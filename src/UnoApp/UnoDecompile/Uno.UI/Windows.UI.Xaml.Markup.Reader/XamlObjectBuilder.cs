using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Uno.Disposables;
using Uno.Extensions;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Uno.Xaml;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Markup.Reader;

internal class XamlObjectBuilder
{
	private class EventHandlerWrapper
	{
		private readonly object _instance;

		private readonly MethodInfo _method;

		public EventHandlerWrapper(object instance, MethodInfo method)
		{
			_instance = instance;
			_method = method;
		}

		public void Handler2(object sender, object args)
		{
			_method.Invoke(_instance, Array.Empty<object>());
		}

		public void Handler1(object sender)
		{
			_method.Invoke(_instance, Array.Empty<object>());
		}
	}

	private XamlFileDefinition _fileDefinition;

	private readonly List<(string elementName, ElementNameSubject bindingSubject)> _elementNames = new List<(string, ElementNameSubject)>();

	private readonly Stack<Type> _styleTargetTypeStack = new Stack<Type>();

	private Queue<Action> _postActions = new Queue<Action>();

	private static readonly Regex _attachedPropertMatch = new Regex("(\\(.*?\\))");

	private static Type[] _genericConvertibles = new Type[11]
	{
		typeof(Brush),
		typeof(SolidColorBrush),
		typeof(Color),
		typeof(Thickness),
		typeof(CornerRadius),
		typeof(FontFamily),
		typeof(GridLength),
		typeof(KeyTime),
		typeof(Duration),
		typeof(Matrix),
		typeof(FontWeight)
	};

	private XamlTypeResolver TypeResolver { get; }

	public XamlObjectBuilder(XamlFileDefinition xamlFileDefinition)
	{
		_fileDefinition = xamlFileDefinition;
		TypeResolver = new XamlTypeResolver(_fileDefinition);
	}

	internal object? Build(object? component = null, bool createInstanceFromXClass = false)
	{
		XamlObjectDefinition control = _fileDefinition.Objects.First();
		object obj = LoadObject(control, null, component, createInstanceFromXClass);
		ApplyPostActions(obj);
		return obj;
	}

	private object? LoadObject(XamlObjectDefinition? control, object? rootInstance, object? component = null, bool createInstanceFromXClass = false)
	{
		object rootInstance2 = rootInstance;
		XamlObjectDefinition control2 = control;
		if (control2 == null)
		{
			return null;
		}
		if (control2.Type.Name == "NullExtension" && control2.Type.PreferredXamlNamespace == "http://schemas.microsoft.com/winfx/2006/xaml")
		{
			return null;
		}
		Type type = TypeResolver.FindType(control2.Type);
		XamlMemberDefinition xamlMemberDefinition = control2.Members.FirstOrDefault((XamlMemberDefinition m) => m.Member.Name == "Class" && m.Member.PreferredXamlNamespace == "http://schemas.microsoft.com/winfx/2006/xaml");
		if (createInstanceFromXClass)
		{
			Type type2 = TypeResolver.FindType(xamlMemberDefinition?.Value?.ToString());
			if ((object)type2 != null)
			{
				return Activator.CreateInstance(type2);
			}
		}
		if (type == null)
		{
			throw new InvalidOperationException($"Unable to find type {control2.Type}");
		}
		XamlMemberDefinition unknownContent = control2.Members.Where((XamlMemberDefinition m) => m.Member.Name == "_UnknownContent").FirstOrDefault();
		object obj = unknownContent?.Value;
		XamlMemberDefinition xamlMemberDefinition2 = control2.Members.Where((XamlMemberDefinition m) => m.Member.Name == "_Initialization").FirstOrDefault();
		bool flag = type == typeof(Brush);
		if (type.Is<FrameworkTemplate>())
		{
			Func<UIElement> func = delegate
			{
				XamlMemberDefinition xamlMemberDefinition5 = unknownContent;
				return LoadObject(xamlMemberDefinition5?.Objects.FirstOrDefault(), rootInstance2) as UIElement;
			};
			return Activator.CreateInstance(type, func);
		}
		if (type.Is<ResourceDictionary>() && unknownContent != null)
		{
			XamlMemberDefinition xamlMemberDefinition3 = unknownContent;
			if (Activator.CreateInstance(type) is ResourceDictionary resourceDictionary)
			{
				{
					foreach (XamlObjectDefinition @object in xamlMemberDefinition3.Objects)
					{
						object obj2 = @object.Members.FirstOrDefault((XamlMemberDefinition m) => m.Member.Name == "Key")?.Value;
						object value = LoadObject(@object, rootInstance2);
						if (obj2 != null)
						{
							resourceDictionary.Add(obj2, value);
						}
					}
					return resourceDictionary;
				}
			}
			throw new InvalidCastException();
		}
		if (type.IsPrimitive && xamlMemberDefinition2?.Value is string value2)
		{
			return Convert.ChangeType(value2, type, CultureInfo.InvariantCulture);
		}
		if (type == typeof(string) && xamlMemberDefinition2?.Value is string result)
		{
			return result;
		}
		if (_genericConvertibles.Contains(type) && control2.Members.Where((XamlMemberDefinition m) => m.Member.Name == "_UnknownContent").FirstOrDefault()?.Value is string value3)
		{
			return XamlBindingHelper.ConvertValue(type, value3);
		}
		object instance = component ?? Activator.CreateInstance(type);
		if (rootInstance2 == null)
		{
			rootInstance2 = instance;
		}
		using (TryProcessStyle())
		{
			foreach (XamlMemberDefinition member in control2.Members)
			{
				ProcessNamedMember(control2, instance, member, rootInstance2);
			}
		}
		return instance;
		IDisposable? TryProcessStyle()
		{
			if (instance is Style)
			{
				XamlMemberDefinition xamlMemberDefinition4 = control2.Members.FirstOrDefault((XamlMemberDefinition m) => m.Member.Name == "TargetType");
				if (xamlMemberDefinition4 != null)
				{
					object obj3 = BuildLiteralValue(xamlMemberDefinition4);
					Type targetType = obj3 as Type;
					if ((object)targetType != null)
					{
						_styleTargetTypeStack.Push(targetType);
						return Disposable.Create(delegate
						{
							if (_styleTargetTypeStack.Pop() != targetType)
							{
								throw new InvalidOperationException("StyleTargetType is out of synchronization");
							}
						});
					}
					throw new InvalidOperationException($"The type {xamlMemberDefinition4.Member.Type} is unknown");
				}
			}
			return null;
		}
	}

	private string RewriteAttachedPropertyPath(string? value)
	{
		if (value == null)
		{
			value = "";
		}
		if (value!.Contains("("))
		{
			foreach (NamespaceDeclaration @namespace in _fileDefinition.Namespaces)
			{
				if (@namespace != null)
				{
					string text = @namespace.Namespace.TrimStart("using:");
					value = value!.Replace("(" + @namespace.Prefix + ":", "(" + text + ":");
				}
			}
			Match match = _attachedPropertMatch.Match(value);
			if (match.Success)
			{
				do
				{
					if (match.Value.Contains(":"))
					{
						continue;
					}
					string[] array = match.Value.Trim('(', ')').Split(new char[1] { '.' });
					if (array.Length == 2)
					{
						Type type = TypeResolver.FindType(array[0]);
						if (type != null)
						{
							string text2 = type.Namespace + ":" + type.Name + "." + array[1];
							value = value!.Replace(match.Value, "(" + text2 + ")");
						}
					}
				}
				while ((match = match.NextMatch()).Success);
			}
		}
		return value;
	}

	private void ProcessNamedMember(XamlObjectDefinition control, object instance, XamlMemberDefinition member, object rootInstance)
	{
		if ((TypeResolver.IsType(control.Type, member.Member.DeclaringType) && !TypeResolver.IsAttachedProperty(member)) || member.Member.Name == "_UnknownContent")
		{
			if (instance is TextBlock instance2)
			{
				ProcessTextBlock(control, instance2, member, rootInstance);
				return;
			}
			if (instance is Span span && member.Member.Name == "_UnknownContent")
			{
				ProcessSpan(control, span, member, rootInstance);
				return;
			}
			PropertyInfo memberProperty = GetMemberProperty(control, member);
			if ((object)memberProperty != null)
			{
				if (member.Objects.None())
				{
					if (!TypeResolver.IsInitializedCollection(memberProperty) && !IsResourcesProperty(memberProperty))
					{
						if (memberProperty.PropertyType == typeof(TargetPropertyPath))
						{
							ProcessTargetPropertyPath(instance, member, memberProperty);
							return;
						}
						GetPropertySetter(memberProperty).Invoke(instance, new object[1] { BuildLiteralValue(member, memberProperty.PropertyType) });
					}
				}
				else if (IsMarkupExtension(member))
				{
					ProcessMemberMarkupExtension(instance, member, memberProperty);
				}
				else
				{
					ProcessMemberElements(instance, member, memberProperty, rootInstance);
				}
				return;
			}
			EventInfo memberEvent = GetMemberEvent(control, member);
			if ((object)memberEvent == null)
			{
				return;
			}
			if (member.Value is string eventHandlerName)
			{
				SubscribeToEvent(instance, rootInstance, memberEvent, eventHandlerName, supportsParameterless: false);
				return;
			}
			XamlObjectDefinition xamlObjectDefinition = member.Objects.FirstOrDefault();
			if (xamlObjectDefinition != null && xamlObjectDefinition.Type.Name == "Bind")
			{
				XamlMemberDefinition xamlMemberDefinition = xamlObjectDefinition.Members.FirstOrDefault();
				if (xamlMemberDefinition != null && xamlMemberDefinition.Value is string eventHandlerName2)
				{
					SubscribeToEvent(instance, rootInstance, memberEvent, eventHandlerName2, supportsParameterless: true);
				}
			}
		}
		else if (TypeResolver.IsAttachedProperty(member))
		{
			DependencyProperty dependencyProperty = TypeResolver.FindDependencyProperty(member);
			if (dependencyProperty == null)
			{
				return;
			}
			if (member.Objects.None())
			{
				(instance as DependencyObject)?.SetValue(dependencyProperty, BuildLiteralValue(member, dependencyProperty.Type));
				return;
			}
			if (IsMarkupExtension(member))
			{
				ProcessMemberMarkupExtension(instance, member, null);
				return;
			}
			if (!(instance is DependencyObject instance3))
			{
				throw new InvalidOperationException($"{instance} is not a DependencyObject");
			}
			ProcessMemberElements(instance3, member, dependencyProperty, rootInstance);
		}
		else
		{
			if (!(member.Member.DeclaringType == null) || !(member.Member.Name == "Name"))
			{
				return;
			}
			PropertyInfo propertyByName = TypeResolver.GetPropertyByName(control.Type, "Name");
			if ((object)propertyByName != null)
			{
				GetPropertySetter(propertyByName).Invoke(instance, new object[1] { member.Value });
			}
			if (rootInstance != null && member.Value is string propertyName)
			{
				BindingFlags value = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
				Type type = rootInstance.GetType();
				PropertyInfo propertyByName2 = TypeResolver.GetPropertyByName(type, propertyName, value);
				if ((object)propertyByName2 != null)
				{
					GetPropertySetter(propertyByName2).Invoke(rootInstance, new object[1] { instance });
				}
				else
				{
					TypeResolver.GetFieldByName(type, propertyName, value)?.SetValue(rootInstance, instance);
				}
			}
		}
	}

	private static void SubscribeToEvent(object instance, object rootInstance, EventInfo eventInfo, string eventHandlerName, bool supportsParameterless)
	{
		int num = eventInfo.EventHandlerType?.GetMethod("Invoke")?.GetParameters().Length ?? throw new InvalidOperationException();
		Type type = rootInstance.GetType();
		MethodInfo method = GetMethod(eventHandlerName, num, type);
		if (method != null)
		{
			Delegate handler = method.CreateDelegate(eventInfo.EventHandlerType, rootInstance);
			eventInfo.AddEventHandler(instance, handler);
		}
		else if (supportsParameterless)
		{
			MethodInfo method2 = GetMethod(eventHandlerName, 0, type);
			if ((object)method2 != null && num <= 2)
			{
				EventHandlerWrapper firstArgument = new EventHandlerWrapper(rootInstance, method2);
				MethodInfo method3 = typeof(EventHandlerWrapper).GetMethod((num == 2) ? "Handler2" : "Handler1") ?? throw new InvalidOperationException();
				Delegate handler2 = Delegate.CreateDelegate(eventInfo.EventHandlerType, firstArgument, method3);
				eventInfo.AddEventHandler(instance, handler2);
			}
		}
	}

	private static MethodInfo? GetMethod(string methodName, int paramCount, Type type)
	{
		string methodName2 = methodName;
		return (from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			where m.Name == methodName2 && m.GetParameters().Length == paramCount
			select m).FirstOrDefault();
	}

	private void ProcessSpan(XamlObjectDefinition control, Span span, XamlMemberDefinition member, object rootInstance)
	{
		if (member.Objects.Count != 0)
		{
			foreach (XamlObjectDefinition @object in member.Objects)
			{
				if (LoadObject(@object, rootInstance) is Inline item)
				{
					span.Inlines.Add(item);
				}
			}
		}
		if (member.Value != null)
		{
			span.Inlines.Add(new Run
			{
				Text = member.Value.ToString()
			});
		}
	}

	private void ProcessTargetPropertyPath(object instance, XamlMemberDefinition member, PropertyInfo propertyInfo)
	{
		if (member.Value is string text)
		{
			int num = text.IndexOf(".");
			string targetName = text.Substring(0, num);
			string value = text.Substring(num + 1);
			if (instance is Setter setter)
			{
				setter.Target = new TargetPropertyPath(targetName, new PropertyPath(RewriteAttachedPropertyPath(value)));
			}
			return;
		}
		throw new NotSupportedException($"The property {propertyInfo} must be provided a value");
	}

	private void ProcessTextBlock(XamlObjectDefinition control, TextBlock instance, XamlMemberDefinition member, object rootInstance)
	{
		if (member.Objects.Any())
		{
			if (!IsMarkupExtension(member))
			{
				foreach (XamlObjectDefinition @object in member.Objects)
				{
					if (LoadObject(@object, rootInstance) is Inline item)
					{
						instance.Inlines.Add(item);
					}
				}
				return;
			}
			ProcessMemberMarkupExtension(instance, member, null);
		}
		else
		{
			PropertyInfo memberProperty = GetMemberProperty(control, member);
			if ((object)memberProperty != null)
			{
				GetPropertySetter(memberProperty).Invoke(instance, new object[1] { BuildLiteralValue(member, memberProperty.PropertyType) });
			}
		}
	}

	private void ProcessMemberElements(DependencyObject instance, XamlMemberDefinition member, DependencyProperty property, object rootInstance)
	{
		DependencyProperty property2 = property;
		if (TypeResolver.IsCollectionOrListType(property2.Type))
		{
			object obj = BuildInstance();
			AddCollectionItems(obj, member.Objects, rootInstance);
			instance.SetValue(property2, obj);
		}
		else
		{
			instance.SetValue(property2, LoadObject(member.Objects.First(), rootInstance));
		}
		object BuildInstance()
		{
			if (property2.Type.GetGenericTypeDefinition() == typeof(IList<>))
			{
				return Activator.CreateInstance(typeof(List<>).MakeGenericType(property2.Type.GenericTypeArguments[0]));
			}
			return Activator.CreateInstance(property2.Type);
		}
	}

	private void ProcessMemberElements(object instance, XamlMemberDefinition member, PropertyInfo propertyInfo, object rootInstance)
	{
		if (TypeResolver.IsCollectionOrListType(propertyInfo.PropertyType))
		{
			if (propertyInfo.PropertyType == typeof(ResourceDictionary))
			{
				MethodInfo[] methods = propertyInfo.PropertyType.GetMethods();
				MethodInfo methodInfo = propertyInfo.PropertyType.GetMethod("Add", new Type[2]
				{
					typeof(object),
					typeof(object)
				}) ?? throw new InvalidOperationException($"The property {propertyInfo} type does not provide an Add method (Line {member.LineNumber}:{member.LinePosition}");
				{
					foreach (XamlObjectDefinition @object in member.Objects)
					{
						object obj = LoadObject(@object, rootInstance);
						object resourceKey = GetResourceKey(@object);
						Type resourceTargetType = GetResourceTargetType(@object);
						if (obj?.GetType() == typeof(Style) && resourceTargetType == null)
						{
							throw new InvalidOperationException($"No target type was specified (Line {member.LineNumber}:{member.LinePosition}");
						}
						if (propertyInfo.GetMethod == null)
						{
							throw new InvalidOperationException($"The property {propertyInfo} does not provide a getter (Line {member.LineNumber}:{member.LinePosition}");
						}
						object obj2 = propertyInfo.GetMethod!.Invoke(instance, null);
						methodInfo.Invoke(obj2, new object[2]
						{
							resourceKey ?? resourceTargetType,
							obj
						});
					}
					return;
				}
			}
			if (TypeResolver.IsNewableProperty(propertyInfo, out var newableType))
			{
				object obj3 = Activator.CreateInstance(newableType);
				AddCollectionItems(obj3, member.Objects, rootInstance);
				GetPropertySetter(propertyInfo).Invoke(instance, new object[1] { obj3 });
				return;
			}
			if (!TypeResolver.IsInitializedCollection(propertyInfo))
			{
				throw new InvalidOperationException($"Unsupported collection type {propertyInfo.PropertyType} on {propertyInfo}");
			}
			if (propertyInfo.GetMethod == null)
			{
				throw new InvalidOperationException($"The property {propertyInfo} does not provide a getter (Line {member.LineNumber}:{member.LinePosition}");
			}
			object obj4 = propertyInfo.GetMethod!.Invoke(instance, null);
			if (obj4 == null)
			{
				throw new InvalidOperationException($"The property {propertyInfo} getter did not provide a value (Line {member.LineNumber}:{member.LinePosition}");
			}
			if (obj4 is IDictionary<object, object> dictionary)
			{
				AddGenericDictionaryItems(dictionary, member.Objects, rootInstance);
			}
			else
			{
				AddCollectionItems(obj4, member.Objects, rootInstance);
			}
		}
		else
		{
			GetPropertySetter(propertyInfo).Invoke(instance, new object[1] { LoadObject(member.Objects.First(), rootInstance) });
		}
	}

	private static MethodInfo GetPropertySetter(PropertyInfo propertyInfo)
	{
		return propertyInfo?.SetMethod ?? throw new InvalidOperationException($"Unable to find setter for property [{propertyInfo}]");
	}

	private void ProcessMemberMarkupExtension(object instance, XamlMemberDefinition member, PropertyInfo? propertyInfo)
	{
		if (IsBindingMarkupNode(member))
		{
			ProcessBindingMarkupNode(instance, member);
		}
		else if (IsStaticResourceMarkupNode(member) || IsThemeResourceMarkupNode(member))
		{
			ProcessStaticResourceMarkupNode(instance, member, propertyInfo);
		}
	}

	private void ProcessStaticResourceMarkupNode(object instance, XamlMemberDefinition member, PropertyInfo? propertyInfo)
	{
		XamlObjectDefinition xamlObjectDefinition = member.Objects.FirstOrDefault();
		if (xamlObjectDefinition == null)
		{
			return;
		}
		string text = xamlObjectDefinition.Members.FirstOrDefault()?.Value?.ToString();
		DependencyProperty dependencyProperty = TypeResolver.FindDependencyProperty(member);
		if (text != null && dependencyProperty != null && instance is DependencyObject owner)
		{
			ResourceResolver.ApplyResource(owner, dependencyProperty, text, IsThemeResourceMarkupNode(member), isHotReloadSupported: true);
			FrameworkElement fe = instance as FrameworkElement;
			if (fe != null)
			{
				fe.Loading += delegate
				{
					fe.UpdateResourceBindings();
				};
			}
		}
		else if (propertyInfo != null)
		{
			GetPropertySetter(propertyInfo).Invoke(instance, new object[1] { ResourceResolver.ResolveResourceStatic(text, propertyInfo!.PropertyType) });
			if (instance is Setter setter && propertyInfo!.Name == "Value")
			{
				setter.ApplyThemeResourceUpdateValues(text, null, IsThemeResourceMarkupNode(member), isHotReload: true);
			}
		}
	}

	private static object? ResolveStaticResource(object? instance, string? keyName)
	{
		string keyName2 = keyName;
		object value;
		return (from fe in (instance as FrameworkElement).Flatten((FrameworkElement i) => i?.Parent as FrameworkElement)
			select (fe != null && fe.Resources.TryGetValue(keyName2, out value, shouldCheckSystem: false)) ? value : null).Concat(ResourceResolver.ResolveTopLevelResource(keyName2)).Trim().FirstOrDefault();
	}

	private bool IsStaticResourceMarkupNode(XamlMemberDefinition member)
	{
		return member.Objects.Any((XamlObjectDefinition o) => o.Type.Name == "StaticResource");
	}

	private bool IsThemeResourceMarkupNode(XamlMemberDefinition member)
	{
		return member.Objects.Any((XamlObjectDefinition o) => o.Type.Name == "ThemeResource");
	}

	private bool IsResourcesProperty(PropertyInfo propertyInfo)
	{
		if (propertyInfo.Name == "Resources")
		{
			return propertyInfo.PropertyType == typeof(ResourceDictionary);
		}
		return false;
	}

	private void ProcessBindingMarkupNode(object instance, XamlMemberDefinition member)
	{
		Binding binding = BuildBindingExpression(instance, member);
		if (instance is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			DependencyProperty dependencyProperty = TypeResolver.FindDependencyProperty(member);
			if (dependencyProperty != null)
			{
				dependencyObjectStoreProvider.Store.SetBinding(dependencyProperty, binding);
				return;
			}
			PropertyInfo propertyByName = TypeResolver.GetPropertyByName(member.Owner.Type, member.Member.Name);
			if ((object)propertyByName != null)
			{
				if (member.Objects.Empty())
				{
					GetPropertySetter(propertyByName).Invoke(instance, new object[1] { BuildLiteralValue(member, propertyByName.PropertyType) });
					return;
				}
				MethodInfo propertySetter = GetPropertySetter(propertyByName);
				object[] parameters = new Binding[1] { BuildBindingExpression(null, member) };
				propertySetter.Invoke(instance, parameters);
				return;
			}
			throw new NotSupportedException($"Unknown dependency property {member.Member}");
		}
		throw new NotSupportedException($"Binding is not supported on {member.Member}");
	}

	private Binding BuildBindingExpression(object? instance, XamlMemberDefinition member)
	{
		object instance2 = instance;
		XamlObjectDefinition xamlObjectDefinition = member.Objects.FirstOrDefault((XamlObjectDefinition o) => o.Type.Name == "Binding");
		XamlObjectDefinition xamlObjectDefinition2 = member.Objects.FirstOrDefault((XamlObjectDefinition o) => o.Type.Name == "TemplateBinding");
		Binding binding = new Binding();
		if (xamlObjectDefinition2 != null)
		{
			binding.RelativeSource = RelativeSource.TemplatedParent;
		}
		if (xamlObjectDefinition == null && xamlObjectDefinition2 == null)
		{
			throw new InvalidOperationException("Unable to find Binding or TemplateBinding node");
		}
		string staticResourceName;
		foreach (XamlMemberDefinition member2 in (xamlObjectDefinition ?? xamlObjectDefinition2).Members)
		{
			switch (member2.Member.Name)
			{
			case "_PositionalParameters":
			case "Path":
				binding.Path = RewriteAttachedPropertyPath(member2.Value?.ToString());
				break;
			case "ElementName":
			{
				ElementNameSubject elementNameSubject = new ElementNameSubject();
				binding.ElementName = elementNameSubject;
				string text = member2.Value?.ToString();
				if (text != null)
				{
					AddElementName(text, elementNameSubject);
				}
				break;
			}
			case "TargetNullValue":
				binding.TargetNullValue = member2.Value?.ToString();
				break;
			case "FallbackValue":
				binding.FallbackValue = member2.Value?.ToString();
				break;
			case "UpdateSourceTrigger":
			{
				if (Enum.TryParse<UpdateSourceTrigger>(member2.Value?.ToString(), out var result2))
				{
					binding.UpdateSourceTrigger = result2;
					break;
				}
				throw new NotSupportedException($"Invalid binding mode {member2.Value}");
			}
			case "RelativeSource":
			{
				XamlObjectDefinition xamlObjectDefinition4 = member2.Objects.First();
				if (xamlObjectDefinition4 != null && xamlObjectDefinition4.Type.Name == "RelativeSource")
				{
					string text2 = xamlObjectDefinition4.Members.FirstOrDefault()?.Value?.ToString()?.ToLowerInvariant();
					if (!(text2 == "templatedparent"))
					{
						throw new NotSupportedException("RelativeSource " + text2 + " is not supported");
					}
					binding.RelativeSource = RelativeSource.TemplatedParent;
				}
				break;
			}
			case "Mode":
			{
				if (Enum.TryParse<BindingMode>(member2.Value?.ToString(), out var result))
				{
					binding.Mode = result;
					break;
				}
				throw new NotSupportedException($"Invalid binding mode {member2.Value}");
			}
			case "ConverterParameter":
				binding.ConverterParameter = member2.Value?.ToString();
				break;
			case "Converter":
			{
				XamlObjectDefinition xamlObjectDefinition3 = member2.Objects.First();
				if (xamlObjectDefinition3 != null)
				{
					if (!(xamlObjectDefinition3.Type.Name == "StaticResource"))
					{
						throw new NotSupportedException("Markup extension " + xamlObjectDefinition3.Type.Name + " is not supported for Bindiner.Converter");
					}
					staticResourceName = xamlObjectDefinition3.Members.FirstOrDefault()?.Value?.ToString();
					_postActions.Enqueue(ResolveResource);
				}
				break;
			}
			default:
				throw new NotSupportedException($"Binding option {member2.Member} is not supported");
			}
		}
		return binding;
	}

	private void AddElementName(string elementName, ElementNameSubject subject)
	{
		_elementNames.Add((elementName, subject));
	}

	private bool IsBindingMarkupNode(XamlMemberDefinition member)
	{
		return member.Objects.Any((XamlObjectDefinition o) => o.Type.Name == "Binding" || o.Type.Name == "TemplateBinding");
	}

	private static bool IsMarkupExtension(XamlMemberDefinition member)
	{
		return member.Objects.Where((XamlObjectDefinition m) => m.Type.Name == "Binding" || m.Type.Name == "Bind" || m.Type.Name == "StaticResource" || m.Type.Name == "ThemeResource" || m.Type.Name == "TemplateBinding").Any();
	}

	private void AddGenericDictionaryItems(IDictionary<object, object> dictionary, IEnumerable<XamlObjectDefinition> nonBindingObjects, object rootInstance)
	{
		foreach (XamlObjectDefinition nonBindingObject in nonBindingObjects)
		{
			object obj = LoadObject(nonBindingObject, rootInstance);
			object resourceKey = GetResourceKey(nonBindingObject);
			if (resourceKey != null && obj != null)
			{
				dictionary[resourceKey] = obj;
			}
		}
	}

	private void AddDictionaryItems(object collectionInstance, IEnumerable<XamlObjectDefinition> nonBindingObjects, object rootInstance)
	{
		MethodInfo methodInfo = null;
		foreach (XamlObjectDefinition nonBindingObject in nonBindingObjects)
		{
			object item = LoadObject(nonBindingObject, rootInstance);
			if (methodInfo == null)
			{
				methodInfo = (from m in collectionInstance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
					where m.Name == "set_Item"
					select m).FirstOrDefault(delegate(MethodInfo m)
				{
					ParameterInfo[] parameters = m.GetParameters();
					return parameters != null && parameters.Length == 1 && (item?.GetType() ?? typeof(object)).Is(parameters[0].ParameterType);
				}) ?? throw new InvalidOperationException($"The type does {collectionInstance.GetType()} contains an Add({item?.GetType()}) method");
			}
			methodInfo.Invoke(collectionInstance, new object[1] { item });
		}
	}

	private void AddCollectionItems(object collectionInstance, IEnumerable<XamlObjectDefinition> nonBindingObjects, object rootInstance)
	{
		MethodInfo methodInfo = null;
		foreach (XamlObjectDefinition nonBindingObject in nonBindingObjects)
		{
			object item = LoadObject(nonBindingObject, rootInstance);
			if (methodInfo == null)
			{
				methodInfo = (from m in collectionInstance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
					where m.Name == "Add"
					select m).FirstOrDefault(delegate(MethodInfo m)
				{
					ParameterInfo[] parameters = m.GetParameters();
					return parameters != null && parameters.Length == 1 && (item?.GetType() ?? typeof(object)).Is(parameters[0].ParameterType);
				}) ?? throw new InvalidOperationException($"The type does {collectionInstance.GetType()} contains an Add({item?.GetType()}) method");
			}
			methodInfo.Invoke(collectionInstance, new object[1] { item });
		}
	}

	private object? GetResourceKey(XamlObjectDefinition child)
	{
		return child.Members.FirstOrDefault((XamlMemberDefinition m) => string.Equals(m.Member.Name, "Name", StringComparison.OrdinalIgnoreCase) || string.Equals(m.Member.Name, "Key", StringComparison.OrdinalIgnoreCase))?.Value?.ToString();
	}

	private Type? GetResourceTargetType(XamlObjectDefinition child)
	{
		return TypeResolver.FindType(child.Members.FirstOrDefault((XamlMemberDefinition m) => string.Equals(m.Member.Name, "TargetType", StringComparison.OrdinalIgnoreCase))?.Value?.ToString() ?? "");
	}

	private PropertyInfo? GetMemberProperty(XamlObjectDefinition control, XamlMemberDefinition member)
	{
		if (member.Member.Name == "_UnknownContent")
		{
			PropertyInfo propertyInfo = TypeResolver.FindContentProperty(TypeResolver.FindType(control.Type));
			if (propertyInfo == null)
			{
				throw new InvalidOperationException($"Implicit content is not supported on {control.Type}");
			}
			return propertyInfo;
		}
		return TypeResolver.GetPropertyByName(control.Type, member.Member.Name);
	}

	private EventInfo? GetMemberEvent(XamlObjectDefinition control, XamlMemberDefinition member)
	{
		return TypeResolver.GetEventByName(control.Type, member.Member.Name);
	}

	private object? BuildLiteralValue(XamlMemberDefinition member, Type? propertyType = null)
	{
		if (member.Objects.None())
		{
			string text = member.Value?.ToString();
			propertyType = propertyType ?? TypeResolver.FindPropertyType(member.Member);
			if (propertyType != null)
			{
				if (propertyType == typeof(Type))
				{
					return TypeResolver.FindType(text);
				}
				if (propertyType == typeof(DependencyProperty) && member.Owner.Type.Name == "Setter")
				{
					Type type = _styleTargetTypeStack.Peek();
					DependencyProperty dependencyProperty = TypeResolver.FindDependencyProperty(type, text);
					if (dependencyProperty != null)
					{
						return dependencyProperty;
					}
					throw new Exception($"The property {type}.{text} does not exist");
				}
				return BuildLiteralValue(propertyType, text);
			}
			throw new Exception("The property " + member.Owner?.Type?.Name + "." + member.Member?.Name + " is unknown");
		}
		XamlObjectDefinition xamlObjectDefinition = member.Objects.First();
		throw new NotSupportedException("MarkupExtension {0} is not supported.".InvariantCultureFormat(xamlObjectDefinition.Type.Name));
	}

	private object? BuildLiteralValue(Type propertyType, string? memberValue)
	{
		Type propertyType2 = propertyType;
		return BindingPropertyHelper.Convert(() => propertyType2, memberValue);
	}

	private void ApplyPostActions(object? instance)
	{
		if (instance is FrameworkElement root)
		{
			ResolveElementNames(root);
		}
		while (_postActions.Count != 0)
		{
			_postActions.Dequeue()();
		}
	}

	private void ResolveElementNames(FrameworkElement root)
	{
		foreach (var (name, elementNameSubject) in _elementNames)
		{
			if (root.FindName(name) is DependencyObject elementInstance)
			{
				elementNameSubject.ElementInstance = elementInstance;
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Uno.Conversion;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.Extensions;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.DataBinding;

internal static class BindingPropertyHelper
{
	private class UnoGetMemberBinder : GetMemberBinder
	{
		public UnoGetMemberBinder(string name, bool ignoreCase)
			: base(name, ignoreCase)
		{
		}

		public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			throw new NotSupportedException();
		}
	}

	private class UnoSetMemberBinder : SetMemberBinder
	{
		public UnoSetMemberBinder(string name, bool ignoreCase)
			: base(name, ignoreCase)
		{
		}

		public override DynamicMetaObject FallbackSetMember(DynamicMetaObject target, DynamicMetaObject value, DynamicMetaObject errorSuggestion)
		{
			throw new NotImplementedException();
		}
	}

	private static readonly Logger _log;

	private static Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences?, bool>, ValueGetterHandler> _getValueGetter;

	private static Dictionary<CachedTuple<Type, string, bool, DependencyPropertyValuePrecedences>, ValueSetterHandler> _getValueSetter;

	private static Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences>, ValueGetterHandler> _getPrecedenceSpecificValueGetter;

	private static Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences>, ValueGetterHandler> _getSubstituteValueGetter;

	private static Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences>, ValueUnsetterHandler> _getValueUnsetter;

	private static Dictionary<CachedTuple<Type, string>, bool> _isEvent;

	private static Dictionary<CachedTuple<Type, string, bool>, Type?> _getPropertyType;

	public static Func<MethodInfo, Func<object, object?[], object?>> MethodInvokerBuilder { get; set; }

	public static IBindableMetadataProvider? BindableMetadataProvider { get; set; }

	public static DefaultConversionExtensions Conversion { get; private set; }

	static BindingPropertyHelper()
	{
		_log = typeof(BindingPropertyHelper).Log();
		_getValueGetter = new Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences?, bool>, ValueGetterHandler>(CachedTuple<Type, string, DependencyPropertyValuePrecedences?, bool>.Comparer);
		_getValueSetter = new Dictionary<CachedTuple<Type, string, bool, DependencyPropertyValuePrecedences>, ValueSetterHandler>(CachedTuple<Type, string, bool, DependencyPropertyValuePrecedences>.Comparer);
		_getPrecedenceSpecificValueGetter = new Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences>, ValueGetterHandler>(CachedTuple<Type, string, DependencyPropertyValuePrecedences>.Comparer);
		_getSubstituteValueGetter = new Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences>, ValueGetterHandler>(CachedTuple<Type, string, DependencyPropertyValuePrecedences>.Comparer);
		_getValueUnsetter = new Dictionary<CachedTuple<Type, string, DependencyPropertyValuePrecedences>, ValueUnsetterHandler>(CachedTuple<Type, string, DependencyPropertyValuePrecedences>.Comparer);
		_isEvent = new Dictionary<CachedTuple<Type, string>, bool>(CachedTuple<Type, string>.Comparer);
		_getPropertyType = new Dictionary<CachedTuple<Type, string, bool>, Type>(CachedTuple<Type, string, bool>.Comparer);
		MethodInvokerBuilder = new Func<MethodInfo, Func<object, object[], object>>(DefaultInvokerBuilder);
		Conversion = new DefaultConversionExtensions();
	}

	internal static void ClearCaches()
	{
		_getValueGetter.Clear();
		_getValueSetter.Clear();
		_getPrecedenceSpecificValueGetter.Clear();
		_getSubstituteValueGetter.Clear();
		_getValueUnsetter.Clear();
		_isEvent.Clear();
		_getPropertyType.Clear();
	}

	private static Func<object, object?[], object?> DefaultInvokerBuilder(MethodInfo method)
	{
		MethodInfo method2 = method;
		return (object instance, object?[] args) => method2.Invoke(instance, args);
	}

	public static bool IsEvent(Type type, string property)
	{
		CachedTuple<Type, string> key = CachedTuple.Create(type, property);
		lock (_isEvent)
		{
			if (!_isEvent.TryGetValue(key, out var value))
			{
				_isEvent.Add(key, value = InternalIsEvent(type, property));
				return value;
			}
			return value;
		}
	}

	public static Type? GetPropertyType(Type type, string property, bool allowPrivateMembers)
	{
		CachedTuple<Type, string, bool> key = CachedTuple.Create(type, property, allowPrivateMembers);
		lock (_getPropertyType)
		{
			if (!_getPropertyType.TryGetValue(key, out var value))
			{
				_getPropertyType.Add(key, value = InternalGetPropertyType(type, property, allowPrivateMembers));
				return value;
			}
			return value;
		}
	}

	internal static ValueGetterHandler GetValueGetter(Type type, string property)
	{
		return GetValueGetter(type, property, null, allowPrivateMembers: false);
	}

	internal static ValueGetterHandler GetValueGetter(Type type, string property, DependencyPropertyValuePrecedences? precedence, bool allowPrivateMembers)
	{
		CachedTuple<Type, string, DependencyPropertyValuePrecedences?, bool> key = CachedTuple.Create(type, property, precedence, allowPrivateMembers);
		lock (_getValueGetter)
		{
			if (!_getValueGetter.TryGetValue(key, out var value))
			{
				_getValueGetter.Add(key, value = InternalGetValueGetter(type, property, precedence, allowPrivateMembers));
				return value;
			}
			return value;
		}
	}

	internal static ValueSetterHandler GetValueSetter(Type type, string property, bool convert)
	{
		return GetValueSetter(type, property, convert, DependencyPropertyValuePrecedences.Local);
	}

	internal static ValueSetterHandler GetValueSetter(Type type, string property, bool convert, DependencyPropertyValuePrecedences precedence)
	{
		CachedTuple<Type, string, bool, DependencyPropertyValuePrecedences> key = CachedTuple.Create(type, property, convert, precedence);
		lock (_getValueSetter)
		{
			if (!_getValueSetter.TryGetValue(key, out var value))
			{
				_getValueSetter.Add(key, value = InternalGetValueSetter(type, property, convert, precedence));
				return value;
			}
			return value;
		}
	}

	internal static ValueGetterHandler GetPrecedenceSpecificValueGetter(Type type, string property, DependencyPropertyValuePrecedences precedence)
	{
		CachedTuple<Type, string, DependencyPropertyValuePrecedences> key = CachedTuple.Create(type, property, precedence);
		lock (_getPrecedenceSpecificValueGetter)
		{
			if (!_getPrecedenceSpecificValueGetter.TryGetValue(key, out var value))
			{
				_getPrecedenceSpecificValueGetter.Add(key, value = InternalGetPrecedenceSpecificValueGetter(type, property, precedence));
				return value;
			}
			return value;
		}
	}

	internal static ValueGetterHandler GetSubstituteValueGetter(Type type, string property, DependencyPropertyValuePrecedences precedence)
	{
		CachedTuple<Type, string, DependencyPropertyValuePrecedences> key = CachedTuple.Create(type, property, precedence);
		lock (_getSubstituteValueGetter)
		{
			if (!_getSubstituteValueGetter.TryGetValue(key, out var value))
			{
				_getSubstituteValueGetter.Add(key, value = InternalGetSubstituteValueGetter(type, property, precedence));
				return value;
			}
			return value;
		}
	}

	internal static ValueUnsetterHandler GetValueUnsetter(Type type, string property)
	{
		return GetValueUnsetter(type, property, DependencyPropertyValuePrecedences.Local);
	}

	internal static ValueUnsetterHandler GetValueUnsetter(Type type, string property, DependencyPropertyValuePrecedences precedence)
	{
		CachedTuple<Type, string, DependencyPropertyValuePrecedences> key = CachedTuple.Create(type, property, precedence);
		lock (_getValueUnsetter)
		{
			if (!_getValueUnsetter.TryGetValue(key, out var value))
			{
				_getValueUnsetter.Add(key, value = InternalGetValueUnsetter(type, property, precedence));
				return value;
			}
			return value;
		}
	}

	private static bool InternalIsEvent(Type type, string property)
	{
		return type.GetEvent(property) != null;
	}

	private static Type? InternalGetPropertyType(Type type, string property, bool allowPrivateMembers)
	{
		if (type == typeof(UnsetValue))
		{
			return null;
		}
		property = SanitizePropertyName(type, property);
		if (IsValidMetadataProviderType(type) && BindableMetadataProvider != null)
		{
			BindablePropertyDescriptor propertByBindableMetadataProvider = BindablePropertyDescriptor.GetPropertByBindableMetadataProvider(type, property);
			if (propertByBindableMetadataProvider.OwnerType != null)
			{
				if (IsIndexerFormat(property) && propertByBindableMetadataProvider.OwnerType.GetIndexerGetter() != null)
				{
					return typeof(object);
				}
				if (propertByBindableMetadataProvider.Property != null)
				{
					return propertByBindableMetadataProvider.Property.PropertyType;
				}
				_log.ErrorFormat("The [{0}] property does not exist on type [{1}]", property, type);
				return null;
			}
		}
		if (_log.IsEnabled(LogLevel.Debug))
		{
			_log.Debug($"GetPropertyType({type}, {property}) [Reflection]");
		}
		if (IsIndexerFormat(property))
		{
			PropertyInfo propertyInfo = GetPropertyInfo(type, "Item", allowPrivateMembers: false);
			if (propertyInfo != null)
			{
				return propertyInfo.PropertyType;
			}
			_log.ErrorFormat("The Indexer property getter does not exist on type [{0}]", type);
			return null;
		}
		PropertyInfo propertyInfo2 = GetPropertyInfo(type, property, allowPrivateMembers: false);
		if (propertyInfo2 != null)
		{
			return propertyInfo2.PropertyType;
		}
		if (allowPrivateMembers)
		{
			FieldInfo fieldInfo = GetFieldInfo(type, property, allowPrivateMembers: true);
			if (fieldInfo != null)
			{
				return fieldInfo.FieldType;
			}
		}
		MethodInfo attachedPropertyGetter = GetAttachedPropertyGetter(type, property);
		if (attachedPropertyGetter != null)
		{
			return attachedPropertyGetter.ReturnType;
		}
		if (type.IsPrimitive && property == "Value")
		{
			return type;
		}
		_log.ErrorFormat("The [{0}] property getter does not exist on type [{1}]", property, type);
		return null;
	}

	private static PropertyInfo? GetPropertyInfo(Type type, string name, bool allowPrivateMembers)
	{
		do
		{
			PropertyInfo property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | (allowPrivateMembers ? BindingFlags.NonPublic : BindingFlags.Default) | BindingFlags.DeclaredOnly);
			if (property != null)
			{
				return property;
			}
			type = type.BaseType;
		}
		while (type != null);
		return null;
	}

	private static FieldInfo? GetFieldInfo(Type type, string name, bool allowPrivateMembers)
	{
		do
		{
			FieldInfo field = type.GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | (allowPrivateMembers ? BindingFlags.NonPublic : BindingFlags.Default) | BindingFlags.DeclaredOnly);
			if (field != null)
			{
				return field;
			}
			type = type.BaseType;
		}
		while (type != null);
		return null;
	}

	private static bool IsIndexerFormat(string property)
	{
		if (property.Length > 0 && property[0] == '[')
		{
			return property[property.Length - 1] == ']';
		}
		return false;
	}

	private static string SanitizePropertyName(Type type, string property)
	{
		if (property.Contains("."))
		{
			string[] array = property.Replace(":", ".").Split(new char[1] { '.' }).Reverse()
				.Take(2)
				.Reverse()
				.ToArray();
			if (array.Length == 2 && (array[0] == type.Name || array[0] == "UIElement" || array[0] == "FrameworkElement"))
			{
				property = array[1];
			}
		}
		return property;
	}

	private static ValueGetterHandler InternalGetValueGetter(Type type, string property, DependencyPropertyValuePrecedences? precedence, bool allowPrivateMembers)
	{
		Type type2 = type;
		string property2 = property;
		if (type2 == typeof(UnsetValue))
		{
			return new ValueGetterHandler(UnsetValueGetter);
		}
		property2 = SanitizePropertyName(type2, property2);
		if (IsIndexerFormat(property2))
		{
			string indexerString = property2.Substring(1, property2.Length - 2);
			if (type2.IsArray)
			{
				if (int.TryParse(indexerString, out var index))
				{
					return delegate(object obj)
					{
						if (obj is Array array && array.Length > index)
						{
							return array.GetValue(index);
						}
						_log.ErrorFormat($"The index [{0}] was outside of the bounds of the [{1}]", index, type2);
						return DependencyProperty.UnsetValue;
					};
				}
				_log.ErrorFormat("The property [{0}] is not valid for [{1}]", property2, type2);
			}
			else if (type2.Is<IList>())
			{
				if (int.TryParse(indexerString, out var index2))
				{
					return delegate(object obj)
					{
						if (obj is IList list && list.Count > index2)
						{
							return list[index2];
						}
						_log.ErrorFormat($"The index [{0}] was outside of the bounds of the [{1}]", index2, type2);
						return DependencyProperty.UnsetValue;
					};
				}
				_log.ErrorFormat("The property [{0}] is not valid for [{1}]", property2, type2);
			}
			if (IsValidMetadataProviderType(type2) && BindableMetadataProvider != null)
			{
				IBindableType bindableTypeByType = BindableMetadataProvider!.GetBindableTypeByType(type2);
				if (bindableTypeByType != null)
				{
					StringIndexerGetterDelegate indexerMethod = bindableTypeByType.GetIndexerGetter();
					if (indexerMethod != null)
					{
						return (object instance) => indexerMethod(instance, indexerString);
					}
				}
			}
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.Debug($"GetValueGetter({type2}, {property2}) [Reflection]");
			}
			PropertyInfo indexerInfo = GetPropertyInfo(type2, "Item", allowPrivateMembers);
			if (indexerInfo != null)
			{
				MethodInfo getMethod = indexerInfo.GetGetMethod();
				if (getMethod == null)
				{
					Func<object> empty3 = Funcs.CreateMemoized(delegate
					{
						_log.ErrorFormat("The Indexer Getter does not exist on [{0}]", type2);
						return DependencyProperty.UnsetValue;
					});
					return (object instance) => empty3();
				}
				Func<object, object?[], object?> handler2 = MethodInvokerBuilder(getMethod);
				return (object instance) => handler2(instance, new object[1] { Convert(() => indexerInfo.GetIndexParameters()[0].ParameterType, indexerString) });
			}
			Func<object> empty2 = Funcs.CreateMemoized(delegate
			{
				_log.ErrorFormat("The Indexer property getter does not exist on type [{0}]", type2);
				return DependencyProperty.UnsetValue;
			});
			return (object instance) => empty2();
		}
		if (IsValidMetadataProviderType(type2) && BindableMetadataProvider != null)
		{
			BindablePropertyDescriptor propertByBindableMetadataProvider = BindablePropertyDescriptor.GetPropertByBindableMetadataProvider(type2, property2);
			if (propertByBindableMetadataProvider.OwnerType != null && propertByBindableMetadataProvider != null && propertByBindableMetadataProvider.Property?.Getter != null)
			{
				DependencyProperty dependencyProperty = propertByBindableMetadataProvider.Property.DependencyProperty;
				if (dependencyProperty != null)
				{
					return (object instance) => instance.GetValue(dependencyProperty, precedence);
				}
				PropertyGetterHandler getter = propertByBindableMetadataProvider.Property.Getter;
				return (object instance) => getter(instance, precedence);
			}
		}
		if (_log.IsEnabled(LogLevel.Debug))
		{
			_log.Debug($"GetValueGetter({type2}, {property2}) [Reflection]");
		}
		DependencyProperty dp = FindDependencyProperty(type2, property2);
		if (dp != null)
		{
			if (!precedence.HasValue)
			{
				return (object instance) => ((DependencyObject)instance).GetValue(dp);
			}
			return (object instance) => ((DependencyObject)instance).GetValue(dp, precedence.Value);
		}
		PropertyInfo propertyInfo = GetPropertyInfo(type2, property2, allowPrivateMembers);
		if (propertyInfo != null)
		{
			MethodInfo getMethod2 = propertyInfo.GetGetMethod(allowPrivateMembers);
			if (getMethod2 == null)
			{
				Func<object> emptyProperty = Funcs.CreateMemoized(delegate
				{
					_log.ErrorFormat("The Property [{0}] Getter does not exist on [{1}]", property2, type2);
					return DependencyProperty.UnsetValue;
				});
				return (object instance) => emptyProperty();
			}
			Func<object, object?[], object?> handler = MethodInvokerBuilder(getMethod2);
			return (object instance) => handler(instance, new object[0]);
		}
		if (allowPrivateMembers)
		{
			FieldInfo fieldInfo = GetFieldInfo(type2, property2, allowPrivateMembers: true);
			if (fieldInfo != null)
			{
				return (object instance) => fieldInfo.GetValue(instance);
			}
		}
		MethodInfo attachedPropertyGetter = GetAttachedPropertyGetter(type2, property2);
		if (attachedPropertyGetter != null)
		{
			if (!attachedPropertyGetter.IsStatic)
			{
				Func<object> emptyAttached = Funcs.CreateMemoized(delegate
				{
					_log.ErrorFormat("The attached property Getter for [{0}] must be static", property2);
					return DependencyProperty.UnsetValue;
				});
				return (object instance) => emptyAttached();
			}
			return (object instance) => attachedPropertyGetter.Invoke(null, new object[1] { instance });
		}
		object value;
		if (type2 == typeof(ExpandoObject))
		{
			return (object instance) => (instance is IDictionary<string, object> dictionary && dictionary.TryGetValue(property2, out value)) ? value : null;
		}
		object result;
		if (type2.Is(typeof(DynamicObject)))
		{
			return (object instance) => (instance is DynamicObject dynamicObject && dynamicObject.TryGetMember(new UnoGetMemberBinder(property2, ignoreCase: true), out result)) ? result : null;
		}
		if (type2.IsPrimitive && property2 == "Value")
		{
			return (object instance) => instance;
		}
		Func<object> empty = Funcs.CreateMemoized(delegate
		{
			_log.ErrorFormat("The [{0}] property getter does not exist on type [{1}]", property2, type2);
			return DependencyProperty.UnsetValue;
		});
		return (object instance) => empty();
	}

	private static ValueSetterHandler InternalGetValueSetter(Type type, string property, bool convert, DependencyPropertyValuePrecedences precedence)
	{
		Type type2 = type;
		string property2 = property;
		if (type2 == typeof(UnsetValue))
		{
			return new ValueSetterHandler(UnsetValueSetter);
		}
		property2 = SanitizePropertyName(type2, property2);
		Func<Func<Type?>?, object?, object?> convertSelector = (convert ? new Func<Func<Type>, object, object>(Convert) : ((Func<Func<Type>, object, object>)((Func<Type?>? p, object? v) => v)));
		if (IsIndexerFormat(property2))
		{
			string indexerName = property2.Substring(1, property2.Length - 2);
			Func<PropertyInfo> indexerInfo = Funcs.CreateMemoized(() => GetPropertyInfo(type2, "Item", allowPrivateMembers: false));
			Func<Type> indexerType = Funcs.CreateMemoized(() => indexerInfo()?.PropertyType);
			if (IsValidMetadataProviderType(type2) && BindableMetadataProvider != null)
			{
				IBindableType bindableTypeByType = BindableMetadataProvider!.GetBindableTypeByType(type2);
				if (bindableTypeByType != null)
				{
					StringIndexerSetterDelegate indexerMethod = bindableTypeByType.GetIndexerSetter();
					if (indexerMethod != null)
					{
						return delegate(object instance, object? value)
						{
							indexerMethod(instance, indexerName, convertSelector(indexerType, value));
						};
					}
					Action once5 = Actions.CreateOnce(delegate
					{
						_log.ErrorFormat("The Indexer property setter does not exist on type [{0}]", type2);
					});
					return delegate
					{
						once5();
					};
				}
			}
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.Debug($"GetValueSetter({type2}, {property2}) [Reflection]");
			}
			PropertyInfo propertyInfo = indexerInfo();
			if (propertyInfo != null)
			{
				MethodInfo setMethod = propertyInfo.GetSetMethod();
				if (setMethod != null)
				{
					Func<object, object?[], object?> handler2 = MethodInvokerBuilder(setMethod);
					return delegate(object instance, object? value)
					{
						handler2(instance, new object[2]
						{
							indexerName,
							convertSelector(indexerType, value)
						});
					};
				}
				Action once4 = Actions.CreateOnce(delegate
				{
					_log.ErrorFormat("The Indexer Setter does not exist on [{0}]", type2);
				});
				return delegate
				{
					once4();
				};
			}
			Action once3 = Actions.CreateOnce(delegate
			{
				_log.ErrorFormat("The Indexer property setter does not exist on type [{0}]", type2);
			});
			return delegate
			{
				once3();
			};
		}
		if (IsValidMetadataProviderType(type2) && BindableMetadataProvider != null)
		{
			BindablePropertyDescriptor bindableProperty = BindablePropertyDescriptor.GetPropertByBindableMetadataProvider(type2, property2);
			if (bindableProperty.OwnerType != null)
			{
				if (bindableProperty != null)
				{
					DependencyProperty dependencyProperty = bindableProperty.Property?.DependencyProperty;
					if (dependencyProperty != null)
					{
						return delegate(object instance, object? value)
						{
							instance.SetValue(dependencyProperty, convertSelector(() => bindableProperty.Property.PropertyType, value), precedence);
						};
					}
					if (bindableProperty.Property?.Setter != null)
					{
						PropertySetterHandler setter = bindableProperty.Property.Setter;
						return delegate(object instance, object? value)
						{
							setter(instance, convertSelector(() => bindableProperty.Property.PropertyType, value), precedence);
						};
					}
				}
				Action once2 = Actions.CreateOnce(delegate
				{
					_log.ErrorFormat("The property setter for [{0}] does not exist on [{1}]", property2, type2);
				});
				return delegate
				{
					once2();
				};
			}
		}
		if (_log.IsEnabled(LogLevel.Debug))
		{
			_log.Debug($"GetValueSetter({type2}, {property2}) [Reflection]");
		}
		DependencyProperty dp = FindDependencyProperty(type2, property2) ?? FindAttachedProperty(type2, property2);
		if (dp != null)
		{
			return delegate(object instance, object? value)
			{
				((DependencyObject)instance).SetValue(dp, convertSelector(() => dp.Type, value), precedence);
			};
		}
		PropertyInfo propertyInfo2 = GetPropertyInfo(type2, property2, allowPrivateMembers: false);
		if (propertyInfo2 != null)
		{
			MethodInfo setMethod2 = propertyInfo2.GetSetMethod();
			if (setMethod2 != null)
			{
				Func<Type> propertyType = Funcs.CreateMemoized(() => GetPropertyOrDependencyPropertyType(type2, property2));
				Func<object, object?[], object?> handler = MethodInvokerBuilder(setMethod2);
				return delegate(object instance, object? value)
				{
					handler(instance, new object[1] { convertSelector(propertyType, value) });
				};
			}
		}
		if (type2 == typeof(ExpandoObject))
		{
			return delegate(object instance, object? value)
			{
				if (instance is IDictionary<string, object> dictionary)
				{
					dictionary[property2] = value;
				}
			};
		}
		if (type2.Is(typeof(DynamicObject)))
		{
			return delegate(object instance, object? value)
			{
				if (instance is DynamicObject dynamicObject)
				{
					dynamicObject.TrySetMember(new UnoSetMemberBinder(property2, ignoreCase: true), value);
				}
			};
		}
		Action once = Actions.CreateOnce(delegate
		{
			_log.ErrorFormat("The property setter for [{0}] does not exist on [{1}]", property2, type2);
		});
		return delegate
		{
			once();
		};
	}

	private static ValueGetterHandler InternalGetPrecedenceSpecificValueGetter(Type type, string property, DependencyPropertyValuePrecedences precedence)
	{
		string property2 = property;
		Type type2 = type;
		if (type2 == typeof(UnsetValue))
		{
			return new ValueGetterHandler(UnsetValueGetter);
		}
		property2 = SanitizePropertyName(type2, property2);
		DependencyProperty dp = FindDependencyProperty(type2, property2);
		if (dp != null)
		{
			return (object instance) => ((DependencyObject)instance).GetPrecedenceSpecificValue(dp, precedence);
		}
		Func<object> empty = Funcs.CreateMemoized(delegate
		{
			_log.ErrorFormat("The [{0}] precedence specific property getter does not exist on type [{1}]", property2, type2);
			return DependencyProperty.UnsetValue;
		});
		return (object instance) => empty();
	}

	private static ValueGetterHandler InternalGetSubstituteValueGetter(Type type, string property, DependencyPropertyValuePrecedences precedence)
	{
		string property2 = property;
		Type type2 = type;
		if (type2 == typeof(UnsetValue))
		{
			return new ValueGetterHandler(UnsetValueGetter);
		}
		property2 = SanitizePropertyName(type2, property2);
		DependencyProperty dp = FindDependencyProperty(type2, property2);
		if (dp != null)
		{
			return (object instance) => ((DependencyObject)instance).GetValueUnderPrecedence(dp, precedence);
		}
		Func<object> empty = Funcs.CreateMemoized(delegate
		{
			_log.ErrorFormat("The [{0}] substitute property getter does not exist on type [{1}]", property2, type2);
			return DependencyProperty.UnsetValue;
		});
		return (object instance) => empty();
	}

	private static ValueUnsetterHandler InternalGetValueUnsetter(Type type, string property, DependencyPropertyValuePrecedences precedence)
	{
		string property2 = property;
		Type type2 = type;
		if (type2 == typeof(UnsetValue))
		{
			return delegate
			{
			};
		}
		property2 = SanitizePropertyName(type2, property2);
		DependencyProperty dp = FindDependencyProperty(type2, property2) ?? FindAttachedProperty(type2, property2);
		if (dp != null)
		{
			return delegate(object instance)
			{
				((DependencyObject)instance).ClearValue(dp, precedence);
			};
		}
		Action once = Actions.CreateOnce(delegate
		{
			_log.ErrorFormat("The property unsetter for [{0}] does not exist on [{1}]", property2, type2);
		});
		return delegate
		{
			once();
		};
	}

	private static DependencyProperty FindDependencyProperty(Type ownerType, string property)
	{
		return DependencyProperty.GetProperty(ownerType, property);
	}

	private static DependencyProperty? FindAttachedProperty(Type type, string property)
	{
		DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.Parse(property);
		if (dependencyPropertyDescriptor != null)
		{
			type = dependencyPropertyDescriptor.OwnerType;
			property = dependencyPropertyDescriptor.Name;
		}
		return type?.GetField(property + "Property")?.GetValue(null) as DependencyProperty;
	}

	private static Type? GetPropertyOrDependencyPropertyType(Type type, string property)
	{
		PropertyInfo propertyInfo = GetPropertyInfo(type, property, allowPrivateMembers: false);
		if (propertyInfo != null)
		{
			return propertyInfo.PropertyType;
		}
		MethodInfo attachedPropertyGetter = GetAttachedPropertyGetter(type, property);
		if (attachedPropertyGetter != null)
		{
			return attachedPropertyGetter.ReturnType;
		}
		return null;
	}

	private static MethodInfo? GetAttachedPropertyGetter(Type type, string property)
	{
		string property2 = property;
		DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.Parse(property2);
		if (dependencyPropertyDescriptor != null)
		{
			type = dependencyPropertyDescriptor.OwnerType;
			property2 = dependencyPropertyDescriptor.Name;
		}
		return (from m in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
			where m.Name == "Get" + property2 && m.GetParameters().Length == 1
			select m).FirstOrDefault();
	}

	internal static object? Convert(Func<Type?>? propertyType, object? value)
	{
		if (value != null && propertyType != null)
		{
			Type type = propertyType!();
			if (!value!.GetType().Is(type))
			{
				if (FastConvert(type, value, out var output))
				{
					return output;
				}
				if (type != typeof(object))
				{
					value = ConvertWithConvertionExtension(value, type);
				}
			}
		}
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static object ConvertWithConvertionExtension(object? value, Type? t)
	{
		try
		{
			value = Conversion.To(value, t, CultureInfo.CurrentCulture);
			return value;
		}
		catch (Exception)
		{
			value = Conversion.To(value, t, CultureInfo.InvariantCulture);
			return value;
		}
	}

	private static object UnsetValueGetter(object unused)
	{
		return DependencyProperty.UnsetValue;
	}

	private static void UnsetValueSetter(object unused, object? unused2)
	{
	}

	private static bool IsValidMetadataProviderType(Type type)
	{
		if (type.IsPublic)
		{
			return type.IsClass;
		}
		return false;
	}

	private static bool FastConvert(Type outputType, object input, out object output)
	{
		output = null;
		if (input is string input2 && FastStringConvert(outputType, input2, ref output))
		{
			return true;
		}
		if (FastNumberConvert(outputType, input, ref output))
		{
			return true;
		}
		if (!(input is Enum))
		{
			if (!(input is bool boolInput))
			{
				if (!(input is Windows.UI.Color color))
				{
					if (!(input is SolidColorBrush solidColorBrush))
					{
						if (!(input is ColorOffset input3))
						{
							if (input is Thickness thickness)
							{
								return FastThicknessConvert(outputType, thickness, ref output);
							}
							return false;
						}
						return FastColorOffsetConvert(outputType, input3, ref output);
					}
					return FastSolidColorBrushConvert(outputType, solidColorBrush, ref output);
				}
				return FastColorConvert(outputType, color, ref output);
			}
			return FastBooleanConvert(outputType, boolInput, ref output);
		}
		return FastEnumConvert(outputType, input, ref output);
	}

	private static bool FastBooleanConvert(Type outputType, bool boolInput, ref object output)
	{
		if (outputType == typeof(Visibility))
		{
			output = ((!boolInput) ? Visibility.Collapsed : Visibility.Visible);
			return true;
		}
		return false;
	}

	private static bool FastEnumConvert(Type outputType, object input, ref object output)
	{
		if (outputType == typeof(string))
		{
			output = input.ToString();
			return true;
		}
		return false;
	}

	private static bool FastColorOffsetConvert(Type outputType, ColorOffset input, ref object output)
	{
		if (outputType == typeof(Windows.UI.Color))
		{
			output = (Windows.UI.Color)input;
			return true;
		}
		return false;
	}

	private static bool FastColorConvert(Type outputType, Windows.UI.Color color, ref object output)
	{
		if (outputType == typeof(SolidColorBrush))
		{
			output = new SolidColorBrush(color);
			return true;
		}
		return false;
	}

	private static bool FastSolidColorBrushConvert(Type outputType, SolidColorBrush solidColorBrush, ref object output)
	{
		if (outputType == typeof(Windows.UI.Color) || outputType == typeof(Windows.UI.Color?))
		{
			output = solidColorBrush.Color;
			return true;
		}
		return false;
	}

	private static bool FastThicknessConvert(Type outputType, Thickness thickness, ref object output)
	{
		if (outputType == typeof(double) && thickness.IsUniform())
		{
			output = thickness.Left;
			return true;
		}
		return false;
	}

	private static bool FastNumberConvert(Type outputType, object input, ref object output)
	{
		if (input is double num)
		{
			if (outputType == typeof(float))
			{
				output = (float)num;
				return true;
			}
			if (outputType == typeof(TimeSpan))
			{
				output = TimeSpan.FromSeconds(num);
				return true;
			}
			if (outputType == typeof(GridLength))
			{
				output = GridLengthHelper.FromPixels(num);
				return true;
			}
		}
		if (input is int num2)
		{
			if (outputType == typeof(float))
			{
				output = (float)num2;
				return true;
			}
			if (outputType == typeof(TimeSpan))
			{
				output = TimeSpan.FromSeconds(num2);
				return true;
			}
			if (outputType == typeof(GridLength))
			{
				output = GridLengthHelper.FromPixels(num2);
				return true;
			}
		}
		return false;
	}

	private static bool FastStringConvert(Type outputType, string input, ref object output)
	{
		if (FastStringToVisibilityConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToHorizontalAlignmentConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToVerticalAlignmentConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToBrushConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToDoubleConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToSingleConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToThicknessConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToGridLengthConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToOrientationConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToColorConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToTextAlignmentConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToImageSource(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToFontWeightConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToFontFamilyConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToIntegerConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToPointF(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToPoint(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToMatrix(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToDuration(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToRepeatBehavior(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToKeyTime(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToKeySpline(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToPointCollection(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToPath(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToInputScope(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToToolTip(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToIconElement(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToUriConvert(outputType, input, ref output))
		{
			return true;
		}
		if (FastStringToTypeConvert(outputType, input, ref output))
		{
			return true;
		}
		if (outputType.IsEnum)
		{
			output = Enum.Parse(outputType, input, ignoreCase: true);
			return true;
		}
		return false;
	}

	private static bool FastStringToIconElement(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(IconElement))
		{
			output = (IconElement)input;
			return true;
		}
		return false;
	}

	private static bool FastStringToInputScope(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(InputScope))
		{
			object output2 = null;
			if (FastEnumConvert(typeof(InputScopeNameValue), input, ref output2))
			{
				output = new InputScope
				{
					Names = 
					{
						new InputScopeName
						{
							NameValue = (InputScopeNameValue)output2
						}
					}
				};
				return true;
			}
		}
		return false;
	}

	private static bool FastStringToToolTip(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(ToolTip))
		{
			output = new ToolTip
			{
				Content = input
			};
			return true;
		}
		return false;
	}

	private static bool FastStringToKeyTime(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(KeyTime))
		{
			output = KeyTime.FromTimeSpan(TimeSpan.Parse(input, CultureInfo.InvariantCulture));
			return true;
		}
		return false;
	}

	private static bool FastStringToKeySpline(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(KeySpline))
		{
			output = KeySpline.FromString(input);
			return true;
		}
		return false;
	}

	private static bool FastStringToDuration(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Duration))
		{
			if (input == "Forever")
			{
				output = Duration.Forever;
			}
			else if (input == "Automatic")
			{
				output = Duration.Automatic;
			}
			else
			{
				output = new Duration(TimeSpan.Parse(input, CultureInfo.InvariantCulture));
			}
			return true;
		}
		return false;
	}

	private static bool FastStringToRepeatBehavior(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(RepeatBehavior) && input == "Forever")
		{
			output = RepeatBehavior.Forever;
			return true;
		}
		return false;
	}

	private static bool FastStringToPointCollection(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(PointCollection))
		{
			output = (PointCollection)input;
			return true;
		}
		return false;
	}

	private static bool FastStringToPath(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Geometry))
		{
			output = (Geometry)input;
			return true;
		}
		return false;
	}

	private static bool FastStringToFontFamilyConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(FontFamily))
		{
			output = new FontFamily(input);
			return true;
		}
		return false;
	}

	private static bool FastStringToMatrix(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Matrix))
		{
			List<double> doubleValues = GetDoubleValues(input);
			output = new Matrix(doubleValues[0], doubleValues[1], doubleValues[2], doubleValues[3], doubleValues[4], doubleValues[5]);
			return true;
		}
		return false;
	}

	private static bool FastStringToPointF(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(PointF))
		{
			List<float> floatValues = GetFloatValues(input);
			if (floatValues.Count == 2)
			{
				output = new PointF(floatValues[0], floatValues[1]);
				return true;
			}
			if (floatValues.Count == 1)
			{
				output = new PointF(floatValues[0], floatValues[0]);
				return true;
			}
		}
		return false;
	}

	private static bool FastStringToPoint(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Windows.Foundation.Point))
		{
			List<double> doubleValues = GetDoubleValues(input);
			if (doubleValues.Count == 2)
			{
				output = new Windows.Foundation.Point(doubleValues[0], doubleValues[1]);
				return true;
			}
			if (doubleValues.Count == 1)
			{
				output = new Windows.Foundation.Point(doubleValues[0], doubleValues[0]);
				return true;
			}
		}
		return false;
	}

	private static bool FastStringToBrushConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Brush))
		{
			output = SolidColorBrushHelper.Parse(input);
			return true;
		}
		return false;
	}

	private static bool FastStringToColorConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Windows.UI.Color))
		{
			output = Colors.Parse(input);
			return true;
		}
		return false;
	}

	private static bool FastStringToImageSource(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(ImageSource))
		{
			output = (ImageSource)input;
			return true;
		}
		return false;
	}

	private static bool FastStringToTextAlignmentConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(TextAlignment))
		{
			switch (input.ToLowerInvariant())
			{
			case "center":
				output = TextAlignment.Center;
				return true;
			case "left":
				output = TextAlignment.Left;
				return true;
			case "start":
				output = TextAlignment.Left;
				return true;
			case "right":
				output = TextAlignment.Right;
				return true;
			case "end":
				output = TextAlignment.Right;
				return true;
			case "justify":
				output = TextAlignment.Justify;
				return true;
			case "detectfromcontent":
				output = TextAlignment.DetectFromContent;
				return true;
			default:
				throw new InvalidOperationException("The value " + input + " is not a valid TextAlignment");
			}
		}
		return false;
	}

	private static bool FastStringToGridLengthConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(GridLength))
		{
			GridLength[] array = GridLength.ParseGridLength(input);
			if (array.Length != 0)
			{
				output = array[0];
				return true;
			}
		}
		return false;
	}

	private static bool FastStringToDoubleConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(double))
		{
			if (input == "")
			{
				output = double.NaN;
				return true;
			}
			if (input.Length == 1)
			{
				char c = input[0];
				if (c >= '0' && c <= '9')
				{
					output = (double)(c - 48);
					return true;
				}
			}
			string text = input.Trim();
			if (text == "0" || text == "")
			{
				output = 0.0;
				return true;
			}
			text = text.ToLowerInvariant();
			switch (text)
			{
			case "nan":
			case "auto":
				output = double.NaN;
				return true;
			case "-infinity":
				output = double.NegativeInfinity;
				return true;
			case "infinity":
				output = double.PositiveInfinity;
				return true;
			}
			if (double.TryParse(text, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out var result))
			{
				output = result;
				return true;
			}
		}
		return false;
	}

	private static bool FastStringToSingleConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(float))
		{
			if (input == "")
			{
				output = float.NaN;
				return true;
			}
			if (input.Length == 1)
			{
				char c = input[0];
				if (c >= '0' && c <= '9')
				{
					output = (float)(c - 48);
					return true;
				}
			}
			string text = input.Trim();
			if (text == "0" || text == "")
			{
				output = 0f;
				return true;
			}
			text = text.ToLowerInvariant();
			switch (text)
			{
			case "nan":
				output = float.NaN;
				return true;
			case "-infinity":
				output = float.NegativeInfinity;
				return true;
			case "infinity":
				output = float.PositiveInfinity;
				return true;
			}
			if (float.TryParse(text, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out var result))
			{
				output = result;
				return true;
			}
		}
		return false;
	}

	private static bool FastStringToIntegerConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(int))
		{
			if (input.Length == 1)
			{
				char c = input[0];
				if (c >= '0' && c <= '9')
				{
					output = c - 48;
					return true;
				}
			}
			string text = input.Trim();
			if (text == "0" || text == "")
			{
				output = 0;
				return true;
			}
			if (int.TryParse(text, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out var result))
			{
				output = result;
				return true;
			}
		}
		return false;
	}

	private static bool FastStringToOrientationConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Orientation))
		{
			string text = input.ToLowerInvariant();
			if (!(text == "vertical"))
			{
				if (text == "horizontal")
				{
					output = Orientation.Horizontal;
					return true;
				}
				throw new InvalidOperationException("The value " + input + " is not a valid Orientation");
			}
			output = Orientation.Vertical;
			return true;
		}
		return false;
	}

	private static bool FastStringToThicknessConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Thickness))
		{
			output = new ThicknessConverter().ConvertFrom(input);
			return true;
		}
		return false;
	}

	private static bool FastStringToVerticalAlignmentConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(VerticalAlignment))
		{
			switch (input.ToLowerInvariant())
			{
			case "center":
				output = VerticalAlignment.Center;
				return true;
			case "top":
				output = VerticalAlignment.Top;
				return true;
			case "bottom":
				output = VerticalAlignment.Bottom;
				return true;
			case "stretch":
				output = VerticalAlignment.Stretch;
				return true;
			default:
				throw new InvalidOperationException("The value " + input + " is not a valid VerticalAlignment");
			}
		}
		return false;
	}

	private static bool FastStringToHorizontalAlignmentConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(HorizontalAlignment))
		{
			switch (input.ToLowerInvariant())
			{
			case "center":
				output = HorizontalAlignment.Center;
				return true;
			case "left":
				output = HorizontalAlignment.Left;
				return true;
			case "right":
				output = HorizontalAlignment.Right;
				return true;
			case "stretch":
				output = HorizontalAlignment.Stretch;
				return true;
			default:
				throw new InvalidOperationException("The value " + input + " is not a valid HorizontalAlignment");
			}
		}
		return false;
	}

	private static bool FastStringToVisibilityConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Visibility))
		{
			string text = input.ToLowerInvariant();
			if (!(text == "visible"))
			{
				if (text == "collapsed")
				{
					output = Visibility.Collapsed;
					return true;
				}
				throw new InvalidOperationException("The value " + input + " is not a valid Visibility");
			}
			output = Visibility.Visible;
			return true;
		}
		return false;
	}

	private static bool FastStringToFontWeightConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(FontWeight))
		{
			switch (input.ToLowerInvariant())
			{
			case "thin":
				output = FontWeights.Thin;
				return true;
			case "extralight":
				output = FontWeights.ExtraLight;
				return true;
			case "ultralight":
				output = FontWeights.UltraLight;
				return true;
			case "semilight":
				output = FontWeights.SemiLight;
				return true;
			case "light":
				output = FontWeights.Light;
				return true;
			case "normal":
				output = FontWeights.Normal;
				return true;
			case "regular":
				output = FontWeights.Regular;
				return true;
			case "medium":
				output = FontWeights.Medium;
				return true;
			case "semibold":
				output = FontWeights.SemiBold;
				return true;
			case "demibold":
				output = FontWeights.DemiBold;
				return true;
			case "bold":
				output = FontWeights.Bold;
				return true;
			case "ultrabold":
				output = FontWeights.UltraBold;
				return true;
			case "extrabold":
				output = FontWeights.ExtraBold;
				return true;
			case "black":
				output = FontWeights.Black;
				return true;
			case "heavy":
				output = FontWeights.Heavy;
				return true;
			case "extrablack":
				output = FontWeights.ExtraBlack;
				return true;
			case "ultrablack":
				output = FontWeights.UltraBlack;
				return true;
			default:
				throw new InvalidOperationException("The value " + input + " is not a valid FontWeight");
			}
		}
		return false;
	}

	private static bool FastStringToUriConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Uri))
		{
			output = new Uri(input);
			return true;
		}
		return false;
	}

	private static bool FastStringToTypeConvert(Type outputType, string input, ref object output)
	{
		if (outputType == typeof(Type))
		{
			output = Type.GetType(input, throwOnError: true);
			return true;
		}
		return false;
	}

	private static List<double> GetDoubleValues(string input)
	{
		List<double> list = new List<double>();
		ReadOnlySpan<char> s = input.AsSpan().Trim();
		while (!s.IsEmpty)
		{
			int num = NextDoubleLength(s);
			list.Add(double.Parse(s.Slice(0, num).ToString(), NumberStyles.Float));
			s = s.Slice(num);
			s = EatSeparator(s);
		}
		return list;
	}

	private static List<float> GetFloatValues(string input)
	{
		List<float> list = new List<float>();
		ReadOnlySpan<char> s = input.AsSpan().Trim();
		while (!s.IsEmpty)
		{
			int num = NextDoubleLength(s);
			list.Add(float.Parse(s.Slice(0, num).ToString(), NumberStyles.Float));
			s = s.Slice(num);
			s = EatSeparator(s);
		}
		return list;
	}

	private static ReadOnlySpan<char> EatSeparator(ReadOnlySpan<char> s)
	{
		if (s.IsEmpty)
		{
			return s;
		}
		bool flag = false;
		bool flag2 = false;
		int i;
		for (i = 0; i < s.Length; i++)
		{
			if (char.IsWhiteSpace(s[i]))
			{
				flag = true;
				continue;
			}
			if (s[i] != ',')
			{
				break;
			}
			if (flag2)
			{
				throw new ArgumentException("Comma shouldn't appear twice between two double values.");
			}
			flag2 = true;
		}
		return s.Slice(i);
	}

	private static int NextDoubleLength(ReadOnlySpan<char> s)
	{
		int i;
		for (i = 0; i < s.Length && !char.IsWhiteSpace(s[i]) && s[i] != ','; i++)
		{
		}
		return i;
	}
}

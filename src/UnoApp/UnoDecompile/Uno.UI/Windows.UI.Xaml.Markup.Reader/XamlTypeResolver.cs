using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Uno;
using Uno.Extensions;
using Uno.Xaml;
using Windows.Foundation;

namespace Windows.UI.Xaml.Markup.Reader;

internal class XamlTypeResolver
{
	private static readonly Assembly[] _lookupAssemblies = new Assembly[3]
	{
		typeof(FrameworkElement).Assembly,
		typeof(Color).Assembly,
		typeof(Size).Assembly
	};

	private readonly Func<string?, Type?> _findType;

	private readonly Func<Type, string, bool> _isAttachedProperty;

	private readonly XamlFileDefinition FileDefinition;

	private readonly Func<string, string, Type?> _findPropertyTypeByName;

	private readonly Func<XamlMember, Type?> _findPropertyTypeByXamlMember;

	private readonly Func<Type?, PropertyInfo?> _findContentProperty;

	public static ImmutableDictionary<string, string[]> KnownNamespaces { get; } = new Dictionary<string, string[]>
	{
		{
			"http://schemas.microsoft.com/winfx/2006/xaml/presentation",
			XamlConstants.Namespaces.PresentationNamespaces
		},
		{
			"http://schemas.microsoft.com/winfx/2006/xaml",
			new string[1] { "System" }
		}
	}.ToImmutableDictionary();


	public XamlTypeResolver(XamlFileDefinition definition)
	{
		FileDefinition = definition;
		_findType = new Func<string, Type>(SourceFindType);
		_findType = _findType.AsMemoized();
		_isAttachedProperty = Funcs.Create<Type, string, bool>(SourceIsAttachedProperty).AsLockedMemoized();
		_findPropertyTypeByXamlMember = Funcs.Create<XamlMember, Type>(SourceFindPropertyType).AsLockedMemoized();
		_findPropertyTypeByName = Funcs.Create<string, string, Type>(SourceFindPropertyType).AsLockedMemoized();
		_findContentProperty = Funcs.Create<Type, PropertyInfo>(SourceFindContentProperty).AsLockedMemoized();
	}

	public bool IsAttachedProperty(XamlMemberDefinition member)
	{
		if (member.Member.DeclaringType != null)
		{
			Type type = FindType(member.Member.DeclaringType);
			if (type != null)
			{
				return _isAttachedProperty(type, member.Member.Name);
			}
		}
		return false;
	}

	public bool IsType(XamlType xamlType, XamlType baseType)
	{
		if (xamlType == baseType)
		{
			return true;
		}
		if (baseType == null || xamlType == null)
		{
			return false;
		}
		Type type = _findType(baseType.Name);
		if (type != null)
		{
			return IsType(xamlType, type.FullName);
		}
		return false;
	}

	public bool IsInitializedCollection(PropertyInfo property)
	{
		if (property != null && IsInitializableProperty(property))
		{
			return IsCollectionOrListType(property.PropertyType);
		}
		return false;
	}

	public PropertyInfo? GetPropertyByName(XamlType declaringType, string propertyName, BindingFlags? flags = null)
	{
		return GetPropertyByName(FindType(declaringType), propertyName, flags);
	}

	public FieldInfo? GetFieldByName(XamlType declaringType, string propertyName, BindingFlags? flags = null)
	{
		return GetFieldByName(FindType(declaringType), propertyName, flags);
	}

	public PropertyInfo? FindContentProperty(Type? elementType)
	{
		return _findContentProperty(elementType);
	}

	public PropertyInfo? GetPropertyByName(Type? type, string propertyName, BindingFlags? flags = null)
	{
		string propertyName2 = propertyName;
		return ((!flags.HasValue) ? type?.GetProperties() : type?.GetProperties(flags.Value))?.FirstOrDefault((PropertyInfo p) => p.Name == propertyName2);
	}

	public FieldInfo? GetFieldByName(Type? type, string propertyName, BindingFlags? flags = null)
	{
		string propertyName2 = propertyName;
		return ((!flags.HasValue) ? type?.GetFields() : type?.GetFields(flags.Value))?.FirstOrDefault((FieldInfo p) => p.Name == propertyName2);
	}

	public EventInfo? GetEventByName(XamlType declaringType, string eventName)
	{
		return GetEventByName(FindType(declaringType), eventName);
	}

	private static EventInfo? GetEventByName(Type? type, string eventName)
	{
		string eventName2 = eventName;
		return type?.GetEvents().FirstOrDefault((EventInfo p) => p.Name == eventName2);
	}

	private PropertyInfo? SourceFindContentProperty(Type? elementType)
	{
		if (elementType == null)
		{
			return null;
		}
		ContentPropertyAttribute contentPropertyAttribute = elementType.GetCustomAttributes<ContentPropertyAttribute>().FirstOrDefault();
		if (contentPropertyAttribute != null)
		{
			return GetPropertyByName(elementType, contentPropertyAttribute.Name);
		}
		if (elementType!.BaseType != typeof(object))
		{
			return FindContentProperty(elementType!.BaseType);
		}
		return null;
	}

	public bool IsNewableProperty(PropertyInfo property, out Type? newableType)
	{
		Type propertyType = property.PropertyType;
		MethodInfo? setMethod = property.SetMethod;
		bool flag = (object)setMethod != null && setMethod!.IsPublic && propertyType.SelectOrDefault((Type nts) => nts.GetConstructors().Any((ConstructorInfo ms) => ms.GetParameters().Length == 0), defaultValue: false);
		newableType = (flag ? propertyType : null);
		return flag;
	}

	public DependencyProperty? FindDependencyProperty(XamlMemberDefinition member)
	{
		Type type = FindType(member.Member.DeclaringType);
		if (type != null)
		{
			string name = member.Member.Name;
			return FindDependencyProperty(type, name);
		}
		return null;
	}

	public DependencyProperty? FindDependencyProperty(Type propertyOwner, string? propertyName)
	{
		string propertyName2 = propertyName;
		PropertyInfo propertyInfo = (from p in GetAllProperties(propertyOwner)
			where p.Name == propertyName2 + "Property"
			select p).FirstOrDefault();
		FieldInfo fieldInfo = (from p in GetAllFields(propertyOwner)
			where p.Name == propertyName2 + "Property"
			select p).FirstOrDefault();
		return (propertyInfo?.GetValue(null) ?? fieldInfo?.GetValue(null)) as DependencyProperty;
	}

	private static IEnumerable<PropertyInfo> GetAllProperties(Type type)
	{
		Type currentType = type;
		while (currentType != null && currentType != typeof(object))
		{
			PropertyInfo[] properties = currentType.GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				yield return properties[i];
			}
			currentType = currentType.BaseType;
		}
	}

	private static IEnumerable<FieldInfo> GetAllFields(Type type)
	{
		Type currentType = type;
		while (currentType != null && currentType != typeof(object))
		{
			FieldInfo[] fields = currentType.GetFields();
			for (int i = 0; i < fields.Length; i++)
			{
				yield return fields[i];
			}
			currentType = currentType.BaseType;
		}
	}

	private bool IsInitializableProperty(PropertyInfo property)
	{
		return !(property.SetMethod?.IsPublic ?? false);
	}

	public bool IsCollectionOrListType(Type type)
	{
		if (!IsImplementingInterface(type, typeof(ICollection)) && !IsImplementingInterface(type, typeof(ICollection<>)) && !IsImplementingInterface(type, typeof(IList)))
		{
			return IsImplementingInterface(type, typeof(IList<>));
		}
		return true;
	}

	private bool IsImplementingInterface(Type type, Type iface)
	{
		Type iface2 = iface;
		return type.Flatten((Type t) => t.BaseType).Any((Type t) => t.GetInterfaces().Any((Type i) => i == iface2 || (i.IsGenericType && i.GetGenericTypeDefinition() == iface2)));
	}

	public bool IsType(XamlType xamlType, string? typeName)
	{
		Type type = FindType(xamlType);
		if (type != null)
		{
			do
			{
				if (type.FullName == typeName)
				{
					return true;
				}
				type = type.BaseType;
			}
			while (!(type == null) && type.Name != "Object");
		}
		return false;
	}

	public Type? FindType(string? name)
	{
		if (name.IsNullOrWhiteSpace())
		{
			return null;
		}
		return _findType(name);
	}

	public Type? FindType(XamlType? type)
	{
		XamlType type2 = type;
		if (type2 != null)
		{
			NamespaceDeclaration namespaceDeclaration = FileDefinition.Namespaces.FirstOrDefault((NamespaceDeclaration n) => n.Namespace == type2.PreferredXamlNamespace);
			bool valueOrDefault = (namespaceDeclaration?.Prefix?.HasValue()).GetValueOrDefault();
			if (type2.PreferredXamlNamespace == "http://schemas.microsoft.com/winfx/2006/xaml")
			{
				if (type2.Name == "Bind")
				{
					return _findType("Windows.UI.Xaml.Data.Binding");
				}
				Type type3 = _findType("System." + type2.Name);
				if ((object)type3 != null)
				{
					return type3;
				}
			}
			string arg = (valueOrDefault ? (namespaceDeclaration?.Prefix + ":" + type2.Name) : type2.Name);
			return _findType(arg);
		}
		return null;
	}

	private Type? SourceFindType(string? name)
	{
		string name2 = name;
		if (name2 == null)
		{
			return null;
		}
		string originalName = name2;
		if (name2.Contains(":"))
		{
			string[] fields = name2.Split(new char[1] { ':' });
			NamespaceDeclaration namespaceDeclaration = FileDefinition.Namespaces.FirstOrDefault((NamespaceDeclaration n) => n.Prefix == fields[0]);
			if (namespaceDeclaration != null)
			{
				string text = namespaceDeclaration.Namespace.TrimStart("using:");
				if (text.StartsWith("clr-namespace:"))
				{
					text = text.Split(new char[1] { ';' })[0].TrimStart("clr-namespace:");
				}
				name2 = text + "." + fields[1];
			}
		}
		else
		{
			string key = FileDefinition.Namespaces.Where((NamespaceDeclaration n) => n.Prefix.None()).FirstOrDefault()?.Namespace ?? "";
			string[] array = KnownNamespaces.UnoGetValueOrDefault(key, Array.Empty<string>());
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				Assembly[] lookupAssemblies = _lookupAssemblies;
				foreach (Assembly assembly in lookupAssemblies)
				{
					Type type = assembly.GetType(text2 + "." + name2);
					if (type != null)
					{
						return type;
					}
				}
			}
		}
		Func<Type>[] source = new Func<Type>[4]
		{
			() => Type.GetType(name2),
			() => Type.GetType(originalName),
			() => Type.GetType(originalName.Split(new char[1] { ':' }).ElementAtOrDefault(1) ?? ""),
			() => (from a in AppDomain.CurrentDomain.GetAssemblies()
				select a.GetType(name2)).Trim().FirstOrDefault()
		};
		return source.Select((Func<Type> m) => m()).Trim().FirstOrDefault();
	}

	private static bool SourceIsAttachedProperty(Type type, string name)
	{
		string name2 = name;
		Type type2 = type;
		do
		{
			if (type2 == null)
			{
				return false;
			}
			PropertyInfo propertyInfo = type2.GetProperties().FirstOrDefault((PropertyInfo p) => p.Name == name2);
			MethodInfo methodInfo = type2.GetMethods().FirstOrDefault((MethodInfo p) => p.Name == "Set" + name2);
			if ((propertyInfo?.GetMethod?.IsStatic).GetValueOrDefault())
			{
				return true;
			}
			if (methodInfo != null && methodInfo.IsStatic)
			{
				return true;
			}
			type2 = type2.BaseType;
		}
		while (!(type == null) && !(type.Name == "Object"));
		return false;
	}

	public Type? FindPropertyType(XamlMember xamlMember)
	{
		return _findPropertyTypeByXamlMember(xamlMember);
	}

	private Type? SourceFindPropertyType(XamlMember xamlMember)
	{
		if (xamlMember.DeclaringType != null)
		{
			string[] array = KnownNamespaces.UnoGetValueOrDefault(xamlMember.DeclaringType.PreferredXamlNamespace, Array.Empty<string>());
			string[] array2 = array;
			foreach (string text in array2)
			{
				string name = xamlMember.DeclaringType.Name;
				Type type = FindPropertyType(text + "." + name, xamlMember.Name);
				if (type != null)
				{
					return type;
				}
			}
		}
		return FindPropertyType(FindType(xamlMember.DeclaringType)?.FullName ?? "$$unknown", xamlMember.Name);
	}

	public Type? FindPropertyType(string ownerType, string propertyName)
	{
		return _findPropertyTypeByName(ownerType, propertyName);
	}

	private Type? SourceFindPropertyType(string ownerType, string propertyName)
	{
		string propertyName2 = propertyName;
		Type type = FindType(ownerType);
		if (type != null)
		{
			do
			{
				Type type2 = type;
				PropertyInfo propertyInfo = type2.GetProperties().FirstOrDefault((PropertyInfo p) => p.Name == propertyName2);
				MethodInfo methodInfo = type2.GetMethods().FirstOrDefault((MethodInfo p) => p.Name == "Set" + propertyName2);
				if (propertyInfo != null)
				{
					return propertyInfo.PropertyType;
				}
				if (methodInfo != null)
				{
					return methodInfo.GetParameters().ElementAt(1).ParameterType;
				}
				Type baseType = type.BaseType;
				if (baseType == null)
				{
					baseType = type.BaseType;
				}
				type = baseType;
			}
			while (!(type == null) && !(type == typeof(object)));
			return null;
		}
		return null;
	}
}

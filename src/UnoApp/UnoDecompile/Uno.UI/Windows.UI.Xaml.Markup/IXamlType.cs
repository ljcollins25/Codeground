using System;
using Uno;

namespace Windows.UI.Xaml.Markup;

[NotImplemented]
public interface IXamlType
{
	IXamlType BaseType { get; }

	IXamlMember ContentProperty { get; }

	string FullName { get; }

	bool IsArray { get; }

	bool IsBindable { get; }

	bool IsCollection { get; }

	bool IsConstructible { get; }

	bool IsDictionary { get; }

	bool IsMarkupExtension { get; }

	IXamlType ItemType { get; }

	IXamlType KeyType { get; }

	Type UnderlyingType { get; }

	object ActivateInstance();

	object CreateFromString(string value);

	IXamlMember GetMember(string name);

	void AddToVector(object instance, object value);

	void AddToMap(object instance, object key, object value);

	void RunInitializer();
}

using Uno;

namespace Windows.UI.Xaml.Markup;

[NotImplemented]
public interface IXamlMember
{
	bool IsAttachable { get; }

	bool IsDependencyProperty { get; }

	bool IsReadOnly { get; }

	string Name { get; }

	IXamlType TargetType { get; }

	IXamlType Type { get; }

	object GetValue(object instance);

	void SetValue(object instance, object value);
}

using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IValueProvider
{
	bool IsReadOnly { get; }

	string Value { get; }

	void SetValue(string value);
}

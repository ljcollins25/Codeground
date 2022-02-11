using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IRangeValueProvider
{
	bool IsReadOnly { get; }

	double LargeChange { get; }

	double Maximum { get; }

	double Minimum { get; }

	double SmallChange { get; }

	double Value { get; }

	void SetValue(double value);
}

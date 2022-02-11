namespace Microsoft.UI.Xaml.Controls;

public class NumberBoxValueChangedEventArgs
{
	public double OldValue { get; }

	public double NewValue { get; }

	internal NumberBoxValueChangedEventArgs(double oldValue, double newValue)
	{
		OldValue = oldValue;
		NewValue = newValue;
	}
}

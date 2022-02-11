namespace Windows.UI.Xaml.Controls.Primitives;

public sealed class RangeBaseValueChangedEventArgs : RoutedEventArgs
{
	public double NewValue { get; internal set; }

	public double OldValue { get; internal set; }

	internal RangeBaseValueChangedEventArgs(object originalSource)
		: base(originalSource)
	{
	}
}

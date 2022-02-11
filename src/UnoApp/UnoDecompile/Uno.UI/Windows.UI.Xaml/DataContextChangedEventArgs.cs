namespace Windows.UI.Xaml;

public class DataContextChangedEventArgs
{
	public bool Handled { get; set; }

	public object NewValue { get; }

	public DataContextChangedEventArgs(object newValue)
	{
		NewValue = newValue;
	}
}

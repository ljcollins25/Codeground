namespace Windows.UI.Xaml.Controls;

public sealed class TextBoxTextChangingEventArgs
{
	public bool IsContentChanging { get; }

	internal TextBoxTextChangingEventArgs()
	{
		IsContentChanging = true;
	}
}

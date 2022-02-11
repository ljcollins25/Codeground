namespace Windows.UI.Xaml.Controls;

public sealed class TextBoxBeforeTextChangingEventArgs
{
	public bool Cancel { get; set; }

	public string NewText { get; }

	internal TextBoxBeforeTextChangingEventArgs(string newText)
	{
		NewText = newText;
	}
}

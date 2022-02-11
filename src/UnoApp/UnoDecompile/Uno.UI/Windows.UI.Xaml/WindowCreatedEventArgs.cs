namespace Windows.UI.Xaml;

public sealed class WindowCreatedEventArgs
{
	public Window Window { get; }

	internal WindowCreatedEventArgs(Window window)
	{
		Window = window;
	}
}

using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml;

public class VisualStateChangedEventArgs
{
	public Control Control { get; set; }

	public VisualState NewState { get; set; }

	public VisualState OldState { get; set; }
}

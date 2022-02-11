using Windows.Foundation;

namespace Windows.UI.ViewManagement;

public class InputPaneVisibilityEventArgs
{
	public bool EnsuredFocusedElementInView { get; set; }

	public Rect OccludedRect { get; private set; }

	internal InputPaneVisibilityEventArgs(Rect occludedRect)
	{
		OccludedRect = occludedRect;
	}
}

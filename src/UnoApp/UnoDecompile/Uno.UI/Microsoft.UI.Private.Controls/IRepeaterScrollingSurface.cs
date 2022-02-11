using Windows.Foundation;
using Windows.UI.Xaml;

namespace Microsoft.UI.Private.Controls;

internal interface IRepeaterScrollingSurface
{
	bool IsHorizontallyScrollable { get; }

	bool IsVerticallyScrollable { get; }

	UIElement AnchorElement { get; }

	event ConfigurationChangedEventHandler ConfigurationChanged;

	event PostArrangeEventHandler PostArrange;

	event ViewportChangedEventHandler ViewportChanged;

	void RegisterAnchorCandidate(UIElement element);

	void UnregisterAnchorCandidate(UIElement element);

	Rect GetRelativeViewport(UIElement child);
}

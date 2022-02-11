using Uno;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public interface IScrollAnchorProvider
{
	UIElement CurrentAnchor { get; }

	void RegisterAnchorCandidate(UIElement element);

	void UnregisterAnchorCandidate(UIElement element);
}

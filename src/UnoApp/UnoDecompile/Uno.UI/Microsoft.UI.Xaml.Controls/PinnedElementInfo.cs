using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal struct PinnedElementInfo
{
	private UIElement m_pinnedElement;

	private VirtualizationInfo m_virtInfo;

	public UIElement PinnedElement => m_pinnedElement;

	public VirtualizationInfo VirtualizationInfo => m_virtInfo;

	public PinnedElementInfo(UIElement element)
	{
		m_pinnedElement = element;
		m_virtInfo = ItemsRepeater.GetVirtualizationInfo(element);
	}
}

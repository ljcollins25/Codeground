using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal class ToolTipPopupPanel : PlacementPopupPanel
{
	private readonly ToolTip _toolTip;

	protected override FlyoutPlacementMode PopupPlacement => _toolTip.Placement switch
	{
		PlacementMode.Bottom => FlyoutPlacementMode.Bottom, 
		PlacementMode.Top => FlyoutPlacementMode.Top, 
		PlacementMode.Left => FlyoutPlacementMode.Left, 
		PlacementMode.Right => FlyoutPlacementMode.Right, 
		_ => FlyoutPlacementMode.Top, 
	};

	protected override Point? PositionInAnchorControl => null;

	protected override FrameworkElement AnchorControl => _toolTip.Popup.Anchor as FrameworkElement;

	internal ToolTipPopupPanel(ToolTip toolTip)
		: base(toolTip.Popup)
	{
		_toolTip = toolTip;
		base.Background = null;
	}
}

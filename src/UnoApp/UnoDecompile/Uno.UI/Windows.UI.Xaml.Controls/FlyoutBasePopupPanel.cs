using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

internal class FlyoutBasePopupPanel : PlacementPopupPanel
{
	private readonly FlyoutBase _flyout;

	protected override FlyoutPlacementMode PopupPlacement => _flyout.EffectivePlacement;

	protected override FrameworkElement AnchorControl => _flyout.Target;

	protected override Point? PositionInAnchorControl => _flyout.PopupPositionInTarget;

	internal override FlyoutBase Flyout => _flyout;

	public FlyoutBasePopupPanel(FlyoutBase flyout)
		: base(flyout._popup)
	{
		_flyout = flyout;
		_flyout._popup.IsForFlyout = true;
		base.Background = new SolidColorBrush(Colors.Transparent);
	}
}

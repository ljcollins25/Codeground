using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal class ContentDialogPopupPanel : PopupPanel
{
	public ContentDialogPopupPanel(ContentDialog dialog)
		: base(dialog._popup)
	{
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug($"ArrangeOverride ContentDialogPopupPanel {finalSize}");
		}
		foreach (UIElement child in base.Children)
		{
			if (child != null)
			{
				UIElement uIElement = child;
				Size desiredSize = uIElement.DesiredSize;
				Rect rect = CalculateDialogPlacement(desiredSize);
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().LogDebug($"Arranging ContentDialogPopupPanel {desiredSize} to {rect}");
				}
				uIElement.Arrange(rect);
			}
		}
		return finalSize;
	}

	private Rect CalculateDialogPlacement(Size desiredSize)
	{
		Rect trueVisibleBounds = ApplicationView.GetForCurrentView().TrueVisibleBounds;
		if (desiredSize.Width > trueVisibleBounds.Width)
		{
			desiredSize.Width = trueVisibleBounds.Width;
		}
		if (desiredSize.Height > trueVisibleBounds.Height)
		{
			desiredSize.Height = trueVisibleBounds.Height;
		}
		Point point = new Point((trueVisibleBounds.Width - desiredSize.Width) / 2.0, (trueVisibleBounds.Height - desiredSize.Height) / 2.0);
		return new Rect(point, desiredSize);
	}
}

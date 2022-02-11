using System;
using System.Linq;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace Windows.UI.Xaml.Controls.Primitives;

internal class PopupPanel : Panel
{
	private ManagedWeakReference _popup;

	protected Size _lastMeasuredSize;

	public Popup Popup
	{
		get
		{
			return _popup?.Target as Popup;
		}
		set
		{
			WeakReferencePool.ReturnWeakReference(this, _popup);
			_popup = WeakReferencePool.RentWeakReference(this, value);
		}
	}

	public PopupPanel(Popup popup)
	{
		Popup = popup ?? throw new ArgumentNullException("popup");
		base.Visibility = Visibility.Collapsed;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		bool flag = base.Visibility != Visibility.Collapsed;
		if (!flag)
		{
			availableSize = default(Size);
		}
		UIElement uIElement = GetChildren().FirstOrDefault();
		if (uIElement == null)
		{
			return availableSize;
		}
		if (!flag || Popup.CustomLayouter == null)
		{
			_lastMeasuredSize = MeasureElement(uIElement, availableSize);
		}
		else
		{
			Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
			visibleBounds.Width = Math.Min(availableSize.Width, visibleBounds.Width);
			visibleBounds.Height = Math.Min(availableSize.Height, visibleBounds.Height);
			_lastMeasuredSize = Popup.CustomLayouter.Measure(availableSize, visibleBounds.Size);
		}
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Measured PopupPanel #={0} ({1}) DC={2} child={3} offset={4},{5} availableSize={6} measured={7}", GetHashCode(), (Popup.CustomLayouter == null) ? "" : "**using custom layouter**", Popup.DataContext, uIElement, Popup.HorizontalOffset, Popup.VerticalOffset, availableSize, _lastMeasuredSize));
		}
		return availableSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size size = _lastMeasuredSize;
		bool flag = base.Visibility != Visibility.Collapsed;
		if (!flag)
		{
			finalSize = default(Size);
			size = finalSize;
		}
		UIElement uIElement = GetChildren().FirstOrDefault();
		if (uIElement == null)
		{
			return finalSize;
		}
		if (!flag)
		{
			ArrangeElement(uIElement, default(Rect));
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Arranged PopupPanel #={GetHashCode()} **closed** DC={Popup.DataContext} child={uIElement} finalSize={finalSize}");
			}
		}
		else if (Popup.CustomLayouter == null)
		{
			UIElement uIElement2 = Popup.Anchor ?? Popup;
			Point point = uIElement2.TransformToVisual(this).TransformPoint(default(Point));
			Rect rect = new Rect(point.X + (double)(float)Popup.HorizontalOffset, point.Y + (double)(float)Popup.VerticalOffset, size.Width, size.Height);
			ArrangeElement(uIElement, rect);
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Arranged PopupPanel #={GetHashCode()} DC={Popup.DataContext} child={uIElement} popupLocation={point} offset={Popup.HorizontalOffset},{Popup.VerticalOffset} finalSize={finalSize} childFrame={rect}");
			}
		}
		else
		{
			Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
			visibleBounds.Width = Math.Min(finalSize.Width, visibleBounds.Width);
			visibleBounds.Height = Math.Min(finalSize.Height, visibleBounds.Height);
			Popup.CustomLayouter.Arrange(finalSize, visibleBounds, _lastMeasuredSize);
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Arranged PopupPanel #={GetHashCode()} **using custom layouter** DC={Popup.DataContext} child={uIElement} finalSize={finalSize}");
			}
		}
		return finalSize;
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		this.SetLogicalParent(Popup);
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		this.SetLogicalParent(null);
	}
}

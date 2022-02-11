using System;
using Uno;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class ToolTip : ContentControl
{
	private const double TOOLTIP_TOLERANCE = 2.0;

	private const double DEFAULT_KEYBOARD_OFFSET = 12.0;

	private const double DEFAULT_MOUSE_OFFSET = 20.0;

	private const double DEFAULT_TOUCH_OFFSET = 44.0;

	private const double CONTEXT_MENU_HINT_VERTICAL_OFFSET = -5.0;

	private const int m_mousePlacementVerticalOffset = 11;

	internal const PlacementMode DefaultPlacementMode = PlacementMode.Top;

	private Popup? _popup;

	private DependencyObject? _owner;

	private PlacementMode? m_pToolTipServicePlacementModeOverride;

	private bool m_bIsPopupPositioned;

	private bool m_bClosing;

	private bool m_bIsOpenAsAutomaticToolTip;

	private bool m_bCallPerformPlacementAtNextPopupOpen;

	private bool m_isSliderThumbToolTip;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalOffset
	{
		get
		{
			return (double)GetValue(VerticalOffsetProperty);
		}
		set
		{
			SetValue(VerticalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement PlacementTarget
	{
		get
		{
			return (UIElement)GetValue(PlacementTargetProperty);
		}
		set
		{
			SetValue(PlacementTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalOffset
	{
		get
		{
			return (double)GetValue(HorizontalOffsetProperty);
		}
		set
		{
			SetValue(HorizontalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ToolTipTemplateSettings TemplateSettings
	{
		get
		{
			throw new NotImplementedException("The member ToolTipTemplateSettings ToolTip.TemplateSettings is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Rect? PlacementRect
	{
		get
		{
			return (Rect?)GetValue(PlacementRectProperty);
		}
		set
		{
			SetValue(PlacementRectProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalOffsetProperty { get; } = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(ToolTip), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlacementTargetProperty { get; } = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(ToolTip), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalOffsetProperty { get; } = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(ToolTip), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlacementRectProperty { get; } = DependencyProperty.Register("PlacementRect", typeof(Rect?), typeof(ToolTip), new FrameworkPropertyMetadata((object)null));


	internal Popup Popup
	{
		get
		{
			if (_popup == null)
			{
				_popup = new Popup
				{
					IsLightDismissEnabled = false
				};
				_popup!.PopupPanel = new PopupPanel(_popup);
				_popup!.Opened += OnPopupOpened;
				_popup!.Closed += delegate
				{
					IsOpen = false;
				};
			}
			return _popup;
		}
	}

	internal long CurrentHoverId { get; set; }

	internal IDisposable? OwnerEventSubscriptions { get; set; }

	internal IDisposable? OwnerVisibilitySubscription { get; set; }

	private FrameworkElement? Target => _owner as FrameworkElement;

	public static DependencyProperty PlacementProperty { get; } = DependencyProperty.Register("Placement", typeof(PlacementMode), typeof(ToolTip), new FrameworkPropertyMetadata(PlacementMode.Top));


	public PlacementMode Placement
	{
		get
		{
			return (PlacementMode)GetValue(PlacementProperty);
		}
		set
		{
			SetValue(PlacementProperty, value);
		}
	}

	public static DependencyProperty IsOpenProperty { get; } = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ToolTip), new FrameworkPropertyMetadata(false, OnOpenChanged));


	public bool IsOpen
	{
		get
		{
			return (bool)GetValue(IsOpenProperty);
		}
		set
		{
			SetValue(IsOpenProperty, value);
		}
	}

	public event RoutedEventHandler? Closed;

	public event RoutedEventHandler? Opened;

	public ToolTip()
	{
		base.DefaultStyleKey = typeof(ToolTip);
		base.SizeChanged += OnToolTipSizeChanged;
		base.Loading += delegate
		{
			PerformPlacementInternal();
		};
	}

	private static void OnOpenChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		(sender as ToolTip)?.OnOpenChanged((bool)args.NewValue);
	}

	private Size GetTooltipSize()
	{
		if (base.ActualHeight != 0.0 && base.ActualWidth != 0.0)
		{
			return new Size(base.ActualWidth, base.ActualHeight);
		}
		if (base.DesiredSize == default(Size))
		{
			ApplyTemplate();
			Measure(Window.Current.Bounds.Size);
		}
		return base.DesiredSize;
	}

	private void OnOpenChanged(bool isOpen)
	{
		PerformPlacementInternal();
		Popup.IsOpen = isOpen;
		if (isOpen)
		{
			AttachToPopup();
			this.Opened?.Invoke(this, new RoutedEventArgs(this));
			GoToElementState("Opened", useTransitions: true);
		}
		else
		{
			this.Closed?.Invoke(this, new RoutedEventArgs(this));
			GoToElementState("Closed", useTransitions: true);
		}
	}

	private void AttachToPopup()
	{
		if (base.Parent == null)
		{
			Popup.Child = this;
		}
		else if (base.Parent != _popup)
		{
			this.Log().Warn("This ToolTip is already in visual tree: won't be able to use it with TooltipService.");
		}
	}

	public void SetAnchor(UIElement element)
	{
		_owner = element;
	}

	private void PerformPlacement(Rect? pTargetRect = null)
	{
		Popup popup = _popup;
		if (popup != null && IsOpen)
		{
			PerformPlacementWithPopup(pTargetRect);
			if (!m_bIsPopupPositioned && IsOpen)
			{
				m_bIsPopupPositioned = true;
				UpdateVisualState();
			}
		}
	}

	private void PerformPlacementWithPopup(Rect? pTargetRect)
	{
		if (IsOpen && base.IsEnabled)
		{
			PlacementMode placementMode = m_pToolTipServicePlacementModeOverride ?? Placement;
			Rect pDimentions = new Rect(HorizontalOffset, VerticalOffset, base.ActualWidth, base.ActualHeight);
			if (placementMode == PlacementMode.Mouse)
			{
				PerformMousePlacementWithPopup(pDimentions, placementMode);
			}
			else
			{
				PerformNonMousePlacementWithPopup(pTargetRect, pDimentions, placementMode);
			}
		}
	}

	private void PerformMousePlacementWithPopup(Rect pDimentions, PlacementMode placement)
	{
		double right = pDimentions.Right;
		double bottom = pDimentions.Bottom;
		double left = pDimentions.Left;
		double top = pDimentions.Top;
		double num = 0.0;
		double num2 = 0.0;
		bool flag = false;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		Rect rect = default(Rect);
		Rect rect2 = default(Rect);
		num = Window.Current.Bounds.Width;
		num2 = Window.Current.Bounds.Height;
		FrameworkElement target = Target;
		if (target != null)
		{
			flag = false;
			if (!target.IsLoaded)
			{
				return;
			}
		}
		Popup popup = Popup;
		Point pointerPosition = CoreWindow.GetForCurrentThread()!.PointerPosition;
		num5 = pointerPosition.X;
		num6 = pointerPosition.Y;
		if (flag)
		{
			num5 = num - num5;
		}
		MovePointToPointerToolTipShowPosition(ref num5, ref num6, placement);
		num6 += 11.0 + top;
		num5 += left;
		num6 = Math.Max(2.0, num6);
		num5 = Math.Max(2.0, num5);
		num3 = num;
		num4 = num2;
		rect.X = num5;
		rect.Y = num6;
		rect.Width = right;
		rect.Height = bottom;
		rect2.Width = num3;
		rect2.Height = num4;
		rect2.Intersect(rect);
		if (Math.Abs(rect2.Width - rect.Width) < 2.0 && Math.Abs(rect2.Height - rect.Height) < 2.0)
		{
			if (flag)
			{
				num5 = num - num5;
			}
			popup.VerticalOffset = num6;
			popup.HorizontalOffset = num5;
			return;
		}
		if (num6 + rect.Height > num4)
		{
			num6 = num4 - rect.Height - 2.0;
		}
		if (num6 < 0.0)
		{
			num6 = 0.0;
		}
		if (num5 + rect.Width > num3)
		{
			num5 = num3 - rect.Width - 2.0;
		}
		if (num5 < 0.0)
		{
			num5 = 0.0;
		}
		Rect toolTipRect = new Rect(num5, num6, rect.Width, rect.Height);
		CalculateTooltipClip(toolTipRect, num3, num4);
		if (flag)
		{
			num5 = num - num5;
		}
		popup.VerticalOffset = num6 + top;
		popup.HorizontalOffset = num5 + left;
	}

	private void PerformNonMousePlacementWithPopup(Rect? pTargetRect, Rect pDimentions, PlacementMode placement)
	{
		double width = pDimentions.Left;
		double height = pDimentions.Top;
		bool flag = false;
		Point point = default(Point);
		Rect rect = default(Rect);
		Size size = default(Size);
		FrameworkElement frameworkElement = _owner as FrameworkElement;
		if (frameworkElement != null && !frameworkElement.IsLoaded)
		{
			return;
		}
		Popup popup = _popup;
		if (popup == null)
		{
			return;
		}
		if (placement == PlacementMode.Mouse)
		{
			placement = PlacementMode.Top;
		}
		if (frameworkElement != null)
		{
			Rect bounds = Window.Current.Bounds;
			Rect constraint = bounds;
			Rect bounds2 = Window.Current.Bounds;
			point.X = bounds2.X;
			point.Y = bounds2.Y;
			size = GetTooltipSize();
			Rect placementRectInWindowCoordinates = GetPlacementRectInWindowCoordinates();
			bool flag2 = false;
			if (pTargetRect.HasValue)
			{
				rect = pTargetRect.Value;
			}
			else if (!placementRectInWindowCoordinates.IsEmpty)
			{
				rect = placementRectInWindowCoordinates;
			}
			else if (!m_isSliderThumbToolTip)
			{
				Point point2 = default(Point);
				point2 = CoreWindow.GetForCurrentThread()!.PointerPosition;
				rect.X = point2.X;
				rect.Y = point2.Y;
			}
			else
			{
				flag2 = true;
			}
			if (flag2 && Target != null)
			{
				Point point3 = default(Point);
				Target!.TransformToVisual(null).TransformPoint(point3);
				rect.X = point3.X;
				rect.Y = point3.Y;
				rect.Width = Target!.ActualWidth;
				rect.Height = Target!.ActualHeight;
			}
			rect = rect.OffsetRect(point.X, point.Y);
			if (!this.IsDependencyPropertySet(HorizontalOffsetProperty))
			{
				width = 20.0;
			}
			if (!this.IsDependencyPropertySet(VerticalOffsetProperty))
			{
				height = 20.0;
			}
			rect.Inflate(width, height);
			(Rect rect, PlacementMode sideChosen) tuple = ToolTipPositioning.QueryRelativePosition(constraint, size, rect, placement);
			Rect item = tuple.rect;
			PlacementMode item2 = tuple.sideChosen;
			Rect toolTipRect = new Rect(0.0, 0.0, base.ActualWidth, base.ActualHeight);
			CalculateTooltipClip(toolTipRect, bounds.Width - bounds.X, bounds.Height - bounds.Y);
			popup.VerticalOffset = item.Top - point.Y;
			popup.HorizontalOffset = (flag ? (item.Right - point.X) : (item.Left - point.X));
		}
	}

	private void CalculateTooltipClip(Rect toolTipRect, double maxX, double maxY)
	{
		Size size = default(Size);
		double num = 0.0;
		double num2 = 0.0;
		num = toolTipRect.Left + toolTipRect.Right - maxX;
		num2 = toolTipRect.Top + toolTipRect.Bottom - maxY;
		if (num >= 0.0 || num2 >= 0.0)
		{
			num = Math.Max(0.0, num);
			num2 = Math.Max(0.0, num2);
			size.Width = Math.Max(0.0, toolTipRect.Right - num);
			size.Height = Math.Max(0.0, toolTipRect.Bottom - num2);
			PerformClipping(size);
		}
	}

	private void MovePointToPointerToolTipShowPosition(ref Point point, PlacementMode placement)
	{
		Rect placementRectInWindowCoordinates = GetPlacementRectInWindowCoordinates();
		if (!placementRectInWindowCoordinates.IsEmpty && placementRectInWindowCoordinates.Contains(point))
		{
			switch (placement)
			{
			case PlacementMode.Left:
				point.X = placementRectInWindowCoordinates.X;
				break;
			case PlacementMode.Right:
				point.X = placementRectInWindowCoordinates.X + placementRectInWindowCoordinates.Width;
				break;
			case PlacementMode.Mouse:
			case PlacementMode.Top:
				point.Y = placementRectInWindowCoordinates.Y;
				break;
			case PlacementMode.Bottom:
				point.Y = placementRectInWindowCoordinates.Y + placementRectInWindowCoordinates.Height;
				break;
			case (PlacementMode)3:
			case (PlacementMode)5:
			case (PlacementMode)6:
			case (PlacementMode)8:
				break;
			}
		}
	}

	private void MovePointToPointerToolTipShowPosition(ref double left, ref double top, PlacementMode placement)
	{
		Point point = new Point(left, top);
		MovePointToPointerToolTipShowPosition(ref point, placement);
		left = point.X;
		top = point.Y;
	}

	private Rect GetPlacementRectInWindowCoordinates()
	{
		Rect rect = Rect.Empty;
		Rect? placementRect = PlacementRect;
		if (placementRect.HasValue)
		{
			Rect valueOrDefault = placementRect.GetValueOrDefault();
			rect = valueOrDefault;
			if (Target != null)
			{
				GeneralTransform generalTransform = Target!.TransformToVisual(null);
				generalTransform.TransformBounds(rect);
			}
		}
		return rect;
	}

	private void PerformPlacementInternal()
	{
		TextElement textElement = _owner as TextElement;
		if (textElement == null)
		{
			PerformPlacement();
		}
	}

	private void OnToolTipSizeChanged(object pSender, SizeChangedEventArgs pArgs)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("{0} - new Size=({1}, {2})", "OnToolTipSizeChanged", base.ActualWidth, base.ActualHeight));
		}
		PerformPlacementInternal();
	}

	private void OnPopupOpened(object? pUnused1, object pUnused2)
	{
		m_bCallPerformPlacementAtNextPopupOpen = false;
		PerformPlacementInternal();
	}

	private void PerformClipping(Size size)
	{
		int childrenCount = VisualTreeHelper.GetChildrenCount(this);
		if (childrenCount > 0 && VisualTreeHelper.GetChild(this, 0) is FrameworkElement frameworkElement)
		{
			if (size.Width < frameworkElement.ActualWidth)
			{
				frameworkElement.Width = size.Width;
			}
			if (size.Height < frameworkElement.ActualHeight)
			{
				frameworkElement.Height = size.Height;
			}
		}
	}
}

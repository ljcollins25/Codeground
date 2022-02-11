using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Primitives;

public class CarouselPanel : VirtualizingPanel, IScrollSnapPointsInfo
{
	private readonly ItemsStackPanelLayout _layout = new ItemsStackPanelLayout();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object ScrollOwner
	{
		get
		{
			throw new NotImplementedException("The member object CarouselPanel.ScrollOwner is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "object CarouselPanel.ScrollOwner");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanVerticallyScroll
	{
		get
		{
			throw new NotImplementedException("The member bool CarouselPanel.CanVerticallyScroll is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "bool CarouselPanel.CanVerticallyScroll");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanHorizontallyScroll
	{
		get
		{
			throw new NotImplementedException("The member bool CarouselPanel.CanHorizontallyScroll is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "bool CarouselPanel.CanHorizontallyScroll");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ExtentHeight
	{
		get
		{
			throw new NotImplementedException("The member double CarouselPanel.ExtentHeight is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ExtentWidth
	{
		get
		{
			throw new NotImplementedException("The member double CarouselPanel.ExtentWidth is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalOffset
	{
		get
		{
			throw new NotImplementedException("The member double CarouselPanel.HorizontalOffset is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalOffset
	{
		get
		{
			throw new NotImplementedException("The member double CarouselPanel.VerticalOffset is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ViewportHeight
	{
		get
		{
			throw new NotImplementedException("The member double CarouselPanel.ViewportHeight is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ViewportWidth
	{
		get
		{
			throw new NotImplementedException("The member double CarouselPanel.ViewportWidth is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool AreHorizontalSnapPointsRegular
	{
		get
		{
			throw new NotImplementedException("The member bool CarouselPanel.AreHorizontalSnapPointsRegular is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool AreVerticalSnapPointsRegular
	{
		get
		{
			throw new NotImplementedException("The member bool CarouselPanel.AreVerticalSnapPointsRegular is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public event EventHandler<object> HorizontalSnapPointsChanged
	{
		[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "event EventHandler<object> CarouselPanel.HorizontalSnapPointsChanged");
		}
		[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "event EventHandler<object> CarouselPanel.HorizontalSnapPointsChanged");
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public event EventHandler<object> VerticalSnapPointsChanged
	{
		[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "event EventHandler<object> CarouselPanel.VerticalSnapPointsChanged");
		}
		[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "event EventHandler<object> CarouselPanel.VerticalSnapPointsChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineUp()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.LineUp()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineDown()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.LineDown()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineLeft()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.LineLeft()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineRight()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.LineRight()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageUp()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.PageUp()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageDown()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.PageDown()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageLeft()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.PageLeft()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageRight()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.PageRight()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelUp()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.MouseWheelUp()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelDown()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.MouseWheelDown()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelLeft()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.MouseWheelLeft()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelRight()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.MouseWheelRight()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetHorizontalOffset(double offset)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.SetHorizontalOffset(double offset)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetVerticalOffset(double offset)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.CarouselPanel", "void CarouselPanel.SetVerticalOffset(double offset)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Rect MakeVisible(UIElement visual, Rect rectangle)
	{
		throw new NotImplementedException("The member Rect CarouselPanel.MakeVisible(UIElement visual, Rect rectangle) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public IReadOnlyList<float> GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment)
	{
		throw new NotImplementedException("The member IReadOnlyList<float> CarouselPanel.GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public float GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset)
	{
		throw new NotImplementedException("The member float CarouselPanel.GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset) is not implemented in Uno.");
	}

	public CarouselPanel()
	{
		_layout.Initialize(this);
		_layout.CacheLength = 0.5;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		return _layout.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		return _layout.ArrangeOverride(finalSize);
	}

	private protected override VirtualizingPanelLayout GetLayouterCore()
	{
		return _layout;
	}
}

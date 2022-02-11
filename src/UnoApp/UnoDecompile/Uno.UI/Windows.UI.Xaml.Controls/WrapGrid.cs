using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class WrapGrid : OrientedVirtualizingPanel
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public VerticalAlignment VerticalChildrenAlignment
	{
		get
		{
			return (VerticalAlignment)GetValue(VerticalChildrenAlignmentProperty);
		}
		set
		{
			SetValue(VerticalChildrenAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Orientation Orientation
	{
		get
		{
			return (Orientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MaximumRowsOrColumns
	{
		get
		{
			return (int)GetValue(MaximumRowsOrColumnsProperty);
		}
		set
		{
			SetValue(MaximumRowsOrColumnsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ItemWidth
	{
		get
		{
			return (double)GetValue(ItemWidthProperty);
		}
		set
		{
			SetValue(ItemWidthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ItemHeight
	{
		get
		{
			return (double)GetValue(ItemHeightProperty);
		}
		set
		{
			SetValue(ItemHeightProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public HorizontalAlignment HorizontalChildrenAlignment
	{
		get
		{
			return (HorizontalAlignment)GetValue(HorizontalChildrenAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalChildrenAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalChildrenAlignmentProperty { get; } = DependencyProperty.Register("HorizontalChildrenAlignment", typeof(HorizontalAlignment), typeof(WrapGrid), new FrameworkPropertyMetadata(HorizontalAlignment.Left));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemHeightProperty { get; } = DependencyProperty.Register("ItemHeight", typeof(double), typeof(WrapGrid), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemWidthProperty { get; } = DependencyProperty.Register("ItemWidth", typeof(double), typeof(WrapGrid), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaximumRowsOrColumnsProperty { get; } = DependencyProperty.Register("MaximumRowsOrColumns", typeof(int), typeof(WrapGrid), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(WrapGrid), new FrameworkPropertyMetadata(Orientation.Vertical));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalChildrenAlignmentProperty { get; } = DependencyProperty.Register("VerticalChildrenAlignment", typeof(VerticalAlignment), typeof(WrapGrid), new FrameworkPropertyMetadata(VerticalAlignment.Top));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public WrapGrid()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WrapGrid", "WrapGrid.WrapGrid()");
	}
}

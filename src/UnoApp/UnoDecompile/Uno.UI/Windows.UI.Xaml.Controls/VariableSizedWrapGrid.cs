using System;
using Uno;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class VariableSizedWrapGrid : Panel
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
	public static DependencyProperty ColumnSpanProperty { get; } = DependencyProperty.RegisterAttached("ColumnSpan", typeof(int), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalChildrenAlignmentProperty { get; } = DependencyProperty.Register("HorizontalChildrenAlignment", typeof(HorizontalAlignment), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(HorizontalAlignment.Left));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemHeightProperty { get; } = DependencyProperty.Register("ItemHeight", typeof(double), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemWidthProperty { get; } = DependencyProperty.Register("ItemWidth", typeof(double), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaximumRowsOrColumnsProperty { get; } = DependencyProperty.Register("MaximumRowsOrColumns", typeof(int), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(Orientation.Vertical));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RowSpanProperty { get; } = DependencyProperty.RegisterAttached("RowSpan", typeof(int), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalChildrenAlignmentProperty { get; } = DependencyProperty.Register("VerticalChildrenAlignment", typeof(VerticalAlignment), typeof(VariableSizedWrapGrid), new FrameworkPropertyMetadata(VerticalAlignment.Top));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static int GetRowSpan(UIElement element)
	{
		return (int)element.GetValue(RowSpanProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetRowSpan(UIElement element, int value)
	{
		element.SetValue(RowSpanProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static int GetColumnSpan(UIElement element)
	{
		return (int)element.GetValue(ColumnSpanProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetColumnSpan(UIElement element, int value)
	{
		element.SetValue(ColumnSpanProperty, value);
	}

	[NotImplemented]
	public VariableSizedWrapGrid()
	{
		throw new NotImplementedException();
	}
}

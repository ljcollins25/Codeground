using System.Collections.Generic;
using Uno;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarPenButton : InkToolbarToolButton
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double SelectedStrokeWidth
	{
		get
		{
			return (double)GetValue(SelectedStrokeWidthProperty);
		}
		set
		{
			SetValue(SelectedStrokeWidthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int SelectedBrushIndex
	{
		get
		{
			return (int)GetValue(SelectedBrushIndexProperty);
		}
		set
		{
			SetValue(SelectedBrushIndexProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<Brush> Palette
	{
		get
		{
			return (IList<Brush>)GetValue(PaletteProperty);
		}
		set
		{
			SetValue(PaletteProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double MinStrokeWidth
	{
		get
		{
			return (double)GetValue(MinStrokeWidthProperty);
		}
		set
		{
			SetValue(MinStrokeWidthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double MaxStrokeWidth
	{
		get
		{
			return (double)GetValue(MaxStrokeWidthProperty);
		}
		set
		{
			SetValue(MaxStrokeWidthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush SelectedBrush => (Brush)GetValue(SelectedBrushProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxStrokeWidthProperty { get; } = DependencyProperty.Register("MaxStrokeWidth", typeof(double), typeof(InkToolbarPenButton), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinStrokeWidthProperty { get; } = DependencyProperty.Register("MinStrokeWidth", typeof(double), typeof(InkToolbarPenButton), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PaletteProperty { get; } = DependencyProperty.Register("Palette", typeof(IList<Brush>), typeof(InkToolbarPenButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedBrushIndexProperty { get; } = DependencyProperty.Register("SelectedBrushIndex", typeof(int), typeof(InkToolbarPenButton), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedBrushProperty { get; } = DependencyProperty.Register("SelectedBrush", typeof(Brush), typeof(InkToolbarPenButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedStrokeWidthProperty { get; } = DependencyProperty.Register("SelectedStrokeWidth", typeof(double), typeof(InkToolbarPenButton), new FrameworkPropertyMetadata(0.0));

}

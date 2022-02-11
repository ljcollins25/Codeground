using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media;

[NotImplemented]
public class TileBrush : Brush
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Stretch Stretch
	{
		get
		{
			return (Stretch)GetValue(StretchProperty);
		}
		set
		{
			SetValue(StretchProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public AlignmentY AlignmentY
	{
		get
		{
			return (AlignmentY)GetValue(AlignmentYProperty);
		}
		set
		{
			SetValue(AlignmentYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public AlignmentX AlignmentX
	{
		get
		{
			return (AlignmentX)GetValue(AlignmentXProperty);
		}
		set
		{
			SetValue(AlignmentXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AlignmentXProperty { get; } = DependencyProperty.Register("AlignmentX", typeof(AlignmentX), typeof(TileBrush), new FrameworkPropertyMetadata(AlignmentX.Left));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AlignmentYProperty { get; } = DependencyProperty.Register("AlignmentY", typeof(AlignmentY), typeof(TileBrush), new FrameworkPropertyMetadata(AlignmentY.Top));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(TileBrush), new FrameworkPropertyMetadata(Stretch.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected TileBrush()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.TileBrush", "TileBrush.TileBrush()");
	}
}

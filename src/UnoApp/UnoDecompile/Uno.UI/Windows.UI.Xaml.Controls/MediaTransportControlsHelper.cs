using Uno;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class MediaTransportControlsHelper
{
	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty DropoutOrderProperty { get; } = DependencyProperty.RegisterAttached("DropoutOrder", typeof(int?), typeof(MediaTransportControlsHelper), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static int? GetDropoutOrder(UIElement element)
	{
		return (int?)element.GetValue(DropoutOrderProperty);
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static void SetDropoutOrder(UIElement element, int? value)
	{
		element.SetValue(DropoutOrderProperty, value);
	}
}

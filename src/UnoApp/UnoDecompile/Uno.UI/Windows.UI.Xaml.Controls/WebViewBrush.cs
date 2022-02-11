using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class WebViewBrush : TileBrush
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string SourceName
	{
		get
		{
			return (string)GetValue(SourceNameProperty);
		}
		set
		{
			SetValue(SourceNameProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SourceNameProperty { get; } = DependencyProperty.Register("SourceName", typeof(string), typeof(WebViewBrush), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public WebViewBrush()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebViewBrush", "WebViewBrush.WebViewBrush()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Redraw()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebViewBrush", "void WebViewBrush.Redraw()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetSource(WebView source)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebViewBrush", "void WebViewBrush.SetSource(WebView source)");
	}
}

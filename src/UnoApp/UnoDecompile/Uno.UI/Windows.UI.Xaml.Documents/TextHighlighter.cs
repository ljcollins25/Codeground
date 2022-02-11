using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Documents;

[NotImplemented]
public class TextHighlighter
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush Foreground
	{
		get
		{
			return (Brush)this.GetValue(ForegroundProperty);
		}
		set
		{
			this.SetValue(ForegroundProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush Background
	{
		get
		{
			return (Brush)this.GetValue(BackgroundProperty);
		}
		set
		{
			this.SetValue(BackgroundProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<TextRange> Ranges
	{
		get
		{
			throw new NotImplementedException("The member IList<TextRange> TextHighlighter.Ranges is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty BackgroundProperty { get; } = DependencyProperty.Register("Background", typeof(Brush), typeof(TextHighlighter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(TextHighlighter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextHighlighter()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextHighlighter", "TextHighlighter.TextHighlighter()");
	}
}

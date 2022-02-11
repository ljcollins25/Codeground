using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Documents;

[NotImplemented]
public class InlineUIContainer : Inline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Child
	{
		get
		{
			throw new NotImplementedException("The member UIElement InlineUIContainer.Child is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.InlineUIContainer", "UIElement InlineUIContainer.Child");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InlineUIContainer()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.InlineUIContainer", "InlineUIContainer.InlineUIContainer()");
	}
}

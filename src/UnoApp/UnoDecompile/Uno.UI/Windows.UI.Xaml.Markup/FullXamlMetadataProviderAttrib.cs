using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Markup;

[NotImplemented]
public class FullXamlMetadataProviderAttribute : Attribute
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FullXamlMetadataProviderAttribute()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Markup.FullXamlMetadataProviderAttribute", "FullXamlMetadataProviderAttribute.FullXamlMetadataProviderAttribute()");
	}
}

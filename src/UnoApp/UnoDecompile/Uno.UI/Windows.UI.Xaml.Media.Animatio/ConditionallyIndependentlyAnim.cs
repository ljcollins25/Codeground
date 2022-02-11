using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class ConditionallyIndependentlyAnimatableAttribute : Attribute
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ConditionallyIndependentlyAnimatableAttribute()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.ConditionallyIndependentlyAnimatableAttribute", "ConditionallyIndependentlyAnimatableAttribute.ConditionallyIndependentlyAnimatableAttribute()");
	}
}

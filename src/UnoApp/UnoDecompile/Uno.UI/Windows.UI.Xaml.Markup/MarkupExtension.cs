using System;
using Uno;

namespace Windows.UI.Xaml.Markup;

public class MarkupExtension : IMarkupExtensionOverrides
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual object ProvideValue()
	{
		throw new NotImplementedException("The member object MarkupExtension.ProvideValue() is not implemented in Uno.");
	}

	object IMarkupExtensionOverrides.ProvideValue()
	{
		return ProvideValue();
	}
}

using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class AnchorRequestedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Anchor
	{
		get
		{
			throw new NotImplementedException("The member UIElement AnchorRequestedEventArgs.Anchor is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.AnchorRequestedEventArgs", "UIElement AnchorRequestedEventArgs.Anchor");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<UIElement> AnchorCandidates
	{
		get
		{
			throw new NotImplementedException("The member IList<UIElement> AnchorRequestedEventArgs.AnchorCandidates is not implemented in Uno.");
		}
	}
}

using System;
using Uno;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml;

[NotImplemented]
public class FrameworkViewSource : IFrameworkViewSource
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FrameworkViewSource()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.FrameworkViewSource", "FrameworkViewSource.FrameworkViewSource()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IFrameworkView CreateView()
	{
		throw new NotImplementedException("The member IFrameworkView FrameworkViewSource.CreateView() is not implemented in Uno.");
	}
}

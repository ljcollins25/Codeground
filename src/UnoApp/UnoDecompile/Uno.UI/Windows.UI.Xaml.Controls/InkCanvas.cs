using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Input.Inking;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkCanvas : FrameworkElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkPresenter InkPresenter
	{
		get
		{
			throw new NotImplementedException("The member InkPresenter InkCanvas.InkPresenter is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkCanvas()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkCanvas", "InkCanvas.InkCanvas()");
	}
}

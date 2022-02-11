using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Primitives;

public class FlyoutShowOptions
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlyoutShowMode ShowMode
	{
		get
		{
			throw new NotImplementedException("The member FlyoutShowMode FlyoutShowOptions.ShowMode is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.FlyoutShowOptions", "FlyoutShowMode FlyoutShowOptions.ShowMode");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Rect? ExclusionRect
	{
		get
		{
			throw new NotImplementedException("The member Rect? FlyoutShowOptions.ExclusionRect is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.FlyoutShowOptions", "Rect? FlyoutShowOptions.ExclusionRect");
		}
	}

	public Point? Position { get; set; }

	public FlyoutPlacementMode Placement { get; set; } = FlyoutPlacementMode.Auto;

}

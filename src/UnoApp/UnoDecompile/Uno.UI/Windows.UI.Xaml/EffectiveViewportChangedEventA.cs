using System;
using Uno;
using Windows.Foundation;

namespace Windows.UI.Xaml;

public class EffectiveViewportChangedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double BringIntoViewDistanceX
	{
		get
		{
			throw new NotImplementedException("The member double EffectiveViewportChangedEventArgs.BringIntoViewDistanceX is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double BringIntoViewDistanceY
	{
		get
		{
			throw new NotImplementedException("The member double EffectiveViewportChangedEventArgs.BringIntoViewDistanceY is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Rect MaxViewport
	{
		get
		{
			throw new NotImplementedException("The member Rect EffectiveViewportChangedEventArgs.MaxViewport is not implemented in Uno.");
		}
	}

	public Rect EffectiveViewport { get; }

	internal EffectiveViewportChangedEventArgs(Rect effectiveViewport)
	{
		EffectiveViewport = effectiveViewport;
	}
}

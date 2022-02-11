using System;
using System.Collections.Generic;
using Uno;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapElementClickEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Geopoint Location
	{
		get
		{
			throw new NotImplementedException("The member Geopoint MapElementClickEventArgs.Location is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<MapElement> MapElements
	{
		get
		{
			throw new NotImplementedException("The member IList<MapElement> MapElementClickEventArgs.MapElements is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Point Position
	{
		get
		{
			throw new NotImplementedException("The member Point MapElementClickEventArgs.Position is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapElementClickEventArgs()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs", "MapElementClickEventArgs.MapElementClickEventArgs()");
	}
}

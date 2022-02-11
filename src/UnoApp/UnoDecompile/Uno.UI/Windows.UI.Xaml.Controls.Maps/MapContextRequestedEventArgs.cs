using System;
using System.Collections.Generic;
using Uno;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapContextRequestedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Geopoint Location
	{
		get
		{
			throw new NotImplementedException("The member Geopoint MapContextRequestedEventArgs.Location is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IReadOnlyList<MapElement> MapElements
	{
		get
		{
			throw new NotImplementedException("The member IReadOnlyList<MapElement> MapContextRequestedEventArgs.MapElements is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Point Position
	{
		get
		{
			throw new NotImplementedException("The member Point MapContextRequestedEventArgs.Position is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapContextRequestedEventArgs()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs", "MapContextRequestedEventArgs.MapContextRequestedEventArgs()");
	}
}

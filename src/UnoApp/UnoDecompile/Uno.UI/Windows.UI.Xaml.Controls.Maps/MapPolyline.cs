using System;
using Uno;
using Windows.Devices.Geolocation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapPolyline : MapElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double StrokeThickness
	{
		get
		{
			throw new NotImplementedException("The member double MapPolyline.StrokeThickness is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapPolyline", "double MapPolyline.StrokeThickness");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool StrokeDashed
	{
		get
		{
			return (bool)GetValue(StrokeDashedProperty);
		}
		set
		{
			SetValue(StrokeDashedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Color StrokeColor
	{
		get
		{
			throw new NotImplementedException("The member Color MapPolyline.StrokeColor is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapPolyline", "Color MapPolyline.StrokeColor");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Geopath Path
	{
		get
		{
			return (Geopath)GetValue(PathProperty);
		}
		set
		{
			SetValue(PathProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PathProperty { get; } = DependencyProperty.Register("Path", typeof(Geopath), typeof(MapPolyline), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeDashedProperty { get; } = DependencyProperty.Register("StrokeDashed", typeof(bool), typeof(MapPolyline), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapPolyline()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapPolyline", "MapPolyline.MapPolyline()");
	}
}

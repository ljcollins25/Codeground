using System;
using System.Collections.Generic;
using Uno;
using Windows.Devices.Geolocation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapPolygon : MapElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double StrokeThickness
	{
		get
		{
			return (double)GetValue(StrokeThicknessProperty);
		}
		set
		{
			SetValue(StrokeThicknessProperty, value);
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
			throw new NotImplementedException("The member Color MapPolygon.StrokeColor is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapPolygon", "Color MapPolygon.StrokeColor");
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
	public Color FillColor
	{
		get
		{
			throw new NotImplementedException("The member Color MapPolygon.FillColor is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapPolygon", "Color MapPolygon.FillColor");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<Geopath> Paths
	{
		get
		{
			throw new NotImplementedException("The member IList<Geopath> MapPolygon.Paths is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PathProperty { get; } = DependencyProperty.Register("Path", typeof(Geopath), typeof(MapPolygon), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeDashedProperty { get; } = DependencyProperty.Register("StrokeDashed", typeof(bool), typeof(MapPolygon), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeThicknessProperty { get; } = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(MapPolygon), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapPolygon()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapPolygon", "MapPolygon.MapPolygon()");
	}
}

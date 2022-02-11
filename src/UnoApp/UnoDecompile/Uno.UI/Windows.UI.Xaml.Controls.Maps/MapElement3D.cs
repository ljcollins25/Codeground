using System;
using System.Numerics;
using Uno;
using Windows.Devices.Geolocation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapElement3D : MapElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3 Scale
	{
		get
		{
			return (Vector3)GetValue(ScaleProperty);
		}
		set
		{
			SetValue(ScaleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Roll
	{
		get
		{
			return (double)GetValue(RollProperty);
		}
		set
		{
			SetValue(RollProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Pitch
	{
		get
		{
			return (double)GetValue(PitchProperty);
		}
		set
		{
			SetValue(PitchProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapModel3D Model
	{
		get
		{
			throw new NotImplementedException("The member MapModel3D MapElement3D.Model is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElement3D", "MapModel3D MapElement3D.Model");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Geopoint Location
	{
		get
		{
			return (Geopoint)GetValue(LocationProperty);
		}
		set
		{
			SetValue(LocationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Heading
	{
		get
		{
			return (double)GetValue(HeadingProperty);
		}
		set
		{
			SetValue(HeadingProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeadingProperty { get; } = DependencyProperty.Register("Heading", typeof(double), typeof(MapElement3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LocationProperty { get; } = DependencyProperty.Register("Location", typeof(Geopoint), typeof(MapElement3D), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PitchProperty { get; } = DependencyProperty.Register("Pitch", typeof(double), typeof(MapElement3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RollProperty { get; } = DependencyProperty.Register("Roll", typeof(double), typeof(MapElement3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ScaleProperty { get; } = DependencyProperty.Register("Scale", typeof(Vector3), typeof(MapElement3D), new FrameworkPropertyMetadata(default(Vector3)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapElement3D()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElement3D", "MapElement3D.MapElement3D()");
	}
}

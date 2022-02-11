using System;
using Uno;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapBillboard : MapElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Point NormalizedAnchorPoint
	{
		get
		{
			return (Point)GetValue(NormalizedAnchorPointProperty);
		}
		set
		{
			SetValue(NormalizedAnchorPointProperty, value);
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
	public IRandomAccessStreamReference Image
	{
		get
		{
			throw new NotImplementedException("The member IRandomAccessStreamReference MapBillboard.Image is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapBillboard", "IRandomAccessStreamReference MapBillboard.Image");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapElementCollisionBehavior CollisionBehaviorDesired
	{
		get
		{
			return (MapElementCollisionBehavior)GetValue(CollisionBehaviorDesiredProperty);
		}
		set
		{
			SetValue(CollisionBehaviorDesiredProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapCamera ReferenceCamera
	{
		get
		{
			throw new NotImplementedException("The member MapCamera MapBillboard.ReferenceCamera is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CollisionBehaviorDesiredProperty { get; } = DependencyProperty.Register("CollisionBehaviorDesired", typeof(MapElementCollisionBehavior), typeof(MapBillboard), new FrameworkPropertyMetadata(MapElementCollisionBehavior.Hide));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LocationProperty { get; } = DependencyProperty.Register("Location", typeof(Geopoint), typeof(MapBillboard), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty NormalizedAnchorPointProperty { get; } = DependencyProperty.Register("NormalizedAnchorPoint", typeof(Point), typeof(MapBillboard), new FrameworkPropertyMetadata(default(Point)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapBillboard(MapCamera camera)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapBillboard", "MapBillboard.MapBillboard(MapCamera camera)");
	}
}

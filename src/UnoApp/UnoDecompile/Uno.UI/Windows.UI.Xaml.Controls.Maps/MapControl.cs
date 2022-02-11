using System;
using System.Collections.Generic;
using Uno;
using Uno.Foundation.Logging;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapControl : Control, IUnoMapControl
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanTiltDown => (bool)GetValue(CanTiltDownProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanTiltUp => (bool)GetValue(CanTiltUpProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanZoomIn => (bool)GetValue(CanZoomInProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanZoomOut => (bool)GetValue(CanZoomOutProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanTiltUpProperty { get; } = DependencyProperty.Register("CanTiltUp", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanZoomInProperty { get; } = DependencyProperty.Register("CanZoomIn", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanZoomOutProperty { get; } = DependencyProperty.Register("CanZoomOut", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanTiltDownProperty { get; } = DependencyProperty.Register("CanTiltDown", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public new MapStyle Style
	{
		get
		{
			return (MapStyle)GetValue(StyleProperty);
		}
		set
		{
			SetValue(StyleProperty, value);
		}
	}

	public double DesiredPitch
	{
		get
		{
			return (double)GetValue(DesiredPitchProperty);
		}
		set
		{
			SetValue(DesiredPitchProperty, value);
		}
	}

	public MapColorScheme ColorScheme
	{
		get
		{
			return (MapColorScheme)GetValue(ColorSchemeProperty);
		}
		set
		{
			SetValue(ColorSchemeProperty, value);
		}
	}

	public bool PedestrianFeaturesVisible
	{
		get
		{
			return (bool)GetValue(PedestrianFeaturesVisibleProperty);
		}
		set
		{
			SetValue(PedestrianFeaturesVisibleProperty, value);
		}
	}

	public Geopoint Center
	{
		get
		{
			return (Geopoint)GetValue(CenterProperty);
		}
		set
		{
			SetValue(CenterProperty, value);
		}
	}

	public bool LandmarksVisible
	{
		get
		{
			return (bool)GetValue(LandmarksVisibleProperty);
		}
		set
		{
			SetValue(LandmarksVisibleProperty, value);
		}
	}

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

	public MapWatermarkMode WatermarkMode
	{
		get
		{
			return (MapWatermarkMode)GetValue(WatermarkModeProperty);
		}
		set
		{
			SetValue(WatermarkModeProperty, value);
		}
	}

	public string MapServiceToken
	{
		get
		{
			return (string)GetValue(MapServiceTokenProperty);
		}
		set
		{
			SetValue(MapServiceTokenProperty, value);
		}
	}

	public Point TransformOrigin
	{
		get
		{
			return (Point)GetValue(TransformOriginProperty);
		}
		set
		{
			SetValue(TransformOriginProperty, value);
		}
	}

	public bool TrafficFlowVisible
	{
		get
		{
			return (bool)GetValue(TrafficFlowVisibleProperty);
		}
		set
		{
			SetValue(TrafficFlowVisibleProperty, value);
		}
	}

	public double ZoomLevel
	{
		get
		{
			return (double)GetValue(ZoomLevelProperty);
		}
		set
		{
			SetValue(ZoomLevelProperty, value);
		}
	}

	public IList<DependencyObject> Children
	{
		get
		{
			return (IList<DependencyObject>)GetValue(ChildrenProperty);
		}
		set
		{
			SetValue(ChildrenProperty, value);
		}
	}

	public MapLoadingStatus LoadingStatus => (MapLoadingStatus)GetValue(LoadingStatusProperty);

	public IList<MapElement> MapElements => (IList<MapElement>)GetValue(MapElementsProperty);

	public double MaxZoomLevel
	{
		get
		{
			throw new NotImplementedException("The member double MapControl.MaxZoomLevel is not implemented in Uno.");
		}
	}

	public double MinZoomLevel
	{
		get
		{
			throw new NotImplementedException("The member double MapControl.MinZoomLevel is not implemented in Uno.");
		}
	}

	public double Pitch => (double)GetValue(PitchProperty);

	public IList<MapRouteView> Routes => (IList<MapRouteView>)GetValue(RoutesProperty);

	public IList<MapTileSource> TileSources => (IList<MapTileSource>)GetValue(TileSourcesProperty);

	public MapCustomExperience CustomExperience
	{
		get
		{
			throw new NotImplementedException("The member MapCustomExperience MapControl.CustomExperience is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "MapCustomExperience MapControl.CustomExperience");
		}
	}

	public bool BusinessLandmarksVisible
	{
		get
		{
			return (bool)GetValue(BusinessLandmarksVisibleProperty);
		}
		set
		{
			SetValue(BusinessLandmarksVisibleProperty, value);
		}
	}

	public MapInteractionMode ZoomInteractionMode
	{
		get
		{
			return (MapInteractionMode)GetValue(ZoomInteractionModeProperty);
		}
		set
		{
			SetValue(ZoomInteractionModeProperty, value);
		}
	}

	public bool TransitFeaturesVisible
	{
		get
		{
			return (bool)GetValue(TransitFeaturesVisibleProperty);
		}
		set
		{
			SetValue(TransitFeaturesVisibleProperty, value);
		}
	}

	public MapPanInteractionMode PanInteractionMode
	{
		get
		{
			return (MapPanInteractionMode)GetValue(PanInteractionModeProperty);
		}
		set
		{
			SetValue(PanInteractionModeProperty, value);
		}
	}

	public MapInteractionMode TiltInteractionMode
	{
		get
		{
			return (MapInteractionMode)GetValue(TiltInteractionModeProperty);
		}
		set
		{
			SetValue(TiltInteractionModeProperty, value);
		}
	}

	public MapScene Scene
	{
		get
		{
			return (MapScene)GetValue(SceneProperty);
		}
		set
		{
			SetValue(SceneProperty, value);
		}
	}

	public MapInteractionMode RotateInteractionMode
	{
		get
		{
			return (MapInteractionMode)GetValue(RotateInteractionModeProperty);
		}
		set
		{
			SetValue(RotateInteractionModeProperty, value);
		}
	}

	public bool Is3DSupported => (bool)GetValue(Is3DSupportedProperty);

	public bool IsStreetsideSupported => (bool)GetValue(IsStreetsideSupportedProperty);

	public MapCamera TargetCamera
	{
		get
		{
			throw new NotImplementedException("The member MapCamera MapControl.TargetCamera is not implemented in Uno.");
		}
	}

	public MapCamera ActualCamera
	{
		get
		{
			throw new NotImplementedException("The member MapCamera MapControl.ActualCamera is not implemented in Uno.");
		}
	}

	public bool TransitFeaturesEnabled
	{
		get
		{
			return (bool)GetValue(TransitFeaturesEnabledProperty);
		}
		set
		{
			SetValue(TransitFeaturesEnabledProperty, value);
		}
	}

	public bool BusinessLandmarksEnabled
	{
		get
		{
			return (bool)GetValue(BusinessLandmarksEnabledProperty);
		}
		set
		{
			SetValue(BusinessLandmarksEnabledProperty, value);
		}
	}

	public Thickness ViewPadding
	{
		get
		{
			return (Thickness)GetValue(ViewPaddingProperty);
		}
		set
		{
			SetValue(ViewPaddingProperty, value);
		}
	}

	public MapStyleSheet StyleSheet
	{
		get
		{
			return (MapStyleSheet)GetValue(StyleSheetProperty);
		}
		set
		{
			SetValue(StyleSheetProperty, value);
		}
	}

	public MapProjection MapProjection
	{
		get
		{
			return (MapProjection)GetValue(MapProjectionProperty);
		}
		set
		{
			SetValue(MapProjectionProperty, value);
		}
	}

	public IList<MapLayer> Layers
	{
		get
		{
			return (IList<MapLayer>)GetValue(LayersProperty);
		}
		set
		{
			SetValue(LayersProperty, value);
		}
	}

	public string Region
	{
		get
		{
			return (string)GetValue(RegionProperty);
		}
		set
		{
			SetValue(RegionProperty, value);
		}
	}

	public static DependencyProperty CenterProperty { get; } = DependencyProperty.Register("Center", typeof(Geopoint), typeof(MapControl), new FrameworkPropertyMetadata(new Geopoint(default(BasicGeoposition))));


	public static DependencyProperty ChildrenProperty { get; } = DependencyProperty.Register("Children", typeof(IList<DependencyObject>), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty ColorSchemeProperty { get; } = DependencyProperty.Register("ColorScheme", typeof(MapColorScheme), typeof(MapControl), new FrameworkPropertyMetadata(MapColorScheme.Light));


	public static DependencyProperty DesiredPitchProperty { get; } = DependencyProperty.Register("DesiredPitch", typeof(double), typeof(MapControl), new FrameworkPropertyMetadata(0.0));


	public static DependencyProperty HeadingProperty { get; } = DependencyProperty.Register("Heading", typeof(double), typeof(MapControl), new FrameworkPropertyMetadata(0.0));


	public static DependencyProperty LandmarksVisibleProperty { get; } = DependencyProperty.Register("LandmarksVisible", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty LocationProperty { get; } = DependencyProperty.RegisterAttached("Location", typeof(Geopoint), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty MapElementsProperty { get; } = DependencyProperty.Register("MapElements", typeof(IList<MapElement>), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty MapServiceTokenProperty { get; } = DependencyProperty.Register("MapServiceToken", typeof(string), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty NormalizedAnchorPointProperty { get; } = DependencyProperty.RegisterAttached("NormalizedAnchorPoint", typeof(Point), typeof(MapControl), new FrameworkPropertyMetadata(default(Point)));


	public static DependencyProperty PedestrianFeaturesVisibleProperty { get; } = DependencyProperty.Register("PedestrianFeaturesVisible", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty PitchProperty { get; } = DependencyProperty.Register("Pitch", typeof(double), typeof(MapControl), new FrameworkPropertyMetadata(0.0));


	public static DependencyProperty RoutesProperty { get; } = DependencyProperty.Register("Routes", typeof(IList<MapRouteView>), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public new static DependencyProperty StyleProperty { get; } = DependencyProperty.Register("Style", typeof(MapStyle), typeof(MapControl), new FrameworkPropertyMetadata(MapStyle.None));


	public static DependencyProperty TileSourcesProperty { get; } = DependencyProperty.Register("TileSources", typeof(IList<MapTileSource>), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty TrafficFlowVisibleProperty { get; } = DependencyProperty.Register("TrafficFlowVisible", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty TransformOriginProperty { get; } = DependencyProperty.Register("TransformOrigin", typeof(Point), typeof(MapControl), new FrameworkPropertyMetadata(default(Point)));


	public static DependencyProperty WatermarkModeProperty { get; } = DependencyProperty.Register("WatermarkMode", typeof(MapWatermarkMode), typeof(MapControl), new FrameworkPropertyMetadata(MapWatermarkMode.Automatic));


	public static DependencyProperty ZoomLevelProperty { get; } = DependencyProperty.Register("ZoomLevel", typeof(double), typeof(MapControl), new FrameworkPropertyMetadata(0.0));


	public static DependencyProperty LoadingStatusProperty { get; } = DependencyProperty.Register("LoadingStatus", typeof(MapLoadingStatus), typeof(MapControl), new FrameworkPropertyMetadata(MapLoadingStatus.Loading));


	public static DependencyProperty BusinessLandmarksVisibleProperty { get; } = DependencyProperty.Register("BusinessLandmarksVisible", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty Is3DSupportedProperty { get; } = DependencyProperty.Register("Is3DSupported", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty PanInteractionModeProperty { get; } = DependencyProperty.Register("PanInteractionMode", typeof(MapPanInteractionMode), typeof(MapControl), new FrameworkPropertyMetadata(MapPanInteractionMode.Auto));


	public static DependencyProperty RotateInteractionModeProperty { get; } = DependencyProperty.Register("RotateInteractionMode", typeof(MapInteractionMode), typeof(MapControl), new FrameworkPropertyMetadata(MapInteractionMode.Auto));


	public static DependencyProperty TiltInteractionModeProperty { get; } = DependencyProperty.Register("TiltInteractionMode", typeof(MapInteractionMode), typeof(MapControl), new FrameworkPropertyMetadata(MapInteractionMode.Auto));


	public static DependencyProperty TransitFeaturesVisibleProperty { get; } = DependencyProperty.Register("TransitFeaturesVisible", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty ZoomInteractionModeProperty { get; } = DependencyProperty.Register("ZoomInteractionMode", typeof(MapInteractionMode), typeof(MapControl), new FrameworkPropertyMetadata(MapInteractionMode.Auto));


	public static DependencyProperty IsStreetsideSupportedProperty { get; } = DependencyProperty.Register("IsStreetsideSupported", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty SceneProperty { get; } = DependencyProperty.Register("Scene", typeof(MapScene), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty BusinessLandmarksEnabledProperty { get; } = DependencyProperty.Register("BusinessLandmarksEnabled", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty TransitFeaturesEnabledProperty { get; } = DependencyProperty.Register("TransitFeaturesEnabled", typeof(bool), typeof(MapControl), new FrameworkPropertyMetadata(false));


	public static DependencyProperty MapProjectionProperty { get; } = DependencyProperty.Register("MapProjection", typeof(MapProjection), typeof(MapControl), new FrameworkPropertyMetadata(MapProjection.WebMercator));


	public static DependencyProperty StyleSheetProperty { get; } = DependencyProperty.Register("StyleSheet", typeof(MapStyleSheet), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty ViewPaddingProperty { get; } = DependencyProperty.Register("ViewPadding", typeof(Thickness), typeof(MapControl), new FrameworkPropertyMetadata(default(Thickness)));


	public static DependencyProperty LayersProperty { get; } = DependencyProperty.Register("Layers", typeof(IList<MapLayer>), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty RegionProperty { get; } = DependencyProperty.Register("Region", typeof(string), typeof(MapControl), new FrameworkPropertyMetadata((object)null));


	public event TypedEventHandler<MapControl, object> CenterChanged;

	public event TypedEventHandler<MapControl, object> HeadingChanged
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.HeadingChanged");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.HeadingChanged");
		}
	}

	public event TypedEventHandler<MapControl, object> LoadingStatusChanged
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.LoadingStatusChanged");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.LoadingStatusChanged");
		}
	}

	public event TypedEventHandler<MapControl, MapInputEventArgs> MapDoubleTapped
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapInputEventArgs> MapControl.MapDoubleTapped");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapInputEventArgs> MapControl.MapDoubleTapped");
		}
	}

	public event TypedEventHandler<MapControl, MapInputEventArgs> MapHolding
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapInputEventArgs> MapControl.MapHolding");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapInputEventArgs> MapControl.MapHolding");
		}
	}

	public event TypedEventHandler<MapControl, MapInputEventArgs> MapTapped
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapInputEventArgs> MapControl.MapTapped");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapInputEventArgs> MapControl.MapTapped");
		}
	}

	public event TypedEventHandler<MapControl, object> PitchChanged
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.PitchChanged");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.PitchChanged");
		}
	}

	public event TypedEventHandler<MapControl, object> TransformOriginChanged
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.TransformOriginChanged");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, object> MapControl.TransformOriginChanged");
		}
	}

	public event TypedEventHandler<MapControl, object> ZoomLevelChanged;

	public event TypedEventHandler<MapControl, MapActualCameraChangedEventArgs> ActualCameraChanged
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapActualCameraChangedEventArgs> MapControl.ActualCameraChanged");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapActualCameraChangedEventArgs> MapControl.ActualCameraChanged");
		}
	}

	public event TypedEventHandler<MapControl, MapActualCameraChangingEventArgs> ActualCameraChanging
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapActualCameraChangingEventArgs> MapControl.ActualCameraChanging");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapActualCameraChangingEventArgs> MapControl.ActualCameraChanging");
		}
	}

	public event TypedEventHandler<MapControl, MapCustomExperienceChangedEventArgs> CustomExperienceChanged
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapCustomExperienceChangedEventArgs> MapControl.CustomExperienceChanged");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapCustomExperienceChangedEventArgs> MapControl.CustomExperienceChanged");
		}
	}

	public event TypedEventHandler<MapControl, MapElementClickEventArgs> MapElementClick
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapElementClickEventArgs> MapControl.MapElementClick");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapElementClickEventArgs> MapControl.MapElementClick");
		}
	}

	public event TypedEventHandler<MapControl, MapElementPointerEnteredEventArgs> MapElementPointerEntered
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapElementPointerEnteredEventArgs> MapControl.MapElementPointerEntered");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapElementPointerEnteredEventArgs> MapControl.MapElementPointerEntered");
		}
	}

	public event TypedEventHandler<MapControl, MapElementPointerExitedEventArgs> MapElementPointerExited
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapElementPointerExitedEventArgs> MapControl.MapElementPointerExited");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapElementPointerExitedEventArgs> MapControl.MapElementPointerExited");
		}
	}

	public event TypedEventHandler<MapControl, MapTargetCameraChangedEventArgs> TargetCameraChanged
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapTargetCameraChangedEventArgs> MapControl.TargetCameraChanged");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapTargetCameraChangedEventArgs> MapControl.TargetCameraChanged");
		}
	}

	public event TypedEventHandler<MapControl, MapRightTappedEventArgs> MapRightTapped
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapRightTappedEventArgs> MapControl.MapRightTapped");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapRightTappedEventArgs> MapControl.MapRightTapped");
		}
	}

	public event TypedEventHandler<MapControl, MapContextRequestedEventArgs> MapContextRequested
	{
		[NotImplemented]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapContextRequestedEventArgs> MapControl.MapContextRequested");
		}
		[NotImplemented]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "event TypedEventHandler<MapControl, MapContextRequestedEventArgs> MapControl.MapContextRequested");
		}
	}

	public MapControl()
	{
		Children = new DependencyObjectCollection(this);
		Layers = new List<MapLayer>();
		base.DefaultStyleKey = typeof(MapControl);
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (this.Log().IsEnabled(LogLevel.Warning))
		{
			this.Log().LogWarning("MapControl is not supported on this target platform.");
		}
	}

	public IReadOnlyList<MapElement> FindMapElementsAtOffset(Point offset)
	{
		throw new NotImplementedException("The member IReadOnlyList<MapElement> MapControl.FindMapElementsAtOffset(Point offset) is not implemented in Uno.");
	}

	public void GetLocationFromOffset(Point offset, out Geopoint location)
	{
		throw new NotImplementedException("The member void MapControl.GetLocationFromOffset(Point offset, out Geopoint location) is not implemented in Uno.");
	}

	public void GetOffsetFromLocation(Geopoint location, out Point offset)
	{
		throw new NotImplementedException("The member void MapControl.GetOffsetFromLocation(Geopoint location, out Point offset) is not implemented in Uno.");
	}

	public void IsLocationInView(Geopoint location, out bool isInView)
	{
		throw new NotImplementedException("The member void MapControl.IsLocationInView(Geopoint location, out bool isInView) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TrySetViewBoundsAsync(GeoboundingBox bounds, Thickness? margin, MapAnimationKind animation)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TrySetViewBoundsAsync(GeoboundingBox bounds, Thickness? margin, MapAnimationKind animation) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TrySetViewAsync(Geopoint center)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TrySetViewAsync(Geopoint center) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TrySetViewAsync(Geopoint center, double? zoomLevel)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TrySetViewAsync(Geopoint center, double? zoomLevel) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TrySetViewAsync(Geopoint center, double? zoomLevel, double? heading, double? desiredPitch)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TrySetViewAsync(Geopoint center, double? zoomLevel, double? heading, double? desiredPitch) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TrySetViewAsync(Geopoint center, double? zoomLevel, double? heading, double? desiredPitch, MapAnimationKind animation)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TrySetViewAsync(Geopoint center, double? zoomLevel, double? heading, double? desiredPitch, MapAnimationKind animation) is not implemented in Uno.");
	}

	public void StartContinuousRotate(double rateInDegreesPerSecond)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StartContinuousRotate(double rateInDegreesPerSecond)");
	}

	public void StopContinuousRotate()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StopContinuousRotate()");
	}

	public void StartContinuousTilt(double rateInDegreesPerSecond)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StartContinuousTilt(double rateInDegreesPerSecond)");
	}

	public void StopContinuousTilt()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StopContinuousTilt()");
	}

	public void StartContinuousZoom(double rateOfChangePerSecond)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StartContinuousZoom(double rateOfChangePerSecond)");
	}

	public void StopContinuousZoom()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StopContinuousZoom()");
	}

	public IAsyncOperation<bool> TryRotateAsync(double degrees)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryRotateAsync(double degrees) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TryRotateToAsync(double angleInDegrees)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryRotateToAsync(double angleInDegrees) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TryTiltAsync(double degrees)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryTiltAsync(double degrees) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TryTiltToAsync(double angleInDegrees)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryTiltToAsync(double angleInDegrees) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TryZoomInAsync()
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryZoomInAsync() is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TryZoomOutAsync()
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryZoomOutAsync() is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TryZoomToAsync(double zoomLevel)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryZoomToAsync(double zoomLevel) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TrySetSceneAsync(MapScene scene)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TrySetSceneAsync(MapScene scene) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TrySetSceneAsync(MapScene scene, MapAnimationKind animationKind)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TrySetSceneAsync(MapScene scene, MapAnimationKind animationKind) is not implemented in Uno.");
	}

	public Geopath GetVisibleRegion(MapVisibleRegionKind region)
	{
		throw new NotImplementedException("The member Geopath MapControl.GetVisibleRegion(MapVisibleRegionKind region) is not implemented in Uno.");
	}

	public IReadOnlyList<MapElement> FindMapElementsAtOffset(Point offset, double radius)
	{
		throw new NotImplementedException("The member IReadOnlyList<MapElement> MapControl.FindMapElementsAtOffset(Point offset, double radius) is not implemented in Uno.");
	}

	public void GetLocationFromOffset(Point offset, AltitudeReferenceSystem desiredReferenceSystem, out Geopoint location)
	{
		throw new NotImplementedException("The member void MapControl.GetLocationFromOffset(Point offset, AltitudeReferenceSystem desiredReferenceSystem, out Geopoint location) is not implemented in Uno.");
	}

	public void StartContinuousPan(double horizontalPixelsPerSecond, double verticalPixelsPerSecond)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StartContinuousPan(double horizontalPixelsPerSecond, double verticalPixelsPerSecond)");
	}

	public void StopContinuousPan()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapControl", "void MapControl.StopContinuousPan()");
	}

	public IAsyncOperation<bool> TryPanAsync(double horizontalPixels, double verticalPixels)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryPanAsync(double horizontalPixels, double verticalPixels) is not implemented in Uno.");
	}

	public IAsyncOperation<bool> TryPanToAsync(Geopoint location)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> MapControl.TryPanToAsync(Geopoint location) is not implemented in Uno.");
	}

	public bool TryGetLocationFromOffset(Point offset, out Geopoint location)
	{
		throw new NotImplementedException("The member bool MapControl.TryGetLocationFromOffset(Point offset, out Geopoint location) is not implemented in Uno.");
	}

	public bool TryGetLocationFromOffset(Point offset, AltitudeReferenceSystem desiredReferenceSystem, out Geopoint location)
	{
		throw new NotImplementedException("The member bool MapControl.TryGetLocationFromOffset(Point offset, AltitudeReferenceSystem desiredReferenceSystem, out Geopoint location) is not implemented in Uno.");
	}

	public static Geopoint GetLocation(DependencyObject element)
	{
		return (Geopoint)element.GetValue(LocationProperty);
	}

	public static void SetLocation(DependencyObject element, Geopoint value)
	{
		element.SetValue(LocationProperty, value);
	}

	public static Point GetNormalizedAnchorPoint(DependencyObject element)
	{
		return (Point)element.GetValue(NormalizedAnchorPointProperty);
	}

	public static void SetNormalizedAnchorPoint(DependencyObject element, Point value)
	{
		element.SetValue(NormalizedAnchorPointProperty, value);
	}

	void IUnoMapControl.RaiseCenterChanged(object sender, object p)
	{
		this.CenterChanged?.Invoke(this, p);
	}

	void IUnoMapControl.RaiseZoomLevelChanged(object sender, object p)
	{
		this.ZoomLevelChanged?.Invoke(this, p);
	}
}

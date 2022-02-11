using System.Collections.Generic;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Maps;

[NotImplemented]
public class MapElementsLayer : MapLayer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<MapElement> MapElements
	{
		get
		{
			return (IList<MapElement>)GetValue(MapElementsProperty);
		}
		set
		{
			SetValue(MapElementsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MapElementsProperty { get; } = DependencyProperty.Register("MapElements", typeof(IList<MapElement>), typeof(MapElementsLayer), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<MapElementsLayer, MapElementsLayerContextRequestedEventArgs> MapContextRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerContextRequestedEventArgs> MapElementsLayer.MapContextRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerContextRequestedEventArgs> MapElementsLayer.MapContextRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<MapElementsLayer, MapElementsLayerClickEventArgs> MapElementClick
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerClickEventArgs> MapElementsLayer.MapElementClick");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerClickEventArgs> MapElementsLayer.MapElementClick");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<MapElementsLayer, MapElementsLayerPointerEnteredEventArgs> MapElementPointerEntered
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerPointerEnteredEventArgs> MapElementsLayer.MapElementPointerEntered");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerPointerEnteredEventArgs> MapElementsLayer.MapElementPointerEntered");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<MapElementsLayer, MapElementsLayerPointerExitedEventArgs> MapElementPointerExited
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerPointerExitedEventArgs> MapElementsLayer.MapElementPointerExited");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "event TypedEventHandler<MapElementsLayer, MapElementsLayerPointerExitedEventArgs> MapElementsLayer.MapElementPointerExited");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MapElementsLayer()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Maps.MapElementsLayer", "MapElementsLayer.MapElementsLayer()");
	}
}

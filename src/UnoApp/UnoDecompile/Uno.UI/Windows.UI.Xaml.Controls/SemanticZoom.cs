using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class SemanticZoom : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ISemanticZoomInformation ZoomedOutView
	{
		get
		{
			return (ISemanticZoomInformation)GetValue(ZoomedOutViewProperty);
		}
		set
		{
			SetValue(ZoomedOutViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ISemanticZoomInformation ZoomedInView
	{
		get
		{
			return (ISemanticZoomInformation)GetValue(ZoomedInViewProperty);
		}
		set
		{
			SetValue(ZoomedInViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsZoomedInViewActive
	{
		get
		{
			return (bool)GetValue(IsZoomedInViewActiveProperty);
		}
		set
		{
			SetValue(IsZoomedInViewActiveProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsZoomOutButtonEnabled
	{
		get
		{
			return (bool)GetValue(IsZoomOutButtonEnabledProperty);
		}
		set
		{
			SetValue(IsZoomOutButtonEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanChangeViews
	{
		get
		{
			return (bool)GetValue(CanChangeViewsProperty);
		}
		set
		{
			SetValue(CanChangeViewsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanChangeViewsProperty { get; } = DependencyProperty.Register("CanChangeViews", typeof(bool), typeof(SemanticZoom), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsZoomOutButtonEnabledProperty { get; } = DependencyProperty.Register("IsZoomOutButtonEnabled", typeof(bool), typeof(SemanticZoom), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsZoomedInViewActiveProperty { get; } = DependencyProperty.Register("IsZoomedInViewActive", typeof(bool), typeof(SemanticZoom), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ZoomedInViewProperty { get; } = DependencyProperty.Register("ZoomedInView", typeof(ISemanticZoomInformation), typeof(SemanticZoom), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ZoomedOutViewProperty { get; } = DependencyProperty.Register("ZoomedOutView", typeof(ISemanticZoomInformation), typeof(SemanticZoom), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event SemanticZoomViewChangedEventHandler ViewChangeCompleted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SemanticZoom", "event SemanticZoomViewChangedEventHandler SemanticZoom.ViewChangeCompleted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SemanticZoom", "event SemanticZoomViewChangedEventHandler SemanticZoom.ViewChangeCompleted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event SemanticZoomViewChangedEventHandler ViewChangeStarted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SemanticZoom", "event SemanticZoomViewChangedEventHandler SemanticZoom.ViewChangeStarted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SemanticZoom", "event SemanticZoomViewChangedEventHandler SemanticZoom.ViewChangeStarted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SemanticZoom()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SemanticZoom", "SemanticZoom.SemanticZoom()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ToggleActiveView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SemanticZoom", "void SemanticZoom.ToggleActiveView()");
	}
}

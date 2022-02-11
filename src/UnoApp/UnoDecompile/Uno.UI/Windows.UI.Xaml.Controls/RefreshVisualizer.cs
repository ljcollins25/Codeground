using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class RefreshVisualizer : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RefreshVisualizerOrientation Orientation
	{
		get
		{
			return (RefreshVisualizerOrientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Content
	{
		get
		{
			return (UIElement)GetValue(ContentProperty);
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RefreshVisualizerState State => (RefreshVisualizerState)GetValue(StateProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(UIElement), typeof(RefreshVisualizer), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	internal static object InfoProviderProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(RefreshVisualizerOrientation), typeof(RefreshVisualizer), new FrameworkPropertyMetadata(RefreshVisualizerOrientation.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StateProperty { get; } = DependencyProperty.Register("State", typeof(RefreshVisualizerState), typeof(RefreshVisualizer), new FrameworkPropertyMetadata(RefreshVisualizerState.Idle));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RefreshVisualizer, RefreshRequestedEventArgs> RefreshRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshRequestedEventArgs> RefreshVisualizer.RefreshRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshRequestedEventArgs> RefreshVisualizer.RefreshRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RefreshVisualizer, RefreshStateChangedEventArgs> RefreshStateChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshStateChangedEventArgs> RefreshVisualizer.RefreshStateChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshStateChangedEventArgs> RefreshVisualizer.RefreshStateChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RefreshVisualizer()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshVisualizer", "RefreshVisualizer.RefreshVisualizer()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RequestRefresh()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshVisualizer", "void RefreshVisualizer.RequestRefresh()");
	}
}

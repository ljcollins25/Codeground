using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class RefreshContainer : ContentControl
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RefreshVisualizer Visualizer
	{
		get
		{
			return (RefreshVisualizer)GetValue(VisualizerProperty);
		}
		set
		{
			SetValue(VisualizerProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RefreshPullDirection PullDirection
	{
		get
		{
			return (RefreshPullDirection)GetValue(PullDirectionProperty);
		}
		set
		{
			SetValue(PullDirectionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PullDirectionProperty { get; } = DependencyProperty.Register("PullDirection", typeof(RefreshPullDirection), typeof(RefreshContainer), new FrameworkPropertyMetadata(RefreshPullDirection.LeftToRight));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VisualizerProperty { get; } = DependencyProperty.Register("Visualizer", typeof(RefreshVisualizer), typeof(RefreshContainer), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RefreshContainer, RefreshRequestedEventArgs> RefreshRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshContainer", "event TypedEventHandler<RefreshContainer, RefreshRequestedEventArgs> RefreshContainer.RefreshRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshContainer", "event TypedEventHandler<RefreshContainer, RefreshRequestedEventArgs> RefreshContainer.RefreshRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RefreshContainer()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshContainer", "RefreshContainer.RefreshContainer()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RequestRefresh()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RefreshContainer", "void RefreshContainer.RequestRefresh()");
	}
}

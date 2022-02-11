using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class VirtualizingStackPanel : OrientedVirtualizingPanel
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Orientation Orientation
	{
		get
		{
			return (Orientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AreScrollSnapPointsRegular
	{
		get
		{
			return (bool)GetValue(AreScrollSnapPointsRegularProperty);
		}
		set
		{
			SetValue(AreScrollSnapPointsRegularProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AreScrollSnapPointsRegularProperty { get; } = DependencyProperty.Register("AreScrollSnapPointsRegular", typeof(bool), typeof(VirtualizingStackPanel), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsVirtualizingProperty { get; } = DependencyProperty.RegisterAttached("IsVirtualizing", typeof(bool), typeof(VirtualizingStackPanel), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(VirtualizingStackPanel), new FrameworkPropertyMetadata(Orientation.Vertical));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VirtualizationModeProperty { get; } = DependencyProperty.RegisterAttached("VirtualizationMode", typeof(VirtualizationMode), typeof(VirtualizingStackPanel), new FrameworkPropertyMetadata(VirtualizationMode.Standard));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event CleanUpVirtualizedItemEventHandler CleanUpVirtualizedItemEvent
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingStackPanel", "event CleanUpVirtualizedItemEventHandler VirtualizingStackPanel.CleanUpVirtualizedItemEvent");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingStackPanel", "event CleanUpVirtualizedItemEventHandler VirtualizingStackPanel.CleanUpVirtualizedItemEvent");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public VirtualizingStackPanel()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingStackPanel", "VirtualizingStackPanel.VirtualizingStackPanel()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnCleanUpVirtualizedItem(CleanUpVirtualizedItemEventArgs e)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingStackPanel", "void VirtualizingStackPanel.OnCleanUpVirtualizedItem(CleanUpVirtualizedItemEventArgs e)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static VirtualizationMode GetVirtualizationMode(DependencyObject element)
	{
		return (VirtualizationMode)element.GetValue(VirtualizationModeProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetVirtualizationMode(DependencyObject element, VirtualizationMode value)
	{
		element.SetValue(VirtualizationModeProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsVirtualizing(DependencyObject o)
	{
		return (bool)o.GetValue(IsVirtualizingProperty);
	}
}

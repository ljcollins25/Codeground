using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class ContinuumNavigationTransitionInfo : NavigationTransitionInfo
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement ExitElement
	{
		get
		{
			return (UIElement)GetValue(ExitElementProperty);
		}
		set
		{
			SetValue(ExitElementProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ExitElementContainerProperty { get; } = DependencyProperty.RegisterAttached("ExitElementContainer", typeof(bool), typeof(ContinuumNavigationTransitionInfo), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ExitElementProperty { get; } = DependencyProperty.Register("ExitElement", typeof(UIElement), typeof(ContinuumNavigationTransitionInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsEntranceElementProperty { get; } = DependencyProperty.RegisterAttached("IsEntranceElement", typeof(bool), typeof(ContinuumNavigationTransitionInfo), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsExitElementProperty { get; } = DependencyProperty.RegisterAttached("IsExitElement", typeof(bool), typeof(ContinuumNavigationTransitionInfo), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ContinuumNavigationTransitionInfo()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.ContinuumNavigationTransitionInfo", "ContinuumNavigationTransitionInfo.ContinuumNavigationTransitionInfo()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsEntranceElement(UIElement element)
	{
		return (bool)element.GetValue(IsEntranceElementProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsEntranceElement(UIElement element, bool value)
	{
		element.SetValue(IsEntranceElementProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsExitElement(UIElement element)
	{
		return (bool)element.GetValue(IsExitElementProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsExitElement(UIElement element, bool value)
	{
		element.SetValue(IsExitElementProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetExitElementContainer(ListViewBase element)
	{
		return (bool)element.GetValue(ExitElementContainerProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetExitElementContainer(ListViewBase element, bool value)
	{
		element.SetValue(ExitElementContainerProperty, value);
	}
}

using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Hosting;

public class ElementCompositionPreview
{
	private const string ChildVisualName = "childVisual";

	private static readonly Compositor _compositor = new Compositor();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetAppWindowContent(AppWindow appWindow, UIElement xamlContent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Hosting.ElementCompositionPreview", "void ElementCompositionPreview.SetAppWindowContent(AppWindow appWindow, UIElement xamlContent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static UIElement GetAppWindowContent(AppWindow appWindow)
	{
		throw new NotImplementedException("The member UIElement ElementCompositionPreview.GetAppWindowContent(AppWindow appWindow) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetImplicitShowAnimation(UIElement element, ICompositionAnimationBase animation)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Hosting.ElementCompositionPreview", "void ElementCompositionPreview.SetImplicitShowAnimation(UIElement element, ICompositionAnimationBase animation)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetImplicitHideAnimation(UIElement element, ICompositionAnimationBase animation)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Hosting.ElementCompositionPreview", "void ElementCompositionPreview.SetImplicitHideAnimation(UIElement element, ICompositionAnimationBase animation)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsTranslationEnabled(UIElement element, bool value)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Hosting.ElementCompositionPreview", "void ElementCompositionPreview.SetIsTranslationEnabled(UIElement element, bool value)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static CompositionPropertySet GetPointerPositionPropertySet(UIElement targetElement)
	{
		throw new NotImplementedException("The member CompositionPropertySet ElementCompositionPreview.GetPointerPositionPropertySet(UIElement targetElement) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static Visual GetElementChildVisual(UIElement element)
	{
		throw new NotImplementedException("The member Visual ElementCompositionPreview.GetElementChildVisual(UIElement element) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static CompositionPropertySet GetScrollViewerManipulationPropertySet(ScrollViewer scrollViewer)
	{
		throw new NotImplementedException("The member CompositionPropertySet ElementCompositionPreview.GetScrollViewerManipulationPropertySet(ScrollViewer scrollViewer) is not implemented in Uno.");
	}

	public static Visual GetElementVisual(UIElement element)
	{
		return new Visual(_compositor)
		{
			NativeOwner = element
		};
	}

	public static void SetElementChildVisual(UIElement element, Visual visual)
	{
	}
}

using System;
using Uno;
using Uno.UI;
using Uno.UI.Dispatching;
using Windows.Foundation.Metadata;
using Windows.UI.Core;

namespace Windows.UI.Xaml.Media;

public class CompositionTarget
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static event EventHandler<RenderedEventArgs> Rendered
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.CompositionTarget", "event EventHandler<RenderedEventArgs> CompositionTarget.Rendered");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.CompositionTarget", "event EventHandler<RenderedEventArgs> CompositionTarget.Rendered");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static event EventHandler<object> SurfaceContentsLost
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.CompositionTarget", "event EventHandler<object> CompositionTarget.SurfaceContentsLost");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.CompositionTarget", "event EventHandler<object> CompositionTarget.SurfaceContentsLost");
		}
	}

	public static event EventHandler<object> Rendering
	{
		add
		{
			Windows.UI.Core.CoreDispatcher.CheckThreadAccess();
			bool shouldRaiseRenderEvents = Uno.UI.Dispatching.CoreDispatcher.Main.ShouldRaiseRenderEvents;
			Uno.UI.Dispatching.CoreDispatcher.Main.Rendering += value;
			Uno.UI.Dispatching.CoreDispatcher.Main.RenderEventThrottle = FeatureConfiguration.CompositionTarget.RenderEventThrottle;
			Uno.UI.Dispatching.CoreDispatcher main = Uno.UI.Dispatching.CoreDispatcher.Main;
			if (main.RenderingEventArgsGenerator == null)
			{
				Func<TimeSpan, object> func2 = (main.RenderingEventArgsGenerator = (TimeSpan d) => new RenderingEventArgs(d));
			}
			if (!shouldRaiseRenderEvents)
			{
				Uno.UI.Dispatching.CoreDispatcher.Main.WakeUp();
			}
		}
		remove
		{
			Uno.UI.Dispatching.CoreDispatcher.CheckThreadAccess();
			Uno.UI.Dispatching.CoreDispatcher.Main.Rendering -= value;
		}
	}
}

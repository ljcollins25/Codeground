using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class ConnectedAnimationService
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CompositionEasingFunction DefaultEasingFunction
	{
		get
		{
			throw new NotImplementedException("The member CompositionEasingFunction ConnectedAnimationService.DefaultEasingFunction is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.ConnectedAnimationService", "CompositionEasingFunction ConnectedAnimationService.DefaultEasingFunction");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TimeSpan DefaultDuration
	{
		get
		{
			throw new NotImplementedException("The member TimeSpan ConnectedAnimationService.DefaultDuration is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.ConnectedAnimationService", "TimeSpan ConnectedAnimationService.DefaultDuration");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ConnectedAnimation PrepareToAnimate(string key, UIElement source)
	{
		throw new NotImplementedException("The member ConnectedAnimation ConnectedAnimationService.PrepareToAnimate(string key, UIElement source) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ConnectedAnimation GetAnimation(string key)
	{
		throw new NotImplementedException("The member ConnectedAnimation ConnectedAnimationService.GetAnimation(string key) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static ConnectedAnimationService GetForCurrentView()
	{
		throw new NotImplementedException("The member ConnectedAnimationService ConnectedAnimationService.GetForCurrentView() is not implemented in Uno.");
	}
}

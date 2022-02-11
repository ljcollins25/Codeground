using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class HandwritingView : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement PlacementTarget
	{
		get
		{
			return (UIElement)GetValue(PlacementTargetProperty);
		}
		set
		{
			SetValue(PlacementTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public HandwritingPanelPlacementAlignment PlacementAlignment
	{
		get
		{
			return (HandwritingPanelPlacementAlignment)GetValue(PlacementAlignmentProperty);
		}
		set
		{
			SetValue(PlacementAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AreCandidatesEnabled
	{
		get
		{
			return (bool)GetValue(AreCandidatesEnabledProperty);
		}
		set
		{
			SetValue(AreCandidatesEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsOpen => (bool)GetValue(IsOpenProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AreCandidatesEnabledProperty { get; } = DependencyProperty.Register("AreCandidatesEnabled", typeof(bool), typeof(HandwritingView), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsOpenProperty { get; } = DependencyProperty.Register("IsOpen", typeof(bool), typeof(HandwritingView), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlacementAlignmentProperty { get; } = DependencyProperty.Register("PlacementAlignment", typeof(HandwritingPanelPlacementAlignment), typeof(HandwritingView), new FrameworkPropertyMetadata(HandwritingPanelPlacementAlignment.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlacementTargetProperty { get; } = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(HandwritingView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<HandwritingView, HandwritingPanelClosedEventArgs> Closed
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.HandwritingView", "event TypedEventHandler<HandwritingView, HandwritingPanelClosedEventArgs> HandwritingView.Closed");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.HandwritingView", "event TypedEventHandler<HandwritingView, HandwritingPanelClosedEventArgs> HandwritingView.Closed");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<HandwritingView, HandwritingPanelOpenedEventArgs> Opened
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.HandwritingView", "event TypedEventHandler<HandwritingView, HandwritingPanelOpenedEventArgs> HandwritingView.Opened");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.HandwritingView", "event TypedEventHandler<HandwritingView, HandwritingPanelOpenedEventArgs> HandwritingView.Opened");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public HandwritingView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.HandwritingView", "HandwritingView.HandwritingView()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool TryClose()
	{
		throw new NotImplementedException("The member bool HandwritingView.TryClose() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool TryOpen()
	{
		throw new NotImplementedException("The member bool HandwritingView.TryOpen() is not implemented in Uno.");
	}
}

using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml;

[NotImplemented]
public class EventTrigger : TriggerBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RoutedEvent RoutedEvent
	{
		get
		{
			throw new NotImplementedException("The member RoutedEvent EventTrigger.RoutedEvent is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.EventTrigger", "RoutedEvent EventTrigger.RoutedEvent");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TriggerActionCollection Actions
	{
		get
		{
			throw new NotImplementedException("The member TriggerActionCollection EventTrigger.Actions is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public EventTrigger()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.EventTrigger", "EventTrigger.EventTrigger()");
	}
}

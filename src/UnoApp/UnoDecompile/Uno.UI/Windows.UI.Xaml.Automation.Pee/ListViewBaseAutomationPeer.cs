using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class ListViewBaseAutomationPeer : SelectorAutomationPeer, IDropTargetProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string DropEffect
	{
		get
		{
			throw new NotImplementedException("The member string ListViewBaseAutomationPeer.DropEffect is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string[] DropEffects
	{
		get
		{
			throw new NotImplementedException("The member string[] ListViewBaseAutomationPeer.DropEffects is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ListViewBaseAutomationPeer(ListViewBase owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ListViewBaseAutomationPeer", "ListViewBaseAutomationPeer.ListViewBaseAutomationPeer(ListViewBase owner)");
	}

	[NotImplemented]
	public ListViewBaseAutomationPeer(object e)
		: base(null)
	{
		throw new NotImplementedException();
	}
}

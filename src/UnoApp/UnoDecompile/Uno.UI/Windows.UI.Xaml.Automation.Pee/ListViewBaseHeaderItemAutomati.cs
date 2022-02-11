using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class ListViewBaseHeaderItemAutomationPeer : FrameworkElementAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected ListViewBaseHeaderItemAutomationPeer(ListViewBaseHeaderItem owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ListViewBaseHeaderItemAutomationPeer", "ListViewBaseHeaderItemAutomationPeer.ListViewBaseHeaderItemAutomationPeer(ListViewBaseHeaderItem owner)");
	}

	[NotImplemented]
	protected ListViewBaseHeaderItemAutomationPeer(object owner)
	{
		throw new NotSupportedException();
	}
}

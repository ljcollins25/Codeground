using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class TreeViewItemAutomationPeer : ListViewItemAutomationPeer, IExpandCollapseProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			throw new NotImplementedException("The member ExpandCollapseState TreeViewItemAutomationPeer.ExpandCollapseState is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TreeViewItemAutomationPeer(TreeViewItem owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer", "TreeViewItemAutomationPeer.TreeViewItemAutomationPeer(TreeViewItem owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Collapse()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer", "void TreeViewItemAutomationPeer.Collapse()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Expand()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer", "void TreeViewItemAutomationPeer.Expand()");
	}
}

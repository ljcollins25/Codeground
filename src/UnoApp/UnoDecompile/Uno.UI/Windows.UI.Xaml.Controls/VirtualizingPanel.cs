using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class VirtualizingPanel : Panel, IVirtualizingPanel
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemContainerGenerator ItemContainerGenerator
	{
		get
		{
			throw new NotImplementedException("The member ItemContainerGenerator VirtualizingPanel.ItemContainerGenerator is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected void AddInternalChild(UIElement child)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingPanel", "void VirtualizingPanel.AddInternalChild(UIElement child)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected void InsertInternalChild(int index, UIElement child)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingPanel", "void VirtualizingPanel.InsertInternalChild(int index, UIElement child)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected void RemoveInternalChildRange(int index, int range)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingPanel", "void VirtualizingPanel.RemoveInternalChildRange(int index, int range)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnItemsChanged(object sender, ItemsChangedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingPanel", "void VirtualizingPanel.OnItemsChanged(object sender, ItemsChangedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnClearChildren()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingPanel", "void VirtualizingPanel.OnClearChildren()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void BringIndexIntoView(int index)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.VirtualizingPanel", "void VirtualizingPanel.BringIndexIntoView(int index)");
	}

	public VirtualizingPanelLayout GetLayouter()
	{
		return GetLayouterCore();
	}

	private protected virtual VirtualizingPanelLayout GetLayouterCore()
	{
		throw new NotSupportedException("This method must be overridden by implementing classes.");
	}
}

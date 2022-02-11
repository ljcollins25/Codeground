using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class ContainerContentChangingEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Phase
	{
		get
		{
			throw new NotImplementedException("The member uint ContainerContentChangingEventArgs.Phase is not implemented in Uno.");
		}
	}

	public bool Handled { get; set; }

	public bool InRecycleQueue { get; }

	public object Item { get; }

	public SelectorItem ItemContainer { get; }

	public int ItemIndex { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RegisterUpdateCallback(TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> callback)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs", "void ContainerContentChangingEventArgs.RegisterUpdateCallback(TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> callback)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RegisterUpdateCallback(uint callbackPhase, TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> callback)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs", "void ContainerContentChangingEventArgs.RegisterUpdateCallback(uint callbackPhase, TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> callback)");
	}

	public ContainerContentChangingEventArgs()
	{
	}

	internal ContainerContentChangingEventArgs(object item, SelectorItem itemContainer, int itemIndex)
	{
		Item = item;
		ItemContainer = itemContainer;
		ItemIndex = itemIndex;
	}
}

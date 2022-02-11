using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class ItemContainerGenerator
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event ItemsChangedEventHandler ItemsChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "event ItemsChangedEventHandler ItemContainerGenerator.ItemsChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "event ItemsChangedEventHandler ItemContainerGenerator.ItemsChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object ItemFromContainer(DependencyObject container)
	{
		throw new NotImplementedException("The member object ItemContainerGenerator.ItemFromContainer(DependencyObject container) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject ContainerFromItem(object item)
	{
		throw new NotImplementedException("The member DependencyObject ItemContainerGenerator.ContainerFromItem(object item) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int IndexFromContainer(DependencyObject container)
	{
		throw new NotImplementedException("The member int ItemContainerGenerator.IndexFromContainer(DependencyObject container) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject ContainerFromIndex(int index)
	{
		throw new NotImplementedException("The member DependencyObject ItemContainerGenerator.ContainerFromIndex(int index) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemContainerGenerator GetItemContainerGeneratorForPanel(Panel panel)
	{
		throw new NotImplementedException("The member ItemContainerGenerator ItemContainerGenerator.GetItemContainerGeneratorForPanel(Panel panel) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void StartAt(GeneratorPosition position, GeneratorDirection direction, bool allowStartAtRealizedItem)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "void ItemContainerGenerator.StartAt(GeneratorPosition position, GeneratorDirection direction, bool allowStartAtRealizedItem)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Stop()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "void ItemContainerGenerator.Stop()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject GenerateNext(out bool isNewlyRealized)
	{
		throw new NotImplementedException("The member DependencyObject ItemContainerGenerator.GenerateNext(out bool isNewlyRealized) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PrepareItemContainer(DependencyObject container)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "void ItemContainerGenerator.PrepareItemContainer(DependencyObject container)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RemoveAll()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "void ItemContainerGenerator.RemoveAll()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Remove(GeneratorPosition position, int count)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "void ItemContainerGenerator.Remove(GeneratorPosition position, int count)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public GeneratorPosition GeneratorPositionFromIndex(int itemIndex)
	{
		throw new NotImplementedException("The member GeneratorPosition ItemContainerGenerator.GeneratorPositionFromIndex(int itemIndex) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int IndexFromGeneratorPosition(GeneratorPosition position)
	{
		throw new NotImplementedException("The member int ItemContainerGenerator.IndexFromGeneratorPosition(GeneratorPosition position) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Recycle(GeneratorPosition position, int count)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemContainerGenerator", "void ItemContainerGenerator.Recycle(GeneratorPosition position, int count)");
	}
}

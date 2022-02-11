using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

public class DataTemplateSelector : IElementFactory
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement GetElement(ElementFactoryGetArgs args)
	{
		throw new NotImplementedException("The member UIElement DataTemplateSelector.GetElement(ElementFactoryGetArgs args) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RecycleElement(ElementFactoryRecycleArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.DataTemplateSelector", "void DataTemplateSelector.RecycleElement(ElementFactoryRecycleArgs args)");
	}

	public DataTemplateSelector()
	{
		Initialize();
	}

	private void Initialize()
	{
	}

	public DataTemplate SelectTemplate(object item)
	{
		return SelectTemplateCore(item);
	}

	public DataTemplate SelectTemplate(object item, DependencyObject container)
	{
		return SelectTemplateCore(item, container);
	}

	protected virtual DataTemplate SelectTemplateCore(object item)
	{
		return null;
	}

	protected virtual DataTemplate SelectTemplateCore(object item, DependencyObject container)
	{
		return null;
	}
}

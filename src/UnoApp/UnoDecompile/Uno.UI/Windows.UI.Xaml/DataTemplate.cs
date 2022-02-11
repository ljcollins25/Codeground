using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml;

public class DataTemplate : FrameworkTemplate, IElementFactory
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ExtensionInstanceProperty { get; } = DependencyProperty.RegisterAttached("ExtensionInstance", typeof(IDataTemplateExtension), typeof(DataTemplate), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement GetElement(ElementFactoryGetArgs args)
	{
		throw new NotImplementedException("The member UIElement DataTemplate.GetElement(ElementFactoryGetArgs args) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RecycleElement(ElementFactoryRecycleArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.DataTemplate", "void DataTemplate.RecycleElement(ElementFactoryRecycleArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IDataTemplateExtension GetExtensionInstance(FrameworkElement element)
	{
		return (IDataTemplateExtension)element.GetValue(ExtensionInstanceProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetExtensionInstance(FrameworkElement element, IDataTemplateExtension value)
	{
		element.SetValue(ExtensionInstanceProperty, value);
	}

	public DataTemplate()
		: base(null)
	{
	}

	public DataTemplate(Func<UIElement?>? factory)
		: base(factory)
	{
	}

	public DataTemplate(object? owner, FrameworkTemplateBuilder? factory)
		: base(owner, factory)
	{
	}

	public static implicit operator DataTemplate?(Func<UIElement?>? obj)
	{
		if (obj == null)
		{
			return null;
		}
		return new DataTemplate(obj);
	}
}

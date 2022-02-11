using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

internal class RadioButtonsElementFactory : ElementFactory
{
	private IElementFactoryShim m_itemTemplateWrapper;

	internal void UserElementFactory(object newValue)
	{
		m_itemTemplateWrapper = newValue as IElementFactoryShim;
		if (m_itemTemplateWrapper == null && newValue is DataTemplate dataTemplate)
		{
			m_itemTemplateWrapper = new ItemTemplateWrapper(dataTemplate);
		}
	}

	protected override UIElement GetElementCore(ElementFactoryGetArgs args)
	{
		object obj = GetContent(m_itemTemplateWrapper);
		if (obj is RadioButton result)
		{
			return result;
		}
		RadioButton radioButton = new RadioButton();
		radioButton.Content = args.Data;
		if (m_itemTemplateWrapper is ItemTemplateWrapper itemTemplateWrapper2)
		{
			radioButton.ContentTemplate = itemTemplateWrapper2.Template;
		}
		return radioButton;
		object GetContent(IElementFactoryShim itemTemplateWrapper)
		{
			if (itemTemplateWrapper != null)
			{
				return itemTemplateWrapper.GetElement(args);
			}
			return args.Data;
		}
	}

	protected override void RecycleElementCore(ElementFactoryRecycleArgs args)
	{
	}
}

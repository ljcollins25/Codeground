using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Microsoft.UI.Xaml.Controls;

internal class ItemTemplateWrapper : IElementFactoryShim
{
	private DataTemplate m_dataTemplate;

	private DataTemplateSelector m_dataTemplateSelector;

	internal DataTemplate Template
	{
		get
		{
			return m_dataTemplate;
		}
		set
		{
			m_dataTemplate = value;
		}
	}

	internal DataTemplateSelector TemplateSelector
	{
		get
		{
			return m_dataTemplateSelector;
		}
		set
		{
			m_dataTemplateSelector = value;
		}
	}

	public ItemTemplateWrapper(DataTemplate dataTemplate)
	{
		m_dataTemplate = dataTemplate;
	}

	public ItemTemplateWrapper(DataTemplateSelector dataTemplateSelector)
	{
		m_dataTemplateSelector = dataTemplateSelector;
	}

	public UIElement GetElement(ElementFactoryGetArgs args)
	{
		DataTemplate dataTemplate = m_dataTemplate ?? m_dataTemplateSelector.SelectTemplate(args.Data);
		if (dataTemplate == null)
		{
			try
			{
				dataTemplate = m_dataTemplateSelector.SelectTemplate(args.Data, null);
			}
			catch (ArgumentException)
			{
			}
			if (dataTemplate == null)
			{
				throw new ArgumentException("Null encountered as data template. That is not a valid value for a data template, and can not be used.");
			}
		}
		RecyclePool poolInstance = RecyclePool.GetPoolInstance(dataTemplate);
		UIElement uIElement = null;
		if (poolInstance != null)
		{
			uIElement = poolInstance.TryGetElement("", args.Parent as FrameworkElement);
		}
		if (uIElement == null)
		{
			uIElement = dataTemplate.LoadContent() as FrameworkElement;
			if (uIElement == null)
			{
				Rectangle rectangle = new Rectangle();
				rectangle.Width = 0.0;
				rectangle.Height = 0.0;
				uIElement = rectangle;
			}
			uIElement.SetValue(RecyclePool.OriginTemplateProperty, dataTemplate);
		}
		return uIElement;
	}

	public void RecycleElement(ElementFactoryRecycleArgs args)
	{
		UIElement element = args.Element;
		DataTemplate dataTemplate = m_dataTemplate ?? (element.GetValue(RecyclePool.OriginTemplateProperty) as DataTemplate);
		RecyclePool recyclePool = RecyclePool.GetPoolInstance(dataTemplate);
		if (recyclePool == null)
		{
			recyclePool = new RecyclePool();
			RecyclePool.SetPoolInstance(dataTemplate, recyclePool);
		}
		recyclePool.PutElement(args.Element, "", args.Parent);
	}
}

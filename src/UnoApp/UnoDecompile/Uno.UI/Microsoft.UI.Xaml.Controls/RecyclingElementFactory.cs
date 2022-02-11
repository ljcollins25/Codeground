using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Controls;

[ContentProperty(Name = "Templates")]
public class RecyclingElementFactory : ElementFactory
{
	private RecyclePool m_recyclePool;

	private IDictionary<string, DataTemplate> m_templates = new Dictionary<string, DataTemplate>();

	private SelectTemplateEventArgs m_args;

	public RecyclePool RecyclePool
	{
		get
		{
			return m_recyclePool;
		}
		set
		{
			m_recyclePool = value;
		}
	}

	public IDictionary<string, DataTemplate> Templates
	{
		get
		{
			return m_templates;
		}
		set
		{
			m_templates = value;
		}
	}

	public event TypedEventHandler<RecyclingElementFactory, SelectTemplateEventArgs> SelectTemplateKey;

	protected virtual string OnSelectTemplateKeyCore(object dataContext, UIElement owner)
	{
		if (m_args == null)
		{
			m_args = new SelectTemplateEventArgs();
		}
		SelectTemplateEventArgs args = m_args;
		args.TemplateKey = null;
		args.DataContext = dataContext;
		args.Owner = owner;
		this.SelectTemplateKey?.Invoke(this, args);
		string templateKey = args.TemplateKey;
		if (string.IsNullOrEmpty(templateKey))
		{
			throw new InvalidOperationException("Please provide a valid template identifier in the handler for the SelectTemplateKey event.");
		}
		return templateKey;
	}

	protected override UIElement GetElementCore(ElementFactoryGetArgs args)
	{
		if (m_templates == null || m_templates.Count == 0)
		{
			throw new InvalidOperationException("Templates property cannot be null or empty.");
		}
		UIElement parent = args.Parent;
		string text = ((m_templates.Count == 1) ? m_templates.First().Key : OnSelectTemplateKeyCore(args.Data, parent));
		if (string.IsNullOrEmpty(text))
		{
			throw new InvalidOperationException("Template key cannot be empty or null.");
		}
		FrameworkElement frameworkElement = m_recyclePool.TryGetElement(text, parent) as FrameworkElement;
		if (frameworkElement == null)
		{
			if (m_templates.Count > 1 && !m_templates.ContainsKey(text))
			{
				string message = "No templates of key " + text + " were found in the templates collection.";
				throw new InvalidOperationException(message);
			}
			DataTemplate dataTemplate = m_templates[text];
			frameworkElement = dataTemplate.LoadContent() as FrameworkElement;
			RecyclePool.SetReuseKey(frameworkElement, text);
		}
		return frameworkElement;
	}

	protected override void RecycleElementCore(ElementFactoryRecycleArgs args)
	{
		UIElement element = args.Element;
		string reuseKey = RecyclePool.GetReuseKey(element);
		m_recyclePool.PutElement(element, reuseKey, args.Parent);
	}
}

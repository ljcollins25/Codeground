using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class RecyclePool
{
	private struct ElementInfo
	{
		public UIElement Element { get; }

		public IPanel Owner { get; }

		public ElementInfo(UIElement element, IPanel owner)
		{
			Element = element;
			Owner = owner;
		}
	}

	private readonly Dictionary<string, List<ElementInfo>> m_elements = new Dictionary<string, List<ElementInfo>>();

	public static DependencyProperty PoolInstanceProperty { get; } = DependencyProperty.RegisterAttached("PoolInstance", typeof(RecyclePool), typeof(RecyclePool), new FrameworkPropertyMetadata((object)null));


	internal static DependencyProperty ReuseKeyProperty { get; } = DependencyProperty.RegisterAttached("ReuseKey", typeof(string), typeof(RecyclePool), new FrameworkPropertyMetadata((object)"", (PropertyChangedCallback)null));


	internal static DependencyProperty OriginTemplateProperty { get; } = DependencyProperty.RegisterAttached("OriginTemplate", typeof(DataTemplate), typeof(RecyclePool), new FrameworkPropertyMetadata(null, null));


	public void PutElement(UIElement element, string key)
	{
		PutElementCore(element, key, null);
	}

	public void PutElement(UIElement element, string key, UIElement owner)
	{
		PutElementCore(element, key, owner);
	}

	public UIElement TryGetElement(string key)
	{
		return TryGetElementCore(key, null);
	}

	public UIElement TryGetElement(string key, UIElement owner)
	{
		return TryGetElementCore(key, owner);
	}

	protected virtual void PutElementCore(UIElement element, string key, UIElement owner)
	{
		IPanel owner2 = EnsureOwnerIsPanelOrNull(owner);
		ElementInfo item = new ElementInfo(element, owner2);
		if (m_elements.TryGetValue(key, out var value))
		{
			value.Add(item);
			return;
		}
		List<ElementInfo> list = new List<ElementInfo>();
		list.Add(item);
		m_elements[key] = list;
	}

	protected virtual UIElement TryGetElementCore(string key, UIElement owner)
	{
		if (m_elements.TryGetValue(key, out var value) && value.Count > 0)
		{
			ElementInfo elementInfo = default(ElementInfo);
			UIElement winrtOwner = owner;
			int num = value.FindIndex((ElementInfo elemInfo) => elemInfo.Owner == winrtOwner || elemInfo.Owner == null);
			if (num < 0)
			{
				num = value.Count - 1;
			}
			elementInfo = value[num];
			value.RemoveAt(num);
			IPanel panel = EnsureOwnerIsPanelOrNull(winrtOwner);
			if (elementInfo.Owner != null && elementInfo.Owner != panel)
			{
				IPanel owner2 = elementInfo.Owner;
				if (owner2 != null)
				{
					int num2 = owner2.Children.IndexOf(elementInfo.Element);
					if (num2 < 0)
					{
						throw new InvalidOperationException("ItemsRepeater's child not found in its Children collection.");
					}
					owner2.Children.RemoveAt(num2);
				}
			}
			return elementInfo.Element;
		}
		return null;
	}

	private IPanel EnsureOwnerIsPanelOrNull(UIElement owner)
	{
		IPanel panel = null;
		if (owner != null)
		{
			panel = owner as IPanel;
			if (panel == null)
			{
				throw new InvalidOperationException("owner must to be a Panel or null.");
			}
		}
		return panel;
	}

	public static RecyclePool GetPoolInstance(DataTemplate dataTemplate)
	{
		return (RecyclePool)dataTemplate.GetValue(PoolInstanceProperty);
	}

	public static void SetPoolInstance(DataTemplate dataTemplate, RecyclePool value)
	{
		dataTemplate.SetValue(PoolInstanceProperty, value);
	}

	internal static string GetReuseKey(UIElement element)
	{
		return (string)element.GetValue(ReuseKeyProperty);
	}

	internal static void SetReuseKey(UIElement element, string value)
	{
		element.SetValue(ReuseKeyProperty, value);
	}
}

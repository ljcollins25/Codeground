using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class UniqueIdElementPool : IEnumerable<KeyValuePair<string, UIElement>>, IEnumerable
{
	private Dictionary<string, UIElement> m_elementMap = new Dictionary<string, UIElement>();

	private readonly ItemsRepeater m_owner;

	public UniqueIdElementPool(ItemsRepeater owner)
	{
		m_owner = owner;
	}

	public void Add(UIElement element)
	{
		VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(element);
		string uniqueId = virtualizationInfo.UniqueId;
		if (m_elementMap.ContainsKey(uniqueId))
		{
			throw new InvalidOperationException("The unique id provided (" + virtualizationInfo.UniqueId + ") is not unique.");
		}
		m_elementMap.Add(uniqueId, element);
	}

	public UIElement Remove(int index)
	{
		UIElement value = null;
		string key = m_owner.ItemsSourceView.KeyFromIndex(index);
		if (m_elementMap.TryGetValue(key, out value))
		{
			m_elementMap.Remove(key);
		}
		return value;
	}

	public void Clear()
	{
		m_elementMap.Clear();
	}

	public IEnumerator<KeyValuePair<string, UIElement>> GetEnumerator()
	{
		return m_elementMap.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

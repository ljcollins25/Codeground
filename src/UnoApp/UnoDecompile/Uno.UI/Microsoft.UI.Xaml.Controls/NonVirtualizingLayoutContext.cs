using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class NonVirtualizingLayoutContext : LayoutContext
{
	private LayoutContextAdapter m_contextAdapter;

	public IReadOnlyList<UIElement> Children => ChildrenCore;

	public virtual IReadOnlyList<UIElement> ChildrenCore
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	internal VirtualizingLayoutContext GetVirtualizingContextAdapter()
	{
		if (m_contextAdapter == null)
		{
			m_contextAdapter = new LayoutContextAdapter(this);
		}
		return m_contextAdapter;
	}
}

using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class LayoutPanelLayoutContext : NonVirtualizingLayoutContext
{
	private LayoutPanel m_owner;

	public override IReadOnlyList<UIElement> ChildrenCore => m_owner.Children.ToArray();

	protected internal override object LayoutStateCore
	{
		get
		{
			return m_owner.LayoutState;
		}
		set
		{
			m_owner.LayoutState = value;
		}
	}

	internal LayoutPanelLayoutContext(LayoutPanel owner)
	{
		m_owner = owner;
	}
}

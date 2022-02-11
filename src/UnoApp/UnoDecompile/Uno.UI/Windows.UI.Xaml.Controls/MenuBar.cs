using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Items")]
public class MenuBar : Control
{
	private Grid m_layoutRoot;

	private ItemsControl m_contentRoot;

	public IList<MenuBarItem> Items
	{
		get
		{
			return (IList<MenuBarItem>)GetValue(ItemsProperty);
		}
		private set
		{
			SetValue(ItemsProperty, value);
		}
	}

	public static DependencyProperty ItemsProperty { get; } = DependencyProperty.Register("Items", typeof(IList<MenuBarItem>), typeof(MenuBar), new FrameworkPropertyMetadata(null));


	internal bool IsFlyoutOpen { get; set; }

	public MenuBar()
	{
		Items = new ObservableCollection<MenuBarItem>();
		base.DefaultStyleKey = typeof(MenuBar);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		m_layoutRoot = GetTemplateChild("LayoutRoot") as Grid;
		if (GetTemplateChild("ContentRoot") is ItemsControl itemsControl)
		{
			itemsControl.XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled;
			itemsControl.ItemsSource = Items;
			m_contentRoot = itemsControl;
		}
	}
}

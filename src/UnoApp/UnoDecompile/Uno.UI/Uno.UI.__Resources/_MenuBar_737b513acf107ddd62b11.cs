using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uno.UI.__Resources;

internal class _MenuBar_737b513acf107ddd62b115a6fa290d25_MenuBarRDSC0
{
	private class _MenuBar_737b513acf107ddd62b115a6fa290d25_UnoUI__Resources_MenuBar_737b513acf107ddd62b115a6fa290d25_MenuBarRDSC0MenuBarRDSC1
	{
		public UIElement Build(object __ResourceOwner_166)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new StackPanel
			{
				IsParsing = true,
				Orientation = Orientation.Horizontal
			}.MenuBar_737b513acf107ddd62b115a6fa290d25_XamlApply(delegate(StackPanel c2)
			{
				c2.CreationComplete();
			});
			DependencyObject dependencyObject = uIElement;
			if (dependencyObject != null)
			{
				NameScope.SetNameScope(dependencyObject, nameScope);
				nameScope.Owner = dependencyObject;
				FrameworkElementHelper.AddObjectReference(dependencyObject, this);
			}
			return uIElement;
		}
	}

	private ElementNameSubject _ContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ItemsControl ContentRoot
	{
		get
		{
			return (ItemsControl)_ContentRootSubject.ElementInstance;
		}
		set
		{
			_ContentRootSubject.ElementInstance = value;
		}
	}

	private Grid LayoutRoot
	{
		get
		{
			return (Grid)_LayoutRootSubject.ElementInstance;
		}
		set
		{
			_LayoutRootSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_161)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			HorizontalAlignment = HorizontalAlignment.Stretch,
			Children = { (UIElement)new ItemsControl
			{
				IsParsing = true,
				Name = "ContentRoot",
				VerticalAlignment = VerticalAlignment.Stretch,
				HorizontalAlignment = HorizontalAlignment.Left,
				IsTabStop = false,
				ItemsPanel = new ItemsPanelTemplate(__ResourceOwner_161, (object? __owner) => new _MenuBar_737b513acf107ddd62b115a6fa290d25_UnoUI__Resources_MenuBar_737b513acf107ddd62b115a6fa290d25_MenuBarRDSC0MenuBarRDSC1().Build(__owner))
			}.MenuBar_737b513acf107ddd62b115a6fa290d25_XamlApply(delegate(ItemsControl c0)
			{
				nameScope.RegisterName("ContentRoot", c0);
				ContentRoot = c0;
				c0.CreationComplete();
			}) }
		}.MenuBar_737b513acf107ddd62b115a6fa290d25_XamlApply(delegate(Grid c1)
		{
			nameScope.RegisterName("LayoutRoot", c1);
			LayoutRoot = c1;
			c1.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c1.CreationComplete();
		});
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}

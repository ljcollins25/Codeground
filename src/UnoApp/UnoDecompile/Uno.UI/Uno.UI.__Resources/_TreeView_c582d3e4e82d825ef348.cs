using Microsoft.UI.Xaml.Controls;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _TreeView_c582d3e4e82d825ef34875c57c83145b_TreeViewRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private TextBlock _component_0
	{
		get
		{
			return (TextBlock)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2564)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Height = 44.0,
			Children = { (UIElement)new TextBlock
			{
				IsParsing = true,
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Center
			}.TreeView_c582d3e4e82d825ef34875c57c83145b_XamlApply(delegate(TextBlock c1)
			{
				c1.SetBinding(TextBlock.TextProperty, new Binding
				{
					Path = "Content"
				});
				ResourceResolverSingleton.Instance.ApplyResource(c1, FrameworkElement.StyleProperty, "BodyTextBlockStyle", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__80.Instance.__ParseContext_);
				_component_0 = c1;
				c1.CreationComplete();
			}) }
		}.TreeView_c582d3e4e82d825ef34875c57c83145b_XamlApply(delegate(Grid c2)
		{
			c2.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
			};
		}
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
internal class _TreeView_c582d3e4e82d825ef34875c57c83145b_TreeViewRDSC1
{
	private ElementNameSubject _ListControlSubject = new ElementNameSubject();

	private Microsoft.UI.Xaml.Controls.TreeViewList ListControl
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.TreeViewList)_ListControlSubject.ElementInstance;
		}
		set
		{
			_ListControlSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2565)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Microsoft.UI.Xaml.Controls.TreeViewList
		{
			IsParsing = true,
			Name = "ListControl"
		}.TreeView_c582d3e4e82d825ef34875c57c83145b_XamlApply(delegate(Microsoft.UI.Xaml.Controls.TreeViewList c3)
		{
			nameScope.RegisterName("ListControl", c3);
			ListControl = c3;
			c3.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ItemsControl.ItemTemplateProperty, new Binding
			{
				Path = "ItemTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ItemsControl.ItemTemplateSelectorProperty, new Binding
			{
				Path = "ItemTemplateSelector",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ItemsControl.ItemContainerStyleProperty, new Binding
			{
				Path = "ItemContainerStyle",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ItemsControl.ItemContainerStyleSelectorProperty, new Binding
			{
				Path = "ItemContainerStyleSelector",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ItemsControl.ItemContainerTransitionsProperty, new Binding
			{
				Path = "ItemContainerTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ListViewBase.CanDragItemsProperty, new Binding
			{
				Path = "CanDragItems",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(UIElement.AllowDropProperty, new Binding
			{
				Path = "AllowDrop",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ListViewBase.CanReorderItemsProperty, new Binding
			{
				Path = "CanReorderItems",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.CreationComplete();
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

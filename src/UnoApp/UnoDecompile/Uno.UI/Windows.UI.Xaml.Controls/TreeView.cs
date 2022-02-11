using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
[Obsolete("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.TreeView instead.")]
public class TreeView : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TreeViewSelectionMode SelectionMode
	{
		get
		{
			return (TreeViewSelectionMode)GetValue(SelectionModeProperty);
		}
		set
		{
			SetValue(SelectionModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<TreeViewNode> RootNodes
	{
		get
		{
			throw new NotImplementedException("The member IList<TreeViewNode> TreeView.RootNodes is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<TreeViewNode> SelectedNodes
	{
		get
		{
			throw new NotImplementedException("The member IList<TreeViewNode> TreeView.SelectedNodes is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object ItemsSource
	{
		get
		{
			return GetValue(ItemsSourceProperty);
		}
		set
		{
			SetValue(ItemsSourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataTemplateSelector ItemTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty);
		}
		set
		{
			SetValue(ItemTemplateSelectorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataTemplate ItemTemplate
	{
		get
		{
			return (DataTemplate)GetValue(ItemTemplateProperty);
		}
		set
		{
			SetValue(ItemTemplateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TransitionCollection ItemContainerTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(ItemContainerTransitionsProperty);
		}
		set
		{
			SetValue(ItemContainerTransitionsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public StyleSelector ItemContainerStyleSelector
	{
		get
		{
			return (StyleSelector)GetValue(ItemContainerStyleSelectorProperty);
		}
		set
		{
			SetValue(ItemContainerStyleSelectorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Style ItemContainerStyle
	{
		get
		{
			return (Style)GetValue(ItemContainerStyleProperty);
		}
		set
		{
			SetValue(ItemContainerStyleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanReorderItems
	{
		get
		{
			return (bool)GetValue(CanReorderItemsProperty);
		}
		set
		{
			SetValue(CanReorderItemsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanDragItems
	{
		get
		{
			return (bool)GetValue(CanDragItemsProperty);
		}
		set
		{
			SetValue(CanDragItemsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionModeProperty { get; } = DependencyProperty.Register("SelectionMode", typeof(TreeViewSelectionMode), typeof(TreeView), new FrameworkPropertyMetadata(TreeViewSelectionMode.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanDragItemsProperty { get; } = DependencyProperty.Register("CanDragItems", typeof(bool), typeof(TreeView), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanReorderItemsProperty { get; } = DependencyProperty.Register("CanReorderItems", typeof(bool), typeof(TreeView), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemContainerStyleProperty { get; } = DependencyProperty.Register("ItemContainerStyle", typeof(Style), typeof(TreeView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemContainerStyleSelectorProperty { get; } = DependencyProperty.Register("ItemContainerStyleSelector", typeof(StyleSelector), typeof(TreeView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemContainerTransitionsProperty { get; } = DependencyProperty.Register("ItemContainerTransitions", typeof(TransitionCollection), typeof(TreeView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemTemplateProperty { get; } = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(TreeView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemTemplateSelectorProperty { get; } = DependencyProperty.Register("ItemTemplateSelector", typeof(DataTemplateSelector), typeof(TreeView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(TreeView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TreeView, TreeViewCollapsedEventArgs> Collapsed
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewCollapsedEventArgs> TreeView.Collapsed");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewCollapsedEventArgs> TreeView.Collapsed");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TreeView, TreeViewExpandingEventArgs> Expanding
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewExpandingEventArgs> TreeView.Expanding");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewExpandingEventArgs> TreeView.Expanding");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TreeView, TreeViewItemInvokedEventArgs> ItemInvoked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewItemInvokedEventArgs> TreeView.ItemInvoked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewItemInvokedEventArgs> TreeView.ItemInvoked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TreeView, TreeViewDragItemsCompletedEventArgs> DragItemsCompleted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewDragItemsCompletedEventArgs> TreeView.DragItemsCompleted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewDragItemsCompletedEventArgs> TreeView.DragItemsCompleted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TreeView, TreeViewDragItemsStartingEventArgs> DragItemsStarting
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewDragItemsStartingEventArgs> TreeView.DragItemsStarting");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "event TypedEventHandler<TreeView, TreeViewDragItemsStartingEventArgs> TreeView.DragItemsStarting");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Expand(TreeViewNode value)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "void TreeView.Expand(TreeViewNode value)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Collapse(TreeViewNode value)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "void TreeView.Collapse(TreeViewNode value)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SelectAll()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeView", "void TreeView.SelectAll()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TreeViewNode NodeFromContainer(DependencyObject container)
	{
		throw new NotImplementedException("The member TreeViewNode TreeView.NodeFromContainer(DependencyObject container) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject ContainerFromNode(TreeViewNode node)
	{
		throw new NotImplementedException("The member DependencyObject TreeView.ContainerFromNode(TreeViewNode node) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object ItemFromContainer(DependencyObject container)
	{
		throw new NotImplementedException("The member object TreeView.ItemFromContainer(DependencyObject container) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject ContainerFromItem(object item)
	{
		throw new NotImplementedException("The member DependencyObject TreeView.ContainerFromItem(object item) is not implemented in Uno.");
	}

	public TreeView()
	{
		throw new NotImplementedException("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.TreeView instead.");
	}
}

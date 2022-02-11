using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Microsoft.UI.Xaml.Controls;

public class TreeView : Control
{
	private const string c_listControlName = "ListControl";

	private TreeViewList m_listControl;

	private TreeViewNode m_rootNode;

	private IList<TreeViewNode> m_pendingSelectedNodes;

	public IList<TreeViewNode> RootNodes => m_rootNode.Children;

	internal TreeViewList ListControl => m_listControl;

	internal TreeViewList MutableListControl => m_listControl;

	public TreeViewNode SelectedNode
	{
		get
		{
			if (SelectedNodes.Count <= 0)
			{
				return null;
			}
			return SelectedNodes[0];
		}
		set
		{
			if (SelectedNodes.Count > 0)
			{
				SelectedNodes.Clear();
			}
			if (value != null)
			{
				SelectedNodes.Add(value);
			}
		}
	}

	public IList<TreeViewNode> SelectedNodes => ListControl?.ListViewModel?.SelectedNodes ?? m_pendingSelectedNodes;

	public IList<object> SelectedItems => ListControl?.ListViewModel?.SelectedItems;

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

	public object SelectedItem
	{
		get
		{
			return GetValue(SelectedItemProperty);
		}
		set
		{
			SetValue(SelectedItemProperty, value);
		}
	}

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

	public static DependencyProperty CanDragItemsProperty { get; } = DependencyProperty.Register("CanDragItems", typeof(bool), typeof(TreeView), new FrameworkPropertyMetadata(true));


	public static DependencyProperty CanReorderItemsProperty { get; } = DependencyProperty.Register("CanReorderItems", typeof(bool), typeof(TreeView), new FrameworkPropertyMetadata(true));


	public static DependencyProperty ItemContainerStyleProperty { get; } = DependencyProperty.Register("ItemContainerStyle", typeof(Style), typeof(TreeView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty ItemContainerStyleSelectorProperty { get; } = DependencyProperty.Register("ItemContainerStyleSelector", typeof(StyleSelector), typeof(TreeView), new FrameworkPropertyMetadata(null));


	public static DependencyProperty ItemContainerTransitionsProperty { get; } = DependencyProperty.Register("ItemContainerTransitions", typeof(TransitionCollection), typeof(TreeView), new FrameworkPropertyMetadata(null));


	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(TreeView), new FrameworkPropertyMetadata(null, OnItemsSourcePropertyChanged));


	public static DependencyProperty ItemTemplateProperty { get; } = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(TreeView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty ItemTemplateSelectorProperty { get; } = DependencyProperty.Register("ItemTemplateSelector", typeof(DataTemplateSelector), typeof(TreeView), new FrameworkPropertyMetadata(null));


	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(TreeView), new FrameworkPropertyMetadata(null, OnSelectedItemPropertyChanged));


	public static DependencyProperty SelectionModeProperty { get; } = DependencyProperty.Register("SelectionMode", typeof(TreeViewSelectionMode), typeof(TreeView), new FrameworkPropertyMetadata(TreeViewSelectionMode.Single, OnSelectionModePropertyChanged));


	public event TypedEventHandler<TreeView, TreeViewCollapsedEventArgs> Collapsed;

	public event TypedEventHandler<TreeView, TreeViewDragItemsCompletedEventArgs> DragItemsCompleted;

	public event TypedEventHandler<TreeView, TreeViewDragItemsStartingEventArgs> DragItemsStarting;

	public event TypedEventHandler<TreeView, TreeViewExpandingEventArgs> Expanding;

	public event TypedEventHandler<TreeView, TreeViewItemInvokedEventArgs> ItemInvoked;

	public event TypedEventHandler<TreeView, TreeViewSelectionChangedEventArgs> SelectionChanged;

	private event TypedEventHandler<TreeView, ContainerContentChangingEventArgs> ContainerContentChanged;

	public TreeView()
	{
		base.DefaultStyleKey = typeof(TreeView);
		m_rootNode = new TreeViewNode();
		m_pendingSelectedNodes = new List<TreeViewNode>();
	}

	public object ItemFromContainer(DependencyObject container)
	{
		return ListControl?.ItemFromContainer(container);
	}

	public DependencyObject ContainerFromItem(object item)
	{
		return ListControl?.ContainerFromItem(item);
	}

	public TreeViewNode NodeFromContainer(DependencyObject container)
	{
		return ListControl?.NodeFromContainer(container);
	}

	public DependencyObject ContainerFromNode(TreeViewNode node)
	{
		return ListControl?.ContainerFromNode(node);
	}

	internal void UpdateSelection(TreeViewNode node, bool isSelected)
	{
		TreeViewViewModel treeViewViewModel = ListControl?.ListViewModel;
		if (treeViewViewModel != null && isSelected != treeViewViewModel.IsNodeSelected(node))
		{
			treeViewViewModel.SelectNode(node, isSelected);
		}
	}

	public void Expand(TreeViewNode node)
	{
		TreeViewViewModel listViewModel = ListControl.ListViewModel;
		listViewModel.ExpandNode(node);
	}

	public void Collapse(TreeViewNode node)
	{
		TreeViewViewModel listViewModel = ListControl.ListViewModel;
		listViewModel.CollapseNode(node);
	}

	public void SelectAll()
	{
		TreeViewViewModel listViewModel = ListControl.ListViewModel;
		listViewModel.SelectAll();
	}

	private void OnItemClick(object sender, ItemClickEventArgs args)
	{
		TreeViewItemInvokedEventArgs args2 = new TreeViewItemInvokedEventArgs(args.ClickedItem);
		this.ItemInvoked?.Invoke(this, args2);
	}

	private void OnContainerContentChanging(object sender, ContainerContentChangingEventArgs args)
	{
		this.ContainerContentChanged?.Invoke((TreeView)sender, args);
	}

	private void OnNodeExpanding(TreeViewNode sender, object args)
	{
		TreeViewExpandingEventArgs args2 = new TreeViewExpandingEventArgs(sender);
		if (ListControl == null)
		{
			return;
		}
		if (ContainerFromNode(sender) is TreeViewItem treeViewItem)
		{
			if (!treeViewItem.IsExpanded)
			{
				treeViewItem.IsExpanded = true;
			}
			TreeViewItemTemplateSettings treeViewItemTemplateSettings = treeViewItem.TreeViewItemTemplateSettings;
			treeViewItemTemplateSettings.ExpandedGlyphVisibility = Visibility.Visible;
			treeViewItemTemplateSettings.CollapsedGlyphVisibility = Visibility.Collapsed;
		}
		this.Expanding?.Invoke(this, args2);
	}

	private void OnNodeCollapsed(TreeViewNode sender, object args)
	{
		TreeViewCollapsedEventArgs args2 = new TreeViewCollapsedEventArgs(sender);
		if (ListControl == null)
		{
			return;
		}
		if (ContainerFromNode(sender) is TreeViewItem treeViewItem)
		{
			if (treeViewItem.IsExpanded)
			{
				treeViewItem.IsExpanded = false;
			}
			TreeViewItemTemplateSettings treeViewItemTemplateSettings = treeViewItem.TreeViewItemTemplateSettings;
			treeViewItemTemplateSettings.ExpandedGlyphVisibility = Visibility.Collapsed;
			treeViewItemTemplateSettings.CollapsedGlyphVisibility = Visibility.Visible;
		}
		this.Collapsed?.Invoke(this, args2);
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == SelectionModeProperty && ListControl != null)
		{
			switch (SelectionMode)
			{
			case TreeViewSelectionMode.None:
				ListControl.SelectionMode = ListViewSelectionMode.None;
				UpdateItemsSelectionMode(isMultiSelect: false);
				break;
			case TreeViewSelectionMode.Single:
				ListControl.SelectionMode = ListViewSelectionMode.Single;
				UpdateItemsSelectionMode(isMultiSelect: false);
				break;
			case TreeViewSelectionMode.Multiple:
				ListControl.SelectionMode = ListViewSelectionMode.None;
				UpdateItemsSelectionMode(isMultiSelect: true);
				break;
			}
		}
		else if (property == ItemsSourceProperty)
		{
			m_rootNode.IsContentMode = true;
			if (ListControl != null)
			{
				TreeViewViewModel listViewModel = ListControl.ListViewModel;
				listViewModel.IsContentMode = true;
			}
			m_rootNode.ItemsSource = ItemsSource;
		}
		else if (property == SelectedItemProperty)
		{
			IList<object> selectedItems = SelectedItems;
			object obj = ((selectedItems != null && selectedItems.Count > 0) ? selectedItems[0] : null);
			if (args.NewValue != obj)
			{
				ListControl?.ListViewModel?.SelectSingleItem(args.NewValue);
			}
		}
	}

	private void OnListControlDragItemsStarting(object sender, DragItemsStartingEventArgs args)
	{
		TreeViewDragItemsStartingEventArgs args2 = new TreeViewDragItemsStartingEventArgs(args);
		this.DragItemsStarting?.Invoke(this, args2);
	}

	private void OnListControlDragItemsCompleted(object sender, DragItemsCompletedEventArgs args)
	{
		object newParentItem = CreateNewParent(args.Items, ListControl, m_rootNode);
		TreeViewDragItemsCompletedEventArgs args2 = new TreeViewDragItemsCompletedEventArgs(args, newParentItem);
		this.DragItemsCompleted?.Invoke(this, args2);
		object CreateNewParent(IReadOnlyList<object> items, TreeViewList listControl, TreeViewNode rootNode)
		{
			if (listControl != null && items != null && items.Count > 0)
			{
				TreeViewNode treeViewNode = listControl.NodeFromItem(items[0]);
				if (treeViewNode != null)
				{
					TreeViewNode parent = treeViewNode.Parent;
					if (parent != null && parent != rootNode)
					{
						return ListControl.ItemFromNode(parent);
					}
				}
			}
			return null;
		}
	}

	private void OnListControlSelectionChanged(object sender, SelectionChangedEventArgs args)
	{
		if (SelectionMode == TreeViewSelectionMode.Single)
		{
			RaiseSelectionChanged(args.AddedItems, args.RemovedItems);
			object obj = GetNewSelectedItem(args);
			if (SelectedItem != obj)
			{
				SelectedItem = obj;
			}
		}
		static object GetNewSelectedItem(SelectionChangedEventArgs args)
		{
			IList<object> addedItems = args.AddedItems;
			if (addedItems != null)
			{
				if (addedItems.Count > 0)
				{
					return addedItems[0];
				}
				return null;
			}
			return null;
		}
	}

	private void UpdateItemsSelectionMode(bool isMultiSelect)
	{
		TreeViewList listControl = ListControl;
		if (listControl.IsMultiselect != isMultiSelect)
		{
			listControl.EnableMultiselect(isMultiSelect);
		}
		TreeViewViewModel listViewModel = listControl.ListViewModel;
		int count = listViewModel.Count;
		for (int i = 0; i < count; i++)
		{
			if (!(listControl.ContainerFromIndex(i) is TreeViewItem control))
			{
				continue;
			}
			if (isMultiSelect)
			{
				TreeViewNode nodeAt = listViewModel.GetNodeAt(i);
				if (nodeAt != null)
				{
					if (listViewModel.IsNodeSelected(nodeAt))
					{
						VisualStateManager.GoToState(control, "TreeViewMultiSelectEnabledSelected", useTransitions: false);
					}
					else
					{
						VisualStateManager.GoToState(control, "TreeViewMultiSelectEnabledUnselected", useTransitions: false);
					}
				}
			}
			else
			{
				VisualStateManager.GoToState(control, "TreeViewMultiSelectDisabled", useTransitions: false);
			}
		}
	}

	internal void RaiseSelectionChanged(IList<object> addedItems, IList<object> removedItems)
	{
		TreeViewSelectionChangedEventArgs args = new TreeViewSelectionChangedEventArgs(addedItems, removedItems);
		this.SelectionChanged?.Invoke(this, args);
	}

	protected override void OnApplyTemplate()
	{
		m_listControl = GetTemplateChild("ListControl") as TreeViewList;
		TreeViewList listControl = m_listControl;
		if (listControl == null)
		{
			return;
		}
		TreeViewList treeViewList = listControl;
		TreeViewViewModel listViewModel = treeViewList.ListViewModel;
		if (m_rootNode == null)
		{
			m_rootNode = new TreeViewNode();
		}
		if (ItemsSource != null)
		{
			listViewModel.IsContentMode = true;
		}
		listViewModel.PrepareView(m_rootNode);
		listViewModel.SetOwners(listControl, this);
		listViewModel.NodeExpanding += OnNodeExpanding;
		listViewModel.NodeCollapsed += OnNodeCollapsed;
		TreeViewSelectionMode selectionMode = SelectionMode;
		if (selectionMode == TreeViewSelectionMode.Single)
		{
			listControl.SelectionMode = ListViewSelectionMode.Single;
		}
		else
		{
			listControl.SelectionMode = ListViewSelectionMode.None;
			if (selectionMode == TreeViewSelectionMode.Multiple)
			{
				UpdateItemsSelectionMode(isMultiSelect: true);
			}
		}
		listControl.ItemClick += OnItemClick;
		listControl.ContainerContentChanging += OnContainerContentChanging;
		listControl.DragItemsStarting += new DragItemsStartingEventHandler(OnListControlDragItemsStarting);
		listControl.DragItemsCompleted += new TypedEventHandler<ListViewBase, DragItemsCompletedEventArgs>(OnListControlDragItemsCompleted);
		listControl.SelectionChanged += OnListControlSelectionChanged;
		if (m_pendingSelectedNodes == null || m_pendingSelectedNodes.Count <= 0)
		{
			return;
		}
		IList<TreeViewNode> selectedNodes = listViewModel.SelectedNodes;
		foreach (TreeViewNode pendingSelectedNode in m_pendingSelectedNodes)
		{
			selectedNodes.Add(pendingSelectedNode);
		}
		m_pendingSelectedNodes.Clear();
	}

	private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeView treeView = (TreeView)sender;
		treeView.OnPropertyChanged(args);
	}

	private static void OnSelectionModePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeView treeView = (TreeView)sender;
		treeView.OnPropertyChanged(args);
	}

	private static void OnSelectedItemPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeView treeView = (TreeView)sender;
		treeView.OnPropertyChanged(args);
	}
}

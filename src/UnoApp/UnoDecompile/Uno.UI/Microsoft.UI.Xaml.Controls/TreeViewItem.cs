using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Automation.Peers;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class TreeViewItem : ListViewItem
{
	private const long c_dragOverInterval = 10000000L;

	private const string c_multiSelectCheckBoxName = "MultiSelectCheckBox";

	private const string c_expandCollapseChevronName = "ExpandCollapseChevron";

	private bool m_expansionCycled;

	private CheckBox m_selectionBox;

	private DispatcherTimer m_expandContentTimer;

	private TreeView m_ancestorTreeView;

	private UIElement m_expandCollapseChevron;

	internal TreeView AncestorTreeView
	{
		get
		{
			if (m_ancestorTreeView == null)
			{
				m_ancestorTreeView = GetAncestorView<TreeView>();
			}
			if (m_ancestorTreeView == null && GetValue(ItemsControl.ItemsControlForItemContainerProperty) is WeakReference<ItemsControl> weakReference && weakReference.TryGetTarget(out var target))
			{
				TreeViewList treeViewList = target as TreeViewList;
				m_ancestorTreeView = treeViewList.AncestorTreeView;
			}
			return m_ancestorTreeView;
		}
	}

	internal bool IsSelectedInternal
	{
		get
		{
			bool result = base.IsSelected;
			TreeView ancestorTreeView = AncestorTreeView;
			if (ancestorTreeView != null)
			{
				TreeViewList listControl = ancestorTreeView.ListControl;
				if (listControl != null && listControl.IsMultiselect)
				{
					TreeNodeSelectionState treeNodeSelectionState = CheckBoxSelectionState(m_selectionBox);
					result = treeNodeSelectionState == TreeNodeSelectionState.Selected;
				}
			}
			return result;
		}
	}

	private TreeViewNode TreeNode => AncestorTreeView?.NodeFromContainer(this);

	private bool IsInContentMode => AncestorTreeView.ListControl.ListViewModel.IsContentMode;

	public string CollapsedGlyph
	{
		get
		{
			return (string)GetValue(CollapsedGlyphProperty);
		}
		set
		{
			SetValue(CollapsedGlyphProperty, value);
		}
	}

	public string ExpandedGlyph
	{
		get
		{
			return (string)GetValue(ExpandedGlyphProperty);
		}
		set
		{
			SetValue(ExpandedGlyphProperty, value);
		}
	}

	public Brush GlyphBrush
	{
		get
		{
			return (Brush)GetValue(GlyphBrushProperty);
		}
		set
		{
			SetValue(GlyphBrushProperty, value);
		}
	}

	public double GlyphOpacity
	{
		get
		{
			return (double)GetValue(GlyphOpacityProperty);
		}
		set
		{
			SetValue(GlyphOpacityProperty, value);
		}
	}

	public double GlyphSize
	{
		get
		{
			return (double)GetValue(GlyphSizeProperty);
		}
		set
		{
			SetValue(GlyphSizeProperty, value);
		}
	}

	public bool HasUnrealizedChildren
	{
		get
		{
			return (bool)GetValue(HasUnrealizedChildrenProperty);
		}
		set
		{
			SetValue(HasUnrealizedChildrenProperty, value);
		}
	}

	public bool IsExpanded
	{
		get
		{
			return (bool)GetValue(IsExpandedProperty);
		}
		set
		{
			SetValue(IsExpandedProperty, value);
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

	public TreeViewItemTemplateSettings TreeViewItemTemplateSettings
	{
		get
		{
			return (TreeViewItemTemplateSettings)GetValue(TreeViewItemTemplateSettingsProperty);
		}
		set
		{
			SetValue(TreeViewItemTemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty CollapsedGlyphProperty { get; } = DependencyProperty.Register("CollapsedGlyph", typeof(string), typeof(TreeViewItem), new FrameworkPropertyMetadata("\ue76c"));


	public static DependencyProperty ExpandedGlyphProperty { get; } = DependencyProperty.Register("ExpandedGlyph", typeof(string), typeof(TreeViewItem), new FrameworkPropertyMetadata("\ue70d"));


	public static DependencyProperty GlyphBrushProperty { get; } = DependencyProperty.Register("GlyphBrush", typeof(Brush), typeof(TreeViewItem), new FrameworkPropertyMetadata(null));


	public static DependencyProperty GlyphOpacityProperty { get; } = DependencyProperty.Register("GlyphOpacity", typeof(double), typeof(TreeViewItem), new FrameworkPropertyMetadata(1.0));


	public static DependencyProperty GlyphSizeProperty { get; } = DependencyProperty.Register("GlyphSize", typeof(double), typeof(TreeViewItem), new FrameworkPropertyMetadata(12.0));


	public static DependencyProperty HasUnrealizedChildrenProperty { get; } = DependencyProperty.Register("HasUnrealizedChildren", typeof(bool), typeof(TreeViewItem), new FrameworkPropertyMetadata(false, OnHasUnrealizedChildrenPropertyChanged));


	public static DependencyProperty IsExpandedProperty { get; } = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(TreeViewItem), new FrameworkPropertyMetadata(false, OnIsExpandedPropertyChanged));


	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(TreeViewItem), new FrameworkPropertyMetadata(null, OnItemsSourcePropertyChanged));


	public static DependencyProperty TreeViewItemTemplateSettingsProperty { get; } = DependencyProperty.Register("TreeViewItemTemplateSettings", typeof(TreeViewItemTemplateSettings), typeof(TreeViewItem), new FrameworkPropertyMetadata(null));


	public TreeViewItem()
	{
		base.DefaultStyleKey = typeof(TreeViewItem);
		SetValue(TreeViewItemTemplateSettingsProperty, new TreeViewItemTemplateSettings());
	}

	protected override void OnKeyDown(KeyRoutedEventArgs e)
	{
		TreeViewNode treeNode = TreeNode;
		if (treeNode != null)
		{
			TreeView ancestorTreeView = AncestorTreeView;
			VirtualKey key = e.Key;
			VirtualKey originalKey = e.OriginalKey;
			if (originalKey == VirtualKey.GamepadA && ancestorTreeView.ListControl.IsMultiselect)
			{
				HandleGamepadAInMultiselectMode(treeNode);
				e.Handled = true;
			}
			else if (IsInReorderMode(key))
			{
				HandleReorder(key);
				e.Handled = true;
			}
			else if (IsExpandCollapse(key))
			{
				if (HandleExpandCollapse(key))
				{
					e.Handled = true;
				}
			}
			else if (key == VirtualKey.Space && ancestorTreeView.ListControl.IsMultiselect)
			{
				CheckBox selectionBox = m_selectionBox;
				bool flag = CheckBoxSelectionState(selectionBox) == TreeNodeSelectionState.Selected;
				selectionBox.IsChecked = !flag;
				e.Handled = true;
			}
		}
		base.OnKeyDown(e);
	}

	protected override void OnDrop(DragEventArgs args)
	{
		if (!args.Handled && args.AcceptedOperation == DataPackageOperation.Move)
		{
			TreeView ancestorTreeView = AncestorTreeView;
			if (ancestorTreeView != null)
			{
				TreeViewList listControl = ancestorTreeView.ListControl;
				TreeViewNode draggedTreeViewNode = listControl.DraggedTreeViewNode;
				if (draggedTreeViewNode != null)
				{
					if (listControl.IsMutiSelectWithSelectedItems)
					{
						TreeViewNode treeViewNode = ancestorTreeView.NodeFromContainer(this);
						IList<TreeViewNode> rootsOfSelectedSubtrees = listControl.GetRootsOfSelectedSubtrees();
						foreach (TreeViewNode item in rootsOfSelectedSubtrees)
						{
							int index = listControl.FlatIndex(item);
							if (listControl.IsFlatIndexValid(index))
							{
								listControl.RemoveNodeFromParent(item);
								((TreeViewNodeVector)treeViewNode.Children).Append(item);
							}
						}
						args.Handled = true;
						ancestorTreeView.MutableListControl.OnDropInternal(args);
					}
					else
					{
						TreeViewNode treeViewNode2 = ancestorTreeView.NodeFromContainer(this);
						int index2 = draggedTreeViewNode.Parent.Children.IndexOf(draggedTreeViewNode);
						if (draggedTreeViewNode != treeViewNode2)
						{
							((TreeViewNodeVector)treeViewNode2.Parent.Children).RemoveAt(index2);
							((TreeViewNodeVector)treeViewNode2.Children).Append(draggedTreeViewNode);
							args.Handled = true;
							ancestorTreeView.MutableListControl.OnDropInternal(args);
						}
						else
						{
							args.AcceptedOperation = DataPackageOperation.None;
						}
					}
				}
			}
		}
		base.OnDrop(args);
	}

	protected override void OnDragOver(DragEventArgs args)
	{
		TreeView ancestorTreeView = AncestorTreeView;
		if (ancestorTreeView != null && !args.Handled)
		{
			TreeViewList listControl = ancestorTreeView.ListControl;
			TreeViewNode treeViewNode = ancestorTreeView.NodeFromContainer(this);
			TreeViewNode draggedTreeViewNode = listControl.DraggedTreeViewNode;
			if (draggedTreeViewNode != null && ancestorTreeView.CanReorderItems)
			{
				if (listControl.IsMutiSelectWithSelectedItems)
				{
					if (listControl.IsSelected(treeViewNode))
					{
						args.AcceptedOperation = DataPackageOperation.None;
						ancestorTreeView.MutableListControl.SetDraggedOverItem(null);
					}
					else
					{
						args.AcceptedOperation = DataPackageOperation.Move;
						ancestorTreeView.MutableListControl.SetDraggedOverItem(this);
					}
				}
				else
				{
					TreeViewNode parent = treeViewNode.Parent;
					while (parent != null && parent != draggedTreeViewNode)
					{
						parent = parent.Parent;
					}
					TreeViewList mutableListControl = ancestorTreeView.MutableListControl;
					if (parent != draggedTreeViewNode && draggedTreeViewNode != treeViewNode)
					{
						args.AcceptedOperation = DataPackageOperation.Move;
						mutableListControl.SetDraggedOverItem(this);
					}
					listControl.UpdateDropTargetDropEffect(forceUpdate: false, isLeaving: false, null);
				}
			}
		}
		base.OnDragOver(args);
	}

	protected override void OnDragEnter(DragEventArgs args)
	{
		args.AcceptedOperation = DataPackageOperation.None;
		args.DragUIOverride.IsGlyphVisible = true;
		TreeView ancestorTreeView = AncestorTreeView;
		if (ancestorTreeView != null && ancestorTreeView.CanReorderItems && !args.Handled)
		{
			TreeViewList listControl = ancestorTreeView.ListControl;
			TreeViewNode draggedTreeViewNode = listControl.DraggedTreeViewNode;
			if (draggedTreeViewNode != null)
			{
				TreeViewNode treeViewNode = ancestorTreeView.NodeFromContainer(this);
				TreeViewNode parent = treeViewNode.Parent;
				while (parent != null && parent != draggedTreeViewNode)
				{
					parent = parent.Parent;
				}
				if (parent != draggedTreeViewNode && draggedTreeViewNode != treeViewNode)
				{
					args.AcceptedOperation = DataPackageOperation.Move;
				}
				TreeViewNode treeNode = TreeNode;
				if (treeNode != draggedTreeViewNode && !treeViewNode.IsExpanded && treeViewNode.HasChildren)
				{
					if (m_expandContentTimer != null)
					{
						DispatcherTimer expandContentTimer = m_expandContentTimer;
						expandContentTimer.Stop();
						expandContentTimer.Start();
					}
					else
					{
						TimeSpan interval = new TimeSpan(10000000L);
						DispatcherTimer dispatcherTimer = (m_expandContentTimer = new DispatcherTimer());
						dispatcherTimer.Interval = interval;
						dispatcherTimer.Tick += OnExpandContentTimerTick;
						dispatcherTimer.Start();
					}
				}
			}
		}
		base.OnDragEnter(args);
	}

	protected override void OnDragLeave(DragEventArgs args)
	{
		if (!args.Handled)
		{
			TreeView ancestorTreeView = AncestorTreeView;
			if (ancestorTreeView != null)
			{
				TreeViewList listControl = ancestorTreeView.ListControl;
				listControl.SetDraggedOverItem(null);
			}
			if (m_expandContentTimer != null)
			{
				m_expandContentTimer.Stop();
			}
		}
		base.OnDragLeave(args);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new Microsoft.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		RecycleEvents();
		m_selectionBox = (CheckBox)GetTemplateChild("MultiSelectCheckBox");
		RegisterPropertyChangedCallback(SelectorItem.IsSelectedProperty, OnIsSelectedChanged);
		if (m_selectionBox != null)
		{
			m_selectionBox.Checked += new RoutedEventHandler(OnCheckToggle);
			m_selectionBox.Unchecked += new RoutedEventHandler(OnCheckToggle);
		}
		UIElement uIElement = (UIElement)GetTemplateChild("ExpandCollapseChevron");
		if (uIElement != null)
		{
			uIElement.PointerPressed += OnExpandCollapseChevronPointerPressed;
			m_expandCollapseChevron = uIElement;
		}
		TreeViewNode treeNode = TreeNode;
		if (treeNode != null && IsInContentMode)
		{
			UpdateNodeIsExpandedAsync(treeNode, IsExpanded);
			treeNode.HasUnrealizedChildren = HasUnrealizedChildren;
		}
		if (treeNode != null)
		{
			UpdateSelectionVisual(treeNode.SelectionState);
		}
		base.OnApplyTemplate();
	}

	private T GetAncestorView<T>() where T : class
	{
		DependencyObject dependencyObject = this;
		T val = null;
		while (dependencyObject != null && val == null)
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
			val = dependencyObject as T;
		}
		return val;
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		TreeViewNode treeNode = TreeNode;
		if (treeNode == null)
		{
			return;
		}
		if (property == IsExpandedProperty)
		{
			bool flag = (bool)args.NewValue;
			if (treeNode.IsExpanded != flag)
			{
				UpdateNodeIsExpandedAsync(treeNode, flag);
			}
			RaiseExpandCollapseAutomationEvent(flag);
		}
		else if (property == ItemsSourceProperty)
		{
			SetItemsSource(treeNode, args.NewValue);
		}
		else if (property == HasUnrealizedChildrenProperty)
		{
			bool hasUnrealizedChildren = (bool)args.NewValue;
			treeNode.HasUnrealizedChildren = hasUnrealizedChildren;
		}
	}

	internal void SetItemsSource(TreeViewNode node, object value)
	{
		node.ItemsSource = value;
		if (IsInContentMode)
		{
			bool flag = HasUnrealizedChildren || node.HasChildren;
			GlyphOpacity = (flag ? 1.0 : 0.0);
		}
	}

	private void OnExpandContentTimerTick(object sender, object args)
	{
		if (m_expandContentTimer != null)
		{
			m_expandContentTimer.Stop();
		}
		TreeViewNode treeNode = TreeNode;
		if (treeNode != null && !treeNode.IsExpanded)
		{
			treeNode.IsExpanded = true;
		}
	}

	private void RaiseExpandCollapseAutomationEvent(bool isExpanded)
	{
		if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			ExpandCollapseState newState = (isExpanded ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
			if (automationPeer != null)
			{
				Microsoft.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer treeViewItemAutomationPeer = (Microsoft.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer)automationPeer;
				treeViewItemAutomationPeer.RaiseExpandCollapseAutomationEvent(newState);
			}
		}
	}

	private bool IsInReorderMode(VirtualKey key)
	{
		CoreVirtualKeyStates keyState = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Control);
		bool flag = (keyState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
		CoreVirtualKeyStates keyState2 = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Menu);
		bool flag2 = (keyState2 & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
		CoreVirtualKeyStates keyState3 = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Shift);
		bool flag3 = (keyState3 & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
		bool flag4 = IsDirectionalKey(key);
		bool flag5 = false;
		TreeView ancestorTreeView = AncestorTreeView;
		if (AncestorTreeView != null)
		{
			flag5 = ancestorTreeView.CanReorderItems;
		}
		if (flag5 && flag4 && flag3 && flag2)
		{
			return !flag;
		}
		return false;
	}

	private void UpdateTreeViewItemVisualState(TreeNodeSelectionState state)
	{
		if (state == TreeNodeSelectionState.Selected)
		{
			VisualStateManager.GoToState(this, "TreeViewMultiSelectEnabledSelected", useTransitions: false);
		}
		else
		{
			VisualStateManager.GoToState(this, "TreeViewMultiSelectEnabledUnselected", useTransitions: false);
		}
	}

	private void OnCheckToggle(object sender, RoutedEventArgs args)
	{
		TreeView ancestorTreeView = AncestorTreeView;
		if (ancestorTreeView != null)
		{
			TreeViewList listControl = ancestorTreeView.ListControl;
			int index = listControl.IndexFromContainer(this);
			TreeNodeSelectionState treeNodeSelectionState = CheckBoxSelectionState((CheckBox)sender);
			listControl.ListViewModel.SelectByIndex(index, treeNodeSelectionState);
			UpdateTreeViewItemVisualState(treeNodeSelectionState);
			RaiseSelectionChangeEvents(treeNodeSelectionState == TreeNodeSelectionState.Selected);
		}
	}

	private void RaiseSelectionChangeEvents(bool isSelected)
	{
		AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
		if (automationPeer != null)
		{
			Microsoft.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer treeViewItemAutomationPeer = (Microsoft.UI.Xaml.Automation.Peers.TreeViewItemAutomationPeer)automationPeer;
			AutomationEvents eventId = (isSelected ? AutomationEvents.SelectionItemPatternOnElementAddedToSelection : AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection);
			treeViewItemAutomationPeer.RaiseAutomationEvent(eventId);
			AutomationProperty isSelectedProperty = SelectionItemPatternIdentifiers.IsSelectedProperty;
			treeViewItemAutomationPeer.RaisePropertyChangedEvent(isSelectedProperty, !isSelected, isSelected);
		}
	}

	internal void UpdateSelection(bool isSelected)
	{
		TreeView ancestorTreeView = AncestorTreeView;
		if (ancestorTreeView != null)
		{
			TreeViewNode treeNode = TreeNode;
			if (treeNode != null)
			{
				ancestorTreeView.UpdateSelection(treeNode, isSelected);
			}
		}
	}

	internal void UpdateSelectionVisual(TreeNodeSelectionState state)
	{
		TreeView ancestorTreeView = AncestorTreeView;
		if (ancestorTreeView == null)
		{
			return;
		}
		TreeViewList listControl = ancestorTreeView.ListControl;
		if (listControl.IsMultiselect)
		{
			UpdateMultipleSelection(state);
			return;
		}
		TreeViewNode treeNode = TreeNode;
		if (treeNode != null)
		{
			TreeViewViewModel listViewModel = listControl.ListViewModel;
			bool flag = listViewModel.IsNodeSelected(treeNode);
			if (flag != base.IsSelected)
			{
				base.IsSelected = flag;
			}
		}
	}

	private void OnIsSelectedChanged(DependencyObject sender, DependencyProperty args)
	{
		UpdateSelection((bool)GetValue(args));
	}

	private void UpdateMultipleSelection(TreeNodeSelectionState state)
	{
		if (m_selectionBox != null)
		{
			switch (state)
			{
			case TreeNodeSelectionState.Selected:
				m_selectionBox.IsChecked = true;
				break;
			case TreeNodeSelectionState.PartialSelected:
				m_selectionBox.IsChecked = null;
				break;
			case TreeNodeSelectionState.UnSelected:
				m_selectionBox.IsChecked = false;
				break;
			}
			UpdateTreeViewItemVisualState(state);
		}
	}

	internal void UpdateIndentation(int depth)
	{
		Thickness indentation = new Thickness(depth * 16, 0.0, 0.0, 0.0);
		TreeViewItemTemplateSettings treeViewItemTemplateSettings = TreeViewItemTemplateSettings;
		treeViewItemTemplateSettings.Indentation = indentation;
	}

	private bool IsExpandCollapse(VirtualKey key)
	{
		CoreVirtualKeyStates keyState = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Control);
		bool flag = (keyState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
		CoreVirtualKeyStates keyState2 = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Menu);
		bool flag2 = (keyState2 & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
		CoreVirtualKeyStates keyState3 = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Shift);
		bool flag3 = (keyState3 & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
		if (IsDirectionalKey(key) && !flag3 && !flag2)
		{
			return !flag;
		}
		return false;
	}

	private void ReorderItems(ListView listControl, TreeViewNode targetNode, int position, int childIndex, bool isForwards)
	{
		int num = (isForwards ? 1 : (-1));
		if (listControl.ContainerFromIndex(position + num) is TreeViewItem treeViewItem)
		{
			treeViewItem.Focus(FocusState.Keyboard);
		}
		TreeViewNode parent = targetNode.Parent;
		TreeViewNodeVector treeViewNodeVector = (TreeViewNodeVector)parent.Children;
		treeViewNodeVector.RemoveAt(childIndex);
		treeViewNodeVector.InsertAt(childIndex + num, targetNode);
		listControl.UpdateLayout();
		TreeView ancestorTreeView = AncestorTreeView;
		if (ancestorTreeView.ContainerFromNode(targetNode) is TreeViewItem treeViewItem2)
		{
			TreeViewItem treeViewItem3 = treeViewItem2;
			treeViewItem3.Focus(FocusState.Keyboard);
			((TreeViewList)listControl).UpdateDropTargetDropEffect(forceUpdate: false, isLeaving: false, treeViewItem3);
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(listControl);
			automationPeer.RaiseAutomationEvent(AutomationEvents.Dropped);
		}
	}

	private void HandleGamepadAInMultiselectMode(TreeViewNode node)
	{
		if (node.HasChildren)
		{
			if (!m_expansionCycled)
			{
				node.IsExpanded = !node.IsExpanded;
				m_expansionCycled = true;
			}
			else
			{
				m_expansionCycled = ToggleSelection();
			}
		}
		else
		{
			ToggleSelection();
		}
	}

	private bool ToggleSelection()
	{
		TreeNodeSelectionState treeNodeSelectionState = CheckBoxSelectionState(m_selectionBox);
		TreeNodeSelectionState treeNodeSelectionState2 = ((treeNodeSelectionState != TreeNodeSelectionState.Selected) ? TreeNodeSelectionState.Selected : TreeNodeSelectionState.UnSelected);
		UpdateMultipleSelection(treeNodeSelectionState2);
		return treeNodeSelectionState2 == TreeNodeSelectionState.Selected;
	}

	private void HandleReorder(VirtualKey key)
	{
		TreeViewNode treeNode = TreeNode;
		TreeViewNode parent = treeNode.Parent;
		TreeViewList listControl = AncestorTreeView.ListControl;
		int num = listControl.IndexFromContainer(this);
		if (key == VirtualKey.Up || (key == VirtualKey.Left && num != 0))
		{
			int num2 = parent.Children.IndexOf(treeNode);
			if (num2 != 0)
			{
				if (treeNode.IsExpanded)
				{
					treeNode.IsExpanded = false;
				}
				ReorderItems(listControl, treeNode, num, num2, isForwards: false);
			}
		}
		else
		{
			if ((key != VirtualKey.Down && key != VirtualKey.Right) || num == listControl.Items.Count - 1)
			{
				return;
			}
			int num3 = parent.Children.IndexOf(treeNode);
			if (num3 != parent.Children.Count - 1)
			{
				if (treeNode.IsExpanded)
				{
					treeNode.IsExpanded = false;
				}
				ReorderItems(listControl, treeNode, num, num3, isForwards: true);
			}
		}
	}

	private bool HandleExpandCollapse(VirtualKey key)
	{
		TreeView ancestorTreeView = AncestorTreeView;
		TreeViewNode treeViewNode = ancestorTreeView.NodeFromContainer(this);
		bool flag = base.FlowDirection == FlowDirection.RightToLeft;
		bool isExpanded = treeViewNode.IsExpanded;
		bool result = false;
		if ((key == VirtualKey.Left && !flag) || (key == VirtualKey.Right && flag))
		{
			if (isExpanded)
			{
				treeViewNode.IsExpanded = false;
				DependencyObject dependencyObject = ancestorTreeView.ContainerFromNode(treeViewNode);
				if (dependencyObject != null)
				{
					TreeViewItem treeViewItem = (TreeViewItem)dependencyObject;
					treeViewItem.Focus(FocusState.Keyboard);
				}
				result = true;
			}
			else
			{
				TreeViewNode parent = treeViewNode.Parent;
				if (parent != null)
				{
					DependencyObject dependencyObject2 = ancestorTreeView.ContainerFromNode(parent);
					if (dependencyObject2 != null)
					{
						TreeViewItem treeViewItem2 = (TreeViewItem)dependencyObject2;
						treeViewItem2.Focus(FocusState.Keyboard);
						result = true;
					}
				}
			}
		}
		else if ((key == VirtualKey.Right && !flag) || (key == VirtualKey.Left && flag))
		{
			if (!isExpanded && treeViewNode.HasChildren)
			{
				treeViewNode.IsExpanded = true;
				result = true;
			}
			else if (treeViewNode.Children.Count > 0)
			{
				TreeViewNode node = treeViewNode.Children[0];
				DependencyObject dependencyObject3 = ancestorTreeView.ContainerFromNode(node);
				if (dependencyObject3 != null)
				{
					TreeViewItem treeViewItem3 = (TreeViewItem)dependencyObject3;
					treeViewItem3.Focus(FocusState.Keyboard);
					result = true;
				}
			}
		}
		return result;
	}

	private void OnExpandCollapseChevronPointerPressed(object sender, PointerRoutedEventArgs args)
	{
		TreeViewNode treeNode = TreeNode;
		bool flag2 = (treeNode.IsExpanded = !treeNode.IsExpanded);
		args.Handled = true;
	}

	private void RecycleEvents()
	{
		UIElement expandCollapseChevron = m_expandCollapseChevron;
		if (expandCollapseChevron != null)
		{
			expandCollapseChevron.PointerPressed -= OnExpandCollapseChevronPointerPressed;
		}
	}

	private static bool IsDirectionalKey(VirtualKey key)
	{
		if (key != VirtualKey.Up && key != VirtualKey.Down && key != VirtualKey.Left)
		{
			return key == VirtualKey.Right;
		}
		return true;
	}

	private void UpdateNodeIsExpandedAsync(TreeViewNode node, bool isExpanded)
	{
		CoreDispatcher dispatcher = Window.Current.Dispatcher;
		IAsyncAction asyncAction = dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			node.IsExpanded = isExpanded;
		});
	}

	private TreeNodeSelectionState CheckBoxSelectionState(CheckBox checkBox)
	{
		bool? isChecked = checkBox.IsChecked;
		if (isChecked.HasValue)
		{
			if (isChecked.Value)
			{
				return TreeNodeSelectionState.Selected;
			}
			return TreeNodeSelectionState.UnSelected;
		}
		return TreeNodeSelectionState.PartialSelected;
	}

	~TreeViewItem()
	{
		RecycleEvents();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (TreeNode != null)
		{
			UpdateIndentation(TreeNode.Depth);
			UpdateSelectionVisual(TreeNode.SelectionState);
		}
	}

	private static void OnHasUnrealizedChildrenPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeViewItem treeViewItem = (TreeViewItem)sender;
		treeViewItem.OnPropertyChanged(args);
	}

	private static void OnIsExpandedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeViewItem treeViewItem = (TreeViewItem)sender;
		treeViewItem.OnPropertyChanged(args);
	}

	private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeViewItem treeViewItem = (TreeViewItem)sender;
		treeViewItem.OnPropertyChanged(args);
	}
}

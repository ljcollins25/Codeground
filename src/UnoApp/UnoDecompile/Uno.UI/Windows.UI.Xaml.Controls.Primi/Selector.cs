using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls.Primitives;

public class Selector : ItemsControl
{
	private protected ScrollViewer m_tpScrollViewer;

	private protected int m_iFocusedIndex;

	private protected bool m_skipScrollIntoView;

	private readonly SerialDisposable _collectionViewSubscription = new SerialDisposable();

	private BindingPath _selectedValueBindingPath;

	private bool _disableRaiseSelectionChanged;

	private bool m_inCollectionChange;

	private readonly HashSet<DataTemplate> _itemTemplatesThatArentContainers = new HashSet<DataTemplate>();

	internal const bool UsesManagedLayouting = true;

	private protected IVirtualizingPanel VirtualizingPanel => base.ItemsPanelRoot as IVirtualizingPanel;

	internal virtual bool IsSingleSelection => true;

	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(Selector), new FrameworkPropertyMetadata((object)null));


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

	internal bool DisableRaiseSelectionChanged
	{
		get
		{
			return _disableRaiseSelectionChanged;
		}
		set
		{
			_disableRaiseSelectionChanged = value;
		}
	}

	public int SelectedIndex
	{
		get
		{
			return (int)GetValue(SelectedIndexProperty);
		}
		set
		{
			SetValue(SelectedIndexProperty, value);
		}
	}

	public static DependencyProperty SelectedIndexProperty { get; } = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(Selector), new FrameworkPropertyMetadata(-1));


	public string SelectedValuePath
	{
		get
		{
			return (string)GetValue(SelectedValuePathProperty);
		}
		set
		{
			SetValue(SelectedValuePathProperty, value);
		}
	}

	public static DependencyProperty SelectedValuePathProperty { get; } = DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(Selector), new FrameworkPropertyMetadata("", delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as Selector)?.UpdateSelectedValue();
	}));


	public object SelectedValue
	{
		get
		{
			return GetValue(SelectedValueProperty);
		}
		set
		{
			SetValue(SelectedValueProperty, value);
		}
	}

	public static DependencyProperty SelectedValueProperty { get; } = DependencyProperty.Register("SelectedValue", typeof(object), typeof(Selector), new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as Selector).OnSelectedValueChanged(e.OldValue, e.NewValue);
	}, (CoerceValueCallback)SelectedValueCoerce));


	public bool? IsSynchronizedWithCurrentItem
	{
		get
		{
			return (bool?)GetValue(IsSynchronizedWithCurrentItemProperty);
		}
		set
		{
			SetValue(IsSynchronizedWithCurrentItemProperty, value);
		}
	}

	public static DependencyProperty IsSynchronizedWithCurrentItemProperty { get; } = DependencyProperty.Register("IsSynchronizedWithCurrentItem", typeof(bool?), typeof(Selector), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as Selector)?.IsSynchronizedWithCurrentItemChanged((bool?)e.OldValue, (bool?)e.NewValue);
	}));


	private IndexPath? SelectedIndexPath { get; set; }

	public bool IsSelectionActive { get; set; }

	private protected override bool ShouldItemsControlManageChildren => !(base.ItemsPanelRoot is IVirtualizingPanel);

	public event SelectionChangedEventHandler SelectionChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsSelectionActive(DependencyObject element)
	{
		throw new NotImplementedException("The member bool Selector.GetIsSelectionActive(DependencyObject element) is not implemented in Uno.");
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == SelectedItemProperty)
		{
			OnSelectedItemChanged(args.OldValue, args.NewValue, updateItemSelectedState: true);
		}
		else if (args.Property == SelectedIndexProperty)
		{
			OnSelectedIndexChanged((int)args.OldValue, (int)args.NewValue);
		}
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		m_tpScrollViewer = GetTemplateChild<ScrollViewer>("ScrollViewer");
	}

	internal void OnSelectorItemIsSelectedChanged(SelectorItem container, bool oldIsSelected, bool newIsSelected)
	{
		object item = ItemFromContainer(container);
		ChangeSelectedItem(item, oldIsSelected, newIsSelected);
	}

	internal virtual void ChangeSelectedItem(object item, bool oldIsSelected, bool newIsSelected)
	{
		if (SelectedItem == item && !newIsSelected)
		{
			SelectedItem = null;
		}
		else if (SelectedItem != item && newIsSelected)
		{
			SelectedItem = item;
		}
	}

	internal virtual void OnSelectedItemChanged(object oldSelectedItem, object selectedItem, bool updateItemSelectedState)
	{
		int num;
		if (oldSelectedItem == null)
		{
			IEnumerable items = GetItems();
			num = ((items != null && !items.Contains(null)) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		bool flag2 = false;
		IEnumerable items2 = GetItems();
		if (items2 != null && !items2.Contains(selectedItem))
		{
			if (selectedItem != null)
			{
				object selectedItem2 = ((items2 != null && items2.Contains(oldSelectedItem)) ? oldSelectedItem : null);
				try
				{
					_disableRaiseSelectionChanged = true;
					SelectedItem = selectedItem2;
					return;
				}
				finally
				{
					_disableRaiseSelectionChanged = false;
				}
			}
			flag2 = true;
		}
		if (SelectedIndex == -1 && selectedItem == null)
		{
			flag2 = true;
		}
		int num2 = IndexFromItem(selectedItem);
		if (SelectedIndex != num2)
		{
			SelectedIndex = num2;
		}
		OnSelectedItemChangedPartial(oldSelectedItem, selectedItem);
		UpdateSelectedValue();
		if (updateItemSelectedState)
		{
			TryUpdateSelectorItemIsSelected(oldSelectedItem, isSelected: false);
			TryUpdateSelectorItemIsSelected(selectedItem, isSelected: true);
		}
		InvokeSelectionChanged(flag ? new object[0] : new object[1] { oldSelectedItem }, flag2 ? new object[0] : new object[1] { selectedItem });
	}

	internal void TryUpdateSelectorItemIsSelected(object item, bool isSelected)
	{
		if (item is SelectorItem selectorItem)
		{
			selectorItem.IsSelected = isSelected;
		}
		else if (ContainerFromItem(item) is SelectorItem selectorItem2)
		{
			selectorItem2.IsSelected = isSelected;
		}
	}

	private void UpdateSelectedValue()
	{
		if (SelectedValuePath.HasValue())
		{
			if (_selectedValueBindingPath?.Path != SelectedValuePath)
			{
				_selectedValueBindingPath = new BindingPath(SelectedValuePath, null);
			}
		}
		else
		{
			_selectedValueBindingPath = null;
		}
		if (_selectedValueBindingPath != null)
		{
			_selectedValueBindingPath.DataContext = SelectedItem;
			SelectedValue = _selectedValueBindingPath.Value;
		}
		else
		{
			SelectedValue = SelectedItem;
		}
	}

	private void OnSelectedItemChangedPartial(object oldSelectedItem, object selectedItem)
	{
		UpdateItemSelectedState(oldSelectedItem, updateTo: false);
		UpdateItemSelectedState(selectedItem, updateTo: true);
	}

	internal void InvokeSelectionChanged(object[] removedItems, object[] addedItems)
	{
		if (!_disableRaiseSelectionChanged)
		{
			this.SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(this, removedItems, addedItems));
		}
	}

	internal virtual void OnSelectedIndexChanged(int oldSelectedIndex, int newSelectedIndex)
	{
		object obj = ItemFromIndex(newSelectedIndex);
		if (base.ItemsSource is ICollectionView collectionView)
		{
			collectionView.MoveCurrentToPosition(newSelectedIndex);
		}
		if (!object.Equals(SelectedItem, obj))
		{
			SelectedItem = obj;
		}
		SelectedIndexPath = GetIndexPathFromIndex(SelectedIndex);
	}

	private void OnSelectedValueChanged(object oldValue, object newValue)
	{
		(int Index, object ItemWithValue) tuple = FindIndexOfItemWithValue(newValue);
		int item = tuple.Index;
		object item2 = tuple.ItemWithValue;
		SelectedIndex = item;
	}

	private static object SelectedValueCoerce(DependencyObject snd, object baseValue)
	{
		Selector selector = (Selector)snd;
		if (selector?._selectedValueBindingPath != null)
		{
			return baseValue;
		}
		IEnumerable items = selector.GetItems();
		if (items == null || !items.Contains(baseValue))
		{
			return null;
		}
		return baseValue;
	}

	private void IsSynchronizedWithCurrentItemChanged(bool? oldValue, bool? newValue)
	{
		if (newValue == true)
		{
			throw new ArgumentOutOfRangeException("True is not a supported value for this property");
		}
		TrySubscribeToCurrentChanged();
	}

	protected override void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnItemsSourceChanged(e);
		TrySubscribeToCurrentChanged();
		Refresh();
	}

	private void TrySubscribeToCurrentChanged()
	{
		bool flag = IsSynchronizedWithCurrentItem ?? true;
		object itemsSource = base.ItemsSource;
		ICollectionView collectionView = itemsSource as ICollectionView;
		if (collectionView != null && flag)
		{
			EventHandler<object> currentChangedHandler = OnCollectionViewCurrentChanged;
			_collectionViewSubscription.Disposable = Disposable.Create(delegate
			{
				collectionView.CurrentChanged -= currentChangedHandler;
			});
			collectionView.CurrentChanged += currentChangedHandler;
			SelectedIndex = collectionView.CurrentPosition;
		}
		else
		{
			_collectionViewSubscription.Disposable = null;
			SelectedIndex = -1;
		}
	}

	private void OnCollectionViewCurrentChanged(object sender, object e)
	{
		if (IsSingleSelection && base.ItemsSource is ICollectionView collectionView)
		{
			SelectedIndex = collectionView.CurrentPosition;
		}
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		base.PrepareContainerForItemOverride(element, item);
		if (element is SelectorItem selectorItem)
		{
			selectorItem.IsSelected = IsSelected(IndexFromContainer(element));
		}
	}

	internal virtual bool IsSelected(int index)
	{
		return SelectedIndex == index;
	}

	internal override void OnItemsSourceSingleCollectionChanged(object sender, NotifyCollectionChangedEventArgs c, int section)
	{
		int selectedIndex = SelectedIndex;
		base.OnItemsSourceSingleCollectionChanged(sender, c, section);
		switch (c.Action)
		{
		case NotifyCollectionChangedAction.Add:
		{
			int indexFromIndexPath3 = GetIndexFromIndexPath(IndexPath.FromRowSection(c.NewStartingIndex, section));
			if (selectedIndex >= indexFromIndexPath3)
			{
				selectedIndex = (SelectedIndex = selectedIndex + c.NewItems!.Count);
			}
			break;
		}
		case NotifyCollectionChangedAction.Remove:
		{
			int indexFromIndexPath = GetIndexFromIndexPath(IndexPath.FromRowSection(c.OldStartingIndex, section));
			if (selectedIndex >= indexFromIndexPath && selectedIndex < indexFromIndexPath + c.OldItems!.Count)
			{
				SelectedIndex = -1;
			}
			else if (selectedIndex >= indexFromIndexPath + c.OldItems!.Count)
			{
				selectedIndex = (SelectedIndex = selectedIndex - c.OldItems!.Count);
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		{
			int indexFromIndexPath2 = GetIndexFromIndexPath(IndexPath.FromRowSection(c.OldStartingIndex, section));
			if (selectedIndex >= indexFromIndexPath2 && selectedIndex < indexFromIndexPath2 + c.OldItems!.Count)
			{
				SelectedIndex = -1;
			}
			break;
		}
		case NotifyCollectionChangedAction.Move:
		case NotifyCollectionChangedAction.Reset:
		{
			IndexPath? selectedIndexPath = SelectedIndexPath;
			if (selectedIndexPath.HasValue && selectedIndexPath.GetValueOrDefault().Section == section)
			{
				object obj = ItemFromIndex(SelectedIndex);
				if (obj == null || !obj.Equals(SelectedItem))
				{
					SelectedIndex = -1;
				}
			}
			break;
		}
		}
		OnItemsChanged(c);
	}

	internal override void OnItemsSourceGroupsChanged(object sender, NotifyCollectionChangedEventArgs c)
	{
		base.OnItemsSourceGroupsChanged(sender, c);
		if (!SelectedIndexPath.HasValue)
		{
			return;
		}
		IndexPath value = SelectedIndexPath.Value;
		switch (c.Action)
		{
		case NotifyCollectionChangedAction.Add:
		{
			IndexPath indexPath5 = IndexPath.FromRowSection(0, c.NewStartingIndex);
			if (value >= indexPath5)
			{
				int num2 = SelectedIndex;
				for (int j = c.NewStartingIndex; j < c.NewStartingIndex + c.NewItems!.Count; j++)
				{
					num2 += GetGroupCount(j);
				}
				SelectedIndex = num2;
			}
			break;
		}
		case NotifyCollectionChangedAction.Remove:
		{
			IndexPath indexPath3 = IndexPath.FromRowSection(0, c.OldStartingIndex);
			IndexPath indexPath4 = IndexPath.FromRowSection(int.MaxValue, c.OldStartingIndex + c.OldItems!.Count);
			if (value >= indexPath3 && value < indexPath4)
			{
				SelectedIndex = -1;
			}
			else if (value >= indexPath4)
			{
				int num = SelectedIndex;
				for (int i = c.OldStartingIndex; i < c.OldStartingIndex + c.OldItems!.Count; i++)
				{
					num -= GetGroupCount(i);
				}
				SelectedIndex = num;
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		{
			IndexPath indexPath = IndexPath.FromRowSection(0, c.OldStartingIndex);
			IndexPath indexPath2 = IndexPath.FromRowSection(int.MaxValue, c.OldStartingIndex + c.OldItems!.Count);
			if (value >= indexPath && value < indexPath2)
			{
				SelectedIndex = -1;
			}
			break;
		}
		case NotifyCollectionChangedAction.Reset:
			SelectedIndex = -1;
			break;
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	internal void OnItemClicked(SelectorItem selectorItem)
	{
		OnItemClicked(IndexFromContainer(selectorItem));
	}

	internal virtual void OnItemClicked(int clickedIndex)
	{
		if (base.ItemsSource is ICollectionView collectionView)
		{
			collectionView.MoveCurrentToPosition(clickedIndex);
			clickedIndex = collectionView.CurrentPosition;
		}
		SelectedIndex = clickedIndex;
	}

	private void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		if (base.ItemsSource != null)
		{
			return;
		}
		IVectorChangedEventArgs vectorChangedEventArgs = e.ToVectorChangedEventArgs();
		if (vectorChangedEventArgs.CollectionChange == CollectionChange.ItemChanged || (vectorChangedEventArgs.CollectionChange == CollectionChange.ItemInserted && vectorChangedEventArgs.Index < base.Items.Count))
		{
			object obj = base.Items[(int)vectorChangedEventArgs.Index];
			if (obj is SelectorItem selectorItem && selectorItem.IsSelected)
			{
				ChangeSelectedItem(selectorItem, oldIsSelected: false, newIsSelected: true);
			}
		}
		else if (vectorChangedEventArgs.CollectionChange == CollectionChange.ItemRemoved && vectorChangedEventArgs.Index == (uint)SelectedIndex)
		{
			SelectedIndex = -1;
		}
	}

	private protected override DependencyObject GetRootOfItemTemplateAsContainer(DataTemplate template)
	{
		if (_itemTemplatesThatArentContainers.Contains(template))
		{
			return null;
		}
		UIElement uIElement = template?.LoadContentCached();
		if (IsItemItsOwnContainerOverride(uIElement))
		{
			if (uIElement is ContentControl contentControl)
			{
				contentControl.IsGeneratedContainer = true;
				contentControl.IsContainerFromTemplateRoot = true;
			}
			return uIElement;
		}
		if (uIElement != null)
		{
			_itemTemplatesThatArentContainers.Add(template);
			template.ReleaseTemplateRoot(uIElement);
		}
		return null;
	}

	private (int Index, object ItemWithValue) FindIndexOfItemWithValue(object value)
	{
		int numberOfItems = base.NumberOfItems;
		for (int i = 0; i < numberOfItems; i++)
		{
			object itemFromIndex = GetItemFromIndex(i);
			object selectedValue = GetSelectedValue(itemFromIndex);
			if (object.Equals(value, selectedValue))
			{
				return (i, selectedValue);
			}
		}
		return (-1, null);
	}

	private object GetSelectedValue(object pItem)
	{
		if (_selectedValueBindingPath == null || pItem == null)
		{
			return pItem;
		}
		_selectedValueBindingPath.DataContext = pItem;
		return _selectedValueBindingPath.Value;
	}

	private protected override void Refresh()
	{
		base.Refresh();
		_itemTemplatesThatArentContainers.Clear();
		RefreshPartial();
	}

	protected virtual (Orientation PhysicalOrientation, Orientation LogicalOrientation) GetItemsHostOrientations()
	{
		return (Orientation.Horizontal, Orientation.Horizontal);
	}

	protected void SetFocusedItem(int index, bool shouldScrollIntoView, bool forceFocus, FocusState focusState, bool animateIfBringIntoView)
	{
	}

	protected void SetFocusedItem(int index, bool shouldScrollIntoView, bool forceFocus, FocusState focusState, bool animateIfBringIntoView, FocusNavigationDirection focusNavigationDirection)
	{
	}

	private void ScrollIntoView(int index, bool isGroupItemIndex, bool isHeader, bool isFooter, bool isFromPublicAPI, bool ensureContainerRealized, bool animateIfBringIntoView, ScrollIntoViewAlignment @default)
	{
	}

	protected void SetFocusedItem(int index, bool shouldScrollIntoView, bool animateIfBringIntoView, FocusNavigationDirection focusNavigationDirection)
	{
		FocusState focusState = FocusState.Programmatic;
		SetFocusedItem(index, shouldScrollIntoView, forceFocus: false, focusState, animateIfBringIntoView, focusNavigationDirection);
	}

	protected void SetFocusedItem(int index, bool shouldScrollIntoView)
	{
	}

	private bool CanScrollIntoView()
	{
		bool flag = false;
		bool flag2 = false;
		Panel itemsPanelRoot = base.ItemsPanelRoot;
		if (itemsPanelRoot != null && !flag)
		{
			flag2 = true;
		}
		if (!flag && flag2 && !m_skipScrollIntoView)
		{
			return !m_inCollectionChange;
		}
		return false;
	}

	private void RefreshPartial()
	{
		if (VirtualizingPanel != null)
		{
			VirtualizingPanel.GetLayouter().Refresh();
			InvalidateMeasure();
		}
	}

	private void UpdateItemSelectedState(object item, bool updateTo)
	{
		if (item != null)
		{
			DependencyObject dependencyObject = ContainerFromItem(item);
			if (dependencyObject is SelectorItem selectorItem)
			{
				selectorItem.IsSelected = updateTo;
			}
		}
	}
}

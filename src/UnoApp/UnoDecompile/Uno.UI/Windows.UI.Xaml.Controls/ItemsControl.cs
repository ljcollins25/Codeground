using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.Extensions;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Items")]
public class ItemsControl : Control, IItemContainerMapping, IItemsControl, IFrameworkElement, IDataContextProvider, DependencyObject, IDependencyObjectParse
{
	private class ViewComparer : IEqualityComparer<UIElement>
	{
		public bool Equals(UIElement x, UIElement y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(UIElement obj)
		{
			return obj.GetHashCode();
		}
	}

	protected IVectorChangedEventArgs _inProgressVectorChange;

	private ItemsPresenter _itemsPresenter;

	private readonly SerialDisposable _notifyCollectionChanged = new SerialDisposable();

	private readonly SerialDisposable _notifyCollectionGroupsChanged = new SerialDisposable();

	private readonly SerialDisposable _cvsViewChanged = new SerialDisposable();

	private bool _isReady;

	private ItemCollection _items = new ItemCollection();

	private DependencyObject _containerBeingPrepared;

	private int[] _groupCounts;

	private static readonly DataTemplate InnerContentPresenterTemplate = new DataTemplate(() => new ContentPresenter());

	private UIElement _internalItemsPanelRoot;

	private Panel _itemsPanelRoot;

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
	public GroupStyleSelector GroupStyleSelector
	{
		get
		{
			return (GroupStyleSelector)GetValue(GroupStyleSelectorProperty);
		}
		set
		{
			SetValue(GroupStyleSelectorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemContainerGenerator ItemContainerGenerator
	{
		get
		{
			throw new NotImplementedException("The member ItemContainerGenerator ItemsControl.ItemContainerGenerator is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GroupStyleSelectorProperty { get; } = DependencyProperty.Register("GroupStyleSelector", typeof(GroupStyleSelector), typeof(ItemsControl), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemContainerTransitionsProperty { get; } = DependencyProperty.Register("ItemContainerTransitions", typeof(TransitionCollection), typeof(ItemsControl), new FrameworkPropertyMetadata((object)null));


	internal ScrollViewer ScrollViewer { get; private set; }

	internal UIElement InternalItemsPanelRoot
	{
		get
		{
			return _internalItemsPanelRoot;
		}
		set
		{
			_internalItemsPanelRoot?.SetParent(null);
			_internalItemsPanelRoot = value;
		}
	}

	public Panel ItemsPanelRoot
	{
		get
		{
			return _itemsPanelRoot;
		}
		set
		{
			_itemsPanelRoot?.SetParent(null);
			_itemsPanelRoot = value;
		}
	}

	private protected virtual bool ShouldItemsControlManageChildren => ItemsPanelRoot == InternalItemsPanelRoot;

	public ItemsPanelTemplate ItemsPanel
	{
		get
		{
			return (ItemsPanelTemplate)GetValue(ItemsPanelProperty);
		}
		set
		{
			SetValue(ItemsPanelProperty, value);
		}
	}

	public static DependencyProperty ItemsPanelProperty { get; } = DependencyProperty.Register("ItemsPanel", typeof(ItemsPanelTemplate), typeof(ItemsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsControl)s)?.OnItemsPanelChanged((ItemsPanelTemplate)e.OldValue, (ItemsPanelTemplate)e.NewValue);
	}));


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

	public static DependencyProperty ItemTemplateProperty { get; } = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(ItemsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsControl)s)?.OnItemTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue);
	}));


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

	public static DependencyProperty ItemTemplateSelectorProperty { get; } = DependencyProperty.Register("ItemTemplateSelector", typeof(DataTemplateSelector), typeof(ItemsControl), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsControl)s)?.OnItemTemplateSelectorChanged((DataTemplateSelector)e.OldValue, (DataTemplateSelector)e.NewValue);
	}));


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

	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(ItemsControl), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsControl)s).OnItemsSourceChanged(e);
	}));


	public ItemCollection Items => _items;

	internal int NumberOfGroups => CollectionGroups?.Count ?? 0;

	internal int NumberOfDisplayGroups
	{
		get
		{
			if (!AreEmptyGroupsHidden)
			{
				return NumberOfGroups;
			}
			return CollectionGroups.Where((object g) => (g as ICollectionViewGroup).GroupItems.Count > 0).Count();
		}
	}

	internal int NumberOfItems
	{
		get
		{
			IEnumerable items = GetItems();
			if (items is ICollection<object> collection)
			{
				return collection.Count;
			}
			return items?.Count() ?? 0;
		}
	}

	internal bool HasItems
	{
		get
		{
			IEnumerable items = GetItems();
			if (items is ICollection<object> collection)
			{
				return collection.Count > 0;
			}
			return items?.Any() ?? false;
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

	public static DependencyProperty ItemContainerStyleProperty { get; } = DependencyProperty.Register("ItemContainerStyle", typeof(Style), typeof(ItemsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((ItemsControl)o).OnItemContainerStyleChanged((Style)e.OldValue, (Style)e.NewValue);
	}));


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

	public static DependencyProperty ItemContainerStyleSelectorProperty { get; } = DependencyProperty.Register("ItemContainerStyleSelector", typeof(StyleSelector), typeof(ItemsControl), new FrameworkPropertyMetadata(null, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((ItemsControl)o).OnItemContainerStyleSelectorChanged((StyleSelector)e.OldValue, (StyleSelector)e.NewValue);
	}));


	public IObservableVector<GroupStyle> GroupStyle { get; } = new ObservableVector<GroupStyle>();


	public bool IsGrouping
	{
		get
		{
			return (bool)GetValue(IsGroupingProperty);
		}
		private set
		{
			SetValue(IsGroupingProperty, value);
		}
	}

	public static DependencyProperty IsGroupingProperty { get; } = DependencyProperty.Register("IsGrouping", typeof(bool), typeof(ItemsControl), new FrameworkPropertyMetadata(false));


	internal static DependencyProperty IndexForItemContainerProperty { get; } = DependencyProperty.RegisterAttached("IndexForItemContainer", typeof(int), typeof(ItemsControl), new FrameworkPropertyMetadata(-1));


	internal static DependencyProperty ItemsControlForItemContainerProperty { get; } = DependencyProperty.RegisterAttached("ItemsControlForItemContainer", typeof(WeakReference<ItemsControl>), typeof(ItemsControl), new FrameworkPropertyMetadata(DependencyProperty.UnsetValue));


	internal bool AreEmptyGroupsHidden
	{
		get
		{
			if (CollectionGroups != null)
			{
				return GroupStyle.FirstOrDefault()?.HidesIfEmpty ?? false;
			}
			return false;
		}
	}

	private IObservableVector<object> CollectionGroups => (GetItems() as ICollectionView)?.CollectionGroups;

	internal IEnumerable<DependencyObject> MaterializedContainers => GetItemsPanelChildren().Prepend(_containerBeingPrepared).Trim().Distinct();

	public string DisplayMemberPath
	{
		get
		{
			return (string)GetValue(DisplayMemberPathProperty);
		}
		set
		{
			SetValue(DisplayMemberPathProperty, value);
		}
	}

	public static DependencyProperty DisplayMemberPathProperty { get; } = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(ItemsControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsControl)s)?.OnDisplayMemberPathChanged((string)e.OldValue, (string)e.NewValue);
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject GroupHeaderContainerFromItemContainer(DependencyObject itemContainer)
	{
		throw new NotImplementedException("The member DependencyObject ItemsControl.GroupHeaderContainerFromItemContainer(DependencyObject itemContainer) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnGroupStyleSelectorChanged(GroupStyleSelector oldGroupStyleSelector, GroupStyleSelector newGroupStyleSelector)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemsControl", "void ItemsControl.OnGroupStyleSelectorChanged(GroupStyleSelector oldGroupStyleSelector, GroupStyleSelector newGroupStyleSelector)");
	}

	public static ItemsControl GetItemsOwner(DependencyObject element)
	{
		if (element is Panel panel && panel.IsItemsHost)
		{
			return panel.ItemsOwner;
		}
		return null;
	}

	public ItemsControl()
	{
		Initialize();
		base.DefaultStyleKey = typeof(ItemsControl);
	}

	private void Initialize()
	{
		_items.VectorChanged += OnItemsVectorChanged;
	}

	private void OnItemsVectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs e)
	{
		_inProgressVectorChange = e;
		OnItemsChanged(e);
		_inProgressVectorChange = null;
		OnItemsSourceSingleCollectionChanged(this, e.ToNotifyCollectionChangedEventArgs(), 0);
	}

	private void RequestLayoutPartial()
	{
		InvalidateMeasure();
	}

	private void OnItemsPanelChanged(ItemsPanelTemplate oldItemsPanel, ItemsPanelTemplate newItemsPanel)
	{
		if (_isReady && !object.Equals(oldItemsPanel, newItemsPanel))
		{
			UpdateItemsPanelRoot();
		}
	}

	protected virtual void OnItemTemplateChanged(DataTemplate oldItemTemplate, DataTemplate newItemTemplate)
	{
		Refresh();
		UpdateItems(null);
	}

	protected virtual void OnItemTemplateSelectorChanged(DataTemplateSelector oldItemTemplateSelector, DataTemplateSelector newItemTemplateSelector)
	{
		Refresh();
		UpdateItems(null);
	}

	protected virtual void OnItemsChanged(object e)
	{
	}

	internal IEnumerable GetItems()
	{
		object obj = UnwrapItemsSource();
		if (obj != null)
		{
			return obj as IEnumerable;
		}
		ItemCollection items = Items;
		if (items != null && items.Any())
		{
			return Items;
		}
		return Enumerable.Empty<object>();
	}

	protected virtual void OnItemContainerStyleChanged(Style oldItemContainerStyle, Style newItemContainerStyle)
	{
		Refresh();
	}

	protected virtual void OnItemContainerStyleSelectorChanged(StyleSelector oldItemContainerStyleSelector, StyleSelector newItemContainerStyleSelector)
	{
		Refresh();
	}

	internal GroupStyle GetGroupStyle()
	{
		return GroupStyle.FirstOrDefault();
	}

	internal IndexPath? GetNextItemIndex(IndexPath? currentItem, int direction)
	{
		if (!HasItems)
		{
			return null;
		}
		if (!currentItem.HasValue)
		{
			if (direction == 1)
			{
				int section = (IsGrouping ? GetNextNonEmptySection(-1, 1).Value : 0);
				return IndexPath.FromRowSection(0, section);
			}
			return null;
		}
		return direction switch
		{
			1 => GetIncrementedItemIndex(currentItem.Value), 
			-1 => GetDecrementedItemIndex(currentItem.Value), 
			_ => throw new ArgumentOutOfRangeException("direction"), 
		};
	}

	private IndexPath? GetIncrementedItemIndex(IndexPath currentItem)
	{
		if (!IsGrouping)
		{
			if (currentItem.Section > 0)
			{
				throw new InvalidOperationException("Received an index with non-zero group, but source is not grouped.");
			}
			if (currentItem.Row == NumberOfItems - 1)
			{
				return null;
			}
			return IndexPath.FromRowSection(currentItem.Row + 1, 0);
		}
		if (currentItem.Row == GetDisplayGroupCount(currentItem.Section) - 1)
		{
			int? nextNonEmptySection = GetNextNonEmptySection(currentItem.Section, 1);
			if (!nextNonEmptySection.HasValue)
			{
				return null;
			}
			return IndexPath.FromRowSection(0, nextNonEmptySection.Value);
		}
		return IndexPath.FromRowSection(currentItem.Row + 1, currentItem.Section);
	}

	private IndexPath? GetDecrementedItemIndex(IndexPath currentItem)
	{
		if (!IsGrouping)
		{
			if (currentItem.Section > 0)
			{
				throw new InvalidOperationException("Received an index with non-zero group, but source is not grouped.");
			}
			if (currentItem.Row == 0)
			{
				return null;
			}
			return IndexPath.FromRowSection(currentItem.Row - 1, 0);
		}
		if (currentItem.Row == 0)
		{
			int? nextNonEmptySection = GetNextNonEmptySection(currentItem.Section, -1);
			if (!nextNonEmptySection.HasValue)
			{
				return null;
			}
			return IndexPath.FromRowSection(GetDisplayGroupCount(nextNonEmptySection.Value) - 1, nextNonEmptySection.Value);
		}
		return IndexPath.FromRowSection(currentItem.Row - 1, currentItem.Section);
	}

	internal int GetIndexFromIndexPath(IndexPath indexPath)
	{
		if (indexPath.Section == 0)
		{
			return indexPath.Row;
		}
		int num = 0;
		for (int i = 0; i < indexPath.Section; i++)
		{
			num += GetDisplayGroupCount(i);
		}
		return num + indexPath.Row;
	}

	internal IndexPath? GetIndexPathFromIndex(int index)
	{
		if (!IsGrouping)
		{
			return IndexPath.FromRowSection(index, 0);
		}
		int num = index;
		for (int i = 0; i < NumberOfDisplayGroups; i++)
		{
			int displayGroupCount = GetDisplayGroupCount(i);
			if (num < displayGroupCount)
			{
				return IndexPath.FromRowSection(num, i);
			}
			num -= displayGroupCount;
		}
		return null;
	}

	private int? GetNextNonEmptySection(int startingSection, int direction)
	{
		int num = startingSection;
		for (num += direction; num >= 0 && num < NumberOfDisplayGroups; num += direction)
		{
			if (GetDisplayGroupCount(num) > 0)
			{
				return num;
			}
		}
		return null;
	}

	internal IndexPath? GetLastItem()
	{
		if (!IsGrouping)
		{
			int numberOfItems = NumberOfItems;
			if (numberOfItems <= 0)
			{
				return null;
			}
			return IndexPath.FromRowSection(numberOfItems - 1, 0);
		}
		for (int num = NumberOfDisplayGroups - 1; num >= 0; num--)
		{
			int displayGroupCount = GetDisplayGroupCount(num);
			if (displayGroupCount > 0)
			{
				return IndexPath.FromRowSection(displayGroupCount - 1, num);
			}
		}
		return null;
	}

	internal int AdjustGroupIndexForHidesIfEmpty(int index)
	{
		int num = index;
		if (AreEmptyGroupsHidden)
		{
			for (int i = 0; i < index; i++)
			{
				if (GetGroupCount(i) == 0)
				{
					num--;
				}
			}
		}
		return num;
	}

	internal int GetItemsOnLastLine(int section, int itemsPerLine)
	{
		int num = GetDisplayGroupCount(section) % itemsPerLine;
		if (num != 0)
		{
			return num;
		}
		return itemsPerLine;
	}

	protected virtual void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug($"Calling OnItemsSourceChanged(), Old source={e.OldValue}, new source={e.NewValue}, NoOfItems={NumberOfItems}");
		}
		IsGrouping = (e.NewValue as ICollectionView)?.CollectionGroups != null;
		Items.SetItemsSource(UnwrapItemsSource() as IEnumerable);
		ObserveCollectionChanged();
		TryObserveCollectionViewSource(e.NewValue);
	}

	private void TryObserveCollectionViewSource(object newValue)
	{
		if (newValue is CollectionViewSource instance)
		{
			_cvsViewChanged.Disposable = null;
			_cvsViewChanged.Disposable = instance.RegisterDisposablePropertyChangedCallback(CollectionViewSource.ViewProperty, delegate
			{
				ObserveCollectionChanged();
				UpdateItems(null);
			});
		}
	}

	internal int GetGroupCount(int groupIndex)
	{
		if (!IsGrouping)
		{
			return 0;
		}
		return GetGroupAt(groupIndex).GroupItems.Count;
	}

	internal int GetDisplayGroupCount(int displaySection)
	{
		if (!IsGrouping)
		{
			return 0;
		}
		return GetGroupAtDisplaySection(displaySection).GroupItems.Count;
	}

	internal object UnwrapItemsSource()
	{
		if (!(ItemsSource is CollectionViewSource collectionViewSource))
		{
			return ItemsSource;
		}
		return collectionViewSource.View;
	}

	internal void ObserveCollectionChanged()
	{
		object obj = UnwrapItemsSource();
		if (obj == null)
		{
			_notifyCollectionChanged.Disposable = null;
		}
		else
		{
			if (obj is CollectionView collectionView && collectionView.CollectionGroups != null)
			{
				IEnumerable innerCollection = collectionView.InnerCollection;
				INotifyCollectionChanged observableGroupedSource = innerCollection as INotifyCollectionChanged;
				if (observableGroupedSource != null)
				{
					NotifyCollectionChangedEventHandler handler = OnItemsSourceGroupsChanged;
					_notifyCollectionChanged.Disposable = Disposable.Create(delegate
					{
						observableGroupedSource.CollectionChanged -= handler;
					});
					observableGroupedSource.CollectionChanged += handler;
					goto IL_0116;
				}
			}
			ICollectionView iCollectionView = obj as ICollectionView;
			if (iCollectionView != null && iCollectionView.CollectionGroups != null)
			{
				VectorChangedEventHandler<object> handler2 = OnItemsSourceGroupsVectorChanged;
				_notifyCollectionChanged.Disposable = Disposable.Create(delegate
				{
					iCollectionView.CollectionGroups.VectorChanged -= handler2;
				});
				iCollectionView.CollectionGroups.VectorChanged += handler2;
			}
			else
			{
				_notifyCollectionChanged.Disposable = null;
			}
		}
		goto IL_0116;
		IL_0116:
		_notifyCollectionGroupsChanged.Disposable = null;
		if (!(obj is ICollectionView collectionView2) || collectionView2.CollectionGroups == null)
		{
			return;
		}
		CompositeDisposable compositeDisposable = new CompositeDisposable();
		int num = -1;
		foreach (ICollectionViewGroup collectionGroup in collectionView2.CollectionGroups)
		{
			ICollectionViewGroup group = collectionGroup;
			if (!AreEmptyGroupsHidden || group.GroupItems.Count > 0)
			{
				num++;
			}
			int insideLoop = num;
			INotifyCollectionChanged observableGroup = (group.GroupItems as INotifyCollectionChanged) ?? (group.Group as INotifyCollectionChanged);
			if (observableGroup != null)
			{
				NotifyCollectionChangedEventHandler onCollectionChanged = delegate(object o, NotifyCollectionChangedEventArgs e)
				{
					OnItemsSourceSingleCollectionChanged(o, e, insideLoop);
				};
				Disposable.Create(delegate
				{
					observableGroup.CollectionChanged -= onCollectionChanged;
				}).DisposeWith(compositeDisposable);
				observableGroup.CollectionChanged += onCollectionChanged;
			}
			else
			{
				VectorChangedEventHandler<object> onVectorChanged = delegate(IObservableVector<object> o, IVectorChangedEventArgs e)
				{
					OnItemsSourceSingleCollectionChanged(o, e.ToNotifyCollectionChangedEventArgs(), insideLoop);
				};
				Disposable.Create(delegate
				{
					group.GroupItems.VectorChanged -= onVectorChanged;
				}).DisposeWith(compositeDisposable);
				group.GroupItems.VectorChanged += onVectorChanged;
			}
			INotifyPropertyChanged bindableGroup = group as INotifyPropertyChanged;
			if (bindableGroup != null)
			{
				Disposable.Create(delegate
				{
					bindableGroup.PropertyChanged -= new PropertyChangedEventHandler(onPropertyChanged);
				}).DisposeWith(compositeDisposable);
				bindableGroup.PropertyChanged += new PropertyChangedEventHandler(onPropertyChanged);
				OnGroupPropertyChanged(group, insideLoop);
			}
			void onPropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				if (e.PropertyName == "Group")
				{
					OnGroupPropertyChanged(group, insideLoop);
				}
			}
		}
		_notifyCollectionGroupsChanged.Disposable = compositeDisposable;
		UpdateGroupCounts();
	}

	private void UpdateGroupCounts()
	{
		if (CollectionGroups != null)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < CollectionGroups.Count; i++)
			{
				ICollectionViewGroup collectionViewGroup = CollectionGroups[i] as ICollectionViewGroup;
				list.Add(collectionViewGroup.GroupItems.Count);
			}
			_groupCounts = list.ToArray();
		}
		else
		{
			_groupCounts = null;
		}
	}

	internal int GetCachedGroupCount(int groupIndex)
	{
		return _groupCounts[groupIndex];
	}

	private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		OnItemsSourceSingleCollectionChanged(sender, args, 0);
	}

	private void OnItemsSourceGroupsVectorChanged(object sender, IVectorChangedEventArgs args)
	{
		OnItemsSourceGroupsChanged(sender, args.ToNotifyCollectionChangedEventArgs());
	}

	private void OnItemsSourceVectorChanged(object sender, IVectorChangedEventArgs args)
	{
		OnItemsSourceCollectionChanged(sender, args.ToNotifyCollectionChangedEventArgs());
	}

	internal virtual void OnItemsSourceSingleCollectionChanged(object sender, NotifyCollectionChangedEventArgs args, int section)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Called {0}(), Action={1}, NoOfItems={2}", "OnItemsSourceSingleCollectionChanged", args.Action, NumberOfItems));
		}
		UpdateItems(args);
	}

	internal virtual void OnItemsSourceGroupsChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Called {0}(), Action={1}, NoOfItems={2}, NoOfGroups={3}", "OnItemsSourceGroupsChanged", args.Action, NumberOfItems, NumberOfGroups));
		}
		UpdateItems(args);
	}

	internal virtual void OnGroupPropertyChanged(ICollectionViewGroup group, int groupIndex)
	{
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		ScrollViewer = GetTemplateChild("ScrollViewer") as ScrollViewer;
		_isReady = true;
		UpdateItemsPanelRoot();
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
	}

	private void UpdateItemsPanelRoot()
	{
		if (ShouldItemsControlManageChildren)
		{
			ItemsPanelRoot?.Children.Clear();
		}
		if (InternalItemsPanelRoot != null)
		{
			CleanUpInternalItemsPanel(InternalItemsPanelRoot);
		}
		UIElement uIElement = ItemsPanel?.LoadContent() ?? new StackPanel();
		InternalItemsPanelRoot = ResolveInternalItemsPanel(uIElement);
		ItemsPanelRoot = uIElement as Panel;
		ItemsPanelRoot?.SetItemsOwner(this);
		_itemsPresenter?.SetItemsPanel(InternalItemsPanelRoot);
		UpdateItems(null);
	}

	protected virtual UIElement ResolveInternalItemsPanel(UIElement itemsPanel)
	{
		return itemsPanel;
	}

	protected internal override void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnDataContextChanged(e);
		SyncDataContext();
	}

	private protected virtual void UpdateItems(NotifyCollectionChangedEventArgs args)
	{
		if (ItemsPanelRoot == null || !ShouldItemsControlManageChildren)
		{
			return;
		}
		if (args != null)
		{
			if (args.Action == NotifyCollectionChangedAction.Reset)
			{
				for (int i = 0; i < ItemsPanelRoot.Children.Count; i++)
				{
					CleanUpContainer(ItemsPanelRoot.Children[i]);
				}
				ItemsPanelRoot.Children.Clear();
			}
			else
			{
				if (args.Action == NotifyCollectionChangedAction.Remove && args.OldItems!.Count == 1)
				{
					UIElement container2 = ItemsPanelRoot.Children[args.OldStartingIndex];
					ItemsPanelRoot.Children.RemoveAt(args.OldStartingIndex);
					LocalCleanupContainer(container2);
					RequestLayoutPartial();
					return;
				}
				if (args.Action == NotifyCollectionChangedAction.Add && args.NewItems!.Count == 1)
				{
					ItemsPanelRoot.Children.Insert(args.NewStartingIndex, (UIElement)LocalCreateContainer(args.NewStartingIndex));
					RequestLayoutPartial();
					return;
				}
				if (args.Action == NotifyCollectionChangedAction.Replace && args.NewItems!.Count == 1)
				{
					UIElement container3 = ItemsPanelRoot.Children[args.NewStartingIndex];
					LocalCleanupContainer(container3);
					ItemsPanelRoot.Children[args.NewStartingIndex] = (UIElement)LocalCreateContainer(args.NewStartingIndex);
					RequestLayoutPartial();
					return;
				}
			}
		}
		IEnumerable<object> source = (GetItems() ?? Enumerable.Empty<object>()).Cast<object>().Select((object _, int index) => LocalCreateContainer(index));
		ObservableCollectionUpdateResults<UIElement> observableCollectionUpdateResults = ItemsPanelRoot.Children.UpdateWithResults(source.OfType<UIElement>(), tryDispose: false, new ViewComparer());
		IEnumerator<UIElement> enumerator = observableCollectionUpdateResults.Removed.GetEnumerator();
		while (enumerator.MoveNext())
		{
			UIElement current = enumerator.Current;
			LocalCleanupContainer(current);
		}
		RequestLayoutPartial();
		void LocalCleanupContainer(object container)
		{
			if (container is DependencyObject element)
			{
				CleanUpContainer(element);
			}
		}
		object LocalCreateContainer(int index)
		{
			DependencyObject containerForIndex = GetContainerForIndex(index);
			PrepareContainerForIndex(containerForIndex, index);
			return containerForIndex;
		}
	}

	protected virtual void ClearContainerForItemOverride(DependencyObject element, object item)
	{
		if (element is UIElement uIElement && !uIElement.IsGeneratedContainer && element is FrameworkElement frameworkElement && frameworkElement.IsStyleSetFromItemsControl)
		{
			frameworkElement.ClearValue(FrameworkElement.StyleProperty);
			frameworkElement.IsStyleSetFromItemsControl = false;
		}
	}

	internal virtual void ContainerClearedForItem(object item, SelectorItem itemContainer)
	{
	}

	internal void CleanUpContainer(DependencyObject element)
	{
		object item;
		if (!(element is ContentPresenter contentPresenter))
		{
			if (!(element is ContentControl contentControl) || contentControl == null)
			{
				goto IL_0033;
			}
			item = contentControl.Content;
		}
		else
		{
			if (contentPresenter == null)
			{
				goto IL_0033;
			}
			item = contentPresenter.Content;
		}
		goto IL_0035;
		IL_0033:
		item = element;
		goto IL_0035;
		IL_0035:
		ClearContainerForItemOverride(element, item);
		ContainerClearedForItem(item, element as SelectorItem);
		if (element is ContentPresenter contentPresenter2 && (contentPresenter2.ContentTemplate == ItemTemplate || contentPresenter2.ContentTemplateSelector == ItemTemplateSelector))
		{
			contentPresenter2.ClearValue(ContentPresenter.ContentProperty);
			contentPresenter2.ClearValue(ContentPresenter.ContentTemplateProperty);
			contentPresenter2.ClearValue(ContentPresenter.ContentTemplateSelectorProperty);
		}
		else if (element is ContentControl contentControl2)
		{
			contentControl2.ClearValue(UIElement.DataContextProperty);
		}
	}

	protected virtual DependencyObject GetContainerForItemOverride()
	{
		return InnerContentPresenterTemplate.LoadContentCached() as ContentPresenter;
	}

	protected virtual void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		bool flag = element == item;
		if (element is ContentPresenter contentPresenter)
		{
			contentPresenter.ContentTemplate = ItemTemplate;
			contentPresenter.ContentTemplateSelector = ItemTemplateSelector;
			if (!flag)
			{
				SetContent(contentPresenter, ContentPresenter.ContentProperty);
			}
		}
		else if (element is ContentControl contentControl)
		{
			if (!contentControl.IsContainerFromTemplateRoot)
			{
				contentControl.ContentTemplate = ItemTemplate;
				contentControl.ContentTemplateSelector = ItemTemplateSelector;
			}
			if (!flag)
			{
				TryRepairContentConnection(contentControl, item);
				SetContent(contentControl, UIElement.DataContextProperty);
				if (!contentControl.IsContainerFromTemplateRoot && contentControl.GetBindingExpression(ContentControl.ContentProperty) == null)
				{
					contentControl.SetBinding(ContentControl.ContentProperty, new Binding());
				}
			}
		}
		ApplyItemContainerStyle(element, item);
		void SetContent(UIElement container, DependencyProperty contentProperty)
		{
			string displayMemberPath = DisplayMemberPath;
			if (string.IsNullOrEmpty(displayMemberPath))
			{
				container.SetValue(contentProperty, item);
			}
			else
			{
				container.SetBinding(contentProperty, new Binding
				{
					Path = displayMemberPath,
					Source = item
				});
			}
		}
	}

	private void TryRepairContentConnection(ContentControl container, object item)
	{
		if (item is UIElement uIElement && container.DataContext == uIElement && uIElement.GetVisualTreeParent() == null)
		{
			container.DataContext = null;
		}
	}

	protected virtual bool IsItemItsOwnContainerOverride(object item)
	{
		return item is IFrameworkElement;
	}

	internal void PrepareContainerForIndex(DependencyObject container, int index)
	{
		_containerBeingPrepared = container;
		container.SetValue(IndexForItemContainerProperty, index);
		object item = ItemFromIndex(index);
		PrepareContainerForItemOverride(container, item);
		ContainerPreparedForItem(item, container as SelectorItem, index);
		_containerBeingPrepared = null;
	}

	internal virtual void ContainerPreparedForItem(object item, SelectorItem itemContainer, int itemIndex)
	{
	}

	internal DependencyObject GetContainerForIndex(int index)
	{
		object obj = ItemFromIndex(index);
		if (IsItemItsOwnContainerOverride(obj))
		{
			DependencyObject dependencyObject = obj as DependencyObject;
			dependencyObject.SetValue(ItemsControlForItemContainerProperty, new WeakReference<ItemsControl>(this));
			return dependencyObject;
		}
		DataTemplate template = DataTemplateHelper.ResolveTemplate(ItemTemplate, ItemTemplateSelector, obj, null);
		return GetContainerForTemplate(template);
	}

	internal DependencyObject GetContainerForTemplate(DataTemplate template)
	{
		DependencyObject dependencyObject = GetRootOfItemTemplateAsContainer(template) ?? GetContainerForItemOverride();
		dependencyObject.SetValue(ItemsControlForItemContainerProperty, new WeakReference<ItemsControl>(this));
		return dependencyObject;
	}

	private protected virtual DependencyObject GetRootOfItemTemplateAsContainer(DataTemplate template)
	{
		return null;
	}

	public object ItemFromContainer(DependencyObject container)
	{
		int num = IndexFromContainer(container);
		if (num > -1)
		{
			return ItemFromIndex(num);
		}
		if (Items.Contains(container))
		{
			return container;
		}
		return null;
	}

	public DependencyObject ContainerFromItem(object item)
	{
		if (IsItemItsOwnContainer(item))
		{
			int num = Items.IndexOf(item);
			if (num < 0)
			{
				return null;
			}
			return item as DependencyObject;
		}
		int index = IndexFromItem(item);
		if (index != -1)
		{
			return MaterializedContainers.FirstOrDefault((DependencyObject materializedContainer) => object.Equals(IndexFromContainer(materializedContainer), index));
		}
		return null;
	}

	public int IndexFromContainer(DependencyObject container)
	{
		int num = IndexFromContainerInner(container);
		if (num < 0)
		{
			return Items.IndexOf(container);
		}
		if (_inProgressVectorChange != null)
		{
			if (_inProgressVectorChange.CollectionChange == CollectionChange.ItemRemoved)
			{
				if (num == _inProgressVectorChange.Index)
				{
					return -1;
				}
				if (num > _inProgressVectorChange.Index)
				{
					return num - 1;
				}
			}
			else if (_inProgressVectorChange.CollectionChange == CollectionChange.ItemInserted)
			{
				if (num >= _inProgressVectorChange.Index)
				{
					return num + 1;
				}
			}
			else if ((_inProgressVectorChange.CollectionChange == CollectionChange.ItemChanged && _inProgressVectorChange.Index == num) || _inProgressVectorChange.CollectionChange == CollectionChange.Reset)
			{
				object obj = ItemFromIndex(num);
				if (IsItemItsOwnContainer(obj) && object.Equals(obj, container))
				{
					return num;
				}
				return -1;
			}
		}
		return num;
	}

	internal virtual int IndexFromContainerInner(DependencyObject container)
	{
		return (int)container.GetValue(IndexForItemContainerProperty);
	}

	public DependencyObject ContainerFromIndex(int index)
	{
		object obj = ItemFromIndex(index);
		if (IsItemItsOwnContainer(obj))
		{
			return obj as DependencyObject;
		}
		int inProgressAdjustedIndex = GetInProgressAdjustedIndex(index);
		if (inProgressAdjustedIndex < 0)
		{
			return null;
		}
		return ContainerFromIndexInner(inProgressAdjustedIndex);
	}

	internal virtual DependencyObject ContainerFromIndexInner(int index)
	{
		return MaterializedContainers.FirstOrDefault((DependencyObject materializedContainer) => object.Equals(materializedContainer.GetValue(IndexForItemContainerProperty), index));
	}

	protected int GetInProgressAdjustedIndex(int index)
	{
		int result = index;
		if (_inProgressVectorChange != null)
		{
			if (_inProgressVectorChange.CollectionChange == CollectionChange.ItemRemoved)
			{
				if (index >= _inProgressVectorChange.Index)
				{
					result = index + 1;
				}
			}
			else if (_inProgressVectorChange.CollectionChange == CollectionChange.ItemInserted)
			{
				if (index == _inProgressVectorChange.Index)
				{
					return -1;
				}
				if (index > _inProgressVectorChange.Index)
				{
					result = index - 1;
				}
			}
			else if ((_inProgressVectorChange.CollectionChange == CollectionChange.ItemChanged && _inProgressVectorChange.Index == index) || _inProgressVectorChange.CollectionChange == CollectionChange.Reset)
			{
				result = -1;
			}
		}
		return result;
	}

	internal object ItemFromIndex(int index)
	{
		IEnumerable items = GetItems();
		if (items != null && index >= 0 && index < NumberOfItems)
		{
			return items.ElementAt(index);
		}
		return null;
	}

	internal int IndexFromItem(object item)
	{
		return GetItems()?.IndexOf(item) ?? (-1);
	}

	internal bool IsItemItsOwnContainer(object item)
	{
		return IsItemItsOwnContainerOverride(item);
	}

	internal bool IsIndexItsOwnContainer(int index)
	{
		return IsItemItsOwnContainer(ItemFromIndex(index));
	}

	internal virtual ContentControl GetGroupHeaderContainer(object groupHeader)
	{
		return ContentControl.CreateItemContainer();
	}

	public static ItemsControl ItemsControlFromItemContainer(DependencyObject container)
	{
		return (container.GetValue(ItemsControlForItemContainerProperty) as WeakReference<ItemsControl>)?.GetTarget();
	}

	protected internal virtual IEnumerable<DependencyObject> GetItemsPanelChildren()
	{
		return ItemsPanelRoot?.Children.OfType<DependencyObject>() ?? Enumerable.Empty<DependencyObject>();
	}

	internal object GetDisplayItemFromIndexPath(IndexPath indexPath)
	{
		if (!IsGrouping)
		{
			return GetItemFromIndex(indexPath.Row);
		}
		return GetGroupAtDisplaySection(indexPath.Section)?.GroupItems?[indexPath.Row];
	}

	internal object GetItemFromIndex(int index)
	{
		IEnumerable items = GetItems();
		if (items is IList<object> list)
		{
			return list[index];
		}
		return items?.ElementAtOrDefault(index);
	}

	internal IndexPath GetIndexPathFromItem(object item)
	{
		object obj = UnwrapItemsSource();
		if (IsGrouping)
		{
			return (obj as ICollectionView).GetIndexPathForItem(item);
		}
		int row = GetItems()?.IndexOf(item) ?? (-1);
		return IndexPath.FromRowSection(row, 0);
	}

	internal ICollectionViewGroup GetGroupAtDisplaySection(int displaySection)
	{
		if (!AreEmptyGroupsHidden)
		{
			return GetGroupAt(displaySection);
		}
		return CollectionGroups.Where((object g) => (g as ICollectionViewGroup).GroupItems.Count > 0).ElementAt(displaySection) as ICollectionViewGroup;
	}

	internal ICollectionViewGroup GetGroupAt(int section)
	{
		return CollectionGroups[section] as ICollectionViewGroup;
	}

	internal void SetItemsPresenter(ItemsPresenter itemsPresenter)
	{
		if (_itemsPresenter != itemsPresenter)
		{
			_itemsPresenter = itemsPresenter;
			_itemsPresenter?.SetItemsPanel(InternalItemsPanelRoot);
		}
	}

	internal DataTemplate ResolveItemTemplate(object item)
	{
		return DataTemplateHelper.ResolveTemplate(ItemTemplate, ItemTemplateSelector, item, this);
	}

	protected internal virtual void CleanUpInternalItemsPanel(UIElement panel)
	{
	}

	private protected virtual void Refresh()
	{
	}

	private protected void ChangeSelectorItemsVisualState(bool useTransitions)
	{
		foreach (DependencyObject itemsPanelChild in GetItemsPanelChildren())
		{
			if (itemsPanelChild is SelectorItem selectorItem)
			{
				selectorItem.UpdateVisualState(useTransitions);
			}
		}
	}

	private void ApplyItemContainerStyle(DependencyObject element, object item)
	{
		if (!(element is FrameworkElement frameworkElement))
		{
			return;
		}
		object obj = element.ReadLocalValue(FrameworkElement.StyleProperty);
		bool isStyleSetFromItemsControl = frameworkElement.IsStyleSetFromItemsControl;
		if (obj == DependencyProperty.UnsetValue || isStyleSetFromItemsControl)
		{
			Style style = ItemContainerStyle ?? ItemContainerStyleSelector?.SelectStyle(item, element);
			if (style != null)
			{
				frameworkElement.Style = style;
				frameworkElement.IsStyleSetFromItemsControl = true;
			}
			else
			{
				frameworkElement.ClearValue(FrameworkElement.StyleProperty);
				frameworkElement.IsStyleSetFromItemsControl = false;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected virtual void SyncDataContext()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SetNeedsUpdateItems()
	{
		UpdateItems();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool UpdateItemsIfNeeded()
	{
		return UpdateItems();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected virtual bool UpdateItems()
	{
		UpdateItems(null);
		return true;
	}

	protected virtual void OnDisplayMemberPathChanged(string oldDisplayMemberPath, string newDisplayMemberPath)
	{
		OnDisplayMemberPathChangedPartial(oldDisplayMemberPath, newDisplayMemberPath);
	}

	private void OnDisplayMemberPathChangedPartial(string oldDisplayMemberPath, string newDisplayMemberPath)
	{
		if (!string.IsNullOrEmpty(oldDisplayMemberPath) || !string.IsNullOrEmpty(newDisplayMemberPath))
		{
			Refresh();
		}
	}
}

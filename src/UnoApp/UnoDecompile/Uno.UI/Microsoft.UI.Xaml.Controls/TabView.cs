using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Input;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Uno.UI.Helpers.WinUI;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Microsoft.UI.Xaml.Controls;

[ContentProperty(Name = "TabItems")]
public class TabView : Control
{
	private const double c_tabMinimumWidth = 48.0;

	private const double c_tabMaximumWidth = 200.0;

	private const string c_tabViewItemMinWidthName = "TabViewItemMinWidth";

	private const string c_tabViewItemMaxWidthName = "TabViewItemMaxWidth";

	private const double c_scrollAmount = 50.0;

	internal const double c_tabShadowDepth = 16.0;

	internal const string c_tabViewShadowDepthName = "TabViewShadowDepth";

	private bool m_updateTabWidthOnPointerLeave;

	private bool m_pointerInTabstrip;

	private ColumnDefinition m_leftContentColumn;

	private ColumnDefinition m_tabColumn;

	private ColumnDefinition m_addButtonColumn;

	private ColumnDefinition m_rightContentColumn;

	private ListView m_listView;

	private ContentPresenter m_tabContentPresenter;

	private ContentPresenter m_rightContentPresenter;

	private Grid m_tabContainerGrid;

	private ScrollViewer m_scrollViewer;

	private RepeatButton m_scrollDecreaseButton;

	private RepeatButton m_scrollIncreaseButton;

	private Button m_addButton;

	private ItemsPresenter m_itemsPresenter;

	private Grid m_shadowReceiver;

	private readonly SerialDisposable m_listViewLoadedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_tabStripPointerExitedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_tabStripPointerEnteredRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewSelectionChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewGettingFocusRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewCanReorderItemsPropertyChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewAllowDropPropertyChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewDragItemsStartingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewDragItemsCompletedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewDragOverRevoker = new SerialDisposable();

	private readonly SerialDisposable m_listViewDropRevoker = new SerialDisposable();

	private readonly SerialDisposable m_scrollViewerLoadedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_scrollViewerViewChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_addButtonClickRevoker = new SerialDisposable();

	private readonly SerialDisposable m_scrollDecreaseClickRevoker = new SerialDisposable();

	private readonly SerialDisposable m_scrollIncreaseClickRevoker = new SerialDisposable();

	private readonly SerialDisposable m_itemsPresenterSizeChangedRevoker = new SerialDisposable();

	private DispatcherHelper m_dispatcherHelper;

	private string m_tabCloseButtonTooltipText;

	private Size previousAvailableSize;

	private readonly SerialDisposable m_ScrollViewerScrollableWidthPropertyChangedRevoker = new SerialDisposable();

	public ICommand AddTabButtonCommand
	{
		get
		{
			return (ICommand)GetValue(AddTabButtonCommandProperty);
		}
		set
		{
			SetValue(AddTabButtonCommandProperty, value);
		}
	}

	public static DependencyProperty AddTabButtonCommandProperty { get; } = DependencyProperty.Register("AddTabButtonCommand", typeof(ICommand), typeof(TabView), new FrameworkPropertyMetadata(null));


	public object AddTabButtonCommandParameter
	{
		get
		{
			return GetValue(AddTabButtonCommandParameterProperty);
		}
		set
		{
			SetValue(AddTabButtonCommandParameterProperty, value);
		}
	}

	public static DependencyProperty AddTabButtonCommandParameterProperty { get; } = DependencyProperty.Register("AddTabButtonCommandParameter", typeof(object), typeof(TabView), new FrameworkPropertyMetadata(null));


	public bool AllowDropTabs
	{
		get
		{
			return (bool)GetValue(AllowDropTabsProperty);
		}
		set
		{
			SetValue(AllowDropTabsProperty, value);
		}
	}

	public static DependencyProperty AllowDropTabsProperty { get; } = DependencyProperty.Register("AllowDropTabs", typeof(bool), typeof(TabView), new FrameworkPropertyMetadata(true));


	public bool CanDragTabs
	{
		get
		{
			return (bool)GetValue(CanDragTabsProperty);
		}
		set
		{
			SetValue(CanDragTabsProperty, value);
		}
	}

	public static DependencyProperty CanDragTabsProperty { get; } = DependencyProperty.Register("CanDragTabs", typeof(bool), typeof(TabView), new FrameworkPropertyMetadata(false));


	public bool CanReorderTabs
	{
		get
		{
			return (bool)GetValue(CanReorderTabsProperty);
		}
		set
		{
			SetValue(CanReorderTabsProperty, value);
		}
	}

	public static DependencyProperty CanReorderTabsProperty { get; } = DependencyProperty.Register("CanReorderTabs", typeof(bool), typeof(TabView), new FrameworkPropertyMetadata(true));


	public TabViewCloseButtonOverlayMode CloseButtonOverlayMode
	{
		get
		{
			return (TabViewCloseButtonOverlayMode)GetValue(CloseButtonOverlayModeProperty);
		}
		set
		{
			SetValue(CloseButtonOverlayModeProperty, value);
		}
	}

	public static DependencyProperty CloseButtonOverlayModeProperty { get; } = DependencyProperty.Register("CloseButtonOverlayMode", typeof(TabViewCloseButtonOverlayMode), typeof(TabView), new FrameworkPropertyMetadata(TabViewCloseButtonOverlayMode.Auto, OnCloseButtonOverlayModePropertyChanged));


	public bool IsAddTabButtonVisible
	{
		get
		{
			return (bool)GetValue(IsAddTabButtonVisibleProperty);
		}
		set
		{
			SetValue(IsAddTabButtonVisibleProperty, value);
		}
	}

	public static DependencyProperty IsAddTabButtonVisibleProperty { get; } = DependencyProperty.Register("IsAddTabButtonVisible", typeof(bool), typeof(TabView), new FrameworkPropertyMetadata(true));


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

	public static DependencyProperty SelectedIndexProperty { get; } = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(TabView), new FrameworkPropertyMetadata(0, OnSelectedIndexPropertyChanged));


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

	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(TabView), new FrameworkPropertyMetadata(null, OnSelectedItemPropertyChanged));


	public IList<object> TabItems
	{
		get
		{
			return (IList<object>)GetValue(TabItemsProperty);
		}
		private set
		{
			SetValue(TabItemsProperty, value);
		}
	}

	public static DependencyProperty TabItemsProperty { get; } = DependencyProperty.Register("TabItems", typeof(IList<object>), typeof(TabView), new FrameworkPropertyMetadata(null));


	public object TabItemsSource
	{
		get
		{
			return GetValue(TabItemsSourceProperty);
		}
		set
		{
			SetValue(TabItemsSourceProperty, value);
		}
	}

	public static DependencyProperty TabItemsSourceProperty { get; } = DependencyProperty.Register("TabItemsSource", typeof(object), typeof(TabView), new FrameworkPropertyMetadata(null, OnTabItemsSourcePropertyChanged));


	public DataTemplate TabItemTemplate
	{
		get
		{
			return (DataTemplate)GetValue(TabItemTemplateProperty);
		}
		set
		{
			SetValue(TabItemTemplateProperty, value);
		}
	}

	public static DependencyProperty TabItemTemplateProperty { get; } = DependencyProperty.Register("TabItemTemplate", typeof(DataTemplate), typeof(TabView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public DataTemplateSelector TabItemTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)GetValue(TabItemTemplateSelectorProperty);
		}
		set
		{
			SetValue(TabItemTemplateSelectorProperty, value);
		}
	}

	public static DependencyProperty TabItemTemplateSelectorProperty { get; } = DependencyProperty.Register("TabItemTemplateSelector", typeof(DataTemplateSelector), typeof(TabView), new FrameworkPropertyMetadata(null));


	public object TabStripFooter
	{
		get
		{
			return GetValue(TabStripFooterProperty);
		}
		set
		{
			SetValue(TabStripFooterProperty, value);
		}
	}

	public static DependencyProperty TabStripFooterProperty { get; } = DependencyProperty.Register("TabStripFooter", typeof(object), typeof(TabView), new FrameworkPropertyMetadata(null));


	public DataTemplate TabStripFooterTemplate
	{
		get
		{
			return (DataTemplate)GetValue(TabStripFooterTemplateProperty);
		}
		set
		{
			SetValue(TabStripFooterTemplateProperty, value);
		}
	}

	public static DependencyProperty TabStripFooterTemplateProperty { get; } = DependencyProperty.Register("TabStripFooterTemplate", typeof(DataTemplate), typeof(TabView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public object TabStripHeader
	{
		get
		{
			return GetValue(TabStripHeaderProperty);
		}
		set
		{
			SetValue(TabStripHeaderProperty, value);
		}
	}

	public static DependencyProperty TabStripHeaderProperty { get; } = DependencyProperty.Register("TabStripHeader", typeof(object), typeof(TabView), new FrameworkPropertyMetadata(null));


	public DataTemplate TabStripHeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(TabStripHeaderTemplateProperty);
		}
		set
		{
			SetValue(TabStripHeaderTemplateProperty, value);
		}
	}

	public static DependencyProperty TabStripHeaderTemplateProperty { get; } = DependencyProperty.Register("TabStripHeaderTemplate", typeof(DataTemplate), typeof(TabView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public TabViewWidthMode TabWidthMode
	{
		get
		{
			return (TabViewWidthMode)GetValue(TabWidthModeProperty);
		}
		set
		{
			SetValue(TabWidthModeProperty, value);
		}
	}

	public static DependencyProperty TabWidthModeProperty { get; } = DependencyProperty.Register("TabWidthMode", typeof(TabViewWidthMode), typeof(TabView), new FrameworkPropertyMetadata(TabViewWidthMode.Equal, OnTabWidthModePropertyChanged));


	public event TypedEventHandler<TabView, object> AddTabButtonClick;

	public event SelectionChangedEventHandler SelectionChanged;

	public event TypedEventHandler<TabView, TabViewTabCloseRequestedEventArgs> TabCloseRequested;

	public event TypedEventHandler<TabView, TabViewTabDragCompletedEventArgs> TabDragCompleted;

	public event TypedEventHandler<TabView, TabViewTabDragStartingEventArgs> TabDragStarting;

	public event TypedEventHandler<TabView, TabViewTabDroppedOutsideEventArgs> TabDroppedOutside;

	public event TypedEventHandler<TabView, IVectorChangedEventArgs> TabItemsChanged;

	public event DragEventHandler TabStripDragOver;

	public event DragEventHandler TabStripDrop;

	public TabView()
	{
		m_dispatcherHelper = new DispatcherHelper(this);
		ObservableVector<object> value = new ObservableVector<object>();
		SetValue(TabItemsProperty, value);
		SetDefaultStyleKey(this);
		base.Loaded += OnLoaded;
		if (SharedHelpers.IsRS3OrHigher())
		{
			KeyboardAccelerator keyboardAccelerator = new KeyboardAccelerator();
			keyboardAccelerator.Key = VirtualKey.F4;
			keyboardAccelerator.Modifiers = VirtualKeyModifiers.Control;
			keyboardAccelerator.Invoked += OnCtrlF4Invoked;
			keyboardAccelerator.ScopeOwner = this;
			base.KeyboardAccelerators.Add(keyboardAccelerator);
			m_tabCloseButtonTooltipText = ResourceAccessor.GetLocalizedStringResource("TabViewCloseButtonTooltipWithKA");
		}
		else
		{
			m_tabCloseButtonTooltipText = ResourceAccessor.GetLocalizedStringResource("TabViewCloseButtonTooltip");
		}
		if (SharedHelpers.Is19H1OrHigher())
		{
			KeyboardAccelerator keyboardAccelerator2 = new KeyboardAccelerator();
			keyboardAccelerator2.Key = VirtualKey.Tab;
			keyboardAccelerator2.Modifiers = VirtualKeyModifiers.Control;
			keyboardAccelerator2.Invoked += OnCtrlTabInvoked;
			keyboardAccelerator2.ScopeOwner = this;
			base.KeyboardAccelerators.Add(keyboardAccelerator2);
			KeyboardAccelerator keyboardAccelerator3 = new KeyboardAccelerator();
			keyboardAccelerator3.Key = VirtualKey.Tab;
			keyboardAccelerator3.Modifiers = VirtualKeyModifiers.Control | VirtualKeyModifiers.Shift;
			keyboardAccelerator3.Invoked += OnCtrlShiftTabInvoked;
			keyboardAccelerator3.ScopeOwner = this;
			base.KeyboardAccelerators.Add(keyboardAccelerator3);
		}
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		UnhookEventsAndClearFields();
		m_tabContentPresenter = (ContentPresenter)GetTemplateChild("TabContentPresenter");
		m_rightContentPresenter = (ContentPresenter)GetTemplateChild("RightContentPresenter");
		m_leftContentColumn = (ColumnDefinition)GetTemplateChild("LeftContentColumn");
		m_tabColumn = (ColumnDefinition)GetTemplateChild("TabColumn");
		m_addButtonColumn = (ColumnDefinition)GetTemplateChild("AddButtonColumn");
		m_rightContentColumn = (ColumnDefinition)GetTemplateChild("RightContentColumn");
		Grid containerGrid = GetTemplateChild<Grid>("TabContainerGrid");
		if (containerGrid != null)
		{
			m_tabContainerGrid = containerGrid;
			containerGrid.PointerExited += OnTabStripPointerExited;
			m_tabStripPointerExitedRevoker.Disposable = Disposable.Create(delegate
			{
				containerGrid.PointerExited -= OnTabStripPointerExited;
			});
			containerGrid.PointerEntered += OnTabStripPointerEntered;
			m_tabStripPointerEnteredRevoker.Disposable = Disposable.Create(delegate
			{
				containerGrid.PointerEntered -= OnTabStripPointerEntered;
			});
		}
		if (!SharedHelpers.Is21H1OrHigher())
		{
			m_shadowReceiver = (Grid)GetTemplateChild("ShadowReceiver");
		}
		m_listView = GetListView();
		m_addButton = GetAddButton();
		if (SharedHelpers.IsThemeShadowAvailable() && !SharedHelpers.Is21H1OrHigher() && GetTemplateChild("ShadowCaster") is Grid grid)
		{
			ThemeShadow themeShadow = new ThemeShadow();
			themeShadow.Receivers.Add(GetShadowReceiver());
			double num = (double)SharedHelpers.FindInApplicationResources("TabViewShadowDepth", 16.0);
			Vector3 translation = grid.Translation;
			Vector3 vector2 = (grid.Translation = new Vector3(translation.X, translation.Y, (float)num));
			grid.Shadow = themeShadow;
		}
		UpdateListViewItemContainerTransitions();
		Button GetAddButton()
		{
			Button addButton = GetTemplateChild("AddButton") as Button;
			if (addButton != null)
			{
				if (string.IsNullOrEmpty(AutomationProperties.GetName(addButton)))
				{
					string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("TabViewAddButtonName");
					AutomationProperties.SetName(addButton, localizedStringResource);
				}
				object toolTip = ToolTipService.GetToolTip(addButton);
				if (toolTip == null)
				{
					ToolTip value = new ToolTip
					{
						Content = ResourceAccessor.GetLocalizedStringResource("TabViewAddButtonTooltip")
					};
					ToolTipService.SetToolTip(addButton, value);
				}
				addButton.Click += OnAddButtonClick;
				m_addButtonClickRevoker.Disposable = Disposable.Create(delegate
				{
					addButton.Click -= OnAddButtonClick;
				});
			}
			return addButton;
		}
		ListView GetListView()
		{
			ListView listView = GetTemplateChild("TabListView") as ListView;
			if (listView != null)
			{
				listView.Loaded += OnListViewLoaded;
				m_listViewLoadedRevoker.Disposable = Disposable.Create(delegate
				{
					listView.Loaded -= OnListViewLoaded;
				});
				listView.SelectionChanged += OnListViewSelectionChanged;
				m_listViewSelectionChangedRevoker.Disposable = Disposable.Create(delegate
				{
					listView.SelectionChanged -= OnListViewSelectionChanged;
				});
				listView.DragItemsStarting += new DragItemsStartingEventHandler(OnListViewDragItemsStarting);
				m_listViewDragItemsStartingRevoker.Disposable = Disposable.Create(delegate
				{
					listView.DragItemsStarting -= new DragItemsStartingEventHandler(OnListViewDragItemsStarting);
				});
				listView.DragItemsCompleted += new TypedEventHandler<ListViewBase, DragItemsCompletedEventArgs>(OnListViewDragItemsCompleted);
				m_listViewDragItemsCompletedRevoker.Disposable = Disposable.Create(delegate
				{
					listView.DragItemsCompleted -= new TypedEventHandler<ListViewBase, DragItemsCompletedEventArgs>(OnListViewDragItemsCompleted);
				});
				listView.DragOver += OnListViewDragOver;
				m_listViewDragOverRevoker.Disposable = Disposable.Create(delegate
				{
					listView.DragOver -= OnListViewDragOver;
				});
				listView.Drop += OnListViewDrop;
				m_listViewDropRevoker.Disposable = Disposable.Create(delegate
				{
					listView.Drop -= OnListViewDrop;
				});
				listView.GettingFocus += OnListViewGettingFocus;
				m_listViewGettingFocusRevoker.Disposable = Disposable.Create(delegate
				{
					listView.GettingFocus -= OnListViewGettingFocus;
				});
				long canReorderItemsToken = listView.RegisterPropertyChangedCallback(ListViewBase.CanReorderItemsProperty, OnListViewDraggingPropertyChanged);
				m_listViewCanReorderItemsPropertyChangedRevoker.Disposable = Disposable.Create(delegate
				{
					listView.UnregisterPropertyChangedCallback(ListViewBase.CanReorderItemsProperty, canReorderItemsToken);
				});
				long allowDropToken = listView.RegisterPropertyChangedCallback(UIElement.AllowDropProperty, OnListViewDraggingPropertyChanged);
				m_listViewAllowDropPropertyChangedRevoker.Disposable = Disposable.Create(delegate
				{
					listView.UnregisterPropertyChangedCallback(UIElement.AllowDropProperty, allowDropToken);
				});
			}
			return listView;
		}
	}

	internal void SetTabSeparatorOpacity(int index, int opacityValue)
	{
		if (ContainerFromIndex(index) is TabViewItem tabViewItem && tabViewItem.GetTemplateChild("TabSeparator") is FrameworkElement frameworkElement)
		{
			frameworkElement.Opacity = opacityValue;
		}
	}

	internal void SetTabSeparatorOpacity(int index)
	{
		int selectedIndex = SelectedIndex;
		if (index == selectedIndex || index + 1 == selectedIndex)
		{
			SetTabSeparatorOpacity(index, 0);
		}
		else
		{
			SetTabSeparatorOpacity(index, 1);
		}
	}

	private void OnListViewDraggingPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		UpdateListViewItemContainerTransitions();
	}

	private void OnListViewGettingFocus(object sender, GettingFocusEventArgs args)
	{
		FocusNavigationDirection direction = args.Direction;
		if (direction != FocusNavigationDirection.Up && direction != FocusNavigationDirection.Down)
		{
			return;
		}
		TabViewItem tabViewItem = args.OldFocusedElement as TabViewItem;
		TabViewItem tabViewItem2 = args.NewFocusedElement as TabViewItem;
		if (tabViewItem == null || tabViewItem2 == null)
		{
			return;
		}
		ListView listView = m_listView;
		if (listView == null)
		{
			return;
		}
		bool flag = listView.IndexFromContainer(tabViewItem) != -1;
		bool flag2 = listView.IndexFromContainer(tabViewItem2) != -1;
		if (!(flag && flag2))
		{
			return;
		}
		FocusInputDeviceKind inputDevice = args.InputDevice;
		if (inputDevice == FocusInputDeviceKind.GameController)
		{
			Rect rect = new Rect(0.0, 0.0, (float)listView.ActualWidth, (float)listView.ActualHeight);
			Rect exclusionRect = listView.TransformToVisual(null).TransformBounds(rect);
			FindNextElementOptions findNextElementOptions = new FindNextElementOptions();
			findNextElementOptions.ExclusionRect = exclusionRect;
			DependencyObject next = FocusManager.FindNextElement(direction, findNextElementOptions);
			if (args != null)
			{
				args.TrySetNewFocusedElement(next);
			}
			else
			{
				m_dispatcherHelper.RunAsync(delegate
				{
					CppWinRTHelpers.SetFocus(next, FocusState.Programmatic);
				});
			}
			args.Handled = true;
		}
		else
		{
			args.Cancel = true;
			args.Handled = true;
		}
	}

	private void OnSelectedIndexPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateSelectedIndex();
		SetTabSeparatorOpacity((int)args.OldValue);
		SetTabSeparatorOpacity((int)args.OldValue - 1);
		SetTabSeparatorOpacity(SelectedIndex - 1);
		SetTabSeparatorOpacity(SelectedIndex);
	}

	private void OnSelectedItemPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateSelectedItem();
	}

	private void OnTabItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateListViewItemContainerTransitions();
	}

	private void UpdateListViewItemContainerTransitions()
	{
		if (TabItemsSource == null)
		{
			return;
		}
		ListView listView2 = m_listView;
		if (listView2 == null || !listView2.CanReorderItems || !listView2.AllowDrop || !GetTransitionCollectionHasAddDeleteOrContentThemeTransition(listView2))
		{
			return;
		}
		TransitionCollection transitionCollection = new TransitionCollection();
		TransitionCollection itemContainerTransitions = listView2.ItemContainerTransitions;
		foreach (Transition item in itemContainerTransitions)
		{
			if (item != null && !(item is AddDeleteThemeTransition) && !(item is ContentThemeTransition))
			{
				transitionCollection.Add(item);
			}
		}
		listView2.ItemContainerTransitions = transitionCollection;
		static bool GetTransitionCollectionHasAddDeleteOrContentThemeTransition(ListView listView)
		{
			TransitionCollection itemContainerTransitions2 = listView.ItemContainerTransitions;
			if (itemContainerTransitions2 != null)
			{
				foreach (Transition item2 in itemContainerTransitions2)
				{
					if (item2 != null && (item2 is AddDeleteThemeTransition || item2 is ContentThemeTransition))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	private void UnhookEventsAndClearFields()
	{
		m_listViewLoadedRevoker.Disposable = null;
		m_listViewSelectionChangedRevoker.Disposable = null;
		m_listViewDragItemsStartingRevoker.Disposable = null;
		m_listViewDragItemsCompletedRevoker.Disposable = null;
		m_listViewDragOverRevoker.Disposable = null;
		m_listViewDropRevoker.Disposable = null;
		m_listViewGettingFocusRevoker.Disposable = null;
		m_listViewCanReorderItemsPropertyChangedRevoker.Disposable = null;
		m_listViewAllowDropPropertyChangedRevoker.Disposable = null;
		m_addButtonClickRevoker.Disposable = null;
		m_itemsPresenterSizeChangedRevoker.Disposable = null;
		m_tabStripPointerExitedRevoker.Disposable = null;
		m_tabStripPointerEnteredRevoker.Disposable = null;
		m_scrollViewerLoadedRevoker.Disposable = null;
		m_scrollViewerViewChangedRevoker.Disposable = null;
		m_scrollDecreaseClickRevoker.Disposable = null;
		m_scrollIncreaseClickRevoker.Disposable = null;
		m_tabContentPresenter = null;
		m_rightContentPresenter = null;
		m_leftContentColumn = null;
		m_tabColumn = null;
		m_addButtonColumn = null;
		m_rightContentColumn = null;
		m_tabContainerGrid = null;
		m_shadowReceiver = null;
		m_listView = null;
		m_addButton = null;
		m_itemsPresenter = null;
		m_scrollViewer = null;
		m_scrollDecreaseButton = null;
		m_scrollIncreaseButton = null;
	}

	private void OnTabWidthModePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateTabWidths();
		foreach (object tabItem in TabItems)
		{
			GetTabViewItem(tabItem)?.OnTabViewWidthModeChanged(TabWidthMode);
		}
		TabViewItem GetTabViewItem(object item)
		{
			if (item is TabViewItem result)
			{
				return result;
			}
			return ContainerFromItem(item) as TabViewItem;
		}
	}

	private void OnCloseButtonOverlayModePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		foreach (object tabItem in TabItems)
		{
			GetTabViewItem(tabItem)?.OnCloseButtonOverlayModeChanged(CloseButtonOverlayMode);
		}
		TabViewItem GetTabViewItem(object item)
		{
			if (item is TabViewItem result)
			{
				return result;
			}
			return ContainerFromItem(item) as TabViewItem;
		}
	}

	private void OnAddButtonClick(object sender, RoutedEventArgs args)
	{
		this.AddTabButtonClick?.Invoke(this, args);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new TabViewAutomationPeer(this);
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		UpdateTabContent();
	}

	private void OnListViewLoaded(object sender, RoutedEventArgs args)
	{
		ListView listView2 = m_listView;
		if (listView2 == null)
		{
			return;
		}
		ItemCollection items = listView2.Items;
		if (items != null)
		{
			if (listView2.ItemsSource == null)
			{
				List<object> list = new List<object>();
				foreach (object tabItem in TabItems)
				{
					list.Add(tabItem);
				}
				items.Clear();
				foreach (object item in list)
				{
					if (item != null)
					{
						items.Add(item);
					}
				}
			}
			TabItems = items;
		}
		if (ReadLocalValue(SelectedItemProperty) != DependencyProperty.UnsetValue)
		{
			UpdateSelectedItem();
		}
		else
		{
			UpdateSelectedIndex();
		}
		SelectedIndex = listView2.SelectedIndex;
		SelectedItem = listView2.SelectedItem;
		m_itemsPresenter = GetItemsPresenter(listView2);
		ScrollViewer scrollViewer = SharedHelpers.FindInVisualTreeByName(listView2, "ScrollViewer") as ScrollViewer;
		m_scrollViewer = scrollViewer;
		if (scrollViewer == null)
		{
			return;
		}
		if (SharedHelpers.IsIsLoadedAvailable() && scrollViewer.IsLoaded)
		{
			OnScrollViewerLoaded(null, null);
		}
		else
		{
			scrollViewer.Loaded += OnScrollViewerLoaded;
			m_scrollViewerLoadedRevoker.Disposable = Disposable.Create(delegate
			{
				scrollViewer.Loaded -= OnScrollViewerLoaded;
			});
		}
		long scrollViewerScrollableWidthToken = scrollViewer.RegisterPropertyChangedCallback(ScrollViewer.ScrollableWidthProperty, delegate
		{
			UpdateScrollViewerDecreaseAndIncreaseButtonsViewState();
		});
		m_ScrollViewerScrollableWidthPropertyChangedRevoker.Disposable = Disposable.Create(delegate
		{
			scrollViewer.UnregisterPropertyChangedCallback(ScrollViewer.ScrollableWidthProperty, scrollViewerScrollableWidthToken);
		});
		ItemsPresenter GetItemsPresenter(ListView listView)
		{
			ItemsPresenter itemsPresenter = SharedHelpers.FindInVisualTreeByName(listView, "TabsItemsPresenter") as ItemsPresenter;
			if (itemsPresenter != null)
			{
				itemsPresenter.SizeChanged += OnItemsPresenterSizeChanged;
				m_itemsPresenterSizeChangedRevoker.Disposable = Disposable.Create(delegate
				{
					itemsPresenter.SizeChanged -= OnItemsPresenterSizeChanged;
				});
			}
			return itemsPresenter;
		}
	}

	private void OnTabStripPointerExited(object sender, PointerRoutedEventArgs args)
	{
		m_pointerInTabstrip = false;
		if (m_updateTabWidthOnPointerLeave)
		{
			try
			{
				UpdateTabWidths();
			}
			finally
			{
				m_updateTabWidthOnPointerLeave = false;
			}
		}
	}

	private void OnTabStripPointerEntered(object sender, PointerRoutedEventArgs args)
	{
		m_pointerInTabstrip = true;
	}

	private void OnScrollViewerLoaded(object sender, RoutedEventArgs args)
	{
		ScrollViewer scrollViewer2 = m_scrollViewer;
		if (scrollViewer2 != null)
		{
			m_scrollDecreaseButton = GetDecreaseButton(scrollViewer2);
			m_scrollIncreaseButton = GetIncreaseButton(scrollViewer2);
			scrollViewer2.ViewChanged += new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollViewerViewChanged);
			m_scrollViewerViewChangedRevoker.Disposable = Disposable.Create(delegate
			{
				scrollViewer2.ViewChanged -= new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollViewerViewChanged);
			});
		}
		UpdateTabWidths();
		RepeatButton GetDecreaseButton(ScrollViewer scrollViewer)
		{
			RepeatButton decreaseButton = SharedHelpers.FindInVisualTreeByName(scrollViewer, "ScrollDecreaseButton") as RepeatButton;
			if (decreaseButton != null)
			{
				object toolTip2 = ToolTipService.GetToolTip(decreaseButton);
				if (toolTip2 == null)
				{
					ToolTip value2 = new ToolTip
					{
						Content = ResourceAccessor.GetLocalizedStringResource("TabViewScrollDecreaseButtonTooltip")
					};
					ToolTipService.SetToolTip(decreaseButton, value2);
				}
				decreaseButton.Click += OnScrollDecreaseClick;
				m_scrollDecreaseClickRevoker.Disposable = Disposable.Create(delegate
				{
					decreaseButton.Click -= OnScrollDecreaseClick;
				});
			}
			return decreaseButton;
		}
		RepeatButton GetIncreaseButton(ScrollViewer scrollViewer)
		{
			RepeatButton increaseButton = SharedHelpers.FindInVisualTreeByName(scrollViewer, "ScrollIncreaseButton") as RepeatButton;
			if (increaseButton != null)
			{
				object toolTip = ToolTipService.GetToolTip(increaseButton);
				if (toolTip == null)
				{
					ToolTip value = new ToolTip
					{
						Content = ResourceAccessor.GetLocalizedStringResource("TabViewScrollIncreaseButtonTooltip")
					};
					ToolTipService.SetToolTip(increaseButton, value);
				}
				increaseButton.Click += OnScrollIncreaseClick;
				m_scrollIncreaseClickRevoker.Disposable = Disposable.Create(delegate
				{
					increaseButton.Click -= OnScrollIncreaseClick;
				});
			}
			return increaseButton;
		}
	}

	private void OnScrollViewerViewChanged(object sender, ScrollViewerViewChangedEventArgs args)
	{
		UpdateScrollViewerDecreaseAndIncreaseButtonsViewState();
	}

	private void UpdateScrollViewerDecreaseAndIncreaseButtonsViewState()
	{
		ScrollViewer scrollViewer = m_scrollViewer;
		if (scrollViewer == null)
		{
			return;
		}
		RepeatButton scrollDecreaseButton = m_scrollDecreaseButton;
		RepeatButton scrollIncreaseButton = m_scrollIncreaseButton;
		double num = 0.1;
		double horizontalOffset = scrollViewer.HorizontalOffset;
		double scrollableWidth = scrollViewer.ScrollableWidth;
		if (Math.Abs(horizontalOffset - scrollableWidth) < num)
		{
			if (scrollDecreaseButton != null)
			{
				scrollDecreaseButton.IsEnabled = true;
			}
			if (scrollIncreaseButton != null)
			{
				scrollIncreaseButton.IsEnabled = false;
			}
		}
		else if (Math.Abs(horizontalOffset) < num)
		{
			if (scrollDecreaseButton != null)
			{
				scrollDecreaseButton.IsEnabled = false;
			}
			if (scrollIncreaseButton != null)
			{
				scrollIncreaseButton.IsEnabled = true;
			}
		}
		else
		{
			if (scrollDecreaseButton != null)
			{
				scrollDecreaseButton.IsEnabled = true;
			}
			if (scrollIncreaseButton != null)
			{
				scrollIncreaseButton.IsEnabled = true;
			}
		}
	}

	private void OnItemsPresenterSizeChanged(object sender, SizeChangedEventArgs args)
	{
		if (!m_updateTabWidthOnPointerLeave)
		{
			UpdateScrollViewerDecreaseAndIncreaseButtonsViewState();
			UpdateTabWidths();
		}
	}

	internal void OnItemsChanged(object item, TabViewListView tabListView)
	{
		if (!(item is IVectorChangedEventArgs vectorChangedEventArgs))
		{
			return;
		}
		this.TabItemsChanged?.Invoke(this, vectorChangedEventArgs);
		int count = TabItems.Count;
		int selectedIndex = (m_listView ?? tabListView).SelectedIndex;
		int num = SelectedIndex;
		if (num != selectedIndex && selectedIndex != -1)
		{
			SelectedIndex = selectedIndex;
			num = selectedIndex;
		}
		if (vectorChangedEventArgs.CollectionChange == CollectionChange.ItemRemoved)
		{
			m_updateTabWidthOnPointerLeave = true;
			if (count > 0 && (num == -1 || num == vectorChangedEventArgs.Index))
			{
				int num2 = (int)vectorChangedEventArgs.Index;
				if (num2 >= count)
				{
					num2 = count - 1;
				}
				int num3 = num2;
				do
				{
					if (ContainerFromIndex(num3) is ListViewItem listViewItem && listViewItem.IsEnabled && listViewItem.Visibility == Visibility.Visible)
					{
						SelectedItem = TabItems[num3];
						break;
					}
					num3++;
					if (num3 >= count)
					{
						num3 = 0;
					}
				}
				while (num3 != num2);
			}
			if (TabWidthMode == TabViewWidthMode.Equal && (!m_pointerInTabstrip || vectorChangedEventArgs.Index == TabItems.Count))
			{
				UpdateTabWidths(shouldUpdateWidths: true, fillAllAvailableSpace: false);
			}
		}
		else
		{
			UpdateTabWidths();
			SetTabSeparatorOpacity(count - 1);
		}
	}

	private void OnListViewSelectionChanged(object sender, SelectionChangedEventArgs args)
	{
		ListView listView = m_listView;
		if (listView != null)
		{
			SelectedIndex = listView.SelectedIndex;
			SelectedItem = listView.SelectedItem;
		}
		UpdateTabContent();
		this.SelectionChanged?.Invoke(this, args);
	}

	private TabViewItem FindTabViewItemFromDragItem(object item)
	{
		TabViewItem tabViewItem = ContainerFromItem(item) as TabViewItem;
		if (tabViewItem == null && item is FrameworkElement reference)
		{
			tabViewItem = VisualTreeHelper.GetParent(reference) as TabViewItem;
		}
		if (tabViewItem == null)
		{
			int count = TabItems.Count;
			for (int i = 0; i < count; i++)
			{
				TabViewItem tabViewItem2 = ContainerFromIndex(i) as TabViewItem;
				if (tabViewItem2.Content == item)
				{
					tabViewItem = tabViewItem2;
					break;
				}
			}
		}
		return tabViewItem;
	}

	private void OnListViewDragItemsStarting(object sender, DragItemsStartingEventArgs args)
	{
		object item = args.Items[0];
		TabViewItem tab = FindTabViewItemFromDragItem(item);
		TabViewTabDragStartingEventArgs args2 = new TabViewTabDragStartingEventArgs(args, item, tab);
		this.TabDragStarting?.Invoke(this, args2);
	}

	private void OnListViewDragOver(object sender, DragEventArgs args)
	{
		this.TabStripDragOver?.Invoke(this, args);
	}

	private void OnListViewDrop(object sender, DragEventArgs args)
	{
		this.TabStripDrop?.Invoke(this, args);
	}

	private void OnListViewDragItemsCompleted(object sender, DragItemsCompletedEventArgs args)
	{
		object item = args.Items[0];
		TabViewItem tab = FindTabViewItemFromDragItem(item);
		TabViewTabDragCompletedEventArgs args2 = new TabViewTabDragCompletedEventArgs(args, item, tab);
		this.TabDragCompleted?.Invoke(this, args2);
		if (args.DropResult == DataPackageOperation.None)
		{
			TabViewTabDroppedOutsideEventArgs args3 = new TabViewTabDroppedOutsideEventArgs(item, tab);
			this.TabDroppedOutside?.Invoke(this, args3);
		}
	}

	internal void UpdateTabContent()
	{
		ContentPresenter tabContentPresenter = m_tabContentPresenter;
		if (tabContentPresenter == null)
		{
			return;
		}
		if (SelectedItem == null)
		{
			tabContentPresenter.Content = null;
			tabContentPresenter.ContentTemplate = null;
			tabContentPresenter.ContentTemplateSelector = null;
			return;
		}
		TabViewItem tabViewItem = SelectedItem as TabViewItem;
		if (tabViewItem == null)
		{
			tabViewItem = ContainerFromItem(SelectedItem) as TabViewItem;
		}
		if (tabViewItem == null)
		{
			return;
		}
		bool shouldMoveFocusToNewTab = false;
		tabContentPresenter.LosingFocus += OnTabContentPresenterLosingFocus;
		tabContentPresenter.Content = tabViewItem.Content;
		tabContentPresenter.ContentTemplate = tabViewItem.ContentTemplate;
		tabContentPresenter.ContentTemplateSelector = tabViewItem.ContentTemplateSelector;
		tabContentPresenter.DataContext = tabViewItem.DataContext;
		if (shouldMoveFocusToNewTab)
		{
			DependencyObject dependencyObject = FocusManager.FindFirstFocusableElement(tabContentPresenter);
			if (dependencyObject == null)
			{
				dependencyObject = tabViewItem;
			}
			if (dependencyObject != null)
			{
				CppWinRTHelpers.SetFocus(dependencyObject, FocusState.Programmatic);
			}
		}
		void OnTabContentPresenterLosingFocus(object sender, LosingFocusEventArgs args)
		{
			shouldMoveFocusToNewTab = true;
			tabContentPresenter.LosingFocus -= OnTabContentPresenterLosingFocus;
		}
	}

	internal void RequestCloseTab(TabViewItem container, bool updateTabWidths)
	{
		ListView listView = m_listView;
		if (listView != null)
		{
			TabViewTabCloseRequestedEventArgs args = new TabViewTabCloseRequestedEventArgs(listView.ItemFromContainer(container), container);
			this.TabCloseRequested?.Invoke(this, args);
			if (container != null)
			{
				container.RaiseRequestClose(args);
			}
		}
		UpdateTabWidths(updateTabWidths);
	}

	private void OnScrollDecreaseClick(object sender, RoutedEventArgs args)
	{
		ScrollViewer scrollViewer = m_scrollViewer;
		scrollViewer?.ChangeView(Math.Max(0.0, scrollViewer.HorizontalOffset - 50.0), null, null);
	}

	private void OnScrollIncreaseClick(object sender, RoutedEventArgs args)
	{
		ScrollViewer scrollViewer = m_scrollViewer;
		scrollViewer?.ChangeView(Math.Min(scrollViewer.ScrollableWidth, scrollViewer.HorizontalOffset + 50.0), null, null);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (previousAvailableSize.Width != availableSize.Width)
		{
			previousAvailableSize = availableSize;
			UpdateTabWidths();
		}
		return base.MeasureOverride(availableSize);
	}

	private void UpdateTabWidths(bool shouldUpdateWidths = true, bool fillAllAvailableSpace = true)
	{
		double num = double.NaN;
		Grid tabContainerGrid = m_tabContainerGrid;
		if (tabContainerGrid != null)
		{
			double num2 = 0.0;
			ColumnDefinition leftContentColumn = m_leftContentColumn;
			if (leftContentColumn != null)
			{
				num2 += leftContentColumn.ActualWidth;
			}
			ColumnDefinition addButtonColumn = m_addButtonColumn;
			if (addButtonColumn != null)
			{
				double num3 = addButtonColumn.ActualWidth;
				if (addButtonColumn.ActualWidth == 0.0)
				{
					Button addButton = m_addButton;
					if (addButton != null && addButton.Visibility == Visibility.Visible && previousAvailableSize.Width > 0.0)
					{
						m_addButton.Measure(previousAvailableSize);
						num3 = m_addButton.DesiredSize.Width;
					}
				}
				num2 += num3;
			}
			ColumnDefinition rightContentColumn = m_rightContentColumn;
			if (rightContentColumn != null)
			{
				ContentPresenter rightContentPresenter = m_rightContentPresenter;
				if (rightContentPresenter != null)
				{
					Size desiredSize = rightContentPresenter.DesiredSize;
					rightContentColumn.MinWidth = desiredSize.Width;
					num2 += desiredSize.Width;
				}
			}
			ColumnDefinition tabColumn = m_tabColumn;
			if (tabColumn != null)
			{
				double num4 = previousAvailableSize.Width - num2;
				if (num4 > 0.0)
				{
					if (TabWidthMode == TabViewWidthMode.Equal)
					{
						double min = (double)SharedHelpers.FindInApplicationResources("TabViewItemMinWidth", 48.0);
						double max = (double)SharedHelpers.FindInApplicationResources("TabViewItemMaxWidth", 200.0);
						Thickness padding = base.Padding;
						if (fillAllAvailableSpace)
						{
							double value = (num4 - (padding.Left + padding.Right)) / (double)TabItems.Count;
							num = MathEx.Clamp(value, min, max);
						}
						else
						{
							double num5 = tabColumn.ActualWidth - (padding.Left + padding.Right);
							RepeatButton scrollIncreaseButton = m_scrollIncreaseButton;
							if (scrollIncreaseButton != null && scrollIncreaseButton.Visibility == Visibility.Visible)
							{
								num5 -= scrollIncreaseButton.ActualWidth;
							}
							RepeatButton scrollDecreaseButton = m_scrollDecreaseButton;
							if (scrollDecreaseButton != null && scrollDecreaseButton.Visibility == Visibility.Visible)
							{
								num5 -= scrollDecreaseButton.ActualWidth;
							}
							double value2 = num5 / (double)TabItems.Count;
							num = MathEx.Clamp(value2, min, max);
						}
						tabColumn.MaxWidth = num4;
						double num6 = num * (double)TabItems.Count;
						if (num6 > num4 - (padding.Left + padding.Right))
						{
							tabColumn.Width = GridLengthHelper.FromPixels(num4);
							ListView listView = m_listView;
							TabViewListView tabViewListView = m_listView as TabViewListView;
							if (listView != null)
							{
								tabViewListView?.SetHorizontalScrollBarVisibility(ScrollBarVisibility.Visible);
								UpdateScrollViewerDecreaseAndIncreaseButtonsViewState();
							}
						}
						else
						{
							tabColumn.Width = GridLengthHelper.FromPixels(num6);
							ListView listView2 = m_listView;
							TabViewListView tabViewListView2 = m_listView as TabViewListView;
							if (listView2 != null)
							{
								if (shouldUpdateWidths && fillAllAvailableSpace)
								{
									tabViewListView2?.SetHorizontalScrollBarVisibility(ScrollBarVisibility.Hidden);
								}
								else
								{
									RepeatButton scrollDecreaseButton2 = m_scrollDecreaseButton;
									if (scrollDecreaseButton2 != null)
									{
										scrollDecreaseButton2.IsEnabled = false;
									}
									RepeatButton scrollIncreaseButton2 = m_scrollIncreaseButton;
									if (scrollIncreaseButton2 != null)
									{
										scrollIncreaseButton2.IsEnabled = false;
									}
								}
							}
						}
					}
					else
					{
						tabColumn.MaxWidth = num4;
						tabColumn.Width = GridLengthHelper.FromValueAndType(1.0, GridUnitType.Auto);
						ListView listView3 = m_listView;
						TabViewListView tabViewListView3 = m_listView as TabViewListView;
						if (listView3 != null)
						{
							listView3.MaxWidth = num4;
							ItemsPresenter itemsPresenter = m_itemsPresenter;
							if (itemsPresenter != null)
							{
								bool flag = itemsPresenter.ActualWidth > num4;
								tabViewListView3?.SetHorizontalScrollBarVisibility(flag ? ScrollBarVisibility.Visible : ScrollBarVisibility.Hidden);
								if (flag)
								{
									UpdateScrollViewerDecreaseAndIncreaseButtonsViewState();
								}
							}
						}
					}
				}
			}
		}
		if (!shouldUpdateWidths && TabWidthMode == TabViewWidthMode.Equal)
		{
			return;
		}
		foreach (object tabItem in TabItems)
		{
			TabViewItem tabViewItem = tabItem as TabViewItem;
			if (tabViewItem == null)
			{
				tabViewItem = ContainerFromItem(tabItem) as TabViewItem;
			}
			if (tabViewItem != null)
			{
				tabViewItem.Width = num;
			}
		}
	}

	private void UpdateSelectedItem()
	{
		ListView listView = m_listView;
		if (listView != null)
		{
			listView.SelectedItem = SelectedItem;
		}
	}

	private void UpdateSelectedIndex()
	{
		ListView listView = m_listView;
		if (listView != null)
		{
			int selectedIndex = SelectedIndex;
			if (selectedIndex < listView.Items.Count)
			{
				listView.SelectedIndex = selectedIndex;
			}
		}
	}

	public DependencyObject ContainerFromItem(object item)
	{
		return m_listView?.ContainerFromItem(item);
	}

	public DependencyObject ContainerFromIndex(int index)
	{
		return m_listView?.ContainerFromIndex(index);
	}

	internal int IndexFromContainer(DependencyObject container)
	{
		return m_listView?.IndexFromContainer(container) ?? (-1);
	}

	public object ItemFromContainer(DependencyObject container)
	{
		return m_listView?.ItemFromContainer(container);
	}

	private int GetItemCount()
	{
		object tabItemsSource = TabItemsSource;
		if (tabItemsSource != null)
		{
			if (tabItemsSource is IEnumerable enumerable)
			{
				return enumerable.Count();
			}
			return 0;
		}
		return TabItems.Count;
	}

	private bool SelectNextTab(int increment)
	{
		bool result = false;
		int itemCount = GetItemCount();
		if (itemCount > 1)
		{
			int selectedIndex = SelectedIndex;
			selectedIndex = (SelectedIndex = (selectedIndex + increment + itemCount) % itemCount);
			result = true;
		}
		return result;
	}

	private bool RequestCloseCurrentTab()
	{
		bool result = false;
		if (SelectedItem is TabViewItem tabViewItem && tabViewItem.IsClosable)
		{
			RequestCloseTab(tabViewItem, updateTabWidths: true);
			result = true;
		}
		return result;
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		CoreWindow forCurrentThread = CoreWindow.GetForCurrentThread();
		if (forCurrentThread == null)
		{
			return;
		}
		if (args.Key == VirtualKey.F4)
		{
			if (!SharedHelpers.IsRS3OrHigher() && (forCurrentThread.GetKeyState(VirtualKey.Control) & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down)
			{
				args.Handled = RequestCloseCurrentTab();
			}
		}
		else if (args.Key == VirtualKey.Tab && !SharedHelpers.Is19H1OrHigher())
		{
			bool flag = (forCurrentThread.GetKeyState(VirtualKey.Control) & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
			bool flag2 = (forCurrentThread.GetKeyState(VirtualKey.Shift) & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
			if (flag && !flag2)
			{
				args.Handled = SelectNextTab(1);
			}
			else if (flag && flag2)
			{
				args.Handled = SelectNextTab(-1);
			}
		}
	}

	private void OnCtrlF4Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
	{
		args.Handled = RequestCloseCurrentTab();
	}

	private void OnCtrlTabInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
	{
		args.Handled = SelectNextTab(1);
	}

	private void OnCtrlShiftTabInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
	{
		args.Handled = SelectNextTab(-1);
	}

	internal UIElement GetShadowReceiver()
	{
		return m_shadowReceiver;
	}

	internal string GetTabCloseButtonTooltipText()
	{
		return m_tabCloseButtonTooltipText;
	}

	private static void OnCloseButtonOverlayModePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabView tabView = (TabView)sender;
		tabView.OnCloseButtonOverlayModePropertyChanged(args);
	}

	private static void OnSelectedIndexPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabView tabView = (TabView)sender;
		tabView.OnSelectedIndexPropertyChanged(args);
	}

	private static void OnSelectedItemPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabView tabView = (TabView)sender;
		tabView.OnSelectedItemPropertyChanged(args);
	}

	private static void OnTabItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabView tabView = (TabView)sender;
		tabView.OnTabItemsSourcePropertyChanged(args);
	}

	private static void OnTabWidthModePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabView tabView = (TabView)sender;
		tabView.OnTabWidthModePropertyChanged(args);
	}
}

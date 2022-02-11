using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls.Primitives;

public class LoopingSelector : Control
{
	private enum ListEnd
	{
		Head,
		Tail
	}

	private enum ItemState
	{
		ManipulationInProgress,
		Expanded,
		LostFocus
	}

	private const string c_scrollViewerTemplatePart = "ScrollViewer";

	private const string c_upButtonTemplatePart = "UpButton";

	private const string c_downButtonTemplatePart = "DownButton";

	private const double c_targetScreenWidth = 400.0;

	private static int c_automationLargeIncrement = 5;

	private static int c_automationSmallIncrement = 1;

	private LoopingSelectorPanel _tpPanel;

	private ScrollViewer _tpScrollViewer;

	private ScrollViewer _tpScrollViewerPrivate;

	private ButtonBase _tpUpButton;

	private ButtonBase _tpDownButton;

	private WeakReference<LoopingSelectorAutomationPeer> _wrAP;

	private bool _hasFocus;

	private bool _isSized;

	private bool _isSetupPending;

	private bool _isScrollViewerInitialized;

	private bool _skipNextBalance;

	private bool _skipSelectionChangeUntilFinalViewChanged;

	private bool _skipNextArrange;

	private ItemState _itemState;

	private double _unpaddedExtentTop;

	private double _unpaddedExtentBottom;

	private double _realizedTop;

	private double _realizedBottom;

	private int _realizedTopIdx;

	private int _realizedBottomIdx;

	private int _realizedMidpointIdx;

	private uint _itemCount;

	private double _scaledItemHeight;

	private double _itemHeight;

	private double _itemWidth;

	private double _itemWidthFallback;

	private double _panelSize;

	private double _panelMidpointScrollPosition;

	private bool _isWithinScrollChange;

	private bool _isWithinArrangeOverride;

	private bool _disablePropertyChange;

	private double _lastArrangeSizeHeight;

	private double _delayScrollPositionY;

	private readonly Stack<LoopingSelectorItem> _recycledItems = new Stack<LoopingSelectorItem>();

	private readonly LinkedList<LoopingSelectorItem> _realizedItems = new LinkedList<LoopingSelectorItem>();

	private readonly IDictionary<int, LoopingSelectorItem> _realizedItemsForAP = new Dictionary<int, LoopingSelectorItem>();

	private double _tpPreviousScrollPosition;

	public bool ShouldLoop
	{
		get
		{
			return (bool)GetValue(ShouldLoopProperty);
		}
		set
		{
			SetValue(ShouldLoopProperty, value);
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

	public IList<object> Items
	{
		get
		{
			return (IList<object>)GetValue(ItemsProperty);
		}
		set
		{
			SetValue(ItemsProperty, value);
		}
	}

	public int ItemWidth
	{
		get
		{
			return (int)GetValue(ItemWidthProperty);
		}
		set
		{
			SetValue(ItemWidthProperty, value);
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

	public int ItemHeight
	{
		get
		{
			return (int)GetValue(ItemHeightProperty);
		}
		set
		{
			SetValue(ItemHeightProperty, value);
		}
	}

	public static DependencyProperty ItemHeightProperty { get; } = DependencyProperty.Register("ItemHeight", typeof(int), typeof(LoopingSelector), new FrameworkPropertyMetadata(0));


	public static DependencyProperty ItemTemplateProperty { get; } = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(LoopingSelector), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty ItemWidthProperty { get; } = DependencyProperty.Register("ItemWidth", typeof(int), typeof(LoopingSelector), new FrameworkPropertyMetadata(0));


	public static DependencyProperty ItemsProperty { get; } = DependencyProperty.Register("Items", typeof(IList<object>), typeof(LoopingSelector), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SelectedIndexProperty { get; } = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(LoopingSelector), new FrameworkPropertyMetadata(0));


	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(LoopingSelector), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty ShouldLoopProperty { get; } = DependencyProperty.Register("ShouldLoop", typeof(bool), typeof(LoopingSelector), new FrameworkPropertyMetadata(false));


	public event SelectionChangedEventHandler SelectionChanged;

	internal LoopingSelector()
	{
		this.RegisterDisposablePropertyChangedCallback(delegate(ManagedWeakReference i, DependencyProperty s, DependencyPropertyChangedEventArgs e)
		{
			OnPropertyChanged(e);
		});
		_hasFocus = false;
		_isSized = false;
		_isSetupPending = true;
		_isScrollViewerInitialized = false;
		_skipNextBalance = false;
		_skipSelectionChangeUntilFinalViewChanged = false;
		_skipNextArrange = false;
		_itemState = ItemState.Expanded;
		_unpaddedExtentTop = 0.0;
		_unpaddedExtentBottom = 0.0;
		_realizedTop = 0.0;
		_realizedBottom = 0.0;
		_realizedTopIdx = -1;
		_realizedBottomIdx = -1;
		_realizedMidpointIdx = -1;
		_itemCount = 0u;
		_scaledItemHeight = 0.0;
		_itemHeight = 0.0;
		_itemWidth = 0.0;
		_panelSize = 0.0;
		_panelMidpointScrollPosition = 0.0;
		_isWithinScrollChange = false;
		_isWithinArrangeOverride = false;
		_disablePropertyChange = false;
		_lastArrangeSizeHeight = 0.0;
		_delayScrollPositionY = -1.0;
		_itemWidthFallback = 0.0;
		InitializeImpl();
	}

	private void InitializeImpl()
	{
		base.DefaultStyleKey = typeof(LoopingSelector);
		base.PointerPressed += OnPressed;
		base.LostFocus += OnLostFocus;
		base.GotFocus += OnGotFocus;
		base.PointerEntered += OnPointerEntered;
		base.PointerExited += OnPointerExited;
	}

	private void RaiseOnSelectionChanged(DependencyObject pOldItem, DependencyObject pNewItem)
	{
		IList<object> list = new List<object>(1);
		IList<object> list2 = new List<object>(1);
		list2.Add(pNewItem);
		list.Add(pOldItem);
		SelectionChangedEventArgs e = new SelectionChangedEventArgs(list, list2);
		this.SelectionChanged?.Invoke(this, e);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		LoopingSelectorAutomationPeer loopingSelectorAutomationPeer = new LoopingSelectorAutomationPeer(this);
		LoopingSelectorAutomationPeer result = loopingSelectorAutomationPeer;
		_wrAP = new WeakReference<LoopingSelectorAutomationPeer>(loopingSelectorAutomationPeer);
		return result;
	}

	private void OnUpButtonClicked(object pSender, RoutedEventArgs pEventArgs)
	{
		SelectPreviousItem();
	}

	private void OnDownButtonClicked(object pSender, RoutedEventArgs pEventArgs)
	{
		SelectNextItem();
	}

	protected override void OnKeyDown(KeyRoutedEventArgs pEventArgs)
	{
		bool flag = false;
		VirtualKey virtualKey = VirtualKey.None;
		if (pEventArgs == null)
		{
			throw new ArgumentNullException();
		}
		if (pEventArgs.Handled)
		{
			return;
		}
		virtualKey = pEventArgs.Key;
		VirtualKeyModifiers keyboardModifiers = PlatformHelpers.GetKeyboardModifiers();
		if ((keyboardModifiers & VirtualKeyModifiers.Menu) == 0)
		{
			flag = true;
			switch (virtualKey)
			{
			case VirtualKey.Up:
				SelectPreviousItem();
				break;
			case VirtualKey.Down:
				SelectNextItem();
				break;
			case VirtualKey.PageUp:
			case VirtualKey.GamepadLeftTrigger:
				HandlePageUpKeyPress();
				break;
			case VirtualKey.PageDown:
			case VirtualKey.GamepadRightTrigger:
				HandlePageDownKeyPress();
				break;
			case VirtualKey.Home:
				HandleHomeKeyPress();
				break;
			case VirtualKey.End:
				HandleEndKeyPress();
				break;
			default:
				flag = false;
				break;
			}
			pEventArgs.Handled = flag;
		}
	}

	private void SelectNextItem()
	{
		bool flag = false;
		flag = ShouldLoop;
		int selectedIndex = SelectedIndex;
		if (selectedIndex < (int)(_itemCount - 1) || flag)
		{
			double scaledItemHeight = _scaledItemHeight;
			SetScrollPosition(_unpaddedExtentTop + scaledItemHeight, useAnimation: true);
			RequestInteractionSound(ElementSoundKind.Focus);
		}
	}

	private void SelectPreviousItem()
	{
		bool flag = false;
		flag = ShouldLoop;
		int selectedIndex = SelectedIndex;
		if (selectedIndex > 0 || flag)
		{
			double num = -1.0 * _scaledItemHeight;
			SetScrollPosition(_unpaddedExtentTop + num, useAnimation: true);
			RequestInteractionSound(ElementSoundKind.Focus);
		}
	}

	private void HandlePageDownKeyPress()
	{
		double num = _unpaddedExtentBottom - _unpaddedExtentTop;
		double num2 = num / 2.0;
		SetScrollPosition(_unpaddedExtentTop + num2, useAnimation: true);
		RequestInteractionSound(ElementSoundKind.Focus);
	}

	private void HandlePageUpKeyPress()
	{
		double num = _unpaddedExtentBottom - _unpaddedExtentTop;
		double num2 = -1.0 * num / 2.0;
		SetScrollPosition(_unpaddedExtentTop + num2, useAnimation: true);
		RequestInteractionSound(ElementSoundKind.Focus);
	}

	private void HandleHomeKeyPress()
	{
		double num = (double)(-1 * _realizedMidpointIdx) * _scaledItemHeight;
		SetScrollPosition(_unpaddedExtentTop + num, useAnimation: false);
		Balance(isOnSnapPoint: true);
		RequestInteractionSound(ElementSoundKind.Focus);
	}

	private void HandleEndKeyPress()
	{
		int num = (int)(_itemCount - 1) - _realizedMidpointIdx;
		double num2 = (double)num * _scaledItemHeight;
		SetScrollPosition(_unpaddedExtentTop + num2, useAnimation: false);
		Balance(isOnSnapPoint: true);
		RequestInteractionSound(ElementSoundKind.Focus);
	}

	private void OnViewChanged(object pSender, ScrollViewerViewChangedEventArgs pEventArgs)
	{
		DispatcherQueue.GetForCurrentThread().TryEnqueue(ProcessEvent);
		void ProcessEvent()
		{
			bool flag = false;
			if (!pEventArgs.IsIntermediate && !_isWithinScrollChange && !_isWithinArrangeOverride)
			{
				Balance(isOnSnapPoint: false);
				if (_itemState == ItemState.ManipulationInProgress)
				{
					TransitionItemsState(ItemState.Expanded);
					_itemState = ItemState.Expanded;
				}
				else if (_itemState == ItemState.LostFocus)
				{
					ExpandIfNecessary();
				}
				_skipSelectionChangeUntilFinalViewChanged = false;
			}
		}
	}

	private void OnViewChanging(object pSender, ScrollViewerViewChangingEventArgs pEventArgs)
	{
		if (_isWithinScrollChange || _isWithinArrangeOverride)
		{
			return;
		}
		Balance(isOnSnapPoint: false);
		if (_itemState != ItemState.LostFocus && !_hasFocus)
		{
			bool flag = false;
			FocusState focusState = FocusState.Unfocused;
			if (base.FocusState == FocusState.Unfocused)
			{
				flag = Focus(FocusState.Programmatic);
			}
		}
		if (_itemState == ItemState.Expanded)
		{
			TransitionItemsState(ItemState.ManipulationInProgress);
			_itemState = ItemState.ManipulationInProgress;
			AutomationRaiseExpandCollapse();
		}
	}

	private void OnPointerEntered(object pSender, PointerRoutedEventArgs pEventArgs)
	{
		PointerDeviceType pointerDeviceType = PointerDeviceType.Touch;
		PointerPoint currentPoint = pEventArgs.GetCurrentPoint(null);
		if (currentPoint == null)
		{
			throw new ArgumentNullException();
		}
		PointerDevice pointerDevice = currentPoint.PointerDevice;
		if (pointerDevice == null)
		{
			throw new ArgumentNullException();
		}
		if (pointerDevice.PointerDeviceType != 0)
		{
			GoToState("PointerOver", useTransitions: false);
		}
	}

	private void OnPointerExited(object pSender, PointerRoutedEventArgs pEventArgs)
	{
		GoToState("Normal", useTransitions: false);
		TransitionItemsState(_itemState);
	}

	private void GoToState(string strState, bool useTransitions)
	{
		VisualStateManager.GoToState(this, strState, useTransitions);
	}

	private void OnPressed(object pSender, PointerRoutedEventArgs pEventArgs)
	{
		if (_itemState == ItemState.LostFocus)
		{
			_itemState = ItemState.ManipulationInProgress;
		}
		pEventArgs.Handled = true;
	}

	private void OnLostFocus(object pSender, RoutedEventArgs pEventArgs)
	{
		bool pHasFocus = false;
		HasFocus(out pHasFocus);
		if (!pHasFocus && _hasFocus)
		{
			_hasFocus = false;
			if (_itemState == ItemState.ManipulationInProgress)
			{
				_itemState = ItemState.LostFocus;
			}
			else
			{
				ExpandIfNecessary();
			}
		}
	}

	private void OnGotFocus(object pSender, RoutedEventArgs pEventArgs)
	{
		bool pHasFocus = false;
		HasFocus(out pHasFocus);
		if (pHasFocus)
		{
			_hasFocus = true;
		}
	}

	private void OnItemTapped(object pSender, TappedRoutedEventArgs pArgs)
	{
		if (_itemState == ItemState.Expanded)
		{
			LoopingSelectorItem loopingSelectorItem = pSender as LoopingSelectorItem;
			LoopingSelectorItem loopingSelectorItem2 = loopingSelectorItem;
			int idx = 0;
			uint itemIndex = 0u;
			loopingSelectorItem2.GetVisualIndex(out idx);
			VisualIndexToItemIndex((uint)idx, out itemIndex);
			int num = 0;
			num = SelectedIndex;
			if (itemIndex == (uint)num)
			{
				ExpandIfNecessary();
				return;
			}
			double num2 = (double)(idx - _realizedMidpointIdx) * _scaledItemHeight;
			SetScrollPosition(_unpaddedExtentTop + num2, useAnimation: true);
		}
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs pArgs)
	{
		DependencyProperty property = pArgs.Property;
		if (property == ItemsProperty)
		{
			ClearAllItems();
			Balance(isOnSnapPoint: false);
			AutomationClearPeerMap();
			AutomationRaiseSelectionChanged();
		}
		else if (property == ShouldLoopProperty)
		{
			ClearAllItems();
			_isSized = false;
			_isSetupPending = true;
			Balance(isOnSnapPoint: false);
		}
		else if (property == SelectedIndexProperty && !_disablePropertyChange)
		{
			int num = 0;
			int num2 = 0;
			int num3 = (int)pArgs.NewValue;
			int num4 = num3;
			num = num4;
			num3 = (int)pArgs.OldValue;
			num4 = num3;
			num2 = num4;
			SetSelectedIndex(num2, num);
			Balance(isOnSnapPoint: false);
		}
	}

	private void IsTemplateAndItemsAttached(out bool result)
	{
		result = false;
		if (ItemHeight == 0 || _tpScrollViewer == null || _tpPanel == null)
		{
			return;
		}
		IList<object> items = Items;
		if (items != null)
		{
			uint num = 0u;
			if ((_itemCount = (uint)items.Count) != 0)
			{
				result = true;
			}
		}
	}

	private void IsSetupForAutomation(out bool isSetup)
	{
		bool result = false;
		IsTemplateAndItemsAttached(out result);
		isSetup = result && _isSized && !_isSetupPending;
	}

	private void Balance(bool isOnSnapPoint)
	{
		bool result = false;
		bool flag = false;
		IsTemplateAndItemsAttached(out result);
		flag = !result;
		if (!flag && _skipNextBalance)
		{
			_skipNextBalance = false;
			flag = true;
		}
		if (!flag)
		{
			MeasureExtent(out _unpaddedExtentTop, out _unpaddedExtentBottom);
			if (_unpaddedExtentBottom - _unpaddedExtentTop > 100000.0)
			{
				_skipNextArrange = false;
				flag = true;
			}
		}
		if (!flag)
		{
			EnsureSetup();
			flag = !_isSized || _isSetupPending;
		}
		if (!flag)
		{
			uint num = 0u;
			uint num2 = 0u;
			uint num3 = 0u;
			uint num4 = 0u;
			int headIdx = 0;
			int tailIdx = 0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			GetMaximumAddIndexPosition(out headIdx, out tailIdx);
			if (isOnSnapPoint)
			{
				Normalize();
			}
			num7 = _unpaddedExtentBottom - _unpaddedExtentTop;
			num5 = _unpaddedExtentTop - num7 / 2.0;
			num6 = _unpaddedExtentBottom + num7 / 2.0;
			while (_realizedTop < num5 + 1.0 - _scaledItemHeight && _realizedItems.Count > 0)
			{
				Trim(ListEnd.Head);
				num2++;
			}
			while (_realizedBottom > num6 - 1.0 + _scaledItemHeight && _realizedItems.Count > 0)
			{
				Trim(ListEnd.Tail);
				num4++;
			}
			while (_realizedTop > num5 && _realizedTopIdx > headIdx)
			{
				Add(ListEnd.Head);
				num++;
			}
			while (_realizedBottom < num6 && _realizedBottomIdx < tailIdx)
			{
				Add(ListEnd.Tail);
				num3++;
			}
			if (num != 0 || num3 != 0 || num4 != 0 || num3 != 0)
			{
				AutomationRaiseStructureChanged();
			}
			if (isOnSnapPoint || _itemState == ItemState.Expanded)
			{
				UpdateSelectedItem();
			}
		}
	}

	private void Normalize()
	{
		bool flag = false;
		if (ShouldLoop && Math.Abs(_unpaddedExtentTop - _panelMidpointScrollPosition) > 50.0)
		{
			double num = _panelMidpointScrollPosition - _unpaddedExtentTop;
			if (Math.Abs(num / _scaledItemHeight - Math.Floor(num / _scaledItemHeight)) < 0.001)
			{
				_realizedTop += num;
				_realizedBottom += num;
				_unpaddedExtentTop += num;
				_unpaddedExtentBottom += num;
				ShiftChildren(num);
				SetScrollPosition(_panelMidpointScrollPosition, useAnimation: false);
				_skipNextBalance = true;
			}
		}
	}

	private void EnsureSetup()
	{
		int num = 0;
		num = SelectedIndex;
		if (!_isSized)
		{
			int num2 = 0;
			num2 = ItemHeight;
			_itemHeight = num2;
			_scaledItemHeight = num2;
			num2 = ItemWidth;
			if (num2 == 0)
			{
				_itemWidth = _itemWidthFallback;
			}
			else
			{
				_itemWidth = num2;
			}
			ClearAllItems();
			SizePanel();
			_isSized = true;
		}
		if (_isScrollViewerInitialized && _isSetupPending)
		{
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			bool flag = false;
			flag = ShouldLoop;
			num3 = _tpScrollViewer.ViewportHeight;
			num4 = _tpScrollViewer.VerticalOffset;
			SetupSnapPoints(0.0, _scaledItemHeight);
			if (flag)
			{
				num6 = _panelSize / 2.0;
				_panelMidpointScrollPosition = num6 - num3 / 2.0 + _scaledItemHeight / 2.0;
				_realizedTop = num6;
				_realizedBottom = num6;
				num5 = _panelMidpointScrollPosition;
			}
			else
			{
				num6 = (_panelSize - (double)_itemCount * _scaledItemHeight) / 2.0;
				_panelMidpointScrollPosition = num6 - num3 / 2.0 + _scaledItemHeight / 2.0;
				_realizedTop = num6 + (double)num * _scaledItemHeight;
				_realizedBottom = num6 + (double)num * _scaledItemHeight;
				num5 = _panelMidpointScrollPosition + (double)num * _scaledItemHeight;
			}
			_realizedTopIdx = num;
			_realizedBottomIdx = num - 1;
			if (Math.Abs(num4 - num5) > 1.0)
			{
				SetScrollPosition(num5, useAnimation: false);
				_unpaddedExtentTop += num5 - num4;
				_unpaddedExtentBottom += num5 - num4;
				_skipNextBalance = true;
			}
			_isSetupPending = false;
		}
	}

	private void SetSelectedIndex(int oldIdx, int newIdx)
	{
		double num = 0.0;
		bool result = false;
		IsTemplateAndItemsAttached(out result);
		if (oldIdx != -1 && result && _itemState == ItemState.Expanded)
		{
			num = (double)(newIdx - oldIdx) * _scaledItemHeight;
			SetScrollPosition(_unpaddedExtentTop + num, useAnimation: false);
		}
	}

	private void Trim(ListEnd end)
	{
		if (_realizedItems.Count != 0)
		{
			LoopingSelectorItem value;
			if (end == ListEnd.Head)
			{
				value = _realizedItems.Last!.Value;
				_realizedItems.RemoveLast();
			}
			else
			{
				value = _realizedItems.First!.Value;
				_realizedItems.RemoveFirst();
			}
			if (end == ListEnd.Head)
			{
				_realizedTop += _scaledItemHeight;
				_realizedTopIdx++;
			}
			else
			{
				_realizedBottom -= _scaledItemHeight;
				_realizedBottomIdx--;
			}
			RecycleItem(value);
		}
	}

	private void Add(ListEnd end)
	{
		LoopingSelectorItem ppItem;
		if (end == ListEnd.Head)
		{
			RealizeItem((uint)(_realizedTopIdx - 1), out ppItem);
			_realizedItems.AddLast(ppItem);
			UIElement pitem = ppItem;
			SetPosition(pitem, _realizedTop - _scaledItemHeight);
			_realizedTop -= _scaledItemHeight;
			_realizedTopIdx--;
		}
		else
		{
			RealizeItem((uint)(_realizedBottomIdx + 1), out ppItem);
			_realizedItems.AddFirst(ppItem);
			UIElement pitem = ppItem;
			SetPosition(pitem, _realizedBottom);
			_realizedBottom += _scaledItemHeight;
			_realizedBottomIdx++;
		}
	}

	private void GetMaximumAddIndexPosition(out int headIdx, out int tailIdx)
	{
		if (ShouldLoop)
		{
			headIdx = int.MinValue;
			tailIdx = int.MaxValue;
		}
		else
		{
			headIdx = 0;
			tailIdx = (int)(_itemCount - 1);
		}
	}

	private void UpdateSelectedItem(bool ignoreScrollingState = false)
	{
		uint num = 0u;
		double num2 = 0.0;
		uint num3 = 0u;
		int num4 = 0;
		num2 = (_unpaddedExtentTop + _unpaddedExtentBottom) / 2.0 - _realizedTop;
		num3 = (uint)_realizedTopIdx + (uint)num2 / (uint)_scaledItemHeight;
		IList<object> items = Items;
		num = (uint)items.Count;
		UpdateVisualSelectedItem((uint)_realizedMidpointIdx, num3);
		_realizedMidpointIdx = (int)num3;
		if (ignoreScrollingState || !_skipSelectionChangeUntilFinalViewChanged)
		{
			num3 = PositiveMod((int)num3, (int)num);
			DependencyObject dependencyObject = items[(int)num3] as DependencyObject;
			_disablePropertyChange = true;
			num4 = SelectedIndex;
			SelectedIndex = (int)num3;
			DependencyObject pOldItem = SelectedItem as DependencyObject;
			SelectedItem = dependencyObject;
			if (num4 != (int)num3)
			{
				RaiseOnSelectionChanged(pOldItem, dependencyObject);
				AutomationRaiseSelectionChanged();
			}
			_disablePropertyChange = false;
		}
	}

	private void UpdateVisualSelectedItem(uint oldIdx, uint newIdx)
	{
		if (oldIdx == newIdx)
		{
			return;
		}
		LoopingSelectorItem loopingSelectorItem = null;
		int count = _realizedItems.Count;
		if (count <= 0)
		{
			return;
		}
		if (count > oldIdx - _realizedTopIdx)
		{
			int num = count - ((int)oldIdx - _realizedTopIdx) - 1;
			LoopingSelectorItem loopingSelectorItem2 = _realizedItems.ElementAt(num % count);
			loopingSelectorItem = loopingSelectorItem2;
			if (_itemState == ItemState.Expanded)
			{
				loopingSelectorItem.SetState(LoopingSelectorItem.State.Expanded, useTransitions: true);
			}
			else
			{
				loopingSelectorItem.SetState(LoopingSelectorItem.State.Normal, useTransitions: true);
			}
		}
		if (count > newIdx - _realizedTopIdx)
		{
			LoopingSelectorItem loopingSelectorItem2 = _realizedItems.ElementAt(count - ((int)newIdx - _realizedTopIdx) - 1);
			loopingSelectorItem = loopingSelectorItem2;
			loopingSelectorItem.SetState(LoopingSelectorItem.State.Selected, useTransitions: true);
		}
	}

	internal void VisualIndexToItemIndex(uint visualIndex, out uint itemIndex)
	{
		IList<object> items = Items;
		int num = 0;
		num = items.Count;
		itemIndex = PositiveMod((int)visualIndex, num);
	}

	private void RealizeItem(uint itemIdxToRealize, out LoopingSelectorItem ppItem)
	{
		LoopingSelectorItem loopingSelectorItem = null;
		uint itemIndex = 0u;
		VisualIndexToItemIndex(itemIdxToRealize, out itemIndex);
		RetreiveItemFromAPRealizedItems(itemIndex, out var ppItem2);
		if (ppItem2 == null && _recycledItems.Count != 0)
		{
			ppItem2 = _recycledItems.Pop();
		}
		ContentControl contentControl;
		DependencyObject element;
		if (ppItem2 == null)
		{
			GetPanelChildren(out var ppChildren, out var _);
			ppItem2 = new LoopingSelectorItem();
			UIElement uIElement = ppItem2;
			Control control = ppItem2;
			contentControl = ppItem2;
			element = ppItem2;
			FrameworkElement frameworkElement = ppItem2;
			loopingSelectorItem = ppItem2;
			loopingSelectorItem.SetParent(this);
			DataTemplate dataTemplate = (contentControl.ContentTemplate = ItemTemplate);
			frameworkElement.Width = _itemWidth;
			frameworkElement.Height = _itemHeight;
			ppChildren.Add(uIElement);
			HorizontalAlignment horizontalAlignment = (control.HorizontalContentAlignment = HorizontalContentAlignment);
			Thickness thickness = (control.Padding = Padding);
			uIElement.Tapped += OnItemTapped;
			control.ApplyTemplate();
		}
		else
		{
			loopingSelectorItem = ppItem2;
			contentControl = ppItem2;
			element = ppItem2;
			FrameworkElement frameworkElement2 = ppItem2;
			frameworkElement2.Width = _itemWidth;
		}
		IList<object> items = Items;
		DependencyObject dependencyObject = (DependencyObject)(contentControl.Content = items[(int)itemIndex] as DependencyObject);
		int num = 0;
		num = items.Count;
		AutomationProperties.SetPositionInSet(element, (int)(itemIndex + 1));
		AutomationProperties.SetSizeOfSet(element, num);
		loopingSelectorItem.SetVisualIndex((int)itemIdxToRealize);
		if (_itemState == ItemState.Expanded || _itemState == ItemState.ManipulationInProgress || _itemState == ItemState.LostFocus)
		{
			loopingSelectorItem.SetState(LoopingSelectorItem.State.Expanded, useTransitions: false);
		}
		else
		{
			loopingSelectorItem.SetState(LoopingSelectorItem.State.Normal, useTransitions: false);
		}
		loopingSelectorItem.AutomationUpdatePeerIfExists((int)itemIndex);
		ppItem = ppItem2;
	}

	private void RecycleItem(LoopingSelectorItem pItem)
	{
		_recycledItems.Push(pItem);
		Canvas.SetLeft(pItem, -10000.0);
	}

	private void RequestInteractionSound(ElementSoundKind soundKind)
	{
		PlatformHelpers.RequestInteractionSoundForElement(soundKind, this);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size size = default(Size);
		size = base.MeasureOverride(availableSize);
		int itemWidth = ItemWidth;
		if (itemWidth == 0 && availableSize.Width.IsFinite())
		{
			size.Width = availableSize.Width;
		}
		else
		{
			size.Width = itemWidth;
		}
		return size;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		int num = 0;
		double num2 = 0.0;
		bool flag = false;
		double num3 = 0.0;
		_isWithinArrangeOverride = true;
		try
		{
			num = ItemWidth;
			if (num != 0)
			{
				num3 = num;
			}
			else
			{
				num3 = finalSize.Width;
				double width = finalSize.Width;
				if (_itemWidthFallback != width)
				{
					_itemWidthFallback = width;
					_isSized = false;
				}
			}
			if (_delayScrollPositionY != -1.0)
			{
				SetScrollPosition(_delayScrollPositionY, useAnimation: false);
				_skipNextBalance = false;
				_delayScrollPositionY = -1.0;
				flag = true;
			}
			if (_isScrollViewerInitialized && !_isSetupPending)
			{
				num2 = _tpScrollViewer.VerticalOffset;
			}
			Size result = base.ArrangeOverride(finalSize);
			if (finalSize.Height != _lastArrangeSizeHeight && _isScrollViewerInitialized && !_isSetupPending)
			{
				double panelSize = _panelSize;
				double num4 = 0.0;
				num4 = _tpScrollViewer.VerticalOffset;
				SizePanel();
				double num5 = (_panelSize - panelSize) / 2.0;
				_realizedTop += num5;
				_realizedBottom += num5;
				ShiftChildren(num5);
				if (num4 != num2 && !flag)
				{
					_delayScrollPositionY = num2;
					_skipNextArrange = true;
				}
			}
			if (_skipNextArrange && _isScrollViewerInitialized)
			{
				_skipNextArrange = false;
			}
			else
			{
				if (!_isScrollViewerInitialized)
				{
					_isScrollViewerInitialized = true;
				}
				Balance(isOnSnapPoint: false);
			}
			result.Width = num3;
			return result;
		}
		finally
		{
			_lastArrangeSizeHeight = finalSize.Height;
			_isWithinArrangeOverride = false;
		}
	}

	protected override void OnApplyTemplate()
	{
		ContentControl contentControl = null;
		if (_tpScrollViewer != null)
		{
			_tpScrollViewer.ViewChanged -= new EventHandler<ScrollViewerViewChangedEventArgs>(OnViewChanged);
			_tpScrollViewer.ViewChanging -= OnViewChanging;
		}
		if (_tpUpButton != null)
		{
			_tpUpButton.Click -= OnUpButtonClicked;
		}
		if (_tpDownButton != null)
		{
			_tpDownButton.Click -= OnDownButtonClicked;
		}
		if (_tpScrollViewerPrivate != null)
		{
			_tpScrollViewerPrivate.EnableOverpan();
		}
		_tpScrollViewer = null;
		_tpScrollViewerPrivate = null;
		_tpPanel = null;
		_tpUpButton = null;
		_tpDownButton = null;
		DependencyObject templateChild = GetTemplateChild("UpButton");
		if (templateChild is ButtonBase tpUpButton)
		{
			_tpUpButton = tpUpButton;
		}
		DependencyObject templateChild2 = GetTemplateChild("DownButton");
		if (templateChild2 is ButtonBase tpDownButton)
		{
			_tpDownButton = tpDownButton;
		}
		DependencyObject templateChild3 = GetTemplateChild("ScrollViewer");
		if (templateChild3 != null)
		{
			ScrollViewer scrollViewer = templateChild3 as ScrollViewer;
			contentControl = templateChild3 as ContentControl;
			_tpScrollViewer = scrollViewer;
			_tpScrollViewerPrivate = scrollViewer;
		}
		if (contentControl != null)
		{
			LoopingSelectorPanel loopingSelectorPanel = new LoopingSelectorPanel();
			DependencyObject dependencyObject = (DependencyObject)(contentControl.Content = loopingSelectorPanel);
			_tpPanel = loopingSelectorPanel;
		}
		if (_tpPanel != null)
		{
			FrameworkElement tpPanel = _tpPanel;
			tpPanel.Height = 1000000.0;
		}
		if (_tpUpButton != null)
		{
			_tpUpButton.Click += OnUpButtonClicked;
		}
		if (_tpDownButton != null)
		{
			_tpDownButton.Click += OnDownButtonClicked;
		}
		if (_tpScrollViewer != null)
		{
			_tpScrollViewer.ViewChanged += new EventHandler<ScrollViewerViewChangedEventArgs>(OnViewChanged);
			_tpScrollViewer.ViewChanging += OnViewChanging;
		}
		if (_tpScrollViewerPrivate != null)
		{
			_tpScrollViewerPrivate.DisableOverpan();
		}
	}

	private void HasFocus(out bool pHasFocus)
	{
		pHasFocus = false;
		XamlRoot xamlRoot = XamlRoot;
		if (xamlRoot != null && FocusManager.GetFocusedElement(xamlRoot) is DependencyObject dependencyObject)
		{
			DependencyObject pChild = dependencyObject;
			IsAscendantOfTarget(pChild, out pHasFocus);
		}
	}

	private void IsAscendantOfTarget(DependencyObject pChild, out bool pIsChildOfTarget)
	{
		DependencyObject dependencyObject = pChild;
		bool flag = false;
		while (dependencyObject != null && !flag)
		{
			if (dependencyObject == this)
			{
				flag = true;
				continue;
			}
			DependencyObject parent = VisualTreeHelper.GetParent(dependencyObject);
			dependencyObject = parent;
		}
		pIsChildOfTarget = flag;
	}

	private void ShiftChildren(double delta)
	{
		if (delta == 0.0)
		{
			return;
		}
		foreach (LoopingSelectorItem realizedItem in _realizedItems)
		{
			double num = 0.0;
			LoopingSelectorItem loopingSelectorItem = realizedItem;
			UIElement element = loopingSelectorItem;
			num = Canvas.GetTop(element);
			Canvas.SetTop(element, num + delta);
		}
	}

	private void MeasureExtent(out double extentTop, out double extentBottom)
	{
		double num = 0.0;
		double num2 = 0.0;
		num = _tpScrollViewer.ViewportHeight;
		extentBottom = (extentTop = _tpScrollViewer.VerticalOffset) + num;
	}

	private void ClearAllItems()
	{
		foreach (LoopingSelectorItem realizedItem in _realizedItems)
		{
			RecycleItem(realizedItem);
			_realizedBottom -= _scaledItemHeight;
			_realizedBottomIdx--;
		}
		_realizedItems.Clear();
		_realizedItemsForAP.Clear();
		IList<object> items = Items;
		if (items != null)
		{
			int num = 0;
			int num2 = 0;
			num = (int)(_itemCount = (uint)items.Count);
			num2 = _realizedMidpointIdx - (int)PositiveMod(_realizedMidpointIdx, (int)_itemCount);
			_realizedMidpointIdx -= num2;
			_realizedTopIdx -= num2;
			_realizedBottomIdx -= num2;
		}
	}

	private void GetPanelChildren(out IList<UIElement> ppChildren, out uint count)
	{
		Panel tpPanel = _tpPanel;
		IList<UIElement> children = tpPanel.Children;
		count = (uint)children.Count;
		ppChildren = children;
	}

	private void SizePanel()
	{
		bool flag = false;
		flag = ShouldLoop;
		FrameworkElement tpPanel = _tpPanel;
		if (flag)
		{
			double num = 0.0;
			num = _tpScrollViewer.ViewportHeight;
			_panelSize = num + 1001.0 * _scaledItemHeight;
		}
		else
		{
			double num2 = 0.0;
			num2 = _tpScrollViewer.ViewportHeight;
			_panelSize = num2 + (double)(_itemCount - 1) * _scaledItemHeight;
			_panelSize += 1.0;
		}
		tpPanel.Height = _panelSize;
	}

	private void SetScrollPosition(double offset, bool useAnimation)
	{
		double spVerticalOffset = offset;
		if (!useAnimation)
		{
			bool flag = false;
			_isWithinScrollChange = true;
			if (!_tpScrollViewer.ChangeViewWithOptionalAnimation(null, spVerticalOffset, null, disableAnimation: true))
			{
				_delayScrollPositionY = offset;
			}
			_isWithinScrollChange = false;
		}
		else
		{
			DispatcherQueue forCurrentThread = DispatcherQueue.GetForCurrentThread();
			bool flag2 = forCurrentThread.TryEnqueue(delegate
			{
				_tpScrollViewer.ChangeViewWithOptionalAnimation(null, spVerticalOffset, null, disableAnimation: false);
			});
		}
	}

	private void SetupSnapPoints(double offset, double size)
	{
		LoopingSelectorPanel loopingSelectorPanel = null;
		loopingSelectorPanel = _tpPanel;
		loopingSelectorPanel.SetOffsetInPixels((float)offset);
		loopingSelectorPanel.SetSizeInPixels((float)size);
	}

	private void SetPosition(UIElement pitem, double offset)
	{
		Canvas.SetTop(pitem, offset);
		Canvas.SetLeft(pitem, 0.0);
	}

	private void ExpandIfNecessary()
	{
		if (_itemState != ItemState.Expanded)
		{
			TransitionItemsState(ItemState.Expanded);
			_itemState = ItemState.Expanded;
		}
	}

	private void TransitionItemsState(ItemState state)
	{
		uint num = 0u;
		foreach (LoopingSelectorItem realizedItem in _realizedItems)
		{
			LoopingSelectorItem loopingSelectorItem = realizedItem;
			switch (state)
			{
			case ItemState.ManipulationInProgress:
				loopingSelectorItem.SetState(LoopingSelectorItem.State.Expanded, useTransitions: true);
				break;
			case ItemState.Expanded:
				if (_realizedTopIdx + (_realizedItems.Count - 1 - num) == _realizedMidpointIdx)
				{
					loopingSelectorItem.SetState(LoopingSelectorItem.State.Selected, useTransitions: true);
				}
				else
				{
					loopingSelectorItem.SetState(LoopingSelectorItem.State.Expanded, useTransitions: true);
				}
				break;
			default:
				if (_realizedTopIdx + (_realizedItems.Count - 1 - num) == _realizedMidpointIdx)
				{
					loopingSelectorItem.SetState(LoopingSelectorItem.State.Selected, useTransitions: true);
				}
				else
				{
					loopingSelectorItem.SetState(LoopingSelectorItem.State.Normal, useTransitions: true);
				}
				break;
			}
			num++;
		}
	}

	internal void AutomationGetSelectedItem(out LoopingSelectorItem ppItemNoRef)
	{
		ppItemNoRef = null;
		foreach (LoopingSelectorItem realizedItem in _realizedItems)
		{
			LoopingSelectorItem loopingSelectorItem = realizedItem;
			int idx = 0;
			loopingSelectorItem.GetVisualIndex(out idx);
			uint itemIndex = 0u;
			VisualIndexToItemIndex((uint)idx, out itemIndex);
			int num = 0;
			num = SelectedIndex;
			if (itemIndex == (uint)num)
			{
				ppItemNoRef = loopingSelectorItem;
				break;
			}
		}
	}

	private void RetreiveItemFromAPRealizedItems(uint moddeItemdIdx, out LoopingSelectorItem ppItem)
	{
		ppItem = null;
		if (_realizedItemsForAP.TryGetValue((int)moddeItemdIdx, out var value))
		{
			ppItem = value;
			_realizedItemsForAP.Remove((int)moddeItemdIdx);
		}
	}

	internal void AutomationScrollToVisualIdx(int visualIdx, bool ignoreScrollingState = false)
	{
		bool isSetup = false;
		IsSetupForAutomation(out isSetup);
		if (isSetup && _itemState == ItemState.Expanded)
		{
			int num = visualIdx - _realizedMidpointIdx;
			double num2 = (double)num * _scaledItemHeight;
			SetScrollPosition(_unpaddedExtentTop + num2, useAnimation: false);
			Balance(isOnSnapPoint: true);
			if (num2 == 0.0)
			{
				UpdateSelectedItem(ignoreScrollingState);
			}
		}
	}

	internal void AutomationGetIsScrollable(out bool pIsScrollable)
	{
		pIsScrollable = _itemCount != 0;
	}

	internal void AutomationGetScrollPercent(out double pScrollPercent)
	{
		int num = SelectedIndex;
		if (num < 0)
		{
			num = 0;
		}
		if (_itemCount != 0)
		{
			pScrollPercent = (double)num / (double)_itemCount * 100.0;
		}
		else
		{
			pScrollPercent = 0.0;
		}
	}

	internal void AutomationGetScrollViewSize(out double pScrollPercent)
	{
		bool isSetup = false;
		pScrollPercent = 100.0;
		IsSetupForAutomation(out isSetup);
		if (isSetup)
		{
			double num = _unpaddedExtentBottom - _unpaddedExtentTop;
			if (num > 0.0)
			{
				pScrollPercent = num / ((double)_itemCount * _scaledItemHeight) * 100.0;
			}
		}
	}

	internal void AutomationSetScrollPercent(double scrollPercent)
	{
		bool isSetup = false;
		if (scrollPercent < 0.0 || scrollPercent > 100.0)
		{
			throw new InvalidOperationException();
		}
		IsSetupForAutomation(out isSetup);
		if (isSetup && _itemState == ItemState.Expanded)
		{
			int num = (int)((double)(_itemCount - 1) * scrollPercent / 100.0);
			int num2 = (int)PositiveMod(_realizedMidpointIdx, (int)_itemCount);
			int num3 = num - num2;
			double num4 = (double)num3 * _scaledItemHeight;
			SetScrollPosition(_unpaddedExtentTop + num4, useAnimation: false);
			Balance(isOnSnapPoint: true);
		}
	}

	internal void AutomationTryGetSelectionUIAPeer(out AutomationPeer ppPeer)
	{
		ppPeer = null;
		LoopingSelectorItem ppItemNoRef = null;
		AutomationGetSelectedItem(out ppItemNoRef);
		if (ppItemNoRef != null)
		{
			AutomationPeer automationPeer = (ppPeer = FrameworkElementAutomationPeer.CreatePeerForElement(this));
		}
	}

	internal void AutomationScroll(ScrollAmount scrollAmount)
	{
		bool isSetup = false;
		IsSetupForAutomation(out isSetup);
		if (isSetup && _itemState == ItemState.Expanded)
		{
			double num = 0.0;
			int num2 = 0;
			switch (scrollAmount)
			{
			case ScrollAmount.LargeDecrement:
				num2 = -c_automationLargeIncrement;
				break;
			case ScrollAmount.LargeIncrement:
				num2 = c_automationLargeIncrement;
				break;
			case ScrollAmount.SmallDecrement:
				num2 = -c_automationSmallIncrement;
				break;
			case ScrollAmount.SmallIncrement:
				num2 = c_automationSmallIncrement;
				break;
			}
			int num3 = (int)PositiveMod(_realizedMidpointIdx, (int)_itemCount);
			if (num3 + num2 > (int)(_itemCount - 1))
			{
				num2 = (int)_itemCount - num3 - 1;
			}
			else if (num3 + num2 < 0)
			{
				num2 = -num3;
			}
			num = (double)num2 * _scaledItemHeight;
			SetScrollPosition(_unpaddedExtentTop + num, useAnimation: false);
			Balance(isOnSnapPoint: true);
		}
	}

	internal void AutomationTryScrollItemIntoView(DependencyObject pItem)
	{
		int num = 0;
		bool flag = false;
		IList<object> items = Items;
		num = items.IndexOf(pItem);
		if (num >= 0)
		{
			_skipSelectionChangeUntilFinalViewChanged = true;
			int visualIdx = (int)(_realizedMidpointIdx - PositiveMod(_realizedMidpointIdx, (int)_itemCount) + num);
			AutomationScrollToVisualIdx(visualIdx);
		}
	}

	private void AutomationRaiseSelectionChanged()
	{
		LoopingSelectorItem ppItemNoRef = null;
		double pScrollPercent = 0.0;
		AutomationProperty verticalScrollPercentProperty = ScrollPatternIdentifiers.VerticalScrollPercentProperty;
		AutomationGetScrollPercent(out pScrollPercent);
		AutomationGetSelectedItem(out ppItemNoRef);
		if (ppItemNoRef != null)
		{
			AutomationHelper.RaiseEventIfListener(this, AutomationEvents.SelectionItemPatternOnElementSelected);
			AutomationHelper.SetAutomationFocusIfListener(this);
		}
		AutomationHelper.RaisePropertyChangedIfListener(this, verticalScrollPercentProperty, _tpPreviousScrollPosition, pScrollPercent);
		_tpPreviousScrollPosition = pScrollPercent;
	}

	private void AutomationRaiseExpandCollapse()
	{
		AutomationProperty expandCollapseStateProperty = ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty;
		ExpandCollapseState oldValue = ExpandCollapseState.Collapsed;
		ExpandCollapseState newValue = ExpandCollapseState.Expanded;
		AutomationHelper.RaisePropertyChangedIfListener(this, expandCollapseStateProperty, oldValue, newValue);
	}

	private void AutomationRaiseStructureChanged()
	{
		AutomationHelper.RaiseEventIfListener(this, AutomationEvents.StructureChanged);
	}

	internal void AutomationGetContainerUIAPeerForItem(DependencyObject pItem, out LoopingSelectorItemAutomationPeer ppPeer)
	{
		ppPeer = null;
		LoopingSelectorItem loopingSelectorItem = null;
		foreach (LoopingSelectorItem realizedItem in _realizedItems)
		{
			LoopingSelectorItem loopingSelectorItem2 = realizedItem;
			ContentControl contentControl = loopingSelectorItem2;
			DependencyObject dependencyObject = contentControl.Content as DependencyObject;
			if (dependencyObject == pItem)
			{
				loopingSelectorItem = loopingSelectorItem2;
				break;
			}
		}
		if (loopingSelectorItem == null)
		{
			foreach (KeyValuePair<int, LoopingSelectorItem> item in _realizedItemsForAP)
			{
				LoopingSelectorItem value = item.Value;
				ContentControl contentControl2 = value;
				DependencyObject dependencyObject2 = contentControl2.Content as DependencyObject;
				if (dependencyObject2 == pItem)
				{
					loopingSelectorItem = value;
					break;
				}
			}
		}
		if (loopingSelectorItem != null)
		{
			UIElement element = loopingSelectorItem;
			AutomationPeer automationPeer = AutomationHelper.CreatePeerForElement(element);
			LoopingSelectorItemAutomationPeer loopingSelectorItemAutomationPeer = (ppPeer = automationPeer as LoopingSelectorItemAutomationPeer);
		}
	}

	internal void AutomationClearPeerMap()
	{
		LoopingSelectorAutomationPeer target = null;
		WeakReference<LoopingSelectorAutomationPeer> wrAP = _wrAP;
		if (wrAP != null && wrAP.TryGetTarget(out target))
		{
			target.ClearPeerMap();
		}
	}

	internal void AutomationRealizeItemForAP(uint itemIdxToRealize)
	{
		RealizeItem(itemIdxToRealize, out var ppItem);
		_realizedItemsForAP[(int)itemIdxToRealize] = ppItem;
	}

	private uint PositiveMod(int x, int n)
	{
		return (uint)((x % n + n) % n);
	}
}

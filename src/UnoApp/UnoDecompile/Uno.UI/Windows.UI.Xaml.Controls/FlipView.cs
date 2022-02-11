using System;
using DirectUI;
using Uno.Disposables;
using Uno.UI.Xaml.Core;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class FlipView : Selector
{
	private const string UIA_FLIPVIEW_PREVIOUS = "UIA_FLIPVIEW_PREVIOUS";

	private const string UIA_FLIPVIEW_NEXT = "UIA_FLIPVIEW_NEXT";

	private const int TICKS_PER_MILLISECOND = 10000;

	private const int FLIP_VIEW_BUTTONS_SHOW_DURATION_MS = 3000;

	private DispatcherTimer m_tpFixOffsetTimer;

	private ButtonBase m_tpPreviousButtonHorizontalPart;

	private ButtonBase m_tpNextButtonHorizontalPart;

	private ButtonBase m_tpPreviousButtonVerticalPart;

	private ButtonBase m_tpNextButtonVerticalPart;

	private bool m_showNavigationButtons;

	private DispatcherTimer m_tpButtonsFadeOutTimer;

	private bool m_animateNewIndex;

	private bool m_skipAnimationOnce;

	private bool m_itemsAreSized;

	private bool m_inMeasure;

	private bool m_inArrange;

	private SnapPointsType m_verticalSnapPointsType;

	private SnapPointsType m_horizontalSnapPointsType;

	private int m_lastScrollWheelDelta;

	private bool m_keepNavigationButtonsVisible;

	private bool m_moveFocusToSelectedItem;

	private readonly SerialDisposable _fixOffsetSubscription = new SerialDisposable();

	private readonly SerialDisposable _buttonsFadeOutTimerSubscription = new SerialDisposable();

	public bool UseTouchAnimationsForAllNavigation
	{
		get
		{
			return (bool)GetValue(UseTouchAnimationsForAllNavigationProperty);
		}
		set
		{
			SetValue(UseTouchAnimationsForAllNavigationProperty, value);
		}
	}

	public static DependencyProperty UseTouchAnimationsForAllNavigationProperty { get; } = DependencyProperty.Register("UseTouchAnimationsForAllNavigation", typeof(bool), typeof(FlipView), new FrameworkPropertyMetadata(true));


	private event EventHandler<ScrollViewerViewChangedEventArgs> m_epScrollViewerViewChangedHandler;

	public FlipView()
	{
		base.DefaultStyleKey = typeof(FlipView);
		InitializePartial();
	}

	private void InitializePartial()
	{
		m_showNavigationButtons = false;
		m_animateNewIndex = false;
		m_verticalSnapPointsType = SnapPointsType.None;
		m_horizontalSnapPointsType = SnapPointsType.None;
		m_skipAnimationOnce = false;
		m_lastScrollWheelDelta = 0;
		m_keepNavigationButtonsVisible = false;
		m_itemsAreSized = false;
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		HookTemplate();
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		UnhookTemplate();
	}

	private void HookTemplate()
	{
		UnhookTemplate();
		InitializeScrollViewer();
		ButtonBase buttonBase = (m_tpPreviousButtonHorizontalPart = CreateButtonClickEventHandler("PreviousButtonHorizontal", OnPreviousButtonPartClick));
		if (m_tpPreviousButtonHorizontalPart != null)
		{
			m_tpPreviousButtonHorizontalPart.PointerEntered += OnPointerEnteredNavigationButtons;
			m_tpPreviousButtonHorizontalPart.PointerExited += OnPointerExitedNavigationButtons;
			string name = AutomationProperties.GetName(m_tpPreviousButtonHorizontalPart);
			if (name == null)
			{
				name = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_FLIPVIEW_PREVIOUS");
				AutomationProperties.SetName(m_tpPreviousButtonHorizontalPart, name);
			}
		}
		ButtonBase buttonBase2 = (m_tpNextButtonHorizontalPart = CreateButtonClickEventHandler("NextButtonHorizontal", OnNextButtonPartClick));
		if (m_tpNextButtonHorizontalPart != null)
		{
			m_tpNextButtonHorizontalPart.PointerEntered += OnPointerEnteredNavigationButtons;
			m_tpNextButtonHorizontalPart.PointerExited += OnPointerExitedNavigationButtons;
			string name = AutomationProperties.GetName(m_tpNextButtonHorizontalPart);
			if (name == null)
			{
				name = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_FLIPVIEW_NEXT");
				AutomationProperties.SetName(m_tpNextButtonHorizontalPart, name);
			}
		}
		ButtonBase buttonBase3 = (m_tpPreviousButtonVerticalPart = CreateButtonClickEventHandler("PreviousButtonVertical", OnPreviousButtonPartClick));
		if (m_tpPreviousButtonVerticalPart != null)
		{
			m_tpPreviousButtonVerticalPart.PointerEntered += OnPointerEnteredNavigationButtons;
			m_tpPreviousButtonVerticalPart.PointerExited += OnPointerExitedNavigationButtons;
			string name = AutomationProperties.GetName(m_tpPreviousButtonVerticalPart);
			if (name == null)
			{
				name = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_FLIPVIEW_PREVIOUS");
				AutomationProperties.SetName(m_tpPreviousButtonVerticalPart, name);
			}
		}
		ButtonBase buttonBase4 = (m_tpNextButtonVerticalPart = CreateButtonClickEventHandler("NextButtonVertical", OnNextButtonPartClick));
		if (m_tpNextButtonVerticalPart != null)
		{
			m_tpNextButtonVerticalPart.PointerEntered += OnPointerEnteredNavigationButtons;
			m_tpNextButtonVerticalPart.PointerExited += OnPointerExitedNavigationButtons;
			string name = AutomationProperties.GetName(m_tpNextButtonVerticalPart);
			if (name == null)
			{
				name = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_FLIPVIEW_NEXT");
				AutomationProperties.SetName(m_tpNextButtonVerticalPart, name);
			}
		}
		UpdateVisualState(useTransitions: false);
	}

	~FlipView()
	{
		UnhookTemplate();
	}

	private void SaveAndClearSnapPointsTypes()
	{
		if (m_tpScrollViewer != null && !m_animateNewIndex)
		{
			m_verticalSnapPointsType = m_tpScrollViewer.VerticalSnapPointsType;
			m_horizontalSnapPointsType = m_tpScrollViewer.HorizontalSnapPointsType;
			m_tpScrollViewer.ClearValue(ScrollViewer.VerticalSnapPointsTypeProperty, DependencyPropertyValuePrecedences.Local);
			m_tpScrollViewer.ClearValue(ScrollViewer.HorizontalSnapPointsTypeProperty, DependencyPropertyValuePrecedences.Local);
		}
	}

	private void RestoreSnapPointsTypes()
	{
		if (m_tpScrollViewer != null)
		{
			m_tpScrollViewer.VerticalSnapPointsType = m_verticalSnapPointsType;
			m_tpScrollViewer.HorizontalSnapPointsType = m_horizontalSnapPointsType;
		}
	}

	private bool MoveNext()
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		ItemCollection items = base.Items;
		num2 = items.Count;
		num = base.SelectedIndex;
		if (num < num2 - 1)
		{
			num++;
			flag = true;
		}
		else
		{
			num = num2 - 1;
		}
		UpdateSelectedIndex(num);
		if (flag)
		{
			ElementSoundPlayerService.RequestInteractionSoundForElementStatic(ElementSoundKind.MoveNext, this);
		}
		return flag;
	}

	private bool MovePrevious()
	{
		bool flag = false;
		int num = base.SelectedIndex;
		if (num > 0)
		{
			num--;
			flag = true;
		}
		UpdateSelectedIndex(num);
		if (flag)
		{
			ElementSoundPlayerService.RequestInteractionSoundForElementStatic(ElementSoundKind.MovePrevious, this);
		}
		return flag;
	}

	private Rect CalculateBounds(int index)
	{
		Rect empty = Rect.Empty;
		bool flag = false;
		Orientation orientation = Orientation.Vertical;
		double num = 0.0;
		double num2 = 0.0;
		Rect result = empty;
		num2 = GetDesiredItemHeight();
		result.Height = (float)num2;
		num = GetDesiredItemWidth();
		result.Width = (float)num;
		if (GetItemsHostOrientations().PhysicalOrientation == Orientation.Vertical)
		{
			result.Y = result.Height * (double)index;
		}
		else
		{
			result.X = result.Width * (double)index;
		}
		return result;
	}

	private void UpdateSelectedIndex(int index)
	{
		base.SelectedIndex = index;
		SetFocusedItem(index, shouldScrollIntoView: false, forceFocus: true, FocusState.Pointer, animateIfBringIntoView: false);
	}

	private void UnhookTemplate()
	{
		if (m_tpPreviousButtonHorizontalPart != null)
		{
			m_tpPreviousButtonHorizontalPart.PointerEntered -= OnPointerEnteredNavigationButtons;
			m_tpPreviousButtonHorizontalPart.PointerExited -= OnPointerExitedNavigationButtons;
		}
		if (m_tpNextButtonHorizontalPart != null)
		{
			m_tpNextButtonHorizontalPart.PointerEntered -= OnPointerEnteredNavigationButtons;
			m_tpNextButtonHorizontalPart.PointerExited -= OnPointerExitedNavigationButtons;
		}
		if (m_tpPreviousButtonVerticalPart != null)
		{
			m_tpPreviousButtonVerticalPart.PointerEntered -= OnPointerEnteredNavigationButtons;
			m_tpPreviousButtonVerticalPart.PointerExited -= OnPointerExitedNavigationButtons;
		}
		if (m_tpNextButtonVerticalPart != null)
		{
			m_tpNextButtonVerticalPart.PointerEntered -= OnPointerEnteredNavigationButtons;
			m_tpNextButtonVerticalPart.PointerExited -= OnPointerExitedNavigationButtons;
		}
		if (m_tpScrollViewer != null)
		{
			m_tpScrollViewer.SizeChanged -= OnScrollingHostPartSizeChanged;
			m_tpScrollViewer.ViewChanged -= new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollViewerViewChanged);
		}
		m_tpButtonsFadeOutTimer?.Stop();
		m_tpFixOffsetTimer?.Stop();
		_fixOffsetSubscription.Disposable = null;
		_buttonsFadeOutTimerSubscription.Disposable = null;
	}

	private ButtonBase CreateButtonClickEventHandler(string buttonName, RoutedEventHandler eventHandler)
	{
		GetTemplatePart<ButtonBase>(buttonName, out var element);
		if (element != null)
		{
			element.Click += eventHandler;
		}
		return element;
	}

	private void InitializeScrollViewer()
	{
		if (m_tpScrollViewer != null)
		{
			return;
		}
		GetTemplatePart<ScrollViewer>("ScrollingHost", out var element);
		m_tpScrollViewer = element;
		m_tpScrollViewer.ForceChangeToCurrentView = true;
		m_tpScrollViewer.IsHorizontalScrollChainingEnabled = false;
		if (m_tpScrollViewer != null)
		{
			Orientation orientation = Orientation.Vertical;
			m_tpScrollViewer.ArePointerWheelEventsIgnored = true;
			if (GetItemsHostOrientations().PhysicalOrientation == Orientation.Vertical)
			{
				m_tpScrollViewer.HorizontalScrollMode = ScrollMode.Disabled;
				m_tpScrollViewer.VerticalScrollMode = ScrollMode.Enabled;
			}
			else
			{
				m_tpScrollViewer.VerticalScrollMode = ScrollMode.Disabled;
				m_tpScrollViewer.HorizontalScrollMode = ScrollMode.Enabled;
			}
			m_tpScrollViewer.SizeChanged += OnScrollingHostPartSizeChanged;
			m_tpScrollViewer.ViewChanged += new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollViewerViewChanged);
		}
	}

	private void OnScrollViewerViewChanged(object pSender, ScrollViewerViewChangedEventArgs pArgs)
	{
		bool flag = true;
		if (pArgs.IsIntermediate || !m_itemsAreSized || m_inMeasure || m_inArrange)
		{
			return;
		}
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 0;
		ItemCollection items = base.Items;
		num4 = items.Count;
		if (num4 <= 0)
		{
			return;
		}
		Orientation orientation = Orientation.Vertical;
		if (GetItemsHostOrientations().PhysicalOrientation == Orientation.Vertical)
		{
			num2 = m_tpScrollViewer.VerticalOffset;
			num3 = m_tpScrollViewer.ViewportHeight;
		}
		else
		{
			num2 = m_tpScrollViewer.HorizontalOffset;
			num3 = m_tpScrollViewer.ViewportWidth;
		}
		if (!(num3 > 0.0))
		{
			return;
		}
		bool flag2 = false;
		flag2 = (bool)GetValue(VirtualizingStackPanel.IsVirtualizingProperty);
		if (!m_animateNewIndex)
		{
			bool flag3 = false;
			if (m_tpFixOffsetTimer != null)
			{
				flag3 = m_tpFixOffsetTimer.IsEnabled;
			}
			if (!flag3)
			{
				m_skipAnimationOnce = true;
				num = (base.SelectedIndex = (int)Math.Round(flag2 ? ItemsPresenter.OffsetToIndex(num2) : (num2 / num3), 0));
				m_skipAnimationOnce = false;
			}
		}
		else
		{
			m_animateNewIndex = false;
			RestoreSnapPointsTypes();
		}
		if (!m_moveFocusToSelectedItem)
		{
			return;
		}
		int num6 = 0;
		num6 = base.SelectedIndex;
		if (num6 >= 0)
		{
			DependencyObject dependencyObject = ContainerFromIndex(num6);
			if (dependencyObject != null)
			{
				m_moveFocusToSelectedItem = false;
				SetFocusedItem(num6, shouldScrollIntoView: false, forceFocus: false, FocusState.Programmatic, animateIfBringIntoView: false);
			}
		}
	}

	private void OnItemsHostAvailable()
	{
		InitializeScrollViewer();
	}

	protected override void OnPointerWheelChanged(PointerRoutedEventArgs pArgs)
	{
		bool flag = false;
		base.OnPointerWheelChanged(pArgs);
		if (pArgs.Handled)
		{
			return;
		}
		VirtualKeyModifiers virtualKeyModifiers = VirtualKeyModifiers.None;
		bool flag2 = false;
		virtualKeyModifiers = PlatformHelpers.GetKeyboardModifiers();
		if (virtualKeyModifiers.HasFlag(VirtualKeyModifiers.Control))
		{
			return;
		}
		bool flag3 = false;
		if (false)
		{
			int num = 0;
			PointerPoint currentPoint = pArgs.GetCurrentPoint(this);
			if (currentPoint == null)
			{
				throw new ArgumentNullException();
			}
			PointerPointProperties properties = currentPoint.Properties;
			if (properties == null)
			{
				throw new ArgumentNullException();
			}
			num = properties.MouseWheelDelta;
			if ((num < 0 && m_lastScrollWheelDelta >= 0) || (num > 0 && m_lastScrollWheelDelta <= 0))
			{
				flag3 = true;
			}
			if (flag3)
			{
				bool flag4 = false;
				if ((num >= 0) ? MovePrevious() : MoveNext())
				{
					m_lastScrollWheelDelta = num;
					pArgs.Handled = true;
				}
			}
		}
		if (!flag3)
		{
			pArgs.Handled = true;
		}
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs pArgs)
	{
		PointerDeviceType pointerDeviceType = PointerDeviceType.Touch;
		base.OnPointerEntered(pArgs);
		if (pArgs == null)
		{
			throw new ArgumentNullException();
		}
		Pointer pointer = pArgs.Pointer;
		if (pointer == null)
		{
			throw new ArgumentNullException();
		}
		if (pointer.PointerDeviceType == PointerDeviceType.Touch)
		{
			HideButtonsImmediately();
		}
		else
		{
			ResetButtonsFadeOutTimer();
		}
	}

	protected override void OnPointerMoved(PointerRoutedEventArgs pArgs)
	{
		PointerDeviceType pointerDeviceType = PointerDeviceType.Touch;
		base.OnPointerMoved(pArgs);
		if (pArgs == null)
		{
			throw new ArgumentNullException();
		}
		Pointer pointer = pArgs.Pointer;
		if (pointer == null)
		{
			throw new ArgumentNullException();
		}
		if (pointer.PointerDeviceType != 0)
		{
			ResetButtonsFadeOutTimer();
		}
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is FlipViewItem;
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return new FlipViewItem();
	}

	protected override void OnItemsChanged(object e)
	{
		base.OnItemsChanged(e);
		int num = 0;
		int num2 = 0;
		bool skipAnimationOnce = m_skipAnimationOnce;
		num2 = base.SelectedIndex;
		num = base.SelectedIndex;
		if (num2 < 0 || num2 != num)
		{
			int num3 = 0;
			int num4 = -1;
			ItemCollection items = base.Items;
			num3 = items.Count;
			if (num3 > 0)
			{
				num4 = ((num2 >= 0 || num >= 0) ? ((num2 >= 0 && (num < 0 || num >= num2)) ? num2 : num) : 0);
				if (num4 >= num3)
				{
					num4 = num3 - 1;
				}
			}
			m_skipAnimationOnce = true;
			base.SelectedIndex = num4;
		}
		if (!m_animateNewIndex)
		{
			SetOffsetToSelectedIndex();
		}
		m_skipAnimationOnce = skipAnimationOnce;
	}

	protected override void OnItemsSourceChanged(DependencyPropertyChangedEventArgs args)
	{
		base.OnItemsSourceChanged(args);
		int num = 0;
		int num2 = 0;
		ItemCollection items = base.Items;
		num2 = items.Count;
		if (args.NewValue != null && num2 > 0)
		{
			num = base.SelectedIndex;
			if (num < 0)
			{
				base.SelectedIndex = 0;
			}
			SetOffsetToSelectedIndex();
		}
	}

	private void NotifyOfSourceChanged(IObservableVector<DependencyObject> pSender, IVectorChangedEventArgs e)
	{
		CollectionChange collectionChange = CollectionChange.Reset;
		int num = 0;
		int num2 = 0;
		m_skipAnimationOnce = true;
		num2 = base.SelectedIndex;
		if (num2 < 0)
		{
			num2 = 0;
		}
		collectionChange = e.CollectionChange;
		if (collectionChange == CollectionChange.ItemChanged)
		{
			num = base.SelectedIndex;
			if (num < 0)
			{
				base.SelectedIndex = num2;
			}
			SetOffsetToSelectedIndex();
		}
		m_skipAnimationOnce = false;
	}

	private void SetOffsetToSelectedIndex()
	{
		int num = 0;
		Orientation orientation = Orientation.Vertical;
		bool flag = false;
		bool flag2 = false;
		double num2 = 0.0;
		num = base.SelectedIndex;
		if (num < 0)
		{
			return;
		}
		orientation = GetItemsHostOrientations().PhysicalOrientation;
		flag = orientation == Orientation.Vertical;
		if ((bool)GetValue(VirtualizingStackPanel.IsVirtualizingProperty))
		{
			num2 = ItemsPresenter.IndexToOffset(num);
		}
		else if (flag)
		{
			num2 = GetDesiredItemHeight();
			num2 *= (double)num;
		}
		else
		{
			num2 = GetDesiredItemWidth();
			num2 *= (double)num;
		}
		if (m_tpScrollViewer != null)
		{
			if (flag)
			{
				m_tpScrollViewer.ScrollToVerticalOffset(num2);
			}
			else
			{
				m_tpScrollViewer.ScrollToHorizontalOffset(num2);
			}
		}
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		base.PrepareContainerForItemOverride(element, item);
		FlipViewItem flipViewItem = null;
		double num = 0.0;
		Thickness empty = Thickness.Empty;
		flipViewItem = (FlipViewItem)element;
		empty = flipViewItem.Margin;
		num = GetDesiredItemWidth();
		num = (flipViewItem.Width = num - (empty.Left + empty.Right));
		num = GetDesiredItemHeight();
		num = (flipViewItem.Height = num - (empty.Top + empty.Bottom));
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new AutomationPeer();
	}

	private void OnScrollingHostPartSizeChanged(object pSender, SizeChangedEventArgs pArgs)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 0;
		Thickness empty = Thickness.Empty;
		num = GetDesiredItemWidth();
		num2 = GetDesiredItemHeight();
		ItemCollection items = base.Items;
		num4 = items.Count;
		for (int i = 0; i < num4; i++)
		{
			DependencyObject dependencyObject = ContainerFromIndex(i);
			if (dependencyObject != null)
			{
				FlipViewItem flipViewItem = null;
				flipViewItem = dependencyObject as FlipViewItem;
				empty = flipViewItem.Margin;
				num3 = (flipViewItem.Width = num - (empty.Left + empty.Right));
				num3 = (flipViewItem.Height = num2 - (empty.Top + empty.Bottom));
			}
		}
		m_itemsAreSized = true;
		SetFixOffsetTimer();
		this.m_epScrollViewerViewChangedHandler?.Invoke(this, new ScrollViewerViewChangedEventArgs());
	}

	private void OnPreviousButtonPartClick(object pSender, RoutedEventArgs pArgs)
	{
		MovePrevious();
		ResetButtonsFadeOutTimer();
	}

	private void OnNextButtonPartClick(object pSender, RoutedEventArgs pArgs)
	{
		MoveNext();
		ResetButtonsFadeOutTimer();
	}

	private void OnPointerEnteredNavigationButtons(object pSender, PointerRoutedEventArgs pArgs)
	{
		m_showNavigationButtons = true;
		m_keepNavigationButtonsVisible = true;
		UpdateVisualState();
	}

	private void OnPointerExitedNavigationButtons(object pSender, PointerRoutedEventArgs pArgs)
	{
		m_keepNavigationButtonsVisible = false;
		ResetButtonsFadeOutTimer();
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		bool flag2 = false;
		Orientation orientation = Orientation.Vertical;
		bool flag3 = false;
		ItemCollection items = base.Items;
		num2 = items.Count;
		num = base.SelectedIndex;
		if (num == 0 || num2 <= 1)
		{
			flag = true;
		}
		if (num2 - 1 == num || num2 <= 1)
		{
			flag2 = true;
		}
		orientation = GetItemsHostOrientations().PhysicalOrientation;
		flag3 = orientation == Orientation.Vertical;
		if (m_tpPreviousButtonHorizontalPart != null)
		{
			ButtonBase tpPreviousButtonHorizontalPart = m_tpPreviousButtonHorizontalPart;
			if (tpPreviousButtonHorizontalPart != null)
			{
				tpPreviousButtonHorizontalPart.Visibility = ((!m_showNavigationButtons || flag || flag3) ? Visibility.Collapsed : Visibility.Visible);
			}
		}
		if (m_tpPreviousButtonVerticalPart != null)
		{
			ButtonBase tpPreviousButtonVerticalPart = m_tpPreviousButtonVerticalPart;
			if (tpPreviousButtonVerticalPart != null)
			{
				tpPreviousButtonVerticalPart.Visibility = ((!m_showNavigationButtons || flag || !flag3) ? Visibility.Collapsed : Visibility.Visible);
			}
		}
		if (m_tpNextButtonHorizontalPart != null)
		{
			ButtonBase tpNextButtonHorizontalPart = m_tpNextButtonHorizontalPart;
			if (tpNextButtonHorizontalPart != null)
			{
				tpNextButtonHorizontalPart.Visibility = ((!m_showNavigationButtons || flag2 || flag3) ? Visibility.Collapsed : Visibility.Visible);
			}
		}
		if (m_tpNextButtonVerticalPart != null)
		{
			ButtonBase tpNextButtonVerticalPart = m_tpNextButtonVerticalPart;
			if (tpNextButtonVerticalPart != null)
			{
				tpNextButtonVerticalPart.Visibility = ((!m_showNavigationButtons || flag2 || !flag3) ? Visibility.Collapsed : Visibility.Visible);
			}
		}
	}

	private double GetDesiredItemWidth()
	{
		double num = 0.0;
		Panel itemsPanelRoot = base.ItemsPanelRoot;
		if (itemsPanelRoot is IVirtualizingPanel virtualizingPanel)
		{
			num = ((virtualizingPanel as VirtualizingPanel)?.LastAvailableSize.Width).Value;
		}
		double num2 = ((!double.IsInfinity(num) && !(num <= 0.0)) ? num : ((m_tpScrollViewer != null) ? m_tpScrollViewer.ActualWidth : base.ActualWidth));
		if (num2 <= 0.0)
		{
			num2 = base.Width;
		}
		return num2;
	}

	private double GetDesiredItemHeight()
	{
		double num = 0.0;
		Panel itemsPanelRoot = base.ItemsPanelRoot;
		if (itemsPanelRoot is IVirtualizingPanel virtualizingPanel)
		{
			num = ((virtualizingPanel as VirtualizingPanel)?.LastAvailableSize.Height).Value;
		}
		double num2 = ((!double.IsInfinity(num) && !(num <= 0.0)) ? num : ((m_tpScrollViewer != null) ? m_tpScrollViewer.ActualHeight : base.ActualHeight));
		if (num2 <= 0.0)
		{
			num2 = base.Height;
		}
		return num2;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			m_inMeasure = true;
			Size size = base.XamlRoot.Size;
			num = base.Height;
			if (double.IsNaN(num))
			{
				availableSize.Height = Math.Min(size.Height, availableSize.Height);
			}
			num2 = base.Width;
			if (double.IsNaN(num2))
			{
				availableSize.Width = Math.Min(size.Width, availableSize.Width);
			}
			return base.MeasureOverride(availableSize);
		}
		finally
		{
			m_inMeasure = false;
		}
	}

	protected override Size ArrangeOverride(Size arrangeSize)
	{
		try
		{
			m_inArrange = true;
			return base.ArrangeOverride(arrangeSize);
		}
		finally
		{
			m_inArrange = false;
		}
	}

	protected override void OnGotFocus(RoutedEventArgs pArgs)
	{
		base.OnGotFocus(pArgs);
	}

	protected override void OnLostFocus(RoutedEventArgs pArgs)
	{
		base.OnLostFocus(pArgs);
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerCaptureLost(pArgs);
		HandlePointerLostOrCanceled(pArgs);
	}

	protected override void OnPointerCanceled(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerCanceled(pArgs);
		HandlePointerLostOrCanceled(pArgs);
		HideButtonsImmediately();
	}

	private void HandlePointerLostOrCanceled(PointerRoutedEventArgs pArgs)
	{
		PointerDeviceType pointerDeviceType = PointerDeviceType.Touch;
		if (pArgs == null)
		{
			throw new ArgumentNullException();
		}
		PointerPoint currentPoint = pArgs.GetCurrentPoint(this);
		if (currentPoint == null)
		{
			throw new ArgumentNullException();
		}
		PointerDevice pointerDevice = currentPoint.PointerDevice;
		if (pointerDevice == null)
		{
			throw new ArgumentNullException();
		}
		if (pointerDevice.PointerDeviceType == PointerDeviceType.Touch)
		{
			UpdateVisualState();
		}
	}

	internal override void OnSelectedIndexChanged(int oldSelectedIndex, int newSelectedIndex)
	{
		base.OnSelectedIndexChanged(oldSelectedIndex, newSelectedIndex);
		bool flag = false;
		flag = UseTouchAnimationsForAllNavigation;
		if ((oldSelectedIndex == newSelectedIndex + 1 || oldSelectedIndex == newSelectedIndex - 1) && m_tpScrollViewer != null && flag && !m_skipAnimationOnce && oldSelectedIndex != -1 && newSelectedIndex != -1)
		{
			Rect rect = default(Rect);
			bool flag2 = false;
			rect = CalculateBounds(newSelectedIndex);
			SaveAndClearSnapPointsTypes();
			m_skipScrollIntoView = true;
			m_animateNewIndex = true;
			if (m_tpScrollViewer != null)
			{
				double num = 0.0;
				Orientation orientation = Orientation.Horizontal;
				bool flag3 = false;
				if (GetItemsHostOrientations().PhysicalOrientation == Orientation.Vertical)
				{
					num = (m_tpScrollViewer?.VerticalOffset).Value;
				}
				else
				{
					num = (m_tpScrollViewer?.HorizontalOffset).Value;
				}
				m_tpScrollViewer?.UpdateLayout();
				m_tpFixOffsetTimer?.Stop();
				flag2 = (m_tpScrollViewer?.BringIntoViewport(rect, skipDuringTouchContact: true, skipAnimationWhileRunning: false, animate: true)).Value;
			}
		}
		else
		{
			if (m_animateNewIndex)
			{
				bool value = (m_tpScrollViewer?.CancelDirectManipulations()).Value;
				RestoreSnapPointsTypes();
				m_animateNewIndex = false;
				SetFixOffsetTimer();
			}
			else
			{
				SetOffsetToSelectedIndex();
			}
			m_skipScrollIntoView = false;
		}
		m_skipAnimationOnce = false;
		bool flag4 = Math.Abs(oldSelectedIndex - newSelectedIndex) <= 1;
	}

	private void OnIsEnabledChanged()
	{
		bool flag = false;
		if (!base.IsEnabled)
		{
			HideButtonsImmediately();
		}
		UpdateVisualState();
	}

	private void OnVisibilityChanged()
	{
		Visibility visibility = Visibility.Collapsed;
		if (base.Visibility != 0)
		{
			HideButtonsImmediately();
		}
		UpdateVisualState();
	}

	private void SetFixOffsetTimer()
	{
		if (m_tpFixOffsetTimer != null)
		{
			m_tpFixOffsetTimer.Stop();
		}
		else
		{
			DispatcherTimer spNewDispatcherTimer = new DispatcherTimer();
			_fixOffsetSubscription.Disposable = Disposable.Create(delegate
			{
				spNewDispatcherTimer.Stop();
				spNewDispatcherTimer.Tick -= FixOffset;
			});
			spNewDispatcherTimer.Tick += FixOffset;
			TimeSpan zero = TimeSpan.Zero;
			spNewDispatcherTimer.Interval = zero;
			m_tpFixOffsetTimer = spNewDispatcherTimer;
			if (m_tpFixOffsetTimer == null)
			{
				throw new ArgumentNullException();
			}
		}
		m_tpFixOffsetTimer.Start();
	}

	private void FixOffset(object sender, object e)
	{
		m_tpFixOffsetTimer.Stop();
		if (m_tpScrollViewer != null && !m_tpScrollViewer.IsInManipulation)
		{
			SetOffsetToSelectedIndex();
		}
		else
		{
			SetFixOffsetTimer();
		}
	}

	private void EnsureButtonsFadeOutTimer()
	{
		if (m_tpButtonsFadeOutTimer == null)
		{
			TimeSpan interval = TimeSpan.FromMilliseconds(30000000.0);
			DispatcherTimer spNewDispatcherTimer = new DispatcherTimer();
			_buttonsFadeOutTimerSubscription.Disposable = Disposable.Create(delegate
			{
				spNewDispatcherTimer.Stop();
				spNewDispatcherTimer.Tick -= ButtonsFadeOutTimerTickHandler;
			});
			spNewDispatcherTimer.Tick += ButtonsFadeOutTimerTickHandler;
			spNewDispatcherTimer.Interval = interval;
			m_tpButtonsFadeOutTimer = spNewDispatcherTimer;
		}
	}

	private void ResetButtonsFadeOutTimer()
	{
		if (!m_showNavigationButtons)
		{
			EnsureButtonsFadeOutTimer();
			m_showNavigationButtons = true;
			UpdateVisualState();
		}
		m_tpButtonsFadeOutTimer?.Start();
	}

	private void HideButtonsImmediately()
	{
		if (m_showNavigationButtons)
		{
			m_tpButtonsFadeOutTimer?.Stop();
			if (!m_keepNavigationButtonsVisible)
			{
				m_showNavigationButtons = false;
				UpdateVisualState();
			}
		}
	}

	private void ButtonsFadeOutTimerTickHandler(object sender, object e)
	{
		HideButtonsImmediately();
	}

	public (ButtonBase ppPreviousButton, ButtonBase ppNextButton) GetPreviousAndNextButtons()
	{
		Orientation orientation = Orientation.Vertical;
		ButtonBase item;
		ButtonBase item2;
		if (GetItemsHostOrientations().PhysicalOrientation == Orientation.Vertical)
		{
			item = m_tpPreviousButtonVerticalPart;
			item2 = m_tpNextButtonVerticalPart;
		}
		else
		{
			item = m_tpPreviousButtonHorizontalPart;
			item2 = m_tpNextButtonHorizontalPart;
		}
		return (item, item2);
	}

	private void GetTemplatePart<T>(string name, out T element) where T : class
	{
		element = GetTemplateChild(name) as T;
	}
}

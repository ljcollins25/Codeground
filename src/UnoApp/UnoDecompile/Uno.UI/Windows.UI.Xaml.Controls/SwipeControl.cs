using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Uno.Disposables;
using Uno.UI;
using Uno.UI.Helpers.WinUI;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class SwipeControl : ContentControl
{
	private enum CreatedContent
	{
		Left,
		Top,
		Bottom,
		Right,
		None
	}

	private const double c_epsilon = 0.0001;

	private const float c_ThresholdValue = 100f;

	private const float c_MinimumCloseVelocity = 31f;

	[ThreadStatic]
	private static WeakReference<SwipeControl> s_lastInteractedWithSwipeControl = null;

	private Grid m_rootGrid;

	private Grid m_content;

	private Grid m_inputEater;

	private Grid m_swipeContentRoot;

	private StackPanel m_swipeContentStackPanel;

	private Style m_swipeItemStyle;

	private SwipeItems m_currentItems;

	private PointerEventHandler m_onPointerPressedEventHandler;

	private IDisposable m_xamlRootPointerPressedEventRevoker;

	private IDisposable m_xamlRootKeyDownEventRevoker;

	private IDisposable m_xamlRootChangedRevoker;

	private IDisposable m_acceleratorKeyActivatedRevoker;

	private bool m_hasInitialLoadedEventFired;

	private bool m_lastActionWasClosing;

	private bool m_lastActionWasOpening;

	private bool m_isInteracting;

	private bool m_isIdle = true;

	private bool m_isOpen;

	private bool m_thresholdReached;

	private bool m_blockNearContent;

	private bool m_blockFarContent;

	private bool m_isHorizontal = true;

	private CreatedContent m_createdContent = CreatedContent.None;

	private const string s_isNearOpenPropertyName = "isNearOpen";

	private const string s_isFarOpenPropertyName = "isFarOpen";

	private const string s_isNearContentPropertyName = "isNearContent";

	private const string s_blockNearContentPropertyName = "blockNearContent";

	private const string s_blockFarContentPropertyName = "blockFarContent";

	private const string s_hasLeftContentPropertyName = "hasLeftContent";

	private const string s_hasRightContentPropertyName = "hasRightContent";

	private const string s_hasTopContentPropertyName = "hasTopContent";

	private const string s_hasBottomContentPropertyName = "hasBottomContent";

	private const string s_isHorizontalPropertyName = "isHorizontal";

	private const string s_trackerPropertyName = "tracker";

	private const string s_foregroundVisualPropertyName = "foregroundVisual";

	private const string s_swipeContentVisualPropertyName = "swipeContentVisual";

	private const string s_swipeContentSizeParameterName = "swipeContentVisual";

	private const string s_swipeRootVisualPropertyName = "swipeRootVisual";

	private const string s_maxThresholdPropertyName = "maxThreshold";

	private const string s_minPositionPropertyName = "minPosition";

	private const string s_maxPositionPropertyName = "maxPosition";

	private const string s_leftInsetTargetName = "LeftInset";

	private const string s_rightInsetTargetName = "RightInset";

	private const string s_topInsetTargetName = "TopInset";

	private const string s_bottomInsetTargetName = "BottomInset";

	private const string s_translationPropertyName = "Translation";

	private const string s_offsetPropertyName = "Offset";

	private const string s_rootGridName = "RootGrid";

	private const string s_inputEaterName = "InputEater";

	private const string s_ContentRootName = "ContentRoot";

	private const string s_swipeContentRootName = "SwipeContentRoot";

	private const string s_swipeContentStackPanelName = "SwipeContentStackPanel";

	private const string s_swipeItemStyleName = "SwipeItemStyle";

	private const string s_swipeItemBackgroundResourceName = "SwipeItemBackground";

	private const string s_swipeItemForegroundResourceName = "SwipeItemForeground";

	private const string s_executeSwipeItemPreThresholdBackgroundResourceName = "SwipeItemPreThresholdExecuteBackground";

	private const string s_executeSwipeItemPostThresholdBackgroundResourceName = "SwipeItemPostThresholdExecuteBackground";

	private const string s_executeSwipeItemPreThresholdForegroundResourceName = "SwipeItemPreThresholdExecuteForeground";

	private const string s_executeSwipeItemPostThresholdForegroundResourceName = "SwipeItemPostThresholdExecuteForeground";

	private TranslateTransform _transform;

	private TranslateTransform _swipeStackPaneltransform;

	private Vector2 _positionWhenCaptured = Vector2.Zero;

	private Vector2 _desiredPosition = Vector2.Zero;

	private Vector2 _desiredStackPanelPosition = Vector2.Zero;

	private bool _isFarOpen;

	private bool _isNearOpen;

	private bool _hasLeftContent;

	private bool _hasRightContent;

	private bool _hasTopContent;

	private bool _hasBottomContent;

	public static DependencyProperty BottomItemsProperty { get; } = DependencyProperty.Register("BottomItems", typeof(SwipeItems), typeof(SwipeControl), new FrameworkPropertyMetadata(null, OnBottomItemsPropertyChanged));


	public SwipeItems BottomItems
	{
		get
		{
			return (SwipeItems)GetValue(BottomItemsProperty);
		}
		set
		{
			SetValue(BottomItemsProperty, value);
		}
	}

	public static DependencyProperty LeftItemsProperty { get; } = DependencyProperty.Register("LeftItems", typeof(SwipeItems), typeof(SwipeControl), new FrameworkPropertyMetadata(null, OnLeftItemsPropertyChanged));


	public SwipeItems LeftItems
	{
		get
		{
			return (SwipeItems)GetValue(LeftItemsProperty);
		}
		set
		{
			SetValue(LeftItemsProperty, value);
		}
	}

	public static DependencyProperty RightItemsProperty { get; } = DependencyProperty.Register("RightItems", typeof(SwipeItems), typeof(SwipeControl), new FrameworkPropertyMetadata(null, OnRightItemsPropertyChanged));


	public SwipeItems RightItems
	{
		get
		{
			return (SwipeItems)GetValue(RightItemsProperty);
		}
		set
		{
			SetValue(RightItemsProperty, value);
		}
	}

	public static DependencyProperty TopItemsProperty { get; } = DependencyProperty.Register("TopItems", typeof(SwipeItems), typeof(SwipeControl), new FrameworkPropertyMetadata(null, OnTopItemsPropertyChanged));


	public SwipeItems TopItems
	{
		get
		{
			return (SwipeItems)GetValue(TopItemsProperty);
		}
		set
		{
			SetValue(TopItemsProperty, value);
		}
	}

	public SwipeControl()
	{
		if (s_lastInteractedWithSwipeControl == null)
		{
			s_lastInteractedWithSwipeControl = new WeakReference<SwipeControl>(null);
		}
		SetDefaultStyleKey(this);
		base.Loaded += UnfinalizeOnLoad;
		base.Unloaded += FinalizeOnUnload;
	}

	private static void UnfinalizeOnLoad(object sender, RoutedEventArgs routedEventArgs)
	{
		((SwipeControl)sender).SwipeControl_Unfinalizer();
	}

	private static void FinalizeOnUnload(object sender, RoutedEventArgs routedEventArgs)
	{
		((SwipeControl)sender).SwipeControl_Finalizer();
	}

	private void SwipeControl_Unfinalizer()
	{
		DetachEventHandlers();
		AttachEventHandlers(isUnoUnfinalizer: true);
	}

	private void SwipeControl_Finalizer()
	{
		DetachEventHandlers();
		if (s_lastInteractedWithSwipeControl.TryGetTarget(out var target) && target == this)
		{
			s_lastInteractedWithSwipeControl.SetTarget(null);
			SwipeTestHooks.GetGlobalTestHooks()?.NotifyLastInteractedWithSwipeControlChanged();
		}
	}

	public async void Close()
	{
		_ = 1;
		try
		{
			if (m_isOpen && !m_lastActionWasClosing && !m_isInteracting)
			{
				m_lastActionWasClosing = true;
				m_isInteracting = true;
				_desiredPosition = Vector2.Zero;
				UpdateStackPanelDesiredPosition();
				await Task.Delay(TimeSpan.FromSeconds(0.25));
				await AnimateTransforms(useInertiaSpeed: false, 0.0);
				OnSwipeManipulationCompleted(this, null);
			}
		}
		catch (Exception e)
		{
			Application.Current.RaiseRecoverableUnhandledException(e);
		}
	}

	protected override void OnApplyTemplate()
	{
		ThrowIfHasVerticalAndHorizontalContent(setIsHorizontal: true);
		DetachEventHandlers();
		GetTemplateParts();
		EnsureClip();
		AttachEventHandlers();
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == LeftItemsProperty)
		{
			OnLeftItemsCollectionChanged(args);
		}
		if (property == RightItemsProperty)
		{
			OnRightItemsCollectionChanged(args);
		}
		if (property == TopItemsProperty)
		{
			OnTopItemsCollectionChanged(args);
		}
		if (property == BottomItemsProperty)
		{
			OnBottomItemsCollectionChanged(args);
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		base.MeasureOverride(availableSize);
		m_rootGrid.Measure(availableSize);
		Size desiredSize = m_rootGrid.DesiredSize;
		if (!double.IsInfinity(availableSize.Width))
		{
			desiredSize.Width = availableSize.Width;
		}
		if (!double.IsInfinity(availableSize.Height))
		{
			desiredSize.Height = availableSize.Height;
		}
		return desiredSize;
	}

	internal static SwipeControl GetLastInteractedWithSwipeControl()
	{
		if (s_lastInteractedWithSwipeControl.TryGetTarget(out var target))
		{
			return target;
		}
		return null;
	}

	internal bool GetIsOpen()
	{
		return m_isOpen;
	}

	internal bool GetIsIdle()
	{
		return m_isIdle;
	}

	private void OnLeftItemsCollectionChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue != null)
		{
			IObservableVector<SwipeItem> observableVector = args.NewValue as IObservableVector<SwipeItem>;
			observableVector.VectorChanged -= OnLeftItemsChanged;
		}
		if (args.NewValue != null)
		{
			ThrowIfHasVerticalAndHorizontalContent();
			IObservableVector<SwipeItem> observableVector2 = args.NewValue as IObservableVector<SwipeItem>;
			observableVector2.VectorChanged += OnLeftItemsChanged;
		}
		_hasLeftContent = args.NewValue != null && (args.NewValue as IObservableVector<SwipeItem>).Count > 0;
		if (m_createdContent == CreatedContent.Left)
		{
			CreateLeftContent();
		}
	}

	private void OnRightItemsCollectionChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue != null)
		{
			IObservableVector<SwipeItem> observableVector = args.OldValue as IObservableVector<SwipeItem>;
			observableVector.VectorChanged -= OnRightItemsChanged;
		}
		if (args.NewValue != null)
		{
			ThrowIfHasVerticalAndHorizontalContent();
			IObservableVector<SwipeItem> observableVector2 = args.NewValue as IObservableVector<SwipeItem>;
			observableVector2.VectorChanged += OnRightItemsChanged;
		}
		_hasRightContent = args.NewValue != null && (args.NewValue as IObservableVector<SwipeItem>).Count > 0;
		if (m_createdContent == CreatedContent.Right)
		{
			CreateRightContent();
		}
	}

	private void OnTopItemsCollectionChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue != null)
		{
			IObservableVector<SwipeItem> observableVector = args.OldValue as IObservableVector<SwipeItem>;
			observableVector.VectorChanged -= OnTopItemsChanged;
		}
		if (args.NewValue != null)
		{
			ThrowIfHasVerticalAndHorizontalContent();
			IObservableVector<SwipeItem> observableVector2 = args.NewValue as IObservableVector<SwipeItem>;
			observableVector2.VectorChanged += OnTopItemsChanged;
		}
		_hasTopContent = args.NewValue != null && (args.NewValue as IObservableVector<SwipeItem>).Count > 0;
		if (m_createdContent == CreatedContent.Top)
		{
			CreateTopContent();
		}
	}

	private void OnBottomItemsCollectionChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue != null)
		{
			IObservableVector<SwipeItem> observableVector = args.OldValue as IObservableVector<SwipeItem>;
			observableVector.VectorChanged -= OnBottomItemsChanged;
		}
		if (args.NewValue != null)
		{
			ThrowIfHasVerticalAndHorizontalContent();
			IObservableVector<SwipeItem> observableVector2 = args.NewValue as IObservableVector<SwipeItem>;
			observableVector2.VectorChanged += OnBottomItemsChanged;
		}
		_hasBottomContent = args.NewValue != null && (args.NewValue as IObservableVector<SwipeItem>).Count > 0;
		if (m_createdContent == CreatedContent.Bottom)
		{
			CreateBottomContent();
		}
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		if (!m_hasInitialLoadedEventFired)
		{
			m_hasInitialLoadedEventFired = true;
			InitializeInteractionTracker();
			TryGetSwipeVisuals();
		}
		CloseWithoutAnimation();
	}

	private void AttachEventHandlers(bool isUnoUnfinalizer = false)
	{
		if (isUnoUnfinalizer)
		{
			OnLoaded(this, null);
		}
		else
		{
			base.Loaded += OnLoaded;
			m_hasInitialLoadedEventFired = false;
		}
		base.SizeChanged += OnSizeChanged;
		m_swipeContentStackPanel.SizeChanged += OnSwipeContentStackPanelSizeChanged;
		if (m_onPointerPressedEventHandler == null)
		{
			m_onPointerPressedEventHandler = OnPointerPressedEvent;
			AddHandler(UIElement.PointerPressedEvent, m_onPointerPressedEventHandler, handledEventsToo: true);
		}
		m_inputEater.Tapped += InputEaterGridTapped;
		UnoAttachEventHandlers();
	}

	private void DetachEventHandlers()
	{
		base.Loaded -= OnLoaded;
		base.SizeChanged -= OnSizeChanged;
		if (m_swipeContentStackPanel != null)
		{
			m_swipeContentStackPanel.SizeChanged -= OnSwipeContentStackPanelSizeChanged;
		}
		if (m_onPointerPressedEventHandler != null)
		{
			RemoveHandler(UIElement.PointerPressedEvent, m_onPointerPressedEventHandler);
			m_onPointerPressedEventHandler = null;
		}
		if (m_inputEater != null)
		{
			m_inputEater.Tapped -= InputEaterGridTapped;
		}
		DetachDismissingHandlers();
		UnoDetachEventHandlers();
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		EnsureClip();
		foreach (UIElement child in m_swipeContentStackPanel.GetChildren())
		{
			if (!(child is AppBarButton appBarButton))
			{
				continue;
			}
			if (m_isHorizontal)
			{
				appBarButton.Height = base.ActualHeight;
				if (m_currentItems != null && m_currentItems.Mode == SwipeMode.Execute)
				{
					appBarButton.Width = base.ActualWidth;
				}
			}
			else
			{
				appBarButton.Width = base.ActualWidth;
				if (m_currentItems != null && m_currentItems.Mode == SwipeMode.Execute)
				{
					appBarButton.Height = base.ActualHeight;
				}
			}
		}
	}

	private void OnSwipeContentStackPanelSizeChanged(object sender, SizeChangedEventArgs args)
	{
	}

	private void OnPointerPressedEvent(object sender, PointerRoutedEventArgs args)
	{
		if (args.Pointer.PointerDeviceType == PointerDeviceType.Touch && m_currentItems != null && m_currentItems.Mode == SwipeMode.Execute && m_currentItems.Size != 0 && m_currentItems.GetAt(0u).BehaviorOnInvoked == SwipeBehaviorOnInvoked.RemainOpen)
		{
			_ = m_isOpen;
		}
	}

	private void InputEaterGridTapped(object sender, TappedRoutedEventArgs args)
	{
		if (m_isOpen)
		{
			CloseIfNotRemainOpenExecuteItem();
			args.Handled = true;
		}
	}

	private void AttachDismissingHandlers()
	{
		DetachDismissingHandlers();
		XamlRoot xamlRoot = base.XamlRoot;
		if (xamlRoot != null)
		{
			UIElement xamlRootContent = xamlRoot.Content;
			if (xamlRootContent != null)
			{
				PointerEventHandler handler = delegate(object _, PointerRoutedEventArgs args)
				{
					DismissSwipeOnAnExternalTap(args.GetCurrentPoint(null).Position);
				};
				xamlRootContent.AddHandler(UIElement.PointerPressedEvent, handler, handledEventsToo: true);
				m_xamlRootPointerPressedEventRevoker = Disposable.Create(delegate
				{
					xamlRootContent.RemoveHandler(UIElement.PointerPressedEvent, handler);
				});
				KeyEventHandler keyEventHandler = delegate
				{
					CloseIfNotRemainOpenExecuteItem();
				};
				xamlRootContent.AddHandler(UIElement.KeyDownEvent, handler, handledEventsToo: true);
				m_xamlRootKeyDownEventRevoker = Disposable.Create(delegate
				{
					xamlRootContent.RemoveHandler(UIElement.PointerPressedEvent, handler);
				});
			}
			xamlRoot.Changed += new TypedEventHandler<XamlRoot, XamlRootChangedEventArgs>(CurrentXamlRootChanged);
			m_xamlRootChangedRevoker = Disposable.Create(delegate
			{
				xamlRoot.Changed -= new TypedEventHandler<XamlRoot, XamlRootChangedEventArgs>(CurrentXamlRootChanged);
			});
		}
		CoreWindow forCurrentThread = CoreWindow.GetForCurrentThread();
		if (forCurrentThread == null)
		{
			return;
		}
		CoreDispatcher dispatcher = forCurrentThread.Dispatcher;
		if (dispatcher != null)
		{
			dispatcher.AcceleratorKeyActivated += DismissSwipeOnAcceleratorKeyActivator;
			m_acceleratorKeyActivatedRevoker = Disposable.Create(delegate
			{
				dispatcher.AcceleratorKeyActivated -= DismissSwipeOnAcceleratorKeyActivator;
			});
		}
	}

	private void DetachDismissingHandlers()
	{
		m_xamlRootPointerPressedEventRevoker?.Dispose();
		m_xamlRootKeyDownEventRevoker?.Dispose();
		m_xamlRootChangedRevoker?.Dispose();
		m_acceleratorKeyActivatedRevoker?.Dispose();
	}

	private void DismissSwipeOnAcceleratorKeyActivator(CoreDispatcher sender, AcceleratorKeyEventArgs args)
	{
		CloseIfNotRemainOpenExecuteItem();
	}

	private void CurrentXamlRootChanged(XamlRoot sender, XamlRootChangedEventArgs args)
	{
		CloseIfNotRemainOpenExecuteItem();
	}

	private void DismissSwipeOnCoreWindowKeyDown(CoreWindow sender, KeyEventArgs args)
	{
		CloseIfNotRemainOpenExecuteItem();
	}

	private void CurrentWindowSizeChanged(DependencyObject sender, WindowSizeChangedEventArgs args)
	{
		CloseIfNotRemainOpenExecuteItem();
	}

	private void CurrentWindowVisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs args)
	{
		CloseIfNotRemainOpenExecuteItem();
	}

	private void DismissSwipeOnAnExternalCoreWindowTap(CoreWindow sender, PointerEventArgs args)
	{
		DismissSwipeOnAnExternalTap(args.CurrentPoint.RawPosition);
	}

	private void DismissSwipeOnAnExternalTap(Point tapPoint)
	{
		GeneralTransform generalTransform = TransformToVisual(null);
		Point zero = Point.Zero;
		Point point = generalTransform.TransformPoint(zero);
		if (tapPoint.X < point.X || tapPoint.Y < point.Y || tapPoint.X - point.X > base.ActualWidth || tapPoint.Y - point.Y > base.ActualHeight)
		{
			CloseIfNotRemainOpenExecuteItem();
		}
	}

	private void GetTemplateParts()
	{
		m_rootGrid = GetTemplateChild<Grid>("RootGrid");
		m_inputEater = GetTemplateChild<Grid>("InputEater");
		m_content = GetTemplateChild<Grid>("ContentRoot");
		m_swipeContentRoot = GetTemplateChild<Grid>("SwipeContentRoot");
		m_swipeContentStackPanel = GetTemplateChild<StackPanel>("SwipeContentStackPanel");
		if (m_swipeContentRoot == null)
		{
			Grid grid = new Grid();
			grid.Name = "SwipeContentRoot";
			m_swipeContentRoot = grid;
			m_rootGrid.Children.Insert(0, grid);
		}
		if (m_swipeContentStackPanel == null)
		{
			StackPanel stackPanel = new StackPanel();
			stackPanel.Name("SwipeContentStackPanel");
			m_swipeContentStackPanel = stackPanel;
			m_swipeContentRoot.Children.Add(stackPanel);
		}
		m_swipeContentStackPanel.Orientation(m_isHorizontal ? Orientation.Horizontal : Orientation.Vertical);
		object obj = SharedHelpers.FindInApplicationResources("SwipeItemStyle", null);
		if (obj != null)
		{
			m_swipeItemStyle = obj as Style;
		}
	}

	private void EnsureClip()
	{
		float num = (float)base.ActualWidth;
		float num2 = (float)base.ActualHeight;
		Rect rect = new Rect(0.0, 0.0, num, num2);
		RectangleGeometry rectangleGeometry = new RectangleGeometry();
		rectangleGeometry.Rect = rect;
		base.Clip = rectangleGeometry;
	}

	private void CloseWithoutAnimation()
	{
		bool isIdle = m_isIdle;
		_desiredPosition = Vector2.Zero;
		UpdateStackPanelDesiredPosition();
		UpdateTransforms();
		if (isIdle)
		{
			IdleStateEntered(null, null);
		}
	}

	private void CloseIfNotRemainOpenExecuteItem()
	{
		if (m_currentItems == null || m_currentItems.Mode != SwipeMode.Execute || m_currentItems.Size == 0 || m_currentItems.GetAt(0u).BehaviorOnInvoked != SwipeBehaviorOnInvoked.RemainOpen || !m_isOpen)
		{
			Close();
		}
	}

	private void CreateLeftContent()
	{
		SwipeItems leftItems = LeftItems;
		if (leftItems != null)
		{
			m_createdContent = CreatedContent.Left;
			CreateContent(leftItems);
		}
	}

	private void CreateRightContent()
	{
		SwipeItems rightItems = RightItems;
		if (rightItems != null)
		{
			m_createdContent = CreatedContent.Right;
			CreateContent(rightItems);
		}
	}

	private void CreateBottomContent()
	{
		SwipeItems bottomItems = BottomItems;
		if (bottomItems != null)
		{
			m_createdContent = CreatedContent.Bottom;
			CreateContent(bottomItems);
		}
	}

	private void CreateTopContent()
	{
		SwipeItems topItems = TopItems;
		if (topItems != null)
		{
			m_createdContent = CreatedContent.Top;
			CreateContent(topItems);
		}
	}

	private void CreateContent(SwipeItems items)
	{
		if (m_swipeContentStackPanel != null && m_swipeContentStackPanel.Children != null)
		{
			m_swipeContentStackPanel.Children.Clear();
		}
		m_currentItems = items;
		if (m_currentItems != null)
		{
			AlignStackPanel();
			PopulateContentItems();
			SetupExecuteExpressionAnimation();
			SetupClipAnimation();
			UpdateColors();
		}
	}

	private void AlignStackPanel()
	{
		if (m_currentItems.Size == 0)
		{
			return;
		}
		switch (m_currentItems.Mode)
		{
		case SwipeMode.Execute:
			if (m_isHorizontal)
			{
				m_swipeContentStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
				m_swipeContentStackPanel.VerticalAlignment = VerticalAlignment.Center;
			}
			else
			{
				m_swipeContentStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
				m_swipeContentStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
			}
			break;
		case SwipeMode.Reveal:
			if (m_isHorizontal)
			{
				HorizontalAlignment horizontalAlignment = ((m_createdContent != 0) ? ((m_createdContent == CreatedContent.Right) ? HorizontalAlignment.Right : HorizontalAlignment.Stretch) : HorizontalAlignment.Left);
				m_swipeContentStackPanel.HorizontalAlignment = horizontalAlignment;
				m_swipeContentStackPanel.VerticalAlignment = VerticalAlignment.Center;
			}
			else
			{
				VerticalAlignment verticalAlignment = ((m_createdContent != CreatedContent.Top) ? ((m_createdContent == CreatedContent.Bottom) ? VerticalAlignment.Bottom : VerticalAlignment.Stretch) : VerticalAlignment.Top);
				m_swipeContentStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
				m_swipeContentStackPanel.VerticalAlignment = verticalAlignment;
			}
			break;
		}
	}

	private void PopulateContentItems()
	{
		foreach (SwipeItem currentItem in m_currentItems)
		{
			m_swipeContentStackPanel.Children.Add(GetSwipeItemButton(currentItem));
		}
		TryGetSwipeVisuals();
	}

	private void SetupExecuteExpressionAnimation()
	{
		_ = m_currentItems.Mode;
		_ = 1;
	}

	private void SetupClipAnimation()
	{
	}

	private void UpdateColors()
	{
		if (m_currentItems.Mode == SwipeMode.Execute)
		{
			UpdateColorsIfExecuteItem();
		}
		else
		{
			UpdateColorsIfRevealItems();
		}
	}

	private AppBarButton GetSwipeItemButton(SwipeItem swipeItem)
	{
		AppBarButton appBarButton = new AppBarButton();
		swipeItem.GenerateControl(appBarButton, m_swipeItemStyle);
		if (swipeItem.Background == null)
		{
			object obj = SharedHelpers.FindInApplicationResources((m_currentItems.Mode == SwipeMode.Reveal) ? "SwipeItemBackground" : (m_thresholdReached ? "SwipeItemPostThresholdExecuteBackground" : "SwipeItemPreThresholdExecuteBackground"));
			if (obj != null)
			{
				appBarButton.Background = obj as Brush;
			}
		}
		if (swipeItem.Foreground == null)
		{
			object obj2 = SharedHelpers.FindInApplicationResources((m_currentItems.Mode == SwipeMode.Reveal) ? "SwipeItemForeground" : (m_thresholdReached ? "SwipeItemPostThresholdExecuteForeground" : "SwipeItemPreThresholdExecuteForeground"));
			if (obj2 != null)
			{
				appBarButton.Foreground = obj2 as Brush;
			}
		}
		if (m_isHorizontal)
		{
			appBarButton.Height = base.ActualHeight;
			if (m_currentItems.Mode == SwipeMode.Execute)
			{
				appBarButton.Width = base.ActualWidth;
			}
		}
		else
		{
			appBarButton.Width = base.ActualWidth;
			if (m_currentItems.Mode == SwipeMode.Execute)
			{
				appBarButton.Height = base.ActualHeight;
			}
		}
		return appBarButton;
	}

	private void UpdateColorsIfExecuteItem()
	{
		if (m_currentItems != null && m_currentItems.Mode == SwipeMode.Execute)
		{
			SwipeItem swipeItem = null;
			if (m_currentItems.Size != 0)
			{
				swipeItem = m_currentItems.GetAt(0u);
			}
			UpdateExecuteBackgroundColor(swipeItem);
			UpdateExecuteForegroundColor(swipeItem);
		}
	}

	private void UpdateExecuteBackgroundColor(SwipeItem swipeItem)
	{
		Brush background = null;
		if (!m_thresholdReached)
		{
			object obj = SharedHelpers.FindInApplicationResources("SwipeItemPreThresholdExecuteBackground");
			if (obj != null)
			{
				background = obj as Brush;
			}
		}
		else
		{
			object obj2 = SharedHelpers.FindInApplicationResources("SwipeItemPostThresholdExecuteBackground");
			if (obj2 != null)
			{
				background = obj2 as Brush;
			}
		}
		if (swipeItem != null && swipeItem.Background != null)
		{
			background = swipeItem.Background;
		}
		m_swipeContentStackPanel.Background = background;
		m_swipeContentRoot.Background = null;
	}

	private void UpdateExecuteForegroundColor(SwipeItem swipeItem)
	{
		if (m_swipeContentStackPanel.Children.Count <= 0 || !(m_swipeContentStackPanel.Children[0] is AppBarButton appBarButton))
		{
			return;
		}
		Brush foreground = null;
		if (!m_thresholdReached)
		{
			object obj = SharedHelpers.FindInApplicationResources("SwipeItemPreThresholdExecuteForeground");
			if (obj != null)
			{
				foreground = obj as Brush;
			}
		}
		else
		{
			object obj2 = SharedHelpers.FindInApplicationResources("SwipeItemPostThresholdExecuteForeground");
			if (obj2 != null)
			{
				foreground = obj2 as Brush;
			}
		}
		if (swipeItem != null && swipeItem.Foreground != null)
		{
			foreground = swipeItem.Foreground;
		}
		appBarButton.Foreground = foreground;
		appBarButton.Background = new SolidColorBrush(Colors.Transparent);
	}

	private void UpdateColorsIfRevealItems()
	{
		if (m_currentItems.Mode != 0)
		{
			return;
		}
		Brush background = null;
		object obj = SharedHelpers.FindInApplicationResources("SwipeItemBackground");
		if (obj != null)
		{
			background = obj as Brush;
		}
		if (m_currentItems.Size != 0)
		{
			switch (m_createdContent)
			{
			case CreatedContent.Left:
			case CreatedContent.Top:
			{
				Brush background3 = m_currentItems.GetAt((uint)(m_swipeContentStackPanel.Children.Count - 1)).Background;
				if (background3 != null)
				{
					background = background3;
				}
				break;
			}
			case CreatedContent.Bottom:
			case CreatedContent.Right:
			{
				Brush background2 = m_currentItems.GetAt(0u).Background;
				if (background2 != null)
				{
					background = background2;
				}
				break;
			}
			}
		}
		m_swipeContentRoot.Background = background;
		m_swipeContentStackPanel.Background = null;
	}

	private void OnLeftItemsChanged(IObservableVector<SwipeItem> sender, IVectorChangedEventArgs args)
	{
		ThrowIfHasVerticalAndHorizontalContent();
		_hasLeftContent = sender.Count > 0;
		if (m_createdContent == CreatedContent.Left)
		{
			CreateLeftContent();
		}
	}

	private void OnRightItemsChanged(IObservableVector<SwipeItem> sender, IVectorChangedEventArgs args)
	{
		ThrowIfHasVerticalAndHorizontalContent();
		_hasRightContent = sender.Count > 0;
		if (m_createdContent == CreatedContent.Right)
		{
			CreateRightContent();
		}
	}

	private void OnTopItemsChanged(IObservableVector<SwipeItem> sender, IVectorChangedEventArgs args)
	{
		ThrowIfHasVerticalAndHorizontalContent();
		_hasTopContent = sender.Count > 0;
		if (m_createdContent == CreatedContent.Top)
		{
			CreateTopContent();
		}
	}

	private void OnBottomItemsChanged(IObservableVector<SwipeItem> sender, IVectorChangedEventArgs args)
	{
		ThrowIfHasVerticalAndHorizontalContent();
		_hasBottomContent = sender.Count > 0;
		if (m_createdContent == CreatedContent.Bottom)
		{
			CreateBottomContent();
		}
	}

	private void TryGetSwipeVisuals()
	{
	}

	private void UpdateIsOpen(bool isOpen)
	{
		if (isOpen)
		{
			if (!m_isOpen)
			{
				m_isOpen = true;
				m_lastActionWasOpening = true;
				switch (m_createdContent)
				{
				case CreatedContent.Bottom:
				case CreatedContent.Right:
					_isFarOpen = true;
					_isNearOpen = false;
					break;
				case CreatedContent.Left:
				case CreatedContent.Top:
					_isFarOpen = false;
					_isNearOpen = true;
					break;
				case CreatedContent.None:
					_isFarOpen = false;
					_isNearOpen = false;
					break;
				}
				if (m_currentItems.Mode != SwipeMode.Execute)
				{
					AttachDismissingHandlers();
				}
				SwipeTestHooks.GetGlobalTestHooks()?.NotifyOpenedStatusChanged(this);
			}
		}
		else if (m_isOpen)
		{
			m_isOpen = false;
			m_lastActionWasClosing = true;
			DetachDismissingHandlers();
			_isFarOpen = false;
			_isNearOpen = false;
			SwipeTestHooks.GetGlobalTestHooks()?.NotifyOpenedStatusChanged(this);
		}
	}

	private void UpdateThresholdReached(float value)
	{
		bool thresholdReached = m_thresholdReached;
		float num = (float)((m_isHorizontal ? m_swipeContentStackPanel.ActualWidth : m_swipeContentStackPanel.ActualHeight) - 1.0);
		if (!m_isOpen || m_lastActionWasOpening)
		{
			m_thresholdReached = Math.Abs(value) > Math.Min(num, 100f);
		}
		else
		{
			m_thresholdReached = Math.Abs(value) < num;
		}
		if (m_thresholdReached != thresholdReached)
		{
			UpdateColorsIfExecuteItem();
		}
	}

	private void ThrowIfHasVerticalAndHorizontalContent(bool setIsHorizontal = false)
	{
		bool flag = LeftItems != null && LeftItems.Size != 0;
		bool flag2 = RightItems != null && RightItems.Size != 0;
		bool flag3 = TopItems != null && TopItems.Size != 0;
		bool flag4 = BottomItems != null && BottomItems.Size != 0;
		if (setIsHorizontal)
		{
			m_isHorizontal = flag || flag2 || !(flag3 || flag4);
		}
		if (base.Template != null)
		{
			if (m_isHorizontal && (flag3 || flag4))
			{
				throw new ArgumentException("This SwipeControl is horizontal and can not have vertical items.");
			}
			if (!m_isHorizontal && (flag || flag2))
			{
				throw new ArgumentException("This SwipeControl is vertical and can not have horizontal items.");
			}
		}
		else if ((flag || flag2) && (flag3 || flag4))
		{
			throw new ArgumentException("SwipeControl can't have both horizontal items and vertical items set at the same time.");
		}
	}

	private string GetAnimationTarget(UIElement child)
	{
		if (DownlevelHelper.SetIsTranslationEnabledExists() || SharedHelpers.IsTranslationFacadeAvailable(child))
		{
			return "Translation";
		}
		return "Offset";
	}

	private SwipeControl GetThis()
	{
		return this;
	}

	private bool IsTranslationFacadeAvailableForSwipeControl(UIElement element)
	{
		return false;
	}

	private string DirectionToInset(CreatedContent createdContent)
	{
		return createdContent switch
		{
			CreatedContent.Right => "LeftInset", 
			CreatedContent.Left => "RightInset", 
			CreatedContent.Bottom => "TopInset", 
			CreatedContent.Top => "BottomInset", 
			CreatedContent.None => "", 
			_ => "", 
		};
	}

	private static string isNearOpenPropertyName()
	{
		return "isNearOpen";
	}

	private static string isFarOpenPropertyName()
	{
		return "isFarOpen";
	}

	private static string isNearContentPropertyName()
	{
		return "isNearContent";
	}

	private static string blockNearContentPropertyName()
	{
		return "blockNearContent";
	}

	private static string blockFarContentPropertyName()
	{
		return "blockFarContent";
	}

	private static string hasLeftContentPropertyName()
	{
		return "hasLeftContent";
	}

	private static string hasRightContentPropertyName()
	{
		return "hasRightContent";
	}

	private static string hasTopContentPropertyName()
	{
		return "hasTopContent";
	}

	private static string hasBottomContentPropertyName()
	{
		return "hasBottomContent";
	}

	private static string isHorizontalPropertyName()
	{
		return "isHorizontal";
	}

	private static string trackerPropertyName()
	{
		return "tracker";
	}

	private static string foregroundVisualPropertyName()
	{
		return "foregroundVisual";
	}

	private static string swipeContentVisualPropertyName()
	{
		return "swipeContentVisual";
	}

	private static string swipeContentSizeParameterName()
	{
		return "swipeContentVisual";
	}

	private static string swipeRootVisualPropertyName()
	{
		return "swipeRootVisual";
	}

	private static string maxThresholdPropertyName()
	{
		return "maxThreshold";
	}

	private static void OnBottomItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeControl swipeControl = (SwipeControl)sender;
		swipeControl.OnPropertyChanged(args);
	}

	private static void OnLeftItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeControl swipeControl = (SwipeControl)sender;
		swipeControl.OnPropertyChanged(args);
	}

	private static void OnRightItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeControl swipeControl = (SwipeControl)sender;
		swipeControl.OnPropertyChanged(args);
	}

	private static void OnTopItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeControl swipeControl = (SwipeControl)sender;
		swipeControl.OnPropertyChanged(args);
	}

	[Conditional("DEBUG")]
	private static void SWIPECONTROL_TRACE_INFO(SwipeControl that, [CallerLineNumber] int TRACE_MSG_METH = -1, [CallerMemberName] string METH_NAME = null, SwipeControl _ = null)
	{
	}

	[Conditional("DEBUG")]
	private static void SWIPECONTROL_TRACE_VERBOSE(SwipeControl that, [CallerLineNumber] int TRACE_MSG_METH = -1, [CallerMemberName] string METH_NAME = null, SwipeControl _ = null)
	{
	}

	private void InitializeInteractionTracker()
	{
		if (m_content.RenderTransform == null || _transform == null)
		{
			m_content.RenderTransform = (_transform = new TranslateTransform());
		}
		if (m_swipeContentStackPanel.RenderTransform == null || _swipeStackPaneltransform == null)
		{
			m_swipeContentStackPanel.RenderTransform = (_swipeStackPaneltransform = new TranslateTransform());
		}
	}

	private void UnoAttachEventHandlers()
	{
		m_content.ManipulationMode = (m_isHorizontal ? ManipulationModes.TranslateX : ManipulationModes.TranslateY);
		m_content.ManipulationStarting += OnSwipeManipulationStarting;
		m_content.ManipulationStarted += OnSwipeManipulationStarted;
		m_content.ManipulationDelta += OnSwipeManipulationDelta;
		m_content.ManipulationCompleted += OnSwipeManipulationCompleted;
	}

	private void UnoDetachEventHandlers()
	{
		if (m_content != null)
		{
			m_content.ManipulationStarting -= OnSwipeManipulationStarting;
			m_content.ManipulationStarted -= OnSwipeManipulationStarted;
			m_content.ManipulationDelta -= OnSwipeManipulationDelta;
			m_content.ManipulationCompleted -= OnSwipeManipulationCompleted;
		}
	}

	private void OnSwipeManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
	{
	}

	private void OnSwipeManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
	{
		if (e.PointerDeviceType != 0)
		{
			e.Complete();
			return;
		}
		if (m_isIdle)
		{
			m_isIdle = false;
		}
		m_lastActionWasClosing = false;
		m_lastActionWasOpening = false;
		m_isInteracting = true;
		if (!m_isOpen)
		{
			m_blockNearContent = false;
			m_blockFarContent = false;
		}
		_positionWhenCaptured = new Vector2((float)_transform.X, (float)_transform.Y);
		PointerIdentifier[] pointers = e.Pointers;
		foreach (PointerIdentifier pointer in pointers)
		{
			if (!PointerCapture.TryGet(pointer, out var capture))
			{
				continue;
			}
			List<PointerCaptureTarget> list = capture.GetTargets(PointerCaptureKind.Explicit).ToList();
			foreach (PointerCaptureTarget item in list)
			{
				item.Element.ReleasePointerCapture(capture.Pointer);
			}
		}
	}

	private void OnSwipeManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
	{
		if (e.PointerDeviceType != 0)
		{
			return;
		}
		UpdateDesiredPosition(e);
		UpdateStackPanelDesiredPosition();
		s_lastInteractedWithSwipeControl.TryGetTarget(out var target);
		if (m_isInteracting && (target == null || target != this))
		{
			target?.CloseIfNotRemainOpenExecuteItem();
			s_lastInteractedWithSwipeControl.SetTarget(this);
			SwipeTestHooks.GetGlobalTestHooks()?.NotifyLastInteractedWithSwipeControlChanged();
		}
		float num = 0f;
		if (m_isHorizontal)
		{
			num = 0f - _desiredPosition.X;
			if (!m_blockNearContent && m_createdContent != 0 && (double)num < -0.0001)
			{
				CreateLeftContent();
			}
			else if (!m_blockFarContent && m_createdContent != CreatedContent.Right && (double)num > 0.0001)
			{
				CreateRightContent();
			}
		}
		else
		{
			num = 0f - _desiredPosition.Y;
			if (!m_blockNearContent && m_createdContent != CreatedContent.Top && (double)num < -0.0001)
			{
				CreateTopContent();
			}
			else if (!m_blockFarContent && m_createdContent != CreatedContent.Bottom && (double)num > 0.0001)
			{
				CreateBottomContent();
			}
		}
		UpdateThresholdReached(num);
		UpdateTransforms();
	}

	private void UpdateDesiredPosition(ManipulationDeltaRoutedEventArgs e)
	{
		Vector2 rawDesiredPosition = _positionWhenCaptured + e.Cumulative.Translation.ToVector2();
		Vector2 clampedPosition = GetClampedPosition(rawDesiredPosition);
		Vector2 vector = (_desiredPosition = GetAttenuatedPosition(clampedPosition));
	}

	private Vector2 GetClampedPosition(Vector2 rawDesiredPosition)
	{
		bool flag = _hasLeftContent || _hasTopContent;
		bool flag2 = _hasRightContent || _hasBottomContent;
		int num = ((!_isNearOpen && flag2) ? (-10000) : 0);
		int num2 = ((!_isFarOpen && flag) ? 10000 : 0);
		return Vector2.Max(Vector2.Min(rawDesiredPosition, Vector2.One * num2), Vector2.One * num);
	}

	private void UpdateStackPanelDesiredPosition()
	{
		int num = ((m_createdContent != 0 && m_createdContent != CreatedContent.Top) ? 1 : (-1));
		if (m_isHorizontal)
		{
			if (m_swipeContentStackPanel.HorizontalAlignment == HorizontalAlignment.Stretch)
			{
				_desiredStackPanelPosition.X = (float)((double)num * base.ActualWidth * 0.5 + (double)_desiredPosition.X * 0.5);
			}
			else
			{
				_desiredStackPanelPosition.X = 0f;
			}
		}
		else if (m_swipeContentStackPanel.VerticalAlignment == VerticalAlignment.Stretch)
		{
			_desiredStackPanelPosition.Y = (float)((double)num * base.ActualHeight * 0.5 + (double)_desiredPosition.Y * 0.5);
		}
		else
		{
			_desiredStackPanelPosition.Y = 0f;
		}
	}

	private async void OnSwipeManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
	{
		try
		{
			if (e != null && e.PointerDeviceType != 0)
			{
				return;
			}
			await SimulateInertia(e?.Velocities ?? default(ManipulationVelocities));
			m_isInteracting = false;
			UpdateIsOpen(_desiredPosition != Vector2.Zero);
			if (m_isOpen)
			{
				if (m_currentItems != null && m_currentItems.Mode == SwipeMode.Execute && m_currentItems.Count > 0)
				{
					SwipeItem at = m_currentItems.GetAt(0u);
					at.InvokeSwipe(this);
				}
			}
			else
			{
				StackPanel swipeContentStackPanel = m_swipeContentStackPanel;
				if (swipeContentStackPanel != null)
				{
					swipeContentStackPanel.Background = null;
					swipeContentStackPanel.Children?.Clear();
				}
				Grid swipeContentRoot = m_swipeContentRoot;
				if (swipeContentRoot != null)
				{
					swipeContentRoot.Background = null;
				}
				m_currentItems = null;
				m_createdContent = CreatedContent.None;
			}
			if (!m_isIdle)
			{
				m_isIdle = true;
				SwipeTestHooks.GetGlobalTestHooks()?.NotifyIdleStatusChanged(this);
			}
		}
		catch (Exception e2)
		{
			Application.Current.RaiseRecoverableUnhandledException(e2);
		}
	}

	private async Task SimulateInertia(ManipulationVelocities v)
	{
		float num = (float)GestureRecognizer.Manipulation.InertiaTouch.TranslateX * 1000f;
		Vector2 vector = (m_isHorizontal ? Vector2.UnitX : Vector2.UnitY);
		float num2 = (float)(m_isHorizontal ? v.Linear.X : v.Linear.Y) * 1000f;
		bool useInertiaSpeed = false;
		Vector2 vector2 = _desiredPosition;
		if (Math.Abs(num2) > num)
		{
			if (m_swipeContentStackPanel.IsMeasureDirty || m_swipeContentStackPanel.IsArrangeDirty)
			{
				await base.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
				{
					SimulateInertia(v);
				});
				return;
			}
			vector2 = _desiredPosition + vector * num2 * 0.5f;
			vector2 = GetClampedPosition(vector2);
			Vector2 vector3 = _desiredPosition * vector2;
			if (m_isHorizontal ? (vector3.X < 0f) : (vector3.Y < 0f))
			{
				CloseWithoutAnimation();
				return;
			}
			_desiredPosition = vector2;
			useInertiaSpeed = true;
		}
		float value = (m_isHorizontal ? _desiredPosition.X : _desiredPosition.Y);
		float num3 = Math.Abs(value);
		double num4 = (m_isHorizontal ? m_swipeContentStackPanel.ActualWidth : m_swipeContentStackPanel.ActualHeight);
		if (m_isOpen)
		{
			if ((double)num3 < num4)
			{
				_desiredPosition = Vector2.Zero;
			}
			else
			{
				_desiredPosition = vector * (float)num4 * Math.Sign(value);
			}
		}
		else if (m_createdContent != CreatedContent.None && ((double)num3 > num4 || num3 > 100f))
		{
			_desiredPosition = vector * (float)num4 * Math.Sign(value);
		}
		else
		{
			_desiredPosition = Vector2.Zero;
		}
		Vector2 vector4 = _desiredPosition - vector2;
		float num5 = (m_isHorizontal ? vector4.X : vector4.Y);
		if (num5 * num2 < 0f)
		{
			useInertiaSpeed = false;
		}
		UpdateStackPanelDesiredPosition();
		await AnimateTransforms(useInertiaSpeed, num2);
		m_isInteracting = false;
		if (m_isIdle)
		{
			m_isIdle = false;
			SwipeTestHooks.GetGlobalTestHooks()?.NotifyIdleStatusChanged(this);
		}
		UpdateIsOpen(_desiredPosition != Vector2.Zero);
		if (m_isOpen)
		{
			switch (m_createdContent)
			{
			case CreatedContent.Bottom:
			case CreatedContent.Right:
				m_blockNearContent = true;
				m_blockFarContent = false;
				break;
			case CreatedContent.Left:
			case CreatedContent.Top:
				m_blockNearContent = false;
				m_blockFarContent = true;
				break;
			case CreatedContent.None:
				m_blockNearContent = false;
				m_blockFarContent = false;
				break;
			}
		}
	}

	private void ConfigurePositionInertiaRestingValues()
	{
	}

	private void IdleStateEntered(object @null, object also_null)
	{
	}

	private void UpdateTransforms()
	{
		if (m_isHorizontal)
		{
			_transform.X = _desiredPosition.X;
			_swipeStackPaneltransform.X = _desiredStackPanelPosition.X;
			_transform.SetValue(TranslateTransform.XProperty, (double)_desiredPosition.X, DependencyPropertyValuePrecedences.Animations);
			_swipeStackPaneltransform.SetValue(TranslateTransform.XProperty, (double)_desiredStackPanelPosition.X, DependencyPropertyValuePrecedences.Animations);
		}
		else
		{
			_transform.Y = _desiredPosition.Y;
			_swipeStackPaneltransform.Y = _desiredStackPanelPosition.Y;
			_transform.SetValue(TranslateTransform.YProperty, (double)_desiredPosition.Y, DependencyPropertyValuePrecedences.Animations);
			_swipeStackPaneltransform.SetValue(TranslateTransform.YProperty, (double)_desiredStackPanelPosition.Y, DependencyPropertyValuePrecedences.Animations);
		}
	}

	private async Task AnimateTransforms(bool useInertiaSpeed, double inertiaSpeed)
	{
		double num = (m_isHorizontal ? _transform.X : _transform.Y);
		float num2 = (m_isHorizontal ? _desiredPosition.X : _desiredPosition.Y);
		double num3 = Math.Abs((double)num2 - num);
		double value = Math.Min(num3 / 31.0, 0.3);
		if (useInertiaSpeed)
		{
			value = num3 / inertiaSpeed;
		}
		Storyboard storyboard = new Storyboard();
		DoubleAnimation obj = new DoubleAnimation
		{
			To = num2,
			Duration = new Duration(TimeSpan.FromSeconds(value))
		};
		IEasingFunction easingFunction2;
		if (!useInertiaSpeed)
		{
			IEasingFunction easingFunction = new QuadraticEase
			{
				EasingMode = EasingMode.EaseInOut
			};
			easingFunction2 = easingFunction;
		}
		else
		{
			IEasingFunction easingFunction = LinearEase.Instance;
			easingFunction2 = easingFunction;
		}
		obj.EasingFunction = easingFunction2;
		DoubleAnimation doubleAnimation = obj;
		Storyboard.SetTarget(doubleAnimation, _transform);
		Storyboard.SetTargetProperty(doubleAnimation, m_isHorizontal ? "X" : "Y");
		storyboard.Children.Add(doubleAnimation);
		double num4 = (m_isHorizontal ? _swipeStackPaneltransform.X : _swipeStackPaneltransform.Y);
		float num5 = (m_isHorizontal ? _desiredStackPanelPosition.X : _desiredStackPanelPosition.Y);
		if (num4 != (double)num5)
		{
			DoubleAnimation obj2 = new DoubleAnimation
			{
				To = num5,
				Duration = new Duration(TimeSpan.FromSeconds(value))
			};
			IEasingFunction easingFunction3;
			if (!useInertiaSpeed)
			{
				IEasingFunction easingFunction = new QuadraticEase
				{
					EasingMode = EasingMode.EaseInOut
				};
				easingFunction3 = easingFunction;
			}
			else
			{
				IEasingFunction easingFunction = LinearEase.Instance;
				easingFunction3 = easingFunction;
			}
			obj2.EasingFunction = easingFunction3;
			DoubleAnimation doubleAnimation2 = obj2;
			Storyboard.SetTarget(doubleAnimation2, _swipeStackPaneltransform);
			Storyboard.SetTargetProperty(doubleAnimation2, m_isHorizontal ? "X" : "Y");
			storyboard.Children.Add(doubleAnimation2);
		}
		await storyboard.Run();
	}

	private Vector2 GetAttenuatedPosition(Vector2 desiredPosition)
	{
		double num = (m_isHorizontal ? m_swipeContentStackPanel.ActualWidth : m_swipeContentStackPanel.ActualHeight);
		float value = (m_isHorizontal ? desiredPosition.X : desiredPosition.Y);
		Vector2 vector = (m_isHorizontal ? Vector2.UnitX : Vector2.UnitY);
		double num2 = (double)Math.Abs(value) - num;
		if (num2 > 0.0)
		{
			return vector * Math.Sign(value) * (float)(num + num2 * 0.5);
		}
		return desiredPosition;
	}
}

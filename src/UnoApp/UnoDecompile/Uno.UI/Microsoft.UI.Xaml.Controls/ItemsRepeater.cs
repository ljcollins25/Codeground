using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.UI.Xaml.Automation.Peers;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

[ContentProperty(Name = "ItemTemplate")]
public class ItemsRepeater : FrameworkElement, IPanel
{
	private const uint MaxStackLayoutIterations = 60u;

	private readonly UIElementCollection _repeaterChildren;

	internal static Point ClearedElementsArrangePosition = new Point(-10000.0, -10000.0);

	internal static Rect InvalidRect = new Rect(-1.0, -1.0, -1.0, -1.0);

	private ItemsRepeaterElementPreparedEventArgs m_elementPreparedArgs;

	private ItemsRepeaterElementClearingEventArgs m_elementClearingArgs;

	private ItemsRepeaterElementIndexChangedEventArgs m_elementIndexChangedArgs;

	private AnimationManager m_animationManager;

	private ViewManager m_viewManager;

	private ViewportManager m_viewportManager;

	private ItemsSourceView m_itemsSourceView;

	private IElementFactoryShim m_itemTemplateWrapper;

	private VirtualizingLayoutContext m_layoutContext;

	private object m_layoutState;

	private NotifyCollectionChangedEventArgs m_processingItemsSourceChange;

	private Size m_lastAvailableSize;

	private bool m_isLayoutInProgress;

	private Point m_layoutOrigin;

	private int _loadedCounter;

	private int _unloadedCounter;

	private uint _stackLayoutMeasureCounter;

	private IElementFactory m_itemTemplate;

	private Layout m_layout;

	private ElementAnimator m_animator;

	private bool m_isItemTemplateEmpty;

	private static readonly DependencyProperty VirtualizationInfoProperty = DependencyProperty.RegisterAttached("VirtualizationInfo", typeof(VirtualizationInfo), typeof(ItemsRepeater), new FrameworkPropertyMetadata((object)null));

	internal IElementFactoryShim ItemTemplateShim => m_itemTemplateWrapper;

	internal object LayoutState
	{
		get
		{
			return m_layoutState;
		}
		set
		{
			m_layoutState = value;
		}
	}

	internal Rect VisibleWindow => m_viewportManager.GetLayoutVisibleWindow();

	internal Rect RealizationWindow => m_viewportManager.GetLayoutRealizationWindow();

	internal UIElement SuggestedAnchor => m_viewportManager.SuggestedAnchor;

	internal UIElement MadeAnchor => m_viewportManager.MadeAnchor;

	internal Point LayoutOrigin
	{
		get
		{
			return m_layoutOrigin;
		}
		set
		{
			m_layoutOrigin = value;
		}
	}

	UIElementCollection IPanel.Children => _repeaterChildren;

	internal IList<UIElement> Children => _repeaterChildren;

	internal ViewManager ViewManager => m_viewManager;

	internal AnimationManager AnimationManager => m_animationManager;

	private bool IsProcessingCollectionChange => m_processingItemsSourceChange != null;

	public ItemsSourceView ItemsSourceView => m_itemsSourceView;

	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(ItemsRepeater), new FrameworkPropertyMetadata(null, OnPropertyChanged));


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

	public static DependencyProperty ItemTemplateProperty { get; } = DependencyProperty.Register("ItemTemplate", typeof(object), typeof(ItemsRepeater), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public object ItemTemplate
	{
		get
		{
			return GetValue(ItemTemplateProperty);
		}
		set
		{
			SetValue(ItemTemplateProperty, value);
		}
	}

	public static DependencyProperty LayoutProperty { get; } = DependencyProperty.Register("Layout", typeof(Layout), typeof(ItemsRepeater), new FrameworkPropertyMetadata(new StackLayout(), OnPropertyChanged));


	public Layout Layout
	{
		get
		{
			return (Layout)GetValue(LayoutProperty);
		}
		set
		{
			SetValue(LayoutProperty, value);
		}
	}

	public static DependencyProperty AnimatorProperty { get; } = DependencyProperty.Register("Animator", typeof(ElementAnimator), typeof(ItemsRepeater), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public ElementAnimator Animator
	{
		get
		{
			return (ElementAnimator)GetValue(AnimatorProperty);
		}
		set
		{
			SetValue(AnimatorProperty, value);
		}
	}

	public static DependencyProperty HorizontalCacheLengthProperty { get; } = DependencyProperty.Register("HorizontalCacheLength", typeof(double), typeof(ItemsRepeater), new FrameworkPropertyMetadata(2.0, OnPropertyChanged));


	public double HorizontalCacheLength
	{
		get
		{
			return (double)GetValue(HorizontalCacheLengthProperty);
		}
		set
		{
			SetValue(HorizontalCacheLengthProperty, value);
		}
	}

	public static DependencyProperty VerticalCacheLengthProperty { get; } = DependencyProperty.Register("VerticalCacheLength", typeof(double), typeof(ItemsRepeater), new FrameworkPropertyMetadata(2.0, OnPropertyChanged));


	public double VerticalCacheLength
	{
		get
		{
			return (double)GetValue(VerticalCacheLengthProperty);
		}
		set
		{
			SetValue(VerticalCacheLengthProperty, value);
		}
	}

	public event TypedEventHandler<ItemsRepeater, ItemsRepeaterElementPreparedEventArgs> ElementPrepared;

	public event TypedEventHandler<ItemsRepeater, ItemsRepeaterElementIndexChangedEventArgs> ElementIndexChanged;

	public event TypedEventHandler<ItemsRepeater, ItemsRepeaterElementClearingEventArgs> ElementClearing;

	internal event TypedEventHandler<ItemsRepeater, ItemsRepeaterElementPreparedEventArgs> UnoBeforeElementPrepared;

	public ItemsRepeater()
	{
		_repeaterChildren = new UIElementCollection(this);
		m_animationManager = new AnimationManager(this);
		m_viewManager = new ViewManager(this);
		m_viewportManager = new ViewportManagerWithPlatformFeatures(this);
		AutomationProperties.SetAccessibilityView(this, AccessibilityView.Raw);
		base.TabFocusNavigation = KeyboardNavigationMode.Once;
		base.XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled;
		base.Loaded += OnLoaded;
		base.Unloaded += OnUnloaded;
		base.LayoutUpdated += OnLayoutUpdated;
		VirtualizingLayout newValue = Layout as VirtualizingLayout;
		OnLayoutChanged(null, newValue);
	}

	~ItemsRepeater()
	{
		m_itemTemplate = null;
		m_animator = null;
		m_layout = null;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new RepeaterAutomationPeer(this);
	}

	protected override IEnumerable<DependencyObject> GetChildrenInTabFocusOrder()
	{
		return CreateChildrenInTabFocusOrderIterable();
	}

	protected override void OnBringIntoViewRequested(BringIntoViewRequestedEventArgs e)
	{
		m_viewportManager.OnBringIntoViewRequested(e);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (m_isLayoutInProgress)
		{
			throw new InvalidOperationException("Reentrancy detected during layout.");
		}
		if (IsProcessingCollectionChange)
		{
			throw new InvalidOperationException("Cannot run layout in the middle of a collection change.");
		}
		Layout layout = Layout;
		if (layout != null && layout is StackLayout && ++_stackLayoutMeasureCounter >= 60)
		{
			Rect layoutExtent = m_viewportManager.GetLayoutExtent();
			return new Size(layoutExtent.Width - layoutExtent.X, layoutExtent.Height - layoutExtent.Y);
		}
		m_viewportManager.OnOwnerMeasuring();
		m_isLayoutInProgress = true;
		using (Disposable.Create(delegate
		{
			m_isLayoutInProgress = false;
		}))
		{
			m_viewManager.PrunePinnedElements();
			Rect layoutExtent2 = default(Rect);
			Size result = default(Size);
			if (layout != null)
			{
				VirtualizingLayoutContext layoutContext = GetLayoutContext();
				if (m_isItemTemplateEmpty)
				{
					layoutExtent2 = new Rect(m_layoutOrigin.X, m_layoutOrigin.Y, 0.0, 0.0);
				}
				else
				{
					result = layout.Measure(layoutContext, availableSize);
					layoutExtent2 = new Rect(m_layoutOrigin.X, m_layoutOrigin.Y, result.Width, result.Height);
				}
				IList<UIElement> children = Children;
				for (int i = 0; i < children.Count; i++)
				{
					UIElement element = children[i];
					VirtualizationInfo virtualizationInfo = GetVirtualizationInfo(element);
					if (virtualizationInfo.Owner == ElementOwner.Layout && virtualizationInfo.AutoRecycleCandidate && !virtualizationInfo.KeepAlive)
					{
						ClearElementImpl(element);
					}
				}
			}
			m_viewportManager.SetLayoutExtent(layoutExtent2);
			m_lastAvailableSize = availableSize;
			return result;
		}
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		if (m_isLayoutInProgress)
		{
			throw new InvalidOperationException("Reentrancy detected during layout.");
		}
		if (IsProcessingCollectionChange)
		{
			throw new InvalidOperationException("Cannot run layout in the middle of a collection change.");
		}
		m_isLayoutInProgress = true;
		using (Disposable.Create(delegate
		{
			m_isLayoutInProgress = false;
		}))
		{
			Size result = default(Size);
			Layout layout = Layout;
			if (layout != null)
			{
				result = layout.Arrange(GetLayoutContext(), finalSize);
			}
			m_viewManager.OnOwnerArranged();
			IList<UIElement> children = Children;
			for (int i = 0; i < children.Count; i++)
			{
				UIElement uIElement = children[i];
				VirtualizationInfo virtualizationInfo = GetVirtualizationInfo(uIElement);
				virtualizationInfo.KeepAlive = false;
				if (virtualizationInfo.Owner == ElementOwner.ElementFactory || virtualizationInfo.Owner == ElementOwner.PinnedPool)
				{
					uIElement.Arrange(new Rect(ClearedElementsArrangePosition.X - (double)(float)uIElement.DesiredSize.Width, ClearedElementsArrangePosition.Y - (double)(float)uIElement.DesiredSize.Height, 0.0, 0.0));
					continue;
				}
				Rect layoutSlot = CachedVisualTreeHelpers.GetLayoutSlot(uIElement as FrameworkElement);
				if (virtualizationInfo.ArrangeBounds != InvalidRect && layoutSlot != virtualizationInfo.ArrangeBounds)
				{
					m_animationManager.OnElementBoundsChanged(uIElement, virtualizationInfo.ArrangeBounds, layoutSlot);
				}
				virtualizationInfo.ArrangeBounds = layoutSlot;
			}
			m_viewportManager.OnOwnerArranged();
			m_animationManager.OnOwnerArranged();
			return result;
		}
	}

	public int GetElementIndex(UIElement element)
	{
		return GetElementIndexImpl(element);
	}

	public UIElement TryGetElement(int index)
	{
		return GetElementFromIndexImpl(index);
	}

	internal void PinElement(UIElement element)
	{
		m_viewManager.UpdatePin(element, addPin: true);
	}

	internal void UnpinElement(UIElement element)
	{
		m_viewManager.UpdatePin(element, addPin: false);
	}

	public UIElement GetOrCreateElement(int index)
	{
		return GetOrCreateElementImpl(index);
	}

	public UIElement GetElementImpl(int index, bool forceCreate, bool suppressAutoRecycle)
	{
		return m_viewManager.GetElement(index, forceCreate, suppressAutoRecycle);
	}

	public void ClearElementImpl(UIElement element)
	{
		bool isClearedDueToCollectionChange = IsProcessingCollectionChange && (m_processingItemsSourceChange.Action == NotifyCollectionChangedAction.Remove || m_processingItemsSourceChange.Action == NotifyCollectionChangedAction.Replace || m_processingItemsSourceChange.Action == NotifyCollectionChangedAction.Reset);
		m_viewManager.ClearElement(element, isClearedDueToCollectionChange);
		m_viewportManager.OnElementCleared(element);
	}

	private int GetElementIndexImpl(UIElement element)
	{
		DependencyObject parent = VisualTreeHelper.GetParent(element);
		if (parent == this)
		{
			VirtualizationInfo virtInfo = TryGetVirtualizationInfo(element);
			return m_viewManager.GetElementIndex(virtInfo);
		}
		return -1;
	}

	private UIElement GetElementFromIndexImpl(int index)
	{
		UIElement uIElement = null;
		IList<UIElement> children = Children;
		for (int i = 0; i < children.Count; i++)
		{
			if (uIElement != null)
			{
				break;
			}
			UIElement uIElement2 = children[i];
			VirtualizationInfo virtualizationInfo = TryGetVirtualizationInfo(uIElement2);
			if (virtualizationInfo != null && virtualizationInfo.IsRealized && virtualizationInfo.Index == index)
			{
				uIElement = uIElement2;
			}
		}
		return uIElement;
	}

	private UIElement GetOrCreateElementImpl(int index)
	{
		if (ItemsSourceView == null)
		{
			throw new InvalidOperationException("ItemSource doesn't have a value");
		}
		if (index >= 0 && index >= ItemsSourceView.Count)
		{
			throw new ArgumentException("index", "Argument index is invalid.");
		}
		if (m_isLayoutInProgress)
		{
			throw new InvalidOperationException("GetOrCreateElement invocation is not allowed during layout.");
		}
		UIElement uIElement = GetElementFromIndexImpl(index);
		bool flag = uIElement == null;
		if (flag)
		{
			if (Layout == null)
			{
				throw new InvalidOperationException("Cannot make an Anchor when there is no attached layout.");
			}
			uIElement = GetLayoutContext().GetOrCreateElementAt(index);
			uIElement.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
		}
		m_viewportManager.OnMakeAnchor(uIElement, flag);
		InvalidateMeasure();
		return uIElement;
	}

	internal static VirtualizationInfo TryGetVirtualizationInfo(UIElement element)
	{
		object value = element.GetValue(VirtualizationInfoProperty);
		return (VirtualizationInfo)value;
	}

	internal static VirtualizationInfo GetVirtualizationInfo(UIElement element)
	{
		VirtualizationInfo virtualizationInfo = TryGetVirtualizationInfo(element);
		if (virtualizationInfo == null)
		{
			virtualizationInfo = CreateAndInitializeVirtualizationInfo(element);
		}
		return virtualizationInfo;
	}

	internal static VirtualizationInfo CreateAndInitializeVirtualizationInfo(UIElement element)
	{
		VirtualizationInfo virtualizationInfo = new VirtualizationInfo();
		element.SetValue(VirtualizationInfoProperty, virtualizationInfo);
		return virtualizationInfo;
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == ItemsSourceProperty)
		{
			if (args.NewValue != args.OldValue)
			{
				object newValue = args.NewValue;
				ItemsSourceView itemsSourceView = newValue as ItemsSourceView;
				if (newValue != null && itemsSourceView == null)
				{
					itemsSourceView = new InspectingDataSource(newValue);
				}
				OnDataSourcePropertyChanged(m_itemsSourceView, itemsSourceView);
			}
		}
		else if (property == ItemTemplateProperty)
		{
			OnItemTemplateChanged(args.OldValue, args.NewValue);
		}
		else if (property == LayoutProperty)
		{
			OnLayoutChanged(args.OldValue as Layout, args.NewValue as Layout);
		}
		else if (property == AnimatorProperty)
		{
			OnAnimatorChanged(args.OldValue as ElementAnimator, args.NewValue as ElementAnimator);
		}
		else if (property == HorizontalCacheLengthProperty)
		{
			m_viewportManager.HorizontalCacheLength = (double)args.NewValue;
		}
		else if (property == VerticalCacheLengthProperty)
		{
			m_viewportManager.VerticalCacheLength = (double)args.NewValue;
		}
	}

	internal void OnElementPrepared(UIElement element, int index)
	{
		m_viewportManager.OnElementPrepared(element);
		TypedEventHandler<ItemsRepeater, ItemsRepeaterElementPreparedEventArgs> elementPrepared = this.ElementPrepared;
		if (elementPrepared != null)
		{
			if (m_elementPreparedArgs == null)
			{
				m_elementPreparedArgs = new ItemsRepeaterElementPreparedEventArgs(element, index);
			}
			else
			{
				m_elementPreparedArgs.Update(element, index);
			}
			elementPrepared(this, m_elementPreparedArgs);
		}
	}

	internal void OnElementClearing(UIElement element)
	{
		TypedEventHandler<ItemsRepeater, ItemsRepeaterElementClearingEventArgs> elementClearing = this.ElementClearing;
		if (elementClearing != null)
		{
			if (m_elementClearingArgs == null)
			{
				m_elementClearingArgs = new ItemsRepeaterElementClearingEventArgs(element);
			}
			else
			{
				m_elementClearingArgs.Update(element);
			}
			elementClearing(this, m_elementClearingArgs);
		}
	}

	internal void OnElementIndexChanged(UIElement element, int oldIndex, int newIndex)
	{
		TypedEventHandler<ItemsRepeater, ItemsRepeaterElementIndexChangedEventArgs> elementIndexChanged = this.ElementIndexChanged;
		if (elementIndexChanged != null)
		{
			if (m_elementIndexChangedArgs == null)
			{
				m_elementIndexChangedArgs = new ItemsRepeaterElementIndexChangedEventArgs(element, oldIndex, newIndex);
			}
			else
			{
				m_elementIndexChangedArgs.Update(element, in oldIndex, in newIndex);
			}
			elementIndexChanged(this, m_elementIndexChangedArgs);
		}
	}

	internal int Indent()
	{
		int num = 1;
		return num * 4;
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		if (_loadedCounter > _unloadedCounter)
		{
			InvalidateMeasure();
			m_viewportManager.ResetScrollers();
		}
		_loadedCounter++;
	}

	private void OnUnloaded(object sender, RoutedEventArgs args)
	{
		_stackLayoutMeasureCounter = 0u;
		_unloadedCounter++;
		if (_unloadedCounter == _loadedCounter)
		{
			m_viewportManager.ResetScrollers();
		}
	}

	private void OnLayoutUpdated(object sender, object e)
	{
		_stackLayoutMeasureCounter = 0u;
	}

	private void OnDataSourcePropertyChanged(ItemsSourceView oldValue, ItemsSourceView newValue)
	{
		if (m_isLayoutInProgress)
		{
			throw new InvalidOperationException("Cannot set ItemsSourceView during layout.");
		}
		m_itemsSourceView = newValue;
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= OnItemsSourceViewChanged;
		}
		if (newValue != null)
		{
			newValue.CollectionChanged += OnItemsSourceViewChanged;
		}
		Layout layout = Layout;
		if (layout == null)
		{
			return;
		}
		NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
		using (Disposable.Create(delegate
		{
			m_processingItemsSourceChange = null;
		}))
		{
			m_processingItemsSourceChange = notifyCollectionChangedEventArgs;
			if (layout is VirtualizingLayout virtualizingLayout)
			{
				virtualizingLayout.OnItemsChangedCore(GetLayoutContext(), newValue, notifyCollectionChangedEventArgs);
			}
			else if (layout is NonVirtualizingLayout)
			{
				foreach (UIElement child in Children)
				{
					if (GetVirtualizationInfo(child).IsRealized)
					{
						ClearElementImpl(child);
					}
				}
				Children.Clear();
			}
			InvalidateMeasure();
		}
	}

	private void OnItemTemplateChanged(object oldValue, object newValue)
	{
		if (m_isLayoutInProgress && oldValue != null)
		{
			throw new InvalidOperationException("ItemTemplate cannot be changed during layout.");
		}
		Layout layout = Layout;
		if (layout != null)
		{
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
			using (Disposable.Create(delegate
			{
				m_processingItemsSourceChange = null;
			}))
			{
				m_processingItemsSourceChange = notifyCollectionChangedEventArgs;
				if (layout is VirtualizingLayout virtualizingLayout)
				{
					virtualizingLayout.OnItemsChangedCore(GetLayoutContext(), newValue, notifyCollectionChangedEventArgs);
				}
				else if (layout is NonVirtualizingLayout)
				{
					foreach (UIElement child in Children)
					{
						if (GetVirtualizationInfo(child).IsRealized)
						{
							ClearElementImpl(child);
						}
					}
				}
			}
		}
		if (!SharedHelpers.IsRS5OrHigher())
		{
			m_itemTemplate = newValue as IElementFactory;
		}
		m_isItemTemplateEmpty = false;
		m_itemTemplateWrapper = newValue as IElementFactoryShim;
		if (m_itemTemplateWrapper == null)
		{
			if (newValue is DataTemplate dataTemplate)
			{
				m_itemTemplateWrapper = new ItemTemplateWrapper(dataTemplate);
				if (dataTemplate.LoadContent() is FrameworkElement item)
				{
					IList<UIElement> children = Children;
					children.Add(item);
					children.RemoveAt(children.Count - 1);
				}
				else
				{
					m_isItemTemplateEmpty = true;
				}
			}
			else
			{
				if (!(newValue is DataTemplateSelector dataTemplateSelector))
				{
					throw new ArgumentException("ItemTemplate", "ItemTemplate");
				}
				m_itemTemplateWrapper = new ItemTemplateWrapper(dataTemplateSelector);
			}
		}
		InvalidateMeasure();
	}

	private void OnLayoutChanged(Layout oldValue, Layout newValue)
	{
		if (m_isLayoutInProgress)
		{
			throw new InvalidOperationException("Layout cannot be changed during layout.");
		}
		m_viewManager.OnLayoutChanging();
		m_animationManager.OnLayoutChanging();
		if (oldValue != null)
		{
			oldValue.UninitializeForContext(GetLayoutContext());
			oldValue.MeasureInvalidated -= InvalidateMeasureForLayout;
			oldValue.ArrangeInvalidated -= InvalidateArrangeForLayout;
			_stackLayoutMeasureCounter = 0u;
			IList<UIElement> children = Children;
			for (int i = 0; i < children.Count; i++)
			{
				UIElement element = children[i];
				if (GetVirtualizationInfo(element).IsRealized)
				{
					ClearElementImpl(element);
				}
			}
			m_layoutState = null;
		}
		if (!SharedHelpers.IsRS5OrHigher())
		{
			m_layout = newValue;
		}
		if (newValue != null)
		{
			newValue.InitializeForContext(GetLayoutContext());
			newValue.MeasureInvalidated += InvalidateMeasureForLayout;
			newValue.ArrangeInvalidated += InvalidateArrangeForLayout;
		}
		bool isVirtualizing = newValue is VirtualizingLayout;
		m_viewportManager.OnLayoutChanged(isVirtualizing);
		InvalidateMeasure();
	}

	private void OnAnimatorChanged(ElementAnimator oldValue, ElementAnimator newValue)
	{
		m_animationManager.OnAnimatorChanged(newValue);
		if (!SharedHelpers.IsRS5OrHigher())
		{
			m_animator = newValue;
		}
	}

	private void OnItemsSourceViewChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		if (m_isLayoutInProgress)
		{
			throw new InvalidOperationException("Changes in data source are not allowed during layout.");
		}
		if (args.Action == NotifyCollectionChangedAction.Move)
		{
			OnItemsSourceViewChanged(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, args.OldItems, args.OldStartingIndex));
			OnItemsSourceViewChanged(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, args.NewItems, args.NewStartingIndex));
			return;
		}
		if (IsProcessingCollectionChange)
		{
			throw new InvalidOperationException("Changes in the data source are not allowed during another change in the data source.");
		}
		m_processingItemsSourceChange = args;
		using (Disposable.Create(delegate
		{
			m_processingItemsSourceChange = null;
		}))
		{
			m_animationManager.OnItemsSourceChanged(sender, args);
			m_viewManager.OnItemsSourceChanged(sender, args);
			Layout layout = Layout;
			if (layout != null)
			{
				if (layout is VirtualizingLayout virtualizingLayout)
				{
					virtualizingLayout.OnItemsChangedCore(GetLayoutContext(), sender, args);
				}
				else
				{
					InvalidateMeasure();
				}
			}
		}
	}

	private void InvalidateMeasureForLayout(Layout sender, object args)
	{
		InvalidateMeasure();
	}

	private void InvalidateArrangeForLayout(Layout sender, object args)
	{
		InvalidateArrange();
	}

	private VirtualizingLayoutContext GetLayoutContext()
	{
		if (m_layoutContext == null)
		{
			m_layoutContext = new RepeaterLayoutContext(this);
		}
		return m_layoutContext;
	}

	private IEnumerable<DependencyObject> CreateChildrenInTabFocusOrderIterable()
	{
		IList<UIElement> children = Children;
		if ((long)children.Count > 0L)
		{
			return new ChildrenInTabFocusOrderIterable(this);
		}
		return null;
	}

	internal void OnUnoBeforeElementPrepared(UIElement element, int index)
	{
		ItemsRepeaterElementPreparedEventArgs args = new ItemsRepeaterElementPreparedEventArgs(element, index);
		this.UnoBeforeElementPrepared?.Invoke(this, args);
	}

	private static void OnPropertyChanged(DependencyObject snd, DependencyPropertyChangedEventArgs args)
	{
		((ItemsRepeater)snd).OnPropertyChanged(args);
	}
}

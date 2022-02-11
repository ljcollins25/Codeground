using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DirectUI;
using Uno;
using Uno.Client;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Uno.Foundation.Logging;
using Uno.UI;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class ListViewBase : Selector, ISemanticZoomInformation
{
	private struct PanVelocity
	{
		public float HorizontalVelocity;

		public float VerticalVelocity;

		public static PanVelocity Stationary => default(PanVelocity);

		public bool IsStationary()
		{
			if (HorizontalVelocity == 0f)
			{
				return VerticalVelocity == 0f;
			}
			return false;
		}

		public void Clear()
		{
			HorizontalVelocity = (VerticalVelocity = 0f);
		}
	}

	private bool _modifyingSelectionInternally;

	private readonly List<object> _oldSelectedItems = new List<object>();

	private bool _isIncrementalLoadingInFlight;

	private readonly Dictionary<DependencyObject, object> _containersForIndexRepair = new Dictionary<DependencyObject, object>();

	private ICommand _itemClickCommand;

	private const string ReorderOwnerFormatId = "__uno__private__data____list__view__base__source__";

	private const string ReorderItemFormatId = "__uno__private__data____list__view__base__source__item__";

	private const string ReorderContainerFormatId = "__uno__private__data____list__view__base__source__container__";

	private const string DragItemsFormatId = "__uno__private__data____list__view__base__items__";

	private const int LISTVIEWBASE_EDGE_SCROLL_EDGE_WIDTH_PX = 100;

	private const int LISTVIEWBASE_EDGE_SCROLL_START_DELAY_MSEC = 50;

	private const double LISTVIEWBASE_EDGE_SCROLL_MIN_SPEED = 150.0;

	private const double LISTVIEWBASE_EDGE_SCROLL_MAX_SPEED = 1500.0;

	private const int LISTVIEW_LIVEREORDER_TIMER = 200;

	private const int GRIDVIEW_LIVEREORDER_TIMER = 300;

	private int m_dragItemsCount;

	private SelectorItem? m_tpPrimaryDraggedContainer;

	private SelectorItem m_tpDragOverItem;

	private PanVelocity m_pendingAutoPanVelocity;

	private PanVelocity m_currentAutoPanVelocity;

	private DispatcherTimer? m_tpStartEdgeScrollTimer;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSwipeEnabled
	{
		get
		{
			return (bool)GetValue(IsSwipeEnabledProperty);
		}
		set
		{
			SetValue(IsSwipeEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TransitionCollection HeaderTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(HeaderTransitionsProperty);
		}
		set
		{
			SetValue(HeaderTransitionsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool ShowsScrollingPlaceholders
	{
		get
		{
			return (bool)GetValue(ShowsScrollingPlaceholdersProperty);
		}
		set
		{
			SetValue(ShowsScrollingPlaceholdersProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TransitionCollection FooterTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(FooterTransitionsProperty);
		}
		set
		{
			SetValue(FooterTransitionsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ListViewReorderMode ReorderMode
	{
		get
		{
			return (ListViewReorderMode)GetValue(ReorderModeProperty);
		}
		set
		{
			SetValue(ReorderModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsMultiSelectCheckBoxEnabled
	{
		get
		{
			return (bool)GetValue(IsMultiSelectCheckBoxEnabledProperty);
		}
		set
		{
			SetValue(IsMultiSelectCheckBoxEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IReadOnlyList<ItemIndexRange> SelectedRanges
	{
		get
		{
			throw new NotImplementedException("The member IReadOnlyList<ItemIndexRange> ListViewBase.SelectedRanges is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool SingleSelectionFollowsFocus
	{
		get
		{
			return (bool)GetValue(SingleSelectionFollowsFocusProperty);
		}
		set
		{
			SetValue(SingleSelectionFollowsFocusProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SemanticZoom SemanticZoomOwner
	{
		get
		{
			return (SemanticZoom)GetValue(SemanticZoomOwnerProperty);
		}
		set
		{
			SetValue(SemanticZoomOwnerProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsZoomedInView
	{
		get
		{
			return (bool)GetValue(IsZoomedInViewProperty);
		}
		set
		{
			SetValue(IsZoomedInViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsActiveView
	{
		get
		{
			return (bool)GetValue(IsActiveViewProperty);
		}
		set
		{
			SetValue(IsActiveViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderTransitionsProperty { get; } = DependencyProperty.Register("HeaderTransitions", typeof(TransitionCollection), typeof(ListViewBase), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsActiveViewProperty { get; } = DependencyProperty.Register("IsActiveView", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsSwipeEnabledProperty { get; } = DependencyProperty.Register("IsSwipeEnabled", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsZoomedInViewProperty { get; } = DependencyProperty.Register("IsZoomedInView", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SemanticZoomOwnerProperty { get; } = DependencyProperty.Register("SemanticZoomOwner", typeof(SemanticZoom), typeof(ListViewBase), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FooterTransitionsProperty { get; } = DependencyProperty.Register("FooterTransitions", typeof(TransitionCollection), typeof(ListViewBase), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ShowsScrollingPlaceholdersProperty { get; } = DependencyProperty.Register("ShowsScrollingPlaceholders", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ReorderModeProperty { get; } = DependencyProperty.Register("ReorderMode", typeof(ListViewReorderMode), typeof(ListViewBase), new FrameworkPropertyMetadata(ListViewReorderMode.Disabled));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsMultiSelectCheckBoxEnabledProperty { get; } = DependencyProperty.Register("IsMultiSelectCheckBoxEnabled", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SingleSelectionFollowsFocusProperty { get; } = DependencyProperty.Register("SingleSelectionFollowsFocus", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false));


	public bool RefreshOnCollectionChanged { get; set; }

	internal override bool IsSingleSelection => SelectionMode == ListViewSelectionMode.Single;

	private bool IsSelectionMultiple
	{
		get
		{
			if (SelectionMode != ListViewSelectionMode.Multiple)
			{
				return SelectionMode == ListViewSelectionMode.Extended;
			}
			return true;
		}
	}

	public ICommand ItemClickCommand
	{
		get
		{
			return _itemClickCommand;
		}
		set
		{
			_itemClickCommand = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ICommand Command
	{
		get
		{
			return ItemClickCommand;
		}
		set
		{
			ItemClickCommand = value;
		}
	}

	public IList<object> SelectedItems { get; }

	internal bool ShouldShowHeader
	{
		get
		{
			if (Header == null)
			{
				return HeaderTemplate != null;
			}
			return true;
		}
	}

	internal bool ShouldShowFooter
	{
		get
		{
			if (Footer == null)
			{
				return FooterTemplate != null;
			}
			return true;
		}
	}

	private bool CanLoadItems
	{
		get
		{
			if (!_isIncrementalLoadingInFlight && IncrementalLoadingTrigger == IncrementalLoadingTrigger.Edge)
			{
				return SourceHasMoreItems;
			}
			return false;
		}
	}

	private bool SourceHasMoreItems
	{
		get
		{
			if (!(GetItems() is ISupportIncrementalLoading supportIncrementalLoading) || !supportIncrementalLoading.HasMoreItems)
			{
				if (GetItems() is ICollectionView collectionView)
				{
					return collectionView.HasMoreItems;
				}
				return false;
			}
			return true;
		}
	}

	public static DependencyProperty CanReorderItemsProperty { get; } = DependencyProperty.Register("CanReorderItems", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false));


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

	public static DependencyProperty CanDragItemsProperty { get; } = DependencyProperty.Register("CanDragItems", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false, OnCanDragItemsChanged));


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

	private int PageSize
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(ListViewBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnHeaderChanged(e.OldValue, e.NewValue);
	}));


	public DataTemplate HeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(HeaderTemplateProperty);
		}
		set
		{
			SetValue(HeaderTemplateProperty, value);
		}
	}

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(ListViewBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnHeaderTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue);
	}));


	public object Footer
	{
		get
		{
			return GetValue(FooterProperty);
		}
		set
		{
			SetValue(FooterProperty, value);
		}
	}

	public static DependencyProperty FooterProperty { get; } = DependencyProperty.Register("Footer", typeof(object), typeof(ListViewBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnFooterChanged(e.OldValue, e.NewValue);
	}));


	public DataTemplate FooterTemplate
	{
		get
		{
			return (DataTemplate)GetValue(FooterTemplateProperty);
		}
		set
		{
			SetValue(FooterTemplateProperty, value);
		}
	}

	public static DependencyProperty FooterTemplateProperty { get; } = DependencyProperty.Register("FooterTemplate", typeof(DataTemplate), typeof(ListViewBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnFooterTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue);
	}));


	public ListViewSelectionMode SelectionMode
	{
		get
		{
			return (ListViewSelectionMode)GetValue(SelectionModeProperty);
		}
		set
		{
			SetValue(SelectionModeProperty, value);
		}
	}

	public static DependencyProperty SelectionModeProperty { get; } = DependencyProperty.Register("SelectionMode", typeof(ListViewSelectionMode), typeof(ListViewBase), new FrameworkPropertyMetadata(ListViewSelectionMode.Single, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnSelectionModeChanged((ListViewSelectionMode)e.OldValue, (ListViewSelectionMode)e.NewValue);
	}));


	public bool IsItemClickEnabled
	{
		get
		{
			return (bool)GetValue(IsItemClickEnabledProperty);
		}
		set
		{
			SetValue(IsItemClickEnabledProperty, value);
		}
	}

	public static DependencyProperty IsItemClickEnabledProperty { get; } = DependencyProperty.Register("IsItemClickEnabled", typeof(bool), typeof(ListViewBase), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnIsItemClickEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public double DataFetchSize
	{
		get
		{
			return (double)GetValue(DataFetchSizeProperty);
		}
		set
		{
			SetValue(DataFetchSizeProperty, value);
		}
	}

	public static DependencyProperty DataFetchSizeProperty { get; } = DependencyProperty.Register("DataFetchSize", typeof(double), typeof(ListViewBase), new FrameworkPropertyMetadata(3.0, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnDataFetchSizeChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double IncrementalLoadingThreshold
	{
		get
		{
			return (double)GetValue(IncrementalLoadingThresholdProperty);
		}
		set
		{
			SetValue(IncrementalLoadingThresholdProperty, value);
		}
	}

	public static DependencyProperty IncrementalLoadingThresholdProperty { get; } = DependencyProperty.Register("IncrementalLoadingThreshold", typeof(double), typeof(ListViewBase), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnIncrementalLoadingThresholdChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public IncrementalLoadingTrigger IncrementalLoadingTrigger
	{
		get
		{
			return (IncrementalLoadingTrigger)GetValue(IncrementalLoadingTriggerProperty);
		}
		set
		{
			SetValue(IncrementalLoadingTriggerProperty, value);
		}
	}

	public static DependencyProperty IncrementalLoadingTriggerProperty { get; } = DependencyProperty.Register("IncrementalLoadingTrigger", typeof(IncrementalLoadingTrigger), typeof(ListViewBase), new FrameworkPropertyMetadata(IncrementalLoadingTrigger.Edge, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ListViewBase)s)?.OnIncrementalLoadingTriggerChanged((IncrementalLoadingTrigger)e.OldValue, (IncrementalLoadingTrigger)e.NewValue);
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ListViewBase, ChoosingGroupHeaderContainerEventArgs> ChoosingGroupHeaderContainer
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "event TypedEventHandler<ListViewBase, ChoosingGroupHeaderContainerEventArgs> ListViewBase.ChoosingGroupHeaderContainer");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "event TypedEventHandler<ListViewBase, ChoosingGroupHeaderContainerEventArgs> ListViewBase.ChoosingGroupHeaderContainer");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ListViewBase, ChoosingItemContainerEventArgs> ChoosingItemContainer
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "event TypedEventHandler<ListViewBase, ChoosingItemContainerEventArgs> ListViewBase.ChoosingItemContainer");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "event TypedEventHandler<ListViewBase, ChoosingItemContainerEventArgs> ListViewBase.ChoosingItemContainer");
		}
	}

	public event TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> ContainerContentChanging;

	public event ItemClickEventHandler ItemClick;

	public event DragItemsStartingEventHandler DragItemsStarting;

	public event TypedEventHandler<ListViewBase, DragItemsCompletedEventArgs> DragItemsCompleted;

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView(object item)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.ScrollIntoView(object item)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SelectAll()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.SelectAll()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync()
	{
		throw new NotImplementedException("The member IAsyncOperation<LoadMoreItemsResult> ListViewBase.LoadMoreItemsAsync() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView(object item, ScrollIntoViewAlignment alignment)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.ScrollIntoView(object item, ScrollIntoViewAlignment alignment)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetDesiredContainerUpdateDuration(TimeSpan duration)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.SetDesiredContainerUpdateDuration(TimeSpan duration)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SelectRange(ItemIndexRange itemIndexRange)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.SelectRange(ItemIndexRange itemIndexRange)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void DeselectRange(ItemIndexRange itemIndexRange)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.DeselectRange(ItemIndexRange itemIndexRange)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsDragSource()
	{
		throw new NotImplementedException("The member bool ListViewBase.IsDragSource() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<bool> TryStartConnectedAnimationAsync(ConnectedAnimation animation, object item, string elementName)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> ListViewBase.TryStartConnectedAnimationAsync(ConnectedAnimation animation, object item, string elementName) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ConnectedAnimation PrepareConnectedAnimation(string key, object item, string elementName)
	{
		throw new NotImplementedException("The member ConnectedAnimation ListViewBase.PrepareConnectedAnimation(string key, object item, string elementName) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void InitializeViewChange()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.InitializeViewChange()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CompleteViewChange()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.CompleteViewChange()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MakeVisible(SemanticZoomLocation item)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.MakeVisible(SemanticZoomLocation item)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListViewBase", "void ListViewBase.CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}

	protected internal ListViewBase()
	{
		Initialize();
		ObservableCollection<object> observableCollection = new ObservableCollection<object>();
		observableCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(OnSelectedItemsCollectionChanged);
		SelectedItems = observableCollection;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		if (!base.HasItems)
		{
			TryLoadFirstItem();
		}
		return base.ArrangeOverride(finalSize);
	}

	private void OnSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (_modifyingSelectionInternally)
		{
			_oldSelectedItems.Clear();
			_oldSelectedItems.AddRange(SelectedItems);
			return;
		}
		IEnumerable items = GetItems();
		if (items == null && _oldSelectedItems.Any())
		{
			ResetSelection();
			return;
		}
		object[] array;
		object[] array2;
		if (e.Action != NotifyCollectionChangedAction.Reset)
		{
			array = (e.NewItems ?? new object[0]).Where((object item) => items.Contains(item)).ToObjectArray();
			array2 = (e.OldItems ?? new object[0]).Where((object item) => items.Contains(item)).ToObjectArray();
		}
		else
		{
			array = new object[0];
			array2 = _oldSelectedItems.Where((object item) => items.Contains(item)).ToObjectArray();
		}
		try
		{
			_modifyingSelectionInternally = true;
			int? num = ((IEnumerable<object>)SelectedItems).Select((Func<object, int?>)((object item) => items.IndexOf(item))).FirstOrDefault((int? index) => index > -1);
			if (num.HasValue)
			{
				base.SelectedItem = items.ElementAt(num.Value);
				base.SelectedIndex = num.Value;
			}
			else
			{
				base.SelectedItem = null;
				base.SelectedIndex = -1;
			}
			TryUpdateSelectorItemIsSelected(array2, isSelected: false);
			TryUpdateSelectorItemIsSelected(array, isSelected: true);
		}
		finally
		{
			_modifyingSelectionInternally = false;
		}
		if (array.Any() || array2.Any())
		{
			InvokeSelectionChanged(array2, array);
		}
		_oldSelectedItems.Clear();
		_oldSelectedItems.AddRange(SelectedItems);
	}

	private void TryUpdateSelectorItemIsSelected(object[] items, bool isSelected)
	{
		foreach (object item in items)
		{
			TryUpdateSelectorItemIsSelected(item, isSelected);
		}
	}

	private void ResetSelection()
	{
		try
		{
			_modifyingSelectionInternally = true;
			_oldSelectedItems.Clear();
			_oldSelectedItems.AddRange(SelectedItems);
			SelectedItems.Clear();
		}
		finally
		{
			_modifyingSelectionInternally = false;
		}
	}

	internal override void ChangeSelectedItem(object item, bool oldIsSelected, bool newIsSelected)
	{
		if (_modifyingSelectionInternally)
		{
			return;
		}
		switch (SelectionMode)
		{
		case ListViewSelectionMode.Single:
		{
			int num = IndexFromItem(item);
			if (!newIsSelected)
			{
				if (base.SelectedIndex == num)
				{
					base.SelectedIndex = -1;
				}
			}
			else
			{
				base.SelectedIndex = num;
			}
			break;
		}
		case ListViewSelectionMode.Multiple:
		case ListViewSelectionMode.Extended:
			if (!newIsSelected)
			{
				SelectedItems.Remove(item);
			}
			else if (!SelectedItems.Contains(item))
			{
				SelectedItems.Add(item);
			}
			break;
		case ListViewSelectionMode.None:
			break;
		}
	}

	internal override void OnSelectedItemChanged(object oldSelectedItem, object selectedItem, bool updateItemSelectedState)
	{
		if (_modifyingSelectionInternally)
		{
			return;
		}
		if (IsSelectionMultiple)
		{
			IEnumerable items = GetItems();
			if (selectedItem == null || items.Contains(selectedItem))
			{
				object[] array = null;
				object[] array2 = null;
				try
				{
					_modifyingSelectionInternally = true;
					array = SelectedItems.Except(selectedItem).ToObjectArray();
					bool flag = selectedItem != null || items.Contains(null);
					array2 = ((SelectedItems.Contains(selectedItem) || !flag) ? new object[0] : new object[1] { selectedItem });
					SelectedItems.Clear();
					if (flag)
					{
						SelectedItems.Add(selectedItem);
					}
				}
				finally
				{
					_modifyingSelectionInternally = false;
				}
				if (array2.Length != 0 || array.Length != 0)
				{
					InvokeSelectionChanged(array, array2);
				}
			}
			else
			{
				base.SelectedItem = oldSelectedItem;
			}
			return;
		}
		try
		{
			_modifyingSelectionInternally = true;
			if (selectedItem != null)
			{
				SelectedItems.Update(new object[1] { selectedItem });
			}
			else
			{
				SelectedItems.Clear();
			}
		}
		finally
		{
			_modifyingSelectionInternally = false;
		}
		base.OnSelectedItemChanged(oldSelectedItem, selectedItem, updateItemSelectedState: true);
	}

	private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (!IsSelectionMultiple)
		{
			return;
		}
		foreach (object addedItem in e.AddedItems)
		{
			SetSelectedState(IndexFromItem(addedItem), selected: true);
		}
		foreach (object removedItem in e.RemovedItems)
		{
			SetSelectedState(IndexFromItem(removedItem), selected: false);
		}
	}

	internal override void OnSelectedIndexChanged(int oldSelectedIndex, int newSelectedIndex)
	{
		base.OnSelectedIndexChanged(oldSelectedIndex, newSelectedIndex);
	}

	private void Initialize()
	{
		base.SelectionChanged += OnSelectionChanged;
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
	}

	internal override void OnItemClicked(int clickedIndex)
	{
		object obj = ItemFromIndex(clickedIndex);
		if (IsItemClickEnabled)
		{
			IsItemItsOwnContainerOverride(obj);
			ItemClickCommand.ExecuteIfPossible(obj);
			this.ItemClick?.Invoke(this, new ItemClickEventArgs
			{
				ClickedItem = obj
			});
		}
		switch (SelectionMode)
		{
		case ListViewSelectionMode.Single:
			if (base.ItemsSource is ICollectionView collectionView)
			{
				collectionView.MoveCurrentToPosition(clickedIndex);
				clickedIndex = collectionView.CurrentPosition;
			}
			base.SelectedIndex = clickedIndex;
			break;
		case ListViewSelectionMode.Multiple:
		case ListViewSelectionMode.Extended:
			HandleMultipleSelection(clickedIndex, obj);
			break;
		case ListViewSelectionMode.None:
			break;
		}
	}

	private void HandleMultipleSelection(int clickedIndex, object item)
	{
		if (!SelectedItems.Contains(item))
		{
			SelectedItems.Add(item);
			SetSelectedState(clickedIndex, selected: true);
		}
		else
		{
			SelectedItems.Remove(item);
			SetSelectedState(clickedIndex, selected: false);
		}
	}

	private void SetSelectedState(int clickedIndex, bool selected)
	{
		if (ContainerFromIndex(clickedIndex) is SelectorItem selectorItem)
		{
			selectorItem.IsSelected = selected;
		}
	}

	protected internal override void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnDataContextChanged(e);
		base.ItemsPanelRoot?.SetValue(UIElement.DataContextProperty, base.DataContext, DependencyPropertyValuePrecedences.Inheritance);
	}

	internal object ResolveFooterContext()
	{
		return ResolveHeaderOrFooterContext(FooterProperty, FooterTemplateProperty);
	}

	internal override void OnItemsSourceSingleCollectionChanged(object sender, NotifyCollectionChangedEventArgs args, int section)
	{
		if (RefreshOnCollectionChanged)
		{
			completeRefresh();
			return;
		}
		switch (args.Action)
		{
		case NotifyCollectionChangedAction.Add:
			if (base.AreEmptyGroupsHidden && (sender as IEnumerable).Count() == args.NewItems!.Count)
			{
				completeRefresh();
				return;
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Inserting {args.NewItems!.Count} items starting at {args.NewStartingIndex}");
			}
			SaveContainersForIndexRepair(args.NewStartingIndex, args.NewItems!.Count);
			AddItems(args.NewStartingIndex, args.NewItems!.Count, section);
			RepairIndices();
			break;
		case NotifyCollectionChangedAction.Remove:
			if (base.AreEmptyGroupsHidden && (sender as IEnumerable).None())
			{
				completeRefresh();
				return;
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Deleting {args.OldItems!.Count} items starting at {args.OldStartingIndex}");
			}
			SaveContainersForIndexRepair(args.OldStartingIndex, -args.OldItems!.Count);
			RemoveItems(args.OldStartingIndex, args.OldItems!.Count, section);
			RepairIndices();
			break;
		case NotifyCollectionChangedAction.Replace:
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Replacing {args.NewItems!.Count} items starting at {args.NewStartingIndex}");
			}
			ReplaceItems(args.NewStartingIndex, args.NewItems!.Count, section);
			break;
		case NotifyCollectionChangedAction.Move:
			Refresh();
			break;
		case NotifyCollectionChangedAction.Reset:
			Refresh();
			break;
		}
		base.OnItemsSourceSingleCollectionChanged(sender, args, section);
		void completeRefresh()
		{
			Refresh();
			ObserveCollectionChanged();
			base.OnItemsSourceSingleCollectionChanged(sender, args, section);
		}
	}

	private void SaveContainersForIndexRepair(int startingIndex, int indexChange)
	{
		_containersForIndexRepair.Clear();
		foreach (DependencyObject materializedContainer in base.MaterializedContainers)
		{
			int num = (int)materializedContainer.GetValue(ItemsControl.IndexForItemContainerProperty);
			if (num >= startingIndex)
			{
				_containersForIndexRepair.Add(materializedContainer, num + indexChange);
			}
		}
	}

	private void RepairIndices()
	{
		foreach (KeyValuePair<DependencyObject, object> item in _containersForIndexRepair)
		{
			item.Key.SetValue(ItemsControl.IndexForItemContainerProperty, item.Value);
		}
		_containersForIndexRepair.Clear();
	}

	internal override void OnItemsSourceGroupsChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		if (RefreshOnCollectionChanged)
		{
			Refresh();
			ObserveCollectionChanged();
			base.OnItemsSourceGroupsChanged(sender, args);
			return;
		}
		switch (args.Action)
		{
		case NotifyCollectionChangedAction.Add:
		{
			for (int k = args.NewStartingIndex; k < args.NewStartingIndex + args.NewItems!.Count; k++)
			{
			}
			for (int l = args.NewStartingIndex; l < args.NewStartingIndex + args.NewItems!.Count; l++)
			{
				if (!base.AreEmptyGroupsHidden || GetGroupCount(l) > 0)
				{
					int groupIndexInView2 = AdjustGroupIndexForHidesIfEmpty(l);
					AddGroup(groupIndexInView2);
				}
			}
			break;
		}
		case NotifyCollectionChangedAction.Remove:
		{
			for (int num2 = args.OldItems!.Count - 1; num2 >= 0; num2--)
			{
			}
			for (int num3 = args.OldItems!.Count - 1; num3 >= 0; num3--)
			{
				if (!base.AreEmptyGroupsHidden || GetCachedGroupCount(args.OldStartingIndex + num3) > 0)
				{
					int groupIndexInView3 = AdjustGroupIndexForHidesIfEmpty(args.OldStartingIndex + num3);
					RemoveGroup(groupIndexInView3);
				}
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		{
			for (int num = args.OldItems!.Count - 1; num >= 0; num--)
			{
			}
			for (int i = args.NewStartingIndex; i < args.NewStartingIndex + args.NewItems!.Count; i++)
			{
			}
			for (int j = args.NewStartingIndex; j < args.NewStartingIndex + args.NewItems!.Count; j++)
			{
				int groupIndexInView = AdjustGroupIndexForHidesIfEmpty(j);
				ReplaceGroup(groupIndexInView);
			}
			break;
		}
		default:
			Refresh();
			break;
		}
		ObserveCollectionChanged();
		base.OnItemsSourceGroupsChanged(sender, args);
	}

	internal override void OnGroupPropertyChanged(ICollectionViewGroup group, int groupIndex)
	{
		base.OnGroupPropertyChanged(group, groupIndex);
		ContentControl contentControl = ContainerFromGroupIndex(groupIndex);
		if (contentControl != null)
		{
			contentControl.DataContext = group.Group;
		}
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		_containersForIndexRepair.Remove(element);
		base.PrepareContainerForItemOverride(element, item);
		if (element is SelectorItem selectorItem)
		{
			ApplyMultiSelectState(selectorItem);
		}
	}

	internal override void ContainerPreparedForItem(object item, SelectorItem itemContainer, int itemIndex)
	{
		base.ContainerPreparedForItem(item, itemContainer, itemIndex);
		PrepareContainerForDragDrop(itemContainer);
		this.ContainerContentChanging?.Invoke(this, new ContainerContentChangingEventArgs(item, itemContainer, itemIndex));
	}

	internal override void ContainerClearedForItem(object item, SelectorItem itemContainer)
	{
		ClearContainerForDragDrop(itemContainer);
		base.ContainerClearedForItem(item, itemContainer);
	}

	internal void ApplyMultiSelectState(SelectorItem selectorItem)
	{
		selectorItem.ApplyMultiSelectState(IsSelectionMultiple);
	}

	private void ReplaceItems(int firstItem, int count, int section)
	{
		for (int i = 0; i < count; i++)
		{
			IndexPath indexPath = IndexPath.FromRowSection(firstItem + i, section);
			int indexFromIndexPath = GetIndexFromIndexPath(indexPath);
			DependencyObject dependencyObject = ContainerFromIndex(indexFromIndexPath);
			if (dependencyObject != null)
			{
				object displayItemFromIndexPath = GetDisplayItemFromIndexPath(indexPath);
				PrepareContainerForIndex(dependencyObject, indexFromIndexPath);
			}
		}
	}

	internal object ResolveHeaderContext()
	{
		return ResolveHeaderOrFooterContext(HeaderProperty, HeaderTemplateProperty);
	}

	private object ResolveHeaderOrFooterContext(DependencyProperty contextProperty, DependencyProperty templateProperty)
	{
		if (this.IsDependencyPropertySet(contextProperty))
		{
			return GetValue(contextProperty);
		}
		if (GetValue(templateProperty) != null)
		{
			return base.DataContext;
		}
		return null;
	}

	internal override bool IsSelected(int index)
	{
		switch (SelectionMode)
		{
		case ListViewSelectionMode.None:
			return false;
		case ListViewSelectionMode.Single:
			return index == base.SelectedIndex;
		case ListViewSelectionMode.Multiple:
		case ListViewSelectionMode.Extended:
			return SelectedItems.Any((object item) => IndexFromItem(item).Equals(index));
		default:
			return false;
		}
	}

	internal void TryLoadMoreItems(int currentLastItem)
	{
		if (CanLoadItems)
		{
			double num = (IncrementalLoadingThreshold + 1.0) * (double)PageSize;
			int num2 = base.NumberOfItems - 1 - currentLastItem;
			if ((double)num2 <= num)
			{
				int num3 = Math.Max(1, PageSize);
				TryLoadMoreItemsInner((int)(DataFetchSize * (double)num3));
			}
		}
	}

	private void TryLoadFirstItem()
	{
		if (CanLoadItems)
		{
			TryLoadMoreItemsInner(1);
		}
	}

	private void TryLoadMoreItemsInner(int count)
	{
		_isIncrementalLoadingInFlight = true;
		LoadMoreItemsAsync(GetItems(), (uint)count);
	}

	private async Task LoadMoreItemsAsync(object incrementalSource, uint count)
	{
		LoadMoreItemsResult result = default(LoadMoreItemsResult);
		try
		{
			if (incrementalSource is ISupportIncrementalLoading supportIncrementalLoading)
			{
				result = await supportIncrementalLoading.LoadMoreItemsAsync(count);
			}
			else
			{
				if (!(incrementalSource is ICollectionView collectionView))
				{
					throw new InvalidOperationException();
				}
				result = await collectionView.LoadMoreItemsAsync(count);
			}
		}
		catch (Exception ex)
		{
			if (this.Log().IsEnabled(LogLevel.Warning))
			{
				this.Log().Warn("LoadMoreItemsAsync failed.", ex);
			}
		}
		finally
		{
			_isIncrementalLoadingInFlight = false;
		}
		if (result.Count != 0)
		{
			TryLoadMoreItems();
		}
	}

	private static void OnCanDragItemsChanged(DependencyObject snd, DependencyPropertyChangedEventArgs args)
	{
		if (!(snd is ListViewBase listViewBase))
		{
			return;
		}
		object newValue = args.NewValue;
		if (newValue is bool)
		{
			bool flag = (bool)newValue;
			IEnumerable<UIElement> items = listViewBase.MaterializedContainers.OfType<UIElement>();
			if (flag)
			{
				items.ForEach(PrepareContainerForDragDropCore);
			}
			else
			{
				items.ForEach(ClearContainerForDragDrop);
			}
		}
	}

	private void PrepareContainerForDragDrop(UIElement itemContainer)
	{
		if (CanDragItems)
		{
			PrepareContainerForDragDropCore(itemContainer);
		}
	}

	private static void PrepareContainerForDragDropCore(UIElement itemContainer)
	{
		if (itemContainer != null)
		{
			itemContainer.DragStarting -= OnItemContainerDragStarting;
			itemContainer.DropCompleted -= OnItemContainerDragCompleted;
			itemContainer.CanDrag = true;
			itemContainer.DragStarting += OnItemContainerDragStarting;
			itemContainer.DropCompleted += OnItemContainerDragCompleted;
		}
	}

	private static void ClearContainerForDragDrop(UIElement itemContainer)
	{
		if (itemContainer != null)
		{
			itemContainer.DragStarting -= OnItemContainerDragStarting;
			itemContainer.DropCompleted -= OnItemContainerDragCompleted;
			itemContainer.DragEnter -= OnReorderDragUpdated;
			itemContainer.DragOver -= OnReorderDragUpdated;
			itemContainer.DragLeave -= OnReorderDragLeave;
			itemContainer.Drop -= OnReorderCompleted;
		}
	}

	private static void OnItemContainerDragStarting(UIElement sender, DragStartingEventArgs innerArgs)
	{
		if (ItemsControl.ItemsControlFromItemContainer(sender) is ListViewBase listViewBase && listViewBase.CanDragItems)
		{
			List<object> list = ((listViewBase.SelectionMode == ListViewSelectionMode.Multiple || listViewBase.SelectionMode == ListViewSelectionMode.Extended) ? listViewBase.SelectedItems.ToList() : new List<object>());
			object obj = listViewBase.ItemFromContainer(sender);
			if (obj != null && !list.Contains(obj))
			{
				list.Add(obj);
			}
			DragItemsStartingEventArgs dragItemsStartingEventArgs = new DragItemsStartingEventArgs(innerArgs, list);
			listViewBase.DragItemsStarting?.Invoke(listViewBase, dragItemsStartingEventArgs);
			dragItemsStartingEventArgs.Data.SetData("__uno__private__data____list__view__base__items__", dragItemsStartingEventArgs.Items.ToList());
			if (listViewBase.CanReorderItems && listViewBase.AllowDrop && obj != null)
			{
				dragItemsStartingEventArgs.Data.SetData("__uno__private__data____list__view__base__source__", listViewBase);
				dragItemsStartingEventArgs.Data.SetData("__uno__private__data____list__view__base__source__item__", obj);
				dragItemsStartingEventArgs.Data.SetData("__uno__private__data____list__view__base__source__container__", sender);
				listViewBase.DragEnter -= OnReorderDragUpdated;
				listViewBase.DragOver -= OnReorderDragUpdated;
				listViewBase.DragLeave -= OnReorderDragLeave;
				listViewBase.Drop -= OnReorderCompleted;
				listViewBase.DragEnter += OnReorderDragUpdated;
				listViewBase.DragOver += OnReorderDragUpdated;
				listViewBase.DragLeave += OnReorderDragLeave;
				listViewBase.Drop += OnReorderCompleted;
				listViewBase.m_tpPrimaryDraggedContainer = sender as SelectorItem;
				listViewBase.ChangeSelectorItemsVisualState(useTransitions: true);
			}
		}
	}

	private static void OnItemContainerDragCompleted(UIElement sender, DropCompletedEventArgs innerArgs)
	{
		if (ItemsControl.ItemsControlFromItemContainer(sender) is ListViewBase listViewBase)
		{
			listViewBase.DragEnter -= OnReorderDragUpdated;
			listViewBase.DragOver -= OnReorderDragUpdated;
			listViewBase.DragLeave -= OnReorderDragLeave;
			listViewBase.Drop -= OnReorderCompleted;
			if (listViewBase.CanDragItems)
			{
				IReadOnlyList<object> items = (innerArgs.Info.Data.FindRawData("__uno__private__data____list__view__base__items__") as IReadOnlyList<object>) ?? new List<object>(0);
				DragItemsCompletedEventArgs args = new DragItemsCompletedEventArgs(innerArgs, items);
				listViewBase.DragItemsCompleted?.Invoke(listViewBase, args);
			}
			listViewBase.CleanupReordering();
		}
	}

	private static void OnReorderDragUpdated(object sender, DragEventArgs dragEventArgs)
	{
		OnReorderUpdated(sender, dragEventArgs, setVelocity: true);
	}

	private static void OnReorderDragLeave(object sender, DragEventArgs dragEventArgs)
	{
		OnReorderUpdated(sender, dragEventArgs, setVelocity: false);
	}

	private static void OnReorderUpdated(object sender, DragEventArgs dragEventArgs, bool setVelocity)
	{
		ListView listView = sender as ListView;
		ListView listView2 = dragEventArgs.DataView.FindRawData("__uno__private__data____list__view__base__source__") as ListView;
		object obj = dragEventArgs.DataView.FindRawData("__uno__private__data____list__view__base__source__item__");
		FrameworkElement frameworkElement = dragEventArgs.DataView.FindRawData("__uno__private__data____list__view__base__source__container__") as FrameworkElement;
		if (listView == null || listView2 == null || obj == null || frameworkElement == null || listView2 != listView)
		{
			dragEventArgs.Log().Warn("Invalid reorder event.");
			dragEventArgs.AcceptedOperation = DataPackageOperation.None;
			return;
		}
		dragEventArgs.AcceptedOperation = DataPackageOperation.Move;
		Point position = dragEventArgs.GetPosition(listView);
		listView.UpdateReordering(position, frameworkElement, obj);
		if (setVelocity)
		{
			PanVelocity pendingAutoPanVelocity = listView.ComputeEdgeScrollVelocity(position);
			listView.SetPendingAutoPanVelocity(pendingAutoPanVelocity);
		}
		else
		{
			listView.SetPendingAutoPanVelocity(PanVelocity.Stationary);
		}
	}

	private static void OnReorderCompleted(object sender, DragEventArgs dragEventArgs)
	{
		ListView that = sender as ListView;
		that?.SetPendingAutoPanVelocity(PanVelocity.Stationary);
		ListView listView = dragEventArgs.DataView.FindRawData("__uno__private__data____list__view__base__source__") as ListView;
		object item = dragEventArgs.DataView.FindRawData("__uno__private__data____list__view__base__source__item__");
		FrameworkElement container = dragEventArgs.DataView.FindRawData("__uno__private__data____list__view__base__source__container__") as FrameworkElement;
		if (that == null || listView == null || item == null || container == null || listView != that)
		{
			dragEventArgs.Log().Warn("Invalid reorder event.");
			return;
		}
		IndexPath? updatedIndex = that.CompleteReordering(container, item);
		that.m_tpPrimaryDraggedContainer = null;
		that.ChangeSelectorItemsVisualState(useTransitions: true);
		if (that.IsGrouping || !updatedIndex.HasValue)
		{
			return;
		}
		object obj = dragEventArgs.DataView.FindRawData("__uno__private__data____list__view__base__items__");
		List<object> movedItems = obj as List<object>;
		if (movedItems == null)
		{
			return;
		}
		object obj2 = that.UnwrapItemsSource();
		object obj3 = obj2;
		if (obj3 != null)
		{
			IObservableVector observableVector = obj3 as IObservableVector;
			if (observableVector == null)
			{
				IList list = obj3 as IList;
				if (list != null && IsObservableCollection(list))
				{
					ProcessMove(list.Count, new Func<object, int>(list.IndexOf), delegate(int oldIndex, int newIndex)
					{
						DoMove(list, oldIndex, newIndex);
					});
				}
			}
			else
			{
				ProcessMove(observableVector.Count, new Func<object, int>(observableVector.IndexOf), delegate(int oldIndex, int newIndex)
				{
					DoMove(observableVector, oldIndex, newIndex);
				});
			}
		}
		else
		{
			ItemCollection items = that.Items;
			ProcessMove(items.Count, new Func<object, int>(items.IndexOf), delegate(int oldIndex, int newIndex)
			{
				DoMove(items, oldIndex, newIndex);
			});
		}
		void ProcessMove(int count, Func<object, int> indexOf, Action<int, int> mv)
		{
			int num = indexOf(item);
			if (num >= 0)
			{
				int num2;
				if (updatedIndex.Value.Row == int.MaxValue)
				{
					num2 = count - 1;
				}
				else
				{
					num2 = that.GetIndexFromIndexPath(updatedIndex.Value);
					if (num < num2)
					{
						num2--;
					}
				}
				for (int i = 0; i < movedItems.Count; i++)
				{
					object arg = movedItems[i];
					int num3 = indexOf(arg);
					if (num3 >= 0 && num3 != num2)
					{
						bool flag = that.SelectedIndex == num3;
						mv(num3, num2);
						if (flag)
						{
							container.SetValue(ItemsControl.IndexForItemContainerProperty, num2);
							that.SelectedIndex = num2;
						}
						if (num3 > num2)
						{
							num2++;
						}
					}
				}
			}
		}
	}

	private void UpdateReordering(Point location, FrameworkElement draggedContainer, object draggedItem)
	{
		base.VirtualizingPanel?.GetLayouter().UpdateReorderingItem(location, draggedContainer, draggedItem);
	}

	private IndexPath? CompleteReordering(FrameworkElement draggedContainer, object draggedItem)
	{
		return base.VirtualizingPanel?.GetLayouter().CompleteReorderingItem(draggedContainer, draggedItem);
	}

	private void CleanupReordering()
	{
	}

	private static bool IsObservableCollection(object src)
	{
		Type type = src.GetType();
		if (type.IsGenericType)
		{
			return type.GetGenericTypeDefinition() == typeof(ObservableCollection<>);
		}
		return false;
	}

	private static void DoMove(ItemCollection items, int oldIndex, int newIndex)
	{
		object item = items[oldIndex];
		items.RemoveAt(oldIndex);
		if (newIndex >= items.Count)
		{
			items.Add(item);
		}
		else
		{
			items.Insert(newIndex, item);
		}
	}

	private static void DoMove(IObservableVector vector, int oldIndex, int newIndex)
	{
		object item = vector[oldIndex];
		vector.RemoveAt(oldIndex);
		if (newIndex >= vector.Count)
		{
			vector.Add(item);
		}
		else
		{
			vector.Insert(newIndex, item);
		}
	}

	private static void DoMove(IList list, int oldIndex, int newIndex)
	{
		object value = list[oldIndex];
		list.RemoveAt(oldIndex);
		if (newIndex >= list.Count)
		{
			list.Add(value);
		}
		else
		{
			list.Insert(newIndex, value);
		}
	}

	internal bool IsContainerDragDropOwner(UIElement pContainer)
	{
		bool result = false;
		if (m_tpPrimaryDraggedContainer != null && object.Equals(pContainer, m_tpPrimaryDraggedContainer))
		{
			result = true;
		}
		return result;
	}

	internal bool IsInDragDrop()
	{
		return m_tpPrimaryDraggedContainer != null;
	}

	internal int DragItemsCount()
	{
		return m_dragItemsCount;
	}

	private PanVelocity ComputeEdgeScrollVelocity(Point dragPoint)
	{
		bool flag = false;
		bool flag2 = false;
		PanVelocity result = default(PanVelocity);
		if (m_tpScrollViewer != null)
		{
			ScrollMode scrollMode = ScrollMode.Disabled;
			ScrollMode scrollMode2 = ScrollMode.Disabled;
			scrollMode = m_tpScrollViewer.VerticalScrollMode;
			scrollMode2 = m_tpScrollViewer.HorizontalScrollMode;
			flag2 = scrollMode != ScrollMode.Disabled;
			if (scrollMode2 != 0)
			{
				double num = 0.0;
				double num2 = 0.0;
				num = m_tpScrollViewer.HorizontalOffset;
				result.HorizontalVelocity = ComputeEdgeScrollVelocityFromEdgeDistance(dragPoint.X);
				if (result.IsStationary())
				{
					double actualWidth = base.ActualWidth;
					result.HorizontalVelocity = 0f - ComputeEdgeScrollVelocityFromEdgeDistance(actualWidth - dragPoint.X);
					num2 = m_tpScrollViewer.ScrollableWidth;
				}
				else
				{
					num2 = m_tpScrollViewer.MinHorizontalOffset;
				}
				if (DoubleUtil.AreWithinTolerance(num2, num, 0.05))
				{
					result.Clear();
				}
			}
			if (flag2 && result.IsStationary())
			{
				double num3 = 0.0;
				double num4 = 0.0;
				num3 = m_tpScrollViewer.VerticalOffset;
				result.VerticalVelocity = ComputeEdgeScrollVelocityFromEdgeDistance(dragPoint.Y);
				if (result.IsStationary())
				{
					double actualHeight = base.ActualHeight;
					result.VerticalVelocity = 0f - ComputeEdgeScrollVelocityFromEdgeDistance(actualHeight - dragPoint.Y);
					num4 = m_tpScrollViewer.ScrollableHeight;
				}
				else
				{
					num4 = m_tpScrollViewer.MinVerticalOffset;
				}
				if (DoubleUtil.AreWithinTolerance(num4, num3, 0.05))
				{
					result.Clear();
				}
			}
		}
		return result;
	}

	private float ComputeEdgeScrollVelocityFromEdgeDistance(double distanceFromEdge)
	{
		if (distanceFromEdge <= 100.0)
		{
			return (float)(1500.0 - distanceFromEdge / 100.0 * 1350.0);
		}
		return 0f;
	}

	private void SetPendingAutoPanVelocity(PanVelocity velocity)
	{
		if (!velocity.IsStationary())
		{
			if (m_currentAutoPanVelocity.IsStationary())
			{
				m_pendingAutoPanVelocity = velocity;
				EnsureStartEdgeScrollTimer();
			}
			else
			{
				m_currentAutoPanVelocity = velocity;
				ScrollWithVelocity(m_currentAutoPanVelocity);
			}
		}
		else
		{
			DestroyStartEdgeScrollTimer();
			m_currentAutoPanVelocity.Clear();
			m_pendingAutoPanVelocity.Clear();
			ScrollWithVelocity(m_currentAutoPanVelocity);
		}
	}

	private void ScrollWithVelocity(PanVelocity velocity)
	{
		if (m_tpScrollViewer != null)
		{
			m_tpScrollViewer.SetConstantVelocities(velocity.HorizontalVelocity, velocity.VerticalVelocity);
		}
	}

	private void EnsureStartEdgeScrollTimer()
	{
		if (m_tpStartEdgeScrollTimer == null)
		{
			TimeSpan interval = TimeSpan.FromMilliseconds(50.0);
			m_tpStartEdgeScrollTimer = new DispatcherTimer();
			m_tpStartEdgeScrollTimer!.Tick += StartEdgeScrollTimerTick;
			m_tpStartEdgeScrollTimer!.Interval = interval;
			m_tpStartEdgeScrollTimer!.Start();
		}
	}

	private void DestroyStartEdgeScrollTimer()
	{
		if (m_tpStartEdgeScrollTimer != null)
		{
			m_tpStartEdgeScrollTimer!.Stop();
		}
		m_tpStartEdgeScrollTimer = null;
	}

	private void StartEdgeScrollTimerTick(object? pUnused1, object pUnused2)
	{
		DestroyStartEdgeScrollTimer();
		m_currentAutoPanVelocity = m_pendingAutoPanVelocity;
		m_pendingAutoPanVelocity.Clear();
		ScrollWithVelocity(m_currentAutoPanVelocity);
	}

	internal bool IsDragOverItem(SelectorItem pItem)
	{
		return pItem == m_tpDragOverItem;
	}

	internal bool GetIsHolding()
	{
		return false;
	}

	private void AddItems(int firstItem, int count, int section)
	{
		if (base.VirtualizingPanel != null)
		{
			base.VirtualizingPanel.GetLayouter().AddItems(firstItem, count, section);
		}
		else
		{
			Refresh();
		}
	}

	private void RemoveItems(int firstItem, int count, int section)
	{
		if (base.VirtualizingPanel != null)
		{
			base.VirtualizingPanel.GetLayouter().RemoveItems(firstItem, count, section);
		}
		else
		{
			Refresh();
		}
	}

	private void AddGroup(int groupIndexInView)
	{
		Refresh();
	}

	private void RemoveGroup(int groupIndexInView)
	{
		Refresh();
	}

	private void ReplaceGroup(int groupIndexInView)
	{
		Refresh();
	}

	private ContentControl ContainerFromGroupIndex(int groupIndex)
	{
		throw new NotImplementedException();
	}

	private void TryLoadMoreItems()
	{
	}

	protected virtual void OnHeaderChanged(object oldHeader, object newHeader)
	{
	}

	protected virtual void OnHeaderTemplateChanged(DataTemplate oldHeaderTemplate, DataTemplate newHeaderTemplate)
	{
	}

	protected virtual void OnFooterChanged(object oldFooter, object newFooter)
	{
	}

	protected virtual void OnFooterTemplateChanged(DataTemplate oldFooterTemplate, DataTemplate newFooterTemplate)
	{
	}

	protected virtual void OnSelectionModeChanged(ListViewSelectionMode oldSelectionMode, ListViewSelectionMode newSelectionMode)
	{
		OnSelectionModeChangedPartial(oldSelectionMode, newSelectionMode);
	}

	private void OnSelectionModeChangedPartial(ListViewSelectionMode oldSelectionMode, ListViewSelectionMode newSelectionMode)
	{
		base.SelectedIndex = -1;
		foreach (object item in SelectedItems.ToList())
		{
			SetSelectedState(IndexFromItem(item), selected: false);
		}
		SelectedItems.Clear();
		foreach (SelectorItem item2 in GetItemsPanelChildren().OfType<SelectorItem>())
		{
			ApplyMultiSelectState(item2);
		}
	}

	protected virtual void OnIsItemClickEnabledChanged(bool oldIsItemClickEnabled, bool newIsItemClickEnabled)
	{
	}

	protected virtual void OnDataFetchSizeChanged(double oldDataFetchSize, double newDataFetchSize)
	{
	}

	protected virtual void OnIncrementalLoadingThresholdChanged(double oldIncrementalLoadingThreshold, double newIncrementalLoadingThreshold)
	{
	}

	protected virtual void OnIncrementalLoadingTriggerChanged(IncrementalLoadingTrigger oldIncrementalLoadingTrigger, IncrementalLoadingTrigger newIncrementalLoadingTrigger)
	{
	}
}

using System;
using System.Collections;
using Uno;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class Pivot : ItemsControl
{
	private static class PivotHeaderItemSelectionStates
	{
		public const string Disabled = "Disabled";

		public const string Unselected = "Unselected";

		public const string UnselectedLocked = "UnselectedLocked";

		public const string Selected = "Selected";

		public const string UnselectedPointerOver = "UnselectedPointerOver";

		public const string SelectedPointerOver = "SelectedPointerOver";

		public const string UnselectedPressed = "UnselectedPressed";

		public const string SelectedPressed = "SelectedPressed";
	}

	private ContentControl _titleContentControl;

	private PivotHeaderPanel _staticHeader;

	private PivotHeaderPanel _header;

	private RectangleGeometry _headerClipperGeometry;

	private ContentControl _headerClipper;

	private DataTemplate _pivotItemTemplate;

	private bool _isTemplateApplied;

	private bool _isUWPTemplate;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsLocked
	{
		get
		{
			return (bool)GetValue(IsLockedProperty);
		}
		set
		{
			SetValue(IsLockedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHeaderItemsCarouselEnabled
	{
		get
		{
			return (bool)GetValue(IsHeaderItemsCarouselEnabledProperty);
		}
		set
		{
			SetValue(IsHeaderItemsCarouselEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PivotHeaderFocusVisualPlacement HeaderFocusVisualPlacement
	{
		get
		{
			return (PivotHeaderFocusVisualPlacement)GetValue(HeaderFocusVisualPlacementProperty);
		}
		set
		{
			SetValue(HeaderFocusVisualPlacementProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SlideInAnimationGroupProperty { get; } = DependencyProperty.RegisterAttached("SlideInAnimationGroup", typeof(PivotSlideInAnimationGroup), typeof(Pivot), new FrameworkPropertyMetadata(PivotSlideInAnimationGroup.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderFocusVisualPlacementProperty { get; } = DependencyProperty.Register("HeaderFocusVisualPlacement", typeof(PivotHeaderFocusVisualPlacement), typeof(Pivot), new FrameworkPropertyMetadata(PivotHeaderFocusVisualPlacement.ItemHeaders));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHeaderItemsCarouselEnabledProperty { get; } = DependencyProperty.Register("IsHeaderItemsCarouselEnabled", typeof(bool), typeof(Pivot), new FrameworkPropertyMetadata(false));


	public DataTemplate TitleTemplate
	{
		get
		{
			return (DataTemplate)GetValue(TitleTemplateProperty);
		}
		set
		{
			SetValue(TitleTemplateProperty, value);
		}
	}

	public object Title
	{
		get
		{
			return GetValue(TitleProperty);
		}
		set
		{
			SetValue(TitleProperty, value);
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

	public DataTemplate RightHeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(RightHeaderTemplateProperty);
		}
		set
		{
			SetValue(RightHeaderTemplateProperty, value);
		}
	}

	public object RightHeader
	{
		get
		{
			return GetValue(RightHeaderProperty);
		}
		set
		{
			SetValue(RightHeaderProperty, value);
		}
	}

	public DataTemplate LeftHeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(LeftHeaderTemplateProperty);
		}
		set
		{
			SetValue(LeftHeaderTemplateProperty, value);
		}
	}

	public object LeftHeader
	{
		get
		{
			return GetValue(LeftHeaderProperty);
		}
		set
		{
			SetValue(LeftHeaderProperty, value);
		}
	}

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(Pivot), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty IsLockedProperty { get; } = DependencyProperty.Register("IsLocked", typeof(bool), typeof(Pivot), new FrameworkPropertyMetadata(false));


	public static DependencyProperty SelectedIndexProperty { get; } = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(Pivot), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as Pivot)?.OnSelectedIndexChanged((int)e.OldValue, (int)e.NewValue);
	}));


	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(Pivot), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as Pivot)?.OnSelectedItemPropertyChanged(e.OldValue, e.NewValue);
	}));


	public static DependencyProperty TitleProperty { get; } = DependencyProperty.Register("Title", typeof(object), typeof(Pivot), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnTitlePropertyChanged));


	public static DependencyProperty TitleTemplateProperty { get; } = DependencyProperty.Register("TitleTemplate", typeof(DataTemplate), typeof(Pivot), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty LeftHeaderProperty { get; } = DependencyProperty.Register("LeftHeader", typeof(object), typeof(Pivot), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty LeftHeaderTemplateProperty { get; } = DependencyProperty.Register("LeftHeaderTemplate", typeof(DataTemplate), typeof(Pivot), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty RightHeaderProperty { get; } = DependencyProperty.Register("RightHeader", typeof(object), typeof(Pivot), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty RightHeaderTemplateProperty { get; } = DependencyProperty.Register("RightHeaderTemplate", typeof(DataTemplate), typeof(Pivot), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public event TypedEventHandler<Pivot, PivotItemEventArgs> PivotItemLoaded;

	public event TypedEventHandler<Pivot, PivotItemEventArgs> PivotItemLoading;

	public event TypedEventHandler<Pivot, PivotItemEventArgs> PivotItemUnloaded;

	public event TypedEventHandler<Pivot, PivotItemEventArgs> PivotItemUnloading;

	public event SelectionChangedEventHandler SelectionChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static PivotSlideInAnimationGroup GetSlideInAnimationGroup(FrameworkElement element)
	{
		return (PivotSlideInAnimationGroup)element.GetValue(SlideInAnimationGroupProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetSlideInAnimationGroup(FrameworkElement element, PivotSlideInAnimationGroup value)
	{
		element.SetValue(SlideInAnimationGroupProperty, value);
	}

	public Pivot()
	{
		base.DefaultStyleKey = typeof(Pivot);
		base.Loaded += delegate
		{
			RegisterHeaderEvents();
		};
		base.Unloaded += delegate
		{
			UnregisterHeaderEvents();
		};
		base.Items.VectorChanged += OnItemsVectorChanged;
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_staticHeader = GetTemplateChild("StaticHeader") as PivotHeaderPanel;
		_titleContentControl = GetTemplateChild("TitleContentControl") as ContentControl;
		_header = GetTemplateChild("Header") as PivotHeaderPanel;
		_headerClipperGeometry = GetTemplateChild("HeaderClipperGeometry") as RectangleGeometry;
		_headerClipper = GetTemplateChild("HeaderClipper") as ContentControl;
		_pivotItemTemplate = new DataTemplate(() => new PivotItem());
		_isUWPTemplate = _staticHeader != null;
		if (!_isUWPTemplate)
		{
			base.ItemsPanelRoot = null;
		}
		_isTemplateApplied = true;
		UpdateProperties();
		UpdateItems(null);
		SynchronizeItems();
	}

	private void UnregisterHeaderEvents()
	{
		if (_staticHeader == null)
		{
			return;
		}
		foreach (UIElement child in _staticHeader.Children)
		{
			if (child is PivotHeaderItem pivotHeaderItem)
			{
				pivotHeaderItem.PointerPressed -= OnItemPointerPressed;
				pivotHeaderItem.PointerEntered -= OnItemPointerEntered;
				pivotHeaderItem.PointerExited -= OnItemPointerExited;
				pivotHeaderItem.IsEnabledChanged -= OnItemIsEnabledChanged;
			}
		}
	}

	private void RegisterHeaderEvents()
	{
		UnregisterHeaderEvents();
		if (_staticHeader == null)
		{
			return;
		}
		foreach (UIElement child in _staticHeader.Children)
		{
			if (child is PivotHeaderItem pivotHeaderItem)
			{
				pivotHeaderItem.PointerPressed += OnItemPointerPressed;
				pivotHeaderItem.PointerEntered += OnItemPointerEntered;
				pivotHeaderItem.PointerExited += OnItemPointerExited;
				pivotHeaderItem.IsEnabledChanged += OnItemIsEnabledChanged;
			}
		}
	}

	private void UpdateProperties()
	{
		if (_isUWPTemplate && _isTemplateApplied)
		{
			if (_headerClipper != null)
			{
				_headerClipper.Clip = null;
			}
			if (_header != null)
			{
				_header.Visibility = Visibility.Collapsed;
			}
			if (_titleContentControl != null)
			{
				_titleContentControl.Visibility = ((Title == null) ? Visibility.Collapsed : Visibility.Visible);
			}
		}
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		if (!_isUWPTemplate)
		{
			return base.IsItemItsOwnContainerOverride(item);
		}
		return item is PivotItem;
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		if (!_isUWPTemplate)
		{
			return base.GetContainerForItemOverride();
		}
		return _pivotItemTemplate.LoadContentCached();
	}

	private void OnItemsVectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event)
	{
		SynchronizeItems();
	}

	private void SynchronizeItems()
	{
		if (_isUWPTemplate)
		{
			_staticHeader.Visibility = ((!base.HasItems) ? Visibility.Collapsed : Visibility.Visible);
			UnregisterHeaderEvents();
			_staticHeader.Children.Clear();
			IEnumerable items = GetItems();
			foreach (object item in items)
			{
				PivotHeaderItem pivotHeaderItem = new PivotHeaderItem
				{
					ContentTemplate = HeaderTemplate,
					IsHitTestVisible = true
				};
				if (item is PivotItem pivotItem)
				{
					pivotItem.PivotHeaderItem = pivotHeaderItem;
					pivotHeaderItem.Content = pivotItem.Header;
				}
				else
				{
					pivotHeaderItem.Content = item;
				}
				pivotHeaderItem.SetBinding(ContentControl.ContentTemplateProperty, new Binding
				{
					Path = "HeaderTemplate",
					RelativeSource = RelativeSource.TemplatedParent
				});
				pivotHeaderItem.EnsureTemplate();
				_staticHeader.Children.Add(pivotHeaderItem);
			}
			if (SelectedIndex == -1 && base.HasItems)
			{
				SelectedIndex = 0;
			}
			else
			{
				SynchronizeSelectedItem();
			}
			RegisterHeaderEvents();
		}
		else if (base.TemplatedRoot is NativePivotPresenter nativePivotPresenter)
		{
			nativePivotPresenter.Items.Clear();
			nativePivotPresenter.Items.AddRange(base.Items);
		}
	}

	private void OnItemPointerPressed(object sender, PointerRoutedEventArgs e)
	{
		if (_isUWPTemplate && sender is PivotHeaderItem pivotHeaderItem)
		{
			UpdateVisualStates(pivotHeaderItem);
			SelectedIndex = _staticHeader.Children.IndexOf(pivotHeaderItem);
		}
	}

	private void OnItemPointerEntered(object sender, PointerRoutedEventArgs e)
	{
		if (_isUWPTemplate && sender is PivotHeaderItem headerItem)
		{
			UpdateVisualStates(headerItem);
		}
	}

	private void OnItemPointerExited(object sender, PointerRoutedEventArgs e)
	{
		if (_isUWPTemplate && sender is PivotHeaderItem headerItem)
		{
			UpdateVisualStates(headerItem);
		}
	}

	private void OnItemIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (_isUWPTemplate && sender is PivotHeaderItem headerItem)
		{
			UpdateVisualStates(headerItem);
		}
	}

	private void UpdateVisualStates(PivotHeaderItem headerItem)
	{
		if (_isUWPTemplate)
		{
			if (!headerItem.IsEnabled)
			{
				VisualStateManager.GoToState(headerItem, "Disabled", useTransitions: true);
				return;
			}
			bool flag = SelectedIndex == _staticHeader.Children.IndexOf(headerItem);
			bool isPointerOver = headerItem.IsPointerOver;
			bool isPointerPressed = headerItem.IsPointerPressed;
			string text = (flag ? (isPointerOver ? "SelectedPointerOver" : ((!isPointerPressed) ? "Selected" : "SelectedPressed")) : (isPointerOver ? "UnselectedPointerOver" : ((!isPointerPressed) ? "Unselected" : "UnselectedPressed")));
			string stateName = text;
			VisualStateManager.GoToState(headerItem, stateName, useTransitions: true);
		}
	}

	private void OnSelectedIndexChanged(int oldValue, int newValue)
	{
		if (_isUWPTemplate)
		{
			SynchronizeSelectedItem();
		}
	}

	protected override void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnItemsSourceChanged(e);
		SynchronizeItems();
	}

	private void SynchronizeSelectedItem()
	{
		if (SelectedIndex == -1 || !base.HasItems)
		{
			return;
		}
		int num = Math.Max(Math.Min(SelectedIndex, base.NumberOfItems - 1), 0);
		PivotHeaderItem pivotHeaderItem = _staticHeader.Children[num] as PivotHeaderItem;
		IEnumerable items = GetItems();
		object obj2 = (SelectedItem = items.ElementAt(num));
		for (int i = 0; i < base.NumberOfItems; i++)
		{
			if (ContainerFromIndex(i) is ContentControl contentControl && num != i)
			{
				contentControl.Visibility = Visibility.Collapsed;
			}
		}
		if (ContainerFromIndex(num) is ContentControl contentControl2)
		{
			contentControl2.Visibility = Visibility.Visible;
		}
		foreach (UIElement child in _staticHeader.Children)
		{
			if (child is PivotHeaderItem control && child != pivotHeaderItem)
			{
				VisualStateManager.GoToState(control, "Unselected", useTransitions: true);
			}
		}
		VisualStateManager.GoToState(pivotHeaderItem, "Selected", useTransitions: true);
	}

	private static void OnTitlePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is Pivot pivot && pivot._isUWPTemplate)
		{
			pivot.UpdateProperties();
		}
	}

	private void OnSelectedItemPropertyChanged(object oldValue, object newValue)
	{
		object[] removedItems = ((oldValue == null) ? Array.Empty<object>() : new object[1] { oldValue });
		object[] addedItems = ((newValue == null) ? Array.Empty<object>() : new object[1] { newValue });
		if (newValue is PivotItem pivotItem)
		{
			PivotHeaderItem pivotHeaderItem = pivotItem.PivotHeaderItem;
			if (pivotHeaderItem != null)
			{
				int num = _staticHeader.Children.IndexOf(pivotHeaderItem);
				if (num > -1)
				{
					SelectedIndex = num;
				}
			}
		}
		InvokeSelectionChanged(removedItems, addedItems);
	}

	protected void InvokeSelectionChanged(object[] removedItems, object[] addedItems)
	{
		this.SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(this, removedItems, addedItems));
	}
}

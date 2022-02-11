using System;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class ComboBox : Selector
{
	private class DropDownLayouter : Popup.IDynamicPopupLayouter
	{
		private ManagedWeakReference _combo;

		private ManagedWeakReference _popup;

		private const int _itemsToShow = 9;

		private ComboBox? Combo => _combo.Target as ComboBox;

		private Popup? Popup => _popup.Target as Popup;

		public DropDownLayouter(ComboBox combo, Popup popup)
		{
			_combo = ((IWeakReferenceProvider)combo).WeakReference;
			_popup = ((IWeakReferenceProvider)popup).WeakReference;
		}

		public Size Measure(Size available, Size visibleSize)
		{
			Popup popup = Popup;
			ComboBox combo = Combo;
			if (!(popup?.Child is FrameworkElement frameworkElement) || combo == null)
			{
				return default(Size);
			}
			if (combo.IsPopupFullscreen)
			{
				frameworkElement.MinWidth = available.Width;
				frameworkElement.MaxWidth = available.Width;
				frameworkElement.MaxHeight = available.Height;
			}
			else
			{
				double maxHeight = Math.Min(visibleSize.Height, Math.Min(combo.MaxDropDownHeight, combo.ActualHeight * 9.0));
				frameworkElement.MinHeight = combo.ActualHeight;
				frameworkElement.MinWidth = combo.ActualWidth;
				frameworkElement.MaxHeight = maxHeight;
				frameworkElement.MaxWidth = visibleSize.Width;
				frameworkElement.HorizontalAlignment = HorizontalAlignment.Left;
				frameworkElement.VerticalAlignment = VerticalAlignment.Top;
			}
			frameworkElement.Measure(visibleSize);
			return frameworkElement.DesiredSize;
		}

		public void Arrange(Size finalSize, Rect visibleBounds, Size desiredSize, Point? upperLeftLocation)
		{
			Popup popup = Popup;
			ComboBox combo = Combo;
			UIElement uIElement = popup?.Child;
			FrameworkElement child = uIElement as FrameworkElement;
			if (child == null || combo == null)
			{
				return;
			}
			if (combo.IsPopupFullscreen)
			{
				Size size = new Size(finalSize.Width, Math.Min(finalSize.Height, child.DesiredSize.Height));
				Rect rect = new Rect(getChildLocation(), size);
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"FullScreen Layout for dropdown (desired: {desiredSize} / available: {finalSize} / visible: {visibleBounds} / finalRect: {rect} )");
				}
				child.Arrange(rect);
				return;
			}
			Rect absoluteBoundsRect = combo.GetAbsoluteBoundsRect();
			Rect rect2 = new Rect(absoluteBoundsRect.Location, desiredSize.AtMost(visibleBounds.Size));
			int numberOfItems = combo.NumberOfItems;
			int num = combo.SelectedIndex;
			if (num < 0 && numberOfItems > 0)
			{
				num = numberOfItems / 2;
			}
			DropDownPlacement dropDownPreferredPlacement = Uno.UI.Xaml.Controls.ComboBox.GetDropDownPreferredPlacement(combo);
			int num2 = Math.Max(1, Math.Min(4, numberOfItems / 2 - 1));
			switch (dropDownPreferredPlacement)
			{
			case DropDownPlacement.Auto:
				if (num >= 0 && num < num2)
				{
					goto case DropDownPlacement.Below;
				}
				if (num >= 0 && num >= numberOfItems - num2 && numberOfItems <= 9 && rect2.Height < combo.ActualHeight * 9.0 - 3.0)
				{
					goto case DropDownPlacement.Above;
				}
				goto default;
			case DropDownPlacement.Below:
				rect2.Y = absoluteBoundsRect.Top;
				break;
			case DropDownPlacement.Above:
				rect2.Y = absoluteBoundsRect.Bottom - rect2.Height;
				break;
			default:
				rect2.Y = absoluteBoundsRect.Top - rect2.Height / 2.0 + absoluteBoundsRect.Height / 2.0;
				break;
			}
			if (rect2.Left < visibleBounds.Left)
			{
				rect2.X = visibleBounds.X;
			}
			else if (rect2.Right > visibleBounds.Width)
			{
				rect2.X = visibleBounds.Width - rect2.Width;
			}
			if (rect2.Top < visibleBounds.Top)
			{
				rect2.Y = visibleBounds.Y;
			}
			else if (rect2.Bottom > visibleBounds.Height)
			{
				rect2.Y = visibleBounds.Height - rect2.Height - 1.0;
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Layout the combo's dropdown at {rect2} (desired: {desiredSize} / available: {finalSize} / visible: {visibleBounds} / selected: {num} of {numberOfItems})");
			}
			if (upperLeftLocation.HasValue)
			{
				Point valueOrDefault = upperLeftLocation.GetValueOrDefault();
				rect2.X -= valueOrDefault.X;
				rect2.Y -= valueOrDefault.Y;
			}
			child.Arrange(rect2);
			Point getChildLocation()
			{
				VerticalAlignment verticalAlignment = child.VerticalAlignment;
				if (verticalAlignment == VerticalAlignment.Top || verticalAlignment != VerticalAlignment.Bottom)
				{
					return default(Point);
				}
				return new Point(0.0, finalSize.Height - child.DesiredSize.Height);
			}
		}
	}

	private bool _areItemTemplatesForwarded;

	private IPopup? _popup;

	private Border? _popupBorder;

	private ContentPresenter? _contentPresenter;

	private TextBlock? _placeholderTextBlock;

	private ContentPresenter? _headerContentPresenter;

	private ManagedWeakReference? _selectionParentInDropdown;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsEditable
	{
		get
		{
			return (bool)GetValue(IsEditableProperty);
		}
		set
		{
			SetValue(IsEditableProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSelectionBoxHighlighted
	{
		get
		{
			throw new NotImplementedException("The member bool ComboBox.IsSelectionBoxHighlighted is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object SelectionBoxItem
	{
		get
		{
			throw new NotImplementedException("The member object ComboBox.SelectionBoxItem is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataTemplate SelectionBoxItemTemplate
	{
		get
		{
			throw new NotImplementedException("The member DataTemplate ComboBox.SelectionBoxItemTemplate is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsTextSearchEnabled
	{
		get
		{
			return (bool)GetValue(IsTextSearchEnabledProperty);
		}
		set
		{
			SetValue(IsTextSearchEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ComboBoxSelectionChangedTrigger SelectionChangedTrigger
	{
		get
		{
			return (ComboBoxSelectionChangedTrigger)GetValue(SelectionChangedTriggerProperty);
		}
		set
		{
			SetValue(SelectionChangedTriggerProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush PlaceholderForeground
	{
		get
		{
			return (Brush)GetValue(PlaceholderForegroundProperty);
		}
		set
		{
			SetValue(PlaceholderForegroundProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Style TextBoxStyle
	{
		get
		{
			return (Style)GetValue(TextBoxStyleProperty);
		}
		set
		{
			SetValue(TextBoxStyleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			SetValue(TextProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Description
	{
		get
		{
			return GetValue(DescriptionProperty);
		}
		set
		{
			SetValue(DescriptionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextSearchEnabledProperty { get; } = DependencyProperty.Register("IsTextSearchEnabled", typeof(bool), typeof(ComboBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionChangedTriggerProperty { get; } = DependencyProperty.Register("SelectionChangedTrigger", typeof(ComboBoxSelectionChangedTrigger), typeof(ComboBox), new FrameworkPropertyMetadata(ComboBoxSelectionChangedTrigger.Committed));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlaceholderForegroundProperty { get; } = DependencyProperty.Register("PlaceholderForeground", typeof(Brush), typeof(ComboBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(object), typeof(ComboBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsEditableProperty { get; } = DependencyProperty.Register("IsEditable", typeof(bool), typeof(ComboBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextBoxStyleProperty { get; } = DependencyProperty.Register("TextBoxStyle", typeof(Style), typeof(ComboBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(ComboBox), new FrameworkPropertyMetadata((object)null));


	public ComboBoxTemplateSettings TemplateSettings { get; } = new ComboBoxTemplateSettings();


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

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(ComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ComboBox)s)?.OnHeaderChanged(e.OldValue, e.NewValue);
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

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(ComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ComboBox)s)?.OnHeaderTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue);
	}));


	public bool IsPopupFullscreen { get; set; }

	public LightDismissOverlayMode LightDismissOverlayMode
	{
		get
		{
			return (LightDismissOverlayMode)GetValue(LightDismissOverlayModeProperty);
		}
		set
		{
			SetValue(LightDismissOverlayModeProperty, value);
		}
	}

	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(ComboBox), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


	internal Brush LightDismissOverlayBackground
	{
		get
		{
			return (Brush)GetValue(LightDismissOverlayBackgroundProperty);
		}
		set
		{
			SetValue(LightDismissOverlayBackgroundProperty, value);
		}
	}

	internal static DependencyProperty LightDismissOverlayBackgroundProperty { get; } = DependencyProperty.Register("LightDismissOverlayBackground", typeof(Brush), typeof(ComboBox), new FrameworkPropertyMetadata(null));


	public string PlaceholderText
	{
		get
		{
			return (string)GetValue(PlaceholderTextProperty);
		}
		set
		{
			SetValue(PlaceholderTextProperty, value);
		}
	}

	public static DependencyProperty PlaceholderTextProperty { get; } = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(ComboBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ComboBox)s)?.OnPlaceholderTextChanged((string)e.OldValue, (string)e.NewValue);
	}));


	public bool IsDropDownOpen
	{
		get
		{
			return (bool)GetValue(IsDropDownOpenProperty);
		}
		set
		{
			SetValue(IsDropDownOpenProperty, value);
		}
	}

	public static DependencyProperty IsDropDownOpenProperty { get; } = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(ComboBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ComboBox)s)?.OnIsDropDownOpenChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public double MaxDropDownHeight
	{
		get
		{
			return (double)GetValue(MaxDropDownHeightProperty);
		}
		set
		{
			SetValue(MaxDropDownHeightProperty, value);
		}
	}

	public static DependencyProperty MaxDropDownHeightProperty { get; } = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(ComboBox), new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ComboBox)s)?.OnMaxDropDownHeightChanged((double)e.OldValue, (double)e.NewValue);
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ComboBox, ComboBoxTextSubmittedEventArgs> TextSubmitted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ComboBox", "event TypedEventHandler<ComboBox, ComboBoxTextSubmittedEventArgs> ComboBox.TextSubmitted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ComboBox", "event TypedEventHandler<ComboBox, ComboBoxTextSubmittedEventArgs> ComboBox.TextSubmitted");
		}
	}

	public event EventHandler<object>? DropDownClosed;

	public event EventHandler<object>? DropDownOpened;

	public ComboBox()
	{
		ResourceResolver.ApplyResource(this, LightDismissOverlayBackgroundProperty, "ComboBoxLightDismissOverlayBackground", isThemeResourceExtension: true, isHotReloadSupported: true);
		base.DefaultStyleKey = typeof(ComboBox);
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return new ComboBoxItem
		{
			IsGeneratedContainer = true
		};
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is ComboBoxItem;
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_popup is Popup popup)
		{
			popup.CustomLayouter = null;
		}
		_popup = GetTemplateChild("Popup") as IPopup;
		_popupBorder = GetTemplateChild("PopupBorder") as Border;
		_contentPresenter = GetTemplateChild("ContentPresenter") as ContentPresenter;
		_placeholderTextBlock = GetTemplateChild("PlaceholderTextBlock") as TextBlock;
		if (_popup is Popup popup2)
		{
			Border popupBorder = _popupBorder;
			if (popupBorder != null)
			{
				popupBorder.AllowFocusOnInteraction = false;
			}
			popup2.CustomLayouter = new DropDownLayouter(this, popup2);
			popup2.BindToEquivalentProperty(this, "LightDismissOverlayMode");
			popup2.BindToEquivalentProperty(this, "LightDismissOverlayBackground");
		}
		UpdateHeaderVisibility();
		UpdateContentPresenter();
		if (_contentPresenter == null)
		{
			return;
		}
		_contentPresenter!.SynchronizeContentWithOuterTemplatedParent = false;
		ManagedWeakReference thisRef = ((IWeakReferenceProvider)this).WeakReference;
		_contentPresenter!.DataContextChanged += delegate(FrameworkElement snd, DataContextChangedEventArgs evt)
		{
			if (thisRef.Target is ComboBox comboBox && evt.NewValue != null && comboBox.SelectedItem == null && comboBox._contentPresenter != null)
			{
				comboBox._contentPresenter!.DataContext = null;
			}
		};
		UpdateCommonStates();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		UpdateDropDownState();
		if (_popup != null)
		{
			_popup!.Closed += OnPopupClosed;
			_popup!.Opened += OnPopupOpened;
		}
		Window.Current.SizeChanged += OnWindowSizeChanged;
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		if (_popup != null)
		{
			_popup!.Closed -= OnPopupClosed;
			_popup!.Opened -= OnPopupOpened;
		}
		Window.Current.SizeChanged -= OnWindowSizeChanged;
	}

	protected virtual void OnDropDownClosed(object e)
	{
		this.DropDownClosed?.Invoke(this, null);
	}

	protected virtual void OnDropDownOpened(object e)
	{
		this.DropDownOpened?.Invoke(this, null);
	}

	private void OnWindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
	{
		IsDropDownOpen = false;
	}

	private void OnPopupOpened(object? sender, object e)
	{
		IsDropDownOpen = true;
	}

	private void OnPopupClosed(object? sender, object e)
	{
		IsDropDownOpen = false;
	}

	private void OnHeaderChanged(object oldHeader, object newHeader)
	{
		UpdateHeaderVisibility();
	}

	private void OnHeaderTemplateChanged(DataTemplate oldHeaderTemplate, DataTemplate newHeaderTemplate)
	{
		UpdateHeaderVisibility();
	}

	private void UpdateHeaderVisibility()
	{
		Visibility visibility = ((Header == null && HeaderTemplate == null) ? Visibility.Collapsed : Visibility.Visible);
		if (visibility == Visibility.Visible && _headerContentPresenter == null)
		{
			_headerContentPresenter = GetTemplateChild("HeaderContentPresenter") as ContentPresenter;
			if (_headerContentPresenter != null)
			{
				_headerContentPresenter!.IsHitTestVisible = false;
			}
		}
		if (_headerContentPresenter != null)
		{
			_headerContentPresenter!.Visibility = visibility;
		}
	}

	internal override void OnSelectedItemChanged(object oldSelectedItem, object selectedItem, bool updateItemSelectedState)
	{
		if (oldSelectedItem is FrameworkElement selectionView)
		{
			RestoreSelectedItem(selectionView);
		}
		base.OnSelectedItemChanged(oldSelectedItem, selectedItem, updateItemSelectedState);
		UpdateContentPresenter();
	}

	internal override void OnItemClicked(int clickedIndex)
	{
		base.OnItemClicked(clickedIndex);
		IsDropDownOpen = false;
	}

	private void UpdateContentPresenter()
	{
		if (_contentPresenter == null)
		{
			return;
		}
		if (base.SelectedItem != null)
		{
			object selectionContent = GetSelectionContent();
			FrameworkElement frameworkElement = selectionContent as FrameworkElement;
			if (frameworkElement != null)
			{
				ComboBoxItem comboBoxItem = frameworkElement.FindFirstParent<ComboBoxItem>();
				if (comboBoxItem != null)
				{
					_selectionParentInDropdown = ((IWeakReferenceProvider)frameworkElement.GetVisualTreeParent())?.WeakReference;
				}
			}
			else
			{
				_selectionParentInDropdown = null;
			}
			string displayMemberPath = base.DisplayMemberPath;
			if (string.IsNullOrEmpty(displayMemberPath))
			{
				_contentPresenter!.Content = selectionContent;
			}
			else
			{
				BindingPath bindingPath = new BindingPath(displayMemberPath, selectionContent)
				{
					DataContext = selectionContent
				};
				_contentPresenter!.Content = bindingPath.Value;
			}
			if (frameworkElement != null && frameworkElement.GetVisualTreeParent() != _contentPresenter)
			{
				_contentPresenter!.AddChild(frameworkElement);
			}
			if (!_areItemTemplatesForwarded)
			{
				SetContentPresenterBinding(ContentPresenter.ContentTemplateProperty, "ItemTemplate");
				SetContentPresenterBinding(ContentPresenter.ContentTemplateSelectorProperty, "ItemTemplateSelector");
				_areItemTemplatesForwarded = true;
			}
		}
		else
		{
			_contentPresenter!.Content = _placeholderTextBlock;
			if (_areItemTemplatesForwarded)
			{
				_contentPresenter!.ClearValue(ContentPresenter.ContentTemplateProperty);
				_contentPresenter!.ClearValue(ContentPresenter.ContentTemplateSelectorProperty);
				_areItemTemplatesForwarded = false;
			}
		}
		void SetContentPresenterBinding(DependencyProperty targetProperty, string sourcePropertyPath)
		{
			_contentPresenter?.SetBinding(targetProperty, new Binding(sourcePropertyPath)
			{
				RelativeSource = RelativeSource.TemplatedParent
			});
		}
	}

	private object? GetSelectionContent()
	{
		if (!(base.SelectedItem is ComboBoxItem comboBoxItem))
		{
			return base.SelectedItem;
		}
		return comboBoxItem.Content;
	}

	private void RestoreSelectedItem()
	{
		object selectionContent = GetSelectionContent();
		if (selectionContent is FrameworkElement selectionView)
		{
			RestoreSelectedItem(selectionView);
		}
	}

	private void RestoreSelectedItem(FrameworkElement selectionView)
	{
		FrameworkElement frameworkElement = _selectionParentInDropdown?.Target as FrameworkElement;
		ComboBoxItem comboBoxItem = frameworkElement?.FindFirstParent<ComboBoxItem>();
		if (frameworkElement != null && comboBoxItem?.Content == selectionView && selectionView.GetVisualTreeParent() != frameworkElement)
		{
			frameworkElement.AddChild(selectionView);
		}
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		base.OnIsEnabledChanged(e);
		UpdateCommonStates();
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		base.OnPointerPressed(args);
		args.Handled = true;
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		base.OnPointerReleased(args);
		Focus(FocusState.Programmatic);
		IsDropDownOpen = true;
		args.Handled = true;
	}

	private void UpdateDropDownState()
	{
		string stateName = (IsDropDownOpen ? "Opened" : "Closed");
		VisualStateManager.GoToState(this, stateName, useTransitions: true);
	}

	private void UpdateCommonStates()
	{
		string stateName = (base.IsEnabled ? "Normal" : "Disabled");
		VisualStateManager.GoToState(this, stateName, useTransitions: true);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ComboBoxAutomationPeer(this);
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		UpdateVisualState();
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		UpdateVisualState();
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		if (base.FocusState != 0 && base.IsEnabled)
		{
			if (base.FocusState == FocusState.Pointer)
			{
				GoToState(useTransitions, "PointerFocused");
			}
			else
			{
				GoToState(useTransitions, "Focused");
			}
		}
		else
		{
			GoToState(useTransitions, "Unfocused");
		}
	}

	protected virtual void OnPlaceholderTextChanged(string oldPlaceholderText, string newPlaceholderText)
	{
	}

	protected virtual void OnIsDropDownOpenChanged(bool oldIsDropDownOpen, bool newIsDropDownOpen)
	{
		OnIsDropDownOpenChangedPartial(oldIsDropDownOpen, newIsDropDownOpen);
	}

	private void OnIsDropDownOpenChangedPartial(bool oldIsDropDownOpen, bool newIsDropDownOpen)
	{
		if (_popup != null)
		{
			_popup!.IsOpen = newIsDropDownOpen;
		}
		RoutedEventArgs e = new RoutedEventArgs
		{
			OriginalSource = this
		};
		if (newIsDropDownOpen)
		{
			OnDropDownOpened(e);
			RestoreSelectedItem();
		}
		else
		{
			OnDropDownClosed(e);
			UpdateContentPresenter();
			Focus(FocusState.Programmatic);
		}
		UpdateDropDownState();
	}

	protected virtual void OnMaxDropDownHeightChanged(double oldMaxDropDownHeight, double newMaxDropDownHeight)
	{
	}
}

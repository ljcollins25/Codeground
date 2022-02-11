using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.UI.Private.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.UI.Helpers.WinUI;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

[ContentProperty(Name = "Items")]
public class RadioButtons : Control
{
	private int m_selectedIndex = -1;

	private bool m_currentlySelecting;

	private bool m_blockSelecting = true;

	private ItemsRepeater m_repeater;

	private RadioButtonsElementFactory m_radioButtonsElementFactory;

	private bool m_testHooksEnabled;

	private const string s_repeaterName = "InnerRepeater";

	private const string s_childHandlersPropertyName = "ChildHandlers";

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

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(RadioButtons), new FrameworkPropertyMetadata(null, OnPropertyChanged));


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

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(RadioButtons), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


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

	public static DependencyProperty ItemsProperty { get; } = DependencyProperty.Register("Items", typeof(IList<object>), typeof(RadioButtons), new FrameworkPropertyMetadata(null, OnPropertyChanged));


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

	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(RadioButtons), new FrameworkPropertyMetadata(null, OnPropertyChanged));


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

	public static DependencyProperty ItemTemplateProperty { get; } = DependencyProperty.Register("ItemTemplate", typeof(object), typeof(RadioButtons), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public int MaxColumns
	{
		get
		{
			return (int)GetValue(MaxColumnsProperty);
		}
		set
		{
			SetValue(MaxColumnsProperty, value);
		}
	}

	public static DependencyProperty MaxColumnsProperty { get; } = DependencyProperty.Register("MaxColumns", typeof(int), typeof(RadioButtons), new FrameworkPropertyMetadata(1, OnPropertyChanged));


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

	public static DependencyProperty SelectedIndexProperty { get; } = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(RadioButtons), new FrameworkPropertyMetadata(-1, OnPropertyChanged));


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

	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(RadioButtons), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public event SelectionChangedEventHandler SelectionChanged;

	public RadioButtons()
	{
		ObservableCollection<object> value = new ObservableCollection<object>();
		SetValue(ItemsProperty, value);
		base.DefaultStyleKey = typeof(RadioButtons);
		if (this != null)
		{
			PreviewKeyDown += OnChildPreviewKeyDown;
		}
		base.AccessKeyInvoked += OnAccessKeyInvoked;
		base.GettingFocus += OnGettingFocus;
		m_radioButtonsElementFactory = new RadioButtonsElementFactory();
	}

	protected override void OnApplyTemplate()
	{
		base.IsEnabledChanged += OnIsEnabledChanged;
		m_repeater = GetRepeater();
		UpdateItemsSource();
		UpdateVisualStateForIsEnabledChange();
		ItemsRepeater GetRepeater()
		{
			ItemsRepeater templateChild = GetTemplateChild<ItemsRepeater>("InnerRepeater");
			if (templateChild != null)
			{
				templateChild.ItemTemplate = m_radioButtonsElementFactory;
				templateChild.ElementPrepared += OnRepeaterElementPrepared;
				templateChild.ElementClearing += OnRepeaterElementClearing;
				templateChild.ElementIndexChanged += OnRepeaterElementIndexChanged;
				templateChild.Loaded += OnRepeaterLoaded;
				return templateChild;
			}
			return null;
		}
	}

	private void OnGettingFocus(object sender, GettingFocusEventArgs args)
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater == null)
		{
			return;
		}
		FocusInputDeviceKind inputDevice = args.InputDevice;
		if (inputDevice != FocusInputDeviceKind.Keyboard)
		{
			return;
		}
		DependencyObject oldFocusedElement = args.OldFocusedElement;
		if (oldFocusedElement == null || repeater != VisualTreeHelper.GetParent(oldFocusedElement))
		{
			UIElement uIElement = repeater.TryGetElement(m_selectedIndex);
			if (uIElement != null)
			{
				if (args != null && args.TrySetNewFocusedElement(uIElement))
				{
					args.Handled = true;
				}
			}
		}
		else if (SharedHelpers.IsRS3OrHigher() && (Window.Current.CoreWindow.GetKeyState(VirtualKey.Control) & CoreVirtualKeyStates.Down) != CoreVirtualKeyStates.Down && args.NewFocusedElement is UIElement element)
		{
			Select(repeater.GetElementIndex(element));
			args.Handled = true;
		}
	}

	private void OnRepeaterLoaded(object sender, RoutedEventArgs args)
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			if (m_testHooksEnabled)
			{
				AttachToLayoutChanged();
			}
			m_blockSelecting = false;
			if (SelectedIndex == -1 && SelectedItem != null)
			{
				UpdateSelectedItem();
			}
			else
			{
				UpdateSelectedIndex();
			}
			OnRepeaterCollectionChanged(null, null);
		}
	}

	private void OnChildPreviewKeyDown(object sender, KeyRoutedEventArgs args)
	{
		switch (args.Key)
		{
		case VirtualKey.Down:
			if (MoveFocusNext())
			{
				args.Handled = true;
			}
			else if (args.OriginalKey == VirtualKey.GamepadDPadDown && FocusManager.TryMoveFocus(FocusNavigationDirection.Next))
			{
				args.Handled = true;
			}
			else
			{
				args.Handled = HandleEdgeCaseFocus(first: false, args.OriginalSource);
			}
			break;
		case VirtualKey.Up:
			if (MoveFocusPrevious())
			{
				args.Handled = true;
			}
			else if (args.OriginalKey == VirtualKey.GamepadDPadUp && FocusManager.TryMoveFocus(FocusNavigationDirection.Previous))
			{
				args.Handled = true;
			}
			else
			{
				args.Handled = HandleEdgeCaseFocus(first: true, args.OriginalSource);
			}
			break;
		case VirtualKey.Right:
			if (args.OriginalKey != VirtualKey.GamepadDPadRight)
			{
				if (FocusManager.TryMoveFocus(FocusNavigationDirection.Right, GetFindNextElementOptions()))
				{
					args.Handled = true;
					break;
				}
			}
			else if (FocusManager.TryMoveFocus(FocusNavigationDirection.Right))
			{
				args.Handled = true;
				break;
			}
			args.Handled = HandleEdgeCaseFocus(first: false, args.OriginalSource);
			break;
		case VirtualKey.Left:
			if (args.OriginalKey != VirtualKey.GamepadDPadLeft)
			{
				if (FocusManager.TryMoveFocus(FocusNavigationDirection.Left, GetFindNextElementOptions()))
				{
					args.Handled = true;
					break;
				}
			}
			else if (FocusManager.TryMoveFocus(FocusNavigationDirection.Left))
			{
				args.Handled = true;
				break;
			}
			args.Handled = HandleEdgeCaseFocus(first: true, args.OriginalSource);
			break;
		}
	}

	private void OnAccessKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
	{
		if (base.IsAccessKeyScope)
		{
			return;
		}
		if (m_selectedIndex != 0)
		{
			ItemsRepeater repeater = m_repeater;
			if (repeater != null)
			{
				UIElement uIElement = repeater.TryGetElement(m_selectedIndex);
				if (uIElement != null && uIElement is Control control)
				{
					args.Handled = control.Focus(FocusState.Programmatic);
					return;
				}
			}
		}
		args.Handled = Focus(FocusState.Programmatic);
	}

	private bool HandleEdgeCaseFocus(bool first, object source)
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater != null && source is UIElement element)
		{
			int num = GetIndex();
			if (repeater.GetElementIndex(element) == num)
			{
				return true;
			}
		}
		return false;
		int GetIndex()
		{
			if (first)
			{
				return 0;
			}
			ItemsSourceView itemsSourceView = repeater.ItemsSourceView;
			if (itemsSourceView != null)
			{
				return itemsSourceView.Count - 1;
			}
			return -1;
		}
	}

	private FindNextElementOptions GetFindNextElementOptions()
	{
		FindNextElementOptions findNextElementOptions = new FindNextElementOptions();
		findNextElementOptions.SearchRoot = this;
		return findNextElementOptions;
	}

	private void OnRepeaterElementPrepared(ItemsRepeater sender, ItemsRepeaterElementPreparedEventArgs args)
	{
		UIElement element = args.Element;
		if (element == null)
		{
			return;
		}
		if (element is ToggleButton toggleButton)
		{
			toggleButton.Checked += new RoutedEventHandler(OnChildChecked);
			toggleButton.Unchecked += new RoutedEventHandler(OnChildUnchecked);
			if (SharedHelpers.IsTrue(toggleButton.IsChecked))
			{
				Select(args.Index);
			}
			if (args.Index == SelectedIndex)
			{
				toggleButton.IsChecked = true;
			}
		}
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			ItemsSourceView itemsSourceView = repeater.ItemsSourceView;
			if (itemsSourceView != null)
			{
				element.SetValue(AutomationProperties.PositionInSetProperty, args.Index + 1);
				element.SetValue(AutomationProperties.SizeOfSetProperty, itemsSourceView.Count);
			}
		}
	}

	private void OnRepeaterElementClearing(ItemsRepeater itemsRepeater, ItemsRepeaterElementClearingEventArgs args)
	{
		UIElement element = args.Element;
		if (element != null && element is ToggleButton toggleButton)
		{
			toggleButton.Checked -= new RoutedEventHandler(OnChildChecked);
			toggleButton.Unchecked -= new RoutedEventHandler(OnChildUnchecked);
			if (SharedHelpers.IsTrue(toggleButton.IsChecked))
			{
				Select(-1);
			}
		}
	}

	private void OnRepeaterElementIndexChanged(ItemsRepeater sender, ItemsRepeaterElementIndexChangedEventArgs args)
	{
		UIElement element = args.Element;
		if (element != null)
		{
			element.SetValue(AutomationProperties.PositionInSetProperty, args.NewIndex + 1);
			if (element is ToggleButton toggleButton && SharedHelpers.IsTrue(toggleButton.IsChecked))
			{
				Select(args.NewIndex);
			}
		}
	}

	private void OnRepeaterCollectionChanged(object sender, object args)
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater == null)
		{
			return;
		}
		ItemsSourceView itemsSourceView = repeater.ItemsSourceView;
		if (itemsSourceView != null)
		{
			int count = itemsSourceView.Count;
			for (int i = 0; i < count; i++)
			{
				repeater.TryGetElement(i)?.SetValue(AutomationProperties.SizeOfSetProperty, count);
			}
		}
	}

	private void Select(int index)
	{
		if (!m_blockSelecting && !m_currentlySelecting && m_selectedIndex != index)
		{
			try
			{
				m_currentlySelecting = true;
				int selectedIndex = m_selectedIndex;
				m_selectedIndex = index;
				object dataAtIndex = GetDataAtIndex(m_selectedIndex, containerIsChecked: true);
				object dataAtIndex2 = GetDataAtIndex(selectedIndex, containerIsChecked: false);
				SelectedIndex = m_selectedIndex;
				SelectedItem = dataAtIndex;
				this.SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(new List<object> { dataAtIndex2 }, new List<object> { dataAtIndex }));
			}
			finally
			{
				m_currentlySelecting = false;
			}
		}
	}

	private object GetDataAtIndex(int index, bool containerIsChecked)
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			UIElement uIElement = repeater.TryGetElement(index);
			if (uIElement != null && uIElement is ToggleButton toggleButton)
			{
				toggleButton.IsChecked = containerIsChecked;
			}
			if (index >= 0)
			{
				ItemsSourceView itemsSourceView = repeater.ItemsSourceView;
				if (itemsSourceView != null && index < itemsSourceView.Count)
				{
					return itemsSourceView.GetAt(index);
				}
			}
		}
		return null;
	}

	private void OnChildChecked(object sender, RoutedEventArgs args)
	{
		if (!m_currentlySelecting)
		{
			ItemsRepeater repeater = m_repeater;
			if (repeater != null && sender is UIElement element)
			{
				Select(repeater.GetElementIndex(element));
			}
		}
	}

	private void OnChildUnchecked(object sender, RoutedEventArgs args)
	{
		if (!m_currentlySelecting)
		{
			ItemsRepeater repeater = m_repeater;
			if (repeater != null && sender is UIElement element && m_selectedIndex == repeater.GetElementIndex(element))
			{
				Select(-1);
			}
		}
	}

	private bool MoveFocusNext()
	{
		return MoveFocus(1);
	}

	private bool MoveFocusPrevious()
	{
		return MoveFocus(-1);
	}

	private bool MoveFocus(int indexIncrement)
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater != null && FocusManager.GetFocusedElement() is UIElement element)
		{
			int elementIndex = repeater.GetElementIndex(element);
			if (elementIndex >= 0)
			{
				elementIndex += indexIncrement;
				for (int count = repeater.ItemsSourceView.Count; elementIndex >= 0 && elementIndex < count; elementIndex += indexIncrement)
				{
					UIElement uIElement = repeater.TryGetElement(elementIndex);
					if (uIElement != null && uIElement is Control control && control.Focus(FocusState.Programmatic))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == ItemsProperty || property == ItemsSourceProperty)
		{
			UpdateItemsSource();
		}
		else if (property == SelectedIndexProperty)
		{
			UpdateSelectedIndex();
		}
		else if (property == SelectedItemProperty)
		{
			UpdateSelectedItem();
		}
		else if (property == ItemTemplateProperty)
		{
			UpdateItemTemplate();
		}
	}

	private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs args)
	{
		UpdateVisualStateForIsEnabledChange();
	}

	public UIElement ContainerFromIndex(int index)
	{
		return m_repeater?.TryGetElement(index);
	}

	private void UpdateItemsSource()
	{
		Select(-1);
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			if (repeater.ItemsSourceView != null)
			{
				repeater.ItemsSourceView.CollectionChanged -= OnRepeaterCollectionChanged;
			}
			repeater.ItemsSource = GetItemsSource();
			ItemsSourceView itemsSourceView = repeater.ItemsSourceView;
			if (itemsSourceView != null)
			{
				itemsSourceView.CollectionChanged += OnRepeaterCollectionChanged;
			}
		}
	}

	private object GetItemsSource()
	{
		object itemsSource = ItemsSource;
		if (itemsSource != null)
		{
			return itemsSource;
		}
		return Items;
	}

	private void UpdateSelectedIndex()
	{
		if (!m_currentlySelecting)
		{
			Select(SelectedIndex);
		}
	}

	private void UpdateSelectedItem()
	{
		if (m_currentlySelecting)
		{
			return;
		}
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			ItemsSourceView itemsSourceView = repeater.ItemsSourceView;
			if (itemsSourceView != null)
			{
				Select(itemsSourceView.IndexOf(SelectedItem));
			}
		}
	}

	private void UpdateItemTemplate()
	{
		m_radioButtonsElementFactory.UserElementFactory(ItemTemplate);
	}

	private void UpdateVisualStateForIsEnabledChange()
	{
		VisualStateManager.GoToState(this, base.IsEnabled ? "Normal" : "Disabled", useTransitions: false);
	}

	internal void SetTestHooksEnabled(bool enabled)
	{
		if (m_testHooksEnabled != enabled)
		{
			m_testHooksEnabled = enabled;
			if (enabled)
			{
				AttachToLayoutChanged();
			}
			else
			{
				DetatchFromLayoutChanged();
			}
		}
	}

	~RadioButtons()
	{
		ColumnMajorUniformToLargestGridLayout layout = GetLayout();
		if (layout != null)
		{
			layout.LayoutChanged -= OnLayoutChanged;
		}
	}

	private void OnLayoutChanged(ColumnMajorUniformToLargestGridLayout sender, object args)
	{
		RadioButtonsTestHooks.NotifyLayoutChanged(this);
	}

	internal int GetRows()
	{
		return GetLayout()?.GetRows() ?? (-1);
	}

	internal int GetColumns()
	{
		return GetLayout()?.GetColumns() ?? (-1);
	}

	internal int GetLargerColumns()
	{
		return GetLayout()?.GetLargerColumns() ?? (-1);
	}

	private void AttachToLayoutChanged()
	{
		ColumnMajorUniformToLargestGridLayout layout = GetLayout();
		if (layout != null)
		{
			layout.SetTestHooksEnabled(enabled: true);
			layout.LayoutChanged += OnLayoutChanged;
		}
	}

	private void DetatchFromLayoutChanged()
	{
		ColumnMajorUniformToLargestGridLayout layout = GetLayout();
		if (layout != null)
		{
			layout.SetTestHooksEnabled(enabled: false);
			layout.LayoutChanged -= OnLayoutChanged;
		}
	}

	private ColumnMajorUniformToLargestGridLayout GetLayout()
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			Layout layout = repeater.Layout;
			if (layout != null && layout is ColumnMajorUniformToLargestGridLayout result)
			{
				return result;
			}
		}
		return null;
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		RadioButtons radioButtons = (RadioButtons)sender;
		radioButtons.OnPropertyChanged(args);
	}
}

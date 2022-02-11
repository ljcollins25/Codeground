using System.Collections.Generic;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Items")]
public class MenuBarItem : Control
{
	private readonly SerialDisposable _registrations = new SerialDisposable();

	private MenuBar m_menuBar;

	private MenuBarItemFlyout m_flyout;

	private Button m_button;

	private bool m_isFlyoutOpen;

	private DependencyObject m_passThroughElement;

	private CompositeDisposable _activeDisposables;

	public string Title
	{
		get
		{
			return (string)GetValue(TitleProperty);
		}
		set
		{
			SetValue(TitleProperty, value);
		}
	}

	public IList<MenuFlyoutItemBase> Items => (IList<MenuFlyoutItemBase>)GetValue(ItemsProperty);

	public static DependencyProperty ItemsProperty { get; } = DependencyProperty.Register("Items", typeof(IList<MenuFlyoutItemBase>), typeof(MenuBarItem), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty TitleProperty { get; } = DependencyProperty.Register("Title", typeof(string), typeof(MenuBarItem), new FrameworkPropertyMetadata((object)null));


	public MenuBarItem()
	{
		base.DefaultStyleKey = typeof(MenuBarItem);
		ObservableVector<MenuFlyoutItemBase> observableVector = new ObservableVector<MenuFlyoutItemBase>();
		observableVector.VectorChanged += OnItemsVectorChanged;
		SetValue(ItemsProperty, observableVector);
		base.Loaded += MenuBarItem_Loaded;
	}

	private void MenuBarItem_Loaded(object sender, RoutedEventArgs e)
	{
		SynchronizeMenuBar();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new MenuBarItemAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		m_button = GetTemplateChild("ContentButton") as Button;
		PopulateContent();
		AttachEventHandlers();
		SynchronizeMenuBar();
	}

	private void SynchronizeMenuBar()
	{
		m_menuBar = SharedHelpers.GetAncestorOfType<MenuBar>(VisualTreeHelper.GetParent(this));
	}

	private void PopulateContent()
	{
		MenuBarItemFlyout menuBarItemFlyout = new MenuBarItemFlyout();
		foreach (MenuFlyoutItemBase item in Items)
		{
			menuBarItemFlyout.Items.Add(item);
		}
		menuBarItemFlyout.Placement = FlyoutPlacementMode.Bottom;
		if (m_passThroughElement != null)
		{
			menuBarItemFlyout.OverlayInputPassThroughElement = m_passThroughElement;
		}
		m_flyout = menuBarItemFlyout;
		if (m_button != null)
		{
			m_button.IsAccessKeyScope = true;
			m_button.ContextFlyout = menuBarItemFlyout;
		}
	}

	private void AttachEventHandlers()
	{
		_registrations.Disposable = null;
		_activeDisposables = new CompositeDisposable();
		if (m_button != null)
		{
			_activeDisposables.Add(m_button.RegisterDisposablePropertyChangedCallback(ButtonBase.IsPressedProperty, OnVisualPropertyChanged));
			_activeDisposables.Add(m_button.RegisterDisposablePropertyChangedCallback(ButtonBase.IsPointerOverProperty, OnVisualPropertyChanged));
		}
		if (m_flyout != null)
		{
			m_flyout.Closed += OnFlyoutClosed;
			m_flyout.Opening += OnFlyoutOpening;
			_activeDisposables.Add(delegate
			{
				m_flyout.Closed -= OnFlyoutClosed;
				m_flyout.Opening -= OnFlyoutOpening;
			});
		}
		base.PointerEntered += OnMenuBarItemPointerEntered;
		_activeDisposables.Add(delegate
		{
			base.PointerEntered -= OnMenuBarItemPointerEntered;
		});
		PointerEventHandler pointerPressHandler = OnMenuBarItemPointerPressed;
		AddHandler(UIElement.PointerPressedEvent, pointerPressHandler, handledEventsToo: true);
		KeyEventHandler keyDownHandler = OnMenuBarItemKeyDown;
		AddHandler(UIElement.KeyDownEvent, keyDownHandler, handledEventsToo: true);
		_activeDisposables.Add(delegate
		{
			RemoveHandler(UIElement.PointerPressedEvent, pointerPressHandler);
			RemoveHandler(UIElement.KeyDownEvent, keyDownHandler);
		});
		base.AccessKeyInvoked += OnMenuBarItemAccessKeyInvoked;
		_activeDisposables.Add(delegate
		{
			base.AccessKeyInvoked -= OnMenuBarItemAccessKeyInvoked;
		});
		_registrations.Disposable = _activeDisposables;
	}

	private void OnMenuBarItemPointerEntered(object sender, PointerRoutedEventArgs args)
	{
		if (m_menuBar != null && m_menuBar.IsFlyoutOpen)
		{
			ShowMenuFlyout();
		}
	}

	private void OnMenuBarItemPointerPressed(object sender, PointerRoutedEventArgs args)
	{
		if (m_menuBar != null && !m_menuBar.IsFlyoutOpen)
		{
			ShowMenuFlyout();
		}
	}

	private void OnMenuBarItemKeyDown(object sender, KeyRoutedEventArgs args)
	{
		VirtualKey key = args.Key;
		if (key == VirtualKey.Down || key == VirtualKey.Enter || key == VirtualKey.Space)
		{
			ShowMenuFlyout();
		}
	}

	private void OnPresenterKeyDown(object sender, KeyRoutedEventArgs args)
	{
		switch (args.Key)
		{
		case VirtualKey.Right:
			if (base.FlowDirection == FlowDirection.RightToLeft)
			{
				OpenFlyoutFrom(FlyoutLocation.Left);
			}
			else
			{
				OpenFlyoutFrom(FlyoutLocation.Right);
			}
			break;
		case VirtualKey.Left:
			if (base.FlowDirection == FlowDirection.RightToLeft)
			{
				OpenFlyoutFrom(FlyoutLocation.Right);
			}
			else
			{
				OpenFlyoutFrom(FlyoutLocation.Left);
			}
			break;
		}
	}

	private void OnItemsVectorChanged(IObservableVector<MenuFlyoutItemBase> sender, IVectorChangedEventArgs e)
	{
		if (m_flyout != null)
		{
			uint index = e.Index;
			switch (e.CollectionChange)
			{
			case CollectionChange.ItemInserted:
				m_flyout.Items.Insert((int)index, (MenuFlyoutItem)Items[(int)index]);
				break;
			case CollectionChange.ItemRemoved:
				m_flyout.Items.RemoveAt((int)index);
				break;
			}
		}
	}

	private void OnMenuBarItemAccessKeyInvoked(DependencyObject sender, AccessKeyInvokedEventArgs args)
	{
		ShowMenuFlyout();
		args.Handled = true;
	}

	internal void ShowMenuFlyout()
	{
		if (m_button == null)
		{
			return;
		}
		double actualWidth = m_button.ActualWidth;
		double actualHeight = m_button.ActualHeight;
		if (SharedHelpers.IsFlyoutShowOptionsAvailable())
		{
			FlyoutShowOptions flyoutShowOptions = new FlyoutShowOptions();
			flyoutShowOptions.Position = new Point(0.0, actualHeight);
			flyoutShowOptions.Placement = FlyoutPlacementMode.Bottom;
			flyoutShowOptions.ExclusionRect = new Rect(0.0, 0.0, actualWidth, actualHeight);
			m_flyout.ShowAt(m_button, flyoutShowOptions);
		}
		else
		{
			m_flyout.ShowAt(m_button, new Point(0.0, actualHeight));
		}
		if (m_flyout?.m_presenter != null)
		{
			m_flyout.m_presenter.KeyDown += OnPresenterKeyDown;
			_activeDisposables.Add(delegate
			{
				m_flyout.m_presenter.KeyDown -= OnPresenterKeyDown;
			});
		}
	}

	internal void CloseMenuFlyout()
	{
		m_flyout.Hide();
	}

	private void OpenFlyoutFrom(FlyoutLocation location)
	{
		if (m_menuBar != null)
		{
			int num = m_menuBar.Items.IndexOf(this);
			CloseMenuFlyout();
			if (location == FlyoutLocation.Left)
			{
				m_menuBar.Items[(num - 1 + m_menuBar.Items.Count) % m_menuBar.Items.Count].ShowMenuFlyout();
			}
			else
			{
				m_menuBar.Items[(num + 1) % m_menuBar.Items.Count].ShowMenuFlyout();
			}
		}
	}

	private void AddPassThroughElement(DependencyObject element)
	{
		m_passThroughElement = element;
	}

	public bool IsFlyoutOpen()
	{
		return m_isFlyoutOpen;
	}

	public void Invoke()
	{
		if (IsFlyoutOpen())
		{
			CloseMenuFlyout();
		}
		else
		{
			ShowMenuFlyout();
		}
	}

	private void OnFlyoutClosed(object sender, object args)
	{
		m_isFlyoutOpen = false;
		if (m_menuBar != null)
		{
			m_menuBar.IsFlyoutOpen = false;
		}
		UpdateVisualStates();
	}

	private void OnFlyoutOpening(object sender, object args)
	{
		Focus(FocusState.Pointer);
		m_isFlyoutOpen = true;
		if (m_menuBar != null)
		{
			m_menuBar.IsFlyoutOpen = true;
		}
		UpdateVisualStates();
	}

	private void OnVisualPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		UpdateVisualStates();
	}

	private void UpdateVisualStates()
	{
		if (m_button != null)
		{
			if (m_isFlyoutOpen)
			{
				VisualStateManager.GoToState(this, "Selected", useTransitions: false);
			}
			else if (m_button.IsPressed)
			{
				VisualStateManager.GoToState(this, "Pressed", useTransitions: false);
			}
			else if (m_button.IsPointerOver)
			{
				VisualStateManager.GoToState(this, "PointerOver", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "Normal", useTransitions: false);
			}
		}
	}
}

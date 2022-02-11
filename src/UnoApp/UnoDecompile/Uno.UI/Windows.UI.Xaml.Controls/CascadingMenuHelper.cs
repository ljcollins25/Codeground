using System;
using System.Collections.Generic;
using Uno.Disposables;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

internal class CascadingMenuHelper
{
	private const int m_subMenuOverlapPixels = 4;

	private int m_subMenuShowDelay;

	private WeakReference m_wpOwner;

	private WeakReference m_wpSubMenuPresenter;

	private IDisposable m_loadedHandler;

	private DispatcherTimer m_delayOpenMenuTimer;

	private DispatcherTimer m_delayCloseMenuTimer;

	private bool m_isPointerOver = true;

	private bool m_isPressed = true;

	private const int DefaultMenuShowDelay = 400;

	private Point? _lastTargetPoint;

	internal bool IsPressed => m_isPressed;

	internal bool IsPointerOver => m_isPointerOver;

	public CascadingMenuHelper()
	{
		m_isPointerOver = false;
		m_isPressed = false;
		m_subMenuShowDelay = -1;
	}

	~CascadingMenuHelper()
	{
		m_delayOpenMenuTimer?.Stop();
		m_delayCloseMenuTimer?.Stop();
	}

	internal void Initialize(FrameworkElement owner)
	{
		FrameworkElement frameworkElement = owner;
		m_wpOwner = new WeakReference(frameworkElement);
		owner.Loaded += OnLoadedClearFlags;
		m_loadedHandler = Disposable.Create(delegate
		{
			owner.Loaded -= OnLoadedClearFlags;
		});
		if (m_subMenuShowDelay < 0)
		{
			m_subMenuShowDelay = 400;
		}
		frameworkElement.IsAccessKeyScope = true;
		void OnLoadedClearFlags(object pSender, RoutedEventArgs args)
		{
			ClearStateFlags();
		}
	}

	internal void OnApplyTemplate()
	{
		UpdateOwnerVisualState();
	}

	internal void OnPointerEntered(PointerRoutedEventArgs args)
	{
		bool flag = false;
		m_isPointerOver = true;
		if (!args.Handled)
		{
			if (m_wpOwner?.Target is ISubMenuOwner subMenuOwner)
			{
				subMenuOwner.ParentOwner?.CancelCloseSubMenu();
			}
			Pointer pointer = args.Pointer;
			if (pointer.PointerDeviceType != 0)
			{
				CancelCloseSubMenu();
				EnsureDelayOpenMenuTimer();
				m_delayOpenMenuTimer.Start();
				UpdateOwnerVisualState();
			}
			args.Handled = true;
		}
	}

	internal void OnPointerExited(PointerRoutedEventArgs args, bool parentIsSubMenu)
	{
		bool flag = false;
		m_isPointerOver = false;
		m_isPressed = false;
		flag = args.Handled;
		if (m_delayOpenMenuTimer != null)
		{
			m_delayOpenMenuTimer.Stop();
		}
		FrameworkElement frameworkElement = m_wpOwner?.Target as FrameworkElement;
		if (flag || frameworkElement == null || !frameworkElement.IsLoaded)
		{
			return;
		}
		Pointer pointer = args.Pointer;
		PointerDeviceType pointerDeviceType = pointer.PointerDeviceType;
		if (PointerDeviceType.Mouse == pointerDeviceType && !parentIsSubMenu && m_wpSubMenuPresenter?.Target is UIElement uIElement)
		{
			bool flag2 = false;
			PointerPoint currentPoint = args.GetCurrentPoint(null);
			Point position = currentPoint.Position;
			IEnumerable<UIElement> enumerable = VisualTreeHelper.FindElementsInHostCoordinates(position, frameworkElement, includeAllElements: true);
			foreach (UIElement item in enumerable)
			{
				if (frameworkElement == item || uIElement == item)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				enumerable = VisualTreeHelper.FindElementsInHostCoordinates(position, uIElement, includeAllElements: true);
				foreach (UIElement item2 in enumerable)
				{
					if (frameworkElement == item2 || uIElement == item2)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				DelayCloseSubMenu();
				args.Handled = true;
			}
		}
		UpdateOwnerVisualState();
	}

	internal void OnPointerPressed(PointerRoutedEventArgs args)
	{
		m_isPressed = true;
		args.Handled = true;
	}

	internal void OnPointerReleased(PointerRoutedEventArgs args)
	{
		m_isPressed = false;
		Pointer pointer = args.Pointer;
		if (pointer.PointerDeviceType == PointerDeviceType.Touch)
		{
			OpenSubMenu();
		}
		args.Handled = true;
	}

	internal void OnGotFocus(RoutedEventArgs args)
	{
		UpdateOwnerVisualState();
	}

	internal void OnLostFocus(RoutedEventArgs args)
	{
		m_isPressed = false;
		UpdateOwnerVisualState();
	}

	internal void OnKeyDown(KeyRoutedEventArgs args)
	{
		bool flag = false;
		if (!args.Handled)
		{
			VirtualKey key = args.Key;
			if (key == VirtualKey.Enter || key == VirtualKey.Right || key == VirtualKey.Space)
			{
				OpenSubMenu();
				args.Handled = true;
			}
		}
	}

	internal void OnKeyUp(KeyRoutedEventArgs args)
	{
		UpdateOwnerVisualState();
		args.Handled = true;
	}

	private void EnsureDelayOpenMenuTimer()
	{
		if (m_delayOpenMenuTimer == null)
		{
			m_delayOpenMenuTimer = new DispatcherTimer();
			m_delayOpenMenuTimer.Tick += delegate
			{
				DelayOpenMenuTimerTickHandler();
			};
			TimeSpan interval = TimeSpan.FromMilliseconds(m_subMenuShowDelay);
			m_delayOpenMenuTimer.Interval = interval;
		}
	}

	private void DelayOpenMenuTimerTickHandler()
	{
		EnsureCloseExistingSubItems();
		OpenSubMenu();
		if (m_delayOpenMenuTimer != null)
		{
			m_delayOpenMenuTimer.Stop();
		}
	}

	private void EnsureDelayCloseMenuTimer()
	{
		if (m_delayCloseMenuTimer == null)
		{
			m_delayCloseMenuTimer = new DispatcherTimer();
			m_delayCloseMenuTimer.Tick += delegate
			{
				DelayCloseMenuTimerTickHandler();
			};
			TimeSpan interval = TimeSpan.FromMilliseconds(m_subMenuShowDelay);
			m_delayCloseMenuTimer.Interval = interval;
		}
	}

	private void DelayCloseMenuTimerTickHandler()
	{
		CloseSubMenu();
		if (m_delayCloseMenuTimer != null)
		{
			m_delayCloseMenuTimer.Stop();
		}
	}

	private void EnsureCloseExistingSubItems()
	{
		if (m_wpOwner?.Target is ISubMenuOwner subMenuOwner)
		{
			subMenuOwner.ClosePeerSubMenus();
		}
	}

	internal void SetSubMenuPresenter(FrameworkElement subMenuPresenter)
	{
		m_wpSubMenuPresenter = new WeakReference(subMenuPresenter);
		if (m_wpOwner?.Target is ISubMenuOwner owner && subMenuPresenter is IMenuPresenter menuPresenter)
		{
			menuPresenter.Owner = owner;
		}
	}

	internal void OpenSubMenu()
	{
		if (!(m_wpOwner?.Target is ISubMenuOwner subMenuOwner))
		{
			return;
		}
		subMenuOwner.PrepareSubMenu();
		bool flag = false;
		if (!subMenuOwner.IsSubMenuOpen && m_wpOwner?.Target is Control control)
		{
			EnsureCloseExistingSubItems();
			double num = 0.0;
			num = control.ActualWidth;
			FlowDirection flowDirection = FlowDirection.LeftToRight;
			flowDirection = control.FlowDirection;
			Point point = new Point(0.0, 0.0);
			bool flag2 = false;
			if (subMenuOwner.IsSubMenuPositionedAbsolutely)
			{
				GeneralTransform generalTransform = control.TransformToVisual(null);
				point = generalTransform.TransformPoint(point);
			}
			if (flowDirection == FlowDirection.RightToLeft)
			{
				point.X += (float)(4.0 - num);
			}
			else
			{
				point.X += (float)(num - 4.0);
			}
			subMenuOwner.OpenSubMenu(point);
			Point? lastTargetPoint = _lastTargetPoint;
			if (lastTargetPoint.HasValue)
			{
				Point valueOrDefault = lastTargetPoint.GetValueOrDefault();
				subMenuOwner.PositionSubMenu(valueOrDefault);
			}
			subMenuOwner.RaiseAutomationPeerExpandCollapse(isOpen: true);
			ElementSoundPlayer.RequestInteractionSoundForElement(ElementSoundKind.Invoke, control);
		}
	}

	internal void CloseSubMenu()
	{
		CloseChildSubMenus();
		if (m_wpOwner?.Target is ISubMenuOwner subMenuOwner)
		{
			subMenuOwner.CloseSubMenu();
			subMenuOwner.RaiseAutomationPeerExpandCollapse(isOpen: false);
			if (subMenuOwner is DependencyObject element)
			{
				ElementSoundPlayer.RequestInteractionSoundForElement(ElementSoundKind.Hide, element);
			}
		}
	}

	internal void CloseChildSubMenus()
	{
		FrameworkElement frameworkElement = m_wpSubMenuPresenter?.Target as Frame;
		IMenuPresenter menuPresenter = null;
		if (frameworkElement != null)
		{
			menuPresenter = frameworkElement as IMenuPresenter;
		}
		menuPresenter?.CloseSubMenu();
	}

	internal void DelayCloseSubMenu()
	{
		EnsureDelayCloseMenuTimer();
		if (m_delayCloseMenuTimer != null)
		{
			m_delayCloseMenuTimer.Start();
		}
	}

	internal void CancelCloseSubMenu()
	{
		if (m_delayCloseMenuTimer != null)
		{
			m_delayCloseMenuTimer.Stop();
		}
	}

	internal void ClearStateFlags()
	{
		m_isPressed = false;
		m_isPointerOver = false;
		UpdateOwnerVisualState();
	}

	internal void OnIsEnabledChanged()
	{
		if (m_wpOwner?.Target is Control control)
		{
			bool flag = false;
			if (!control.IsEnabled)
			{
				ClearStateFlags();
			}
			else
			{
				control.UpdateVisualState();
			}
		}
	}

	public void OnVisibilityChanged()
	{
		if (m_wpOwner?.Target is UIElement uIElement && uIElement.Visibility != 0)
		{
			ClearStateFlags();
		}
	}

	internal void OnPresenterSizeChanged(object pSender, SizeChangedEventArgs args, Popup popup)
	{
		Control control = m_wpOwner?.Target as Control;
		ISubMenuOwner subMenuOwner = m_wpOwner?.Target as ISubMenuOwner;
		Control control2 = m_wpSubMenuPresenter?.Target as Control;
		if (control == null || subMenuOwner == null || control2 == null)
		{
			return;
		}
		Size newSize = args.NewSize;
		FlowDirection flowDirection = control.FlowDirection;
		Point point = new Point(double.NegativeInfinity, double.NegativeInfinity);
		bool flag = false;
		flag = subMenuOwner.IsSubMenuPositionedAbsolutely;
		Point point2 = new Point(0.0, 0.0);
		if (flag)
		{
			GeneralTransform generalTransform = control.TransformToVisual(null);
			point2 = generalTransform.TransformPoint(point2);
		}
		double num = 0.0;
		double num2 = 0.0;
		num = control.ActualWidth;
		num2 = control.ActualHeight;
		double maxWidth = control2.MaxWidth;
		double maxHeight = control2.MaxHeight;
		Rect rect = FlyoutBase.CalculateAvailableWindowRect(isMenuFlyout: true, popup, null, hasTargetPosition: true, point2, isFull: false);
		control2.MaxWidth = (double.IsNaN(maxWidth) ? rect.Width : Math.Min(maxWidth, rect.Width));
		control2.MaxHeight = (double.IsNaN(maxHeight) ? rect.Height : Math.Min(maxHeight, rect.Height));
		double num3 = rect.Height - point2.Y;
		if (flowDirection == FlowDirection.LeftToRight)
		{
			double num4 = rect.Width - (point2.X + num);
			if (newSize.Width > num4)
			{
				if (newSize.Width < point2.X)
				{
					point.X = (float)(point2.X - newSize.Width + 4.0);
				}
				else
				{
					point.X = (float)(rect.Width - newSize.Width);
				}
			}
		}
		else
		{
			double num5 = point2.X - rect.X - num;
			if (newSize.Width > num5)
			{
				if (newSize.Width < rect.Width + rect.X - point2.X)
				{
					point.X = (float)(point2.X + num - 4.0);
				}
				else
				{
					point.X = (float)num;
				}
			}
			else
			{
				point.X = (float)(point2.X - num + 4.0);
			}
		}
		if (newSize.Height > num3)
		{
			if (point2.Y + num2 > newSize.Height)
			{
				point.Y = (float)(point2.Y + num2 - newSize.Height);
			}
			else
			{
				point.Y = (float)(point2.Y - Math.Min(newSize.Height - num3, rect.Height - num3));
			}
		}
		_lastTargetPoint = point;
		subMenuOwner.PositionSubMenu(point);
	}

	private void UpdateOwnerVisualState()
	{
		if (m_wpOwner?.Target is Control control)
		{
			control.UpdateVisualState();
		}
	}
}

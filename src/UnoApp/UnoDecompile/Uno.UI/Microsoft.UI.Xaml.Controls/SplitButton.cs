using System.Windows.Input;
using Microsoft.UI.Private.Controls;
using Microsoft.UI.Xaml.Automation.Peers;
using Uno.UI.Helpers.WinUI;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Microsoft.UI.Xaml.Controls;

public class SplitButton : ContentControl
{
	private bool m_isKeyDown;

	private bool m_isFlyoutOpen;

	private PointerDeviceType m_lastPointerDeviceType = PointerDeviceType.Mouse;

	private Button m_primaryButton;

	private Button m_secondaryButton;

	private long m_flyoutPlacementChangedRevoker;

	private long m_pressedPrimaryRevoker;

	private long m_pointerOverPrimaryRevoker;

	private long m_pressedSecondaryRevoker;

	private long m_pointerOverSecondaryRevoker;

	internal bool m_hasLoaded;

	internal bool IsFlyoutOpen => m_isFlyoutOpen;

	public ICommand Command
	{
		get
		{
			return (ICommand)GetValue(CommandProperty);
		}
		set
		{
			SetValue(CommandProperty, value);
		}
	}

	public object CommandParameter
	{
		get
		{
			return GetValue(CommandParameterProperty);
		}
		set
		{
			SetValue(CommandParameterProperty, value);
		}
	}

	public FlyoutBase Flyout
	{
		get
		{
			return (FlyoutBase)GetValue(FlyoutProperty);
		}
		set
		{
			SetValue(FlyoutProperty, value);
		}
	}

	public static DependencyProperty CommandProperty { get; } = DependencyProperty.Register("Command", typeof(ICommand), typeof(SplitButton), new FrameworkPropertyMetadata(null, OnCommandChanged));


	public static DependencyProperty CommandParameterProperty { get; } = DependencyProperty.Register("CommandParameter", typeof(object), typeof(SplitButton), new FrameworkPropertyMetadata(null, OnCommandParameterChanged));


	public static DependencyProperty FlyoutProperty { get; } = DependencyProperty.Register("Flyout", typeof(FlyoutBase), typeof(SplitButton), new FrameworkPropertyMetadata(null, OnFlyoutChanged));


	public event TypedEventHandler<SplitButton, SplitButtonClickEventArgs> Click;

	public SplitButton()
	{
		base.DefaultStyleKey = typeof(SplitButton);
		base.KeyDown += OnSplitButtonKeyDown;
		base.KeyUp += OnSplitButtonKeyUp;
	}

	protected override void OnApplyTemplate()
	{
		UnregisterEvents();
		m_primaryButton = GetTemplateChild("PrimaryButton") as Button;
		m_secondaryButton = GetTemplateChild("SecondaryButton") as Button;
		Button primaryButton = m_primaryButton;
		if (primaryButton != null)
		{
			primaryButton.Click += OnClickPrimary;
			m_pressedPrimaryRevoker = primaryButton.RegisterPropertyChangedCallback(ButtonBase.IsPressedProperty, OnVisualPropertyChanged);
			m_pointerOverPrimaryRevoker = primaryButton.RegisterPropertyChangedCallback(ButtonBase.IsPointerOverProperty, OnVisualPropertyChanged);
			primaryButton.PointerEntered += OnPointerEvent;
			primaryButton.PointerExited += OnPointerEvent;
			primaryButton.PointerPressed += OnPointerEvent;
			primaryButton.PointerReleased += OnPointerEvent;
			primaryButton.PointerCanceled += OnPointerEvent;
			primaryButton.PointerCaptureLost += OnPointerEvent;
		}
		Button secondaryButton = m_secondaryButton;
		if (secondaryButton != null)
		{
			string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("SplitButtonSecondaryButtonName");
			AutomationProperties.SetName(secondaryButton, localizedStringResource);
			secondaryButton.Click += OnClickSecondary;
			m_pressedSecondaryRevoker = secondaryButton.RegisterPropertyChangedCallback(ButtonBase.IsPressedProperty, OnVisualPropertyChanged);
			m_pointerOverSecondaryRevoker = secondaryButton.RegisterPropertyChangedCallback(ButtonBase.IsPointerOverProperty, OnVisualPropertyChanged);
			secondaryButton.PointerEntered += OnPointerEvent;
			secondaryButton.PointerExited += OnPointerEvent;
			secondaryButton.PointerPressed += OnPointerEvent;
			secondaryButton.PointerReleased += OnPointerEvent;
			secondaryButton.PointerCanceled += OnPointerEvent;
			secondaryButton.PointerCaptureLost += OnPointerEvent;
		}
		RegisterFlyoutEvents();
		UpdateVisualStates();
		m_hasLoaded = true;
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == FlyoutProperty)
		{
			if (args.OldValue is Flyout flyout)
			{
				flyout.Opened -= OnFlyoutOpened;
				flyout.Closed -= OnFlyoutClosed;
				flyout.UnregisterPropertyChangedCallback(FlyoutBase.PlacementProperty, m_flyoutPlacementChangedRevoker);
			}
			OnFlyoutChanged();
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new Microsoft.UI.Xaml.Automation.Peers.SplitButtonAutomationPeer(this);
	}

	private void OnFlyoutChanged()
	{
		RegisterFlyoutEvents();
		UpdateVisualStates();
	}

	private void RegisterFlyoutEvents()
	{
		if (Flyout != null)
		{
			Flyout.Opened += OnFlyoutOpened;
			Flyout.Closed += OnFlyoutClosed;
			m_flyoutPlacementChangedRevoker = Flyout.RegisterPropertyChangedCallback(FlyoutBase.PlacementProperty, OnFlyoutPlacementChanged);
		}
	}

	private void OnVisualPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		UpdateVisualStates();
	}

	internal virtual bool InternalIsChecked()
	{
		return false;
	}

	internal void UpdateVisualStates(bool useTransitions = true)
	{
		if (m_lastPointerDeviceType == PointerDeviceType.Touch || m_isKeyDown)
		{
			VisualStateManager.GoToState(this, "SecondaryButtonSpan", useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "SecondaryButtonRight", useTransitions);
		}
		Button primaryButton = m_primaryButton;
		Button secondaryButton = m_secondaryButton;
		if (primaryButton == null || secondaryButton == null)
		{
			return;
		}
		if (m_isFlyoutOpen)
		{
			VisualStateManager.GoToState(this, "FlyoutOpen", useTransitions);
		}
		else if (InternalIsChecked())
		{
			if (m_lastPointerDeviceType == PointerDeviceType.Touch || m_isKeyDown)
			{
				if (primaryButton.IsPressed || secondaryButton.IsPressed || m_isKeyDown)
				{
					VisualStateManager.GoToState(this, "CheckedTouchPressed", useTransitions);
				}
				else
				{
					VisualStateManager.GoToState(this, "Checked", useTransitions);
				}
			}
			else if (primaryButton.IsPressed)
			{
				VisualStateManager.GoToState(this, "CheckedPrimaryPressed", useTransitions);
			}
			else if (primaryButton.IsPointerOver)
			{
				VisualStateManager.GoToState(this, "CheckedPrimaryPointerOver", useTransitions);
			}
			else if (secondaryButton.IsPressed)
			{
				VisualStateManager.GoToState(this, "CheckedSecondaryPressed", useTransitions);
			}
			else if (secondaryButton.IsPointerOver)
			{
				VisualStateManager.GoToState(this, "CheckedSecondaryPointerOver", useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, "Checked", useTransitions);
			}
		}
		else if (m_lastPointerDeviceType == PointerDeviceType.Touch || m_isKeyDown)
		{
			if (primaryButton.IsPressed || secondaryButton.IsPressed || m_isKeyDown)
			{
				VisualStateManager.GoToState(this, "TouchPressed", useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, "Normal", useTransitions);
			}
		}
		else if (primaryButton.IsPressed)
		{
			VisualStateManager.GoToState(this, "PrimaryPressed", useTransitions);
		}
		else if (primaryButton.IsPointerOver)
		{
			VisualStateManager.GoToState(this, "PrimaryPointerOver", useTransitions);
		}
		else if (secondaryButton.IsPressed)
		{
			VisualStateManager.GoToState(this, "SecondaryPressed", useTransitions);
		}
		else if (secondaryButton.IsPointerOver)
		{
			VisualStateManager.GoToState(this, "SecondaryPointerOver", useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "Normal", useTransitions);
		}
	}

	internal void OpenFlyout()
	{
		FlyoutBase flyout = Flyout;
		if (flyout != null)
		{
			if (SharedHelpers.IsFlyoutShowOptionsAvailable())
			{
				FlyoutShowOptions flyoutShowOptions = new FlyoutShowOptions();
				flyoutShowOptions.Placement = FlyoutPlacementMode.BottomEdgeAlignedLeft;
				flyout.ShowAt(this, flyoutShowOptions);
			}
			else
			{
				flyout.ShowAt(this);
			}
		}
	}

	internal void CloseFlyout()
	{
		Flyout?.Hide();
	}

	private void OnFlyoutOpened(object sender, object args)
	{
		m_isFlyoutOpen = true;
		UpdateVisualStates();
		SharedHelpers.RaiseAutomationPropertyChangedEvent(this, ExpandCollapseState.Collapsed, ExpandCollapseState.Expanded);
	}

	private void OnFlyoutClosed(object sender, object args)
	{
		m_isFlyoutOpen = false;
		UpdateVisualStates();
		SharedHelpers.RaiseAutomationPropertyChangedEvent(this, ExpandCollapseState.Expanded, ExpandCollapseState.Collapsed);
	}

	private void OnFlyoutPlacementChanged(DependencyObject sender, DependencyProperty dp)
	{
		UpdateVisualStates();
	}

	internal virtual void OnClickPrimary(object sender, RoutedEventArgs args)
	{
		SplitButtonClickEventArgs args2 = new SplitButtonClickEventArgs();
		this.Click?.Invoke(this, args2);
		FrameworkElementAutomationPeer.FromElement(this)?.RaiseAutomationEvent(AutomationEvents.InvokePatternOnInvoked);
	}

	private void OnClickSecondary(object sender, RoutedEventArgs args)
	{
		OpenFlyout();
	}

	private void OnPointerEvent(object sender, PointerRoutedEventArgs args)
	{
		PointerDeviceType pointerDeviceType = args.Pointer.PointerDeviceType;
		if (SplitButtonTestHelper.SimulateTouch)
		{
			pointerDeviceType = PointerDeviceType.Touch;
		}
		if (m_lastPointerDeviceType != pointerDeviceType)
		{
			m_lastPointerDeviceType = pointerDeviceType;
			UpdateVisualStates();
		}
	}

	private void OnSplitButtonKeyDown(object sender, KeyRoutedEventArgs args)
	{
		VirtualKey key = args.Key;
		if (key == VirtualKey.Space || key == VirtualKey.Enter || key == VirtualKey.GamepadA)
		{
			m_isKeyDown = true;
			UpdateVisualStates();
		}
	}

	private void OnSplitButtonKeyUp(object sender, KeyRoutedEventArgs args)
	{
		switch (args.Key)
		{
		case VirtualKey.Enter:
		case VirtualKey.Space:
		case VirtualKey.GamepadA:
			m_isKeyDown = false;
			UpdateVisualStates();
			if (base.IsEnabled)
			{
				OnClickPrimary(null, null);
				args.Handled = true;
			}
			break;
		case VirtualKey.Down:
		{
			CoreVirtualKeyStates keyState = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Menu);
			bool flag = (keyState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
			if (base.IsEnabled && flag)
			{
				OpenFlyout();
				args.Handled = true;
			}
			break;
		}
		case VirtualKey.F4:
			if (base.IsEnabled)
			{
				OpenFlyout();
				args.Handled = true;
			}
			break;
		}
	}

	private void UnregisterEvents()
	{
		if (m_primaryButton != null)
		{
			m_primaryButton.Click -= OnClickPrimary;
			m_primaryButton.UnregisterPropertyChangedCallback(ButtonBase.IsPressedProperty, m_pressedPrimaryRevoker);
			m_primaryButton.UnregisterPropertyChangedCallback(ButtonBase.IsPointerOverProperty, m_pointerOverPrimaryRevoker);
			m_primaryButton.PointerEntered -= OnPointerEvent;
			m_primaryButton.PointerExited -= OnPointerEvent;
			m_primaryButton.PointerPressed -= OnPointerEvent;
			m_primaryButton.PointerReleased -= OnPointerEvent;
			m_primaryButton.PointerCanceled -= OnPointerEvent;
			m_primaryButton.PointerCaptureLost -= OnPointerEvent;
		}
		if (m_secondaryButton != null)
		{
			m_secondaryButton.Click -= OnClickSecondary;
			m_secondaryButton.UnregisterPropertyChangedCallback(ButtonBase.IsPressedProperty, m_pressedSecondaryRevoker);
			m_secondaryButton.UnregisterPropertyChangedCallback(ButtonBase.IsPointerOverProperty, m_pointerOverSecondaryRevoker);
			m_secondaryButton.PointerEntered -= OnPointerEvent;
			m_secondaryButton.PointerExited -= OnPointerEvent;
			m_secondaryButton.PointerPressed -= OnPointerEvent;
			m_secondaryButton.PointerReleased -= OnPointerEvent;
			m_secondaryButton.PointerCanceled -= OnPointerEvent;
			m_secondaryButton.PointerCaptureLost -= OnPointerEvent;
		}
	}

	private static void OnCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SplitButton splitButton = (SplitButton)sender;
		splitButton.OnPropertyChanged(args);
	}

	private static void OnCommandParameterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SplitButton splitButton = (SplitButton)sender;
		splitButton.OnPropertyChanged(args);
	}

	private static void OnFlyoutChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SplitButton splitButton = (SplitButton)sender;
		splitButton.OnPropertyChanged(args);
	}
}

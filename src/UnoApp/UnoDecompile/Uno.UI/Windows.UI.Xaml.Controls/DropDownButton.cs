using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;

namespace Windows.UI.Xaml.Controls;

public class DropDownButton : Button
{
	private bool m_isFlyoutOpen;

	public DropDownButton()
	{
		base.DefaultStyleKey = typeof(DropDownButton);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new DropDownButtonAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		this.RegisterDisposablePropertyChangedCallback(Button.FlyoutProperty, OnFlyoutPropertyChanged);
		RegisterFlyoutEvents();
	}

	private void RegisterFlyoutEvents()
	{
		if (base.Flyout != null)
		{
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
		}
	}

	internal bool IsFlyoutOpen()
	{
		return m_isFlyoutOpen;
	}

	internal void OpenFlyout()
	{
		base.Flyout?.ShowAt(this);
	}

	internal void CloseFlyout()
	{
		base.Flyout?.Hide();
	}

	private void OnFlyoutPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue is Flyout flyout)
		{
			flyout.Opened -= OnFlyoutOpened;
			flyout.Closed -= OnFlyoutClosed;
		}
		RegisterFlyoutEvents();
	}

	private void OnFlyoutOpened(object sender, object args)
	{
		m_isFlyoutOpen = true;
		SharedHelpers.RaiseAutomationPropertyChangedEvent(this, ExpandCollapseState.Collapsed, ExpandCollapseState.Expanded);
	}

	private void OnFlyoutClosed(object sender, object args)
	{
		m_isFlyoutOpen = false;
		SharedHelpers.RaiseAutomationPropertyChangedEvent(this, ExpandCollapseState.Expanded, ExpandCollapseState.Collapsed);
	}
}

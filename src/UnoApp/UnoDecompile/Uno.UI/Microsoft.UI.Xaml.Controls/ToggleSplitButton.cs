using Microsoft.UI.Xaml.Automation.Peers;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;

namespace Microsoft.UI.Xaml.Controls;

public class ToggleSplitButton : SplitButton
{
	public bool IsChecked
	{
		get
		{
			return (bool)GetValue(IsCheckedProperty);
		}
		set
		{
			SetValue(IsCheckedProperty, value);
		}
	}

	public static DependencyProperty IsCheckedProperty { get; } = DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToggleSplitButton), new FrameworkPropertyMetadata(false, OnIsCheckedPropertyChanged));


	public event TypedEventHandler<ToggleSplitButton, ToggleSplitButtonIsCheckedChangedEventArgs> IsCheckedChanged;

	public ToggleSplitButton()
	{
		base.DefaultStyleKey = typeof(ToggleSplitButton);
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == IsCheckedProperty)
		{
			OnIsCheckedChanged();
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ToggleSplitButtonAutomationPeer(this);
	}

	private void OnIsCheckedChanged()
	{
		if (m_hasLoaded)
		{
			ToggleSplitButtonIsCheckedChangedEventArgs args = new ToggleSplitButtonIsCheckedChangedEventArgs();
			this.IsCheckedChanged?.Invoke(this, args);
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
			if (automationPeer != null)
			{
				ToggleState toggleState = (IsChecked ? ToggleState.On : ToggleState.Off);
				ToggleState toggleState2 = ((toggleState != ToggleState.On) ? ToggleState.On : ToggleState.Off);
				automationPeer.RaisePropertyChangedEvent(TogglePatternIdentifiers.ToggleStateProperty, toggleState2, toggleState);
			}
		}
		UpdateVisualStates();
	}

	internal override void OnClickPrimary(object sender, RoutedEventArgs args)
	{
		Toggle();
		base.OnClickPrimary(sender, args);
	}

	internal override bool InternalIsChecked()
	{
		return IsChecked;
	}

	internal void Toggle()
	{
		IsChecked = !IsChecked;
	}

	private static void OnIsCheckedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		ToggleSplitButton toggleSplitButton = (ToggleSplitButton)sender;
		toggleSplitButton.OnPropertyChanged(args);
	}
}

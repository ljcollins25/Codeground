using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class Button : ButtonBase
{
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

	public static DependencyProperty FlyoutProperty { get; }

	static Button()
	{
		FlyoutProperty = DependencyProperty.Register("Flyout", typeof(FlyoutBase), typeof(Button), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.LogicalChild));
		Control.HorizontalContentAlignmentProperty.OverrideMetadata(typeof(Button), new FrameworkPropertyMetadata(HorizontalAlignment.Center));
		Control.VerticalContentAlignmentProperty.OverrideMetadata(typeof(Button), new FrameworkPropertyMetadata(VerticalAlignment.Center));
	}

	public Button()
	{
		base.DefaultStyleKey = typeof(Button);
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		Flyout?.Close();
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		if (!base.IsEnabled)
		{
			GoToState(useTransitions, "Disabled");
		}
		else if (base.IsPressed)
		{
			GoToState(useTransitions, "Pressed");
		}
		else if (base.IsPointerOver)
		{
			GoToState(useTransitions, "PointerOver");
		}
		else
		{
			GoToState(useTransitions, "Normal");
		}
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

	private protected override void OnClick()
	{
		if (AutomationPeer.ListenerExistsHelper(AutomationEvents.InvokePatternOnInvoked))
		{
			GetOrCreateAutomationPeer()?.RaiseAutomationEvent(AutomationEvents.InvokePatternOnInvoked);
		}
		base.OnClick();
		OpenAssociatedFlyout();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ButtonAutomationPeer(this);
	}

	private protected virtual void OpenAssociatedFlyout()
	{
		Flyout?.ShowAt(this);
	}
}

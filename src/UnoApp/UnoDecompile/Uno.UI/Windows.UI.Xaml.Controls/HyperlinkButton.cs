using System;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class HyperlinkButton : ButtonBase
{
	private const string ContentPresenterName = "ContentPresenter";

	private const string ContentPresenterLegacyName = "Text";

	public Uri NavigateUri
	{
		get
		{
			return (Uri)GetValue(NavigateUriProperty);
		}
		set
		{
			SetValue(NavigateUriProperty, value);
		}
	}

	public static DependencyProperty NavigateUriProperty { get; } = DependencyProperty.Register("NavigateUri", typeof(Uri), typeof(HyperlinkButton), new FrameworkPropertyMetadata((object)null));


	public HyperlinkButton()
	{
		base.DefaultStyleKey = typeof(HyperlinkButton);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (GetTemplateChild("ContentPresenter") is ContentPresenter contentPresenter)
		{
			contentPresenter.Measure(new Size(0.0, 0.0));
			if (VisualTreeHelper.GetChildrenCount(contentPresenter) == 1 && VisualTreeHelper.GetChild(contentPresenter, 0) is ImplicitTextBlock implicitTextBlock)
			{
				implicitTextBlock.TextDecorations = TextDecorations.Underline;
			}
		}
	}

	private protected override void Initialize()
	{
		base.Initialize();
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == ContentControl.ContentProperty || args.Property == ContentControl.ContentTemplateProperty)
		{
			InvalidateMeasure();
		}
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool isEnabled = base.IsEnabled;
		bool isPressed = base.IsPressed;
		bool isPointerOver = base.IsPointerOver;
		FocusState focusState = base.FocusState;
		if (!isEnabled)
		{
			GoToState(useTransitions, "Disabled");
		}
		else if (isPressed)
		{
			GoToState(useTransitions, "Pressed");
		}
		else if (isPointerOver)
		{
			GoToState(useTransitions, "PointerOver");
		}
		else
		{
			GoToState(useTransitions, "Normal");
		}
		if (focusState != FocusState.Unfocused && isEnabled)
		{
			if (focusState == FocusState.Pointer)
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

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new HyperlinkButtonAutomationPeer(this);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size result = base.MeasureOverride(availableSize);
		UnderlineContentPresenterText();
		SetHyperlinkForegroundOverrideForBackPlate();
		return result;
	}

	private protected override async void OnClick()
	{
		if (AutomationPeer.ListenerExistsHelper(AutomationEvents.InvokePatternOnInvoked))
		{
			GetOrCreateAutomationPeer()?.RaiseAutomationEvent(AutomationEvents.InvokePatternOnInvoked);
		}
		base.OnClick();
		Uri navigateUri = NavigateUri;
		if (navigateUri != null)
		{
			await Launcher.LaunchUriAsync(navigateUri);
		}
	}

	private void UnderlineContentPresenterText()
	{
		ContentPresenter contentPresenter = null;
		DependencyObject templateChild = GetTemplateChild("ContentPresenter");
		if (templateChild == null)
		{
			return;
		}
		DependencyObject dependencyObject = templateChild;
		if (dependencyObject != null)
		{
			contentPresenter = dependencyObject as ContentPresenter;
		}
		if (contentPresenter != null && contentPresenter.IsUsingDefaultTemplate)
		{
			UIElement contentTemplateRoot = contentPresenter.ContentTemplateRoot;
			if (contentTemplateRoot is TextBlock textBlock)
			{
				textBlock.TextDecorations = TextDecorations.Underline;
			}
		}
	}

	private void SetHyperlinkForegroundOverrideForBackPlate()
	{
	}
}

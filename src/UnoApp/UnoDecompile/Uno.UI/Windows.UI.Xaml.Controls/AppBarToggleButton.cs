using System;
using DirectUI;
using Windows.Foundation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class AppBarToggleButton : ToggleButton, ICommandBarElement, ICommandBarElement2, ICommandBarElement3, ICommandBarOverflowElement, ICommandBarLabeledElement
{
	private Storyboard? m_widthAdjustmentsForLabelOnRightStyleStoryboard;

	private CommandBarDefaultLabelPosition m_defaultLabelPosition;

	private TextBlock? m_tpKeyboardAcceleratorTextLabel;

	private bool m_isTemplateApplied;

	private bool m_isWithIcons;

	private bool m_isWithKeyboardAcceleratorText;

	private double m_maxKeyboardAcceleratorTextWidth;

	private bool m_ownsToolTip;

	public AppBarToggleButtonTemplateSettings TemplateSettings
	{
		get
		{
			return (AppBarToggleButtonTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(AppBarToggleButtonTemplateSettings), typeof(AppBarToggleButton), new FrameworkPropertyMetadata(null));


	public string Label
	{
		get
		{
			return (string)GetValue(LabelProperty);
		}
		set
		{
			SetValue(LabelProperty, value);
		}
	}

	public static DependencyProperty LabelProperty { get; } = DependencyProperty.Register("Label", typeof(string), typeof(AppBarToggleButton), new FrameworkPropertyMetadata((object)null));


	public IconElement Icon
	{
		get
		{
			return (IconElement)GetValue(IconProperty);
		}
		set
		{
			SetValue(IconProperty, value);
		}
	}

	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(AppBarToggleButton), new FrameworkPropertyMetadata((object)null));


	public bool IsInOverflow
	{
		get
		{
			return CommandBar.IsCommandBarElementInOverflow(this);
		}
		internal set
		{
			SetValue(IsInOverflowProperty, value);
		}
	}

	bool ICommandBarElement3.IsInOverflow
	{
		get
		{
			return IsInOverflow;
		}
		set
		{
			IsInOverflow = value;
		}
	}

	public static DependencyProperty IsInOverflowProperty { get; } = DependencyProperty.Register("IsInOverflow", typeof(bool), typeof(AppBarToggleButton), new FrameworkPropertyMetadata(false));


	public CommandBarLabelPosition LabelPosition
	{
		get
		{
			return (CommandBarLabelPosition)GetValue(LabelPositionProperty);
		}
		set
		{
			SetValue(LabelPositionProperty, value);
		}
	}

	public static DependencyProperty LabelPositionProperty { get; } = DependencyProperty.Register("LabelPosition", typeof(CommandBarLabelPosition), typeof(AppBarToggleButton), new FrameworkPropertyMetadata(CommandBarLabelPosition.Default));


	public bool IsCompact
	{
		get
		{
			return (bool)GetValue(IsCompactProperty);
		}
		set
		{
			SetValue(IsCompactProperty, value);
		}
	}

	public static DependencyProperty IsCompactProperty { get; } = DependencyProperty.Register("IsCompact", typeof(bool), typeof(AppBarToggleButton), new FrameworkPropertyMetadata(false));


	public int DynamicOverflowOrder
	{
		get
		{
			return (int)GetValue(DynamicOverflowOrderProperty);
		}
		set
		{
			SetValue(DynamicOverflowOrderProperty, value);
		}
	}

	public static DependencyProperty DynamicOverflowOrderProperty { get; } = DependencyProperty.Register("DynamicOverflowOrder", typeof(int), typeof(AppBarToggleButton), new FrameworkPropertyMetadata(0));


	internal bool UseOverflowStyle
	{
		get
		{
			return (bool)GetValue(UseOverflowStyleProperty);
		}
		set
		{
			SetValue(UseOverflowStyleProperty, value);
		}
	}

	bool ICommandBarOverflowElement.UseOverflowStyle
	{
		get
		{
			return UseOverflowStyle;
		}
		set
		{
			UseOverflowStyle = value;
		}
	}

	internal static DependencyProperty UseOverflowStyleProperty { get; } = DependencyProperty.Register("UseOverflowStyle", typeof(bool), typeof(AppBarToggleButton), new FrameworkPropertyMetadata(false));


	public string KeyboardAcceleratorTextOverride
	{
		get
		{
			return GetKeyboardAcceleratorText();
		}
		set
		{
			PutKeyboardAcceleratorText(value);
		}
	}

	public static DependencyProperty KeyboardAcceleratorTextOverrideProperty { get; } = DependencyProperty.Register("KeyboardAcceleratorTextOverride", typeof(string), typeof(AppBarToggleButton), new FrameworkPropertyMetadata((object)null));


	public AppBarToggleButton()
	{
		m_isTemplateApplied = false;
		m_isWithIcons = false;
		m_ownsToolTip = true;
		base.DefaultStyleKey = typeof(AppBarToggleButton);
	}

	internal void SetOverflowStyleParams(bool hasIcons, bool hasKeyboardAcceleratorText)
	{
		bool flag = false;
		if (m_isWithIcons != hasIcons)
		{
			m_isWithIcons = hasIcons;
			flag = true;
		}
		if (m_isWithKeyboardAcceleratorText != hasKeyboardAcceleratorText)
		{
			m_isWithKeyboardAcceleratorText = hasKeyboardAcceleratorText;
			flag = true;
		}
		if (flag)
		{
			UpdateVisualState();
		}
	}

	void ICommandBarLabeledElement.SetDefaultLabelPosition(CommandBarDefaultLabelPosition defaultLabelPosition)
	{
		if (m_defaultLabelPosition != defaultLabelPosition)
		{
			m_defaultLabelPosition = defaultLabelPosition;
			UpdateInternalStyles();
			UpdateVisualState();
		}
	}

	bool ICommandBarLabeledElement.GetHasBottomLabel()
	{
		CommandBarDefaultLabelPosition effectiveLabelPosition = GetEffectiveLabelPosition();
		string label = Label;
		if (effectiveLabelPosition == CommandBarDefaultLabelPosition.Bottom)
		{
			return label != null;
		}
		return false;
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		OnPropertyChanged(args);
	}

	protected override void OnApplyTemplate()
	{
		OnBeforeApplyTemplate();
		base.OnApplyTemplate();
		OnAfterApplyTemplate();
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs args)
	{
		base.OnPointerEntered(args);
		CloseSubMenusOnPointerEntered(null);
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool flag = false;
		base.ChangeVisualState(useTransitions);
		if (UseOverflowStyle)
		{
			if (m_isWithIcons)
			{
				GoToState(useTransitions, "OverflowWithMenuIcons");
			}
			else
			{
				GoToState(useTransitions, "Overflow");
			}
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			flag2 = base.IsEnabled;
			flag3 = base.IsPressed;
			flag4 = base.IsPointerOver;
			if (base.IsChecked.GetValueOrDefault())
			{
				if (flag3)
				{
					GoToState(useTransitions, "OverflowCheckedPressed");
				}
				else if (flag4)
				{
					GoToState(useTransitions, "OverflowCheckedPointerOver");
				}
				else if (flag2)
				{
					GoToState(useTransitions, "OverflowChecked");
				}
			}
			else if (flag3)
			{
				GoToState(useTransitions, "OverflowPressed");
			}
			else if (flag4)
			{
				GoToState(useTransitions, "OverflowPointerOver");
			}
			else if (flag2)
			{
				GoToState(useTransitions, "OverflowNormal");
			}
		}
		ChangeCommonVisualStates(useTransitions);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new AppBarToggleButtonAutomationPeer(this);
	}

	protected override void OnToggle()
	{
		CommandBar.OnCommandExecutionStatic(this);
		base.OnToggle();
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		base.OnVisibilityChanged(oldValue, newValue);
		CommandBar.OnCommandBarElementVisibilityChanged(this);
	}

	private protected override void OnCommandChanged(object oldValue, object newValue)
	{
		base.OnCommandChanged(oldValue, newValue);
		OnCommandChangedHelper(oldValue, newValue);
	}

	private CommandBarDefaultLabelPosition GetEffectiveLabelPosition()
	{
		CommandBarLabelPosition labelPosition = LabelPosition;
		if (labelPosition != CommandBarLabelPosition.Collapsed)
		{
			return m_defaultLabelPosition;
		}
		return CommandBarDefaultLabelPosition.Collapsed;
	}

	private void UpdateInternalStyles()
	{
		if (!m_isTemplateApplied)
		{
			return;
		}
		CommandBarDefaultLabelPosition effectiveLabelPosition = GetEffectiveLabelPosition();
		bool useOverflowStyle = UseOverflowStyle;
		bool flag = effectiveLabelPosition == CommandBarDefaultLabelPosition.Right && !useOverflowStyle;
		if (flag && !this.IsDependencyPropertyLocallySet(FrameworkElement.WidthProperty))
		{
			if (m_widthAdjustmentsForLabelOnRightStyleStoryboard == null)
			{
				Storyboard storyboard = (m_widthAdjustmentsForLabelOnRightStyleStoryboard = CreateStoryboardForWidthAdjustmentsForLabelOnRightStyle());
			}
			StartAnimationForWidthAdjustments();
		}
		else if (!flag && m_widthAdjustmentsForLabelOnRightStyleStoryboard != null)
		{
			StopAnimationForWidthAdjustments();
		}
		UpdateToolTip();
	}

	private Storyboard CreateStoryboardForWidthAdjustmentsForLabelOnRightStyle()
	{
		Storyboard storyboard = new Storyboard();
		ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames = new ObjectAnimationUsingKeyFrames();
		Storyboard.SetTarget(objectAnimationUsingKeyFrames, this);
		Storyboard.SetTargetProperty(objectAnimationUsingKeyFrames, "Width");
		DiscreteObjectKeyFrame discreteObjectKeyFrame = new DiscreteObjectKeyFrame();
		KeyTime keyTime2 = (discreteObjectKeyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero));
		discreteObjectKeyFrame.Value = double.NaN;
		objectAnimationUsingKeyFrames.KeyFrames.Add(discreteObjectKeyFrame);
		storyboard.Children.Add(objectAnimationUsingKeyFrames);
		return storyboard;
	}

	private void StartAnimationForWidthAdjustments()
	{
		if (m_widthAdjustmentsForLabelOnRightStyleStoryboard != null)
		{
			StopAnimationForWidthAdjustments();
			m_widthAdjustmentsForLabelOnRightStyleStoryboard!.Begin();
			m_widthAdjustmentsForLabelOnRightStyleStoryboard!.SkipToFill();
		}
	}

	private void StopAnimationForWidthAdjustments()
	{
		if (m_widthAdjustmentsForLabelOnRightStyleStoryboard != null)
		{
			ClockState currentState = m_widthAdjustmentsForLabelOnRightStyleStoryboard!.GetCurrentState();
			if (currentState == ClockState.Active || currentState == ClockState.Filling)
			{
				m_widthAdjustmentsForLabelOnRightStyleStoryboard!.Stop();
			}
		}
	}

	private void OnBeforeApplyTemplate()
	{
		if (m_isTemplateApplied)
		{
			StopAnimationForWidthAdjustments();
			m_isTemplateApplied = false;
		}
	}

	private void OnAfterApplyTemplate()
	{
		GetTemplatePart<TextBlock>("KeyboardAcceleratorTextLabel", out var element);
		m_tpKeyboardAcceleratorTextLabel = element;
		m_isTemplateApplied = true;
		UpdateInternalStyles();
		UpdateVisualState();
	}

	private void CloseSubMenusOnPointerEntered(ISubMenuOwner? pMenuToLeaveOpen)
	{
		if (IsInOverflow)
		{
			CommandBar.FindParentCommandBarForElement(this, out var parentCmdBar);
			parentCmdBar?.CloseSubMenus(pMenuToLeaveOpen, closeOnDelay: true);
		}
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == IsCompactProperty || args.Property == UseOverflowStyleProperty || args.Property == LabelPositionProperty)
		{
			UpdateInternalStyles();
			UpdateVisualState();
		}
		if (args.Property == ToolTipService.ToolTipProperty)
		{
			object value = GetValue(ToolTipService.ToolTipProperty);
			if (value != null)
			{
				m_ownsToolTip = false;
			}
			else
			{
				m_ownsToolTip = true;
			}
		}
	}

	private void ChangeCommonVisualStates(bool useTransitions)
	{
		bool isCompact = IsCompact;
		bool useOverflowStyle = UseOverflowStyle;
		CommandBarDefaultLabelPosition effectiveLabelPosition = GetEffectiveLabelPosition();
		bool flag = false;
		if (m_isWithKeyboardAcceleratorText)
		{
			flag = true;
		}
		if (!useOverflowStyle)
		{
			switch (effectiveLabelPosition)
			{
			case CommandBarDefaultLabelPosition.Right:
				GoToState(useTransitions, "LabelOnRight");
				break;
			case CommandBarDefaultLabelPosition.Collapsed:
				GoToState(useTransitions, "LabelCollapsed");
				break;
			default:
				if (isCompact)
				{
					GoToState(useTransitions, "Compact");
				}
				else
				{
					GoToState(useTransitions, "FullSize");
				}
				break;
			}
		}
		GoToState(useTransitions, "InputModeDefault");
		if (m_isWithKeyboardAcceleratorText && flag && useOverflowStyle)
		{
			GoToState(useTransitions, "KeyboardAcceleratorTextVisible");
		}
		else
		{
			GoToState(useTransitions, "KeyboardAcceleratorTextCollapsed");
		}
	}

	private void OnCommandChangedHelper(object pOldValue, object pNewValue)
	{
		if (pOldValue != null && pOldValue is XamlUICommand uiCommand)
		{
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, LabelProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, IconProperty);
		}
		if (pNewValue != null && pNewValue is XamlUICommand uiCommand2)
		{
			CommandingHelpers.ClearBindingIfSet(uiCommand2, this, ContentControl.ContentProperty);
			CommandingHelpers.BindToLabelPropertyIfUnset(uiCommand2, this, LabelProperty);
			CommandingHelpers.BindToIconPropertyIfUnset(uiCommand2, this, IconProperty);
		}
	}

	internal void UpdateTemplateSettings(double maxKeyboardAcceleratorTextWidth)
	{
		if (m_maxKeyboardAcceleratorTextWidth != maxKeyboardAcceleratorTextWidth)
		{
			m_maxKeyboardAcceleratorTextWidth = maxKeyboardAcceleratorTextWidth;
			AppBarToggleButtonTemplateSettings appBarToggleButtonTemplateSettings = TemplateSettings;
			if (appBarToggleButtonTemplateSettings == null)
			{
				appBarToggleButtonTemplateSettings = (TemplateSettings = new AppBarToggleButtonTemplateSettings());
			}
			appBarToggleButtonTemplateSettings.KeyboardAcceleratorTextMinWidth = m_maxKeyboardAcceleratorTextWidth;
		}
	}

	private void UpdateToolTip()
	{
		if (m_ownsToolTip)
		{
			bool useOverflowStyle = UseOverflowStyle;
			string keyboardAcceleratorTextOverride = KeyboardAcceleratorTextOverride;
			if (!useOverflowStyle && !string.IsNullOrWhiteSpace(keyboardAcceleratorTextOverride))
			{
				string label = Label;
				string localizedResourceString = DXamlCore.Current.GetLocalizedResourceString("KEYBOARD_ACCELERATOR_TEXT_TOOLTIP");
				SetValue(ToolTipService.ToolTipProperty, string.Format(localizedResourceString, label, keyboardAcceleratorTextOverride));
			}
			else
			{
				ClearValue(ToolTipService.ToolTipProperty);
			}
			m_ownsToolTip = true;
		}
	}

	internal Size GetKeyboardAcceleratorTextDesiredSize()
	{
		Size result = new Size(0.0, 0.0);
		if (m_tpKeyboardAcceleratorTextLabel != null)
		{
			m_tpKeyboardAcceleratorTextLabel!.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			result = m_tpKeyboardAcceleratorTextLabel!.DesiredSize;
			Thickness margin = m_tpKeyboardAcceleratorTextLabel!.Margin;
			result.Width -= margin.Left + margin.Right;
			result.Height -= margin.Top + margin.Bottom;
		}
		return result;
	}

	private string GetKeyboardAcceleratorText()
	{
		string text = GetValue(KeyboardAcceleratorTextOverrideProperty) as string;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = KeyboardAccelerator.GetStringRepresentationForUIElement(this);
			if (!string.IsNullOrWhiteSpace(text))
			{
				PutKeyboardAcceleratorText(text);
			}
		}
		return text ?? string.Empty;
	}

	private void PutKeyboardAcceleratorText(string keyboardAcceleratorText)
	{
		SetValue(KeyboardAcceleratorTextOverrideProperty, keyboardAcceleratorText);
	}

	private void GetTemplatePart<T>(string name, out T? element) where T : class
	{
		element = GetTemplateChild(name) as T;
	}
}

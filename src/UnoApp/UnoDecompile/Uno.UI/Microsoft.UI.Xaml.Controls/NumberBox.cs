using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Uno;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Globalization.NumberFormatting;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class NumberBox : Control
{
	private bool m_valueUpdating;

	private bool m_textUpdating;

	private SignificantDigitsNumberRounder m_displayRounder = new SignificantDigitsNumberRounder();

	private TextBox m_textBox;

	private Popup m_popup;

	private ContentPresenter m_headerPresenter;

	private SerialDisposable _eventSubscriptions = new SerialDisposable();

	private static string c_numberBoxDownButtonName = "DownSpinButton";

	private static string c_numberBoxUpButtonName = "UpSpinButton";

	private static string c_numberBoxTextBoxName = "InputBox";

	private static string c_numberBoxPopupName = "UpDownPopup";

	private static string c_numberBoxPopupDownButtonName = "PopupDownSpinButton";

	private static string c_numberBoxPopupUpButtonName = "PopupUpSpinButton";

	private static string c_numberBoxHeaderName = "HeaderContentPresenter";

	private const string c_whitespace = " \n\r\t\f\v";

	public double Minimum
	{
		get
		{
			return (double)GetValue(MinimumProperty);
		}
		set
		{
			SetValue(MinimumProperty, value);
		}
	}

	public static DependencyProperty MinimumProperty { get; } = DependencyProperty.Register("Minimum", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(double.MinValue, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnMinimumPropertyChanged(e);
	}));


	public double Maximum
	{
		get
		{
			return (double)GetValue(MaximumProperty);
		}
		set
		{
			SetValue(MaximumProperty, value);
		}
	}

	public static DependencyProperty MaximumProperty { get; } = DependencyProperty.Register("Maximum", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(double.MaxValue, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnMaximumPropertyChanged(e);
	}));


	public double Value
	{
		get
		{
			return (double)GetValue(ValueProperty);
		}
		set
		{
			SetValue(ValueProperty, value);
		}
	}

	public static DependencyProperty ValueProperty { get; } = DependencyProperty.Register("Value", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnValuePropertyChanged(e);
	}));


	public double SmallChange
	{
		get
		{
			return (double)GetValue(SmallChangeProperty);
		}
		set
		{
			SetValue(SmallChangeProperty, value);
		}
	}

	public static DependencyProperty SmallChangeProperty { get; } = DependencyProperty.Register("SmallChange", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(1.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnSmallChangePropertyChanged(e);
	}));


	public double LargeChange
	{
		get
		{
			return (double)GetValue(LargeChangeProperty);
		}
		set
		{
			SetValue(LargeChangeProperty, value);
		}
	}

	public static DependencyProperty LargeChangeProperty { get; } = DependencyProperty.Register("LargeChange", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(10.0));


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

	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(NumberBox), new FrameworkPropertyMetadata("", delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnTextPropertyChanged(e);
	}));


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

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(NumberBox), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnHeaderPropertyChanged(e);
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

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(NumberBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnHeaderTemplatePropertyChanged(e);
	}));


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

	public static DependencyProperty PlaceholderTextProperty { get; } = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(NumberBox), new FrameworkPropertyMetadata(null));


	[NotImplemented]
	public FlyoutBase SelectionFlyout
	{
		get
		{
			return (FlyoutBase)GetValue(SelectionFlyoutProperty);
		}
		set
		{
			SetValue(SelectionFlyoutProperty, value);
		}
	}

	public static DependencyProperty SelectionFlyoutProperty { get; } = DependencyProperty.Register("SelectionFlyout", typeof(FlyoutBase), typeof(NumberBox), new FrameworkPropertyMetadata(null));


	public SolidColorBrush SelectionHighlightColor
	{
		get
		{
			return (SolidColorBrush)GetValue(SelectionHighlightColorProperty);
		}
		set
		{
			SetValue(SelectionHighlightColorProperty, value);
		}
	}

	public static DependencyProperty SelectionHighlightColorProperty { get; } = DependencyProperty.Register("SelectionHighlightColor", typeof(SolidColorBrush), typeof(NumberBox), new FrameworkPropertyMetadata(null));


	public TextReadingOrder TextReadingOrder
	{
		get
		{
			return (TextReadingOrder)GetValue(TextReadingOrderProperty);
		}
		set
		{
			SetValue(TextReadingOrderProperty, value);
		}
	}

	public static DependencyProperty TextReadingOrderProperty { get; } = DependencyProperty.Register("TextReadingOrder", typeof(TextReadingOrder), typeof(NumberBox), new FrameworkPropertyMetadata(null));


	public bool PreventKeyboardDisplayOnProgrammaticFocus
	{
		get
		{
			return (bool)GetValue(PreventKeyboardDisplayOnProgrammaticFocusProperty);
		}
		set
		{
			SetValue(PreventKeyboardDisplayOnProgrammaticFocusProperty, value);
		}
	}

	public static DependencyProperty PreventKeyboardDisplayOnProgrammaticFocusProperty { get; } = DependencyProperty.Register("PreventKeyboardDisplayOnProgrammaticFocus", typeof(bool), typeof(NumberBox), new FrameworkPropertyMetadata(null));


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

	public static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(object), typeof(NumberBox), new FrameworkPropertyMetadata(null));


	public NumberBoxValidationMode ValidationMode
	{
		get
		{
			return (NumberBoxValidationMode)GetValue(ValidationModeProperty);
		}
		set
		{
			SetValue(ValidationModeProperty, value);
		}
	}

	public static DependencyProperty ValidationModeProperty { get; } = DependencyProperty.Register("ValidationMode", typeof(NumberBoxValidationMode), typeof(NumberBox), new FrameworkPropertyMetadata(NumberBoxValidationMode.InvalidInputOverwritten, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnValidationModePropertyChanged(e);
	}));


	public NumberBoxSpinButtonPlacementMode SpinButtonPlacementMode
	{
		get
		{
			return (NumberBoxSpinButtonPlacementMode)GetValue(SpinButtonPlacementModeProperty);
		}
		set
		{
			SetValue(SpinButtonPlacementModeProperty, value);
		}
	}

	public static DependencyProperty SpinButtonPlacementModeProperty { get; } = DependencyProperty.Register("SpinButtonPlacementMode", typeof(NumberBoxSpinButtonPlacementMode), typeof(NumberBox), new FrameworkPropertyMetadata(NumberBoxSpinButtonPlacementMode.Hidden, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnSpinButtonPlacementModePropertyChanged(e);
	}));


	public bool IsWrapEnabled
	{
		get
		{
			return (bool)GetValue(IsWrapEnabledProperty);
		}
		set
		{
			SetValue(IsWrapEnabledProperty, value);
		}
	}

	public static DependencyProperty IsWrapEnabledProperty { get; } = DependencyProperty.Register("IsWrapEnabled", typeof(bool), typeof(NumberBox), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnIsWrapEnabledPropertyChanged(e);
	}));


	public bool AcceptsExpression
	{
		get
		{
			return (bool)GetValue(AcceptsExpressionProperty);
		}
		set
		{
			SetValue(AcceptsExpressionProperty, value);
		}
	}

	public static DependencyProperty AcceptsExpressionProperty { get; } = DependencyProperty.Register("AcceptsExpression", typeof(bool), typeof(NumberBox), new FrameworkPropertyMetadata(false));


	public INumberFormatter2 NumberFormatter
	{
		get
		{
			return (INumberFormatter2)GetValue(NumberFormatterProperty);
		}
		set
		{
			SetValue(NumberFormatterProperty, value);
		}
	}

	public static DependencyProperty NumberFormatterProperty { get; } = DependencyProperty.Register("NumberFormatter", typeof(INumberFormatter2), typeof(NumberBox), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NumberBox)?.OnNumberFormatterPropertyChanged(e);
	}));


	public event TypedEventHandler<NumberBox, NumberBoxValueChangedEventArgs> ValueChanged;

	private static string trim(string s)
	{
		(char, int) tuple = GetNonWhiteSpace().FirstOrDefault();
		(char, int) tuple2 = GetNonWhiteSpace().LastOrDefault();
		if (tuple.Item1 != 0 && tuple2.Item1 != 0)
		{
			return s.Substring(tuple.Item2, tuple2.Item2 - tuple.Item2 + 1);
		}
		return "";
		IEnumerable<(char c, int i)> GetNonWhiteSpace()
		{
			return from p in s.Select((char c, int i) => (c, i))
				where !" \n\r\t\f\v".Contains(p.c.ToString())
				select p;
		}
	}

	public NumberBox()
	{
		NumberFormatter = new DecimalFormatter
		{
			IntegerDigits = 1,
			FractionDigits = 0
		};
		base.PointerWheelChanged += OnNumberBoxScroll;
		base.GotFocus += OnNumberBoxGotFocus;
		base.LostFocus += OnNumberBoxLostFocus;
		base.Loaded += delegate
		{
			InitializeTemplate();
		};
		base.Unloaded += delegate
		{
			DisposeRegistrations();
		};
		SetDefaultStyleKey(this);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new NumberBoxAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		InitializeTemplate();
	}

	private void InitializeTemplate()
	{
		_eventSubscriptions.Disposable = null;
		CompositeDisposable disposable = new CompositeDisposable();
		string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("NumberBoxDownSpinButtonName");
		string localizedStringResource2 = ResourceAccessor.GetLocalizedStringResource("NumberBoxUpSpinButtonName");
		DependencyObject templateChild = GetTemplateChild(c_numberBoxDownButtonName);
		RepeatButton spinDown = templateChild as RepeatButton;
		if (spinDown != null)
		{
			spinDown.Click += OnSpinDownClick;
			disposable.Add(delegate
			{
				spinDown.Click -= OnSpinDownClick;
			});
			if (string.IsNullOrEmpty(AutomationProperties.GetName(spinDown)))
			{
				AutomationProperties.SetName(spinDown, localizedStringResource);
			}
		}
		templateChild = GetTemplateChild(c_numberBoxUpButtonName);
		RepeatButton spinUp = templateChild as RepeatButton;
		if (spinUp != null)
		{
			spinUp.Click += OnSpinUpClick;
			disposable.Add(delegate
			{
				spinUp.Click -= OnSpinUpClick;
			});
			if (string.IsNullOrEmpty(AutomationProperties.GetName(spinUp)))
			{
				AutomationProperties.SetName(spinUp, localizedStringResource2);
			}
		}
		UpdateHeaderPresenterState();
		templateChild = GetTemplateChild(c_numberBoxTextBoxName);
		TextBox textBox = templateChild as TextBox;
		if (textBox != null)
		{
			textBox.KeyDown += OnNumberBoxKeyDown;
			disposable.Add(delegate
			{
				textBox.KeyDown -= OnNumberBoxKeyDown;
			});
			textBox.KeyUp += OnNumberBoxKeyUp;
			disposable.Add(delegate
			{
				textBox.KeyUp -= OnNumberBoxKeyUp;
			});
			m_textBox = textBox;
		}
		m_popup = GetTemplateChild(c_numberBoxPopupName) as Popup;
		SharedHelpers.IsThemeShadowAvailable();
		templateChild = GetTemplateChild(c_numberBoxPopupDownButtonName);
		RepeatButton popupSpinDown = templateChild as RepeatButton;
		if (popupSpinDown != null)
		{
			popupSpinDown.Click += OnSpinDownClick;
			disposable.Add(delegate
			{
				popupSpinDown.Click -= OnSpinDownClick;
			});
		}
		templateChild = GetTemplateChild(c_numberBoxPopupUpButtonName);
		RepeatButton popupSpinUp = templateChild as RepeatButton;
		if (popupSpinUp != null)
		{
			popupSpinUp.Click += OnSpinUpClick;
			disposable.Add(delegate
			{
				popupSpinUp.Click -= OnSpinUpClick;
			});
		}
		m_displayRounder.SignificantDigits = 12u;
		UpdateSpinButtonPlacement();
		UpdateSpinButtonEnabled();
		if (ReadLocalValue(ValueProperty) == DependencyProperty.UnsetValue && ReadLocalValue(TextProperty) != DependencyProperty.UnsetValue)
		{
			UpdateValueToText();
		}
		else
		{
			UpdateTextToValue();
		}
		_eventSubscriptions.Disposable = disposable;
	}

	private void DisposeRegistrations()
	{
		_eventSubscriptions.Disposable = null;
	}

	private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (m_valueUpdating)
		{
			return;
		}
		double num = (double)args.OldValue;
		try
		{
			m_valueUpdating = true;
			CoerceValue();
			double num2 = Value;
			if (num2 != num && (!double.IsNaN(num2) || !double.IsNaN(num)))
			{
				NumberBoxValueChangedEventArgs args2 = new NumberBoxValueChangedEventArgs(num, num2);
				this.ValueChanged?.Invoke(this, args2);
				if (FrameworkElementAutomationPeer.FromElement(this) is NumberBoxAutomationPeer numberBoxAutomationPeer)
				{
					numberBoxAutomationPeer.RaiseValueChangedEvent(num, num2);
				}
			}
			UpdateTextToValue();
			UpdateSpinButtonEnabled();
		}
		finally
		{
			m_valueUpdating = false;
		}
	}

	private void OnMinimumPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		CoerceMaximum();
		CoerceValue();
		UpdateSpinButtonEnabled();
	}

	private void OnMaximumPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		CoerceMinimum();
		CoerceValue();
		UpdateSpinButtonEnabled();
	}

	private void OnSmallChangePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateSpinButtonEnabled();
	}

	private void OnIsWrapEnabledPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateSpinButtonEnabled();
	}

	private void OnNumberFormatterPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateTextToValue();
	}

	private void ValidateNumberFormatter(INumberFormatter2 value)
	{
		if (!(value is INumberParser))
		{
			throw new ArgumentException("value");
		}
	}

	private void OnSpinButtonPlacementModePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateSpinButtonPlacement();
	}

	private void OnTextPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (!m_textUpdating)
		{
			UpdateValueToText();
		}
	}

	private void UpdateValueToText()
	{
		if (m_textBox != null)
		{
			m_textBox.Text = Text;
			ValidateInput();
		}
	}

	private void OnHeaderPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateHeaderPresenterState();
	}

	private void OnHeaderTemplatePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateHeaderPresenterState();
	}

	private void OnValidationModePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		ValidateInput();
		UpdateSpinButtonEnabled();
	}

	private void OnNumberBoxGotFocus(object sender, RoutedEventArgs args)
	{
		if (m_textBox != null)
		{
			m_textBox.SelectAll();
		}
		if (SpinButtonPlacementMode == NumberBoxSpinButtonPlacementMode.Compact && m_popup != null)
		{
			m_popup.IsOpen = true;
		}
	}

	private void OnNumberBoxLostFocus(object sender, RoutedEventArgs args)
	{
		ValidateInput();
		if (m_popup != null)
		{
			m_popup.IsOpen = false;
		}
	}

	private void CoerceMinimum()
	{
		double maximum = Maximum;
		if (Minimum > maximum)
		{
			Minimum = maximum;
		}
	}

	private void CoerceMaximum()
	{
		double minimum = Minimum;
		if (Maximum < minimum)
		{
			Maximum = minimum;
		}
	}

	private void CoerceValue()
	{
		double value = Value;
		if (!double.IsNaN(value) && !IsInBounds(value) && ValidationMode == NumberBoxValidationMode.InvalidInputOverwritten)
		{
			double maximum = Maximum;
			if (value > maximum)
			{
				Value = maximum;
			}
			else
			{
				Value = Minimum;
			}
		}
	}

	private void ValidateInput()
	{
		if (m_textBox == null)
		{
			return;
		}
		string text = trim(m_textBox.Text);
		if (string.IsNullOrEmpty(text))
		{
			Value = double.NaN;
			return;
		}
		INumberParser numberParser = NumberFormatter as INumberParser;
		double result;
		double? num = (AcceptsExpression ? NumberBoxParser.Compute(text, numberParser) : (ApiInformation.IsTypePresent(numberParser?.GetType().FullName) ? numberParser.ParseDouble(text) : (double.TryParse(text, out result) ? new double?(result) : null)));
		if (!num.HasValue)
		{
			if (ValidationMode == NumberBoxValidationMode.InvalidInputOverwritten)
			{
				UpdateTextToValue();
			}
		}
		else if (num.Value == Value)
		{
			UpdateTextToValue();
		}
		else
		{
			Value = num.Value;
		}
	}

	private void OnSpinDownClick(object sender, RoutedEventArgs args)
	{
		StepValue(0.0 - SmallChange);
	}

	private void OnSpinUpClick(object sender, RoutedEventArgs args)
	{
		StepValue(SmallChange);
	}

	private void OnNumberBoxKeyDown(object sender, KeyRoutedEventArgs args)
	{
		switch (args.OriginalKey)
		{
		case VirtualKey.Up:
			StepValue(SmallChange);
			args.Handled = true;
			break;
		case VirtualKey.Down:
			StepValue(0.0 - SmallChange);
			args.Handled = true;
			break;
		case VirtualKey.PageUp:
			StepValue(LargeChange);
			args.Handled = true;
			break;
		case VirtualKey.PageDown:
			StepValue(0.0 - LargeChange);
			args.Handled = true;
			break;
		}
	}

	private void OnNumberBoxKeyUp(object sender, KeyRoutedEventArgs args)
	{
		switch (args.OriginalKey)
		{
		case VirtualKey.Enter:
		case VirtualKey.GamepadA:
			ValidateInput();
			args.Handled = true;
			break;
		case VirtualKey.Escape:
		case VirtualKey.GamepadB:
			UpdateTextToValue();
			args.Handled = true;
			break;
		}
	}

	private void OnNumberBoxScroll(object sender, PointerRoutedEventArgs args)
	{
		if (m_textBox != null && m_textBox.FocusState != 0)
		{
			int mouseWheelDelta = args.GetCurrentPoint(this).Properties.MouseWheelDelta;
			if (mouseWheelDelta > 0)
			{
				StepValue(SmallChange);
			}
			else if (mouseWheelDelta < 0)
			{
				StepValue(0.0 - SmallChange);
			}
		}
	}

	private void StepValue(double change)
	{
		ValidateInput();
		double value = Value;
		if (double.IsNaN(value))
		{
			return;
		}
		value += change;
		if (IsWrapEnabled)
		{
			double maximum = Maximum;
			double minimum = Minimum;
			if (value > maximum)
			{
				value = minimum;
			}
			else if (value < minimum)
			{
				value = maximum;
			}
		}
		Value = value;
	}

	private void UpdateTextToValue()
	{
		if (m_textBox != null)
		{
			string text = "";
			double value = Value;
			if (!double.IsNaN(value))
			{
				double value2 = m_displayRounder.RoundDouble(value);
				text = ((!ApiInformation.IsTypePresent(NumberFormatter.GetType().FullName)) ? value2.ToString("0." + new string('#', (int)m_displayRounder.SignificantDigits), CultureInfo.CurrentCulture) : NumberFormatter.FormatDouble(value2));
			}
			m_textBox.Text = text;
			try
			{
				m_textUpdating = true;
				Text = text;
				m_textBox.Select(text.Length, 0);
			}
			finally
			{
				m_textUpdating = false;
			}
		}
	}

	private void UpdateSpinButtonPlacement()
	{
		switch (SpinButtonPlacementMode)
		{
		case NumberBoxSpinButtonPlacementMode.Inline:
			VisualStateManager.GoToState(this, "SpinButtonsVisible", useTransitions: false);
			break;
		case NumberBoxSpinButtonPlacementMode.Compact:
			VisualStateManager.GoToState(this, "SpinButtonsPopup", useTransitions: false);
			break;
		default:
			VisualStateManager.GoToState(this, "SpinButtonsCollapsed", useTransitions: false);
			break;
		}
	}

	private void UpdateSpinButtonEnabled()
	{
		double value = Value;
		bool flag = false;
		bool flag2 = false;
		if (!double.IsNaN(value))
		{
			if (IsWrapEnabled || ValidationMode != 0)
			{
				flag = true;
				flag2 = true;
			}
			else
			{
				if (value < Maximum)
				{
					flag = true;
				}
				if (value > Minimum)
				{
					flag2 = true;
				}
			}
		}
		VisualStateManager.GoToState(this, flag ? "UpSpinButtonEnabled" : "UpSpinButtonDisabled", useTransitions: false);
		VisualStateManager.GoToState(this, flag2 ? "DownSpinButtonEnabled" : "DownSpinButtonDisabled", useTransitions: false);
	}

	private bool IsInBounds(double value)
	{
		if (value >= Minimum)
		{
			return value <= Maximum;
		}
		return false;
	}

	private void UpdateHeaderPresenterState()
	{
		bool flag = false;
		object header = Header;
		if (header != null)
		{
			if (header is string text)
			{
				if (text != string.Empty)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
		}
		DataTemplate headerTemplate = HeaderTemplate;
		if (headerTemplate != null)
		{
			flag = true;
		}
		if (flag && m_headerPresenter == null)
		{
			ContentPresenter templateChild = GetTemplateChild<ContentPresenter>(c_numberBoxHeaderName);
			if (templateChild != null)
			{
				m_headerPresenter = templateChild;
			}
		}
		if (m_headerPresenter != null)
		{
			m_headerPresenter.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		}
	}
}

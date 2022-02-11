using System;
using System.Globalization;
using Uno.Disposables;
using Uno.Foundation;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

internal class TextBoxView : FrameworkElement
{
	private readonly TextBox _textBox;

	private readonly SerialDisposable _foregroundChanged = new SerialDisposable();

	public Brush Foreground
	{
		get
		{
			return (Brush)GetValue(ForegroundProperty);
		}
		set
		{
			SetValue(ForegroundProperty, value);
		}
	}

	internal static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(TextBoxView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as TextBoxView)?.OnForegroundChanged(e);
	}));


	internal bool IsMultiline { get; }

	public int SelectionStart
	{
		get
		{
			if (!int.TryParse(GetProperty("selectionStart"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
			{
				return 0;
			}
			return result;
		}
		set
		{
			SetProperty("selectionStart", value.ToString());
		}
	}

	public int SelectionEnd
	{
		get
		{
			if (!int.TryParse(GetProperty("selectionEnd"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
			{
				return 0;
			}
			return result;
		}
		set
		{
			SetProperty("selectionEnd", value.ToString());
		}
	}

	private event EventHandler HtmlInput
	{
		add
		{
			RegisterEventHandler("input", value, GenericEventHandlers.RaiseEventHandler);
		}
		remove
		{
			UnregisterEventHandler("input", value, GenericEventHandlers.RaiseEventHandler);
		}
	}

	private void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
	{
		_foregroundChanged.Disposable = null;
		if (e.NewValue is SolidColorBrush b)
		{
			_foregroundChanged.Disposable = Brush.AssignAndObserveBrush(b, delegate
			{
				SetForeground(e.NewValue);
			});
		}
		SetForeground(e.NewValue);
	}

	public TextBoxView(TextBox textBox, bool isMultiline)
		: base(isMultiline ? "textarea" : "input")
	{
		IsMultiline = isMultiline;
		_textBox = textBox;
		SetTextNative(_textBox.Text);
		if (FeatureConfiguration.TextBox.HideCaret)
		{
			SetStyle(("caret-color", "transparent !important"));
		}
		SetAttribute("tabindex", "0");
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		HtmlInput += OnInput;
		SetTextNative(_textBox.Text);
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		HtmlInput -= OnInput;
	}

	private void OnInput(object sender, EventArgs eventArgs)
	{
		string property = GetProperty("value");
		string text = _textBox.ProcessTextInput(property);
		if (text != property)
		{
			SetTextNative(text);
		}
		InvalidateMeasure();
	}

	internal void SetTextNative(string text)
	{
		SetProperty("value", text);
		InvalidateMeasure();
	}

	internal void Select(int start, int length)
	{
		WebAssemblyRuntime.InvokeJS($"Uno.UI.WindowManager.current.selectInputRange({base.HtmlId}, {start}, {length})");
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		return MeasureView(availableSize);
	}

	internal void SetIsPassword(bool isPassword)
	{
		if (IsMultiline)
		{
			throw new NotSupportedException("A PasswordBox cannot have multiple lines.");
		}
		SetAttribute("type", isPassword ? "password" : "text");
	}

	internal void SetEnabled(bool newValue)
	{
		SetProperty("disabled", newValue ? "false" : "true");
	}

	internal void SetIsReadOnly(bool isReadOnly)
	{
		if (isReadOnly)
		{
			SetAttribute("readonly", "readonly");
		}
		else
		{
			RemoveAttribute("readonly");
		}
	}

	internal void SetInputScope(InputScope scope)
	{
		SetAttribute("inputmode", scope.GetFirstInputScopeNameValue() switch
		{
			InputScopeNameValue.CurrencyAmount => "decimal", 
			InputScopeNameValue.CurrencyAmountAndSymbol => "decimal", 
			InputScopeNameValue.NumericPin => "numeric", 
			InputScopeNameValue.Digits => "numeric", 
			InputScopeNameValue.Number => "numeric", 
			InputScopeNameValue.NumberFullWidth => "numeric", 
			InputScopeNameValue.DateDayNumber => "numeric", 
			InputScopeNameValue.DateMonthNumber => "numeric", 
			InputScopeNameValue.TelephoneNumber => "tel", 
			InputScopeNameValue.TelephoneLocalNumber => "tel", 
			InputScopeNameValue.Search => "search", 
			InputScopeNameValue.SearchIncremental => "search", 
			InputScopeNameValue.EmailNameOrAddress => "email", 
			InputScopeNameValue.EmailSmtpAddress => "email", 
			InputScopeNameValue.Url => "url", 
			_ => "text", 
		});
	}

	internal override bool IsViewHit()
	{
		return true;
	}
}

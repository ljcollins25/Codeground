using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class PasswordBox : TextBox
{
	public const string RevealButtonPartName = "RevealButton";

	private ButtonBase _revealButton;

	private readonly SerialDisposable _revealButtonSubscription = new SerialDisposable();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string PasswordChar
	{
		get
		{
			return (string)GetValue(PasswordCharProperty);
		}
		set
		{
			SetValue(PasswordCharProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new SolidColorBrush SelectionHighlightColor
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

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new bool PreventKeyboardDisplayOnProgrammaticFocus
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new TextReadingOrder TextReadingOrder
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new FlyoutBase SelectionFlyout
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new object Description
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new bool CanPasteClipboardContent => (bool)GetValue(CanPasteClipboardContentProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PasswordCharProperty { get; } = DependencyProperty.Register("PasswordChar", typeof(string), typeof(PasswordBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty PreventKeyboardDisplayOnProgrammaticFocusProperty { get; } = DependencyProperty.Register("PreventKeyboardDisplayOnProgrammaticFocus", typeof(bool), typeof(PasswordBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty SelectionHighlightColorProperty { get; } = DependencyProperty.Register("SelectionHighlightColor", typeof(SolidColorBrush), typeof(PasswordBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty TextReadingOrderProperty { get; } = DependencyProperty.Register("TextReadingOrder", typeof(TextReadingOrder), typeof(PasswordBox), new FrameworkPropertyMetadata(TextReadingOrder.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty CanPasteClipboardContentProperty { get; } = DependencyProperty.Register("CanPasteClipboardContent", typeof(bool), typeof(PasswordBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(object), typeof(PasswordBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty SelectionFlyoutProperty { get; } = DependencyProperty.Register("SelectionFlyout", typeof(FlyoutBase), typeof(PasswordBox), new FrameworkPropertyMetadata((object)null));


	private bool UseIsPasswordEnabledProperty
	{
		get
		{
			if (this.IsDependencyPropertySet(IsPasswordRevealButtonEnabledProperty))
			{
				return !this.IsDependencyPropertySet(PasswordRevealModeProperty);
			}
			return false;
		}
	}

	public string Password
	{
		get
		{
			return (string)GetValue(PasswordProperty);
		}
		set
		{
			SetValue(PasswordProperty, value);
		}
	}

	public static DependencyProperty PasswordProperty { get; } = DependencyProperty.Register("Password", typeof(string), typeof(PasswordBox), new FrameworkPropertyMetadata(string.Empty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PasswordBox)s)?.OnPasswordChanged(e);
	}));


	public bool IsPasswordRevealButtonEnabled
	{
		get
		{
			return (bool)GetValue(IsPasswordRevealButtonEnabledProperty);
		}
		set
		{
			SetValue(IsPasswordRevealButtonEnabledProperty, value);
		}
	}

	public static DependencyProperty IsPasswordRevealButtonEnabledProperty { get; } = DependencyProperty.Register("IsPasswordRevealButtonEnabled", typeof(bool), typeof(PasswordBox), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PasswordBox)s)?.OnIsPasswordRevealButtonEnabledChanged(e);
	}));


	public PasswordRevealMode PasswordRevealMode
	{
		get
		{
			return (PasswordRevealMode)GetValue(PasswordRevealModeProperty);
		}
		set
		{
			SetValue(PasswordRevealModeProperty, value);
		}
	}

	public static DependencyProperty PasswordRevealModeProperty { get; } = DependencyProperty.Register("PasswordRevealMode", typeof(bool), typeof(PasswordBox), new FrameworkPropertyMetadata(PasswordRevealMode.Peek, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PasswordBox)s)?.OnPasswordRevealModeChanged(e);
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new event ContextMenuOpeningEventHandler ContextMenuOpening
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PasswordBox", "event ContextMenuOpeningEventHandler PasswordBox.ContextMenuOpening");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PasswordBox", "event ContextMenuOpeningEventHandler PasswordBox.ContextMenuOpening");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new event TextControlPasteEventHandler Paste
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PasswordBox", "event TextControlPasteEventHandler PasswordBox.Paste");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PasswordBox", "event TextControlPasteEventHandler PasswordBox.Paste");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<PasswordBox, PasswordBoxPasswordChangingEventArgs> PasswordChanging
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PasswordBox", "event TypedEventHandler<PasswordBox, PasswordBoxPasswordChangingEventArgs> PasswordBox.PasswordChanging");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PasswordBox", "event TypedEventHandler<PasswordBox, PasswordBoxPasswordChangingEventArgs> PasswordBox.PasswordChanging");
		}
	}

	public event RoutedEventHandler PasswordChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new void PasteFromClipboard()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PasswordBox", "void PasswordBox.PasteFromClipboard()");
	}

	public PasswordBox()
	{
		base.DefaultStyleKey = typeof(PasswordBox);
	}

	public new void SelectAll()
	{
		base.SelectAll();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		RegisterSetPasswordScope();
	}

	private void RegisterSetPasswordScope()
	{
		_revealButton = GetTemplateChild("RevealButton") as ButtonBase;
		if (_revealButton != null)
		{
			PointerEventHandler beginReveal = BeginReveal;
			PointerEventHandler endReveal = EndReveal;
			_revealButton.AddHandler(UIElement.PointerPressedEvent, beginReveal, handledEventsToo: true);
			_revealButton.AddHandler(UIElement.PointerReleasedEvent, endReveal, handledEventsToo: true);
			_revealButton.AddHandler(UIElement.PointerExitedEvent, endReveal, handledEventsToo: true);
			_revealButton.AddHandler(UIElement.PointerCanceledEvent, endReveal, handledEventsToo: true);
			_revealButton.AddHandler(UIElement.PointerCaptureLostEvent, endReveal, handledEventsToo: true);
			_revealButtonSubscription.Disposable = Disposable.Create(delegate
			{
				_revealButton.RemoveHandler(UIElement.PointerPressedEvent, beginReveal);
				_revealButton.RemoveHandler(UIElement.PointerReleasedEvent, endReveal);
				_revealButton.RemoveHandler(UIElement.PointerExitedEvent, endReveal);
				_revealButton.RemoveHandler(UIElement.PointerCanceledEvent, endReveal);
				_revealButton.RemoveHandler(UIElement.PointerCaptureLostEvent, endReveal);
			});
		}
		CheckRevealModeForScope();
	}

	private void BeginReveal(object sender, PointerRoutedEventArgs e)
	{
		SetPasswordScope(shouldHideText: false);
	}

	private void EndReveal(object sender, PointerRoutedEventArgs e)
	{
		SetPasswordScope(shouldHideText: true);
		EndRevealPartial();
	}

	private void EndRevealPartial()
	{
		FocusTextView();
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		_revealButtonSubscription.Disposable = null;
	}

	private void SetPasswordScope(bool shouldHideText)
	{
		SetIsPassword(shouldHideText);
	}

	private void OnPasswordChanged(DependencyPropertyChangedEventArgs e)
	{
		SetValue(TextBox.TextProperty, (string)e.NewValue);
		this.PasswordChanged?.Invoke(this, new RoutedEventArgs(this));
		if (Password.IsNullOrEmpty() && (PasswordRevealMode == PasswordRevealMode.Peek || (UseIsPasswordEnabledProperty && IsPasswordRevealButtonEnabled)))
		{
			_isButtonEnabled = true;
		}
	}

	protected override void OnTextChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnTextChanged(e);
		SetValue(PasswordProperty, (string)e.NewValue);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new PasswordBoxAutomationPeer(this);
	}

	public override string GetAccessibilityInnerText()
	{
		return null;
	}

	private void OnIsPasswordRevealButtonEnabledChanged(DependencyPropertyChangedEventArgs e)
	{
		CheckRevealModeForScope();
	}

	private void OnPasswordRevealModeChanged(DependencyPropertyChangedEventArgs e)
	{
		CheckRevealModeForScope();
	}

	private void CheckRevealModeForScope()
	{
		if (UseIsPasswordEnabledProperty)
		{
			SetPasswordScope(shouldHideText: true);
			return;
		}
		PasswordRevealMode passwordRevealMode = PasswordRevealMode;
		if ((uint)passwordRevealMode > 1u && passwordRevealMode == PasswordRevealMode.Visible)
		{
			SetPasswordScope(shouldHideText: false);
		}
		else
		{
			SetPasswordScope(shouldHideText: true);
		}
	}

	internal override void UpdateFocusState(FocusState focusState)
	{
		FocusState focusState2 = base.FocusState;
		base.UpdateFocusState(focusState);
		OnFocusStateChanged(focusState2, focusState);
	}

	private void OnFocusStateChanged(FocusState oldValue, FocusState newValue)
	{
		if (oldValue == newValue || oldValue != 0)
		{
			return;
		}
		if (UseIsPasswordEnabledProperty)
		{
			_isButtonEnabled = IsPasswordRevealButtonEnabled;
			if (_isButtonEnabled)
			{
				VisualStateManager.GoToState(this, "ButtonVisible", useTransitions: true);
			}
			else
			{
				VisualStateManager.GoToState(this, "ButtonCollapsed", useTransitions: true);
			}
		}
		else
		{
			if (PasswordRevealMode == PasswordRevealMode.Peek && Password.IsNullOrEmpty())
			{
				_isButtonEnabled = true;
			}
			else
			{
				_isButtonEnabled = false;
			}
			VisualStateManager.GoToState(this, "ButtonCollapsed", useTransitions: true);
		}
	}
}

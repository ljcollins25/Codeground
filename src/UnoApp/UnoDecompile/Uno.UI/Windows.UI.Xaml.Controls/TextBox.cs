using System;
using System.Collections.Generic;
using Uno;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.Common;
using Uno.UI.DataBinding;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class TextBox : Control, IFrameworkTemplatePoolAware
{
	private IFrameworkElement _placeHolder;

	private ContentControl _contentElement;

	private WeakReference<Button> _deleteButton;

	private ContentPresenter _header;

	private protected bool _isButtonEnabled = true;

	private bool _isInvokingTextChanged;

	private bool _isInputModifyingText;

	private bool _isTextChangedPending;

	private bool _hasTextChangedThisFocusSession;

	private bool _forceFocusedVisualState;

	private bool _isPointerOver;

	private TextBoxView _textBoxView;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string SelectedText
	{
		get
		{
			throw new NotImplementedException("The member string TextBox.SelectedText is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "string TextBox.SelectedText");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsColorFontEnabled
	{
		get
		{
			return (bool)GetValue(IsColorFontEnabledProperty);
		}
		set
		{
			SetValue(IsColorFontEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CandidateWindowAlignment DesiredCandidateWindowAlignment
	{
		get
		{
			return (CandidateWindowAlignment)GetValue(DesiredCandidateWindowAlignmentProperty);
		}
		set
		{
			SetValue(DesiredCandidateWindowAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SolidColorBrush SelectionHighlightColorWhenNotFocused
	{
		get
		{
			return (SolidColorBrush)GetValue(SelectionHighlightColorWhenNotFocusedProperty);
		}
		set
		{
			SetValue(SelectionHighlightColorWhenNotFocusedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush PlaceholderForeground
	{
		get
		{
			return (Brush)GetValue(PlaceholderForegroundProperty);
		}
		set
		{
			SetValue(PlaceholderForegroundProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextAlignment HorizontalTextAlignment
	{
		get
		{
			return (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalTextAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHandwritingViewEnabled
	{
		get
		{
			return (bool)GetValue(IsHandwritingViewEnabledProperty);
		}
		set
		{
			SetValue(IsHandwritingViewEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public HandwritingView HandwritingView
	{
		get
		{
			return (HandwritingView)GetValue(HandwritingViewProperty);
		}
		set
		{
			SetValue(HandwritingViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanPasteClipboardContent => (bool)GetValue(CanPasteClipboardContentProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanRedo => (bool)GetValue(CanRedoProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanUndo => (bool)GetValue(CanUndoProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlyoutBase ProofingMenuFlyout => (FlyoutBase)GetValue(ProofingMenuFlyoutProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionHighlightColorProperty { get; } = DependencyProperty.Register("SelectionHighlightColor", typeof(SolidColorBrush), typeof(TextBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PreventKeyboardDisplayOnProgrammaticFocusProperty { get; } = DependencyProperty.Register("PreventKeyboardDisplayOnProgrammaticFocus", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorFontEnabledProperty { get; } = DependencyProperty.Register("IsColorFontEnabled", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DesiredCandidateWindowAlignmentProperty { get; } = DependencyProperty.Register("DesiredCandidateWindowAlignment", typeof(CandidateWindowAlignment), typeof(TextBox), new FrameworkPropertyMetadata(CandidateWindowAlignment.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextReadingOrderProperty { get; } = DependencyProperty.Register("TextReadingOrder", typeof(TextReadingOrder), typeof(TextBox), new FrameworkPropertyMetadata(TextReadingOrder.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionHighlightColorWhenNotFocusedProperty { get; } = DependencyProperty.Register("SelectionHighlightColorWhenNotFocused", typeof(SolidColorBrush), typeof(TextBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlaceholderForegroundProperty { get; } = DependencyProperty.Register("PlaceholderForeground", typeof(Brush), typeof(TextBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalTextAlignmentProperty { get; } = DependencyProperty.Register("HorizontalTextAlignment", typeof(TextAlignment), typeof(TextBox), new FrameworkPropertyMetadata(TextAlignment.Center));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHandwritingViewEnabledProperty { get; } = DependencyProperty.Register("IsHandwritingViewEnabled", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HandwritingViewProperty { get; } = DependencyProperty.Register("HandwritingView", typeof(HandwritingView), typeof(TextBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionFlyoutProperty { get; } = DependencyProperty.Register("SelectionFlyout", typeof(FlyoutBase), typeof(TextBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ProofingMenuFlyoutProperty { get; } = DependencyProperty.Register("ProofingMenuFlyout", typeof(FlyoutBase), typeof(TextBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanUndoProperty { get; } = DependencyProperty.Register("CanUndo", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanRedoProperty { get; } = DependencyProperty.Register("CanRedo", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanPasteClipboardContentProperty { get; } = DependencyProperty.Register("CanPasteClipboardContent", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false));


	private protected bool CanShowButton
	{
		get
		{
			if (Text.HasValue() && base.FocusState != 0 && !IsReadOnly && !AcceptsReturn)
			{
				return TextWrapping == TextWrapping.NoWrap;
			}
			return false;
		}
	}

	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			SetValue(TextProperty, value);
		}
	}

	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(TextBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnTextChanged(e);
	}, (DependencyObject d, object v) => ((TextBox)d)?.CoerceText(v), UpdateSourceTrigger.Explicit)
	{
		CoerceWhenUnchanged = false
	});


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

	public static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(object), typeof(TextBox), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnDescriptionChanged(e);
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

	public static DependencyProperty PlaceholderTextProperty { get; } = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(TextBox), new FrameworkPropertyMetadata(string.Empty));


	public InputScope InputScope
	{
		get
		{
			return (InputScope)GetValue(InputScopeProperty);
		}
		set
		{
			SetValue(InputScopeProperty, value);
		}
	}

	public static DependencyProperty InputScopeProperty { get; } = DependencyProperty.Register("InputScope", typeof(InputScope), typeof(TextBox), new FrameworkPropertyMetadata(new InputScope
	{
		Names = 
		{
			new InputScopeName
			{
				NameValue = InputScopeNameValue.Default
			}
		}
	}, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnInputScopeChanged(e);
	}));


	public int MaxLength
	{
		get
		{
			return (int)GetValue(MaxLengthProperty);
		}
		set
		{
			SetValue(MaxLengthProperty, value);
		}
	}

	public static DependencyProperty MaxLengthProperty { get; } = DependencyProperty.Register("MaxLength", typeof(int), typeof(TextBox), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnMaxLengthChanged(e);
	}));


	public bool AcceptsReturn
	{
		get
		{
			return (bool)GetValue(AcceptsReturnProperty);
		}
		set
		{
			SetValue(AcceptsReturnProperty, value);
		}
	}

	public static DependencyProperty AcceptsReturnProperty { get; } = DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnAcceptsReturnChanged(e);
	}));


	public TextWrapping TextWrapping
	{
		get
		{
			return (TextWrapping)GetValue(TextWrappingProperty);
		}
		set
		{
			SetValue(TextWrappingProperty, value);
		}
	}

	public static DependencyProperty TextWrappingProperty { get; } = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(TextBox), new FrameworkPropertyMetadata(TextWrapping.NoWrap, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnTextWrappingChanged(e);
	}));


	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CharacterCasing CharacterCasing
	{
		get
		{
			return (CharacterCasing)GetValue(CharacterCasingProperty);
		}
		set
		{
			SetValue(CharacterCasingProperty, value);
		}
	}

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CharacterCasingProperty { get; } = DependencyProperty.Register("CharacterCasing", typeof(CharacterCasing), typeof(TextBox), new FrameworkPropertyMetadata(CharacterCasing.Normal, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnTextCharacterCasingChanged(e);
	}));


	public bool IsReadOnly
	{
		get
		{
			return (bool)GetValue(IsReadOnlyProperty);
		}
		set
		{
			SetValue(IsReadOnlyProperty, value);
		}
	}

	public static DependencyProperty IsReadOnlyProperty { get; } = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnIsReadonlyChanged(e);
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

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(TextBox), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnHeaderChanged();
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

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(TextBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnHeaderChanged();
	}));


	public bool IsSpellCheckEnabled
	{
		get
		{
			return (bool)GetValue(IsSpellCheckEnabledProperty);
		}
		set
		{
			SetValue(IsSpellCheckEnabledProperty, value);
		}
	}

	public static DependencyProperty IsSpellCheckEnabledProperty { get; } = DependencyProperty.Register("IsSpellCheckEnabled", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnIsSpellCheckEnabledChanged(e);
	}));


	[NotImplemented]
	public bool IsTextPredictionEnabled
	{
		get
		{
			return (bool)GetValue(IsTextPredictionEnabledProperty);
		}
		set
		{
			SetValue(IsTextPredictionEnabledProperty, value);
		}
	}

	[NotImplemented]
	public static DependencyProperty IsTextPredictionEnabledProperty { get; } = DependencyProperty.Register("IsTextPredictionEnabled", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnIsTextPredictionEnabledChanged(e);
	}));


	public TextAlignment TextAlignment
	{
		get
		{
			return (TextAlignment)GetValue(TextAlignmentProperty);
		}
		set
		{
			SetValue(TextAlignmentProperty, value);
		}
	}

	public static DependencyProperty TextAlignmentProperty { get; } = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(TextBox), new FrameworkPropertyMetadata(TextAlignment.Left, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBox)s)?.OnTextAlignmentChanged(e);
	}));


	public int SelectionStart
	{
		get
		{
			return _textBoxView?.SelectionStart ?? 0;
		}
		set
		{
			_textBoxView.Maybe(delegate(TextBoxView tbv)
			{
				tbv.SelectionStart = value;
			});
		}
	}

	public int SelectionLength
	{
		get
		{
			if (_textBoxView == null)
			{
				return 0;
			}
			return _textBoxView.SelectionEnd - _textBoxView.SelectionStart;
		}
		set
		{
			if (_textBoxView != null)
			{
				_textBoxView.SelectionEnd = _textBoxView.SelectionStart + value;
			}
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event ContextMenuOpeningEventHandler ContextMenuOpening
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event ContextMenuOpeningEventHandler TextBox.ContextMenuOpening");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event ContextMenuOpeningEventHandler TextBox.ContextMenuOpening");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TextControlPasteEventHandler Paste
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TextControlPasteEventHandler TextBox.Paste");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TextControlPasteEventHandler TextBox.Paste");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBox, CandidateWindowBoundsChangedEventArgs> CandidateWindowBoundsChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, CandidateWindowBoundsChangedEventArgs> TextBox.CandidateWindowBoundsChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, CandidateWindowBoundsChangedEventArgs> TextBox.CandidateWindowBoundsChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBox, TextCompositionChangedEventArgs> TextCompositionChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextCompositionChangedEventArgs> TextBox.TextCompositionChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextCompositionChangedEventArgs> TextBox.TextCompositionChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBox, TextCompositionEndedEventArgs> TextCompositionEnded
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextCompositionEndedEventArgs> TextBox.TextCompositionEnded");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextCompositionEndedEventArgs> TextBox.TextCompositionEnded");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBox, TextCompositionStartedEventArgs> TextCompositionStarted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextCompositionStartedEventArgs> TextBox.TextCompositionStarted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextCompositionStartedEventArgs> TextBox.TextCompositionStarted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBox, TextControlCopyingToClipboardEventArgs> CopyingToClipboard
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextControlCopyingToClipboardEventArgs> TextBox.CopyingToClipboard");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextControlCopyingToClipboardEventArgs> TextBox.CopyingToClipboard");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBox, TextControlCuttingToClipboardEventArgs> CuttingToClipboard
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextControlCuttingToClipboardEventArgs> TextBox.CuttingToClipboard");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextControlCuttingToClipboardEventArgs> TextBox.CuttingToClipboard");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBox, TextBoxSelectionChangingEventArgs> SelectionChanging
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextBoxSelectionChangingEventArgs> TextBox.SelectionChanging");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "event TypedEventHandler<TextBox, TextBoxSelectionChangingEventArgs> TextBox.SelectionChanging");
		}
	}

	public event TextChangedEventHandler TextChanged;

	public event TypedEventHandler<TextBox, TextBoxTextChangingEventArgs> TextChanging;

	public event TypedEventHandler<TextBox, TextBoxBeforeTextChangingEventArgs> BeforeTextChanging;

	public event RoutedEventHandler SelectionChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Rect GetRectFromCharacterIndex(int charIndex, bool trailingEdge)
	{
		throw new NotImplementedException("The member Rect TextBox.GetRectFromCharacterIndex(int charIndex, bool trailingEdge) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<IReadOnlyList<string>> GetLinguisticAlternativesAsync()
	{
		throw new NotImplementedException("The member IAsyncOperation<IReadOnlyList<string>> TextBox.GetLinguisticAlternativesAsync() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Undo()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "void TextBox.Undo()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Redo()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "void TextBox.Redo()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PasteFromClipboard()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "void TextBox.PasteFromClipboard()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CopySelectionToClipboard()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "void TextBox.CopySelectionToClipboard()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CutSelectionToClipboard()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "void TextBox.CutSelectionToClipboard()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ClearUndoRedoHistory()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBox", "void TextBox.ClearUndoRedoHistory()");
	}

	public TextBox()
	{
		this.RegisterParentChangedCallback(this, OnParentChanged);
		base.DefaultStyleKey = typeof(TextBox);
		base.SizeChanged += OnSizeChanged;
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		UpdateButtonStates();
	}

	private void OnParentChanged(object instance, object key, DependencyObjectParentChangedEventArgs args)
	{
		UpdateFontPartial();
	}

	private void InitializeProperties()
	{
		UpdatePlaceholderVisibility();
		UpdateButtonStates();
		OnInputScopeChanged(CreateInitialValueChangerEventArgs(InputScopeProperty, null, InputScope));
		OnMaxLengthChanged(CreateInitialValueChangerEventArgs(MaxLengthProperty, null, MaxLength));
		OnAcceptsReturnChanged(CreateInitialValueChangerEventArgs(AcceptsReturnProperty, null, AcceptsReturn));
		OnIsReadonlyChanged(CreateInitialValueChangerEventArgs(IsReadOnlyProperty, null, IsReadOnly));
		OnForegroundColorChanged(null, base.Foreground);
		UpdateFontPartial();
		OnHeaderChanged();
		OnIsTextPredictionEnabledChanged(CreateInitialValueChangerEventArgs(IsTextPredictionEnabledProperty, IsTextPredictionEnabledProperty.GetMetadata(GetType()).DefaultValue, IsTextPredictionEnabled));
		OnIsSpellCheckEnabledChanged(CreateInitialValueChangerEventArgs(IsSpellCheckEnabledProperty, IsSpellCheckEnabledProperty.GetMetadata(GetType()).DefaultValue, IsSpellCheckEnabled));
		OnTextAlignmentChanged(CreateInitialValueChangerEventArgs(TextAlignmentProperty, TextAlignmentProperty.GetMetadata(GetType()).DefaultValue, TextAlignment));
		OnTextWrappingChanged(CreateInitialValueChangerEventArgs(TextWrappingProperty, TextWrappingProperty.GetMetadata(GetType()).DefaultValue, TextWrapping));
		OnFocusStateChanged((FocusState)Control.FocusStateProperty.GetMetadata(GetType()).DefaultValue, base.FocusState, initial: true);
		OnVerticalContentAlignmentChanged(VerticalAlignment.Top, base.VerticalContentAlignment);
		OnTextCharacterCasingChanged(CreateInitialValueChangerEventArgs(CharacterCasingProperty, CharacterCasingProperty.GetMetadata(GetType()).DefaultValue, CharacterCasing));
		OnDescriptionChanged(CreateInitialValueChangerEventArgs(DescriptionProperty, DescriptionProperty.GetMetadata(GetType()).DefaultValue, Description));
		Button button = _deleteButton?.GetTarget();
		if (button != null)
		{
			ManagedWeakReference thisRef = ((IWeakReferenceProvider)this).WeakReference;
			button.Command = new DelegateCommand(delegate
			{
				(thisRef.Target as TextBox)?.DeleteButtonClick();
			});
		}
		InitializePropertiesPartial();
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_textBoxView = null;
		_placeHolder = GetTemplateChild("PlaceholderTextContentPresenter") as IFrameworkElement;
		_contentElement = GetTemplateChild("ContentElement") as ContentControl;
		_header = GetTemplateChild("HeaderContentPresenter") as ContentPresenter;
		ScrollViewer scrollViewer = _contentElement as ScrollViewer;
		if (GetTemplateChild("DeleteButton") is Button target)
		{
			_deleteButton = new WeakReference<Button>(target);
		}
		UpdateTextBoxView();
		InitializeProperties();
		UpdateVisualState();
	}

	private void InitializePropertiesPartial()
	{
		if (_header != null)
		{
			AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(OnHeaderClick), handledEventsToo: true);
		}
	}

	private DependencyPropertyChangedEventArgs CreateInitialValueChangerEventArgs(DependencyProperty property, object oldValue, object newValue)
	{
		return new DependencyPropertyChangedEventArgs(property, oldValue, DependencyPropertyValuePrecedences.DefaultValue, newValue, DependencyPropertyValuePrecedences.DefaultValue);
	}

	private static string GetFirstLine(string value)
	{
		for (int i = 0; i < value.Length; i++)
		{
			char c = value[i];
			if (c == '\r' || c == '\n')
			{
				return value.Substring(0, i);
			}
		}
		return value;
	}

	protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e)
	{
		_hasTextChangedThisFocusSession = true;
		if (!_isInvokingTextChanged)
		{
			_isInvokingTextChanged = true;
			this.TextChanging?.Invoke(this, new TextBoxTextChangingEventArgs());
			_isInvokingTextChanged = false;
		}
		if (!_isInputModifyingText)
		{
			_textBoxView?.SetTextNative(Text);
		}
		UpdatePlaceholderVisibility();
		UpdateButtonStates();
		if (!_isTextChangedPending)
		{
			_isTextChangedPending = true;
			base.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(RaiseTextChanged));
		}
	}

	private void RaiseTextChanged()
	{
		if (!_isInvokingTextChanged)
		{
			_isInvokingTextChanged = true;
			this.TextChanged?.Invoke(this, new TextChangedEventArgs(this));
			_isInvokingTextChanged = false;
			_isTextChangedPending = false;
		}
		_textBoxView?.SetTextNative(Text);
	}

	private void UpdatePlaceholderVisibility()
	{
		if (_placeHolder != null)
		{
			_placeHolder.Visibility = ((!Text.IsNullOrEmpty()) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	private object CoerceText(object baseValue)
	{
		string text = baseValue as string;
		if (text == null)
		{
			return "";
		}
		if (MaxLength > 0 && text.Length > MaxLength)
		{
			return DependencyProperty.UnsetValue;
		}
		if (!AcceptsReturn)
		{
			text = GetFirstLine(text);
		}
		TextBoxBeforeTextChangingEventArgs textBoxBeforeTextChangingEventArgs = new TextBoxBeforeTextChangingEventArgs(text);
		this.BeforeTextChanging?.Invoke(this, textBoxBeforeTextChangingEventArgs);
		if (textBoxBeforeTextChangingEventArgs.Cancel)
		{
			return DependencyProperty.UnsetValue;
		}
		return text;
	}

	private void OnDescriptionChanged(DependencyPropertyChangedEventArgs args)
	{
		if (!(FindName("DescriptionPresenter") is ContentPresenter contentPresenter))
		{
			return;
		}
		if (args.NewValue != null)
		{
			if (args.NewValue is string value && string.IsNullOrWhiteSpace(value))
			{
				contentPresenter.Visibility = Visibility.Collapsed;
			}
			else
			{
				contentPresenter.Visibility = Visibility.Visible;
			}
		}
		else
		{
			contentPresenter.Visibility = Visibility.Collapsed;
		}
	}

	protected override void OnFontSizeChanged(double oldValue, double newValue)
	{
		base.OnFontSizeChanged(oldValue, newValue);
		UpdateFontPartial();
	}

	protected override void OnFontFamilyChanged(FontFamily oldValue, FontFamily newValue)
	{
		base.OnFontFamilyChanged(oldValue, newValue);
		UpdateFontPartial();
	}

	protected override void OnFontStyleChanged(FontStyle oldValue, FontStyle newValue)
	{
		base.OnFontStyleChanged(oldValue, newValue);
		UpdateFontPartial();
	}

	protected override void OnFontWeightChanged(FontWeight oldValue, FontWeight newValue)
	{
		base.OnFontWeightChanged(oldValue, newValue);
		UpdateFontPartial();
	}

	private void UpdateFontPartial()
	{
		if (_textBoxView != null)
		{
			_textBoxView.SetFontSize(base.FontSize);
			_textBoxView.SetFontStyle(base.FontStyle);
			_textBoxView.SetFontWeight(base.FontWeight);
			_textBoxView.SetFontFamily(base.FontFamily);
		}
	}

	protected override void OnForegroundColorChanged(Brush oldValue, Brush newValue)
	{
		OnForegroundColorChangedPartial(newValue);
	}

	private void OnForegroundColorChangedPartial(Brush newValue)
	{
		_textBoxView?.SetForeground(newValue);
	}

	protected void OnInputScopeChanged(DependencyPropertyChangedEventArgs e)
	{
		OnInputScopeChangedPartial(e);
	}

	private void OnInputScopeChangedPartial(DependencyPropertyChangedEventArgs e)
	{
		if (e.NewValue is InputScope scope)
		{
			ApplyInputScope(scope);
		}
	}

	private void OnMaxLengthChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnAcceptsReturnChanged(DependencyPropertyChangedEventArgs e)
	{
		object newValue = e.NewValue;
		if (newValue is bool && !(bool)newValue)
		{
			string text = Text;
			string firstLine = GetFirstLine(text);
			if (text != firstLine)
			{
				Text = firstLine;
			}
		}
		UpdateButtonStates();
	}

	private void OnTextWrappingChanged(DependencyPropertyChangedEventArgs args)
	{
		OnTextWrappingChangedPartial(args);
		UpdateButtonStates();
	}

	private void OnTextWrappingChangedPartial(DependencyPropertyChangedEventArgs e)
	{
		_textBoxView?.SetTextWrappingAndTrimming(TextWrapping, null);
	}

	private void OnTextCharacterCasingChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnIsReadonlyChanged(DependencyPropertyChangedEventArgs e)
	{
		OnIsReadonlyChangedPartial(e);
		UpdateButtonStates();
	}

	private void OnIsReadonlyChangedPartial(DependencyPropertyChangedEventArgs e)
	{
		object newValue = e.NewValue;
		if (newValue is bool)
		{
			bool value = (bool)newValue;
			ApplyIsReadonly(value);
		}
	}

	private void OnHeaderChanged()
	{
		Visibility visibility = ((Header == null && HeaderTemplate == null) ? Visibility.Collapsed : Visibility.Visible);
		if (_header != null)
		{
			_header.Visibility = visibility;
		}
	}

	protected virtual void OnIsSpellCheckEnabledChanged(DependencyPropertyChangedEventArgs e)
	{
		OnIsSpellCheckEnabledChangedPartial(e);
	}

	private void OnIsSpellCheckEnabledChangedPartial(DependencyPropertyChangedEventArgs e)
	{
		_textBoxView?.SetAttribute("spellcheck", IsSpellCheckEnabled.ToString());
	}

	protected virtual void OnIsTextPredictionEnabledChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	protected virtual void OnTextAlignmentChanged(DependencyPropertyChangedEventArgs e)
	{
		OnTextAlignmentChangedPartial(e);
	}

	private void OnTextAlignmentChangedPartial(DependencyPropertyChangedEventArgs e)
	{
		_textBoxView?.SetTextAlignment(TextAlignment);
	}

	internal override void UpdateFocusState(FocusState focusState)
	{
		FocusState focusState2 = base.FocusState;
		base.UpdateFocusState(focusState);
		OnFocusStateChanged(focusState2, focusState, initial: false);
	}

	private void OnFocusStateChanged(FocusState oldValue, FocusState newValue, bool initial)
	{
		if (!initial && newValue == FocusState.Unfocused && _hasTextChangedThisFocusSession)
		{
			GetBindingExpression(TextProperty)?.UpdateSource(Text);
		}
		UpdateButtonStates();
		if (oldValue == FocusState.Unfocused || newValue == FocusState.Unfocused)
		{
			_hasTextChangedThisFocusSession = false;
		}
		UpdateVisualState();
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		if (newValue == Visibility.Visible)
		{
			UpdateVisualState();
		}
		else
		{
			_isPointerOver = false;
		}
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs e)
	{
		base.OnPointerEntered(e);
		_isPointerOver = true;
		UpdateVisualState();
	}

	protected override void OnPointerExited(PointerRoutedEventArgs e)
	{
		base.OnPointerExited(e);
		_isPointerOver = false;
		UpdateVisualState();
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs e)
	{
		base.OnPointerCaptureLost(e);
		_isPointerOver = false;
		UpdateVisualState();
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		base.OnPointerPressed(args);
		if (ShouldFocusOnPointerPressed(args))
		{
			Focus(FocusState.Pointer);
		}
		args.Handled = true;
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		base.OnPointerReleased(args);
		if (!ShouldFocusOnPointerPressed(args))
		{
			Focus(FocusState.Pointer);
		}
		args.Handled = true;
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		base.OnKeyDown(args);
		switch (args.Key)
		{
		case VirtualKey.Up:
		case VirtualKey.Down:
			if (AcceptsReturn)
			{
				args.Handled = true;
			}
			break;
		case VirtualKey.End:
		case VirtualKey.Home:
		case VirtualKey.Left:
		case VirtualKey.Right:
			args.Handled = true;
			break;
		}
		if (args.Handled)
		{
			((IPreventDefaultHandling)args).DoNotPreventDefault = true;
		}
	}

	protected virtual void UpdateButtonStates()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug("UpdateButtonStates");
		}
		if (CanShowButton && _isButtonEnabled && base.ActualWidth > base.FontSize * 5.0)
		{
			VisualStateManager.GoToState(this, "ButtonVisible", useTransitions: true);
		}
		else
		{
			VisualStateManager.GoToState(this, "ButtonCollapsed", useTransitions: true);
		}
	}

	internal string ProcessTextInput(string newText)
	{
		_isInputModifyingText = true;
		Text = newText;
		_isInputModifyingText = false;
		return Text;
	}

	private void DeleteButtonClick()
	{
		Text = string.Empty;
		OnDeleteButtonClickPartial();
	}

	private void OnDeleteButtonClickPartial()
	{
		FocusTextView();
	}

	internal void OnSelectionChanged()
	{
		this.SelectionChanged?.Invoke(this, new RoutedEventArgs(this));
	}

	public void OnTemplateRecycled()
	{
		Text = string.Empty;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new TextBoxAutomationPeer(this);
	}

	public override string GetAccessibilityInnerText()
	{
		return Text;
	}

	protected override void OnVerticalContentAlignmentChanged(VerticalAlignment oldVerticalContentAlignment, VerticalAlignment newVerticalContentAlignment)
	{
		base.OnVerticalContentAlignmentChanged(oldVerticalContentAlignment, newVerticalContentAlignment);
		if (_contentElement != null)
		{
			_contentElement.VerticalContentAlignment = newVerticalContentAlignment;
		}
		if (_placeHolder != null)
		{
			_placeHolder.VerticalAlignment = newVerticalContentAlignment;
		}
	}

	public void Select(int start, int length)
	{
		if (start < 0)
		{
			throw new ArgumentException($"'{start}' cannot be negative.", "start");
		}
		if (length < 0)
		{
			throw new ArgumentException($"'{length}' cannot be negative.", "length");
		}
		int length2 = Text.Length;
		if (start >= length2)
		{
			start = length2;
			length = 0;
		}
		else if (start + length > length2)
		{
			length = length2 - start;
		}
		if (SelectionStart != start || SelectionLength != length)
		{
			SelectPartial(start, length);
			OnSelectionChanged();
		}
	}

	public void SelectAll()
	{
		SelectAllPartial();
	}

	private void SelectPartial(int start, int length)
	{
		_textBoxView?.Select(start, length);
	}

	private void SelectAllPartial()
	{
		Select(0, Text.Length);
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}

	private bool ShouldFocusOnPointerPressed(PointerRoutedEventArgs args)
	{
		return args.Pointer.PointerDeviceType != PointerDeviceType.Touch;
	}

	internal override void UpdateVisualState(bool useTransitions = true)
	{
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
		if (!base.IsEnabled)
		{
			VisualStateManager.GoToState(this, "Disabled", useTransitions: true);
		}
		else if (_forceFocusedVisualState || (base.FocusState != 0 && focusManagerForElement.IsPluginFocused()))
		{
			VisualStateManager.GoToState(this, "Focused", useTransitions: true);
		}
		else if (_isPointerOver)
		{
			VisualStateManager.GoToState(this, "PointerOver", useTransitions: true);
		}
		else
		{
			VisualStateManager.GoToState(this, "Normal", useTransitions: true);
		}
	}

	protected override bool IsDelegatingFocusToTemplateChild()
	{
		return true;
	}

	internal bool FocusTextView()
	{
		return FocusManager.FocusNative(_textBoxView);
	}

	private void UpdateTextBoxView()
	{
		if (_contentElement == null)
		{
			return;
		}
		if (AcceptsReturn || TextWrapping != 0)
		{
			if (_textBoxView == null || !_textBoxView.IsMultiline)
			{
				_textBoxView = new TextBoxView(this, isMultiline: true);
				_contentElement.Content = _textBoxView;
				InitializeProperties();
			}
		}
		else if (_textBoxView == null || _textBoxView.IsMultiline)
		{
			_textBoxView = new TextBoxView(this, isMultiline: false);
			_contentElement.Content = _textBoxView;
			InitializeProperties();
		}
	}

	private void OnHeaderClick(object sender, object args)
	{
		FocusTextView();
	}

	protected void SetIsPassword(bool isPassword)
	{
		if (_textBoxView != null)
		{
			_textBoxView.SetIsPassword(isPassword);
		}
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		base.OnIsEnabledChanged(e);
		ApplyEnabled(e.NewValue);
	}

	private void ApplyEnabled(bool? isEnabled = null)
	{
		_textBoxView?.SetEnabled(isEnabled ?? base.IsEnabled);
	}

	private void ApplyIsReadonly(bool? isReadOnly = null)
	{
		_textBoxView?.SetIsReadOnly(isReadOnly ?? IsReadOnly);
	}

	private void ApplyInputScope(InputScope scope)
	{
		_textBoxView?.SetInputScope(scope);
	}
}

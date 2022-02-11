using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class RichEditBox
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextWrapping TextWrapping
	{
		get
		{
			return (TextWrapping)this.GetValue(TextWrappingProperty);
		}
		set
		{
			this.SetValue(TextWrappingProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextAlignment TextAlignment
	{
		get
		{
			return (TextAlignment)this.GetValue(TextAlignmentProperty);
		}
		set
		{
			this.SetValue(TextAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsTextPredictionEnabled
	{
		get
		{
			return (bool)this.GetValue(IsTextPredictionEnabledProperty);
		}
		set
		{
			this.SetValue(IsTextPredictionEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSpellCheckEnabled
	{
		get
		{
			return (bool)this.GetValue(IsSpellCheckEnabledProperty);
		}
		set
		{
			this.SetValue(IsSpellCheckEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsReadOnly
	{
		get
		{
			return (bool)this.GetValue(IsReadOnlyProperty);
		}
		set
		{
			this.SetValue(IsReadOnlyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InputScope InputScope
	{
		get
		{
			return (InputScope)this.GetValue(InputScopeProperty);
		}
		set
		{
			this.SetValue(InputScopeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AcceptsReturn
	{
		get
		{
			return (bool)this.GetValue(AcceptsReturnProperty);
		}
		set
		{
			this.SetValue(AcceptsReturnProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ITextDocument Document
	{
		get
		{
			throw new NotImplementedException("The member ITextDocument RichEditBox.Document is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SolidColorBrush SelectionHighlightColor
	{
		get
		{
			return (SolidColorBrush)this.GetValue(SelectionHighlightColorProperty);
		}
		set
		{
			this.SetValue(SelectionHighlightColorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool PreventKeyboardDisplayOnProgrammaticFocus
	{
		get
		{
			return (bool)this.GetValue(PreventKeyboardDisplayOnProgrammaticFocusProperty);
		}
		set
		{
			this.SetValue(PreventKeyboardDisplayOnProgrammaticFocusProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string PlaceholderText
	{
		get
		{
			return (string)this.GetValue(PlaceholderTextProperty);
		}
		set
		{
			this.SetValue(PlaceholderTextProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsColorFontEnabled
	{
		get
		{
			return (bool)this.GetValue(IsColorFontEnabledProperty);
		}
		set
		{
			this.SetValue(IsColorFontEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataTemplate HeaderTemplate
	{
		get
		{
			return (DataTemplate)this.GetValue(HeaderTemplateProperty);
		}
		set
		{
			this.SetValue(HeaderTemplateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Header
	{
		get
		{
			return this.GetValue(HeaderProperty);
		}
		set
		{
			this.SetValue(HeaderProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextReadingOrder TextReadingOrder
	{
		get
		{
			return (TextReadingOrder)this.GetValue(TextReadingOrderProperty);
		}
		set
		{
			this.SetValue(TextReadingOrderProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CandidateWindowAlignment DesiredCandidateWindowAlignment
	{
		get
		{
			return (CandidateWindowAlignment)this.GetValue(DesiredCandidateWindowAlignmentProperty);
		}
		set
		{
			this.SetValue(DesiredCandidateWindowAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RichEditClipboardFormat ClipboardCopyFormat
	{
		get
		{
			return (RichEditClipboardFormat)this.GetValue(ClipboardCopyFormatProperty);
		}
		set
		{
			this.SetValue(ClipboardCopyFormatProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SolidColorBrush SelectionHighlightColorWhenNotFocused
	{
		get
		{
			return (SolidColorBrush)this.GetValue(SelectionHighlightColorWhenNotFocusedProperty);
		}
		set
		{
			this.SetValue(SelectionHighlightColorWhenNotFocusedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MaxLength
	{
		get
		{
			return (int)this.GetValue(MaxLengthProperty);
		}
		set
		{
			this.SetValue(MaxLengthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextAlignment HorizontalTextAlignment
	{
		get
		{
			return (TextAlignment)this.GetValue(HorizontalTextAlignmentProperty);
		}
		set
		{
			this.SetValue(HorizontalTextAlignmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DisabledFormattingAccelerators DisabledFormattingAccelerators
	{
		get
		{
			return (DisabledFormattingAccelerators)this.GetValue(DisabledFormattingAcceleratorsProperty);
		}
		set
		{
			this.SetValue(DisabledFormattingAcceleratorsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CharacterCasing CharacterCasing
	{
		get
		{
			return (CharacterCasing)this.GetValue(CharacterCasingProperty);
		}
		set
		{
			this.SetValue(CharacterCasingProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHandwritingViewEnabled
	{
		get
		{
			return (bool)this.GetValue(IsHandwritingViewEnabledProperty);
		}
		set
		{
			this.SetValue(IsHandwritingViewEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public HandwritingView HandwritingView
	{
		get
		{
			return (HandwritingView)this.GetValue(HandwritingViewProperty);
		}
		set
		{
			this.SetValue(HandwritingViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ContentLinkProviderCollection ContentLinkProviders
	{
		get
		{
			return (ContentLinkProviderCollection)this.GetValue(ContentLinkProvidersProperty);
		}
		set
		{
			this.SetValue(ContentLinkProvidersProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SolidColorBrush ContentLinkForegroundColor
	{
		get
		{
			return (SolidColorBrush)this.GetValue(ContentLinkForegroundColorProperty);
		}
		set
		{
			this.SetValue(ContentLinkForegroundColorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SolidColorBrush ContentLinkBackgroundColor
	{
		get
		{
			return (SolidColorBrush)this.GetValue(ContentLinkBackgroundColorProperty);
		}
		set
		{
			this.SetValue(ContentLinkBackgroundColorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlyoutBase SelectionFlyout
	{
		get
		{
			return (FlyoutBase)this.GetValue(SelectionFlyoutProperty);
		}
		set
		{
			this.SetValue(SelectionFlyoutProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Description
	{
		get
		{
			return this.GetValue(DescriptionProperty);
		}
		set
		{
			this.SetValue(DescriptionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlyoutBase ProofingMenuFlyout => (FlyoutBase)this.GetValue(ProofingMenuFlyoutProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RichEditTextDocument TextDocument
	{
		get
		{
			throw new NotImplementedException("The member RichEditTextDocument RichEditBox.TextDocument is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AcceptsReturnProperty { get; } = DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(RichEditBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty InputScopeProperty { get; } = DependencyProperty.Register("InputScope", typeof(InputScope), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsReadOnlyProperty { get; } = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(RichEditBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsSpellCheckEnabledProperty { get; } = DependencyProperty.Register("IsSpellCheckEnabled", typeof(bool), typeof(RichEditBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextPredictionEnabledProperty { get; } = DependencyProperty.Register("IsTextPredictionEnabled", typeof(bool), typeof(RichEditBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextAlignmentProperty { get; } = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(RichEditBox), new FrameworkPropertyMetadata(TextAlignment.Center));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextWrappingProperty { get; } = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(RichEditBox), new FrameworkPropertyMetadata(TextWrapping.NoWrap));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorFontEnabledProperty { get; } = DependencyProperty.Register("IsColorFontEnabled", typeof(bool), typeof(RichEditBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlaceholderTextProperty { get; } = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PreventKeyboardDisplayOnProgrammaticFocusProperty { get; } = DependencyProperty.Register("PreventKeyboardDisplayOnProgrammaticFocus", typeof(bool), typeof(RichEditBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionHighlightColorProperty { get; } = DependencyProperty.Register("SelectionHighlightColor", typeof(SolidColorBrush), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DesiredCandidateWindowAlignmentProperty { get; } = DependencyProperty.Register("DesiredCandidateWindowAlignment", typeof(CandidateWindowAlignment), typeof(RichEditBox), new FrameworkPropertyMetadata(CandidateWindowAlignment.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextReadingOrderProperty { get; } = DependencyProperty.Register("TextReadingOrder", typeof(TextReadingOrder), typeof(RichEditBox), new FrameworkPropertyMetadata(TextReadingOrder.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ClipboardCopyFormatProperty { get; } = DependencyProperty.Register("ClipboardCopyFormat", typeof(RichEditClipboardFormat), typeof(RichEditBox), new FrameworkPropertyMetadata(RichEditClipboardFormat.AllFormats));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxLengthProperty { get; } = DependencyProperty.Register("MaxLength", typeof(int), typeof(RichEditBox), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionHighlightColorWhenNotFocusedProperty { get; } = DependencyProperty.Register("SelectionHighlightColorWhenNotFocused", typeof(SolidColorBrush), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CharacterCasingProperty { get; } = DependencyProperty.Register("CharacterCasing", typeof(CharacterCasing), typeof(RichEditBox), new FrameworkPropertyMetadata(CharacterCasing.Normal));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DisabledFormattingAcceleratorsProperty { get; } = DependencyProperty.Register("DisabledFormattingAccelerators", typeof(DisabledFormattingAccelerators), typeof(RichEditBox), new FrameworkPropertyMetadata(DisabledFormattingAccelerators.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalTextAlignmentProperty { get; } = DependencyProperty.Register("HorizontalTextAlignment", typeof(TextAlignment), typeof(RichEditBox), new FrameworkPropertyMetadata(TextAlignment.Center));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentLinkBackgroundColorProperty { get; } = DependencyProperty.Register("ContentLinkBackgroundColor", typeof(SolidColorBrush), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentLinkForegroundColorProperty { get; } = DependencyProperty.Register("ContentLinkForegroundColor", typeof(SolidColorBrush), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentLinkProvidersProperty { get; } = DependencyProperty.Register("ContentLinkProviders", typeof(ContentLinkProviderCollection), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HandwritingViewProperty { get; } = DependencyProperty.Register("HandwritingView", typeof(HandwritingView), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHandwritingViewEnabledProperty { get; } = DependencyProperty.Register("IsHandwritingViewEnabled", typeof(bool), typeof(RichEditBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(object), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ProofingMenuFlyoutProperty { get; } = DependencyProperty.Register("ProofingMenuFlyout", typeof(FlyoutBase), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionFlyoutProperty { get; } = DependencyProperty.Register("SelectionFlyout", typeof(FlyoutBase), typeof(RichEditBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event ContextMenuOpeningEventHandler ContextMenuOpening
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event ContextMenuOpeningEventHandler RichEditBox.ContextMenuOpening");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event ContextMenuOpeningEventHandler RichEditBox.ContextMenuOpening");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler SelectionChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event RoutedEventHandler RichEditBox.SelectionChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event RoutedEventHandler RichEditBox.SelectionChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler TextChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event RoutedEventHandler RichEditBox.TextChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event RoutedEventHandler RichEditBox.TextChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TextControlPasteEventHandler Paste
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TextControlPasteEventHandler RichEditBox.Paste");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TextControlPasteEventHandler RichEditBox.Paste");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, CandidateWindowBoundsChangedEventArgs> CandidateWindowBoundsChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, CandidateWindowBoundsChangedEventArgs> RichEditBox.CandidateWindowBoundsChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, CandidateWindowBoundsChangedEventArgs> RichEditBox.CandidateWindowBoundsChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, RichEditBoxTextChangingEventArgs> TextChanging
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, RichEditBoxTextChangingEventArgs> RichEditBox.TextChanging");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, RichEditBoxTextChangingEventArgs> RichEditBox.TextChanging");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, TextCompositionChangedEventArgs> TextCompositionChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextCompositionChangedEventArgs> RichEditBox.TextCompositionChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextCompositionChangedEventArgs> RichEditBox.TextCompositionChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, TextCompositionEndedEventArgs> TextCompositionEnded
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextCompositionEndedEventArgs> RichEditBox.TextCompositionEnded");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextCompositionEndedEventArgs> RichEditBox.TextCompositionEnded");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, TextCompositionStartedEventArgs> TextCompositionStarted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextCompositionStartedEventArgs> RichEditBox.TextCompositionStarted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextCompositionStartedEventArgs> RichEditBox.TextCompositionStarted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, TextControlCopyingToClipboardEventArgs> CopyingToClipboard
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextControlCopyingToClipboardEventArgs> RichEditBox.CopyingToClipboard");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextControlCopyingToClipboardEventArgs> RichEditBox.CopyingToClipboard");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, TextControlCuttingToClipboardEventArgs> CuttingToClipboard
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextControlCuttingToClipboardEventArgs> RichEditBox.CuttingToClipboard");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, TextControlCuttingToClipboardEventArgs> RichEditBox.CuttingToClipboard");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, ContentLinkChangedEventArgs> ContentLinkChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, ContentLinkChangedEventArgs> RichEditBox.ContentLinkChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, ContentLinkChangedEventArgs> RichEditBox.ContentLinkChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, ContentLinkInvokedEventArgs> ContentLinkInvoked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, ContentLinkInvokedEventArgs> RichEditBox.ContentLinkInvoked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, ContentLinkInvokedEventArgs> RichEditBox.ContentLinkInvoked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichEditBox, RichEditBoxSelectionChangingEventArgs> SelectionChanging
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, RichEditBoxSelectionChangingEventArgs> RichEditBox.SelectionChanging");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "event TypedEventHandler<RichEditBox, RichEditBoxSelectionChangingEventArgs> RichEditBox.SelectionChanging");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RichEditBox()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichEditBox", "RichEditBox.RichEditBox()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<IReadOnlyList<string>> GetLinguisticAlternativesAsync()
	{
		throw new NotImplementedException("The member IAsyncOperation<IReadOnlyList<string>> RichEditBox.GetLinguisticAlternativesAsync() is not implemented in Uno.");
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Uno;
using Uno.Disposables;
using Uno.UI;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Text")]
public class TextBlock : FrameworkElement, DependencyObject
{
	private InlineCollection _inlines;

	private string _inlinesText;

	private readonly SerialDisposable _foregroundChanged = new SerialDisposable();

	internal static readonly PointerEventHandler OnPointerPressed = delegate(object sender, PointerRoutedEventArgs e)
	{
		if (sender is Hyperlink hyperlink3 && e.GetCurrentPoint(hyperlink3).Properties.IsLeftButtonPressed && hyperlink3.CapturePointer(e.Pointer))
		{
			hyperlink3.SetPointerPressed(e.Pointer);
			e.Handled = true;
		}
		else if (sender is TextBlock textBlock && textBlock.IsTextSelectionEnabled)
		{
			e.Handled = true;
		}
	};

	internal static readonly PointerEventHandler OnPointerReleased = delegate(object sender, PointerRoutedEventArgs e)
	{
		if (sender is Hyperlink hyperlink2 && hyperlink2.IsCaptured(e.Pointer))
		{
			(hyperlink2.GetParent() as TextBlock)?.CompleteGesture();
			hyperlink2.ReleasePointerPressed(e.Pointer);
		}
	};

	internal static readonly PointerEventHandler OnPointerCaptureLost = delegate(object sender, PointerRoutedEventArgs e)
	{
		if (sender is Hyperlink hyperlink)
		{
			bool flag2 = (e.Handled = hyperlink.AbortPointerPressed(e.Pointer));
		}
	};

	private const int MaxMeasureCache = 50;

	private static TextBlockMeasureCache _cache = new TextBlockMeasureCache();

	private bool _fontStyleChanged;

	private bool _fontWeightChanged;

	private bool _textChanged;

	private bool _fontFamilyChanged;

	private bool _fontSizeChanged;

	private bool _maxLinesChanged;

	private bool _textTrimmingChanged;

	private bool _textAlignmentChanged;

	private bool _lineHeightChanged;

	private bool _characterSpacingChanged;

	private bool _textDecorationsChanged;

	private bool _textWrappingChanged;

	private bool _paddingChangedChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FontStretch FontStretch
	{
		get
		{
			return (FontStretch)GetValue(FontStretchProperty);
		}
		set
		{
			SetValue(FontStretchProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string SelectedText => (string)GetValue(SelectedTextProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer SelectionEnd
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextBlock.SelectionEnd is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer SelectionStart
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextBlock.SelectionStart is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double BaselineOffset
	{
		get
		{
			throw new NotImplementedException("The member double TextBlock.BaselineOffset is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer ContentEnd
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextBlock.ContentEnd is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer ContentStart
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextBlock.ContentStart is not implemented in Uno.");
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
	public TextLineBounds TextLineBounds
	{
		get
		{
			return (TextLineBounds)GetValue(TextLineBoundsProperty);
		}
		set
		{
			SetValue(TextLineBoundsProperty, value);
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
	public OpticalMarginAlignment OpticalMarginAlignment
	{
		get
		{
			return (OpticalMarginAlignment)GetValue(OpticalMarginAlignmentProperty);
		}
		set
		{
			SetValue(OpticalMarginAlignmentProperty, value);
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsTextScaleFactorEnabled
	{
		get
		{
			return (bool)GetValue(IsTextScaleFactorEnabledProperty);
		}
		set
		{
			SetValue(IsTextScaleFactorEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsTextTrimmed => (bool)GetValue(IsTextTrimmedProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<TextHighlighter> TextHighlighters
	{
		get
		{
			throw new NotImplementedException("The member IList<TextHighlighter> TextBlock.TextHighlighters is not implemented in Uno.");
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
	public static DependencyProperty FontStretchProperty { get; } = DependencyProperty.Register("FontStretch", typeof(FontStretch), typeof(TextBlock), new FrameworkPropertyMetadata(FontStretch.Undefined));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedTextProperty { get; } = DependencyProperty.Register("SelectedText", typeof(string), typeof(TextBlock), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorFontEnabledProperty { get; } = DependencyProperty.Register("IsColorFontEnabled", typeof(bool), typeof(TextBlock), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OpticalMarginAlignmentProperty { get; } = DependencyProperty.Register("OpticalMarginAlignment", typeof(OpticalMarginAlignment), typeof(TextBlock), new FrameworkPropertyMetadata(OpticalMarginAlignment.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionHighlightColorProperty { get; } = DependencyProperty.Register("SelectionHighlightColor", typeof(SolidColorBrush), typeof(TextBlock), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextLineBoundsProperty { get; } = DependencyProperty.Register("TextLineBounds", typeof(TextLineBounds), typeof(TextBlock), new FrameworkPropertyMetadata(TextLineBounds.Full));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextReadingOrderProperty { get; } = DependencyProperty.Register("TextReadingOrder", typeof(TextReadingOrder), typeof(TextBlock), new FrameworkPropertyMetadata(TextReadingOrder.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } = DependencyProperty.Register("IsTextScaleFactorEnabled", typeof(bool), typeof(TextBlock), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextTrimmedProperty { get; } = DependencyProperty.Register("IsTextTrimmed", typeof(bool), typeof(TextBlock), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionFlyoutProperty { get; } = DependencyProperty.Register("SelectionFlyout", typeof(FlyoutBase), typeof(TextBlock), new FrameworkPropertyMetadata((object)null));


	public InlineCollection Inlines
	{
		get
		{
			if (_inlines == null)
			{
				_inlines = new InlineCollection(this);
				UpdateInlines(Text);
			}
			return _inlines;
		}
	}

	public FontStyle FontStyle
	{
		get
		{
			return (FontStyle)GetValue(FontStyleProperty);
		}
		set
		{
			SetValue(FontStyleProperty, value);
		}
	}

	public static DependencyProperty FontStyleProperty { get; } = DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(TextBlock), new FrameworkPropertyMetadata(FontStyle.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnFontStyleChanged();
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

	public static DependencyProperty TextWrappingProperty { get; } = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(TextBlock), new FrameworkPropertyMetadata(TextWrapping.NoWrap, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnTextWrappingChanged();
	}));


	public FontWeight FontWeight
	{
		get
		{
			return (FontWeight)GetValue(FontWeightProperty);
		}
		set
		{
			SetValue(FontWeightProperty, value);
		}
	}

	public static DependencyProperty FontWeightProperty { get; } = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(TextBlock), new FrameworkPropertyMetadata(FontWeights.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnFontWeightChanged();
	}));


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

	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(TextBlock), new FrameworkPropertyMetadata((object)string.Empty, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnTextChanged((string)e.OldValue, (string)e.NewValue);
	}, (CoerceValueCallback)CoerceText));


	public FontFamily FontFamily
	{
		get
		{
			return (FontFamily)GetValue(FontFamilyProperty);
		}
		set
		{
			SetValue(FontFamilyProperty, value);
		}
	}

	public static DependencyProperty FontFamilyProperty { get; } = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(TextBlock), new FrameworkPropertyMetadata(FontFamily.Default, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnFontFamilyChanged();
	}));


	public double FontSize
	{
		get
		{
			return (double)GetValue(FontSizeProperty);
		}
		set
		{
			SetValue(FontSizeProperty, value);
		}
	}

	public static DependencyProperty FontSizeProperty { get; } = DependencyProperty.Register("FontSize", typeof(double), typeof(TextBlock), new FrameworkPropertyMetadata(14.0, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnFontSizeChanged();
	}));


	public int MaxLines
	{
		get
		{
			return (int)GetValue(MaxLinesProperty);
		}
		set
		{
			SetValue(MaxLinesProperty, value);
		}
	}

	public static DependencyProperty MaxLinesProperty { get; } = DependencyProperty.Register("MaxLines", typeof(int), typeof(TextBlock), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnMaxLinesChanged();
	}));


	public TextTrimming TextTrimming
	{
		get
		{
			return (TextTrimming)GetValue(TextTrimmingProperty);
		}
		set
		{
			SetValue(TextTrimmingProperty, value);
		}
	}

	public static DependencyProperty TextTrimmingProperty { get; } = DependencyProperty.Register("TextTrimming", typeof(TextTrimming), typeof(TextBlock), new FrameworkPropertyMetadata(TextTrimming.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnTextTrimmingChanged();
	}));


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

	public static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(TextBlock), new FrameworkPropertyMetadata(SolidColorBrushHelper.Black, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnForegroundChanged();
	}));


	public bool IsTextSelectionEnabled
	{
		get
		{
			return (bool)GetValue(IsTextSelectionEnabledProperty);
		}
		set
		{
			SetValue(IsTextSelectionEnabledProperty, value);
		}
	}

	public static DependencyProperty IsTextSelectionEnabledProperty { get; } = DependencyProperty.Register("IsTextSelectionEnabled", typeof(bool), typeof(TextBlock), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnIsTextSelectionEnabledChangedPartial();
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

	public static DependencyProperty TextAlignmentProperty { get; } = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(TextBlock), new FrameworkPropertyMetadata(TextAlignment.Left, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnTextAlignmentChanged();
	}));


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

	public static DependencyProperty HorizontalTextAlignmentProperty { get; } = DependencyProperty.Register("HorizontalTextAlignment", typeof(TextAlignment), typeof(TextBlock), new FrameworkPropertyMetadata(TextAlignment.Left, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnHorizontalTextAlignmentChanged();
	}));


	public double LineHeight
	{
		get
		{
			return (double)GetValue(LineHeightProperty);
		}
		set
		{
			SetValue(LineHeightProperty, value);
		}
	}

	public static DependencyProperty LineHeightProperty { get; } = DependencyProperty.Register("LineHeight", typeof(double), typeof(TextBlock), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnLineHeightChanged();
	}));


	public LineStackingStrategy LineStackingStrategy
	{
		get
		{
			return (LineStackingStrategy)GetValue(LineStackingStrategyProperty);
		}
		set
		{
			SetValue(LineStackingStrategyProperty, value);
		}
	}

	public static DependencyProperty LineStackingStrategyProperty { get; } = DependencyProperty.Register("LineStackingStrategy", typeof(LineStackingStrategy), typeof(TextBlock), new FrameworkPropertyMetadata(LineStackingStrategy.MaxHeight, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnLineStackingStrategyChanged();
	}));


	public Thickness Padding
	{
		get
		{
			return (Thickness)GetValue(PaddingProperty);
		}
		set
		{
			SetValue(PaddingProperty, value);
		}
	}

	public static DependencyProperty PaddingProperty { get; } = DependencyProperty.Register("Padding", typeof(Thickness), typeof(TextBlock), new FrameworkPropertyMetadata(Thickness.Empty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnPaddingChanged();
	}));


	public int CharacterSpacing
	{
		get
		{
			return (int)GetValue(CharacterSpacingProperty);
		}
		set
		{
			SetValue(CharacterSpacingProperty, value);
		}
	}

	public static DependencyProperty CharacterSpacingProperty { get; } = DependencyProperty.Register("CharacterSpacing", typeof(int), typeof(TextBlock), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnCharacterSpacingChanged();
	}));


	public TextDecorations TextDecorations
	{
		get
		{
			return (TextDecorations)GetValue(TextDecorationsProperty);
		}
		set
		{
			SetValue(TextDecorationsProperty, value);
		}
	}

	public static DependencyProperty TextDecorationsProperty { get; } = DependencyProperty.Register("TextDecorations", typeof(uint), typeof(TextBlock), new FrameworkPropertyMetadata(TextDecorations.None, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextBlock)s).OnTextDecorationsChanged();
	}));


	private bool UseInlinesFastPath => _inlines == null;

	private bool IsLayoutConstrainedByMaxLines => MaxLines > 0;

	internal override bool IsFocusable
	{
		get
		{
			if (IsVisible() && (IsTextSelectionEnabled || base.IsTabStop))
			{
				return AreAllAncestorsVisible();
			}
			return false;
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event ContextMenuOpeningEventHandler ContextMenuOpening
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "event ContextMenuOpeningEventHandler TextBlock.ContextMenuOpening");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "event ContextMenuOpeningEventHandler TextBlock.ContextMenuOpening");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler SelectionChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "event RoutedEventHandler TextBlock.SelectionChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "event RoutedEventHandler TextBlock.SelectionChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TextBlock, IsTextTrimmedChangedEventArgs> IsTextTrimmedChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "event TypedEventHandler<TextBlock, IsTextTrimmedChangedEventArgs> TextBlock.IsTextTrimmedChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "event TypedEventHandler<TextBlock, IsTextTrimmedChangedEventArgs> TextBlock.IsTextTrimmedChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SelectAll()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "void TextBlock.SelectAll()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Select(TextPointer start, TextPointer end)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "void TextBlock.Select(TextPointer start, TextPointer end)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CompositionBrush GetAlphaMask()
	{
		throw new NotImplementedException("The member CompositionBrush TextBlock.GetAlphaMask() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CopySelectionToClipboard()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TextBlock", "void TextBlock.CopySelectionToClipboard()");
	}

	private void InitializeProperties()
	{
		OnForegroundChanged();
		OnFontFamilyChanged();
		OnFontWeightChanged();
		OnFontStyleChanged();
		OnFontSizeChanged();
		OnTextTrimmingChanged();
		OnTextWrappingChanged();
		OnMaxLinesChanged();
		OnTextAlignmentChanged();
		OnTextChanged(string.Empty, Text);
	}

	internal void InvalidateInlines()
	{
		OnInlinesChanged();
	}

	private void OnInlinesChanged()
	{
		Text = (_inlinesText = string.Concat(Inlines.Select(new Func<Inline, string>(InlineExtensions.GetText))));
		UpdateHyperlinks();
		InvalidateTextBlock();
	}

	private void OnFontStyleChanged()
	{
		OnFontStyleChangedPartial();
		InvalidateTextBlock();
	}

	private void OnFontStyleChangedPartial()
	{
		_fontStyleChanged = true;
	}

	private void OnTextWrappingChanged()
	{
		OnTextWrappingChangedPartial();
		InvalidateTextBlock();
	}

	private void OnTextWrappingChangedPartial()
	{
		_textWrappingChanged = true;
	}

	private void OnFontWeightChanged()
	{
		OnFontWeightChangedPartial();
		InvalidateTextBlock();
	}

	private void OnFontWeightChangedPartial()
	{
		_fontWeightChanged = true;
	}

	internal static object CoerceText(DependencyObject dependencyObject, object baseValue)
	{
		if (!(baseValue is string))
		{
			return string.Empty;
		}
		return baseValue;
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
		UpdateInlines(newValue);
		OnTextChangedPartial();
		InvalidateTextBlock();
	}

	private void OnTextChangedPartial()
	{
		_textChanged = true;
		UpdateHitTest();
	}

	private void OnFontFamilyChanged()
	{
		OnFontFamilyChangedPartial();
		InvalidateTextBlock();
	}

	private void OnFontFamilyChangedPartial()
	{
		_fontFamilyChanged = true;
	}

	private void OnFontSizeChanged()
	{
		OnFontSizeChangedPartial();
		InvalidateTextBlock();
	}

	private void OnFontSizeChangedPartial()
	{
		_fontSizeChanged = true;
	}

	private void OnMaxLinesChanged()
	{
		OnMaxLinesChangedPartial();
		InvalidateTextBlock();
	}

	private void OnMaxLinesChangedPartial()
	{
		_maxLinesChanged = true;
	}

	private void OnTextTrimmingChanged()
	{
		OnTextTrimmingChangedPartial();
		InvalidateTextBlock();
	}

	private void OnTextTrimmingChangedPartial()
	{
		_textTrimmingChanged = true;
	}

	private void OnForegroundChanged()
	{
		_foregroundChanged.Disposable = null;
		Brush foreground = Foreground;
		if (foreground != null && foreground.SupportsAssignAndObserveBrush)
		{
			_foregroundChanged.Disposable = Brush.AssignAndObserveBrush(Foreground, delegate
			{
				refreshForeground();
			}, refreshForeground);
		}
		refreshForeground();
		void refreshForeground()
		{
			OnForegroundChangedPartial();
			InvalidateTextBlock();
		}
	}

	private void OnForegroundChangedPartial()
	{
		SetForeground(Foreground);
	}

	private void OnIsTextSelectionEnabledChangedPartial()
	{
		if (IsTextSelectionEnabled)
		{
			SetCssClasses("selectionEnabled");
		}
		else
		{
			UnsetCssClasses("selectionEnabled");
		}
	}

	private void OnTextAlignmentChanged()
	{
		HorizontalTextAlignment = TextAlignment;
		OnTextAlignmentChangedPartial();
		InvalidateTextBlock();
	}

	private void OnTextAlignmentChangedPartial()
	{
		_textAlignmentChanged = true;
	}

	private void OnHorizontalTextAlignmentChanged()
	{
		TextAlignment = HorizontalTextAlignment;
	}

	private void OnLineHeightChanged()
	{
		OnLineHeightChangedPartial();
		InvalidateTextBlock();
	}

	private void OnLineHeightChangedPartial()
	{
		_lineHeightChanged = true;
	}

	private void OnLineStackingStrategyChanged()
	{
		InvalidateTextBlock();
	}

	private void OnPaddingChanged()
	{
		OnPaddingChangedPartial();
		InvalidateTextBlock();
	}

	private void OnPaddingChangedPartial()
	{
		_paddingChangedChanged = true;
	}

	private void OnCharacterSpacingChanged()
	{
		OnCharacterSpacingChangedPartial();
		InvalidateTextBlock();
	}

	private void OnCharacterSpacingChangedPartial()
	{
		_characterSpacingChanged = true;
	}

	private void OnTextDecorationsChanged()
	{
		OnTextDecorationsChangedPartial();
		InvalidateTextBlock();
	}

	private void OnTextDecorationsChangedPartial()
	{
		_textDecorationsChanged = true;
	}

	private IEnumerable<(Inline inline, int start, int end)> GetEffectiveInlines()
	{
		if (UseInlinesFastPath)
		{
			yield break;
		}
		int start = 0;
		foreach (Inline inline in Inlines.SelectMany(new Func<Inline, IEnumerable<Inline>>(InlineExtensions.Enumerate)))
		{
			if (inline.HasTypographicalEffectWithin(this))
			{
				yield return (inline, start, start + inline.GetText().Length);
			}
			if (inline is Run || inline is LineBreak)
			{
				start += inline.GetText().Length;
			}
		}
	}

	private void UpdateInlines(string text)
	{
		if (!UseInlinesFastPath)
		{
			if (ReadLocalValue(TextProperty) is UnsetValue)
			{
				Inlines.Clear();
				ClearTextPartial();
			}
			else if (text != _inlinesText)
			{
				Inlines.Clear();
				ClearTextPartial();
				Inlines.Add(new Run
				{
					Text = text
				});
			}
		}
	}

	private void ClearTextPartial()
	{
		SetHtmlContent("");
	}

	private void UpdateHyperlinks()
	{
	}

	private void InvalidateTextBlock()
	{
		InvalidateMeasure();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new TextBlockAutomationPeer(this);
	}

	public override string GetAccessibilityInnerText()
	{
		return Text;
	}

	private protected override double GetActualWidth()
	{
		return base.DesiredSize.Width;
	}

	private protected override double GetActualHeight()
	{
		return base.DesiredSize.Height;
	}

	internal override void UpdateThemeBindings(ResourceUpdateReason updateReason)
	{
		base.UpdateThemeBindings(updateReason);
		SetDefaultForeground(ForegroundProperty);
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}

	public new bool Focus(FocusState value)
	{
		return base.Focus(value);
	}

	internal override bool IsViewHit()
	{
		if (Text == null)
		{
			return base.IsViewHit();
		}
		return true;
	}

	public TextBlock()
		: base("p")
	{
		OnFontStyleChangedPartial();
		OnFontWeightChangedPartial();
		OnTextChangedPartial();
		OnFontFamilyChangedPartial();
		OnFontSizeChangedPartial();
		OnCharacterSpacingChangedPartial();
		OnLineHeightChangedPartial();
		OnTextAlignmentChangedPartial();
		OnTextWrappingChangedPartial();
		OnIsTextSelectionEnabledChangedPartial();
		InitializeDefaultValues();
	}

	private void InitializeDefaultValues()
	{
		this.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top, DependencyPropertyValuePrecedences.DefaultValue);
	}

	private void ConditionalUpdate(ref bool condition, Action action)
	{
		if (condition)
		{
			condition = false;
			action();
		}
	}

	private void SynchronizeHtmlParagraphAttributes()
	{
		ConditionalUpdate(ref _fontStyleChanged, delegate
		{
			SetFontStyle(FontStyle);
		});
		ConditionalUpdate(ref _fontWeightChanged, delegate
		{
			SetFontWeight(FontWeight);
		});
		ConditionalUpdate(ref _fontFamilyChanged, delegate
		{
			SetFontFamily(FontFamily);
		});
		ConditionalUpdate(ref _fontSizeChanged, delegate
		{
			SetFontSize(FontSize);
		});
		ConditionalUpdate(ref _maxLinesChanged, delegate
		{
			SetMaxLines(MaxLines);
		});
		ConditionalUpdate(ref _textAlignmentChanged, delegate
		{
			SetTextAlignment(TextAlignment);
		});
		ConditionalUpdate(ref _lineHeightChanged, delegate
		{
			SetLineHeight(LineHeight);
		});
		ConditionalUpdate(ref _characterSpacingChanged, delegate
		{
			SetCharacterSpacing(CharacterSpacing);
		});
		ConditionalUpdate(ref _textDecorationsChanged, delegate
		{
			SetTextDecorations(TextDecorations);
		});
		ConditionalUpdate(ref _paddingChangedChanged, delegate
		{
			SetTextPadding(Padding);
		});
		if (_textTrimmingChanged || _textWrappingChanged)
		{
			_textTrimmingChanged = (_textWrappingChanged = false);
			SetTextWrappingAndTrimming(textTrimming: TextTrimming, textWrapping: TextWrapping);
		}
		if (_textChanged)
		{
			_textChanged = false;
			if (UseInlinesFastPath)
			{
				SetText(Text);
			}
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		SynchronizeHtmlParagraphAttributes();
		if (UseInlinesFastPath)
		{
			Size? size = _cache.FindMeasuredSize(this, availableSize);
			Size valueOrDefault;
			if (size.HasValue)
			{
				valueOrDefault = size.GetValueOrDefault();
				UnoMetrics.TextBlock.MeasureCacheHits++;
				return valueOrDefault;
			}
			UnoMetrics.TextBlock.MeasureCacheMisses++;
			valueOrDefault = MeasureView(availableSize);
			_cache.CacheMeasure(this, availableSize, valueOrDefault);
			return valueOrDefault;
		}
		return MeasureView(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size finalSize2;
		if (IsLayoutConstrainedByMaxLines)
		{
			finalSize2 = base.DesiredSize;
			if (base.HorizontalAlignment == HorizontalAlignment.Stretch)
			{
				finalSize2.Width = finalSize.Width;
			}
		}
		else
		{
			finalSize2 = finalSize;
		}
		return base.ArrangeOverride(finalSize2);
	}

	private int GetCharacterIndexAtPoint(Point point)
	{
		throw new NotSupportedException();
	}
}

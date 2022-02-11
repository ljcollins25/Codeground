using System;
using Uno;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Documents;

public abstract class TextElement : UIElement, DependencyObject
{
	public static DependencyProperty BaseLineAlignmentProperty = DependencyProperty.Register("BaseLineAlignment", typeof(BaseLineAlignment), typeof(TextElement), new FrameworkPropertyMetadata(BaseLineAlignment.Baseline, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnBaseLineAlignmentChanged();
	}));

	private bool _AllowFocusOnInteractionPropertyBackingFieldSet;

	private bool _AllowFocusOnInteractionPropertyBackingField;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string Language
	{
		get
		{
			return (string)GetValue(LanguageProperty);
		}
		set
		{
			SetValue(LanguageProperty, value);
		}
	}

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
	public TextPointer ContentEnd
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextElement.ContentEnd is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer ContentStart
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextElement.ContentStart is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer ElementEnd
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextElement.ElementEnd is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer ElementStart
	{
		get
		{
			throw new NotImplementedException("The member TextPointer TextElement.ElementStart is not implemented in Uno.");
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
	public new bool ExitDisplayModeOnAccessKeyInvoked
	{
		get
		{
			return (bool)GetValue(ExitDisplayModeOnAccessKeyInvokedProperty);
		}
		set
		{
			SetValue(ExitDisplayModeOnAccessKeyInvokedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new string AccessKey
	{
		get
		{
			return (string)GetValue(AccessKeyProperty);
		}
		set
		{
			SetValue(AccessKeyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new double KeyTipVerticalOffset
	{
		get
		{
			return (double)GetValue(KeyTipVerticalOffsetProperty);
		}
		set
		{
			SetValue(KeyTipVerticalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new KeyTipPlacementMode KeyTipPlacementMode
	{
		get
		{
			return (KeyTipPlacementMode)GetValue(KeyTipPlacementModeProperty);
		}
		set
		{
			SetValue(KeyTipPlacementModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new double KeyTipHorizontalOffset
	{
		get
		{
			return (double)GetValue(KeyTipHorizontalOffsetProperty);
		}
		set
		{
			SetValue(KeyTipHorizontalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new bool IsAccessKeyScope
	{
		get
		{
			return (bool)GetValue(IsAccessKeyScopeProperty);
		}
		set
		{
			SetValue(IsAccessKeyScopeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new DependencyObject AccessKeyScopeOwner
	{
		get
		{
			return (DependencyObject)GetValue(AccessKeyScopeOwnerProperty);
		}
		set
		{
			SetValue(AccessKeyScopeOwnerProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FontStretchProperty { get; } = DependencyProperty.Register("FontStretch", typeof(FontStretch), typeof(TextElement), new FrameworkPropertyMetadata(FontStretch.Undefined));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LanguageProperty { get; } = DependencyProperty.Register("Language", typeof(string), typeof(TextElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } = DependencyProperty.Register("IsTextScaleFactorEnabled", typeof(bool), typeof(TextElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty AccessKeyProperty { get; } = DependencyProperty.Register("AccessKey", typeof(string), typeof(TextElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty ExitDisplayModeOnAccessKeyInvokedProperty { get; } = DependencyProperty.Register("ExitDisplayModeOnAccessKeyInvoked", typeof(bool), typeof(TextElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty AccessKeyScopeOwnerProperty { get; } = DependencyProperty.Register("AccessKeyScopeOwner", typeof(DependencyObject), typeof(TextElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty IsAccessKeyScopeProperty { get; } = DependencyProperty.Register("IsAccessKeyScope", typeof(bool), typeof(TextElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty KeyTipHorizontalOffsetProperty { get; } = DependencyProperty.Register("KeyTipHorizontalOffset", typeof(double), typeof(TextElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty KeyTipPlacementModeProperty { get; } = DependencyProperty.Register("KeyTipPlacementMode", typeof(KeyTipPlacementMode), typeof(TextElement), new FrameworkPropertyMetadata(KeyTipPlacementMode.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty KeyTipVerticalOffsetProperty { get; } = DependencyProperty.Register("KeyTipVerticalOffset", typeof(double), typeof(TextElement), new FrameworkPropertyMetadata(0.0));


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

	public static DependencyProperty FontFamilyProperty { get; } = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(TextElement), new FrameworkPropertyMetadata(FontFamily.Default, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnFontFamilyChanged();
	}));


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

	public static DependencyProperty FontStyleProperty { get; } = DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(TextElement), new FrameworkPropertyMetadata(FontStyle.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnFontStyleChanged();
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

	public static DependencyProperty FontSizeProperty { get; } = DependencyProperty.Register("FontSize", typeof(double), typeof(TextElement), new FrameworkPropertyMetadata(14.0, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnFontSizeChanged();
	}));


	public Brush Foreground
	{
		get
		{
			return (Brush)GetValue(ForegroundProperty);
		}
		set
		{
			if (value != null && !(value is SolidColorBrush))
			{
				throw new InvalidOperationException("Specified brush is not a SolidColorBrush");
			}
			SetValue(ForegroundProperty, value);
		}
	}

	public static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(TextElement), new FrameworkPropertyMetadata(SolidColorBrushHelper.Black, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnForegroundChanged();
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

	public static DependencyProperty FontWeightProperty { get; } = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(TextElement), new FrameworkPropertyMetadata(FontWeights.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnFontWeightChanged();
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

	public static DependencyProperty CharacterSpacingProperty { get; } = DependencyProperty.Register("CharacterSpacing", typeof(int), typeof(TextElement), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnCharacterSpacingChanged();
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

	public static DependencyProperty TextDecorationsProperty { get; } = DependencyProperty.Register("TextDecorations", typeof(uint), typeof(TextElement), new FrameworkPropertyMetadata(TextDecorations.None, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TextElement)s).OnTextDecorationsChanged();
	}));


	public BaseLineAlignment BaseLineAlignment
	{
		get
		{
			return (BaseLineAlignment)GetValue(BaseLineAlignmentProperty);
		}
		set
		{
			SetValue(BaseLineAlignmentProperty, value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = true, Options = FrameworkPropertyMetadataOptions.Inherits)]
	public static DependencyProperty AllowFocusOnInteractionProperty { get; } = CreateAllowFocusOnInteractionProperty();


	public bool AllowFocusOnInteraction
	{
		get
		{
			return GetAllowFocusOnInteractionValue();
		}
		set
		{
			SetAllowFocusOnInteractionValue(value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new event TypedEventHandler<TextElement, AccessKeyDisplayDismissedEventArgs> AccessKeyDisplayDismissed
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextElement", "event TypedEventHandler<TextElement, AccessKeyDisplayDismissedEventArgs> TextElement.AccessKeyDisplayDismissed");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextElement", "event TypedEventHandler<TextElement, AccessKeyDisplayDismissedEventArgs> TextElement.AccessKeyDisplayDismissed");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new event TypedEventHandler<TextElement, AccessKeyDisplayRequestedEventArgs> AccessKeyDisplayRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextElement", "event TypedEventHandler<TextElement, AccessKeyDisplayRequestedEventArgs> TextElement.AccessKeyDisplayRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextElement", "event TypedEventHandler<TextElement, AccessKeyDisplayRequestedEventArgs> TextElement.AccessKeyDisplayRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new event TypedEventHandler<TextElement, AccessKeyInvokedEventArgs> AccessKeyInvoked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextElement", "event TypedEventHandler<TextElement, AccessKeyInvokedEventArgs> TextElement.AccessKeyInvoked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextElement", "event TypedEventHandler<TextElement, AccessKeyInvokedEventArgs> TextElement.AccessKeyInvoked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object FindName(string name)
	{
		throw new NotImplementedException("The member object TextElement.FindName(string name) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected new virtual void OnDisconnectVisualChildren()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.TextElement", "void TextElement.OnDisconnectVisualChildren()");
	}

	protected virtual void OnFontFamilyChanged()
	{
		OnFontFamilyChangedPartial();
	}

	private void OnFontFamilyChangedPartial()
	{
		SetFontFamily(ReadLocalValue(FontFamilyProperty));
	}

	protected virtual void OnFontStyleChanged()
	{
		OnFontStyleChangedPartial();
	}

	private void OnFontStyleChangedPartial()
	{
		SetFontStyle(ReadLocalValue(FontStyleProperty));
	}

	protected virtual void OnFontSizeChanged()
	{
		OnFontSizeChangedPartial();
	}

	private void OnFontSizeChangedPartial()
	{
		SetFontSize(ReadLocalValue(FontSizeProperty));
	}

	protected virtual void OnForegroundChanged()
	{
		OnForegroundChangedPartial();
	}

	private void OnForegroundChangedPartial()
	{
		SetForeground(ReadLocalValue(ForegroundProperty));
	}

	protected virtual void OnFontWeightChanged()
	{
		OnFontWeightChangedPartial();
	}

	private void OnFontWeightChangedPartial()
	{
		SetFontWeight(ReadLocalValue(FontWeightProperty));
	}

	protected virtual void OnCharacterSpacingChanged()
	{
		OnCharacterSpacingChangedPartial();
	}

	private void OnCharacterSpacingChangedPartial()
	{
		SetCharacterSpacing(ReadLocalValue(CharacterSpacingProperty));
	}

	protected virtual void OnTextDecorationsChanged()
	{
		OnTextDecorationsChangedPartial();
	}

	private void OnTextDecorationsChangedPartial()
	{
		SetTextDecorations(ReadLocalValue(TextDecorationsProperty));
	}

	protected virtual void OnBaseLineAlignmentChanged()
	{
		OnBaseLineAlignmentChangedPartial();
	}

	private void OnBaseLineAlignmentChangedPartial()
	{
	}

	internal FrameworkElement GetContainingFrameworkElement()
	{
		object parent = this.GetParent();
		while (parent != null && !(parent is RichTextBlock) && !(parent is TextBlock))
		{
			parent = parent.GetParent();
		}
		return parent as FrameworkElement;
	}

	protected TextElement(string htmlTag = "span")
		: base(htmlTag)
	{
	}

	private bool GetAllowFocusOnInteractionValue()
	{
		if (!_AllowFocusOnInteractionPropertyBackingFieldSet)
		{
			_AllowFocusOnInteractionPropertyBackingField = (bool)GetValue(AllowFocusOnInteractionProperty);
			_AllowFocusOnInteractionPropertyBackingFieldSet = true;
		}
		return _AllowFocusOnInteractionPropertyBackingField;
	}

	private void SetAllowFocusOnInteractionValue(bool value)
	{
		SetValue(AllowFocusOnInteractionProperty, value);
	}

	private static DependencyProperty CreateAllowFocusOnInteractionProperty()
	{
		return DependencyProperty.Register("AllowFocusOnInteraction", typeof(bool), typeof(TextElement), new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.Inherits, (BackingFieldUpdateCallback)OnAllowFocusOnInteractionBackingFieldUpdate));
	}

	private static void OnAllowFocusOnInteractionBackingFieldUpdate(object instance, object newValue)
	{
		TextElement textElement = instance as TextElement;
		textElement._AllowFocusOnInteractionPropertyBackingField = (bool)newValue;
		textElement._AllowFocusOnInteractionPropertyBackingFieldSet = true;
	}
}

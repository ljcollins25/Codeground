using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Documents;

[NotImplemented]
public class ContentLink : Inline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new XYFocusNavigationStrategy XYFocusUpNavigationStrategy
	{
		get
		{
			return (XYFocusNavigationStrategy)GetValue(XYFocusUpNavigationStrategyProperty);
		}
		set
		{
			SetValue(XYFocusUpNavigationStrategyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new DependencyObject XYFocusUp
	{
		get
		{
			return (DependencyObject)GetValue(XYFocusUpProperty);
		}
		set
		{
			SetValue(XYFocusUpProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new XYFocusNavigationStrategy XYFocusRightNavigationStrategy
	{
		get
		{
			return (XYFocusNavigationStrategy)GetValue(XYFocusRightNavigationStrategyProperty);
		}
		set
		{
			SetValue(XYFocusRightNavigationStrategyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new DependencyObject XYFocusRight
	{
		get
		{
			return (DependencyObject)GetValue(XYFocusRightProperty);
		}
		set
		{
			SetValue(XYFocusRightProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new XYFocusNavigationStrategy XYFocusLeftNavigationStrategy
	{
		get
		{
			return (XYFocusNavigationStrategy)GetValue(XYFocusLeftNavigationStrategyProperty);
		}
		set
		{
			SetValue(XYFocusLeftNavigationStrategyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new DependencyObject XYFocusLeft
	{
		get
		{
			return (DependencyObject)GetValue(XYFocusLeftProperty);
		}
		set
		{
			SetValue(XYFocusLeftProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new XYFocusNavigationStrategy XYFocusDownNavigationStrategy
	{
		get
		{
			return (XYFocusNavigationStrategy)GetValue(XYFocusDownNavigationStrategyProperty);
		}
		set
		{
			SetValue(XYFocusDownNavigationStrategyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new DependencyObject XYFocusDown
	{
		get
		{
			return (DependencyObject)GetValue(XYFocusDownProperty);
		}
		set
		{
			SetValue(XYFocusDownProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new int TabIndex
	{
		get
		{
			return (int)GetValue(TabIndexProperty);
		}
		set
		{
			SetValue(TabIndexProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new bool IsTabStop
	{
		get
		{
			return (bool)GetValue(IsTabStopProperty);
		}
		set
		{
			SetValue(IsTabStopProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ContentLinkInfo Info
	{
		get
		{
			throw new NotImplementedException("The member ContentLinkInfo ContentLink.Info is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "ContentLinkInfo ContentLink.Info");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ElementSoundMode ElementSoundMode
	{
		get
		{
			return (ElementSoundMode)GetValue(ElementSoundModeProperty);
		}
		set
		{
			SetValue(ElementSoundModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CoreCursorType Cursor
	{
		get
		{
			return (CoreCursorType)GetValue(CursorProperty);
		}
		set
		{
			SetValue(CursorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush Background
	{
		get
		{
			return (Brush)GetValue(BackgroundProperty);
		}
		set
		{
			SetValue(BackgroundProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new FocusState FocusState => (FocusState)GetValue(FocusStateProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty BackgroundProperty { get; } = DependencyProperty.Register("Background", typeof(Brush), typeof(ContentLink), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CursorProperty { get; } = DependencyProperty.Register("Cursor", typeof(CoreCursorType), typeof(ContentLink), new FrameworkPropertyMetadata(CoreCursorType.Arrow));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ElementSoundModeProperty { get; } = DependencyProperty.Register("ElementSoundMode", typeof(ElementSoundMode), typeof(ContentLink), new FrameworkPropertyMetadata(ElementSoundMode.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty FocusStateProperty { get; } = DependencyProperty.Register("FocusState", typeof(FocusState), typeof(ContentLink), new FrameworkPropertyMetadata(FocusState.Unfocused));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty IsTabStopProperty { get; } = DependencyProperty.Register("IsTabStop", typeof(bool), typeof(ContentLink), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty TabIndexProperty { get; } = DependencyProperty.Register("TabIndex", typeof(int), typeof(ContentLink), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusDownNavigationStrategyProperty { get; } = DependencyProperty.Register("XYFocusDownNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(ContentLink), new FrameworkPropertyMetadata(XYFocusNavigationStrategy.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusDownProperty { get; } = DependencyProperty.Register("XYFocusDown", typeof(DependencyObject), typeof(ContentLink), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusLeftNavigationStrategyProperty { get; } = DependencyProperty.Register("XYFocusLeftNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(ContentLink), new FrameworkPropertyMetadata(XYFocusNavigationStrategy.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusLeftProperty { get; } = DependencyProperty.Register("XYFocusLeft", typeof(DependencyObject), typeof(ContentLink), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusRightNavigationStrategyProperty { get; } = DependencyProperty.Register("XYFocusRightNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(ContentLink), new FrameworkPropertyMetadata(XYFocusNavigationStrategy.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusRightProperty { get; } = DependencyProperty.Register("XYFocusRight", typeof(DependencyObject), typeof(ContentLink), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusUpNavigationStrategyProperty { get; } = DependencyProperty.Register("XYFocusUpNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(ContentLink), new FrameworkPropertyMetadata(XYFocusNavigationStrategy.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty XYFocusUpProperty { get; } = DependencyProperty.Register("XYFocusUp", typeof(DependencyObject), typeof(ContentLink), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new event RoutedEventHandler GotFocus
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "event RoutedEventHandler ContentLink.GotFocus");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "event RoutedEventHandler ContentLink.GotFocus");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ContentLink, ContentLinkInvokedEventArgs> Invoked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "event TypedEventHandler<ContentLink, ContentLinkInvokedEventArgs> ContentLink.Invoked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "event TypedEventHandler<ContentLink, ContentLinkInvokedEventArgs> ContentLink.Invoked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new event RoutedEventHandler LostFocus
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "event RoutedEventHandler ContentLink.LostFocus");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "event RoutedEventHandler ContentLink.LostFocus");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ContentLink()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.ContentLink", "ContentLink.ContentLink()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new bool Focus(FocusState value)
	{
		throw new NotImplementedException("The member bool ContentLink.Focus(FocusState value) is not implemented in Uno.");
	}
}

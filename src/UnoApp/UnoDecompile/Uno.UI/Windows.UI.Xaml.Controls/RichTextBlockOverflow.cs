using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Documents;

namespace Windows.UI.Xaml.Controls;

public class RichTextBlockOverflow : FrameworkElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RichTextBlockOverflow OverflowContentTarget
	{
		get
		{
			return (RichTextBlockOverflow)GetValue(OverflowContentTargetProperty);
		}
		set
		{
			SetValue(OverflowContentTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double BaselineOffset
	{
		get
		{
			throw new NotImplementedException("The member double RichTextBlockOverflow.BaselineOffset is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer ContentEnd
	{
		get
		{
			throw new NotImplementedException("The member TextPointer RichTextBlockOverflow.ContentEnd is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RichTextBlock ContentSource
	{
		get
		{
			throw new NotImplementedException("The member RichTextBlock RichTextBlockOverflow.ContentSource is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer ContentStart
	{
		get
		{
			throw new NotImplementedException("The member TextPointer RichTextBlockOverflow.ContentStart is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool HasOverflowContent => (bool)GetValue(HasOverflowContentProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsTextTrimmed => (bool)GetValue(IsTextTrimmedProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HasOverflowContentProperty { get; } = DependencyProperty.Register("HasOverflowContent", typeof(bool), typeof(RichTextBlockOverflow), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OverflowContentTargetProperty { get; } = DependencyProperty.Register("OverflowContentTarget", typeof(RichTextBlockOverflow), typeof(RichTextBlockOverflow), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PaddingProperty { get; } = DependencyProperty.Register("Padding", typeof(Thickness), typeof(RichTextBlockOverflow), new FrameworkPropertyMetadata(default(Thickness)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxLinesProperty { get; } = DependencyProperty.Register("MaxLines", typeof(int), typeof(RichTextBlockOverflow), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextTrimmedProperty { get; } = DependencyProperty.Register("IsTextTrimmed", typeof(bool), typeof(RichTextBlockOverflow), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<RichTextBlockOverflow, IsTextTrimmedChangedEventArgs> IsTextTrimmedChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichTextBlockOverflow", "event TypedEventHandler<RichTextBlockOverflow, IsTextTrimmedChangedEventArgs> RichTextBlockOverflow.IsTextTrimmedChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RichTextBlockOverflow", "event TypedEventHandler<RichTextBlockOverflow, IsTextTrimmedChangedEventArgs> RichTextBlockOverflow.IsTextTrimmedChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TextPointer GetPositionFromPoint(Point point)
	{
		throw new NotImplementedException("The member TextPointer RichTextBlockOverflow.GetPositionFromPoint(Point point) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new bool Focus(FocusState value)
	{
		throw new NotImplementedException("The member bool RichTextBlockOverflow.Focus(FocusState value) is not implemented in Uno.");
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}
}

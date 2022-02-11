using System;
using System.Windows.Input;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[Obsolete("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.SplitButton instead.")]
public class SplitButton : ContentControl
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlyoutBase Flyout
	{
		get
		{
			return (FlyoutBase)GetValue(FlyoutProperty);
		}
		set
		{
			SetValue(FlyoutProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object CommandParameter
	{
		get
		{
			return GetValue(CommandParameterProperty);
		}
		set
		{
			SetValue(CommandParameterProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ICommand Command
	{
		get
		{
			return (ICommand)GetValue(CommandProperty);
		}
		set
		{
			SetValue(CommandProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CommandParameterProperty { get; } = DependencyProperty.Register("CommandParameter", typeof(object), typeof(SplitButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CommandProperty { get; } = DependencyProperty.Register("Command", typeof(ICommand), typeof(SplitButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FlyoutProperty { get; } = DependencyProperty.Register("Flyout", typeof(FlyoutBase), typeof(SplitButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<SplitButton, SplitButtonClickEventArgs> Click
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SplitButton", "event TypedEventHandler<SplitButton, SplitButtonClickEventArgs> SplitButton.Click");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SplitButton", "event TypedEventHandler<SplitButton, SplitButtonClickEventArgs> SplitButton.Click");
		}
	}

	public SplitButton()
	{
		throw new NotImplementedException("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.SplitButton instead.");
	}
}

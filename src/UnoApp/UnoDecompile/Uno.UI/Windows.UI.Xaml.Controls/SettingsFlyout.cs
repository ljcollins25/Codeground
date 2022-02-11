using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class SettingsFlyout : ContentControl
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string Title
	{
		get
		{
			return (string)GetValue(TitleProperty);
		}
		set
		{
			SetValue(TitleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource IconSource
	{
		get
		{
			return (ImageSource)GetValue(IconSourceProperty);
		}
		set
		{
			SetValue(IconSourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush HeaderForeground
	{
		get
		{
			return (Brush)GetValue(HeaderForegroundProperty);
		}
		set
		{
			SetValue(HeaderForegroundProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush HeaderBackground
	{
		get
		{
			return (Brush)GetValue(HeaderBackgroundProperty);
		}
		set
		{
			SetValue(HeaderBackgroundProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SettingsFlyoutTemplateSettings TemplateSettings
	{
		get
		{
			throw new NotImplementedException("The member SettingsFlyoutTemplateSettings SettingsFlyout.TemplateSettings is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderBackgroundProperty { get; } = DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(SettingsFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderForegroundProperty { get; } = DependencyProperty.Register("HeaderForeground", typeof(Brush), typeof(SettingsFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IconSourceProperty { get; } = DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(SettingsFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TitleProperty { get; } = DependencyProperty.Register("Title", typeof(string), typeof(SettingsFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event BackClickEventHandler BackClick
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SettingsFlyout", "event BackClickEventHandler SettingsFlyout.BackClick");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SettingsFlyout", "event BackClickEventHandler SettingsFlyout.BackClick");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SettingsFlyout()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SettingsFlyout", "SettingsFlyout.SettingsFlyout()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Show()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SettingsFlyout", "void SettingsFlyout.Show()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ShowIndependent()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SettingsFlyout", "void SettingsFlyout.ShowIndependent()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Hide()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SettingsFlyout", "void SettingsFlyout.Hide()");
	}
}

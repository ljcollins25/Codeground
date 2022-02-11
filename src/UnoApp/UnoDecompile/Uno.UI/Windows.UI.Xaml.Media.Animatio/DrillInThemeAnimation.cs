using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class DrillInThemeAnimation : Timeline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string ExitTargetName
	{
		get
		{
			return (string)GetValue(ExitTargetNameProperty);
		}
		set
		{
			SetValue(ExitTargetNameProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject ExitTarget
	{
		get
		{
			return (DependencyObject)GetValue(ExitTargetProperty);
		}
		set
		{
			SetValue(ExitTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string EntranceTargetName
	{
		get
		{
			return (string)GetValue(EntranceTargetNameProperty);
		}
		set
		{
			SetValue(EntranceTargetNameProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject EntranceTarget
	{
		get
		{
			return (DependencyObject)GetValue(EntranceTargetProperty);
		}
		set
		{
			SetValue(EntranceTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty EntranceTargetNameProperty { get; } = DependencyProperty.Register("EntranceTargetName", typeof(string), typeof(DrillInThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty EntranceTargetProperty { get; } = DependencyProperty.Register("EntranceTarget", typeof(DependencyObject), typeof(DrillInThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ExitTargetNameProperty { get; } = DependencyProperty.Register("ExitTargetName", typeof(string), typeof(DrillInThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ExitTargetProperty { get; } = DependencyProperty.Register("ExitTarget", typeof(DependencyObject), typeof(DrillInThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DrillInThemeAnimation()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.DrillInThemeAnimation", "DrillInThemeAnimation.DrillInThemeAnimation()");
	}
}

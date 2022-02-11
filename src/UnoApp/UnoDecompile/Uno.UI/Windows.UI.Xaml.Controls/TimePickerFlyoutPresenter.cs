using Uno;

namespace Windows.UI.Xaml.Controls;

public class TimePickerFlyoutPresenter : FlyoutPresenter
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new bool IsDefaultShadowEnabled
	{
		get
		{
			return (bool)GetValue(IsDefaultShadowEnabledProperty);
		}
		set
		{
			SetValue(IsDefaultShadowEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new static DependencyProperty IsDefaultShadowEnabledProperty { get; } = DependencyProperty.Register("IsDefaultShadowEnabled", typeof(bool), typeof(TimePickerFlyoutPresenter), new FrameworkPropertyMetadata(false));


	public TimePickerFlyoutPresenter()
	{
		base.DefaultStyleKey = typeof(TimePickerFlyoutPresenter);
	}
}

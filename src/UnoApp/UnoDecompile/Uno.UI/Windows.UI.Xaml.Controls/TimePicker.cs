using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Globalization;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class TimePicker : Control
{
	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public TimeSpan Time
	{
		get
		{
			return (TimeSpan)GetValue(TimeProperty);
		}
		set
		{
			SetValue(TimeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public int MinuteIncrement
	{
		get
		{
			return (int)GetValue(MinuteIncrementProperty);
		}
		set
		{
			SetValue(MinuteIncrementProperty, value);
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
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

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
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

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public LightDismissOverlayMode LightDismissOverlayMode
	{
		get
		{
			return (LightDismissOverlayMode)GetValue(LightDismissOverlayModeProperty);
		}
		set
		{
			SetValue(LightDismissOverlayModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TimeSpan? SelectedTime
	{
		get
		{
			return (TimeSpan?)GetValue(SelectedTimeProperty);
		}
		set
		{
			SetValue(SelectedTimeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(TimePicker), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(TimePicker), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty MinuteIncrementProperty { get; } = DependencyProperty.Register("MinuteIncrement", typeof(int), typeof(TimePicker), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty TimeProperty { get; } = DependencyProperty.Register("Time", typeof(TimeSpan), typeof(TimePicker), new FrameworkPropertyMetadata(default(TimeSpan)));


	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(TimePicker), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedTimeProperty { get; } = DependencyProperty.Register("SelectedTime", typeof(TimeSpan?), typeof(TimePicker), new FrameworkPropertyMetadata((object)null));


	public string ClockIdentifier
	{
		get
		{
			return (string)GetValue(ClockIdentifierProperty);
		}
		set
		{
			SetValue(ClockIdentifierProperty, value);
		}
	}

	public static DependencyProperty ClockIdentifierProperty { get; } = DependencyProperty.Register("ClockIdentifier", typeof(string), typeof(TimePicker), new FrameworkPropertyMetadata(ClockIdentifiers.TwelveHour, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimePicker)s)?.OnClockIdentifierChanged((string)e.OldValue, (string)e.NewValue);
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<TimePickerValueChangedEventArgs> TimeChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TimePicker", "event EventHandler<TimePickerValueChangedEventArgs> TimePicker.TimeChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TimePicker", "event EventHandler<TimePickerValueChangedEventArgs> TimePicker.TimeChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TimePicker, TimePickerSelectedValueChangedEventArgs> SelectedTimeChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TimePicker", "event TypedEventHandler<TimePicker, TimePickerSelectedValueChangedEventArgs> TimePicker.SelectedTimeChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TimePicker", "event TypedEventHandler<TimePicker, TimePickerSelectedValueChangedEventArgs> TimePicker.SelectedTimeChanged");
		}
	}

	protected virtual void OnClockIdentifierChanged(string oldClockIdentifier, string newClockIdentifier)
	{
	}
}

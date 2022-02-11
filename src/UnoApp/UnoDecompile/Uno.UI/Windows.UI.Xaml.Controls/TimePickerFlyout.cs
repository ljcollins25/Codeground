using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Globalization;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class TimePickerFlyout : PickerFlyoutBase
{
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

	public static DependencyProperty TimeProperty { get; } = DependencyProperty.Register("Time", typeof(TimeSpan), typeof(TimePickerFlyout), new FrameworkPropertyMetadata(DateTime.Now.TimeOfDay, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimePickerFlyout)s)?.OnTimeChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
	}));


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

	public static DependencyProperty MinuteIncrementProperty { get; } = DependencyProperty.Register("MinuteIncrement", typeof(int), typeof(TimePickerFlyout), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimePickerFlyout)s)?.OnMinuteIncrementChanged((int)e.OldValue, (int)e.NewValue);
	}));


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

	public static DependencyProperty ClockIdentifierProperty { get; } = DependencyProperty.Register("ClockIdentifier", typeof(string), typeof(TimePickerFlyout), new FrameworkPropertyMetadata(ClockIdentifiers.TwelveHour, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimePickerFlyout)s)?.OnClockIdentifierChanged((string)e.OldValue, (string)e.NewValue);
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TimePickerFlyout, TimePickedEventArgs> TimePicked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TimePickerFlyout", "event TypedEventHandler<TimePickerFlyout, TimePickedEventArgs> TimePickerFlyout.TimePicked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TimePickerFlyout", "event TypedEventHandler<TimePickerFlyout, TimePickedEventArgs> TimePickerFlyout.TimePicked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<TimeSpan?> ShowAtAsync(FrameworkElement target)
	{
		throw new NotImplementedException("The member IAsyncOperation<TimeSpan?> TimePickerFlyout.ShowAtAsync(FrameworkElement target) is not implemented in Uno.");
	}

	protected override Control CreatePresenter()
	{
		throw new NotImplementedException();
	}

	protected override void OnConfirmed()
	{
		throw new NotImplementedException();
	}

	protected override bool ShouldShowConfirmationButtons()
	{
		throw new NotImplementedException();
	}

	protected virtual void OnTimeChanged(TimeSpan oldTime, TimeSpan newTime)
	{
	}

	protected virtual void OnMinuteIncrementChanged(int oldMinuteIncrement, int newMinuteIncrement)
	{
	}

	protected virtual void OnClockIdentifierChanged(string oldClockIdentifier, string newClockIdentifier)
	{
	}
}

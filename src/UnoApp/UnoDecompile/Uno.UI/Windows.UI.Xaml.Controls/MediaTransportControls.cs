using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class MediaTransportControls : Control
{
	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsZoomEnabled
	{
		get
		{
			return (bool)GetValue(IsZoomEnabledProperty);
		}
		set
		{
			SetValue(IsZoomEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsZoomButtonVisible
	{
		get
		{
			return (bool)GetValue(IsZoomButtonVisibleProperty);
		}
		set
		{
			SetValue(IsZoomButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsVolumeEnabled
	{
		get
		{
			return (bool)GetValue(IsVolumeEnabledProperty);
		}
		set
		{
			SetValue(IsVolumeEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsVolumeButtonVisible
	{
		get
		{
			return (bool)GetValue(IsVolumeButtonVisibleProperty);
		}
		set
		{
			SetValue(IsVolumeButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsStopEnabled
	{
		get
		{
			return (bool)GetValue(IsStopEnabledProperty);
		}
		set
		{
			SetValue(IsStopEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsStopButtonVisible
	{
		get
		{
			return (bool)GetValue(IsStopButtonVisibleProperty);
		}
		set
		{
			SetValue(IsStopButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsSeekEnabled
	{
		get
		{
			return (bool)GetValue(IsSeekEnabledProperty);
		}
		set
		{
			SetValue(IsSeekEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsSeekBarVisible
	{
		get
		{
			return (bool)GetValue(IsSeekBarVisibleProperty);
		}
		set
		{
			SetValue(IsSeekBarVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsPlaybackRateEnabled
	{
		get
		{
			return (bool)GetValue(IsPlaybackRateEnabledProperty);
		}
		set
		{
			SetValue(IsPlaybackRateEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsPlaybackRateButtonVisible
	{
		get
		{
			return (bool)GetValue(IsPlaybackRateButtonVisibleProperty);
		}
		set
		{
			SetValue(IsPlaybackRateButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsFullWindowEnabled
	{
		get
		{
			return (bool)GetValue(IsFullWindowEnabledProperty);
		}
		set
		{
			SetValue(IsFullWindowEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsFullWindowButtonVisible
	{
		get
		{
			return (bool)GetValue(IsFullWindowButtonVisibleProperty);
		}
		set
		{
			SetValue(IsFullWindowButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsFastRewindEnabled
	{
		get
		{
			return (bool)GetValue(IsFastRewindEnabledProperty);
		}
		set
		{
			SetValue(IsFastRewindEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsFastRewindButtonVisible
	{
		get
		{
			return (bool)GetValue(IsFastRewindButtonVisibleProperty);
		}
		set
		{
			SetValue(IsFastRewindButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsFastForwardEnabled
	{
		get
		{
			return (bool)GetValue(IsFastForwardEnabledProperty);
		}
		set
		{
			SetValue(IsFastForwardEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsFastForwardButtonVisible
	{
		get
		{
			return (bool)GetValue(IsFastForwardButtonVisibleProperty);
		}
		set
		{
			SetValue(IsFastForwardButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsCompact
	{
		get
		{
			return (bool)GetValue(IsCompactProperty);
		}
		set
		{
			SetValue(IsCompactProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsSkipForwardEnabled
	{
		get
		{
			return (bool)GetValue(IsSkipForwardEnabledProperty);
		}
		set
		{
			SetValue(IsSkipForwardEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsSkipForwardButtonVisible
	{
		get
		{
			return (bool)GetValue(IsSkipForwardButtonVisibleProperty);
		}
		set
		{
			SetValue(IsSkipForwardButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsSkipBackwardEnabled
	{
		get
		{
			return (bool)GetValue(IsSkipBackwardEnabledProperty);
		}
		set
		{
			SetValue(IsSkipBackwardEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsSkipBackwardButtonVisible
	{
		get
		{
			return (bool)GetValue(IsSkipBackwardButtonVisibleProperty);
		}
		set
		{
			SetValue(IsSkipBackwardButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsPreviousTrackButtonVisible
	{
		get
		{
			return (bool)GetValue(IsPreviousTrackButtonVisibleProperty);
		}
		set
		{
			SetValue(IsPreviousTrackButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsNextTrackButtonVisible
	{
		get
		{
			return (bool)GetValue(IsNextTrackButtonVisibleProperty);
		}
		set
		{
			SetValue(IsNextTrackButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public FastPlayFallbackBehaviour FastPlayFallbackBehaviour
	{
		get
		{
			return (FastPlayFallbackBehaviour)GetValue(FastPlayFallbackBehaviourProperty);
		}
		set
		{
			SetValue(FastPlayFallbackBehaviourProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool ShowAndHideAutomatically
	{
		get
		{
			return (bool)GetValue(ShowAndHideAutomaticallyProperty);
		}
		set
		{
			SetValue(ShowAndHideAutomaticallyProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsRepeatEnabled
	{
		get
		{
			return (bool)GetValue(IsRepeatEnabledProperty);
		}
		set
		{
			SetValue(IsRepeatEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsRepeatButtonVisible
	{
		get
		{
			return (bool)GetValue(IsRepeatButtonVisibleProperty);
		}
		set
		{
			SetValue(IsRepeatButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsCompactOverlayEnabled
	{
		get
		{
			return (bool)GetValue(IsCompactOverlayEnabledProperty);
		}
		set
		{
			SetValue(IsCompactOverlayEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public bool IsCompactOverlayButtonVisible
	{
		get
		{
			return (bool)GetValue(IsCompactOverlayButtonVisibleProperty);
		}
		set
		{
			SetValue(IsCompactOverlayButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsCompactProperty { get; } = DependencyProperty.Register("IsCompact", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsFastForwardButtonVisibleProperty { get; } = DependencyProperty.Register("IsFastForwardButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsFastForwardEnabledProperty { get; } = DependencyProperty.Register("IsFastForwardEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsFastRewindButtonVisibleProperty { get; } = DependencyProperty.Register("IsFastRewindButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsFastRewindEnabledProperty { get; } = DependencyProperty.Register("IsFastRewindEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsFullWindowButtonVisibleProperty { get; } = DependencyProperty.Register("IsFullWindowButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsFullWindowEnabledProperty { get; } = DependencyProperty.Register("IsFullWindowEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsPlaybackRateButtonVisibleProperty { get; } = DependencyProperty.Register("IsPlaybackRateButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsPlaybackRateEnabledProperty { get; } = DependencyProperty.Register("IsPlaybackRateEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsSeekBarVisibleProperty { get; } = DependencyProperty.Register("IsSeekBarVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsSeekEnabledProperty { get; } = DependencyProperty.Register("IsSeekEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsStopButtonVisibleProperty { get; } = DependencyProperty.Register("IsStopButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsStopEnabledProperty { get; } = DependencyProperty.Register("IsStopEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsVolumeButtonVisibleProperty { get; } = DependencyProperty.Register("IsVolumeButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsVolumeEnabledProperty { get; } = DependencyProperty.Register("IsVolumeEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsZoomButtonVisibleProperty { get; } = DependencyProperty.Register("IsZoomButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsZoomEnabledProperty { get; } = DependencyProperty.Register("IsZoomEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty FastPlayFallbackBehaviourProperty { get; } = DependencyProperty.Register("FastPlayFallbackBehaviour", typeof(FastPlayFallbackBehaviour), typeof(MediaTransportControls), new FrameworkPropertyMetadata(FastPlayFallbackBehaviour.Skip));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsNextTrackButtonVisibleProperty { get; } = DependencyProperty.Register("IsNextTrackButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsPreviousTrackButtonVisibleProperty { get; } = DependencyProperty.Register("IsPreviousTrackButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsSkipBackwardButtonVisibleProperty { get; } = DependencyProperty.Register("IsSkipBackwardButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsSkipBackwardEnabledProperty { get; } = DependencyProperty.Register("IsSkipBackwardEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsSkipForwardButtonVisibleProperty { get; } = DependencyProperty.Register("IsSkipForwardButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsSkipForwardEnabledProperty { get; } = DependencyProperty.Register("IsSkipForwardEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsRepeatButtonVisibleProperty { get; } = DependencyProperty.Register("IsRepeatButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsRepeatEnabledProperty { get; } = DependencyProperty.Register("IsRepeatEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty ShowAndHideAutomaticallyProperty { get; } = DependencyProperty.Register("ShowAndHideAutomatically", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsCompactOverlayButtonVisibleProperty { get; } = DependencyProperty.Register("IsCompactOverlayButtonVisible", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsCompactOverlayEnabledProperty { get; } = DependencyProperty.Register("IsCompactOverlayEnabled", typeof(bool), typeof(MediaTransportControls), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<MediaTransportControls, MediaTransportControlsThumbnailRequestedEventArgs> ThumbnailRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaTransportControls", "event TypedEventHandler<MediaTransportControls, MediaTransportControlsThumbnailRequestedEventArgs> MediaTransportControls.ThumbnailRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaTransportControls", "event TypedEventHandler<MediaTransportControls, MediaTransportControlsThumbnailRequestedEventArgs> MediaTransportControls.ThumbnailRequested");
		}
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public MediaTransportControls()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaTransportControls", "MediaTransportControls.MediaTransportControls()");
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public void Show()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaTransportControls", "void MediaTransportControls.Show()");
	}

	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public void Hide()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaTransportControls", "void MediaTransportControls.Hide()");
	}
}

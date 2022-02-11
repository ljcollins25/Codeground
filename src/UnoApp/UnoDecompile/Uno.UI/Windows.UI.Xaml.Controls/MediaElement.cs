using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Media.Casting;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.PlayTo;
using Windows.Media.Protection;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class MediaElement : FrameworkElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Volume
	{
		get
		{
			return (double)GetValue(VolumeProperty);
		}
		set
		{
			SetValue(VolumeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Stereo3DVideoRenderMode Stereo3DVideoRenderMode
	{
		get
		{
			return (Stereo3DVideoRenderMode)GetValue(Stereo3DVideoRenderModeProperty);
		}
		set
		{
			SetValue(Stereo3DVideoRenderModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Stereo3DVideoPackingMode Stereo3DVideoPackingMode
	{
		get
		{
			return (Stereo3DVideoPackingMode)GetValue(Stereo3DVideoPackingModeProperty);
		}
		set
		{
			SetValue(Stereo3DVideoPackingModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Uri Source
	{
		get
		{
			return (Uri)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool RealTimePlayback
	{
		get
		{
			return (bool)GetValue(RealTimePlaybackProperty);
		}
		set
		{
			SetValue(RealTimePlaybackProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MediaProtectionManager ProtectionManager
	{
		get
		{
			return (MediaProtectionManager)GetValue(ProtectionManagerProperty);
		}
		set
		{
			SetValue(ProtectionManagerProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource PosterSource
	{
		get
		{
			return (ImageSource)GetValue(PosterSourceProperty);
		}
		set
		{
			SetValue(PosterSourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TimeSpan Position
	{
		get
		{
			return (TimeSpan)GetValue(PositionProperty);
		}
		set
		{
			SetValue(PositionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double PlaybackRate
	{
		get
		{
			return (double)GetValue(PlaybackRateProperty);
		}
		set
		{
			SetValue(PlaybackRateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AutoPlay
	{
		get
		{
			return (bool)GetValue(AutoPlayProperty);
		}
		set
		{
			SetValue(AutoPlayProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int? AudioStreamIndex
	{
		get
		{
			return (int?)GetValue(AudioStreamIndexProperty);
		}
		set
		{
			SetValue(AudioStreamIndexProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsMuted
	{
		get
		{
			return (bool)GetValue(IsMutedProperty);
		}
		set
		{
			SetValue(IsMutedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public AudioDeviceType AudioDeviceType
	{
		get
		{
			return (AudioDeviceType)GetValue(AudioDeviceTypeProperty);
		}
		set
		{
			SetValue(AudioDeviceTypeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public AudioCategory AudioCategory
	{
		get
		{
			return (AudioCategory)GetValue(AudioCategoryProperty);
		}
		set
		{
			SetValue(AudioCategoryProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double DefaultPlaybackRate
	{
		get
		{
			return (double)GetValue(DefaultPlaybackRateProperty);
		}
		set
		{
			SetValue(DefaultPlaybackRateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsLooping
	{
		get
		{
			return (bool)GetValue(IsLoopingProperty);
		}
		set
		{
			SetValue(IsLoopingProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Balance
	{
		get
		{
			return (double)GetValue(BalanceProperty);
		}
		set
		{
			SetValue(BalanceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double DownloadProgressOffset => (double)GetValue(DownloadProgressOffsetProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsAudioOnly => (bool)GetValue(IsAudioOnlyProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsStereo3DVideo => (bool)GetValue(IsStereo3DVideoProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TimelineMarkerCollection Markers
	{
		get
		{
			throw new NotImplementedException("The member TimelineMarkerCollection MediaElement.Markers is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Duration NaturalDuration => (Duration)GetValue(NaturalDurationProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int NaturalVideoHeight => (int)GetValue(NaturalVideoHeightProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int NaturalVideoWidth => (int)GetValue(NaturalVideoWidthProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PlayToSource PlayToSource => (PlayToSource)GetValue(PlayToSourceProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Stereo3DVideoPackingMode ActualStereo3DVideoPackingMode => (Stereo3DVideoPackingMode)GetValue(ActualStereo3DVideoPackingModeProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int AspectRatioHeight => (int)GetValue(AspectRatioHeightProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int AspectRatioWidth => (int)GetValue(AspectRatioWidthProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int AudioStreamCount => (int)GetValue(AudioStreamCountProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double BufferingProgress => (double)GetValue(BufferingProgressProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanPause => (bool)GetValue(CanPauseProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanSeek => (bool)GetValue(CanSeekProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MediaElementState CurrentState => (MediaElementState)GetValue(CurrentStateProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double DownloadProgress => (double)GetValue(DownloadProgressProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Stretch Stretch
	{
		get
		{
			return (Stretch)GetValue(StretchProperty);
		}
		set
		{
			SetValue(StretchProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Uri PlayToPreferredSourceUri
	{
		get
		{
			return (Uri)GetValue(PlayToPreferredSourceUriProperty);
		}
		set
		{
			SetValue(PlayToPreferredSourceUriProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsFullWindow
	{
		get
		{
			return (bool)GetValue(IsFullWindowProperty);
		}
		set
		{
			SetValue(IsFullWindowProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AreTransportControlsEnabled
	{
		get
		{
			return (bool)GetValue(AreTransportControlsEnabledProperty);
		}
		set
		{
			SetValue(AreTransportControlsEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MediaTransportControls TransportControls
	{
		get
		{
			throw new NotImplementedException("The member MediaTransportControls MediaElement.TransportControls is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "MediaTransportControls MediaElement.TransportControls");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DownloadProgressOffsetProperty { get; } = DependencyProperty.Register("DownloadProgressOffset", typeof(double), typeof(MediaElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(Uri), typeof(MediaElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty Stereo3DVideoPackingModeProperty { get; } = DependencyProperty.Register("Stereo3DVideoPackingMode", typeof(Stereo3DVideoPackingMode), typeof(MediaElement), new FrameworkPropertyMetadata(Stereo3DVideoPackingMode.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty Stereo3DVideoRenderModeProperty { get; } = DependencyProperty.Register("Stereo3DVideoRenderMode", typeof(Stereo3DVideoRenderMode), typeof(MediaElement), new FrameworkPropertyMetadata(Stereo3DVideoRenderMode.Mono));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ActualStereo3DVideoPackingModeProperty { get; } = DependencyProperty.Register("ActualStereo3DVideoPackingMode", typeof(Stereo3DVideoPackingMode), typeof(MediaElement), new FrameworkPropertyMetadata(Stereo3DVideoPackingMode.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AspectRatioHeightProperty { get; } = DependencyProperty.Register("AspectRatioHeight", typeof(int), typeof(MediaElement), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AspectRatioWidthProperty { get; } = DependencyProperty.Register("AspectRatioWidth", typeof(int), typeof(MediaElement), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AudioCategoryProperty { get; } = DependencyProperty.Register("AudioCategory", typeof(AudioCategory), typeof(MediaElement), new FrameworkPropertyMetadata(AudioCategory.Other));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AudioDeviceTypeProperty { get; } = DependencyProperty.Register("AudioDeviceType", typeof(AudioDeviceType), typeof(MediaElement), new FrameworkPropertyMetadata(AudioDeviceType.Console));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AudioStreamCountProperty { get; } = DependencyProperty.Register("AudioStreamCount", typeof(int), typeof(MediaElement), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AudioStreamIndexProperty { get; } = DependencyProperty.Register("AudioStreamIndex", typeof(int?), typeof(MediaElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AutoPlayProperty { get; } = DependencyProperty.Register("AutoPlay", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty BalanceProperty { get; } = DependencyProperty.Register("Balance", typeof(double), typeof(MediaElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty BufferingProgressProperty { get; } = DependencyProperty.Register("BufferingProgress", typeof(double), typeof(MediaElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanPauseProperty { get; } = DependencyProperty.Register("CanPause", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanSeekProperty { get; } = DependencyProperty.Register("CanSeek", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CurrentStateProperty { get; } = DependencyProperty.Register("CurrentState", typeof(MediaElementState), typeof(MediaElement), new FrameworkPropertyMetadata(MediaElementState.Closed));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DefaultPlaybackRateProperty { get; } = DependencyProperty.Register("DefaultPlaybackRate", typeof(double), typeof(MediaElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VolumeProperty { get; } = DependencyProperty.Register("Volume", typeof(double), typeof(MediaElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DownloadProgressProperty { get; } = DependencyProperty.Register("DownloadProgress", typeof(double), typeof(MediaElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsAudioOnlyProperty { get; } = DependencyProperty.Register("IsAudioOnly", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsLoopingProperty { get; } = DependencyProperty.Register("IsLooping", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsMutedProperty { get; } = DependencyProperty.Register("IsMuted", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsStereo3DVideoProperty { get; } = DependencyProperty.Register("IsStereo3DVideo", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty NaturalDurationProperty { get; } = DependencyProperty.Register("NaturalDuration", typeof(Duration), typeof(MediaElement), new FrameworkPropertyMetadata(default(Duration)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty NaturalVideoHeightProperty { get; } = DependencyProperty.Register("NaturalVideoHeight", typeof(int), typeof(MediaElement), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty NaturalVideoWidthProperty { get; } = DependencyProperty.Register("NaturalVideoWidth", typeof(int), typeof(MediaElement), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlayToSourceProperty { get; } = DependencyProperty.Register("PlayToSource", typeof(PlayToSource), typeof(MediaElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlaybackRateProperty { get; } = DependencyProperty.Register("PlaybackRate", typeof(double), typeof(MediaElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PositionProperty { get; } = DependencyProperty.Register("Position", typeof(TimeSpan), typeof(MediaElement), new FrameworkPropertyMetadata(default(TimeSpan)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PosterSourceProperty { get; } = DependencyProperty.Register("PosterSource", typeof(ImageSource), typeof(MediaElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ProtectionManagerProperty { get; } = DependencyProperty.Register("ProtectionManager", typeof(MediaProtectionManager), typeof(MediaElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RealTimePlaybackProperty { get; } = DependencyProperty.Register("RealTimePlayback", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsFullWindowProperty { get; } = DependencyProperty.Register("IsFullWindow", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlayToPreferredSourceUriProperty { get; } = DependencyProperty.Register("PlayToPreferredSourceUri", typeof(Uri), typeof(MediaElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(MediaElement), new FrameworkPropertyMetadata(Stretch.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AreTransportControlsEnabledProperty { get; } = DependencyProperty.Register("AreTransportControlsEnabled", typeof(bool), typeof(MediaElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler BufferingProgressChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.BufferingProgressChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.BufferingProgressChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler CurrentStateChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.CurrentStateChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.CurrentStateChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler DownloadProgressChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.DownloadProgressChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.DownloadProgressChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TimelineMarkerRoutedEventHandler MarkerReached
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event TimelineMarkerRoutedEventHandler MediaElement.MarkerReached");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event TimelineMarkerRoutedEventHandler MediaElement.MarkerReached");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler MediaEnded
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.MediaEnded");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.MediaEnded");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event ExceptionRoutedEventHandler MediaFailed
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event ExceptionRoutedEventHandler MediaElement.MediaFailed");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event ExceptionRoutedEventHandler MediaElement.MediaFailed");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler MediaOpened
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.MediaOpened");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.MediaOpened");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RateChangedRoutedEventHandler RateChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RateChangedRoutedEventHandler MediaElement.RateChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RateChangedRoutedEventHandler MediaElement.RateChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler SeekCompleted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.SeekCompleted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.SeekCompleted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event RoutedEventHandler VolumeChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.VolumeChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event RoutedEventHandler MediaElement.VolumeChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<MediaElement, PartialMediaFailureDetectedEventArgs> PartialMediaFailureDetected
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event TypedEventHandler<MediaElement, PartialMediaFailureDetectedEventArgs> MediaElement.PartialMediaFailureDetected");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "event TypedEventHandler<MediaElement, PartialMediaFailureDetectedEventArgs> MediaElement.PartialMediaFailureDetected");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MediaElement()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "MediaElement.MediaElement()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Stop()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.Stop()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Play()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.Play()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Pause()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.Pause()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MediaCanPlayResponse CanPlayType(string type)
	{
		throw new NotImplementedException("The member MediaCanPlayResponse MediaElement.CanPlayType(string type) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetSource(IRandomAccessStream stream, string mimeType)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.SetSource(IRandomAccessStream stream, string mimeType)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string GetAudioStreamLanguage(int? index)
	{
		throw new NotImplementedException("The member string MediaElement.GetAudioStreamLanguage(int? index) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void AddAudioEffect(string effectID, bool effectOptional, IPropertySet effectConfiguration)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.AddAudioEffect(string effectID, bool effectOptional, IPropertySet effectConfiguration)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void AddVideoEffect(string effectID, bool effectOptional, IPropertySet effectConfiguration)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.AddVideoEffect(string effectID, bool effectOptional, IPropertySet effectConfiguration)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RemoveAllEffects()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.RemoveAllEffects()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetMediaStreamSource(IMediaSource source)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.SetMediaStreamSource(IMediaSource source)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetPlaybackSource(IMediaPlaybackSource source)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaElement", "void MediaElement.SetPlaybackSource(IMediaPlaybackSource source)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CastingSource GetAsCastingSource()
	{
		throw new NotImplementedException("The member CastingSource MediaElement.GetAsCastingSource() is not implemented in Uno.");
	}
}

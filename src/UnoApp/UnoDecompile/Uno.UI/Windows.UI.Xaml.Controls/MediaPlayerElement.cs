using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.Media.Playback;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class MediaPlayerElement : Control
{
	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public MediaTransportControls TransportControls
	{
		get
		{
			throw new NotImplementedException("The member MediaTransportControls MediaPlayerElement.TransportControls is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaPlayerElement", "MediaTransportControls MediaPlayerElement.TransportControls");
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
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

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public IMediaPlaybackSource Source
	{
		get
		{
			return (IMediaPlaybackSource)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
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

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
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

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
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

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
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

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public MediaPlayer MediaPlayer => (MediaPlayer)GetValue(MediaPlayerProperty);

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty AreTransportControlsEnabledProperty { get; } = DependencyProperty.Register("AreTransportControlsEnabled", typeof(bool), typeof(MediaPlayerElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty AutoPlayProperty { get; } = DependencyProperty.Register("AutoPlay", typeof(bool), typeof(MediaPlayerElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty IsFullWindowProperty { get; } = DependencyProperty.Register("IsFullWindow", typeof(bool), typeof(MediaPlayerElement), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty MediaPlayerProperty { get; } = DependencyProperty.Register("MediaPlayer", typeof(MediaPlayer), typeof(MediaPlayerElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty PosterSourceProperty { get; } = DependencyProperty.Register("PosterSource", typeof(ImageSource), typeof(MediaPlayerElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(IMediaPlaybackSource), typeof(MediaPlayerElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(MediaPlayerElement), new FrameworkPropertyMetadata(Stretch.None));


	[NotImplemented(new string[] { "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public MediaPlayerElement()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaPlayerElement", "MediaPlayerElement.MediaPlayerElement()");
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public void SetMediaPlayer(MediaPlayer mediaPlayer)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.MediaPlayerElement", "void MediaPlayerElement.SetMediaPlayer(MediaPlayer mediaPlayer)");
	}
}

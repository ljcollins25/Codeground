using Uno;
using Windows.Media.Playback;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class MediaPlayerPresenter : Border
{
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
	public MediaPlayer MediaPlayer
	{
		get
		{
			return (MediaPlayer)GetValue(MediaPlayerProperty);
		}
		set
		{
			SetValue(MediaPlayerProperty, value);
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
	public static DependencyProperty IsFullWindowProperty { get; } = DependencyProperty.Register("IsFullWindow", typeof(bool), typeof(MediaPlayerPresenter), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty MediaPlayerProperty { get; } = DependencyProperty.Register("MediaPlayer", typeof(MediaPlayer), typeof(MediaPlayerPresenter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(MediaPlayerPresenter), new FrameworkPropertyMetadata(Stretch.None));

}

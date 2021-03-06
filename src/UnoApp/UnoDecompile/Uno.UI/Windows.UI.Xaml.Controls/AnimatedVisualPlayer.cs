using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Source")]
public class AnimatedVisualPlayer : FrameworkElement
{
	public static DependencyProperty AutoPlayProperty { get; } = DependencyProperty.Register("AutoPlay", typeof(bool), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(true, UpdateSourceOnChanged));


	public static DependencyProperty IsAnimatedVisualLoadedProperty { get; } = DependencyProperty.Register("IsAnimatedVisualLoaded", typeof(bool), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(false, UpdateSourceOnChanged));


	public static DependencyProperty IsPlayingProperty { get; } = DependencyProperty.Register("IsPlaying", typeof(bool), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(false, UpdateSourceOnChanged));


	public static DependencyProperty PlaybackRateProperty { get; } = DependencyProperty.Register("PlaybackRate", typeof(double), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(1.0, UpdateSourceOnChanged));


	public static DependencyProperty FallbackContentProperty { get; } = DependencyProperty.Register("FallbackContent", typeof(DataTemplate), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, UpdateSourceOnChanged));


	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(IAnimatedVisualSource), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, UpdateSourceOnChanged));


	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(Stretch.Uniform, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, UpdateSourceOnChanged));


	public static DependencyProperty DurationProperty { get; } = DependencyProperty.Register("Duration", typeof(TimeSpan), typeof(AnimatedVisualPlayer), new FrameworkPropertyMetadata(default(TimeSpan), UpdateSourceOnChanged));


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

	public bool IsAnimatedVisualLoaded
	{
		get
		{
			return (bool)GetValue(IsAnimatedVisualLoadedProperty);
		}
		internal set
		{
			SetValue(IsAnimatedVisualLoadedProperty, value);
		}
	}

	public bool IsPlaying
	{
		get
		{
			return (bool)GetValue(IsPlayingProperty);
		}
		internal set
		{
			SetValue(IsPlayingProperty, value);
		}
	}

	public DataTemplate FallbackContent
	{
		get
		{
			return (DataTemplate)GetValue(FallbackContentProperty);
		}
		set
		{
			SetValue(FallbackContentProperty, value);
		}
	}

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

	public IAnimatedVisualSource Source
	{
		get
		{
			return (IAnimatedVisualSource)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

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

	public TimeSpan Duration
	{
		get
		{
			return (TimeSpan)GetValue(DurationProperty);
		}
		internal set
		{
			SetValue(DurationProperty, value);
		}
	}

	private static void UpdateSourceOnChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
	{
		if (source is AnimatedVisualPlayer animatedVisualPlayer && animatedVisualPlayer.IsLoaded && animatedVisualPlayer.Source != null)
		{
			animatedVisualPlayer.Source.Update(animatedVisualPlayer);
			animatedVisualPlayer.InvalidateMeasure();
		}
	}

	public void Pause()
	{
		Source?.Pause();
	}

	public async Task PlayAsync(double fromProgress, double toProgress, bool looped)
	{
		Source?.Play(fromProgress, toProgress, looped);
	}

	public void Resume()
	{
		Source?.Resume();
	}

	public void SetProgress(double progress)
	{
		Source?.SetProgress(progress);
	}

	public void Stop()
	{
		Source?.Stop();
	}

	private protected override void OnLoaded()
	{
		Source?.Update(this);
		Source?.Load();
		base.OnLoaded();
	}

	private protected override void OnUnloaded()
	{
		Source?.Unload();
		base.OnUnloaded();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		IAnimatedVisualSource source = Source;
		if (source != null)
		{
			source.Measure(availableSize);
			if (true)
			{
				return Source.Measure(availableSize);
			}
		}
		return base.MeasureOverride(availableSize);
	}
}

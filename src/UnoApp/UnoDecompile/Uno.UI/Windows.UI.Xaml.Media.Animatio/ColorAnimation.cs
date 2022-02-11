using System;
using Uno;

namespace Windows.UI.Xaml.Media.Animation;

public class ColorAnimation : Timeline, ITimeline, IDisposable, IAnimation<ColorOffset>
{
	private readonly AnimationImplementation<ColorOffset> _animationImplementation;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public EasingFunctionBase EasingFunction
	{
		get
		{
			return (EasingFunctionBase)GetValue(EasingFunctionProperty);
		}
		set
		{
			SetValue(EasingFunctionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty EasingFunctionProperty { get; } = DependencyProperty.Register("EasingFunction", typeof(EasingFunctionBase), typeof(ColorAnimation), new FrameworkPropertyMetadata((object)null));


	public Color? To
	{
		get
		{
			return (Color?)GetValue(ToProperty);
		}
		set
		{
			SetValue(ToProperty, value);
		}
	}

	public Color? From
	{
		get
		{
			return (Color?)GetValue(FromProperty);
		}
		set
		{
			SetValue(FromProperty, value);
		}
	}

	public bool EnableDependentAnimation
	{
		get
		{
			return (bool)GetValue(EnableDependentAnimationProperty);
		}
		set
		{
			SetValue(EnableDependentAnimationProperty, value);
		}
	}

	bool IAnimation<ColorOffset>.EnableDependentAnimation => EnableDependentAnimation;

	public Color? By
	{
		get
		{
			return (Color?)GetValue(ByProperty);
		}
		set
		{
			SetValue(ByProperty, value);
		}
	}

	public static DependencyProperty ByProperty { get; } = DependencyProperty.Register("By", typeof(Color?), typeof(ColorAnimation), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty EnableDependentAnimationProperty { get; } = DependencyProperty.Register("EnableDependentAnimation", typeof(bool), typeof(ColorAnimation), new FrameworkPropertyMetadata(false));


	public static DependencyProperty FromProperty { get; } = DependencyProperty.Register("From", typeof(Color?), typeof(ColorAnimation), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty ToProperty { get; } = DependencyProperty.Register("To", typeof(Color?), typeof(ColorAnimation), new FrameworkPropertyMetadata((object)null));


	ColorOffset? IAnimation<ColorOffset>.To => (ColorOffset?)To;

	ColorOffset? IAnimation<ColorOffset>.From => (ColorOffset?)From;

	ColorOffset? IAnimation<ColorOffset>.By => (ColorOffset?)By;

	[NotImplemented]
	IEasingFunction IAnimation<ColorOffset>.EasingFunction => null;

	public ColorAnimation()
	{
		_animationImplementation = new AnimationImplementation<ColorOffset>(this);
	}

	void ITimeline.Begin()
	{
		_animationImplementation.Begin();
	}

	void ITimeline.Stop()
	{
		_animationImplementation.Stop();
	}

	void ITimeline.Resume()
	{
		_animationImplementation.Resume();
	}

	void ITimeline.Pause()
	{
		_animationImplementation.Pause();
	}

	void ITimeline.Seek(TimeSpan offset)
	{
		_animationImplementation.Seek(offset);
	}

	void ITimeline.SeekAlignedToLastTick(TimeSpan offset)
	{
		_animationImplementation.SeekAlignedToLastTick(offset);
	}

	void ITimeline.SkipToFill()
	{
		_animationImplementation.SkipToFill();
	}

	void ITimeline.Deactivate()
	{
		_animationImplementation.Deactivate();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_animationImplementation.Dispose();
		}
		base.Dispose(disposing);
	}

	ColorOffset IAnimation<ColorOffset>.Subtract(ColorOffset minuend, ColorOffset subtrahend)
	{
		return minuend - subtrahend;
	}

	ColorOffset IAnimation<ColorOffset>.Add(ColorOffset first, ColorOffset second)
	{
		return first + second;
	}

	ColorOffset IAnimation<ColorOffset>.Multiply(float multiplier, ColorOffset color)
	{
		return multiplier * color;
	}

	ColorOffset IAnimation<ColorOffset>.Convert(object value)
	{
		if (value is string colorCode)
		{
			return (ColorOffset)Colors.Parse(colorCode);
		}
		return default(ColorOffset);
	}
}

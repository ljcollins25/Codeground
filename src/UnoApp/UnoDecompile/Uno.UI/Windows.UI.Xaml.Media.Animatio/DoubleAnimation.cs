using System;

namespace Windows.UI.Xaml.Media.Animation;

public class DoubleAnimation : Timeline, ITimeline, IDisposable, IAnimation<float>
{
	private readonly AnimationImplementation<float> _animationImplementation;

	public double? By
	{
		get
		{
			return (double?)GetValue(ByProperty);
		}
		set
		{
			SetValue(ByProperty, value);
		}
	}

	public static DependencyProperty ByProperty { get; } = DependencyProperty.Register("By", typeof(double?), typeof(DoubleAnimation), new FrameworkPropertyMetadata(null));


	public double? From
	{
		get
		{
			return (double?)GetValue(FromProperty);
		}
		set
		{
			SetValue(FromProperty, value);
		}
	}

	public static DependencyProperty FromProperty { get; } = DependencyProperty.Register("From", typeof(double?), typeof(DoubleAnimation), new FrameworkPropertyMetadata(null));


	public double? To
	{
		get
		{
			return (double?)GetValue(ToProperty);
		}
		set
		{
			SetValue(ToProperty, value);
		}
	}

	public static DependencyProperty ToProperty { get; } = DependencyProperty.Register("To", typeof(double?), typeof(DoubleAnimation), new FrameworkPropertyMetadata(null));


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

	bool IAnimation<float>.EnableDependentAnimation => EnableDependentAnimation;

	public static DependencyProperty EnableDependentAnimationProperty { get; } = DependencyProperty.Register("EnableDependentAnimation", typeof(bool), typeof(DoubleAnimation), new FrameworkPropertyMetadata(false));


	public IEasingFunction EasingFunction
	{
		get
		{
			return (IEasingFunction)GetValue(EasingFunctionProperty);
		}
		set
		{
			SetValue(EasingFunctionProperty, value);
		}
	}

	IEasingFunction IAnimation<float>.EasingFunction => EasingFunction;

	float? IAnimation<float>.To => (float?)To;

	float? IAnimation<float>.From => (float?)From;

	float? IAnimation<float>.By => (float?)By;

	public static DependencyProperty EasingFunctionProperty { get; } = DependencyProperty.Register("EasingFunction", typeof(IEasingFunction), typeof(DoubleAnimation), new FrameworkPropertyMetadata(null));


	public DoubleAnimation()
	{
		_animationImplementation = new AnimationImplementation<float>(this);
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

	float IAnimation<float>.Subtract(float minuend, float subtrahend)
	{
		return minuend - subtrahend;
	}

	float IAnimation<float>.Add(float first, float second)
	{
		return first + second;
	}

	float IAnimation<float>.Convert(object value)
	{
		return Convert.ToSingle(value);
	}

	float IAnimation<float>.Multiply(float multiplier, float t)
	{
		return multiplier * t;
	}
}

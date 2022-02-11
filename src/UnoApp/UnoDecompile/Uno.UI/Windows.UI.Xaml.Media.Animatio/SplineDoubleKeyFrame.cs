namespace Windows.UI.Xaml.Media.Animation;

public class SplineDoubleKeyFrame : DoubleKeyFrame
{
	public KeySpline KeySpline
	{
		get
		{
			return (KeySpline)GetValue(KeySplineProperty);
		}
		set
		{
			SetValue(KeySplineProperty, value);
		}
	}

	public static DependencyProperty KeySplineProperty { get; } = DependencyProperty.Register("KeySpline", typeof(KeySpline), typeof(SplineDoubleKeyFrame), new FrameworkPropertyMetadata(new KeySpline()));


	public SplineDoubleKeyFrame()
	{
	}

	public SplineDoubleKeyFrame(double value)
		: base(value)
	{
	}

	public SplineDoubleKeyFrame(double value, KeyTime keyTime)
		: base(value, keyTime)
	{
	}

	public SplineDoubleKeyFrame(double value, KeyTime keyTime, KeySpline keySpline)
		: base(value, keyTime)
	{
		KeySpline = keySpline;
	}

	internal override IEasingFunction GetEasingFunction()
	{
		return new SplineEasingFunction(KeySpline);
	}
}

namespace Windows.UI.Xaml.Media.Animation;

public class EasingDoubleKeyFrame : DoubleKeyFrame
{
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

	public static DependencyProperty EasingFunctionProperty { get; } = DependencyProperty.Register("EasingFunction", typeof(EasingFunctionBase), typeof(EasingDoubleKeyFrame), new FrameworkPropertyMetadata(null));


	public EasingDoubleKeyFrame()
	{
	}

	public EasingDoubleKeyFrame(double value)
		: base(value)
	{
	}

	public EasingDoubleKeyFrame(double value, KeyTime keyTime)
		: base(value, keyTime)
	{
	}

	public EasingDoubleKeyFrame(double value, KeyTime keyTime, EasingFunctionBase easingFunction)
		: base(value, keyTime)
	{
		EasingFunction = easingFunction;
	}

	internal override IEasingFunction GetEasingFunction()
	{
		return EasingFunction;
	}
}

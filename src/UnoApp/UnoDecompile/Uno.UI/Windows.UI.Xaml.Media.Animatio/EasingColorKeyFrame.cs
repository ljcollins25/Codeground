namespace Windows.UI.Xaml.Media.Animation;

public class EasingColorKeyFrame : ColorKeyFrame
{
	public static DependencyProperty EasingFunctionProperty { get; } = DependencyProperty.Register("EasingFunction", typeof(EasingFunctionBase), typeof(EasingColorKeyFrame), new FrameworkPropertyMetadata((object)null));


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

	internal override IEasingFunction GetEasingFunction()
	{
		return EasingFunction;
	}
}

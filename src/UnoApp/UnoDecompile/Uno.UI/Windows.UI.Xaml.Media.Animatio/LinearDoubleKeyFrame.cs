namespace Windows.UI.Xaml.Media.Animation;

public class LinearDoubleKeyFrame : DoubleKeyFrame
{
	public LinearDoubleKeyFrame()
	{
	}

	public LinearDoubleKeyFrame(double value)
		: base(value)
	{
	}

	public LinearDoubleKeyFrame(double value, KeyTime keyTime)
		: base(value, keyTime)
	{
	}

	internal override IEasingFunction GetEasingFunction()
	{
		return null;
	}
}

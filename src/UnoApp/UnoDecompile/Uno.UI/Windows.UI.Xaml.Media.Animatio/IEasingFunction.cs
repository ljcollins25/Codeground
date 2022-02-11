namespace Windows.UI.Xaml.Media.Animation;

public interface IEasingFunction
{
	double Ease(double currentTime, double startValue, double finalValue, double duration);
}

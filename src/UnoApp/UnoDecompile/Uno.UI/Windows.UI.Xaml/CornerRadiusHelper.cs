namespace Windows.UI.Xaml;

public class CornerRadiusHelper
{
	public static CornerRadius FromRadii(double topLeft, double topRight, double bottomRight, double bottomLeft)
	{
		return new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);
	}

	public static CornerRadius FromUniformRadius(double uniformRadius)
	{
		return new CornerRadius(uniformRadius);
	}
}

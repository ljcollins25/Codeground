using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class PathIconSource : IconSource
{
	public Geometry Data
	{
		get
		{
			return (Geometry)GetValue(DataProperty);
		}
		set
		{
			SetValue(DataProperty, value);
		}
	}

	public static DependencyProperty DataProperty { get; } = DependencyProperty.Register("Data", typeof(Geometry), typeof(PathIconSource), new FrameworkPropertyMetadata(null));


	public override IconElement CreateIconElement()
	{
		PathIcon pathIcon = new PathIcon();
		if (Data != null)
		{
			pathIcon.Data = Data;
		}
		if (base.Foreground != null)
		{
			pathIcon.Foreground = base.Foreground;
		}
		return pathIcon;
	}
}

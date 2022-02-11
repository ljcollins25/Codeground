using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

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

	public static DependencyProperty DataProperty { get; } = DependencyProperty.Register("Data", typeof(Geometry), typeof(PathIconSource), new FrameworkPropertyMetadata(null, IconSource.OnPropertyChanged));


	private protected override IconElement CreateIconElementCore()
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

	private protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty sourceProperty)
	{
		if (sourceProperty == DataProperty)
		{
			return PathIcon.DataProperty;
		}
		return base.GetIconElementPropertyCore(sourceProperty);
	}
}

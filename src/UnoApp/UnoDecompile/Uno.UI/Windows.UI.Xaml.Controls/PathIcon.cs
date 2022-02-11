using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Windows.UI.Xaml.Controls;

public class PathIcon : IconElement
{
	private Path _path;

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

	public static DependencyProperty DataProperty { get; } = DependencyProperty.Register("Data", typeof(Geometry), typeof(PathIcon), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PathIcon)s).OnDataChanged(e);
	}));


	public PathIcon()
	{
		_path = new Path();
		_path.Fill = base.Foreground;
		_path.Stretch = Stretch.None;
		AddIconElementView(_path);
	}

	protected override void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
	{
		_path.Fill = e.NewValue as Brush;
	}

	private void OnDataChanged(DependencyPropertyChangedEventArgs e)
	{
		_path.Data = e.NewValue as Geometry;
		_path.Fill = base.Foreground;
	}
}

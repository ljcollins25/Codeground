using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls.Primitives;

public sealed class TickBar : FrameworkElement
{
	public Brush Fill
	{
		get
		{
			return (Brush)GetValue(FillProperty);
		}
		set
		{
			SetValue(FillProperty, value);
		}
	}

	public static DependencyProperty FillProperty { get; } = DependencyProperty.Register("Fill", typeof(Brush), typeof(TickBar), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TickBar)s)?.OnFillChanged(e);
	}));


	private void OnFillChanged(DependencyPropertyChangedEventArgs e)
	{
	}
}

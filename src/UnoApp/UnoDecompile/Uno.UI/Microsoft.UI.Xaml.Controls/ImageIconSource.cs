using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class ImageIconSource : IconSource
{
	public ImageSource ImageSource
	{
		get
		{
			return (ImageSource)GetValue(ImageSourceProperty);
		}
		set
		{
			SetValue(ImageSourceProperty, value);
		}
	}

	public static DependencyProperty ImageSourceProperty { get; } = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageIconSource), new FrameworkPropertyMetadata(null, IconSource.OnPropertyChanged));


	private protected override IconElement CreateIconElementCore()
	{
		ImageIcon imageIcon = new ImageIcon();
		ImageSource imageSource = ImageSource;
		if (imageSource != null)
		{
			imageIcon.Source = imageSource;
		}
		Brush foreground = base.Foreground;
		if (foreground != null)
		{
			imageIcon.Foreground = foreground;
		}
		return imageIcon;
	}

	private protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty sourceProperty)
	{
		if (sourceProperty == ImageSourceProperty)
		{
			return ImageIcon.SourceProperty;
		}
		return base.GetIconElementPropertyCore(sourceProperty);
	}
}

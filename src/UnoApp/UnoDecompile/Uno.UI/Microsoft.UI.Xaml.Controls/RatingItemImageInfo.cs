using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class RatingItemImageInfo : RatingItemInfo
{
	public ImageSource DisabledImage
	{
		get
		{
			return (ImageSource)GetValue(DisabledImageProperty);
		}
		set
		{
			SetValue(DisabledImageProperty, value);
		}
	}

	public static DependencyProperty DisabledImageProperty { get; } = DependencyProperty.Register("DisabledImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata(null));


	public ImageSource Image
	{
		get
		{
			return (ImageSource)GetValue(ImageProperty);
		}
		set
		{
			SetValue(ImageProperty, value);
		}
	}

	public static DependencyProperty ImageProperty { get; } = DependencyProperty.Register("Image", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata(null));


	public ImageSource PlaceholderImage
	{
		get
		{
			return (ImageSource)GetValue(PlaceholderImageProperty);
		}
		set
		{
			SetValue(PlaceholderImageProperty, value);
		}
	}

	public static DependencyProperty PlaceholderImageProperty { get; } = DependencyProperty.Register("PlaceholderImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata(null));


	public ImageSource PointerOverImage
	{
		get
		{
			return (ImageSource)GetValue(PointerOverImageProperty);
		}
		set
		{
			SetValue(PointerOverImageProperty, value);
		}
	}

	public static DependencyProperty PointerOverImageProperty { get; } = DependencyProperty.Register("PointerOverImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata(null));


	public ImageSource PointerOverPlaceholderImage
	{
		get
		{
			return (ImageSource)GetValue(PointerOverPlaceholderImageProperty);
		}
		set
		{
			SetValue(PointerOverPlaceholderImageProperty, value);
		}
	}

	public static DependencyProperty PointerOverPlaceholderImageProperty { get; } = DependencyProperty.Register("PointerOverPlaceholderImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata(null));


	public ImageSource UnsetImage
	{
		get
		{
			return (ImageSource)GetValue(UnsetImageProperty);
		}
		set
		{
			SetValue(UnsetImageProperty, value);
		}
	}

	public static DependencyProperty UnsetImageProperty { get; } = DependencyProperty.Register("UnsetImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata(null));

}

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class ImageIcon : IconElement
{
	private Image? m_rootImage;

	private bool _initialized;

	private bool _applyTemplateCalled;

	public ImageSource Source
	{
		get
		{
			return (ImageSource)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageIcon), new FrameworkPropertyMetadata(null, OnSourcePropertyChanged));


	public ImageIcon()
	{
		base.Loaded += ImageIcon_Loaded;
	}

	private void ImageIcon_Loaded(object sender, RoutedEventArgs e)
	{
		EnsureInitialized();
	}

	protected override void OnApplyTemplate()
	{
		if (VisualTreeHelper.GetChild(this, 0) is Grid reference)
		{
			Image image = (Image)VisualTreeHelper.GetChild(reference, 0);
			image.Source = Source;
			m_rootImage = image;
		}
		else
		{
			m_rootImage = null;
		}
		_applyTemplateCalled = true;
	}

	private void OnSourcePropertyChanged(DependencyPropertyChangedEventArgs agrs)
	{
		Image rootImage = m_rootImage;
		if (rootImage != null)
		{
			rootImage.Source = Source;
		}
	}

	private static void OnSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is ImageIcon imageIcon)
		{
			imageIcon.OnSourcePropertyChanged(args);
		}
	}

	private void EnsureInitialized()
	{
		InitializeVisualTree();
		if (!_applyTemplateCalled)
		{
			OnApplyTemplate();
			_applyTemplateCalled = true;
		}
	}

	private void InitializeVisualTree()
	{
		if (!_initialized)
		{
			Image item = new Image
			{
				Stretch = Stretch.Uniform
			};
			Grid grid = new Grid();
			grid.Children.Add(item);
			AddIconElementView(grid);
			_initialized = true;
		}
	}
}

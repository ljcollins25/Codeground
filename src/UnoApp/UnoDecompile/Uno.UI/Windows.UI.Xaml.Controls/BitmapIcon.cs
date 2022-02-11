using System;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class BitmapIcon : IconElement
{
	private Image _image;

	private Grid _grid;

	public bool ShowAsMonochrome
	{
		get
		{
			return (bool)GetValue(ShowAsMonochromeProperty);
		}
		set
		{
			SetValue(ShowAsMonochromeProperty, value);
		}
	}

	public static DependencyProperty ShowAsMonochromeProperty { get; } = DependencyProperty.Register("ShowAsMonochrome", typeof(bool), typeof(BitmapIcon), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as BitmapIcon)?.OnShowAsMonochromeChanged((bool)e.NewValue);
	}));


	public Uri UriSource
	{
		get
		{
			return (Uri)GetValue(UriSourceProperty);
		}
		set
		{
			SetValue(UriSourceProperty, value);
		}
	}

	public static DependencyProperty UriSourceProperty { get; } = DependencyProperty.Register("UriSource", typeof(Uri), typeof(BitmapIcon), new FrameworkPropertyMetadata((object)null));


	public BitmapIcon()
	{
		this.SetValue(IconElement.ForegroundProperty, SolidColorBrushHelper.Black, DependencyPropertyValuePrecedences.Inheritance);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (_image == null)
		{
			_image = new Image
			{
				Stretch = Stretch.Uniform
			};
			UpdateImageMonochromeColor();
			_image.SetBinding(Image.SourceProperty, new Binding
			{
				Source = this,
				Path = "UriSource"
			});
			_grid = new Grid();
			_grid.Children.Add(_image);
			AddIconElementView(_grid);
		}
		return base.MeasureOverride(availableSize);
	}

	private void OnShowAsMonochromeChanged(bool value)
	{
		UpdateImageMonochromeColor();
	}

	protected override void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnForegroundChanged(e);
		UpdateImageMonochromeColor();
	}

	private void UpdateImageMonochromeColor()
	{
		if (_image != null)
		{
			_image.MonochromeColor = ((!ShowAsMonochrome) ? null : (base.Foreground as SolidColorBrush)?.Color);
		}
	}
}

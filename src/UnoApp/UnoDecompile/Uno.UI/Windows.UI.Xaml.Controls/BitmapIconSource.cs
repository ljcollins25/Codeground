using System;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

public class BitmapIconSource : IconSource
{
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

	public static DependencyProperty UriSourceProperty { get; } = DependencyProperty.Register("UriSource", typeof(Uri), typeof(BitmapIconSource), new FrameworkPropertyMetadata((object)null));


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

	public static DependencyProperty ShowAsMonochromeProperty { get; } = DependencyProperty.Register("ShowAsMonochrome", typeof(bool), typeof(BitmapIconSource), new FrameworkPropertyMetadata(true));


	public override IconElement CreateIconElement()
	{
		BitmapIcon bitmapIcon = new BitmapIcon();
		if (UriSource != null)
		{
			bitmapIcon.UriSource = UriSource;
		}
		if (ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Controls.BitmapIcon", "ShowAsMonochrome"))
		{
			bitmapIcon.ShowAsMonochrome = ShowAsMonochrome;
		}
		if (base.Foreground != null)
		{
			bitmapIcon.Foreground = base.Foreground;
		}
		return bitmapIcon;
	}
}

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class AnimatedIconSource : IconSource
{
	public IconSource FallbackIconSource
	{
		get
		{
			return (IconSource)GetValue(FallbackIconSourceProperty);
		}
		set
		{
			SetValue(FallbackIconSourceProperty, value);
		}
	}

	public static DependencyProperty FallbackIconSourceProperty { get; } = DependencyProperty.Register("FallbackIconSource", typeof(IconSource), typeof(AnimatedIconSource), new FrameworkPropertyMetadata(null, IconSource.OnPropertyChanged));


	public bool MirroredWhenRightToLeft
	{
		get
		{
			return (bool)GetValue(MirroredWhenRightToLeftProperty);
		}
		set
		{
			SetValue(MirroredWhenRightToLeftProperty, value);
		}
	}

	public static DependencyProperty MirroredWhenRightToLeftProperty { get; } = DependencyProperty.Register("MirroredWhenRightToLeft", typeof(bool), typeof(AnimatedIconSource), new FrameworkPropertyMetadata(false, IconSource.OnPropertyChanged));


	public IAnimatedVisualSource2 Source
	{
		get
		{
			return (IAnimatedVisualSource2)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(IAnimatedVisualSource2), typeof(AnimatedIconSource), new FrameworkPropertyMetadata(null, IconSource.OnPropertyChanged));


	private protected override IconElement CreateIconElementCore()
	{
		AnimatedIcon animatedIcon = new AnimatedIcon();
		IAnimatedVisualSource2 source = Source;
		if (source != null)
		{
			animatedIcon.Source = source;
		}
		IconSource fallbackIconSource = FallbackIconSource;
		if (fallbackIconSource != null)
		{
			animatedIcon.FallbackIconSource = fallbackIconSource;
		}
		Brush foreground = base.Foreground;
		if (foreground != null)
		{
			animatedIcon.Foreground = foreground;
		}
		animatedIcon.MirroredWhenRightToLeft = MirroredWhenRightToLeft;
		return animatedIcon;
	}

	private protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty sourceProperty)
	{
		if (sourceProperty == SourceProperty)
		{
			return AnimatedIcon.SourceProperty;
		}
		if (sourceProperty == FallbackIconSourceProperty)
		{
			return AnimatedIcon.FallbackIconSourceProperty;
		}
		if (sourceProperty == MirroredWhenRightToLeftProperty)
		{
			return AnimatedIcon.MirroredWhenRightToLeftProperty;
		}
		return base.GetIconElementPropertyCore(sourceProperty);
	}
}

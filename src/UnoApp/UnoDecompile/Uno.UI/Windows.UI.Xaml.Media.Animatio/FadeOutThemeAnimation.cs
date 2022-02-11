using Uno.UI;

namespace Windows.UI.Xaml.Media.Animation;

public class FadeOutThemeAnimation : DoubleAnimation
{
	public static DependencyProperty TargetNameProperty { get; } = DependencyProperty.Register("TargetName", typeof(string), typeof(FadeOutThemeAnimation), new FrameworkPropertyMetadata(null));


	public string TargetName
	{
		get
		{
			return (string)GetValue(TargetNameProperty);
		}
		set
		{
			SetValue(TargetNameProperty, value);
		}
	}

	public FadeOutThemeAnimation()
	{
		this.SetValue(Timeline.DurationProperty, new Duration(FeatureConfiguration.ThemeAnimation.DefaultThemeAnimationDuration), DependencyPropertyValuePrecedences.DefaultValue);
		this.SetValue(Storyboard.TargetPropertyProperty, "Opacity", DependencyPropertyValuePrecedences.DefaultValue);
		this.SetValue(DoubleAnimation.ToProperty, 0.0, DependencyPropertyValuePrecedences.DefaultValue);
	}

	private protected override void InitTarget()
	{
		object obj = NameScope.GetNameScope(this)?.FindName(TargetName);
		if (obj is DependencyObject target)
		{
			Storyboard.SetTarget(this, target);
		}
	}

	private static void OnTargetNameChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		Storyboard.SetTargetName(dependencyobject as Timeline, args.NewValue as string);
	}
}

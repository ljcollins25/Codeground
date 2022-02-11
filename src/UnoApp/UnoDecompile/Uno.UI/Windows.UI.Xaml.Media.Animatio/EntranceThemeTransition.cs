using System;

namespace Windows.UI.Xaml.Media.Animation;

public class EntranceThemeTransition : Transition
{
	private readonly Duration _duration = new Duration(TimeSpan.FromMilliseconds(100.0));

	public float FromHorizontalOffset
	{
		get
		{
			return (float)GetValue(FromHorizontalOffsetProperty);
		}
		set
		{
			SetValue(FromHorizontalOffsetProperty, value);
		}
	}

	public static DependencyProperty FromHorizontalOffsetProperty { get; } = DependencyProperty.Register("FromHorizontalOffset", typeof(float), typeof(EntranceThemeTransition), new FrameworkPropertyMetadata(40f));


	public float FromVerticalOffset
	{
		get
		{
			return (float)GetValue(FromVerticalOffsetProperty);
		}
		set
		{
			SetValue(FromVerticalOffsetProperty, value);
		}
	}

	public static DependencyProperty FromVerticalOffsetProperty { get; } = DependencyProperty.Register("FromVerticalOffset", typeof(float), typeof(EntranceThemeTransition), new FrameworkPropertyMetadata(0f));


	public bool IsStaggeringEnabled
	{
		get
		{
			return (bool)GetValue(IsStaggeringEnabledProperty);
		}
		set
		{
			SetValue(IsStaggeringEnabledProperty, value);
		}
	}

	public static DependencyProperty IsStaggeringEnabledProperty { get; } = DependencyProperty.Register("IsStaggeringEnabled", typeof(bool), typeof(EntranceThemeTransition), new FrameworkPropertyMetadata(true));


	private void AttachOpacityAnimation(Storyboard storyBoard, IFrameworkElement element, TimeSpan beginTime)
	{
		double startingOpacity = element.Opacity;
		DoubleAnimation doubleAnimation = new DoubleAnimation();
		doubleAnimation.From = 0.0;
		doubleAnimation.To = startingOpacity;
		doubleAnimation.FillBehavior = FillBehavior.Stop;
		doubleAnimation.BeginTime = beginTime;
		element.Opacity = 0.0;
		doubleAnimation.Completed += delegate
		{
			element.Opacity = startingOpacity;
		};
		doubleAnimation.Duration = TimeSpan.FromMilliseconds(_duration.TimeSpan.TotalMilliseconds / 2.0);
		Storyboard.SetTarget(doubleAnimation, element);
		Storyboard.SetTargetProperty(doubleAnimation, "Opacity");
		storyBoard.Children.Add(doubleAnimation);
	}

	private void AttachHorizontalTranslateAnimation(Storyboard storyBoard, IFrameworkElement element, TimeSpan beginTime)
	{
		if (FromHorizontalOffset != 0f)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation();
			doubleAnimation.From = FromHorizontalOffset;
			doubleAnimation.To = 0.0;
			doubleAnimation.FillBehavior = FillBehavior.Stop;
			doubleAnimation.BeginTime = beginTime;
			doubleAnimation.Duration = _duration;
			Storyboard.SetTarget(doubleAnimation, element.RenderTransform);
			Storyboard.SetTargetProperty(doubleAnimation, "X");
			storyBoard.Children.Add(doubleAnimation);
		}
	}

	private void AttachVerticalTranslateAnimation(Storyboard storyBoard, IFrameworkElement element, TimeSpan beginTime)
	{
		if (FromVerticalOffset != 0f)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation();
			doubleAnimation.From = FromVerticalOffset;
			doubleAnimation.To = 0.0;
			doubleAnimation.FillBehavior = FillBehavior.Stop;
			doubleAnimation.BeginTime = beginTime;
			doubleAnimation.Duration = _duration;
			Storyboard.SetTarget(doubleAnimation, element.RenderTransform);
			Storyboard.SetTargetProperty(doubleAnimation, "Y");
			storyBoard.Children.Add(doubleAnimation);
		}
	}

	internal override void AttachToStoryboardAnimation(Storyboard sb, IFrameworkElement element, TimeSpan beginTime, int xOffset, int yOffset)
	{
		if (!IsStaggeringEnabled)
		{
			beginTime = TimeSpan.Zero;
		}
		base.AttachToStoryboardAnimation(sb, element, beginTime);
		element.RenderTransform = new TranslateTransform();
		AttachHorizontalTranslateAnimation(sb, element, beginTime);
		AttachVerticalTranslateAnimation(sb, element, beginTime);
		AttachOpacityAnimation(sb, element, beginTime);
	}
}

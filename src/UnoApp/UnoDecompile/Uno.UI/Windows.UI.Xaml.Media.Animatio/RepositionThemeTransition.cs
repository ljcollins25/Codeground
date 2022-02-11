using System;
using Uno;

namespace Windows.UI.Xaml.Media.Animation;

public class RepositionThemeTransition : Transition
{
	private readonly Duration _duration = new Duration(TimeSpan.FromMilliseconds(120.0));

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsStaggeringEnabledProperty { get; } = DependencyProperty.Register("IsStaggeringEnabled", typeof(bool), typeof(RepositionThemeTransition), new FrameworkPropertyMetadata(false));


	internal override void AttachToStoryboardAnimation(Storyboard sb, IFrameworkElement element, TimeSpan beginTime, int xOffset, int yOffset)
	{
		element.RenderTransform = new TranslateTransform
		{
			X = xOffset,
			Y = yOffset
		};
		AttachHorizontalTranslateAnimation(sb, element, beginTime, xOffset);
		AttachVerticalTranslateAnimation(sb, element, beginTime, yOffset);
	}

	private void AttachHorizontalTranslateAnimation(Storyboard storyBoard, IFrameworkElement element, TimeSpan beginTime, int xOffset)
	{
		if (xOffset != 0)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation();
			doubleAnimation.From = xOffset;
			doubleAnimation.To = 0.0;
			doubleAnimation.FillBehavior = FillBehavior.HoldEnd;
			doubleAnimation.BeginTime = beginTime;
			doubleAnimation.Duration = _duration;
			Storyboard.SetTarget(doubleAnimation, element.RenderTransform);
			Storyboard.SetTargetProperty(doubleAnimation, "X");
			storyBoard.Children.Add(doubleAnimation);
		}
	}

	private void AttachVerticalTranslateAnimation(Storyboard storyBoard, IFrameworkElement element, TimeSpan beginTime, int yOffset)
	{
		if (yOffset != 0)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation();
			doubleAnimation.From = yOffset;
			doubleAnimation.To = 0.0;
			doubleAnimation.FillBehavior = FillBehavior.HoldEnd;
			doubleAnimation.BeginTime = beginTime;
			doubleAnimation.Duration = _duration;
			Storyboard.SetTarget(doubleAnimation, element.RenderTransform);
			Storyboard.SetTargetProperty(doubleAnimation, "Y");
			storyBoard.Children.Add(doubleAnimation);
		}
	}
}

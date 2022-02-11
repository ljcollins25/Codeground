using System;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class ProgressRing : Control
{
	public bool IsActive
	{
		get
		{
			return (bool)GetValue(IsActiveProperty);
		}
		set
		{
			SetValue(IsActiveProperty, value);
		}
	}

	public static DependencyProperty IsActiveProperty { get; } = DependencyProperty.Register("IsActive", typeof(bool), typeof(ProgressRing), new FrameworkPropertyMetadata(false, OnIsActiveChanged));


	public ProgressRingTemplateSettings TemplateSettings
	{
		get
		{
			ProgressRingTemplateSettings progressRingTemplateSettings = new ProgressRingTemplateSettings
			{
				EllipseDiameter = 3.0,
				MaxSideLength = 100.0
			};
			double num = (base.Width.IsNaN() ? base.MinWidth : base.Width);
			progressRingTemplateSettings.EllipseOffset = new Thickness(num * (Math.Sqrt(2.0) - 1.0) / 2.0);
			return progressRingTemplateSettings;
		}
	}

	public ProgressRing()
	{
		base.DefaultStyleKey = typeof(ProgressRing);
	}

	private static void OnIsActiveChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		ProgressRing progressRing = (ProgressRing)dependencyObject;
		bool flag = (bool)args.NewValue;
		if (progressRing.IsLoaded)
		{
			VisualStateManager.GoToState(progressRing, flag ? "Active" : "Inactive", useTransitions: false);
		}
	}
}

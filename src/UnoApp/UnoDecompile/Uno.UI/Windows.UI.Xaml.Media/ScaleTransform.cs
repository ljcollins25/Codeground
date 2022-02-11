using System.Numerics;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class ScaleTransform : Transform
{
	public double CenterY
	{
		get
		{
			return (double)GetValue(CenterYProperty);
		}
		set
		{
			SetValue(CenterYProperty, value);
		}
	}

	public static DependencyProperty CenterYProperty { get; } = DependencyProperty.Register("CenterY", typeof(double), typeof(ScaleTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double CenterX
	{
		get
		{
			return (double)GetValue(CenterXProperty);
		}
		set
		{
			SetValue(CenterXProperty, value);
		}
	}

	public static DependencyProperty CenterXProperty { get; } = DependencyProperty.Register("CenterX", typeof(double), typeof(ScaleTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double ScaleX
	{
		get
		{
			return (double)GetValue(ScaleXProperty);
		}
		set
		{
			SetValue(ScaleXProperty, value);
		}
	}

	public static DependencyProperty ScaleXProperty { get; } = DependencyProperty.Register("ScaleX", typeof(double), typeof(ScaleTransform), new FrameworkPropertyMetadata(1.0, Transform.NotifyChangedCallback));


	public double ScaleY
	{
		get
		{
			return (double)GetValue(ScaleYProperty);
		}
		set
		{
			SetValue(ScaleYProperty, value);
		}
	}

	public static DependencyProperty ScaleYProperty { get; } = DependencyProperty.Register("ScaleY", typeof(double), typeof(ScaleTransform), new FrameworkPropertyMetadata(1.0, Transform.NotifyChangedCallback));


	internal static Matrix3x2 GetMatrix(double centerX, double centerY, double scaleX, double scaleY)
	{
		Vector2 scales = new Vector2((float)scaleX, (float)scaleY);
		Vector2 centerPoint = new Vector2((float)centerX, (float)centerY);
		return Matrix3x2.CreateScale(scales, centerPoint);
	}

	internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
	{
		return GetMatrix(absoluteOrigin.X + CenterX, absoluteOrigin.Y + CenterY, ScaleX, ScaleY);
	}
}

using System.Numerics;
using Uno.Extensions;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public sealed class RotateTransform : Transform
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

	public static DependencyProperty CenterYProperty { get; } = DependencyProperty.Register("CenterY", typeof(double), typeof(RotateTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


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

	public static DependencyProperty CenterXProperty { get; } = DependencyProperty.Register("CenterX", typeof(double), typeof(RotateTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double Angle
	{
		get
		{
			return (double)GetValue(AngleProperty);
		}
		set
		{
			SetValue(AngleProperty, value);
		}
	}

	public static DependencyProperty AngleProperty { get; } = DependencyProperty.Register("Angle", typeof(double), typeof(RotateTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	internal static Matrix3x2 GetMatrix(double centerX, double centerY, double angleDegree)
	{
		float radians = (float)MathEx.ToRadians(angleDegree);
		Vector2 centerPoint = new Vector2((float)centerX, (float)centerY);
		return Matrix3x2.CreateRotation(radians, centerPoint);
	}

	internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
	{
		return GetMatrix(absoluteOrigin.X + CenterX, absoluteOrigin.Y + CenterY, Angle);
	}
}

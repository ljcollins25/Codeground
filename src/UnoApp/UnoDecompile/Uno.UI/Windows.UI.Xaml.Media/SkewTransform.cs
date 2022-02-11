using System.Numerics;
using Uno.Extensions;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class SkewTransform : Transform
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

	public static DependencyProperty CenterYProperty { get; } = DependencyProperty.Register("CenterY", typeof(double), typeof(SkewTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


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

	public static DependencyProperty CenterXProperty { get; } = DependencyProperty.Register("CenterX", typeof(double), typeof(SkewTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double AngleX
	{
		get
		{
			return (double)GetValue(AngleXProperty);
		}
		set
		{
			SetValue(AngleXProperty, value);
		}
	}

	public static DependencyProperty AngleXProperty { get; } = DependencyProperty.Register("AngleX", typeof(double), typeof(SkewTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double AngleY
	{
		get
		{
			return (double)GetValue(AngleYProperty);
		}
		set
		{
			SetValue(AngleYProperty, value);
		}
	}

	public static DependencyProperty AngleYProperty { get; } = DependencyProperty.Register("AngleY", typeof(double), typeof(SkewTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	internal static Matrix3x2 GetMatrix(double centerX, double centerY, double angleXDegree, double angleYDegree)
	{
		float radiansX = (float)MathEx.ToRadians(angleXDegree);
		float radiansY = (float)MathEx.ToRadians(angleYDegree);
		Vector2 centerPoint = new Vector2((float)centerX, (float)centerY);
		return Matrix3x2.CreateSkew(radiansX, radiansY, centerPoint);
	}

	internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
	{
		return GetMatrix(absoluteOrigin.X + CenterX, absoluteOrigin.Y + CenterY, AngleX, AngleY);
	}
}

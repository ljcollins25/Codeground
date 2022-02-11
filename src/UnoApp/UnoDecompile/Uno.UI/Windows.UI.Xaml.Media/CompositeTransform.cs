using System.Numerics;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class CompositeTransform : Transform
{
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

	public static DependencyProperty CenterXProperty { get; } = DependencyProperty.Register("CenterX", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


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

	public static DependencyProperty CenterYProperty { get; } = DependencyProperty.Register("CenterY", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double Rotation
	{
		get
		{
			return (double)GetValue(RotationProperty);
		}
		set
		{
			SetValue(RotationProperty, value);
		}
	}

	public static DependencyProperty RotationProperty { get; } = DependencyProperty.Register("Rotation", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


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

	public static DependencyProperty ScaleXProperty { get; } = DependencyProperty.Register("ScaleX", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(1.0, Transform.NotifyChangedCallback));


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

	public static DependencyProperty ScaleYProperty { get; } = DependencyProperty.Register("ScaleY", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(1.0, Transform.NotifyChangedCallback));


	public double SkewX
	{
		get
		{
			return (double)GetValue(SkewXProperty);
		}
		set
		{
			SetValue(SkewXProperty, value);
		}
	}

	public static DependencyProperty SkewXProperty { get; } = DependencyProperty.Register("SkewX", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double SkewY
	{
		get
		{
			return (double)GetValue(SkewYProperty);
		}
		set
		{
			SetValue(SkewYProperty, value);
		}
	}

	public static DependencyProperty SkewYProperty { get; } = DependencyProperty.Register("SkewY", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double TranslateX
	{
		get
		{
			return (double)GetValue(TranslateXProperty);
		}
		set
		{
			SetValue(TranslateXProperty, value);
		}
	}

	public static DependencyProperty TranslateXProperty { get; } = DependencyProperty.Register("TranslateX", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double TranslateY
	{
		get
		{
			return (double)GetValue(TranslateYProperty);
		}
		set
		{
			SetValue(TranslateYProperty, value);
		}
	}

	public static DependencyProperty TranslateYProperty { get; } = DependencyProperty.Register("TranslateY", typeof(double), typeof(CompositeTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
	{
		double centerX = absoluteOrigin.X + CenterX;
		double centerY = absoluteOrigin.Y + CenterY;
		Matrix3x2 identity = Matrix3x2.Identity;
		identity *= ScaleTransform.GetMatrix(centerX, centerY, ScaleX, ScaleY);
		identity *= SkewTransform.GetMatrix(CenterX, CenterY, SkewX, SkewY);
		identity *= RotateTransform.GetMatrix(CenterX, CenterY, Rotation);
		return identity * TranslateTransform.GetMatrix(TranslateX, TranslateY);
	}
}

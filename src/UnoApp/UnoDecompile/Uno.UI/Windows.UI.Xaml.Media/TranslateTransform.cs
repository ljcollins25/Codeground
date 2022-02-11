using System.Numerics;
using Uno.Extensions;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class TranslateTransform : Transform
{
	public double X
	{
		get
		{
			return (double)GetValue(XProperty);
		}
		set
		{
			SetValue(XProperty, value);
		}
	}

	public static DependencyProperty XProperty { get; } = DependencyProperty.Register("X", typeof(double), typeof(TranslateTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	public double Y
	{
		get
		{
			return (double)GetValue(YProperty);
		}
		set
		{
			SetValue(YProperty, value);
		}
	}

	public static DependencyProperty YProperty { get; } = DependencyProperty.Register("Y", typeof(double), typeof(TranslateTransform), new FrameworkPropertyMetadata(0.0, Transform.NotifyChangedCallback));


	internal static Matrix3x2 GetMatrix(double x, double y)
	{
		return Matrix3x2.CreateTranslation((float)x, (float)y);
	}

	internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
	{
		return GetMatrix(X, Y);
	}

	protected override bool TryTransformCore(Point inPoint, out Point outPoint)
	{
		outPoint = inPoint + new Point(X, Y);
		return true;
	}

	protected override Rect TransformBoundsCore(Rect rect)
	{
		return rect.Transform(Matrix3x2.CreateTranslation((float)X, (float)Y));
	}
}

using System.Numerics;
using Uno.Foundation.Logging;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class MatrixTransform : Transform
{
	public Matrix Matrix
	{
		get
		{
			return (Matrix)GetValue(MatrixProperty);
		}
		set
		{
			SetValue(MatrixProperty, value);
		}
	}

	public static DependencyProperty MatrixProperty { get; } = DependencyProperty.Register("Matrix", typeof(Matrix), typeof(MatrixTransform), new FrameworkPropertyMetadata(Matrix.Identity, Transform.NotifyChangedCallback));


	internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
	{
		if ((absoluteOrigin.X != 0.0 || absoluteOrigin.Y != 0.0) && this.Log().IsEnabled(LogLevel.Error))
		{
			this.Log().Error("The matrix transform does not support absolute origin");
		}
		return Matrix.Inner;
	}
}

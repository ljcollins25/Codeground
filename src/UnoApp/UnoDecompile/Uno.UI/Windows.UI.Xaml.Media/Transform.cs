using System;
using System.Numerics;
using Uno.Extensions;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public abstract class Transform : GeneralTransform
{
	protected static PropertyChangedCallback NotifyChangedCallback { get; } = delegate(DependencyObject snd, DependencyPropertyChangedEventArgs args)
	{
		if (snd is Transform transform)
		{
			transform.NotifyChanged();
		}
	};


	internal Matrix3x2 MatrixCore { get; private set; } = Matrix3x2.Identity;


	internal virtual UIElement View { get; set; }

	protected override GeneralTransform InverseCore
	{
		get
		{
			Matrix3x2 matrixCore = MatrixCore;
			if (matrixCore.IsIdentity)
			{
				return this;
			}
			return new MatrixTransform
			{
				Matrix = new Matrix(matrixCore.Inverse())
			};
		}
	}

	internal event EventHandler Changed;

	protected void NotifyChanged()
	{
		MatrixCore = ToMatrix(new Point(0.0, 0.0));
		this.Changed?.Invoke(this, EventArgs.Empty);
	}

	internal Matrix3x2 ToMatrix(Point relativeOrigin, Size viewSize)
	{
		return ToMatrix(new Point(relativeOrigin.X * viewSize.Width, relativeOrigin.Y * viewSize.Height));
	}

	internal abstract Matrix3x2 ToMatrix(Point absoluteOrigin);

	protected override bool TryTransformCore(Point inPoint, out Point outPoint)
	{
		Matrix3x2 matrixCore = MatrixCore;
		if (matrixCore.IsIdentity)
		{
			outPoint = inPoint;
			return false;
		}
		outPoint = matrixCore.Transform(inPoint);
		return true;
	}

	protected override Rect TransformBoundsCore(Rect rect)
	{
		return MatrixCore.Transform(rect);
	}
}

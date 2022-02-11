using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Uno.Disposables;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

public abstract class ArbitraryShapeBase : Shape
{
	private readonly SerialDisposable _layer = new SerialDisposable();

	private object?[]? _layerState;

	private double _scaleX;

	private double _scaleY;

	protected bool ShouldPreserveOrigin
	{
		get
		{
			if (this is Path)
			{
				return base.Stretch == Stretch.None;
			}
			return false;
		}
	}

	protected static double LimitWithUserSize(double availableSize, double userSize, double naNFallbackValue)
	{
		bool flag = userSize != 0.0 && !double.IsNaN(userSize) && !double.IsInfinity(userSize);
		bool flag2 = !double.IsNaN(availableSize);
		flag2 &= !double.IsInfinity(availableSize);
		if (flag && flag2)
		{
			return Math.Min(userSize, availableSize);
		}
		if (flag2)
		{
			return availableSize;
		}
		return naNFallbackValue;
	}

	protected override void RefreshShape(bool forceRefresh = false)
	{
		if (!base.IsLoaded)
		{
			return;
		}
		object[] array = GetShapeParameters().ToArray();
		if (!forceRefresh)
		{
			object?[]? layerState = _layerState;
			if (layerState != null && layerState.SequenceEqual<object>(array))
			{
				return;
			}
		}
		_layer.Disposable = null;
		_layerState = array;
		_layer.Disposable = BuildDrawableLayer();
	}

	private protected Rect GetBounds()
	{
		double num = base.Width;
		double num2 = base.Height;
		if (double.IsNaN(num))
		{
			double minWidth = base.MinWidth;
			if (minWidth > 0.0)
			{
				num = minWidth;
			}
		}
		if (double.IsNaN(num2))
		{
			double minHeight = base.MinHeight;
			if (minHeight > 0.0)
			{
				num2 = minHeight;
			}
		}
		if (double.IsNaN(num))
		{
			if (double.IsNaN(num2))
			{
				return new Rect(0.0, 0.0, 0.0, 0.0);
			}
			return new Rect(0.0, 0.0, num2, num2);
		}
		if (double.IsNaN(num2))
		{
			return new Rect(0.0, 0.0, num, num);
		}
		return new Rect(0.0, 0.0, num, num2);
	}

	protected internal virtual IEnumerable<object?> GetShapeParameters()
	{
		yield return GetActualSize();
		yield return base.Fill;
		yield return base.Stroke;
		yield return base.StrokeThickness;
		yield return base.Stretch;
		yield return base.StrokeDashArray;
		yield return _scaleX;
		yield return _scaleY;
	}

	private IDisposable BuildDrawableLayer()
	{
		return Disposable.Empty;
	}

	private Size GetActualSize()
	{
		return Size.Empty;
	}

	protected virtual void InvalidateShape()
	{
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		InvalidateShape();
		Size item = GetMeasurements(availableSize).desiredSize;
		Size size = base.MeasureOverride(availableSize);
		return item;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		if (base.Parent == null)
		{
			return default(Size);
		}
		(Size, double, double, double, double) measurements = GetMeasurements(finalSize);
		Matrix3x2 matrix3x = Matrix3x2.CreateScale((float)measurements.Item4, (float)measurements.Item5);
		Matrix3x2 matrix3x2 = Matrix3x2.CreateTranslation((float)measurements.Item2, (float)measurements.Item3);
		Matrix3x2 nativeTransform = matrix3x2 * matrix3x;
		foreach (UIElement child in GetChildren())
		{
			if (!(child is DefsSvgElement))
			{
				child.SetNativeTransform(nativeTransform);
			}
		}
		return finalSize;
	}

	private (Size desiredSize, double translateX, double translateY, double scaleX, double scaleY) GetMeasurements(Size availableSize)
	{
		Rect bBoxOfChildrenWithStrokeThickness = GetBBoxOfChildrenWithStrokeThickness();
		if (base.Stretch == Stretch.None)
		{
			return (new Size(bBoxOfChildrenWithStrokeThickness.Right, bBoxOfChildrenWithStrokeThickness.Bottom), 0.0, 0.0, 1.0, 1.0);
		}
		double num = bBoxOfChildrenWithStrokeThickness.AspectRatio();
		double num2 = LimitWithUserSize(availableSize.Width, base.Width, bBoxOfChildrenWithStrokeThickness.Width);
		double num3 = LimitWithUserSize(availableSize.Height, base.Height, num2 / num);
		double item = bBoxOfChildrenWithStrokeThickness.X * -1.0;
		double item2 = bBoxOfChildrenWithStrokeThickness.Y * -1.0;
		if (base.Stretch == Stretch.Fill)
		{
			double item3 = num2 / bBoxOfChildrenWithStrokeThickness.Width;
			double item4 = num3 / bBoxOfChildrenWithStrokeThickness.Height;
			return (new Size(num2, num3), item, item2, item3, item4);
		}
		double num4 = num2 / num3;
		bool flag = num > num4;
		double num5 = num2;
		double num6 = num3;
		double num7 = num2 / bBoxOfChildrenWithStrokeThickness.Width;
		double num8 = num3 / bBoxOfChildrenWithStrokeThickness.Height;
		if (base.Stretch == Stretch.Uniform)
		{
			if (flag)
			{
				num6 = num5 / num;
				num8 = num7;
			}
			else
			{
				num5 = num6 * num;
				num7 = num8;
			}
		}
		else
		{
			if (base.Stretch != Stretch.UniformToFill)
			{
				throw new InvalidOperationException("Unknown stretch mode.");
			}
			if (flag)
			{
				num5 = num6 * num;
				num7 = num8;
			}
			else
			{
				num6 = num5 / num;
				num8 = num7;
			}
		}
		Size item5 = new Size(num5, num6);
		return (item5, item, item2, num7, num8);
	}

	private Rect GetBBoxOfChildrenWithStrokeThickness()
	{
		Rect rect = Rect.Empty;
		foreach (UIElement child in GetChildren())
		{
			if (!(child is DefsSvgElement))
			{
				Rect bBoxWithStrokeThickness = GetBBoxWithStrokeThickness(child);
				if (rect == Rect.Empty)
				{
					rect = bBoxWithStrokeThickness;
				}
				else
				{
					rect.Union(bBoxWithStrokeThickness);
				}
			}
		}
		return rect;
	}

	private Rect GetBBoxWithStrokeThickness(UIElement element)
	{
		Rect bBox = element.GetBBox();
		double actualStrokeThickness = base.ActualStrokeThickness;
		if (base.Stroke == null || actualStrokeThickness < double.Epsilon)
		{
			return bBox;
		}
		double num = actualStrokeThickness / 2.0;
		double num2 = Math.Min(bBox.X, bBox.Left - num);
		double num3 = Math.Min(bBox.Y, bBox.Top - num);
		double width = bBox.Right + num - num2;
		double height = bBox.Bottom + num - num3;
		return new Rect(num2, num3, width, height);
	}
}

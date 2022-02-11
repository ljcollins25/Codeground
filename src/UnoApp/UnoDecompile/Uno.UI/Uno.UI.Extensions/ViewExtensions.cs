using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Uno.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Extensions;

public static class ViewExtensions
{
	public static IEnumerable<UIElement> GetVisualAncestry(this UIElement view)
	{
		for (UIElement ancestor = view.GetVisualTreeParent(); ancestor != null; ancestor = ancestor.GetVisualTreeParent())
		{
			yield return ancestor;
		}
	}

	internal static string GetElementSpecificDetails(this UIElement element)
	{
		if (!(element is TextBlock textBlock))
		{
			if (!(element is ScrollViewer scrollViewer))
			{
				if (!(element is ScrollContentPresenter scrollContentPresenter))
				{
					if (!(element is Viewbox viewbox))
					{
						if (!(element is SplitView splitView))
						{
							if (element is Grid grid2)
							{
								return GetGridDetails(grid2);
							}
							return "";
						}
						return $" Mode={splitView.DisplayMode}";
					}
					return $" Stretch={viewbox.Stretch}";
				}
				return $" Extent={scrollContentPresenter.ExtentWidth}x{scrollContentPresenter.ExtentHeight} Offset={scrollContentPresenter.ScrollOffsets}";
			}
			return $" Extent={scrollViewer.ExtentWidth}x{scrollViewer.ExtentHeight}";
		}
		return $" Text=\"{textBlock.Text}\" Foreground={textBlock.Foreground}";
		static string GetGridDetails(Grid grid)
		{
			string text = null;
			if (grid.ColumnDefinitions.Count > 1)
			{
				text = " Cols=" + grid.ColumnDefinitions.Select((ColumnDefinition x) => x.Width.ToString()).JoinBy(",");
			}
			string text2 = null;
			if (grid.RowDefinitions.Count > 1)
			{
				text2 = " Rows=" + grid.RowDefinitions.Select((RowDefinition x) => x.Height.ToString()).JoinBy(",");
			}
			return text + text2;
		}
	}

	internal static string GetElementGridOrCanvasDetails(this UIElement element)
	{
		StringBuilder sb = new StringBuilder();
		CheckProperty(Grid.ColumnProperty);
		CheckProperty(Grid.RowProperty);
		CheckProperty(Grid.ColumnSpanProperty);
		CheckProperty(Grid.RowSpanProperty);
		CheckProperty(Canvas.TopProperty);
		CheckProperty(Canvas.LeftProperty);
		CheckProperty(Canvas.ZIndexProperty);
		return sb.ToString();
		void CheckProperty(DependencyProperty property)
		{
			object obj = element.ReadLocalValue(property);
			if (obj is int)
			{
				int num = (int)obj;
				sb.Append($" {property.OwnerType.Name}.{property.Name}={num}");
			}
		}
	}

	internal static string GetTransformDetails(this Transform transform)
	{
		if (!(transform is ScaleTransform scaleTransform))
		{
			if (!(transform is TranslateTransform translateTransform))
			{
				if (!(transform is TransformGroup transformGroup))
				{
					if (!(transform is RotateTransform rotateTransform))
					{
						if (!(transform is MatrixTransform matrix2))
						{
							if (!(transform is CompositeTransform compositeTransform))
							{
								if (transform is SkewTransform skewTransform)
								{
									return $" SkewX={skewTransform.AngleX}  SkewY={skewTransform.AngleY}";
								}
								return "";
							}
							return $" ScaleX/Y={compositeTransform.ScaleX}/{compositeTransform.ScaleY} TranslateX/Y={compositeTransform.TranslateX}/{compositeTransform.TranslateY}";
						}
						return GetMatrix(matrix2);
					}
					return $" Rotate={rotateTransform.Angle}";
				}
				return " TransfrmGrp[" + transformGroup.Children.Select(new Func<Transform, string>(GetTransformDetails)).JoinBy(", ") + "]";
			}
			return $" TranslateX/Y={translateTransform.X}/{translateTransform.Y}";
		}
		return (scaleTransform.ScaleX == 1.0 && scaleTransform.ScaleY == 1.0) ? " UNSCALED" : $" ScaleX/Y={scaleTransform.ScaleX}/{scaleTransform.ScaleY}";
		static string GetMatrix(MatrixTransform matrix)
		{
			Matrix3x2 inner = matrix.Matrix.Inner;
			return $" Matrix=[{inner.M11}, {inner.M21}, {inner.M31}, {inner.M12}, {inner.M22}, {inner.M32}]";
		}
	}
}

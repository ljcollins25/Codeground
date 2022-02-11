using System;
using System.Linq;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

public class WrapPanel : Panel
{
	private Orientation _orientation = Orientation.Horizontal;

	private float? _itemWidth;

	private float? _itemHeight;

	public virtual Orientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			if (_orientation != value)
			{
				_orientation = value;
				OnOrientationChanged();
			}
		}
	}

	public virtual float? ItemWidth
	{
		get
		{
			return _itemWidth;
		}
		set
		{
			if (_itemWidth != value)
			{
				_itemWidth = value;
				OnItemWidthChanged();
			}
		}
	}

	public virtual float? ItemHeight
	{
		get
		{
			return _itemHeight;
		}
		set
		{
			if (_itemHeight != value)
			{
				_itemHeight = value;
				OnItemHeightChanged();
			}
		}
	}

	protected virtual void OnOrientationChanged()
	{
	}

	protected virtual void OnItemWidthChanged()
	{
	}

	protected virtual void OnItemHeightChanged()
	{
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Orientation orientation = Orientation;
		OrientedSize orientedSize = new OrientedSize(orientation);
		OrientedSize orientedSize2 = new OrientedSize(orientation);
		OrientedSize orientedSize3 = new OrientedSize(orientation, availableSize.Width, availableSize.Height);
		double num = ((double?)ItemWidth) ?? double.NaN;
		double num2 = ((double?)ItemHeight) ?? double.NaN;
		bool flag = !double.IsNaN(num);
		bool flag2 = !double.IsNaN(num2);
		Size availableSize2 = new Size(flag ? num : availableSize.Width, flag2 ? num2 : availableSize.Height);
		foreach (UIElement child in base.Children)
		{
			Size size = MeasureElement(child, availableSize2);
			OrientedSize orientedSize4 = new OrientedSize(orientation, flag ? num : size.Width, flag2 ? num2 : size.Height);
			if (NumericExtensions.IsGreaterThan(orientedSize.Direct + orientedSize4.Direct, orientedSize3.Direct))
			{
				orientedSize2.Direct = Math.Max(orientedSize.Direct, orientedSize2.Direct);
				orientedSize2.Indirect += orientedSize.Indirect;
				orientedSize = orientedSize4;
				if (NumericExtensions.IsGreaterThan(orientedSize4.Direct, orientedSize3.Direct))
				{
					orientedSize2.Direct = Math.Max(orientedSize4.Direct, orientedSize2.Direct);
					orientedSize2.Indirect += orientedSize4.Indirect;
					orientedSize = new OrientedSize(orientation);
				}
			}
			else
			{
				orientedSize.Direct += orientedSize4.Direct;
				orientedSize.Indirect = Math.Max(orientedSize.Indirect, orientedSize4.Indirect);
			}
		}
		orientedSize2.Direct = Math.Max(orientedSize.Direct, orientedSize2.Direct);
		orientedSize2.Indirect += orientedSize.Indirect;
		return new Size(orientedSize2.Width, orientedSize2.Height);
	}

	protected override Size ArrangeOverride(Size arrangeSize)
	{
		Orientation orientation = Orientation;
		OrientedSize orientedSize = new OrientedSize(orientation);
		OrientedSize orientedSize2 = new OrientedSize(orientation, arrangeSize.Width, arrangeSize.Height);
		double num = ((double?)ItemWidth) ?? double.NaN;
		double num2 = ((double?)ItemHeight) ?? double.NaN;
		bool flag = !double.IsNaN(num);
		bool flag2 = !double.IsNaN(num2);
		double num3 = 0.0;
		double? directDelta = ((orientation != Orientation.Horizontal) ? (flag2 ? new double?(num2) : null) : (flag ? new double?(num) : null));
		UIElement[] array = base.Children.ToArray();
		int num4 = array.Length;
		int num5 = 0;
		for (int i = 0; i < num4; i++)
		{
			UIElement view = array[i];
			Size elementDesiredSize = GetElementDesiredSize(view);
			OrientedSize orientedSize3 = new OrientedSize(orientation, flag ? num : elementDesiredSize.Width, flag2 ? num2 : elementDesiredSize.Height);
			if (NumericExtensions.IsGreaterThan(orientedSize.Direct + orientedSize3.Direct, orientedSize2.Direct))
			{
				ArrangeLine(array, num5, i, directDelta, num3, orientedSize.Indirect);
				num3 += orientedSize.Indirect;
				orientedSize = orientedSize3;
				if (NumericExtensions.IsGreaterThan(orientedSize3.Direct, orientedSize2.Direct))
				{
					ArrangeLine(array, i, ++i, directDelta, num3, orientedSize3.Indirect);
					num3 += orientedSize.Indirect;
					orientedSize = new OrientedSize(orientation);
				}
				num5 = i;
			}
			else
			{
				orientedSize.Direct += orientedSize3.Direct;
				orientedSize.Indirect = Math.Max(orientedSize.Indirect, orientedSize3.Indirect);
			}
		}
		if (num5 < num4)
		{
			ArrangeLine(array, num5, num4, directDelta, num3, orientedSize.Indirect);
		}
		return arrangeSize;
	}

	private void ArrangeLine(UIElement[] children, int lineStart, int lineEnd, double? directDelta, double indirectOffset, double indirectGrowth)
	{
		double num = 0.0;
		Orientation orientation = Orientation;
		bool flag = orientation == Orientation.Horizontal;
		for (int i = lineStart; i < lineEnd; i++)
		{
			UIElement view = children[i];
			Size elementDesiredSize = GetElementDesiredSize(view);
			OrientedSize orientedSize = new OrientedSize(orientation, elementDesiredSize.Width, elementDesiredSize.Height);
			double num2 = (directDelta.HasValue ? directDelta.Value : orientedSize.Direct);
			Rect finalRect = (flag ? new Rect(num, indirectOffset, num2, indirectGrowth) : new Rect(indirectOffset, num, indirectGrowth, num2));
			ArrangeElement(view, finalRect);
			num += num2;
		}
	}
}

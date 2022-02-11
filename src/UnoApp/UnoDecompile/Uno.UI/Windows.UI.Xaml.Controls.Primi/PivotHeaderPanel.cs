using System;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls.Primitives;

public class PivotHeaderPanel : Canvas
{
	protected override Size MeasureOverride(Size availableSize)
	{
		Size result = default(Size);
		Size availableSize2 = availableSize;
		availableSize2.Height = double.PositiveInfinity;
		int count = base.Children.Count;
		for (int i = 0; i < count; i++)
		{
			UIElement view = base.Children[i];
			Size size = MeasureElement(view, availableSize2);
			result.Width += size.Width;
			result.Height = Math.Max(result.Height, size.Height);
		}
		return result;
	}

	protected override Size ArrangeOverride(Size arrangeSize)
	{
		Rect finalRect = new Rect(0.0, 0.0, arrangeSize.Width, arrangeSize.Height);
		double num = 0.0;
		int count = base.Children.Count;
		for (int i = 0; i < count; i++)
		{
			UIElement view = base.Children[i];
			Size elementDesiredSize = GetElementDesiredSize(view);
			finalRect.X += num;
			num = elementDesiredSize.Width;
			finalRect.Width = elementDesiredSize.Width;
			finalRect.Height = Math.Max(arrangeSize.Height, elementDesiredSize.Height);
			ArrangeElement(view, finalRect);
		}
		return arrangeSize;
	}
}

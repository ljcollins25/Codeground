using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class InfoBarPanel : Panel
{
	private bool m_isVertical;

	public static DependencyProperty HorizontalOrientationMarginProperty { get; } = DependencyProperty.RegisterAttached("HorizontalOrientationMargin", typeof(Thickness), typeof(InfoBarPanel), new FrameworkPropertyMetadata(default(Thickness)));


	public Thickness HorizontalOrientationPadding
	{
		get
		{
			return (Thickness)GetValue(HorizontalOrientationPaddingProperty);
		}
		set
		{
			SetValue(HorizontalOrientationPaddingProperty, value);
		}
	}

	public static DependencyProperty HorizontalOrientationPaddingProperty { get; } = DependencyProperty.Register("HorizontalOrientationPadding", typeof(Thickness), typeof(InfoBarPanel), new FrameworkPropertyMetadata(default(Thickness)));


	public static DependencyProperty VerticalOrientationMarginProperty { get; } = DependencyProperty.RegisterAttached("VerticalOrientationMargin", typeof(Thickness), typeof(InfoBarPanel), new FrameworkPropertyMetadata(default(Thickness)));


	public Thickness VerticalOrientationPadding
	{
		get
		{
			return (Thickness)GetValue(VerticalOrientationPaddingProperty);
		}
		set
		{
			SetValue(VerticalOrientationPaddingProperty, value);
		}
	}

	public static DependencyProperty VerticalOrientationPaddingProperty { get; } = DependencyProperty.Register("VerticalOrientationPadding", typeof(Thickness), typeof(InfoBarPanel), new FrameworkPropertyMetadata(default(Thickness)));


	protected override Size MeasureOverride(Size availableSize)
	{
		Size result = default(Size);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = 0;
		float num7 = ((!(base.Parent is FrameworkElement frameworkElement)) ? 0f : ((float)(frameworkElement.MinHeight - (Margin.Top + Margin.Bottom))));
		UIElementCollection children = base.Children;
		int count = children.Count;
		foreach (UIElement item in children)
		{
			item.Measure(availableSize);
			Size desiredSize = item.DesiredSize;
			if (desiredSize.Width != 0.0 && desiredSize.Height != 0.0)
			{
				Thickness horizontalOrientationMargin = GetHorizontalOrientationMargin(item);
				num += desiredSize.Width + (double)((num6 > 0) ? ((float)horizontalOrientationMargin.Left) : 0f) + (double)(float)horizontalOrientationMargin.Right;
				num += desiredSize.Width + (double)((num6 > 0) ? ((float)horizontalOrientationMargin.Left) : 0f) + (double)((num6 < count - 1) ? ((float)horizontalOrientationMargin.Right) : 0f);
				Thickness verticalOrientationMargin = GetVerticalOrientationMargin(item);
				num2 += desiredSize.Height + (double)((num6 > 0) ? ((float)verticalOrientationMargin.Top) : 0f) + (double)((num6 < count - 1) ? ((float)verticalOrientationMargin.Bottom) : 0f);
				if (desiredSize.Width > num3)
				{
					num3 = desiredSize.Width;
				}
				if (desiredSize.Height > num4)
				{
					num4 = desiredSize.Height;
				}
				double num8 = desiredSize.Height + horizontalOrientationMargin.Top + horizontalOrientationMargin.Bottom;
				if (num8 > num5)
				{
					num5 = num8;
				}
				num6++;
			}
		}
		if (num6 == 1 || num > availableSize.Width || (num7 > 0f && num5 > (double)num7))
		{
			m_isVertical = true;
			Thickness verticalOrientationPadding = VerticalOrientationPadding;
			result.Width = num3 + (double)(float)verticalOrientationPadding.Left + (double)(float)verticalOrientationPadding.Right;
			result.Height = num2 + (double)(float)verticalOrientationPadding.Top + (double)(float)verticalOrientationPadding.Bottom;
		}
		else
		{
			m_isVertical = false;
			Thickness horizontalOrientationPadding = HorizontalOrientationPadding;
			result.Width = num + (double)(float)horizontalOrientationPadding.Left + (double)(float)horizontalOrientationPadding.Right;
			result.Height = num4 + (double)(float)horizontalOrientationPadding.Top + (double)(float)horizontalOrientationPadding.Bottom;
		}
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size result = finalSize;
		if (m_isVertical)
		{
			Thickness verticalOrientationPadding = VerticalOrientationPadding;
			double num = verticalOrientationPadding.Top;
			bool flag = false;
			{
				foreach (UIElement child in base.Children)
				{
					if (child is FrameworkElement)
					{
						Size desiredSize = child.DesiredSize;
						if (desiredSize.Width != 0.0 && desiredSize.Height != 0.0)
						{
							Thickness verticalOrientationMargin = GetVerticalOrientationMargin(child);
							num += (double)(flag ? ((float)verticalOrientationMargin.Top) : 0f);
							child.Arrange(new Rect(verticalOrientationPadding.Left + verticalOrientationMargin.Left, num, desiredSize.Width, desiredSize.Height));
							num += desiredSize.Height + (double)(float)verticalOrientationMargin.Bottom;
							flag = true;
						}
					}
				}
				return result;
			}
		}
		Thickness horizontalOrientationPadding = HorizontalOrientationPadding;
		double num2 = horizontalOrientationPadding.Left;
		bool flag2 = false;
		UIElementCollection children = base.Children;
		int count = children.Count;
		for (int i = 0; i < count; i++)
		{
			UIElement uIElement = children[i];
			if (!(uIElement is FrameworkElement))
			{
				continue;
			}
			Size desiredSize2 = uIElement.DesiredSize;
			if (desiredSize2.Width != 0.0 && desiredSize2.Height != 0.0)
			{
				Thickness horizontalOrientationMargin = GetHorizontalOrientationMargin(uIElement);
				num2 += (double)(flag2 ? ((float)horizontalOrientationMargin.Left) : 0f);
				if (i < count - 1)
				{
					uIElement.Arrange(new Rect(num2, (float)horizontalOrientationPadding.Top + (float)horizontalOrientationMargin.Top, desiredSize2.Width, desiredSize2.Height));
				}
				else
				{
					uIElement.Arrange(new Rect(num2, (float)horizontalOrientationPadding.Top + (float)horizontalOrientationMargin.Top, Math.Max(desiredSize2.Width, finalSize.Width - num2), desiredSize2.Height));
				}
				num2 += desiredSize2.Width + (double)(float)horizontalOrientationMargin.Right;
				flag2 = true;
			}
		}
		return result;
	}

	public static Thickness GetHorizontalOrientationMargin(DependencyObject obj)
	{
		return (Thickness)obj.GetValue(HorizontalOrientationMarginProperty);
	}

	public static void SetHorizontalOrientationMargin(DependencyObject obj, Thickness value)
	{
		obj.SetValue(HorizontalOrientationMarginProperty, value);
	}

	public static Thickness GetVerticalOrientationMargin(DependencyObject obj)
	{
		return (Thickness)obj.GetValue(VerticalOrientationMarginProperty);
	}

	public static void SetVerticalOrientationMargin(DependencyObject obj, Thickness value)
	{
		obj.SetValue(VerticalOrientationMarginProperty, value);
	}
}

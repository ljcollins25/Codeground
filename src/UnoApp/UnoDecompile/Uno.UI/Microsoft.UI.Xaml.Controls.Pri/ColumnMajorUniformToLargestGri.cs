using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class ColumnMajorUniformToLargestGridLayout : NonVirtualizingLayout
{
	private int m_actualColumnCount = 1;

	private Size m_largestChildSize = Size.Empty;

	private bool m_testHooksEnabled;

	private int m_rows = -1;

	private int m_columns = -1;

	private int m_largerColumns = -1;

	public static readonly DependencyProperty ColumnSpacingProperty = DependencyProperty.Register("ColumnSpacing", typeof(double), typeof(ColumnMajorUniformToLargestGridLayout), new FrameworkPropertyMetadata(0.0, OnColumnSpacingPropertyChanged));

	public static readonly DependencyProperty MaxColumnsProperty = DependencyProperty.Register("MaxColumns", typeof(int), typeof(ColumnMajorUniformToLargestGridLayout), new FrameworkPropertyMetadata(0, OnMaxColumnsPropertyChanged));

	public static readonly DependencyProperty RowSpacingProperty = DependencyProperty.Register("RowSpacing", typeof(double), typeof(ColumnMajorUniformToLargestGridLayout), new FrameworkPropertyMetadata(0.0, OnRowSpacingPropertyChanged));

	public double ColumnSpacing
	{
		get
		{
			return (double)GetValue(ColumnSpacingProperty);
		}
		set
		{
			SetValue(ColumnSpacingProperty, value);
		}
	}

	public int MaxColumns
	{
		get
		{
			return (int)GetValue(MaxColumnsProperty);
		}
		set
		{
			SetValue(MaxColumnsProperty, value);
		}
	}

	public double RowSpacing
	{
		get
		{
			return (double)GetValue(RowSpacingProperty);
		}
		set
		{
			SetValue(RowSpacingProperty, value);
		}
	}

	internal event TypedEventHandler<ColumnMajorUniformToLargestGridLayout, object> LayoutChanged;

	protected internal override Size MeasureOverride(NonVirtualizingLayoutContext context, Size availableSize)
	{
		IReadOnlyList<UIElement> children = context.Children;
		if (children != null)
		{
			m_largestChildSize = GetLargestChildSize();
			m_actualColumnCount = CalculateColumns(children.Count, m_largestChildSize.Width, availableSize.Width);
			int num = (int)Math.Ceiling((double)children.Count / (double)m_actualColumnCount);
			return new Size(m_largestChildSize.Width * (double)m_actualColumnCount + (double)((float)ColumnSpacing * (float)(m_actualColumnCount - 1)), m_largestChildSize.Height * (double)num + (double)((float)RowSpacing * (float)(num - 1)));
		}
		return new Size(0.0, 0.0);
		Size GetLargestChildSize()
		{
			double num2 = 0.0;
			double num3 = 0.0;
			foreach (UIElement item in children)
			{
				item.Measure(availableSize);
				Size desiredSize = item.DesiredSize;
				if (desiredSize.Width > num2)
				{
					num2 = desiredSize.Width;
				}
				if (desiredSize.Height > num3)
				{
					num3 = desiredSize.Height;
				}
			}
			return new Size(num2, num3);
		}
	}

	protected internal override Size ArrangeOverride(NonVirtualizingLayoutContext context, Size finalSize)
	{
		IReadOnlyList<UIElement> children = context.Children;
		if (children != null)
		{
			int count = children.Count;
			int num = (int)Math.Floor((float)count / (float)m_actualColumnCount);
			int num2 = count % m_actualColumnCount;
			float num3 = (float)ColumnSpacing;
			float num4 = (float)RowSpacing;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = 0;
			int num8 = 0;
			foreach (UIElement item in children)
			{
				Size desiredSize = item.DesiredSize;
				item.Arrange(new Rect(num5, num6, desiredSize.Width, desiredSize.Height));
				if (num8 < num2)
				{
					if (num7 % (num + 1) == num)
					{
						num5 += m_largestChildSize.Width + (double)num3;
						num6 = 0.0;
						num8++;
					}
					else
					{
						num6 += m_largestChildSize.Height + (double)num4;
					}
				}
				else
				{
					int num9 = num7 - num2 * (num + 1);
					if (num9 % num == num - 1)
					{
						num5 += m_largestChildSize.Width + (double)num3;
						num6 = 0.0;
						num8++;
					}
					else
					{
						num6 += m_largestChildSize.Height + (double)num4;
					}
				}
				num7++;
			}
			if (m_testHooksEnabled && (m_largerColumns != num2 || m_columns != num8 || m_rows != num))
			{
				m_largerColumns = num2;
				m_columns = num8;
				m_rows = num;
				this.LayoutChanged?.Invoke(this, null);
			}
		}
		return finalSize;
	}

	private void OnColumnSpacingPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		InvalidateMeasure();
	}

	private void OnRowSpacingPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		InvalidateMeasure();
	}

	private void OnMaxColumnsPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		InvalidateMeasure();
	}

	private int CalculateColumns(int childCount, double maxItemWidth, double availableWidth)
	{
		double num = ColumnSpacing + maxItemWidth;
		int num2 = Math.Min(MaxColumns, childCount);
		if (num < 1.4012984643248171E-45)
		{
			return num2;
		}
		double num3 = availableWidth - maxItemWidth;
		double num4 = Math.Max(0.0, Math.Floor(num3 / num));
		double num5 = Math.Min(num2, num4 + 1.0);
		return Math.Max(1, (int)num5);
	}

	private void ValidateGreaterThanZero(int value)
	{
		if (value <= 0)
		{
			throw new ArgumentOutOfRangeException("value");
		}
	}

	internal void SetTestHooksEnabled(bool enabled)
	{
		m_testHooksEnabled = enabled;
	}

	internal int GetRows()
	{
		return m_rows;
	}

	internal int GetColumns()
	{
		return m_columns;
	}

	internal int GetLargerColumns()
	{
		return m_largerColumns;
	}

	private static void OnColumnSpacingPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		ColumnMajorUniformToLargestGridLayout columnMajorUniformToLargestGridLayout = (ColumnMajorUniformToLargestGridLayout)sender;
		columnMajorUniformToLargestGridLayout.OnColumnSpacingPropertyChanged(args);
	}

	private static void OnMaxColumnsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		ColumnMajorUniformToLargestGridLayout columnMajorUniformToLargestGridLayout = (ColumnMajorUniformToLargestGridLayout)sender;
		int num = (int)args.NewValue;
		int num2 = num;
		columnMajorUniformToLargestGridLayout.ValidateGreaterThanZero(num2);
		if (num != num2)
		{
			sender.SetValue(args.Property, num2);
		}
		else
		{
			columnMajorUniformToLargestGridLayout.OnMaxColumnsPropertyChanged(args);
		}
	}

	private static void OnRowSpacingPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		ColumnMajorUniformToLargestGridLayout columnMajorUniformToLargestGridLayout = (ColumnMajorUniformToLargestGridLayout)sender;
		columnMajorUniformToLargestGridLayout.OnRowSpacingPropertyChanged(args);
	}
}

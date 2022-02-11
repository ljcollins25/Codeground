namespace Windows.UI.Xaml.Controls;

internal class ItemsWrapGridLayout
{
	public double ItemHeight
	{
		get
		{
			return (double)this.GetValue(ItemHeightProperty);
		}
		set
		{
			this.SetValue(ItemHeightProperty, value);
		}
	}

	public static DependencyProperty ItemHeightProperty { get; } = DependencyProperty.Register("ItemHeight", typeof(double), typeof(ItemsWrapGridLayout), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGridLayout)s)?.OnItemHeightChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double ItemWidth
	{
		get
		{
			return (double)this.GetValue(ItemWidthProperty);
		}
		set
		{
			this.SetValue(ItemWidthProperty, value);
		}
	}

	public static DependencyProperty ItemWidthProperty { get; } = DependencyProperty.Register("ItemWidth", typeof(double), typeof(ItemsWrapGridLayout), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGridLayout)s)?.OnItemWidthChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public int MaximumRowsOrColumns
	{
		get
		{
			return (int)this.GetValue(MaximumRowsOrColumnsProperty);
		}
		set
		{
			this.SetValue(MaximumRowsOrColumnsProperty, value);
		}
	}

	public static DependencyProperty MaximumRowsOrColumnsProperty { get; } = DependencyProperty.Register("MaximumRowsOrColumns", typeof(int), typeof(ItemsWrapGridLayout), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGridLayout)s)?.OnMaximumRowsOrColumnsChanged((int)e.OldValue, (int)e.NewValue);
	}));


	protected virtual void OnItemHeightChanged(double oldItemHeight, double newItemHeight)
	{
	}

	protected virtual void OnItemWidthChanged(double oldItemWidth, double newItemWidth)
	{
	}

	protected virtual void OnMaximumRowsOrColumnsChanged(int oldMaximumRowsOrColumns, int newMaximumRowsOrColumns)
	{
	}
}

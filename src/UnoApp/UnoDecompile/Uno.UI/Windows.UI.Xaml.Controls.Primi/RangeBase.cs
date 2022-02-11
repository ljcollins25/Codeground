namespace Windows.UI.Xaml.Controls.Primitives;

public abstract class RangeBase : Control
{
	public double Value
	{
		get
		{
			return (double)GetValue(ValueProperty);
		}
		set
		{
			SetValue(ValueProperty, value);
		}
	}

	public static DependencyProperty ValueProperty { get; } = DependencyProperty.Register("Value", typeof(double), typeof(RangeBase), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as RangeBase)?.OnValueChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double Minimum
	{
		get
		{
			return (double)GetValue(MinimumProperty);
		}
		set
		{
			SetValue(MinimumProperty, value);
		}
	}

	public static DependencyProperty MinimumProperty { get; } = DependencyProperty.Register("Minimum", typeof(double), typeof(RangeBase), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as RangeBase)?.OnMinimumChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double Maximum
	{
		get
		{
			return (double)GetValue(MaximumProperty);
		}
		set
		{
			SetValue(MaximumProperty, value);
		}
	}

	public static DependencyProperty MaximumProperty { get; } = DependencyProperty.Register("Maximum", typeof(double), typeof(RangeBase), new FrameworkPropertyMetadata(1.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as RangeBase)?.OnMaximumChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double SmallChange
	{
		get
		{
			return (double)GetValue(SmallChangeProperty);
		}
		set
		{
			SetValue(SmallChangeProperty, value);
		}
	}

	public static DependencyProperty SmallChangeProperty { get; } = DependencyProperty.Register("SmallChange", typeof(double), typeof(RangeBase), new FrameworkPropertyMetadata(0.1, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as RangeBase)?.OnSmallChangeChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double LargeChange
	{
		get
		{
			return (double)GetValue(LargeChangeProperty);
		}
		set
		{
			SetValue(LargeChangeProperty, value);
		}
	}

	public static DependencyProperty LargeChangeProperty { get; } = DependencyProperty.Register("LargeChange", typeof(double), typeof(RangeBase), new FrameworkPropertyMetadata(1.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnLargeChangeChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double ActualValue
	{
		get
		{
			return (double)GetValue(ActualValueProperty);
		}
		private set
		{
			SetValue(ActualValueProperty, value);
		}
	}

	public static DependencyProperty ActualValueProperty { get; } = DependencyProperty.Register("ActualValue", typeof(double), typeof(RangeBase), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as RangeBase)?.OnActualValueChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public event RangeBaseValueChangedEventHandler ValueChanged;

	public RangeBase()
	{
		base.DefaultStyleKey = typeof(RangeBase);
	}

	protected virtual void OnValueChanged(double oldValue, double newValue)
	{
		this.ValueChanged?.Invoke(this, new RangeBaseValueChangedEventArgs(this)
		{
			OldValue = oldValue,
			NewValue = newValue
		});
		UpdateValues();
	}

	protected virtual void OnMinimumChanged(double oldValue, double newValue)
	{
		if (Minimum < 0.0)
		{
			Maximum = 0.0;
		}
		if (Minimum > Maximum)
		{
			Maximum = Minimum;
		}
		UpdateValues();
	}

	protected virtual void OnMaximumChanged(double oldValue, double newValue)
	{
		if (Maximum < Minimum)
		{
			Minimum = Maximum;
		}
		UpdateValues();
	}

	protected virtual void OnSmallChangeChanged(double oldValue, double newValue)
	{
	}

	private static void OnLargeChangeChanged(double oldValue, double newValue)
	{
	}

	protected virtual void OnActualValueChanged(double oldValue, double newValue)
	{
	}

	private void UpdateValues()
	{
		if (Value < Minimum)
		{
			Value = Minimum;
		}
		else if (Value > Maximum)
		{
			Value = Maximum;
		}
		ActualValue = (Value - Minimum) / (Maximum - Minimum);
	}
}

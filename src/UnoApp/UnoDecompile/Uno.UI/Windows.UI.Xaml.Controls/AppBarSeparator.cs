namespace Windows.UI.Xaml.Controls;

public class AppBarSeparator : Control, ICommandBarElement, ICommandBarElement2, ICommandBarElement3, ICommandBarOverflowElement
{
	public bool IsCompact
	{
		get
		{
			return (bool)GetValue(IsCompactProperty);
		}
		set
		{
			SetValue(IsCompactProperty, value);
		}
	}

	public static DependencyProperty IsCompactProperty { get; } = DependencyProperty.Register("IsCompact", typeof(bool), typeof(AppBarSeparator), new FrameworkPropertyMetadata(false));


	public int DynamicOverflowOrder
	{
		get
		{
			return (int)GetValue(DynamicOverflowOrderProperty);
		}
		set
		{
			SetValue(DynamicOverflowOrderProperty, value);
		}
	}

	public static DependencyProperty DynamicOverflowOrderProperty { get; } = DependencyProperty.Register("DynamicOverflowOrder", typeof(int), typeof(AppBarSeparator), new FrameworkPropertyMetadata(0));


	public bool IsInOverflow
	{
		get
		{
			return CommandBar.IsCommandBarElementInOverflow(this);
		}
		internal set
		{
			SetValue(IsInOverflowProperty, value);
		}
	}

	bool ICommandBarElement3.IsInOverflow
	{
		get
		{
			return IsInOverflow;
		}
		set
		{
			IsInOverflow = value;
		}
	}

	public static DependencyProperty IsInOverflowProperty { get; } = DependencyProperty.Register("IsInOverflow", typeof(bool), typeof(AppBarSeparator), new FrameworkPropertyMetadata(false));


	internal bool UseOverflowStyle
	{
		get
		{
			return (bool)GetValue(UseOverflowStyleProperty);
		}
		set
		{
			SetValue(UseOverflowStyleProperty, value);
		}
	}

	bool ICommandBarOverflowElement.UseOverflowStyle
	{
		get
		{
			return UseOverflowStyle;
		}
		set
		{
			UseOverflowStyle = value;
		}
	}

	internal static DependencyProperty UseOverflowStyleProperty { get; } = DependencyProperty.Register("UseOverflowStyle", typeof(bool), typeof(AppBarSeparator), new FrameworkPropertyMetadata(false));


	public AppBarSeparator()
	{
		base.DefaultStyleKey = typeof(AppBarSeparator);
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == IsCompactProperty || args.Property == UseOverflowStyleProperty)
		{
			UpdateVisualState();
		}
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		UpdateVisualState();
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool flag = false;
		bool flag2 = false;
		base.ChangeVisualState(useTransitions);
		flag2 = UseOverflowStyle;
		flag = IsCompact;
		if (flag2)
		{
			GoToState(useTransitions, "Overflow");
		}
		else if (flag)
		{
			GoToState(useTransitions, "Compact");
		}
		else
		{
			GoToState(useTransitions, "FullSize");
		}
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		CommandBar.OnCommandBarElementVisibilityChanged(this);
	}
}

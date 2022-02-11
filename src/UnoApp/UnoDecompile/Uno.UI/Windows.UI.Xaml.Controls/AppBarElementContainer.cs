namespace Windows.UI.Xaml.Controls;

public class AppBarElementContainer : ContentControl, ICommandBarElement, ICommandBarElement2, ICommandBarOverflowElement, ICommandBarElement3
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

	public static DependencyProperty IsCompactProperty { get; } = DependencyProperty.Register("IsCompact", typeof(bool), typeof(AppBarElementContainer), new FrameworkPropertyMetadata(false));


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

	public static DependencyProperty DynamicOverflowOrderProperty { get; } = DependencyProperty.Register("DynamicOverflowOrder", typeof(int), typeof(AppBarElementContainer), new FrameworkPropertyMetadata(0));


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

	public static DependencyProperty IsInOverflowProperty { get; } = DependencyProperty.Register("IsInOverflow", typeof(bool), typeof(AppBarElementContainer), new FrameworkPropertyMetadata(false));


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

	internal static DependencyProperty UseOverflowStyleProperty { get; } = DependencyProperty.Register("UseOverflowStyle", typeof(bool), typeof(AppBarElementContainer), new FrameworkPropertyMetadata(false));

}

namespace Windows.UI.Xaml;

public class StateTrigger : StateTriggerBase
{
	public bool IsActive
	{
		get
		{
			return (bool)GetValue(IsActiveProperty);
		}
		set
		{
			SetValue(IsActiveProperty, value);
		}
	}

	public static DependencyProperty IsActiveProperty { get; } = DependencyProperty.Register("IsActive", typeof(bool), typeof(StateTrigger), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as StateTrigger)?.OnIsActiveChanged(e);
	}));


	private void OnIsActiveChanged(DependencyPropertyChangedEventArgs e)
	{
		object newValue = e.NewValue;
		if (newValue is bool)
		{
			bool active = (bool)newValue;
			SetActive(active);
		}
	}
}

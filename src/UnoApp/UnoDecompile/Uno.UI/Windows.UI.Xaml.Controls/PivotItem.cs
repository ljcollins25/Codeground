using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class PivotItem : ContentControl
{
	internal PivotHeaderItem PivotHeaderItem { get; set; }

	protected override bool CanCreateTemplateWithoutParent => true;

	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(PivotItem), new FrameworkPropertyMetadata(null, OnHeaderChanged));


	public PivotItem()
	{
		base.HorizontalAlignment = HorizontalAlignment.Stretch;
		base.VerticalAlignment = VerticalAlignment.Stretch;
		base.HorizontalContentAlignment = HorizontalAlignment.Stretch;
		base.VerticalContentAlignment = VerticalAlignment.Stretch;
		base.DefaultStyleKey = typeof(PivotItem);
	}

	public PivotItem(string header)
		: this()
	{
		Header = header;
	}

	private static void OnHeaderChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is PivotItem pivotItem && pivotItem.PivotHeaderItem != null)
		{
			pivotItem.PivotHeaderItem.Content = args.NewValue;
		}
	}
}

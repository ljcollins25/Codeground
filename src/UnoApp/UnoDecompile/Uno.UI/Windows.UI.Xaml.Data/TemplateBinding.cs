namespace Windows.UI.Xaml.Data;

public class TemplateBinding : Binding
{
	public TemplateBinding(PropertyPath path = null, IValueConverter converter = null, object converterParameter = null)
		: base(path, converter, converterParameter)
	{
		base.RelativeSource = RelativeSource.TemplatedParent;
	}
}

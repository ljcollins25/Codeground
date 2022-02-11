namespace Uno.UI.DataBinding;

public static class BindableMetadata
{
	public static IBindableMetadataProvider? Provider
	{
		get
		{
			return BindingPropertyHelper.BindableMetadataProvider;
		}
		set
		{
			BindingPropertyHelper.BindableMetadataProvider = value;
		}
	}
}

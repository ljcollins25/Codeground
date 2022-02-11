using Uno.UI.DataBinding;

namespace Windows.UI.Xaml.Data;

internal class ResourceBinding : BindingBase
{
	public SpecializedResourceDictionary.ResourceKey ResourceKey { get; }

	public ResourceUpdateReason UpdateReason { get; }

	public bool IsThemeResourceExtension { get; }

	public bool IsPersistent => UpdateReason != ResourceUpdateReason.StaticResourceLoading;

	public object? ParseContext { get; }

	public DependencyPropertyValuePrecedences Precedence { get; }

	public BindingPath? SetterBindingPath { get; }

	public ResourceBinding(SpecializedResourceDictionary.ResourceKey resourceKey, ResourceUpdateReason updateReason, object? parseContext, DependencyPropertyValuePrecedences precedence, BindingPath? setterBindingPath)
	{
		ResourceKey = resourceKey;
		UpdateReason = updateReason;
		ParseContext = parseContext;
		Precedence = precedence;
		SetterBindingPath = setterBindingPath;
	}
}

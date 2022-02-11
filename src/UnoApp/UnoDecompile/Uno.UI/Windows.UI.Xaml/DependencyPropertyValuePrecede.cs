namespace Windows.UI.Xaml;

public enum DependencyPropertyValuePrecedences
{
	Coercion,
	Animations,
	Local,
	TemplatedParent,
	ExplicitStyle,
	ImplicitStyle,
	Inheritance,
	DefaultStyle,
	DefaultValue
}

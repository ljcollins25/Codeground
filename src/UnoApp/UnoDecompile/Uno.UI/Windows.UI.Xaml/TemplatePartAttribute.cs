using System;

namespace Windows.UI.Xaml;

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public sealed class TemplatePartAttribute : Attribute
{
	public string Name { get; set; }

	public Type Type { get; set; }
}

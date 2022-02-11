using System;

namespace Windows.UI.Xaml;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class TemplateVisualStateAttribute : Attribute
{
	public string GroupName;

	public string Name;
}

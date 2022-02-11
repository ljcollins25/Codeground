using System;

namespace Windows.UI.Xaml;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class StyleTypedPropertyAttribute : Attribute
{
	public string Property;

	public Type StyleTargetType;
}

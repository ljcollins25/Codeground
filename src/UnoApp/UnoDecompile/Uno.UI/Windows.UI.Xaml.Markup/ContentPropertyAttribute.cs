using System;

namespace Windows.UI.Xaml.Markup;

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class ContentPropertyAttribute : Attribute
{
	private string _name;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}
}

using System;

namespace Windows.UI.Xaml.Controls;

public class ControlTemplate : FrameworkTemplate
{
	public Type? TargetType { get; set; }

	public ControlTemplate()
		: this(null)
	{
	}

	public ControlTemplate(Func<UIElement?>? factory)
		: base(factory)
	{
	}

	public ControlTemplate(object? owner, FrameworkTemplateBuilder? factory)
		: base(owner, factory)
	{
	}

	public static implicit operator ControlTemplate(Func<UIElement>? obj)
	{
		return new ControlTemplate(obj);
	}
}

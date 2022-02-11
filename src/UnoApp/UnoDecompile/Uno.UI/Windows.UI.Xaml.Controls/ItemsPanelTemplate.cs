using System;

namespace Windows.UI.Xaml.Controls;

public class ItemsPanelTemplate : FrameworkTemplate
{
	public ItemsPanelTemplate()
		: this(null)
	{
	}

	public ItemsPanelTemplate(Func<UIElement?>? factory)
		: base(factory)
	{
	}

	public ItemsPanelTemplate(object? owner, FrameworkTemplateBuilder? factory)
		: base(owner, factory)
	{
	}

	public static implicit operator ItemsPanelTemplate(Func<UIElement?>? obj)
	{
		return new ItemsPanelTemplate(obj);
	}

	public static implicit operator Func<UIElement?>(ItemsPanelTemplate? obj)
	{
		ItemsPanelTemplate obj2 = obj;
		return () => obj2?.LoadContent();
	}

	public new UIElement? LoadContent()
	{
		return base.LoadContent();
	}
}

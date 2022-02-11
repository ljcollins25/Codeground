using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Windows.UI.Xaml;

namespace Uno.UI.Extensions;

public static class UIElementExtensions
{
	internal enum IndentationFormat
	{
		Tabs,
		Columns,
		Numbered,
		NumberedColumns,
		NumberedSpaces
	}

	private static readonly IndentationFormat _defaultIndentationFormat = IndentationFormat.NumberedSpaces;

	private static Dictionary<(Type type, string property), DependencyProperty?>? _dependencyPropertyReflectionCache;

	internal static string GetDebugName(this object? elt)
	{
		if (elt != null)
		{
			UIElement uIElement;
			if (!(elt is FrameworkElement frameworkElement))
			{
				uIElement = elt as UIElement;
				if (uIElement == null)
				{
					return $"{elt!.GetType().Name}-{elt!.GetHashCode():X8}";
				}
			}
			else
			{
				if (frameworkElement.Name.HasValue())
				{
					return $"{frameworkElement.Name}-{frameworkElement.HtmlId}";
				}
				uIElement = (UIElement)elt;
			}
			return $"{elt!.GetType().Name}-{uIElement.HtmlId}";
		}
		return "--null--";
	}

	internal static string GetDebugIdentifier(this object? elt)
	{
		int debugDepth = elt.GetDebugDepth();
		IndentationFormat defaultIndentationFormat = _defaultIndentationFormat;
		string text;
		int num;
		if (defaultIndentationFormat != IndentationFormat.Numbered)
		{
			if (defaultIndentationFormat == IndentationFormat.NumberedColumns)
			{
				if (debugDepth < 0)
				{
					text = "?>";
					goto IL_00ed;
				}
				num = 3;
			}
			else
			{
				num = 4;
			}
		}
		else
		{
			if (debugDepth < 0)
			{
				text = "-?>";
				goto IL_00ed;
			}
			num = 1;
		}
		if (debugDepth < 0)
		{
			goto IL_007e;
		}
		switch (num)
		{
		case 4:
			break;
		default:
			goto IL_007e;
		case 1:
			goto IL_008f;
		case 3:
			goto IL_0098;
		}
		text = defaultIndentationFormat switch
		{
			IndentationFormat.Columns => GetColumnsIndentation(debugDepth), 
			IndentationFormat.NumberedSpaces => $"{new string(' ', debugDepth * 2)} {debugDepth:D2}>", 
			IndentationFormat.Tabs => new string('\t', debugDepth) ?? "", 
			_ => $"{new string(' ', debugDepth * 2)} {debugDepth:D2}>", 
		};
		goto IL_00ed;
		IL_0098:
		text = GetNumberedColumnIndentation(debugDepth);
		goto IL_00ed;
		IL_00ed:
		string text2 = text;
		return text2 + "[" + elt.GetDebugName() + "]";
		IL_007e:
		text = "";
		goto IL_00ed;
		IL_008f:
		text = GetNumberedIndentation(debugDepth);
		goto IL_00ed;
		static string GetColumnsIndentation(int depth)
		{
			StringBuilder stringBuilder3 = new StringBuilder(depth * 2);
			for (int k = 0; k < depth; k++)
			{
				stringBuilder3.Append('|');
				stringBuilder3.Append(' ');
			}
			return stringBuilder3.ToString();
		}
		static string GetNumberedColumnIndentation(int depth)
		{
			StringBuilder stringBuilder2 = new StringBuilder(depth * 4);
			for (int j = 0; j < depth - 1; j++)
			{
				stringBuilder2.Append(' ', j.ToString().Length);
				stringBuilder2.Append('|');
			}
			stringBuilder2.Append(depth);
			stringBuilder2.Append('>');
			return stringBuilder2.ToString();
		}
		static string GetNumberedIndentation(int depth)
		{
			StringBuilder stringBuilder = new StringBuilder(depth * 4);
			for (int i = 0; i < depth; i++)
			{
				stringBuilder.Append('-');
				stringBuilder.Append(i);
				stringBuilder.Append('>');
			}
			return stringBuilder.ToString();
		}
	}

	internal static int GetDebugDepth(this object? elt)
	{
		if (elt != null)
		{
			if (elt is UIElement uIElement)
			{
				return uIElement.Depth;
			}
			object parent = elt.GetParent();
			return (parent != null) ? (parent.GetDebugDepth() + 1) : 0;
		}
		return 0;
	}

	internal static CornerRadius GetCornerRadius(this UIElement uiElement)
	{
		if (uiElement is FrameworkElement frameworkElement && frameworkElement.TryGetCornerRadius(out var cornerRadius))
		{
			return cornerRadius;
		}
		DependencyProperty dependencyProperty = uiElement.FindDependencyPropertyUsingReflection<Thickness>("CornerRadius");
		if (dependencyProperty != null)
		{
			object value = uiElement.GetValue(dependencyProperty);
			if (value is CornerRadius)
			{
				return (CornerRadius)value;
			}
		}
		return default(CornerRadius);
	}

	internal static Thickness GetPadding(this UIElement uiElement)
	{
		if (uiElement is FrameworkElement frameworkElement && frameworkElement.TryGetPadding(out var padding))
		{
			return padding;
		}
		DependencyProperty dependencyProperty = uiElement.FindDependencyPropertyUsingReflection<Thickness>("PaddingProperty");
		if (dependencyProperty != null)
		{
			object value = uiElement.GetValue(dependencyProperty);
			if (value is Thickness)
			{
				return (Thickness)value;
			}
		}
		return default(Thickness);
	}

	internal static Thickness GetBorderThickness(this UIElement uiElement)
	{
		if (uiElement is FrameworkElement frameworkElement && frameworkElement.TryGetBorderThickness(out var borderThickness))
		{
			return borderThickness;
		}
		DependencyProperty dependencyProperty = uiElement.FindDependencyPropertyUsingReflection<Thickness>("BorderThicknessProperty");
		if (dependencyProperty != null)
		{
			object value = uiElement.GetValue(dependencyProperty);
			if (value is Thickness)
			{
				return (Thickness)value;
			}
		}
		return default(Thickness);
	}

	internal static bool SetPadding(this UIElement uiElement, Thickness padding)
	{
		if (uiElement is FrameworkElement frameworkElement && frameworkElement.TrySetPadding(padding))
		{
			return true;
		}
		DependencyProperty dependencyProperty = uiElement.FindDependencyPropertyUsingReflection<Thickness>("PaddingProperty");
		if (dependencyProperty != null)
		{
			uiElement.SetValue(dependencyProperty, padding);
			return true;
		}
		return false;
	}

	internal static bool SetBorderThickness(this UIElement uiElement, Thickness borderThickness)
	{
		if (uiElement is FrameworkElement frameworkElement && frameworkElement.TrySetBorderThickness(borderThickness))
		{
			return true;
		}
		DependencyProperty dependencyProperty = uiElement.FindDependencyPropertyUsingReflection<Thickness>("BorderThicknessProperty");
		if (dependencyProperty != null)
		{
			uiElement.SetValue(dependencyProperty, borderThickness);
			return true;
		}
		return false;
	}

	internal static DependencyProperty? FindDependencyPropertyUsingReflection<TProperty>(this UIElement uiElement, string propertyName)
	{
		Type type = uiElement.GetType();
		Type typeFromHandle = typeof(TProperty);
		(Type, string) key = (type, propertyName);
		if (_dependencyPropertyReflectionCache == null)
		{
			_dependencyPropertyReflectionCache = new Dictionary<(Type, string), DependencyProperty>(2);
		}
		if (_dependencyPropertyReflectionCache!.TryGetValue(key, out var value))
		{
			return value;
		}
		value = (type.GetTypeInfo().GetDeclaredProperty(propertyName)?.GetValue(null) as DependencyProperty) ?? (type.GetTypeInfo().GetDeclaredField(propertyName)?.GetValue(null) as DependencyProperty);
		if (value == null)
		{
			uiElement.Log().Warn($"The {propertyName} dependency property does not exist on {type}");
		}
		else if (value.Type != typeFromHandle)
		{
			uiElement.Log().Warn($"The {propertyName} dependency property {type} is not of the {typeFromHandle} Type.");
			value = null;
		}
		_dependencyPropertyReflectionCache![key] = value;
		return value;
	}

	public static FrameworkElement GetTopLevelParent(this UIElement view)
	{
		FrameworkElement frameworkElement = view as FrameworkElement;
		while (frameworkElement != null && frameworkElement.Parent is FrameworkElement frameworkElement2)
		{
			frameworkElement = frameworkElement2;
		}
		return frameworkElement;
	}
}

using System;
using System.Reflection;
using Microsoft.UI.Xaml.Controls;
using Uno.Extensions;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml;

internal static class FrameworkElementExtensions
{
	public static T Style<T>(this T element, Style style) where T : IFrameworkElement
	{
		element.Style = style;
		return element;
	}

	public static T Binding<T>(this T element, string property, string propertyPath, string converter) where T : IDependencyObjectStoreProvider
	{
		DependencyProperty dependencyProperty = GetDependencyProperty(element, property);
		PropertyPath path = new PropertyPath(propertyPath.Replace("].[", "]["));
		Binding binding = new Binding
		{
			Path = path,
			Converter = ResourceHelper.FindConverter(converter)
		};
		element.Store.SetBinding(dependencyProperty, binding);
		return element;
	}

	public static T Binding<T>(this T element, string property, string propertyPath, object source, BindingMode mode) where T : DependencyObject
	{
		return element.Binding(property, new Binding
		{
			Path = propertyPath,
			Source = source,
			Mode = mode
		});
	}

	public static T Binding<T>(this T element, string property, BindingBase binding) where T : DependencyObject
	{
		(element as IDependencyObjectStoreProvider).Store.SetBinding(property, binding);
		return element;
	}

	private static DependencyProperty GetDependencyProperty(object element, string propertyName)
	{
		DependencyProperty dependencyProperty = GetDependencyPropertyFromProperties(element, propertyName);
		if (dependencyProperty == null)
		{
			dependencyProperty = GetDependencyPropertyFromFields(element, propertyName);
		}
		if (dependencyProperty == null)
		{
			throw new InvalidOperationException("Unable to find the dependency property [{0}]".InvariantCultureFormat(propertyName));
		}
		return dependencyProperty;
	}

	private static DependencyProperty GetDependencyPropertyFromFields(object element, string property)
	{
		FieldInfo fieldInfo = null;
		Type type = element.GetType();
		do
		{
			fieldInfo = type.GetTypeInfo().GetDeclaredField(property + "Property");
			if (fieldInfo == null)
			{
				type = type.GetTypeInfo().BaseType;
			}
		}
		while (type != null && fieldInfo == null);
		if (fieldInfo != null)
		{
			return (DependencyProperty)fieldInfo.GetValue(null);
		}
		return null;
	}

	private static DependencyProperty GetDependencyPropertyFromProperties(object element, string property)
	{
		PropertyInfo propertyInfo = null;
		Type type = element.GetType();
		do
		{
			propertyInfo = type.GetTypeInfo().GetDeclaredProperty(property + "Property");
			if (propertyInfo == null)
			{
				type = type.GetTypeInfo().BaseType;
			}
		}
		while (type != null && propertyInfo == null);
		if (propertyInfo != null)
		{
			return (DependencyProperty)propertyInfo.GetMethod!.Invoke(null, new object[0]);
		}
		return null;
	}

	public static T Binding<T>(this T element, string property, string propertyPath) where T : DependencyObject
	{
		PropertyPath path = new PropertyPath(propertyPath.Replace("].[", "]["));
		Binding binding = new Binding
		{
			Path = path
		};
		return element.Binding(property, binding);
	}

	public static Run Binding(this Run element, string property, string propertyPath)
	{
		propertyPath = propertyPath.Replace("].[", "][");
		if (property == "Text")
		{
			string instance = "<Run xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Text=\"{{Binding {0}}}\" />";
			return (Run)XamlReader.Load(instance.InvariantCultureFormat(propertyPath));
		}
		PropertyPath path = new PropertyPath(propertyPath);
		Binding binding = new Binding
		{
			Path = path
		};
		DependencyProperty dependencyProperty = GetDependencyProperty(element, property);
		BindingOperations.SetBinding(element, dependencyProperty, binding);
		return element;
	}

	public static T Margin<T>(this T element, Thickness margin) where T : IFrameworkElement
	{
		element.Margin = margin;
		return element;
	}

	public static T Name<T>(this T element, string name) where T : IFrameworkElement
	{
		element.Name = name;
		return element;
	}

	public static T MaxWidth<T>(this T element, float maxWidth) where T : IFrameworkElement
	{
		element.MaxWidth = maxWidth;
		return element;
	}

	public static T MaxHeight<T>(this T element, float maxHeight) where T : IFrameworkElement
	{
		element.MaxHeight = maxHeight;
		return element;
	}

	public static T Margin<T>(this T element, float left, float top, float right, float bottom) where T : IFrameworkElement
	{
		return element.Margin(new Thickness(left, top, right, bottom));
	}

	public static T Margin<T>(this T element, float leftRight, float topBottom) where T : IFrameworkElement
	{
		return element.Margin(new Thickness(leftRight, topBottom));
	}

	internal static T BindToEquivalentProperty<T>(this T element, object source, string property, BindingMode bindingMode = BindingMode.OneWay) where T : DependencyObject
	{
		return element.Binding(property, property, source, bindingMode);
	}

	internal static bool TryGetPadding(this IFrameworkElement frameworkElement, out Thickness padding)
	{
		if (!(frameworkElement is Grid grid))
		{
			if (!(frameworkElement is StackPanel stackPanel))
			{
				if (!(frameworkElement is RelativePanel relativePanel))
				{
					if (!(frameworkElement is LayoutPanel layoutPanel))
					{
						if (!(frameworkElement is Control control))
						{
							if (!(frameworkElement is ContentPresenter contentPresenter))
							{
								if (!(frameworkElement is Border border))
								{
									if (!(frameworkElement is ItemsPresenter itemsPresenter))
									{
										if (frameworkElement is TextBlock textBlock)
										{
											padding = textBlock.Padding;
											return true;
										}
										padding = default(Thickness);
										return false;
									}
									padding = itemsPresenter.Padding;
									return true;
								}
								padding = border.Padding;
								return true;
							}
							padding = contentPresenter.Padding;
							return true;
						}
						padding = control.Padding;
						return true;
					}
					padding = layoutPanel.Padding;
					return true;
				}
				padding = relativePanel.Padding;
				return true;
			}
			padding = stackPanel.Padding;
			return true;
		}
		padding = grid.Padding;
		return true;
	}

	internal static bool TrySetPadding(this IFrameworkElement frameworkElement, Thickness padding)
	{
		if (!(frameworkElement is Grid grid))
		{
			if (!(frameworkElement is StackPanel stackPanel))
			{
				if (!(frameworkElement is RelativePanel relativePanel))
				{
					if (!(frameworkElement is LayoutPanel layoutPanel))
					{
						if (!(frameworkElement is Control control))
						{
							if (!(frameworkElement is ContentPresenter contentPresenter))
							{
								if (frameworkElement is Border border)
								{
									border.Padding = padding;
									return true;
								}
								return false;
							}
							contentPresenter.Padding = padding;
							return true;
						}
						control.Padding = padding;
						return true;
					}
					layoutPanel.Padding = padding;
					return true;
				}
				relativePanel.Padding = padding;
				return true;
			}
			stackPanel.Padding = padding;
			return true;
		}
		grid.Padding = padding;
		return true;
	}

	internal static bool TryGetBorderThickness(this IFrameworkElement frameworkElement, out Thickness borderThickness)
	{
		if (!(frameworkElement is Grid grid))
		{
			if (!(frameworkElement is StackPanel stackPanel))
			{
				if (!(frameworkElement is RelativePanel relativePanel))
				{
					if (!(frameworkElement is LayoutPanel layoutPanel))
					{
						if (!(frameworkElement is Control control))
						{
							if (!(frameworkElement is ContentPresenter contentPresenter))
							{
								if (frameworkElement is Border border)
								{
									borderThickness = border.BorderThickness;
									return true;
								}
								borderThickness = default(Thickness);
								return false;
							}
							borderThickness = contentPresenter.BorderThickness;
							return true;
						}
						borderThickness = control.BorderThickness;
						return true;
					}
					borderThickness = layoutPanel.BorderThickness;
					return true;
				}
				borderThickness = relativePanel.BorderThickness;
				return true;
			}
			borderThickness = stackPanel.BorderThickness;
			return true;
		}
		borderThickness = grid.BorderThickness;
		return true;
	}

	internal static bool TrySetBorderThickness(this IFrameworkElement frameworkElement, Thickness borderThickness)
	{
		if (!(frameworkElement is Grid grid))
		{
			if (!(frameworkElement is StackPanel stackPanel))
			{
				if (!(frameworkElement is RelativePanel relativePanel))
				{
					if (!(frameworkElement is LayoutPanel layoutPanel))
					{
						if (!(frameworkElement is Control control))
						{
							if (!(frameworkElement is ContentPresenter contentPresenter))
							{
								if (frameworkElement is Border border)
								{
									border.BorderThickness = borderThickness;
									return true;
								}
								return false;
							}
							contentPresenter.BorderThickness = borderThickness;
							return true;
						}
						control.BorderThickness = borderThickness;
						return true;
					}
					layoutPanel.BorderThickness = borderThickness;
					return true;
				}
				relativePanel.BorderThickness = borderThickness;
				return true;
			}
			stackPanel.BorderThickness = borderThickness;
			return true;
		}
		grid.BorderThickness = borderThickness;
		return true;
	}

	internal static bool TryGetCornerRadius(this IFrameworkElement frameworkElement, out CornerRadius cornerRadius)
	{
		if (!(frameworkElement is Grid grid))
		{
			if (!(frameworkElement is StackPanel stackPanel))
			{
				if (!(frameworkElement is RelativePanel relativePanel))
				{
					if (!(frameworkElement is LayoutPanel layoutPanel))
					{
						if (!(frameworkElement is Control control))
						{
							if (!(frameworkElement is ContentPresenter contentPresenter))
							{
								if (frameworkElement is Border border)
								{
									cornerRadius = border.CornerRadius;
									return true;
								}
								cornerRadius = default(CornerRadius);
								return false;
							}
							cornerRadius = contentPresenter.CornerRadius;
							return true;
						}
						cornerRadius = control.CornerRadius;
						return true;
					}
					cornerRadius = layoutPanel.CornerRadius;
					return true;
				}
				cornerRadius = relativePanel.CornerRadius;
				return true;
			}
			cornerRadius = stackPanel.CornerRadius;
			return true;
		}
		cornerRadius = grid.CornerRadius;
		return true;
	}
}

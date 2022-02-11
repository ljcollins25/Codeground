using System;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Windows.Foundation;

namespace Windows.UI.Xaml.Markup;

public sealed class XamlBindingHelper
{
	private static readonly Action ResumeRenderingOnlyOnFrameworkElement = Actions.CreateOnce(delegate
	{
		typeof(XamlBindingHelper).Log().Error("ResumeRendering/SuspendRendering is only supported on FrameworkElement instances.");
	});

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DataTemplateComponentProperty { get; } = DependencyProperty.RegisterAttached("DataTemplateComponent", typeof(IDataTemplateComponent), typeof(XamlBindingHelper), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IDataTemplateComponent GetDataTemplateComponent(DependencyObject element)
	{
		return (IDataTemplateComponent)element.GetValue(DataTemplateComponentProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetDataTemplateComponent(DependencyObject element, IDataTemplateComponent value)
	{
		element.SetValue(DataTemplateComponentProperty, value);
	}

	public static object ConvertValue(Type type, object value)
	{
		return BindingPropertyHelper.Convert(() => type, value);
	}

	public static void ResumeRendering(UIElement target)
	{
		if (target is FrameworkElement frameworkElement)
		{
			frameworkElement.ResumeRendering();
		}
		else
		{
			ResumeRenderingOnlyOnFrameworkElement();
		}
	}

	public static void SuspendRendering(UIElement target)
	{
		if (target is FrameworkElement frameworkElement)
		{
			frameworkElement.SuspendRendering();
		}
		else
		{
			ResumeRenderingOnlyOnFrameworkElement();
		}
	}

	public static void SetPropertyFromBoolean(object dependencyObject, DependencyProperty propertyToSet, bool value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromByte(object dependencyObject, DependencyProperty propertyToSet, byte value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromChar16(object dependencyObject, DependencyProperty propertyToSet, char value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromDateTime(object dependencyObject, DependencyProperty propertyToSet, DateTimeOffset value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromDouble(object dependencyObject, DependencyProperty propertyToSet, double value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromInt32(object dependencyObject, DependencyProperty propertyToSet, int value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromInt64(object dependencyObject, DependencyProperty propertyToSet, long value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromObject(object dependencyObject, DependencyProperty propertyToSet, object value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromPoint(object dependencyObject, DependencyProperty propertyToSet, Point value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromRect(object dependencyObject, DependencyProperty propertyToSet, Rect value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromSingle(object dependencyObject, DependencyProperty propertyToSet, float value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromSize(object dependencyObject, DependencyProperty propertyToSet, Size value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromString(object dependencyObject, DependencyProperty propertyToSet, string value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromTimeSpan(object dependencyObject, DependencyProperty propertyToSet, TimeSpan value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromUInt32(object dependencyObject, DependencyProperty propertyToSet, uint value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromUInt64(object dependencyObject, DependencyProperty propertyToSet, ulong value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}

	public static void SetPropertyFromUri(object dependencyObject, DependencyProperty propertyToSet, Uri value)
	{
		(dependencyObject as DependencyObject).SetValue(propertyToSet, value);
	}
}

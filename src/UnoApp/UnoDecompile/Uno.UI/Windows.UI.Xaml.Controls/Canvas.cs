using Uno.UI;
using Uno.UI.Xaml;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

public class Canvas : Panel, ICustomClippingElement
{
	[GeneratedDependencyProperty(DefaultValue = 0.0, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, Options = FrameworkPropertyMetadataOptions.AutoConvert)]
	public static DependencyProperty LeftProperty { get; } = CreateLeftProperty();


	[GeneratedDependencyProperty(DefaultValue = 0.0, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, Options = FrameworkPropertyMetadataOptions.AutoConvert)]
	public static DependencyProperty TopProperty { get; } = CreateTopProperty();


	[GeneratedDependencyProperty(DefaultValue = 0.0, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, Options = FrameworkPropertyMetadataOptions.AutoConvert)]
	public static DependencyProperty ZIndexProperty { get; } = CreateZIndexProperty();


	bool ICustomClippingElement.AllowClippingToLayoutSlot => false;

	bool ICustomClippingElement.ForceClippingToLayoutSlot => false;

	public static double GetLeft(DependencyObject obj)
	{
		return GetLeftValue(obj);
	}

	public static void SetLeft(DependencyObject obj, double value)
	{
		SetLeftValue(obj, value);
	}

	private static void OnLeftChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		(dependencyObject as IFrameworkElement)?.InvalidateArrange();
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties && dependencyObject is UIElement uIElement)
		{
			uIElement.UpdateDOMXamlProperty("Canvas.Left", args.NewValue);
		}
	}

	public static double GetTop(DependencyObject obj)
	{
		return GetTopValue(obj);
	}

	public static void SetTop(DependencyObject obj, double value)
	{
		SetTopValue(obj, value);
	}

	private static void OnTopChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		(dependencyObject as IFrameworkElement)?.InvalidateArrange();
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties && dependencyObject is UIElement uIElement)
		{
			uIElement.UpdateDOMXamlProperty("Canvas.Top", args.NewValue);
		}
	}

	public static double GetZIndex(DependencyObject obj)
	{
		return GetZIndexValue(obj);
	}

	public static void SetZIndex(DependencyObject obj, double value)
	{
		SetZIndexValue(obj, value);
	}

	private static void OnZIndexChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is UIElement element)
		{
			double? zindex = ((args.NewValue is double value) ? new double?(value) : null);
			OnZIndexChangedPartial(element, zindex);
		}
	}

	private static void OnZIndexChangedPartial(UIElement element, double? zindex)
	{
		if (zindex.HasValue)
		{
			double valueOrDefault = zindex.GetValueOrDefault();
			element.SetStyle("z-index", valueOrDefault);
		}
		else
		{
			element.ResetStyle("z-index");
		}
	}

	public static double GetLeft(UIElement element)
	{
		return GetLeft((DependencyObject)element);
	}

	public static void SetLeft(UIElement element, double length)
	{
		SetLeft((DependencyObject)element, length);
	}

	public static double GetTop(UIElement element)
	{
		return GetTop((DependencyObject)element);
	}

	public static void SetTop(UIElement element, double length)
	{
		SetTop((DependencyObject)element, length);
	}

	public static int GetZIndex(UIElement element)
	{
		return (int)GetZIndex((DependencyObject)element);
	}

	public static void SetZIndex(UIElement element, int value)
	{
		SetZIndex((DependencyObject)element, (double)value);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		foreach (UIElement child in base.Children)
		{
			if (child != null)
			{
				MeasureElement(child, new Size(double.PositiveInfinity, double.PositiveInfinity));
			}
		}
		return new Size(0.0, 0.0);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		foreach (UIElement child in base.Children)
		{
			if (child != null)
			{
				UIElement view = child;
				DependencyObject obj = child;
				Size elementDesiredSize = GetElementDesiredSize(view);
				Rect rect = default(Rect);
				rect.X = GetLeft(obj);
				rect.Y = GetTop(obj);
				rect.Width = elementDesiredSize.Width;
				rect.Height = elementDesiredSize.Height;
				Rect finalRect = rect;
				ArrangeElement(child, finalRect);
			}
		}
		return finalSize;
	}

	private static double GetLeftValue(DependencyObject instance)
	{
		if (instance is UIElement uIElement)
		{
			if (!uIElement.__Canvas_LeftPropertyBackingFieldSet)
			{
				uIElement.__Canvas_LeftPropertyBackingField = (double)instance.GetValue(LeftProperty);
				uIElement.__Canvas_LeftPropertyBackingFieldSet = true;
			}
			return uIElement.__Canvas_LeftPropertyBackingField;
		}
		return (double)instance.GetValue(LeftProperty);
	}

	private static void SetLeftValue(DependencyObject instance, double value)
	{
		instance.SetValue(LeftProperty, value);
	}

	private static DependencyProperty CreateLeftProperty()
	{
		return DependencyProperty.RegisterAttached("Left", typeof(double), typeof(Canvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AutoConvert, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			OnLeftChanged(instance, args);
		}, delegate(DependencyObject instance, object newValue)
		{
			if (instance is UIElement uIElement)
			{
				uIElement.__Canvas_LeftPropertyBackingField = (double)instance.GetValue(LeftProperty);
				uIElement.__Canvas_LeftPropertyBackingFieldSet = true;
			}
		}));
	}

	private static double GetTopValue(DependencyObject instance)
	{
		if (instance is UIElement uIElement)
		{
			if (!uIElement.__Canvas_TopPropertyBackingFieldSet)
			{
				uIElement.__Canvas_TopPropertyBackingField = (double)instance.GetValue(TopProperty);
				uIElement.__Canvas_TopPropertyBackingFieldSet = true;
			}
			return uIElement.__Canvas_TopPropertyBackingField;
		}
		return (double)instance.GetValue(TopProperty);
	}

	private static void SetTopValue(DependencyObject instance, double value)
	{
		instance.SetValue(TopProperty, value);
	}

	private static DependencyProperty CreateTopProperty()
	{
		return DependencyProperty.RegisterAttached("Top", typeof(double), typeof(Canvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AutoConvert, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			OnTopChanged(instance, args);
		}, delegate(DependencyObject instance, object newValue)
		{
			if (instance is UIElement uIElement)
			{
				uIElement.__Canvas_TopPropertyBackingField = (double)instance.GetValue(TopProperty);
				uIElement.__Canvas_TopPropertyBackingFieldSet = true;
			}
		}));
	}

	private static double GetZIndexValue(DependencyObject instance)
	{
		if (instance is UIElement uIElement)
		{
			if (!uIElement.__Canvas_ZIndexPropertyBackingFieldSet)
			{
				uIElement.__Canvas_ZIndexPropertyBackingField = (double)instance.GetValue(ZIndexProperty);
				uIElement.__Canvas_ZIndexPropertyBackingFieldSet = true;
			}
			return uIElement.__Canvas_ZIndexPropertyBackingField;
		}
		return (double)instance.GetValue(ZIndexProperty);
	}

	private static void SetZIndexValue(DependencyObject instance, double value)
	{
		instance.SetValue(ZIndexProperty, value);
	}

	private static DependencyProperty CreateZIndexProperty()
	{
		return DependencyProperty.RegisterAttached("ZIndex", typeof(double), typeof(Canvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AutoConvert, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			OnZIndexChanged(instance, args);
		}, delegate(DependencyObject instance, object newValue)
		{
			if (instance is UIElement uIElement)
			{
				uIElement.__Canvas_ZIndexPropertyBackingField = (double)instance.GetValue(ZIndexProperty);
				uIElement.__Canvas_ZIndexPropertyBackingFieldSet = true;
			}
		}));
	}
}

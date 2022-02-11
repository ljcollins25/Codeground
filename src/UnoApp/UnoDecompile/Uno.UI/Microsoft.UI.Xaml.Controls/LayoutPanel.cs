using System;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class LayoutPanel : Panel
{
	private LayoutContext m_layoutContext;

	private bool _BorderBrushPropertyBackingFieldSet;

	private Brush _BorderBrushPropertyBackingField;

	private bool _BorderThicknessPropertyBackingFieldSet;

	private Thickness _BorderThicknessPropertyBackingField;

	private bool _PaddingPropertyBackingFieldSet;

	private Thickness _PaddingPropertyBackingField;

	private bool _CornerRadiusPropertyBackingFieldSet;

	private CornerRadius _CornerRadiusPropertyBackingField;

	public object LayoutState { get; set; }

	public Brush BorderBrush
	{
		get
		{
			return GetBorderBrushValue();
		}
		set
		{
			SetBorderBrushValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallback = false, Options = FrameworkPropertyMetadataOptions.ValueInheritsDataContext)]
	public static DependencyProperty BorderBrushProperty { get; } = CreateBorderBrushProperty();


	public Thickness BorderThickness
	{
		get
		{
			return GetBorderThicknessValue();
		}
		set
		{
			SetBorderThicknessValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallback = false)]
	public static DependencyProperty BorderThicknessProperty { get; } = CreateBorderThicknessProperty();


	public Thickness Padding
	{
		get
		{
			return GetPaddingValue();
		}
		set
		{
			SetPaddingValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallback = false)]
	public static DependencyProperty PaddingProperty { get; } = CreatePaddingProperty();


	public CornerRadius CornerRadius
	{
		get
		{
			return GetCornerRadiusValue();
		}
		set
		{
			SetCornerRadiusValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallback = false)]
	public static DependencyProperty CornerRadiusProperty { get; } = CreateCornerRadiusProperty();


	public static DependencyProperty LayoutProperty { get; } = DependencyProperty.Register("Layout", typeof(Layout), typeof(LayoutPanel), new FrameworkPropertyMetadata((object)null));


	public Layout Layout
	{
		get
		{
			return (Layout)GetValue(LayoutProperty);
		}
		set
		{
			SetValue(LayoutProperty, value);
		}
	}

	public LayoutPanel()
	{
		this.RegisterDisposablePropertyChangedCallback(delegate(ManagedWeakReference i, DependencyProperty s, DependencyPropertyChangedEventArgs e)
		{
			OnPropertyChanged(e);
		});
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == LayoutProperty)
		{
			OnLayoutChanged(args.OldValue as Layout, args.NewValue as Layout);
		}
		else if (property == BorderBrushProperty)
		{
			OnBorderBrushChanged(newValue: base.BorderBrushInternal = (Brush)args.NewValue, oldValue: (Brush)args.OldValue);
		}
		else if (property == BorderThicknessProperty)
		{
			OnBorderThicknessChanged(newValue: base.BorderThicknessInternal = (Thickness)args.NewValue, oldValue: (Thickness)args.OldValue);
		}
		else if (property == CornerRadiusProperty)
		{
			OnCornerRadiusChanged(newValue: base.CornerRadiusInternal = (CornerRadius)args.NewValue, oldValue: (CornerRadius)args.OldValue);
		}
		else if (property == PaddingProperty)
		{
			OnPaddingChanged(newValue: base.PaddingInternal = (Thickness)args.NewValue, oldValue: (Thickness)args.OldValue);
			InvalidateMeasure();
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Thickness padding = Padding;
		Thickness borderThickness = BorderThickness;
		double num = padding.Left + padding.Right + borderThickness.Left + borderThickness.Right;
		double num2 = padding.Top + padding.Bottom + borderThickness.Top + borderThickness.Bottom;
		Size availableSize2 = availableSize;
		availableSize2.Width -= num;
		availableSize2.Height -= num2;
		availableSize2.Width = Math.Max(0.0, availableSize2.Width);
		availableSize2.Height = Math.Max(0.0, availableSize2.Height);
		Layout layout = Layout;
		Size result;
		if (layout != null)
		{
			Size size = layout.Measure(m_layoutContext, availableSize2);
			size.Width += num;
			size.Height += num2;
			result = size;
		}
		else
		{
			Size size2 = default(Size);
			foreach (UIElement child in base.Children)
			{
				child.Measure(availableSize2);
				Size desiredSize = child.DesiredSize;
				size2.Width = Math.Max(size2.Width, desiredSize.Width);
				size2.Height = Math.Max(size2.Height, desiredSize.Height);
			}
			result = size2;
			result.Width += num;
			result.Height += num2;
		}
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Thickness padding = Padding;
		Thickness borderThickness = BorderThickness;
		float num = (float)(padding.Left + padding.Right + borderThickness.Left + borderThickness.Right);
		float num2 = (float)(padding.Top + padding.Bottom + borderThickness.Top + borderThickness.Bottom);
		float num3 = (float)(padding.Left + borderThickness.Left);
		float num4 = (float)(padding.Top + borderThickness.Top);
		Size finalSize2 = finalSize;
		finalSize2.Width -= num;
		finalSize2.Height -= num2;
		finalSize2.Width = Math.Max(0.0, finalSize2.Width);
		finalSize2.Height = Math.Max(0.0, finalSize2.Height);
		Layout layout = Layout;
		if (layout != null)
		{
			Size result = layout.Arrange(m_layoutContext, finalSize2);
			result.Width += num;
			result.Height += num2;
			if (num3 != 0f || num4 != 0f)
			{
				foreach (UIElement child in base.Children)
				{
					if (child is FrameworkElement frameworkElement)
					{
						Rect layoutSlot = LayoutInformation.GetLayoutSlot(frameworkElement);
						layoutSlot.X += num3;
						layoutSlot.Y += num4;
						frameworkElement.Arrange(layoutSlot);
					}
				}
			}
			return result;
		}
		Rect finalRect = new Rect(num3, num4, finalSize2.Width, finalSize2.Height);
		foreach (UIElement child2 in base.Children)
		{
			child2.Arrange(finalRect);
		}
		return finalSize;
	}

	private void OnLayoutChanged(Layout oldValue, Layout newValue)
	{
		if (m_layoutContext == null)
		{
			m_layoutContext = new LayoutPanelLayoutContext(this);
		}
		if (oldValue != null)
		{
			oldValue.UninitializeForContext(m_layoutContext);
			oldValue.MeasureInvalidated -= InvalidateMeasureForLayout;
			oldValue.ArrangeInvalidated -= InvalidateArrangeForLayout;
		}
		if (newValue != null)
		{
			newValue.InitializeForContext(m_layoutContext);
			newValue.MeasureInvalidated += InvalidateMeasureForLayout;
			newValue.ArrangeInvalidated += InvalidateArrangeForLayout;
		}
		InvalidateMeasure();
	}

	private void InvalidateMeasureForLayout(Layout sender, object o)
	{
		InvalidateMeasure();
	}

	private void InvalidateArrangeForLayout(Layout sender, object o)
	{
		InvalidateArrange();
	}

	private static Brush GetBorderBrushDefaultValue()
	{
		return SolidColorBrushHelper.Transparent;
	}

	private static Thickness GetBorderThicknessDefaultValue()
	{
		return Thickness.Empty;
	}

	private static Thickness GetPaddingDefaultValue()
	{
		return Thickness.Empty;
	}

	private static CornerRadius GetCornerRadiusDefaultValue()
	{
		return CornerRadius.None;
	}

	private Brush GetBorderBrushValue()
	{
		if (!_BorderBrushPropertyBackingFieldSet)
		{
			_BorderBrushPropertyBackingField = (Brush)GetValue(BorderBrushProperty);
			_BorderBrushPropertyBackingFieldSet = true;
		}
		return _BorderBrushPropertyBackingField;
	}

	private void SetBorderBrushValue(Brush value)
	{
		SetValue(BorderBrushProperty, value);
	}

	private static DependencyProperty CreateBorderBrushProperty()
	{
		return DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(LayoutPanel), new FrameworkPropertyMetadata((object)GetBorderBrushDefaultValue(), FrameworkPropertyMetadataOptions.ValueInheritsDataContext, (BackingFieldUpdateCallback)OnBorderBrushBackingFieldUpdate));
	}

	private static void OnBorderBrushBackingFieldUpdate(object instance, object newValue)
	{
		LayoutPanel layoutPanel = instance as LayoutPanel;
		layoutPanel._BorderBrushPropertyBackingField = (Brush)newValue;
		layoutPanel._BorderBrushPropertyBackingFieldSet = true;
	}

	private Thickness GetBorderThicknessValue()
	{
		if (!_BorderThicknessPropertyBackingFieldSet)
		{
			_BorderThicknessPropertyBackingField = (Thickness)GetValue(BorderThicknessProperty);
			_BorderThicknessPropertyBackingFieldSet = true;
		}
		return _BorderThicknessPropertyBackingField;
	}

	private void SetBorderThicknessValue(Thickness value)
	{
		SetValue(BorderThicknessProperty, value);
	}

	private static DependencyProperty CreateBorderThicknessProperty()
	{
		return DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(LayoutPanel), new FrameworkPropertyMetadata((object)GetBorderThicknessDefaultValue(), (BackingFieldUpdateCallback)OnBorderThicknessBackingFieldUpdate));
	}

	private static void OnBorderThicknessBackingFieldUpdate(object instance, object newValue)
	{
		LayoutPanel layoutPanel = instance as LayoutPanel;
		layoutPanel._BorderThicknessPropertyBackingField = (Thickness)newValue;
		layoutPanel._BorderThicknessPropertyBackingFieldSet = true;
	}

	private Thickness GetPaddingValue()
	{
		if (!_PaddingPropertyBackingFieldSet)
		{
			_PaddingPropertyBackingField = (Thickness)GetValue(PaddingProperty);
			_PaddingPropertyBackingFieldSet = true;
		}
		return _PaddingPropertyBackingField;
	}

	private void SetPaddingValue(Thickness value)
	{
		SetValue(PaddingProperty, value);
	}

	private static DependencyProperty CreatePaddingProperty()
	{
		return DependencyProperty.Register("Padding", typeof(Thickness), typeof(LayoutPanel), new FrameworkPropertyMetadata((object)GetPaddingDefaultValue(), (BackingFieldUpdateCallback)OnPaddingBackingFieldUpdate));
	}

	private static void OnPaddingBackingFieldUpdate(object instance, object newValue)
	{
		LayoutPanel layoutPanel = instance as LayoutPanel;
		layoutPanel._PaddingPropertyBackingField = (Thickness)newValue;
		layoutPanel._PaddingPropertyBackingFieldSet = true;
	}

	private CornerRadius GetCornerRadiusValue()
	{
		if (!_CornerRadiusPropertyBackingFieldSet)
		{
			_CornerRadiusPropertyBackingField = (CornerRadius)GetValue(CornerRadiusProperty);
			_CornerRadiusPropertyBackingFieldSet = true;
		}
		return _CornerRadiusPropertyBackingField;
	}

	private void SetCornerRadiusValue(CornerRadius value)
	{
		SetValue(CornerRadiusProperty, value);
	}

	private static DependencyProperty CreateCornerRadiusProperty()
	{
		return DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(LayoutPanel), new FrameworkPropertyMetadata((object)GetCornerRadiusDefaultValue(), (BackingFieldUpdateCallback)OnCornerRadiusBackingFieldUpdate));
	}

	private static void OnCornerRadiusBackingFieldUpdate(object instance, object newValue)
	{
		LayoutPanel layoutPanel = instance as LayoutPanel;
		layoutPanel._CornerRadiusPropertyBackingField = (CornerRadius)newValue;
		layoutPanel._CornerRadiusPropertyBackingFieldSet = true;
	}
}

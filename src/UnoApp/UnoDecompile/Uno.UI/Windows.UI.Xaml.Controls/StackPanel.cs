using System;
using System.Collections.Generic;
using System.Linq;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class StackPanel : Panel, IScrollSnapPointsInfo, IInsertionPanel
{
	private List<float> _snapPoints;

	private bool _BackgroundSizingPropertyBackingFieldSet;

	private BackgroundSizing _BackgroundSizingPropertyBackingField;

	private bool _BorderBrushPropertyBackingFieldSet;

	private Brush _BorderBrushPropertyBackingField;

	private bool _BorderThicknessPropertyBackingFieldSet;

	private Thickness _BorderThicknessPropertyBackingField;

	private bool _PaddingPropertyBackingFieldSet;

	private Thickness _PaddingPropertyBackingField;

	private bool _CornerRadiusPropertyBackingFieldSet;

	private CornerRadius _CornerRadiusPropertyBackingField;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AreScrollSnapPointsRegular
	{
		get
		{
			return (bool)GetValue(AreScrollSnapPointsRegularProperty);
		}
		set
		{
			SetValue(AreScrollSnapPointsRegularProperty, value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = BackgroundSizing.InnerBorderEdge, ChangedCallback = true)]
	public static DependencyProperty BackgroundSizingProperty { get; } = CreateBackgroundSizingProperty();


	public BackgroundSizing BackgroundSizing
	{
		get
		{
			return GetBackgroundSizingValue();
		}
		set
		{
			SetBackgroundSizingValue(value);
		}
	}

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

	[GeneratedDependencyProperty(ChangedCallbackName = "OnBorderBrushPropertyChanged", Options = FrameworkPropertyMetadataOptions.ValueInheritsDataContext)]
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

	[GeneratedDependencyProperty(ChangedCallbackName = "OnBorderThicknessPropertyChanged")]
	public static DependencyProperty BorderThicknessProperty { get; } = CreateBorderThicknessProperty();


	private Size BorderAndPaddingSize
	{
		get
		{
			Thickness borderThickness = BorderThickness;
			Thickness padding = Padding;
			double width = borderThickness.Left + borderThickness.Right + padding.Left + padding.Right;
			double height = borderThickness.Top + borderThickness.Bottom + padding.Top + padding.Bottom;
			return new Size(width, height);
		}
	}

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

	[GeneratedDependencyProperty(ChangedCallbackName = "OnPaddingPropertyChanged")]
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

	[GeneratedDependencyProperty(ChangedCallbackName = "OnCornerRadiusPropertyChanged")]
	public static DependencyProperty CornerRadiusProperty { get; } = CreateCornerRadiusProperty();


	public Orientation Orientation
	{
		get
		{
			return (Orientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(StackPanel), new FrameworkPropertyMetadata(Orientation.Vertical, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((StackPanel)s)?.OnOrientationChanged(e);
	}));


	public double Spacing
	{
		get
		{
			return (double)GetValue(SpacingProperty);
		}
		set
		{
			SetValue(SpacingProperty, value);
		}
	}

	public static DependencyProperty SpacingProperty { get; } = DependencyProperty.Register("Spacing", typeof(double), typeof(StackPanel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));


	public bool AreHorizontalSnapPointsRegular => false;

	public bool AreVerticalSnapPointsRegular => false;

	public static DependencyProperty AreScrollSnapPointsRegularProperty { get; } = DependencyProperty.Register("AreScrollSnapPointsRegular", typeof(bool), typeof(StackPanel), new FrameworkPropertyMetadata(false));


	public event EventHandler<object> HorizontalSnapPointsChanged;

	public event EventHandler<object> VerticalSnapPointsChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void GetInsertionIndexes(Point position, out int first, out int second)
	{
		throw new NotImplementedException("The member void StackPanel.GetInsertionIndexes(Point position, out int first, out int second) is not implemented in Uno.");
	}

	private void OnBackgroundSizingChanged(DependencyPropertyChangedEventArgs e)
	{
		OnBackgroundSizingChangedInnerPanel(e);
	}

	private static Brush GetBorderBrushDefaultValue()
	{
		return SolidColorBrushHelper.Transparent;
	}

	private void OnBorderBrushPropertyChanged(Brush oldValue, Brush newValue)
	{
		base.BorderBrushInternal = newValue;
		OnBorderBrushChanged(oldValue, newValue);
	}

	private static Thickness GetBorderThicknessDefaultValue()
	{
		return Thickness.Empty;
	}

	private void OnBorderThicknessPropertyChanged(Thickness oldValue, Thickness newValue)
	{
		base.BorderThicknessInternal = newValue;
		OnBorderThicknessChanged(oldValue, newValue);
	}

	private static Thickness GetPaddingDefaultValue()
	{
		return Thickness.Empty;
	}

	private void OnPaddingPropertyChanged(Thickness oldValue, Thickness newValue)
	{
		base.PaddingInternal = newValue;
		OnPaddingChanged(oldValue, newValue);
	}

	private static CornerRadius GetCornerRadiusDefaultValue()
	{
		return CornerRadius.None;
	}

	private void OnCornerRadiusPropertyChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		base.CornerRadiusInternal = newValue;
		OnCornerRadiusChanged(oldValue, newValue);
	}

	private void OnOrientationChanged(DependencyPropertyChangedEventArgs e)
	{
		InvalidateMeasure();
	}

	protected override bool? IsWidthConstrainedInner(UIElement requester)
	{
		if (requester != null && Orientation == Orientation.Horizontal)
		{
			return false;
		}
		return this.IsWidthConstrainedSimple();
	}

	protected override bool? IsHeightConstrainedInner(UIElement requester)
	{
		if (requester != null && Orientation == Orientation.Vertical)
		{
			return false;
		}
		return this.IsHeightConstrainedSimple();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size borderAndPaddingSize = BorderAndPaddingSize;
		availableSize = availableSize.Subtract(borderAndPaddingSize);
		Size left = default(Size);
		bool flag = Orientation == Orientation.Horizontal;
		Size availableSize2 = availableSize;
		if (flag)
		{
			availableSize2.Width = double.PositiveInfinity;
		}
		else
		{
			availableSize2.Height = double.PositiveInfinity;
		}
		double spacing = Spacing;
		int count = base.Children.Count;
		for (int i = 0; i < count; i++)
		{
			UIElement view = base.Children[i];
			Size size = MeasureElement(view, availableSize2);
			bool flag2 = i != count - 1;
			if (flag)
			{
				left.Width += size.Width;
				left.Height = Math.Max(left.Height, size.Height);
				if (flag2)
				{
					left.Width += spacing;
				}
			}
			else
			{
				left.Width = Math.Max(left.Width, size.Width);
				left.Height += size.Height;
				if (flag2)
				{
					left.Height += spacing;
				}
			}
		}
		return left.Add(borderAndPaddingSize);
	}

	protected override Size ArrangeOverride(Size arrangeSize)
	{
		Size borderAndPaddingSize = BorderAndPaddingSize;
		arrangeSize = arrangeSize.Subtract(borderAndPaddingSize);
		Rect rect = new Rect(BorderThickness.Left + Padding.Left, BorderThickness.Top + Padding.Top, arrangeSize.Width, arrangeSize.Height);
		bool flag = Orientation == Orientation.Horizontal;
		double num = 0.0;
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"StackPanel/{base.Name}: Arranging {base.Children.Count} children.");
		}
		double spacing = Spacing;
		int count = base.Children.Count;
		List<float> list = _snapPoints ?? (_snapPoints = new List<float>(count));
		bool flag2 = list.Count != count;
		if (list.Capacity < count)
		{
			list.Capacity = count;
		}
		while (list.Count < count)
		{
			list.Add(0f);
		}
		while (list.Count > count)
		{
			list.RemoveAt(count);
		}
		for (int i = 0; i < count; i++)
		{
			UIElement view = base.Children[i];
			Size elementDesiredSize = GetElementDesiredSize(view);
			bool flag3 = i != 0;
			if (flag)
			{
				rect.X += num;
				if (flag3)
				{
					rect.X += spacing;
				}
				num = elementDesiredSize.Width;
				rect.Width = elementDesiredSize.Width;
				rect.Height = Math.Max(arrangeSize.Height, elementDesiredSize.Height);
				float num2 = (float)rect.Right;
				flag2 |= list[i] == num2;
				list[i] = num2;
			}
			else
			{
				rect.Y += num;
				if (flag3)
				{
					rect.Y += spacing;
				}
				num = elementDesiredSize.Height;
				rect.Height = elementDesiredSize.Height;
				rect.Width = Math.Max(arrangeSize.Width, elementDesiredSize.Width);
				float num3 = (float)rect.Bottom;
				flag2 |= list[i] == num3;
				list[i] = num3;
			}
			Rect finalRect = rect;
			ArrangeElement(view, finalRect);
		}
		Size result = arrangeSize.Add(borderAndPaddingSize);
		if (flag2)
		{
			if (flag)
			{
				this.HorizontalSnapPointsChanged?.Invoke(this, this);
			}
			else
			{
				this.VerticalSnapPointsChanged?.Invoke(this, this);
			}
		}
		return result;
	}

	public IReadOnlyList<float> GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment)
	{
		if (orientation == Orientation && _snapPoints != null)
		{
			switch (alignment)
			{
			case SnapPointsAlignment.Far:
				return _snapPoints;
			case SnapPointsAlignment.Center:
			{
				float previous = 0f;
				return new List<float>(_snapPoints.Select((float sp) => (previous + sp) / 2f));
			}
			case SnapPointsAlignment.Near:
			{
				List<float> list = new List<float>(_snapPoints.Count);
				list.Add(0f);
				for (int i = 1; i < _snapPoints.Count; i++)
				{
					list.Add(_snapPoints[i - 1]);
				}
				return list;
			}
			}
		}
		return new float[0];
	}

	public float GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset)
	{
		throw new InvalidOperationException();
	}

	private BackgroundSizing GetBackgroundSizingValue()
	{
		if (!_BackgroundSizingPropertyBackingFieldSet)
		{
			_BackgroundSizingPropertyBackingField = (BackgroundSizing)GetValue(BackgroundSizingProperty);
			_BackgroundSizingPropertyBackingFieldSet = true;
		}
		return _BackgroundSizingPropertyBackingField;
	}

	private void SetBackgroundSizingValue(BackgroundSizing value)
	{
		SetValue(BackgroundSizingProperty, value);
	}

	private static DependencyProperty CreateBackgroundSizingProperty()
	{
		return DependencyProperty.Register("BackgroundSizing", typeof(BackgroundSizing), typeof(StackPanel), new FrameworkPropertyMetadata((object)BackgroundSizing.InnerBorderEdge, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((StackPanel)instance).OnBackgroundSizingChanged(args);
		}, (BackingFieldUpdateCallback)OnBackgroundSizingBackingFieldUpdate));
	}

	private static void OnBackgroundSizingBackingFieldUpdate(object instance, object newValue)
	{
		StackPanel stackPanel = instance as StackPanel;
		stackPanel._BackgroundSizingPropertyBackingField = (BackgroundSizing)newValue;
		stackPanel._BackgroundSizingPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(StackPanel), new FrameworkPropertyMetadata((object)GetBorderBrushDefaultValue(), FrameworkPropertyMetadataOptions.ValueInheritsDataContext, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((StackPanel)instance).OnBorderBrushPropertyChanged((Brush)args.OldValue, (Brush)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderBrushBackingFieldUpdate));
	}

	private static void OnBorderBrushBackingFieldUpdate(object instance, object newValue)
	{
		StackPanel stackPanel = instance as StackPanel;
		stackPanel._BorderBrushPropertyBackingField = (Brush)newValue;
		stackPanel._BorderBrushPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(StackPanel), new FrameworkPropertyMetadata((object)GetBorderThicknessDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((StackPanel)instance).OnBorderThicknessPropertyChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderThicknessBackingFieldUpdate));
	}

	private static void OnBorderThicknessBackingFieldUpdate(object instance, object newValue)
	{
		StackPanel stackPanel = instance as StackPanel;
		stackPanel._BorderThicknessPropertyBackingField = (Thickness)newValue;
		stackPanel._BorderThicknessPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("Padding", typeof(Thickness), typeof(StackPanel), new FrameworkPropertyMetadata((object)GetPaddingDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((StackPanel)instance).OnPaddingPropertyChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnPaddingBackingFieldUpdate));
	}

	private static void OnPaddingBackingFieldUpdate(object instance, object newValue)
	{
		StackPanel stackPanel = instance as StackPanel;
		stackPanel._PaddingPropertyBackingField = (Thickness)newValue;
		stackPanel._PaddingPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(StackPanel), new FrameworkPropertyMetadata((object)GetCornerRadiusDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((StackPanel)instance).OnCornerRadiusPropertyChanged((CornerRadius)args.OldValue, (CornerRadius)args.NewValue);
		}, (BackingFieldUpdateCallback)OnCornerRadiusBackingFieldUpdate));
	}

	private static void OnCornerRadiusBackingFieldUpdate(object instance, object newValue)
	{
		StackPanel stackPanel = instance as StackPanel;
		stackPanel._CornerRadiusPropertyBackingField = (CornerRadius)newValue;
		stackPanel._CornerRadiusPropertyBackingFieldSet = true;
	}
}

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Uno.Disposables;
using Uno.Extensions;
using Uno.UI.Helpers.WinUI;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class ColorSpectrum : Control
{
	private bool m_updatingColor;

	private bool m_updatingHsvColor;

	private bool m_isPointerOver;

	private bool m_isPointerPressed;

	private bool m_shouldShowLargeSelection;

	private List<Hsv> m_hsvValues = new List<Hsv>();

	private Grid m_layoutRoot;

	private Grid m_sizingGrid;

	private Rectangle m_spectrumRectangle;

	private Ellipse m_spectrumEllipse;

	private Rectangle m_spectrumOverlayRectangle;

	private Ellipse m_spectrumOverlayEllipse;

	private FrameworkElement m_inputTarget;

	private Panel m_selectionEllipsePanel;

	private ToolTip m_colorNameToolTip;

	private IAsyncAction m_createImageBitmapAction;

	private WriteableBitmap m_hueRedBitmap;

	private WriteableBitmap m_hueYellowBitmap;

	private WriteableBitmap m_hueGreenBitmap;

	private WriteableBitmap m_hueCyanBitmap;

	private WriteableBitmap m_hueBlueBitmap;

	private WriteableBitmap m_huePurpleBitmap;

	private WriteableBitmap m_saturationMinimumBitmap;

	private WriteableBitmap m_saturationMaximumBitmap;

	private WriteableBitmap m_valueBitmap;

	private ColorSpectrumShape m_shapeFromLastBitmapCreation;

	private ColorSpectrumComponents m_componentsFromLastBitmapCreation = ColorSpectrumComponents.HueSaturation;

	private double m_imageWidthFromLastBitmapCreation;

	private double m_imageHeightFromLastBitmapCreation;

	private int m_minHueFromLastBitmapCreation;

	private int m_maxHueFromLastBitmapCreation;

	private int m_minSaturationFromLastBitmapCreation;

	private int m_maxSaturationFromLastBitmapCreation;

	private int m_minValueFromLastBitmapCreation;

	private int m_maxValueFromLastBitmapCreation;

	private Color m_oldColor = Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private Vector4 m_oldHsvColor = new Vector4(0f, 0f, 1f, 1f);

	private bool _isTemplateApplied;

	private SerialDisposable _eventSubscriptions = new SerialDisposable();

	public Color Color
	{
		get
		{
			return (Color)GetValue(ColorProperty);
		}
		set
		{
			SetValue(ColorProperty, value);
		}
	}

	public static DependencyProperty ColorProperty { get; } = DependencyProperty.Register("Color", typeof(Color), typeof(ColorSpectrum), new FrameworkPropertyMetadata(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public ColorSpectrumComponents Components
	{
		get
		{
			return (ColorSpectrumComponents)GetValue(ComponentsProperty);
		}
		set
		{
			SetValue(ComponentsProperty, value);
		}
	}

	public static DependencyProperty ComponentsProperty { get; } = DependencyProperty.Register("Components", typeof(ColorSpectrumComponents), typeof(ColorSpectrum), new FrameworkPropertyMetadata(ColorSpectrumComponents.HueSaturation, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public Vector4 HsvColor
	{
		get
		{
			return (Vector4)GetValue(HsvColorProperty);
		}
		set
		{
			SetValue(HsvColorProperty, value);
		}
	}

	public static DependencyProperty HsvColorProperty { get; } = DependencyProperty.Register("HsvColor", typeof(Vector4), typeof(ColorSpectrum), new FrameworkPropertyMetadata(new Vector4(0f, 0f, 1f, 1f), delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public int MaxHue
	{
		get
		{
			return (int)GetValue(MaxHueProperty);
		}
		set
		{
			SetValue(MaxHueProperty, value);
		}
	}

	public static DependencyProperty MaxHueProperty { get; } = DependencyProperty.Register("MaxHue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(359, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public int MaxSaturation
	{
		get
		{
			return (int)GetValue(MaxSaturationProperty);
		}
		set
		{
			SetValue(MaxSaturationProperty, value);
		}
	}

	public static DependencyProperty MaxSaturationProperty { get; } = DependencyProperty.Register("MaxSaturation", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(100, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public int MaxValue
	{
		get
		{
			return (int)GetValue(MaxValueProperty);
		}
		set
		{
			SetValue(MaxValueProperty, value);
		}
	}

	public static DependencyProperty MaxValueProperty { get; } = DependencyProperty.Register("MaxValue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(100, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public int MinHue
	{
		get
		{
			return (int)GetValue(MinHueProperty);
		}
		set
		{
			SetValue(MinHueProperty, value);
		}
	}

	public static DependencyProperty MinHueProperty { get; } = DependencyProperty.Register("MinHue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public int MinSaturation
	{
		get
		{
			return (int)GetValue(MinSaturationProperty);
		}
		set
		{
			SetValue(MinSaturationProperty, value);
		}
	}

	public static DependencyProperty MinSaturationProperty { get; } = DependencyProperty.Register("MinSaturation", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public int MinValue
	{
		get
		{
			return (int)GetValue(MinValueProperty);
		}
		set
		{
			SetValue(MinValueProperty, value);
		}
	}

	public static DependencyProperty MinValueProperty { get; } = DependencyProperty.Register("MinValue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public ColorSpectrumShape Shape
	{
		get
		{
			return (ColorSpectrumShape)GetValue(ShapeProperty);
		}
		set
		{
			SetValue(ShapeProperty, value);
		}
	}

	public static DependencyProperty ShapeProperty { get; } = DependencyProperty.Register("Shape", typeof(ColorSpectrumShape), typeof(ColorSpectrum), new FrameworkPropertyMetadata(ColorSpectrumShape.Box, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorSpectrum)?.OnPropertyChanged(e);
	}));


	public event TypedEventHandler<ColorSpectrum, ColorChangedEventArgs> ColorChanged;

	public ColorSpectrum()
	{
		SetDefaultStyleKey(this);
		m_updatingColor = false;
		m_updatingHsvColor = false;
		m_isPointerOver = false;
		m_isPointerPressed = false;
		m_shouldShowLargeSelection = false;
		m_shapeFromLastBitmapCreation = Shape;
		m_componentsFromLastBitmapCreation = Components;
		m_imageWidthFromLastBitmapCreation = 0.0;
		m_imageHeightFromLastBitmapCreation = 0.0;
		m_minHueFromLastBitmapCreation = MinHue;
		m_maxHueFromLastBitmapCreation = MaxHue;
		m_minSaturationFromLastBitmapCreation = MinSaturation;
		m_maxSaturationFromLastBitmapCreation = MaxSaturation;
		m_minValueFromLastBitmapCreation = MinValue;
		m_maxValueFromLastBitmapCreation = MaxValue;
		base.Loaded += OnLoaded;
		base.Unloaded += OnUnloaded;
		if (SharedHelpers.IsRS1OrHigher())
		{
			base.IsFocusEngagementEnabled = true;
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ColorSpectrumAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		_eventSubscriptions.Disposable = null;
		m_layoutRoot = GetTemplateChild<Grid>("LayoutRoot");
		m_sizingGrid = GetTemplateChild<Grid>("SizingGrid");
		m_spectrumRectangle = GetTemplateChild<Rectangle>("SpectrumRectangle");
		m_spectrumEllipse = GetTemplateChild<Ellipse>("SpectrumEllipse");
		m_spectrumOverlayRectangle = GetTemplateChild<Rectangle>("SpectrumOverlayRectangle");
		m_spectrumOverlayEllipse = GetTemplateChild<Ellipse>("SpectrumOverlayEllipse");
		m_inputTarget = GetTemplateChild<FrameworkElement>("InputTarget");
		m_selectionEllipsePanel = GetTemplateChild<Panel>("SelectionEllipsePanel");
		m_colorNameToolTip = GetTemplateChild<ToolTip>("ColorNameToolTip");
		CompositeDisposable disposable = SubscribeToEvents();
		if (DownlevelHelper.ToDisplayNameExists())
		{
			ToolTip colorNameToolTip = m_colorNameToolTip;
			if (colorNameToolTip != null)
			{
				colorNameToolTip.Content = ColorHelper.ToDisplayName(Color);
			}
		}
		m_selectionEllipsePanel?.RegisterPropertyChangedCallback(FrameworkElement.FlowDirectionProperty, OnSelectionEllipseFlowDirectionChanged);
		if (m_hsvValues.Count == 0)
		{
			CreateBitmapsAndColorMap();
		}
		UpdateEllipse();
		UpdateVisualState(useTransitions: false);
		_eventSubscriptions.Disposable = disposable;
		_isTemplateApplied = true;
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		if (args.Key != VirtualKey.Left && args.Key != VirtualKey.Right && args.Key != VirtualKey.Up && args.Key != VirtualKey.Down)
		{
			base.OnKeyDown(args);
			return;
		}
		bool flag = (Window.Current.CoreWindow.GetKeyState(VirtualKey.Control) & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
		ColorPickerHsvChannel colorPickerHsvChannel = ColorPickerHsvChannel.Hue;
		bool flag2 = false;
		if (args.Key == VirtualKey.Left || args.Key == VirtualKey.Right)
		{
			switch (Components)
			{
			case ColorSpectrumComponents.HueValue:
			case ColorSpectrumComponents.HueSaturation:
				colorPickerHsvChannel = ColorPickerHsvChannel.Hue;
				break;
			case ColorSpectrumComponents.SaturationValue:
				flag2 = true;
				goto case ColorSpectrumComponents.SaturationHue;
			case ColorSpectrumComponents.SaturationHue:
				colorPickerHsvChannel = ColorPickerHsvChannel.Saturation;
				break;
			case ColorSpectrumComponents.ValueHue:
			case ColorSpectrumComponents.ValueSaturation:
				colorPickerHsvChannel = ColorPickerHsvChannel.Value;
				break;
			}
		}
		else if (args.Key == VirtualKey.Up || args.Key == VirtualKey.Down)
		{
			switch (Components)
			{
			case ColorSpectrumComponents.ValueHue:
			case ColorSpectrumComponents.SaturationHue:
				colorPickerHsvChannel = ColorPickerHsvChannel.Hue;
				break;
			case ColorSpectrumComponents.HueSaturation:
			case ColorSpectrumComponents.ValueSaturation:
				colorPickerHsvChannel = ColorPickerHsvChannel.Saturation;
				break;
			case ColorSpectrumComponents.SaturationValue:
				flag2 = true;
				goto case ColorSpectrumComponents.HueValue;
			case ColorSpectrumComponents.HueValue:
				colorPickerHsvChannel = ColorPickerHsvChannel.Value;
				break;
			}
		}
		double minBound = 0.0;
		double maxBound = 0.0;
		switch (colorPickerHsvChannel)
		{
		case ColorPickerHsvChannel.Hue:
			minBound = MinHue;
			maxBound = MaxHue;
			break;
		case ColorPickerHsvChannel.Saturation:
			minBound = MinSaturation;
			maxBound = MaxSaturation;
			break;
		case ColorPickerHsvChannel.Value:
			minBound = MinValue;
			maxBound = MaxValue;
			break;
		}
		ColorHelpers.IncrementDirection incrementDirection = (((colorPickerHsvChannel != 0 || (args.Key != VirtualKey.Left && args.Key != VirtualKey.Up)) && (colorPickerHsvChannel == ColorPickerHsvChannel.Hue || (args.Key != VirtualKey.Right && args.Key != VirtualKey.Down))) ? ColorHelpers.IncrementDirection.Higher : ColorHelpers.IncrementDirection.Lower);
		if (base.FlowDirection == FlowDirection.RightToLeft != flag2 && (args.Key == VirtualKey.Left || args.Key == VirtualKey.Right))
		{
			incrementDirection = ((incrementDirection != ColorHelpers.IncrementDirection.Higher) ? ColorHelpers.IncrementDirection.Higher : ColorHelpers.IncrementDirection.Lower);
		}
		ColorHelpers.IncrementAmount amount = (flag ? ColorHelpers.IncrementAmount.Large : ColorHelpers.IncrementAmount.Small);
		Vector4 hsvColor = HsvColor;
		UpdateColor(ColorHelpers.IncrementColorChannel(new Hsv(Hsv.GetHue(hsvColor), Hsv.GetSaturation(hsvColor), Hsv.GetValue(hsvColor)), colorPickerHsvChannel, incrementDirection, amount, shouldWrap: true, minBound, maxBound));
		args.Handled = true;
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		ToolTip colorNameToolTip = m_colorNameToolTip;
		if (colorNameToolTip != null && DownlevelHelper.ToDisplayNameExists())
		{
			colorNameToolTip.IsOpen = true;
		}
		UpdateVisualState(useTransitions: true);
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		ToolTip colorNameToolTip = m_colorNameToolTip;
		if (colorNameToolTip != null && DownlevelHelper.ToDisplayNameExists())
		{
			colorNameToolTip.IsOpen = false;
		}
		UpdateVisualState(useTransitions: true);
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == ColorProperty)
		{
			OnColorChanged(args);
		}
		else if (property == HsvColorProperty)
		{
			OnHsvColorChanged(args);
		}
		else if (property == MinHueProperty || property == MaxHueProperty)
		{
			OnMinMaxHueChanged(args);
		}
		else if (property == MinSaturationProperty || property == MaxSaturationProperty)
		{
			OnMinMaxSaturationChanged(args);
		}
		else if (property == MinValueProperty || property == MaxValueProperty)
		{
			OnMinMaxValueChanged(args);
		}
		else if (property == ShapeProperty)
		{
			OnShapeChanged(args);
		}
		else if (property == ComponentsProperty)
		{
			OnComponentsChanged(args);
		}
	}

	private void OnColorChanged(DependencyPropertyChangedEventArgs args)
	{
		if (!m_updatingColor)
		{
			Color color = Color;
			m_updatingHsvColor = true;
			Hsv hsv = ColorConversion.RgbToHsv(new Rgb((double)(int)color.R / 255.0, (double)(int)color.G / 255.0, (double)(int)color.B / 255.0));
			HsvColor = new Vector4((float)hsv.H, (float)hsv.S, (float)hsv.V, (float)((double)(int)color.A / 255.0));
			m_updatingHsvColor = false;
			UpdateEllipse();
			UpdateBitmapSources();
		}
		m_oldColor = (Color)args.OldValue;
	}

	private void OnHsvColorChanged(DependencyPropertyChangedEventArgs args)
	{
		if (!m_updatingHsvColor)
		{
			SetColor();
		}
		m_oldHsvColor = (Vector4)args.OldValue;
	}

	private void SetColor()
	{
		Vector4 hsvColor = HsvColor;
		m_updatingColor = true;
		Rgb rgb = ColorConversion.HsvToRgb(new Hsv(Hsv.GetHue(hsvColor), Hsv.GetSaturation(hsvColor), Hsv.GetValue(hsvColor)));
		Color = ColorConversion.ColorFromRgba(rgb, Hsv.GetAlpha(hsvColor));
		m_updatingColor = false;
		UpdateEllipse();
		UpdateBitmapSources();
		RaiseColorChanged();
	}

	public void RaiseColorChanged()
	{
		Color color = Color;
		if (m_oldColor.A == color.A && m_oldColor.R == color.R && m_oldColor.G == color.G && m_oldColor.B == color.B)
		{
			return;
		}
		ColorChangedEventArgs colorChangedEventArgs = new ColorChangedEventArgs();
		colorChangedEventArgs.OldColor = m_oldColor;
		colorChangedEventArgs.NewColor = color;
		this.ColorChanged?.Invoke(this, colorChangedEventArgs);
		if (DownlevelHelper.ToDisplayNameExists())
		{
			ToolTip colorNameToolTip = m_colorNameToolTip;
			if (colorNameToolTip != null)
			{
				colorNameToolTip.Content = ColorHelper.ToDisplayName(color);
			}
		}
		AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
		if (automationPeer != null)
		{
			ColorSpectrumAutomationPeer colorSpectrumAutomationPeer = automationPeer as ColorSpectrumAutomationPeer;
			colorSpectrumAutomationPeer.RaisePropertyChangedEvent(m_oldColor, color, m_oldHsvColor, HsvColor);
		}
	}

	protected void OnMinMaxHueChanged(DependencyPropertyChangedEventArgs args)
	{
		int minHue = MinHue;
		int maxHue = MaxHue;
		if (minHue < 0 || minHue > 359)
		{
			throw new ArgumentException("MinHue must be between 0 and 359.");
		}
		if (maxHue < 0 || maxHue > 359)
		{
			throw new ArgumentException("MaxHue must be between 0 and 359.");
		}
		ColorSpectrumComponents components = Components;
		if (components != ColorSpectrumComponents.SaturationValue && components != ColorSpectrumComponents.ValueSaturation)
		{
			CreateBitmapsAndColorMap();
		}
	}

	protected void OnMinMaxSaturationChanged(DependencyPropertyChangedEventArgs args)
	{
		int minSaturation = MinSaturation;
		int maxSaturation = MaxSaturation;
		if (minSaturation < 0 || minSaturation > 100)
		{
			throw new ArgumentException("MinSaturation must be between 0 and 100.");
		}
		if (maxSaturation < 0 || maxSaturation > 100)
		{
			throw new ArgumentException("MaxSaturation must be between 0 and 100.");
		}
		ColorSpectrumComponents components = Components;
		if (components != 0 && components != ColorSpectrumComponents.ValueHue)
		{
			CreateBitmapsAndColorMap();
		}
	}

	private void OnMinMaxValueChanged(DependencyPropertyChangedEventArgs args)
	{
		int minValue = MinValue;
		int maxValue = MaxValue;
		if (minValue < 0 || minValue > 100)
		{
			throw new ArgumentException("MinValue must be between 0 and 100.");
		}
		if (maxValue < 0 || maxValue > 100)
		{
			throw new ArgumentException("MaxValue must be between 0 and 100.");
		}
		ColorSpectrumComponents components = Components;
		if (components != ColorSpectrumComponents.HueSaturation && components != ColorSpectrumComponents.SaturationHue)
		{
			CreateBitmapsAndColorMap();
		}
	}

	private void OnShapeChanged(DependencyPropertyChangedEventArgs args)
	{
		CreateBitmapsAndColorMap();
	}

	private void OnComponentsChanged(DependencyPropertyChangedEventArgs args)
	{
		CreateBitmapsAndColorMap();
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		if (_isTemplateApplied && _eventSubscriptions.Disposable == null)
		{
			_eventSubscriptions.Disposable = SubscribeToEvents();
		}
	}

	private void OnUnloaded(object sender, RoutedEventArgs args)
	{
		ColorHelpers.CancelAsyncAction(m_createImageBitmapAction);
		_eventSubscriptions.Disposable = null;
	}

	public Rect GetBoundingRectangle()
	{
		Rect rect = new Rect(0.0, 0.0, 0.0, 0.0);
		FrameworkElement inputTarget = m_inputTarget;
		if (inputTarget != null)
		{
			rect.Width = inputTarget.ActualWidth;
			rect.Height = inputTarget.ActualHeight;
		}
		Rect dipsRect = TransformToVisual(null).TransformBounds(rect);
		return SharedHelpers.ConvertDipsToPhysical(this, dipsRect);
	}

	private new void UpdateVisualState(bool useTransitions)
	{
		if (m_isPointerPressed)
		{
			VisualStateManager.GoToState(this, m_shouldShowLargeSelection ? "PressedLarge" : "Pressed", useTransitions);
		}
		else if (m_isPointerOver)
		{
			VisualStateManager.GoToState(this, "PointerOver", useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "Normal", useTransitions);
		}
		VisualStateManager.GoToState(this, (m_shapeFromLastBitmapCreation == ColorSpectrumShape.Box) ? "BoxSelected" : "RingSelected", useTransitions);
		VisualStateManager.GoToState(this, SelectionEllipseShouldBeLight() ? "SelectionEllipseLight" : "SelectionEllipseDark", useTransitions);
		if (base.IsEnabled && base.FocusState != 0)
		{
			if (base.FocusState == FocusState.Pointer)
			{
				VisualStateManager.GoToState(this, "PointerFocused", useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, "Focused", useTransitions);
			}
		}
		else
		{
			VisualStateManager.GoToState(this, "Unfocused", useTransitions);
		}
	}

	private void UpdateColor(Hsv newHsv)
	{
		m_updatingColor = true;
		m_updatingHsvColor = true;
		Rgb rgb = ColorConversion.HsvToRgb(newHsv);
		float alpha = Hsv.GetAlpha(HsvColor);
		Color = ColorConversion.ColorFromRgba(rgb, alpha);
		HsvColor = new Vector4((float)newHsv.H, (float)newHsv.S, (float)newHsv.V, alpha);
		UpdateEllipse();
		UpdateVisualState(useTransitions: true);
		m_updatingHsvColor = false;
		m_updatingColor = false;
		RaiseColorChanged();
	}

	private void UpdateColorFromPoint(PointerPoint point)
	{
		if (m_hsvValues.Count != 0)
		{
			double num = point.Position.X;
			double num2 = point.Position.Y;
			double num3 = Math.Min(m_imageWidthFromLastBitmapCreation, m_imageHeightFromLastBitmapCreation) / 2.0;
			double num4 = Math.Sqrt(Math.Pow(num - num3, 2.0) + Math.Pow(num2 - num3, 2.0));
			ColorSpectrumShape shape = Shape;
			if (num4 > num3 && shape == ColorSpectrumShape.Ring)
			{
				num = num3 / num4 * (num - num3) + num3;
				num2 = num3 / num4 * (num2 - num3) + num3;
			}
			int num5 = (int)Math.Round(num);
			int num6 = (int)Math.Round(num2);
			int num7 = (int)Math.Round(m_imageWidthFromLastBitmapCreation);
			if (num5 < 0)
			{
				num5 = 0;
			}
			else if ((double)num5 >= m_imageWidthFromLastBitmapCreation)
			{
				num5 = (int)Math.Round(m_imageWidthFromLastBitmapCreation) - 1;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			else if ((double)num6 >= m_imageHeightFromLastBitmapCreation)
			{
				num6 = (int)Math.Round(m_imageHeightFromLastBitmapCreation) - 1;
			}
			Hsv newHsv = m_hsvValues[MathEx.Clamp(num6 * num7 + num5, 0, m_hsvValues.Count - 1)];
			ColorSpectrumComponents components = Components;
			Vector4 hsvColor = HsvColor;
			switch (components)
			{
			case ColorSpectrumComponents.HueValue:
			case ColorSpectrumComponents.ValueHue:
				newHsv.S = Hsv.GetSaturation(hsvColor);
				break;
			case ColorSpectrumComponents.HueSaturation:
			case ColorSpectrumComponents.SaturationHue:
				newHsv.V = Hsv.GetValue(hsvColor);
				break;
			case ColorSpectrumComponents.SaturationValue:
			case ColorSpectrumComponents.ValueSaturation:
				newHsv.H = Hsv.GetHue(hsvColor);
				break;
			}
			UpdateColor(newHsv);
		}
	}

	private void UpdateEllipse()
	{
		Panel selectionEllipsePanel = m_selectionEllipsePanel;
		if (selectionEllipsePanel == null)
		{
			return;
		}
		if (m_imageWidthFromLastBitmapCreation == 0.0 || m_imageHeightFromLastBitmapCreation == 0.0)
		{
			selectionEllipsePanel.Visibility = Visibility.Collapsed;
			return;
		}
		selectionEllipsePanel.Visibility = Visibility.Visible;
		Vector4 hsvColor = HsvColor;
		Hsv.SetHue(hsvColor, MathEx.Clamp(Hsv.GetHue(hsvColor), m_minHueFromLastBitmapCreation, m_maxHueFromLastBitmapCreation));
		Hsv.SetSaturation(hsvColor, MathEx.Clamp(Hsv.GetSaturation(hsvColor), (float)m_minSaturationFromLastBitmapCreation / 100f, (float)m_maxSaturationFromLastBitmapCreation / 100f));
		Hsv.SetValue(hsvColor, MathEx.Clamp(Hsv.GetValue(hsvColor), (float)m_minValueFromLastBitmapCreation / 100f, (float)m_maxValueFromLastBitmapCreation / 100f));
		double num6;
		double num7;
		if (m_shapeFromLastBitmapCreation == ColorSpectrumShape.Box)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = (Hsv.GetHue(hsvColor) - (float)m_minHueFromLastBitmapCreation) / (float)(m_maxHueFromLastBitmapCreation - m_minHueFromLastBitmapCreation);
			double num4 = ((double)Hsv.GetSaturation(hsvColor) * 100.0 - (double)m_minSaturationFromLastBitmapCreation) / (double)(m_maxSaturationFromLastBitmapCreation - m_minSaturationFromLastBitmapCreation);
			double num5 = ((double)Hsv.GetValue(hsvColor) * 100.0 - (double)m_minValueFromLastBitmapCreation) / (double)(m_maxValueFromLastBitmapCreation - m_minValueFromLastBitmapCreation);
			if (m_componentsFromLastBitmapCreation == ColorSpectrumComponents.HueSaturation || m_componentsFromLastBitmapCreation == ColorSpectrumComponents.SaturationHue)
			{
				num4 = 1.0 - num4;
			}
			else
			{
				num5 = 1.0 - num5;
			}
			switch (m_componentsFromLastBitmapCreation)
			{
			case ColorSpectrumComponents.HueValue:
				num = num3;
				num2 = num5;
				break;
			case ColorSpectrumComponents.HueSaturation:
				num = num3;
				num2 = num4;
				break;
			case ColorSpectrumComponents.ValueHue:
				num = num5;
				num2 = num3;
				break;
			case ColorSpectrumComponents.ValueSaturation:
				num = num5;
				num2 = num4;
				break;
			case ColorSpectrumComponents.SaturationHue:
				num = num4;
				num2 = num3;
				break;
			case ColorSpectrumComponents.SaturationValue:
				num = num4;
				num2 = num5;
				break;
			}
			num6 = m_imageWidthFromLastBitmapCreation * num;
			num7 = m_imageHeightFromLastBitmapCreation * num2;
		}
		else
		{
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = ((m_maxHueFromLastBitmapCreation != m_minHueFromLastBitmapCreation) ? (360f * (Hsv.GetHue(hsvColor) - (float)m_minHueFromLastBitmapCreation) / (float)(m_maxHueFromLastBitmapCreation - m_minHueFromLastBitmapCreation)) : 0f);
			double num11 = ((m_maxSaturationFromLastBitmapCreation != m_minSaturationFromLastBitmapCreation) ? (360.0 * ((double)Hsv.GetSaturation(hsvColor) * 100.0 - (double)m_minSaturationFromLastBitmapCreation) / (double)(m_maxSaturationFromLastBitmapCreation - m_minSaturationFromLastBitmapCreation)) : 0.0);
			double num12 = ((m_maxValueFromLastBitmapCreation != m_minValueFromLastBitmapCreation) ? (360.0 * ((double)Hsv.GetValue(hsvColor) * 100.0 - (double)m_minValueFromLastBitmapCreation) / (double)(m_maxValueFromLastBitmapCreation - m_minValueFromLastBitmapCreation)) : 0.0);
			double num13 = ((m_maxHueFromLastBitmapCreation != m_minHueFromLastBitmapCreation) ? ((Hsv.GetHue(hsvColor) - (float)m_minHueFromLastBitmapCreation) / (float)(m_maxHueFromLastBitmapCreation - m_minHueFromLastBitmapCreation) - 1f) : 0f);
			double num14 = ((m_maxSaturationFromLastBitmapCreation != m_minSaturationFromLastBitmapCreation) ? (((double)Hsv.GetSaturation(hsvColor) * 100.0 - (double)m_minSaturationFromLastBitmapCreation) / (double)(m_maxSaturationFromLastBitmapCreation - m_minSaturationFromLastBitmapCreation) - 1.0) : 0.0);
			double num15 = ((m_maxValueFromLastBitmapCreation != m_minValueFromLastBitmapCreation) ? (((double)Hsv.GetValue(hsvColor) * 100.0 - (double)m_minValueFromLastBitmapCreation) / (double)(m_maxValueFromLastBitmapCreation - m_minValueFromLastBitmapCreation) - 1.0) : 0.0);
			if (m_componentsFromLastBitmapCreation == ColorSpectrumComponents.HueSaturation || m_componentsFromLastBitmapCreation == ColorSpectrumComponents.SaturationHue)
			{
				num11 = 360.0 - num11;
				num14 = 0.0 - num14 - 1.0;
			}
			else
			{
				num12 = 360.0 - num12;
				num15 = 0.0 - num15 - 1.0;
			}
			switch (m_componentsFromLastBitmapCreation)
			{
			case ColorSpectrumComponents.HueValue:
				num8 = num10;
				num9 = num15;
				break;
			case ColorSpectrumComponents.HueSaturation:
				num8 = num10;
				num9 = num14;
				break;
			case ColorSpectrumComponents.ValueHue:
				num8 = num12;
				num9 = num13;
				break;
			case ColorSpectrumComponents.ValueSaturation:
				num8 = num12;
				num9 = num14;
				break;
			case ColorSpectrumComponents.SaturationHue:
				num8 = num11;
				num9 = num13;
				break;
			case ColorSpectrumComponents.SaturationValue:
				num8 = num11;
				num9 = num15;
				break;
			}
			double num16 = Math.Min(m_imageWidthFromLastBitmapCreation, m_imageHeightFromLastBitmapCreation) / 2.0;
			num6 = Math.Cos(num8 * Math.PI / 180.0 + Math.PI) * num16 * num9 + num16;
			num7 = Math.Sin(num8 * Math.PI / 180.0 + Math.PI) * num16 * num9 + num16;
		}
		Canvas.SetLeft(selectionEllipsePanel, num6 - selectionEllipsePanel.Width / 2.0);
		Canvas.SetTop(selectionEllipsePanel, num7 - selectionEllipsePanel.Height / 2.0);
		if (DownlevelHelper.ToDisplayNameExists())
		{
			ToolTip colorNameToolTip = m_colorNameToolTip;
			if (colorNameToolTip != null)
			{
				colorNameToolTip.IsEnabled = false;
				colorNameToolTip.IsEnabled = true;
			}
		}
		UpdateVisualState(useTransitions: true);
	}

	private void OnLayoutRootSizeChanged(object sender, SizeChangedEventArgs args)
	{
		CreateBitmapsAndColorMap();
	}

	private void OnInputTargetPointerEntered(object sender, PointerRoutedEventArgs args)
	{
		m_isPointerOver = true;
		UpdateVisualState(useTransitions: true);
		args.Handled = true;
	}

	private void OnInputTargetPointerExited(object sender, PointerRoutedEventArgs args)
	{
		m_isPointerOver = false;
		UpdateVisualState(useTransitions: true);
		args.Handled = true;
	}

	private void OnInputTargetPointerPressed(object sender, PointerRoutedEventArgs args)
	{
		FrameworkElement inputTarget = m_inputTarget;
		Focus(FocusState.Pointer);
		m_isPointerPressed = true;
		m_shouldShowLargeSelection = args.Pointer.PointerDeviceType == PointerDeviceType.Pen || args.Pointer.PointerDeviceType == PointerDeviceType.Touch;
		inputTarget.CapturePointer(args.Pointer);
		UpdateColorFromPoint(args.GetCurrentPoint(inputTarget));
		UpdateVisualState(useTransitions: true);
		UpdateEllipse();
		args.Handled = true;
	}

	private void OnInputTargetPointerMoved(object sender, PointerRoutedEventArgs args)
	{
		if (m_isPointerPressed)
		{
			UpdateColorFromPoint(args.GetCurrentPoint(m_inputTarget));
			args.Handled = true;
		}
	}

	private void OnInputTargetPointerReleased(object sender, PointerRoutedEventArgs args)
	{
		m_isPointerPressed = false;
		m_shouldShowLargeSelection = false;
		m_inputTarget.ReleasePointerCapture(args.Pointer);
		UpdateVisualState(useTransitions: true);
		UpdateEllipse();
		args.Handled = true;
	}

	private void OnSelectionEllipseFlowDirectionChanged(DependencyObject o, DependencyProperty p)
	{
		UpdateEllipse();
	}

	private CompositeDisposable SubscribeToEvents()
	{
		CompositeDisposable compositeDisposable = new CompositeDisposable();
		Grid layoutRoot = m_layoutRoot;
		if (layoutRoot != null)
		{
			layoutRoot.SizeChanged += OnLayoutRootSizeChanged;
			compositeDisposable.Add(delegate
			{
				layoutRoot.SizeChanged -= OnLayoutRootSizeChanged;
			});
		}
		FrameworkElement inputTarget = m_inputTarget;
		if (inputTarget != null)
		{
			inputTarget.PointerEntered += OnInputTargetPointerEntered;
			inputTarget.PointerExited += OnInputTargetPointerExited;
			inputTarget.PointerPressed += OnInputTargetPointerPressed;
			inputTarget.PointerMoved += OnInputTargetPointerMoved;
			inputTarget.PointerReleased += OnInputTargetPointerReleased;
			compositeDisposable.Add(delegate
			{
				inputTarget.PointerEntered -= OnInputTargetPointerEntered;
			});
			compositeDisposable.Add(delegate
			{
				inputTarget.PointerExited -= OnInputTargetPointerExited;
			});
			compositeDisposable.Add(delegate
			{
				inputTarget.PointerPressed -= OnInputTargetPointerPressed;
			});
			compositeDisposable.Add(delegate
			{
				inputTarget.PointerMoved -= OnInputTargetPointerMoved;
			});
			compositeDisposable.Add(delegate
			{
				inputTarget.PointerReleased -= OnInputTargetPointerReleased;
			});
		}
		return compositeDisposable;
	}

	private async void CreateBitmapsAndColorMap()
	{
		Grid layoutRoot = m_layoutRoot;
		Grid sizingGrid = m_sizingGrid;
		FrameworkElement inputTarget = m_inputTarget;
		Rectangle spectrumRectangle = m_spectrumRectangle;
		Ellipse spectrumEllipse = m_spectrumEllipse;
		Rectangle spectrumOverlayRectangle = m_spectrumOverlayRectangle;
		Ellipse spectrumOverlayEllipse = m_spectrumOverlayEllipse;
		if (m_layoutRoot == null || m_sizingGrid == null || m_inputTarget == null || m_spectrumRectangle == null || m_spectrumEllipse == null || m_spectrumOverlayRectangle == null || m_spectrumOverlayEllipse == null || SharedHelpers.IsInDesignMode())
		{
			return;
		}
		double minDimension = Math.Min(layoutRoot.ActualWidth, layoutRoot.ActualHeight);
		if (minDimension == 0.0)
		{
			return;
		}
		sizingGrid.Width = minDimension;
		sizingGrid.Height = minDimension;
		RectangleGeometry clip = sizingGrid.Clip;
		if (clip != null)
		{
			clip.Rect = new Rect(0.0, 0.0, minDimension, minDimension);
		}
		inputTarget.Width = minDimension;
		inputTarget.Height = minDimension;
		spectrumRectangle.Width = minDimension;
		spectrumRectangle.Height = minDimension;
		spectrumEllipse.Width = minDimension;
		spectrumEllipse.Height = minDimension;
		spectrumOverlayRectangle.Width = minDimension;
		spectrumOverlayRectangle.Height = minDimension;
		spectrumOverlayEllipse.Width = minDimension;
		spectrumOverlayEllipse.Height = minDimension;
		Vector4 hsvColor = HsvColor;
		int minHue = MinHue;
		int maxHue = MaxHue;
		int minSaturation = MinSaturation;
		int maxSaturation = MaxSaturation;
		int minValue = MinValue;
		int maxValue = MaxValue;
		ColorSpectrumShape shape = Shape;
		ColorSpectrumComponents components = Components;
		if (minHue >= maxHue)
		{
			maxHue = minHue;
		}
		if (minSaturation >= maxSaturation)
		{
			maxSaturation = minSaturation;
		}
		if (minValue >= maxValue)
		{
			maxValue = minValue;
		}
		Hsv hsv = new Hsv(Hsv.GetHue(hsvColor), Hsv.GetSaturation(hsvColor), Hsv.GetValue(hsvColor));
		ArrayList<byte> bgraMinPixelData = new ArrayList<byte>();
		ArrayList<byte> bgraMiddle1PixelData = new ArrayList<byte>();
		ArrayList<byte> bgraMiddle2PixelData = new ArrayList<byte>();
		ArrayList<byte> bgraMiddle3PixelData = new ArrayList<byte>();
		ArrayList<byte> bgraMiddle4PixelData = new ArrayList<byte>();
		ArrayList<byte> bgraMaxPixelData = new ArrayList<byte>();
		List<Hsv> newHsvValues = new List<Hsv>();
		int num = (int)(Math.Round(minDimension) * Math.Round(minDimension));
		int capacity = num * 4;
		bgraMinPixelData.Capacity = capacity;
		if (components == ColorSpectrumComponents.ValueSaturation || components == ColorSpectrumComponents.SaturationValue)
		{
			bgraMiddle1PixelData.Capacity = capacity;
			bgraMiddle2PixelData.Capacity = capacity;
			bgraMiddle3PixelData.Capacity = capacity;
			bgraMiddle4PixelData.Capacity = capacity;
		}
		bgraMaxPixelData.Capacity = capacity;
		newHsvValues.Capacity = num;
		int minDimensionInt = (int)Math.Round(minDimension);
		await Task.Run(delegate
		{
			if (shape == ColorSpectrumShape.Box)
			{
				for (int num2 = minDimensionInt - 1; num2 >= 0; num2--)
				{
					for (int num3 = minDimensionInt - 1; num3 >= 0; num3--)
					{
						FillPixelForBox(num2, num3, hsv, minDimensionInt, components, minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue, bgraMinPixelData, bgraMiddle1PixelData, bgraMiddle2PixelData, bgraMiddle3PixelData, bgraMiddle4PixelData, bgraMaxPixelData, newHsvValues);
					}
				}
			}
			else
			{
				for (int i = 0; i < minDimensionInt; i++)
				{
					for (int j = 0; j < minDimensionInt; j++)
					{
						FillPixelForRing(j, i, (double)minDimensionInt / 2.0, hsv, components, minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue, bgraMinPixelData, bgraMiddle1PixelData, bgraMiddle2PixelData, bgraMiddle3PixelData, bgraMiddle4PixelData, bgraMaxPixelData, newHsvValues);
					}
				}
			}
		});
		ColorSpectrum strongThis = this;
		strongThis.m_createImageBitmapAction = null;
		strongThis.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			int pixelWidth = (int)Math.Round(minDimension);
			int pixelHeight = (int)Math.Round(minDimension);
			ColorSpectrumComponents components2 = strongThis.Components;
			WriteableBitmap writeableBitmap = ColorHelpers.CreateBitmapFromPixelData(pixelWidth, pixelHeight, bgraMinPixelData);
			WriteableBitmap writeableBitmap2 = ColorHelpers.CreateBitmapFromPixelData(pixelWidth, pixelHeight, bgraMaxPixelData);
			switch (components2)
			{
			case ColorSpectrumComponents.HueValue:
			case ColorSpectrumComponents.ValueHue:
				strongThis.m_saturationMinimumBitmap = writeableBitmap;
				strongThis.m_saturationMaximumBitmap = writeableBitmap2;
				break;
			case ColorSpectrumComponents.HueSaturation:
			case ColorSpectrumComponents.SaturationHue:
				strongThis.m_valueBitmap = writeableBitmap2;
				break;
			case ColorSpectrumComponents.SaturationValue:
			case ColorSpectrumComponents.ValueSaturation:
				strongThis.m_hueRedBitmap = writeableBitmap;
				strongThis.m_hueYellowBitmap = ColorHelpers.CreateBitmapFromPixelData(pixelWidth, pixelHeight, bgraMiddle1PixelData);
				strongThis.m_hueGreenBitmap = ColorHelpers.CreateBitmapFromPixelData(pixelWidth, pixelHeight, bgraMiddle2PixelData);
				strongThis.m_hueCyanBitmap = ColorHelpers.CreateBitmapFromPixelData(pixelWidth, pixelHeight, bgraMiddle3PixelData);
				strongThis.m_hueBlueBitmap = ColorHelpers.CreateBitmapFromPixelData(pixelWidth, pixelHeight, bgraMiddle4PixelData);
				strongThis.m_huePurpleBitmap = writeableBitmap2;
				break;
			}
			strongThis.m_shapeFromLastBitmapCreation = strongThis.Shape;
			strongThis.m_componentsFromLastBitmapCreation = strongThis.Components;
			strongThis.m_imageWidthFromLastBitmapCreation = minDimension;
			strongThis.m_imageHeightFromLastBitmapCreation = minDimension;
			strongThis.m_minHueFromLastBitmapCreation = strongThis.MinHue;
			strongThis.m_maxHueFromLastBitmapCreation = strongThis.MaxHue;
			strongThis.m_minSaturationFromLastBitmapCreation = strongThis.MinSaturation;
			strongThis.m_maxSaturationFromLastBitmapCreation = strongThis.MaxSaturation;
			strongThis.m_minValueFromLastBitmapCreation = strongThis.MinValue;
			strongThis.m_maxValueFromLastBitmapCreation = strongThis.MaxValue;
			strongThis.m_hsvValues = newHsvValues;
			strongThis.UpdateBitmapSources();
			strongThis.UpdateEllipse();
		});
	}

	private void FillPixelForBox(double x, double y, Hsv baseHsv, double minDimension, ColorSpectrumComponents components, double minHue, double maxHue, double minSaturation, double maxSaturation, double minValue, double maxValue, ArrayList<byte> bgraMinPixelData, ArrayList<byte> bgraMiddle1PixelData, ArrayList<byte> bgraMiddle2PixelData, ArrayList<byte> bgraMiddle3PixelData, ArrayList<byte> bgraMiddle4PixelData, ArrayList<byte> bgraMaxPixelData, List<Hsv> newHsvValues)
	{
		double num = minSaturation / 100.0;
		double num2 = maxSaturation / 100.0;
		double num3 = minValue / 100.0;
		double num4 = maxValue / 100.0;
		Hsv hsv = baseHsv;
		Hsv hsv2 = baseHsv;
		Hsv hsv3 = baseHsv;
		Hsv hsv4 = baseHsv;
		Hsv hsv5 = baseHsv;
		Hsv hsv6 = baseHsv;
		double num5 = (minDimension - 1.0 - x) / (minDimension - 1.0);
		double num6 = (minDimension - 1.0 - y) / (minDimension - 1.0);
		switch (components)
		{
		case ColorSpectrumComponents.HueValue:
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num6 * (maxHue - minHue))))));
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num5 * (num4 - num3))))));
			hsv.S = 0.0;
			hsv6.S = 1.0;
			break;
		case ColorSpectrumComponents.HueSaturation:
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num6 * (maxHue - minHue))))));
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num5 * (num2 - num))))));
			hsv.V = 0.0;
			hsv6.V = 1.0;
			break;
		case ColorSpectrumComponents.ValueHue:
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num6 * (num4 - num3))))));
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num5 * (maxHue - minHue))))));
			hsv.S = 0.0;
			hsv6.S = 1.0;
			break;
		case ColorSpectrumComponents.ValueSaturation:
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num6 * (num4 - num3))))));
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num5 * (num2 - num))))));
			hsv.H = 0.0;
			hsv2.H = 60.0;
			hsv3.H = 120.0;
			hsv4.H = 180.0;
			hsv5.H = 240.0;
			hsv6.H = 300.0;
			break;
		case ColorSpectrumComponents.SaturationHue:
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num6 * (num2 - num))))));
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num5 * (maxHue - minHue))))));
			hsv.V = 0.0;
			hsv6.V = 1.0;
			break;
		case ColorSpectrumComponents.SaturationValue:
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num6 * (num2 - num))))));
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num5 * (num4 - num3))))));
			hsv.H = 0.0;
			hsv2.H = 60.0;
			hsv3.H = 120.0;
			hsv4.H = 180.0;
			hsv5.H = 240.0;
			hsv6.H = 300.0;
			break;
		}
		if (components == ColorSpectrumComponents.HueSaturation || components == ColorSpectrumComponents.SaturationHue)
		{
			hsv.S = num2 - hsv.S + num;
			hsv2.S = num2 - hsv2.S + num;
			hsv3.S = num2 - hsv3.S + num;
			hsv4.S = num2 - hsv4.S + num;
			hsv5.S = num2 - hsv5.S + num;
			hsv6.S = num2 - hsv6.S + num;
		}
		else
		{
			hsv.V = num4 - hsv.V + num3;
			hsv2.V = num4 - hsv2.V + num3;
			hsv3.V = num4 - hsv3.V + num3;
			hsv4.V = num4 - hsv4.V + num3;
			hsv5.V = num4 - hsv5.V + num3;
			hsv6.V = num4 - hsv6.V + num3;
		}
		newHsvValues.Add(hsv);
		Rgb rgb = ColorConversion.HsvToRgb(hsv);
		bgraMinPixelData.Add((byte)Math.Round(rgb.B * 255.0));
		bgraMinPixelData.Add((byte)Math.Round(rgb.G * 255.0));
		bgraMinPixelData.Add((byte)Math.Round(rgb.R * 255.0));
		bgraMinPixelData.Add(byte.MaxValue);
		if (components == ColorSpectrumComponents.ValueSaturation || components == ColorSpectrumComponents.SaturationValue)
		{
			Rgb rgb2 = ColorConversion.HsvToRgb(hsv2);
			bgraMiddle1PixelData.Add((byte)Math.Round(rgb2.B * 255.0));
			bgraMiddle1PixelData.Add((byte)Math.Round(rgb2.G * 255.0));
			bgraMiddle1PixelData.Add((byte)Math.Round(rgb2.R * 255.0));
			bgraMiddle1PixelData.Add(byte.MaxValue);
			Rgb rgb3 = ColorConversion.HsvToRgb(hsv3);
			bgraMiddle2PixelData.Add((byte)Math.Round(rgb3.B * 255.0));
			bgraMiddle2PixelData.Add((byte)Math.Round(rgb3.G * 255.0));
			bgraMiddle2PixelData.Add((byte)Math.Round(rgb3.R * 255.0));
			bgraMiddle2PixelData.Add(byte.MaxValue);
			Rgb rgb4 = ColorConversion.HsvToRgb(hsv4);
			bgraMiddle3PixelData.Add((byte)Math.Round(rgb4.B * 255.0));
			bgraMiddle3PixelData.Add((byte)Math.Round(rgb4.G * 255.0));
			bgraMiddle3PixelData.Add((byte)Math.Round(rgb4.R * 255.0));
			bgraMiddle3PixelData.Add(byte.MaxValue);
			Rgb rgb5 = ColorConversion.HsvToRgb(hsv5);
			bgraMiddle4PixelData.Add((byte)Math.Round(rgb5.B * 255.0));
			bgraMiddle4PixelData.Add((byte)Math.Round(rgb5.G * 255.0));
			bgraMiddle4PixelData.Add((byte)Math.Round(rgb5.R * 255.0));
			bgraMiddle4PixelData.Add(byte.MaxValue);
		}
		Rgb rgb6 = ColorConversion.HsvToRgb(hsv6);
		bgraMaxPixelData.Add((byte)Math.Round(rgb6.B * 255.0));
		bgraMaxPixelData.Add((byte)Math.Round(rgb6.G * 255.0));
		bgraMaxPixelData.Add((byte)Math.Round(rgb6.R * 255.0));
		bgraMaxPixelData.Add(byte.MaxValue);
	}

	private void FillPixelForRing(double x, double y, double radius, Hsv baseHsv, ColorSpectrumComponents components, double minHue, double maxHue, double minSaturation, double maxSaturation, double minValue, double maxValue, ArrayList<byte> bgraMinPixelData, ArrayList<byte> bgraMiddle1PixelData, ArrayList<byte> bgraMiddle2PixelData, ArrayList<byte> bgraMiddle3PixelData, ArrayList<byte> bgraMiddle4PixelData, ArrayList<byte> bgraMaxPixelData, List<Hsv> newHsvValues)
	{
		double num = minSaturation / 100.0;
		double num2 = maxSaturation / 100.0;
		double num3 = minValue / 100.0;
		double num4 = maxValue / 100.0;
		double num5 = Math.Sqrt(Math.Pow(x - radius, 2.0) + Math.Pow(y - radius, 2.0));
		double num6 = x;
		double num7 = y;
		if (num5 > radius)
		{
			num6 = radius / num5 * (x - radius) + radius;
			num7 = radius / num5 * (y - radius) + radius;
			num5 = radius;
		}
		Hsv hsv = baseHsv;
		Hsv hsv2 = baseHsv;
		Hsv hsv3 = baseHsv;
		Hsv hsv4 = baseHsv;
		Hsv hsv5 = baseHsv;
		Hsv hsv6 = baseHsv;
		double num8 = 1.0 - num5 / radius;
		double num9 = Math.Atan2(radius - num7, radius - num6) * 180.0 / Math.PI;
		num9 += 180.0;
		for (num9 = Math.Floor(num9); num9 > 360.0; num9 -= 360.0)
		{
		}
		double num10 = num9 / 360.0;
		switch (components)
		{
		case ColorSpectrumComponents.HueValue:
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num10 * (maxHue - minHue))))));
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num8 * (num4 - num3))))));
			hsv.S = 0.0;
			hsv6.S = 1.0;
			break;
		case ColorSpectrumComponents.HueSaturation:
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num10 * (maxHue - minHue))))));
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num8 * (num2 - num))))));
			hsv.V = 0.0;
			hsv6.V = 1.0;
			break;
		case ColorSpectrumComponents.ValueHue:
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num10 * (num4 - num3))))));
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num8 * (maxHue - minHue))))));
			hsv.S = 0.0;
			hsv6.S = 1.0;
			break;
		case ColorSpectrumComponents.ValueSaturation:
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num10 * (num4 - num3))))));
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num8 * (num2 - num))))));
			hsv.H = 0.0;
			hsv2.H = 60.0;
			hsv3.H = 120.0;
			hsv4.H = 180.0;
			hsv5.H = 240.0;
			hsv6.H = 300.0;
			break;
		case ColorSpectrumComponents.SaturationHue:
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num10 * (num2 - num))))));
			hsv.H = (hsv2.H = (hsv3.H = (hsv4.H = (hsv5.H = (hsv6.H = minHue + num8 * (maxHue - minHue))))));
			hsv.V = 0.0;
			hsv6.V = 1.0;
			break;
		case ColorSpectrumComponents.SaturationValue:
			hsv.S = (hsv2.S = (hsv3.S = (hsv4.S = (hsv5.S = (hsv6.S = num + num10 * (num2 - num))))));
			hsv.V = (hsv2.V = (hsv3.V = (hsv4.V = (hsv5.V = (hsv6.V = num3 + num8 * (num4 - num3))))));
			hsv.H = 0.0;
			hsv2.H = 60.0;
			hsv3.H = 120.0;
			hsv4.H = 180.0;
			hsv5.H = 240.0;
			hsv6.H = 300.0;
			break;
		}
		if (components == ColorSpectrumComponents.HueSaturation || components == ColorSpectrumComponents.SaturationHue)
		{
			hsv.S = num2 - hsv.S + num;
			hsv2.S = num2 - hsv2.S + num;
			hsv3.S = num2 - hsv3.S + num;
			hsv4.S = num2 - hsv4.S + num;
			hsv5.S = num2 - hsv5.S + num;
			hsv6.S = num2 - hsv6.S + num;
		}
		else
		{
			hsv.V = num4 - hsv.V + num3;
			hsv2.V = num4 - hsv2.V + num3;
			hsv3.V = num4 - hsv3.V + num3;
			hsv4.V = num4 - hsv4.V + num3;
			hsv5.V = num4 - hsv5.V + num3;
			hsv6.V = num4 - hsv6.V + num3;
		}
		newHsvValues.Add(hsv);
		Rgb rgb = ColorConversion.HsvToRgb(hsv);
		bgraMinPixelData.Add((byte)Math.Round(rgb.B * 255.0));
		bgraMinPixelData.Add((byte)Math.Round(rgb.G * 255.0));
		bgraMinPixelData.Add((byte)Math.Round(rgb.R * 255.0));
		bgraMinPixelData.Add(byte.MaxValue);
		if (components == ColorSpectrumComponents.ValueSaturation || components == ColorSpectrumComponents.SaturationValue)
		{
			Rgb rgb2 = ColorConversion.HsvToRgb(hsv2);
			bgraMiddle1PixelData.Add((byte)Math.Round(rgb2.B * 255.0));
			bgraMiddle1PixelData.Add((byte)Math.Round(rgb2.G * 255.0));
			bgraMiddle1PixelData.Add((byte)Math.Round(rgb2.R * 255.0));
			bgraMiddle1PixelData.Add(byte.MaxValue);
			Rgb rgb3 = ColorConversion.HsvToRgb(hsv3);
			bgraMiddle2PixelData.Add((byte)Math.Round(rgb3.B * 255.0));
			bgraMiddle2PixelData.Add((byte)Math.Round(rgb3.G * 255.0));
			bgraMiddle2PixelData.Add((byte)Math.Round(rgb3.R * 255.0));
			bgraMiddle2PixelData.Add(byte.MaxValue);
			Rgb rgb4 = ColorConversion.HsvToRgb(hsv4);
			bgraMiddle3PixelData.Add((byte)Math.Round(rgb4.B * 255.0));
			bgraMiddle3PixelData.Add((byte)Math.Round(rgb4.G * 255.0));
			bgraMiddle3PixelData.Add((byte)Math.Round(rgb4.R * 255.0));
			bgraMiddle3PixelData.Add(byte.MaxValue);
			Rgb rgb5 = ColorConversion.HsvToRgb(hsv5);
			bgraMiddle4PixelData.Add((byte)Math.Round(rgb5.B * 255.0));
			bgraMiddle4PixelData.Add((byte)Math.Round(rgb5.G * 255.0));
			bgraMiddle4PixelData.Add((byte)Math.Round(rgb5.R * 255.0));
			bgraMiddle4PixelData.Add(byte.MaxValue);
		}
		Rgb rgb6 = ColorConversion.HsvToRgb(hsv6);
		bgraMaxPixelData.Add((byte)Math.Round(rgb6.B * 255.0));
		bgraMaxPixelData.Add((byte)Math.Round(rgb6.G * 255.0));
		bgraMaxPixelData.Add((byte)Math.Round(rgb6.R * 255.0));
		bgraMaxPixelData.Add(byte.MaxValue);
	}

	private void UpdateBitmapSources()
	{
		Rectangle spectrumOverlayRectangle = m_spectrumOverlayRectangle;
		Ellipse spectrumOverlayEllipse = m_spectrumOverlayEllipse;
		if (spectrumOverlayRectangle == null || spectrumOverlayEllipse == null)
		{
			return;
		}
		Rectangle spectrumRectangle = m_spectrumRectangle;
		Ellipse spectrumEllipse = m_spectrumEllipse;
		Vector4 hsvColor = HsvColor;
		switch (Components)
		{
		case ColorSpectrumComponents.HueValue:
		case ColorSpectrumComponents.ValueHue:
			if (m_saturationMinimumBitmap != null && m_saturationMaximumBitmap != null)
			{
				ImageBrush imageBrush3 = new ImageBrush();
				ImageBrush imageBrush4 = new ImageBrush();
				imageBrush3.ImageSource = m_saturationMinimumBitmap;
				imageBrush4.ImageSource = m_saturationMaximumBitmap;
				spectrumOverlayRectangle.Opacity = Hsv.GetSaturation(hsvColor);
				spectrumOverlayEllipse.Opacity = Hsv.GetSaturation(hsvColor);
				spectrumRectangle.Fill = imageBrush3;
				spectrumEllipse.Fill = imageBrush3;
				spectrumOverlayRectangle.Fill = imageBrush4;
				spectrumOverlayRectangle.Fill = imageBrush4;
			}
			break;
		case ColorSpectrumComponents.HueSaturation:
		case ColorSpectrumComponents.SaturationHue:
			if (m_valueBitmap != null)
			{
				ImageBrush imageBrush5 = new ImageBrush();
				ImageBrush imageBrush6 = new ImageBrush();
				imageBrush5.ImageSource = m_valueBitmap;
				imageBrush6.ImageSource = m_valueBitmap;
				spectrumOverlayRectangle.Opacity = 1.0;
				spectrumOverlayEllipse.Opacity = 1.0;
				spectrumRectangle.Fill = imageBrush5;
				spectrumEllipse.Fill = imageBrush5;
				spectrumOverlayRectangle.Fill = imageBrush6;
				spectrumOverlayRectangle.Fill = imageBrush6;
			}
			break;
		case ColorSpectrumComponents.SaturationValue:
		case ColorSpectrumComponents.ValueSaturation:
			if (m_hueRedBitmap != null && m_hueYellowBitmap != null && m_hueGreenBitmap != null && m_hueCyanBitmap != null && m_hueBlueBitmap != null && m_huePurpleBitmap != null)
			{
				ImageBrush imageBrush = new ImageBrush();
				ImageBrush imageBrush2 = new ImageBrush();
				double num = (double)Hsv.GetHue(hsvColor) / 60.0;
				if (num < 1.0)
				{
					imageBrush.ImageSource = m_hueRedBitmap;
					imageBrush2.ImageSource = m_hueYellowBitmap;
				}
				else if (num >= 1.0 && num < 2.0)
				{
					imageBrush.ImageSource = m_hueYellowBitmap;
					imageBrush2.ImageSource = m_hueGreenBitmap;
				}
				else if (num >= 2.0 && num < 3.0)
				{
					imageBrush.ImageSource = m_hueGreenBitmap;
					imageBrush2.ImageSource = m_hueCyanBitmap;
				}
				else if (num >= 3.0 && num < 4.0)
				{
					imageBrush.ImageSource = m_hueCyanBitmap;
					imageBrush2.ImageSource = m_hueBlueBitmap;
				}
				else if (num >= 4.0 && num < 5.0)
				{
					imageBrush.ImageSource = m_hueBlueBitmap;
					imageBrush2.ImageSource = m_huePurpleBitmap;
				}
				else
				{
					imageBrush.ImageSource = m_huePurpleBitmap;
					imageBrush2.ImageSource = m_hueRedBitmap;
				}
				spectrumOverlayRectangle.Opacity = num - (double)(int)num;
				spectrumOverlayEllipse.Opacity = num - (double)(int)num;
				spectrumRectangle.Fill = imageBrush;
				spectrumEllipse.Fill = imageBrush;
				spectrumOverlayRectangle.Fill = imageBrush2;
				spectrumOverlayRectangle.Fill = imageBrush2;
			}
			break;
		}
	}

	private bool SelectionEllipseShouldBeLight()
	{
		Color color;
		if (Components == ColorSpectrumComponents.HueSaturation || Components == ColorSpectrumComponents.SaturationHue)
		{
			Vector4 hsvColor = HsvColor;
			Rgb rgb = ColorConversion.HsvToRgb(new Hsv(Hsv.GetHue(hsvColor), Hsv.GetSaturation(hsvColor), 1.0));
			color = ColorConversion.ColorFromRgba(rgb, Hsv.GetAlpha(hsvColor));
		}
		else
		{
			color = Color;
		}
		double num = ((color.R <= 10) ? ((double)(int)color.R / 3294.0) : Math.Pow((double)(int)color.R / 269.0 + 0.0513, 2.4));
		double num2 = ((color.G <= 10) ? ((double)(int)color.G / 3294.0) : Math.Pow((double)(int)color.G / 269.0 + 0.0513, 2.4));
		double num3 = ((color.B <= 10) ? ((double)(int)color.B / 3294.0) : Math.Pow((double)(int)color.B / 269.0 + 0.0513, 2.4));
		return 0.2126 * num + 0.7152 * num2 + 0.0722 * num3 <= 0.5;
	}
}

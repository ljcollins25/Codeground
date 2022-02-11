using System;
using System.Globalization;
using System.Numerics;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace Microsoft.UI.Xaml.Controls;

public class ColorPicker : Control
{
	private enum ColorUpdateReason
	{
		InitializingColor,
		ColorPropertyChanged,
		ColorSpectrumColorChanged,
		ThirdDimensionSliderChanged,
		AlphaSliderChanged,
		RgbTextBoxChanged,
		HsvTextBoxChanged,
		AlphaTextBoxChanged,
		HexTextBoxChanged
	}

	private bool m_updatingColor;

	private bool m_updatingControls;

	private Rgb m_currentRgb = new Rgb(1.0, 1.0, 1.0);

	private Hsv m_currentHsv = new Hsv(0.0, 1.0, 1.0);

	private string m_currentHex = "#FFFFFFFF";

	private double m_currentAlpha = 1.0;

	private string m_previousString = string.Empty;

	private bool m_isFocusedTextBoxValid;

	private bool m_textEntryGridOpened;

	private Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum m_colorSpectrum;

	private Grid m_colorPreviewRectangleGrid;

	private Rectangle m_colorPreviewRectangle;

	private Rectangle m_previousColorRectangle;

	private ImageBrush m_colorPreviewRectangleCheckeredBackgroundImageBrush;

	private IAsyncAction m_createColorPreviewRectangleCheckeredBackgroundBitmapAction;

	private Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider m_thirdDimensionSlider;

	private LinearGradientBrush m_thirdDimensionSliderGradientBrush;

	private Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider m_alphaSlider;

	private LinearGradientBrush m_alphaSliderGradientBrush;

	private Rectangle m_alphaSliderBackgroundRectangle;

	private ImageBrush m_alphaSliderCheckeredBackgroundImageBrush;

	private IAsyncAction m_alphaSliderCheckeredBackgroundBitmapAction;

	private ButtonBase m_moreButton;

	private TextBlock m_moreButtonLabel;

	private ComboBox m_colorRepresentationComboBox;

	private TextBox m_redTextBox;

	private TextBox m_greenTextBox;

	private TextBox m_blueTextBox;

	private TextBox m_hueTextBox;

	private TextBox m_saturationTextBox;

	private TextBox m_valueTextBox;

	private TextBox m_alphaTextBox;

	private TextBox m_hexTextBox;

	private ComboBoxItem m_RgbComboBoxItem;

	private ComboBoxItem m_HsvComboBoxItem;

	private TextBlock m_redLabel;

	private TextBlock m_greenLabel;

	private TextBlock m_blueLabel;

	private TextBlock m_hueLabel;

	private TextBlock m_saturationLabel;

	private TextBlock m_valueLabel;

	private TextBlock m_alphaLabel;

	private SolidColorBrush m_checkerColorBrush;

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

	public static DependencyProperty ColorProperty { get; } = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker), new FrameworkPropertyMetadata(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public ColorSpectrumComponents ColorSpectrumComponents
	{
		get
		{
			return (ColorSpectrumComponents)GetValue(ColorSpectrumComponentsProperty);
		}
		set
		{
			SetValue(ColorSpectrumComponentsProperty, value);
		}
	}

	public static DependencyProperty ColorSpectrumComponentsProperty { get; } = DependencyProperty.Register("ColorSpectrumComponents", typeof(ColorSpectrumComponents), typeof(ColorPicker), new FrameworkPropertyMetadata(ColorSpectrumComponents.HueSaturation, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public ColorSpectrumShape ColorSpectrumShape
	{
		get
		{
			return (ColorSpectrumShape)GetValue(ColorSpectrumShapeProperty);
		}
		set
		{
			SetValue(ColorSpectrumShapeProperty, value);
		}
	}

	public static DependencyProperty ColorSpectrumShapeProperty { get; } = DependencyProperty.Register("ColorSpectrumShape", typeof(ColorSpectrumShape), typeof(ColorPicker), new FrameworkPropertyMetadata(ColorSpectrumShape.Box, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsAlphaEnabled
	{
		get
		{
			return (bool)GetValue(IsAlphaEnabledProperty);
		}
		set
		{
			SetValue(IsAlphaEnabledProperty, value);
		}
	}

	public static DependencyProperty IsAlphaEnabledProperty { get; } = DependencyProperty.Register("IsAlphaEnabled", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsAlphaSliderVisible
	{
		get
		{
			return (bool)GetValue(IsAlphaSliderVisibleProperty);
		}
		set
		{
			SetValue(IsAlphaSliderVisibleProperty, value);
		}
	}

	public static DependencyProperty IsAlphaSliderVisibleProperty { get; } = DependencyProperty.Register("IsAlphaSliderVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsAlphaTextInputVisible
	{
		get
		{
			return (bool)GetValue(IsAlphaTextInputVisibleProperty);
		}
		set
		{
			SetValue(IsAlphaTextInputVisibleProperty, value);
		}
	}

	public static DependencyProperty IsAlphaTextInputVisibleProperty { get; } = DependencyProperty.Register("IsAlphaTextInputVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsColorChannelTextInputVisible
	{
		get
		{
			return (bool)GetValue(IsColorChannelTextInputVisibleProperty);
		}
		set
		{
			SetValue(IsColorChannelTextInputVisibleProperty, value);
		}
	}

	public static DependencyProperty IsColorChannelTextInputVisibleProperty { get; } = DependencyProperty.Register("IsColorChannelTextInputVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsColorPreviewVisible
	{
		get
		{
			return (bool)GetValue(IsColorPreviewVisibleProperty);
		}
		set
		{
			SetValue(IsColorPreviewVisibleProperty, value);
		}
	}

	public static DependencyProperty IsColorPreviewVisibleProperty { get; } = DependencyProperty.Register("IsColorPreviewVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsColorSliderVisible
	{
		get
		{
			return (bool)GetValue(IsColorSliderVisibleProperty);
		}
		set
		{
			SetValue(IsColorSliderVisibleProperty, value);
		}
	}

	public static DependencyProperty IsColorSliderVisibleProperty { get; } = DependencyProperty.Register("IsColorSliderVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsColorSpectrumVisible
	{
		get
		{
			return (bool)GetValue(IsColorSpectrumVisibleProperty);
		}
		set
		{
			SetValue(IsColorSpectrumVisibleProperty, value);
		}
	}

	public static DependencyProperty IsColorSpectrumVisibleProperty { get; } = DependencyProperty.Register("IsColorSpectrumVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsHexInputVisible
	{
		get
		{
			return (bool)GetValue(IsHexInputVisibleProperty);
		}
		set
		{
			SetValue(IsHexInputVisibleProperty, value);
		}
	}

	public static DependencyProperty IsHexInputVisibleProperty { get; } = DependencyProperty.Register("IsHexInputVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public bool IsMoreButtonVisible
	{
		get
		{
			return (bool)GetValue(IsMoreButtonVisibleProperty);
		}
		set
		{
			SetValue(IsMoreButtonVisibleProperty, value);
		}
	}

	public static DependencyProperty IsMoreButtonVisibleProperty { get; } = DependencyProperty.Register("IsMoreButtonVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
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

	public static DependencyProperty MaxHueProperty { get; } = DependencyProperty.Register("MaxHue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(359, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
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

	public static DependencyProperty MaxSaturationProperty { get; } = DependencyProperty.Register("MaxSaturation", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(100, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
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

	public static DependencyProperty MaxValueProperty { get; } = DependencyProperty.Register("MaxValue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(100, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
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

	public static DependencyProperty MinHueProperty { get; } = DependencyProperty.Register("MinHue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
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

	public static DependencyProperty MinSaturationProperty { get; } = DependencyProperty.Register("MinSaturation", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
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

	public static DependencyProperty MinValueProperty { get; } = DependencyProperty.Register("MinValue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public Color? PreviousColor
	{
		get
		{
			return (Color?)GetValue(PreviousColorProperty);
		}
		set
		{
			SetValue(PreviousColorProperty, value);
		}
	}

	public static DependencyProperty PreviousColorProperty { get; } = DependencyProperty.Register("PreviousColor", typeof(Color?), typeof(ColorPicker), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ColorPicker)?.OnPropertyChanged(e);
	}));


	public event TypedEventHandler<ColorPicker, ColorChangedEventArgs> ColorChanged;

	public ColorPicker()
	{
		SetDefaultStyleKey(this);
		base.Loaded += OnLoaded;
		base.Unloaded += OnUnloaded;
	}

	protected override void OnApplyTemplate()
	{
		_eventSubscriptions.Disposable = null;
		m_colorSpectrum = GetTemplateChild<Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum>("ColorSpectrum");
		m_colorPreviewRectangleGrid = GetTemplateChild<Grid>("ColorPreviewRectangleGrid");
		m_colorPreviewRectangle = GetTemplateChild<Rectangle>("ColorPreviewRectangle");
		m_previousColorRectangle = GetTemplateChild<Rectangle>("PreviousColorRectangle");
		m_colorPreviewRectangleCheckeredBackgroundImageBrush = GetTemplateChild<ImageBrush>("ColorPreviewRectangleCheckeredBackgroundImageBrush");
		m_thirdDimensionSlider = GetTemplateChild<Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider>("ThirdDimensionSlider");
		m_thirdDimensionSliderGradientBrush = GetTemplateChild<LinearGradientBrush>("ThirdDimensionSliderGradientBrush");
		m_alphaSlider = GetTemplateChild<Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider>("AlphaSlider");
		m_alphaSliderGradientBrush = GetTemplateChild<LinearGradientBrush>("AlphaSliderGradientBrush");
		m_alphaSliderBackgroundRectangle = GetTemplateChild<Rectangle>("AlphaSliderBackgroundRectangle");
		m_alphaSliderCheckeredBackgroundImageBrush = GetTemplateChild<ImageBrush>("AlphaSliderCheckeredBackgroundImageBrush");
		m_moreButton = GetTemplateChild<ButtonBase>("MoreButton");
		m_colorRepresentationComboBox = GetTemplateChild<ComboBox>("ColorRepresentationComboBox");
		m_redTextBox = GetTemplateChild<TextBox>("RedTextBox");
		m_greenTextBox = GetTemplateChild<TextBox>("GreenTextBox");
		m_blueTextBox = GetTemplateChild<TextBox>("BlueTextBox");
		m_hueTextBox = GetTemplateChild<TextBox>("HueTextBox");
		m_saturationTextBox = GetTemplateChild<TextBox>("SaturationTextBox");
		m_valueTextBox = GetTemplateChild<TextBox>("ValueTextBox");
		m_alphaTextBox = GetTemplateChild<TextBox>("AlphaTextBox");
		m_hexTextBox = GetTemplateChild<TextBox>("HexTextBox");
		m_RgbComboBoxItem = GetTemplateChild<ComboBoxItem>("RGBComboBoxItem");
		m_HsvComboBoxItem = GetTemplateChild<ComboBoxItem>("HSVComboBoxItem");
		m_redLabel = GetTemplateChild<TextBlock>("RedLabel");
		m_greenLabel = GetTemplateChild<TextBlock>("GreenLabel");
		m_blueLabel = GetTemplateChild<TextBlock>("BlueLabel");
		m_hueLabel = GetTemplateChild<TextBlock>("HueLabel");
		m_saturationLabel = GetTemplateChild<TextBlock>("SaturationLabel");
		m_valueLabel = GetTemplateChild<TextBlock>("ValueLabel");
		m_alphaLabel = GetTemplateChild<TextBlock>("AlphaLabel");
		m_checkerColorBrush = GetTemplateChild<SolidColorBrush>("CheckerColorBrush");
		CompositeDisposable disposable = SubscribeToEvents();
		Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum colorSpectrum = m_colorSpectrum;
		if (colorSpectrum != null)
		{
			AutomationProperties.SetName(colorSpectrum, ResourceAccessor.GetLocalizedStringResource("AutomationNameColorSpectrum"));
		}
		Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider thirdDimensionSlider = m_thirdDimensionSlider;
		if (thirdDimensionSlider != null)
		{
			SetThirdDimensionSliderChannel();
		}
		Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider alphaSlider = m_alphaSlider;
		if (alphaSlider != null)
		{
			alphaSlider.ColorChannel = ColorPickerHsvChannel.Alpha;
			AutomationProperties.SetName(alphaSlider, ResourceAccessor.GetLocalizedStringResource("AutomationNameAlphaSlider"));
		}
		ButtonBase moreButton = m_moreButton;
		if (moreButton != null)
		{
			AutomationProperties.SetName(moreButton, ResourceAccessor.GetLocalizedStringResource("AutomationNameMoreButtonCollapsed"));
			AutomationProperties.SetHelpText(moreButton, ResourceAccessor.GetLocalizedStringResource("HelpTextMoreButton"));
			TextBlock templateChild = GetTemplateChild<TextBlock>("MoreButtonLabel");
			if (templateChild != null)
			{
				m_moreButtonLabel = templateChild;
				templateChild.Text = ResourceAccessor.GetLocalizedStringResource("TextMoreButtonLabelCollapsed");
			}
		}
		ComboBox colorRepresentationComboBox = m_colorRepresentationComboBox;
		if (colorRepresentationComboBox != null)
		{
			AutomationProperties.SetName(colorRepresentationComboBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameColorModelComboBox"));
		}
		TextBox redTextBox = m_redTextBox;
		if (redTextBox != null)
		{
			AutomationProperties.SetName(redTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameRedTextBox"));
		}
		TextBox greenTextBox = m_greenTextBox;
		if (greenTextBox != null)
		{
			AutomationProperties.SetName(greenTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameGreenTextBox"));
		}
		TextBox blueTextBox = m_blueTextBox;
		if (blueTextBox != null)
		{
			AutomationProperties.SetName(blueTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameBlueTextBox"));
		}
		TextBox hueTextBox = m_hueTextBox;
		if (hueTextBox != null)
		{
			AutomationProperties.SetName(hueTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameHueTextBox"));
		}
		TextBox saturationTextBox = m_saturationTextBox;
		if (saturationTextBox != null)
		{
			AutomationProperties.SetName(saturationTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameSaturationTextBox"));
		}
		TextBox valueTextBox = m_valueTextBox;
		if (valueTextBox != null)
		{
			AutomationProperties.SetName(valueTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameValueTextBox"));
		}
		TextBox alphaTextBox = m_alphaTextBox;
		if (alphaTextBox != null)
		{
			AutomationProperties.SetName(alphaTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameAlphaTextBox"));
		}
		TextBox hexTextBox = m_hexTextBox;
		if (hexTextBox != null)
		{
			AutomationProperties.SetName(hexTextBox, ResourceAccessor.GetLocalizedStringResource("AutomationNameHexTextBox"));
		}
		ComboBoxItem rgbComboBoxItem = m_RgbComboBoxItem;
		if (rgbComboBoxItem != null)
		{
			rgbComboBoxItem.Content = ResourceAccessor.GetLocalizedStringResource("ContentRGBComboBoxItem");
		}
		ComboBoxItem hsvComboBoxItem = m_HsvComboBoxItem;
		if (hsvComboBoxItem != null)
		{
			hsvComboBoxItem.Content = ResourceAccessor.GetLocalizedStringResource("ContentHSVComboBoxItem");
		}
		TextBlock redLabel = m_redLabel;
		if (redLabel != null)
		{
			redLabel.Text = ResourceAccessor.GetLocalizedStringResource("TextRedLabel");
		}
		TextBlock greenLabel = m_greenLabel;
		if (greenLabel != null)
		{
			greenLabel.Text = ResourceAccessor.GetLocalizedStringResource("TextGreenLabel");
		}
		TextBlock blueLabel = m_blueLabel;
		if (blueLabel != null)
		{
			blueLabel.Text = ResourceAccessor.GetLocalizedStringResource("TextBlueLabel");
		}
		TextBlock hueLabel = m_hueLabel;
		if (hueLabel != null)
		{
			hueLabel.Text = ResourceAccessor.GetLocalizedStringResource("TextHueLabel");
		}
		TextBlock saturationLabel = m_saturationLabel;
		if (saturationLabel != null)
		{
			saturationLabel.Text = ResourceAccessor.GetLocalizedStringResource("TextSaturationLabel");
		}
		TextBlock valueLabel = m_valueLabel;
		if (valueLabel != null)
		{
			valueLabel.Text = ResourceAccessor.GetLocalizedStringResource("TextValueLabel");
		}
		TextBlock alphaLabel = m_alphaLabel;
		if (alphaLabel != null)
		{
			alphaLabel.Text = ResourceAccessor.GetLocalizedStringResource("TextAlphaLabel");
		}
		m_checkerColorBrush?.RegisterPropertyChangedCallback(SolidColorBrush.ColorProperty, OnCheckerColorChanged);
		CreateColorPreviewCheckeredBackground();
		CreateAlphaSliderCheckeredBackground();
		UpdateVisualState(useTransitions: false);
		InitializeColor();
		UpdatePreviousColorRectangle();
		_eventSubscriptions.Disposable = disposable;
		_isTemplateApplied = true;
	}

	protected void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == ColorProperty)
		{
			OnColorChanged(args);
		}
		else if (property == PreviousColorProperty)
		{
			OnPreviousColorChanged(args);
		}
		else if (property == IsAlphaEnabledProperty)
		{
			OnIsAlphaEnabledChanged(args);
		}
		else if (property == IsColorSpectrumVisibleProperty || property == IsColorPreviewVisibleProperty || property == IsColorSliderVisibleProperty || property == IsAlphaSliderVisibleProperty || property == IsMoreButtonVisibleProperty || property == IsColorChannelTextInputVisibleProperty || property == IsAlphaTextInputVisibleProperty || property == IsHexInputVisibleProperty)
		{
			OnPartVisibilityChanged(args);
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
		else if (property == ColorSpectrumComponentsProperty)
		{
			OnColorSpectrumComponentsChanged(args);
		}
	}

	internal Hsv GetCurrentHsv()
	{
		return m_currentHsv;
	}

	private void OnColorChanged(DependencyPropertyChangedEventArgs args)
	{
		if (!m_updatingColor)
		{
			Color color = Color;
			m_currentRgb = new Rgb((double)(int)color.R / 255.0, (double)(int)color.G / 255.0, (double)(int)color.B / 255.0);
			m_currentAlpha = (double)(int)color.A / 255.0;
			m_currentHsv = ColorConversion.RgbToHsv(m_currentRgb);
			m_currentHex = GetCurrentHexValue();
			UpdateColorControls(ColorUpdateReason.ColorPropertyChanged);
		}
		Color oldColor = (Color)args.OldValue;
		Color newColor = (Color)args.NewValue;
		if (oldColor.A != newColor.A || oldColor.R != newColor.R || oldColor.G != newColor.G || oldColor.B != newColor.B)
		{
			ColorChangedEventArgs colorChangedEventArgs = new ColorChangedEventArgs();
			colorChangedEventArgs.OldColor = oldColor;
			colorChangedEventArgs.NewColor = newColor;
			this.ColorChanged?.Invoke(this, colorChangedEventArgs);
		}
	}

	private void OnPreviousColorChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdatePreviousColorRectangle();
		UpdateVisualState(useTransitions: true);
	}

	private void OnIsAlphaEnabledChanged(DependencyPropertyChangedEventArgs args)
	{
		m_currentHex = GetCurrentHexValue();
		TextBox hexTextBox = m_hexTextBox;
		if (hexTextBox != null)
		{
			m_updatingControls = true;
			hexTextBox.Text = m_currentHex;
			m_updatingControls = false;
		}
		OnPartVisibilityChanged(args);
	}

	private void OnPartVisibilityChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateVisualState(useTransitions: true);
	}

	private void OnMinMaxHueChanged(DependencyPropertyChangedEventArgs args)
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
		m_currentHsv.H = Math.Max(minHue, Math.Min(m_currentHsv.H, maxHue));
		UpdateColor(m_currentHsv, ColorUpdateReason.ColorPropertyChanged);
		UpdateThirdDimensionSlider();
	}

	private void OnMinMaxSaturationChanged(DependencyPropertyChangedEventArgs args)
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
		m_currentHsv.S = Math.Max((double)minSaturation / 100.0, Math.Min(m_currentHsv.S, (double)maxSaturation / 100.0));
		UpdateColor(m_currentHsv, ColorUpdateReason.ColorPropertyChanged);
		UpdateThirdDimensionSlider();
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
		m_currentHsv.V = Math.Max((double)minValue / 100.0, Math.Min(m_currentHsv.V, (double)maxValue / 100.0));
		UpdateColor(m_currentHsv, ColorUpdateReason.ColorPropertyChanged);
		UpdateThirdDimensionSlider();
	}

	private void OnColorSpectrumComponentsChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateThirdDimensionSlider();
		SetThirdDimensionSliderChannel();
	}

	private new void UpdateVisualState(bool useTransitions)
	{
		Color? previousColor = PreviousColor;
		bool isAlphaEnabled = IsAlphaEnabled;
		bool isColorSpectrumVisible = IsColorSpectrumVisible;
		string stateName = ((!isColorSpectrumVisible) ? (previousColor.HasValue ? "PreviousColorVisibleHorizontal" : "PreviousColorCollapsedHorizontal") : (previousColor.HasValue ? "PreviousColorVisibleVertical" : "PreviousColorCollapsedVertical"));
		VisualStateManager.GoToState(this, isColorSpectrumVisible ? "ColorSpectrumVisible" : "ColorSpectrumCollapsed", useTransitions);
		VisualStateManager.GoToState(this, stateName, useTransitions);
		VisualStateManager.GoToState(this, IsColorPreviewVisible ? "ColorPreviewVisible" : "ColorPreviewCollapsed", useTransitions);
		VisualStateManager.GoToState(this, IsColorSliderVisible ? "ThirdDimensionSliderVisible" : "ThirdDimensionSliderCollapsed", useTransitions);
		VisualStateManager.GoToState(this, (isAlphaEnabled && IsAlphaSliderVisible) ? "AlphaSliderVisible" : "AlphaSliderCollapsed", useTransitions);
		VisualStateManager.GoToState(this, IsMoreButtonVisible ? "MoreButtonVisible" : "MoreButtonCollapsed", useTransitions);
		VisualStateManager.GoToState(this, (!IsMoreButtonVisible || m_textEntryGridOpened) ? "TextEntryGridVisible" : "TextEntryGridCollapsed", useTransitions);
		ComboBox colorRepresentationComboBox = m_colorRepresentationComboBox;
		if (colorRepresentationComboBox != null)
		{
			VisualStateManager.GoToState(this, (colorRepresentationComboBox.SelectedIndex == 0) ? "RgbSelected" : "HsvSelected", useTransitions);
		}
		VisualStateManager.GoToState(this, IsColorChannelTextInputVisible ? "ColorChannelTextInputVisible" : "ColorChannelTextInputCollapsed", useTransitions);
		VisualStateManager.GoToState(this, (isAlphaEnabled && IsAlphaTextInputVisible) ? "AlphaTextInputVisible" : "AlphaTextInputCollapsed", useTransitions);
		VisualStateManager.GoToState(this, IsHexInputVisible ? "HexInputVisible" : "HexInputCollapsed", useTransitions);
		VisualStateManager.GoToState(this, isAlphaEnabled ? "AlphaEnabled" : "AlphaDisabled", useTransitions);
	}

	private void InitializeColor()
	{
		Color color = Color;
		m_currentRgb = new Rgb((double)(int)color.R / 255.0, (double)(int)color.G / 255.0, (double)(int)color.B / 255.0);
		m_currentHsv = ColorConversion.RgbToHsv(m_currentRgb);
		m_currentAlpha = (double)(int)color.A / 255.0;
		m_currentHex = GetCurrentHexValue();
		SetColorAndUpdateControls(ColorUpdateReason.InitializingColor);
	}

	private void UpdateColor(Rgb rgb, ColorUpdateReason reason)
	{
		m_currentRgb = rgb;
		m_currentHsv = ColorConversion.RgbToHsv(m_currentRgb);
		m_currentHex = GetCurrentHexValue();
		SetColorAndUpdateControls(reason);
	}

	private void UpdateColor(Hsv hsv, ColorUpdateReason reason)
	{
		m_currentHsv = hsv;
		m_currentRgb = ColorConversion.HsvToRgb(hsv);
		m_currentHex = GetCurrentHexValue();
		SetColorAndUpdateControls(reason);
	}

	private void UpdateColor(double alpha, ColorUpdateReason reason)
	{
		m_currentAlpha = alpha;
		m_currentHex = GetCurrentHexValue();
		SetColorAndUpdateControls(reason);
	}

	private void SetColorAndUpdateControls(ColorUpdateReason reason)
	{
		m_updatingColor = true;
		Color = ColorConversion.ColorFromRgba(m_currentRgb, m_currentAlpha);
		UpdateColorControls(reason);
		m_updatingColor = false;
	}

	private void UpdatePreviousColorRectangle()
	{
		Rectangle previousColorRectangle = m_previousColorRectangle;
		if (previousColorRectangle != null)
		{
			Color? previousColor = PreviousColor;
			if (previousColor.HasValue)
			{
				previousColorRectangle.Fill = new SolidColorBrush(previousColor.Value);
			}
			else
			{
				previousColorRectangle.Fill = null;
			}
		}
	}

	private void UpdateColorControls(ColorUpdateReason reason)
	{
		m_updatingControls = true;
		if (reason != ColorUpdateReason.ColorSpectrumColorChanged && m_colorSpectrum != null)
		{
			m_colorSpectrum.HsvColor = new Vector4((float)m_currentHsv.H, (float)m_currentHsv.S, (float)m_currentHsv.V, (float)m_currentAlpha);
		}
		Rectangle colorPreviewRectangle = m_colorPreviewRectangle;
		if (colorPreviewRectangle != null)
		{
			Color color = Color;
			colorPreviewRectangle.Fill = new SolidColorBrush(color);
		}
		if (reason != ColorUpdateReason.ThirdDimensionSliderChanged && m_thirdDimensionSlider != null)
		{
			UpdateThirdDimensionSlider();
		}
		if (reason != ColorUpdateReason.AlphaSliderChanged && m_alphaSlider != null)
		{
			UpdateAlphaSlider();
		}
		ColorPicker strongThis = this;
		Action updateTextBoxes = delegate
		{
			if (reason != ColorUpdateReason.RgbTextBoxChanged)
			{
				TextBox redTextBox = strongThis.m_redTextBox;
				if (redTextBox != null)
				{
					redTextBox.Text = ((byte)Math.Round(strongThis.m_currentRgb.R * 255.0)).ToString(CultureInfo.InvariantCulture);
				}
				TextBox greenTextBox = strongThis.m_greenTextBox;
				if (greenTextBox != null)
				{
					greenTextBox.Text = ((byte)Math.Round(strongThis.m_currentRgb.G * 255.0)).ToString(CultureInfo.InvariantCulture);
				}
				TextBox blueTextBox = strongThis.m_blueTextBox;
				if (blueTextBox != null)
				{
					blueTextBox.Text = ((byte)Math.Round(strongThis.m_currentRgb.B * 255.0)).ToString(CultureInfo.InvariantCulture);
				}
			}
			if (reason != ColorUpdateReason.HsvTextBoxChanged)
			{
				TextBox hueTextBox = strongThis.m_hueTextBox;
				if (hueTextBox != null)
				{
					hueTextBox.Text = ((int)Math.Round(strongThis.m_currentHsv.H)).ToString(CultureInfo.InvariantCulture);
				}
				TextBox saturationTextBox = strongThis.m_saturationTextBox;
				if (saturationTextBox != null)
				{
					saturationTextBox.Text = ((int)Math.Round(strongThis.m_currentHsv.S * 100.0)).ToString(CultureInfo.InvariantCulture);
				}
				TextBox valueTextBox = strongThis.m_valueTextBox;
				if (valueTextBox != null)
				{
					valueTextBox.Text = ((int)Math.Round(strongThis.m_currentHsv.V * 100.0)).ToString(CultureInfo.InvariantCulture);
				}
			}
			if (reason != ColorUpdateReason.AlphaTextBoxChanged)
			{
				TextBox alphaTextBox = strongThis.m_alphaTextBox;
				if (alphaTextBox != null)
				{
					alphaTextBox.Text = ((int)Math.Round(strongThis.m_currentAlpha * 100.0)).ToString(CultureInfo.InvariantCulture) + "%";
				}
			}
			if (reason != ColorUpdateReason.HexTextBoxChanged)
			{
				TextBox hexTextBox = strongThis.m_hexTextBox;
				if (hexTextBox != null)
				{
					hexTextBox.Text = strongThis.m_currentHex;
				}
			}
		};
		if (SharedHelpers.IsRS2OrHigher())
		{
			updateTextBoxes();
		}
		else if (!SharedHelpers.IsInDesignMode())
		{
			base.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				strongThis.m_updatingControls = true;
				updateTextBoxes();
				strongThis.m_updatingControls = false;
			});
		}
		m_updatingControls = false;
	}

	private void OnColorSpectrumColorChanged(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum sender, ColorChangedEventArgs args)
	{
		if (!m_updatingControls)
		{
			Vector4 hsvColor = sender.HsvColor;
			UpdateColor(new Hsv(Hsv.GetHue(hsvColor), Hsv.GetSaturation(hsvColor), Hsv.GetValue(hsvColor)), ColorUpdateReason.ColorSpectrumColorChanged);
		}
	}

	private void OnColorSpectrumSizeChanged(object sender, SizeChangedEventArgs args)
	{
		if (args.NewSize.Width != args.PreviousSize.Width)
		{
			m_colorSpectrum.Height = args.NewSize.Width;
		}
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
		ColorHelpers.CancelAsyncAction(m_createColorPreviewRectangleCheckeredBackgroundBitmapAction);
		ColorHelpers.CancelAsyncAction(m_alphaSliderCheckeredBackgroundBitmapAction);
		_eventSubscriptions.Disposable = null;
	}

	private void OnCheckerColorChanged(DependencyObject o, DependencyProperty p)
	{
		CreateColorPreviewCheckeredBackground();
		CreateAlphaSliderCheckeredBackground();
	}

	private void OnColorPreviewRectangleGridSizeChanged(object sender, SizeChangedEventArgs args)
	{
		CreateColorPreviewCheckeredBackground();
	}

	private void OnAlphaSliderBackgroundRectangleSizeChanged(object sender, SizeChangedEventArgs args)
	{
		CreateAlphaSliderCheckeredBackground();
	}

	private void OnThirdDimensionSliderValueChanged(object sender, RangeBaseValueChangedEventArgs args)
	{
		if (!m_updatingControls)
		{
			ColorSpectrumComponents colorSpectrumComponents = ColorSpectrumComponents;
			double h = m_currentHsv.H;
			double s = m_currentHsv.S;
			double v = m_currentHsv.V;
			switch (colorSpectrumComponents)
			{
			case ColorSpectrumComponents.HueValue:
			case ColorSpectrumComponents.ValueHue:
				s = m_thirdDimensionSlider.Value / 100.0;
				break;
			case ColorSpectrumComponents.HueSaturation:
			case ColorSpectrumComponents.SaturationHue:
				v = m_thirdDimensionSlider.Value / 100.0;
				break;
			case ColorSpectrumComponents.SaturationValue:
			case ColorSpectrumComponents.ValueSaturation:
				h = m_thirdDimensionSlider.Value;
				break;
			}
			UpdateColor(new Hsv(h, s, v), ColorUpdateReason.ThirdDimensionSliderChanged);
		}
	}

	private void OnAlphaSliderValueChanged(object sender, RangeBaseValueChangedEventArgs args)
	{
		if (!m_updatingControls)
		{
			UpdateColor(m_alphaSlider.Value / 100.0, ColorUpdateReason.AlphaSliderChanged);
		}
	}

	private void OnMoreButtonClicked(object sender, RoutedEventArgs args)
	{
		m_textEntryGridOpened = !m_textEntryGridOpened;
		UpdateMoreButton();
	}

	private void OnMoreButtonChecked(object sender, RoutedEventArgs args)
	{
		m_textEntryGridOpened = true;
		UpdateMoreButton();
	}

	private void OnMoreButtonUnchecked(object sender, RoutedEventArgs args)
	{
		m_textEntryGridOpened = false;
		UpdateMoreButton();
	}

	private void UpdateMoreButton()
	{
		ButtonBase moreButton = m_moreButton;
		if (moreButton != null)
		{
			AutomationProperties.SetName(moreButton, ResourceAccessor.GetLocalizedStringResource(m_textEntryGridOpened ? "AutomationNameMoreButtonExpanded" : "AutomationNameMoreButtonCollapsed"));
		}
		TextBlock moreButtonLabel = m_moreButtonLabel;
		if (moreButtonLabel != null)
		{
			moreButtonLabel.Text = ResourceAccessor.GetLocalizedStringResource(m_textEntryGridOpened ? "TextMoreButtonLabelExpanded" : "TextMoreButtonLabelCollapsed");
		}
		UpdateVisualState(useTransitions: true);
	}

	private void OnColorRepresentationComboBoxSelectionChanged(object sender, SelectionChangedEventArgs args)
	{
		UpdateVisualState(useTransitions: true);
	}

	private void OnTextBoxGotFocus(object sender, RoutedEventArgs args)
	{
		TextBox textBox = sender as TextBox;
		m_isFocusedTextBoxValid = true;
		m_previousString = textBox.Text;
	}

	private void OnTextBoxLostFocus(object sender, RoutedEventArgs args)
	{
		TextBox textBox = sender as TextBox;
		if (!m_isFocusedTextBoxValid)
		{
			textBox.Text = m_previousString;
		}
		UpdateColorControls(ColorUpdateReason.ColorPropertyChanged);
	}

	private void OnRgbTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		if (!m_updatingControls)
		{
			ulong? num = ColorConversion.TryParseInt(sender.Text);
			if (!num.HasValue || num.Value < 0 || num.Value > 255)
			{
				m_isFocusedTextBoxValid = false;
				return;
			}
			m_isFocusedTextBoxValid = true;
			UpdateColor(ApplyConstraintsToRgbColor(GetRgbColorFromTextBoxes()), ColorUpdateReason.RgbTextBoxChanged);
		}
	}

	private void OnHueTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		if (!m_updatingControls)
		{
			ulong? num = ColorConversion.TryParseInt(m_hueTextBox.Text);
			if (!num.HasValue || num.Value < (ulong)MinHue || num.Value > (ulong)MaxHue)
			{
				m_isFocusedTextBoxValid = false;
				return;
			}
			m_isFocusedTextBoxValid = true;
			UpdateColor(GetHsvColorFromTextBoxes(), ColorUpdateReason.HsvTextBoxChanged);
		}
	}

	private void OnSaturationTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		if (!m_updatingControls)
		{
			ulong? num = ColorConversion.TryParseInt(m_saturationTextBox.Text);
			if (!num.HasValue || num.Value < (ulong)MinSaturation || num.Value > (ulong)MaxSaturation)
			{
				m_isFocusedTextBoxValid = false;
				return;
			}
			m_isFocusedTextBoxValid = true;
			UpdateColor(GetHsvColorFromTextBoxes(), ColorUpdateReason.HsvTextBoxChanged);
		}
	}

	private void OnValueTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		if (!m_updatingControls)
		{
			ulong? num = ColorConversion.TryParseInt(m_valueTextBox.Text);
			if (!num.HasValue || num.Value < (ulong)MinValue || num.Value > (ulong)MaxValue)
			{
				m_isFocusedTextBoxValid = false;
				return;
			}
			m_isFocusedTextBoxValid = true;
			UpdateColor(GetHsvColorFromTextBoxes(), ColorUpdateReason.HsvTextBoxChanged);
		}
	}

	private void OnAlphaTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		if (m_updatingControls)
		{
			return;
		}
		TextBox alphaTextBox = m_alphaTextBox;
		if (alphaTextBox != null)
		{
			int selectionStart = alphaTextBox.SelectionStart + alphaTextBox.SelectionLength;
			string text = alphaTextBox.Text;
			if (string.IsNullOrEmpty(text) || text[text.Length - 1] != '%')
			{
				alphaTextBox.Text = text + "%";
				alphaTextBox.SelectionStart = selectionStart;
			}
			string s = alphaTextBox.Text.Substring(0, alphaTextBox.Text.Length - 1);
			ulong? num = ColorConversion.TryParseInt(s);
			if (!num.HasValue || num.Value < 0 || num.Value > 100)
			{
				m_isFocusedTextBoxValid = false;
				return;
			}
			m_isFocusedTextBoxValid = true;
			UpdateColor((double)num.Value / 100.0, ColorUpdateReason.AlphaTextBoxChanged);
		}
	}

	private void OnHexTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		if (!m_updatingControls)
		{
			TextBox hexTextBox = m_hexTextBox;
			string text = hexTextBox.Text;
			if (string.IsNullOrEmpty(text) || text[0] != '#')
			{
				hexTextBox.Text = "#" + text;
				hexTextBox.SelectionStart = hexTextBox.Text.Length;
			}
			Rgb rgb;
			double num;
			if (IsAlphaEnabled)
			{
				(rgb, num) = ColorConversion.HexToRgba(m_hexTextBox.Text);
			}
			else
			{
				rgb = ColorConversion.HexToRgb(m_hexTextBox.Text);
				num = 1.0;
			}
			if ((rgb.R == -1.0 && rgb.G == -1.0 && rgb.B == -1.0 && num == -1.0) || num < 0.0 || num > 1.0)
			{
				m_isFocusedTextBoxValid = false;
				return;
			}
			m_isFocusedTextBoxValid = true;
			UpdateColor(ApplyConstraintsToRgbColor(rgb), ColorUpdateReason.HexTextBoxChanged);
			UpdateColor(num, ColorUpdateReason.HexTextBoxChanged);
		}
	}

	private Rgb GetRgbColorFromTextBoxes()
	{
		int.TryParse(m_redTextBox?.Text, out var result);
		int.TryParse(m_greenTextBox?.Text, out var result2);
		int.TryParse(m_blueTextBox?.Text, out var result3);
		return new Rgb((double)result / 255.0, (double)result2 / 255.0, (double)result3 / 255.0);
	}

	private Hsv GetHsvColorFromTextBoxes()
	{
		int.TryParse(m_hueTextBox?.Text, out var result);
		int.TryParse(m_saturationTextBox?.Text, out var result2);
		int.TryParse(m_valueTextBox?.Text, out var result3);
		return new Hsv(result, (double)result2 / 100.0, (double)result3 / 100.0);
	}

	private string GetCurrentHexValue()
	{
		if (!IsAlphaEnabled)
		{
			return ColorConversion.RgbToHex(m_currentRgb);
		}
		return ColorConversion.RgbaToHex(m_currentRgb, m_currentAlpha);
	}

	private Rgb ApplyConstraintsToRgbColor(Rgb rgb)
	{
		double val = MinHue;
		double val2 = MaxHue;
		double val3 = (double)MinSaturation / 100.0;
		double val4 = (double)MaxSaturation / 100.0;
		double val5 = (double)MinValue / 100.0;
		double val6 = (double)MaxValue / 100.0;
		Hsv hsv = ColorConversion.RgbToHsv(rgb);
		hsv.H = Math.Min(Math.Max(hsv.H, val), val2);
		hsv.S = Math.Min(Math.Max(hsv.S, val3), val4);
		hsv.V = Math.Min(Math.Max(hsv.V, val5), val6);
		return ColorConversion.HsvToRgb(hsv);
	}

	private CompositeDisposable SubscribeToEvents()
	{
		CompositeDisposable compositeDisposable = new CompositeDisposable();
		Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum colorSpectrum = m_colorSpectrum;
		if (colorSpectrum != null)
		{
			colorSpectrum.ColorChanged += OnColorSpectrumColorChanged;
			colorSpectrum.SizeChanged += OnColorSpectrumSizeChanged;
			compositeDisposable.Add(delegate
			{
				colorSpectrum.ColorChanged -= OnColorSpectrumColorChanged;
			});
			compositeDisposable.Add(delegate
			{
				colorSpectrum.SizeChanged -= OnColorSpectrumSizeChanged;
			});
		}
		Grid colorPreviewRectangleGrid = m_colorPreviewRectangleGrid;
		if (colorPreviewRectangleGrid != null)
		{
			colorPreviewRectangleGrid.SizeChanged += OnColorPreviewRectangleGridSizeChanged;
			compositeDisposable.Add(delegate
			{
				colorPreviewRectangleGrid.SizeChanged -= OnColorPreviewRectangleGridSizeChanged;
			});
		}
		Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider thirdDimensionSlider = m_thirdDimensionSlider;
		if (thirdDimensionSlider != null)
		{
			thirdDimensionSlider.ValueChanged += OnThirdDimensionSliderValueChanged;
			compositeDisposable.Add(delegate
			{
				thirdDimensionSlider.ValueChanged -= OnThirdDimensionSliderValueChanged;
			});
		}
		Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider alphaSlider = m_alphaSlider;
		if (alphaSlider != null)
		{
			alphaSlider.ValueChanged += OnAlphaSliderValueChanged;
			compositeDisposable.Add(delegate
			{
				alphaSlider.ValueChanged -= OnAlphaSliderValueChanged;
			});
		}
		Rectangle alphaSliderBackgroundRectangle = m_alphaSliderBackgroundRectangle;
		if (alphaSliderBackgroundRectangle != null)
		{
			alphaSliderBackgroundRectangle.SizeChanged += OnAlphaSliderBackgroundRectangleSizeChanged;
			compositeDisposable.Add(delegate
			{
				alphaSliderBackgroundRectangle.SizeChanged -= OnAlphaSliderBackgroundRectangleSizeChanged;
			});
		}
		ButtonBase moreButton = m_moreButton;
		if (moreButton != null)
		{
			ToggleButton moreButtonAsToggleButton = moreButton as ToggleButton;
			if (moreButtonAsToggleButton != null)
			{
				moreButtonAsToggleButton.Checked += new RoutedEventHandler(OnMoreButtonChecked);
				moreButtonAsToggleButton.Unchecked += new RoutedEventHandler(OnMoreButtonUnchecked);
				compositeDisposable.Add(delegate
				{
					moreButtonAsToggleButton.Checked -= new RoutedEventHandler(OnMoreButtonChecked);
				});
				compositeDisposable.Add(delegate
				{
					moreButtonAsToggleButton.Unchecked -= new RoutedEventHandler(OnMoreButtonUnchecked);
				});
			}
			else
			{
				moreButton.Click += OnMoreButtonClicked;
				compositeDisposable.Add(delegate
				{
					moreButton.Click -= OnMoreButtonClicked;
				});
			}
		}
		ComboBox colorRepresentationComboBox = m_colorRepresentationComboBox;
		if (colorRepresentationComboBox != null)
		{
			colorRepresentationComboBox.SelectionChanged += OnColorRepresentationComboBoxSelectionChanged;
			compositeDisposable.Add(delegate
			{
				colorRepresentationComboBox.SelectionChanged -= OnColorRepresentationComboBoxSelectionChanged;
			});
		}
		TextBox redTextBox = m_redTextBox;
		if (redTextBox != null)
		{
			redTextBox.TextChanging += OnRgbTextChanging;
			redTextBox.GotFocus += OnTextBoxGotFocus;
			redTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				redTextBox.TextChanging -= OnRgbTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				redTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				redTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		TextBox greenTextBox = m_greenTextBox;
		if (greenTextBox != null)
		{
			greenTextBox.TextChanging += OnRgbTextChanging;
			greenTextBox.GotFocus += OnTextBoxGotFocus;
			greenTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				greenTextBox.TextChanging -= OnRgbTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				greenTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				greenTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		TextBox blueTextBox = m_blueTextBox;
		if (blueTextBox != null)
		{
			blueTextBox.TextChanging += OnRgbTextChanging;
			blueTextBox.GotFocus += OnTextBoxGotFocus;
			blueTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				blueTextBox.TextChanging -= OnRgbTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				blueTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				blueTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		TextBox hueTextBox = m_hueTextBox;
		if (hueTextBox != null)
		{
			hueTextBox.TextChanging += OnHueTextChanging;
			hueTextBox.GotFocus += OnTextBoxGotFocus;
			hueTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				hueTextBox.TextChanging -= OnHueTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				hueTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				hueTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		TextBox saturationTextBox = m_saturationTextBox;
		if (saturationTextBox != null)
		{
			saturationTextBox.TextChanging += OnSaturationTextChanging;
			saturationTextBox.GotFocus += OnTextBoxGotFocus;
			saturationTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				saturationTextBox.TextChanging -= OnSaturationTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				saturationTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				saturationTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		TextBox valueTextBox = m_valueTextBox;
		if (valueTextBox != null)
		{
			valueTextBox.TextChanging += OnValueTextChanging;
			valueTextBox.GotFocus += OnTextBoxGotFocus;
			valueTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				valueTextBox.TextChanging -= OnValueTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				valueTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				valueTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		TextBox alphaTextBox = m_alphaTextBox;
		if (alphaTextBox != null)
		{
			alphaTextBox.TextChanging += OnAlphaTextChanging;
			alphaTextBox.GotFocus += OnTextBoxGotFocus;
			alphaTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				alphaTextBox.TextChanging -= OnAlphaTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				alphaTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				alphaTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		TextBox hexTextBox = m_hexTextBox;
		if (hexTextBox != null)
		{
			hexTextBox.TextChanging += OnHexTextChanging;
			hexTextBox.GotFocus += OnTextBoxGotFocus;
			hexTextBox.LostFocus += OnTextBoxLostFocus;
			compositeDisposable.Add(delegate
			{
				hexTextBox.TextChanging -= OnHexTextChanging;
			});
			compositeDisposable.Add(delegate
			{
				hexTextBox.GotFocus -= OnTextBoxGotFocus;
			});
			compositeDisposable.Add(delegate
			{
				hexTextBox.LostFocus -= OnTextBoxLostFocus;
			});
		}
		return compositeDisposable;
	}

	private void UpdateThirdDimensionSlider()
	{
		if (m_thirdDimensionSlider == null || m_thirdDimensionSliderGradientBrush == null)
		{
			return;
		}
		Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider thirdDimensionSlider = m_thirdDimensionSlider;
		LinearGradientBrush thirdDimensionSliderGradientBrush = m_thirdDimensionSliderGradientBrush;
		thirdDimensionSliderGradientBrush.GradientStops.Clear();
		switch (ColorSpectrumComponents)
		{
		case ColorSpectrumComponents.HueValue:
		case ColorSpectrumComponents.ValueHue:
		{
			int minSaturation = MinSaturation;
			int num5 = MaxSaturation;
			thirdDimensionSlider.Minimum = minSaturation;
			thirdDimensionSlider.Maximum = num5;
			thirdDimensionSlider.Value = m_currentHsv.S * 100.0;
			if (minSaturation >= num5)
			{
				num5 = minSaturation;
			}
			AddGradientStop(thirdDimensionSliderGradientBrush, 0.0, new Hsv(m_currentHsv.H, (double)minSaturation / 100.0, 1.0), 1.0);
			AddGradientStop(thirdDimensionSliderGradientBrush, 1.0, new Hsv(m_currentHsv.H, (double)num5 / 100.0, 1.0), 1.0);
			break;
		}
		case ColorSpectrumComponents.HueSaturation:
		case ColorSpectrumComponents.SaturationHue:
		{
			int minValue = MinValue;
			int num6 = MaxValue;
			thirdDimensionSlider.Minimum = minValue;
			thirdDimensionSlider.Maximum = num6;
			thirdDimensionSlider.Value = m_currentHsv.V * 100.0;
			if (minValue >= num6)
			{
				num6 = minValue;
			}
			AddGradientStop(thirdDimensionSliderGradientBrush, 0.0, new Hsv(m_currentHsv.H, m_currentHsv.S, (double)minValue / 100.0), 1.0);
			AddGradientStop(thirdDimensionSliderGradientBrush, 1.0, new Hsv(m_currentHsv.H, m_currentHsv.S, (double)num6 / 100.0), 1.0);
			break;
		}
		case ColorSpectrumComponents.SaturationValue:
		case ColorSpectrumComponents.ValueSaturation:
		{
			int minHue = MinHue;
			int num = MaxHue;
			thirdDimensionSlider.Minimum = minHue;
			thirdDimensionSlider.Maximum = num;
			thirdDimensionSlider.Value = m_currentHsv.H;
			if (minHue >= num)
			{
				num = minHue;
			}
			double num2 = (double)minHue / 359.0;
			double num3 = (double)num / 359.0;
			AddGradientStop(thirdDimensionSliderGradientBrush, 0.0, new Hsv(minHue, 1.0, 1.0), 1.0);
			for (int i = 1; i <= 5; i++)
			{
				double num4 = (double)i / 6.0;
				if (num2 < num4 && num3 > num4)
				{
					AddGradientStop(thirdDimensionSliderGradientBrush, (num4 - num2) / (num3 - num2), new Hsv(60.0 * (double)i, 1.0, 1.0), 1.0);
				}
			}
			AddGradientStop(thirdDimensionSliderGradientBrush, 1.0, new Hsv(num, 1.0, 1.0), 1.0);
			break;
		}
		}
	}

	private void SetThirdDimensionSliderChannel()
	{
		Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider thirdDimensionSlider = m_thirdDimensionSlider;
		if (thirdDimensionSlider != null)
		{
			switch (ColorSpectrumComponents)
			{
			case ColorSpectrumComponents.SaturationValue:
			case ColorSpectrumComponents.ValueSaturation:
				thirdDimensionSlider.ColorChannel = ColorPickerHsvChannel.Hue;
				AutomationProperties.SetName(thirdDimensionSlider, ResourceAccessor.GetLocalizedStringResource("AutomationNameHueSlider"));
				break;
			case ColorSpectrumComponents.HueValue:
			case ColorSpectrumComponents.ValueHue:
				thirdDimensionSlider.ColorChannel = ColorPickerHsvChannel.Saturation;
				AutomationProperties.SetName(thirdDimensionSlider, ResourceAccessor.GetLocalizedStringResource("AutomationNameSaturationSlider"));
				break;
			case ColorSpectrumComponents.HueSaturation:
			case ColorSpectrumComponents.SaturationHue:
				thirdDimensionSlider.ColorChannel = ColorPickerHsvChannel.Value;
				AutomationProperties.SetName(thirdDimensionSlider, ResourceAccessor.GetLocalizedStringResource("AutomationNameValueSlider"));
				break;
			}
		}
	}

	private void UpdateAlphaSlider()
	{
		if (m_alphaSlider != null && m_alphaSliderGradientBrush != null)
		{
			Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider alphaSlider = m_alphaSlider;
			LinearGradientBrush alphaSliderGradientBrush = m_alphaSliderGradientBrush;
			alphaSliderGradientBrush.GradientStops.Clear();
			alphaSlider.Minimum = 0.0;
			alphaSlider.Maximum = 100.0;
			alphaSlider.Value = m_currentAlpha * 100.0;
			AddGradientStop(alphaSliderGradientBrush, 0.0, m_currentHsv, 0.0);
			AddGradientStop(alphaSliderGradientBrush, 1.0, m_currentHsv, 1.0);
		}
	}

	private void CreateColorPreviewCheckeredBackground()
	{
		if (SharedHelpers.IsInDesignMode())
		{
			return;
		}
		Grid colorPreviewRectangleGrid = m_colorPreviewRectangleGrid;
		if (colorPreviewRectangleGrid != null && m_colorPreviewRectangleCheckeredBackgroundImageBrush != null)
		{
			int width = (int)Math.Round(colorPreviewRectangleGrid.ActualWidth);
			int height = (int)Math.Round(colorPreviewRectangleGrid.ActualHeight);
			ArrayList<byte> bgraCheckeredPixelData = new ArrayList<byte>();
			ColorPicker strongThis = this;
			ColorHelpers.CreateCheckeredBackgroundAsync(width, height, GetCheckerColor(), bgraCheckeredPixelData, m_createColorPreviewRectangleCheckeredBackgroundBitmapAction, base.Dispatcher, delegate(WriteableBitmap checkeredBackgroundSoftwareBitmap)
			{
				strongThis.m_colorPreviewRectangleCheckeredBackgroundImageBrush.ImageSource = checkeredBackgroundSoftwareBitmap;
			});
		}
	}

	private void CreateAlphaSliderCheckeredBackground()
	{
		if (SharedHelpers.IsInDesignMode())
		{
			return;
		}
		Rectangle alphaSliderBackgroundRectangle = m_alphaSliderBackgroundRectangle;
		if (alphaSliderBackgroundRectangle != null && m_alphaSliderCheckeredBackgroundImageBrush != null)
		{
			int width = (int)Math.Round(alphaSliderBackgroundRectangle.ActualWidth);
			int height = (int)Math.Round(alphaSliderBackgroundRectangle.ActualHeight);
			ArrayList<byte> bgraCheckeredPixelData = new ArrayList<byte>();
			ColorPicker strongThis = this;
			ColorHelpers.CreateCheckeredBackgroundAsync(width, height, GetCheckerColor(), bgraCheckeredPixelData, m_alphaSliderCheckeredBackgroundBitmapAction, base.Dispatcher, delegate(WriteableBitmap checkeredBackgroundSoftwareBitmap)
			{
				strongThis.m_alphaSliderCheckeredBackgroundImageBrush.ImageSource = checkeredBackgroundSoftwareBitmap;
			});
		}
	}

	private void AddGradientStop(LinearGradientBrush brush, double offset, Hsv hsvColor, double alpha)
	{
		GradientStop gradientStop = new GradientStop();
		Rgb rgb = ColorConversion.HsvToRgb(hsvColor);
		gradientStop.Color = ColorHelper.FromArgb((byte)Math.Round(alpha * 255.0), (byte)Math.Round(rgb.R * 255.0), (byte)Math.Round(rgb.G * 255.0), (byte)Math.Round(rgb.B * 255.0));
		gradientStop.Offset = offset;
		brush.GradientStops.Add(gradientStop);
	}

	private Color GetCheckerColor()
	{
		SolidColorBrush checkerColorBrush = m_checkerColorBrush;
		if ((object)checkerColorBrush != null)
		{
			return checkerColorBrush.Color;
		}
		object obj = Application.Current.Resources["SystemListLowColor"];
		return (Color)obj;
	}
}

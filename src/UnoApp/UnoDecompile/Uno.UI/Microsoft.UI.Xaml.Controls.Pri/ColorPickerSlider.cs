using System;
using Uno.UI.Helpers.WinUI;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class ColorPickerSlider : Slider
{
	private ToolTip m_toolTip;

	public ColorPickerHsvChannel ColorChannel
	{
		get
		{
			return (ColorPickerHsvChannel)GetValue(ColorChannelProperty);
		}
		set
		{
			SetValue(ColorChannelProperty, value);
		}
	}

	public static DependencyProperty ColorChannelProperty { get; } = DependencyProperty.Register("ColorChannel", typeof(ColorPickerHsvChannel), typeof(ColorPickerSlider), new FrameworkPropertyMetadata(ColorPickerHsvChannel.Value));


	public ColorPickerSlider()
	{
		base.DefaultStyleKey = typeof(Slider);
		base.ValueChanged += OnValueChangedEvent;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ColorPickerSliderAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		m_toolTip = GetTemplateChild<ToolTip>("ToolTip");
		ToolTip toolTip = m_toolTip;
		if (toolTip != null)
		{
			toolTip.Content = GetToolTipString();
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		if ((base.Orientation == Orientation.Horizontal && args.Key != VirtualKey.Left && args.Key != VirtualKey.Right) || (base.Orientation == Orientation.Vertical && args.Key != VirtualKey.Up && args.Key != VirtualKey.Down))
		{
			base.OnKeyDown(args);
			return;
		}
		ColorPicker parentColorPicker = GetParentColorPicker();
		if (parentColorPicker != null)
		{
			bool flag = (Window.Current.CoreWindow.GetKeyState(VirtualKey.Control) & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
			double num = 0.0;
			double num2 = 0.0;
			Hsv originalHsv = parentColorPicker.GetCurrentHsv();
			double num3 = 0.0;
			switch (ColorChannel)
			{
			case ColorPickerHsvChannel.Hue:
				num = parentColorPicker.MinHue;
				num2 = parentColorPicker.MaxHue;
				originalHsv.H = base.Value;
				break;
			case ColorPickerHsvChannel.Saturation:
				num = parentColorPicker.MinSaturation;
				num2 = parentColorPicker.MaxSaturation;
				originalHsv.S = base.Value / 100.0;
				break;
			case ColorPickerHsvChannel.Value:
				num = parentColorPicker.MinValue;
				num2 = parentColorPicker.MaxValue;
				originalHsv.V = base.Value / 100.0;
				break;
			case ColorPickerHsvChannel.Alpha:
				num = 0.0;
				num2 = 100.0;
				num3 = base.Value / 100.0;
				break;
			default:
				throw new InvalidOperationException("Invalid ColorPickerHsvChannel.");
			}
			bool flag2 = base.FlowDirection == FlowDirection.RightToLeft && !base.IsDirectionReversed;
			ColorHelpers.IncrementDirection direction = (((args.Key != VirtualKey.Left || flag2) && !(args.Key == VirtualKey.Right && flag2) && args.Key != VirtualKey.Up) ? ColorHelpers.IncrementDirection.Higher : ColorHelpers.IncrementDirection.Lower);
			ColorHelpers.IncrementAmount amount = (flag ? ColorHelpers.IncrementAmount.Large : ColorHelpers.IncrementAmount.Small);
			if (ColorChannel != ColorPickerHsvChannel.Alpha)
			{
				originalHsv = ColorHelpers.IncrementColorChannel(originalHsv, ColorChannel, direction, amount, shouldWrap: false, num, num2);
			}
			else
			{
				num3 = ColorHelpers.IncrementAlphaChannel(num3, direction, amount, shouldWrap: false, num, num2);
			}
			switch (ColorChannel)
			{
			case ColorPickerHsvChannel.Hue:
				base.Value = originalHsv.H;
				break;
			case ColorPickerHsvChannel.Saturation:
				base.Value = originalHsv.S * 100.0;
				break;
			case ColorPickerHsvChannel.Value:
				base.Value = originalHsv.V * 100.0;
				break;
			case ColorPickerHsvChannel.Alpha:
				base.Value = num3 * 100.0;
				break;
			default:
				throw new InvalidOperationException("Invalid ColorPickerHsvChannel.");
			}
			args.Handled = true;
		}
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		ToolTip toolTip = m_toolTip;
		if (toolTip != null)
		{
			toolTip.Content = GetToolTipString();
			toolTip.IsEnabled = true;
			toolTip.IsOpen = true;
		}
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		ToolTip toolTip = m_toolTip;
		if (toolTip != null)
		{
			toolTip.IsOpen = false;
		}
	}

	private void OnValueChangedEvent(object sender, RangeBaseValueChangedEventArgs args)
	{
		ToolTip toolTip = m_toolTip;
		if (toolTip != null)
		{
			toolTip.Content = GetToolTipString();
			toolTip.IsEnabled = false;
			toolTip.IsEnabled = true;
		}
		DependencyObject dependencyObject = this;
		ColorPicker colorPicker = null;
		while (dependencyObject != null && (colorPicker = dependencyObject as ColorPicker) == null)
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
		}
		if (colorPicker != null)
		{
			Color color = colorPicker.Color;
			Hsv hsv = ColorConversion.RgbToHsv(ColorConversion.RgbFromColor(color));
			hsv.V = args.NewValue / 100.0;
			Color newColor = ColorConversion.ColorFromRgba(ColorConversion.HsvToRgb(hsv));
			ColorPickerSliderAutomationPeer colorPickerSliderAutomationPeer = FrameworkElementAutomationPeer.FromElement(this) as ColorPickerSliderAutomationPeer;
			colorPickerSliderAutomationPeer.RaisePropertyChangedEvent(color, newColor, (int)Math.Round(args.OldValue), (int)Math.Round(args.NewValue));
		}
	}

	private ColorPicker GetParentColorPicker()
	{
		ColorPicker colorPicker = null;
		DependencyObject dependencyObject = this;
		while (dependencyObject != null && colorPicker == null)
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
		}
		return colorPicker;
	}

	private string GetToolTipString()
	{
		uint num = (uint)Math.Round(base.Value);
		if (ColorChannel == ColorPickerHsvChannel.Alpha)
		{
			return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("ToolTipStringAlphaSlider"), num);
		}
		ColorPicker parentColorPicker = GetParentColorPicker();
		if (parentColorPicker != null && DownlevelHelper.ToDisplayNameExists())
		{
			Hsv currentHsv = parentColorPicker.GetCurrentHsv();
			string localizedStringResource;
			switch (ColorChannel)
			{
			case ColorPickerHsvChannel.Hue:
				currentHsv.H = base.Value;
				localizedStringResource = ResourceAccessor.GetLocalizedStringResource("ToolTipStringHueSliderWithColorName");
				break;
			case ColorPickerHsvChannel.Saturation:
				localizedStringResource = ResourceAccessor.GetLocalizedStringResource("ToolTipStringSaturationSliderWithColorName");
				currentHsv.S = base.Value / 100.0;
				break;
			case ColorPickerHsvChannel.Value:
				localizedStringResource = ResourceAccessor.GetLocalizedStringResource("ToolTipStringValueSliderWithColorName");
				currentHsv.V = base.Value / 100.0;
				break;
			default:
				throw new InvalidOperationException("Invalid ColorPickerHsvChannel.");
			}
			return StringUtil.FormatString(localizedStringResource, num, ColorHelper.ToDisplayName(ColorConversion.ColorFromRgba(ColorConversion.HsvToRgb(currentHsv))));
		}
		return StringUtil.FormatString(ColorChannel switch
		{
			ColorPickerHsvChannel.Hue => ResourceAccessor.GetLocalizedStringResource("ToolTipStringHueSliderWithoutColorName"), 
			ColorPickerHsvChannel.Saturation => ResourceAccessor.GetLocalizedStringResource("ToolTipStringSaturationSliderWithoutColorName"), 
			ColorPickerHsvChannel.Value => ResourceAccessor.GetLocalizedStringResource("ToolTipStringValueSliderWithoutColorName"), 
			_ => throw new InvalidOperationException("Invalid ColorPickerHsvChannel."), 
		}, num);
	}
}

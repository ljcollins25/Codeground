using System;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class ColorPickerSliderAutomationPeer : AutomationPeer, IValueProvider
{
	private readonly ColorPickerSlider _owner;

	public bool IsReadOnly => false;

	public string Value
	{
		get
		{
			ColorPickerSlider owner = _owner;
			DependencyObject dependencyObject = owner;
			ColorPicker colorPicker = null;
			while (dependencyObject != null)
			{
				colorPicker = dependencyObject as ColorPicker;
				if (colorPicker != null)
				{
					break;
				}
				dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
			}
			if (colorPicker != null)
			{
				Color color = colorPicker.Color;
				double value = owner.Value;
				return GetValueString(color, (int)Math.Round(value));
			}
			return string.Empty;
		}
	}

	internal ColorPickerSliderAutomationPeer(ColorPickerSlider owner)
	{
		_owner = owner;
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (_owner.ColorChannel != ColorPickerHsvChannel.Alpha && patternInterface == PatternInterface.Value)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	public void SetValue(string value)
	{
	}

	public void RaisePropertyChangedEvent(Color oldColor, Color newColor, int oldValue, int newValue)
	{
		if (ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Automation.ValuePatternIdentifiers", "ValueProperty"))
		{
			string valueString = GetValueString(oldColor, oldValue);
			string valueString2 = GetValueString(newColor, newValue);
			RaisePropertyChangedEvent(ValuePatternIdentifiers.ValueProperty, valueString, valueString2);
		}
	}

	private string GetValueString(Color color, int value)
	{
		if (DownlevelHelper.ToDisplayNameExists())
		{
			string localizedStringResource;
			switch (_owner.ColorChannel)
			{
			case ColorPickerHsvChannel.Hue:
				localizedStringResource = ResourceAccessor.GetLocalizedStringResource("ValueStringHueSliderWithColorName");
				break;
			case ColorPickerHsvChannel.Saturation:
				localizedStringResource = ResourceAccessor.GetLocalizedStringResource("ValueStringSaturationSliderWithColorName");
				break;
			case ColorPickerHsvChannel.Value:
				localizedStringResource = ResourceAccessor.GetLocalizedStringResource("ValueStringValueSliderWithColorName");
				break;
			default:
				return string.Empty;
			}
			return StringUtil.FormatString(localizedStringResource, value, ColorHelper.ToDisplayName(color));
		}
		string localizedStringResource2;
		switch (_owner.ColorChannel)
		{
		case ColorPickerHsvChannel.Hue:
			localizedStringResource2 = ResourceAccessor.GetLocalizedStringResource("ValueStringHueSliderWithoutColorName");
			break;
		case ColorPickerHsvChannel.Saturation:
			localizedStringResource2 = ResourceAccessor.GetLocalizedStringResource("ValueStringSaturationSliderWithoutColorName");
			break;
		case ColorPickerHsvChannel.Value:
			localizedStringResource2 = ResourceAccessor.GetLocalizedStringResource("ValueStringValueSliderWithoutColorName");
			break;
		default:
			return string.Empty;
		}
		return StringUtil.FormatString(localizedStringResource2, value);
	}
}

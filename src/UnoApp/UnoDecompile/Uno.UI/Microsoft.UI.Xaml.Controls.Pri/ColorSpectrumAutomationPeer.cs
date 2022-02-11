using System;
using System.Numerics;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class ColorSpectrumAutomationPeer : AutomationPeer, IValueProvider
{
	private readonly ColorSpectrum _owner;

	public bool IsReadOnly => false;

	public string Value
	{
		get
		{
			ColorSpectrum owner = _owner;
			Color color = owner.Color;
			Vector4 hsvColor = owner.HsvColor;
			return GetValueString(color, hsvColor);
		}
	}

	internal ColorSpectrumAutomationPeer(ColorSpectrum owner)
	{
		_owner = owner;
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.Value)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Slider;
	}

	protected override string GetLocalizedControlTypeCore()
	{
		return ResourceAccessor.GetLocalizedStringResource("LocalizedControlTypeColorSpectrum");
	}

	protected override string GetNameCore()
	{
		string text = base.GetNameCore();
		if (string.IsNullOrEmpty(text))
		{
			text = ResourceAccessor.GetLocalizedStringResource("AutomationNameColorSpectrum");
		}
		return text;
	}

	protected override string GetClassNameCore()
	{
		return "ColorSpectrum";
	}

	protected override string GetHelpTextCore()
	{
		return ResourceAccessor.GetLocalizedStringResource("HelpTextColorSpectrum");
	}

	protected override Rect GetBoundingRectangleCore()
	{
		return _owner.GetBoundingRectangle();
	}

	protected override Point GetClickablePointCore()
	{
		Rect boundingRectangleCore = GetBoundingRectangleCore();
		return new Point(boundingRectangleCore.X + boundingRectangleCore.Width / 2.0, boundingRectangleCore.Y + boundingRectangleCore.Height / 2.0);
	}

	public void SetValue(string value)
	{
		ColorSpectrum owner = _owner;
		Color color2 = (owner.Color = (Color)XamlBindingHelper.ConvertValue(typeof(Color), value));
		owner.RaiseColorChanged();
	}

	public void RaisePropertyChangedEvent(Color oldColor, Color newColor, Vector4 oldHsvColor, Vector4 newHsvColor)
	{
		if (ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Automation.ValuePatternIdentifiers", "ValueProperty"))
		{
			string valueString = GetValueString(oldColor, oldHsvColor);
			string valueString2 = GetValueString(newColor, newHsvColor);
			RaisePropertyChangedEvent(ValuePatternIdentifiers.ValueProperty, valueString, valueString2);
		}
	}

	private string GetValueString(Color color, Vector4 hsvColor)
	{
		uint num = (uint)Math.Round(Hsv.GetHue(hsvColor));
		uint num2 = (uint)Math.Round(Hsv.GetSaturation(hsvColor) * 100f);
		uint num3 = (uint)Math.Round(Hsv.GetValue(hsvColor) * 100f);
		if (DownlevelHelper.ToDisplayNameExists())
		{
			return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("ValueStringColorSpectrumWithColorName"), ColorHelper.ToDisplayName(color), num, num2, num3);
		}
		return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("ValueStringColorSpectrumWithoutColorName"), num, num2, num3);
	}
}

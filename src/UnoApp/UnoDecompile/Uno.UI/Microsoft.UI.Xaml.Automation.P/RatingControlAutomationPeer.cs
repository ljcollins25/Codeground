using Microsoft.UI.Xaml.Controls;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.Globalization.NumberFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class RatingControlAutomationPeer : FrameworkElementAutomationPeer, IRangeValueProvider, IValueProvider
{
	bool IValueProvider.IsReadOnly => GetRatingControl().IsReadOnly;

	string IValueProvider.Value
	{
		get
		{
			double value = GetRatingControl().Value;
			if (value == -1.0)
			{
				double placeholderValue = GetRatingControl().PlaceholderValue;
				if (placeholderValue == -1.0)
				{
					return ResourceAccessor.GetLocalizedStringResource("RatingUnset");
				}
				return GenerateValue_ValueString(ResourceAccessor.GetLocalizedStringResource("CommunityRatingString"), placeholderValue);
			}
			return GenerateValue_ValueString(ResourceAccessor.GetLocalizedStringResource("BasicRatingString"), value);
		}
	}

	double IRangeValueProvider.SmallChange => 1.0;

	double IRangeValueProvider.LargeChange => 1.0;

	double IRangeValueProvider.Maximum => GetRatingControl().MaxRating;

	double IRangeValueProvider.Minimum => 0.0;

	double IRangeValueProvider.Value
	{
		get
		{
			double value = GetRatingControl().Value;
			if (value == -1.0)
			{
				return 0.0;
			}
			return value;
		}
	}

	bool IRangeValueProvider.IsReadOnly => GetRatingControl().IsReadOnly;

	public RatingControlAutomationPeer(RatingControl owner)
		: base(owner)
	{
	}

	protected override string GetLocalizedControlTypeCore()
	{
		return ResourceAccessor.GetLocalizedStringResource("RatingLocalizedControlType");
	}

	void IValueProvider.SetValue(string value)
	{
		DecimalFormatter decimalFormatter = new DecimalFormatter();
		double? num = decimalFormatter.ParseDouble(value);
		if (num.HasValue)
		{
			GetRatingControl().Value = num.Value;
		}
	}

	void IRangeValueProvider.SetValue(double value)
	{
		GetRatingControl().Value = value;
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.Value || patternInterface == PatternInterface.RangeValue)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Slider;
	}

	internal void RaisePropertyChangedEvent(double newValue)
	{
		double value = GetRatingControl().Value;
		object oldValue = PropertyValue.CreateDouble(value);
		if (newValue == -1.0)
		{
			object newValue2 = PropertyValue.CreateDouble(0.0);
			RaisePropertyChangedEvent(ValuePatternIdentifiers.ValueProperty, oldValue, newValue2);
			RaisePropertyChangedEvent(RangeValuePatternIdentifiers.ValueProperty, oldValue, newValue2);
		}
		else
		{
			object newValue3 = PropertyValue.CreateDouble(newValue);
			RaisePropertyChangedEvent(ValuePatternIdentifiers.ValueProperty, oldValue, newValue3);
			RaisePropertyChangedEvent(RangeValuePatternIdentifiers.ValueProperty, oldValue, newValue3);
		}
	}

	private RatingControl GetRatingControl()
	{
		UIElement owner = base.Owner;
		return owner as RatingControl;
	}

	private int DetermineFractionDigits(double value)
	{
		value *= 100.0;
		int num = (int)value;
		if (num % 100 == 0)
		{
			return 0;
		}
		if (num % 10 == 0)
		{
			return 1;
		}
		return 2;
	}

	private int DetermineSignificantDigits(double value, int fractionDigits)
	{
		int num = (int)value;
		int num2 = 0;
		while (num > 0)
		{
			num /= 10;
			num2++;
		}
		return num2 + fractionDigits;
	}

	private string GenerateValue_ValueString(string resourceString, double ratingValue)
	{
		DecimalFormatter decimalFormatter = new DecimalFormatter();
		SignificantDigitsNumberRounder significantDigitsNumberRounder = (SignificantDigitsNumberRounder)(decimalFormatter.NumberRounder = new SignificantDigitsNumberRounder());
		string text = GetRatingControl().MaxRating.ToString();
		int fractionDigits = DetermineFractionDigits(ratingValue);
		int significantDigits = DetermineSignificantDigits(ratingValue, fractionDigits);
		decimalFormatter.FractionDigits = fractionDigits;
		significantDigitsNumberRounder.SignificantDigits = (uint)significantDigits;
		string text2 = decimalFormatter.Format(ratingValue);
		return StringUtil.FormatString(resourceString, text2, text);
	}
}

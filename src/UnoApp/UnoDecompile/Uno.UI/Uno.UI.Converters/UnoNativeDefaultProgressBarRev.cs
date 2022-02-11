using System;
using System.Globalization;

namespace Uno.UI.Converters;

public class UnoNativeDefaultProgressBarReverseBoolConverter : ConverterBase
{
	protected override object Convert(object value, Type targetType, object parameter)
	{
		if (parameter != null)
		{
			throw new ArgumentException($"This converter does not use any parameters. You should remove \"{parameter}\" passed as parameter.");
		}
		if (value != null && !(value is bool))
		{
			throw new ArgumentException($"Value must either be null or of type bool. Got {value} ({value.GetType().FullName})");
		}
		bool flag = value != null && System.Convert.ToBoolean(value, CultureInfo.InvariantCulture);
		return !flag;
	}

	protected override object ConvertBack(object value, Type targetType, object parameter)
	{
		if (value == null)
		{
			throw new InvalidOperationException("Since results should never be null, reverse conversion does not support null values");
		}
		return Convert(value, targetType, parameter);
	}
}

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Windows.UI.Xaml;

public class ThicknessConverter : TypeConverter
{
	private static readonly char[] _valueSeparator = new char[5] { ',', ' ', '\t', '\r', '\n' };

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string) || sourceType == typeof(double) || sourceType == typeof(float) || sourceType == typeof(int))
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string text)
		{
			double[] array = (from s in text.Split(_valueSeparator, StringSplitOptions.RemoveEmptyEntries)
				select double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
			if (array.Length == 4)
			{
				return new Thickness(array[0], array[1], array[2], array[3]);
			}
			if (array.Length == 2)
			{
				return new Thickness(array[0], array[1], array[0], array[1]);
			}
			return new Thickness(array[0], array[0], array[0], array[0]);
		}
		if (value is double uniformLength)
		{
			return new Thickness(uniformLength);
		}
		if (value is float num)
		{
			return new Thickness(num);
		}
		if (value is int num2)
		{
			return new Thickness(num2);
		}
		return base.ConvertFrom(context, culture, value);
	}
}

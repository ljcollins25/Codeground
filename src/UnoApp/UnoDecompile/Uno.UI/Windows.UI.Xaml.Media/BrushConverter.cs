using System;
using System.ComponentModel;
using System.Globalization;

namespace Windows.UI.Xaml.Media;

public class BrushConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string) || sourceType == typeof(Color))
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (!(value is string colorCode))
		{
			if (value is Color color)
			{
				return new SolidColorBrush(color);
			}
			return base.ConvertFrom(context, culture, value);
		}
		return SolidColorBrushHelper.FromARGB(colorCode);
	}
}

using System;
using System.ComponentModel;
using System.Globalization;
using Windows.UI.Xaml.Media;

namespace Uno.Media;

public sealed class GeometryConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string))
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string text)
		{
			return (Geometry)text;
		}
		return base.ConvertFrom(context, culture, value);
	}
}

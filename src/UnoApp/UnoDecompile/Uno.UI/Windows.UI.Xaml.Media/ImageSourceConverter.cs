using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using Uno.Extensions;

namespace Windows.UI.Xaml.Media;

public class ImageSourceConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string) || sourceType == typeof(Uri) || sourceType.Is(typeof(Stream)))
		{
			return true;
		}
		if (false)
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			return (ImageSource)(string)value;
		}
		if (value is Uri)
		{
			return (ImageSource)(Uri)value;
		}
		if (value is Stream)
		{
			return (ImageSource)(Stream)value;
		}
		ImageSource imageSource = null;
		if (imageSource != null)
		{
			return imageSource;
		}
		return base.ConvertFrom(context, culture, value);
	}
}

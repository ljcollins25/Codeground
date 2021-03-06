using System;
using Windows.UI.Xaml.Data;

namespace Uno.UI.Converters;

public abstract class ConverterBase : IValueConverter
{
	object IValueConverter.Convert(object value, Type targetType, object parameter, string culture)
	{
		return Convert(value, targetType, parameter);
	}

	protected abstract object Convert(object value, Type targetType, object parameter);

	object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string culture)
	{
		return ConvertBack(value, targetType, parameter);
	}

	protected virtual object ConvertBack(object value, Type targetType, object parameter)
	{
		throw new NotSupportedException();
	}
}

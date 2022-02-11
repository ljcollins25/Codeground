using System;
using System.Globalization;
using Uno.UI.Converters;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Controls.MediaPlayer.Internal;

internal class FromNullableBoolToVisibilityConverter : ConverterBase
{
	public VisibilityIfTrue VisibilityIfTrue { get; set; }

	public FromNullableBoolToVisibilityConverter()
	{
		VisibilityIfTrue = VisibilityIfTrue.Visible;
	}

	protected override object Convert(object value, Type targetType, object parameter)
	{
		if (parameter != null)
		{
			throw new ArgumentException($"This converter does not use any parameters. You should remove \"{parameter}\" passed as parameter.");
		}
		bool flag = VisibilityIfTrue == VisibilityIfTrue.Collapsed;
		Visibility visibility = (flag ? Visibility.Collapsed : Visibility.Visible);
		Visibility visibility2 = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		if (value != null && !(value is bool))
		{
			throw new ArgumentException($"Value must either be null or of type bool. Got {value} ({value.GetType().FullName})");
		}
		return (value != null && System.Convert.ToBoolean(value, CultureInfo.InvariantCulture)) ? visibility : visibility2;
	}

	protected override object ConvertBack(object value, Type targetType, object parameter)
	{
		if (value == null)
		{
			return null;
		}
		if (parameter != null)
		{
			throw new ArgumentException($"This converter does not use any parameters. You should remove \"{parameter}\" passed as parameter.");
		}
		Visibility visibility = ((VisibilityIfTrue == VisibilityIfTrue.Collapsed) ? Visibility.Collapsed : Visibility.Visible);
		Visibility visibility2 = (Visibility)value;
		return visibility.Equals(visibility2);
	}
}

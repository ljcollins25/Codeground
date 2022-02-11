using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Windows.UI.Xaml;

[TypeConverter(typeof(Converter))]
[DebuggerDisplay("{DebugDisplay,nq}")]
public struct GridLength : IEquatable<GridLength>
{
	public class Converter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string) || sourceType.IsPrimitive)
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				return ParseGridLength(value as string).FirstOrDefault();
			}
			if (value is ValueType)
			{
				return GridLengthHelper.FromPixels(Convert.ToDouble(value));
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}

	public static GridLength Auto => GridLengthHelper.Auto;

	public GridUnitType GridUnitType { get; private set; }

	public bool IsAbsolute => GridUnitType == GridUnitType.Pixel;

	public bool IsAuto => GridUnitType == GridUnitType.Auto;

	public bool IsStar => GridUnitType == GridUnitType.Star;

	public double Value { get; private set; }

	private string DebugDisplay => ToDisplayString();

	public static implicit operator GridLength(string value)
	{
		return FromString(value);
	}

	public static implicit operator GridLength(double value)
	{
		return new GridLength(value);
	}

	public GridLength(double pixels)
		: this(pixels, GridUnitType.Pixel)
	{
	}

	public GridLength(double value, GridUnitType gridUnitType)
	{
		if (double.IsNaN(value) || double.IsInfinity(value) || value < 0.0 || (gridUnitType != 0 && gridUnitType != GridUnitType.Pixel && gridUnitType != GridUnitType.Star))
		{
			throw new ArgumentException($"Invalid GridLength {value}{gridUnitType}.", "value");
		}
		Value = ((gridUnitType == GridUnitType.Auto) ? 1.0 : value);
		GridUnitType = gridUnitType;
	}

	public static GridLength FromString(string s)
	{
		string text = s.Trim();
		if (text == "*")
		{
			return new GridLength(1.0, GridUnitType.Star);
		}
		if (text.Equals("auto", StringComparison.OrdinalIgnoreCase))
		{
			return new GridLength(0.0, GridUnitType.Auto);
		}
		if (text.EndsWith("*"))
		{
			string s2 = text.Substring(0, text.Length - 1);
			if (double.TryParse(s2, NumberStyles.Float | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out var result))
			{
				return new GridLength(result, GridUnitType.Star);
			}
			throw new InvalidOperationException("The value [" + text + "] is not a valid GridLength");
		}
		if (text.EndsWith("px", StringComparison.OrdinalIgnoreCase) || text.EndsWith("cm", StringComparison.OrdinalIgnoreCase) || text.EndsWith("in", StringComparison.OrdinalIgnoreCase) || text.EndsWith("pt", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(0, text.Length - 2);
		}
		if (double.TryParse(text, NumberStyles.Float | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out var result2))
		{
			return new GridLength(result2, GridUnitType.Pixel);
		}
		throw new InvalidOperationException("The value [" + text + "] is not a valid GridLength");
	}

	public static GridLength[] ParseGridLength(string s)
	{
		string[] array = s.Split(new char[1] { ',' });
		List<GridLength> list = new List<GridLength>(array.Length);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.IsNullOrEmpty(text))
			{
				list.Add(new GridLength(0.0, GridUnitType.Auto));
			}
			else
			{
				list.Add(FromString(text));
			}
		}
		return list.ToArray();
	}

	public bool Equals(GridLength other)
	{
		if (other.GridUnitType == GridUnitType)
		{
			if (GridUnitType == GridUnitType.Auto)
			{
				return true;
			}
			return other.Value == Value;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is GridLength other))
		{
			return false;
		}
		return Equals(other);
	}

	public override int GetHashCode()
	{
		return GridUnitType.GetHashCode() ^ Value.GetHashCode();
	}

	public static bool operator ==(GridLength gl1, GridLength gl2)
	{
		return gl1.Equals(gl2);
	}

	public static bool operator !=(GridLength gl1, GridLength gl2)
	{
		return !gl1.Equals(gl2);
	}

	internal readonly string ToDisplayString()
	{
		return $"GridLength({this})";
	}

	public override string ToString()
	{
		return GridUnitType switch
		{
			GridUnitType.Auto => "Auto", 
			GridUnitType.Pixel => $"{Value:f1}px", 
			GridUnitType.Star => $"{Value:f1}*", 
			_ => "invalid", 
		};
	}
}

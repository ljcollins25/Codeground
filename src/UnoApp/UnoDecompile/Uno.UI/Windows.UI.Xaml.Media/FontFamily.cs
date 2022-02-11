using System;

namespace Windows.UI.Xaml.Media;

public class FontFamily
{
	private readonly int _hashCode;

	public string Source { get; }

	public static FontFamily Default { get; } = new FontFamily("Segoe UI");


	internal string ParsedSource { get; private set; }

	public FontFamily(string familyName)
	{
		Source = familyName;
		Init(familyName);
		_hashCode = Source.GetHashCode();
	}

	public static implicit operator FontFamily(string familyName)
	{
		return new FontFamily(familyName);
	}

	public override bool Equals(object obj)
	{
		if (obj is FontFamily fontFamily)
		{
			return Source.Equals(fontFamily.Source, StringComparison.Ordinal);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public static bool operator ==(FontFamily a, FontFamily b)
	{
		if ((object)a == b)
		{
			return true;
		}
		return a?.Equals(b) ?? false;
	}

	public static bool operator !=(FontFamily a, FontFamily b)
	{
		if ((object)a == b)
		{
			return false;
		}
		if ((object)a != null)
		{
			return !a.Equals(b);
		}
		return true;
	}

	private void Init(string fontName)
	{
		ParsedSource = ParseFontFamilySource(fontName);
	}

	private string ParseFontFamilySource(string familyName)
	{
		if (string.IsNullOrEmpty(familyName))
		{
			throw new ArgumentException("Font family name must not be empty string nor null", "familyName");
		}
		if (familyName.Contains("/") || familyName.Contains("#"))
		{
			int num = familyName.LastIndexOf("#");
			if (num != -1)
			{
				return familyName.Substring(num + 1);
			}
			int num2 = familyName.LastIndexOf("/") + 1;
			int num3 = familyName.LastIndexOf(".");
			if (num3 < num2)
			{
				num3 = familyName.Length;
			}
			return familyName.Substring(num2, num3 - num2);
		}
		return familyName;
	}
}

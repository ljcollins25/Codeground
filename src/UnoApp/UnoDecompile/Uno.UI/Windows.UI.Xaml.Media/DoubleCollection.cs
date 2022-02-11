using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Uno;

namespace Windows.UI.Xaml.Media;

public class DoubleCollection : List<double>, IList<double>, ICollection<double>, IEnumerable<double>, IEnumerable
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Size
	{
		get
		{
			throw new NotImplementedException("The member uint DoubleCollection.Size is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsReadOnly
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public DoubleCollection()
	{
	}

	public DoubleCollection(IEnumerable<double> collection)
		: base(collection)
	{
	}

	public static implicit operator DoubleCollection(string value)
	{
		return (from str in value.Split(',', ' ')
			select double.Parse(str, CultureInfo.InvariantCulture)).ToArray();
	}

	public static implicit operator DoubleCollection(double[] value)
	{
		return new DoubleCollection(value);
	}
}

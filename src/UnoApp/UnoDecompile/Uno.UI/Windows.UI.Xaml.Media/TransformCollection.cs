using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Uno;

namespace Windows.UI.Xaml.Media;

public class TransformCollection : ObservableCollection<Transform>, IList<Transform>, ICollection<Transform>, IEnumerable<Transform>, IEnumerable
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Size
	{
		get
		{
			throw new NotImplementedException("The member uint TransformCollection.Size is not implemented in Uno.");
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
}

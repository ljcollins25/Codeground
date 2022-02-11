using System;
using System.Collections;
using System.Collections.Generic;
using Uno;

namespace Windows.UI.Xaml.Media.Animation;

public class TransitionCollection : List<Transition>, IList<Transition>, ICollection<Transition>, IEnumerable<Transition>, IEnumerable
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Size
	{
		get
		{
			throw new NotImplementedException("The member uint TransitionCollection.Size is not implemented in Uno.");
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

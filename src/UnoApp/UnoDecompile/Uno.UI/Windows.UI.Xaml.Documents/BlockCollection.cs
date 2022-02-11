using System;
using System.Collections;
using System.Collections.Generic;
using Uno;

namespace Windows.UI.Xaml.Documents;

public class BlockCollection : DependencyObjectCollection<Block>, IList<Block>, ICollection<Block>, IEnumerable<Block>, IEnumerable
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new Block this[int index]
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public new void Add(Block block)
	{
		base.Add(block);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Uno;

namespace Windows.UI.Xaml;

public sealed class SetterBaseCollection : DependencyObjectCollection<SetterBase>, IList<SetterBase>, ICollection<SetterBase>, IEnumerable<SetterBase>, IEnumerable
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSealed
	{
		get
		{
			throw new NotImplementedException("The member bool SetterBaseCollection.IsSealed is not implemented in Uno.");
		}
	}

	public SetterBaseCollection()
	{
	}

	internal SetterBaseCollection(DependencyObject parent, bool isAutoPropertyInheritanceEnabled)
		: base(parent, isAutoPropertyInheritanceEnabled: false)
	{
	}
}

using System;

namespace Uno.UI.DataBinding;

public interface IBindableType
{
	Type Type { get; }

	ActivatorDelegate? CreateInstance();

	IBindableProperty? GetProperty(string name);

	StringIndexerGetterDelegate? GetIndexerGetter();

	StringIndexerSetterDelegate? GetIndexerSetter();
}

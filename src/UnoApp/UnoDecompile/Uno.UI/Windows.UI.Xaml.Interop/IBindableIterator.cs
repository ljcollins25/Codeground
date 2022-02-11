using Uno;

namespace Windows.UI.Xaml.Interop;

[NotImplemented]
public interface IBindableIterator
{
	object Current { get; }

	bool HasCurrent { get; }

	bool MoveNext();
}

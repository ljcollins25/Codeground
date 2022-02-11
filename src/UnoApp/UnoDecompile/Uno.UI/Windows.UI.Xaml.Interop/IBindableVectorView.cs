using System.Collections;
using Uno;

namespace Windows.UI.Xaml.Interop;

[NotImplemented]
public interface IBindableVectorView : IEnumerable
{
	uint Size { get; }

	object GetAt(uint index);

	bool IndexOf(object value, out uint index);
}

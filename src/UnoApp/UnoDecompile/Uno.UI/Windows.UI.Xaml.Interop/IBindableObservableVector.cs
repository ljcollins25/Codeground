using System.Collections;
using Uno;

namespace Windows.UI.Xaml.Interop;

[NotImplemented]
public interface IBindableObservableVector : IList, ICollection, IEnumerable
{
	event BindableVectorChangedEventHandler VectorChanged;
}

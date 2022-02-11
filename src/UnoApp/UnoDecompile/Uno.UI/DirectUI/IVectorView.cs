using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal interface IVectorView<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
{
	uint Size { get; }

	T GetAt(uint index);

	bool IndexOf(T value, out uint index);
}

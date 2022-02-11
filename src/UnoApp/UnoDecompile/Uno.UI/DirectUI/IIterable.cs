using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal interface IIterable<T> : IEnumerable<T>, IEnumerable
{
	IIterator<T> GetIterator();
}

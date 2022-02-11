using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal interface IVector<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
}

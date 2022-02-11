using System;
using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal interface IIterator<T> : IEnumerator<T>, IEnumerator, IDisposable
{
	bool HasCurrent { get; }
}

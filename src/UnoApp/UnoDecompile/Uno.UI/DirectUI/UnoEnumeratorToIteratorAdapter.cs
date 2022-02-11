using System;
using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal class UnoEnumeratorToIteratorAdapter<T> : IIterator<T>, IEnumerator<T>, IEnumerator, IDisposable
{
	private readonly IEnumerator<T> _inner;

	public T Current => _inner.Current;

	object IEnumerator.Current => ((IEnumerator)_inner).Current;

	public bool HasCurrent { get; private set; }

	public UnoEnumeratorToIteratorAdapter(IEnumerator<T> inner)
	{
		_inner = inner;
	}

	public bool MoveNext()
	{
		return HasCurrent = _inner.MoveNext();
	}

	public void Reset()
	{
		_inner.Reset();
	}

	public void Dispose()
	{
		_inner.Dispose();
	}
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal class UnoVectorViewToEnumerableAdapter<T> : IEnumerator<T>, IEnumerator, IDisposable
{
	private readonly IVectorView<T> _view;

	private int _index = -1;

	object IEnumerator.Current => Current;

	public T Current => _view.GetAt((uint)_index);

	public UnoVectorViewToEnumerableAdapter(IVectorView<T> view)
	{
		_view = view;
	}

	public bool MoveNext()
	{
		return ++_index < _view.Size;
	}

	public void Reset()
	{
	}

	public void Dispose()
	{
	}
}

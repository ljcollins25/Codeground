using System;
using System.Collections.Generic;
using Uno.Buffers;

namespace Windows.UI.Xaml;

internal class DependencyPropertyCallbackManager : IDisposable
{
	private class CallbackDisposable : IDisposable
	{
		private readonly LinkedListNode<PropertyChangedCallback> _cookie;

		private readonly DependencyPropertyCallbackManager _owner;

		public CallbackDisposable(DependencyPropertyCallbackManager owner, LinkedListNode<PropertyChangedCallback> cookie)
		{
			_cookie = cookie;
			_owner = owner;
		}

		public void Dispose()
		{
			_owner._callbacks.Remove(_cookie);
			_owner._id++;
			_owner.ReturnShadowToPool();
		}
	}

	private readonly LinkedList<PropertyChangedCallback> _callbacks = new LinkedList<PropertyChangedCallback>();

	private static readonly ArrayPool<PropertyChangedCallback> _pool = ArrayPool<PropertyChangedCallback>.Create(100, 100);

	private PropertyChangedCallback[] _callbacksShadow;

	private int _id;

	private bool _disposed;

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			ReturnShadowToPool();
		}
	}

	public IDisposable RegisterCallback(PropertyChangedCallback callback)
	{
		ReturnShadowToPool();
		_id++;
		return new CallbackDisposable(this, _callbacks.AddLast(callback));
	}

	public void RaisePropertyChanged(DependencyObject actualInstanceAlias, DependencyPropertyChangedEventArgs eventArgs)
	{
		EnsureCallbacksShadow();
		PropertyChangedCallback[] callbacksShadow = _callbacksShadow;
		int count = _callbacks.Count;
		int id = _id;
		_callbacksShadow = null;
		for (int i = 0; i < count; i++)
		{
			callbacksShadow[i](actualInstanceAlias, eventArgs);
		}
		if (_id == id && _callbacksShadow == null)
		{
			_callbacksShadow = callbacksShadow;
		}
		else
		{
			_pool.Return(callbacksShadow, clearArray: true);
		}
	}

	private void EnsureCallbacksShadow()
	{
		if (_callbacksShadow == null)
		{
			if (_callbacks.Count != 0)
			{
				_callbacksShadow = _pool.Rent(_callbacks.Count);
				_callbacks.CopyTo(_callbacksShadow, 0);
				GC.ReRegisterForFinalize(this);
			}
			else
			{
				_callbacksShadow = Array.Empty<PropertyChangedCallback>();
			}
		}
	}

	private void ReturnShadowToPool()
	{
		if (_callbacksShadow != null)
		{
			_pool.Return(_callbacksShadow, clearArray: true);
			_callbacksShadow = null;
			GC.SuppressFinalize(this);
		}
	}
}

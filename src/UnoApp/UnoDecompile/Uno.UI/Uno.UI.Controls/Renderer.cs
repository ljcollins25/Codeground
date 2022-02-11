using System;
using System.Collections.Generic;
using Uno.Disposables;
using Windows.UI.Xaml;

namespace Uno.UI.Controls;

internal abstract class Renderer<TElement, TNative> : IDisposable where TElement : DependencyObject where TNative : class
{
	private CompositeDisposable _subscriptions = new CompositeDisposable();

	private readonly WeakReference _element;

	private TNative _native;

	private bool _isRendering;

	public TElement Element => (TElement)_element.Target;

	public TNative Native
	{
		get
		{
			if (_native == null)
			{
				_native = CreateNativeInstance();
				OnNativeChanged();
			}
			return _native;
		}
		set
		{
			if (_native != value)
			{
				_native = value;
				OnNativeChanged();
			}
		}
	}

	public Renderer(TElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		_element = new WeakReference(element);
	}

	private void OnNativeChanged()
	{
		_subscriptions.Dispose();
		if (_native != null)
		{
			_subscriptions = new CompositeDisposable(Initialize());
		}
		Invalidate();
	}

	protected abstract TNative CreateNativeInstance();

	public void Invalidate()
	{
		if (_native != null && !_isRendering)
		{
			try
			{
				_isRendering = true;
				Render();
			}
			finally
			{
				_isRendering = false;
			}
		}
	}

	protected abstract IEnumerable<IDisposable> Initialize();

	protected abstract void Render();

	public void Dispose()
	{
		_subscriptions.Dispose();
	}
}

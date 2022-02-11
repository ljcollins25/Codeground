using System;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls.Primitives;

internal class NativePopupAdapter<T> : IPopup
{
	private readonly T _nativePopup;

	private readonly Action<T> _open;

	private readonly Action<T> _close;

	private IDisposable _openPopupRegistration;

	private bool _isOpen;

	public T NativePopup => _nativePopup;

	public bool IsOpen
	{
		get
		{
			return _isOpen;
		}
		set
		{
			if (_isOpen != value)
			{
				_isOpen = value;
				if (value)
				{
					_open(_nativePopup);
					_openPopupRegistration = VisualTreeHelper.RegisterOpenPopup(this);
					this.Opened?.Invoke(this, EventArgs.Empty);
				}
				else
				{
					_close(_nativePopup);
					_openPopupRegistration?.Dispose();
					this.Closed?.Invoke(this, EventArgs.Empty);
				}
			}
		}
	}

	public UIElement Child { get; set; }

	public event EventHandler<object> Opened;

	public event EventHandler<object> Closed;

	public NativePopupAdapter(T nativePopup, Action<T> open, Action<T> close, Action<T, EventHandler> opened = null, Action<T, EventHandler> closed = null)
	{
		_nativePopup = nativePopup;
		_open = open;
		_close = close;
		opened?.Invoke(_nativePopup, delegate
		{
			IsOpen = true;
		});
		closed?.Invoke(_nativePopup, delegate
		{
			IsOpen = false;
		});
	}
}

using Uno.UI.DataBinding;

namespace Windows.UI.Xaml.Markup;

public class ComponentHolder
{
	private ManagedWeakReference? _instanceRef;

	private object? _instance;

	public object? Instance
	{
		get
		{
			if (!IsWeak)
			{
				return _instance;
			}
			return _instanceRef?.Target;
		}
		set
		{
			if (IsWeak)
			{
				_instanceRef = WeakReferencePool.RentWeakReference(this, value);
			}
			else
			{
				_instance = value;
			}
		}
	}

	public bool IsWeak { get; }

	public ComponentHolder()
		: this(isWeak: true)
	{
	}

	public ComponentHolder(bool isWeak)
	{
		IsWeak = isWeak;
	}
}

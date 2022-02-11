using Uno.UI.DataBinding;

namespace Windows.UI.Xaml.Data;

public class ElementNameSubject
{
	public delegate void ElementInstanceChangedHandler(object sender, object? instance);

	private ManagedWeakReference? _elementInstanceRef;

	public object? ElementInstance
	{
		get
		{
			object obj = _elementInstanceRef?.Target;
			if (!(obj is ElementStub))
			{
				if (obj != null)
				{
					return obj;
				}
				return null;
			}
			return null;
		}
		set
		{
			_elementInstanceRef = WeakReferencePool.RentWeakReference(this, value);
			object obj = _elementInstanceRef?.Target;
			if (!(obj is ElementStub))
			{
				this.ElementInstanceChanged?.Invoke(this, obj);
			}
		}
	}

	internal object? ActualElementInstance => _elementInstanceRef?.Target;

	public bool IsLoadTimeBound { get; set; }

	public string? Name { get; set; }

	public event ElementInstanceChangedHandler? ElementInstanceChanged;

	public ElementNameSubject()
	{
	}

	public ElementNameSubject(bool isRuntimeBound, string name)
	{
		IsLoadTimeBound = isRuntimeBound;
		Name = name;
	}
}

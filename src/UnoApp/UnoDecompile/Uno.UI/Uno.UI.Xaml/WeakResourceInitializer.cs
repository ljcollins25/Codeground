using System.ComponentModel;
using Uno.UI.DataBinding;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml;

[EditorBrowsable(EditorBrowsableState.Never)]
public class WeakResourceInitializer
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate object ResourceInitializerWithOwner(object? owner);

	private readonly ManagedWeakReference _owner;

	public ResourceDictionary.ResourceInitializer Initializer { get; }

	public WeakResourceInitializer(object owner, ResourceInitializerWithOwner initializer)
	{
		ResourceInitializerWithOwner initializer2 = initializer;
		base._002Ector();
		WeakResourceInitializer weakResourceInitializer = this;
		_owner = WeakReferencePool.RentWeakReference(this, owner);
		Initializer = () => initializer2(weakResourceInitializer._owner?.Target);
	}
}

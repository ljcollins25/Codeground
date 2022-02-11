using System.Collections.Generic;
using System.ComponentModel;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml;

[EditorBrowsable(EditorBrowsableState.Never)]
public class NameScope : INameScope
{
	private Dictionary<string, ManagedWeakReference> _names = new Dictionary<string, ManagedWeakReference>();

	private ManagedWeakReference _ownerRef;

	public DependencyObject Owner
	{
		get
		{
			return _ownerRef?.Target as DependencyObject;
		}
		set
		{
			if (_ownerRef != null)
			{
				WeakReferencePool.ReturnWeakReference(this, _ownerRef);
			}
			_ownerRef = WeakReferencePool.RentWeakReference(this, value);
		}
	}

	public static DependencyProperty NameScopeProperty { get; } = DependencyProperty.RegisterAttached("NameScope", typeof(INameScope), typeof(NameScope), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));


	public object FindName(string name)
	{
		if (!_names.TryGetValue(name, out var value))
		{
			return null;
		}
		return value.Target;
	}

	public void RegisterName(string name, object scopedElement)
	{
		if (_names.ContainsKey(name))
		{
			this.Log().Warn("The name [" + name + "] already exists in the current XAML scope");
		}
		_names[name] = WeakReferencePool.RentWeakReference(this, scopedElement);
	}

	public void UnregisterName(string name)
	{
		_names.Remove(name);
	}

	public static void SetNameScope(DependencyObject dependencyObject, INameScope value)
	{
		dependencyObject.SetValue(NameScopeProperty, value);
	}

	public static INameScope GetNameScope(DependencyObject dependencyObject)
	{
		return (INameScope)dependencyObject.GetValue(NameScopeProperty);
	}

	internal static object FindInNamescopes(DependencyObject caller, string name)
	{
		DependencyObject dependencyObject = caller;
		while (dependencyObject != null)
		{
			INameScope nameScope = GetNameScope(dependencyObject);
			object obj = nameScope?.FindName(name);
			if (obj != null)
			{
				return obj;
			}
			DependencyObject dependencyObject2 = dependencyObject.GetParent() as DependencyObject;
			if (dependencyObject2 == null && !(dependencyObject is UIElement))
			{
				DependencyObject dependencyObject3 = nameScope?.Owner;
				if (dependencyObject3 != null)
				{
					return FindInNamescopes(dependencyObject3, name);
				}
			}
			dependencyObject = dependencyObject2;
		}
		return null;
	}
}

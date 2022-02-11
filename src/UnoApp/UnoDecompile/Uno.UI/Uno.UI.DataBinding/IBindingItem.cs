using System;

namespace Uno.UI.DataBinding;

public interface IBindingItem
{
	string PropertyName { get; }

	Type PropertyType { get; }

	object DataContext { get; }
}

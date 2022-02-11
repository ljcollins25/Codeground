using System;

namespace Uno.UI.DataBinding;

public interface IBindingAdapter
{
	Type TargetType { get; }

	void SetValue(object instance, object value);

	object GetValue(object instance);
}

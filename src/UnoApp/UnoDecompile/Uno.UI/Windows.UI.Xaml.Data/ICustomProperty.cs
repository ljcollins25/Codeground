using System;

namespace Windows.UI.Xaml.Data;

public interface ICustomProperty
{
	bool CanRead { get; }

	bool CanWrite { get; }

	string Name { get; }

	Type Type { get; }

	object GetValue(object target);

	void SetValue(object target, object value);

	object GetIndexedValue(object target, object index);

	void SetIndexedValue(object target, object value, object index);
}

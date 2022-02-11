using System;

namespace Windows.UI.Xaml.Data;

public interface ICustomPropertyProvider
{
	Type Type { get; }

	ICustomProperty GetCustomProperty(string name);

	ICustomProperty GetIndexedProperty(string name, Type type);

	string GetStringRepresentation();
}

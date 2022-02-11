using System;
using Uno.Collections;

namespace Windows.UI.Xaml;

internal class PropertyMetadataDictionary
{
	internal delegate PropertyMetadata CreationHandler();

	private readonly HashtableEx _table = new HashtableEx();

	internal void Add(Type ownerType, PropertyMetadata ownerTypeMetadata)
	{
		_table.Add(ownerType, ownerTypeMetadata);
	}

	internal bool TryGetValue(Type ownerType, out PropertyMetadata? metadata)
	{
		if (_table.TryGetValue(ownerType, out var value))
		{
			metadata = (PropertyMetadata)value;
			return true;
		}
		metadata = null;
		return false;
	}

	internal bool ContainsKey(Type ownerType)
	{
		return _table.ContainsKey(ownerType);
	}

	internal bool ContainsValue(PropertyMetadata typeMetadata)
	{
		return _table.ContainsValue(typeMetadata);
	}

	internal PropertyMetadata FindOrCreate(Type ownerType, CreationHandler createHandler)
	{
		if (_table.TryGetValue(ownerType, out var value))
		{
			return (PropertyMetadata)value;
		}
		PropertyMetadata propertyMetadata = createHandler();
		_table[ownerType] = propertyMetadata;
		return propertyMetadata;
	}
}

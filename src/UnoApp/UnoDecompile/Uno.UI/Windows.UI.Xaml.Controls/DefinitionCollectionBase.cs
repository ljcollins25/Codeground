using System.Collections.Generic;

namespace Windows.UI.Xaml.Controls;

internal interface DefinitionCollectionBase
{
	int Count { get; }

	IEnumerable<DefinitionBase> GetItems();

	DefinitionBase GetItem(int index);

	internal void Lock();

	internal void Unlock();
}

using System.Collections.Generic;

namespace Windows.UI.Xaml;

internal interface IAdditionalChildrenProvider
{
	IEnumerable<DependencyObject> GetAdditionalChildObjects();
}

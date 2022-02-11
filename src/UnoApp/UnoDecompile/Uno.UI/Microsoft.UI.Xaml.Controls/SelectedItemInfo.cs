using System;

namespace Microsoft.UI.Xaml.Controls;

internal struct SelectedItemInfo
{
	internal WeakReference<SelectionNode> Node;

	internal IndexPath Path;
}

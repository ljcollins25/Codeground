using System;

namespace Windows.UI.Xaml.Data;

[Flags]
internal enum ResourceUpdateReason
{
	None = 0,
	StaticResourceLoading = 1,
	ThemeResource = 2,
	HotReload = 4,
	PropagatesThroughTree = 6
}

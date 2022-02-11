using System;

namespace Microsoft.UI.Xaml.Controls;

[Flags]
public enum ElementRealizationOptions
{
	None = 0,
	ForceCreate = 1,
	SuppressAutoRecycle = 2
}

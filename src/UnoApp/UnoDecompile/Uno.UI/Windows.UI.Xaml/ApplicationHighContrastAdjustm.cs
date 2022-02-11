using System;

namespace Windows.UI.Xaml;

[Flags]
public enum ApplicationHighContrastAdjustment : uint
{
	None = 0u,
	Auto = uint.MaxValue
}

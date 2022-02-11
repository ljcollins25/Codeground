using System;

namespace Windows.UI.Xaml;

[Flags]
public enum ElementHighContrastAdjustment : uint
{
	None = 0u,
	Application = 0x80000000u,
	Auto = uint.MaxValue
}

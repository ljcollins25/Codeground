using System;

namespace Windows.UI.Xaml.Controls;

[Flags]
public enum DisabledFormattingAccelerators : uint
{
	None = 0u,
	Bold = 1u,
	Italic = 2u,
	Underline = 4u,
	All = uint.MaxValue
}

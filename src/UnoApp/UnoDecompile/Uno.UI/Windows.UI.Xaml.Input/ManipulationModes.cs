using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Input;

[ContractVersion(typeof(UniversalApiContract), 65536u)]
[Flags]
[WebHostHidden]
public enum ManipulationModes : uint
{
	None = 0u,
	TranslateX = 1u,
	TranslateY = 2u,
	[NotImplemented]
	TranslateRailsX = 4u,
	[NotImplemented]
	TranslateRailsY = 8u,
	Rotate = 0x10u,
	Scale = 0x20u,
	TranslateInertia = 0x40u,
	RotateInertia = 0x80u,
	ScaleInertia = 0x100u,
	All = 0xFFFFu,
	System = 0x10000u
}

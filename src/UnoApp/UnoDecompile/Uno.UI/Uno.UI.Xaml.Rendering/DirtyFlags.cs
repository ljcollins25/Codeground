namespace Uno.UI.Xaml.Rendering;

internal enum DirtyFlags
{
	None = 0,
	Render = 1,
	Bounds = 2,
	Independent = 4,
	ForcePropagate = 8
}

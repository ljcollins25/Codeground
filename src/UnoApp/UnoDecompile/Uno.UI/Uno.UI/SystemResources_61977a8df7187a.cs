using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media;

namespace Uno.UI;

internal static class SystemResources_61977a8df7187a26a77c4b89d85ac77aXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(SolidColorBrush instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SolidColorBrush SystemResources_61977a8df7187a26a77c4b89d85ac77a_XamlApply(this SolidColorBrush instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}
}

using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media;

namespace Uno.UI;

internal static class SemanticStylesResources_edd0ab07608c2c0ca43d0d01f07f0b9aXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(SolidColorBrush instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SolidColorBrush SemanticStylesResources_edd0ab07608c2c0ca43d0d01f07f0b9a_XamlApply(this SolidColorBrush instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}
}

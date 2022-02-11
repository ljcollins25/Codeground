using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

internal static class SystemFocusVisual_d2e089aae2316d880324f851cc56641fXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(Border instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Border SystemFocusVisual_d2e089aae2316d880324f851cc56641f_XamlApply(this Border instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}
}

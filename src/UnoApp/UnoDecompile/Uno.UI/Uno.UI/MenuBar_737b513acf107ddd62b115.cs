using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

internal static class MenuBar_737b513acf107ddd62b115a6fa290d25XamlApplyExtensions
{
	public delegate void XamlApplyHandler0(ItemsControl instance);

	public delegate void XamlApplyHandler1(Grid instance);

	public delegate void XamlApplyHandler2(StackPanel instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ItemsControl MenuBar_737b513acf107ddd62b115a6fa290d25_XamlApply(this ItemsControl instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid MenuBar_737b513acf107ddd62b115a6fa290d25_XamlApply(this Grid instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static StackPanel MenuBar_737b513acf107ddd62b115a6fa290d25_XamlApply(this StackPanel instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}
}

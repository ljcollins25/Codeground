using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

internal static class SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1XamlApplyExtensions
{
	public delegate void XamlApplyHandler0(StackPanel instance);

	public delegate void XamlApplyHandler1(Grid instance);

	public delegate void XamlApplyHandler2(ContentPresenter instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static StackPanel SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(this StackPanel instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(this Grid instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ContentPresenter SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(this ContentPresenter instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}
}

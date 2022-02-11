using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI;

internal static class DragView_1768c0992ed91fdec9b729bca455303aXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(TranslateTransform instance);

	public delegate void XamlApplyHandler1(Image instance);

	public delegate void XamlApplyHandler2(TextBlock instance);

	public delegate void XamlApplyHandler3(StackPanel instance);

	public delegate void XamlApplyHandler4(Grid instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TranslateTransform DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(this TranslateTransform instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Image DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(this Image instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TextBlock DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(this TextBlock instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static StackPanel DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(this StackPanel instance, XamlApplyHandler3 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(this Grid instance, XamlApplyHandler4 handler)
	{
		handler(instance);
		return instance;
	}
}

using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI;

internal static class MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3bXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(SolidColorBrush instance);

	public delegate void XamlApplyHandler1(Border instance);

	public delegate void XamlApplyHandler2(Button instance);

	public delegate void XamlApplyHandler3(Grid instance);

	public delegate void XamlApplyHandler4(VisualState instance);

	public delegate void XamlApplyHandler5(VisualStateGroup instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SolidColorBrush MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(this SolidColorBrush instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Border MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(this Border instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Button MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(this Button instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(this Grid instance, XamlApplyHandler3 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static VisualState MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(this VisualState instance, XamlApplyHandler4 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static VisualStateGroup MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(this VisualStateGroup instance, XamlApplyHandler5 handler)
	{
		handler(instance);
		return instance;
	}
}

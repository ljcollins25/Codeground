using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media;

namespace Uno.UI;

internal static class Common_themeresources_any_d61b33e69776fff070b70a0129cde151XamlApplyExtensions
{
	public delegate void XamlApplyHandler0(SolidColorBrush instance);

	public delegate void XamlApplyHandler1(GradientStop instance);

	public delegate void XamlApplyHandler2(LinearGradientBrush instance);

	public delegate void XamlApplyHandler3(ScaleTransform instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SolidColorBrush Common_themeresources_any_d61b33e69776fff070b70a0129cde151_XamlApply(this SolidColorBrush instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static GradientStop Common_themeresources_any_d61b33e69776fff070b70a0129cde151_XamlApply(this GradientStop instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static LinearGradientBrush Common_themeresources_any_d61b33e69776fff070b70a0129cde151_XamlApply(this LinearGradientBrush instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ScaleTransform Common_themeresources_any_d61b33e69776fff070b70a0129cde151_XamlApply(this ScaleTransform instance, XamlApplyHandler3 handler)
	{
		handler(instance);
		return instance;
	}
}

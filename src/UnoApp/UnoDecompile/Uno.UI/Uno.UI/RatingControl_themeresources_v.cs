using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

internal static class RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8XamlApplyExtensions
{
	public delegate void XamlApplyHandler0(Microsoft.UI.Xaml.Controls.RatingItemFontInfo instance);

	public delegate void XamlApplyHandler1(TextBlock instance);

	public delegate void XamlApplyHandler2(Image instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Microsoft.UI.Xaml.Controls.RatingItemFontInfo RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_XamlApply(this Microsoft.UI.Xaml.Controls.RatingItemFontInfo instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TextBlock RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_XamlApply(this TextBlock instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Image RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_XamlApply(this Image instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}
}

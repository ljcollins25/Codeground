using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI;

internal static class ToolTip_ac7e2519a681bcd14512ef3662650954XamlApplyExtensions
{
	public delegate void XamlApplyHandler0(SolidColorBrush instance);

	public delegate void XamlApplyHandler1(ContentPresenter instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SolidColorBrush ToolTip_ac7e2519a681bcd14512ef3662650954_XamlApply(this SolidColorBrush instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ContentPresenter ToolTip_ac7e2519a681bcd14512ef3662650954_XamlApply(this ContentPresenter instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}
}

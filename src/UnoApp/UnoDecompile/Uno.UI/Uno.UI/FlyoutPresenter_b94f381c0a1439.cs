using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

internal static class FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddcXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(ContentPresenter instance);

	public delegate void XamlApplyHandler1(ScrollViewer instance);

	public delegate void XamlApplyHandler2(Border instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ContentPresenter FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddc_XamlApply(this ContentPresenter instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ScrollViewer FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddc_XamlApply(this ScrollViewer instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Border FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddc_XamlApply(this Border instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}
}

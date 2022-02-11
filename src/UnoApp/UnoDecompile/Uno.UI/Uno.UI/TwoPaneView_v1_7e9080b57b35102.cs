using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

internal static class TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1caXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(ColumnDefinition instance);

	public delegate void XamlApplyHandler1(RowDefinition instance);

	public delegate void XamlApplyHandler2(Border instance);

	public delegate void XamlApplyHandler3(ScrollViewer instance);

	public delegate void XamlApplyHandler4(Grid instance);

	public delegate void XamlApplyHandler5(VisualState instance);

	public delegate void XamlApplyHandler6(VisualStateGroup instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ColumnDefinition TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(this ColumnDefinition instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RowDefinition TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(this RowDefinition instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Border TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(this Border instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ScrollViewer TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(this ScrollViewer instance, XamlApplyHandler3 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(this Grid instance, XamlApplyHandler4 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static VisualState TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(this VisualState instance, XamlApplyHandler5 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static VisualStateGroup TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(this VisualStateGroup instance, XamlApplyHandler6 handler)
	{
		handler(instance);
		return instance;
	}
}

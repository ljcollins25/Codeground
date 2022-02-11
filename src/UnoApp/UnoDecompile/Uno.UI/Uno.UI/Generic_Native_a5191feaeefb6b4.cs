using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

internal static class Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2XamlApplyExtensions
{
	public delegate void XamlApplyHandler0(ColumnDefinition instance);

	public delegate void XamlApplyHandler1(RowDefinition instance);

	public delegate void XamlApplyHandler2(ContentPresenter instance);

	public delegate void XamlApplyHandler3(ElementStub instance);

	public delegate void XamlApplyHandler4(ContentControl instance);

	public delegate void XamlApplyHandler5(Grid instance);

	public delegate void XamlApplyHandler6(NativePivotPresenter instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ColumnDefinition Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(this ColumnDefinition instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RowDefinition Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(this RowDefinition instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ContentPresenter Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(this ContentPresenter instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ElementStub Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(this ElementStub instance, XamlApplyHandler3 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ContentControl Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(this ContentControl instance, XamlApplyHandler4 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(this Grid instance, XamlApplyHandler5 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static NativePivotPresenter Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(this NativePivotPresenter instance, XamlApplyHandler6 handler)
	{
		handler(instance);
		return instance;
	}
}

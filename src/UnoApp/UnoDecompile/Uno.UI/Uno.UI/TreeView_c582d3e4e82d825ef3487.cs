using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI;

internal static class TreeView_c582d3e4e82d825ef34875c57c83145bXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(EntranceThemeTransition instance);

	public delegate void XamlApplyHandler1(TextBlock instance);

	public delegate void XamlApplyHandler2(Grid instance);

	public delegate void XamlApplyHandler3(Microsoft.UI.Xaml.Controls.TreeViewList instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static EntranceThemeTransition TreeView_c582d3e4e82d825ef34875c57c83145b_XamlApply(this EntranceThemeTransition instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TextBlock TreeView_c582d3e4e82d825ef34875c57c83145b_XamlApply(this TextBlock instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid TreeView_c582d3e4e82d825ef34875c57c83145b_XamlApply(this Grid instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Microsoft.UI.Xaml.Controls.TreeViewList TreeView_c582d3e4e82d825ef34875c57c83145b_XamlApply(this Microsoft.UI.Xaml.Controls.TreeViewList instance, XamlApplyHandler3 handler)
	{
		handler(instance);
		return instance;
	}
}

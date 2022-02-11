using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Extensions;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Uno.UI.Helpers.Xaml;

public static class SetterExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Setter ApplyThemeResourceUpdateValues(this Setter setter, string themeResourceName, object parseContext)
	{
		return setter.ApplyThemeResourceUpdateValues(themeResourceName, parseContext, isTheme: true, isHotReload: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Setter ApplyThemeResourceUpdateValues(this Setter setter, string themeResourceName, object parseContext, bool isTheme, bool isHotReload)
	{
		setter.ThemeResourceKey = ((!themeResourceName.IsNullOrEmpty()) ? themeResourceName : null);
		setter.ThemeResourceContext = parseContext as XamlParseContext;
		if (isTheme)
		{
			setter.ResourceBindingUpdateReason |= ResourceUpdateReason.ThemeResource;
		}
		if (isHotReload)
		{
			setter.ResourceBindingUpdateReason |= ResourceUpdateReason.HotReload;
		}
		return setter;
	}
}

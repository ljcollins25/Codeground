using System;
using Windows.UI.Xaml;

namespace Uno.UI.Extensions;

internal static class ElementThemeExtensions
{
	public static ApplicationTheme? ToApplicationThemeOrDefault(this ElementTheme elementTheme)
	{
		return elementTheme switch
		{
			ElementTheme.Default => null, 
			ElementTheme.Light => ApplicationTheme.Light, 
			ElementTheme.Dark => ApplicationTheme.Dark, 
			_ => throw new ArgumentException(), 
		};
	}
}

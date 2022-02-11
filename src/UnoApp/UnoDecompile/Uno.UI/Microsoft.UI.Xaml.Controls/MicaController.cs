using Windows.UI;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class MicaController
{
	internal static readonly Color DarkThemeColor = Color.FromArgb(byte.MaxValue, 32, 32, 32);

	internal const float DarkThemeTintOpacity = 0.8f;

	internal static readonly Color LightThemeColor = Color.FromArgb(byte.MaxValue, 243, 243, 243);

	internal const float LightThemeTintOpacity = 0.5f;

	internal bool SetTarget(Window xamlWindow)
	{
		return false;
	}
}

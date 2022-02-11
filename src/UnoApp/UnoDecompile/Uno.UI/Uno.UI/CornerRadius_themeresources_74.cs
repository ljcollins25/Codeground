using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace Uno.UI;

internal static class CornerRadius_themeresources_745a3175d62711194df0d1ca026171daXamlApplyExtensions
{
	public delegate void XamlApplyHandler0(CornerRadiusFilterConverter instance);

	public delegate void XamlApplyHandler1(CornerRadiusToThicknessConverter instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CornerRadiusFilterConverter CornerRadius_themeresources_745a3175d62711194df0d1ca026171da_XamlApply(this CornerRadiusFilterConverter instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CornerRadiusToThicknessConverter CornerRadius_themeresources_745a3175d62711194df0d1ca026171da_XamlApply(this CornerRadiusToThicknessConverter instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}
}

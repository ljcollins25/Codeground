using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI;

internal static class ProgressRing_09242e98778da8e36c54a331b05303b2XamlApplyExtensions
{
	public delegate void XamlApplyHandler0(AnimatedVisualPlayer instance);

	public delegate void XamlApplyHandler1(Grid instance);

	public delegate void XamlApplyHandler2(VisualState instance);

	public delegate void XamlApplyHandler3(DoubleAnimation instance);

	public delegate void XamlApplyHandler4(VisualStateGroup instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static AnimatedVisualPlayer ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(this AnimatedVisualPlayer instance, XamlApplyHandler0 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Grid ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(this Grid instance, XamlApplyHandler1 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static VisualState ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(this VisualState instance, XamlApplyHandler2 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static DoubleAnimation ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(this DoubleAnimation instance, XamlApplyHandler3 handler)
	{
		handler(instance);
		return instance;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static VisualStateGroup ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(this VisualStateGroup instance, XamlApplyHandler4 handler)
	{
		handler(instance);
		return instance;
	}
}

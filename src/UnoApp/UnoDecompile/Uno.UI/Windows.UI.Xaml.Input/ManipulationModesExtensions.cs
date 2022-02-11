using Uno.Foundation.Logging;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

internal static class ManipulationModesExtensions
{
	private const ManipulationModes _unsupported = ManipulationModes.TranslateRailsX | ManipulationModes.TranslateRailsY | ManipulationModes.TranslateInertia | ManipulationModes.RotateInertia | ManipulationModes.ScaleInertia;

	public static bool IsSupported(this ManipulationModes mode)
	{
		if (mode != ManipulationModes.All)
		{
			return (mode & (ManipulationModes.TranslateRailsX | ManipulationModes.TranslateRailsY | ManipulationModes.TranslateInertia | ManipulationModes.RotateInertia | ManipulationModes.ScaleInertia)) == 0;
		}
		return true;
	}

	public static void LogIfNotSupported(this ManipulationModes mode, Logger log)
	{
		if (!mode.IsSupported() && log.IsEnabled(LogLevel.Information))
		{
			log.Warn($"The ManipulationMode '{mode}' is not supported by Uno. " + "Only 'None', 'All', 'System', 'TranslateX', 'TranslateY', 'Rotate', and 'Scale' are supported. Using any other mode will not cause an error, but the corresponding manipulation event will not be generated. Note that with Uno the 'All' and 'System' are handled the same way.");
		}
	}

	public static GestureSettings ToGestureSettings(this ManipulationModes mode)
	{
		GestureSettings gestureSettings = GestureSettings.None;
		if (mode.HasFlag(ManipulationModes.TranslateX))
		{
			gestureSettings |= GestureSettings.ManipulationTranslateX;
		}
		if (mode.HasFlag(ManipulationModes.TranslateY))
		{
			gestureSettings |= GestureSettings.ManipulationTranslateY;
		}
		if (mode.HasFlag(ManipulationModes.TranslateRailsX))
		{
			gestureSettings |= GestureSettings.ManipulationTranslateRailsX;
		}
		if (mode.HasFlag(ManipulationModes.TranslateRailsY))
		{
			gestureSettings |= GestureSettings.ManipulationTranslateRailsY;
		}
		if (mode.HasFlag(ManipulationModes.TranslateInertia))
		{
			gestureSettings |= GestureSettings.ManipulationTranslateInertia;
		}
		if (mode.HasFlag(ManipulationModes.Rotate))
		{
			gestureSettings |= GestureSettings.ManipulationRotate;
		}
		if (mode.HasFlag(ManipulationModes.RotateInertia))
		{
			gestureSettings |= GestureSettings.ManipulationRotateInertia;
		}
		if (mode.HasFlag(ManipulationModes.Scale))
		{
			gestureSettings |= GestureSettings.ManipulationScale;
		}
		if (mode.HasFlag(ManipulationModes.ScaleInertia))
		{
			gestureSettings |= GestureSettings.ManipulationScaleInertia;
		}
		return gestureSettings;
	}
}

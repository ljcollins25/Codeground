using System;
using Uno.Foundation.Logging;

namespace Windows.UI.Xaml.Media.Animation;

public static class TimelineExtensions
{
	internal static string GetTimelineTargetFullName(this Timeline t)
	{
		return Storyboard.GetTargetName(t) + "." + Storyboard.GetTargetProperty(t);
	}

	internal static bool GetIsDurationZero(this Timeline timeline)
	{
		return timeline.GetCalculatedDuration() == TimeSpan.Zero;
	}

	internal static bool GetIsDependantAnimation(this Timeline timeline)
	{
		if (timeline.GetIsDurationZero() || !timeline.IsTargetPropertyDependant())
		{
			return false;
		}
		if (timeline.Log().IsEnabled(LogLevel.Debug))
		{
			timeline.Log().Debug("This Dependent animation will not run, EnableDependentAnimation is set to false");
		}
		return true;
	}

	internal static bool GetIsHardwareAnimated(this Timeline timeline)
	{
		if (!timeline.GetIsDependantAnimation())
		{
			return !timeline.GetIsDurationZero();
		}
		return false;
	}
}

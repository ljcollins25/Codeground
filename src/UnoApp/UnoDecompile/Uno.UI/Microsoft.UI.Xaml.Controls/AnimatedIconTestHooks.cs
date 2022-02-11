using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls;

internal class AnimatedIconTestHooks
{
	internal static TypedEventHandler<AnimatedIcon, object> LastAnimationSegmentChanged;

	internal static void SetAnimationQueueBehavior(AnimatedIcon animatedIcon, AnimatedIconAnimationQueueBehavior behavior)
	{
		animatedIcon?.SetAnimationQueueBehavior(behavior);
	}

	internal static void SetDurationMultiplier(AnimatedIcon animatedIcon, float multiplier)
	{
		animatedIcon?.SetDurationMultiplier(multiplier);
	}

	internal static void SetSpeedUpMultiplier(AnimatedIcon animatedIcon, float multiplier)
	{
		animatedIcon?.SetSpeedUpMultiplier(multiplier);
	}

	internal static void SetQueueLength(AnimatedIcon animatedIcon, int length)
	{
		animatedIcon?.SetQueueLength(length);
	}

	internal static string GetLastAnimationSegment(AnimatedIcon animatedIcon)
	{
		if (animatedIcon != null)
		{
			return animatedIcon.GetLastAnimationSegment();
		}
		return "";
	}

	internal static string GetLastAnimationSegmentStart(AnimatedIcon animatedIcon)
	{
		if (animatedIcon != null)
		{
			return animatedIcon.GetLastAnimationSegmentStart();
		}
		return "";
	}

	internal static string GetLastAnimationSegmentEnd(AnimatedIcon animatedIcon)
	{
		if (animatedIcon != null)
		{
			return animatedIcon.GetLastAnimationSegmentEnd();
		}
		return "";
	}

	internal static void NotifyLastAnimationSegmentChanged(AnimatedIcon sender)
	{
		LastAnimationSegmentChanged?.Invoke(sender, null);
	}
}

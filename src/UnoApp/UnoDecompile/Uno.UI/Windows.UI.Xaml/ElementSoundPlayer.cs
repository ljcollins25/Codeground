using System;
using Uno;
using Uno.UI.Xaml.Core;

namespace Windows.UI.Xaml;

public class ElementSoundPlayer
{
	public static double Volume
	{
		get
		{
			return ElementSoundPlayerService.Instance.Volume;
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value", "Volume value must be between 0.0 and 1.0");
			}
			ElementSoundPlayerService.Instance.Volume = value;
		}
	}

	public static ElementSoundPlayerState State
	{
		get
		{
			return ElementSoundPlayerService.Instance.PlayerState;
		}
		set
		{
			ElementSoundPlayerService.Instance.PlayerState = value;
		}
	}

	public static ElementSpatialAudioMode SpatialAudioMode
	{
		get
		{
			return ElementSoundPlayerService.Instance.SpatialAudioMode;
		}
		set
		{
			ElementSoundPlayerService.Instance.SpatialAudioMode = value;
		}
	}

	[NotImplemented]
	public static void Play(ElementSoundKind sound)
	{
		ElementSoundPlayerService.Instance.Play(sound);
	}

	internal static void RequestInteractionSoundForElement(ElementSoundKind soundToPlay, DependencyObject element)
	{
		ElementSoundPlayerService.Instance.RequestInteractionSoundForElement(soundToPlay, element);
	}
}

using System;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Core;

internal class ElementSoundPlayerService
{
	private static readonly Lazy<ElementSoundPlayerService> _instance = new Lazy<ElementSoundPlayerService>(() => new ElementSoundPlayerService());

	private double _volume = 1.0;

	private ElementSoundPlayerState _playerState;

	private ElementSpatialAudioMode _spatialAudioMode;

	internal static ElementSoundPlayerService Instance => _instance.Value;

	internal double Volume
	{
		get
		{
			return _volume;
		}
		set
		{
			if (_volume != value)
			{
				_volume = value;
			}
		}
	}

	internal ElementSoundPlayerState PlayerState
	{
		get
		{
			return _playerState;
		}
		set
		{
			if (_playerState != value)
			{
				_playerState = value;
			}
		}
	}

	public ElementSpatialAudioMode SpatialAudioMode
	{
		get
		{
			return _spatialAudioMode;
		}
		set
		{
			if (_spatialAudioMode != value)
			{
				_spatialAudioMode = value;
			}
		}
	}

	internal void Play(ElementSoundKind sound)
	{
	}

	internal static ElementSoundMode GetEffectiveSoundMode(DependencyObject? dependencyObject)
	{
		return ElementSoundMode.Off;
	}

	internal void RequestInteractionSoundForElement(ElementSoundKind soundKind, DependencyObject? dependencyObject)
	{
	}

	internal static void RequestInteractionSoundForElementStatic(ElementSoundKind soundKind, DependencyObject? dependencyObject)
	{
	}
}

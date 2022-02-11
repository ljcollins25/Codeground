using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls.AnimatedVisuals;

public class AnimatedGlobalNavigationButtonVisualSource : IAnimatedVisualSource2, IAnimatedVisualSource
{
	public IReadOnlyDictionary<string, double> Markers => new Dictionary<string, double>();

	public void Load()
	{
	}

	public Size Measure(Size availableSize)
	{
		return availableSize;
	}

	public void Pause()
	{
	}

	public void Play(double fromProgress, double toProgress, bool looped)
	{
	}

	public void Resume()
	{
	}

	public void SetColorProperty(string propertyName, Color value)
	{
	}

	public void SetProgress(double progress)
	{
	}

	public void Stop()
	{
	}

	public void Unload()
	{
	}

	public void Update(AnimatedVisualPlayer player)
	{
	}

	public IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor, out object diagnostics)
	{
		diagnostics = new object();
		return null;
	}
}

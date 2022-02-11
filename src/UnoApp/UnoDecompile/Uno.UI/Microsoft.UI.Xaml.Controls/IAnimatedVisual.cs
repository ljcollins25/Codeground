using System;
using System.Numerics;
using Windows.UI.Composition;

namespace Microsoft.UI.Xaml.Controls;

public interface IAnimatedVisual : IDisposable
{
	Visual RootVisual { get; }

	Vector2 Size { get; }

	TimeSpan Duration { get; }
}

using System;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public interface ILottieVisualSourceProvider
{
	IAnimatedVisualSource CreateFromLottieAsset(Uri sourceFile);

	IThemableAnimatedVisualSource CreateTheamableFromLottieAsset(Uri sourceFile);

	bool TryCreateThemableFromAnimatedVisualSource(IAnimatedVisualSource animatedVisualSource, out IThemableAnimatedVisualSource themableAnimatedVisualSource);
}

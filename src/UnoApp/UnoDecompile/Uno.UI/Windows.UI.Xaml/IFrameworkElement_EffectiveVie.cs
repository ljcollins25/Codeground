using System;

namespace Windows.UI.Xaml;

internal interface IFrameworkElement_EffectiveViewport
{
	void InitializeEffectiveViewport();

	IDisposable RequestViewportUpdates(bool isInternal, IFrameworkElement_EffectiveViewport? child = null);

	void OnParentViewportChanged(bool isInitial, bool isInternal, IFrameworkElement_EffectiveViewport parent, ViewportInfo viewport);

	void OnLayoutUpdated();
}

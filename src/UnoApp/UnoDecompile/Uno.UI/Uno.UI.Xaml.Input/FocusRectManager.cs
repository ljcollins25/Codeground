using Uno.Foundation.Logging;
using Uno.UI.Xaml.Controls;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Core.Rendering;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class FocusRectManager
{
	private SystemFocusVisual? _focusVisual;

	[NotImplemented]
	internal void OnFocusedElementKeyPressed()
	{
	}

	[NotImplemented]
	internal void OnFocusedElementKeyReleased()
	{
	}

	internal static bool AreHighVisibilityFocusRectsEnabled()
	{
		return Application.Current.FocusVisualKind != FocusVisualKind.DottedLine;
	}

	internal static bool AreRevealFocusRectsEnabled()
	{
		return Application.Current.FocusVisualKind == FocusVisualKind.Reveal;
	}

	internal void RenderFocusRectForElement(UIElement element, IContentRenderer? contentRenderer)
	{
		AreHighVisibilityFocusRectsEnabled();
	}

	internal void ReleaseResources(bool isDeviceLost, bool cleanupDComp, bool clearPCData)
	{
	}

	internal void UpdateFocusRect(DependencyObject? focusedElement, DependencyObject? focusTarget, FocusNavigationDirection focusNavigationDirection, bool cleanOnly)
	{
		Canvas canvas = (CoreServices.Instance.ContentRootCoordinator.CoreWindowContentRoot?.VisualTree)?.FocusVisualRoot;
		if (canvas == null)
		{
			return;
		}
		if (_focusVisual == null)
		{
			canvas.Children.Add(_focusVisual = new SystemFocusVisual());
		}
		if (focusedElement is FrameworkElement frameworkElement && frameworkElement.FocusState == FocusState.Keyboard && frameworkElement.UseSystemFocusVisuals)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Showing focus rect for {focusedElement?.GetType().Name} and state {(focusedElement as UIElement)?.FocusState} and uses system focus visuals {(focusedElement as UIElement)?.UseSystemFocusVisuals}");
			}
			_focusVisual!.FocusedElement = (focusedElement as FrameworkElement) ?? frameworkElement;
			_focusVisual!.Visibility = Visibility.Visible;
		}
		else
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug("Hiding focus rect");
			}
			_focusVisual!.FocusedElement = null;
			_focusVisual!.Visibility = Visibility.Collapsed;
		}
	}

	internal void RedrawFocusVisual()
	{
		_focusVisual?.Redraw();
	}
}

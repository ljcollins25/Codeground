using System;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Input;

internal class FocusedElementRemovedEventArgs : EventArgs
{
	public DependencyObject? OldFocusedElement { get; }

	public DependencyObject? NewFocusedElement { get; set; }

	public FocusedElementRemovedEventArgs(DependencyObject? focusedElement, DependencyObject? currentNextFocusableElement)
	{
		OldFocusedElement = focusedElement;
		NewFocusedElement = currentNextFocusableElement;
	}
}

using System;

namespace Windows.UI.Xaml.Input;

public class FocusManagerGotFocusEventArgs
{
	public DependencyObject? NewFocusedElement { get; internal set; }

	public Guid CorrelationId { get; internal set; }

	internal FocusManagerGotFocusEventArgs(DependencyObject? newFocusedElement, Guid correlationId)
	{
		NewFocusedElement = newFocusedElement;
		CorrelationId = correlationId;
	}
}

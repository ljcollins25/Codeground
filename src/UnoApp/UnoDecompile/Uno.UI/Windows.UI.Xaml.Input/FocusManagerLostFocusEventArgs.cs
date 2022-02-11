using System;

namespace Windows.UI.Xaml.Input;

public class FocusManagerLostFocusEventArgs
{
	public DependencyObject? OldFocusedElement { get; internal set; }

	public Guid CorrelationId { get; internal set; }

	internal FocusManagerLostFocusEventArgs(DependencyObject? oldFocusedElement, Guid correlationId)
	{
		OldFocusedElement = oldFocusedElement;
		CorrelationId = correlationId;
	}
}

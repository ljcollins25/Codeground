using System;

namespace Windows.UI.Xaml;

internal class DependencyObjectParentChangedEventArgs : EventArgs
{
	public object NewParent { get; }

	public object PreviousParent { get; }

	public DependencyObjectParentChangedEventArgs(object previousParent, object newParent)
	{
		PreviousParent = previousParent;
		NewParent = newParent;
	}
}

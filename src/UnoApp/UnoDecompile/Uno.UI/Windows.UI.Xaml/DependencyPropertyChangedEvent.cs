using System;

namespace Windows.UI.Xaml;

public class DependencyPropertyChangedEventArgs : EventArgs
{
	public object NewValue { get; private set; }

	public object OldValue { get; private set; }

	internal DependencyPropertyValuePrecedences NewPrecedence { get; private set; }

	internal DependencyPropertyValuePrecedences OldPrecedence { get; private set; }

	internal bool BypassesPropagation { get; private set; }

	public DependencyProperty Property { get; }

	internal DependencyPropertyChangedEventArgs(DependencyProperty property, object oldValue, DependencyPropertyValuePrecedences oldPrecedence, object newValue, DependencyPropertyValuePrecedences newPrecedence, bool bypassesPropagation = false)
	{
		Property = property;
		OldValue = oldValue;
		OldPrecedence = oldPrecedence;
		NewValue = newValue;
		NewPrecedence = newPrecedence;
		BypassesPropagation = bypassesPropagation;
	}
}
public delegate void DependencyPropertyChangedEventHandler(object sender, DependencyPropertyChangedEventArgs e);

using Uno;

namespace Windows.UI.Xaml.Data;

public enum UpdateSourceTrigger
{
	Default,
	PropertyChanged,
	Explicit,
	[NotImplemented]
	LostFocus
}

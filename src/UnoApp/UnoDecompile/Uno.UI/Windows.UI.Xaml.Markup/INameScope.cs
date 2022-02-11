using System.ComponentModel;

namespace Windows.UI.Xaml.Markup;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface INameScope
{
	DependencyObject Owner { get; }

	object FindName(string name);

	void RegisterName(string name, object scopedElement);

	void UnregisterName(string name);
}

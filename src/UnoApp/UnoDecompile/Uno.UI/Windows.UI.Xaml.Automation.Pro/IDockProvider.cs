using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IDockProvider
{
	DockPosition DockPosition { get; }

	void SetDockPosition(DockPosition dockPosition);
}

using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IDropTargetProvider
{
	string DropEffect { get; }

	string[] DropEffects { get; }
}

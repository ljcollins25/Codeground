using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ISynchronizedInputProvider
{
	void Cancel();

	void StartListening(SynchronizedInputType inputType);
}

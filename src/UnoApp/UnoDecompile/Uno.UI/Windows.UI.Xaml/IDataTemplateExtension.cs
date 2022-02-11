using Uno;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml;

[NotImplemented]
public interface IDataTemplateExtension
{
	void ResetTemplate();

	bool ProcessBinding(uint phase);

	int ProcessBindings(ContainerContentChangingEventArgs arg);
}

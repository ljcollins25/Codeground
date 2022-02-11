using Uno;

namespace Windows.UI.Xaml.Markup;

[NotImplemented]
public interface IDataTemplateComponent
{
	void Recycle();

	void ProcessBindings(object item, int itemIndex, int phase, out int nextPhase);
}

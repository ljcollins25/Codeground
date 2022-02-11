using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ISpreadsheetItemProvider
{
	string Formula { get; }

	IRawElementProviderSimple[] GetAnnotationObjects();

	AnnotationType[] GetAnnotationTypes();
}

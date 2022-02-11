using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IAnnotationProvider
{
	int AnnotationTypeId { get; }

	string AnnotationTypeName { get; }

	string Author { get; }

	string DateTime { get; }

	IRawElementProviderSimple Target { get; }
}

using System;
using Uno;

namespace Windows.UI.Xaml.Markup;

[NotImplemented]
public interface IXamlMetadataProvider
{
	IXamlType GetXamlType(Type type);

	IXamlType GetXamlType(string fullName);

	XmlnsDefinition[] GetXmlnsDefinitions();
}

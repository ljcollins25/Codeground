using System.Collections.Generic;
using Uno.Xaml;

namespace Windows.UI.Xaml.Markup.Reader;

internal class XamlFileDefinition
{
	public List<NamespaceDeclaration> Namespaces { get; private set; }

	public List<XamlObjectDefinition> Objects { get; private set; }

	public XamlFileDefinition()
	{
		Namespaces = new List<NamespaceDeclaration>();
		Objects = new List<XamlObjectDefinition>();
	}
}

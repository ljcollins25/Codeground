using System.Collections.Generic;
using Uno.Xaml;

namespace Windows.UI.Xaml.Markup.Reader;

internal class XamlMemberDefinition
{
	private XamlMember _xamlMember;

	public XamlMember Member => _xamlMember;

	public object Value { get; set; }

	public List<XamlObjectDefinition> Objects { get; private set; }

	public int LineNumber { get; private set; }

	public int LinePosition { get; set; }

	public XamlObjectDefinition Owner { get; }

	public XamlMemberDefinition(XamlMember xamlMember, int lineNumber, int linePosition, XamlObjectDefinition owner = null)
	{
		if (xamlMember.DeclaringType == null && owner != null && xamlMember.PreferredXamlNamespace != "http://schemas.microsoft.com/winfx/2006/xaml")
		{
			xamlMember = new XamlMember(xamlMember.Name, owner.Type, xamlMember.IsAttachable);
		}
		_xamlMember = xamlMember;
		LineNumber = lineNumber;
		LinePosition = linePosition;
		Objects = new List<XamlObjectDefinition>();
		Owner = owner;
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Uno.Extensions;
using Uno.Xaml;

namespace Windows.UI.Xaml.Markup.Reader;

internal class XamlStringParser
{
	private int _depth;

	public XamlFileDefinition Parse(string content)
	{
		XmlReader xmlReader = XmlReader.Create(new StringReader(content));
		XamlSchemaContext schemaContext = new XamlSchemaContext(Enumerable.Empty<Assembly>());
		XamlXmlReaderSettings settings = new XamlXmlReaderSettings
		{
			ProvideLineInfo = true
		};
		using (XamlXmlReader xamlXmlReader = new XamlXmlReader(xmlReader, schemaContext, settings))
		{
			if (xamlXmlReader.Read())
			{
				return Visit(xamlXmlReader);
			}
		}
		return null;
	}

	private XamlFileDefinition Visit(XamlXmlReader reader)
	{
		WriteState(reader);
		XamlFileDefinition xamlFileDefinition = new XamlFileDefinition();
		do
		{
			switch (reader.NodeType)
			{
			case XamlNodeType.StartObject:
				_depth++;
				xamlFileDefinition.Objects.Add(VisitObject(reader, null));
				break;
			case XamlNodeType.NamespaceDeclaration:
				xamlFileDefinition.Namespaces.Add(reader.Namespace);
				break;
			default:
				throw new InvalidOperationException();
			}
		}
		while (reader.Read());
		return xamlFileDefinition;
	}

	private void WriteState(XamlXmlReader reader)
	{
	}

	private XamlObjectDefinition VisitObject(XamlXmlReader reader, XamlObjectDefinition owner)
	{
		XamlObjectDefinition xamlObjectDefinition = new XamlObjectDefinition(reader.Type, reader.LineNumber, reader.LinePosition, owner);
		Visit(reader, xamlObjectDefinition);
		return xamlObjectDefinition;
	}

	private void Visit(XamlXmlReader reader, XamlObjectDefinition xamlObject)
	{
		while (reader.Read())
		{
			WriteState(reader);
			switch (reader.NodeType)
			{
			case XamlNodeType.StartMember:
				_depth++;
				xamlObject.Members.Add(VisitMember(reader, xamlObject));
				break;
			case XamlNodeType.StartObject:
				_depth++;
				xamlObject.Objects.Add(VisitObject(reader, xamlObject));
				break;
			case XamlNodeType.Value:
				xamlObject.Value = reader.Value;
				break;
			case XamlNodeType.EndObject:
				_depth--;
				return;
			case XamlNodeType.EndMember:
				_depth--;
				break;
			default:
				throw new InvalidOperationException();
			}
		}
	}

	private XamlMemberDefinition VisitMember(XamlXmlReader reader, XamlObjectDefinition owner)
	{
		XamlMemberDefinition xamlMemberDefinition = new XamlMemberDefinition(reader.Member, reader.LineNumber, reader.LinePosition, owner);
		while (reader.Read())
		{
			WriteState(reader);
			switch (reader.NodeType)
			{
			case XamlNodeType.EndMember:
				_depth--;
				return xamlMemberDefinition;
			case XamlNodeType.Value:
				if (IsLiteralInlineText(reader.Value, xamlMemberDefinition, owner))
				{
					XamlObjectDefinition item = ConvertLiteralInlineTextToRun(reader);
					xamlMemberDefinition.Objects.Add(item);
				}
				else
				{
					xamlMemberDefinition.Value = reader.Value;
				}
				break;
			case XamlNodeType.StartObject:
				_depth++;
				xamlMemberDefinition.Objects.Add(VisitObject(reader, owner));
				break;
			case XamlNodeType.EndObject:
				_depth--;
				break;
			default:
				throw new InvalidOperationException("Unable to process {2} node at Line {0}, position {1}".InvariantCultureFormat(reader.LineNumber, reader.LinePosition, reader.NodeType));
			case XamlNodeType.NamespaceDeclaration:
				break;
			}
		}
		return xamlMemberDefinition;
	}

	private bool IsLiteralInlineText(object value, XamlMemberDefinition member, XamlObjectDefinition xamlObject)
	{
		if (value is string && (xamlObject.Type.Name == "TextBlock" || xamlObject.Type.Name == "Bold" || xamlObject.Type.Name == "Hyperlink" || xamlObject.Type.Name == "Italic" || xamlObject.Type.Name == "Underline"))
		{
			if (!(member.Member.Name == "_UnknownContent"))
			{
				return member.Member.Name == "Inlines";
			}
			return true;
		}
		return false;
	}

	private XamlObjectDefinition ConvertLiteralInlineTextToRun(XamlXmlReader reader)
	{
		XamlType xamlType = new XamlType("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Run", new List<XamlType>(), new XamlSchemaContext());
		XamlMember xamlMember = new XamlMember("Text", xamlType, isAttachable: false);
		return new XamlObjectDefinition(xamlType, reader.LineNumber, reader.LinePosition, null)
		{
			Members = 
			{
				new XamlMemberDefinition(xamlMember, reader.LineNumber, reader.LinePosition)
				{
					Value = reader.Value
				}
			}
		};
	}
}

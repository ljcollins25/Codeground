using Windows.UI.Xaml.Markup.Reader;

namespace Windows.UI.Xaml.Markup;

public class XamlReader
{
	public static object Load(string xaml)
	{
		XamlStringParser xamlStringParser = new XamlStringParser();
		XamlObjectBuilder xamlObjectBuilder = new XamlObjectBuilder(xamlStringParser.Parse(xaml));
		return xamlObjectBuilder.Build();
	}

	public static object LoadWithInitialTemplateValidation(string xaml)
	{
		return Load(xaml);
	}

	internal static object LoadUsingXClass(string xaml)
	{
		XamlStringParser xamlStringParser = new XamlStringParser();
		XamlObjectBuilder xamlObjectBuilder = new XamlObjectBuilder(xamlStringParser.Parse(xaml));
		return xamlObjectBuilder.Build(null, createInstanceFromXClass: true);
	}

	internal static void LoadUsingComponent(string xaml, object component)
	{
		XamlStringParser xamlStringParser = new XamlStringParser();
		XamlObjectBuilder xamlObjectBuilder = new XamlObjectBuilder(xamlStringParser.Parse(xaml));
		xamlObjectBuilder.Build(component);
	}
}

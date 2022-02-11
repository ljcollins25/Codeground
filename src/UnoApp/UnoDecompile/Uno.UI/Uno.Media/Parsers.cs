using Windows.UI.Xaml.Media;

namespace Uno.Media;

internal static class Parsers
{
	internal static Geometry ParseGeometry(string pathString)
	{
		FillRule fillRule = FillRule.EvenOdd;
		StreamGeometry streamGeometry = new StreamGeometry();
		using (StreamGeometryContext context = streamGeometry.Open())
		{
			PathMarkupParser pathMarkupParser = new PathMarkupParser(context);
			pathMarkupParser.Parse(pathString, ref fillRule);
		}
		streamGeometry.FillRule = fillRule;
		return streamGeometry;
	}
}

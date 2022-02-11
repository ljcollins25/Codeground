using System;
using Uno.Extensions;
using Windows.UI.Xaml.Media;

namespace Uno.Media;

public static class GeometryHelper
{
	private static Func<(Action<StreamGeometryContext>, FillRule), StreamGeometry> _build = CachedBuild;

	public static StreamGeometry Build(Action<StreamGeometryContext> contextAction)
	{
		return Build(contextAction, FillRule.EvenOdd);
	}

	public static StreamGeometry Build(Action<StreamGeometryContext> contextAction, FillRule fillRule)
	{
		return _build.AsWeakMemoized((contextAction, fillRule))();
	}

	private static StreamGeometry CachedBuild((Action<StreamGeometryContext> contextAction, FillRule fillRule) p)
	{
		StreamGeometry streamGeometry = new StreamGeometry();
		using (StreamGeometryContext obj = streamGeometry.Open())
		{
			p.contextAction(obj);
		}
		streamGeometry.FillRule = p.fillRule;
		return streamGeometry;
	}
}

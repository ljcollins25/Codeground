using System.ComponentModel;
using Windows.UI.Xaml.Media;

namespace Uno.Media;

[TypeConverter(typeof(GeometryConverter))]
public sealed class StreamGeometry : Geometry
{
	private object bezierPath;

	public FillRule FillRule { get; set; }

	public StreamGeometryContext Open()
	{
		return new PathStreamGeometryContext(this);
	}

	internal void Close(object bezierPath_)
	{
		bezierPath = bezierPath_;
	}

	public override void Dispose()
	{
	}
}

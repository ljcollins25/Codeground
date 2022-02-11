using System;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

public class GeometryData : Geometry
{
	private readonly SvgElement _svgElement = new SvgElement("path");

	public string Data { get; }

	public FillRule FillRule { get; }

	public GeometryData()
	{
	}

	public GeometryData(string data)
	{
		if (data.StartsWith("F", StringComparison.InvariantCultureIgnoreCase) && data.Length > 2)
		{
			FillRule = ((data[1] == '1') ? FillRule.Nonzero : FillRule.EvenOdd);
			Data = data.Substring(2);
		}
		else
		{
			Data = data;
		}
		_svgElement.SetAttribute("d", Data);
		FillRule fillRule = FillRule;
		_svgElement.SetAttribute("fill-rule", fillRule switch
		{
			FillRule.EvenOdd => "evenodd", 
			FillRule.Nonzero => "nonzero", 
			_ => "evenodd", 
		});
	}

	internal override SvgElement GetSvgElement()
	{
		return _svgElement;
	}
}

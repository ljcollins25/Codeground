using System.Collections.Generic;
using System.Linq;
using Uno;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

public class Polygon : ArbitraryShapeBase
{
	private readonly SvgElement _polygon = new SvgElement("polygon");

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FillRule FillRule
	{
		get
		{
			return (FillRule)GetValue(FillRuleProperty);
		}
		set
		{
			SetValue(FillRuleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FillRuleProperty { get; } = DependencyProperty.Register("FillRule", typeof(FillRule), typeof(Polygon), new FrameworkPropertyMetadata(FillRule.EvenOdd));


	public PointCollection Points
	{
		get
		{
			return (PointCollection)GetValue(PointsProperty);
		}
		set
		{
			SetValue(PointsProperty, value);
		}
	}

	public static DependencyProperty PointsProperty { get; } = DependencyProperty.Register("Points", typeof(PointCollection), typeof(Polygon), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.LogicalChild | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		Polygon polygon = (Polygon)s;
		polygon.OnPointsChanged();
		(e.OldValue as PointCollection)?.UnRegisterChangedListener(polygon.OnPointsChanged);
		(e.NewValue as PointCollection)?.RegisterChangedListener(polygon.OnPointsChanged);
	}));


	public Polygon()
	{
		Points = new PointCollection();
		InitializePartial();
	}

	private void InitializePartial()
	{
		base.SvgChildren.Add(_polygon);
		InitCommonShapeProperties();
	}

	private void OnPointsChanged()
	{
		PointCollection points = Points;
		if (points == null)
		{
			_polygon.RemoveAttribute("points");
		}
		else
		{
			_polygon.SetAttribute("points", points.ToCssString());
		}
	}

	protected internal override IEnumerable<object> GetShapeParameters()
	{
		yield return Points?.ToArray();
		foreach (object shapeParameter in base.GetShapeParameters())
		{
			yield return shapeParameter;
		}
	}

	protected override SvgElement GetMainSvgElement()
	{
		return _polygon;
	}
}

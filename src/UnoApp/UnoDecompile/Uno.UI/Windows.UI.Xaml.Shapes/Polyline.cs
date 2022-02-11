using System.Collections.Generic;
using System.Linq;
using Uno;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

public class Polyline : ArbitraryShapeBase
{
	private readonly SvgElement _polyline = new SvgElement("polyline");

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
	public static DependencyProperty FillRuleProperty { get; } = DependencyProperty.Register("FillRule", typeof(FillRule), typeof(Polyline), new FrameworkPropertyMetadata(FillRule.EvenOdd));


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

	public static DependencyProperty PointsProperty { get; } = DependencyProperty.Register("Points", typeof(PointCollection), typeof(Polyline), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.LogicalChild | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		Polyline polyline = (Polyline)s;
		polyline.OnPointsChanged();
		(e.OldValue as PointCollection)?.UnRegisterChangedListener(polyline.OnPointsChanged);
		(e.NewValue as PointCollection)?.RegisterChangedListener(polyline.OnPointsChanged);
	}));


	public Polyline()
	{
		Points = new PointCollection();
		InitializePartial();
	}

	private void InitializePartial()
	{
		base.SvgChildren.Add(_polyline);
		InitCommonShapeProperties();
	}

	private void OnPointsChanged()
	{
		PointCollection points = Points;
		if (points == null)
		{
			_polyline.RemoveAttribute("points");
		}
		else
		{
			_polyline.SetAttribute("points", points.ToCssString());
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
		return _polyline;
	}
}

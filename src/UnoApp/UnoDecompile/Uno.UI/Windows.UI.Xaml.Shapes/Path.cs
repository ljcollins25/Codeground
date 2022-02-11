using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

public class Path : ArbitraryShapeBase
{
	private readonly SvgElement _root = new SvgElement("g");

	public Geometry? Data
	{
		get
		{
			return (Geometry)GetValue(DataProperty);
		}
		set
		{
			SetValue(DataProperty, value);
		}
	}

	public static DependencyProperty DataProperty { get; } = DependencyProperty.Register("Data", typeof(Geometry), typeof(Path), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext | FrameworkPropertyMetadataOptions.LogicalChild | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Path)s).OnDataChanged();
	}));


	private void OnDataChanged()
	{
		InvalidateMeasure();
	}

	protected internal override IEnumerable<object?> GetShapeParameters()
	{
		Geometry data = Data;
		if (data != null)
		{
			yield return data;
		}
		foreach (object shapeParameter in base.GetShapeParameters())
		{
			yield return shapeParameter;
		}
	}

	public Path()
	{
		base.SvgChildren.Add(_root);
		InitCommonShapeProperties();
	}

	protected override SvgElement GetMainSvgElement()
	{
		return _root;
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		DependencyProperty property = args.Property;
		if (property == DataProperty)
		{
			_root.ClearChildren();
			Geometry data = Data;
			if (data != null)
			{
				_root.AddChild(data.GetSvgElement());
			}
		}
	}

	protected override void InvalidateShape()
	{
		Data?.Invalidate();
	}
}

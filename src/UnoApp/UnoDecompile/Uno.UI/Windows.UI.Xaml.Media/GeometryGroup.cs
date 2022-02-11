using System;
using System.Globalization;
using System.Text;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

[ContentProperty(Name = "Children")]
public class GeometryGroup : Geometry
{
	private class CompositeFormattable : IFormattable
	{
		private readonly GeometryGroup _owner;

		public CompositeFormattable(GeometryGroup owner)
		{
			_owner = owner;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Geometry child in _owner.Children)
			{
				IFormattable formattable = child.ToPathData();
				stringBuilder.Append(formattable.ToString(format, formatProvider));
			}
			return stringBuilder.ToString();
		}
	}

	private SvgElement? _svgElement;

	private CompositeFormattable _compositeFormattable;

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

	public static DependencyProperty FillRuleProperty { get; } = DependencyProperty.Register("FillRule", typeof(FillRule), typeof(GeometryGroup), new FrameworkPropertyMetadata((object)FillRule.EvenOdd, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, (PropertyChangedCallback)delegate
	{
	}));


	public GeometryCollection Children
	{
		get
		{
			return (GeometryCollection)GetValue(ChildrenProperty);
		}
		set
		{
			SetValue(ChildrenProperty, value);
		}
	}

	public static DependencyProperty ChildrenProperty { get; } = DependencyProperty.Register("Children", typeof(GeometryCollection), typeof(GeometryGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext | FrameworkPropertyMetadataOptions.LogicalChild | FrameworkPropertyMetadataOptions.AffectsMeasure));


	public GeometryGroup()
	{
		Children = new GeometryCollection();
		InitPartials();
	}

	private void InitPartials()
	{
		this.RegisterDisposablePropertyChangedCallback(OnPropertyChanged);
		Children.VectorChanged += OnGeometriesChanged;
	}

	private protected override Rect ComputeBounds()
	{
		Rect? rect = null;
		foreach (Geometry child in Children)
		{
			if (rect.HasValue)
			{
				Rect valueOrDefault = rect.GetValueOrDefault();
				rect = valueOrDefault.UnionWith(child.Bounds);
			}
			else
			{
				rect = child.Bounds;
			}
		}
		if (rect.HasValue)
		{
			Rect valueOrDefault2 = rect.GetValueOrDefault();
			return base.Transform?.TransformBounds(valueOrDefault2) ?? valueOrDefault2;
		}
		return default(Rect);
	}

	private void OnPropertyChanged(ManagedWeakReference? instance, DependencyProperty property, DependencyPropertyChangedEventArgs? args)
	{
		if (_svgElement == null)
		{
			return;
		}
		if (property == FillRuleProperty)
		{
			FillRule fillRule = FillRule;
			_svgElement!.SetAttribute("fill-rule", fillRule switch
			{
				FillRule.EvenOdd => "evenodd", 
				FillRule.Nonzero => "nonzero", 
				_ => "evenodd", 
			});
		}
		else
		{
			if (property != ChildrenProperty)
			{
				return;
			}
			_svgElement!.ClearChildren();
			if (args?.OldValue is GeometryCollection geometryCollection)
			{
				geometryCollection.VectorChanged -= OnGeometriesChanged;
			}
			if (!((args?.NewValue ?? Children) is GeometryCollection geometryCollection2))
			{
				return;
			}
			geometryCollection2.VectorChanged += OnGeometriesChanged;
			geometryCollection2.SetParent(this);
			foreach (Geometry item in geometryCollection2)
			{
				_svgElement!.AddChild(item.GetSvgElement());
			}
		}
	}

	internal override void Invalidate()
	{
		string value = ToPathData().ToString(null, CultureInfo.InvariantCulture);
		GetSvgElement().SetAttribute("d", value);
	}

	private void OnGeometriesChanged(IObservableVector<Geometry> sender, IVectorChangedEventArgs e)
	{
		Invalidate();
	}

	internal override SvgElement GetSvgElement()
	{
		if (_svgElement == null)
		{
			_svgElement = new SvgElement("path");
			OnPropertyChanged(null, FillRuleProperty, null);
			OnPropertyChanged(null, ChildrenProperty, null);
		}
		return _svgElement;
	}

	internal override IFormattable ToPathData()
	{
		return _compositeFormattable ?? (_compositeFormattable = new CompositeFormattable(this));
	}
}

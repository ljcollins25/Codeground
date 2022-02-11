using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

[ContentProperty(Name = "Figures")]
public class PathGeometry : Geometry
{
	private readonly SvgElement _svgElement = new SvgElement("path");

	public static DependencyProperty FillRuleProperty { get; } = DependencyProperty.Register("FillRule", typeof(FillRule), typeof(PathGeometry), new FrameworkPropertyMetadata(FillRule.EvenOdd, FrameworkPropertyMetadataOptions.AffectsRender));


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

	public PathFigureCollection Figures
	{
		get
		{
			return (PathFigureCollection)GetValue(FiguresProperty);
		}
		set
		{
			SetValue(FiguresProperty, value);
		}
	}

	public static DependencyProperty FiguresProperty { get; } = DependencyProperty.Register("Figures", typeof(PathFigureCollection), typeof(PathGeometry), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext | FrameworkPropertyMetadataOptions.LogicalChild | FrameworkPropertyMetadataOptions.AffectsMeasure));


	public PathGeometry()
	{
		Figures = new PathFigureCollection();
		InitPartials();
	}

	private void InitPartials()
	{
		this.RegisterDisposablePropertyChangedCallback(OnPropertyChanged);
		_svgElement.SetAttribute("fill-rule", "evenodd");
	}

	private void OnPropertyChanged(ManagedWeakReference instance, DependencyProperty property, DependencyPropertyChangedEventArgs args)
	{
		if (property == FiguresProperty)
		{
			if (args.OldValue is PathFigureCollection pathFigureCollection)
			{
				pathFigureCollection.VectorChanged -= OnFiguresVectorChanged;
			}
			if (args.NewValue is PathFigureCollection pathFigureCollection2)
			{
				pathFigureCollection2.VectorChanged += OnFiguresVectorChanged;
			}
			_svgElement.InvalidateMeasure();
		}
		else if (property == FillRuleProperty)
		{
			FillRule fillRule = FillRule;
			_svgElement.SetAttribute("fill-rule", fillRule switch
			{
				FillRule.EvenOdd => "evenodd", 
				FillRule.Nonzero => "nonzero", 
				_ => "evenodd", 
			});
		}
	}

	internal override void Invalidate()
	{
		ComputeAndSetPathData();
	}

	private void OnFiguresVectorChanged(IObservableVector<PathFigure> sender, IVectorChangedEventArgs? args)
	{
		_svgElement.InvalidateMeasure();
	}

	private void ComputeAndSetPathData()
	{
		string value = ToStreamGeometry(Figures);
		_svgElement.SetAttribute("d", value);
	}

	private static string ToStreamGeometry(PathFigureCollection figures)
	{
		PathFigureCollection figures2 = figures;
		if (figures2 == null)
		{
			return "";
		}
		return string.Join(" ", GenerateDataParts().Select(new Func<IFormattable, string>(FormattableExtensions.ToStringInvariant)));
		IEnumerable<IFormattable> GenerateDataParts()
		{
			foreach (PathFigure figure in figures2)
			{
				yield return $"M {figure.StartPoint.X},{figure.StartPoint.Y}";
				foreach (PathSegment segment in figure.Segments)
				{
					foreach (IFormattable item in segment.ToDataStream())
					{
						yield return item;
					}
				}
				if (figure.IsClosed)
				{
					yield return $"Z";
				}
			}
		}
	}

	internal override SvgElement GetSvgElement()
	{
		return _svgElement;
	}

	internal override IFormattable ToPathData()
	{
		return $"{ToStreamGeometry(Figures)}";
	}
}

using System.Collections.Generic;
using Uno.Extensions;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

public class Line : ArbitraryShapeBase
{
	private readonly SvgElement _line = new SvgElement("line");

	public double X1
	{
		get
		{
			return (double)GetValue(X1Property);
		}
		set
		{
			SetValue(X1Property, value);
		}
	}

	public static DependencyProperty X1Property { get; } = DependencyProperty.Register("X1", typeof(double), typeof(Line), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, OnX1PropertyChanged));


	public double X2
	{
		get
		{
			return (double)GetValue(X2Property);
		}
		set
		{
			SetValue(X2Property, value);
		}
	}

	public static DependencyProperty X2Property { get; } = DependencyProperty.Register("X2", typeof(double), typeof(Line), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, OnX2PropertyChanged));


	public double Y1
	{
		get
		{
			return (double)GetValue(Y1Property);
		}
		set
		{
			SetValue(Y1Property, value);
		}
	}

	public static DependencyProperty Y1Property { get; } = DependencyProperty.Register("Y1", typeof(double), typeof(Line), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, OnY1PropertyChanged));


	public double Y2
	{
		get
		{
			return (double)GetValue(Y2Property);
		}
		set
		{
			SetValue(Y2Property, value);
		}
	}

	public static DependencyProperty Y2Property { get; } = DependencyProperty.Register("Y2", typeof(double), typeof(Line), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, OnY2PropertyChanged));


	public Line()
	{
		InitializePartial();
	}

	private void InitializePartial()
	{
		base.SvgChildren.Add(_line);
		InitCommonShapeProperties();
	}

	private static void OnX1PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is Line line)
		{
			line.OnX1PropertyChangedPartial((double)args.OldValue, (double)args.NewValue);
		}
	}

	private void OnX1PropertyChangedPartial(double oldValue, double newValue)
	{
		_line.SetAttribute("x1", newValue.ToStringInvariant());
	}

	private static void OnX2PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is Line line)
		{
			line.OnX2PropertyChangedPartial((double)args.OldValue, (double)args.NewValue);
		}
	}

	private void OnX2PropertyChangedPartial(double oldValue, double newValue)
	{
		_line.SetAttribute("x2", newValue.ToStringInvariant());
	}

	private static void OnY1PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is Line line)
		{
			line.OnY1PropertyChangedPartial((double)args.OldValue, (double)args.NewValue);
		}
	}

	private void OnY1PropertyChangedPartial(double oldValue, double newValue)
	{
		_line.SetAttribute("y1", newValue.ToStringInvariant());
	}

	private static void OnY2PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is Line line)
		{
			line.OnY2PropertyChangedPartial((double)args.OldValue, (double)args.NewValue);
		}
	}

	private void OnY2PropertyChangedPartial(double oldValue, double newValue)
	{
		_line.SetAttribute("y2", newValue.ToStringInvariant());
	}

	protected internal override IEnumerable<object> GetShapeParameters()
	{
		yield return X1;
		yield return X2;
		yield return Y1;
		yield return Y2;
		foreach (object shapeParameter in base.GetShapeParameters())
		{
			yield return shapeParameter;
		}
	}

	protected override SvgElement GetMainSvgElement()
	{
		return _line;
	}
}

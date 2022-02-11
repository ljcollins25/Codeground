using System;
using Windows.Foundation;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Child")]
public class Viewbox : FrameworkElement
{
	private const double SCALE_EPSILON = 1E-05;

	private readonly Border _container;

	public UIElement Child
	{
		get
		{
			return _container.Child;
		}
		set
		{
			_container.Child = value;
		}
	}

	public StretchDirection StretchDirection
	{
		get
		{
			return (StretchDirection)GetValue(StretchDirectionProperty);
		}
		set
		{
			SetValue(StretchDirectionProperty, value);
		}
	}

	public Stretch Stretch
	{
		get
		{
			return (Stretch)GetValue(StretchProperty);
		}
		set
		{
			SetValue(StretchProperty, value);
		}
	}

	public static DependencyProperty StretchDirectionProperty { get; } = DependencyProperty.Register("StretchDirection", typeof(StretchDirection), typeof(Viewbox), new FrameworkPropertyMetadata(StretchDirection.Both, FrameworkPropertyMetadataOptions.AffectsMeasure));


	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(Viewbox), new FrameworkPropertyMetadata(Stretch.Uniform, FrameworkPropertyMetadataOptions.AffectsMeasure));


	public Viewbox()
	{
		base.HorizontalAlignment = HorizontalAlignment.Center;
		base.VerticalAlignment = VerticalAlignment.Center;
		_container = new Border();
		OnChildChangedPartial(null, _container);
	}

	private void OnChildChangedPartial(UIElement previousValue, UIElement newValue)
	{
		if (previousValue != null)
		{
			RemoveChild(previousValue);
		}
		AddChild(newValue);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size desired = base.MeasureOverride(new Size(double.PositiveInfinity, double.PositiveInfinity));
		var (num, num2) = GetScale(availableSize, desired);
		return new Size(Math.Min(availableSize.Width, desired.Width * num), Math.Min(availableSize.Height, desired.Height * num2));
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		if (finalSize.Width == 0.0 || finalSize.Height == 0.0)
		{
			return default(Size);
		}
		var (num, num2) = GetScale(finalSize, _container.DesiredSize);
		if (Math.Abs(num - 1.0) < 1E-05 && Math.Abs(num2 - 1.0) < 1E-05)
		{
			_container.RenderTransform = null;
		}
		else
		{
			ScaleTransform scaleTransform = (_container.RenderTransform as ScaleTransform) ?? new ScaleTransform();
			scaleTransform.ScaleX = num;
			scaleTransform.ScaleY = num2;
			_container.RenderTransform = scaleTransform;
		}
		ArrangeElement(_container, new Rect(default(Point), _container.DesiredSize));
		return finalSize;
	}

	internal (double scaleX, double scaleY) GetScale(Size constraint, Size desired)
	{
		switch (Stretch)
		{
		case Stretch.Uniform:
		{
			double uniformToFillScale2 = ((desired.Width * constraint.Height < desired.Height * constraint.Width) ? (constraint.Height / desired.Height) : (constraint.Width / desired.Width));
			uniformToFillScale2 = AdjustWithDirection(uniformToFillScale2);
			return (uniformToFillScale2, uniformToFillScale2);
		}
		case Stretch.UniformToFill:
		{
			double uniformToFillScale = ((desired.Width * constraint.Height < desired.Height * constraint.Width) ? (constraint.Width / desired.Width) : (constraint.Height / desired.Height));
			uniformToFillScale = AdjustWithDirection(uniformToFillScale);
			return (uniformToFillScale, uniformToFillScale);
		}
		case Stretch.Fill:
			return (AdjustWithDirection(constraint.Width / desired.Width), AdjustWithDirection(constraint.Height / desired.Height));
		default:
			return (1.0, 1.0);
		}
	}

	private double AdjustWithDirection(double uniformToFillScale)
	{
		if (double.IsNaN(uniformToFillScale) || double.IsInfinity(uniformToFillScale))
		{
			return 1.0;
		}
		return StretchDirection switch
		{
			StretchDirection.UpOnly => Math.Max(1.0, uniformToFillScale), 
			StretchDirection.DownOnly => Math.Min(1.0, uniformToFillScale), 
			_ => uniformToFillScale, 
		};
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}
}

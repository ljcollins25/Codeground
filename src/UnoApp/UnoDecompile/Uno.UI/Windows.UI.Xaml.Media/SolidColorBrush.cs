using System;
using Uno.Extensions;

namespace Windows.UI.Xaml.Media;

public class SolidColorBrush : Brush, IEquatable<SolidColorBrush>, IShareableDependencyObject
{
	private readonly bool _isClone;

	internal Color ColorWithOpacity { get; private set; }

	bool IShareableDependencyObject.IsClone => _isClone;

	public Color Color
	{
		get
		{
			return (Color)GetValue(ColorProperty);
		}
		set
		{
			SetValue(ColorProperty, value);
		}
	}

	public static DependencyProperty ColorProperty { get; } = DependencyProperty.Register("Color", typeof(Color), typeof(SolidColorBrush), new FrameworkPropertyMetadata(Colors.Transparent, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SolidColorBrush)s).OnColorChanged((Color)e.OldValue, (Color)e.NewValue);
	}));


	public SolidColorBrush()
	{
		base.IsAutoPropertyInheritanceEnabled = false;
	}

	public SolidColorBrush(Color color)
		: this()
	{
		Color = color;
		UpdateColorWithOpacity(color);
	}

	private SolidColorBrush(SolidColorBrush original)
		: this()
	{
		_isClone = true;
		Color = original.Color;
		UpdateColorWithOpacity(Color);
		base.Opacity = original.Opacity;
		base.Transform = original.Transform;
		base.RelativeTransform = original.RelativeTransform;
	}

	private void UpdateColorWithOpacity(Color newColor)
	{
		ColorWithOpacity = GetColorWithOpacity(newColor);
	}

	protected override void OnOpacityChanged(double oldValue, double newValue)
	{
		base.OnOpacityChanged(oldValue, newValue);
		UpdateColorWithOpacity(Color);
	}

	private void OnColorChanged(Color oldValue, Color newValue)
	{
		UpdateColorWithOpacity(newValue);
	}

	DependencyObject IShareableDependencyObject.Clone()
	{
		return new SolidColorBrush(this);
	}

	public override string ToString()
	{
		return "[SolidColorBrush {0}]".InvariantCultureFormat(Color);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as SolidColorBrush);
	}

	public bool Equals(SolidColorBrush other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this != other)
		{
			if (ColorWithOpacity.Equals(other.ColorWithOpacity))
			{
				return _isClone == other._isClone;
			}
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		int hashCode = ColorWithOpacity.GetHashCode();
		bool isClone = _isClone;
		return hashCode ^ isClone.GetHashCode();
	}

	public static bool operator ==(SolidColorBrush left, SolidColorBrush right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(SolidColorBrush left, SolidColorBrush right)
	{
		return !object.Equals(left, right);
	}
}

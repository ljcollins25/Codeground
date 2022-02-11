using System;
using System.Numerics;
using Uno.Extensions;
using Windows.Foundation;

namespace Windows.UI.Xaml;

internal struct ViewportInfo : IEquatable<ViewportInfo>
{
	public IFrameworkElement_EffectiveViewport? Reference;

	public Rect Effective;

	public Rect Clip;

	public static ViewportInfo Empty { get; } = new ViewportInfo
	{
		Effective = Rect.Empty,
		Clip = Rect.Empty
	};


	public ViewportInfo(IFrameworkElement_EffectiveViewport reference, Rect viewport)
	{
		Reference = reference;
		Effective = (Clip = viewport);
	}

	public ViewportInfo(IFrameworkElement_EffectiveViewport reference, Rect effective, Rect clip)
	{
		Reference = reference;
		Effective = effective;
		Clip = clip;
	}

	public ViewportInfo GetRelativeTo(IFrameworkElement_EffectiveViewport element)
	{
		Rect effective = Effective;
		Rect clip = Clip;
		if (element is UIElement from && Reference is UIElement to)
		{
			Matrix3x2 matrix = UIElement.GetTransform(from, to).Inverse();
			if (Effective.IsValid)
			{
				effective = matrix.Transform(Effective);
			}
			if (Clip.IsValid)
			{
				clip = matrix.Transform(Clip);
			}
		}
		return new ViewportInfo(element, effective, clip);
	}

	public override string ToString()
	{
		return Effective.ToDebugString() + " (clip: " + Clip.ToDebugString() + ")";
	}

	public override int GetHashCode()
	{
		return Effective.GetHashCode();
	}

	public bool Equals(ViewportInfo other)
	{
		return Equals(this, other);
	}

	public override bool Equals(object? obj)
	{
		if (obj is ViewportInfo right)
		{
			return Equals(this, right);
		}
		return false;
	}

	private static bool Equals(ViewportInfo left, ViewportInfo right)
	{
		return left.Effective.Equals(right.Effective);
	}

	public static bool operator ==(ViewportInfo left, ViewportInfo right)
	{
		return Equals(left, right);
	}

	public static bool operator !=(ViewportInfo left, ViewportInfo right)
	{
		return !Equals(left, right);
	}
}

using System;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Media;

public sealed class NativeRenderTransformAdapter : IDisposable
{
	public UIElement Owner { get; }

	public Transform Transform { get; }

	public Point CurrentOrigin { get; private set; }

	public Size CurrentSize { get; private set; }

	public NativeRenderTransformAdapter(UIElement owner, Transform transform, Point origin)
	{
		Owner = owner;
		Transform = transform;
		CurrentOrigin = origin;
		CurrentSize = ((owner is IFrameworkElement frameworkElement) ? new Size(frameworkElement.ActualWidth, frameworkElement.ActualHeight) : new Size(0.0, 0.0));
		transform.View = owner;
		Initialized();
		Transform.Changed += UpdateOnTransformPropertyChanged;
	}

	private void Initialized()
	{
		Update();
		Apply(isSizeChanged: false, isOriginChanged: true);
	}

	public void UpdateOrigin(Point origin)
	{
		CurrentOrigin = origin;
		Update(isSizeChanged: false, isOriginChanged: true);
	}

	public void UpdateSize(Size size)
	{
		CurrentSize = size;
		Update(isSizeChanged: true);
	}

	private void UpdateOnTransformPropertyChanged(object snd, EventArgs args)
	{
		Update();
	}

	private void Update(bool isSizeChanged = false, bool isOriginChanged = false)
	{
		Apply(isSizeChanged, isOriginChanged);
	}

	private void Apply(bool isSizeChanged, bool isOriginChanged)
	{
		if (!isSizeChanged)
		{
			if (isOriginChanged)
			{
				FormattableString number = $"{(int)(CurrentOrigin.X * 100.0)}% {(int)(CurrentOrigin.Y * 100.0)}%";
				Owner.SetStyle("transform-origin", number.ToStringInvariant());
			}
			else
			{
				Owner.SetNativeTransform(Transform.MatrixCore);
			}
		}
	}

	private void Cleanup()
	{
		Owner.ResetStyle("transform");
	}

	public void Dispose()
	{
		Transform.Changed -= UpdateOnTransformPropertyChanged;
		Cleanup();
	}
}

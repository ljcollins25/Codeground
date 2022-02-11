using System.Numerics;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class MonochromaticOverlayPresenter : Grid
{
	private CompositionEffectFactory _effectFactory;

	private Color _replacementColor;

	private bool _needsBrushUpdate;

	public Color ReplacementColor
	{
		get
		{
			return (Color)GetValue(ReplacementColorProperty);
		}
		set
		{
			SetValue(ReplacementColorProperty, value);
		}
	}

	public static DependencyProperty ReplacementColorProperty { get; } = DependencyProperty.Register("ReplacementColor", typeof(Color), typeof(MonochromaticOverlayPresenter), new FrameworkPropertyMetadata(default(Color), OnPropertyChanged));


	public UIElement SourceElement
	{
		get
		{
			return (UIElement)GetValue(SourceElementProperty);
		}
		set
		{
			SetValue(SourceElementProperty, value);
		}
	}

	public static DependencyProperty SourceElementProperty { get; } = DependencyProperty.Register("SourceElement", typeof(UIElement), typeof(MonochromaticOverlayPresenter), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public MonochromaticOverlayPresenter()
	{
		base.SizeChanged += delegate
		{
			InvalidateBrush();
		};
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		InvalidateBrush();
	}

	private void InvalidateBrush()
	{
		if (!_needsBrushUpdate)
		{
			_needsBrushUpdate = true;
			SharedHelpers.QueueCallbackForCompositionRendering(delegate
			{
				UpdateBrush();
				_needsBrushUpdate = false;
			});
		}
	}

	private void UpdateBrush()
	{
		UIElement sourceElement = SourceElement;
		if (sourceElement != null)
		{
			Color replacementColor = ReplacementColor;
			if (_replacementColor != replacementColor)
			{
				_replacementColor = replacementColor;
				_effectFactory = null;
			}
			Compositor compositor = Window.Current.Compositor;
			_ = _effectFactory;
			Vector2 vector = new Vector2((float)base.ActualWidth, (float)base.ActualHeight);
			GeneralTransform generalTransform = TransformToVisual(sourceElement);
			Point point = generalTransform.TransformPoint(new Point(0.0, 0.0));
			CompositionSurfaceBrush compositionSurfaceBrush = compositor.CreateSurfaceBrush();
			compositionSurfaceBrush.Stretch = CompositionStretch.None;
			CompositionVisualSurface compositionVisualSurface = compositor.CreateVisualSurface();
			compositionVisualSurface.SourceVisual = ElementCompositionPreview.GetElementVisual(sourceElement);
			compositionVisualSurface.SourceOffset = new Vector2((float)point.X, (float)point.Y);
			compositionVisualSurface.SourceSize = vector;
			compositionSurfaceBrush.Surface = compositionVisualSurface;
			compositionSurfaceBrush.Stretch = CompositionStretch.None;
			CompositionEffectBrush compositionEffectBrush = _effectFactory.CreateBrush();
			compositionEffectBrush.SetSourceParameter("source", compositionSurfaceBrush);
			SpriteVisual spriteVisual = compositor.CreateSpriteVisual();
			spriteVisual.Size = vector;
			spriteVisual.Brush = compositionEffectBrush;
			ElementCompositionPreview.SetElementChildVisual(this, spriteVisual);
		}
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is MonochromaticOverlayPresenter monochromaticOverlayPresenter)
		{
			monochromaticOverlayPresenter.OnPropertyChanged(args);
		}
	}
}

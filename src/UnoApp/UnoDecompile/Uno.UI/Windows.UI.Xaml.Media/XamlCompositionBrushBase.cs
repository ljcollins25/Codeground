using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;

namespace Windows.UI.Xaml.Media;

public class XamlCompositionBrushBase : Brush
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CompositionBrush CompositionBrush
	{
		get
		{
			throw new NotImplementedException("The member CompositionBrush XamlCompositionBrushBase.CompositionBrush is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.XamlCompositionBrushBase", "CompositionBrush XamlCompositionBrushBase.CompositionBrush");
		}
	}

	public Color FallbackColor
	{
		get
		{
			return (Color)GetValue(FallbackColorProperty);
		}
		set
		{
			SetValue(FallbackColorProperty, value);
		}
	}

	public static DependencyProperty FallbackColorProperty { get; } = DependencyProperty.Register("FallbackColor", typeof(Color), typeof(XamlCompositionBrushBase), new FrameworkPropertyMetadata(default(Color)));


	internal Color FallbackColorWithOpacity => FallbackColor.WithOpacity(base.Opacity);

	protected XamlCompositionBrushBase()
	{
	}

	protected virtual void OnConnected()
	{
	}

	protected virtual void OnDisconnected()
	{
	}
}

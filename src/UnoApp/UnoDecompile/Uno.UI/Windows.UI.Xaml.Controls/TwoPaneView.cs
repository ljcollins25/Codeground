using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[Obsolete("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.TwoPaneView instead.")]
public class TwoPaneView : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TwoPaneViewWideModeConfiguration WideModeConfiguration
	{
		get
		{
			return (TwoPaneViewWideModeConfiguration)GetValue(WideModeConfigurationProperty);
		}
		set
		{
			SetValue(WideModeConfigurationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TwoPaneViewTallModeConfiguration TallModeConfiguration
	{
		get
		{
			return (TwoPaneViewTallModeConfiguration)GetValue(TallModeConfigurationProperty);
		}
		set
		{
			SetValue(TallModeConfigurationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TwoPaneViewPriority PanePriority
	{
		get
		{
			return (TwoPaneViewPriority)GetValue(PanePriorityProperty);
		}
		set
		{
			SetValue(PanePriorityProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public GridLength Pane2Length
	{
		get
		{
			return (GridLength)GetValue(Pane2LengthProperty);
		}
		set
		{
			SetValue(Pane2LengthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Pane2
	{
		get
		{
			return (UIElement)GetValue(Pane2Property);
		}
		set
		{
			SetValue(Pane2Property, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public GridLength Pane1Length
	{
		get
		{
			return (GridLength)GetValue(Pane1LengthProperty);
		}
		set
		{
			SetValue(Pane1LengthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Pane1
	{
		get
		{
			return (UIElement)GetValue(Pane1Property);
		}
		set
		{
			SetValue(Pane1Property, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double MinWideModeWidth
	{
		get
		{
			return (double)GetValue(MinWideModeWidthProperty);
		}
		set
		{
			SetValue(MinWideModeWidthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double MinTallModeHeight
	{
		get
		{
			return (double)GetValue(MinTallModeHeightProperty);
		}
		set
		{
			SetValue(MinTallModeHeightProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TwoPaneViewMode Mode => (TwoPaneViewMode)GetValue(ModeProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinTallModeHeightProperty { get; } = DependencyProperty.Register("MinTallModeHeight", typeof(double), typeof(TwoPaneView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinWideModeWidthProperty { get; } = DependencyProperty.Register("MinWideModeWidth", typeof(double), typeof(TwoPaneView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ModeProperty { get; } = DependencyProperty.Register("Mode", typeof(TwoPaneViewMode), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewMode.SinglePane));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty Pane1LengthProperty { get; } = DependencyProperty.Register("Pane1Length", typeof(GridLength), typeof(TwoPaneView), new FrameworkPropertyMetadata(default(GridLength)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty Pane1Property { get; } = DependencyProperty.Register("Pane1", typeof(UIElement), typeof(TwoPaneView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty Pane2LengthProperty { get; } = DependencyProperty.Register("Pane2Length", typeof(GridLength), typeof(TwoPaneView), new FrameworkPropertyMetadata(default(GridLength)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty Pane2Property { get; } = DependencyProperty.Register("Pane2", typeof(UIElement), typeof(TwoPaneView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PanePriorityProperty { get; } = DependencyProperty.Register("PanePriority", typeof(TwoPaneViewPriority), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewPriority.Pane1));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TallModeConfigurationProperty { get; } = DependencyProperty.Register("TallModeConfiguration", typeof(TwoPaneViewTallModeConfiguration), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewTallModeConfiguration.SinglePane));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty WideModeConfigurationProperty { get; } = DependencyProperty.Register("WideModeConfiguration", typeof(TwoPaneViewWideModeConfiguration), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewWideModeConfiguration.SinglePane));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<TwoPaneView, object> ModeChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TwoPaneView", "event TypedEventHandler<TwoPaneView, object> TwoPaneView.ModeChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TwoPaneView", "event TypedEventHandler<TwoPaneView, object> TwoPaneView.ModeChanged");
		}
	}

	public TwoPaneView()
	{
		throw new NotImplementedException("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.TwoPaneView instead.");
	}
}

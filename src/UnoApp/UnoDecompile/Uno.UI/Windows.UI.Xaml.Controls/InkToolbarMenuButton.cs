using System;
using Uno;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarMenuButton : ToggleButton
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsExtensionGlyphShown
	{
		get
		{
			return (bool)GetValue(IsExtensionGlyphShownProperty);
		}
		set
		{
			SetValue(IsExtensionGlyphShownProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarMenuKind MenuKind
	{
		get
		{
			throw new NotImplementedException("The member InkToolbarMenuKind InkToolbarMenuButton.MenuKind is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsExtensionGlyphShownProperty { get; } = DependencyProperty.Register("IsExtensionGlyphShown", typeof(bool), typeof(InkToolbarMenuButton), new FrameworkPropertyMetadata(false));

}

using System;
using Uno;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarToolButton : RadioButton
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
	public InkToolbarTool ToolKind
	{
		get
		{
			throw new NotImplementedException("The member InkToolbarTool InkToolbarToolButton.ToolKind is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsExtensionGlyphShownProperty { get; } = DependencyProperty.Register("IsExtensionGlyphShown", typeof(bool), typeof(InkToolbarToolButton), new FrameworkPropertyMetadata(false));

}

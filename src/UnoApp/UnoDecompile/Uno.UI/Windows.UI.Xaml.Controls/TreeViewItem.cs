using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class TreeViewItem : ListViewItem
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsExpanded
	{
		get
		{
			return (bool)GetValue(IsExpandedProperty);
		}
		set
		{
			SetValue(IsExpandedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double GlyphSize
	{
		get
		{
			return (double)GetValue(GlyphSizeProperty);
		}
		set
		{
			SetValue(GlyphSizeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double GlyphOpacity
	{
		get
		{
			return (double)GetValue(GlyphOpacityProperty);
		}
		set
		{
			SetValue(GlyphOpacityProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush GlyphBrush
	{
		get
		{
			return (Brush)GetValue(GlyphBrushProperty);
		}
		set
		{
			SetValue(GlyphBrushProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string ExpandedGlyph
	{
		get
		{
			return (string)GetValue(ExpandedGlyphProperty);
		}
		set
		{
			SetValue(ExpandedGlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string CollapsedGlyph
	{
		get
		{
			return (string)GetValue(CollapsedGlyphProperty);
		}
		set
		{
			SetValue(CollapsedGlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TreeViewItemTemplateSettings TreeViewItemTemplateSettings => (TreeViewItemTemplateSettings)GetValue(TreeViewItemTemplateSettingsProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object ItemsSource
	{
		get
		{
			return GetValue(ItemsSourceProperty);
		}
		set
		{
			SetValue(ItemsSourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool HasUnrealizedChildren
	{
		get
		{
			return (bool)GetValue(HasUnrealizedChildrenProperty);
		}
		set
		{
			SetValue(HasUnrealizedChildrenProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CollapsedGlyphProperty { get; } = DependencyProperty.Register("CollapsedGlyph", typeof(string), typeof(TreeViewItem), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ExpandedGlyphProperty { get; } = DependencyProperty.Register("ExpandedGlyph", typeof(string), typeof(TreeViewItem), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GlyphBrushProperty { get; } = DependencyProperty.Register("GlyphBrush", typeof(Brush), typeof(TreeViewItem), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GlyphOpacityProperty { get; } = DependencyProperty.Register("GlyphOpacity", typeof(double), typeof(TreeViewItem), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GlyphSizeProperty { get; } = DependencyProperty.Register("GlyphSize", typeof(double), typeof(TreeViewItem), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsExpandedProperty { get; } = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(TreeViewItem), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TreeViewItemTemplateSettingsProperty { get; } = DependencyProperty.Register("TreeViewItemTemplateSettings", typeof(TreeViewItemTemplateSettings), typeof(TreeViewItem), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HasUnrealizedChildrenProperty { get; } = DependencyProperty.Register("HasUnrealizedChildren", typeof(bool), typeof(TreeViewItem), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(TreeViewItem), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TreeViewItem()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeViewItem", "TreeViewItem.TreeViewItem()");
	}
}

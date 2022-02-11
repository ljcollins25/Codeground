using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class ListBox : Selector
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SelectionMode SelectionMode
	{
		get
		{
			return (SelectionMode)GetValue(SelectionModeProperty);
		}
		set
		{
			SetValue(SelectionModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<object> SelectedItems
	{
		get
		{
			throw new NotImplementedException("The member IList<object> ListBox.SelectedItems is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool SingleSelectionFollowsFocus
	{
		get
		{
			return (bool)GetValue(SingleSelectionFollowsFocusProperty);
		}
		set
		{
			SetValue(SingleSelectionFollowsFocusProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionModeProperty { get; } = DependencyProperty.Register("SelectionMode", typeof(SelectionMode), typeof(ListBox), new FrameworkPropertyMetadata(SelectionMode.Single));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SingleSelectionFollowsFocusProperty { get; } = DependencyProperty.Register("SingleSelectionFollowsFocus", typeof(bool), typeof(ListBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ListBox()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListBox", "ListBox.ListBox()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView(object item)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListBox", "void ListBox.ScrollIntoView(object item)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SelectAll()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListBox", "void ListBox.SelectAll()");
	}
}

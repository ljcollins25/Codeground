using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class ListPickerFlyout : PickerFlyoutBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ListPickerFlyoutSelectionMode SelectionMode
	{
		get
		{
			return (ListPickerFlyoutSelectionMode)GetValue(SelectionModeProperty);
		}
		set
		{
			SetValue(SelectionModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string SelectedValuePath
	{
		get
		{
			return (string)GetValue(SelectedValuePathProperty);
		}
		set
		{
			SetValue(SelectedValuePathProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object SelectedValue
	{
		get
		{
			return GetValue(SelectedValueProperty);
		}
		set
		{
			SetValue(SelectedValueProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object SelectedItem
	{
		get
		{
			return GetValue(SelectedItemProperty);
		}
		set
		{
			SetValue(SelectedItemProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int SelectedIndex
	{
		get
		{
			return (int)GetValue(SelectedIndexProperty);
		}
		set
		{
			SetValue(SelectedIndexProperty, value);
		}
	}

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
	public DataTemplate ItemTemplate
	{
		get
		{
			return (DataTemplate)GetValue(ItemTemplateProperty);
		}
		set
		{
			SetValue(ItemTemplateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string DisplayMemberPath
	{
		get
		{
			return (string)GetValue(DisplayMemberPathProperty);
		}
		set
		{
			SetValue(DisplayMemberPathProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<object> SelectedItems
	{
		get
		{
			throw new NotImplementedException("The member IList<object> ListPickerFlyout.SelectedItems is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DisplayMemberPathProperty { get; } = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(ListPickerFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemTemplateProperty { get; } = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(ListPickerFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemsSourceProperty { get; } = DependencyProperty.Register("ItemsSource", typeof(object), typeof(ListPickerFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedIndexProperty { get; } = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(ListPickerFlyout), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(ListPickerFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedValuePathProperty { get; } = DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(ListPickerFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedValueProperty { get; } = DependencyProperty.Register("SelectedValue", typeof(object), typeof(ListPickerFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectionModeProperty { get; } = DependencyProperty.Register("SelectionMode", typeof(ListPickerFlyoutSelectionMode), typeof(ListPickerFlyout), new FrameworkPropertyMetadata(ListPickerFlyoutSelectionMode.Single));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ListPickerFlyout, ItemsPickedEventArgs> ItemsPicked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListPickerFlyout", "event TypedEventHandler<ListPickerFlyout, ItemsPickedEventArgs> ListPickerFlyout.ItemsPicked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ListPickerFlyout", "event TypedEventHandler<ListPickerFlyout, ItemsPickedEventArgs> ListPickerFlyout.ItemsPicked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<IReadOnlyList<object>> ShowAtAsync(FrameworkElement target)
	{
		throw new NotImplementedException("The member IAsyncOperation<IReadOnlyList<object>> ListPickerFlyout.ShowAtAsync(FrameworkElement target) is not implemented in Uno.");
	}

	protected override bool ShouldShowConfirmationButtons()
	{
		return SelectionMode == ListPickerFlyoutSelectionMode.Multiple;
	}
}

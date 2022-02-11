using System;
using System.ComponentModel;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

public class GroupStyle : INotifyPropertyChanged
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemsPanelTemplate Panel
	{
		get
		{
			throw new NotImplementedException("The member ItemsPanelTemplate GroupStyle.Panel is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.GroupStyle", "ItemsPanelTemplate GroupStyle.Panel");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public StyleSelector ContainerStyleSelector
	{
		get
		{
			throw new NotImplementedException("The member StyleSelector GroupStyle.ContainerStyleSelector is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.GroupStyle", "StyleSelector GroupStyle.ContainerStyleSelector");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Style ContainerStyle
	{
		get
		{
			throw new NotImplementedException("The member Style GroupStyle.ContainerStyle is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.GroupStyle", "Style GroupStyle.ContainerStyle");
		}
	}

	public DataTemplate HeaderTemplate { get; set; }

	[NotImplemented]
	public DataTemplateSelector HeaderTemplateSelector { get; set; }

	public Style HeaderContainerStyle { get; set; }

	public bool HidesIfEmpty { get; set; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event PropertyChangedEventHandler PropertyChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.GroupStyle", "event PropertyChangedEventHandler GroupStyle.PropertyChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.GroupStyle", "event PropertyChangedEventHandler GroupStyle.PropertyChanged");
		}
	}
}

using System;
using Uno;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class CommandBarFlyout : FlyoutBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IObservableVector<ICommandBarElement> PrimaryCommands
	{
		get
		{
			throw new NotImplementedException("The member IObservableVector<ICommandBarElement> CommandBarFlyout.PrimaryCommands is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IObservableVector<ICommandBarElement> SecondaryCommands
	{
		get
		{
			throw new NotImplementedException("The member IObservableVector<ICommandBarElement> CommandBarFlyout.SecondaryCommands is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CommandBarFlyout()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.CommandBarFlyout", "CommandBarFlyout.CommandBarFlyout()");
	}
}

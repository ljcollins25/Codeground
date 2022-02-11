using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class AutoSuggestBoxAutomationPeer : FrameworkElementAutomationPeer, IInvokeProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public AutoSuggestBoxAutomationPeer(AutoSuggestBox owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutoSuggestBoxAutomationPeer", "AutoSuggestBoxAutomationPeer.AutoSuggestBoxAutomationPeer(AutoSuggestBox owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Invoke()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutoSuggestBoxAutomationPeer", "void AutoSuggestBoxAutomationPeer.Invoke()");
	}
}

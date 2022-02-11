using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class RepeatButtonAutomationPeer : ButtonBaseAutomationPeer, IInvokeProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RepeatButtonAutomationPeer(RepeatButton owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.RepeatButtonAutomationPeer", "RepeatButtonAutomationPeer.RepeatButtonAutomationPeer(RepeatButton owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Invoke()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.RepeatButtonAutomationPeer", "void RepeatButtonAutomationPeer.Invoke()");
	}
}

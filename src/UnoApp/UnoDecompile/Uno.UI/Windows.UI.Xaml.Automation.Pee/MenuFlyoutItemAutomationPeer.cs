using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class MenuFlyoutItemAutomationPeer : FrameworkElementAutomationPeer, IInvokeProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public MenuFlyoutItemAutomationPeer(MenuFlyoutItem owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.MenuFlyoutItemAutomationPeer", "MenuFlyoutItemAutomationPeer.MenuFlyoutItemAutomationPeer(MenuFlyoutItem owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Invoke()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.MenuFlyoutItemAutomationPeer", "void MenuFlyoutItemAutomationPeer.Invoke()");
	}
}

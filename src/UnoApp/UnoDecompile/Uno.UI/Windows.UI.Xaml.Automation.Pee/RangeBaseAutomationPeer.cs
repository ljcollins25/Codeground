using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

public class RangeBaseAutomationPeer : FrameworkElementAutomationPeer, IRangeValueProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsReadOnly
	{
		get
		{
			throw new NotImplementedException("The member bool RangeBaseAutomationPeer.IsReadOnly is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double LargeChange
	{
		get
		{
			throw new NotImplementedException("The member double RangeBaseAutomationPeer.LargeChange is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Maximum
	{
		get
		{
			throw new NotImplementedException("The member double RangeBaseAutomationPeer.Maximum is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Minimum
	{
		get
		{
			throw new NotImplementedException("The member double RangeBaseAutomationPeer.Minimum is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double SmallChange
	{
		get
		{
			throw new NotImplementedException("The member double RangeBaseAutomationPeer.SmallChange is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Value
	{
		get
		{
			throw new NotImplementedException("The member double RangeBaseAutomationPeer.Value is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RangeBaseAutomationPeer(RangeBase owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.RangeBaseAutomationPeer", "RangeBaseAutomationPeer.RangeBaseAutomationPeer(RangeBase owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetValue(double value)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.RangeBaseAutomationPeer", "void RangeBaseAutomationPeer.SetValue(double value)");
	}

	public RangeBaseAutomationPeer()
	{
		throw new NotImplementedException();
	}

	public RangeBaseAutomationPeer(object instance)
	{
		throw new NotImplementedException();
	}
}

using System;
using DirectUI;
using Uno;
using Uno.UI.Xaml.Core;
using Windows.Foundation;

namespace Windows.UI.Xaml;

public sealed class XamlRoot
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHostVisible
	{
		get
		{
			throw new NotImplementedException("The member bool XamlRoot.IsHostVisible is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double RasterizationScale
	{
		get
		{
			throw new NotImplementedException("The member double XamlRoot.RasterizationScale is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIContext UIContext
	{
		get
		{
			throw new NotImplementedException("The member UIContext XamlRoot.UIContext is not implemented in Uno.");
		}
	}

	internal static XamlRoot Current { get; } = new XamlRoot();


	public UIElement? Content => Window.Current?.Content;

	public Size Size => Content?.RenderSize ?? Size.Empty;

	internal VisualTree VisualTree => DXamlCore.Current.GetHandle().ContentRootCoordinator.CoreWindowContentRoot!.VisualTree;

	public event TypedEventHandler<XamlRoot, XamlRootChangedEventArgs>? Changed;

	private XamlRoot()
	{
	}

	internal void NotifyChanged()
	{
		this.Changed?.Invoke(this, new XamlRootChangedEventArgs());
	}
}

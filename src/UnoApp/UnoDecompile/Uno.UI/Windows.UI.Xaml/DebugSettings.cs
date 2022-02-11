using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml;

public sealed class DebugSettings
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool FailFastOnErrors
	{
		get
		{
			throw new NotImplementedException("The member bool DebugSettings.FailFastOnErrors is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.DebugSettings", "bool DebugSettings.FailFastOnErrors");
		}
	}

	[NotImplemented]
	public bool EnableFrameRateCounter { get; set; }

	[NotImplemented]
	public bool EnableRedrawRegions { get; set; }

	[NotImplemented]
	public bool IsBindingTracingEnabled { get; set; }

	[NotImplemented]
	public bool IsOverdrawHeatMapEnabled { get; set; }

	[NotImplemented]
	public bool IsTextPerformanceVisualizationEnabled { get; set; }

	public event BindingFailedEventHandler BindingFailed;

	private void OnBindingFailed(BindingFailedEventArgs args)
	{
		this.BindingFailed?.Invoke(this, args);
	}
}

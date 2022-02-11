using System;
using System.Collections.Generic;
using Uno;
using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Primitives;

public class PivotPanel : Panel, IScrollSnapPointsInfo
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AreHorizontalSnapPointsRegular
	{
		get
		{
			throw new NotImplementedException("The member bool PivotPanel.AreHorizontalSnapPointsRegular is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AreVerticalSnapPointsRegular
	{
		get
		{
			throw new NotImplementedException("The member bool PivotPanel.AreVerticalSnapPointsRegular is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<object> HorizontalSnapPointsChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.PivotPanel", "event EventHandler<object> PivotPanel.HorizontalSnapPointsChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.PivotPanel", "event EventHandler<object> PivotPanel.HorizontalSnapPointsChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<object> VerticalSnapPointsChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.PivotPanel", "event EventHandler<object> PivotPanel.VerticalSnapPointsChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.PivotPanel", "event EventHandler<object> PivotPanel.VerticalSnapPointsChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IReadOnlyList<float> GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment)
	{
		throw new NotImplementedException("The member IReadOnlyList<float> PivotPanel.GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public float GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset)
	{
		throw new NotImplementedException("The member float PivotPanel.GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset) is not implemented in Uno.");
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		ScrollViewer scrollViewer = FindFirstParent<ScrollViewer>();
		if (scrollViewer == null)
		{
			this.Log().Warn("Failed to find expected parent ScrollViewer of this PivotPanel");
		}
		else
		{
			availableSize = new Size(Math.Min(availableSize.Width, scrollViewer.ViewportMeasureSize.Width), availableSize.Height);
		}
		double num = 0.0;
		foreach (UIElement child in base.Children)
		{
			MeasureElement(child, availableSize);
			if (child.DesiredSize.Height > num)
			{
				num = child.DesiredSize.Height;
			}
		}
		if (!(availableSize.Height > num))
		{
			return availableSize;
		}
		return new Size(availableSize.Width, num);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		ScrollViewer scrollViewer = FindFirstParent<ScrollViewer>();
		if (scrollViewer == null)
		{
			this.Log().Warn("Failed to find expected parent ScrollViewer of this PivotPanel");
		}
		else
		{
			finalSize = new Size(Math.Min(finalSize.Width, scrollViewer.ViewportArrangeSize.Width), finalSize.Height);
		}
		foreach (UIElement child in base.Children)
		{
			ArrangeElement(child, new Rect(default(Point), finalSize));
		}
		return finalSize;
	}
}

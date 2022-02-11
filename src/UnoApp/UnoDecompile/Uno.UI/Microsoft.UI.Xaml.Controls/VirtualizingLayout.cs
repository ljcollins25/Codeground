using System;
using System.Collections.Specialized;
using Uno;
using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls;

public class VirtualizingLayout : Layout
{
	protected internal virtual void InitializeForContextCore(VirtualizingLayoutContext context)
	{
	}

	protected internal virtual void UninitializeForContextCore(VirtualizingLayoutContext context)
	{
	}

	protected internal virtual Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
	{
		throw new NotImplementedException();
	}

	protected internal virtual Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
	{
		return finalSize;
	}

	protected internal virtual void OnItemsChangedCore(VirtualizingLayoutContext context, object source, NotifyCollectionChangedEventArgs args)
	{
		InvalidateMeasure();
	}

	[UnoOnly]
	protected internal virtual bool IsSignificantViewportChange(Rect oldViewport, Rect newViewport)
	{
		if (!(Math.Abs(oldViewport.Width - newViewport.Width) > 50.0) && !(Math.Abs(oldViewport.Height - newViewport.Height) > 50.0) && !(Math.Abs(oldViewport.Top - newViewport.Top) > 50.0))
		{
			return Math.Abs(oldViewport.Left - newViewport.Left) > 50.0;
		}
		return true;
	}
}

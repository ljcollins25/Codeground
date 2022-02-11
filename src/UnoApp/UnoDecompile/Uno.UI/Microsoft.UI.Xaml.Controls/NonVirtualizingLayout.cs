using System;
using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls;

public class NonVirtualizingLayout : Layout
{
	protected internal virtual void InitializeForContextCore(LayoutContext context)
	{
	}

	protected internal virtual void UninitializeForContextCore(LayoutContext context)
	{
	}

	protected internal virtual Size MeasureOverride(NonVirtualizingLayoutContext context, Size availableSize)
	{
		throw new NotImplementedException();
	}

	protected internal virtual Size ArrangeOverride(NonVirtualizingLayoutContext context, Size finalSize)
	{
		throw new NotImplementedException();
	}
}

using System;
using Uno;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class ItemsWrapGrid : Panel
{
	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CacheLength
	{
		get
		{
			return (double)GetValue(CacheLengthProperty);
		}
		set
		{
			SetValue(CacheLengthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int FirstCacheIndex
	{
		get
		{
			throw new NotImplementedException("The member int ItemsWrapGrid.FirstCacheIndex is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int FirstVisibleIndex
	{
		get
		{
			throw new NotImplementedException("The member int ItemsWrapGrid.FirstVisibleIndex is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int LastCacheIndex
	{
		get
		{
			throw new NotImplementedException("The member int ItemsWrapGrid.LastCacheIndex is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int LastVisibleIndex
	{
		get
		{
			throw new NotImplementedException("The member int ItemsWrapGrid.LastVisibleIndex is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PanelScrollingDirection ScrollingDirection
	{
		get
		{
			throw new NotImplementedException("The member PanelScrollingDirection ItemsWrapGrid.ScrollingDirection is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CacheLengthProperty { get; } = DependencyProperty.Register("CacheLength", typeof(double), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(0.0));


	public bool AreStickyGroupHeadersEnabled
	{
		get
		{
			return (bool)GetValue(AreStickyGroupHeadersEnabledProperty);
		}
		set
		{
			SetValue(AreStickyGroupHeadersEnabledProperty, value);
		}
	}

	public static DependencyProperty AreStickyGroupHeadersEnabledProperty { get; } = DependencyProperty.Register("AreStickyGroupHeadersEnabled", typeof(bool), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGrid)s)?.OnAreStickyGroupHeadersEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public GroupHeaderPlacement GroupHeaderPlacement
	{
		get
		{
			return (GroupHeaderPlacement)GetValue(GroupHeaderPlacementProperty);
		}
		set
		{
			SetValue(GroupHeaderPlacementProperty, value);
		}
	}

	public static DependencyProperty GroupHeaderPlacementProperty { get; } = DependencyProperty.Register("GroupHeaderPlacement", typeof(GroupHeaderPlacement), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(GroupHeaderPlacement.Top, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGrid)s)?.OnGroupHeaderPlacementChanged((GroupHeaderPlacement)e.OldValue, (GroupHeaderPlacement)e.NewValue);
	}));


	public Thickness GroupPadding
	{
		get
		{
			return (Thickness)GetValue(GroupPaddingProperty);
		}
		set
		{
			SetValue(GroupPaddingProperty, value);
		}
	}

	public static DependencyProperty GroupPaddingProperty { get; } = DependencyProperty.Register("GroupPadding", typeof(Thickness), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(Thickness.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGrid)s)?.OnGroupPaddingChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
	}));


	public double ItemHeight
	{
		get
		{
			return (double)GetValue(ItemHeightProperty);
		}
		set
		{
			SetValue(ItemHeightProperty, value);
		}
	}

	public static DependencyProperty ItemHeightProperty { get; } = DependencyProperty.Register("ItemHeight", typeof(double), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGrid)s)?.OnItemHeightChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double ItemWidth
	{
		get
		{
			return (double)GetValue(ItemWidthProperty);
		}
		set
		{
			SetValue(ItemWidthProperty, value);
		}
	}

	public static DependencyProperty ItemWidthProperty { get; } = DependencyProperty.Register("ItemWidth", typeof(double), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGrid)s)?.OnItemWidthChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public Orientation Orientation
	{
		get
		{
			return (Orientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGrid)s)?.OnOrientationChanged((Orientation)e.OldValue, (Orientation)e.NewValue);
	}));


	public int MaximumRowsOrColumns
	{
		get
		{
			return (int)GetValue(MaximumRowsOrColumnsProperty);
		}
		set
		{
			SetValue(MaximumRowsOrColumnsProperty, value);
		}
	}

	public static DependencyProperty MaximumRowsOrColumnsProperty { get; } = DependencyProperty.Register("MaximumRowsOrColumns", typeof(int), typeof(ItemsWrapGrid), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsWrapGrid)s)?.OnMaximumRowsOrColumnsChanged((int)e.OldValue, (int)e.NewValue);
	}));


	protected virtual void OnAreStickyGroupHeadersEnabledChanged(bool oldAreStickyGroupHeadersEnabled, bool newAreStickyGroupHeadersEnabled)
	{
	}

	protected virtual void OnGroupHeaderPlacementChanged(GroupHeaderPlacement oldGroupHeaderPlacement, GroupHeaderPlacement newGroupHeaderPlacement)
	{
	}

	protected virtual void OnGroupPaddingChanged(Thickness oldGroupPadding, Thickness newGroupPadding)
	{
	}

	protected virtual void OnItemHeightChanged(double oldItemHeight, double newItemHeight)
	{
	}

	protected virtual void OnItemWidthChanged(double oldItemWidth, double newItemWidth)
	{
	}

	protected virtual void OnOrientationChanged(Orientation oldOrientation, Orientation newOrientation)
	{
	}

	protected virtual void OnMaximumRowsOrColumnsChanged(int oldMaximumRowsOrColumns, int newMaximumRowsOrColumns)
	{
	}
}

using System;
using Uno;
using Uno.UI;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class ItemsStackPanel : Panel, IVirtualizingPanel
{
	private VirtualizingPanelLayout _layout;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemsUpdatingScrollMode ItemsUpdatingScrollMode
	{
		get
		{
			throw new NotImplementedException("The member ItemsUpdatingScrollMode ItemsStackPanel.ItemsUpdatingScrollMode is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemsStackPanel", "ItemsUpdatingScrollMode ItemsStackPanel.ItemsUpdatingScrollMode");
		}
	}

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
			throw new NotImplementedException("The member int ItemsStackPanel.FirstCacheIndex is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int LastCacheIndex
	{
		get
		{
			throw new NotImplementedException("The member int ItemsStackPanel.LastCacheIndex is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PanelScrollingDirection ScrollingDirection
	{
		get
		{
			throw new NotImplementedException("The member PanelScrollingDirection ItemsStackPanel.ScrollingDirection is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CacheLengthProperty { get; } = DependencyProperty.Register("CacheLength", typeof(double), typeof(ItemsStackPanel), new FrameworkPropertyMetadata(0.0));


	[NotImplemented]
	public int FirstVisibleIndex => _layout?.FirstVisibleIndex ?? (-1);

	[NotImplemented]
	public int LastVisibleIndex => _layout?.LastVisibleIndex ?? (-1);

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

	public static DependencyProperty AreStickyGroupHeadersEnabledProperty { get; } = DependencyProperty.Register("AreStickyGroupHeadersEnabled", typeof(bool), typeof(ItemsStackPanel), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsStackPanel)s)?.OnAreStickyGroupHeadersEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
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

	public static DependencyProperty GroupHeaderPlacementProperty { get; } = DependencyProperty.Register("GroupHeaderPlacement", typeof(GroupHeaderPlacement), typeof(ItemsStackPanel), new FrameworkPropertyMetadata(GroupHeaderPlacement.Top, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsStackPanel)s)?.OnGroupHeaderPlacementChanged((GroupHeaderPlacement)e.OldValue, (GroupHeaderPlacement)e.NewValue);
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

	public static DependencyProperty GroupPaddingProperty { get; } = DependencyProperty.Register("GroupPadding", typeof(Thickness), typeof(ItemsStackPanel), new FrameworkPropertyMetadata(Thickness.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsStackPanel)s)?.OnGroupPaddingChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
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

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(ItemsStackPanel), new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsStackPanel)s)?.OnOrientationChanged((Orientation)e.OldValue, (Orientation)e.NewValue);
	}));


	public ItemsStackPanel()
	{
		if (FeatureConfiguration.ListViewBase.DefaultCacheLength.HasValue)
		{
			CacheLength = FeatureConfiguration.ListViewBase.DefaultCacheLength.Value;
		}
		CreateLayoutIfNeeded();
		_layout.Initialize(this);
	}

	VirtualizingPanelLayout IVirtualizingPanel.GetLayouter()
	{
		CreateLayoutIfNeeded();
		return _layout;
	}

	private void CreateLayoutIfNeeded()
	{
		if (_layout == null)
		{
			_layout = new ItemsStackPanelLayout();
			_layout.BindToEquivalentProperty(this, "Orientation");
			_layout.BindToEquivalentProperty(this, "AreStickyGroupHeadersEnabled");
			_layout.BindToEquivalentProperty(this, "GroupHeaderPlacement");
			_layout.BindToEquivalentProperty(this, "GroupPadding");
			_layout.BindToEquivalentProperty(this, "CacheLength");
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		return _layout.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		return _layout.ArrangeOverride(finalSize);
	}

	protected virtual void OnAreStickyGroupHeadersEnabledChanged(bool oldAreStickyGroupHeadersEnabled, bool newAreStickyGroupHeadersEnabled)
	{
	}

	protected virtual void OnGroupHeaderPlacementChanged(GroupHeaderPlacement oldGroupHeaderPlacement, GroupHeaderPlacement newGroupHeaderPlacement)
	{
	}

	protected virtual void OnGroupPaddingChanged(Thickness oldGroupPadding, Thickness newGroupPadding)
	{
	}

	protected virtual void OnOrientationChanged(Orientation oldOrientation, Orientation newOrientation)
	{
	}
}

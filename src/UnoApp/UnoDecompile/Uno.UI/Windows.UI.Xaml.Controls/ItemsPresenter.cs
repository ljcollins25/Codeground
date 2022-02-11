using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class ItemsPresenter : FrameworkElement, IScrollSnapPointsInfo
{
	private UIElement _itemsPanel;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TransitionCollection HeaderTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(HeaderTransitionsProperty);
		}
		set
		{
			SetValue(HeaderTransitionsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataTemplate HeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(HeaderTemplateProperty);
		}
		set
		{
			SetValue(HeaderTemplateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TransitionCollection FooterTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(FooterTransitionsProperty);
		}
		set
		{
			SetValue(FooterTransitionsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataTemplate FooterTemplate
	{
		get
		{
			return (DataTemplate)GetValue(FooterTemplateProperty);
		}
		set
		{
			SetValue(FooterTemplateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Footer
	{
		get
		{
			return GetValue(FooterProperty);
		}
		set
		{
			SetValue(FooterProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(ItemsPresenter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(ItemsPresenter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderTransitionsProperty { get; } = DependencyProperty.Register("HeaderTransitions", typeof(TransitionCollection), typeof(ItemsPresenter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FooterProperty { get; } = DependencyProperty.Register("Footer", typeof(object), typeof(ItemsPresenter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FooterTemplateProperty { get; } = DependencyProperty.Register("FooterTemplate", typeof(DataTemplate), typeof(ItemsPresenter), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FooterTransitionsProperty { get; } = DependencyProperty.Register("FooterTransitions", typeof(TransitionCollection), typeof(ItemsPresenter), new FrameworkPropertyMetadata((object)null));


	public Thickness Padding
	{
		get
		{
			return (Thickness)GetValue(PaddingProperty);
		}
		set
		{
			SetValue(PaddingProperty, value);
		}
	}

	public static DependencyProperty PaddingProperty { get; } = DependencyProperty.Register("Padding", typeof(Thickness), typeof(ItemsPresenter), new FrameworkPropertyMetadata(Thickness.Empty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ItemsPresenter)s)?.OnPaddingChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
	}));


	private bool IsWithinScrollableArea => true;

	private Thickness AppliedPadding
	{
		get
		{
			if (!IsWithinScrollableArea)
			{
				return Thickness.Empty;
			}
			return Padding;
		}
	}

	protected override bool IsSimpleLayout => true;

	internal UIElement Panel => _itemsPanel;

	private IScrollSnapPointsInfo SnapPointsProvider => Panel as IScrollSnapPointsInfo;

	public bool AreHorizontalSnapPointsRegular => SnapPointsProvider?.AreHorizontalSnapPointsRegular ?? false;

	public bool AreVerticalSnapPointsRegular => SnapPointsProvider?.AreVerticalSnapPointsRegular ?? false;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<object> HorizontalSnapPointsChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemsPresenter", "event EventHandler<object> ItemsPresenter.HorizontalSnapPointsChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemsPresenter", "event EventHandler<object> ItemsPresenter.HorizontalSnapPointsChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<object> VerticalSnapPointsChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemsPresenter", "event EventHandler<object> ItemsPresenter.VerticalSnapPointsChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemsPresenter", "event EventHandler<object> ItemsPresenter.VerticalSnapPointsChanged");
		}
	}

	protected internal override void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnTemplatedParentChanged(e);
		if (base.TemplatedParent is ItemsControl itemsControl && base.IsLoaded)
		{
			itemsControl.SetItemsPresenter(this);
		}
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (base.TemplatedParent is ItemsControl itemsControl && base.IsLoaded)
		{
			itemsControl.SetItemsPresenter(this);
		}
	}

	private void OnPaddingChanged(Thickness oldValue, Thickness newValue)
	{
		InvalidateMeasure();
		PropagateLayoutValues();
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == FrameworkElement.MinHeightProperty || args.Property == FrameworkElement.MinWidthProperty)
		{
			PropagateLayoutValues();
		}
	}

	internal void SetItemsPanel(UIElement panel)
	{
		if (_itemsPanel != panel)
		{
			_itemsPanel = panel;
			RemoveChildViews();
			if (_itemsPanel != null)
			{
				AddChild(_itemsPanel);
				PropagateLayoutValues();
			}
			InvalidateMeasure();
		}
	}

	private void RemoveChildViews()
	{
		ClearChildren();
	}

	private void PropagateLayoutValues()
	{
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		UIElement uIElement = FindFirstChild();
		if (uIElement != null)
		{
			Thickness appliedPadding = AppliedPadding;
			Rect finalRect = new Rect(appliedPadding.Left, appliedPadding.Top, finalSize.Width - appliedPadding.Left - appliedPadding.Right, finalSize.Height - appliedPadding.Top - appliedPadding.Bottom);
			ArrangeElement(uIElement, finalRect);
		}
		return finalSize;
	}

	protected override Size MeasureOverride(Size size)
	{
		Thickness appliedPadding = AppliedPadding;
		Size size2 = base.MeasureOverride(new Size(size.Width - appliedPadding.Left - appliedPadding.Right, size.Height - appliedPadding.Top - appliedPadding.Bottom));
		return new Size(size2.Width + appliedPadding.Left + appliedPadding.Right, size2.Height + appliedPadding.Top + appliedPadding.Bottom);
	}

	public IReadOnlyList<float> GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment)
	{
		return SnapPointsProvider?.GetIrregularSnapPoints(orientation, alignment);
	}

	public float GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset)
	{
		if (SnapPointsProvider == null)
		{
			throw new InvalidOperationException();
		}
		return SnapPointsProvider.GetRegularSnapPoints(orientation, alignment, out offset);
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}

	internal static double OffsetToIndex(double offset)
	{
		return Math.Max(0.0, offset - 2.0);
	}

	internal static double IndexToOffset(int index)
	{
		return (index >= 0) ? (index + 2) : 0;
	}
}

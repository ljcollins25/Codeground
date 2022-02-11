using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Input.Inking;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbar : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkCanvas TargetInkCanvas
	{
		get
		{
			return (InkCanvas)GetValue(TargetInkCanvasProperty);
		}
		set
		{
			SetValue(TargetInkCanvasProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsRulerButtonChecked
	{
		get
		{
			return (bool)GetValue(IsRulerButtonCheckedProperty);
		}
		set
		{
			SetValue(IsRulerButtonCheckedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarInitialControls InitialControls
	{
		get
		{
			return (InkToolbarInitialControls)GetValue(InitialControlsProperty);
		}
		set
		{
			SetValue(InitialControlsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarToolButton ActiveTool
	{
		get
		{
			return (InkToolbarToolButton)GetValue(ActiveToolProperty);
		}
		set
		{
			SetValue(ActiveToolProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObjectCollection Children => (DependencyObjectCollection)GetValue(ChildrenProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkDrawingAttributes InkDrawingAttributes => (InkDrawingAttributes)GetValue(InkDrawingAttributesProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsStencilButtonChecked
	{
		get
		{
			return (bool)GetValue(IsStencilButtonCheckedProperty);
		}
		set
		{
			SetValue(IsStencilButtonCheckedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarButtonFlyoutPlacement ButtonFlyoutPlacement
	{
		get
		{
			return (InkToolbarButtonFlyoutPlacement)GetValue(ButtonFlyoutPlacementProperty);
		}
		set
		{
			SetValue(ButtonFlyoutPlacementProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkPresenter TargetInkPresenter
	{
		get
		{
			return (InkPresenter)GetValue(TargetInkPresenterProperty);
		}
		set
		{
			SetValue(TargetInkPresenterProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ActiveToolProperty { get; } = DependencyProperty.Register("ActiveTool", typeof(InkToolbarToolButton), typeof(InkToolbar), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ChildrenProperty { get; } = DependencyProperty.Register("Children", typeof(DependencyObjectCollection), typeof(InkToolbar), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty InitialControlsProperty { get; } = DependencyProperty.Register("InitialControls", typeof(InkToolbarInitialControls), typeof(InkToolbar), new FrameworkPropertyMetadata(InkToolbarInitialControls.All));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty InkDrawingAttributesProperty { get; } = DependencyProperty.Register("InkDrawingAttributes", typeof(InkDrawingAttributes), typeof(InkToolbar), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsRulerButtonCheckedProperty { get; } = DependencyProperty.Register("IsRulerButtonChecked", typeof(bool), typeof(InkToolbar), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TargetInkCanvasProperty { get; } = DependencyProperty.Register("TargetInkCanvas", typeof(InkCanvas), typeof(InkToolbar), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ButtonFlyoutPlacementProperty { get; } = DependencyProperty.Register("ButtonFlyoutPlacement", typeof(InkToolbarButtonFlyoutPlacement), typeof(InkToolbar), new FrameworkPropertyMetadata(InkToolbarButtonFlyoutPlacement.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsStencilButtonCheckedProperty { get; } = DependencyProperty.Register("IsStencilButtonChecked", typeof(bool), typeof(InkToolbar), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(InkToolbar), new FrameworkPropertyMetadata(Orientation.Vertical));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TargetInkPresenterProperty { get; } = DependencyProperty.Register("TargetInkPresenter", typeof(InkPresenter), typeof(InkToolbar), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<InkToolbar, object> ActiveToolChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.ActiveToolChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.ActiveToolChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<InkToolbar, object> EraseAllClicked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.EraseAllClicked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.EraseAllClicked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<InkToolbar, object> InkDrawingAttributesChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.InkDrawingAttributesChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.InkDrawingAttributesChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<InkToolbar, object> IsRulerButtonCheckedChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.IsRulerButtonCheckedChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, object> InkToolbar.IsRulerButtonCheckedChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<InkToolbar, InkToolbarIsStencilButtonCheckedChangedEventArgs> IsStencilButtonCheckedChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, InkToolbarIsStencilButtonCheckedChangedEventArgs> InkToolbar.IsStencilButtonCheckedChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "event TypedEventHandler<InkToolbar, InkToolbarIsStencilButtonCheckedChangedEventArgs> InkToolbar.IsStencilButtonCheckedChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbar()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbar", "InkToolbar.InkToolbar()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarToolButton GetToolButton(InkToolbarTool tool)
	{
		throw new NotImplementedException("The member InkToolbarToolButton InkToolbar.GetToolButton(InkToolbarTool tool) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarToggleButton GetToggleButton(InkToolbarToggle tool)
	{
		throw new NotImplementedException("The member InkToolbarToggleButton InkToolbar.GetToggleButton(InkToolbarToggle tool) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarMenuButton GetMenuButton(InkToolbarMenuKind menu)
	{
		throw new NotImplementedException("The member InkToolbarMenuButton InkToolbar.GetMenuButton(InkToolbarMenuKind menu) is not implemented in Uno.");
	}
}

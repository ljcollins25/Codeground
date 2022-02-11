using Uno;
using Windows.Foundation;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class FlyoutPresenter : ContentControl
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsDefaultShadowEnabled
	{
		get
		{
			return (bool)GetValue(IsDefaultShadowEnabledProperty);
		}
		set
		{
			SetValue(IsDefaultShadowEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsDefaultShadowEnabledProperty { get; } = DependencyProperty.Register("IsDefaultShadowEnabled", typeof(bool), typeof(FlyoutPresenter), new FrameworkPropertyMetadata(false));


	protected override bool CanCreateTemplateWithoutParent { get; } = true;


	public FlyoutPresenter()
	{
		base.DefaultStyleKey = typeof(FlyoutPresenter);
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == FrameworkElement.AllowFocusOnInteractionProperty)
		{
			Content?.SetValue(FrameworkElement.AllowFocusOnInteractionProperty, base.AllowFocusOnInteraction);
		}
		else if (args.Property == FrameworkElement.AllowFocusWhenDisabledProperty)
		{
			Content?.SetValue(FrameworkElement.AllowFocusWhenDisabledProperty, base.AllowFocusWhenDisabled);
		}
		base.OnPropertyChanged2(args);
	}

	protected override void OnContentChanged(object oldValue, object newValue)
	{
		base.OnContentChanged(oldValue, newValue);
		Content?.SetValue(FrameworkElement.AllowFocusOnInteractionProperty, base.AllowFocusOnInteraction);
		Content?.SetValue(FrameworkElement.AllowFocusWhenDisabledProperty, base.AllowFocusWhenDisabled);
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		if (GetTemplateRoot() is FrameworkElement frameworkElement && base.Parent is FlyoutBasePopupPanel flyoutBasePopupPanel)
		{
			Point position = args.GetCurrentPoint(frameworkElement).Position;
			if (0.0 > position.X || position.X > frameworkElement.ActualWidth || 0.0 > position.Y || position.Y > frameworkElement.ActualHeight)
			{
				flyoutBasePopupPanel.Flyout.Hide();
			}
		}
		args.Handled = true;
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		args.Handled = true;
	}

	protected override void OnTapped(TappedRoutedEventArgs args)
	{
		args.Handled = true;
	}

	protected override void OnDoubleTapped(DoubleTappedRoutedEventArgs args)
	{
		args.Handled = true;
	}

	internal override bool IsViewHit()
	{
		return true;
	}
}

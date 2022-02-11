using System;
using Uno.UI.Extensions;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Xaml.Core;

internal class RootVisual : Panel
{
	private readonly CoreServices _coreServices;

	private bool _isLeftButtonPressed;

	internal VisualTree? AssociatedVisualTree { get; set; }

	internal PopupRoot? AssociatedPopupRoot => AssociatedVisualTree?.PopupRoot ?? this.GetContext().MainPopupRoot;

	internal UIElement? AssociatedPublicRoot => AssociatedVisualTree?.PublicRootVisual ?? (this.GetContext().VisualRoot as UIElement);

	public RootVisual(CoreServices coreServices)
	{
		_coreServices = coreServices ?? throw new ArgumentNullException("coreServices");
		base.IsVisualTreeRoot = true;
		base.PointerPressed += RootVisual_PointerPressed;
		base.PointerReleased += RootVisual_PointerReleased;
		base.PointerCanceled += RootVisual_PointerCanceled;
	}

	internal void SetBackgroundColor(Color backgroundColor)
	{
		SetValue(FrameworkElement.BackgroundProperty, new SolidColorBrush(backgroundColor));
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		foreach (UIElement child in base.Children)
		{
			child?.Measure(availableSize);
		}
		return default(Size);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		foreach (UIElement child in base.Children)
		{
			if (child != null)
			{
				float offsetX = child.GetOffsetX();
				float offsetY = child.GetOffsetY();
				Rect finalRect = new Rect(offsetX, offsetY, finalSize.Width, finalSize.Height);
				child.Arrange(finalRect);
			}
		}
		return finalSize;
	}

	private void RootVisual_PointerPressed(object sender, PointerRoutedEventArgs e)
	{
		PointerPoint currentPoint = e.GetCurrentPoint(this);
		_isLeftButtonPressed = currentPoint.Properties.IsLeftButtonPressed;
	}

	private void RootVisual_PointerReleased(object sender, PointerRoutedEventArgs e)
	{
		if (_isLeftButtonPressed)
		{
			_isLeftButtonPressed = false;
			object focusedElement = FocusManager.GetFocusedElement();
			if (focusedElement is UIElement uIElement)
			{
				uIElement.Unfocus();
				e.Handled = true;
			}
		}
	}

	private void RootVisual_PointerCanceled(object sender, PointerRoutedEventArgs e)
	{
		_isLeftButtonPressed = false;
	}
}

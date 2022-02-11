using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Xaml.Controls;

internal class SystemFocusVisual : Control
{
	private SerialDisposable _focusedElementSubscriptions = new SerialDisposable();

	private Rect _lastRect = Rect.Empty;

	public static readonly DependencyProperty FocusedElementProperty = DependencyProperty.Register("FocusedElement", typeof(UIElement), typeof(SystemFocusVisual), new FrameworkPropertyMetadata(null, OnFocusedElementChanged));

	public UIElement? FocusedElement
	{
		get
		{
			return (FrameworkElement)GetValue(FocusedElementProperty);
		}
		set
		{
			SetValue(FocusedElementProperty, value);
		}
	}

	public SystemFocusVisual()
	{
		base.DefaultStyleKey = typeof(SystemFocusVisual);
		Window.Current.SizeChanged += WindowSizeChanged;
	}

	internal void Redraw()
	{
		SetLayoutProperties();
	}

	private static void OnFocusedElementChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		SystemFocusVisual focusVisual = (SystemFocusVisual)dependencyObject;
		focusVisual._focusedElementSubscriptions.Disposable = null;
		object newValue = args.NewValue;
		FrameworkElement element = newValue as FrameworkElement;
		if (element != null)
		{
			element.EnsureFocusVisualBrushDefaults();
			element.SizeChanged += focusVisual.FocusedElementSizeChanged;
			element.LayoutUpdated += focusVisual.FocusedElementLayoutUpdated;
			element.Unloaded += focusVisual.FocusedElementUnloaded;
			long visibilityToken = element.RegisterPropertyChangedCallback(UIElement.VisibilityProperty, focusVisual.FocusedElementVisibilityChanged);
			focusVisual.SetLayoutProperties();
			focusVisual._focusedElementSubscriptions.Disposable = Disposable.Create(delegate
			{
				element.SizeChanged -= focusVisual.FocusedElementSizeChanged;
				element.LayoutUpdated -= focusVisual.FocusedElementLayoutUpdated;
				element.UnregisterPropertyChangedCallback(UIElement.VisibilityProperty, visibilityToken);
			});
		}
	}

	private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
	{
		SetLayoutProperties();
	}

	private void FocusedElementUnloaded(object sender, RoutedEventArgs e)
	{
		FocusedElement = null;
	}

	private void FocusedElementVisibilityChanged(DependencyObject sender, DependencyProperty dp)
	{
		SetLayoutProperties();
	}

	private void FocusedElementLayoutUpdated(object? sender, object e)
	{
		SetLayoutProperties();
	}

	private void FocusedElementSizeChanged(object sender, SizeChangedEventArgs args)
	{
		SetLayoutProperties();
	}

	private void SetLayoutProperties()
	{
		if (FocusedElement == null || FocusedElement!.Visibility == Visibility.Collapsed || (FocusedElement is Control control && !control.IsEnabled && !control.AllowFocusWhenDisabled))
		{
			base.Visibility = Visibility.Collapsed;
			return;
		}
		base.Visibility = Visibility.Visible;
		GeneralTransform generalTransform = FocusedElement!.TransformToVisual(Window.Current.Content);
		Point point = generalTransform.TransformPoint(new Point(0.0, 0.0));
		Rect rect = new Rect(point.X, point.Y, FocusedElement!.ActualSize.X, FocusedElement!.ActualSize.Y);
		if (rect != _lastRect)
		{
			base.Width = FocusedElement!.ActualSize.X;
			base.Height = FocusedElement!.ActualSize.Y;
			Canvas.SetLeft(this, point.X);
			Canvas.SetTop(this, point.Y);
			_lastRect = rect;
		}
	}
}

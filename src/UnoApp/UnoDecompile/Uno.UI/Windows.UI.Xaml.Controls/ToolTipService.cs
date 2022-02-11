using System;
using System.Threading.Tasks;
using Uno;
using Uno.Disposables;
using Uno.UI;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class ToolTipService
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlacementTargetProperty { get; } = DependencyProperty.RegisterAttached("PlacementTarget", typeof(UIElement), typeof(ToolTipService), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty ToolTipProperty { get; } = DependencyProperty.RegisterAttached("ToolTip", typeof(object), typeof(ToolTipService), new FrameworkPropertyMetadata(null, OnToolTipChanged));


	public static DependencyProperty PlacementProperty { get; } = DependencyProperty.RegisterAttached("Placement", typeof(PlacementMode), typeof(ToolTipService), new FrameworkPropertyMetadata(PlacementMode.Top, OnPlacementChanged));


	internal static DependencyProperty ToolTipReferenceProperty { get; } = DependencyProperty.RegisterAttached("ToolTipReference", typeof(ToolTip), typeof(ToolTipService), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static UIElement GetPlacementTarget(DependencyObject element)
	{
		return (UIElement)element.GetValue(PlacementTargetProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetPlacementTarget(DependencyObject element, UIElement value)
	{
		element.SetValue(PlacementTargetProperty, value);
	}

	public static object GetToolTip(DependencyObject obj)
	{
		return obj.GetValue(ToolTipProperty);
	}

	public static void SetToolTip(DependencyObject obj, object value)
	{
		obj.SetValue(ToolTipProperty, value);
	}

	public static PlacementMode GetPlacement(DependencyObject obj)
	{
		return (PlacementMode)obj.GetValue(PlacementProperty);
	}

	public static void SetPlacement(DependencyObject obj, PlacementMode value)
	{
		obj.SetValue(PlacementProperty, value);
	}

	internal static ToolTip GetToolTipReference(DependencyObject obj)
	{
		return (ToolTip)obj.GetValue(ToolTipReferenceProperty);
	}

	internal static void SetToolTipReference(DependencyObject obj, ToolTip value)
	{
		obj.SetValue(ToolTipReferenceProperty, value);
	}

	private static void OnToolTipChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs e)
	{
		if (!FeatureConfiguration.ToolTip.UseToolTips)
		{
			return;
		}
		FrameworkElement owner = dependencyobject as FrameworkElement;
		if (owner == null)
		{
			return;
		}
		if (e.NewValue == null)
		{
			DisposePreviousToolTip();
			return;
		}
		if (e.NewValue is ToolTip toolTip2)
		{
			ToolTip toolTipReference = GetToolTipReference(owner);
			if (toolTipReference != null && toolTip2 != toolTipReference)
			{
				DisposePreviousToolTip(toolTipReference);
			}
			if (toolTip2 != toolTipReference)
			{
				SetupToolTip(toolTip2);
			}
			return;
		}
		ToolTip toolTipReference2 = GetToolTipReference(owner);
		if (e.OldValue is ToolTip toolTip3 && toolTip3 == toolTipReference2)
		{
			DisposePreviousToolTip(toolTipReference2);
			SetupToolTip(new ToolTip
			{
				Content = e.NewValue
			});
		}
		else if (toolTipReference2 != null)
		{
			toolTipReference2.Content = e.NewValue;
		}
		else
		{
			SetupToolTip(new ToolTip
			{
				Content = e.NewValue
			});
		}
		void DisposePreviousToolTip(ToolTip toolTip = null)
		{
			if (toolTip == null)
			{
				toolTip = GetToolTipReference(owner);
			}
			toolTip.OwnerEventSubscriptions?.Dispose();
			toolTip.OwnerEventSubscriptions = null;
			SetToolTipReference(owner, null);
		}
		void SetupToolTip(ToolTip toolTip)
		{
			toolTip.Placement = GetPlacement(toolTip);
			toolTip.SetAnchor(GetPlacementTarget(owner) ?? owner);
			SetToolTipReference(owner, toolTip);
			toolTip.OwnerEventSubscriptions = SubscribeToEvents(owner, toolTip);
		}
	}

	private static void OnPlacementChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs e)
	{
		ToolTip toolTipReference = GetToolTipReference(dependencyobject);
		if (toolTipReference != null)
		{
			toolTipReference.Placement = (PlacementMode)e.NewValue;
		}
	}

	private static IDisposable SubscribeToEvents(FrameworkElement control, ToolTip tooltip)
	{
		if (control.IsLoaded)
		{
			OnOwnerLoaded(control, null);
		}
		control.Loaded += OnOwnerLoaded;
		control.Unloaded += OnOwnerUnloaded;
		return Disposable.Create(delegate
		{
			control.Loaded -= OnOwnerLoaded;
			control.Unloaded -= OnOwnerUnloaded;
			OnOwnerUnloaded(control, null);
			tooltip.IsOpen = false;
			tooltip.CurrentHoverId++;
		});
	}

	private static void OnOwnerVisibilityChanged(DependencyObject sender, DependencyProperty dp)
	{
		if (sender is FrameworkElement frameworkElement && frameworkElement.Visibility != 0)
		{
			ToolTip toolTipReference = GetToolTipReference(frameworkElement);
			if (toolTipReference != null)
			{
				toolTipReference.IsOpen = false;
				toolTipReference.CurrentHoverId++;
			}
		}
	}

	private static void OnOwnerLoaded(object sender, RoutedEventArgs e)
	{
		FrameworkElement owner = sender as FrameworkElement;
		if (owner == null)
		{
			return;
		}
		ToolTip toolTipReference = GetToolTipReference(owner);
		if (toolTipReference != null)
		{
			owner.PointerEntered += OnPointerEntered;
			owner.PointerExited += OnPointerExited;
			long token = owner.RegisterPropertyChangedCallback(UIElement.VisibilityProperty, OnOwnerVisibilityChanged);
			toolTipReference.OwnerVisibilitySubscription = Disposable.Create(delegate
			{
				owner.UnregisterPropertyChangedCallback(UIElement.VisibilityProperty, token);
			});
		}
	}

	private static void OnOwnerUnloaded(object sender, RoutedEventArgs e)
	{
		if (sender is FrameworkElement frameworkElement)
		{
			ToolTip toolTipReference = GetToolTipReference(frameworkElement);
			if (toolTipReference != null)
			{
				toolTipReference.IsOpen = false;
				frameworkElement.PointerEntered -= OnPointerEntered;
				frameworkElement.PointerExited -= OnPointerExited;
				toolTipReference.OwnerVisibilitySubscription?.Dispose();
				toolTipReference.OwnerVisibilitySubscription = null;
			}
		}
	}

	private static void OnPointerEntered(object sender, PointerRoutedEventArgs e)
	{
		FrameworkElement owner = sender as FrameworkElement;
		ToolTip toolTip;
		if (owner != null)
		{
			toolTip = GetToolTipReference(owner);
			if (toolTip != null)
			{
				HoverTask(++toolTip.CurrentHoverId);
			}
		}
		async Task HoverTask(long hoverId)
		{
			await Task.Delay(FeatureConfiguration.ToolTip.ShowDelay);
			if (toolTip.CurrentHoverId == hoverId && owner.IsLoaded)
			{
				toolTip.IsOpen = true;
				await Task.Delay(FeatureConfiguration.ToolTip.ShowDuration);
				if (toolTip.CurrentHoverId == hoverId)
				{
					toolTip.IsOpen = false;
				}
			}
		}
	}

	private static void OnPointerExited(object sender, PointerRoutedEventArgs e)
	{
		if (sender is FrameworkElement obj)
		{
			ToolTip toolTipReference = GetToolTipReference(obj);
			if (toolTipReference != null)
			{
				toolTipReference.IsOpen = false;
				toolTipReference.CurrentHoverId++;
			}
		}
	}
}

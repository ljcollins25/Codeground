using System;
using System.Runtime.CompilerServices;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.Extensions;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Behaviors;

internal static class InternalVisibleBoundsPadding
{
	[Flags]
	public enum PaddingMask
	{
		All = 0xF,
		None = 0,
		Top = 1,
		Bottom = 2,
		Left = 4,
		Right = 8
	}

	public class VisibleBoundsDetails
	{
		private static readonly ConditionalWeakTable<FrameworkElement, VisibleBoundsDetails> _instances = new ConditionalWeakTable<FrameworkElement, VisibleBoundsDetails>();

		private readonly WeakReference _owner;

		private readonly TypedEventHandler<ApplicationView, object> _visibleBoundsChanged;

		private PaddingMask _paddingMask;

		private readonly Thickness _originalPadding;

		private FrameworkElement? Owner => _owner.Target as FrameworkElement;

		internal VisibleBoundsDetails(FrameworkElement owner)
		{
			_owner = new WeakReference(owner);
			_originalPadding = owner.GetPadding();
			_visibleBoundsChanged = delegate
			{
				UpdatePadding();
			};
			owner.LayoutUpdated += delegate
			{
				UpdatePadding();
			};
			owner.Loaded += delegate
			{
				UpdatePadding();
				ApplicationView.GetForCurrentView().VisibleBoundsChanged += _visibleBoundsChanged;
			};
			owner.Unloaded += delegate
			{
				ApplicationView.GetForCurrentView().VisibleBoundsChanged -= _visibleBoundsChanged;
			};
		}

		private void UpdatePadding()
		{
			if (Window.Current?.Content == null || !AreBoundsAspectRatiosConsistent || Owner == null || !Owner!.IsLoaded)
			{
				return;
			}
			Thickness visibilityPadding;
			if (WindowPadding.Left != 0.0 || WindowPadding.Right != 0.0 || WindowPadding.Top != 0.0 || WindowPadding.Bottom != 0.0)
			{
				ScrollViewer scrollAncestor = GetScrollAncestor();
				FrameworkElement boundsOf = scrollAncestor ?? Owner;
				Rect relativeBounds = GetRelativeBounds(boundsOf, Window.Current.Content);
				visibilityPadding = CalculateVisibilityPadding(OffsetVisibleBounds, relativeBounds);
				if (scrollAncestor != null)
				{
					visibilityPadding = AdjustScrollablePadding(visibilityPadding, scrollAncestor);
				}
			}
			else
			{
				visibilityPadding = default(Thickness);
			}
			Thickness padding = CalculateAppliedPadding(_paddingMask, visibilityPadding);
			ApplyPadding(padding);
		}

		private Thickness CalculateVisibilityPadding(Rect visibleBounds, Rect controlBounds)
		{
			Thickness windowPadding = WindowPadding;
			double left = Math.Min(visibleBounds.Left - controlBounds.Left, windowPadding.Left);
			double top = Math.Min(visibleBounds.Top - controlBounds.Top, windowPadding.Top);
			double right = Math.Min(controlBounds.Right - visibleBounds.Right, windowPadding.Right);
			double bottom = Math.Min(controlBounds.Bottom - visibleBounds.Bottom, windowPadding.Bottom);
			Thickness result = default(Thickness);
			result.Left = left;
			result.Top = top;
			result.Right = right;
			result.Bottom = bottom;
			return result;
		}

		private Thickness AdjustScrollablePadding(Thickness visibilityPadding, ScrollViewer scrollAncestor)
		{
			if (scrollAncestor.Content is FrameworkElement frameworkElement && Owner != null)
			{
				Rect relativeBounds = GetRelativeBounds(Owner, frameworkElement);
				Rect rect = new Rect(0.0, 0.0, frameworkElement.ActualWidth, frameworkElement.ActualHeight);
				visibilityPadding.Left -= relativeBounds.Left - rect.Left;
				visibilityPadding.Top -= relativeBounds.Top - rect.Top;
				visibilityPadding.Right -= rect.Right - relativeBounds.Right;
				visibilityPadding.Bottom -= rect.Bottom - relativeBounds.Bottom;
			}
			return visibilityPadding;
		}

		private Thickness CalculateAppliedPadding(PaddingMask mask, Thickness visibilityPadding)
		{
			double left = (mask.HasFlag(PaddingMask.Left) ? Math.Max(_originalPadding.Left, visibilityPadding.Left) : _originalPadding.Left);
			double top = (mask.HasFlag(PaddingMask.Top) ? Math.Max(_originalPadding.Top, visibilityPadding.Top) : _originalPadding.Top);
			double right = (mask.HasFlag(PaddingMask.Right) ? Math.Max(_originalPadding.Right, visibilityPadding.Right) : _originalPadding.Right);
			double bottom = (mask.HasFlag(PaddingMask.Bottom) ? Math.Max(_originalPadding.Bottom, visibilityPadding.Bottom) : _originalPadding.Bottom);
			Thickness result = default(Thickness);
			result.Left = left;
			result.Top = top;
			result.Right = right;
			result.Bottom = bottom;
			return result;
		}

		private void ApplyPadding(Thickness padding)
		{
			FrameworkElement owner = Owner;
			if (owner != null && owner.SetPadding(padding) && _log.IsEnabled(LogLevel.Debug))
			{
				_log.LogDebug($"ApplyPadding={padding}");
			}
		}

		internal static VisibleBoundsDetails GetInstance(FrameworkElement element)
		{
			return _instances.GetValue(element, (FrameworkElement e) => new VisibleBoundsDetails(e));
		}

		internal void OnIsPaddingMaskChanged(PaddingMask oldValue, PaddingMask newValue)
		{
			_paddingMask = newValue;
			UpdatePadding();
		}

		private ScrollViewer? GetScrollAncestor()
		{
			return Owner?.FindFirstParent<ScrollViewer>();
		}

		private static Rect GetRelativeBounds(FrameworkElement boundsOf, UIElement relativeTo)
		{
			return boundsOf.TransformToVisual(relativeTo).TransformBounds(new Rect(0.0, 0.0, boundsOf.ActualWidth, boundsOf.ActualHeight));
		}
	}

	private static readonly Logger _log = typeof(InternalVisibleBoundsPadding).Log();

	public static Thickness WindowPadding
	{
		get
		{
			Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
			Rect rect = Window.Current?.Bounds ?? Rect.Empty;
			Thickness thickness = default(Thickness);
			thickness.Left = visibleBounds.Left - rect.Left;
			thickness.Top = visibleBounds.Top - rect.Top;
			thickness.Right = rect.Right - visibleBounds.Right;
			thickness.Bottom = rect.Bottom - visibleBounds.Bottom;
			Thickness thickness2 = thickness;
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.LogDebug($"WindowPadding={thickness2} bounds={rect} visibleBounds={visibleBounds}");
			}
			return thickness2;
		}
	}

	private static Rect OffsetVisibleBounds
	{
		get
		{
			Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
			Window current = Window.Current;
			if (current != null)
			{
				Rect bounds = current.Bounds;
				visibleBounds.X -= bounds.X;
				visibleBounds.Y -= bounds.Y;
			}
			return visibleBounds;
		}
	}

	public static DependencyProperty PaddingMaskProperty { get; } = DependencyProperty.RegisterAttached("PaddingMask", typeof(PaddingMask), typeof(InternalVisibleBoundsPadding), new PropertyMetadata(PaddingMask.None, OnIsPaddingMaskChanged));


	private static bool AreBoundsAspectRatiosConsistent => ApplicationView.GetForCurrentView().VisibleBounds.GetOrientation() == Window.Current?.Bounds.GetOrientation();

	public static PaddingMask GetPaddingMask(DependencyObject obj)
	{
		return (PaddingMask)obj.GetValue(PaddingMaskProperty);
	}

	public static void SetPaddingMask(DependencyObject obj, PaddingMask value)
	{
		obj.SetValue(PaddingMaskProperty, value);
	}

	private static void OnIsPaddingMaskChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is FrameworkElement element)
		{
			VisibleBoundsDetails.GetInstance(element).OnIsPaddingMaskChanged((PaddingMask)args.OldValue, (PaddingMask)args.NewValue);
		}
		else if (dependencyObject.Log().IsEnabled(LogLevel.Debug))
		{
			dependencyObject.Log().LogDebug($"PaddingMask is only supported on FrameworkElement (Found {dependencyObject?.GetType()})");
		}
	}
}

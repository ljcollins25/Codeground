using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Uno.UI.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Media;

public class VisualTreeHelper
{
	internal struct Branch
	{
		public readonly UIElement Root;

		public readonly UIElement Leaf;

		public static Branch ToWindowRoot(UIElement leaf)
		{
			return new Branch(Window.Current.RootElement, leaf);
		}

		public Branch(UIElement root, UIElement leaf)
		{
			Root = root;
			Leaf = leaf;
		}

		public void Deconstruct(out UIElement root, out UIElement leaf)
		{
			root = Root;
			leaf = Leaf;
		}

		public IEnumerable<UIElement> EnumerateLeafToRoot()
		{
			UIElement current = Leaf;
			yield return Leaf;
			while (current != Root)
			{
				DependencyObject parent = GetParent(current);
				while (true)
				{
					UIElement uIElement;
					current = (uIElement = parent as UIElement);
					if (uIElement != null)
					{
						break;
					}
					parent = GetParent(parent);
				}
				yield return current;
			}
		}

		public override string ToString()
		{
			return "Root=" + Root.GetDebugName() + " | Leaf=" + Leaf.GetDebugName();
		}
	}

	private static readonly List<WeakReference<IPopup>> _openPopups;

	internal static readonly GetHitTestability DefaultGetTestability;

	internal static IDisposable RegisterOpenPopup(IPopup popup)
	{
		WeakReference<IPopup> weakPopup = new WeakReference<IPopup>(popup);
		_openPopups.AddDistinct(weakPopup);
		return Disposable.Create(delegate
		{
			_openPopups.Remove(weakPopup);
		});
	}

	[NotImplemented]
	public static void DisconnectChildrenRecursive(UIElement element)
	{
		throw new NotSupportedException();
	}

	public static IEnumerable<UIElement> FindElementsInHostCoordinates(Point intersectingPoint, UIElement subtree)
	{
		return FindElementsInHostCoordinates(intersectingPoint, subtree, includeAllElements: false);
	}

	[NotImplemented]
	public static IEnumerable<UIElement> FindElementsInHostCoordinates(Rect intersectingRect, UIElement subtree)
	{
		throw new NotSupportedException();
	}

	public static IEnumerable<UIElement> FindElementsInHostCoordinates(Point intersectingPoint, UIElement subtree, bool includeAllElements)
	{
		if (subtree == null)
		{
			yield break;
		}
		if (IsElementIntersecting(intersectingPoint, subtree))
		{
			yield return subtree;
		}
		UIElement uIElement = default(UIElement);
		foreach (UIElement child in subtree.GetChildren().OfType<UIElement>())
		{
			bool flag = includeAllElements || (child.IsHitTestVisible && child.IsViewHit());
			int num;
			if (child != null)
			{
				uIElement = child;
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (((uint)num & (flag ? 1u : 0u)) == 0)
			{
				continue;
			}
			if (IsElementIntersecting(intersectingPoint, uIElement))
			{
				yield return uIElement;
			}
			foreach (UIElement item in FindElementsInHostCoordinates(intersectingPoint, child, includeAllElements))
			{
				yield return item;
			}
		}
	}

	private static bool IsElementIntersecting(Point intersectingPoint, UIElement uiElement)
	{
		GeneralTransform generalTransform = uiElement.TransformToVisual(null);
		return generalTransform.TransformBounds(uiElement.LayoutSlot).Contains(intersectingPoint);
	}

	[NotImplemented]
	public static IEnumerable<UIElement> FindElementsInHostCoordinates(Rect intersectingRect, UIElement subtree, bool includeAllElements)
	{
		throw new NotSupportedException();
	}

	public static DependencyObject GetChild(DependencyObject reference, int childIndex)
	{
		return (reference as UIElement)?.GetChildren().OfType<DependencyObject>().ElementAtOrDefault(childIndex);
	}

	public static int GetChildrenCount(DependencyObject reference)
	{
		return (reference as UIElement)?.GetChildren().OfType<DependencyObject>().Count() ?? 0;
	}

	public static IReadOnlyList<Popup> GetOpenPopups(Window window)
	{
		return _openPopups.Select(new Func<WeakReference<IPopup>, IPopup>(WeakReferenceExtensions.GetTarget)).OfType<Popup>().ToList()
			.AsReadOnly();
	}

	private static IReadOnlyList<Popup> GetOpenFlyoutPopups()
	{
		return (from p in _openPopups.Select(new Func<WeakReference<IPopup>, IPopup>(WeakReferenceExtensions.GetTarget)).OfType<Popup>()
			where p.IsForFlyout
			select p).ToList().AsReadOnly();
	}

	public static IReadOnlyList<Popup> GetOpenPopupsForXamlRoot(XamlRoot xamlRoot)
	{
		if (xamlRoot == XamlRoot.Current)
		{
			return GetOpenPopups(Window.Current);
		}
		return new Popup[0];
	}

	public static DependencyObject GetParent(DependencyObject reference)
	{
		return reference.GetParent() as DependencyObject;
	}

	internal static void CloseAllPopups()
	{
		foreach (Popup openPopup in GetOpenPopups(Window.Current))
		{
			openPopup.IsOpen = false;
		}
	}

	internal static void CloseAllFlyouts()
	{
		foreach (Popup openFlyoutPopup in GetOpenFlyoutPopups())
		{
			openFlyoutPopup.IsOpen = false;
		}
	}

	public static FrameworkElement AdaptNative(UIElement nativeView)
	{
		if (nativeView is FrameworkElement)
		{
			throw new InvalidOperationException("AdaptNative() should only be called for non-FrameworkElement native views.Use TryAdaptNative if it's not known whether view will be native.");
		}
		ContentPresenter contentPresenter = new ContentPresenter
		{
			IsNativeHost = true,
			Content = nativeView
		};
		PropagateAttachedProperties(contentPresenter, nativeView, Grid.RowProperty, Grid.RowSpanProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty, Canvas.LeftProperty, Canvas.TopProperty, Canvas.ZIndexProperty);
		return contentPresenter;
	}

	private static void PropagateAttachedProperties(FrameworkElement host, UIElement nativeView, params DependencyProperty[] properties)
	{
		foreach (DependencyProperty dp in properties)
		{
			host.SetValue(dp, nativeView.GetValue(dp));
		}
	}

	public static FrameworkElement TryAdaptNative(UIElement view)
	{
		if (view is FrameworkElement result)
		{
			return result;
		}
		return AdaptNative(view);
	}

	public static IEnumerable<T> GetChildren<T>(DependencyObject view)
	{
		return (view as UIElement)?.GetChildren().OfType<T>() ?? Enumerable.Empty<T>();
	}

	public static IEnumerable<DependencyObject> GetChildren(DependencyObject view)
	{
		return GetChildren<DependencyObject>(view);
	}

	internal static void AddChild(UIElement view, UIElement child)
	{
		view.AddChild(child);
	}

	internal static void RemoveChild(UIElement view, UIElement child)
	{
		view.RemoveChild(child);
	}

	internal static IReadOnlyList<UIElement> ClearChildren(UIElement view)
	{
		List<UIElement> result = GetChildren<UIElement>(view).ToList();
		view.ClearChildren();
		return result;
	}

	static VisualTreeHelper()
	{
		_openPopups = new List<WeakReference<IPopup>>();
		DefaultGetTestability = (UIElement elt) => (elt.GetHitTestVisibility(), DefaultGetTestability);
	}

	internal static (UIElement? element, Branch? stale) HitTest(Point position, GetHitTestability? getTestability = null, Predicate<UIElement>? isStale = null)
	{
		UIElement rootElement = Window.Current.RootElement;
		if (rootElement != null)
		{
			return SearchDownForTopMostElementAt(position, rootElement, getTestability ?? DefaultGetTestability, isStale);
		}
		return default((UIElement, Branch?));
	}

	private static (UIElement? element, Branch? stale) SearchDownForTopMostElementAt(Point posRelToParent, UIElement element, GetHitTestability getVisibility, Predicate<UIElement>? isStale = null, Func<IEnumerable<UIElement>, IEnumerable<UIElement>>? childrenFilter = null)
	{
		Branch? branch = null;
		HitTestability hitTestability;
		(hitTestability, getVisibility) = getVisibility(element);
		if (hitTestability == HitTestability.Collapsed)
		{
			if (isStale != null && isStale!(element))
			{
				branch = SearchDownForStaleBranch(element, isStale);
			}
			return (null, branch);
		}
		Rect layoutSlotWithMarginsAndAlignments = element.LayoutSlotWithMarginsAndAlignments;
		Rect rect = element.Clip?.Bounds ?? Rect.Infinite;
		Rect rect2 = new Rect(default(Point), layoutSlotWithMarginsAndAlignments.Size);
		Point point = posRelToParent;
		point.X -= layoutSlotWithMarginsAndAlignments.X;
		point.Y -= layoutSlotWithMarginsAndAlignments.Y;
		Transform renderTransform = element.RenderTransform;
		if (renderTransform != null)
		{
			Matrix3x2 matrix = renderTransform.MatrixCore.Inverse();
			point = matrix.Transform(point);
			rect2 = matrix.Transform(rect2);
		}
		if (element is ScrollViewer scrollViewer)
		{
			float zoomFactor = scrollViewer.ZoomFactor;
			point.X /= zoomFactor;
			point.Y /= zoomFactor;
			rect2 = new Rect(rect2.Location, new Size(scrollViewer.ExtentWidth, scrollViewer.ExtentHeight));
		}
		if (element.IsScrollPort)
		{
			point.X += element.ScrollOffsets.X;
			point.Y += element.ScrollOffsets.Y;
		}
		if (!rect.Contains(point))
		{
			if (isStale != null && isStale!(element))
			{
				branch = SearchDownForStaleBranch(element, isStale);
			}
			return (null, branch);
		}
		IEnumerable<UIElement> source = ((childrenFilter == null) ? GetManagedVisualChildren(element) : childrenFilter!(GetManagedVisualChildren(element)));
		using IEnumerator<UIElement> enumerator = source.Reverse().GetEnumerator();
		Predicate<UIElement> predicate = isStale;
		while (enumerator.MoveNext())
		{
			(UIElement, Branch?) tuple2 = SearchDownForTopMostElementAt(point, enumerator.Current, getVisibility, predicate);
			Branch? item = tuple2.Item2;
			if (item.HasValue)
			{
				branch = tuple2.Item2;
				predicate = null;
			}
			if (tuple2.Item1 == null)
			{
				continue;
			}
			if (predicate != null)
			{
				while (enumerator.MoveNext())
				{
					if (predicate(enumerator.Current))
					{
						branch = SearchDownForStaleBranch(enumerator.Current, predicate);
						break;
					}
				}
			}
			return (tuple2.Item1, branch);
		}
		if (hitTestability == HitTestability.Visible && rect2.Contains(point))
		{
			return (element, branch);
		}
		if (isStale != null && isStale!(element))
		{
			branch = new Branch(element, branch?.Leaf ?? element);
		}
		return (null, branch);
	}

	private static Branch SearchDownForStaleBranch(UIElement staleRoot, Predicate<UIElement> isStale)
	{
		return new Branch(staleRoot, SearchDownForLeaf(staleRoot, isStale));
	}

	internal static UIElement SearchDownForLeaf(UIElement root, Predicate<UIElement> predicate)
	{
		foreach (UIElement item in GetManagedVisualChildren(root).Reverse())
		{
			if (predicate(item))
			{
				return SearchDownForLeaf(item, predicate);
			}
		}
		return root;
	}

	private static Func<IEnumerable<UIElement>, IEnumerable<UIElement>> Except(UIElement element)
	{
		UIElement element2 = element;
		return (IEnumerable<UIElement> children) => children.Except<UIElement>(new UIElement[1] { element2 });
	}

	private static Func<IEnumerable<UIElement>, IEnumerable<UIElement>> SkipUntil(UIElement element)
	{
		UIElement element2 = element;
		return (IEnumerable<UIElement> children) => SkipUntilCore(element2, children);
	}

	private static IEnumerable<UIElement> SkipUntilCore(UIElement element, IEnumerable<UIElement> children)
	{
		using IEnumerator<UIElement> enumerator = children.GetEnumerator();
		while (enumerator.MoveNext() && enumerator.Current != element)
		{
		}
		if (enumerator.MoveNext())
		{
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
		}
	}

	private static IEnumerable<UIElement> GetManagedVisualChildren(UIElement view)
	{
		return view.GetChildren().OfType<UIElement>();
	}

	[Conditional("TRACE_HIT_TESTING")]
	private static void TRACE(FormattableString msg)
	{
	}
}

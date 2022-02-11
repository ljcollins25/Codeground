using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Foundation.Logging;
using Uno.UI.Helpers.WinUI;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class XYFocus
{
	internal struct XYFocusParameters
	{
		public DependencyObject? Element { get; set; }

		public Rect Bounds { get; set; }

		public double Score { get; set; }
	}

	internal class XYFocusMaxRootBoundComparer : IComparer<XYFocusParameters>
	{
		private readonly FocusNavigationDirection _direction;

		internal XYFocusMaxRootBoundComparer(FocusNavigationDirection direction)
		{
			_direction = direction;
		}

		public int Compare(XYFocusParameters x, XYFocusParameters y)
		{
			Rect bounds = x.Bounds;
			Rect bounds2 = y.Bounds;
			if (_direction == FocusNavigationDirection.Left)
			{
				return bounds.Left.CompareTo(bounds2.Left);
			}
			if (_direction == FocusNavigationDirection.Right)
			{
				return bounds2.Right.CompareTo(bounds.Right);
			}
			if (_direction == FocusNavigationDirection.Up)
			{
				return bounds.Top.CompareTo(bounds2.Top);
			}
			if (_direction == FocusNavigationDirection.Down)
			{
				return bounds2.Bottom.CompareTo(bounds.Bottom);
			}
			return 1;
		}
	}

	internal class XYFocusParametersBestFocusableElementComparer : IComparer<XYFocusParameters>
	{
		private readonly FocusNavigationDirection _direction;

		private readonly bool _isRightToLeft;

		internal XYFocusParametersBestFocusableElementComparer(FocusNavigationDirection direction, bool isRightToLeft)
		{
			_direction = direction;
			_isRightToLeft = isRightToLeft;
		}

		public int Compare(XYFocusParameters elementA, XYFocusParameters elementB)
		{
			if (elementA.Score == elementB.Score)
			{
				Rect bounds = elementA.Bounds;
				Rect bounds2 = elementB.Bounds;
				if (_direction == FocusNavigationDirection.Up || _direction == FocusNavigationDirection.Down)
				{
					if (_isRightToLeft)
					{
						return bounds2.Left.CompareTo(bounds.Left);
					}
					return bounds.Left.CompareTo(bounds2.Left);
				}
				return bounds.Top.CompareTo(bounds2.Top);
			}
			return elementB.Score.CompareTo(elementA.Score);
		}
	}

	internal struct Manifolds
	{
		public static Manifolds Default
		{
			get
			{
				Manifolds result = default(Manifolds);
				result.Reset();
				return result;
			}
		}

		public (double top, double bottom) Vertical { get; set; }

		public (double left, double right) Horizontal { get; set; }

		public void Reset()
		{
			Vertical = (-1.0, -1.0);
			Horizontal = (-1.0, -1.0);
		}
	}

	internal const int InitialCandidateListCapacity = 50;

	private Manifolds _manifolds;

	private XYFocusAlgorithms _heuristic = new XYFocusAlgorithms();

	private HashSet<int> _exploredList = new HashSet<int>();

	internal Manifolds ResetManifolds()
	{
		Manifolds manifolds = _manifolds;
		_manifolds.Reset();
		return manifolds;
	}

	internal void SetManifolds(Manifolds manifolds)
	{
		_manifolds.Vertical = manifolds.Vertical;
		_manifolds.Horizontal = manifolds.Horizontal;
	}

	private void ClearCache()
	{
		_exploredList.Clear();
	}

	internal DependencyObject? GetNextFocusableElement(FocusNavigationDirection direction, DependencyObject? element, DependencyObject? engagedControl, VisualTree visualTree, bool updateManifolds, XYFocusOptions xyFocusOptions)
	{
		if (element == null)
		{
			return null;
		}
		int num = 0;
		if (_exploredList.Count != 0)
		{
			num = ExploredListHash(direction, element, engagedControl, xyFocusOptions);
			if (_exploredList.Contains(num))
			{
				CacheHitTrace(direction);
				return null;
			}
		}
		UIElement rootOrIslandForElement = VisualTree.GetRootOrIslandForElement(element);
		bool isRightToLeft = element.IsRightToLeft();
		XYFocusNavigationStrategy strategy = XYFocusBubbling.GetStrategy(element, direction, xyFocusOptions.NavigationStrategyOverride);
		Rect bounds = xyFocusOptions.FocusedElementBounds;
		DependencyObject dependencyObject = XYFocusBubbling.GetDirectionOverride(element, xyFocusOptions.SearchRoot, direction, ignoreFocusabililty: true);
		if (dependencyObject != null)
		{
			return dependencyObject;
		}
		DependencyObject activeScrollerForScrollInput = GetActiveScrollerForScrollInput(direction, element);
		bool flag = activeScrollerForScrollInput != null;
		if (xyFocusOptions.FocusHintRectangle.HasValue)
		{
			bounds = xyFocusOptions.FocusHintRectangle.Value;
			element = null;
		}
		Rect rect = ((engagedControl != null) ? XYFocusTreeWalker.GetBoundsForRanking(engagedControl, xyFocusOptions.IgnoreClipping) : ((xyFocusOptions.SearchRoot == null) ? XYFocusTreeWalker.GetBoundsForRanking(rootOrIslandForElement, xyFocusOptions.IgnoreClipping) : XYFocusTreeWalker.GetBoundsForRanking(xyFocusOptions.SearchRoot, xyFocusOptions.IgnoreClipping)));
		List<XYFocusParameters> allValidFocusableChildren = GetAllValidFocusableChildren(rootOrIslandForElement, direction, element, engagedControl, xyFocusOptions.SearchRoot, visualTree, activeScrollerForScrollInput, xyFocusOptions.IgnoreClipping, xyFocusOptions.ShouldConsiderXYFocusKeyboardNavigation);
		if (allValidFocusableChildren.Count > 0)
		{
			double val = Math.Max(rect.Right - rect.Left, rect.Bottom - rect.Top);
			val = Math.Max(val, GetMaxRootBoundsDistance(allValidFocusableChildren, bounds, direction, xyFocusOptions.IgnoreClipping));
			RankElements(allValidFocusableChildren, direction, bounds, val, strategy, xyFocusOptions.ExclusionRect, xyFocusOptions.IgnoreClipping, xyFocusOptions.IgnoreCone);
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				foreach (XYFocusParameters item in allValidFocusableChildren)
				{
					this.Log().LogDebug("Candidate: {0} {1},{2} {3},{4} rank {5}", item.Element, item.Bounds.Left, item.Bounds.Top, item.Bounds.Right, item.Bounds.Bottom, item.Score);
				}
			}
			bool ignoreOcclusivity = xyFocusOptions.IgnoreOcclusivity || flag;
			dependencyObject = ChooseBestFocusableElementFromList(allValidFocusableChildren, direction, visualTree, bounds, xyFocusOptions.IgnoreClipping, ignoreOcclusivity, isRightToLeft, xyFocusOptions.UpdateManifold && updateManifolds);
			dependencyObject = XYFocusBubbling.TryXYFocusBubble(element, dependencyObject, xyFocusOptions.SearchRoot, direction);
		}
		if (dependencyObject == null)
		{
			if (num == 0)
			{
				num = ExploredListHash(direction, element, engagedControl, xyFocusOptions);
			}
			_exploredList.Add(num);
		}
		return dependencyObject;
	}

	private DependencyObject? ChooseBestFocusableElementFromList(IList<XYFocusParameters> scoreList, FocusNavigationDirection direction, VisualTree visualTree, Rect bounds, bool ignoreClipping, bool ignoreOcclusivity, bool isRightToLeft, bool updateManifolds)
	{
		DependencyObject result = null;
		scoreList = scoreList.OrderBy((XYFocusParameters param) => param, new XYFocusParametersBestFocusableElementComparer(direction, isRightToLeft)).ToList();
		foreach (XYFocusParameters score in scoreList)
		{
			if (!(score.Score <= 0.0))
			{
				Rect elementBounds = (ignoreClipping ? XYFocusTreeWalker.GetBoundsForRanking(score.Element, ignoreClipping: false) : score.Bounds);
				if (!score.Bounds.IsInfinite && (ignoreOcclusivity || !XYFocusTreeWalker.IsOccluded(score.Element, elementBounds)))
				{
					result = score.Element;
					if (updateManifolds)
					{
						(double, double) hManifold = _manifolds.Horizontal;
						(double, double) vManifold = _manifolds.Vertical;
						XYFocusAlgorithms.UpdateManifolds(direction, bounds, score.Bounds, ref hManifold, ref vManifold);
						_manifolds.Horizontal = hManifold;
						_manifolds.Vertical = vManifold;
						return result;
					}
					return result;
				}
				continue;
			}
			return result;
		}
		return result;
	}

	internal void UpdateManifolds(FocusNavigationDirection direction, Rect elementBounds, DependencyObject candidate, bool ignoreClipping)
	{
		Rect boundsForRanking = XYFocusTreeWalker.GetBoundsForRanking(candidate, ignoreClipping);
		(double, double) hManifold = _manifolds.Horizontal;
		(double, double) vManifold = _manifolds.Vertical;
		XYFocusAlgorithms.UpdateManifolds(direction, elementBounds, boundsForRanking, ref hManifold, ref vManifold);
		_manifolds.Horizontal = hManifold;
		_manifolds.Vertical = vManifold;
	}

	private List<XYFocusParameters> GetAllValidFocusableChildren(DependencyObject? startRoot, FocusNavigationDirection direction, DependencyObject? currentElement, DependencyObject? engagedControl, DependencyObject? searchScope, VisualTree visualTree, DependencyObject? activeScroller, bool ignoreClipping, bool shouldConsiderXYFocusKeyboardNavigation)
	{
		DependencyObject startRoot2 = startRoot;
		List<XYFocusParameters> list = new List<XYFocusParameters>(50);
		FocusWalkTraceBegin(direction);
		if (searchScope != null)
		{
			startRoot2 = searchScope;
		}
		if (engagedControl == null)
		{
			list = XYFocusTreeWalker.FindElements(startRoot2, currentElement, activeScroller, ignoreClipping, shouldConsiderXYFocusKeyboardNavigation);
		}
		else
		{
			IList<DependencyObject> popupChildrenOpenedDuringEngagement = PopupRoot.GetPopupChildrenOpenedDuringEngagement(engagedControl);
			list = XYFocusTreeWalker.FindElements(engagedControl, currentElement, activeScroller, ignoreClipping, shouldConsiderXYFocusKeyboardNavigation);
			foreach (DependencyObject item2 in popupChildrenOpenedDuringEngagement)
			{
				List<XYFocusParameters> collection = XYFocusTreeWalker.FindElements(item2, currentElement, activeScroller, ignoreClipping, shouldConsiderXYFocusKeyboardNavigation);
				list.AddRange(collection);
			}
			if (currentElement != engagedControl)
			{
				Rect boundsForRanking = XYFocusTreeWalker.GetBoundsForRanking(engagedControl, ignoreClipping);
				XYFocusParameters item = default(XYFocusParameters);
				item.Element = engagedControl;
				item.Bounds = boundsForRanking;
				list.Add(item);
			}
		}
		TraceXYFocusWalkEnd();
		return list;
	}

	private void RankElements(List<XYFocusParameters> candidateList, FocusNavigationDirection direction, Rect bounds, double maxRootBoundsDistance, XYFocusNavigationStrategy mode, Rect? exclusionRect, bool ignoreClipping, bool ignoreCone)
	{
		Rect rect = exclusionRect ?? Rect.Empty;
		for (int i = 0; i < candidateList.Count; i++)
		{
			XYFocusParameters value = candidateList[i];
			Rect bounds2 = value.Bounds;
			if (!MathHelpers.DoRectsIntersect(rect, bounds2) && !MathHelpers.DoesRectContainRect(rect, bounds2))
			{
				if (mode == XYFocusNavigationStrategy.Projection && XYFocusAlgorithms.ShouldCandidateBeConsideredForRanking(bounds, bounds2, maxRootBoundsDistance, direction, rect, ignoreCone))
				{
					value.Score = _heuristic.GetScore(direction, bounds, bounds2, _manifolds.Horizontal, _manifolds.Vertical, maxRootBoundsDistance);
				}
				else if (mode == XYFocusNavigationStrategy.NavigationDirectionDistance || mode == XYFocusNavigationStrategy.RectilinearDistance)
				{
					value.Score = ProximityStrategy.GetScore(direction, bounds, bounds2, maxRootBoundsDistance, mode == XYFocusNavigationStrategy.RectilinearDistance);
				}
			}
			candidateList[i] = value;
		}
	}

	private double GetMaxRootBoundsDistance(IReadOnlyList<XYFocusParameters> list, Rect bounds, FocusNavigationDirection direction, bool ignoreClipping)
	{
		Rect bounds2 = list.OrderByDescending((XYFocusParameters param) => param, new XYFocusMaxRootBoundComparer(direction)).FirstOrDefault()!.Bounds;
		return direction switch
		{
			FocusNavigationDirection.Left => Math.Abs(bounds2.Right - bounds.Left), 
			FocusNavigationDirection.Right => Math.Abs(bounds.Right - bounds2.Left), 
			FocusNavigationDirection.Up => Math.Abs(bounds.Bottom - bounds2.Top), 
			FocusNavigationDirection.Down => Math.Abs(bounds2.Bottom - bounds.Top), 
			_ => 0.0, 
		};
	}

	private DependencyObject? GetActiveScrollerForScrollInput(FocusNavigationDirection direction, DependencyObject? focusedElement)
	{
		DependencyObject dependencyObject = null;
		for (dependencyObject = ((!(focusedElement is TextElement textElement)) ? focusedElement : textElement.GetContainingFrameworkElement()); dependencyObject != null; dependencyObject = dependencyObject.GetParent() as DependencyObject)
		{
			if (dependencyObject is UIElement uIElement && uIElement.IsScroller())
			{
				bool horizontally = false;
				bool vertically = false;
				FocusProperties.IsScrollable(uIElement, ref horizontally, ref vertically);
				bool flag = IsHorizontalNavigationDirection(direction) && horizontally;
				bool flag2 = IsVerticalNavigationDirection(direction) && vertically;
				if (flag || flag2)
				{
					return uIElement;
				}
			}
		}
		return null;
	}

	private bool IsHorizontalNavigationDirection(FocusNavigationDirection direction)
	{
		if (direction != FocusNavigationDirection.Left)
		{
			return direction == FocusNavigationDirection.Right;
		}
		return true;
	}

	private bool IsVerticalNavigationDirection(FocusNavigationDirection direction)
	{
		if (direction != FocusNavigationDirection.Up)
		{
			return direction == FocusNavigationDirection.Down;
		}
		return true;
	}

	private void SetPrimaryAxisDistanceWeight(int primaryAxisDistanceWeight)
	{
		_heuristic.SetPrimaryAxisDistanceWeight(primaryAxisDistanceWeight);
	}

	private void SetSecondaryAxisDistanceWeight(int secondaryAxisDistanceWeight)
	{
		_heuristic.SetSecondaryAxisDistanceWeight(secondaryAxisDistanceWeight);
	}

	private void SetPercentInManifoldShadowWeight(int percentInManifoldShadowWeight)
	{
		_heuristic.SetPercentInManifoldShadowWeight(percentInManifoldShadowWeight);
	}

	private void SetPercentInShadowWeight(int percentInShadowWeight)
	{
		_heuristic.SetPercentInShadowWeight(percentInShadowWeight);
	}

	private int ExploredListHash(FocusNavigationDirection direction, DependencyObject? element, DependencyObject? engagedControl, XYFocusOptions xyFocusOptions)
	{
		int num = 17;
		num = num * 23 + direction.GetHashCode();
		num = num * 23 + (element?.GetHashCode() ?? 0);
		num = num * 23 + (engagedControl?.GetHashCode() ?? 0);
		return num * 23 + xyFocusOptions.GetHashCode();
	}

	private void FocusWalkTraceBegin(FocusNavigationDirection direction)
	{
		switch (direction)
		{
		case FocusNavigationDirection.Next:
			TraceXYFocusWalkBegin("Next");
			break;
		case FocusNavigationDirection.Previous:
			TraceXYFocusWalkBegin("Previous");
			break;
		case FocusNavigationDirection.Up:
			TraceXYFocusWalkBegin("Up");
			break;
		case FocusNavigationDirection.Down:
			TraceXYFocusWalkBegin("Down");
			break;
		case FocusNavigationDirection.Left:
			TraceXYFocusWalkBegin("Left");
			break;
		case FocusNavigationDirection.Right:
			TraceXYFocusWalkBegin("Right");
			break;
		default:
			TraceXYFocusWalkBegin("Invalid");
			break;
		}
	}

	private void CacheHitTrace(FocusNavigationDirection direction)
	{
		switch (direction)
		{
		case FocusNavigationDirection.Next:
			TraceXYFocusCandidateCacheHit("Next");
			break;
		case FocusNavigationDirection.Previous:
			TraceXYFocusCandidateCacheHit("Previous");
			break;
		case FocusNavigationDirection.Up:
			TraceXYFocusCandidateCacheHit("Up");
			break;
		case FocusNavigationDirection.Down:
			TraceXYFocusCandidateCacheHit("Down");
			break;
		case FocusNavigationDirection.Left:
			TraceXYFocusCandidateCacheHit("Left");
			break;
		case FocusNavigationDirection.Right:
			TraceXYFocusCandidateCacheHit("Right");
			break;
		default:
			TraceXYFocusCandidateCacheHit("Invalid");
			break;
		}
	}

	private void TraceXYFocusWalkBegin(string direction)
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace("XYFocus walk begin for direction " + direction);
		}
	}

	private void TraceXYFocusCandidateCacheHit(string direction)
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace("XYFocus candidate cache hit for direction " + direction);
		}
	}

	private void TraceXYFocusWalkEnd()
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace("XYFocus walk ended");
		}
	}
}

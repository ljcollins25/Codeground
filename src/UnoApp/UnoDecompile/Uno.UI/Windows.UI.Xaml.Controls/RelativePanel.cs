using System;
using System.Collections.Generic;
using System.Linq;
using Uno;
using Uno.Extensions;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class RelativePanel : Panel
{
	private class Dependency
	{
		public const int DependencyTypeCount = 10;

		public IFrameworkElement Element { get; private set; }

		public DependencyType Type { get; private set; }

		public Dependency(IFrameworkElement element, DependencyType type)
		{
			Element = element;
			Type = type;
		}
	}

	private enum DependencyType
	{
		Above,
		Below,
		LeftOf,
		RightOf,
		AlignBottomWith,
		AlignLeftWith,
		AlignRightWith,
		AlignTopWith,
		AlignHorizontalCenterWith,
		AlignVerticalCenterWith
	}

	private class SiblingGraph
	{
		private List<Sibling> _entryPoints = new List<Sibling>();

		private List<Sibling> _nodes = new List<Sibling>();

		internal void AddNode(IFrameworkElement child, Dependency[] dependencies)
		{
			Sibling sibling = new Sibling(child);
			foreach (Dependency dependency in dependencies)
			{
				Sibling sibling2 = _nodes.Where((Sibling n) => n.Element.Equals(dependency.Element)).FirstOrDefault();
				if (sibling2 != null)
				{
					sibling.Dependencies.Add(new SiblingDependency(sibling2, dependency.Type));
					sibling2.Dependencies.Add(new SiblingDependency(sibling, GetOppositeDependency(dependency.Type), isInferred: true));
				}
			}
			if (dependencies.Length == 0)
			{
				_entryPoints.Add(sibling);
			}
			_nodes.Add(sibling);
		}

		internal IEnumerable<IEnumerable<IFrameworkElement>> GetClusters(bool isHorizontallyInfinite, bool isVerticallyInfinite)
		{
			List<Sibling> list = new List<Sibling>(_nodes);
			List<Sibling> list2 = new List<Sibling>(_entryPoints);
			List<IEnumerable<IFrameworkElement>> list3 = new List<IEnumerable<IFrameworkElement>>();
			while (list.Count != 0)
			{
				if (list2.Count != 0)
				{
					Sibling sibling = list2[0];
					if (list.Contains(sibling))
					{
						List<Sibling> list4 = new List<Sibling>();
						list.Remove(sibling);
						list4.Add(sibling);
						IEnumerator<IFrameworkElement> enumerator = sibling.GetSiblings().GetEnumerator();
						while (enumerator.MoveNext())
						{
							Sibling sibling2 = list.FirstOrDefault((Sibling n) => n.Element.Equals(enumerator.Current));
							if (sibling2 != null)
							{
								list.Remove(sibling2);
								list4.Add(sibling2);
							}
						}
						CleanupDependencies(list4, isHorizontallyInfinite, isVerticallyInfinite);
						IFrameworkElement[] item = OrderClusterForLayouting(list4);
						list3.Add(item);
					}
					list2.Remove(sibling);
					continue;
				}
				throw new InvalidOperationException("A RelativePanel child was left out of the Sibling Graph.");
			}
			return list3;
		}

		private void CleanupDependencies(List<Sibling> cluster, bool isHorizontallyInfinite, bool isVerticallyInfinite)
		{
			if (!isHorizontallyInfinite && !isVerticallyInfinite)
			{
				return;
			}
			foreach (Sibling item in cluster)
			{
				if (isHorizontallyInfinite && GetAlignRightWithPanel((UIElement)item.Element))
				{
					ReverseDependencies(item, isHorizontal: true);
				}
				if (isVerticallyInfinite && GetAlignBottomWithPanel((UIElement)item.Element))
				{
					ReverseDependencies(item, isHorizontal: false);
				}
			}
		}

		private void ReverseDependencies(Sibling sibling, bool isHorizontal)
		{
			foreach (SiblingDependency dependency in sibling.Dependencies)
			{
				if (!dependency.IsInferred)
				{
					continue;
				}
				if (isHorizontal && (dependency.Type == DependencyType.RightOf || dependency.Type == DependencyType.AlignLeftWith))
				{
					dependency.IsInferred = false;
					SiblingDependency siblingDependency = dependency.Sibling.Dependencies.First((SiblingDependency sd) => sd.Sibling.Equals(sibling) && sd.Type.Equals(GetOppositeDependency(dependency.Type)));
					if (siblingDependency != null)
					{
						siblingDependency.IsInferred = true;
					}
					ReverseDependencies(dependency.Sibling, isHorizontal);
				}
				else if (!isHorizontal && (dependency.Type == DependencyType.Below || dependency.Type == DependencyType.AlignTopWith))
				{
					dependency.IsInferred = false;
					SiblingDependency siblingDependency2 = dependency.Sibling.Dependencies.First((SiblingDependency sd) => sd.Sibling.Equals(sibling) && sd.Type.Equals(GetOppositeDependency(dependency.Type)));
					if (siblingDependency2 != null)
					{
						siblingDependency2.IsInferred = true;
					}
					ReverseDependencies(dependency.Sibling, isHorizontal);
				}
			}
		}

		private IFrameworkElement[] OrderClusterForLayouting(List<Sibling> cluster)
		{
			List<Sibling> list = new List<Sibling>(cluster.OrderByDescending(delegate(Sibling s)
			{
				UIElement uIElement = (UIElement)s.Element;
				return (IsAlignLeftWithPanel(uIElement) ? 3 : 0) + (IsAlignTopWithPanel(uIElement) ? 3 : 0) + (GetAlignRightWithPanel(uIElement) ? 1 : 0) + (GetAlignBottomWithPanel(uIElement) ? 1 : 0);
			}));
			List<Sibling> ordered = new List<Sibling>();
			while (list.Count != 0)
			{
				Sibling item = list.First((Sibling s) => (from sd in s.Dependencies
					where !sd.IsInferred
					select sd.Sibling).Except(ordered).Empty());
				list.Remove(item);
				ordered.Add(item);
			}
			return ordered.SelectToArray((Sibling s) => s.Element);
		}

		internal Sibling GetSibling(IFrameworkElement element)
		{
			return _nodes.FirstOrDefault((Sibling s) => s.Element.Equals(element));
		}

		internal Size MeasureSiblings(Size availableSize, Thickness padding, Func<UIElement, Size, Size> measureChild)
		{
			IEnumerable<IEnumerable<IFrameworkElement>> clusters = GetClusters(double.IsPositiveInfinity(availableSize.Width), double.IsPositiveInfinity(availableSize.Height));
			Size finalSize = default(Size);
			Func<UIElement, Size, Size> measureChild2 = CacheMeasureFunc(measureChild);
			foreach (IEnumerable<IFrameworkElement> item in clusters)
			{
				Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos = new Dictionary<IFrameworkElement, SiblingLayoutInfo>(IFrameworkElementReferenceEqualityComparer.Default);
				foreach (IFrameworkElement item2 in item)
				{
					PrepareAndMeasureChild(item2, availableSize, padding, measureChild2, siblingLayoutInfos);
				}
				foreach (IFrameworkElement item3 in item)
				{
					finalSize = ExecuteOnSiblingLayoutInfoIfAvailable(item3, siblingLayoutInfos, (SiblingLayoutInfo sli) => UpdateFinalMeasuredSize(sli.Area, finalSize, availableSize, padding));
				}
			}
			return finalSize;
		}

		private void PrepareAndMeasureChild(IFrameworkElement child, Size availableSize, Thickness padding, Func<UIElement, Size, Size> measureChild, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, List<IFrameworkElement> updateCallerStack = null)
		{
			bool flag = false;
			Rect areaForChild = GetAvailableAreaForChild(child, availableSize, siblingLayoutInfos, padding);
			double num = child.Margin.Left + child.Margin.Right;
			double num2 = child.Margin.Top + child.Margin.Bottom;
			if ((!double.IsNaN(child.Width) && areaForChild.Width < child.Width + num) || areaForChild.Width < child.MinWidth + num || (!double.IsNaN(child.Height) && areaForChild.Height < child.Height + num2) || areaForChild.Height < child.MinHeight + num2)
			{
				flag = true;
				areaForChild.Width = Math.Max(Math.Max(double.IsNaN(child.Width) ? 0.0 : child.Width, child.MinWidth) + num, areaForChild.Width);
				areaForChild.Height = Math.Max(Math.Max(double.IsNaN(child.Height) ? 0.0 : child.Height, child.MinHeight) + num2, areaForChild.Height);
			}
			Size childSize = measureChild(child as UIElement, areaForChild.Size);
			Rect childArea = ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => ComputeChildArea(areaForChild, childSize, sli));
			bool flag2 = ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsAreaSet);
			bool flag3 = ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, delegate(SiblingLayoutInfo sli)
			{
				if (sli.Area.Equals(childArea))
				{
					return false;
				}
				sli.Area = childArea;
				return true;
			});
			if ((flag && flag3) || (flag2 && flag3))
			{
				List<IFrameworkElement> list = updateCallerStack ?? new List<IFrameworkElement>();
				list.Add(child);
				UpdateSiblingsBasedOnSize(child, availableSize, padding, measureChild, siblingLayoutInfos, list);
			}
		}

		private void UpdateSiblingsBasedOnSize(IFrameworkElement child, Size availableSize, Thickness padding, Func<UIElement, Size, Size> measureChild, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, List<IFrameworkElement> updateCallerStack)
		{
			Sibling sibling = GetSibling(child);
			foreach (IFrameworkElement item in sibling.Dependencies.Select((SiblingDependency d) => d.Sibling.Element).Distinct())
			{
				if (siblingLayoutInfos.ContainsKey(item) && !updateCallerStack.Contains(item))
				{
					PrepareAndMeasureChild(item, availableSize, padding, measureChild, siblingLayoutInfos, updateCallerStack);
				}
			}
		}

		internal void ArrangeSiblings(Size finalSize, Thickness padding, Func<UIElement, Size> getDesiredChildSize, Action<UIElement, Rect> arrangeChild)
		{
			IEnumerable<IEnumerable<IFrameworkElement>> clusters = GetClusters(double.IsPositiveInfinity(finalSize.Width), double.IsPositiveInfinity(finalSize.Height));
			foreach (IEnumerable<IFrameworkElement> item in clusters)
			{
				Dictionary<IFrameworkElement, SiblingLayoutInfo> dictionary = new Dictionary<IFrameworkElement, SiblingLayoutInfo>(IFrameworkElementReferenceEqualityComparer.Default);
				foreach (IFrameworkElement item2 in item)
				{
					PrepareChildForArrange(item2, finalSize, padding, getDesiredChildSize, dictionary);
				}
				foreach (IFrameworkElement item3 in item)
				{
					SiblingLayoutInfo siblingLayoutInfo = dictionary[item3];
					if (siblingLayoutInfo != null)
					{
						arrangeChild(item3 as UIElement, siblingLayoutInfo.Area);
					}
				}
			}
		}

		private void PrepareChildForArrange(IFrameworkElement child, Size finalSize, Thickness padding, Func<UIElement, Size> getDesiredChildSize, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos)
		{
			Rect areaForChild = GetAvailableAreaForChild(child, finalSize, siblingLayoutInfos, padding);
			Size size = getDesiredChildSize(child as UIElement);
			Rect childArea = areaForChild;
			if (!ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.StretchesHorizontally))
			{
				childArea = AlterRectangleSize(childArea, Math.Min(childArea.Width, size.Width), childArea.Height);
			}
			if (!ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.StretchesVertically))
			{
				childArea = AlterRectangleSize(childArea, childArea.Width, Math.Min(childArea.Height, size.Height));
			}
			childArea = ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => ComputeChildArea(areaForChild, childArea.Size, sli));
			if (ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, delegate(SiblingLayoutInfo sli)
			{
				if (!sli.Area.Equals(childArea))
				{
					sli.Area = childArea;
					return true;
				}
				return false;
			}))
			{
				UpdateSiblingsBasedOnArea(child, finalSize, padding, getDesiredChildSize, siblingLayoutInfos);
			}
		}

		private Rect GetAvailableAreaForChild(IFrameworkElement child, Size availableSize, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, Thickness graphPadding)
		{
			double num = ComputeChildLeftBound(child, availableSize, siblingLayoutInfos, graphPadding);
			double num2 = ComputeChildTopBound(child, availableSize, siblingLayoutInfos, graphPadding);
			double num3 = ComputeChildRightBound(child, availableSize, siblingLayoutInfos, num, graphPadding);
			double num4 = ComputeChildBottomBound(child, availableSize, siblingLayoutInfos, num2, graphPadding);
			return new Rect(num, num2, num3 - num, num4 - num2);
		}

		private double ComputeChildLeftBound(IFrameworkElement child, Size availableSize, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, Thickness graphPadding, bool useInferred = false)
		{
			SiblingDependency[] availableDependencies = GetAvailableDependencies(GetSibling(child), DependencyType.RightOf, useInferred, siblingLayoutInfos);
			if (availableDependencies.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsLeftBound = !useInferred);
				return availableDependencies.Max((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Right);
			}
			SiblingDependency[] availableDependencies2 = GetAvailableDependencies(GetSibling(child), DependencyType.AlignLeftWith, useInferred, siblingLayoutInfos);
			if (availableDependencies2.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsLeftBound = !useInferred);
				return availableDependencies2.Max((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Left);
			}
			SiblingDependency[] availableDependencies3 = GetAvailableDependencies(GetSibling(child), DependencyType.AlignHorizontalCenterWith, useInferred, siblingLayoutInfos);
			if (availableDependencies3.Length != 0)
			{
				double center = availableDependencies3.Average(delegate(SiblingDependency d)
				{
					SiblingLayoutInfo siblingLayoutInfo = siblingLayoutInfos[d.Sibling.Element];
					return (siblingLayoutInfo.Area.Left + siblingLayoutInfo.Area.Right) / 2.0;
				});
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, delegate(SiblingLayoutInfo sli)
				{
					Point result = (sli.Center = new Point(center, sli.Center.Y));
					return result;
				});
			}
			if (IsAlignLeftWithPanel((UIElement)child))
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsLeftBound = true);
			}
			if (GetAlignHorizontalCenterWithPanel((UIElement)child))
			{
				double num = child.Margin.Left + child.Margin.Right;
				double num2 = (double.IsNaN(child.Width) ? Math.Max(Math.Min(availableSize.Width - graphPadding.Left - graphPadding.Right, child.MaxWidth + num), child.MinWidth + num) : (child.Width + num));
				return (availableSize.Width - num - num2) / 2.0;
			}
			if (!useInferred)
			{
				return ComputeChildLeftBound(child, availableSize, siblingLayoutInfos, graphPadding, useInferred: true);
			}
			return graphPadding.Left;
		}

		private bool IsAlignLeftWithPanel(UIElement child)
		{
			if (!GetAlignLeftWithPanel(child))
			{
				if (!GetAlignRightWithPanel(child) && !GetAlignHorizontalCenterWithPanel(child) && GetAlignLeftWith(child) == null && GetAlignRightWith(child) == null && GetRightOf(child) == null)
				{
					return GetLeftOf(child) == null;
				}
				return false;
			}
			return true;
		}

		private double ComputeChildTopBound(IFrameworkElement child, Size availableSize, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, Thickness graphPadding, bool useInferred = false)
		{
			SiblingDependency[] availableDependencies = GetAvailableDependencies(GetSibling(child), DependencyType.Below, useInferred, siblingLayoutInfos);
			if (availableDependencies.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsTopBound = !useInferred);
				return availableDependencies.Max((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Bottom);
			}
			SiblingDependency[] availableDependencies2 = GetAvailableDependencies(GetSibling(child), DependencyType.AlignTopWith, useInferred, siblingLayoutInfos);
			if (availableDependencies2.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsTopBound = !useInferred);
				return availableDependencies2.Max((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Top);
			}
			SiblingDependency[] availableDependencies3 = GetAvailableDependencies(GetSibling(child), DependencyType.AlignVerticalCenterWith, useInferred, siblingLayoutInfos);
			if (availableDependencies3.Length != 0)
			{
				double center = availableDependencies3.Average(delegate(SiblingDependency d)
				{
					SiblingLayoutInfo siblingLayoutInfo = siblingLayoutInfos[d.Sibling.Element];
					return (siblingLayoutInfo.Area.Top + siblingLayoutInfo.Area.Bottom) / 2.0;
				});
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, delegate(SiblingLayoutInfo sli)
				{
					Point result = (sli.Center = new Point(sli.Center.X, center));
					return result;
				});
			}
			if (IsAlignTopWithPanel((UIElement)child))
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsTopBound = true);
			}
			if (GetAlignVerticalCenterWithPanel((UIElement)child))
			{
				double num = child.Margin.Top + child.Margin.Bottom;
				double num2 = (double.IsNaN(child.Height) ? Math.Max(Math.Min(availableSize.Height - graphPadding.Top - graphPadding.Bottom, child.MaxHeight + num), child.MinHeight + num) : (child.Height + num));
				return (availableSize.Height - num - num2) / 2.0;
			}
			if (!useInferred)
			{
				return ComputeChildTopBound(child, availableSize, siblingLayoutInfos, graphPadding, useInferred: true);
			}
			return graphPadding.Top;
		}

		private bool IsAlignTopWithPanel(UIElement child)
		{
			if (!GetAlignTopWithPanel(child))
			{
				if (!GetAlignBottomWithPanel(child) && !GetAlignVerticalCenterWithPanel(child) && GetAlignTopWith(child) == null && GetAlignBottomWith(child) == null && GetAbove(child) == null)
				{
					return GetBelow(child) == null;
				}
				return false;
			}
			return true;
		}

		private double ComputeChildRightBound(IFrameworkElement child, Size availableSize, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, double childLeft, Thickness graphPadding, bool useInferred = false)
		{
			SiblingDependency[] availableDependencies = GetAvailableDependencies(GetSibling(child), DependencyType.LeftOf, useInferred, siblingLayoutInfos);
			if (availableDependencies.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsRightBound = !useInferred);
				return availableDependencies.Min((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Left);
			}
			SiblingDependency[] availableDependencies2 = GetAvailableDependencies(GetSibling(child), DependencyType.AlignRightWith, useInferred, siblingLayoutInfos);
			if (availableDependencies2.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsRightBound = !useInferred);
				return availableDependencies2.Min((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Right);
			}
			if (GetAlignRightWithPanel((UIElement)child))
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsRightBound = true);
				return availableSize.Width - graphPadding.Right;
			}
			if (!useInferred)
			{
				return ComputeChildRightBound(child, availableSize, siblingLayoutInfos, childLeft, graphPadding, useInferred: true);
			}
			double num = childLeft + child.Margin.Left + child.Margin.Right;
			if (!double.IsNaN(child.Width))
			{
				return child.Width + num;
			}
			return Math.Max(Math.Min(availableSize.Width - graphPadding.Right, child.MaxWidth + num), child.MinWidth + num);
		}

		private double ComputeChildBottomBound(IFrameworkElement child, Size availableSize, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, double childTop, Thickness graphPadding, bool useInferred = false)
		{
			SiblingDependency[] availableDependencies = GetAvailableDependencies(GetSibling(child), DependencyType.Above, useInferred, siblingLayoutInfos);
			if (availableDependencies.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsBottomBound = !useInferred);
				return availableDependencies.Min((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Top);
			}
			SiblingDependency[] availableDependencies2 = GetAvailableDependencies(GetSibling(child), DependencyType.AlignBottomWith, useInferred, siblingLayoutInfos);
			if (availableDependencies2.Length != 0)
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsBottomBound = !useInferred);
				return availableDependencies2.Min((SiblingDependency d) => siblingLayoutInfos[d.Sibling.Element].Area.Bottom);
			}
			if (GetAlignBottomWithPanel((UIElement)child))
			{
				ExecuteOnSiblingLayoutInfoIfAvailable(child, siblingLayoutInfos, (SiblingLayoutInfo sli) => sli.IsBottomBound = true);
				return availableSize.Height - graphPadding.Bottom;
			}
			if (!useInferred)
			{
				ComputeChildBottomBound(child, availableSize, siblingLayoutInfos, childTop, graphPadding, useInferred: true);
			}
			double num = childTop + child.Margin.Top + child.Margin.Bottom;
			if (!double.IsNaN(child.Height))
			{
				return child.Height + num;
			}
			return Math.Max(Math.Min(availableSize.Height - graphPadding.Bottom, child.MaxHeight + num), child.MinHeight + num);
		}

		private SiblingDependency[] GetAvailableDependencies(Sibling element, DependencyType dependencyType, bool useInferred, IDictionary<IFrameworkElement, SiblingLayoutInfo> availableSiblings)
		{
			return element.Dependencies.Where((SiblingDependency d) => d.Type == dependencyType && d.IsInferred == useInferred && availableSiblings.ContainsKey(d.Sibling.Element)).ToArray();
		}

		private Rect ComputeChildArea(Rect availableArea, Size childSize, SiblingLayoutInfo siblingLayoutInfo)
		{
			Point location = availableArea.Location;
			if (siblingLayoutInfo.IsRightBound && !siblingLayoutInfo.IsLeftBound && !double.IsPositiveInfinity(availableArea.Right))
			{
				location.X = availableArea.Right - childSize.Width;
			}
			else if (!double.IsNaN(siblingLayoutInfo.Center.X))
			{
				location.X = siblingLayoutInfo.Center.X - childSize.Width / 2.0;
			}
			if (siblingLayoutInfo.IsBottomBound && !siblingLayoutInfo.IsTopBound && !double.IsPositiveInfinity(availableArea.Bottom))
			{
				location.Y = availableArea.Bottom - childSize.Height;
			}
			else if (!double.IsNaN(siblingLayoutInfo.Center.Y))
			{
				location.Y = siblingLayoutInfo.Center.Y - childSize.Height / 2.0;
			}
			return new Rect(location, childSize);
		}

		private Size UpdateFinalMeasuredSize(Rect childArea, Size currentFinalMeasuredSize, Size availableSize, Thickness graphPadding)
		{
			return new Size(double.IsPositiveInfinity(childArea.Right) ? Math.Min(Math.Max(childArea.Left + childArea.Width + graphPadding.Right, currentFinalMeasuredSize.Width), availableSize.Width) : Math.Min(Math.Max(childArea.Right + graphPadding.Right, currentFinalMeasuredSize.Width), availableSize.Width), double.IsPositiveInfinity(childArea.Bottom) ? Math.Min(Math.Max(childArea.Top + childArea.Height + graphPadding.Bottom, currentFinalMeasuredSize.Height), availableSize.Height) : Math.Min(Math.Max(childArea.Bottom + graphPadding.Bottom, currentFinalMeasuredSize.Height), availableSize.Height));
		}

		private void UpdateSiblingsBasedOnArea(IFrameworkElement child, Size finalSize, Thickness padding, Func<UIElement, Size> getDesiredChildSize, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos)
		{
			Sibling sibling = GetSibling(child);
			foreach (IFrameworkElement item in sibling.Dependencies.Select((SiblingDependency d) => d.Sibling.Element).Distinct())
			{
				if (siblingLayoutInfos.ContainsKey(item))
				{
					PrepareChildForArrange(item, finalSize, padding, getDesiredChildSize, siblingLayoutInfos);
				}
			}
		}

		private T ExecuteOnSiblingLayoutInfoIfAvailable<T>(IFrameworkElement child, Dictionary<IFrameworkElement, SiblingLayoutInfo> siblingLayoutInfos, Func<SiblingLayoutInfo, T> operation)
		{
			if (!siblingLayoutInfos.ContainsKey(child))
			{
				siblingLayoutInfos[child] = new SiblingLayoutInfo();
			}
			return operation(siblingLayoutInfos[child]);
		}

		private DependencyType GetOppositeDependency(DependencyType value)
		{
			return value switch
			{
				DependencyType.Above => DependencyType.Below, 
				DependencyType.LeftOf => DependencyType.RightOf, 
				DependencyType.Below => DependencyType.Above, 
				DependencyType.RightOf => DependencyType.LeftOf, 
				_ => value, 
			};
		}

		private static Rect AlterRectangleSize(Rect rectangle, double width, double height)
		{
			return new Rect(rectangle.Location, new Size(width, height));
		}

		private static Func<UIElement, Size, Size> CacheMeasureFunc(Func<UIElement, Size, Size> measureChild)
		{
			Dictionary<UIElement, Dictionary<Size, Size>> values = new Dictionary<UIElement, Dictionary<Size, Size>>(ReferenceEqualityComparer<UIElement>.Default);
			return delegate(UIElement view, Size size)
			{
				if (!values.TryGetValue(view, out var value))
				{
					Dictionary<Size, Size> dictionary2 = (values[view] = new Dictionary<Size, Size>());
					value = dictionary2;
				}
				IEnumerable<KeyValuePair<Size, Size>> enumerable = value.Where((KeyValuePair<Size, Size> kvp) => kvp.Key.Width >= size.Width && kvp.Key.Height >= size.Height && kvp.Value.Width <= size.Width && kvp.Value.Height <= size.Height);
				return enumerable.Empty() ? (value[size] = measureChild(view, size)) : (from kvp in enumerable
					select kvp.Value into s
					orderby s.Width * s.Height descending
					select s).First();
			};
		}
	}

	private class SiblingLayoutInfo
	{
		private Rect _area;

		public bool IsAreaSet { get; set; }

		public Rect Area
		{
			get
			{
				return _area;
			}
			set
			{
				IsAreaSet = true;
				_area = value;
			}
		}

		public bool IsLeftBound { get; set; }

		public bool IsTopBound { get; set; }

		public bool IsRightBound { get; set; }

		public bool IsBottomBound { get; set; }

		public bool StretchesHorizontally
		{
			get
			{
				if (IsLeftBound)
				{
					return IsRightBound;
				}
				return false;
			}
		}

		public bool StretchesVertically
		{
			get
			{
				if (IsTopBound)
				{
					return IsBottomBound;
				}
				return false;
			}
		}

		public Point Center { get; set; } = new Point(double.NaN, double.NaN);

	}

	private class Sibling
	{
		public List<SiblingDependency> Dependencies { get; private set; }

		public IFrameworkElement Element { get; private set; }

		public Sibling(IFrameworkElement element)
		{
			Element = element;
			Dependencies = new List<SiblingDependency>();
		}

		public IEnumerable<IFrameworkElement> GetSiblings(IFrameworkElement[] except = null)
		{
			Sibling[] array = Dependencies.SelectToArray((SiblingDependency d) => d.Sibling);
			List<IFrameworkElement> ignored = new List<IFrameworkElement>();
			if (except != null)
			{
				ignored.AddRange(except);
			}
			Sibling[] array2 = array;
			foreach (Sibling sibling in array2)
			{
				IFrameworkElement element = sibling.Element;
				if (ignored.Contains(element))
				{
					continue;
				}
				ignored.Add(element);
				yield return element;
				foreach (IFrameworkElement sibling2 in sibling.GetSiblings(ignored.ToArray()))
				{
					ignored.Add(sibling2);
					yield return sibling2;
				}
			}
		}
	}

	private class SiblingDependency
	{
		public Sibling Sibling { get; set; }

		public DependencyType Type { get; set; }

		public bool IsInferred { get; set; }

		public SiblingDependency(Sibling sibling, DependencyType type, bool isInferred = false)
		{
			Sibling = sibling;
			Type = type;
			IsInferred = isInferred;
		}
	}

	private bool _BackgroundSizingPropertyBackingFieldSet;

	private BackgroundSizing _BackgroundSizingPropertyBackingField;

	private bool _BorderBrushPropertyBackingFieldSet;

	private Brush _BorderBrushPropertyBackingField;

	private bool _BorderThicknessPropertyBackingFieldSet;

	private Thickness _BorderThicknessPropertyBackingField;

	private bool _PaddingPropertyBackingFieldSet;

	private Thickness _PaddingPropertyBackingField;

	private bool _CornerRadiusPropertyBackingFieldSet;

	private CornerRadius _CornerRadiusPropertyBackingField;

	[GeneratedDependencyProperty(DefaultValue = BackgroundSizing.InnerBorderEdge, ChangedCallback = true)]
	public static DependencyProperty BackgroundSizingProperty { get; } = CreateBackgroundSizingProperty();


	public BackgroundSizing BackgroundSizing
	{
		get
		{
			return GetBackgroundSizingValue();
		}
		set
		{
			SetBackgroundSizingValue(value);
		}
	}

	public Brush BorderBrush
	{
		get
		{
			return GetBorderBrushValue();
		}
		set
		{
			SetBorderBrushValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnBorderBrushPropertyChanged", Options = FrameworkPropertyMetadataOptions.ValueInheritsDataContext)]
	public static DependencyProperty BorderBrushProperty { get; } = CreateBorderBrushProperty();


	public Thickness BorderThickness
	{
		get
		{
			return GetBorderThicknessValue();
		}
		set
		{
			SetBorderThicknessValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnBorderThicknessPropertyChanged")]
	public static DependencyProperty BorderThicknessProperty { get; } = CreateBorderThicknessProperty();


	public Thickness Padding
	{
		get
		{
			return GetPaddingValue();
		}
		set
		{
			SetPaddingValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnPaddingPropertyChanged")]
	public static DependencyProperty PaddingProperty { get; } = CreatePaddingProperty();


	public CornerRadius CornerRadius
	{
		get
		{
			return GetCornerRadiusValue();
		}
		set
		{
			SetCornerRadiusValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnCornerRadiusPropertyChanged")]
	public static DependencyProperty CornerRadiusProperty { get; } = CreateCornerRadiusProperty();


	public static DependencyProperty AlignBottomWithPanelProperty { get; } = DependencyProperty.RegisterAttached("AlignBottomWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignLeftWithPanelProperty { get; } = DependencyProperty.RegisterAttached("AlignLeftWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignRightWithPanelProperty { get; } = DependencyProperty.RegisterAttached("AlignRightWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignTopWithPanelProperty { get; } = DependencyProperty.RegisterAttached("AlignTopWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignHorizontalCenterWithPanelProperty { get; } = DependencyProperty.RegisterAttached("AlignHorizontalCenterWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignVerticalCenterWithPanelProperty { get; } = DependencyProperty.RegisterAttached("AlignVerticalCenterWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignBottomWithProperty { get; } = DependencyProperty.RegisterAttached("AlignBottomWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignLeftWithProperty { get; } = DependencyProperty.RegisterAttached("AlignLeftWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignRightWithProperty { get; } = DependencyProperty.RegisterAttached("AlignRightWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignTopWithProperty { get; } = DependencyProperty.RegisterAttached("AlignTopWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignHorizontalCenterWithProperty { get; } = DependencyProperty.RegisterAttached("AlignHorizontalCenterWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AlignVerticalCenterWithProperty { get; } = DependencyProperty.RegisterAttached("AlignVerticalCenterWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty AboveProperty { get; } = DependencyProperty.RegisterAttached("Above", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty BelowProperty { get; } = DependencyProperty.RegisterAttached("Below", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty LeftOfProperty { get; } = DependencyProperty.RegisterAttached("LeftOf", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	public static DependencyProperty RightOfProperty { get; } = DependencyProperty.RegisterAttached("RightOf", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		OnPositioningChanged(s);
	}));


	protected override Size MeasureOverride(Size availableSize)
	{
		SiblingGraph childGraph = GetChildGraph(availableSize);
		return childGraph.MeasureSiblings(availableSize, Padding, base.MeasureElement);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		SiblingGraph childGraph = GetChildGraph(finalSize);
		childGraph.ArrangeSiblings(finalSize, Padding, base.GetElementDesiredSize, base.ArrangeElement);
		return finalSize;
	}

	private SiblingGraph GetChildGraph(Size availableSize)
	{
		IFrameworkElement[] array = base.Children.Select((UIElement c) => c as IFrameworkElement).Trim().ToArray();
		List<IFrameworkElement> list = new List<IFrameworkElement>();
		Dictionary<IFrameworkElement, Dependency[]> dictionary = new Dictionary<IFrameworkElement, Dependency[]>();
		IFrameworkElement[] array2 = array;
		foreach (IFrameworkElement frameworkElement in array2)
		{
			Dependency[] dependencies = GetDependencies((UIElement)frameworkElement, array);
			IFrameworkElement[] dependencies2 = dependencies.SelectToArray((Dependency d) => d.Element);
			ValidateDependencies(array, dependencies2);
			dictionary[frameworkElement] = dependencies;
			OrderChildBasedOnDependencies(frameworkElement, dependencies2, list);
		}
		ValidateCircularReferences(list, dictionary);
		return BuildGraph(list.ToArray(), dictionary);
	}

	private Dependency[] GetDependencies(UIElement child, IFrameworkElement[] allChildren)
	{
		List<Dependency> list = new List<Dependency>(10);
		IFrameworkElement child2 = GetChild(GetAbove(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.Above));
		}
		child2 = GetChild(GetBelow(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.Below));
		}
		child2 = GetChild(GetLeftOf(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.LeftOf));
		}
		child2 = GetChild(GetRightOf(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.RightOf));
		}
		child2 = GetChild(GetAlignBottomWith(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.AlignBottomWith));
		}
		child2 = GetChild(GetAlignHorizontalCenterWith(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.AlignHorizontalCenterWith));
		}
		child2 = GetChild(GetAlignLeftWith(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.AlignLeftWith));
		}
		child2 = GetChild(GetAlignRightWith(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.AlignRightWith));
		}
		child2 = GetChild(GetAlignTopWith(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.AlignTopWith));
		}
		child2 = GetChild(GetAlignVerticalCenterWith(child), allChildren);
		if (child2 != null)
		{
			list.Add(new Dependency(child2, DependencyType.AlignVerticalCenterWith));
		}
		return list.ToArray();
	}

	private void ValidateDependencies(IFrameworkElement[] children, IFrameworkElement[] dependencies)
	{
		foreach (IFrameworkElement value in dependencies)
		{
			if (!children.Contains(value))
			{
				throw new InvalidOperationException("Cannot position an item in relation to a sibling that is not directly located in the RelativePanel.");
			}
		}
	}

	private void OrderChildBasedOnDependencies(IFrameworkElement child, IFrameworkElement[] dependencies, List<IFrameworkElement> orderedChildren)
	{
		if (orderedChildren.Count == 0 || dependencies.Length == 0)
		{
			orderedChildren.Insert(0, child);
			return;
		}
		int index = 0;
		List<IFrameworkElement> list = new List<IFrameworkElement>();
		list.AddRange(dependencies);
		for (int i = 0; i < orderedChildren.Count; i++)
		{
			IFrameworkElement item = orderedChildren[i];
			list.Remove(item);
			index = i + 1;
			if (list.Count == 0)
			{
				break;
			}
		}
		orderedChildren.Insert(index, child);
	}

	private void ValidateCircularReferences(List<IFrameworkElement> orderedChildren, Dictionary<IFrameworkElement, Dependency[]> childrenDependencies)
	{
		List<IFrameworkElement> list = new List<IFrameworkElement>();
		foreach (IFrameworkElement orderedChild in orderedChildren)
		{
			if (childrenDependencies[orderedChild].Select((Dependency d) => d.Element).Except(list).Any())
			{
				throw new ArgumentException("RelativePanel error : Circular dependency detected.  Layout cannot complete.");
			}
			list.Add(orderedChild);
		}
	}

	private SiblingGraph BuildGraph(IFrameworkElement[] orderedChildren, Dictionary<IFrameworkElement, Dependency[]> childrenDependencies)
	{
		SiblingGraph siblingGraph = new SiblingGraph();
		foreach (IFrameworkElement frameworkElement in orderedChildren)
		{
			siblingGraph.AddNode(frameworkElement, childrenDependencies[frameworkElement]);
		}
		return siblingGraph;
	}

	private IFrameworkElement GetChild(object obj, IEnumerable<IFrameworkElement> allChildren)
	{
		if (obj == null)
		{
			return null;
		}
		string name = obj as string;
		if (name.HasValue())
		{
			return allChildren.FirstOrDefault((IFrameworkElement fe) => string.Equals(fe.Name, name));
		}
		if (!(obj is ElementNameSubject elementNameSubject))
		{
			return obj as IFrameworkElement;
		}
		if (elementNameSubject.ElementInstance == null)
		{
			ElementNameSubject.ElementInstanceChangedHandler elementChangedEventHandler = null;
			elementChangedEventHandler = delegate(object sender, object? newInstance)
			{
				InvalidateMeasure();
				if (!(newInstance is ElementStub))
				{
					(sender as ElementNameSubject).ElementInstanceChanged -= elementChangedEventHandler;
				}
			};
			elementNameSubject.ElementInstanceChanged += elementChangedEventHandler;
		}
		return elementNameSubject.ElementInstance as IFrameworkElement;
	}

	private void OnBackgroundSizingChanged(DependencyPropertyChangedEventArgs e)
	{
		OnBackgroundSizingChangedInnerPanel(e);
	}

	private static Brush GetBorderBrushDefaultValue()
	{
		return SolidColorBrushHelper.Transparent;
	}

	private void OnBorderBrushPropertyChanged(Brush oldValue, Brush newValue)
	{
		base.BorderBrushInternal = newValue;
		OnBorderBrushChanged(oldValue, newValue);
	}

	private static Thickness GetBorderThicknessDefaultValue()
	{
		return Thickness.Empty;
	}

	private void OnBorderThicknessPropertyChanged(Thickness oldValue, Thickness newValue)
	{
		base.BorderThicknessInternal = newValue;
		OnBorderThicknessChanged(oldValue, newValue);
	}

	private static Thickness GetPaddingDefaultValue()
	{
		return Thickness.Empty;
	}

	private void OnPaddingPropertyChanged(Thickness oldValue, Thickness newValue)
	{
		base.PaddingInternal = newValue;
		OnPaddingChanged(oldValue, newValue);
	}

	private static CornerRadius GetCornerRadiusDefaultValue()
	{
		return CornerRadius.None;
	}

	private void OnCornerRadiusPropertyChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		base.CornerRadiusInternal = newValue;
		OnCornerRadiusChanged(oldValue, newValue);
	}

	public static bool GetAlignBottomWithPanel(UIElement view)
	{
		return (bool)view.GetValue(AlignBottomWithPanelProperty);
	}

	public static void SetAlignBottomWithPanel(UIElement view, bool value)
	{
		view.SetValue(AlignBottomWithPanelProperty, value);
	}

	public static bool GetAlignLeftWithPanel(UIElement view)
	{
		return (bool)view.GetValue(AlignLeftWithPanelProperty);
	}

	public static void SetAlignLeftWithPanel(UIElement view, bool value)
	{
		view.SetValue(AlignLeftWithPanelProperty, value);
	}

	public static bool GetAlignRightWithPanel(UIElement view)
	{
		return (bool)view.GetValue(AlignRightWithPanelProperty);
	}

	public static void SetAlignRightWithPanel(UIElement view, bool value)
	{
		view.SetValue(AlignRightWithPanelProperty, value);
	}

	public static bool GetAlignTopWithPanel(UIElement view)
	{
		return (bool)view.GetValue(AlignTopWithPanelProperty);
	}

	public static void SetAlignTopWithPanel(UIElement view, bool value)
	{
		view.SetValue(AlignTopWithPanelProperty, value);
	}

	public static bool GetAlignHorizontalCenterWithPanel(UIElement view)
	{
		return (bool)view.GetValue(AlignHorizontalCenterWithPanelProperty);
	}

	public static void SetAlignHorizontalCenterWithPanel(UIElement view, bool value)
	{
		view.SetValue(AlignHorizontalCenterWithPanelProperty, value);
	}

	public static bool GetAlignVerticalCenterWithPanel(UIElement view)
	{
		return (bool)view.GetValue(AlignVerticalCenterWithPanelProperty);
	}

	public static void SetAlignVerticalCenterWithPanel(UIElement view, bool value)
	{
		view.SetValue(AlignVerticalCenterWithPanelProperty, value);
	}

	public static object GetAlignBottomWith(UIElement view)
	{
		return view.GetValue(AlignBottomWithProperty);
	}

	public static void SetAlignBottomWith(UIElement view, object value)
	{
		view.SetValue(AlignBottomWithProperty, value);
	}

	public static object GetAlignLeftWith(UIElement view)
	{
		return view.GetValue(AlignLeftWithProperty);
	}

	public static void SetAlignLeftWith(UIElement view, object value)
	{
		view.SetValue(AlignLeftWithProperty, value);
	}

	public static object GetAlignRightWith(UIElement view)
	{
		return view.GetValue(AlignRightWithProperty);
	}

	public static void SetAlignRightWith(UIElement view, object value)
	{
		view.SetValue(AlignRightWithProperty, value);
	}

	public static object GetAlignTopWith(UIElement view)
	{
		return view.GetValue(AlignTopWithProperty);
	}

	public static void SetAlignTopWith(UIElement view, object value)
	{
		view.SetValue(AlignTopWithProperty, value);
	}

	public static object GetAlignHorizontalCenterWith(UIElement view)
	{
		return view.GetValue(AlignHorizontalCenterWithProperty);
	}

	public static void SetAlignHorizontalCenterWith(UIElement view, object value)
	{
		view.SetValue(AlignHorizontalCenterWithProperty, value);
	}

	public static object GetAlignVerticalCenterWith(UIElement view)
	{
		return view.GetValue(AlignVerticalCenterWithProperty);
	}

	public static void SetAlignVerticalCenterWith(UIElement view, object value)
	{
		view.SetValue(AlignVerticalCenterWithProperty, value);
	}

	public static object GetAbove(UIElement view)
	{
		return view.GetValue(AboveProperty);
	}

	public static void SetAbove(UIElement view, object value)
	{
		view.SetValue(AboveProperty, value);
	}

	public static object GetBelow(UIElement view)
	{
		return view.GetValue(BelowProperty);
	}

	public static void SetBelow(UIElement view, object value)
	{
		view.SetValue(BelowProperty, value);
	}

	public static object GetLeftOf(UIElement view)
	{
		return view.GetValue(LeftOfProperty);
	}

	public static void SetLeftOf(UIElement view, object value)
	{
		view.SetValue(LeftOfProperty, value);
	}

	public static object GetRightOf(UIElement view)
	{
		return view.GetValue(RightOfProperty);
	}

	public static void SetRightOf(UIElement view, object value)
	{
		view.SetValue(RightOfProperty, value);
	}

	private static void OnPositioningChanged(object s)
	{
		if (s is FrameworkElement frameworkElement)
		{
			frameworkElement.InvalidateArrange();
		}
	}

	private BackgroundSizing GetBackgroundSizingValue()
	{
		if (!_BackgroundSizingPropertyBackingFieldSet)
		{
			_BackgroundSizingPropertyBackingField = (BackgroundSizing)GetValue(BackgroundSizingProperty);
			_BackgroundSizingPropertyBackingFieldSet = true;
		}
		return _BackgroundSizingPropertyBackingField;
	}

	private void SetBackgroundSizingValue(BackgroundSizing value)
	{
		SetValue(BackgroundSizingProperty, value);
	}

	private static DependencyProperty CreateBackgroundSizingProperty()
	{
		return DependencyProperty.Register("BackgroundSizing", typeof(BackgroundSizing), typeof(RelativePanel), new FrameworkPropertyMetadata((object)BackgroundSizing.InnerBorderEdge, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((RelativePanel)instance).OnBackgroundSizingChanged(args);
		}, (BackingFieldUpdateCallback)OnBackgroundSizingBackingFieldUpdate));
	}

	private static void OnBackgroundSizingBackingFieldUpdate(object instance, object newValue)
	{
		RelativePanel relativePanel = instance as RelativePanel;
		relativePanel._BackgroundSizingPropertyBackingField = (BackgroundSizing)newValue;
		relativePanel._BackgroundSizingPropertyBackingFieldSet = true;
	}

	private Brush GetBorderBrushValue()
	{
		if (!_BorderBrushPropertyBackingFieldSet)
		{
			_BorderBrushPropertyBackingField = (Brush)GetValue(BorderBrushProperty);
			_BorderBrushPropertyBackingFieldSet = true;
		}
		return _BorderBrushPropertyBackingField;
	}

	private void SetBorderBrushValue(Brush value)
	{
		SetValue(BorderBrushProperty, value);
	}

	private static DependencyProperty CreateBorderBrushProperty()
	{
		return DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(RelativePanel), new FrameworkPropertyMetadata((object)GetBorderBrushDefaultValue(), FrameworkPropertyMetadataOptions.ValueInheritsDataContext, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((RelativePanel)instance).OnBorderBrushPropertyChanged((Brush)args.OldValue, (Brush)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderBrushBackingFieldUpdate));
	}

	private static void OnBorderBrushBackingFieldUpdate(object instance, object newValue)
	{
		RelativePanel relativePanel = instance as RelativePanel;
		relativePanel._BorderBrushPropertyBackingField = (Brush)newValue;
		relativePanel._BorderBrushPropertyBackingFieldSet = true;
	}

	private Thickness GetBorderThicknessValue()
	{
		if (!_BorderThicknessPropertyBackingFieldSet)
		{
			_BorderThicknessPropertyBackingField = (Thickness)GetValue(BorderThicknessProperty);
			_BorderThicknessPropertyBackingFieldSet = true;
		}
		return _BorderThicknessPropertyBackingField;
	}

	private void SetBorderThicknessValue(Thickness value)
	{
		SetValue(BorderThicknessProperty, value);
	}

	private static DependencyProperty CreateBorderThicknessProperty()
	{
		return DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(RelativePanel), new FrameworkPropertyMetadata((object)GetBorderThicknessDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((RelativePanel)instance).OnBorderThicknessPropertyChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderThicknessBackingFieldUpdate));
	}

	private static void OnBorderThicknessBackingFieldUpdate(object instance, object newValue)
	{
		RelativePanel relativePanel = instance as RelativePanel;
		relativePanel._BorderThicknessPropertyBackingField = (Thickness)newValue;
		relativePanel._BorderThicknessPropertyBackingFieldSet = true;
	}

	private Thickness GetPaddingValue()
	{
		if (!_PaddingPropertyBackingFieldSet)
		{
			_PaddingPropertyBackingField = (Thickness)GetValue(PaddingProperty);
			_PaddingPropertyBackingFieldSet = true;
		}
		return _PaddingPropertyBackingField;
	}

	private void SetPaddingValue(Thickness value)
	{
		SetValue(PaddingProperty, value);
	}

	private static DependencyProperty CreatePaddingProperty()
	{
		return DependencyProperty.Register("Padding", typeof(Thickness), typeof(RelativePanel), new FrameworkPropertyMetadata((object)GetPaddingDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((RelativePanel)instance).OnPaddingPropertyChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnPaddingBackingFieldUpdate));
	}

	private static void OnPaddingBackingFieldUpdate(object instance, object newValue)
	{
		RelativePanel relativePanel = instance as RelativePanel;
		relativePanel._PaddingPropertyBackingField = (Thickness)newValue;
		relativePanel._PaddingPropertyBackingFieldSet = true;
	}

	private CornerRadius GetCornerRadiusValue()
	{
		if (!_CornerRadiusPropertyBackingFieldSet)
		{
			_CornerRadiusPropertyBackingField = (CornerRadius)GetValue(CornerRadiusProperty);
			_CornerRadiusPropertyBackingFieldSet = true;
		}
		return _CornerRadiusPropertyBackingField;
	}

	private void SetCornerRadiusValue(CornerRadius value)
	{
		SetValue(CornerRadiusProperty, value);
	}

	private static DependencyProperty CreateCornerRadiusProperty()
	{
		return DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(RelativePanel), new FrameworkPropertyMetadata((object)GetCornerRadiusDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((RelativePanel)instance).OnCornerRadiusPropertyChanged((CornerRadius)args.OldValue, (CornerRadius)args.NewValue);
		}, (BackingFieldUpdateCallback)OnCornerRadiusBackingFieldUpdate));
	}

	private static void OnCornerRadiusBackingFieldUpdate(object instance, object newValue)
	{
		RelativePanel relativePanel = instance as RelativePanel;
		relativePanel._CornerRadiusPropertyBackingField = (CornerRadius)newValue;
		relativePanel._CornerRadiusPropertyBackingFieldSet = true;
	}
}

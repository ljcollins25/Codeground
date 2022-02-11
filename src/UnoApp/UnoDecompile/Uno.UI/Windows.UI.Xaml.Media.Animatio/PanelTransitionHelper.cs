using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Uno.Extensions;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Media.Animation;

internal class PanelTransitionHelper
{
	private class ChildWithOffset
	{
		public UIElement Element { get; set; }

		public int OffsetX { get; set; }

		public int OffsetY { get; set; }
	}

	private readonly Panel _source;

	private Storyboard _onLoadedStoryboard;

	private bool _onLoadedisAnimating;

	private bool _onUpdatedIsAnimating;

	private Storyboard _onUpdatedStoryboard;

	private Dictionary<UIElement, Point> _childsInitialPositions = new Dictionary<UIElement, Point>();

	private List<ChildWithOffset> _modifiedChildWithOffset = new List<ChildWithOffset>();

	private List<IFrameworkElement> _previouslyAddedElements = new List<IFrameworkElement>();

	private List<IFrameworkElement> _elements = new List<IFrameworkElement>();

	internal PanelTransitionHelper(Panel source)
	{
		_source = source;
	}

	internal void SetInitialChildrenPositions()
	{
		_childsInitialPositions = GetChildrenPositionsFromSource();
	}

	private Dictionary<UIElement, Point> GetChildrenPositionsFromSource()
	{
		return new Dictionary<UIElement, Point>();
	}

	internal void AddElement(IFrameworkElement element)
	{
		if (element.Transitions.Safe().Any())
		{
			return;
		}
		_elements.Add(element);
		_previouslyAddedElements.Add(element);
		if (!_onLoadedisAnimating)
		{
			_onLoadedisAnimating = true;
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				RunOnLoadedAnimations();
				_onLoadedisAnimating = false;
			});
		}
	}

	private void RunOnLoadedAnimations()
	{
		if (_onLoadedStoryboard != null)
		{
			_onLoadedStoryboard.Stop();
		}
		_onLoadedStoryboard = new Storyboard();
		TimeSpan beginTime = TimeSpan.Zero;
		foreach (IFrameworkElement item in _source.Children.OfType<IFrameworkElement>())
		{
			if (item.Transitions.Safe().Any() || !_elements.Contains(item))
			{
				continue;
			}
			foreach (Transition childrenTransition in _source.ChildrenTransitions)
			{
				if (!(childrenTransition is RepositionThemeTransition))
				{
					childrenTransition.AttachToStoryboardAnimation(_onLoadedStoryboard, item, beginTime);
				}
			}
			beginTime = beginTime.Add(TimeSpan.FromMilliseconds(100.0));
		}
		_elements.Clear();
		_onLoadedStoryboard.Begin();
	}

	internal void LayoutUpdatedTransition()
	{
		Dictionary<UIElement, Point> childrenPositionsFromSource = GetChildrenPositionsFromSource();
		foreach (KeyValuePair<UIElement, Point> childPosition in _childsInitialPositions)
		{
			if (_previouslyAddedElements.Contains(childPosition.Key as IFrameworkElement))
			{
				continue;
			}
			KeyValuePair<UIElement, Point> keyValuePair = childrenPositionsFromSource.First((KeyValuePair<UIElement, Point> pair) => pair.Key == childPosition.Key);
			if (keyValuePair.Key is IFrameworkElement frameworkElement && !frameworkElement.Transitions.Safe().Any())
			{
				int num = childPosition.Value.X - keyValuePair.Value.X;
				int num2 = childPosition.Value.Y - keyValuePair.Value.Y;
				if (num != 0 || num2 != 0)
				{
					ChildWithOffset item = new ChildWithOffset
					{
						Element = childPosition.Key,
						OffsetX = num,
						OffsetY = num2
					};
					_modifiedChildWithOffset.Add(item);
					frameworkElement.RenderTransform = new TranslateTransform
					{
						X = num,
						Y = num2
					};
				}
			}
		}
		if (!_onUpdatedIsAnimating)
		{
			_onUpdatedIsAnimating = true;
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				RunLayoutUpdatedAnimations();
				_onUpdatedIsAnimating = false;
			});
		}
	}

	private void RunLayoutUpdatedAnimations()
	{
		_onUpdatedStoryboard = new Storyboard();
		TimeSpan beginTime = TimeSpan.Zero;
		foreach (ChildWithOffset item in _modifiedChildWithOffset)
		{
			Transition transition = _source.ChildrenTransitions.First((Transition t) => t is RepositionThemeTransition);
			transition.AttachToStoryboardAnimation(_onUpdatedStoryboard, (IFrameworkElement)item.Element, beginTime, item.OffsetX, item.OffsetY);
			beginTime = beginTime.Add(TimeSpan.FromMilliseconds(40.0));
		}
		_modifiedChildWithOffset.Clear();
		_previouslyAddedElements.Clear();
		_onUpdatedStoryboard.Begin();
	}
}

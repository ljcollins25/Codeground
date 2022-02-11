using System;
using System.Collections.Generic;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class ElementAnimator
{
	private enum AnimationTrigger
	{
		Show,
		Hide,
		BoundsChange
	}

	private struct ElementInfo
	{
		public UIElement Element { get; }

		public AnimationTrigger Trigger { get; }

		public AnimationContext Context { get; }

		public Rect OldBounds { get; }

		public Rect NewBounds { get; }

		public ElementInfo(UIElement element, AnimationTrigger trigger, AnimationContext context)
		{
			Element = element;
			Trigger = trigger;
			Context = context;
			OldBounds = default(Rect);
			NewBounds = default(Rect);
		}

		public ElementInfo(UIElement element, AnimationTrigger trigger, AnimationContext context, Rect oldBounds, Rect newBounds)
		{
			Element = element;
			Trigger = trigger;
			Context = context;
			OldBounds = oldBounds;
			NewBounds = newBounds;
		}
	}

	private readonly List<ElementInfo> m_animatingElements = new List<ElementInfo>();

	protected bool HasShowAnimationsPending { get; private set; }

	protected bool HasHideAnimationsPending { get; private set; }

	protected bool HasBoundsChangeAnimationsPending { get; private set; }

	protected AnimationContext SharedContext { get; private set; }

	public event ElementAnimationCompleted BoundsChangeAnimationCompleted;

	public event ElementAnimationCompleted HideAnimationCompleted;

	public event ElementAnimationCompleted ShowAnimationCompleted;

	public void OnElementShown(UIElement element, AnimationContext context)
	{
		if (HasShowAnimation(element, context))
		{
			HasShowAnimationsPending = true;
			SharedContext |= context;
			QueueElementForAnimation(new ElementInfo(element, AnimationTrigger.Show, context));
		}
	}

	public void OnElementHidden(UIElement element, AnimationContext context)
	{
		if (HasHideAnimation(element, context))
		{
			HasHideAnimationsPending = true;
			SharedContext |= context;
			QueueElementForAnimation(new ElementInfo(element, AnimationTrigger.Hide, context));
		}
	}

	public void OnElementBoundsChanged(UIElement element, AnimationContext context, Rect oldBounds, Rect newBounds)
	{
		if (HasBoundsChangeAnimation(element, context, oldBounds, newBounds))
		{
			HasBoundsChangeAnimationsPending = true;
			SharedContext |= context;
			QueueElementForAnimation(new ElementInfo(element, AnimationTrigger.BoundsChange, context, oldBounds, newBounds));
		}
	}

	public bool HasShowAnimation(UIElement element, AnimationContext context)
	{
		return HasShowAnimationCore(element, context);
	}

	public bool HasHideAnimation(UIElement element, AnimationContext context)
	{
		return HasHideAnimationCore(element, context);
	}

	public bool HasBoundsChangeAnimation(UIElement element, AnimationContext context, Rect oldBounds, Rect newBounds)
	{
		return HasBoundsChangeAnimationCore(element, context, oldBounds, newBounds);
	}

	protected virtual bool HasShowAnimationCore(UIElement element, AnimationContext context)
	{
		throw new NotImplementedException();
	}

	protected virtual bool HasHideAnimationCore(UIElement element, AnimationContext context)
	{
		throw new NotImplementedException();
	}

	protected virtual bool HasBoundsChangeAnimationCore(UIElement element, AnimationContext context, Rect oldBounds, Rect newBounds)
	{
		throw new NotImplementedException();
	}

	protected virtual void StartShowAnimation(UIElement element, AnimationContext context)
	{
		throw new NotImplementedException();
	}

	protected virtual void StartHideAnimation(UIElement element, AnimationContext context)
	{
		throw new NotImplementedException();
	}

	protected virtual void StartBoundsChangeAnimation(UIElement element, AnimationContext context, Rect oldBounds, Rect newBounds)
	{
		throw new NotImplementedException();
	}

	protected void OnShowAnimationCompleted(UIElement element)
	{
		this.ShowAnimationCompleted?.Invoke(this, element);
	}

	protected void OnHideAnimationCompleted(UIElement element)
	{
		this.HideAnimationCompleted?.Invoke(this, element);
	}

	protected void OnBoundsChangeAnimationCompleted(UIElement element)
	{
		this.BoundsChangeAnimationCompleted?.Invoke(this, element);
	}

	private void QueueElementForAnimation(ElementInfo elementInfo)
	{
		m_animatingElements.Add(elementInfo);
		if (m_animatingElements.Count == 1)
		{
			CompositionTarget.Rendering += OnRendering;
		}
	}

	private void OnRendering(object snd, object args)
	{
		CompositionTarget.Rendering -= OnRendering;
		using (Disposable.Create(ResetState))
		{
			foreach (ElementInfo animatingElement in m_animatingElements)
			{
				switch (animatingElement.Trigger)
				{
				case AnimationTrigger.Show:
					StartShowAnimation(animatingElement.Element, animatingElement.Context);
					break;
				case AnimationTrigger.Hide:
					StartHideAnimation(animatingElement.Element, animatingElement.Context);
					break;
				case AnimationTrigger.BoundsChange:
					StartBoundsChangeAnimation(animatingElement.Element, animatingElement.Context, animatingElement.OldBounds, animatingElement.NewBounds);
					break;
				}
			}
		}
	}

	private void ResetState()
	{
		m_animatingElements.Clear();
		bool flag2 = (HasBoundsChangeAnimationsPending = false);
		bool hasShowAnimationsPending = (HasHideAnimationsPending = flag2);
		HasShowAnimationsPending = hasShowAnimationsPending;
		SharedContext = AnimationContext.None;
	}
}

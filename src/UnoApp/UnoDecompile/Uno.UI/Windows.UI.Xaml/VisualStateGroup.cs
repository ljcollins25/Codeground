using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml;

[ContentProperty(Name = "States")]
[Windows.UI.Xaml.Data.Bindable]
public sealed class VisualStateGroup : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private readonly XamlScope _xamlScope;

	private (VisualState state, VisualTransition transition) _current;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public VisualState CurrentState => _current.state;

	public string Name { get; set; }

	public IList<VisualState> States
	{
		get
		{
			IList<VisualState> list = (IList<VisualState>)GetValue(StatesProperty);
			if (list == null)
			{
				DependencyObjectCollection<VisualState> dependencyObjectCollection = new DependencyObjectCollection<VisualState>(this, isAutoPropertyInheritanceEnabled: false);
				list = dependencyObjectCollection;
				SetValue(StatesProperty, list);
			}
			return list;
		}
		internal set
		{
			SetValue(StatesProperty, value);
		}
	}

	public static DependencyProperty StatesProperty { get; } = DependencyProperty.Register("States", typeof(IList<VisualState>), typeof(VisualStateGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VisualStateGroup)s)?.OnStatesChanged(e);
	}));


	public IList<VisualTransition> Transitions
	{
		get
		{
			IList<VisualTransition> list = (IList<VisualTransition>)GetValue(TransitionsProperty);
			if (list == null)
			{
				list = new DependencyObjectCollection<VisualTransition>(this, isAutoPropertyInheritanceEnabled: false);
				SetValue(TransitionsProperty, list);
			}
			return list;
		}
		internal set
		{
			SetValue(TransitionsProperty, value);
		}
	}

	public static DependencyProperty TransitionsProperty { get; } = DependencyProperty.Register("Transitions", typeof(IList<VisualTransition>), typeof(VisualStateGroup), new FrameworkPropertyMetadata((object)null));


	public CoreDispatcher Dispatcher => CoreApplication.MainView.Dispatcher;

	private DependencyObjectStore __Store
	{
		get
		{
			if (__storeBackingField == null)
			{
				__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);
				__InitializeBinder();
			}
			return __storeBackingField;
		}
	}

	public bool IsStoreInitialized => __storeBackingField != null;

	DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;

	ManagedWeakReference IWeakReferenceProvider.WeakReference
	{
		get
		{
			if (_selfWeakReference == null)
			{
				_selfWeakReference = WeakReferencePool.RentSelfWeakReference(this);
			}
			return _selfWeakReference;
		}
	}

	public object DataContext
	{
		get
		{
			return GetValue(DataContextProperty);
		}
		set
		{
			SetValue(DataContextProperty, value);
		}
	}

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(VisualStateGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VisualStateGroup)s).OnDataContextChanged(e);
	}));


	public DependencyObject TemplatedParent
	{
		get
		{
			return (DependencyObject)GetValue(TemplatedParentProperty);
		}
		set
		{
			SetValue(TemplatedParentProperty, value);
		}
	}

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(VisualStateGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VisualStateGroup)s).OnTemplatedParentChanged(e);
	}));


	[EditorBrowsable(EditorBrowsableState.Never)]
	internal bool IsAutoPropertyInheritanceEnabled
	{
		get
		{
			return __Store.IsAutoPropertyInheritanceEnabled;
		}
		set
		{
			__Store.IsAutoPropertyInheritanceEnabled = value;
		}
	}

	public event VisualStateChangedEventHandler CurrentStateChanging;

	public event VisualStateChangedEventHandler CurrentStateChanged;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	public VisualStateGroup()
	{
		_xamlScope = ResourceResolver.CurrentScope;
		IsAutoPropertyInheritanceEnabled = false;
		this.RegisterParentChangedCallback(this, OnParentChanged);
	}

	private void OnStatesChanged(DependencyPropertyChangedEventArgs e)
	{
		if (e.OldValue is DependencyObjectCollection<VisualState> dependencyObjectCollection)
		{
			dependencyObjectCollection.VectorChanged -= VisualStateChanged;
		}
		if (e.NewValue is DependencyObjectCollection<VisualState> dependencyObjectCollection2)
		{
			dependencyObjectCollection2.VectorChanged += VisualStateChanged;
		}
		RefreshStateTriggers();
	}

	private void VisualStateChanged(object sender, IVectorChangedEventArgs e)
	{
		RefreshStateTriggers();
	}

	private void OnParentChanged(object instance, object key, DependencyObjectParentChangedEventArgs args)
	{
		RefreshStateTriggers(force: true);
	}

	internal void RaiseCurrentStateChanging(VisualState oldState, VisualState newState)
	{
		if (this.CurrentStateChanging != null)
		{
			this.CurrentStateChanging(this, new VisualStateChangedEventArgs
			{
				Control = FindFirstAncestorControl(),
				NewState = newState,
				OldState = oldState
			});
		}
	}

	internal void RaiseCurrentStateChanged(VisualState oldState, VisualState newState)
	{
		if (this.CurrentStateChanged != null)
		{
			this.CurrentStateChanged(this, new VisualStateChangedEventArgs
			{
				Control = FindFirstAncestorControl(),
				NewState = newState,
				OldState = oldState
			});
		}
	}

	private Control FindFirstAncestorControl()
	{
		return (this.GetParent() as FrameworkElement)?.FindFirstParent<Control>();
	}

	internal void GoToState(IFrameworkElement element, VisualState state, bool useTransitions, Action onStateChanged)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("Go to state [{0}/{1}] on [{2}]", Name, state?.Name, element);
		}
		(VisualState, VisualTransition) current = _current;
		(VisualState, VisualTransition) current2 = (state, FindTransition(current.Item1?.Name, state?.Name));
		ResourceResolver.PushNewScope(_xamlScope);
		(Storyboard, Storyboard, SetterBaseCollection) tuple = (current.Item2?.Storyboard, current.Item1?.Storyboard, current.Item1?.Setters);
		(Storyboard transition, Storyboard animation, SetterBaseCollection setters) target = (current2.Item2?.Storyboard, current2.Item1?.Storyboard, current2.Item1?.Setters);
		ResourceResolver.PopScope();
		Storyboard storyboard;
		if ((tuple.Item1?.State ?? Timeline.TimelineState.Stopped) != Timeline.TimelineState.Stopped)
		{
			(storyboard, _, _) = tuple;
		}
		else
		{
			storyboard = tuple.Item2;
		}
		Storyboard storyboard2 = storyboard;
		Storyboard storyboard3 = target.transition ?? target.animation;
		if (storyboard2 != null)
		{
			if (storyboard3 == null)
			{
				storyboard2.Stop();
			}
			else
			{
				storyboard2.TurnOverAnimationsTo(storyboard3);
			}
		}
		SetterBaseCollection item = tuple.Item3;
		if (item != null)
		{
			IEnumerator<Setter> enumerator = item.OfType<Setter>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				Setter setter = enumerator.Current;
				if (element != null)
				{
					SetterBaseCollection item2 = target.setters;
					if (item2 != null && item2.OfType<Setter>().Any((Setter o) => o.HasSameTarget(setter, DependencyPropertyValuePrecedences.Animations, element)))
					{
						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							this.Log().Debug($"Ignoring reset of setter of '{setter.Target?.Path}' as it will be updated again by '{state.Name}'");
						}
						continue;
					}
				}
				setter.ClearValue();
			}
		}
		_current = current2;
		if (FeatureConfiguration.VisualState.ApplySettersBeforeTransition)
		{
			ApplyTargetStateSetters();
		}
		Storyboard transitionAnimation;
		if (useTransitions)
		{
			transitionAnimation = target.transition;
			if (transitionAnimation != null)
			{
				transitionAnimation.Completed += OnTransitionCompleted;
				transitionAnimation.Begin();
				return;
			}
		}
		ApplyTargetState();
		void ApplyTargetState()
		{
			if (!FeatureConfiguration.VisualState.ApplySettersBeforeTransition)
			{
				ApplyTargetStateSetters();
			}
			target.animation?.Begin();
			onStateChanged();
		}
		void ApplyTargetStateSetters()
		{
			if (target.setters != null && element != null)
			{
				ResourceResolver.PushNewScope(_xamlScope);
				IEnumerator<Setter> enumerator2 = target.setters.OfType<Setter>().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.ApplyValue(DependencyPropertyValuePrecedences.Animations, element);
				}
				ResourceResolver.PopScope();
			}
		}
		void OnTransitionCompleted(object s, object a)
		{
			transitionAnimation.Completed -= OnTransitionCompleted;
			Storyboard item3 = target.animation;
			if (item3 != null)
			{
				transitionAnimation.TurnOverAnimationsTo(item3);
			}
			ApplyTargetState();
		}
	}

	private VisualTransition FindTransition(string oldStateName, string newStateName)
	{
		bool flag = oldStateName.HasValue();
		bool flag2 = newStateName.HasValue();
		if (flag && flag2)
		{
			VisualTransition visualTransition = Transitions.FirstOrDefault(Match(oldStateName, newStateName));
			if (visualTransition != null)
			{
				return visualTransition;
			}
		}
		if (flag)
		{
			VisualTransition visualTransition2 = Transitions.FirstOrDefault(Match(oldStateName, null));
			if (visualTransition2 != null)
			{
				return visualTransition2;
			}
		}
		if (flag2)
		{
			VisualTransition visualTransition3 = Transitions.FirstOrDefault(Match(null, newStateName));
			if (visualTransition3 != null)
			{
				return visualTransition3;
			}
		}
		return null;
		Func<VisualTransition, bool> Match(string from, string to)
		{
			return (VisualTransition tr) => string.Equals(tr.From, oldStateName) && string.Equals(tr.To, newStateName);
		}
	}

	internal void RefreshStateTriggers(bool force = false)
	{
		VisualState newState = GetActiveTrigger();
		VisualState oldState = CurrentState;
		if (newState == oldState)
		{
			if (!force)
			{
				return;
			}
			if (newState == null)
			{
				OnStateChanged();
				return;
			}
		}
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"[{this}].RefreshStateTriggers() activeState={newState}, oldState={oldState}");
		}
		IFrameworkElement element = this.GetParent() as IFrameworkElement;
		GoToState(element, newState, useTransitions: false, OnStateChanged);
		void OnStateChanged()
		{
			RaiseCurrentStateChanged(oldState, newState);
		}
	}

	private VisualState GetActiveTrigger()
	{
		VisualState visualState = null;
		VisualState visualState2 = null;
		for (int i = 0; i < States.Count; i++)
		{
			VisualState visualState3 = States[i];
			for (int j = 0; j < visualState3.StateTriggers.Count; j++)
			{
				StateTriggerBase stateTriggerBase = visualState3.StateTriggers[j];
				if (stateTriggerBase.CurrentPrecedence == StateTriggerPrecedence.CustomTrigger)
				{
					return visualState3;
				}
				if (stateTriggerBase.CurrentPrecedence == StateTriggerPrecedence.MinWidthTrigger && visualState == null)
				{
					visualState = visualState3;
					if (visualState2 != null)
					{
						break;
					}
				}
				else if (stateTriggerBase.CurrentPrecedence == StateTriggerPrecedence.MinHeightTrigger && visualState2 == null)
				{
					visualState2 = visualState3;
					if (visualState != null)
					{
						break;
					}
				}
			}
			if (visualState != null && visualState2 != null)
			{
				break;
			}
		}
		return visualState ?? visualState2;
	}

	public override string ToString()
	{
		return Name ?? $"<unnamed group {GetHashCode()}>";
	}

	public object GetValue(DependencyProperty dp)
	{
		return __Store.GetValue(dp);
	}

	public void SetValue(DependencyProperty dp, object value)
	{
		__Store.SetValue(dp, value);
	}

	public void ClearValue(DependencyProperty dp)
	{
		__Store.ClearValue(dp);
	}

	public object ReadLocalValue(DependencyProperty dp)
	{
		return __Store.ReadLocalValue(dp);
	}

	public object GetAnimationBaseValue(DependencyProperty dp)
	{
		return __Store.GetAnimationBaseValue(dp);
	}

	public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback)
	{
		return __Store.RegisterPropertyChangedCallback(dp, callback);
	}

	public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token)
	{
		__Store.UnregisterPropertyChangedCallback(dp, token);
	}

	private void __InitializeBinder()
	{
		if (BinderReferenceHolder.IsEnabled)
		{
			_refHolder = new BinderReferenceHolder(GetType(), this);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ClearBindings()
	{
		__Store.ClearBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RestoreBindings()
	{
		__Store.RestoreBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyCompiledBindings()
	{
	}

	private void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		this.DataContextChanged?.Invoke(null, new DataContextChangedEventArgs(DataContext));
	}

	private void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		__Store.SetTemplatedParent(e.NewValue as FrameworkElement);
	}

	public void SetBinding(object target, string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(target, dependencyProperty, binding);
	}

	public void SetBinding(string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBinding(DependencyProperty dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBindingValue(object value, [CallerMemberName] string propertyName = null)
	{
		__Store.SetBindingValue(value, propertyName);
	}

	public BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return __Store.GetBindingExpression(dependencyProperty);
	}

	public void ResumeBindings()
	{
		__Store.ResumeBindings();
	}

	public void SuspendBindings()
	{
		__Store.SuspendBindings();
	}
}

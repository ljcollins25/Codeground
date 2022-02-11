using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Media.Animation;

[Windows.UI.Xaml.Data.Bindable]
public class Timeline : DependencyObject, ITimeline, IDisposable, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private protected class AnimationImplementation<T> : IDisposable where T : struct
	{
		public static class TraceProvider
		{
			public static readonly Guid Id = Guid.Parse("{CC14F7B2-D92B-429D-81A4-E1E7A1B13D3D}");

			public const int Start = 1;

			public const int Stop = 2;

			public const int Pause = 3;

			public const int Resume = 4;
		}

		private static readonly IEventProvider _trace = Tracing.Get(TraceProvider.Id);

		private Timeline _owner;

		private EventActivity _traceActivity;

		private readonly Stopwatch _activeDuration = new Stopwatch();

		private int _replayCount = 1;

		private T? _startingValue;

		private T? _endValue;

		private readonly CompositeDisposable _subscriptions = new CompositeDisposable(0);

		private IValueAnimator _animator;

		private IAnimation<T> AnimationOwner => _owner as IAnimation<T>;

		private TimelineState State
		{
			get
			{
				return _owner?.State ?? TimelineState.Active;
			}
			set
			{
				if (_owner != null)
				{
					_owner.State = value;
				}
			}
		}

		private TimeSpan? BeginTime => _owner?.BeginTime;

		private Duration Duration => _owner?.Duration ?? default(Duration);

		private FillBehavior FillBehavior => _owner?.FillBehavior ?? FillBehavior.HoldEnd;

		private T? From => AnimationOwner?.From;

		private T? To => AnimationOwner?.To;

		private T? By => AnimationOwner?.By;

		private IEasingFunction EasingFunction => AnimationOwner?.EasingFunction;

		private bool EnableDependentAnimation => AnimationOwner?.EnableDependentAnimation ?? false;

		private DependencyObject Target => _owner?.Target;

		private BindingPath PropertyInfo => _owner?.PropertyInfo;

		public AnimationImplementation(Timeline owner)
		{
			_owner = owner;
		}

		private string[] GetTraceProperties()
		{
			return _owner?.GetTraceProperties();
		}

		private void ClearValue()
		{
			_owner?.ClearValue();
		}

		private void SetValue(object value)
		{
			_owner?.SetValue(value);
		}

		private bool NeedsRepeat(Stopwatch activeDuration, int replayCount)
		{
			return _owner?.NeedsRepeat(activeDuration, replayCount) ?? false;
		}

		private object GetValue()
		{
			return _owner?.GetValue();
		}

		public void Begin()
		{
			if (_trace.IsEnabled)
			{
				IEventProvider trace = _trace;
				object[] traceProperties = GetTraceProperties();
				_traceActivity = trace.WriteEventActivity(1, EventOpcode.Start, traceProperties);
			}
			PropertyInfo?.CloneShareableObjectsInPath();
			_subscriptions.Clear();
			_activeDuration.Restart();
			_replayCount = 1;
			Play();
		}

		public void Stop()
		{
			if (_trace.IsEnabled)
			{
				IEventProvider trace = _trace;
				EventActivity traceActivity = _traceActivity;
				object[] traceProperties = GetTraceProperties();
				trace.WriteEventActivity(2, EventOpcode.Stop, traceActivity, traceProperties);
			}
			_animator?.Cancel();
			_startingValue = null;
			ClearValue();
			State = TimelineState.Stopped;
		}

		public void Resume()
		{
			if (State == TimelineState.Paused)
			{
				if (_trace.IsEnabled)
				{
					IEventProvider trace = _trace;
					EventActivity traceActivity = _traceActivity;
					object[] traceProperties = GetTraceProperties();
					trace.WriteEventActivity(4, EventOpcode.Send, traceActivity, traceProperties);
				}
				_animator.Resume();
				State = TimelineState.Active;
			}
		}

		public void Pause()
		{
			if (State != TimelineState.Paused)
			{
				if (_trace.IsEnabled)
				{
					IEventProvider trace = _trace;
					EventActivity traceActivity = _traceActivity;
					object[] traceProperties = GetTraceProperties();
					trace.WriteEventActivity(3, EventOpcode.Send, traceActivity, traceProperties);
				}
				_animator.Pause();
				State = TimelineState.Paused;
			}
		}

		public void Seek(TimeSpan offset)
		{
			_animator.CurrentPlayTime = (long)offset.TotalMilliseconds;
			if (State == TimelineState.Active || State == TimelineState.Paused)
			{
				CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
				{
					OnFrame();
					_animator.Pause();
				});
			}
		}

		public void SeekAlignedToLastTick(TimeSpan offset)
		{
			Seek(offset);
		}

		public void SkipToFill()
		{
			if (_animator != null && _animator.IsRunning)
			{
				_animator.Cancel();
				_startingValue = null;
			}
			SetValue(ComputeToValue());
			OnEnd();
		}

		public void Deactivate()
		{
			_animator?.Cancel();
			_startingValue = null;
			State = TimelineState.Stopped;
		}

		private void Replay()
		{
			_replayCount++;
			Play();
		}

		private void InitializeAnimator()
		{
			_startingValue = ComputeFromValue();
			_endValue = ComputeToValue();
			_animator = AnimatorFactory.Create(_owner, _startingValue.Value, _endValue.Value);
			_animator.SetEasingFunction(EasingFunction);
			SetAnimatorDuration();
			_animator.DisposeWith(_subscriptions);
			if (ReportEachFrame())
			{
				_animator.Update += OnAnimatorUpdate;
			}
			else
			{
				_animator.AnimationEnd += OnAnimatorAnimationEndFrame;
			}
			_animator.AnimationEnd += OnAnimatorAnimationEnd;
			_animator.AnimationCancel += OnAnimatorCancelled;
			_animator.AnimationFailed += OnAnimatorFailed;
		}

		private void OnAnimatorAnimationEnd(object sender, EventArgs e)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("DoubleAnimation has ended.");
			}
			OnEnd();
			_startingValue = null;
		}

		private void OnAnimatorAnimationEndFrame(object sender, EventArgs e)
		{
			OnFrame();
		}

		private void OnAnimatorAnimationPause(object sender, EventArgs e)
		{
			OnFrame();
		}

		private void OnAnimatorUpdate(object sender, EventArgs e)
		{
			OnFrame();
		}

		private void Play()
		{
			InitializeAnimator();
			if (EnableDependentAnimation || !_owner.GetIsDependantAnimation())
			{
				if (BeginTime.HasValue)
				{
					_animator.StartDelay = (long)BeginTime.Value.TotalMilliseconds;
				}
				_animator.Start();
				State = TimelineState.Active;
			}
		}

		private void SetAnimatorDuration()
		{
			switch (Duration.Type)
			{
			case DurationType.Automatic:
				_animator.SetDuration(1000L);
				break;
			case DurationType.Forever:
				_animator.SetDuration(long.MaxValue);
				break;
			case DurationType.TimeSpan:
				_animator.SetDuration((long)Duration.TimeSpan.TotalMilliseconds);
				break;
			}
		}

		private void OnEnd()
		{
			if (NeedsRepeat(_activeDuration, _replayCount))
			{
				Replay();
				return;
			}
			if (FillBehavior == FillBehavior.HoldEnd)
			{
				State = TimelineState.Filling;
			}
			else
			{
				State = TimelineState.Stopped;
				ClearValue();
			}
			_owner.OnCompleted();
		}

		private void OnAnimatorFailed(object sender, EventArgs e)
		{
			State = TimelineState.Stopped;
			ClearValue();
			_owner.OnFailed();
		}

		private void OnAnimatorCancelled(object sender, EventArgs e)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("DoubleAnimation was cancelled.");
			}
			State = TimelineState.Stopped;
		}

		private T ComputeFromValue()
		{
			if (From.HasValue)
			{
				return From.Value;
			}
			if (By.HasValue && To.HasValue)
			{
				return AnimationOwner.Subtract(To.Value, By.Value);
			}
			return GetDefaultTargetValue().GetValueOrDefault();
		}

		private T? GetDefaultTargetValue()
		{
			if (_startingValue.HasValue)
			{
				return _startingValue;
			}
			object value = GetValue();
			if (value != null)
			{
				return AnimationOwner.Convert(value);
			}
			return null;
		}

		private T ComputeToValue()
		{
			if (To.HasValue)
			{
				return To.Value;
			}
			if (!By.HasValue)
			{
				return GetDefaultTargetValue().GetValueOrDefault();
			}
			if (!From.HasValue)
			{
				return AnimationOwner.Add(GetDefaultTargetValue().GetValueOrDefault(), By.Value);
			}
			return AnimationOwner.Add(From.Value, By.Value);
		}

		public void Dispose()
		{
			_subscriptions.Dispose();
			_owner = null;
		}

		private void OnFrame()
		{
			SetValue(_animator.AnimatedValue);
		}

		private bool ReportEachFrame()
		{
			return true;
		}
	}

	internal enum TimelineState
	{
		Active,
		Filling,
		Stopped,
		Paused
	}

	private WeakReference<DependencyObject> _targetElement;

	private BindingPath _propertyInfo;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double SpeedRatio
	{
		get
		{
			return (double)GetValue(SpeedRatioProperty);
		}
		set
		{
			SetValue(SpeedRatioProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AutoReverse
	{
		get
		{
			return (bool)GetValue(AutoReverseProperty);
		}
		set
		{
			SetValue(AutoReverseProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool AllowDependentAnimations
	{
		get
		{
			throw new NotImplementedException("The member bool Timeline.AllowDependentAnimations is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.Timeline", "bool Timeline.AllowDependentAnimations");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AutoReverseProperty { get; } = DependencyProperty.Register("AutoReverse", typeof(bool), typeof(Timeline), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SpeedRatioProperty { get; } = DependencyProperty.Register("SpeedRatio", typeof(double), typeof(Timeline), new FrameworkPropertyMetadata(0.0));


	internal TimelineState State { get; private protected set; }

	public TimeSpan? BeginTime
	{
		get
		{
			return (TimeSpan?)GetValue(BeginTimeProperty);
		}
		set
		{
			SetValue(BeginTimeProperty, value);
		}
	}

	public static DependencyProperty BeginTimeProperty { get; } = DependencyProperty.Register("BeginTime", typeof(TimeSpan?), typeof(Timeline), new FrameworkPropertyMetadata(TimeSpan.Zero));


	public Duration Duration
	{
		get
		{
			return (Duration)GetValue(DurationProperty);
		}
		set
		{
			SetValue(DurationProperty, value);
		}
	}

	public static DependencyProperty DurationProperty { get; } = DependencyProperty.Register("Duration", typeof(Duration), typeof(Timeline), new FrameworkPropertyMetadata(Duration.Automatic));


	public FillBehavior FillBehavior
	{
		get
		{
			return (FillBehavior)GetValue(FillBehaviorProperty);
		}
		set
		{
			SetValue(FillBehaviorProperty, value);
		}
	}

	public static DependencyProperty FillBehaviorProperty { get; } = DependencyProperty.Register("FillBehavior", typeof(FillBehavior), typeof(Timeline), new FrameworkPropertyMetadata(FillBehavior.HoldEnd));


	public RepeatBehavior RepeatBehavior
	{
		get
		{
			return (RepeatBehavior)GetValue(RepeatBehaviorProperty);
		}
		set
		{
			SetValue(RepeatBehaviorProperty, value);
		}
	}

	public static DependencyProperty RepeatBehaviorProperty { get; } = DependencyProperty.Register("RepeatBehavior", typeof(RepeatBehavior), typeof(Timeline), new FrameworkPropertyMetadata(default(RepeatBehavior)));


	internal DependencyObject Target
	{
		get
		{
			return _targetElement?.GetTarget();
		}
		set
		{
			_targetElement = new WeakReference<DependencyObject>(value);
		}
	}

	internal BindingPath PropertyInfo
	{
		get
		{
			string targetProperty = Storyboard.GetTargetProperty(this);
			InitTarget();
			DependencyObject dependencyObject = Target ?? GetTargetFromName();
			if (_propertyInfo == null || _propertyInfo.Path != targetProperty)
			{
				if (_propertyInfo != null)
				{
					_propertyInfo.DataContext = null;
					_propertyInfo.Dispose();
				}
				_propertyInfo = new BindingPath(targetProperty, null, DependencyPropertyValuePrecedences.Animations, allowPrivateMembers: false)
				{
					DataContext = dependencyObject
				};
				return _propertyInfo;
			}
			if (_propertyInfo.DataContext != dependencyObject)
			{
				_propertyInfo.DataContext = dependencyObject;
			}
			return _propertyInfo;
		}
	}

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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(Timeline), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Timeline)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(Timeline), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Timeline)s).OnTemplatedParentChanged(e);
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

	public event EventHandler<object> Completed;

	internal event EventHandler<object> Failed;

	event EventHandler<object> ITimeline.Failed
	{
		add
		{
			Failed += value;
		}
		remove
		{
			Failed += value;
		}
	}

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	public Timeline()
	{
		IsAutoPropertyInheritanceEnabled = false;
		State = TimelineState.Stopped;
	}

	protected string[] GetTraceProperties()
	{
		return new string[4]
		{
			this.GetParent()?.GetType().Name,
			this.GetParent()?.GetDependencyObjectId().ToString(),
			Target?.GetType().ToString(),
			PropertyInfo?.Path
		};
	}

	protected void OnCompleted()
	{
		this.Completed?.Invoke(this, null);
	}

	protected void OnFailed()
	{
		this.Failed?.Invoke(this, null);
	}

	internal virtual TimeSpan GetCalculatedDuration()
	{
		switch (Duration.Type)
		{
		case DurationType.Forever:
			return TimeSpan.MaxValue;
		case DurationType.TimeSpan:
			if (Duration.TimeSpan > TimeSpan.Zero)
			{
				return Duration.TimeSpan;
			}
			break;
		case DurationType.Automatic:
			return TimeSpan.Zero;
		}
		return TimeSpan.Zero;
	}

	internal void SetElementNameTarget(ElementNameSubject subject)
	{
		ElementNameSubject.ElementInstanceChangedHandler handler = null;
		handler = delegate(object s, object? e)
		{
			Target = e as DependencyObject;
			if (Target != null)
			{
				if (_propertyInfo != null)
				{
					_propertyInfo.DataContext = Target;
				}
				if (!(e is ElementStub))
				{
					subject.ElementInstanceChanged -= handler;
				}
			}
		};
		Target = subject.ElementInstance as DependencyObject;
		subject.ElementInstanceChanged += handler;
	}

	private protected virtual void InitTarget()
	{
	}

	protected DependencyObject GetTargetFromName()
	{
		FrameworkElement visualParent = GetVisualParent();
		if (visualParent != null)
		{
			return visualParent.FindName(Storyboard.GetTargetName(this)) as DependencyObject;
		}
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Failed to find target {Storyboard.GetTargetName(this)} on {this.GetParent()?.GetType()}");
		}
		return null;
	}

	private FrameworkElement GetVisualParent()
	{
		object obj = this;
		while ((obj = obj.GetParent()) != null)
		{
			if (obj is FrameworkElement result)
			{
				return result;
			}
		}
		return null;
	}

	protected object GetValue()
	{
		return PropertyInfo.Value;
	}

	protected object GetNonAnimatedValue()
	{
		return PropertyInfo.GetSubstituteValue();
	}

	protected void SetValue(object value)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("Setting [{0}] to [{1} / {2}] current {3:X8}/{4}={5}", value, Storyboard.GetTargetName(this), Storyboard.GetTargetProperty(this), PropertyInfo?.DataContext?.GetHashCode(), PropertyInfo?.DataContext?.GetType(), PropertyInfo?.Value);
		}
		PropertyInfo.Value = value;
	}

	protected void ClearValue()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("Clearing [{0} / {1}]", Storyboard.GetTargetName(this), Storyboard.GetTargetProperty(this));
		}
		PropertyInfo.ClearValue();
	}

	void ITimeline.Begin()
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void Begin()");
	}

	void ITimeline.Stop()
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void Stop()");
	}

	void ITimeline.Resume()
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void Resume()");
	}

	void ITimeline.Pause()
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void Pause()");
	}

	void ITimeline.Seek(TimeSpan offset)
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void Seek(TimeSpan offset)");
	}

	void ITimeline.SeekAlignedToLastTick(TimeSpan offset)
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void SeekAlignedToLastTick(TimeSpan offset)");
	}

	void ITimeline.SkipToFill()
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void SkipToFill()");
	}

	void ITimeline.Deactivate()
	{
		ApiInformation.TryRaiseNotImplemented(GetType().FullName, "void Deactivate()");
	}

	private protected IValueAnimator InitializeAnimator()
	{
		throw new NotSupportedException();
	}

	private protected bool NeedsRepeat(Stopwatch duration, int replayCount)
	{
		TimeSpan elapsed = duration.Elapsed;
		if (RepeatBehavior.Type == RepeatBehaviorType.Forever || (RepeatBehavior.HasCount && RepeatBehavior.Count > (double)replayCount) || (RepeatBehavior.HasDuration && RepeatBehavior.Duration - elapsed > TimeSpan.Zero))
		{
			return State != TimelineState.Stopped;
		}
		return false;
	}

	internal bool IsTargetPropertyDependant()
	{
		if (PropertyInfo != null)
		{
			IBindingItem bindingItem = PropertyInfo.GetPathItems().LastOrDefault();
			if (bindingItem != null && (bindingItem.PropertyName.EndsWith("Opacity") || (bindingItem.DataContext is SolidColorBrush && bindingItem.PropertyName.EndsWith("Color")) || (bindingItem.DataContext is Transform transform && transform.View != null)))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void Dispose(bool disposing)
	{
		Target = null;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~Timeline()
	{
		Dispose(disposing: true);
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

	public override string ToString()
	{
		return GetType().FullName;
	}

	protected internal virtual void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		this.DataContextChanged?.Invoke(null, new DataContextChangedEventArgs(DataContext));
	}

	protected internal virtual void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml;

[ContentProperty(Name = "Storyboard")]
[Windows.UI.Xaml.Data.Bindable]
public sealed class VisualState : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private Action lazyBuilder;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public string Name { get; set; }

	public Storyboard Storyboard
	{
		get
		{
			EnsureMaterialized();
			return (Storyboard)GetValue(StoryboardProperty);
		}
		set
		{
			SetValue(StoryboardProperty, value);
		}
	}

	public static DependencyProperty StoryboardProperty { get; } = DependencyProperty.Register("Storyboard", typeof(Storyboard), typeof(VisualState), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext, OnStoryboardChanged));


	public SetterBaseCollection Setters
	{
		get
		{
			SetterBaseCollection setterBaseCollection = GetValue(SettersProperty) as SetterBaseCollection;
			if (setterBaseCollection == null)
			{
				SetterBaseCollection setterBaseCollection3 = (Setters = new SetterBaseCollection(this, isAutoPropertyInheritanceEnabled: false));
				setterBaseCollection = setterBaseCollection3;
			}
			EnsureMaterialized();
			return setterBaseCollection;
		}
		internal set
		{
			SetValue(SettersProperty, value);
		}
	}

	internal static DependencyProperty SettersProperty { get; } = DependencyProperty.Register("Setters", typeof(SetterBaseCollection), typeof(VisualState), new FrameworkPropertyMetadata((object)null));


	public IList<StateTriggerBase> StateTriggers
	{
		get
		{
			IList<StateTriggerBase> list = GetValue(StateTriggersProperty) as IList<StateTriggerBase>;
			if (list == null)
			{
				DependencyObjectCollection<StateTriggerBase> dependencyObjectCollection = new DependencyObjectCollection<StateTriggerBase>(this, isAutoPropertyInheritanceEnabled: false);
				dependencyObjectCollection.VectorChanged += OnStateTriggerCollectionChanged;
				IList<StateTriggerBase> list3 = (StateTriggers = dependencyObjectCollection);
				list = list3;
			}
			return list;
		}
		internal set
		{
			SetValue(StateTriggersProperty, value);
		}
	}

	internal static DependencyProperty StateTriggersProperty { get; } = DependencyProperty.Register("StateTriggers", typeof(IList<StateTriggerBase>), typeof(VisualState), new FrameworkPropertyMetadata(null, StateTriggersChanged));


	internal VisualStateGroup Owner => this.GetParent() as VisualStateGroup;

	internal Action LazyBuilder
	{
		get
		{
			return lazyBuilder;
		}
		set
		{
			lazyBuilder = value;
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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(VisualState), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VisualState)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(VisualState), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VisualState)s).OnTemplatedParentChanged(e);
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

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	public VisualState()
	{
		IsAutoPropertyInheritanceEnabled = false;
	}

	private static void OnStoryboardChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue is IDependencyObjectStoreProvider dependencyObject2)
		{
			dependencyObject2.SetParent(null);
		}
		if (args.NewValue is IDependencyObjectStoreProvider dependencyObject3)
		{
			dependencyObject3.SetParent(dependencyObject);
		}
	}

	private static void StateTriggersChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue is IList<StateTriggerBase> list)
		{
			foreach (StateTriggerBase item in list)
			{
				item.SetParent(null);
			}
		}
		if (!(args.NewValue is IList<StateTriggerBase> list2))
		{
			return;
		}
		foreach (StateTriggerBase item2 in list2)
		{
			item2.SetParent(dependencyobject);
		}
	}

	private void EnsureMaterialized()
	{
		if (LazyBuilder == null)
		{
			return;
		}
		Action action = LazyBuilder;
		LazyBuilder = null;
		action();
		((IDependencyObjectStoreProvider)Storyboard)?.Store.UpdateResourceBindings(ResourceUpdateReason.ThemeResource);
		foreach (SetterBase setter in Setters)
		{
			((IDependencyObjectStoreProvider)setter)?.Store.UpdateResourceBindings(ResourceUpdateReason.ThemeResource);
		}
	}

	private void OnStateTriggerCollectionChanged(IObservableVector<StateTriggerBase> sender, IVectorChangedEventArgs e)
	{
		Owner?.RefreshStateTriggers();
	}

	public override string ToString()
	{
		return Name ?? $"<unnamed state {GetHashCode()}>";
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

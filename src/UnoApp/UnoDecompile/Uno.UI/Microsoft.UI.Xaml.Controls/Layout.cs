using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Microsoft.UI.Xaml.Controls;

[Windows.UI.Xaml.Data.Bindable]
public class Layout : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	internal string LayoutId { get; set; }

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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(Layout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Layout)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(Layout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Layout)s).OnTemplatedParentChanged(e);
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

	public event TypedEventHandler<Layout, object> MeasureInvalidated;

	public event TypedEventHandler<Layout, object> ArrangeInvalidated;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	internal static VirtualizingLayoutContext GetVirtualizingLayoutContext(LayoutContext context)
	{
		if (!(context is VirtualizingLayoutContext result))
		{
			if (context is NonVirtualizingLayoutContext nonVirtualizingLayoutContext)
			{
				return nonVirtualizingLayoutContext.GetVirtualizingContextAdapter();
			}
			throw new NotImplementedException();
		}
		return result;
	}

	internal static NonVirtualizingLayoutContext GetNonVirtualizingLayoutContext(LayoutContext context)
	{
		if (!(context is NonVirtualizingLayoutContext result))
		{
			if (context is VirtualizingLayoutContext virtualizingLayoutContext)
			{
				return virtualizingLayoutContext.GetNonVirtualizingContextAdapter();
			}
			throw new NotImplementedException();
		}
		return result;
	}

	public void InitializeForContext(LayoutContext context)
	{
		if (!(this is VirtualizingLayout virtualizingLayout))
		{
			if (!(this is NonVirtualizingLayout nonVirtualizingLayout))
			{
				throw new NotImplementedException();
			}
			nonVirtualizingLayout.InitializeForContextCore(GetNonVirtualizingLayoutContext(context));
		}
		else
		{
			virtualizingLayout.InitializeForContextCore(GetVirtualizingLayoutContext(context));
		}
	}

	public void UninitializeForContext(LayoutContext context)
	{
		if (!(this is VirtualizingLayout virtualizingLayout))
		{
			if (!(this is NonVirtualizingLayout nonVirtualizingLayout))
			{
				throw new NotImplementedException();
			}
			nonVirtualizingLayout.UninitializeForContextCore(GetNonVirtualizingLayoutContext(context));
		}
		else
		{
			virtualizingLayout.UninitializeForContextCore(GetVirtualizingLayoutContext(context));
		}
	}

	public Size Measure(LayoutContext context, Size availableSize)
	{
		if (!(this is VirtualizingLayout virtualizingLayout))
		{
			if (this is NonVirtualizingLayout nonVirtualizingLayout)
			{
				return nonVirtualizingLayout.MeasureOverride(GetNonVirtualizingLayoutContext(context), availableSize);
			}
			throw new NotImplementedException();
		}
		return virtualizingLayout.MeasureOverride(GetVirtualizingLayoutContext(context), availableSize);
	}

	public Size Arrange(LayoutContext context, Size finalSize)
	{
		if (!(this is VirtualizingLayout virtualizingLayout))
		{
			if (this is NonVirtualizingLayout nonVirtualizingLayout)
			{
				return nonVirtualizingLayout.ArrangeOverride(GetNonVirtualizingLayoutContext(context), finalSize);
			}
			throw new NotImplementedException();
		}
		return virtualizingLayout.ArrangeOverride(GetVirtualizingLayoutContext(context), finalSize);
	}

	protected void InvalidateMeasure()
	{
		this.MeasureInvalidated?.Invoke(this, null);
	}

	protected void InvalidateArrange()
	{
		this.ArrangeInvalidated?.Invoke(this, null);
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

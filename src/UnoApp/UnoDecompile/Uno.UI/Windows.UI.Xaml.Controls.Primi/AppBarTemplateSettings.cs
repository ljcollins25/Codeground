using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls.Primitives;

[Windows.UI.Xaml.Data.Bindable]
public class AppBarTemplateSettings : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public Rect ClipRect
	{
		get
		{
			return (Rect)GetValue(ClipRectProperty);
		}
		internal set
		{
			SetValue(ClipRectProperty, value);
		}
	}

	internal static DependencyProperty ClipRectProperty { get; } = DependencyProperty.Register("ClipRect", typeof(Rect), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(default(Rect)));


	public Thickness CompactRootMargin
	{
		get
		{
			return (Thickness)GetValue(CompactRootMarginProperty);
		}
		internal set
		{
			SetValue(CompactRootMarginProperty, value);
		}
	}

	internal static DependencyProperty CompactRootMarginProperty { get; } = DependencyProperty.Register("CompactRootMargin", typeof(Thickness), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(new Thickness(0.0)));


	public double CompactVerticalDelta
	{
		get
		{
			return (double)GetValue(CompactVerticalDeltaProperty);
		}
		internal set
		{
			SetValue(CompactVerticalDeltaProperty, value);
		}
	}

	internal static DependencyProperty CompactVerticalDeltaProperty { get; } = DependencyProperty.Register("CompactVerticalDelta", typeof(double), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public Thickness HiddenRootMargin
	{
		get
		{
			return (Thickness)GetValue(HiddenRootMarginProperty);
		}
		internal set
		{
			SetValue(HiddenRootMarginProperty, value);
		}
	}

	public static DependencyProperty HiddenRootMarginProperty { get; } = DependencyProperty.Register("HiddenRootMargin", typeof(Thickness), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(new Thickness(0.0)));


	public double HiddenVerticalDelta
	{
		get
		{
			return (double)GetValue(HiddenVerticalDeltaProperty);
		}
		internal set
		{
			SetValue(HiddenVerticalDeltaProperty, value);
		}
	}

	internal static DependencyProperty HiddenVerticalDeltaProperty { get; } = DependencyProperty.Register("HiddenVerticalDelta", typeof(double), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public Thickness MinimalRootMargin
	{
		get
		{
			return (Thickness)GetValue(MinimalRootMarginProperty);
		}
		internal set
		{
			SetValue(MinimalRootMarginProperty, value);
		}
	}

	internal static DependencyProperty MinimalRootMarginProperty { get; } = DependencyProperty.Register("MinimalRootMargin", typeof(Thickness), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(new Thickness(0.0)));


	public double MinimalVerticalDelta
	{
		get
		{
			return (double)GetValue(MinimalVerticalDeltaProperty);
		}
		internal set
		{
			SetValue(MinimalVerticalDeltaProperty, value);
		}
	}

	internal static DependencyProperty MinimalVerticalDeltaProperty { get; } = DependencyProperty.Register("MinimalVerticalDelta", typeof(double), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double NegativeCompactVerticalDelta
	{
		get
		{
			return (double)GetValue(NegativeCompactVerticalDeltaProperty);
		}
		internal set
		{
			SetValue(NegativeCompactVerticalDeltaProperty, value);
		}
	}

	internal static DependencyProperty NegativeCompactVerticalDeltaProperty { get; } = DependencyProperty.Register("NegativeCompactVerticalDelta", typeof(double), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double NegativeMinimalVerticalDelta
	{
		get
		{
			return (double)GetValue(NegativeMinimalVerticalDeltaProperty);
		}
		internal set
		{
			SetValue(NegativeMinimalVerticalDeltaProperty, value);
		}
	}

	internal static DependencyProperty NegativeMinimalVerticalDeltaProperty { get; } = DependencyProperty.Register("NegativeMinimalVerticalDelta", typeof(double), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double NegativeHiddenVerticalDelta
	{
		get
		{
			return (double)GetValue(NegativeHiddenVerticalDeltaProperty);
		}
		internal set
		{
			SetValue(NegativeHiddenVerticalDeltaProperty, value);
		}
	}

	internal static DependencyProperty NegativeHiddenVerticalDeltaProperty { get; } = DependencyProperty.Register("NegativeHiddenVerticalDelta", typeof(double), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((AppBarTemplateSettings)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(AppBarTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((AppBarTemplateSettings)s).OnTemplatedParentChanged(e);
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

	internal AppBarTemplateSettings()
	{
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

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
public class CommandBarTemplateSettings : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public double ContentHeight
	{
		get
		{
			return (double)GetValue(ContentHeightProperty);
		}
		internal set
		{
			SetValue(ContentHeightProperty, value);
		}
	}

	internal static DependencyProperty ContentHeightProperty { get; } = DependencyProperty.Register("ContentHeight", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public Visibility EffectiveOverflowButtonVisibility
	{
		get
		{
			return (Visibility)GetValue(EffectiveOverflowButtonVisibilityProperty);
		}
		internal set
		{
			SetValue(EffectiveOverflowButtonVisibilityProperty, value);
		}
	}

	internal static DependencyProperty EffectiveOverflowButtonVisibilityProperty { get; } = DependencyProperty.Register("EffectiveOverflowButtonVisibility", typeof(Visibility), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(Visibility.Visible));


	public double NegativeOverflowContentHeight
	{
		get
		{
			return (double)GetValue(NegativeOverflowContentHeightProperty);
		}
		internal set
		{
			SetValue(NegativeOverflowContentHeightProperty, value);
		}
	}

	internal static DependencyProperty NegativeOverflowContentHeightProperty { get; } = DependencyProperty.Register("NegativeOverflowContentHeight", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public Rect OverflowContentClipRect
	{
		get
		{
			return (Rect)GetValue(OverflowContentClipRectProperty);
		}
		internal set
		{
			SetValue(OverflowContentClipRectProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentClipRectProperty { get; } = DependencyProperty.Register("OverflowContentClipRect", typeof(Rect), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(default(Rect)));


	public double OverflowContentHeight
	{
		get
		{
			return (double)GetValue(OverflowContentHeightProperty);
		}
		internal set
		{
			SetValue(OverflowContentHeightProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentHeightProperty { get; } = DependencyProperty.Register("OverflowContentHeight", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double OverflowContentHorizontalOffset
	{
		get
		{
			return (double)GetValue(OverflowContentHorizontalOffsetProperty);
		}
		internal set
		{
			SetValue(OverflowContentHorizontalOffsetProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentHorizontalOffsetProperty { get; } = DependencyProperty.Register("OverflowContentHorizontalOffset", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double OverflowContentMaxHeight
	{
		get
		{
			return (double)GetValue(OverflowContentMaxHeightProperty);
		}
		internal set
		{
			SetValue(OverflowContentMaxHeightProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentMaxHeightProperty { get; } = DependencyProperty.Register("OverflowContentMaxHeight", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double OverflowContentMinWidth
	{
		get
		{
			return (double)GetValue(OverflowContentMinWidthProperty);
		}
		internal set
		{
			SetValue(OverflowContentMinWidthProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentMinWidthProperty { get; } = DependencyProperty.Register("OverflowContentMinWidth", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double OverflowContentMaxWidth
	{
		get
		{
			return (double)GetValue(OverflowContentMaxWidthProperty);
		}
		internal set
		{
			SetValue(OverflowContentMaxWidthProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentMaxWidthProperty { get; } = DependencyProperty.Register("OverflowContentMaxWidth", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double OverflowContentCompactYTranslation
	{
		get
		{
			return (double)GetValue(OverflowContentCompactYTranslationProperty);
		}
		internal set
		{
			SetValue(OverflowContentCompactYTranslationProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentCompactYTranslationProperty { get; } = DependencyProperty.Register("OverflowContentCompactYTranslation", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double OverflowContentHiddenYTranslation
	{
		get
		{
			return (double)GetValue(OverflowContentHiddenYTranslationProperty);
		}
		internal set
		{
			SetValue(OverflowContentHiddenYTranslationProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentHiddenYTranslationProperty { get; } = DependencyProperty.Register("OverflowContentHiddenYTranslation", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double OverflowContentMinimalYTranslation
	{
		get
		{
			return (double)GetValue(OverflowContentMinimalYTranslationProperty);
		}
		internal set
		{
			SetValue(OverflowContentMinimalYTranslationProperty, value);
		}
	}

	internal static DependencyProperty OverflowContentMinimalYTranslationProperty { get; } = DependencyProperty.Register("OverflowContentMinimalYTranslation", typeof(double), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(0.0));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CommandBarTemplateSettings)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(CommandBarTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CommandBarTemplateSettings)s).OnTemplatedParentChanged(e);
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

	internal CommandBarTemplateSettings()
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

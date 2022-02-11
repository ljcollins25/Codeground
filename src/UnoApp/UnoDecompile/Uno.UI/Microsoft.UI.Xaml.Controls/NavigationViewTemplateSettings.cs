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
public class NavigationViewTemplateSettings : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public Visibility BackButtonVisibility
	{
		get
		{
			return (Visibility)GetValue(BackButtonVisibilityProperty);
		}
		internal set
		{
			SetValue(BackButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty BackButtonVisibilityProperty { get; } = DependencyProperty.Register("BackButtonVisibility", typeof(Visibility), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(Visibility.Collapsed));


	public Visibility LeftPaneVisibility
	{
		get
		{
			return (Visibility)GetValue(LeftPaneVisibilityProperty);
		}
		internal set
		{
			SetValue(LeftPaneVisibilityProperty, value);
		}
	}

	public static DependencyProperty LeftPaneVisibilityProperty { get; } = DependencyProperty.Register("LeftPaneVisibility", typeof(Visibility), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(Visibility.Visible));


	public double OpenPaneWidth
	{
		get
		{
			return (double)GetValue(OpenPaneWidthProperty);
		}
		set
		{
			SetValue(OpenPaneWidthProperty, value);
		}
	}

	public static DependencyProperty OpenPaneWidthProperty { get; } = DependencyProperty.Register("OpenPaneWidth", typeof(double), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(320.0));


	public Visibility OverflowButtonVisibility
	{
		get
		{
			return (Visibility)GetValue(OverflowButtonVisibilityProperty);
		}
		internal set
		{
			SetValue(OverflowButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty OverflowButtonVisibilityProperty { get; } = DependencyProperty.Register("OverflowButtonVisibility", typeof(Visibility), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(Visibility.Collapsed));


	public Visibility PaneToggleButtonVisibility
	{
		get
		{
			return (Visibility)GetValue(PaneToggleButtonVisibilityProperty);
		}
		internal set
		{
			SetValue(PaneToggleButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty PaneToggleButtonVisibilityProperty { get; } = DependencyProperty.Register("PaneToggleButtonVisibility", typeof(Visibility), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(Visibility.Visible));


	public double PaneToggleButtonWidth
	{
		get
		{
			return (double)GetValue(PaneToggleButtonWidthProperty);
		}
		internal set
		{
			SetValue(PaneToggleButtonWidthProperty, value);
		}
	}

	public static DependencyProperty PaneToggleButtonWidthProperty { get; } = DependencyProperty.Register("PaneToggleButtonWidth", typeof(double), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public bool SingleSelectionFollowsFocus
	{
		get
		{
			return (bool)GetValue(SingleSelectionFollowsFocusProperty);
		}
		internal set
		{
			SetValue(SingleSelectionFollowsFocusProperty, value);
		}
	}

	public static DependencyProperty SingleSelectionFollowsFocusProperty { get; } = DependencyProperty.Register("SingleSelectionFollowsFocus", typeof(bool), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(false));


	public double SmallerPaneToggleButtonWidth
	{
		get
		{
			return (double)GetValue(SmallerPaneToggleButtonWidthProperty);
		}
		internal set
		{
			SetValue(SmallerPaneToggleButtonWidthProperty, value);
		}
	}

	public static DependencyProperty SmallerPaneToggleButtonWidthProperty { get; } = DependencyProperty.Register("SmallerPaneToggleButtonWidth", typeof(double), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public double TopPadding
	{
		get
		{
			return (double)GetValue(TopPaddingProperty);
		}
		internal set
		{
			SetValue(TopPaddingProperty, value);
		}
	}

	public static DependencyProperty TopPaddingProperty { get; } = DependencyProperty.Register("TopPadding", typeof(double), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(0.0));


	public Visibility TopPaneVisibility
	{
		get
		{
			return (Visibility)GetValue(TopPaneVisibilityProperty);
		}
		internal set
		{
			SetValue(TopPaneVisibilityProperty, value);
		}
	}

	public static DependencyProperty TopPaneVisibilityProperty { get; } = DependencyProperty.Register("TopPaneVisibility", typeof(Visibility), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(Visibility.Collapsed));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((NavigationViewTemplateSettings)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(NavigationViewTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((NavigationViewTemplateSettings)s).OnTemplatedParentChanged(e);
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

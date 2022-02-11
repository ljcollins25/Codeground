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
public sealed class CalendarViewTemplateSettings : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private static readonly DependencyProperty MinViewWidthProperty = DependencyProperty.Register("MinViewWidth", typeof(double), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(0.0));

	private static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty WeekDay1Property = DependencyProperty.Register("WeekDay1", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty WeekDay2Property = DependencyProperty.Register("WeekDay2", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty WeekDay3Property = DependencyProperty.Register("WeekDay3", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty WeekDay4Property = DependencyProperty.Register("WeekDay4", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty WeekDay5Property = DependencyProperty.Register("WeekDay5", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty WeekDay6Property = DependencyProperty.Register("WeekDay6", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty WeekDay7Property = DependencyProperty.Register("WeekDay7", typeof(string), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata((object)null));

	private static readonly DependencyProperty HasMoreContentAfterProperty = DependencyProperty.Register("HasMoreContentAfter", typeof(bool), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(false));

	private static readonly DependencyProperty HasMoreContentBeforeProperty = DependencyProperty.Register("HasMoreContentBefore", typeof(bool), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(false));

	private static readonly DependencyProperty HasMoreViewsProperty = DependencyProperty.Register("HasMoreViews", typeof(bool), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(false));

	private static readonly DependencyProperty ClipRectProperty = DependencyProperty.Register("ClipRect", typeof(Rect), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(default(Rect)));

	private static readonly DependencyProperty CenterXProperty = DependencyProperty.Register("CenterX", typeof(double), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(0.0));

	private static readonly DependencyProperty CenterYProperty = DependencyProperty.Register("CenterY", typeof(double), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(0.0));

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public double MinViewWidth
	{
		get
		{
			return (double)GetValue(MinViewWidthProperty);
		}
		internal set
		{
			SetValue(MinViewWidthProperty, value);
		}
	}

	public string HeaderText
	{
		get
		{
			return (string)GetValue(HeaderTextProperty);
		}
		internal set
		{
			SetValue(HeaderTextProperty, value);
		}
	}

	public string WeekDay1
	{
		get
		{
			return (string)GetValue(WeekDay1Property);
		}
		internal set
		{
			SetValue(WeekDay1Property, value);
		}
	}

	public string WeekDay2
	{
		get
		{
			return (string)GetValue(WeekDay2Property);
		}
		internal set
		{
			SetValue(WeekDay2Property, value);
		}
	}

	public string WeekDay3
	{
		get
		{
			return (string)GetValue(WeekDay3Property);
		}
		internal set
		{
			SetValue(WeekDay3Property, value);
		}
	}

	public string WeekDay4
	{
		get
		{
			return (string)GetValue(WeekDay4Property);
		}
		internal set
		{
			SetValue(WeekDay4Property, value);
		}
	}

	public string WeekDay5
	{
		get
		{
			return (string)GetValue(WeekDay5Property);
		}
		internal set
		{
			SetValue(WeekDay5Property, value);
		}
	}

	public string WeekDay6
	{
		get
		{
			return (string)GetValue(WeekDay6Property);
		}
		internal set
		{
			SetValue(WeekDay6Property, value);
		}
	}

	public string WeekDay7
	{
		get
		{
			return (string)GetValue(WeekDay7Property);
		}
		internal set
		{
			SetValue(WeekDay7Property, value);
		}
	}

	public bool HasMoreContentAfter
	{
		get
		{
			return (bool)GetValue(HasMoreContentAfterProperty);
		}
		internal set
		{
			SetValue(HasMoreContentAfterProperty, value);
		}
	}

	public bool HasMoreContentBefore
	{
		get
		{
			return (bool)GetValue(HasMoreContentBeforeProperty);
		}
		internal set
		{
			SetValue(HasMoreContentBeforeProperty, value);
		}
	}

	public bool HasMoreViews
	{
		get
		{
			return (bool)GetValue(HasMoreViewsProperty);
		}
		internal set
		{
			SetValue(HasMoreViewsProperty, value);
		}
	}

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

	public double CenterX
	{
		get
		{
			return (double)GetValue(CenterXProperty);
		}
		internal set
		{
			SetValue(CenterXProperty, value);
		}
	}

	public double CenterY
	{
		get
		{
			return (double)GetValue(CenterYProperty);
		}
		internal set
		{
			SetValue(CenterYProperty, value);
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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CalendarViewTemplateSettings)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(CalendarViewTemplateSettings), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CalendarViewTemplateSettings)s).OnTemplatedParentChanged(e);
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

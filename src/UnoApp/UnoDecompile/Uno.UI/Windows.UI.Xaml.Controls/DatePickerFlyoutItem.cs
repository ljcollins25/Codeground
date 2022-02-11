using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls;

[Windows.UI.Xaml.Data.Bindable]
public class DatePickerFlyoutItem : DependencyObject, ICustomPropertyProvider, IEquatable<DatePickerFlyoutItem>, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Type Type
	{
		get
		{
			throw new NotImplementedException("The member Type DatePickerFlyoutItem.Type is not implemented in Uno.");
		}
	}

	public string SecondaryText
	{
		get
		{
			return (string)GetValue(SecondaryTextProperty);
		}
		set
		{
			SetValue(SecondaryTextProperty, value);
		}
	}

	public string PrimaryText
	{
		get
		{
			return (string)GetValue(PrimaryTextProperty);
		}
		set
		{
			SetValue(PrimaryTextProperty, value);
		}
	}

	public static DependencyProperty PrimaryTextProperty { get; } = DependencyProperty.Register("PrimaryText", typeof(string), typeof(DatePickerFlyoutItem), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SecondaryTextProperty { get; } = DependencyProperty.Register("SecondaryText", typeof(string), typeof(DatePickerFlyoutItem), new FrameworkPropertyMetadata((object)null));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(DatePickerFlyoutItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerFlyoutItem)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(DatePickerFlyoutItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerFlyoutItem)s).OnTemplatedParentChanged(e);
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ICustomProperty GetCustomProperty(string name)
	{
		throw new NotImplementedException("The member ICustomProperty DatePickerFlyoutItem.GetCustomProperty(string name) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ICustomProperty GetIndexedProperty(string name, Type type)
	{
		throw new NotImplementedException("The member ICustomProperty DatePickerFlyoutItem.GetIndexedProperty(string name, Type type) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string GetStringRepresentation()
	{
		throw new NotImplementedException("The member string DatePickerFlyoutItem.GetStringRepresentation() is not implemented in Uno.");
	}

	public bool Equals(DatePickerFlyoutItem other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (object.Equals(PrimaryText, other.PrimaryText))
		{
			return object.Equals(PrimaryText, other.PrimaryText);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() == GetType())
		{
			return Equals((DatePickerFlyoutItem)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		string primaryText = PrimaryText;
		string secondaryText = SecondaryText;
		int num = primaryText?.GetHashCode() ?? 0;
		return (num * 397) ^ (secondaryText?.GetHashCode() ?? 0);
	}

	public override string ToString()
	{
		string primaryText = PrimaryText;
		string secondaryText = SecondaryText;
		if (primaryText != null && secondaryText != null)
		{
			return primaryText + " " + secondaryText;
		}
		if (primaryText != null)
		{
			return primaryText;
		}
		if (secondaryText != null)
		{
			return secondaryText;
		}
		return "";
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

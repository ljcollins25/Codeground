using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Input;

[Windows.UI.Xaml.Data.Bindable]
public class KeyboardAccelerator : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public DependencyObject ScopeOwner
	{
		get
		{
			return (DependencyObject)GetValue(ScopeOwnerProperty);
		}
		set
		{
			SetValue(ScopeOwnerProperty, value);
		}
	}

	public VirtualKeyModifiers Modifiers
	{
		get
		{
			return (VirtualKeyModifiers)GetValue(ModifiersProperty);
		}
		set
		{
			SetValue(ModifiersProperty, value);
		}
	}

	public VirtualKey Key
	{
		get
		{
			return (VirtualKey)GetValue(KeyProperty);
		}
		set
		{
			SetValue(KeyProperty, value);
		}
	}

	public bool IsEnabled
	{
		get
		{
			return (bool)GetValue(IsEnabledProperty);
		}
		set
		{
			SetValue(IsEnabledProperty, value);
		}
	}

	public static DependencyProperty ScopeOwnerProperty { get; } = DependencyProperty.Register("ScopeOwner", typeof(DependencyObject), typeof(KeyboardAccelerator), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty ModifiersProperty { get; } = DependencyProperty.Register("Modifiers", typeof(VirtualKeyModifiers), typeof(KeyboardAccelerator), new FrameworkPropertyMetadata(VirtualKeyModifiers.None));


	public static DependencyProperty KeyProperty { get; } = DependencyProperty.Register("Key", typeof(VirtualKey), typeof(KeyboardAccelerator), new FrameworkPropertyMetadata(VirtualKey.None));


	public static DependencyProperty IsEnabledProperty { get; } = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(KeyboardAccelerator), new FrameworkPropertyMetadata(false));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(KeyboardAccelerator), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((KeyboardAccelerator)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(KeyboardAccelerator), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((KeyboardAccelerator)s).OnTemplatedParentChanged(e);
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> Invoked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.KeyboardAccelerator", "event TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> KeyboardAccelerator.Invoked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.KeyboardAccelerator", "event TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> KeyboardAccelerator.Invoked");
		}
	}

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	internal static string GetStringRepresentationForUIElement(UIElement uiElement)
	{
		if (uiElement.KeyboardAccelerators.Count != 0)
		{
			IList<KeyboardAccelerator> keyboardAccelerators = uiElement.KeyboardAccelerators;
			int count = keyboardAccelerators.Count;
			if (count > 0)
			{
				KeyboardAccelerator keyboardAccelerator = keyboardAccelerators[0];
				return keyboardAccelerator.GetStringRepresentation();
			}
		}
		return null;
	}

	private string GetStringRepresentation()
	{
		VirtualKey key = Key;
		VirtualKeyModifiers modifiers = Modifiers;
		string keyboardAcceleratorString = "";
		if ((modifiers & VirtualKeyModifiers.Control) != 0)
		{
			ConcatVirtualKey(VirtualKey.Control, ref keyboardAcceleratorString);
		}
		if ((modifiers & VirtualKeyModifiers.Menu) != 0)
		{
			ConcatVirtualKey(VirtualKey.Menu, ref keyboardAcceleratorString);
		}
		if ((modifiers & VirtualKeyModifiers.Windows) != 0)
		{
			ConcatVirtualKey(VirtualKey.LeftWindows, ref keyboardAcceleratorString);
		}
		if ((modifiers & VirtualKeyModifiers.Shift) != 0)
		{
			ConcatVirtualKey(VirtualKey.Shift, ref keyboardAcceleratorString);
		}
		ConcatVirtualKey(key, ref keyboardAcceleratorString);
		return keyboardAcceleratorString;
	}

	private void ConcatVirtualKey(VirtualKey key, ref string keyboardAcceleratorString)
	{
		string text = key.ToString();
		if (string.IsNullOrEmpty(keyboardAcceleratorString))
		{
			keyboardAcceleratorString = text;
			return;
		}
		string format = "{0} + {1}";
		keyboardAcceleratorString = string.Format(CultureInfo.InvariantCulture, format, keyboardAcceleratorString, text);
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

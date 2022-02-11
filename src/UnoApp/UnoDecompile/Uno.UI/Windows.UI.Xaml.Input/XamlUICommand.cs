using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Input;

[Windows.UI.Xaml.Data.Bindable]
public class XamlUICommand : DependencyObject, ICommand, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public string Label
	{
		get
		{
			return (string)GetValue(LabelProperty);
		}
		set
		{
			SetValue(LabelProperty, value);
		}
	}

	public IconSource IconSource
	{
		get
		{
			return (IconSource)GetValue(IconSourceProperty);
		}
		set
		{
			SetValue(IconSourceProperty, value);
		}
	}

	public string Description
	{
		get
		{
			return (string)GetValue(DescriptionProperty);
		}
		set
		{
			SetValue(DescriptionProperty, value);
		}
	}

	public ICommand Command
	{
		get
		{
			return (ICommand)GetValue(CommandProperty);
		}
		set
		{
			SetValue(CommandProperty, value);
		}
	}

	public string AccessKey
	{
		get
		{
			return (string)GetValue(AccessKeyProperty);
		}
		set
		{
			SetValue(AccessKeyProperty, value);
		}
	}

	public IList<KeyboardAccelerator> KeyboardAccelerators => (IList<KeyboardAccelerator>)GetValue(KeyboardAcceleratorsProperty);

	public static DependencyProperty AccessKeyProperty { get; } = DependencyProperty.Register("AccessKey", typeof(string), typeof(XamlUICommand), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty CommandProperty { get; } = DependencyProperty.Register("Command", typeof(ICommand), typeof(XamlUICommand), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(string), typeof(XamlUICommand), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty IconSourceProperty { get; } = DependencyProperty.Register("IconSource", typeof(IconSource), typeof(XamlUICommand), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty KeyboardAcceleratorsProperty { get; } = DependencyProperty.Register("KeyboardAccelerators", typeof(IList<KeyboardAccelerator>), typeof(XamlUICommand), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty LabelProperty { get; } = DependencyProperty.Register("Label", typeof(string), typeof(XamlUICommand), new FrameworkPropertyMetadata((object)null));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(XamlUICommand), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((XamlUICommand)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(XamlUICommand), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((XamlUICommand)s).OnTemplatedParentChanged(e);
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

	public event EventHandler CanExecuteChanged;

	public event TypedEventHandler<XamlUICommand, CanExecuteRequestedEventArgs> CanExecuteRequested;

	public event TypedEventHandler<XamlUICommand, ExecuteRequestedEventArgs> ExecuteRequested;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	public void NotifyCanExecuteChanged()
	{
		this.CanExecuteChanged?.Invoke(this, null);
	}

	public bool CanExecute(object parameter)
	{
		bool flag = false;
		CanExecuteRequestedEventArgs canExecuteRequestedEventArgs = new CanExecuteRequestedEventArgs();
		canExecuteRequestedEventArgs.Parameter = parameter;
		canExecuteRequestedEventArgs.CanExecute = true;
		this.CanExecuteRequested?.Invoke(this, canExecuteRequestedEventArgs);
		flag = canExecuteRequestedEventArgs.CanExecute;
		ICommand command = Command;
		if (command != null)
		{
			bool flag2 = command.CanExecute(parameter);
			flag = flag && flag2;
		}
		return flag;
	}

	public void Execute(object parameter)
	{
		ExecuteRequestedEventArgs executeRequestedEventArgs = new ExecuteRequestedEventArgs();
		executeRequestedEventArgs.Parameter = parameter;
		this.ExecuteRequested?.Invoke(this, executeRequestedEventArgs);
		Command?.Execute(parameter);
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

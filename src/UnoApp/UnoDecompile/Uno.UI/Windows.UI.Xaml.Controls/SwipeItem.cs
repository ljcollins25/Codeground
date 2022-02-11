using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[Windows.UI.Xaml.Data.Bindable]
public class SwipeItem : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public static DependencyProperty BackgroundProperty { get; } = DependencyProperty.Register("Background", typeof(Brush), typeof(SwipeItem), new FrameworkPropertyMetadata(null, OnBackgroundPropertyChanged));


	public Brush Background
	{
		get
		{
			return (Brush)GetValue(BackgroundProperty);
		}
		set
		{
			SetValue(BackgroundProperty, value);
		}
	}

	public static DependencyProperty BehaviorOnInvokedProperty { get; } = DependencyProperty.Register("BehaviorOnInvoked", typeof(SwipeBehaviorOnInvoked), typeof(SwipeItem), new FrameworkPropertyMetadata(SwipeBehaviorOnInvoked.Auto, OnBehaviorOnInvokedPropertyChanged));


	public SwipeBehaviorOnInvoked BehaviorOnInvoked
	{
		get
		{
			return (SwipeBehaviorOnInvoked)GetValue(BehaviorOnInvokedProperty);
		}
		set
		{
			SetValue(BehaviorOnInvokedProperty, value);
		}
	}

	public static DependencyProperty CommandProperty { get; } = DependencyProperty.Register("Command", typeof(ICommand), typeof(SwipeItem), new FrameworkPropertyMetadata(null, OnCommandPropertyChanged));


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

	public static DependencyProperty CommandParameterProperty { get; } = DependencyProperty.Register("CommandParameter", typeof(object), typeof(SwipeItem), new FrameworkPropertyMetadata(null, OnCommandParameterPropertyChanged));


	public object CommandParameter
	{
		get
		{
			return GetValue(CommandParameterProperty);
		}
		set
		{
			SetValue(CommandParameterProperty, value);
		}
	}

	public static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(SwipeItem), new FrameworkPropertyMetadata(null, OnForegroundPropertyChanged));


	public Brush Foreground
	{
		get
		{
			return (Brush)GetValue(ForegroundProperty);
		}
		set
		{
			SetValue(ForegroundProperty, value);
		}
	}

	public static DependencyProperty IconSourceProperty { get; } = DependencyProperty.Register("IconSource", typeof(IconSource), typeof(SwipeItem), new FrameworkPropertyMetadata(null, OnIconSourcePropertyChanged));


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

	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(SwipeItem), new FrameworkPropertyMetadata(null, OnTextPropertyChanged));


	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			SetValue(TextProperty, value);
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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(SwipeItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SwipeItem)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(SwipeItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SwipeItem)s).OnTemplatedParentChanged(e);
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

	public event TypedEventHandler<SwipeItem, SwipeItemInvokedEventArgs> Invoked
	{
		add
		{
			m_invokedEventSource += value;
		}
		remove
		{
			m_invokedEventSource -= value;
		}
	}

	private event TypedEventHandler<SwipeItem, SwipeItemInvokedEventArgs> m_invokedEventSource;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	internal void InvokeSwipe(SwipeControl swipeControl)
	{
		SwipeItemInvokedEventArgs args = new SwipeItemInvokedEventArgs(swipeControl);
		this.m_invokedEventSource?.Invoke(this, args);
		if (CommandProperty != null)
		{
			ICommand command = Command;
			object commandParameter = CommandParameter;
			if (command != null && command.CanExecute(commandParameter))
			{
				command.Execute(commandParameter);
			}
		}
		if (BehaviorOnInvoked == SwipeBehaviorOnInvoked.Close || BehaviorOnInvoked == SwipeBehaviorOnInvoked.Auto)
		{
			swipeControl.Close();
		}
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == CommandProperty)
		{
			OnCommandChanged(args.OldValue as ICommand, args.NewValue as ICommand);
		}
	}

	private void OnCommandChanged(ICommand oldCommand, ICommand newCommand)
	{
		if (newCommand is XamlUICommand uiCommand)
		{
			CommandingHelpers.BindToLabelPropertyIfUnset(uiCommand, this, TextProperty);
			CommandingHelpers.BindToIconSourcePropertyIfUnset(uiCommand, this, IconSourceProperty);
		}
	}

	internal void GenerateControl(AppBarButton appBarButton, Style swipeItemStyle)
	{
		appBarButton.Style(swipeItemStyle);
		if (Background != null)
		{
			appBarButton.Background = Background;
		}
		if (Foreground != null)
		{
			appBarButton.Foreground = Foreground;
		}
		if (IconSource != null)
		{
			appBarButton.Icon = IconSource.CreateIconElement();
		}
		appBarButton.Label = Text;
		AttachEventHandlers(appBarButton);
	}

	private void AttachEventHandlers(AppBarButton appBarButton)
	{
		WeakReference<SwipeItem> weakThis = new WeakReference<SwipeItem>(this);
		appBarButton.Tapped += delegate(object sender, TappedRoutedEventArgs args)
		{
			if (weakThis.TryGetTarget(out var target2))
			{
				target2.OnItemTapped(sender, args);
			}
		};
		appBarButton.PointerPressed += delegate(object sender, PointerRoutedEventArgs args)
		{
			if (weakThis.TryGetTarget(out var target))
			{
				target.OnPointerPressed(sender, args);
			}
		};
	}

	private void OnItemTapped(object sender, TappedRoutedEventArgs args)
	{
		for (DependencyObject parent = VisualTreeHelper.GetParent(sender as DependencyObject); parent != null; parent = VisualTreeHelper.GetParent(parent))
		{
			if (parent is SwipeControl swipeControl)
			{
				InvokeSwipe(swipeControl);
				args.Handled = true;
			}
		}
	}

	private void OnPointerPressed(object sender, PointerRoutedEventArgs args)
	{
		if (args.Pointer.PointerDeviceType == PointerDeviceType.Touch)
		{
			args.Handled = true;
		}
	}

	private static void OnBackgroundPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItem swipeItem = (SwipeItem)sender;
		swipeItem.OnPropertyChanged(args);
	}

	private static void OnBehaviorOnInvokedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItem swipeItem = (SwipeItem)sender;
		swipeItem.OnPropertyChanged(args);
	}

	private static void OnCommandPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItem swipeItem = (SwipeItem)sender;
		swipeItem.OnPropertyChanged(args);
	}

	private static void OnCommandParameterPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItem swipeItem = (SwipeItem)sender;
		swipeItem.OnPropertyChanged(args);
	}

	private static void OnForegroundPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItem swipeItem = (SwipeItem)sender;
		swipeItem.OnPropertyChanged(args);
	}

	private static void OnIconSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItem swipeItem = (SwipeItem)sender;
		swipeItem.OnPropertyChanged(args);
	}

	private static void OnTextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItem swipeItem = (SwipeItem)sender;
		swipeItem.OnPropertyChanged(args);
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

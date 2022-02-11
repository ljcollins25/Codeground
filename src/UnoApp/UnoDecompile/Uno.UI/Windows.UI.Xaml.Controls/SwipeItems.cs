using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls;

[Windows.UI.Xaml.Data.Bindable]
public class SwipeItems : DependencyObject, IList<SwipeItem>, ICollection<SwipeItem>, IEnumerable<SwipeItem>, IEnumerable, IObservableVector<SwipeItem>, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private ObservableCollection<SwipeItem> m_items;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	private ObservableCollection<SwipeItem> Items
	{
		set
		{
			if (Mode == SwipeMode.Execute && value.Count > 1)
			{
				throw new ArgumentException("Execute items should only have one item.");
			}
			m_items = value;
			this.m_vectorChangedEventSource?.Invoke(this, null);
		}
	}

	public uint Size => (uint)m_items.Count;

	public static DependencyProperty ModeProperty { get; } = DependencyProperty.Register("Mode", typeof(SwipeMode), typeof(SwipeItems), new FrameworkPropertyMetadata(SwipeMode.Reveal, OnModePropertyChanged));


	public SwipeMode Mode
	{
		get
		{
			return (SwipeMode)GetValue(ModeProperty);
		}
		set
		{
			SetValue(ModeProperty, value);
		}
	}

	public int Count => m_items.Count;

	public bool IsReadOnly => ((ICollection<SwipeItem>)m_items).IsReadOnly;

	public SwipeItem this[int index]
	{
		get
		{
			return GetAt((uint)index);
		}
		set
		{
			SetAt((uint)index, value);
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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(SwipeItems), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SwipeItems)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(SwipeItems), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SwipeItems)s).OnTemplatedParentChanged(e);
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

	public event VectorChangedEventHandler<SwipeItem> VectorChanged
	{
		add
		{
			m_vectorChangedEventSource += value;
		}
		remove
		{
			m_vectorChangedEventSource -= value;
		}
	}

	private event VectorChangedEventHandler<SwipeItem> m_vectorChangedEventSource;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	public SwipeItems()
	{
		ObservableCollection<SwipeItem> observableCollection2 = (Items = new ObservableCollection<SwipeItem>());
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == ModeProperty && (SwipeMode)args.NewValue == SwipeMode.Execute && m_items.Count > 1)
		{
			throw new ArgumentException("Execute items should only have one item.");
		}
	}

	public SwipeItem GetAt(uint index)
	{
		if (index >= m_items.Count)
		{
			throw new IndexOutOfRangeException();
		}
		return m_items[(int)index];
	}

	public bool IndexOf(SwipeItem value, out uint index)
	{
		int num = m_items.IndexOf(value);
		if (num < 0)
		{
			index = 0u;
			return false;
		}
		index = (uint)num;
		return true;
	}

	public void SetAt(uint index, SwipeItem value)
	{
		if (index >= m_items.Count)
		{
			throw new IndexOutOfRangeException();
		}
		m_items[(int)index] = value;
		this.m_vectorChangedEventSource?.Invoke(this, null);
	}

	public void InsertAt(uint index, SwipeItem value)
	{
		if (Mode == SwipeMode.Execute && m_items.Count > 0)
		{
			throw new ArgumentException("Execute items should only have one item.");
		}
		if (index > m_items.Count)
		{
			throw new IndexOutOfRangeException();
		}
		m_items.Insert((int)index, value);
		this.m_vectorChangedEventSource?.Invoke(this, null);
	}

	public void RemoveAt(uint index)
	{
		if (index >= m_items.Count)
		{
			throw new IndexOutOfRangeException();
		}
		m_items.RemoveAt((int)index);
		this.m_vectorChangedEventSource?.Invoke(this, null);
	}

	public void Append(SwipeItem value)
	{
		if (Mode == SwipeMode.Execute && m_items.Count > 0)
		{
			throw new ArgumentException("Execute items should only have one item.");
		}
		m_items.Add(value);
		this.m_vectorChangedEventSource?.Invoke(this, null);
	}

	public void RemoveAtEnd()
	{
		m_items.RemoveAt(m_items.Count - 1);
		this.m_vectorChangedEventSource?.Invoke(this, null);
	}

	public void Clear()
	{
		m_items.Clear();
		this.m_vectorChangedEventSource?.Invoke(this, null);
	}

	public SwipeItem First()
	{
		throw new NotImplementedException();
	}

	public uint GetMany(uint startIndex, SwipeItem[] items)
	{
		throw new NotImplementedException();
	}

	public void ReplaceAll(SwipeItem[] items)
	{
		throw new NotImplementedException();
	}

	private static void OnModePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		SwipeItems swipeItems = sender as SwipeItems;
		swipeItems.OnPropertyChanged(args);
	}

	public IEnumerator<SwipeItem> GetEnumerator()
	{
		return m_items.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return m_items.GetEnumerator();
	}

	public void Add(SwipeItem item)
	{
		Append(item);
	}

	public bool Contains(SwipeItem item)
	{
		return m_items.Contains(item);
	}

	public void CopyTo(SwipeItem[] array, int arrayIndex)
	{
		m_items.CopyTo(array, arrayIndex);
	}

	public bool Remove(SwipeItem item)
	{
		return m_items.Remove(item);
	}

	public int IndexOf(SwipeItem item)
	{
		return m_items.IndexOf(item);
	}

	public void Insert(int index, SwipeItem item)
	{
		InsertAt((uint)index, item);
	}

	public void RemoveAt(int index)
	{
		RemoveAt((uint)index);
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

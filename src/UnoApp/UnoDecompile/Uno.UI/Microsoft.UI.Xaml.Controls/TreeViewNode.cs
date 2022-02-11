using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Microsoft.UI.Xaml.Controls;

[Windows.UI.Xaml.Data.Bindable]
public class TreeViewNode : DependencyObject, ICustomPropertyProvider, IStringable, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private WeakReference<TreeViewNode> m_parentNode;

	private bool m_HasUnrealizedChildren;

	private object m_itemsSource;

	private ItemsSourceView m_itemsDataSource;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public TreeViewNode Parent
	{
		get
		{
			TreeViewNode target = null;
			WeakReference<TreeViewNode> parentNode = m_parentNode;
			if (parentNode != null && parentNode.TryGetTarget(out target))
			{
				return target;
			}
			return null;
		}
		internal set
		{
			if (value != null)
			{
				m_parentNode = new WeakReference<TreeViewNode>(value);
			}
			else
			{
				m_parentNode = null;
			}
			UpdateDepth((value != null) ? (value.Depth + 1) : (-1));
		}
	}

	public bool HasUnrealizedChildren
	{
		get
		{
			return m_HasUnrealizedChildren;
		}
		set
		{
			m_HasUnrealizedChildren = value;
			UpdateHasChildren();
		}
	}

	public IList<TreeViewNode> Children { get; }

	internal bool IsContentMode { get; set; }

	internal TreeNodeSelectionState SelectionState { get; set; }

	internal object ItemsSource
	{
		get
		{
			return m_itemsSource;
		}
		set
		{
			if (m_itemsDataSource != null)
			{
				m_itemsDataSource.CollectionChanged -= OnItemsSourceChanged;
			}
			m_itemsSource = value;
			m_itemsDataSource = ((value != null) ? new InspectingDataSource(value) : null);
			if (m_itemsDataSource != null)
			{
				m_itemsDataSource.CollectionChanged += OnItemsSourceChanged;
			}
			SyncChildrenNodesWithItemsSource();
		}
	}

	Type ICustomPropertyProvider.Type => typeof(TreeViewNode);

	public object Content
	{
		get
		{
			return GetValue(ContentProperty);
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	public int Depth
	{
		get
		{
			return (int)GetValue(DepthProperty);
		}
		private set
		{
			SetValue(DepthProperty, value);
		}
	}

	public bool HasChildren
	{
		get
		{
			return (bool)GetValue(HasChildrenProperty);
		}
		private set
		{
			SetValue(HasChildrenProperty, value);
		}
	}

	public bool IsExpanded
	{
		get
		{
			return (bool)GetValue(IsExpandedProperty);
		}
		set
		{
			SetValue(IsExpandedProperty, value);
		}
	}

	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(object), typeof(TreeViewNode), new FrameworkPropertyMetadata(null));


	public static DependencyProperty DepthProperty { get; } = DependencyProperty.Register("Depth", typeof(int), typeof(TreeViewNode), new FrameworkPropertyMetadata(-1));


	public static DependencyProperty HasChildrenProperty { get; } = DependencyProperty.Register("HasChildren", typeof(bool), typeof(TreeViewNode), new FrameworkPropertyMetadata(false, OnHasChildrenPropertyChanged));


	public static DependencyProperty IsExpandedProperty { get; } = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(TreeViewNode), new FrameworkPropertyMetadata(false, OnIsExpandedPropertyChanged));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(TreeViewNode), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TreeViewNode)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(TreeViewNode), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TreeViewNode)s).OnTemplatedParentChanged(e);
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

	internal event TypedEventHandler<TreeViewNode, IVectorChangedEventArgs> ChildrenChanged;

	internal event TypedEventHandler<TreeViewNode, DependencyPropertyChangedEventArgs> ExpandedChanged;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	public TreeViewNode()
	{
		TreeViewNodeVector treeViewNodeVector = new TreeViewNodeVector();
		treeViewNodeVector.SetParent(this);
		Children = treeViewNodeVector;
		treeViewNodeVector.VectorChanged += ChildVectorChanged;
	}

	private void UpdateDepth(int depth)
	{
		SetValue(DepthProperty, depth);
		foreach (TreeViewNode child in Children)
		{
			child.UpdateDepth(depth + 1);
		}
	}

	private void UpdateHasChildren()
	{
		bool flag = Children.Count != 0 || m_HasUnrealizedChildren;
		SetValue(HasChildrenProperty, flag);
	}

	private void ChildVectorChanged(IObservableVector<TreeViewNode> sender, IVectorChangedEventArgs args)
	{
		CollectionChange collectionChange = args.CollectionChange;
		uint index = args.Index;
		UpdateHasChildren();
		RaiseChildrenChanged(collectionChange, index);
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		this.ExpandedChanged?.Invoke(this, args);
	}

	private void RaiseChildrenChanged(CollectionChange collectionChange, uint index)
	{
		VectorChangedEventArgs args = new VectorChangedEventArgs(collectionChange, index);
		this.ChildrenChanged?.Invoke(this, args);
	}

	private void OnItemsSourceChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		switch (args.Action)
		{
		case NotifyCollectionChangedAction.Add:
			if (m_itemsDataSource.Count != Children.Count)
			{
				AddToChildrenNodes(args.NewStartingIndex, args.NewItems!.Count);
			}
			break;
		case NotifyCollectionChangedAction.Remove:
			if (m_itemsDataSource.Count != Children.Count)
			{
				RemoveFromChildrenNodes(args.OldStartingIndex, args.OldItems!.Count);
			}
			break;
		case NotifyCollectionChangedAction.Reset:
			SyncChildrenNodesWithItemsSource();
			break;
		case NotifyCollectionChangedAction.Replace:
			RemoveFromChildrenNodes(args.OldStartingIndex, args.OldItems!.Count);
			AddToChildrenNodes(args.NewStartingIndex, args.NewItems!.Count);
			break;
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	private void AddToChildrenNodes(int index, int count)
	{
		for (int num = index + count - 1; num >= index; num--)
		{
			object at = m_itemsDataSource.GetAt(num);
			TreeViewNode treeViewNode = new TreeViewNode();
			treeViewNode.Content = at;
			((TreeViewNodeVector)Children).InsertAt(index, treeViewNode, updateItemsSource: false);
		}
	}

	private void RemoveFromChildrenNodes(int index, int count)
	{
		for (int i = 0; i < count; i++)
		{
			((TreeViewNodeVector)Children).RemoveAt(index, updateItemsSource: false);
		}
	}

	private void SyncChildrenNodesWithItemsSource()
	{
		if (!AreChildrenNodesEqualToItemsSource())
		{
			TreeViewNodeVector treeViewNodeVector = (TreeViewNodeVector)Children;
			treeViewNodeVector.Clear(updateItemsSource: false, updateIsExpanded: false);
			int num = ((m_itemsDataSource != null) ? m_itemsDataSource.Count : 0);
			for (int i = 0; i < num; i++)
			{
				object at = m_itemsDataSource.GetAt(i);
				TreeViewNode treeViewNode = new TreeViewNode();
				treeViewNode.Content = at;
				treeViewNode.IsContentMode = true;
				treeViewNodeVector.Append(treeViewNode, updateItemsSource: false);
			}
		}
	}

	private bool AreChildrenNodesEqualToItemsSource()
	{
		IList<TreeViewNode> children = Children;
		int num = children?.Count ?? 0;
		int num2 = ((m_itemsDataSource != null) ? m_itemsDataSource.Count : 0);
		if (num != num2)
		{
			return false;
		}
		for (int i = 0; i < num2; i++)
		{
			if (children[i].Content != m_itemsDataSource.GetAt(i))
			{
				return false;
			}
		}
		return true;
	}

	private string GetContentAsString()
	{
		object content = Content;
		if (content != null)
		{
			if (content is ICustomPropertyProvider customPropertyProvider)
			{
				return customPropertyProvider.GetStringRepresentation();
			}
			if (!(content is IStringable stringable))
			{
				return content?.ToString() ?? GetType().Name;
			}
			return stringable.ToString();
		}
		return GetType().Name;
	}

	ICustomProperty ICustomPropertyProvider.GetCustomProperty(string name)
	{
		return null;
	}

	ICustomProperty ICustomPropertyProvider.GetIndexedProperty(string name, Type type)
	{
		return null;
	}

	string ICustomPropertyProvider.GetStringRepresentation()
	{
		return GetContentAsString();
	}

	public override string ToString()
	{
		return GetContentAsString();
	}

	private static void OnHasChildrenPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeViewNode treeViewNode = (TreeViewNode)sender;
		treeViewNode.OnPropertyChanged(args);
	}

	private static void OnIsExpandedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TreeViewNode treeViewNode = (TreeViewNode)sender;
		treeViewNode.OnPropertyChanged(args);
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

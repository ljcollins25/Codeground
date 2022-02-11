using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

[Windows.UI.Xaml.Data.Bindable]
public class FrameworkTemplate : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	internal class FrameworkTemplateEqualityComparer : IEqualityComparer<FrameworkTemplate>
	{
		public static readonly FrameworkTemplateEqualityComparer Default = new FrameworkTemplateEqualityComparer();

		private FrameworkTemplateEqualityComparer()
		{
		}

		public bool Equals(FrameworkTemplate? left, FrameworkTemplate? right)
		{
			if (left != right && !(left?._viewFactory == right?._viewFactory))
			{
				if (left?._viewFactory?.Target == right?._viewFactory?.Target)
				{
					return left?._viewFactory?.Method == right?._viewFactory?.Method;
				}
				return false;
			}
			return true;
		}

		public int GetHashCode(FrameworkTemplate obj)
		{
			return obj._hashCode;
		}
	}

	private readonly FrameworkTemplateBuilder? _viewFactory;

	private readonly int _hashCode;

	private readonly ManagedWeakReference? _ownerRef;

	private readonly XamlScope _xamlScope;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(FrameworkTemplate), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FrameworkTemplate)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(FrameworkTemplate), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FrameworkTemplate)s).OnTemplatedParentChanged(e);
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

	protected FrameworkTemplate()
	{
		throw new NotSupportedException("Use the factory constructors");
	}

	public FrameworkTemplate(Func<UIElement?>? factory)
	{
		Func<UIElement?> factory2 = factory;
		this._002Ector(null, (object? _) => factory2?.Invoke());
	}

	public FrameworkTemplate(object? owner, FrameworkTemplateBuilder? factory)
	{
		_viewFactory = factory;
		_ownerRef = WeakReferencePool.RentWeakReference(this, owner);
		_hashCode = (factory?.Target?.GetHashCode()).GetValueOrDefault() ^ (factory?.Method.GetHashCode() ?? 0);
		_xamlScope = ResourceResolver.CurrentScope;
	}

	public static implicit operator Func<UIElement?>(FrameworkTemplate? obj)
	{
		FrameworkTemplate obj2 = obj;
		return () => obj2?._viewFactory?.Invoke(null);
	}

	internal UIElement? LoadContentCached()
	{
		return FrameworkTemplatePool.Instance.DequeueTemplate(this);
	}

	internal void ReleaseTemplateRoot(UIElement templateRoot)
	{
		FrameworkTemplatePool.Instance.ReleaseTemplateRoot(templateRoot, this);
	}

	public UIElement? LoadContent()
	{
		UIElement result = null;
		ResourceResolver.PushNewScope(_xamlScope);
		if (_viewFactory != null)
		{
			result = _viewFactory!(_ownerRef?.Target);
		}
		ResourceResolver.PopScope();
		return result;
	}

	public override bool Equals(object? obj)
	{
		if (obj is FrameworkTemplate left && FrameworkTemplateEqualityComparer.Default.Equals(left, this))
		{
			return true;
		}
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return _hashCode;
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

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls;

[DebuggerDisplay("{DebugDisplay,nq}")]
[Windows.UI.Xaml.Data.Bindable]
public class ColumnDefinition : DependencyObject, DefinitionBase, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private double _effectiveMinSize;

	private double _measureArrangeSize;

	private double _sizeCache;

	private double _finalOffset;

	private GridUnitType _effectiveUnitType;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	private bool _WidthPropertyBackingFieldSet;

	private GridLength _WidthPropertyBackingField;

	private bool _MinWidthPropertyBackingFieldSet;

	private double _MinWidthPropertyBackingField;

	private bool _MaxWidthPropertyBackingFieldSet;

	private double _MaxWidthPropertyBackingField;

	[GeneratedDependencyProperty]
	public static DependencyProperty WidthProperty { get; } = CreateWidthProperty();


	public GridLength Width
	{
		get
		{
			return GetWidthValue();
		}
		set
		{
			SetWidthValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 0.0)]
	public static DependencyProperty MinWidthProperty { get; } = CreateMinWidthProperty();


	public double MinWidth
	{
		get
		{
			return GetMinWidthValue();
		}
		set
		{
			SetMinWidthValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = double.PositiveInfinity)]
	public static DependencyProperty MaxWidthProperty { get; } = CreateMaxWidthProperty();


	public double MaxWidth
	{
		get
		{
			return GetMaxWidthValue();
		}
		set
		{
			SetMaxWidthValue(value);
		}
	}

	public double ActualWidth => _measureArrangeSize;

	private string DebugDisplay => $"ColumnDefinition(Width={Width.ToDisplayString()};MinWidth={MinWidth};MaxWidth={MaxWidth}";

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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(ColumnDefinition), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ColumnDefinition)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(ColumnDefinition), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ColumnDefinition)s).OnTemplatedParentChanged(e);
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

	public ColumnDefinition()
	{
		IsAutoPropertyInheritanceEnabled = false;
		this.RegisterDisposablePropertyChangedCallback(delegate
		{
			InvalidateDefinition();
		});
	}

	private static GridLength GetWidthDefaultValue()
	{
		return GridLengthHelper.OneStar;
	}

	public static implicit operator ColumnDefinition(string value)
	{
		return new ColumnDefinition
		{
			Width = GridLength.ParseGridLength(value).First()
		};
	}

	private static GridLength GetMaxWidthDefaultValue()
	{
		return GridLengthHelper.OneStar;
	}

	private void InvalidateDefinition()
	{
		if (this.GetParent() is Grid grid)
		{
			grid.InvalidateDefinitions();
		}
	}

	double DefinitionBase.GetUserSizeValue()
	{
		return Width.Value;
	}

	GridUnitType DefinitionBase.GetUserSizeType()
	{
		return Width.GridUnitType;
	}

	double DefinitionBase.GetUserMaxSize()
	{
		return MaxWidth;
	}

	double DefinitionBase.GetUserMinSize()
	{
		return MinWidth;
	}

	double DefinitionBase.GetEffectiveMinSize()
	{
		return _effectiveMinSize;
	}

	void DefinitionBase.SetEffectiveMinSize(double value)
	{
		_effectiveMinSize = value;
	}

	double DefinitionBase.GetMeasureArrangeSize()
	{
		return _measureArrangeSize;
	}

	void DefinitionBase.SetMeasureArrangeSize(double value)
	{
		_measureArrangeSize = value;
	}

	double DefinitionBase.GetSizeCache()
	{
		return _sizeCache;
	}

	void DefinitionBase.SetSizeCache(double value)
	{
		_sizeCache = value;
	}

	double DefinitionBase.GetFinalOffset()
	{
		return _finalOffset;
	}

	void DefinitionBase.SetFinalOffset(double value)
	{
		_finalOffset = value;
	}

	GridUnitType DefinitionBase.GetEffectiveUnitType()
	{
		return _effectiveUnitType;
	}

	void DefinitionBase.SetEffectiveUnitType(GridUnitType type)
	{
		_effectiveUnitType = type;
	}

	double DefinitionBase.GetPreferredSize()
	{
		if (_effectiveUnitType == GridUnitType.Auto || !(_effectiveMinSize < _measureArrangeSize))
		{
			return _effectiveMinSize;
		}
		return _measureArrangeSize;
	}

	void DefinitionBase.UpdateEffectiveMinSize(double newValue)
	{
		_effectiveMinSize = Math.Max(_effectiveMinSize, newValue);
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

	private GridLength GetWidthValue()
	{
		if (!_WidthPropertyBackingFieldSet)
		{
			_WidthPropertyBackingField = (GridLength)GetValue(WidthProperty);
			_WidthPropertyBackingFieldSet = true;
		}
		return _WidthPropertyBackingField;
	}

	private void SetWidthValue(GridLength value)
	{
		SetValue(WidthProperty, value);
	}

	private static DependencyProperty CreateWidthProperty()
	{
		return DependencyProperty.Register("Width", typeof(GridLength), typeof(ColumnDefinition), new FrameworkPropertyMetadata((object)GetWidthDefaultValue(), (BackingFieldUpdateCallback)OnWidthBackingFieldUpdate));
	}

	private static void OnWidthBackingFieldUpdate(object instance, object newValue)
	{
		ColumnDefinition columnDefinition = instance as ColumnDefinition;
		columnDefinition._WidthPropertyBackingField = (GridLength)newValue;
		columnDefinition._WidthPropertyBackingFieldSet = true;
	}

	private double GetMinWidthValue()
	{
		if (!_MinWidthPropertyBackingFieldSet)
		{
			_MinWidthPropertyBackingField = (double)GetValue(MinWidthProperty);
			_MinWidthPropertyBackingFieldSet = true;
		}
		return _MinWidthPropertyBackingField;
	}

	private void SetMinWidthValue(double value)
	{
		SetValue(MinWidthProperty, value);
	}

	private static DependencyProperty CreateMinWidthProperty()
	{
		return DependencyProperty.Register("MinWidth", typeof(double), typeof(ColumnDefinition), new FrameworkPropertyMetadata((object)0.0, (BackingFieldUpdateCallback)OnMinWidthBackingFieldUpdate));
	}

	private static void OnMinWidthBackingFieldUpdate(object instance, object newValue)
	{
		ColumnDefinition columnDefinition = instance as ColumnDefinition;
		columnDefinition._MinWidthPropertyBackingField = (double)newValue;
		columnDefinition._MinWidthPropertyBackingFieldSet = true;
	}

	private double GetMaxWidthValue()
	{
		if (!_MaxWidthPropertyBackingFieldSet)
		{
			_MaxWidthPropertyBackingField = (double)GetValue(MaxWidthProperty);
			_MaxWidthPropertyBackingFieldSet = true;
		}
		return _MaxWidthPropertyBackingField;
	}

	private void SetMaxWidthValue(double value)
	{
		SetValue(MaxWidthProperty, value);
	}

	private static DependencyProperty CreateMaxWidthProperty()
	{
		return DependencyProperty.Register("MaxWidth", typeof(double), typeof(ColumnDefinition), new FrameworkPropertyMetadata((object)double.PositiveInfinity, (BackingFieldUpdateCallback)OnMaxWidthBackingFieldUpdate));
	}

	private static void OnMaxWidthBackingFieldUpdate(object instance, object newValue)
	{
		ColumnDefinition columnDefinition = instance as ColumnDefinition;
		columnDefinition._MaxWidthPropertyBackingField = (double)newValue;
		columnDefinition._MaxWidthPropertyBackingFieldSet = true;
	}
}

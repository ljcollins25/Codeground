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
public class RowDefinition : DependencyObject, DefinitionBase, IDependencyObjectStoreProvider, IWeakReferenceProvider
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

	private bool _HeightPropertyBackingFieldSet;

	private GridLength _HeightPropertyBackingField;

	private bool _MinHeightPropertyBackingFieldSet;

	private double _MinHeightPropertyBackingField;

	private bool _MaxHeightPropertyBackingFieldSet;

	private double _MaxHeightPropertyBackingField;

	[GeneratedDependencyProperty]
	public static DependencyProperty HeightProperty { get; } = CreateHeightProperty();


	public GridLength Height
	{
		get
		{
			return GetHeightValue();
		}
		set
		{
			SetHeightValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 0.0)]
	public static DependencyProperty MinHeightProperty { get; } = CreateMinHeightProperty();


	public double MinHeight
	{
		get
		{
			return GetMinHeightValue();
		}
		set
		{
			SetMinHeightValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = double.PositiveInfinity)]
	public static DependencyProperty MaxHeightProperty { get; } = CreateMaxHeightProperty();


	public double MaxHeight
	{
		get
		{
			return GetMaxHeightValue();
		}
		set
		{
			SetMaxHeightValue(value);
		}
	}

	public double ActualHeight => _measureArrangeSize;

	private string DebugDisplay => $"RowDefinition(Height={Height.ToDisplayString()};MinHeight={MinHeight};MaxHeight={MaxHeight}";

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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(RowDefinition), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((RowDefinition)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(RowDefinition), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((RowDefinition)s).OnTemplatedParentChanged(e);
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

	public RowDefinition()
	{
		IsAutoPropertyInheritanceEnabled = false;
		this.RegisterDisposablePropertyChangedCallback(delegate
		{
			InvalidateDefinition();
		});
	}

	private static GridLength GetHeightDefaultValue()
	{
		return GridLengthHelper.OneStar;
	}

	public static implicit operator RowDefinition(string value)
	{
		return new RowDefinition
		{
			Height = GridLength.ParseGridLength(value).First()
		};
	}

	private static GridLength GetMaxHeightDefaultValue()
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
		return Height.Value;
	}

	GridUnitType DefinitionBase.GetUserSizeType()
	{
		return Height.GridUnitType;
	}

	double DefinitionBase.GetUserMaxSize()
	{
		return MaxHeight;
	}

	double DefinitionBase.GetUserMinSize()
	{
		return MinHeight;
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

	private GridLength GetHeightValue()
	{
		if (!_HeightPropertyBackingFieldSet)
		{
			_HeightPropertyBackingField = (GridLength)GetValue(HeightProperty);
			_HeightPropertyBackingFieldSet = true;
		}
		return _HeightPropertyBackingField;
	}

	private void SetHeightValue(GridLength value)
	{
		SetValue(HeightProperty, value);
	}

	private static DependencyProperty CreateHeightProperty()
	{
		return DependencyProperty.Register("Height", typeof(GridLength), typeof(RowDefinition), new FrameworkPropertyMetadata((object)GetHeightDefaultValue(), (BackingFieldUpdateCallback)OnHeightBackingFieldUpdate));
	}

	private static void OnHeightBackingFieldUpdate(object instance, object newValue)
	{
		RowDefinition rowDefinition = instance as RowDefinition;
		rowDefinition._HeightPropertyBackingField = (GridLength)newValue;
		rowDefinition._HeightPropertyBackingFieldSet = true;
	}

	private double GetMinHeightValue()
	{
		if (!_MinHeightPropertyBackingFieldSet)
		{
			_MinHeightPropertyBackingField = (double)GetValue(MinHeightProperty);
			_MinHeightPropertyBackingFieldSet = true;
		}
		return _MinHeightPropertyBackingField;
	}

	private void SetMinHeightValue(double value)
	{
		SetValue(MinHeightProperty, value);
	}

	private static DependencyProperty CreateMinHeightProperty()
	{
		return DependencyProperty.Register("MinHeight", typeof(double), typeof(RowDefinition), new FrameworkPropertyMetadata((object)0.0, (BackingFieldUpdateCallback)OnMinHeightBackingFieldUpdate));
	}

	private static void OnMinHeightBackingFieldUpdate(object instance, object newValue)
	{
		RowDefinition rowDefinition = instance as RowDefinition;
		rowDefinition._MinHeightPropertyBackingField = (double)newValue;
		rowDefinition._MinHeightPropertyBackingFieldSet = true;
	}

	private double GetMaxHeightValue()
	{
		if (!_MaxHeightPropertyBackingFieldSet)
		{
			_MaxHeightPropertyBackingField = (double)GetValue(MaxHeightProperty);
			_MaxHeightPropertyBackingFieldSet = true;
		}
		return _MaxHeightPropertyBackingField;
	}

	private void SetMaxHeightValue(double value)
	{
		SetValue(MaxHeightProperty, value);
	}

	private static DependencyProperty CreateMaxHeightProperty()
	{
		return DependencyProperty.Register("MaxHeight", typeof(double), typeof(RowDefinition), new FrameworkPropertyMetadata((object)double.PositiveInfinity, (BackingFieldUpdateCallback)OnMaxHeightBackingFieldUpdate));
	}

	private static void OnMaxHeightBackingFieldUpdate(object instance, object newValue)
	{
		RowDefinition rowDefinition = instance as RowDefinition;
		rowDefinition._MaxHeightPropertyBackingField = (double)newValue;
		rowDefinition._MaxHeightPropertyBackingFieldSet = true;
	}
}

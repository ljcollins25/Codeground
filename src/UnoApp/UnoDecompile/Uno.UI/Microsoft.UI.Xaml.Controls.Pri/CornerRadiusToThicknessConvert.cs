using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Microsoft.UI.Xaml.Controls.Primitives;

[Windows.UI.Xaml.Data.Bindable]
public class CornerRadiusToThicknessConverter : DependencyObject, IValueConverter, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public double Multiplier
	{
		get
		{
			return (double)GetValue(MultiplierProperty);
		}
		set
		{
			SetValue(MultiplierProperty, value);
		}
	}

	public static DependencyProperty MultiplierProperty { get; } = DependencyProperty.Register("Multiplier", typeof(double), typeof(CornerRadiusToThicknessConverter), new FrameworkPropertyMetadata(1.0));


	public CornerRadiusToThicknessConverterKind ConversionKind
	{
		get
		{
			return (CornerRadiusToThicknessConverterKind)GetValue(ConversionKindProperty);
		}
		set
		{
			SetValue(ConversionKindProperty, value);
		}
	}

	public static DependencyProperty ConversionKindProperty { get; } = DependencyProperty.Register("ConversionKind", typeof(CornerRadiusToThicknessConverterKind), typeof(CornerRadiusToThicknessConverter), new FrameworkPropertyMetadata(CornerRadiusToThicknessConverterKind.FilterLeftAndRightFromTop));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(CornerRadiusToThicknessConverter), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CornerRadiusToThicknessConverter)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(CornerRadiusToThicknessConverter), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CornerRadiusToThicknessConverter)s).OnTemplatedParentChanged(e);
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

	private static Thickness Convert(CornerRadius radius, CornerRadiusToThicknessConverterKind filterKind, double multiplier)
	{
		Thickness result = default(Thickness);
		switch (filterKind)
		{
		case CornerRadiusToThicknessConverterKind.FilterLeftAndRightFromTop:
			result.Left = radius.TopLeft * multiplier;
			result.Right = radius.TopRight * multiplier;
			result.Top = 0.0;
			result.Bottom = 0.0;
			break;
		case CornerRadiusToThicknessConverterKind.FilterLeftAndRightFromBottom:
			result.Left = radius.BottomLeft * multiplier;
			result.Right = radius.BottomRight * multiplier;
			result.Top = 0.0;
			result.Bottom = 0.0;
			break;
		case CornerRadiusToThicknessConverterKind.FilterTopAndBottomFromLeft:
			result.Left = 0.0;
			result.Right = 0.0;
			result.Top = radius.TopLeft * multiplier;
			result.Bottom = radius.BottomLeft * multiplier;
			break;
		case CornerRadiusToThicknessConverterKind.FilterTopAndBottomFromRight:
			result.Left = 0.0;
			result.Right = 0.0;
			result.Top = radius.TopRight * multiplier;
			result.Bottom = radius.BottomRight * multiplier;
			break;
		case CornerRadiusToThicknessConverterKind.FilterTopFromTopLeft:
			result.Left = 0.0;
			result.Right = 0.0;
			result.Top = radius.TopLeft * multiplier;
			result.Bottom = 0.0;
			break;
		case CornerRadiusToThicknessConverterKind.FilterTopFromTopRight:
			result.Left = 0.0;
			result.Right = 0.0;
			result.Top = radius.TopRight * multiplier;
			result.Bottom = 0.0;
			break;
		case CornerRadiusToThicknessConverterKind.FilterRightFromTopRight:
			result.Left = 0.0;
			result.Right = radius.TopRight * multiplier;
			result.Top = 0.0;
			result.Bottom = 0.0;
			break;
		case CornerRadiusToThicknessConverterKind.FilterRightFromBottomRight:
			result.Left = 0.0;
			result.Right = radius.BottomRight * multiplier;
			result.Top = 0.0;
			result.Bottom = 0.0;
			break;
		case CornerRadiusToThicknessConverterKind.FilterBottomFromBottomRight:
			result.Left = 0.0;
			result.Right = 0.0;
			result.Top = 0.0;
			result.Bottom = radius.BottomRight * multiplier;
			break;
		case CornerRadiusToThicknessConverterKind.FilterBottomFromBottomLeft:
			result.Left = 0.0;
			result.Right = 0.0;
			result.Top = 0.0;
			result.Bottom = radius.BottomLeft * multiplier;
			break;
		case CornerRadiusToThicknessConverterKind.FilterLeftFromBottomLeft:
			result.Left = radius.BottomLeft * multiplier;
			result.Right = 0.0;
			result.Top = 0.0;
			result.Bottom = 0.0;
			break;
		case CornerRadiusToThicknessConverterKind.FilterLeftFromTopLeft:
			result.Left = radius.TopLeft * multiplier;
			result.Right = 0.0;
			result.Top = 0.0;
			result.Bottom = 0.0;
			break;
		}
		return result;
	}

	public object Convert(object value, Type targetType, object parameter, string language)
	{
		if (value is CornerRadius radius)
		{
			double multiplier = Multiplier;
			return Convert(radius, ConversionKind, multiplier);
		}
		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language)
	{
		throw new NotSupportedException();
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
public enum CornerRadiusToThicknessConverterKind
{
	FilterTopAndBottomFromLeft,
	FilterTopAndBottomFromRight,
	FilterLeftAndRightFromTop,
	FilterLeftAndRightFromBottom,
	FilterTopFromTopLeft,
	FilterTopFromTopRight,
	FilterRightFromTopRight,
	FilterRightFromBottomRight,
	FilterBottomFromBottomRight,
	FilterBottomFromBottomLeft,
	FilterLeftFromBottomLeft,
	FilterLeftFromTopLeft
}

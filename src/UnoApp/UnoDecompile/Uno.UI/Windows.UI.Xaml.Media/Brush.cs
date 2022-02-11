using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Media;

[TypeConverter(typeof(BrushConverter))]
[Windows.UI.Xaml.Data.Bindable]
public abstract class Brush : DependencyObject, IAnimationObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	internal delegate void ColorSetterHandler(Color color);

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	private bool _OpacityPropertyBackingFieldSet;

	private double _OpacityPropertyBackingField;

	private bool _TransformPropertyBackingFieldSet;

	private Transform _TransformPropertyBackingField;

	private bool _RelativeTransformPropertyBackingFieldSet;

	private Transform _RelativeTransformPropertyBackingField;

	public double Opacity
	{
		get
		{
			return GetOpacityValue();
		}
		set
		{
			SetOpacityValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 1.0, ChangedCallback = true)]
	public static DependencyProperty OpacityProperty { get; } = CreateOpacityProperty();


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty TransformProperty { get; } = CreateTransformProperty();


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Transform Transform
	{
		get
		{
			return GetTransformValue();
		}
		set
		{
			SetTransformValue(value);
		}
	}

	public Transform RelativeTransform
	{
		get
		{
			return GetRelativeTransformValue();
		}
		set
		{
			SetRelativeTransformValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null, ChangedCallback = true)]
	public static DependencyProperty RelativeTransformProperty { get; } = CreateRelativeTransformProperty();


	internal bool SupportsAssignAndObserveBrush
	{
		get
		{
			if (!(this is ImageBrush))
			{
				return !(this is AcrylicBrush);
			}
			return false;
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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(Brush), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Brush)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(Brush), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Brush)s).OnTemplatedParentChanged(e);
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
	protected virtual void PopulatePropertyInfoOverride(string propertyName, AnimationPropertyInfo animationPropertyInfo)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Brush", "void Brush.PopulatePropertyInfoOverride(string propertyName, AnimationPropertyInfo animationPropertyInfo)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PopulatePropertyInfo(string propertyName, AnimationPropertyInfo propertyInfo)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Brush", "void Brush.PopulatePropertyInfo(string propertyName, AnimationPropertyInfo propertyInfo)");
	}

	public Brush()
	{
	}

	public static implicit operator Brush(Color uiColor)
	{
		return SolidColorBrushHelper.FromARGB(uiColor.A, uiColor.R, uiColor.G, uiColor.B);
	}

	public static implicit operator Brush(string colorCode)
	{
		return SolidColorBrushHelper.Parse(colorCode);
	}

	protected virtual void OnOpacityChanged(double oldValue, double newValue)
	{
	}

	protected virtual void OnRelativeTransformChanged(Transform oldValue, Transform newValue)
	{
	}

	private protected Color GetColorWithOpacity(Color referenceColor)
	{
		return Color.FromArgb((byte)(Opacity * (double)(int)referenceColor.A), referenceColor.R, referenceColor.G, referenceColor.B);
	}

	internal static Color? GetColorWithOpacity(Brush brush, Color? defaultColor = null)
	{
		if (!TryGetColorWithOpacity(brush, out var color))
		{
			return defaultColor;
		}
		return color;
	}

	internal static bool TryGetColorWithOpacity(Brush brush, out Color color)
	{
		if (!(brush is SolidColorBrush solidColorBrush))
		{
			if (!(brush is GradientBrush gradientBrush))
			{
				if (brush is XamlCompositionBrushBase xamlCompositionBrushBase)
				{
					color = xamlCompositionBrushBase.FallbackColorWithOpacity;
					return true;
				}
				color = default(Color);
				return false;
			}
			color = gradientBrush.FallbackColorWithOpacity;
			return true;
		}
		color = solidColorBrush.ColorWithOpacity;
		return true;
	}

	internal static IDisposable AssignAndObserveBrush(Brush b, ColorSetterHandler colorSetter, Action imageBrushCallback = null)
	{
		if (b is SolidColorBrush solidColorBrush)
		{
			colorSetter(solidColorBrush.ColorWithOpacity);
			return WhenAnyChanged(new CompositeDisposable(2), solidColorBrush, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
			{
				colorSetter((s as SolidColorBrush).ColorWithOpacity);
			}, SolidColorBrush.ColorProperty, OpacityProperty);
		}
		if (b is GradientBrush gradientBrush)
		{
			CompositeDisposable compositeDisposable = new CompositeDisposable(4);
			colorSetter(gradientBrush.FallbackColorWithOpacity);
			WhenAnyChanged(compositeDisposable, gradientBrush, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
			{
				colorSetter((s as GradientBrush).FallbackColorWithOpacity);
			}, GradientBrush.FallbackColorProperty, OpacityProperty);
			SerialDisposable innerDisposable = new SerialDisposable();
			innerDisposable.Disposable = ObserveGradientBrushStops(gradientBrush.GradientStops, colorSetter);
			gradientBrush.RegisterDisposablePropertyChangedCallback(GradientBrush.GradientStopsProperty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
			{
				innerDisposable.Disposable = ObserveGradientBrushStops((s as GradientBrush).GradientStops, colorSetter);
			}).DisposeWith(compositeDisposable);
			innerDisposable.DisposeWith(compositeDisposable);
			return compositeDisposable;
		}
		if (b is AcrylicBrush)
		{
			Application.Current.RaiseRecoverableUnhandledException(new InvalidOperationException("AcrylicBrush is ** not ** supported by the AssignAndObserveBrush. (Instead you have to use the AcrylicBrush.Subscribe().)"));
			return Disposable.Empty;
		}
		if (b is ImageBrush)
		{
			Application.Current.RaiseRecoverableUnhandledException(new InvalidOperationException("ImageBrush is ** not ** supported by the AssignAndObserveBrush. (Instead you have to use the ImageBrush.Subscribe().)"));
			return Disposable.Empty;
		}
		if (b is XamlCompositionBrushBase xamlCompositionBrushBase)
		{
			colorSetter(xamlCompositionBrushBase.FallbackColorWithOpacity);
			return WhenAnyChanged(new CompositeDisposable(2), xamlCompositionBrushBase, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
			{
				colorSetter((s as XamlCompositionBrushBase).FallbackColorWithOpacity);
			}, XamlCompositionBrushBase.FallbackColorProperty, OpacityProperty);
		}
		colorSetter(Colors.Transparent);
		return Disposable.Empty;
	}

	private static IDisposable ObserveGradientBrushStops(GradientStopCollection stops, ColorSetterHandler colorSetter)
	{
		CompositeDisposable disposables = new CompositeDisposable();
		if (stops != null)
		{
			colorSetter(Colors.Transparent);
			stops.VectorChanged += OnVectorChanged;
			disposables.Add(delegate
			{
				stops.VectorChanged -= OnVectorChanged;
			});
		}
		return disposables;
		void OnVectorChanged(IObservableVector<GradientStop> sender, IVectorChangedEventArgs e)
		{
			colorSetter(Colors.Transparent);
			GradientStop[] array = stops.ToArray();
			foreach (GradientStop source in array)
			{
				WhenAnyChanged(disposables, source, delegate
				{
					colorSetter(Colors.Transparent);
				}, GradientStop.ColorProperty, GradientStop.OffsetProperty);
			}
		}
	}

	private static CompositeDisposable WhenAnyChanged(CompositeDisposable disposables, DependencyObject source, PropertyChangedCallback callback, params DependencyProperty[] properties)
	{
		foreach (DependencyProperty property in properties)
		{
			source.RegisterDisposablePropertyChangedCallback(property, callback).DisposeWith(disposables);
		}
		return disposables;
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

	private double GetOpacityValue()
	{
		if (!_OpacityPropertyBackingFieldSet)
		{
			_OpacityPropertyBackingField = (double)GetValue(OpacityProperty);
			_OpacityPropertyBackingFieldSet = true;
		}
		return _OpacityPropertyBackingField;
	}

	private void SetOpacityValue(double value)
	{
		SetValue(OpacityProperty, value);
	}

	private static DependencyProperty CreateOpacityProperty()
	{
		return DependencyProperty.Register("Opacity", typeof(double), typeof(Brush), new FrameworkPropertyMetadata((object)1.0, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Brush)instance).OnOpacityChanged((double)args.OldValue, (double)args.NewValue);
		}, (BackingFieldUpdateCallback)OnOpacityBackingFieldUpdate));
	}

	private static void OnOpacityBackingFieldUpdate(object instance, object newValue)
	{
		Brush brush = instance as Brush;
		brush._OpacityPropertyBackingField = (double)newValue;
		brush._OpacityPropertyBackingFieldSet = true;
	}

	private Transform GetTransformValue()
	{
		if (!_TransformPropertyBackingFieldSet)
		{
			_TransformPropertyBackingField = (Transform)GetValue(TransformProperty);
			_TransformPropertyBackingFieldSet = true;
		}
		return _TransformPropertyBackingField;
	}

	private void SetTransformValue(Transform value)
	{
		SetValue(TransformProperty, value);
	}

	private static DependencyProperty CreateTransformProperty()
	{
		return DependencyProperty.Register("Transform", typeof(Transform), typeof(Brush), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnTransformBackingFieldUpdate));
	}

	private static void OnTransformBackingFieldUpdate(object instance, object newValue)
	{
		Brush brush = instance as Brush;
		brush._TransformPropertyBackingField = (Transform)newValue;
		brush._TransformPropertyBackingFieldSet = true;
	}

	private Transform GetRelativeTransformValue()
	{
		if (!_RelativeTransformPropertyBackingFieldSet)
		{
			_RelativeTransformPropertyBackingField = (Transform)GetValue(RelativeTransformProperty);
			_RelativeTransformPropertyBackingFieldSet = true;
		}
		return _RelativeTransformPropertyBackingField;
	}

	private void SetRelativeTransformValue(Transform value)
	{
		SetValue(RelativeTransformProperty, value);
	}

	private static DependencyProperty CreateRelativeTransformProperty()
	{
		return DependencyProperty.Register("RelativeTransform", typeof(Transform), typeof(Brush), new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Brush)instance).OnRelativeTransformChanged((Transform)args.OldValue, (Transform)args.NewValue);
		}, (BackingFieldUpdateCallback)OnRelativeTransformBackingFieldUpdate));
	}

	private static void OnRelativeTransformBackingFieldUpdate(object instance, object newValue)
	{
		Brush brush = instance as Brush;
		brush._RelativeTransformPropertyBackingField = (Transform)newValue;
		brush._RelativeTransformPropertyBackingFieldSet = true;
	}
}

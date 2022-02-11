using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Core.Comparison;
using Uno.Diagnostics.Eventing;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml;

[ContentProperty(Name = "Setters")]
[Windows.UI.Xaml.Data.Bindable]
public class Style : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private delegate void ApplyToHandler(DependencyObject instance);

	public delegate Style StyleProviderHandler();

	private static Logger _logger = typeof(Style).Log();

	private static readonly Dictionary<Type, StyleProviderHandler> _lookup = new Dictionary<Type, StyleProviderHandler>(FastTypeComparer.Default);

	private static readonly Dictionary<Type, Style> _defaultStyleCache = new Dictionary<Type, Style>(FastTypeComparer.Default);

	private static readonly Dictionary<Type, StyleProviderHandler> _nativeLookup = new Dictionary<Type, StyleProviderHandler>(FastTypeComparer.Default);

	private static readonly Dictionary<Type, Style> _nativeDefaultStyleCache = new Dictionary<Type, Style>(FastTypeComparer.Default);

	private readonly XamlScope _xamlScope;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSealed
	{
		get
		{
			throw new NotImplementedException("The member bool Style.IsSealed is not implemented in Uno.");
		}
	}

	public Type? TargetType { get; set; }

	public Style? BasedOn { get; set; }

	public SetterBaseCollection Setters { get; } = new SetterBaseCollection();


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(Style), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Style)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(Style), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Style)s).OnTemplatedParentChanged(e);
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
	public void Seal()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Style", "void Style.Seal()");
	}

	public Style()
	{
		_xamlScope = ResourceResolver.CurrentScope;
	}

	public Style(Type targetType)
		: this()
	{
		if (targetType == null)
		{
			throw new ArgumentNullException("targetType");
		}
		TargetType = targetType;
	}

	internal void ApplyTo(DependencyObject o, DependencyPropertyValuePrecedences precedence)
	{
		if (o == null)
		{
			this.Log().Warn("Style.ApplyTo - Applied to null object - Skipping");
			return;
		}
		IDisposable disposable = o.OverrideLocalPrecedence(precedence);
		IDictionary<object, ApplyToHandler> dictionary = CreateSetterMap();
		ResourceResolver.PushNewScope(_xamlScope);
		IEnumerator<KeyValuePair<object, ApplyToHandler>> enumerator = dictionary.GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Value(o);
		}
		(o as IDependencyObjectStoreProvider).Store.UpdateResourceBindings(ResourceUpdateReason.StaticResourceLoading);
		ResourceResolver.PopScope();
		disposable?.Dispose();
	}

	internal void ClearInvalidProperties(DependencyObject dependencyObject, Style incomingStyle, DependencyPropertyValuePrecedences precedence)
	{
		IDictionary<object, ApplyToHandler> dictionary = CreateSetterMap();
		IDictionary<object, ApplyToHandler> dictionary2 = incomingStyle?.CreateSetterMap();
		foreach (KeyValuePair<object, ApplyToHandler> item in dictionary)
		{
			if (item.Key is DependencyProperty dependencyProperty && (dictionary2 == null || !dictionary2.ContainsKey(dependencyProperty)))
			{
				dependencyObject.ClearValue(dependencyProperty, precedence);
			}
		}
	}

	private IDictionary<object, ApplyToHandler> CreateSetterMap()
	{
		Dictionary<object, ApplyToHandler> dictionary = new Dictionary<object, ApplyToHandler>();
		EnumerateSetters(this, dictionary);
		return dictionary;
	}

	private void EnumerateSetters(Style style, Dictionary<object, ApplyToHandler> map)
	{
		if (style.BasedOn != null)
		{
			EnumerateSetters(style.BasedOn, map);
		}
		if (style.Setters == null)
		{
			return;
		}
		foreach (SetterBase setter2 in style.Setters)
		{
			if (setter2 is Setter setter)
			{
				if (setter.Property == null)
				{
					throw new InvalidOperationException("Property must be set on Setter used in Style");
				}
				map[setter.Property] = setter2.ApplyTo;
			}
			else if (setter2 is ICSharpPropertySetter iCSharpPropertySetter)
			{
				map[iCSharpPropertySetter.Property] = setter2.ApplyTo;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void RegisterDefaultStyleForType(Type type, StyleProviderHandler styleProvider)
	{
		RegisterDefaultStyleForType(type, styleProvider, isNative: false);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void RegisterDefaultStyleForType(Type type, StyleProviderHandler styleProvider, bool isNative)
	{
		if (isNative)
		{
			_nativeLookup[type] = styleProvider;
		}
		else
		{
			_lookup[type] = styleProvider;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void RegisterDefaultStyleForType(Type type, IXamlResourceDictionaryProvider dictionaryProvider, bool isNative)
	{
		IXamlResourceDictionaryProvider dictionaryProvider2 = dictionaryProvider;
		Type type2 = type;
		RegisterDefaultStyleForType(type2, new StyleProviderHandler(ProvideStyle), isNative);
		Style ProvideStyle()
		{
			ResourceDictionary resourceDictionary = dictionaryProvider2.GetResourceDictionary();
			if (resourceDictionary.TryGetValue(type2, out var value, shouldCheckSystem: false))
			{
				return (Style)value;
			}
			throw new InvalidOperationException($"{resourceDictionary} was registered as style provider for {type2} but doesn't contain matching style.");
		}
	}

	internal static Style? GetDefaultStyleForType(Type type)
	{
		return GetDefaultStyleForType(type, ShouldUseUWPDefaultStyle(type));
	}

	private static Style? GetDefaultStyleForType(Type type, bool useUWPDefaultStyles)
	{
		if (type == null)
		{
			return null;
		}
		Dictionary<Type, Style> dictionary = (useUWPDefaultStyles ? _defaultStyleCache : _nativeDefaultStyleCache);
		Dictionary<Type, StyleProviderHandler> dictionary2 = (useUWPDefaultStyles ? _lookup : _nativeLookup);
		if (!dictionary.TryGetValue(type, out var value) && dictionary2.TryGetValue(type, out var value2))
		{
			value = (dictionary[type] = value2());
			dictionary2.Remove(type);
		}
		if (value == null && !useUWPDefaultStyles)
		{
			if (_logger.IsEnabled(LogLevel.Debug))
			{
				_logger.LogDebug($"No native style found for type {type}, falling back on UWP style");
			}
			value = GetDefaultStyleForType(type, useUWPDefaultStyles: true);
		}
		if (_logger.IsEnabled(LogLevel.Debug))
		{
			if (value != null)
			{
				_logger.LogDebug(string.Format("Returning {0} style {1} for type {2}", useUWPDefaultStyles ? "UWP" : "native", value, type));
			}
			else
			{
				_logger.LogDebug(string.Format("No {0} style found for type {1}", useUWPDefaultStyles ? "UWP" : "native", type));
			}
		}
		return value;
	}

	internal static bool ShouldUseUWPDefaultStyle(Type type)
	{
		if (type != null && FeatureConfiguration.Style.UseUWPDefaultStylesOverride.TryGetValue(type, out var value))
		{
			return value;
		}
		return FeatureConfiguration.Style.UseUWPDefaultStyles;
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

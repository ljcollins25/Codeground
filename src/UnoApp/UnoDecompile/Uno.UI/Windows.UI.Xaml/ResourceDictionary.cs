using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

[Windows.UI.Xaml.Data.Bindable]
public class ResourceDictionary : DependencyObject, IDictionary<object, object>, ICollection<KeyValuePair<object, object>>, IEnumerable<KeyValuePair<object, object>>, IEnumerable, IDependencyObjectParse, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate object ResourceInitializer();

	private class SpecialValue
	{
	}

	private class LazyInitializer : SpecialValue
	{
		public XamlScope CurrentScope { get; }

		public ResourceInitializer Initializer { get; }

		public LazyInitializer(XamlScope currentScope, ResourceInitializer initializer)
		{
			CurrentScope = currentScope;
			Initializer = initializer;
		}
	}

	private class StaticResourceAliasRedirect : SpecialValue
	{
		public string ResourceKey { get; }

		public XamlParseContext ParseContext { get; }

		public StaticResourceAliasRedirect(string resourceKey, XamlParseContext parseContext)
		{
			ResourceKey = resourceKey;
			ParseContext = parseContext;
		}
	}

	private static class Themes
	{
		public static SpecializedResourceDictionary.ResourceKey Light { get; } = "Light";


		public static SpecializedResourceDictionary.ResourceKey Default { get; } = "Default";


		public static SpecializedResourceDictionary.ResourceKey Active { get; set; } = Light;

	}

	private readonly SpecializedResourceDictionary _values = new SpecializedResourceDictionary();

	private readonly List<ResourceDictionary> _mergedDictionaries = new List<ResourceDictionary>();

	private ResourceDictionary _themeDictionaries;

	private bool _hasUnmaterializedItems;

	private Uri _source;

	private ResourceDictionary _activeThemeDictionary;

	private SpecializedResourceDictionary.ResourceKey _activeTheme;

	private bool _isParsing;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Size
	{
		get
		{
			throw new NotImplementedException("The member uint ResourceDictionary.Size is not implemented in Uno.");
		}
	}

	public Uri Source
	{
		get
		{
			return _source;
		}
		set
		{
			if (!IsParsing)
			{
				ResourceDictionary source = ResourceResolver.RetrieveDictionaryForSource(value);
				CopyFrom(source);
			}
			_source = value;
		}
	}

	public IList<ResourceDictionary> MergedDictionaries => _mergedDictionaries;

	public IDictionary<object, object> ThemeDictionaries => GetOrCreateThemeDictionaries();

	internal bool IsSystemDictionary { get; set; }

	public object this[object key]
	{
		get
		{
			TryGetValue(key, out var value);
			return value;
		}
		set
		{
			if (key != null)
			{
				SpecializedResourceDictionary.ResourceKey resourceKey = new SpecializedResourceDictionary.ResourceKey(key);
				Set(in resourceKey, value, throwIfPresent: false);
			}
		}
	}

	public ICollection<object> Keys => _values.Keys.Select((SpecializedResourceDictionary.ResourceKey k) => ConvertKey(k)).ToList();

	public ICollection<object> Values => _values.Values;

	public int Count => _values.Count;

	public bool IsReadOnly => false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsParsing
	{
		get
		{
			return _isParsing;
		}
		set
		{
			if (!value)
			{
				throw new InvalidOperationException("IsParsing should never be set from user code.");
			}
			_isParsing = value;
			if (_isParsing)
			{
				ResourceResolver.PushSourceToScope(this);
			}
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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(ResourceDictionary), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ResourceDictionary)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(ResourceDictionary), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ResourceDictionary)s).OnTemplatedParentChanged(e);
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

	private event EventHandler ResourceDictionaryValueChange;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	private ResourceDictionary GetOrCreateThemeDictionaries()
	{
		if (_themeDictionaries == null)
		{
			_themeDictionaries = new ResourceDictionary();
			_themeDictionaries.ResourceDictionaryValueChange += delegate
			{
				_activeTheme = SpecializedResourceDictionary.ResourceKey.Empty;
			};
		}
		return _themeDictionaries;
	}

	internal object Lookup(object key)
	{
		if (!TryGetValue(key, out var value))
		{
			return null;
		}
		return value;
	}

	internal object Lookup(string key)
	{
		if (!TryGetValue(key, out var value))
		{
			return null;
		}
		return value;
	}

	public bool HasKey(object key)
	{
		return ContainsKey(key);
	}

	public bool Insert(object key, object value)
	{
		if (key != null)
		{
			SpecializedResourceDictionary.ResourceKey resourceKey = new SpecializedResourceDictionary.ResourceKey(key);
			Set(in resourceKey, value, throwIfPresent: false);
			return true;
		}
		return false;
	}

	public bool Remove(object key)
	{
		SpecializedResourceDictionary.ResourceKey key2 = new SpecializedResourceDictionary.ResourceKey(key);
		if (_values.Remove(in key2))
		{
			this.ResourceDictionaryValueChange?.Invoke(this, EventArgs.Empty);
			return true;
		}
		return false;
	}

	public bool Remove(KeyValuePair<object, object> key)
	{
		return Remove(key.Key);
	}

	public void Clear()
	{
		_values.Clear();
		this.ResourceDictionaryValueChange?.Invoke(this, EventArgs.Empty);
	}

	public void Add(object key, object value)
	{
		SpecializedResourceDictionary.ResourceKey resourceKey = new SpecializedResourceDictionary.ResourceKey(key);
		Set(in resourceKey, value, throwIfPresent: true);
	}

	public bool ContainsKey(object key)
	{
		return ContainsKey(key, shouldCheckSystem: true);
	}

	public bool ContainsKey(object key, bool shouldCheckSystem)
	{
		return ContainsKey(new SpecializedResourceDictionary.ResourceKey(key), shouldCheckSystem);
	}

	internal bool ContainsKey(SpecializedResourceDictionary.ResourceKey resourceKey, bool shouldCheckSystem)
	{
		if (!_values.ContainsKey(in resourceKey) && !ContainsKeyMerged(in resourceKey))
		{
			SpecializedResourceDictionary.ResourceKey activeTheme = Themes.Active;
			if (!ContainsKeyTheme(in resourceKey, in activeTheme))
			{
				if (shouldCheckSystem && !IsSystemDictionary)
				{
					return ResourceResolver.ContainsKeySystem(in resourceKey);
				}
				return false;
			}
		}
		return true;
	}

	public bool TryGetValue(object key, out object value)
	{
		return TryGetValue(key, out value, shouldCheckSystem: true);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetValue(object key, out object value, bool shouldCheckSystem)
	{
		SpecializedResourceDictionary.ResourceKey resourceKey = new SpecializedResourceDictionary.ResourceKey(key);
		return TryGetValue(in resourceKey, out value, shouldCheckSystem);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool TryGetValue(string resourceKey, out object value, bool shouldCheckSystem)
	{
		SpecializedResourceDictionary.ResourceKey resourceKey2 = new SpecializedResourceDictionary.ResourceKey(resourceKey);
		return TryGetValue(in resourceKey2, out value, shouldCheckSystem);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool TryGetValue(Type resourceKey, out object value, bool shouldCheckSystem)
	{
		SpecializedResourceDictionary.ResourceKey resourceKey2 = new SpecializedResourceDictionary.ResourceKey(resourceKey);
		return TryGetValue(in resourceKey2, out value, shouldCheckSystem);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool TryGetValue(in SpecializedResourceDictionary.ResourceKey resourceKey, out object value, bool shouldCheckSystem)
	{
		return TryGetValue(in resourceKey, SpecializedResourceDictionary.ResourceKey.Empty, out value, shouldCheckSystem);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool TryGetValue(in SpecializedResourceDictionary.ResourceKey resourceKey, SpecializedResourceDictionary.ResourceKey activeTheme, out object value, bool shouldCheckSystem)
	{
		if (_values.TryGetValue(in resourceKey, out value))
		{
			if (value is SpecialValue)
			{
				TryMaterializeLazy(in resourceKey, ref value);
				TryResolveAlias(ref value);
			}
			return true;
		}
		if (activeTheme.IsEmpty)
		{
			activeTheme = Themes.Active;
		}
		if (GetFromMerged(in resourceKey, out value))
		{
			return true;
		}
		if (GetFromTheme(in resourceKey, in activeTheme, out value))
		{
			return true;
		}
		if (shouldCheckSystem && !IsSystemDictionary)
		{
			return ResourceResolver.TrySystemResourceRetrieval(in resourceKey, out value);
		}
		return false;
	}

	private void Set(in SpecializedResourceDictionary.ResourceKey resourceKey, object value, bool throwIfPresent)
	{
		if (throwIfPresent && _values.ContainsKey(in resourceKey))
		{
			throw new ArgumentException("An entry with the same key already exists.");
		}
		if (value is WeakResourceInitializer weakResourceInitializer)
		{
			value = weakResourceInitializer.Initializer;
		}
		if (value is ResourceInitializer initializer)
		{
			_hasUnmaterializedItems = true;
			_values[in resourceKey] = new LazyInitializer(ResourceResolver.CurrentScope, initializer);
			this.ResourceDictionaryValueChange?.Invoke(this, EventArgs.Empty);
			return;
		}
		_values[in resourceKey] = value;
		if (value is ResourceDictionary)
		{
			this.ResourceDictionaryValueChange?.Invoke(this, EventArgs.Empty);
		}
	}

	private void TryMaterializeLazy(in SpecializedResourceDictionary.ResourceKey key, ref object value)
	{
		if (value is LazyInitializer lazyInitializer)
		{
			object obj = null;
			_values.Remove(in key);
			ResourceResolver.PushNewScope(lazyInitializer.CurrentScope);
			obj = (value = lazyInitializer.Initializer());
			_values[in key] = obj;
			if (obj is ResourceDictionary)
			{
				this.ResourceDictionaryValueChange?.Invoke(this, EventArgs.Empty);
			}
			ResourceResolver.PopScope();
		}
	}

	private bool TryResolveAlias(ref object value)
	{
		if (value is StaticResourceAliasRedirect staticResourceAliasRedirect)
		{
			ResourceResolver.ResolveResourceStatic(staticResourceAliasRedirect.ResourceKey, out var value2, staticResourceAliasRedirect.ParseContext);
			value = value2;
			return true;
		}
		return false;
	}

	private bool GetFromMerged(in SpecializedResourceDictionary.ResourceKey resourceKey, out object value)
	{
		int count = _mergedDictionaries.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (_mergedDictionaries[num].TryGetValue(in resourceKey, out value, shouldCheckSystem: false))
			{
				return true;
			}
		}
		value = null;
		return false;
	}

	private bool ContainsKeyMerged(in SpecializedResourceDictionary.ResourceKey resourceKey)
	{
		for (int num = _mergedDictionaries.Count - 1; num >= 0; num--)
		{
			if (_mergedDictionaries[num].ContainsKey(resourceKey, shouldCheckSystem: false))
			{
				return true;
			}
		}
		return false;
	}

	private ResourceDictionary GetActiveThemeDictionary(in SpecializedResourceDictionary.ResourceKey activeTheme)
	{
		if (!activeTheme.Equals(_activeTheme))
		{
			_activeTheme = activeTheme;
			ResourceDictionary themeDictionary = GetThemeDictionary(in activeTheme);
			if (themeDictionary == null)
			{
				SpecializedResourceDictionary.ResourceKey theme = Themes.Default;
				themeDictionary = GetThemeDictionary(in theme);
			}
			_activeThemeDictionary = themeDictionary;
		}
		return _activeThemeDictionary;
	}

	private ResourceDictionary GetThemeDictionary(in SpecializedResourceDictionary.ResourceKey theme)
	{
		object value = null;
		ResourceDictionary themeDictionaries = _themeDictionaries;
		if (themeDictionaries != null && themeDictionaries.TryGetValue(in theme, out value, shouldCheckSystem: false))
		{
			return value as ResourceDictionary;
		}
		return null;
	}

	private bool GetFromTheme(in SpecializedResourceDictionary.ResourceKey resourceKey, in SpecializedResourceDictionary.ResourceKey activeTheme, out object value)
	{
		ResourceDictionary activeThemeDictionary = GetActiveThemeDictionary(in activeTheme);
		if (activeThemeDictionary != null && activeThemeDictionary.TryGetValue(in resourceKey, out value, shouldCheckSystem: false))
		{
			return true;
		}
		return GetFromThemeMerged(in resourceKey, in activeTheme, out value);
	}

	private bool GetFromThemeMerged(in SpecializedResourceDictionary.ResourceKey resourceKey, in SpecializedResourceDictionary.ResourceKey activeTheme, out object value)
	{
		int count = _mergedDictionaries.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (_mergedDictionaries[num].GetFromTheme(in resourceKey, in activeTheme, out value))
			{
				return true;
			}
		}
		value = null;
		return false;
	}

	private bool ContainsKeyTheme(in SpecializedResourceDictionary.ResourceKey resourceKey, in SpecializedResourceDictionary.ResourceKey activeTheme)
	{
		return GetActiveThemeDictionary(in activeTheme)?.ContainsKey(resourceKey, shouldCheckSystem: false) ?? ContainsKeyThemeMerged(in resourceKey, in activeTheme);
	}

	private bool ContainsKeyThemeMerged(in SpecializedResourceDictionary.ResourceKey resourceKey, in SpecializedResourceDictionary.ResourceKey activeTheme)
	{
		int count = _mergedDictionaries.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (_mergedDictionaries[num].ContainsKeyTheme(in resourceKey, in activeTheme))
			{
				return true;
			}
		}
		return false;
	}

	internal void CopyFrom(ResourceDictionary source)
	{
		_values.Clear();
		_mergedDictionaries.Clear();
		_themeDictionaries?.Clear();
		_values.AddRange(source._values);
		_mergedDictionaries.AddRange(source._mergedDictionaries);
		if (source._themeDictionaries != null)
		{
			GetOrCreateThemeDictionaries().CopyFrom(source._themeDictionaries);
		}
	}

	private static object ConvertKey(SpecializedResourceDictionary.ResourceKey resourceKey)
	{
		return ((object)resourceKey.TypeKey) ?? ((object)resourceKey.Key);
	}

	public void Add(KeyValuePair<object, object> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Contains(KeyValuePair<object, object> item)
	{
		SpecializedResourceDictionary values = _values;
		SpecializedResourceDictionary.ResourceKey key = new SpecializedResourceDictionary.ResourceKey(item.Key);
		return values.ContainsKey(in key);
	}

	[NotImplemented]
	public void CopyTo(KeyValuePair<object, object>[] array, int arrayIndex)
	{
		throw new NotSupportedException();
	}

	public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
	{
		TryMaterializeAll();
		foreach (KeyValuePair<SpecializedResourceDictionary.ResourceKey, object> value2 in _values)
		{
			object value = value2.Value;
			if (TryResolveAlias(ref value))
			{
				yield return new KeyValuePair<object, object>(ConvertKey(value2.Key), value);
			}
			else
			{
				yield return new KeyValuePair<object, object>(ConvertKey(value2.Key), value2.Value);
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private void TryMaterializeAll()
	{
		if (!_hasUnmaterializedItems)
		{
			return;
		}
		List<KeyValuePair<SpecializedResourceDictionary.ResourceKey, object>> list = new List<KeyValuePair<SpecializedResourceDictionary.ResourceKey, object>>();
		foreach (KeyValuePair<SpecializedResourceDictionary.ResourceKey, object> value2 in _values)
		{
			if (value2.Value is LazyInitializer)
			{
				list.Add(value2);
			}
		}
		foreach (KeyValuePair<SpecializedResourceDictionary.ResourceKey, object> item in list)
		{
			object value = item.Value;
			SpecializedResourceDictionary.ResourceKey key = item.Key;
			TryMaterializeLazy(in key, ref value);
		}
		_hasUnmaterializedItems = false;
	}

	public void CreationComplete()
	{
		if (!IsParsing)
		{
			throw new InvalidOperationException("Called without matching IsParsing call. This method should never be called from user code.");
		}
		_isParsing = false;
		ResourceResolver.PopSourceFromScope();
	}

	internal void UpdateThemeBindings(ResourceUpdateReason updateReason)
	{
		foreach (object value in _values.Values)
		{
			if (value is IDependencyObjectStoreProvider dependencyObjectStoreProvider && dependencyObjectStoreProvider.Store.Parent == null)
			{
				dependencyObjectStoreProvider.Store.UpdateResourceBindings(updateReason, this);
			}
		}
		foreach (ResourceDictionary mergedDictionary in _mergedDictionaries)
		{
			mergedDictionary.UpdateThemeBindings(updateReason);
		}
	}

	internal static object GetStaticResourceAliasPassthrough(string resourceKey, XamlParseContext parseContext)
	{
		return new StaticResourceAliasRedirect(resourceKey, parseContext);
	}

	internal static void SetActiveTheme(SpecializedResourceDictionary.ResourceKey key)
	{
		Themes.Active = key;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Resources;

namespace Uno.UI;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class ResourceResolver
{
	public static class TraceProvider
	{
		public static readonly Guid Id = Guid.Parse("{15E13473-560E-4601-86FF-C9E1EDB73701}");

		public const int InitGenericXamlStart = 1;

		public const int InitGenericXamlStop = 2;
	}

	private static readonly Dictionary<string, Func<ResourceDictionary>> _registeredDictionariesByUri;

	private static readonly Dictionary<string, ResourceDictionary> _registeredDictionariesByAssembly;

	private static readonly Dictionary<string, Func<ResourceDictionary>> _registeredDictionariesByFilepath;

	private static int _assemblyRef;

	private static readonly IEventProvider _trace;

	private static readonly Logger _log;

	private static readonly Stack<XamlScope> _scopeStack;

	private static ResourceDictionary MasterDictionary => GlobalStaticResources.MasterDictionary;

	internal static XamlScope CurrentScope => _scopeStack.Peek();

	static ResourceResolver()
	{
		_registeredDictionariesByUri = new Dictionary<string, Func<ResourceDictionary>>(StringComparer.InvariantCultureIgnoreCase);
		_registeredDictionariesByAssembly = new Dictionary<string, ResourceDictionary>();
		_registeredDictionariesByFilepath = new Dictionary<string, Func<ResourceDictionary>>(StringComparer.InvariantCultureIgnoreCase);
		_assemblyRef = -1;
		_trace = Tracing.Get(TraceProvider.Id);
		_log = typeof(ResourceResolver).Log();
		_scopeStack = new Stack<XamlScope>();
		_scopeStack.Push(XamlScope.Create());
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static T ResolveResourceStatic<T>(object key, object context = null)
	{
		SpecializedResourceDictionary.ResourceKey resourceKey = new SpecializedResourceDictionary.ResourceKey(key);
		if (TryStaticRetrieval(in resourceKey, context, out var value) && value is T)
		{
			return (T)value;
		}
		return default(T);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static object ResolveResourceStatic(object key, Type type, object context = null)
	{
		SpecializedResourceDictionary.ResourceKey resourceKey = new SpecializedResourceDictionary.ResourceKey(key);
		if (TryStaticRetrieval(in resourceKey, context, out var value))
		{
			if (value.GetType().Is(type))
			{
				return value;
			}
			object obj = BindingPropertyHelper.Convert(() => type, value);
			if (obj == null && _log.IsEnabled(LogLevel.Warning))
			{
				_log.LogWarning($"Unable to convert value '{value}' of type '{value.GetType()}' to type '{type}'");
			}
			return obj;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool ResolveResourceStatic(object key, out object value, object context = null)
	{
		SpecializedResourceDictionary.ResourceKey resourceKey = new SpecializedResourceDictionary.ResourceKey(key);
		return TryStaticRetrieval(in resourceKey, context, out value);
	}

	internal static double ResolveTopLevelResourceDouble(SpecializedResourceDictionary.ResourceKey key, double fallbackValue = 0.0)
	{
		if (TryTopLevelRetrieval(in key, null, out var value) && value is double)
		{
			return (double)value;
		}
		return fallbackValue;
	}

	internal static object ResolveTopLevelResource(SpecializedResourceDictionary.ResourceKey key, object fallbackValue = null)
	{
		if (TryTopLevelRetrieval(in key, null, out var value) && value != null)
		{
			return value;
		}
		return fallbackValue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ApplyResource(DependencyObject owner, DependencyProperty property, object resourceKey, bool isThemeResourceExtension, object context = null)
	{
		ApplyResource(owner, property, resourceKey, isThemeResourceExtension, isHotReloadSupported: false, context);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ApplyResource(DependencyObject owner, DependencyProperty property, object resourceKey, bool isThemeResourceExtension, bool isHotReloadSupported, object context = null)
	{
		ResourceUpdateReason resourceUpdateReason = ResourceUpdateReason.None;
		if (isThemeResourceExtension)
		{
			resourceUpdateReason |= ResourceUpdateReason.ThemeResource;
		}
		if (isHotReloadSupported)
		{
			resourceUpdateReason |= ResourceUpdateReason.HotReload;
		}
		if (resourceUpdateReason == ResourceUpdateReason.None)
		{
			resourceUpdateReason = ResourceUpdateReason.StaticResourceLoading;
		}
		ApplyResource(owner, property, new SpecializedResourceDictionary.ResourceKey(resourceKey), resourceUpdateReason, context, null);
	}

	internal static void ApplyResource(DependencyObject owner, DependencyProperty property, SpecializedResourceDictionary.ResourceKey specializedKey, ResourceUpdateReason updateReason, object context, DependencyPropertyValuePrecedences? precedence)
	{
		if (TryStaticRetrieval(in specializedKey, context, out var value))
		{
			owner.SetValue(property, BindingPropertyHelper.Convert(() => property.Type, value), precedence);
			if (updateReason == ResourceUpdateReason.StaticResourceLoading)
			{
				return;
			}
		}
		(owner as IDependencyObjectStoreProvider).Store.SetResourceBinding(property, specializedKey, updateReason, context, precedence, null);
	}

	internal static bool ApplyVisualStateSetter(SpecializedResourceDictionary.ResourceKey resourceKey, object context, BindingPath bindingPath, DependencyPropertyValuePrecedences precedence, ResourceUpdateReason updateReason)
	{
		if (TryStaticRetrieval(in resourceKey, context, out var value) && bindingPath.DataContext != null)
		{
			DependencyProperty property = DependencyProperty.GetProperty(bindingPath.DataContext!.GetType(), bindingPath.LeafPropertyName);
			if (property != null && bindingPath.DataContext is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
			{
				bindingPath.Value = value;
				dependencyObjectStoreProvider.Store.SetResourceBinding(property, resourceKey, updateReason, context, precedence, bindingPath);
				return true;
			}
		}
		return false;
	}

	private static bool TryStaticRetrieval(in SpecializedResourceDictionary.ResourceKey resourceKey, object context, out object value)
	{
		IEnumerator<ManagedWeakReference> enumerator = CurrentScope.Sources.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ManagedWeakReference current = enumerator.Current;
			ResourceDictionary resourceDictionary = (current.Target as FrameworkElement)?.Resources ?? (current.Target as ResourceDictionary);
			if (resourceDictionary != null && resourceDictionary.TryGetValue(in resourceKey, out value, shouldCheckSystem: false))
			{
				return true;
			}
		}
		bool flag = TryTopLevelRetrieval(in resourceKey, context, out value);
		if (!flag && _log.IsEnabled(LogLevel.Warning))
		{
			_log.LogWarning("Couldn't statically resolve resource " + resourceKey.Key);
		}
		return flag;
	}

	internal static bool TryTopLevelRetrieval(in SpecializedResourceDictionary.ResourceKey resourceKey, object context, out object value)
	{
		value = null;
		Application current = Application.Current;
		if ((current == null || !current.Resources.TryGetValue(in resourceKey, out value, shouldCheckSystem: false)) && !TryAssemblyResourceRetrieval(in resourceKey, context, out value))
		{
			return TrySystemResourceRetrieval(in resourceKey, out value);
		}
		return true;
	}

	private static bool TryAssemblyResourceRetrieval(in SpecializedResourceDictionary.ResourceKey resourceKey, object context, out object value)
	{
		value = null;
		if (!(context is XamlParseContext xamlParseContext))
		{
			return false;
		}
		if (xamlParseContext.AssemblyName == "Uno.UI")
		{
			return false;
		}
		if (_registeredDictionariesByAssembly.TryGetValue(xamlParseContext.AssemblyName, out var value2))
		{
			foreach (KeyValuePair<object, object> item in value2)
			{
				ResourceDictionary resourceDictionary = item.Value as ResourceDictionary;
				if (resourceDictionary.TryGetValue(in resourceKey, out value, shouldCheckSystem: false))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static bool TrySystemResourceRetrieval(in SpecializedResourceDictionary.ResourceKey resourceKey, out object value)
	{
		return MasterDictionary.TryGetValue(in resourceKey, out value, shouldCheckSystem: false);
	}

	internal static bool ContainsKeySystem(in SpecializedResourceDictionary.ResourceKey resourceKey)
	{
		return MasterDictionary.ContainsKey(resourceKey, shouldCheckSystem: false);
	}

	internal static T GetSystemResource<T>(object key)
	{
		if (MasterDictionary.TryGetValue(key, out var value, shouldCheckSystem: false) && value is T)
		{
			return (T)value;
		}
		return default(T);
	}

	internal static void PushNewScope(XamlScope scope)
	{
		_scopeStack.Push(scope);
	}

	internal static void PushSourceToScope(DependencyObject source)
	{
		PushSourceToScope((source as IWeakReferenceProvider).WeakReference);
	}

	internal static void PushSourceToScope(ManagedWeakReference source)
	{
		XamlScope xamlScope = _scopeStack.Pop();
		_scopeStack.Push(xamlScope.Push(source));
	}

	internal static void PopSourceFromScope()
	{
		XamlScope xamlScope = _scopeStack.Pop();
		_scopeStack.Push(xamlScope.Pop());
	}

	internal static void PopScope()
	{
		_scopeStack.Pop();
		if (_scopeStack.Count == 0)
		{
			throw new InvalidOperationException("Base scope should never be popped.");
		}
	}

	internal static IDisposable WriteInitiateGlobalStaticResourcesEventActivity()
	{
		return _trace.WriteEventActivity(1, 2);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void RegisterResourceDictionaryBySource(string uri, XamlParseContext context, Func<ResourceDictionary> dictionary)
	{
		RegisterResourceDictionaryBySource(uri, context, dictionary, null);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void RegisterResourceDictionaryBySource(string uri, XamlParseContext context, Func<ResourceDictionary> dictionary, string filePath)
	{
		_registeredDictionariesByUri[uri] = dictionary;
		if (context != null)
		{
			ResourceDictionary resourceDictionary = _registeredDictionariesByAssembly.FindOrCreate(context.AssemblyName, () => new ResourceDictionary());
			ResourceDictionary.ResourceInitializer value = dictionary.Invoke;
			_assemblyRef++;
			resourceDictionary[_assemblyRef] = value;
		}
		if (filePath != null)
		{
			_registeredDictionariesByFilepath[filePath] = dictionary;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static ResourceDictionary RetrieveDictionaryForSource(Uri source)
	{
		if ((object)source == null)
		{
			throw new ArgumentNullException("source");
		}
		return RetrieveDictionaryForSource(source.AbsoluteUri, null);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static ResourceDictionary RetrieveDictionaryForSource(string source, string currentAbsolutePath)
	{
		if (source == null)
		{
			return new ResourceDictionary();
		}
		if (!XamlFilePathHelper.IsAbsolutePath(source))
		{
			source = XamlFilePathHelper.LocalResourcePrefix + XamlFilePathHelper.ResolveAbsoluteSource(currentAbsolutePath, source);
		}
		if (_registeredDictionariesByUri.TryGetValue(source, out var value))
		{
			return value();
		}
		throw new InvalidOperationException("Cannot locate resource from '" + source + "'");
	}

	internal static ResourceDictionary RetrieveDictionaryForFilePath(string filePath)
	{
		if (_registeredDictionariesByFilepath.TryGetValue(filePath, out var value))
		{
			return value();
		}
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static T RetrieveCustomResource<T>(string resourceId, string objectType, string propertyName, string propertyType)
	{
		if (CustomXamlResourceLoader.Current == null)
		{
			throw new InvalidOperationException("No custom resource loader set.");
		}
		object resourceInternal = CustomXamlResourceLoader.Current.GetResourceInternal(resourceId, objectType, propertyName, propertyType);
		if (resourceInternal is T)
		{
			return (T)resourceInternal;
		}
		return default(T);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static object ResolveStaticResourceAlias(string resourceKey, object parseContext)
	{
		return ResourceDictionary.GetStaticResourceAliasPassthrough(resourceKey, parseContext as XamlParseContext);
	}

	internal static void UpdateSystemThemeBindings(ResourceUpdateReason updateReason)
	{
		MasterDictionary.UpdateThemeBindings(updateReason);
	}
}

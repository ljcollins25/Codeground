using System;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace Uno.UI;

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class ResourceResolverSingleton
{
	private static ResourceResolverSingleton _instance;

	public static ResourceResolverSingleton Instance => _instance ?? (_instance = new ResourceResolverSingleton());

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ResolveResourceStatic(object key, out object value, object context)
	{
		return ResourceResolver.ResolveResourceStatic(key, out value, context);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object ResolveResourceStatic(object key, Type type, object context)
	{
		return ResourceResolver.ResolveResourceStatic(key, type, context);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyResource(DependencyObject owner, DependencyProperty property, object resourceKey, bool isThemeResourceExtension, bool isHotReloadSupported, object context)
	{
		ResourceResolver.ApplyResource(owner, property, resourceKey, isThemeResourceExtension, isHotReloadSupported, context);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyResource(DependencyObject owner, DependencyProperty property, object resourceKey, bool isThemeResourceExtension, object context)
	{
		ResourceResolver.ApplyResource(owner, property, resourceKey, isThemeResourceExtension, context);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object ResolveStaticResourceAlias(string resourceKey, object parseContext)
	{
		return ResourceResolver.ResolveStaticResourceAlias(resourceKey, parseContext);
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno.Disposables;
using Uno.Extensions;

namespace Windows.UI.Xaml;

public static class DependencyObjectExtensions
{
	private static ConditionalWeakTable<object, AttachedDependencyObject> _objectData = new ConditionalWeakTable<object, AttachedDependencyObject>();

	private static DependencyObjectStore GetStore(object instance)
	{
		if (instance is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			return dependencyObjectStoreProvider.Store;
		}
		return GetAttachedStore(instance);
	}

	internal static DependencyObjectStore GetAttachedStore(object instance)
	{
		return ((IDependencyObjectStoreProvider)GetAttachedDependencyObject(instance)).Store;
	}

	internal static AttachedDependencyObject GetAttachedDependencyObject(object instance)
	{
		return _objectData.GetValue(instance, (object i) => new AttachedDependencyObject(i));
	}

	internal static long GetDependencyObjectId(this object dependencyObject)
	{
		return GetStore(dependencyObject).ObjectId;
	}

	internal static object GetParent(this object dependencyObject)
	{
		return GetStore(dependencyObject).Parent;
	}

	internal static object GetParent(this IDependencyObjectStoreProvider provider)
	{
		return provider.Store.Parent;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	internal static void StoreTryEnableHardReferences(this IDependencyObjectStoreProvider provider)
	{
		provider.Store.TryEnableHardReferences();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	internal static void StoreDisableHardReferences(this IDependencyObjectStoreProvider provider)
	{
		provider.Store.DisableHardReferences();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	internal static Style StoreGetImplicitStyle(this IDependencyObjectStoreProvider provider, in SpecializedResourceDictionary.ResourceKey styleKey)
	{
		return provider.Store.GetImplicitStyle(in styleKey);
	}

	internal static IEnumerable<object> GetParents(this object dependencyObject)
	{
		for (object parent = dependencyObject.GetParent(); parent != null; parent = parent.GetParent())
		{
			yield return parent;
		}
	}

	internal static bool HasParent(this object dependencyObject, DependencyObject searchedParent)
	{
		for (object parent = dependencyObject.GetParent(); parent != null; parent = parent.GetParent())
		{
			if (parent == searchedParent)
			{
				return true;
			}
		}
		return false;
	}

	internal static void SetParent(this object dependencyObject, object parent)
	{
		GetStore(dependencyObject).Parent = parent;
	}

	internal static void SetLogicalParent(this FrameworkElement element, DependencyObject logicalParent)
	{
		element.LogicalParentOverride = logicalParent;
	}

	internal static bool IsAncestorOf(this DependencyObject ancestor, DependencyObject descendant)
	{
		object parent = descendant.GetParent();
		while (parent != null && ancestor != parent)
		{
			parent = parent.GetParent();
		}
		return ancestor == parent;
	}

	internal static IDisposable OverrideLocalPrecedence(this object instance, DependencyPropertyValuePrecedences precedence)
	{
		return GetStore(instance).OverrideLocalPrecedence(precedence);
	}

	public static object GetValue(this object instance, DependencyProperty property)
	{
		return GetStore(instance).GetValue(property);
	}

	public static object GetValue(this object instance, DependencyProperty property, DependencyPropertyValuePrecedences? precedence)
	{
		return GetStore(instance).GetValue(property, precedence);
	}

	public static object ReadLocalValue(this object instance, DependencyProperty property)
	{
		return GetStore(instance).ReadLocalValue(property);
	}

	internal static object GetPrecedenceSpecificValue(this DependencyObject instance, DependencyProperty property, DependencyPropertyValuePrecedences precedence)
	{
		return GetStore(instance).GetValue(property, precedence, isPrecedenceSpecific: true);
	}

	internal static void PropagateInheritedProperties(this DependencyObject instance)
	{
		GetStore(instance).PropagateInheritedProperties();
	}

	internal static (object value, DependencyPropertyValuePrecedences precedence) GetValueUnderPrecedence(this DependencyObject instance, DependencyProperty property, DependencyPropertyValuePrecedences precedence)
	{
		return GetStore(instance).GetValueUnderPrecedence(property, precedence);
	}

	internal static (object value, DependencyPropertyValuePrecedences precedence)[] GetValueForEachPrecedences(this DependencyObject instance, DependencyProperty property)
	{
		List<object> propertyDetails = GetStore(instance).GetPropertyDetails(property).ToList();
		return (from DependencyPropertyValuePrecedences precedence in Enum.GetValues(typeof(DependencyPropertyValuePrecedences))
			select (propertyDetails[(int)precedence], precedence)).ToArray();
	}

	internal static void ClearValue(this DependencyObject instance, DependencyProperty property, DependencyPropertyValuePrecedences precedence)
	{
		instance.SetValue(property, DependencyProperty.UnsetValue, precedence);
	}

	public static void SetValue(this object instance, DependencyProperty property, object value)
	{
		GetStore(instance).SetValue(property, value, DependencyPropertyValuePrecedences.Local);
	}

	public static void SetValue(this DependencyObject instance, DependencyProperty property, object value, DependencyPropertyValuePrecedences? precedence)
	{
		GetStore(instance).SetValue(property, value, precedence ?? DependencyPropertyValuePrecedences.Local);
	}

	public static void SetValue(this object instance, DependencyProperty property, object value, DependencyPropertyValuePrecedences? precedence)
	{
		GetStore(instance).SetValue(property, value, precedence ?? DependencyPropertyValuePrecedences.Local);
	}

	internal static void CoerceValue(this IDependencyObjectStoreProvider storeProvider, DependencyProperty property)
	{
		storeProvider.Store.CoerceValue(property);
	}

	public static IDisposable RegisterDisposablePropertyChangedCallback(this object instance, DependencyProperty property, PropertyChangedCallback callback)
	{
		return GetStore(instance).RegisterPropertyChangedCallback(property, callback);
	}

	public static IDisposable RegisterDisposablePropertyChangedCallback(this object instance, ExplicitPropertyChangedCallback handler)
	{
		return GetStore(instance).RegisterPropertyChangedCallback(handler);
	}

	internal static IDisposable RegisterDisposableNestedPropertyChangedCallback(this DependencyObject instance, PropertyChangedCallback callback, params DependencyProperty[][] properties)
	{
		if (instance == null)
		{
			return Disposable.Empty;
		}
		return (from @group in properties.Where(new Func<DependencyProperty[], bool>(Enumerable.Any)).GroupBy(new Func<DependencyProperty[], DependencyProperty>(Enumerable.First), (DependencyProperty[] propertyPath) => propertyPath.Skip(1).ToArray()).Where(new Func<IGrouping<DependencyProperty, DependencyProperty[]>, bool>(Enumerable.Any))
			where @group.Key != null
			select @group).Select(delegate(IGrouping<DependencyProperty, DependencyProperty[]> group)
		{
			DependencyProperty key = group.Key;
			DependencyProperty[][] subProperties = group.ToArray();
			if (!instance.GetType().Is(key.OwnerType) && !key.IsAttached)
			{
				return Disposable.Empty;
			}
			SerialDisposable childDisposable = new SerialDisposable();
			childDisposable.Disposable = (instance.GetValue(key) as DependencyObject)?.RegisterDisposableNestedPropertyChangedCallback(callback, subProperties);
			IDisposable disposable = instance.RegisterDisposablePropertyChangedCallback(key, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
			{
				callback(s, e);
				childDisposable.Disposable = s?.RegisterDisposableNestedPropertyChangedCallback(callback, subProperties);
			});
			return new CompositeDisposable(disposable, childDisposable);
		}).Apply((IEnumerable<IDisposable> disposables) => new CompositeDisposable(disposables));
	}

	internal static IDisposable RegisterParentChangedCallback(this DependencyObject instance, object key, ParentChangedCallback handler)
	{
		return GetStore(instance).RegisterParentChangedCallback(key, handler);
	}

	internal static bool IsDependencyPropertySet(this DependencyObject dependencyObject, DependencyProperty property)
	{
		return GetStore(dependencyObject).GetCurrentHighestValuePrecedence(property) != DependencyPropertyValuePrecedences.DefaultValue;
	}

	internal static bool IsDependencyPropertyLocallySet(this DependencyObject dependencyObject, DependencyProperty property)
	{
		return GetStore(dependencyObject).GetCurrentHighestValuePrecedence(property) <= DependencyPropertyValuePrecedences.Local;
	}

	internal static DependencyPropertyValuePrecedences GetCurrentHighestValuePrecedence(this DependencyObject dependencyObject, DependencyProperty property)
	{
		return GetStore(dependencyObject).GetCurrentHighestValuePrecedence(property);
	}

	internal static void InvalidateMeasure(this DependencyObject d)
	{
		((d as UIElement) ?? d.GetParents().OfType<UIElement>().FirstOrDefault())?.InvalidateMeasure();
	}

	internal static void InvalidateArrange(this DependencyObject d)
	{
		((d as UIElement) ?? d.GetParents().OfType<UIElement>().FirstOrDefault())?.InvalidateArrange();
	}

	internal static void InvalidateRender(this DependencyObject d)
	{
		((d as UIElement) ?? d.GetParents().OfType<UIElement>().FirstOrDefault())?.InvalidateRender();
	}

	internal static void RegisterDefaultValueProvider(this IDependencyObjectStoreProvider storeProvider, DependencyObjectStore.DefaultValueProvider provider)
	{
		storeProvider.Store.RegisterDefaultValueProvider(provider);
	}

	internal static void RegisterPropertyChangedCallbackStrong(this IDependencyObjectStoreProvider storeProvider, ExplicitPropertyChangedCallback handler)
	{
		storeProvider.Store.RegisterPropertyChangedCallbackStrong(handler);
	}

	internal static bool IsRightToLeft(this DependencyObject dependencyObject)
	{
		if (dependencyObject is FrameworkElement frameworkElement)
		{
			return frameworkElement.FlowDirection == FlowDirection.RightToLeft;
		}
		return false;
	}
}

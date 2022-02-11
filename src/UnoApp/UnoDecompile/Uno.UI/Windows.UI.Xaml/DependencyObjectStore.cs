using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Uno.Collections;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

public class DependencyObjectStore : IDisposable
{
	private class AncestorsDictionary
	{
		private readonly HashtableEx _entries = new HashtableEx();

		internal bool TryGetValue(object key, out bool isAncestor)
		{
			if (_entries.TryGetValue(key, out var value))
			{
				isAncestor = (bool)value;
				return true;
			}
			isAncestor = false;
			return false;
		}

		internal void Set(object key, bool isAncestor)
		{
			_entries[key] = isAncestor;
		}

		internal void Clear()
		{
			_entries.Clear();
		}
	}

	private delegate void DataContextProviderAction(IDataContextProvider provider);

	private delegate void ObjectAction(object instance);

	internal delegate bool DefaultValueProvider(DependencyProperty property, out object defaultValue);

	public static class TraceProvider
	{
		public static readonly Guid Id = new Guid(1125107793u, 59671, 17799, 175, 123, 90, 28, 229, 161, 148, 29);

		public const int GetValue = 1;

		public const int SetValueStart = 2;

		public const int SetValueStop = 3;

		public const int CreationTask = 4;

		public const int DataContextChangedStart = 5;

		public const int DataContextChangedStop = 6;
	}

	private readonly struct InheritedPropertyChangedCallbackDisposable : IDisposable
	{
		private readonly DependencyObjectStore ChildStore;

		private readonly ManagedWeakReference ObjectStoreWeak;

		public InheritedPropertyChangedCallbackDisposable(ManagedWeakReference objectStoreWeak, DependencyObjectStore childStore)
		{
			ChildStore = childStore;
			ObjectStoreWeak = objectStoreWeak;
		}

		public void Dispose()
		{
			CleanupInheritedPropertyChangedCallback(ObjectStoreWeak, ChildStore);
		}
	}

	private readonly struct InheritedPropertiesDisposable : IDisposable
	{
		private readonly IDisposable _inheritedPropertiesCallback;

		private readonly DependencyObjectStore _owner;

		public InheritedPropertiesDisposable(DependencyObjectStore owner, IDisposable inheritedPropertiesCallback)
		{
			_owner = owner;
			_inheritedPropertiesCallback = inheritedPropertiesCallback;
		}

		public void Dispose()
		{
			_inheritedPropertiesCallback.Dispose();
			_owner.CleanupInheritedProperties();
		}
	}

	private class DependencyPropertyPath : IEquatable<DependencyPropertyPath?>
	{
		public class Comparer : IEqualityComparer<DependencyPropertyPath?>
		{
			public static Comparer Default { get; } = new Comparer();


			private Comparer()
			{
			}

			public bool Equals(DependencyPropertyPath? x, DependencyPropertyPath? y)
			{
				return x?.Equals(y) ?? false;
			}

			public int GetHashCode(DependencyPropertyPath? obj)
			{
				return obj?.GetHashCode() ?? 0;
			}
		}

		public DependencyObject Instance { get; }

		public DependencyProperty Property { get; }

		public DependencyPropertyPath(DependencyObject instance, DependencyProperty property)
		{
			Instance = instance;
			Property = property;
		}

		public override int GetHashCode()
		{
			return Instance.GetHashCode() ^ Property.UniqueId.GetHashCode();
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as DependencyPropertyPath);
		}

		public bool Equals(DependencyPropertyPath? other)
		{
			if (other != null && Instance == other!.Instance)
			{
				return Property.UniqueId == other!.Property.UniqueId;
			}
			return false;
		}
	}

	private class WeakReferenceValueComparer : IEqualityComparer<WeakReference>
	{
		public static readonly WeakReferenceValueComparer Default = new WeakReferenceValueComparer();

		public bool Equals(WeakReference? x, WeakReference? y)
		{
			return x?.Target == y?.Target;
		}

		public int GetHashCode(WeakReference obj)
		{
			return obj?.GetHashCode() ?? 0;
		}
	}

	private readonly object _gate = new object();

	private readonly HashtableEx _childrenBindableMap = new HashtableEx(DependencyPropertyComparer.Default);

	private readonly List<object?> _childrenBindable = new List<object>();

	private bool _isApplyingTemplateBindings;

	private bool _isApplyingDataContextBindings;

	private bool _bindingsSuspended;

	private readonly DependencyProperty _dataContextProperty;

	private readonly DependencyProperty _templatedParentProperty;

	private static readonly IEventProvider _trace;

	private static long _objectIdCounter;

	private bool _isDisposed;

	private readonly DependencyPropertyDetailsCollection _properties;

	private ResourceBindingCollection? _resourceBindings;

	private DependencyProperty _parentTemplatedParentProperty = UIElement.TemplatedParentProperty;

	private DependencyProperty _parentDataContextProperty = UIElement.DataContextProperty;

	private ImmutableList<ExplicitPropertyChangedCallback> _genericCallbacks = ImmutableList<ExplicitPropertyChangedCallback>.Empty;

	private ImmutableList<DependencyObjectStore> _childrenStores = ImmutableList<DependencyObjectStore>.Empty;

	private ImmutableList<ParentChangedCallback> _parentChangedCallbacks = ImmutableList<ParentChangedCallback>.Empty;

	private readonly ManagedWeakReference _originalObjectRef;

	private DependencyObject? _hardOriginalObjectRef;

	private ManagedWeakReference? _thisWeakRef;

	private readonly Type _originalObjectType;

	private readonly SerialDisposable _inheritedProperties = new SerialDisposable();

	private ManagedWeakReference? _parentRef;

	private object? _hardParentRef;

	private readonly Dictionary<DependencyProperty, ManagedWeakReference> _inheritedForwardedProperties = new Dictionary<DependencyProperty, ManagedWeakReference>(DependencyPropertyComparer.Default);

	private Stack<DependencyPropertyValuePrecedences?>? _overriddenPrecedences;

	private static long _propertyChangedToken;

	private readonly Dictionary<long, IDisposable> _propertyChangedTokens = new Dictionary<long, IDisposable>();

	private bool _registeringInheritedProperties;

	private bool _unregisteringInheritedProperties;

	private bool _parentUnregisteringInheritedProperties;

	private bool _isSettingPersistentResourceBinding;

	private SpecializedResourceDictionary.ResourceKey? _themeLastUsed;

	private static readonly bool _validatePropertyOwner;

	private static readonly List<DependencyPropertyPath> _propagationBypass;

	private static readonly Dictionary<DependencyPropertyPath, object?> _propagationBypassed;

	private HashSet<DependencyProperty> _updatedProperties = new HashSet<DependencyProperty>(DependencyPropertyComparer.Default);

	private bool _isUpdatingChildResourceBindings;

	internal DependencyProperty DataContextProperty => _dataContextProperty;

	internal DependencyProperty TemplatedParentProperty => _templatedParentProperty;

	public object? Parent
	{
		get
		{
			object obj = _hardParentRef;
			if (obj == null)
			{
				ManagedWeakReference? parentRef = _parentRef;
				if (parentRef == null)
				{
					return null;
				}
				obj = parentRef!.Target;
			}
			return obj;
		}
		set
		{
			if (_parentRef?.Target != value || (_parentRef != null && value == null))
			{
				DisableHardReferences();
				object previousParent = _parentRef?.Target;
				if (_parentRef != null)
				{
					WeakReferencePool.ReturnWeakReference(this, _parentRef);
				}
				_parentRef = null;
				if (value != null)
				{
					_parentRef = WeakReferencePool.RentWeakReference(this, value);
				}
				_inheritedProperties.Disposable = null;
				if (value is IDependencyObjectStoreProvider parentProvider)
				{
					TryRegisterInheritedProperties(parentProvider);
				}
				OnParentChanged(previousParent, value);
			}
		}
	}

	public bool IsAutoPropertyInheritanceEnabled { get; set; } = true;


	internal long ObjectId { get; }

	public DependencyObject? ActualInstance => _hardOriginalObjectRef ?? (_originalObjectRef.Target as DependencyObject);

	private ManagedWeakReference ThisWeakReference => _thisWeakRef ?? (_thisWeakRef = WeakReferencePool.RentWeakReference(this, this));

	internal bool AreHardReferencesEnabled => _hardParentRef != null;

	public void SetTemplatedParent(FrameworkElement? templatedParent)
	{
		if (!_isApplyingTemplateBindings && !_bindingsSuspended)
		{
			_isApplyingTemplateBindings = true;
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().DebugFormat("{0}.ApplyTemplateBindings({1}/{2}) (h:{3:X8})", _originalObjectType.ToString(), templatedParent?.GetType().ToString() ?? "[null]", templatedParent?.GetHashCode().ToString("X8", CultureInfo.InvariantCulture) ?? "[null]", ActualInstance?.GetHashCode());
			}
			_properties.ApplyTemplatedParent(templatedParent);
			ApplyChildrenBindable(templatedParent, isTemplatedParent: true);
			_isApplyingTemplateBindings = false;
		}
	}

	private void ApplyChildrenBindable(object? inheritedValue, bool isTemplatedParent)
	{
		for (int i = 0; i < _childrenBindable.Count; i++)
		{
			object obj = _childrenBindable[i];
			IDependencyObjectStoreProvider dependencyObjectStoreProvider = obj as IDependencyObjectStoreProvider;
			object obj2 = dependencyObjectStoreProvider?.GetParent();
			if (obj2 != null && obj2 != ActualInstance)
			{
				continue;
			}
			if (dependencyObjectStoreProvider != null)
			{
				SetInherited(dependencyObjectStoreProvider, inheritedValue, isTemplatedParent);
			}
			else
			{
				if (obj is string)
				{
					continue;
				}
				if (obj is IList list)
				{
					for (int j = 0; j < list.Count; j++)
					{
						if (list[j] is IDependencyObjectStoreProvider provider2)
						{
							SetInherited(provider2, inheritedValue, isTemplatedParent);
						}
					}
				}
				else
				{
					if (!(obj is IEnumerable enumerable))
					{
						continue;
					}
					foreach (object item in enumerable)
					{
						if (item is IDependencyObjectStoreProvider provider3)
						{
							SetInherited(provider3, inheritedValue, isTemplatedParent);
						}
					}
				}
			}
		}
		static void SetInherited(IDependencyObjectStoreProvider provider, object? inheritedValue, bool isTemplatedParent)
		{
			if (isTemplatedParent)
			{
				provider.Store.SetInheritedTemplatedParent(inheritedValue);
			}
			else
			{
				provider.Store.SetInheritedDataContext(inheritedValue);
			}
		}
	}

	private void SetInheritedTemplatedParent(object? templatedParent)
	{
		SetValue(_templatedParentProperty, templatedParent, DependencyPropertyValuePrecedences.Inheritance, _properties.TemplatedParentPropertyDetails);
	}

	private void SetInheritedDataContext(object? dataContext)
	{
		SetValue(_dataContextProperty, dataContext, DependencyPropertyValuePrecedences.Inheritance, _properties.DataContextPropertyDetails);
	}

	public void ApplyCompiledBindings()
	{
		_properties.ApplyCompiledBindings();
	}

	internal void ApplyElementNameBindings()
	{
		_properties.ApplyElementNameBindings();
	}

	private string GetOwnerDebugString()
	{
		return ActualInstance?.GetType().ToString() ?? "[collected]";
	}

	private static void InitializeStaticBinder()
	{
		BindingPath.RegisterPropertyChangedRegistrationHandler(new BindingPath.PropertyChangedRegistrationHandler(SubscribeToDependencyPropertyChanged));
	}

	public void RestoreBindings()
	{
	}

	public void ClearBindings()
	{
	}

	public void SuspendBindings()
	{
		_bindingsSuspended = true;
		_properties.SuspendBindings();
	}

	public void ResumeBindings()
	{
		_bindingsSuspended = false;
		_properties.ResumeBindings();
	}

	private void BinderDispose()
	{
		lock (_gate)
		{
			if (_isDisposed)
			{
				return;
			}
			_isDisposed = true;
		}
		_properties.Dispose();
	}

	private void OnDataContextChanged(object? providedDataContext, object? actualDataContext, DependencyPropertyValuePrecedences precedence)
	{
		BindingExpression bindingExpression = _properties.FindDataContextBinding();
		if (bindingExpression != null && precedence == DependencyPropertyValuePrecedences.Inheritance)
		{
			if (bindingExpression.ParentBinding.RelativeSource == null)
			{
				bindingExpression.DataContext = providedDataContext;
			}
		}
		else if (!_isApplyingDataContextBindings && !_bindingsSuspended)
		{
			_isApplyingDataContextBindings = true;
			IDisposable disposable = TryWriteDataContextChangedEventActivity();
			if (disposable != null)
			{
				ApplyWithTrace(actualDataContext, disposable);
			}
			else
			{
				ApplyDataContext(actualDataContext);
			}
			_isApplyingDataContextBindings = false;
		}
		void ApplyWithTrace(object? actualDataContext, IDisposable trace)
		{
			using (trace)
			{
				ApplyDataContext(actualDataContext);
			}
		}
	}

	private void ApplyDataContext(object? actualDataContext)
	{
		_properties.ApplyDataContext(actualDataContext);
		ApplyChildrenBindable(actualDataContext, isTemplatedParent: false);
	}

	private IDisposable? TryWriteDataContextChangedEventActivity()
	{
		IDisposable result = null;
		if (_trace.IsEnabled)
		{
			result = _trace.WriteEventActivity(5, 6, GetTraceProperties());
		}
		return result;
	}

	private object?[] GetTraceProperties()
	{
		return new object[2]
		{
			ObjectId,
			_originalObjectType?.ToString()
		};
	}

	public void SetBinding(object target, string dependencyProperty, BindingBase binding)
	{
		TryRegisterInheritedProperties(null, force: true);
		if (target is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			dependencyObjectStoreProvider.Store.SetBinding(dependencyProperty, binding);
			return;
		}
		throw new NotSupportedException($"Target {target?.GetType()} must be a DependencyObject");
	}

	public void SetBinding(DependencyProperty dependencyProperty, BindingBase binding)
	{
		TryRegisterInheritedProperties(null, force: true);
		if (dependencyProperty == null)
		{
			throw new ArgumentNullException("dependencyProperty");
		}
		if (binding == null)
		{
			throw new ArgumentNullException("binding");
		}
		if (binding is Binding binding2)
		{
			_properties.SetBinding(dependencyProperty, binding2, _originalObjectRef);
			return;
		}
		if (binding is ResourceBinding resourceBinding)
		{
			_resourceBindings = _resourceBindings ?? new ResourceBindingCollection();
			_resourceBindings!.Add(dependencyProperty, resourceBinding);
			return;
		}
		throw new NotSupportedException("Only Windows.UI.Xaml.Data.Binding is supported for bindings.");
	}

	internal void SetResourceBinding(DependencyProperty dependencyProperty, SpecializedResourceDictionary.ResourceKey resourceKey, ResourceUpdateReason updateReason, object context, DependencyPropertyValuePrecedences? precedence, BindingPath? setterBindingPath)
	{
		if (!precedence.HasValue)
		{
			Stack<DependencyPropertyValuePrecedences?>? overriddenPrecedences = _overriddenPrecedences;
			if (overriddenPrecedences != null && overriddenPrecedences!.Count > 0)
			{
				precedence = _overriddenPrecedences!.Peek();
			}
		}
		ResourceBinding binding = new ResourceBinding(resourceKey, updateReason, context, precedence ?? DependencyPropertyValuePrecedences.Local, setterBindingPath);
		SetBinding(dependencyProperty, binding);
	}

	public void SetBinding(string dependencyProperty, BindingBase binding)
	{
		TryRegisterInheritedProperties(null, force: true);
		if (dependencyProperty == null)
		{
			throw new ArgumentNullException("dependencyProperty");
		}
		if (binding == null)
		{
			throw new ArgumentNullException("binding");
		}
		if (binding is Binding binding2)
		{
			DependencyProperty dependencyProperty2 = DependencyProperty.GetProperty(_originalObjectType, dependencyProperty) ?? FindStandardProperty(_originalObjectType, dependencyProperty, binding2.CompiledSource != null);
			if (dependencyProperty2 != null)
			{
				_properties.SetBinding(dependencyProperty2, binding2, _originalObjectRef);
			}
			return;
		}
		throw new NotSupportedException("Only Windows.UI.Xaml.Data.Binding is supported for bindings.");
	}

	private DependencyProperty? FindStandardProperty(Type originalObjectType, string dependencyProperty, bool allowPrivateMembers)
	{
		Type propertyType = BindingPropertyHelper.GetPropertyType(originalObjectType, dependencyProperty, allowPrivateMembers);
		if (propertyType != null)
		{
			ValueSetterHandler valueSetter = BindingPropertyHelper.GetValueSetter(originalObjectType, dependencyProperty, convert: true);
			DependencyProperty dependencyProperty2 = DependencyProperty.GetProperty(originalObjectType, dependencyProperty);
			if (dependencyProperty2 == null)
			{
				dependencyProperty2 = DependencyProperty.Register(dependencyProperty, propertyType, originalObjectType, new FrameworkPropertyMetadata(null));
			}
			return dependencyProperty2;
		}
		this.Log().Error($"The property {dependencyProperty} does not exist on {originalObjectType}");
		return null;
	}

	public void SetBindingValue(object value, [CallerMemberName] string? propertyName = null)
	{
		DependencyProperty dependencyProperty = DependencyProperty.GetProperty(_originalObjectType, propertyName);
		if (dependencyProperty == null && propertyName != null)
		{
			dependencyProperty = FindStandardProperty(_originalObjectType, propertyName, allowPrivateMembers: false);
		}
		if (dependencyProperty != null)
		{
			SetBindingValue(value, dependencyProperty);
			return;
		}
		throw new InvalidOperationException($"Binding to a non-DependencyProperty is not supported ({_originalObjectType}.{propertyName})");
	}

	public void SetBindingValue(object value, DependencyProperty property)
	{
		_properties.SetSourceValue(property, value);
	}

	internal void SetBindingValue(DependencyPropertyDetails propertyDetails, object value)
	{
		if (_unregisteringInheritedProperties || _parentUnregisteringInheritedProperties)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().DebugFormat("SetSourceValue() not called because inherited property is being unset.");
			}
		}
		else
		{
			_properties.SetSourceValue(propertyDetails, value);
		}
	}

	internal void RegisterDefaultValueProvider(DefaultValueProvider provider)
	{
		_properties.RegisterDefaultValueProvider(provider);
	}

	private static IDisposable? SubscribeToDependencyPropertyChanged(ManagedWeakReference dataContextReference, string propertyName, Action newValueAction)
	{
		Action newValueAction2 = newValueAction;
		if (dataContextReference.Target is DependencyObject dependencyObject)
		{
			DependencyProperty property = DependencyProperty.GetProperty(dependencyObject.GetType(), propertyName);
			if (property != null)
			{
				PropertyChangedCallback callback = delegate
				{
					newValueAction2();
				};
				return dependencyObject.RegisterDisposablePropertyChangedCallback(property, callback);
			}
			if (typeof(DependencyProperty).Log().IsEnabled(LogLevel.Debug))
			{
				typeof(DependencyProperty).Log().DebugFormat("Unable to find the dependency property [{0}] on type [{1}]", propertyName, dependencyObject.GetType());
			}
		}
		return null;
	}

	private void OnDependencyPropertyChanged(DependencyPropertyDetails propertyDetails, DependencyPropertyChangedEventArgs args)
	{
		SetBindingValue(propertyDetails, args.NewValue);
		GetPropertyInheritanceConfiguration(propertyDetails, args, out var hasValueInherits, out var hasValueDoesNotInherit);
		if (hasValueDoesNotInherit)
		{
			return;
		}
		IDependencyObjectStoreProvider dependencyObjectStoreProvider = args.NewValue as IDependencyObjectStoreProvider;
		if (hasValueInherits)
		{
			if (dependencyObjectStoreProvider != null)
			{
				SetChildrenBindableValue(propertyDetails, (dependencyObjectStoreProvider.Store.Parent != ActualInstance) ? args.NewValue : null);
			}
			else
			{
				SetChildrenBindableValue(propertyDetails, args.NewValue);
			}
		}
		else if (dependencyObjectStoreProvider != null && !(dependencyObjectStoreProvider is UIElement))
		{
			SetChildrenBindableValue(propertyDetails, dependencyObjectStoreProvider);
		}
	}

	private void SetChildrenBindableValue(DependencyPropertyDetails propertyDetails, object? value)
	{
		_childrenBindable[GetOrCreateChildBindablePropertyIndex(propertyDetails.Property)] = value;
	}

	private void GetPropertyInheritanceConfiguration(DependencyPropertyDetails propertyDetails, DependencyPropertyChangedEventArgs args, out bool hasValueInherits, out bool hasValueDoesNotInherit)
	{
		if (propertyDetails.Property == _templatedParentProperty || propertyDetails.Property == _dataContextProperty)
		{
			hasValueInherits = false;
			hasValueDoesNotInherit = true;
		}
		else if (propertyDetails.Metadata is FrameworkPropertyMetadata frameworkPropertyMetadata)
		{
			hasValueInherits = frameworkPropertyMetadata.Options.HasValueInheritsDataContext();
			hasValueDoesNotInherit = frameworkPropertyMetadata.Options.HasValueDoesNotInheritDataContext();
		}
		else
		{
			hasValueInherits = false;
			hasValueDoesNotInherit = false;
		}
	}

	private int GetOrCreateChildBindablePropertyIndex(DependencyProperty property)
	{
		int result;
		if (!_childrenBindableMap.TryGetValue(property, out var value))
		{
			_childrenBindableMap[property] = (result = _childrenBindableMap.Count);
			_childrenBindable.Add(null);
		}
		else
		{
			result = (int)value;
		}
		return result;
	}

	public BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return _properties.GetBindingExpression(dependencyProperty);
	}

	public Binding? GetBinding(DependencyProperty dependencyProperty)
	{
		return GetBindingExpression(dependencyProperty)?.ParentBinding;
	}

	static DependencyObjectStore()
	{
		_trace = Tracing.Get(TraceProvider.Id);
		_propertyChangedToken = 0L;
		_validatePropertyOwner = Debugger.IsAttached;
		_propagationBypass = new List<DependencyPropertyPath>();
		_propagationBypassed = new Dictionary<DependencyPropertyPath, object>(DependencyPropertyPath.Comparer.Default);
		InitializeStaticBinder();
	}

	public DependencyObjectStore(object originalObject, DependencyProperty dataContextProperty, DependencyProperty templatedParentProperty)
	{
		ObjectId = Interlocked.Increment(ref _objectIdCounter);
		_originalObjectRef = WeakReferencePool.RentWeakReference(this, originalObject);
		_originalObjectType = ((originalObject is AttachedDependencyObject attachedDependencyObject) ? attachedDependencyObject.Owner.GetType() : originalObject.GetType());
		_properties = new DependencyPropertyDetailsCollection(_originalObjectType, _originalObjectRef, dataContextProperty, templatedParentProperty);
		_dataContextProperty = dataContextProperty;
		_templatedParentProperty = templatedParentProperty;
		if (_trace.IsEnabled)
		{
			_trace.WriteEvent(4, new object[2] { ObjectId, _originalObjectType.Name });
		}
	}

	~DependencyObjectStore()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	private void Dispose(bool disposing)
	{
		if (disposing)
		{
			GC.SuppressFinalize(this);
		}
		BinderDispose();
	}

	public object? GetValue(DependencyProperty property)
	{
		return GetValue(property, null, null, isPrecedenceSpecific: false);
	}

	public object? ReadLocalValue(DependencyProperty property)
	{
		return GetValue(property, DependencyPropertyValuePrecedences.Local, isPrecedenceSpecific: true);
	}

	public object? GetAnimationBaseValue(DependencyProperty property)
	{
		return GetValue(property, DependencyPropertyValuePrecedences.Local);
	}

	internal object? GetValue(DependencyProperty property, DependencyPropertyValuePrecedences? precedence = null, bool isPrecedenceSpecific = false)
	{
		return GetValue(property, null, precedence, isPrecedenceSpecific);
	}

	internal object? GetValue(DependencyProperty property, DependencyPropertyDetails? propertyDetails, DependencyPropertyValuePrecedences? precedence = null, bool isPrecedenceSpecific = false)
	{
		WritePropertyEventTrace(1, property, precedence);
		ValidatePropertyOwner(property);
		if (propertyDetails == null)
		{
			propertyDetails = _properties.GetPropertyDetails(property);
		}
		return GetValue(propertyDetails, precedence, isPrecedenceSpecific);
	}

	private object? GetValue(DependencyPropertyDetails propertyDetails, DependencyPropertyValuePrecedences? precedence = null, bool isPrecedenceSpecific = false)
	{
		if (propertyDetails == _properties.DataContextPropertyDetails || propertyDetails == _properties.TemplatedParentPropertyDetails)
		{
			TryRegisterInheritedProperties(null, force: true);
		}
		if (!precedence.HasValue)
		{
			return propertyDetails.GetValue();
		}
		if (isPrecedenceSpecific)
		{
			return propertyDetails.GetValue(precedence.Value);
		}
		DependencyPropertyValuePrecedences currentHighestValuePrecedence = GetCurrentHighestValuePrecedence(propertyDetails);
		return propertyDetails.GetValue((DependencyPropertyValuePrecedences)Math.Max((int)currentHighestValuePrecedence, (int)precedence.Value));
	}

	internal DependencyPropertyValuePrecedences GetCurrentHighestValuePrecedence(DependencyPropertyDetails propertyDetails)
	{
		return propertyDetails.CurrentHighestValuePrecedence;
	}

	internal DependencyPropertyValuePrecedences GetCurrentHighestValuePrecedence(DependencyProperty property)
	{
		return _properties.GetPropertyDetails(property).CurrentHighestValuePrecedence;
	}

	internal IDisposable? OverrideLocalPrecedence(DependencyPropertyValuePrecedences? precedence)
	{
		if (_overriddenPrecedences == null)
		{
			_overriddenPrecedences = new Stack<DependencyPropertyValuePrecedences?>(2);
		}
		if (_overriddenPrecedences!.Count > 0 && _overriddenPrecedences!.Peek() == precedence)
		{
			return null;
		}
		_overriddenPrecedences!.Push(precedence);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug(string.Format("OverrideLocalPrecedence({0}) - stack is {1}", precedence, string.Join(", ", _overriddenPrecedences)));
		}
		return Disposable.Create(delegate
		{
			DependencyPropertyValuePrecedences? dependencyPropertyValuePrecedences = _overriddenPrecedences!.Pop();
			if (dependencyPropertyValuePrecedences != precedence)
			{
				throw new InvalidOperationException($"Error while unstacking precedence. Should be {precedence}, got {dependencyPropertyValuePrecedences}.");
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				string arg = ((_overriddenPrecedences!.Count == 0) ? "<none>" : _overriddenPrecedences!.Peek().ToString());
				this.Log().Debug($"OverrideLocalPrecedence({precedence}).Dispose() ==> new overriden precedence is {arg})");
			}
		});
	}

	internal static IDisposable? BypassPropagation(DependencyObject instance, DependencyProperty property)
	{
		if (instance == null)
		{
			return null;
		}
		DependencyPropertyPath path = new DependencyPropertyPath(instance, property);
		if (_propagationBypass.Contains<DependencyPropertyPath>(path, DependencyPropertyPath.Comparer.Default))
		{
			return null;
		}
		_propagationBypass.Add(path);
		return Disposable.Create(delegate
		{
			_propagationBypass.Remove(path);
		});
	}

	public void SetValue(DependencyProperty property, object value)
	{
		SetValue(property, value, DependencyPropertyValuePrecedences.Local);
	}

	public void ClearValue(DependencyProperty property)
	{
		SetValue(property, DependencyProperty.UnsetValue, DependencyPropertyValuePrecedences.Local);
	}

	internal void ClearValue(DependencyProperty property, DependencyPropertyValuePrecedences precedence)
	{
		SetValue(property, DependencyProperty.UnsetValue, precedence);
	}

	internal void SetValue(DependencyProperty property, object? value, DependencyPropertyValuePrecedences precedence, DependencyPropertyDetails? propertyDetails = null, bool isPersistentResourceBinding = false)
	{
		if (_trace.IsEnabled)
		{
			SetValueWithTrace(property, value, precedence, propertyDetails, isPersistentResourceBinding);
		}
		else
		{
			InnerSetValue(property, value, precedence, propertyDetails, isPersistentResourceBinding);
		}
		void SetValueWithTrace(DependencyProperty property, object? value, DependencyPropertyValuePrecedences precedence, DependencyPropertyDetails? propertyDetails, bool isPersistentResourceBinding)
		{
			using (WritePropertyEventTrace(2, 3, property, precedence))
			{
				InnerSetValue(property, value, precedence, propertyDetails, isPersistentResourceBinding);
			}
		}
	}

	private void InnerSetValue(DependencyProperty property, object? value, DependencyPropertyValuePrecedences precedence, DependencyPropertyDetails? propertyDetails, bool isPersistentResourceBinding)
	{
		if (precedence == DependencyPropertyValuePrecedences.Coercion)
		{
			throw new ArgumentException("SetValue must not be called with precedence DependencyPropertyValuePrecedences.Coercion, as it expects a non-coerced value to function properly.");
		}
		DependencyObject actualInstance = ActualInstance;
		if (actualInstance != null)
		{
			IDisposable disposable = ApplyPrecedenceOverride(ref precedence);
			if (value is UnsetValue && precedence == DependencyPropertyValuePrecedences.DefaultValue)
			{
				throw new InvalidOperationException("The default value must be a valid value");
			}
			ValidatePropertyOwner(property);
			if (propertyDetails == null)
			{
				propertyDetails = _properties.GetPropertyDetails(property);
			}
			object value2 = GetValue(propertyDetails);
			DependencyPropertyValuePrecedences currentHighestValuePrecedence = GetCurrentHighestValuePrecedence(propertyDetails);
			ApplyCoercion(actualInstance, propertyDetails, value2, value);
			SetValueInternal(value, precedence, propertyDetails);
			if (!isPersistentResourceBinding && !_isSettingPersistentResourceBinding)
			{
				_resourceBindings?.ClearBinding(property, precedence);
			}
			object value3 = GetValue(propertyDetails);
			DependencyPropertyValuePrecedences currentHighestValuePrecedence2 = GetCurrentHighestValuePrecedence(propertyDetails);
			if (property == _dataContextProperty)
			{
				OnDataContextChanged(value, value3, precedence);
			}
			TryUpdateInheritedAttachedProperty(property, propertyDetails);
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				string text = (_originalObjectRef.Target as IFrameworkElement)?.Name ?? _originalObjectRef.Target?.GetType().Name;
				int? num = _originalObjectRef.Target?.GetHashCode();
				this.Log().Debug($"SetValue on [{text}/{num:X8}] for [{property.Name}] to [{value3}] (req:{value} reqp:{precedence} p:{value2} pp:{currentHighestValuePrecedence} np:{currentHighestValuePrecedence2})");
			}
			RaiseCallbacks(actualInstance, propertyDetails, value2, currentHighestValuePrecedence, value3, currentHighestValuePrecedence2);
			disposable?.Dispose();
		}
		else
		{
			Parent = null;
		}
	}

	private void TryUpdateInheritedAttachedProperty(DependencyProperty property, DependencyPropertyDetails propertyDetails)
	{
		if (property.IsAttached && propertyDetails.Metadata is FrameworkPropertyMetadata frameworkPropertyMetadata && frameworkPropertyMetadata.Options.HasInherits())
		{
			_inheritedForwardedProperties[property] = _originalObjectRef;
		}
	}

	private void ApplyCoercion(DependencyObject actualInstanceAlias, DependencyPropertyDetails propertyDetails, object? previousValue, object? baseValue)
	{
		if (baseValue is UnsetValue)
		{
			SetValueInternal(DependencyProperty.UnsetValue, DependencyPropertyValuePrecedences.Coercion, propertyDetails);
			return;
		}
		CoerceValueCallback coerceValueCallback = propertyDetails.Metadata.CoerceValueCallback;
		if (coerceValueCallback != null && (propertyDetails.Metadata.CoerceWhenUnchanged || !object.Equals(previousValue, baseValue)))
		{
			object obj = coerceValueCallback(actualInstanceAlias, baseValue);
			if (obj is UnsetValue)
			{
				SetValueInternal(previousValue, DependencyPropertyValuePrecedences.Coercion, propertyDetails);
			}
			else if (!object.Equals(obj, baseValue))
			{
				SetValueInternal(obj, DependencyPropertyValuePrecedences.Coercion, propertyDetails);
			}
			else
			{
				SetValueInternal(DependencyProperty.UnsetValue, DependencyPropertyValuePrecedences.Coercion, propertyDetails);
			}
		}
	}

	internal void CoerceValue(DependencyProperty property)
	{
		var (value, precedence) = GetValueUnderPrecedence(property, DependencyPropertyValuePrecedences.Coercion);
		SetValue(property, value, precedence);
	}

	private void WritePropertyEventTrace(int eventId, DependencyProperty property, DependencyPropertyValuePrecedences? precedence)
	{
		if (_trace.IsEnabled)
		{
			_trace.WriteEvent(eventId, new object[4]
			{
				ObjectId,
				property.OwnerType.Name,
				property.Name,
				precedence?.ToString() ?? "Local"
			});
		}
	}

	private IDisposable? WritePropertyEventTrace(int startEventId, int stopEventId, DependencyProperty property, DependencyPropertyValuePrecedences precedence)
	{
		if (_trace.IsEnabled)
		{
			return _trace.WriteEventActivity(startEventId, stopEventId, new object[4]
			{
				ObjectId,
				property.OwnerType.Name,
				property.Name,
				precedence.ToString()
			});
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private IDisposable? ApplyPrecedenceOverride(ref DependencyPropertyValuePrecedences precedence)
	{
		Stack<DependencyPropertyValuePrecedences?>? overriddenPrecedences = _overriddenPrecedences;
		DependencyPropertyValuePrecedences? dependencyPropertyValuePrecedences = ((overriddenPrecedences != null && overriddenPrecedences!.Count > 0) ? _overriddenPrecedences!.Peek() : null);
		if (dependencyPropertyValuePrecedences.HasValue)
		{
			DependencyPropertyValuePrecedences dependencyPropertyValuePrecedences2 = (precedence = dependencyPropertyValuePrecedences.GetValueOrDefault());
			return OverrideLocalPrecedence(null);
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ValidatePropertyOwner(DependencyProperty property)
	{
		if (_validatePropertyOwner)
		{
			bool flag = _originalObjectType.Is(typeof(FrameworkElement));
			bool flag2 = _originalObjectRef.Target is IFrameworkElement && !flag;
			if (!_originalObjectType.Is(property.OwnerType) && !property.IsAttached && !flag2)
			{
				throw new InvalidOperationException($"The Dependency Property [{property.Name}] is owned by [{property.OwnerType}] and cannot be used on [{_originalObjectType}]");
			}
		}
	}

	public long RegisterPropertyChangedCallback(DependencyProperty property, DependencyPropertyChangedCallback callback)
	{
		DependencyPropertyChangedCallback callback2 = callback;
		DependencyProperty property2 = property;
		_propertyChangedToken = Interlocked.Increment(ref _propertyChangedToken);
		IDisposable value = RegisterPropertyChangedCallback(property2, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			callback2(s, property2);
		});
		_propertyChangedTokens.Add(_propertyChangedToken, value);
		return _propertyChangedToken;
	}

	public void UnregisterPropertyChangedCallback(DependencyProperty property, long token)
	{
		if (_propertyChangedTokens.TryGetValue(token, out var value))
		{
			value.Dispose();
			_propertyChangedTokens.Remove(token);
		}
	}

	internal IDisposable RegisterPropertyChangedCallback(DependencyProperty property, PropertyChangedCallback callback, DependencyPropertyDetails? propertyDetails = null)
	{
		PropertyChangedCallback callback2 = callback;
		(PropertyChangedCallback callback, IDisposable release) weakDelegate = CreateWeakDelegate(callback2);
		if (propertyDetails == null)
		{
			propertyDetails = _properties.GetPropertyDetails(property);
		}
		IDisposable cookie = propertyDetails!.CallbackManager.RegisterCallback(weakDelegate.callback);
		ManagedWeakReference instanceRef = ThisWeakReference;
		return new DispatcherConditionalDisposable(callback2.Target, instanceRef.CloneWeakReference(), delegate
		{
			if (instanceRef.Target is DependencyObjectStore)
			{
				cookie.Dispose();
				weakDelegate.release.Dispose();
				callback2 = null;
			}
		});
	}

	internal IDisposable RegisterPropertyChangedCallback(ExplicitPropertyChangedCallback handler)
	{
		ExplicitPropertyChangedCallback handler2 = handler;
		(ExplicitPropertyChangedCallback callback, IDisposable release) weakDelegate = CreateWeakDelegate(handler2);
		_genericCallbacks = _genericCallbacks.Add(weakDelegate.callback);
		ManagedWeakReference instanceRef = ThisWeakReference;
		return new DispatcherConditionalDisposable(handler2.Target, instanceRef.CloneWeakReference(), delegate
		{
			if (instanceRef.Target is DependencyObjectStore dependencyObjectStore)
			{
				dependencyObjectStore._genericCallbacks = dependencyObjectStore._genericCallbacks.Remove(weakDelegate.callback);
			}
			weakDelegate.release.Dispose();
			handler2 = null;
		});
	}

	internal void RegisterPropertyChangedCallbackStrong(ExplicitPropertyChangedCallback handler)
	{
		_genericCallbacks = _genericCallbacks.Add(handler);
	}

	private InheritedPropertyChangedCallbackDisposable RegisterInheritedPropertyChangedCallback(DependencyObjectStore childStore)
	{
		_childrenStores = _childrenStores.Add(childStore);
		PropagateInheritedProperties(childStore);
		ManagedWeakReference thisWeakReference = ThisWeakReference;
		return new InheritedPropertyChangedCallbackDisposable(thisWeakReference, childStore);
	}

	private static void CleanupInheritedPropertyChangedCallback(ManagedWeakReference objectStoreWeak, DependencyObjectStore childStore)
	{
		if (objectStoreWeak.Target is DependencyObjectStore dependencyObjectStore)
		{
			dependencyObjectStore._childrenStores = dependencyObjectStore._childrenStores.Remove(childStore);
		}
	}

	internal void RegisterSelfParentChangedCallback(ParentChangedCallback callback)
	{
		_parentChangedCallbacks = _parentChangedCallbacks.Add(callback);
	}

	internal IDisposable RegisterParentChangedCallback(object key, ParentChangedCallback callback)
	{
		object key2 = key;
		ParentChangedCallback callback2 = callback;
		ManagedWeakReference wr = WeakReferencePool.RentWeakReference(this, callback2);
		ParentChangedCallback weakDelegate = delegate(object s, object? _, DependencyObjectParentChangedEventArgs e)
		{
			(wr.Target as ParentChangedCallback)?.Invoke(s, key2, e);
		};
		_parentChangedCallbacks = _parentChangedCallbacks.Add(weakDelegate);
		ManagedWeakReference instanceRef = ThisWeakReference;
		return new DispatcherConditionalDisposable(callback2.Target, instanceRef.CloneWeakReference(), Cleanup);
		void Cleanup()
		{
			DependencyObjectStore dependencyObjectStore = instanceRef.Target as DependencyObjectStore;
			if (dependencyObjectStore != null)
			{
				dependencyObjectStore._parentChangedCallbacks = dependencyObjectStore._parentChangedCallbacks.Remove(weakDelegate);
			}
			WeakReferencePool.ReturnWeakReference(dependencyObjectStore, wr);
			callback2 = null;
		}
	}

	internal (object? value, DependencyPropertyValuePrecedences precedence) GetValueUnderPrecedence(DependencyProperty property, DependencyPropertyValuePrecedences precedence)
	{
		DependencyPropertyDetails propertyDetails = _properties.GetPropertyDetails(property);
		return propertyDetails.GetValueUnderPrecedence(precedence);
	}

	internal DependencyPropertyDetails GetPropertyDetails(DependencyProperty property)
	{
		return _properties.GetPropertyDetails(property);
	}

	private void OnParentPropertyChangedCallback(ManagedWeakReference sourceInstance, DependencyProperty parentProperty, DependencyPropertyChangedEventArgs args)
	{
		var (dependencyProperty, propertyDetails) = GetLocalPropertyDetails(parentProperty);
		if (dependencyProperty != null)
		{
			if (dependencyProperty != _dataContextProperty && dependencyProperty != _templatedParentProperty && !_updatedProperties.Contains(dependencyProperty))
			{
				_updatedProperties.Add(dependencyProperty);
			}
			SetValue(dependencyProperty, args.NewValue, DependencyPropertyValuePrecedences.Inheritance, propertyDetails);
			return;
		}
		_inheritedForwardedProperties[parentProperty] = sourceInstance;
		for (int i = 0; i < _childrenStores.Count; i++)
		{
			DependencyObjectStore dependencyObjectStore = _childrenStores[i];
			dependencyObjectStore.OnParentPropertyChangedCallback(sourceInstance, parentProperty, args);
		}
	}

	private void TryRegisterInheritedProperties(IDependencyObjectStoreProvider? parentProvider = null, bool force = false)
	{
		if (!_registeringInheritedProperties && !_unregisteringInheritedProperties && _inheritedProperties.Disposable == null && (IsAutoPropertyInheritanceEnabled || force || _properties.HasBindings || _childrenStores.Count != 0))
		{
			if (parentProvider == null && Parent is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
			{
				parentProvider = dependencyObjectStoreProvider;
			}
			if (parentProvider != null)
			{
				_registeringInheritedProperties = true;
				_inheritedProperties.Disposable = RegisterInheritedProperties(parentProvider);
				_registeringInheritedProperties = false;
			}
		}
	}

	private InheritedPropertiesDisposable RegisterInheritedProperties(IDependencyObjectStoreProvider parentProvider)
	{
		_parentTemplatedParentProperty = parentProvider.Store.TemplatedParentProperty;
		_parentDataContextProperty = parentProvider.Store.DataContextProperty;
		InheritedPropertyChangedCallbackDisposable inheritedPropertyChangedCallbackDisposable = parentProvider.Store.RegisterInheritedPropertyChangedCallback(this);
		PropagateInheritedProperties();
		return new InheritedPropertiesDisposable(this, inheritedPropertyChangedCallbackDisposable);
	}

	private void CleanupInheritedProperties()
	{
		_unregisteringInheritedProperties = true;
		_inheritedForwardedProperties.Clear();
		if (ActualInstance != null)
		{
			HashSet<DependencyProperty>.Enumerator enumerator = _updatedProperties.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DependencyProperty current = enumerator.Current;
				SetValue(current, DependencyProperty.UnsetValue, DependencyPropertyValuePrecedences.Inheritance);
			}
			SetValue(_dataContextProperty, DependencyProperty.UnsetValue, DependencyPropertyValuePrecedences.Inheritance);
			SetValue(_templatedParentProperty, DependencyProperty.UnsetValue, DependencyPropertyValuePrecedences.Inheritance);
		}
		_unregisteringInheritedProperties = false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private (DependencyProperty? localProperty, DependencyPropertyDetails? propertyDetails) GetLocalPropertyDetails(DependencyProperty property)
	{
		if (_parentDataContextProperty.UniqueId == property.UniqueId)
		{
			return (_dataContextProperty, _properties.DataContextPropertyDetails);
		}
		if (_parentTemplatedParentProperty == property)
		{
			return (_templatedParentProperty, _properties.TemplatedParentPropertyDetails);
		}
		DependencyProperty property2 = DependencyProperty.GetProperty(_originalObjectType, property.Name);
		if (property2 != null)
		{
			DependencyPropertyDetails propertyDetails = _properties.GetPropertyDetails(property2);
			if (HasInherits(propertyDetails))
			{
				return (property2, propertyDetails);
			}
		}
		else if (property.IsAttached)
		{
			DependencyPropertyDetails dependencyPropertyDetails = _properties.FindPropertyDetails(property);
			if (dependencyPropertyDetails != null && HasInherits(dependencyPropertyDetails))
			{
				return (property, dependencyPropertyDetails);
			}
		}
		return (null, null);
	}

	internal void UpdateResourceBindings(ResourceUpdateReason updateReason, ResourceDictionary? containingDictionary = null)
	{
		if (updateReason == ResourceUpdateReason.None)
		{
			throw new ArgumentException();
		}
		if (_resourceBindings == null || !_resourceBindings!.HasBindings)
		{
			UpdateChildResourceBindings(updateReason);
			return;
		}
		ResourceDictionary[] dictionariesInScope = GetResourceDictionaries(includeAppResources: false, containingDictionary).ToArray();
		List<(DependencyProperty, ResourceBinding)> list = _resourceBindings!.GetAllBindings().ToList();
		foreach (var (property, binding) in list)
		{
			InnerUpdateResourceBindings(updateReason, dictionariesInScope, property, binding);
		}
		UpdateChildResourceBindings(updateReason);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void InnerUpdateResourceBindings(ResourceUpdateReason updateReason, ResourceDictionary[] dictionariesInScope, DependencyProperty property, ResourceBinding binding)
	{
		try
		{
			InnerUpdateResourceBindingsUnsafe(updateReason, dictionariesInScope, property, binding);
		}
		catch (Exception ex)
		{
			if (this.Log().IsEnabled(LogLevel.Warning))
			{
				this.Log().Warn("Failed to update binding, target may have been disposed", ex);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void InnerUpdateResourceBindingsUnsafe(ResourceUpdateReason updateReason, ResourceDictionary[] dictionariesInScope, DependencyProperty property, ResourceBinding binding)
	{
		bool flag = false;
		foreach (ResourceDictionary resourceDictionary in dictionariesInScope)
		{
			SpecializedResourceDictionary.ResourceKey resourceKey = binding.ResourceKey;
			if (resourceDictionary.TryGetValue(in resourceKey, out var value, shouldCheckSystem: false))
			{
				flag = true;
				SetResourceBindingValue(property, binding, value);
				break;
			}
		}
		if (!flag && (binding.UpdateReason & updateReason) != 0)
		{
			SpecializedResourceDictionary.ResourceKey resourceKey = binding.ResourceKey;
			if (ResourceResolver.TryTopLevelRetrieval(in resourceKey, binding.ParseContext, out var value2))
			{
				SetResourceBindingValue(property, binding, value2);
			}
		}
	}

	private void SetResourceBindingValue(DependencyProperty property, ResourceBinding binding, object? value)
	{
		DependencyProperty property2 = property;
		object value2 = BindingPropertyHelper.Convert(() => property2.Type, value);
		if (binding.SetterBindingPath != null)
		{
			_isSettingPersistentResourceBinding = binding.IsPersistent;
			binding.SetterBindingPath!.Value = value2;
			_isSettingPersistentResourceBinding = false;
		}
		else
		{
			SetValue(property2, value2, binding.Precedence, null, binding.IsPersistent);
		}
	}

	private void UpdateChildResourceBindings(ResourceUpdateReason updateReason)
	{
		if (!_isUpdatingChildResourceBindings && (updateReason & ResourceUpdateReason.PropagatesThroughTree) != 0)
		{
			try
			{
				InnerUpdateChildResourceBindings(updateReason);
			}
			finally
			{
				_isUpdatingChildResourceBindings = false;
			}
			if (ActualInstance is IThemeChangeAware themeChangeAware)
			{
				themeChangeAware.OnThemeChanged();
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void InnerUpdateChildResourceBindings(ResourceUpdateReason updateReason)
	{
		_isUpdatingChildResourceBindings = true;
		foreach (DependencyObject childrenDependencyObject in GetChildrenDependencyObjects())
		{
			if (!(childrenDependencyObject is IFrameworkElement) && childrenDependencyObject is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
			{
				dependencyObjectStoreProvider.Store.UpdateResourceBindings(updateReason);
			}
		}
	}

	private IEnumerable<DependencyObject> GetChildrenDependencyObjects()
	{
		DependencyPropertyDetails?[] allDetails = _properties.GetAllDetails();
		foreach (DependencyPropertyDetails dependencyPropertyDetails in allDetails)
		{
			if (dependencyPropertyDetails == null || dependencyPropertyDetails == _properties.DataContextPropertyDetails || dependencyPropertyDetails == _properties.TemplatedParentPropertyDetails)
			{
				continue;
			}
			object propertyValue = GetValue(dependencyPropertyDetails);
			if (propertyValue is IEnumerable<DependencyObject> enumerable && (propertyValue is ICollection || propertyValue is DependencyObjectCollectionBase))
			{
				foreach (DependencyObject item in enumerable)
				{
					yield return item;
				}
			}
			if (propertyValue is IAdditionalChildrenProvider additionalChildrenProvider)
			{
				foreach (DependencyObject additionalChildObject in additionalChildrenProvider.GetAdditionalChildObjects())
				{
					yield return additionalChildObject;
				}
			}
			if (propertyValue is DependencyObject dependencyObject)
			{
				yield return dependencyObject;
			}
		}
	}

	private IEnumerable<ResourceDictionary> GetResourceDictionaries(bool includeAppResources, ResourceDictionary? containingDictionary = null)
	{
		if (containingDictionary != null)
		{
			yield return containingDictionary;
		}
		DependencyObject dependencyObject = ActualInstance;
		FrameworkElement candidateFE = dependencyObject as FrameworkElement;
		while (dependencyObject != null)
		{
			DependencyObject parent = dependencyObject.GetParent() as DependencyObject;
			if (candidateFE != null)
			{
				if (candidateFE.Resources != null)
				{
					yield return candidateFE.Resources;
				}
				if (parent is FrameworkElement frameworkElement)
				{
					FrameworkElement frameworkElement2;
					candidateFE = (frameworkElement2 = frameworkElement);
					dependencyObject = frameworkElement2;
				}
				else
				{
					dependencyObject = parent;
				}
			}
			else
			{
				candidateFE = parent as FrameworkElement;
				dependencyObject = parent;
			}
		}
		if (includeAppResources && Application.Current != null)
		{
			yield return Application.Current.Resources;
		}
	}

	internal Style? GetImplicitStyle(in SpecializedResourceDictionary.ResourceKey styleKey)
	{
		foreach (ResourceDictionary resourceDictionary in GetResourceDictionaries(includeAppResources: true))
		{
			if (resourceDictionary.TryGetValue(in styleKey, out var value, shouldCheckSystem: false))
			{
				return value as Style;
			}
		}
		return null;
	}

	internal void PropagateInheritedProperties(DependencyObjectStore? childStore = null)
	{
		DependencyProperty[] props = DependencyProperty.GetFrameworkPropertiesForType(_originalObjectType, FrameworkPropertyMetadataOptions.Inherits);
		ManagedWeakReference instanceRef = ((_originalObjectRef != null) ? _originalObjectRef : ThisWeakReference);
		if (childStore != null)
		{
			Propagate(childStore);
		}
		else
		{
			for (int i = 0; i < _childrenStores.Count; i++)
			{
				DependencyObjectStore store2 = _childrenStores[i];
				Propagate(store2);
			}
		}
		PropagateInheritedNonLocalProperties(childStore);
		void Propagate(DependencyObjectStore store)
		{
			foreach (DependencyProperty dependencyProperty in props)
			{
				store.OnParentPropertyChangedCallback(instanceRef, dependencyProperty, new DependencyPropertyChangedEventArgs(dependencyProperty, null, DependencyPropertyValuePrecedences.DefaultValue, GetValue(dependencyProperty), DependencyPropertyValuePrecedences.Inheritance));
			}
		}
	}

	private void PropagateInheritedNonLocalProperties(DependencyObjectStore? childStore)
	{
		AncestorsDictionary map = new AncestorsDictionary();
		DependencyObject actualInstance = ActualInstance;
		Dictionary<DependencyProperty, ManagedWeakReference>.Enumerator enumerator = _inheritedForwardedProperties.GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<DependencyProperty, ManagedWeakReference> sourceInstanceProperties = enumerator.Current;
			if (!IsAncestor(actualInstance, map, sourceInstanceProperties.Value.Target) && (!sourceInstanceProperties.Key.IsAttached || actualInstance != sourceInstanceProperties.Value.Target))
			{
				continue;
			}
			if (childStore != null)
			{
				Propagate(childStore);
				continue;
			}
			for (int i = 0; i < _childrenStores.Count; i++)
			{
				Propagate(_childrenStores[i]);
			}
			void Propagate(DependencyObjectStore store)
			{
				store.OnParentPropertyChangedCallback(sourceInstanceProperties.Value, sourceInstanceProperties.Key, new DependencyPropertyChangedEventArgs(sourceInstanceProperties.Key, null, DependencyPropertyValuePrecedences.DefaultValue, (sourceInstanceProperties.Value.Target as DependencyObject)?.GetValue(sourceInstanceProperties.Key), DependencyPropertyValuePrecedences.Inheritance));
			}
		}
	}

	private static bool IsAncestor(DependencyObject? instance, AncestorsDictionary map, object ancestor)
	{
		bool isAncestor = false;
		if (ancestor != null && !map.TryGetValue(ancestor, out isAncestor))
		{
			while (instance != null)
			{
				instance = instance.GetParent() as DependencyObject;
				if (instance == ancestor)
				{
					isAncestor = true;
				}
			}
			map.Set(ancestor, isAncestor);
		}
		return isAncestor;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool HasInherits(DependencyPropertyDetails propertyDetails)
	{
		PropertyMetadata metadata = propertyDetails.Metadata;
		if (metadata is FrameworkPropertyMetadata frameworkPropertyMetadata)
		{
			return frameworkPropertyMetadata.Options.HasInherits();
		}
		return false;
	}

	private static (PropertyChangedCallback callback, IDisposable release) CreateWeakDelegate(PropertyChangedCallback callback)
	{
		ManagedWeakReference wr = WeakReferencePool.RentWeakReference(null, callback);
		PropertyChangedCallback item = delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((!wr.IsDisposed) ? (wr.Target as PropertyChangedCallback) : null)?.Invoke(s, e);
		};
		return (item, Disposable.Create(delegate
		{
			WeakReferencePool.ReturnWeakReference(null, wr);
		}));
	}

	private static (Action callback, IDisposable release) CreateWeakDelegate(Action callback)
	{
		ManagedWeakReference wr = WeakReferencePool.RentWeakReference(null, callback);
		Action item = delegate
		{
			(wr.Target as Action)?.Invoke();
		};
		return (item, Disposable.Create(delegate
		{
			WeakReferencePool.ReturnWeakReference(null, wr);
		}));
	}

	private static (ExplicitPropertyChangedCallback callback, IDisposable release) CreateWeakDelegate(ExplicitPropertyChangedCallback callback)
	{
		ManagedWeakReference wr = WeakReferencePool.RentWeakReference(null, callback);
		ExplicitPropertyChangedCallback item = delegate(ManagedWeakReference instance, DependencyProperty s, DependencyPropertyChangedEventArgs e)
		{
			(wr.Target as ExplicitPropertyChangedCallback)?.Invoke(instance, s, e);
		};
		return (item, Disposable.Create(delegate
		{
			WeakReferencePool.ReturnWeakReference(null, wr);
		}));
	}

	private void RaiseCallbacks(DependencyObject actualInstanceAlias, DependencyPropertyDetails propertyDetails, object? previousValue, DependencyPropertyValuePrecedences previousPrecedence, object? newValue, DependencyPropertyValuePrecedences newPrecedence)
	{
		bool flag = _propagationBypass.Count != 0 || _propagationBypassed.Count != 0;
		DependencyPropertyPath dependencyPropertyPath = (flag ? new DependencyPropertyPath(actualInstanceAlias, propertyDetails.Property) : null);
		if (AreDifferent(newValue, previousValue))
		{
			bool flag2 = flag && _propagationBypass.Contains(dependencyPropertyPath);
			if (flag2)
			{
				_propagationBypassed[dependencyPropertyPath] = previousValue;
			}
			InvokeCallbacks(actualInstanceAlias, propertyDetails.Property, propertyDetails, previousValue, previousPrecedence, newValue, newPrecedence, flag2);
		}
		else if (flag && _propagationBypassed.ContainsKey(dependencyPropertyPath) && !_propagationBypass.Contains<DependencyPropertyPath>(dependencyPropertyPath, DependencyPropertyPath.Comparer.Default))
		{
			object previousValue2 = _propagationBypassed[dependencyPropertyPath];
			_propagationBypassed.Remove(dependencyPropertyPath);
			InvokeCallbacks(actualInstanceAlias, propertyDetails.Property, propertyDetails, previousValue2, previousPrecedence, newValue, newPrecedence);
		}
		else if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Skipped raising PropertyChangedCallbacks because value for property {propertyDetails.Property.OwnerType}.{propertyDetails.Property.Name} remained identical.");
		}
	}

	private void InvokeCallbacks(DependencyObject actualInstanceAlias, DependencyProperty property, DependencyPropertyDetails propertyDetails, object? previousValue, DependencyPropertyValuePrecedences previousPrecedence, object? newValue, DependencyPropertyValuePrecedences newPrecedence, bool bypassesPropagation = false)
	{
		DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs = new DependencyPropertyChangedEventArgs(property, previousValue, previousPrecedence, newValue, newPrecedence, bypassesPropagation);
		PropertyMetadata metadata = propertyDetails.Metadata;
		ManagedWeakReference managedWeakReference = _originalObjectRef ?? ThisWeakReference;
		if (metadata is FrameworkPropertyMetadata frameworkPropertyMetadata)
		{
			if (frameworkPropertyMetadata.Options.HasLogicalChild())
			{
				UpdateAutoParent(actualInstanceAlias, previousValue, newValue);
			}
			if (frameworkPropertyMetadata.Options.HasAffectsMeasure())
			{
				actualInstanceAlias.InvalidateMeasure();
			}
			if (frameworkPropertyMetadata.Options.HasAffectsArrange())
			{
				actualInstanceAlias.InvalidateArrange();
			}
			if (frameworkPropertyMetadata.Options.HasAffectsRender())
			{
				actualInstanceAlias.InvalidateRender();
			}
			if (frameworkPropertyMetadata.Options.HasInherits())
			{
				for (int i = 0; i < _childrenStores.Count; i++)
				{
					CallChildCallback(_childrenStores[i], managedWeakReference, property, dependencyPropertyChangedEventArgs);
				}
			}
		}
		else if (property.IsDependencyObjectCollection)
		{
			UpdateAutoParent(actualInstanceAlias, previousValue, newValue);
		}
		metadata.RaiseBackingFieldUpdate(actualInstanceAlias, newValue);
		metadata.RaisePropertyChanged(actualInstanceAlias, dependencyPropertyChangedEventArgs);
		OnDependencyPropertyChanged(propertyDetails, dependencyPropertyChangedEventArgs);
		if (actualInstanceAlias is UIElement uIElement)
		{
			uIElement.OnPropertyChanged2(dependencyPropertyChangedEventArgs);
		}
		propertyDetails.CallbackManager.RaisePropertyChanged(actualInstanceAlias, dependencyPropertyChangedEventArgs);
		for (int j = 0; j < _genericCallbacks.Data.Length; j++)
		{
			ExplicitPropertyChangedCallback explicitPropertyChangedCallback = _genericCallbacks.Data[j];
			explicitPropertyChangedCallback(managedWeakReference, property, dependencyPropertyChangedEventArgs);
		}
	}

	private void CallChildCallback(DependencyObjectStore childStore, ManagedWeakReference instanceRef, DependencyProperty property, DependencyPropertyChangedEventArgs eventArgs)
	{
		bool flag = (_unregisteringInheritedProperties || _parentUnregisteringInheritedProperties) && property == _dataContextProperty;
		if (flag)
		{
			childStore._parentUnregisteringInheritedProperties = true;
		}
		childStore.OnParentPropertyChangedCallback(instanceRef, property, eventArgs);
		if (flag)
		{
			childStore._parentUnregisteringInheritedProperties = false;
		}
	}

	private static void UpdateAutoParent(DependencyObject actualInstanceAlias, object? previousValue, object? newValue)
	{
		if (previousValue is DependencyObject dependencyObject && dependencyObject.GetParent() == actualInstanceAlias)
		{
			dependencyObject.SetParent(null);
		}
		if (newValue is DependencyObject dependencyObject2)
		{
			dependencyObject2.SetParent(actualInstanceAlias);
		}
	}

	private void SetValueInternal(object? value, DependencyPropertyValuePrecedences precedence, DependencyPropertyDetails propertyDetails)
	{
		if (value != null && value != DependencyProperty.UnsetValue)
		{
			FrameworkPropertyMetadata obj = propertyDetails.Metadata as FrameworkPropertyMetadata;
			if (obj != null && obj.Options.HasAutoConvert() && value?.GetType() != propertyDetails.Property.Type)
			{
				value = Convert.ChangeType(value, propertyDetails.Property.Type);
			}
		}
		if (AreDifferent(value, propertyDetails.GetValue(precedence)))
		{
			propertyDetails.SetValue(value, precedence);
		}
	}

	public static bool AreDifferent(object? previousValue, object? newValue)
	{
		if (newValue is ValueType || newValue is string)
		{
			return !object.Equals(previousValue, newValue);
		}
		return previousValue != newValue;
	}

	private void OnParentChanged(object? previousParent, object? value)
	{
		if (_parentChangedCallbacks.Data.Length != 0)
		{
			DependencyObject actualInstance = ActualInstance;
			if (actualInstance != null)
			{
				DependencyObjectParentChangedEventArgs args = new DependencyObjectParentChangedEventArgs(previousParent, value);
				for (int i = 0; i < _parentChangedCallbacks.Data.Length; i++)
				{
					ParentChangedCallback parentChangedCallback = _parentChangedCallbacks.Data[i];
					parentChangedCallback(actualInstance, null, args);
				}
			}
		}
		CheckThemeBindings(previousParent, value);
	}

	private void CheckThemeBindings(object? previousParent, object? value)
	{
		if (!(ActualInstance is FrameworkElement instance))
		{
			return;
		}
		if (value == null && previousParent != null)
		{
			_themeLastUsed = Application.Current?.RequestedThemeForResources;
		}
		else
		{
			if (previousParent != null || value == null)
			{
				return;
			}
			SpecializedResourceDictionary.ResourceKey? themeLastUsed = _themeLastUsed;
			if (!themeLastUsed.HasValue)
			{
				return;
			}
			SpecializedResourceDictionary.ResourceKey valueOrDefault = themeLastUsed.GetValueOrDefault();
			_themeLastUsed = null;
			themeLastUsed = Application.Current?.RequestedThemeForResources;
			if (themeLastUsed.HasValue)
			{
				SpecializedResourceDictionary.ResourceKey valueOrDefault2 = themeLastUsed.GetValueOrDefault();
				if (!valueOrDefault.Equals(valueOrDefault2))
				{
					Application.PropagateResourcesChanged(instance, ResourceUpdateReason.ThemeResource);
				}
			}
		}
	}

	internal void SetLastUsedTheme(SpecializedResourceDictionary.ResourceKey? resourceKey)
	{
		_themeLastUsed = resourceKey;
	}

	internal IEnumerable<ResourceBinding> GetResourceBindingsForProperty(DependencyProperty dependencyProperty)
	{
		return _resourceBindings?.GetBindingsForProperty(dependencyProperty) ?? Enumerable.Empty<ResourceBinding>();
	}

	internal void TryEnableHardReferences()
	{
		if (FeatureConfiguration.DependencyObject.IsStoreHardReferenceEnabled)
		{
			_hardParentRef = Parent;
			_hardOriginalObjectRef = ActualInstance;
			_properties.TryEnableHardReferences();
		}
	}

	internal void DisableHardReferences()
	{
		if (FeatureConfiguration.DependencyObject.IsStoreHardReferenceEnabled)
		{
			_hardParentRef = null;
			_hardOriginalObjectRef = null;
			_properties.DisableHardReferences();
		}
	}
}

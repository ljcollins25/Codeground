using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uno.UI.DataBinding;

[DebuggerDisplay("Path={_path} DataContext={_dataContext}")]
internal class BindingPath : IDisposable, IValueChangedListener
{
	public delegate IDisposable? PropertyChangedRegistrationHandler(ManagedWeakReference dataContext, string propertyName, Action onNewValue);

	private sealed class BindingItem : IBindingItem, IDisposable
	{
		private delegate void PropertyChangedHandler(object? previousValue, object? newValue, bool shouldRaiseValueChanged);

		private ManagedWeakReference? _dataContextWeakStorage;

		private readonly SerialDisposable _propertyChanged = new SerialDisposable();

		private bool _disposed;

		private readonly DependencyPropertyValuePrecedences? _precedence;

		private readonly object? _fallbackValue;

		private readonly bool _allowPrivateMembers;

		private ValueGetterHandler? _valueGetter;

		private ValueGetterHandler? _precedenceSpecificGetter;

		private ValueGetterHandler? _substituteValueGetter;

		private ValueSetterHandler? _valueSetter;

		private ValueSetterHandler? _localValueSetter;

		private ValueUnsetterHandler? _valueUnsetter;

		private Type? _dataContextType;

		private bool _isDataContextChanging;

		public object? DataContext
		{
			get
			{
				return _dataContextWeakStorage?.Target;
			}
			set
			{
				if (!_disposed && (!FeatureConfiguration.Binding.IgnoreINPCSameReferences || DependencyObjectStore.AreDifferent(DataContext, value)))
				{
					ManagedWeakReference weakDataContext = WeakReferencePool.RentWeakReference(this, value);
					SetWeakDataContext(weakDataContext);
				}
			}
		}

		public BindingItem? Next { get; }

		public string PropertyName { get; }

		public IValueChangedListener? ValueChangedListener { get; set; }

		public object? Value
		{
			get
			{
				return GetSourceValue();
			}
			set
			{
				SetValue(value);
			}
		}

		public Type? PropertyType
		{
			get
			{
				if (DataContext != null)
				{
					return BindingPropertyHelper.GetPropertyType(_dataContextType, PropertyName, _allowPrivateMembers);
				}
				return null;
			}
		}

		public BindingItem(BindingItem next, string property, object fallbackValue)
			: this(next, property, fallbackValue, null, allowPrivateMembers: false)
		{
		}

		internal BindingItem(BindingItem? next, string property, object? fallbackValue, DependencyPropertyValuePrecedences? precedence, bool allowPrivateMembers)
		{
			Next = next;
			PropertyName = property;
			_precedence = precedence;
			_fallbackValue = fallbackValue;
			_allowPrivateMembers = allowPrivateMembers;
		}

		internal void SetWeakDataContext(ManagedWeakReference? weakDataContext, bool transferReferenceOwnership = false)
		{
			ManagedWeakReference dataContextWeakStorage = _dataContextWeakStorage;
			_dataContextWeakStorage = weakDataContext;
			OnDataContextChanged();
			WeakReferencePool.ReturnWeakReference(this, dataContextWeakStorage);
		}

		private void SetValue(object? value)
		{
			BuildValueSetter();
			SetSourceValue(_valueSetter, value);
		}

		public void SetLocalValue(object value)
		{
			BuildLocalValueSetter();
			SetSourceValue(_localValueSetter, value);
		}

		internal object? GetPrecedenceSpecificValue()
		{
			BuildPrecedenceSpecificValueGetter();
			return GetSourceValue(_precedenceSpecificGetter);
		}

		internal object? GetSubstituteValue()
		{
			BuildSubstituteValueGetter();
			return GetSourceValue(_substituteValueGetter);
		}

		private void OnDataContextChanged()
		{
			if (DataContext != null)
			{
				ClearCachedGetters();
				if (_propertyChanged.Disposable != null)
				{
					_isDataContextChanging = true;
					_propertyChanged.Disposable = null;
					_isDataContextChanging = false;
				}
				_propertyChanged.Disposable = SubscribeToPropertyChanged(delegate(object? previousValue, object? newValue, bool shouldRaiseValueChanged)
				{
					if (!_isDataContextChanging || !(newValue is UnsetValue))
					{
						if (Next != null)
						{
							Next!.DataContext = newValue;
						}
						if (shouldRaiseValueChanged && previousValue != newValue)
						{
							RaiseValueChanged(newValue);
						}
					}
				});
				RaiseValueChanged(Value);
				if (Next != null)
				{
					Next!.DataContext = Value;
				}
			}
			else
			{
				if (Next != null)
				{
					Next!.DataContext = null;
				}
				RaiseValueChanged(null);
				_propertyChanged.Disposable = null;
			}
		}

		private void ClearCachedGetters()
		{
			Type type = DataContext!.GetType();
			if (_dataContextType != type && _dataContextType != null)
			{
				_valueGetter = null;
				_precedenceSpecificGetter = null;
				_substituteValueGetter = null;
				_localValueSetter = null;
				_valueSetter = null;
				_valueUnsetter = null;
			}
			_dataContextType = type;
		}

		private void BuildValueSetter()
		{
			if (_valueSetter == null && _dataContextType != null)
			{
				if (!_precedence.HasValue)
				{
					BuildLocalValueSetter();
					_valueSetter = _localValueSetter;
				}
				else
				{
					_valueSetter = BindingPropertyHelper.GetValueSetter(_dataContextType, PropertyName, convert: true, _precedence.Value);
				}
			}
		}

		private void BuildLocalValueSetter()
		{
			if (_localValueSetter == null && _dataContextType != null)
			{
				_localValueSetter = BindingPropertyHelper.GetValueSetter(_dataContextType, PropertyName, convert: true);
			}
		}

		private void SetSourceValue(ValueSetterHandler setter, object? value)
		{
			object dataContext = DataContext;
			if (dataContext != null)
			{
				try
				{
					setter(dataContext, value);
					return;
				}
				catch (Exception ex)
				{
					if (this.Log().IsEnabled(LogLevel.Error))
					{
						this.Log().Error("Failed to set the source value for [" + PropertyName + "]", ex);
					}
					return;
				}
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().DebugFormat("Setting [{0}] failed because the DataContext is null for. It may have already been collected, or explicitly set to null.", PropertyName);
			}
		}

		private void BuildValueGetter()
		{
			if (_valueGetter == null && _dataContextType != null)
			{
				_valueGetter = BindingPropertyHelper.GetValueGetter(_dataContextType, PropertyName, _precedence, _allowPrivateMembers);
			}
		}

		private void BuildPrecedenceSpecificValueGetter()
		{
			if (_precedenceSpecificGetter == null && _dataContextType != null)
			{
				_precedenceSpecificGetter = BindingPropertyHelper.GetValueGetter(_dataContextType, PropertyName, _precedence, _allowPrivateMembers);
			}
		}

		private void BuildSubstituteValueGetter()
		{
			if (_substituteValueGetter == null && _dataContextType != null)
			{
				_substituteValueGetter = BindingPropertyHelper.GetSubstituteValueGetter(_dataContextType, PropertyName, _precedence ?? DependencyPropertyValuePrecedences.Local);
			}
		}

		private object? GetSourceValue()
		{
			BuildValueGetter();
			return GetSourceValue(_valueGetter);
		}

		private object? GetSourceValue(ValueGetterHandler getter)
		{
			object dataContext = DataContext;
			if (dataContext != null)
			{
				try
				{
					return getter(dataContext);
				}
				catch (Exception ex)
				{
					if (this.Log().IsEnabled(LogLevel.Error))
					{
						this.Log().Error("Failed to get the source value for [" + PropertyName + "]", ex);
					}
					return DependencyProperty.UnsetValue;
				}
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().DebugFormat("Unable to get the source value for [{0}]", PropertyName);
			}
			return null;
		}

		private void BuildValueUnsetter()
		{
			if (_valueUnsetter == null && _dataContextType != null)
			{
				_valueUnsetter = ((!_precedence.HasValue) ? BindingPropertyHelper.GetValueUnsetter(_dataContextType, PropertyName) : BindingPropertyHelper.GetValueUnsetter(_dataContextType, PropertyName, _precedence.Value));
			}
		}

		internal void ClearValue()
		{
			BuildValueUnsetter();
			object dataContext = DataContext;
			if (dataContext != null)
			{
				_valueUnsetter!(dataContext);
			}
			else if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().DebugFormat("Unsetting [{0}] failed because the DataContext is null for. It may have already been collected, or explicitly set to null.", PropertyName);
			}
		}

		private void RaiseValueChanged(object? newValue)
		{
			ValueChangedListener?.OnValueChanged(newValue);
		}

		private IDisposable SubscribeToPropertyChanged(PropertyChangedHandler action)
		{
			PropertyChangedHandler action2 = action;
			CompositeDisposable compositeDisposable = new CompositeDisposable(_propertyChangedHandlers.Count * 3);
			for (int i = 0; i < _propertyChangedHandlers.Count; i++)
			{
				PropertyChangedRegistrationHandler propertyChangedRegistrationHandler = _propertyChangedHandlers[i];
				object previousValue = null;
				Action updateProperty = delegate
				{
					object sourceValue = GetSourceValue();
					action2(previousValue, sourceValue, shouldRaiseValueChanged: true);
					previousValue = sourceValue;
				};
				Action action3 = delegate
				{
					action2(previousValue, DependencyProperty.UnsetValue, shouldRaiseValueChanged: false);
				};
				IDisposable disposable = propertyChangedRegistrationHandler(_dataContextWeakStorage, PropertyName, updateProperty);
				if (disposable != null)
				{
					previousValue = GetSourceValue();
					compositeDisposable.Add(delegate
					{
						updateProperty = null;
					});
					compositeDisposable.Add(disposable);
					compositeDisposable.Add(action3);
				}
			}
			return compositeDisposable;
		}

		public void Dispose()
		{
			_disposed = true;
			_propertyChanged.Dispose();
		}
	}

	private static List<PropertyChangedRegistrationHandler> _propertyChangedHandlers;

	private readonly string _path;

	private BindingItem? _chain;

	private BindingItem? _value;

	private ManagedWeakReference? _dataContextWeakStorage;

	private bool _disposed;

	public IValueChangedListener? ValueChangedListener { get; set; }

	public string Path => _path;

	public object? Value
	{
		get
		{
			if (_value != null)
			{
				return _value!.Value;
			}
			return DataContext;
		}
		set
		{
			if (!_disposed && _value != null && DependencyObjectStore.AreDifferent(value, _value!.GetPrecedenceSpecificValue()))
			{
				_value!.Value = value;
			}
		}
	}

	internal string? LeafPropertyName => _value?.PropertyName;

	public Type? ValueType => _value?.PropertyType;

	internal object? DataItem => _value?.DataContext;

	public object? DataContext
	{
		get
		{
			return _dataContextWeakStorage?.Target;
		}
		set
		{
			SetWeakDataContext(WeakReferencePool.RentWeakReference(this, value));
		}
	}

	static BindingPath()
	{
		_propertyChangedHandlers = new List<PropertyChangedRegistrationHandler>();
		RegisterPropertyChangedRegistrationHandler(new PropertyChangedRegistrationHandler(SubscribeToNotifyPropertyChanged));
	}

	public BindingPath(string path, object? fallbackValue)
		: this(path, fallbackValue, null, allowPrivateMembers: false)
	{
	}

	internal BindingPath(string path, object? fallbackValue, DependencyPropertyValuePrecedences? precedence, bool allowPrivateMembers)
	{
		_path = path ?? "";
		Parse(_path, fallbackValue, precedence, allowPrivateMembers, ref _chain, ref _value);
		if (_value != null)
		{
			_value!.ValueChangedListener = this;
		}
	}

	public IEnumerable<IBindingItem> GetPathItems()
	{
		return _chain?.Flatten((BindingItem i) => i.Next) ?? new BindingItem[0];
	}

	internal void CloneShareableObjectsInPath()
	{
		foreach (BindingItem pathItem in GetPathItems())
		{
			if ((pathItem.PropertyType == typeof(Brush) || pathItem.PropertyType == typeof(GeneralTransform)) && pathItem.Value is IShareableDependencyObject shareableDependencyObject && !shareableDependencyObject.IsClone && pathItem.DataContext is DependencyObject)
			{
				DependencyObject dependencyObject3 = (DependencyObject)(pathItem.Value = shareableDependencyObject.Clone());
				break;
			}
		}
	}

	public static void RegisterPropertyChangedRegistrationHandler(PropertyChangedRegistrationHandler handler)
	{
		_propertyChangedHandlers.Add(handler);
	}

	public object? GetSubstituteValue()
	{
		if (_value != null)
		{
			return _value!.GetSubstituteValue();
		}
		return DataContext;
	}

	internal void SetLocalValue(object value)
	{
		if (!_disposed)
		{
			_value?.SetLocalValue(value);
		}
	}

	public void ClearValue()
	{
		if (!_disposed)
		{
			_value?.ClearValue();
		}
	}

	internal void SetWeakDataContext(ManagedWeakReference weakDataContext)
	{
		if (!_disposed)
		{
			ManagedWeakReference dataContextWeakStorage = _dataContextWeakStorage;
			_dataContextWeakStorage = weakDataContext;
			OnDataContextChanged();
			WeakReferencePool.ReturnWeakReference(this, dataContextWeakStorage);
		}
	}

	private void OnDataContextChanged()
	{
		if (_chain != null)
		{
			_chain!.SetWeakDataContext(_dataContextWeakStorage);
		}
		else
		{
			ValueChangedListener?.OnValueChanged(Value);
		}
	}

	void IValueChangedListener.OnValueChanged(object o)
	{
		ValueChangedListener?.OnValueChanged(o);
	}

	~BindingPath()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		_disposed = true;
		if (disposing)
		{
			_value.SafeDispose();
			_chain.SafeDispose();
		}
	}

	private static void Parse(string path, object? fallbackValue, DependencyPropertyValuePrecedences? precedence, bool allowPrivateMembers, ref BindingItem? head, ref BindingItem? tail)
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		for (int num2 = path.Length - 1; num2 >= 0; num2--)
		{
			char c = path[num2];
			switch (c)
			{
			case ')':
				TryPrependItem(path, num2 + 1, num, fallbackValue, precedence, allowPrivateMembers, ref head, ref tail);
				flag = true;
				num = 0;
				continue;
			case '(':
				if (flag)
				{
					TryPrependItem(path, num2 + 1, num, fallbackValue, precedence, allowPrivateMembers, ref head, ref tail);
					flag = false;
					num = 0;
					continue;
				}
				break;
			case ']':
				TryPrependItem(path, num2 + 1, num, fallbackValue, precedence, allowPrivateMembers, ref head, ref tail);
				flag2 = true;
				num = 1;
				continue;
			case '[':
				if (flag2)
				{
					TryPrependItem(path, num2, ++num, fallbackValue, precedence, allowPrivateMembers, ref head, ref tail);
					flag2 = false;
					num = 0;
					continue;
				}
				break;
			case '.':
				if (!flag)
				{
					TryPrependItem(path, num2 + 1, num, fallbackValue, precedence, allowPrivateMembers, ref head, ref tail);
					num = 0;
					continue;
				}
				break;
			}
			if (num > 0 || !char.IsWhiteSpace(c))
			{
				num++;
			}
		}
		TryPrependItem(path, 0, num, fallbackValue, precedence, allowPrivateMembers, ref head, ref tail);
	}

	private static void TryPrependItem(string path, int start, int length, object? fallbackValue, DependencyPropertyValuePrecedences? precedence, bool allowPrivateMembers, ref BindingItem? head, ref BindingItem? tail)
	{
		if (length <= 0)
		{
			return;
		}
		char c = path[start];
		while (char.IsWhiteSpace(c) && length > 0)
		{
			start++;
			length--;
			c = path[start];
		}
		if (length > 0)
		{
			string property = path.Substring(start, length);
			BindingItem bindingItem = (head = new BindingItem(head, property, fallbackValue, precedence, allowPrivateMembers));
			if (tail == null)
			{
				tail = bindingItem;
			}
		}
	}

	private static IDisposable? SubscribeToNotifyPropertyChanged(ManagedWeakReference dataContextReference, string propertyName, Action newValueAction)
	{
		string propertyName2 = propertyName;
		ManagedWeakReference dataContextReference2 = dataContextReference;
		if (dataContextReference2.Target is INotifyPropertyChanged notifyPropertyChanged)
		{
			if (propertyName2.Length != 0 && propertyName2[0] == '[')
			{
				propertyName2 = "Item" + propertyName2;
			}
			ManagedWeakReference newValueActionWeak = WeakReferencePool.RentWeakReference(null, newValueAction);
			PropertyChangedEventHandler handler = delegate(object s, PropertyChangedEventArgs args)
			{
				if (args.PropertyName == propertyName2 || string.IsNullOrEmpty(args.PropertyName))
				{
					if (typeof(BindingPath).Log().IsEnabled(LogLevel.Debug))
					{
						typeof(BindingPath).Log().Debug($"Property changed for {propertyName2} on [{dataContextReference2.Target?.GetType()}]");
					}
					if (!newValueActionWeak.IsDisposed)
					{
						(newValueActionWeak.Target as Action)?.Invoke();
					}
				}
			};
			notifyPropertyChanged.PropertyChanged += handler;
			return Disposable.Create(delegate
			{
				if (dataContextReference2.Target is INotifyPropertyChanged notifyPropertyChanged2)
				{
					notifyPropertyChanged2.PropertyChanged -= handler;
				}
				WeakReferencePool.ReturnWeakReference(null, newValueActionWeak);
			});
		}
		return null;
	}
}

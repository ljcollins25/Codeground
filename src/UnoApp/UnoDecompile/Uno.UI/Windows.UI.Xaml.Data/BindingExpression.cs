using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;

namespace Windows.UI.Xaml.Data;

public class BindingExpression : BindingExpressionBase, IDisposable, IValueChangedListener
{
	private readonly Type _boundPropertyType;

	private readonly ManagedWeakReference _view;

	private readonly Type _targetOwnerType;

	private ManagedWeakReference _dataContext;

	private SerialDisposable _subscription = new SerialDisposable();

	private BindingPath _bindingPath;

	private bool _disposed;

	private ManagedWeakReference _explicitSourceStore;

	private readonly bool _isCompiledSource;

	private readonly bool _isElementNameSource;

	private bool _isBindingSuspended;

	private ValueGetterHandler _valueGetter;

	private ValueSetterHandler _valueSetter;

	private bool _IsCurrentlyPushingTwoWay;

	private bool _IsCurrentlyPushing;

	private BindingPath[] _updateSources;

	public Binding ParentBinding { get; }

	internal DependencyPropertyDetails TargetPropertyDetails { get; }

	private object ExplicitSource
	{
		get
		{
			return _explicitSourceStore?.Target;
		}
		set
		{
			_explicitSourceStore = WeakReferencePool.RentWeakReference(this, value);
		}
	}

	public string TargetName => TargetPropertyDetails.Property.Name;

	public object DataContext
	{
		get
		{
			if (!_isElementNameSource && ExplicitSource == null)
			{
				return _dataContext?.Target;
			}
			return ExplicitSource;
		}
		set
		{
			if (ExplicitSource == null && !_disposed && DependencyObjectStore.AreDifferent(_dataContext?.Target, value))
			{
				ManagedWeakReference dataContext = _dataContext;
				_dataContext = WeakReferencePool.RentWeakReference(this, value);
				ApplyBinding();
				WeakReferencePool.ReturnWeakReference(this, dataContext);
			}
		}
	}

	public object DataItem => _bindingPath.DataItem;

	internal BindingExpression(ManagedWeakReference viewReference, DependencyPropertyDetails targetPropertyDetails, Binding binding)
	{
		ParentBinding = binding;
		_view = viewReference;
		if (_view?.Target is AttachedDependencyObject attachedDependencyObject)
		{
			_view = attachedDependencyObject.OwnerWeakReference;
		}
		_targetOwnerType = targetPropertyDetails.Property.OwnerType;
		TargetPropertyDetails = targetPropertyDetails;
		_bindingPath = new BindingPath((string)ParentBinding.Path, ParentBinding.FallbackValue, null, ParentBinding.CompiledSource != null);
		_boundPropertyType = targetPropertyDetails.Property.Type;
		TryGetSource(binding);
		if (ParentBinding.CompiledSource != null)
		{
			_isCompiledSource = true;
			ExplicitSource = ParentBinding.CompiledSource;
		}
		if (ParentBinding.XBindPropertyPaths != null)
		{
			_updateSources = ParentBinding.XBindPropertyPaths.Select((string p) => new BindingPath(p, null, null, allowPrivateMembers: true)).ToArray();
		}
		if (ParentBinding.ElementName != null)
		{
			_isElementNameSource = true;
		}
		ManagedWeakReference weakDataContext = GetWeakDataContext();
		if (weakDataContext == null || !weakDataContext.IsAlive)
		{
			ApplyFallbackValue();
		}
		ApplyExplicitSource();
		ApplyElementName();
	}

	private ManagedWeakReference GetWeakDataContext()
	{
		if (!_isElementNameSource)
		{
			ManagedWeakReference explicitSourceStore = _explicitSourceStore;
			if (explicitSourceStore == null || !explicitSourceStore.IsAlive)
			{
				return _dataContext;
			}
		}
		return _explicitSourceStore;
	}

	public void UpdateSource()
	{
		if (TryGetTargetValue(out var value))
		{
			UpdateSource(value);
		}
	}

	public void UpdateSource(object value)
	{
		if (!_IsCurrentlyPushing && !_IsCurrentlyPushingTwoWay && ParentBinding.Mode == BindingMode.TwoWay)
		{
			_IsCurrentlyPushingTwoWay = true;
			if (ParentBinding.Converter != null)
			{
				value = ParentBinding.Converter.ConvertBack(value, _bindingPath.ValueType, ParentBinding.ConverterParameter, GetCurrentCulture());
			}
			if (ParentBinding.XBindBack != null)
			{
				UpdateSourceOnXBindBack(value);
			}
			else
			{
				_bindingPath.Value = value;
			}
			_IsCurrentlyPushingTwoWay = false;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void UpdateSourceOnXBindBack(object value)
	{
		try
		{
			ParentBinding.XBindBack(DataContext, value);
		}
		catch (Exception ex)
		{
			if (this.Log().IsEnabled(LogLevel.Error))
			{
				this.Log().Error($"Failed to set the source value for x:Bind path [{ParentBinding.Path}]", ex);
			}
		}
	}

	public void SetSourceValue(object value)
	{
		if (_disposed)
		{
			return;
		}
		try
		{
			if (ParentBinding.Mode == BindingMode.TwoWay && ResolveUpdateSourceTrigger() == UpdateSourceTrigger.PropertyChanged)
			{
				UpdateSource(value);
			}
		}
		catch (Exception ex)
		{
			this.Log().Error("Failed to set value [{0}] to [{1}]".InvariantCultureFormat(value, TargetPropertyDetails), ex);
		}
	}

	internal void SuspendBinding()
	{
		if (!_isBindingSuspended)
		{
			_isBindingSuspended = true;
			_subscription.Dispose();
		}
	}

	internal void ResumeBinding()
	{
		if (_isBindingSuspended)
		{
			_isBindingSuspended = false;
			ApplyBinding();
		}
	}

	private UpdateSourceTrigger ResolveUpdateSourceTrigger()
	{
		if (ParentBinding.UpdateSourceTrigger == UpdateSourceTrigger.Default)
		{
			if (!(TargetPropertyDetails.Property?.GetMetadata(_targetOwnerType) is FrameworkPropertyMetadata frameworkPropertyMetadata))
			{
				return UpdateSourceTrigger.PropertyChanged;
			}
			return frameworkPropertyMetadata.DefaultUpdateSourceTrigger;
		}
		return ParentBinding.UpdateSourceTrigger;
	}

	internal void ApplyElementName()
	{
		object elementName = ParentBinding.ElementName;
		ElementNameSubject elementNameSubject = elementName as ElementNameSubject;
		if (elementNameSubject == null)
		{
			return;
		}
		if (elementNameSubject.IsLoadTimeBound)
		{
			object obj2 = (ExplicitSource = NameScope.FindInNamescopes(_view?.Target as DependencyObject, elementNameSubject.Name));
			ApplyExplicitSource();
		}
		else if (elementNameSubject.ElementInstance == null)
		{
			elementNameSubject.ElementInstanceChanged += delegate
			{
				applySource();
			};
		}
		else
		{
			applySource();
		}
		void applySource()
		{
			ExplicitSource = elementNameSubject.ElementInstance;
			ApplyExplicitSource();
		}
	}

	private void ApplyFallbackValue(bool useTypeDefaultValue = true)
	{
		if (ParentBinding.FallbackValue != null)
		{
			SetTargetValue(ConvertToBoundPropertyType(ParentBinding.FallbackValue));
		}
		else if (useTypeDefaultValue && TargetPropertyDetails != null)
		{
			SetTargetValue(TargetPropertyDetails.Property.GetMetadata(_view.Target?.GetType()).DefaultValue);
		}
	}

	private void ApplyExplicitSource()
	{
		if (_isElementNameSource || (ExplicitSource != null && !_isCompiledSource))
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().DebugFormat("Applying explicit source {0} on {1}", ExplicitSource?.GetType(), _view.Target?.GetType());
			}
			ApplyBinding();
		}
	}

	internal void ApplyCompiledSource()
	{
		if (_isCompiledSource && ExplicitSource != null)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().DebugFormat("Applying compiled source {0} on {1}", ExplicitSource.GetType(), _view.Target?.GetType());
			}
			ApplyBinding();
		}
	}

	private void TryGetSource(Binding binding)
	{
		object source = binding.Source;
		ElementNameSubject sourceSubject = source as ElementNameSubject;
		if (sourceSubject != null)
		{
			if (sourceSubject.ElementInstance == null)
			{
				sourceSubject.ElementInstanceChanged += delegate
				{
					applySource();
				};
			}
			else
			{
				applySource();
			}
		}
		else
		{
			ExplicitSource = binding.Source;
		}
		void applySource()
		{
			ExplicitSource = sourceSubject.ElementInstance;
			ApplyExplicitSource();
		}
	}

	private bool TryGetTargetValue(out object value)
	{
		object target = _view.Target;
		if (target != null)
		{
			value = GetValueGetter()(target);
			return true;
		}
		Dispose();
		value = null;
		return false;
	}

	private void SetTargetValue(object value)
	{
		object target = _view.Target;
		if (target != null)
		{
			GetValueSetter()(target, value);
		}
		else
		{
			Dispose();
		}
	}

	private ValueGetterHandler GetValueGetter()
	{
		if (_valueGetter == null)
		{
			_valueGetter = BindingPropertyHelper.GetValueGetter(_targetOwnerType, TargetPropertyDetails.Property.Name);
		}
		return _valueGetter;
	}

	private ValueSetterHandler GetValueSetter()
	{
		if (_valueSetter == null)
		{
			_valueSetter = BindingPropertyHelper.GetValueSetter(_targetOwnerType, TargetPropertyDetails.Property.Name, convert: true);
		}
		return _valueSetter;
	}

	private void ApplyBinding()
	{
		ManagedWeakReference weakDataContext = GetWeakDataContext();
		if (weakDataContext != null && weakDataContext.IsAlive)
		{
			_subscription.Disposable = null;
			if (_updateSources != null)
			{
				BindingPath[] updateSources = _updateSources;
				foreach (BindingPath bindingPath in updateSources)
				{
					bindingPath.ValueChangedListener = this;
					if (ParentBinding.CompiledSource != null)
					{
						bindingPath.DataContext = ParentBinding.CompiledSource;
					}
					else
					{
						bindingPath.SetWeakDataContext(weakDataContext);
					}
				}
				_subscription.Disposable = Actions.ToDisposable(delegate
				{
					BindingPath[] updateSources3 = _updateSources;
					foreach (BindingPath bindingPath3 in updateSources3)
					{
						bindingPath3.ValueChangedListener = null;
					}
				});
			}
			else
			{
				_bindingPath.ValueChangedListener = this;
				_bindingPath.SetWeakDataContext(weakDataContext);
				_subscription.Disposable = Actions.ToDisposable(delegate
				{
					_bindingPath.ValueChangedListener = null;
				});
			}
			return;
		}
		if (_updateSources != null)
		{
			BindingPath[] updateSources2 = _updateSources;
			foreach (BindingPath bindingPath2 in updateSources2)
			{
				bindingPath2.DataContext = null;
			}
		}
		else
		{
			_bindingPath.DataContext = null;
		}
		if (ParentBinding.FallbackValue != null)
		{
			ApplyFallbackValue();
		}
		else
		{
			SetTargetValueSafe(null, useTargetNullValue: false);
		}
		_subscription.Disposable = null;
	}

	void IValueChangedListener.OnValueChanged(object o)
	{
		if (ParentBinding.XBindSelector != null)
		{
			SetTargetValueForXBindSelector();
		}
		else
		{
			SetTargetValueSafe(o);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void SetTargetValueForXBindSelector()
	{
		if (FeatureConfiguration.BindingExpression.HandleSetTargetValueExceptions)
		{
			SetTargetValueWithTry();
		}
		else
		{
			SetTargetValue();
		}
		void SetTargetValue()
		{
			BindingPath[] updateSources = _updateSources;
			if (updateSources == null || updateSources.None((BindingPath s) => s.ValueType == null))
			{
				SetTargetValueSafe(ParentBinding.XBindSelector(DataContext));
			}
			else
			{
				ApplyFallbackValue(useTypeDefaultValue: false);
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Binding path does not provide a value [{TargetPropertyDetails}] on [{_targetOwnerType}], using fallback value");
				}
			}
		}
		void SetTargetValueWithTry()
		{
			try
			{
				SetTargetValue();
			}
			catch (Exception ex)
			{
				ApplyFallbackValue();
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error("Failed to apply binding to property [{0}] on [{1}] ({2})".InvariantCultureFormat(TargetPropertyDetails, _targetOwnerType, ex.Message), ex);
				}
			}
		}
	}

	private void SetTargetValueSafe(object v)
	{
		if (!_IsCurrentlyPushingTwoWay)
		{
			SetTargetValueSafe(v, useTargetNullValue: true);
		}
	}

	private void SetTargetValueSafe(object v, bool useTargetNullValue)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("{0}.SetTargetValueSafe({1}) (p:{2}, h:{3:X8})", _view.Target?.GetType() ?? typeof(object), v.SelectOrDefault<object, string>((object vv) => vv.ToString(), "[null]"), _bindingPath.Path, _view.Target?.GetHashCode());
		}
		if (FeatureConfiguration.BindingExpression.HandleSetTargetValueExceptions)
		{
			SetTargetValueSafeWithTry(v, useTargetNullValue);
			return;
		}
		InnerSetTargetValueSafe(v, useTargetNullValue);
		_IsCurrentlyPushing = false;
		void SetTargetValueSafeWithTry(object v, bool useTargetNullValue)
		{
			try
			{
				InnerSetTargetValueSafe(v, useTargetNullValue);
			}
			catch (Exception ex)
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error("Failed to apply binding to property [{0}] on [{1}] ({2})".InvariantCultureFormat(TargetPropertyDetails, _targetOwnerType, ex.Message), ex);
				}
				ApplyFallbackValue();
			}
			_IsCurrentlyPushing = false;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void InnerSetTargetValueSafe(object v, bool useTargetNullValue)
	{
		if (v is UnsetValue)
		{
			ApplyFallbackValue();
			return;
		}
		_IsCurrentlyPushing = true;
		object obj = ConvertValue(v);
		if (obj == DependencyProperty.UnsetValue)
		{
			ApplyFallbackValue();
		}
		else if (useTargetNullValue && obj == null && ParentBinding.TargetNullValue != null)
		{
			SetTargetValue(ConvertValue(ParentBinding.TargetNullValue));
		}
		else
		{
			SetTargetValue(obj);
		}
	}

	private string GetCurrentCulture()
	{
		return CultureInfo.CurrentCulture.ToString();
	}

	private object ConvertValue(object value)
	{
		if (ParentBinding.Converter != null)
		{
			return ParentBinding.Converter.Convert(value, _boundPropertyType, ParentBinding.ConverterParameter, GetCurrentCulture());
		}
		return ConvertToBoundPropertyType(value);
	}

	private object ConvertToBoundPropertyType(object value)
	{
		if (value != null && _boundPropertyType != null && _boundPropertyType != typeof(object) && !value.GetType().Is(_boundPropertyType))
		{
			value = BindingPropertyHelper.Convert(() => _boundPropertyType, value);
		}
		return value;
	}

	public void Dispose()
	{
		_subscription.Dispose();
		_bindingPath.Dispose();
		_disposed = true;
	}
}

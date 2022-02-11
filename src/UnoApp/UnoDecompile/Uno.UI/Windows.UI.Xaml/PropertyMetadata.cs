using System;
using Uno;

namespace Windows.UI.Xaml;

public class PropertyMetadata
{
	private bool _isDefaultValueSet;

	private object _defaultValue;

	private bool _isCoerceValueCallbackSet;

	private CoerceValueCallback _coerceValueCallback;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CreateDefaultValueCallback CreateDefaultValueCallback
	{
		get
		{
			throw new NotImplementedException("The member CreateDefaultValueCallback PropertyMetadata.CreateDefaultValueCallback is not implemented in Uno.");
		}
	}

	internal bool CoerceWhenUnchanged { get; set; } = true;


	public object DefaultValue
	{
		get
		{
			return _defaultValue;
		}
		internal set
		{
			_defaultValue = value;
			_isDefaultValueSet = true;
		}
	}

	public PropertyChangedCallback PropertyChangedCallback { get; internal set; }

	internal CoerceValueCallback CoerceValueCallback
	{
		get
		{
			return _coerceValueCallback;
		}
		set
		{
			_coerceValueCallback = value;
			_isCoerceValueCallbackSet = true;
		}
	}

	internal BackingFieldUpdateCallback BackingFieldUpdateCallback { get; set; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static PropertyMetadata Create(object defaultValue)
	{
		throw new NotImplementedException("The member PropertyMetadata PropertyMetadata.Create(object defaultValue) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static PropertyMetadata Create(object defaultValue, PropertyChangedCallback propertyChangedCallback)
	{
		throw new NotImplementedException("The member PropertyMetadata PropertyMetadata.Create(object defaultValue, PropertyChangedCallback propertyChangedCallback) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static PropertyMetadata Create(CreateDefaultValueCallback createDefaultValueCallback)
	{
		throw new NotImplementedException("The member PropertyMetadata PropertyMetadata.Create(CreateDefaultValueCallback createDefaultValueCallback) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static PropertyMetadata Create(CreateDefaultValueCallback createDefaultValueCallback, PropertyChangedCallback propertyChangedCallback)
	{
		throw new NotImplementedException("The member PropertyMetadata PropertyMetadata.Create(CreateDefaultValueCallback createDefaultValueCallback, PropertyChangedCallback propertyChangedCallback) is not implemented in Uno.");
	}

	internal PropertyMetadata()
	{
	}

	public PropertyMetadata(object defaultValue)
	{
		DefaultValue = defaultValue;
	}

	internal PropertyMetadata(object defaultValue, BackingFieldUpdateCallback backingFieldUpdateCallback)
	{
		DefaultValue = defaultValue;
		BackingFieldUpdateCallback = backingFieldUpdateCallback;
	}

	public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
	{
		DefaultValue = defaultValue;
		PropertyChangedCallback = propertyChangedCallback;
	}

	internal PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, BackingFieldUpdateCallback backingFieldUpdateCallback)
	{
		DefaultValue = defaultValue;
		PropertyChangedCallback = propertyChangedCallback;
		BackingFieldUpdateCallback = backingFieldUpdateCallback;
	}

	public PropertyMetadata(PropertyChangedCallback propertyChangedCallback)
	{
		PropertyChangedCallback = propertyChangedCallback;
	}

	internal PropertyMetadata(PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
	{
		PropertyChangedCallback = propertyChangedCallback;
		CoerceValueCallback = coerceValueCallback;
	}

	internal PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
	{
		DefaultValue = defaultValue;
		PropertyChangedCallback = propertyChangedCallback;
		CoerceValueCallback = coerceValueCallback;
	}

	internal PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, BackingFieldUpdateCallback backingFieldUpdateCallback)
	{
		DefaultValue = defaultValue;
		PropertyChangedCallback = propertyChangedCallback;
		CoerceValueCallback = coerceValueCallback;
		BackingFieldUpdateCallback = backingFieldUpdateCallback;
	}

	protected internal virtual void Merge(PropertyMetadata baseMetadata, DependencyProperty dp)
	{
		if (!_isCoerceValueCallbackSet)
		{
			CoerceValueCallback = baseMetadata.CoerceValueCallback;
		}
		if (!_isDefaultValueSet)
		{
			DefaultValue = baseMetadata.DefaultValue;
		}
		PropertyChangedCallback = (PropertyChangedCallback)Delegate.Combine(baseMetadata.PropertyChangedCallback, PropertyChangedCallback);
		BackingFieldUpdateCallback = (BackingFieldUpdateCallback)Delegate.Combine(baseMetadata.BackingFieldUpdateCallback, BackingFieldUpdateCallback);
	}

	internal void MergePropertyChangedCallback(PropertyChangedCallback callback)
	{
		PropertyChangedCallback = (PropertyChangedCallback)Delegate.Combine(PropertyChangedCallback, callback);
	}

	internal void RaisePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
	{
		PropertyChangedCallback?.Invoke(source, e);
	}

	internal void RaiseBackingFieldUpdate(DependencyObject source, object newValue)
	{
		BackingFieldUpdateCallback?.Invoke(source, newValue);
	}
}

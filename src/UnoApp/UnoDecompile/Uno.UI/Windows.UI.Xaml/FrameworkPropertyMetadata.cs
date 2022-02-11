using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

public class FrameworkPropertyMetadata : PropertyMetadata
{
	private bool _isDefaultUpdateSourceTriggerSet;

	private UpdateSourceTrigger _defaultUpdateSourceTrigger;

	public FrameworkPropertyMetadataOptions Options { get; set; } = FrameworkPropertyMetadataOptions.ValueInheritsDataContext;


	public UpdateSourceTrigger DefaultUpdateSourceTrigger
	{
		get
		{
			if (_defaultUpdateSourceTrigger != 0)
			{
				return _defaultUpdateSourceTrigger;
			}
			return UpdateSourceTrigger.PropertyChanged;
		}
		private set
		{
			_defaultUpdateSourceTrigger = value;
			_isDefaultUpdateSourceTriggerSet = true;
		}
	}

	internal bool IsLogicalChild
	{
		get
		{
			return Options.HasLogicalChild();
		}
		set
		{
			Options = (value ? (Options |= FrameworkPropertyMetadataOptions.LogicalChild) : (Options &= ~FrameworkPropertyMetadataOptions.LogicalChild));
		}
	}

	public bool HasWeakStorage
	{
		get
		{
			return Options.HasWeakStorage();
		}
		set
		{
			Options = (value ? (Options |= FrameworkPropertyMetadataOptions.WeakStorage) : (Options &= ~FrameworkPropertyMetadataOptions.WeakStorage));
		}
	}

	public FrameworkPropertyMetadata(object defaultValue)
		: base(defaultValue)
	{
	}

	public FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options)
		: base(defaultValue)
	{
		Options = options.WithDefault();
	}

	public FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options, PropertyChangedCallback propertyChangedCallback)
		: base(defaultValue, propertyChangedCallback)
	{
		Options = options.WithDefault();
	}

	internal FrameworkPropertyMetadata(PropertyChangedCallback propertyChangedCallback)
		: base(null, propertyChangedCallback)
	{
	}

	internal FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options, PropertyChangedCallback propertyChangedCallback, BackingFieldUpdateCallback backingFieldUpdateCallback)
		: base(defaultValue, propertyChangedCallback, backingFieldUpdateCallback)
	{
		Options = options.WithDefault();
	}

	internal FrameworkPropertyMetadata(object defaultValue, BackingFieldUpdateCallback backingFieldUpdateCallback)
		: base(defaultValue, null, backingFieldUpdateCallback)
	{
	}

	internal FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options, BackingFieldUpdateCallback backingFieldUpdateCallback)
		: base(defaultValue, null, backingFieldUpdateCallback)
	{
		Options = options.WithDefault();
	}

	internal FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
		: base(defaultValue, propertyChangedCallback, coerceValueCallback, null)
	{
		Options = options.WithDefault();
	}

	internal FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, BackingFieldUpdateCallback backingFieldUpdateCallback)
		: base(defaultValue, propertyChangedCallback, coerceValueCallback, backingFieldUpdateCallback)
	{
		Options = options.WithDefault();
	}

	internal FrameworkPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
		: base(defaultValue, propertyChangedCallback)
	{
	}

	internal FrameworkPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, BackingFieldUpdateCallback backingFieldUpdateCallback)
		: base(defaultValue, propertyChangedCallback, backingFieldUpdateCallback)
	{
	}

	internal FrameworkPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
		: base(defaultValue, propertyChangedCallback, coerceValueCallback, null)
	{
	}

	internal FrameworkPropertyMetadata(PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
		: base(propertyChangedCallback, coerceValueCallback)
	{
	}

	internal FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options, BackingFieldUpdateCallback backingFieldUpdateCallback, CoerceValueCallback coerceValueCallback)
		: base(defaultValue, null, coerceValueCallback, backingFieldUpdateCallback)
	{
		Options = options.WithDefault();
	}

	internal FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions options, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, UpdateSourceTrigger defaultUpdateSourceTrigger)
		: base(defaultValue, propertyChangedCallback, coerceValueCallback, null)
	{
		Options = options.WithDefault();
		DefaultUpdateSourceTrigger = defaultUpdateSourceTrigger;
	}

	protected internal override void Merge(PropertyMetadata baseMetadata, DependencyProperty dp)
	{
		base.Merge(baseMetadata, dp);
		if (baseMetadata is FrameworkPropertyMetadata frameworkPropertyMetadata)
		{
			if (!_isDefaultUpdateSourceTriggerSet)
			{
				DefaultUpdateSourceTrigger = frameworkPropertyMetadata.DefaultUpdateSourceTrigger;
			}
			Options |= frameworkPropertyMetadata.Options;
		}
	}
}

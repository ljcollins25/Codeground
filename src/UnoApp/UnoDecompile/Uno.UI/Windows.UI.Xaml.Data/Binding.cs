using System;
using System.ComponentModel;

namespace Windows.UI.Xaml.Data;

public class Binding : BindingBase
{
	private WeakReference _weakSource;

	private object _source;

	public PropertyPath Path { get; set; }

	public IValueConverter Converter { get; set; }

	public object ConverterParameter { get; set; }

	public string ConverterLanguage { get; set; }

	public object ElementName { get; set; }

	public object FallbackValue { get; set; }

	public BindingMode Mode { get; set; }

	public RelativeSource RelativeSource { get; set; }

	public object Source
	{
		get
		{
			return _weakSource?.Target ?? _source;
		}
		set
		{
			if (value != null)
			{
				_weakSource = null;
				_source = value;
			}
			else
			{
				_weakSource = null;
				_source = null;
			}
		}
	}

	public object TargetNullValue { get; set; }

	public UpdateSourceTrigger UpdateSourceTrigger { get; set; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object CompiledSource { get; set; }

	internal Func<object, object> XBindSelector { get; private set; }

	internal Action<object, object> XBindBack { get; private set; }

	internal string[] XBindPropertyPaths { get; private set; }

	public Binding()
	{
	}

	internal Binding(PropertyPath path = null, IValueConverter converter = null, object converterParameter = null)
	{
		Path = path ?? new PropertyPath(string.Empty);
		Converter = converter;
		ConverterParameter = converterParameter;
		Mode = BindingMode.OneWay;
	}

	public static implicit operator Binding(string path)
	{
		return new Binding(path);
	}

	internal void SetBindingXBindProvider(object compiledSource, Func<object, object> xBindSelector, Action<object, object> xBindBack, string[] propertyPaths = null)
	{
		CompiledSource = compiledSource;
		XBindSelector = xBindSelector;
		XBindPropertyPaths = propertyPaths;
		XBindBack = xBindBack;
	}
}

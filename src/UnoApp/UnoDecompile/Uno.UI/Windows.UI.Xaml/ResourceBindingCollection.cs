using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

internal class ResourceBindingCollection
{
	private readonly Dictionary<DependencyProperty, Dictionary<DependencyPropertyValuePrecedences, ResourceBinding>> _bindings = new Dictionary<DependencyProperty, Dictionary<DependencyPropertyValuePrecedences, ResourceBinding>>();

	public bool HasBindings
	{
		get
		{
			if (_bindings.Count > 0)
			{
				return _bindings.Any<KeyValuePair<DependencyProperty, Dictionary<DependencyPropertyValuePrecedences, ResourceBinding>>>((KeyValuePair<DependencyProperty, Dictionary<DependencyPropertyValuePrecedences, ResourceBinding>> b) => b.Value.Any());
			}
			return false;
		}
	}

	public IEnumerable<(DependencyProperty Property, ResourceBinding Binding)> GetAllBindings()
	{
		foreach (KeyValuePair<DependencyProperty, Dictionary<DependencyPropertyValuePrecedences, ResourceBinding>> kvp in _bindings)
		{
			using Dictionary<DependencyPropertyValuePrecedences, ResourceBinding>.Enumerator enumerator2 = kvp.Value.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				yield return new ValueTuple<DependencyProperty, ResourceBinding>(item2: enumerator2.Current.Value, item1: kvp.Key);
			}
		}
	}

	public IEnumerable<ResourceBinding>? GetBindingsForProperty(DependencyProperty property)
	{
		if (_bindings.TryGetValue(property, out var value))
		{
			return value.Values;
		}
		return null;
	}

	public void Add(DependencyProperty property, ResourceBinding resourceBinding)
	{
		Dictionary<DependencyPropertyValuePrecedences, ResourceBinding> dictionary = _bindings.FindOrCreate(property, () => new Dictionary<DependencyPropertyValuePrecedences, ResourceBinding>());
		dictionary[resourceBinding.Precedence] = resourceBinding;
	}

	public void ClearBinding(DependencyProperty property, DependencyPropertyValuePrecedences precedence)
	{
		if (_bindings.TryGetValue(property, out var value))
		{
			value.Remove(precedence);
		}
	}
}

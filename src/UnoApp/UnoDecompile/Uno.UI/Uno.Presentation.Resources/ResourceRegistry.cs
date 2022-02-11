using System;
using System.Collections.Generic;
using Uno.Extensions;

namespace Uno.Presentation.Resources;

public class ResourceRegistry : IResourceRegistry
{
	public delegate object ResourceLookupHandler(string resourceName);

	private object _gate = new object();

	private readonly Dictionary<object, Func<object>> _resources = new Dictionary<object, Func<object>>();

	private List<ResourceLookupHandler> _lookups = new List<ResourceLookupHandler>();

	public void RegisteLookup(ResourceLookupHandler resourceLookup)
	{
		_lookups.Add(resourceLookup);
	}

	public void Register(object name, Func<object> builder)
	{
		lock (_gate)
		{
			_resources[name] = builder.AsMemoized();
		}
	}

	public object FindResource(string name)
	{
		lock (_gate)
		{
			object obj = _resources.UnoGetValueOrDefault(name, () => null)();
			if (obj == null)
			{
				obj = LookupExternalResouce(name);
			}
			return obj;
		}
	}

	private object LookupExternalResouce(string name)
	{
		foreach (ResourceLookupHandler lookup in _lookups)
		{
			object obj = lookup(name);
			if (obj != null)
			{
				return obj;
			}
		}
		return null;
	}

	public object GetResource(string name)
	{
		lock (_gate)
		{
			if (_resources.TryGetValue(name, out var value))
			{
				return value();
			}
			object obj = LookupExternalResouce(name);
			if (obj != null)
			{
				return obj;
			}
			throw new KeyNotFoundException("Cannot find resource with key '{0}'.".InvariantCultureFormat(name));
		}
	}
}

using System.Collections.Generic;
using System.Collections.Immutable;
using Uno.UI.DataBinding;

namespace Windows.UI.Xaml;

internal class XamlScope
{
	private readonly ImmutableStack<ManagedWeakReference> _resourceSources;

	public IEnumerable<ManagedWeakReference> Sources => _resourceSources;

	private XamlScope(ImmutableStack<ManagedWeakReference> sources)
	{
		_resourceSources = sources;
	}

	public XamlScope Push(ManagedWeakReference source)
	{
		return new XamlScope(_resourceSources.Push(source));
	}

	public XamlScope Pop()
	{
		return new XamlScope(_resourceSources.Pop());
	}

	public static XamlScope Create()
	{
		return new XamlScope(ImmutableStack.Create<ManagedWeakReference>());
	}
}

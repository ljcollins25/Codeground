using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Core;

internal class ContentRootCoordinator
{
	private readonly CoreServices _coreServices;

	private readonly List<ContentRoot> _contentRoots = new List<ContentRoot>();

	public IReadOnlyList<ContentRoot> ContentRoots => _contentRoots;

	public ContentRoot? CoreWindowContentRoot { get; set; }

	public ContentRootCoordinator(CoreServices coreServices)
	{
		_coreServices = coreServices ?? throw new ArgumentNullException("coreServices");
	}

	public ContentRoot CreateContentRoot(ContentRootType type, Color backgroundColor, UIElement? rootElement)
	{
		ContentRoot contentRoot = new ContentRoot(type, backgroundColor, rootElement, _coreServices);
		_contentRoots.Add(contentRoot);
		return contentRoot;
	}

	public void RemoveContentRoot(ContentRoot contentRoot)
	{
		_contentRoots.Remove(contentRoot);
	}
}

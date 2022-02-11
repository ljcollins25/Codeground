using System;
using Uno.UI.Xaml.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Core;

internal class ContentRoot
{
	private readonly CoreServices _coreServices;

	internal ContentRootType Type { get; }

	internal VisualTree VisualTree { get; }

	internal FocusManager FocusManager { get; }

	internal InputManager InputManager { get; }

	internal FocusAdapter FocusAdapter { get; }

	internal AccessKeyExport AccessKeyExport { get; } = new AccessKeyExport();


	internal XamlRoot? XamlRoot => VisualTree.XamlRoot;

	public ContentRoot(ContentRootType type, Color backgroundColor, UIElement? rootElement, CoreServices coreServices)
	{
		_coreServices = coreServices ?? throw new ArgumentNullException("coreServices");
		VisualTree = new VisualTree(coreServices, backgroundColor, rootElement, this);
		FocusManager = new FocusManager(this);
		InputManager = new InputManager(this);
		FocusAdapter = new FocusAdapter(this);
		FocusManager.SetFocusObserver(new FocusObserver(this));
		if (type == ContentRootType.CoreWindow)
		{
			coreServices.ContentRootCoordinator.CoreWindowContentRoot = this;
		}
	}

	internal bool IsShuttingDown()
	{
		return false;
	}

	internal XamlRoot GetOrCreateXamlRoot()
	{
		return VisualTree.GetOrCreateXamlRoot();
	}
}

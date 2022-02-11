using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Uno.UI.Xaml.Core;

internal class CoreServices
{
	private static Lazy<CoreServices> _instance = new Lazy<CoreServices>(() => new CoreServices());

	private VisualTree? _mainVisualTree;

	public static CoreServices Instance => _instance.Value;

	public ContentRootCoordinator ContentRootCoordinator { get; }

	public InitializationType InitializationType { get; private set; } = InitializationType.MainView;


	public RootVisual? MainRootVisual => _mainVisualTree?.RootVisual;

	public PopupRoot? MainPopupRoot => _mainVisualTree?.PopupRoot;

	public Canvas? MainFocusVisualRoot => _mainVisualTree?.FocusVisualRoot;

	public FullWindowMediaRoot? MainFullWindowMediaRoot => _mainVisualTree?.FullWindowMediaRoot;

	public DependencyObject? VisualRoot => _mainVisualTree?.PublicRootVisual;

	public CoreServices()
	{
		ContentRootCoordinator = new ContentRootCoordinator(this);
	}

	private void ResetCoreWindowVisualTree()
	{
		_mainVisualTree = null;
	}

	internal void PutVisualRoot(DependencyObject? dependencyObject)
	{
		ResetCoreWindowVisualTree();
		InitCoreWindowContentRoot();
		if (dependencyObject != null)
		{
			UIElement publicRootVisual = dependencyObject as UIElement;
			_mainVisualTree!.SetPublicRootVisual(publicRootVisual, null, null);
		}
	}

	private void InitCoreWindowContentRoot()
	{
		ContentRoot contentRoot = ContentRootCoordinator.CreateContentRoot(ContentRootType.CoreWindow, Colors.Transparent, null);
		_mainVisualTree = contentRoot.VisualTree;
	}

	[NotImplemented]
	internal void UIARaiseFocusChangedEventOnUIAWindow(DependencyObject sender)
	{
	}
}

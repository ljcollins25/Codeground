using System;
using Uno.Foundation.Logging;
using Uno.UI.Extensions;
using Uno.UI.Xaml.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Core;

internal class VisualTree
{
	internal enum LookupOptions
	{
		NoFallback,
		WarningIfNotFound
	}

	private const int VisualDiagnosticsRootZIndex = 2147483546;

	private const int ConnectedAnimationRootZIndex = 2147483545;

	private const int PopupZIndex = 2147483544;

	private const int FullWindowMediaRootZIndex = 2147483543;

	private const int TransitionRootZIndex = 2147483542;

	private readonly CoreServices _coreServices;

	private readonly UnoFocusInputHandler? _focusInputHandler;

	private const int UnoTopZIndex = 2147483547;

	private const int FocusVisualZIndex = 2147483548;

	internal UnoFocusInputHandler? UnoFocusInputHandler => _focusInputHandler;

	public ContentRoot ContentRoot { get; }

	public RootVisual? RootVisual { get; private set; }

	public PopupRoot? PopupRoot { get; private set; }

	public FullWindowMediaRoot? FullWindowMediaRoot { get; private set; }

	public UIElement? PublicRootVisual { get; private set; }

	public ScrollViewer? RootScrollViewer { get; private set; }

	public ContentPresenter? RootContentPresenter { get; private set; }

	public UIElement RootElement { get; }

	public XamlRoot? XamlRoot { get; private set; }

	public DependencyObject? ActiveRootVisual
	{
		get
		{
			UIElement uIElement = FullWindowMediaRoot;
			if (uIElement != null && uIElement != null)
			{
				UIElement uIElement2 = uIElement;
				if (uIElement2.Visibility == Visibility.Collapsed)
				{
					uIElement = null;
				}
			}
			if (uIElement == null)
			{
				uIElement = PublicRootVisual;
			}
			return uIElement;
		}
	}

	public Canvas? FocusVisualRoot { get; private set; }

	public VisualTree(CoreServices coreServices, Color backgroundColor, UIElement? rootElement, ContentRoot contentRoot)
	{
		_coreServices = coreServices ?? throw new ArgumentNullException("coreServices");
		ContentRoot = contentRoot ?? throw new ArgumentNullException("contentRoot");
		if (rootElement != null)
		{
			RootElement = rootElement;
			return;
		}
		RootVisual = new RootVisual(coreServices);
		RootVisual!.AssociatedVisualTree = this;
		RootVisual!.SetBackgroundColor(backgroundColor);
		RootElement = RootVisual;
		_focusInputHandler = new UnoFocusInputHandler(RootVisual);
	}

	private void EnsureFullWindowMediaRoot()
	{
		if (FullWindowMediaRoot == null)
		{
			FullWindowMediaRoot = new FullWindowMediaRoot();
			Canvas.SetZIndex(FullWindowMediaRoot, 2147483543);
		}
	}

	private void EnsurePopupRoot()
	{
		if (PopupRoot == null)
		{
			PopupRoot = new PopupRoot();
			Canvas.SetZIndex(PopupRoot, 2147483544);
		}
	}

	internal void SetPublicRootVisual(UIElement? publicRootVisual, ScrollViewer? rootScrollViewer, ContentPresenter? rootContentPresenter)
	{
		if (publicRootVisual != PublicRootVisual)
		{
			ResetRoots();
			PublicRootVisual = publicRootVisual;
			RootScrollViewer = rootScrollViewer;
			RootContentPresenter = rootContentPresenter;
			EnsurePopupRoot();
			EnsureFocusVisualRoot();
			EnsureFullWindowMediaRoot();
			if (PublicRootVisual != null && RootScrollViewer == null)
			{
				AddRoot(PublicRootVisual);
			}
			AddRoot(FullWindowMediaRoot);
			AddRoot(PopupRoot);
			AddRoot(FocusVisualRoot);
		}
	}

	[NotImplemented]
	public static PopupRoot? GetPopupRootForElement(DependencyObject dependencyObject)
	{
		return null;
	}

	internal static RootVisual? GetRootForElement(DependencyObject? pObject)
	{
		return pObject?.GetContext().MainRootVisual;
	}

	internal static FocusManager? GetFocusManagerForElement(DependencyObject? dependencyObject, LookupOptions options = LookupOptions.WarningIfNotFound)
	{
		ContentRoot contentRootForElement = GetContentRootForElement(dependencyObject, options);
		if (contentRootForElement != null)
		{
			return contentRootForElement.FocusManager;
		}
		return (dependencyObject?.GetContext().ContentRootCoordinator.CoreWindowContentRoot)?.FocusManager;
	}

	internal static ContentRoot? GetContentRootForElement(DependencyObject? dependencyObject, LookupOptions options = LookupOptions.WarningIfNotFound)
	{
		VisualTree forElement = GetForElement(dependencyObject, options);
		if (forElement != null)
		{
			return forElement.ContentRoot;
		}
		ContentRoot contentRoot = dependencyObject?.GetContext().ContentRootCoordinator.CoreWindowContentRoot;
		if (contentRoot != null)
		{
			return contentRoot;
		}
		return null;
	}

	private void AddRoot(UIElement? root)
	{
		if (root != null)
		{
			RootElement.AddChild(root);
		}
	}

	[NotImplemented]
	private bool ResetRoots()
	{
		return true;
	}

	[NotImplemented]
	internal bool IsBehindFullWindowMediaRoot(DependencyObject? focusedElement)
	{
		return false;
	}

	[NotImplemented]
	private void RemoveRoot(UIElement root)
	{
	}

	[NotImplemented]
	private static UIElement? GetXamlIslandRootForElement(DependencyObject? pObject)
	{
		return null;
	}

	internal static VisualTree? GetForElement(DependencyObject? element, LookupOptions options = LookupOptions.WarningIfNotFound)
	{
		if (element == null)
		{
			return null;
		}
		VisualTree visualTree = element.GetVisualTree();
		if (visualTree != null)
		{
			return visualTree;
		}
		VisualTree visualTreeViaTreeWalk = GetVisualTreeViaTreeWalk(element, options);
		if (visualTreeViaTreeWalk != null)
		{
			element.SetVisualTree(visualTreeViaTreeWalk);
		}
		return visualTreeViaTreeWalk;
	}

	internal static VisualTree? GetVisualTreeViaTreeWalk(DependencyObject element, LookupOptions options)
	{
		VisualTree visualTree = null;
		int num = 1000;
		while (element != null && num != 0)
		{
			num--;
			VisualTree visualTree2 = element.GetVisualTree();
			if (visualTree2 != null)
			{
				return visualTree2;
			}
			if (element is RootVisual rootVisual)
			{
				return rootVisual.AssociatedVisualTree;
			}
		}
		if (visualTree == null && options == LookupOptions.WarningIfNotFound)
		{
			VisualTreeNotFoundWarning();
		}
		return visualTree;
	}

	internal static UIElement? GetRootOrIslandForElement(DependencyObject? element)
	{
		UIElement xamlIslandRootForElement = GetXamlIslandRootForElement(element);
		if (xamlIslandRootForElement == null)
		{
			return GetRootForElement(element);
		}
		return xamlIslandRootForElement;
	}

	internal XamlRoot GetOrCreateXamlRoot()
	{
		if (XamlRoot == null)
		{
			XamlRoot = Windows.UI.Xaml.XamlRoot.Current;
		}
		return XamlRoot;
	}

	private static void VisualTreeNotFoundWarning()
	{
		if (typeof(VisualTree).Log().IsEnabled(LogLevel.Debug))
		{
			typeof(VisualTree).Log().LogDebug("Visual Tree was not found.");
		}
	}

	public void EnsureFocusVisualRoot()
	{
		if (FocusVisualRoot == null)
		{
			FocusVisualRoot = new Canvas
			{
				Background = null,
				IsHitTestVisible = false
			};
			Canvas.SetZIndex(FocusVisualRoot, 2147483548);
		}
	}
}

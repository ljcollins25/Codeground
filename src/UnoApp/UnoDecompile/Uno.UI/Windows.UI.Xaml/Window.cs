using System;
using System.Collections.Generic;
using System.Diagnostics;
using Uno;
using Uno.Disposables;
using Uno.Foundation;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.Xaml.Core;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml;

public sealed class Window
{
	private CoreWindowActivationState? _lastActivationState;

	private List<WeakEventHelper.GenericEventHandler> _sizeChangedHandlers = new List<WeakEventHelper.GenericEventHandler>();

	private DragRoot _dragRoot;

	private static Window _current;

	private RootVisual _rootVisual;

	private ScrollViewer _rootScrollViewer;

	private Border _rootBorder;

	private UIElement _content;

	private bool _invalidateRequested;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Compositor Compositor
	{
		get
		{
			throw new NotImplementedException("The member Compositor Window.Compositor is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIContext UIContext
	{
		get
		{
			throw new NotImplementedException("The member UIContext Window.UIContext is not implemented in Uno.");
		}
	}

	public UIElement Content
	{
		get
		{
			return InternalGetContent();
		}
		set
		{
			if (Content == value)
			{
				return;
			}
			UIElement content = Content;
			if (content != null)
			{
				content.IsWindowRoot = false;
				if (content is FrameworkElement frameworkElement)
				{
					frameworkElement.SizeChanged -= RootSizeChanged;
				}
			}
			if (value != null)
			{
				value.IsWindowRoot = true;
			}
			InternalSetContent(value);
			if (value is FrameworkElement frameworkElement2)
			{
				frameworkElement2.SizeChanged += RootSizeChanged;
			}
			XamlRoot.Current.NotifyChanged();
		}
	}

	internal UIElement RootElement => InternalGetRootElement();

	internal PopupRoot PopupRoot => CoreServices.Instance.MainPopupRoot;

	internal FullWindowMediaRoot FullWindowMediaRoot => CoreServices.Instance.MainFullWindowMediaRoot;

	internal Canvas FocusVisualLayer => CoreServices.Instance.MainFocusVisualRoot;

	public Rect Bounds { get; private set; }

	public CoreWindow CoreWindow { get; private set; }

	public CoreDispatcher Dispatcher { get; private set; }

	public bool Visible
	{
		get
		{
			return CoreWindow.Visible;
		}
		set
		{
			CoreWindow.Visible = value;
		}
	}

	public static Window Current => InternalGetCurrentWindow();

	internal DragDropManager DragDrop { get; private set; }

	public event WindowActivatedEventHandler Activated;

	public event WindowClosedEventHandler Closed;

	public event WindowSizeChangedEventHandler SizeChanged;

	public event WindowVisibilityChangedEventHandler VisibilityChanged;

	private void InitializeCommon()
	{
		InitDragAndDrop();
		if (Application.Current != null)
		{
			Application.Current.RaiseWindowCreated(this);
		}
		else if (this.Log().IsEnabled(LogLevel.Warning))
		{
			this.Log().Warn("Unable to raise WindowCreatedEvent, there is no active Application");
		}
	}

	public void Activate()
	{
		InternalActivate();
		OnActivated(CoreWindowActivationState.CodeActivated);
		Visible = true;
	}

	private void InternalActivate()
	{
		WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.activate();");
	}

	public void Close()
	{
	}

	public void SetTitleBar(UIElement value)
	{
	}

	internal IDisposable RegisterSizeChangedEvent(WindowSizeChangedEventHandler handler)
	{
		return WeakEventHelper.RegisterEvent(_sizeChangedHandlers, handler, delegate(Delegate h, object s, object e)
		{
			(h as WindowSizeChangedEventHandler)?.Invoke(s, (WindowSizeChangedEventArgs)e);
		});
	}

	internal void OnActivated(CoreWindowActivationState state)
	{
		if (_lastActivationState != state)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Window activating with {state} state.");
			}
			_lastActivationState = state;
			WindowActivatedEventArgs windowActivatedEventArgs = new WindowActivatedEventArgs(state);
			WindowActivatedEventArgs args = windowActivatedEventArgs;
			CoreWindow.OnActivated(args);
			this.Activated?.Invoke(this, windowActivatedEventArgs);
		}
	}

	internal void OnVisibilityChanged(bool newVisibility)
	{
		if (Visible != newVisibility)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Window visibility changing to {newVisibility}");
			}
			Visible = newVisibility;
			VisibilityChangedEventArgs visibilityChangedEventArgs = new VisibilityChangedEventArgs();
			CoreWindow.OnVisibilityChanged(visibilityChangedEventArgs);
			this.VisibilityChanged?.Invoke(this, visibilityChangedEventArgs);
		}
	}

	private void RootSizeChanged(object sender, SizeChangedEventArgs args)
	{
		XamlRoot.Current.NotifyChanged();
	}

	private void RaiseSizeChanged(WindowSizeChangedEventArgs windowSizeChangedEventArgs)
	{
		WindowSizeChangedEventArgs windowSizeChangedEventArgs2 = new WindowSizeChangedEventArgs(windowSizeChangedEventArgs.Size)
		{
			Handled = windowSizeChangedEventArgs.Handled
		};
		this.SizeChanged?.Invoke(this, windowSizeChangedEventArgs2);
		windowSizeChangedEventArgs.Handled = windowSizeChangedEventArgs2.Handled;
		CoreWindow.GetForCurrentThread()?.OnSizeChanged(windowSizeChangedEventArgs);
		windowSizeChangedEventArgs2.Handled = windowSizeChangedEventArgs.Handled;
		foreach (WeakEventHelper.GenericEventHandler sizeChangedHandler in _sizeChangedHandlers)
		{
			sizeChangedHandler(this, windowSizeChangedEventArgs2);
		}
	}

	private void InitDragAndDrop()
	{
		CoreDragDropManager coreDragDropManager = CoreDragDropManager.CreateForCurrentView();
		DragDropManager dragDropManager2 = (DragDrop = new DragDropManager(this));
		DragDropManager uIManager = dragDropManager2;
		coreDragDropManager.SetUIManager(uIManager);
	}

	internal IDisposable OpenDragAndDrop(DragView dragView)
	{
		RootVisual rootElement = _rootVisual;
		if (rootElement == null)
		{
			return Disposable.Empty;
		}
		if (_dragRoot == null)
		{
			_dragRoot = new DragRoot();
			rootElement.Children.Add(_dragRoot);
		}
		_dragRoot.Show(dragView);
		return Disposable.Create(Remove);
		void Remove()
		{
			_dragRoot.Hide(dragView);
			if (_dragRoot.PendingDragCount == 0)
			{
				rootElement.Children.Remove(_dragRoot);
				_dragRoot = null;
			}
		}
	}

	public Window()
	{
		Init();
		InitializeCommon();
	}

	private void Init()
	{
		Dispatcher = CoreDispatcher.Main;
		CoreWindow = new CoreWindow();
	}

	internal static void InvalidateMeasure()
	{
		Current?.InnerInvalidateMeasure();
	}

	private void InnerInvalidateMeasure()
	{
		if (!_invalidateRequested)
		{
			_invalidateRequested = true;
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("DispatchInvalidateMeasure scheduled");
			}
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				_invalidateRequested = false;
				Current?.DispatchInvalidateMeasure();
			});
		}
	}

	private void DispatchInvalidateMeasure()
	{
		if (_rootVisual != null)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			_rootVisual.Measure(Bounds.Size);
			_rootVisual.Arrange(Bounds);
			stopwatch.Stop();
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"DispatchInvalidateMeasure: {stopwatch.Elapsed}");
			}
		}
	}

	[Preserve]
	public static void Resize(double width, double height)
	{
		RootVisual rootVisual = Current?._rootVisual;
		if (rootVisual == null)
		{
			typeof(Window).Log().Error("Resize ignore, no current window defined");
		}
		else
		{
			Current.OnNativeSizeChanged(new Size(width, height));
		}
	}

	private void OnNativeSizeChanged(Size size)
	{
		Rect rect = new Rect(0.0, 0.0, size.Width, size.Height);
		if (rect != Bounds)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"OnNativeSizeChanged: {size}");
			}
			Bounds = rect;
			DispatchInvalidateMeasure();
			RaiseSizeChanged(new WindowSizeChangedEventArgs(size));
			ApplicationView.GetForCurrentView()?.SetVisibleBounds(rect);
		}
	}

	private void InternalSetContent(UIElement content)
	{
		if (_rootVisual == null)
		{
			_rootBorder = new Border();
			_rootScrollViewer = new ScrollViewer
			{
				VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
				VerticalScrollMode = ScrollMode.Disabled,
				HorizontalScrollMode = ScrollMode.Disabled,
				Content = _rootBorder
			};
			CoreServices.Instance.PutVisualRoot(_rootScrollViewer);
			_rootVisual = CoreServices.Instance.MainRootVisual;
			if (_rootVisual == null)
			{
				throw new InvalidOperationException("The root visual could not be created.");
			}
		}
		_rootBorder.Child = (_content = content);
		if (content != null)
		{
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded && !_rootVisual.IsLoaded)
			{
				UIElement.LoadingRootElement(_rootVisual);
			}
			WebAssemblyRuntime.InvokeJS($"Uno.UI.WindowManager.current.setRootContent({_rootVisual.HtmlId});");
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded && !_rootVisual.IsLoaded)
			{
				UIElement.RootElementLoaded(_rootVisual);
			}
		}
		else
		{
			WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.setRootContent();");
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded && _rootVisual.IsLoaded)
			{
				UIElement.RootElementUnloaded(_rootVisual);
			}
		}
		UpdateRootAttributes();
	}

	private UIElement InternalGetContent()
	{
		return _content;
	}

	private UIElement InternalGetRootElement()
	{
		return _rootVisual;
	}

	private static Window InternalGetCurrentWindow()
	{
		if (_current == null)
		{
			_current = new Window();
		}
		return _current;
	}

	internal void UpdateRootAttributes()
	{
		if (_rootVisual == null)
		{
			throw new InvalidOperationException("Internal window root is not yet set.");
		}
		if (FeatureConfiguration.Cursors.UseHandForInteraction)
		{
			_rootVisual.SetAttribute("data-use-hand-cursor-interaction", "true");
		}
		else
		{
			_rootVisual.RemoveAttribute("data-use-hand-cursor-interaction");
		}
	}

	internal IDisposable OpenPopup(Popup popup)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug("Creating popup");
		}
		if (PopupRoot == null)
		{
			throw new InvalidOperationException("PopupRoot is not initialized yet.");
		}
		PopupPanel popupPanel = popup.PopupPanel;
		PopupRoot.Children.Add(popupPanel);
		return new CompositeDisposable(Disposable.Create(delegate
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Closing popup");
			}
			PopupRoot.Children.Remove(popupPanel);
		}), VisualTreeHelper.RegisterOpenPopup(popup));
	}
}

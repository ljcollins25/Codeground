using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.Extensions;
using Uno.Foundation;
using Uno.Foundation.Extensibility;
using Uno.Foundation.Logging;
using Uno.Helpers;
using Uno.Helpers.Theming;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml;

public class Application
{
	[Preserve]
	public static class TraceProvider
	{
		public static readonly Guid Id;

		public const int LauchedStart = 1;

		public const int LauchedStop = 2;

		static TraceProvider()
		{
			Id = new Guid(-555714779, 7359, 19446, new byte[8] { 172, 138, 150, 3, 96, 203, 53, 18 });
		}
	}

	private Dictionary<string, string> _loadableComponents;

	private bool _initializationComplete;

	private static readonly IEventProvider _trace;

	private bool _themeSetExplicitly;

	private ApplicationTheme? _requestedTheme;

	private bool _systemThemeChangesObserved;

	private SpecializedResourceDictionary.ResourceKey _requestedThemeForResources;

	private bool _isInBackground;

	private static bool _startInvoked;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ApplicationHighContrastAdjustment HighContrastAdjustment
	{
		get
		{
			throw new NotImplementedException("The member ApplicationHighContrastAdjustment Application.HighContrastAdjustment is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "ApplicationHighContrastAdjustment Application.HighContrastAdjustment");
		}
	}

	public static Application Current { get; private set; }

	public DebugSettings DebugSettings { get; } = new DebugSettings();


	public ApplicationRequiresPointerMode RequiresPointerMode { get; set; }

	public FocusVisualKind FocusVisualKind { get; set; } = FocusVisualKind.HighVisibility;


	public ApplicationTheme RequestedTheme
	{
		get
		{
			EnsureInternalRequestedTheme();
			return InternalRequestedTheme.Value;
		}
		set
		{
			if (_initializationComplete)
			{
				throw new NotSupportedException("Operation not supported");
			}
			SetExplicitRequestedTheme(value);
		}
	}

	private ApplicationTheme? InternalRequestedTheme
	{
		get
		{
			return _requestedTheme;
		}
		set
		{
			_requestedTheme = value;
			CoreApplication.RequestedTheme = ((value == ApplicationTheme.Dark) ? SystemTheme.Dark : SystemTheme.Light);
			UpdateRequestedThemesForResources();
		}
	}

	internal SpecializedResourceDictionary.ResourceKey RequestedThemeForResources
	{
		get
		{
			EnsureInternalRequestedTheme();
			return _requestedThemeForResources;
		}
		private set
		{
			_requestedThemeForResources = value;
			ResourceDictionary.SetActiveTheme(value);
		}
	}

	internal ElementTheme ActualElementTheme => RequestedTheme switch
	{
		ApplicationTheme.Dark => ElementTheme.Dark, 
		ApplicationTheme.Light => ElementTheme.Light, 
		_ => throw new InvalidOperationException("Application's RequestedTheme is invalid."), 
	};

	public ResourceDictionary Resources { get; set; } = new ResourceDictionary();


	public event EventHandler<object> Resuming;

	public event SuspendingEventHandler Suspending;

	public event EnteredBackgroundEventHandler EnteredBackground;

	public event LeavingBackgroundEventHandler LeavingBackground;

	public event UnhandledExceptionEventHandler UnhandledException;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnFileActivated(FileActivatedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.OnFileActivated(FileActivatedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnSearchActivated(SearchActivatedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.OnSearchActivated(SearchActivatedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.OnShareTargetActivated(ShareTargetActivatedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnFileOpenPickerActivated(FileOpenPickerActivatedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.OnFileOpenPickerActivated(FileOpenPickerActivatedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnFileSavePickerActivated(FileSavePickerActivatedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.OnFileSavePickerActivated(FileSavePickerActivatedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnCachedFileUpdaterActivated(CachedFileUpdaterActivatedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.OnCachedFileUpdaterActivated(CachedFileUpdaterActivatedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnBackgroundActivated(BackgroundActivatedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.OnBackgroundActivated(BackgroundActivatedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void LoadComponent(object component, Uri resourceLocator, ComponentResourceLocation componentResourceLocation)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Application", "void Application.LoadComponent(object component, Uri resourceLocator, ComponentResourceLocation componentResourceLocation)");
	}

	internal bool IsLoadableComponent(Uri resource)
	{
		EnsureLoadableComponents();
		return _loadableComponents.ContainsKey(resource.OriginalString);
	}

	public static void LoadComponent(object component, Uri resourceLocator)
	{
		if (Current._loadableComponents.TryGetValue(resourceLocator.OriginalString, out var value))
		{
			XamlReader.LoadUsingComponent(value, component);
		}
	}

	internal static void RegisterComponent(Uri resourceLocator, string xaml)
	{
		Current._loadableComponents[resourceLocator.OriginalString] = xaml;
	}

	private void EnsureLoadableComponents()
	{
		if (_loadableComponents == null)
		{
			_loadableComponents = new Dictionary<string, string>();
		}
	}

	static Application()
	{
		_trace = Tracing.Get(TraceProvider.Id);
		_startInvoked = false;
		ApiInformation.RegisterAssembly(typeof(Application).Assembly);
		ApiInformation.RegisterAssembly(typeof(ApplicationData).Assembly);
		DispatcherTimerProxy.SetDispatcherTimerGetter(() => new DispatcherTimer());
		VisualTreeHelperProxy.SetCloseAllFlyoutsAction(delegate
		{
			VisualTreeHelper.CloseAllFlyouts();
		});
	}

	private void EnsureInternalRequestedTheme()
	{
		if (!InternalRequestedTheme.HasValue)
		{
			InternalRequestedTheme = GetDefaultSystemTheme();
		}
	}

	internal static void UpdateRequestedThemesForResources()
	{
		Application current = Current;
		string requestedCustomTheme = ApplicationHelper.RequestedCustomTheme;
		ApplicationTheme requestedTheme = Current.RequestedTheme;
		string text = ((!requestedCustomTheme.IsNullOrEmpty()) ? requestedCustomTheme : (requestedTheme switch
		{
			ApplicationTheme.Dark => "Dark", 
			ApplicationTheme.Light => "Light", 
			_ => throw new InvalidOperationException($"Theme {Current.RequestedTheme} is not valid"), 
		}));
		current.RequestedThemeForResources = text;
	}

	internal void SetExplicitRequestedTheme(ApplicationTheme? explicitTheme)
	{
		_themeSetExplicitly = explicitTheme.HasValue;
		ApplicationTheme requestedTheme = explicitTheme ?? GetDefaultSystemTheme();
		SetRequestedTheme(requestedTheme);
	}

	public void OnSystemThemeChanged()
	{
		if (!_themeSetExplicitly)
		{
			ApplicationTheme defaultSystemTheme = GetDefaultSystemTheme();
			SetRequestedTheme(defaultSystemTheme);
		}
		UISettings.OnColorValuesChanged();
	}

	[NotImplemented]
	public void Exit()
	{
		if (this.Log().IsEnabled(LogLevel.Warning))
		{
			this.Log().LogWarning("This platform does not support application exit.");
		}
	}

	public static void Start(ApplicationInitializationCallback callback)
	{
		StartPartial(callback);
	}

	private void ObserveSystemThemeChanges()
	{
		WebAssemblyRuntime.InvokeJS("Windows.UI.Xaml.Application.observeSystemTheme()");
	}

	private static void StartPartial(ApplicationInitializationCallback callback)
	{
		Console.WriteLine("StartPartial 1");
		_startInvoked = true;
		Console.WriteLine("StartPartial 1");
		bool isHostedMode = !WebAssemblyRuntime.IsWebAssembly;
		Console.WriteLine("StartPartial 1");
		bool isLoadEventsEnabled = !FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded;
		Console.WriteLine("StartPartial 1");
		WindowManagerInterop.Init(isHostedMode, isLoadEventsEnabled);
		Console.WriteLine("StartPartial 1");
		ApplicationData.Init();
		Console.WriteLine("StartPartial 1");
		SynchronizationContext.SetSynchronizationContext(new CoreDispatcherSynchronizationContext(CoreDispatcher.Main, CoreDispatcherPriority.Normal));
		Console.WriteLine("StartPartial 1");
		callback(new ApplicationInitializationCallbackParams());
	}

	protected internal virtual void OnActivated(IActivatedEventArgs args)
	{
	}

	protected internal virtual void OnLaunched(LaunchActivatedEventArgs args)
	{
	}

	internal void InitializationCompleted()
	{
		if (!_systemThemeChangesObserved)
		{
			ObserveSystemThemeChanges();
		}
		_initializationComplete = true;
	}

	internal void RaiseRecoverableUnhandledException(Exception e)
	{
		this.UnhandledException?.Invoke(this, new UnhandledExceptionEventArgs(e, fatal: false));
	}

	private ApplicationTheme GetDefaultSystemTheme()
	{
		if (SystemThemeHelper.SystemTheme != 0)
		{
			return ApplicationTheme.Dark;
		}
		return ApplicationTheme.Light;
	}

	private IDisposable WritePhaseEventTrace(int startEventId, int stopEventId)
	{
		if (_trace.IsEnabled)
		{
			return _trace.WriteEventActivity(startEventId, stopEventId, new object[0]);
		}
		return null;
	}

	internal void OnEnteredBackground()
	{
		if (!_isInBackground)
		{
			_isInBackground = true;
			this.EnteredBackground?.Invoke(this, new EnteredBackgroundEventArgs());
		}
	}

	internal void OnLeavingBackground()
	{
		if (_isInBackground)
		{
			_isInBackground = false;
			this.LeavingBackground?.Invoke(this, new LeavingBackgroundEventArgs());
		}
	}

	internal void OnResuming()
	{
		CoreApplication.RaiseResuming();
	}

	internal void OnSuspending()
	{
		CoreApplication.RaiseSuspending(new SuspendingEventArgs(new SuspendingOperation(DateTime.Now.AddSeconds(30.0))));
		OnSuspendingPartial();
	}

	private void OnSuspendingPartial()
	{
		bool completed = false;
		SuspendingOperation suspendingOperation = new SuspendingOperation(DateTime.Now.AddSeconds(0.0), delegate
		{
			completed = true;
		});
		this.Suspending?.Invoke(this, new SuspendingEventArgs(suspendingOperation));
		suspendingOperation.EventRaiseCompleted();
		if (!completed && this.Log().IsEnabled(LogLevel.Warning))
		{
			this.Log().LogWarning("This platform does not support asynchronous Suspending deferral. Code executed after the of the method called by Suspending may not get executed.");
		}
	}

	protected virtual void OnWindowCreated(WindowCreatedEventArgs args)
	{
	}

	internal void RaiseWindowCreated(Window window)
	{
		OnWindowCreated(new WindowCreatedEventArgs(window));
	}

	private void SetRequestedTheme(ApplicationTheme requestedTheme)
	{
		if (requestedTheme != InternalRequestedTheme)
		{
			InternalRequestedTheme = requestedTheme;
			OnRequestedThemeChanged();
		}
	}

	internal void UpdateResourceBindingsForHotReload()
	{
		OnResourcesChanged(ResourceUpdateReason.HotReload);
	}

	private void OnRequestedThemeChanged()
	{
		OnResourcesChanged(ResourceUpdateReason.ThemeResource);
	}

	private void OnResourcesChanged(ResourceUpdateReason updateReason)
	{
		UIElement uIElement = OnResourcesChangedg__GetTreeRoot_96_0();
		if (uIElement != null)
		{
			Resources?.UpdateThemeBindings(updateReason);
			ResourceResolver.UpdateSystemThemeBindings(updateReason);
			PropagateResourcesChanged(uIElement, updateReason);
		}
	}

	internal static void PropagateResourcesChanged(object instance, ResourceUpdateReason updateReason)
	{
		if (instance is FrameworkElement frameworkElement)
		{
			frameworkElement.UpdateThemeBindings(updateReason);
		}
		if (instance is Panel panel)
		{
			{
				foreach (UIElement child in panel.Children)
				{
					PropagateResourcesChanged(child, updateReason);
				}
				return;
			}
		}
		if (!(instance is UIElement uIElement))
		{
			return;
		}
		foreach (UIElement child2 in uIElement.GetChildren())
		{
			PropagateResourcesChanged(child2, updateReason);
		}
	}

	public Application()
	{
		if (!_startInvoked)
		{
			throw new InvalidOperationException("The application must be started using Application.Start first, e.g. Windows.UI.Xaml.Application.Start(_ => new App());");
		}
		Current = this;
		Package.SetEntryAssembly(GetType().Assembly);
		ApiExtensibility.Register(typeof(IDragDropExtension), (object o) => DragDropExtension.GetForCurrentView());
		CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(Initialize));
		ObserveApplicationVisibility();
	}

	[Preserve]
	public static int DispatchSystemThemeChange()
	{
		Current.OnSystemThemeChanged();
		return 0;
	}

	[Preserve]
	public static int DispatchVisibilityChange(bool isVisible)
	{
		Application current = Current;
		Window current2 = Window.Current;
		if (isVisible)
		{
			current?.LeavingBackground?.Invoke(current, new LeavingBackgroundEventArgs());
			current2?.OnVisibilityChanged(newVisibility: true);
			current2?.OnActivated(CoreWindowActivationState.CodeActivated);
		}
		else
		{
			current2?.OnActivated(CoreWindowActivationState.Deactivated);
			current2?.OnVisibilityChanged(newVisibility: false);
			current?.EnteredBackground?.Invoke(current, new EnteredBackgroundEventArgs());
		}
		return 0;
	}

	private void Initialize()
	{
		using (WritePhaseEventTrace(1, 2))
		{
			Window.Current.ToString();
			string text = WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.findLaunchArguments()");
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Launch arguments: " + text);
			}
			InitializationCompleted();
			if (!string.IsNullOrEmpty(text) && ProtocolActivation.TryParseActivationUri(text, out var uri))
			{
				OnActivated(new ProtocolActivatedEventArgs(uri, ApplicationExecutionState.NotRunning));
			}
			else
			{
				OnLaunched(new LaunchActivatedEventArgs(ActivationKind.Launch, text));
			}
		}
	}

	internal static void DispatchSuspending()
	{
		Current?.OnSuspending();
	}

	private void ObserveApplicationVisibility()
	{
		WebAssemblyRuntime.InvokeJS("Windows.UI.Xaml.Application.observeVisibility()");
	}

	[CompilerGenerated]
	internal static UIElement OnResourcesChangedg__GetTreeRoot_96_0()
	{
		UIElement uIElement = Window.Current.Content;
		for (UIElement uIElement2 = uIElement?.GetVisualTreeParent(); uIElement2 != null; uIElement2 = uIElement?.GetVisualTreeParent())
		{
			uIElement = uIElement2;
		}
		return uIElement;
	}
}

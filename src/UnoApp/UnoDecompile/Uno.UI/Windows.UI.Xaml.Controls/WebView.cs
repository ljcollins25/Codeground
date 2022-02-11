using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Uno;
using Uno.Extensions;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Navigation;
using Windows.Web;
using Windows.Web.Http;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class WebView : Control
{
	private const string BlankUrl = "about:blank";

	private static readonly Uri BlankUri = new Uri("about:blank");

	private object _internalSource;

	private bool _isLoaded;

	private string _invokeScriptResponse = string.Empty;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<Uri> AllowedScriptNotifyUris
	{
		get
		{
			return (IList<Uri>)GetValue(AllowedScriptNotifyUrisProperty);
		}
		set
		{
			SetValue(AllowedScriptNotifyUrisProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataPackage DataTransferPackage => (DataPackage)GetValue(DataTransferPackageProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Color DefaultBackgroundColor
	{
		get
		{
			return (Color)GetValue(DefaultBackgroundColorProperty);
		}
		set
		{
			SetValue(DefaultBackgroundColorProperty, value);
		}
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public string DocumentTitle => (string)GetValue(DocumentTitleProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool ContainsFullScreenElement => (bool)GetValue(ContainsFullScreenElementProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<WebViewDeferredPermissionRequest> DeferredPermissionRequests
	{
		get
		{
			throw new NotImplementedException("The member IList<WebViewDeferredPermissionRequest> WebView.DeferredPermissionRequests is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public WebViewExecutionMode ExecutionMode
	{
		get
		{
			throw new NotImplementedException("The member WebViewExecutionMode WebView.ExecutionMode is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public WebViewSettings Settings
	{
		get
		{
			throw new NotImplementedException("The member WebViewSettings WebView.Settings is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AllowedScriptNotifyUrisProperty { get; } = DependencyProperty.Register("AllowedScriptNotifyUris", typeof(IList<Uri>), typeof(WebView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IList<Uri> AnyScriptNotifyUri
	{
		get
		{
			throw new NotImplementedException("The member IList<Uri> WebView.AnyScriptNotifyUri is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DataTransferPackageProperty { get; } = DependencyProperty.Register("DataTransferPackage", typeof(DataPackage), typeof(WebView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DefaultBackgroundColorProperty { get; } = DependencyProperty.Register("DefaultBackgroundColor", typeof(Color), typeof(WebView), new FrameworkPropertyMetadata(default(Color)));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty DocumentTitleProperty { get; } = DependencyProperty.Register("DocumentTitle", typeof(string), typeof(WebView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContainsFullScreenElementProperty { get; } = DependencyProperty.Register("ContainsFullScreenElement", typeof(bool), typeof(WebView), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static WebViewExecutionMode DefaultExecutionMode
	{
		get
		{
			throw new NotImplementedException("The member WebViewExecutionMode WebView.DefaultExecutionMode is not implemented in Uno.");
		}
	}

	public bool CanGoBack
	{
		get
		{
			return (bool)GetValue(CanGoBackProperty);
		}
		private set
		{
			SetValue(CanGoBackProperty, value);
		}
	}

	public static DependencyProperty CanGoBackProperty { get; } = DependencyProperty.Register("CanGoBack", typeof(bool), typeof(WebView), new FrameworkPropertyMetadata(false));


	public bool CanGoForward
	{
		get
		{
			return (bool)GetValue(CanGoForwardProperty);
		}
		private set
		{
			SetValue(CanGoForwardProperty, value);
		}
	}

	public static DependencyProperty CanGoForwardProperty { get; } = DependencyProperty.Register("CanGoForward", typeof(bool), typeof(WebView), new FrameworkPropertyMetadata(false));


	public Uri Source
	{
		get
		{
			return (Uri)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(Uri), typeof(WebView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((WebView)s)?.Navigate((Uri)e.NewValue);
	}));


	public bool IsScrollEnabled
	{
		get
		{
			return (bool)GetValue(IsScrollEnabledProperty);
		}
		set
		{
			SetValue(IsScrollEnabledProperty, value);
		}
	}

	public static DependencyProperty IsScrollEnabledProperty { get; } = DependencyProperty.Register("IsScrollEnabled", typeof(bool), typeof(WebView), new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)delegate
	{
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event LoadCompletedEventHandler LoadCompleted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event LoadCompletedEventHandler WebView.LoadCompleted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event LoadCompletedEventHandler WebView.LoadCompleted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event NotifyEventHandler ScriptNotify
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event NotifyEventHandler WebView.ScriptNotify");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event NotifyEventHandler WebView.ScriptNotify");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewContentLoadingEventArgs> ContentLoading
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewContentLoadingEventArgs> WebView.ContentLoading");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewContentLoadingEventArgs> WebView.ContentLoading");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewDOMContentLoadedEventArgs> DOMContentLoaded
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewDOMContentLoadedEventArgs> WebView.DOMContentLoaded");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewDOMContentLoadedEventArgs> WebView.DOMContentLoaded");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewContentLoadingEventArgs> FrameContentLoading
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewContentLoadingEventArgs> WebView.FrameContentLoading");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewContentLoadingEventArgs> WebView.FrameContentLoading");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewDOMContentLoadedEventArgs> FrameDOMContentLoaded
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewDOMContentLoadedEventArgs> WebView.FrameDOMContentLoaded");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewDOMContentLoadedEventArgs> WebView.FrameDOMContentLoaded");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewNavigationCompletedEventArgs> FrameNavigationCompleted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewNavigationCompletedEventArgs> WebView.FrameNavigationCompleted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewNavigationCompletedEventArgs> WebView.FrameNavigationCompleted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewNavigationStartingEventArgs> FrameNavigationStarting
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewNavigationStartingEventArgs> WebView.FrameNavigationStarting");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewNavigationStartingEventArgs> WebView.FrameNavigationStarting");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewLongRunningScriptDetectedEventArgs> LongRunningScriptDetected
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewLongRunningScriptDetectedEventArgs> WebView.LongRunningScriptDetected");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewLongRunningScriptDetectedEventArgs> WebView.LongRunningScriptDetected");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, object> UnsafeContentWarningDisplaying
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, object> WebView.UnsafeContentWarningDisplaying");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, object> WebView.UnsafeContentWarningDisplaying");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewUnviewableContentIdentifiedEventArgs> UnviewableContentIdentified
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewUnviewableContentIdentifiedEventArgs> WebView.UnviewableContentIdentified");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewUnviewableContentIdentifiedEventArgs> WebView.UnviewableContentIdentified");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, object> ContainsFullScreenElementChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, object> WebView.ContainsFullScreenElementChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, object> WebView.ContainsFullScreenElementChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewPermissionRequestedEventArgs> PermissionRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewPermissionRequestedEventArgs> WebView.PermissionRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewPermissionRequestedEventArgs> WebView.PermissionRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewSeparateProcessLostEventArgs> SeparateProcessLost
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewSeparateProcessLostEventArgs> WebView.SeparateProcessLost");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewSeparateProcessLostEventArgs> WebView.SeparateProcessLost");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<WebView, WebViewWebResourceRequestedEventArgs> WebResourceRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewWebResourceRequestedEventArgs> WebView.WebResourceRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "event TypedEventHandler<WebView, WebViewWebResourceRequestedEventArgs> WebView.WebResourceRequested");
		}
	}

	public event TypedEventHandler<WebView, WebViewNavigationStartingEventArgs> NavigationStarting;

	public event TypedEventHandler<WebView, WebViewNavigationCompletedEventArgs> NavigationCompleted;

	public event TypedEventHandler<WebView, WebViewNewWindowRequestedEventArgs> NewWindowRequested;

	public event TypedEventHandler<WebView, WebViewUnsupportedUriSchemeIdentifiedEventArgs> UnsupportedUriSchemeIdentified;

	public event WebViewNavigationFailedEventHandler NavigationFailed;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public WebView(WebViewExecutionMode executionMode)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "WebView.WebView(WebViewExecutionMode executionMode)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string InvokeScript(string scriptName, string[] arguments)
	{
		throw new NotImplementedException("The member string WebView.InvokeScript(string scriptName, string[] arguments) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public void Refresh()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "void WebView.Refresh()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncAction CapturePreviewToStreamAsync(IRandomAccessStream stream)
	{
		throw new NotImplementedException("The member IAsyncAction WebView.CapturePreviewToStreamAsync(IRandomAccessStream stream) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public IAsyncOperation<string> InvokeScriptAsync(string scriptName, IEnumerable<string> arguments)
	{
		throw new NotImplementedException("The member IAsyncOperation<string> WebView.InvokeScriptAsync(string scriptName, IEnumerable<string> arguments) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<DataPackage> CaptureSelectedContentToDataPackageAsync()
	{
		throw new NotImplementedException("The member IAsyncOperation<DataPackage> WebView.CaptureSelectedContentToDataPackageAsync() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void NavigateToLocalStreamUri(Uri source, IUriToStreamResolver streamResolver)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "void WebView.NavigateToLocalStreamUri(Uri source, IUriToStreamResolver streamResolver)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Uri BuildLocalStreamUri(string contentIdentifier, string relativePath)
	{
		throw new NotImplementedException("The member Uri WebView.BuildLocalStreamUri(string contentIdentifier, string relativePath) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void NavigateWithHttpRequestMessage(Windows.Web.Http.HttpRequestMessage requestMessage)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "void WebView.NavigateWithHttpRequestMessage(HttpRequestMessage requestMessage)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void AddWebAllowedObject(string name, object pObject)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebView", "void WebView.AddWebAllowedObject(string name, object pObject)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public WebViewDeferredPermissionRequest DeferredPermissionRequestById(uint id)
	{
		throw new NotImplementedException("The member WebViewDeferredPermissionRequest WebView.DeferredPermissionRequestById(uint id) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IAsyncAction ClearTemporaryWebDataAsync()
	{
		throw new NotImplementedException("The member IAsyncAction WebView.ClearTemporaryWebDataAsync() is not implemented in Uno.");
	}

	public WebView()
	{
		base.DefaultStyleKey = typeof(WebView);
	}

	public void GoBack()
	{
	}

	public void GoForward()
	{
	}

	public void Navigate(Uri uri)
	{
		SetInternalSource(uri ?? BlankUri);
	}

	public void NavigateToString(string text)
	{
		SetInternalSource(text ?? "");
	}

	public void NavigateWithHttpRequestMessage(global::System.Net.Http.HttpRequestMessage requestMessage)
	{
		if (requestMessage?.RequestUri == null)
		{
			throw new ArgumentException("Invalid request message. It does not have a RequestUri.");
		}
		SetInternalSource(requestMessage);
	}

	public void Stop()
	{
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		_isLoaded = true;
	}

	private void SetInternalSource(object source)
	{
		_internalSource = source;
		UpdateFromInternalSource();
	}

	private void UpdateFromInternalSource()
	{
		Uri uri = _internalSource as Uri;
		if (!(uri != null))
		{
			string text = _internalSource as string;
			global::System.Net.Http.HttpRequestMessage httpRequestMessage = _internalSource as global::System.Net.Http.HttpRequestMessage;
		}
	}

	private static string ConcatenateJavascriptArguments(string[] arguments)
	{
		string result = string.Empty;
		if (arguments != null && arguments.Any())
		{
			result = string.Join(",", arguments);
		}
		return result;
	}

	internal void OnUnsupportedUriSchemeIdentified(WebViewUnsupportedUriSchemeIdentifiedEventArgs args)
	{
		this.UnsupportedUriSchemeIdentified?.Invoke(this, args);
	}

	internal bool GetIsHistoryEntryValid(string url)
	{
		if (!url.IsNullOrWhiteSpace())
		{
			return !url.Equals("about:blank", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public async Task<string> InvokeScriptAsync(CancellationToken ct, string script, string[] arguments)
	{
		throw new NotSupportedException();
	}

	public async Task<string> InvokeScriptAsync(string script, string[] arguments)
	{
		throw new NotSupportedException();
	}
}

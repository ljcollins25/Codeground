using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.Helpers;
using Uno.UI.DataBinding;
using Uno.UI.Dispatching;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Windows.UI.Xaml.Media;

[TypeConverter(typeof(ImageSourceConverter))]
[Windows.UI.Xaml.Data.Bindable]
public class ImageSource : DependencyObject, IDisposable, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	public static class TraceProvider
	{
		public static readonly Guid Id = Guid.Parse("{FC4E2720-2DCF-418C-B360-93314AB3B813}");

		public const int ImageSource_SetImageDecodeStart = 1;

		public const int ImageSource_SetImageDecodeStop = 2;
	}

	private static readonly IEventProvider _trace = Tracing.Get(TraceProvider.Id);

	private const string MsAppXScheme = "ms-appx";

	private const string MsAppDataScheme = "ms-appdata";

	public static IImageSourceDownloader DefaultDownloader;

	public IImageSourceDownloader Downloader;

	private Uri _webUri;

	private readonly SerialDisposable _opening = new SerialDisposable();

	private readonly List<Action<ImageData>> _subscriptions = new List<Action<ImageData>>();

	private ImageData? _cache;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	internal string FilePath { get; private set; }

	public bool UseTargetSize { get; set; }

	internal Uri WebUri
	{
		get
		{
			return _webUri;
		}
		private set
		{
			_webUri = value;
			_ = value != null;
		}
	}

	internal bool IsOpened => _cache.HasValue;

	public Windows.UI.Core.CoreDispatcher Dispatcher => CoreApplication.MainView.Dispatcher;

	private DependencyObjectStore __Store
	{
		get
		{
			if (__storeBackingField == null)
			{
				__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);
				__InitializeBinder();
			}
			return __storeBackingField;
		}
	}

	public bool IsStoreInitialized => __storeBackingField != null;

	DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;

	ManagedWeakReference IWeakReferenceProvider.WeakReference
	{
		get
		{
			if (_selfWeakReference == null)
			{
				_selfWeakReference = WeakReferencePool.RentSelfWeakReference(this);
			}
			return _selfWeakReference;
		}
	}

	public object DataContext
	{
		get
		{
			return GetValue(DataContextProperty);
		}
		set
		{
			SetValue(DataContextProperty, value);
		}
	}

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(ImageSource), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ImageSource)s).OnDataContextChanged(e);
	}));


	public DependencyObject TemplatedParent
	{
		get
		{
			return (DependencyObject)GetValue(TemplatedParentProperty);
		}
		set
		{
			SetValue(TemplatedParentProperty, value);
		}
	}

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(ImageSource), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ImageSource)s).OnTemplatedParentChanged(e);
	}));


	[EditorBrowsable(EditorBrowsableState.Never)]
	internal bool IsAutoPropertyInheritanceEnabled
	{
		get
		{
			return __Store.IsAutoPropertyInheritanceEnabled;
		}
		set
		{
			__Store.IsAutoPropertyInheritanceEnabled = value;
		}
	}

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	private void InitializeDownloader()
	{
		Downloader = DefaultDownloader;
	}

	protected ImageSource(string url)
		: this()
	{
		Uri uri = TryCreateUriFromString(url);
		if (uri != null)
		{
			InitFromUri(uri);
		}
		else if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("The uri [{0}] is not valid, skipping.", url);
		}
	}

	protected ImageSource(Uri uri)
		: this()
	{
		InitFromUri(uri);
	}

	internal static Uri TryCreateUriFromString(string url)
	{
		if (url.StartsWith("/"))
		{
			url = "ms-appx://" + url;
		}
		if (url.HasValueTrimmed() && Uri.TryCreate(url.Trim(), UriKind.RelativeOrAbsolute, out var result))
		{
			if (!result.IsAbsoluteUri || result.Scheme.Length == 0)
			{
				return new Uri("ms-appx:///" + result.OriginalString.TrimStart("/"));
			}
			return result;
		}
		return null;
	}

	internal void InitFromUri(Uri uri)
	{
		if (!uri.IsAbsoluteUri || uri.Scheme == "")
		{
			uri = new Uri("ms-appx:///" + uri.OriginalString.TrimStart("/"));
		}
		if (uri.IsLocalResource())
		{
			InitFromResource(uri);
			return;
		}
		if (uri.IsAppData())
		{
			string filePath = AppDataUriEvaluator.ToPath(uri);
			InitFromFile(filePath);
		}
		if (uri.IsFile)
		{
			InitFromFile(uri.PathAndQuery);
		}
		WebUri = uri;
	}

	private void InitFromFile(string filePath)
	{
		FilePath = filePath;
	}

	private void InitFromResource(Uri uri)
	{
		WebUri = new Uri(uri.PathAndQuery.TrimStart("/"), UriKind.Relative);
	}

	public static implicit operator ImageSource(string url)
	{
		if (!url.IsNullOrWhiteSpace())
		{
			return new BitmapImage(url);
		}
		return null;
	}

	public static implicit operator ImageSource(Uri uri)
	{
		return new BitmapImage(uri);
	}

	public static implicit operator ImageSource(Stream stream)
	{
		throw new NotSupportedException("Implicit conversion from Stream to ImageSource is not supported");
	}

	public void Dispose()
	{
	}

	private async Task<Uri> Download(CancellationToken ct, Uri uri)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("Initiated download from {0}", uri);
		}
		if (Downloader != null)
		{
			return await Downloader.Download(ct, uri);
		}
		throw new InvalidOperationException("No Downloader has been specified for this ImageSource. An IImageSourceDownloader may be provided to enable image downloads.");
	}

	internal IDisposable Subscribe(Action<ImageData> onSourceOpened, int? targetWidth = null, int? targetHeight = null)
	{
		_subscriptions.Add(onSourceOpened);
		if (_cache.HasValue)
		{
			onSourceOpened(_cache.Value);
		}
		else if (_subscriptions.Count == 1)
		{
			RequestOpen(targetWidth, targetHeight);
		}
		return Disposable.Create(delegate
		{
			_subscriptions.Remove(onSourceOpened);
		});
	}

	private protected virtual bool TryOpenSourceSync(int? targetWidth, int? targetHeight, out ImageData image)
	{
		image = default(ImageData);
		return false;
	}

	private protected virtual bool TryOpenSourceAsync(CancellationToken ct, int? targetWidth, int? targetHeight, out Task<ImageData> asyncImage)
	{
		asyncImage = null;
		return false;
	}

	private protected void InvalidateSource()
	{
		_cache = null;
		if (_subscriptions.Count > 0)
		{
			RequestOpen();
		}
	}

	private protected void RequestOpen(int? targetWidth = null, int? targetHeight = null)
	{
		try
		{
			if (TryOpenSourceSync(targetWidth, targetHeight, out var image))
			{
				OnOpened(image);
				return;
			}
			_opening.Disposable = null;
			_opening.Disposable = Uno.UI.Dispatching.CoreDispatcher.Main.RunAsync(Uno.UI.Dispatching.CoreDispatcherPriority.Normal, delegate(CancellationToken ct)
			{
				Open(ct, targetWidth, targetHeight);
			});
		}
		catch (Exception ex)
		{
			this.Log().Error($"Error loading image: {ex}");
			OnOpened(new ImageData
			{
				Kind = ImageDataKind.Error,
				Error = ex
			});
		}
	}

	private async Task Open(CancellationToken ct, int? targetWidth = null, int? targetHeight = null)
	{
		try
		{
			Task<ImageData> asyncImage;
			if (TryOpenSourceSync(targetWidth, targetHeight, out var image))
			{
				OnOpened(image);
			}
			else if (TryOpenSourceAsync(ct, targetWidth, targetHeight, out asyncImage))
			{
				OnOpened(await asyncImage);
			}
			else
			{
				OnOpened(default(ImageData));
			}
		}
		catch (Exception error)
		{
			OnOpened(new ImageData
			{
				Kind = ImageDataKind.Error,
				Error = error
			});
		}
	}

	private void OnOpened(ImageData data)
	{
		_cache = data;
		if (this.Log().IsEnabled(LogLevel.Information))
		{
			this.Log().Info($"Image {this} opened with {data}");
		}
		List<Action<ImageData>> list = _subscriptions.ToList();
		foreach (Action<ImageData> item in list)
		{
			item(data);
		}
	}

	public ImageSource()
	{
	}

	internal void UnloadImageData()
	{
	}

	private protected async Task<ImageData> OpenFromStream(IRandomAccessStreamWithContentType stream, Action<ulong, ulong?>? progress, CancellationToken ct)
	{
		try
		{
			string text = Convert.ToBase64String(await stream.ReadBytesAsync(ct, 0uL, progress));
			ReportImageLoaded();
			ImageData result = default(ImageData);
			result.Kind = ImageDataKind.DataUri;
			result.Value = "data:" + stream.ContentType + ";base64," + text;
			return result;
		}
		catch (Exception ex)
		{
			ReportImageFailed(ex.Message);
			ImageData result = default(ImageData);
			result.Kind = ImageDataKind.Error;
			result.Error = ex;
			return result;
		}
	}

	internal virtual void ReportImageLoaded()
	{
	}

	internal virtual void ReportImageFailed(string errorMessage)
	{
	}

	public object GetValue(DependencyProperty dp)
	{
		return __Store.GetValue(dp);
	}

	public void SetValue(DependencyProperty dp, object value)
	{
		__Store.SetValue(dp, value);
	}

	public void ClearValue(DependencyProperty dp)
	{
		__Store.ClearValue(dp);
	}

	public object ReadLocalValue(DependencyProperty dp)
	{
		return __Store.ReadLocalValue(dp);
	}

	public object GetAnimationBaseValue(DependencyProperty dp)
	{
		return __Store.GetAnimationBaseValue(dp);
	}

	public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback)
	{
		return __Store.RegisterPropertyChangedCallback(dp, callback);
	}

	public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token)
	{
		__Store.UnregisterPropertyChangedCallback(dp, token);
	}

	private void __InitializeBinder()
	{
		if (BinderReferenceHolder.IsEnabled)
		{
			_refHolder = new BinderReferenceHolder(GetType(), this);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ClearBindings()
	{
		__Store.ClearBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RestoreBindings()
	{
		__Store.RestoreBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyCompiledBindings()
	{
	}

	public override string ToString()
	{
		return GetType().FullName;
	}

	protected internal virtual void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		this.DataContextChanged?.Invoke(null, new DataContextChangedEventArgs(DataContext));
	}

	protected internal virtual void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		__Store.SetTemplatedParent(e.NewValue as FrameworkElement);
	}

	public void SetBinding(object target, string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(target, dependencyProperty, binding);
	}

	public void SetBinding(string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBinding(DependencyProperty dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBindingValue(object value, [CallerMemberName] string propertyName = null)
	{
		__Store.SetBindingValue(value, propertyName);
	}

	public BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return __Store.GetBindingExpression(dependencyProperty);
	}

	public void ResumeBindings()
	{
		__Store.ResumeBindings();
	}

	public void SuspendBindings()
	{
		__Store.SuspendBindings();
	}
}

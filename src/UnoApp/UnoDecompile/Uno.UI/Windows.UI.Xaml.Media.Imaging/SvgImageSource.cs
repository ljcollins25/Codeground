using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Uno;
using Windows.Foundation;
using Windows.Storage.Helpers;
using Windows.Storage.Streams;

namespace Windows.UI.Xaml.Media.Imaging;

public class SvgImageSource : ImageSource
{
	private SvgImageSourceLoadStatus? _lastStatus;

	private IRandomAccessStream _stream;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double RasterizePixelWidth
	{
		get
		{
			return (double)GetValue(RasterizePixelWidthProperty);
		}
		set
		{
			SetValue(RasterizePixelWidthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double RasterizePixelHeight
	{
		get
		{
			return (double)GetValue(RasterizePixelHeightProperty);
		}
		set
		{
			SetValue(RasterizePixelHeightProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RasterizePixelHeightProperty { get; } = DependencyProperty.Register("RasterizePixelHeight", typeof(double), typeof(SvgImageSource), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RasterizePixelWidthProperty { get; } = DependencyProperty.Register("RasterizePixelWidth", typeof(double), typeof(SvgImageSource), new FrameworkPropertyMetadata(0.0));


	public Uri UriSource
	{
		get
		{
			return (Uri)GetValue(UriSourceProperty);
		}
		set
		{
			SetValue(UriSourceProperty, value);
		}
	}

	public static DependencyProperty UriSourceProperty { get; } = DependencyProperty.Register("UriSource", typeof(Uri), typeof(SvgImageSource), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as SvgImageSource)?.OnUriSourceChanged(e);
	}));


	internal string ContentType { get; set; } = "image/svg+xml";


	public event TypedEventHandler<SvgImageSource, SvgImageSourceFailedEventArgs> OpenFailed;

	public event TypedEventHandler<SvgImageSource, SvgImageSourceOpenedEventArgs> Opened;

	private void OnUriSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		if (!object.Equals(e.OldValue, e.NewValue))
		{
			UnloadImageData();
		}
		InitFromUri(e.NewValue as Uri);
		InvalidateSource();
	}

	public SvgImageSource()
	{
		InitPartial();
	}

	public SvgImageSource(Uri uriSource)
	{
		UriSource = uriSource;
		InitPartial();
	}

	public IAsyncOperation<SvgImageSourceLoadStatus> SetSourceAsync(IRandomAccessStream streamSource)
	{
		return AsyncOperation<SvgImageSourceLoadStatus>.FromTask(new FuncAsync<AsyncOperation<SvgImageSourceLoadStatus>, SvgImageSourceLoadStatus>(SetSourceAsync));
		async Task<SvgImageSourceLoadStatus> SetSourceAsync(CancellationToken ct, AsyncOperation<SvgImageSourceLoadStatus> _)
		{
			if (streamSource == null)
			{
				throw new ArgumentException("streamSource");
			}
			_lastStatus = null;
			_stream = streamSource.CloneStream();
			TaskCompletionSource<SvgImageSourceLoadStatus> tcs = new TaskCompletionSource<SvgImageSourceLoadStatus>();
			using (Subscribe(OnChanged))
			{
				InvalidateSource();
				return await tcs.Task;
			}
			void OnChanged(ImageData data)
			{
				tcs.TrySetResult(_lastStatus ?? SvgImageSourceLoadStatus.Other);
			}
		}
	}

	private void InitPartial()
	{
	}

	private void RaiseImageFailed(SvgImageSourceLoadStatus loadStatus)
	{
		_lastStatus = loadStatus;
		this.OpenFailed?.Invoke(this, new SvgImageSourceFailedEventArgs(loadStatus));
	}

	private void RaiseImageOpened()
	{
		_lastStatus = SvgImageSourceLoadStatus.Success;
		this.Opened?.Invoke(this, new SvgImageSourceOpenedEventArgs());
	}

	private protected override bool TryOpenSourceSync(int? targetWidth, int? targetHeight, out ImageData image)
	{
		Uri webUri = base.WebUri;
		if ((object)webUri != null)
		{
			image = default(ImageData);
			Uri uri = ((!webUri.IsAbsoluteUri || !(webUri.Scheme == "file")) ? webUri : new Uri(webUri.PathAndQuery.TrimStart(new char[1] { '/' }), UriKind.Relative));
			Uri uri2 = uri;
			if (uri2.IsAbsoluteUri)
			{
				if (uri2.Scheme == "http" || uri2.Scheme == "https")
				{
					image = new ImageData
					{
						Kind = ImageDataKind.Url,
						Value = uri2.AbsoluteUri,
						Source = this
					};
				}
			}
			else
			{
				string value = AssetsPathBuilder.BuildAssetUri(uri2.OriginalString);
				image = new ImageData
				{
					Kind = ImageDataKind.Url,
					Value = value,
					Source = this
				};
			}
			return image.Kind != ImageDataKind.Empty;
		}
		image = default(ImageData);
		return false;
	}

	private protected override bool TryOpenSourceAsync(CancellationToken ct, int? targetWidth, int? targetHeight, out Task<ImageData> asyncImage)
	{
		IRandomAccessStream stream = _stream;
		if (stream != null)
		{
			IRandomAccessStreamWithContentType stream2 = stream.TrySetContentType(ContentType);
			asyncImage = OpenFromStream(stream2, null, ct);
			return true;
		}
		asyncImage = null;
		return false;
	}

	internal override void ReportImageLoaded()
	{
		RaiseImageOpened();
	}

	internal override void ReportImageFailed(string errorMessage)
	{
		RaiseImageFailed(SvgImageSourceLoadStatus.Other);
	}

	public override string ToString()
	{
		Uri webUri = base.WebUri;
		if ((object)webUri != null)
		{
			return $"{GetType().Name}/{webUri}";
		}
		IRandomAccessStream stream = _stream;
		if (stream != null)
		{
			return $"{GetType().Name}/{stream.GetType()}";
		}
		return GetType().Name + "/-empty-";
	}
}

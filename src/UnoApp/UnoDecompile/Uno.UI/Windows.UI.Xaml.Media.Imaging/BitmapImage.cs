using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Uno;
using Uno.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.Storage.Helpers;
using Windows.Storage.Streams;

namespace Windows.UI.Xaml.Media.Imaging;

public sealed class BitmapImage : BitmapSource
{
	internal static class AssetResolver
	{
		private static readonly Lazy<Task<HashSet<string>>> _assets = new Lazy<Task<HashSet<string>>>(new Func<Task<HashSet<string>>>(GetAssets));

		private static readonly int[] KnownScales = new int[16]
		{
			100, 120, 125, 140, 150, 160, 175, 180, 200, 225,
			250, 300, 350, 400, 450, 500
		};

		private static async Task<HashSet<string>> GetAssets()
		{
			string text = AssetsPathBuilder.BuildAssetUri("uno-assets.txt");
			return new HashSet<string>(Regex.Split(await WebAssemblyRuntime.InvokeAsync("fetch('" + text + "').then(r => r.text())"), "\r\n|\r|\n"));
		}

		internal static async Task<ImageData> ResolveImageAsync(ImageSource source, Uri uri, ResolutionScale? scaleOverride)
		{
			try
			{
				ImageData result;
				if (uri.IsAbsoluteUri)
				{
					if (uri.Scheme == "http" || uri.Scheme == "https")
					{
						result = default(ImageData);
						result.Kind = ImageDataKind.Url;
						result.Value = uri.AbsoluteUri;
						result.Source = source;
						return result;
					}
					return default(ImageData);
				}
				HashSet<string> assets = await _assets.Value;
				result = default(ImageData);
				result.Kind = ImageDataKind.Url;
				result.Value = GetScaledPath(uri.OriginalString, assets, scaleOverride);
				result.Source = source;
				return result;
			}
			catch (Exception error)
			{
				ImageData result = default(ImageData);
				result.Kind = ImageDataKind.Error;
				result.Error = error;
				return result;
			}
		}

		private static string GetScaledPath(string path, HashSet<string> assets, ResolutionScale? scaleOverride)
		{
			if (!string.IsNullOrEmpty(path))
			{
				string directoryName = Path.GetDirectoryName(path);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
				string extension = Path.GetExtension(path);
				int num = (int)((!scaleOverride.HasValue) ? DisplayInformation.GetForCurrentView().ResolutionScale : scaleOverride.Value);
				if (num < 100)
				{
					num = 100;
				}
				for (int num2 = KnownScales.Length - 1; num2 >= 0; num2--)
				{
					int num3 = KnownScales[num2];
					if (num >= num3)
					{
						string text = Path.Combine(directoryName, $"{fileNameWithoutExtension}.scale-{num3}{extension}");
						if (assets.Contains(text))
						{
							return AssetsPathBuilder.BuildAssetUri(text);
						}
					}
				}
				return AssetsPathBuilder.BuildAssetUri(path);
			}
			return path;
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AutoPlay
	{
		get
		{
			return (bool)GetValue(AutoPlayProperty);
		}
		set
		{
			SetValue(AutoPlayProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsAnimatedBitmap => (bool)GetValue(IsAnimatedBitmapProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsPlaying => (bool)GetValue(IsPlayingProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AutoPlayProperty { get; } = DependencyProperty.Register("AutoPlay", typeof(bool), typeof(BitmapImage), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsAnimatedBitmapProperty { get; } = DependencyProperty.Register("IsAnimatedBitmap", typeof(bool), typeof(BitmapImage), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsPlayingProperty { get; } = DependencyProperty.Register("IsPlaying", typeof(bool), typeof(BitmapImage), new FrameworkPropertyMetadata(false));


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

	public static DependencyProperty UriSourceProperty { get; } = DependencyProperty.Register("UriSource", typeof(Uri), typeof(BitmapImage), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BitmapImage)s)?.OnUriSourceChanged(e);
	}));


	public DecodePixelType DecodePixelType
	{
		get
		{
			return (DecodePixelType)GetValue(DecodePixelTypeProperty);
		}
		set
		{
			SetValue(DecodePixelTypeProperty, value);
		}
	}

	public static DependencyProperty DecodePixelTypeProperty { get; } = DependencyProperty.Register("DecodePixelType", typeof(DecodePixelType), typeof(BitmapImage), new FrameworkPropertyMetadata(DecodePixelType.Physical, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BitmapImage)s)?.OnDecodePixelTypeChanged(e);
	}));


	public int DecodePixelWidth
	{
		get
		{
			return (int)GetValue(DecodePixelWidthProperty);
		}
		set
		{
			SetValue(DecodePixelWidthProperty, value);
		}
	}

	public static DependencyProperty DecodePixelWidthProperty { get; } = DependencyProperty.Register("DecodePixelWidth", typeof(int), typeof(BitmapImage), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BitmapImage)s)?.OnDecodePixelWidthChanged(e);
	}));


	public int DecodePixelHeight
	{
		get
		{
			return (int)GetValue(DecodePixelHeightProperty);
		}
		set
		{
			SetValue(DecodePixelHeightProperty, value);
		}
	}

	public static DependencyProperty DecodePixelHeightProperty { get; } = DependencyProperty.Register("DecodePixelHeight", typeof(int), typeof(BitmapImage), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BitmapImage)s)?.OnDecodePixelHeightChanged(e);
	}));


	public BitmapCreateOptions CreateOptions
	{
		get
		{
			return (BitmapCreateOptions)GetValue(CreateOptionsProperty);
		}
		set
		{
			SetValue(CreateOptionsProperty, value);
		}
	}

	public static DependencyProperty CreateOptionsProperty { get; } = DependencyProperty.Register("CreateOptions", typeof(BitmapCreateOptions), typeof(BitmapImage), new FrameworkPropertyMetadata(BitmapCreateOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BitmapImage)s)?.OnCreateOptionsChanged(e);
	}));


	internal ResolutionScale? ScaleOverride { get; set; }

	internal string ContentType { get; set; } = "application/octet-stream";


	public event DownloadProgressEventHandler DownloadProgress;

	public event ExceptionRoutedEventHandler ImageFailed;

	public event RoutedEventHandler ImageOpened;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Play()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Imaging.BitmapImage", "void BitmapImage.Play()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Stop()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Imaging.BitmapImage", "void BitmapImage.Stop()");
	}

	private void OnUriSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		if (!object.Equals(e.OldValue, e.NewValue))
		{
			UnloadImageData();
		}
		InitFromUri(e.NewValue as Uri);
		InvalidateSource();
	}

	private void OnDecodePixelTypeChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnDecodePixelWidthChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnDecodePixelHeightChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnCreateOptionsChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	public BitmapImage(Uri uriSource)
		: base(uriSource)
	{
		UriSource = uriSource;
	}

	internal BitmapImage(string stringSource)
		: base(stringSource)
	{
		UriSource = base.WebUri ?? ImageSource.TryCreateUriFromString(stringSource);
	}

	public BitmapImage()
	{
	}

	private void RaiseDownloadProgress(int progress = 0)
	{
		DownloadProgressEventHandler downloadProgress = this.DownloadProgress;
		if (downloadProgress != null)
		{
			downloadProgress?.Invoke(this, new DownloadProgressEventArgs
			{
				Progress = progress
			});
		}
	}

	private void RaiseImageFailed(ExceptionRoutedEventArgs args)
	{
		ExceptionRoutedEventHandler imageFailed = this.ImageFailed;
		if (imageFailed != null)
		{
			imageFailed?.Invoke(this, args);
		}
	}

	private void RaiseImageFailed(Exception ex)
	{
		ExceptionRoutedEventHandler imageFailed = this.ImageFailed;
		if (imageFailed != null)
		{
			imageFailed?.Invoke(this, new ExceptionRoutedEventArgs(this, ex.Message));
		}
	}

	private void RaiseImageOpened()
	{
		RoutedEventHandler imageOpened = this.ImageOpened;
		if (imageOpened != null)
		{
			imageOpened?.Invoke(this, new RoutedEventArgs(this));
		}
	}

	private protected override bool TryOpenSourceAsync(CancellationToken ct, int? targetWidth, int? targetHeight, out Task<ImageData> asyncImage)
	{
		Uri webUri = base.WebUri;
		if ((object)webUri != null)
		{
			Uri uri = ((!webUri.IsAbsoluteUri || !(webUri.Scheme == "file")) ? webUri : new Uri(webUri.PathAndQuery.TrimStart(new char[1] { '/' }), UriKind.Relative));
			Uri uri2 = uri;
			asyncImage = AssetResolver.ResolveImageAsync(this, uri2, ScaleOverride);
			return true;
		}
		IRandomAccessStream stream = _stream;
		if (stream != null)
		{
			IRandomAccessStreamWithContentType stream2 = stream.TrySetContentType(ContentType);
			asyncImage = OpenFromStream(stream2, new Action<ulong, ulong?>(OnProgress), ct);
			return true;
		}
		asyncImage = null;
		return false;
		void OnProgress(ulong position, ulong? length)
		{
			if (position != 0 && length.HasValue)
			{
				ulong valueOrDefault = length.GetValueOrDefault();
				int progress = (int)((float)position / (float)valueOrDefault * 100f);
				RaiseDownloadProgress(progress);
			}
		}
	}

	internal override void ReportImageLoaded()
	{
		RaiseImageOpened();
	}

	internal override void ReportImageFailed(string errorMessage)
	{
		RaiseImageFailed(new Exception("Unable to load image: " + errorMessage));
	}
}

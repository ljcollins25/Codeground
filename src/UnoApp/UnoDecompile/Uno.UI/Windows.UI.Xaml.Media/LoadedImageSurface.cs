using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;
using Windows.UI.Composition;

namespace Windows.UI.Xaml.Media;

[NotImplemented]
public class LoadedImageSurface : IDisposable, ICompositionSurface
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Size DecodedPhysicalSize
	{
		get
		{
			throw new NotImplementedException("The member Size LoadedImageSurface.DecodedPhysicalSize is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Size DecodedSize
	{
		get
		{
			throw new NotImplementedException("The member Size LoadedImageSurface.DecodedSize is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Size NaturalSize
	{
		get
		{
			throw new NotImplementedException("The member Size LoadedImageSurface.NaturalSize is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<LoadedImageSurface, LoadedImageSourceLoadCompletedEventArgs> LoadCompleted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.LoadedImageSurface", "event TypedEventHandler<LoadedImageSurface, LoadedImageSourceLoadCompletedEventArgs> LoadedImageSurface.LoadCompleted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.LoadedImageSurface", "event TypedEventHandler<LoadedImageSurface, LoadedImageSourceLoadCompletedEventArgs> LoadedImageSurface.LoadCompleted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Dispose()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.LoadedImageSurface", "void LoadedImageSurface.Dispose()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static LoadedImageSurface StartLoadFromUri(Uri uri, Size desiredMaxSize)
	{
		throw new NotImplementedException("The member LoadedImageSurface LoadedImageSurface.StartLoadFromUri(Uri uri, Size desiredMaxSize) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static LoadedImageSurface StartLoadFromUri(Uri uri)
	{
		throw new NotImplementedException("The member LoadedImageSurface LoadedImageSurface.StartLoadFromUri(Uri uri) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static LoadedImageSurface StartLoadFromStream(IRandomAccessStream stream, Size desiredMaxSize)
	{
		throw new NotImplementedException("The member LoadedImageSurface LoadedImageSurface.StartLoadFromStream(IRandomAccessStream stream, Size desiredMaxSize) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static LoadedImageSurface StartLoadFromStream(IRandomAccessStream stream)
	{
		throw new NotImplementedException("The member LoadedImageSurface LoadedImageSurface.StartLoadFromStream(IRandomAccessStream stream) is not implemented in Uno.");
	}
}

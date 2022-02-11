using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Imaging;

namespace Windows.UI.Xaml.Media.Imaging;

[NotImplemented]
public class SoftwareBitmapSource : ImageSource, IDisposable
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SoftwareBitmapSource()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Imaging.SoftwareBitmapSource", "SoftwareBitmapSource.SoftwareBitmapSource()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncAction SetBitmapAsync(SoftwareBitmap softwareBitmap)
	{
		throw new NotImplementedException("The member IAsyncAction SoftwareBitmapSource.SetBitmapAsync(SoftwareBitmap softwareBitmap) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new void Dispose()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Imaging.SoftwareBitmapSource", "void SoftwareBitmapSource.Dispose()");
	}
}

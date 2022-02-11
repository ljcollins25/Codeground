using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Windows.UI.Xaml;

public class DragUI
{
	internal ImageSource? Content { get; set; }

	internal Point? Anchor { get; set; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.DragUI", "void DragUI.SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap, Point anchorPoint)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.DragUI", "void DragUI.SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap, Point anchorPoint)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetContentFromDataPackage()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.DragUI", "void DragUI.SetContentFromDataPackage()");
	}

	public void SetContentFromBitmapImage(BitmapImage bitmapImage)
	{
		SetContentFromBitmapImage(bitmapImage, default(Point));
	}

	public void SetContentFromBitmapImage(BitmapImage bitmapImage, Point anchorPoint)
	{
		Content = bitmapImage;
		Anchor = anchorPoint;
	}
}

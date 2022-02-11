using Uno;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;

namespace Windows.UI.Xaml;

public class DragUIOverride
{
	private readonly CoreDragUIOverride _core;

	public bool IsGlyphVisible
	{
		get
		{
			return _core.IsGlyphVisible;
		}
		set
		{
			_core.IsGlyphVisible = value;
		}
	}

	public bool IsContentVisible
	{
		get
		{
			return _core.IsContentVisible;
		}
		set
		{
			_core.IsContentVisible = value;
		}
	}

	public bool IsCaptionVisible
	{
		get
		{
			return _core.IsCaptionVisible;
		}
		set
		{
			_core.IsCaptionVisible = value;
		}
	}

	public string Caption
	{
		get
		{
			return _core.Caption;
		}
		set
		{
			_core.Caption = value;
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.DragUIOverride", "void DragUIOverride.SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap, Point anchorPoint)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.DragUIOverride", "void DragUIOverride.SetContentFromSoftwareBitmap(SoftwareBitmap softwareBitmap, Point anchorPoint)");
	}

	internal DragUIOverride(CoreDragUIOverride core)
	{
		_core = core;
	}

	public void SetContentFromBitmapImage(BitmapImage bitmapImage)
	{
		_core.Content = bitmapImage;
	}

	public void SetContentFromBitmapImage(BitmapImage bitmapImage, Point anchorPoint)
	{
		_core.Content = bitmapImage;
		_core.ContentAnchor = anchorPoint;
	}

	public void Clear()
	{
		_core.Clear();
	}
}

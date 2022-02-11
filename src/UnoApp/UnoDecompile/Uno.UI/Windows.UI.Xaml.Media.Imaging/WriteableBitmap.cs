using System;
using System.Runtime.InteropServices;
using Uno.Foundation;
using Windows.Storage.Streams;

namespace Windows.UI.Xaml.Media.Imaging;

public class WriteableBitmap : BitmapSource
{
	private readonly Windows.Storage.Streams.Buffer _buffer;

	public IBuffer PixelBuffer => _buffer;

	internal event EventHandler Invalidated;

	public WriteableBitmap(int pixelWidth, int pixelHeight)
	{
		uint num = (uint)(pixelWidth * pixelHeight * 4);
		_buffer = new Windows.Storage.Streams.Buffer(num)
		{
			Length = num
		};
		base.PixelWidth = pixelWidth;
		base.PixelHeight = pixelHeight;
	}

	public void Invalidate()
	{
		InvalidateSource();
		this.Invalidated?.Invoke(this, EventArgs.Empty);
	}

	private protected override bool TryOpenSourceSync(int? targetWidth, int? targetHeight, out ImageData image)
	{
		GCHandle gCHandle = GCHandle.Alloc(_buffer.ToArray(), GCHandleType.Pinned);
		IntPtr intPtr = gCHandle.AddrOfPinnedObject();
		try
		{
			string value = WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.rawPixelsToBase64EncodeImage(" + intPtr + ", " + base.PixelWidth + ", " + base.PixelHeight + ");");
			image = new ImageData
			{
				Kind = ImageDataKind.DataUri,
				Value = value
			};
			return true;
		}
		finally
		{
			gCHandle.Free();
		}
	}
}

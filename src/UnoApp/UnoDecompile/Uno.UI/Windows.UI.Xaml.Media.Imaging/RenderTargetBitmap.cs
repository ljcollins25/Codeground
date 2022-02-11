using System;
using System.Threading;
using Uno;
using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Windows.UI.Xaml.Media.Imaging;

[NotImplemented]
public class RenderTargetBitmap : ImageSource
{
	internal const bool IsImplemented = false;

	private byte[] _buffer;

	[NotImplemented]
	public static DependencyProperty PixelWidthProperty { get; } = DependencyProperty.Register("PixelWidth", typeof(int), typeof(RenderTargetBitmap), new FrameworkPropertyMetadata(0));


	[NotImplemented]
	public int PixelWidth
	{
		get
		{
			return (int)GetValue(PixelWidthProperty);
		}
		private set
		{
			SetValue(PixelWidthProperty, value);
		}
	}

	[NotImplemented]
	public static DependencyProperty PixelHeightProperty { get; } = DependencyProperty.Register("PixelHeight", typeof(int), typeof(RenderTargetBitmap), new FrameworkPropertyMetadata(0));


	[NotImplemented]
	public int PixelHeight
	{
		get
		{
			return (int)GetValue(PixelHeightProperty);
		}
		private set
		{
			SetValue(PixelHeightProperty, value);
		}
	}

	[NotImplemented]
	public IAsyncAction RenderAsync(UIElement element, int scaledWidth, int scaledHeight)
	{
		return AsyncAction.FromTask(async delegate
		{
			try
			{
				_buffer = RenderAsPng(element, new Size(scaledWidth, scaledHeight));
				PixelWidth = scaledWidth;
				PixelHeight = scaledHeight;
				InvalidateSource();
			}
			catch (Exception ex)
			{
				this.Log().Error("Failed to render element to bitmap.", ex);
			}
		});
	}

	[NotImplemented]
	public IAsyncAction RenderAsync(UIElement element)
	{
		return AsyncAction.FromTask(async delegate
		{
			try
			{
				_buffer = RenderAsPng(element);
				PixelWidth = (int)element.ActualSize.X;
				PixelHeight = (int)element.ActualSize.Y;
				InvalidateSource();
			}
			catch (Exception ex)
			{
				this.Log().Error("Failed to render element to bitmap.", ex);
			}
		});
	}

	[NotImplemented]
	public IAsyncOperation<IBuffer> GetPixelsAsync()
	{
		return AsyncOperation<IBuffer>.FromTask(async (CancellationToken op, AsyncOperation<IBuffer> ct) => new Windows.Storage.Streams.Buffer(_buffer));
	}

	private static byte[] RenderAsPng(UIElement element, Size? scaledSize = null)
	{
		throw new NotImplementedException("RenderTargetBitmap is not supported on this platform.");
	}
}

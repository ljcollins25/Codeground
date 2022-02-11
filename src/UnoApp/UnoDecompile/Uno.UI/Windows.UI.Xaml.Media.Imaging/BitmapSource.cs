using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Windows.UI.Xaml.Media.Imaging;

public class BitmapSource : ImageSource
{
	protected IRandomAccessStream _stream;

	public int PixelHeight
	{
		get
		{
			return (int)GetValue(PixelHeightProperty);
		}
		internal set
		{
			SetValue(PixelHeightProperty, value);
		}
	}

	public static DependencyProperty PixelHeightProperty { get; } = DependencyProperty.Register("PixelHeight", typeof(int), typeof(BitmapSource), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BitmapSource)s)?.OnPixelHeightChanged(e);
	}));


	public int PixelWidth
	{
		get
		{
			return (int)GetValue(PixelWidthProperty);
		}
		internal set
		{
			SetValue(PixelWidthProperty, value);
		}
	}

	public static DependencyProperty PixelWidthProperty { get; } = DependencyProperty.Register("PixelWidth", typeof(int), typeof(BitmapSource), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BitmapSource)s)?.OnPixelWidthChanged(e);
	}));


	private void OnPixelHeightChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnPixelWidthChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	protected BitmapSource()
	{
	}

	protected BitmapSource(Uri sourceUri)
		: base(sourceUri)
	{
	}

	protected BitmapSource(string sourceString)
		: base(sourceString)
	{
	}

	public void SetSource(Stream streamSource)
	{
		SetSourceCore(streamSource.AsRandomAccessStream());
	}

	public Task SetSourceAsync(Stream streamSource)
	{
		SetSourceCore(streamSource.AsRandomAccessStream());
		return ForceLoad(CancellationToken.None);
	}

	public void SetSource(IRandomAccessStream streamSource)
	{
		SetSourceCore(streamSource);
	}

	public IAsyncAction SetSourceAsync(IRandomAccessStream streamSource)
	{
		SetSourceCore(streamSource);
		return AsyncAction.FromTask(ForceLoad);
	}

	private void SetSourceCore(IRandomAccessStream streamSource)
	{
		if (streamSource == null)
		{
			throw new ArgumentException("streamSource");
		}
		PixelWidth = 0;
		PixelHeight = 0;
		IRandomAccessStream randomAccessStream = (_stream = streamSource.CloneStream());
	}

	private async Task ForceLoad(CancellationToken ct)
	{
		TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
		using (ct.Register(delegate
		{
			tcs.TrySetCanceled();
		}))
		{
			using (Subscribe(OnChanged))
			{
				InvalidateSource();
				await tcs.Task;
			}
		}
		void OnChanged(ImageData data)
		{
			tcs.TrySetResult(null);
		}
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

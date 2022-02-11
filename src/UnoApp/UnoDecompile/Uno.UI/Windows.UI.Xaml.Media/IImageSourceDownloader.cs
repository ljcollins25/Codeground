using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windows.UI.Xaml.Media;

public interface IImageSourceDownloader
{
	Task<Uri> Download(CancellationToken ct, Uri uri);
}

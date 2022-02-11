using System.Threading;

namespace Windows.UI.Xaml.Media.Animation;

internal static class RenderingLoopAnimatorMetadataIdProvider
{
	private static long _next;

	public static long Next()
	{
		return Interlocked.Increment(ref _next);
	}
}

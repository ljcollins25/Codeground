using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace DirectUI;

internal class CSizeUtil
{
	public static void Deflate(ref Size pSize, Thickness thickness)
	{
		pSize = pSize.Subtract(thickness);
	}

	public static void Inflate(ref Size pSize, Thickness thickness)
	{
		pSize = pSize.Add(thickness);
	}

	public static void Deflate(ref Size pSize, Size size)
	{
		pSize = pSize.Subtract(size);
	}

	public static void Inflate(ref Size pSize, Size size)
	{
		pSize = pSize.Add(size);
	}

	public static void Deflate(ref Rect pRect, Thickness thickness)
	{
		pRect = pRect.DeflateBy(thickness);
	}

	public static void Inflate(ref Rect pRect, Thickness thickness)
	{
		pRect = pRect.InflateBy(thickness);
	}
}

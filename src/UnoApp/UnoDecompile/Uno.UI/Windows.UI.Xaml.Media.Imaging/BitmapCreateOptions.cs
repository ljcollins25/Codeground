using System;

namespace Windows.UI.Xaml.Media.Imaging;

[Flags]
public enum BitmapCreateOptions : uint
{
	None = 0u,
	IgnoreImageCache = 8u
}

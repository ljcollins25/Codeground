using Windows.UI;

namespace Microsoft.UI.Xaml.Controls;

public interface IColorChangedEventArgs
{
	Color OldColor { get; }

	Color NewColor { get; }
}

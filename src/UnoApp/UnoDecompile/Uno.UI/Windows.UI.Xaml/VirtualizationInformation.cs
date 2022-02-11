using Windows.Foundation;

namespace Windows.UI.Xaml;

internal sealed class VirtualizationInformation
{
	public bool IsGeneratedContainer { get; set; }

	public bool IsContainerFromTemplateRoot { get; set; }

	public Rect Bounds { get; set; }

	public Size MeasureSize { get; set; }
}

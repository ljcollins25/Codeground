using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[WebHostHidden]
[ContractVersion(typeof(UniversalApiContract), 65536u)]
public enum ClickMode
{
	Release,
	Press,
	Hover
}

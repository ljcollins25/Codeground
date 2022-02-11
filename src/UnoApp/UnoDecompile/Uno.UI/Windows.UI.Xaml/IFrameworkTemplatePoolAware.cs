using Uno;

namespace Windows.UI.Xaml;

[UnoOnly]
internal interface IFrameworkTemplatePoolAware
{
	void OnTemplateRecycled();
}

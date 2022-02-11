using System.ComponentModel;
using Windows.UI.Xaml;

namespace Uno.UI;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IXamlResourceDictionaryProvider
{
	ResourceDictionary GetResourceDictionary();
}

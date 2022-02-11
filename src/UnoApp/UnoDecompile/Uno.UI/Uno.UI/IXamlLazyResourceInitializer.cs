using System.ComponentModel;

namespace Uno.UI;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IXamlLazyResourceInitializer
{
	object GetInitializedValue(string resourceRetrievalKey);
}

using System.ComponentModel;

namespace Windows.UI.Xaml;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IDependencyObjectParse
{
	bool IsParsing { get; set; }

	void CreationComplete();
}

namespace Windows.UI.Xaml.Automation.Provider;

public interface IExpandCollapseProvider
{
	ExpandCollapseState ExpandCollapseState { get; }

	void Collapse();

	void Expand();
}

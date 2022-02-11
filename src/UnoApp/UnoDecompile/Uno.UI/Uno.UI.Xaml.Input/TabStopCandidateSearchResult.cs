using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Input;

internal struct TabStopCandidateSearchResult
{
	public DependencyObject? Candidate { get; set; }

	public bool DidCycleFocusAtRootVisualScope { get; set; }

	public TabStopCandidateSearchResult(bool didCycleFocusAtRootVisualScope, DependencyObject? candidate)
	{
		DidCycleFocusAtRootVisualScope = didCycleFocusAtRootVisualScope;
		Candidate = candidate;
	}
}

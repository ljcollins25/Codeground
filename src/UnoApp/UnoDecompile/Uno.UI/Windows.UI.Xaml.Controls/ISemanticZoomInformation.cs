using Uno;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public interface ISemanticZoomInformation
{
	bool IsActiveView { get; set; }

	bool IsZoomedInView { get; set; }

	SemanticZoom SemanticZoomOwner { get; set; }

	void InitializeViewChange();

	void CompleteViewChange();

	void MakeVisible(SemanticZoomLocation item);

	void StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination);

	void StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination);

	void CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination);

	void CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination);
}

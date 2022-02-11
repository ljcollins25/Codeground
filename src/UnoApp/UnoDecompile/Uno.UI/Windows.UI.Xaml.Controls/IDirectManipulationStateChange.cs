using DirectUI;

namespace Windows.UI.Xaml.Controls;

internal interface IDirectManipulationStateChangeHandler
{
	void NotifyStateChange(DMManipulationState state, float xCumulativeTranslation, float yCumulativeTranslation, float zCumulativeFactor, float xCenter, float yCenter, bool isInertial, bool isTouchConfigurationActivated, bool isBringIntoViewportConfigurationActivated);
}

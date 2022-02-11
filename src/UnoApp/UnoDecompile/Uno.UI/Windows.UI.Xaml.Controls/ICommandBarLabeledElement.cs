namespace Windows.UI.Xaml.Controls;

internal interface ICommandBarLabeledElement
{
	void SetDefaultLabelPosition(CommandBarDefaultLabelPosition defaultLabelPosition);

	bool GetHasBottomLabel();
}

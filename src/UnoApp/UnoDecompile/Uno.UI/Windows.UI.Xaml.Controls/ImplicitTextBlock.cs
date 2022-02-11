using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls;

[Bindable]
public class ImplicitTextBlock : TextBlock
{
	public ImplicitTextBlock(DependencyObject parent)
	{
		AccessibilityView accessibilityView = AutomationProperties.GetAccessibilityView(parent);
		AutomationProperties.SetAccessibilityView(this, accessibilityView);
	}
}

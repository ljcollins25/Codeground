using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Xaml.Controls;

public static class ComboBox
{
	public static DependencyProperty DropDownPreferredPlacementProperty { get; } = DependencyProperty.RegisterAttached("DropDownPreferredLocation", typeof(DropDownPlacement), typeof(ComboBox), new FrameworkPropertyMetadata(FeatureConfiguration.ComboBox.DefaultDropDownPreferredPlacement));


	public static void SetDropDownPreferredPlacement(Windows.UI.Xaml.Controls.ComboBox combo, DropDownPlacement mode)
	{
		combo.SetValue(DropDownPreferredPlacementProperty, mode);
	}

	public static DropDownPlacement GetDropDownPreferredPlacement(Windows.UI.Xaml.Controls.ComboBox combo)
	{
		return (DropDownPlacement)combo.GetValue(DropDownPreferredPlacementProperty);
	}
}

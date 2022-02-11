using System;

namespace Windows.UI.Xaml.Controls;

public class UserControl : ContentControl
{
	private protected override bool IsTabStopDefaultValue => false;

	private protected override Type GetDefaultStyleKey()
	{
		return null;
	}
}

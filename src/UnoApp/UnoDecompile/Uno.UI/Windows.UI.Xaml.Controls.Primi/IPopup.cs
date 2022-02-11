using System;

namespace Windows.UI.Xaml.Controls.Primitives;

internal interface IPopup
{
	bool IsOpen { get; set; }

	UIElement Child { get; set; }

	event EventHandler<object> Closed;

	event EventHandler<object> Opened;
}

namespace Windows.UI.Xaml;

internal interface ICustomClippingElement
{
	bool AllowClippingToLayoutSlot { get; }

	bool ForceClippingToLayoutSlot { get; }
}

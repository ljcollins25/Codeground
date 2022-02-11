namespace Windows.UI.Xaml.Controls;

public interface ICommandBarElement2
{
	int DynamicOverflowOrder { get; set; }

	bool IsInOverflow { get; }
}

namespace Windows.UI.Xaml.Controls;

public interface IMenu
{
	IMenu ParentMenu { get; set; }

	void Close();
}

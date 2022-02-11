namespace Windows.UI.Xaml.Controls;

public interface IMenuPresenter
{
	IMenu OwningMenu { get; set; }

	ISubMenuOwner Owner { get; set; }

	IMenuPresenter SubPresenter { get; set; }

	void CloseSubMenu();
}

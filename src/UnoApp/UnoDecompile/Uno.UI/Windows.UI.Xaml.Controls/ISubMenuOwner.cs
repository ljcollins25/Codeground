using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

public interface ISubMenuOwner
{
	bool IsSubMenuOpen { get; }

	bool IsSubMenuPositionedAbsolutely { get; }

	ISubMenuOwner ParentOwner { get; set; }

	void PrepareSubMenu();

	void OpenSubMenu(Point position);

	void PositionSubMenu(Point position);

	void ClosePeerSubMenus();

	void CloseSubMenu();

	void CloseSubMenuTree();

	void DelayCloseSubMenu();

	void CancelCloseSubMenu();

	void RaiseAutomationPeerExpandCollapse(bool isOpen);
}

using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class NavigationViewItemAutomationPeer : FrameworkElementAutomationPeer, IExpandCollapseProvider
{
	private enum AutomationOutput
	{
		Position,
		Size
	}

	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			ExpandCollapseState result = ExpandCollapseState.LeafNode;
			if (base.Owner is NavigationViewItem navigationViewItem)
			{
				result = (navigationViewItem.IsExpanded ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
			}
			return result;
		}
	}

	public NavigationViewItemAutomationPeer(NavigationViewItem navigationViewItem)
		: base(navigationViewItem)
	{
	}

	protected override string GetNameCore()
	{
		string text = base.GetNameCore();
		if (string.IsNullOrEmpty(text) && base.Owner is NavigationViewItem navigationViewItem)
		{
			text = SharedHelpers.TryGetStringRepresentationFromObject(navigationViewItem.Content);
		}
		if (string.IsNullOrEmpty(text))
		{
			text = ResourceAccessor.GetLocalizedStringResource("NavigationViewItemDefaultControlName");
		}
		return text;
	}

	protected override object GetPatternCore(PatternInterface pattern)
	{
		if (pattern == PatternInterface.SelectionItem || (pattern == PatternInterface.ExpandCollapse && HasChildren()))
		{
			return this;
		}
		return base.GetPatternCore(pattern);
	}

	protected override string GetClassNameCore()
	{
		return "NavigationViewItem";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		if (IsOnTopNavigation())
		{
			return AutomationControlType.TabItem;
		}
		return AutomationControlType.ListItem;
	}

	protected override int GetPositionInSetCore()
	{
		int num = 0;
		if (IsOnTopNavigation() && !IsOnFooterNavigation())
		{
			return GetPositionOrSetCountInTopNavHelper(AutomationOutput.Position);
		}
		return GetPositionOrSetCountInLeftNavHelper(AutomationOutput.Position);
	}

	protected override int GetSizeOfSetCore()
	{
		int result = 0;
		if (IsOnTopNavigation() && !IsOnFooterNavigation())
		{
			NavigationView parentNavigationView = GetParentNavigationView();
			if (parentNavigationView != null)
			{
				result = GetPositionOrSetCountInTopNavHelper(AutomationOutput.Size);
			}
		}
		else
		{
			result = GetPositionOrSetCountInLeftNavHelper(AutomationOutput.Size);
		}
		return result;
	}

	protected override int GetLevelCore()
	{
		if (base.Owner is NavigationViewItemBase navigationViewItemBase)
		{
			NavigationViewItemBase navigationViewItemBase2 = navigationViewItemBase;
			if (navigationViewItemBase2.IsTopLevelItem)
			{
				return 1;
			}
			NavigationView parentNavigationView = GetParentNavigationView();
			if (parentNavigationView != null)
			{
				IndexPath indexPathForContainer = parentNavigationView.GetIndexPathForContainer(navigationViewItemBase);
				if (indexPathForContainer != null)
				{
					return indexPathForContainer.GetSize() - 1;
				}
			}
		}
		return 0;
	}

	private void Invoke()
	{
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null && base.Owner is NavigationViewItem navigationViewItem)
		{
			if (navigationViewItem == parentNavigationView.SettingsItem)
			{
				parentNavigationView.OnSettingsInvoked();
			}
			else
			{
				parentNavigationView.OnNavigationViewItemInvoked(navigationViewItem);
			}
		}
	}

	public void Collapse()
	{
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null && base.Owner is NavigationViewItem item)
		{
			parentNavigationView.Collapse(item);
			RaiseExpandCollapseAutomationEvent(ExpandCollapseState.Collapsed);
		}
	}

	public void Expand()
	{
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null && base.Owner is NavigationViewItem item)
		{
			parentNavigationView.Expand(item);
			RaiseExpandCollapseAutomationEvent(ExpandCollapseState.Expanded);
		}
	}

	internal void RaiseExpandCollapseAutomationEvent(ExpandCollapseState newState)
	{
		if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			ExpandCollapseState expandCollapseState = ((newState != ExpandCollapseState.Expanded) ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
			RaisePropertyChangedEvent(ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty, expandCollapseState, newState);
		}
	}

	private NavigationView GetParentNavigationView()
	{
		NavigationView result = null;
		if (base.Owner is NavigationViewItemBase navigationViewItemBase)
		{
			result = navigationViewItemBase.GetNavigationView();
		}
		return result;
	}

	private int GetNavigationViewItemCountInPrimaryList()
	{
		int result = 0;
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null)
		{
			result = parentNavigationView.GetNavigationViewItemCountInPrimaryList();
		}
		return result;
	}

	private int GetNavigationViewItemCountInTopNav()
	{
		int result = 0;
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null)
		{
			result = parentNavigationView.GetNavigationViewItemCountInTopNav();
		}
		return result;
	}

	private bool IsSettingsItem()
	{
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null)
		{
			NavigationViewItem navigationViewItem = base.Owner as NavigationViewItem;
			object settingsItem = parentNavigationView.SettingsItem;
			if (navigationViewItem != null && settingsItem != null && (navigationViewItem == settingsItem || navigationViewItem.Content == settingsItem))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsOnTopNavigation()
	{
		NavigationViewRepeaterPosition navigationViewRepeaterPosition = GetNavigationViewRepeaterPosition();
		if (navigationViewRepeaterPosition != 0)
		{
			return navigationViewRepeaterPosition != NavigationViewRepeaterPosition.LeftFooter;
		}
		return false;
	}

	private bool IsOnTopNavigationOverflow()
	{
		return GetNavigationViewRepeaterPosition() == NavigationViewRepeaterPosition.TopOverflow;
	}

	private bool IsOnFooterNavigation()
	{
		NavigationViewRepeaterPosition navigationViewRepeaterPosition = GetNavigationViewRepeaterPosition();
		if (navigationViewRepeaterPosition != NavigationViewRepeaterPosition.LeftFooter)
		{
			return navigationViewRepeaterPosition == NavigationViewRepeaterPosition.TopFooter;
		}
		return true;
	}

	private NavigationViewRepeaterPosition GetNavigationViewRepeaterPosition()
	{
		if (base.Owner is NavigationViewItemBase navigationViewItemBase)
		{
			return navigationViewItemBase.Position;
		}
		return NavigationViewRepeaterPosition.LeftNav;
	}

	private ItemsRepeater GetParentItemsRepeater()
	{
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null && base.Owner is NavigationViewItemBase nvib)
		{
			return parentNavigationView.GetParentItemsRepeaterForContainer(nvib);
		}
		return null;
	}

	private int GetPositionOrSetCountInLeftNavHelper(AutomationOutput automationOutput)
	{
		int num = 0;
		ItemsRepeater parentItemsRepeater = GetParentItemsRepeater();
		if (parentItemsRepeater != null)
		{
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(parentItemsRepeater);
			if (automationPeer != null)
			{
				IList<AutomationPeer> children = automationPeer.GetChildren();
				if (children != null)
				{
					int num2 = 0;
					bool flag = false;
					{
						foreach (AutomationPeer item in children)
						{
							UIElement uIElement = parentItemsRepeater.TryGetElement(num2);
							if (uIElement != null)
							{
								if (uIElement is NavigationViewItemHeader)
								{
									if (automationOutput == AutomationOutput.Size && flag)
									{
										return num;
									}
									num = 0;
								}
								else if (uIElement is NavigationViewItem navigationViewItem && navigationViewItem.Visibility == Visibility.Visible)
								{
									num++;
									if (FrameworkElementAutomationPeer.FromElement(navigationViewItem) == this)
									{
										if (automationOutput == AutomationOutput.Position)
										{
											return num;
										}
										flag = true;
									}
								}
							}
							num2++;
						}
						return num;
					}
				}
			}
		}
		return num;
	}

	private int GetPositionOrSetCountInTopNavHelper(AutomationOutput automationOutput)
	{
		int num = 0;
		bool flag = false;
		ItemsRepeater parentItemsRepeater = GetParentItemsRepeater();
		if (parentItemsRepeater != null)
		{
			ItemsSourceView itemsSourceView = parentItemsRepeater.ItemsSourceView;
			if (itemsSourceView != null)
			{
				int count = itemsSourceView.Count;
				for (int i = 0; i < count; i++)
				{
					UIElement uIElement = parentItemsRepeater.TryGetElement(i);
					if (uIElement == null)
					{
						continue;
					}
					if (uIElement is NavigationViewItemHeader)
					{
						if (automationOutput == AutomationOutput.Size && flag)
						{
							break;
						}
						num = 0;
					}
					else
					{
						if (!(uIElement is NavigationViewItem navigationViewItem) || navigationViewItem.Visibility != 0)
						{
							continue;
						}
						num++;
						if (FrameworkElementAutomationPeer.FromElement(navigationViewItem) == this)
						{
							if (automationOutput == AutomationOutput.Position)
							{
								break;
							}
							flag = true;
						}
					}
				}
			}
		}
		return num;
	}

	private bool IsSelected()
	{
		if (base.Owner is NavigationViewItem navigationViewItem)
		{
			return navigationViewItem.IsSelected;
		}
		return false;
	}

	private IRawElementProviderSimple SelectionContainer()
	{
		NavigationView parentNavigationView = GetParentNavigationView();
		if (parentNavigationView != null)
		{
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(parentNavigationView);
			if (automationPeer != null)
			{
				return ProviderFromPeer(automationPeer);
			}
		}
		return null;
	}

	private void AddToSelection()
	{
		ChangeSelection(isSelected: true);
	}

	private void Select()
	{
		ChangeSelection(isSelected: true);
	}

	private void RemoveFromSelection()
	{
		ChangeSelection(isSelected: false);
	}

	private void ChangeSelection(bool isSelected)
	{
		if (base.Owner is NavigationViewItem navigationViewItem)
		{
			navigationViewItem.IsSelected = isSelected;
		}
	}

	private bool HasChildren()
	{
		if (base.Owner is NavigationViewItem navigationViewItem)
		{
			return navigationViewItem.HasChildren();
		}
		return false;
	}
}

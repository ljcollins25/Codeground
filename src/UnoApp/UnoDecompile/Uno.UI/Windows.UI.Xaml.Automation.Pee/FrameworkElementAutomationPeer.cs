using System;
using System.Collections.Generic;
using System.Linq;
using Uno.UI;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class FrameworkElementAutomationPeer : AutomationPeer
{
	public UIElement Owner { get; }

	public FrameworkElementAutomationPeer()
	{
	}

	public FrameworkElementAutomationPeer(object element)
	{
		Owner = element as UIElement;
	}

	public FrameworkElementAutomationPeer(FrameworkElement owner)
	{
		Owner = owner;
	}

	public static AutomationPeer FromElement(UIElement element)
	{
		if (element is IFrameworkElement element2)
		{
			return FromIFrameworkElement(element2);
		}
		return null;
	}

	public static AutomationPeer CreatePeerForElement(UIElement element)
	{
		if (element is IFrameworkElement element2)
		{
			return CreatePeerForIFrameworkElement(element2);
		}
		return null;
	}

	private static AutomationPeer CreatePeerForIFrameworkElement(IFrameworkElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return element.GetAutomationPeer();
	}

	private static AutomationPeer FromIFrameworkElement(IFrameworkElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return element.GetAutomationPeer();
	}

	protected override string GetLocalizedControlTypeCore()
	{
		string localizedControlType = AutomationProperties.GetLocalizedControlType(Owner);
		if (localizedControlType != null && !string.IsNullOrEmpty(localizedControlType))
		{
			return localizedControlType;
		}
		return base.GetLocalizedControlTypeCore();
	}

	protected override AutomationPeer GetLabeledByCore()
	{
		if (AutomationProperties.GetLabeledBy(Owner) is IFrameworkElement frameworkElement)
		{
			return frameworkElement.GetAutomationPeer();
		}
		return base.GetLabeledByCore();
	}

	protected override string GetNameCore()
	{
		string name = AutomationProperties.GetName(Owner);
		if (name != null && !string.IsNullOrEmpty(name))
		{
			return name;
		}
		AutomationPeer labeledBy = GetLabeledBy();
		if (labeledBy != null)
		{
			string name2 = labeledBy.GetName();
			if (name2 != null && !string.IsNullOrEmpty(name2))
			{
				return name2;
			}
		}
		string simpleAccessibilityName = GetSimpleAccessibilityName();
		if (simpleAccessibilityName != null && !string.IsNullOrEmpty(simpleAccessibilityName))
		{
			return simpleAccessibilityName;
		}
		string text = (Owner as FrameworkElement)?.GetAccessibilityInnerText();
		if (text != null && !string.IsNullOrEmpty(text))
		{
			return text;
		}
		return base.GetNameCore();
	}

	protected override IList<AutomationPeer> GetChildrenCore()
	{
		return Owner.GetChildren().OfType<UIElement>().Select(new Func<UIElement, AutomationPeer>(CreatePeerForElement))
			.ToList();
	}

	private string GetSimpleAccessibilityName()
	{
		if (FeatureConfiguration.AutomationPeer.UseSimpleAccessibility)
		{
			UIElement owner = Owner;
			if (owner != null && AutomationProperties.GetAccessibilityView(Owner) != 0)
			{
				return string.Join(", ", from automationPeer in (from child in owner.EnumerateAllChildren().OfType<IFrameworkElement>()
						where child.Visibility == Visibility.Visible
						select child).Select(delegate(IFrameworkElement child)
					{
						AutomationProperties.SetAccessibilityView(child, AccessibilityView.Raw);
						return child;
					}).Select(new Func<IFrameworkElement, AutomationPeer>(FromIFrameworkElement))
					where automationPeer != null
					select automationPeer.GetName() into childName
					where !string.IsNullOrEmpty(childName)
					select childName);
			}
		}
		return null;
	}

	protected override bool IsEnabledCore()
	{
		if (Owner is Control control)
		{
			return control.IsEnabled;
		}
		return true;
	}

	protected override void SetFocusCore()
	{
		if (Owner is Control control)
		{
			control.Focus(FocusState.Programmatic);
		}
	}

	protected override AutomationLandmarkType GetLandmarkTypeCore()
	{
		return AutomationProperties.GetLandmarkType(Owner);
	}
}

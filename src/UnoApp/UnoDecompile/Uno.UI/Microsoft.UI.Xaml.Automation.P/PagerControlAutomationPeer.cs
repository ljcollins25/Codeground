using System;
using Microsoft.UI.Xaml.Controls;
using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class PagerControlAutomationPeer : FrameworkElementAutomationPeer, ISelectionProvider
{
	public bool CanSelectMultiple => false;

	public bool IsSelectionRequired => true;

	public PagerControlAutomationPeer(PagerControl owner)
		: base(owner)
	{
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.Selection)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "PagerControl";
	}

	protected override string GetNameCore()
	{
		string text = base.GetNameCore();
		if (string.IsNullOrEmpty(text) && base.Owner is PagerControl pagerControl)
		{
			text = SharedHelpers.TryGetStringRepresentationFromObject(pagerControl.GetValue(AutomationProperties.NameProperty));
		}
		return text;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Menu;
	}

	protected override AutomationLandmarkType GetLandmarkTypeCore()
	{
		return AutomationLandmarkType.Navigation;
	}

	private PagerControl GetImpl()
	{
		PagerControl result = null;
		if (base.Owner is PagerControl pagerControl)
		{
			result = pagerControl;
		}
		return result;
	}

	IRawElementProviderSimple[] ISelectionProvider.GetSelection()
	{
		return Array.Empty<IRawElementProviderSimple>();
	}

	internal void RaiseSelectionChanged(double oldIndex, double newIndex)
	{
		if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			RaisePropertyChangedEvent(SelectionPatternIdentifiers.SelectionProperty, oldIndex, newIndex);
		}
	}
}

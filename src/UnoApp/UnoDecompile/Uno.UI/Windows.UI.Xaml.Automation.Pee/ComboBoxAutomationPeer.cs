using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class ComboBoxAutomationPeer : SelectorAutomationPeer, IValueProvider, IExpandCollapseProvider, IWindowProvider
{
	[NotImplemented]
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			throw new NotImplementedException("The member ExpandCollapseState ComboBoxAutomationPeer.ExpandCollapseState is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public bool IsReadOnly
	{
		get
		{
			throw new NotImplementedException("The member bool ComboBoxAutomationPeer.IsReadOnly is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public string Value
	{
		get
		{
			throw new NotImplementedException("The member string ComboBoxAutomationPeer.Value is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public WindowInteractionState InteractionState
	{
		get
		{
			throw new NotImplementedException("The member WindowInteractionState ComboBoxAutomationPeer.InteractionState is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public bool IsModal
	{
		get
		{
			throw new NotImplementedException("The member bool ComboBoxAutomationPeer.IsModal is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public bool IsTopmost
	{
		get
		{
			throw new NotImplementedException("The member bool ComboBoxAutomationPeer.IsTopmost is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public bool Maximizable
	{
		get
		{
			throw new NotImplementedException("The member bool ComboBoxAutomationPeer.Maximizable is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public bool Minimizable
	{
		get
		{
			throw new NotImplementedException("The member bool ComboBoxAutomationPeer.Minimizable is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public WindowVisualState VisualState
	{
		get
		{
			throw new NotImplementedException("The member WindowVisualState ComboBoxAutomationPeer.VisualState is not implemented in Uno.");
		}
	}

	[NotImplemented]
	public ComboBoxAutomationPeer(ComboBox owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxAutomationPeer", "ComboBoxAutomationPeer.ComboBoxAutomationPeer(ComboBox owner)");
	}

	[NotImplemented]
	public void Collapse()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxAutomationPeer", "void ComboBoxAutomationPeer.Collapse()");
	}

	[NotImplemented]
	public void Expand()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxAutomationPeer", "void ComboBoxAutomationPeer.Expand()");
	}

	[NotImplemented]
	public void SetValue(string value)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxAutomationPeer", "void ComboBoxAutomationPeer.SetValue(string value)");
	}

	[NotImplemented]
	public void Close()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxAutomationPeer", "void ComboBoxAutomationPeer.Close()");
	}

	[NotImplemented]
	public void SetVisualState(WindowVisualState state)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxAutomationPeer", "void ComboBoxAutomationPeer.SetVisualState(WindowVisualState state)");
	}

	[NotImplemented]
	public bool WaitForInputIdle(int milliseconds)
	{
		throw new NotImplementedException("The member bool ComboBoxAutomationPeer.WaitForInputIdle(int milliseconds) is not implemented in Uno.");
	}
}

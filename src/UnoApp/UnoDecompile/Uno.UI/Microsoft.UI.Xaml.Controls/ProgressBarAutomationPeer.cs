using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Controls;

public class ProgressBarAutomationPeer : AutomationPeer, IRangeValueProvider
{
	private readonly ProgressBar _owner;

	public bool IsReadOnly => true;

	public double Value => _owner.Value;

	public double SmallChange => double.NaN;

	public double LargeChange => double.NaN;

	public double Minimum => _owner.Minimum;

	public double Maximum => _owner.Maximum;

	public ProgressBarAutomationPeer(ProgressBar owner)
	{
		_owner = owner;
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.RangeValue)
		{
			if (_owner.IsIndeterminate)
			{
				return null;
			}
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "ProgressBar";
	}

	protected override string GetNameCore()
	{
		string nameCore = base.GetNameCore();
		ProgressBar owner = _owner;
		if (owner.ShowError)
		{
			return "Error" + nameCore;
		}
		if (owner.ShowPaused)
		{
			return "Busy" + nameCore;
		}
		if (owner.IsIndeterminate)
		{
			return "Paused" + nameCore;
		}
		return nameCore;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.ProgressBar;
	}

	public void SetValue(double value)
	{
		_owner.Value = value;
	}
}

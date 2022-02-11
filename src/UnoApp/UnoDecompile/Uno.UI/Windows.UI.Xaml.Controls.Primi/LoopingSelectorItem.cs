using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls.Primitives;

public class LoopingSelectorItem : ContentControl
{
	internal enum State
	{
		Normal,
		Expanded,
		Selected,
		PointerOver,
		Pressed
	}

	private State _state;

	private int _visualIndex;

	private LoopingSelector _pParentNoRef;

	private bool _hasPeerBeenCreated;

	internal LoopingSelectorItem()
	{
		_state = State.Normal;
		_visualIndex = 0;
		_pParentNoRef = null;
		_hasPeerBeenCreated = false;
		InitializeImpl();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		return base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		return base.ArrangeOverride(finalSize);
	}

	private void InitializeImpl()
	{
		base.DefaultStyleKey = typeof(LoopingSelectorItem);
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs pEventArgs)
	{
		PointerDeviceType pointerDeviceType = PointerDeviceType.Touch;
		PointerPoint currentPoint = pEventArgs.GetCurrentPoint(null);
		if (currentPoint == null)
		{
			return;
		}
		PointerDevice pointerDevice = currentPoint.PointerDevice;
		if (pointerDevice != null)
		{
			pointerDeviceType = pointerDevice.PointerDeviceType;
			if (pointerDeviceType == PointerDeviceType.Mouse && _state != State.Selected)
			{
				SetState(State.PointerOver, useTransitions: false);
			}
		}
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		if (_state != State.Selected)
		{
			SetState(State.Pressed, useTransitions: false);
		}
	}

	protected override void OnPointerExited(PointerRoutedEventArgs args)
	{
		if (_state != State.Selected)
		{
			SetState(State.Normal, useTransitions: false);
		}
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs args)
	{
		if (_state != State.Selected)
		{
			SetState(State.Normal, useTransitions: false);
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		LoopingSelectorItemAutomationPeer result = new LoopingSelectorItemAutomationPeer(this);
		_hasPeerBeenCreated = true;
		return result;
	}

	private void GoToState(State newState, bool useTransitions)
	{
		string stateName = null;
		switch (newState)
		{
		case State.Normal:
			stateName = "Normal";
			break;
		case State.Expanded:
			stateName = "Expanded";
			break;
		case State.Selected:
			stateName = "Selected";
			break;
		case State.PointerOver:
			stateName = "PointerOver";
			break;
		case State.Pressed:
			stateName = "Pressed";
			break;
		}
		VisualStateManager.GoToState(this, stateName, useTransitions);
	}

	internal void SetState(State newState, bool useTransitions)
	{
		if (newState != _state)
		{
			GoToState(newState, useTransitions);
			_state = newState;
		}
	}

	internal void AutomationSelect()
	{
		LoopingSelector ppValue = null;
		GetParentNoRef(out ppValue);
		ppValue.AutomationScrollToVisualIdx(_visualIndex, ignoreScrollingState: true);
	}

	internal void AutomationGetSelectionContainerUIAPeer(out AutomationPeer ppPeer)
	{
		LoopingSelector ppValue = null;
		GetParentNoRef(out ppValue);
		AutomationPeer automationPeer = (ppPeer = FrameworkElementAutomationPeer.CreatePeerForElement(this));
	}

	internal void AutomationGetIsSelected(out bool value)
	{
		LoopingSelector ppValue = null;
		GetParentNoRef(out ppValue);
		int selectedIndex = ppValue.SelectedIndex;
		uint itemIndex = 0u;
		ppValue.VisualIndexToItemIndex((uint)_visualIndex, out itemIndex);
		value = selectedIndex == (int)itemIndex;
	}

	internal void AutomationUpdatePeerIfExists(int itemIndex)
	{
		if (_hasPeerBeenCreated)
		{
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(this);
			LoopingSelectorItemAutomationPeer loopingSelectorItemAutomationPeer = automationPeer as LoopingSelectorItemAutomationPeer;
			LoopingSelectorItemAutomationPeer loopingSelectorItemAutomationPeer2 = loopingSelectorItemAutomationPeer;
			loopingSelectorItemAutomationPeer2.UpdateEventSource();
			loopingSelectorItemAutomationPeer2.UpdateItemIndex(itemIndex);
		}
	}

	internal void GetVisualIndex(out int idx)
	{
		idx = _visualIndex;
	}

	internal void SetVisualIndex(int idx)
	{
		_visualIndex = idx;
	}

	internal void SetParent(LoopingSelector pValue)
	{
		_pParentNoRef = pValue;
	}

	internal void GetParentNoRef(out LoopingSelector ppValue)
	{
		ppValue = _pParentNoRef;
	}

	~LoopingSelectorItem()
	{
	}
}

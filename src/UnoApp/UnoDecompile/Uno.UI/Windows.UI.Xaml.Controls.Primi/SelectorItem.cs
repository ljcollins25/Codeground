using System;
using System.Threading.Tasks;
using Uno.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls.Primitives;

public class SelectorItem : ContentControl
{
	private static class CommonStates
	{
		public const string Selected = "Selected";

		public const string Normal = "Normal";

		public const string Over = "PointerOver";

		public const string Pressed = "Pressed";

		public const string OverSelected = "PointerOverSelected";

		public const string PressedSelected = "PressedSelected";
	}

	private static class DisabledStates
	{
		public const string Enabled = "Enabled";

		public const string Disabled = "Disabled";
	}

	private enum ManipulationUpdateKind
	{
		None,
		Begin,
		End,
		Clicked
	}

	private static readonly TimeSpan MinTimeBetweenPressStates = TimeSpan.FromMilliseconds(100.0);

	private string _currentState;

	private uint _goToStateRequest;

	private DateTime _pauseStateUpdateUntil;

	internal bool ShouldHandlePressed { get; set; } = true;


	private bool IsListViewBaseItem
	{
		get
		{
			if (!(this is ListViewItem))
			{
				return this is GridViewItem;
			}
			return true;
		}
	}

	protected override bool CanCreateTemplateWithoutParent { get; } = true;


	private Selector Selector => ItemsControl.ItemsControlFromItemContainer(this) as Selector;

	private bool IsItemClickEnabled
	{
		get
		{
			if (!(Selector is ListViewBase listViewBase))
			{
				return true;
			}
			if (!listViewBase.IsItemClickEnabled)
			{
				return listViewBase.SelectionMode != ListViewSelectionMode.None;
			}
			return true;
		}
	}

	public bool IsSelected
	{
		get
		{
			return (bool)GetValue(IsSelectedProperty);
		}
		set
		{
			SetValue(IsSelectedProperty, value);
		}
	}

	public static DependencyProperty IsSelectedProperty { get; } = DependencyProperty.Register("IsSelected", typeof(bool), typeof(SelectorItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SelectorItem)s)?.OnIsSelectedChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		string stateName = (e.NewValue ? "Enabled" : "Disabled");
		VisualStateManager.GoToState(this, stateName, useTransitions: true);
		base.OnIsEnabledChanged(e);
	}

	internal void ApplyMultiSelectState(bool isSelectionMultiple)
	{
		if (isSelectionMultiple)
		{
			VisualStateManager.GoToState(this, "MultiSelectEnabled", useTransitions: true);
			return;
		}
		string text = VisualStateManager.GetCurrentState(this, "MultiSelectStates")?.Name;
		if (text == "MultiSelectEnabled")
		{
			VisualStateManager.GoToState(this, "MultiSelectDisabled", useTransitions: true);
		}
	}

	private void UpdateCommonStatesWithoutNeedsLayout(ManipulationUpdateKind manipulationUpdate = ManipulationUpdateKind.None)
	{
		using (InterceptSetNeedsLayout())
		{
			UpdateCommonStates(manipulationUpdate);
		}
	}

	private void UpdateCommonStates(ManipulationUpdateKind manipulationUpdate = ManipulationUpdateKind.None)
	{
		string state = GetState(base.IsEnabled, IsSelected, base.IsPointerOver, base.HasPointerCapture);
		uint request = ++_goToStateRequest;
		TimeSpan delay;
		bool pause;
		if (manipulationUpdate == ManipulationUpdateKind.Clicked && _currentState != "PressedSelected" && _currentState != "Pressed")
		{
			VisualStateManager.GoToState(this, _currentState = GetState(base.IsEnabled, IsSelected, base.IsPointerOver, isPressed: true), useTransitions: true);
			_pauseStateUpdateUntil = DateTime.Now + MinTimeBetweenPressStates;
			delay = MinTimeBetweenPressStates;
			pause = false;
		}
		else if (manipulationUpdate == ManipulationUpdateKind.Begin)
		{
			delay = MinTimeBetweenPressStates;
			pause = true;
		}
		else
		{
			delay = _pauseStateUpdateUntil - DateTime.Now;
			pause = false;
		}
		if (delay < TimeSpan.Zero)
		{
			_currentState = state;
			VisualStateManager.GoToState(this, state, useTransitions: true);
			return;
		}
		CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, async delegate
		{
			await Task.Delay(delay);
			if (_goToStateRequest == request)
			{
				_currentState = state;
				VisualStateManager.GoToState(this, state, useTransitions: true);
				if (pause)
				{
					_pauseStateUpdateUntil = DateTime.Now + MinTimeBetweenPressStates;
				}
			}
		});
	}

	private string GetState(bool isEnabled, bool isSelected, bool isOver, bool isPressed)
	{
		string result = "Normal";
		if (isEnabled)
		{
			if (isSelected && isPressed)
			{
				result = "PressedSelected";
			}
			else if (FeatureConfiguration.SelectorItem.UseOverStates && isSelected && isOver)
			{
				result = "PointerOverSelected";
			}
			else if (isSelected)
			{
				result = "Selected";
			}
			else if (isPressed)
			{
				result = "Pressed";
			}
			else if (FeatureConfiguration.SelectorItem.UseOverStates && isOver)
			{
				result = "PointerOver";
			}
		}
		else if (isSelected)
		{
			result = "Selected";
		}
		return result;
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		UpdateCommonStates();
		string stateName = (base.IsEnabled ? "Enabled" : "Disabled");
		VisualStateManager.GoToState(this, stateName, useTransitions: true);
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs args)
	{
		base.OnPointerEntered(args);
		UpdateCommonStatesWithoutNeedsLayout(ManipulationUpdateKind.Begin);
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		if (ShouldHandlePressed && IsItemClickEnabled && args.GetCurrentPoint(this).Properties.IsLeftButtonPressed && CapturePointer(args.Pointer))
		{
			args.Handled = true;
		}
		base.OnPointerPressed(args);
		UpdateCommonStatesWithoutNeedsLayout(ManipulationUpdateKind.Begin);
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		ManipulationUpdateKind manipulationUpdate;
		if (IsCaptured(args.Pointer))
		{
			manipulationUpdate = ManipulationUpdateKind.Clicked;
			Selector?.OnItemClicked(this);
			ReleasePointerCapture(args.Pointer);
			args.Handled = true;
		}
		else
		{
			manipulationUpdate = ManipulationUpdateKind.End;
		}
		base.OnPointerReleased(args);
		UpdateCommonStatesWithoutNeedsLayout(manipulationUpdate);
	}

	protected override void OnPointerExited(PointerRoutedEventArgs args)
	{
		ReleasePointerCapture(args.Pointer);
		base.OnPointerExited(args);
		UpdateCommonStatesWithoutNeedsLayout(ManipulationUpdateKind.End);
	}

	protected override void OnPointerCanceled(PointerRoutedEventArgs args)
	{
		base.OnPointerCanceled(args);
		UpdateCommonStatesWithoutNeedsLayout(ManipulationUpdateKind.End);
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs args)
	{
		base.OnPointerCaptureLost(args);
		UpdateCommonStatesWithoutNeedsLayout(ManipulationUpdateKind.End);
	}

	private IDisposable InterceptSetNeedsLayout()
	{
		return null;
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		base.ChangeVisualState(useTransitions);
		if (!IsListViewBaseItem)
		{
			return;
		}
		ListViewBaseItemVisualStatesCriteria criteria = default(ListViewBaseItemVisualStatesCriteria);
		criteria.isEnabled = base.IsEnabled;
		criteria.isSelected = IsSelected;
		criteria.focusState = base.FocusState;
		criteria.isPressed = base.IsPointerPressed;
		criteria.isPointerOver = base.IsPointerOver;
		if (!(Selector is ListViewBase listViewBase))
		{
			return;
		}
		criteria.isDragging = listViewBase.IsInDragDrop();
		criteria.isDraggedOver = listViewBase.IsDragOverItem(this);
		criteria.dragItemsCount = listViewBase.DragItemsCount();
		criteria.isItemDragPrimary = listViewBase.IsContainerDragDropOwner(this);
		criteria.canDrag = listViewBase.CanDragItems;
		criteria.canReorder = listViewBase.CanReorderItems;
		if (listViewBase.GetIsHolding())
		{
			criteria.isHolding = true;
		}
		criteria.isMultiSelect = listViewBase.IsMultiSelectCheckBoxEnabled;
		ListViewSelectionMode selectionMode = listViewBase.SelectionMode;
		criteria.isSelected &= selectionMode != ListViewSelectionMode.None;
		bool flag = false;
		flag = listViewBase.IsItemClickEnabled;
		if (selectionMode == ListViewSelectionMode.None && !flag)
		{
			criteria.isPressed = false;
			criteria.isPointerOver = false;
		}
		if (criteria.isMultiSelect)
		{
			criteria.isMultiSelect &= listViewBase.SelectionMode == ListViewSelectionMode.Multiple;
		}
		criteria.isInsideListView = true;
		foreach (string item in VisualStatesHelper.GetValidVisualStatesListViewBaseItem(criteria))
		{
			GoToState(useTransitions, item);
		}
	}

	protected virtual void OnIsSelectedChanged(bool oldIsSelected, bool newIsSelected)
	{
		OnIsSelectedChangedPartial(oldIsSelected, newIsSelected);
	}

	private void OnIsSelectedChangedPartial(bool oldIsSelected, bool newIsSelected)
	{
		UpdateCommonStates();
		Selector?.OnSelectorItemIsSelectedChanged(this, oldIsSelected, newIsSelected);
	}
}

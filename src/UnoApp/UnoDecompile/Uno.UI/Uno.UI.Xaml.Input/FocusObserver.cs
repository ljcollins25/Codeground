using System;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class FocusObserver
{
	private readonly ContentRoot _contentRoot;

	private XamlSourceFocusNavigationRequest? _currentInteraction;

	internal FocusObserver(ContentRoot contentRoot)
	{
		_contentRoot = contentRoot ?? throw new ArgumentNullException("contentRoot");
	}

	private Rect GetOriginToComponent(DependencyObject? pOldFocusedElement)
	{
		Rect rect = default(Rect);
		if (pOldFocusedElement != null)
		{
			IFocusable iFocusableForDO = FocusableHelper.GetIFocusableForDO(pOldFocusedElement);
			if (iFocusableForDO == null && pOldFocusedElement is UIElement uIElement)
			{
				rect = uIElement.GetGlobalBounds(ignoreClipping: true);
			}
		}
		Rect result = default(Rect);
		result.X = rect.Left;
		result.Y = rect.Top;
		result.Width = rect.Right - rect.Left;
		result.Height = rect.Bottom - rect.Top;
		return result;
	}

	private Rect GetOriginFromInteraction()
	{
		Rect result = default(Rect);
		if (_currentInteraction != null)
		{
			Rect hintRect = _currentInteraction!.HintRect;
			result = new Rect(new Point(hintRect.X, hintRect.Y), new Point(hintRect.X + hintRect.Width, hintRect.Y + hintRect.Height));
		}
		return result;
	}

	private FocusMovementResult NavigateFocusXY(DependencyObject pComponent, FocusNavigationDirection direction, Rect origin)
	{
		XYFocusOptions xyFocusOptions = default(XYFocusOptions);
		xyFocusOptions.FocusHintRectangle = origin;
		xyFocusOptions.UpdateManifoldsFromFocusHintRectangle = true;
		FocusMovement focusMovement = new FocusMovement(xyFocusOptions, direction, pComponent);
		focusMovement.CanCancel = false;
		focusMovement.CanDepartFocus = false;
		focusMovement.ShouldCompleteAsyncOperation = true;
		return _contentRoot.FocusManager.FindAndSetNextFocus(focusMovement);
	}

	private Rect CalculateNewOrigin(FocusNavigationDirection direction, Rect currentOrigin)
	{
		DependencyObject activeRootVisual = _contentRoot.VisualTree.ActiveRootVisual;
		Rect originToComponent = GetOriginToComponent(activeRootVisual);
		Rect result = currentOrigin;
		switch (direction)
		{
		case FocusNavigationDirection.Left:
		case FocusNavigationDirection.Right:
			result.X = originToComponent.X;
			result.Width = originToComponent.Width;
			break;
		case FocusNavigationDirection.Up:
		case FocusNavigationDirection.Down:
			result.Y = originToComponent.Y;
			result.Height = originToComponent.Height;
			break;
		}
		return result;
	}

	internal bool ProcessNavigateFocusRequest(XamlSourceFocusNavigationRequest focusNavigationRequest)
	{
		bool handled = false;
		UpdateCurrentInteraction(focusNavigationRequest);
		XamlSourceFocusNavigationReason reason = focusNavigationRequest.Reason;
		DependencyObject dependencyObject = null;
		ContentRootType type = _contentRoot.Type;
		DependencyObject dependencyObject2;
		if (type == ContentRootType.XamlIsland)
		{
			DependencyObject rootScrollViewer = _contentRoot.VisualTree.RootScrollViewer;
			dependencyObject2 = rootScrollViewer ?? _contentRoot.VisualTree.ActiveRootVisual;
		}
		else
		{
			dependencyObject2 = _contentRoot.VisualTree.ActiveRootVisual;
		}
		dependencyObject = dependencyObject2;
		FocusNavigationDirection focusNavigationDirectionFromReason = FocusConversionFunctions.GetFocusNavigationDirectionFromReason(reason);
		switch (reason)
		{
		case XamlSourceFocusNavigationReason.First:
		case XamlSourceFocusNavigationReason.Last:
		{
			_contentRoot.InputManager.LastInputDeviceType = FocusConversionFunctions.GetInputDeviceTypeFromDirection(focusNavigationDirectionFromReason);
			bool flag = reason == XamlSourceFocusNavigationReason.Last;
			if (dependencyObject == null)
			{
				return false;
			}
			DependencyObject dependencyObject4 = null;
			dependencyObject4 = ((!flag) ? _contentRoot.FocusManager.GetFirstFocusableElement(dependencyObject) : _contentRoot.FocusManager.GetLastFocusableElement(dependencyObject));
			if (dependencyObject4 == null)
			{
				PopupRoot popupRoot = _contentRoot.VisualTree.PopupRoot;
				if (popupRoot != null)
				{
					dependencyObject4 = ((!flag) ? _contentRoot.FocusManager.GetFirstFocusableElement(popupRoot) : _contentRoot.FocusManager.GetLastFocusableElement(popupRoot));
				}
			}
			if (dependencyObject4 != null)
			{
				_contentRoot.FocusManager.ClearFocus();
				FocusMovement focusMovement2 = new FocusMovement(dependencyObject4, flag ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next, FocusState.Keyboard);
				focusMovement2.CanCancel = false;
				FocusMovementResult focusMovementResult3 = _contentRoot.FocusManager.SetFocusedElement(focusMovement2);
				if (focusMovementResult3.WasMoved)
				{
					handled = StopInteraction();
				}
			}
			else
			{
				Guid correlationId2 = focusNavigationRequest.CorrelationId;
				DepartFocus(focusNavigationDirectionFromReason, correlationId2, ref handled);
			}
			break;
		}
		case XamlSourceFocusNavigationReason.Programmatic:
		case XamlSourceFocusNavigationReason.Restore:
		{
			DependencyObject focusedElement = _contentRoot.FocusManager.FocusedElement;
			if (focusedElement != null)
			{
				handled = StopInteraction();
			}
			else
			{
				if (focusedElement != null || reason != 0)
				{
					break;
				}
				if (dependencyObject == null)
				{
					return false;
				}
				DependencyObject dependencyObject3 = _contentRoot.FocusManager.GetFirstFocusableElement(dependencyObject);
				if (dependencyObject3 == null)
				{
					dependencyObject3 = dependencyObject;
				}
				if (dependencyObject3 != null)
				{
					FocusMovement focusMovement = new FocusMovement(dependencyObject3, FocusNavigationDirection.None, FocusState.Programmatic);
					focusMovement.CanCancel = false;
					FocusMovementResult focusMovementResult2 = _contentRoot.FocusManager.SetFocusedElement(focusMovement);
					if (focusMovementResult2.WasMoved)
					{
						handled = StopInteraction();
					}
				}
			}
			break;
		}
		case XamlSourceFocusNavigationReason.Left:
		case XamlSourceFocusNavigationReason.Up:
		case XamlSourceFocusNavigationReason.Right:
		case XamlSourceFocusNavigationReason.Down:
		{
			if (dependencyObject == null)
			{
				return false;
			}
			_contentRoot.InputManager.LastInputDeviceType = FocusConversionFunctions.GetInputDeviceTypeFromDirection(focusNavigationDirectionFromReason);
			Rect originFromInteraction = GetOriginFromInteraction();
			FocusMovementResult focusMovementResult = NavigateFocusXY(dependencyObject, focusNavigationDirectionFromReason, originFromInteraction);
			if (focusMovementResult.WasMoved)
			{
				handled = StopInteraction();
				break;
			}
			Rect hintRect = focusNavigationRequest.HintRect;
			Rect origin = CalculateNewOrigin(focusNavigationDirectionFromReason, hintRect);
			Guid correlationId = focusNavigationRequest.CorrelationId;
			DepartFocus(focusNavigationDirectionFromReason, origin, correlationId, ref handled);
			break;
		}
		}
		return handled;
	}

	internal void DepartFocus(FocusNavigationDirection direction, Guid correlationId, ref bool handled)
	{
		DependencyObject focusedElement = _contentRoot.FocusManager.FocusedElement;
		Rect originToComponent = GetOriginToComponent(focusedElement);
		DepartFocus(direction, originToComponent, correlationId, ref handled);
	}

	private void DepartFocus(FocusNavigationDirection direction, Rect origin, Guid correlationId, ref bool handled)
	{
		if (!handled)
		{
			XamlSourceFocusNavigationReason? focusNavigationReasonFromDirection = FocusConversionFunctions.GetFocusNavigationReasonFromDirection(direction);
			if (focusNavigationReasonFromDirection.HasValue)
			{
				StartInteraction(focusNavigationReasonFromDirection.Value, origin, correlationId);
				handled = true;
			}
		}
	}

	private void StartInteraction(XamlSourceFocusNavigationReason reason, Rect origin, Guid correlationId)
	{
		XamlSourceFocusNavigationRequest xamlSourceFocusNavigationRequest = (_currentInteraction = new XamlSourceFocusNavigationRequest(reason, origin, correlationId));
	}

	private bool StopInteraction()
	{
		_currentInteraction = null;
		return true;
	}

	protected virtual CoreWindowActivationMode GetActivationMode()
	{
		return CoreWindowActivationMode.None;
	}

	private void UpdateCurrentInteraction(XamlSourceFocusNavigationRequest? pRequest)
	{
		_currentInteraction = pRequest;
	}
}

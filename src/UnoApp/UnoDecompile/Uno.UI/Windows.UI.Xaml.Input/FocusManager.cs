using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DirectUI;
using Uno;
using Uno.Foundation;
using Uno.Foundation.Logging;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Core.Rendering;
using Uno.UI.Xaml.Input;
using Uno.UI.Xaml.Rendering;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;

namespace Windows.UI.Xaml.Input;

public sealed class FocusManager : IFocusManager
{
	private static readonly Lazy<Logger> _log = new Lazy<Logger>(() => typeof(FocusManager).Log());

	private static readonly Dictionary<XamlRoot, object> _focusedElements = new Dictionary<XamlRoot, object>(1);

	private readonly ContentRoot _contentRoot;

	private readonly FocusRectManager _focusRectManager = new FocusRectManager();

	private DependencyObject? _focusedElement;

	private AutomationPeer? _focusedAutomationPeer;

	private DependencyObject? _focusTarget;

	private WeakReference<UIElement>? _focusRectangleUIElement;

	private bool _pluginFocused = true;

	private FocusState _realFocusStateForFocusedElement;

	private FocusObserver? _focusObserver;

	private XYFocus _xyFocus = new XYFocus();

	private bool _canTabOutOfPlugin = true;

	private bool _isPrevFocusTextControl;

	private Control? _engagedControl;

	private bool _focusLocked;

	private bool _ignoreFocusLock;

	private bool _currentFocusOperationCancellable = true;

	private bool _initialFocus;

	private FocusAsyncOperation? _asyncOperation;

	private static bool _isCallingFocusNative;

	private static bool _skipNativeFocus;

	internal DependencyObject? FocusedElement => _focusedElement;

	internal ContentRoot ContentRoot => _contentRoot;

	internal FocusRectManager FocusRectManager => _focusRectManager;

	internal Control? EngagedControl
	{
		get
		{
			return _engagedControl;
		}
		set
		{
			_engagedControl = value;
		}
	}

	internal bool InitialFocus
	{
		get
		{
			return _initialFocus;
		}
		set
		{
			_initialFocus = value;
		}
	}

	internal FocusObserver FocusObserver => _focusObserver ?? throw new InvalidOperationException("Focus observer was not set.");

	public static event EventHandler<FocusManagerGotFocusEventArgs>? GotFocus;

	public static event EventHandler<FocusManagerLostFocusEventArgs>? LostFocus;

	public static event EventHandler<GettingFocusEventArgs>? GettingFocus;

	public static event EventHandler<LosingFocusEventArgs>? LosingFocus;

	internal event EventHandler<FocusedElementRemovedEventArgs>? FocusedElementRemoved;

	public static DependencyObject? FindFirstFocusableElement(DependencyObject? searchScope)
	{
		return FindFirstFocusableElementImpl(searchScope);
	}

	public static DependencyObject? FindLastFocusableElement(DependencyObject? searchScope)
	{
		return FindLastFocusableElementImpl(searchScope);
	}

	public static DependencyObject? FindNextElement(FocusNavigationDirection focusNavigationDirection)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Undefined focus navigation direction was used.");
		}
		return FindNextElementImpl(focusNavigationDirection);
	}

	public static DependencyObject? FindNextElement(FocusNavigationDirection focusNavigationDirection, FindNextElementOptions focusNavigationOptions)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Invalid value of focus navigation direction was used.");
		}
		if (focusNavigationOptions == null)
		{
			throw new ArgumentNullException("focusNavigationOptions");
		}
		return FindNextElementWithOptionsImpl(focusNavigationDirection, focusNavigationOptions);
	}

	public static UIElement? FindNextFocusableElement(FocusNavigationDirection focusNavigationDirection)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Undefined focus navigation direction was used.");
		}
		return FindNextFocusableElementImpl(focusNavigationDirection);
	}

	public static UIElement? FindNextFocusableElement(FocusNavigationDirection focusNavigationDirection, Rect hintRect)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Undefined focus navigation direction was used.");
		}
		return FindNextFocusableElementWithHintImpl(focusNavigationDirection, hintRect);
	}

	public static object? GetFocusedElement()
	{
		return GetFocusedElementImpl();
	}

	public static object? GetFocusedElement(XamlRoot xamlRoot)
	{
		return GetFocusedElementWithRootImpl(xamlRoot);
	}

	public static IAsyncOperation<FocusMovementResult> TryFocusAsync(DependencyObject element, FocusState value)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		if (!Enum.IsDefined(typeof(FocusState), value))
		{
			throw new ArgumentOutOfRangeException("value", "Undefined focus state was used.");
		}
		return TryFocusAsyncImpl(element, value);
	}

	public static bool TryMoveFocus(FocusNavigationDirection focusNavigationDirection)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Undefined focus navigation direction was used.");
		}
		return TryMoveFocusImpl(focusNavigationDirection);
	}

	public static bool TryMoveFocus(FocusNavigationDirection focusNavigationDirection, FindNextElementOptions focusNavigationOptions)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Invalid value of focus navigation direction was used.");
		}
		if (focusNavigationDirection == FocusNavigationDirection.Next || focusNavigationDirection == FocusNavigationDirection.Previous || focusNavigationDirection == FocusNavigationDirection.None)
		{
			throw new ArgumentOutOfRangeException("Focus navigation directions Next, Previous, and None are not supported when using FindNextElementOptions", "focusNavigationDirection");
		}
		if (focusNavigationOptions == null)
		{
			throw new ArgumentNullException("focusNavigationOptions");
		}
		return TryMoveFocusImpl(focusNavigationDirection);
	}

	public static IAsyncOperation<FocusMovementResult> TryMoveFocusAsync(FocusNavigationDirection focusNavigationDirection)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Undefined focus navigation direction was used.");
		}
		return TryMoveFocusAsyncImpl(focusNavigationDirection);
	}

	public static IAsyncOperation<FocusMovementResult> TryMoveFocusAsync(FocusNavigationDirection focusNavigationDirection, FindNextElementOptions focusNavigationOptions)
	{
		if (!Enum.IsDefined(typeof(FocusNavigationDirection), focusNavigationDirection))
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection", "Invalid value of focus navigation direction was used.");
		}
		if (focusNavigationDirection == FocusNavigationDirection.Next || focusNavigationDirection == FocusNavigationDirection.Previous || focusNavigationDirection == FocusNavigationDirection.None)
		{
			throw new ArgumentOutOfRangeException("Focus navigation directions Next, Previous, and None are not supported when using FindNextElementOptions", "focusNavigationDirection");
		}
		if (focusNavigationOptions == null)
		{
			throw new ArgumentNullException("focusNavigationOptions");
		}
		return TryMoveFocusAsyncImpl(focusNavigationDirection);
	}

	internal FocusManager(ContentRoot contentRoot)
	{
		_contentRoot = contentRoot ?? throw new ArgumentNullException("contentRoot");
	}

	internal void SetIgnoreFocusLock(bool ignore)
	{
		_ignoreFocusLock = ignore;
	}

	internal void SetFocusObserver(FocusObserver focusObserver)
	{
		_focusObserver = focusObserver;
	}

	internal FocusMovementResult SetFocusedElement(FocusMovement movement)
	{
		DependencyObject dependencyObject = movement.Target;
		if (dependencyObject == null)
		{
			return new FocusMovementResult();
		}
		if (!IsFocusable(dependencyObject))
		{
			dependencyObject = GetFirstFocusableElement(dependencyObject);
			if (dependencyObject == null || !IsFocusable(dependencyObject))
			{
				return new FocusMovementResult();
			}
		}
		FocusNavigationDirection direction = movement.Direction;
		return UpdateFocus(new FocusMovement(dependencyObject, movement));
	}

	internal void ClearFocus()
	{
		UpdateFocus(new FocusMovement(null, FocusNavigationDirection.None, FocusState.Unfocused));
	}

	private void ReleaseFocusRectManagerResources()
	{
		_focusRectManager.ReleaseResources(isDeviceLost: false, cleanupDComp: false, clearPCData: true);
	}

	private void CleanupDeviceRelatedResources(bool cleanupDComp)
	{
		_focusRectManager.ReleaseResources(isDeviceLost: true, cleanupDComp, clearPCData: false);
	}

	private bool FocusedElementIsBehindFullWindowMediaRoot()
	{
		return _contentRoot.VisualTree?.IsBehindFullWindowMediaRoot(_focusedElement) ?? false;
	}

	private DependencyObject? GetFirstFocusableElementFromRoot(bool useReverseDirection)
	{
		DependencyObject dependencyObject = null;
		DependencyObject activeRootVisual = _contentRoot.VisualTree.ActiveRootVisual;
		if (activeRootVisual != null)
		{
			dependencyObject = (useReverseDirection ? GetLastFocusableElement(activeRootVisual, dependencyObject) : GetFirstFocusableElement(activeRootVisual, dependencyObject));
		}
		return dependencyObject;
	}

	internal DependencyObject? GetFirstFocusableElement(DependencyObject searchStartLocation, DependencyObject? focusCandidate = null)
	{
		focusCandidate = GetFirstFocusableElementInternal(searchStartLocation, focusCandidate);
		if (focusCandidate != null && !IsFocusable(focusCandidate) && CanHaveFocusableChildren(focusCandidate))
		{
			focusCandidate = GetFirstFocusableElement(focusCandidate);
		}
		return focusCandidate;
	}

	private DependencyObject? GetFirstFocusableElementInternal(DependencyObject searchStartLocation, DependencyObject? firstFocusedElement)
	{
		bool flag = false;
		DependencyObject dependencyObject = (searchStartLocation as UIElement)?.GetFirstFocusableElementOverride();
		if (dependencyObject != null)
		{
			flag = IsFocusable(dependencyObject) || CanHaveFocusableChildren(dependencyObject);
		}
		if (flag)
		{
			if (firstFocusedElement == null || GetTabIndex(dependencyObject) < GetTabIndex(firstFocusedElement))
			{
				firstFocusedElement = dependencyObject;
			}
			return firstFocusedElement;
		}
		IEnumerable<DependencyObject> focusChildrenInTabOrder = FocusProperties.GetFocusChildrenInTabOrder(searchStartLocation);
		foreach (DependencyObject item in focusChildrenInTabOrder)
		{
			if (item == null || !IsVisible(item))
			{
				continue;
			}
			bool flag2 = CanHaveFocusableChildren(item);
			if (IsPotentialTabStop(item))
			{
				if (firstFocusedElement == null && (IsFocusable(item) || flag2))
				{
					firstFocusedElement = item;
				}
				if ((IsFocusable(item) || flag2) && GetTabIndex(item) < GetTabIndex(firstFocusedElement))
				{
					firstFocusedElement = item;
				}
			}
			else if (flag2)
			{
				firstFocusedElement = GetFirstFocusableElementInternal(item, firstFocusedElement);
			}
		}
		return firstFocusedElement;
	}

	internal DependencyObject? GetLastFocusableElement(DependencyObject searchStartLocation, DependencyObject? focusCandidate = null)
	{
		focusCandidate = GetLastFocusableElementInternal(searchStartLocation, focusCandidate);
		if (focusCandidate != null && CanHaveFocusableChildren(focusCandidate))
		{
			focusCandidate = GetLastFocusableElement(focusCandidate);
		}
		return focusCandidate;
	}

	private DependencyObject? GetLastFocusableElementInternal(DependencyObject searchStartLocation, DependencyObject? lastFocusedElement)
	{
		bool flag = false;
		DependencyObject dependencyObject = (searchStartLocation as UIElement)?.GetLastFocusableElementOverride();
		if (dependencyObject != null)
		{
			flag = IsFocusable(dependencyObject) || CanHaveFocusableChildren(dependencyObject);
		}
		if (flag)
		{
			if (lastFocusedElement == null || GetTabIndex(dependencyObject) >= GetTabIndex(lastFocusedElement))
			{
				lastFocusedElement = dependencyObject;
			}
			return lastFocusedElement;
		}
		IEnumerable<DependencyObject> focusChildrenInTabOrder = FocusProperties.GetFocusChildrenInTabOrder(searchStartLocation);
		foreach (DependencyObject item in focusChildrenInTabOrder)
		{
			if (item == null || !IsVisible(item))
			{
				continue;
			}
			bool flag2 = CanHaveFocusableChildren(item);
			if (IsPotentialTabStop(item))
			{
				if (lastFocusedElement == null && (IsFocusable(item) || flag2))
				{
					lastFocusedElement = item;
				}
				if ((IsFocusable(item) || flag2) && GetTabIndex(item) >= GetTabIndex(lastFocusedElement))
				{
					lastFocusedElement = item;
				}
			}
			else if (flag2)
			{
				lastFocusedElement = GetLastFocusableElementInternal(item, lastFocusedElement);
			}
		}
		return lastFocusedElement;
	}

	private bool CanProcessTabStop(bool isReverse)
	{
		bool flag = true;
		bool flag2 = false;
		bool flag3 = false;
		DependencyObject focusedElement = _focusedElement;
		if (IsFocusedElementInPopup())
		{
			return true;
		}
		if (isReverse)
		{
			flag2 = IsFocusOnFirstTabStop();
		}
		else
		{
			flag3 = IsFocusOnLastTabStop();
		}
		if (flag2 || flag3)
		{
			flag = false;
		}
		if (flag)
		{
			DependencyObject firstFocusableElementFromRoot = GetFirstFocusableElementFromRoot(!isReverse);
			if (firstFocusableElementFromRoot != null)
			{
				UIElement parentElement = GetParentElement(firstFocusableElementFromRoot);
				if (parentElement != null && GetTabNavigation(parentElement) == KeyboardNavigationMode.Once && parentElement == GetParentElement(focusedElement))
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
		}
		else if (flag3 || flag2)
		{
			if (GetTabNavigation(focusedElement) == KeyboardNavigationMode.Cycle)
			{
				flag = true;
			}
			else
			{
				for (UIElement parentElement2 = GetParentElement(focusedElement); parentElement2 != null; parentElement2 = GetParentElement(parentElement2))
				{
					if (GetTabNavigation(parentElement2) == KeyboardNavigationMode.Cycle)
					{
						flag = true;
						break;
					}
				}
			}
		}
		return flag;
	}

	private TabStopCandidateSearchResult GetTabStopCandidateElement(bool isReverse, bool queryOnly)
	{
		DependencyObject dependencyObject = null;
		bool didCycleFocusAtRootVisualScope = false;
		DependencyObject activeRootVisual = _contentRoot.VisualTree.ActiveRootVisual;
		if (activeRootVisual == null)
		{
			return new TabStopCandidateSearchResult(didCycleFocusAtRootVisualScope: false, null);
		}
		bool flag = false;
		if (_focusedElement != null && _canTabOutOfPlugin)
		{
			flag = CanProcessTabStop(isReverse);
		}
		if (_focusedElement == null || FocusedElementIsBehindFullWindowMediaRoot())
		{
			dependencyObject = (isReverse ? GetLastFocusableElement(activeRootVisual) : GetFirstFocusableElement(activeRootVisual));
			didCycleFocusAtRootVisualScope = true;
		}
		else if (!isReverse)
		{
			dependencyObject = GetNextTabStop();
			if (dependencyObject == null && (!_canTabOutOfPlugin || flag || queryOnly))
			{
				dependencyObject = GetFirstFocusableElement(activeRootVisual);
				didCycleFocusAtRootVisualScope = true;
			}
		}
		else
		{
			dependencyObject = GetPreviousTabStop();
			if (dependencyObject == null && (!_canTabOutOfPlugin || flag || queryOnly))
			{
				dependencyObject = GetLastFocusableElement(activeRootVisual);
				didCycleFocusAtRootVisualScope = true;
			}
		}
		return new TabStopCandidateSearchResult(didCycleFocusAtRootVisualScope, dependencyObject);
	}

	private DependencyObject? ProcessTabStopInternal(bool isReverse, bool queryOnly)
	{
		DependencyObject result = null;
		bool flag = false;
		bool flag2 = false;
		DependencyObject dependencyObject = null;
		DependencyObject dependencyObject2 = null;
		DependencyObject dependencyObject3 = null;
		TabStopCandidateSearchResult tabStopCandidateElement = GetTabStopCandidateElement(isReverse, queryOnly);
		flag2 = tabStopCandidateElement.DidCycleFocusAtRootVisualScope;
		dependencyObject2 = tabStopCandidateElement.Candidate;
		TabStopProcessingResult? tabStopProcessingResult = (_focusedElement as UIElement)?.ProcessTabStop(_focusedElement, dependencyObject2, isReverse, flag2);
		dependencyObject3 = tabStopProcessingResult?.NewTabStop;
		flag = tabStopProcessingResult?.IsOverriden ?? false;
		if (flag)
		{
			dependencyObject = dependencyObject3;
		}
		if (!flag && dependencyObject == null && dependencyObject2 != null)
		{
			dependencyObject = dependencyObject2;
		}
		if (dependencyObject != null)
		{
			result = dependencyObject;
			dependencyObject = null;
		}
		return result;
	}

	private bool ProcessTabStop(bool isReverseDirection)
	{
		bool result = false;
		bool queryOnly = false;
		DependencyObject dependencyObject = ProcessTabStopInternal(isReverseDirection, queryOnly);
		FocusNavigationDirection direction = (isReverseDirection ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);
		if (dependencyObject != null)
		{
			FocusMovementResult focusMovementResult = SetFocusedElement(new FocusMovement(dependencyObject, direction, FocusState.Keyboard));
			result = focusMovementResult.WasMoved;
		}
		else
		{
			Guid correlationId = Guid.NewGuid();
			bool handled = false;
			FocusObserver.DepartFocus(direction, correlationId, ref handled);
		}
		return result;
	}

	internal UIElement? GetFirstFocusableElement()
	{
		DependencyObject dependencyObject = null;
		UIElement uIElement = null;
		if (_contentRoot.VisualTree != null)
		{
			PopupRoot popupRoot = _contentRoot.VisualTree.PopupRoot;
			if (popupRoot != null)
			{
				Popup topmostPopup = popupRoot.GetTopmostPopup(PopupRoot.PopupFilter.LightDismissOrFlyout);
				if (topmostPopup != null)
				{
					uIElement = topmostPopup;
				}
			}
			if (uIElement == null)
			{
				dependencyObject = GetFirstFocusableElementFromRoot(useReverseDirection: false);
				if (dependencyObject != null)
				{
					uIElement = ((!(dependencyObject is UIElement uIElement2)) ? GetParentElement(dependencyObject) : uIElement2);
				}
			}
		}
		return uIElement;
	}

	private UIElement? GetNextFocusableElement()
	{
		DependencyObject nextTabStop = GetNextTabStop();
		UIElement result = null;
		if (nextTabStop != null)
		{
			result = ((!(nextTabStop is UIElement uIElement)) ? GetParentElement(nextTabStop) : uIElement);
		}
		return result;
	}

	internal DependencyObject? GetNextTabStop(DependencyObject? pCurrentTabStop = null, bool bIgnoreCurrentTabStopScope = false)
	{
		DependencyObject dependencyObject = null;
		DependencyObject dependencyObject2 = pCurrentTabStop ?? _focusedElement;
		DependencyObject dependencyObject3 = null;
		DependencyObject dependencyObject4 = null;
		if (dependencyObject2 == null || _contentRoot.VisualTree == null)
		{
			return null;
		}
		dependencyObject3 = dependencyObject2;
		dependencyObject4 = (dependencyObject2 as UIElement)?.GetNextTabStopOverride();
		dependencyObject = dependencyObject4;
		if (dependencyObject == null && !bIgnoreCurrentTabStopScope && IsVisible(dependencyObject2) && (CanHaveChildren(dependencyObject2) || CanHaveFocusableChildren(dependencyObject2)))
		{
			dependencyObject = GetFirstFocusableElement(dependencyObject2, dependencyObject);
		}
		if (dependencyObject == null)
		{
			bool bCurrentPassed = false;
			DependencyObject dependencyObject5 = dependencyObject2;
			DependencyObject dependencyObject6 = GetFocusParent(dependencyObject2);
			bool flag = dependencyObject6 == _contentRoot.VisualTree.RootVisual;
			while (dependencyObject6 != null && !flag && dependencyObject == null)
			{
				if (IsValidTabStopSearchCandidate(dependencyObject5) && GetTabNavigation(dependencyObject5) == KeyboardNavigationMode.Cycle)
				{
					dependencyObject = ((dependencyObject5 != GetParentElement(dependencyObject2)) ? GetFirstFocusableElement(dependencyObject5, dependencyObject5) : GetFirstFocusableElement(dependencyObject5));
					break;
				}
				if (IsValidTabStopSearchCandidate(dependencyObject6) && GetTabNavigation(dependencyObject6) == KeyboardNavigationMode.Once)
				{
					dependencyObject5 = dependencyObject6;
					dependencyObject6 = GetFocusParent(dependencyObject6);
					if (dependencyObject6 == null)
					{
						break;
					}
				}
				else if (!IsValidTabStopSearchCandidate(dependencyObject6))
				{
					UIElement parentElement = GetParentElement(dependencyObject6);
					if (parentElement == null)
					{
						dependencyObject6 = GetRootOfPopupSubTree(dependencyObject5);
						if (dependencyObject6 != null)
						{
							dependencyObject = GetNextTabStopInternal(dependencyObject6, dependencyObject5, dependencyObject, ref bCurrentPassed, ref dependencyObject3);
							if (dependencyObject != null && !IsFocusable(dependencyObject))
							{
								dependencyObject = GetFirstFocusableElement(dependencyObject);
							}
							if (dependencyObject == null)
							{
								dependencyObject = GetFirstFocusableElement(dependencyObject6);
							}
							break;
						}
						dependencyObject6 = _contentRoot.VisualTree.ActiveRootVisual;
					}
					else if (parentElement == null || GetTabNavigation(parentElement) != KeyboardNavigationMode.Once)
					{
						dependencyObject6 = ((parentElement == null) ? _contentRoot.VisualTree.ActiveRootVisual : parentElement);
					}
					else
					{
						dependencyObject5 = parentElement;
						dependencyObject6 = GetFocusParent(parentElement);
						if (dependencyObject6 == null)
						{
							break;
						}
					}
				}
				dependencyObject = GetNextTabStopInternal(dependencyObject6, dependencyObject5, dependencyObject, ref bCurrentPassed, ref dependencyObject3);
				if (dependencyObject != null && !IsFocusable(dependencyObject) && CanHaveFocusableChildren(dependencyObject))
				{
					dependencyObject = GetFirstFocusableElement(dependencyObject);
				}
				if (dependencyObject != null)
				{
					break;
				}
				if (IsValidTabStopSearchCandidate(dependencyObject6))
				{
					dependencyObject5 = dependencyObject6;
				}
				dependencyObject6 = GetFocusParent(dependencyObject6);
				bCurrentPassed = false;
				flag = dependencyObject6 == _contentRoot.VisualTree.RootVisual;
			}
		}
		return dependencyObject;
	}

	private DependencyObject? GetNextTabStopInternal(DependencyObject? pParent, DependencyObject? pCurrent, DependencyObject? pCandidate, ref bool bCurrentPassed, ref DependencyObject? pCurrentCompare)
	{
		DependencyObject dependencyObject = pCandidate;
		DependencyObject dependencyObject2 = null;
		if (IsValidTabStopSearchCandidate(pCurrent))
		{
			pCurrentCompare = pCurrent;
		}
		if (pParent != null)
		{
			bool flag = false;
			IEnumerable<DependencyObject> focusChildrenInTabOrder = FocusProperties.GetFocusChildrenInTabOrder(pParent);
			{
				foreach (DependencyObject item in focusChildrenInTabOrder)
				{
					dependencyObject2 = null;
					if (item != null && item == pCurrent)
					{
						flag = true;
						bCurrentPassed = true;
						continue;
					}
					if (item != null && IsVisible(item))
					{
						if (item == pCurrent)
						{
							flag = true;
							bCurrentPassed = true;
							continue;
						}
						if (IsValidTabStopSearchCandidate(item))
						{
							dependencyObject2 = (IsPotentialTabStop(item) ? item : GetNextTabStopInternal(item, pCurrent, dependencyObject, ref bCurrentPassed, ref pCurrentCompare));
						}
						else if (CanHaveFocusableChildren(item))
						{
							dependencyObject2 = GetNextTabStopInternal(item, pCurrent, dependencyObject, ref bCurrentPassed, ref pCurrentCompare);
						}
					}
					if (dependencyObject2 == null || (!IsFocusable(dependencyObject2) && !CanHaveFocusableChildren(dependencyObject2)))
					{
						continue;
					}
					int num = CompareTabIndex(dependencyObject2, pCurrentCompare);
					if (num <= 0 && (!(flag | bCurrentPassed) || num != 0))
					{
						continue;
					}
					if (dependencyObject != null)
					{
						if (CompareTabIndex(dependencyObject2, dependencyObject) < 0)
						{
							dependencyObject = dependencyObject2;
						}
					}
					else
					{
						dependencyObject = dependencyObject2;
					}
				}
				return dependencyObject;
			}
		}
		return dependencyObject;
	}

	internal DependencyObject? GetPreviousTabStop(DependencyObject? pCurrentTabStop = null)
	{
		DependencyObject dependencyObject = pCurrentTabStop ?? _focusedElement;
		DependencyObject dependencyObject2 = null;
		DependencyObject dependencyObject3 = null;
		if (dependencyObject == null && _contentRoot.VisualTree == null)
		{
			return null;
		}
		dependencyObject3 = dependencyObject;
		DependencyObject dependencyObject4 = (dependencyObject as UIElement)?.GetPreviousTabStopOverride();
		dependencyObject2 = dependencyObject4;
		if (dependencyObject2 == null)
		{
			bool bCurrentPassed = false;
			DependencyObject dependencyObject5 = dependencyObject;
			DependencyObject dependencyObject6 = GetFocusParent(dependencyObject);
			while (dependencyObject6 != null && !(dependencyObject6 is RootVisual) && dependencyObject2 == null)
			{
				if (IsValidTabStopSearchCandidate(dependencyObject5) && GetTabNavigation(dependencyObject5) == KeyboardNavigationMode.Cycle)
				{
					dependencyObject2 = GetLastFocusableElement(dependencyObject5, dependencyObject5);
					break;
				}
				if (IsValidTabStopSearchCandidate(dependencyObject6) && GetTabNavigation(dependencyObject6) == KeyboardNavigationMode.Once)
				{
					if (IsFocusable(dependencyObject6))
					{
						dependencyObject2 = dependencyObject6;
						break;
					}
					dependencyObject5 = dependencyObject6;
					dependencyObject6 = GetFocusParent(dependencyObject6);
					if (dependencyObject6 == null)
					{
						break;
					}
				}
				else if (!IsValidTabStopSearchCandidate(dependencyObject6))
				{
					UIElement parentElement = GetParentElement(dependencyObject6);
					if (parentElement == null)
					{
						dependencyObject6 = GetRootOfPopupSubTree(dependencyObject5);
						if (dependencyObject6 != null)
						{
							dependencyObject2 = GetPreviousTabStopInternal(dependencyObject6, dependencyObject5, dependencyObject2, ref bCurrentPassed, ref dependencyObject3);
							if (dependencyObject2 != null && !IsFocusable(dependencyObject2))
							{
								dependencyObject2 = GetLastFocusableElement(dependencyObject2);
							}
							if (dependencyObject2 == null)
							{
								dependencyObject2 = GetLastFocusableElement(dependencyObject6);
							}
							break;
						}
						dependencyObject6 = _contentRoot.VisualTree.ActiveRootVisual;
					}
					else if (parentElement == null || GetTabNavigation(parentElement) != KeyboardNavigationMode.Once)
					{
						dependencyObject6 = ((parentElement == null) ? _contentRoot.VisualTree.ActiveRootVisual : parentElement);
					}
					else
					{
						if (IsFocusable(parentElement))
						{
							dependencyObject2 = parentElement;
							break;
						}
						dependencyObject5 = dependencyObject6;
						dependencyObject6 = parentElement;
					}
				}
				dependencyObject2 = GetPreviousTabStopInternal(dependencyObject6, dependencyObject5, dependencyObject2, ref bCurrentPassed, ref dependencyObject3);
				if (dependencyObject2 == null && IsPotentialTabStop(dependencyObject6) && IsFocusable(dependencyObject6))
				{
					dependencyObject2 = ((dependencyObject6 == null || !IsPotentialTabStop(dependencyObject6) || GetTabNavigation(dependencyObject6) != KeyboardNavigationMode.Cycle) ? dependencyObject6 : GetLastFocusableElement(dependencyObject6));
				}
				else if (dependencyObject2 != null && CanHaveFocusableChildren(dependencyObject2))
				{
					dependencyObject2 = GetLastFocusableElement(dependencyObject2);
				}
				if (dependencyObject2 != null)
				{
					break;
				}
				if (IsValidTabStopSearchCandidate(dependencyObject6))
				{
					dependencyObject5 = dependencyObject6;
				}
				dependencyObject6 = GetFocusParent(dependencyObject6);
				bCurrentPassed = false;
			}
		}
		return dependencyObject2;
	}

	private DependencyObject? GetPreviousTabStopInternal(DependencyObject? parent, DependencyObject? pCurrent, DependencyObject? pCandidate, ref bool bCurrentPassed, ref DependencyObject? pCurrentCompare)
	{
		DependencyObject dependencyObject = pCandidate;
		DependencyObject dependencyObject2 = null;
		if (IsValidTabStopSearchCandidate(pCurrent))
		{
			pCurrentCompare = pCurrent;
		}
		if (parent != null)
		{
			bool flag = false;
			IEnumerable<DependencyObject> focusChildrenInTabOrder = FocusProperties.GetFocusChildrenInTabOrder(parent);
			{
				foreach (DependencyObject item in focusChildrenInTabOrder)
				{
					bool flag2 = false;
					dependencyObject2 = null;
					if (item != null && item == pCurrent)
					{
						flag = true;
						bCurrentPassed = true;
						continue;
					}
					if (item != null && IsVisible(item))
					{
						if (item == pCurrent)
						{
							flag = true;
							bCurrentPassed = true;
							continue;
						}
						if (IsValidTabStopSearchCandidate(item))
						{
							if (!IsPotentialTabStop(item))
							{
								dependencyObject2 = GetPreviousTabStopInternal(item, pCurrent, dependencyObject, ref bCurrentPassed, ref pCurrentCompare);
								flag2 = true;
							}
							else
							{
								dependencyObject2 = item;
							}
						}
						else if (CanHaveFocusableChildren(item))
						{
							dependencyObject2 = GetPreviousTabStopInternal(item, pCurrent, dependencyObject, ref bCurrentPassed, ref pCurrentCompare);
							flag2 = true;
						}
					}
					if (dependencyObject2 == null || (!IsFocusable(dependencyObject2) && !CanHaveFocusableChildren(dependencyObject2)))
					{
						continue;
					}
					int num = CompareTabIndex(dependencyObject2, pCurrentCompare);
					if (num >= 0 && (!((!flag && !bCurrentPassed) || flag2) || num != 0))
					{
						continue;
					}
					if (dependencyObject != null)
					{
						if (CompareTabIndex(dependencyObject2, dependencyObject) >= 0)
						{
							dependencyObject = dependencyObject2;
						}
					}
					else
					{
						dependencyObject = dependencyObject2;
					}
				}
				return dependencyObject;
			}
		}
		return dependencyObject;
	}

	private int CompareTabIndex(DependencyObject? firstObject, DependencyObject? secondObject)
	{
		if (GetTabIndex(firstObject) > GetTabIndex(secondObject))
		{
			return 1;
		}
		if (GetTabIndex(firstObject) < GetTabIndex(secondObject))
		{
			return -1;
		}
		return 0;
	}

	private bool IsFocusOnFirstTabStop()
	{
		DependencyObject focusedElement = _focusedElement;
		DependencyObject dependencyObject = null;
		DependencyObject dependencyObject2 = null;
		if (focusedElement == null || _contentRoot.VisualTree == null)
		{
			return false;
		}
		dependencyObject = _contentRoot.VisualTree.ActiveRootVisual;
		dependencyObject2 = GetFirstFocusableElement(dependencyObject);
		if (focusedElement == dependencyObject2)
		{
			return true;
		}
		return false;
	}

	private bool IsFocusOnLastTabStop()
	{
		DependencyObject focusedElement = _focusedElement;
		DependencyObject dependencyObject = null;
		DependencyObject dependencyObject2 = null;
		if (focusedElement == null || _contentRoot.VisualTree == null)
		{
			return false;
		}
		dependencyObject = _contentRoot.VisualTree.ActiveRootVisual;
		dependencyObject2 = GetLastFocusableElement(dependencyObject);
		if (focusedElement == dependencyObject2)
		{
			return true;
		}
		return false;
	}

	private bool CanHaveFocusableChildren(DependencyObject? pParent)
	{
		return FocusProperties.CanHaveFocusableChildren(pParent);
	}

	private UIElement? GetParentElement(DependencyObject? pCurrent)
	{
		DependencyObject dependencyObject = null;
		if (pCurrent != null)
		{
			for (dependencyObject = GetFocusParent(pCurrent); dependencyObject != null; dependencyObject = GetFocusParent(dependencyObject))
			{
				if (IsValidTabStopSearchCandidate(dependencyObject) && dependencyObject is UIElement result)
				{
					return result;
				}
			}
		}
		return null;
	}

	private void NotifyFocusChanged(bool bringIntoView, bool animateIfBringIntoView)
	{
		if (_focusedElement != null)
		{
			_contentRoot.InputManager.NotifyFocusChanged(_focusedElement, bringIntoView, animateIfBringIntoView);
		}
	}

	private bool IsFocusable(DependencyObject? dependencyObject)
	{
		return FocusProperties.IsFocusable(dependencyObject);
	}

	private DependencyObject? GetFocusParent(DependencyObject? dependencyObject)
	{
		if (dependencyObject != null)
		{
			if (FocusableHelper.IsFocusableDO(dependencyObject))
			{
				return FocusableHelper.GetContainingFrameworkElementIfFocusable(dependencyObject);
			}
			DependencyObject activeRootVisual = _contentRoot.VisualTree.ActiveRootVisual;
			if (dependencyObject != activeRootVisual)
			{
				return dependencyObject.GetParent() as DependencyObject;
			}
		}
		return null;
	}

	private bool IsVisible(DependencyObject? pObject)
	{
		return FocusProperties.IsVisible(pObject);
	}

	private int GetTabIndex(DependencyObject? dependencyObject)
	{
		if (dependencyObject != null)
		{
			if (dependencyObject is UIElement uIElement)
			{
				return uIElement.TabIndex;
			}
			IFocusable iFocusableForDO = FocusableHelper.GetIFocusableForDO(dependencyObject);
			if (iFocusableForDO != null)
			{
				return iFocusableForDO.GetTabIndex();
			}
		}
		return int.MaxValue;
	}

	private bool CanHaveChildren(DependencyObject? pObject)
	{
		if (pObject is UIElement uIElement)
		{
			return uIElement.CanHaveChildren();
		}
		return false;
	}

	private DependencyObject? GetRootOfPopupSubTree(DependencyObject? dependencyObject)
	{
		DependencyObject result = null;
		if (dependencyObject != null)
		{
			if (dependencyObject is UIElement uIElement)
			{
				result = uIElement.GetRootOfPopupSubTree();
			}
			else
			{
				UIElement parentElement = GetParentElement(dependencyObject);
				if (parentElement != null)
				{
					result = parentElement.GetRootOfPopupSubTree();
				}
			}
		}
		return result;
	}

	private KeyboardNavigationMode GetTabNavigation(DependencyObject? pObject)
	{
		if (!(pObject is UIElement uIElement))
		{
			return KeyboardNavigationMode.Local;
		}
		return uIElement.GetTabNavigation();
	}

	private bool IsPotentialTabStop(DependencyObject? dependencyObject)
	{
		return FocusProperties.IsPotentialTabStop(dependencyObject);
	}

	private bool CanRaiseFocusEventChange()
	{
		bool result = false;
		if (IsPluginFocused())
		{
			result = true;
		}
		return result;
	}

	private bool ShouldUpdateFocus(DependencyObject? newFocus, FocusState focusState)
	{
		bool result = true;
		if (newFocus != null)
		{
			if (newFocus is FrameworkElement element)
			{
				result = FocusSelection.ShouldUpdateFocus(element, focusState);
			}
			else if (newFocus is FlyoutBase element2)
			{
				result = FocusSelection.ShouldUpdateFocus(element2, focusState);
			}
			else if (newFocus is TextElement element3)
			{
				result = FocusSelection.ShouldUpdateFocus(element3, focusState);
			}
		}
		return result;
	}

	private FocusMovementResult UpdateFocus(FocusMovement movement)
	{
		if (movement == null)
		{
			throw new ArgumentNullException("movement");
		}
		DependencyObject newFocusTarget = movement.Target;
		FocusNavigationDirection direction = movement.Direction;
		bool forceBringIntoView = movement.ForceBringIntoView;
		bool animateIfBringIntoView = movement.AnimateIfBringIntoView;
		FocusState focusState = movement.FocusState;
		FocusState focusState2 = CoerceFocusState(focusState);
		bool success = false;
		bool focusCancelled = false;
		bool shouldCompleteAsyncOperation = movement.ShouldCompleteAsyncOperation;
		DependencyObject dependencyObject = null;
		bool bringIntoView = false;
		Guid correlationId = ((_asyncOperation != null) ? _asyncOperation!.CorrelationId : movement.CorrelationId);
		LogTraceTraceUpdateFocusBegin();
		InputDeviceType inputDeviceType = InputDeviceType.None;
		if (_asyncOperation != null)
		{
		}
		if (_focusLocked && !_ignoreFocusLock)
		{
			throw new InvalidOperationException("Focus change not allowed during focus changing.");
		}
		if (!ShouldUpdateFocus(newFocusTarget, focusState))
		{
			return Cleanup();
		}
		if (_contentRoot.IsShuttingDown())
		{
			return Cleanup();
		}
		if (newFocusTarget == null && focusState2 == FocusState.Unfocused)
		{
			_xyFocus.ResetManifolds();
		}
		inputDeviceType = _contentRoot.InputManager.LastInputDeviceType;
		if (inputDeviceType == InputDeviceType.GamepadOrRemote)
		{
			TextBox textBox = newFocusTarget as TextBox;
		}
		if (newFocusTarget == _focusedElement)
		{
			if (newFocusTarget is UIElement uIElement && uIElement.FocusState != focusState2)
			{
				RaiseGotFocusEvent(_focusedElement, correlationId);
				uIElement.UpdateFocusState(focusState2);
				_realFocusStateForFocusedElement = focusState;
			}
			else
			{
				IFocusable iFocusableForDO = FocusableHelper.GetIFocusableForDO(newFocusTarget);
				if (iFocusableForDO != null)
				{
					FocusState focusState3 = (FocusState)newFocusTarget.GetValue(iFocusableForDO.GetFocusStatePropertyIndex());
					if (focusState2 != focusState3)
					{
						RaiseGotFocusEvent(_focusedElement, correlationId);
						focusState3 = focusState2;
						newFocusTarget.SetValue(iFocusableForDO.GetFocusStatePropertyIndex(), focusState3);
					}
					_realFocusStateForFocusedElement = focusState;
				}
			}
			success = true;
			return Cleanup();
		}
		if (movement.RaiseGettingLosingEvents && CanRaiseFocusEventChange() && RaiseAndProcessGettingAndLosingFocusEvents(_focusedElement, newFocusTarget, focusState, direction, movement.CanCancel, correlationId).Canceled)
		{
			success = true;
			focusCancelled = true;
			return Cleanup();
		}
		dependencyObject = _focusedElement;
		if (dependencyObject != null)
		{
			IFocusable iFocusableForDO2 = FocusableHelper.GetIFocusableForDO(dependencyObject);
			if (iFocusableForDO2 != null)
			{
				dependencyObject.SetValue(iFocusableForDO2.GetFocusStatePropertyIndex(), FocusState.Unfocused);
				goto IL_0284;
			}
		}
		if (dependencyObject != null && dependencyObject is UIElement uIElement2)
		{
			uIElement2.UpdateFocusState(FocusState.Unfocused);
		}
		goto IL_0284;
		IL_0284:
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			_log.Value.LogDebug(string.Format("{0}() - oldFocus={1} ({2}), newFocus={3} ({4})", "UpdateFocus", _focusedElement, _realFocusStateForFocusedElement, newFocusTarget, focusState));
		}
		_focusedElement = newFocusTarget;
		_realFocusStateForFocusedElement = focusState;
		_contentRoot.FocusAdapter.SetFocus();
		if (_focusedElement != null && (focusState == FocusState.Keyboard || forceBringIntoView))
		{
			bringIntoView = _focusedElement is UIElement || IsPotentialTabStop(_focusedElement);
		}
		if (newFocusTarget != null)
		{
			IFocusable iFocusableForDO3 = FocusableHelper.GetIFocusableForDO(newFocusTarget);
			if (iFocusableForDO3 != null)
			{
				newFocusTarget.SetValue(iFocusableForDO3.GetFocusStatePropertyIndex(), focusState2);
				goto IL_038a;
			}
		}
		if (newFocusTarget is UIElement uIElement4)
		{
			uIElement4.UpdateFocusState(focusState2);
		}
		goto IL_038a;
		IL_038a:
		UpdateFocusRect(direction, cleanOnly: false);
		FocusNative(_focusedElement as UIElement);
		success = true;
		if (_focusedElement == null || !TextCore.IsTextControl(_focusedElement))
		{
			if (_isPrevFocusTextControl)
			{
				TextCore instance = TextCore.Instance;
				instance.ClearLastSelectedTextElement();
				_isPrevFocusTextControl = false;
			}
		}
		else
		{
			_isPrevFocusTextControl = true;
		}
		if (_focusedElement != null)
		{
			FireAutomationFocusChanged();
		}
		if (CanRaiseFocusEventChange())
		{
			if (dependencyObject != null)
			{
				bool flag = newFocusTarget != null && NavigatedToByEngagingControl(newFocusTarget);
				if (_engagedControl != null && !flag)
				{
					_engagedControl!.RemoveFocusEngagement();
				}
				RaiseLostFocusEvent(dependencyObject, correlationId);
			}
			else
			{
				CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
				{
					FocusManager.LostFocus?.Invoke(null, new FocusManagerLostFocusEventArgs(null, correlationId));
				});
			}
			if (_focusedElement != null)
			{
				RaiseGotFocusEvent(_focusedElement, correlationId);
			}
			else
			{
				CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
				{
					FocusManager.GotFocus?.Invoke(null, new FocusManagerGotFocusEventArgs(_focusedElement, correlationId));
				});
			}
		}
		else if (dependencyObject != null && dependencyObject is Control control)
		{
			control.UpdateVisualState();
		}
		NotifyFocusChanged(bringIntoView, animateIfBringIntoView);
		_contentRoot.AccessKeyExport.UpdateScope();
		if (focusState2 == FocusState.Keyboard && _contentRoot.InputManager.ShouldRequestFocusSound() && (inputDeviceType == InputDeviceType.Keyboard || inputDeviceType == InputDeviceType.GamepadOrRemote))
		{
			ElementSoundPlayerService.Instance.RequestInteractionSoundForElement(ElementSoundKind.Focus, newFocusTarget);
		}
		return Cleanup();
		FocusMovementResult Cleanup()
		{
			TraceUpdateFocusEnd(newFocusTarget);
			FocusMovementResult result = new FocusMovementResult(success, focusCancelled);
			if (_asyncOperation != null)
			{
				CancelCurrentAsyncOperation(result);
			}
			_currentFocusOperationCancellable = true;
			return result;
		}
	}

	private void FireAutomationFocusChanged()
	{
		AutomationPeer automationPeer = null;
		if (_focusedElement != null)
		{
			automationPeer = (_focusedElement as UIElement)?.OnCreateAutomationPeerInternal();
			if (automationPeer == null && _focusedElement is ContentControl)
			{
				UIElement uiElement = _focusedElement as UIElement;
				Popup openPopupForElement = PopupRoot.GetOpenPopupForElement(uiElement);
				if (openPopupForElement != null)
				{
					automationPeer = openPopupForElement.OnCreateAutomationPeerInternal();
				}
			}
			if (automationPeer != null)
			{
				_focusedAutomationPeer = automationPeer;
			}
		}
		if (automationPeer == null)
		{
			_focusedAutomationPeer = null;
		}
	}

	private void RaiseLostFocusEvent(DependencyObject pLostFocusElement, Guid correlationId)
	{
		DependencyObject pLostFocusElement2 = pLostFocusElement;
		if (pLostFocusElement2 == null)
		{
			throw new ArgumentNullException("pLostFocusElement");
		}
		RoutedEventArgs spLostFocusEventArgs = new RoutedEventArgs();
		FocusManagerLostFocusEventArgs spFocusManagerLostFocusEventArgs = new FocusManagerLostFocusEventArgs(pLostFocusElement2, correlationId);
		spLostFocusEventArgs.OriginalSource = pLostFocusElement2;
		IFocusable lostFocusElementFocusable = FocusableHelper.GetIFocusableForDO(pLostFocusElement2);
		if (lostFocusElementFocusable != null)
		{
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				lostFocusElementFocusable.OnLostFocus(spLostFocusEventArgs);
			});
		}
		CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			(pLostFocusElement2 as UIElement)?.RaiseEvent(UIElement.LostFocusEvent, spLostFocusEventArgs);
		});
		CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			FocusManager.LostFocus?.Invoke(null, spFocusManagerLostFocusEventArgs);
		});
	}

	private bool NavigatedToByEngagingControl(DependencyObject focused)
	{
		DependencyObject dependencyObject = focused;
		bool result = false;
		if (_engagedControl != null)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = _engagedControl == dependencyObject as Control;
			if (FocusableHelper.IsFocusableDO(dependencyObject))
			{
				dependencyObject = GetFocusParent(dependencyObject);
			}
			UIElement uIElement = dependencyObject as UIElement;
			if (uIElement != null)
			{
				flag = _engagedControl.IsAncestorOf(uIElement);
			}
			Popup popup = dependencyObject as Popup;
			if (GetRootOfPopupSubTree(uIElement) != null || popup != null)
			{
				IList<DependencyObject> popupChildrenOpenedDuringEngagement = PopupRoot.GetPopupChildrenOpenedDuringEngagement(dependencyObject);
				foreach (DependencyObject item in popupChildrenOpenedDuringEngagement)
				{
					flag3 = item == uIElement;
					if (flag3)
					{
						break;
					}
					flag2 = (popup != null && popup.Child != null && (item == popup.Child || popup.Child.IsAncestorOf(item))) || item.IsAncestorOf(uIElement);
					if (flag2)
					{
						break;
					}
				}
			}
			result = flag || flag4 || flag3 || flag2;
		}
		return result;
	}

	private void RaiseGotFocusEvent(DependencyObject pGotFocusElement, Guid correlationId)
	{
		DependencyObject pGotFocusElement2 = pGotFocusElement;
		if (pGotFocusElement2 == null)
		{
			throw new ArgumentNullException("pGotFocusElement");
		}
		RoutedEventArgs spGotFocusEventArgs = new RoutedEventArgs();
		FocusManagerGotFocusEventArgs spFocusManagerGotFocusEventArgs = new FocusManagerGotFocusEventArgs(_focusedElement, correlationId);
		spGotFocusEventArgs.OriginalSource = pGotFocusElement2;
		IFocusable gotFocusElementFocusable = FocusableHelper.GetIFocusableForDO(pGotFocusElement2);
		if (gotFocusElementFocusable != null)
		{
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				gotFocusElementFocusable.OnGotFocus(spGotFocusEventArgs);
			});
		}
		CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			(pGotFocusElement2 as UIElement)?.RaiseEvent(UIElement.GotFocusEvent, spGotFocusEventArgs);
		});
		CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			FocusManager.GotFocus?.Invoke(null, spFocusManagerGotFocusEventArgs);
		});
	}

	private DependencyObject? RaiseFocusElementRemovedEvent(DependencyObject? currentNextFocusableElement)
	{
		FocusedElementRemovedEventArgs focusedElementRemovedEventArgs = new FocusedElementRemovedEventArgs(_focusedElement, currentNextFocusableElement);
		this.FocusedElementRemoved?.Invoke(this, focusedElementRemovedEventArgs);
		return focusedElementRemovedEventArgs.NewFocusedElement;
	}

	internal void SetFocusOnNextFocusableElement(FocusState focusState, bool shouldFireFocusedRemoved)
	{
		bool flag = true;
		DependencyObject dependencyObject = GetNextFocusableElement();
		if (dependencyObject == null)
		{
			dependencyObject = GetFirstFocusableElement();
		}
		if (shouldFireFocusedRemoved)
		{
			dependencyObject = RaiseFocusElementRemovedEvent(dependencyObject);
		}
		if (dependencyObject != null && FocusableHelper.IsFocusableDO(dependencyObject))
		{
			FocusMovementResult focusMovementResult = SetFocusedElement(new FocusMovement(dependencyObject, FocusNavigationDirection.Next, focusState));
			flag = focusMovementResult.WasMoved;
		}
		if (dependencyObject is FrameworkElement element && !FocusSelection.ShouldUpdateFocus(element, focusState))
		{
			focusState = FocusState.Programmatic;
		}
		UIElement uIElement = dependencyObject as UIElement;
		if (dependencyObject == null || !flag)
		{
			ClearFocus();
		}
		else if (uIElement != null)
		{
			bool flag2 = false;
			if (!uIElement.Focus(focusState, animateIfBringIntoView: false))
			{
				ClearFocus();
			}
		}
	}

	internal bool TryMoveFocusInstance(FocusNavigationDirection focusNavigationDirection)
	{
		XYFocusOptions @default = XYFocusOptions.Default;
		FocusMovementResult focusMovementResult = FindAndSetNextFocus(new FocusMovement(@default, focusNavigationDirection, null));
		return focusMovementResult.WasMoved;
	}

	internal bool FindAndSetNextFocus(FocusNavigationDirection direction)
	{
		XYFocusOptions @default = XYFocusOptions.Default;
		FocusMovementResult focusMovementResult = FindAndSetNextFocus(new FocusMovement(@default, direction, null));
		return focusMovementResult.WasMoved;
	}

	internal FocusMovementResult FindAndSetNextFocus(FocusMovement movement)
	{
		FocusMovementResult focusMovementResult = new FocusMovementResult();
		FocusNavigationDirection direction = movement.Direction;
		bool flag = true;
		XYFocusOptions value = movement.XYFocusOptions.Value;
		if (_focusLocked)
		{
			throw new InvalidOperationException("Cannot change focus while focus is already changing.");
		}
		if (value.UpdateManifoldsFromFocusHintRectangle && value.FocusHintRectangle.HasValue)
		{
			XYFocus.Manifolds manifolds = default(XYFocus.Manifolds);
			manifolds.Horizontal = (value.FocusHintRectangle.Value.Top, value.FocusHintRectangle.Value.Bottom);
			manifolds.Vertical = (value.FocusHintRectangle.Value.Left, value.FocusHintRectangle.Value.Right);
			_xyFocus.SetManifolds(manifolds);
		}
		flag = !_contentRoot.FocusAdapter.ShouldDepartFocus(direction);
		DependencyObject dependencyObject = FindNextFocus(new FindFocusOptions(direction, flag), value, movement.Target, updateManifolds: false);
		if (dependencyObject != null)
		{
			focusMovementResult = SetFocusedElement(new FocusMovement(dependencyObject, movement));
			if (focusMovementResult.WasMoved && !focusMovementResult.WasCanceled && value.UpdateManifold)
			{
				Rect elementBounds = (value.FocusHintRectangle.HasValue ? value.FocusHintRectangle.Value : value.FocusedElementBounds);
				_xyFocus.UpdateManifolds(direction, elementBounds, dependencyObject, value.IgnoreClipping);
			}
		}
		else if (movement.CanDepartFocus)
		{
			bool handled = false;
			FocusObserver.DepartFocus(direction, movement.CorrelationId, ref handled);
		}
		return focusMovementResult;
	}

	internal DependencyObject? FindNextFocus(FocusNavigationDirection direction)
	{
		XYFocusOptions @default = XYFocusOptions.Default;
		return FindNextFocus(new FindFocusOptions(direction), @default);
	}

	internal DependencyObject? FindNextFocus(FindFocusOptions findFocusOptions, XYFocusOptions xyFocusOptions, DependencyObject? component = null, bool updateManifolds = true)
	{
		FocusNavigationDirection direction = findFocusOptions.Direction;
		switch (direction)
		{
		case FocusNavigationDirection.Next:
			TraceXYFocusEnteredBegin("Next");
			break;
		case FocusNavigationDirection.Previous:
			TraceXYFocusEnteredBegin("Previous");
			break;
		case FocusNavigationDirection.Up:
			TraceXYFocusEnteredBegin("Up");
			break;
		case FocusNavigationDirection.Down:
			TraceXYFocusEnteredBegin("Down");
			break;
		case FocusNavigationDirection.Left:
			TraceXYFocusEnteredBegin("Left");
			break;
		case FocusNavigationDirection.Right:
			TraceXYFocusEnteredBegin("Right");
			break;
		default:
			TraceXYFocusEnteredBegin("Invalid");
			break;
		}
		DependencyObject dependencyObject = null;
		Control engagedControl = (xyFocusOptions.ConsiderEngagement ? _engagedControl : null);
		DependencyObject dependencyObject2 = ((component == null) ? _focusedElement : component);
		if (direction == FocusNavigationDirection.Previous || direction == FocusNavigationDirection.Next || dependencyObject2 == null)
		{
			bool isReverse = direction == FocusNavigationDirection.Previous;
			dependencyObject = ProcessTabStopInternal(isReverse, findFocusOptions.QueryOnly);
			if (dependencyObject == null)
			{
				return null;
			}
		}
		else
		{
			UIElement uIElement = dependencyObject2 as UIElement;
			if (uIElement == null && FocusableHelper.IsFocusableDO(dependencyObject2))
			{
				uIElement = GetFocusParent(dependencyObject2) as UIElement;
			}
			xyFocusOptions.FocusedElementBounds = uIElement?.GetGlobalBoundsLogical(xyFocusOptions.IgnoreClipping) ?? Rect.Empty;
			dependencyObject = _xyFocus.GetNextFocusableElement(direction, dependencyObject2, engagedControl, _contentRoot.VisualTree, updateManifolds, xyFocusOptions);
		}
		TraceXYFocusEnteredEnd();
		return dependencyObject;
	}

	private UIElement? GetFocusTargetDescendant(UIElement element)
	{
		if (element is Control control)
		{
			return control.FocusTargetDescendant;
		}
		return null;
	}

	private DependencyObject? GetFocusTarget()
	{
		DependencyObject dependencyObject = _focusedElement;
		if (dependencyObject == null && _focusRectangleUIElement != null && _focusRectangleUIElement!.TryGetTarget(out var target))
		{
			dependencyObject = target;
		}
		if (dependencyObject == null)
		{
			return null;
		}
		if (!IsPluginFocused())
		{
			return null;
		}
		if (dependencyObject is FrameworkElement frameworkElement && frameworkElement.AllowFocusWhenDisabled && !frameworkElement.IsEnabled)
		{
			return null;
		}
		if (dependencyObject is UIElement uIElement && uIElement.IsFocused && uIElement.IsKeyboardFocused && uIElement.UseSystemFocusVisuals)
		{
			UIElement focusTargetDescendant = GetFocusTargetDescendant(uIElement);
			if (focusTargetDescendant != null)
			{
				return focusTargetDescendant;
			}
			return uIElement;
		}
		if (Uno.UI.Xaml.Input.FocusRectManager.AreHighVisibilityFocusRectsEnabled())
		{
			TextElement textElementForFocusRectCandidate = GetTextElementForFocusRectCandidate();
			if (textElementForFocusRectCandidate != null)
			{
				return textElementForFocusRectCandidate;
			}
		}
		return null;
	}

	private TextElement? GetTextElementForFocusRectCandidate()
	{
		if (IsPluginFocused())
		{
			DependencyObject focusedElement = _focusedElement;
			if (focusedElement != null && FocusableHelper.IsFocusableDO(focusedElement))
			{
				FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(focusedElement);
				InputManager inputManager = _contentRoot.InputManager;
				if (inputManager.LastInputDeviceType == InputDeviceType.Keyboard && inputManager.LastInputWasNonFocusNavigationKeyFromSIP())
				{
					return null;
				}
				bool flag = focusManagerForElement != null && focusManagerForElement.GetRealFocusStateForFocusedElement() == FocusState.Programmatic && (inputManager.LastInputDeviceType == InputDeviceType.Keyboard || inputManager.LastInputDeviceType == InputDeviceType.GamepadOrRemote);
				bool flag2 = focusManagerForElement != null && focusManagerForElement.GetRealFocusStateForFocusedElement() == FocusState.Keyboard;
				if (flag2 || flag)
				{
					return focusedElement as TextElement;
				}
			}
		}
		return null;
	}

	private void UpdateFocusRect(FocusNavigationDirection focusNavigationDirection, bool cleanOnly)
	{
		_focusTarget = GetFocusTarget();
		_focusRectManager.UpdateFocusRect(_focusedElement, _focusTarget, focusNavigationDirection, cleanOnly);
	}

	internal void OnFocusedElementKeyPressed()
	{
		_focusRectManager.OnFocusedElementKeyPressed();
	}

	internal void OnFocusedElementKeyReleased()
	{
		_focusRectManager.OnFocusedElementKeyReleased();
	}

	private void RenderFocusRectForElementIfNeeded(UIElement element, IContentRenderer? renderer)
	{
		if (element == _focusTarget)
		{
			_focusRectManager.RenderFocusRectForElement(element, renderer);
		}
	}

	private void SetFocusVisualDirty()
	{
		DependencyObject focusedElement = _focusedElement;
		if (focusedElement is UIElement focusedElement2)
		{
			UIElement.NWSetContentDirty(focusedElement2, DirtyFlags.Render);
		}
		else if (focusedElement != null && FocusableHelper.IsFocusableDO(focusedElement))
		{
			FrameworkElement containingFrameworkElementIfFocusable = FocusableHelper.GetContainingFrameworkElementIfFocusable(focusedElement);
			if (containingFrameworkElementIfFocusable != null)
			{
				UIElement.NWSetContentDirty(containingFrameworkElementIfFocusable, DirtyFlags.Render);
			}
		}
	}

	private void OnAccessKeyDisplayModeChanged()
	{
		TextBox textBox = _focusedElement as TextBox;
	}

	private ChangingFocusEventRaiseResult RaiseChangingFocusEvent<TArgs>(DependencyObject? losingFocusElement, DependencyObject? gettingFocusElement, FocusState newFocusState, FocusNavigationDirection navigationDirection, RoutedEvent routedEvent, Guid correlationId, ChangingFocusEventArgsFactory<TArgs> argsFactory) where TArgs : RoutedEventArgs, IChangingFocusEventArgs
	{
		_focusLocked = true;
		try
		{
			FocusInputDeviceKind lastFocusInputDeviceKind = _contentRoot.InputManager.LastFocusInputDeviceKind;
			TArgs val = argsFactory(losingFocusElement, gettingFocusElement, newFocusState, navigationDirection, lastFocusInputDeviceKind, _currentFocusOperationCancellable, correlationId);
			UIElement uIElement = null;
			if (routedEvent == UIElement.LosingFocusEvent)
			{
				uIElement = losingFocusElement as UIElement;
			}
			else if (routedEvent == UIElement.GettingFocusEvent)
			{
				uIElement = gettingFocusElement as UIElement;
			}
			if (uIElement != null)
			{
				val.OriginalSource = uIElement;
				uIElement.RaiseEvent(routedEvent, val);
			}
			if (routedEvent == UIElement.LosingFocusEvent)
			{
				FocusManager.LosingFocus?.Invoke(null, val as LosingFocusEventArgs);
			}
			else
			{
				FocusManager.GettingFocus?.Invoke(null, val as GettingFocusEventArgs);
			}
			DependencyObject dependencyObject = val.NewFocusedElement;
			if (dependencyObject != gettingFocusElement && dependencyObject != null && !IsFocusable(dependencyObject))
			{
				DependencyObject dependencyObject2 = null;
				dependencyObject2 = ((navigationDirection != FocusNavigationDirection.Previous) ? GetFirstFocusableElement(dependencyObject) : GetLastFocusableElement(dependencyObject));
				dependencyObject = dependencyObject2;
			}
			if (val.Cancel || dependencyObject == losingFocusElement || (gettingFocusElement != null && dependencyObject == null))
			{
				return new ChangingFocusEventRaiseResult(canceled: true);
			}
			return new ChangingFocusEventRaiseResult(canceled: false, dependencyObject);
		}
		finally
		{
			_focusLocked = false;
		}
	}

	private ChangingFocusEventRaiseResult RaiseAndProcessGettingAndLosingFocusEvents(DependencyObject? pOldFocus, DependencyObject? pFocusTarget, FocusState focusState, FocusNavigationDirection focusNavigationDirection, bool focusChangeCancellable, Guid correlationId)
	{
		DependencyObject dependencyObject = pFocusTarget;
		_currentFocusOperationCancellable &= focusChangeCancellable;
		bool flag = false;
		ChangingFocusEventRaiseResult changingFocusEventRaiseResult = RaiseChangingFocusEvent(pOldFocus, dependencyObject, focusState, focusNavigationDirection, UIElement.LosingFocusEvent, correlationId, new ChangingFocusEventArgsFactory<LosingFocusEventArgs>(CreateLosingFocusEventArgs));
		if (changingFocusEventRaiseResult.Canceled)
		{
			return new ChangingFocusEventRaiseResult(canceled: true);
		}
		DependencyObject finalGettingFocusElement = changingFocusEventRaiseResult.FinalGettingFocusElement;
		if (dependencyObject != finalGettingFocusElement)
		{
			flag = true;
		}
		if (!flag)
		{
			finalGettingFocusElement = null;
			ChangingFocusEventRaiseResult changingFocusEventRaiseResult2 = RaiseChangingFocusEvent(pOldFocus, dependencyObject, focusState, focusNavigationDirection, UIElement.GettingFocusEvent, correlationId, new ChangingFocusEventArgsFactory<GettingFocusEventArgs>(CreateGettingFocusEventArgs));
			if (changingFocusEventRaiseResult2.Canceled)
			{
				return new ChangingFocusEventRaiseResult(canceled: true);
			}
			finalGettingFocusElement = changingFocusEventRaiseResult2.FinalGettingFocusElement;
			if (dependencyObject != finalGettingFocusElement)
			{
				flag = true;
			}
		}
		if (flag)
		{
			if (!ShouldUpdateFocus(finalGettingFocusElement, focusState))
			{
				return new ChangingFocusEventRaiseResult(canceled: true);
			}
			ChangingFocusEventRaiseResult changingFocusEventRaiseResult3 = RaiseAndProcessGettingAndLosingFocusEvents(pOldFocus, finalGettingFocusElement, focusState, focusNavigationDirection, focusChangeCancellable, correlationId);
			if (changingFocusEventRaiseResult3.Canceled)
			{
				return new ChangingFocusEventRaiseResult(canceled: true);
			}
			finalGettingFocusElement = changingFocusEventRaiseResult3.FinalGettingFocusElement;
			pFocusTarget = finalGettingFocusElement;
		}
		return new ChangingFocusEventRaiseResult(canceled: false, pFocusTarget);
	}

	private bool IsValidTabStopSearchCandidate(DependencyObject? element)
	{
		bool flag = IsPotentialTabStop(element);
		if (!flag)
		{
			flag = element is UIElement uIElement && uIElement.IsTabNavigationSet;
		}
		return flag;
	}

	internal void RaiseNoFocusCandidateFoundEvent(FocusNavigationDirection navigationDirection)
	{
		UIElement uIElement = _focusedElement as UIElement;
		TextElement textElement = _focusedElement as TextElement;
		switch (navigationDirection)
		{
		case FocusNavigationDirection.Next:
			TraceXYFocusNotFoundInfo(_focusedElement, "Next");
			break;
		case FocusNavigationDirection.Previous:
			TraceXYFocusNotFoundInfo(_focusedElement, "Previous");
			break;
		case FocusNavigationDirection.Up:
			TraceXYFocusNotFoundInfo(_focusedElement, "Up");
			break;
		case FocusNavigationDirection.Down:
			TraceXYFocusNotFoundInfo(_focusedElement, "Down");
			break;
		case FocusNavigationDirection.Left:
			TraceXYFocusNotFoundInfo(_focusedElement, "Left");
			break;
		case FocusNavigationDirection.Right:
			TraceXYFocusNotFoundInfo(_focusedElement, "Right");
			break;
		default:
			TraceXYFocusNotFoundInfo(_focusedElement, "Invalid");
			break;
		}
		if (textElement != null)
		{
			uIElement = textElement.GetContainingFrameworkElement();
		}
		Guid correlationId = Guid.NewGuid();
		bool handled = false;
		FocusObserver.DepartFocus(navigationDirection, correlationId, ref handled);
		if (uIElement != null)
		{
			FocusInputDeviceKind lastFocusInputDeviceKind = _contentRoot.InputManager.LastFocusInputDeviceKind;
			NoFocusCandidateFoundEventArgs noFocusCandidateFoundEventArgs = new NoFocusCandidateFoundEventArgs(navigationDirection, lastFocusInputDeviceKind);
			noFocusCandidateFoundEventArgs.OriginalSource = _focusedElement;
			uIElement.RaiseEvent(UIElement.NoFocusCandidateFoundEvent, noFocusCandidateFoundEventArgs);
		}
	}

	private void SetPluginFocusStatus(bool pluginFocused)
	{
		_pluginFocused = pluginFocused;
	}

	private FocusState GetFocusStateFromInputDeviceType(InputDeviceType inputDeviceType)
	{
		switch (inputDeviceType)
		{
		case InputDeviceType.None:
			return FocusState.Programmatic;
		case InputDeviceType.Mouse:
		case InputDeviceType.Touch:
		case InputDeviceType.Pen:
			return FocusState.Pointer;
		case InputDeviceType.Keyboard:
		case InputDeviceType.GamepadOrRemote:
			return FocusState.Keyboard;
		default:
			return FocusState.Programmatic;
		}
	}

	private bool TrySetAsyncOperation(FocusAsyncOperation asyncOperation)
	{
		if (_asyncOperation != null)
		{
			return false;
		}
		_asyncOperation = asyncOperation;
		return true;
	}

	private void CancelCurrentAsyncOperation(FocusMovementResult result)
	{
		if (_asyncOperation != null)
		{
			_asyncOperation!.CoreSetResults(result);
			_asyncOperation!.CoreFireCompletion();
			_asyncOperation = null;
		}
	}

	private FocusState CoerceFocusState(FocusState focusState)
	{
		InputDeviceType lastInputDeviceType = _contentRoot.InputManager.LastInputDeviceType;
		if (focusState == FocusState.Programmatic)
		{
			switch (lastInputDeviceType)
			{
			case InputDeviceType.Keyboard:
				if (_contentRoot.InputManager.LastInputWasNonFocusNavigationKeyFromSIP())
				{
					return FocusState.Pointer;
				}
				return FocusState.Keyboard;
			case InputDeviceType.GamepadOrRemote:
				return FocusState.Keyboard;
			default:
				return FocusState.Pointer;
			}
		}
		return focusState;
	}

	private void SetWindowFocus(bool isFocused, bool isShiftDown)
	{
		Guid correlationId = Guid.NewGuid();
		SetPluginFocusStatus(isFocused);
		DependencyObject focusedElement = _focusedElement;
		if (focusedElement == null && isFocused)
		{
			focusedElement = GetFirstFocusableElementFromRoot(isShiftDown);
			if (focusedElement != null)
			{
				FocusState focusState = FocusState.Programmatic;
				if (_contentRoot.InputManager.LastInputDeviceType == InputDeviceType.GamepadOrRemote)
				{
					focusState = FocusState.Keyboard;
				}
				InitialFocus = true;
				FocusMovementResult focusMovementResult = SetFocusedElement(new FocusMovement(focusedElement, FocusNavigationDirection.None, focusState));
				return;
			}
		}
		if (focusedElement == null)
		{
			focusedElement = _contentRoot.VisualTree.PublicRootVisual;
		}
		if (focusedElement == null)
		{
			return;
		}
		RoutedEventArgs args = new RoutedEventArgs();
		if (isFocused)
		{
			DependencyObject pFocusTarget = focusedElement;
			bool flag = false;
			using (new UnsafeFocusLockOverrideGuard(this))
			{
				DependencyObject focusedElement2 = _focusedElement;
				ChangingFocusEventRaiseResult changingFocusEventRaiseResult = RaiseAndProcessGettingAndLosingFocusEvents(null, pFocusTarget, GetRealFocusStateForFocusedElement(), FocusNavigationDirection.None, focusChangeCancellable: false, correlationId);
				pFocusTarget = changingFocusEventRaiseResult.FinalGettingFocusElement;
				bool canceled = changingFocusEventRaiseResult.Canceled;
				_currentFocusOperationCancellable = true;
				if (focusedElement2 != _focusedElement)
				{
					flag = true;
					focusedElement = _focusedElement;
				}
				args.OriginalSource = focusedElement;
				if (focusedElement is UIElement focusedElement3)
				{
					UIElement.NWSetContentDirty(focusedElement3, DirtyFlags.Render);
				}
				if (!flag)
				{
					CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
					{
						if (focusedElement is Hyperlink hyperlink2)
						{
							hyperlink2.OnGotFocus(args);
						}
						(focusedElement as UIElement)?.RaiseEvent(UIElement.GotFocusEvent, args);
						FocusManager.LostFocus?.Invoke(null, new FocusManagerLostFocusEventArgs(null, correlationId));
						FocusManager.GotFocus?.Invoke(null, new FocusManagerGotFocusEventArgs(focusedElement, correlationId));
					});
				}
				FireAutomationFocusChanged();
				return;
			}
		}
		using (new UnsafeFocusLockOverrideGuard(this))
		{
			DependencyObject focusedElement4 = _focusedElement;
			bool canceled2 = RaiseAndProcessGettingAndLosingFocusEvents(focusedElement, null, FocusState.Unfocused, FocusNavigationDirection.None, focusChangeCancellable: false, correlationId).Canceled;
			_currentFocusOperationCancellable = true;
			if (focusedElement4 != _focusedElement)
			{
				focusedElement = _focusedElement;
			}
			args.OriginalSource = focusedElement;
			if (focusedElement is Control control)
			{
				FocusState focusState2 = control.FocusState;
				control.UpdateFocusState(FocusState.Unfocused);
				(focusedElement as Control)?.UpdateVisualState();
				control.UpdateFocusState(focusState2);
			}
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				if (focusedElement is Hyperlink hyperlink)
				{
					hyperlink.OnLostFocus(args);
				}
				(focusedElement as UIElement)?.RaiseEvent(UIElement.LostFocusEvent, args);
				FocusManager.LostFocus?.Invoke(null, new FocusManagerLostFocusEventArgs(focusedElement, correlationId));
				FocusManager.GotFocus?.Invoke(null, new FocusManagerGotFocusEventArgs(null, correlationId));
			});
		}
	}

	private bool IsFocusedElementInPopup()
	{
		if (_focusedElement != null)
		{
			return GetRootOfPopupSubTree(_focusedElement) != null;
		}
		return false;
	}

	internal void SetFocusRectangleUIElement(UIElement? newFocusRectangle)
	{
		if (newFocusRectangle == null)
		{
			_focusRectangleUIElement = null;
		}
		else
		{
			_focusRectangleUIElement = new WeakReference<UIElement>(newFocusRectangle);
		}
	}

	internal bool IsPluginFocused()
	{
		return _pluginFocused;
	}

	internal FocusState GetRealFocusStateForFocusedElement()
	{
		return _realFocusStateForFocusedElement;
	}

	private void TraceXYFocusEnteredBegin(string direction)
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace("XY focus entered begin for direction " + direction);
		}
	}

	private void TraceXYFocusEnteredEnd()
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace("XY focus entered end");
		}
	}

	private void LogTraceTraceUpdateFocusBegin()
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace("Update focus begin");
		}
	}

	private void TraceXYFocusNotFoundInfo(DependencyObject? focusedElement, string direction)
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace($"Did not find XY focus from {focusedElement} in {direction}");
		}
	}

	private void TraceUpdateFocusEnd(DependencyObject? focusedElement)
	{
		if (this.Log().IsEnabled(LogLevel.Trace))
		{
			this.Log().Trace($"Update focus ended for {focusedElement}");
		}
	}

	private static LosingFocusEventArgs CreateLosingFocusEventArgs(DependencyObject? oldFocusedElement, DependencyObject? newFocusedElement, FocusState focusState, FocusNavigationDirection direction, FocusInputDeviceKind inputDevice, bool canCancelFocus, Guid correlationId)
	{
		return new LosingFocusEventArgs(oldFocusedElement, newFocusedElement, focusState, direction, inputDevice, canCancelFocus, correlationId);
	}

	private static GettingFocusEventArgs CreateGettingFocusEventArgs(DependencyObject? oldFocusedElement, DependencyObject? newFocusedElement, FocusState focusState, FocusNavigationDirection direction, FocusInputDeviceKind inputDevice, bool canCancelFocus, Guid correlationId)
	{
		return new GettingFocusEventArgs(oldFocusedElement, newFocusedElement, focusState, direction, inputDevice, canCancelFocus, correlationId);
	}

	DependencyObject? IFocusManager.FindNextFocus(FindFocusOptions findFocusOptions, XYFocusOptions xyFocusOptions, DependencyObject? component, bool updateManifolds)
	{
		return FindNextFocus(findFocusOptions, xyFocusOptions, component, updateManifolds);
	}

	FocusMovementResult IFocusManager.SetFocusedElement(FocusMovement movement)
	{
		return SetFocusedElement(movement);
	}

	private static void ConvertOptionsRectsToPhysical(float scale, XYFocusOptions xyFocusOptions)
	{
		if (xyFocusOptions.ExclusionRect.HasValue)
		{
			Rect value = xyFocusOptions.ExclusionRect.Value;
			value = DXamlCore.Current.DipsToPhysicalPixels(scale, value);
			xyFocusOptions.ExclusionRect = value;
		}
		if (xyFocusOptions.FocusHintRectangle.HasValue)
		{
			Rect value2 = xyFocusOptions.FocusHintRectangle.Value;
			value2 = DXamlCore.Current.DipsToPhysicalPixels(scale, value2);
			xyFocusOptions.FocusHintRectangle = value2;
		}
	}

	private static bool InIslandsMode()
	{
		return false;
	}

	private static object? FindNextFocus(FocusNavigationDirection focusNavigationDirection, XYFocusOptions xyFocusOptions)
	{
		if (focusNavigationDirection == FocusNavigationDirection.None)
		{
			throw new ArgumentOutOfRangeException("focusNavigationDirection");
		}
		DXamlCore current = DXamlCore.Current;
		if (current == null)
		{
			throw new InvalidOperationException("XamlCore is not set.");
		}
		FocusManager focusManager = null;
		DependencyObject searchRoot = xyFocusOptions.SearchRoot;
		if (searchRoot != null)
		{
			focusManager = VisualTree.GetFocusManagerForElement(searchRoot);
		}
		else
		{
			if (current.GetHandle().InitializationType == InitializationType.IslandsOnly)
			{
				throw new ArgumentException("The search root must not be null.");
			}
			ContentRoot contentRoot = current.GetHandle().ContentRootCoordinator?.CoreWindowContentRoot;
			if (contentRoot == null)
			{
				return null;
			}
			focusManager = contentRoot.FocusManager;
		}
		if (focusManager == null)
		{
			return null;
		}
		ContentRoot contentRoot2 = focusManager.ContentRoot;
		float rasterizationScaleForContentRoot = RootScale.GetRasterizationScaleForContentRoot(contentRoot2);
		ConvertOptionsRectsToPhysical(rasterizationScaleForContentRoot, xyFocusOptions);
		return focusManager.FindNextFocus(new FindFocusOptions(focusNavigationDirection), xyFocusOptions);
	}

	private static object? GetFocusedElementImpl()
	{
		DXamlCore current = DXamlCore.Current;
		if (current == null)
		{
			throw new InvalidOperationException("XamlCore is not set.");
		}
		return (current.GetHandle().ContentRootCoordinator?.CoreWindowContentRoot)?.FocusManager.FocusedElement;
	}

	private static DependencyObject? GetAppVisibleXamlRootContent(ContentRoot contentRoot)
	{
		XamlRoot orCreateXamlRoot = contentRoot.GetOrCreateXamlRoot();
		return orCreateXamlRoot.Content;
	}

	private static bool TryMoveFocusStatic(FocusNavigationDirection focusNavigationDirection, FindNextElementOptions? pFocusNavigationOverride, ref IAsyncOperation<FocusMovementResult>? asyncOperation, bool useAsync)
	{
		DependencyObject dependencyObject = null;
		XYFocusOptions xyFocusOptions = default(XYFocusOptions);
		bool result = false;
		FocusAsyncOperation focusAsyncOperation = null;
		DXamlCore current = DXamlCore.Current;
		if (current == null)
		{
			throw new InvalidOperationException("XamlCore is not set.");
		}
		FocusManager focusManager = null;
		ContentRoot contentRoot = null;
		ContentRootCoordinator contentRootCoordinator = current.GetHandle().ContentRootCoordinator;
		if (pFocusNavigationOverride != null)
		{
			DependencyObject searchRoot = pFocusNavigationOverride!.SearchRoot;
			Rect exclusionRect = pFocusNavigationOverride!.ExclusionRect;
			Rect hintRect = pFocusNavigationOverride!.HintRect;
			XYFocusNavigationStrategyOverride xYFocusNavigationStrategyOverride = pFocusNavigationOverride!.XYFocusNavigationStrategyOverride;
			bool ignoreOcclusivity = pFocusNavigationOverride!.IgnoreOcclusivity;
			dependencyObject = searchRoot;
			if (dependencyObject != null)
			{
				contentRoot = VisualTree.GetContentRootForElement(dependencyObject);
				focusManager = contentRoot?.FocusManager;
				if (focusManager == null)
				{
					throw new InvalidOperationException("Search root is not part of the visual tree.");
				}
			}
			else
			{
				if (current.GetHandle().InitializationType == InitializationType.IslandsOnly)
				{
					throw new ArgumentException("The search root must not be null.");
				}
				contentRoot = contentRootCoordinator?.CoreWindowContentRoot;
			}
			if (contentRoot != null && GetAppVisibleXamlRootContent(contentRoot) == dependencyObject)
			{
				dependencyObject = contentRoot.VisualTree.RootElement;
			}
			else if (focusNavigationDirection != FocusNavigationDirection.Up && focusNavigationDirection != FocusNavigationDirection.Down && focusNavigationDirection != FocusNavigationDirection.Left && focusNavigationDirection != FocusNavigationDirection.Right)
			{
				throw new ArgumentOutOfRangeException("Focus navigation directions Next, Previous, and None are not supported when using FindNextElementOptions");
			}
			xyFocusOptions.NavigationStrategyOverride = xYFocusNavigationStrategyOverride;
			xyFocusOptions.IgnoreOcclusivity = ignoreOcclusivity;
			Rect value = exclusionRect;
			Rect value2 = hintRect;
			if (dependencyObject != null)
			{
				xyFocusOptions.SearchRoot = dependencyObject;
			}
			if (!value.IsUniform)
			{
				xyFocusOptions.ExclusionRect = value;
			}
			if (!value2.IsUniform)
			{
				xyFocusOptions.FocusHintRectangle = value2;
			}
			if (contentRoot != null)
			{
				float rasterizationScaleForContentRoot = RootScale.GetRasterizationScaleForContentRoot(contentRoot);
				ConvertOptionsRectsToPhysical(rasterizationScaleForContentRoot, xyFocusOptions);
			}
		}
		if (focusManager == null)
		{
			if (current.GetHandle().InitializationType == InitializationType.IslandsOnly)
			{
				throw new InvalidOperationException("Focus navigation options must be set for desktop apps.");
			}
			if (contentRoot == null)
			{
				contentRoot = contentRootCoordinator?.CoreWindowContentRoot;
			}
			if (contentRoot == null)
			{
				return result;
			}
			focusManager = contentRoot.FocusManager;
		}
		FocusMovement focusMovement = new FocusMovement(xyFocusOptions, focusNavigationDirection, null);
		if (useAsync)
		{
			focusAsyncOperation = new FocusAsyncOperation(focusMovement.CorrelationId);
			asyncOperation = focusAsyncOperation.CreateAsyncOperation();
			_ = focusMovement.ShouldCompleteAsyncOperation;
		}
		FocusMovementResult focusMovementResult = focusManager.FindAndSetNextFocus(focusMovement);
		focusAsyncOperation?.CoreSetResults(focusMovementResult);
		focusAsyncOperation?.CoreFireCompletion();
		return focusMovementResult.WasMoved;
	}

	private static IAsyncOperation<FocusMovementResult> TryMoveFocusAsyncImpl(FocusNavigationDirection focusNavigationDirection)
	{
		IAsyncOperation<FocusMovementResult> asyncOperation = null;
		bool flag = TryMoveFocusStatic(focusNavigationDirection, null, ref asyncOperation, useAsync: true);
		return asyncOperation ?? AsyncOperation.FromTask((CancellationToken ct) => Task.FromResult(new FocusMovementResult()));
	}

	private static IAsyncOperation<FocusMovementResult> TryMoveFocusWithOptionsAsyncImpl(FocusNavigationDirection focusNavigationDirection, FindNextElementOptions focusNavigationOptions)
	{
		IAsyncOperation<FocusMovementResult> asyncOperation = null;
		bool flag = TryMoveFocusStatic(focusNavigationDirection, focusNavigationOptions, ref asyncOperation, useAsync: true);
		return asyncOperation ?? AsyncOperation.FromTask((CancellationToken ct) => Task.FromResult(new FocusMovementResult()));
	}

	private static bool TryMoveFocusImpl(FocusNavigationDirection focusNavigationDirection)
	{
		IAsyncOperation<FocusMovementResult> asyncOperation = null;
		return TryMoveFocusStatic(focusNavigationDirection, null, ref asyncOperation, useAsync: false);
	}

	private static bool TryMoveFocusWithOptionsImpl(FocusNavigationDirection focusNavigationDirection, FindNextElementOptions pFocusNavigationOverride)
	{
		IAsyncOperation<FocusMovementResult> asyncOperation = null;
		return TryMoveFocusStatic(focusNavigationDirection, pFocusNavigationOverride, ref asyncOperation, useAsync: false);
	}

	private static IAsyncOperation<FocusMovementResult> TryFocusAsyncImpl(DependencyObject pElement, FocusState focusState)
	{
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(pElement);
		if (focusManagerForElement == null)
		{
			throw new InvalidOperationException("Element is not part of the visual tree.");
		}
		FocusMovement focusMovement = new FocusMovement(pElement, FocusNavigationDirection.None, focusState);
		FocusAsyncOperation focusAsyncOperation = new FocusAsyncOperation(focusMovement.CorrelationId);
		IAsyncOperation<FocusMovementResult> result = focusAsyncOperation.CreateAsyncOperation();
		if (!FocusProperties.IsFocusable(pElement))
		{
			focusAsyncOperation.CoreSetResults(new FocusMovementResult());
		}
		_ = focusMovement.ShouldCompleteAsyncOperation;
		FocusMovementResult coreFocusMovementResult = focusManagerForElement.SetFocusedElement(focusMovement);
		focusAsyncOperation?.CoreSetResults(coreFocusMovementResult);
		focusAsyncOperation?.CoreFireCompletion();
		return result;
	}

	private static UIElement? FindNextFocusableElementImpl(FocusNavigationDirection focusNavigationDirection)
	{
		if (InIslandsMode())
		{
			throw new NotSupportedException("This API is not supported in desktop mode.");
		}
		XYFocusOptions xyFocusOptions = default(XYFocusOptions);
		xyFocusOptions.UpdateManifold = false;
		object obj = FindNextFocus(focusNavigationDirection, xyFocusOptions);
		return obj as UIElement;
	}

	private static UIElement? FindNextFocusableElementWithHintImpl(FocusNavigationDirection focusNavigationDirection, Rect focusHintRectangle)
	{
		if (InIslandsMode())
		{
			throw new NotSupportedException("This API is not supported in desktop mode.");
		}
		XYFocusOptions xyFocusOptions = default(XYFocusOptions);
		xyFocusOptions.UpdateManifold = false;
		xyFocusOptions.FocusHintRectangle = focusHintRectangle;
		object obj = FindNextFocus(focusNavigationDirection, xyFocusOptions);
		return obj as UIElement;
	}

	private object? FindNextFocusWithSearchRootIgnoreEngagementImpl(FocusNavigationDirection focusNavigationDirection, object? pSearchRoot)
	{
		DependencyObject dependencyObject = pSearchRoot as DependencyObject;
		DependencyObject dependencyObject2 = dependencyObject;
		if (dependencyObject2 == null && InIslandsMode())
		{
			throw new ArgumentException("Search root must not be null.", "pSearchRoot");
		}
		XYFocusOptions xyFocusOptions = default(XYFocusOptions);
		xyFocusOptions.SearchRoot = dependencyObject2;
		xyFocusOptions.ConsiderEngagement = false;
		return FindNextFocus(focusNavigationDirection, xyFocusOptions);
	}

	internal static void SetEngagedControl(object pEngagedControl)
	{
		DependencyObject dependencyObject = pEngagedControl as DependencyObject;
		if (VisualTree.GetFocusManagerForElement(dependencyObject)?.EngagedControl != null)
		{
			throw new InvalidOperationException("Another control is already engaged.");
		}
		if (pEngagedControl != null && dependencyObject is Control control)
		{
			control.SetValue(Control.IsFocusEngagedProperty, true);
		}
	}

	private bool SetFocusedElement(DependencyObject pElement, FocusState focusState, bool animateIfBringIntoView, bool forceBringIntoView, bool isProcessingTab, bool isShiftPressed)
	{
		FocusNavigationDirection focusNavigationDirection = FocusNavigationDirection.None;
		if (isProcessingTab)
		{
			focusNavigationDirection = (isShiftPressed ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);
		}
		return SetFocusedElementWithDirection(pElement, focusState, animateIfBringIntoView, forceBringIntoView, focusNavigationDirection);
	}

	internal static bool SetFocusedElementWithDirection(DependencyObject? pElement, FocusState focusState, bool animateIfBringIntoView, bool forceBringIntoView, FocusNavigationDirection focusNavigationDirection)
	{
		bool flag = false;
		if (pElement == null)
		{
			throw new ArgumentNullException("pElement");
		}
		if (pElement is Control control)
		{
			if (animateIfBringIntoView)
			{
				control.SetAnimateIfBringIntoView();
			}
			return control.FocusWithDirection(focusState, focusNavigationDirection);
		}
		bool flag2 = focusNavigationDirection == FocusNavigationDirection.Previous;
		bool isProcessingTab = focusNavigationDirection == FocusNavigationDirection.Next || flag2;
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(pElement);
		FocusMovement focusMovement = new FocusMovement(pElement, focusNavigationDirection, focusState);
		focusMovement.ForceBringIntoView = forceBringIntoView;
		focusMovement.AnimateIfBringIntoView = animateIfBringIntoView;
		focusMovement.IsProcessingTab = isProcessingTab;
		focusMovement.IsShiftPressed = flag2;
		return (focusManagerForElement?.SetFocusedElement(focusMovement))?.WasMoved ?? false;
	}

	private static DependencyObject? FindFirstFocusableElementImpl(DependencyObject? pSearchScope)
	{
		DependencyObject dependencyObject = null;
		if (pSearchScope != null)
		{
			return VisualTree.GetFocusManagerForElement(pSearchScope)?.GetFirstFocusableElement(pSearchScope);
		}
		return DXamlCore.Current.GetHandle().ContentRootCoordinator.CoreWindowContentRoot?.FocusManager.GetFirstFocusableElementFromRoot(useReverseDirection: false);
	}

	private static DependencyObject? FindLastFocusableElementImpl(DependencyObject? pSearchScope)
	{
		DependencyObject dependencyObject = null;
		if (pSearchScope != null)
		{
			return VisualTree.GetFocusManagerForElement(pSearchScope)?.GetLastFocusableElement(pSearchScope);
		}
		return DXamlCore.Current.GetHandle().ContentRootCoordinator.CoreWindowContentRoot?.FocusManager.GetFirstFocusableElementFromRoot(useReverseDirection: true);
	}

	internal static object? FindNextFocusWithSearchRootIgnoreEngagementWithHintRectImpl(FocusNavigationDirection focusNavigationDirection, object pSearchRoot, Rect focusHintRectangle, Rect focusExclusionRectangle)
	{
		DependencyObject dependencyObject = pSearchRoot as DependencyObject;
		object obj = null;
		DependencyObject dependencyObject2 = dependencyObject;
		if (dependencyObject2 == null && InIslandsMode())
		{
			throw new InvalidOperationException("Search root is invalid.");
		}
		XYFocusOptions xyFocusOptions = default(XYFocusOptions);
		xyFocusOptions.SearchRoot = dependencyObject2;
		xyFocusOptions.ConsiderEngagement = false;
		xyFocusOptions.FocusHintRectangle = focusHintRectangle;
		xyFocusOptions.ExclusionRect = focusExclusionRectangle;
		return FindNextFocus(focusNavigationDirection, xyFocusOptions);
	}

	internal static object? FindNextFocusWithSearchRootIgnoreEngagementWithClipImpl(FocusNavigationDirection focusNavigationDirection, object pSearchRoot, bool ignoreClipping, bool ignoreCone)
	{
		DependencyObject dependencyObject = pSearchRoot as DependencyObject;
		object obj = null;
		DependencyObject dependencyObject2 = dependencyObject;
		if (dependencyObject2 == null && InIslandsMode())
		{
			throw new InvalidOperationException("Invalid search root");
		}
		XYFocusOptions xyFocusOptions = default(XYFocusOptions);
		xyFocusOptions.SearchRoot = dependencyObject2;
		xyFocusOptions.ConsiderEngagement = false;
		xyFocusOptions.IgnoreClipping = ignoreClipping;
		xyFocusOptions.IgnoreCone = ignoreCone;
		return FindNextFocus(focusNavigationDirection, xyFocusOptions);
	}

	private static DependencyObject? FindNextElementImpl(FocusNavigationDirection focusNavigationDirection)
	{
		if (InIslandsMode())
		{
			if (typeof(FocusManager).Log().IsEnabled(LogLevel.Error))
			{
				typeof(FocusManager).Log().LogError("FindNextElement override with FindNextElementOptions must be used in WinUI Desktop apps.");
			}
			return null;
		}
		XYFocusOptions xYFocusOptions = default(XYFocusOptions);
		xYFocusOptions.UpdateManifold = false;
		XYFocusOptions xyFocusOptions = xYFocusOptions;
		object obj = FindNextFocus(focusNavigationDirection, xyFocusOptions);
		return obj as DependencyObject;
	}

	private static DependencyObject? FindNextElementWithOptionsImpl(FocusNavigationDirection focusNavigationDirection, FindNextElementOptions pFocusNavigationOverride)
	{
		XYFocusOptions xYFocusOptions = default(XYFocusOptions);
		xYFocusOptions.UpdateManifold = false;
		XYFocusOptions xyFocusOptions = xYFocusOptions;
		DependencyObject dependencyObject = pFocusNavigationOverride.SearchRoot;
		Rect exclusionRect = pFocusNavigationOverride.ExclusionRect;
		Rect hintRect = pFocusNavigationOverride.HintRect;
		XYFocusNavigationStrategyOverride xYFocusNavigationStrategyOverride = pFocusNavigationOverride.XYFocusNavigationStrategyOverride;
		bool ignoreOcclusivity = pFocusNavigationOverride.IgnoreOcclusivity;
		ContentRoot contentRoot = null;
		if (dependencyObject != null)
		{
			contentRoot = VisualTree.GetContentRootForElement(dependencyObject);
		}
		else
		{
			if (InIslandsMode())
			{
				throw new InvalidOperationException("Search root is not a dependency object.");
			}
			contentRoot = DXamlCore.Current.GetHandle().ContentRootCoordinator.CoreWindowContentRoot;
		}
		if (contentRoot != null && GetAppVisibleXamlRootContent(contentRoot) == dependencyObject)
		{
			dependencyObject = contentRoot.VisualTree.RootElement;
		}
		else if (focusNavigationDirection != FocusNavigationDirection.Up && focusNavigationDirection != FocusNavigationDirection.Down && focusNavigationDirection != FocusNavigationDirection.Left && focusNavigationDirection != FocusNavigationDirection.Right)
		{
			throw new ArgumentOutOfRangeException("Focus navigation directions Next, Previous, and None are not supported when using FindNextElementOptions");
		}
		if (dependencyObject != null)
		{
			xyFocusOptions.SearchRoot = dependencyObject;
		}
		if (!exclusionRect.IsUniform)
		{
			xyFocusOptions.ExclusionRect = exclusionRect;
		}
		if (!hintRect.IsUniform)
		{
			xyFocusOptions.FocusHintRectangle = hintRect;
		}
		xyFocusOptions.NavigationStrategyOverride = xYFocusNavigationStrategyOverride;
		xyFocusOptions.IgnoreOcclusivity = ignoreOcclusivity;
		object obj = FindNextFocus(focusNavigationDirection, xyFocusOptions);
		return obj as DependencyObject;
	}

	private static object? GetFocusedElementWithRootImpl(XamlRoot xamlRoot)
	{
		if (xamlRoot == null)
		{
			throw new ArgumentNullException("xamlRoot");
		}
		FocusManager focusManager = xamlRoot.VisualTree.ContentRoot.FocusManager;
		return focusManager.FocusedElement;
	}

	internal static void ProcessControlFocused(Control control)
	{
		if (_log.Value.IsEnabled(LogLevel.Debug))
		{
			_log.Value.LogDebug(string.Format("{0}() focusedElement={1}, control={2}", "ProcessControlFocused", GetFocusedElement(), control));
		}
		if (FocusProperties.IsFocusable(control))
		{
			VisualTree.GetFocusManagerForElement(control)?.UpdateFocus(new FocusMovement(control, FocusNavigationDirection.None, FocusState.Pointer));
		}
	}

	internal static void ProcessElementFocused(UIElement element)
	{
		if (_log.Value.IsEnabled(LogLevel.Debug))
		{
			_log.Value.LogDebug(string.Format("{0}() focusedElement={1}, element={2}, searching for focusable parent control", "ProcessElementFocused", GetFocusedElement(), element));
		}
		foreach (object parent in element.GetParents())
		{
			if (parent is TextBlock textBlock && textBlock.IsFocusable)
			{
				FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(textBlock);
				_skipNativeFocus = true;
				focusManagerForElement?.UpdateFocus(new FocusMovement(textBlock, FocusNavigationDirection.None, FocusState.Pointer));
				_skipNativeFocus = false;
				break;
			}
			if (parent is Control control && control.IsFocusable)
			{
				ProcessControlFocused(control);
				break;
			}
		}
	}

	internal static bool FocusNative(UIElement element)
	{
		if (_log.Value.IsEnabled(LogLevel.Debug))
		{
			_log.Value.LogDebug(string.Format("{0}(element: {1})", "FocusNative", element));
		}
		if (_skipNativeFocus)
		{
			_log.Value.LogDebug("FocusNative skipping native focus");
			return false;
		}
		if (element == null)
		{
			return false;
		}
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(element);
		if (focusManagerForElement != null && focusManagerForElement.InitialFocus)
		{
			return false;
		}
		if (element is TextBox textBox)
		{
			return textBox.FocusTextView();
		}
		_isCallingFocusNative = true;
		string str = $"Uno.UI.WindowManager.current.focusView({element.HtmlId});";
		WebAssemblyRuntime.InvokeJS(str);
		_isCallingFocusNative = false;
		return true;
	}

	[Preserve]
	public static void ReceiveFocusNative(int handle)
	{
		if (!_isCallingFocusNative)
		{
			UIElement focusElementFromHandle = GetFocusElementFromHandle(handle);
			if (_log.Value.IsEnabled(LogLevel.Debug))
			{
				_log.Value.LogDebug("ReceiveFocusNative(" + (focusElementFromHandle?.ToString() ?? "[null]") + ")");
			}
			if (focusElementFromHandle is Control control)
			{
				ProcessControlFocused(control);
				return;
			}
			if (focusElementFromHandle != null)
			{
				ProcessElementFocused(focusElementFromHandle);
				return;
			}
			FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(Window.Current.RootElement);
			focusManagerForElement.ClearFocus();
		}
	}

	private static UIElement GetFocusElementFromHandle(int handle)
	{
		if (handle == -1)
		{
			return null;
		}
		return UIElement.GetElementFromHandle(handle);
	}
}

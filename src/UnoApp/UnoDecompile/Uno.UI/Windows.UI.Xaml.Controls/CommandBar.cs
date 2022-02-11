using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DirectUI;
using Uno.Disposables;
using Uno.UI;
using Uno.UI.Extensions;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "PrimaryCommands")]
public class CommandBar : AppBar, IMenu
{
	private enum OverflowInitialFocusItem
	{
		None,
		FirstItem,
		LastItem
	}

	private ItemsControl? m_tpPrimaryItemsControlPart;

	private ItemsControl? m_tpSecondaryItemsControlPart;

	private CommandBarElementCollection? m_tpPrimaryCommands;

	private CommandBarElementCollection? m_tpSecondaryCommands;

	private ObservableCollection<ICommandBarElement>? m_tpDynamicPrimaryCommands;

	private ObservableCollection<ICommandBarElement>? m_tpDynamicSecondaryCommands;

	private IterableWrappedObservableCollection<ICommandBarElement>? m_tpWrappedPrimaryCommands;

	private IterableWrappedObservableCollection<ICommandBarElement>? m_tpWrappedSecondaryCommands;

	private TrackerCollection<ICommandBarElement>? m_tpPrimaryCommandsInTransition;

	private TrackerCollection<ICommandBarElement>? m_tpPrimaryCommandsInPreviousTransition;

	private readonly SerialDisposable m_unloadedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_primaryCommandsChangedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_secondaryCommandsChangedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_secondaryItemsControlLoadedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_contentRootSizeChangedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_overflowContentSizeChangedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_overflowPopupClosedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_overflowPresenterItemsPresenterKeyDownEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_accessKeyInvokedEventHandler = new SerialDisposable();

	private readonly SerialDisposable m_overflowPopupOpenedEventHandler = new SerialDisposable();

	private FrameworkElement? m_tpContentControl;

	private FrameworkElement? m_tpOverflowContentRoot;

	private Popup? m_tpOverflowPopup;

	private ItemsPresenter? m_tpOverflowPresenterItemsPresenter;

	private FrameworkElement? m_tpWindowedPopupPadding;

	private double m_overflowContentMinWidth;

	private double m_overflowContentTouchMinWidth;

	private double m_overflowContentMaxWidth = 480.0;

	private double m_restorablePrimaryCommandMinWidth;

	private bool m_skipProcessTabStopOverride;

	private bool m_hasAlreadyFiredOverflowChangingEvent;

	private bool m_hasAppBarSeparatorInOverflow;

	private bool m_isDynamicOverflowEnabled = true;

	private int m_SecondaryCommandStartIndex;

	private OverflowInitialFocusItem m_overflowInitialFocusItem;

	private AppBarSeparator? m_tpAppBarSeparatorInOverflow;

	private ICommandBarElement? m_focusedElementPriorToCollectionOrSizeChange;

	private FocusState m_focusStatePriorToCollectionOrSizeChange;

	private double m_lastAvailableWidth;

	IMenu? IMenu.ParentMenu
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Style CommandBarOverflowPresenterStyle
	{
		get
		{
			return (Style)GetValue(CommandBarOverflowPresenterStyleProperty);
		}
		set
		{
			SetValue(CommandBarOverflowPresenterStyleProperty, value);
		}
	}

	public static DependencyProperty CommandBarOverflowPresenterStyleProperty { get; } = DependencyProperty.Register("CommandBarOverflowPresenterStyle", typeof(Style), typeof(CommandBar), new FrameworkPropertyMetadata(null));


	public CommandBarTemplateSettings CommandBarTemplateSettings
	{
		get
		{
			return (CommandBarTemplateSettings)GetValue(CommandBarTemplateSettingsProperty);
		}
		set
		{
			SetValue(CommandBarTemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty CommandBarTemplateSettingsProperty { get; } = DependencyProperty.Register("CommandBarTemplateSettings", typeof(CommandBarTemplateSettings), typeof(CommandBar), new FrameworkPropertyMetadata(null));


	public CommandBarDefaultLabelPosition DefaultLabelPosition
	{
		get
		{
			return (CommandBarDefaultLabelPosition)GetValue(DefaultLabelPositionProperty);
		}
		set
		{
			SetValue(DefaultLabelPositionProperty, value);
		}
	}

	public static DependencyProperty DefaultLabelPositionProperty { get; } = DependencyProperty.Register("DefaultLabelPosition", typeof(CommandBarDefaultLabelPosition), typeof(CommandBar), new FrameworkPropertyMetadata(CommandBarDefaultLabelPosition.Bottom));


	public bool IsDynamicOverflowEnabled
	{
		get
		{
			return (bool)GetValue(IsDynamicOverflowEnabledProperty);
		}
		set
		{
			SetValue(IsDynamicOverflowEnabledProperty, value);
		}
	}

	public static DependencyProperty IsDynamicOverflowEnabledProperty { get; } = DependencyProperty.Register("IsDynamicOverflowEnabled", typeof(bool), typeof(CommandBar), new FrameworkPropertyMetadata(true));


	public CommandBarOverflowButtonVisibility OverflowButtonVisibility
	{
		get
		{
			return (CommandBarOverflowButtonVisibility)GetValue(OverflowButtonVisibilityProperty);
		}
		set
		{
			SetValue(OverflowButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty OverflowButtonVisibilityProperty { get; } = DependencyProperty.Register("OverflowButtonVisibility", typeof(CommandBarOverflowButtonVisibility), typeof(CommandBar), new FrameworkPropertyMetadata(CommandBarOverflowButtonVisibility.Auto));


	public IObservableVector<ICommandBarElement> PrimaryCommands
	{
		get
		{
			return (IObservableVector<ICommandBarElement>)GetValue(PrimaryCommandsProperty);
		}
		private set
		{
			SetValue(PrimaryCommandsProperty, value);
		}
	}

	public static DependencyProperty PrimaryCommandsProperty { get; } = DependencyProperty.Register("PrimaryCommands", typeof(IObservableVector<ICommandBarElement>), typeof(CommandBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext));


	public IObservableVector<ICommandBarElement> SecondaryCommands
	{
		get
		{
			return (IObservableVector<ICommandBarElement>)GetValue(SecondaryCommandsProperty);
		}
		private set
		{
			SetValue(SecondaryCommandsProperty, value);
		}
	}

	public static DependencyProperty SecondaryCommandsProperty { get; } = DependencyProperty.Register("SecondaryCommands", typeof(IObservableVector<ICommandBarElement>), typeof(CommandBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext));


	public event TypedEventHandler<CommandBar, DynamicOverflowItemsChangingEventArgs>? DynamicOverflowItemsChanging;

	public CommandBar()
	{
		base.DefaultStyleKey = typeof(CommandBar);
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		m_unloadedEventHandler.Disposable = null;
		m_primaryCommandsChangedEventHandler.Disposable = null;
		m_secondaryCommandsChangedEventHandler.Disposable = null;
		m_secondaryItemsControlLoadedEventHandler.Disposable = null;
		m_contentRootSizeChangedEventHandler.Disposable = null;
		m_overflowContentSizeChangedEventHandler.Disposable = null;
		m_overflowPopupClosedEventHandler.Disposable = null;
		m_overflowPresenterItemsPresenterKeyDownEventHandler.Disposable = null;
		m_accessKeyInvokedEventHandler.Disposable = null;
		m_overflowPopupOpenedEventHandler.Disposable = null;
		if (m_tpOverflowPopup != null)
		{
			m_tpOverflowPopup!.IsOpen = false;
		}
		if (!base.IsOpen)
		{
			SetCompactMode(isCompact: true);
		}
	}

	protected override void PrepareState()
	{
		base.PrepareState();
		CommandBarElementCollection commandBarElementCollection = new CommandBarElementCollection();
		commandBarElementCollection.Init(this, notifyCollectionChanging: false);
		m_tpPrimaryCommands = commandBarElementCollection;
		CommandBarElementCollection commandBarElementCollection2 = new CommandBarElementCollection();
		commandBarElementCollection2.Init(this, notifyCollectionChanging: true);
		m_tpSecondaryCommands = commandBarElementCollection2;
		PrimaryCommands = m_tpPrimaryCommands;
		SecondaryCommands = m_tpSecondaryCommands;
		m_tpPrimaryCommands!.VectorChanged += new VectorChangedEventHandler<ICommandBarElement>(OnPrimaryCommandsChanged);
		m_primaryCommandsChangedEventHandler.Disposable = Disposable.Create(delegate
		{
			m_tpPrimaryCommands!.VectorChanged -= new VectorChangedEventHandler<ICommandBarElement>(OnPrimaryCommandsChanged);
		});
		m_tpSecondaryCommands!.VectorChanged += new VectorChangedEventHandler<ICommandBarElement>(OnSecondaryCommandsChanged);
		m_secondaryCommandsChangedEventHandler.Disposable = Disposable.Create(delegate
		{
			m_tpSecondaryCommands!.VectorChanged -= new VectorChangedEventHandler<ICommandBarElement>(OnSecondaryCommandsChanged);
		});
		m_tpDynamicPrimaryCommands = new ObservableCollection<ICommandBarElement>();
		m_tpDynamicSecondaryCommands = new ObservableCollection<ICommandBarElement>();
		m_tpPrimaryCommandsInPreviousTransition = new TrackerCollection<ICommandBarElement>();
		m_tpPrimaryCommandsInTransition = new TrackerCollection<ICommandBarElement>();
		m_tpAppBarSeparatorInOverflow = new AppBarSeparator();
		CommandBarTemplateSettings = new CommandBarTemplateSettings();
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == DefaultLabelPositionProperty)
		{
			PropagateDefaultLabelPosition();
			UpdateVisualState();
		}
		else if (args.Property == IsDynamicOverflowEnabledProperty)
		{
			if (m_isDynamicOverflowEnabled != (bool)args.NewValue)
			{
				m_isDynamicOverflowEnabled = (bool)args.NewValue;
				ResetDynamicCommands();
				InvalidateMeasure();
				UpdateVisualState();
			}
		}
		else if (args.Property == AppBar.ClosedDisplayModeProperty || args.Property == OverflowButtonVisibilityProperty)
		{
			UpdateTemplateSettings();
		}
		else if (args.Property == UIElement.VisibilityProperty)
		{
			ResetCommandBarElementFocus();
		}
	}

	protected override void OnApplyTemplate()
	{
		if (m_tpSecondaryItemsControlPart != null)
		{
			m_secondaryItemsControlLoadedEventHandler.Disposable = null;
		}
		if (m_tpOverflowContentRoot != null)
		{
			m_overflowContentSizeChangedEventHandler.Disposable = null;
		}
		if (m_tpOverflowPresenterItemsPresenter != null)
		{
			m_overflowPresenterItemsPresenterKeyDownEventHandler.Disposable = null;
		}
		if (m_tpOverflowPopup != null)
		{
			m_overflowPopupClosedEventHandler.Disposable = null;
		}
		m_tpContentControl = null;
		m_tpOverflowContentRoot = null;
		m_tpOverflowPopup = null;
		m_tpOverflowPresenterItemsPresenter = null;
		m_tpWindowedPopupPadding = null;
		base.OnApplyTemplate();
		GetTemplatePart<ItemsControl>("PrimaryItemsControl", out m_tpPrimaryItemsControlPart);
		GetTemplatePart<ItemsControl>("SecondaryItemsControl", out m_tpSecondaryItemsControlPart);
		if (m_tpSecondaryItemsControlPart != null)
		{
			m_tpSecondaryItemsControlPart!.Loaded += OnSecondaryItemsControlLoaded;
			m_secondaryItemsControlLoadedEventHandler.Disposable = Disposable.Create(delegate
			{
				m_tpSecondaryItemsControlPart!.Loaded -= OnSecondaryItemsControlLoaded;
			});
		}
		GetTemplatePart<FrameworkElement>("ContentControl", out var element);
		GetTemplatePart<FrameworkElement>("OverflowContentRoot", out var element2);
		GetTemplatePart<Popup>("OverflowPopup", out var element3);
		GetTemplatePart<FrameworkElement>("WindowedPopupPadding", out var element4);
		m_tpContentControl = element;
		m_tpOverflowContentRoot = element2;
		if (m_tpOverflowContentRoot != null)
		{
			m_tpOverflowContentRoot!.SizeChanged += OnOverflowContentRootSizeChanged;
			m_overflowContentSizeChangedEventHandler.Disposable = Disposable.Create(delegate
			{
				m_tpOverflowContentRoot!.SizeChanged -= OnOverflowContentRootSizeChanged;
			});
		}
		m_tpOverflowPopup = element3;
		if (m_tpOverflowPopup != null)
		{
			m_tpOverflowPopup!.IsSubMenu = true;
			m_tpOverflowPopup!.Closed += OnOverflowPopupClosed;
			m_overflowPopupClosedEventHandler.Disposable = Disposable.Create(delegate
			{
				m_tpOverflowPopup!.Closed -= OnOverflowPopupClosed;
			});
		}
		m_tpWindowedPopupPadding = element4;
		m_overflowContentMinWidth = ResourceResolver.ResolveTopLevelResourceDouble("CommandBarOverflowMinWidth");
		m_overflowContentTouchMinWidth = ResourceResolver.ResolveTopLevelResourceDouble("CommandBarOverflowTouchMinWidth");
		m_overflowContentMaxWidth = ResourceResolver.ResolveTopLevelResourceDouble("CommandBarOverflowMaxWidth");
		CommandBarTemplateSettings commandBarTemplateSettings = CommandBarTemplateSettings;
		if (commandBarTemplateSettings != null)
		{
			commandBarTemplateSettings.OverflowContentMaxWidth = m_overflowContentMaxWidth;
		}
		ConfigureItemsControls();
		if (!base.IsOpen)
		{
			SetCompactMode(isCompact: true);
		}
		SetOverflowStyleParams();
		PropagateDefaultLabelPosition();
		int num = m_tpDynamicSecondaryCommands?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			SetOverflowStyleAndInputModeOnSecondaryCommand(i, isItemInOverflow: true);
		}
		if (m_tpExpandButton != null && m_tpSecondaryItemsControlPart != null && m_tpExpandButton!.IsAccessKeyScope)
		{
			m_tpSecondaryItemsControlPart!.AccessKeyScopeOwner = m_tpExpandButton;
			base.AccessKeyInvoked += OnAccessKeyInvoked;
			m_accessKeyInvokedEventHandler.Disposable = Disposable.Create(delegate
			{
				base.AccessKeyInvoked -= OnAccessKeyInvoked;
			});
		}
		UpdateVisualState();
	}

	private void OnOverflowPopupClosed(object? sender, object e)
	{
		base.IsOpen = false;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (m_isDynamicOverflowEnabled)
		{
			return MeasureOverrideForDynamicOverflow(availableSize);
		}
		return base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size result = base.ArrangeOverride(finalSize);
		RestoreCommandBarElementFocus();
		return result;
	}

	private Size MeasureOverrideForDynamicOverflow(Size availableSize)
	{
		Size size = default(Size);
		Size size2 = default(Size);
		Size result = base.MeasureOverride(availableSize);
		if (m_tpPrimaryItemsControlPart != null && m_tpContentRoot != null)
		{
			size2 = m_tpPrimaryItemsControlPart!.DesiredSize;
			m_tpContentRoot!.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			size = m_tpContentRoot!.DesiredSize;
			if (size.Width > availableSize.Width)
			{
				int num = 0;
				num = m_tpDynamicPrimaryCommands?.Count ?? 0;
				if (num > 0)
				{
					int primaryCommandsCountInTransition = 0;
					Size size3 = default(Size);
					m_tpPrimaryItemsControlPart!.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
					FindMovablePrimaryCommands(primaryItemsControlDesiredWidth: m_tpPrimaryItemsControlPart!.DesiredSize.Width, availablePrimaryCommandsWidth: size2.Width, primaryCommandsCountInTransition: out primaryCommandsCountInTransition);
					if (primaryCommandsCountInTransition > 0)
					{
						TrimPrimaryCommandSeparatorInOverflow(ref primaryCommandsCountInTransition);
						if (primaryCommandsCountInTransition > 0)
						{
							if (!m_hasAlreadyFiredOverflowChangingEvent)
							{
								FireDynamicOverflowItemsChangingEvent(isForceToRestore: false);
							}
							UpdatePrimaryCommandElementMinWidthInOverflow();
							MoveTransitionPrimaryCommandsIntoOverflow(primaryCommandsCountInTransition);
							SetOverflowStyleParams();
							SaveMovedPrimaryCommandsIntoPreviousTransitionCollection();
						}
						UpdateVisualState();
					}
				}
			}
			else if (m_lastAvailableWidth < availableSize.Width && m_SecondaryCommandStartIndex > 0 && m_restorablePrimaryCommandMinWidth >= 0.0)
			{
				int num2 = 0;
				double num3 = m_restorablePrimaryCommandMinWidth;
				double num4 = availableSize.Width - size.Width;
				num2 = GetRestorablePrimaryCommandsMinimumCount();
				if (num2 > 0)
				{
					num3 *= (double)num2;
				}
				if (num4 > num3)
				{
					FireDynamicOverflowItemsChangingEvent(isForceToRestore: true);
					m_hasAlreadyFiredOverflowChangingEvent = true;
					ResetDynamicCommands();
					SaveMovedPrimaryCommandsIntoPreviousTransitionCollection();
					m_tpPrimaryItemsControlPart!.SetNeedsUpdateItems();
					SetOverflowStyleParams();
					UpdateVisualState();
				}
			}
		}
		m_hasAlreadyFiredOverflowChangingEvent = false;
		m_lastAvailableWidth = availableSize.Width;
		return result;
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		base.ChangeVisualState(useTransitions);
		bool flag = false;
		flag = HasVisibleElements(m_tpDynamicPrimaryCommands);
		bool flag2 = false;
		flag2 = HasVisibleElements(m_tpDynamicSecondaryCommands);
		string stateName = ((flag && flag2) ? "BothCommands" : ((!flag2) ? "PrimaryCommandsOnly" : "SecondaryCommandsOnly"));
		GoToState(useTransitions, stateName);
		if (m_isDynamicOverflowEnabled)
		{
			GoToState(useTransitions, "DynamicOverflowEnabled");
		}
		else
		{
			GoToState(useTransitions, "DynamicOverflowDisabled");
		}
	}

	private void ConfigureItemsControls()
	{
		ResetDynamicCommands();
		if (m_tpPrimaryItemsControlPart != null)
		{
			IterableWrappedObservableCollection<ICommandBarElement> tpWrappedPrimaryCommands = new IterableWrappedObservableCollection<ICommandBarElement>();
			m_tpPrimaryItemsControlPart!.ItemsSource = m_tpDynamicPrimaryCommands;
			m_tpWrappedPrimaryCommands = tpWrappedPrimaryCommands;
		}
		if (m_tpSecondaryItemsControlPart != null)
		{
			IterableWrappedObservableCollection<ICommandBarElement> tpWrappedSecondaryCommands = new IterableWrappedObservableCollection<ICommandBarElement>();
			m_tpSecondaryItemsControlPart!.ItemsSource = m_tpDynamicSecondaryCommands;
			m_tpWrappedSecondaryCommands = tpWrappedSecondaryCommands;
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		base.OnKeyDown(args);
		bool flag = false;
		if (args.Handled)
		{
			return;
		}
		VirtualKey key = args.Key;
		VirtualKey originalKey = args.OriginalKey;
		bool flag2 = false;
		bool flag3 = false;
		if (IsGamepadNavigationDirection(originalKey))
		{
			flag2 = true;
			bool isOpen = base.IsOpen;
			flag3 = isOpen;
		}
		if (!flag2 || flag3)
		{
			bool handled = false;
			switch (key)
			{
			case VirtualKey.Left:
			case VirtualKey.Right:
				handled = OnLeftRightKeyDown(key == VirtualKey.Left);
				break;
			case VirtualKey.Up:
			case VirtualKey.Down:
				handled = OnUpDownKeyDown(key == VirtualKey.Up, !flag2);
				break;
			}
			args.Handled = handled;
		}
	}

	private bool OnLeftRightKeyDown(bool isLeftKey)
	{
		bool flag = false;
		VirtualKeyModifiers virtualKeyModifiers = VirtualKeyModifiers.None;
		GetKeyboardModifiers(out virtualKeyModifiers);
		if ((virtualKeyModifiers & VirtualKeyModifiers.Menu) != 0)
		{
			return false;
		}
		bool flag2 = true;
		FlowDirection flowDirection = FlowDirection.LeftToRight;
		flowDirection = base.FlowDirection;
		flag2 = (flowDirection == FlowDirection.LeftToRight && !isLeftKey) || (flowDirection == FlowDirection.RightToLeft && isLeftKey);
		ShiftFocusHorizontally(flag2);
		return true;
	}

	private bool OnUpDownKeyDown(bool isUpKey, bool allowFocusWrap)
	{
		bool wasFocusSet = false;
		if (m_tpExpandButton == null)
		{
			return false;
		}
		VirtualKeyModifiers virtualKeyModifiers = VirtualKeyModifiers.None;
		GetKeyboardModifiers(out virtualKeyModifiers);
		if ((virtualKeyModifiers & VirtualKeyModifiers.Menu) != 0)
		{
			return false;
		}
		object focusedElement = FocusManager.GetFocusedElement();
		if (m_tpExpandButton == focusedElement)
		{
			if (base.IsOpen)
			{
				bool shouldOpenUp = GetShouldOpenUp();
				if (isUpKey)
				{
					if (allowFocusWrap || shouldOpenUp)
					{
						SetFocusedElementInOverflow(focusFirstElement: false, out wasFocusSet);
					}
				}
				else if (allowFocusWrap || !shouldOpenUp)
				{
					SetFocusedElementInOverflow(focusFirstElement: true, out wasFocusSet);
				}
			}
			else
			{
				m_overflowInitialFocusItem = ((!isUpKey) ? OverflowInitialFocusItem.FirstItem : OverflowInitialFocusItem.LastItem);
				base.IsOpen = true;
				wasFocusSet = true;
			}
		}
		return wasFocusSet;
	}

	private void ShiftFocusVerticallyInOverflow(bool topToBottom, bool allowFocusWrap = true)
	{
		object focusedElement = FocusManager.GetFocusedElement();
		DependencyObject dependencyObject = null;
		dependencyObject = ((!topToBottom) ? FocusManager.FindFirstFocusableElement(m_tpOverflowPresenterItemsPresenter) : FocusManager.FindLastFocusableElement(m_tpOverflowPresenterItemsPresenter));
		if (focusedElement == dependencyObject)
		{
			bool shouldOpenUp = GetShouldOpenUp();
			if (allowFocusWrap || !(shouldOpenUp ^ topToBottom))
			{
				this.SetFocusedElement(m_tpExpandButton, FocusState.Keyboard, animateIfBringIntoView: false);
				DXamlCore.Current.GetElementSoundPlayerServiceNoRef().RequestInteractionSoundForElement(ElementSoundKind.Focus, this);
			}
		}
		else
		{
			FocusManager.TryMoveFocus(topToBottom ? FocusNavigationDirection.Down : FocusNavigationDirection.Up);
			DXamlCore.Current.GetElementSoundPlayerServiceNoRef().RequestInteractionSoundForElement(ElementSoundKind.Focus, this);
		}
	}

	private void HandleTabKeyPressedInOverflow(bool isShiftKeyPressed, out bool wasHandled)
	{
		wasHandled = false;
		KeyboardNavigationMode keyboardNavigationMode = KeyboardNavigationMode.Local;
		if (m_tpSecondaryItemsControlPart != null)
		{
			keyboardNavigationMode = m_tpSecondaryItemsControlPart!.TabNavigation;
		}
		bool flag = keyboardNavigationMode == KeyboardNavigationMode.Once;
		if (!flag)
		{
			object focusedElement = FocusManager.GetFocusedElement();
			DependencyObject dependencyObject = null;
			dependencyObject = ((!isShiftKeyPressed) ? FocusManager.FindFirstFocusableElement(m_tpOverflowPresenterItemsPresenter) : FocusManager.FindLastFocusableElement(m_tpOverflowPresenterItemsPresenter));
			flag = focusedElement == dependencyObject;
		}
		if (!flag)
		{
			return;
		}
		DependencyObject dependencyObject2 = null;
		bool flag2 = false;
		if (isShiftKeyPressed)
		{
			dependencyObject2 = FocusManager.FindLastFocusableElement(this);
		}
		else
		{
			bool isSticky = base.IsSticky;
			flag2 = isSticky;
			dependencyObject2 = ((!flag2) ? FocusManager.FindFirstFocusableElement(this) : FocusManager.FindLastFocusableElement(this));
		}
		if (dependencyObject2 != null)
		{
			this.SetFocusedElement(dependencyObject2, FocusState.Keyboard, animateIfBringIntoView: false, isProcessingTab: true, isShiftKeyPressed);
			if (flag2)
			{
				m_skipProcessTabStopOverride = true;
				FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
				DXamlCore.Current.GetElementSoundPlayerServiceNoRef().RequestInteractionSoundForElement(ElementSoundKind.Focus, this);
				m_skipProcessTabStopOverride = false;
			}
		}
		wasHandled = true;
	}

	private void SetFocusedElementInOverflow(bool focusFirstElement, out bool wasFocusSet)
	{
		wasFocusSet = false;
		if (m_tpOverflowPresenterItemsPresenter != null)
		{
			DependencyObject dependencyObject = null;
			dependencyObject = ((!focusFirstElement) ? FocusManager.FindLastFocusableElement(m_tpOverflowPresenterItemsPresenter) : FocusManager.FindFirstFocusableElement(m_tpOverflowPresenterItemsPresenter));
			if (dependencyObject != null)
			{
				bool flag = (wasFocusSet = this.SetFocusedElement(dependencyObject, FocusState.Keyboard, animateIfBringIntoView: false));
			}
		}
	}

	internal override TabStopProcessingResult ProcessTabStopOverride(DependencyObject? focusedElement, DependencyObject? candidateTabStopElement, bool isBackward, bool didCycleFocusAtRootVisualScope)
	{
		TabStopProcessingResult result = base.ProcessTabStopOverride(focusedElement, candidateTabStopElement, isBackward, didCycleFocusAtRootVisualScope);
		if (isBackward)
		{
			return result;
		}
		if (m_skipProcessTabStopOverride)
		{
			return result;
		}
		if (base.IsOpen && m_tpOverflowPresenterItemsPresenter != null)
		{
			DependencyObject dependencyObject = FocusManager.FindLastFocusableElement(this);
			if (focusedElement != null && focusedElement == dependencyObject)
			{
				DependencyObject dependencyObject2 = FocusManager.FindFirstFocusableElement(m_tpOverflowPresenterItemsPresenter);
				if (dependencyObject2 != null)
				{
					if (result.IsOverriden)
					{
						result.NewTabStop = null;
					}
					result.NewTabStop = dependencyObject2;
					result.IsOverriden = true;
				}
			}
		}
		return result;
	}

	internal override TabStopProcessingResult ProcessCandidateTabStopOverride(DependencyObject? focusedElement, DependencyObject? candidateTabStopElement, DependencyObject? overriddenCandidateTabStopElement, bool isBackward)
	{
		TabStopProcessingResult tabStopProcessingResult = default(TabStopProcessingResult);
		tabStopProcessingResult.NewTabStop = null;
		tabStopProcessingResult.IsOverriden = false;
		TabStopProcessingResult result = tabStopProcessingResult;
		if (!isBackward)
		{
			return result;
		}
		if (base.IsOpen && m_tpOverflowPresenterItemsPresenter != null)
		{
			DependencyObject dependencyObject = FocusManager.FindLastFocusableElement(this);
			if (candidateTabStopElement != null && candidateTabStopElement == dependencyObject)
			{
				DependencyObject dependencyObject2 = null;
				KeyboardNavigationMode keyboardNavigationMode = KeyboardNavigationMode.Local;
				if (m_tpSecondaryItemsControlPart != null)
				{
					keyboardNavigationMode = m_tpSecondaryItemsControlPart!.TabNavigation;
				}
				dependencyObject2 = ((keyboardNavigationMode != KeyboardNavigationMode.Once) ? FocusManager.FindLastFocusableElement(m_tpOverflowPresenterItemsPresenter) : FocusManager.FindFirstFocusableElement(m_tpOverflowPresenterItemsPresenter));
				if (dependencyObject2 != null)
				{
					result.NewTabStop = dependencyObject2;
					result.IsOverriden = true;
				}
			}
		}
		return result;
	}

	private void ShiftFocusHorizontally(bool moveToRight)
	{
		if (m_tpContentControl != null)
		{
			object focusedElement = FocusManager.GetFocusedElement();
			if (m_tpContentControl.IsAncestorOf(focusedElement as DependencyObject))
			{
				return;
			}
			DependencyObject dependencyObject = null;
			if (moveToRight)
			{
				if (m_tpExpandButton != null)
				{
					dependencyObject = m_tpExpandButton;
				}
				if (dependencyObject == null && m_tpPrimaryItemsControlPart != null)
				{
					dependencyObject = FocusManager.FindLastFocusableElement(m_tpPrimaryItemsControlPart);
				}
			}
			else
			{
				if (m_tpPrimaryItemsControlPart != null)
				{
					dependencyObject = FocusManager.FindFirstFocusableElement(m_tpPrimaryItemsControlPart);
				}
				if (dependencyObject == null && m_tpExpandButton != null)
				{
					dependencyObject = m_tpExpandButton;
				}
			}
			if (focusedElement == dependencyObject)
			{
				return;
			}
		}
		FocusManager.TryMoveFocus(moveToRight ? FocusNavigationDirection.Right : FocusNavigationDirection.Left);
		DXamlCore.Current.GetElementSoundPlayerServiceNoRef().RequestInteractionSoundForElement(ElementSoundKind.Focus, this);
	}

	protected override void OnOpening(object e)
	{
		base.OnOpening(e);
		SetCompactMode(isCompact: false);
		if (m_tpOverflowPopup != null)
		{
			m_tpOverflowPopup!.IsOpen = true;
		}
		if (m_tpOverflowContentRoot != null)
		{
			m_tpOverflowContentRoot!.UpdateLayout();
		}
	}

	protected override void OnClosing(object e)
	{
		base.OnClosing(e);
		CloseSubMenus(null, closeOnDelay: false);
	}

	protected override void OnClosed(object e)
	{
		SetCompactMode(isCompact: true);
		if (m_tpOverflowPopup != null)
		{
			m_tpOverflowPopup!.IsOpen = false;
		}
		base.OnClosed(e);
	}

	private void SetOverflowStyleAndInputModeOnSecondaryCommand(int index, bool isItemInOverflow)
	{
		ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[index];
		if (commandBarElement != null)
		{
			SetOverflowStyleUsage(commandBarElement, isItemInOverflow);
		}
	}

	private void SetOverflowStyleUsage(ICommandBarElement? element, bool isItemInOverflow)
	{
		if (element is ICommandBarOverflowElement commandBarOverflowElement)
		{
			commandBarOverflowElement.UseOverflowStyle = isItemInOverflow;
		}
	}

	private void SetOverflowStyleParams()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		num = m_tpDynamicSecondaryCommands?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[i];
			if (commandBarElement != null)
			{
				AppBarButton appBarButton = null;
				AppBarToggleButton appBarToggleButton = null;
				IconElement iconElement = null;
				string text = null;
				if (commandBarElement is AppBarButton appBarButton2)
				{
					iconElement = appBarButton2.Icon;
					flag2 = flag2 || iconElement != null;
					text = appBarButton2.KeyboardAcceleratorTextOverride;
					flag3 = flag3 || !string.IsNullOrWhiteSpace(text);
				}
				else if (commandBarElement is AppBarToggleButton appBarToggleButton2)
				{
					flag = true;
					iconElement = appBarToggleButton2.Icon;
					flag2 = flag2 || iconElement != null;
					text = appBarToggleButton2.KeyboardAcceleratorTextOverride;
					flag3 = flag3 || !string.IsNullOrWhiteSpace(text);
				}
				if (flag2 && flag && flag3)
				{
					break;
				}
			}
		}
		for (int j = 0; j < num; j++)
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicSecondaryCommands?[j];
			if (commandBarElement2 != null)
			{
				AppBarButton appBarButton3 = null;
				AppBarToggleButton appBarToggleButton3 = null;
				if (commandBarElement2 is AppBarButton appBarButton4)
				{
					appBarButton4.SetOverflowStyleParams(flag2, flag, flag3);
				}
				else if (commandBarElement2 is AppBarToggleButton appBarToggleButton4)
				{
					appBarToggleButton4.SetOverflowStyleParams(flag2, flag3);
				}
			}
		}
	}

	private void PropagateDefaultLabelPosition()
	{
		int num = m_tpDynamicPrimaryCommands?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[i];
			if (commandBarElement != null)
			{
				PropagateDefaultLabelPositionToElement(commandBarElement);
			}
		}
		int num2 = m_tpDynamicSecondaryCommands?.Count ?? 0;
		for (int j = 0; j < num2; j++)
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicSecondaryCommands?[j];
			if (commandBarElement2 != null)
			{
				PropagateDefaultLabelPositionToElement(commandBarElement2);
			}
		}
	}

	private void PropagateDefaultLabelPositionToElement(ICommandBarElement element)
	{
		if (element is ICommandBarLabeledElement commandBarLabeledElement)
		{
			CommandBarDefaultLabelPosition defaultLabelPosition = DefaultLabelPosition;
			commandBarLabeledElement.SetDefaultLabelPosition(defaultLabelPosition);
		}
	}

	private bool IsGamepadNavigationDirection(VirtualKey key)
	{
		if (!IsGamepadNavigationRight(key) && !IsGamepadNavigationLeft(key) && !IsGamepadNavigationUp(key))
		{
			return IsGamepadNavigationDown(key);
		}
		return true;
	}

	private bool IsGamepadNavigationRight(VirtualKey key)
	{
		if (key != VirtualKey.GamepadLeftThumbstickRight)
		{
			return key == VirtualKey.GamepadDPadRight;
		}
		return true;
	}

	private bool IsGamepadNavigationLeft(VirtualKey key)
	{
		if (key != VirtualKey.GamepadLeftThumbstickLeft)
		{
			return key == VirtualKey.GamepadDPadLeft;
		}
		return true;
	}

	private bool IsGamepadNavigationUp(VirtualKey key)
	{
		if (key != VirtualKey.GamepadLeftThumbstickUp)
		{
			return key == VirtualKey.GamepadDPadUp;
		}
		return true;
	}

	private bool IsGamepadNavigationDown(VirtualKey key)
	{
		if (key != VirtualKey.GamepadLeftThumbstickDown)
		{
			return key == VirtualKey.GamepadDPadDown;
		}
		return true;
	}

	private void OnPrimaryCommandsChanged(IObservableVector<ICommandBarElement> sender, IVectorChangedEventArgs pArgs)
	{
		ResetDynamicCommands();
		bool isOpen = base.IsOpen;
		bool flag = !isOpen;
		CollectionChange collectionChange = pArgs.CollectionChange;
		uint index = pArgs.Index;
		switch (collectionChange)
		{
		case CollectionChange.ItemInserted:
		case CollectionChange.ItemChanged:
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicPrimaryCommands?[(int)index];
			if (commandBarElement2 != null)
			{
				commandBarElement2.IsCompact = flag;
				PropagateDefaultLabelPositionToElement(commandBarElement2);
			}
			break;
		}
		case CollectionChange.Reset:
		{
			SetCompactMode(flag);
			int num = m_tpDynamicPrimaryCommands?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[i];
				if (commandBarElement != null)
				{
					PropagateDefaultLabelPositionToElement(commandBarElement);
				}
			}
			break;
		}
		}
		InvalidateMeasure();
		UpdateVisualState();
	}

	private void OnSecondaryCommandsChanged(IObservableVector<ICommandBarElement> sender, IVectorChangedEventArgs pArgs)
	{
		ResetDynamicCommands();
		CollectionChange collectionChange = pArgs.CollectionChange;
		uint index = pArgs.Index;
		SetOverflowStyleParams();
		switch (collectionChange)
		{
		case CollectionChange.ItemInserted:
		case CollectionChange.ItemChanged:
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicSecondaryCommands?[(int)index];
			if (commandBarElement2 != null)
			{
				PropagateDefaultLabelPositionToElement(commandBarElement2);
				SetOverflowStyleAndInputModeOnSecondaryCommand((int)index, isItemInOverflow: true);
				PropagateDefaultLabelPositionToElement(commandBarElement2);
			}
			break;
		}
		case CollectionChange.Reset:
		{
			int num = m_tpDynamicSecondaryCommands?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[i];
				if (commandBarElement != null)
				{
					SetOverflowStyleAndInputModeOnSecondaryCommand(i, isItemInOverflow: true);
					PropagateDefaultLabelPositionToElement(commandBarElement);
				}
			}
			break;
		}
		}
		InvalidateMeasure();
		UpdateVisualState();
		UpdateTemplateSettings();
	}

	private void OnSecondaryItemsControlLoaded(object sender, RoutedEventArgs e)
	{
		if (m_tpOverflowPresenterItemsPresenter == null)
		{
			m_tpOverflowPresenterItemsPresenter = m_tpSecondaryItemsControlPart?.GetTemplateChild<ItemsPresenter>("ItemsPresenter");
			if (m_tpOverflowPresenterItemsPresenter != null)
			{
				m_tpOverflowPresenterItemsPresenter!.KeyDown += OnOverflowContentKeyDown;
				m_overflowPresenterItemsPresenterKeyDownEventHandler.Disposable = Disposable.Create(delegate
				{
					m_tpOverflowPresenterItemsPresenter!.KeyDown -= OnOverflowContentKeyDown;
				});
			}
		}
		if (m_overflowInitialFocusItem != 0)
		{
			SetFocusedElementInOverflow(m_overflowInitialFocusItem == OverflowInitialFocusItem.FirstItem, out var _);
			m_overflowInitialFocusItem = OverflowInitialFocusItem.None;
		}
	}

	private void OnOverflowContentRootSizeChanged(object sender, SizeChangedEventArgs args)
	{
		if (m_tpSecondaryItemsControlPart is CommandBarOverflowPresenter commandBarOverflowPresenter)
		{
			bool shouldOverflowOpenInFullWidth = GetShouldOverflowOpenInFullWidth();
			bool shouldOpenUp = GetShouldOpenUp();
			commandBarOverflowPresenter.SetDisplayModeState(shouldOverflowOpenInFullWidth, shouldOpenUp);
		}
		UpdateTemplateSettings();
	}

	private void TryDismissCommandBarOverflow()
	{
		if (!base.IsSticky)
		{
			base.IsOpen = false;
		}
		RestoreFocusToExpandButton();
	}

	private void OnOverflowContentKeyDown(object sender, KeyRoutedEventArgs e)
	{
		VirtualKey virtualKey = VirtualKey.None;
		VirtualKey virtualKey2 = VirtualKey.None;
		virtualKey = e.Key;
		virtualKey2 = e.OriginalKey;
		bool wasHandled = false;
		switch (virtualKey2)
		{
		case VirtualKey.Escape:
		case VirtualKey.GamepadB:
			TryDismissCommandBarOverflow();
			wasHandled = true;
			break;
		case VirtualKey.Left:
		case VirtualKey.Right:
		case VirtualKey.GamepadDPadLeft:
		case VirtualKey.GamepadDPadRight:
		case VirtualKey.GamepadLeftThumbstickRight:
		case VirtualKey.GamepadLeftThumbstickLeft:
			wasHandled = true;
			break;
		case VirtualKey.GamepadDPadUp:
		case VirtualKey.GamepadDPadDown:
		case VirtualKey.GamepadLeftThumbstickUp:
		case VirtualKey.GamepadLeftThumbstickDown:
			ShiftFocusVerticallyInOverflow(virtualKey == VirtualKey.Down || virtualKey == VirtualKey.GamepadDPadDown || virtualKey == VirtualKey.GamepadLeftThumbstickDown, allowFocusWrap: false);
			wasHandled = true;
			break;
		case VirtualKey.Up:
		case VirtualKey.Down:
			ShiftFocusVerticallyInOverflow(virtualKey == VirtualKey.Down);
			wasHandled = true;
			break;
		case VirtualKey.Tab:
		{
			GetKeyboardModifiers(out var virtualKeyModifiers);
			HandleTabKeyPressedInOverflow((virtualKeyModifiers & VirtualKeyModifiers.Shift) != 0, out wasHandled);
			break;
		}
		}
		if (wasHandled)
		{
			e.Handled = true;
		}
	}

	internal static void OnCommandExecutionStatic(ICommandBarElement element)
	{
		FindParentCommandBarForElement(element, out var parentCmdBar);
		if (parentCmdBar != null)
		{
			parentCmdBar.IsOpen = false;
		}
	}

	internal static void OnCommandBarElementVisibilityChanged(ICommandBarElement element)
	{
		FindParentCommandBarForElement(element, out var parentCmdBar);
		parentCmdBar?.UpdateVisualState();
	}

	protected override bool ContainsElement(DependencyObject pElement)
	{
		bool flag = false;
		flag = this.IsAncestorOf(pElement);
		if (!flag && m_tpOverflowContentRoot != null)
		{
			flag = m_tpOverflowContentRoot.IsAncestorOf(pElement);
		}
		return flag;
	}

	private void RestoreFocusToExpandButton()
	{
		if (m_tpExpandButton == null)
		{
			return;
		}
		DependencyObject focusedElement = this.GetFocusedElement();
		if (focusedElement != null)
		{
			bool flag = false;
			if (m_tpOverflowContentRoot != null)
			{
				flag = m_tpOverflowContentRoot.IsAncestorOf(focusedElement);
			}
			if (flag)
			{
				FocusState focusState = GetFocusState(focusedElement);
				this.SetFocusedElement(m_tpExpandButton, focusState, animateIfBringIntoView: false);
			}
		}
	}

	protected override void RestoreSavedFocusImpl(DependencyObject? savedFocusedElement, FocusState savedFocusState)
	{
		if (savedFocusedElement != null)
		{
			base.RestoreSavedFocusImpl(savedFocusedElement, savedFocusState);
		}
		else
		{
			RestoreFocusToExpandButton();
		}
	}

	protected override void UpdateTemplateSettings()
	{
		CommandBarTemplateSettings commandBarTemplateSettings = CommandBarTemplateSettings;
		AppBarTemplateSettings templateSettings = base.TemplateSettings;
		if (base.IsOpen)
		{
			double num = (commandBarTemplateSettings.ContentHeight = base.ContentHeight);
			Rect rect = default(Rect);
			Rect rect2 = default(Rect);
			rect = Window.Current.Bounds;
			if (0 == 0)
			{
				rect2 = rect;
			}
			bool flag = false;
			flag = GetShouldOverflowOpenInFullWidth();
			double overflowContentMaxWidth = m_overflowContentMaxWidth;
			double overflowContentMinWidth;
			if (flag)
			{
				overflowContentMinWidth = rect.Width;
				overflowContentMaxWidth = rect.Width;
			}
			else
			{
				overflowContentMinWidth = m_overflowContentMinWidth;
			}
			commandBarTemplateSettings.OverflowContentMinWidth = overflowContentMinWidth;
			commandBarTemplateSettings.OverflowContentMaxWidth = overflowContentMaxWidth;
			double num2 = rect2.Height * 0.5;
			if (m_tpWindowedPopupPadding != null)
			{
				double actualHeight = m_tpWindowedPopupPadding!.ActualHeight;
				num2 += actualHeight;
			}
			commandBarTemplateSettings.OverflowContentMaxHeight = num2;
			Size overflowContentSize = GetOverflowContentSize();
			commandBarTemplateSettings.OverflowContentClipRect = new Rect(0.0, 0.0, overflowContentSize.Width, overflowContentSize.Height - ((m_tpWindowedPopupPadding != null) ? num : 0.0));
			double compactVerticalDelta = templateSettings.CompactVerticalDelta;
			double minimalVerticalDelta = templateSettings.MinimalVerticalDelta;
			double hiddenVerticalDelta = templateSettings.HiddenVerticalDelta;
			commandBarTemplateSettings.OverflowContentCompactYTranslation = 0.0 - overflowContentSize.Height + compactVerticalDelta;
			commandBarTemplateSettings.OverflowContentMinimalYTranslation = 0.0 - overflowContentSize.Height + minimalVerticalDelta;
			commandBarTemplateSettings.OverflowContentHiddenYTranslation = 0.0 - overflowContentSize.Height + hiddenVerticalDelta;
			double num3 = (commandBarTemplateSettings.OverflowContentHeight = overflowContentSize.Height);
			commandBarTemplateSettings.NegativeOverflowContentHeight = 0.0 - num3;
			double num4 = 0.0;
			num4 = (commandBarTemplateSettings.OverflowContentHorizontalOffset = CalculateOverflowContentHorizontalOffset(overflowContentSize, rect2));
		}
		base.UpdateTemplateSettings();
		CommandBarOverflowButtonVisibility overflowButtonVisibility = OverflowButtonVisibility;
		bool flag2 = false;
		switch (overflowButtonVisibility)
		{
		case CommandBarOverflowButtonVisibility.Visible:
			flag2 = true;
			break;
		case CommandBarOverflowButtonVisibility.Auto:
		{
			int num6 = 0;
			num6 = m_tpDynamicSecondaryCommands?.Count ?? 0;
			if (num6 > 0)
			{
				flag2 = true;
				break;
			}
			if (base.ClosedDisplayMode != 0)
			{
				flag2 = true;
				break;
			}
			double compactVerticalDelta2 = templateSettings.CompactVerticalDelta;
			flag2 = !compactVerticalDelta2.IsZero();
			break;
		}
		}
		commandBarTemplateSettings.EffectiveOverflowButtonVisibility = ((!flag2) ? Visibility.Collapsed : Visibility.Visible);
		double num7 = 0.0;
		int num8 = m_tpDynamicSecondaryCommands?.Count ?? 0;
		for (int i = 0; i < num8; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[i];
			if (commandBarElement != null)
			{
				Size size = default(Size);
				double num9 = 0.0;
				if (commandBarElement is AppBarButton appBarButton)
				{
					size = appBarButton.GetKeyboardAcceleratorTextDesiredSize();
				}
				else if (commandBarElement is AppBarToggleButton appBarToggleButton)
				{
					size = appBarToggleButton.GetKeyboardAcceleratorTextDesiredSize();
				}
				num9 = size.Width;
				if (num9 > num7)
				{
					num7 = num9;
				}
			}
		}
		for (int j = 0; j < num8; j++)
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicSecondaryCommands?[j];
			if (commandBarElement2 != null)
			{
				if (commandBarElement2 is AppBarButton appBarButton2)
				{
					appBarButton2.UpdateTemplateSettings(num7);
				}
				else if (commandBarElement2 is AppBarToggleButton appBarToggleButton2)
				{
					appBarToggleButton2.UpdateTemplateSettings(num7);
				}
			}
		}
	}

	private bool GetShouldOverflowOpenInFullWidth()
	{
		return Window.Current.Bounds.Width <= m_overflowContentMaxWidth;
	}

	protected override void GetVerticalOffsetNeededToOpenUp(out double neededOffset, out bool opensWindowed)
	{
		base.GetVerticalOffsetNeededToOpenUp(out neededOffset, out opensWindowed);
		CommandBarTemplateSettings commandBarTemplateSettings = CommandBarTemplateSettings;
		double overflowContentHeight = commandBarTemplateSettings.OverflowContentHeight;
		neededOffset += overflowContentHeight;
	}

	private Size GetOverflowContentSize()
	{
		Size result = new Size(0.0, 0.0);
		if (m_tpOverflowContentRoot != null && HasVisibleElements(m_tpDynamicSecondaryCommands))
		{
			m_tpOverflowContentRoot!.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			return m_tpOverflowContentRoot!.DesiredSize;
		}
		return result;
	}

	private double CalculateOverflowContentHorizontalOffset(Size overflowContentSize, Rect visibleBounds)
	{
		double num = 0.0;
		GeneralTransform generalTransform = TransformToVisual(null);
		Point point = generalTransform.TransformPoint(new Point(0.0, 0.0));
		double actualWidth = base.ActualWidth;
		num = actualWidth - overflowContentSize.Width;
		if (num < 0.0)
		{
			FlowDirection flowDirection = base.FlowDirection;
			if ((flowDirection == FlowDirection.LeftToRight && point.X + num < 0.0) || (flowDirection == FlowDirection.RightToLeft && point.X - num > visibleBounds.Width))
			{
				num = (((flowDirection != 0 || !(point.X + overflowContentSize.Width <= visibleBounds.Width)) && (flowDirection != FlowDirection.RightToLeft || !(point.X - overflowContentSize.Width >= 0.0))) ? ((flowDirection == FlowDirection.LeftToRight) ? (0.0 - point.X) : (point.X - visibleBounds.Width)) : 0.0);
			}
		}
		return num;
	}

	private static bool HasVisibleElements(ObservableCollection<ICommandBarElement>? collection)
	{
		bool result = false;
		int num = collection?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = collection?[i];
			if (commandBarElement != null && commandBarElement is UIElement uIElement && uIElement.Visibility == Visibility.Visible)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static void FindParentCommandBarForElement(ICommandBarElement element, out CommandBar? parentCmdBar)
	{
		parentCmdBar = null;
		DependencyObject dependencyObject = element as DependencyObject;
		CommandBar commandBar = null;
		ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(dependencyObject);
		if (itemsControl != null)
		{
			DependencyObject templatedParent = itemsControl.TemplatedParent;
			commandBar = templatedParent as CommandBar;
		}
		if (commandBar == null)
		{
			for (DependencyObject dependencyObject2 = dependencyObject; dependencyObject2 != null; dependencyObject2 = dependencyObject2.GetParent() as DependencyObject)
			{
				if (dependencyObject2 is CommandBar commandBar2)
				{
					commandBar = commandBar2;
				}
			}
		}
		parentCmdBar = commandBar;
	}

	private void FindMovablePrimaryCommands(double availablePrimaryCommandsWidth, double primaryItemsControlDesiredWidth, out int primaryCommandsCountInTransition)
	{
		bool canProcessDynamicOverflowOrder = false;
		FindMovablePrimaryCommandsFromOrderSet(availablePrimaryCommandsWidth, primaryItemsControlDesiredWidth, out primaryCommandsCountInTransition, ref canProcessDynamicOverflowOrder);
		if (canProcessDynamicOverflowOrder)
		{
			return;
		}
		int num = m_tpDynamicPrimaryCommands?.Count ?? 0;
		int num2 = num - 1;
		primaryCommandsCountInTransition = 0;
		for (int num3 = num2; num3 > 0; num3--)
		{
			ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[num3];
			Size size = default(Size);
			if (commandBarElement is UIElement uIElement)
			{
				size = uIElement.DesiredSize;
			}
			primaryItemsControlDesiredWidth -= size.Width;
			if (primaryItemsControlDesiredWidth < availablePrimaryCommandsWidth)
			{
				break;
			}
			num2--;
		}
		m_tpPrimaryCommandsInTransition?.Clear();
		for (int i = num2; i < num; i++)
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicPrimaryCommands?[i];
			if (commandBarElement2 != null)
			{
				m_tpPrimaryCommandsInTransition?.Insert(primaryCommandsCountInTransition++, commandBarElement2);
			}
		}
	}

	private void FindMovablePrimaryCommandsFromOrderSet(double availablePrimaryCommandsWidth, double primaryItemsControlDesiredWidth, out int primaryCommandsCountInTransition, ref bool canProcessDynamicOverflowOrder)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		primaryCommandsCountInTransition = 0;
		canProcessDynamicOverflowOrder = false;
		do
		{
			bool flag2 = false;
			flag = false;
			num = m_tpDynamicPrimaryCommands?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[i];
				if (!(commandBarElement is ICommandBarElement2 commandBarElement2))
				{
					continue;
				}
				num2 = commandBarElement2.DynamicOverflowOrder;
				if (num2 > 0 && num2 > num4)
				{
					if (!flag2)
					{
						num3 = num2;
						flag2 = true;
					}
					else
					{
						num3 = Math.Min(num2, num3);
					}
					flag = true;
				}
			}
			if (flag && num3 > num4)
			{
				if (!canProcessDynamicOverflowOrder)
				{
					canProcessDynamicOverflowOrder = true;
					m_tpPrimaryCommandsInTransition?.Clear();
				}
				for (int j = 0; j < num; j++)
				{
					ICommandBarElement commandBarElement3 = m_tpDynamicPrimaryCommands?[j];
					if (!(commandBarElement3 is ICommandBarElement2 commandBarElement4))
					{
						continue;
					}
					num2 = commandBarElement4.DynamicOverflowOrder;
					if (num2 > 0 && num2 == num3)
					{
						InsertPrimaryCommandToPrimaryCommandsInTransition(j, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
						if (j > 0)
						{
							FindMovableSeparatorsInBackwardDirection(j, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
						}
						if (j < num - 1)
						{
							FindMovableSeparatorsInForwardDirection(j, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
						}
						if (primaryItemsControlDesiredWidth < availablePrimaryCommandsWidth)
						{
							flag = false;
						}
					}
				}
			}
			num4 = num3;
		}
		while (flag);
		if (!canProcessDynamicOverflowOrder || !(primaryItemsControlDesiredWidth > availablePrimaryCommandsWidth))
		{
			return;
		}
		for (int num5 = num; num5 > 0; num5--)
		{
			ICommandBarElement commandBarElement5 = m_tpDynamicPrimaryCommands?[num5 - 1];
			if (commandBarElement5 is ICommandBarElement2 commandBarElement6 && commandBarElement6.DynamicOverflowOrder == 0)
			{
				InsertPrimaryCommandToPrimaryCommandsInTransition(num5 - 1, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
				if (primaryItemsControlDesiredWidth < availablePrimaryCommandsWidth)
				{
					break;
				}
			}
		}
	}

	private void InsertPrimaryCommandToPrimaryCommandsInTransition(int indexMovingPrimaryCommand, ref int primaryCommandsCountInTransition, ref double primaryItemsControlDesiredWidth)
	{
		ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[indexMovingPrimaryCommand];
		if (commandBarElement != null)
		{
			m_tpPrimaryCommandsInTransition?.Insert(primaryCommandsCountInTransition++, commandBarElement);
			if (commandBarElement is UIElement uIElement)
			{
				primaryItemsControlDesiredWidth -= uIElement.DesiredSize.Width;
			}
		}
	}

	private void UpdatePrimaryCommandElementMinWidthInOverflow()
	{
		Size size = default(Size);
		int num = 0;
		num = m_tpPrimaryCommandsInTransition?.Count ?? 0;
		m_restorablePrimaryCommandMinWidth = -1.0;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = m_tpPrimaryCommandsInTransition?[i];
			if (commandBarElement == null)
			{
				continue;
			}
			AppBarSeparator appBarSeparator = commandBarElement as AppBarSeparator;
			if (appBarSeparator == null)
			{
				size = ((commandBarElement is UIElement uIElement) ? uIElement.DesiredSize : default(Size));
				if (m_restorablePrimaryCommandMinWidth == -1.0)
				{
					m_restorablePrimaryCommandMinWidth = size.Width;
				}
				else
				{
					m_restorablePrimaryCommandMinWidth = Math.Min(m_restorablePrimaryCommandMinWidth, size.Width);
				}
			}
		}
	}

	private void MoveTransitionPrimaryCommandsIntoOverflow(int primaryCommandsCountInTransition)
	{
		bool flag = false;
		int num = 0;
		if (m_SecondaryCommandStartIndex == 0)
		{
			bool flag2 = false;
			if (HasVisibleElements(m_tpDynamicSecondaryCommands) && m_tpAppBarSeparatorInOverflow != null)
			{
				SetOverflowStyleUsage(m_tpAppBarSeparatorInOverflow, isItemInOverflow: true);
				m_tpDynamicSecondaryCommands?.Insert(m_SecondaryCommandStartIndex, m_tpAppBarSeparatorInOverflow);
				m_SecondaryCommandStartIndex++;
				m_hasAppBarSeparatorInOverflow = true;
			}
		}
		for (int i = 0; i < primaryCommandsCountInTransition; i++)
		{
			ICommandBarElement commandBarElement = m_tpPrimaryCommandsInTransition?[0];
			m_tpPrimaryCommandsInTransition?.RemoveAt(0);
			num = ((commandBarElement == null) ? (-1) : (m_tpDynamicPrimaryCommands?.IndexOf(commandBarElement) ?? (-1)));
			if (num != -1)
			{
				m_tpDynamicPrimaryCommands?.RemoveAt(num);
				InsertTransitionPrimaryCommandIntoOverflow(commandBarElement);
			}
		}
	}

	private void InsertTransitionPrimaryCommandIntoOverflow(ICommandBarElement? transitionPrimaryElement)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		bool flag = false;
		bool flag2 = false;
		if (transitionPrimaryElement == null)
		{
			return;
		}
		num3 = ((!m_hasAppBarSeparatorInOverflow) ? m_SecondaryCommandStartIndex : (m_SecondaryCommandStartIndex - 1));
		num = m_tpPrimaryCommands?.IndexOf(transitionPrimaryElement) ?? (-1);
		flag = num != -1;
		for (int i = 0; i < num3; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[i];
			if (commandBarElement != null)
			{
				num2 = m_tpPrimaryCommands?.IndexOf(commandBarElement) ?? (-1);
				flag = num2 != -1;
			}
			if (num < num2)
			{
				SetOverflowStyleUsage(transitionPrimaryElement, isItemInOverflow: true);
				m_tpDynamicSecondaryCommands?.Insert(i, transitionPrimaryElement);
				m_SecondaryCommandStartIndex++;
				flag2 = true;
				break;
			}
		}
		if (!flag2)
		{
			SetOverflowStyleUsage(transitionPrimaryElement, isItemInOverflow: true);
			m_tpDynamicSecondaryCommands?.Insert(num3, transitionPrimaryElement);
			m_SecondaryCommandStartIndex++;
		}
	}

	private void ResetDynamicCommands()
	{
		int num = 0;
		int num2 = 0;
		StoreFocusedCommandBarElement();
		num = m_tpPrimaryCommands?.Count ?? 0;
		num2 = m_tpSecondaryCommands?.Count ?? 0;
		for (int i = 0; i < m_SecondaryCommandStartIndex; i++)
		{
			SetOverflowStyleAndInputModeOnSecondaryCommand(i, isItemInOverflow: false);
		}
		for (int j = 0; j < m_SecondaryCommandStartIndex; j++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[0];
			if (commandBarElement != null)
			{
				m_tpDynamicSecondaryCommands?.RemoveAt(0);
				m_tpDynamicPrimaryCommands?.Insert(0, commandBarElement);
			}
		}
		m_SecondaryCommandStartIndex = 0;
		m_hasAppBarSeparatorInOverflow = false;
		m_tpDynamicPrimaryCommands?.Clear();
		for (int k = 0; k < num; k++)
		{
			ICommandBarElement commandBarElement2 = m_tpPrimaryCommands?[k];
			if (commandBarElement2 != null)
			{
				m_tpDynamicPrimaryCommands?.Insert(k, commandBarElement2);
			}
		}
		m_tpDynamicSecondaryCommands?.Clear();
		for (int l = 0; l < num2; l++)
		{
			ICommandBarElement commandBarElement3 = m_tpSecondaryCommands?[l];
			if (commandBarElement3 != null)
			{
				SetOverflowStyleUsage(commandBarElement3, isItemInOverflow: true);
				m_tpDynamicSecondaryCommands?.Insert(l, commandBarElement3);
			}
		}
		UpdateTemplateSettings();
	}

	private void SaveMovedPrimaryCommandsIntoPreviousTransitionCollection()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		num = m_tpDynamicSecondaryCommands?.Count ?? 0;
		num2 = m_tpSecondaryCommands?.Count ?? 0;
		num3 = num - num2;
		m_tpPrimaryCommandsInPreviousTransition?.Clear();
		for (int i = 0; i < num3; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[i];
			if (commandBarElement != null)
			{
				m_tpPrimaryCommandsInPreviousTransition?.Insert(i, commandBarElement);
			}
		}
	}

	private void FireDynamicOverflowItemsChangingEvent(bool isForceToRestore)
	{
		DynamicOverflowItemsChangingEventArgs dynamicOverflowItemsChangingEventArgs = new DynamicOverflowItemsChangingEventArgs();
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (!isForceToRestore)
		{
			num = m_tpPrimaryCommandsInPreviousTransition?.Count ?? 0;
			num2 = m_tpPrimaryCommandsInTransition?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				ICommandBarElement commandBarElement = m_tpPrimaryCommandsInPreviousTransition?[i];
				for (int j = 0; j < num2; j++)
				{
					ICommandBarElement commandBarElement2 = m_tpPrimaryCommandsInTransition?[j];
					if (commandBarElement2 != null && commandBarElement2 == commandBarElement)
					{
						num3++;
					}
				}
			}
			flag = num2 - num3 > 0;
		}
		dynamicOverflowItemsChangingEventArgs.Action = ((!flag) ? CommandBarDynamicOverflowAction.RemovingFromOverflow : CommandBarDynamicOverflowAction.AddingToOverflow);
		this.DynamicOverflowItemsChanging?.Invoke(this, dynamicOverflowItemsChangingEventArgs);
	}

	internal static bool IsCommandBarElementInOverflow(ICommandBarElement element)
	{
		FindParentCommandBarForElement(element, out var parentCmdBar);
		bool result = false;
		if (parentCmdBar != null)
		{
			result = parentCmdBar.IsElementInOverflow(element);
		}
		return result;
	}

	private bool IsElementInOverflow(ICommandBarElement element)
	{
		int num = 0;
		bool result = false;
		num = m_tpDynamicSecondaryCommands?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[i];
			if (commandBarElement != null && commandBarElement == element)
			{
				result = true;
			}
		}
		return result;
	}

	internal static int GetPositionInSetStatic(ICommandBarElement element)
	{
		int result = -1;
		FindParentCommandBarForElement(element, out var parentCmdBar);
		if (parentCmdBar != null)
		{
			result = parentCmdBar.GetPositionInSet(element);
		}
		return result;
	}

	private int GetPositionInSet(ICommandBarElement element)
	{
		int result = -1;
		int num = m_tpDynamicPrimaryCommands?.Count ?? 0;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[i];
			UIElement uIElement = commandBarElement as UIElement;
			Visibility visibility = Visibility.Collapsed;
			if (uIElement != null)
			{
				visibility = uIElement.Visibility;
			}
			if (visibility == Visibility.Visible)
			{
				AppBarButton appBarButton = commandBarElement as AppBarButton;
				AppBarToggleButton appBarToggleButton = commandBarElement as AppBarToggleButton;
				if (appBarButton != null || appBarToggleButton != null)
				{
					num2++;
				}
				if (commandBarElement == element)
				{
					result = num2;
				}
			}
		}
		num = 0;
		num = m_tpDynamicSecondaryCommands?.Count ?? 0;
		num2 = 0;
		for (int j = 0; j < num; j++)
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicSecondaryCommands?[j];
			UIElement uIElement2 = commandBarElement2 as UIElement;
			Visibility visibility2 = Visibility.Collapsed;
			if (uIElement2 != null)
			{
				visibility2 = uIElement2.Visibility;
			}
			if (visibility2 == Visibility.Visible)
			{
				AppBarButton appBarButton2 = commandBarElement2 as AppBarButton;
				AppBarToggleButton appBarToggleButton2 = commandBarElement2 as AppBarToggleButton;
				if (appBarButton2 != null || appBarToggleButton2 != null)
				{
					num2++;
				}
				if (commandBarElement2 == element)
				{
					result = num2;
				}
			}
		}
		return result;
	}

	internal static int GetSizeOfSetStatic(ICommandBarElement element)
	{
		int result = -1;
		FindParentCommandBarForElement(element, out var parentCmdBar);
		if (parentCmdBar != null)
		{
			result = parentCmdBar.GetSizeOfSet(element);
		}
		return result;
	}

	private int GetSizeOfSet(ICommandBarElement element)
	{
		int result = -1;
		int num = m_tpDynamicPrimaryCommands?.Count ?? 0;
		bool flag = false;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[i];
			UIElement uIElement = commandBarElement as UIElement;
			Visibility visibility = Visibility.Collapsed;
			if (uIElement != null)
			{
				visibility = uIElement.Visibility;
			}
			if (visibility == Visibility.Visible)
			{
				AppBarButton appBarButton = commandBarElement as AppBarButton;
				AppBarToggleButton appBarToggleButton = commandBarElement as AppBarToggleButton;
				if (appBarButton != null || appBarToggleButton != null)
				{
					num2++;
				}
				if (commandBarElement == element)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			result = num2;
		}
		num = 0;
		num = m_tpDynamicSecondaryCommands?.Count ?? 0;
		num2 = 0;
		for (int j = 0; j < num; j++)
		{
			ICommandBarElement commandBarElement2 = m_tpDynamicSecondaryCommands?[j];
			UIElement uIElement2 = commandBarElement2 as UIElement;
			Visibility visibility2 = Visibility.Collapsed;
			if (uIElement2 != null)
			{
				visibility2 = uIElement2.Visibility;
			}
			if (visibility2 == Visibility.Visible)
			{
				AppBarButton appBarButton2 = commandBarElement2 as AppBarButton;
				AppBarToggleButton appBarToggleButton2 = commandBarElement2 as AppBarToggleButton;
				if (appBarButton2 != null || appBarToggleButton2 != null)
				{
					num2++;
				}
				if (commandBarElement2 == element)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			result = num2;
		}
		return result;
	}

	private void TrimPrimaryCommandSeparatorInOverflow(ref int primaryCommandsCountInTransition)
	{
		for (int num = primaryCommandsCountInTransition; num > 0; num--)
		{
			ICommandBarElement commandBarElement = m_tpPrimaryCommandsInTransition?[num - 1];
			if (commandBarElement is AppBarSeparator item)
			{
				bool flag = false;
				int num2 = m_tpDynamicPrimaryCommands?.IndexOf(item) ?? (-1);
				if (num2 != -1)
				{
					m_tpDynamicPrimaryCommands?.RemoveAt(num2);
				}
				m_tpPrimaryCommandsInTransition?.RemoveAt(num - 1);
				primaryCommandsCountInTransition--;
			}
		}
	}

	private bool IsAppBarSeparatorInDynamicPrimaryCommands(int index)
	{
		bool result = false;
		ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[index];
		if (commandBarElement != null && commandBarElement is AppBarSeparator)
		{
			result = true;
		}
		return result;
	}

	private void FindMovableSeparatorsInBackwardDirection(int movingPrimaryCommandIndex, ref int primaryCommandsCountInTransition, ref double primaryItemsControlDesiredWidth)
	{
		if (movingPrimaryCommandIndex <= 0)
		{
			return;
		}
		bool flag = false;
		if (!IsAppBarSeparatorInDynamicPrimaryCommands(movingPrimaryCommandIndex - 1))
		{
			return;
		}
		bool hasNonSeparator = false;
		int indexNonSeparator = 0;
		int num = movingPrimaryCommandIndex - 1;
		FindNonSeparatorInDynamicPrimaryCommands(isForward: false, num, out hasNonSeparator, out indexNonSeparator);
		if (!hasNonSeparator)
		{
			while (num >= 0)
			{
				InsertSeparatorToPrimaryCommandsInTransition(num, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
				num--;
			}
		}
		else
		{
			while (num > indexNonSeparator && num - indexNonSeparator > 1)
			{
				InsertSeparatorToPrimaryCommandsInTransition(num, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
				num--;
			}
		}
	}

	private void FindMovableSeparatorsInForwardDirection(int movingPrimaryCommandIndex, ref int primaryCommandsCountInTransition, ref double primaryItemsControlDesiredWidth)
	{
		bool flag = false;
		if (!IsAppBarSeparatorInDynamicPrimaryCommands(movingPrimaryCommandIndex + 1))
		{
			return;
		}
		bool hasNonSeparator = false;
		int num = 0;
		int indexNonSeparator = 0;
		int i = movingPrimaryCommandIndex + 1;
		FindNonSeparatorInDynamicPrimaryCommands(isForward: true, i, out hasNonSeparator, out indexNonSeparator);
		num = m_tpDynamicPrimaryCommands?.Count ?? 0;
		if (!hasNonSeparator)
		{
			for (; i < num; i++)
			{
				InsertSeparatorToPrimaryCommandsInTransition(i, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
			}
		}
		else
		{
			for (; i < indexNonSeparator && indexNonSeparator - i > 1; i++)
			{
				InsertSeparatorToPrimaryCommandsInTransition(i, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
			}
		}
		if (movingPrimaryCommandIndex == 0)
		{
			InsertSeparatorToPrimaryCommandsInTransition(movingPrimaryCommandIndex + 1, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
		}
		if (movingPrimaryCommandIndex > 0 && IsAppBarSeparatorInDynamicPrimaryCommands(movingPrimaryCommandIndex - 1))
		{
			InsertSeparatorToPrimaryCommandsInTransition(movingPrimaryCommandIndex + 1, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
			if (!hasNonSeparator)
			{
				InsertSeparatorToPrimaryCommandsInTransition(movingPrimaryCommandIndex - 1, ref primaryCommandsCountInTransition, ref primaryItemsControlDesiredWidth);
			}
		}
	}

	private void FindNonSeparatorInDynamicPrimaryCommands(bool isForward, int indexMoving, out bool hasNonSeparator, out int indexNonSeparator)
	{
		int num = 0;
		hasNonSeparator = false;
		indexNonSeparator = 0;
		num = m_tpDynamicPrimaryCommands?.Count ?? 0;
		while (isForward ? (indexMoving < num) : (indexMoving >= 0))
		{
			ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[indexMoving];
			if (!(commandBarElement is AppBarSeparator))
			{
				hasNonSeparator = true;
				indexNonSeparator = indexMoving;
				break;
			}
			indexMoving = ((!isForward) ? (indexMoving - 1) : (indexMoving + 1));
		}
	}

	private void InsertSeparatorToPrimaryCommandsInTransition(int indexMovingSeparator, ref int primaryCommandsCountInTransition, ref double primaryItemsControlDesiredWidth)
	{
		ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands?[indexMovingSeparator];
		if (commandBarElement is AppBarSeparator item)
		{
			bool flag = false;
			int num = 0;
			num = m_tpPrimaryCommandsInTransition?.IndexOf(item) ?? (-1);
			if (num == -1)
			{
				UIElement uIElement = null;
				m_tpPrimaryCommandsInTransition?.Insert(primaryCommandsCountInTransition++, item);
				primaryItemsControlDesiredWidth -= ((commandBarElement is UIElement uIElement2) ? uIElement2.DesiredSize : default(Size)).Width;
			}
		}
	}

	private int GetRestorablePrimaryCommandsMinimumCount()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (m_SecondaryCommandStartIndex > 1)
		{
			for (int i = 0; i < m_SecondaryCommandStartIndex - 1; i++)
			{
				ICommandBarElement commandBarElement = m_tpDynamicSecondaryCommands?[i];
				if (commandBarElement is ICommandBarElement2 commandBarElement2)
				{
					num = commandBarElement2.DynamicOverflowOrder;
					if (num > 0)
					{
						num2 = Math.Max(num, num2);
					}
				}
			}
			if (num2 > 0)
			{
				for (int j = 0; j < m_SecondaryCommandStartIndex - 1; j++)
				{
					ICommandBarElement commandBarElement3 = m_tpDynamicSecondaryCommands?[j];
					if (commandBarElement3 is ICommandBarElement2 commandBarElement4)
					{
						num = commandBarElement4.DynamicOverflowOrder;
						if (num > 0 && num == num2)
						{
							num3++;
						}
					}
				}
			}
			else
			{
				num3 = 1;
			}
		}
		return num3;
	}

	private void StoreFocusedCommandBarElement()
	{
		DependencyObject focusedElement = this.GetFocusedElement();
		if (focusedElement != null)
		{
			ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(focusedElement);
			if (itemsControl != null && (itemsControl == m_tpPrimaryItemsControlPart || itemsControl == m_tpSecondaryItemsControlPart))
			{
				object obj = itemsControl.ItemFromContainer(focusedElement);
				ICommandBarElement commandBarElement = (m_focusedElementPriorToCollectionOrSizeChange = obj as ICommandBarElement);
				m_focusStatePriorToCollectionOrSizeChange = GetFocusState(focusedElement);
			}
		}
	}

	private void RestoreCommandBarElementFocus()
	{
		ICommandBarElement focusedElementPriorToCollectionOrSizeChange = m_focusedElementPriorToCollectionOrSizeChange;
		if (focusedElementPriorToCollectionOrSizeChange == null)
		{
			return;
		}
		ItemsControl itemsControl = null;
		bool flag = false;
		int num = m_tpDynamicPrimaryCommands?.IndexOf(focusedElementPriorToCollectionOrSizeChange) ?? (-1);
		if (num != -1)
		{
			itemsControl = m_tpPrimaryItemsControlPart;
		}
		else
		{
			num = m_tpDynamicSecondaryCommands?.IndexOf(focusedElementPriorToCollectionOrSizeChange) ?? (-1);
			if (num != -1)
			{
				itemsControl = m_tpSecondaryItemsControlPart;
			}
		}
		if (itemsControl != null)
		{
			DependencyObject dependencyObject = itemsControl.ContainerFromItem(focusedElementPriorToCollectionOrSizeChange);
			if (dependencyObject != null && dependencyObject is UIElement uIElement)
			{
				uIElement.Focus(m_focusStatePriorToCollectionOrSizeChange);
			}
		}
		ResetCommandBarElementFocus();
	}

	private void OnAccessKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
	{
		if (m_tpOverflowPopup != null)
		{
			m_tpOverflowPopup!.Opened += OnOverflowPopupOpened;
			m_overflowPopupOpenedEventHandler.Disposable = Disposable.Create(delegate
			{
				m_tpOverflowPopup!.Opened -= OnOverflowPopupOpened;
			});
		}
	}

	private void OnOverflowPopupOpened(object? sender, object e)
	{
		try
		{
			if (m_tpOverflowPopup == null || m_tpSecondaryItemsControlPart == null)
			{
				return;
			}
			ItemCollection items = m_tpSecondaryItemsControlPart!.Items;
			IEnumerator<object> enumerator = items.GetEnumerator();
			if (enumerator == null)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			for (flag2 = enumerator.Current != null; flag2 && !flag; flag2 = enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (current is Control control)
				{
					flag = control.Focus(FocusState.Keyboard);
				}
			}
		}
		finally
		{
			m_overflowPopupOpenedEventHandler.Disposable = null;
		}
	}

	private void ResetCommandBarElementFocus()
	{
		m_focusedElementPriorToCollectionOrSizeChange = null;
		m_focusStatePriorToCollectionOrSizeChange = FocusState.Unfocused;
	}

	private FocusState GetFocusState(DependencyObject focusedElement)
	{
		FocusState focusState = FocusState.Programmatic;
		Control control = focusedElement as Control;
		if (control != null)
		{
			focusState = control.FocusState;
		}
		if (control == null || focusState == FocusState.Unfocused)
		{
			FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
			if (focusManagerForElement != null)
			{
				focusState = focusManagerForElement.GetRealFocusStateForFocusedElement();
			}
		}
		return focusState;
	}

	internal void CloseSubMenus(ISubMenuOwner? pMenuToLeaveOpen, bool closeOnDelay)
	{
		IObservableVector<ICommandBarElement> primaryCommands = PrimaryCommands;
		IObservableVector<ICommandBarElement> secondaryCommands = SecondaryCommands;
		int num = 0;
		int num2 = 0;
		num = primaryCommands.Count;
		num2 = secondaryCommands.Count;
		for (int i = 0; i < num; i++)
		{
			ICommandBarElement commandBarElement = primaryCommands[i];
			if (commandBarElement is ISubMenuOwner subMenuOwner && (pMenuToLeaveOpen == null || pMenuToLeaveOpen != subMenuOwner))
			{
				if (closeOnDelay)
				{
					subMenuOwner.DelayCloseSubMenu();
				}
				else
				{
					subMenuOwner.CloseSubMenuTree();
				}
			}
		}
		for (int j = 0; j < num2; j++)
		{
			ICommandBarElement commandBarElement2 = secondaryCommands[j];
			if (commandBarElement2 is ISubMenuOwner subMenuOwner2 && (pMenuToLeaveOpen == null || pMenuToLeaveOpen != subMenuOwner2))
			{
				if (closeOnDelay)
				{
					subMenuOwner2.DelayCloseSubMenu();
				}
				else
				{
					subMenuOwner2.CloseSubMenuTree();
				}
			}
		}
	}

	private void SetCompactMode(bool isCompact)
	{
		if (m_tpDynamicPrimaryCommands != null && m_tpDynamicSecondaryCommands != null)
		{
			int count = m_tpDynamicPrimaryCommands!.Count;
			for (int i = 0; i < count; i++)
			{
				ICommandBarElement commandBarElement = m_tpDynamicPrimaryCommands![i];
				commandBarElement.IsCompact = isCompact;
			}
		}
	}

	internal void NotifyElementVectorChanging(CommandBarElementCollection pElementCollection, CollectionChange change, int changeIndex)
	{
		SetOverflowStyleParams();
		switch (change)
		{
		case CollectionChange.ItemRemoved:
		case CollectionChange.ItemChanged:
			SetOverflowStyleAndInputModeOnSecondaryCommand(changeIndex, isItemInOverflow: false);
			break;
		case CollectionChange.Reset:
		{
			int num = 0;
			num = m_tpSecondaryCommands?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				SetOverflowStyleAndInputModeOnSecondaryCommand(i, isItemInOverflow: false);
			}
			break;
		}
		}
	}

	void IMenu.Close()
	{
		base.IsOpen = false;
	}
}

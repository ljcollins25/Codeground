using System.Windows.Input;
using Microsoft.UI.Xaml.Automation.Peers;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Microsoft.UI.Xaml.Controls;

public class PagerControl : Control
{
	private const string c_numberBoxVisibleVisualState = "NumberBoxVisible";

	private const string c_comboBoxVisibleVisualState = "ComboBoxVisible";

	private const string c_numberPanelVisibleVisualState = "NumberPanelVisible";

	private const string c_firstPageButtonVisibleVisualState = "FirstPageButtonVisible";

	private const string c_firstPageButtonNotVisibleVisualState = "FirstPageButtonCollapsed";

	private const string c_firstPageButtonHiddenVisualState = "FirstPageButtonHidden";

	private const string c_firstPageButtonEnabledVisualState = "FirstPageButtonEnabled";

	private const string c_firstPageButtonDisabledVisualState = "FirstPageButtonDisabled";

	private const string c_previousPageButtonVisibleVisualState = "PreviousPageButtonVisible";

	private const string c_previousPageButtonNotVisibleVisualState = "PreviousPageButtonCollapsed";

	private const string c_previousPageButtonHiddenVisualState = "PreviousPageButtonHidden";

	private const string c_previousPageButtonEnabledVisualState = "PreviousPageButtonEnabled";

	private const string c_previousPageButtonDisabledVisualState = "PreviousPageButtonDisabled";

	private const string c_nextPageButtonVisibleVisualState = "NextPageButtonVisible";

	private const string c_nextPageButtonNotVisibleVisualState = "NextPageButtonCollapsed";

	private const string c_nextPageButtonHiddenVisualState = "NextPageButtonHidden";

	private const string c_nextPageButtonEnabledVisualState = "NextPageButtonEnabled";

	private const string c_nextPageButtonDisabledVisualState = "NextPageButtonDisabled";

	private const string c_lastPageButtonVisibleVisualState = "LastPageButtonVisible";

	private const string c_lastPageButtonNotVisibleVisualState = "LastPageButtonCollapsed";

	private const string c_lastPageButtonHiddenVisualState = "LastPageButtonHidden";

	private const string c_lastPageButtonEnabledVisualState = "LastPageButtonEnabled";

	private const string c_lastPageButtonDisabledVisualState = "LastPageButtonDisabled";

	private const string c_finiteItemsModeState = "FiniteItems";

	private const string c_infiniteItemsModeState = "InfiniteItems";

	private const string c_rootGridName = "RootGrid";

	private const string c_comboBoxName = "ComboBoxDisplay";

	private const string c_numberBoxName = "NumberBoxDisplay";

	private const string c_numberPanelRepeaterName = "NumberPanelItemsRepeater";

	private const string c_numberPanelIndicatorName = "NumberPanelCurrentPageIndicator";

	private const string c_firstPageButtonName = "FirstPageButton";

	private const string c_previousPageButtonName = "PreviousPageButton";

	private const string c_nextPageButtonName = "NextPageButton";

	private const string c_lastPageButtonName = "LastPageButton";

	private const string c_numberPanelButtonStyleName = "PagerControlNumberPanelButtonStyle";

	private const int c_AutoDisplayModeNumberOfPagesThreshold = 10;

	private const int c_infiniteModeComboBoxItemsIncrement = 100;

	private int m_lastSelectedPageIndex = -1;

	private int m_lastNumberOfPagesCount;

	private ComboBox m_comboBox;

	private NumberBox m_numberBox;

	private ItemsRepeater m_numberPanelRepeater;

	private FrameworkElement m_selectedPageIndicator;

	private SerialDisposable m_rootGridKeyDownRevoker = new SerialDisposable();

	private SerialDisposable m_comboBoxSelectionChangedRevoker = new SerialDisposable();

	private SerialDisposable m_numberBoxValueChangedRevoker = new SerialDisposable();

	private SerialDisposable m_firstPageButtonClickRevoker = new SerialDisposable();

	private SerialDisposable m_previousPageButtonClickRevoker = new SerialDisposable();

	private SerialDisposable m_nextPageButtonClickRevoker = new SerialDisposable();

	private SerialDisposable m_lastPageButtonClickRevoker = new SerialDisposable();

	private IObservableVector<object> m_comboBoxEntries;

	private IObservableVector<object> m_numberPanelElements;

	public bool ButtonPanelAlwaysShowFirstLastPageIndex
	{
		get
		{
			return (bool)GetValue(ButtonPanelAlwaysShowFirstLastPageIndexProperty);
		}
		set
		{
			SetValue(ButtonPanelAlwaysShowFirstLastPageIndexProperty, value);
		}
	}

	public static DependencyProperty ButtonPanelAlwaysShowFirstLastPageIndexProperty { get; } = DependencyProperty.Register("ButtonPanelAlwaysShowFirstLastPageIndex", typeof(bool), typeof(PagerControl), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public PagerControlDisplayMode DisplayMode
	{
		get
		{
			return (PagerControlDisplayMode)GetValue(DisplayModeProperty);
		}
		set
		{
			SetValue(DisplayModeProperty, value);
		}
	}

	public static DependencyProperty DisplayModeProperty { get; } = DependencyProperty.Register("DisplayMode", typeof(PagerControlDisplayMode), typeof(PagerControl), new FrameworkPropertyMetadata(PagerControlDisplayMode.Auto, OnPropertyChanged));


	public ICommand FirstButtonCommand
	{
		get
		{
			return (ICommand)GetValue(FirstButtonCommandProperty);
		}
		set
		{
			SetValue(FirstButtonCommandProperty, value);
		}
	}

	public static DependencyProperty FirstButtonCommandProperty { get; } = DependencyProperty.Register("FirstButtonCommand", typeof(ICommand), typeof(PagerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public Style FirstButtonStyle
	{
		get
		{
			return (Style)GetValue(FirstButtonStyleProperty);
		}
		set
		{
			SetValue(FirstButtonStyleProperty, value);
		}
	}

	public static DependencyProperty FirstButtonStyleProperty { get; } = DependencyProperty.Register("FirstButtonStyle", typeof(Style), typeof(PagerControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public PagerControlButtonVisibility FirstButtonVisibility
	{
		get
		{
			return (PagerControlButtonVisibility)GetValue(FirstButtonVisibilityProperty);
		}
		set
		{
			SetValue(FirstButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty FirstButtonVisibilityProperty { get; } = DependencyProperty.Register("FirstButtonVisibility", typeof(PagerControlButtonVisibility), typeof(PagerControl), new FrameworkPropertyMetadata(PagerControlButtonVisibility.Visible, OnPropertyChanged));


	public ICommand LastButtonCommand
	{
		get
		{
			return (ICommand)GetValue(LastButtonCommandProperty);
		}
		set
		{
			SetValue(LastButtonCommandProperty, value);
		}
	}

	public static DependencyProperty LastButtonCommandProperty { get; } = DependencyProperty.Register("LastButtonCommand", typeof(ICommand), typeof(PagerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public Style LastButtonStyle
	{
		get
		{
			return (Style)GetValue(LastButtonStyleProperty);
		}
		set
		{
			SetValue(LastButtonStyleProperty, value);
		}
	}

	public static DependencyProperty LastButtonStyleProperty { get; } = DependencyProperty.Register("LastButtonStyle", typeof(Style), typeof(PagerControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public PagerControlButtonVisibility LastButtonVisibility
	{
		get
		{
			return (PagerControlButtonVisibility)GetValue(LastButtonVisibilityProperty);
		}
		set
		{
			SetValue(LastButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty LastButtonVisibilityProperty { get; } = DependencyProperty.Register("LastButtonVisibility", typeof(PagerControlButtonVisibility), typeof(PagerControl), new FrameworkPropertyMetadata(PagerControlButtonVisibility.Visible, OnPropertyChanged));


	public ICommand NextButtonCommand
	{
		get
		{
			return (ICommand)GetValue(NextButtonCommandProperty);
		}
		set
		{
			SetValue(NextButtonCommandProperty, value);
		}
	}

	public static DependencyProperty NextButtonCommandProperty { get; } = DependencyProperty.Register("NextButtonCommand", typeof(ICommand), typeof(PagerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public Style NextButtonStyle
	{
		get
		{
			return (Style)GetValue(NextButtonStyleProperty);
		}
		set
		{
			SetValue(NextButtonStyleProperty, value);
		}
	}

	public static DependencyProperty NextButtonStyleProperty { get; } = DependencyProperty.Register("NextButtonStyle", typeof(Style), typeof(PagerControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public PagerControlButtonVisibility NextButtonVisibility
	{
		get
		{
			return (PagerControlButtonVisibility)GetValue(NextButtonVisibilityProperty);
		}
		set
		{
			SetValue(NextButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty NextButtonVisibilityProperty { get; } = DependencyProperty.Register("NextButtonVisibility", typeof(PagerControlButtonVisibility), typeof(PagerControl), new FrameworkPropertyMetadata(PagerControlButtonVisibility.Visible, OnPropertyChanged));


	public int NumberOfPages
	{
		get
		{
			return (int)GetValue(NumberOfPagesProperty);
		}
		set
		{
			SetValue(NumberOfPagesProperty, value);
		}
	}

	public static DependencyProperty NumberOfPagesProperty { get; } = DependencyProperty.Register("NumberOfPages", typeof(int), typeof(PagerControl), new FrameworkPropertyMetadata(0, OnPropertyChanged));


	public string PrefixText
	{
		get
		{
			return (string)GetValue(PrefixTextProperty);
		}
		set
		{
			SetValue(PrefixTextProperty, value);
		}
	}

	public static DependencyProperty PrefixTextProperty { get; } = DependencyProperty.Register("PrefixText", typeof(string), typeof(PagerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public ICommand PreviousButtonCommand
	{
		get
		{
			return (ICommand)GetValue(PreviousButtonCommandProperty);
		}
		set
		{
			SetValue(PreviousButtonCommandProperty, value);
		}
	}

	public static DependencyProperty PreviousButtonCommandProperty { get; } = DependencyProperty.Register("PreviousButtonCommand", typeof(ICommand), typeof(PagerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public Style PreviousButtonStyle
	{
		get
		{
			return (Style)GetValue(PreviousButtonStyleProperty);
		}
		set
		{
			SetValue(PreviousButtonStyleProperty, value);
		}
	}

	public static DependencyProperty PreviousButtonStyleProperty { get; } = DependencyProperty.Register("PreviousButtonStyle", typeof(Style), typeof(PagerControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public PagerControlButtonVisibility PreviousButtonVisibility
	{
		get
		{
			return (PagerControlButtonVisibility)GetValue(PreviousButtonVisibilityProperty);
		}
		set
		{
			SetValue(PreviousButtonVisibilityProperty, value);
		}
	}

	public static DependencyProperty PreviousButtonVisibilityProperty { get; } = DependencyProperty.Register("PreviousButtonVisibility", typeof(PagerControlButtonVisibility), typeof(PagerControl), new FrameworkPropertyMetadata(PagerControlButtonVisibility.Visible, OnPropertyChanged));


	public int SelectedPageIndex
	{
		get
		{
			return (int)GetValue(SelectedPageIndexProperty);
		}
		set
		{
			SetValue(SelectedPageIndexProperty, value);
		}
	}

	public static DependencyProperty SelectedPageIndexProperty { get; } = DependencyProperty.Register("SelectedPageIndex", typeof(int), typeof(PagerControl), new FrameworkPropertyMetadata(0, OnPropertyChanged));


	public string SuffixText
	{
		get
		{
			return (string)GetValue(SuffixTextProperty);
		}
		set
		{
			SetValue(SuffixTextProperty, value);
		}
	}

	public static DependencyProperty SuffixTextProperty { get; } = DependencyProperty.Register("SuffixText", typeof(string), typeof(PagerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public PagerControlTemplateSettings TemplateSettings
	{
		get
		{
			return (PagerControlTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(PagerControlTemplateSettings), typeof(PagerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public event TypedEventHandler<PagerControl, PagerControlSelectedIndexChangedEventArgs> SelectedIndexChanged;

	public PagerControl()
	{
		m_comboBoxEntries = new ObservableVector<object>();
		m_numberPanelElements = new ObservableVector<object>();
		PagerControlTemplateSettings pagerControlTemplateSettings = new PagerControlTemplateSettings();
		pagerControlTemplateSettings.SetValue(PagerControlTemplateSettings.PagesProperty, m_comboBoxEntries);
		pagerControlTemplateSettings.SetValue(PagerControlTemplateSettings.NumberPanelItemsProperty, m_numberPanelElements);
		SetValue(TemplateSettingsProperty, pagerControlTemplateSettings);
		base.DefaultStyleKey = typeof(PagerControl);
	}

	~PagerControl()
	{
		m_rootGridKeyDownRevoker?.Dispose();
		m_comboBoxSelectionChangedRevoker?.Dispose();
		m_firstPageButtonClickRevoker?.Dispose();
		m_previousPageButtonClickRevoker?.Dispose();
		m_nextPageButtonClickRevoker?.Dispose();
		m_lastPageButtonClickRevoker?.Dispose();
	}

	protected override void OnApplyTemplate()
	{
		if (string.IsNullOrEmpty(PrefixText))
		{
			PrefixText = ResourceAccessor.GetLocalizedStringResource("PagerControlPrefixText");
		}
		if (string.IsNullOrEmpty(SuffixText))
		{
			SuffixText = ResourceAccessor.GetLocalizedStringResource("PagerControlPrefixText");
		}
		FrameworkElement rootGrid = GetTemplateChild<FrameworkElement>("RootGrid");
		if (rootGrid != null)
		{
			rootGrid.KeyDown += OnRootGridKeyDown;
			m_rootGridKeyDownRevoker.Disposable = Disposable.Create(delegate
			{
				rootGrid.KeyDown -= OnRootGridKeyDown;
			});
		}
		Button firstPageButton = GetTemplateChild<Button>("FirstPageButton");
		if (firstPageButton != null)
		{
			AutomationProperties.SetName(firstPageButton, ResourceAccessor.GetLocalizedStringResource("PagerControlFirstPageButtonText"));
			firstPageButton.Click += FirstButtonClicked;
			m_firstPageButtonClickRevoker.Disposable = Disposable.Create(delegate
			{
				firstPageButton.Click -= FirstButtonClicked;
			});
		}
		Button previousPageButton = GetTemplateChild<Button>("PreviousPageButton");
		if (previousPageButton != null)
		{
			AutomationProperties.SetName(previousPageButton, ResourceAccessor.GetLocalizedStringResource("PagerControlPreviousPageButtonText"));
			previousPageButton.Click += PreviousButtonClicked;
			m_previousPageButtonClickRevoker.Disposable = Disposable.Create(delegate
			{
				previousPageButton.Click -= PreviousButtonClicked;
			});
		}
		Button nextPageButton = GetTemplateChild<Button>("NextPageButton");
		if (nextPageButton != null)
		{
			AutomationProperties.SetName(nextPageButton, ResourceAccessor.GetLocalizedStringResource("PagerControlNextPageButtonText"));
			nextPageButton.Click += NextButtonClicked;
			m_nextPageButtonClickRevoker.Disposable = Disposable.Create(delegate
			{
				nextPageButton.Click -= NextButtonClicked;
			});
		}
		Button lastPageButton = GetTemplateChild<Button>("LastPageButton");
		if (lastPageButton != null)
		{
			AutomationProperties.SetName(lastPageButton, ResourceAccessor.GetLocalizedStringResource("PagerControlLastPageButtonText"));
			lastPageButton.Click += LastButtonClicked;
			m_lastPageButtonClickRevoker.Disposable = Disposable.Create(delegate
			{
				lastPageButton.Click -= LastButtonClicked;
			});
		}
		m_comboBoxSelectionChangedRevoker.Disposable = null;
		InitComboBox((ComboBox)GetTemplateChild("ComboBoxDisplay"));
		m_numberBoxValueChangedRevoker.Disposable = null;
		InitNumberBox((NumberBox)GetTemplateChild("NumberBoxDisplay"));
		m_numberPanelRepeater = (ItemsRepeater)GetTemplateChild("NumberPanelItemsRepeater");
		m_selectedPageIndicator = (FrameworkElement)GetTemplateChild("NumberPanelCurrentPageIndicator");
		OnDisplayModeChanged();
		UpdateOnEdgeButtonVisualStates();
		OnNumberOfPagesChanged(0);
		OnSelectedPageIndexChange(-1);
		void InitComboBox(ComboBox comboBox)
		{
			m_comboBox = comboBox;
			if (comboBox != null)
			{
				comboBox.SelectedIndex = SelectedPageIndex - 1;
				AutomationProperties.SetName(comboBox, ResourceAccessor.GetLocalizedStringResource("PagerControlPageText"));
				comboBox.SelectionChanged += ComboBoxSelectionChanged;
				m_comboBoxSelectionChangedRevoker.Disposable = Disposable.Create(delegate
				{
					comboBox.SelectionChanged -= ComboBoxSelectionChanged;
				});
			}
		}
		void InitNumberBox(NumberBox numberBox)
		{
			m_numberBox = numberBox;
			if (numberBox != null)
			{
				numberBox.Value = SelectedPageIndex + 1;
				AutomationProperties.SetName(numberBox, ResourceAccessor.GetLocalizedStringResource("PagerControlPageText"));
				numberBox.ValueChanged += NumberBoxValueChanged;
				m_numberBoxValueChangedRevoker.Disposable = Disposable.Create(delegate
				{
					numberBox.ValueChanged -= NumberBoxValueChanged;
				});
			}
		}
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (base.Template != null)
		{
			if (property == FirstButtonVisibilityProperty)
			{
				OnButtonVisibilityChanged(FirstButtonVisibility, "FirstPageButtonVisible", "FirstPageButtonCollapsed", "FirstPageButtonHidden", 0);
			}
			else if (property == PreviousButtonVisibilityProperty)
			{
				OnButtonVisibilityChanged(PreviousButtonVisibility, "PreviousPageButtonVisible", "PreviousPageButtonCollapsed", "PreviousPageButtonHidden", 0);
			}
			else if (property == NextButtonVisibilityProperty)
			{
				OnButtonVisibilityChanged(NextButtonVisibility, "NextPageButtonVisible", "NextPageButtonCollapsed", "NextPageButtonHidden", NumberOfPages - 1);
			}
			else if (property == LastButtonVisibilityProperty)
			{
				OnButtonVisibilityChanged(LastButtonVisibility, "LastPageButtonVisible", "LastPageButtonCollapsed", "LastPageButtonHidden", NumberOfPages - 1);
			}
			else if (property == DisplayModeProperty)
			{
				OnDisplayModeChanged();
				UpdateTemplateSettingElementLists();
			}
			else if (property == NumberOfPagesProperty)
			{
				OnNumberOfPagesChanged((int)args.OldValue);
			}
			else if (property == SelectedPageIndexProperty)
			{
				OnSelectedPageIndexChange((int)args.OldValue);
			}
			else if (property == ButtonPanelAlwaysShowFirstLastPageIndexProperty)
			{
				UpdateNumberPanel(NumberOfPages);
			}
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new PagerControlAutomationPeer(this);
	}

	private void OnDisplayModeChanged()
	{
		switch (DisplayMode)
		{
		case PagerControlDisplayMode.ButtonPanel:
			VisualStateManager.GoToState(this, "NumberPanelVisible", useTransitions: false);
			break;
		case PagerControlDisplayMode.ComboBox:
			VisualStateManager.GoToState(this, "ComboBoxVisible", useTransitions: false);
			break;
		case PagerControlDisplayMode.NumberBox:
			VisualStateManager.GoToState(this, "NumberBoxVisible", useTransitions: false);
			break;
		default:
			UpdateDisplayModeAutoState();
			break;
		}
	}

	private void UpdateDisplayModeAutoState()
	{
		int numberOfPages = NumberOfPages;
		if (numberOfPages > -1)
		{
			VisualStateManager.GoToState(this, (numberOfPages < 10) ? "ComboBoxVisible" : "NumberBoxVisible", useTransitions: false);
		}
		else
		{
			VisualStateManager.GoToState(this, "NumberBoxVisible", useTransitions: false);
		}
	}

	private void OnNumberOfPagesChanged(int oldValue)
	{
		m_lastNumberOfPagesCount = oldValue;
		int numberOfPages = NumberOfPages;
		if (numberOfPages < SelectedPageIndex && numberOfPages > -1)
		{
			SelectedPageIndex = numberOfPages - 1;
		}
		UpdateTemplateSettingElementLists();
		if (DisplayMode == PagerControlDisplayMode.Auto)
		{
			UpdateDisplayModeAutoState();
		}
		if (numberOfPages > -1)
		{
			VisualStateManager.GoToState(this, "FiniteItems", useTransitions: false);
			NumberBox numberBox = m_numberBox;
			if (numberBox != null)
			{
				numberBox.Maximum = numberOfPages;
			}
		}
		else
		{
			VisualStateManager.GoToState(this, "InfiniteItems", useTransitions: false);
			NumberBox numberBox2 = m_numberBox;
			if (numberBox2 != null)
			{
				numberBox2.Maximum = double.PositiveInfinity;
			}
		}
		UpdateOnEdgeButtonVisualStates();
	}

	private void OnSelectedPageIndexChange(int oldValue)
	{
		if (SelectedPageIndex > NumberOfPages - 1 && NumberOfPages > 0)
		{
			SelectedPageIndex = NumberOfPages - 1;
		}
		else if (SelectedPageIndex < 0)
		{
			SelectedPageIndex = 0;
		}
		m_lastSelectedPageIndex = oldValue;
		ComboBox comboBox = m_comboBox;
		if (comboBox != null && SelectedPageIndex < m_comboBoxEntries.Count)
		{
			comboBox.SelectedIndex = SelectedPageIndex;
		}
		NumberBox numberBox = m_numberBox;
		if (numberBox != null)
		{
			numberBox.Value = SelectedPageIndex + 1;
		}
		UpdateOnEdgeButtonVisualStates();
		UpdateTemplateSettingElementLists();
		if (DisplayMode == PagerControlDisplayMode.ButtonPanel)
		{
			UpdateNumberPanel(NumberOfPages);
		}
		if (FrameworkElementAutomationPeer.FromElement(this) is PagerControlAutomationPeer pagerControlAutomationPeer)
		{
			pagerControlAutomationPeer.RaiseSelectionChanged(m_lastSelectedPageIndex, SelectedPageIndex);
		}
		RaiseSelectedIndexChanged();
	}

	private void RaiseSelectedIndexChanged()
	{
		PagerControlSelectedIndexChangedEventArgs args = new PagerControlSelectedIndexChangedEventArgs(m_lastSelectedPageIndex, SelectedPageIndex);
		this.SelectedIndexChanged?.Invoke(this, args);
	}

	private void OnButtonVisibilityChanged(PagerControlButtonVisibility visibility, string visibleStateName, string collapsedStateName, string hiddenStateName, int hiddenOnEdgePageCriteria)
	{
		switch (visibility)
		{
		case PagerControlButtonVisibility.Visible:
			VisualStateManager.GoToState(this, visibleStateName, useTransitions: false);
			return;
		case PagerControlButtonVisibility.Hidden:
			VisualStateManager.GoToState(this, collapsedStateName, useTransitions: false);
			return;
		}
		if (SelectedPageIndex != hiddenOnEdgePageCriteria)
		{
			VisualStateManager.GoToState(this, visibleStateName, useTransitions: false);
		}
		else
		{
			VisualStateManager.GoToState(this, hiddenStateName, useTransitions: false);
		}
	}

	private void UpdateTemplateSettingElementLists()
	{
		PagerControlDisplayMode displayMode = DisplayMode;
		int numberOfPages = NumberOfPages;
		switch (displayMode)
		{
		case PagerControlDisplayMode.Auto:
		case PagerControlDisplayMode.ComboBox:
			if (numberOfPages > -1)
			{
				FillComboBoxCollectionToSize(numberOfPages);
			}
			else if (m_comboBoxEntries.Count < 100)
			{
				FillComboBoxCollectionToSize(100);
			}
			break;
		case PagerControlDisplayMode.ButtonPanel:
			UpdateNumberPanel(numberOfPages);
			break;
		}
	}

	private void FillComboBoxCollectionToSize(int numberOfPages)
	{
		int count = m_comboBoxEntries.Count;
		if (count <= numberOfPages)
		{
			for (int i = count; i < numberOfPages; i++)
			{
				m_comboBoxEntries.Add(i + 1);
			}
			return;
		}
		for (int num = count; num > numberOfPages; num--)
		{
			m_comboBoxEntries.RemoveAt(m_comboBoxEntries.Count - 1);
		}
	}

	private void UpdateOnEdgeButtonVisualStates()
	{
		int selectedPageIndex = SelectedPageIndex;
		int numberOfPages = NumberOfPages;
		if (selectedPageIndex == 0)
		{
			VisualStateManager.GoToState(this, "FirstPageButtonDisabled", useTransitions: false);
			VisualStateManager.GoToState(this, "PreviousPageButtonDisabled", useTransitions: false);
			VisualStateManager.GoToState(this, "NextPageButtonEnabled", useTransitions: false);
			VisualStateManager.GoToState(this, "LastPageButtonEnabled", useTransitions: false);
		}
		else if (selectedPageIndex >= numberOfPages - 1)
		{
			VisualStateManager.GoToState(this, "FirstPageButtonEnabled", useTransitions: false);
			VisualStateManager.GoToState(this, "PreviousPageButtonEnabled", useTransitions: false);
			if (numberOfPages > -1)
			{
				VisualStateManager.GoToState(this, "NextPageButtonDisabled", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "NextPageButtonEnabled", useTransitions: false);
			}
			VisualStateManager.GoToState(this, "LastPageButtonDisabled", useTransitions: false);
		}
		else
		{
			VisualStateManager.GoToState(this, "FirstPageButtonEnabled", useTransitions: false);
			VisualStateManager.GoToState(this, "PreviousPageButtonEnabled", useTransitions: false);
			VisualStateManager.GoToState(this, "NextPageButtonEnabled", useTransitions: false);
			VisualStateManager.GoToState(this, "LastPageButtonEnabled", useTransitions: false);
		}
		if (FirstButtonVisibility == PagerControlButtonVisibility.HiddenOnEdge)
		{
			if (selectedPageIndex != 0)
			{
				VisualStateManager.GoToState(this, "FirstPageButtonVisible", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "FirstPageButtonHidden", useTransitions: false);
			}
		}
		if (PreviousButtonVisibility == PagerControlButtonVisibility.HiddenOnEdge)
		{
			if (selectedPageIndex != 0)
			{
				VisualStateManager.GoToState(this, "PreviousPageButtonVisible", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "PreviousPageButtonHidden", useTransitions: false);
			}
		}
		if (NextButtonVisibility == PagerControlButtonVisibility.HiddenOnEdge)
		{
			if (selectedPageIndex != numberOfPages - 1)
			{
				VisualStateManager.GoToState(this, "NextPageButtonVisible", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "NextPageButtonHidden", useTransitions: false);
			}
		}
		if (LastButtonVisibility == PagerControlButtonVisibility.HiddenOnEdge)
		{
			if (selectedPageIndex != numberOfPages - 1)
			{
				VisualStateManager.GoToState(this, "LastPageButtonVisible", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "LastPageButtonHidden", useTransitions: false);
			}
		}
	}

	private void UpdateNumberPanel(int numberOfPages)
	{
		if (numberOfPages < 0)
		{
			UpdateNumberOfPanelCollectionInfiniteItems();
			return;
		}
		if (numberOfPages < 8)
		{
			UpdateNumberPanelCollectionAllItems(numberOfPages);
			return;
		}
		int selectedPageIndex = SelectedPageIndex;
		if (selectedPageIndex < 4)
		{
			UpdateNumberPanelCollectionStartWithEllipsis(numberOfPages, selectedPageIndex);
		}
		else if (selectedPageIndex >= numberOfPages - 4)
		{
			UpdateNumberPanelCollectionEndWithEllipsis(numberOfPages, selectedPageIndex);
		}
		else
		{
			UpdateNumberPanelCollectionCenterWithEllipsis(numberOfPages, selectedPageIndex);
		}
	}

	private void UpdateNumberOfPanelCollectionInfiniteItems()
	{
		int selectedPageIndex = SelectedPageIndex;
		m_numberPanelElements.Clear();
		if (selectedPageIndex < 3)
		{
			AppendButtonToNumberPanelList(1, 0);
			AppendButtonToNumberPanelList(2, 0);
			AppendButtonToNumberPanelList(3, 0);
			AppendButtonToNumberPanelList(4, 0);
			AppendButtonToNumberPanelList(5, 0);
			MoveIdentifierToElement(selectedPageIndex);
		}
		else
		{
			AppendButtonToNumberPanelList(1, 0);
			AppendEllipsisIconToNumberPanelList();
			AppendButtonToNumberPanelList(selectedPageIndex, 0);
			AppendButtonToNumberPanelList(selectedPageIndex + 1, 0);
			AppendButtonToNumberPanelList(selectedPageIndex + 2, 0);
			MoveIdentifierToElement(3);
		}
	}

	private void UpdateNumberPanelCollectionAllItems(int numberOfPages)
	{
		if (m_lastNumberOfPagesCount != numberOfPages)
		{
			m_numberPanelElements.Clear();
			for (int i = 0; i < numberOfPages && i < 7; i++)
			{
				AppendButtonToNumberPanelList(i + 1, numberOfPages);
			}
		}
		MoveIdentifierToElement(SelectedPageIndex);
	}

	private void UpdateNumberPanelCollectionStartWithEllipsis(int numberOfPages, int selectedIndex)
	{
		if (m_lastNumberOfPagesCount != numberOfPages)
		{
			m_numberPanelElements.Clear();
			AppendButtonToNumberPanelList(1, numberOfPages);
			AppendButtonToNumberPanelList(2, numberOfPages);
			AppendButtonToNumberPanelList(3, numberOfPages);
			AppendButtonToNumberPanelList(4, numberOfPages);
			AppendButtonToNumberPanelList(5, numberOfPages);
			if (ButtonPanelAlwaysShowFirstLastPageIndex)
			{
				AppendEllipsisIconToNumberPanelList();
				AppendButtonToNumberPanelList(numberOfPages, numberOfPages);
			}
		}
		MoveIdentifierToElement(selectedIndex);
	}

	private void UpdateNumberPanelCollectionEndWithEllipsis(int numberOfPages, int selectedIndex)
	{
		if (m_lastNumberOfPagesCount != numberOfPages)
		{
			m_numberPanelElements.Clear();
			if (ButtonPanelAlwaysShowFirstLastPageIndex)
			{
				AppendButtonToNumberPanelList(1, numberOfPages);
				AppendEllipsisIconToNumberPanelList();
			}
			AppendButtonToNumberPanelList(numberOfPages - 4, numberOfPages);
			AppendButtonToNumberPanelList(numberOfPages - 3, numberOfPages);
			AppendButtonToNumberPanelList(numberOfPages - 2, numberOfPages);
			AppendButtonToNumberPanelList(numberOfPages - 1, numberOfPages);
			AppendButtonToNumberPanelList(numberOfPages, numberOfPages);
		}
		if (ButtonPanelAlwaysShowFirstLastPageIndex)
		{
			MoveIdentifierToElement(selectedIndex - numberOfPages + 7);
		}
		else
		{
			MoveIdentifierToElement(selectedIndex - numberOfPages + 5);
		}
	}

	private void UpdateNumberPanelCollectionCenterWithEllipsis(int numberOfPages, int selectedIndex)
	{
		bool buttonPanelAlwaysShowFirstLastPageIndex = ButtonPanelAlwaysShowFirstLastPageIndex;
		if (m_lastNumberOfPagesCount != numberOfPages)
		{
			m_numberPanelElements.Clear();
			if (buttonPanelAlwaysShowFirstLastPageIndex)
			{
				AppendButtonToNumberPanelList(1, numberOfPages);
				AppendEllipsisIconToNumberPanelList();
			}
			AppendButtonToNumberPanelList(selectedIndex, numberOfPages);
			AppendButtonToNumberPanelList(selectedIndex + 1, numberOfPages);
			AppendButtonToNumberPanelList(selectedIndex + 2, numberOfPages);
			if (buttonPanelAlwaysShowFirstLastPageIndex)
			{
				AppendEllipsisIconToNumberPanelList();
				AppendButtonToNumberPanelList(numberOfPages, numberOfPages);
			}
		}
		if (buttonPanelAlwaysShowFirstLastPageIndex)
		{
			MoveIdentifierToElement(3);
		}
		else
		{
			MoveIdentifierToElement(1);
		}
	}

	private void MoveIdentifierToElement(int index)
	{
		FrameworkElement selectedPageIndicator = m_selectedPageIndicator;
		if (selectedPageIndicator == null)
		{
			return;
		}
		ItemsRepeater numberPanelRepeater = m_numberPanelRepeater;
		if (numberPanelRepeater != null)
		{
			numberPanelRepeater.UpdateLayout();
			if (numberPanelRepeater.TryGetElement(index) is FrameworkElement frameworkElement)
			{
				Rect rect = frameworkElement.TransformToVisual(numberPanelRepeater).TransformBounds(new Rect(0.0, 0.0, (float)numberPanelRepeater.ActualWidth, (float)numberPanelRepeater.ActualHeight));
				Thickness margin = default(Thickness);
				margin.Left = rect.X;
				margin.Top = 0.0;
				margin.Right = 0.0;
				margin.Bottom = 0.0;
				selectedPageIndicator.Margin = margin;
				selectedPageIndicator.Width = frameworkElement.ActualWidth;
			}
		}
	}

	private void AppendButtonToNumberPanelList(int pageNumber, int numberOfPages)
	{
		Button button = new Button();
		button.Content = pageNumber;
		button.Click += delegate(object sender, RoutedEventArgs args)
		{
			if (sender is Button button2)
			{
				int num = (int)button2.Content;
				SelectedPageIndex = num - 1;
			}
		};
		button.Style = (Style)ResourceAccessor.ResourceLookup(this, "PagerControlNumberPanelButtonStyle");
		AutomationProperties.SetName(button, ResourceAccessor.GetLocalizedStringResource("PagerControlPageText") + " " + pageNumber);
		AutomationProperties.SetPositionInSet(button, pageNumber);
		AutomationProperties.SetSizeOfSet(button, numberOfPages);
		m_numberPanelElements.Add(button);
	}

	private void AppendEllipsisIconToNumberPanelList()
	{
		SymbolIcon symbolIcon = new SymbolIcon();
		symbolIcon.Symbol = Symbol.More;
		m_numberPanelElements.Add(symbolIcon);
	}

	private void OnRootGridKeyDown(object sender, KeyRoutedEventArgs args)
	{
		if (args.Key == VirtualKey.Left || args.Key == VirtualKey.GamepadDPadLeft)
		{
			FocusManager.TryMoveFocus(FocusNavigationDirection.Left);
		}
		else if (args.Key == VirtualKey.Right || args.Key == VirtualKey.GamepadDPadRight)
		{
			FocusManager.TryMoveFocus(FocusNavigationDirection.Right);
		}
	}

	private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs args)
	{
		ComboBox comboBox = m_comboBox;
		if (comboBox != null)
		{
			SelectedPageIndex = comboBox.SelectedIndex;
		}
	}

	private void NumberBoxValueChanged(object sender, NumberBoxValueChangedEventArgs args)
	{
		SelectedPageIndex = (int)args.NewValue - 1;
	}

	private void FirstButtonClicked(object sender, RoutedEventArgs e)
	{
		SelectedPageIndex = 0;
		FirstButtonCommand?.Execute(null);
	}

	private void PreviousButtonClicked(object sender, RoutedEventArgs e)
	{
		SelectedPageIndex--;
		PreviousButtonCommand?.Execute(null);
	}

	private void NextButtonClicked(object sender, RoutedEventArgs e)
	{
		SelectedPageIndex++;
		NextButtonCommand?.Execute(null);
	}

	private void LastButtonClicked(object sender, RoutedEventArgs e)
	{
		SelectedPageIndex = NumberOfPages - 1;
		LastButtonCommand?.Execute(null);
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		PagerControl pagerControl = (PagerControl)sender;
		pagerControl.OnPropertyChanged(args);
	}
}

using System;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class TwoPaneView : Control
{
	private enum ViewMode
	{
		Pane1Only,
		Pane2Only,
		LeftRight,
		RightLeft,
		TopBottom,
		BottomTop,
		None
	}

	private const string c_pane1ScrollViewerName = "PART_Pane1ScrollViewer";

	private const string c_pane2ScrollViewerName = "PART_Pane2ScrollViewer";

	private const string c_columnLeftName = "PART_ColumnLeft";

	private const string c_columnMiddleName = "PART_ColumnMiddle";

	private const string c_columnRightName = "PART_ColumnRight";

	private const string c_rowTopName = "PART_RowTop";

	private const string c_rowMiddleName = "PART_RowMiddle";

	private const string c_rowBottomName = "PART_RowBottom";

	private const double c_defaultMinWideModeWidth = 641.0;

	private const double c_defaultMinTallModeHeight = 641.0;

	private static readonly GridLength c_pane1LengthDefault = new GridLength(1.0, GridUnitType.Auto);

	private static readonly GridLength c_pane2LengthDefault = new GridLength(1.0, GridUnitType.Star);

	private ViewMode m_currentMode = ViewMode.None;

	private bool m_loaded;

	private readonly SerialDisposable m_pane1LoadedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_pane2LoadedRevoker = new SerialDisposable();

	private ColumnDefinition? m_columnLeft;

	private ColumnDefinition? m_columnMiddle;

	private ColumnDefinition? m_columnRight;

	private RowDefinition? m_rowTop;

	private RowDefinition? m_rowMiddle;

	private RowDefinition? m_rowBottom;

	private readonly SerialDisposable m_windowSizeChangedRevoker = new SerialDisposable();

	public double MinTallModeHeight
	{
		get
		{
			return (double)GetValue(MinTallModeHeightProperty);
		}
		set
		{
			SetValue(MinTallModeHeightProperty, value);
		}
	}

	public static DependencyProperty MinTallModeHeightProperty { get; } = DependencyProperty.Register("MinTallModeHeight", typeof(double), typeof(TwoPaneView), new FrameworkPropertyMetadata(641.0, OnPropertyChanged));


	public double MinWideModeWidth
	{
		get
		{
			return (double)GetValue(MinWideModeWidthProperty);
		}
		set
		{
			SetValue(MinWideModeWidthProperty, value);
		}
	}

	public static DependencyProperty MinWideModeWidthProperty { get; } = DependencyProperty.Register("MinWideModeWidth", typeof(double), typeof(TwoPaneView), new FrameworkPropertyMetadata(641.0, OnPropertyChanged));


	public TwoPaneViewMode Mode => (TwoPaneViewMode)GetValue(ModeProperty);

	public static DependencyProperty ModeProperty { get; } = DependencyProperty.Register("Mode", typeof(TwoPaneViewMode), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewMode.SinglePane));


	public UIElement Pane1
	{
		get
		{
			return (UIElement)GetValue(Pane1Property);
		}
		set
		{
			SetValue(Pane1Property, value);
		}
	}

	public static DependencyProperty Pane1Property { get; } = DependencyProperty.Register("Pane1", typeof(UIElement), typeof(TwoPaneView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public GridLength Pane1Length
	{
		get
		{
			return (GridLength)GetValue(Pane1LengthProperty);
		}
		set
		{
			SetValue(Pane1LengthProperty, value);
		}
	}

	public static DependencyProperty Pane1LengthProperty { get; } = DependencyProperty.Register("Pane1Length", typeof(GridLength), typeof(TwoPaneView), new FrameworkPropertyMetadata(c_pane1LengthDefault, OnPropertyChanged));


	public UIElement Pane2
	{
		get
		{
			return (UIElement)GetValue(Pane2Property);
		}
		set
		{
			SetValue(Pane2Property, value);
		}
	}

	public static DependencyProperty Pane2Property { get; } = DependencyProperty.Register("Pane2", typeof(UIElement), typeof(TwoPaneView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public GridLength Pane2Length
	{
		get
		{
			return (GridLength)GetValue(Pane2LengthProperty);
		}
		set
		{
			SetValue(Pane2LengthProperty, value);
		}
	}

	public static DependencyProperty Pane2LengthProperty { get; } = DependencyProperty.Register("Pane2Length", typeof(GridLength), typeof(TwoPaneView), new FrameworkPropertyMetadata(c_pane2LengthDefault, OnPropertyChanged));


	public TwoPaneViewPriority PanePriority
	{
		get
		{
			return (TwoPaneViewPriority)GetValue(PanePriorityProperty);
		}
		set
		{
			SetValue(PanePriorityProperty, value);
		}
	}

	public static DependencyProperty PanePriorityProperty { get; } = DependencyProperty.Register("PanePriority", typeof(TwoPaneViewPriority), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewPriority.Pane1, OnPropertyChanged));


	public TwoPaneViewTallModeConfiguration TallModeConfiguration
	{
		get
		{
			return (TwoPaneViewTallModeConfiguration)GetValue(TallModeConfigurationProperty);
		}
		set
		{
			SetValue(TallModeConfigurationProperty, value);
		}
	}

	public static DependencyProperty TallModeConfigurationProperty { get; } = DependencyProperty.Register("TallModeConfiguration", typeof(TwoPaneViewTallModeConfiguration), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewTallModeConfiguration.TopBottom, OnPropertyChanged));


	public TwoPaneViewWideModeConfiguration WideModeConfiguration
	{
		get
		{
			return (TwoPaneViewWideModeConfiguration)GetValue(WideModeConfigurationProperty);
		}
		set
		{
			SetValue(WideModeConfigurationProperty, value);
		}
	}

	public static DependencyProperty WideModeConfigurationProperty { get; } = DependencyProperty.Register("WideModeConfiguration", typeof(TwoPaneViewWideModeConfiguration), typeof(TwoPaneView), new FrameworkPropertyMetadata(TwoPaneViewWideModeConfiguration.LeftRight, OnPropertyChanged));


	public event TypedEventHandler<TwoPaneView, object> ModeChanged;

	public TwoPaneView()
	{
		base.DefaultStyleKey = typeof(TwoPaneView);
		base.SizeChanged += OnSizeChanged;
		Window window = Window.Current;
		window.SizeChanged += OnWindowSizeChanged;
		m_windowSizeChangedRevoker.Disposable = Disposable.Create(delegate
		{
			window.SizeChanged -= OnWindowSizeChanged;
		});
		base.Unloaded += delegate
		{
			m_windowSizeChangedRevoker.Disposable = null;
			m_pane1LoadedRevoker.Disposable = null;
			m_pane2LoadedRevoker.Disposable = null;
		};
	}

	protected override void OnApplyTemplate()
	{
		m_loaded = true;
		SetScrollViewerProperties("PART_Pane1ScrollViewer", m_pane1LoadedRevoker);
		SetScrollViewerProperties("PART_Pane2ScrollViewer", m_pane2LoadedRevoker);
		if (GetTemplateChild("PART_ColumnLeft") is ColumnDefinition columnLeft)
		{
			m_columnLeft = columnLeft;
		}
		if (GetTemplateChild("PART_ColumnMiddle") is ColumnDefinition columnMiddle)
		{
			m_columnMiddle = columnMiddle;
		}
		if (GetTemplateChild("PART_ColumnRight") is ColumnDefinition columnRight)
		{
			m_columnRight = columnRight;
		}
		if (GetTemplateChild("PART_RowTop") is RowDefinition rowTop)
		{
			m_rowTop = rowTop;
		}
		if (GetTemplateChild("PART_RowMiddle") is RowDefinition rowMiddle)
		{
			m_rowMiddle = rowMiddle;
		}
		if (GetTemplateChild("PART_RowBottom") is RowDefinition rowBottom)
		{
			m_rowBottom = rowBottom;
		}
	}

	private void SetScrollViewerProperties(string scrollViewerName, SerialDisposable revoker)
	{
		if (!SharedHelpers.IsRS5OrHigher())
		{
			return;
		}
		DependencyObject templateChild = GetTemplateChild(scrollViewerName);
		ScrollViewer scrollViewer = templateChild as ScrollViewer;
		if (scrollViewer != null && SharedHelpers.IsScrollContentPresenterSizesContentToTemplatedParentAvailable())
		{
			scrollViewer.Loaded += OnScrollViewerLoaded;
			revoker.Disposable = Disposable.Create(delegate
			{
				scrollViewer.Loaded -= OnScrollViewerLoaded;
			});
		}
	}

	private void OnScrollViewerLoaded(object sender, RoutedEventArgs args)
	{
		if (sender is FrameworkElement parent)
		{
			FrameworkElement frameworkElement = SharedHelpers.FindInVisualTreeByName(parent, "ScrollContentPresenter");
			if (frameworkElement != null && frameworkElement is ScrollContentPresenter scrollContentPresenter)
			{
				scrollContentPresenter.SizesContentToTemplatedParent = true;
			}
		}
	}

	private void OnWindowSizeChanged(object sender, WindowSizeChangedEventArgs args)
	{
		UpdateMode();
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		UpdateMode();
	}

	private void UpdateMode()
	{
		if (!m_loaded)
		{
			return;
		}
		double actualWidth = base.ActualWidth;
		double actualHeight = base.ActualHeight;
		ViewMode viewMode = ((PanePriority != 0) ? ViewMode.Pane2Only : ViewMode.Pane1Only);
		DisplayRegionHelperInfo regionInfo = DisplayRegionHelper.GetRegionInfo();
		Rect controlRect = GetControlRect();
		if (IsInMultipleRegions(regionInfo, controlRect))
		{
			if (regionInfo.Mode == TwoPaneViewMode.Wide)
			{
				if (WideModeConfiguration != 0)
				{
					viewMode = ((WideModeConfiguration == TwoPaneViewWideModeConfiguration.LeftRight) ? ViewMode.LeftRight : ViewMode.RightLeft);
				}
			}
			else if (regionInfo.Mode == TwoPaneViewMode.Tall && TallModeConfiguration != 0)
			{
				viewMode = ((TallModeConfiguration == TwoPaneViewTallModeConfiguration.TopBottom) ? ViewMode.TopBottom : ViewMode.BottomTop);
			}
		}
		else if (actualWidth > MinWideModeWidth && WideModeConfiguration != 0)
		{
			viewMode = ((WideModeConfiguration == TwoPaneViewWideModeConfiguration.LeftRight) ? ViewMode.LeftRight : ViewMode.RightLeft);
		}
		else if (actualHeight > MinTallModeHeight && TallModeConfiguration != 0)
		{
			viewMode = ((TallModeConfiguration == TwoPaneViewTallModeConfiguration.TopBottom) ? ViewMode.TopBottom : ViewMode.BottomTop);
		}
		UpdateRowsColumns(viewMode, regionInfo, controlRect);
		if (viewMode != m_currentMode)
		{
			m_currentMode = viewMode;
			TwoPaneViewMode twoPaneViewMode = TwoPaneViewMode.SinglePane;
			switch (m_currentMode)
			{
			case ViewMode.Pane1Only:
				VisualStateManager.GoToState(this, "ViewMode_OneOnly", useTransitions: true);
				break;
			case ViewMode.Pane2Only:
				VisualStateManager.GoToState(this, "ViewMode_TwoOnly", useTransitions: true);
				break;
			case ViewMode.LeftRight:
				VisualStateManager.GoToState(this, "ViewMode_LeftRight", useTransitions: true);
				twoPaneViewMode = TwoPaneViewMode.Wide;
				break;
			case ViewMode.RightLeft:
				VisualStateManager.GoToState(this, "ViewMode_RightLeft", useTransitions: true);
				twoPaneViewMode = TwoPaneViewMode.Wide;
				break;
			case ViewMode.TopBottom:
				VisualStateManager.GoToState(this, "ViewMode_TopBottom", useTransitions: true);
				twoPaneViewMode = TwoPaneViewMode.Tall;
				break;
			case ViewMode.BottomTop:
				VisualStateManager.GoToState(this, "ViewMode_BottomTop", useTransitions: true);
				twoPaneViewMode = TwoPaneViewMode.Tall;
				break;
			}
			if (twoPaneViewMode != Mode)
			{
				SetValue(ModeProperty, twoPaneViewMode);
				this.ModeChanged?.Invoke(this, this);
			}
		}
	}

	private void UpdateRowsColumns(ViewMode newMode, DisplayRegionHelperInfo info, Rect rcControl)
	{
		if (m_columnLeft == null || m_columnMiddle == null || m_columnRight == null || m_rowTop == null || m_rowMiddle == null || m_rowBottom == null)
		{
			return;
		}
		m_columnMiddle!.Width = new GridLength(0.0, GridUnitType.Pixel);
		m_rowMiddle!.Height = new GridLength(0.0, GridUnitType.Pixel);
		if (newMode == ViewMode.LeftRight || newMode == ViewMode.RightLeft)
		{
			m_columnLeft!.Width = ((newMode == ViewMode.LeftRight) ? Pane1Length : Pane2Length);
			m_columnRight!.Width = ((newMode == ViewMode.LeftRight) ? Pane2Length : Pane1Length);
		}
		else
		{
			m_columnLeft!.Width = new GridLength(1.0, GridUnitType.Star);
			m_columnRight!.Width = new GridLength(0.0, GridUnitType.Pixel);
		}
		if (newMode == ViewMode.TopBottom || newMode == ViewMode.BottomTop)
		{
			m_rowTop!.Height = ((newMode == ViewMode.TopBottom) ? Pane1Length : Pane2Length);
			m_rowBottom!.Height = ((newMode == ViewMode.TopBottom) ? Pane2Length : Pane1Length);
		}
		else
		{
			m_rowTop!.Height = new GridLength(1.0, GridUnitType.Star);
			m_rowBottom!.Height = new GridLength(0.0, GridUnitType.Pixel);
		}
		if (IsInMultipleRegions(info, rcControl) && newMode != 0 && newMode != ViewMode.Pane2Only)
		{
			Rect rect = info.Regions[0];
			Rect rect2 = info.Regions[1];
			Rect rect3 = DisplayRegionHelper.WindowRect();
			if (info.Mode == TwoPaneViewMode.Wide)
			{
				m_columnMiddle!.Width = new GridLength(rect2.X - rect.Width, GridUnitType.Pixel);
				m_columnLeft!.Width = new GridLength(rect.Width - rcControl.X, GridUnitType.Pixel);
				m_columnRight!.Width = new GridLength(Math.Max(0.0, rect2.Width - (rect3.Width - rcControl.Width - rcControl.X)), GridUnitType.Pixel);
			}
			else
			{
				m_rowMiddle!.Height = new GridLength(rect2.Y - rect.Height, GridUnitType.Pixel);
				m_rowTop!.Height = new GridLength(rect.Height - rcControl.Y, GridUnitType.Pixel);
				m_rowBottom!.Height = new GridLength(Math.Max(0.0, rect2.Height - (rect3.Height - rcControl.Height - rcControl.Y)), GridUnitType.Pixel);
			}
		}
	}

	private Rect GetControlRect()
	{
		GeneralTransform generalTransform = TransformToVisual(DisplayRegionHelper.WindowElement());
		return generalTransform.TransformBounds(new Rect(0.0, 0.0, (float)base.ActualWidth, (float)base.ActualHeight));
	}

	private bool IsInMultipleRegions(DisplayRegionHelperInfo info, Rect rcControl)
	{
		bool result = false;
		if (info.Mode != 0)
		{
			Rect rect = info.Regions[0];
			Rect rect2 = info.Regions[1];
			if (info.Mode == TwoPaneViewMode.Wide)
			{
				if (rcControl.X < rect.Width && rcControl.X + rcControl.Width > rect2.X)
				{
					result = true;
				}
			}
			else if (info.Mode == TwoPaneViewMode.Tall && rcControl.Y < rect.Height && rcControl.Y + rcControl.Height > rect2.Y)
			{
				result = true;
			}
		}
		return result;
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == MinWideModeWidthProperty || property == MinTallModeHeightProperty)
		{
			double num = (double)args.NewValue;
			double num2 = Math.Max(0.0, num);
			if (num2 != num)
			{
				SetValue(property, num2);
				return;
			}
		}
		if (property == PanePriorityProperty || property == Pane1LengthProperty || property == Pane2LengthProperty || property == WideModeConfigurationProperty || property == TallModeConfigurationProperty || property == MinWideModeWidthProperty || property == MinTallModeHeightProperty)
		{
			UpdateMode();
		}
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TwoPaneView twoPaneView = (TwoPaneView)sender;
		twoPaneView.OnPropertyChanged(args);
	}
}

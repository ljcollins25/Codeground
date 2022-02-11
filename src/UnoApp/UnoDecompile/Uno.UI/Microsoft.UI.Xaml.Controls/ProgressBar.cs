using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Microsoft.UI.Xaml.Controls;

public class ProgressBar : RangeBase
{
	private const string s_ErrorStateName = "Error";

	private const string s_PausedStateName = "Paused";

	private const string s_IndeterminateStateName = "Indeterminate";

	private const string s_IndeterminateErrorStateName = "IndeterminateError";

	private const string s_IndeterminatePausedStateName = "IndeterminatePaused";

	private const string s_DeterminateStateName = "Determinate";

	private const string s_UpdatingStateName = "Updating";

	private Grid m_layoutRoot;

	private Rectangle m_determinateProgressBarIndicator;

	private Rectangle m_indeterminateProgressBarIndicator;

	private Rectangle m_indeterminateProgressBarIndicator2;

	public static DependencyProperty IsIndeterminateProperty { get; } = DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ProgressBar), new FrameworkPropertyMetadata(false, OnIsIndeterminateChanged));


	public bool IsIndeterminate
	{
		get
		{
			return (bool)GetValue(IsIndeterminateProperty);
		}
		set
		{
			SetValue(IsIndeterminateProperty, value);
		}
	}

	public static DependencyProperty ShowErrorProperty { get; } = DependencyProperty.Register("ShowError", typeof(bool), typeof(ProgressBar), new FrameworkPropertyMetadata(false, OnShowErrorChanged));


	public bool ShowError
	{
		get
		{
			return (bool)GetValue(ShowErrorProperty);
		}
		set
		{
			SetValue(ShowErrorProperty, value);
		}
	}

	public static DependencyProperty ShowPausedProperty { get; } = DependencyProperty.Register("ShowPaused", typeof(bool), typeof(ProgressBar), new FrameworkPropertyMetadata(false, OnShowPausedChanged));


	public bool ShowPaused
	{
		get
		{
			return (bool)GetValue(ShowPausedProperty);
		}
		set
		{
			SetValue(ShowPausedProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(ProgressBarTemplateSettings), typeof(ProgressBar), new FrameworkPropertyMetadata((object)null));


	public ProgressBarTemplateSettings TemplateSettings
	{
		get
		{
			return (ProgressBarTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public ProgressBar()
	{
		base.DefaultStyleKey = typeof(ProgressBar);
		base.SizeChanged += delegate
		{
			OnSizeChange();
		};
		base.LayoutUpdated += delegate
		{
			OnSizeChange();
		};
		RegisterPropertyChangedCallback(RangeBase.ValueProperty, OnRangeBasePropertyChanged);
		RegisterPropertyChangedCallback(RangeBase.MinimumProperty, OnRangeBasePropertyChanged);
		RegisterPropertyChangedCallback(RangeBase.MaximumProperty, OnRangeBasePropertyChanged);
		RegisterPropertyChangedCallback(Control.PaddingProperty, OnRangeBasePropertyChanged);
		TemplateSettings = new ProgressBarTemplateSettings();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ProgressBarAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		m_layoutRoot = GetTemplateChild("LayoutRoot") as Grid;
		m_determinateProgressBarIndicator = GetTemplateChild("DeterminateProgressBarIndicator") as Rectangle;
		m_indeterminateProgressBarIndicator = GetTemplateChild("IndeterminateProgressBarIndicator") as Rectangle;
		m_indeterminateProgressBarIndicator2 = GetTemplateChild("IndeterminateProgressBarIndicator2") as Rectangle;
		UpdateStates();
	}

	private void OnSizeChange()
	{
		SetProgressBarIndicatorWidth();
		UpdateWidthBasedTemplateSettings();
	}

	private void OnRangeBasePropertyChanged(DependencyObject sender, DependencyProperty dp)
	{
		SetProgressBarIndicatorWidth();
	}

	private static void OnIsIndeterminateChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyobject is ProgressBar progressBar)
		{
			progressBar.SetProgressBarIndicatorWidth();
			progressBar.UpdateStates();
		}
	}

	private static void OnShowErrorChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyobject is ProgressBar progressBar)
		{
			progressBar.UpdateStates();
		}
	}

	private static void OnShowPausedChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyobject is ProgressBar progressBar)
		{
			progressBar.UpdateStates();
		}
	}

	private void UpdateStates()
	{
		bool showError = ShowError;
		bool isIndeterminate = IsIndeterminate;
		if (showError && isIndeterminate)
		{
			VisualStateManager.GoToState(this, "IndeterminateError", useTransitions: true);
		}
		else if (showError)
		{
			VisualStateManager.GoToState(this, "Error", useTransitions: true);
		}
		else if (isIndeterminate && ShowPaused)
		{
			VisualStateManager.GoToState(this, "IndeterminatePaused", useTransitions: true);
		}
		else if (ShowPaused)
		{
			VisualStateManager.GoToState(this, "Paused", useTransitions: true);
		}
		else if (isIndeterminate)
		{
			UpdateWidthBasedTemplateSettings();
			VisualStateManager.GoToState(this, "Indeterminate", useTransitions: true);
		}
		else if (!isIndeterminate)
		{
			VisualStateManager.GoToState(this, "Determinate", useTransitions: true);
		}
	}

	private void SetProgressBarIndicatorWidth()
	{
		ProgressBarTemplateSettings templateSettings = TemplateSettings;
		Grid layoutRoot = m_layoutRoot;
		if (layoutRoot == null)
		{
			return;
		}
		Rectangle determinateProgressBarIndicator = m_determinateProgressBarIndicator;
		if (determinateProgressBarIndicator == null)
		{
			return;
		}
		double actualWidth = layoutRoot.ActualWidth;
		double actualWidth2 = determinateProgressBarIndicator.ActualWidth;
		double maximum = base.Maximum;
		double minimum = base.Minimum;
		Thickness padding = base.Padding;
		VisualStateManager.GoToState(this, "Updating", useTransitions: true);
		if (IsIndeterminate)
		{
			determinateProgressBarIndicator.Width = 0.0;
			Rectangle indeterminateProgressBarIndicator = m_indeterminateProgressBarIndicator;
			if (indeterminateProgressBarIndicator != null)
			{
				indeterminateProgressBarIndicator.Width = actualWidth * 0.4;
			}
			Rectangle indeterminateProgressBarIndicator2 = m_indeterminateProgressBarIndicator2;
			if (indeterminateProgressBarIndicator2 != null)
			{
				indeterminateProgressBarIndicator2.Width = actualWidth * 0.6;
			}
		}
		else if (Math.Abs(maximum - minimum) > double.Epsilon)
		{
			double num = actualWidth - (padding.Left + padding.Right);
			double num2 = num / (maximum - minimum);
			double num3 = num2 * (base.Value - minimum);
			double num4 = num3 - actualWidth2;
			templateSettings.IndicatorLengthDelta = 0.0 - num4;
			determinateProgressBarIndicator.Width = num3;
		}
		else
		{
			determinateProgressBarIndicator.Width = 0.0;
		}
		UpdateStates();
	}

	private void UpdateWidthBasedTemplateSettings()
	{
		ProgressBarTemplateSettings templateSettings = TemplateSettings;
		Grid layoutRoot = m_layoutRoot;
		double num;
		double num2;
		if (layoutRoot == null)
		{
			num = 0.0;
			num2 = 0.0;
		}
		else
		{
			double actualWidth = layoutRoot.ActualWidth;
			double actualHeight = layoutRoot.ActualHeight;
			num = actualWidth;
			num2 = actualHeight;
		}
		double num3 = num * 0.4;
		double num4 = num * 0.6;
		templateSettings.ContainerAnimationStartPosition = num3 * -1.0;
		templateSettings.ContainerAnimationEndPosition = num3 * 3.0;
		templateSettings.ContainerAnimationStartPosition2 = num4 * -1.5;
		templateSettings.ContainerAnimationEndPosition2 = num4 * 1.66;
		templateSettings.ContainerAnimationMidPosition = num * 0.2;
		Thickness padding = base.Padding;
		templateSettings.ClipRect = new RectangleGeometry
		{
			Rect = new Rect(padding.Left, padding.Top, num - (padding.Right + padding.Left), num2 - (padding.Bottom + padding.Top))
		};
	}
}

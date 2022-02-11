using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class ProgressBar : RangeBase
{
	private FrameworkElement _determinateRoot;

	private FrameworkElement _progressBarIndicator;

	public ProgressBarTemplateSettings TemplateSettings { get; }

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

	public static DependencyProperty IsIndeterminateProperty { get; }

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

	public static DependencyProperty ShowErrorProperty { get; }

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

	public static DependencyProperty ShowPausedProperty { get; }

	static ProgressBar()
	{
		IsIndeterminateProperty = DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ProgressBar), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			(s as ProgressBar)?.OnIsIndeterminateChanged((bool)e.OldValue, (bool)e.NewValue);
		}));
		ShowErrorProperty = DependencyProperty.Register("ShowError", typeof(bool), typeof(ProgressBar), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			(s as ProgressBar)?.OnShowErrorChanged((bool)e.OldValue, (bool)e.NewValue);
		}));
		ShowPausedProperty = DependencyProperty.Register("ShowPaused", typeof(bool), typeof(ProgressBar), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			(s as ProgressBar)?.OnShowPausedChanged((bool)e.OldValue, (bool)e.NewValue);
		}));
		RangeBase.MaximumProperty.OverrideMetadata(typeof(ProgressBar), new FrameworkPropertyMetadata(100.0));
	}

	public ProgressBar()
	{
		TemplateSettings = new ProgressBarTemplateSettings();
		base.DefaultStyleKey = typeof(ProgressBar);
	}

	protected virtual void OnIsIndeterminateChanged(bool oldValue, bool newValue)
	{
		UpdateCommonStates();
	}

	protected virtual void OnShowErrorChanged(bool oldValue, bool newValue)
	{
		UpdateCommonStates();
	}

	protected virtual void OnShowPausedChanged(bool oldValue, bool newValue)
	{
		UpdateCommonStates();
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_determinateRoot = GetTemplateChild("DeterminateRoot") as FrameworkElement;
		_progressBarIndicator = GetTemplateChild("ProgressBarIndicator") as FrameworkElement;
		if (_determinateRoot != null)
		{
			_determinateRoot.SizeChanged += delegate
			{
				UpdateProgress(dispatchInvalidate: true);
			};
		}
		UpdateProgress();
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		UpdateProgress();
	}

	protected override void OnMaximumChanged(double oldValue, double newValue)
	{
		base.OnMaximumChanged(oldValue, newValue);
		UpdateProgress();
	}

	protected override void OnMinimumChanged(double oldValue, double newValue)
	{
		base.OnMinimumChanged(oldValue, newValue);
		UpdateProgress();
	}

	private void UpdateProgress(bool dispatchInvalidate = false)
	{
		if (_progressBarIndicator != null && _determinateRoot != null)
		{
			_progressBarIndicator.Width = _determinateRoot.ActualWidth * (base.Value / (base.Maximum - base.Minimum));
		}
	}

	private void UpdateCommonStates()
	{
		if (IsIndeterminate)
		{
			VisualStateManager.GoToState(this, "Indeterminate", useTransitions: false);
		}
		else if (ShowError)
		{
			VisualStateManager.GoToState(this, "Error", useTransitions: false);
		}
		else if (ShowPaused)
		{
			VisualStateManager.GoToState(this, "Paused", useTransitions: false);
		}
		else if (!IsIndeterminate)
		{
			VisualStateManager.GoToState(this, "Determinate", useTransitions: false);
		}
		else
		{
			VisualStateManager.GoToState(this, "Updating", useTransitions: false);
		}
	}
}

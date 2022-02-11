using System;
using System.Threading.Tasks;
using Uno.Foundation.Extensibility;
using Uno.Foundation.Logging;
using Uno.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class ProgressRing : Control
{
	private enum LoadedAsset : byte
	{
		NotLoaded,
		Indeterminate,
		Determinate
	}

	private const string ActiveStateName = "Active";

	private const string DeterminateActiveStateName = "DeterminateActive";

	private const string InactiveStateName = "Inactive";

	private const string LottiePlayerName = "LottiePlayer";

	private const string LayoutRootName = "LayoutRoot";

	private readonly ILottieVisualSourceProvider? _lottieProvider;

	private AnimatedVisualPlayer? _player;

	private Panel? _layoutRoot;

	private double _oldValue;

	private Uri? _currentSourceUri;

	private LoadedAsset _loadedAsset;

	public static readonly DependencyProperty DeterminateSourceProperty = DependencyProperty.Register("DeterminateSource", typeof(IAnimatedVisualSource), typeof(ProgressRing), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ProgressRing)?.OnDeterminateSourcePropertyChanged(e);
	}));

	public static readonly DependencyProperty IndeterminateSourceProperty = DependencyProperty.Register("IndeterminateSource", typeof(IAnimatedVisualSource), typeof(ProgressRing), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ProgressRing)?.OnIndeterminateSourcePropertyChanged(e);
	}));

	public static DependencyProperty IsActiveProperty { get; } = DependencyProperty.Register("IsActive", typeof(bool), typeof(ProgressRing), new FrameworkPropertyMetadata(true, OnIsActivePropertyChanged));


	public bool IsActive
	{
		get
		{
			return (bool)GetValue(IsActiveProperty);
		}
		set
		{
			SetValue(IsActiveProperty, value);
		}
	}

	public static DependencyProperty IsIndeterminateProperty { get; } = DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ProgressRing), new FrameworkPropertyMetadata(true, OnIsIndeterminatePropertyChanged));


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

	public double Value
	{
		get
		{
			return (double)GetValue(ValueProperty);
		}
		set
		{
			SetValue(ValueProperty, value);
		}
	}

	public static DependencyProperty ValueProperty { get; } = DependencyProperty.Register("Value", typeof(double), typeof(ProgressRing), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ProgressRing)?.OnValuePropertyChanged(e);
	}));


	public double Maximum
	{
		get
		{
			return (double)GetValue(MaximumProperty);
		}
		set
		{
			SetValue(MaximumProperty, value);
		}
	}

	public static DependencyProperty MaximumProperty { get; } = DependencyProperty.Register("Maximum", typeof(double), typeof(ProgressRing), new FrameworkPropertyMetadata(100.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ProgressRing)?.OnMaximumPropertyChanged(e);
	}));


	public double Minimum
	{
		get
		{
			return (double)GetValue(MinimumProperty);
		}
		set
		{
			SetValue(MinimumProperty, value);
		}
	}

	public static DependencyProperty MinimumProperty { get; } = DependencyProperty.Register("Minimum", typeof(double), typeof(ProgressRing), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ProgressRing)?.OnMinimumPropertyChanged(e);
	}));


	public IAnimatedVisualSource DeterminateSource
	{
		get
		{
			return (IAnimatedVisualSource)GetValue(DeterminateSourceProperty);
		}
		set
		{
			SetValue(DeterminateSourceProperty, value);
		}
	}

	public IAnimatedVisualSource IndeterminateSource
	{
		get
		{
			return (IAnimatedVisualSource)GetValue(IndeterminateSourceProperty);
		}
		set
		{
			SetValue(IndeterminateSourceProperty, value);
		}
	}

	public ProgressRing()
	{
		base.DefaultStyleKey = typeof(ProgressRing);
		ApiExtensibility.CreateInstance<ILottieVisualSourceProvider>(this, out _lottieProvider);
		if (_lottieProvider == null)
		{
			this.Log().Error("ProgressRing control needs the Uno.UI.Lottie package to run properly.");
		}
		RegisterPropertyChangedCallback(Control.ForegroundProperty, OnForegroundPropertyChanged);
		RegisterPropertyChangedCallback(FrameworkElement.BackgroundProperty, OnBackgroundPropertyChanged);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ProgressRingAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		_player = GetTemplateChild("LottiePlayer") as AnimatedVisualPlayer;
		_layoutRoot = GetTemplateChild("LayoutRoot") as Panel;
		SetAnimatedVisualPlayerSource();
		UpdateLottieProgress();
		ChangeVisualState();
		SetLottieForegroundColor();
		SetLottieBackgroundColor();
	}

	private static void OnIsIndeterminatePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		(dependencyObject as ProgressRing)?.ChangeVisualState();
	}

	private void OnForegroundPropertyChanged(DependencyObject sender, DependencyProperty dp)
	{
		SetLottieForegroundColor();
	}

	private void OnBackgroundPropertyChanged(DependencyObject sender, DependencyProperty dp)
	{
		SetLottieBackgroundColor();
	}

	private void SetLottieForegroundColor()
	{
		if (_player?.Source is IThemableAnimatedVisualSource themableAnimatedVisualSource && Brush.TryGetColorWithOpacity(base.Foreground, out var color))
		{
			themableAnimatedVisualSource.SetColorThemeProperty("Foreground", color);
		}
	}

	private void SetLottieBackgroundColor()
	{
		if (_player?.Source is IThemableAnimatedVisualSource themableAnimatedVisualSource && Brush.TryGetColorWithOpacity(base.Background, out var color))
		{
			themableAnimatedVisualSource.SetColorThemeProperty("Background", color);
		}
	}

	private static void OnIsActivePropertyChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		(dependencyobject as ProgressRing)?.ChangeVisualState();
	}

	private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		CoerceValue();
		if (!IsIndeterminate)
		{
			UpdateLottieProgress();
		}
	}

	private void OnMaximumPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		CoerceMinimum();
		CoerceValue();
		if (!IsIndeterminate)
		{
			UpdateLottieProgress();
		}
	}

	private void OnMinimumPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		CoerceMaximum();
		CoerceValue();
		if (!IsIndeterminate)
		{
			UpdateLottieProgress();
		}
	}

	private void OnDeterminateSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		SetAnimatedVisualPlayerSource(force: true);
	}

	private void OnIndeterminateSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		SetAnimatedVisualPlayerSource(force: true);
	}

	private void SetAnimatedVisualPlayerSource(bool force = false)
	{
		if (_lottieProvider != null && _player != null)
		{
			if (IsIndeterminate)
			{
				if (_loadedAsset == LoadedAsset.Indeterminate && !force)
				{
					return;
				}
				_loadedAsset = LoadedAsset.Indeterminate;
				IAnimatedVisualSource indeterminateSource = IndeterminateSource;
				if (indeterminateSource == null)
				{
					_currentSourceUri = FeatureConfiguration.ProgressRing.ProgressRingAsset;
					IThemableAnimatedVisualSource source = _lottieProvider!.CreateTheamableFromLottieAsset(_currentSourceUri);
					_player!.Source = source;
				}
				else
				{
					AnimatedVisualPlayer? player = _player;
					IAnimatedVisualSource source2;
					if (!_lottieProvider!.TryCreateThemableFromAnimatedVisualSource(indeterminateSource, out var themableAnimatedVisualSource))
					{
						source2 = indeterminateSource;
					}
					else
					{
						IAnimatedVisualSource animatedVisualSource = themableAnimatedVisualSource;
						source2 = animatedVisualSource;
					}
					player!.Source = source2;
				}
			}
			else
			{
				if (_loadedAsset == LoadedAsset.Determinate && !force)
				{
					return;
				}
				_loadedAsset = LoadedAsset.Determinate;
				IAnimatedVisualSource determinateSource = DeterminateSource;
				if (determinateSource == null)
				{
					_currentSourceUri = FeatureConfiguration.ProgressRing.DeterminateProgressRingAsset;
					IThemableAnimatedVisualSource source3 = _lottieProvider!.CreateTheamableFromLottieAsset(_currentSourceUri);
					_player!.Source = source3;
				}
				else
				{
					AnimatedVisualPlayer? player2 = _player;
					IAnimatedVisualSource source4;
					if (!_lottieProvider!.TryCreateThemableFromAnimatedVisualSource(determinateSource, out var themableAnimatedVisualSource2))
					{
						source4 = determinateSource;
					}
					else
					{
						IAnimatedVisualSource animatedVisualSource = themableAnimatedVisualSource2;
						source4 = animatedVisualSource;
					}
					player2!.Source = source4;
				}
			}
			SetLottieForegroundColor();
			SetLottieBackgroundColor();
		}
		else if (_player != null && _layoutRoot != null)
		{
			TextBlock item = new TextBlock
			{
				Text = "⚠\ufe0f Uno.UI.Lottie missing ⚠\ufe0f",
				Foreground = SolidColorBrushHelper.Red
			};
			_layoutRoot!.Children.Add(item);
		}
	}

	private void ChangeVisualState()
	{
		if (IsActive)
		{
			if (IsIndeterminate)
			{
				VisualStateManager.GoToState(this, "Active", useTransitions: true);
				SetAnimatedVisualPlayerSource();
				Task task = _player?.PlayAsync(0.0, 1.0, looped: true);
			}
			else
			{
				VisualStateManager.GoToState(this, "DeterminateActive", useTransitions: true);
				SetAnimatedVisualPlayerSource();
				UpdateLottieProgress();
			}
		}
		else
		{
			VisualStateManager.GoToState(this, "Inactive", useTransitions: true);
			_player?.Stop();
		}
	}

	private void UpdateLottieProgress()
	{
		if (_player != null)
		{
			double value = Value;
			double minimum = Minimum;
			double num = Maximum - minimum;
			double num2 = (_oldValue - minimum) / num;
			double num3 = (value - minimum) / num;
			if (num2 < num3)
			{
				Task task = _player!.PlayAsync(num2, num3, looped: false);
			}
			else
			{
				_player!.SetProgress(num3);
			}
			_oldValue = value;
		}
	}

	private void CoerceMinimum()
	{
		double maximum = Maximum;
		if (Minimum > maximum)
		{
			Minimum = maximum;
		}
	}

	private void CoerceMaximum()
	{
		double minimum = Minimum;
		if (Maximum < minimum)
		{
			Maximum = minimum;
		}
	}

	private void CoerceValue()
	{
		double value = Value;
		if (!double.IsNaN(value) && !IsInBounds(value))
		{
			double maximum = Maximum;
			if (value > maximum)
			{
				Value = maximum;
			}
			else
			{
				Value = Minimum;
			}
		}
	}

	private bool IsInBounds(double value)
	{
		if (value >= Minimum)
		{
			return value <= Maximum;
		}
		return false;
	}
}

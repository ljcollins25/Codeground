using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Core;

namespace Windows.UI.Xaml;

public class AdaptiveTrigger : StateTriggerBase
{
	private readonly SerialDisposable _sizeChangedSubscription = new SerialDisposable();

	public double MinWindowHeight
	{
		get
		{
			return (double)GetValue(MinWindowHeightProperty);
		}
		set
		{
			SetValue(MinWindowHeightProperty, value);
		}
	}

	public static DependencyProperty MinWindowHeightProperty { get; } = DependencyProperty.Register("MinWindowHeight", typeof(double), typeof(AdaptiveTrigger), new FrameworkPropertyMetadata(-1.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((AdaptiveTrigger)s)?.OnMinWindowHeightChanged(e);
	}));


	public double MinWindowWidth
	{
		get
		{
			return (double)GetValue(MinWindowWidthProperty);
		}
		set
		{
			SetValue(MinWindowWidthProperty, value);
		}
	}

	public static DependencyProperty MinWindowWidthProperty { get; } = DependencyProperty.Register("MinWindowWidthProperty", typeof(double), typeof(AdaptiveTrigger), new FrameworkPropertyMetadata(-1.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((AdaptiveTrigger)s)?.OnMinWindowWidthChanged(e);
	}));


	public AdaptiveTrigger()
	{
		UpdateState();
	}

	private void OnCurrentWindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
	{
		UpdateState();
	}

	private void UpdateState()
	{
		Rect bounds = Window.Current.Bounds;
		double width = bounds.Width;
		double height = bounds.Height;
		double minWindowWidth = MinWindowWidth;
		double minWindowHeight = MinWindowHeight;
		bool flag = width >= minWindowWidth && height >= minWindowHeight;
		if (flag && minWindowWidth >= 0.0)
		{
			SetActivePrecedence(StateTriggerPrecedence.MinWidthTrigger);
		}
		else if (flag)
		{
			SetActivePrecedence(StateTriggerPrecedence.MinHeightTrigger);
		}
		else
		{
			SetActivePrecedence(StateTriggerPrecedence.Inactive);
		}
	}

	private void OnMinWindowHeightChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateState();
	}

	private void OnMinWindowWidthChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateState();
	}

	internal override void OnOwnerChanged()
	{
		base.OnOwnerChanged();
		_sizeChangedSubscription.Disposable = null;
		if (base.Owner != null)
		{
			_sizeChangedSubscription.Disposable = Window.Current.RegisterSizeChangedEvent(OnCurrentWindowSizeChanged);
		}
	}
}

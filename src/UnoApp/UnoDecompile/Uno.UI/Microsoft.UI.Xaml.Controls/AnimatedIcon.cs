using System;
using System.Collections.Generic;
using System.Numerics;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class AnimatedIcon : IconElement
{
	private const string s_progressPropertyName = "Progress";

	private const string s_foregroundPropertyName = "Foreground";

	private const string s_transitionInfix = "To";

	private const string s_transitionStartSuffix = "_Start";

	private const string s_transitionEndSuffix = "_End";

	private IAnimatedVisual m_animatedVisual;

	private Panel m_rootPanel;

	private ScaleTransform m_scaleTransform;

	private string m_currentState = "";

	private string m_previousState = "";

	private Queue<string> m_queuedStates = new Queue<string>();

	private int m_queueLength = 2;

	private string m_pendingState = "";

	private string m_lastAnimationSegment = "";

	private string m_lastAnimationSegmentStart = "";

	private string m_lastAnimationSegmentEnd = "";

	private bool m_isPlaying;

	private bool m_canDisplayPrimaryContent = true;

	private float m_previousSegmentLength = 1f;

	private float m_durationMultiplier = 1f;

	private float m_speedUpMultiplier = 7f;

	private bool m_isSpeedUp;

	private CompositionPropertySet m_progressPropertySet;

	private CompositionScopedBatch m_batch;

	private SerialDisposable m_batchCompletedRevoker = new SerialDisposable();

	private SerialDisposable m_ancestorStatePropertyChangedRevoker = new SerialDisposable();

	private SerialDisposable m_layoutUpdatedRevoker = new SerialDisposable();

	private SerialDisposable m_foregroundColorPropertyChangedRevoker = new SerialDisposable();

	private AnimatedIconAnimationQueueBehavior m_queueBehavior = AnimatedIconAnimationQueueBehavior.QueueOne;

	private bool _initialized;

	private bool _applyTemplateCalled;

	public IconSource FallbackIconSource
	{
		get
		{
			return (IconSource)GetValue(FallbackIconSourceProperty);
		}
		set
		{
			SetValue(FallbackIconSourceProperty, value);
		}
	}

	public static DependencyProperty FallbackIconSourceProperty { get; } = DependencyProperty.Register("FallbackIconSource", typeof(IconSource), typeof(AnimatedIcon), new FrameworkPropertyMetadata(null, OnFallbackIconSourcePropertyChanged));


	public bool MirroredWhenRightToLeft
	{
		get
		{
			return (bool)GetValue(MirroredWhenRightToLeftProperty);
		}
		set
		{
			SetValue(MirroredWhenRightToLeftProperty, value);
		}
	}

	public static DependencyProperty MirroredWhenRightToLeftProperty { get; } = DependencyProperty.Register("MirroredWhenRightToLeft", typeof(bool), typeof(AnimatedIcon), new FrameworkPropertyMetadata(false, OnMirroredWhenRightToLeftPropertyChanged));


	public IAnimatedVisualSource2 Source
	{
		get
		{
			return (IAnimatedVisualSource2)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(IAnimatedVisualSource2), typeof(AnimatedIcon), new FrameworkPropertyMetadata(null, OnSourcePropertyChanged));


	public static DependencyProperty StateProperty { get; } = DependencyProperty.RegisterAttached("State", typeof(string), typeof(AnimatedIcon), new FrameworkPropertyMetadata(null, OnAnimatedIconStatePropertyChanged));


	public AnimatedIcon()
	{
		m_progressPropertySet = new CompositionPropertySet(null);
		base.Loaded += OnLoaded;
		RegisterPropertyChangedCallback(IconElement.ForegroundProperty, OnForegroundPropertyChanged);
		RegisterPropertyChangedCallback(FrameworkElement.FlowDirectionProperty, OnFlowDirectionPropertyChanged);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		ConstructAndInsertVisual();
		Panel panel = (m_rootPanel = VisualTreeHelper.GetChild(this, 0) as Panel);
		m_currentState = GetState(this);
		if (panel == null)
		{
			return;
		}
		if (panel.Children.Count > 0)
		{
			UIElement uIElement = panel.Children[0];
			if (uIElement != null)
			{
				uIElement.Visibility = Visibility.Collapsed;
			}
		}
		IAnimatedVisual animatedVisual = m_animatedVisual;
		if (animatedVisual != null)
		{
			ElementCompositionPreview.SetElementChildVisual(panel, animatedVisual.RootVisual);
		}
		TrySetForegroundProperty();
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		EnsureInitialized();
		DependencyProperty property = StateProperty;
		var (ancestorWithState, value) = GetAncestorWithState();
		if (string.IsNullOrEmpty((string)GetValue(property)))
		{
			SetValue(property, value);
		}
		if (ancestorWithState != null)
		{
			m_ancestorStatePropertyChangedRevoker.Disposable = null;
			long token = ancestorWithState.RegisterPropertyChangedCallback(property, OnAncestorAnimatedIconStatePropertyChanged);
			m_ancestorStatePropertyChangedRevoker.Disposable = Disposable.Create(delegate
			{
				ancestorWithState.UnregisterPropertyChangedCallback(property, token);
			});
		}
		OnFallbackIconSourcePropertyChanged(null);
		(DependencyObject, string) GetAncestorWithState()
		{
			for (DependencyObject parent = VisualTreeHelper.GetParent(this); parent != null; parent = VisualTreeHelper.GetParent(parent))
			{
				object value2 = parent.GetValue(property);
				if (!string.IsNullOrEmpty((string)value2))
				{
					return (parent, (string)value2);
				}
			}
			return (null, string.Empty);
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		IAnimatedVisual animatedVisual = m_animatedVisual;
		if (animatedVisual != null)
		{
			Vector2 size = animatedVisual.Size;
			if (size != Vector2.Zero)
			{
				double num = ((availableSize.Width == double.PositiveInfinity) ? double.PositiveInfinity : (availableSize.Width / (double)size.X));
				double num2 = ((availableSize.Height == double.PositiveInfinity) ? double.PositiveInfinity : (availableSize.Height / (double)size.Y));
				if (num == double.PositiveInfinity && num2 == double.PositiveInfinity)
				{
					return new Size(size.X, size.Y);
				}
				if (num == double.PositiveInfinity)
				{
					return new Size((double)size.X * num2, availableSize.Height);
				}
				if (num2 == double.PositiveInfinity)
				{
					return new Size(availableSize.Width, (double)size.Y * num);
				}
				if (!(num2 > num))
				{
					return new Size((double)size.X * num2, availableSize.Height);
				}
				return new Size(availableSize.Width, (double)size.Y * num);
			}
			return new Size(size.X, size.Y);
		}
		return base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		IAnimatedVisual animatedVisual = m_animatedVisual;
		if (animatedVisual != null)
		{
			Vector2 size = animatedVisual.Size;
			Vector2 vector = GetScale(finalSize, size);
			Vector2 size2 = new Vector2((float)Math.Min(finalSize.Width / (double)vector.X, size.X), (float)Math.Min(finalSize.Height / (double)vector.Y, size.Y));
			Vector2 value = new Vector2((float)(finalSize.Width - (double)(size * vector).X) / 2f, (float)(finalSize.Height - (double)(size * vector).Y) / 2f);
			Visual rootVisual = animatedVisual.RootVisual;
			rootVisual.Offset = new Vector3(value, 0f);
			rootVisual.Size = size2;
			rootVisual.Scale = new Vector3(vector, 1f);
			return finalSize;
		}
		return base.ArrangeOverride(finalSize);
		static Vector2 GetScale(Size finalSize, Vector2 visualSize)
		{
			double num = finalSize.Width / (double)visualSize.X;
			double num2 = finalSize.Height / (double)visualSize.Y;
			if (num < num2)
			{
				num2 = num;
			}
			else
			{
				num = num2;
			}
			return new Vector2((float)num, (float)num2);
		}
	}

	private static void OnAnimatedIconStatePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is AnimatedIcon animatedIcon)
		{
			animatedIcon.OnStatePropertyChanged();
		}
	}

	private void OnAncestorAnimatedIconStatePropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		SetValue(StateProperty, sender.GetValue(args));
	}

	private void OnStatePropertyChanged()
	{
		m_pendingState = (string)GetValue(StateProperty);
		m_layoutUpdatedRevoker.Disposable = null;
		base.LayoutUpdated += OnLayoutUpdatedAfterStateChanged;
		m_layoutUpdatedRevoker.Disposable = Disposable.Create(delegate
		{
			base.LayoutUpdated -= OnLayoutUpdatedAfterStateChanged;
		});
		SharedHelpers.QueueCallbackForCompositionRendering(delegate
		{
			InvalidateArrange();
		});
	}

	private void OnLayoutUpdatedAfterStateChanged(object sender, object args)
	{
		m_layoutUpdatedRevoker.Disposable = null;
		switch (m_queueBehavior)
		{
		case AnimatedIconAnimationQueueBehavior.Cut:
			TransitionAndUpdateStates(m_currentState, m_pendingState);
			break;
		case AnimatedIconAnimationQueueBehavior.QueueOne:
			if (m_isPlaying)
			{
				if (m_queuedStates.Count >= m_queueLength)
				{
					TransitionAndUpdateStates(m_currentState, m_queuedStates.Peek());
				}
				m_queuedStates.Enqueue(m_pendingState);
			}
			else
			{
				TransitionAndUpdateStates(m_currentState, m_pendingState);
			}
			break;
		case AnimatedIconAnimationQueueBehavior.SpeedUpQueueOne:
			if (m_isPlaying)
			{
				if (m_queuedStates.Count >= m_queueLength)
				{
					if (m_batch != null)
					{
						m_batchCompletedRevoker.Disposable = null;
					}
					TransitionAndUpdateStates(m_currentState, m_queuedStates.Peek(), m_speedUpMultiplier);
					m_queuedStates.Enqueue(m_pendingState);
					break;
				}
				m_queuedStates.Enqueue(m_pendingState);
				if (!m_isSpeedUp)
				{
					if (m_batch != null)
					{
						m_batchCompletedRevoker.Disposable = null;
					}
					m_isSpeedUp = true;
					IReadOnlyDictionary<string, double> markers = Source.Markers;
					string key = StringUtil.FormatString("%1!s!%2!s!%3!s!%4!s!", m_previousState, "To", m_currentState, "_End");
					if (markers.ContainsKey(key))
					{
						PlaySegment(float.NaN, (float)markers[key], null, m_speedUpMultiplier);
					}
				}
			}
			else
			{
				TransitionAndUpdateStates(m_currentState, m_pendingState);
			}
			break;
		}
		m_pendingState = "";
	}

	private void TransitionAndUpdateStates(string fromState, string toState, float playbackMultiplier = 1f)
	{
		bool cleanedUpFlag = false;
		Action action = delegate
		{
			if (!cleanedUpFlag)
			{
				m_previousState = fromState;
				m_currentState = toState;
				if (m_queuedStates.Count > 0)
				{
					m_queuedStates.Dequeue();
				}
			}
		};
		TransitionStates(fromState, toState, action, playbackMultiplier);
		action();
	}

	private void TransitionStates(string fromState, string toState, Action cleanupAction, float playbackMultiplier = 1f)
	{
		IAnimatedVisualSource2 source = Source;
		if (source == null)
		{
			return;
		}
		IReadOnlyDictionary<string, double> markers = source.Markers;
		if (markers == null)
		{
			return;
		}
		string text = StringUtil.FormatString("%1!s!%2!s!%3!s!", fromState, "To", toState);
		string text2 = StringUtil.FormatString("%1!s!%2!s!", text, "_Start");
		string text3 = StringUtil.FormatString("%1!s!%2!s!", text, "_End");
		bool flag = markers.ContainsKey(text2);
		bool flag2 = markers.ContainsKey(text3);
		if (flag && flag2)
		{
			float from = (float)markers[text2];
			float to = (float)markers[text3];
			PlaySegment(from, to, cleanupAction, playbackMultiplier);
			m_lastAnimationSegmentStart = text2;
			m_lastAnimationSegmentEnd = text3;
		}
		else if (flag2)
		{
			float value = (float)markers[text3];
			m_progressPropertySet.InsertScalar("Progress", value);
			m_lastAnimationSegmentStart = "";
			m_lastAnimationSegmentEnd = text3;
		}
		else if (flag)
		{
			float value2 = (float)markers[text2];
			m_progressPropertySet.InsertScalar("Progress", value2);
			m_lastAnimationSegmentStart = text2;
			m_lastAnimationSegmentEnd = "";
		}
		else if (markers.ContainsKey(text))
		{
			float value3 = (float)markers[text];
			m_progressPropertySet.InsertScalar("Progress", value3);
			m_lastAnimationSegmentStart = "";
			m_lastAnimationSegmentEnd = text;
		}
		else if (markers.ContainsKey(toState))
		{
			float value4 = (float)markers[toState];
			m_progressPropertySet.InsertScalar("Progress", value4);
			m_lastAnimationSegmentStart = "";
			m_lastAnimationSegmentEnd = toState;
		}
		else
		{
			var (flag3, value5) = FindValue();
			if (flag3)
			{
				m_progressPropertySet.InsertScalar("Progress", value5);
			}
			else
			{
				string strEnd = null;
				float to2 = Wcstof(toState, ref strEnd);
				if (strEnd == toState)
				{
					PlaySegment(float.NaN, to2, cleanupAction, playbackMultiplier);
					m_lastAnimationSegmentStart = "";
					m_lastAnimationSegmentEnd = toState;
				}
				else
				{
					m_progressPropertySet.InsertScalar("Progress", 0f);
					m_lastAnimationSegmentStart = "";
					m_lastAnimationSegmentEnd = "0.0";
				}
			}
		}
		m_lastAnimationSegment = text;
		AnimatedIconTestHooks.NotifyLastAnimationSegmentChanged(this);
		(bool found, float value) FindValue()
		{
			string value6 = StringUtil.FormatString("%1!s!%2!s!%3!s!", "To", toState, "_End");
			foreach (KeyValuePair<string, double> item in markers)
			{
				string key = item.Key;
				if (key.IndexOf(value6) > -1)
				{
					m_lastAnimationSegmentStart = "";
					m_lastAnimationSegmentEnd = item.Key;
					return (true, (float)item.Value);
				}
			}
			return (false, 0f);
		}
	}

	private float Wcstof(string input, ref string strEnd)
	{
		for (int num = input.Length; num > 0; num--)
		{
			string s = input.Substring(0, num);
			if (float.TryParse(s, out var result))
			{
				if (input.Length - num == 0)
				{
					strEnd = null;
				}
				else
				{
					strEnd = input.Substring(num, input.Length - num);
				}
				return result;
			}
		}
		strEnd = input;
		return 0f;
	}

	private void PlaySegment(float from, float to, Action cleanupAction, float playbackMultiplier = 1f)
	{
		float num = (m_previousSegmentLength = GetSegmentLength(from, to, m_previousSegmentLength));
		TimeSpan timeSpan = ((m_animatedVisual != null) ? TimeSpan.FromMilliseconds(m_animatedVisual.Duration.TotalMilliseconds * (double)num * (1.0 / (double)playbackMultiplier) * (double)m_durationMultiplier) : TimeSpan.Zero);
		if (timeSpan < TimeSpan.FromMilliseconds(20.0) || !SharedHelpers.IsAnimationsEnabled())
		{
			m_progressPropertySet.InsertScalar("Progress", to);
			OnAnimationCompleted(null, null);
			return;
		}
		Compositor compositor = m_progressPropertySet.Compositor;
		ScalarKeyFrameAnimation scalarKeyFrameAnimation = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation.Duration = timeSpan;
		LinearEasingFunction easingFunction = compositor.CreateLinearEasingFunction();
		if (!float.IsNaN(from))
		{
			scalarKeyFrameAnimation.InsertKeyFrame(0f, from);
		}
		scalarKeyFrameAnimation.InsertKeyFrame(1f, to, easingFunction);
		scalarKeyFrameAnimation.IterationBehavior = AnimationIterationBehavior.Count;
		scalarKeyFrameAnimation.IterationCount = 1;
		if (m_batch != null)
		{
			m_batchCompletedRevoker.Disposable = null;
		}
		m_batch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
		m_batchCompletedRevoker.Disposable = null;
		m_batch.Completed += new TypedEventHandler<object, CompositionBatchCompletedEventArgs>(OnAnimationCompleted);
		m_batchCompletedRevoker.Disposable = Disposable.Create(delegate
		{
			m_batch.Completed -= new TypedEventHandler<object, CompositionBatchCompletedEventArgs>(OnAnimationCompleted);
		});
		m_isPlaying = true;
		m_progressPropertySet.StartAnimation("Progress", scalarKeyFrameAnimation);
		cleanupAction?.Invoke();
		m_batch.End();
		static float GetSegmentLength(float from, float to, float previousSegmentLength)
		{
			if (float.IsNaN(from))
			{
				return previousSegmentLength;
			}
			return Math.Abs(to - from);
		}
	}

	private void OnSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (!ConstructAndInsertVisual())
		{
			SetRootPanelChildToFallbackIcon();
		}
	}

	private void UpdateMirrorTransform()
	{
		ScaleTransform scaleTransform = GetScaleTransform();
		scaleTransform.ScaleX = ((base.FlowDirection == FlowDirection.RightToLeft && !MirroredWhenRightToLeft && m_canDisplayPrimaryContent) ? (-1f) : 1f);
		ScaleTransform GetScaleTransform()
		{
			if (m_scaleTransform == null)
			{
				ScaleTransform scaleTransform2 = (ScaleTransform)(base.RenderTransform = new ScaleTransform());
				base.RenderTransformOrigin = new Point(0.5, 0.5);
				m_scaleTransform = scaleTransform2;
				return scaleTransform2;
			}
			return m_scaleTransform;
		}
	}

	private void OnMirroredWhenRightToLeftPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateMirrorTransform();
	}

	private bool ConstructAndInsertVisual()
	{
		Visual visual = GetVisual();
		Panel rootPanel = m_rootPanel;
		if (rootPanel != null)
		{
			ElementCompositionPreview.SetElementChildVisual(rootPanel, visual);
		}
		if (visual != null)
		{
			m_canDisplayPrimaryContent = true;
			Panel rootPanel2 = m_rootPanel;
			if (rootPanel2 != null && rootPanel2.Children.Count > 1)
			{
				rootPanel2.Children.RemoveAt(1);
			}
			visual.Properties.InsertScalar("Progress", 0f);
			Compositor compositor = visual.Compositor;
			string expression = StringUtil.FormatString("_.%1!s!", "Progress");
			ExpressionAnimation expressionAnimation = compositor.CreateExpressionAnimation(expression);
			expressionAnimation.SetReferenceParameter("_", m_progressPropertySet);
			visual.Properties.StartAnimation("Progress", expressionAnimation);
			return true;
		}
		m_canDisplayPrimaryContent = false;
		return false;
		Visual GetVisual()
		{
			IAnimatedVisualSource2 source = Source;
			if (source != null)
			{
				TrySetForegroundProperty(source);
				return (m_animatedVisual = null)?.RootVisual;
			}
			m_animatedVisual = null;
			return null;
		}
	}

	private void OnFallbackIconSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (!m_canDisplayPrimaryContent)
		{
			SetRootPanelChildToFallbackIcon();
		}
	}

	private void SetRootPanelChildToFallbackIcon()
	{
		IconSource fallbackIconSource = FallbackIconSource;
		if (fallbackIconSource == null)
		{
			return;
		}
		IconElement item = fallbackIconSource.CreateIconElement();
		Panel rootPanel = m_rootPanel;
		if (rootPanel != null)
		{
			if (rootPanel.Children.Count > 1)
			{
				rootPanel.Children.RemoveAt(1);
			}
			rootPanel.Children.Add(item);
		}
	}

	private void OnForegroundPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		m_foregroundColorPropertyChangedRevoker.Disposable = null;
		Brush foreground = base.Foreground;
		SolidColorBrush foregroundSolidColorBrush = foreground as SolidColorBrush;
		if ((object)foregroundSolidColorBrush != null)
		{
			long token = foregroundSolidColorBrush.RegisterPropertyChangedCallback(SolidColorBrush.ColorProperty, OnForegroundBrushColorPropertyChanged);
			m_foregroundColorPropertyChangedRevoker.Disposable = Disposable.Create(delegate
			{
				foregroundSolidColorBrush.UnregisterPropertyChangedCallback(SolidColorBrush.ColorProperty, token);
			});
			TrySetForegroundProperty(foregroundSolidColorBrush.Color);
		}
	}

	private void OnFlowDirectionPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		UpdateMirrorTransform();
	}

	private void OnForegroundBrushColorPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		TrySetForegroundProperty((Color)sender.GetValue(args));
	}

	private void TrySetForegroundProperty(IAnimatedVisualSource2 source = null)
	{
		if (base.Foreground is SolidColorBrush solidColorBrush)
		{
			TrySetForegroundProperty(solidColorBrush.Color, source);
		}
	}

	private void TrySetForegroundProperty(Color color, IAnimatedVisualSource2 source = null)
	{
		((source != null) ? source : Source)?.SetColorProperty("Foreground", color);
	}

	private void OnAnimationCompleted(object sender, CompositionBatchCompletedEventArgs args)
	{
		if (m_batch != null)
		{
			m_batchCompletedRevoker.Disposable = null;
		}
		m_isPlaying = false;
		switch (m_queueBehavior)
		{
		case AnimatedIconAnimationQueueBehavior.QueueOne:
			if (m_queuedStates.Count > 0)
			{
				TransitionAndUpdateStates(m_currentState, m_queuedStates.Peek());
			}
			break;
		case AnimatedIconAnimationQueueBehavior.SpeedUpQueueOne:
			if (m_queuedStates.Count > 0)
			{
				if (m_queuedStates.Count == 1)
				{
					TransitionAndUpdateStates(m_currentState, m_queuedStates.Peek());
				}
				else
				{
					TransitionAndUpdateStates(m_currentState, m_queuedStates.Peek(), m_isSpeedUp ? m_speedUpMultiplier : 1f);
				}
			}
			break;
		case AnimatedIconAnimationQueueBehavior.Cut:
			break;
		}
	}

	internal void SetAnimationQueueBehavior(AnimatedIconAnimationQueueBehavior behavior)
	{
		m_queueBehavior = behavior;
	}

	internal void SetDurationMultiplier(float multiplier)
	{
		m_durationMultiplier = multiplier;
	}

	internal void SetSpeedUpMultiplier(float multiplier)
	{
		m_speedUpMultiplier = multiplier;
	}

	internal void SetQueueLength(int length)
	{
		m_queueLength = length;
	}

	internal string GetLastAnimationSegment()
	{
		return m_lastAnimationSegment;
	}

	internal string GetLastAnimationSegmentStart()
	{
		return m_lastAnimationSegmentStart;
	}

	internal string GetLastAnimationSegmentEnd()
	{
		return m_lastAnimationSegmentEnd;
	}

	public static string GetState(DependencyObject obj)
	{
		return (string)obj.GetValue(StateProperty);
	}

	public static void SetState(DependencyObject obj, string value)
	{
		obj.SetValue(StateProperty, value);
	}

	private static void OnFallbackIconSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is AnimatedIcon animatedIcon)
		{
			animatedIcon.OnFallbackIconSourcePropertyChanged(args);
		}
	}

	private static void OnMirroredWhenRightToLeftPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is AnimatedIcon animatedIcon)
		{
			animatedIcon.OnMirroredWhenRightToLeftPropertyChanged(args);
		}
	}

	private static void OnSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is AnimatedIcon animatedIcon)
		{
			animatedIcon.OnSourcePropertyChanged(args);
		}
	}

	private void EnsureInitialized()
	{
		InitializeVisualTree();
		if (!_applyTemplateCalled)
		{
			OnApplyTemplate();
			_applyTemplateCalled = true;
		}
	}

	private void InitializeVisualTree()
	{
		if (!_initialized)
		{
			AddIconElementView(new Grid());
			_initialized = true;
		}
	}
}

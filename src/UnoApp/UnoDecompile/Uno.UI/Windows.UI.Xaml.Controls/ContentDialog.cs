using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Uno.Client;
using Uno.Disposables;
using Uno.Extensions;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class ContentDialog : ContentControl
{
	private enum PlacementMode
	{
		Undetermined,
		EntireControlInPopup,
		TransplantedRootInPopup,
		InPlace
	}

	internal readonly Popup _popup;

	private TaskCompletionSource<ContentDialogResult> _tcs;

	private readonly SerialDisposable _subscriptions = new SerialDisposable();

	private bool _hiding;

	private Border m_tpBackgroundElementPart;

	private Border m_tpButton1HostPart;

	private Border m_tpButton2HostPart;

	private ButtonBase m_tpCloseButtonPart;

	private Grid m_tpCommandSpacePart;

	private Border m_tpContainerPart;

	private Grid m_tpContentPanelPart;

	private ContentPresenter m_tpContentPart;

	private ScrollViewer m_tpContentScrollViewerPart;

	private Grid m_tpDialogSpacePart;

	private Grid m_tpLayoutRootPart;

	private ButtonBase m_tpPrimaryButtonPart;

	private ScaleTransform m_tpScaleTransformPart;

	private ButtonBase m_tpSecondaryButtonPart;

	private ContentControl m_tpTitlePart;

	private const double ContentDialog_SIP_Bottom_Margin = 12.0;

	private PlacementMode m_placementMode;

	private bool m_hideInProgress;

	private bool m_hasPreparedContent;

	private bool m_isShowing;

	private Storyboard? m_layoutAdjustmentsForInputPaneStoryboard;

	private double m_dialogMinHeight;

	public DataTemplate TitleTemplate
	{
		get
		{
			return (DataTemplate)GetValue(TitleTemplateProperty);
		}
		set
		{
			SetValue(TitleTemplateProperty, value);
		}
	}

	public object Title
	{
		get
		{
			return GetValue(TitleProperty);
		}
		set
		{
			SetValue(TitleProperty, value);
		}
	}

	public string SecondaryButtonText
	{
		get
		{
			return (string)GetValue(SecondaryButtonTextProperty);
		}
		set
		{
			SetValue(SecondaryButtonTextProperty, value);
		}
	}

	public object SecondaryButtonCommandParameter
	{
		get
		{
			return GetValue(SecondaryButtonCommandParameterProperty);
		}
		set
		{
			SetValue(SecondaryButtonCommandParameterProperty, value);
		}
	}

	public ICommand SecondaryButtonCommand
	{
		get
		{
			return (ICommand)GetValue(SecondaryButtonCommandProperty);
		}
		set
		{
			SetValue(SecondaryButtonCommandProperty, value);
		}
	}

	public string PrimaryButtonText
	{
		get
		{
			return (string)GetValue(PrimaryButtonTextProperty);
		}
		set
		{
			SetValue(PrimaryButtonTextProperty, value);
		}
	}

	public object PrimaryButtonCommandParameter
	{
		get
		{
			return GetValue(PrimaryButtonCommandParameterProperty);
		}
		set
		{
			SetValue(PrimaryButtonCommandParameterProperty, value);
		}
	}

	public ICommand PrimaryButtonCommand
	{
		get
		{
			return (ICommand)GetValue(PrimaryButtonCommandProperty);
		}
		set
		{
			SetValue(PrimaryButtonCommandProperty, value);
		}
	}

	public bool IsSecondaryButtonEnabled
	{
		get
		{
			return (bool)GetValue(IsSecondaryButtonEnabledProperty);
		}
		set
		{
			SetValue(IsSecondaryButtonEnabledProperty, value);
		}
	}

	public bool IsPrimaryButtonEnabled
	{
		get
		{
			return (bool)GetValue(IsPrimaryButtonEnabledProperty);
		}
		set
		{
			SetValue(IsPrimaryButtonEnabledProperty, value);
		}
	}

	public bool FullSizeDesired
	{
		get
		{
			return (bool)GetValue(FullSizeDesiredProperty);
		}
		set
		{
			SetValue(FullSizeDesiredProperty, value);
		}
	}

	public Style SecondaryButtonStyle
	{
		get
		{
			return (Style)GetValue(SecondaryButtonStyleProperty);
		}
		set
		{
			SetValue(SecondaryButtonStyleProperty, value);
		}
	}

	public Style PrimaryButtonStyle
	{
		get
		{
			return (Style)GetValue(PrimaryButtonStyleProperty);
		}
		set
		{
			SetValue(PrimaryButtonStyleProperty, value);
		}
	}

	public ContentDialogButton DefaultButton
	{
		get
		{
			return (ContentDialogButton)GetValue(DefaultButtonProperty);
		}
		set
		{
			SetValue(DefaultButtonProperty, value);
		}
	}

	public string CloseButtonText
	{
		get
		{
			return (string)GetValue(CloseButtonTextProperty);
		}
		set
		{
			SetValue(CloseButtonTextProperty, value);
		}
	}

	public Style CloseButtonStyle
	{
		get
		{
			return (Style)GetValue(CloseButtonStyleProperty);
		}
		set
		{
			SetValue(CloseButtonStyleProperty, value);
		}
	}

	public object CloseButtonCommandParameter
	{
		get
		{
			return GetValue(CloseButtonCommandParameterProperty);
		}
		set
		{
			SetValue(CloseButtonCommandParameterProperty, value);
		}
	}

	public ICommand CloseButtonCommand
	{
		get
		{
			return (ICommand)GetValue(CloseButtonCommandProperty);
		}
		set
		{
			SetValue(CloseButtonCommandProperty, value);
		}
	}

	public static DependencyProperty FullSizeDesiredProperty { get; } = DependencyProperty.Register("FullSizeDesired", typeof(bool), typeof(ContentDialog), new FrameworkPropertyMetadata(false, UpdateVisualState));


	public static DependencyProperty IsPrimaryButtonEnabledProperty { get; } = DependencyProperty.Register("IsPrimaryButtonEnabled", typeof(bool), typeof(ContentDialog), new FrameworkPropertyMetadata(true));


	public static DependencyProperty IsSecondaryButtonEnabledProperty { get; } = DependencyProperty.Register("IsSecondaryButtonEnabled", typeof(bool), typeof(ContentDialog), new FrameworkPropertyMetadata(true));


	public static DependencyProperty PrimaryButtonCommandParameterProperty { get; } = DependencyProperty.Register("PrimaryButtonCommandParameter", typeof(object), typeof(ContentDialog), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty PrimaryButtonCommandProperty { get; } = DependencyProperty.Register("PrimaryButtonCommand", typeof(ICommand), typeof(ContentDialog), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty PrimaryButtonTextProperty { get; } = DependencyProperty.Register("PrimaryButtonText", typeof(string), typeof(ContentDialog), new FrameworkPropertyMetadata("", UpdateVisualState));


	public static DependencyProperty SecondaryButtonCommandParameterProperty { get; } = DependencyProperty.Register("SecondaryButtonCommandParameter", typeof(object), typeof(ContentDialog), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SecondaryButtonCommandProperty { get; } = DependencyProperty.Register("SecondaryButtonCommand", typeof(ICommand), typeof(ContentDialog), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SecondaryButtonTextProperty { get; } = DependencyProperty.Register("SecondaryButtonText", typeof(string), typeof(ContentDialog), new FrameworkPropertyMetadata("", UpdateVisualState));


	public static DependencyProperty TitleProperty { get; } = DependencyProperty.Register("Title", typeof(object), typeof(ContentDialog), new FrameworkPropertyMetadata(null, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((ContentDialog)o).UpdateTitleSpaceVisibility();
	}));


	public static DependencyProperty TitleTemplateProperty { get; } = DependencyProperty.Register("TitleTemplate", typeof(DataTemplate), typeof(ContentDialog), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((ContentDialog)o).UpdateTitleSpaceVisibility();
	}));


	public static DependencyProperty CloseButtonCommandParameterProperty { get; } = DependencyProperty.Register("CloseButtonCommandParameter", typeof(object), typeof(ContentDialog), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty CloseButtonCommandProperty { get; } = DependencyProperty.Register("CloseButtonCommand", typeof(ICommand), typeof(ContentDialog), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty CloseButtonStyleProperty { get; } = DependencyProperty.Register("CloseButtonStyle", typeof(Style), typeof(ContentDialog), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty CloseButtonTextProperty { get; } = DependencyProperty.Register("CloseButtonText", typeof(string), typeof(ContentDialog), new FrameworkPropertyMetadata("", UpdateVisualState));


	public static DependencyProperty DefaultButtonProperty { get; } = DependencyProperty.Register("DefaultButton", typeof(ContentDialogButton), typeof(ContentDialog), new FrameworkPropertyMetadata(ContentDialogButton.None, UpdateVisualState));


	public static DependencyProperty PrimaryButtonStyleProperty { get; } = DependencyProperty.Register("PrimaryButtonStyle", typeof(Style), typeof(ContentDialog), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public static DependencyProperty SecondaryButtonStyleProperty { get; } = DependencyProperty.Register("SecondaryButtonStyle", typeof(Style), typeof(ContentDialog), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public event TypedEventHandler<ContentDialog, ContentDialogClosedEventArgs> Closed;

	public event TypedEventHandler<ContentDialog, ContentDialogClosingEventArgs> Closing;

	public event TypedEventHandler<ContentDialog, ContentDialogOpenedEventArgs> Opened;

	public event TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> PrimaryButtonClick;

	public event TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> SecondaryButtonClick;

	public event TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> CloseButtonClick;

	public ContentDialog()
	{
		_popup = new Popup
		{
			LightDismissOverlayMode = LightDismissOverlayMode.On
		};
		ResourceResolver.ApplyResource(_popup, Popup.LightDismissOverlayBackgroundProperty, "ContentDialogLightDismissOverlayBackground", isThemeResourceExtension: true, isHotReloadSupported: true);
		_popup.PopupPanel = new ContentDialogPopupPanel(this);
		ManagedWeakReference thisRef = ((IWeakReferenceProvider)this).WeakReference;
		_popup.Opened += delegate
		{
			if (thisRef.Target is ContentDialog contentDialog3)
			{
				contentDialog3.Opened?.Invoke(contentDialog3, new ContentDialogOpenedEventArgs());
				contentDialog3.UpdateVisualState();
			}
		};
		base.KeyDown += OnPopupKeyDown;
		InputPane forCurrentView = InputPane.GetForCurrentView();
		forCurrentView.Showing += delegate
		{
			if (thisRef.Target is ContentDialog contentDialog2)
			{
				contentDialog2.UpdateVisualState();
			}
		};
		forCurrentView.Hiding += delegate
		{
			if (thisRef.Target is ContentDialog contentDialog)
			{
				contentDialog.UpdateVisualState();
			}
		};
		base.Loaded += delegate
		{
			RegisterEvents();
		};
		base.Unloaded += delegate
		{
			UnregisterEvents();
		};
		base.DefaultStyleKey = typeof(ContentDialog);
	}

	private void OnPopupKeyDown(object sender, KeyRoutedEventArgs e)
	{
		switch (e.Key)
		{
		case VirtualKey.Enter:
			switch (DefaultButton)
			{
			case ContentDialogButton.Close:
				ProcessCloseButton();
				break;
			case ContentDialogButton.Primary:
				ProcessPrimaryButton();
				break;
			case ContentDialogButton.Secondary:
				ProcessSecondaryButton();
				break;
			case ContentDialogButton.None:
				break;
			}
			break;
		case VirtualKey.Escape:
			ProcessCloseButton();
			break;
		}
	}

	public void Hide()
	{
		if (!_hiding)
		{
			_hiding = true;
			Hide(ContentDialogResult.None);
		}
	}

	private bool Hide(ContentDialogResult result)
	{
		ContentDialogClosingEventArgs contentDialogClosingEventArgs = new ContentDialogClosingEventArgs(Complete, result);
		this.Closing?.Invoke(this, contentDialogClosingEventArgs);
		if (!contentDialogClosingEventArgs.IsDeferred)
		{
			Complete(contentDialogClosingEventArgs);
		}
		else
		{
			contentDialogClosingEventArgs.EventRaiseCompleted();
		}
		return !contentDialogClosingEventArgs.Cancel;
		void Complete(ContentDialogClosingEventArgs args)
		{
			if (!args.Cancel)
			{
				m_isShowing = false;
				_popup.IsOpen = false;
				_popup.Child = null;
				UpdateVisualState();
				this.Closed?.Invoke(this, new ContentDialogClosedEventArgs(result));
				_tcs.SetResult(result);
			}
			_hiding = false;
		}
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		GetTemplateParts();
		m_dialogMinHeight = ResourceResolver.ResolveTopLevelResourceDouble("ContentDialogMinHeight");
		if (m_placementMode == PlacementMode.EntireControlInPopup)
		{
			PrepareContent();
		}
	}

	private void GetTemplateParts()
	{
		m_tpBackgroundElementPart = GetTemplateChild("BackgroundElement") as Border;
		m_tpButton1HostPart = GetTemplateChild("Button1Host") as Border;
		m_tpButton2HostPart = GetTemplateChild("Button2Host") as Border;
		m_tpCloseButtonPart = GetTemplateChild("CloseButton") as ButtonBase;
		m_tpCommandSpacePart = GetTemplateChild("CommandSpace") as Grid;
		m_tpContainerPart = GetTemplateChild("Container") as Border;
		m_tpContentPanelPart = GetTemplateChild("ContentPanel") as Grid;
		m_tpContentPart = GetTemplateChild("Content") as ContentPresenter;
		m_tpContentScrollViewerPart = GetTemplateChild("ContentScrollViewer") as ScrollViewer;
		m_tpDialogSpacePart = GetTemplateChild("DialogSpace") as Grid;
		m_tpLayoutRootPart = GetTemplateChild("LayoutRoot") as Grid;
		m_tpPrimaryButtonPart = GetTemplateChild("PrimaryButton") as ButtonBase;
		m_tpScaleTransformPart = GetTemplateChild("ScaleTransform") as ScaleTransform;
		m_tpSecondaryButtonPart = GetTemplateChild("SecondaryButton") as ButtonBase;
		m_tpTitlePart = GetTemplateChild("Title") as ContentControl;
	}

	private bool HasValidAppliedTemplate()
	{
		return m_tpBackgroundElementPart != null;
	}

	public IAsyncOperation<ContentDialogResult> ShowAsync()
	{
		return AsyncOperation.FromTask(async delegate
		{
			if (_popup.IsOpen)
			{
				throw new InvalidOperationException("A ContentDialog is already opened.");
			}
			m_placementMode = PlacementMode.EntireControlInPopup;
			EnsureTemplate();
			if (HasValidAppliedTemplate())
			{
				PrepareContent();
			}
			_popup.Child = this;
			m_isShowing = true;
			_popup.IsOpen = true;
			_popup.IsLightDismissEnabled = false;
			_tcs = new TaskCompletionSource<ContentDialogResult>();
			return await _tcs.Task;
		});
	}

	public IAsyncOperation<ContentDialogResult> ShowAsync(ContentDialogPlacement placement)
	{
		return ShowAsync();
	}

	private void UnregisterEvents()
	{
		_subscriptions.Disposable = null;
	}

	private void RegisterEvents()
	{
		_subscriptions.Disposable = null;
		CompositeDisposable disposable = new CompositeDisposable();
		DependencyObject templateChild = GetTemplateChild("PrimaryButton");
		Button primaryButton = templateChild as Button;
		if (primaryButton != null)
		{
			primaryButton.Click += OnPrimaryButtonClicked;
			disposable.Add(delegate
			{
				primaryButton.Click -= OnPrimaryButtonClicked;
			});
		}
		templateChild = GetTemplateChild("SecondaryButton");
		Button secondaryButton = templateChild as Button;
		if (secondaryButton != null)
		{
			secondaryButton.Click += OnSecondaryButtonClicked;
			disposable.Add(delegate
			{
				secondaryButton.Click -= OnSecondaryButtonClicked;
			});
		}
		templateChild = GetTemplateChild("CloseButton");
		Button closeButton = templateChild as Button;
		if (closeButton != null)
		{
			closeButton.Click += OnCloseButtonClicked;
			disposable.Add(delegate
			{
				closeButton.Click -= OnCloseButtonClicked;
			});
		}
		_subscriptions.Disposable = disposable;
	}

	private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
	{
		ProcessCloseButton();
	}

	private void OnSecondaryButtonClicked(object sender, RoutedEventArgs e)
	{
		ProcessSecondaryButton();
	}

	private void OnPrimaryButtonClicked(object sender, RoutedEventArgs e)
	{
		ProcessPrimaryButton();
	}

	private void ProcessCloseButton()
	{
		if (!_hiding)
		{
			_hiding = true;
			ContentDialogButtonClickEventArgs contentDialogButtonClickEventArgs = new ContentDialogButtonClickEventArgs(Complete);
			this.CloseButtonClick?.Invoke(this, contentDialogButtonClickEventArgs);
			if (contentDialogButtonClickEventArgs.Deferral == null)
			{
				Complete(contentDialogButtonClickEventArgs);
			}
		}
		void Complete(ContentDialogButtonClickEventArgs a)
		{
			if (!a.Cancel)
			{
				CloseButtonCommand.ExecuteIfPossible(CloseButtonCommandParameter);
				Hide(ContentDialogResult.None);
			}
			else
			{
				_hiding = false;
			}
		}
	}

	private void ProcessSecondaryButton()
	{
		if (!_hiding)
		{
			_hiding = true;
			ContentDialogButtonClickEventArgs contentDialogButtonClickEventArgs = new ContentDialogButtonClickEventArgs(Complete);
			this.SecondaryButtonClick?.Invoke(this, contentDialogButtonClickEventArgs);
			if (contentDialogButtonClickEventArgs.Deferral == null)
			{
				Complete(contentDialogButtonClickEventArgs);
			}
		}
		void Complete(ContentDialogButtonClickEventArgs a)
		{
			if (!a.Cancel)
			{
				SecondaryButtonCommand.ExecuteIfPossible(SecondaryButtonCommandParameter);
				Hide(ContentDialogResult.Secondary);
			}
			else
			{
				_hiding = false;
			}
		}
	}

	private void ProcessPrimaryButton()
	{
		if (!_hiding)
		{
			_hiding = true;
			ContentDialogButtonClickEventArgs contentDialogButtonClickEventArgs = new ContentDialogButtonClickEventArgs(Complete);
			this.PrimaryButtonClick?.Invoke(this, contentDialogButtonClickEventArgs);
			if (contentDialogButtonClickEventArgs.Deferral == null)
			{
				Complete(contentDialogButtonClickEventArgs);
			}
		}
		void Complete(ContentDialogButtonClickEventArgs a)
		{
			if (!a.Cancel)
			{
				PrimaryButtonCommand.ExecuteIfPossible(PrimaryButtonCommandParameter);
				Hide(ContentDialogResult.Primary);
			}
			else
			{
				_hiding = false;
			}
		}
	}

	private static void UpdateVisualState(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs newValue)
	{
		(dependencyObject as ContentDialog).UpdateVisualState();
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		base.ChangeVisualState(useTransitions);
		bool fullSizeDesired = FullSizeDesired;
		string primaryButtonText = PrimaryButtonText;
		string secondaryButtonText = SecondaryButtonText;
		string closeButtonText = CloseButtonText;
		bool flag = !primaryButtonText.IsNullOrEmpty();
		bool flag2 = !secondaryButtonText.IsNullOrEmpty();
		bool flag3 = !closeButtonText.IsNullOrEmpty();
		string stateName = "NoneVisible";
		if (flag && flag2 && flag3)
		{
			stateName = "AllVisible";
		}
		else if (flag && flag2)
		{
			stateName = "PrimaryAndSecondaryVisible";
		}
		else if (flag && flag3)
		{
			stateName = "PrimaryAndCloseVisible";
		}
		else if (flag2 && flag3)
		{
			stateName = "SecondaryAndCloseVisible";
		}
		else if (flag)
		{
			stateName = "PrimaryVisible";
		}
		else if (flag2)
		{
			stateName = "SecondaryVisible";
		}
		else if (flag3)
		{
			stateName = "CloseVisible";
		}
		GoToState(useTransitions, stateName);
		string stateName2 = "NoDefaultButton";
		switch (DefaultButton)
		{
		case ContentDialogButton.Primary:
			stateName2 = "PrimaryAsDefaultButton";
			break;
		case ContentDialogButton.Secondary:
			stateName2 = "SecondaryAsDefaultButton";
			break;
		case ContentDialogButton.Close:
			stateName2 = "CloseAsDefaultButton";
			break;
		}
		GoToState(useTransitions, stateName2);
		if (m_placementMode == PlacementMode.InPlace)
		{
			GoToState(useTransitions: true, (m_isShowing && !m_hideInProgress) ? "DialogShowing" : "DialogHidden");
		}
		else if (m_placementMode != 0)
		{
			GoToState(useTransitions: false, "DialogShowingWithoutSmokeLayer");
		}
		GoToState(useTransitions, fullSizeDesired ? "FullDialogSizing" : "DefaultDialogSizing");
		GoToState(useTransitions, "NoBorder");
		AdjustVisualStateForInputPane();
	}

	private void ResetAndPrepareContent()
	{
	}

	private void PrepareContent()
	{
		if (!m_hasPreparedContent)
		{
			UpdateVisualState();
			UpdateTitleSpaceVisibility();
			if (m_placementMode != PlacementMode.InPlace)
			{
				SizeAndPositionContentInPopup();
			}
			m_hasPreparedContent = true;
		}
	}

	private void SizeAndPositionContentInPopup()
	{
		Popup popup = _popup;
		double num = 0.0;
		double num2 = 0.0;
		Rect bounds = Window.Current.Bounds;
		FlowDirection flowDirection = base.FlowDirection;
		FrameworkElement tpBackgroundElementPart = m_tpBackgroundElementPart;
		if (m_placementMode == PlacementMode.EntireControlInPopup)
		{
			base.Height = bounds.Height;
			base.Width = bounds.Width;
		}
		else if (m_tpLayoutRootPart != null)
		{
			m_tpLayoutRootPart.Height = bounds.Height;
			m_tpLayoutRootPart.Width = bounds.Width;
		}
		if (m_placementMode == PlacementMode.TransplantedRootInPopup)
		{
			GeneralTransform generalTransform = popup.TransformToVisual(null);
			Point point = generalTransform.TransformPoint(default(Point));
			num = ((flowDirection == FlowDirection.LeftToRight) ? (num - point.X) : ((num - point.X) * -1.0));
			num2 -= point.Y;
		}
		popup.HorizontalOffset = num;
		popup.VerticalOffset = num2;
	}

	private void UpdateTitleSpaceVisibility()
	{
		if (m_tpTitlePart != null)
		{
			bool flag = Title != null || TitleTemplate != null;
			m_tpTitlePart.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	private void AdjustVisualStateForInputPane()
	{
		Rect occludedRect = InputPane.GetForCurrentView().OccludedRect;
		if (m_isShowing && occludedRect.Height > 0.0)
		{
			Rect rect = getElementBounds(m_tpLayoutRootPart);
			Rect rect2 = getElementBounds(m_tpBackgroundElementPart);
			if (occludedRect.Y < rect2.Y + rect2.Height + 12.0)
			{
				ScrollBarVisibility contentVerticalScrollBarVisiblity = ScrollBarVisibility.Auto;
				bool setDialogVerticalAlignment = false;
				VerticalAlignment dialogVerticalAlignment = VerticalAlignment.Center;
				Thickness layoutRootPadding = new Thickness(0.0, 0.0, 0.0, rect.Height - Math.Max(occludedRect.Y - rect.Y, (float)m_dialogMinHeight) + 12.0);
				if (!FullSizeDesired)
				{
					dialogVerticalAlignment = VerticalAlignment.Bottom;
					setDialogVerticalAlignment = true;
				}
				Storyboard storyboard = CreateStoryboardForLayoutAdjustmentsForInputPane(layoutRootPadding, contentVerticalScrollBarVisiblity, setDialogVerticalAlignment, dialogVerticalAlignment);
				storyboard.Begin();
				storyboard.SkipToFill();
				m_layoutAdjustmentsForInputPaneStoryboard = storyboard;
			}
		}
		else if (m_layoutAdjustmentsForInputPaneStoryboard != null)
		{
			m_layoutAdjustmentsForInputPaneStoryboard!.Stop();
			m_layoutAdjustmentsForInputPaneStoryboard = null;
		}
		static Rect getElementBounds(FrameworkElement element)
		{
			GeneralTransform generalTransform = element.TransformToVisual(null);
			double actualWidth = element.ActualWidth;
			double actualHeight = element.ActualHeight;
			return generalTransform.TransformBounds(new Rect(0.0, 0.0, actualWidth, actualHeight));
		}
	}

	private Storyboard CreateStoryboardForLayoutAdjustmentsForInputPane(Thickness layoutRootPadding, ScrollBarVisibility contentVerticalScrollBarVisiblity, bool setDialogVerticalAlignment, VerticalAlignment dialogVerticalAlignment)
	{
		Storyboard storyboard = new Storyboard();
		TimelineCollection children = storyboard.Children;
		ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames = new ObjectAnimationUsingKeyFrames();
		Storyboard.SetTarget(objectAnimationUsingKeyFrames, m_tpBackgroundElementPart);
		Storyboard.SetTargetProperty(objectAnimationUsingKeyFrames, "Margin");
		ObjectKeyFrameCollection keyFrames = objectAnimationUsingKeyFrames.KeyFrames;
		DiscreteObjectKeyFrame discreteObjectKeyFrame = new DiscreteObjectKeyFrame();
		KeyTime keyTime2 = (discreteObjectKeyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero));
		discreteObjectKeyFrame.Value = layoutRootPadding;
		keyFrames.Add(discreteObjectKeyFrame);
		children.Add(objectAnimationUsingKeyFrames);
		ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames2 = new ObjectAnimationUsingKeyFrames();
		Storyboard.SetTarget(objectAnimationUsingKeyFrames2, m_tpContentScrollViewerPart);
		Storyboard.SetTargetProperty(objectAnimationUsingKeyFrames2, "VerticalScrollBarVisibility");
		ObjectKeyFrameCollection keyFrames2 = objectAnimationUsingKeyFrames2.KeyFrames;
		DiscreteObjectKeyFrame discreteObjectKeyFrame2 = new DiscreteObjectKeyFrame();
		KeyTime keyTime4 = (discreteObjectKeyFrame2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero));
		discreteObjectKeyFrame2.Value = contentVerticalScrollBarVisiblity;
		keyFrames2.Add(discreteObjectKeyFrame2);
		children.Add(objectAnimationUsingKeyFrames2);
		if (setDialogVerticalAlignment)
		{
			ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames3 = new ObjectAnimationUsingKeyFrames();
			Storyboard.SetTarget(objectAnimationUsingKeyFrames3, m_tpBackgroundElementPart);
			Storyboard.SetTargetProperty(objectAnimationUsingKeyFrames3, "VerticalAlignment");
			ObjectKeyFrameCollection keyFrames3 = objectAnimationUsingKeyFrames3.KeyFrames;
			DiscreteObjectKeyFrame discreteObjectKeyFrame3 = new DiscreteObjectKeyFrame();
			KeyTime keyTime6 = (discreteObjectKeyFrame3.KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero));
			discreteObjectKeyFrame3.Value = dialogVerticalAlignment;
			keyFrames3.Add(discreteObjectKeyFrame3);
			children.Add(objectAnimationUsingKeyFrames3);
		}
		return storyboard;
	}
}

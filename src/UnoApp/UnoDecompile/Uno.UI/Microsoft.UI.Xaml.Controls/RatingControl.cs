using System;
using Microsoft.UI.Xaml.Automation.Peers;
using Uno.UI.Helpers.WinUI;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Composition;
using Windows.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class RatingControl : Control
{
	private const float c_horizontalScaleAnimationCenterPoint = 0.5f;

	private const float c_verticalScaleAnimationCenterPoint = 0.8f;

	private readonly Thickness c_focusVisualMargin = new Thickness(-8.0, -7.0, -8.0, 0.0);

	private const int c_defaultRatingFontSizeForRendering = 32;

	private const int c_defaultItemSpacing = 8;

	private const float c_mouseOverScale = 0.8f;

	private const float c_touchOverScale = 1f;

	private const float c_noPointerOverMagicNumber = -100f;

	private const float c_defaultCaptionTopMargin = 22f;

	private const int c_noValueSetSentinel = -1;

	private UISettings _uiSettings;

	private TextBlock? m_captionTextBlock;

	private CompositionPropertySet? m_sharedPointerPropertySet;

	private StackPanel? m_backgroundStackPanel;

	private StackPanel? m_foregroundStackPanel;

	private bool m_isPointerOver;

	private bool m_isPointerDown;

	private double m_mousePercentage;

	private RatingInfoType m_infoType = RatingInfoType.Font;

	private double m_preEngagementValue;

	private bool m_disengagedWithA;

	private bool m_shouldDiscardValue = true;

	private long m_fontFamilyChangedToken;

	private DispatcherHelper? m_dispatcherHelper;

	public string Caption
	{
		get
		{
			return (string)GetValue(CaptionProperty);
		}
		set
		{
			SetValue(CaptionProperty, value);
		}
	}

	public static DependencyProperty CaptionProperty { get; } = DependencyProperty.Register("Caption", typeof(string), typeof(RatingControl), new FrameworkPropertyMetadata(string.Empty, OnPropertyChanged));


	public int InitialSetValue
	{
		get
		{
			return (int)GetValue(InitialSetValueProperty);
		}
		set
		{
			SetValue(InitialSetValueProperty, value);
		}
	}

	public static DependencyProperty InitialSetValueProperty { get; } = DependencyProperty.Register("InitialSetValue", typeof(int), typeof(RatingControl), new FrameworkPropertyMetadata(1, OnPropertyChanged));


	public bool IsClearEnabled
	{
		get
		{
			return (bool)GetValue(IsClearEnabledProperty);
		}
		set
		{
			SetValue(IsClearEnabledProperty, value);
		}
	}

	public static DependencyProperty IsClearEnabledProperty { get; } = DependencyProperty.Register("IsClearEnabled", typeof(bool), typeof(RatingControl), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public bool IsReadOnly
	{
		get
		{
			return (bool)GetValue(IsReadOnlyProperty);
		}
		set
		{
			SetValue(IsReadOnlyProperty, value);
		}
	}

	public static DependencyProperty IsReadOnlyProperty { get; } = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(RatingControl), new FrameworkPropertyMetadata(false, OnPropertyChanged));


	public RatingItemInfo ItemInfo
	{
		get
		{
			return (RatingItemInfo)GetValue(ItemInfoProperty);
		}
		set
		{
			SetValue(ItemInfoProperty, value);
		}
	}

	public static DependencyProperty ItemInfoProperty { get; } = DependencyProperty.Register("ItemInfo", typeof(RatingItemInfo), typeof(RatingControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public int MaxRating
	{
		get
		{
			return (int)GetValue(MaxRatingProperty);
		}
		set
		{
			SetValue(MaxRatingProperty, value);
		}
	}

	public static DependencyProperty MaxRatingProperty { get; } = DependencyProperty.Register("MaxRating", typeof(int), typeof(RatingControl), new FrameworkPropertyMetadata(5, OnPropertyChanged));


	public double PlaceholderValue
	{
		get
		{
			return (double)GetValue(PlaceholderValueProperty);
		}
		set
		{
			SetValue(PlaceholderValueProperty, value);
		}
	}

	public static DependencyProperty PlaceholderValueProperty { get; } = DependencyProperty.Register("PlaceholderValue", typeof(double), typeof(RatingControl), new FrameworkPropertyMetadata(-1.0, OnPropertyChanged));


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

	public static DependencyProperty ValueProperty { get; } = DependencyProperty.Register("Value", typeof(double), typeof(RatingControl), new FrameworkPropertyMetadata(-1.0, OnPropertyChanged));


	public event TypedEventHandler<RatingControl, object> ValueChanged;

	public RatingControl()
	{
		m_dispatcherHelper = new DispatcherHelper(this);
		base.DefaultStyleKey = typeof(RatingControl);
		base.Unloaded += RatingControl_Unloaded;
	}

	private void RatingControl_Unloaded(object sender, RoutedEventArgs e)
	{
		RecycleEvents(useSafeGet: true);
	}

	~RatingControl()
	{
	}

	private float RenderingRatingFontSize()
	{
		return (float)(32.0 * GetUISettings().TextScaleFactor);
	}

	private float ActualRatingFontSize()
	{
		return RenderingRatingFontSize() / 2f;
	}

	private double ItemSpacing()
	{
		double num = 16.0;
		return 8.0 - (GetUISettings().TextScaleFactor - 1.0) * num / 2.0;
	}

	private void UpdateCaptionMargins()
	{
		TextBlock captionTextBlock = m_captionTextBlock;
		if (captionTextBlock != null)
		{
			double textScaleFactor = GetUISettings().TextScaleFactor;
			Thickness margin = captionTextBlock.Margin;
			margin.Top = 22f - ActualRatingFontSize() * 0.8f;
			captionTextBlock.Margin(margin);
		}
	}

	protected override void OnApplyTemplate()
	{
		RecycleEvents();
		TextBlock textBlock = (TextBlock)GetTemplateChild("Caption");
		if (textBlock != null)
		{
			m_captionTextBlock = textBlock;
			textBlock.SizeChanged += OnCaptionSizeChanged;
			UpdateCaptionMargins();
		}
		StackPanel stackPanel = (StackPanel)GetTemplateChild("RatingBackgroundStackPanel");
		if (stackPanel != null)
		{
			m_backgroundStackPanel = stackPanel;
			stackPanel.PointerCanceled += OnPointerCancelledBackgroundStackPanel;
			stackPanel.PointerCaptureLost += OnPointerCaptureLostBackgroundStackPanel;
			stackPanel.PointerMoved += OnPointerMovedOverBackgroundStackPanel;
			stackPanel.PointerEntered += OnPointerEnteredBackgroundStackPanel;
			stackPanel.PointerExited += OnPointerExitedBackgroundStackPanel;
			stackPanel.PointerPressed += OnPointerPressedBackgroundStackPanel;
			stackPanel.PointerReleased += OnPointerReleasedBackgroundStackPanel;
		}
		m_foregroundStackPanel = (StackPanel)GetTemplateChild("RatingForegroundStackPanel");
		if (SharedHelpers.IsRS1OrHigher())
		{
			base.FocusEngaged += OnFocusEngaged;
			base.FocusDisengaged += OnFocusDisengaged;
			base.IsFocusEngagementEnabled = true;
			base.FocusVisualMargin = c_focusVisualMargin;
		}
		base.IsEnabledChanged += OnIsEnabledChanged;
		m_fontFamilyChangedToken = RegisterPropertyChangedCallback(Control.FontFamilyProperty, OnFontFamilyChanged);
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(this);
		Compositor compositor = elementVisual.Compositor;
		m_sharedPointerPropertySet = compositor.CreatePropertySet();
		m_sharedPointerPropertySet!.InsertScalar("starsScaleFocalPoint", -100f);
		m_sharedPointerPropertySet!.InsertScalar("pointerScalar", 0.8f);
		StampOutRatingItems();
		GetUISettings().TextScaleFactorChanged += OnTextScaleFactorChanged;
	}

	private double CoerceValueBetweenMinAndMax(double value)
	{
		if (value < 0.0)
		{
			value = -1.0;
		}
		else if (value <= 1.0)
		{
			value = 1.0;
		}
		else if (value > (double)MaxRating)
		{
			value = MaxRating;
		}
		return value;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new Microsoft.UI.Xaml.Automation.Peers.RatingControlAutomationPeer(this);
	}

	private void StampOutRatingItems()
	{
		if (m_backgroundStackPanel != null && m_foregroundStackPanel != null)
		{
			m_backgroundStackPanel!.Children.Clear();
			if (IsItemInfoPresentAndFontInfo())
			{
				PopulateStackPanelWithItems("BackgroundGlyphDefaultTemplate", m_backgroundStackPanel, RatingControlStates.Unset);
			}
			else if (IsItemInfoPresentAndImageInfo())
			{
				PopulateStackPanelWithItems("BackgroundImageDefaultTemplate", m_backgroundStackPanel, RatingControlStates.Unset);
			}
			m_foregroundStackPanel!.Children.Clear();
			if (IsItemInfoPresentAndFontInfo())
			{
				PopulateStackPanelWithItems("ForegroundGlyphDefaultTemplate", m_foregroundStackPanel, RatingControlStates.Set);
			}
			else if (IsItemInfoPresentAndImageInfo())
			{
				PopulateStackPanelWithItems("ForegroundImageDefaultTemplate", m_foregroundStackPanel, RatingControlStates.Set);
			}
			UpdateRatingItemsAppearance();
		}
	}

	private void ReRenderCaption()
	{
		TextBlock captionTextBlock = m_captionTextBlock;
		if (captionTextBlock != null)
		{
			ResetControlWidth();
		}
	}

	private void UpdateRatingItemsAppearance()
	{
		if (m_foregroundStackPanel == null)
		{
			return;
		}
		double placeholderValue = PlaceholderValue;
		double value = Value;
		double num = 0.0;
		if (m_isPointerOver)
		{
			num = Math.Ceiling(m_mousePercentage * (double)MaxRating);
			if (value == -1.0)
			{
				if (placeholderValue == -1.0)
				{
					VisualStateManager.GoToState(this, "PointerOverPlaceholder", useTransitions: false);
					CustomizeStackPanel(m_foregroundStackPanel, RatingControlStates.PointerOverPlaceholder);
				}
				else
				{
					VisualStateManager.GoToState(this, "PointerOverUnselected", useTransitions: false);
					CustomizeStackPanel(m_foregroundStackPanel, RatingControlStates.PointerOverPlaceholder);
				}
			}
			else
			{
				VisualStateManager.GoToState(this, "PointerOverSet", useTransitions: false);
				CustomizeStackPanel(m_foregroundStackPanel, RatingControlStates.PointerOverSet);
			}
		}
		else if (value > -1.0)
		{
			num = value;
			VisualStateManager.GoToState(this, "Set", useTransitions: false);
			CustomizeStackPanel(m_foregroundStackPanel, RatingControlStates.Set);
		}
		else if (placeholderValue > -1.0)
		{
			num = placeholderValue;
			VisualStateManager.GoToState(this, "Placeholder", useTransitions: false);
			CustomizeStackPanel(m_foregroundStackPanel, RatingControlStates.Placeholder);
		}
		if (!base.IsEnabled)
		{
			VisualStateManager.GoToState(this, "Disabled", useTransitions: false);
			CustomizeStackPanel(m_foregroundStackPanel, RatingControlStates.Disabled);
		}
		uint num2 = 0u;
		foreach (UIElement child in m_foregroundStackPanel!.Children)
		{
			float num3 = RenderingRatingFontSize();
			if ((double)(num2 + 1) > num)
			{
				num3 = ((!((double)num2 < num)) ? 0f : (num3 * (float)(num - Math.Floor(num))));
			}
			Rect rect = default(Rect);
			rect.X = 0.0;
			rect.Y = 0.0;
			rect.Height = RenderingRatingFontSize();
			rect.Width = num3;
			RectangleGeometry rectangleGeometry = new RectangleGeometry();
			rectangleGeometry.Rect = rect;
			child.Clip = rectangleGeometry;
			num2++;
		}
		ResetControlWidth();
	}

	private void ApplyScaleExpressionAnimation(UIElement uiElement, int starIndex)
	{
		ScaleTransform scaleTransform = (ScaleTransform)(uiElement.RenderTransform = new ScaleTransform
		{
			ScaleX = 0.5,
			ScaleY = 0.5
		});
		uiElement.RenderTransformOrigin = new Point(0.5, 0.5);
	}

	private void PopulateStackPanelWithItems(string templateName, StackPanel stackPanel, RatingControlStates state)
	{
		object obj = Application.Current.Resources.Lookup(templateName);
		DataTemplate dataTemplate = obj as DataTemplate;
		for (int i = 0; i < MaxRating; i++)
		{
			UIElement uIElement = dataTemplate.LoadContent();
			if (uIElement != null)
			{
				CustomizeRatingItem(uIElement, state);
				stackPanel.Children.Add(uIElement);
				ApplyScaleExpressionAnimation(uIElement, i);
			}
		}
	}

	private void CustomizeRatingItem(UIElement ui, RatingControlStates type)
	{
		if (IsItemInfoPresentAndFontInfo())
		{
			if (ui is TextBlock textBlock)
			{
				textBlock.FontFamily = base.FontFamily;
				textBlock.Text = GetAppropriateGlyph(type);
			}
			return;
		}
		if (IsItemInfoPresentAndImageInfo())
		{
			if (ui is Image image)
			{
				image.Source = GetAppropriateImageSource(type);
				image.Width = RenderingRatingFontSize();
				image.Height = RenderingRatingFontSize();
			}
			return;
		}
		throw new InvalidOperationException("ItemInfo property is null");
	}

	private void CustomizeStackPanel(StackPanel stackPanel, RatingControlStates state)
	{
		foreach (UIElement child in stackPanel.Children)
		{
			CustomizeRatingItem(child, state);
		}
	}

	private string GetAppropriateGlyph(RatingControlStates type)
	{
		if (!IsItemInfoPresentAndFontInfo())
		{
			throw new InvalidOperationException("Runtime error, tried to retrieve a glyph when the ItemInfo is not a RatingItemGlyphInfo");
		}
		RatingItemFontInfo ratingItemFontInfo = ItemInfo as RatingItemFontInfo;
		return type switch
		{
			RatingControlStates.Disabled => GetNextGlyphIfNull(ratingItemFontInfo.DisabledGlyph, RatingControlStates.Set), 
			RatingControlStates.PointerOverSet => GetNextGlyphIfNull(ratingItemFontInfo.PointerOverGlyph, RatingControlStates.Set), 
			RatingControlStates.PointerOverPlaceholder => GetNextGlyphIfNull(ratingItemFontInfo.PointerOverPlaceholderGlyph, RatingControlStates.Placeholder), 
			RatingControlStates.Placeholder => GetNextGlyphIfNull(ratingItemFontInfo.PlaceholderGlyph, RatingControlStates.Set), 
			RatingControlStates.Unset => GetNextGlyphIfNull(ratingItemFontInfo.UnsetGlyph, RatingControlStates.Set), 
			RatingControlStates.Null => null, 
			_ => ratingItemFontInfo.Glyph, 
		};
	}

	private string GetNextGlyphIfNull(string glyph, RatingControlStates fallbackType)
	{
		if (string.IsNullOrEmpty(glyph))
		{
			if (fallbackType == RatingControlStates.Null)
			{
				return null;
			}
			return GetAppropriateGlyph(fallbackType);
		}
		return glyph;
	}

	private ImageSource GetAppropriateImageSource(RatingControlStates type)
	{
		if (!IsItemInfoPresentAndImageInfo())
		{
			throw new InvalidOperationException("Runtime error, tried to retrieve an image when the ItemInfo is not a RatingItemImageInfo");
		}
		RatingItemImageInfo ratingItemImageInfo = ItemInfo as RatingItemImageInfo;
		return type switch
		{
			RatingControlStates.Disabled => GetNextImageIfNull(ratingItemImageInfo.DisabledImage, RatingControlStates.Set), 
			RatingControlStates.PointerOverSet => GetNextImageIfNull(ratingItemImageInfo.PointerOverImage, RatingControlStates.Set), 
			RatingControlStates.PointerOverPlaceholder => GetNextImageIfNull(ratingItemImageInfo.PointerOverPlaceholderImage, RatingControlStates.Placeholder), 
			RatingControlStates.Placeholder => GetNextImageIfNull(ratingItemImageInfo.PlaceholderImage, RatingControlStates.Set), 
			RatingControlStates.Unset => GetNextImageIfNull(ratingItemImageInfo.UnsetImage, RatingControlStates.Set), 
			RatingControlStates.Null => null, 
			_ => ratingItemImageInfo.Image, 
		};
	}

	private ImageSource GetNextImageIfNull(ImageSource image, RatingControlStates fallbackType)
	{
		if (image == null)
		{
			if (fallbackType == RatingControlStates.Null)
			{
				return null;
			}
			return GetAppropriateImageSource(fallbackType);
		}
		return image;
	}

	private void ResetControlWidth()
	{
		double width = CalculateTotalRatingControlWidth();
		Width = width;
	}

	private void ChangeRatingBy(double change, bool originatedFromMouse)
	{
		if (change == 0.0)
		{
			return;
		}
		double num = 0.0;
		double value = Value;
		if (value != -1.0)
		{
			if ((double)(int)Value != Value)
			{
				num = ((change != -1.0) ? ((double)(int)Value + change) : ((double)(int)Value));
			}
			else
			{
				num = value;
				num += change;
			}
		}
		else
		{
			num = InitialSetValue;
		}
		SetRatingTo(num, originatedFromMouse);
	}

	private void SetRatingTo(double newRating, bool originatedFromMouse)
	{
		double num = 0.0;
		double value = Value;
		num = Math.Min(newRating, MaxRating);
		num = Math.Max(num, 0.0);
		if (value > -1.0 || num != 0.0)
		{
			if (!IsClearEnabled && num <= 0.0)
			{
				Value = 1.0;
			}
			else if (num == value && IsClearEnabled && (num != (double)MaxRating || originatedFromMouse))
			{
				Value = -1.0;
			}
			else if (num > 0.0)
			{
				Value = num;
			}
			else
			{
				Value = -1.0;
			}
			if (SharedHelpers.IsRS1OrHigher() && base.IsFocusEngaged && ShouldEnableAnimation())
			{
				double num2 = CalculateStarCenter((int)(num - 1.0));
				m_sharedPointerPropertySet!.InsertScalar("starsScaleFocalPoint", (float)num2);
			}
			this.ValueChanged?.Invoke(this, null);
		}
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == MaxRatingProperty)
		{
			int num = (int)args.NewValue;
			int num2 = Math.Max(1, num);
			if (Value > (double)num2)
			{
				Value = num2;
			}
			if (PlaceholderValue > (double)num2)
			{
				PlaceholderValue = num2;
			}
			if (num2 != num)
			{
				SetValue(property, num2);
				return;
			}
		}
		else if (property == PlaceholderValueProperty || property == ValueProperty)
		{
			double num3 = (double)args.NewValue;
			double num4 = CoerceValueBetweenMinAndMax(num3);
			if (num3 != num4)
			{
				SetValue(property, num4);
				return;
			}
		}
		if (property == CaptionProperty)
		{
			OnCaptionChanged(args);
		}
		else if (property == InitialSetValueProperty)
		{
			OnInitialSetValueChanged(args);
		}
		else if (property == IsClearEnabledProperty)
		{
			OnIsClearEnabledChanged(args);
		}
		else if (property == IsReadOnlyProperty)
		{
			OnIsReadOnlyChanged(args);
		}
		else if (property == ItemInfoProperty)
		{
			OnItemInfoChanged(args);
		}
		else if (property == MaxRatingProperty)
		{
			OnMaxRatingChanged(args);
		}
		else if (property == PlaceholderValueProperty)
		{
			OnPlaceholderValueChanged(args);
		}
		else if (property == ValueProperty)
		{
			OnValueChanged(args);
		}
	}

	private void OnCaptionChanged(DependencyPropertyChangedEventArgs args)
	{
		ReRenderCaption();
	}

	private void OnFontFamilyChanged(DependencyObject sender, DependencyProperty args)
	{
		if (m_backgroundStackPanel != null)
		{
			for (int i = 0; i < MaxRating; i++)
			{
				if (m_backgroundStackPanel!.Children[i] is TextBlock ui)
				{
					CustomizeRatingItem(ui, RatingControlStates.Unset);
				}
				if (m_foregroundStackPanel!.Children[i] is TextBlock ui2)
				{
					CustomizeRatingItem(ui2, RatingControlStates.Set);
				}
			}
		}
		UpdateRatingItemsAppearance();
	}

	private void OnInitialSetValueChanged(DependencyPropertyChangedEventArgs args)
	{
	}

	private void OnIsClearEnabledChanged(DependencyPropertyChangedEventArgs args)
	{
	}

	private void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs args)
	{
	}

	private void OnItemInfoChanged(DependencyPropertyChangedEventArgs args)
	{
		bool flag = false;
		if (ItemInfo == null)
		{
			m_infoType = RatingInfoType.None;
		}
		else if (ItemInfo is RatingItemFontInfo)
		{
			if (m_infoType != RatingInfoType.Font && m_backgroundStackPanel != null)
			{
				m_infoType = RatingInfoType.Font;
				StampOutRatingItems();
				flag = true;
			}
		}
		else if (m_infoType != RatingInfoType.Image)
		{
			m_infoType = RatingInfoType.Image;
			StampOutRatingItems();
			flag = true;
		}
		if (m_backgroundStackPanel != null && !flag)
		{
			for (int i = 0; i < MaxRating; i++)
			{
				CustomizeRatingItem(m_backgroundStackPanel!.Children[i], RatingControlStates.Unset);
				CustomizeRatingItem(m_foregroundStackPanel!.Children[i], RatingControlStates.Set);
			}
		}
		UpdateRatingItemsAppearance();
	}

	private void OnMaxRatingChanged(DependencyPropertyChangedEventArgs args)
	{
		StampOutRatingItems();
	}

	private void OnPlaceholderValueChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateRatingItemsAppearance();
	}

	private void OnValueChanged(DependencyPropertyChangedEventArgs args)
	{
		AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
		if (automationPeer != null)
		{
			Microsoft.UI.Xaml.Automation.Peers.RatingControlAutomationPeer ratingControlAutomationPeer = automationPeer as Microsoft.UI.Xaml.Automation.Peers.RatingControlAutomationPeer;
			ratingControlAutomationPeer.RaisePropertyChangedEvent(Value);
		}
		UpdateRatingItemsAppearance();
	}

	private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs args)
	{
		UpdateRatingItemsAppearance();
	}

	private void OnCaptionSizeChanged(object sender, SizeChangedEventArgs args)
	{
		ResetControlWidth();
	}

	private void OnPointerCancelledBackgroundStackPanel(object sender, PointerRoutedEventArgs args)
	{
		PointerExitedImpl(args);
	}

	private void OnPointerCaptureLostBackgroundStackPanel(object sender, PointerRoutedEventArgs args)
	{
		PointerExitedImpl(args, resetScaleAnimation: false);
	}

	private void OnPointerMovedOverBackgroundStackPanel(object sender, PointerRoutedEventArgs args)
	{
		if (IsReadOnly)
		{
			return;
		}
		PointerPoint currentPoint = args.GetCurrentPoint(m_backgroundStackPanel);
		float num = (float)currentPoint.Position.X;
		if (ShouldEnableAnimation())
		{
			m_sharedPointerPropertySet!.InsertScalar("starsScaleFocalPoint", num);
			if (args.Pointer.PointerDeviceType == PointerDeviceType.Touch)
			{
				m_sharedPointerPropertySet!.InsertScalar("pointerScalar", 1f);
			}
			else
			{
				m_sharedPointerPropertySet!.InsertScalar("pointerScalar", 0.8f);
			}
		}
		m_mousePercentage = (double)num / CalculateActualRatingWidth();
		UpdateRatingItemsAppearance();
		args.Handled = true;
	}

	private void OnPointerEnteredBackgroundStackPanel(object sender, PointerRoutedEventArgs args)
	{
		if (!IsReadOnly)
		{
			m_isPointerOver = true;
			args.Handled = true;
		}
	}

	private void OnPointerExitedBackgroundStackPanel(object sender, PointerRoutedEventArgs args)
	{
		PointerExitedImpl(args);
	}

	private void PointerExitedImpl(PointerRoutedEventArgs args, bool resetScaleAnimation = true)
	{
		PointerPoint currentPoint = args.GetCurrentPoint(m_backgroundStackPanel);
		if (resetScaleAnimation)
		{
			m_isPointerOver = false;
		}
		if (!m_isPointerDown)
		{
			if (resetScaleAnimation)
			{
				m_sharedPointerPropertySet!.InsertScalar("starsScaleFocalPoint", -100f);
			}
			UpdateRatingItemsAppearance();
		}
		args.Handled = true;
	}

	private void OnPointerPressedBackgroundStackPanel(object sender, PointerRoutedEventArgs args)
	{
		if (!IsReadOnly)
		{
			m_isPointerDown = true;
			m_backgroundStackPanel!.CapturePointer(args.Pointer);
		}
	}

	private void OnPointerReleasedBackgroundStackPanel(object sender, PointerRoutedEventArgs args)
	{
		if (!IsReadOnly)
		{
			PointerPoint currentPoint = args.GetCurrentPoint(m_backgroundStackPanel);
			double x = currentPoint.Position.X;
			double num = x / CalculateActualRatingWidth();
			SetRatingTo(Math.Ceiling(num * (double)MaxRating), originatedFromMouse: true);
			if (SharedHelpers.IsRS1OrHigher())
			{
				ElementSoundPlayer.Play(ElementSoundKind.Invoke);
			}
		}
		if (m_isPointerDown)
		{
			m_isPointerDown = false;
			UpdateRatingItemsAppearance();
		}
	}

	private double CalculateTotalRatingControlWidth()
	{
		double num = CalculateActualRatingWidth();
		string text = (string)GetValue(CaptionProperty);
		double num2 = 0.0;
		if (text != null && text.Length > 0)
		{
			num2 = ItemSpacing();
		}
		double num3 = 0.0;
		if (m_captionTextBlock != null)
		{
			num3 = m_captionTextBlock!.ActualWidth;
		}
		return num + num2 + num3;
	}

	private double CalculateStarCenter(int starIndex)
	{
		return (double)ActualRatingFontSize() * ((double)starIndex + 0.5) + (double)starIndex * ItemSpacing();
	}

	private double CalculateActualRatingWidth()
	{
		return (double)((float)MaxRating * ActualRatingFontSize()) + (double)(MaxRating - 1) * ItemSpacing();
	}

	protected override void OnKeyDown(KeyRoutedEventArgs eventArgs)
	{
		if (eventArgs.Handled)
		{
			return;
		}
		if (!IsReadOnly)
		{
			bool handled = false;
			VirtualKey virtualKey = eventArgs.Key;
			double num = 1.0;
			if (base.FlowDirection == FlowDirection.RightToLeft)
			{
				num *= -1.0;
			}
			VirtualKey originalKey = eventArgs.OriginalKey;
			switch (originalKey)
			{
			case VirtualKey.Up:
				virtualKey = VirtualKey.Right;
				num = 1.0;
				break;
			case VirtualKey.Down:
				virtualKey = VirtualKey.Left;
				num = 1.0;
				break;
			}
			if ((originalKey == VirtualKey.GamepadDPadLeft || originalKey == VirtualKey.GamepadDPadRight || originalKey == VirtualKey.GamepadLeftThumbstickLeft || originalKey == VirtualKey.GamepadLeftThumbstickRight) && SharedHelpers.IsRS1OrHigher())
			{
				ElementSoundPlayer.Play(ElementSoundKind.Focus);
			}
			switch (virtualKey)
			{
			case VirtualKey.Left:
				ChangeRatingBy(-1.0 * num, originatedFromMouse: false);
				handled = true;
				break;
			case VirtualKey.Right:
				ChangeRatingBy(1.0 * num, originatedFromMouse: false);
				handled = true;
				break;
			case VirtualKey.Home:
				SetRatingTo(0.0, originatedFromMouse: false);
				handled = true;
				break;
			case VirtualKey.End:
				SetRatingTo(MaxRating, originatedFromMouse: false);
				handled = true;
				break;
			}
			eventArgs.Handled = handled;
		}
		base.OnKeyDown(eventArgs);
	}

	protected override void OnPreviewKeyDown(KeyRoutedEventArgs eventArgs)
	{
		if (eventArgs.Handled || IsReadOnly || !base.IsFocusEngaged || !base.IsFocusEngagementEnabled)
		{
			return;
		}
		switch (eventArgs.OriginalKey)
		{
		case VirtualKey.GamepadA:
			m_shouldDiscardValue = false;
			m_preEngagementValue = -1.0;
			RemoveFocusEngagement();
			m_disengagedWithA = true;
			eventArgs.Handled = true;
			break;
		case VirtualKey.GamepadB:
		{
			bool flag = false;
			m_shouldDiscardValue = false;
			if (Value != m_preEngagementValue)
			{
				flag = true;
			}
			Value = m_preEngagementValue;
			if (flag)
			{
				this.ValueChanged?.Invoke(this, null);
			}
			m_preEngagementValue = -1.0;
			RemoveFocusEngagement();
			eventArgs.Handled = true;
			break;
		}
		}
	}

	protected override void OnPreviewKeyUp(KeyRoutedEventArgs eventArgs)
	{
		VirtualKey originalKey = eventArgs.OriginalKey;
		if (base.IsFocusEngagementEnabled && originalKey == VirtualKey.GamepadA && m_disengagedWithA)
		{
			m_disengagedWithA = false;
			eventArgs.Handled = true;
		}
	}

	private bool ShouldEnableAnimation()
	{
		return SharedHelpers.IsAnimationsEnabled();
	}

	private void OnFocusEngaged(Control sender, FocusEngagedEventArgs args)
	{
		if (!IsReadOnly)
		{
			EnterGamepadEngagementMode();
		}
	}

	private void OnFocusDisengaged(Control sender, FocusDisengagedEventArgs args)
	{
		if (m_shouldDiscardValue)
		{
			bool flag = false;
			if (Value != m_preEngagementValue)
			{
				flag = true;
			}
			Value = m_preEngagementValue;
			m_preEngagementValue = -1.0;
			if (flag)
			{
				this.ValueChanged?.Invoke(this, null);
			}
		}
		ExitGamepadEngagementMode();
	}

	private void EnterGamepadEngagementMode()
	{
		double value = Value;
		m_shouldDiscardValue = true;
		if (value != -1.0)
		{
			value = (m_preEngagementValue = Value);
		}
		else
		{
			Value = InitialSetValue;
			this.ValueChanged?.Invoke(this, null);
			value = InitialSetValue;
			m_preEngagementValue = -1.0;
		}
		if (SharedHelpers.IsRS1OrHigher())
		{
			ElementSoundPlayer.Play(ElementSoundKind.Invoke);
		}
		if (ShouldEnableAnimation())
		{
			double num = CalculateStarCenter((int)(value - 1.0));
			m_sharedPointerPropertySet!.InsertScalar("starsScaleFocalPoint", (float)num);
		}
	}

	private void ExitGamepadEngagementMode()
	{
		if (SharedHelpers.IsRS1OrHigher())
		{
			ElementSoundPlayer.Play(ElementSoundKind.GoBack);
		}
		m_sharedPointerPropertySet!.InsertScalar("starsScaleFocalPoint", -100f);
		m_disengagedWithA = false;
	}

	private void RecycleEvents(bool useSafeGet = false)
	{
		if (m_backgroundStackPanel != null)
		{
			m_backgroundStackPanel!.PointerCanceled -= OnPointerCancelledBackgroundStackPanel;
			m_backgroundStackPanel!.PointerCaptureLost -= OnPointerCaptureLostBackgroundStackPanel;
			m_backgroundStackPanel!.PointerMoved -= OnPointerMovedOverBackgroundStackPanel;
			m_backgroundStackPanel!.PointerEntered -= OnPointerEnteredBackgroundStackPanel;
			m_backgroundStackPanel!.PointerExited -= OnPointerExitedBackgroundStackPanel;
			m_backgroundStackPanel!.PointerPressed -= OnPointerPressedBackgroundStackPanel;
			m_backgroundStackPanel!.PointerReleased -= OnPointerReleasedBackgroundStackPanel;
		}
		if (m_captionTextBlock != null)
		{
			m_captionTextBlock!.SizeChanged -= OnCaptionSizeChanged;
		}
		UnregisterPropertyChangedCallback(Control.FontFamilyProperty, m_fontFamilyChangedToken);
		base.IsEnabledChanged -= OnIsEnabledChanged;
	}

	private void OnTextScaleFactorChanged(UISettings setting, object args)
	{
		m_dispatcherHelper!.RunAsync(delegate
		{
			StampOutRatingItems();
			UpdateCaptionMargins();
		});
	}

	private UISettings GetUISettings()
	{
		_uiSettings = _uiSettings ?? new UISettings();
		return _uiSettings;
	}

	private bool IsItemInfoPresentAndFontInfo()
	{
		return m_infoType == RatingInfoType.Font;
	}

	private bool IsItemInfoPresentAndImageInfo()
	{
		return m_infoType == RatingInfoType.Image;
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		RatingControl ratingControl = sender as RatingControl;
		ratingControl.OnPropertyChanged(args);
	}
}

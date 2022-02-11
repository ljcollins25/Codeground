using System;
using System.Runtime.CompilerServices;
using DirectUI;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Windows.UI.Xaml.Controls;

public class CalendarViewBaseItem : Control
{
	internal class CalendarViewBaseItemAutomationPeer : FrameworkElementAutomationPeer
	{
		internal CalendarViewBaseItemAutomationPeer(object owner)
			: base(owner)
		{
		}

		protected override object GetPatternCore(PatternInterface patternInterface)
		{
			object obj = null;
			bool flag = false;
			flag = IsItemVisible();
			if ((patternInterface == PatternInterface.GridItem && flag) || patternInterface == PatternInterface.ScrollItem)
			{
				return this;
			}
			return base.GetPatternCore(patternInterface);
		}

		protected override string GetNameCore()
		{
			string text = base.GetNameCore();
			if (text == null)
			{
				UIElement owner = base.Owner;
				text = (owner as CalendarViewItem).GetMainText();
			}
			return text;
		}

		private int ColumnSpanImpl()
		{
			return 1;
		}

		protected IRawElementProviderSimple ContainingGridImpl()
		{
			IRawElementProviderSimple rawElementProviderSimple = null;
			UIElement owner = base.Owner;
			CalendarView parentCalendarView = (owner as CalendarViewBaseItem).GetParentCalendarView();
			AutomationPeer automationPeer = parentCalendarView.GetAutomationPeer();
			return ProviderFromPeer(automationPeer);
		}

		private int RowSpanImpl()
		{
			return 1;
		}

		private void ScrollIntoViewImpl()
		{
			UIElement owner = base.Owner;
			DateTimeOffset dateBase = (owner as CalendarViewItem).DateBase;
			CalendarView parentCalendarView = (owner as CalendarViewBaseItem).GetParentCalendarView();
			parentCalendarView.SetDisplayDate(dateBase);
		}

		private bool IsItemVisible()
		{
			bool result = false;
			UIElement owner = base.Owner;
			CalendarView parentCalendarView = (owner as CalendarViewBaseItem).GetParentCalendarView();
			parentCalendarView.GetActiveGeneratorHost(out var ppHost);
			CalendarPanel panel = ppHost.Panel;
			if (panel != null)
			{
				DateTimeOffset dateTimeOffset = default(DateTimeOffset);
				dateTimeOffset = (owner as CalendarViewBaseItem).DateBase;
				int num = 0;
				num = ppHost.CalculateOffsetFromMinDate(dateTimeOffset);
				int num2 = 0;
				num2 = panel.FirstVisibleIndex;
				int num3 = 0;
				num3 = panel.LastVisibleIndex;
				result = num >= num2 && num <= num3;
			}
			return result;
		}
	}

	private interface IContentRenderer
	{
		void RenderFocusRectangle(CalendarViewBaseItem calendarViewBaseItem, FocusRectangleOptions focusOptions);

		void GeneralImageRenderContent(Rect bounds, Rect rect, Brush pBrush, BrushParams emptyBrushParams, CalendarViewBaseItem calendarViewBaseItem, object o, object o1, bool b);
	}

	private protected struct TextBlockFontProperties
	{
		public float fontSize;

		public FontStyle fontStyle;

		public FontWeight fontWeight;

		public FontFamily pFontFamilyNoRef;
	}

	private protected struct TextBlockAlignments
	{
		public HorizontalAlignment horizontalAlignment;

		public VerticalAlignment verticalAlignment;
	}

	private CalendarView m_pParentCalendarView;

	private const float InScopeDensityBarOpacity = 0.35f;

	private const float OutOfScopeDensityBarOpacity = 0.1f;

	private const float MaxDensityBarHeight = 5f;

	private const float TodayBlackouTopacity = 0.4f;

	private const float FocusBorderThickness = 2f;

	private const float TodaySelectedInnerBorderThickness = 2f;

	private TextBlock m_pMainTextBlock;

	private TextBlock m_pLabelTextBlock;

	private WeakReference<CalendarView> m_wrOwner;

	private const int s_maxNumberOfDensityBars = 10;

	private Color[] m_densityBarColors = new Color[10];

	private uint m_numberOfDensityBar;

	private protected bool m_isToday;

	private protected bool m_isKeyboardFocused;

	private protected bool m_isSelected;

	private protected bool m_isBlackout;

	private protected bool m_isHovered;

	private protected bool m_isPressed;

	private protected bool m_isOutOfScope;

	private protected bool m_hasLabel;

	private readonly BorderLayerRenderer _borderRenderer = new BorderLayerRenderer();

	private Size _lastSize;

	internal virtual DateTimeOffset DateBase
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs pArgs)
	{
		bool flag = false;
		base.OnPointerPressed(pArgs);
		if (!pArgs.Handled)
		{
			SetIsPressed(state: true);
			UpdateVisualStateInternal();
		}
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs pArgs)
	{
		bool flag = false;
		base.OnPointerReleased(pArgs);
		if (!pArgs.Handled)
		{
			SetIsPressed(state: false);
			UpdateVisualStateInternal();
		}
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs pArgs)
	{
		PointerDeviceType pointerDeviceType = PointerDeviceType.Touch;
		base.OnPointerEntered(pArgs);
		Pointer pointer = pArgs.Pointer;
		if (pointer.PointerDeviceType != 0)
		{
			SetIsHovered(state: true);
			UpdateVisualStateInternal();
		}
	}

	protected override void OnPointerExited(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerExited(pArgs);
		SetIsHovered(state: false);
		SetIsPressed(state: false);
		UpdateVisualStateInternal();
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerCaptureLost(pArgs);
		SetIsHovered(state: false);
		SetIsPressed(state: false);
		UpdateVisualStateInternal();
	}

	protected override void OnGotFocus(RoutedEventArgs pArgs)
	{
		FocusState focusState = FocusState.Unfocused;
		base.OnGotFocus(pArgs);
		GetParentCalendarView()?.OnItemFocused(this);
		focusState = base.FocusState;
		SetIsKeyboardFocused(focusState == FocusState.Keyboard);
	}

	protected override void OnLostFocus(RoutedEventArgs pArgs)
	{
		base.OnLostFocus(pArgs);
		SetIsKeyboardFocused(state: false);
	}

	protected override void OnRightTapped(RightTappedRoutedEventArgs pArgs)
	{
		base.OnRightTapped(pArgs);
		bool flag = false;
		if (!pArgs.Handled)
		{
			bool flag2 = false;
			flag2 = FocusSelfOrChild(FocusState.Pointer);
			pArgs.Handled = true;
		}
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs pArgs)
	{
		UpdateTextBlockForeground();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private protected CalendarViewBaseItem GetHandle()
	{
		return this;
	}

	internal void SetParentCalendarView(CalendarView pCalendarView)
	{
		m_pParentCalendarView = pCalendarView;
		CalendarViewBaseItem handle = GetHandle();
		handle.SetOwner(pCalendarView);
	}

	internal CalendarView GetParentCalendarView()
	{
		return m_pParentCalendarView;
	}

	internal bool FocusSelfOrChild(FocusState focusState, FocusNavigationDirection focusNavigationDirection = FocusNavigationDirection.Next)
	{
		bool flag = false;
		DependencyObject dependencyObject = null;
		bool result = false;
		dependencyObject = ((base.FocusState == FocusState.Unfocused) ? this : (FocusManager.GetFocusedElement() as DependencyObject));
		if (dependencyObject != null)
		{
			bool flag2 = FocusManager.SetFocusedElementWithDirection(dependencyObject, focusState, animateIfBringIntoView: false, forceBringIntoView: false, focusNavigationDirection);
			result = !flag2;
		}
		return result;
	}

	internal void UpdateTextBlockForeground()
	{
		CalendarViewBaseItem handle = GetHandle();
		handle.UpdateTextBlocksForeground();
	}

	internal void UpdateTextBlockFontProperties()
	{
		CalendarViewBaseItem handle = GetHandle();
		handle.UpdateTextBlocksFontProperties();
	}

	internal void UpdateTextBlockAlignments()
	{
		CalendarViewBaseItem handle = GetHandle();
		handle.UpdateTextBlocksAlignments();
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
		base.ChangeVisualState(bUseTransitions);
		CalendarViewBaseItem handle = GetHandle();
		bool flag = false;
		bool flag2 = handle.IsHovered();
		if (handle.IsPressed())
		{
			flag = GoToState(bUseTransitions, "Pressed");
		}
		else if (flag2)
		{
			flag = GoToState(bUseTransitions, "PointerOver");
		}
		else
		{
			flag = GoToState(bUseTransitions, "Normal");
		}
	}

	private void UpdateVisualStateInternal()
	{
		CalendarViewBaseItem handle = GetHandle();
		if (handle.HasTemplateChild())
		{
			UpdateVisualState(useTransitions: false);
		}
	}

	internal CalendarViewBaseItem()
	{
		m_pParentCalendarView = null;
		Initialize_CalendarViewBaseItemChrome();
	}

	internal override bool IsViewHit()
	{
		return true;
	}

	protected override void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void Initialize_CalendarViewBaseItemChrome()
	{
		m_pMainTextBlock = null;
		m_pLabelTextBlock = null;
		m_isToday = false;
		m_isKeyboardFocused = false;
		m_isSelected = false;
		m_isBlackout = false;
		m_isHovered = false;
		m_isPressed = false;
		m_isOutOfScope = false;
		m_numberOfDensityBar = 0u;
		m_hasLabel = false;
	}

	private bool HasTemplateChild()
	{
		return GetFirstChildNoAddRef() != null;
	}

	private void RemoveTemplateChild()
	{
		UIElement firstChildNoAddRef = GetFirstChildNoAddRef();
		if (firstChildNoAddRef != null)
		{
			RemoveChild(firstChildNoAddRef);
		}
	}

	private UIElement GetFirstChildNoAddRef()
	{
		return GetFirstChild();
	}

	private UIElement GetFirstChild()
	{
		UIElement uIElement = VisualTreeHelper.GetChild(this, 0) as UIElement;
		if (uIElement != m_pMainTextBlock && uIElement != m_pLabelTextBlock)
		{
			return uIElement;
		}
		return null;
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == Control.TemplateProperty)
		{
			InvalidateRender();
		}
		if (args.Property == FrameworkElement.BackgroundProperty)
		{
			InvalidateRender();
		}
		base.OnPropertyChanged2(args);
	}

	private void GenerateContentBounds(out Rect pBounds)
	{
		pBounds = default(Rect);
		pBounds.X = 0.0;
		pBounds.Y = 0.0;
		pBounds.Width = GetActualWidth();
		pBounds.Height = GetActualHeight();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size pSize = default(Size);
		Thickness itemBorderThickness = GetItemBorderThickness();
		Thickness padding = base.Padding;
		if (ShouldUseLayoutRounding())
		{
			itemBorderThickness.Left = LayoutRound(itemBorderThickness.Left);
			itemBorderThickness.Right = LayoutRound(itemBorderThickness.Right);
			itemBorderThickness.Top = LayoutRound(itemBorderThickness.Top);
			itemBorderThickness.Bottom = LayoutRound(itemBorderThickness.Bottom);
			padding.Left = LayoutRound(padding.Left);
			padding.Right = LayoutRound(padding.Right);
			padding.Top = LayoutRound(padding.Top);
			padding.Bottom = LayoutRound(padding.Bottom);
		}
		CSizeUtil.Deflate(ref availableSize, itemBorderThickness);
		CSizeUtil.Deflate(ref availableSize, padding);
		Uno_MeasureChrome(availableSize);
		if (m_pMainTextBlock != null)
		{
			m_pMainTextBlock.Measure(availableSize);
			pSize = m_pMainTextBlock.DesiredSize;
		}
		if (m_pLabelTextBlock != null)
		{
			m_pLabelTextBlock.Measure(availableSize);
		}
		UIElement firstChildNoAddRef = GetFirstChildNoAddRef();
		if (firstChildNoAddRef != null)
		{
			firstChildNoAddRef.Measure(availableSize);
			pSize.Width = Math.Max(firstChildNoAddRef.DesiredSize.Width, pSize.Width);
			pSize.Height = Math.Max(firstChildNoAddRef.DesiredSize.Height, pSize.Height);
		}
		CSizeUtil.Inflate(ref pSize, itemBorderThickness);
		CSizeUtil.Inflate(ref pSize, padding);
		return pSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size size = default(Size);
		Rect pRect = new Rect(0.0, 0.0, finalSize.Width, finalSize.Height);
		Thickness itemBorderThickness = GetItemBorderThickness();
		Thickness padding = base.Padding;
		CSizeUtil.Deflate(ref pRect, itemBorderThickness);
		CSizeUtil.Deflate(ref pRect, padding);
		if (ShouldUseLayoutRounding())
		{
			itemBorderThickness.Left = LayoutRound(itemBorderThickness.Left);
			itemBorderThickness.Right = LayoutRound(itemBorderThickness.Right);
			itemBorderThickness.Top = LayoutRound(itemBorderThickness.Top);
			itemBorderThickness.Bottom = LayoutRound(itemBorderThickness.Bottom);
			padding.Left = LayoutRound(padding.Left);
			padding.Right = LayoutRound(padding.Right);
			padding.Top = LayoutRound(padding.Top);
			padding.Bottom = LayoutRound(padding.Bottom);
		}
		Uno_ArrangeChrome(pRect);
		if (m_pMainTextBlock != null)
		{
			m_pMainTextBlock.Arrange(pRect);
		}
		if (m_pLabelTextBlock != null)
		{
			m_pLabelTextBlock.Arrange(pRect);
		}
		GetFirstChildNoAddRef()?.Arrange(pRect);
		return finalSize;
	}

	private void CreateTextBlock(ref TextBlock spTextBlock)
	{
		spTextBlock = new TextBlock();
		spTextBlock.SetValue(UIElement.IsHitTestVisibleProperty, false);
		object value = TextWrapping.NoWrap;
		spTextBlock.SetValue(TextBlock.TextWrappingProperty, value);
		value = AccessibilityView.Raw;
		spTextBlock.SetValue(AutomationProperties.AccessibilityViewProperty, value);
		value = Visibility.Visible;
		spTextBlock.SetValue(UIElement.VisibilityProperty, value);
	}

	private void EnsureTextBlock(ref TextBlock spTextBlock)
	{
		if (spTextBlock == null)
		{
			CreateTextBlock(ref spTextBlock);
			AddChild(spTextBlock);
			UpdateTextBlockForeground(spTextBlock);
			UpdateTextBlockForegroundOpacity(spTextBlock);
			UpdateTextBlockFontProperties(spTextBlock);
			UpdateTextBlockAlignments(spTextBlock);
		}
	}

	private bool IsLabel(TextBlock pTextBlock)
	{
		return pTextBlock == m_pLabelTextBlock;
	}

	private void RenderChrome(IContentRenderer pContentRenderer, CalendarViewBaseItemChromeLayerPosition layer)
	{
		Rect rect = new Rect(0.0, 0.0, GetActualWidth(), GetActualHeight());
		if (ShouldUseLayoutRounding())
		{
			rect.Width = LayoutRound(rect.Width);
			rect.Height = LayoutRound(rect.Height);
		}
		if (layer == CalendarViewBaseItemChromeLayerPosition.Pre)
		{
			DrawBackground(pContentRenderer, rect);
			DrawControlBackground(pContentRenderer, rect);
		}
		if (layer == CalendarViewBaseItemChromeLayerPosition.TemplateChild_Post || (layer == CalendarViewBaseItemChromeLayerPosition.Pre && GetFirstChildNoAddRef() == null))
		{
			DrawDensityBar(pContentRenderer, rect);
		}
		if (layer == CalendarViewBaseItemChromeLayerPosition.Post)
		{
			bool flag = false;
			flag = ShouldDrawDottedLinesFocusVisual();
			if (m_isKeyboardFocused && flag)
			{
				DrawFocusBorder(pContentRenderer, rect);
			}
			else
			{
				DrawBorder(pContentRenderer, rect);
			}
			if (m_isToday && m_isSelected)
			{
				Rect pRect = rect;
				CSizeUtil.Deflate(ref pRect, GetItemBorderThickness());
				DrawInnerBorder(pContentRenderer, pRect);
			}
		}
	}

	private void RenderDensityBars(IContentRenderer pContentRenderer)
	{
		RenderChrome(pContentRenderer, CalendarViewBaseItemChromeLayerPosition.TemplateChild_Post);
	}

	private bool ShouldUseLayoutRounding()
	{
		return false;
	}

	private uint GetIntValueOfColor(Color color)
	{
		return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B);
	}

	private void DrawDensityBar(IContentRenderer pContentRenderer, Rect bounds)
	{
	}

	private void DrawBorder(IContentRenderer pContentRenderer, Brush pBrush, Rect bounds, Thickness pNinegrid, bool isHollow)
	{
		pContentRenderer.GeneralImageRenderContent(bounds, bounds, pBrush, default(BrushParams), this, pNinegrid, null, isHollow);
	}

	private void DrawBorder(IContentRenderer pContentRenderer, Rect bounds)
	{
		Thickness itemBorderThickness = GetItemBorderThickness();
		Brush itemBorderBrush = GetItemBorderBrush(forFocus: false);
		if (itemBorderBrush != null && itemBorderThickness.Bottom != 0.0 && itemBorderThickness.Top != 0.0 && itemBorderThickness.Left != 0.0 && itemBorderThickness.Right != 0.0)
		{
			DrawBorder(pContentRenderer, itemBorderBrush, bounds, itemBorderThickness, isHollow: true);
		}
	}

	private void DrawInnerBorder(IContentRenderer pContentRenderer, Rect bounds)
	{
	}

	private void DrawFocusBorder(IContentRenderer pContentRenderer, Rect bounds)
	{
		FocusRectangleOptions focusOptions = default(FocusRectangleOptions);
		Brush itemBorderBrush = GetItemBorderBrush(forFocus: true);
		Brush itemFocusAltBorderBrush = GetItemFocusAltBorderBrush();
		focusOptions.firstThickness = new Thickness(2.0);
		focusOptions.drawFirst = true;
		focusOptions.firstBrush = (SolidColorBrush)itemBorderBrush;
		focusOptions.drawSecond = true;
		focusOptions.secondBrush = (SolidColorBrush)itemFocusAltBorderBrush;
		pContentRenderer.RenderFocusRectangle(this, focusOptions);
	}

	private void DrawBackground(IContentRenderer pContentRenderer, Rect bounds)
	{
		Brush itemBackgroundBrush = GetItemBackgroundBrush();
		if (itemBackgroundBrush != null)
		{
			pContentRenderer.GeneralImageRenderContent(bounds, bounds, itemBackgroundBrush, default(BrushParams), this, null, null, b: false);
		}
	}

	private void DrawControlBackground(IContentRenderer pContentRenderer, Rect bounds)
	{
		object value = GetValue(FrameworkElement.BackgroundProperty);
		Brush brush = (Brush)value;
		if (brush != null)
		{
			pContentRenderer.GeneralImageRenderContent(bounds, bounds, brush, default(BrushParams), this, null, null, b: false);
		}
	}

	private void SetOwner(CalendarView pOwner)
	{
		m_wrOwner = new WeakReference<CalendarView>(pOwner);
	}

	private protected CalendarView GetOwner()
	{
		m_wrOwner.TryGetTarget(out var target);
		return target;
	}

	internal void SetDensityColors(IIterable<Color> pColors)
	{
		if (pColors != null)
		{
			uint num = 0u;
			bool flag = false;
			IIterator<Color> iterator = pColors.GetIterator();
			flag = iterator.HasCurrent;
			while (flag && num < 10)
			{
				m_densityBarColors[num] = iterator.Current;
				flag = iterator.MoveNext();
				num++;
			}
			m_numberOfDensityBar = num;
		}
		else
		{
			m_numberOfDensityBar = 0u;
		}
		InvalidateRender();
	}

	internal void SetIsToday(bool state)
	{
		if (m_isToday != state)
		{
			m_isToday = state;
			UpdateTextBlocksForeground();
			UpdateTextBlocksForegroundOpacity();
			UpdateTextBlocksFontProperties();
			InvalidateRender();
		}
	}

	internal void SetIsKeyboardFocused(bool state)
	{
		if (m_isKeyboardFocused != state)
		{
			m_isKeyboardFocused = state;
			InvalidateRender();
		}
	}

	internal void SetIsSelected(bool state)
	{
		if (m_isSelected != state)
		{
			m_isSelected = state;
			UpdateTextBlocksForeground();
			UpdateTextBlocksForegroundOpacity();
			InvalidateRender();
		}
	}

	internal void SetIsBlackout(bool state)
	{
		if (m_isBlackout != state)
		{
			m_isBlackout = state;
			UpdateTextBlocksForeground();
			UpdateTextBlocksForegroundOpacity();
			InvalidateRender();
		}
	}

	private void SetIsHovered(bool state)
	{
		if (m_isHovered != state)
		{
			m_isHovered = state;
			InvalidateRender();
		}
	}

	private void SetIsPressed(bool state)
	{
		if (m_isPressed != state)
		{
			m_isPressed = state;
			UpdateTextBlocksForeground();
			InvalidateRender();
		}
	}

	internal void SetIsOutOfScope(bool state)
	{
		if (m_isOutOfScope != state)
		{
			m_isOutOfScope = state;
			UpdateTextBlocksForeground();
			InvalidateRender();
		}
	}

	private void UpdateTextBlocksForeground()
	{
		if (m_pMainTextBlock != null)
		{
			UpdateTextBlockForeground(m_pMainTextBlock);
		}
		if (m_pLabelTextBlock != null)
		{
			UpdateTextBlockForeground(m_pLabelTextBlock);
		}
	}

	private void UpdateTextBlocksForegroundOpacity()
	{
		if (m_pMainTextBlock != null)
		{
			UpdateTextBlockForegroundOpacity(m_pMainTextBlock);
		}
		if (m_pLabelTextBlock != null)
		{
			UpdateTextBlockForegroundOpacity(m_pLabelTextBlock);
		}
	}

	internal void UpdateTextBlocksFontProperties()
	{
		if (m_pMainTextBlock != null)
		{
			UpdateTextBlockFontProperties(m_pMainTextBlock);
		}
		if (m_pLabelTextBlock != null)
		{
			UpdateTextBlockFontProperties(m_pLabelTextBlock);
		}
	}

	private void UpdateTextBlocksAlignments()
	{
		if (m_pMainTextBlock != null)
		{
			UpdateTextBlockAlignments(m_pMainTextBlock);
		}
		if (m_pLabelTextBlock != null)
		{
			UpdateTextBlockAlignments(m_pLabelTextBlock);
		}
	}

	private void UpdateTextBlockForeground(TextBlock pTextBlock)
	{
		Brush textBlockForeground = GetTextBlockForeground();
		pTextBlock.SetValue(TextBlock.ForegroundProperty, textBlockForeground);
	}

	private void UpdateTextBlockForegroundOpacity(TextBlock pTextBlock)
	{
		double num = GetTextBlockForegroundOpacity();
		if (IsLabel(pTextBlock) && !m_hasLabel)
		{
			num = 0.0;
		}
		pTextBlock.SetValue(UIElement.OpacityProperty, num);
	}

	internal void UpdateTextBlockFontProperties(TextBlock pTextBlock)
	{
		if (GetTextBlockFontProperties(IsLabel(pTextBlock), out var pProperties))
		{
			pTextBlock.SetValue(TextBlock.FontSizeProperty, (double)pProperties.fontSize);
			object obj = pProperties.fontStyle;
			pTextBlock.SetValue(TextBlock.FontStyleProperty, (FontStyle)obj);
			obj = pProperties.fontWeight;
			pTextBlock.SetValue(TextBlock.FontWeightProperty, (FontWeight)obj);
			pTextBlock.SetValue(TextBlock.FontFamilyProperty, pProperties.pFontFamilyNoRef);
		}
	}

	private void UpdateTextBlockAlignments(TextBlock pTextBlock)
	{
		if (GetTextBlockAlignments(IsLabel(pTextBlock), out var pAlignments))
		{
			object value = pAlignments.horizontalAlignment;
			pTextBlock.SetValue(FrameworkElement.HorizontalAlignmentProperty, value);
			value = pAlignments.verticalAlignment;
			pTextBlock.SetValue(FrameworkElement.VerticalAlignmentProperty, value);
		}
	}

	internal void UpdateMainText(string mainText)
	{
		EnsureTextBlock(ref m_pMainTextBlock);
		m_pMainTextBlock.SetValue(TextBlock.TextProperty, mainText);
	}

	internal string GetMainText()
	{
		string result = null;
		if (m_pMainTextBlock != null)
		{
			object value = m_pMainTextBlock.GetValue(TextBlock.TextProperty);
			string text = value as string;
			result = text;
		}
		return result;
	}

	private bool IsHovered()
	{
		return m_isHovered;
	}

	private bool IsPressed()
	{
		return m_isPressed;
	}

	internal void UpdateLabelText(string labelText)
	{
		EnsureTextBlock(ref m_pLabelTextBlock);
		m_pLabelTextBlock.SetValue(TextBlock.TextProperty, labelText);
	}

	internal void ShowLabelText(bool showLabel)
	{
		m_hasLabel = showLabel;
		if (m_pLabelTextBlock != null)
		{
			UpdateTextBlockForegroundOpacity(m_pLabelTextBlock);
		}
	}

	private void InvalidateRender()
	{
		Uno_InvalidateRender();
	}

	private Thickness GetItemBorderThickness()
	{
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			Thickness calendarItemBorderThickness = owner.m_calendarItemBorderThickness;
			if (ShouldUseLayoutRounding())
			{
				calendarItemBorderThickness.Left = LayoutRound(calendarItemBorderThickness.Left);
				calendarItemBorderThickness.Right = LayoutRound(calendarItemBorderThickness.Right);
				calendarItemBorderThickness.Top = LayoutRound(calendarItemBorderThickness.Top);
				calendarItemBorderThickness.Bottom = LayoutRound(calendarItemBorderThickness.Bottom);
			}
			return calendarItemBorderThickness;
		}
		return default(Thickness);
	}

	private Brush GetItemBorderBrush(bool forFocus)
	{
		Brush result = null;
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			if (!m_isToday)
			{
				result = ((m_isSelected && !m_isBlackout) ? (m_isPressed ? owner.m_pSelectedPressedBorderBrush : ((!m_isHovered) ? owner.m_pSelectedBorderBrush : owner.m_pSelectedHoverBorderBrush)) : (m_isPressed ? owner.m_pPressedBorderBrush : (m_isHovered ? owner.m_pHoverBorderBrush : ((!forFocus) ? owner.m_pCalendarItemBorderBrush : owner.m_pFocusBorderBrush))));
			}
			else if (m_isPressed)
			{
				result = owner.m_pTodayPressedBorderBrush;
			}
			else if (m_isHovered)
			{
				result = owner.m_pTodayHoverBorderBrush;
			}
		}
		return result;
	}

	private Brush GetItemFocusAltBorderBrush()
	{
		Brush result = null;
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			result = owner.m_pCalendarItemBackground;
		}
		return result;
	}

	private Brush GetItemInnerBorderBrush()
	{
		return GetOwner()?.m_pTodaySelectedInnerBorderBrush;
	}

	private Brush GetItemBackgroundBrush()
	{
		Brush result = null;
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			result = (m_isToday ? ((!m_isBlackout) ? owner.m_pTodayBackground : owner.m_pTodayBlackoutBackground) : ((!m_isOutOfScope) ? owner.m_pCalendarItemBackground : owner.m_pOutOfScopeBackground));
		}
		return result;
	}

	private Brush GetTextBlockForeground()
	{
		Brush result = null;
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			result = ((!base.IsEnabled) ? owner.m_pDisabledForeground : (m_isToday ? owner.m_pTodayForeground : (m_isBlackout ? owner.m_pBlackoutForeground : (m_isSelected ? owner.m_pSelectedForeground : (m_isPressed ? owner.m_pPressedForeground : ((!m_isOutOfScope) ? owner.m_pCalendarItemForeground : owner.m_pOutOfScopeForeground))))));
		}
		return result;
	}

	private float GetTextBlockForegroundOpacity()
	{
		float result = 1f;
		if (m_isToday && m_isBlackout)
		{
			result = 0.4f;
		}
		return result;
	}

	private void CustomizeFocusRectangle(FocusRectangleOptions options, out bool shouldDrawFocusRect)
	{
		bool flag = false;
		if (ShouldDrawDottedLinesFocusVisual())
		{
			shouldDrawFocusRect = false;
			return;
		}
		if (m_isSelected || m_isHovered || m_isPressed)
		{
			options.secondBrush = (SolidColorBrush)GetItemBorderBrush(forFocus: false);
		}
		shouldDrawFocusRect = true;
	}

	private bool ShouldDrawDottedLinesFocusVisual()
	{
		return false;
	}

	private protected virtual bool GetTextBlockFontProperties(bool isLabel, out TextBlockFontProperties pProperties)
	{
		pProperties = default(TextBlockFontProperties);
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			pProperties.fontSize = (isLabel ? owner.m_firstOfYearDecadeLabelFontSize : owner.m_monthYearItemFontSize);
			pProperties.fontStyle = (isLabel ? owner.m_firstOfYearDecadeLabelFontStyle : owner.m_monthYearItemFontStyle);
			if (isLabel)
			{
				pProperties.fontWeight = owner.m_firstOfYearDecadeLabelFontWeight;
			}
			else if (m_isToday)
			{
				pProperties.fontWeight = owner.m_todayFontWeight;
			}
			else
			{
				pProperties.fontWeight = owner.m_monthYearItemFontWeight;
			}
			pProperties.pFontFamilyNoRef = (isLabel ? owner.m_pFirstOfYearDecadeLabelFontFamily : owner.m_pMonthYearItemFontFamily);
		}
		return owner != null;
	}

	private protected virtual bool GetTextBlockAlignments(bool isLabel, out TextBlockAlignments pAlignments)
	{
		pAlignments = default(TextBlockAlignments);
		pAlignments.horizontalAlignment = HorizontalAlignment.Center;
		pAlignments.verticalAlignment = ((!isLabel) ? VerticalAlignment.Center : VerticalAlignment.Top);
		return GetOwner() != null;
	}

	private Brush FindTodaySelectedBackgroundBrush()
	{
		CalendarView owner = GetOwner();
		if (owner != null && m_isToday && m_isSelected)
		{
			return owner.m_pTodaySelectedBackground;
		}
		return null;
	}

	private Brush FindSelectedBackgroundBrush()
	{
		CalendarView owner = GetOwner();
		if (owner != null && !m_isToday && m_isSelected)
		{
			return owner.m_pSelectedBackground;
		}
		return null;
	}

	private protected virtual CornerRadius GetItemCornerRadius()
	{
		return GetOwner()?.m_calendarItemCornerRadius ?? CornerRadius.None;
	}

	private void Uno_InvalidateRender()
	{
		_lastSize = default(Size);
		InvalidateArrange();
	}

	private void Uno_MeasureChrome(Size availableSize)
	{
		if (IsHovered() && !base.IsPointerOver)
		{
			SetIsHovered(state: false);
		}
	}

	private void Uno_ArrangeChrome(Rect finalBounds)
	{
		UpdateChromeIfNeeded(finalBounds);
	}

	private void UpdateChromeIfNeeded(Rect rect)
	{
		if (rect.Width > 0.0 && rect.Height > 0.0 && _lastSize != rect.Size)
		{
			_lastSize = rect.Size;
			UpdateChrome();
		}
	}

	private void UpdateChrome()
	{
		Brush brush = base.Background;
		Thickness itemBorderThickness = GetItemBorderThickness();
		Brush borderBrush = GetItemBorderBrush(forFocus: false);
		CornerRadius itemCornerRadius = GetItemCornerRadius();
		if (IsClear(brush))
		{
			Brush brush2 = FindTodaySelectedBackgroundBrush();
			if (brush2 != null && !IsClear(brush2))
			{
				brush = brush2;
			}
			else
			{
				Brush brush3 = FindSelectedBackgroundBrush();
				brush = ((brush3 == null || IsClear(brush3)) ? GetItemBackgroundBrush() : brush3);
			}
		}
		if (m_isToday && m_isSelected)
		{
			Brush itemInnerBorderBrush = GetItemInnerBorderBrush();
			if (itemInnerBorderBrush != null)
			{
				borderBrush = itemInnerBorderBrush;
			}
		}
		_borderRenderer.UpdateLayer(this, brush, BackgroundSizing.InnerBorderEdge, itemBorderThickness, borderBrush, itemCornerRadius, null);
	}

	private bool IsClear(Brush brush)
	{
		if (brush != null && brush.Opacity != 0.0)
		{
			if (brush is SolidColorBrush solidColorBrush)
			{
				return solidColorBrush.Color.IsTransparent;
			}
			return false;
		}
		return true;
	}
}

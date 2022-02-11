using System;
using Uno;
using Uno.UI;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Windows.Foundation;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Documents;

public sealed class Hyperlink : Span
{
	private readonly IFocusable _focusableHelper;

	private static Brush _defaultForeground;

	private Pointer _pressedPointer;

	private const NavigationTarget _defaultNavigationTarget = NavigationTarget.NewDocument;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ElementSoundMode ElementSoundMode
	{
		get
		{
			return (ElementSoundMode)GetValue(ElementSoundModeProperty);
		}
		set
		{
			SetValue(ElementSoundModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ElementSoundModeProperty { get; } = DependencyProperty.Register("ElementSoundMode", typeof(ElementSoundMode), typeof(Hyperlink), new FrameworkPropertyMetadata(ElementSoundMode.Default));


	private static Brush DefaultForeground
	{
		get
		{
			if (_defaultForeground == null)
			{
				_defaultForeground = null;
			}
			return _defaultForeground;
		}
	}

	public Uri NavigateUri
	{
		get
		{
			return (Uri)GetValue(NavigateUriProperty);
		}
		set
		{
			SetValue(NavigateUriProperty, value);
		}
	}

	public static DependencyProperty NavigateUriProperty { get; } = DependencyProperty.Register("NavigateUri", typeof(Uri), typeof(Hyperlink), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Hyperlink)s).OnNavigateUriChangedPartial((Uri)e.NewValue);
	}));


	public UnderlineStyle UnderlineStyle
	{
		get
		{
			return (UnderlineStyle)GetValue(UnderlineStyleProperty);
		}
		set
		{
			SetValue(UnderlineStyleProperty, value);
		}
	}

	internal static DependencyProperty UnderlineStyleProperty { get; } = DependencyProperty.Register("UnderlineStyle", typeof(UnderlineStyle), typeof(Hyperlink), new FrameworkPropertyMetadata(UnderlineStyle.Single, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Hyperlink)s).OnUnderlineStyleChanged();
	}));


	public new FocusState FocusState
	{
		get
		{
			return base.FocusState;
		}
		set
		{
			base.FocusState = value;
		}
	}

	public new static DependencyProperty FocusStateProperty { get; } = UIElement.FocusStateProperty;


	public new bool IsTabStop
	{
		get
		{
			return base.IsTabStop;
		}
		set
		{
			base.IsTabStop = value;
		}
	}

	public new static DependencyProperty IsTabStopProperty { get; } = UIElement.IsTabStopProperty;


	public new int TabIndex
	{
		get
		{
			return base.TabIndex;
		}
		set
		{
			base.TabIndex = value;
		}
	}

	public new static DependencyProperty TabIndexProperty { get; } = UIElement.TabIndexProperty;


	public new DependencyObject XYFocusUp
	{
		get
		{
			return base.XYFocusUp;
		}
		set
		{
			base.XYFocusUp = value;
		}
	}

	public new static DependencyProperty XYFocusUpProperty { get; } = UIElement.XYFocusUpProperty;


	public new DependencyObject XYFocusDown
	{
		get
		{
			return base.XYFocusDown;
		}
		set
		{
			base.XYFocusDown = value;
		}
	}

	public new static DependencyProperty XYFocusDownProperty { get; } = UIElement.XYFocusDownProperty;


	public new DependencyObject XYFocusLeft
	{
		get
		{
			return base.XYFocusLeft;
		}
		set
		{
			base.XYFocusLeft = value;
		}
	}

	public new static DependencyProperty XYFocusLeftProperty { get; } = UIElement.XYFocusLeftProperty;


	public new DependencyObject XYFocusRight
	{
		get
		{
			return base.XYFocusRight;
		}
		set
		{
			base.XYFocusRight = value;
		}
	}

	public new static DependencyProperty XYFocusRightProperty { get; } = UIElement.XYFocusRightProperty;


	public new XYFocusNavigationStrategy XYFocusDownNavigationStrategy
	{
		get
		{
			return base.XYFocusDownNavigationStrategy;
		}
		set
		{
			base.XYFocusDownNavigationStrategy = value;
		}
	}

	public new static DependencyProperty XYFocusDownNavigationStrategyProperty { get; } = UIElement.XYFocusDownNavigationStrategyProperty;


	public new XYFocusNavigationStrategy XYFocusLeftNavigationStrategy
	{
		get
		{
			return base.XYFocusLeftNavigationStrategy;
		}
		set
		{
			base.XYFocusLeftNavigationStrategy = value;
		}
	}

	public new static DependencyProperty XYFocusLeftNavigationStrategyProperty { get; } = UIElement.XYFocusLeftNavigationStrategyProperty;


	public new XYFocusNavigationStrategy XYFocusRightNavigationStrategy
	{
		get
		{
			return base.XYFocusRightNavigationStrategy;
		}
		set
		{
			base.XYFocusRightNavigationStrategy = value;
		}
	}

	public new static DependencyProperty XYFocusRightNavigationStrategyProperty { get; } = UIElement.XYFocusRightNavigationStrategyProperty;


	public new XYFocusNavigationStrategy XYFocusUpNavigationStrategy
	{
		get
		{
			return base.XYFocusUpNavigationStrategy;
		}
		set
		{
			base.XYFocusUpNavigationStrategy = value;
		}
	}

	public new static DependencyProperty XYFocusUpNavigationStrategyProperty { get; } = UIElement.XYFocusUpNavigationStrategyProperty;


	public NavigationTarget NavigationTarget
	{
		get
		{
			return (NavigationTarget)GetValue(NavigationTargetProperty);
		}
		set
		{
			SetValue(NavigationTargetProperty, value);
		}
	}

	public static DependencyProperty NavigationTargetProperty { get; } = DependencyProperty.Register("NavigationTarget", typeof(NavigationTarget), typeof(Hyperlink), new FrameworkPropertyMetadata(NavigationTarget.NewDocument, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Hyperlink)s).OnNavigationTargetChanged(e);
	}));


	public event TypedEventHandler<Hyperlink, HyperlinkClickEventArgs> Click;

	public new event RoutedEventHandler GotFocus;

	public new event RoutedEventHandler LostFocus;

	public new bool Focus(FocusState value)
	{
		if (value == FocusState.Unfocused)
		{
			throw new ArgumentOutOfRangeException("value", "Focus method does not allow FocusState.Unfocused");
		}
		if (this == null)
		{
			return false;
		}
		DependencyObject target = null;
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
		if (focusManagerForElement == null)
		{
			return false;
		}
		if (IsFocusable())
		{
			target = this;
		}
		FocusMovementResult focusMovementResult = focusManagerForElement.SetFocusedElement(new FocusMovement(target, FocusNavigationDirection.None, value));
		return focusMovementResult.WasMoved;
	}

	internal void OnGotFocus(RoutedEventArgs args)
	{
		this.GotFocus?.Invoke(this, args);
	}

	internal void OnLostFocus(RoutedEventArgs args)
	{
		this.LostFocus?.Invoke(this, args);
	}

	private void OnNavigateUriChangedPartial(Uri newNavigateUri)
	{
		UpdateNavigationProperties(newNavigateUri, NavigationTarget);
	}

	private void OnUnderlineStyleChanged()
	{
		base.TextDecorations = ((UnderlineStyle == UnderlineStyle.Single) ? TextDecorations.Underline : TextDecorations.None);
	}

	internal void SetPointerPressed(Pointer pointer)
	{
		_pressedPointer = pointer;
		this.SetValue(TextElement.ForegroundProperty, GetPressedForeground(), DependencyPropertyValuePrecedences.Animations);
	}

	internal bool ReleasePointerPressed(Pointer pointer)
	{
		Pointer pressedPointer = _pressedPointer;
		if (pressedPointer != null && pressedPointer.Equals(pointer))
		{
			OnClick();
			_pressedPointer = null;
			this.ClearValue(TextElement.ForegroundProperty, DependencyPropertyValuePrecedences.Animations);
			return true;
		}
		return false;
	}

	internal bool AbortPointerPressed(Pointer pointer)
	{
		Pointer pressedPointer = _pressedPointer;
		if (pressedPointer != null && pressedPointer.Equals(pointer))
		{
			_pressedPointer = null;
			this.ClearValue(TextElement.ForegroundProperty, DependencyPropertyValuePrecedences.Animations);
			return true;
		}
		return false;
	}

	internal void AbortAllPointerPressed()
	{
		this.ClearValue(TextElement.ForegroundProperty, DependencyPropertyValuePrecedences.Animations);
	}

	internal void OnClick()
	{
		this.Click?.Invoke(this, new HyperlinkClickEventArgs
		{
			OriginalSource = this
		});
	}

	private Brush GetPressedForeground()
	{
		return null;
	}

	internal new bool IsFocusable()
	{
		FrameworkElement containingFrameworkElement = GetContainingFrameworkElement();
		if (containingFrameworkElement != null && containingFrameworkElement.IsEnabled && containingFrameworkElement.Visibility == Visibility.Visible && containingFrameworkElement.AreAllAncestorsVisible())
		{
			return IsTabStop;
		}
		return false;
	}

	internal IFocusable GetIFocusable()
	{
		return _focusableHelper;
	}

	public Hyperlink()
		: base("a")
	{
		UpdateNavigationProperties(null, NavigationTarget.NewDocument);
		base.PointerPressed += TextBlock.OnPointerPressed;
		base.PointerReleased += TextBlock.OnPointerReleased;
		base.PointerCaptureLost += TextBlock.OnPointerCaptureLost;
		ResourceResolver.ApplyResource(this, TextElement.ForegroundProperty, "SystemControlHyperlinkTextBrush", isThemeResourceExtension: true);
	}

	private void OnNavigationTargetChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateNavigationProperties(NavigateUri, (NavigationTarget)e.NewValue);
	}

	private void UpdateNavigationProperties(Uri navigateUri, NavigationTarget target)
	{
		string text = navigateUri?.OriginalString;
		if (string.IsNullOrWhiteSpace(text))
		{
			SetAttribute(("target", ""), ("href", "#"));
		}
		else if (target == NavigationTarget.NewDocument)
		{
			SetAttribute(("target", "_blank"), ("href", text));
		}
		else
		{
			SetAttribute(("target", ""), ("href", text));
		}
		UpdateHitTest();
	}

	internal override bool IsViewHit()
	{
		if (!(NavigateUri != null))
		{
			return base.IsViewHit();
		}
		return true;
	}
}

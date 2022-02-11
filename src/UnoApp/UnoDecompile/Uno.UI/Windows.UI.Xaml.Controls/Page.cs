using System;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI.Extensions;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Windows.UI.Xaml.Controls;

public class Page : UserControl
{
	[NotImplemented]
	public AppBar TopAppBar
	{
		get
		{
			return (AppBar)GetValue(TopAppBarProperty);
		}
		set
		{
			SetValue(TopAppBarProperty, value);
		}
	}

	[NotImplemented]
	public static DependencyProperty TopAppBarProperty { get; } = DependencyProperty.Register("TopAppBar", typeof(AppBar), typeof(Page), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext));


	[NotImplemented]
	public AppBar BottomAppBar
	{
		get
		{
			return (AppBar)GetValue(BottomAppBarProperty);
		}
		set
		{
			SetValue(BottomAppBarProperty, value);
		}
	}

	[NotImplemented]
	public static DependencyProperty BottomAppBarProperty { get; } = DependencyProperty.Register("BottomAppBar", typeof(AppBar), typeof(Page), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext));


	public Frame Frame
	{
		get
		{
			return (Frame)GetValue(FrameProperty);
		}
		internal set
		{
			SetValue(FrameProperty, value);
		}
	}

	public static DependencyProperty FrameProperty { get; } = DependencyProperty.Register("Frame", typeof(Frame), typeof(Page), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public NavigationCacheMode NavigationCacheMode { get; set; }

	public Page()
	{
		InitializeBorder();
	}

	protected internal virtual void OnNavigatedFrom(NavigationEventArgs e)
	{
	}

	protected internal virtual void OnNavigatedTo(NavigationEventArgs e)
	{
	}

	protected internal virtual void OnNavigatingFrom(NavigatingCancelEventArgs e)
	{
	}

	protected override void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateBorder();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		DependencyObject focusedElement = this.GetFocusedElement();
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
		if (focusManagerForElement == null || !focusManagerForElement.IsPluginFocused() || focusedElement != null)
		{
			return;
		}
		if (FocusProperties.IsFocusable(this))
		{
			this.SetFocusedElement(this, FocusState.Programmatic, animateIfBringIntoView: false);
			return;
		}
		DependencyObject dependencyObject = focusManagerForElement?.GetFirstFocusableElement(this);
		if (dependencyObject != null && focusManagerForElement != null)
		{
			DependencyObject spFirstFocusableElementDO = dependencyObject;
			focusManagerForElement.InitialFocus = true;
			TrySetFocusedElement(spFirstFocusableElementDO);
			focusManagerForElement.InitialFocus = false;
		}
		if (dependencyObject == null && AutomationPeer.ListenerExistsHelper(AutomationEvents.AutomationFocusChanged))
		{
			CoreServices.Instance.UIARaiseFocusChangedEventOnUIAWindow(this);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void TrySetFocusedElement(DependencyObject spFirstFocusableElementDO)
	{
		try
		{
			bool flag = this.SetFocusedElement(spFirstFocusableElementDO, FocusState.Programmatic, animateIfBringIntoView: false);
		}
		catch (Exception arg)
		{
			if (this.Log().IsEnabled(LogLevel.Error))
			{
				this.Log().LogError($"Setting initial page focus failed: {arg}");
			}
		}
	}

	private void InitializeBorder()
	{
	}

	private void UpdateBorder()
	{
		SetBorder(Thickness.Empty, null);
		SetAndObserveBackgroundBrush(base.Background);
	}
}

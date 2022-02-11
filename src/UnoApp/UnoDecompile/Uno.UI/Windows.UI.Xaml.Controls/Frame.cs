using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Windows.UI.Xaml.Controls;

public class Frame : ContentControl, INavigate
{
	private bool _isNavigating;

	private string _navigationState;

	private static readonly PagePool _pool = new PagePool();

	internal PageStackEntry CurrentEntry { get; set; }

	public int BackStackDepth
	{
		get
		{
			return (int)GetValue(BackStackDepthProperty);
		}
		private set
		{
			SetValue(BackStackDepthProperty, value);
		}
	}

	public static DependencyProperty BackStackDepthProperty { get; } = DependencyProperty.Register("BackStackDepth", typeof(int), typeof(Frame), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnBackStackDepthChanged(e);
	}));


	public IList<PageStackEntry> BackStack
	{
		get
		{
			return (IList<PageStackEntry>)GetValue(BackStackProperty);
		}
		set
		{
			SetValue(BackStackProperty, value);
		}
	}

	public static DependencyProperty BackStackProperty { get; } = DependencyProperty.Register("BackStack", typeof(IList<PageStackEntry>), typeof(Frame), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnBackStackChanged(e);
	}));


	public int CacheSize
	{
		get
		{
			return (int)GetValue(CacheSizeProperty);
		}
		set
		{
			SetValue(CacheSizeProperty, value);
		}
	}

	public static DependencyProperty CacheSizeProperty { get; } = DependencyProperty.Register("CacheSize", typeof(int), typeof(Frame), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnCacheSizeChanged(e);
	}));


	public bool CanGoBack
	{
		get
		{
			return (bool)GetValue(CanGoBackProperty);
		}
		private set
		{
			SetValue(CanGoBackProperty, value);
		}
	}

	public static DependencyProperty CanGoBackProperty { get; } = DependencyProperty.Register("CanGoBack", typeof(bool), typeof(Frame), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnCanGoBackChanged(e);
	}));


	public bool CanGoForward
	{
		get
		{
			return (bool)GetValue(CanGoForwardProperty);
		}
		private set
		{
			SetValue(CanGoForwardProperty, value);
		}
	}

	public static DependencyProperty CanGoForwardProperty { get; } = DependencyProperty.Register("CanGoForward", typeof(bool), typeof(Frame), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnCanGoForwardChanged(e);
	}));


	public Type CurrentSourcePageType => (Type)GetValue(CurrentSourcePageTypeProperty);

	public static DependencyProperty CurrentSourcePageTypeProperty { get; } = DependencyProperty.Register("CurrentSourcePageType", typeof(Type), typeof(Frame), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnCurrentSourcePageTypeChanged(e);
	}));


	public IList<PageStackEntry> ForwardStack
	{
		get
		{
			return (IList<PageStackEntry>)GetValue(ForwardStackProperty);
		}
		private set
		{
			SetValue(ForwardStackProperty, value);
		}
	}

	public static DependencyProperty ForwardStackProperty { get; } = DependencyProperty.Register("ForwardStack", typeof(IList<PageStackEntry>), typeof(Frame), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnForwardStackChanged(e);
	}));


	public Type SourcePageType
	{
		get
		{
			return (Type)GetValue(SourcePageTypeProperty);
		}
		set
		{
			SetValue(SourcePageTypeProperty, value);
		}
	}

	public static DependencyProperty SourcePageTypeProperty { get; } = DependencyProperty.Register("SourcePageType", typeof(Type), typeof(Frame), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Frame)s)?.OnSourcePageTypeChanged(e);
	}));


	public bool IsNavigationStackEnabled
	{
		get
		{
			return (bool)GetValue(IsNavigationStackEnabledProperty);
		}
		set
		{
			SetValue(IsNavigationStackEnabledProperty, value);
		}
	}

	public static DependencyProperty IsNavigationStackEnabledProperty { get; } = DependencyProperty.Register("IsNavigationStackEnabled", typeof(bool), typeof(Frame), new FrameworkPropertyMetadata(true));


	public event NavigatedEventHandler Navigated;

	public event NavigatingCancelEventHandler Navigating;

	public event NavigationFailedEventHandler NavigationFailed;

	public event NavigationStoppedEventHandler NavigationStopped;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetNavigationState(string navigationState, bool suppressNavigate)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Frame", "void Frame.SetNavigationState(string navigationState, bool suppressNavigate)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool NavigateToType(Type sourcePageType, object parameter, FrameNavigationOptions navigationOptions)
	{
		throw new NotImplementedException("The member bool Frame.NavigateToType(Type sourcePageType, object parameter, FrameNavigationOptions navigationOptions) is not implemented in Uno.");
	}

	public Frame()
	{
		ObservableCollection<PageStackEntry> observableCollection = new ObservableCollection<PageStackEntry>();
		ObservableCollection<PageStackEntry> observableCollection2 = new ObservableCollection<PageStackEntry>();
		observableCollection.CollectionChanged += delegate
		{
			CanGoBack = BackStack.Any();
			BackStackDepth = BackStack.Count;
		};
		observableCollection2.CollectionChanged += delegate
		{
			CanGoForward = ForwardStack.Any();
		};
		BackStack = observableCollection;
		ForwardStack = observableCollection2;
		base.DefaultStyleKey = typeof(Frame);
	}

	protected override void OnContentChanged(object oldValue, object newValue)
	{
		base.OnContentChanged(oldValue, newValue);
		if (newValue == null)
		{
			CurrentEntry = null;
		}
	}

	protected virtual void OnBackStackDepthChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnBackStackChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnCacheSizeChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnCanGoBackChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnCanGoForwardChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnCurrentSourcePageTypeChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnForwardStackChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnSourcePageTypeChanged(DependencyPropertyChangedEventArgs e)
	{
		if (!_isNavigating)
		{
			if (e.NewValue == null)
			{
				throw new InvalidOperationException("SourcePageType cannot be set to null. Set Content to null instead.");
			}
			Navigate((Type)e.NewValue);
		}
	}

	public string GetNavigationState()
	{
		return _navigationState;
	}

	public void GoBack()
	{
		GoBack(null);
	}

	public void GoBack(NavigationTransitionInfo transitionInfoOverride)
	{
		if (CanGoBack)
		{
			PageStackEntry pageStackEntry = BackStack.Last();
			if (transitionInfoOverride != null)
			{
				pageStackEntry.NavigationTransitionInfo = transitionInfoOverride;
			}
			else
			{
				pageStackEntry.NavigationTransitionInfo = CurrentEntry.NavigationTransitionInfo;
			}
			InnerNavigate(pageStackEntry, NavigationMode.Back);
		}
	}

	public void GoForward()
	{
		if (CanGoForward)
		{
			InnerNavigate(ForwardStack.Last(), NavigationMode.Forward);
		}
	}

	public bool Navigate(Type sourcePageType)
	{
		return Navigate(sourcePageType, null, null);
	}

	public bool Navigate(Type sourcePageType, object parameter)
	{
		return Navigate(sourcePageType, parameter, null);
	}

	public bool Navigate(Type sourcePageType, object parameter, NavigationTransitionInfo infoOverride)
	{
		PageStackEntry entry = new PageStackEntry(sourcePageType, parameter, infoOverride);
		return InnerNavigate(entry, NavigationMode.New);
	}

	private bool InnerNavigate(PageStackEntry entry, NavigationMode mode)
	{
		try
		{
			return InnerNavigateUnsafe(entry, mode);
		}
		catch (Exception ex)
		{
			this.NavigationFailed?.Invoke(this, new NavigationFailedEventArgs(entry.SourcePageType, ex));
			if (this.NavigationFailed == null)
			{
				Application.Current.RaiseRecoverableUnhandledException(new InvalidOperationException("Navigation failed", ex));
			}
			return false;
		}
		finally
		{
			_isNavigating = false;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool InnerNavigateUnsafe(PageStackEntry entry, NavigationMode mode)
	{
		_isNavigating = true;
		NavigatingCancelEventArgs navigatingCancelEventArgs = new NavigatingCancelEventArgs(mode, entry.NavigationTransitionInfo, entry.Parameter, entry.SourcePageType);
		this.Navigating?.Invoke(this, navigatingCancelEventArgs);
		if (navigatingCancelEventArgs.Cancel)
		{
			OnNavigationStopped(entry, mode);
			return false;
		}
		CurrentEntry?.Instance?.OnNavigatingFrom(navigatingCancelEventArgs);
		if (navigatingCancelEventArgs.Cancel)
		{
			OnNavigationStopped(entry, mode);
			return false;
		}
		PageStackEntry currentEntry = CurrentEntry;
		CurrentEntry = entry;
		if (mode == NavigationMode.New)
		{
			ReleasePages(ForwardStack);
		}
		if (CurrentEntry.Instance == null)
		{
			Page page = CreatePageInstanceCached(entry.SourcePageType);
			if (page == null)
			{
				return false;
			}
			page.Frame = this;
			CurrentEntry.Instance = page;
		}
		Content = CurrentEntry.Instance;
		if (IsNavigationStackEnabled)
		{
			switch (mode)
			{
			case NavigationMode.New:
				ForwardStack.Clear();
				if (currentEntry != null)
				{
					BackStack.Add(currentEntry);
				}
				break;
			case NavigationMode.Back:
				ForwardStack.Add(currentEntry);
				BackStack.Remove(CurrentEntry);
				break;
			case NavigationMode.Forward:
				BackStack.Add(currentEntry);
				ForwardStack.Remove(CurrentEntry);
				break;
			}
		}
		NavigationEventArgs e = new NavigationEventArgs(CurrentEntry.Instance, mode, entry.NavigationTransitionInfo, entry.Parameter, entry.SourcePageType, null);
		SetValue(SourcePageTypeProperty, entry.SourcePageType);
		SetValue(CurrentSourcePageTypeProperty, entry.SourcePageType);
		currentEntry?.Instance.OnNavigatedFrom(e);
		CurrentEntry.Instance.OnNavigatedTo(e);
		this.Navigated?.Invoke(this, e);
		return true;
	}

	private void ReleasePages(IList<PageStackEntry> pageStackEntries)
	{
		foreach (PageStackEntry pageStackEntry in pageStackEntries)
		{
			pageStackEntry.Instance.Frame = null;
		}
		if (!FeatureConfiguration.Page.IsPoolingEnabled)
		{
			return;
		}
		foreach (PageStackEntry pageStackEntry2 in pageStackEntries)
		{
			if (pageStackEntry2.Instance != null)
			{
				_pool.EnqueuePage(pageStackEntry2.SourcePageType, pageStackEntry2.Instance);
			}
		}
	}

	public void SetNavigationState(string navigationState)
	{
		_navigationState = navigationState;
	}

	private static Page CreatePageInstanceCached(Type sourcePageType)
	{
		return _pool.DequeuePage(sourcePageType);
	}

	internal static Page CreatePageInstance(Type sourcePageType)
	{
		if (BindingPropertyHelper.BindableMetadataProvider != null)
		{
			IBindableType bindableTypeByType = BindingPropertyHelper.BindableMetadataProvider!.GetBindableTypeByType(sourcePageType);
			if (bindableTypeByType != null)
			{
				return bindableTypeByType.CreateInstance()!() as Page;
			}
		}
		return Activator.CreateInstance(sourcePageType) as Page;
	}

	private void OnNavigationStopped(PageStackEntry entry, NavigationMode mode)
	{
		this.NavigationStopped?.Invoke(this, new NavigationEventArgs(entry.Instance, mode, entry.NavigationTransitionInfo, entry.Parameter, entry.SourcePageType, null));
	}
}

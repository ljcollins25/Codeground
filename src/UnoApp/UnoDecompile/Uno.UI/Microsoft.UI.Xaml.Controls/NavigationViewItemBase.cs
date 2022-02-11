using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewItemBase : ContentControl
{
	protected bool _fullyInitialized;

	protected const int c_itemIndentation = 31;

	protected NavigationView m_navigationView;

	private NavigationViewRepeaterPosition m_position;

	private int m_depth;

	internal NavigationViewRepeaterPosition Position
	{
		get
		{
			return m_position;
		}
		set
		{
			if (m_position != value)
			{
				m_position = value;
				OnNavigationViewItemBasePositionChanged();
			}
		}
	}

	internal new int Depth
	{
		get
		{
			return m_depth;
		}
		set
		{
			if (m_depth != value)
			{
				m_depth = value;
				OnNavigationViewItemBaseDepthChanged();
			}
		}
	}

	internal bool IsTopLevelItem { get; set; }

	internal bool CreatedByNavigationViewItemsFactory { get; set; }

	public bool IsSelected
	{
		get
		{
			return (bool)GetValue(IsSelectedProperty);
		}
		set
		{
			SetValue(IsSelectedProperty, value);
		}
	}

	public static DependencyProperty IsSelectedProperty { get; } = DependencyProperty.Register("IsSelected", typeof(bool), typeof(NavigationViewItemBase), new FrameworkPropertyMetadata(false, OnIsSelectedPropertyChanged));


	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		base.Loaded -= OnLoaded;
		base.Loaded += OnLoaded;
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		if (m_navigationView == null)
		{
			SetNavigationViewParent(SharedHelpers.GetAncestorOfType<NavigationView>(this));
		}
	}

	internal NavigationView GetNavigationView()
	{
		return m_navigationView;
	}

	protected SplitView GetSplitView()
	{
		SplitView result = null;
		NavigationView navigationView = GetNavigationView();
		if (navigationView != null)
		{
			result = navigationView.GetSplitView();
		}
		return result;
	}

	internal void SetNavigationViewParent(NavigationView navigationView)
	{
		m_navigationView = navigationView;
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == IsSelectedProperty)
		{
			OnNavigationViewItemBaseIsSelectedChanged();
		}
	}

	internal void Reinitialize()
	{
		if (!_fullyInitialized)
		{
			OnApplyTemplate();
		}
		UpdateVisualState(useTransitions: false);
	}

	protected virtual void OnNavigationViewItemBasePositionChanged()
	{
	}

	protected virtual void OnNavigationViewItemBaseDepthChanged()
	{
	}

	protected virtual void OnNavigationViewItemBaseIsSelectedChanged()
	{
	}

	private static void OnIsSelectedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationViewItemBase navigationViewItemBase = (NavigationViewItemBase)sender;
		navigationViewItemBase.OnPropertyChanged(args);
	}
}

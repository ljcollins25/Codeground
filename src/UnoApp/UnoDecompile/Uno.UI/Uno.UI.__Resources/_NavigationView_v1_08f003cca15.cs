using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC0
{
	private class _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_UnoUI__Resources_NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC0NavigationView_v1RDSC4
	{
		private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

		private ElementNameSubject _ScrollViewerSubject = new ElementNameSubject();

		private ContentPresenter ContentPresenter
		{
			get
			{
				return (ContentPresenter)_ContentPresenterSubject.ElementInstance;
			}
			set
			{
				_ContentPresenterSubject.ElementInstance = value;
			}
		}

		private ScrollViewer ScrollViewer
		{
			get
			{
				return (ScrollViewer)_ScrollViewerSubject.ElementInstance;
			}
			set
			{
				_ScrollViewerSubject.ElementInstance = value;
			}
		}

		public UIElement Build(object __ResourceOwner_125)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new ScrollViewer
			{
				IsParsing = true,
				Name = "ScrollViewer",
				Content = new ContentPresenter
				{
					IsParsing = true,
					Name = "ContentPresenter"
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentPresenter c125)
				{
					nameScope.RegisterName("ContentPresenter", c125);
					ContentPresenter = c125;
					c125.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(ContentPresenter.ContentProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
					{
						Path = "ContentTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
					{
						Path = "ContentTransitions",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(ContentPresenter.PaddingProperty, new Binding
					{
						Path = "Padding",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
					{
						Path = "HorizontalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
					{
						Path = "VerticalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
					{
						Path = "CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c125.CreationComplete();
				})
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ScrollViewer c126)
			{
				nameScope.RegisterName("ScrollViewer", c126);
				ScrollViewer = c126;
				c126.SetBinding(ScrollViewer.ZoomModeProperty, new Binding
				{
					Path = "ScrollViewer.ZoomMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c126.SetBinding(ScrollViewer.HorizontalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c126.SetBinding(ScrollViewer.HorizontalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c126.SetBinding(ScrollViewer.VerticalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c126.SetBinding(ScrollViewer.VerticalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c126, AccessibilityView.Raw);
				c126.CreationComplete();
			});
			DependencyObject dependencyObject = uIElement;
			if (dependencyObject != null)
			{
				NameScope.SetNameScope(dependencyObject, nameScope);
				nameScope.Owner = dependencyObject;
				FrameworkElementHelper.AddObjectReference(dependencyObject, this);
			}
			return uIElement;
		}
	}

	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_7_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_8_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_9_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_10_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_11_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_12_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_13_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_14_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_15_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_16_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _TopNavTopPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonPlaceholderOnTopNavSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavLeftPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _PaneHeaderOnTopPaneSubject = new ElementNameSubject();

	private ElementNameSubject _PaneTitleOnTopPaneSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavMenuItemsHostSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavMenuItemsOverflowHostSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavOverflowButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PaneCustomContentOnTopPaneSubject = new ElementNameSubject();

	private ElementNameSubject _TopPaneAutoSuggestBoxPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _TopPaneAutoSuggestAreaSubject = new ElementNameSubject();

	private ElementNameSubject _PaneFooterOnTopPaneSubject = new ElementNameSubject();

	private ElementNameSubject _TopFooterMenuItemsHostSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavGridSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavContentOverlayAreaGridSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavAreaSubject = new ElementNameSubject();

	private ElementNameSubject _PaneContentGridToggleButtonRowSubject = new ElementNameSubject();

	private ElementNameSubject _ItemsContainerRowSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPaneTopPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _PaneHeaderContentBorderRowSubject = new ElementNameSubject();

	private ElementNameSubject _PaneHeaderCloseButtonColumnSubject = new ElementNameSubject();

	private ElementNameSubject _PaneHeaderToggleButtonColumnSubject = new ElementNameSubject();

	private ElementNameSubject _PaneHeaderContentBorderSubject = new ElementNameSubject();

	private ElementNameSubject _PaneAutoSuggestBoxPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _PaneAutoSuggestButtonSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestAreaSubject = new ElementNameSubject();

	private ElementNameSubject _PaneCustomContentBorderSubject = new ElementNameSubject();

	private ElementNameSubject _MenuItemsHostSubject = new ElementNameSubject();

	private ElementNameSubject _MenuItemsScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _VisualItemsSeparatorSubject = new ElementNameSubject();

	private ElementNameSubject _FooterContentBorderSubject = new ElementNameSubject();

	private ElementNameSubject _FooterMenuItemsHostSubject = new ElementNameSubject();

	private ElementNameSubject _FooterItemsScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _ItemsContainerGridSubject = new ElementNameSubject();

	private ElementNameSubject _PaneContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _ContentTopPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _ContentLeftPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderContentSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _RootSplitViewSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneTopPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewBackButtonSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewBackButtonToolTipSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewCloseButtonSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewCloseButtonToolTipSubject = new ElementNameSubject();

	private ElementNameSubject _PaneTitleTextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PaneTitlePresenterSubject = new ElementNameSubject();

	private ElementNameSubject _PaneTitleHolderSubject = new ElementNameSubject();

	private ElementNameSubject _ButtonHolderGridSubject = new ElementNameSubject();

	private ElementNameSubject _PaneToggleButtonGridSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _CompactSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _MinimalSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavigationMinimalSubject = new ElementNameSubject();

	private ElementNameSubject _MinimalWithBackButtonSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayModeGroupSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneButtonVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneButtonCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneGroupSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderGroupSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestBoxVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestBoxCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestGroupSubject = new ElementNameSubject();

	private ElementNameSubject _NotClosedCompactSubject = new ElementNameSubject();

	private ElementNameSubject _ClosedCompactSubject = new ElementNameSubject();

	private ElementNameSubject _PaneStateGroupSubject = new ElementNameSubject();

	private ElementNameSubject _ListSizeFullSubject = new ElementNameSubject();

	private ElementNameSubject _ListSizeCompactSubject = new ElementNameSubject();

	private ElementNameSubject _PaneStateListSizeGroupSubject = new ElementNameSubject();

	private ElementNameSubject _TitleBarVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _TitleBarCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _TitleBarVisibilityGroupSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowButtonWithLabelSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowButtonNoLabelSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowLabelGroupSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonGroupSubject = new ElementNameSubject();

	private ElementNameSubject _PaneVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _PaneCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _PaneVisibilityGroupSubject = new ElementNameSubject();

	private ColumnDefinition _component_0
	{
		get
		{
			return (ColumnDefinition)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private ColumnDefinition _component_1
	{
		get
		{
			return (ColumnDefinition)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Button _component_2
	{
		get
		{
			return (Button)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private ContentControl _component_3
	{
		get
		{
			return (ContentControl)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private Grid _component_4
	{
		get
		{
			return (Grid)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private Grid _component_5
	{
		get
		{
			return (Grid)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private StackPanel _component_6
	{
		get
		{
			return (StackPanel)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private RowDefinition _component_7
	{
		get
		{
			return (RowDefinition)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private ContentControl _component_8
	{
		get
		{
			return (ContentControl)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private Button _component_9
	{
		get
		{
			return (Button)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private Grid _component_10
	{
		get
		{
			return (Grid)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private ContentControl _component_11
	{
		get
		{
			return (ContentControl)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private SplitView _component_12
	{
		get
		{
			return (SplitView)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private Button _component_13
	{
		get
		{
			return (Button)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private Button _component_14
	{
		get
		{
			return (Button)_component_14_Holder.Instance;
		}
		set
		{
			_component_14_Holder.Instance = value;
		}
	}

	private TextBlock _component_15
	{
		get
		{
			return (TextBlock)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
		}
	}

	private ContentControl _component_16
	{
		get
		{
			return (ContentControl)_component_16_Holder.Instance;
		}
		set
		{
			_component_16_Holder.Instance = value;
		}
	}

	private Grid TopNavTopPadding
	{
		get
		{
			return (Grid)_TopNavTopPaddingSubject.ElementInstance;
		}
		set
		{
			_TopNavTopPaddingSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition BackButtonPlaceholderOnTopNav
	{
		get
		{
			return (ColumnDefinition)_BackButtonPlaceholderOnTopNavSubject.ElementInstance;
		}
		set
		{
			_BackButtonPlaceholderOnTopNavSubject.ElementInstance = value;
		}
	}

	private Grid TopNavLeftPadding
	{
		get
		{
			return (Grid)_TopNavLeftPaddingSubject.ElementInstance;
		}
		set
		{
			_TopNavLeftPaddingSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneHeaderOnTopPane
	{
		get
		{
			return (ContentControl)_PaneHeaderOnTopPaneSubject.ElementInstance;
		}
		set
		{
			_PaneHeaderOnTopPaneSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneTitleOnTopPane
	{
		get
		{
			return (ContentControl)_PaneTitleOnTopPaneSubject.ElementInstance;
		}
		set
		{
			_PaneTitleOnTopPaneSubject.ElementInstance = value;
		}
	}

	private ItemsRepeater TopNavMenuItemsHost
	{
		get
		{
			return (ItemsRepeater)_TopNavMenuItemsHostSubject.ElementInstance;
		}
		set
		{
			_TopNavMenuItemsHostSubject.ElementInstance = value;
		}
	}

	private ItemsRepeater TopNavMenuItemsOverflowHost
	{
		get
		{
			return (ItemsRepeater)_TopNavMenuItemsOverflowHostSubject.ElementInstance;
		}
		set
		{
			_TopNavMenuItemsOverflowHostSubject.ElementInstance = value;
		}
	}

	private Button TopNavOverflowButton
	{
		get
		{
			return (Button)_TopNavOverflowButtonSubject.ElementInstance;
		}
		set
		{
			_TopNavOverflowButtonSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneCustomContentOnTopPane
	{
		get
		{
			return (ContentControl)_PaneCustomContentOnTopPaneSubject.ElementInstance;
		}
		set
		{
			_PaneCustomContentOnTopPaneSubject.ElementInstance = value;
		}
	}

	private ContentControl TopPaneAutoSuggestBoxPresenter
	{
		get
		{
			return (ContentControl)_TopPaneAutoSuggestBoxPresenterSubject.ElementInstance;
		}
		set
		{
			_TopPaneAutoSuggestBoxPresenterSubject.ElementInstance = value;
		}
	}

	private Grid TopPaneAutoSuggestArea
	{
		get
		{
			return (Grid)_TopPaneAutoSuggestAreaSubject.ElementInstance;
		}
		set
		{
			_TopPaneAutoSuggestAreaSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneFooterOnTopPane
	{
		get
		{
			return (ContentControl)_PaneFooterOnTopPaneSubject.ElementInstance;
		}
		set
		{
			_PaneFooterOnTopPaneSubject.ElementInstance = value;
		}
	}

	private ItemsRepeater TopFooterMenuItemsHost
	{
		get
		{
			return (ItemsRepeater)_TopFooterMenuItemsHostSubject.ElementInstance;
		}
		set
		{
			_TopFooterMenuItemsHostSubject.ElementInstance = value;
		}
	}

	private Grid TopNavGrid
	{
		get
		{
			return (Grid)_TopNavGridSubject.ElementInstance;
		}
		set
		{
			_TopNavGridSubject.ElementInstance = value;
		}
	}

	private Border TopNavContentOverlayAreaGrid
	{
		get
		{
			return (Border)_TopNavContentOverlayAreaGridSubject.ElementInstance;
		}
		set
		{
			_TopNavContentOverlayAreaGridSubject.ElementInstance = value;
		}
	}

	private StackPanel TopNavArea
	{
		get
		{
			return (StackPanel)_TopNavAreaSubject.ElementInstance;
		}
		set
		{
			_TopNavAreaSubject.ElementInstance = value;
		}
	}

	private RowDefinition PaneContentGridToggleButtonRow
	{
		get
		{
			return (RowDefinition)_PaneContentGridToggleButtonRowSubject.ElementInstance;
		}
		set
		{
			_PaneContentGridToggleButtonRowSubject.ElementInstance = value;
		}
	}

	private RowDefinition ItemsContainerRow
	{
		get
		{
			return (RowDefinition)_ItemsContainerRowSubject.ElementInstance;
		}
		set
		{
			_ItemsContainerRowSubject.ElementInstance = value;
		}
	}

	private Grid ContentPaneTopPadding
	{
		get
		{
			return (Grid)_ContentPaneTopPaddingSubject.ElementInstance;
		}
		set
		{
			_ContentPaneTopPaddingSubject.ElementInstance = value;
		}
	}

	private RowDefinition PaneHeaderContentBorderRow
	{
		get
		{
			return (RowDefinition)_PaneHeaderContentBorderRowSubject.ElementInstance;
		}
		set
		{
			_PaneHeaderContentBorderRowSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition PaneHeaderCloseButtonColumn
	{
		get
		{
			return (ColumnDefinition)_PaneHeaderCloseButtonColumnSubject.ElementInstance;
		}
		set
		{
			_PaneHeaderCloseButtonColumnSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition PaneHeaderToggleButtonColumn
	{
		get
		{
			return (ColumnDefinition)_PaneHeaderToggleButtonColumnSubject.ElementInstance;
		}
		set
		{
			_PaneHeaderToggleButtonColumnSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneHeaderContentBorder
	{
		get
		{
			return (ContentControl)_PaneHeaderContentBorderSubject.ElementInstance;
		}
		set
		{
			_PaneHeaderContentBorderSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneAutoSuggestBoxPresenter
	{
		get
		{
			return (ContentControl)_PaneAutoSuggestBoxPresenterSubject.ElementInstance;
		}
		set
		{
			_PaneAutoSuggestBoxPresenterSubject.ElementInstance = value;
		}
	}

	private Button PaneAutoSuggestButton
	{
		get
		{
			return (Button)_PaneAutoSuggestButtonSubject.ElementInstance;
		}
		set
		{
			_PaneAutoSuggestButtonSubject.ElementInstance = value;
		}
	}

	private Grid AutoSuggestArea
	{
		get
		{
			return (Grid)_AutoSuggestAreaSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestAreaSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneCustomContentBorder
	{
		get
		{
			return (ContentControl)_PaneCustomContentBorderSubject.ElementInstance;
		}
		set
		{
			_PaneCustomContentBorderSubject.ElementInstance = value;
		}
	}

	private ItemsRepeater MenuItemsHost
	{
		get
		{
			return (ItemsRepeater)_MenuItemsHostSubject.ElementInstance;
		}
		set
		{
			_MenuItemsHostSubject.ElementInstance = value;
		}
	}

	private ScrollViewer MenuItemsScrollViewer
	{
		get
		{
			return (ScrollViewer)_MenuItemsScrollViewerSubject.ElementInstance;
		}
		set
		{
			_MenuItemsScrollViewerSubject.ElementInstance = value;
		}
	}

	private Microsoft.UI.Xaml.Controls.NavigationViewItemSeparator VisualItemsSeparator
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.NavigationViewItemSeparator)_VisualItemsSeparatorSubject.ElementInstance;
		}
		set
		{
			_VisualItemsSeparatorSubject.ElementInstance = value;
		}
	}

	private ContentControl FooterContentBorder
	{
		get
		{
			return (ContentControl)_FooterContentBorderSubject.ElementInstance;
		}
		set
		{
			_FooterContentBorderSubject.ElementInstance = value;
		}
	}

	private ItemsRepeater FooterMenuItemsHost
	{
		get
		{
			return (ItemsRepeater)_FooterMenuItemsHostSubject.ElementInstance;
		}
		set
		{
			_FooterMenuItemsHostSubject.ElementInstance = value;
		}
	}

	private ScrollViewer FooterItemsScrollViewer
	{
		get
		{
			return (ScrollViewer)_FooterItemsScrollViewerSubject.ElementInstance;
		}
		set
		{
			_FooterItemsScrollViewerSubject.ElementInstance = value;
		}
	}

	private Grid ItemsContainerGrid
	{
		get
		{
			return (Grid)_ItemsContainerGridSubject.ElementInstance;
		}
		set
		{
			_ItemsContainerGridSubject.ElementInstance = value;
		}
	}

	private Grid PaneContentGrid
	{
		get
		{
			return (Grid)_PaneContentGridSubject.ElementInstance;
		}
		set
		{
			_PaneContentGridSubject.ElementInstance = value;
		}
	}

	private Grid ContentTopPadding
	{
		get
		{
			return (Grid)_ContentTopPaddingSubject.ElementInstance;
		}
		set
		{
			_ContentTopPaddingSubject.ElementInstance = value;
		}
	}

	private Grid ContentLeftPadding
	{
		get
		{
			return (Grid)_ContentLeftPaddingSubject.ElementInstance;
		}
		set
		{
			_ContentLeftPaddingSubject.ElementInstance = value;
		}
	}

	private ContentControl HeaderContent
	{
		get
		{
			return (ContentControl)_HeaderContentSubject.ElementInstance;
		}
		set
		{
			_HeaderContentSubject.ElementInstance = value;
		}
	}

	private Grid ContentGrid
	{
		get
		{
			return (Grid)_ContentGridSubject.ElementInstance;
		}
		set
		{
			_ContentGridSubject.ElementInstance = value;
		}
	}

	private SplitView RootSplitView
	{
		get
		{
			return (SplitView)_RootSplitViewSubject.ElementInstance;
		}
		set
		{
			_RootSplitViewSubject.ElementInstance = value;
		}
	}

	private Grid TogglePaneTopPadding
	{
		get
		{
			return (Grid)_TogglePaneTopPaddingSubject.ElementInstance;
		}
		set
		{
			_TogglePaneTopPaddingSubject.ElementInstance = value;
		}
	}

	private Button NavigationViewBackButton
	{
		get
		{
			return (Button)_NavigationViewBackButtonSubject.ElementInstance;
		}
		set
		{
			_NavigationViewBackButtonSubject.ElementInstance = value;
		}
	}

	private ToolTip NavigationViewBackButtonToolTip
	{
		get
		{
			return (ToolTip)_NavigationViewBackButtonToolTipSubject.ElementInstance;
		}
		set
		{
			_NavigationViewBackButtonToolTipSubject.ElementInstance = value;
		}
	}

	private Button NavigationViewCloseButton
	{
		get
		{
			return (Button)_NavigationViewCloseButtonSubject.ElementInstance;
		}
		set
		{
			_NavigationViewCloseButtonSubject.ElementInstance = value;
		}
	}

	private ToolTip NavigationViewCloseButtonToolTip
	{
		get
		{
			return (ToolTip)_NavigationViewCloseButtonToolTipSubject.ElementInstance;
		}
		set
		{
			_NavigationViewCloseButtonToolTipSubject.ElementInstance = value;
		}
	}

	private TextBlock PaneTitleTextBlock
	{
		get
		{
			return (TextBlock)_PaneTitleTextBlockSubject.ElementInstance;
		}
		set
		{
			_PaneTitleTextBlockSubject.ElementInstance = value;
		}
	}

	private Button TogglePaneButton
	{
		get
		{
			return (Button)_TogglePaneButtonSubject.ElementInstance;
		}
		set
		{
			_TogglePaneButtonSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneTitlePresenter
	{
		get
		{
			return (ContentControl)_PaneTitlePresenterSubject.ElementInstance;
		}
		set
		{
			_PaneTitlePresenterSubject.ElementInstance = value;
		}
	}

	private Grid PaneTitleHolder
	{
		get
		{
			return (Grid)_PaneTitleHolderSubject.ElementInstance;
		}
		set
		{
			_PaneTitleHolderSubject.ElementInstance = value;
		}
	}

	private Grid ButtonHolderGrid
	{
		get
		{
			return (Grid)_ButtonHolderGridSubject.ElementInstance;
		}
		set
		{
			_ButtonHolderGridSubject.ElementInstance = value;
		}
	}

	private Grid PaneToggleButtonGrid
	{
		get
		{
			return (Grid)_PaneToggleButtonGridSubject.ElementInstance;
		}
		set
		{
			_PaneToggleButtonGridSubject.ElementInstance = value;
		}
	}

	private Grid RootGrid
	{
		get
		{
			return (Grid)_RootGridSubject.ElementInstance;
		}
		set
		{
			_RootGridSubject.ElementInstance = value;
		}
	}

	private VisualState Compact
	{
		get
		{
			return (VisualState)_CompactSubject.ElementInstance;
		}
		set
		{
			_CompactSubject.ElementInstance = value;
		}
	}

	private VisualState Expanded
	{
		get
		{
			return (VisualState)_ExpandedSubject.ElementInstance;
		}
		set
		{
			_ExpandedSubject.ElementInstance = value;
		}
	}

	private VisualState Minimal
	{
		get
		{
			return (VisualState)_MinimalSubject.ElementInstance;
		}
		set
		{
			_MinimalSubject.ElementInstance = value;
		}
	}

	private VisualState TopNavigationMinimal
	{
		get
		{
			return (VisualState)_TopNavigationMinimalSubject.ElementInstance;
		}
		set
		{
			_TopNavigationMinimalSubject.ElementInstance = value;
		}
	}

	private VisualState MinimalWithBackButton
	{
		get
		{
			return (VisualState)_MinimalWithBackButtonSubject.ElementInstance;
		}
		set
		{
			_MinimalWithBackButtonSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DisplayModeGroup
	{
		get
		{
			return (VisualStateGroup)_DisplayModeGroupSubject.ElementInstance;
		}
		set
		{
			_DisplayModeGroupSubject.ElementInstance = value;
		}
	}

	private VisualState TogglePaneButtonVisible
	{
		get
		{
			return (VisualState)_TogglePaneButtonVisibleSubject.ElementInstance;
		}
		set
		{
			_TogglePaneButtonVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState TogglePaneButtonCollapsed
	{
		get
		{
			return (VisualState)_TogglePaneButtonCollapsedSubject.ElementInstance;
		}
		set
		{
			_TogglePaneButtonCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup TogglePaneGroup
	{
		get
		{
			return (VisualStateGroup)_TogglePaneGroupSubject.ElementInstance;
		}
		set
		{
			_TogglePaneGroupSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderVisible
	{
		get
		{
			return (VisualState)_HeaderVisibleSubject.ElementInstance;
		}
		set
		{
			_HeaderVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderCollapsed
	{
		get
		{
			return (VisualState)_HeaderCollapsedSubject.ElementInstance;
		}
		set
		{
			_HeaderCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup HeaderGroup
	{
		get
		{
			return (VisualStateGroup)_HeaderGroupSubject.ElementInstance;
		}
		set
		{
			_HeaderGroupSubject.ElementInstance = value;
		}
	}

	private VisualState AutoSuggestBoxVisible
	{
		get
		{
			return (VisualState)_AutoSuggestBoxVisibleSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestBoxVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState AutoSuggestBoxCollapsed
	{
		get
		{
			return (VisualState)_AutoSuggestBoxCollapsedSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestBoxCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup AutoSuggestGroup
	{
		get
		{
			return (VisualStateGroup)_AutoSuggestGroupSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestGroupSubject.ElementInstance = value;
		}
	}

	private VisualState NotClosedCompact
	{
		get
		{
			return (VisualState)_NotClosedCompactSubject.ElementInstance;
		}
		set
		{
			_NotClosedCompactSubject.ElementInstance = value;
		}
	}

	private VisualState ClosedCompact
	{
		get
		{
			return (VisualState)_ClosedCompactSubject.ElementInstance;
		}
		set
		{
			_ClosedCompactSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneStateGroup
	{
		get
		{
			return (VisualStateGroup)_PaneStateGroupSubject.ElementInstance;
		}
		set
		{
			_PaneStateGroupSubject.ElementInstance = value;
		}
	}

	private VisualState ListSizeFull
	{
		get
		{
			return (VisualState)_ListSizeFullSubject.ElementInstance;
		}
		set
		{
			_ListSizeFullSubject.ElementInstance = value;
		}
	}

	private VisualState ListSizeCompact
	{
		get
		{
			return (VisualState)_ListSizeCompactSubject.ElementInstance;
		}
		set
		{
			_ListSizeCompactSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneStateListSizeGroup
	{
		get
		{
			return (VisualStateGroup)_PaneStateListSizeGroupSubject.ElementInstance;
		}
		set
		{
			_PaneStateListSizeGroupSubject.ElementInstance = value;
		}
	}

	private VisualState TitleBarVisible
	{
		get
		{
			return (VisualState)_TitleBarVisibleSubject.ElementInstance;
		}
		set
		{
			_TitleBarVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState TitleBarCollapsed
	{
		get
		{
			return (VisualState)_TitleBarCollapsedSubject.ElementInstance;
		}
		set
		{
			_TitleBarCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup TitleBarVisibilityGroup
	{
		get
		{
			return (VisualStateGroup)_TitleBarVisibilityGroupSubject.ElementInstance;
		}
		set
		{
			_TitleBarVisibilityGroupSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowButtonWithLabel
	{
		get
		{
			return (VisualState)_OverflowButtonWithLabelSubject.ElementInstance;
		}
		set
		{
			_OverflowButtonWithLabelSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowButtonNoLabel
	{
		get
		{
			return (VisualState)_OverflowButtonNoLabelSubject.ElementInstance;
		}
		set
		{
			_OverflowButtonNoLabelSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup OverflowLabelGroup
	{
		get
		{
			return (VisualStateGroup)_OverflowLabelGroupSubject.ElementInstance;
		}
		set
		{
			_OverflowLabelGroupSubject.ElementInstance = value;
		}
	}

	private VisualState BackButtonVisible
	{
		get
		{
			return (VisualState)_BackButtonVisibleSubject.ElementInstance;
		}
		set
		{
			_BackButtonVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState BackButtonCollapsed
	{
		get
		{
			return (VisualState)_BackButtonCollapsedSubject.ElementInstance;
		}
		set
		{
			_BackButtonCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup BackButtonGroup
	{
		get
		{
			return (VisualStateGroup)_BackButtonGroupSubject.ElementInstance;
		}
		set
		{
			_BackButtonGroupSubject.ElementInstance = value;
		}
	}

	private VisualState PaneVisible
	{
		get
		{
			return (VisualState)_PaneVisibleSubject.ElementInstance;
		}
		set
		{
			_PaneVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState PaneCollapsed
	{
		get
		{
			return (VisualState)_PaneCollapsedSubject.ElementInstance;
		}
		set
		{
			_PaneCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneVisibilityGroup
	{
		get
		{
			return (VisualStateGroup)_PaneVisibilityGroupSubject.ElementInstance;
		}
		set
		{
			_PaneVisibilityGroupSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_42)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		Grid grid = new Grid();
		grid.IsParsing = true;
		grid.Name = "RootGrid";
		grid.Children.Add(new Grid
		{
			IsParsing = true,
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				},
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Star)
				}
			},
			Children = 
			{
				(UIElement)new StackPanel
				{
					IsParsing = true,
					Name = "TopNavArea",
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Top,
					XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled,
					Children = 
					{
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "TopNavTopPadding"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c2)
						{
							nameScope.RegisterName("TopNavTopPadding", c2);
							TopNavTopPadding = c2;
							c2.SetBinding(FrameworkElement.HeightProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.TopPadding"
							});
							c2.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.TopPaneVisibility"
							});
							c2.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "TopNavGrid",
							ColumnDefinitions = 
							{
								new ColumnDefinition().NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ColumnDefinition c3)
								{
									nameScope.RegisterName("BackButtonPlaceholderOnTopNav", c3);
									BackButtonPlaceholderOnTopNav = c3;
									ResourceResolverSingleton.Instance.ApplyResource(c3, ColumnDefinition.WidthProperty, "NavigationBackButtonWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
									_component_0 = c3;
									NameScope.SetNameScope(_component_0, nameScope);
								}),
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Star)
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ColumnDefinition c8)
								{
									ResourceResolverSingleton.Instance.ApplyResource(c8, ColumnDefinition.MinWidthProperty, "TopNavigationViewPaneCustomContentMinWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
									_component_1 = c8;
									NameScope.SetNameScope(_component_1, nameScope);
								}),
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								}
							},
							Children = 
							{
								(UIElement)new Grid
								{
									IsParsing = true,
									Name = "TopNavLeftPadding",
									Width = 0.0
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c12)
								{
									nameScope.RegisterName("TopNavLeftPadding", c12);
									TopNavLeftPadding = c12;
									Grid.SetColumn(c12, 1);
									c12.CreationComplete();
								}),
								(UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneHeaderOnTopPane",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c13)
								{
									nameScope.RegisterName("PaneHeaderOnTopPane", c13);
									PaneHeaderOnTopPane = c13;
									Grid.SetColumn(c13, 2);
									c13.CreationComplete();
								}),
								(UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneTitleOnTopPane",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c14)
								{
									nameScope.RegisterName("PaneTitleOnTopPane", c14);
									PaneTitleOnTopPane = c14;
									Grid.SetColumn(c14, 2);
									c14.CreationComplete();
								}),
								(UIElement)new ItemsRepeaterScrollHost
								{
									IsParsing = true,
									ScrollViewer = new ScrollViewer
									{
										IsParsing = true,
										Content = new ItemsRepeater
										{
											IsParsing = true,
											Name = "TopNavMenuItemsHost",
											Layout = new StackLayout
											{
												Orientation = Orientation.Horizontal
											}
										}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeater c16)
										{
											nameScope.RegisterName("TopNavMenuItemsHost", c16);
											TopNavMenuItemsHost = c16;
											AutomationProperties.SetLandmarkType(c16, AutomationLandmarkType.Navigation);
											c16.SetBinding(AutomationProperties.NameProperty, new Binding
											{
												Path = "AutomationProperties.Name",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											AutomationProperties.SetAccessibilityView(c16, AccessibilityView.Content);
											c16.CreationComplete();
										})
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ScrollViewer c17)
									{
										ScrollViewer.SetHorizontalScrollMode(c17, ScrollMode.Disabled);
										ScrollViewer.SetHorizontalScrollBarVisibility(c17, ScrollBarVisibility.Hidden);
										ScrollViewer.SetVerticalScrollMode(c17, ScrollMode.Disabled);
										ScrollViewer.SetVerticalScrollBarVisibility(c17, ScrollBarVisibility.Hidden);
										c17.CreationComplete();
									})
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeaterScrollHost c18)
								{
									Grid.SetColumn(c18, 3);
									c18.CreationComplete();
								}),
								(UIElement)new Button
								{
									IsParsing = true,
									Name = "TopNavOverflowButton",
									Content = "More",
									Flyout = new Flyout
									{
										Placement = FlyoutPlacementMode.BottomEdgeAlignedRight,
										FlyoutPresenterStyle = new Style(typeof(FlyoutPresenter))
										{
											Setters = 
											{
												(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.PaddingProperty, "TopNavigationViewOverflowMenuPadding", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, default(Thickness)).ApplyThemeResourceUpdateValues("TopNavigationViewOverflowMenuPadding", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false),
												(SetterBase)new Setter(FrameworkElement.MarginProperty, new Thickness(0.0, -4.0, 0.0, 0.0)),
												(SetterBase)new Setter(ScrollViewer.HorizontalScrollModeProperty, ScrollMode.Auto),
												(SetterBase)new Setter(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto),
												(SetterBase)new Setter(ScrollViewer.VerticalScrollModeProperty, ScrollMode.Auto),
												(SetterBase)new Setter(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto),
												(SetterBase)new Setter(ScrollViewer.ZoomModeProperty, ZoomMode.Disabled),
												(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.CornerRadiusProperty, "OverlayCornerRadius", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, default(CornerRadius)).ApplyThemeResourceUpdateValues("OverlayCornerRadius", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false),
												(SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_42, (object? __ResourceOwner_119) => new ControlTemplate(__ResourceOwner_119, (object? __owner) => new _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_UnoUI__Resources_NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC0NavigationView_v1RDSC4().Build(__owner)))
											}
										},
										Content = new ItemsRepeaterScrollHost
										{
											IsParsing = true,
											ScrollViewer = new ScrollViewer
											{
												IsParsing = true,
												Content = new ItemsRepeater
												{
													IsParsing = true,
													Name = "TopNavMenuItemsOverflowHost"
												}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeater c19)
												{
													nameScope.RegisterName("TopNavMenuItemsOverflowHost", c19);
													TopNavMenuItemsOverflowHost = c19;
													AutomationProperties.SetAccessibilityView(c19, AccessibilityView.Content);
													c19.CreationComplete();
												})
											}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ScrollViewer c20)
											{
												ScrollViewer.SetVerticalScrollBarVisibility(c20, ScrollBarVisibility.Auto);
												c20.CreationComplete();
											})
										}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeaterScrollHost c21)
										{
											c21.CreationComplete();
										})
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Flyout c22)
									{
										c22.SetBinding(FlyoutBase.ElementSoundModeProperty, new Binding
										{
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
											Path = "ElementSoundMode"
										});
									})
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Button c23)
								{
									nameScope.RegisterName("TopNavOverflowButton", c23);
									TopNavOverflowButton = c23;
									Grid.SetColumn(c23, 4);
									ResourceResolverSingleton.Instance.ApplyResource(c23, FrameworkElement.MarginProperty, "TopNavigationViewOverflowButtonMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
									ResourceResolverSingleton.Instance.ApplyResource(c23, FrameworkElement.StyleProperty, "NavigationViewOverflowButtonStyleWhenPaneOnTop", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
									c23.SetBinding(UIElement.VisibilityProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.OverflowButtonVisibility"
									});
									_component_2 = c23;
									c23.CreationComplete();
								}),
								(UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneCustomContentOnTopPane",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c24)
								{
									nameScope.RegisterName("PaneCustomContentOnTopPane", c24);
									PaneCustomContentOnTopPane = c24;
									Grid.SetColumn(c24, 5);
									c24.CreationComplete();
								}),
								(UIElement)new Grid
								{
									IsParsing = true,
									Name = "TopPaneAutoSuggestArea",
									Children = { (UIElement)new ContentControl
									{
										IsParsing = true,
										Name = "TopPaneAutoSuggestBoxPresenter",
										MinWidth = 48.0,
										IsTabStop = false,
										HorizontalContentAlignment = HorizontalAlignment.Stretch,
										VerticalContentAlignment = VerticalAlignment.Center
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c25)
									{
										nameScope.RegisterName("TopPaneAutoSuggestBoxPresenter", c25);
										TopPaneAutoSuggestBoxPresenter = c25;
										ResourceResolverSingleton.Instance.ApplyResource(c25, FrameworkElement.MarginProperty, "TopNavigationViewAutoSuggestBoxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
										_component_3 = c25;
										c25.CreationComplete();
									}) }
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c26)
								{
									nameScope.RegisterName("TopPaneAutoSuggestArea", c26);
									TopPaneAutoSuggestArea = c26;
									ResourceResolverSingleton.Instance.ApplyResource(c26, FrameworkElement.HeightProperty, "NavigationViewTopPaneHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
									Grid.SetColumn(c26, 6);
									_component_4 = c26;
									c26.CreationComplete();
								}),
								(UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneFooterOnTopPane",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c27)
								{
									nameScope.RegisterName("PaneFooterOnTopPane", c27);
									PaneFooterOnTopPane = c27;
									Grid.SetColumn(c27, 7);
									c27.CreationComplete();
								}),
								(UIElement)new ItemsRepeater
								{
									IsParsing = true,
									Name = "TopFooterMenuItemsHost",
									Layout = new StackLayout
									{
										Orientation = Orientation.Horizontal
									}
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeater c29)
								{
									nameScope.RegisterName("TopFooterMenuItemsHost", c29);
									TopFooterMenuItemsHost = c29;
									Grid.SetColumn(c29, 8);
									AutomationProperties.SetLandmarkType(c29, AutomationLandmarkType.Navigation);
									AutomationProperties.SetAccessibilityView(c29, AccessibilityView.Content);
									c29.CreationComplete();
								})
							}
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c30)
						{
							nameScope.RegisterName("TopNavGrid", c30);
							TopNavGrid = c30;
							ResourceResolverSingleton.Instance.ApplyResource(c30, FrameworkElement.HeightProperty, "NavigationViewTopPaneHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
							c30.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.TopPaneVisibility"
							});
							_component_5 = c30;
							c30.CreationComplete();
						}),
						(UIElement)new Border
						{
							IsParsing = true,
							Name = "TopNavContentOverlayAreaGrid"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Border c31)
						{
							nameScope.RegisterName("TopNavContentOverlayAreaGrid", c31);
							TopNavContentOverlayAreaGrid = c31;
							c31.SetBinding(Border.ChildProperty, new Binding
							{
								Path = "ContentOverlay",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c31.CreationComplete();
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(StackPanel c32)
				{
					nameScope.RegisterName("TopNavArea", c32);
					TopNavArea = c32;
					ResourceResolverSingleton.Instance.ApplyResource(c32, FrameworkElement.BackgroundProperty, "NavigationViewTopPaneBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
					Grid.SetRow(c32, 0);
					Canvas.SetZIndex(c32, 1.0);
					_component_6 = c32;
					c32.CreationComplete();
				}),
				(UIElement)new SplitView
				{
					IsParsing = true,
					Name = "RootSplitView",
					DisplayMode = SplitViewDisplayMode.Inline,
					IsTabStop = false,
					Pane = new Grid
					{
						IsParsing = true,
						Name = "PaneContentGrid",
						HorizontalAlignment = HorizontalAlignment.Left,
						RowDefinitions = 
						{
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(0.0, GridUnitType.Pixel)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(RowDefinition c35)
							{
								nameScope.RegisterName("PaneContentGridToggleButtonRow", c35);
								PaneContentGridToggleButtonRow = c35;
								ResourceResolverSingleton.Instance.ApplyResource(c35, RowDefinition.MinHeightProperty, "NavigationViewPaneHeaderRowMinHeight", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
								_component_7 = c35;
								NameScope.SetNameScope(_component_7, nameScope);
							}),
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(8.0, GridUnitType.Pixel)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Star)
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(RowDefinition c39)
							{
								nameScope.RegisterName("ItemsContainerRow", c39);
								ItemsContainerRow = c39;
							})
						},
						Children = 
						{
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "ContentPaneTopPadding"
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c40)
							{
								nameScope.RegisterName("ContentPaneTopPadding", c40);
								ContentPaneTopPadding = c40;
								c40.SetBinding(FrameworkElement.HeightProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.TopPadding"
								});
								c40.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								RowDefinitions = { new RowDefinition().NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(RowDefinition c41)
								{
									nameScope.RegisterName("PaneHeaderContentBorderRow", c41);
									PaneHeaderContentBorderRow = c41;
								}) },
								ColumnDefinitions = 
								{
									new ColumnDefinition().NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ColumnDefinition c42)
									{
										nameScope.RegisterName("PaneHeaderCloseButtonColumn", c42);
										PaneHeaderCloseButtonColumn = c42;
									}),
									new ColumnDefinition().NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ColumnDefinition c43)
									{
										nameScope.RegisterName("PaneHeaderToggleButtonColumn", c43);
										PaneHeaderToggleButtonColumn = c43;
									}),
									new ColumnDefinition
									{
										Width = new GridLength(1.0, GridUnitType.Star)
									}
								},
								Children = { (UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneHeaderContentBorder",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c45)
								{
									nameScope.RegisterName("PaneHeaderContentBorder", c45);
									PaneHeaderContentBorder = c45;
									Grid.SetColumn(c45, 2);
									c45.CreationComplete();
								}) }
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c46)
							{
								Grid.SetRow(c46, 2);
								c46.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "AutoSuggestArea",
								VerticalAlignment = VerticalAlignment.Center,
								Children = 
								{
									(UIElement)new ContentControl
									{
										IsParsing = true,
										Name = "PaneAutoSuggestBoxPresenter",
										IsTabStop = false,
										HorizontalContentAlignment = HorizontalAlignment.Stretch,
										VerticalContentAlignment = VerticalAlignment.Center
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c47)
									{
										nameScope.RegisterName("PaneAutoSuggestBoxPresenter", c47);
										PaneAutoSuggestBoxPresenter = c47;
										ResourceResolverSingleton.Instance.ApplyResource(c47, FrameworkElement.MarginProperty, "NavigationViewAutoSuggestBoxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
										_component_8 = c47;
										c47.CreationComplete();
									}),
									(UIElement)new Button
									{
										IsParsing = true,
										Name = "PaneAutoSuggestButton",
										Visibility = Visibility.Collapsed
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Button c48)
									{
										nameScope.RegisterName("PaneAutoSuggestButton", c48);
										PaneAutoSuggestButton = c48;
										ResourceResolverSingleton.Instance.ApplyResource(c48, FrameworkElement.StyleProperty, "NavigationViewPaneSearchButtonStyle", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
										c48.SetBinding(FrameworkElement.WidthProperty, new Binding
										{
											Path = "CompactPaneLength",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										_component_9 = c48;
										c48.CreationComplete();
									})
								}
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c49)
							{
								nameScope.RegisterName("AutoSuggestArea", c49);
								AutoSuggestArea = c49;
								Grid.SetRow(c49, 3);
								ResourceResolverSingleton.Instance.ApplyResource(c49, FrameworkElement.HeightProperty, "NavigationViewTopPaneHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
								_component_10 = c49;
								c49.CreationComplete();
							}),
							(UIElement)new ContentControl
							{
								IsParsing = true,
								Name = "PaneCustomContentBorder",
								IsTabStop = false,
								VerticalContentAlignment = VerticalAlignment.Stretch,
								HorizontalContentAlignment = HorizontalAlignment.Stretch
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c50)
							{
								nameScope.RegisterName("PaneCustomContentBorder", c50);
								PaneCustomContentBorder = c50;
								Grid.SetRow(c50, 4);
								c50.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "ItemsContainerGrid",
								Margin = new Thickness(0.0, 0.0, 0.0, 8.0),
								RowDefinitions = 
								{
									new RowDefinition
									{
										Height = new GridLength(1.0, GridUnitType.Star)
									},
									new RowDefinition
									{
										Height = new GridLength(1.0, GridUnitType.Auto)
									},
									new RowDefinition
									{
										Height = new GridLength(1.0, GridUnitType.Auto)
									},
									new RowDefinition
									{
										Height = new GridLength(1.0, GridUnitType.Auto)
									}
								},
								Children = 
								{
									(UIElement)new ItemsRepeaterScrollHost
									{
										IsParsing = true,
										HorizontalAlignment = HorizontalAlignment.Stretch,
										VerticalAlignment = VerticalAlignment.Stretch,
										ScrollViewer = new ScrollViewer
										{
											IsParsing = true,
											Name = "MenuItemsScrollViewer",
											TabNavigation = KeyboardNavigationMode.Local,
											Content = new ItemsRepeater
											{
												IsParsing = true,
												Name = "MenuItemsHost"
											}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeater c55)
											{
												nameScope.RegisterName("MenuItemsHost", c55);
												MenuItemsHost = c55;
												c55.SetBinding(AutomationProperties.NameProperty, new Binding
												{
													Path = "AutomationProperties.Name",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												AutomationProperties.SetAccessibilityView(c55, AccessibilityView.Content);
												c55.CreationComplete();
											})
										}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ScrollViewer c56)
										{
											nameScope.RegisterName("MenuItemsScrollViewer", c56);
											MenuItemsScrollViewer = c56;
											ScrollViewer.SetVerticalScrollBarVisibility(c56, ScrollBarVisibility.Auto);
											c56.CreationComplete();
										})
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeaterScrollHost c57)
									{
										c57.CreationComplete();
									}),
									(UIElement)new Microsoft.UI.Xaml.Controls.NavigationViewItemSeparator
									{
										IsParsing = true,
										Name = "VisualItemsSeparator",
										VerticalAlignment = VerticalAlignment.Center,
										Visibility = Visibility.Collapsed,
										HorizontalAlignment = HorizontalAlignment.Stretch
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Microsoft.UI.Xaml.Controls.NavigationViewItemSeparator c58)
									{
										nameScope.RegisterName("VisualItemsSeparator", c58);
										VisualItemsSeparator = c58;
										Grid.SetRow(c58, 1);
										c58.CreationComplete();
									}),
									(UIElement)new ContentControl
									{
										IsParsing = true,
										Name = "FooterContentBorder",
										IsTabStop = false,
										VerticalContentAlignment = VerticalAlignment.Stretch,
										HorizontalContentAlignment = HorizontalAlignment.Stretch
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c59)
									{
										nameScope.RegisterName("FooterContentBorder", c59);
										FooterContentBorder = c59;
										Grid.SetRow(c59, 2);
										c59.CreationComplete();
									}),
									(UIElement)new ItemsRepeaterScrollHost
									{
										IsParsing = true,
										ScrollViewer = new ScrollViewer
										{
											IsParsing = true,
											Name = "FooterItemsScrollViewer",
											VerticalAnchorRatio = 1.0,
											Content = new ItemsRepeater
											{
												IsParsing = true,
												Name = "FooterMenuItemsHost"
											}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeater c60)
											{
												nameScope.RegisterName("FooterMenuItemsHost", c60);
												FooterMenuItemsHost = c60;
												AutomationProperties.SetAccessibilityView(c60, AccessibilityView.Content);
												c60.CreationComplete();
											})
										}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ScrollViewer c61)
										{
											nameScope.RegisterName("FooterItemsScrollViewer", c61);
											FooterItemsScrollViewer = c61;
											ScrollViewer.SetVerticalScrollBarVisibility(c61, ScrollBarVisibility.Auto);
											c61.CreationComplete();
										})
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeaterScrollHost c62)
									{
										Grid.SetRow(c62, 3);
										c62.CreationComplete();
									})
								}
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c63)
							{
								nameScope.RegisterName("ItemsContainerGrid", c63);
								ItemsContainerGrid = c63;
								Grid.SetRow(c63, 6);
								c63.CreationComplete();
							})
						}
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c64)
					{
						nameScope.RegisterName("PaneContentGrid", c64);
						PaneContentGrid = c64;
						c64.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "TemplateSettings.LeftPaneVisibility"
						});
						c64.CreationComplete();
					}),
					Content = new Grid
					{
						IsParsing = true,
						Name = "ContentGrid",
						RowDefinitions = 
						{
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Star)
							}
						},
						ColumnDefinitions = 
						{
							new ColumnDefinition
							{
								Width = new GridLength(1.0, GridUnitType.Auto)
							},
							new ColumnDefinition
							{
								Width = new GridLength(1.0, GridUnitType.Star)
							}
						},
						Children = 
						{
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "ContentTopPadding"
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c70)
							{
								nameScope.RegisterName("ContentTopPadding", c70);
								ContentTopPadding = c70;
								Grid.SetColumnSpan(c70, 2);
								c70.SetBinding(FrameworkElement.HeightProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.TopPadding"
								});
								c70.SetBinding(UIElement.VisibilityProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.LeftPaneVisibility"
								});
								c70.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "ContentLeftPadding"
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c71)
							{
								nameScope.RegisterName("ContentLeftPadding", c71);
								ContentLeftPadding = c71;
								Grid.SetRow(c71, 1);
								c71.CreationComplete();
							}),
							(UIElement)new ContentControl
							{
								IsParsing = true,
								Name = "HeaderContent",
								IsTabStop = false,
								VerticalContentAlignment = VerticalAlignment.Stretch,
								HorizontalContentAlignment = HorizontalAlignment.Stretch
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c72)
							{
								nameScope.RegisterName("HeaderContent", c72);
								HeaderContent = c72;
								Grid.SetRow(c72, 1);
								Grid.SetColumn(c72, 1);
								ResourceResolverSingleton.Instance.ApplyResource(c72, FrameworkElement.MinHeightProperty, "PaneToggleButtonHeight", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
								c72.SetBinding(ContentControl.ContentProperty, new Binding
								{
									Path = "Header",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c72.SetBinding(ContentControl.ContentTemplateProperty, new Binding
								{
									Path = "HeaderTemplate",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								ResourceResolverSingleton.Instance.ApplyResource(c72, FrameworkElement.StyleProperty, "NavigationViewTitleHeaderContentControlTextStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
								_component_11 = c72;
								c72.CreationComplete();
							}),
							(UIElement)new ContentPresenter
							{
								IsParsing = true
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentPresenter c73)
							{
								AutomationProperties.SetLandmarkType(c73, AutomationLandmarkType.Main);
								Grid.SetRow(c73, 2);
								Grid.SetColumnSpan(c73, 2);
								c73.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Content",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c73.CreationComplete();
							})
						}
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c74)
					{
						nameScope.RegisterName("ContentGrid", c74);
						ContentGrid = c74;
						c74.CreationComplete();
					})
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(SplitView c75)
				{
					nameScope.RegisterName("RootSplitView", c75);
					RootSplitView = c75;
					c75.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c75.SetBinding(SplitView.CompactPaneLengthProperty, new Binding
					{
						Path = "CompactPaneLength",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c75.SetBinding(SplitView.IsPaneOpenProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "IsPaneOpen",
						Mode = BindingMode.TwoWay
					});
					c75.SetBinding(SplitView.OpenPaneLengthProperty, new Binding
					{
						Path = "OpenPaneLength",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c75, SplitView.PaneBackgroundProperty, "NavigationViewDefaultPaneBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
					Grid.SetRow(c75, 1);
					_component_12 = c75;
					c75.CreationComplete();
				})
			}
		}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c76)
		{
			c76.CreationComplete();
		}));
		grid.Children.Add(new Grid
		{
			IsParsing = true,
			Name = "PaneToggleButtonGrid",
			Margin = new Thickness(0.0, 0.0, 0.0, 8.0),
			HorizontalAlignment = HorizontalAlignment.Left,
			VerticalAlignment = VerticalAlignment.Top,
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				},
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				}
			},
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "TogglePaneTopPadding"
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c79)
				{
					nameScope.RegisterName("TogglePaneTopPadding", c79);
					TogglePaneTopPadding = c79;
					c79.SetBinding(FrameworkElement.HeightProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "TemplateSettings.TopPadding"
					});
					c79.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ButtonHolderGrid",
					Children = 
					{
						(UIElement)new Button
						{
							IsParsing = true,
							Name = "NavigationViewBackButton",
							VerticalAlignment = VerticalAlignment.Top
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Button c80)
						{
							nameScope.RegisterName("NavigationViewBackButton", c80);
							NavigationViewBackButton = c80;
							ResourceResolverSingleton.Instance.ApplyResource(c80, FrameworkElement.StyleProperty, "NavigationBackButtonNormalStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
							c80.SetBinding(FrameworkElement.WidthProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.PaneToggleButtonWidth"
							});
							c80.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.BackButtonVisibility"
							});
							c80.SetBinding(Control.IsEnabledProperty, new Binding
							{
								Path = "IsBackEnabled",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							ToolTipService.SetToolTip(c80, new ToolTip
							{
								IsParsing = true,
								Name = "NavigationViewBackButtonToolTip"
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ToolTip c81)
							{
								nameScope.RegisterName("NavigationViewBackButtonToolTip", c81);
								NavigationViewBackButtonToolTip = c81;
								c81.CreationComplete();
							}));
							_component_13 = c80;
							c80.CreationComplete();
						}),
						(UIElement)new Button
						{
							IsParsing = true,
							Name = "NavigationViewCloseButton",
							VerticalAlignment = VerticalAlignment.Top
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Button c82)
						{
							nameScope.RegisterName("NavigationViewCloseButton", c82);
							NavigationViewCloseButton = c82;
							ResourceResolverSingleton.Instance.ApplyResource(c82, FrameworkElement.StyleProperty, "NavigationBackButtonNormalStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
							ToolTipService.SetToolTip(c82, new ToolTip
							{
								IsParsing = true,
								Name = "NavigationViewCloseButtonToolTip"
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ToolTip c83)
							{
								nameScope.RegisterName("NavigationViewCloseButtonToolTip", c83);
								NavigationViewCloseButtonToolTip = c83;
								c83.CreationComplete();
							}));
							_component_14 = c82;
							c82.CreationComplete();
						}),
						(UIElement)new Button
						{
							IsParsing = true,
							Name = "TogglePaneButton",
							HorizontalAlignment = HorizontalAlignment.Center,
							VerticalAlignment = VerticalAlignment.Top,
							Content = new TextBlock
							{
								IsParsing = true,
								Name = "PaneTitleTextBlock",
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(TextBlock c84)
							{
								nameScope.RegisterName("PaneTitleTextBlock", c84);
								PaneTitleTextBlock = c84;
								Grid.SetColumn(c84, 0);
								c84.SetBinding(TextBlock.TextProperty, new Binding
								{
									Path = "PaneTitle",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								ResourceResolverSingleton.Instance.ApplyResource(c84, FrameworkElement.StyleProperty, "NavigationViewItemHeaderTextStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
								_component_15 = c84;
								c84.CreationComplete();
							})
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Button c85)
						{
							nameScope.RegisterName("TogglePaneButton", c85);
							TogglePaneButton = c85;
							c85.SetBinding(FrameworkElement.StyleProperty, new Binding
							{
								Path = "PaneToggleButtonStyle",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetLandmarkType(c85, AutomationLandmarkType.Navigation);
							c85.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.PaneToggleButtonVisibility"
							});
							c85.SetBinding(FrameworkElement.MinWidthProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.PaneToggleButtonWidth"
							});
							c85.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "PaneTitleHolder",
							Visibility = Visibility.Collapsed,
							Children = { (UIElement)new ContentControl
							{
								IsParsing = true,
								Name = "PaneTitlePresenter",
								IsTabStop = false,
								HorizontalContentAlignment = HorizontalAlignment.Stretch,
								VerticalContentAlignment = VerticalAlignment.Stretch
							}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentControl c86)
							{
								nameScope.RegisterName("PaneTitlePresenter", c86);
								PaneTitlePresenter = c86;
								ResourceResolverSingleton.Instance.ApplyResource(c86, FrameworkElement.MarginProperty, "NavigationViewPaneTitlePresenterMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
								_component_16 = c86;
								c86.CreationComplete();
							}) }
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c87)
						{
							nameScope.RegisterName("PaneTitleHolder", c87);
							PaneTitleHolder = c87;
							c87.CreationComplete();
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c88)
				{
					nameScope.RegisterName("ButtonHolderGrid", c88);
					ButtonHolderGrid = c88;
					Grid.SetRow(c88, 1);
					c88.CreationComplete();
				})
			}
		}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c89)
		{
			nameScope.RegisterName("PaneToggleButtonGrid", c89);
			PaneToggleButtonGrid = c89;
			Canvas.SetZIndex(c89, 100.0);
			c89.CreationComplete();
		}));
		uIElement = grid.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c90)
		{
			nameScope.RegisterName("RootGrid", c90);
			RootGrid = c90;
			VisualStateManager.SetVisualStateGroups(c90, new VisualStateGroup[10]
			{
				new VisualStateGroup
				{
					Name = "DisplayModeGroup",
					States = 
					{
						new VisualState
						{
							Name = "Compact"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c91)
						{
							nameScope.RegisterName("Compact", c91);
							Compact = c91;
						}),
						new VisualState
						{
							Name = "Expanded"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c92)
						{
							nameScope.RegisterName("Expanded", c92);
							Expanded = c92;
							MarkupHelper.SetVisualStateLazy(c92, delegate
							{
								c92.Name = "Expanded";
								c92.Setters.Add(new Setter(new TargetPropertyPath(_RootSplitViewSubject, (PropertyPath)"PaneBackground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewExpandedPaneBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewExpandedPaneBackground", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Minimal"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c93)
						{
							nameScope.RegisterName("Minimal", c93);
							Minimal = c93;
							MarkupHelper.SetVisualStateLazy(c93, delegate
							{
								c93.Name = "Minimal";
								c93.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewMinimalHeaderMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewMinimalHeaderMargin", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "TopNavigationMinimal"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c94)
						{
							nameScope.RegisterName("TopNavigationMinimal", c94);
							TopNavigationMinimal = c94;
						}),
						new VisualState
						{
							Name = "MinimalWithBackButton"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c95)
						{
							nameScope.RegisterName("MinimalWithBackButton", c95);
							MinimalWithBackButton = c95;
							MarkupHelper.SetVisualStateLazy(c95, delegate
							{
								c95.Name = "MinimalWithBackButton";
								c95.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewMinimalHeaderMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewMinimalHeaderMargin", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c96)
				{
					nameScope.RegisterName("DisplayModeGroup", c96);
					DisplayModeGroup = c96;
				}),
				new VisualStateGroup
				{
					Name = "TogglePaneGroup",
					States = 
					{
						new VisualState
						{
							Name = "TogglePaneButtonVisible"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c97)
						{
							nameScope.RegisterName("TogglePaneButtonVisible", c97);
							TogglePaneButtonVisible = c97;
						}),
						new VisualState
						{
							Name = "TogglePaneButtonCollapsed"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c98)
						{
							nameScope.RegisterName("TogglePaneButtonCollapsed", c98);
							TogglePaneButtonCollapsed = c98;
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c99)
				{
					nameScope.RegisterName("TogglePaneGroup", c99);
					TogglePaneGroup = c99;
				}),
				new VisualStateGroup
				{
					Name = "HeaderGroup",
					States = 
					{
						new VisualState
						{
							Name = "HeaderVisible"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c100)
						{
							nameScope.RegisterName("HeaderVisible", c100);
							HeaderVisible = c100;
						}),
						new VisualState
						{
							Name = "HeaderCollapsed"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c101)
						{
							nameScope.RegisterName("HeaderCollapsed", c101);
							HeaderCollapsed = c101;
							MarkupHelper.SetVisualStateLazy(c101, delegate
							{
								c101.Name = "HeaderCollapsed";
								c101.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c102)
				{
					nameScope.RegisterName("HeaderGroup", c102);
					HeaderGroup = c102;
				}),
				new VisualStateGroup
				{
					Name = "AutoSuggestGroup",
					States = 
					{
						new VisualState
						{
							Name = "AutoSuggestBoxVisible"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c103)
						{
							nameScope.RegisterName("AutoSuggestBoxVisible", c103);
							AutoSuggestBoxVisible = c103;
						}),
						new VisualState
						{
							Name = "AutoSuggestBoxCollapsed"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c104)
						{
							nameScope.RegisterName("AutoSuggestBoxCollapsed", c104);
							AutoSuggestBoxCollapsed = c104;
							MarkupHelper.SetVisualStateLazy(c104, delegate
							{
								c104.Name = "AutoSuggestBoxCollapsed";
								c104.Setters.Add(new Setter(new TargetPropertyPath(_AutoSuggestAreaSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c104.Setters.Add(new Setter(new TargetPropertyPath(_TopPaneAutoSuggestAreaSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c105)
				{
					nameScope.RegisterName("AutoSuggestGroup", c105);
					AutoSuggestGroup = c105;
				}),
				new VisualStateGroup
				{
					Name = "PaneStateGroup",
					States = 
					{
						new VisualState
						{
							Name = "NotClosedCompact"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c106)
						{
							nameScope.RegisterName("NotClosedCompact", c106);
							NotClosedCompact = c106;
						}),
						new VisualState
						{
							Name = "ClosedCompact"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c107)
						{
							nameScope.RegisterName("ClosedCompact", c107);
							ClosedCompact = c107;
							MarkupHelper.SetVisualStateLazy(c107, delegate
							{
								c107.Name = "ClosedCompact";
								c107.Setters.Add(new Setter(new TargetPropertyPath(_PaneAutoSuggestBoxPresenterSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c107.Setters.Add(new Setter(new TargetPropertyPath(_PaneAutoSuggestButtonSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c108)
				{
					nameScope.RegisterName("PaneStateGroup", c108);
					PaneStateGroup = c108;
				}),
				new VisualStateGroup
				{
					Name = "PaneStateListSizeGroup",
					States = 
					{
						new VisualState
						{
							Name = "ListSizeFull"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c109)
						{
							nameScope.RegisterName("ListSizeFull", c109);
							ListSizeFull = c109;
						}),
						new VisualState
						{
							Name = "ListSizeCompact"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c110)
						{
							nameScope.RegisterName("ListSizeCompact", c110);
							ListSizeCompact = c110;
							MarkupHelper.SetVisualStateLazy(c110, delegate
							{
								c110.Name = "ListSizeCompact";
								c110.Setters.Add(new Setter(new TargetPropertyPath(_PaneContentGridSubject, (PropertyPath)"Width"), null).NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Setter c111)
								{
									c111.SetBinding("Value", new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "CompactPaneLength"
									});
								}));
								c110.Setters.Add(new Setter(new TargetPropertyPath(_PaneTitleTextBlockSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c110.Setters.Add(new Setter(new TargetPropertyPath(_PaneHeaderContentBorderSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c110.Setters.Add(new Setter(new TargetPropertyPath(_PaneCustomContentBorderSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c110.Setters.Add(new Setter(new TargetPropertyPath(_FooterContentBorderSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c112)
				{
					nameScope.RegisterName("PaneStateListSizeGroup", c112);
					PaneStateListSizeGroup = c112;
				}),
				new VisualStateGroup
				{
					Name = "TitleBarVisibilityGroup",
					States = 
					{
						new VisualState
						{
							Name = "TitleBarVisible"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c113)
						{
							nameScope.RegisterName("TitleBarVisible", c113);
							TitleBarVisible = c113;
						}),
						new VisualState
						{
							Name = "TitleBarCollapsed"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c114)
						{
							nameScope.RegisterName("TitleBarCollapsed", c114);
							TitleBarCollapsed = c114;
							MarkupHelper.SetVisualStateLazy(c114, delegate
							{
								c114.Name = "TitleBarCollapsed";
								c114.Setters.Add(new Setter(new TargetPropertyPath(_PaneContentGridSubject, (PropertyPath)"Margin"), "0,32,0,0"));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c115)
				{
					nameScope.RegisterName("TitleBarVisibilityGroup", c115);
					TitleBarVisibilityGroup = c115;
				}),
				new VisualStateGroup
				{
					Name = "OverflowLabelGroup",
					States = 
					{
						new VisualState
						{
							Name = "OverflowButtonWithLabel"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c116)
						{
							nameScope.RegisterName("OverflowButtonWithLabel", c116);
							OverflowButtonWithLabel = c116;
						}),
						new VisualState
						{
							Name = "OverflowButtonNoLabel"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c117)
						{
							nameScope.RegisterName("OverflowButtonNoLabel", c117);
							OverflowButtonNoLabel = c117;
							MarkupHelper.SetVisualStateLazy(c117, delegate
							{
								c117.Name = "OverflowButtonNoLabel";
								c117.Setters.Add(new Setter(new TargetPropertyPath(_TopNavOverflowButtonSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewOverflowButtonNoLabelStyleWhenPaneOnTop", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewOverflowButtonNoLabelStyleWhenPaneOnTop", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c118)
				{
					nameScope.RegisterName("OverflowLabelGroup", c118);
					OverflowLabelGroup = c118;
				}),
				new VisualStateGroup
				{
					Name = "BackButtonGroup",
					States = 
					{
						new VisualState
						{
							Name = "BackButtonVisible"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c119)
						{
							nameScope.RegisterName("BackButtonVisible", c119);
							BackButtonVisible = c119;
						}),
						new VisualState
						{
							Name = "BackButtonCollapsed"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c120)
						{
							nameScope.RegisterName("BackButtonCollapsed", c120);
							BackButtonCollapsed = c120;
							MarkupHelper.SetVisualStateLazy(c120, delegate
							{
								c120.Name = "BackButtonCollapsed";
								c120.Setters.Add(new Setter(new TargetPropertyPath(_BackButtonPlaceholderOnTopNavSubject, (PropertyPath)"Width"), "0"));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c121)
				{
					nameScope.RegisterName("BackButtonGroup", c121);
					BackButtonGroup = c121;
				}),
				new VisualStateGroup
				{
					Name = "PaneVisibilityGroup",
					States = 
					{
						new VisualState
						{
							Name = "PaneVisible"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c122)
						{
							nameScope.RegisterName("PaneVisible", c122);
							PaneVisible = c122;
						}),
						new VisualState
						{
							Name = "PaneCollapsed"
						}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c123)
						{
							nameScope.RegisterName("PaneCollapsed", c123);
							PaneCollapsed = c123;
							MarkupHelper.SetVisualStateLazy(c123, delegate
							{
								c123.Name = "PaneCollapsed";
								c123.Setters.Add(new Setter(new TargetPropertyPath(_RootSplitViewSubject, (PropertyPath)"CompactPaneLength"), "0"));
								c123.Setters.Add(new Setter(new TargetPropertyPath(_PaneToggleButtonGridSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c124)
				{
					nameScope.RegisterName("PaneVisibilityGroup", c124);
					PaneVisibilityGroup = c124;
				})
			});
			c90.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
				_component_3.UpdateResourceBindings();
				_component_4.UpdateResourceBindings();
				_component_5.UpdateResourceBindings();
				_component_6.UpdateResourceBindings();
				_component_7.UpdateResourceBindings();
				_component_8.UpdateResourceBindings();
				_component_9.UpdateResourceBindings();
				_component_10.UpdateResourceBindings();
				_component_11.UpdateResourceBindings();
				_component_12.UpdateResourceBindings();
				_component_13.UpdateResourceBindings();
				_component_14.UpdateResourceBindings();
				_component_15.UpdateResourceBindings();
				_component_16.UpdateResourceBindings();
			};
		}
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
internal class _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC1
{
	private class _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_UnoUI__Resources_NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC1NavigationView_v1RDSC5
	{
		private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

		private ElementNameSubject _ScrollViewerSubject = new ElementNameSubject();

		private ContentPresenter ContentPresenter
		{
			get
			{
				return (ContentPresenter)_ContentPresenterSubject.ElementInstance;
			}
			set
			{
				_ContentPresenterSubject.ElementInstance = value;
			}
		}

		private ScrollViewer ScrollViewer
		{
			get
			{
				return (ScrollViewer)_ScrollViewerSubject.ElementInstance;
			}
			set
			{
				_ScrollViewerSubject.ElementInstance = value;
			}
		}

		public UIElement Build(object __ResourceOwner_149)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new ScrollViewer
			{
				IsParsing = true,
				Name = "ScrollViewer",
				Content = new ContentPresenter
				{
					IsParsing = true,
					Name = "ContentPresenter"
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ContentPresenter c142)
				{
					nameScope.RegisterName("ContentPresenter", c142);
					ContentPresenter = c142;
					c142.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(ContentPresenter.ContentProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
					{
						Path = "ContentTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
					{
						Path = "ContentTransitions",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(ContentPresenter.PaddingProperty, new Binding
					{
						Path = "Padding",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
					{
						Path = "HorizontalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
					{
						Path = "VerticalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
					{
						Path = "CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c142.CreationComplete();
				})
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ScrollViewer c143)
			{
				nameScope.RegisterName("ScrollViewer", c143);
				ScrollViewer = c143;
				c143.SetBinding(ScrollViewer.ZoomModeProperty, new Binding
				{
					Path = "ScrollViewer.ZoomMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c143.SetBinding(ScrollViewer.HorizontalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c143.SetBinding(ScrollViewer.HorizontalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c143.SetBinding(ScrollViewer.VerticalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c143.SetBinding(ScrollViewer.VerticalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c143, AccessibilityView.Raw);
				c143.CreationComplete();
			});
			DependencyObject dependencyObject = uIElement;
			if (dependencyObject != null)
			{
				NameScope.SetNameScope(dependencyObject, nameScope);
				nameScope.Owner = dependencyObject;
				FrameworkElementHelper.AddObjectReference(dependencyObject, this);
			}
			return uIElement;
		}
	}

	private ElementNameSubject _NavigationViewItemPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewItemMenuItemsHostSubject = new ElementNameSubject();

	private ElementNameSubject _NVIRootGridSubject = new ElementNameSubject();

	private ElementNameSubject _OnLeftNavigationSubject = new ElementNameSubject();

	private ElementNameSubject _OnLeftNavigationRevealSubject = new ElementNameSubject();

	private ElementNameSubject _OnTopNavigationPrimarySubject = new ElementNameSubject();

	private ElementNameSubject _OnTopNavigationPrimaryRevealSubject = new ElementNameSubject();

	private ElementNameSubject _OnTopNavigationOverflowSubject = new ElementNameSubject();

	private ElementNameSubject _ItemOnNavigationViewListPositionStatesSubject = new ElementNameSubject();

	private ElementNameSubject _FlyoutContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _FlyoutRootGridSubject = new ElementNameSubject();

	private ElementNameSubject _ChildrenFlyoutSubject = new ElementNameSubject();

	private Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter NavigationViewItemPresenter
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter)_NavigationViewItemPresenterSubject.ElementInstance;
		}
		set
		{
			_NavigationViewItemPresenterSubject.ElementInstance = value;
		}
	}

	private ItemsRepeater NavigationViewItemMenuItemsHost
	{
		get
		{
			return (ItemsRepeater)_NavigationViewItemMenuItemsHostSubject.ElementInstance;
		}
		set
		{
			_NavigationViewItemMenuItemsHostSubject.ElementInstance = value;
		}
	}

	private Grid NVIRootGrid
	{
		get
		{
			return (Grid)_NVIRootGridSubject.ElementInstance;
		}
		set
		{
			_NVIRootGridSubject.ElementInstance = value;
		}
	}

	private VisualState OnLeftNavigation
	{
		get
		{
			return (VisualState)_OnLeftNavigationSubject.ElementInstance;
		}
		set
		{
			_OnLeftNavigationSubject.ElementInstance = value;
		}
	}

	private VisualState OnLeftNavigationReveal
	{
		get
		{
			return (VisualState)_OnLeftNavigationRevealSubject.ElementInstance;
		}
		set
		{
			_OnLeftNavigationRevealSubject.ElementInstance = value;
		}
	}

	private VisualState OnTopNavigationPrimary
	{
		get
		{
			return (VisualState)_OnTopNavigationPrimarySubject.ElementInstance;
		}
		set
		{
			_OnTopNavigationPrimarySubject.ElementInstance = value;
		}
	}

	private VisualState OnTopNavigationPrimaryReveal
	{
		get
		{
			return (VisualState)_OnTopNavigationPrimaryRevealSubject.ElementInstance;
		}
		set
		{
			_OnTopNavigationPrimaryRevealSubject.ElementInstance = value;
		}
	}

	private VisualState OnTopNavigationOverflow
	{
		get
		{
			return (VisualState)_OnTopNavigationOverflowSubject.ElementInstance;
		}
		set
		{
			_OnTopNavigationOverflowSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ItemOnNavigationViewListPositionStates
	{
		get
		{
			return (VisualStateGroup)_ItemOnNavigationViewListPositionStatesSubject.ElementInstance;
		}
		set
		{
			_ItemOnNavigationViewListPositionStatesSubject.ElementInstance = value;
		}
	}

	private Grid FlyoutContentGrid
	{
		get
		{
			return (Grid)_FlyoutContentGridSubject.ElementInstance;
		}
		set
		{
			_FlyoutContentGridSubject.ElementInstance = value;
		}
	}

	private Grid FlyoutRootGrid
	{
		get
		{
			return (Grid)_FlyoutRootGridSubject.ElementInstance;
		}
		set
		{
			_FlyoutRootGridSubject.ElementInstance = value;
		}
	}

	private Flyout ChildrenFlyout
	{
		get
		{
			return (Flyout)_ChildrenFlyoutSubject.ElementInstance;
		}
		set
		{
			_ChildrenFlyoutSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_126)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "NVIRootGrid",
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Star)
				},
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				}
			},
			Children = 
			{
				(UIElement)new Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter
				{
					IsParsing = true,
					Name = "NavigationViewItemPresenter",
					IsTabStop = false
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter c129)
				{
					nameScope.RegisterName("NavigationViewItemPresenter", c129);
					NavigationViewItemPresenter = c129;
					c129.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter.IconProperty, new Binding
					{
						Path = "Icon",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(ContentControl.ContentTransitionsProperty, new Binding
					{
						Path = "ContentTransitions",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(ContentControl.ContentTemplateProperty, new Binding
					{
						Path = "ContentTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(FrameworkElement.MarginProperty, new Binding
					{
						Path = "Margin",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(Control.PaddingProperty, new Binding
					{
						Path = "Padding",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(Control.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(Control.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(Control.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(Control.UseSystemFocusVisualsProperty, new Binding
					{
						Path = "UseSystemFocusVisuals",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
					{
						Path = "VerticalAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
					{
						Path = "HorizontalAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(Control.VerticalContentAlignmentProperty, new Binding
					{
						Path = "VerticalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(Control.HorizontalContentAlignmentProperty, new Binding
					{
						Path = "HorizontalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(ContentControl.ContentTemplateSelectorProperty, new Binding
					{
						Path = "ContentTemplateSelector",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding(ContentControl.ContentProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c129.SetBinding("primitiveContract7Present:CornerRadius", new Binding
					{
						Path = "CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					Control.SetIsTemplateFocusTarget(c129, value: true);
					c129.CreationComplete();
				}),
				(UIElement)new ItemsRepeater
				{
					IsParsing = true,
					Name = "NavigationViewItemMenuItemsHost",
					Visibility = Visibility.Collapsed,
					Layout = new StackLayout
					{
						Orientation = Orientation.Vertical
					}
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ItemsRepeater c131)
				{
					nameScope.RegisterName("NavigationViewItemMenuItemsHost", c131);
					NavigationViewItemMenuItemsHost = c131;
					Grid.SetRow(c131, 1);
					c131.CreationComplete();
				})
			}
		}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c132)
		{
			nameScope.RegisterName("NVIRootGrid", c132);
			NVIRootGrid = c132;
			VisualStateManager.SetVisualStateGroups(c132, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "ItemOnNavigationViewListPositionStates",
				States = 
				{
					new VisualState
					{
						Name = "OnLeftNavigation"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c133)
					{
						nameScope.RegisterName("OnLeftNavigation", c133);
						OnLeftNavigation = c133;
						MarkupHelper.SetVisualStateLazy(c133, delegate
						{
							c133.Name = "OnLeftNavigation";
							c133.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MUX_NavigationViewItemPresenterStyleWhenOnLeftPane", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)));
						});
					}),
					new VisualState
					{
						Name = "OnLeftNavigationReveal"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c134)
					{
						nameScope.RegisterName("OnLeftNavigationReveal", c134);
						OnLeftNavigationReveal = c134;
						MarkupHelper.SetVisualStateLazy(c134, delegate
						{
							c134.Name = "OnLeftNavigationReveal";
							c134.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MUX_NavigationViewItemPresenterStyleWhenOnLeftPaneWithRevealFocus", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)));
						});
					}),
					new VisualState
					{
						Name = "OnTopNavigationPrimary"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c135)
					{
						nameScope.RegisterName("OnTopNavigationPrimary", c135);
						OnTopNavigationPrimary = c135;
						MarkupHelper.SetVisualStateLazy(c135, delegate
						{
							c135.Name = "OnTopNavigationPrimary";
							c135.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemMargin", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c135.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MUX_NavigationViewItemPresenterStyleWhenOnTopPane", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)));
							c135.Setters.Add(new Setter(new TargetPropertyPath(_ChildrenFlyoutSubject, (PropertyPath)"Placement"), "BottomEdgeAlignedLeft"));
						});
					}),
					new VisualState
					{
						Name = "OnTopNavigationPrimaryReveal"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c136)
					{
						nameScope.RegisterName("OnTopNavigationPrimaryReveal", c136);
						OnTopNavigationPrimaryReveal = c136;
						MarkupHelper.SetVisualStateLazy(c136, delegate
						{
							c136.Name = "OnTopNavigationPrimaryReveal";
							c136.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemMargin", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c136.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MUX_NavigationViewItemPresenterStyleWhenOnTopPaneWithRevealFocus", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)));
							c136.Setters.Add(new Setter(new TargetPropertyPath(_ChildrenFlyoutSubject, (PropertyPath)"Placement"), "BottomEdgeAlignedLeft"));
						});
					}),
					new VisualState
					{
						Name = "OnTopNavigationOverflow"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c137)
					{
						nameScope.RegisterName("OnTopNavigationOverflow", c137);
						OnTopNavigationOverflow = c137;
						MarkupHelper.SetVisualStateLazy(c137, delegate
						{
							c137.Name = "OnTopNavigationOverflow";
							c137.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MUX_NavigationViewItemPresenterStyleWhenOnTopPaneOverflow", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)));
						});
					})
				}
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c138)
			{
				nameScope.RegisterName("ItemOnNavigationViewListPositionStates", c138);
				ItemOnNavigationViewListPositionStates = c138;
			}) });
			FlyoutBase.SetAttachedFlyout(c132, new Flyout
			{
				Placement = FlyoutPlacementMode.RightEdgeAlignedTop,
				FlyoutPresenterStyle = new Style(typeof(FlyoutPresenter))
				{
					Setters = 
					{
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.PaddingProperty, "NavigationViewItemChildrenMenuFlyoutPadding", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, default(Thickness)).ApplyThemeResourceUpdateValues("NavigationViewItemChildrenMenuFlyoutPadding", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false),
						(SetterBase)new Setter(FrameworkElement.MarginProperty, new Thickness(0.0, -4.0, 0.0, 0.0)),
						(SetterBase)new Setter(ScrollViewer.HorizontalScrollModeProperty, ScrollMode.Auto),
						(SetterBase)new Setter(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto),
						(SetterBase)new Setter(ScrollViewer.VerticalScrollModeProperty, ScrollMode.Auto),
						(SetterBase)new Setter(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto),
						(SetterBase)new Setter(ScrollViewer.ZoomModeProperty, ZoomMode.Disabled),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.CornerRadiusProperty, "OverlayCornerRadius", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, default(CornerRadius)).ApplyThemeResourceUpdateValues("OverlayCornerRadius", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false),
						(SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_126, (object? __ResourceOwner_148) => new ControlTemplate(__ResourceOwner_148, (object? __owner) => new _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_UnoUI__Resources_NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC1NavigationView_v1RDSC5().Build(__owner)))
					}
				},
				Content = new Grid
				{
					IsParsing = true,
					Name = "FlyoutRootGrid",
					Children = { (UIElement)new Grid
					{
						IsParsing = true,
						Name = "FlyoutContentGrid"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c139)
					{
						nameScope.RegisterName("FlyoutContentGrid", c139);
						FlyoutContentGrid = c139;
						c139.CreationComplete();
					}) }
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c140)
				{
					nameScope.RegisterName("FlyoutRootGrid", c140);
					FlyoutRootGrid = c140;
					c140.CreationComplete();
				})
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Flyout c141)
			{
				nameScope.RegisterName("ChildrenFlyout", c141);
				ChildrenFlyout = c141;
			}));
			c132.CreationComplete();
		});
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
internal class _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _HeaderTextSubject = new ElementNameSubject();

	private ElementNameSubject _InnerHeaderGridSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewItemHeaderRootGridSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderTextVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderTextCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _PaneStatesSubject = new ElementNameSubject();

	private TextBlock _component_0
	{
		get
		{
			return (TextBlock)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Grid _component_1
	{
		get
		{
			return (Grid)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private TextBlock HeaderText
	{
		get
		{
			return (TextBlock)_HeaderTextSubject.ElementInstance;
		}
		set
		{
			_HeaderTextSubject.ElementInstance = value;
		}
	}

	private Grid InnerHeaderGrid
	{
		get
		{
			return (Grid)_InnerHeaderGridSubject.ElementInstance;
		}
		set
		{
			_InnerHeaderGridSubject.ElementInstance = value;
		}
	}

	private Grid NavigationViewItemHeaderRootGrid
	{
		get
		{
			return (Grid)_NavigationViewItemHeaderRootGridSubject.ElementInstance;
		}
		set
		{
			_NavigationViewItemHeaderRootGridSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderTextVisible
	{
		get
		{
			return (VisualState)_HeaderTextVisibleSubject.ElementInstance;
		}
		set
		{
			_HeaderTextVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderTextCollapsed
	{
		get
		{
			return (VisualState)_HeaderTextCollapsedSubject.ElementInstance;
		}
		set
		{
			_HeaderTextCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneStates
	{
		get
		{
			return (VisualStateGroup)_PaneStatesSubject.ElementInstance;
		}
		set
		{
			_PaneStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_152)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "NavigationViewItemHeaderRootGrid",
			Children = { (UIElement)new Grid
			{
				IsParsing = true,
				Name = "InnerHeaderGrid",
				Height = 40.0,
				HorizontalAlignment = HorizontalAlignment.Left,
				Children = { (UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "HeaderText",
					VerticalAlignment = VerticalAlignment.Center,
					Margin = new Thickness(0.0, -1.0, 0.0, -1.0),
					TextWrapping = TextWrapping.NoWrap
				}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(TextBlock c144)
				{
					nameScope.RegisterName("HeaderText", c144);
					HeaderText = c144;
					ResourceResolverSingleton.Instance.ApplyResource(c144, FrameworkElement.StyleProperty, "NavigationViewItemHeaderTextStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
					c144.SetBinding(TextBlock.TextProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c144;
					c144.CreationComplete();
				}) }
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c145)
			{
				nameScope.RegisterName("InnerHeaderGrid", c145);
				InnerHeaderGrid = c145;
				ResourceResolverSingleton.Instance.ApplyResource(c145, FrameworkElement.MarginProperty, "NavigationViewItemInnerHeaderMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
				_component_1 = c145;
				c145.CreationComplete();
			}) }
		}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c146)
		{
			nameScope.RegisterName("NavigationViewItemHeaderRootGrid", c146);
			NavigationViewItemHeaderRootGrid = c146;
			VisualStateManager.SetVisualStateGroups(c146, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "PaneStates",
				Transitions = 
				{
					new VisualTransition
					{
						From = "HeaderTextCollapsed",
						To = "HeaderTextVisible"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualTransition c147)
					{
						MarkupHelper.SetVisualTransitionLazy(c147, delegate
						{
							c147.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "40"
										} }
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ObjectAnimationUsingKeyFrames c149)
									{
										Storyboard.SetTargetName(c149, "InnerHeaderGrid");
										Storyboard.SetTarget(c149, _InnerHeaderGridSubject);
										Storyboard.SetTargetProperty(c149, "Height");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Visible"
										} }
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ObjectAnimationUsingKeyFrames c151)
									{
										Storyboard.SetTargetName(c151, "HeaderText");
										Storyboard.SetTarget(c151, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c151, "Visibility");
									}),
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new LinearDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											},
											(DoubleKeyFrame)new LinearDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(1000000L),
												Value = 0.0
											},
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2000000L),
												KeySpline = "0.0,0.35 0.15,1.0",
												Value = 1.0
											}
										}
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(DoubleAnimationUsingKeyFrames c155)
									{
										Storyboard.SetTargetName(c155, "HeaderText");
										Storyboard.SetTarget(c155, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c155, "Opacity");
									})
								}
							};
						});
					}),
					new VisualTransition
					{
						From = "HeaderTextVisible",
						To = "HeaderTextCollapsed"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualTransition c156)
					{
						MarkupHelper.SetVisualTransitionLazy(c156, delegate
						{
							c156.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "20"
										} }
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ObjectAnimationUsingKeyFrames c158)
									{
										Storyboard.SetTargetName(c158, "InnerHeaderGrid");
										Storyboard.SetTarget(c158, _InnerHeaderGridSubject);
										Storyboard.SetTargetProperty(c158, "Height");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(2000000L),
											Value = "Collapsed"
										} }
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(ObjectAnimationUsingKeyFrames c160)
									{
										Storyboard.SetTargetName(c160, "HeaderText");
										Storyboard.SetTarget(c160, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c160, "Visibility");
									}),
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new LinearDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 1.0
											},
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(1000000L),
												KeySpline = "0.0,0.35 0.15,1.0",
												Value = 0.0
											}
										}
									}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(DoubleAnimationUsingKeyFrames c163)
									{
										Storyboard.SetTargetName(c163, "HeaderText");
										Storyboard.SetTarget(c163, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c163, "Opacity");
									})
								}
							};
						});
					})
				},
				States = 
				{
					new VisualState
					{
						Name = "HeaderTextVisible"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c164)
					{
						nameScope.RegisterName("HeaderTextVisible", c164);
						HeaderTextVisible = c164;
					}),
					new VisualState
					{
						Name = "HeaderTextCollapsed"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c165)
					{
						nameScope.RegisterName("HeaderTextCollapsed", c165);
						HeaderTextCollapsed = c165;
						MarkupHelper.SetVisualStateLazy(c165, delegate
						{
							c165.Name = "HeaderTextCollapsed";
							c165.Setters.Add(new Setter(new TargetPropertyPath(_HeaderTextSubject, (PropertyPath)"Visibility"), "Collapsed"));
							c165.Setters.Add(new Setter(new TargetPropertyPath(_InnerHeaderGridSubject, (PropertyPath)"Height"), "20"));
						});
					})
				}
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c166)
			{
				nameScope.RegisterName("PaneStates", c166);
				PaneStates = c166;
			}) });
			c146.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
			};
		}
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
internal class _NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_NavigationView_v1RDSC3
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _SeparatorLineSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewItemSeparatorRootGridSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalLineSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalLineCompactSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalLineSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationSeparatorLineStatesSubject = new ElementNameSubject();

	private Rectangle _component_0
	{
		get
		{
			return (Rectangle)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Rectangle SeparatorLine
	{
		get
		{
			return (Rectangle)_SeparatorLineSubject.ElementInstance;
		}
		set
		{
			_SeparatorLineSubject.ElementInstance = value;
		}
	}

	private Grid NavigationViewItemSeparatorRootGrid
	{
		get
		{
			return (Grid)_NavigationViewItemSeparatorRootGridSubject.ElementInstance;
		}
		set
		{
			_NavigationViewItemSeparatorRootGridSubject.ElementInstance = value;
		}
	}

	private VisualState HorizontalLine
	{
		get
		{
			return (VisualState)_HorizontalLineSubject.ElementInstance;
		}
		set
		{
			_HorizontalLineSubject.ElementInstance = value;
		}
	}

	private VisualState HorizontalLineCompact
	{
		get
		{
			return (VisualState)_HorizontalLineCompactSubject.ElementInstance;
		}
		set
		{
			_HorizontalLineCompactSubject.ElementInstance = value;
		}
	}

	private VisualState VerticalLine
	{
		get
		{
			return (VisualState)_VerticalLineSubject.ElementInstance;
		}
		set
		{
			_VerticalLineSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationSeparatorLineStates
	{
		get
		{
			return (VisualStateGroup)_NavigationSeparatorLineStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationSeparatorLineStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_155)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "NavigationViewItemSeparatorRootGrid",
			Children = { (UIElement)new Rectangle
			{
				IsParsing = true,
				Name = "SeparatorLine"
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Rectangle c167)
			{
				nameScope.RegisterName("SeparatorLine", c167);
				SeparatorLine = c167;
				ResourceResolverSingleton.Instance.ApplyResource(c167, FrameworkElement.HeightProperty, "NavigationViewItemSeparatorHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c167, FrameworkElement.MarginProperty, "NavigationViewItemSeparatorMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c167, Shape.FillProperty, "NavigationViewItemSeparatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_);
				_component_0 = c167;
				c167.CreationComplete();
			}) }
		}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(Grid c168)
		{
			nameScope.RegisterName("NavigationViewItemSeparatorRootGrid", c168);
			NavigationViewItemSeparatorRootGrid = c168;
			VisualStateManager.SetVisualStateGroups(c168, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "NavigationSeparatorLineStates",
				States = 
				{
					new VisualState
					{
						Name = "HorizontalLine"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c169)
					{
						nameScope.RegisterName("HorizontalLine", c169);
						HorizontalLine = c169;
					}),
					new VisualState
					{
						Name = "HorizontalLineCompact"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c170)
					{
						nameScope.RegisterName("HorizontalLineCompact", c170);
						HorizontalLineCompact = c170;
						MarkupHelper.SetVisualStateLazy(c170, delegate
						{
							c170.Name = "HorizontalLineCompact";
							c170.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewCompactItemSeparatorMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewCompactItemSeparatorMargin", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "VerticalLine"
					}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualState c171)
					{
						nameScope.RegisterName("VerticalLine", c171);
						VerticalLine = c171;
						MarkupHelper.SetVisualStateLazy(c171, delegate
						{
							c171.Name = "VerticalLine";
							c171.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Height"), "20"));
							c171.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Width"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemSeparatorWidth", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemSeparatorWidth", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c171.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemSeparatorMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemSeparatorMargin", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c171.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"VerticalAlignment"), "Center"));
							c171.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemSeparatorForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemSeparatorForeground", GlobalStaticResources.ResourceDictionarySingleton__44.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.NavigationView_v1_08f003cca15ad2fb5dd20512f03f5317_XamlApply(delegate(VisualStateGroup c172)
			{
				nameScope.RegisterName("NavigationSeparatorLineStates", c172);
				NavigationSeparatorLineStates = c172;
			}) });
			c168.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
			};
		}
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}

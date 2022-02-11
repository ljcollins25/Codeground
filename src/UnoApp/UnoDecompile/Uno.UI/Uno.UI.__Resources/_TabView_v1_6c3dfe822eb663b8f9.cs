using System;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _TabView_v1_6c3dfe822eb663b8f992af232e949022_TabView_v1RDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _LeftContentColumnSubject = new ElementNameSubject();

	private ElementNameSubject _TabColumnSubject = new ElementNameSubject();

	private ElementNameSubject _AddButtonColumnSubject = new ElementNameSubject();

	private ElementNameSubject _RightContentColumnSubject = new ElementNameSubject();

	private ElementNameSubject _LeftContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ShadowReceiverSubject = new ElementNameSubject();

	private ElementNameSubject _TabListViewSubject = new ElementNameSubject();

	private ElementNameSubject _AddButtonSubject = new ElementNameSubject();

	private ElementNameSubject _RightContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _TabContainerGridSubject = new ElementNameSubject();

	private ElementNameSubject _ShadowCasterSubject = new ElementNameSubject();

	private ElementNameSubject _TabContentPresenterSubject = new ElementNameSubject();

	private Button _component_0
	{
		get
		{
			return (Button)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private ColumnDefinition LeftContentColumn
	{
		get
		{
			return (ColumnDefinition)_LeftContentColumnSubject.ElementInstance;
		}
		set
		{
			_LeftContentColumnSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition TabColumn
	{
		get
		{
			return (ColumnDefinition)_TabColumnSubject.ElementInstance;
		}
		set
		{
			_TabColumnSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition AddButtonColumn
	{
		get
		{
			return (ColumnDefinition)_AddButtonColumnSubject.ElementInstance;
		}
		set
		{
			_AddButtonColumnSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition RightContentColumn
	{
		get
		{
			return (ColumnDefinition)_RightContentColumnSubject.ElementInstance;
		}
		set
		{
			_RightContentColumnSubject.ElementInstance = value;
		}
	}

	private ContentPresenter LeftContentPresenter
	{
		get
		{
			return (ContentPresenter)_LeftContentPresenterSubject.ElementInstance;
		}
		set
		{
			_LeftContentPresenterSubject.ElementInstance = value;
		}
	}

	private Grid ShadowReceiver
	{
		get
		{
			return (Grid)_ShadowReceiverSubject.ElementInstance;
		}
		set
		{
			_ShadowReceiverSubject.ElementInstance = value;
		}
	}

	private TabViewListView TabListView
	{
		get
		{
			return (TabViewListView)_TabListViewSubject.ElementInstance;
		}
		set
		{
			_TabListViewSubject.ElementInstance = value;
		}
	}

	private Button AddButton
	{
		get
		{
			return (Button)_AddButtonSubject.ElementInstance;
		}
		set
		{
			_AddButtonSubject.ElementInstance = value;
		}
	}

	private ContentPresenter RightContentPresenter
	{
		get
		{
			return (ContentPresenter)_RightContentPresenterSubject.ElementInstance;
		}
		set
		{
			_RightContentPresenterSubject.ElementInstance = value;
		}
	}

	private Grid TabContainerGrid
	{
		get
		{
			return (Grid)_TabContainerGridSubject.ElementInstance;
		}
		set
		{
			_TabContainerGridSubject.ElementInstance = value;
		}
	}

	private Grid ShadowCaster
	{
		get
		{
			return (Grid)_ShadowCasterSubject.ElementInstance;
		}
		set
		{
			_ShadowCasterSubject.ElementInstance = value;
		}
	}

	private ContentPresenter TabContentPresenter
	{
		get
		{
			return (ContentPresenter)_TabContentPresenterSubject.ElementInstance;
		}
		set
		{
			_TabContentPresenterSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2504)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
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
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "TabContainerGrid",
					XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled,
					ColumnDefinitions = 
					{
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ColumnDefinition c3)
						{
							nameScope.RegisterName("LeftContentColumn", c3);
							LeftContentColumn = c3;
						}),
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ColumnDefinition c4)
						{
							nameScope.RegisterName("TabColumn", c4);
							TabColumn = c4;
						}),
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ColumnDefinition c5)
						{
							nameScope.RegisterName("AddButtonColumn", c5);
							AddButtonColumn = c5;
						}),
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Star)
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ColumnDefinition c6)
						{
							nameScope.RegisterName("RightContentColumn", c6);
							RightContentColumn = c6;
						})
					},
					Children = 
					{
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "LeftContentPresenter"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ContentPresenter c7)
						{
							nameScope.RegisterName("LeftContentPresenter", c7);
							LeftContentPresenter = c7;
							Grid.SetColumn(c7, 0);
							c7.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "TabStripHeader",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c7.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "TabStripHeaderTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c7.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "ShadowReceiver"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Grid c8)
						{
							nameScope.RegisterName("ShadowReceiver", c8);
							ShadowReceiver = c8;
							Grid.SetColumnSpan(c8, 4);
							c8.CreationComplete();
						}),
						(UIElement)new TabViewListView
						{
							IsParsing = true,
							Name = "TabListView"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(TabViewListView c9)
						{
							nameScope.RegisterName("TabListView", c9);
							TabListView = c9;
							Grid.SetColumn(c9, 1);
							c9.SetBinding(Control.PaddingProperty, new Binding
							{
								Path = "Padding",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c9.SetBinding(ListViewBase.CanReorderItemsProperty, new Binding
							{
								Path = "CanReorderTabs",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c9.SetBinding(ListViewBase.CanDragItemsProperty, new Binding
							{
								Path = "CanDragTabs",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c9.SetBinding(UIElement.AllowDropProperty, new Binding
							{
								Path = "AllowDropTabs",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c9.SetBinding(ItemsControl.ItemsSourceProperty, new Binding
							{
								Path = "TabItemsSource",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c9.SetBinding(ItemsControl.ItemTemplateProperty, new Binding
							{
								Path = "TabItemTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c9.SetBinding(ItemsControl.ItemTemplateSelectorProperty, new Binding
							{
								Path = "TabItemTemplateSelector",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c9.CreationComplete();
						}),
						(UIElement)new Button
						{
							IsParsing = true,
							Name = "AddButton",
							Content = "\ue710",
							VerticalAlignment = VerticalAlignment.Stretch,
							IsTextScaleFactorEnabled = false,
							HighContrastAdjustment = ElementHighContrastAdjustment.None
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Button c10)
						{
							nameScope.RegisterName("AddButton", c10);
							AddButton = c10;
							Grid.SetColumn(c10, 2);
							c10.SetBinding(ButtonBase.CommandProperty, new Binding
							{
								Path = "AddTabButtonCommand",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c10.SetBinding(ButtonBase.CommandParameterProperty, new Binding
							{
								Path = "AddTabButtonCommandParameter",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c10.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								Path = "IsAddTabButtonVisible",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							ResourceResolverSingleton.Instance.ApplyResource(c10, FrameworkElement.StyleProperty, "TabViewButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							_component_0 = c10;
							c10.CreationComplete();
						}),
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "RightContentPresenter",
							HorizontalAlignment = HorizontalAlignment.Stretch
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ContentPresenter c11)
						{
							nameScope.RegisterName("RightContentPresenter", c11);
							RightContentPresenter = c11;
							Grid.SetColumn(c11, 3);
							c11.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "TabStripFooter",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c11.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "TabStripFooterTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c11.CreationComplete();
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Grid c12)
				{
					nameScope.RegisterName("TabContainerGrid", c12);
					TabContainerGrid = c12;
					c12.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c12.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ShadowCaster",
					Height = 10.0,
					Margin = new Thickness(0.0, 0.0, 0.0, -10.0),
					VerticalAlignment = VerticalAlignment.Bottom,
					Background = SolidColorBrushHelper.Transparent
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Grid c13)
				{
					nameScope.RegisterName("ShadowCaster", c13);
					ShadowCaster = c13;
					Grid.SetRow(c13, 0);
					c13.CreationComplete();
				}),
				(UIElement)new ContentPresenter
				{
					IsParsing = true,
					Name = "TabContentPresenter"
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ContentPresenter c14)
				{
					nameScope.RegisterName("TabContentPresenter", c14);
					TabContentPresenter = c14;
					Grid.SetRow(c14, 1);
					c14.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c14.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c14.CreationComplete();
				})
			}
		}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Grid c15)
		{
			c15.CreationComplete();
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
internal class _TabView_v1_6c3dfe822eb663b8f992af232e949022_TabView_v1RDSC1
{
	public UIElement Build(object __ResourceOwner_2506)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new ItemsStackPanel
		{
			IsParsing = true,
			Orientation = Orientation.Horizontal
		}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ItemsStackPanel c16)
		{
			c16.CreationComplete();
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
internal class _TabView_v1_6c3dfe822eb663b8f992af232e949022_TabView_v1RDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _TabsItemsPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollViewerSubject = new ElementNameSubject();

	private ScrollViewer _component_0
	{
		get
		{
			return (ScrollViewer)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private ItemsPresenter TabsItemsPresenter
	{
		get
		{
			return (ItemsPresenter)_TabsItemsPresenterSubject.ElementInstance;
		}
		set
		{
			_TabsItemsPresenterSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_2507)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Child = new ScrollViewer
			{
				IsParsing = true,
				Name = "ScrollViewer",
				Content = new ItemsPresenter
				{
					IsParsing = true,
					Name = "TabsItemsPresenter"
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ItemsPresenter c17)
				{
					nameScope.RegisterName("TabsItemsPresenter", c17);
					TabsItemsPresenter = c17;
					c17.SetBinding(ItemsPresenter.PaddingProperty, new Binding
					{
						Path = "Padding",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c17.CreationComplete();
				})
			}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ScrollViewer c18)
			{
				nameScope.RegisterName("ScrollViewer", c18);
				ScrollViewer = c18;
				Grid.SetColumn(c18, 1);
				AutomationProperties.SetAccessibilityView(c18, AccessibilityView.Raw);
				ScrollViewer.SetBringIntoViewOnFocusChange(c18, bringIntoViewOnFocusChange: true);
				ScrollViewer.SetHorizontalScrollBarVisibility(c18, ScrollBarVisibility.Auto);
				ScrollViewer.SetHorizontalScrollMode(c18, ScrollMode.Enabled);
				ScrollViewer.SetIsDeferredScrollingEnabled(c18, isDeferredScrollingEnabled: false);
				ScrollViewer.SetIsHorizontalRailEnabled(c18, isHorizontalRailEnabled: false);
				ScrollViewer.SetIsHorizontalScrollChainingEnabled(c18, isHorizontalScrollChainingEnabled: false);
				ScrollViewer.SetIsVerticalRailEnabled(c18, isVerticalRailEnabled: false);
				ScrollViewer.SetIsVerticalScrollChainingEnabled(c18, isVerticalScrollChainingEnabled: false);
				c18.SetBinding(Control.TabNavigationProperty, new Binding
				{
					Path = "TabNavigation",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				ScrollViewer.SetVerticalScrollBarVisibility(c18, ScrollBarVisibility.Disabled);
				ScrollViewer.SetVerticalScrollMode(c18, ScrollMode.Disabled);
				ScrollViewer.SetZoomMode(c18, ZoomMode.Disabled);
				ResourceResolverSingleton.Instance.ApplyResource(c18, FrameworkElement.StyleProperty, "TabScrollViewerStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
				_component_0 = c18;
				c18.CreationComplete();
			})
		}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Border c19)
		{
			c19.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(Border.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.CreationComplete();
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
internal class _TabView_v1_6c3dfe822eb663b8f992af232e949022_TabView_v1RDSC3
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private DiscreteObjectKeyFrame _component_0
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_1
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_2
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_3
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

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

	private VisualState Normal
	{
		get
		{
			return (VisualState)_NormalSubject.ElementInstance;
		}
		set
		{
			_NormalSubject.ElementInstance = value;
		}
	}

	private VisualState PointerOver
	{
		get
		{
			return (VisualState)_PointerOverSubject.ElementInstance;
		}
		set
		{
			_PointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState Pressed
	{
		get
		{
			return (VisualState)_PressedSubject.ElementInstance;
		}
		set
		{
			_PressedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup CommonStates
	{
		get
		{
			return (VisualStateGroup)_CommonStatesSubject.ElementInstance;
		}
		set
		{
			_CommonStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2508)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new ContentPresenter
		{
			IsParsing = true,
			Name = "ContentPresenter"
		}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ContentPresenter c20)
		{
			nameScope.RegisterName("ContentPresenter", c20);
			ContentPresenter = c20;
			AutomationProperties.SetAccessibilityView(c20, AccessibilityView.Raw);
			c20.SetBinding(ContentPresenter.BackgroundSizingProperty, new Binding
			{
				Path = "BackgroundSizing",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
			{
				Path = "ContentTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Content",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
			{
				Path = "ContentTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
			{
				Path = "HorizontalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c20.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
			{
				Path = "VerticalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c20, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c21)
					{
						nameScope.RegisterName("Normal", c21);
						Normal = c21;
						MarkupHelper.SetVisualStateLazy(c21, delegate
						{
							c21.Name = "Normal";
							c21.Storyboard = new Storyboard
							{
								Children = { (Timeline)new PointerUpThemeAnimation().TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(PointerUpThemeAnimation c22)
								{
									Storyboard.SetTargetName(c22, "ContentPresenter");
									Storyboard.SetTarget(c22, _ContentPresenterSubject);
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c23)
					{
						nameScope.RegisterName("PointerOver", c23);
						PointerOver = c23;
						MarkupHelper.SetVisualStateLazy(c23, delegate
						{
							c23.Name = "PointerOver";
							c23.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c24)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c24, ObjectKeyFrame.ValueProperty, "TabViewItemHeaderCloseButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_0 = c24;
											NameScope.SetNameScope(_component_0, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c25)
									{
										Storyboard.SetTargetName(c25, "ContentPresenter");
										Storyboard.SetTarget(c25, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c25, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c26)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c26, ObjectKeyFrame.ValueProperty, "TabViewItemHeaderCloseButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_1 = c26;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c27)
									{
										Storyboard.SetTargetName(c27, "ContentPresenter");
										Storyboard.SetTarget(c27, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c27, "Foreground");
									}),
									(Timeline)new PointerUpThemeAnimation().TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(PointerUpThemeAnimation c28)
									{
										Storyboard.SetTargetName(c28, "ContentPresenter");
										Storyboard.SetTarget(c28, _ContentPresenterSubject);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c29)
					{
						nameScope.RegisterName("Pressed", c29);
						Pressed = c29;
						MarkupHelper.SetVisualStateLazy(c29, delegate
						{
							c29.Name = "Pressed";
							c29.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c30)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c30, ObjectKeyFrame.ValueProperty, "TabViewItemHeaderCloseButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_2 = c30;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c31)
									{
										Storyboard.SetTargetName(c31, "ContentPresenter");
										Storyboard.SetTarget(c31, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c31, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c32)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c32, ObjectKeyFrame.ValueProperty, "TabViewItemHeaderCloseButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_3 = c32;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c33)
									{
										Storyboard.SetTargetName(c33, "ContentPresenter");
										Storyboard.SetTarget(c33, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c33, "Foreground");
									}),
									(Timeline)new PointerDownThemeAnimation().TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(PointerDownThemeAnimation c34)
									{
										Storyboard.SetTargetName(c34, "ContentPresenter");
										Storyboard.SetTarget(c34, _ContentPresenterSubject);
									})
								}
							};
						});
					})
				}
			}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c35)
			{
				nameScope.RegisterName("CommonStates", c35);
				CommonStates = c35;
			}) });
			c20.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
				_component_3.UpdateResourceBindings();
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
internal class _TabView_v1_6c3dfe822eb663b8f992af232e949022_TabView_v1RDSC4
{
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

	private ElementNameSubject _LeftColumnSubject = new ElementNameSubject();

	private ElementNameSubject _RightColumnSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootScaleSubject = new ElementNameSubject();

	private ElementNameSubject _LeftRadiusRenderSubject = new ElementNameSubject();

	private ElementNameSubject _RightRadiusRenderSubject = new ElementNameSubject();

	private ElementNameSubject _TabSeparatorSubject = new ElementNameSubject();

	private ElementNameSubject _IconColumnSubject = new ElementNameSubject();

	private ElementNameSubject _IconControlSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _CloseButtonSubject = new ElementNameSubject();

	private ElementNameSubject _TabContainerSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _DataAvailableSubject = new ElementNameSubject();

	private ElementNameSubject _DataPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _DataVirtualizationStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NoReorderHintSubject = new ElementNameSubject();

	private ElementNameSubject _BottomReorderHintSubject = new ElementNameSubject();

	private ElementNameSubject _TopReorderHintSubject = new ElementNameSubject();

	private ElementNameSubject _RightReorderHintSubject = new ElementNameSubject();

	private ElementNameSubject _LeftReorderHintSubject = new ElementNameSubject();

	private ElementNameSubject _ReorderHintStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NotDraggingSubject = new ElementNameSubject();

	private ElementNameSubject _DraggingSubject = new ElementNameSubject();

	private ElementNameSubject _DraggingTargetSubject = new ElementNameSubject();

	private ElementNameSubject _MultipleDraggingPrimarySubject = new ElementNameSubject();

	private ElementNameSubject _MultipleDraggingSecondarySubject = new ElementNameSubject();

	private ElementNameSubject _DraggedPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _ReorderingSubject = new ElementNameSubject();

	private ElementNameSubject _ReorderingTargetSubject = new ElementNameSubject();

	private ElementNameSubject _MultipleReorderingPrimarySubject = new ElementNameSubject();

	private ElementNameSubject _ReorderedPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _DragOverSubject = new ElementNameSubject();

	private ElementNameSubject _DragStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _NoIconSubject = new ElementNameSubject();

	private ElementNameSubject _IconStatesSubject = new ElementNameSubject();

	private ElementNameSubject _StandardWidthSubject = new ElementNameSubject();

	private ElementNameSubject _CompactSubject = new ElementNameSubject();

	private ElementNameSubject _TabWidthModesSubject = new ElementNameSubject();

	private ElementNameSubject _CloseButtonVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _CloseButtonCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _CloseIconStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ForegroundNotSetSubject = new ElementNameSubject();

	private ElementNameSubject _ForegroundSetSubject = new ElementNameSubject();

	private Path _component_0
	{
		get
		{
			return (Path)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Path _component_1
	{
		get
		{
			return (Path)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Border _component_2
	{
		get
		{
			return (Border)_component_2_Holder.Instance;
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

	private Viewbox _component_4
	{
		get
		{
			return (Viewbox)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private ContentPresenter _component_5
	{
		get
		{
			return (ContentPresenter)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private Button _component_6
	{
		get
		{
			return (Button)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private Grid _component_7
	{
		get
		{
			return (Grid)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private DragOverThemeAnimation _component_8
	{
		get
		{
			return (DragOverThemeAnimation)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private DragOverThemeAnimation _component_9
	{
		get
		{
			return (DragOverThemeAnimation)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private DragOverThemeAnimation _component_10
	{
		get
		{
			return (DragOverThemeAnimation)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private DragOverThemeAnimation _component_11
	{
		get
		{
			return (DragOverThemeAnimation)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_12
	{
		get
		{
			return (DoubleAnimation)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_13
	{
		get
		{
			return (DoubleAnimation)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_14
	{
		get
		{
			return (DoubleAnimation)_component_14_Holder.Instance;
		}
		set
		{
			_component_14_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_15
	{
		get
		{
			return (DoubleAnimation)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_16
	{
		get
		{
			return (DoubleAnimation)_component_16_Holder.Instance;
		}
		set
		{
			_component_16_Holder.Instance = value;
		}
	}

	private ColumnDefinition LeftColumn
	{
		get
		{
			return (ColumnDefinition)_LeftColumnSubject.ElementInstance;
		}
		set
		{
			_LeftColumnSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition RightColumn
	{
		get
		{
			return (ColumnDefinition)_RightColumnSubject.ElementInstance;
		}
		set
		{
			_RightColumnSubject.ElementInstance = value;
		}
	}

	private ScaleTransform LayoutRootScale
	{
		get
		{
			return (ScaleTransform)_LayoutRootScaleSubject.ElementInstance;
		}
		set
		{
			_LayoutRootScaleSubject.ElementInstance = value;
		}
	}

	private Path LeftRadiusRender
	{
		get
		{
			return (Path)_LeftRadiusRenderSubject.ElementInstance;
		}
		set
		{
			_LeftRadiusRenderSubject.ElementInstance = value;
		}
	}

	private Path RightRadiusRender
	{
		get
		{
			return (Path)_RightRadiusRenderSubject.ElementInstance;
		}
		set
		{
			_RightRadiusRenderSubject.ElementInstance = value;
		}
	}

	private Border TabSeparator
	{
		get
		{
			return (Border)_TabSeparatorSubject.ElementInstance;
		}
		set
		{
			_TabSeparatorSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition IconColumn
	{
		get
		{
			return (ColumnDefinition)_IconColumnSubject.ElementInstance;
		}
		set
		{
			_IconColumnSubject.ElementInstance = value;
		}
	}

	private ContentControl IconControl
	{
		get
		{
			return (ContentControl)_IconControlSubject.ElementInstance;
		}
		set
		{
			_IconControlSubject.ElementInstance = value;
		}
	}

	private Viewbox IconBox
	{
		get
		{
			return (Viewbox)_IconBoxSubject.ElementInstance;
		}
		set
		{
			_IconBoxSubject.ElementInstance = value;
		}
	}

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

	private Button CloseButton
	{
		get
		{
			return (Button)_CloseButtonSubject.ElementInstance;
		}
		set
		{
			_CloseButtonSubject.ElementInstance = value;
		}
	}

	private Grid TabContainer
	{
		get
		{
			return (Grid)_TabContainerSubject.ElementInstance;
		}
		set
		{
			_TabContainerSubject.ElementInstance = value;
		}
	}

	private Grid LayoutRoot
	{
		get
		{
			return (Grid)_LayoutRootSubject.ElementInstance;
		}
		set
		{
			_LayoutRootSubject.ElementInstance = value;
		}
	}

	private VisualState Normal
	{
		get
		{
			return (VisualState)_NormalSubject.ElementInstance;
		}
		set
		{
			_NormalSubject.ElementInstance = value;
		}
	}

	private VisualState PointerOver
	{
		get
		{
			return (VisualState)_PointerOverSubject.ElementInstance;
		}
		set
		{
			_PointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState Pressed
	{
		get
		{
			return (VisualState)_PressedSubject.ElementInstance;
		}
		set
		{
			_PressedSubject.ElementInstance = value;
		}
	}

	private VisualState Selected
	{
		get
		{
			return (VisualState)_SelectedSubject.ElementInstance;
		}
		set
		{
			_SelectedSubject.ElementInstance = value;
		}
	}

	private VisualState PointerOverSelected
	{
		get
		{
			return (VisualState)_PointerOverSelectedSubject.ElementInstance;
		}
		set
		{
			_PointerOverSelectedSubject.ElementInstance = value;
		}
	}

	private VisualState PressedSelected
	{
		get
		{
			return (VisualState)_PressedSelectedSubject.ElementInstance;
		}
		set
		{
			_PressedSelectedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup CommonStates
	{
		get
		{
			return (VisualStateGroup)_CommonStatesSubject.ElementInstance;
		}
		set
		{
			_CommonStatesSubject.ElementInstance = value;
		}
	}

	private VisualState Enabled
	{
		get
		{
			return (VisualState)_EnabledSubject.ElementInstance;
		}
		set
		{
			_EnabledSubject.ElementInstance = value;
		}
	}

	private VisualState Disabled
	{
		get
		{
			return (VisualState)_DisabledSubject.ElementInstance;
		}
		set
		{
			_DisabledSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DisabledStates
	{
		get
		{
			return (VisualStateGroup)_DisabledStatesSubject.ElementInstance;
		}
		set
		{
			_DisabledStatesSubject.ElementInstance = value;
		}
	}

	private VisualState DataAvailable
	{
		get
		{
			return (VisualState)_DataAvailableSubject.ElementInstance;
		}
		set
		{
			_DataAvailableSubject.ElementInstance = value;
		}
	}

	private VisualState DataPlaceholder
	{
		get
		{
			return (VisualState)_DataPlaceholderSubject.ElementInstance;
		}
		set
		{
			_DataPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DataVirtualizationStates
	{
		get
		{
			return (VisualStateGroup)_DataVirtualizationStatesSubject.ElementInstance;
		}
		set
		{
			_DataVirtualizationStatesSubject.ElementInstance = value;
		}
	}

	private VisualState NoReorderHint
	{
		get
		{
			return (VisualState)_NoReorderHintSubject.ElementInstance;
		}
		set
		{
			_NoReorderHintSubject.ElementInstance = value;
		}
	}

	private VisualState BottomReorderHint
	{
		get
		{
			return (VisualState)_BottomReorderHintSubject.ElementInstance;
		}
		set
		{
			_BottomReorderHintSubject.ElementInstance = value;
		}
	}

	private VisualState TopReorderHint
	{
		get
		{
			return (VisualState)_TopReorderHintSubject.ElementInstance;
		}
		set
		{
			_TopReorderHintSubject.ElementInstance = value;
		}
	}

	private VisualState RightReorderHint
	{
		get
		{
			return (VisualState)_RightReorderHintSubject.ElementInstance;
		}
		set
		{
			_RightReorderHintSubject.ElementInstance = value;
		}
	}

	private VisualState LeftReorderHint
	{
		get
		{
			return (VisualState)_LeftReorderHintSubject.ElementInstance;
		}
		set
		{
			_LeftReorderHintSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ReorderHintStates
	{
		get
		{
			return (VisualStateGroup)_ReorderHintStatesSubject.ElementInstance;
		}
		set
		{
			_ReorderHintStatesSubject.ElementInstance = value;
		}
	}

	private VisualState NotDragging
	{
		get
		{
			return (VisualState)_NotDraggingSubject.ElementInstance;
		}
		set
		{
			_NotDraggingSubject.ElementInstance = value;
		}
	}

	private VisualState Dragging
	{
		get
		{
			return (VisualState)_DraggingSubject.ElementInstance;
		}
		set
		{
			_DraggingSubject.ElementInstance = value;
		}
	}

	private VisualState DraggingTarget
	{
		get
		{
			return (VisualState)_DraggingTargetSubject.ElementInstance;
		}
		set
		{
			_DraggingTargetSubject.ElementInstance = value;
		}
	}

	private VisualState MultipleDraggingPrimary
	{
		get
		{
			return (VisualState)_MultipleDraggingPrimarySubject.ElementInstance;
		}
		set
		{
			_MultipleDraggingPrimarySubject.ElementInstance = value;
		}
	}

	private VisualState MultipleDraggingSecondary
	{
		get
		{
			return (VisualState)_MultipleDraggingSecondarySubject.ElementInstance;
		}
		set
		{
			_MultipleDraggingSecondarySubject.ElementInstance = value;
		}
	}

	private VisualState DraggedPlaceholder
	{
		get
		{
			return (VisualState)_DraggedPlaceholderSubject.ElementInstance;
		}
		set
		{
			_DraggedPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualState Reordering
	{
		get
		{
			return (VisualState)_ReorderingSubject.ElementInstance;
		}
		set
		{
			_ReorderingSubject.ElementInstance = value;
		}
	}

	private VisualState ReorderingTarget
	{
		get
		{
			return (VisualState)_ReorderingTargetSubject.ElementInstance;
		}
		set
		{
			_ReorderingTargetSubject.ElementInstance = value;
		}
	}

	private VisualState MultipleReorderingPrimary
	{
		get
		{
			return (VisualState)_MultipleReorderingPrimarySubject.ElementInstance;
		}
		set
		{
			_MultipleReorderingPrimarySubject.ElementInstance = value;
		}
	}

	private VisualState ReorderedPlaceholder
	{
		get
		{
			return (VisualState)_ReorderedPlaceholderSubject.ElementInstance;
		}
		set
		{
			_ReorderedPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualState DragOver
	{
		get
		{
			return (VisualState)_DragOverSubject.ElementInstance;
		}
		set
		{
			_DragOverSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DragStates
	{
		get
		{
			return (VisualStateGroup)_DragStatesSubject.ElementInstance;
		}
		set
		{
			_DragStatesSubject.ElementInstance = value;
		}
	}

	private VisualState Icon
	{
		get
		{
			return (VisualState)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
		}
	}

	private VisualState NoIcon
	{
		get
		{
			return (VisualState)_NoIconSubject.ElementInstance;
		}
		set
		{
			_NoIconSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup IconStates
	{
		get
		{
			return (VisualStateGroup)_IconStatesSubject.ElementInstance;
		}
		set
		{
			_IconStatesSubject.ElementInstance = value;
		}
	}

	private VisualState StandardWidth
	{
		get
		{
			return (VisualState)_StandardWidthSubject.ElementInstance;
		}
		set
		{
			_StandardWidthSubject.ElementInstance = value;
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

	private VisualStateGroup TabWidthModes
	{
		get
		{
			return (VisualStateGroup)_TabWidthModesSubject.ElementInstance;
		}
		set
		{
			_TabWidthModesSubject.ElementInstance = value;
		}
	}

	private VisualState CloseButtonVisible
	{
		get
		{
			return (VisualState)_CloseButtonVisibleSubject.ElementInstance;
		}
		set
		{
			_CloseButtonVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState CloseButtonCollapsed
	{
		get
		{
			return (VisualState)_CloseButtonCollapsedSubject.ElementInstance;
		}
		set
		{
			_CloseButtonCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup CloseIconStates
	{
		get
		{
			return (VisualStateGroup)_CloseIconStatesSubject.ElementInstance;
		}
		set
		{
			_CloseIconStatesSubject.ElementInstance = value;
		}
	}

	private VisualState ForegroundNotSet
	{
		get
		{
			return (VisualState)_ForegroundNotSetSubject.ElementInstance;
		}
		set
		{
			_ForegroundNotSetSubject.ElementInstance = value;
		}
	}

	private VisualState ForegroundSet
	{
		get
		{
			return (VisualState)_ForegroundSetSubject.ElementInstance;
		}
		set
		{
			_ForegroundSetSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2512)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Margin = new Thickness(-1.0, 0.0, 0.0, 0.0),
			ColumnDefinitions = 
			{
				new ColumnDefinition
				{
					Width = new GridLength(0.0, GridUnitType.Pixel)
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ColumnDefinition c36)
				{
					nameScope.RegisterName("LeftColumn", c36);
					LeftColumn = c36;
				}),
				new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Star)
				},
				new ColumnDefinition
				{
					Width = new GridLength(0.0, GridUnitType.Pixel)
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ColumnDefinition c38)
				{
					nameScope.RegisterName("RightColumn", c38);
					RightColumn = c38;
				})
			},
			RenderTransform = new ScaleTransform().TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ScaleTransform c39)
			{
				nameScope.RegisterName("LayoutRootScale", c39);
				LayoutRootScale = c39;
			}),
			Children = 
			{
				(UIElement)new ElementStub(() => new Path
				{
					IsParsing = true,
					Name = "LeftRadiusRender",
					Visibility = Visibility.Collapsed,
					VerticalAlignment = VerticalAlignment.Bottom,
					Stretch = Stretch.Uniform,
					Data = (Geometry)"M4 0 L4 4 L0 4 A4,4 90 0 0 4 0 Z"
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Path c40)
				{
					nameScope.RegisterName("LeftRadiusRender", c40);
					LeftRadiusRender = c40;
					Grid.SetColumn(c40, 0);
					c40.SetBinding(FrameworkElement.HeightProperty, new Binding
					{
						Source = ResourceResolverSingleton.Instance.ResolveResourceStatic("OverlayCornerRadius", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_),
						Path = "BottomLeft"
					});
					c40.SetBinding(FrameworkElement.MarginProperty, new Binding
					{
						Source = ResourceResolverSingleton.Instance.ResolveResourceStatic("OverlayCornerRadius", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_),
						Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewLeftInsetCornerConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c40, Shape.FillProperty, "TabViewItemHeaderBackgroundSelected", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
					_component_0 = c40;
					c40.CreationComplete();
				})).TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ElementStub c41)
				{
					c41.Name = "LeftRadiusRender";
					_LeftRadiusRenderSubject.ElementInstance = c41;
					c41.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ElementStub(() => new Path
				{
					IsParsing = true,
					Name = "RightRadiusRender",
					Visibility = Visibility.Collapsed,
					VerticalAlignment = VerticalAlignment.Bottom,
					Stretch = Stretch.Uniform,
					Data = (Geometry)"M0 0 L0 4 L4 4 A4 4 90 0 1 0 0 Z"
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Path c42)
				{
					nameScope.RegisterName("RightRadiusRender", c42);
					RightRadiusRender = c42;
					Grid.SetColumn(c42, 2);
					c42.SetBinding(FrameworkElement.HeightProperty, new Binding
					{
						Source = ResourceResolverSingleton.Instance.ResolveResourceStatic("OverlayCornerRadius", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_),
						Path = "BottomRight"
					});
					c42.SetBinding(FrameworkElement.MarginProperty, new Binding
					{
						Source = ResourceResolverSingleton.Instance.ResolveResourceStatic("OverlayCornerRadius", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_),
						Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewRightInsetCornerConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c42, Shape.FillProperty, "TabViewItemHeaderBackgroundSelected", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
					_component_1 = c42;
					c42.CreationComplete();
				})).TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ElementStub c43)
				{
					c43.Name = "RightRadiusRender";
					_RightRadiusRenderSubject.ElementInstance = c43;
					c43.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "TabSeparator",
					HorizontalAlignment = HorizontalAlignment.Right,
					Width = 1.0,
					BorderThickness = new Thickness(1.0)
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Border c44)
				{
					nameScope.RegisterName("TabSeparator", c44);
					TabSeparator = c44;
					Grid.SetColumn(c44, 1);
					ResourceResolverSingleton.Instance.ApplyResource(c44, Border.BorderBrushProperty, "TabViewItemSeparator", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c44, FrameworkElement.MarginProperty, "TabViewItemSeparatorMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
					_component_2 = c44;
					c44.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "TabContainer",
					ColumnDefinitions = 
					{
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ColumnDefinition c45)
						{
							nameScope.RegisterName("IconColumn", c45);
							IconColumn = c45;
						}),
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Star)
						},
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						}
					},
					Children = 
					{
						(UIElement)new Viewbox
						{
							IsParsing = true,
							Name = "IconBox",
							Child = new ContentControl
							{
								IsParsing = true,
								Name = "IconControl",
								IsTabStop = false,
								HighContrastAdjustment = ElementHighContrastAdjustment.None
							}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ContentControl c48)
							{
								nameScope.RegisterName("IconControl", c48);
								IconControl = c48;
								c48.SetBinding(ContentControl.ContentProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TabViewTemplateSettings.IconElement"
								});
								ResourceResolverSingleton.Instance.ApplyResource(c48, Control.ForegroundProperty, "TabViewItemIconForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
								_component_3 = c48;
								c48.CreationComplete();
							})
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Viewbox c49)
						{
							nameScope.RegisterName("IconBox", c49);
							IconBox = c49;
							ResourceResolverSingleton.Instance.ApplyResource(c49, FrameworkElement.MaxWidthProperty, "TabViewItemHeaderIconSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c49, FrameworkElement.MaxHeightProperty, "TabViewItemHeaderIconSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c49, FrameworkElement.MarginProperty, "TabViewItemHeaderIconMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							_component_4 = c49;
							c49.CreationComplete();
						}),
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter",
							Content = "",
							OpticalMarginAlignment = OpticalMarginAlignment.TrimSideBearings,
							HighContrastAdjustment = ElementHighContrastAdjustment.None
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ContentPresenter c50)
						{
							nameScope.RegisterName("ContentPresenter", c50);
							ContentPresenter = c50;
							Grid.SetColumn(c50, 1);
							c50.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
							{
								Path = "HorizontalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c50.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
							{
								Path = "VerticalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c50.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "HeaderTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c50.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c50.SetBinding(ContentPresenter.FontWeightProperty, new Binding
							{
								Path = "FontWeight",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							ResourceResolverSingleton.Instance.ApplyResource(c50, ContentPresenter.FontSizeProperty, "TabViewItemHeaderFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c50, ContentPresenter.ForegroundProperty, "TabViewItemHeaderForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							_component_5 = c50;
							c50.CreationComplete();
						}),
						(UIElement)new Button
						{
							IsParsing = true,
							Name = "CloseButton",
							Content = "\ue711",
							IsTextScaleFactorEnabled = false,
							IsTabStop = false,
							HighContrastAdjustment = ElementHighContrastAdjustment.None
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Button c51)
						{
							nameScope.RegisterName("CloseButton", c51);
							CloseButton = c51;
							Grid.SetColumn(c51, 2);
							ResourceResolverSingleton.Instance.ApplyResource(c51, FrameworkElement.WidthProperty, "TabViewItemHeaderCloseButtonSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c51, FrameworkElement.HeightProperty, "TabViewItemHeaderCloseButtonSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c51, Control.FontSizeProperty, "TabViewItemHeaderCloseFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c51, FrameworkElement.MarginProperty, "TabViewItemHeaderCloseMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c51, FrameworkElement.BackgroundProperty, "TabViewItemHeaderCloseButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c51, Control.ForegroundProperty, "TabViewItemHeaderCloseButtonForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c51, FrameworkElement.StyleProperty, "TabViewCloseButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
							_component_6 = c51;
							c51.CreationComplete();
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Grid c52)
				{
					nameScope.RegisterName("TabContainer", c52);
					TabContainer = c52;
					Grid.SetColumn(c52, 1);
					c52.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c52.SetBinding(Grid.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c52.SetBinding(Grid.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					Control.SetIsTemplateFocusTarget(c52, value: true);
					ResourceResolverSingleton.Instance.ApplyResource(c52, Grid.PaddingProperty, "TabViewItemHeaderPadding", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
					c52.SetBinding(Grid.CornerRadiusProperty, new Binding
					{
						Source = ResourceResolverSingleton.Instance.ResolveResourceStatic("OverlayCornerRadius", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_),
						Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopCornerRadiusFilterConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)
					});
					c52.SetBinding(FrameworkElement.FocusVisualMarginProperty, new Binding
					{
						Path = "FocusVisualMargin",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_7 = c52;
					c52.CreationComplete();
				})
			}
		}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Grid c53)
		{
			nameScope.RegisterName("LayoutRoot", c53);
			LayoutRoot = c53;
			c53.SetBinding(Grid.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c53, new VisualStateGroup[9]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c54)
						{
							nameScope.RegisterName("Normal", c54);
							Normal = c54;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c55)
						{
							nameScope.RegisterName("PointerOver", c55);
							PointerOver = c55;
							MarkupHelper.SetVisualStateLazy(c55, delegate
							{
								c55.Name = "PointerOver";
								c55.Setters.Add(new Setter(new TargetPropertyPath(_TabContainerSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemIconForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemIconForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderPointerOverCloseButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderPointerOverCloseButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderPointerOverCloseButtonForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderPointerOverCloseButtonForeground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c56)
						{
							nameScope.RegisterName("Pressed", c56);
							Pressed = c56;
							MarkupHelper.SetVisualStateLazy(c56, delegate
							{
								c56.Name = "Pressed";
								c56.Setters.Add(new Setter(new TargetPropertyPath(_TabContainerSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemIconForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemIconForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderPressedCloseButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderPressedCloseButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderPressedCloseButtonForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderPressedCloseButtonForeground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c57)
						{
							nameScope.RegisterName("Selected", c57);
							Selected = c57;
							MarkupHelper.SetVisualStateLazy(c57, delegate
							{
								c57.Name = "Selected";
								c57.Setters.Add(new Setter(new TargetPropertyPath(_TabContainerSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemIconForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemIconForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderSelectedCloseButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderSelectedCloseButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderSelectedCloseButtonForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderSelectedCloseButtonForeground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_LeftRadiusRenderSubject, (PropertyPath)"Visibility"), "Visible"));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_LeftRadiusRenderSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_RightRadiusRenderSubject, (PropertyPath)"Visibility"), "Visible"));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_RightRadiusRenderSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), "Transparent"));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c58)
						{
							nameScope.RegisterName("PointerOverSelected", c58);
							PointerOverSelected = c58;
							MarkupHelper.SetVisualStateLazy(c58, delegate
							{
								c58.Name = "PointerOverSelected";
								c58.Setters.Add(new Setter(new TargetPropertyPath(_TabContainerSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemIconForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemIconForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderSelectedCloseButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderSelectedCloseButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderSelectedCloseButtonForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderSelectedCloseButtonForeground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), "Transparent"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_LeftRadiusRenderSubject, (PropertyPath)"Visibility"), "Visible"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_LeftRadiusRenderSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_RightRadiusRenderSubject, (PropertyPath)"Visibility"), "Visible"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_RightRadiusRenderSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c59)
						{
							nameScope.RegisterName("PressedSelected", c59);
							PressedSelected = c59;
							MarkupHelper.SetVisualStateLazy(c59, delegate
							{
								c59.Name = "PressedSelected";
								c59.Setters.Add(new Setter(new TargetPropertyPath(_TabContainerSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemIconForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemIconForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderSelectedCloseButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderSelectedCloseButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderSelectedCloseButtonForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderSelectedCloseButtonForeground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), "Transparent"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_LeftRadiusRenderSubject, (PropertyPath)"Visibility"), "Visible"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_LeftRadiusRenderSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_RightRadiusRenderSubject, (PropertyPath)"Visibility"), "Visible"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_RightRadiusRenderSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c60)
				{
					nameScope.RegisterName("CommonStates", c60);
					CommonStates = c60;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c61)
						{
							nameScope.RegisterName("Enabled", c61);
							Enabled = c61;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c62)
						{
							nameScope.RegisterName("Disabled", c62);
							Disabled = c62;
							MarkupHelper.SetVisualStateLazy(c62, delegate
							{
								c62.Name = "Disabled";
								c62.Setters.Add(new Setter(new TargetPropertyPath(_TabContainerSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c62.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c62.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c62.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c62.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderDisabledCloseButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderDisabledCloseButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c62.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderDisabledCloseButtonForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderDisabledCloseButtonForeground", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c63)
				{
					nameScope.RegisterName("DisabledStates", c63);
					DisabledStates = c63;
				}),
				new VisualStateGroup
				{
					Name = "DataVirtualizationStates",
					States = 
					{
						new VisualState
						{
							Name = "DataAvailable"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c64)
						{
							nameScope.RegisterName("DataAvailable", c64);
							DataAvailable = c64;
						}),
						new VisualState
						{
							Name = "DataPlaceholder"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c65)
						{
							nameScope.RegisterName("DataPlaceholder", c65);
							DataPlaceholder = c65;
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c66)
				{
					nameScope.RegisterName("DataVirtualizationStates", c66);
					DataVirtualizationStates = c66;
				}),
				new VisualStateGroup
				{
					Name = "ReorderHintStates",
					Transitions = 
					{
						new VisualTransition
						{
							GeneratedDuration = new Duration(TimeSpan.FromTicks(2000000L)),
							To = "NoReorderHint"
						}
					},
					States = 
					{
						new VisualState
						{
							Name = "NoReorderHint"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c68)
						{
							nameScope.RegisterName("NoReorderHint", c68);
							NoReorderHint = c68;
						}),
						new VisualState
						{
							Name = "BottomReorderHint"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c69)
						{
							nameScope.RegisterName("BottomReorderHint", c69);
							BottomReorderHint = c69;
							MarkupHelper.SetVisualStateLazy(c69, delegate
							{
								c69.Name = "BottomReorderHint";
								c69.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DragOverThemeAnimation
									{
										Direction = AnimationDirection.Bottom,
										TargetName = "LayoutRoot"
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DragOverThemeAnimation c70)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c70, DragOverThemeAnimation.ToOffsetProperty, "ListViewItemReorderHintThemeOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
										NameScope.SetNameScope(c70, nameScope);
										_component_8 = c70;
										NameScope.SetNameScope(_component_8, nameScope);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "TopReorderHint"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c71)
						{
							nameScope.RegisterName("TopReorderHint", c71);
							TopReorderHint = c71;
							MarkupHelper.SetVisualStateLazy(c71, delegate
							{
								c71.Name = "TopReorderHint";
								c71.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DragOverThemeAnimation
									{
										Direction = AnimationDirection.Top,
										TargetName = "LayoutRoot"
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DragOverThemeAnimation c72)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c72, DragOverThemeAnimation.ToOffsetProperty, "ListViewItemReorderHintThemeOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
										NameScope.SetNameScope(c72, nameScope);
										_component_9 = c72;
										NameScope.SetNameScope(_component_9, nameScope);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "RightReorderHint"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c73)
						{
							nameScope.RegisterName("RightReorderHint", c73);
							RightReorderHint = c73;
							MarkupHelper.SetVisualStateLazy(c73, delegate
							{
								c73.Name = "RightReorderHint";
								c73.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DragOverThemeAnimation
									{
										Direction = AnimationDirection.Right,
										TargetName = "LayoutRoot"
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DragOverThemeAnimation c74)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c74, DragOverThemeAnimation.ToOffsetProperty, "ListViewItemReorderHintThemeOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
										NameScope.SetNameScope(c74, nameScope);
										_component_10 = c74;
										NameScope.SetNameScope(_component_10, nameScope);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "LeftReorderHint"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c75)
						{
							nameScope.RegisterName("LeftReorderHint", c75);
							LeftReorderHint = c75;
							MarkupHelper.SetVisualStateLazy(c75, delegate
							{
								c75.Name = "LeftReorderHint";
								c75.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DragOverThemeAnimation
									{
										Direction = AnimationDirection.Left,
										TargetName = "LayoutRoot"
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DragOverThemeAnimation c76)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c76, DragOverThemeAnimation.ToOffsetProperty, "ListViewItemReorderHintThemeOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
										NameScope.SetNameScope(c76, nameScope);
										_component_11 = c76;
										NameScope.SetNameScope(_component_11, nameScope);
									}) }
								};
							});
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c77)
				{
					nameScope.RegisterName("ReorderHintStates", c77);
					ReorderHintStates = c77;
				}),
				new VisualStateGroup
				{
					Name = "DragStates",
					Transitions = 
					{
						new VisualTransition
						{
							GeneratedDuration = new Duration(TimeSpan.FromTicks(2000000L)),
							To = "NotDragging"
						}
					},
					States = 
					{
						new VisualState
						{
							Name = "NotDragging"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c79)
						{
							nameScope.RegisterName("NotDragging", c79);
							NotDragging = c79;
						}),
						new VisualState
						{
							Name = "Dragging"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c80)
						{
							nameScope.RegisterName("Dragging", c80);
							Dragging = c80;
							MarkupHelper.SetVisualStateLazy(c80, delegate
							{
								c80.Name = "Dragging";
								c80.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DoubleAnimation c81)
										{
											Storyboard.SetTargetName(c81, "LayoutRoot");
											Storyboard.SetTarget(c81, _LayoutRootSubject);
											Storyboard.SetTargetProperty(c81, "Opacity");
											ResourceResolverSingleton.Instance.ApplyResource(c81, DoubleAnimation.ToProperty, "ListViewItemDragThemeOpacity", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_12 = c81;
											NameScope.SetNameScope(_component_12, nameScope);
										}),
										(Timeline)new DragItemThemeAnimation
										{
											TargetName = "LayoutRoot"
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DragItemThemeAnimation c82)
										{
											NameScope.SetNameScope(c82, nameScope);
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "DraggingTarget"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c83)
						{
							nameScope.RegisterName("DraggingTarget", c83);
							DraggingTarget = c83;
						}),
						new VisualState
						{
							Name = "MultipleDraggingPrimary"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c84)
						{
							nameScope.RegisterName("MultipleDraggingPrimary", c84);
							MultipleDraggingPrimary = c84;
						}),
						new VisualState
						{
							Name = "MultipleDraggingSecondary"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c85)
						{
							nameScope.RegisterName("MultipleDraggingSecondary", c85);
							MultipleDraggingSecondary = c85;
						}),
						new VisualState
						{
							Name = "DraggedPlaceholder"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c86)
						{
							nameScope.RegisterName("DraggedPlaceholder", c86);
							DraggedPlaceholder = c86;
						}),
						new VisualState
						{
							Name = "Reordering"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c87)
						{
							nameScope.RegisterName("Reordering", c87);
							Reordering = c87;
							MarkupHelper.SetVisualStateLazy(c87, delegate
							{
								c87.Name = "Reordering";
								c87.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DoubleAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(2400000L))
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DoubleAnimation c88)
									{
										Storyboard.SetTargetName(c88, "LayoutRoot");
										Storyboard.SetTarget(c88, _LayoutRootSubject);
										Storyboard.SetTargetProperty(c88, "Opacity");
										ResourceResolverSingleton.Instance.ApplyResource(c88, DoubleAnimation.ToProperty, "ListViewItemReorderThemeOpacity", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
										_component_13 = c88;
										NameScope.SetNameScope(_component_13, nameScope);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "ReorderingTarget"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c89)
						{
							nameScope.RegisterName("ReorderingTarget", c89);
							ReorderingTarget = c89;
							MarkupHelper.SetVisualStateLazy(c89, delegate
							{
								c89.Name = "ReorderingTarget";
								c89.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(2400000L))
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DoubleAnimation c90)
										{
											Storyboard.SetTargetName(c90, "LayoutRoot");
											Storyboard.SetTarget(c90, _LayoutRootSubject);
											Storyboard.SetTargetProperty(c90, "Opacity");
											ResourceResolverSingleton.Instance.ApplyResource(c90, DoubleAnimation.ToProperty, "ListViewItemReorderTargetThemeOpacity", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_14 = c90;
											NameScope.SetNameScope(_component_14, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(2400000L))
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DoubleAnimation c91)
										{
											Storyboard.SetTargetName(c91, "LayoutRootScale");
											Storyboard.SetTarget(c91, _LayoutRootScaleSubject);
											Storyboard.SetTargetProperty(c91, "ScaleX");
											ResourceResolverSingleton.Instance.ApplyResource(c91, DoubleAnimation.ToProperty, "ListViewItemReorderTargetThemeScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_15 = c91;
											NameScope.SetNameScope(_component_15, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(2400000L))
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DoubleAnimation c92)
										{
											Storyboard.SetTargetName(c92, "LayoutRootScale");
											Storyboard.SetTarget(c92, _LayoutRootScaleSubject);
											Storyboard.SetTargetProperty(c92, "ScaleY");
											ResourceResolverSingleton.Instance.ApplyResource(c92, DoubleAnimation.ToProperty, "ListViewItemReorderTargetThemeScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_16 = c92;
											NameScope.SetNameScope(_component_16, nameScope);
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MultipleReorderingPrimary"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c93)
						{
							nameScope.RegisterName("MultipleReorderingPrimary", c93);
							MultipleReorderingPrimary = c93;
						}),
						new VisualState
						{
							Name = "ReorderedPlaceholder"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c94)
						{
							nameScope.RegisterName("ReorderedPlaceholder", c94);
							ReorderedPlaceholder = c94;
							MarkupHelper.SetVisualStateLazy(c94, delegate
							{
								c94.Name = "ReorderedPlaceholder";
								c94.Storyboard = new Storyboard
								{
									Children = { (Timeline)new FadeOutThemeAnimation
									{
										TargetName = "LayoutRoot"
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(FadeOutThemeAnimation c95)
									{
										NameScope.SetNameScope(c95, nameScope);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "DragOver"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c96)
						{
							nameScope.RegisterName("DragOver", c96);
							DragOver = c96;
							MarkupHelper.SetVisualStateLazy(c96, delegate
							{
								c96.Name = "DragOver";
								c96.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DropTargetItemThemeAnimation
									{
										TargetName = "LayoutRoot"
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DropTargetItemThemeAnimation c97)
									{
										NameScope.SetNameScope(c97, nameScope);
									}) }
								};
							});
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c98)
				{
					nameScope.RegisterName("DragStates", c98);
					DragStates = c98;
				}),
				new VisualStateGroup
				{
					Name = "IconStates",
					States = 
					{
						new VisualState
						{
							Name = "Icon"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c99)
						{
							nameScope.RegisterName("Icon", c99);
							Icon = c99;
						}),
						new VisualState
						{
							Name = "NoIcon"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c100)
						{
							nameScope.RegisterName("NoIcon", c100);
							NoIcon = c100;
							MarkupHelper.SetVisualStateLazy(c100, delegate
							{
								c100.Name = "NoIcon";
								c100.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c101)
				{
					nameScope.RegisterName("IconStates", c101);
					IconStates = c101;
				}),
				new VisualStateGroup
				{
					Name = "TabWidthModes",
					States = 
					{
						new VisualState
						{
							Name = "StandardWidth"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c102)
						{
							nameScope.RegisterName("StandardWidth", c102);
							StandardWidth = c102;
						}),
						new VisualState
						{
							Name = "Compact"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c103)
						{
							nameScope.RegisterName("Compact", c103);
							Compact = c103;
							MarkupHelper.SetVisualStateLazy(c103, delegate
							{
								c103.Name = "Compact";
								c103.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Margin"), "0,0,0,0"));
								c103.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c103.Setters.Add(new Setter(new TargetPropertyPath(_IconColumnSubject, (PropertyPath)"Width"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TabViewItemHeaderIconSize", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TabViewItemHeaderIconSize", GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c104)
				{
					nameScope.RegisterName("TabWidthModes", c104);
					TabWidthModes = c104;
				}),
				new VisualStateGroup
				{
					Name = "CloseIconStates",
					States = 
					{
						new VisualState
						{
							Name = "CloseButtonVisible"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c105)
						{
							nameScope.RegisterName("CloseButtonVisible", c105);
							CloseButtonVisible = c105;
						}),
						new VisualState
						{
							Name = "CloseButtonCollapsed"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c106)
						{
							nameScope.RegisterName("CloseButtonCollapsed", c106);
							CloseButtonCollapsed = c106;
							MarkupHelper.SetVisualStateLazy(c106, delegate
							{
								c106.Name = "CloseButtonCollapsed";
								c106.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c107)
				{
					nameScope.RegisterName("CloseIconStates", c107);
					CloseIconStates = c107;
				}),
				new VisualStateGroup
				{
					States = 
					{
						new VisualState
						{
							Name = "ForegroundNotSet"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c108)
						{
							nameScope.RegisterName("ForegroundNotSet", c108);
							ForegroundNotSet = c108;
						}),
						new VisualState
						{
							Name = "ForegroundSet"
						}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c109)
						{
							nameScope.RegisterName("ForegroundSet", c109);
							ForegroundSet = c109;
							MarkupHelper.SetVisualStateLazy(c109, delegate
							{
								c109.Name = "ForegroundSet";
								c109.Setters.Add(new Setter(new TargetPropertyPath(_IconControlSubject, (PropertyPath)"Foreground"), null).TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Setter c110)
								{
									c110.SetBinding("Value", new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "Foreground"
									});
								}));
								c109.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), null).TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Setter c111)
								{
									c111.SetBinding("Value", new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "Foreground"
									});
								}));
							});
						})
					}
				}
			});
			c53.CreationComplete();
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
internal class _TabView_v1_6c3dfe822eb663b8f992af232e949022_TabView_v1RDSC5
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ScrollDecreaseButtonSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollIncreaseButtonSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private RepeatButton _component_0
	{
		get
		{
			return (RepeatButton)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private RepeatButton _component_1
	{
		get
		{
			return (RepeatButton)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private RepeatButton ScrollDecreaseButton
	{
		get
		{
			return (RepeatButton)_ScrollDecreaseButtonSubject.ElementInstance;
		}
		set
		{
			_ScrollDecreaseButtonSubject.ElementInstance = value;
		}
	}

	private ScrollContentPresenter ScrollContentPresenter
	{
		get
		{
			return (ScrollContentPresenter)_ScrollContentPresenterSubject.ElementInstance;
		}
		set
		{
			_ScrollContentPresenterSubject.ElementInstance = value;
		}
	}

	private RepeatButton ScrollIncreaseButton
	{
		get
		{
			return (RepeatButton)_ScrollIncreaseButtonSubject.ElementInstance;
		}
		set
		{
			_ScrollIncreaseButtonSubject.ElementInstance = value;
		}
	}

	private Border Root
	{
		get
		{
			return (Border)_RootSubject.ElementInstance;
		}
		set
		{
			_RootSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2542)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Name = "Root",
			Child = new Grid
			{
				IsParsing = true,
				ColumnDefinitions = 
				{
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Auto)
					},
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Star)
					},
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Auto)
					}
				},
				Children = 
				{
					(UIElement)new RepeatButton
					{
						IsParsing = true,
						Name = "ScrollDecreaseButton",
						VerticalAlignment = VerticalAlignment.Bottom,
						BorderThickness = new Thickness(1.0),
						Delay = 50,
						Interval = 100,
						HighContrastAdjustment = ElementHighContrastAdjustment.None,
						Content = "\ue76b"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(RepeatButton c115)
					{
						nameScope.RegisterName("ScrollDecreaseButton", c115);
						ScrollDecreaseButton = c115;
						AutomationProperties.SetAccessibilityView(c115, AccessibilityView.Raw);
						ResourceResolverSingleton.Instance.ApplyResource(c115, FrameworkElement.WidthProperty, "TabViewItemScrollButtonWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c115, FrameworkElement.HeightProperty, "TabViewItemScrollButtonHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c115, Control.PaddingProperty, "TabViewItemScrollButtonPadding", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c115, FrameworkElement.BackgroundProperty, "TabViewScrollButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c115, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						c115.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							Path = "ComputedHorizontalScrollBarVisibility",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						_component_0 = c115;
						c115.CreationComplete();
					}),
					(UIElement)new ScrollContentPresenter
					{
						IsParsing = true,
						Name = "ScrollContentPresenter",
						Padding = new Thickness(1.0, 0.0, 0.0, 0.0),
						TabFocusNavigation = KeyboardNavigationMode.Once
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ScrollContentPresenter c116)
					{
						nameScope.RegisterName("ScrollContentPresenter", c116);
						ScrollContentPresenter = c116;
						Grid.SetColumn(c116, 1);
						c116.CreationComplete();
					}),
					(UIElement)new RepeatButton
					{
						IsParsing = true,
						Name = "ScrollIncreaseButton",
						VerticalAlignment = VerticalAlignment.Bottom,
						HorizontalAlignment = HorizontalAlignment.Center,
						BorderThickness = new Thickness(1.0),
						Delay = 50,
						Interval = 100,
						HighContrastAdjustment = ElementHighContrastAdjustment.None,
						Content = "\ue76c"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(RepeatButton c117)
					{
						nameScope.RegisterName("ScrollIncreaseButton", c117);
						ScrollIncreaseButton = c117;
						AutomationProperties.SetAccessibilityView(c117, AccessibilityView.Raw);
						Grid.SetColumn(c117, 2);
						ResourceResolverSingleton.Instance.ApplyResource(c117, FrameworkElement.WidthProperty, "TabViewItemScrollButtonWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c117, FrameworkElement.HeightProperty, "TabViewItemScrollButtonHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c117, Control.PaddingProperty, "TabViewItemScrollButtonPadding", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c117, FrameworkElement.BackgroundProperty, "TabViewScrollButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c117, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
						c117.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							Path = "ComputedHorizontalScrollBarVisibility",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						_component_1 = c117;
						c117.CreationComplete();
					})
				}
			}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Grid c118)
			{
				c118.CreationComplete();
			})
		}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(Border c119)
		{
			nameScope.RegisterName("Root", c119);
			Root = c119;
			c119.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c119.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c119.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c119.CreationComplete();
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
internal class _TabView_v1_6c3dfe822eb663b8f992af232e949022_TabView_v1RDSC6
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private DiscreteObjectKeyFrame _component_0
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_1
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_2
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_3
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_4
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_5
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

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

	private VisualState Normal
	{
		get
		{
			return (VisualState)_NormalSubject.ElementInstance;
		}
		set
		{
			_NormalSubject.ElementInstance = value;
		}
	}

	private VisualState PointerOver
	{
		get
		{
			return (VisualState)_PointerOverSubject.ElementInstance;
		}
		set
		{
			_PointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState Pressed
	{
		get
		{
			return (VisualState)_PressedSubject.ElementInstance;
		}
		set
		{
			_PressedSubject.ElementInstance = value;
		}
	}

	private VisualState Disabled
	{
		get
		{
			return (VisualState)_DisabledSubject.ElementInstance;
		}
		set
		{
			_DisabledSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup CommonStates
	{
		get
		{
			return (VisualStateGroup)_CommonStatesSubject.ElementInstance;
		}
		set
		{
			_CommonStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2543)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new ContentPresenter
		{
			IsParsing = true,
			Name = "ContentPresenter",
			FontWeight = FontWeights.SemiLight
		}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ContentPresenter c120)
		{
			nameScope.RegisterName("ContentPresenter", c120);
			ContentPresenter = c120;
			c120.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.BackgroundSizingProperty, new Binding
			{
				Path = "BackgroundSizing",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Content",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
			{
				Path = "ContentTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
			{
				Path = "ContentTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.FontSizeProperty, new Binding
			{
				Path = "FontSize",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.FontFamilyProperty, new Binding
			{
				Path = "FontFamily",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
			{
				Path = "HorizontalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c120.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
			{
				Path = "VerticalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			AutomationProperties.SetAccessibilityView(c120, AccessibilityView.Raw);
			VisualStateManager.SetVisualStateGroups(c120, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c121)
					{
						nameScope.RegisterName("Normal", c121);
						Normal = c121;
						MarkupHelper.SetVisualStateLazy(c121, delegate
						{
							c121.Name = "Normal";
							c121.Storyboard = new Storyboard
							{
								Children = { (Timeline)new PointerUpThemeAnimation().TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(PointerUpThemeAnimation c122)
								{
									Storyboard.SetTargetName(c122, "ContentPresenter");
									Storyboard.SetTarget(c122, _ContentPresenterSubject);
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c123)
					{
						nameScope.RegisterName("PointerOver", c123);
						PointerOver = c123;
						MarkupHelper.SetVisualStateLazy(c123, delegate
						{
							c123.Name = "PointerOver";
							c123.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c124)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c124, ObjectKeyFrame.ValueProperty, "TabViewButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_0 = c124;
											NameScope.SetNameScope(_component_0, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c125)
									{
										Storyboard.SetTargetName(c125, "ContentPresenter");
										Storyboard.SetTarget(c125, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c125, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c126)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c126, ObjectKeyFrame.ValueProperty, "TabViewButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_1 = c126;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c127)
									{
										Storyboard.SetTargetName(c127, "ContentPresenter");
										Storyboard.SetTarget(c127, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c127, "Foreground");
									}),
									(Timeline)new PointerUpThemeAnimation().TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(PointerUpThemeAnimation c128)
									{
										Storyboard.SetTargetName(c128, "ContentPresenter");
										Storyboard.SetTarget(c128, _ContentPresenterSubject);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c129)
					{
						nameScope.RegisterName("Pressed", c129);
						Pressed = c129;
						MarkupHelper.SetVisualStateLazy(c129, delegate
						{
							c129.Name = "Pressed";
							c129.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c130)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c130, ObjectKeyFrame.ValueProperty, "TabViewButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_2 = c130;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c131)
									{
										Storyboard.SetTargetName(c131, "ContentPresenter");
										Storyboard.SetTarget(c131, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c131, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c132)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c132, ObjectKeyFrame.ValueProperty, "TabViewButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_3 = c132;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c133)
									{
										Storyboard.SetTargetName(c133, "ContentPresenter");
										Storyboard.SetTarget(c133, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c133, "Foreground");
									}),
									(Timeline)new PointerDownThemeAnimation().TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(PointerDownThemeAnimation c134)
									{
										Storyboard.SetTargetName(c134, "ContentPresenter");
										Storyboard.SetTarget(c134, _ContentPresenterSubject);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualState c135)
					{
						nameScope.RegisterName("Disabled", c135);
						Disabled = c135;
						MarkupHelper.SetVisualStateLazy(c135, delegate
						{
							c135.Name = "Disabled";
							c135.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c136)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c136, ObjectKeyFrame.ValueProperty, "TabViewButtonBackgroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_4 = c136;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c137)
									{
										Storyboard.SetTargetName(c137, "ContentPresenter");
										Storyboard.SetTarget(c137, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c137, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(DiscreteObjectKeyFrame c138)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c138, ObjectKeyFrame.ValueProperty, "TabViewButtonForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__78.Instance.__ParseContext_);
											_component_5 = c138;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(ObjectAnimationUsingKeyFrames c139)
									{
										Storyboard.SetTargetName(c139, "ContentPresenter");
										Storyboard.SetTarget(c139, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c139, "Foreground");
									})
								}
							};
						});
					})
				}
			}.TabView_v1_6c3dfe822eb663b8f992af232e949022_XamlApply(delegate(VisualStateGroup c140)
			{
				nameScope.RegisterName("CommonStates", c140);
				CommonStates = c140;
			}) });
			c120.CreationComplete();
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

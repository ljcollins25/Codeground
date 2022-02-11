using System;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconHostSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedDisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private RowDefinition _component_0
	{
		get
		{
			return (RowDefinition)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private TextBlock Icon
	{
		get
		{
			return (TextBlock)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
		}
	}

	private Viewbox IconHost
	{
		get
		{
			return (Viewbox)_IconHostSubject.ElementInstance;
		}
		set
		{
			_IconHostSubject.ElementInstance = value;
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

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
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

	private VisualState Checked
	{
		get
		{
			return (VisualState)_CheckedSubject.ElementInstance;
		}
		set
		{
			_CheckedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPointerOver
	{
		get
		{
			return (VisualState)_CheckedPointerOverSubject.ElementInstance;
		}
		set
		{
			_CheckedPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPressed
	{
		get
		{
			return (VisualState)_CheckedPressedSubject.ElementInstance;
		}
		set
		{
			_CheckedPressedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedDisabled
	{
		get
		{
			return (VisualState)_CheckedDisabledSubject.ElementInstance;
		}
		set
		{
			_CheckedDisabledSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_916)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			HorizontalAlignment = HorizontalAlignment.Stretch,
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
			RowDefinitions = { new RowDefinition().NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(RowDefinition c2)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c2, RowDefinition.HeightProperty, "PaneToggleButtonHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
				_component_0 = c2;
				NameScope.SetNameScope(_component_0, nameScope);
			}) },
			Children = 
			{
				(UIElement)new Border
				{
					IsParsing = true,
					Child = new Viewbox
					{
						IsParsing = true,
						Name = "IconHost",
						Width = 16.0,
						Height = 16.0,
						HorizontalAlignment = HorizontalAlignment.Center,
						Child = new TextBlock
						{
							IsParsing = true,
							Name = "Icon",
							Text = "\ue700"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(TextBlock c3)
						{
							nameScope.RegisterName("Icon", c3);
							Icon = c3;
							c3.SetBinding(TextBlock.FontSizeProperty, new Binding
							{
								Path = "FontSize",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c3, AccessibilityView.Raw);
							c3.CreationComplete();
						})
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Viewbox c4)
					{
						nameScope.RegisterName("IconHost", c4);
						IconHost = c4;
						c4.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
						{
							Path = "VerticalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						AutomationProperties.SetAccessibilityView(c4, AccessibilityView.Raw);
						c4.CreationComplete();
					})
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c5)
				{
					c5.SetBinding(FrameworkElement.WidthProperty, new Binding
					{
						Path = "MinWidth",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c5.CreationComplete();
				}),
				(UIElement)new ContentPresenter
				{
					IsParsing = true,
					Name = "ContentPresenter",
					VerticalContentAlignment = VerticalAlignment.Center
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c6)
				{
					nameScope.RegisterName("ContentPresenter", c6);
					ContentPresenter = c6;
					c6.SetBinding(ContentPresenter.ContentProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c6.SetBinding(ContentPresenter.FontSizeProperty, new Binding
					{
						Path = "FontSize",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					Grid.SetColumn(c6, 1);
					c6.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c7)
				{
					nameScope.RegisterName("RevealBorder", c7);
					RevealBorder = c7;
					c7.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c7.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					Grid.SetColumnSpan(c7, 2);
					c7.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c8)
		{
			nameScope.RegisterName("LayoutRoot", c8);
			LayoutRoot = c8;
			c8.SetBinding(FrameworkElement.MinWidthProperty, new Binding
			{
				Path = "MinWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c8.SetBinding(FrameworkElement.HeightProperty, new Binding
			{
				Path = "MinHeight",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c8.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c8.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c8, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c9)
					{
						nameScope.RegisterName("Normal", c9);
						Normal = c9;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c10)
					{
						nameScope.RegisterName("PointerOver", c10);
						PointerOver = c10;
						MarkupHelper.SetVisualStateLazy(c10, delegate
						{
							c10.Name = "PointerOver";
							c10.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c10.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c10.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c11)
					{
						nameScope.RegisterName("Pressed", c11);
						Pressed = c11;
						MarkupHelper.SetVisualStateLazy(c11, delegate
						{
							c11.Name = "Pressed";
							c11.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c11.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c11.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c12)
					{
						nameScope.RegisterName("Disabled", c12);
						Disabled = c12;
						MarkupHelper.SetVisualStateLazy(c12, delegate
						{
							c12.Name = "Disabled";
							c12.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c12.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Checked"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c13)
					{
						nameScope.RegisterName("Checked", c13);
						Checked = c13;
						MarkupHelper.SetVisualStateLazy(c13, delegate
						{
							c13.Name = "Checked";
							c13.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c13.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "CheckedPointerOver"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c14)
					{
						nameScope.RegisterName("CheckedPointerOver", c14);
						CheckedPointerOver = c14;
						MarkupHelper.SetVisualStateLazy(c14, delegate
						{
							c14.Name = "CheckedPointerOver";
							c14.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c14.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "CheckedPressed"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c15)
					{
						nameScope.RegisterName("CheckedPressed", c15);
						CheckedPressed = c15;
						MarkupHelper.SetVisualStateLazy(c15, delegate
						{
							c15.Name = "CheckedPressed";
							c15.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c15.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "CheckedDisabled"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c16)
					{
						nameScope.RegisterName("CheckedDisabled", c16);
						CheckedDisabled = c16;
						MarkupHelper.SetVisualStateLazy(c16, delegate
						{
							c16.Name = "CheckedDisabled";
							c16.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c16.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c17)
			{
				nameScope.RegisterName("CommonStates", c17);
				CommonStates = c17;
			}) });
			c8.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC1
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
		}
	}

	private FontIcon Icon
	{
		get
		{
			return (FontIcon)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_985)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent,
					Visibility = Visibility.Collapsed
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c18)
				{
					nameScope.RegisterName("PointerRectangle", c18);
					PointerRectangle = c18;
					c18.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c19)
				{
					nameScope.RegisterName("RevealBorder", c19);
					RevealBorder = c19;
					c19.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c19.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c19.CreationComplete();
				}),
				(UIElement)new FontIcon
				{
					IsParsing = true,
					Name = "Icon",
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					FontSize = 20.0,
					Glyph = "\ue10c",
					IsHitTestVisible = false
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(FontIcon c20)
				{
					nameScope.RegisterName("Icon", c20);
					Icon = c20;
					AutomationProperties.SetAccessibilityView(c20, AccessibilityView.Raw);
					ResourceResolverSingleton.Instance.ApplyResource(c20, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
					c20.SetBinding(IconElement.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c20;
					c20.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c21)
		{
			nameScope.RegisterName("RootGrid", c21);
			RootGrid = c21;
			c21.SetBinding(FrameworkElement.HeightProperty, new Binding
			{
				Path = "Height",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c21.SetBinding(FrameworkElement.WidthProperty, new Binding
			{
				Path = "Width",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c21.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c21, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c22)
					{
						nameScope.RegisterName("Normal", c22);
						Normal = c22;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c23)
					{
						nameScope.RegisterName("PointerOver", c23);
						PointerOver = c23;
						MarkupHelper.SetVisualStateLazy(c23, delegate
						{
							c23.Name = "PointerOver";
							c23.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c23.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c23.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c23.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c24)
					{
						nameScope.RegisterName("Pressed", c24);
						Pressed = c24;
						MarkupHelper.SetVisualStateLazy(c24, delegate
						{
							c24.Name = "Pressed";
							c24.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c24.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c24.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c24.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c25)
					{
						nameScope.RegisterName("Disabled", c25);
						Disabled = c25;
						MarkupHelper.SetVisualStateLazy(c25, delegate
						{
							c25.Name = "Disabled";
							c25.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c26)
			{
				nameScope.RegisterName("CommonStates", c26);
				CommonStates = c26;
			}) });
			c21.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
		}
	}

	private FontIcon Icon
	{
		get
		{
			return (FontIcon)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_1021)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c27)
				{
					nameScope.RegisterName("PointerRectangle", c27);
					PointerRectangle = c27;
					c27.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c28)
				{
					nameScope.RegisterName("RevealBorder", c28);
					RevealBorder = c28;
					c28.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c28.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c28.CreationComplete();
				}),
				(UIElement)new FontIcon
				{
					IsParsing = true,
					Name = "Icon",
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					FontSize = 20.0,
					Glyph = "\ue10c",
					IsHitTestVisible = false
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(FontIcon c29)
				{
					nameScope.RegisterName("Icon", c29);
					Icon = c29;
					AutomationProperties.SetAccessibilityView(c29, AccessibilityView.Raw);
					ResourceResolverSingleton.Instance.ApplyResource(c29, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
					c29.SetBinding(IconElement.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c29;
					c29.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c30)
		{
			nameScope.RegisterName("RootGrid", c30);
			RootGrid = c30;
			c30.SetBinding(FrameworkElement.HeightProperty, new Binding
			{
				Path = "Height",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c30.SetBinding(FrameworkElement.WidthProperty, new Binding
			{
				Path = "Width",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c30.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c30, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c31)
					{
						nameScope.RegisterName("Normal", c31);
						Normal = c31;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c32)
					{
						nameScope.RegisterName("PointerOver", c32);
						PointerOver = c32;
						MarkupHelper.SetVisualStateLazy(c32, delegate
						{
							c32.Name = "PointerOver";
							c32.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c32.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c32.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c32.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c33)
					{
						nameScope.RegisterName("Pressed", c33);
						Pressed = c33;
						MarkupHelper.SetVisualStateLazy(c33, delegate
						{
							c33.Name = "Pressed";
							c33.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c33.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c33.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c33.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c34)
					{
						nameScope.RegisterName("Disabled", c34);
						Disabled = c34;
						MarkupHelper.SetVisualStateLazy(c34, delegate
						{
							c34.Name = "Disabled";
							c34.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c35)
			{
				nameScope.RegisterName("CommonStates", c35);
				CommonStates = c35;
			}) });
			c30.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC3
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ExpandCollapseRotateExpandedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseRotateCollapsedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _IconColumnSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronRotateTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _PresenterContentRootGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _IconCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _IconStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronHiddenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleOpenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleClosedSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NotClosedCompactAndTopLevelItemSubject = new ElementNameSubject();

	private ElementNameSubject _ClosedCompactAndTopLevelItemSubject = new ElementNameSubject();

	private ElementNameSubject _PaneAndTopLevelItemStatesSubject = new ElementNameSubject();

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

	private Viewbox _component_1
	{
		get
		{
			return (Viewbox)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private ContentPresenter _component_2
	{
		get
		{
			return (ContentPresenter)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private TextBlock _component_3
	{
		get
		{
			return (TextBlock)_component_3_Holder.Instance;
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

	private Grid _component_6
	{
		get
		{
			return (Grid)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private Storyboard ExpandCollapseRotateExpandedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance = value;
		}
	}

	private Storyboard ExpandCollapseRotateCollapsedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance = value;
		}
	}

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
		}
	}

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private Border IconColumn
	{
		get
		{
			return (Border)_IconColumnSubject.ElementInstance;
		}
		set
		{
			_IconColumnSubject.ElementInstance = value;
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

	private RotateTransform ExpandCollapseChevronRotateTransform
	{
		get
		{
			return (RotateTransform)_ExpandCollapseChevronRotateTransformSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronRotateTransformSubject.ElementInstance = value;
		}
	}

	private Grid ExpandCollapseChevron
	{
		get
		{
			return (Grid)_ExpandCollapseChevronSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronSubject.ElementInstance = value;
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

	private Grid PresenterContentRootGrid
	{
		get
		{
			return (Grid)_PresenterContentRootGridSubject.ElementInstance;
		}
		set
		{
			_PresenterContentRootGridSubject.ElementInstance = value;
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

	private VisualStateGroup PointerStates
	{
		get
		{
			return (VisualStateGroup)_PointerStatesSubject.ElementInstance;
		}
		set
		{
			_PointerStatesSubject.ElementInstance = value;
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

	private VisualState IconVisible
	{
		get
		{
			return (VisualState)_IconVisibleSubject.ElementInstance;
		}
		set
		{
			_IconVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState IconCollapsed
	{
		get
		{
			return (VisualState)_IconCollapsedSubject.ElementInstance;
		}
		set
		{
			_IconCollapsedSubject.ElementInstance = value;
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

	private VisualState ChevronHidden
	{
		get
		{
			return (VisualState)_ChevronHiddenSubject.ElementInstance;
		}
		set
		{
			_ChevronHiddenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleOpen
	{
		get
		{
			return (VisualState)_ChevronVisibleOpenSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleOpenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleClosed
	{
		get
		{
			return (VisualState)_ChevronVisibleClosedSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleClosedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ChevronStates
	{
		get
		{
			return (VisualStateGroup)_ChevronStatesSubject.ElementInstance;
		}
		set
		{
			_ChevronStatesSubject.ElementInstance = value;
		}
	}

	private VisualState NotClosedCompactAndTopLevelItem
	{
		get
		{
			return (VisualState)_NotClosedCompactAndTopLevelItemSubject.ElementInstance;
		}
		set
		{
			_NotClosedCompactAndTopLevelItemSubject.ElementInstance = value;
		}
	}

	private VisualState ClosedCompactAndTopLevelItem
	{
		get
		{
			return (VisualState)_ClosedCompactAndTopLevelItemSubject.ElementInstance;
		}
		set
		{
			_ClosedCompactAndTopLevelItemSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneAndTopLevelItemStates
	{
		get
		{
			return (VisualStateGroup)_PaneAndTopLevelItemStatesSubject.ElementInstance;
		}
		set
		{
			_PaneAndTopLevelItemStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1056)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)"ExpandCollapseRotateExpandedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 0.0,
						To = 180.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c36)
					{
						Storyboard.SetTargetName(c36, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c36, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c36, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c37)
				{
					nameScope.RegisterName("ExpandCollapseRotateExpandedStoryboard", c37);
					ExpandCollapseRotateExpandedStoryboard = c37;
				}),
				[(object)"ExpandCollapseRotateCollapsedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 180.0,
						To = 0.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c38)
					{
						Storyboard.SetTargetName(c38, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c38, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c38, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c39)
				{
					nameScope.RegisterName("ExpandCollapseRotateCollapsedStoryboard", c39);
					ExpandCollapseRotateCollapsedStoryboard = c39;
				})
			},
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c40)
				{
					nameScope.RegisterName("RevealBorder", c40);
					RevealBorder = c40;
					c40.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c40.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c40.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "PresenterContentRootGrid",
					Children = 
					{
						(UIElement)new Grid
						{
							IsParsing = true,
							Margin = new Thickness(4.0, 0.0, 0.0, 0.0),
							HorizontalAlignment = HorizontalAlignment.Left,
							VerticalAlignment = VerticalAlignment.Center,
							Children = { (UIElement)new Rectangle
							{
								IsParsing = true,
								Name = "SelectionIndicator",
								Width = 2.0,
								Height = 24.0,
								Opacity = 0.0
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c41)
							{
								nameScope.RegisterName("SelectionIndicator", c41);
								SelectionIndicator = c41;
								ResourceResolverSingleton.Instance.ApplyResource(c41, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								c41.SetBinding(Rectangle.RadiusXProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
								});
								c41.SetBinding(Rectangle.RadiusYProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
								});
								_component_0 = c41;
								c41.CreationComplete();
							}) }
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c42)
						{
							c42.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "ContentGrid",
							HorizontalAlignment = HorizontalAlignment.Stretch,
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
								(UIElement)new Border
								{
									IsParsing = true,
									Name = "IconColumn",
									Child = new Viewbox
									{
										IsParsing = true,
										Name = "IconBox",
										Height = 16.0,
										Child = new ContentPresenter
										{
											IsParsing = true,
											Name = "Icon"
										}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c46)
										{
											nameScope.RegisterName("Icon", c46);
											Icon = c46;
											c46.SetBinding(ContentPresenter.ContentProperty, new Binding
											{
												Path = "Icon",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c46.CreationComplete();
										})
									}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Viewbox c47)
									{
										nameScope.RegisterName("IconBox", c47);
										IconBox = c47;
										ResourceResolverSingleton.Instance.ApplyResource(c47, FrameworkElement.MarginProperty, "NavigationViewItemOnLeftIconBoxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										_component_1 = c47;
										c47.CreationComplete();
									})
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c48)
								{
									nameScope.RegisterName("IconColumn", c48);
									IconColumn = c48;
									c48.SetBinding(FrameworkElement.WidthProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.IconWidth"
									});
									c48.CreationComplete();
								}),
								(UIElement)new ContentPresenter
								{
									IsParsing = true,
									Name = "ContentPresenter"
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c49)
								{
									nameScope.RegisterName("ContentPresenter", c49);
									ContentPresenter = c49;
									Grid.SetColumn(c49, 1);
									ResourceResolverSingleton.Instance.ApplyResource(c49, FrameworkElement.MarginProperty, "NavigationViewItemContentPresenterMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									c49.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
									{
										Path = "ContentTransitions",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c49.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
									{
										Path = "ContentTemplate",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c49.SetBinding(ContentPresenter.ContentProperty, new Binding
									{
										Path = "Content",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c49.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
									{
										Path = "HorizontalContentAlignment",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c49.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
									{
										Path = "VerticalContentAlignment",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c49.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
									{
										Path = "ContentTemplateSelector",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c49.SetBinding(ContentPresenter.PaddingProperty, new Binding
									{
										Path = "Padding",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									AutomationProperties.SetAccessibilityView(c49, AccessibilityView.Raw);
									_component_2 = c49;
									c49.CreationComplete();
								}),
								(UIElement)new Grid
								{
									IsParsing = true,
									Name = "ExpandCollapseChevron",
									Visibility = Visibility.Collapsed,
									HorizontalAlignment = HorizontalAlignment.Right,
									Width = 40.0,
									Background = SolidColorBrushHelper.Transparent,
									Children = { (UIElement)new TextBlock
									{
										IsParsing = true,
										RenderTransformOrigin = new Point(0.5, 0.5),
										HorizontalAlignment = HorizontalAlignment.Center,
										VerticalAlignment = VerticalAlignment.Center,
										IsTextScaleFactorEnabled = false,
										RenderTransform = new RotateTransform
										{
											Angle = 0.0
										}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(RotateTransform c50)
										{
											nameScope.RegisterName("ExpandCollapseChevronRotateTransform", c50);
											ExpandCollapseChevronRotateTransform = c50;
										})
									}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(TextBlock c51)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c51, TextBlock.ForegroundProperty, "NavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c51, TextBlock.FontSizeProperty, "NavigationViewItemExpandedGlyphFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c51, TextBlock.TextProperty, "NavigationViewItemExpandedGlyph", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c51, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										AutomationProperties.SetAccessibilityView(c51, AccessibilityView.Raw);
										_component_3 = c51;
										c51.CreationComplete();
									}) }
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c52)
								{
									nameScope.RegisterName("ExpandCollapseChevron", c52);
									ExpandCollapseChevron = c52;
									Grid.SetColumn(c52, 2);
									ResourceResolverSingleton.Instance.ApplyResource(c52, FrameworkElement.MarginProperty, "NavigationViewItemExpandChevronMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									_component_4 = c52;
									c52.CreationComplete();
								})
							}
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c53)
						{
							nameScope.RegisterName("ContentGrid", c53);
							ContentGrid = c53;
							ResourceResolverSingleton.Instance.ApplyResource(c53, FrameworkElement.MinHeightProperty, "NavigationViewItemOnLeftMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
							_component_5 = c53;
							c53.CreationComplete();
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c54)
				{
					nameScope.RegisterName("PresenterContentRootGrid", c54);
					PresenterContentRootGrid = c54;
					c54.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c55)
		{
			nameScope.RegisterName("LayoutRoot", c55);
			LayoutRoot = c55;
			ResourceResolverSingleton.Instance.ApplyResource(c55, FrameworkElement.MinHeightProperty, "NavigationViewItemOnLeftMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
			c55.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c55, value: true);
			VisualStateManager.SetVisualStateGroups(c55, new VisualStateGroup[5]
			{
				new VisualStateGroup
				{
					Name = "PointerStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c56)
						{
							nameScope.RegisterName("Normal", c56);
							Normal = c56;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c57)
						{
							nameScope.RegisterName("PointerOver", c57);
							PointerOver = c57;
							MarkupHelper.SetVisualStateLazy(c57, delegate
							{
								c57.Name = "PointerOver";
								c57.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c58)
						{
							nameScope.RegisterName("Pressed", c58);
							Pressed = c58;
							MarkupHelper.SetVisualStateLazy(c58, delegate
							{
								c58.Name = "Pressed";
								c58.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c59)
						{
							nameScope.RegisterName("Selected", c59);
							Selected = c59;
							MarkupHelper.SetVisualStateLazy(c59, delegate
							{
								c59.Name = "Selected";
								c59.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c60)
						{
							nameScope.RegisterName("PointerOverSelected", c60);
							PointerOverSelected = c60;
							MarkupHelper.SetVisualStateLazy(c60, delegate
							{
								c60.Name = "PointerOverSelected";
								c60.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
								c60.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c60.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c60.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c60.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c61)
						{
							nameScope.RegisterName("PressedSelected", c61);
							PressedSelected = c61;
							MarkupHelper.SetVisualStateLazy(c61, delegate
							{
								c61.Name = "PressedSelected";
								c61.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
								c61.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c61.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c61.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c61.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c62)
				{
					nameScope.RegisterName("PointerStates", c62);
					PointerStates = c62;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c63)
						{
							nameScope.RegisterName("Enabled", c63);
							Enabled = c63;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c64)
						{
							nameScope.RegisterName("Disabled", c64);
							Disabled = c64;
							MarkupHelper.SetVisualStateLazy(c64, delegate
							{
								c64.Name = "Disabled";
								c64.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c64.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Opacity"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ListViewItemDisabledThemeOpacity", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ListViewItemDisabledThemeOpacity", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c65)
				{
					nameScope.RegisterName("DisabledStates", c65);
					DisabledStates = c65;
				}),
				new VisualStateGroup
				{
					Name = "IconStates",
					States = 
					{
						new VisualState
						{
							Name = "IconVisible"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c66)
						{
							nameScope.RegisterName("IconVisible", c66);
							IconVisible = c66;
						}),
						new VisualState
						{
							Name = "IconCollapsed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c67)
						{
							nameScope.RegisterName("IconCollapsed", c67);
							IconCollapsed = c67;
							MarkupHelper.SetVisualStateLazy(c67, delegate
							{
								c67.Name = "IconCollapsed";
								c67.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c67.Setters.Add(new Setter(new TargetPropertyPath(_IconColumnSubject, (PropertyPath)"Width"), "16"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c68)
				{
					nameScope.RegisterName("IconStates", c68);
					IconStates = c68;
				}),
				new VisualStateGroup
				{
					Name = "ChevronStates",
					States = 
					{
						new VisualState
						{
							Name = "ChevronHidden"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c69)
						{
							nameScope.RegisterName("ChevronHidden", c69);
							ChevronHidden = c69;
						}),
						new VisualState
						{
							Name = "ChevronVisibleOpen"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c70)
						{
							nameScope.RegisterName("ChevronVisibleOpen", c70);
							ChevronVisibleOpen = c70;
							MarkupHelper.SetVisualStateLazy(c70, delegate
							{
								c70.Name = "ChevronVisibleOpen";
								c70.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c70.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "180"));
							});
						}),
						new VisualState
						{
							Name = "ChevronVisibleClosed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c71)
						{
							nameScope.RegisterName("ChevronVisibleClosed", c71);
							ChevronVisibleClosed = c71;
							MarkupHelper.SetVisualStateLazy(c71, delegate
							{
								c71.Name = "ChevronVisibleClosed";
								c71.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c71.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "0"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c72)
				{
					nameScope.RegisterName("ChevronStates", c72);
					ChevronStates = c72;
				}),
				new VisualStateGroup
				{
					Name = "PaneAndTopLevelItemStates",
					States = 
					{
						new VisualState
						{
							Name = "NotClosedCompactAndTopLevelItem"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c73)
						{
							nameScope.RegisterName("NotClosedCompactAndTopLevelItem", c73);
							NotClosedCompactAndTopLevelItem = c73;
						}),
						new VisualState
						{
							Name = "ClosedCompactAndTopLevelItem"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c74)
						{
							nameScope.RegisterName("ClosedCompactAndTopLevelItem", c74);
							ClosedCompactAndTopLevelItem = c74;
							MarkupHelper.SetVisualStateLazy(c74, delegate
							{
								c74.Name = "ClosedCompactAndTopLevelItem";
								c74.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewCompactItemContentPresenterMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewCompactItemContentPresenterMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c75)
				{
					nameScope.RegisterName("PaneAndTopLevelItemStates", c75);
					PaneAndTopLevelItemStates = c75;
				})
			});
			_component_6 = c55;
			c55.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC4
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_7_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ExpandCollapseRotateExpandedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseRotateCollapsedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _IconColumnSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronRotateTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _PresenterContentRootGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _FocusedSubject = new ElementNameSubject();

	private ElementNameSubject _UnfocusedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerFocusedSubject = new ElementNameSubject();

	private ElementNameSubject _FocusStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _IconCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _IconStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronHiddenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleOpenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleClosedSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NotClosedCompactAndTopLevelItemSubject = new ElementNameSubject();

	private ElementNameSubject _ClosedCompactAndTopLevelItemSubject = new ElementNameSubject();

	private ElementNameSubject _PaneAndTopLevelItemStatesSubject = new ElementNameSubject();

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

	private Viewbox _component_2
	{
		get
		{
			return (Viewbox)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private ContentPresenter _component_3
	{
		get
		{
			return (ContentPresenter)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private TextBlock _component_4
	{
		get
		{
			return (TextBlock)_component_4_Holder.Instance;
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

	private Grid _component_6
	{
		get
		{
			return (Grid)_component_6_Holder.Instance;
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

	private Storyboard ExpandCollapseRotateExpandedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance = value;
		}
	}

	private Storyboard ExpandCollapseRotateCollapsedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance = value;
		}
	}

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
		}
	}

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
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

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private RotateTransform ExpandCollapseChevronRotateTransform
	{
		get
		{
			return (RotateTransform)_ExpandCollapseChevronRotateTransformSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronRotateTransformSubject.ElementInstance = value;
		}
	}

	private Grid ExpandCollapseChevron
	{
		get
		{
			return (Grid)_ExpandCollapseChevronSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronSubject.ElementInstance = value;
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

	private Grid PresenterContentRootGrid
	{
		get
		{
			return (Grid)_PresenterContentRootGridSubject.ElementInstance;
		}
		set
		{
			_PresenterContentRootGridSubject.ElementInstance = value;
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

	private VisualState Focused
	{
		get
		{
			return (VisualState)_FocusedSubject.ElementInstance;
		}
		set
		{
			_FocusedSubject.ElementInstance = value;
		}
	}

	private VisualState Unfocused
	{
		get
		{
			return (VisualState)_UnfocusedSubject.ElementInstance;
		}
		set
		{
			_UnfocusedSubject.ElementInstance = value;
		}
	}

	private VisualState PointerFocused
	{
		get
		{
			return (VisualState)_PointerFocusedSubject.ElementInstance;
		}
		set
		{
			_PointerFocusedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup FocusStates
	{
		get
		{
			return (VisualStateGroup)_FocusStatesSubject.ElementInstance;
		}
		set
		{
			_FocusStatesSubject.ElementInstance = value;
		}
	}

	private VisualState IconVisible
	{
		get
		{
			return (VisualState)_IconVisibleSubject.ElementInstance;
		}
		set
		{
			_IconVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState IconCollapsed
	{
		get
		{
			return (VisualState)_IconCollapsedSubject.ElementInstance;
		}
		set
		{
			_IconCollapsedSubject.ElementInstance = value;
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

	private VisualState ChevronHidden
	{
		get
		{
			return (VisualState)_ChevronHiddenSubject.ElementInstance;
		}
		set
		{
			_ChevronHiddenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleOpen
	{
		get
		{
			return (VisualState)_ChevronVisibleOpenSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleOpenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleClosed
	{
		get
		{
			return (VisualState)_ChevronVisibleClosedSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleClosedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ChevronStates
	{
		get
		{
			return (VisualStateGroup)_ChevronStatesSubject.ElementInstance;
		}
		set
		{
			_ChevronStatesSubject.ElementInstance = value;
		}
	}

	private VisualState NotClosedCompactAndTopLevelItem
	{
		get
		{
			return (VisualState)_NotClosedCompactAndTopLevelItemSubject.ElementInstance;
		}
		set
		{
			_NotClosedCompactAndTopLevelItemSubject.ElementInstance = value;
		}
	}

	private VisualState ClosedCompactAndTopLevelItem
	{
		get
		{
			return (VisualState)_ClosedCompactAndTopLevelItemSubject.ElementInstance;
		}
		set
		{
			_ClosedCompactAndTopLevelItemSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneAndTopLevelItemStates
	{
		get
		{
			return (VisualStateGroup)_PaneAndTopLevelItemStatesSubject.ElementInstance;
		}
		set
		{
			_PaneAndTopLevelItemStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1140)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)"ExpandCollapseRotateExpandedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 0.0,
						To = 180.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c76)
					{
						Storyboard.SetTargetName(c76, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c76, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c76, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c77)
				{
					nameScope.RegisterName("ExpandCollapseRotateExpandedStoryboard", c77);
					ExpandCollapseRotateExpandedStoryboard = c77;
				}),
				[(object)"ExpandCollapseRotateCollapsedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 180.0,
						To = 0.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c78)
					{
						Storyboard.SetTargetName(c78, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c78, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c78, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c79)
				{
					nameScope.RegisterName("ExpandCollapseRotateCollapsedStoryboard", c79);
					ExpandCollapseRotateCollapsedStoryboard = c79;
				})
			},
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c80)
				{
					nameScope.RegisterName("RevealBorder", c80);
					RevealBorder = c80;
					c80.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c80.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c80.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "PresenterContentRootGrid",
					Children = 
					{
						(UIElement)new Grid
						{
							IsParsing = true,
							Margin = new Thickness(4.0, 0.0, 0.0, 0.0),
							HorizontalAlignment = HorizontalAlignment.Left,
							VerticalAlignment = VerticalAlignment.Center,
							Children = { (UIElement)new Rectangle
							{
								IsParsing = true,
								Name = "SelectionIndicator",
								Width = 2.0,
								Height = 24.0,
								Opacity = 0.0
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c81)
							{
								nameScope.RegisterName("SelectionIndicator", c81);
								SelectionIndicator = c81;
								ResourceResolverSingleton.Instance.ApplyResource(c81, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								c81.SetBinding(Rectangle.RadiusXProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
								});
								c81.SetBinding(Rectangle.RadiusYProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
								});
								_component_0 = c81;
								c81.CreationComplete();
							}) }
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c82)
						{
							c82.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "ContentGrid",
							HorizontalAlignment = HorizontalAlignment.Left,
							ColumnDefinitions = 
							{
								new ColumnDefinition().NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ColumnDefinition c83)
								{
									nameScope.RegisterName("IconColumn", c83);
									IconColumn = c83;
									ResourceResolverSingleton.Instance.ApplyResource(c83, ColumnDefinition.WidthProperty, "NavigationViewCompactPaneLength", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									_component_1 = c83;
									NameScope.SetNameScope(_component_1, nameScope);
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
									Height = 16.0,
									Child = new ContentPresenter
									{
										IsParsing = true,
										Name = "Icon"
									}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c86)
									{
										nameScope.RegisterName("Icon", c86);
										Icon = c86;
										c86.SetBinding(ContentPresenter.ForegroundProperty, new Binding
										{
											Path = "Foreground",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c86.SetBinding(ContentPresenter.ContentProperty, new Binding
										{
											Path = "Icon",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c86.CreationComplete();
									})
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Viewbox c87)
								{
									nameScope.RegisterName("IconBox", c87);
									IconBox = c87;
									ResourceResolverSingleton.Instance.ApplyResource(c87, FrameworkElement.MarginProperty, "NavigationViewItemOnLeftIconBoxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									_component_2 = c87;
									c87.CreationComplete();
								}),
								(UIElement)new ContentPresenter
								{
									IsParsing = true,
									Name = "ContentPresenter"
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c88)
								{
									nameScope.RegisterName("ContentPresenter", c88);
									ContentPresenter = c88;
									Grid.SetColumn(c88, 1);
									c88.SetBinding(ContentPresenter.ForegroundProperty, new Binding
									{
										Path = "Foreground",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c88.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
									{
										Path = "ContentTransitions",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c88.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
									{
										Path = "ContentTemplate",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c88.SetBinding(ContentPresenter.ContentProperty, new Binding
									{
										Path = "Content",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c88.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
									{
										Path = "HorizontalContentAlignment",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c88.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
									{
										Path = "VerticalContentAlignment",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c88.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
									{
										Path = "ContentTemplateSelector",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									ResourceResolverSingleton.Instance.ApplyResource(c88, FrameworkElement.MarginProperty, "NavigationViewItemContentPresenterMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									c88.SetBinding(ContentPresenter.PaddingProperty, new Binding
									{
										Path = "Padding",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									AutomationProperties.SetAccessibilityView(c88, AccessibilityView.Raw);
									_component_3 = c88;
									c88.CreationComplete();
								}),
								(UIElement)new Grid
								{
									IsParsing = true,
									Name = "ExpandCollapseChevron",
									Visibility = Visibility.Collapsed,
									HorizontalAlignment = HorizontalAlignment.Right,
									Width = 40.0,
									Background = SolidColorBrushHelper.Transparent,
									Children = { (UIElement)new TextBlock
									{
										IsParsing = true,
										RenderTransformOrigin = new Point(0.5, 0.5),
										HorizontalAlignment = HorizontalAlignment.Center,
										VerticalAlignment = VerticalAlignment.Center,
										IsTextScaleFactorEnabled = false,
										RenderTransform = new RotateTransform().NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(RotateTransform c89)
										{
											nameScope.RegisterName("ExpandCollapseChevronRotateTransform", c89);
											ExpandCollapseChevronRotateTransform = c89;
										})
									}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(TextBlock c90)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c90, TextBlock.ForegroundProperty, "NavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c90, TextBlock.FontSizeProperty, "NavigationViewItemExpandedGlyphFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c90, TextBlock.TextProperty, "NavigationViewItemExpandedGlyph", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c90, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
										AutomationProperties.SetAccessibilityView(c90, AccessibilityView.Raw);
										_component_4 = c90;
										c90.CreationComplete();
									}) }
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c91)
								{
									nameScope.RegisterName("ExpandCollapseChevron", c91);
									ExpandCollapseChevron = c91;
									Grid.SetColumn(c91, 2);
									ResourceResolverSingleton.Instance.ApplyResource(c91, FrameworkElement.MarginProperty, "NavigationViewItemExpandChevronMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									_component_5 = c91;
									c91.CreationComplete();
								})
							}
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c92)
						{
							nameScope.RegisterName("ContentGrid", c92);
							ContentGrid = c92;
							ResourceResolverSingleton.Instance.ApplyResource(c92, FrameworkElement.MinHeightProperty, "NavigationViewItemOnLeftMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
							_component_6 = c92;
							c92.CreationComplete();
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c93)
				{
					nameScope.RegisterName("PresenterContentRootGrid", c93);
					PresenterContentRootGrid = c93;
					c93.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c94)
		{
			nameScope.RegisterName("LayoutRoot", c94);
			LayoutRoot = c94;
			ResourceResolverSingleton.Instance.ApplyResource(c94, FrameworkElement.MinHeightProperty, "NavigationViewItemOnLeftMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
			c94.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c94, value: true);
			VisualStateManager.SetVisualStateGroups(c94, new VisualStateGroup[5]
			{
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c95)
						{
							nameScope.RegisterName("Enabled", c95);
							Enabled = c95;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c96)
						{
							nameScope.RegisterName("Disabled", c96);
							Disabled = c96;
							MarkupHelper.SetVisualStateLazy(c96, delegate
							{
								c96.Name = "Disabled";
								c96.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Opacity"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ListViewItemDisabledThemeOpacity", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ListViewItemDisabledThemeOpacity", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c97)
				{
					nameScope.RegisterName("DisabledStates", c97);
					DisabledStates = c97;
				}),
				new VisualStateGroup
				{
					Name = "FocusStates",
					States = 
					{
						new VisualState
						{
							Name = "Focused"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c98)
						{
							nameScope.RegisterName("Focused", c98);
							Focused = c98;
							MarkupHelper.SetVisualStateLazy(c98, delegate
							{
								c98.Name = "Focused";
								c98.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlHighlightAccentBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlHighlightAccentBrush", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c98.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlHighlightAltChromeWhiteBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlHighlightAltChromeWhiteBrush", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c98.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlHighlightAltChromeWhiteBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlHighlightAltChromeWhiteBrush", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Unfocused"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c99)
						{
							nameScope.RegisterName("Unfocused", c99);
							Unfocused = c99;
						}),
						new VisualState
						{
							Name = "PointerFocused"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c100)
						{
							nameScope.RegisterName("PointerFocused", c100);
							PointerFocused = c100;
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c101)
				{
					nameScope.RegisterName("FocusStates", c101);
					FocusStates = c101;
				}),
				new VisualStateGroup
				{
					Name = "IconStates",
					States = 
					{
						new VisualState
						{
							Name = "IconVisible"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c102)
						{
							nameScope.RegisterName("IconVisible", c102);
							IconVisible = c102;
						}),
						new VisualState
						{
							Name = "IconCollapsed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c103)
						{
							nameScope.RegisterName("IconCollapsed", c103);
							IconCollapsed = c103;
							MarkupHelper.SetVisualStateLazy(c103, delegate
							{
								c103.Name = "IconCollapsed";
								c103.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c103.Setters.Add(new Setter(new TargetPropertyPath(_IconColumnSubject, (PropertyPath)"Width"), "16"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c104)
				{
					nameScope.RegisterName("IconStates", c104);
					IconStates = c104;
				}),
				new VisualStateGroup
				{
					Name = "ChevronStates",
					States = 
					{
						new VisualState
						{
							Name = "ChevronHidden"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c105)
						{
							nameScope.RegisterName("ChevronHidden", c105);
							ChevronHidden = c105;
						}),
						new VisualState
						{
							Name = "ChevronVisibleOpen"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c106)
						{
							nameScope.RegisterName("ChevronVisibleOpen", c106);
							ChevronVisibleOpen = c106;
							MarkupHelper.SetVisualStateLazy(c106, delegate
							{
								c106.Name = "ChevronVisibleOpen";
								c106.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c106.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "180"));
							});
						}),
						new VisualState
						{
							Name = "ChevronVisibleClosed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c107)
						{
							nameScope.RegisterName("ChevronVisibleClosed", c107);
							ChevronVisibleClosed = c107;
							MarkupHelper.SetVisualStateLazy(c107, delegate
							{
								c107.Name = "ChevronVisibleClosed";
								c107.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c107.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "0"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c108)
				{
					nameScope.RegisterName("ChevronStates", c108);
					ChevronStates = c108;
				}),
				new VisualStateGroup
				{
					Name = "PaneAndTopLevelItemStates",
					States = 
					{
						new VisualState
						{
							Name = "NotClosedCompactAndTopLevelItem"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c109)
						{
							nameScope.RegisterName("NotClosedCompactAndTopLevelItem", c109);
							NotClosedCompactAndTopLevelItem = c109;
						}),
						new VisualState
						{
							Name = "ClosedCompactAndTopLevelItem"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c110)
						{
							nameScope.RegisterName("ClosedCompactAndTopLevelItem", c110);
							ClosedCompactAndTopLevelItem = c110;
							MarkupHelper.SetVisualStateLazy(c110, delegate
							{
								c110.Name = "ClosedCompactAndTopLevelItem";
								c110.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewCompactItemContentPresenterMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewCompactItemContentPresenterMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c111)
				{
					nameScope.RegisterName("PaneAndTopLevelItemStates", c111);
					PaneAndTopLevelItemStates = c111;
				})
			});
			_component_7 = c94;
			c94.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC5
{
	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _IconRowSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
		}
	}

	private RowDefinition IconRow
	{
		get
		{
			return (RowDefinition)_IconRowSubject.ElementInstance;
		}
		set
		{
			_IconRowSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private VisualStateGroup PointerStates
	{
		get
		{
			return (VisualStateGroup)_PointerStatesSubject.ElementInstance;
		}
		set
		{
			_PointerStatesSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_1224)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c112)
				{
					nameScope.RegisterName("PointerRectangle", c112);
					PointerRectangle = c112;
					c112.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c113)
				{
					nameScope.RegisterName("RevealBorder", c113);
					RevealBorder = c113;
					c113.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c113.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c113.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentGrid",
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
					RowDefinitions = 
					{
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(RowDefinition c116)
						{
							nameScope.RegisterName("IconRow", c116);
							IconRow = c116;
						}),
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Star)
						}
					},
					Children = { (UIElement)new Viewbox
					{
						IsParsing = true,
						Name = "IconBox",
						Height = 16.0,
						Width = 48.0,
						Margin = new Thickness(0.0, 0.0, 0.0, 0.0),
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Center,
						Child = new ContentPresenter
						{
							IsParsing = true,
							Name = "Icon"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c118)
						{
							nameScope.RegisterName("Icon", c118);
							Icon = c118;
							c118.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Icon",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c118.SetBinding(ContentPresenter.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c118.CreationComplete();
						})
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Viewbox c119)
					{
						nameScope.RegisterName("IconBox", c119);
						IconBox = c119;
						Grid.SetRow(c119, 1);
						Grid.SetColumn(c119, 1);
						c119.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c120)
				{
					nameScope.RegisterName("ContentGrid", c120);
					ContentGrid = c120;
					c120.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c121)
		{
			nameScope.RegisterName("LayoutRoot", c121);
			LayoutRoot = c121;
			c121.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c121, value: true);
			VisualStateManager.SetVisualStateGroups(c121, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "PointerStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c122)
						{
							nameScope.RegisterName("Normal", c122);
							Normal = c122;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c123)
						{
							nameScope.RegisterName("PointerOver", c123);
							PointerOver = c123;
							MarkupHelper.SetVisualStateLazy(c123, delegate
							{
								c123.Name = "PointerOver";
								c123.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c123.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c123.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c123.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c124)
						{
							nameScope.RegisterName("Pressed", c124);
							Pressed = c124;
							MarkupHelper.SetVisualStateLazy(c124, delegate
							{
								c124.Name = "Pressed";
								c124.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c124.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c124.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c124.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c125)
						{
							nameScope.RegisterName("Selected", c125);
							Selected = c125;
							MarkupHelper.SetVisualStateLazy(c125, delegate
							{
								c125.Name = "Selected";
								c125.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c125.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c125.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c126)
						{
							nameScope.RegisterName("PointerOverSelected", c126);
							PointerOverSelected = c126;
							MarkupHelper.SetVisualStateLazy(c126, delegate
							{
								c126.Name = "PointerOverSelected";
								c126.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c126.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c126.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c126.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c127)
						{
							nameScope.RegisterName("PressedSelected", c127);
							PressedSelected = c127;
							MarkupHelper.SetVisualStateLazy(c127, delegate
							{
								c127.Name = "PressedSelected";
								c127.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c127.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c127.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c127.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c128)
				{
					nameScope.RegisterName("PointerStates", c128);
					PointerStates = c128;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c129)
						{
							nameScope.RegisterName("Enabled", c129);
							Enabled = c129;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c130)
						{
							nameScope.RegisterName("Disabled", c130);
							Disabled = c130;
							MarkupHelper.SetVisualStateLazy(c130, delegate
							{
								c130.Name = "Disabled";
								c130.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c130.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c131)
				{
					nameScope.RegisterName("DisabledStates", c131);
					DisabledStates = c131;
				})
			});
			c121.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC6
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ExpandCollapseRotateExpandedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseRotateCollapsedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronRotateTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnLeftSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ContentOnlySubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewIconPositionStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronHiddenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleOpenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleClosedSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronStatesSubject = new ElementNameSubject();

	private ContentPresenter _component_0
	{
		get
		{
			return (ContentPresenter)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private TextBlock _component_1
	{
		get
		{
			return (TextBlock)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Grid _component_2
	{
		get
		{
			return (Grid)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Rectangle _component_3
	{
		get
		{
			return (Rectangle)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private Storyboard ExpandCollapseRotateExpandedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance = value;
		}
	}

	private Storyboard ExpandCollapseRotateCollapsedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private RotateTransform ExpandCollapseChevronRotateTransform
	{
		get
		{
			return (RotateTransform)_ExpandCollapseChevronRotateTransformSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronRotateTransformSubject.ElementInstance = value;
		}
	}

	private Grid ExpandCollapseChevron
	{
		get
		{
			return (Grid)_ExpandCollapseChevronSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronSubject.ElementInstance = value;
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

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
		}
	}

	private Grid SelectionIndicatorGrid
	{
		get
		{
			return (Grid)_SelectionIndicatorGridSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorGridSubject.ElementInstance = value;
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

	private VisualStateGroup PointerStates
	{
		get
		{
			return (VisualStateGroup)_PointerStatesSubject.ElementInstance;
		}
		set
		{
			_PointerStatesSubject.ElementInstance = value;
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

	private VisualState IconOnLeft
	{
		get
		{
			return (VisualState)_IconOnLeftSubject.ElementInstance;
		}
		set
		{
			_IconOnLeftSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnly
	{
		get
		{
			return (VisualState)_IconOnlySubject.ElementInstance;
		}
		set
		{
			_IconOnlySubject.ElementInstance = value;
		}
	}

	private VisualState ContentOnly
	{
		get
		{
			return (VisualState)_ContentOnlySubject.ElementInstance;
		}
		set
		{
			_ContentOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationViewIconPositionStates
	{
		get
		{
			return (VisualStateGroup)_NavigationViewIconPositionStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationViewIconPositionStatesSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronHidden
	{
		get
		{
			return (VisualState)_ChevronHiddenSubject.ElementInstance;
		}
		set
		{
			_ChevronHiddenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleOpen
	{
		get
		{
			return (VisualState)_ChevronVisibleOpenSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleOpenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleClosed
	{
		get
		{
			return (VisualState)_ChevronVisibleClosedSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleClosedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ChevronStates
	{
		get
		{
			return (VisualStateGroup)_ChevronStatesSubject.ElementInstance;
		}
		set
		{
			_ChevronStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1285)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)"ExpandCollapseRotateExpandedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 0.0,
						To = 180.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c132)
					{
						Storyboard.SetTargetName(c132, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c132, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c132, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c133)
				{
					nameScope.RegisterName("ExpandCollapseRotateExpandedStoryboard", c133);
					ExpandCollapseRotateExpandedStoryboard = c133;
				}),
				[(object)"ExpandCollapseRotateCollapsedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 180.0,
						To = 0.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c134)
					{
						Storyboard.SetTargetName(c134, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c134, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c134, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c135)
				{
					nameScope.RegisterName("ExpandCollapseRotateCollapsedStoryboard", c135);
					ExpandCollapseRotateCollapsedStoryboard = c135;
				})
			},
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent,
					Visibility = Visibility.Collapsed
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c136)
				{
					nameScope.RegisterName("PointerRectangle", c136);
					PointerRectangle = c136;
					c136.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Border c137)
				{
					nameScope.RegisterName("RevealBorder", c137);
					RevealBorder = c137;
					c137.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c137.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c137.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentGrid",
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
						(UIElement)new Viewbox
						{
							IsParsing = true,
							Name = "IconBox",
							Height = 16.0,
							Width = 16.0,
							Margin = new Thickness(16.0, 0.0, 0.0, 0.0),
							VerticalAlignment = VerticalAlignment.Center,
							HorizontalAlignment = HorizontalAlignment.Center,
							Child = new ContentPresenter
							{
								IsParsing = true,
								Name = "Icon"
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c141)
							{
								nameScope.RegisterName("Icon", c141);
								Icon = c141;
								c141.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Icon",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c141.SetBinding(ContentPresenter.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c141.CreationComplete();
							})
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Viewbox c142)
						{
							nameScope.RegisterName("IconBox", c142);
							IconBox = c142;
							c142.CreationComplete();
						}),
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter",
							TextWrapping = TextWrapping.NoWrap,
							VerticalAlignment = VerticalAlignment.Center
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c143)
						{
							nameScope.RegisterName("ContentPresenter", c143);
							ContentPresenter = c143;
							Grid.SetColumn(c143, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c143, FrameworkElement.MarginProperty, "TopNavigationViewItemContentPresenterMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
							c143.SetBinding(ContentPresenter.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c143.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c143.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c143.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c143.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
							{
								Path = "HorizontalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c143.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
							{
								Path = "ContentTemplateSelector",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c143, AccessibilityView.Raw);
							_component_0 = c143;
							c143.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "ExpandCollapseChevron",
							Visibility = Visibility.Collapsed,
							HorizontalAlignment = HorizontalAlignment.Right,
							Width = 40.0,
							Background = SolidColorBrushHelper.Transparent,
							Children = { (UIElement)new TextBlock
							{
								IsParsing = true,
								RenderTransformOrigin = new Point(0.5, 0.5),
								VerticalAlignment = VerticalAlignment.Center,
								HorizontalAlignment = HorizontalAlignment.Center,
								IsTextScaleFactorEnabled = false,
								RenderTransform = new RotateTransform().NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(RotateTransform c144)
								{
									nameScope.RegisterName("ExpandCollapseChevronRotateTransform", c144);
									ExpandCollapseChevronRotateTransform = c144;
								})
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(TextBlock c145)
							{
								ResourceResolverSingleton.Instance.ApplyResource(c145, TextBlock.ForegroundProperty, "NavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c145, TextBlock.FontSizeProperty, "NavigationViewItemExpandedGlyphFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c145, TextBlock.TextProperty, "NavigationViewItemExpandedGlyph", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c145, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								AutomationProperties.SetAccessibilityView(c145, AccessibilityView.Raw);
								_component_1 = c145;
								c145.CreationComplete();
							}) }
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c146)
						{
							nameScope.RegisterName("ExpandCollapseChevron", c146);
							ExpandCollapseChevron = c146;
							Grid.SetColumn(c146, 2);
							ResourceResolverSingleton.Instance.ApplyResource(c146, FrameworkElement.MarginProperty, "TopNavigationViewItemExpandChevronMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
							_component_2 = c146;
							c146.CreationComplete();
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c147)
				{
					nameScope.RegisterName("ContentGrid", c147);
					ContentGrid = c147;
					c147.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "SelectionIndicatorGrid",
					Margin = new Thickness(16.0, 0.0, 16.0, 4.0),
					VerticalAlignment = VerticalAlignment.Bottom,
					Children = { (UIElement)new Rectangle
					{
						IsParsing = true,
						Name = "SelectionIndicator",
						Height = 2.0,
						Opacity = 0.0
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c148)
					{
						nameScope.RegisterName("SelectionIndicator", c148);
						SelectionIndicator = c148;
						ResourceResolverSingleton.Instance.ApplyResource(c148, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
						c148.SetBinding(Rectangle.RadiusXProperty, new Binding
						{
							Path = "CornerRadius",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
						});
						c148.SetBinding(Rectangle.RadiusYProperty, new Binding
						{
							Path = "CornerRadius",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
						});
						_component_3 = c148;
						c148.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c149)
				{
					nameScope.RegisterName("SelectionIndicatorGrid", c149);
					SelectionIndicatorGrid = c149;
					c149.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c150)
		{
			nameScope.RegisterName("LayoutRoot", c150);
			LayoutRoot = c150;
			c150.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c150, value: true);
			VisualStateManager.SetVisualStateGroups(c150, new VisualStateGroup[4]
			{
				new VisualStateGroup
				{
					Name = "PointerStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c151)
						{
							nameScope.RegisterName("Normal", c151);
							Normal = c151;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c152)
						{
							nameScope.RegisterName("PointerOver", c152);
							PointerOver = c152;
							MarkupHelper.SetVisualStateLazy(c152, delegate
							{
								c152.Name = "PointerOver";
								c152.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c152.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c152.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c152.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c152.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c153)
						{
							nameScope.RegisterName("Pressed", c153);
							Pressed = c153;
							MarkupHelper.SetVisualStateLazy(c153, delegate
							{
								c153.Name = "Pressed";
								c153.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c153.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c153.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c153.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c153.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c154)
						{
							nameScope.RegisterName("Selected", c154);
							Selected = c154;
							MarkupHelper.SetVisualStateLazy(c154, delegate
							{
								c154.Name = "Selected";
								c154.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c154.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c154.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c154.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c155)
						{
							nameScope.RegisterName("PointerOverSelected", c155);
							PointerOverSelected = c155;
							MarkupHelper.SetVisualStateLazy(c155, delegate
							{
								c155.Name = "PointerOverSelected";
								c155.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c155.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c155.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c155.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c155.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c156)
						{
							nameScope.RegisterName("PressedSelected", c156);
							PressedSelected = c156;
							MarkupHelper.SetVisualStateLazy(c156, delegate
							{
								c156.Name = "PressedSelected";
								c156.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c156.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c156.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c156.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c156.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Microsoft.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c157)
				{
					nameScope.RegisterName("PointerStates", c157);
					PointerStates = c157;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c158)
						{
							nameScope.RegisterName("Enabled", c158);
							Enabled = c158;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c159)
						{
							nameScope.RegisterName("Disabled", c159);
							Disabled = c159;
							MarkupHelper.SetVisualStateLazy(c159, delegate
							{
								c159.Name = "Disabled";
								c159.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c159.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c159.Setters.Add(new Setter(new TargetPropertyPath(_RevealBorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBorderBrushCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBorderBrushCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c160)
				{
					nameScope.RegisterName("DisabledStates", c160);
					DisabledStates = c160;
				}),
				new VisualStateGroup
				{
					Name = "NavigationViewIconPositionStates",
					States = 
					{
						new VisualState
						{
							Name = "IconOnLeft"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c161)
						{
							nameScope.RegisterName("IconOnLeft", c161);
							IconOnLeft = c161;
						}),
						new VisualState
						{
							Name = "IconOnly"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c162)
						{
							nameScope.RegisterName("IconOnly", c162);
							IconOnly = c162;
							MarkupHelper.SetVisualStateLazy(c162, delegate
							{
								c162.Name = "IconOnly";
								c162.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Visibility"), "Visible"));
								c162.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"MinWidth"), "48"));
								c162.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c162.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "4,0,4,4"));
								c162.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemIconOnlyExpandChevronMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemIconOnlyExpandChevronMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "ContentOnly"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c163)
						{
							nameScope.RegisterName("ContentOnly", c163);
							ContentOnly = c163;
							MarkupHelper.SetVisualStateLazy(c163, delegate
							{
								c163.Name = "ContentOnly";
								c163.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c163.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemContentOnlyContentPresenterMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemContentOnlyContentPresenterMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c163.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "12,0,12,4"));
								c163.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemContentOnlyExpandChevronMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemContentOnlyExpandChevronMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c164)
				{
					nameScope.RegisterName("NavigationViewIconPositionStates", c164);
					NavigationViewIconPositionStates = c164;
				}),
				new VisualStateGroup
				{
					Name = "ChevronStates",
					States = 
					{
						new VisualState
						{
							Name = "ChevronHidden"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c165)
						{
							nameScope.RegisterName("ChevronHidden", c165);
							ChevronHidden = c165;
						}),
						new VisualState
						{
							Name = "ChevronVisibleOpen"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c166)
						{
							nameScope.RegisterName("ChevronVisibleOpen", c166);
							ChevronVisibleOpen = c166;
							MarkupHelper.SetVisualStateLazy(c166, delegate
							{
								c166.Name = "ChevronVisibleOpen";
								c166.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c166.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "180"));
							});
						}),
						new VisualState
						{
							Name = "ChevronVisibleClosed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c167)
						{
							nameScope.RegisterName("ChevronVisibleClosed", c167);
							ChevronVisibleClosed = c167;
							MarkupHelper.SetVisualStateLazy(c167, delegate
							{
								c167.Name = "ChevronVisibleClosed";
								c167.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "0"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c168)
				{
					nameScope.RegisterName("ChevronStates", c168);
					ChevronStates = c168;
				})
			});
			c150.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC7
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ExpandCollapseRotateExpandedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseRotateCollapsedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronRotateTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _FocusedSubject = new ElementNameSubject();

	private ElementNameSubject _UnfocusedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerFocusedSubject = new ElementNameSubject();

	private ElementNameSubject _FocusStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnLeftSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ContentOnlySubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewIconPositionStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronHiddenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleOpenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleClosedSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronStatesSubject = new ElementNameSubject();

	private ContentPresenter _component_0
	{
		get
		{
			return (ContentPresenter)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private TextBlock _component_1
	{
		get
		{
			return (TextBlock)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Grid _component_2
	{
		get
		{
			return (Grid)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Rectangle _component_3
	{
		get
		{
			return (Rectangle)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private Storyboard ExpandCollapseRotateExpandedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance = value;
		}
	}

	private Storyboard ExpandCollapseRotateCollapsedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private RotateTransform ExpandCollapseChevronRotateTransform
	{
		get
		{
			return (RotateTransform)_ExpandCollapseChevronRotateTransformSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronRotateTransformSubject.ElementInstance = value;
		}
	}

	private Grid ExpandCollapseChevron
	{
		get
		{
			return (Grid)_ExpandCollapseChevronSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronSubject.ElementInstance = value;
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

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
		}
	}

	private Grid SelectionIndicatorGrid
	{
		get
		{
			return (Grid)_SelectionIndicatorGridSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorGridSubject.ElementInstance = value;
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

	private VisualState Focused
	{
		get
		{
			return (VisualState)_FocusedSubject.ElementInstance;
		}
		set
		{
			_FocusedSubject.ElementInstance = value;
		}
	}

	private VisualState Unfocused
	{
		get
		{
			return (VisualState)_UnfocusedSubject.ElementInstance;
		}
		set
		{
			_UnfocusedSubject.ElementInstance = value;
		}
	}

	private VisualState PointerFocused
	{
		get
		{
			return (VisualState)_PointerFocusedSubject.ElementInstance;
		}
		set
		{
			_PointerFocusedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup FocusStates
	{
		get
		{
			return (VisualStateGroup)_FocusStatesSubject.ElementInstance;
		}
		set
		{
			_FocusStatesSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnLeft
	{
		get
		{
			return (VisualState)_IconOnLeftSubject.ElementInstance;
		}
		set
		{
			_IconOnLeftSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnly
	{
		get
		{
			return (VisualState)_IconOnlySubject.ElementInstance;
		}
		set
		{
			_IconOnlySubject.ElementInstance = value;
		}
	}

	private VisualState ContentOnly
	{
		get
		{
			return (VisualState)_ContentOnlySubject.ElementInstance;
		}
		set
		{
			_ContentOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationViewIconPositionStates
	{
		get
		{
			return (VisualStateGroup)_NavigationViewIconPositionStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationViewIconPositionStatesSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronHidden
	{
		get
		{
			return (VisualState)_ChevronHiddenSubject.ElementInstance;
		}
		set
		{
			_ChevronHiddenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleOpen
	{
		get
		{
			return (VisualState)_ChevronVisibleOpenSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleOpenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleClosed
	{
		get
		{
			return (VisualState)_ChevronVisibleClosedSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleClosedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ChevronStates
	{
		get
		{
			return (VisualStateGroup)_ChevronStatesSubject.ElementInstance;
		}
		set
		{
			_ChevronStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1423)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)"ExpandCollapseRotateExpandedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 0.0,
						To = 180.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c169)
					{
						Storyboard.SetTargetName(c169, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c169, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c169, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c170)
				{
					nameScope.RegisterName("ExpandCollapseRotateExpandedStoryboard", c170);
					ExpandCollapseRotateExpandedStoryboard = c170;
				}),
				[(object)"ExpandCollapseRotateCollapsedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 180.0,
						To = 0.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c171)
					{
						Storyboard.SetTargetName(c171, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c171, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c171, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c172)
				{
					nameScope.RegisterName("ExpandCollapseRotateCollapsedStoryboard", c172);
					ExpandCollapseRotateCollapsedStoryboard = c172;
				})
			},
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent,
					Visibility = Visibility.Collapsed
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c173)
				{
					nameScope.RegisterName("PointerRectangle", c173);
					PointerRectangle = c173;
					c173.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentGrid",
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
						(UIElement)new Viewbox
						{
							IsParsing = true,
							Name = "IconBox",
							Height = 16.0,
							Width = 16.0,
							Margin = new Thickness(16.0, 0.0, 0.0, 0.0),
							VerticalAlignment = VerticalAlignment.Center,
							HorizontalAlignment = HorizontalAlignment.Center,
							Child = new ContentPresenter
							{
								IsParsing = true,
								Name = "Icon"
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c177)
							{
								nameScope.RegisterName("Icon", c177);
								Icon = c177;
								c177.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Icon",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c177.SetBinding(ContentPresenter.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c177.CreationComplete();
							})
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Viewbox c178)
						{
							nameScope.RegisterName("IconBox", c178);
							IconBox = c178;
							c178.CreationComplete();
						}),
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter",
							TextWrapping = TextWrapping.NoWrap,
							VerticalAlignment = VerticalAlignment.Center
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c179)
						{
							nameScope.RegisterName("ContentPresenter", c179);
							ContentPresenter = c179;
							Grid.SetColumn(c179, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c179, FrameworkElement.MarginProperty, "TopNavigationViewItemContentPresenterMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
							c179.SetBinding(ContentPresenter.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c179.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c179.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c179.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c179, AccessibilityView.Raw);
							_component_0 = c179;
							c179.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "ExpandCollapseChevron",
							Visibility = Visibility.Collapsed,
							HorizontalAlignment = HorizontalAlignment.Right,
							Width = 40.0,
							Background = SolidColorBrushHelper.Transparent,
							Children = { (UIElement)new TextBlock
							{
								IsParsing = true,
								RenderTransformOrigin = new Point(0.5, 0.5),
								VerticalAlignment = VerticalAlignment.Center,
								HorizontalAlignment = HorizontalAlignment.Center,
								IsTextScaleFactorEnabled = false,
								RenderTransform = new RotateTransform().NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(RotateTransform c180)
								{
									nameScope.RegisterName("ExpandCollapseChevronRotateTransform", c180);
									ExpandCollapseChevronRotateTransform = c180;
								})
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(TextBlock c181)
							{
								ResourceResolverSingleton.Instance.ApplyResource(c181, TextBlock.ForegroundProperty, "NavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c181, TextBlock.FontSizeProperty, "NavigationViewItemExpandedGlyphFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c181, TextBlock.TextProperty, "NavigationViewItemExpandedGlyph", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c181, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								AutomationProperties.SetAccessibilityView(c181, AccessibilityView.Raw);
								_component_1 = c181;
								c181.CreationComplete();
							}) }
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c182)
						{
							nameScope.RegisterName("ExpandCollapseChevron", c182);
							ExpandCollapseChevron = c182;
							Grid.SetColumn(c182, 2);
							ResourceResolverSingleton.Instance.ApplyResource(c182, FrameworkElement.MarginProperty, "NavigationViewItemExpandChevronMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
							_component_2 = c182;
							c182.CreationComplete();
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c183)
				{
					nameScope.RegisterName("ContentGrid", c183);
					ContentGrid = c183;
					c183.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "SelectionIndicatorGrid",
					Margin = new Thickness(16.0, 0.0, 16.0, 4.0),
					VerticalAlignment = VerticalAlignment.Bottom,
					Children = { (UIElement)new Rectangle
					{
						IsParsing = true,
						Name = "SelectionIndicator",
						Height = 2.0,
						Opacity = 0.0
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c184)
					{
						nameScope.RegisterName("SelectionIndicator", c184);
						SelectionIndicator = c184;
						ResourceResolverSingleton.Instance.ApplyResource(c184, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
						c184.SetBinding(Rectangle.RadiusXProperty, new Binding
						{
							Path = "CornerRadius",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
						});
						c184.SetBinding(Rectangle.RadiusYProperty, new Binding
						{
							Path = "CornerRadius",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
						});
						_component_3 = c184;
						c184.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c185)
				{
					nameScope.RegisterName("SelectionIndicatorGrid", c185);
					SelectionIndicatorGrid = c185;
					c185.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c186)
		{
			nameScope.RegisterName("LayoutRoot", c186);
			LayoutRoot = c186;
			c186.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c186, value: true);
			VisualStateManager.SetVisualStateGroups(c186, new VisualStateGroup[4]
			{
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c187)
						{
							nameScope.RegisterName("Enabled", c187);
							Enabled = c187;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c188)
						{
							nameScope.RegisterName("Disabled", c188);
							Disabled = c188;
							MarkupHelper.SetVisualStateLazy(c188, delegate
							{
								c188.Name = "Disabled";
								c188.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c188.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c189)
				{
					nameScope.RegisterName("DisabledStates", c189);
					DisabledStates = c189;
				}),
				new VisualStateGroup
				{
					Name = "FocusStates",
					States = 
					{
						new VisualState
						{
							Name = "Focused"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c190)
						{
							nameScope.RegisterName("Focused", c190);
							Focused = c190;
							MarkupHelper.SetVisualStateLazy(c190, delegate
							{
								c190.Name = "Focused";
								c190.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemRevealBackgroundFocused", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemRevealBackgroundFocused", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c190.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemRevealIconForegroundFocused", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemRevealIconForegroundFocused", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c190.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemRevealContentForegroundFocused", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemRevealContentForegroundFocused", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Unfocused"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c191)
						{
							nameScope.RegisterName("Unfocused", c191);
							Unfocused = c191;
						}),
						new VisualState
						{
							Name = "PointerFocused"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c192)
						{
							nameScope.RegisterName("PointerFocused", c192);
							PointerFocused = c192;
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c193)
				{
					nameScope.RegisterName("FocusStates", c193);
					FocusStates = c193;
				}),
				new VisualStateGroup
				{
					Name = "NavigationViewIconPositionStates",
					States = 
					{
						new VisualState
						{
							Name = "IconOnLeft"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c194)
						{
							nameScope.RegisterName("IconOnLeft", c194);
							IconOnLeft = c194;
						}),
						new VisualState
						{
							Name = "IconOnly"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c195)
						{
							nameScope.RegisterName("IconOnly", c195);
							IconOnly = c195;
							MarkupHelper.SetVisualStateLazy(c195, delegate
							{
								c195.Name = "IconOnly";
								c195.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Visibility"), "Visible"));
								c195.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"MinWidth"), "48"));
								c195.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c195.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "4,0"));
								c195.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemIconOnlyExpandChevronMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemIconOnlyExpandChevronMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "ContentOnly"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c196)
						{
							nameScope.RegisterName("ContentOnly", c196);
							ContentOnly = c196;
							MarkupHelper.SetVisualStateLazy(c196, delegate
							{
								c196.Name = "ContentOnly";
								c196.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c196.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemContentOnlyContentPresenterMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemContentOnlyContentPresenterMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c196.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "12,0"));
								c196.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemContentOnlyExpandChevronMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemContentOnlyExpandChevronMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c197)
				{
					nameScope.RegisterName("NavigationViewIconPositionStates", c197);
					NavigationViewIconPositionStates = c197;
				}),
				new VisualStateGroup
				{
					Name = "ChevronStates",
					States = 
					{
						new VisualState
						{
							Name = "ChevronHidden"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c198)
						{
							nameScope.RegisterName("ChevronHidden", c198);
							ChevronHidden = c198;
						}),
						new VisualState
						{
							Name = "ChevronVisibleOpen"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c199)
						{
							nameScope.RegisterName("ChevronVisibleOpen", c199);
							ChevronVisibleOpen = c199;
							MarkupHelper.SetVisualStateLazy(c199, delegate
							{
								c199.Name = "ChevronVisibleOpen";
								c199.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c199.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "180"));
							});
						}),
						new VisualState
						{
							Name = "ChevronVisibleClosed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c200)
						{
							nameScope.RegisterName("ChevronVisibleClosed", c200);
							ChevronVisibleClosed = c200;
							MarkupHelper.SetVisualStateLazy(c200, delegate
							{
								c200.Name = "ChevronVisibleClosed";
								c200.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c200.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "0"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c201)
				{
					nameScope.RegisterName("ChevronStates", c201);
					ChevronStates = c201;
				})
			});
			c186.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_NavigationView_rs1_themeresources_v1RDSC8
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ExpandCollapseRotateExpandedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseRotateCollapsedStoryboardSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronRotateTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandCollapseChevronSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _PresenterContentRootGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnLeftSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ContentOnlySubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewIconPositionStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronHiddenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleOpenSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronVisibleClosedSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronStatesSubject = new ElementNameSubject();

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

	private ContentPresenter _component_1
	{
		get
		{
			return (ContentPresenter)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private TextBlock _component_2
	{
		get
		{
			return (TextBlock)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Grid _component_3
	{
		get
		{
			return (Grid)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private Storyboard ExpandCollapseRotateExpandedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateExpandedStoryboardSubject.ElementInstance = value;
		}
	}

	private Storyboard ExpandCollapseRotateCollapsedStoryboard
	{
		get
		{
			return (Storyboard)_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseRotateCollapsedStoryboardSubject.ElementInstance = value;
		}
	}

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private RotateTransform ExpandCollapseChevronRotateTransform
	{
		get
		{
			return (RotateTransform)_ExpandCollapseChevronRotateTransformSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronRotateTransformSubject.ElementInstance = value;
		}
	}

	private Grid ExpandCollapseChevron
	{
		get
		{
			return (Grid)_ExpandCollapseChevronSubject.ElementInstance;
		}
		set
		{
			_ExpandCollapseChevronSubject.ElementInstance = value;
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

	private Grid PresenterContentRootGrid
	{
		get
		{
			return (Grid)_PresenterContentRootGridSubject.ElementInstance;
		}
		set
		{
			_PresenterContentRootGridSubject.ElementInstance = value;
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

	private VisualStateGroup PointerStates
	{
		get
		{
			return (VisualStateGroup)_PointerStatesSubject.ElementInstance;
		}
		set
		{
			_PointerStatesSubject.ElementInstance = value;
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

	private VisualState IconOnLeft
	{
		get
		{
			return (VisualState)_IconOnLeftSubject.ElementInstance;
		}
		set
		{
			_IconOnLeftSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnly
	{
		get
		{
			return (VisualState)_IconOnlySubject.ElementInstance;
		}
		set
		{
			_IconOnlySubject.ElementInstance = value;
		}
	}

	private VisualState ContentOnly
	{
		get
		{
			return (VisualState)_ContentOnlySubject.ElementInstance;
		}
		set
		{
			_ContentOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationViewIconPositionStates
	{
		get
		{
			return (VisualStateGroup)_NavigationViewIconPositionStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationViewIconPositionStatesSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronHidden
	{
		get
		{
			return (VisualState)_ChevronHiddenSubject.ElementInstance;
		}
		set
		{
			_ChevronHiddenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleOpen
	{
		get
		{
			return (VisualState)_ChevronVisibleOpenSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleOpenSubject.ElementInstance = value;
		}
	}

	private VisualState ChevronVisibleClosed
	{
		get
		{
			return (VisualState)_ChevronVisibleClosedSubject.ElementInstance;
		}
		set
		{
			_ChevronVisibleClosedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ChevronStates
	{
		get
		{
			return (VisualStateGroup)_ChevronStatesSubject.ElementInstance;
		}
		set
		{
			_ChevronStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1519)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)"ExpandCollapseRotateExpandedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 0.0,
						To = 180.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c202)
					{
						Storyboard.SetTargetName(c202, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c202, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c202, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c203)
				{
					nameScope.RegisterName("ExpandCollapseRotateExpandedStoryboard", c203);
					ExpandCollapseRotateExpandedStoryboard = c203;
				}),
				[(object)"ExpandCollapseRotateCollapsedStoryboard"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimation
					{
						From = 180.0,
						To = 0.0,
						Duration = new Duration(TimeSpan.FromTicks(1000000L))
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(DoubleAnimation c204)
					{
						Storyboard.SetTargetName(c204, "ExpandCollapseChevronRotateTransform");
						Storyboard.SetTarget(c204, _ExpandCollapseChevronRotateTransformSubject);
						Storyboard.SetTargetProperty(c204, "Angle");
					}) }
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Storyboard c205)
				{
					nameScope.RegisterName("ExpandCollapseRotateCollapsedStoryboard", c205);
					ExpandCollapseRotateCollapsedStoryboard = c205;
				})
			},
			Name = "LayoutRoot",
			Height = 40.0,
			Children = { (UIElement)new Grid
			{
				IsParsing = true,
				Name = "PresenterContentRootGrid",
				Children = 
				{
					(UIElement)new Grid
					{
						IsParsing = true,
						Margin = new Thickness(4.0, 0.0, 0.0, 0.0),
						HorizontalAlignment = HorizontalAlignment.Left,
						VerticalAlignment = VerticalAlignment.Center,
						Children = { (UIElement)new Rectangle
						{
							IsParsing = true,
							Name = "SelectionIndicator",
							Width = 2.0,
							Height = 24.0,
							Opacity = 0.0
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Rectangle c206)
						{
							nameScope.RegisterName("SelectionIndicator", c206);
							SelectionIndicator = c206;
							ResourceResolverSingleton.Instance.ApplyResource(c206, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
							c206.SetBinding(Rectangle.RadiusXProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
							});
							c206.SetBinding(Rectangle.RadiusYProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)
							});
							_component_0 = c206;
							c206.CreationComplete();
						}) }
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c207)
					{
						c207.CreationComplete();
					}),
					(UIElement)new Grid
					{
						IsParsing = true,
						Name = "ContentGrid",
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
							(UIElement)new Viewbox
							{
								IsParsing = true,
								Name = "IconBox",
								Height = 16.0,
								Width = 16.0,
								Margin = new Thickness(16.0, 0.0, 0.0, 0.0),
								VerticalAlignment = VerticalAlignment.Center,
								HorizontalAlignment = HorizontalAlignment.Center,
								Child = new ContentPresenter
								{
									IsParsing = true,
									Name = "Icon"
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c211)
								{
									nameScope.RegisterName("Icon", c211);
									Icon = c211;
									c211.SetBinding(ContentPresenter.ContentProperty, new Binding
									{
										Path = "Icon",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c211.SetBinding(ContentPresenter.ForegroundProperty, new Binding
									{
										Path = "Foreground",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c211.CreationComplete();
								})
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Viewbox c212)
							{
								nameScope.RegisterName("IconBox", c212);
								IconBox = c212;
								c212.CreationComplete();
							}),
							(UIElement)new ContentPresenter
							{
								IsParsing = true,
								Name = "ContentPresenter",
								TextWrapping = TextWrapping.NoWrap,
								VerticalAlignment = VerticalAlignment.Center
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(ContentPresenter c213)
							{
								nameScope.RegisterName("ContentPresenter", c213);
								ContentPresenter = c213;
								Grid.SetColumn(c213, 1);
								ResourceResolverSingleton.Instance.ApplyResource(c213, FrameworkElement.MarginProperty, "TopNavigationViewItemOnOverflowContentPresenterMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								c213.SetBinding(ContentPresenter.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c213.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
								{
									Path = "ContentTransitions",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c213.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
								{
									Path = "ContentTemplate",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c213.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Content",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c213.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
								{
									Path = "HorizontalContentAlignment",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c213.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
								{
									Path = "ContentTemplateSelector",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								AutomationProperties.SetAccessibilityView(c213, AccessibilityView.Raw);
								_component_1 = c213;
								c213.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "ExpandCollapseChevron",
								Visibility = Visibility.Collapsed,
								HorizontalAlignment = HorizontalAlignment.Right,
								Width = 40.0,
								Background = SolidColorBrushHelper.Transparent,
								Children = { (UIElement)new TextBlock
								{
									IsParsing = true,
									RenderTransformOrigin = new Point(0.5, 0.5),
									HorizontalAlignment = HorizontalAlignment.Center,
									VerticalAlignment = VerticalAlignment.Center,
									IsTextScaleFactorEnabled = false,
									RenderTransform = new RotateTransform().NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(RotateTransform c214)
									{
										nameScope.RegisterName("ExpandCollapseChevronRotateTransform", c214);
										ExpandCollapseChevronRotateTransform = c214;
									})
								}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(TextBlock c215)
								{
									ResourceResolverSingleton.Instance.ApplyResource(c215, TextBlock.ForegroundProperty, "NavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									ResourceResolverSingleton.Instance.ApplyResource(c215, TextBlock.FontSizeProperty, "NavigationViewItemExpandedGlyphFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									ResourceResolverSingleton.Instance.ApplyResource(c215, TextBlock.TextProperty, "NavigationViewItemExpandedGlyph", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									ResourceResolverSingleton.Instance.ApplyResource(c215, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
									AutomationProperties.SetAccessibilityView(c215, AccessibilityView.Raw);
									_component_2 = c215;
									c215.CreationComplete();
								}) }
							}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c216)
							{
								nameScope.RegisterName("ExpandCollapseChevron", c216);
								ExpandCollapseChevron = c216;
								Grid.SetColumn(c216, 2);
								ResourceResolverSingleton.Instance.ApplyResource(c216, FrameworkElement.MarginProperty, "TopNavigationViewItemOnOverflowExpandChevronMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c216, Grid.PaddingProperty, "TopNavigationViewItemOnOverflowExpandChevronPadding", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_);
								_component_3 = c216;
								c216.CreationComplete();
							})
						}
					}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c217)
					{
						nameScope.RegisterName("ContentGrid", c217);
						ContentGrid = c217;
						c217.CreationComplete();
					})
				}
			}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c218)
			{
				nameScope.RegisterName("PresenterContentRootGrid", c218);
				PresenterContentRootGrid = c218;
				c218.CreationComplete();
			}) }
		}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(Grid c219)
		{
			nameScope.RegisterName("LayoutRoot", c219);
			LayoutRoot = c219;
			c219.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c219, value: true);
			VisualStateManager.SetVisualStateGroups(c219, new VisualStateGroup[4]
			{
				new VisualStateGroup
				{
					Name = "PointerStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c220)
						{
							nameScope.RegisterName("Normal", c220);
							Normal = c220;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c221)
						{
							nameScope.RegisterName("PointerOver", c221);
							PointerOver = c221;
							MarkupHelper.SetVisualStateLazy(c221, delegate
							{
								c221.Name = "PointerOver";
								c221.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c221.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c221.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c222)
						{
							nameScope.RegisterName("Pressed", c222);
							Pressed = c222;
							MarkupHelper.SetVisualStateLazy(c222, delegate
							{
								c222.Name = "Pressed";
								c222.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c222.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c222.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c223)
						{
							nameScope.RegisterName("Selected", c223);
							Selected = c223;
							MarkupHelper.SetVisualStateLazy(c223, delegate
							{
								c223.Name = "Selected";
								c223.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c223.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c223.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c224)
						{
							nameScope.RegisterName("PointerOverSelected", c224);
							PointerOverSelected = c224;
							MarkupHelper.SetVisualStateLazy(c224, delegate
							{
								c224.Name = "PointerOverSelected";
								c224.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c224.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c224.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c225)
						{
							nameScope.RegisterName("PressedSelected", c225);
							PressedSelected = c225;
							MarkupHelper.SetVisualStateLazy(c225, delegate
							{
								c225.Name = "PressedSelected";
								c225.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c225.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c225.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c226)
				{
					nameScope.RegisterName("PointerStates", c226);
					PointerStates = c226;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c227)
						{
							nameScope.RegisterName("Enabled", c227);
							Enabled = c227;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c228)
						{
							nameScope.RegisterName("Disabled", c228);
							Disabled = c228;
							MarkupHelper.SetVisualStateLazy(c228, delegate
							{
								c228.Name = "Disabled";
								c228.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c228.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c229)
				{
					nameScope.RegisterName("DisabledStates", c229);
					DisabledStates = c229;
				}),
				new VisualStateGroup
				{
					Name = "NavigationViewIconPositionStates",
					States = 
					{
						new VisualState
						{
							Name = "IconOnLeft"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c230)
						{
							nameScope.RegisterName("IconOnLeft", c230);
							IconOnLeft = c230;
						}),
						new VisualState
						{
							Name = "IconOnly"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c231)
						{
							nameScope.RegisterName("IconOnly", c231);
							IconOnly = c231;
						}),
						new VisualState
						{
							Name = "ContentOnly"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c232)
						{
							nameScope.RegisterName("ContentOnly", c232);
							ContentOnly = c232;
							MarkupHelper.SetVisualStateLazy(c232, delegate
							{
								c232.Name = "ContentOnly";
								c232.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c232.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemOnOverflowNoIconContentPresenterMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemOnOverflowNoIconContentPresenterMargin", GlobalStaticResources.ResourceDictionarySingleton__41.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c233)
				{
					nameScope.RegisterName("NavigationViewIconPositionStates", c233);
					NavigationViewIconPositionStates = c233;
				}),
				new VisualStateGroup
				{
					Name = "ChevronStates",
					States = 
					{
						new VisualState
						{
							Name = "ChevronHidden"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c234)
						{
							nameScope.RegisterName("ChevronHidden", c234);
							ChevronHidden = c234;
						}),
						new VisualState
						{
							Name = "ChevronVisibleOpen"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c235)
						{
							nameScope.RegisterName("ChevronVisibleOpen", c235);
							ChevronVisibleOpen = c235;
							MarkupHelper.SetVisualStateLazy(c235, delegate
							{
								c235.Name = "ChevronVisibleOpen";
								c235.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c235.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "180"));
							});
						}),
						new VisualState
						{
							Name = "ChevronVisibleClosed"
						}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualState c236)
						{
							nameScope.RegisterName("ChevronVisibleClosed", c236);
							ChevronVisibleClosed = c236;
							MarkupHelper.SetVisualStateLazy(c236, delegate
							{
								c236.Name = "ChevronVisibleClosed";
								c236.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronSubject, (PropertyPath)"Visibility"), "Visible"));
								c236.Setters.Add(new Setter(new TargetPropertyPath(_ExpandCollapseChevronRotateTransformSubject, (PropertyPath)"Angle"), "0"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_v1_ccee9ef9660b015d4662a949742b87be_XamlApply(delegate(VisualStateGroup c237)
				{
					nameScope.RegisterName("ChevronStates", c237);
					ChevronStates = c237;
				})
			});
			c219.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC0
{
	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _IconHostSubject = new ElementNameSubject();

	private ElementNameSubject _RevealBorderSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedDisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

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

	private Viewbox IconHost
	{
		get
		{
			return (Viewbox)_IconHostSubject.ElementInstance;
		}
		set
		{
			_IconHostSubject.ElementInstance = value;
		}
	}

	private Border RevealBorder
	{
		get
		{
			return (Border)_RevealBorderSubject.ElementInstance;
		}
		set
		{
			_RevealBorderSubject.ElementInstance = value;
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

	private VisualState Checked
	{
		get
		{
			return (VisualState)_CheckedSubject.ElementInstance;
		}
		set
		{
			_CheckedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPointerOver
	{
		get
		{
			return (VisualState)_CheckedPointerOverSubject.ElementInstance;
		}
		set
		{
			_CheckedPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPressed
	{
		get
		{
			return (VisualState)_CheckedPressedSubject.ElementInstance;
		}
		set
		{
			_CheckedPressedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedDisabled
	{
		get
		{
			return (VisualState)_CheckedDisabledSubject.ElementInstance;
		}
		set
		{
			_CheckedDisabledSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_408)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			HorizontalAlignment = HorizontalAlignment.Stretch,
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					HorizontalAlignment = HorizontalAlignment.Left,
					Children = { (UIElement)new Viewbox
					{
						IsParsing = true,
						Name = "IconHost",
						Width = 16.0,
						Height = 16.0,
						Child = new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c0)
						{
							nameScope.RegisterName("ContentPresenter", c0);
							ContentPresenter = c0;
							c0.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c0.SetBinding(ContentPresenter.FontSizeProperty, new Binding
							{
								Path = "FontSize",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c0, AccessibilityView.Raw);
							c0.CreationComplete();
						})
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Viewbox c1)
					{
						nameScope.RegisterName("IconHost", c1);
						IconHost = c1;
						c1.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
						{
							Path = "HorizontalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c1.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
						{
							Path = "VerticalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						AutomationProperties.SetAccessibilityView(c1, AccessibilityView.Raw);
						c1.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c2)
				{
					c2.SetBinding(FrameworkElement.WidthProperty, new Binding
					{
						Path = "MinWidth",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "RevealBorder"
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Border c3)
				{
					nameScope.RegisterName("RevealBorder", c3);
					RevealBorder = c3;
					c3.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c3.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c3.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c4)
		{
			nameScope.RegisterName("LayoutRoot", c4);
			LayoutRoot = c4;
			c4.SetBinding(FrameworkElement.HeightProperty, new Binding
			{
				Path = "MinHeight",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c4.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c4.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c4, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c5)
					{
						nameScope.RegisterName("Normal", c5);
						Normal = c5;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c6)
					{
						nameScope.RegisterName("PointerOver", c6);
						PointerOver = c6;
						MarkupHelper.SetVisualStateLazy(c6, delegate
						{
							c6.Name = "PointerOver";
							c6.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ButtonBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ButtonBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c6.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c7)
					{
						nameScope.RegisterName("Pressed", c7);
						Pressed = c7;
						MarkupHelper.SetVisualStateLazy(c7, delegate
						{
							c7.Name = "Pressed";
							c7.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c7.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c8)
					{
						nameScope.RegisterName("Disabled", c8);
						Disabled = c8;
						MarkupHelper.SetVisualStateLazy(c8, delegate
						{
							c8.Name = "Disabled";
							c8.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ButtonBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ButtonBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c8.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Checked"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c9)
					{
						nameScope.RegisterName("Checked", c9);
						Checked = c9;
						MarkupHelper.SetVisualStateLazy(c9, delegate
						{
							c9.Name = "Checked";
							c9.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c9.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "CheckedPointerOver"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c10)
					{
						nameScope.RegisterName("CheckedPointerOver", c10);
						CheckedPointerOver = c10;
						MarkupHelper.SetVisualStateLazy(c10, delegate
						{
							c10.Name = "CheckedPointerOver";
							c10.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c10.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "CheckedPressed"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c11)
					{
						nameScope.RegisterName("CheckedPressed", c11);
						CheckedPressed = c11;
						MarkupHelper.SetVisualStateLazy(c11, delegate
						{
							c11.Name = "CheckedPressed";
							c11.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c11.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "CheckedDisabled"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c12)
					{
						nameScope.RegisterName("CheckedDisabled", c12);
						CheckedDisabled = c12;
						MarkupHelper.SetVisualStateLazy(c12, delegate
						{
							c12.Name = "CheckedDisabled";
							c12.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonBackgroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonBackgroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c12.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ToggleButtonForegroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ToggleButtonForegroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c13)
			{
				nameScope.RegisterName("CommonStates", c13);
				CommonStates = c13;
			}) });
			c4.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC1
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
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

	private FontIcon Icon
	{
		get
		{
			return (FontIcon)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_417)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = { (UIElement)new StackPanel
			{
				IsParsing = true,
				Orientation = Orientation.Horizontal,
				Children = 
				{
					(UIElement)new ContentPresenter
					{
						IsParsing = true,
						Name = "ContentPresenter",
						VerticalAlignment = VerticalAlignment.Center
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c14)
					{
						nameScope.RegisterName("ContentPresenter", c14);
						ContentPresenter = c14;
						c14.SetBinding(ContentPresenter.ContentProperty, new Binding
						{
							Path = "Content",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c14.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
						{
							Path = "ContentTransitions",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c14.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
						{
							Path = "ContentTemplate",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c14.SetBinding(ContentPresenter.ForegroundProperty, new Binding
						{
							Path = "Foreground",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						AutomationProperties.SetAccessibilityView(c14, AccessibilityView.Raw);
						c14.CreationComplete();
					}),
					(UIElement)new FontIcon
					{
						IsParsing = true,
						Name = "Icon",
						Margin = new Thickness(8.0, 0.0, 0.0, -4.0),
						VerticalAlignment = VerticalAlignment.Center,
						FontSize = 8.0,
						Glyph = "\ue96e",
						IsHitTestVisible = false
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(FontIcon c15)
					{
						nameScope.RegisterName("Icon", c15);
						Icon = c15;
						AutomationProperties.SetAccessibilityView(c15, AccessibilityView.Raw);
						ResourceResolverSingleton.Instance.ApplyResource(c15, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
						c15.SetBinding(IconElement.ForegroundProperty, new Binding
						{
							Path = "Foreground",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						_component_0 = c15;
						c15.CreationComplete();
					})
				}
			}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(StackPanel c16)
			{
				c16.SetBinding(StackPanel.PaddingProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c16.CreationComplete();
			}) }
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c17)
		{
			nameScope.RegisterName("RootGrid", c17);
			RootGrid = c17;
			c17.SetBinding(FrameworkElement.HeightProperty, new Binding
			{
				Path = "Height",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c17.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c17, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c18)
					{
						nameScope.RegisterName("Normal", c18);
						Normal = c18;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c19)
					{
						nameScope.RegisterName("PointerOver", c19);
						PointerOver = c19;
						MarkupHelper.SetVisualStateLazy(c19, delegate
						{
							c19.Name = "PointerOver";
							c19.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c19.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c19.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c20)
					{
						nameScope.RegisterName("Pressed", c20);
						Pressed = c20;
						MarkupHelper.SetVisualStateLazy(c20, delegate
						{
							c20.Name = "Pressed";
							c20.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c20.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c20.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c21)
					{
						nameScope.RegisterName("Disabled", c21);
						Disabled = c21;
						MarkupHelper.SetVisualStateLazy(c21, delegate
						{
							c21.Name = "Disabled";
							c21.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c21.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c22)
			{
				nameScope.RegisterName("CommonStates", c22);
				CommonStates = c22;
			}) });
			c17.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private FontIcon Icon
	{
		get
		{
			return (FontIcon)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_421)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Rectangle c23)
				{
					nameScope.RegisterName("PointerRectangle", c23);
					PointerRectangle = c23;
					c23.CreationComplete();
				}),
				(UIElement)new FontIcon
				{
					IsParsing = true,
					Name = "Icon",
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					FontSize = 16.0,
					Glyph = "\ue70d",
					IsHitTestVisible = false
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(FontIcon c24)
				{
					nameScope.RegisterName("Icon", c24);
					Icon = c24;
					AutomationProperties.SetAccessibilityView(c24, AccessibilityView.Raw);
					ResourceResolverSingleton.Instance.ApplyResource(c24, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
					c24.SetBinding(IconElement.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c24;
					c24.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c25)
		{
			nameScope.RegisterName("RootGrid", c25);
			RootGrid = c25;
			c25.SetBinding(FrameworkElement.HeightProperty, new Binding
			{
				Path = "Height",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c25.SetBinding(FrameworkElement.WidthProperty, new Binding
			{
				Path = "Width",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c25.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c25, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c26)
					{
						nameScope.RegisterName("Normal", c26);
						Normal = c26;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c27)
					{
						nameScope.RegisterName("PointerOver", c27);
						PointerOver = c27;
						MarkupHelper.SetVisualStateLazy(c27, delegate
						{
							c27.Name = "PointerOver";
							c27.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c27.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c27.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c28)
					{
						nameScope.RegisterName("Pressed", c28);
						Pressed = c28;
						MarkupHelper.SetVisualStateLazy(c28, delegate
						{
							c28.Name = "Pressed";
							c28.Setters.Add(new Setter(new TargetPropertyPath(_RootGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c28.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c28.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c29)
					{
						nameScope.RegisterName("Disabled", c29);
						Disabled = c29;
						MarkupHelper.SetVisualStateLazy(c29, delegate
						{
							c29.Name = "Disabled";
							c29.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c30)
			{
				nameScope.RegisterName("CommonStates", c30);
				CommonStates = c30;
			}) });
			c25.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC3
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _IconColumnSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _FocusedSubject = new ElementNameSubject();

	private ElementNameSubject _UnfocusedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerFocusedSubject = new ElementNameSubject();

	private ElementNameSubject _FocusStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _IconCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _IconStatesSubject = new ElementNameSubject();

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

	private Viewbox _component_1
	{
		get
		{
			return (Viewbox)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
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

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private VisualState Focused
	{
		get
		{
			return (VisualState)_FocusedSubject.ElementInstance;
		}
		set
		{
			_FocusedSubject.ElementInstance = value;
		}
	}

	private VisualState Unfocused
	{
		get
		{
			return (VisualState)_UnfocusedSubject.ElementInstance;
		}
		set
		{
			_UnfocusedSubject.ElementInstance = value;
		}
	}

	private VisualState PointerFocused
	{
		get
		{
			return (VisualState)_PointerFocusedSubject.ElementInstance;
		}
		set
		{
			_PointerFocusedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup FocusStates
	{
		get
		{
			return (VisualStateGroup)_FocusStatesSubject.ElementInstance;
		}
		set
		{
			_FocusStatesSubject.ElementInstance = value;
		}
	}

	private VisualState IconVisible
	{
		get
		{
			return (VisualState)_IconVisibleSubject.ElementInstance;
		}
		set
		{
			_IconVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState IconCollapsed
	{
		get
		{
			return (VisualState)_IconCollapsedSubject.ElementInstance;
		}
		set
		{
			_IconCollapsedSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_423)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Height = 40.0,
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					Margin = new Thickness(4.0, 0.0, 0.0, 0.0),
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Center,
					Children = { (UIElement)new Rectangle
					{
						IsParsing = true,
						Name = "SelectionIndicator",
						Width = 2.0,
						Height = 24.0,
						Opacity = 0.0
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Rectangle c31)
					{
						nameScope.RegisterName("SelectionIndicator", c31);
						SelectionIndicator = c31;
						ResourceResolverSingleton.Instance.ApplyResource(c31, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
						_component_0 = c31;
						c31.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c32)
				{
					c32.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentGrid",
					Height = 40.0,
					HorizontalAlignment = HorizontalAlignment.Left,
					ColumnDefinitions = 
					{
						new ColumnDefinition
						{
							Width = new GridLength(48.0, GridUnitType.Pixel)
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ColumnDefinition c33)
						{
							nameScope.RegisterName("IconColumn", c33);
							IconColumn = c33;
						}),
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Star)
						}
					},
					Children = 
					{
						(UIElement)new Viewbox
						{
							IsParsing = true,
							Name = "IconBox",
							Child = new ContentPresenter
							{
								IsParsing = true,
								Name = "Icon"
							}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c35)
							{
								nameScope.RegisterName("Icon", c35);
								Icon = c35;
								c35.SetBinding(ContentPresenter.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c35.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Icon",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c35.CreationComplete();
							})
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Viewbox c36)
						{
							nameScope.RegisterName("IconBox", c36);
							IconBox = c36;
							ResourceResolverSingleton.Instance.ApplyResource(c36, FrameworkElement.MarginProperty, "NavigationViewItemIconBoxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
							_component_1 = c36;
							c36.CreationComplete();
						}),
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c37)
						{
							nameScope.RegisterName("ContentPresenter", c37);
							ContentPresenter = c37;
							Grid.SetColumn(c37, 1);
							c37.SetBinding(ContentPresenter.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
							{
								Path = "HorizontalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
							{
								Path = "VerticalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
							{
								Path = "ContentTemplateSelector",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.SetBinding(FrameworkElement.MarginProperty, new Binding
							{
								Path = "Padding",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c37, AccessibilityView.Raw);
							c37.CreationComplete();
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c38)
				{
					nameScope.RegisterName("ContentGrid", c38);
					ContentGrid = c38;
					c38.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c39)
		{
			nameScope.RegisterName("LayoutRoot", c39);
			LayoutRoot = c39;
			c39.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c39, value: true);
			VisualStateManager.SetVisualStateGroups(c39, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c40)
						{
							nameScope.RegisterName("Enabled", c40);
							Enabled = c40;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c41)
						{
							nameScope.RegisterName("Disabled", c41);
							Disabled = c41;
							MarkupHelper.SetVisualStateLazy(c41, delegate
							{
								c41.Name = "Disabled";
								c41.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Opacity"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ListViewItemDisabledThemeOpacity", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ListViewItemDisabledThemeOpacity", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c42)
				{
					nameScope.RegisterName("DisabledStates", c42);
					DisabledStates = c42;
				}),
				new VisualStateGroup
				{
					Name = "FocusStates",
					States = 
					{
						new VisualState
						{
							Name = "Focused"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c43)
						{
							nameScope.RegisterName("Focused", c43);
							Focused = c43;
							MarkupHelper.SetVisualStateLazy(c43, delegate
							{
								c43.Name = "Focused";
								c43.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlHighlightAccentBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlHighlightAccentBrush", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c43.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlHighlightAltChromeWhiteBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlHighlightAltChromeWhiteBrush", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c43.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlHighlightAltChromeWhiteBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlHighlightAltChromeWhiteBrush", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Unfocused"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c44)
						{
							nameScope.RegisterName("Unfocused", c44);
							Unfocused = c44;
						}),
						new VisualState
						{
							Name = "PointerFocused"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c45)
						{
							nameScope.RegisterName("PointerFocused", c45);
							PointerFocused = c45;
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c46)
				{
					nameScope.RegisterName("FocusStates", c46);
					FocusStates = c46;
				}),
				new VisualStateGroup
				{
					Name = "IconStates",
					States = 
					{
						new VisualState
						{
							Name = "IconVisible"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c47)
						{
							nameScope.RegisterName("IconVisible", c47);
							IconVisible = c47;
						}),
						new VisualState
						{
							Name = "IconCollapsed"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c48)
						{
							nameScope.RegisterName("IconCollapsed", c48);
							IconCollapsed = c48;
							MarkupHelper.SetVisualStateLazy(c48, delegate
							{
								c48.Name = "IconCollapsed";
								c48.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c48.Setters.Add(new Setter(new TargetPropertyPath(_IconColumnSubject, (PropertyPath)"Width"), "16"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c49)
				{
					nameScope.RegisterName("IconStates", c49);
					IconStates = c49;
				})
			});
			c39.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC4
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _IconRowSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ContentPresenter _component_0
	{
		get
		{
			return (ContentPresenter)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private RowDefinition IconRow
	{
		get
		{
			return (RowDefinition)_IconRowSubject.ElementInstance;
		}
		set
		{
			_IconRowSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private VisualStateGroup PointerStates
	{
		get
		{
			return (VisualStateGroup)_PointerStatesSubject.ElementInstance;
		}
		set
		{
			_PointerStatesSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_453)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Rectangle c50)
				{
					nameScope.RegisterName("PointerRectangle", c50);
					PointerRectangle = c50;
					c50.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentGrid",
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
					RowDefinitions = 
					{
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(RowDefinition c53)
						{
							nameScope.RegisterName("IconRow", c53);
							IconRow = c53;
						}),
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Star)
						}
					},
					Children = { (UIElement)new Viewbox
					{
						IsParsing = true,
						Name = "IconBox",
						Height = 16.0,
						Width = 48.0,
						Margin = new Thickness(0.0, 0.0, 0.0, 0.0),
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Center,
						Child = new ContentPresenter
						{
							IsParsing = true,
							Name = "Icon"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c55)
						{
							nameScope.RegisterName("Icon", c55);
							Icon = c55;
							c55.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Icon",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							ResourceResolverSingleton.Instance.ApplyResource(c55, ContentPresenter.ForegroundProperty, "TopNavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
							_component_0 = c55;
							c55.CreationComplete();
						})
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Viewbox c56)
					{
						nameScope.RegisterName("IconBox", c56);
						IconBox = c56;
						Grid.SetRow(c56, 1);
						Grid.SetColumn(c56, 1);
						c56.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c57)
				{
					nameScope.RegisterName("ContentGrid", c57);
					ContentGrid = c57;
					c57.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c58)
		{
			nameScope.RegisterName("LayoutRoot", c58);
			LayoutRoot = c58;
			c58.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c58, value: true);
			VisualStateManager.SetVisualStateGroups(c58, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "PointerStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c59)
						{
							nameScope.RegisterName("Normal", c59);
							Normal = c59;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c60)
						{
							nameScope.RegisterName("PointerOver", c60);
							PointerOver = c60;
							MarkupHelper.SetVisualStateLazy(c60, delegate
							{
								c60.Name = "PointerOver";
								c60.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c60.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c60.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c61)
						{
							nameScope.RegisterName("Pressed", c61);
							Pressed = c61;
							MarkupHelper.SetVisualStateLazy(c61, delegate
							{
								c61.Name = "Pressed";
								c61.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c61.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c61.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c62)
						{
							nameScope.RegisterName("Selected", c62);
							Selected = c62;
							MarkupHelper.SetVisualStateLazy(c62, delegate
							{
								c62.Name = "Selected";
								c62.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c62.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c62.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c63)
						{
							nameScope.RegisterName("PointerOverSelected", c63);
							PointerOverSelected = c63;
							MarkupHelper.SetVisualStateLazy(c63, delegate
							{
								c63.Name = "PointerOverSelected";
								c63.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c63.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c63.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c64)
						{
							nameScope.RegisterName("PressedSelected", c64);
							PressedSelected = c64;
							MarkupHelper.SetVisualStateLazy(c64, delegate
							{
								c64.Name = "PressedSelected";
								c64.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c64.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c64.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c65)
				{
					nameScope.RegisterName("PointerStates", c65);
					PointerStates = c65;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c66)
						{
							nameScope.RegisterName("Enabled", c66);
							Enabled = c66;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c67)
						{
							nameScope.RegisterName("Disabled", c67);
							Disabled = c67;
							MarkupHelper.SetVisualStateLazy(c67, delegate
							{
								c67.Name = "Disabled";
								c67.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c68)
				{
					nameScope.RegisterName("DisabledStates", c68);
					DisabledStates = c68;
				})
			});
			c58.CreationComplete();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC5
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnLeftSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ContentOnlySubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewIconPositionStatesSubject = new ElementNameSubject();

	private ContentPresenter _component_0
	{
		get
		{
			return (ContentPresenter)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private ContentPresenter _component_1
	{
		get
		{
			return (ContentPresenter)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Rectangle _component_2
	{
		get
		{
			return (Rectangle)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
		}
	}

	private Grid SelectionIndicatorGrid
	{
		get
		{
			return (Grid)_SelectionIndicatorGridSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorGridSubject.ElementInstance = value;
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

	private VisualStateGroup PointerStates
	{
		get
		{
			return (VisualStateGroup)_PointerStatesSubject.ElementInstance;
		}
		set
		{
			_PointerStatesSubject.ElementInstance = value;
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

	private VisualState IconOnLeft
	{
		get
		{
			return (VisualState)_IconOnLeftSubject.ElementInstance;
		}
		set
		{
			_IconOnLeftSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnly
	{
		get
		{
			return (VisualState)_IconOnlySubject.ElementInstance;
		}
		set
		{
			_IconOnlySubject.ElementInstance = value;
		}
	}

	private VisualState ContentOnly
	{
		get
		{
			return (VisualState)_ContentOnlySubject.ElementInstance;
		}
		set
		{
			_ContentOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationViewIconPositionStates
	{
		get
		{
			return (VisualStateGroup)_NavigationViewIconPositionStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationViewIconPositionStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_504)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent,
					Visibility = Visibility.Collapsed
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Rectangle c69)
				{
					nameScope.RegisterName("PointerRectangle", c69);
					PointerRectangle = c69;
					c69.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentGrid",
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
						(UIElement)new Viewbox
						{
							IsParsing = true,
							Name = "IconBox",
							Height = 16.0,
							Width = 16.0,
							Margin = new Thickness(16.0, 0.0, 0.0, 0.0),
							VerticalAlignment = VerticalAlignment.Center,
							HorizontalAlignment = HorizontalAlignment.Center,
							Child = new ContentPresenter
							{
								IsParsing = true,
								Name = "Icon"
							}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c72)
							{
								nameScope.RegisterName("Icon", c72);
								Icon = c72;
								c72.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Icon",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								ResourceResolverSingleton.Instance.ApplyResource(c72, ContentPresenter.ForegroundProperty, "TopNavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
								_component_0 = c72;
								c72.CreationComplete();
							})
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Viewbox c73)
						{
							nameScope.RegisterName("IconBox", c73);
							IconBox = c73;
							c73.CreationComplete();
						}),
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter",
							Margin = new Thickness(8.0, 0.0, 16.0, 0.0),
							TextWrapping = TextWrapping.NoWrap,
							VerticalAlignment = VerticalAlignment.Center
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c74)
						{
							nameScope.RegisterName("ContentPresenter", c74);
							ContentPresenter = c74;
							Grid.SetColumn(c74, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c74, ContentPresenter.ForegroundProperty, "TopNavigationViewItemForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
							c74.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c74.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c74.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c74.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
							{
								Path = "HorizontalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c74.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
							{
								Path = "ContentTemplateSelector",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c74, AccessibilityView.Raw);
							_component_1 = c74;
							c74.CreationComplete();
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c75)
				{
					nameScope.RegisterName("ContentGrid", c75);
					ContentGrid = c75;
					c75.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "SelectionIndicatorGrid",
					Margin = new Thickness(16.0, 0.0, 16.0, 4.0),
					VerticalAlignment = VerticalAlignment.Bottom,
					Children = { (UIElement)new Rectangle
					{
						IsParsing = true,
						Name = "SelectionIndicator",
						Height = 2.0,
						Opacity = 0.0
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Rectangle c76)
					{
						nameScope.RegisterName("SelectionIndicator", c76);
						SelectionIndicator = c76;
						ResourceResolverSingleton.Instance.ApplyResource(c76, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
						_component_2 = c76;
						c76.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c77)
				{
					nameScope.RegisterName("SelectionIndicatorGrid", c77);
					SelectionIndicatorGrid = c77;
					c77.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c78)
		{
			nameScope.RegisterName("LayoutRoot", c78);
			LayoutRoot = c78;
			c78.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c78, value: true);
			VisualStateManager.SetVisualStateGroups(c78, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "PointerStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c79)
						{
							nameScope.RegisterName("Normal", c79);
							Normal = c79;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c80)
						{
							nameScope.RegisterName("PointerOver", c80);
							PointerOver = c80;
							MarkupHelper.SetVisualStateLazy(c80, delegate
							{
								c80.Name = "PointerOver";
								c80.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c80.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c80.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c80.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c81)
						{
							nameScope.RegisterName("Pressed", c81);
							Pressed = c81;
							MarkupHelper.SetVisualStateLazy(c81, delegate
							{
								c81.Name = "Pressed";
								c81.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c81.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c81.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c81.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c82)
						{
							nameScope.RegisterName("Selected", c82);
							Selected = c82;
							MarkupHelper.SetVisualStateLazy(c82, delegate
							{
								c82.Name = "Selected";
								c82.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c82.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c82.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c82.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c83)
						{
							nameScope.RegisterName("PointerOverSelected", c83);
							PointerOverSelected = c83;
							MarkupHelper.SetVisualStateLazy(c83, delegate
							{
								c83.Name = "PointerOverSelected";
								c83.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c83.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c83.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c83.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c84)
						{
							nameScope.RegisterName("PressedSelected", c84);
							PressedSelected = c84;
							MarkupHelper.SetVisualStateLazy(c84, delegate
							{
								c84.Name = "PressedSelected";
								c84.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c84.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c84.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c84.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c85)
				{
					nameScope.RegisterName("PointerStates", c85);
					PointerStates = c85;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c86)
						{
							nameScope.RegisterName("Enabled", c86);
							Enabled = c86;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c87)
						{
							nameScope.RegisterName("Disabled", c87);
							Disabled = c87;
							MarkupHelper.SetVisualStateLazy(c87, delegate
							{
								c87.Name = "Disabled";
								c87.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c87.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c88)
				{
					nameScope.RegisterName("DisabledStates", c88);
					DisabledStates = c88;
				}),
				new VisualStateGroup
				{
					Name = "NavigationViewIconPositionStates",
					States = 
					{
						new VisualState
						{
							Name = "IconOnLeft"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c89)
						{
							nameScope.RegisterName("IconOnLeft", c89);
							IconOnLeft = c89;
						}),
						new VisualState
						{
							Name = "IconOnly"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c90)
						{
							nameScope.RegisterName("IconOnly", c90);
							IconOnly = c90;
							MarkupHelper.SetVisualStateLazy(c90, delegate
							{
								c90.Name = "IconOnly";
								c90.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Visibility"), "Visible"));
								c90.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Width"), "48"));
								c90.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c90.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "4,0,4,4"));
							});
						}),
						new VisualState
						{
							Name = "ContentOnly"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c91)
						{
							nameScope.RegisterName("ContentOnly", c91);
							ContentOnly = c91;
							MarkupHelper.SetVisualStateLazy(c91, delegate
							{
								c91.Name = "ContentOnly";
								c91.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c91.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), "12,0"));
								c91.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "12,0,12,4"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c92)
				{
					nameScope.RegisterName("NavigationViewIconPositionStates", c92);
					NavigationViewIconPositionStates = c92;
				})
			});
			c78.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC6
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _PointerRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionIndicatorGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _FocusedSubject = new ElementNameSubject();

	private ElementNameSubject _UnfocusedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerFocusedSubject = new ElementNameSubject();

	private ElementNameSubject _FocusStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnLeftSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ContentOnlySubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewIconPositionStatesSubject = new ElementNameSubject();

	private ContentPresenter _component_0
	{
		get
		{
			return (ContentPresenter)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private ContentPresenter _component_1
	{
		get
		{
			return (ContentPresenter)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Rectangle _component_2
	{
		get
		{
			return (Rectangle)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Rectangle PointerRectangle
	{
		get
		{
			return (Rectangle)_PointerRectangleSubject.ElementInstance;
		}
		set
		{
			_PointerRectangleSubject.ElementInstance = value;
		}
	}

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private Rectangle SelectionIndicator
	{
		get
		{
			return (Rectangle)_SelectionIndicatorSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorSubject.ElementInstance = value;
		}
	}

	private Grid SelectionIndicatorGrid
	{
		get
		{
			return (Grid)_SelectionIndicatorGridSubject.ElementInstance;
		}
		set
		{
			_SelectionIndicatorGridSubject.ElementInstance = value;
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

	private VisualState Focused
	{
		get
		{
			return (VisualState)_FocusedSubject.ElementInstance;
		}
		set
		{
			_FocusedSubject.ElementInstance = value;
		}
	}

	private VisualState Unfocused
	{
		get
		{
			return (VisualState)_UnfocusedSubject.ElementInstance;
		}
		set
		{
			_UnfocusedSubject.ElementInstance = value;
		}
	}

	private VisualState PointerFocused
	{
		get
		{
			return (VisualState)_PointerFocusedSubject.ElementInstance;
		}
		set
		{
			_PointerFocusedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup FocusStates
	{
		get
		{
			return (VisualStateGroup)_FocusStatesSubject.ElementInstance;
		}
		set
		{
			_FocusStatesSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnLeft
	{
		get
		{
			return (VisualState)_IconOnLeftSubject.ElementInstance;
		}
		set
		{
			_IconOnLeftSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnly
	{
		get
		{
			return (VisualState)_IconOnlySubject.ElementInstance;
		}
		set
		{
			_IconOnlySubject.ElementInstance = value;
		}
	}

	private VisualState ContentOnly
	{
		get
		{
			return (VisualState)_ContentOnlySubject.ElementInstance;
		}
		set
		{
			_ContentOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationViewIconPositionStates
	{
		get
		{
			return (VisualStateGroup)_NavigationViewIconPositionStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationViewIconPositionStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_570)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "PointerRectangle",
					Fill = SolidColorBrushHelper.Transparent,
					Visibility = Visibility.Collapsed
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Rectangle c93)
				{
					nameScope.RegisterName("PointerRectangle", c93);
					PointerRectangle = c93;
					c93.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentGrid",
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
						(UIElement)new Viewbox
						{
							IsParsing = true,
							Name = "IconBox",
							Height = 16.0,
							Width = 16.0,
							Margin = new Thickness(16.0, 0.0, 0.0, 0.0),
							VerticalAlignment = VerticalAlignment.Center,
							HorizontalAlignment = HorizontalAlignment.Center,
							Child = new ContentPresenter
							{
								IsParsing = true,
								Name = "Icon"
							}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c96)
							{
								nameScope.RegisterName("Icon", c96);
								Icon = c96;
								c96.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Icon",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								ResourceResolverSingleton.Instance.ApplyResource(c96, ContentPresenter.ForegroundProperty, "DefaultTextForegroundThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
								_component_0 = c96;
								c96.CreationComplete();
							})
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Viewbox c97)
						{
							nameScope.RegisterName("IconBox", c97);
							IconBox = c97;
							c97.CreationComplete();
						}),
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter",
							Margin = new Thickness(8.0, 0.0, 16.0, 0.0),
							TextWrapping = TextWrapping.NoWrap,
							VerticalAlignment = VerticalAlignment.Center
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c98)
						{
							nameScope.RegisterName("ContentPresenter", c98);
							ContentPresenter = c98;
							Grid.SetColumn(c98, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c98, ContentPresenter.ForegroundProperty, "DefaultTextForegroundThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
							c98.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c98.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c98.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c98, AccessibilityView.Raw);
							_component_1 = c98;
							c98.CreationComplete();
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c99)
				{
					nameScope.RegisterName("ContentGrid", c99);
					ContentGrid = c99;
					c99.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "SelectionIndicatorGrid",
					Margin = new Thickness(16.0, 0.0, 16.0, 4.0),
					VerticalAlignment = VerticalAlignment.Bottom,
					Children = { (UIElement)new Rectangle
					{
						IsParsing = true,
						Name = "SelectionIndicator",
						Height = 2.0,
						Opacity = 0.0
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Rectangle c100)
					{
						nameScope.RegisterName("SelectionIndicator", c100);
						SelectionIndicator = c100;
						ResourceResolverSingleton.Instance.ApplyResource(c100, Shape.FillProperty, "NavigationViewSelectionIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_);
						_component_2 = c100;
						c100.CreationComplete();
					}) }
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c101)
				{
					nameScope.RegisterName("SelectionIndicatorGrid", c101);
					SelectionIndicatorGrid = c101;
					c101.CreationComplete();
				})
			}
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c102)
		{
			nameScope.RegisterName("LayoutRoot", c102);
			LayoutRoot = c102;
			c102.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c102, value: true);
			VisualStateManager.SetVisualStateGroups(c102, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c103)
						{
							nameScope.RegisterName("Enabled", c103);
							Enabled = c103;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c104)
						{
							nameScope.RegisterName("Disabled", c104);
							Disabled = c104;
							MarkupHelper.SetVisualStateLazy(c104, delegate
							{
								c104.Name = "Disabled";
								c104.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c104.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c105)
				{
					nameScope.RegisterName("DisabledStates", c105);
					DisabledStates = c105;
				}),
				new VisualStateGroup
				{
					Name = "FocusStates",
					States = 
					{
						new VisualState
						{
							Name = "Focused"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c106)
						{
							nameScope.RegisterName("Focused", c106);
							Focused = c106;
							MarkupHelper.SetVisualStateLazy(c106, delegate
							{
								c106.Name = "Focused";
								c106.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemRevealBackgroundFocused", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemRevealBackgroundFocused", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c106.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemRevealIconForegroundFocused", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemRevealIconForegroundFocused", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c106.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemRevealContentForegroundFocused", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemRevealContentForegroundFocused", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Unfocused"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c107)
						{
							nameScope.RegisterName("Unfocused", c107);
							Unfocused = c107;
						}),
						new VisualState
						{
							Name = "PointerFocused"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c108)
						{
							nameScope.RegisterName("PointerFocused", c108);
							PointerFocused = c108;
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c109)
				{
					nameScope.RegisterName("FocusStates", c109);
					FocusStates = c109;
				}),
				new VisualStateGroup
				{
					Name = "NavigationViewIconPositionStates",
					States = 
					{
						new VisualState
						{
							Name = "IconOnLeft"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c110)
						{
							nameScope.RegisterName("IconOnLeft", c110);
							IconOnLeft = c110;
						}),
						new VisualState
						{
							Name = "IconOnly"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c111)
						{
							nameScope.RegisterName("IconOnly", c111);
							IconOnly = c111;
							MarkupHelper.SetVisualStateLazy(c111, delegate
							{
								c111.Name = "IconOnly";
								c111.Setters.Add(new Setter(new TargetPropertyPath(_PointerRectangleSubject, (PropertyPath)"Visibility"), "Visible"));
								c111.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Width"), "48"));
								c111.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c111.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "4,0"));
							});
						}),
						new VisualState
						{
							Name = "ContentOnly"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c112)
						{
							nameScope.RegisterName("ContentOnly", c112);
							ContentOnly = c112;
							MarkupHelper.SetVisualStateLazy(c112, delegate
							{
								c112.Name = "ContentOnly";
								c112.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c112.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), "12,0"));
								c112.Setters.Add(new Setter(new TargetPropertyPath(_SelectionIndicatorGridSubject, (PropertyPath)"Margin"), "12,0"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c113)
				{
					nameScope.RegisterName("NavigationViewIconPositionStates", c113);
					NavigationViewIconPositionStates = c113;
				})
			});
			c102.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
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
internal class _NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_NavigationView_rs1_themeresourcesRDSC7
{
	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _IconBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerStatesSubject = new ElementNameSubject();

	private ElementNameSubject _EnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnLeftSubject = new ElementNameSubject();

	private ElementNameSubject _IconOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ContentOnlySubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewIconPositionStatesSubject = new ElementNameSubject();

	private ContentPresenter Icon
	{
		get
		{
			return (ContentPresenter)_IconSubject.ElementInstance;
		}
		set
		{
			_IconSubject.ElementInstance = value;
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

	private VisualStateGroup PointerStates
	{
		get
		{
			return (VisualStateGroup)_PointerStatesSubject.ElementInstance;
		}
		set
		{
			_PointerStatesSubject.ElementInstance = value;
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

	private VisualState IconOnLeft
	{
		get
		{
			return (VisualState)_IconOnLeftSubject.ElementInstance;
		}
		set
		{
			_IconOnLeftSubject.ElementInstance = value;
		}
	}

	private VisualState IconOnly
	{
		get
		{
			return (VisualState)_IconOnlySubject.ElementInstance;
		}
		set
		{
			_IconOnlySubject.ElementInstance = value;
		}
	}

	private VisualState ContentOnly
	{
		get
		{
			return (VisualState)_ContentOnlySubject.ElementInstance;
		}
		set
		{
			_ContentOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationViewIconPositionStates
	{
		get
		{
			return (VisualStateGroup)_NavigationViewIconPositionStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationViewIconPositionStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_631)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Height = 40.0,
			Children = { (UIElement)new Grid
			{
				IsParsing = true,
				Name = "ContentGrid",
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
					(UIElement)new Viewbox
					{
						IsParsing = true,
						Name = "IconBox",
						Height = 16.0,
						Width = 16.0,
						Margin = new Thickness(16.0, 0.0, 0.0, 0.0),
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Center,
						Child = new ContentPresenter
						{
							IsParsing = true,
							Name = "Icon"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c116)
						{
							nameScope.RegisterName("Icon", c116);
							Icon = c116;
							c116.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Icon",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c116.SetBinding(ContentPresenter.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c116.CreationComplete();
						})
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Viewbox c117)
					{
						nameScope.RegisterName("IconBox", c117);
						IconBox = c117;
						c117.CreationComplete();
					}),
					(UIElement)new ContentPresenter
					{
						IsParsing = true,
						Name = "ContentPresenter",
						Margin = new Thickness(12.0, 0.0, 16.0, 0.0),
						TextWrapping = TextWrapping.NoWrap,
						VerticalAlignment = VerticalAlignment.Center
					}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(ContentPresenter c118)
					{
						nameScope.RegisterName("ContentPresenter", c118);
						ContentPresenter = c118;
						Grid.SetColumn(c118, 1);
						c118.SetBinding(ContentPresenter.ForegroundProperty, new Binding
						{
							Path = "Foreground",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c118.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
						{
							Path = "ContentTransitions",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c118.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
						{
							Path = "ContentTemplate",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c118.SetBinding(ContentPresenter.ContentProperty, new Binding
						{
							Path = "Content",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c118.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
						{
							Path = "HorizontalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c118.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
						{
							Path = "ContentTemplateSelector",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						AutomationProperties.SetAccessibilityView(c118, AccessibilityView.Raw);
						c118.CreationComplete();
					})
				}
			}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c119)
			{
				nameScope.RegisterName("ContentGrid", c119);
				ContentGrid = c119;
				c119.CreationComplete();
			}) }
		}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(Grid c120)
		{
			nameScope.RegisterName("LayoutRoot", c120);
			LayoutRoot = c120;
			c120.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c120, value: true);
			VisualStateManager.SetVisualStateGroups(c120, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "PointerStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c121)
						{
							nameScope.RegisterName("Normal", c121);
							Normal = c121;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c122)
						{
							nameScope.RegisterName("PointerOver", c122);
							PointerOver = c122;
							MarkupHelper.SetVisualStateLazy(c122, delegate
							{
								c122.Name = "PointerOver";
								c122.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c122.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c122.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c123)
						{
							nameScope.RegisterName("Pressed", c123);
							Pressed = c123;
							MarkupHelper.SetVisualStateLazy(c123, delegate
							{
								c123.Name = "Pressed";
								c123.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c123.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c123.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Selected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c124)
						{
							nameScope.RegisterName("Selected", c124);
							Selected = c124;
							MarkupHelper.SetVisualStateLazy(c124, delegate
							{
								c124.Name = "Selected";
								c124.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c124.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c124.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundSelected", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PointerOverSelected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c125)
						{
							nameScope.RegisterName("PointerOverSelected", c125);
							PointerOverSelected = c125;
							MarkupHelper.SetVisualStateLazy(c125, delegate
							{
								c125.Name = "PointerOverSelected";
								c125.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c125.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c125.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PressedSelected"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c126)
						{
							nameScope.RegisterName("PressedSelected", c126);
							PressedSelected = c126;
							MarkupHelper.SetVisualStateLazy(c126, delegate
							{
								c126.Name = "PressedSelected";
								c126.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemBackgroundSelectedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemBackgroundSelectedPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c126.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c126.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c127)
				{
					nameScope.RegisterName("PointerStates", c127);
					PointerStates = c127;
				}),
				new VisualStateGroup
				{
					Name = "DisabledStates",
					States = 
					{
						new VisualState
						{
							Name = "Enabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c128)
						{
							nameScope.RegisterName("Enabled", c128);
							Enabled = c128;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c129)
						{
							nameScope.RegisterName("Disabled", c129);
							Disabled = c129;
							MarkupHelper.SetVisualStateLazy(c129, delegate
							{
								c129.Name = "Disabled";
								c129.Setters.Add(new Setter(new TargetPropertyPath(_IconSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c129.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("TopNavigationViewItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("TopNavigationViewItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__40.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c130)
				{
					nameScope.RegisterName("DisabledStates", c130);
					DisabledStates = c130;
				}),
				new VisualStateGroup
				{
					Name = "NavigationViewIconPositionStates",
					States = 
					{
						new VisualState
						{
							Name = "IconOnLeft"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c131)
						{
							nameScope.RegisterName("IconOnLeft", c131);
							IconOnLeft = c131;
						}),
						new VisualState
						{
							Name = "IconOnly"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c132)
						{
							nameScope.RegisterName("IconOnly", c132);
							IconOnly = c132;
						}),
						new VisualState
						{
							Name = "ContentOnly"
						}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualState c133)
						{
							nameScope.RegisterName("ContentOnly", c133);
							ContentOnly = c133;
							MarkupHelper.SetVisualStateLazy(c133, delegate
							{
								c133.Name = "ContentOnly";
								c133.Setters.Add(new Setter(new TargetPropertyPath(_IconBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c133.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Margin"), "16,0"));
							});
						})
					}
				}.NavigationView_rs1_themeresources_5199eb55a85307bb1f6f83395fc6bd08_XamlApply(delegate(VisualStateGroup c134)
				{
					nameScope.RegisterName("NavigationViewIconPositionStates", c134);
					NavigationViewIconPositionStates = c134;
				})
			});
			c120.CreationComplete();
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

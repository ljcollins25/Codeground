using System;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_MenuFlyout_19h1_themeresourcesRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _MenuFlyoutPresenterScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _MenuFlyoutPresenterBorderSubject = new ElementNameSubject();

	private ItemsPresenter _component_0
	{
		get
		{
			return (ItemsPresenter)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private ScrollViewer MenuFlyoutPresenterScrollViewer
	{
		get
		{
			return (ScrollViewer)_MenuFlyoutPresenterScrollViewerSubject.ElementInstance;
		}
		set
		{
			_MenuFlyoutPresenterScrollViewerSubject.ElementInstance = value;
		}
	}

	private Border MenuFlyoutPresenterBorder
	{
		get
		{
			return (Border)_MenuFlyoutPresenterBorderSubject.ElementInstance;
		}
		set
		{
			_MenuFlyoutPresenterBorderSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_192)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Children = 
			{
				(UIElement)new ScrollViewer
				{
					IsParsing = true,
					Name = "MenuFlyoutPresenterScrollViewer",
					Content = new ItemsPresenter
					{
						IsParsing = true
					}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(ItemsPresenter c0)
					{
						ResourceResolverSingleton.Instance.ApplyResource(c0, FrameworkElement.MarginProperty, "MenuFlyoutScrollerMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
						_component_0 = c0;
						c0.CreationComplete();
					})
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(ScrollViewer c1)
				{
					nameScope.RegisterName("MenuFlyoutPresenterScrollViewer", c1);
					MenuFlyoutPresenterScrollViewer = c1;
					c1.SetBinding(FrameworkElement.MarginProperty, new Binding
					{
						Path = "Padding",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(FrameworkElement.MinWidthProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "TemplateSettings.FlyoutContentMinWidth"
					});
					c1.SetBinding(ScrollViewer.HorizontalScrollModeProperty, new Binding
					{
						Path = "ScrollViewer.HorizontalScrollMode",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(ScrollViewer.HorizontalScrollBarVisibilityProperty, new Binding
					{
						Path = "ScrollViewer.HorizontalScrollBarVisibility",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(ScrollViewer.VerticalScrollModeProperty, new Binding
					{
						Path = "ScrollViewer.VerticalScrollMode",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(ScrollViewer.VerticalScrollBarVisibilityProperty, new Binding
					{
						Path = "ScrollViewer.VerticalScrollBarVisibility",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(ScrollViewer.IsHorizontalRailEnabledProperty, new Binding
					{
						Path = "ScrollViewer.IsHorizontalRailEnabled",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(ScrollViewer.IsVerticalRailEnabledProperty, new Binding
					{
						Path = "ScrollViewer.IsVerticalRailEnabled",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ScrollViewer.SetZoomMode(c1, ZoomMode.Disabled);
					AutomationProperties.SetAccessibilityView(c1, AccessibilityView.Raw);
					c1.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "MenuFlyoutPresenterBorder"
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Border c2)
				{
					nameScope.RegisterName("MenuFlyoutPresenterBorder", c2);
					MenuFlyoutPresenterBorder = c2;
					c2.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.SetBinding(Border.CornerRadiusProperty, new Binding
					{
						Path = "CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.CreationComplete();
				})
			}
		}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Grid c3)
		{
			c3.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.CreationComplete();
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
internal class _MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_MenuFlyout_19h1_themeresourcesRDSC1
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _LanguageSwitcherSettingsLanguageSettingsButtonSubject = new ElementNameSubject();

	private ElementNameSubject _LanguageSwitcherSettingsPenAndInkSettingsButtonSubject = new ElementNameSubject();

	private ElementNameSubject _LanguageSwitcherSettingsHelpButtonSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _DefaultPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _NarrowPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _PaddingSizeStatesSubject = new ElementNameSubject();

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

	private Button _component_1
	{
		get
		{
			return (Button)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private FontIcon _component_2
	{
		get
		{
			return (FontIcon)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Button _component_3
	{
		get
		{
			return (Button)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private FontIcon _component_4
	{
		get
		{
			return (FontIcon)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private Button _component_5
	{
		get
		{
			return (Button)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_6
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private Button LanguageSwitcherSettingsLanguageSettingsButton
	{
		get
		{
			return (Button)_LanguageSwitcherSettingsLanguageSettingsButtonSubject.ElementInstance;
		}
		set
		{
			_LanguageSwitcherSettingsLanguageSettingsButtonSubject.ElementInstance = value;
		}
	}

	private Button LanguageSwitcherSettingsPenAndInkSettingsButton
	{
		get
		{
			return (Button)_LanguageSwitcherSettingsPenAndInkSettingsButtonSubject.ElementInstance;
		}
		set
		{
			_LanguageSwitcherSettingsPenAndInkSettingsButtonSubject.ElementInstance = value;
		}
	}

	private Button LanguageSwitcherSettingsHelpButton
	{
		get
		{
			return (Button)_LanguageSwitcherSettingsHelpButtonSubject.ElementInstance;
		}
		set
		{
			_LanguageSwitcherSettingsHelpButtonSubject.ElementInstance = value;
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

	private VisualState DefaultPadding
	{
		get
		{
			return (VisualState)_DefaultPaddingSubject.ElementInstance;
		}
		set
		{
			_DefaultPaddingSubject.ElementInstance = value;
		}
	}

	private VisualState NarrowPadding
	{
		get
		{
			return (VisualState)_NarrowPaddingSubject.ElementInstance;
		}
		set
		{
			_NarrowPaddingSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaddingSizeStates
	{
		get
		{
			return (VisualStateGroup)_PaddingSizeStatesSubject.ElementInstance;
		}
		set
		{
			_PaddingSizeStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_193)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			ColumnDefinitions = 
			{
				new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Star)
				},
				new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Star)
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
				}
			},
			Children = 
			{
				(UIElement)new Button
				{
					IsParsing = true,
					Name = "LanguageSwitcherSettingsLanguageSettingsButton",
					HorizontalAlignment = HorizontalAlignment.Left,
					Margin = new Thickness(0.0),
					Content = new FontIcon
					{
						IsParsing = true,
						Glyph = "\ue8c1"
					}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(FontIcon c8)
					{
						ResourceResolverSingleton.Instance.ApplyResource(c8, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
						_component_0 = c8;
						c8.CreationComplete();
					})
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Button c9)
				{
					nameScope.RegisterName("LanguageSwitcherSettingsLanguageSettingsButton", c9);
					LanguageSwitcherSettingsLanguageSettingsButton = c9;
					ResourceResolverSingleton.Instance.ApplyResource(c9, FrameworkElement.BackgroundProperty, "MenuFlyoutItemBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
					Grid.SetColumn(c9, 0);
					_component_1 = c9;
					c9.CreationComplete();
				}),
				(UIElement)new Button
				{
					IsParsing = true,
					Name = "LanguageSwitcherSettingsPenAndInkSettingsButton",
					HorizontalAlignment = HorizontalAlignment.Center,
					Margin = new Thickness(0.0),
					Content = new FontIcon
					{
						IsParsing = true,
						Glyph = "\ue713"
					}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(FontIcon c10)
					{
						ResourceResolverSingleton.Instance.ApplyResource(c10, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
						_component_2 = c10;
						c10.CreationComplete();
					})
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Button c11)
				{
					nameScope.RegisterName("LanguageSwitcherSettingsPenAndInkSettingsButton", c11);
					LanguageSwitcherSettingsPenAndInkSettingsButton = c11;
					ResourceResolverSingleton.Instance.ApplyResource(c11, FrameworkElement.BackgroundProperty, "MenuFlyoutItemBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
					Grid.SetColumn(c11, 1);
					_component_3 = c11;
					c11.CreationComplete();
				}),
				(UIElement)new Button
				{
					IsParsing = true,
					Name = "LanguageSwitcherSettingsHelpButton",
					HorizontalAlignment = HorizontalAlignment.Right,
					Margin = new Thickness(0.0),
					Content = new FontIcon
					{
						IsParsing = true,
						Glyph = "\ue9ce"
					}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(FontIcon c12)
					{
						ResourceResolverSingleton.Instance.ApplyResource(c12, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
						_component_4 = c12;
						c12.CreationComplete();
					})
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Button c13)
				{
					nameScope.RegisterName("LanguageSwitcherSettingsHelpButton", c13);
					LanguageSwitcherSettingsHelpButton = c13;
					ResourceResolverSingleton.Instance.ApplyResource(c13, FrameworkElement.BackgroundProperty, "MenuFlyoutItemBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
					Grid.SetColumn(c13, 2);
					_component_5 = c13;
					c13.CreationComplete();
				})
			}
		}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Grid c14)
		{
			nameScope.RegisterName("LayoutRoot", c14);
			LayoutRoot = c14;
			c14.SetBinding(Grid.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c14.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c14.SetBinding(Grid.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c14.SetBinding(Grid.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c14.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c14, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "PaddingSizeStates",
				States = 
				{
					new VisualState
					{
						Name = "DefaultPadding"
					}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c15)
					{
						nameScope.RegisterName("DefaultPadding", c15);
						DefaultPadding = c15;
					}),
					new VisualState
					{
						Name = "NarrowPadding"
					}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c16)
					{
						nameScope.RegisterName("NarrowPadding", c16);
						NarrowPadding = c16;
						MarkupHelper.SetVisualStateLazy(c16, delegate
						{
							c16.Name = "NarrowPadding";
							c16.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(DiscreteObjectKeyFrame c17)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c17, ObjectKeyFrame.ValueProperty, "MenuFlyoutItemThemePaddingNarrow", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
										_component_6 = c17;
										NameScope.SetNameScope(_component_6, nameScope);
									}) }
								}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c18)
								{
									Storyboard.SetTargetName(c18, "LayoutRoot");
									Storyboard.SetTarget(c18, _LayoutRootSubject);
									Storyboard.SetTargetProperty(c18, "Padding");
								}) }
							};
						});
					})
				}
			}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualStateGroup c19)
			{
				nameScope.RegisterName("PaddingSizeStates", c19);
				PaddingSizeStates = c19;
			}) });
			c14.CreationComplete();
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
internal class _MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_MenuFlyout_19h1_themeresourcesRDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _IconContentSubject = new ElementNameSubject();

	private ElementNameSubject _IconRootSubject = new ElementNameSubject();

	private ElementNameSubject _TextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NoPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _CheckPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _IconPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _CheckAndIconPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _CheckPlaceholderStatesSubject = new ElementNameSubject();

	private ElementNameSubject _DefaultPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _NarrowPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _PaddingSizeStatesSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextVisibilitySubject = new ElementNameSubject();

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

	private ContentPresenter IconContent
	{
		get
		{
			return (ContentPresenter)_IconContentSubject.ElementInstance;
		}
		set
		{
			_IconContentSubject.ElementInstance = value;
		}
	}

	private Viewbox IconRoot
	{
		get
		{
			return (Viewbox)_IconRootSubject.ElementInstance;
		}
		set
		{
			_IconRootSubject.ElementInstance = value;
		}
	}

	private TextBlock TextBlock
	{
		get
		{
			return (TextBlock)_TextBlockSubject.ElementInstance;
		}
		set
		{
			_TextBlockSubject.ElementInstance = value;
		}
	}

	private TextBlock KeyboardAcceleratorTextBlock
	{
		get
		{
			return (TextBlock)_KeyboardAcceleratorTextBlockSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextBlockSubject.ElementInstance = value;
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

	private VisualState NoPlaceholder
	{
		get
		{
			return (VisualState)_NoPlaceholderSubject.ElementInstance;
		}
		set
		{
			_NoPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualState CheckPlaceholder
	{
		get
		{
			return (VisualState)_CheckPlaceholderSubject.ElementInstance;
		}
		set
		{
			_CheckPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualState IconPlaceholder
	{
		get
		{
			return (VisualState)_IconPlaceholderSubject.ElementInstance;
		}
		set
		{
			_IconPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualState CheckAndIconPlaceholder
	{
		get
		{
			return (VisualState)_CheckAndIconPlaceholderSubject.ElementInstance;
		}
		set
		{
			_CheckAndIconPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup CheckPlaceholderStates
	{
		get
		{
			return (VisualStateGroup)_CheckPlaceholderStatesSubject.ElementInstance;
		}
		set
		{
			_CheckPlaceholderStatesSubject.ElementInstance = value;
		}
	}

	private VisualState DefaultPadding
	{
		get
		{
			return (VisualState)_DefaultPaddingSubject.ElementInstance;
		}
		set
		{
			_DefaultPaddingSubject.ElementInstance = value;
		}
	}

	private VisualState NarrowPadding
	{
		get
		{
			return (VisualState)_NarrowPaddingSubject.ElementInstance;
		}
		set
		{
			_NarrowPaddingSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaddingSizeStates
	{
		get
		{
			return (VisualStateGroup)_PaddingSizeStatesSubject.ElementInstance;
		}
		set
		{
			_PaddingSizeStatesSubject.ElementInstance = value;
		}
	}

	private VisualState KeyboardAcceleratorTextCollapsed
	{
		get
		{
			return (VisualState)_KeyboardAcceleratorTextCollapsedSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState KeyboardAcceleratorTextVisible
	{
		get
		{
			return (VisualState)_KeyboardAcceleratorTextVisibleSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextVisibleSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup KeyboardAcceleratorTextVisibility
	{
		get
		{
			return (VisualStateGroup)_KeyboardAcceleratorTextVisibilitySubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextVisibilitySubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_194)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			ColumnDefinitions = 
			{
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
					Name = "IconRoot",
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Center,
					Width = 32.0,
					Height = 32.0,
					Visibility = Visibility.Collapsed,
					Child = new ContentPresenter
					{
						IsParsing = true,
						Name = "IconContent"
					}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(ContentPresenter c22)
					{
						nameScope.RegisterName("IconContent", c22);
						IconContent = c22;
						c22.SetBinding(ContentPresenter.ContentProperty, new Binding
						{
							Path = "Icon",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c22.CreationComplete();
					})
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Viewbox c23)
				{
					nameScope.RegisterName("IconRoot", c23);
					IconRoot = c23;
					c23.CreationComplete();
				}),
				(UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "TextBlock",
					TextTrimming = TextTrimming.Clip
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(TextBlock c24)
				{
					nameScope.RegisterName("TextBlock", c24);
					TextBlock = c24;
					c24.SetBinding(TextBlock.TextProperty, new Binding
					{
						Path = "Text",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c24.SetBinding(TextBlock.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c24.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
					{
						Path = "HorizontalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c24.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
					{
						Path = "VerticalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c24.CreationComplete();
				}),
				(UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "KeyboardAcceleratorTextBlock",
					Margin = new Thickness(24.0, 0.0, 0.0, 0.0),
					HorizontalAlignment = HorizontalAlignment.Right,
					Visibility = Visibility.Collapsed
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(TextBlock c25)
				{
					nameScope.RegisterName("KeyboardAcceleratorTextBlock", c25);
					KeyboardAcceleratorTextBlock = c25;
					Grid.SetColumn(c25, 1);
					ResourceResolverSingleton.Instance.ApplyResource(c25, FrameworkElement.StyleProperty, "CaptionTextBlockStyle", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
					c25.SetBinding(TextBlock.TextProperty, new Binding
					{
						Path = "KeyboardAcceleratorTextOverride",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c25.SetBinding(FrameworkElement.MinWidthProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "TemplateSettings.KeyboardAcceleratorTextMinWidth"
					});
					ResourceResolverSingleton.Instance.ApplyResource(c25, TextBlock.ForegroundProperty, "MenuFlyoutItemKeyboardAcceleratorTextForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
					c25.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
					{
						Path = "VerticalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					AutomationProperties.SetAccessibilityView(c25, AccessibilityView.Raw);
					_component_0 = c25;
					c25.CreationComplete();
				})
			}
		}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(Grid c26)
		{
			nameScope.RegisterName("LayoutRoot", c26);
			LayoutRoot = c26;
			c26.SetBinding(Grid.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c26.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c26.SetBinding(Grid.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c26.SetBinding(Grid.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c26.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c26, new VisualStateGroup[4]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c27)
						{
							nameScope.RegisterName("Normal", c27);
							Normal = c27;
							MarkupHelper.SetVisualStateLazy(c27, delegate
							{
								c27.Name = "Normal";
								c27.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(PointerUpThemeAnimation c28)
									{
										Storyboard.SetTargetName(c28, "LayoutRoot");
										Storyboard.SetTarget(c28, _LayoutRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c29)
						{
							nameScope.RegisterName("PointerOver", c29);
							PointerOver = c29;
							MarkupHelper.SetVisualStateLazy(c29, delegate
							{
								c29.Name = "PointerOver";
								c29.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Windows.UI.Xaml.Media:RevealBrush.State)"), "PointerOver"));
								c29.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemRevealBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemRevealBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c29.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemRevealBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemRevealBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c29.Setters.Add(new Setter(new TargetPropertyPath(_IconContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c29.Setters.Add(new Setter(new TargetPropertyPath(_TextBlockSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c29.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextBlockSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemKeyboardAcceleratorTextForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemKeyboardAcceleratorTextForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c29.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(PointerUpThemeAnimation c30)
									{
										Storyboard.SetTargetName(c30, "LayoutRoot");
										Storyboard.SetTarget(c30, _LayoutRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c31)
						{
							nameScope.RegisterName("Pressed", c31);
							Pressed = c31;
							MarkupHelper.SetVisualStateLazy(c31, delegate
							{
								c31.Name = "Pressed";
								c31.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"(Windows.UI.Xaml.Media:RevealBrush.State)"), "Pressed"));
								c31.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemRevealBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemRevealBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c31.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemRevealBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemRevealBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c31.Setters.Add(new Setter(new TargetPropertyPath(_IconContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c31.Setters.Add(new Setter(new TargetPropertyPath(_TextBlockSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c31.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextBlockSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemKeyboardAcceleratorTextForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemKeyboardAcceleratorTextForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c31.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerDownThemeAnimation().MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(PointerDownThemeAnimation c32)
									{
										Storyboard.SetTargetName(c32, "LayoutRoot");
										Storyboard.SetTarget(c32, _LayoutRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "Disabled"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c33)
						{
							nameScope.RegisterName("Disabled", c33);
							Disabled = c33;
							MarkupHelper.SetVisualStateLazy(c33, delegate
							{
								c33.Name = "Disabled";
								c33.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemRevealBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemRevealBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c33.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemRevealBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemRevealBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c33.Setters.Add(new Setter(new TargetPropertyPath(_IconContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c33.Setters.Add(new Setter(new TargetPropertyPath(_TextBlockSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c33.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextBlockSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemKeyboardAcceleratorTextForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemKeyboardAcceleratorTextForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualStateGroup c34)
				{
					nameScope.RegisterName("CommonStates", c34);
					CommonStates = c34;
				}),
				new VisualStateGroup
				{
					Name = "CheckPlaceholderStates",
					States = 
					{
						new VisualState
						{
							Name = "NoPlaceholder"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c35)
						{
							nameScope.RegisterName("NoPlaceholder", c35);
							NoPlaceholder = c35;
						}),
						new VisualState
						{
							Name = "CheckPlaceholder"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c36)
						{
							nameScope.RegisterName("CheckPlaceholder", c36);
							CheckPlaceholder = c36;
							MarkupHelper.SetVisualStateLazy(c36, delegate
							{
								c36.Name = "CheckPlaceholder";
								c36.Setters.Add(new Setter(new TargetPropertyPath(_TextBlockSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemPlaceholderThemeThickness", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemPlaceholderThemeThickness", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "IconPlaceholder"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c37)
						{
							nameScope.RegisterName("IconPlaceholder", c37);
							IconPlaceholder = c37;
							MarkupHelper.SetVisualStateLazy(c37, delegate
							{
								c37.Name = "IconPlaceholder";
								c37.Setters.Add(new Setter(new TargetPropertyPath(_TextBlockSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("LanguageSwitcherMenuFlyoutItemPlaceholderThemeThickness", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("LanguageSwitcherMenuFlyoutItemPlaceholderThemeThickness", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c37.Setters.Add(new Setter(new TargetPropertyPath(_IconRootSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						}),
						new VisualState
						{
							Name = "CheckAndIconPlaceholder"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c38)
						{
							nameScope.RegisterName("CheckAndIconPlaceholder", c38);
							CheckAndIconPlaceholder = c38;
							MarkupHelper.SetVisualStateLazy(c38, delegate
							{
								c38.Name = "CheckAndIconPlaceholder";
								c38.Setters.Add(new Setter(new TargetPropertyPath(_TextBlockSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemDoublePlaceholderThemeThickness", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemDoublePlaceholderThemeThickness", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c38.Setters.Add(new Setter(new TargetPropertyPath(_IconRootSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuFlyoutItemPlaceholderThemeThickness", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuFlyoutItemPlaceholderThemeThickness", GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c38.Setters.Add(new Setter(new TargetPropertyPath(_IconRootSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualStateGroup c39)
				{
					nameScope.RegisterName("CheckPlaceholderStates", c39);
					CheckPlaceholderStates = c39;
				}),
				new VisualStateGroup
				{
					Name = "PaddingSizeStates",
					States = 
					{
						new VisualState
						{
							Name = "DefaultPadding"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c40)
						{
							nameScope.RegisterName("DefaultPadding", c40);
							DefaultPadding = c40;
						}),
						new VisualState
						{
							Name = "NarrowPadding"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c41)
						{
							nameScope.RegisterName("NarrowPadding", c41);
							NarrowPadding = c41;
							MarkupHelper.SetVisualStateLazy(c41, delegate
							{
								c41.Name = "NarrowPadding";
								c41.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(DiscreteObjectKeyFrame c42)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c42, ObjectKeyFrame.ValueProperty, "MenuFlyoutItemThemePaddingNarrow", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__28.Instance.__ParseContext_);
											_component_1 = c42;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c43)
									{
										Storyboard.SetTargetName(c43, "LayoutRoot");
										Storyboard.SetTarget(c43, _LayoutRootSubject);
										Storyboard.SetTargetProperty(c43, "Padding");
									}) }
								};
							});
						})
					}
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualStateGroup c44)
				{
					nameScope.RegisterName("PaddingSizeStates", c44);
					PaddingSizeStates = c44;
				}),
				new VisualStateGroup
				{
					Name = "KeyboardAcceleratorTextVisibility",
					States = 
					{
						new VisualState
						{
							Name = "KeyboardAcceleratorTextCollapsed"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c45)
						{
							nameScope.RegisterName("KeyboardAcceleratorTextCollapsed", c45);
							KeyboardAcceleratorTextCollapsed = c45;
						}),
						new VisualState
						{
							Name = "KeyboardAcceleratorTextVisible"
						}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualState c46)
						{
							nameScope.RegisterName("KeyboardAcceleratorTextVisible", c46);
							KeyboardAcceleratorTextVisible = c46;
							MarkupHelper.SetVisualStateLazy(c46, delegate
							{
								c46.Name = "KeyboardAcceleratorTextVisible";
								c46.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextBlockSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.MenuFlyout_19h1_themeresources_3dbd1f392cec41b4f3287c3f1a55309d_XamlApply(delegate(VisualStateGroup c47)
				{
					nameScope.RegisterName("KeyboardAcceleratorTextVisibility", c47);
					KeyboardAcceleratorTextVisibility = c47;
				})
			});
			c26.CreationComplete();
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

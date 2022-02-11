using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _SplitButton_d5225a226024e774d58a1fd16c5d0a45_SplitButtonRDSC0
{
	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

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

	public UIElement Build(object __ResourceOwner_356)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Background = SolidColorBrushHelper.Transparent,
			Children = { (UIElement)new ContentPresenter
			{
				IsParsing = true,
				Name = "ContentPresenter"
			}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(ContentPresenter c0)
			{
				nameScope.RegisterName("ContentPresenter", c0);
				ContentPresenter = c0;
				c0.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
				{
					Path = "BorderBrush",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.ContentProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
				{
					Path = "ContentTransitions",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
				{
					Path = "ContentTemplate",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.PaddingProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c0, AccessibilityView.Raw);
				c0.CreationComplete();
			}) }
		}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(Grid c1)
		{
			nameScope.RegisterName("RootGrid", c1);
			RootGrid = c1;
			VisualStateManager.SetVisualStateGroups(c1, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c2)
					{
						nameScope.RegisterName("Normal", c2);
						Normal = c2;
					}),
					new VisualState
					{
						Name = "Disabled"
					}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c3)
					{
						nameScope.RegisterName("Disabled", c3);
						Disabled = c3;
						MarkupHelper.SetVisualStateLazy(c3, delegate
						{
							c3.Name = "Disabled";
							c3.Setters.Add(new Setter(new TargetPropertyPath(_ContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualStateGroup c4)
			{
				nameScope.RegisterName("CommonStates", c4);
				CommonStates = c4;
			}) });
			c1.CreationComplete();
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
internal class _SplitButton_d5225a226024e774d58a1fd16c5d0a45_SplitButtonRDSC1
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _PrimaryButtonColumnSubject = new ElementNameSubject();

	private ElementNameSubject _SeparatorSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryButtonColumnSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryBackgroundGridSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryBackgroundGridSubject = new ElementNameSubject();

	private ElementNameSubject _BorderSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryButtonSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryButtonSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _FlyoutOpenSubject = new ElementNameSubject();

	private ElementNameSubject _TouchPressedSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryPressedSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedFlyoutOpenSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedTouchPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPrimaryPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPrimaryPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedSecondaryPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedSecondaryPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryButtonRightSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryButtonSpanSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryButtonPlacementStatesSubject = new ElementNameSubject();

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

	private Button _component_4
	{
		get
		{
			return (Button)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private ColumnDefinition PrimaryButtonColumn
	{
		get
		{
			return (ColumnDefinition)_PrimaryButtonColumnSubject.ElementInstance;
		}
		set
		{
			_PrimaryButtonColumnSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition Separator
	{
		get
		{
			return (ColumnDefinition)_SeparatorSubject.ElementInstance;
		}
		set
		{
			_SeparatorSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition SecondaryButtonColumn
	{
		get
		{
			return (ColumnDefinition)_SecondaryButtonColumnSubject.ElementInstance;
		}
		set
		{
			_SecondaryButtonColumnSubject.ElementInstance = value;
		}
	}

	private Grid PrimaryBackgroundGrid
	{
		get
		{
			return (Grid)_PrimaryBackgroundGridSubject.ElementInstance;
		}
		set
		{
			_PrimaryBackgroundGridSubject.ElementInstance = value;
		}
	}

	private Grid SecondaryBackgroundGrid
	{
		get
		{
			return (Grid)_SecondaryBackgroundGridSubject.ElementInstance;
		}
		set
		{
			_SecondaryBackgroundGridSubject.ElementInstance = value;
		}
	}

	private Grid Border
	{
		get
		{
			return (Grid)_BorderSubject.ElementInstance;
		}
		set
		{
			_BorderSubject.ElementInstance = value;
		}
	}

	private Button PrimaryButton
	{
		get
		{
			return (Button)_PrimaryButtonSubject.ElementInstance;
		}
		set
		{
			_PrimaryButtonSubject.ElementInstance = value;
		}
	}

	private Button SecondaryButton
	{
		get
		{
			return (Button)_SecondaryButtonSubject.ElementInstance;
		}
		set
		{
			_SecondaryButtonSubject.ElementInstance = value;
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

	private VisualState FlyoutOpen
	{
		get
		{
			return (VisualState)_FlyoutOpenSubject.ElementInstance;
		}
		set
		{
			_FlyoutOpenSubject.ElementInstance = value;
		}
	}

	private VisualState TouchPressed
	{
		get
		{
			return (VisualState)_TouchPressedSubject.ElementInstance;
		}
		set
		{
			_TouchPressedSubject.ElementInstance = value;
		}
	}

	private VisualState PrimaryPointerOver
	{
		get
		{
			return (VisualState)_PrimaryPointerOverSubject.ElementInstance;
		}
		set
		{
			_PrimaryPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState PrimaryPressed
	{
		get
		{
			return (VisualState)_PrimaryPressedSubject.ElementInstance;
		}
		set
		{
			_PrimaryPressedSubject.ElementInstance = value;
		}
	}

	private VisualState SecondaryPointerOver
	{
		get
		{
			return (VisualState)_SecondaryPointerOverSubject.ElementInstance;
		}
		set
		{
			_SecondaryPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState SecondaryPressed
	{
		get
		{
			return (VisualState)_SecondaryPressedSubject.ElementInstance;
		}
		set
		{
			_SecondaryPressedSubject.ElementInstance = value;
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

	private VisualState CheckedFlyoutOpen
	{
		get
		{
			return (VisualState)_CheckedFlyoutOpenSubject.ElementInstance;
		}
		set
		{
			_CheckedFlyoutOpenSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedTouchPressed
	{
		get
		{
			return (VisualState)_CheckedTouchPressedSubject.ElementInstance;
		}
		set
		{
			_CheckedTouchPressedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPrimaryPointerOver
	{
		get
		{
			return (VisualState)_CheckedPrimaryPointerOverSubject.ElementInstance;
		}
		set
		{
			_CheckedPrimaryPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPrimaryPressed
	{
		get
		{
			return (VisualState)_CheckedPrimaryPressedSubject.ElementInstance;
		}
		set
		{
			_CheckedPrimaryPressedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedSecondaryPointerOver
	{
		get
		{
			return (VisualState)_CheckedSecondaryPointerOverSubject.ElementInstance;
		}
		set
		{
			_CheckedSecondaryPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedSecondaryPressed
	{
		get
		{
			return (VisualState)_CheckedSecondaryPressedSubject.ElementInstance;
		}
		set
		{
			_CheckedSecondaryPressedSubject.ElementInstance = value;
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

	private VisualState SecondaryButtonRight
	{
		get
		{
			return (VisualState)_SecondaryButtonRightSubject.ElementInstance;
		}
		set
		{
			_SecondaryButtonRightSubject.ElementInstance = value;
		}
	}

	private VisualState SecondaryButtonSpan
	{
		get
		{
			return (VisualState)_SecondaryButtonSpanSubject.ElementInstance;
		}
		set
		{
			_SecondaryButtonSpanSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup SecondaryButtonPlacementStates
	{
		get
		{
			return (VisualStateGroup)_SecondaryButtonPlacementStatesSubject.ElementInstance;
		}
		set
		{
			_SecondaryButtonPlacementStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_357)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Background = SolidColorBrushHelper.Transparent,
			ColumnDefinitions = 
			{
				new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Star)
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(ColumnDefinition c5)
				{
					nameScope.RegisterName("PrimaryButtonColumn", c5);
					PrimaryButtonColumn = c5;
					ResourceResolverSingleton.Instance.ApplyResource(c5, ColumnDefinition.MinWidthProperty, "SplitButtonPrimaryButtonSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_);
					_component_0 = c5;
					NameScope.SetNameScope(_component_0, nameScope);
				}),
				new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Pixel)
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(ColumnDefinition c6)
				{
					nameScope.RegisterName("Separator", c6);
					Separator = c6;
				}),
				new ColumnDefinition().SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(ColumnDefinition c7)
				{
					nameScope.RegisterName("SecondaryButtonColumn", c7);
					SecondaryButtonColumn = c7;
					ResourceResolverSingleton.Instance.ApplyResource(c7, ColumnDefinition.WidthProperty, "SplitButtonSecondaryButtonSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_);
					_component_1 = c7;
					NameScope.SetNameScope(_component_1, nameScope);
				})
			},
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "PrimaryBackgroundGrid"
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(Grid c8)
				{
					nameScope.RegisterName("PrimaryBackgroundGrid", c8);
					PrimaryBackgroundGrid = c8;
					c8.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c8.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "SecondaryBackgroundGrid"
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(Grid c9)
				{
					nameScope.RegisterName("SecondaryBackgroundGrid", c9);
					SecondaryBackgroundGrid = c9;
					c9.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					Grid.SetColumn(c9, 2);
					c9.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "Border"
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(Grid c10)
				{
					nameScope.RegisterName("Border", c10);
					Border = c10;
					Grid.SetColumnSpan(c10, 3);
					c10.SetBinding(Grid.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c10.SetBinding(Grid.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c10.SetBinding(Grid.CornerRadiusProperty, new Binding
					{
						Path = "CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c10.CreationComplete();
				}),
				(UIElement)new Button
				{
					IsParsing = true,
					Name = "PrimaryButton",
					BorderBrush = SolidColorBrushHelper.Transparent,
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Stretch,
					IsTabStop = false
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(Button c11)
				{
					nameScope.RegisterName("PrimaryButton", c11);
					PrimaryButton = c11;
					ResourceResolverSingleton.Instance.ApplyResource(c11, FrameworkElement.StyleProperty, "SplitButtonInnerButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_);
					Grid.SetColumn(c11, 0);
					c11.SetBinding(Control.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(Control.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(ContentControl.ContentProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(ContentControl.ContentTransitionsProperty, new Binding
					{
						Path = "ContentTransitions",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(ContentControl.ContentTemplateProperty, new Binding
					{
						Path = "ContentTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(ButtonBase.CommandProperty, new Binding
					{
						Path = "Command",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(ButtonBase.CommandParameterProperty, new Binding
					{
						Path = "CommandParameter",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(Control.FontFamilyProperty, new Binding
					{
						Path = "FontFamily",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(Control.FontSizeProperty, new Binding
					{
						Path = "FontSize",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(Control.FontWeightProperty, new Binding
					{
						Path = "FontWeight",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(Control.HorizontalContentAlignmentProperty, new Binding
					{
						Path = "HorizontalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(Control.VerticalContentAlignmentProperty, new Binding
					{
						Path = "VerticalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c11.SetBinding(Control.PaddingProperty, new Binding
					{
						Path = "Padding",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					AutomationProperties.SetAccessibilityView(c11, AccessibilityView.Raw);
					_component_2 = c11;
					c11.CreationComplete();
				}),
				(UIElement)new Button
				{
					IsParsing = true,
					Name = "SecondaryButton",
					BorderBrush = SolidColorBrushHelper.Transparent,
					HorizontalContentAlignment = HorizontalAlignment.Stretch,
					VerticalContentAlignment = VerticalAlignment.Stretch,
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Stretch,
					Padding = new Thickness(0.0, 0.0, 9.0, 0.0),
					IsTabStop = false,
					Content = new TextBlock
					{
						IsParsing = true,
						FontSize = 12.0,
						Text = "\ue0e5",
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Right,
						IsTextScaleFactorEnabled = false
					}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(TextBlock c12)
					{
						ResourceResolverSingleton.Instance.ApplyResource(c12, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_);
						AutomationProperties.SetAccessibilityView(c12, AccessibilityView.Raw);
						_component_3 = c12;
						c12.CreationComplete();
					})
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(Button c13)
				{
					nameScope.RegisterName("SecondaryButton", c13);
					SecondaryButton = c13;
					ResourceResolverSingleton.Instance.ApplyResource(c13, FrameworkElement.StyleProperty, "SplitButtonInnerButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_);
					Grid.SetColumn(c13, 2);
					c13.SetBinding(Control.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c13.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c13.SetBinding(Control.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					AutomationProperties.SetAccessibilityView(c13, AccessibilityView.Raw);
					_component_4 = c13;
					c13.CreationComplete();
				})
			}
		}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(Grid c14)
		{
			nameScope.RegisterName("RootGrid", c14);
			RootGrid = c14;
			c14.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c14, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c15)
						{
							nameScope.RegisterName("Normal", c15);
							Normal = c15;
						}),
						new VisualState
						{
							Name = "FlyoutOpen"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c16)
						{
							nameScope.RegisterName("FlyoutOpen", c16);
							FlyoutOpen = c16;
							MarkupHelper.SetVisualStateLazy(c16, delegate
							{
								c16.Name = "FlyoutOpen";
								c16.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c16.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c16.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c16.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c16.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "TouchPressed"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c17)
						{
							nameScope.RegisterName("TouchPressed", c17);
							TouchPressed = c17;
							MarkupHelper.SetVisualStateLazy(c17, delegate
							{
								c17.Name = "TouchPressed";
								c17.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c17.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c17.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c17.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c17.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PrimaryPointerOver"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c18)
						{
							nameScope.RegisterName("PrimaryPointerOver", c18);
							PrimaryPointerOver = c18;
							MarkupHelper.SetVisualStateLazy(c18, delegate
							{
								c18.Name = "PrimaryPointerOver";
								c18.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c18.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c18.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c18.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "PrimaryPressed"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c19)
						{
							nameScope.RegisterName("PrimaryPressed", c19);
							PrimaryPressed = c19;
							MarkupHelper.SetVisualStateLazy(c19, delegate
							{
								c19.Name = "PrimaryPressed";
								c19.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c19.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c19.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c19.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "SecondaryPointerOver"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c20)
						{
							nameScope.RegisterName("SecondaryPointerOver", c20);
							SecondaryPointerOver = c20;
							MarkupHelper.SetVisualStateLazy(c20, delegate
							{
								c20.Name = "SecondaryPointerOver";
								c20.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c20.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c20.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c20.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "SecondaryPressed"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c21)
						{
							nameScope.RegisterName("SecondaryPressed", c21);
							SecondaryPressed = c21;
							MarkupHelper.SetVisualStateLazy(c21, delegate
							{
								c21.Name = "SecondaryPressed";
								c21.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c21.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c21.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c21.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Checked"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c22)
						{
							nameScope.RegisterName("Checked", c22);
							Checked = c22;
							MarkupHelper.SetVisualStateLazy(c22, delegate
							{
								c22.Name = "Checked";
								c22.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c22.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c22.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c22.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c22.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "CheckedFlyoutOpen"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c23)
						{
							nameScope.RegisterName("CheckedFlyoutOpen", c23);
							CheckedFlyoutOpen = c23;
							MarkupHelper.SetVisualStateLazy(c23, delegate
							{
								c23.Name = "CheckedFlyoutOpen";
								c23.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c23.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c23.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c23.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c23.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "CheckedTouchPressed"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c24)
						{
							nameScope.RegisterName("CheckedTouchPressed", c24);
							CheckedTouchPressed = c24;
							MarkupHelper.SetVisualStateLazy(c24, delegate
							{
								c24.Name = "CheckedTouchPressed";
								c24.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c24.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c24.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c24.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c24.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "CheckedPrimaryPointerOver"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c25)
						{
							nameScope.RegisterName("CheckedPrimaryPointerOver", c25);
							CheckedPrimaryPointerOver = c25;
							MarkupHelper.SetVisualStateLazy(c25, delegate
							{
								c25.Name = "CheckedPrimaryPointerOver";
								c25.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c25.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c25.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c25.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c25.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c25.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "CheckedPrimaryPressed"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c26)
						{
							nameScope.RegisterName("CheckedPrimaryPressed", c26);
							CheckedPrimaryPressed = c26;
							MarkupHelper.SetVisualStateLazy(c26, delegate
							{
								c26.Name = "CheckedPrimaryPressed";
								c26.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c26.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c26.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c26.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c26.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c26.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "CheckedSecondaryPointerOver"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c27)
						{
							nameScope.RegisterName("CheckedSecondaryPointerOver", c27);
							CheckedSecondaryPointerOver = c27;
							MarkupHelper.SetVisualStateLazy(c27, delegate
							{
								c27.Name = "CheckedSecondaryPointerOver";
								c27.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c27.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c27.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c27.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c27.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c27.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "CheckedSecondaryPressed"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c28)
						{
							nameScope.RegisterName("CheckedSecondaryPressed", c28);
							CheckedSecondaryPressed = c28;
							MarkupHelper.SetVisualStateLazy(c28, delegate
							{
								c28.Name = "CheckedSecondaryPressed";
								c28.Setters.Add(new Setter(new TargetPropertyPath(_BorderSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c28.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c28.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c28.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryBackgroundGridSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c28.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonBorderBrushCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonBorderBrushCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c28.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SplitButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SplitButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__67.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualStateGroup c29)
				{
					nameScope.RegisterName("CommonStates", c29);
					CommonStates = c29;
				}),
				new VisualStateGroup
				{
					Name = "SecondaryButtonPlacementStates",
					States = 
					{
						new VisualState
						{
							Name = "SecondaryButtonRight"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c30)
						{
							nameScope.RegisterName("SecondaryButtonRight", c30);
							SecondaryButtonRight = c30;
						}),
						new VisualState
						{
							Name = "SecondaryButtonSpan"
						}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualState c31)
						{
							nameScope.RegisterName("SecondaryButtonSpan", c31);
							SecondaryButtonSpan = c31;
							MarkupHelper.SetVisualStateLazy(c31, delegate
							{
								c31.Name = "SecondaryButtonSpan";
								c31.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
								c31.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "3"));
							});
						})
					}
				}.SplitButton_d5225a226024e774d58a1fd16c5d0a45_XamlApply(delegate(VisualStateGroup c32)
				{
					nameScope.RegisterName("SecondaryButtonPlacementStates", c32);
					SecondaryButtonPlacementStates = c32;
				})
			});
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

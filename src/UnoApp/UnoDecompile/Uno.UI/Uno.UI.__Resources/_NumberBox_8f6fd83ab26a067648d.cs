using System;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_NumberBoxRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _InputBoxSubject = new ElementNameSubject();

	private ElementNameSubject _PopupUpSpinButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PopupDownSpinButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PopupContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _UpDownPopupSubject = new ElementNameSubject();

	private ElementNameSubject _UpSpinButtonSubject = new ElementNameSubject();

	private ElementNameSubject _DownSpinButtonSubject = new ElementNameSubject();

	private ElementNameSubject _SpinButtonsCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _SpinButtonsVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _SpinButtonsPopupSubject = new ElementNameSubject();

	private ElementNameSubject _SpinButtonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _UpSpinButtonEnabledSubject = new ElementNameSubject();

	private ElementNameSubject _UpSpinButtonDisabledSubject = new ElementNameSubject();

	private ElementNameSubject _UpSpinButtonEnabledStatesSubject = new ElementNameSubject();

	private ElementNameSubject _DownSpinButtonEnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DownSpinButtonDisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DownSpinButtonEnabledStatesSubject = new ElementNameSubject();

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

	private Popup _component_3
	{
		get
		{
			return (Popup)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private RepeatButton _component_4
	{
		get
		{
			return (RepeatButton)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private RepeatButton _component_5
	{
		get
		{
			return (RepeatButton)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private TextBox InputBox
	{
		get
		{
			return (TextBox)_InputBoxSubject.ElementInstance;
		}
		set
		{
			_InputBoxSubject.ElementInstance = value;
		}
	}

	private RepeatButton PopupUpSpinButton
	{
		get
		{
			return (RepeatButton)_PopupUpSpinButtonSubject.ElementInstance;
		}
		set
		{
			_PopupUpSpinButtonSubject.ElementInstance = value;
		}
	}

	private RepeatButton PopupDownSpinButton
	{
		get
		{
			return (RepeatButton)_PopupDownSpinButtonSubject.ElementInstance;
		}
		set
		{
			_PopupDownSpinButtonSubject.ElementInstance = value;
		}
	}

	private Grid PopupContentRoot
	{
		get
		{
			return (Grid)_PopupContentRootSubject.ElementInstance;
		}
		set
		{
			_PopupContentRootSubject.ElementInstance = value;
		}
	}

	private Popup UpDownPopup
	{
		get
		{
			return (Popup)_UpDownPopupSubject.ElementInstance;
		}
		set
		{
			_UpDownPopupSubject.ElementInstance = value;
		}
	}

	private RepeatButton UpSpinButton
	{
		get
		{
			return (RepeatButton)_UpSpinButtonSubject.ElementInstance;
		}
		set
		{
			_UpSpinButtonSubject.ElementInstance = value;
		}
	}

	private RepeatButton DownSpinButton
	{
		get
		{
			return (RepeatButton)_DownSpinButtonSubject.ElementInstance;
		}
		set
		{
			_DownSpinButtonSubject.ElementInstance = value;
		}
	}

	private VisualState SpinButtonsCollapsed
	{
		get
		{
			return (VisualState)_SpinButtonsCollapsedSubject.ElementInstance;
		}
		set
		{
			_SpinButtonsCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState SpinButtonsVisible
	{
		get
		{
			return (VisualState)_SpinButtonsVisibleSubject.ElementInstance;
		}
		set
		{
			_SpinButtonsVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState SpinButtonsPopup
	{
		get
		{
			return (VisualState)_SpinButtonsPopupSubject.ElementInstance;
		}
		set
		{
			_SpinButtonsPopupSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup SpinButtonStates
	{
		get
		{
			return (VisualStateGroup)_SpinButtonStatesSubject.ElementInstance;
		}
		set
		{
			_SpinButtonStatesSubject.ElementInstance = value;
		}
	}

	private VisualState UpSpinButtonEnabled
	{
		get
		{
			return (VisualState)_UpSpinButtonEnabledSubject.ElementInstance;
		}
		set
		{
			_UpSpinButtonEnabledSubject.ElementInstance = value;
		}
	}

	private VisualState UpSpinButtonDisabled
	{
		get
		{
			return (VisualState)_UpSpinButtonDisabledSubject.ElementInstance;
		}
		set
		{
			_UpSpinButtonDisabledSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup UpSpinButtonEnabledStates
	{
		get
		{
			return (VisualStateGroup)_UpSpinButtonEnabledStatesSubject.ElementInstance;
		}
		set
		{
			_UpSpinButtonEnabledStatesSubject.ElementInstance = value;
		}
	}

	private VisualState DownSpinButtonEnabled
	{
		get
		{
			return (VisualState)_DownSpinButtonEnabledSubject.ElementInstance;
		}
		set
		{
			_DownSpinButtonEnabledSubject.ElementInstance = value;
		}
	}

	private VisualState DownSpinButtonDisabled
	{
		get
		{
			return (VisualState)_DownSpinButtonDisabledSubject.ElementInstance;
		}
		set
		{
			_DownSpinButtonDisabledSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DownSpinButtonEnabledStates
	{
		get
		{
			return (VisualStateGroup)_DownSpinButtonEnabledStatesSubject.ElementInstance;
		}
		set
		{
			_DownSpinButtonEnabledStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_162)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		Grid grid = new Grid();
		grid.IsParsing = true;
		object key = "Light";
		grid.Resources.ThemeDictionaries[key] = new WeakResourceInitializer(__ResourceOwner_162, (object? __ResourceOwner_163) => new ResourceDictionary
		{
			IsSystemDictionary = true,
			["RepeatButtonBorderBrushPointerOver"] = ResourceResolverSingleton.Instance.ResolveStaticResourceAlias("TextControlBorderBrush", GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_),
			["RepeatButtonBorderBrushPressed"] = ResourceResolverSingleton.Instance.ResolveStaticResourceAlias("TextControlBorderBrush", GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_)
		});
		object key2 = "Dark";
		grid.Resources.ThemeDictionaries[key2] = new WeakResourceInitializer(__ResourceOwner_162, (object? __ResourceOwner_164) => new ResourceDictionary
		{
			IsSystemDictionary = true,
			["RepeatButtonBorderBrushPointerOver"] = ResourceResolverSingleton.Instance.ResolveStaticResourceAlias("TextControlBorderBrush", GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_),
			["RepeatButtonBorderBrushPressed"] = ResourceResolverSingleton.Instance.ResolveStaticResourceAlias("TextControlBorderBrush", GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_)
		});
		object key3 = "HighContrast";
		grid.Resources.ThemeDictionaries[key3] = new WeakResourceInitializer(__ResourceOwner_162, (object? __ResourceOwner_165) => new ResourceDictionary
		{
			IsSystemDictionary = true,
			["RepeatButtonBorderBrushPointerOver"] = ResourceResolverSingleton.Instance.ResolveStaticResourceAlias("SystemControlHighlightBaseMediumLowBrush", GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_),
			["RepeatButtonBorderBrushPressed"] = ResourceResolverSingleton.Instance.ResolveStaticResourceAlias("SystemControlHighlightTransparentBrush", GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_)
		});
		grid.ColumnDefinitions.Add(new ColumnDefinition
		{
			Width = new GridLength(1.0, GridUnitType.Star)
		});
		grid.ColumnDefinitions.Add(new ColumnDefinition
		{
			Width = new GridLength(1.0, GridUnitType.Auto)
		});
		grid.ColumnDefinitions.Add(new ColumnDefinition
		{
			Width = new GridLength(1.0, GridUnitType.Auto)
		});
		grid.Children.Add(new TextBox
		{
			IsParsing = true,
			Name = "InputBox"
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(TextBox c3)
		{
			nameScope.RegisterName("InputBox", c3);
			InputBox = c3;
			Grid.SetColumn(c3, 0);
			c3.SetBinding(TextBox.HeaderProperty, new Binding
			{
				Path = "Header",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(TextBox.HeaderTemplateProperty, new Binding
			{
				Path = "HeaderTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(TextBox.PlaceholderTextProperty, new Binding
			{
				Path = "PlaceholderText",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(TextBox.SelectionHighlightColorProperty, new Binding
			{
				Path = "SelectionHighlightColor",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(TextBox.TextReadingOrderProperty, new Binding
			{
				Path = "TextReadingOrder",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(TextBox.PreventKeyboardDisplayOnProgrammaticFocusProperty, new Binding
			{
				Path = "PreventKeyboardDisplayOnProgrammaticFocus",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.CreationComplete();
		}));
		grid.Children.Add(new Popup
		{
			IsParsing = true,
			Name = "UpDownPopup",
			HorizontalAlignment = HorizontalAlignment.Left,
			Child = new Grid
			{
				IsParsing = true,
				Name = "PopupContentRoot",
				RowDefinitions = 
				{
					new RowDefinition
					{
						Height = new GridLength(1.0, GridUnitType.Star)
					},
					new RowDefinition
					{
						Height = new GridLength(1.0, GridUnitType.Star)
					}
				},
				Children = 
				{
					(UIElement)new RepeatButton
					{
						IsParsing = true,
						Name = "PopupUpSpinButton",
						Content = "\ue0e4"
					}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(RepeatButton c6)
					{
						nameScope.RegisterName("PopupUpSpinButton", c6);
						PopupUpSpinButton = c6;
						ResourceResolverSingleton.Instance.ApplyResource(c6, FrameworkElement.StyleProperty, "NumberBoxPopupSpinButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
						Grid.SetRow(c6, 0);
						_component_0 = c6;
						c6.CreationComplete();
					}),
					(UIElement)new RepeatButton
					{
						IsParsing = true,
						Name = "PopupDownSpinButton",
						Content = "\ue0e5"
					}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(RepeatButton c7)
					{
						nameScope.RegisterName("PopupDownSpinButton", c7);
						PopupDownSpinButton = c7;
						ResourceResolverSingleton.Instance.ApplyResource(c7, FrameworkElement.StyleProperty, "NumberBoxPopupSpinButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
						Grid.SetRow(c7, 1);
						_component_1 = c7;
						c7.CreationComplete();
					})
				}
			}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(Grid c8)
			{
				nameScope.RegisterName("PopupContentRoot", c8);
				PopupContentRoot = c8;
				ResourceResolverSingleton.Instance.ApplyResource(c8, FrameworkElement.BackgroundProperty, "SystemControlBackgroundAltHighBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
				_component_2 = c8;
				c8.CreationComplete();
			})
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(Popup c9)
		{
			nameScope.RegisterName("UpDownPopup", c9);
			UpDownPopup = c9;
			Grid.SetColumn(c9, 1);
			ResourceResolverSingleton.Instance.ApplyResource(c9, Popup.VerticalOffsetProperty, "NumberBoxPopupVerticalOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c9, Popup.HorizontalOffsetProperty, "NumberBoxPopupHorizonalOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			_component_3 = c9;
			c9.CreationComplete();
		}));
		grid.Children.Add(new RepeatButton
		{
			IsParsing = true,
			Name = "UpSpinButton",
			Visibility = Visibility.Collapsed,
			Content = "\ue0e4"
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(RepeatButton c10)
		{
			nameScope.RegisterName("UpSpinButton", c10);
			UpSpinButton = c10;
			Grid.SetColumn(c10, 1);
			c10.SetBinding(Control.FontSizeProperty, new Binding
			{
				Path = "FontSize",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c10, FrameworkElement.StyleProperty, "NumberBoxSpinButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			_component_4 = c10;
			c10.CreationComplete();
		}));
		grid.Children.Add(new RepeatButton
		{
			IsParsing = true,
			Name = "DownSpinButton",
			Visibility = Visibility.Collapsed,
			Content = "\ue0e5"
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(RepeatButton c11)
		{
			nameScope.RegisterName("DownSpinButton", c11);
			DownSpinButton = c11;
			Grid.SetColumn(c11, 2);
			c11.SetBinding(Control.FontSizeProperty, new Binding
			{
				Path = "FontSize",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c11, FrameworkElement.StyleProperty, "NumberBoxSpinButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			_component_5 = c11;
			c11.CreationComplete();
		}));
		uIElement = grid.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(Grid c12)
		{
			VisualStateManager.SetVisualStateGroups(c12, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "SpinButtonStates",
					States = 
					{
						new VisualState
						{
							Name = "SpinButtonsCollapsed"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c13)
						{
							nameScope.RegisterName("SpinButtonsCollapsed", c13);
							SpinButtonsCollapsed = c13;
						}),
						new VisualState
						{
							Name = "SpinButtonsVisible"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c14)
						{
							nameScope.RegisterName("SpinButtonsVisible", c14);
							SpinButtonsVisible = c14;
							MarkupHelper.SetVisualStateLazy(c14, delegate
							{
								c14.Name = "SpinButtonsVisible";
								c14.Setters.Add(new Setter(new TargetPropertyPath(_DownSpinButtonSubject, (PropertyPath)"Visibility"), "Visible"));
								c14.Setters.Add(new Setter(new TargetPropertyPath(_UpSpinButtonSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						}),
						new VisualState
						{
							Name = "SpinButtonsPopup"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c15)
						{
							nameScope.RegisterName("SpinButtonsPopup", c15);
							SpinButtonsPopup = c15;
							MarkupHelper.SetVisualStateLazy(c15, delegate
							{
								c15.Name = "SpinButtonsPopup";
								c15.Setters.Add(new Setter(new TargetPropertyPath(_InputBoxSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NumberBoxTextBoxStyle", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_)));
							});
						})
					}
				}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualStateGroup c16)
				{
					nameScope.RegisterName("SpinButtonStates", c16);
					SpinButtonStates = c16;
				}),
				new VisualStateGroup
				{
					Name = "UpSpinButtonEnabledStates",
					States = 
					{
						new VisualState
						{
							Name = "UpSpinButtonEnabled"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c17)
						{
							nameScope.RegisterName("UpSpinButtonEnabled", c17);
							UpSpinButtonEnabled = c17;
						}),
						new VisualState
						{
							Name = "UpSpinButtonDisabled"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c18)
						{
							nameScope.RegisterName("UpSpinButtonDisabled", c18);
							UpSpinButtonDisabled = c18;
							MarkupHelper.SetVisualStateLazy(c18, delegate
							{
								c18.Name = "UpSpinButtonDisabled";
								c18.Setters.Add(new Setter(new TargetPropertyPath(_UpSpinButtonSubject, (PropertyPath)"IsEnabled"), "False"));
								c18.Setters.Add(new Setter(new TargetPropertyPath(_PopupUpSpinButtonSubject, (PropertyPath)"IsEnabled"), "False"));
							});
						})
					}
				}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualStateGroup c19)
				{
					nameScope.RegisterName("UpSpinButtonEnabledStates", c19);
					UpSpinButtonEnabledStates = c19;
				}),
				new VisualStateGroup
				{
					Name = "DownSpinButtonEnabledStates",
					States = 
					{
						new VisualState
						{
							Name = "DownSpinButtonEnabled"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c20)
						{
							nameScope.RegisterName("DownSpinButtonEnabled", c20);
							DownSpinButtonEnabled = c20;
						}),
						new VisualState
						{
							Name = "DownSpinButtonDisabled"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c21)
						{
							nameScope.RegisterName("DownSpinButtonDisabled", c21);
							DownSpinButtonDisabled = c21;
							MarkupHelper.SetVisualStateLazy(c21, delegate
							{
								c21.Name = "DownSpinButtonDisabled";
								c21.Setters.Add(new Setter(new TargetPropertyPath(_DownSpinButtonSubject, (PropertyPath)"IsEnabled"), "False"));
								c21.Setters.Add(new Setter(new TargetPropertyPath(_PopupDownSpinButtonSubject, (PropertyPath)"IsEnabled"), "False"));
							});
						})
					}
				}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualStateGroup c22)
				{
					nameScope.RegisterName("DownSpinButtonEnabledStates", c22);
					DownSpinButtonEnabledStates = c22;
				})
			});
			c12.CreationComplete();
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
internal class _NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_NumberBoxRDSC1
{
	private class _NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_UnoUI__Resources_NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_NumberBoxRDSC1NumberBoxRDSC2
	{
		private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_7_Holder = new ComponentHolder(isWeak: true);

		private ElementNameSubject _GlyphElementSubject = new ElementNameSubject();

		private ElementNameSubject _ButtonLayoutGridSubject = new ElementNameSubject();

		private ElementNameSubject _NormalSubject = new ElementNameSubject();

		private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

		private ElementNameSubject _PressedSubject = new ElementNameSubject();

		private ElementNameSubject _DisabledSubject = new ElementNameSubject();

		private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

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

		private TextBlock GlyphElement
		{
			get
			{
				return (TextBlock)_GlyphElementSubject.ElementInstance;
			}
			set
			{
				_GlyphElementSubject.ElementInstance = value;
			}
		}

		private Grid ButtonLayoutGrid
		{
			get
			{
				return (Grid)_ButtonLayoutGridSubject.ElementInstance;
			}
			set
			{
				_ButtonLayoutGridSubject.ElementInstance = value;
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

		public UIElement Build(object __ResourceOwner_195)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new Grid
			{
				IsParsing = true,
				Name = "ButtonLayoutGrid",
				Children = { (UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "GlyphElement",
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					FontStyle = FontStyle.Normal,
					FontSize = 12.0,
					Text = "\ue10a"
				}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(TextBlock c77)
				{
					nameScope.RegisterName("GlyphElement", c77);
					GlyphElement = c77;
					ResourceResolverSingleton.Instance.ApplyResource(c77, TextBlock.ForegroundProperty, "TextControlButtonForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c77, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
					AutomationProperties.SetAccessibilityView(c77, AccessibilityView.Raw);
					_component_0 = c77;
					c77.CreationComplete();
				}) }
			}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(Grid c78)
			{
				nameScope.RegisterName("ButtonLayoutGrid", c78);
				ButtonLayoutGrid = c78;
				ResourceResolverSingleton.Instance.ApplyResource(c78, Grid.BorderBrushProperty, "TextControlButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
				c78.SetBinding(Grid.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				ResourceResolverSingleton.Instance.ApplyResource(c78, FrameworkElement.BackgroundProperty, "TextControlButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
				VisualStateManager.SetVisualStateGroups(c78, new VisualStateGroup[1] { new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c79)
						{
							nameScope.RegisterName("Normal", c79);
							Normal = c79;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c80)
						{
							nameScope.RegisterName("PointerOver", c80);
							PointerOver = c80;
							MarkupHelper.SetVisualStateLazy(c80, delegate
							{
								c80.Name = "PointerOver";
								c80.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c81)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c81, ObjectKeyFrame.ValueProperty, "TextControlButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_1 = c81;
												NameScope.SetNameScope(_component_1, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c82)
										{
											Storyboard.SetTargetName(c82, "ButtonLayoutGrid");
											Storyboard.SetTarget(c82, _ButtonLayoutGridSubject);
											Storyboard.SetTargetProperty(c82, "Background");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c83)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c83, ObjectKeyFrame.ValueProperty, "TextControlButtonBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_2 = c83;
												NameScope.SetNameScope(_component_2, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c84)
										{
											Storyboard.SetTargetName(c84, "ButtonLayoutGrid");
											Storyboard.SetTarget(c84, _ButtonLayoutGridSubject);
											Storyboard.SetTargetProperty(c84, "BorderBrush");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c85)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c85, ObjectKeyFrame.ValueProperty, "TextControlButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_3 = c85;
												NameScope.SetNameScope(_component_3, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c86)
										{
											Storyboard.SetTargetName(c86, "GlyphElement");
											Storyboard.SetTarget(c86, _GlyphElementSubject);
											Storyboard.SetTargetProperty(c86, "Foreground");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c87)
						{
							nameScope.RegisterName("Pressed", c87);
							Pressed = c87;
							MarkupHelper.SetVisualStateLazy(c87, delegate
							{
								c87.Name = "Pressed";
								c87.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c88)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c88, ObjectKeyFrame.ValueProperty, "TextControlButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_4 = c88;
												NameScope.SetNameScope(_component_4, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c89)
										{
											Storyboard.SetTargetName(c89, "ButtonLayoutGrid");
											Storyboard.SetTarget(c89, _ButtonLayoutGridSubject);
											Storyboard.SetTargetProperty(c89, "Background");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c90)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c90, ObjectKeyFrame.ValueProperty, "TextControlButtonBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_5 = c90;
												NameScope.SetNameScope(_component_5, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c91)
										{
											Storyboard.SetTargetName(c91, "ButtonLayoutGrid");
											Storyboard.SetTarget(c91, _ButtonLayoutGridSubject);
											Storyboard.SetTargetProperty(c91, "BorderBrush");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c92)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c92, ObjectKeyFrame.ValueProperty, "TextControlButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_6 = c92;
												NameScope.SetNameScope(_component_6, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c93)
										{
											Storyboard.SetTargetName(c93, "GlyphElement");
											Storyboard.SetTarget(c93, _GlyphElementSubject);
											Storyboard.SetTargetProperty(c93, "Foreground");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c94)
						{
							nameScope.RegisterName("Disabled", c94);
							Disabled = c94;
							MarkupHelper.SetVisualStateLazy(c94, delegate
							{
								c94.Name = "Disabled";
								c94.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DoubleAnimation
									{
										To = 0.0,
										Duration = new Duration(TimeSpan.FromTicks(0L))
									}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DoubleAnimation c95)
									{
										Storyboard.SetTargetName(c95, "ButtonLayoutGrid");
										Storyboard.SetTarget(c95, _ButtonLayoutGridSubject);
										Storyboard.SetTargetProperty(c95, "Opacity");
									}) }
								};
							});
						})
					}
				}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualStateGroup c96)
				{
					nameScope.RegisterName("CommonStates", c96);
					CommonStates = c96;
				}) });
				_component_7 = c78;
				c78.CreationComplete();
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

	private ElementNameSubject _HeaderContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _BorderElementSubject = new ElementNameSubject();

	private ElementNameSubject _ContentElementSubject = new ElementNameSubject();

	private ElementNameSubject _PlaceholderTextContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _DeleteButtonSubject = new ElementNameSubject();

	private ElementNameSubject _DescriptionPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _FocusedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ButtonVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _ButtonCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ButtonStatesSubject = new ElementNameSubject();

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

	private Border _component_1
	{
		get
		{
			return (Border)_component_1_Holder.Instance;
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

	private DiscreteObjectKeyFrame _component_7
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_8
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_9
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_10
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_11
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_12
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_13
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_14
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_14_Holder.Instance;
		}
		set
		{
			_component_14_Holder.Instance = value;
		}
	}

	private ContentPresenter HeaderContentPresenter
	{
		get
		{
			return (ContentPresenter)_HeaderContentPresenterSubject.ElementInstance;
		}
		set
		{
			_HeaderContentPresenterSubject.ElementInstance = value;
		}
	}

	private Border BorderElement
	{
		get
		{
			return (Border)_BorderElementSubject.ElementInstance;
		}
		set
		{
			_BorderElementSubject.ElementInstance = value;
		}
	}

	private ScrollViewer ContentElement
	{
		get
		{
			return (ScrollViewer)_ContentElementSubject.ElementInstance;
		}
		set
		{
			_ContentElementSubject.ElementInstance = value;
		}
	}

	private TextBlock PlaceholderTextContentPresenter
	{
		get
		{
			return (TextBlock)_PlaceholderTextContentPresenterSubject.ElementInstance;
		}
		set
		{
			_PlaceholderTextContentPresenterSubject.ElementInstance = value;
		}
	}

	private Button DeleteButton
	{
		get
		{
			return (Button)_DeleteButtonSubject.ElementInstance;
		}
		set
		{
			_DeleteButtonSubject.ElementInstance = value;
		}
	}

	private ContentPresenter DescriptionPresenter
	{
		get
		{
			return (ContentPresenter)_DescriptionPresenterSubject.ElementInstance;
		}
		set
		{
			_DescriptionPresenterSubject.ElementInstance = value;
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

	private VisualState ButtonVisible
	{
		get
		{
			return (VisualState)_ButtonVisibleSubject.ElementInstance;
		}
		set
		{
			_ButtonVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState ButtonCollapsed
	{
		get
		{
			return (VisualState)_ButtonCollapsedSubject.ElementInstance;
		}
		set
		{
			_ButtonCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ButtonStates
	{
		get
		{
			return (VisualStateGroup)_ButtonStatesSubject.ElementInstance;
		}
		set
		{
			_ButtonStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_178)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		Grid grid = new Grid();
		grid.IsParsing = true;
		object key = (__LinkerHints.Is_Windows_UI_Xaml_Controls_Button_Available ? "DeleteButtonStyle" : null);
		grid.Resources[key] = new Style(typeof(Button))
		{
			Setters = { (SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_178, (object? __ResourceOwner_179) => new ControlTemplate(__ResourceOwner_179, (object? __owner) => new _NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_UnoUI__Resources_NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_NumberBoxRDSC1NumberBoxRDSC2().Build(__owner))) }
		};
		grid.RowDefinitions.Add(new RowDefinition
		{
			Height = new GridLength(1.0, GridUnitType.Auto)
		});
		grid.RowDefinitions.Add(new RowDefinition
		{
			Height = new GridLength(1.0, GridUnitType.Star)
		});
		grid.RowDefinitions.Add(new RowDefinition
		{
			Height = new GridLength(1.0, GridUnitType.Auto)
		});
		grid.ColumnDefinitions.Add(new ColumnDefinition
		{
			Width = new GridLength(1.0, GridUnitType.Star)
		});
		grid.ColumnDefinitions.Add(new ColumnDefinition
		{
			Width = new GridLength(1.0, GridUnitType.Auto)
		});
		grid.ColumnDefinitions.Add(new ColumnDefinition
		{
			Width = new GridLength(1.0, GridUnitType.Auto)
		});
		grid.Children.Add(new ElementStub(() => new ContentPresenter
		{
			IsParsing = true,
			Name = "HeaderContentPresenter",
			FontWeight = FontWeights.Normal,
			TextWrapping = TextWrapping.Wrap,
			VerticalAlignment = VerticalAlignment.Top,
			Visibility = Visibility.Collapsed
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ContentPresenter c29)
		{
			nameScope.RegisterName("HeaderContentPresenter", c29);
			HeaderContentPresenter = c29;
			Grid.SetRow(c29, 0);
			Grid.SetColumn(c29, 0);
			Grid.SetColumnSpan(c29, 2);
			c29.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Header",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c29.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
			{
				Path = "HeaderTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c29, ContentPresenter.ForegroundProperty, "TextControlHeaderForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c29, FrameworkElement.MarginProperty, "TextBoxTopHeaderMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			_component_0 = c29;
			c29.CreationComplete();
		})).NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ElementStub c30)
		{
			c30.Name = "HeaderContentPresenter";
			_HeaderContentPresenterSubject.ElementInstance = c30;
			c30.Visibility = Visibility.Collapsed;
		}));
		grid.Children.Add(new Border
		{
			IsParsing = true,
			Name = "BorderElement"
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(Border c31)
		{
			nameScope.RegisterName("BorderElement", c31);
			BorderElement = c31;
			Grid.SetRow(c31, 1);
			Grid.SetColumn(c31, 0);
			Grid.SetRowSpan(c31, 1);
			Grid.SetColumnSpan(c31, 3);
			c31.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c31.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c31.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c31.SetBinding(Border.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			Control.SetIsTemplateFocusTarget(c31, value: true);
			ResourceResolverSingleton.Instance.ApplyResource(c31, FrameworkElement.MinWidthProperty, "TextControlThemeMinWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c31, FrameworkElement.MinHeightProperty, "TextControlThemeMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			_component_1 = c31;
			c31.CreationComplete();
		}));
		grid.Children.Add(new ScrollViewer
		{
			IsParsing = true,
			Name = "ContentElement",
			IsTabStop = false
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ScrollViewer c32)
		{
			nameScope.RegisterName("ContentElement", c32);
			ContentElement = c32;
			Grid.SetRow(c32, 1);
			Grid.SetColumn(c32, 0);
			c32.SetBinding(ScrollViewer.HorizontalScrollModeProperty, new Binding
			{
				Path = "ScrollViewer.HorizontalScrollMode",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(ScrollViewer.HorizontalScrollBarVisibilityProperty, new Binding
			{
				Path = "ScrollViewer.HorizontalScrollBarVisibility",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(ScrollViewer.VerticalScrollModeProperty, new Binding
			{
				Path = "ScrollViewer.VerticalScrollMode",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(ScrollViewer.VerticalScrollBarVisibilityProperty, new Binding
			{
				Path = "ScrollViewer.VerticalScrollBarVisibility",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(ScrollViewer.IsHorizontalRailEnabledProperty, new Binding
			{
				Path = "ScrollViewer.IsHorizontalRailEnabled",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(ScrollViewer.IsVerticalRailEnabledProperty, new Binding
			{
				Path = "ScrollViewer.IsVerticalRailEnabled",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(ScrollViewer.IsDeferredScrollingEnabledProperty, new Binding
			{
				Path = "ScrollViewer.IsDeferredScrollingEnabled",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c32.SetBinding(Control.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			AutomationProperties.SetAccessibilityView(c32, AccessibilityView.Raw);
			ScrollViewer.SetZoomMode(c32, ZoomMode.Disabled);
			c32.CreationComplete();
		}));
		grid.Children.Add(new TextBlock
		{
			IsParsing = true,
			Name = "PlaceholderTextContentPresenter",
			IsHitTestVisible = false
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(TextBlock c33)
		{
			nameScope.RegisterName("PlaceholderTextContentPresenter", c33);
			PlaceholderTextContentPresenter = c33;
			Grid.SetRow(c33, 1);
			Grid.SetColumn(c33, 0);
			Grid.SetColumnSpan(c33, 2);
			c33.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c33.SetBinding(TextBlock.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c33.SetBinding(TextBlock.TextProperty, new Binding
			{
				Path = "PlaceholderText",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c33.SetBinding(TextBlock.TextAlignmentProperty, new Binding
			{
				Path = "TextAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c33.SetBinding(TextBlock.TextWrappingProperty, new Binding
			{
				Path = "TextWrapping",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c33.CreationComplete();
		}));
		grid.Children.Add(new Button
		{
			IsParsing = true,
			Name = "DeleteButton",
			IsTabStop = false,
			Visibility = Visibility.Collapsed,
			MinWidth = 34.0,
			VerticalAlignment = VerticalAlignment.Stretch
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(Button c34)
		{
			nameScope.RegisterName("DeleteButton", c34);
			DeleteButton = c34;
			Grid.SetRow(c34, 1);
			Grid.SetColumn(c34, 1);
			ResourceResolverSingleton.Instance.ApplyResource(c34, FrameworkElement.StyleProperty, "DeleteButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			c34.SetBinding(Control.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c34, FrameworkElement.MarginProperty, "HelperButtonThemePadding", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			AutomationProperties.SetAccessibilityView(c34, AccessibilityView.Raw);
			c34.SetBinding(Control.FontSizeProperty, new Binding
			{
				Path = "FontSize",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			_component_2 = c34;
			c34.CreationComplete();
		}));
		grid.Children.Add(new ElementStub(() => new ContentPresenter
		{
			IsParsing = true,
			Name = "DescriptionPresenter"
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ContentPresenter c35)
		{
			nameScope.RegisterName("DescriptionPresenter", c35);
			DescriptionPresenter = c35;
			Grid.SetRow(c35, 2);
			Grid.SetColumn(c35, 0);
			Grid.SetColumnSpan(c35, 2);
			c35.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Description",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c35, ContentPresenter.ForegroundProperty, "SystemControlDescriptionTextForegroundBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			AutomationProperties.SetAccessibilityView(c35, AccessibilityView.Raw);
			_component_3 = c35;
			c35.CreationComplete();
		})).NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ElementStub c36)
		{
			c36.Name = "DescriptionPresenter";
			_DescriptionPresenterSubject.ElementInstance = c36;
		}));
		grid.Children.Add(new TextBlock
		{
			IsParsing = true,
			VerticalAlignment = VerticalAlignment.Center,
			HorizontalAlignment = HorizontalAlignment.Center,
			FontSize = 12.0,
			Text = "\uec8f"
		}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(TextBlock c37)
		{
			Grid.SetRow(c37, 1);
			Grid.SetColumn(c37, 2);
			ResourceResolverSingleton.Instance.ApplyResource(c37, FrameworkElement.MarginProperty, "NumberBoxPopupIndicatorMargin", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c37, TextBlock.ForegroundProperty, "NumberBoxPopupIndicatorForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c37, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
			AutomationProperties.SetAccessibilityView(c37, AccessibilityView.Raw);
			_component_4 = c37;
			c37.CreationComplete();
		}));
		uIElement = grid.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(Grid c38)
		{
			VisualStateManager.SetVisualStateGroups(c38, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c39)
						{
							nameScope.RegisterName("Normal", c39);
							Normal = c39;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c40)
						{
							nameScope.RegisterName("Disabled", c40);
							Disabled = c40;
							MarkupHelper.SetVisualStateLazy(c40, delegate
							{
								c40.Name = "Disabled";
								c40.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c41)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c41, ObjectKeyFrame.ValueProperty, "TextControlHeaderForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_5 = c41;
												NameScope.SetNameScope(_component_5, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c42)
										{
											Storyboard.SetTargetName(c42, "HeaderContentPresenter");
											Storyboard.SetTarget(c42, _HeaderContentPresenterSubject);
											Storyboard.SetTargetProperty(c42, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c43)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c43, ObjectKeyFrame.ValueProperty, "TextControlBackgroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_6 = c43;
												NameScope.SetNameScope(_component_6, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c44)
										{
											Storyboard.SetTargetName(c44, "BorderElement");
											Storyboard.SetTarget(c44, _BorderElementSubject);
											Storyboard.SetTargetProperty(c44, "Background");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c45)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c45, ObjectKeyFrame.ValueProperty, "TextControlBorderBrushDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_7 = c45;
												NameScope.SetNameScope(_component_7, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c46)
										{
											Storyboard.SetTargetName(c46, "BorderElement");
											Storyboard.SetTarget(c46, _BorderElementSubject);
											Storyboard.SetTargetProperty(c46, "BorderBrush");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c47)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c47, ObjectKeyFrame.ValueProperty, "TextControlForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_8 = c47;
												NameScope.SetNameScope(_component_8, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c48)
										{
											Storyboard.SetTargetName(c48, "ContentElement");
											Storyboard.SetTarget(c48, _ContentElementSubject);
											Storyboard.SetTargetProperty(c48, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c49)
											{
												c49.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													Path = "PlaceholderForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													TargetNullValue = ResourceResolverSingleton.Instance.ResolveResourceStatic("TextControlPlaceholderForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_)
												});
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c50)
										{
											Storyboard.SetTargetName(c50, "PlaceholderTextContentPresenter");
											Storyboard.SetTarget(c50, _PlaceholderTextContentPresenterSubject);
											Storyboard.SetTargetProperty(c50, "Foreground");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c51)
						{
							nameScope.RegisterName("PointerOver", c51);
							PointerOver = c51;
							MarkupHelper.SetVisualStateLazy(c51, delegate
							{
								c51.Name = "PointerOver";
								c51.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c52)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c52, ObjectKeyFrame.ValueProperty, "TextControlBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_9 = c52;
												NameScope.SetNameScope(_component_9, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c53)
										{
											Storyboard.SetTargetName(c53, "BorderElement");
											Storyboard.SetTarget(c53, _BorderElementSubject);
											Storyboard.SetTargetProperty(c53, "BorderBrush");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c54)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c54, ObjectKeyFrame.ValueProperty, "TextControlBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_10 = c54;
												NameScope.SetNameScope(_component_10, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c55)
										{
											Storyboard.SetTargetName(c55, "BorderElement");
											Storyboard.SetTarget(c55, _BorderElementSubject);
											Storyboard.SetTargetProperty(c55, "Background");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c56)
											{
												c56.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													Path = "PlaceholderForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													TargetNullValue = ResourceResolverSingleton.Instance.ResolveResourceStatic("TextControlPlaceholderForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_)
												});
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c57)
										{
											Storyboard.SetTargetName(c57, "PlaceholderTextContentPresenter");
											Storyboard.SetTarget(c57, _PlaceholderTextContentPresenterSubject);
											Storyboard.SetTargetProperty(c57, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c58)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c58, ObjectKeyFrame.ValueProperty, "TextControlForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_11 = c58;
												NameScope.SetNameScope(_component_11, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c59)
										{
											Storyboard.SetTargetName(c59, "ContentElement");
											Storyboard.SetTarget(c59, _ContentElementSubject);
											Storyboard.SetTargetProperty(c59, "Foreground");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Focused"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c60)
						{
							nameScope.RegisterName("Focused", c60);
							Focused = c60;
							MarkupHelper.SetVisualStateLazy(c60, delegate
							{
								c60.Name = "Focused";
								c60.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c61)
											{
												c61.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													Path = "PlaceholderForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													TargetNullValue = ResourceResolverSingleton.Instance.ResolveResourceStatic("TextControlPlaceholderForegroundFocused", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_)
												});
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c62)
										{
											Storyboard.SetTargetName(c62, "PlaceholderTextContentPresenter");
											Storyboard.SetTarget(c62, _PlaceholderTextContentPresenterSubject);
											Storyboard.SetTargetProperty(c62, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c63)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c63, ObjectKeyFrame.ValueProperty, "TextControlBackgroundFocused", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_12 = c63;
												NameScope.SetNameScope(_component_12, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c64)
										{
											Storyboard.SetTargetName(c64, "BorderElement");
											Storyboard.SetTarget(c64, _BorderElementSubject);
											Storyboard.SetTargetProperty(c64, "Background");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c65)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c65, ObjectKeyFrame.ValueProperty, "TextControlBorderBrushFocused", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_13 = c65;
												NameScope.SetNameScope(_component_13, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c66)
										{
											Storyboard.SetTargetName(c66, "BorderElement");
											Storyboard.SetTarget(c66, _BorderElementSubject);
											Storyboard.SetTargetProperty(c66, "BorderBrush");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(DiscreteObjectKeyFrame c67)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c67, ObjectKeyFrame.ValueProperty, "TextControlForegroundFocused", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__45.Instance.__ParseContext_);
												_component_14 = c67;
												NameScope.SetNameScope(_component_14, nameScope);
											}) }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c68)
										{
											Storyboard.SetTargetName(c68, "ContentElement");
											Storyboard.SetTarget(c68, _ContentElementSubject);
											Storyboard.SetTargetProperty(c68, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Light"
											} }
										}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c70)
										{
											Storyboard.SetTargetName(c70, "ContentElement");
											Storyboard.SetTarget(c70, _ContentElementSubject);
											Storyboard.SetTargetProperty(c70, "RequestedTheme");
										})
									}
								};
							});
						})
					}
				}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualStateGroup c71)
				{
					nameScope.RegisterName("CommonStates", c71);
					CommonStates = c71;
				}),
				new VisualStateGroup
				{
					Name = "ButtonStates",
					States = 
					{
						new VisualState
						{
							Name = "ButtonVisible"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c72)
						{
							nameScope.RegisterName("ButtonVisible", c72);
							ButtonVisible = c72;
							MarkupHelper.SetVisualStateLazy(c72, delegate
							{
								c72.Name = "ButtonVisible";
								c72.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = Visibility.Visible
										} }
									}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c74)
									{
										Storyboard.SetTargetName(c74, "DeleteButton");
										Storyboard.SetTarget(c74, _DeleteButtonSubject);
										Storyboard.SetTargetProperty(c74, "Visibility");
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "ButtonCollapsed"
						}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualState c75)
						{
							nameScope.RegisterName("ButtonCollapsed", c75);
							ButtonCollapsed = c75;
						})
					}
				}.NumberBox_8f6fd83ab26a067648d6b7b050acc5ee_XamlApply(delegate(VisualStateGroup c76)
				{
					nameScope.RegisterName("ButtonStates", c76);
					ButtonStates = c76;
				})
			});
			c38.CreationComplete();
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

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _ColorPicker_b040c09ab0c1542acb928d53b00aa94f_ColorPickerRDSC0
{
	private class _ColorPicker_b040c09ab0c1542acb928d53b00aa94f_UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_ColorPickerRDSC0ColorPickerRDSC1
	{
		private class _ColorPicker_b040c09ab0c1542acb928d53b00aa94f_UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_ColorPickerRDSC0ColorPickerRDSC1UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_ColorPickerRDSC0ColorPickerRDSC2
		{
			private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

			private Border _component_0
			{
				get
				{
					return (Border)_component_0_Holder.Instance;
				}
				set
				{
					_component_0_Holder.Instance = value;
				}
			}

			public UIElement Build(object __ResourceOwner_1225)
			{
				NameScope nameScope = new NameScope();
				UIElement uIElement = null;
				uIElement = new Border
				{
					IsParsing = true
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Border c193)
				{
					c193.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c193.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c193.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c193, Border.CornerRadiusProperty, "SliderThumbCornerRadius", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
					_component_0 = c193;
					c193.CreationComplete();
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

		private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

		private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

		private ElementNameSubject _HeaderContentPresenterSubject = new ElementNameSubject();

		private ElementNameSubject _HorizontalTrackRectSubject = new ElementNameSubject();

		private ElementNameSubject _HorizontalDecreaseRectSubject = new ElementNameSubject();

		private ElementNameSubject _HorizontalThumbSubject = new ElementNameSubject();

		private ElementNameSubject _ToolTipSubject = new ElementNameSubject();

		private ElementNameSubject _HorizontalTemplateSubject = new ElementNameSubject();

		private ElementNameSubject _SliderContainerSubject = new ElementNameSubject();

		private ElementNameSubject _NormalSubject = new ElementNameSubject();

		private ElementNameSubject _PressedSubject = new ElementNameSubject();

		private ElementNameSubject _DisabledSubject = new ElementNameSubject();

		private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

		private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

		private ElementNameSubject _FocusDisengagedSubject = new ElementNameSubject();

		private ElementNameSubject _FocusEngagedHorizontalSubject = new ElementNameSubject();

		private ElementNameSubject _FocusEngagedVerticalSubject = new ElementNameSubject();

		private ElementNameSubject _FocusEngagementStatesSubject = new ElementNameSubject();

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

		private Rectangle _component_1
		{
			get
			{
				return (Rectangle)_component_1_Holder.Instance;
			}
			set
			{
				_component_1_Holder.Instance = value;
			}
		}

		private Thumb _component_2
		{
			get
			{
				return (Thumb)_component_2_Holder.Instance;
			}
			set
			{
				_component_2_Holder.Instance = value;
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

		private Rectangle HorizontalTrackRect
		{
			get
			{
				return (Rectangle)_HorizontalTrackRectSubject.ElementInstance;
			}
			set
			{
				_HorizontalTrackRectSubject.ElementInstance = value;
			}
		}

		private Rectangle HorizontalDecreaseRect
		{
			get
			{
				return (Rectangle)_HorizontalDecreaseRectSubject.ElementInstance;
			}
			set
			{
				_HorizontalDecreaseRectSubject.ElementInstance = value;
			}
		}

		private Thumb HorizontalThumb
		{
			get
			{
				return (Thumb)_HorizontalThumbSubject.ElementInstance;
			}
			set
			{
				_HorizontalThumbSubject.ElementInstance = value;
			}
		}

		private ToolTip ToolTip
		{
			get
			{
				return (ToolTip)_ToolTipSubject.ElementInstance;
			}
			set
			{
				_ToolTipSubject.ElementInstance = value;
			}
		}

		private Grid HorizontalTemplate
		{
			get
			{
				return (Grid)_HorizontalTemplateSubject.ElementInstance;
			}
			set
			{
				_HorizontalTemplateSubject.ElementInstance = value;
			}
		}

		private Grid SliderContainer
		{
			get
			{
				return (Grid)_SliderContainerSubject.ElementInstance;
			}
			set
			{
				_SliderContainerSubject.ElementInstance = value;
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

		private VisualState FocusDisengaged
		{
			get
			{
				return (VisualState)_FocusDisengagedSubject.ElementInstance;
			}
			set
			{
				_FocusDisengagedSubject.ElementInstance = value;
			}
		}

		private VisualState FocusEngagedHorizontal
		{
			get
			{
				return (VisualState)_FocusEngagedHorizontalSubject.ElementInstance;
			}
			set
			{
				_FocusEngagedHorizontalSubject.ElementInstance = value;
			}
		}

		private VisualState FocusEngagedVertical
		{
			get
			{
				return (VisualState)_FocusEngagedVerticalSubject.ElementInstance;
			}
			set
			{
				_FocusEngagedVerticalSubject.ElementInstance = value;
			}
		}

		private VisualStateGroup FocusEngagementStates
		{
			get
			{
				return (VisualStateGroup)_FocusEngagementStatesSubject.ElementInstance;
			}
			set
			{
				_FocusEngagementStatesSubject.ElementInstance = value;
			}
		}

		public UIElement Build(object __ResourceOwner_1126)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new Grid
			{
				IsParsing = true,
				Resources = { [(object)(__LinkerHints.Is_Windows_UI_Xaml_Controls_Primitives_Thumb_Available ? "SliderThumbStyle" : null)] = (__LinkerHints.Is_Windows_UI_Xaml_Controls_Primitives_Thumb_Available ? new WeakResourceInitializer(__ResourceOwner_1126, (object? __ResourceOwner_1128) => new Style(typeof(Thumb))
				{
					Setters = 
					{
						(SetterBase)new Setter(Control.BorderThicknessProperty, new Thickness(0.0)),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(FrameworkElement.BackgroundProperty, "ColorPickerSliderThumbBackground", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, null).ApplyThemeResourceUpdateValues("ColorPickerSliderThumbBackground", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, isTheme: true, isHotReload: false),
						(SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_1128, (object? __ResourceOwner_1130) => new ControlTemplate(__ResourceOwner_1130, (object? __owner) => new _ColorPicker_b040c09ab0c1542acb928d53b00aa94f_UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_ColorPickerRDSC0ColorPickerRDSC1UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_ColorPickerRDSC0ColorPickerRDSC2().Build(__owner)))
					}
				}) : null) },
				Margin = new Thickness(0.0, 5.0, 0.0, 0.0),
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
					(UIElement)new ElementStub(() => new ContentPresenter
					{
						IsParsing = true,
						Name = "HeaderContentPresenter",
						TextWrapping = TextWrapping.Wrap,
						Visibility = Visibility.Collapsed
					}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ContentPresenter c170)
					{
						nameScope.RegisterName("HeaderContentPresenter", c170);
						HeaderContentPresenter = c170;
						c170.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
						{
							Path = "HeaderTemplate",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c170.SetBinding(ContentPresenter.ContentProperty, new Binding
						{
							Path = "Header",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						ResourceResolverSingleton.Instance.ApplyResource(c170, ContentPresenter.ForegroundProperty, "SliderHeaderForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c170, ContentPresenter.FontWeightProperty, "SliderHeaderThemeFontWeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c170, FrameworkElement.MarginProperty, "SliderHeaderThemeMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
						_component_0 = c170;
						c170.CreationComplete();
					})).ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ElementStub c171)
					{
						c171.Name = "HeaderContentPresenter";
						_HeaderContentPresenterSubject.ElementInstance = c171;
						c171.Visibility = Visibility.Collapsed;
					}),
					(UIElement)new Grid
					{
						IsParsing = true,
						Name = "SliderContainer",
						Background = SolidColorBrushHelper.Transparent,
						Children = { (UIElement)new Grid
						{
							IsParsing = true,
							Name = "HorizontalTemplate",
							MinHeight = 44.0,
							ColumnDefinitions = 
							{
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition()
							},
							RowDefinitions = 
							{
								new RowDefinition
								{
									Height = new GridLength(18.0, GridUnitType.Pixel)
								},
								new RowDefinition
								{
									Height = new GridLength(1.0, GridUnitType.Auto)
								},
								new RowDefinition
								{
									Height = new GridLength(18.0, GridUnitType.Pixel)
								}
							},
							Children = 
							{
								(UIElement)new Rectangle
								{
									IsParsing = true,
									Name = "HorizontalTrackRect",
									Fill = SolidColorBrushHelper.Transparent,
									Opacity = 0.0
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c177)
								{
									nameScope.RegisterName("HorizontalTrackRect", c177);
									HorizontalTrackRect = c177;
									Grid.SetColumnSpan(c177, 3);
									ResourceResolverSingleton.Instance.ApplyResource(c177, FrameworkElement.HeightProperty, "SliderTrackThemeHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
									Grid.SetRow(c177, 1);
									c177.SetBinding(Rectangle.RadiusXProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c177.SetBinding(Rectangle.RadiusYProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									_component_1 = c177;
									c177.CreationComplete();
								}),
								(UIElement)new Rectangle
								{
									IsParsing = true,
									Name = "HorizontalDecreaseRect",
									Fill = SolidColorBrushHelper.Transparent,
									Opacity = 0.0
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c178)
								{
									nameScope.RegisterName("HorizontalDecreaseRect", c178);
									HorizontalDecreaseRect = c178;
									Grid.SetRow(c178, 1);
									c178.CreationComplete();
								}),
								(UIElement)new Thumb
								{
									IsParsing = true,
									Name = "HorizontalThumb"
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Thumb c179)
								{
									nameScope.RegisterName("HorizontalThumb", c179);
									HorizontalThumb = c179;
									AutomationProperties.SetAccessibilityView(c179, AccessibilityView.Raw);
									Grid.SetColumn(c179, 1);
									c179.SetBinding(UIElement.DataContextProperty, new Binding
									{
										Path = "Value",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									ResourceResolverSingleton.Instance.ApplyResource(c179, FrameworkElement.HeightProperty, "SliderHorizontalThumbHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
									Grid.SetRow(c179, 0);
									Grid.SetRowSpan(c179, 3);
									ResourceResolverSingleton.Instance.ApplyResource(c179, FrameworkElement.StyleProperty, "SliderThumbStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
									ResourceResolverSingleton.Instance.ApplyResource(c179, FrameworkElement.WidthProperty, "SliderHorizontalThumbWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
									ToolTipService.SetToolTip(c179, new ToolTip
									{
										IsParsing = true,
										Name = "ToolTip",
										VerticalOffset = 20.0
									}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ToolTip c180)
									{
										nameScope.RegisterName("ToolTip", c180);
										ToolTip = c180;
										c180.CreationComplete();
									}));
									_component_2 = c179;
									c179.CreationComplete();
								})
							}
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c181)
						{
							nameScope.RegisterName("HorizontalTemplate", c181);
							HorizontalTemplate = c181;
							c181.CreationComplete();
						}) }
					}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c182)
					{
						nameScope.RegisterName("SliderContainer", c182);
						SliderContainer = c182;
						Control.SetIsTemplateFocusTarget(c182, value: true);
						Grid.SetRow(c182, 1);
						c182.CreationComplete();
					})
				}
			}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c183)
			{
				VisualStateManager.SetVisualStateGroups(c183, new VisualStateGroup[2]
				{
					new VisualStateGroup
					{
						Name = "CommonStates",
						States = 
						{
							new VisualState
							{
								Name = "Normal"
							}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c184)
							{
								nameScope.RegisterName("Normal", c184);
								Normal = c184;
							}),
							new VisualState
							{
								Name = "Pressed"
							}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c185)
							{
								nameScope.RegisterName("Pressed", c185);
								Pressed = c185;
								MarkupHelper.SetVisualStateLazy(c185, delegate
								{
									c185.Name = "Pressed";
									c185.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ColorPickerSliderThumbBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ColorPickerSliderThumbBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								});
							}),
							new VisualState
							{
								Name = "Disabled"
							}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c186)
							{
								nameScope.RegisterName("Disabled", c186);
								Disabled = c186;
								MarkupHelper.SetVisualStateLazy(c186, delegate
								{
									c186.Name = "Disabled";
									c186.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlDisabledBaseMediumLowBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlDisabledBaseMediumLowBrush", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, isTheme: true, isHotReload: false));
									c186.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ColorPickerSliderThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ColorPickerSliderThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, isTheme: true, isHotReload: false));
									c186.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ColorPickerSliderTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ColorPickerSliderTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, isTheme: true, isHotReload: false));
									c186.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalDecreaseRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ColorPickerSliderTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ColorPickerSliderTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								});
							}),
							new VisualState
							{
								Name = "PointerOver"
							}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c187)
							{
								nameScope.RegisterName("PointerOver", c187);
								PointerOver = c187;
								MarkupHelper.SetVisualStateLazy(c187, delegate
								{
									c187.Name = "PointerOver";
									c187.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ColorPickerSliderThumbBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ColorPickerSliderThumbBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								});
							})
						}
					}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c188)
					{
						nameScope.RegisterName("CommonStates", c188);
						CommonStates = c188;
					}),
					new VisualStateGroup
					{
						Name = "FocusEngagementStates",
						States = 
						{
							new VisualState
							{
								Name = "FocusDisengaged"
							}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c189)
							{
								nameScope.RegisterName("FocusDisengaged", c189);
								FocusDisengaged = c189;
							}),
							new VisualState
							{
								Name = "FocusEngagedHorizontal"
							}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c190)
							{
								nameScope.RegisterName("FocusEngagedHorizontal", c190);
								FocusEngagedHorizontal = c190;
								MarkupHelper.SetVisualStateLazy(c190, delegate
								{
									c190.Name = "FocusEngagedHorizontal";
									c190.Setters.Add(new Setter(new TargetPropertyPath(_SliderContainerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Control.IsTemplateFocusTarget)"), "False"));
									c190.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Control.IsTemplateFocusTarget)"), "True"));
								});
							}),
							new VisualState
							{
								Name = "FocusEngagedVertical"
							}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c191)
							{
								nameScope.RegisterName("FocusEngagedVertical", c191);
								FocusEngagedVertical = c191;
								MarkupHelper.SetVisualStateLazy(c191, delegate
								{
									c191.Name = "FocusEngagedVertical";
									c191.Setters.Add(new Setter(new TargetPropertyPath(_SliderContainerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Control.IsTemplateFocusTarget)"), "False"));
									c191.Setters.Add(new Setter());
								});
							})
						}
					}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c192)
					{
						nameScope.RegisterName("FocusEngagementStates", c192);
						FocusEngagementStates = c192;
					})
				});
				c183.CreationComplete();
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

	private ComponentHolder _component_17_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_18_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_19_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_20_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_21_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_22_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_23_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_24_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_25_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_26_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_27_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_28_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_29_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_30_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_31_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_32_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_33_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_34_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_35_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_36_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _CheckerColorBrushSubject = new ElementNameSubject();

	private ElementNameSubject _ColorSpectrumSubject = new ElementNameSubject();

	private ElementNameSubject _ColorPreviewRectangleCheckeredBackgroundImageBrushSubject = new ElementNameSubject();

	private ElementNameSubject _ColorPreviewRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _PreviousColorRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _BorderRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _ColorPreviewRectangleGridSubject = new ElementNameSubject();

	private ElementNameSubject _ColorSpectrumGridSubject = new ElementNameSubject();

	private ElementNameSubject _ThirdDimensionSliderGradientBrushSubject = new ElementNameSubject();

	private ElementNameSubject _ThirdDimensionSliderSubject = new ElementNameSubject();

	private ElementNameSubject _ThirdDimensionSliderGridSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderCheckeredBackgroundImageBrushSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderGradientBrushSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderBackgroundRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderGridSubject = new ElementNameSubject();

	private ElementNameSubject _MoreButtonLabelSubject = new ElementNameSubject();

	private ElementNameSubject _MoreGlyphSubject = new ElementNameSubject();

	private ElementNameSubject _MoreButtonSubject = new ElementNameSubject();

	private ElementNameSubject _RGBComboBoxItemSubject = new ElementNameSubject();

	private ElementNameSubject _HSVComboBoxItemSubject = new ElementNameSubject();

	private ElementNameSubject _ColorRepresentationComboBoxSubject = new ElementNameSubject();

	private ElementNameSubject _RedTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _RedLabelSubject = new ElementNameSubject();

	private ElementNameSubject _GreenTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _GreenLabelSubject = new ElementNameSubject();

	private ElementNameSubject _BlueTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _BlueLabelSubject = new ElementNameSubject();

	private ElementNameSubject _RgbPanelSubject = new ElementNameSubject();

	private ElementNameSubject _HueTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _HueLabelSubject = new ElementNameSubject();

	private ElementNameSubject _SaturationTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _SaturationLabelSubject = new ElementNameSubject();

	private ElementNameSubject _ValueTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _ValueLabelSubject = new ElementNameSubject();

	private ElementNameSubject _HsvPanelSubject = new ElementNameSubject();

	private ElementNameSubject _ColorChannelTextInputPanelSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaLabelSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaPanelSubject = new ElementNameSubject();

	private ElementNameSubject _HexTextBoxSubject = new ElementNameSubject();

	private ElementNameSubject _TextEntryGridSubject = new ElementNameSubject();

	private ElementNameSubject _ColorSpectrumVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _ColorSpectrumCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ColorSpectrumVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _ColorPreviewVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _ColorPreviewCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ColorPreviewVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _PreviousColorCollapsedVerticalSubject = new ElementNameSubject();

	private ElementNameSubject _PreviousColorVisibleVerticalSubject = new ElementNameSubject();

	private ElementNameSubject _PreviousColorCollapsedHorizontalSubject = new ElementNameSubject();

	private ElementNameSubject _PreviousColorVisibleHorizontalSubject = new ElementNameSubject();

	private ElementNameSubject _PreviousColorVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _ThirdDimensionSliderVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _ThirdDimensionSliderCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ThirdDimensionSliderVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaSliderVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _MoreButtonVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _MoreButtonCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _MoreButtonVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _TextEntryGridCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _TextEntryGridVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _TextEntryGridVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _ColorChannelTextInputVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _ColorChannelTextInputCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ColorChannelTextInputVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _AlphaTextInputVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaTextInputCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaTextInputVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _RgbSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _HsvSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _ColorRepresentationSelectedSubject = new ElementNameSubject();

	private ElementNameSubject _HexInputVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _HexInputCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _HexInputVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _AlphaDisabledSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaEnabledSubject = new ElementNameSubject();

	private ElementNameSubject _AlphaEnabledStateSubject = new ElementNameSubject();

	private SolidColorBrush _component_0
	{
		get
		{
			return (SolidColorBrush)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Rectangle _component_1
	{
		get
		{
			return (Rectangle)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider _component_2
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider _component_3
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_4
	{
		get
		{
			return (SolidColorBrush)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_5
	{
		get
		{
			return (SolidColorBrush)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_6
	{
		get
		{
			return (SolidColorBrush)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_7
	{
		get
		{
			return (SolidColorBrush)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_8
	{
		get
		{
			return (SolidColorBrush)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_9
	{
		get
		{
			return (SolidColorBrush)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_10
	{
		get
		{
			return (SolidColorBrush)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_11
	{
		get
		{
			return (SolidColorBrush)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_12
	{
		get
		{
			return (SolidColorBrush)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_13
	{
		get
		{
			return (SolidColorBrush)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_14
	{
		get
		{
			return (SolidColorBrush)_component_14_Holder.Instance;
		}
		set
		{
			_component_14_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_15
	{
		get
		{
			return (SolidColorBrush)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_16
	{
		get
		{
			return (SolidColorBrush)_component_16_Holder.Instance;
		}
		set
		{
			_component_16_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_17
	{
		get
		{
			return (SolidColorBrush)_component_17_Holder.Instance;
		}
		set
		{
			_component_17_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_18
	{
		get
		{
			return (SolidColorBrush)_component_18_Holder.Instance;
		}
		set
		{
			_component_18_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_19
	{
		get
		{
			return (SolidColorBrush)_component_19_Holder.Instance;
		}
		set
		{
			_component_19_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_20
	{
		get
		{
			return (SolidColorBrush)_component_20_Holder.Instance;
		}
		set
		{
			_component_20_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_21
	{
		get
		{
			return (SolidColorBrush)_component_21_Holder.Instance;
		}
		set
		{
			_component_21_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_22
	{
		get
		{
			return (SolidColorBrush)_component_22_Holder.Instance;
		}
		set
		{
			_component_22_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_23
	{
		get
		{
			return (SolidColorBrush)_component_23_Holder.Instance;
		}
		set
		{
			_component_23_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_24
	{
		get
		{
			return (SolidColorBrush)_component_24_Holder.Instance;
		}
		set
		{
			_component_24_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_25
	{
		get
		{
			return (SolidColorBrush)_component_25_Holder.Instance;
		}
		set
		{
			_component_25_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_26
	{
		get
		{
			return (SolidColorBrush)_component_26_Holder.Instance;
		}
		set
		{
			_component_26_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_27
	{
		get
		{
			return (SolidColorBrush)_component_27_Holder.Instance;
		}
		set
		{
			_component_27_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_28
	{
		get
		{
			return (SolidColorBrush)_component_28_Holder.Instance;
		}
		set
		{
			_component_28_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_29
	{
		get
		{
			return (SolidColorBrush)_component_29_Holder.Instance;
		}
		set
		{
			_component_29_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_30
	{
		get
		{
			return (SolidColorBrush)_component_30_Holder.Instance;
		}
		set
		{
			_component_30_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_31
	{
		get
		{
			return (SolidColorBrush)_component_31_Holder.Instance;
		}
		set
		{
			_component_31_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_32
	{
		get
		{
			return (SolidColorBrush)_component_32_Holder.Instance;
		}
		set
		{
			_component_32_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_33
	{
		get
		{
			return (SolidColorBrush)_component_33_Holder.Instance;
		}
		set
		{
			_component_33_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_34
	{
		get
		{
			return (SolidColorBrush)_component_34_Holder.Instance;
		}
		set
		{
			_component_34_Holder.Instance = value;
		}
	}

	private SolidColorBrush _component_35
	{
		get
		{
			return (SolidColorBrush)_component_35_Holder.Instance;
		}
		set
		{
			_component_35_Holder.Instance = value;
		}
	}

	private FontIcon _component_36
	{
		get
		{
			return (FontIcon)_component_36_Holder.Instance;
		}
		set
		{
			_component_36_Holder.Instance = value;
		}
	}

	private SolidColorBrush CheckerColorBrush
	{
		get
		{
			return (SolidColorBrush)_CheckerColorBrushSubject.ElementInstance;
		}
		set
		{
			_CheckerColorBrushSubject.ElementInstance = value;
		}
	}

	private Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum ColorSpectrum
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum)_ColorSpectrumSubject.ElementInstance;
		}
		set
		{
			_ColorSpectrumSubject.ElementInstance = value;
		}
	}

	private ImageBrush ColorPreviewRectangleCheckeredBackgroundImageBrush
	{
		get
		{
			return (ImageBrush)_ColorPreviewRectangleCheckeredBackgroundImageBrushSubject.ElementInstance;
		}
		set
		{
			_ColorPreviewRectangleCheckeredBackgroundImageBrushSubject.ElementInstance = value;
		}
	}

	private Rectangle ColorPreviewRectangle
	{
		get
		{
			return (Rectangle)_ColorPreviewRectangleSubject.ElementInstance;
		}
		set
		{
			_ColorPreviewRectangleSubject.ElementInstance = value;
		}
	}

	private Rectangle PreviousColorRectangle
	{
		get
		{
			return (Rectangle)_PreviousColorRectangleSubject.ElementInstance;
		}
		set
		{
			_PreviousColorRectangleSubject.ElementInstance = value;
		}
	}

	private Rectangle BorderRectangle
	{
		get
		{
			return (Rectangle)_BorderRectangleSubject.ElementInstance;
		}
		set
		{
			_BorderRectangleSubject.ElementInstance = value;
		}
	}

	private Grid ColorPreviewRectangleGrid
	{
		get
		{
			return (Grid)_ColorPreviewRectangleGridSubject.ElementInstance;
		}
		set
		{
			_ColorPreviewRectangleGridSubject.ElementInstance = value;
		}
	}

	private Grid ColorSpectrumGrid
	{
		get
		{
			return (Grid)_ColorSpectrumGridSubject.ElementInstance;
		}
		set
		{
			_ColorSpectrumGridSubject.ElementInstance = value;
		}
	}

	private LinearGradientBrush ThirdDimensionSliderGradientBrush
	{
		get
		{
			return (LinearGradientBrush)_ThirdDimensionSliderGradientBrushSubject.ElementInstance;
		}
		set
		{
			_ThirdDimensionSliderGradientBrushSubject.ElementInstance = value;
		}
	}

	private Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider ThirdDimensionSlider
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider)_ThirdDimensionSliderSubject.ElementInstance;
		}
		set
		{
			_ThirdDimensionSliderSubject.ElementInstance = value;
		}
	}

	private Grid ThirdDimensionSliderGrid
	{
		get
		{
			return (Grid)_ThirdDimensionSliderGridSubject.ElementInstance;
		}
		set
		{
			_ThirdDimensionSliderGridSubject.ElementInstance = value;
		}
	}

	private ImageBrush AlphaSliderCheckeredBackgroundImageBrush
	{
		get
		{
			return (ImageBrush)_AlphaSliderCheckeredBackgroundImageBrushSubject.ElementInstance;
		}
		set
		{
			_AlphaSliderCheckeredBackgroundImageBrushSubject.ElementInstance = value;
		}
	}

	private LinearGradientBrush AlphaSliderGradientBrush
	{
		get
		{
			return (LinearGradientBrush)_AlphaSliderGradientBrushSubject.ElementInstance;
		}
		set
		{
			_AlphaSliderGradientBrushSubject.ElementInstance = value;
		}
	}

	private Rectangle AlphaSliderBackgroundRectangle
	{
		get
		{
			return (Rectangle)_AlphaSliderBackgroundRectangleSubject.ElementInstance;
		}
		set
		{
			_AlphaSliderBackgroundRectangleSubject.ElementInstance = value;
		}
	}

	private Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider AlphaSlider
	{
		get
		{
			return (Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider)_AlphaSliderSubject.ElementInstance;
		}
		set
		{
			_AlphaSliderSubject.ElementInstance = value;
		}
	}

	private Grid AlphaSliderGrid
	{
		get
		{
			return (Grid)_AlphaSliderGridSubject.ElementInstance;
		}
		set
		{
			_AlphaSliderGridSubject.ElementInstance = value;
		}
	}

	private TextBlock MoreButtonLabel
	{
		get
		{
			return (TextBlock)_MoreButtonLabelSubject.ElementInstance;
		}
		set
		{
			_MoreButtonLabelSubject.ElementInstance = value;
		}
	}

	private FontIcon MoreGlyph
	{
		get
		{
			return (FontIcon)_MoreGlyphSubject.ElementInstance;
		}
		set
		{
			_MoreGlyphSubject.ElementInstance = value;
		}
	}

	private ToggleButton MoreButton
	{
		get
		{
			return (ToggleButton)_MoreButtonSubject.ElementInstance;
		}
		set
		{
			_MoreButtonSubject.ElementInstance = value;
		}
	}

	private ComboBoxItem RGBComboBoxItem
	{
		get
		{
			return (ComboBoxItem)_RGBComboBoxItemSubject.ElementInstance;
		}
		set
		{
			_RGBComboBoxItemSubject.ElementInstance = value;
		}
	}

	private ComboBoxItem HSVComboBoxItem
	{
		get
		{
			return (ComboBoxItem)_HSVComboBoxItemSubject.ElementInstance;
		}
		set
		{
			_HSVComboBoxItemSubject.ElementInstance = value;
		}
	}

	private ComboBox ColorRepresentationComboBox
	{
		get
		{
			return (ComboBox)_ColorRepresentationComboBoxSubject.ElementInstance;
		}
		set
		{
			_ColorRepresentationComboBoxSubject.ElementInstance = value;
		}
	}

	private TextBox RedTextBox
	{
		get
		{
			return (TextBox)_RedTextBoxSubject.ElementInstance;
		}
		set
		{
			_RedTextBoxSubject.ElementInstance = value;
		}
	}

	private TextBlock RedLabel
	{
		get
		{
			return (TextBlock)_RedLabelSubject.ElementInstance;
		}
		set
		{
			_RedLabelSubject.ElementInstance = value;
		}
	}

	private TextBox GreenTextBox
	{
		get
		{
			return (TextBox)_GreenTextBoxSubject.ElementInstance;
		}
		set
		{
			_GreenTextBoxSubject.ElementInstance = value;
		}
	}

	private TextBlock GreenLabel
	{
		get
		{
			return (TextBlock)_GreenLabelSubject.ElementInstance;
		}
		set
		{
			_GreenLabelSubject.ElementInstance = value;
		}
	}

	private TextBox BlueTextBox
	{
		get
		{
			return (TextBox)_BlueTextBoxSubject.ElementInstance;
		}
		set
		{
			_BlueTextBoxSubject.ElementInstance = value;
		}
	}

	private TextBlock BlueLabel
	{
		get
		{
			return (TextBlock)_BlueLabelSubject.ElementInstance;
		}
		set
		{
			_BlueLabelSubject.ElementInstance = value;
		}
	}

	private StackPanel RgbPanel
	{
		get
		{
			return (StackPanel)_RgbPanelSubject.ElementInstance;
		}
		set
		{
			_RgbPanelSubject.ElementInstance = value;
		}
	}

	private TextBox HueTextBox
	{
		get
		{
			return (TextBox)_HueTextBoxSubject.ElementInstance;
		}
		set
		{
			_HueTextBoxSubject.ElementInstance = value;
		}
	}

	private TextBlock HueLabel
	{
		get
		{
			return (TextBlock)_HueLabelSubject.ElementInstance;
		}
		set
		{
			_HueLabelSubject.ElementInstance = value;
		}
	}

	private TextBox SaturationTextBox
	{
		get
		{
			return (TextBox)_SaturationTextBoxSubject.ElementInstance;
		}
		set
		{
			_SaturationTextBoxSubject.ElementInstance = value;
		}
	}

	private TextBlock SaturationLabel
	{
		get
		{
			return (TextBlock)_SaturationLabelSubject.ElementInstance;
		}
		set
		{
			_SaturationLabelSubject.ElementInstance = value;
		}
	}

	private TextBox ValueTextBox
	{
		get
		{
			return (TextBox)_ValueTextBoxSubject.ElementInstance;
		}
		set
		{
			_ValueTextBoxSubject.ElementInstance = value;
		}
	}

	private TextBlock ValueLabel
	{
		get
		{
			return (TextBlock)_ValueLabelSubject.ElementInstance;
		}
		set
		{
			_ValueLabelSubject.ElementInstance = value;
		}
	}

	private StackPanel HsvPanel
	{
		get
		{
			return (StackPanel)_HsvPanelSubject.ElementInstance;
		}
		set
		{
			_HsvPanelSubject.ElementInstance = value;
		}
	}

	private StackPanel ColorChannelTextInputPanel
	{
		get
		{
			return (StackPanel)_ColorChannelTextInputPanelSubject.ElementInstance;
		}
		set
		{
			_ColorChannelTextInputPanelSubject.ElementInstance = value;
		}
	}

	private TextBox AlphaTextBox
	{
		get
		{
			return (TextBox)_AlphaTextBoxSubject.ElementInstance;
		}
		set
		{
			_AlphaTextBoxSubject.ElementInstance = value;
		}
	}

	private TextBlock AlphaLabel
	{
		get
		{
			return (TextBlock)_AlphaLabelSubject.ElementInstance;
		}
		set
		{
			_AlphaLabelSubject.ElementInstance = value;
		}
	}

	private StackPanel AlphaPanel
	{
		get
		{
			return (StackPanel)_AlphaPanelSubject.ElementInstance;
		}
		set
		{
			_AlphaPanelSubject.ElementInstance = value;
		}
	}

	private TextBox HexTextBox
	{
		get
		{
			return (TextBox)_HexTextBoxSubject.ElementInstance;
		}
		set
		{
			_HexTextBoxSubject.ElementInstance = value;
		}
	}

	private Grid TextEntryGrid
	{
		get
		{
			return (Grid)_TextEntryGridSubject.ElementInstance;
		}
		set
		{
			_TextEntryGridSubject.ElementInstance = value;
		}
	}

	private VisualState ColorSpectrumVisible
	{
		get
		{
			return (VisualState)_ColorSpectrumVisibleSubject.ElementInstance;
		}
		set
		{
			_ColorSpectrumVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState ColorSpectrumCollapsed
	{
		get
		{
			return (VisualState)_ColorSpectrumCollapsedSubject.ElementInstance;
		}
		set
		{
			_ColorSpectrumCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ColorSpectrumVisibility
	{
		get
		{
			return (VisualStateGroup)_ColorSpectrumVisibilitySubject.ElementInstance;
		}
		set
		{
			_ColorSpectrumVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState ColorPreviewVisible
	{
		get
		{
			return (VisualState)_ColorPreviewVisibleSubject.ElementInstance;
		}
		set
		{
			_ColorPreviewVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState ColorPreviewCollapsed
	{
		get
		{
			return (VisualState)_ColorPreviewCollapsedSubject.ElementInstance;
		}
		set
		{
			_ColorPreviewCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ColorPreviewVisibility
	{
		get
		{
			return (VisualStateGroup)_ColorPreviewVisibilitySubject.ElementInstance;
		}
		set
		{
			_ColorPreviewVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState PreviousColorCollapsedVertical
	{
		get
		{
			return (VisualState)_PreviousColorCollapsedVerticalSubject.ElementInstance;
		}
		set
		{
			_PreviousColorCollapsedVerticalSubject.ElementInstance = value;
		}
	}

	private VisualState PreviousColorVisibleVertical
	{
		get
		{
			return (VisualState)_PreviousColorVisibleVerticalSubject.ElementInstance;
		}
		set
		{
			_PreviousColorVisibleVerticalSubject.ElementInstance = value;
		}
	}

	private VisualState PreviousColorCollapsedHorizontal
	{
		get
		{
			return (VisualState)_PreviousColorCollapsedHorizontalSubject.ElementInstance;
		}
		set
		{
			_PreviousColorCollapsedHorizontalSubject.ElementInstance = value;
		}
	}

	private VisualState PreviousColorVisibleHorizontal
	{
		get
		{
			return (VisualState)_PreviousColorVisibleHorizontalSubject.ElementInstance;
		}
		set
		{
			_PreviousColorVisibleHorizontalSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PreviousColorVisibility
	{
		get
		{
			return (VisualStateGroup)_PreviousColorVisibilitySubject.ElementInstance;
		}
		set
		{
			_PreviousColorVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState ThirdDimensionSliderVisible
	{
		get
		{
			return (VisualState)_ThirdDimensionSliderVisibleSubject.ElementInstance;
		}
		set
		{
			_ThirdDimensionSliderVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState ThirdDimensionSliderCollapsed
	{
		get
		{
			return (VisualState)_ThirdDimensionSliderCollapsedSubject.ElementInstance;
		}
		set
		{
			_ThirdDimensionSliderCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ThirdDimensionSliderVisibility
	{
		get
		{
			return (VisualStateGroup)_ThirdDimensionSliderVisibilitySubject.ElementInstance;
		}
		set
		{
			_ThirdDimensionSliderVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState AlphaSliderVisible
	{
		get
		{
			return (VisualState)_AlphaSliderVisibleSubject.ElementInstance;
		}
		set
		{
			_AlphaSliderVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState AlphaSliderCollapsed
	{
		get
		{
			return (VisualState)_AlphaSliderCollapsedSubject.ElementInstance;
		}
		set
		{
			_AlphaSliderCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup AlphaSliderVisibility
	{
		get
		{
			return (VisualStateGroup)_AlphaSliderVisibilitySubject.ElementInstance;
		}
		set
		{
			_AlphaSliderVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState MoreButtonVisible
	{
		get
		{
			return (VisualState)_MoreButtonVisibleSubject.ElementInstance;
		}
		set
		{
			_MoreButtonVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState MoreButtonCollapsed
	{
		get
		{
			return (VisualState)_MoreButtonCollapsedSubject.ElementInstance;
		}
		set
		{
			_MoreButtonCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup MoreButtonVisibility
	{
		get
		{
			return (VisualStateGroup)_MoreButtonVisibilitySubject.ElementInstance;
		}
		set
		{
			_MoreButtonVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState TextEntryGridCollapsed
	{
		get
		{
			return (VisualState)_TextEntryGridCollapsedSubject.ElementInstance;
		}
		set
		{
			_TextEntryGridCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState TextEntryGridVisible
	{
		get
		{
			return (VisualState)_TextEntryGridVisibleSubject.ElementInstance;
		}
		set
		{
			_TextEntryGridVisibleSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup TextEntryGridVisibility
	{
		get
		{
			return (VisualStateGroup)_TextEntryGridVisibilitySubject.ElementInstance;
		}
		set
		{
			_TextEntryGridVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState ColorChannelTextInputVisible
	{
		get
		{
			return (VisualState)_ColorChannelTextInputVisibleSubject.ElementInstance;
		}
		set
		{
			_ColorChannelTextInputVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState ColorChannelTextInputCollapsed
	{
		get
		{
			return (VisualState)_ColorChannelTextInputCollapsedSubject.ElementInstance;
		}
		set
		{
			_ColorChannelTextInputCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ColorChannelTextInputVisibility
	{
		get
		{
			return (VisualStateGroup)_ColorChannelTextInputVisibilitySubject.ElementInstance;
		}
		set
		{
			_ColorChannelTextInputVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState AlphaTextInputVisible
	{
		get
		{
			return (VisualState)_AlphaTextInputVisibleSubject.ElementInstance;
		}
		set
		{
			_AlphaTextInputVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState AlphaTextInputCollapsed
	{
		get
		{
			return (VisualState)_AlphaTextInputCollapsedSubject.ElementInstance;
		}
		set
		{
			_AlphaTextInputCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup AlphaTextInputVisibility
	{
		get
		{
			return (VisualStateGroup)_AlphaTextInputVisibilitySubject.ElementInstance;
		}
		set
		{
			_AlphaTextInputVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState RgbSelected
	{
		get
		{
			return (VisualState)_RgbSelectedSubject.ElementInstance;
		}
		set
		{
			_RgbSelectedSubject.ElementInstance = value;
		}
	}

	private VisualState HsvSelected
	{
		get
		{
			return (VisualState)_HsvSelectedSubject.ElementInstance;
		}
		set
		{
			_HsvSelectedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ColorRepresentationSelected
	{
		get
		{
			return (VisualStateGroup)_ColorRepresentationSelectedSubject.ElementInstance;
		}
		set
		{
			_ColorRepresentationSelectedSubject.ElementInstance = value;
		}
	}

	private VisualState HexInputVisible
	{
		get
		{
			return (VisualState)_HexInputVisibleSubject.ElementInstance;
		}
		set
		{
			_HexInputVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState HexInputCollapsed
	{
		get
		{
			return (VisualState)_HexInputCollapsedSubject.ElementInstance;
		}
		set
		{
			_HexInputCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup HexInputVisibility
	{
		get
		{
			return (VisualStateGroup)_HexInputVisibilitySubject.ElementInstance;
		}
		set
		{
			_HexInputVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState AlphaDisabled
	{
		get
		{
			return (VisualState)_AlphaDisabledSubject.ElementInstance;
		}
		set
		{
			_AlphaDisabledSubject.ElementInstance = value;
		}
	}

	private VisualState AlphaEnabled
	{
		get
		{
			return (VisualState)_AlphaEnabledSubject.ElementInstance;
		}
		set
		{
			_AlphaEnabledSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup AlphaEnabledState
	{
		get
		{
			return (VisualStateGroup)_AlphaEnabledStateSubject.ElementInstance;
		}
		set
		{
			_AlphaEnabledStateSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_419)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		Grid obj = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)(__LinkerHints.Is_Microsoft_UI_Xaml_Controls_Primitives_ColorPickerSlider_Available ? "ColorPickerSliderStyle" : null)] = (__LinkerHints.Is_Microsoft_UI_Xaml_Controls_Primitives_ColorPickerSlider_Available ? new WeakResourceInitializer(__ResourceOwner_419, (object? __ResourceOwner_420) => new Style(typeof(Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider))
				{
					Setters = { (SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_420, (object? __ResourceOwner_422) => new ControlTemplate(__ResourceOwner_422, (object? __owner) => new _ColorPicker_b040c09ab0c1542acb928d53b00aa94f_UnoUI__Resources_ColorPicker_b040c09ab0c1542acb928d53b00aa94f_ColorPickerRDSC0ColorPickerRDSC1().Build(__owner))) }
				}) : null),
				[(object)"CheckerColorBrush"] = new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c0)
				{
					nameScope.RegisterName("CheckerColorBrush", c0);
					CheckerColorBrush = c0;
					ResourceResolverSingleton.Instance.ApplyResource(c0, SolidColorBrush.ColorProperty, "SystemListLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
					_component_0 = c0;
					NameScope.SetNameScope(_component_0, nameScope);
				})
			}
		};
		UIElementCollection children = obj.Children;
		StackPanel obj2 = new StackPanel
		{
			IsParsing = true,
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ColorSpectrumGrid",
					ColumnDefinitions = 
					{
						new ColumnDefinition(),
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						}
					},
					Children = 
					{
						(UIElement)new Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum
						{
							IsParsing = true,
							Name = "ColorSpectrum",
							MaxWidth = 336.0,
							MaxHeight = 336.0,
							MinWidth = 256.0,
							MinHeight = 256.0
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum c2)
						{
							nameScope.RegisterName("ColorSpectrum", c2);
							ColorSpectrum = c2;
							Grid.SetColumn(c2, 0);
							Grid.SetRow(c2, 0);
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.MinHueProperty, new Binding
							{
								Path = "MinHue",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.MaxHueProperty, new Binding
							{
								Path = "MaxHue",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.MinSaturationProperty, new Binding
							{
								Path = "MinSaturation",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.MaxSaturationProperty, new Binding
							{
								Path = "MaxSaturation",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.MinValueProperty, new Binding
							{
								Path = "MinValue",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.MaxValueProperty, new Binding
							{
								Path = "MaxValue",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.ShapeProperty, new Binding
							{
								Path = "ColorSpectrumShape",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Microsoft.UI.Xaml.Controls.Primitives.ColorSpectrum.ComponentsProperty, new Binding
							{
								Path = "ColorSpectrumComponents",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(Control.CornerRadiusProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "ColorPreviewRectangleGrid",
							Width = 44.0,
							Margin = new Thickness(12.0, 0.0, 0.0, 0.0),
							RowDefinitions = 
							{
								new RowDefinition(),
								new RowDefinition()
							},
							ColumnDefinitions = 
							{
								new ColumnDefinition(),
								new ColumnDefinition()
							},
							Children = 
							{
								(UIElement)new Rectangle
								{
									IsParsing = true,
									VerticalAlignment = VerticalAlignment.Stretch,
									Fill = new ImageBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ImageBrush c3)
									{
										nameScope.RegisterName("ColorPreviewRectangleCheckeredBackgroundImageBrush", c3);
										ColorPreviewRectangleCheckeredBackgroundImageBrush = c3;
									})
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c4)
								{
									Grid.SetColumnSpan(c4, 2);
									Grid.SetRowSpan(c4, 2);
									c4.SetBinding(Rectangle.RadiusXProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c4.SetBinding(Rectangle.RadiusYProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c4.CreationComplete();
								}),
								(UIElement)new Rectangle
								{
									IsParsing = true,
									Name = "ColorPreviewRectangle",
									VerticalAlignment = VerticalAlignment.Stretch
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c5)
								{
									nameScope.RegisterName("ColorPreviewRectangle", c5);
									ColorPreviewRectangle = c5;
									Grid.SetColumnSpan(c5, 2);
									Grid.SetRowSpan(c5, 2);
									c5.SetBinding(Rectangle.RadiusXProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c5.SetBinding(Rectangle.RadiusYProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c5.CreationComplete();
								}),
								(UIElement)new Rectangle
								{
									IsParsing = true,
									Name = "PreviousColorRectangle",
									VerticalAlignment = VerticalAlignment.Stretch,
									Visibility = Visibility.Collapsed
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c6)
								{
									nameScope.RegisterName("PreviousColorRectangle", c6);
									PreviousColorRectangle = c6;
									Grid.SetColumnSpan(c6, 2);
									Grid.SetRow(c6, 1);
									c6.SetBinding(Rectangle.RadiusXProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c6.SetBinding(Rectangle.RadiusYProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c6.CreationComplete();
								}),
								(UIElement)new Rectangle
								{
									IsParsing = true,
									Name = "BorderRectangle"
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c7)
								{
									nameScope.RegisterName("BorderRectangle", c7);
									BorderRectangle = c7;
									ResourceResolverSingleton.Instance.ApplyResource(c7, FrameworkElement.StyleProperty, "ColorPickerBorderStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
									Grid.SetRowSpan(c7, 2);
									Grid.SetColumnSpan(c7, 2);
									c7.SetBinding(Rectangle.RadiusXProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									c7.SetBinding(Rectangle.RadiusYProperty, new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
									});
									_component_1 = c7;
									c7.CreationComplete();
								})
							}
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c8)
						{
							nameScope.RegisterName("ColorPreviewRectangleGrid", c8);
							ColorPreviewRectangleGrid = c8;
							Grid.SetColumn(c8, 1);
							Grid.SetRow(c8, 0);
							c8.CreationComplete();
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c9)
				{
					nameScope.RegisterName("ColorSpectrumGrid", c9);
					ColorSpectrumGrid = c9;
					c9.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ThirdDimensionSliderGrid",
					Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
					Children = 
					{
						(UIElement)new Rectangle
						{
							IsParsing = true,
							Height = 11.0,
							VerticalAlignment = VerticalAlignment.Center,
							Fill = new LinearGradientBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(LinearGradientBrush c10)
							{
								nameScope.RegisterName("ThirdDimensionSliderGradientBrush", c10);
								ThirdDimensionSliderGradientBrush = c10;
							})
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c11)
						{
							c11.SetBinding(Rectangle.RadiusXProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
							});
							c11.SetBinding(Rectangle.RadiusYProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
							});
							c11.CreationComplete();
						}),
						(UIElement)new Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider
						{
							IsParsing = true,
							Name = "ThirdDimensionSlider",
							Minimum = 0.0,
							Maximum = 100.0,
							ColorChannel = Microsoft.UI.Xaml.Controls.ColorPickerHsvChannel.Value,
							IsThumbToolTipEnabled = false
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider c12)
						{
							nameScope.RegisterName("ThirdDimensionSlider", c12);
							ThirdDimensionSlider = c12;
							ResourceResolverSingleton.Instance.ApplyResource(c12, FrameworkElement.StyleProperty, "ColorPickerSliderStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
							_component_2 = c12;
							c12.CreationComplete();
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c13)
				{
					nameScope.RegisterName("ThirdDimensionSliderGrid", c13);
					ThirdDimensionSliderGrid = c13;
					c13.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "AlphaSliderGrid",
					Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
					Children = 
					{
						(UIElement)new Rectangle
						{
							IsParsing = true,
							Height = 11.0,
							VerticalAlignment = VerticalAlignment.Center,
							Fill = new ImageBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ImageBrush c14)
							{
								nameScope.RegisterName("AlphaSliderCheckeredBackgroundImageBrush", c14);
								AlphaSliderCheckeredBackgroundImageBrush = c14;
							})
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c15)
						{
							c15.SetBinding(Rectangle.RadiusXProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
							});
							c15.SetBinding(Rectangle.RadiusYProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
							});
							c15.CreationComplete();
						}),
						(UIElement)new Rectangle
						{
							IsParsing = true,
							Name = "AlphaSliderBackgroundRectangle",
							Height = 11.0,
							VerticalAlignment = VerticalAlignment.Center,
							Fill = new LinearGradientBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(LinearGradientBrush c16)
							{
								nameScope.RegisterName("AlphaSliderGradientBrush", c16);
								AlphaSliderGradientBrush = c16;
							})
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Rectangle c17)
						{
							nameScope.RegisterName("AlphaSliderBackgroundRectangle", c17);
							AlphaSliderBackgroundRectangle = c17;
							c17.SetBinding(Rectangle.RadiusXProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
							});
							c17.SetBinding(Rectangle.RadiusYProperty, new Binding
							{
								Path = "CornerRadius",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_)
							});
							c17.CreationComplete();
						}),
						(UIElement)new Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider
						{
							IsParsing = true,
							Name = "AlphaSlider",
							Minimum = 0.0,
							Maximum = 100.0,
							ColorChannel = Microsoft.UI.Xaml.Controls.ColorPickerHsvChannel.Alpha,
							IsThumbToolTipEnabled = false
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Microsoft.UI.Xaml.Controls.Primitives.ColorPickerSlider c18)
						{
							nameScope.RegisterName("AlphaSlider", c18);
							AlphaSlider = c18;
							ResourceResolverSingleton.Instance.ApplyResource(c18, FrameworkElement.StyleProperty, "ColorPickerSliderStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
							_component_3 = c18;
							c18.CreationComplete();
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c19)
				{
					nameScope.RegisterName("AlphaSliderGrid", c19);
					AlphaSliderGrid = c19;
					c19.CreationComplete();
				})
			}
		};
		UIElementCollection children2 = obj2.Children;
		ToggleButton toggleButton = new ToggleButton();
		toggleButton.IsParsing = true;
		object key3 = "Default";
		toggleButton.Resources.ThemeDictionaries[key3] = new WeakResourceInitializer(__ResourceOwner_419, (object? __ResourceOwner_616) => new ResourceDictionary
		{
			IsSystemDictionary = true,
			["ToggleButtonBackground"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_617) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrush"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_619) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForeground"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_622) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c22)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c22, SolidColorBrush.ColorProperty, "SystemBaseHighColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_4 = c22;
				NameScope.SetNameScope(_component_4, nameScope);
			})),
			["ToggleButtonBackgroundPointerOver"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_624) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushPointerOver"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_626) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundPointerOver"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_628) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c25)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c25, SolidColorBrush.ColorProperty, "SystemBaseMediumColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_5 = c25;
				NameScope.SetNameScope(_component_5, nameScope);
			})),
			["ToggleButtonBackgroundPressed"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_630) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushPressed"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_633) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundPressed"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_635) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c28)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c28, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_6 = c28;
				NameScope.SetNameScope(_component_6, nameScope);
			})),
			["ToggleButtonBackgroundDisabled"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_637) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushDisabled"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_639) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundDisabled"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_641) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c31)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c31, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_7 = c31;
				NameScope.SetNameScope(_component_7, nameScope);
			})),
			["ToggleButtonBackgroundChecked"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_643) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushChecked"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_645) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundChecked"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_647) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c34)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c34, SolidColorBrush.ColorProperty, "SystemBaseHighColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_8 = c34;
				NameScope.SetNameScope(_component_8, nameScope);
			})),
			["ToggleButtonBackgroundCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_649) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_651) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_653) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c37)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c37, SolidColorBrush.ColorProperty, "SystemBaseMediumColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_9 = c37;
				NameScope.SetNameScope(_component_9, nameScope);
			})),
			["ToggleButtonBackgroundCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_655) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_657) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_658) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c40)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c40, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_10 = c40;
				NameScope.SetNameScope(_component_10, nameScope);
			})),
			["ToggleButtonBackgroundCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_661) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_663) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_616, (object? __ResourceOwner_665) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c43)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c43, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_11 = c43;
				NameScope.SetNameScope(_component_11, nameScope);
			}))
		});
		object key4 = "HighContrast";
		toggleButton.Resources.ThemeDictionaries[key4] = new WeakResourceInitializer(__ResourceOwner_419, (object? __ResourceOwner_667) => new ResourceDictionary
		{
			IsSystemDictionary = true,
			["ToggleButtonBackground"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_668) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrush"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_670) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c45)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c45, SolidColorBrush.ColorProperty, "SystemColorButtonTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_12 = c45;
				NameScope.SetNameScope(_component_12, nameScope);
			})),
			["ToggleButtonForeground"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_672) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c46)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c46, SolidColorBrush.ColorProperty, "SystemColorButtonTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_13 = c46;
				NameScope.SetNameScope(_component_13, nameScope);
			})),
			["ToggleButtonBackgroundPointerOver"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_674) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushPointerOver"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_676) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c48)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c48, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_14 = c48;
				NameScope.SetNameScope(_component_14, nameScope);
			})),
			["ToggleButtonForegroundPointerOver"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_678) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c49)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c49, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_15 = c49;
				NameScope.SetNameScope(_component_15, nameScope);
			})),
			["ToggleButtonBackgroundPressed"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_681) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushPressed"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_683) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c51)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c51, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_16 = c51;
				NameScope.SetNameScope(_component_16, nameScope);
			})),
			["ToggleButtonForegroundPressed"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_685) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c52)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c52, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_17 = c52;
				NameScope.SetNameScope(_component_17, nameScope);
			})),
			["ToggleButtonBackgroundDisabled"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_687) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushDisabled"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_689) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c54)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c54, SolidColorBrush.ColorProperty, "SystemColorGrayTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_18 = c54;
				NameScope.SetNameScope(_component_18, nameScope);
			})),
			["ToggleButtonForegroundDisabled"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_691) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c55)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c55, SolidColorBrush.ColorProperty, "SystemColorGrayTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_19 = c55;
				NameScope.SetNameScope(_component_19, nameScope);
			})),
			["ToggleButtonBackgroundChecked"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_693) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushChecked"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_695) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c57)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c57, SolidColorBrush.ColorProperty, "SystemColorButtonTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_20 = c57;
				NameScope.SetNameScope(_component_20, nameScope);
			})),
			["ToggleButtonForegroundChecked"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_699) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c58)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c58, SolidColorBrush.ColorProperty, "SystemColorButtonTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_21 = c58;
				NameScope.SetNameScope(_component_21, nameScope);
			})),
			["ToggleButtonBackgroundCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_703) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_705) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c60)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c60, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_22 = c60;
				NameScope.SetNameScope(_component_22, nameScope);
			})),
			["ToggleButtonForegroundCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_707) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c61)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c61, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_23 = c61;
				NameScope.SetNameScope(_component_23, nameScope);
			})),
			["ToggleButtonBackgroundCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_709) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_711) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c63)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c63, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_24 = c63;
				NameScope.SetNameScope(_component_24, nameScope);
			})),
			["ToggleButtonForegroundCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_713) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c64)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c64, SolidColorBrush.ColorProperty, "SystemColorHighlightColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_25 = c64;
				NameScope.SetNameScope(_component_25, nameScope);
			})),
			["ToggleButtonBackgroundCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_715) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_717) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c66)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c66, SolidColorBrush.ColorProperty, "SystemColorGrayTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_26 = c66;
				NameScope.SetNameScope(_component_26, nameScope);
			})),
			["ToggleButtonForegroundCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_667, (object? __ResourceOwner_719) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c67)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c67, SolidColorBrush.ColorProperty, "SystemColorGrayTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_27 = c67;
				NameScope.SetNameScope(_component_27, nameScope);
			}))
		});
		object key5 = "Light";
		toggleButton.Resources.ThemeDictionaries[key5] = new WeakResourceInitializer(__ResourceOwner_419, (object? __ResourceOwner_723) => new ResourceDictionary
		{
			IsSystemDictionary = true,
			["ToggleButtonBackground"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_725) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrush"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_727) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForeground"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_729) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c70)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c70, SolidColorBrush.ColorProperty, "SystemBaseHighColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_28 = c70;
				NameScope.SetNameScope(_component_28, nameScope);
			})),
			["ToggleButtonBackgroundPointerOver"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_731) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushPointerOver"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_733) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundPointerOver"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_735) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c73)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c73, SolidColorBrush.ColorProperty, "SystemBaseMediumColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_29 = c73;
				NameScope.SetNameScope(_component_29, nameScope);
			})),
			["ToggleButtonBackgroundPressed"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_737) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushPressed"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_739) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundPressed"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_740) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c76)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c76, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_30 = c76;
				NameScope.SetNameScope(_component_30, nameScope);
			})),
			["ToggleButtonBackgroundDisabled"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_742) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushDisabled"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_744) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundDisabled"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_746) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c79)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c79, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_31 = c79;
				NameScope.SetNameScope(_component_31, nameScope);
			})),
			["ToggleButtonBackgroundChecked"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_748) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushChecked"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_751) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundChecked"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_753) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c82)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c82, SolidColorBrush.ColorProperty, "SystemBaseHighColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_32 = c82;
				NameScope.SetNameScope(_component_32, nameScope);
			})),
			["ToggleButtonBackgroundCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_755) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_758) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundCheckedPointerOver"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_760) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c85)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c85, SolidColorBrush.ColorProperty, "SystemBaseMediumColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_33 = c85;
				NameScope.SetNameScope(_component_33, nameScope);
			})),
			["ToggleButtonBackgroundCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_763) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_765) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundCheckedPressed"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_767) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c88)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c88, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_34 = c88;
				NameScope.SetNameScope(_component_34, nameScope);
			})),
			["ToggleButtonBackgroundCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_769) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonBorderBrushCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_771) => new SolidColorBrush
			{
				Color = Colors.Transparent
			}),
			["ToggleButtonForegroundCheckedDisabled"] = new WeakResourceInitializer(__ResourceOwner_723, (object? __ResourceOwner_772) => new SolidColorBrush().ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(SolidColorBrush c91)
			{
				ResourceResolverSingleton.Instance.ApplyResource(c91, SolidColorBrush.ColorProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
				_component_35 = c91;
				NameScope.SetNameScope(_component_35, nameScope);
			}))
		});
		toggleButton.Name = "MoreButton";
		toggleButton.MinHeight = 32.0;
		toggleButton.MinWidth = 120.0;
		toggleButton.Margin = new Thickness(0.0, 12.0, 0.0, 0.0);
		toggleButton.Padding = new Thickness(0.0);
		toggleButton.HorizontalAlignment = HorizontalAlignment.Right;
		toggleButton.HorizontalContentAlignment = HorizontalAlignment.Right;
		toggleButton.Content = new StackPanel
		{
			IsParsing = true,
			Orientation = Orientation.Horizontal,
			HorizontalAlignment = HorizontalAlignment.Right,
			Margin = new Thickness(0.0, 5.0, 0.0, 7.0),
			Children = 
			{
				(UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "MoreButtonLabel",
					VerticalAlignment = VerticalAlignment.Center
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c92)
				{
					nameScope.RegisterName("MoreButtonLabel", c92);
					MoreButtonLabel = c92;
					c92.CreationComplete();
				}),
				(UIElement)new FontIcon
				{
					IsParsing = true,
					Name = "MoreGlyph",
					Margin = new Thickness(8.0, 0.0, 0.0, 0.0),
					Glyph = "\ue70d",
					FontSize = 12.0
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(FontIcon c93)
				{
					nameScope.RegisterName("MoreGlyph", c93);
					MoreGlyph = c93;
					ResourceResolverSingleton.Instance.ApplyResource(c93, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__3.Instance.__ParseContext_);
					_component_36 = c93;
					c93.CreationComplete();
				})
			}
		}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c94)
		{
			c94.CreationComplete();
		});
		children2.Add(toggleButton.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ToggleButton c95)
		{
			nameScope.RegisterName("MoreButton", c95);
			MoreButton = c95;
			c95.CreationComplete();
		}));
		obj2.Children.Add(new Grid
		{
			IsParsing = true,
			Name = "TextEntryGrid",
			Visibility = Visibility.Collapsed,
			ColumnDefinitions = 
			{
				new ColumnDefinition(),
				new ColumnDefinition()
			},
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
				(UIElement)new ComboBox
				{
					IsParsing = true,
					Name = "ColorRepresentationComboBox",
					Width = 120.0,
					Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
					Items = 
					{
						(object)new ComboBoxItem
						{
							IsParsing = true,
							Name = "RGBComboBoxItem",
							Content = "RGB",
							IsSelected = true
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ComboBoxItem c98)
						{
							nameScope.RegisterName("RGBComboBoxItem", c98);
							RGBComboBoxItem = c98;
							c98.CreationComplete();
						}),
						(object)new ComboBoxItem
						{
							IsParsing = true,
							Name = "HSVComboBoxItem",
							Content = "HSV"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ComboBoxItem c99)
						{
							nameScope.RegisterName("HSVComboBoxItem", c99);
							HSVComboBoxItem = c99;
							c99.CreationComplete();
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(ComboBox c100)
				{
					nameScope.RegisterName("ColorRepresentationComboBox", c100);
					ColorRepresentationComboBox = c100;
					Grid.SetRow(c100, 0);
					c100.CreationComplete();
				}),
				(UIElement)new StackPanel
				{
					IsParsing = true,
					Children = 
					{
						(UIElement)new StackPanel
						{
							IsParsing = true,
							Name = "ColorChannelTextInputPanel",
							Children = 
							{
								(UIElement)new StackPanel
								{
									IsParsing = true,
									Name = "RgbPanel",
									Children = 
									{
										(UIElement)new StackPanel
										{
											IsParsing = true,
											Orientation = Orientation.Horizontal,
											Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
											Children = 
											{
												(UIElement)new TextBox
												{
													IsParsing = true,
													Name = "RedTextBox",
													Width = 120.0,
													MaxLength = 3,
													Text = "255"
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c101)
												{
													nameScope.RegisterName("RedTextBox", c101);
													RedTextBox = c101;
													c101.CreationComplete();
												}),
												(UIElement)new TextBlock
												{
													IsParsing = true,
													Name = "RedLabel",
													Text = "Red",
													VerticalAlignment = VerticalAlignment.Center,
													Margin = new Thickness(8.0, 0.0, 0.0, 0.0)
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c102)
												{
													nameScope.RegisterName("RedLabel", c102);
													RedLabel = c102;
													c102.CreationComplete();
												})
											}
										}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c103)
										{
											c103.CreationComplete();
										}),
										(UIElement)new StackPanel
										{
											IsParsing = true,
											Orientation = Orientation.Horizontal,
											Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
											Children = 
											{
												(UIElement)new TextBox
												{
													IsParsing = true,
													Name = "GreenTextBox",
													Width = 120.0,
													MaxLength = 3,
													Text = "255"
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c104)
												{
													nameScope.RegisterName("GreenTextBox", c104);
													GreenTextBox = c104;
													c104.CreationComplete();
												}),
												(UIElement)new TextBlock
												{
													IsParsing = true,
													Name = "GreenLabel",
													Text = "Green",
													VerticalAlignment = VerticalAlignment.Center,
													Margin = new Thickness(8.0, 0.0, 0.0, 0.0)
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c105)
												{
													nameScope.RegisterName("GreenLabel", c105);
													GreenLabel = c105;
													c105.CreationComplete();
												})
											}
										}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c106)
										{
											c106.CreationComplete();
										}),
										(UIElement)new StackPanel
										{
											IsParsing = true,
											Orientation = Orientation.Horizontal,
											Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
											Children = 
											{
												(UIElement)new TextBox
												{
													IsParsing = true,
													Name = "BlueTextBox",
													Width = 120.0,
													MaxLength = 3,
													Text = "255"
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c107)
												{
													nameScope.RegisterName("BlueTextBox", c107);
													BlueTextBox = c107;
													c107.CreationComplete();
												}),
												(UIElement)new TextBlock
												{
													IsParsing = true,
													Name = "BlueLabel",
													Text = "Blue",
													VerticalAlignment = VerticalAlignment.Center,
													Margin = new Thickness(8.0, 0.0, 0.0, 0.0)
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c108)
												{
													nameScope.RegisterName("BlueLabel", c108);
													BlueLabel = c108;
													c108.CreationComplete();
												})
											}
										}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c109)
										{
											c109.CreationComplete();
										})
									}
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c110)
								{
									nameScope.RegisterName("RgbPanel", c110);
									RgbPanel = c110;
									c110.CreationComplete();
								}),
								(UIElement)new StackPanel
								{
									IsParsing = true,
									Name = "HsvPanel",
									Visibility = Visibility.Collapsed,
									Children = 
									{
										(UIElement)new StackPanel
										{
											IsParsing = true,
											Orientation = Orientation.Horizontal,
											Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
											Children = 
											{
												(UIElement)new TextBox
												{
													IsParsing = true,
													Name = "HueTextBox",
													Width = 120.0,
													MaxLength = 3,
													Text = "0"
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c111)
												{
													nameScope.RegisterName("HueTextBox", c111);
													HueTextBox = c111;
													c111.CreationComplete();
												}),
												(UIElement)new TextBlock
												{
													IsParsing = true,
													Name = "HueLabel",
													Text = "Hue",
													VerticalAlignment = VerticalAlignment.Center,
													Margin = new Thickness(8.0, 0.0, 0.0, 0.0)
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c112)
												{
													nameScope.RegisterName("HueLabel", c112);
													HueLabel = c112;
													c112.CreationComplete();
												})
											}
										}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c113)
										{
											c113.CreationComplete();
										}),
										(UIElement)new StackPanel
										{
											IsParsing = true,
											Orientation = Orientation.Horizontal,
											Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
											Children = 
											{
												(UIElement)new TextBox
												{
													IsParsing = true,
													Name = "SaturationTextBox",
													Width = 120.0,
													MaxLength = 3,
													Text = "0"
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c114)
												{
													nameScope.RegisterName("SaturationTextBox", c114);
													SaturationTextBox = c114;
													c114.CreationComplete();
												}),
												(UIElement)new TextBlock
												{
													IsParsing = true,
													Name = "SaturationLabel",
													Text = "Saturation",
													VerticalAlignment = VerticalAlignment.Center,
													Margin = new Thickness(8.0, 0.0, 0.0, 0.0)
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c115)
												{
													nameScope.RegisterName("SaturationLabel", c115);
													SaturationLabel = c115;
													c115.CreationComplete();
												})
											}
										}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c116)
										{
											c116.CreationComplete();
										}),
										(UIElement)new StackPanel
										{
											IsParsing = true,
											Orientation = Orientation.Horizontal,
											Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
											Children = 
											{
												(UIElement)new TextBox
												{
													IsParsing = true,
													Name = "ValueTextBox",
													Width = 120.0,
													MaxLength = 3,
													Text = "100"
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c117)
												{
													nameScope.RegisterName("ValueTextBox", c117);
													ValueTextBox = c117;
													c117.CreationComplete();
												}),
												(UIElement)new TextBlock
												{
													IsParsing = true,
													Name = "ValueLabel",
													Text = "Value",
													VerticalAlignment = VerticalAlignment.Center,
													Margin = new Thickness(8.0, 0.0, 0.0, 0.0)
												}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c118)
												{
													nameScope.RegisterName("ValueLabel", c118);
													ValueLabel = c118;
													c118.CreationComplete();
												})
											}
										}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c119)
										{
											c119.CreationComplete();
										})
									}
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c120)
								{
									nameScope.RegisterName("HsvPanel", c120);
									HsvPanel = c120;
									Grid.SetRow(c120, 1);
									c120.CreationComplete();
								})
							}
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c121)
						{
							nameScope.RegisterName("ColorChannelTextInputPanel", c121);
							ColorChannelTextInputPanel = c121;
							c121.CreationComplete();
						}),
						(UIElement)new StackPanel
						{
							IsParsing = true,
							Name = "AlphaPanel",
							Orientation = Orientation.Horizontal,
							Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
							Children = 
							{
								(UIElement)new TextBox
								{
									IsParsing = true,
									Name = "AlphaTextBox",
									Width = 120.0,
									MaxLength = 4,
									Text = "100%"
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c122)
								{
									nameScope.RegisterName("AlphaTextBox", c122);
									AlphaTextBox = c122;
									c122.CreationComplete();
								}),
								(UIElement)new TextBlock
								{
									IsParsing = true,
									Name = "AlphaLabel",
									Text = "Opacity",
									VerticalAlignment = VerticalAlignment.Center,
									Margin = new Thickness(8.0, 0.0, 0.0, 0.0)
								}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBlock c123)
								{
									nameScope.RegisterName("AlphaLabel", c123);
									AlphaLabel = c123;
									c123.CreationComplete();
								})
							}
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c124)
						{
							nameScope.RegisterName("AlphaPanel", c124);
							AlphaPanel = c124;
							c124.CreationComplete();
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c125)
				{
					Grid.SetRow(c125, 1);
					Grid.SetColumnSpan(c125, 2);
					c125.CreationComplete();
				}),
				(UIElement)new TextBox
				{
					IsParsing = true,
					Name = "HexTextBox",
					MaxLength = 7,
					Text = "#FFFFFF",
					Margin = new Thickness(0.0, 12.0, 0.0, 0.0),
					Width = 132.0,
					HorizontalAlignment = HorizontalAlignment.Right,
					VerticalAlignment = VerticalAlignment.Top
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(TextBox c126)
				{
					nameScope.RegisterName("HexTextBox", c126);
					HexTextBox = c126;
					Grid.SetColumn(c126, 1);
					c126.CreationComplete();
				})
			}
		}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c127)
		{
			nameScope.RegisterName("TextEntryGrid", c127);
			TextEntryGrid = c127;
			c127.CreationComplete();
		}));
		children.Add(obj2.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(StackPanel c128)
		{
			c128.CreationComplete();
		}));
		uIElement = obj.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(Grid c129)
		{
			c129.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c129, new VisualStateGroup[12]
			{
				new VisualStateGroup
				{
					Name = "ColorSpectrumVisibility",
					States = 
					{
						new VisualState
						{
							Name = "ColorSpectrumVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c130)
						{
							nameScope.RegisterName("ColorSpectrumVisible", c130);
							ColorSpectrumVisible = c130;
						}),
						new VisualState
						{
							Name = "ColorSpectrumCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c131)
						{
							nameScope.RegisterName("ColorSpectrumCollapsed", c131);
							ColorSpectrumCollapsed = c131;
							MarkupHelper.SetVisualStateLazy(c131, delegate
							{
								c131.Name = "ColorSpectrumCollapsed";
								c131.Setters.Add(new Setter(new TargetPropertyPath(_ColorSpectrumSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c131.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleGridSubject, (PropertyPath)"Width"), "NaN"));
								c131.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleGridSubject, (PropertyPath)"Height"), "44"));
								c131.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleGridSubject, (PropertyPath)"Margin"), "0"));
								c131.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleGridSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
								c131.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleGridSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c132)
				{
					nameScope.RegisterName("ColorSpectrumVisibility", c132);
					ColorSpectrumVisibility = c132;
				}),
				new VisualStateGroup
				{
					Name = "ColorPreviewVisibility",
					States = 
					{
						new VisualState
						{
							Name = "ColorPreviewVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c133)
						{
							nameScope.RegisterName("ColorPreviewVisible", c133);
							ColorPreviewVisible = c133;
						}),
						new VisualState
						{
							Name = "ColorPreviewCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c134)
						{
							nameScope.RegisterName("ColorPreviewCollapsed", c134);
							ColorPreviewCollapsed = c134;
							MarkupHelper.SetVisualStateLazy(c134, delegate
							{
								c134.Name = "ColorPreviewCollapsed";
								c134.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleGridSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c135)
				{
					nameScope.RegisterName("ColorPreviewVisibility", c135);
					ColorPreviewVisibility = c135;
				}),
				new VisualStateGroup
				{
					Name = "PreviousColorVisibility",
					States = 
					{
						new VisualState
						{
							Name = "PreviousColorCollapsedVertical"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c136)
						{
							nameScope.RegisterName("PreviousColorCollapsedVertical", c136);
							PreviousColorCollapsedVertical = c136;
						}),
						new VisualState
						{
							Name = "PreviousColorVisibleVertical"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c137)
						{
							nameScope.RegisterName("PreviousColorVisibleVertical", c137);
							PreviousColorVisibleVertical = c137;
							MarkupHelper.SetVisualStateLazy(c137, delegate
							{
								c137.Name = "PreviousColorVisibleVertical";
								c137.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.RowSpan)"), "1"));
								c137.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						}),
						new VisualState
						{
							Name = "PreviousColorCollapsedHorizontal"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c138)
						{
							nameScope.RegisterName("PreviousColorCollapsedHorizontal", c138);
							PreviousColorCollapsedHorizontal = c138;
							MarkupHelper.SetVisualStateLazy(c138, delegate
							{
								c138.Name = "PreviousColorCollapsedHorizontal";
								c138.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "0"));
								c138.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "1"));
								c138.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.RowSpan)"), "2"));
								c138.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "1"));
							});
						}),
						new VisualState
						{
							Name = "PreviousColorVisibleHorizontal"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c139)
						{
							nameScope.RegisterName("PreviousColorVisibleHorizontal", c139);
							PreviousColorVisibleHorizontal = c139;
							MarkupHelper.SetVisualStateLazy(c139, delegate
							{
								c139.Name = "PreviousColorVisibleHorizontal";
								c139.Setters.Add(new Setter(new TargetPropertyPath(_ColorPreviewRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "1"));
								c139.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"Visibility"), "Visible"));
								c139.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "0"));
								c139.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "1"));
								c139.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.RowSpan)"), "2"));
								c139.Setters.Add(new Setter(new TargetPropertyPath(_PreviousColorRectangleSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "1"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c140)
				{
					nameScope.RegisterName("PreviousColorVisibility", c140);
					PreviousColorVisibility = c140;
				}),
				new VisualStateGroup
				{
					Name = "ThirdDimensionSliderVisibility",
					States = 
					{
						new VisualState
						{
							Name = "ThirdDimensionSliderVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c141)
						{
							nameScope.RegisterName("ThirdDimensionSliderVisible", c141);
							ThirdDimensionSliderVisible = c141;
						}),
						new VisualState
						{
							Name = "ThirdDimensionSliderCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c142)
						{
							nameScope.RegisterName("ThirdDimensionSliderCollapsed", c142);
							ThirdDimensionSliderCollapsed = c142;
							MarkupHelper.SetVisualStateLazy(c142, delegate
							{
								c142.Name = "ThirdDimensionSliderCollapsed";
								c142.Setters.Add(new Setter(new TargetPropertyPath(_ThirdDimensionSliderGridSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c143)
				{
					nameScope.RegisterName("ThirdDimensionSliderVisibility", c143);
					ThirdDimensionSliderVisibility = c143;
				}),
				new VisualStateGroup
				{
					Name = "AlphaSliderVisibility",
					States = 
					{
						new VisualState
						{
							Name = "AlphaSliderVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c144)
						{
							nameScope.RegisterName("AlphaSliderVisible", c144);
							AlphaSliderVisible = c144;
						}),
						new VisualState
						{
							Name = "AlphaSliderCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c145)
						{
							nameScope.RegisterName("AlphaSliderCollapsed", c145);
							AlphaSliderCollapsed = c145;
							MarkupHelper.SetVisualStateLazy(c145, delegate
							{
								c145.Name = "AlphaSliderCollapsed";
								c145.Setters.Add(new Setter(new TargetPropertyPath(_AlphaSliderGridSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c146)
				{
					nameScope.RegisterName("AlphaSliderVisibility", c146);
					AlphaSliderVisibility = c146;
				}),
				new VisualStateGroup
				{
					Name = "MoreButtonVisibility",
					States = 
					{
						new VisualState
						{
							Name = "MoreButtonVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c147)
						{
							nameScope.RegisterName("MoreButtonVisible", c147);
							MoreButtonVisible = c147;
						}),
						new VisualState
						{
							Name = "MoreButtonCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c148)
						{
							nameScope.RegisterName("MoreButtonCollapsed", c148);
							MoreButtonCollapsed = c148;
							MarkupHelper.SetVisualStateLazy(c148, delegate
							{
								c148.Name = "MoreButtonCollapsed";
								c148.Setters.Add(new Setter(new TargetPropertyPath(_MoreButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c149)
				{
					nameScope.RegisterName("MoreButtonVisibility", c149);
					MoreButtonVisibility = c149;
				}),
				new VisualStateGroup
				{
					Name = "TextEntryGridVisibility",
					States = 
					{
						new VisualState
						{
							Name = "TextEntryGridCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c150)
						{
							nameScope.RegisterName("TextEntryGridCollapsed", c150);
							TextEntryGridCollapsed = c150;
						}),
						new VisualState
						{
							Name = "TextEntryGridVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c151)
						{
							nameScope.RegisterName("TextEntryGridVisible", c151);
							TextEntryGridVisible = c151;
							MarkupHelper.SetVisualStateLazy(c151, delegate
							{
								c151.Name = "TextEntryGridVisible";
								c151.Setters.Add(new Setter(new TargetPropertyPath(_TextEntryGridSubject, (PropertyPath)"Visibility"), "Visible"));
								c151.Setters.Add(new Setter(new TargetPropertyPath(_MoreGlyphSubject, (PropertyPath)"Glyph"), "\ue70e"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c152)
				{
					nameScope.RegisterName("TextEntryGridVisibility", c152);
					TextEntryGridVisibility = c152;
				}),
				new VisualStateGroup
				{
					Name = "ColorChannelTextInputVisibility",
					States = 
					{
						new VisualState
						{
							Name = "ColorChannelTextInputVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c153)
						{
							nameScope.RegisterName("ColorChannelTextInputVisible", c153);
							ColorChannelTextInputVisible = c153;
						}),
						new VisualState
						{
							Name = "ColorChannelTextInputCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c154)
						{
							nameScope.RegisterName("ColorChannelTextInputCollapsed", c154);
							ColorChannelTextInputCollapsed = c154;
							MarkupHelper.SetVisualStateLazy(c154, delegate
							{
								c154.Name = "ColorChannelTextInputCollapsed";
								c154.Setters.Add(new Setter(new TargetPropertyPath(_ColorRepresentationComboBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c154.Setters.Add(new Setter(new TargetPropertyPath(_ColorChannelTextInputPanelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c154.Setters.Add(new Setter(new TargetPropertyPath(_HexTextBoxSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
								c154.Setters.Add(new Setter(new TargetPropertyPath(_HexTextBoxSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c155)
				{
					nameScope.RegisterName("ColorChannelTextInputVisibility", c155);
					ColorChannelTextInputVisibility = c155;
				}),
				new VisualStateGroup
				{
					Name = "AlphaTextInputVisibility",
					States = 
					{
						new VisualState
						{
							Name = "AlphaTextInputVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c156)
						{
							nameScope.RegisterName("AlphaTextInputVisible", c156);
							AlphaTextInputVisible = c156;
						}),
						new VisualState
						{
							Name = "AlphaTextInputCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c157)
						{
							nameScope.RegisterName("AlphaTextInputCollapsed", c157);
							AlphaTextInputCollapsed = c157;
							MarkupHelper.SetVisualStateLazy(c157, delegate
							{
								c157.Name = "AlphaTextInputCollapsed";
								c157.Setters.Add(new Setter(new TargetPropertyPath(_AlphaPanelSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c158)
				{
					nameScope.RegisterName("AlphaTextInputVisibility", c158);
					AlphaTextInputVisibility = c158;
				}),
				new VisualStateGroup
				{
					Name = "ColorRepresentationSelected",
					States = 
					{
						new VisualState
						{
							Name = "RgbSelected"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c159)
						{
							nameScope.RegisterName("RgbSelected", c159);
							RgbSelected = c159;
						}),
						new VisualState
						{
							Name = "HsvSelected"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c160)
						{
							nameScope.RegisterName("HsvSelected", c160);
							HsvSelected = c160;
							MarkupHelper.SetVisualStateLazy(c160, delegate
							{
								c160.Name = "HsvSelected";
								c160.Setters.Add(new Setter(new TargetPropertyPath(_RgbPanelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c160.Setters.Add(new Setter(new TargetPropertyPath(_HsvPanelSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c161)
				{
					nameScope.RegisterName("ColorRepresentationSelected", c161);
					ColorRepresentationSelected = c161;
				}),
				new VisualStateGroup
				{
					Name = "HexInputVisibility",
					States = 
					{
						new VisualState
						{
							Name = "HexInputVisible"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c162)
						{
							nameScope.RegisterName("HexInputVisible", c162);
							HexInputVisible = c162;
						}),
						new VisualState
						{
							Name = "HexInputCollapsed"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c163)
						{
							nameScope.RegisterName("HexInputCollapsed", c163);
							HexInputCollapsed = c163;
							MarkupHelper.SetVisualStateLazy(c163, delegate
							{
								c163.Name = "HexInputCollapsed";
								c163.Setters.Add(new Setter(new TargetPropertyPath(_HexTextBoxSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c164)
				{
					nameScope.RegisterName("HexInputVisibility", c164);
					HexInputVisibility = c164;
				}),
				new VisualStateGroup
				{
					Name = "AlphaEnabledState",
					States = 
					{
						new VisualState
						{
							Name = "AlphaDisabled"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c165)
						{
							nameScope.RegisterName("AlphaDisabled", c165);
							AlphaDisabled = c165;
						}),
						new VisualState
						{
							Name = "AlphaEnabled"
						}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualState c166)
						{
							nameScope.RegisterName("AlphaEnabled", c166);
							AlphaEnabled = c166;
							MarkupHelper.SetVisualStateLazy(c166, delegate
							{
								c166.Name = "AlphaEnabled";
								c166.Setters.Add(new Setter(new TargetPropertyPath(_HexTextBoxSubject, (PropertyPath)"MaxLength"), "9"));
							});
						})
					}
				}.ColorPicker_b040c09ab0c1542acb928d53b00aa94f_XamlApply(delegate(VisualStateGroup c167)
				{
					nameScope.RegisterName("AlphaEnabledState", c167);
					AlphaEnabledState = c167;
				})
			});
			c129.CreationComplete();
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
				_component_17.UpdateResourceBindings();
				_component_18.UpdateResourceBindings();
				_component_19.UpdateResourceBindings();
				_component_20.UpdateResourceBindings();
				_component_21.UpdateResourceBindings();
				_component_22.UpdateResourceBindings();
				_component_23.UpdateResourceBindings();
				_component_24.UpdateResourceBindings();
				_component_25.UpdateResourceBindings();
				_component_26.UpdateResourceBindings();
				_component_27.UpdateResourceBindings();
				_component_28.UpdateResourceBindings();
				_component_29.UpdateResourceBindings();
				_component_30.UpdateResourceBindings();
				_component_31.UpdateResourceBindings();
				_component_32.UpdateResourceBindings();
				_component_33.UpdateResourceBindings();
				_component_34.UpdateResourceBindings();
				_component_35.UpdateResourceBindings();
				_component_36.UpdateResourceBindings();
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

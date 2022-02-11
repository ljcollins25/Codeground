using System;
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
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_CalendarDatePicker_themeresourcesRDSC0
{
	private class _CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_UnoUI__Resources_CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_CalendarDatePicker_themeresourcesRDSC0CalendarDatePicker_themeresourcesRDSC1
	{
		public UIElement Build(object __ResourceOwner_265)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new ContentPresenter
			{
				IsParsing = true
			}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ContentPresenter c53)
			{
				c53.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
				{
					Path = "BorderBrush",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(ContentPresenter.ContentProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
				{
					Path = "ContentTemplate",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
				{
					Path = "ContentTransitions",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(FrameworkElement.MarginProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
				{
					Path = "CornerRadius",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c53.CreationComplete();
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

	private ElementNameSubject _HeaderContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _BackgroundSubject = new ElementNameSubject();

	private ElementNameSubject _DateTextSubject = new ElementNameSubject();

	private ElementNameSubject _CalendarGlyphSubject = new ElementNameSubject();

	private ElementNameSubject _DescriptionPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _UnfocusedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerFocusedSubject = new ElementNameSubject();

	private ElementNameSubject _FocusedSubject = new ElementNameSubject();

	private ElementNameSubject _FocusStatesSubject = new ElementNameSubject();

	private ElementNameSubject _UnselectedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectionStatesSubject = new ElementNameSubject();

	private ElementNameSubject _TopHeaderSubject = new ElementNameSubject();

	private ElementNameSubject _LeftHeaderSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderStatesSubject = new ElementNameSubject();

	private ElementNameSubject _CalendarViewSubject = new ElementNameSubject();

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

	private CalendarView _component_15
	{
		get
		{
			return (CalendarView)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
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

	private Border Background
	{
		get
		{
			return (Border)_BackgroundSubject.ElementInstance;
		}
		set
		{
			_BackgroundSubject.ElementInstance = value;
		}
	}

	private TextBlock DateText
	{
		get
		{
			return (TextBlock)_DateTextSubject.ElementInstance;
		}
		set
		{
			_DateTextSubject.ElementInstance = value;
		}
	}

	private FontIcon CalendarGlyph
	{
		get
		{
			return (FontIcon)_CalendarGlyphSubject.ElementInstance;
		}
		set
		{
			_CalendarGlyphSubject.ElementInstance = value;
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

	private Grid Root
	{
		get
		{
			return (Grid)_RootSubject.ElementInstance;
		}
		set
		{
			_RootSubject.ElementInstance = value;
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

	private VisualState Unselected
	{
		get
		{
			return (VisualState)_UnselectedSubject.ElementInstance;
		}
		set
		{
			_UnselectedSubject.ElementInstance = value;
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

	private VisualStateGroup SelectionStates
	{
		get
		{
			return (VisualStateGroup)_SelectionStatesSubject.ElementInstance;
		}
		set
		{
			_SelectionStatesSubject.ElementInstance = value;
		}
	}

	private VisualState TopHeader
	{
		get
		{
			return (VisualState)_TopHeaderSubject.ElementInstance;
		}
		set
		{
			_TopHeaderSubject.ElementInstance = value;
		}
	}

	private VisualState LeftHeader
	{
		get
		{
			return (VisualState)_LeftHeaderSubject.ElementInstance;
		}
		set
		{
			_LeftHeaderSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup HeaderStates
	{
		get
		{
			return (VisualStateGroup)_HeaderStatesSubject.ElementInstance;
		}
		set
		{
			_HeaderStatesSubject.ElementInstance = value;
		}
	}

	private CalendarView CalendarView
	{
		get
		{
			return (CalendarView)_CalendarViewSubject.ElementInstance;
		}
		set
		{
			_CalendarViewSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_244)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				},
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Star)
				},
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
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
				},
				new ColumnDefinition
				{
					Width = new GridLength(32.0, GridUnitType.Pixel)
				}
			},
			Children = 
			{
				(UIElement)new ElementStub(() => new ContentPresenter
				{
					IsParsing = true,
					Name = "HeaderContentPresenter",
					TextWrapping = TextWrapping.Wrap,
					VerticalAlignment = VerticalAlignment.Top,
					Visibility = Visibility.Collapsed
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ContentPresenter c6)
				{
					nameScope.RegisterName("HeaderContentPresenter", c6);
					HeaderContentPresenter = c6;
					Grid.SetRow(c6, 0);
					Grid.SetColumn(c6, 1);
					Grid.SetColumnSpan(c6, 2);
					c6.SetBinding(ContentPresenter.ContentProperty, new Binding
					{
						Path = "Header",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c6.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
					{
						Path = "HeaderTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c6, FrameworkElement.MarginProperty, "CalendarDatePickerTopHeaderMargin", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
					_component_0 = c6;
					c6.CreationComplete();
				})).CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ElementStub c7)
				{
					c7.Name = "HeaderContentPresenter";
					_HeaderContentPresenterSubject.ElementInstance = c7;
					c7.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "Background",
					MinHeight = 32.0
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(Border c8)
				{
					nameScope.RegisterName("Background", c8);
					Background = c8;
					Grid.SetRow(c8, 1);
					Grid.SetColumn(c8, 1);
					Grid.SetColumnSpan(c8, 2);
					c8.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c8.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c8.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c8.SetBinding(Border.CornerRadiusProperty, new Binding
					{
						Path = "CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					Control.SetIsTemplateFocusTarget(c8, value: true);
					c8.CreationComplete();
				}),
				(UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "DateText",
					HorizontalAlignment = HorizontalAlignment.Left,
					Padding = new Thickness(12.0, 0.0, 0.0, 2.0),
					VerticalAlignment = VerticalAlignment.Center
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(TextBlock c9)
				{
					nameScope.RegisterName("DateText", c9);
					DateText = c9;
					Grid.SetRow(c9, 1);
					Grid.SetColumn(c9, 1);
					ResourceResolverSingleton.Instance.ApplyResource(c9, TextBlock.ForegroundProperty, "CalendarDatePickerTextForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
					c9.SetBinding(TextBlock.TextProperty, new Binding
					{
						Path = "PlaceholderText",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_1 = c9;
					c9.CreationComplete();
				}),
				(UIElement)new FontIcon
				{
					IsParsing = true,
					Name = "CalendarGlyph",
					Glyph = "\ue787",
					FontSize = 12.0,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(FontIcon c10)
				{
					nameScope.RegisterName("CalendarGlyph", c10);
					CalendarGlyph = c10;
					Grid.SetRow(c10, 1);
					Grid.SetColumn(c10, 2);
					ResourceResolverSingleton.Instance.ApplyResource(c10, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c10, IconElement.ForegroundProperty, "CalendarDatePickerCalendarGlyphForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
					_component_2 = c10;
					c10.CreationComplete();
				}),
				(UIElement)new ElementStub(() => new ContentPresenter
				{
					IsParsing = true,
					Name = "DescriptionPresenter"
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ContentPresenter c11)
				{
					nameScope.RegisterName("DescriptionPresenter", c11);
					DescriptionPresenter = c11;
					Grid.SetRow(c11, 2);
					Grid.SetColumn(c11, 1);
					Grid.SetColumnSpan(c11, 2);
					c11.SetBinding(ContentPresenter.ContentProperty, new Binding
					{
						Path = "Description",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c11, ContentPresenter.ForegroundProperty, "SystemControlDescriptionTextForegroundBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
					AutomationProperties.SetAccessibilityView(c11, AccessibilityView.Raw);
					_component_3 = c11;
					c11.CreationComplete();
				})).CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ElementStub c12)
				{
					c12.Name = "DescriptionPresenter";
					_DescriptionPresenterSubject.ElementInstance = c12;
				})
			}
		}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(Grid c13)
		{
			nameScope.RegisterName("Root", c13);
			Root = c13;
			VisualStateManager.SetVisualStateGroups(c13, new VisualStateGroup[4]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c14)
						{
							nameScope.RegisterName("Normal", c14);
							Normal = c14;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c15)
						{
							nameScope.RegisterName("PointerOver", c15);
							PointerOver = c15;
							MarkupHelper.SetVisualStateLazy(c15, delegate
							{
								c15.Name = "PointerOver";
								c15.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c16)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c16, ObjectKeyFrame.ValueProperty, "CalendarDatePickerBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_4 = c16;
												NameScope.SetNameScope(_component_4, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c17)
										{
											Storyboard.SetTargetName(c17, "Background");
											Storyboard.SetTarget(c17, _BackgroundSubject);
											Storyboard.SetTargetProperty(c17, "BorderBrush");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c18)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c18, ObjectKeyFrame.ValueProperty, "CalendarDatePickerBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_5 = c18;
												NameScope.SetNameScope(_component_5, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c19)
										{
											Storyboard.SetTargetName(c19, "Background");
											Storyboard.SetTarget(c19, _BackgroundSubject);
											Storyboard.SetTargetProperty(c19, "Background");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c20)
						{
							nameScope.RegisterName("Pressed", c20);
							Pressed = c20;
							MarkupHelper.SetVisualStateLazy(c20, delegate
							{
								c20.Name = "Pressed";
								c20.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c21)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c21, ObjectKeyFrame.ValueProperty, "CalendarDatePickerBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_6 = c21;
												NameScope.SetNameScope(_component_6, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c22)
										{
											Storyboard.SetTargetName(c22, "Background");
											Storyboard.SetTarget(c22, _BackgroundSubject);
											Storyboard.SetTargetProperty(c22, "Background");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c23)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c23, ObjectKeyFrame.ValueProperty, "CalendarDatePickerBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_7 = c23;
												NameScope.SetNameScope(_component_7, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c24)
										{
											Storyboard.SetTargetName(c24, "Background");
											Storyboard.SetTarget(c24, _BackgroundSubject);
											Storyboard.SetTargetProperty(c24, "BorderBrush");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Disabled"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c25)
						{
							nameScope.RegisterName("Disabled", c25);
							Disabled = c25;
							MarkupHelper.SetVisualStateLazy(c25, delegate
							{
								c25.Name = "Disabled";
								c25.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c26)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c26, ObjectKeyFrame.ValueProperty, "CalendarDatePickerBackgroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_8 = c26;
												NameScope.SetNameScope(_component_8, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c27)
										{
											Storyboard.SetTargetName(c27, "Background");
											Storyboard.SetTarget(c27, _BackgroundSubject);
											Storyboard.SetTargetProperty(c27, "Background");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c28)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c28, ObjectKeyFrame.ValueProperty, "CalendarDatePickerBorderBrushDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_9 = c28;
												NameScope.SetNameScope(_component_9, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c29)
										{
											Storyboard.SetTargetName(c29, "Background");
											Storyboard.SetTarget(c29, _BackgroundSubject);
											Storyboard.SetTargetProperty(c29, "BorderBrush");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c30)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c30, ObjectKeyFrame.ValueProperty, "CalendarDatePickerHeaderForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_10 = c30;
												NameScope.SetNameScope(_component_10, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c31)
										{
											Storyboard.SetTargetName(c31, "HeaderContentPresenter");
											Storyboard.SetTarget(c31, _HeaderContentPresenterSubject);
											Storyboard.SetTargetProperty(c31, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c32)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c32, ObjectKeyFrame.ValueProperty, "CalendarDatePickerTextForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_11 = c32;
												NameScope.SetNameScope(_component_11, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c33)
										{
											Storyboard.SetTargetName(c33, "DateText");
											Storyboard.SetTarget(c33, _DateTextSubject);
											Storyboard.SetTargetProperty(c33, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c34)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c34, ObjectKeyFrame.ValueProperty, "CalendarDatePickerCalendarGlyphForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
												_component_12 = c34;
												NameScope.SetNameScope(_component_12, nameScope);
											}) }
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c35)
										{
											Storyboard.SetTargetName(c35, "CalendarGlyph");
											Storyboard.SetTarget(c35, _CalendarGlyphSubject);
											Storyboard.SetTargetProperty(c35, "Foreground");
										})
									}
								};
							});
						})
					}
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualStateGroup c36)
				{
					nameScope.RegisterName("CommonStates", c36);
					CommonStates = c36;
				}),
				new VisualStateGroup
				{
					Name = "FocusStates",
					States = 
					{
						new VisualState
						{
							Name = "Unfocused"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c37)
						{
							nameScope.RegisterName("Unfocused", c37);
							Unfocused = c37;
						}),
						new VisualState
						{
							Name = "PointerFocused"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c38)
						{
							nameScope.RegisterName("PointerFocused", c38);
							PointerFocused = c38;
						}),
						new VisualState
						{
							Name = "Focused"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c39)
						{
							nameScope.RegisterName("Focused", c39);
							Focused = c39;
							MarkupHelper.SetVisualStateLazy(c39, delegate
							{
								c39.Name = "Focused";
								c39.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c40)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c40, ObjectKeyFrame.ValueProperty, "CalendarDatePickerBackgroundFocused", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
											_component_13 = c40;
											NameScope.SetNameScope(_component_13, nameScope);
										}) }
									}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c41)
									{
										Storyboard.SetTargetName(c41, "Background");
										Storyboard.SetTarget(c41, _BackgroundSubject);
										Storyboard.SetTargetProperty(c41, "Background");
									}) }
								};
							});
						})
					}
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualStateGroup c42)
				{
					nameScope.RegisterName("FocusStates", c42);
					FocusStates = c42;
				}),
				new VisualStateGroup
				{
					Name = "SelectionStates",
					States = 
					{
						new VisualState
						{
							Name = "Unselected"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c43)
						{
							nameScope.RegisterName("Unselected", c43);
							Unselected = c43;
						}),
						new VisualState
						{
							Name = "Selected"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c44)
						{
							nameScope.RegisterName("Selected", c44);
							Selected = c44;
							MarkupHelper.SetVisualStateLazy(c44, delegate
							{
								c44.Name = "Selected";
								c44.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(DiscreteObjectKeyFrame c45)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c45, ObjectKeyFrame.ValueProperty, "CalendarDatePickerTextForegroundSelected", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
											_component_14 = c45;
											NameScope.SetNameScope(_component_14, nameScope);
										}) }
									}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c46)
									{
										Storyboard.SetTargetName(c46, "DateText");
										Storyboard.SetTarget(c46, _DateTextSubject);
										Storyboard.SetTargetProperty(c46, "Foreground");
									}) }
								};
							});
						})
					}
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualStateGroup c47)
				{
					nameScope.RegisterName("SelectionStates", c47);
					SelectionStates = c47;
				}),
				new VisualStateGroup
				{
					Name = "HeaderStates",
					States = 
					{
						new VisualState
						{
							Name = "TopHeader"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c48)
						{
							nameScope.RegisterName("TopHeader", c48);
							TopHeader = c48;
						}),
						new VisualState
						{
							Name = "LeftHeader"
						}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualState c49)
						{
							nameScope.RegisterName("LeftHeader", c49);
							LeftHeader = c49;
							MarkupHelper.SetVisualStateLazy(c49, delegate
							{
								c49.Name = "LeftHeader";
								c49.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentPresenterSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "1"));
								c49.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentPresenterSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
								c49.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentPresenterSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "1"));
								c49.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarDatePickerLeftHeaderMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_)));
								c49.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentPresenterSubject, (PropertyPath)"MaxWidth"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarDatePickerLeftHeaderMaxWidth", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_)));
							});
						})
					}
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(VisualStateGroup c50)
				{
					nameScope.RegisterName("HeaderStates", c50);
					HeaderStates = c50;
				})
			});
			FlyoutBase.SetAttachedFlyout(c13, new Flyout
			{
				Placement = FlyoutPlacementMode.Bottom,
				ShouldConstrainToRootBounds = false,
				FlyoutPresenterStyle = new Style(typeof(FlyoutPresenter))
				{
					Setters = 
					{
						(SetterBase)new Setter(Control.PaddingProperty, new Thickness(0.0)),
						(SetterBase)new Setter(Control.BorderThicknessProperty, new Thickness(0.0)),
						(SetterBase)new Setter(FlyoutPresenter.IsDefaultShadowEnabledProperty, true),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.CornerRadiusProperty, "OverlayCornerRadius", GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_, default(CornerRadius)).ApplyThemeResourceUpdateValues("OverlayCornerRadius", GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_, isTheme: true, isHotReload: false),
						(SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_244, (object? __ResourceOwner_247) => new ControlTemplate(__ResourceOwner_247, (object? __owner) => new _CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_UnoUI__Resources_CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_CalendarDatePicker_themeresourcesRDSC0CalendarDatePicker_themeresourcesRDSC1().Build(__owner)))
					}
				},
				Content = new CalendarView
				{
					IsParsing = true,
					Name = "CalendarView"
				}.CalendarDatePicker_themeresources_c79697b1dfe00dbfeb25aaa97f4f85c7_XamlApply(delegate(CalendarView c51)
				{
					nameScope.RegisterName("CalendarView", c51);
					CalendarView = c51;
					c51.SetBinding(FrameworkElement.StyleProperty, new Binding
					{
						Path = "CalendarViewStyle",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.MinDateProperty, new Binding
					{
						Path = "MinDate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.MaxDateProperty, new Binding
					{
						Path = "MaxDate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.IsTodayHighlightedProperty, new Binding
					{
						Path = "IsTodayHighlighted",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.DisplayModeProperty, new Binding
					{
						Path = "DisplayMode",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.FirstDayOfWeekProperty, new Binding
					{
						Path = "FirstDayOfWeek",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.DayOfWeekFormatProperty, new Binding
					{
						Path = "DayOfWeekFormat",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.CalendarIdentifierProperty, new Binding
					{
						Path = "CalendarIdentifier",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.IsOutOfScopeEnabledProperty, new Binding
					{
						Path = "IsOutOfScopeEnabled",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c51.SetBinding(CalendarView.IsGroupLabelVisibleProperty, new Binding
					{
						Path = "IsGroupLabelVisible",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c51, Control.CornerRadiusProperty, "OverlayCornerRadius", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__1.Instance.__ParseContext_);
					_component_15 = c51;
					c51.CreationComplete();
				})
			});
			c13.CreationComplete();
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

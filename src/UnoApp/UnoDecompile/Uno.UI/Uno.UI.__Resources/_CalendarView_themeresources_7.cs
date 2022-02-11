using System;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_CalendarView_themeresourcesRDSC0
{
	private class _CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_UnoUI__Resources_CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_CalendarView_themeresourcesRDSC0CalendarView_themeresourcesRDSC2
	{
		private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

		private ElementNameSubject _TextSubject = new ElementNameSubject();

		private ElementNameSubject _NormalSubject = new ElementNameSubject();

		private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

		private ElementNameSubject _PressedSubject = new ElementNameSubject();

		private ElementNameSubject _DisabledSubject = new ElementNameSubject();

		private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

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

		private ContentPresenter Text
		{
			get
			{
				return (ContentPresenter)_TextSubject.ElementInstance;
			}
			set
			{
				_TextSubject.ElementInstance = value;
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

		public UIElement Build(object __ResourceOwner_358)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new ContentPresenter
			{
				IsParsing = true,
				Name = "Text"
			}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ContentPresenter c198)
			{
				nameScope.RegisterName("Text", c198);
				Text = c198;
				c198.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c198.SetBinding(ContentPresenter.BackgroundSizingProperty, new Binding
				{
					Path = "BackgroundSizing",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				ResourceResolverSingleton.Instance.ApplyResource(c198, ContentPresenter.BorderBrushProperty, "CalendarViewNavigationButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
				c198.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c198.SetBinding(ContentPresenter.ContentProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c198.SetBinding(FrameworkElement.MarginProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c198.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c198.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				VisualStateManager.SetVisualStateGroups(c198, new VisualStateGroup[1] { new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c199)
						{
							nameScope.RegisterName("Normal", c199);
							Normal = c199;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c200)
						{
							nameScope.RegisterName("PointerOver", c200);
							PointerOver = c200;
							MarkupHelper.SetVisualStateLazy(c200, delegate
							{
								c200.Name = "PointerOver";
								c200.Setters.Add(new Setter(new TargetPropertyPath(_TextSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarViewNavigationButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c200.Setters.Add(new Setter(new TargetPropertyPath(_TextSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarViewNavigationButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c201)
						{
							nameScope.RegisterName("Pressed", c201);
							Pressed = c201;
							MarkupHelper.SetVisualStateLazy(c201, delegate
							{
								c201.Name = "Pressed";
								c201.Setters.Add(new Setter(new TargetPropertyPath(_TextSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarViewNavigationButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Disabled"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c202)
						{
							nameScope.RegisterName("Disabled", c202);
							Disabled = c202;
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c203)
				{
					nameScope.RegisterName("CommonStates", c203);
					CommonStates = c203;
				}) });
				_component_0 = c198;
				c198.CreationComplete();
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

	private ElementNameSubject _HeaderButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PreviousButtonSubject = new ElementNameSubject();

	private ElementNameSubject _NextButtonSubject = new ElementNameSubject();

	private ElementNameSubject _BackgroundTransformSubject = new ElementNameSubject();

	private ElementNameSubject _BackgroundLayerSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewTransformSubject = new ElementNameSubject();

	private ElementNameSubject _WeekDay1Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay2Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay3Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay4Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay5Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay6Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay7Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDayNamesSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewPanelSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewSubject = new ElementNameSubject();

	private ElementNameSubject _YearViewTransformSubject = new ElementNameSubject();

	private ElementNameSubject _YearViewPanelSubject = new ElementNameSubject();

	private ElementNameSubject _YearViewScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeViewTransformSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeViewPanelSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeViewScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _ViewsSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ViewChangedSubject = new ElementNameSubject();

	private ElementNameSubject _ViewChangingSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderButtonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _MonthSubject = new ElementNameSubject();

	private ElementNameSubject _YearSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayModeStatesSubject = new ElementNameSubject();

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

	private TextBlock _component_5
	{
		get
		{
			return (TextBlock)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private TextBlock _component_6
	{
		get
		{
			return (TextBlock)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private TextBlock _component_7
	{
		get
		{
			return (TextBlock)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private TextBlock _component_8
	{
		get
		{
			return (TextBlock)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private TextBlock _component_9
	{
		get
		{
			return (TextBlock)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer _component_10
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer _component_11
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer _component_12
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_component_12_Holder.Instance;
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

	private DiscreteObjectKeyFrame _component_15
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_16
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_16_Holder.Instance;
		}
		set
		{
			_component_16_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_17
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_17_Holder.Instance;
		}
		set
		{
			_component_17_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_18
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_18_Holder.Instance;
		}
		set
		{
			_component_18_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_19
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_19_Holder.Instance;
		}
		set
		{
			_component_19_Holder.Instance = value;
		}
	}

	private Button HeaderButton
	{
		get
		{
			return (Button)_HeaderButtonSubject.ElementInstance;
		}
		set
		{
			_HeaderButtonSubject.ElementInstance = value;
		}
	}

	private Button PreviousButton
	{
		get
		{
			return (Button)_PreviousButtonSubject.ElementInstance;
		}
		set
		{
			_PreviousButtonSubject.ElementInstance = value;
		}
	}

	private Button NextButton
	{
		get
		{
			return (Button)_NextButtonSubject.ElementInstance;
		}
		set
		{
			_NextButtonSubject.ElementInstance = value;
		}
	}

	private ScaleTransform BackgroundTransform
	{
		get
		{
			return (ScaleTransform)_BackgroundTransformSubject.ElementInstance;
		}
		set
		{
			_BackgroundTransformSubject.ElementInstance = value;
		}
	}

	private Border BackgroundLayer
	{
		get
		{
			return (Border)_BackgroundLayerSubject.ElementInstance;
		}
		set
		{
			_BackgroundLayerSubject.ElementInstance = value;
		}
	}

	private ScaleTransform MonthViewTransform
	{
		get
		{
			return (ScaleTransform)_MonthViewTransformSubject.ElementInstance;
		}
		set
		{
			_MonthViewTransformSubject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay1
	{
		get
		{
			return (TextBlock)_WeekDay1Subject.ElementInstance;
		}
		set
		{
			_WeekDay1Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay2
	{
		get
		{
			return (TextBlock)_WeekDay2Subject.ElementInstance;
		}
		set
		{
			_WeekDay2Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay3
	{
		get
		{
			return (TextBlock)_WeekDay3Subject.ElementInstance;
		}
		set
		{
			_WeekDay3Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay4
	{
		get
		{
			return (TextBlock)_WeekDay4Subject.ElementInstance;
		}
		set
		{
			_WeekDay4Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay5
	{
		get
		{
			return (TextBlock)_WeekDay5Subject.ElementInstance;
		}
		set
		{
			_WeekDay5Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay6
	{
		get
		{
			return (TextBlock)_WeekDay6Subject.ElementInstance;
		}
		set
		{
			_WeekDay6Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay7
	{
		get
		{
			return (TextBlock)_WeekDay7Subject.ElementInstance;
		}
		set
		{
			_WeekDay7Subject.ElementInstance = value;
		}
	}

	private Grid WeekDayNames
	{
		get
		{
			return (Grid)_WeekDayNamesSubject.ElementInstance;
		}
		set
		{
			_WeekDayNamesSubject.ElementInstance = value;
		}
	}

	private CalendarPanel MonthViewPanel
	{
		get
		{
			return (CalendarPanel)_MonthViewPanelSubject.ElementInstance;
		}
		set
		{
			_MonthViewPanelSubject.ElementInstance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer MonthViewScrollViewer
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_MonthViewScrollViewerSubject.ElementInstance;
		}
		set
		{
			_MonthViewScrollViewerSubject.ElementInstance = value;
		}
	}

	private Grid MonthView
	{
		get
		{
			return (Grid)_MonthViewSubject.ElementInstance;
		}
		set
		{
			_MonthViewSubject.ElementInstance = value;
		}
	}

	private ScaleTransform YearViewTransform
	{
		get
		{
			return (ScaleTransform)_YearViewTransformSubject.ElementInstance;
		}
		set
		{
			_YearViewTransformSubject.ElementInstance = value;
		}
	}

	private CalendarPanel YearViewPanel
	{
		get
		{
			return (CalendarPanel)_YearViewPanelSubject.ElementInstance;
		}
		set
		{
			_YearViewPanelSubject.ElementInstance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer YearViewScrollViewer
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_YearViewScrollViewerSubject.ElementInstance;
		}
		set
		{
			_YearViewScrollViewerSubject.ElementInstance = value;
		}
	}

	private ScaleTransform DecadeViewTransform
	{
		get
		{
			return (ScaleTransform)_DecadeViewTransformSubject.ElementInstance;
		}
		set
		{
			_DecadeViewTransformSubject.ElementInstance = value;
		}
	}

	private CalendarPanel DecadeViewPanel
	{
		get
		{
			return (CalendarPanel)_DecadeViewPanelSubject.ElementInstance;
		}
		set
		{
			_DecadeViewPanelSubject.ElementInstance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer DecadeViewScrollViewer
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_DecadeViewScrollViewerSubject.ElementInstance;
		}
		set
		{
			_DecadeViewScrollViewerSubject.ElementInstance = value;
		}
	}

	private Grid Views
	{
		get
		{
			return (Grid)_ViewsSubject.ElementInstance;
		}
		set
		{
			_ViewsSubject.ElementInstance = value;
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

	private VisualState ViewChanged
	{
		get
		{
			return (VisualState)_ViewChangedSubject.ElementInstance;
		}
		set
		{
			_ViewChangedSubject.ElementInstance = value;
		}
	}

	private VisualState ViewChanging
	{
		get
		{
			return (VisualState)_ViewChangingSubject.ElementInstance;
		}
		set
		{
			_ViewChangingSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup HeaderButtonStates
	{
		get
		{
			return (VisualStateGroup)_HeaderButtonStatesSubject.ElementInstance;
		}
		set
		{
			_HeaderButtonStatesSubject.ElementInstance = value;
		}
	}

	private VisualState Month
	{
		get
		{
			return (VisualState)_MonthSubject.ElementInstance;
		}
		set
		{
			_MonthSubject.ElementInstance = value;
		}
	}

	private VisualState Year
	{
		get
		{
			return (VisualState)_YearSubject.ElementInstance;
		}
		set
		{
			_YearSubject.ElementInstance = value;
		}
	}

	private VisualState Decade
	{
		get
		{
			return (VisualState)_DecadeSubject.ElementInstance;
		}
		set
		{
			_DecadeSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DisplayModeStates
	{
		get
		{
			return (VisualStateGroup)_DisplayModeStatesSubject.ElementInstance;
		}
		set
		{
			_DisplayModeStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_284)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Resources = 
			{
				[(object)(__LinkerHints.Is_Windows_UI_Xaml_Controls_TextBlock_Available ? "WeekDayNameStyle" : null)] = (__LinkerHints.Is_Windows_UI_Xaml_Controls_TextBlock_Available ? new WeakResourceInitializer(__ResourceOwner_284, (object? __ResourceOwner_285) => new Style(typeof(TextBlock))
				{
					BasedOn = (Style)ResourceResolverSingleton.Instance.ResolveResourceStatic("CaptionTextBlockStyle", typeof(Style), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_),
					Setters = 
					{
						(SetterBase)new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center),
						(SetterBase)new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
					}
				}) : null),
				[(object)(__LinkerHints.Is_Windows_UI_Xaml_Controls_Button_Available ? "NavigationButtonStyle" : null)] = (__LinkerHints.Is_Windows_UI_Xaml_Controls_Button_Available ? new WeakResourceInitializer(__ResourceOwner_284, (object? __ResourceOwner_286) => new Style(typeof(Button))
				{
					Setters = 
					{
						(SetterBase)new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch),
						(SetterBase)new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Stretch),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.UseSystemFocusVisualsProperty, "UseSystemFocusVisuals", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, false),
						(SetterBase)new Setter(Control.FontSizeProperty, 20.0),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(FrameworkElement.BackgroundProperty, "CalendarViewNavigationButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, null).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false),
						(SetterBase)new Setter(Control.BackgroundSizingProperty, BackgroundSizing.OuterBorderEdge),
						(SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_286, (object? __ResourceOwner_287) => new ControlTemplate(__ResourceOwner_287, (object? __owner) => new _CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_UnoUI__Resources_CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_CalendarView_themeresourcesRDSC0CalendarView_themeresourcesRDSC2().Build(__owner)))
					}
				}) : null),
				[(object)(__LinkerHints.Is_Windows_UI_Xaml_Controls_ScrollViewer_Available ? "ScrollViewerStyle" : null)] = (__LinkerHints.Is_Windows_UI_Xaml_Controls_ScrollViewer_Available ? new WeakResourceInitializer(__ResourceOwner_284, (object? __ResourceOwner_289) => new Style(typeof(Windows.UI.Xaml.Controls.ScrollViewer))
				{
					Setters = 
					{
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.HorizontalScrollModeProperty, ScrollMode.Disabled),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.VerticalScrollModeProperty, ScrollMode.Enabled),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.VerticalSnapPointsTypeProperty, SnapPointsType.Optional),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.ZoomModeProperty, ZoomMode.Disabled),
						(SetterBase)new Setter(Control.TabNavigationProperty, KeyboardNavigationMode.Once),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.BringIntoViewOnFocusChangeProperty, false),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.TemplateProperty, "ScrollViewerScrollBarlessTemplate", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, null),
						(SetterBase)new Setter(Uno.UI.Xaml.Controls.ScrollViewer.ShouldFallBackToNativeScrollBarsProperty, false)
					}
				}) : null)
			},
			Child = new Grid
			{
				IsParsing = true,
				RowDefinitions = 
				{
					new RowDefinition
					{
						Height = new GridLength(40.0, GridUnitType.Pixel)
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
						ColumnDefinitions = 
						{
							new ColumnDefinition
							{
								Width = new GridLength(5.0, GridUnitType.Star)
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
						Children = 
						{
							(UIElement)new Button
							{
								IsParsing = true,
								Name = "HeaderButton",
								Padding = new Thickness(12.0, 0.0, 0.0, 0.0),
								HorizontalContentAlignment = HorizontalAlignment.Left
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Button c5)
							{
								nameScope.RegisterName("HeaderButton", c5);
								HeaderButton = c5;
								c5.SetBinding(ContentControl.ContentProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HeaderText"
								});
								c5.SetBinding(Control.IsEnabledProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HasMoreViews"
								});
								ResourceResolverSingleton.Instance.ApplyResource(c5, FrameworkElement.StyleProperty, "NavigationButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								c5.SetBinding(Control.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								_component_0 = c5;
								c5.CreationComplete();
							}),
							(UIElement)new Button
							{
								IsParsing = true,
								Name = "PreviousButton",
								Content = "\ue0e4",
								IsTabStop = true,
								Padding = new Thickness(1.0),
								HorizontalContentAlignment = HorizontalAlignment.Center
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Button c6)
							{
								nameScope.RegisterName("PreviousButton", c6);
								PreviousButton = c6;
								Grid.SetColumn(c6, 1);
								ResourceResolverSingleton.Instance.ApplyResource(c6, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								c6.SetBinding(Control.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c6.SetBinding(Control.IsEnabledProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HasMoreContentBefore"
								});
								ResourceResolverSingleton.Instance.ApplyResource(c6, FrameworkElement.StyleProperty, "NavigationButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_1 = c6;
								c6.CreationComplete();
							}),
							(UIElement)new Button
							{
								IsParsing = true,
								Name = "NextButton",
								Content = "\ue0e5",
								IsTabStop = true,
								Padding = new Thickness(1.0),
								HorizontalContentAlignment = HorizontalAlignment.Center
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Button c7)
							{
								nameScope.RegisterName("NextButton", c7);
								NextButton = c7;
								Grid.SetColumn(c7, 2);
								ResourceResolverSingleton.Instance.ApplyResource(c7, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								c7.SetBinding(Control.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c7.SetBinding(Control.IsEnabledProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HasMoreContentAfter"
								});
								ResourceResolverSingleton.Instance.ApplyResource(c7, FrameworkElement.StyleProperty, "NavigationButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_2 = c7;
								c7.CreationComplete();
							})
						}
					}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c8)
					{
						c8.CreationComplete();
					}),
					(UIElement)new Grid
					{
						IsParsing = true,
						Name = "Views",
						Children = 
						{
							(UIElement)new Border
							{
								IsParsing = true,
								Name = "BackgroundLayer",
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c9)
								{
									nameScope.RegisterName("BackgroundTransform", c9);
									BackgroundTransform = c9;
									c9.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c9.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								})
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Border c10)
							{
								nameScope.RegisterName("BackgroundLayer", c10);
								BackgroundLayer = c10;
								c10.SetBinding(FrameworkElement.BackgroundProperty, new Binding
								{
									Path = "BorderBrush",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c10.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "MonthView",
								RowDefinitions = 
								{
									new RowDefinition
									{
										Height = new GridLength(38.0, GridUnitType.Pixel)
									},
									new RowDefinition
									{
										Height = new GridLength(1.0, GridUnitType.Star)
									}
								},
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c13)
								{
									nameScope.RegisterName("MonthViewTransform", c13);
									MonthViewTransform = c13;
									c13.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c13.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								}),
								Children = 
								{
									(UIElement)new Grid
									{
										IsParsing = true,
										Name = "WeekDayNames",
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
											},
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
											},
											new ColumnDefinition
											{
												Width = new GridLength(1.0, GridUnitType.Star)
											}
										},
										Children = 
										{
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay1"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c21)
											{
												nameScope.RegisterName("WeekDay1", c21);
												WeekDay1 = c21;
												c21.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay1"
												});
												c21.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c21, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_3 = c21;
												c21.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay2"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c22)
											{
												nameScope.RegisterName("WeekDay2", c22);
												WeekDay2 = c22;
												Grid.SetColumn(c22, 1);
												c22.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay2"
												});
												c22.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c22, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_4 = c22;
												c22.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay3"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c23)
											{
												nameScope.RegisterName("WeekDay3", c23);
												WeekDay3 = c23;
												Grid.SetColumn(c23, 2);
												c23.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay3"
												});
												c23.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c23, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_5 = c23;
												c23.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay4"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c24)
											{
												nameScope.RegisterName("WeekDay4", c24);
												WeekDay4 = c24;
												Grid.SetColumn(c24, 3);
												c24.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay4"
												});
												c24.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c24, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_6 = c24;
												c24.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay5"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c25)
											{
												nameScope.RegisterName("WeekDay5", c25);
												WeekDay5 = c25;
												Grid.SetColumn(c25, 4);
												c25.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay5"
												});
												c25.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c25, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_7 = c25;
												c25.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay6"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c26)
											{
												nameScope.RegisterName("WeekDay6", c26);
												WeekDay6 = c26;
												Grid.SetColumn(c26, 5);
												c26.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay6"
												});
												c26.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c26, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_8 = c26;
												c26.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay7"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c27)
											{
												nameScope.RegisterName("WeekDay7", c27);
												WeekDay7 = c27;
												Grid.SetColumn(c27, 6);
												c27.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay7"
												});
												c27.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c27, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_9 = c27;
												c27.CreationComplete();
											})
										}
									}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c28)
									{
										nameScope.RegisterName("WeekDayNames", c28);
										WeekDayNames = c28;
										c28.SetBinding(FrameworkElement.BackgroundProperty, new Binding
										{
											Path = "Background",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c28.CreationComplete();
									}),
									(UIElement)new Windows.UI.Xaml.Controls.ScrollViewer
									{
										IsParsing = true,
										Name = "MonthViewScrollViewer",
										IsFocusEngagementEnabled = true,
										Content = new CalendarPanel
										{
											IsParsing = true,
											Name = "MonthViewPanel"
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(CalendarPanel c29)
										{
											nameScope.RegisterName("MonthViewPanel", c29);
											MonthViewPanel = c29;
											c29.CreationComplete();
										})
									}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Windows.UI.Xaml.Controls.ScrollViewer c30)
									{
										nameScope.RegisterName("MonthViewScrollViewer", c30);
										MonthViewScrollViewer = c30;
										Grid.SetRow(c30, 1);
										ResourceResolverSingleton.Instance.ApplyResource(c30, FrameworkElement.StyleProperty, "ScrollViewerStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
										_component_10 = c30;
										c30.CreationComplete();
									})
								}
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c31)
							{
								nameScope.RegisterName("MonthView", c31);
								MonthView = c31;
								c31.CreationComplete();
							}),
							(UIElement)new Windows.UI.Xaml.Controls.ScrollViewer
							{
								IsParsing = true,
								Name = "YearViewScrollViewer",
								UseLayoutRounding = false,
								Opacity = 0.0,
								Visibility = Visibility.Collapsed,
								IsFocusEngagementEnabled = true,
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c32)
								{
									nameScope.RegisterName("YearViewTransform", c32);
									YearViewTransform = c32;
									c32.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c32.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								}),
								Content = new CalendarPanel
								{
									IsParsing = true,
									Name = "YearViewPanel"
								}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(CalendarPanel c33)
								{
									nameScope.RegisterName("YearViewPanel", c33);
									YearViewPanel = c33;
									c33.CreationComplete();
								})
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Windows.UI.Xaml.Controls.ScrollViewer c34)
							{
								nameScope.RegisterName("YearViewScrollViewer", c34);
								YearViewScrollViewer = c34;
								ResourceResolverSingleton.Instance.ApplyResource(c34, FrameworkElement.StyleProperty, "ScrollViewerStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_11 = c34;
								c34.CreationComplete();
							}),
							(UIElement)new Windows.UI.Xaml.Controls.ScrollViewer
							{
								IsParsing = true,
								Name = "DecadeViewScrollViewer",
								UseLayoutRounding = false,
								IsFocusEngagementEnabled = true,
								Opacity = 0.0,
								Visibility = Visibility.Collapsed,
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c35)
								{
									nameScope.RegisterName("DecadeViewTransform", c35);
									DecadeViewTransform = c35;
									c35.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c35.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								}),
								Content = new CalendarPanel
								{
									IsParsing = true,
									Name = "DecadeViewPanel"
								}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(CalendarPanel c36)
								{
									nameScope.RegisterName("DecadeViewPanel", c36);
									DecadeViewPanel = c36;
									c36.CreationComplete();
								})
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Windows.UI.Xaml.Controls.ScrollViewer c37)
							{
								nameScope.RegisterName("DecadeViewScrollViewer", c37);
								DecadeViewScrollViewer = c37;
								ResourceResolverSingleton.Instance.ApplyResource(c37, FrameworkElement.StyleProperty, "ScrollViewerStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_12 = c37;
								c37.CreationComplete();
							})
						}
					}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c38)
					{
						nameScope.RegisterName("Views", c38);
						Views = c38;
						Grid.SetRow(c38, 1);
						c38.CreationComplete();
					})
				}
			}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c39)
			{
				c39.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c39.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c39.SetBinding(FrameworkElement.MinWidthProperty, new Binding
				{
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
					Path = "TemplateSettings.MinViewWidth"
				});
				c39.CreationComplete();
			})
		}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Border c40)
		{
			c40.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c40.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c40.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c40.SetBinding(Border.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c40, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c41)
						{
							nameScope.RegisterName("Normal", c41);
							Normal = c41;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c42)
						{
							nameScope.RegisterName("Disabled", c42);
							Disabled = c42;
							MarkupHelper.SetVisualStateLazy(c42, delegate
							{
								c42.Name = "Disabled";
								c42.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c43)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c43, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_13 = c43;
												NameScope.SetNameScope(_component_13, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c44)
										{
											Storyboard.SetTargetName(c44, "WeekDay1");
											Storyboard.SetTarget(c44, _WeekDay1Subject);
											Storyboard.SetTargetProperty(c44, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c45)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c45, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_14 = c45;
												NameScope.SetNameScope(_component_14, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c46)
										{
											Storyboard.SetTargetName(c46, "WeekDay2");
											Storyboard.SetTarget(c46, _WeekDay2Subject);
											Storyboard.SetTargetProperty(c46, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c47)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c47, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_15 = c47;
												NameScope.SetNameScope(_component_15, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c48)
										{
											Storyboard.SetTargetName(c48, "WeekDay3");
											Storyboard.SetTarget(c48, _WeekDay3Subject);
											Storyboard.SetTargetProperty(c48, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c49)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c49, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_16 = c49;
												NameScope.SetNameScope(_component_16, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c50)
										{
											Storyboard.SetTargetName(c50, "WeekDay4");
											Storyboard.SetTarget(c50, _WeekDay4Subject);
											Storyboard.SetTargetProperty(c50, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c51)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c51, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_17 = c51;
												NameScope.SetNameScope(_component_17, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c52)
										{
											Storyboard.SetTargetName(c52, "WeekDay5");
											Storyboard.SetTarget(c52, _WeekDay5Subject);
											Storyboard.SetTargetProperty(c52, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c53)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c53, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_18 = c53;
												NameScope.SetNameScope(_component_18, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c54)
										{
											Storyboard.SetTargetName(c54, "WeekDay6");
											Storyboard.SetTarget(c54, _WeekDay6Subject);
											Storyboard.SetTargetProperty(c54, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c55)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c55, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_19 = c55;
												NameScope.SetNameScope(_component_19, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c56)
										{
											Storyboard.SetTargetName(c56, "WeekDay7");
											Storyboard.SetTarget(c56, _WeekDay7Subject);
											Storyboard.SetTargetProperty(c56, "Foreground");
										})
									}
								};
							});
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c57)
				{
					nameScope.RegisterName("CommonStates", c57);
					CommonStates = c57;
				}),
				new VisualStateGroup
				{
					Name = "HeaderButtonStates",
					States = 
					{
						new VisualState
						{
							Name = "ViewChanged"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c58)
						{
							nameScope.RegisterName("ViewChanged", c58);
							ViewChanged = c58;
						}),
						new VisualState
						{
							Name = "ViewChanging"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c59)
						{
							nameScope.RegisterName("ViewChanging", c59);
							ViewChanging = c59;
							MarkupHelper.SetVisualStateLazy(c59, delegate
							{
								c59.Name = "ViewChanging";
								c59.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DoubleAnimation
									{
										From = 0.0,
										To = 1.0,
										Duration = new Duration(TimeSpan.FromTicks(1670000L))
									}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimation c60)
									{
										Storyboard.SetTargetName(c60, "HeaderButton");
										Storyboard.SetTarget(c60, _HeaderButtonSubject);
										Storyboard.SetTargetProperty(c60, "Opacity");
									}) }
								};
							});
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c61)
				{
					nameScope.RegisterName("HeaderButtonStates", c61);
					HeaderButtonStates = c61;
				}),
				new VisualStateGroup
				{
					Name = "DisplayModeStates",
					Transitions = 
					{
						new VisualTransition
						{
							From = "Month",
							To = "Year"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c62)
						{
							MarkupHelper.SetVisualTransitionLazy(c62, delegate
							{
								c62.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c64)
										{
											Storyboard.SetTargetName(c64, "MonthView");
											Storyboard.SetTarget(c64, _MonthViewSubject);
											Storyboard.SetTargetProperty(c64, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c68)
										{
											Storyboard.SetTargetName(c68, "YearViewScrollViewer");
											Storyboard.SetTarget(c68, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c68, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c70)
										{
											Storyboard.SetTargetName(c70, "YearViewScrollViewer");
											Storyboard.SetTarget(c70, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c70, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.84,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c72)
										{
											Storyboard.SetTargetName(c72, "MonthViewTransform");
											Storyboard.SetTarget(c72, _MonthViewTransformSubject);
											Storyboard.SetTargetProperty(c72, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.84,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c74)
										{
											Storyboard.SetTargetName(c74, "MonthViewTransform");
											Storyboard.SetTarget(c74, _MonthViewTransformSubject);
											Storyboard.SetTargetProperty(c74, "ScaleY");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 1.29
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c77)
										{
											Storyboard.SetTargetName(c77, "YearViewTransform");
											Storyboard.SetTarget(c77, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c77, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 1.29
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c80)
										{
											Storyboard.SetTargetName(c80, "YearViewTransform");
											Storyboard.SetTarget(c80, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c80, "ScaleY");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c84)
										{
											Storyboard.SetTargetName(c84, "BackgroundLayer");
											Storyboard.SetTarget(c84, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c84, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "Year",
							To = "Month"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c85)
						{
							MarkupHelper.SetVisualTransitionLazy(c85, delegate
							{
								c85.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c87)
										{
											Storyboard.SetTargetName(c87, "YearViewScrollViewer");
											Storyboard.SetTarget(c87, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c87, "IsHitTestVisible");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c89)
										{
											Storyboard.SetTargetName(c89, "YearViewScrollViewer");
											Storyboard.SetTarget(c89, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c89, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c91)
										{
											Storyboard.SetTargetName(c91, "YearViewScrollViewer");
											Storyboard.SetTarget(c91, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c91, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c95)
										{
											Storyboard.SetTargetName(c95, "MonthView");
											Storyboard.SetTarget(c95, _MonthViewSubject);
											Storyboard.SetTargetProperty(c95, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 1.29,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c97)
										{
											Storyboard.SetTargetName(c97, "YearViewTransform");
											Storyboard.SetTarget(c97, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c97, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 1.29,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c99)
										{
											Storyboard.SetTargetName(c99, "YearViewTransform");
											Storyboard.SetTarget(c99, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c99, "ScaleY");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c102)
										{
											Storyboard.SetTargetName(c102, "MonthViewTransform");
											Storyboard.SetTarget(c102, _MonthViewTransformSubject);
											Storyboard.SetTargetProperty(c102, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c105)
										{
											Storyboard.SetTargetName(c105, "MonthViewTransform");
											Storyboard.SetTarget(c105, _MonthViewTransformSubject);
											Storyboard.SetTargetProperty(c105, "ScaleY");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c108)
										{
											Storyboard.SetTargetName(c108, "BackgroundTransform");
											Storyboard.SetTarget(c108, _BackgroundTransformSubject);
											Storyboard.SetTargetProperty(c108, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c111)
										{
											Storyboard.SetTargetName(c111, "BackgroundTransform");
											Storyboard.SetTarget(c111, _BackgroundTransformSubject);
											Storyboard.SetTargetProperty(c111, "ScaleY");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c115)
										{
											Storyboard.SetTargetName(c115, "BackgroundLayer");
											Storyboard.SetTarget(c115, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c115, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "Year",
							To = "Decade"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c116)
						{
							MarkupHelper.SetVisualTransitionLazy(c116, delegate
							{
								c116.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c118)
										{
											Storyboard.SetTargetName(c118, "MonthView");
											Storyboard.SetTarget(c118, _MonthViewSubject);
											Storyboard.SetTargetProperty(c118, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c120)
										{
											Storyboard.SetTargetName(c120, "YearViewScrollViewer");
											Storyboard.SetTarget(c120, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c120, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c122)
										{
											Storyboard.SetTargetName(c122, "YearViewScrollViewer");
											Storyboard.SetTarget(c122, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c122, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c126)
										{
											Storyboard.SetTargetName(c126, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c126, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c126, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c128)
										{
											Storyboard.SetTargetName(c128, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c128, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c128, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.84,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c130)
										{
											Storyboard.SetTargetName(c130, "YearViewTransform");
											Storyboard.SetTarget(c130, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c130, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.84,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c132)
										{
											Storyboard.SetTargetName(c132, "YearViewTransform");
											Storyboard.SetTarget(c132, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c132, "ScaleY");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 1.29
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c135)
										{
											Storyboard.SetTargetName(c135, "DecadeViewTransform");
											Storyboard.SetTarget(c135, _DecadeViewTransformSubject);
											Storyboard.SetTargetProperty(c135, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 1.29
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c138)
										{
											Storyboard.SetTargetName(c138, "DecadeViewTransform");
											Storyboard.SetTarget(c138, _DecadeViewTransformSubject);
											Storyboard.SetTargetProperty(c138, "ScaleY");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c142)
										{
											Storyboard.SetTargetName(c142, "BackgroundLayer");
											Storyboard.SetTarget(c142, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c142, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "Decade",
							To = "Year"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c143)
						{
							MarkupHelper.SetVisualTransitionLazy(c143, delegate
							{
								c143.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c145)
										{
											Storyboard.SetTargetName(c145, "MonthView");
											Storyboard.SetTarget(c145, _MonthViewSubject);
											Storyboard.SetTargetProperty(c145, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c147)
										{
											Storyboard.SetTargetName(c147, "YearViewScrollViewer");
											Storyboard.SetTarget(c147, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c147, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c149)
										{
											Storyboard.SetTargetName(c149, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c149, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c149, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c151)
										{
											Storyboard.SetTargetName(c151, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c151, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c151, "IsHitTestVisible");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c153)
										{
											Storyboard.SetTargetName(c153, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c153, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c153, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c157)
										{
											Storyboard.SetTargetName(c157, "YearViewScrollViewer");
											Storyboard.SetTarget(c157, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c157, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 1.29,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c159)
										{
											Storyboard.SetTargetName(c159, "DecadeViewTransform");
											Storyboard.SetTarget(c159, _DecadeViewTransformSubject);
											Storyboard.SetTargetProperty(c159, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 1.29,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c161)
										{
											Storyboard.SetTargetName(c161, "DecadeViewTransform");
											Storyboard.SetTarget(c161, _DecadeViewTransformSubject);
											Storyboard.SetTargetProperty(c161, "ScaleY");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c164)
										{
											Storyboard.SetTargetName(c164, "YearViewTransform");
											Storyboard.SetTarget(c164, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c164, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c167)
										{
											Storyboard.SetTargetName(c167, "YearViewTransform");
											Storyboard.SetTarget(c167, _YearViewTransformSubject);
											Storyboard.SetTargetProperty(c167, "ScaleY");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c170)
										{
											Storyboard.SetTargetName(c170, "BackgroundTransform");
											Storyboard.SetTarget(c170, _BackgroundTransformSubject);
											Storyboard.SetTargetProperty(c170, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.84
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c173)
										{
											Storyboard.SetTargetName(c173, "BackgroundTransform");
											Storyboard.SetTarget(c173, _BackgroundTransformSubject);
											Storyboard.SetTargetProperty(c173, "ScaleY");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c177)
										{
											Storyboard.SetTargetName(c177, "BackgroundLayer");
											Storyboard.SetTarget(c177, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c177, "Opacity");
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
							Name = "Month"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c178)
						{
							nameScope.RegisterName("Month", c178);
							Month = c178;
						}),
						new VisualState
						{
							Name = "Year"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c179)
						{
							nameScope.RegisterName("Year", c179);
							Year = c179;
							MarkupHelper.SetVisualStateLazy(c179, delegate
							{
								c179.Name = "Year";
								c179.Setters.Add(new Setter(new TargetPropertyPath(_YearViewScrollViewerSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c179.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c181)
										{
											Storyboard.SetTargetName(c181, "MonthViewScrollViewer");
											Storyboard.SetTarget(c181, _MonthViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c181, "IsEnabled");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "0"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c183)
										{
											Storyboard.SetTargetName(c183, "MonthView");
											Storyboard.SetTarget(c183, _MonthViewSubject);
											Storyboard.SetTargetProperty(c183, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c185)
										{
											Storyboard.SetTargetName(c185, "YearViewScrollViewer");
											Storyboard.SetTarget(c185, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c185, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 1.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c187)
										{
											Storyboard.SetTargetName(c187, "YearViewScrollViewer");
											Storyboard.SetTarget(c187, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c187, "Opacity");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Decade"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c188)
						{
							nameScope.RegisterName("Decade", c188);
							Decade = c188;
							MarkupHelper.SetVisualStateLazy(c188, delegate
							{
								c188.Name = "Decade";
								c188.Setters.Add(new Setter(new TargetPropertyPath(_DecadeViewScrollViewerSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c188.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c190)
										{
											Storyboard.SetTargetName(c190, "MonthViewScrollViewer");
											Storyboard.SetTarget(c190, _MonthViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c190, "IsEnabled");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "0"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c192)
										{
											Storyboard.SetTargetName(c192, "MonthView");
											Storyboard.SetTarget(c192, _MonthViewSubject);
											Storyboard.SetTargetProperty(c192, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c194)
										{
											Storyboard.SetTargetName(c194, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c194, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c194, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 1.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c196)
										{
											Storyboard.SetTargetName(c196, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c196, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c196, "Opacity");
										})
									}
								};
							});
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c197)
				{
					nameScope.RegisterName("DisplayModeStates", c197);
					DisplayModeStates = c197;
				})
			});
			c40.CreationComplete();
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
internal class _CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_CalendarView_themeresourcesRDSC1
{
	private class _CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_UnoUI__Resources_CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_CalendarView_themeresourcesRDSC1CalendarView_themeresourcesRDSC3
	{
		private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

		private ElementNameSubject _TextSubject = new ElementNameSubject();

		private ElementNameSubject _NormalSubject = new ElementNameSubject();

		private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

		private ElementNameSubject _PressedSubject = new ElementNameSubject();

		private ElementNameSubject _DisabledSubject = new ElementNameSubject();

		private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

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

		private ContentPresenter Text
		{
			get
			{
				return (ContentPresenter)_TextSubject.ElementInstance;
			}
			set
			{
				_TextSubject.ElementInstance = value;
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

		public UIElement Build(object __ResourceOwner_409)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new ContentPresenter
			{
				IsParsing = true,
				Name = "Text"
			}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ContentPresenter c350)
			{
				nameScope.RegisterName("Text", c350);
				Text = c350;
				c350.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c350.SetBinding(ContentPresenter.BackgroundSizingProperty, new Binding
				{
					Path = "BackgroundSizing",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				ResourceResolverSingleton.Instance.ApplyResource(c350, ContentPresenter.BorderBrushProperty, "CalendarViewNavigationButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
				c350.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c350.SetBinding(ContentPresenter.ContentProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c350.SetBinding(FrameworkElement.MarginProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c350.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c350.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				VisualStateManager.SetVisualStateGroups(c350, new VisualStateGroup[1] { new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c351)
						{
							nameScope.RegisterName("Normal", c351);
							Normal = c351;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c352)
						{
							nameScope.RegisterName("PointerOver", c352);
							PointerOver = c352;
							MarkupHelper.SetVisualStateLazy(c352, delegate
							{
								c352.Name = "PointerOver";
								c352.Setters.Add(new Setter(new TargetPropertyPath(_TextSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarViewNavigationButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c352.Setters.Add(new Setter(new TargetPropertyPath(_TextSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarViewNavigationButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c353)
						{
							nameScope.RegisterName("Pressed", c353);
							Pressed = c353;
							MarkupHelper.SetVisualStateLazy(c353, delegate
							{
								c353.Name = "Pressed";
								c353.Setters.Add(new Setter(new TargetPropertyPath(_TextSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CalendarViewNavigationButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Disabled"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c354)
						{
							nameScope.RegisterName("Disabled", c354);
							Disabled = c354;
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c355)
				{
					nameScope.RegisterName("CommonStates", c355);
					CommonStates = c355;
				}) });
				_component_0 = c350;
				c350.CreationComplete();
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

	private ElementNameSubject _HeaderButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PreviousButtonSubject = new ElementNameSubject();

	private ElementNameSubject _NextButtonSubject = new ElementNameSubject();

	private ElementNameSubject _BackgroundTransformSubject = new ElementNameSubject();

	private ElementNameSubject _BackgroundLayerSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewTransformSubject = new ElementNameSubject();

	private ElementNameSubject _WeekDay1Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay2Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay3Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay4Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay5Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay6Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDay7Subject = new ElementNameSubject();

	private ElementNameSubject _WeekDayNamesSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewPanelSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _MonthViewSubject = new ElementNameSubject();

	private ElementNameSubject _YearViewTransformSubject = new ElementNameSubject();

	private ElementNameSubject _YearViewPanelSubject = new ElementNameSubject();

	private ElementNameSubject _YearViewScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeViewTransformSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeViewPanelSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeViewScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _ViewsSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ViewChangedSubject = new ElementNameSubject();

	private ElementNameSubject _ViewChangingSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderButtonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _MonthSubject = new ElementNameSubject();

	private ElementNameSubject _YearSubject = new ElementNameSubject();

	private ElementNameSubject _DecadeSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayModeStatesSubject = new ElementNameSubject();

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

	private TextBlock _component_5
	{
		get
		{
			return (TextBlock)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private TextBlock _component_6
	{
		get
		{
			return (TextBlock)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private TextBlock _component_7
	{
		get
		{
			return (TextBlock)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private TextBlock _component_8
	{
		get
		{
			return (TextBlock)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private TextBlock _component_9
	{
		get
		{
			return (TextBlock)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer _component_10
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer _component_11
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer _component_12
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_component_12_Holder.Instance;
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

	private DiscreteObjectKeyFrame _component_15
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_16
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_16_Holder.Instance;
		}
		set
		{
			_component_16_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_17
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_17_Holder.Instance;
		}
		set
		{
			_component_17_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_18
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_18_Holder.Instance;
		}
		set
		{
			_component_18_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_19
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_19_Holder.Instance;
		}
		set
		{
			_component_19_Holder.Instance = value;
		}
	}

	private Button HeaderButton
	{
		get
		{
			return (Button)_HeaderButtonSubject.ElementInstance;
		}
		set
		{
			_HeaderButtonSubject.ElementInstance = value;
		}
	}

	private Button PreviousButton
	{
		get
		{
			return (Button)_PreviousButtonSubject.ElementInstance;
		}
		set
		{
			_PreviousButtonSubject.ElementInstance = value;
		}
	}

	private Button NextButton
	{
		get
		{
			return (Button)_NextButtonSubject.ElementInstance;
		}
		set
		{
			_NextButtonSubject.ElementInstance = value;
		}
	}

	private ScaleTransform BackgroundTransform
	{
		get
		{
			return (ScaleTransform)_BackgroundTransformSubject.ElementInstance;
		}
		set
		{
			_BackgroundTransformSubject.ElementInstance = value;
		}
	}

	private Border BackgroundLayer
	{
		get
		{
			return (Border)_BackgroundLayerSubject.ElementInstance;
		}
		set
		{
			_BackgroundLayerSubject.ElementInstance = value;
		}
	}

	private ScaleTransform MonthViewTransform
	{
		get
		{
			return (ScaleTransform)_MonthViewTransformSubject.ElementInstance;
		}
		set
		{
			_MonthViewTransformSubject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay1
	{
		get
		{
			return (TextBlock)_WeekDay1Subject.ElementInstance;
		}
		set
		{
			_WeekDay1Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay2
	{
		get
		{
			return (TextBlock)_WeekDay2Subject.ElementInstance;
		}
		set
		{
			_WeekDay2Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay3
	{
		get
		{
			return (TextBlock)_WeekDay3Subject.ElementInstance;
		}
		set
		{
			_WeekDay3Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay4
	{
		get
		{
			return (TextBlock)_WeekDay4Subject.ElementInstance;
		}
		set
		{
			_WeekDay4Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay5
	{
		get
		{
			return (TextBlock)_WeekDay5Subject.ElementInstance;
		}
		set
		{
			_WeekDay5Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay6
	{
		get
		{
			return (TextBlock)_WeekDay6Subject.ElementInstance;
		}
		set
		{
			_WeekDay6Subject.ElementInstance = value;
		}
	}

	private TextBlock WeekDay7
	{
		get
		{
			return (TextBlock)_WeekDay7Subject.ElementInstance;
		}
		set
		{
			_WeekDay7Subject.ElementInstance = value;
		}
	}

	private Grid WeekDayNames
	{
		get
		{
			return (Grid)_WeekDayNamesSubject.ElementInstance;
		}
		set
		{
			_WeekDayNamesSubject.ElementInstance = value;
		}
	}

	private CalendarPanel MonthViewPanel
	{
		get
		{
			return (CalendarPanel)_MonthViewPanelSubject.ElementInstance;
		}
		set
		{
			_MonthViewPanelSubject.ElementInstance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer MonthViewScrollViewer
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_MonthViewScrollViewerSubject.ElementInstance;
		}
		set
		{
			_MonthViewScrollViewerSubject.ElementInstance = value;
		}
	}

	private Grid MonthView
	{
		get
		{
			return (Grid)_MonthViewSubject.ElementInstance;
		}
		set
		{
			_MonthViewSubject.ElementInstance = value;
		}
	}

	private ScaleTransform YearViewTransform
	{
		get
		{
			return (ScaleTransform)_YearViewTransformSubject.ElementInstance;
		}
		set
		{
			_YearViewTransformSubject.ElementInstance = value;
		}
	}

	private CalendarPanel YearViewPanel
	{
		get
		{
			return (CalendarPanel)_YearViewPanelSubject.ElementInstance;
		}
		set
		{
			_YearViewPanelSubject.ElementInstance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer YearViewScrollViewer
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_YearViewScrollViewerSubject.ElementInstance;
		}
		set
		{
			_YearViewScrollViewerSubject.ElementInstance = value;
		}
	}

	private ScaleTransform DecadeViewTransform
	{
		get
		{
			return (ScaleTransform)_DecadeViewTransformSubject.ElementInstance;
		}
		set
		{
			_DecadeViewTransformSubject.ElementInstance = value;
		}
	}

	private CalendarPanel DecadeViewPanel
	{
		get
		{
			return (CalendarPanel)_DecadeViewPanelSubject.ElementInstance;
		}
		set
		{
			_DecadeViewPanelSubject.ElementInstance = value;
		}
	}

	private Windows.UI.Xaml.Controls.ScrollViewer DecadeViewScrollViewer
	{
		get
		{
			return (Windows.UI.Xaml.Controls.ScrollViewer)_DecadeViewScrollViewerSubject.ElementInstance;
		}
		set
		{
			_DecadeViewScrollViewerSubject.ElementInstance = value;
		}
	}

	private Grid Views
	{
		get
		{
			return (Grid)_ViewsSubject.ElementInstance;
		}
		set
		{
			_ViewsSubject.ElementInstance = value;
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

	private VisualState ViewChanged
	{
		get
		{
			return (VisualState)_ViewChangedSubject.ElementInstance;
		}
		set
		{
			_ViewChangedSubject.ElementInstance = value;
		}
	}

	private VisualState ViewChanging
	{
		get
		{
			return (VisualState)_ViewChangingSubject.ElementInstance;
		}
		set
		{
			_ViewChangingSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup HeaderButtonStates
	{
		get
		{
			return (VisualStateGroup)_HeaderButtonStatesSubject.ElementInstance;
		}
		set
		{
			_HeaderButtonStatesSubject.ElementInstance = value;
		}
	}

	private VisualState Month
	{
		get
		{
			return (VisualState)_MonthSubject.ElementInstance;
		}
		set
		{
			_MonthSubject.ElementInstance = value;
		}
	}

	private VisualState Year
	{
		get
		{
			return (VisualState)_YearSubject.ElementInstance;
		}
		set
		{
			_YearSubject.ElementInstance = value;
		}
	}

	private VisualState Decade
	{
		get
		{
			return (VisualState)_DecadeSubject.ElementInstance;
		}
		set
		{
			_DecadeSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DisplayModeStates
	{
		get
		{
			return (VisualStateGroup)_DisplayModeStatesSubject.ElementInstance;
		}
		set
		{
			_DisplayModeStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_361)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Resources = 
			{
				[(object)(__LinkerHints.Is_Windows_UI_Xaml_Controls_TextBlock_Available ? "WeekDayNameStyle" : null)] = (__LinkerHints.Is_Windows_UI_Xaml_Controls_TextBlock_Available ? new WeakResourceInitializer(__ResourceOwner_361, (object? __ResourceOwner_363) => new Style(typeof(TextBlock))
				{
					BasedOn = (Style)ResourceResolverSingleton.Instance.ResolveResourceStatic("CaptionTextBlockStyle", typeof(Style), GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_),
					Setters = 
					{
						(SetterBase)new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center),
						(SetterBase)new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
					}
				}) : null),
				[(object)(__LinkerHints.Is_Windows_UI_Xaml_Controls_Button_Available ? "NavigationButtonStyle" : null)] = (__LinkerHints.Is_Windows_UI_Xaml_Controls_Button_Available ? new WeakResourceInitializer(__ResourceOwner_361, (object? __ResourceOwner_364) => new Style(typeof(Button))
				{
					Setters = 
					{
						(SetterBase)new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch),
						(SetterBase)new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Stretch),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.UseSystemFocusVisualsProperty, "UseSystemFocusVisuals", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, false),
						(SetterBase)new Setter(Control.FontSizeProperty, 20.0),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(FrameworkElement.BackgroundProperty, "CalendarViewNavigationButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, null).ApplyThemeResourceUpdateValues("CalendarViewNavigationButtonBackground", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, isTheme: true, isHotReload: false),
						(SetterBase)new Setter(Control.BackgroundSizingProperty, BackgroundSizing.OuterBorderEdge),
						(SetterBase)new Setter(Control.TemplateProperty, __ResourceOwner_364, (object? __ResourceOwner_365) => new ControlTemplate(__ResourceOwner_365, (object? __owner) => new _CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_UnoUI__Resources_CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_CalendarView_themeresourcesRDSC1CalendarView_themeresourcesRDSC3().Build(__owner)))
					}
				}) : null),
				[(object)(__LinkerHints.Is_Windows_UI_Xaml_Controls_ScrollViewer_Available ? "ScrollViewerStyle" : null)] = (__LinkerHints.Is_Windows_UI_Xaml_Controls_ScrollViewer_Available ? new WeakResourceInitializer(__ResourceOwner_361, (object? __ResourceOwner_366) => new Style(typeof(Windows.UI.Xaml.Controls.ScrollViewer))
				{
					Setters = 
					{
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.HorizontalScrollModeProperty, ScrollMode.Disabled),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.VerticalScrollModeProperty, ScrollMode.Enabled),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.VerticalSnapPointsTypeProperty, SnapPointsType.Optional),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.ZoomModeProperty, ZoomMode.Disabled),
						(SetterBase)new Setter(Control.TabNavigationProperty, KeyboardNavigationMode.Once),
						(SetterBase)new Setter(Windows.UI.Xaml.Controls.ScrollViewer.BringIntoViewOnFocusChangeProperty, false),
						(SetterBase)SetterHelper.GetPropertySetterWithResourceValue(Control.TemplateProperty, "ScrollViewerScrollBarlessTemplate", GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_, null),
						(SetterBase)new Setter(Uno.UI.Xaml.Controls.ScrollViewer.ShouldFallBackToNativeScrollBarsProperty, false)
					}
				}) : null)
			},
			Child = new Grid
			{
				IsParsing = true,
				RowDefinitions = 
				{
					new RowDefinition
					{
						Height = new GridLength(40.0, GridUnitType.Pixel)
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
						ColumnDefinitions = 
						{
							new ColumnDefinition
							{
								Width = new GridLength(5.0, GridUnitType.Star)
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
						Children = 
						{
							(UIElement)new Button
							{
								IsParsing = true,
								Name = "HeaderButton",
								Padding = new Thickness(12.0, 0.0, 0.0, 0.0),
								HorizontalContentAlignment = HorizontalAlignment.Left
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Button c209)
							{
								nameScope.RegisterName("HeaderButton", c209);
								HeaderButton = c209;
								c209.SetBinding(ContentControl.ContentProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HeaderText"
								});
								c209.SetBinding(Control.IsEnabledProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HasMoreViews"
								});
								ResourceResolverSingleton.Instance.ApplyResource(c209, FrameworkElement.StyleProperty, "NavigationButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								c209.SetBinding(Control.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								_component_0 = c209;
								c209.CreationComplete();
							}),
							(UIElement)new Button
							{
								IsParsing = true,
								Name = "PreviousButton",
								Content = "\ue0e4",
								IsTabStop = true,
								Padding = new Thickness(1.0),
								HorizontalContentAlignment = HorizontalAlignment.Center
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Button c210)
							{
								nameScope.RegisterName("PreviousButton", c210);
								PreviousButton = c210;
								Grid.SetColumn(c210, 1);
								ResourceResolverSingleton.Instance.ApplyResource(c210, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								c210.SetBinding(Control.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c210.SetBinding(Control.IsEnabledProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HasMoreContentBefore"
								});
								ResourceResolverSingleton.Instance.ApplyResource(c210, FrameworkElement.StyleProperty, "NavigationButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_1 = c210;
								c210.CreationComplete();
							}),
							(UIElement)new Button
							{
								IsParsing = true,
								Name = "NextButton",
								Content = "\ue0e5",
								IsTabStop = true,
								Padding = new Thickness(1.0),
								HorizontalContentAlignment = HorizontalAlignment.Center
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Button c211)
							{
								nameScope.RegisterName("NextButton", c211);
								NextButton = c211;
								Grid.SetColumn(c211, 2);
								ResourceResolverSingleton.Instance.ApplyResource(c211, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								c211.SetBinding(Control.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c211.SetBinding(Control.IsEnabledProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.HasMoreContentAfter"
								});
								ResourceResolverSingleton.Instance.ApplyResource(c211, FrameworkElement.StyleProperty, "NavigationButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_2 = c211;
								c211.CreationComplete();
							})
						}
					}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c212)
					{
						c212.CreationComplete();
					}),
					(UIElement)new Grid
					{
						IsParsing = true,
						Name = "Views",
						Children = 
						{
							(UIElement)new Border
							{
								IsParsing = true,
								Name = "BackgroundLayer",
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c213)
								{
									nameScope.RegisterName("BackgroundTransform", c213);
									BackgroundTransform = c213;
									c213.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c213.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								})
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Border c214)
							{
								nameScope.RegisterName("BackgroundLayer", c214);
								BackgroundLayer = c214;
								c214.SetBinding(FrameworkElement.BackgroundProperty, new Binding
								{
									Path = "BorderBrush",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c214.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "MonthView",
								RowDefinitions = 
								{
									new RowDefinition
									{
										Height = new GridLength(38.0, GridUnitType.Pixel)
									},
									new RowDefinition
									{
										Height = new GridLength(1.0, GridUnitType.Star)
									}
								},
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c217)
								{
									nameScope.RegisterName("MonthViewTransform", c217);
									MonthViewTransform = c217;
									c217.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c217.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								}),
								Children = 
								{
									(UIElement)new Grid
									{
										IsParsing = true,
										Name = "WeekDayNames",
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
											},
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
											},
											new ColumnDefinition
											{
												Width = new GridLength(1.0, GridUnitType.Star)
											}
										},
										Children = 
										{
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay1"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c225)
											{
												nameScope.RegisterName("WeekDay1", c225);
												WeekDay1 = c225;
												c225.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay1"
												});
												c225.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c225, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_3 = c225;
												c225.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay2"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c226)
											{
												nameScope.RegisterName("WeekDay2", c226);
												WeekDay2 = c226;
												Grid.SetColumn(c226, 1);
												c226.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay2"
												});
												c226.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c226, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_4 = c226;
												c226.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay3"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c227)
											{
												nameScope.RegisterName("WeekDay3", c227);
												WeekDay3 = c227;
												Grid.SetColumn(c227, 2);
												c227.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay3"
												});
												c227.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c227, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_5 = c227;
												c227.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay4"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c228)
											{
												nameScope.RegisterName("WeekDay4", c228);
												WeekDay4 = c228;
												Grid.SetColumn(c228, 3);
												c228.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay4"
												});
												c228.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c228, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_6 = c228;
												c228.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay5"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c229)
											{
												nameScope.RegisterName("WeekDay5", c229);
												WeekDay5 = c229;
												Grid.SetColumn(c229, 4);
												c229.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay5"
												});
												c229.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c229, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_7 = c229;
												c229.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay6"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c230)
											{
												nameScope.RegisterName("WeekDay6", c230);
												WeekDay6 = c230;
												Grid.SetColumn(c230, 5);
												c230.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay6"
												});
												c230.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c230, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_8 = c230;
												c230.CreationComplete();
											}),
											(UIElement)new TextBlock
											{
												IsParsing = true,
												Name = "WeekDay7"
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(TextBlock c231)
											{
												nameScope.RegisterName("WeekDay7", c231);
												WeekDay7 = c231;
												Grid.SetColumn(c231, 6);
												c231.SetBinding(TextBlock.TextProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.WeekDay7"
												});
												c231.SetBinding(TextBlock.ForegroundProperty, new Binding
												{
													Path = "CalendarItemForeground",
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
												});
												ResourceResolverSingleton.Instance.ApplyResource(c231, FrameworkElement.StyleProperty, "WeekDayNameStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_9 = c231;
												c231.CreationComplete();
											})
										}
									}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c232)
									{
										nameScope.RegisterName("WeekDayNames", c232);
										WeekDayNames = c232;
										c232.SetBinding(FrameworkElement.BackgroundProperty, new Binding
										{
											Path = "Background",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c232.CreationComplete();
									}),
									(UIElement)new Windows.UI.Xaml.Controls.ScrollViewer
									{
										IsParsing = true,
										Name = "MonthViewScrollViewer",
										IsFocusEngagementEnabled = true,
										Content = new CalendarPanel
										{
											IsParsing = true,
											Name = "MonthViewPanel"
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(CalendarPanel c233)
										{
											nameScope.RegisterName("MonthViewPanel", c233);
											MonthViewPanel = c233;
											c233.CreationComplete();
										})
									}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Windows.UI.Xaml.Controls.ScrollViewer c234)
									{
										nameScope.RegisterName("MonthViewScrollViewer", c234);
										MonthViewScrollViewer = c234;
										Grid.SetRow(c234, 1);
										ResourceResolverSingleton.Instance.ApplyResource(c234, FrameworkElement.StyleProperty, "ScrollViewerStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
										_component_10 = c234;
										c234.CreationComplete();
									})
								}
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c235)
							{
								nameScope.RegisterName("MonthView", c235);
								MonthView = c235;
								c235.CreationComplete();
							}),
							(UIElement)new Windows.UI.Xaml.Controls.ScrollViewer
							{
								IsParsing = true,
								Name = "YearViewScrollViewer",
								UseLayoutRounding = false,
								Opacity = 0.0,
								Visibility = Visibility.Collapsed,
								IsFocusEngagementEnabled = true,
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c236)
								{
									nameScope.RegisterName("YearViewTransform", c236);
									YearViewTransform = c236;
									c236.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c236.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								}),
								Content = new CalendarPanel
								{
									IsParsing = true,
									Name = "YearViewPanel"
								}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(CalendarPanel c237)
								{
									nameScope.RegisterName("YearViewPanel", c237);
									YearViewPanel = c237;
									c237.CreationComplete();
								})
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Windows.UI.Xaml.Controls.ScrollViewer c238)
							{
								nameScope.RegisterName("YearViewScrollViewer", c238);
								YearViewScrollViewer = c238;
								ResourceResolverSingleton.Instance.ApplyResource(c238, FrameworkElement.StyleProperty, "ScrollViewerStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_11 = c238;
								c238.CreationComplete();
							}),
							(UIElement)new Windows.UI.Xaml.Controls.ScrollViewer
							{
								IsParsing = true,
								Name = "DecadeViewScrollViewer",
								UseLayoutRounding = false,
								IsFocusEngagementEnabled = true,
								Opacity = 0.0,
								Visibility = Visibility.Collapsed,
								RenderTransform = new ScaleTransform().CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ScaleTransform c239)
								{
									nameScope.RegisterName("DecadeViewTransform", c239);
									DecadeViewTransform = c239;
									c239.SetBinding(ScaleTransform.CenterXProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterX"
									});
									c239.SetBinding(ScaleTransform.CenterYProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.CenterY"
									});
								}),
								Content = new CalendarPanel
								{
									IsParsing = true,
									Name = "DecadeViewPanel"
								}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(CalendarPanel c240)
								{
									nameScope.RegisterName("DecadeViewPanel", c240);
									DecadeViewPanel = c240;
									c240.CreationComplete();
								})
							}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Windows.UI.Xaml.Controls.ScrollViewer c241)
							{
								nameScope.RegisterName("DecadeViewScrollViewer", c241);
								DecadeViewScrollViewer = c241;
								ResourceResolverSingleton.Instance.ApplyResource(c241, FrameworkElement.StyleProperty, "ScrollViewerStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
								_component_12 = c241;
								c241.CreationComplete();
							})
						}
					}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c242)
					{
						nameScope.RegisterName("Views", c242);
						Views = c242;
						Grid.SetRow(c242, 1);
						c242.CreationComplete();
					})
				}
			}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Grid c243)
			{
				c243.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c243.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c243.SetBinding(FrameworkElement.MinWidthProperty, new Binding
				{
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
					Path = "TemplateSettings.MinViewWidth"
				});
				c243.CreationComplete();
			})
		}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(Border c244)
		{
			c244.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c244.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c244.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c244.SetBinding(Border.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c244, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c245)
						{
							nameScope.RegisterName("Normal", c245);
							Normal = c245;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c246)
						{
							nameScope.RegisterName("Disabled", c246);
							Disabled = c246;
							MarkupHelper.SetVisualStateLazy(c246, delegate
							{
								c246.Name = "Disabled";
								c246.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c247)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c247, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_13 = c247;
												NameScope.SetNameScope(_component_13, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c248)
										{
											Storyboard.SetTargetName(c248, "WeekDay1");
											Storyboard.SetTarget(c248, _WeekDay1Subject);
											Storyboard.SetTargetProperty(c248, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c249)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c249, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_14 = c249;
												NameScope.SetNameScope(_component_14, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c250)
										{
											Storyboard.SetTargetName(c250, "WeekDay2");
											Storyboard.SetTarget(c250, _WeekDay2Subject);
											Storyboard.SetTargetProperty(c250, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c251)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c251, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_15 = c251;
												NameScope.SetNameScope(_component_15, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c252)
										{
											Storyboard.SetTargetName(c252, "WeekDay3");
											Storyboard.SetTarget(c252, _WeekDay3Subject);
											Storyboard.SetTargetProperty(c252, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c253)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c253, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_16 = c253;
												NameScope.SetNameScope(_component_16, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c254)
										{
											Storyboard.SetTargetName(c254, "WeekDay4");
											Storyboard.SetTarget(c254, _WeekDay4Subject);
											Storyboard.SetTargetProperty(c254, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c255)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c255, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_17 = c255;
												NameScope.SetNameScope(_component_17, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c256)
										{
											Storyboard.SetTargetName(c256, "WeekDay5");
											Storyboard.SetTarget(c256, _WeekDay5Subject);
											Storyboard.SetTargetProperty(c256, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c257)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c257, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_18 = c257;
												NameScope.SetNameScope(_component_18, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c258)
										{
											Storyboard.SetTargetName(c258, "WeekDay6");
											Storyboard.SetTarget(c258, _WeekDay6Subject);
											Storyboard.SetTargetProperty(c258, "Foreground");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DiscreteObjectKeyFrame c259)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c259, ObjectKeyFrame.ValueProperty, "CalendarViewWeekDayForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__2.Instance.__ParseContext_);
												_component_19 = c259;
												NameScope.SetNameScope(_component_19, nameScope);
											}) }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c260)
										{
											Storyboard.SetTargetName(c260, "WeekDay7");
											Storyboard.SetTarget(c260, _WeekDay7Subject);
											Storyboard.SetTargetProperty(c260, "Foreground");
										})
									}
								};
							});
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c261)
				{
					nameScope.RegisterName("CommonStates", c261);
					CommonStates = c261;
				}),
				new VisualStateGroup
				{
					Name = "HeaderButtonStates",
					States = 
					{
						new VisualState
						{
							Name = "ViewChanged"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c262)
						{
							nameScope.RegisterName("ViewChanged", c262);
							ViewChanged = c262;
						}),
						new VisualState
						{
							Name = "ViewChanging"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c263)
						{
							nameScope.RegisterName("ViewChanging", c263);
							ViewChanging = c263;
							MarkupHelper.SetVisualStateLazy(c263, delegate
							{
								c263.Name = "ViewChanging";
								c263.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DoubleAnimation
									{
										From = 0.0,
										To = 1.0,
										Duration = new Duration(TimeSpan.FromTicks(1670000L))
									}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimation c264)
									{
										Storyboard.SetTargetName(c264, "HeaderButton");
										Storyboard.SetTarget(c264, _HeaderButtonSubject);
										Storyboard.SetTargetProperty(c264, "Opacity");
									}) }
								};
							});
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c265)
				{
					nameScope.RegisterName("HeaderButtonStates", c265);
					HeaderButtonStates = c265;
				}),
				new VisualStateGroup
				{
					Name = "DisplayModeStates",
					Transitions = 
					{
						new VisualTransition
						{
							From = "Month",
							To = "Year"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c266)
						{
							MarkupHelper.SetVisualTransitionLazy(c266, delegate
							{
								c266.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c268)
										{
											Storyboard.SetTargetName(c268, "MonthView");
											Storyboard.SetTarget(c268, _MonthViewSubject);
											Storyboard.SetTargetProperty(c268, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c272)
										{
											Storyboard.SetTargetName(c272, "YearViewScrollViewer");
											Storyboard.SetTarget(c272, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c272, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c274)
										{
											Storyboard.SetTargetName(c274, "YearViewScrollViewer");
											Storyboard.SetTarget(c274, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c274, "Visibility");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c278)
										{
											Storyboard.SetTargetName(c278, "BackgroundLayer");
											Storyboard.SetTarget(c278, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c278, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "Year",
							To = "Month"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c279)
						{
							MarkupHelper.SetVisualTransitionLazy(c279, delegate
							{
								c279.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c281)
										{
											Storyboard.SetTargetName(c281, "YearViewScrollViewer");
											Storyboard.SetTarget(c281, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c281, "IsHitTestVisible");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c283)
										{
											Storyboard.SetTargetName(c283, "YearViewScrollViewer");
											Storyboard.SetTarget(c283, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c283, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c285)
										{
											Storyboard.SetTargetName(c285, "YearViewScrollViewer");
											Storyboard.SetTarget(c285, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c285, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c289)
										{
											Storyboard.SetTargetName(c289, "MonthView");
											Storyboard.SetTarget(c289, _MonthViewSubject);
											Storyboard.SetTargetProperty(c289, "Opacity");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c293)
										{
											Storyboard.SetTargetName(c293, "BackgroundLayer");
											Storyboard.SetTarget(c293, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c293, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "Year",
							To = "Decade"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c294)
						{
							MarkupHelper.SetVisualTransitionLazy(c294, delegate
							{
								c294.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c296)
										{
											Storyboard.SetTargetName(c296, "MonthView");
											Storyboard.SetTarget(c296, _MonthViewSubject);
											Storyboard.SetTargetProperty(c296, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c298)
										{
											Storyboard.SetTargetName(c298, "YearViewScrollViewer");
											Storyboard.SetTarget(c298, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c298, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c300)
										{
											Storyboard.SetTargetName(c300, "YearViewScrollViewer");
											Storyboard.SetTarget(c300, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c300, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c304)
										{
											Storyboard.SetTargetName(c304, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c304, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c304, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c306)
										{
											Storyboard.SetTargetName(c306, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c306, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c306, "Visibility");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c310)
										{
											Storyboard.SetTargetName(c310, "BackgroundLayer");
											Storyboard.SetTarget(c310, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c310, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "Decade",
							To = "Year"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualTransition c311)
						{
							MarkupHelper.SetVisualTransitionLazy(c311, delegate
							{
								c311.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c313)
										{
											Storyboard.SetTargetName(c313, "MonthView");
											Storyboard.SetTarget(c313, _MonthViewSubject);
											Storyboard.SetTargetProperty(c313, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c315)
										{
											Storyboard.SetTargetName(c315, "YearViewScrollViewer");
											Storyboard.SetTarget(c315, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c315, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c317)
										{
											Storyboard.SetTargetName(c317, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c317, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c317, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c319)
										{
											Storyboard.SetTargetName(c319, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c319, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c319, "IsHitTestVisible");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2330000L),
												Value = 0.0,
												KeySpline = "0.1,0.9,0.2,1"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c321)
										{
											Storyboard.SetTargetName(c321, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c321, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c321, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(2330000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.1,0.9,0.2,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c325)
										{
											Storyboard.SetTargetName(c325, "YearViewScrollViewer");
											Storyboard.SetTarget(c325, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c325, "Opacity");
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
													KeyTime = TimeSpan.FromTicks(2500000L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(7330000L),
													Value = 1.0,
													KeySpline = "0.15,0.64,0.25,1"
												}
											}
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c329)
										{
											Storyboard.SetTargetName(c329, "BackgroundLayer");
											Storyboard.SetTarget(c329, _BackgroundLayerSubject);
											Storyboard.SetTargetProperty(c329, "Opacity");
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
							Name = "Month"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c330)
						{
							nameScope.RegisterName("Month", c330);
							Month = c330;
						}),
						new VisualState
						{
							Name = "Year"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c331)
						{
							nameScope.RegisterName("Year", c331);
							Year = c331;
							MarkupHelper.SetVisualStateLazy(c331, delegate
							{
								c331.Name = "Year";
								c331.Setters.Add(new Setter(new TargetPropertyPath(_YearViewScrollViewerSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c331.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c333)
										{
											Storyboard.SetTargetName(c333, "MonthViewScrollViewer");
											Storyboard.SetTarget(c333, _MonthViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c333, "IsEnabled");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "0"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c335)
										{
											Storyboard.SetTargetName(c335, "MonthView");
											Storyboard.SetTarget(c335, _MonthViewSubject);
											Storyboard.SetTargetProperty(c335, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c337)
										{
											Storyboard.SetTargetName(c337, "YearViewScrollViewer");
											Storyboard.SetTarget(c337, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c337, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 1.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c339)
										{
											Storyboard.SetTargetName(c339, "YearViewScrollViewer");
											Storyboard.SetTarget(c339, _YearViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c339, "Opacity");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Decade"
						}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualState c340)
						{
							nameScope.RegisterName("Decade", c340);
							Decade = c340;
							MarkupHelper.SetVisualStateLazy(c340, delegate
							{
								c340.Name = "Decade";
								c340.Setters.Add(new Setter(new TargetPropertyPath(_DecadeViewScrollViewerSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c340.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c342)
										{
											Storyboard.SetTargetName(c342, "MonthViewScrollViewer");
											Storyboard.SetTarget(c342, _MonthViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c342, "IsEnabled");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "0"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c344)
										{
											Storyboard.SetTargetName(c344, "MonthView");
											Storyboard.SetTarget(c344, _MonthViewSubject);
											Storyboard.SetTargetProperty(c344, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(ObjectAnimationUsingKeyFrames c346)
										{
											Storyboard.SetTargetName(c346, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c346, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c346, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 1.0
											} }
										}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(DoubleAnimationUsingKeyFrames c348)
										{
											Storyboard.SetTargetName(c348, "DecadeViewScrollViewer");
											Storyboard.SetTarget(c348, _DecadeViewScrollViewerSubject);
											Storyboard.SetTargetProperty(c348, "Opacity");
										})
									}
								};
							});
						})
					}
				}.CalendarView_themeresources_77a12d2adfdb1a6f2a5d799cd97fe3e9_XamlApply(delegate(VisualStateGroup c349)
				{
					nameScope.RegisterName("DisplayModeStates", c349);
					DisplayModeStates = c349;
				})
			});
			c244.CreationComplete();
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

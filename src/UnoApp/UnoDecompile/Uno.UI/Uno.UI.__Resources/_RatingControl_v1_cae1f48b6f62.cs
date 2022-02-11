using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_RatingControl_v1RDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _RatingBackgroundStackPanelSubject = new ElementNameSubject();

	private ElementNameSubject _CaptionSubject = new ElementNameSubject();

	private ElementNameSubject _RatingForegroundStackPanelSubject = new ElementNameSubject();

	private ElementNameSubject _ForegroundContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _PlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverPlaceholderSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverUnselectedSubject = new ElementNameSubject();

	private ElementNameSubject _SetSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSetSubject = new ElementNameSubject();

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

	private StackPanel RatingBackgroundStackPanel
	{
		get
		{
			return (StackPanel)_RatingBackgroundStackPanelSubject.ElementInstance;
		}
		set
		{
			_RatingBackgroundStackPanelSubject.ElementInstance = value;
		}
	}

	private TextBlock Caption
	{
		get
		{
			return (TextBlock)_CaptionSubject.ElementInstance;
		}
		set
		{
			_CaptionSubject.ElementInstance = value;
		}
	}

	private StackPanel RatingForegroundStackPanel
	{
		get
		{
			return (StackPanel)_RatingForegroundStackPanelSubject.ElementInstance;
		}
		set
		{
			_RatingForegroundStackPanelSubject.ElementInstance = value;
		}
	}

	private ContentPresenter ForegroundContentPresenter
	{
		get
		{
			return (ContentPresenter)_ForegroundContentPresenterSubject.ElementInstance;
		}
		set
		{
			_ForegroundContentPresenterSubject.ElementInstance = value;
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

	private VisualState Placeholder
	{
		get
		{
			return (VisualState)_PlaceholderSubject.ElementInstance;
		}
		set
		{
			_PlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualState PointerOverPlaceholder
	{
		get
		{
			return (VisualState)_PointerOverPlaceholderSubject.ElementInstance;
		}
		set
		{
			_PointerOverPlaceholderSubject.ElementInstance = value;
		}
	}

	private VisualState PointerOverUnselected
	{
		get
		{
			return (VisualState)_PointerOverUnselectedSubject.ElementInstance;
		}
		set
		{
			_PointerOverUnselectedSubject.ElementInstance = value;
		}
	}

	private VisualState Set
	{
		get
		{
			return (VisualState)_SetSubject.ElementInstance;
		}
		set
		{
			_SetSubject.ElementInstance = value;
		}
	}

	private VisualState PointerOverSet
	{
		get
		{
			return (VisualState)_PointerOverSetSubject.ElementInstance;
		}
		set
		{
			_PointerOverSetSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_1672)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Children = 
			{
				(UIElement)new StackPanel
				{
					IsParsing = true,
					Orientation = Orientation.Horizontal,
					Margin = new Thickness(-20.0, -20.0, -20.0, -20.0),
					Children = 
					{
						(UIElement)new StackPanel
						{
							IsParsing = true,
							Name = "RatingBackgroundStackPanel",
							Orientation = Orientation.Horizontal,
							Background = SolidColorBrushHelper.Transparent,
							Margin = new Thickness(20.0, 20.0, 0.0, 20.0)
						}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(StackPanel c0)
						{
							nameScope.RegisterName("RatingBackgroundStackPanel", c0);
							RatingBackgroundStackPanel = c0;
							c0.CreationComplete();
						}),
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Name = "Caption",
							Height = 32.0,
							Margin = new Thickness(4.0, 9.0, 20.0, 0.0),
							TextLineBounds = TextLineBounds.TrimToBaseline,
							VerticalAlignment = VerticalAlignment.Center,
							IsHitTestVisible = false
						}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(TextBlock c1)
						{
							nameScope.RegisterName("Caption", c1);
							Caption = c1;
							ResourceResolverSingleton.Instance.ApplyResource(c1, FrameworkElement.StyleProperty, "CaptionTextBlockStyle", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c1, AccessibilityView.Raw);
							nameScope.RegisterName("RatingCaption", c1);
							AutomationProperties.SetName(c1, "RatingCaption");
							c1.SetBinding(TextBlock.TextProperty, new Binding
							{
								Path = "Caption",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							_component_0 = c1;
							c1.CreationComplete();
						})
					}
				}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(StackPanel c2)
				{
					Grid.SetRow(c2, 0);
					c2.CreationComplete();
				}),
				(UIElement)new ContentPresenter
				{
					IsParsing = true,
					Name = "ForegroundContentPresenter",
					IsHitTestVisible = false,
					Content = new StackPanel
					{
						IsParsing = true,
						Orientation = Orientation.Horizontal,
						Margin = new Thickness(-40.0, -40.0, -40.0, -40.0),
						Children = { (UIElement)new StackPanel
						{
							IsParsing = true,
							Name = "RatingForegroundStackPanel",
							Orientation = Orientation.Horizontal,
							IsHitTestVisible = false,
							Margin = new Thickness(40.0, 40.0, 40.0, 40.0)
						}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(StackPanel c3)
						{
							nameScope.RegisterName("RatingForegroundStackPanel", c3);
							RatingForegroundStackPanel = c3;
							c3.CreationComplete();
						}) }
					}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(StackPanel c4)
					{
						c4.CreationComplete();
					})
				}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(ContentPresenter c5)
				{
					nameScope.RegisterName("ForegroundContentPresenter", c5);
					ForegroundContentPresenter = c5;
					Grid.SetRow(c5, 0);
					c5.CreationComplete();
				})
			}
		}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(Grid c6)
		{
			nameScope.RegisterName("LayoutRoot", c6);
			LayoutRoot = c6;
			VisualStateManager.SetVisualStateGroups(c6, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Disabled"
					}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(VisualState c7)
					{
						nameScope.RegisterName("Disabled", c7);
						Disabled = c7;
						MarkupHelper.SetVisualStateLazy(c7, delegate
						{
							c7.Name = "Disabled";
							c7.Setters.Add(new Setter(new TargetPropertyPath(_ForegroundContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("RatingControlDisabledSelectedForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("RatingControlDisabledSelectedForeground", GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Placeholder"
					}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(VisualState c8)
					{
						nameScope.RegisterName("Placeholder", c8);
						Placeholder = c8;
						MarkupHelper.SetVisualStateLazy(c8, delegate
						{
							c8.Name = "Placeholder";
							c8.Setters.Add(new Setter(new TargetPropertyPath(_ForegroundContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("RatingControlPlaceholderForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("RatingControlPlaceholderForeground", GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "PointerOverPlaceholder"
					}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(VisualState c9)
					{
						nameScope.RegisterName("PointerOverPlaceholder", c9);
						PointerOverPlaceholder = c9;
						MarkupHelper.SetVisualStateLazy(c9, delegate
						{
							c9.Name = "PointerOverPlaceholder";
							c9.Setters.Add(new Setter(new TargetPropertyPath(_ForegroundContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("RatingControlPointerOverPlaceholderForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("RatingControlPointerOverPlaceholderForeground", GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "PointerOverUnselected"
					}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(VisualState c10)
					{
						nameScope.RegisterName("PointerOverUnselected", c10);
						PointerOverUnselected = c10;
						MarkupHelper.SetVisualStateLazy(c10, delegate
						{
							c10.Name = "PointerOverUnselected";
							c10.Setters.Add(new Setter(new TargetPropertyPath(_ForegroundContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("RatingControlPointerOverUnselectedForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("RatingControlPointerOverUnselectedForeground", GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Set"
					}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(VisualState c11)
					{
						nameScope.RegisterName("Set", c11);
						Set = c11;
						MarkupHelper.SetVisualStateLazy(c11, delegate
						{
							c11.Name = "Set";
							c11.Setters.Add(new Setter(new TargetPropertyPath(_ForegroundContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("RatingControlSelectedForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("RatingControlSelectedForeground", GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "PointerOverSet"
					}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(VisualState c12)
					{
						nameScope.RegisterName("PointerOverSet", c12);
						PointerOverSet = c12;
						MarkupHelper.SetVisualStateLazy(c12, delegate
						{
							c12.Name = "PointerOverSet";
							c12.Setters.Add(new Setter(new TargetPropertyPath(_ForegroundContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("RatingControlSelectedForeground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("RatingControlSelectedForeground", GlobalStaticResources.ResourceDictionarySingleton__63.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.RatingControl_v1_cae1f48b6f6254b8be9d4fe0a4243939_XamlApply(delegate(VisualStateGroup c13)
			{
				nameScope.RegisterName("CommonStates", c13);
				CommonStates = c13;
			}) });
			c6.CreationComplete();
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

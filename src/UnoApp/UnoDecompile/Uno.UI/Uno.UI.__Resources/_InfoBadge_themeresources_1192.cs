using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_InfoBadge_themeresourcesRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ValueTextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _IconPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _DotSubject = new ElementNameSubject();

	private ElementNameSubject _IconSubject = new ElementNameSubject();

	private ElementNameSubject _FontIconSubject = new ElementNameSubject();

	private ElementNameSubject _ValueSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayKindStatesSubject = new ElementNameSubject();

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

	private TextBlock ValueTextBlock
	{
		get
		{
			return (TextBlock)_ValueTextBlockSubject.ElementInstance;
		}
		set
		{
			_ValueTextBlockSubject.ElementInstance = value;
		}
	}

	private Viewbox IconPresenter
	{
		get
		{
			return (Viewbox)_IconPresenterSubject.ElementInstance;
		}
		set
		{
			_IconPresenterSubject.ElementInstance = value;
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

	private VisualState Dot
	{
		get
		{
			return (VisualState)_DotSubject.ElementInstance;
		}
		set
		{
			_DotSubject.ElementInstance = value;
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

	private VisualState FontIcon
	{
		get
		{
			return (VisualState)_FontIconSubject.ElementInstance;
		}
		set
		{
			_FontIconSubject.ElementInstance = value;
		}
	}

	private VisualState Value
	{
		get
		{
			return (VisualState)_ValueSubject.ElementInstance;
		}
		set
		{
			_ValueSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DisplayKindStates
	{
		get
		{
			return (VisualStateGroup)_DisplayKindStatesSubject.ElementInstance;
		}
		set
		{
			_DisplayKindStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2855)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = 
			{
				(UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "ValueTextBlock",
					Visibility = Visibility.Collapsed,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(TextBlock c5)
				{
					nameScope.RegisterName("ValueTextBlock", c5);
					ValueTextBlock = c5;
					c5.SetBinding(TextBlock.TextProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "Value",
						Mode = BindingMode.OneWay
					});
					ResourceResolverSingleton.Instance.ApplyResource(c5, TextBlock.FontSizeProperty, "InfoBadgeValueFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__21.Instance.__ParseContext_);
					_component_0 = c5;
					c5.CreationComplete();
				}),
				(UIElement)new Viewbox
				{
					IsParsing = true,
					Name = "IconPresenter",
					Visibility = Visibility.Collapsed,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Stretch,
					Child = new ContentPresenter
					{
						IsParsing = true
					}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(ContentPresenter c6)
					{
						c6.SetBinding(ContentPresenter.ContentProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "TemplateSettings.IconElement"
						});
						c6.CreationComplete();
					})
				}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(Viewbox c7)
				{
					nameScope.RegisterName("IconPresenter", c7);
					IconPresenter = c7;
					c7.CreationComplete();
				})
			}
		}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(Grid c8)
		{
			nameScope.RegisterName("RootGrid", c8);
			RootGrid = c8;
			c8.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c8.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
				Path = "TemplateSettings.InfoBadgeCornerRadius"
			});
			c8.SetBinding(Grid.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c8, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "DisplayKindStates",
				States = 
				{
					new VisualState
					{
						Name = "Dot"
					}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(VisualState c9)
					{
						nameScope.RegisterName("Dot", c9);
						Dot = c9;
					}),
					new VisualState
					{
						Name = "Icon"
					}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(VisualState c10)
					{
						nameScope.RegisterName("Icon", c10);
						Icon = c10;
						MarkupHelper.SetVisualStateLazy(c10, delegate
						{
							c10.Name = "Icon";
							c10.Setters.Add(new Setter(new TargetPropertyPath(_IconPresenterSubject, (PropertyPath)"Visibility"), "Visible"));
							c10.Setters.Add(new Setter(new TargetPropertyPath(_IconPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("IconInfoBadgeIconMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__21.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("IconInfoBadgeIconMargin", GlobalStaticResources.ResourceDictionarySingleton__21.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "FontIcon"
					}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(VisualState c11)
					{
						nameScope.RegisterName("FontIcon", c11);
						FontIcon = c11;
						MarkupHelper.SetVisualStateLazy(c11, delegate
						{
							c11.Name = "FontIcon";
							c11.Setters.Add(new Setter(new TargetPropertyPath(_IconPresenterSubject, (PropertyPath)"Visibility"), "Visible"));
							c11.Setters.Add(new Setter(new TargetPropertyPath(_IconPresenterSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("IconInfoBadgeFontIconMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__21.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("IconInfoBadgeFontIconMargin", GlobalStaticResources.ResourceDictionarySingleton__21.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Value"
					}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(VisualState c12)
					{
						nameScope.RegisterName("Value", c12);
						Value = c12;
						MarkupHelper.SetVisualStateLazy(c12, delegate
						{
							c12.Name = "Value";
							c12.Setters.Add(new Setter(new TargetPropertyPath(_ValueTextBlockSubject, (PropertyPath)"Visibility"), "Visible"));
							c12.Setters.Add(new Setter(new TargetPropertyPath(_ValueTextBlockSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ValueInfoBadgeTextMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__21.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ValueInfoBadgeTextMargin", GlobalStaticResources.ResourceDictionarySingleton__21.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.InfoBadge_themeresources_1192177b128fe6ce2f6a3baf379af4c9_XamlApply(delegate(VisualStateGroup c13)
			{
				nameScope.RegisterName("DisplayKindStates", c13);
				DisplayKindStates = c13;
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

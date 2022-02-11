using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uno.UI.__Resources;

internal class _SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_SwipeControl_themeresources_v1RDSC0
{
	private ElementNameSubject _ContentSubject = new ElementNameSubject();

	private ElementNameSubject _TextLabelSubject = new ElementNameSubject();

	private ElementNameSubject _ContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ContentPresenter Content
	{
		get
		{
			return (ContentPresenter)_ContentSubject.ElementInstance;
		}
		set
		{
			_ContentSubject.ElementInstance = value;
		}
	}

	private TextBlock TextLabel
	{
		get
		{
			return (TextBlock)_TextLabelSubject.ElementInstance;
		}
		set
		{
			_TextLabelSubject.ElementInstance = value;
		}
	}

	private Grid ContentRoot
	{
		get
		{
			return (Grid)_ContentRootSubject.ElementInstance;
		}
		set
		{
			_ContentRootSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_381)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = { (UIElement)new Grid
			{
				IsParsing = true,
				Name = "ContentRoot",
				Margin = new Thickness(4.0, 4.0, 4.0, 2.0),
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center,
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
					(UIElement)new Viewbox
					{
						IsParsing = true,
						MaxHeight = 16.0,
						MinWidth = 16.0,
						Child = new ContentPresenter
						{
							IsParsing = true,
							Name = "Content",
							Margin = new Thickness(0.0, 0.0, 0.0, 2.0)
						}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(ContentPresenter c2)
						{
							nameScope.RegisterName("Content", c2);
							Content = c2;
							c2.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Icon",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.CreationComplete();
						})
					}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(Viewbox c3)
					{
						c3.CreationComplete();
					}),
					(UIElement)new TextBlock
					{
						IsParsing = true,
						Name = "TextLabel",
						FontSize = 12.0,
						TextAlignment = TextAlignment.Center,
						TextWrapping = TextWrapping.Wrap
					}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(TextBlock c4)
					{
						nameScope.RegisterName("TextLabel", c4);
						TextLabel = c4;
						Grid.SetRow(c4, 1);
						c4.SetBinding(TextBlock.TextProperty, new Binding
						{
							Path = "Label",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						AutomationProperties.SetAccessibilityView(c4, AccessibilityView.Raw);
						c4.CreationComplete();
					})
				}
			}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(Grid c5)
			{
				nameScope.RegisterName("ContentRoot", c5);
				ContentRoot = c5;
				c5.CreationComplete();
			}) }
		}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(Grid c6)
		{
			nameScope.RegisterName("Root", c6);
			Root = c6;
			c6.SetBinding(FrameworkElement.MinWidthProperty, new Binding
			{
				Path = "MinWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c6.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c6.SetBinding(Grid.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c6.SetBinding(Grid.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c6, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(VisualState c7)
					{
						nameScope.RegisterName("Normal", c7);
						Normal = c7;
					}),
					new VisualState
					{
						Name = "Disabled"
					}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(VisualState c8)
					{
						nameScope.RegisterName("Disabled", c8);
						Disabled = c8;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(VisualState c9)
					{
						nameScope.RegisterName("PointerOver", c9);
						PointerOver = c9;
					}),
					new VisualState
					{
						Name = "Pressed"
					}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(VisualState c10)
					{
						nameScope.RegisterName("Pressed", c10);
						Pressed = c10;
						MarkupHelper.SetVisualStateLazy(c10, delegate
						{
							c10.Name = "Pressed";
							c10.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SwipeItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__73.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SwipeItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__73.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.SwipeControl_themeresources_v1_69f8483b678cddf578a250fa0183249a_XamlApply(delegate(VisualStateGroup c11)
			{
				nameScope.RegisterName("CommonStates", c11);
				CommonStates = c11;
			}) });
			c6.CreationComplete();
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

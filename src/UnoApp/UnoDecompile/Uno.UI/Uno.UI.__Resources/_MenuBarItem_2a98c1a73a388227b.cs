using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Uno.UI.__Resources;

internal class _MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_MenuBarItemRDSC0
{
	private ElementNameSubject _BackgroundSubject = new ElementNameSubject();

	private ElementNameSubject _ContentButtonSubject = new ElementNameSubject();

	private ElementNameSubject _ContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

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

	private Button ContentButton
	{
		get
		{
			return (Button)_ContentButtonSubject.ElementInstance;
		}
		set
		{
			_ContentButtonSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_172)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)"ButtonBackground"] = new WeakResourceInitializer(__ResourceOwner_172, (object? __ResourceOwner_173) => new SolidColorBrush
				{
					Color = Colors.Transparent
				}),
				[(object)"ButtonBackgroundPointerOver"] = new WeakResourceInitializer(__ResourceOwner_172, (object? __ResourceOwner_174) => new SolidColorBrush
				{
					Color = Colors.Transparent
				}),
				[(object)"ButtonBackgroundPressed"] = new WeakResourceInitializer(__ResourceOwner_172, (object? __ResourceOwner_175) => new SolidColorBrush
				{
					Color = Colors.Transparent
				}),
				[(object)"ButtonBackgroundDisabled"] = new WeakResourceInitializer(__ResourceOwner_172, (object? __ResourceOwner_176) => new SolidColorBrush
				{
					Color = Colors.Transparent
				})
			},
			Name = "ContentRoot",
			Children = 
			{
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "Background"
				}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(Border c4)
				{
					nameScope.RegisterName("Background", c4);
					Background = c4;
					c4.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c4.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "BorderThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c4.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c4.CreationComplete();
				}),
				(UIElement)new Button
				{
					IsParsing = true,
					Name = "ContentButton",
					Background = SolidColorBrushHelper.Transparent,
					BorderThickness = new Thickness(0.0),
					VerticalAlignment = VerticalAlignment.Stretch,
					Padding = new Thickness(12.0, 0.0, 12.0, 0.0),
					IsTabStop = false
				}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(Button c5)
				{
					nameScope.RegisterName("ContentButton", c5);
					ContentButton = c5;
					c5.SetBinding(ContentControl.ContentProperty, new Binding
					{
						Path = "Title",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					AutomationProperties.SetAccessibilityView(c5, AccessibilityView.Raw);
					c5.CreationComplete();
				})
			}
		}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(Grid c6)
		{
			nameScope.RegisterName("ContentRoot", c6);
			ContentRoot = c6;
			c6.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
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
					}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(VisualState c7)
					{
						nameScope.RegisterName("Normal", c7);
						Normal = c7;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(VisualState c8)
					{
						nameScope.RegisterName("PointerOver", c8);
						PointerOver = c8;
						MarkupHelper.SetVisualStateLazy(c8, delegate
						{
							c8.Name = "PointerOver";
							c8.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuBarItemBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuBarItemBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c8.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuBarItemBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuBarItemBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(VisualState c9)
					{
						nameScope.RegisterName("Pressed", c9);
						Pressed = c9;
						MarkupHelper.SetVisualStateLazy(c9, delegate
						{
							c9.Name = "Pressed";
							c9.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuBarItemBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuBarItemBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c9.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuBarItemBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuBarItemBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "Selected"
					}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(VisualState c10)
					{
						nameScope.RegisterName("Selected", c10);
						Selected = c10;
						MarkupHelper.SetVisualStateLazy(c10, delegate
						{
							c10.Name = "Selected";
							c10.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuBarItemBackgroundSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuBarItemBackgroundSelected", GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c10.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("MenuBarItemBorderBrushSelected", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("MenuBarItemBorderBrushSelected", GlobalStaticResources.ResourceDictionarySingleton__27.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.MenuBarItem_2a98c1a73a388227b6dfe93e4112cf3b_XamlApply(delegate(VisualStateGroup c11)
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

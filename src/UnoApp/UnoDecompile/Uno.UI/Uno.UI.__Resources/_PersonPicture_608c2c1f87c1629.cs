using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_PersonPictureRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _InitialsTextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _PersonPictureEllipseSubject = new ElementNameSubject();

	private ElementNameSubject _PersonPictureImageSubject = new ElementNameSubject();

	private ElementNameSubject _BadgingBackgroundEllipseSubject = new ElementNameSubject();

	private ElementNameSubject _BadgingEllipseSubject = new ElementNameSubject();

	private ElementNameSubject _BadgeNumberTextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _BadgeGlyphIconSubject = new ElementNameSubject();

	private ElementNameSubject _BadgeGridSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _PhotoSubject = new ElementNameSubject();

	private ElementNameSubject _InitialsSubject = new ElementNameSubject();

	private ElementNameSubject _NoPhotoOrInitialsSubject = new ElementNameSubject();

	private ElementNameSubject _GroupSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NoBadgeSubject = new ElementNameSubject();

	private ElementNameSubject _BadgeWithoutImageSourceSubject = new ElementNameSubject();

	private ElementNameSubject _BadgeImageBrushSubject = new ElementNameSubject();

	private ElementNameSubject _BadgeWithImageSourceSubject = new ElementNameSubject();

	private ElementNameSubject _BadgeStatesSubject = new ElementNameSubject();

	private Ellipse _component_0
	{
		get
		{
			return (Ellipse)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Ellipse _component_1
	{
		get
		{
			return (Ellipse)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private TextBlock _component_2
	{
		get
		{
			return (TextBlock)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private FontIcon _component_3
	{
		get
		{
			return (FontIcon)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private TextBlock InitialsTextBlock
	{
		get
		{
			return (TextBlock)_InitialsTextBlockSubject.ElementInstance;
		}
		set
		{
			_InitialsTextBlockSubject.ElementInstance = value;
		}
	}

	private Ellipse PersonPictureEllipse
	{
		get
		{
			return (Ellipse)_PersonPictureEllipseSubject.ElementInstance;
		}
		set
		{
			_PersonPictureEllipseSubject.ElementInstance = value;
		}
	}

	private Image PersonPictureImage
	{
		get
		{
			return (Image)_PersonPictureImageSubject.ElementInstance;
		}
		set
		{
			_PersonPictureImageSubject.ElementInstance = value;
		}
	}

	private Ellipse BadgingBackgroundEllipse
	{
		get
		{
			return (Ellipse)_BadgingBackgroundEllipseSubject.ElementInstance;
		}
		set
		{
			_BadgingBackgroundEllipseSubject.ElementInstance = value;
		}
	}

	private Ellipse BadgingEllipse
	{
		get
		{
			return (Ellipse)_BadgingEllipseSubject.ElementInstance;
		}
		set
		{
			_BadgingEllipseSubject.ElementInstance = value;
		}
	}

	private TextBlock BadgeNumberTextBlock
	{
		get
		{
			return (TextBlock)_BadgeNumberTextBlockSubject.ElementInstance;
		}
		set
		{
			_BadgeNumberTextBlockSubject.ElementInstance = value;
		}
	}

	private FontIcon BadgeGlyphIcon
	{
		get
		{
			return (FontIcon)_BadgeGlyphIconSubject.ElementInstance;
		}
		set
		{
			_BadgeGlyphIconSubject.ElementInstance = value;
		}
	}

	private Grid BadgeGrid
	{
		get
		{
			return (Grid)_BadgeGridSubject.ElementInstance;
		}
		set
		{
			_BadgeGridSubject.ElementInstance = value;
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

	private VisualState Photo
	{
		get
		{
			return (VisualState)_PhotoSubject.ElementInstance;
		}
		set
		{
			_PhotoSubject.ElementInstance = value;
		}
	}

	private VisualState Initials
	{
		get
		{
			return (VisualState)_InitialsSubject.ElementInstance;
		}
		set
		{
			_InitialsSubject.ElementInstance = value;
		}
	}

	private VisualState NoPhotoOrInitials
	{
		get
		{
			return (VisualState)_NoPhotoOrInitialsSubject.ElementInstance;
		}
		set
		{
			_NoPhotoOrInitialsSubject.ElementInstance = value;
		}
	}

	private VisualState Group
	{
		get
		{
			return (VisualState)_GroupSubject.ElementInstance;
		}
		set
		{
			_GroupSubject.ElementInstance = value;
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

	private VisualState NoBadge
	{
		get
		{
			return (VisualState)_NoBadgeSubject.ElementInstance;
		}
		set
		{
			_NoBadgeSubject.ElementInstance = value;
		}
	}

	private VisualState BadgeWithoutImageSource
	{
		get
		{
			return (VisualState)_BadgeWithoutImageSourceSubject.ElementInstance;
		}
		set
		{
			_BadgeWithoutImageSourceSubject.ElementInstance = value;
		}
	}

	private ImageBrush BadgeImageBrush
	{
		get
		{
			return (ImageBrush)_BadgeImageBrushSubject.ElementInstance;
		}
		set
		{
			_BadgeImageBrushSubject.ElementInstance = value;
		}
	}

	private VisualState BadgeWithImageSource
	{
		get
		{
			return (VisualState)_BadgeWithImageSourceSubject.ElementInstance;
		}
		set
		{
			_BadgeWithImageSourceSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup BadgeStates
	{
		get
		{
			return (VisualStateGroup)_BadgeStatesSubject.ElementInstance;
		}
		set
		{
			_BadgeStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_264)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = 
			{
				(UIElement)new Ellipse
				{
					IsParsing = true
				}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Ellipse c0)
				{
					ResourceResolverSingleton.Instance.ApplyResource(c0, Shape.FillProperty, "PersonPictureEllipseFillThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c0, Shape.StrokeProperty, "SystemColorButtonTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c0, Shape.StrokeThicknessProperty, "PersonPictureEllipseStrokeThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
					c0.SetBinding(FrameworkElement.WidthProperty, new Binding
					{
						Path = "Width",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.SetBinding(FrameworkElement.HeightProperty, new Binding
					{
						Path = "Height",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c0;
					c0.CreationComplete();
				}),
				(UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "InitialsTextBlock",
					FontSize = 36.0,
					TextLineBounds = TextLineBounds.Tight,
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					IsTextScaleFactorEnabled = false
				}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(TextBlock c1)
				{
					nameScope.RegisterName("InitialsTextBlock", c1);
					InitialsTextBlock = c1;
					AutomationProperties.SetAccessibilityView(c1, AccessibilityView.Raw);
					c1.SetBinding(TextBlock.FontFamilyProperty, new Binding
					{
						Path = "FontFamily",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(TextBlock.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(TextBlock.FontWeightProperty, new Binding
					{
						Path = "FontWeight",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(TextBlock.TextProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "TemplateSettings.ActualInitials"
					});
					c1.CreationComplete();
				}),
				(UIElement)new Ellipse
				{
					IsParsing = true,
					Name = "PersonPictureEllipse",
					FlowDirection = FlowDirection.LeftToRight
				}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Ellipse c2)
				{
					nameScope.RegisterName("PersonPictureEllipse", c2);
					PersonPictureEllipse = c2;
					c2.SetBinding(FrameworkElement.WidthProperty, new Binding
					{
						Path = "Width",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.SetBinding(FrameworkElement.HeightProperty, new Binding
					{
						Path = "Height",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					FlowDirection = FlowDirection.LeftToRight,
					Child = new Image
					{
						IsParsing = true,
						Name = "PersonPictureImage",
						Stretch = Stretch.UniformToFill,
						HorizontalAlignment = HorizontalAlignment.Center,
						VerticalAlignment = VerticalAlignment.Center
					}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Image c3)
					{
						nameScope.RegisterName("PersonPictureImage", c3);
						PersonPictureImage = c3;
						c3.CreationComplete();
					})
				}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Border c4)
				{
					c4.SetBinding(FrameworkElement.WidthProperty, new Binding
					{
						Path = "Width",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c4.SetBinding(FrameworkElement.HeightProperty, new Binding
					{
						Path = "Height",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c4.SetBinding(Border.CornerRadiusProperty, new Binding
					{
						Path = "Width",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c4.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "BadgeGrid",
					Visibility = Visibility.Collapsed,
					VerticalAlignment = VerticalAlignment.Bottom,
					HorizontalAlignment = HorizontalAlignment.Right,
					Children = 
					{
						(UIElement)new Ellipse
						{
							IsParsing = true,
							Name = "BadgingBackgroundEllipse"
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Ellipse c5)
						{
							nameScope.RegisterName("BadgingBackgroundEllipse", c5);
							BadgingBackgroundEllipse = c5;
							ResourceResolverSingleton.Instance.ApplyResource(c5, UIElement.OpacityProperty, "PersonPictureEllipseBadgeStrokeOpacity", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c5, Shape.FillProperty, "PersonPictureEllipseBadgeFillThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c5, Shape.StrokeProperty, "PersonPictureEllipseBadgeStrokeThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c5, Shape.StrokeThicknessProperty, "PersonPictureEllipseBadgeStrokeThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
							_component_1 = c5;
							c5.CreationComplete();
						}),
						(UIElement)new Ellipse
						{
							IsParsing = true,
							Name = "BadgingEllipse",
							Opacity = 0.0,
							FlowDirection = FlowDirection.LeftToRight
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Ellipse c6)
						{
							nameScope.RegisterName("BadgingEllipse", c6);
							BadgingEllipse = c6;
							c6.CreationComplete();
						}),
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Name = "BadgeNumberTextBlock",
							TextLineBounds = TextLineBounds.Tight,
							VerticalAlignment = VerticalAlignment.Center,
							HorizontalAlignment = HorizontalAlignment.Center,
							IsTextScaleFactorEnabled = false
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(TextBlock c7)
						{
							nameScope.RegisterName("BadgeNumberTextBlock", c7);
							BadgeNumberTextBlock = c7;
							AutomationProperties.SetAccessibilityView(c7, AccessibilityView.Raw);
							ResourceResolverSingleton.Instance.ApplyResource(c7, TextBlock.ForegroundProperty, "PersonPictureEllipseBadgeForegroundThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
							c7.SetBinding(TextBlock.FontFamilyProperty, new Binding
							{
								Path = "FontFamily",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c7.SetBinding(TextBlock.FontWeightProperty, new Binding
							{
								Path = "FontWeight",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							_component_2 = c7;
							c7.CreationComplete();
						}),
						(UIElement)new FontIcon
						{
							IsParsing = true,
							Name = "BadgeGlyphIcon",
							VerticalAlignment = VerticalAlignment.Center,
							HorizontalAlignment = HorizontalAlignment.Center
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(FontIcon c8)
						{
							nameScope.RegisterName("BadgeGlyphIcon", c8);
							BadgeGlyphIcon = c8;
							AutomationProperties.SetAccessibilityView(c8, AccessibilityView.Raw);
							ResourceResolverSingleton.Instance.ApplyResource(c8, IconElement.ForegroundProperty, "PersonPictureEllipseBadgeForegroundThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c8, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_);
							c8.SetBinding(FontIcon.FontWeightProperty, new Binding
							{
								Path = "FontWeight",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							_component_3 = c8;
							c8.CreationComplete();
						})
					}
				}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Grid c9)
				{
					nameScope.RegisterName("BadgeGrid", c9);
					BadgeGrid = c9;
					c9.CreationComplete();
				})
			}
		}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Grid c10)
		{
			nameScope.RegisterName("RootGrid", c10);
			RootGrid = c10;
			VisualStateManager.SetVisualStateGroups(c10, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Photo"
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualState c11)
						{
							nameScope.RegisterName("Photo", c11);
							Photo = c11;
							MarkupHelper.SetVisualStateLazy(c11, delegate
							{
								c11.Name = "Photo";
								c11.Setters.Add(new Setter(new TargetPropertyPath(_PersonPictureEllipseSubject, (PropertyPath)"Fill"), null).PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Setter c12)
								{
									c12.SetBinding("Value", new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.ActualImageBrush"
									});
								}));
								c11.Setters.Add(new Setter(new TargetPropertyPath(_PersonPictureImageSubject, (PropertyPath)"Source"), null).PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(Setter c13)
								{
									c13.SetBinding("Value", new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.ActualImageBrush.ImageSource"
									});
								}));
							});
						}),
						new VisualState
						{
							Name = "Initials"
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualState c14)
						{
							nameScope.RegisterName("Initials", c14);
							Initials = c14;
						}),
						new VisualState
						{
							Name = "NoPhotoOrInitials"
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualState c15)
						{
							nameScope.RegisterName("NoPhotoOrInitials", c15);
							NoPhotoOrInitials = c15;
							MarkupHelper.SetVisualStateLazy(c15, delegate
							{
								c15.Name = "NoPhotoOrInitials";
								c15.Setters.Add(new Setter(new TargetPropertyPath(_InitialsTextBlockSubject, (PropertyPath)"FontFamily"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SymbolThemeFontFamily", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SymbolThemeFontFamily", GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c15.Setters.Add(new Setter(new TargetPropertyPath(_InitialsTextBlockSubject, (PropertyPath)"Text"), "\ue77b"));
							});
						}),
						new VisualState
						{
							Name = "Group"
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualState c16)
						{
							nameScope.RegisterName("Group", c16);
							Group = c16;
							MarkupHelper.SetVisualStateLazy(c16, delegate
							{
								c16.Name = "Group";
								c16.Setters.Add(new Setter(new TargetPropertyPath(_InitialsTextBlockSubject, (PropertyPath)"FontFamily"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SymbolThemeFontFamily", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SymbolThemeFontFamily", GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c16.Setters.Add(new Setter(new TargetPropertyPath(_InitialsTextBlockSubject, (PropertyPath)"Text"), "\ue716"));
							});
						})
					}
				}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualStateGroup c17)
				{
					nameScope.RegisterName("CommonStates", c17);
					CommonStates = c17;
				}),
				new VisualStateGroup
				{
					Name = "BadgeStates",
					States = 
					{
						new VisualState
						{
							Name = "NoBadge"
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualState c18)
						{
							nameScope.RegisterName("NoBadge", c18);
							NoBadge = c18;
						}),
						new VisualState
						{
							Name = "BadgeWithoutImageSource"
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualState c19)
						{
							nameScope.RegisterName("BadgeWithoutImageSource", c19);
							BadgeWithoutImageSource = c19;
							MarkupHelper.SetVisualStateLazy(c19, delegate
							{
								c19.Name = "BadgeWithoutImageSource";
								c19.Setters.Add(new Setter(new TargetPropertyPath(_BadgeGridSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						}),
						new VisualState
						{
							Name = "BadgeWithImageSource",
							Setters = 
							{
								(SetterBase)new Setter(new TargetPropertyPath(_BadgeGridSubject, (PropertyPath)"Visibility"), "Visible"),
								(SetterBase)new Setter(new TargetPropertyPath(_BadgingEllipseSubject, (PropertyPath)"Opacity"), ResourceResolverSingleton.Instance.ResolveResourceStatic("PersonPictureEllipseBadgeImageSourceStrokeOpacity", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("PersonPictureEllipseBadgeImageSourceStrokeOpacity", GlobalStaticResources.ResourceDictionarySingleton__49.Instance.__ParseContext_, isTheme: true, isHotReload: false),
								(SetterBase)new Setter(new TargetPropertyPath(_BadgingEllipseSubject, (PropertyPath)"Fill"), new ImageBrush
								{
									Stretch = Stretch.UniformToFill
								}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(ImageBrush c20)
								{
									nameScope.RegisterName("BadgeImageBrush", c20);
									BadgeImageBrush = c20;
								}))
							}
						}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualState c21)
						{
							nameScope.RegisterName("BadgeWithImageSource", c21);
							BadgeWithImageSource = c21;
						})
					}
				}.PersonPicture_608c2c1f87c1629f1f42347fdc7b7c60_XamlApply(delegate(VisualStateGroup c22)
				{
					nameScope.RegisterName("BadgeStates", c22);
					BadgeStates = c22;
				})
			});
			c10.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
				_component_3.UpdateResourceBindings();
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

using System;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_PagerControl_themeresources_v2_5RDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private DiscreteObjectKeyFrame _component_0
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_0_Holder.Instance;
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

	private FontIcon Content
	{
		get
		{
			return (FontIcon)_ContentSubject.ElementInstance;
		}
		set
		{
			_ContentSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_206)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = { (UIElement)new FontIcon
			{
				IsParsing = true,
				Name = "Content",
				MirroredWhenRightToLeft = true
			}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(FontIcon c0)
			{
				nameScope.RegisterName("Content", c0);
				Content = c0;
				c0.SetBinding(FontIcon.FontSizeProperty, new Binding
				{
					Path = "FontSize",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(FontIcon.FontFamilyProperty, new Binding
				{
					Path = "FontFamily",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(FontIcon.GlyphProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(IconElement.ForegroundProperty, new Binding
				{
					Path = "Foreground",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c0, AccessibilityView.Raw);
				c0.CreationComplete();
			}) }
		}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(Grid c1)
		{
			nameScope.RegisterName("RootGrid", c1);
			RootGrid = c1;
			c1.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c1, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c2)
					{
						nameScope.RegisterName("Normal", c2);
						Normal = c2;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c3)
					{
						nameScope.RegisterName("PointerOver", c3);
						PointerOver = c3;
						MarkupHelper.SetVisualStateLazy(c3, delegate
						{
							c3.Name = "PointerOver";
							c3.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c4)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c4, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_0 = c4;
											NameScope.SetNameScope(_component_0, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c5)
									{
										Storyboard.SetTargetName(c5, "RootGrid");
										Storyboard.SetTarget(c5, _RootGridSubject);
										Storyboard.SetTargetProperty(c5, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c6)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c6, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_1 = c6;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c7)
									{
										Storyboard.SetTargetName(c7, "Content");
										Storyboard.SetTarget(c7, _ContentSubject);
										Storyboard.SetTargetProperty(c7, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c8)
					{
						nameScope.RegisterName("Pressed", c8);
						Pressed = c8;
						MarkupHelper.SetVisualStateLazy(c8, delegate
						{
							c8.Name = "Pressed";
							c8.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c9)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c9, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_2 = c9;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c10)
									{
										Storyboard.SetTargetName(c10, "RootGrid");
										Storyboard.SetTarget(c10, _RootGridSubject);
										Storyboard.SetTargetProperty(c10, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c11)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c11, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_3 = c11;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c12)
									{
										Storyboard.SetTargetName(c12, "Content");
										Storyboard.SetTarget(c12, _ContentSubject);
										Storyboard.SetTargetProperty(c12, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c13)
					{
						nameScope.RegisterName("Disabled", c13);
						Disabled = c13;
						MarkupHelper.SetVisualStateLazy(c13, delegate
						{
							c13.Name = "Disabled";
							c13.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c14)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c14, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonBackgroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_4 = c14;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c15)
									{
										Storyboard.SetTargetName(c15, "RootGrid");
										Storyboard.SetTarget(c15, _RootGridSubject);
										Storyboard.SetTargetProperty(c15, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c16)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c16, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_5 = c16;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c17)
									{
										Storyboard.SetTargetName(c17, "Content");
										Storyboard.SetTarget(c17, _ContentSubject);
										Storyboard.SetTargetProperty(c17, "Foreground");
									})
								}
							};
						});
					})
				}
			}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualStateGroup c18)
			{
				nameScope.RegisterName("CommonStates", c18);
				CommonStates = c18;
			}) });
			c1.CreationComplete();
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
internal class _PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_PagerControl_themeresources_v2_5RDSC1
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private DiscreteObjectKeyFrame _component_0
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_0_Holder.Instance;
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

	public UIElement Build(object __ResourceOwner_212)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new ContentPresenter
		{
			IsParsing = true,
			Name = "ContentPresenter"
		}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ContentPresenter c19)
		{
			nameScope.RegisterName("ContentPresenter", c19);
			ContentPresenter = c19;
			c19.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.BackgroundSizingProperty, new Binding
			{
				Path = "BackgroundSizing",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Content",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
			{
				Path = "ContentTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
			{
				Path = "ContentTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
			{
				Path = "HorizontalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c19.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
			{
				Path = "VerticalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			AutomationProperties.SetAccessibilityView(c19, AccessibilityView.Raw);
			VisualStateManager.SetVisualStateGroups(c19, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c20)
					{
						nameScope.RegisterName("Normal", c20);
						Normal = c20;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c21)
					{
						nameScope.RegisterName("PointerOver", c21);
						PointerOver = c21;
						MarkupHelper.SetVisualStateLazy(c21, delegate
						{
							c21.Name = "PointerOver";
							c21.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c22)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c22, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_0 = c22;
											NameScope.SetNameScope(_component_0, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c23)
									{
										Storyboard.SetTargetName(c23, "ContentPresenter");
										Storyboard.SetTarget(c23, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c23, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c24)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c24, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_1 = c24;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c25)
									{
										Storyboard.SetTargetName(c25, "ContentPresenter");
										Storyboard.SetTarget(c25, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c25, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c26)
					{
						nameScope.RegisterName("Pressed", c26);
						Pressed = c26;
						MarkupHelper.SetVisualStateLazy(c26, delegate
						{
							c26.Name = "Pressed";
							c26.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c27)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c27, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_2 = c27;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c28)
									{
										Storyboard.SetTargetName(c28, "ContentPresenter");
										Storyboard.SetTarget(c28, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c28, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c29)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c29, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_3 = c29;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c30)
									{
										Storyboard.SetTargetName(c30, "ContentPresenter");
										Storyboard.SetTarget(c30, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c30, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualState c31)
					{
						nameScope.RegisterName("Disabled", c31);
						Disabled = c31;
						MarkupHelper.SetVisualStateLazy(c31, delegate
						{
							c31.Name = "Disabled";
							c31.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c32)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c32, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonBackgroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_4 = c32;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c33)
									{
										Storyboard.SetTargetName(c33, "ContentPresenter");
										Storyboard.SetTarget(c33, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c33, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(DiscreteObjectKeyFrame c34)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c34, ObjectKeyFrame.ValueProperty, "PagerControlPageNavigationButtonForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__47.Instance.__ParseContext_);
											_component_5 = c34;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c35)
									{
										Storyboard.SetTargetName(c35, "ContentPresenter");
										Storyboard.SetTarget(c35, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c35, "Foreground");
									})
								}
							};
						});
					})
				}
			}.PagerControl_themeresources_v2_5_d155c093ed586a44fc6c47ff2121f69b_XamlApply(delegate(VisualStateGroup c36)
			{
				nameScope.RegisterName("CommonStates", c36);
				CommonStates = c36;
			}) });
			c19.CreationComplete();
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

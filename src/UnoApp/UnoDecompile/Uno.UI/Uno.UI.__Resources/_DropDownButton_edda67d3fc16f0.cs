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

internal class _DropDownButton_edda67d3fc16f0f04971c62ccac57411_DropDownButtonRDSC0
{
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

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ChevronTextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _InnerGridSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

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

	private TextBlock ChevronTextBlock
	{
		get
		{
			return (TextBlock)_ChevronTextBlockSubject.ElementInstance;
		}
		set
		{
			_ChevronTextBlockSubject.ElementInstance = value;
		}
	}

	private Grid InnerGrid
	{
		get
		{
			return (Grid)_InnerGridSubject.ElementInstance;
		}
		set
		{
			_InnerGridSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_2547)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = { (UIElement)new Grid
			{
				IsParsing = true,
				Name = "InnerGrid",
				ColumnDefinitions = 
				{
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Star)
					},
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Auto)
					}
				},
				Children = 
				{
					(UIElement)new ContentPresenter
					{
						IsParsing = true,
						Name = "ContentPresenter"
					}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ContentPresenter c2)
					{
						nameScope.RegisterName("ContentPresenter", c2);
						ContentPresenter = c2;
						c2.SetBinding(ContentPresenter.ContentProperty, new Binding
						{
							Path = "Content",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c2.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
						{
							Path = "ContentTransitions",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c2.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
						{
							Path = "ContentTemplate",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c2.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
						{
							Path = "ContentTemplateSelector",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c2.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
						{
							Path = "HorizontalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c2.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
						{
							Path = "VerticalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						AutomationProperties.SetAccessibilityView(c2, AccessibilityView.Raw);
						c2.CreationComplete();
					}),
					(UIElement)new TextBlock
					{
						IsParsing = true,
						Name = "ChevronTextBlock",
						FontSize = 12.0,
						Text = "\ue0e5",
						VerticalAlignment = VerticalAlignment.Center,
						Margin = new Thickness(6.0, 0.0, 0.0, 0.0),
						IsTextScaleFactorEnabled = false
					}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(TextBlock c3)
					{
						nameScope.RegisterName("ChevronTextBlock", c3);
						ChevronTextBlock = c3;
						Grid.SetColumn(c3, 1);
						ResourceResolverSingleton.Instance.ApplyResource(c3, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
						AutomationProperties.SetAccessibilityView(c3, AccessibilityView.Raw);
						_component_0 = c3;
						c3.CreationComplete();
					})
				}
			}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(Grid c4)
			{
				nameScope.RegisterName("InnerGrid", c4);
				InnerGrid = c4;
				c4.SetBinding(Grid.PaddingProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c4.SetBinding(Grid.BorderBrushProperty, new Binding
				{
					Path = "BorderBrush",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c4.SetBinding(Grid.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c4.SetBinding(Grid.CornerRadiusProperty, new Binding
				{
					Path = "CornerRadius",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c4.CreationComplete();
			}) }
		}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(Grid c5)
		{
			nameScope.RegisterName("RootGrid", c5);
			RootGrid = c5;
			c5.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c5.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c5, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(VisualState c6)
					{
						nameScope.RegisterName("Normal", c6);
						Normal = c6;
						MarkupHelper.SetVisualStateLazy(c6, delegate
						{
							c6.Name = "Normal";
							c6.Storyboard = new Storyboard
							{
								Children = { (Timeline)new PointerUpThemeAnimation().DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(PointerUpThemeAnimation c7)
								{
									Storyboard.SetTargetName(c7, "RootGrid");
									Storyboard.SetTarget(c7, _RootGridSubject);
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(VisualState c8)
					{
						nameScope.RegisterName("PointerOver", c8);
						PointerOver = c8;
						MarkupHelper.SetVisualStateLazy(c8, delegate
						{
							c8.Name = "PointerOver";
							c8.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c9)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c9, ObjectKeyFrame.ValueProperty, "ButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_1 = c9;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c10)
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
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c11)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c11, ObjectKeyFrame.ValueProperty, "ButtonBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_2 = c11;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c12)
									{
										Storyboard.SetTargetName(c12, "InnerGrid");
										Storyboard.SetTarget(c12, _InnerGridSubject);
										Storyboard.SetTargetProperty(c12, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c13)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c13, ObjectKeyFrame.ValueProperty, "ButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_3 = c13;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c14)
									{
										Storyboard.SetTargetName(c14, "ContentPresenter");
										Storyboard.SetTarget(c14, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c14, "Foreground");
									}),
									(Timeline)new PointerUpThemeAnimation().DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(PointerUpThemeAnimation c15)
									{
										Storyboard.SetTargetName(c15, "RootGrid");
										Storyboard.SetTarget(c15, _RootGridSubject);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(VisualState c16)
					{
						nameScope.RegisterName("Pressed", c16);
						Pressed = c16;
						MarkupHelper.SetVisualStateLazy(c16, delegate
						{
							c16.Name = "Pressed";
							c16.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c17)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c17, ObjectKeyFrame.ValueProperty, "ButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_4 = c17;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c18)
									{
										Storyboard.SetTargetName(c18, "RootGrid");
										Storyboard.SetTarget(c18, _RootGridSubject);
										Storyboard.SetTargetProperty(c18, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c19)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c19, ObjectKeyFrame.ValueProperty, "ButtonBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_5 = c19;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c20)
									{
										Storyboard.SetTargetName(c20, "InnerGrid");
										Storyboard.SetTarget(c20, _InnerGridSubject);
										Storyboard.SetTargetProperty(c20, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c21)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c21, ObjectKeyFrame.ValueProperty, "ButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_6 = c21;
											NameScope.SetNameScope(_component_6, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c22)
									{
										Storyboard.SetTargetName(c22, "ContentPresenter");
										Storyboard.SetTarget(c22, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c22, "Foreground");
									}),
									(Timeline)new PointerDownThemeAnimation().DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(PointerDownThemeAnimation c23)
									{
										Storyboard.SetTargetName(c23, "RootGrid");
										Storyboard.SetTarget(c23, _RootGridSubject);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(VisualState c24)
					{
						nameScope.RegisterName("Disabled", c24);
						Disabled = c24;
						MarkupHelper.SetVisualStateLazy(c24, delegate
						{
							c24.Name = "Disabled";
							c24.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c25)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c25, ObjectKeyFrame.ValueProperty, "ButtonBackgroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_7 = c25;
											NameScope.SetNameScope(_component_7, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c26)
									{
										Storyboard.SetTargetName(c26, "RootGrid");
										Storyboard.SetTarget(c26, _RootGridSubject);
										Storyboard.SetTargetProperty(c26, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c27)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c27, ObjectKeyFrame.ValueProperty, "ButtonBorderBrushDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_8 = c27;
											NameScope.SetNameScope(_component_8, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c28)
									{
										Storyboard.SetTargetName(c28, "InnerGrid");
										Storyboard.SetTarget(c28, _InnerGridSubject);
										Storyboard.SetTargetProperty(c28, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c29)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c29, ObjectKeyFrame.ValueProperty, "ButtonForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_9 = c29;
											NameScope.SetNameScope(_component_9, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c30)
									{
										Storyboard.SetTargetName(c30, "ContentPresenter");
										Storyboard.SetTarget(c30, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c30, "Foreground");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(DiscreteObjectKeyFrame c31)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c31, ObjectKeyFrame.ValueProperty, "ButtonForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__13.Instance.__ParseContext_);
											_component_10 = c31;
											NameScope.SetNameScope(_component_10, nameScope);
										}) }
									}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(ObjectAnimationUsingKeyFrames c32)
									{
										Storyboard.SetTargetName(c32, "ChevronTextBlock");
										Storyboard.SetTarget(c32, _ChevronTextBlockSubject);
										Storyboard.SetTargetProperty(c32, "Foreground");
									})
								}
							};
						});
					})
				}
			}.DropDownButton_edda67d3fc16f0f04971c62ccac57411_XamlApply(delegate(VisualStateGroup c33)
			{
				nameScope.RegisterName("CommonStates", c33);
				CommonStates = c33;
			}) });
			c5.CreationComplete();
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

using System;
using Microsoft.UI.Xaml.Controls;
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

internal class _NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_NavigationBackButton_v1RDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

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

	private AnimatedIcon Content
	{
		get
		{
			return (AnimatedIcon)_ContentSubject.ElementInstance;
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

	public UIElement Build(object __ResourceOwner_254)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = { (UIElement)new AnimatedIcon
			{
				IsParsing = true,
				Name = "Content",
				Height = 16.0,
				Width = 16.0,
				MirroredWhenRightToLeft = true,
				FallbackIconSource = new Microsoft.UI.Xaml.Controls.FontIconSource
				{
					MirroredWhenRightToLeft = true
				}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(Microsoft.UI.Xaml.Controls.FontIconSource c0)
				{
					c0.SetBinding(Microsoft.UI.Xaml.Controls.FontIconSource.FontSizeProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "FontSize"
					});
					c0.SetBinding(Microsoft.UI.Xaml.Controls.FontIconSource.FontFamilyProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "FontFamily"
					});
					c0.SetBinding(Microsoft.UI.Xaml.Controls.FontIconSource.GlyphProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "Content"
					});
				})
			}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(AnimatedIcon c1)
			{
				nameScope.RegisterName("Content", c1);
				Content = c1;
				AnimatedIcon.SetState(c1, "Normal");
				c1.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c1, AccessibilityView.Raw);
				c1.CreationComplete();
			}) }
		}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(Grid c2)
		{
			nameScope.RegisterName("RootGrid", c2);
			RootGrid = c2;
			c2.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c2.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c2, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(VisualState c3)
					{
						nameScope.RegisterName("Normal", c3);
						Normal = c3;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(VisualState c4)
					{
						nameScope.RegisterName("PointerOver", c4);
						PointerOver = c4;
						MarkupHelper.SetVisualStateLazy(c4, delegate
						{
							c4.Name = "PointerOver";
							c4.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"(Microsoft.UI.Xaml.Controls:AnimatedIcon.State)"), "PointerOver"));
							c4.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(DiscreteObjectKeyFrame c5)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c5, ObjectKeyFrame.ValueProperty, "NavigationViewButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__38.Instance.__ParseContext_);
											_component_0 = c5;
											NameScope.SetNameScope(_component_0, nameScope);
										}) }
									}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c6)
									{
										Storyboard.SetTargetName(c6, "RootGrid");
										Storyboard.SetTarget(c6, _RootGridSubject);
										Storyboard.SetTargetProperty(c6, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(DiscreteObjectKeyFrame c7)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c7, ObjectKeyFrame.ValueProperty, "NavigationViewButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__38.Instance.__ParseContext_);
											_component_1 = c7;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c8)
									{
										Storyboard.SetTargetName(c8, "Content");
										Storyboard.SetTarget(c8, _ContentSubject);
										Storyboard.SetTargetProperty(c8, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(VisualState c9)
					{
						nameScope.RegisterName("Pressed", c9);
						Pressed = c9;
						MarkupHelper.SetVisualStateLazy(c9, delegate
						{
							c9.Name = "Pressed";
							c9.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"(Microsoft.UI.Xaml.Controls:AnimatedIcon.State)"), "Pressed"));
							c9.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(DiscreteObjectKeyFrame c10)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c10, ObjectKeyFrame.ValueProperty, "NavigationViewButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__38.Instance.__ParseContext_);
											_component_2 = c10;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c11)
									{
										Storyboard.SetTargetName(c11, "RootGrid");
										Storyboard.SetTarget(c11, _RootGridSubject);
										Storyboard.SetTargetProperty(c11, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(DiscreteObjectKeyFrame c12)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c12, ObjectKeyFrame.ValueProperty, "NavigationViewButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__38.Instance.__ParseContext_);
											_component_3 = c12;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c13)
									{
										Storyboard.SetTargetName(c13, "Content");
										Storyboard.SetTarget(c13, _ContentSubject);
										Storyboard.SetTargetProperty(c13, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(VisualState c14)
					{
						nameScope.RegisterName("Disabled", c14);
						Disabled = c14;
						MarkupHelper.SetVisualStateLazy(c14, delegate
						{
							c14.Name = "Disabled";
							c14.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(DiscreteObjectKeyFrame c15)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c15, ObjectKeyFrame.ValueProperty, "NavigationViewButtonForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__38.Instance.__ParseContext_);
										_component_4 = c15;
										NameScope.SetNameScope(_component_4, nameScope);
									}) }
								}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(ObjectAnimationUsingKeyFrames c16)
								{
									Storyboard.SetTargetName(c16, "Content");
									Storyboard.SetTarget(c16, _ContentSubject);
									Storyboard.SetTargetProperty(c16, "Foreground");
								}) }
							};
						});
					})
				}
			}.NavigationBackButton_v1_6631735fd7a33b229fdb26b248ec4fc7_XamlApply(delegate(VisualStateGroup c17)
			{
				nameScope.RegisterName("CommonStates", c17);
				CommonStates = c17;
			}) });
			c2.CreationComplete();
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

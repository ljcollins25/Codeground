using System;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC0
{
	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

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

	public UIElement Build(object __ResourceOwner_17)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Background = SolidColorBrushHelper.Transparent
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c0)
		{
			nameScope.RegisterName("Root", c0);
			Root = c0;
			VisualStateManager.SetVisualStateGroups(c0, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = { new VisualState
				{
					Name = "Normal"
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c1)
				{
					nameScope.RegisterName("Normal", c1);
					Normal = c1;
				}) }
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c2)
			{
				nameScope.RegisterName("CommonStates", c2);
				CommonStates = c2;
			}) });
			c0.CreationComplete();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC1
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

	private ElementNameSubject _ArrowSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
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

	private Grid _component_10
	{
		get
		{
			return (Grid)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private FontIcon Arrow
	{
		get
		{
			return (FontIcon)_ArrowSubject.ElementInstance;
		}
		set
		{
			_ArrowSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_88)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = { (UIElement)new FontIcon
			{
				IsParsing = true,
				Name = "Arrow",
				Glyph = "\ue0e3",
				MirroredWhenRightToLeft = true
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(FontIcon c3)
			{
				nameScope.RegisterName("Arrow", c3);
				Arrow = c3;
				ResourceResolverSingleton.Instance.ApplyResource(c3, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c3, IconElement.ForegroundProperty, "ScrollBarButtonArrowForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c3, FontIcon.FontSizeProperty, "ScrollBarButtonArrowIconFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				_component_0 = c3;
				c3.CreationComplete();
			}) }
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c4)
		{
			nameScope.RegisterName("Root", c4);
			Root = c4;
			ResourceResolverSingleton.Instance.ApplyResource(c4, FrameworkElement.BackgroundProperty, "ScrollBarButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c4, Grid.BorderBrushProperty, "ScrollBarButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			VisualStateManager.SetVisualStateGroups(c4, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c5)
					{
						nameScope.RegisterName("Normal", c5);
						Normal = c5;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c6)
					{
						nameScope.RegisterName("PointerOver", c6);
						PointerOver = c6;
						MarkupHelper.SetVisualStateLazy(c6, delegate
						{
							c6.Name = "PointerOver";
							c6.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c7)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c7, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_1 = c7;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c8)
									{
										Storyboard.SetTargetName(c8, "Root");
										Storyboard.SetTarget(c8, _RootSubject);
										Storyboard.SetTargetProperty(c8, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c9)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c9, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_2 = c9;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c10)
									{
										Storyboard.SetTargetName(c10, "Root");
										Storyboard.SetTarget(c10, _RootSubject);
										Storyboard.SetTargetProperty(c10, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c11)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c11, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_3 = c11;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c12)
									{
										Storyboard.SetTargetName(c12, "Arrow");
										Storyboard.SetTarget(c12, _ArrowSubject);
										Storyboard.SetTargetProperty(c12, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c13)
					{
						nameScope.RegisterName("Pressed", c13);
						Pressed = c13;
						MarkupHelper.SetVisualStateLazy(c13, delegate
						{
							c13.Name = "Pressed";
							c13.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c14)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c14, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_4 = c14;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c15)
									{
										Storyboard.SetTargetName(c15, "Root");
										Storyboard.SetTarget(c15, _RootSubject);
										Storyboard.SetTargetProperty(c15, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c16)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c16, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_5 = c16;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c17)
									{
										Storyboard.SetTargetName(c17, "Root");
										Storyboard.SetTarget(c17, _RootSubject);
										Storyboard.SetTargetProperty(c17, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c18)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c18, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_6 = c18;
											NameScope.SetNameScope(_component_6, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c19)
									{
										Storyboard.SetTargetName(c19, "Arrow");
										Storyboard.SetTarget(c19, _ArrowSubject);
										Storyboard.SetTargetProperty(c19, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c20)
					{
						nameScope.RegisterName("Disabled", c20);
						Disabled = c20;
						MarkupHelper.SetVisualStateLazy(c20, delegate
						{
							c20.Name = "Disabled";
							c20.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c21)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c21, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_7 = c21;
											NameScope.SetNameScope(_component_7, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c22)
									{
										Storyboard.SetTargetName(c22, "Root");
										Storyboard.SetTarget(c22, _RootSubject);
										Storyboard.SetTargetProperty(c22, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c23)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c23, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_8 = c23;
											NameScope.SetNameScope(_component_8, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c24)
									{
										Storyboard.SetTargetName(c24, "Root");
										Storyboard.SetTarget(c24, _RootSubject);
										Storyboard.SetTargetProperty(c24, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c25)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c25, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_9 = c25;
											NameScope.SetNameScope(_component_9, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c26)
									{
										Storyboard.SetTargetName(c26, "Arrow");
										Storyboard.SetTarget(c26, _ArrowSubject);
										Storyboard.SetTargetProperty(c26, "Foreground");
									})
								}
							};
						});
					})
				}
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c27)
			{
				nameScope.RegisterName("CommonStates", c27);
				CommonStates = c27;
			}) });
			_component_10 = c4;
			c4.CreationComplete();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC2
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

	private ElementNameSubject _ArrowSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
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

	private Grid _component_10
	{
		get
		{
			return (Grid)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private FontIcon Arrow
	{
		get
		{
			return (FontIcon)_ArrowSubject.ElementInstance;
		}
		set
		{
			_ArrowSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_118)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = { (UIElement)new FontIcon
			{
				IsParsing = true,
				Name = "Arrow",
				Glyph = "\ue0e2",
				MirroredWhenRightToLeft = true
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(FontIcon c28)
			{
				nameScope.RegisterName("Arrow", c28);
				Arrow = c28;
				ResourceResolverSingleton.Instance.ApplyResource(c28, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c28, IconElement.ForegroundProperty, "ScrollBarButtonArrowForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c28, FontIcon.FontSizeProperty, "ScrollBarButtonArrowIconFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				_component_0 = c28;
				c28.CreationComplete();
			}) }
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c29)
		{
			nameScope.RegisterName("Root", c29);
			Root = c29;
			ResourceResolverSingleton.Instance.ApplyResource(c29, FrameworkElement.BackgroundProperty, "ScrollBarButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c29, Grid.BorderBrushProperty, "ScrollBarButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			VisualStateManager.SetVisualStateGroups(c29, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c30)
					{
						nameScope.RegisterName("Normal", c30);
						Normal = c30;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c31)
					{
						nameScope.RegisterName("PointerOver", c31);
						PointerOver = c31;
						MarkupHelper.SetVisualStateLazy(c31, delegate
						{
							c31.Name = "PointerOver";
							c31.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c32)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c32, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_1 = c32;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c33)
									{
										Storyboard.SetTargetName(c33, "Root");
										Storyboard.SetTarget(c33, _RootSubject);
										Storyboard.SetTargetProperty(c33, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c34)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c34, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_2 = c34;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c35)
									{
										Storyboard.SetTargetName(c35, "Root");
										Storyboard.SetTarget(c35, _RootSubject);
										Storyboard.SetTargetProperty(c35, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c36)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c36, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_3 = c36;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c37)
									{
										Storyboard.SetTargetName(c37, "Arrow");
										Storyboard.SetTarget(c37, _ArrowSubject);
										Storyboard.SetTargetProperty(c37, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c38)
					{
						nameScope.RegisterName("Pressed", c38);
						Pressed = c38;
						MarkupHelper.SetVisualStateLazy(c38, delegate
						{
							c38.Name = "Pressed";
							c38.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c39)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c39, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_4 = c39;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c40)
									{
										Storyboard.SetTargetName(c40, "Root");
										Storyboard.SetTarget(c40, _RootSubject);
										Storyboard.SetTargetProperty(c40, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c41)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c41, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_5 = c41;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c42)
									{
										Storyboard.SetTargetName(c42, "Root");
										Storyboard.SetTarget(c42, _RootSubject);
										Storyboard.SetTargetProperty(c42, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c43)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c43, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_6 = c43;
											NameScope.SetNameScope(_component_6, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c44)
									{
										Storyboard.SetTargetName(c44, "Arrow");
										Storyboard.SetTarget(c44, _ArrowSubject);
										Storyboard.SetTargetProperty(c44, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c45)
					{
						nameScope.RegisterName("Disabled", c45);
						Disabled = c45;
						MarkupHelper.SetVisualStateLazy(c45, delegate
						{
							c45.Name = "Disabled";
							c45.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c46)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c46, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_7 = c46;
											NameScope.SetNameScope(_component_7, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c47)
									{
										Storyboard.SetTargetName(c47, "Root");
										Storyboard.SetTarget(c47, _RootSubject);
										Storyboard.SetTargetProperty(c47, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c48)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c48, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_8 = c48;
											NameScope.SetNameScope(_component_8, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c49)
									{
										Storyboard.SetTargetName(c49, "Root");
										Storyboard.SetTarget(c49, _RootSubject);
										Storyboard.SetTargetProperty(c49, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c50)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c50, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_9 = c50;
											NameScope.SetNameScope(_component_9, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c51)
									{
										Storyboard.SetTargetName(c51, "Arrow");
										Storyboard.SetTarget(c51, _ArrowSubject);
										Storyboard.SetTargetProperty(c51, "Foreground");
									})
								}
							};
						});
					})
				}
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c52)
			{
				nameScope.RegisterName("CommonStates", c52);
				CommonStates = c52;
			}) });
			_component_10 = c29;
			c29.CreationComplete();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC3
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

	private ElementNameSubject _ArrowSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
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

	private Grid _component_10
	{
		get
		{
			return (Grid)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private FontIcon Arrow
	{
		get
		{
			return (FontIcon)_ArrowSubject.ElementInstance;
		}
		set
		{
			_ArrowSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_120)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = { (UIElement)new FontIcon
			{
				IsParsing = true,
				Name = "Arrow",
				Glyph = "\ue0e5"
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(FontIcon c53)
			{
				nameScope.RegisterName("Arrow", c53);
				Arrow = c53;
				ResourceResolverSingleton.Instance.ApplyResource(c53, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c53, IconElement.ForegroundProperty, "ScrollBarButtonArrowForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c53, FontIcon.FontSizeProperty, "ScrollBarButtonArrowIconFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				_component_0 = c53;
				c53.CreationComplete();
			}) }
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c54)
		{
			nameScope.RegisterName("Root", c54);
			Root = c54;
			ResourceResolverSingleton.Instance.ApplyResource(c54, FrameworkElement.BackgroundProperty, "ScrollBarButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c54, Grid.BorderBrushProperty, "ScrollBarButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			VisualStateManager.SetVisualStateGroups(c54, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c55)
					{
						nameScope.RegisterName("Normal", c55);
						Normal = c55;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c56)
					{
						nameScope.RegisterName("PointerOver", c56);
						PointerOver = c56;
						MarkupHelper.SetVisualStateLazy(c56, delegate
						{
							c56.Name = "PointerOver";
							c56.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c57)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c57, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_1 = c57;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c58)
									{
										Storyboard.SetTargetName(c58, "Root");
										Storyboard.SetTarget(c58, _RootSubject);
										Storyboard.SetTargetProperty(c58, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c59)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c59, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_2 = c59;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c60)
									{
										Storyboard.SetTargetName(c60, "Root");
										Storyboard.SetTarget(c60, _RootSubject);
										Storyboard.SetTargetProperty(c60, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c61)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c61, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_3 = c61;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c62)
									{
										Storyboard.SetTargetName(c62, "Arrow");
										Storyboard.SetTarget(c62, _ArrowSubject);
										Storyboard.SetTargetProperty(c62, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c63)
					{
						nameScope.RegisterName("Pressed", c63);
						Pressed = c63;
						MarkupHelper.SetVisualStateLazy(c63, delegate
						{
							c63.Name = "Pressed";
							c63.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c64)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c64, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_4 = c64;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c65)
									{
										Storyboard.SetTargetName(c65, "Root");
										Storyboard.SetTarget(c65, _RootSubject);
										Storyboard.SetTargetProperty(c65, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c66)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c66, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_5 = c66;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c67)
									{
										Storyboard.SetTargetName(c67, "Root");
										Storyboard.SetTarget(c67, _RootSubject);
										Storyboard.SetTargetProperty(c67, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c68)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c68, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_6 = c68;
											NameScope.SetNameScope(_component_6, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c69)
									{
										Storyboard.SetTargetName(c69, "Arrow");
										Storyboard.SetTarget(c69, _ArrowSubject);
										Storyboard.SetTargetProperty(c69, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c70)
					{
						nameScope.RegisterName("Disabled", c70);
						Disabled = c70;
						MarkupHelper.SetVisualStateLazy(c70, delegate
						{
							c70.Name = "Disabled";
							c70.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c71)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c71, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_7 = c71;
											NameScope.SetNameScope(_component_7, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c72)
									{
										Storyboard.SetTargetName(c72, "Root");
										Storyboard.SetTarget(c72, _RootSubject);
										Storyboard.SetTargetProperty(c72, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c73)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c73, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_8 = c73;
											NameScope.SetNameScope(_component_8, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c74)
									{
										Storyboard.SetTargetName(c74, "Root");
										Storyboard.SetTarget(c74, _RootSubject);
										Storyboard.SetTargetProperty(c74, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c75)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c75, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_9 = c75;
											NameScope.SetNameScope(_component_9, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c76)
									{
										Storyboard.SetTargetName(c76, "Arrow");
										Storyboard.SetTarget(c76, _ArrowSubject);
										Storyboard.SetTargetProperty(c76, "Foreground");
									})
								}
							};
						});
					})
				}
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c77)
			{
				nameScope.RegisterName("CommonStates", c77);
				CommonStates = c77;
			}) });
			_component_10 = c54;
			c54.CreationComplete();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC4
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

	private ElementNameSubject _ArrowSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private FontIcon _component_0
	{
		get
		{
			return (FontIcon)_component_0_Holder.Instance;
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

	private Grid _component_10
	{
		get
		{
			return (Grid)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private FontIcon Arrow
	{
		get
		{
			return (FontIcon)_ArrowSubject.ElementInstance;
		}
		set
		{
			_ArrowSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_121)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = { (UIElement)new FontIcon
			{
				IsParsing = true,
				Name = "Arrow",
				Glyph = "\ue0e4"
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(FontIcon c78)
			{
				nameScope.RegisterName("Arrow", c78);
				Arrow = c78;
				ResourceResolverSingleton.Instance.ApplyResource(c78, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c78, IconElement.ForegroundProperty, "ScrollBarButtonArrowForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c78, FontIcon.FontSizeProperty, "ScrollBarButtonArrowIconFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
				_component_0 = c78;
				c78.CreationComplete();
			}) }
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c79)
		{
			nameScope.RegisterName("Root", c79);
			Root = c79;
			ResourceResolverSingleton.Instance.ApplyResource(c79, FrameworkElement.BackgroundProperty, "ScrollBarButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			ResourceResolverSingleton.Instance.ApplyResource(c79, Grid.BorderBrushProperty, "ScrollBarButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
			VisualStateManager.SetVisualStateGroups(c79, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c80)
					{
						nameScope.RegisterName("Normal", c80);
						Normal = c80;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c81)
					{
						nameScope.RegisterName("PointerOver", c81);
						PointerOver = c81;
						MarkupHelper.SetVisualStateLazy(c81, delegate
						{
							c81.Name = "PointerOver";
							c81.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c82)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c82, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_1 = c82;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c83)
									{
										Storyboard.SetTargetName(c83, "Root");
										Storyboard.SetTarget(c83, _RootSubject);
										Storyboard.SetTargetProperty(c83, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c84)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c84, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_2 = c84;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c85)
									{
										Storyboard.SetTargetName(c85, "Root");
										Storyboard.SetTarget(c85, _RootSubject);
										Storyboard.SetTargetProperty(c85, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c86)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c86, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_3 = c86;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c87)
									{
										Storyboard.SetTargetName(c87, "Arrow");
										Storyboard.SetTarget(c87, _ArrowSubject);
										Storyboard.SetTargetProperty(c87, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c88)
					{
						nameScope.RegisterName("Pressed", c88);
						Pressed = c88;
						MarkupHelper.SetVisualStateLazy(c88, delegate
						{
							c88.Name = "Pressed";
							c88.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c89)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c89, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_4 = c89;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c90)
									{
										Storyboard.SetTargetName(c90, "Root");
										Storyboard.SetTarget(c90, _RootSubject);
										Storyboard.SetTargetProperty(c90, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c91)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c91, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_5 = c91;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c92)
									{
										Storyboard.SetTargetName(c92, "Root");
										Storyboard.SetTarget(c92, _RootSubject);
										Storyboard.SetTargetProperty(c92, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c93)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c93, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_6 = c93;
											NameScope.SetNameScope(_component_6, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c94)
									{
										Storyboard.SetTargetName(c94, "Arrow");
										Storyboard.SetTarget(c94, _ArrowSubject);
										Storyboard.SetTargetProperty(c94, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c95)
					{
						nameScope.RegisterName("Disabled", c95);
						Disabled = c95;
						MarkupHelper.SetVisualStateLazy(c95, delegate
						{
							c95.Name = "Disabled";
							c95.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c96)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c96, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_7 = c96;
											NameScope.SetNameScope(_component_7, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c97)
									{
										Storyboard.SetTargetName(c97, "Root");
										Storyboard.SetTarget(c97, _RootSubject);
										Storyboard.SetTargetProperty(c97, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c98)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c98, ObjectKeyFrame.ValueProperty, "ScrollBarButtonBorderBrushDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_8 = c98;
											NameScope.SetNameScope(_component_8, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c99)
									{
										Storyboard.SetTargetName(c99, "Root");
										Storyboard.SetTarget(c99, _RootSubject);
										Storyboard.SetTargetProperty(c99, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c100)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c100, ObjectKeyFrame.ValueProperty, "ScrollBarButtonArrowForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_9 = c100;
											NameScope.SetNameScope(_component_9, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c101)
									{
										Storyboard.SetTargetName(c101, "Arrow");
										Storyboard.SetTarget(c101, _ArrowSubject);
										Storyboard.SetTargetProperty(c101, "Foreground");
									})
								}
							};
						});
					})
				}
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c102)
			{
				nameScope.RegisterName("CommonStates", c102);
				CommonStates = c102;
			}) });
			_component_10 = c79;
			c79.CreationComplete();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC5
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ThumbVisualSubject = new ElementNameSubject();

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

	private Rectangle ThumbVisual
	{
		get
		{
			return (Rectangle)_ThumbVisualSubject.ElementInstance;
		}
		set
		{
			_ThumbVisualSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_122)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Rectangle
		{
			IsParsing = true,
			Name = "ThumbVisual"
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Rectangle c103)
		{
			nameScope.RegisterName("ThumbVisual", c103);
			ThumbVisual = c103;
			c103.SetBinding(Shape.FillProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c103, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c104)
					{
						nameScope.RegisterName("Normal", c104);
						Normal = c104;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c105)
					{
						nameScope.RegisterName("PointerOver", c105);
						PointerOver = c105;
						MarkupHelper.SetVisualStateLazy(c105, delegate
						{
							c105.Name = "PointerOver";
							c105.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c106)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c106, ObjectKeyFrame.ValueProperty, "ScrollBarThumbFillPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_0 = c106;
										NameScope.SetNameScope(_component_0, nameScope);
									}) }
								}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c107)
								{
									Storyboard.SetTargetName(c107, "ThumbVisual");
									Storyboard.SetTarget(c107, _ThumbVisualSubject);
									Storyboard.SetTargetProperty(c107, "Fill");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c108)
					{
						nameScope.RegisterName("Pressed", c108);
						Pressed = c108;
						MarkupHelper.SetVisualStateLazy(c108, delegate
						{
							c108.Name = "Pressed";
							c108.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c109)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c109, ObjectKeyFrame.ValueProperty, "ScrollBarThumbFillPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_1 = c109;
										NameScope.SetNameScope(_component_1, nameScope);
									}) }
								}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c110)
								{
									Storyboard.SetTargetName(c110, "ThumbVisual");
									Storyboard.SetTarget(c110, _ThumbVisualSubject);
									Storyboard.SetTargetProperty(c110, "Fill");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c111)
					{
						nameScope.RegisterName("Disabled", c111);
						Disabled = c111;
						MarkupHelper.SetVisualStateLazy(c111, delegate
						{
							c111.Name = "Disabled";
							c111.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c112)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c112, ObjectKeyFrame.ValueProperty, "ScrollBarThumbFillDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_2 = c112;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c113)
									{
										Storyboard.SetTargetName(c113, "ThumbVisual");
										Storyboard.SetTarget(c113, _ThumbVisualSubject);
										Storyboard.SetTargetProperty(c113, "Fill");
									}),
									(Timeline)new DoubleAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(0L)),
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c114)
									{
										Storyboard.SetTargetProperty(c114, "Opacity");
										Storyboard.SetTargetName(c114, "ThumbVisual");
										Storyboard.SetTarget(c114, _ThumbVisualSubject);
									})
								}
							};
						});
					})
				}
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c115)
			{
				nameScope.RegisterName("CommonStates", c115);
				CommonStates = c115;
			}) });
			c103.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC6
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ThumbVisualSubject = new ElementNameSubject();

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

	private Rectangle ThumbVisual
	{
		get
		{
			return (Rectangle)_ThumbVisualSubject.ElementInstance;
		}
		set
		{
			_ThumbVisualSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_123)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Rectangle
		{
			IsParsing = true,
			Name = "ThumbVisual"
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Rectangle c116)
		{
			nameScope.RegisterName("ThumbVisual", c116);
			ThumbVisual = c116;
			c116.SetBinding(Shape.FillProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c116, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c117)
					{
						nameScope.RegisterName("Normal", c117);
						Normal = c117;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c118)
					{
						nameScope.RegisterName("PointerOver", c118);
						PointerOver = c118;
						MarkupHelper.SetVisualStateLazy(c118, delegate
						{
							c118.Name = "PointerOver";
							c118.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c119)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c119, ObjectKeyFrame.ValueProperty, "ScrollBarThumbFillPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_0 = c119;
										NameScope.SetNameScope(_component_0, nameScope);
									}) }
								}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c120)
								{
									Storyboard.SetTargetName(c120, "ThumbVisual");
									Storyboard.SetTarget(c120, _ThumbVisualSubject);
									Storyboard.SetTargetProperty(c120, "Fill");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c121)
					{
						nameScope.RegisterName("Pressed", c121);
						Pressed = c121;
						MarkupHelper.SetVisualStateLazy(c121, delegate
						{
							c121.Name = "Pressed";
							c121.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c122)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c122, ObjectKeyFrame.ValueProperty, "ScrollBarThumbFillPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_1 = c122;
										NameScope.SetNameScope(_component_1, nameScope);
									}) }
								}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c123)
								{
									Storyboard.SetTargetName(c123, "ThumbVisual");
									Storyboard.SetTarget(c123, _ThumbVisualSubject);
									Storyboard.SetTargetProperty(c123, "Fill");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c124)
					{
						nameScope.RegisterName("Disabled", c124);
						Disabled = c124;
						MarkupHelper.SetVisualStateLazy(c124, delegate
						{
							c124.Name = "Disabled";
							c124.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c125)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c125, ObjectKeyFrame.ValueProperty, "ScrollBarThumbFillDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_2 = c125;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c126)
									{
										Storyboard.SetTargetName(c126, "ThumbVisual");
										Storyboard.SetTarget(c126, _ThumbVisualSubject);
										Storyboard.SetTargetProperty(c126, "Fill");
									}),
									(Timeline)new DoubleAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(0L)),
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c127)
									{
										Storyboard.SetTargetProperty(c127, "Opacity");
										Storyboard.SetTargetName(c127, "ThumbVisual");
										Storyboard.SetTarget(c127, _ThumbVisualSubject);
									})
								}
							};
						});
					})
				}
			}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c128)
			{
				nameScope.RegisterName("CommonStates", c128);
				CommonStates = c128;
			}) });
			c116.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC7
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

	private ComponentHolder _component_11_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_12_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_13_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_14_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_15_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_16_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_17_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_18_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_19_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_20_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_21_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_22_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_23_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_24_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_25_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_26_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_27_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_28_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_29_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_30_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_31_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_32_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_33_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_34_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_35_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_36_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_37_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_38_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_39_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_40_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_41_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_42_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_43_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_44_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_45_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_46_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_47_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_48_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_49_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_50_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_51_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_52_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_53_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_54_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_55_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_56_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_57_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_58_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_59_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_60_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_61_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_62_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_63_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_64_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_65_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_66_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_67_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_68_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_69_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_70_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_71_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_72_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_73_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_74_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_75_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_76_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_77_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_78_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_79_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_80_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_81_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_82_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_83_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_84_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_85_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_86_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_87_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_88_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_89_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_90_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_91_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_92_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_93_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_94_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_95_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_96_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_97_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_98_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_99_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_100_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_101_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_102_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_103_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _HorizontalTrackRectSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalSmallDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalLargeDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalThumbTransformSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalThumbSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalLargeIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalSmallIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalRootSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalPanningThumbSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalPanningRootSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalTrackRectSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalSmallDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalLargeDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalThumbTransformSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalThumbSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalLargeIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalSmallIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalRootSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalPanningThumbSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalPanningRootSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_NormalSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _TouchIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_TouchIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_TouchIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _MouseIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_MouseIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_MouseIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _NoIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollingIndicatorStatesSubject = new ElementNameSubject();

	private ElementNameSubject _CollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_CollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_CollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _CollapsedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _ConsciousStatesSubject = new ElementNameSubject();

	private Rectangle _component_0
	{
		get
		{
			return (Rectangle)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private RepeatButton _component_1
	{
		get
		{
			return (RepeatButton)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private RepeatButton _component_2
	{
		get
		{
			return (RepeatButton)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private CompositeTransform _component_3
	{
		get
		{
			return (CompositeTransform)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private Thumb _component_4
	{
		get
		{
			return (Thumb)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private RepeatButton _component_5
	{
		get
		{
			return (RepeatButton)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private RepeatButton _component_6
	{
		get
		{
			return (RepeatButton)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private Border _component_7
	{
		get
		{
			return (Border)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private Rectangle _component_8
	{
		get
		{
			return (Rectangle)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private RepeatButton _component_9
	{
		get
		{
			return (RepeatButton)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private RepeatButton _component_10
	{
		get
		{
			return (RepeatButton)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private CompositeTransform _component_11
	{
		get
		{
			return (CompositeTransform)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private Thumb _component_12
	{
		get
		{
			return (Thumb)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private RepeatButton _component_13
	{
		get
		{
			return (RepeatButton)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private RepeatButton _component_14
	{
		get
		{
			return (RepeatButton)_component_14_Holder.Instance;
		}
		set
		{
			_component_14_Holder.Instance = value;
		}
	}

	private Border _component_15
	{
		get
		{
			return (Border)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_16
	{
		get
		{
			return (ColorAnimation)_component_16_Holder.Instance;
		}
		set
		{
			_component_16_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_17
	{
		get
		{
			return (ColorAnimation)_component_17_Holder.Instance;
		}
		set
		{
			_component_17_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_18
	{
		get
		{
			return (DoubleAnimation)_component_18_Holder.Instance;
		}
		set
		{
			_component_18_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_19
	{
		get
		{
			return (DoubleAnimation)_component_19_Holder.Instance;
		}
		set
		{
			_component_19_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_20
	{
		get
		{
			return (DoubleAnimation)_component_20_Holder.Instance;
		}
		set
		{
			_component_20_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_21
	{
		get
		{
			return (DoubleAnimation)_component_21_Holder.Instance;
		}
		set
		{
			_component_21_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_22
	{
		get
		{
			return (DoubleAnimation)_component_22_Holder.Instance;
		}
		set
		{
			_component_22_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_23
	{
		get
		{
			return (DoubleAnimation)_component_23_Holder.Instance;
		}
		set
		{
			_component_23_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_24
	{
		get
		{
			return (DoubleAnimation)_component_24_Holder.Instance;
		}
		set
		{
			_component_24_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_25
	{
		get
		{
			return (DoubleAnimation)_component_25_Holder.Instance;
		}
		set
		{
			_component_25_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_26
	{
		get
		{
			return (DoubleAnimation)_component_26_Holder.Instance;
		}
		set
		{
			_component_26_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_27
	{
		get
		{
			return (DoubleAnimation)_component_27_Holder.Instance;
		}
		set
		{
			_component_27_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_28
	{
		get
		{
			return (DoubleAnimation)_component_28_Holder.Instance;
		}
		set
		{
			_component_28_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_29
	{
		get
		{
			return (DoubleAnimation)_component_29_Holder.Instance;
		}
		set
		{
			_component_29_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_30
	{
		get
		{
			return (DoubleAnimation)_component_30_Holder.Instance;
		}
		set
		{
			_component_30_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_31
	{
		get
		{
			return (DoubleAnimation)_component_31_Holder.Instance;
		}
		set
		{
			_component_31_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_32
	{
		get
		{
			return (DoubleAnimation)_component_32_Holder.Instance;
		}
		set
		{
			_component_32_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_33
	{
		get
		{
			return (DoubleAnimation)_component_33_Holder.Instance;
		}
		set
		{
			_component_33_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_34
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_34_Holder.Instance;
		}
		set
		{
			_component_34_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_35
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_35_Holder.Instance;
		}
		set
		{
			_component_35_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_36
	{
		get
		{
			return (DoubleAnimation)_component_36_Holder.Instance;
		}
		set
		{
			_component_36_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_37
	{
		get
		{
			return (DoubleAnimation)_component_37_Holder.Instance;
		}
		set
		{
			_component_37_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_38
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_38_Holder.Instance;
		}
		set
		{
			_component_38_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_39
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_39_Holder.Instance;
		}
		set
		{
			_component_39_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_40
	{
		get
		{
			return (ColorAnimation)_component_40_Holder.Instance;
		}
		set
		{
			_component_40_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_41
	{
		get
		{
			return (ColorAnimation)_component_41_Holder.Instance;
		}
		set
		{
			_component_41_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_42
	{
		get
		{
			return (DoubleAnimation)_component_42_Holder.Instance;
		}
		set
		{
			_component_42_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_43
	{
		get
		{
			return (DoubleAnimation)_component_43_Holder.Instance;
		}
		set
		{
			_component_43_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_44
	{
		get
		{
			return (DoubleAnimation)_component_44_Holder.Instance;
		}
		set
		{
			_component_44_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_45
	{
		get
		{
			return (DoubleAnimation)_component_45_Holder.Instance;
		}
		set
		{
			_component_45_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_46
	{
		get
		{
			return (DoubleAnimation)_component_46_Holder.Instance;
		}
		set
		{
			_component_46_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_47
	{
		get
		{
			return (DoubleAnimation)_component_47_Holder.Instance;
		}
		set
		{
			_component_47_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_48
	{
		get
		{
			return (DoubleAnimation)_component_48_Holder.Instance;
		}
		set
		{
			_component_48_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_49
	{
		get
		{
			return (DoubleAnimation)_component_49_Holder.Instance;
		}
		set
		{
			_component_49_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_50
	{
		get
		{
			return (DoubleAnimation)_component_50_Holder.Instance;
		}
		set
		{
			_component_50_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_51
	{
		get
		{
			return (DoubleAnimation)_component_51_Holder.Instance;
		}
		set
		{
			_component_51_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_52
	{
		get
		{
			return (DoubleAnimation)_component_52_Holder.Instance;
		}
		set
		{
			_component_52_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_53
	{
		get
		{
			return (DoubleAnimation)_component_53_Holder.Instance;
		}
		set
		{
			_component_53_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_54
	{
		get
		{
			return (DoubleAnimation)_component_54_Holder.Instance;
		}
		set
		{
			_component_54_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_55
	{
		get
		{
			return (DoubleAnimation)_component_55_Holder.Instance;
		}
		set
		{
			_component_55_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_56
	{
		get
		{
			return (ColorAnimation)_component_56_Holder.Instance;
		}
		set
		{
			_component_56_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_57
	{
		get
		{
			return (ColorAnimation)_component_57_Holder.Instance;
		}
		set
		{
			_component_57_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_58
	{
		get
		{
			return (DoubleAnimation)_component_58_Holder.Instance;
		}
		set
		{
			_component_58_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_59
	{
		get
		{
			return (DoubleAnimation)_component_59_Holder.Instance;
		}
		set
		{
			_component_59_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_60
	{
		get
		{
			return (DoubleAnimation)_component_60_Holder.Instance;
		}
		set
		{
			_component_60_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_61
	{
		get
		{
			return (DoubleAnimation)_component_61_Holder.Instance;
		}
		set
		{
			_component_61_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_62
	{
		get
		{
			return (DoubleAnimation)_component_62_Holder.Instance;
		}
		set
		{
			_component_62_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_63
	{
		get
		{
			return (DoubleAnimation)_component_63_Holder.Instance;
		}
		set
		{
			_component_63_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_64
	{
		get
		{
			return (DoubleAnimation)_component_64_Holder.Instance;
		}
		set
		{
			_component_64_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_65
	{
		get
		{
			return (DoubleAnimation)_component_65_Holder.Instance;
		}
		set
		{
			_component_65_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_66
	{
		get
		{
			return (DoubleAnimation)_component_66_Holder.Instance;
		}
		set
		{
			_component_66_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_67
	{
		get
		{
			return (DoubleAnimation)_component_67_Holder.Instance;
		}
		set
		{
			_component_67_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_68
	{
		get
		{
			return (DoubleAnimation)_component_68_Holder.Instance;
		}
		set
		{
			_component_68_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_69
	{
		get
		{
			return (DoubleAnimation)_component_69_Holder.Instance;
		}
		set
		{
			_component_69_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_70
	{
		get
		{
			return (DoubleAnimation)_component_70_Holder.Instance;
		}
		set
		{
			_component_70_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_71
	{
		get
		{
			return (DoubleAnimation)_component_71_Holder.Instance;
		}
		set
		{
			_component_71_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_72
	{
		get
		{
			return (ColorAnimation)_component_72_Holder.Instance;
		}
		set
		{
			_component_72_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_73
	{
		get
		{
			return (ColorAnimation)_component_73_Holder.Instance;
		}
		set
		{
			_component_73_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_74
	{
		get
		{
			return (DoubleAnimation)_component_74_Holder.Instance;
		}
		set
		{
			_component_74_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_75
	{
		get
		{
			return (DoubleAnimation)_component_75_Holder.Instance;
		}
		set
		{
			_component_75_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_76
	{
		get
		{
			return (DoubleAnimation)_component_76_Holder.Instance;
		}
		set
		{
			_component_76_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_77
	{
		get
		{
			return (DoubleAnimation)_component_77_Holder.Instance;
		}
		set
		{
			_component_77_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_78
	{
		get
		{
			return (DoubleAnimation)_component_78_Holder.Instance;
		}
		set
		{
			_component_78_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_79
	{
		get
		{
			return (DoubleAnimation)_component_79_Holder.Instance;
		}
		set
		{
			_component_79_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_80
	{
		get
		{
			return (DoubleAnimation)_component_80_Holder.Instance;
		}
		set
		{
			_component_80_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_81
	{
		get
		{
			return (DoubleAnimation)_component_81_Holder.Instance;
		}
		set
		{
			_component_81_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_82
	{
		get
		{
			return (DoubleAnimation)_component_82_Holder.Instance;
		}
		set
		{
			_component_82_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_83
	{
		get
		{
			return (DoubleAnimation)_component_83_Holder.Instance;
		}
		set
		{
			_component_83_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_84
	{
		get
		{
			return (DoubleAnimation)_component_84_Holder.Instance;
		}
		set
		{
			_component_84_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_85
	{
		get
		{
			return (DoubleAnimation)_component_85_Holder.Instance;
		}
		set
		{
			_component_85_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_86
	{
		get
		{
			return (DoubleAnimation)_component_86_Holder.Instance;
		}
		set
		{
			_component_86_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_87
	{
		get
		{
			return (DoubleAnimation)_component_87_Holder.Instance;
		}
		set
		{
			_component_87_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_88
	{
		get
		{
			return (ColorAnimation)_component_88_Holder.Instance;
		}
		set
		{
			_component_88_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_89
	{
		get
		{
			return (ColorAnimation)_component_89_Holder.Instance;
		}
		set
		{
			_component_89_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_90
	{
		get
		{
			return (DoubleAnimation)_component_90_Holder.Instance;
		}
		set
		{
			_component_90_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_91
	{
		get
		{
			return (DoubleAnimation)_component_91_Holder.Instance;
		}
		set
		{
			_component_91_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_92
	{
		get
		{
			return (DoubleAnimation)_component_92_Holder.Instance;
		}
		set
		{
			_component_92_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_93
	{
		get
		{
			return (DoubleAnimation)_component_93_Holder.Instance;
		}
		set
		{
			_component_93_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_94
	{
		get
		{
			return (DoubleAnimation)_component_94_Holder.Instance;
		}
		set
		{
			_component_94_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_95
	{
		get
		{
			return (DoubleAnimation)_component_95_Holder.Instance;
		}
		set
		{
			_component_95_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_96
	{
		get
		{
			return (DoubleAnimation)_component_96_Holder.Instance;
		}
		set
		{
			_component_96_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_97
	{
		get
		{
			return (DoubleAnimation)_component_97_Holder.Instance;
		}
		set
		{
			_component_97_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_98
	{
		get
		{
			return (DoubleAnimation)_component_98_Holder.Instance;
		}
		set
		{
			_component_98_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_99
	{
		get
		{
			return (DoubleAnimation)_component_99_Holder.Instance;
		}
		set
		{
			_component_99_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_100
	{
		get
		{
			return (DoubleAnimation)_component_100_Holder.Instance;
		}
		set
		{
			_component_100_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_101
	{
		get
		{
			return (DoubleAnimation)_component_101_Holder.Instance;
		}
		set
		{
			_component_101_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_102
	{
		get
		{
			return (DoubleAnimation)_component_102_Holder.Instance;
		}
		set
		{
			_component_102_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_103
	{
		get
		{
			return (DoubleAnimation)_component_103_Holder.Instance;
		}
		set
		{
			_component_103_Holder.Instance = value;
		}
	}

	private Rectangle HorizontalTrackRect
	{
		get
		{
			return (Rectangle)_HorizontalTrackRectSubject.ElementInstance;
		}
		set
		{
			_HorizontalTrackRectSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalSmallDecrease
	{
		get
		{
			return (RepeatButton)_HorizontalSmallDecreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalSmallDecreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalLargeDecrease
	{
		get
		{
			return (RepeatButton)_HorizontalLargeDecreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalLargeDecreaseSubject.ElementInstance = value;
		}
	}

	private CompositeTransform HorizontalThumbTransform
	{
		get
		{
			return (CompositeTransform)_HorizontalThumbTransformSubject.ElementInstance;
		}
		set
		{
			_HorizontalThumbTransformSubject.ElementInstance = value;
		}
	}

	private Thumb HorizontalThumb
	{
		get
		{
			return (Thumb)_HorizontalThumbSubject.ElementInstance;
		}
		set
		{
			_HorizontalThumbSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalLargeIncrease
	{
		get
		{
			return (RepeatButton)_HorizontalLargeIncreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalLargeIncreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalSmallIncrease
	{
		get
		{
			return (RepeatButton)_HorizontalSmallIncreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalSmallIncreaseSubject.ElementInstance = value;
		}
	}

	private Grid HorizontalRoot
	{
		get
		{
			return (Grid)_HorizontalRootSubject.ElementInstance;
		}
		set
		{
			_HorizontalRootSubject.ElementInstance = value;
		}
	}

	private Border HorizontalPanningThumb
	{
		get
		{
			return (Border)_HorizontalPanningThumbSubject.ElementInstance;
		}
		set
		{
			_HorizontalPanningThumbSubject.ElementInstance = value;
		}
	}

	private Grid HorizontalPanningRoot
	{
		get
		{
			return (Grid)_HorizontalPanningRootSubject.ElementInstance;
		}
		set
		{
			_HorizontalPanningRootSubject.ElementInstance = value;
		}
	}

	private Rectangle VerticalTrackRect
	{
		get
		{
			return (Rectangle)_VerticalTrackRectSubject.ElementInstance;
		}
		set
		{
			_VerticalTrackRectSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalSmallDecrease
	{
		get
		{
			return (RepeatButton)_VerticalSmallDecreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalSmallDecreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalLargeDecrease
	{
		get
		{
			return (RepeatButton)_VerticalLargeDecreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalLargeDecreaseSubject.ElementInstance = value;
		}
	}

	private CompositeTransform VerticalThumbTransform
	{
		get
		{
			return (CompositeTransform)_VerticalThumbTransformSubject.ElementInstance;
		}
		set
		{
			_VerticalThumbTransformSubject.ElementInstance = value;
		}
	}

	private Thumb VerticalThumb
	{
		get
		{
			return (Thumb)_VerticalThumbSubject.ElementInstance;
		}
		set
		{
			_VerticalThumbSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalLargeIncrease
	{
		get
		{
			return (RepeatButton)_VerticalLargeIncreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalLargeIncreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalSmallIncrease
	{
		get
		{
			return (RepeatButton)_VerticalSmallIncreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalSmallIncreaseSubject.ElementInstance = value;
		}
	}

	private Grid VerticalRoot
	{
		get
		{
			return (Grid)_VerticalRootSubject.ElementInstance;
		}
		set
		{
			_VerticalRootSubject.ElementInstance = value;
		}
	}

	private Border VerticalPanningThumb
	{
		get
		{
			return (Border)_VerticalPanningThumbSubject.ElementInstance;
		}
		set
		{
			_VerticalPanningThumbSubject.ElementInstance = value;
		}
	}

	private Grid VerticalPanningRoot
	{
		get
		{
			return (Grid)_VerticalPanningRootSubject.ElementInstance;
		}
		set
		{
			_VerticalPanningRootSubject.ElementInstance = value;
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

	private VisualState Vertical_Normal
	{
		get
		{
			return (VisualState)_Vertical_NormalSubject.ElementInstance;
		}
		set
		{
			_Vertical_NormalSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_Normal
	{
		get
		{
			return (VisualState)_Horizontal_NormalSubject.ElementInstance;
		}
		set
		{
			_Horizontal_NormalSubject.ElementInstance = value;
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

	private VisualState Vertical_Disabled
	{
		get
		{
			return (VisualState)_Vertical_DisabledSubject.ElementInstance;
		}
		set
		{
			_Vertical_DisabledSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_Disabled
	{
		get
		{
			return (VisualState)_Horizontal_DisabledSubject.ElementInstance;
		}
		set
		{
			_Horizontal_DisabledSubject.ElementInstance = value;
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

	private VisualState TouchIndicator
	{
		get
		{
			return (VisualState)_TouchIndicatorSubject.ElementInstance;
		}
		set
		{
			_TouchIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_TouchIndicator
	{
		get
		{
			return (VisualState)_Vertical_TouchIndicatorSubject.ElementInstance;
		}
		set
		{
			_Vertical_TouchIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_TouchIndicator
	{
		get
		{
			return (VisualState)_Horizontal_TouchIndicatorSubject.ElementInstance;
		}
		set
		{
			_Horizontal_TouchIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState MouseIndicator
	{
		get
		{
			return (VisualState)_MouseIndicatorSubject.ElementInstance;
		}
		set
		{
			_MouseIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_MouseIndicator
	{
		get
		{
			return (VisualState)_Vertical_MouseIndicatorSubject.ElementInstance;
		}
		set
		{
			_Vertical_MouseIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_MouseIndicator
	{
		get
		{
			return (VisualState)_Horizontal_MouseIndicatorSubject.ElementInstance;
		}
		set
		{
			_Horizontal_MouseIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState NoIndicator
	{
		get
		{
			return (VisualState)_NoIndicatorSubject.ElementInstance;
		}
		set
		{
			_NoIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ScrollingIndicatorStates
	{
		get
		{
			return (VisualStateGroup)_ScrollingIndicatorStatesSubject.ElementInstance;
		}
		set
		{
			_ScrollingIndicatorStatesSubject.ElementInstance = value;
		}
	}

	private VisualState Collapsed
	{
		get
		{
			return (VisualState)_CollapsedSubject.ElementInstance;
		}
		set
		{
			_CollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_Collapsed
	{
		get
		{
			return (VisualState)_Vertical_CollapsedSubject.ElementInstance;
		}
		set
		{
			_Vertical_CollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_Collapsed
	{
		get
		{
			return (VisualState)_Horizontal_CollapsedSubject.ElementInstance;
		}
		set
		{
			_Horizontal_CollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Expanded
	{
		get
		{
			return (VisualState)_ExpandedSubject.ElementInstance;
		}
		set
		{
			_ExpandedSubject.ElementInstance = value;
		}
	}

	private VisualState ExpandedWithoutAnimation
	{
		get
		{
			return (VisualState)_ExpandedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_ExpandedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualState CollapsedWithoutAnimation
	{
		get
		{
			return (VisualState)_CollapsedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_CollapsedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ConsciousStates
	{
		get
		{
			return (VisualStateGroup)_ConsciousStatesSubject.ElementInstance;
		}
		set
		{
			_ConsciousStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_124)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = 
			{
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "HorizontalRoot",
					Visibility = Visibility.Collapsed,
					IsHitTestVisible = false,
					ColumnDefinitions = 
					{
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						},
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						},
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
							Width = new GridLength(1.0, GridUnitType.Auto)
						}
					},
					Children = 
					{
						(UIElement)new Rectangle
						{
							IsParsing = true,
							Name = "HorizontalTrackRect",
							Opacity = 0.0,
							Margin = new Thickness(0.0)
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Rectangle c134)
						{
							nameScope.RegisterName("HorizontalTrackRect", c134);
							HorizontalTrackRect = c134;
							Grid.SetColumnSpan(c134, 5);
							ResourceResolverSingleton.Instance.ApplyResource(c134, Shape.StrokeThicknessProperty, "ScrollBarTrackBorderThemeThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c134, Shape.FillProperty, "ScrollBarTrackFill", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c134, Shape.StrokeProperty, "ScrollBarTrackStroke", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_0 = c134;
							c134.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalSmallDecrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							AllowFocusOnInteraction = false,
							VerticalAlignment = VerticalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c135)
						{
							nameScope.RegisterName("HorizontalSmallDecrease", c135);
							HorizontalSmallDecrease = c135;
							Grid.SetColumn(c135, 0);
							ResourceResolverSingleton.Instance.ApplyResource(c135, FrameworkElement.MinHeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c135, Control.TemplateProperty, "XamlDefaultScrollBar_HorizontalDecrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c135, FrameworkElement.WidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_1 = c135;
							c135.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalLargeDecrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							IsTabStop = false,
							Interval = 50,
							Width = 0.0,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c136)
						{
							nameScope.RegisterName("HorizontalLargeDecrease", c136);
							HorizontalLargeDecrease = c136;
							Grid.SetColumn(c136, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c136, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_2 = c136;
							c136.CreationComplete();
						}),
						(UIElement)new Thumb
						{
							IsParsing = true,
							Name = "HorizontalThumb",
							Opacity = 0.0,
							VerticalAlignment = VerticalAlignment.Bottom,
							RenderTransformOrigin = new Point(0.5, 1.0),
							RenderTransform = new CompositeTransform
							{
								ScaleX = 1.0,
								TranslateX = 0.0
							}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(CompositeTransform c137)
							{
								nameScope.RegisterName("HorizontalThumbTransform", c137);
								HorizontalThumbTransform = c137;
								ResourceResolverSingleton.Instance.ApplyResource(c137, CompositeTransform.ScaleYProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c137, CompositeTransform.TranslateYProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								_component_3 = c137;
								NameScope.SetNameScope(_component_3, nameScope);
							})
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Thumb c138)
						{
							nameScope.RegisterName("HorizontalThumb", c138);
							HorizontalThumb = c138;
							Grid.SetColumn(c138, 2);
							ResourceResolverSingleton.Instance.ApplyResource(c138, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c138, Control.TemplateProperty, "XamlDefaultScrollBar_HorizontalThumbTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c138, FrameworkElement.HeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c138, FrameworkElement.MinWidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c138, AccessibilityView.Raw);
							_component_4 = c138;
							c138.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalLargeIncrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							IsTabStop = false,
							Interval = 50,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c139)
						{
							nameScope.RegisterName("HorizontalLargeIncrease", c139);
							HorizontalLargeIncrease = c139;
							Grid.SetColumn(c139, 3);
							ResourceResolverSingleton.Instance.ApplyResource(c139, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_5 = c139;
							c139.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalSmallIncrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							AllowFocusOnInteraction = false,
							VerticalAlignment = VerticalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c140)
						{
							nameScope.RegisterName("HorizontalSmallIncrease", c140);
							HorizontalSmallIncrease = c140;
							Grid.SetColumn(c140, 4);
							ResourceResolverSingleton.Instance.ApplyResource(c140, FrameworkElement.MinHeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c140, Control.TemplateProperty, "XamlDefaultScrollBar_HorizontalIncrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c140, FrameworkElement.WidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_6 = c140;
							c140.CreationComplete();
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c141)
				{
					nameScope.RegisterName("HorizontalRoot", c141);
					HorizontalRoot = c141;
					c141.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c141.SetBinding(Grid.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c141.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c142)
				{
					c142.Name = "HorizontalRoot";
					_HorizontalRootSubject.ElementInstance = c142;
					c142.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "HorizontalPanningRoot",
					MinWidth = 24.0,
					Visibility = Visibility.Collapsed,
					Opacity = 0.0,
					Children = { (UIElement)new Border
					{
						IsParsing = true,
						Name = "HorizontalPanningThumb",
						VerticalAlignment = VerticalAlignment.Bottom,
						HorizontalAlignment = HorizontalAlignment.Left,
						BorderThickness = new Thickness(0.0),
						Height = 2.0,
						MinWidth = 32.0,
						Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Border c143)
					{
						nameScope.RegisterName("HorizontalPanningThumb", c143);
						HorizontalPanningThumb = c143;
						ResourceResolverSingleton.Instance.ApplyResource(c143, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
						_component_7 = c143;
						c143.CreationComplete();
					}) }
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c144)
				{
					nameScope.RegisterName("HorizontalPanningRoot", c144);
					HorizontalPanningRoot = c144;
					c144.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c145)
				{
					c145.Name = "HorizontalPanningRoot";
					_HorizontalPanningRootSubject.ElementInstance = c145;
					c145.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "VerticalRoot",
					Visibility = Visibility.Collapsed,
					IsHitTestVisible = false,
					RowDefinitions = 
					{
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						},
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						},
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
					Children = 
					{
						(UIElement)new Rectangle
						{
							IsParsing = true,
							Name = "VerticalTrackRect",
							Opacity = 0.0,
							Margin = new Thickness(0.0)
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Rectangle c151)
						{
							nameScope.RegisterName("VerticalTrackRect", c151);
							VerticalTrackRect = c151;
							Grid.SetRowSpan(c151, 5);
							ResourceResolverSingleton.Instance.ApplyResource(c151, Shape.StrokeThicknessProperty, "ScrollBarTrackBorderThemeThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c151, Shape.FillProperty, "ScrollBarTrackFill", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c151, Shape.StrokeProperty, "ScrollBarTrackStroke", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_8 = c151;
							c151.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalSmallDecrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							HorizontalAlignment = HorizontalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c152)
						{
							nameScope.RegisterName("VerticalSmallDecrease", c152);
							VerticalSmallDecrease = c152;
							ResourceResolverSingleton.Instance.ApplyResource(c152, FrameworkElement.HeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c152, FrameworkElement.MinWidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							Grid.SetRow(c152, 0);
							ResourceResolverSingleton.Instance.ApplyResource(c152, Control.TemplateProperty, "XamlDefaultScrollBar_VerticalDecrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_9 = c152;
							c152.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalLargeDecrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							Height = 0.0,
							IsTabStop = false,
							Interval = 50,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c153)
						{
							nameScope.RegisterName("VerticalLargeDecrease", c153);
							VerticalLargeDecrease = c153;
							Grid.SetRow(c153, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c153, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_10 = c153;
							c153.CreationComplete();
						}),
						(UIElement)new Thumb
						{
							IsParsing = true,
							Name = "VerticalThumb",
							Opacity = 0.0,
							RenderTransformOrigin = new Point(1.0, 0.5),
							RenderTransform = new CompositeTransform
							{
								ScaleY = 1.0,
								TranslateY = 0.0
							}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(CompositeTransform c154)
							{
								nameScope.RegisterName("VerticalThumbTransform", c154);
								VerticalThumbTransform = c154;
								ResourceResolverSingleton.Instance.ApplyResource(c154, CompositeTransform.ScaleXProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c154, CompositeTransform.TranslateXProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								_component_11 = c154;
								NameScope.SetNameScope(_component_11, nameScope);
							})
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Thumb c155)
						{
							nameScope.RegisterName("VerticalThumb", c155);
							VerticalThumb = c155;
							Grid.SetRow(c155, 2);
							ResourceResolverSingleton.Instance.ApplyResource(c155, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c155, Control.TemplateProperty, "XamlDefaultScrollBar_VerticalThumbTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c155, FrameworkElement.WidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c155, FrameworkElement.MinHeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c155, AccessibilityView.Raw);
							_component_12 = c155;
							c155.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalLargeIncrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							IsTabStop = false,
							Interval = 50,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c156)
						{
							nameScope.RegisterName("VerticalLargeIncrease", c156);
							VerticalLargeIncrease = c156;
							Grid.SetRow(c156, 3);
							ResourceResolverSingleton.Instance.ApplyResource(c156, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_13 = c156;
							c156.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalSmallIncrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							HorizontalAlignment = HorizontalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c157)
						{
							nameScope.RegisterName("VerticalSmallIncrease", c157);
							VerticalSmallIncrease = c157;
							ResourceResolverSingleton.Instance.ApplyResource(c157, FrameworkElement.HeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c157, FrameworkElement.MinWidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							Grid.SetRow(c157, 4);
							ResourceResolverSingleton.Instance.ApplyResource(c157, Control.TemplateProperty, "XamlDefaultScrollBar_VerticalIncrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_14 = c157;
							c157.CreationComplete();
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c158)
				{
					nameScope.RegisterName("VerticalRoot", c158);
					VerticalRoot = c158;
					c158.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c158.SetBinding(Grid.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c158.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c159)
				{
					c159.Name = "VerticalRoot";
					_VerticalRootSubject.ElementInstance = c159;
					c159.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "VerticalPanningRoot",
					MinHeight = 24.0,
					Visibility = Visibility.Collapsed,
					Opacity = 0.0,
					Children = { (UIElement)new Border
					{
						IsParsing = true,
						Name = "VerticalPanningThumb",
						VerticalAlignment = VerticalAlignment.Top,
						HorizontalAlignment = HorizontalAlignment.Right,
						BorderThickness = new Thickness(0.0),
						Width = 2.0,
						MinHeight = 32.0,
						Margin = new Thickness(2.0, 0.0, 2.0, 0.0)
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Border c160)
					{
						nameScope.RegisterName("VerticalPanningThumb", c160);
						VerticalPanningThumb = c160;
						ResourceResolverSingleton.Instance.ApplyResource(c160, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
						_component_15 = c160;
						c160.CreationComplete();
					}) }
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c161)
				{
					nameScope.RegisterName("VerticalPanningRoot", c161);
					VerticalPanningRoot = c161;
					c161.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c162)
				{
					c162.Name = "VerticalPanningRoot";
					_VerticalPanningRootSubject.ElementInstance = c162;
					c162.Visibility = Visibility.Collapsed;
				})
			}
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c163)
		{
			nameScope.RegisterName("Root", c163);
			Root = c163;
			VisualStateManager.SetVisualStateGroups(c163, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c164)
						{
							nameScope.RegisterName("Normal", c164);
							Normal = c164;
						}),
						new VisualState
						{
							Name = "Vertical_Normal"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c165)
						{
							nameScope.RegisterName("Vertical_Normal", c165);
							Vertical_Normal = c165;
						}),
						new VisualState
						{
							Name = "Horizontal_Normal"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c166)
						{
							nameScope.RegisterName("Horizontal_Normal", c166);
							Horizontal_Normal = c166;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c167)
						{
							nameScope.RegisterName("Disabled", c167);
							Disabled = c167;
							MarkupHelper.SetVisualStateLazy(c167, delegate
							{
								c167.Name = "Disabled";
								c167.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Opacity"), "0.5"));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c167.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Vertical_Disabled"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c168)
						{
							nameScope.RegisterName("Vertical_Disabled", c168);
							Vertical_Disabled = c168;
							MarkupHelper.SetVisualStateLazy(c168, delegate
							{
								c168.Name = "Vertical_Disabled";
								c168.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c168.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c168.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Opacity"), "0.5"));
								c168.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c168.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c168.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_Disabled"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c169)
						{
							nameScope.RegisterName("Horizontal_Disabled", c169);
							Horizontal_Disabled = c169;
							MarkupHelper.SetVisualStateLazy(c169, delegate
							{
								c169.Name = "Horizontal_Disabled";
								c169.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c169.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c169.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Opacity"), "0.5"));
								c169.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c169.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c169.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c170)
				{
					nameScope.RegisterName("CommonStates", c170);
					CommonStates = c170;
				}),
				new VisualStateGroup
				{
					Name = "ScrollingIndicatorStates",
					States = 
					{
						new VisualState
						{
							Name = "TouchIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c171)
						{
							nameScope.RegisterName("TouchIndicator", c171);
							TouchIndicator = c171;
							MarkupHelper.SetVisualStateLazy(c171, delegate
							{
								c171.Name = "TouchIndicator";
								c171.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c171.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c171.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
								c171.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_TouchIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c172)
						{
							nameScope.RegisterName("Vertical_TouchIndicator", c172);
							Vertical_TouchIndicator = c172;
							MarkupHelper.SetVisualStateLazy(c172, delegate
							{
								c172.Name = "Vertical_TouchIndicator";
								c172.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c172.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_TouchIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c173)
						{
							nameScope.RegisterName("Horizontal_TouchIndicator", c173);
							Horizontal_TouchIndicator = c173;
							MarkupHelper.SetVisualStateLazy(c173, delegate
							{
								c173.Name = "Horizontal_TouchIndicator";
								c173.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c173.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "MouseIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c174)
						{
							nameScope.RegisterName("MouseIndicator", c174);
							MouseIndicator = c174;
							MarkupHelper.SetVisualStateLazy(c174, delegate
							{
								c174.Name = "MouseIndicator";
								c174.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c174.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c174.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c174.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c174.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Opacity"), "1"));
								c174.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_MouseIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c175)
						{
							nameScope.RegisterName("Vertical_MouseIndicator", c175);
							Vertical_MouseIndicator = c175;
							MarkupHelper.SetVisualStateLazy(c175, delegate
							{
								c175.Name = "Vertical_MouseIndicator";
								c175.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c175.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c175.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_MouseIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c176)
						{
							nameScope.RegisterName("Horizontal_MouseIndicator", c176);
							Horizontal_MouseIndicator = c176;
							MarkupHelper.SetVisualStateLazy(c176, delegate
							{
								c176.Name = "Horizontal_MouseIndicator";
								c176.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c176.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c176.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "NoIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c177)
						{
							nameScope.RegisterName("NoIndicator", c177);
							NoIndicator = c177;
							MarkupHelper.SetVisualStateLazy(c177, delegate
							{
								c177.Name = "NoIndicator";
								c177.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ColorAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c178)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c178, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c178, "HorizontalThumb");
											Storyboard.SetTarget(c178, _HorizontalThumbSubject);
											Storyboard.SetTargetProperty(c178, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c178, ColorAnimation.ToProperty, "ScrollBarPanningThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_16 = c178;
											NameScope.SetNameScope(_component_16, nameScope);
										}),
										(Timeline)new ColorAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c179)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c179, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c179, "VerticalThumb");
											Storyboard.SetTarget(c179, _VerticalThumbSubject);
											Storyboard.SetTargetProperty(c179, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c179, ColorAnimation.ToProperty, "ScrollBarPanningThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_17 = c179;
											NameScope.SetNameScope(_component_17, nameScope);
										}),
										(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c180)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c180, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c180, "VerticalThumbTransform");
											Storyboard.SetTarget(c180, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c180, "ScaleX");
											ResourceResolverSingleton.Instance.ApplyResource(c180, DoubleAnimation.ToProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_18 = c180;
											NameScope.SetNameScope(_component_18, nameScope);
										}),
										(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c181)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c181, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c181, "VerticalThumbTransform");
											Storyboard.SetTarget(c181, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c181, "TranslateX");
											ResourceResolverSingleton.Instance.ApplyResource(c181, DoubleAnimation.ToProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_19 = c181;
											NameScope.SetNameScope(_component_19, nameScope);
										}),
										(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c182)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c182, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c182, "HorizontalThumbTransform");
											Storyboard.SetTarget(c182, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c182, "ScaleY");
											ResourceResolverSingleton.Instance.ApplyResource(c182, DoubleAnimation.ToProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_20 = c182;
											NameScope.SetNameScope(_component_20, nameScope);
										}),
										(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c183)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c183, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c183, "HorizontalThumbTransform");
											Storyboard.SetTarget(c183, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c183, "TranslateY");
											ResourceResolverSingleton.Instance.ApplyResource(c183, DoubleAnimation.ToProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_21 = c183;
											NameScope.SetNameScope(_component_21, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c184)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c184, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c184, "VerticalSmallIncrease");
											Storyboard.SetTarget(c184, _VerticalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c184, "Opacity");
											_component_22 = c184;
											NameScope.SetNameScope(_component_22, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c185)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c185, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c185, "VerticalLargeIncrease");
											Storyboard.SetTarget(c185, _VerticalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c185, "Opacity");
											_component_23 = c185;
											NameScope.SetNameScope(_component_23, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c186)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c186, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c186, "VerticalLargeDecrease");
											Storyboard.SetTarget(c186, _VerticalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c186, "Opacity");
											_component_24 = c186;
											NameScope.SetNameScope(_component_24, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c187)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c187, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c187, "VerticalThumb");
											Storyboard.SetTarget(c187, _VerticalThumbSubject);
											Storyboard.SetTargetProperty(c187, "Opacity");
											_component_25 = c187;
											NameScope.SetNameScope(_component_25, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c188)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c188, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c188, "VerticalSmallDecrease");
											Storyboard.SetTarget(c188, _VerticalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c188, "Opacity");
											_component_26 = c188;
											NameScope.SetNameScope(_component_26, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c189)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c189, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c189, "VerticalTrackRect");
											Storyboard.SetTarget(c189, _VerticalTrackRectSubject);
											Storyboard.SetTargetProperty(c189, "Opacity");
											_component_27 = c189;
											NameScope.SetNameScope(_component_27, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c190)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c190, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c190, "HorizontalSmallIncrease");
											Storyboard.SetTarget(c190, _HorizontalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c190, "Opacity");
											_component_28 = c190;
											NameScope.SetNameScope(_component_28, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c191)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c191, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c191, "HorizontalLargeIncrease");
											Storyboard.SetTarget(c191, _HorizontalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c191, "Opacity");
											_component_29 = c191;
											NameScope.SetNameScope(_component_29, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c192)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c192, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c192, "HorizontalLargeDecrease");
											Storyboard.SetTarget(c192, _HorizontalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c192, "Opacity");
											_component_30 = c192;
											NameScope.SetNameScope(_component_30, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c193)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c193, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c193, "HorizontalThumb");
											Storyboard.SetTarget(c193, _HorizontalThumbSubject);
											Storyboard.SetTargetProperty(c193, "Opacity");
											_component_31 = c193;
											NameScope.SetNameScope(_component_31, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c194)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c194, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c194, "HorizontalSmallDecrease");
											Storyboard.SetTarget(c194, _HorizontalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c194, "Opacity");
											_component_32 = c194;
											NameScope.SetNameScope(_component_32, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c195)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c195, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c195, "HorizontalTrackRect");
											Storyboard.SetTarget(c195, _HorizontalTrackRectSubject);
											Storyboard.SetTargetProperty(c195, "Opacity");
											_component_33 = c195;
											NameScope.SetNameScope(_component_33, nameScope);
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												Value = Visibility.Collapsed
											}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c196)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c196, ObjectKeyFrame.KeyTimeProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
												_component_34 = c196;
												NameScope.SetNameScope(_component_34, nameScope);
											}) }
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c197)
										{
											Storyboard.SetTargetName(c197, "HorizontalRoot");
											Storyboard.SetTarget(c197, _HorizontalRootSubject);
											Storyboard.SetTargetProperty(c197, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												Value = Visibility.Collapsed
											}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c198)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c198, ObjectKeyFrame.KeyTimeProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
												_component_35 = c198;
												NameScope.SetNameScope(_component_35, nameScope);
											}) }
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c199)
										{
											Storyboard.SetTargetName(c199, "VerticalRoot");
											Storyboard.SetTarget(c199, _VerticalRootSubject);
											Storyboard.SetTargetProperty(c199, "Visibility");
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c200)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c200, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c200, "HorizontalPanningRoot");
											Storyboard.SetTarget(c200, _HorizontalPanningRootSubject);
											Storyboard.SetTargetProperty(c200, "Opacity");
											_component_36 = c200;
											NameScope.SetNameScope(_component_36, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c201)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c201, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c201, "VerticalPanningRoot");
											Storyboard.SetTarget(c201, _VerticalPanningRootSubject);
											Storyboard.SetTargetProperty(c201, "Opacity");
											_component_37 = c201;
											NameScope.SetNameScope(_component_37, nameScope);
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												Value = Visibility.Collapsed
											}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c202)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c202, ObjectKeyFrame.KeyTimeProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
												_component_38 = c202;
												NameScope.SetNameScope(_component_38, nameScope);
											}) }
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c203)
										{
											Storyboard.SetTargetName(c203, "HorizontalPanningRoot");
											Storyboard.SetTarget(c203, _HorizontalPanningRootSubject);
											Storyboard.SetTargetProperty(c203, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												Value = Visibility.Collapsed
											}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DiscreteObjectKeyFrame c204)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c204, ObjectKeyFrame.KeyTimeProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
												_component_39 = c204;
												NameScope.SetNameScope(_component_39, nameScope);
											}) }
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ObjectAnimationUsingKeyFrames c205)
										{
											Storyboard.SetTargetName(c205, "VerticalPanningRoot");
											Storyboard.SetTarget(c205, _VerticalPanningRootSubject);
											Storyboard.SetTargetProperty(c205, "Visibility");
										})
									}
								};
							});
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c206)
				{
					nameScope.RegisterName("ScrollingIndicatorStates", c206);
					ScrollingIndicatorStates = c206;
				}),
				new VisualStateGroup
				{
					Name = "ConsciousStates",
					Transitions = { new VisualTransition
					{
						From = "Expanded",
						To = "Collapsed"
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualTransition c207)
					{
						MarkupHelper.SetVisualTransitionLazy(c207, delegate
						{
							c207.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ColorAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c208)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c208, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c208, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c208, "HorizontalThumb");
										Storyboard.SetTarget(c208, _HorizontalThumbSubject);
										Storyboard.SetTargetProperty(c208, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
										ResourceResolverSingleton.Instance.ApplyResource(c208, ColorAnimation.ToProperty, "ScrollBarPanningThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_40 = c208;
										NameScope.SetNameScope(_component_40, nameScope);
									}),
									(Timeline)new ColorAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c209)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c209, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c209, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c209, "VerticalThumb");
										Storyboard.SetTarget(c209, _VerticalThumbSubject);
										Storyboard.SetTargetProperty(c209, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
										ResourceResolverSingleton.Instance.ApplyResource(c209, ColorAnimation.ToProperty, "ScrollBarPanningThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_41 = c209;
										NameScope.SetNameScope(_component_41, nameScope);
									}),
									(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c210)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c210, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c210, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c210, "VerticalThumbTransform");
										Storyboard.SetTarget(c210, _VerticalThumbTransformSubject);
										Storyboard.SetTargetProperty(c210, "ScaleX");
										ResourceResolverSingleton.Instance.ApplyResource(c210, DoubleAnimation.ToProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_42 = c210;
										NameScope.SetNameScope(_component_42, nameScope);
									}),
									(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c211)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c211, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c211, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c211, "VerticalThumbTransform");
										Storyboard.SetTarget(c211, _VerticalThumbTransformSubject);
										Storyboard.SetTargetProperty(c211, "TranslateX");
										ResourceResolverSingleton.Instance.ApplyResource(c211, DoubleAnimation.ToProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_43 = c211;
										NameScope.SetNameScope(_component_43, nameScope);
									}),
									(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c212)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c212, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c212, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c212, "HorizontalThumbTransform");
										Storyboard.SetTarget(c212, _HorizontalThumbTransformSubject);
										Storyboard.SetTargetProperty(c212, "ScaleY");
										ResourceResolverSingleton.Instance.ApplyResource(c212, DoubleAnimation.ToProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_44 = c212;
										NameScope.SetNameScope(_component_44, nameScope);
									}),
									(Timeline)new DoubleAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c213)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c213, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c213, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c213, "HorizontalThumbTransform");
										Storyboard.SetTarget(c213, _HorizontalThumbTransformSubject);
										Storyboard.SetTargetProperty(c213, "TranslateY");
										ResourceResolverSingleton.Instance.ApplyResource(c213, DoubleAnimation.ToProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										_component_45 = c213;
										NameScope.SetNameScope(_component_45, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c214)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c214, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c214, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c214, "VerticalSmallIncrease");
										Storyboard.SetTarget(c214, _VerticalSmallIncreaseSubject);
										Storyboard.SetTargetProperty(c214, "Opacity");
										_component_46 = c214;
										NameScope.SetNameScope(_component_46, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c215)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c215, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c215, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c215, "VerticalLargeIncrease");
										Storyboard.SetTarget(c215, _VerticalLargeIncreaseSubject);
										Storyboard.SetTargetProperty(c215, "Opacity");
										_component_47 = c215;
										NameScope.SetNameScope(_component_47, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c216)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c216, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c216, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c216, "VerticalLargeDecrease");
										Storyboard.SetTarget(c216, _VerticalLargeDecreaseSubject);
										Storyboard.SetTargetProperty(c216, "Opacity");
										_component_48 = c216;
										NameScope.SetNameScope(_component_48, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c217)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c217, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c217, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c217, "VerticalSmallDecrease");
										Storyboard.SetTarget(c217, _VerticalSmallDecreaseSubject);
										Storyboard.SetTargetProperty(c217, "Opacity");
										_component_49 = c217;
										NameScope.SetNameScope(_component_49, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c218)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c218, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c218, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c218, "VerticalTrackRect");
										Storyboard.SetTarget(c218, _VerticalTrackRectSubject);
										Storyboard.SetTargetProperty(c218, "Opacity");
										_component_50 = c218;
										NameScope.SetNameScope(_component_50, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c219)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c219, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c219, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c219, "HorizontalSmallIncrease");
										Storyboard.SetTarget(c219, _HorizontalSmallIncreaseSubject);
										Storyboard.SetTargetProperty(c219, "Opacity");
										_component_51 = c219;
										NameScope.SetNameScope(_component_51, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c220)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c220, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c220, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c220, "HorizontalLargeIncrease");
										Storyboard.SetTarget(c220, _HorizontalLargeIncreaseSubject);
										Storyboard.SetTargetProperty(c220, "Opacity");
										_component_52 = c220;
										NameScope.SetNameScope(_component_52, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c221)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c221, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c221, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c221, "HorizontalLargeDecrease");
										Storyboard.SetTarget(c221, _HorizontalLargeDecreaseSubject);
										Storyboard.SetTargetProperty(c221, "Opacity");
										_component_53 = c221;
										NameScope.SetNameScope(_component_53, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c222)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c222, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c222, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c222, "HorizontalSmallDecrease");
										Storyboard.SetTarget(c222, _HorizontalSmallDecreaseSubject);
										Storyboard.SetTargetProperty(c222, "Opacity");
										_component_54 = c222;
										NameScope.SetNameScope(_component_54, nameScope);
									}),
									(Timeline)new DoubleAnimation
									{
										To = 0.0
									}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c223)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c223, Timeline.DurationProperty, "ScrollBarContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c223, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
										Storyboard.SetTargetName(c223, "HorizontalTrackRect");
										Storyboard.SetTarget(c223, _HorizontalTrackRectSubject);
										Storyboard.SetTargetProperty(c223, "Opacity");
										_component_55 = c223;
										NameScope.SetNameScope(_component_55, nameScope);
									})
								}
							};
						});
					}) },
					States = 
					{
						new VisualState
						{
							Name = "Collapsed"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c224)
						{
							nameScope.RegisterName("Collapsed", c224);
							Collapsed = c224;
						}),
						new VisualState
						{
							Name = "Vertical_Collapsed"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c225)
						{
							nameScope.RegisterName("Vertical_Collapsed", c225);
							Vertical_Collapsed = c225;
						}),
						new VisualState
						{
							Name = "Horizontal_Collapsed"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c226)
						{
							nameScope.RegisterName("Horizontal_Collapsed", c226);
							Horizontal_Collapsed = c226;
						}),
						new VisualState
						{
							Name = "Expanded"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c227)
						{
							nameScope.RegisterName("Expanded", c227);
							Expanded = c227;
							MarkupHelper.SetVisualStateLazy(c227, delegate
							{
								c227.Name = "Expanded";
								c227.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c227.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c227.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c227.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c227.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c227.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c227.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ColorAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c228)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c228, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c228, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c228, "HorizontalThumb");
											Storyboard.SetTarget(c228, _HorizontalThumbSubject);
											Storyboard.SetTargetProperty(c228, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c228, ColorAnimation.ToProperty, "ScrollBarThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_56 = c228;
											NameScope.SetNameScope(_component_56, nameScope);
										}),
										(Timeline)new ColorAnimation().ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c229)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c229, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c229, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c229, "VerticalThumb");
											Storyboard.SetTarget(c229, _VerticalThumbSubject);
											Storyboard.SetTargetProperty(c229, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c229, ColorAnimation.ToProperty, "ScrollBarThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_57 = c229;
											NameScope.SetNameScope(_component_57, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c230)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c230, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c230, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c230, "VerticalThumbTransform");
											Storyboard.SetTarget(c230, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c230, "ScaleX");
											_component_58 = c230;
											NameScope.SetNameScope(_component_58, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c231)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c231, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c231, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c231, "VerticalThumbTransform");
											Storyboard.SetTarget(c231, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c231, "TranslateX");
											_component_59 = c231;
											NameScope.SetNameScope(_component_59, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c232)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c232, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c232, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c232, "HorizontalThumbTransform");
											Storyboard.SetTarget(c232, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c232, "ScaleY");
											_component_60 = c232;
											NameScope.SetNameScope(_component_60, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c233)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c233, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c233, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c233, "HorizontalThumbTransform");
											Storyboard.SetTarget(c233, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c233, "TranslateY");
											_component_61 = c233;
											NameScope.SetNameScope(_component_61, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c234)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c234, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c234, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c234, "VerticalSmallIncrease");
											Storyboard.SetTarget(c234, _VerticalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c234, "Opacity");
											_component_62 = c234;
											NameScope.SetNameScope(_component_62, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c235)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c235, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c235, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c235, "VerticalLargeIncrease");
											Storyboard.SetTarget(c235, _VerticalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c235, "Opacity");
											_component_63 = c235;
											NameScope.SetNameScope(_component_63, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c236)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c236, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c236, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c236, "VerticalLargeDecrease");
											Storyboard.SetTarget(c236, _VerticalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c236, "Opacity");
											_component_64 = c236;
											NameScope.SetNameScope(_component_64, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c237)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c237, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c237, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c237, "VerticalSmallDecrease");
											Storyboard.SetTarget(c237, _VerticalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c237, "Opacity");
											_component_65 = c237;
											NameScope.SetNameScope(_component_65, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c238)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c238, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c238, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c238, "VerticalTrackRect");
											Storyboard.SetTarget(c238, _VerticalTrackRectSubject);
											Storyboard.SetTargetProperty(c238, "Opacity");
											_component_66 = c238;
											NameScope.SetNameScope(_component_66, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c239)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c239, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c239, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c239, "HorizontalSmallIncrease");
											Storyboard.SetTarget(c239, _HorizontalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c239, "Opacity");
											_component_67 = c239;
											NameScope.SetNameScope(_component_67, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c240)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c240, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c240, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c240, "HorizontalLargeIncrease");
											Storyboard.SetTarget(c240, _HorizontalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c240, "Opacity");
											_component_68 = c240;
											NameScope.SetNameScope(_component_68, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c241)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c241, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c241, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c241, "HorizontalLargeDecrease");
											Storyboard.SetTarget(c241, _HorizontalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c241, "Opacity");
											_component_69 = c241;
											NameScope.SetNameScope(_component_69, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c242)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c242, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c242, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c242, "HorizontalSmallDecrease");
											Storyboard.SetTarget(c242, _HorizontalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c242, "Opacity");
											_component_70 = c242;
											NameScope.SetNameScope(_component_70, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c243)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c243, Timeline.DurationProperty, "ScrollBarExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c243, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c243, "HorizontalTrackRect");
											Storyboard.SetTarget(c243, _HorizontalTrackRectSubject);
											Storyboard.SetTargetProperty(c243, "Opacity");
											_component_71 = c243;
											NameScope.SetNameScope(_component_71, nameScope);
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "ExpandedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c244)
						{
							nameScope.RegisterName("ExpandedWithoutAnimation", c244);
							ExpandedWithoutAnimation = c244;
							MarkupHelper.SetVisualStateLazy(c244, delegate
							{
								c244.Name = "ExpandedWithoutAnimation";
								c244.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c244.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c244.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c244.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c244.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c244.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c244.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ColorAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c245)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c245, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c245, "HorizontalThumb");
											Storyboard.SetTarget(c245, _HorizontalThumbSubject);
											Storyboard.SetTargetProperty(c245, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c245, ColorAnimation.ToProperty, "ScrollBarThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_72 = c245;
											NameScope.SetNameScope(_component_72, nameScope);
										}),
										(Timeline)new ColorAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c246)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c246, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c246, "VerticalThumb");
											Storyboard.SetTarget(c246, _VerticalThumbSubject);
											Storyboard.SetTargetProperty(c246, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c246, ColorAnimation.ToProperty, "ScrollBarThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_73 = c246;
											NameScope.SetNameScope(_component_73, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c247)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c247, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c247, "VerticalThumbTransform");
											Storyboard.SetTarget(c247, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c247, "ScaleX");
											_component_74 = c247;
											NameScope.SetNameScope(_component_74, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c248)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c248, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c248, "VerticalThumbTransform");
											Storyboard.SetTarget(c248, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c248, "TranslateX");
											_component_75 = c248;
											NameScope.SetNameScope(_component_75, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c249)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c249, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c249, "HorizontalThumbTransform");
											Storyboard.SetTarget(c249, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c249, "ScaleY");
											_component_76 = c249;
											NameScope.SetNameScope(_component_76, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c250)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c250, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c250, "HorizontalThumbTransform");
											Storyboard.SetTarget(c250, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c250, "TranslateY");
											_component_77 = c250;
											NameScope.SetNameScope(_component_77, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c251)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c251, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c251, "VerticalSmallIncrease");
											Storyboard.SetTarget(c251, _VerticalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c251, "Opacity");
											_component_78 = c251;
											NameScope.SetNameScope(_component_78, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c252)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c252, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c252, "VerticalLargeIncrease");
											Storyboard.SetTarget(c252, _VerticalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c252, "Opacity");
											_component_79 = c252;
											NameScope.SetNameScope(_component_79, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c253)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c253, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c253, "VerticalLargeDecrease");
											Storyboard.SetTarget(c253, _VerticalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c253, "Opacity");
											_component_80 = c253;
											NameScope.SetNameScope(_component_80, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c254)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c254, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c254, "VerticalSmallDecrease");
											Storyboard.SetTarget(c254, _VerticalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c254, "Opacity");
											_component_81 = c254;
											NameScope.SetNameScope(_component_81, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c255)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c255, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c255, "VerticalTrackRect");
											Storyboard.SetTarget(c255, _VerticalTrackRectSubject);
											Storyboard.SetTargetProperty(c255, "Opacity");
											_component_82 = c255;
											NameScope.SetNameScope(_component_82, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c256)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c256, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c256, "HorizontalSmallIncrease");
											Storyboard.SetTarget(c256, _HorizontalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c256, "Opacity");
											_component_83 = c256;
											NameScope.SetNameScope(_component_83, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c257)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c257, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c257, "HorizontalLargeIncrease");
											Storyboard.SetTarget(c257, _HorizontalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c257, "Opacity");
											_component_84 = c257;
											NameScope.SetNameScope(_component_84, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c258)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c258, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c258, "HorizontalLargeDecrease");
											Storyboard.SetTarget(c258, _HorizontalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c258, "Opacity");
											_component_85 = c258;
											NameScope.SetNameScope(_component_85, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c259)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c259, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c259, "HorizontalSmallDecrease");
											Storyboard.SetTarget(c259, _HorizontalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c259, "Opacity");
											_component_86 = c259;
											NameScope.SetNameScope(_component_86, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 1.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c260)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c260, Timeline.BeginTimeProperty, "ScrollBarExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c260, "HorizontalTrackRect");
											Storyboard.SetTarget(c260, _HorizontalTrackRectSubject);
											Storyboard.SetTargetProperty(c260, "Opacity");
											_component_87 = c260;
											NameScope.SetNameScope(_component_87, nameScope);
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "CollapsedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c261)
						{
							nameScope.RegisterName("CollapsedWithoutAnimation", c261);
							CollapsedWithoutAnimation = c261;
							MarkupHelper.SetVisualStateLazy(c261, delegate
							{
								c261.Name = "CollapsedWithoutAnimation";
								c261.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ColorAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c262)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c262, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c262, "HorizontalThumb");
											Storyboard.SetTarget(c262, _HorizontalThumbSubject);
											Storyboard.SetTargetProperty(c262, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c262, ColorAnimation.ToProperty, "ScrollBarPanningThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_88 = c262;
											NameScope.SetNameScope(_component_88, nameScope);
										}),
										(Timeline)new ColorAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ColorAnimation c263)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c263, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c263, "VerticalThumb");
											Storyboard.SetTarget(c263, _VerticalThumbSubject);
											Storyboard.SetTargetProperty(c263, "(Windows.UI.Xaml.Controls:Panel.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
											ResourceResolverSingleton.Instance.ApplyResource(c263, ColorAnimation.ToProperty, "ScrollBarPanningThumbBackgroundColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_89 = c263;
											NameScope.SetNameScope(_component_89, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c264)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c264, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c264, "VerticalThumbTransform");
											Storyboard.SetTarget(c264, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c264, "ScaleX");
											ResourceResolverSingleton.Instance.ApplyResource(c264, DoubleAnimation.ToProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_90 = c264;
											NameScope.SetNameScope(_component_90, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c265)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c265, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c265, "VerticalThumbTransform");
											Storyboard.SetTarget(c265, _VerticalThumbTransformSubject);
											Storyboard.SetTargetProperty(c265, "TranslateX");
											ResourceResolverSingleton.Instance.ApplyResource(c265, DoubleAnimation.ToProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_91 = c265;
											NameScope.SetNameScope(_component_91, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c266)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c266, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c266, "HorizontalThumbTransform");
											Storyboard.SetTarget(c266, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c266, "ScaleY");
											ResourceResolverSingleton.Instance.ApplyResource(c266, DoubleAnimation.ToProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_92 = c266;
											NameScope.SetNameScope(_component_92, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L))
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c267)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c267, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c267, "HorizontalThumbTransform");
											Storyboard.SetTarget(c267, _HorizontalThumbTransformSubject);
											Storyboard.SetTargetProperty(c267, "TranslateY");
											ResourceResolverSingleton.Instance.ApplyResource(c267, DoubleAnimation.ToProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											_component_93 = c267;
											NameScope.SetNameScope(_component_93, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c268)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c268, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c268, "VerticalSmallIncrease");
											Storyboard.SetTarget(c268, _VerticalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c268, "Opacity");
											_component_94 = c268;
											NameScope.SetNameScope(_component_94, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c269)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c269, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c269, "VerticalLargeIncrease");
											Storyboard.SetTarget(c269, _VerticalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c269, "Opacity");
											_component_95 = c269;
											NameScope.SetNameScope(_component_95, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c270)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c270, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c270, "VerticalLargeDecrease");
											Storyboard.SetTarget(c270, _VerticalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c270, "Opacity");
											_component_96 = c270;
											NameScope.SetNameScope(_component_96, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c271)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c271, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c271, "VerticalSmallDecrease");
											Storyboard.SetTarget(c271, _VerticalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c271, "Opacity");
											_component_97 = c271;
											NameScope.SetNameScope(_component_97, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c272)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c272, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c272, "VerticalTrackRect");
											Storyboard.SetTarget(c272, _VerticalTrackRectSubject);
											Storyboard.SetTargetProperty(c272, "Opacity");
											_component_98 = c272;
											NameScope.SetNameScope(_component_98, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c273)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c273, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c273, "HorizontalSmallIncrease");
											Storyboard.SetTarget(c273, _HorizontalSmallIncreaseSubject);
											Storyboard.SetTargetProperty(c273, "Opacity");
											_component_99 = c273;
											NameScope.SetNameScope(_component_99, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c274)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c274, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c274, "HorizontalLargeIncrease");
											Storyboard.SetTarget(c274, _HorizontalLargeIncreaseSubject);
											Storyboard.SetTargetProperty(c274, "Opacity");
											_component_100 = c274;
											NameScope.SetNameScope(_component_100, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c275)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c275, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c275, "HorizontalLargeDecrease");
											Storyboard.SetTarget(c275, _HorizontalLargeDecreaseSubject);
											Storyboard.SetTargetProperty(c275, "Opacity");
											_component_101 = c275;
											NameScope.SetNameScope(_component_101, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c276)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c276, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c276, "HorizontalSmallDecrease");
											Storyboard.SetTarget(c276, _HorizontalSmallDecreaseSubject);
											Storyboard.SetTargetProperty(c276, "Opacity");
											_component_102 = c276;
											NameScope.SetNameScope(_component_102, nameScope);
										}),
										(Timeline)new DoubleAnimation
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											To = 0.0
										}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(DoubleAnimation c277)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c277, Timeline.BeginTimeProperty, "ScrollBarContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
											Storyboard.SetTargetName(c277, "HorizontalTrackRect");
											Storyboard.SetTarget(c277, _HorizontalTrackRectSubject);
											Storyboard.SetTargetProperty(c277, "Opacity");
											_component_103 = c277;
											NameScope.SetNameScope(_component_103, nameScope);
										})
									}
								};
							});
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c278)
				{
					nameScope.RegisterName("ConsciousStates", c278);
					ConsciousStates = c278;
				})
			});
			c163.CreationComplete();
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
				_component_20.UpdateResourceBindings();
				_component_21.UpdateResourceBindings();
				_component_22.UpdateResourceBindings();
				_component_23.UpdateResourceBindings();
				_component_24.UpdateResourceBindings();
				_component_25.UpdateResourceBindings();
				_component_26.UpdateResourceBindings();
				_component_27.UpdateResourceBindings();
				_component_28.UpdateResourceBindings();
				_component_29.UpdateResourceBindings();
				_component_30.UpdateResourceBindings();
				_component_31.UpdateResourceBindings();
				_component_32.UpdateResourceBindings();
				_component_33.UpdateResourceBindings();
				_component_34.UpdateResourceBindings();
				_component_35.UpdateResourceBindings();
				_component_36.UpdateResourceBindings();
				_component_37.UpdateResourceBindings();
				_component_38.UpdateResourceBindings();
				_component_39.UpdateResourceBindings();
				_component_40.UpdateResourceBindings();
				_component_41.UpdateResourceBindings();
				_component_42.UpdateResourceBindings();
				_component_43.UpdateResourceBindings();
				_component_44.UpdateResourceBindings();
				_component_45.UpdateResourceBindings();
				_component_46.UpdateResourceBindings();
				_component_47.UpdateResourceBindings();
				_component_48.UpdateResourceBindings();
				_component_49.UpdateResourceBindings();
				_component_50.UpdateResourceBindings();
				_component_51.UpdateResourceBindings();
				_component_52.UpdateResourceBindings();
				_component_53.UpdateResourceBindings();
				_component_54.UpdateResourceBindings();
				_component_55.UpdateResourceBindings();
				_component_56.UpdateResourceBindings();
				_component_57.UpdateResourceBindings();
				_component_58.UpdateResourceBindings();
				_component_59.UpdateResourceBindings();
				_component_60.UpdateResourceBindings();
				_component_61.UpdateResourceBindings();
				_component_62.UpdateResourceBindings();
				_component_63.UpdateResourceBindings();
				_component_64.UpdateResourceBindings();
				_component_65.UpdateResourceBindings();
				_component_66.UpdateResourceBindings();
				_component_67.UpdateResourceBindings();
				_component_68.UpdateResourceBindings();
				_component_69.UpdateResourceBindings();
				_component_70.UpdateResourceBindings();
				_component_71.UpdateResourceBindings();
				_component_72.UpdateResourceBindings();
				_component_73.UpdateResourceBindings();
				_component_74.UpdateResourceBindings();
				_component_75.UpdateResourceBindings();
				_component_76.UpdateResourceBindings();
				_component_77.UpdateResourceBindings();
				_component_78.UpdateResourceBindings();
				_component_79.UpdateResourceBindings();
				_component_80.UpdateResourceBindings();
				_component_81.UpdateResourceBindings();
				_component_82.UpdateResourceBindings();
				_component_83.UpdateResourceBindings();
				_component_84.UpdateResourceBindings();
				_component_85.UpdateResourceBindings();
				_component_86.UpdateResourceBindings();
				_component_87.UpdateResourceBindings();
				_component_88.UpdateResourceBindings();
				_component_89.UpdateResourceBindings();
				_component_90.UpdateResourceBindings();
				_component_91.UpdateResourceBindings();
				_component_92.UpdateResourceBindings();
				_component_93.UpdateResourceBindings();
				_component_94.UpdateResourceBindings();
				_component_95.UpdateResourceBindings();
				_component_96.UpdateResourceBindings();
				_component_97.UpdateResourceBindings();
				_component_98.UpdateResourceBindings();
				_component_99.UpdateResourceBindings();
				_component_100.UpdateResourceBindings();
				_component_101.UpdateResourceBindings();
				_component_102.UpdateResourceBindings();
				_component_103.UpdateResourceBindings();
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
internal class _ScrollBar_2772bd4b73d9fb47624e927079fb3628_ScrollBarRDSC8
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

	private ComponentHolder _component_11_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_12_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_13_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_14_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_15_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _HorizontalTrackRectSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalSmallDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalLargeDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalThumbTransformSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalThumbSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalLargeIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalSmallIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalRootSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalPanningThumbSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalPanningRootSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalTrackRectSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalSmallDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalLargeDecreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalThumbTransformSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalThumbSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalLargeIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalSmallIncreaseSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalRootSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalPanningThumbSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalPanningRootSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_NormalSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _TouchIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_TouchIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_TouchIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _MouseIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_MouseIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_MouseIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _NoIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_NoIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_NoIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollingIndicatorStatesSubject = new ElementNameSubject();

	private ElementNameSubject _CollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_CollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_CollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_ExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_ExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_ExpandedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_ExpandedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _CollapsedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _Vertical_CollapsedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _Horizontal_CollapsedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _ConsciousStatesSubject = new ElementNameSubject();

	private Rectangle _component_0
	{
		get
		{
			return (Rectangle)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private RepeatButton _component_1
	{
		get
		{
			return (RepeatButton)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private RepeatButton _component_2
	{
		get
		{
			return (RepeatButton)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private CompositeTransform _component_3
	{
		get
		{
			return (CompositeTransform)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private Thumb _component_4
	{
		get
		{
			return (Thumb)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private RepeatButton _component_5
	{
		get
		{
			return (RepeatButton)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private RepeatButton _component_6
	{
		get
		{
			return (RepeatButton)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private Border _component_7
	{
		get
		{
			return (Border)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private Rectangle _component_8
	{
		get
		{
			return (Rectangle)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private RepeatButton _component_9
	{
		get
		{
			return (RepeatButton)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private RepeatButton _component_10
	{
		get
		{
			return (RepeatButton)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private CompositeTransform _component_11
	{
		get
		{
			return (CompositeTransform)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private Thumb _component_12
	{
		get
		{
			return (Thumb)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private RepeatButton _component_13
	{
		get
		{
			return (RepeatButton)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private RepeatButton _component_14
	{
		get
		{
			return (RepeatButton)_component_14_Holder.Instance;
		}
		set
		{
			_component_14_Holder.Instance = value;
		}
	}

	private Border _component_15
	{
		get
		{
			return (Border)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
		}
	}

	private Rectangle HorizontalTrackRect
	{
		get
		{
			return (Rectangle)_HorizontalTrackRectSubject.ElementInstance;
		}
		set
		{
			_HorizontalTrackRectSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalSmallDecrease
	{
		get
		{
			return (RepeatButton)_HorizontalSmallDecreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalSmallDecreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalLargeDecrease
	{
		get
		{
			return (RepeatButton)_HorizontalLargeDecreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalLargeDecreaseSubject.ElementInstance = value;
		}
	}

	private CompositeTransform HorizontalThumbTransform
	{
		get
		{
			return (CompositeTransform)_HorizontalThumbTransformSubject.ElementInstance;
		}
		set
		{
			_HorizontalThumbTransformSubject.ElementInstance = value;
		}
	}

	private Thumb HorizontalThumb
	{
		get
		{
			return (Thumb)_HorizontalThumbSubject.ElementInstance;
		}
		set
		{
			_HorizontalThumbSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalLargeIncrease
	{
		get
		{
			return (RepeatButton)_HorizontalLargeIncreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalLargeIncreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton HorizontalSmallIncrease
	{
		get
		{
			return (RepeatButton)_HorizontalSmallIncreaseSubject.ElementInstance;
		}
		set
		{
			_HorizontalSmallIncreaseSubject.ElementInstance = value;
		}
	}

	private Grid HorizontalRoot
	{
		get
		{
			return (Grid)_HorizontalRootSubject.ElementInstance;
		}
		set
		{
			_HorizontalRootSubject.ElementInstance = value;
		}
	}

	private Border HorizontalPanningThumb
	{
		get
		{
			return (Border)_HorizontalPanningThumbSubject.ElementInstance;
		}
		set
		{
			_HorizontalPanningThumbSubject.ElementInstance = value;
		}
	}

	private Grid HorizontalPanningRoot
	{
		get
		{
			return (Grid)_HorizontalPanningRootSubject.ElementInstance;
		}
		set
		{
			_HorizontalPanningRootSubject.ElementInstance = value;
		}
	}

	private Rectangle VerticalTrackRect
	{
		get
		{
			return (Rectangle)_VerticalTrackRectSubject.ElementInstance;
		}
		set
		{
			_VerticalTrackRectSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalSmallDecrease
	{
		get
		{
			return (RepeatButton)_VerticalSmallDecreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalSmallDecreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalLargeDecrease
	{
		get
		{
			return (RepeatButton)_VerticalLargeDecreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalLargeDecreaseSubject.ElementInstance = value;
		}
	}

	private CompositeTransform VerticalThumbTransform
	{
		get
		{
			return (CompositeTransform)_VerticalThumbTransformSubject.ElementInstance;
		}
		set
		{
			_VerticalThumbTransformSubject.ElementInstance = value;
		}
	}

	private Thumb VerticalThumb
	{
		get
		{
			return (Thumb)_VerticalThumbSubject.ElementInstance;
		}
		set
		{
			_VerticalThumbSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalLargeIncrease
	{
		get
		{
			return (RepeatButton)_VerticalLargeIncreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalLargeIncreaseSubject.ElementInstance = value;
		}
	}

	private RepeatButton VerticalSmallIncrease
	{
		get
		{
			return (RepeatButton)_VerticalSmallIncreaseSubject.ElementInstance;
		}
		set
		{
			_VerticalSmallIncreaseSubject.ElementInstance = value;
		}
	}

	private Grid VerticalRoot
	{
		get
		{
			return (Grid)_VerticalRootSubject.ElementInstance;
		}
		set
		{
			_VerticalRootSubject.ElementInstance = value;
		}
	}

	private Border VerticalPanningThumb
	{
		get
		{
			return (Border)_VerticalPanningThumbSubject.ElementInstance;
		}
		set
		{
			_VerticalPanningThumbSubject.ElementInstance = value;
		}
	}

	private Grid VerticalPanningRoot
	{
		get
		{
			return (Grid)_VerticalPanningRootSubject.ElementInstance;
		}
		set
		{
			_VerticalPanningRootSubject.ElementInstance = value;
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

	private VisualState Vertical_Normal
	{
		get
		{
			return (VisualState)_Vertical_NormalSubject.ElementInstance;
		}
		set
		{
			_Vertical_NormalSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_Normal
	{
		get
		{
			return (VisualState)_Horizontal_NormalSubject.ElementInstance;
		}
		set
		{
			_Horizontal_NormalSubject.ElementInstance = value;
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

	private VisualState Vertical_Disabled
	{
		get
		{
			return (VisualState)_Vertical_DisabledSubject.ElementInstance;
		}
		set
		{
			_Vertical_DisabledSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_Disabled
	{
		get
		{
			return (VisualState)_Horizontal_DisabledSubject.ElementInstance;
		}
		set
		{
			_Horizontal_DisabledSubject.ElementInstance = value;
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

	private VisualState TouchIndicator
	{
		get
		{
			return (VisualState)_TouchIndicatorSubject.ElementInstance;
		}
		set
		{
			_TouchIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_TouchIndicator
	{
		get
		{
			return (VisualState)_Vertical_TouchIndicatorSubject.ElementInstance;
		}
		set
		{
			_Vertical_TouchIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_TouchIndicator
	{
		get
		{
			return (VisualState)_Horizontal_TouchIndicatorSubject.ElementInstance;
		}
		set
		{
			_Horizontal_TouchIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState MouseIndicator
	{
		get
		{
			return (VisualState)_MouseIndicatorSubject.ElementInstance;
		}
		set
		{
			_MouseIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_MouseIndicator
	{
		get
		{
			return (VisualState)_Vertical_MouseIndicatorSubject.ElementInstance;
		}
		set
		{
			_Vertical_MouseIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_MouseIndicator
	{
		get
		{
			return (VisualState)_Horizontal_MouseIndicatorSubject.ElementInstance;
		}
		set
		{
			_Horizontal_MouseIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState NoIndicator
	{
		get
		{
			return (VisualState)_NoIndicatorSubject.ElementInstance;
		}
		set
		{
			_NoIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_NoIndicator
	{
		get
		{
			return (VisualState)_Vertical_NoIndicatorSubject.ElementInstance;
		}
		set
		{
			_Vertical_NoIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_NoIndicator
	{
		get
		{
			return (VisualState)_Horizontal_NoIndicatorSubject.ElementInstance;
		}
		set
		{
			_Horizontal_NoIndicatorSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ScrollingIndicatorStates
	{
		get
		{
			return (VisualStateGroup)_ScrollingIndicatorStatesSubject.ElementInstance;
		}
		set
		{
			_ScrollingIndicatorStatesSubject.ElementInstance = value;
		}
	}

	private VisualState Collapsed
	{
		get
		{
			return (VisualState)_CollapsedSubject.ElementInstance;
		}
		set
		{
			_CollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_Collapsed
	{
		get
		{
			return (VisualState)_Vertical_CollapsedSubject.ElementInstance;
		}
		set
		{
			_Vertical_CollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_Collapsed
	{
		get
		{
			return (VisualState)_Horizontal_CollapsedSubject.ElementInstance;
		}
		set
		{
			_Horizontal_CollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Expanded
	{
		get
		{
			return (VisualState)_ExpandedSubject.ElementInstance;
		}
		set
		{
			_ExpandedSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_Expanded
	{
		get
		{
			return (VisualState)_Vertical_ExpandedSubject.ElementInstance;
		}
		set
		{
			_Vertical_ExpandedSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_Expanded
	{
		get
		{
			return (VisualState)_Horizontal_ExpandedSubject.ElementInstance;
		}
		set
		{
			_Horizontal_ExpandedSubject.ElementInstance = value;
		}
	}

	private VisualState ExpandedWithoutAnimation
	{
		get
		{
			return (VisualState)_ExpandedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_ExpandedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_ExpandedWithoutAnimation
	{
		get
		{
			return (VisualState)_Vertical_ExpandedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_Vertical_ExpandedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_ExpandedWithoutAnimation
	{
		get
		{
			return (VisualState)_Horizontal_ExpandedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_Horizontal_ExpandedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualState CollapsedWithoutAnimation
	{
		get
		{
			return (VisualState)_CollapsedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_CollapsedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualState Vertical_CollapsedWithoutAnimation
	{
		get
		{
			return (VisualState)_Vertical_CollapsedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_Vertical_CollapsedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualState Horizontal_CollapsedWithoutAnimation
	{
		get
		{
			return (VisualState)_Horizontal_CollapsedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_Horizontal_CollapsedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ConsciousStates
	{
		get
		{
			return (VisualStateGroup)_ConsciousStatesSubject.ElementInstance;
		}
		set
		{
			_ConsciousStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_186)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = 
			{
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "HorizontalRoot",
					Visibility = Visibility.Collapsed,
					IsHitTestVisible = false,
					ColumnDefinitions = 
					{
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						},
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						},
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
							Width = new GridLength(1.0, GridUnitType.Auto)
						}
					},
					Children = 
					{
						(UIElement)new Rectangle
						{
							IsParsing = true,
							Name = "HorizontalTrackRect",
							Opacity = 0.0,
							Margin = new Thickness(0.0)
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Rectangle c284)
						{
							nameScope.RegisterName("HorizontalTrackRect", c284);
							HorizontalTrackRect = c284;
							Grid.SetColumnSpan(c284, 5);
							ResourceResolverSingleton.Instance.ApplyResource(c284, Shape.StrokeThicknessProperty, "ScrollBarTrackBorderThemeThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c284, Shape.FillProperty, "ScrollBarTrackFill", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c284, Shape.StrokeProperty, "ScrollBarTrackStroke", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_0 = c284;
							c284.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalSmallDecrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							AllowFocusOnInteraction = false,
							VerticalAlignment = VerticalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c285)
						{
							nameScope.RegisterName("HorizontalSmallDecrease", c285);
							HorizontalSmallDecrease = c285;
							Grid.SetColumn(c285, 0);
							ResourceResolverSingleton.Instance.ApplyResource(c285, FrameworkElement.MinHeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c285, Control.TemplateProperty, "XamlDefaultScrollBar_HorizontalDecrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c285, FrameworkElement.WidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_1 = c285;
							c285.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalLargeDecrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							IsTabStop = false,
							Interval = 50,
							Width = 0.0,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c286)
						{
							nameScope.RegisterName("HorizontalLargeDecrease", c286);
							HorizontalLargeDecrease = c286;
							Grid.SetColumn(c286, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c286, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_2 = c286;
							c286.CreationComplete();
						}),
						(UIElement)new Thumb
						{
							IsParsing = true,
							Name = "HorizontalThumb",
							Opacity = 0.0,
							VerticalAlignment = VerticalAlignment.Bottom,
							RenderTransformOrigin = new Point(0.5, 1.0),
							RenderTransform = new CompositeTransform
							{
								ScaleX = 1.0,
								TranslateX = 0.0
							}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(CompositeTransform c287)
							{
								nameScope.RegisterName("HorizontalThumbTransform", c287);
								HorizontalThumbTransform = c287;
								ResourceResolverSingleton.Instance.ApplyResource(c287, CompositeTransform.ScaleYProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c287, CompositeTransform.TranslateYProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								_component_3 = c287;
								NameScope.SetNameScope(_component_3, nameScope);
							})
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Thumb c288)
						{
							nameScope.RegisterName("HorizontalThumb", c288);
							HorizontalThumb = c288;
							Grid.SetColumn(c288, 2);
							ResourceResolverSingleton.Instance.ApplyResource(c288, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c288, Control.TemplateProperty, "XamlDefaultScrollBar_HorizontalThumbTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c288, FrameworkElement.HeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c288, FrameworkElement.MinWidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c288, AccessibilityView.Raw);
							_component_4 = c288;
							c288.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalLargeIncrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							IsTabStop = false,
							Interval = 50,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c289)
						{
							nameScope.RegisterName("HorizontalLargeIncrease", c289);
							HorizontalLargeIncrease = c289;
							Grid.SetColumn(c289, 3);
							ResourceResolverSingleton.Instance.ApplyResource(c289, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_5 = c289;
							c289.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "HorizontalSmallIncrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							AllowFocusOnInteraction = false,
							VerticalAlignment = VerticalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c290)
						{
							nameScope.RegisterName("HorizontalSmallIncrease", c290);
							HorizontalSmallIncrease = c290;
							Grid.SetColumn(c290, 4);
							ResourceResolverSingleton.Instance.ApplyResource(c290, FrameworkElement.MinHeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c290, Control.TemplateProperty, "XamlDefaultScrollBar_HorizontalIncrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c290, FrameworkElement.WidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_6 = c290;
							c290.CreationComplete();
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c291)
				{
					nameScope.RegisterName("HorizontalRoot", c291);
					HorizontalRoot = c291;
					c291.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c291.SetBinding(Grid.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c291.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c292)
				{
					c292.Name = "HorizontalRoot";
					_HorizontalRootSubject.ElementInstance = c292;
					c292.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "HorizontalPanningRoot",
					MinWidth = 24.0,
					Visibility = Visibility.Collapsed,
					Opacity = 0.0,
					Children = { (UIElement)new Border
					{
						IsParsing = true,
						Name = "HorizontalPanningThumb",
						VerticalAlignment = VerticalAlignment.Bottom,
						HorizontalAlignment = HorizontalAlignment.Left,
						BorderThickness = new Thickness(0.0),
						Height = 2.0,
						MinWidth = 32.0,
						Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Border c293)
					{
						nameScope.RegisterName("HorizontalPanningThumb", c293);
						HorizontalPanningThumb = c293;
						ResourceResolverSingleton.Instance.ApplyResource(c293, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
						_component_7 = c293;
						c293.CreationComplete();
					}) }
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c294)
				{
					nameScope.RegisterName("HorizontalPanningRoot", c294);
					HorizontalPanningRoot = c294;
					c294.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c295)
				{
					c295.Name = "HorizontalPanningRoot";
					_HorizontalPanningRootSubject.ElementInstance = c295;
					c295.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "VerticalRoot",
					Visibility = Visibility.Collapsed,
					IsHitTestVisible = false,
					RowDefinitions = 
					{
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						},
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						},
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
					Children = 
					{
						(UIElement)new Rectangle
						{
							IsParsing = true,
							Name = "VerticalTrackRect",
							Opacity = 0.0,
							Margin = new Thickness(0.0)
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Rectangle c301)
						{
							nameScope.RegisterName("VerticalTrackRect", c301);
							VerticalTrackRect = c301;
							Grid.SetRowSpan(c301, 5);
							ResourceResolverSingleton.Instance.ApplyResource(c301, Shape.StrokeThicknessProperty, "ScrollBarTrackBorderThemeThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c301, Shape.FillProperty, "ScrollBarTrackFill", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c301, Shape.StrokeProperty, "ScrollBarTrackStroke", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_8 = c301;
							c301.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalSmallDecrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							HorizontalAlignment = HorizontalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c302)
						{
							nameScope.RegisterName("VerticalSmallDecrease", c302);
							VerticalSmallDecrease = c302;
							ResourceResolverSingleton.Instance.ApplyResource(c302, FrameworkElement.HeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c302, FrameworkElement.MinWidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							Grid.SetRow(c302, 0);
							ResourceResolverSingleton.Instance.ApplyResource(c302, Control.TemplateProperty, "XamlDefaultScrollBar_VerticalDecrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_9 = c302;
							c302.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalLargeDecrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							Height = 0.0,
							IsTabStop = false,
							Interval = 50,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c303)
						{
							nameScope.RegisterName("VerticalLargeDecrease", c303);
							VerticalLargeDecrease = c303;
							Grid.SetRow(c303, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c303, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_10 = c303;
							c303.CreationComplete();
						}),
						(UIElement)new Thumb
						{
							IsParsing = true,
							Name = "VerticalThumb",
							Opacity = 0.0,
							RenderTransformOrigin = new Point(1.0, 0.5),
							RenderTransform = new CompositeTransform
							{
								ScaleY = 1.0,
								TranslateY = 0.0
							}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(CompositeTransform c304)
							{
								nameScope.RegisterName("VerticalThumbTransform", c304);
								VerticalThumbTransform = c304;
								ResourceResolverSingleton.Instance.ApplyResource(c304, CompositeTransform.ScaleXProperty, "SmallScrollThumbScale", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								ResourceResolverSingleton.Instance.ApplyResource(c304, CompositeTransform.TranslateXProperty, "SmallScrollThumbOffset", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
								_component_11 = c304;
								NameScope.SetNameScope(_component_11, nameScope);
							})
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Thumb c305)
						{
							nameScope.RegisterName("VerticalThumb", c305);
							VerticalThumb = c305;
							Grid.SetRow(c305, 2);
							ResourceResolverSingleton.Instance.ApplyResource(c305, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c305, Control.TemplateProperty, "XamlDefaultScrollBar_VerticalThumbTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c305, FrameworkElement.WidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c305, FrameworkElement.MinHeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c305, AccessibilityView.Raw);
							_component_12 = c305;
							c305.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalLargeIncrease",
							Opacity = 0.0,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Stretch,
							IsTabStop = false,
							Interval = 50,
							AllowFocusOnInteraction = false
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c306)
						{
							nameScope.RegisterName("VerticalLargeIncrease", c306);
							VerticalLargeIncrease = c306;
							Grid.SetRow(c306, 3);
							ResourceResolverSingleton.Instance.ApplyResource(c306, Control.TemplateProperty, "XamlDefaultScrollBar_RepeatButtonTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_13 = c306;
							c306.CreationComplete();
						}),
						(UIElement)new RepeatButton
						{
							IsParsing = true,
							Name = "VerticalSmallIncrease",
							Opacity = 0.0,
							IsTabStop = false,
							Interval = 50,
							Margin = new Thickness(0.0),
							HorizontalAlignment = HorizontalAlignment.Center
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(RepeatButton c307)
						{
							nameScope.RegisterName("VerticalSmallIncrease", c307);
							VerticalSmallIncrease = c307;
							ResourceResolverSingleton.Instance.ApplyResource(c307, FrameworkElement.HeightProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c307, FrameworkElement.MinWidthProperty, "ScrollBarSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							Grid.SetRow(c307, 4);
							ResourceResolverSingleton.Instance.ApplyResource(c307, Control.TemplateProperty, "XamlDefaultScrollBar_VerticalIncrementTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
							_component_14 = c307;
							c307.CreationComplete();
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c308)
				{
					nameScope.RegisterName("VerticalRoot", c308);
					VerticalRoot = c308;
					c308.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c308.SetBinding(Grid.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c308.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c309)
				{
					c309.Name = "VerticalRoot";
					_VerticalRootSubject.ElementInstance = c309;
					c309.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ElementStub(() => new Grid
				{
					IsParsing = true,
					Name = "VerticalPanningRoot",
					MinHeight = 24.0,
					Visibility = Visibility.Collapsed,
					Opacity = 0.0,
					Children = { (UIElement)new Border
					{
						IsParsing = true,
						Name = "VerticalPanningThumb",
						VerticalAlignment = VerticalAlignment.Top,
						HorizontalAlignment = HorizontalAlignment.Right,
						BorderThickness = new Thickness(0.0),
						Width = 2.0,
						MinHeight = 32.0,
						Margin = new Thickness(2.0, 0.0, 2.0, 0.0)
					}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Border c310)
					{
						nameScope.RegisterName("VerticalPanningThumb", c310);
						VerticalPanningThumb = c310;
						ResourceResolverSingleton.Instance.ApplyResource(c310, FrameworkElement.BackgroundProperty, "ScrollBarPanningThumbBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_);
						_component_15 = c310;
						c310.CreationComplete();
					}) }
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c311)
				{
					nameScope.RegisterName("VerticalPanningRoot", c311);
					VerticalPanningRoot = c311;
					c311.CreationComplete();
				})).ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(ElementStub c312)
				{
					c312.Name = "VerticalPanningRoot";
					_VerticalPanningRootSubject.ElementInstance = c312;
					c312.Visibility = Visibility.Collapsed;
				})
			}
		}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(Grid c313)
		{
			nameScope.RegisterName("Root", c313);
			Root = c313;
			VisualStateManager.SetVisualStateGroups(c313, new VisualStateGroup[3]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c314)
						{
							nameScope.RegisterName("Normal", c314);
							Normal = c314;
						}),
						new VisualState
						{
							Name = "Vertical_Normal"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c315)
						{
							nameScope.RegisterName("Vertical_Normal", c315);
							Vertical_Normal = c315;
						}),
						new VisualState
						{
							Name = "Horizontal_Normal"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c316)
						{
							nameScope.RegisterName("Horizontal_Normal", c316);
							Horizontal_Normal = c316;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c317)
						{
							nameScope.RegisterName("Disabled", c317);
							Disabled = c317;
							MarkupHelper.SetVisualStateLazy(c317, delegate
							{
								c317.Name = "Disabled";
								c317.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Opacity"), "0.5"));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c317.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Vertical_Disabled"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c318)
						{
							nameScope.RegisterName("Vertical_Disabled", c318);
							Vertical_Disabled = c318;
							MarkupHelper.SetVisualStateLazy(c318, delegate
							{
								c318.Name = "Vertical_Disabled";
								c318.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c318.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c318.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Opacity"), "0.5"));
								c318.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c318.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c318.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_Disabled"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c319)
						{
							nameScope.RegisterName("Horizontal_Disabled", c319);
							Horizontal_Disabled = c319;
							MarkupHelper.SetVisualStateLazy(c319, delegate
							{
								c319.Name = "Horizontal_Disabled";
								c319.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Opacity"), "0.5"));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokeDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokeDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningThumbSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c320)
				{
					nameScope.RegisterName("CommonStates", c320);
					CommonStates = c320;
				}),
				new VisualStateGroup
				{
					Name = "ScrollingIndicatorStates",
					States = 
					{
						new VisualState
						{
							Name = "TouchIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c321)
						{
							nameScope.RegisterName("TouchIndicator", c321);
							TouchIndicator = c321;
							MarkupHelper.SetVisualStateLazy(c321, delegate
							{
								c321.Name = "TouchIndicator";
								c321.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_TouchIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c322)
						{
							nameScope.RegisterName("Vertical_TouchIndicator", c322);
							Vertical_TouchIndicator = c322;
							MarkupHelper.SetVisualStateLazy(c322, delegate
							{
								c322.Name = "Vertical_TouchIndicator";
								c322.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_TouchIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c323)
						{
							nameScope.RegisterName("Horizontal_TouchIndicator", c323);
							Horizontal_TouchIndicator = c323;
							MarkupHelper.SetVisualStateLazy(c323, delegate
							{
								c323.Name = "Horizontal_TouchIndicator";
								c323.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c323.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "MouseIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c324)
						{
							nameScope.RegisterName("MouseIndicator", c324);
							MouseIndicator = c324;
							MarkupHelper.SetVisualStateLazy(c324, delegate
							{
								c324.Name = "MouseIndicator";
								c324.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c324.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c324.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c324.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c324.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Opacity"), "1"));
								c324.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_MouseIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c325)
						{
							nameScope.RegisterName("Vertical_MouseIndicator", c325);
							Vertical_MouseIndicator = c325;
							MarkupHelper.SetVisualStateLazy(c325, delegate
							{
								c325.Name = "Vertical_MouseIndicator";
								c325.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c325.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c325.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_MouseIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c326)
						{
							nameScope.RegisterName("Horizontal_MouseIndicator", c326);
							Horizontal_MouseIndicator = c326;
							MarkupHelper.SetVisualStateLazy(c326, delegate
							{
								c326.Name = "Horizontal_MouseIndicator";
								c326.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c326.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"IsHitTestVisible"), "True"));
								c326.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "NoIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c327)
						{
							nameScope.RegisterName("NoIndicator", c327);
							NoIndicator = c327;
							MarkupHelper.SetVisualStateLazy(c327, delegate
							{
								c327.Name = "NoIndicator";
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Opacity"), "0"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c327.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_NoIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c328)
						{
							nameScope.RegisterName("Vertical_NoIndicator", c328);
							Vertical_NoIndicator = c328;
							MarkupHelper.SetVisualStateLazy(c328, delegate
							{
								c328.Name = "Vertical_NoIndicator";
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Opacity"), "0"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Opacity"), "0"));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_VerticalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_NoIndicator"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c329)
						{
							nameScope.RegisterName("Horizontal_NoIndicator", c329);
							Horizontal_NoIndicator = c329;
							MarkupHelper.SetVisualStateLazy(c329, delegate
							{
								c329.Name = "Horizontal_NoIndicator";
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Opacity"), "0"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Opacity"), "0"));
								c329.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalPanningRootSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c330)
				{
					nameScope.RegisterName("ScrollingIndicatorStates", c330);
					ScrollingIndicatorStates = c330;
				}),
				new VisualStateGroup
				{
					Name = "ConsciousStates",
					States = 
					{
						new VisualState
						{
							Name = "Collapsed"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c331)
						{
							nameScope.RegisterName("Collapsed", c331);
							Collapsed = c331;
						}),
						new VisualState
						{
							Name = "Vertical_Collapsed"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c332)
						{
							nameScope.RegisterName("Vertical_Collapsed", c332);
							Vertical_Collapsed = c332;
						}),
						new VisualState
						{
							Name = "Horizontal_Collapsed"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c333)
						{
							nameScope.RegisterName("Horizontal_Collapsed", c333);
							Horizontal_Collapsed = c333;
						}),
						new VisualState
						{
							Name = "Expanded"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c334)
						{
							nameScope.RegisterName("Expanded", c334);
							Expanded = c334;
							MarkupHelper.SetVisualStateLazy(c334, delegate
							{
								c334.Name = "Expanded";
								c334.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), "1.0"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), "0"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), "1.0"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), "0"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c334.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_Expanded"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c335)
						{
							nameScope.RegisterName("Vertical_Expanded", c335);
							Vertical_Expanded = c335;
							MarkupHelper.SetVisualStateLazy(c335, delegate
							{
								c335.Name = "Vertical_Expanded";
								c335.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), "1.0"));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), "0"));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_Expanded"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c336)
						{
							nameScope.RegisterName("Horizontal_Expanded", c336);
							Horizontal_Expanded = c336;
							MarkupHelper.SetVisualStateLazy(c336, delegate
							{
								c336.Name = "Horizontal_Expanded";
								c336.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), "1.0"));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), "0"));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c336.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "ExpandedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c337)
						{
							nameScope.RegisterName("ExpandedWithoutAnimation", c337);
							ExpandedWithoutAnimation = c337;
							MarkupHelper.SetVisualStateLazy(c337, delegate
							{
								c337.Name = "ExpandedWithoutAnimation";
								c337.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), "1.0"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), "0"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), "1.0"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), "0"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_ExpandedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c338)
						{
							nameScope.RegisterName("Vertical_ExpandedWithoutAnimation", c338);
							Vertical_ExpandedWithoutAnimation = c338;
							MarkupHelper.SetVisualStateLazy(c338, delegate
							{
								c338.Name = "Vertical_ExpandedWithoutAnimation";
								c338.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), "1.0"));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), "0"));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c338.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_ExpandedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c339)
						{
							nameScope.RegisterName("Horizontal_ExpandedWithoutAnimation", c339);
							Horizontal_ExpandedWithoutAnimation = c339;
							MarkupHelper.SetVisualStateLazy(c339, delegate
							{
								c339.Name = "Horizontal_ExpandedWithoutAnimation";
								c339.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Stroke"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackStrokePointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackStrokePointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarTrackFillPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarTrackFillPointerOver", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), "1.0"));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), "0"));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "1"));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "1"));
								c339.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "CollapsedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c340)
						{
							nameScope.RegisterName("CollapsedWithoutAnimation", c340);
							CollapsedWithoutAnimation = c340;
							MarkupHelper.SetVisualStateLazy(c340, delegate
							{
								c340.Name = "CollapsedWithoutAnimation";
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c340.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
							});
						}),
						new VisualState
						{
							Name = "Vertical_CollapsedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c341)
						{
							nameScope.RegisterName("Vertical_CollapsedWithoutAnimation", c341);
							Vertical_CollapsedWithoutAnimation = c341;
							MarkupHelper.SetVisualStateLazy(c341, delegate
							{
								c341.Name = "Vertical_CollapsedWithoutAnimation";
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"ScaleX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalThumbTransformSubject, (PropertyPath)"TranslateX"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c341.Setters.Add(new Setter(new TargetPropertyPath(_VerticalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
							});
						}),
						new VisualState
						{
							Name = "Horizontal_CollapsedWithoutAnimation"
						}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualState c342)
						{
							nameScope.RegisterName("Horizontal_CollapsedWithoutAnimation", c342);
							Horizontal_CollapsedWithoutAnimation = c342;
							MarkupHelper.SetVisualStateLazy(c342, delegate
							{
								c342.Name = "Horizontal_CollapsedWithoutAnimation";
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbSubject, (PropertyPath)"Background.Color"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ScrollBarPanningThumbBackgroundColor", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("ScrollBarPanningThumbBackgroundColor", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"ScaleY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbScale", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbScale", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalThumbTransformSubject, (PropertyPath)"TranslateY"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SmallScrollThumbOffset", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SmallScrollThumbOffset", GlobalStaticResources.ResourceDictionarySingleton__64.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeIncreaseSubject, (PropertyPath)"Opacity"), "0"));
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalLargeDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalSmallDecreaseSubject, (PropertyPath)"Opacity"), "0"));
								c342.Setters.Add(new Setter(new TargetPropertyPath(_HorizontalTrackRectSubject, (PropertyPath)"Opacity"), "0"));
							});
						})
					}
				}.ScrollBar_2772bd4b73d9fb47624e927079fb3628_XamlApply(delegate(VisualStateGroup c343)
				{
					nameScope.RegisterName("ConsciousStates", c343);
					ConsciousStates = c343;
				})
			});
			c313.CreationComplete();
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

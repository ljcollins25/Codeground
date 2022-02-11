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

internal class _DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_DateTimePickerFlyout_themeresourcesRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

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

	public UIElement Build(object __ResourceOwner_2538)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Children = { (UIElement)new ContentPresenter
			{
				IsParsing = true,
				Name = "ContentPresenter"
			}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(ContentPresenter c0)
			{
				nameScope.RegisterName("ContentPresenter", c0);
				ContentPresenter = c0;
				c0.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.BackgroundSizingProperty, new Binding
				{
					Path = "BackgroundSizing",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				ResourceResolverSingleton.Instance.ApplyResource(c0, ContentPresenter.BorderBrushProperty, "DateTimePickerFlyoutButtonBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
				ResourceResolverSingleton.Instance.ApplyResource(c0, ContentPresenter.BorderThicknessProperty, "DateTimeFlyoutButtonBorderThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
				c0.SetBinding(ContentPresenter.ContentProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
				{
					Path = "ContentTemplate",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
				{
					Path = "ContentTransitions",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.PaddingProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c0, AccessibilityView.Raw);
				c0.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
				{
					Path = "CornerRadius",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				_component_0 = c0;
				c0.CreationComplete();
			}) }
		}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(Grid c1)
		{
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
					}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(VisualState c2)
					{
						nameScope.RegisterName("Normal", c2);
						Normal = c2;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(VisualState c3)
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
										}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(DiscreteObjectKeyFrame c4)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c4, ObjectKeyFrame.ValueProperty, "DateTimePickerFlyoutButtonBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
											_component_1 = c4;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c5)
									{
										Storyboard.SetTargetName(c5, "ContentPresenter");
										Storyboard.SetTarget(c5, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c5, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(DiscreteObjectKeyFrame c6)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c6, ObjectKeyFrame.ValueProperty, "DateTimePickerFlyoutButtonBorderBrushPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
											_component_2 = c6;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c7)
									{
										Storyboard.SetTargetName(c7, "ContentPresenter");
										Storyboard.SetTarget(c7, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c7, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(DiscreteObjectKeyFrame c8)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c8, ObjectKeyFrame.ValueProperty, "DateTimePickerFlyoutButtonForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
											_component_3 = c8;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c9)
									{
										Storyboard.SetTargetName(c9, "ContentPresenter");
										Storyboard.SetTarget(c9, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c9, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(VisualState c10)
					{
						nameScope.RegisterName("Pressed", c10);
						Pressed = c10;
						MarkupHelper.SetVisualStateLazy(c10, delegate
						{
							c10.Name = "Pressed";
							c10.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(DiscreteObjectKeyFrame c11)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c11, ObjectKeyFrame.ValueProperty, "DateTimePickerFlyoutButtonBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
											_component_4 = c11;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c12)
									{
										Storyboard.SetTargetName(c12, "ContentPresenter");
										Storyboard.SetTarget(c12, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c12, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(DiscreteObjectKeyFrame c13)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c13, ObjectKeyFrame.ValueProperty, "DateTimePickerFlyoutButtonBorderBrushPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
											_component_5 = c13;
											NameScope.SetNameScope(_component_5, nameScope);
										}) }
									}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c14)
									{
										Storyboard.SetTargetName(c14, "ContentPresenter");
										Storyboard.SetTarget(c14, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c14, "BorderBrush");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(DiscreteObjectKeyFrame c15)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c15, ObjectKeyFrame.ValueProperty, "DateTimePickerFlyoutButtonForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__11.Instance.__ParseContext_);
											_component_6 = c15;
											NameScope.SetNameScope(_component_6, nameScope);
										}) }
									}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(ObjectAnimationUsingKeyFrames c16)
									{
										Storyboard.SetTargetName(c16, "ContentPresenter");
										Storyboard.SetTarget(c16, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c16, "Foreground");
									})
								}
							};
						});
					})
				}
			}.DateTimePickerFlyout_themeresources_76b2d8189b430a78af3ad631c3aa7d2d_XamlApply(delegate(VisualStateGroup c17)
			{
				nameScope.RegisterName("CommonStates", c17);
				CommonStates = c17;
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
				_component_6.UpdateResourceBindings();
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

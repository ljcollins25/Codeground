using System;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _LoopingSelector_91c58f33045a9387d93beb3db190495b_LoopingSelectorRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

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

	public UIElement Build(object __ResourceOwner_151)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new StackPanel
		{
			IsParsing = true,
			VerticalAlignment = VerticalAlignment.Center,
			Children = { (UIElement)new TextBlock
			{
				IsParsing = true
			}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(TextBlock c0)
			{
				c0.SetBinding(TextBlock.TextProperty, new Binding
				{
					Path = "PrimaryText"
				});
				ResourceResolverSingleton.Instance.ApplyResource(c0, TextBlock.FontFamilyProperty, "ContentControlThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
				_component_0 = c0;
				c0.CreationComplete();
			}) }
		}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(StackPanel c1)
		{
			c1.CreationComplete();
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
internal class _LoopingSelector_91c58f33045a9387d93beb3db190495b_LoopingSelectorRDSC1
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _UpButtonSubject = new ElementNameSubject();

	private ElementNameSubject _DownButtonSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ScrollViewer _component_0
	{
		get
		{
			return (ScrollViewer)_component_0_Holder.Instance;
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

	private ScrollViewer ScrollViewer
	{
		get
		{
			return (ScrollViewer)_ScrollViewerSubject.ElementInstance;
		}
		set
		{
			_ScrollViewerSubject.ElementInstance = value;
		}
	}

	private RepeatButton UpButton
	{
		get
		{
			return (RepeatButton)_UpButtonSubject.ElementInstance;
		}
		set
		{
			_UpButtonSubject.ElementInstance = value;
		}
	}

	private RepeatButton DownButton
	{
		get
		{
			return (RepeatButton)_DownButtonSubject.ElementInstance;
		}
		set
		{
			_DownButtonSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_153)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Children = 
			{
				(UIElement)new ScrollViewer
				{
					IsParsing = true,
					Name = "ScrollViewer",
					VerticalSnapPointsType = SnapPointsType.Mandatory,
					VerticalSnapPointsAlignment = SnapPointsAlignment.Near
				}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ScrollViewer c2)
				{
					nameScope.RegisterName("ScrollViewer", c2);
					ScrollViewer = c2;
					ScrollViewer.SetVerticalScrollBarVisibility(c2, ScrollBarVisibility.Hidden);
					ScrollViewer.SetHorizontalScrollMode(c2, ScrollMode.Disabled);
					ScrollViewer.SetZoomMode(c2, ZoomMode.Disabled);
					ResourceResolverSingleton.Instance.ApplyResource(c2, Control.TemplateProperty, "ScrollViewerScrollBarlessTemplate", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
					_component_0 = c2;
					c2.CreationComplete();
				}),
				(UIElement)new RepeatButton
				{
					IsParsing = true,
					Name = "UpButton",
					Content = "\ue70e",
					FontSize = 8.0,
					Height = 22.0,
					Padding = new Thickness(0.0),
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Top,
					Visibility = Visibility.Collapsed,
					IsTabStop = false
				}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(RepeatButton c3)
				{
					nameScope.RegisterName("UpButton", c3);
					UpButton = c3;
					ResourceResolverSingleton.Instance.ApplyResource(c3, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c3, FrameworkElement.StyleProperty, "DateTimePickerFlyoutButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c3, FrameworkElement.BackgroundProperty, "LoopingSelectorButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
					_component_1 = c3;
					c3.CreationComplete();
				}),
				(UIElement)new RepeatButton
				{
					IsParsing = true,
					Name = "DownButton",
					Content = "\ue70d",
					FontSize = 8.0,
					Height = 22.0,
					Padding = new Thickness(0.0),
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Bottom,
					Visibility = Visibility.Collapsed,
					IsTabStop = false
				}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(RepeatButton c4)
				{
					nameScope.RegisterName("DownButton", c4);
					DownButton = c4;
					ResourceResolverSingleton.Instance.ApplyResource(c4, Control.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c4, FrameworkElement.StyleProperty, "DateTimePickerFlyoutButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c4, FrameworkElement.BackgroundProperty, "LoopingSelectorButtonBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
					_component_2 = c4;
					c4.CreationComplete();
				})
			}
		}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(Grid c5)
		{
			VisualStateManager.SetVisualStateGroups(c5, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualState c6)
					{
						nameScope.RegisterName("Normal", c6);
						Normal = c6;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualState c7)
					{
						nameScope.RegisterName("PointerOver", c7);
						PointerOver = c7;
						MarkupHelper.SetVisualStateLazy(c7, delegate
						{
							c7.Name = "PointerOver";
							c7.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Visible"
										} }
									}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c9)
									{
										Storyboard.SetTargetName(c9, "UpButton");
										Storyboard.SetTarget(c9, _UpButtonSubject);
										Storyboard.SetTargetProperty(c9, "Visibility");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Visible"
										} }
									}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c11)
									{
										Storyboard.SetTargetName(c11, "DownButton");
										Storyboard.SetTarget(c11, _DownButtonSubject);
										Storyboard.SetTargetProperty(c11, "Visibility");
									})
								}
							};
						});
					})
				}
			}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualStateGroup c12)
			{
				nameScope.RegisterName("CommonStates", c12);
				CommonStates = c12;
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
internal class _LoopingSelector_91c58f33045a9387d93beb3db190495b_LoopingSelectorRDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentScaleTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _SelectedSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

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

	private ScaleTransform ContentScaleTransform
	{
		get
		{
			return (ScaleTransform)_ContentScaleTransformSubject.ElementInstance;
		}
		set
		{
			_ContentScaleTransformSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_154)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Background = SolidColorBrushHelper.Transparent,
			RenderTransform = new ScaleTransform().LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ScaleTransform c13)
			{
				nameScope.RegisterName("ContentScaleTransform", c13);
				ContentScaleTransform = c13;
			}),
			Children = { (UIElement)new ContentPresenter
			{
				IsParsing = true,
				Name = "ContentPresenter",
				Margin = new Thickness(2.0, 0.0, 2.0, 0.0)
			}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ContentPresenter c14)
			{
				nameScope.RegisterName("ContentPresenter", c14);
				ContentPresenter = c14;
				c14.SetBinding(ContentPresenter.ForegroundProperty, new Binding
				{
					Path = "Foreground",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c14.SetBinding(ContentPresenter.ContentProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c14.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
				{
					Path = "ContentTemplate",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c14.SetBinding(ContentPresenter.PaddingProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c14.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c14.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c14, AccessibilityView.Raw);
				c14.CreationComplete();
			}) }
		}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(Grid c15)
		{
			nameScope.RegisterName("Root", c15);
			Root = c15;
			VisualStateManager.SetVisualStateGroups(c15, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualState c16)
					{
						nameScope.RegisterName("Normal", c16);
						Normal = c16;
					}),
					new VisualState
					{
						Name = "Expanded"
					}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualState c17)
					{
						nameScope.RegisterName("Expanded", c17);
						Expanded = c17;
					}),
					new VisualState
					{
						Name = "Selected"
					}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualState c18)
					{
						nameScope.RegisterName("Selected", c18);
						Selected = c18;
						MarkupHelper.SetVisualStateLazy(c18, delegate
						{
							c18.Name = "Selected";
							c18.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(DiscreteObjectKeyFrame c19)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c19, ObjectKeyFrame.ValueProperty, "LoopingSelectorItemForegroundSelected", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
										_component_0 = c19;
										NameScope.SetNameScope(_component_0, nameScope);
									}) }
								}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c20)
								{
									Storyboard.SetTargetName(c20, "ContentPresenter");
									Storyboard.SetTarget(c20, _ContentPresenterSubject);
									Storyboard.SetTargetProperty(c20, "Foreground");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualState c21)
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
										}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(DiscreteObjectKeyFrame c22)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c22, ObjectKeyFrame.ValueProperty, "LoopingSelectorItemBackgroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
											_component_1 = c22;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c23)
									{
										Storyboard.SetTargetName(c23, "Root");
										Storyboard.SetTarget(c23, _RootSubject);
										Storyboard.SetTargetProperty(c23, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(DiscreteObjectKeyFrame c24)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c24, ObjectKeyFrame.ValueProperty, "LoopingSelectorItemForegroundPointerOver", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
											_component_2 = c24;
											NameScope.SetNameScope(_component_2, nameScope);
										}) }
									}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c25)
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
					}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualState c26)
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
										}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(DiscreteObjectKeyFrame c27)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c27, ObjectKeyFrame.ValueProperty, "LoopingSelectorItemBackgroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
											_component_3 = c27;
											NameScope.SetNameScope(_component_3, nameScope);
										}) }
									}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c28)
									{
										Storyboard.SetTargetName(c28, "Root");
										Storyboard.SetTarget(c28, _RootSubject);
										Storyboard.SetTargetProperty(c28, "Background");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(DiscreteObjectKeyFrame c29)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c29, ObjectKeyFrame.ValueProperty, "LoopingSelectorItemForegroundPressed", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__24.Instance.__ParseContext_);
											_component_4 = c29;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(ObjectAnimationUsingKeyFrames c30)
									{
										Storyboard.SetTargetName(c30, "ContentPresenter");
										Storyboard.SetTarget(c30, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c30, "Foreground");
									})
								}
							};
						});
					})
				}
			}.LoopingSelector_91c58f33045a9387d93beb3db190495b_XamlApply(delegate(VisualStateGroup c31)
			{
				nameScope.RegisterName("CommonStates", c31);
				CommonStates = c31;
			}) });
			c15.CreationComplete();
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

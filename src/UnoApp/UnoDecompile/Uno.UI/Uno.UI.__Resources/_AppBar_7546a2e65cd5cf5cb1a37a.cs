using System;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_AppBarRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ClipGeometryTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ContentTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ContentControlSubject = new ElementNameSubject();

	private ElementNameSubject _EllipsisIconSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandButtonSubject = new ElementNameSubject();

	private ElementNameSubject _HighContrastBorderSubject = new ElementNameSubject();

	private ElementNameSubject _ContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _CompactClosedSubject = new ElementNameSubject();

	private ElementNameSubject _CompactOpenUpSubject = new ElementNameSubject();

	private ElementNameSubject _CompactOpenDownSubject = new ElementNameSubject();

	private ElementNameSubject _MinimalClosedSubject = new ElementNameSubject();

	private ElementNameSubject _MinimalOpenUpSubject = new ElementNameSubject();

	private ElementNameSubject _MinimalOpenDownSubject = new ElementNameSubject();

	private ElementNameSubject _HiddenClosedSubject = new ElementNameSubject();

	private ElementNameSubject _HiddenOpenUpSubject = new ElementNameSubject();

	private ElementNameSubject _HiddenOpenDownSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayModeStatesSubject = new ElementNameSubject();

	private ContentControl _component_0
	{
		get
		{
			return (ContentControl)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private FontIcon _component_1
	{
		get
		{
			return (FontIcon)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Button _component_2
	{
		get
		{
			return (Button)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Rectangle _component_3
	{
		get
		{
			return (Rectangle)_component_3_Holder.Instance;
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

	private TranslateTransform ClipGeometryTransform
	{
		get
		{
			return (TranslateTransform)_ClipGeometryTransformSubject.ElementInstance;
		}
		set
		{
			_ClipGeometryTransformSubject.ElementInstance = value;
		}
	}

	private TranslateTransform ContentTransform
	{
		get
		{
			return (TranslateTransform)_ContentTransformSubject.ElementInstance;
		}
		set
		{
			_ContentTransformSubject.ElementInstance = value;
		}
	}

	private ContentControl ContentControl
	{
		get
		{
			return (ContentControl)_ContentControlSubject.ElementInstance;
		}
		set
		{
			_ContentControlSubject.ElementInstance = value;
		}
	}

	private FontIcon EllipsisIcon
	{
		get
		{
			return (FontIcon)_EllipsisIconSubject.ElementInstance;
		}
		set
		{
			_EllipsisIconSubject.ElementInstance = value;
		}
	}

	private Button ExpandButton
	{
		get
		{
			return (Button)_ExpandButtonSubject.ElementInstance;
		}
		set
		{
			_ExpandButtonSubject.ElementInstance = value;
		}
	}

	private Rectangle HighContrastBorder
	{
		get
		{
			return (Rectangle)_HighContrastBorderSubject.ElementInstance;
		}
		set
		{
			_HighContrastBorderSubject.ElementInstance = value;
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

	private Grid LayoutRoot
	{
		get
		{
			return (Grid)_LayoutRootSubject.ElementInstance;
		}
		set
		{
			_LayoutRootSubject.ElementInstance = value;
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

	private VisualState CompactClosed
	{
		get
		{
			return (VisualState)_CompactClosedSubject.ElementInstance;
		}
		set
		{
			_CompactClosedSubject.ElementInstance = value;
		}
	}

	private VisualState CompactOpenUp
	{
		get
		{
			return (VisualState)_CompactOpenUpSubject.ElementInstance;
		}
		set
		{
			_CompactOpenUpSubject.ElementInstance = value;
		}
	}

	private VisualState CompactOpenDown
	{
		get
		{
			return (VisualState)_CompactOpenDownSubject.ElementInstance;
		}
		set
		{
			_CompactOpenDownSubject.ElementInstance = value;
		}
	}

	private VisualState MinimalClosed
	{
		get
		{
			return (VisualState)_MinimalClosedSubject.ElementInstance;
		}
		set
		{
			_MinimalClosedSubject.ElementInstance = value;
		}
	}

	private VisualState MinimalOpenUp
	{
		get
		{
			return (VisualState)_MinimalOpenUpSubject.ElementInstance;
		}
		set
		{
			_MinimalOpenUpSubject.ElementInstance = value;
		}
	}

	private VisualState MinimalOpenDown
	{
		get
		{
			return (VisualState)_MinimalOpenDownSubject.ElementInstance;
		}
		set
		{
			_MinimalOpenDownSubject.ElementInstance = value;
		}
	}

	private VisualState HiddenClosed
	{
		get
		{
			return (VisualState)_HiddenClosedSubject.ElementInstance;
		}
		set
		{
			_HiddenClosedSubject.ElementInstance = value;
		}
	}

	private VisualState HiddenOpenUp
	{
		get
		{
			return (VisualState)_HiddenOpenUpSubject.ElementInstance;
		}
		set
		{
			_HiddenOpenUpSubject.ElementInstance = value;
		}
	}

	private VisualState HiddenOpenDown
	{
		get
		{
			return (VisualState)_HiddenOpenDownSubject.ElementInstance;
		}
		set
		{
			_HiddenOpenDownSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DisplayModeStates
	{
		get
		{
			return (VisualStateGroup)_DisplayModeStatesSubject.ElementInstance;
		}
		set
		{
			_DisplayModeStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_116)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Resources = 
			{
				[(object)"OverlayOpeningAnimation"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimationUsingKeyFrames
					{
						KeyFrames = 
						{
							(DoubleKeyFrame)new DiscreteDoubleKeyFrame
							{
								KeyTime = TimeSpan.FromTicks(0L),
								Value = 0.0
							},
							(DoubleKeyFrame)new SplineDoubleKeyFrame
							{
								KeyTime = TimeSpan.FromTicks(4670000L),
								KeySpline = "0.1,0.9 0.2,1.0",
								Value = 1.0
							}
						}
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c71)
					{
						Storyboard.SetTargetProperty(c71, "Opacity");
					}) }
				},
				[(object)"OverlayClosingAnimation"] = new Storyboard
				{
					Children = { (Timeline)new DoubleAnimationUsingKeyFrames
					{
						KeyFrames = 
						{
							(DoubleKeyFrame)new DiscreteDoubleKeyFrame
							{
								KeyTime = TimeSpan.FromTicks(0L),
								Value = 1.0
							},
							(DoubleKeyFrame)new SplineDoubleKeyFrame
							{
								KeyTime = TimeSpan.FromTicks(1670000L),
								KeySpline = "0.2,0 0,1",
								Value = 0.0
							}
						}
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c74)
					{
						Storyboard.SetTargetProperty(c74, "Opacity");
					}) }
				}
			},
			Name = "LayoutRoot",
			Clip = new RectangleGeometry
			{
				Transform = new TranslateTransform().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TranslateTransform c75)
				{
					nameScope.RegisterName("ClipGeometryTransform", c75);
					ClipGeometryTransform = c75;
					c75.SetBinding(TranslateTransform.YProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "TemplateSettings.CompactVerticalDelta"
					});
				})
			}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(RectangleGeometry c76)
			{
				c76.SetBinding(RectangleGeometry.RectProperty, new Binding
				{
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
					Path = "TemplateSettings.ClipRect"
				});
			}),
			Children = { (UIElement)new Grid
			{
				IsParsing = true,
				Name = "ContentRoot",
				VerticalAlignment = VerticalAlignment.Top,
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
				RenderTransform = new TranslateTransform().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TranslateTransform c79)
				{
					nameScope.RegisterName("ContentTransform", c79);
					ContentTransform = c79;
				}),
				Children = 
				{
					(UIElement)new ContentControl
					{
						IsParsing = true,
						Name = "ContentControl",
						IsTabStop = false
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ContentControl c80)
					{
						nameScope.RegisterName("ContentControl", c80);
						ContentControl = c80;
						c80.SetBinding(ContentControl.ContentProperty, new Binding
						{
							Path = "Content",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c80.SetBinding(ContentControl.ContentTemplateProperty, new Binding
						{
							Path = "ContentTemplate",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c80.SetBinding(ContentControl.ContentTransitionsProperty, new Binding
						{
							Path = "ContentTransitions",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c80.SetBinding(Control.ForegroundProperty, new Binding
						{
							Path = "Foreground",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c80.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
						{
							Path = "HorizontalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c80.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
						{
							Path = "VerticalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c80.SetBinding(Control.HorizontalContentAlignmentProperty, new Binding
						{
							Path = "HorizontalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c80.SetBinding(Control.VerticalContentAlignmentProperty, new Binding
						{
							Path = "VerticalContentAlignment",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						ResourceResolverSingleton.Instance.ApplyResource(c80, FrameworkElement.MinHeightProperty, "AppBarThemeMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						_component_0 = c80;
						c80.CreationComplete();
					}),
					(UIElement)new Button
					{
						IsParsing = true,
						Name = "ExpandButton",
						Padding = new Thickness(14.0, 23.0, 14.0, 0.0),
						VerticalAlignment = VerticalAlignment.Top,
						Content = new FontIcon
						{
							IsParsing = true,
							Name = "EllipsisIcon",
							VerticalAlignment = VerticalAlignment.Center,
							FontSize = 20.0,
							Glyph = "\ue10c"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(FontIcon c81)
						{
							nameScope.RegisterName("EllipsisIcon", c81);
							EllipsisIcon = c81;
							ResourceResolverSingleton.Instance.ApplyResource(c81, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c81, FrameworkElement.HeightProperty, "AppBarExpandButtonCircleDiameter", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							_component_1 = c81;
							c81.CreationComplete();
						})
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Button c82)
					{
						nameScope.RegisterName("ExpandButton", c82);
						ExpandButton = c82;
						c82.SetBinding(Control.ForegroundProperty, new Binding
						{
							Path = "Foreground",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						ResourceResolverSingleton.Instance.ApplyResource(c82, FrameworkElement.StyleProperty, "XamlDefaultCommandBar_EllipsisButton", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c82, FrameworkElement.MinHeightProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						Grid.SetColumn(c82, 1);
						_component_2 = c82;
						c82.CreationComplete();
					}),
					(UIElement)new ElementStub(() => new Rectangle
					{
						IsParsing = true,
						Name = "HighContrastBorder",
						Visibility = Visibility.Collapsed,
						VerticalAlignment = VerticalAlignment.Stretch,
						StrokeThickness = 1.0
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Rectangle c83)
					{
						nameScope.RegisterName("HighContrastBorder", c83);
						HighContrastBorder = c83;
						Grid.SetColumnSpan(c83, 2);
						ResourceResolverSingleton.Instance.ApplyResource(c83, Shape.StrokeProperty, "AppBarHighContrastBorder", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						_component_3 = c83;
						c83.CreationComplete();
					})).AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ElementStub c84)
					{
						c84.Name = "HighContrastBorder";
						_HighContrastBorderSubject.ElementInstance = c84;
						c84.Visibility = Visibility.Collapsed;
					})
				}
			}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Grid c85)
			{
				nameScope.RegisterName("ContentRoot", c85);
				ContentRoot = c85;
				c85.SetBinding(FrameworkElement.MarginProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c85.SetBinding(FrameworkElement.HeightProperty, new Binding
				{
					Path = "Height",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c85.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c85.CreationComplete();
			}) }
		}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Grid c86)
		{
			nameScope.RegisterName("LayoutRoot", c86);
			LayoutRoot = c86;
			VisualStateManager.SetVisualStateGroups(c86, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c87)
						{
							nameScope.RegisterName("Normal", c87);
							Normal = c87;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c88)
						{
							nameScope.RegisterName("Disabled", c88);
							Disabled = c88;
							MarkupHelper.SetVisualStateLazy(c88, delegate
							{
								c88.Name = "Disabled";
								c88.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c89)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c89, ObjectKeyFrame.ValueProperty, "SystemControlDisabledBaseMediumLowBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
											_component_4 = c89;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c90)
									{
										Storyboard.SetTargetName(c90, "EllipsisIcon");
										Storyboard.SetTarget(c90, _EllipsisIconSubject);
										Storyboard.SetTargetProperty(c90, "Foreground");
									}) }
								};
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c91)
				{
					nameScope.RegisterName("CommonStates", c91);
					CommonStates = c91;
				}),
				new VisualStateGroup
				{
					Name = "DisplayModeStates",
					Transitions = 
					{
						new VisualTransition
						{
							From = "CompactClosed",
							To = "CompactOpenUp",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(4670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c92)
						{
							MarkupHelper.SetVisualTransitionLazy(c92, delegate
							{
								c92.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c94)
										{
											Storyboard.SetTargetName(c94, "ExpandButton");
											Storyboard.SetTarget(c94, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c94, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c96)
										{
											Storyboard.SetTargetName(c96, "HighContrastBorder");
											Storyboard.SetTarget(c96, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c96, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0"
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(SplineDoubleKeyFrame c98)
												{
													c98.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.CompactVerticalDelta"
													});
												})
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c99)
										{
											Storyboard.SetTargetName(c99, "ContentTransform");
											Storyboard.SetTarget(c99, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c99, "Y");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "CompactOpenUp",
							To = "CompactClosed",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(1670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c100)
						{
							MarkupHelper.SetVisualTransitionLazy(c100, delegate
							{
								c100.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c102)
										{
											Storyboard.SetTargetName(c102, "ExpandButton");
											Storyboard.SetTarget(c102, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c102, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c104)
										{
											Storyboard.SetTargetName(c104, "HighContrastBorder");
											Storyboard.SetTarget(c104, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c104, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c105)
												{
													c105.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.CompactVerticalDelta"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c107)
										{
											Storyboard.SetTargetName(c107, "ContentTransform");
											Storyboard.SetTarget(c107, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c107, "Y");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "CompactClosed",
							To = "CompactOpenDown",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(4670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c108)
						{
							MarkupHelper.SetVisualTransitionLazy(c108, delegate
							{
								c108.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c110)
										{
											Storyboard.SetTargetName(c110, "ExpandButton");
											Storyboard.SetTarget(c110, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c110, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c112)
										{
											Storyboard.SetTargetName(c112, "HighContrastBorder");
											Storyboard.SetTarget(c112, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c112, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c113)
												{
													c113.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.CompactVerticalDelta"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c115)
										{
											Storyboard.SetTargetName(c115, "ClipGeometryTransform");
											Storyboard.SetTarget(c115, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c115, "Y");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "CompactOpenDown",
							To = "CompactClosed",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(1670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c116)
						{
							MarkupHelper.SetVisualTransitionLazy(c116, delegate
							{
								c116.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c118)
										{
											Storyboard.SetTargetName(c118, "ExpandButton");
											Storyboard.SetTarget(c118, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c118, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c120)
										{
											Storyboard.SetTargetName(c120, "HighContrastBorder");
											Storyboard.SetTarget(c120, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c120, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1"
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(SplineDoubleKeyFrame c122)
												{
													c122.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.CompactVerticalDelta"
													});
												})
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c123)
										{
											Storyboard.SetTargetName(c123, "ClipGeometryTransform");
											Storyboard.SetTarget(c123, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c123, "Y");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "MinimalClosed",
							To = "MinimalOpenUp",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(4670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c124)
						{
							MarkupHelper.SetVisualTransitionLazy(c124, delegate
							{
								c124.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c126)
										{
											Storyboard.SetTargetName(c126, "ExpandButton");
											Storyboard.SetTarget(c126, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c126, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c128)
										{
											Storyboard.SetTargetName(c128, "ExpandButton");
											Storyboard.SetTarget(c128, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c128, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c130)
										{
											Storyboard.SetTargetName(c130, "HighContrastBorder");
											Storyboard.SetTarget(c130, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c130, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c131)
											{
												c131.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c132)
										{
											Storyboard.SetTargetName(c132, "ClipGeometryTransform");
											Storyboard.SetTarget(c132, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c132, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0"
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(SplineDoubleKeyFrame c134)
												{
													c134.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.MinimalVerticalDelta"
													});
												})
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c135)
										{
											Storyboard.SetTargetName(c135, "ContentTransform");
											Storyboard.SetTarget(c135, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c135, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 1.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c138)
										{
											Storyboard.SetTargetName(c138, "ContentControl");
											Storyboard.SetTarget(c138, _ContentControlSubject);
											Storyboard.SetTargetProperty(c138, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "MinimalOpenUp",
							To = "MinimalClosed",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(1670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c139)
						{
							MarkupHelper.SetVisualTransitionLazy(c139, delegate
							{
								c139.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c141)
										{
											Storyboard.SetTargetName(c141, "ExpandButton");
											Storyboard.SetTarget(c141, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c141, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c143)
										{
											Storyboard.SetTargetName(c143, "ExpandButton");
											Storyboard.SetTarget(c143, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c143, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c145)
										{
											Storyboard.SetTargetName(c145, "HighContrastBorder");
											Storyboard.SetTarget(c145, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c145, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c146)
											{
												c146.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c147)
										{
											Storyboard.SetTargetName(c147, "ClipGeometryTransform");
											Storyboard.SetTarget(c147, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c147, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c148)
												{
													c148.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.MinimalVerticalDelta"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c150)
										{
											Storyboard.SetTargetName(c150, "ContentTransform");
											Storyboard.SetTarget(c150, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c150, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 1.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c153)
										{
											Storyboard.SetTargetName(c153, "ContentControl");
											Storyboard.SetTarget(c153, _ContentControlSubject);
											Storyboard.SetTargetProperty(c153, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "MinimalClosed",
							To = "MinimalOpenDown",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(4670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c154)
						{
							MarkupHelper.SetVisualTransitionLazy(c154, delegate
							{
								c154.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c156)
										{
											Storyboard.SetTargetName(c156, "ExpandButton");
											Storyboard.SetTarget(c156, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c156, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c158)
										{
											Storyboard.SetTargetName(c158, "ExpandButton");
											Storyboard.SetTarget(c158, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c158, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c160)
										{
											Storyboard.SetTargetName(c160, "HighContrastBorder");
											Storyboard.SetTarget(c160, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c160, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c161)
												{
													c161.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.MinimalVerticalDelta"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c163)
										{
											Storyboard.SetTargetName(c163, "ClipGeometryTransform");
											Storyboard.SetTarget(c163, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c163, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 1.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c166)
										{
											Storyboard.SetTargetName(c166, "ContentControl");
											Storyboard.SetTarget(c166, _ContentControlSubject);
											Storyboard.SetTargetProperty(c166, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "MinimalOpenDown",
							To = "MinimalClosed",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(1670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c167)
						{
							MarkupHelper.SetVisualTransitionLazy(c167, delegate
							{
								c167.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c169)
										{
											Storyboard.SetTargetName(c169, "ExpandButton");
											Storyboard.SetTarget(c169, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c169, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c171)
										{
											Storyboard.SetTargetName(c171, "ExpandButton");
											Storyboard.SetTarget(c171, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c171, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c173)
										{
											Storyboard.SetTargetName(c173, "HighContrastBorder");
											Storyboard.SetTarget(c173, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c173, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1"
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(SplineDoubleKeyFrame c175)
												{
													c175.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.MinimalVerticalDelta"
													});
												})
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c176)
										{
											Storyboard.SetTargetName(c176, "ClipGeometryTransform");
											Storyboard.SetTarget(c176, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c176, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 1.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c179)
										{
											Storyboard.SetTargetName(c179, "ContentControl");
											Storyboard.SetTarget(c179, _ContentControlSubject);
											Storyboard.SetTargetProperty(c179, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "HiddenClosed",
							To = "HiddenOpenUp",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(4670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c180)
						{
							MarkupHelper.SetVisualTransitionLazy(c180, delegate
							{
								c180.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c182)
										{
											Storyboard.SetTargetName(c182, "ExpandButton");
											Storyboard.SetTarget(c182, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c182, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c184)
										{
											Storyboard.SetTargetName(c184, "HighContrastBorder");
											Storyboard.SetTarget(c184, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c184, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0"
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(SplineDoubleKeyFrame c186)
												{
													c186.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.HiddenVerticalDelta"
													});
												})
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c187)
										{
											Storyboard.SetTargetName(c187, "ContentTransform");
											Storyboard.SetTarget(c187, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c187, "Y");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "HiddenOpenUp",
							To = "HiddenClosed",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(1670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c188)
						{
							MarkupHelper.SetVisualTransitionLazy(c188, delegate
							{
								c188.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c190)
										{
											Storyboard.SetTargetName(c190, "ExpandButton");
											Storyboard.SetTarget(c190, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c190, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c192)
										{
											Storyboard.SetTargetName(c192, "HighContrastBorder");
											Storyboard.SetTarget(c192, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c192, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c193)
												{
													c193.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.HiddenVerticalDelta"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c195)
										{
											Storyboard.SetTargetName(c195, "ContentTransform");
											Storyboard.SetTarget(c195, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c195, "Y");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "HiddenClosed",
							To = "HiddenOpenDown",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(4670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c196)
						{
							MarkupHelper.SetVisualTransitionLazy(c196, delegate
							{
								c196.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c198)
										{
											Storyboard.SetTargetName(c198, "ExpandButton");
											Storyboard.SetTarget(c198, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c198, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c200)
										{
											Storyboard.SetTargetName(c200, "HighContrastBorder");
											Storyboard.SetTarget(c200, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c200, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c201)
												{
													c201.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.HiddenVerticalDelta"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c203)
										{
											Storyboard.SetTargetName(c203, "ClipGeometryTransform");
											Storyboard.SetTarget(c203, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c203, "Y");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "HiddenOpenDown",
							To = "HiddenClosed",
							GeneratedDuration = new Duration(TimeSpan.FromTicks(1670000L))
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualTransition c204)
						{
							MarkupHelper.SetVisualTransitionLazy(c204, delegate
							{
								c204.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c206)
										{
											Storyboard.SetTargetName(c206, "ExpandButton");
											Storyboard.SetTarget(c206, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c206, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c208)
										{
											Storyboard.SetTargetName(c208, "HighContrastBorder");
											Storyboard.SetTarget(c208, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c208, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 0.0
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1"
												}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(SplineDoubleKeyFrame c210)
												{
													c210.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.HiddenVerticalDelta"
													});
												})
											}
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c211)
										{
											Storyboard.SetTargetName(c211, "ClipGeometryTransform");
											Storyboard.SetTarget(c211, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c211, "Y");
										})
									}
								};
							});
						})
					},
					States = 
					{
						new VisualState
						{
							Name = "CompactClosed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c212)
						{
							nameScope.RegisterName("CompactClosed", c212);
							CompactClosed = c212;
						}),
						new VisualState
						{
							Name = "CompactOpenUp"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c213)
						{
							nameScope.RegisterName("CompactOpenUp", c213);
							CompactOpenUp = c213;
							MarkupHelper.SetVisualStateLazy(c213, delegate
							{
								c213.Name = "CompactOpenUp";
								c213.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c214)
											{
												c214.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.CompactVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c215)
										{
											Storyboard.SetTargetName(c215, "ContentTransform");
											Storyboard.SetTarget(c215, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c215, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c217)
										{
											Storyboard.SetTargetName(c217, "ExpandButton");
											Storyboard.SetTarget(c217, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c217, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c219)
										{
											Storyboard.SetTargetName(c219, "HighContrastBorder");
											Storyboard.SetTarget(c219, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c219, "Visibility");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "CompactOpenDown"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c220)
						{
							nameScope.RegisterName("CompactOpenDown", c220);
							CompactOpenDown = c220;
							MarkupHelper.SetVisualStateLazy(c220, delegate
							{
								c220.Name = "CompactOpenDown";
								c220.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c222)
										{
											Storyboard.SetTargetName(c222, "ClipGeometryTransform");
											Storyboard.SetTarget(c222, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c222, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c224)
										{
											Storyboard.SetTargetName(c224, "ExpandButton");
											Storyboard.SetTarget(c224, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c224, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c226)
										{
											Storyboard.SetTargetName(c226, "HighContrastBorder");
											Storyboard.SetTarget(c226, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c226, "Visibility");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MinimalClosed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c227)
						{
							nameScope.RegisterName("MinimalClosed", c227);
							MinimalClosed = c227;
							MarkupHelper.SetVisualStateLazy(c227, delegate
							{
								c227.Name = "MinimalClosed";
								c227.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c228)
											{
												c228.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c229)
										{
											Storyboard.SetTargetName(c229, "ClipGeometryTransform");
											Storyboard.SetTarget(c229, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c229, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c231)
										{
											Storyboard.SetTargetName(c231, "ContentControl");
											Storyboard.SetTarget(c231, _ContentControlSubject);
											Storyboard.SetTargetProperty(c231, "IsHitTestVisible");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c233)
										{
											Storyboard.SetTargetName(c233, "ContentControl");
											Storyboard.SetTarget(c233, _ContentControlSubject);
											Storyboard.SetTargetProperty(c233, "IsEnabled");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c235)
										{
											Storyboard.SetTargetName(c235, "ContentControl");
											Storyboard.SetTarget(c235, _ContentControlSubject);
											Storyboard.SetTargetProperty(c235, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c236)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c236, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_5 = c236;
												NameScope.SetNameScope(_component_5, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c237)
										{
											Storyboard.SetTargetName(c237, "ExpandButton");
											Storyboard.SetTarget(c237, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c237, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c239)
										{
											Storyboard.SetTargetName(c239, "ExpandButton");
											Storyboard.SetTarget(c239, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c239, "Padding");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MinimalOpenUp"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c240)
						{
							nameScope.RegisterName("MinimalOpenUp", c240);
							MinimalOpenUp = c240;
							MarkupHelper.SetVisualStateLazy(c240, delegate
							{
								c240.Name = "MinimalOpenUp";
								c240.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c241)
											{
												c241.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c242)
										{
											Storyboard.SetTargetName(c242, "ClipGeometryTransform");
											Storyboard.SetTarget(c242, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c242, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c243)
											{
												c243.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c244)
										{
											Storyboard.SetTargetName(c244, "ContentTransform");
											Storyboard.SetTarget(c244, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c244, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c246)
										{
											Storyboard.SetTargetName(c246, "ExpandButton");
											Storyboard.SetTarget(c246, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c246, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c248)
										{
											Storyboard.SetTargetName(c248, "ExpandButton");
											Storyboard.SetTarget(c248, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c248, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c250)
										{
											Storyboard.SetTargetName(c250, "HighContrastBorder");
											Storyboard.SetTarget(c250, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c250, "Visibility");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MinimalOpenDown"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c251)
						{
							nameScope.RegisterName("MinimalOpenDown", c251);
							MinimalOpenDown = c251;
							MarkupHelper.SetVisualStateLazy(c251, delegate
							{
								c251.Name = "MinimalOpenDown";
								c251.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c253)
										{
											Storyboard.SetTargetName(c253, "ClipGeometryTransform");
											Storyboard.SetTarget(c253, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c253, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c255)
										{
											Storyboard.SetTargetName(c255, "ExpandButton");
											Storyboard.SetTarget(c255, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c255, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c257)
										{
											Storyboard.SetTargetName(c257, "ExpandButton");
											Storyboard.SetTarget(c257, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c257, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c259)
										{
											Storyboard.SetTargetName(c259, "HighContrastBorder");
											Storyboard.SetTarget(c259, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c259, "Visibility");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "HiddenClosed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c260)
						{
							nameScope.RegisterName("HiddenClosed", c260);
							HiddenClosed = c260;
							MarkupHelper.SetVisualStateLazy(c260, delegate
							{
								c260.Name = "HiddenClosed";
								c260.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c261)
											{
												c261.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c262)
										{
											Storyboard.SetTargetName(c262, "ClipGeometryTransform");
											Storyboard.SetTarget(c262, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c262, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c264)
										{
											Storyboard.SetTargetName(c264, "ExpandButton");
											Storyboard.SetTarget(c264, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c264, "IsTabStop");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c266)
										{
											Storyboard.SetTargetName(c266, "ContentControl");
											Storyboard.SetTarget(c266, _ContentControlSubject);
											Storyboard.SetTargetProperty(c266, "IsEnabled");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "HiddenOpenUp"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c267)
						{
							nameScope.RegisterName("HiddenOpenUp", c267);
							HiddenOpenUp = c267;
							MarkupHelper.SetVisualStateLazy(c267, delegate
							{
								c267.Name = "HiddenOpenUp";
								c267.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c268)
											{
												c268.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c269)
										{
											Storyboard.SetTargetName(c269, "ClipGeometryTransform");
											Storyboard.SetTarget(c269, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c269, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteDoubleKeyFrame c270)
											{
												c270.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c271)
										{
											Storyboard.SetTargetName(c271, "ContentTransform");
											Storyboard.SetTarget(c271, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c271, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c273)
										{
											Storyboard.SetTargetName(c273, "ExpandButton");
											Storyboard.SetTarget(c273, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c273, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c275)
										{
											Storyboard.SetTargetName(c275, "HighContrastBorder");
											Storyboard.SetTarget(c275, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c275, "Visibility");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "HiddenOpenDown"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c276)
						{
							nameScope.RegisterName("HiddenOpenDown", c276);
							HiddenOpenDown = c276;
							MarkupHelper.SetVisualStateLazy(c276, delegate
							{
								c276.Name = "HiddenOpenDown";
								c276.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DoubleAnimationUsingKeyFrames c278)
										{
											Storyboard.SetTargetName(c278, "ClipGeometryTransform");
											Storyboard.SetTarget(c278, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c278, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c280)
										{
											Storyboard.SetTargetName(c280, "ExpandButton");
											Storyboard.SetTarget(c280, _ExpandButtonSubject);
											Storyboard.SetTargetProperty(c280, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c282)
										{
											Storyboard.SetTargetName(c282, "HighContrastBorder");
											Storyboard.SetTarget(c282, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c282, "Visibility");
										})
									}
								};
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c283)
				{
					nameScope.RegisterName("DisplayModeStates", c283);
					DisplayModeStates = c283;
				})
			});
			c86.CreationComplete();
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
internal class _AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_AppBarRDSC1
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

	private ElementNameSubject _ContentSubject = new ElementNameSubject();

	private ElementNameSubject _ContentViewboxSubject = new ElementNameSubject();

	private ElementNameSubject _TextLabelSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowTextLabelSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextLabelSubject = new ElementNameSubject();

	private ElementNameSubject _SubItemChevronSubject = new ElementNameSubject();

	private ElementNameSubject _ContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _FullSizeSubject = new ElementNameSubject();

	private ElementNameSubject _CompactSubject = new ElementNameSubject();

	private ElementNameSubject _LabelOnRightSubject = new ElementNameSubject();

	private ElementNameSubject _LabelCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowWithToggleButtonsSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowWithMenuIconsSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowWithToggleButtonsAndMenuIconsSubject = new ElementNameSubject();

	private ElementNameSubject _ApplicationViewStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowNormalSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowPressedSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowSubMenuOpenedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _InputModeDefaultSubject = new ElementNameSubject();

	private ElementNameSubject _TouchInputModeSubject = new ElementNameSubject();

	private ElementNameSubject _GameControllerInputModeSubject = new ElementNameSubject();

	private ElementNameSubject _InputModeStatesSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextVisibilitySubject = new ElementNameSubject();

	private ElementNameSubject _NoFlyoutSubject = new ElementNameSubject();

	private ElementNameSubject _HasFlyoutSubject = new ElementNameSubject();

	private ElementNameSubject _FlyoutStatesSubject = new ElementNameSubject();

	private Viewbox _component_0
	{
		get
		{
			return (Viewbox)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private TextBlock _component_1
	{
		get
		{
			return (TextBlock)_component_1_Holder.Instance;
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

	private Grid _component_4
	{
		get
		{
			return (Grid)_component_4_Holder.Instance;
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

	private Viewbox ContentViewbox
	{
		get
		{
			return (Viewbox)_ContentViewboxSubject.ElementInstance;
		}
		set
		{
			_ContentViewboxSubject.ElementInstance = value;
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

	private TextBlock OverflowTextLabel
	{
		get
		{
			return (TextBlock)_OverflowTextLabelSubject.ElementInstance;
		}
		set
		{
			_OverflowTextLabelSubject.ElementInstance = value;
		}
	}

	private TextBlock KeyboardAcceleratorTextLabel
	{
		get
		{
			return (TextBlock)_KeyboardAcceleratorTextLabelSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextLabelSubject.ElementInstance = value;
		}
	}

	private FontIcon SubItemChevron
	{
		get
		{
			return (FontIcon)_SubItemChevronSubject.ElementInstance;
		}
		set
		{
			_SubItemChevronSubject.ElementInstance = value;
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

	private VisualState FullSize
	{
		get
		{
			return (VisualState)_FullSizeSubject.ElementInstance;
		}
		set
		{
			_FullSizeSubject.ElementInstance = value;
		}
	}

	private VisualState Compact
	{
		get
		{
			return (VisualState)_CompactSubject.ElementInstance;
		}
		set
		{
			_CompactSubject.ElementInstance = value;
		}
	}

	private VisualState LabelOnRight
	{
		get
		{
			return (VisualState)_LabelOnRightSubject.ElementInstance;
		}
		set
		{
			_LabelOnRightSubject.ElementInstance = value;
		}
	}

	private VisualState LabelCollapsed
	{
		get
		{
			return (VisualState)_LabelCollapsedSubject.ElementInstance;
		}
		set
		{
			_LabelCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Overflow
	{
		get
		{
			return (VisualState)_OverflowSubject.ElementInstance;
		}
		set
		{
			_OverflowSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowWithToggleButtons
	{
		get
		{
			return (VisualState)_OverflowWithToggleButtonsSubject.ElementInstance;
		}
		set
		{
			_OverflowWithToggleButtonsSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowWithMenuIcons
	{
		get
		{
			return (VisualState)_OverflowWithMenuIconsSubject.ElementInstance;
		}
		set
		{
			_OverflowWithMenuIconsSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowWithToggleButtonsAndMenuIcons
	{
		get
		{
			return (VisualState)_OverflowWithToggleButtonsAndMenuIconsSubject.ElementInstance;
		}
		set
		{
			_OverflowWithToggleButtonsAndMenuIconsSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ApplicationViewStates
	{
		get
		{
			return (VisualStateGroup)_ApplicationViewStatesSubject.ElementInstance;
		}
		set
		{
			_ApplicationViewStatesSubject.ElementInstance = value;
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

	private VisualState OverflowNormal
	{
		get
		{
			return (VisualState)_OverflowNormalSubject.ElementInstance;
		}
		set
		{
			_OverflowNormalSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowPointerOver
	{
		get
		{
			return (VisualState)_OverflowPointerOverSubject.ElementInstance;
		}
		set
		{
			_OverflowPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowPressed
	{
		get
		{
			return (VisualState)_OverflowPressedSubject.ElementInstance;
		}
		set
		{
			_OverflowPressedSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowSubMenuOpened
	{
		get
		{
			return (VisualState)_OverflowSubMenuOpenedSubject.ElementInstance;
		}
		set
		{
			_OverflowSubMenuOpenedSubject.ElementInstance = value;
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

	private VisualState InputModeDefault
	{
		get
		{
			return (VisualState)_InputModeDefaultSubject.ElementInstance;
		}
		set
		{
			_InputModeDefaultSubject.ElementInstance = value;
		}
	}

	private VisualState TouchInputMode
	{
		get
		{
			return (VisualState)_TouchInputModeSubject.ElementInstance;
		}
		set
		{
			_TouchInputModeSubject.ElementInstance = value;
		}
	}

	private VisualState GameControllerInputMode
	{
		get
		{
			return (VisualState)_GameControllerInputModeSubject.ElementInstance;
		}
		set
		{
			_GameControllerInputModeSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup InputModeStates
	{
		get
		{
			return (VisualStateGroup)_InputModeStatesSubject.ElementInstance;
		}
		set
		{
			_InputModeStatesSubject.ElementInstance = value;
		}
	}

	private VisualState KeyboardAcceleratorTextCollapsed
	{
		get
		{
			return (VisualState)_KeyboardAcceleratorTextCollapsedSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState KeyboardAcceleratorTextVisible
	{
		get
		{
			return (VisualState)_KeyboardAcceleratorTextVisibleSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextVisibleSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup KeyboardAcceleratorTextVisibility
	{
		get
		{
			return (VisualStateGroup)_KeyboardAcceleratorTextVisibilitySubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextVisibilitySubject.ElementInstance = value;
		}
	}

	private VisualState NoFlyout
	{
		get
		{
			return (VisualState)_NoFlyoutSubject.ElementInstance;
		}
		set
		{
			_NoFlyoutSubject.ElementInstance = value;
		}
	}

	private VisualState HasFlyout
	{
		get
		{
			return (VisualState)_HasFlyoutSubject.ElementInstance;
		}
		set
		{
			_HasFlyoutSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup FlyoutStates
	{
		get
		{
			return (VisualStateGroup)_FlyoutStatesSubject.ElementInstance;
		}
		set
		{
			_FlyoutStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_145)
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
				ColumnDefinitions = 
				{
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Star)
					},
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Auto)
					},
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Auto)
					}
				},
				RowDefinitions = 
				{
					new RowDefinition
					{
						Height = new GridLength(1.0, GridUnitType.Auto)
					},
					new RowDefinition
					{
						Height = new GridLength(1.0, GridUnitType.Auto)
					}
				},
				Children = 
				{
					(UIElement)new Viewbox
					{
						IsParsing = true,
						Name = "ContentViewbox",
						Height = 20.0,
						HorizontalAlignment = HorizontalAlignment.Center,
						Child = new ContentPresenter
						{
							IsParsing = true,
							Name = "Content",
							Height = 20.0
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ContentPresenter c289)
						{
							nameScope.RegisterName("Content", c289);
							Content = c289;
							c289.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Icon",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c289.SetBinding(ContentPresenter.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c289.CreationComplete();
						})
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Viewbox c290)
					{
						nameScope.RegisterName("ContentViewbox", c290);
						ContentViewbox = c290;
						ResourceResolverSingleton.Instance.ApplyResource(c290, FrameworkElement.MarginProperty, "AppBarButtonContentViewboxCollapsedMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						AutomationProperties.SetAccessibilityView(c290, AccessibilityView.Raw);
						_component_0 = c290;
						c290.CreationComplete();
					}),
					(UIElement)new TextBlock
					{
						IsParsing = true,
						Name = "TextLabel",
						FontSize = 11.0,
						TextAlignment = TextAlignment.Center,
						TextWrapping = TextWrapping.Wrap,
						Margin = new Thickness(2.0, 0.0, 2.0, 6.0)
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TextBlock c291)
					{
						nameScope.RegisterName("TextLabel", c291);
						TextLabel = c291;
						Grid.SetRow(c291, 1);
						c291.SetBinding(TextBlock.TextProperty, new Binding
						{
							Path = "Label",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c291.SetBinding(TextBlock.ForegroundProperty, new Binding
						{
							Path = "Foreground",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c291.SetBinding(TextBlock.FontFamilyProperty, new Binding
						{
							Path = "FontFamily",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						AutomationProperties.SetAccessibilityView(c291, AccessibilityView.Raw);
						c291.CreationComplete();
					}),
					(UIElement)new TextBlock
					{
						IsParsing = true,
						Name = "OverflowTextLabel",
						TextAlignment = TextAlignment.Left,
						TextTrimming = TextTrimming.Clip,
						TextWrapping = TextWrapping.NoWrap,
						HorizontalAlignment = HorizontalAlignment.Stretch,
						VerticalAlignment = VerticalAlignment.Center,
						Margin = new Thickness(12.0, 0.0, 12.0, 0.0),
						Visibility = Visibility.Collapsed
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TextBlock c292)
					{
						nameScope.RegisterName("OverflowTextLabel", c292);
						OverflowTextLabel = c292;
						c292.SetBinding(TextBlock.TextProperty, new Binding
						{
							Path = "Label",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c292.SetBinding(TextBlock.ForegroundProperty, new Binding
						{
							Path = "Foreground",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c292.SetBinding(TextBlock.FontFamilyProperty, new Binding
						{
							Path = "FontFamily",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						ResourceResolverSingleton.Instance.ApplyResource(c292, TextBlock.PaddingProperty, "AppBarButtonOverflowTextLabelPadding", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						AutomationProperties.SetAccessibilityView(c292, AccessibilityView.Raw);
						_component_1 = c292;
						c292.CreationComplete();
					}),
					(UIElement)new TextBlock
					{
						IsParsing = true,
						Name = "KeyboardAcceleratorTextLabel",
						Margin = new Thickness(24.0, 0.0, 12.0, 0.0),
						HorizontalAlignment = HorizontalAlignment.Right,
						VerticalAlignment = VerticalAlignment.Center,
						Visibility = Visibility.Collapsed
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TextBlock c293)
					{
						nameScope.RegisterName("KeyboardAcceleratorTextLabel", c293);
						KeyboardAcceleratorTextLabel = c293;
						Grid.SetColumn(c293, 1);
						ResourceResolverSingleton.Instance.ApplyResource(c293, FrameworkElement.StyleProperty, "CaptionTextBlockStyle", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						c293.SetBinding(TextBlock.TextProperty, new Binding
						{
							Path = "KeyboardAcceleratorTextOverride",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c293.SetBinding(FrameworkElement.MinWidthProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "TemplateSettings.KeyboardAcceleratorTextMinWidth"
						});
						ResourceResolverSingleton.Instance.ApplyResource(c293, TextBlock.ForegroundProperty, "AppBarButtonKeyboardAcceleratorTextForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						AutomationProperties.SetAccessibilityView(c293, AccessibilityView.Raw);
						_component_2 = c293;
						c293.CreationComplete();
					}),
					(UIElement)new FontIcon
					{
						IsParsing = true,
						Name = "SubItemChevron",
						Glyph = "\ue0e3",
						FontSize = 12.0,
						Margin = new Thickness(12.0, 0.0, 12.0, 0.0),
						MirroredWhenRightToLeft = true,
						Visibility = Visibility.Collapsed
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(FontIcon c294)
					{
						nameScope.RegisterName("SubItemChevron", c294);
						SubItemChevron = c294;
						Grid.SetColumn(c294, 2);
						ResourceResolverSingleton.Instance.ApplyResource(c294, FontIcon.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						AutomationProperties.SetAccessibilityView(c294, AccessibilityView.Raw);
						ResourceResolverSingleton.Instance.ApplyResource(c294, IconElement.ForegroundProperty, "MenuFlyoutSubItemChevron", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
						_component_3 = c294;
						c294.CreationComplete();
					})
				}
			}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Grid c295)
			{
				nameScope.RegisterName("ContentRoot", c295);
				ContentRoot = c295;
				ResourceResolverSingleton.Instance.ApplyResource(c295, FrameworkElement.MinHeightProperty, "AppBarThemeMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
				_component_4 = c295;
				c295.CreationComplete();
			}) }
		}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Grid c296)
		{
			nameScope.RegisterName("Root", c296);
			Root = c296;
			c296.SetBinding(FrameworkElement.MinWidthProperty, new Binding
			{
				Path = "MinWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c296.SetBinding(FrameworkElement.MaxWidthProperty, new Binding
			{
				Path = "MaxWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c296.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c296.SetBinding(Grid.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c296.SetBinding(Grid.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c296.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c296, new VisualStateGroup[5]
			{
				new VisualStateGroup
				{
					Name = "ApplicationViewStates",
					States = 
					{
						new VisualState
						{
							Name = "FullSize"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c297)
						{
							nameScope.RegisterName("FullSize", c297);
							FullSize = c297;
						}),
						new VisualState
						{
							Name = "Compact"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c298)
						{
							nameScope.RegisterName("Compact", c298);
							Compact = c298;
							MarkupHelper.SetVisualStateLazy(c298, delegate
							{
								c298.Name = "Compact";
								c298.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Collapsed"
										} }
									}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c300)
									{
										Storyboard.SetTargetName(c300, "TextLabel");
										Storyboard.SetTarget(c300, _TextLabelSubject);
										Storyboard.SetTargetProperty(c300, "Visibility");
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "LabelOnRight"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c301)
						{
							nameScope.RegisterName("LabelOnRight", c301);
							LabelOnRight = c301;
							MarkupHelper.SetVisualStateLazy(c301, delegate
							{
								c301.Name = "LabelOnRight";
								c301.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c302)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c302, ObjectKeyFrame.ValueProperty, "AppBarButtonContentViewboxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_5 = c302;
												NameScope.SetNameScope(_component_5, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c303)
										{
											Storyboard.SetTargetName(c303, "ContentViewbox");
											Storyboard.SetTarget(c303, _ContentViewboxSubject);
											Storyboard.SetTargetProperty(c303, "Margin");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c304)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c304, ObjectKeyFrame.ValueProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_6 = c304;
												NameScope.SetNameScope(_component_6, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c305)
										{
											Storyboard.SetTargetName(c305, "ContentRoot");
											Storyboard.SetTarget(c305, _ContentRootSubject);
											Storyboard.SetTargetProperty(c305, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c307)
										{
											Storyboard.SetTargetName(c307, "TextLabel");
											Storyboard.SetTarget(c307, _TextLabelSubject);
											Storyboard.SetTargetProperty(c307, "(Windows.UI.Xaml.Controls:Grid.Row)");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c309)
										{
											Storyboard.SetTargetName(c309, "TextLabel");
											Storyboard.SetTarget(c309, _TextLabelSubject);
											Storyboard.SetTargetProperty(c309, "(Windows.UI.Xaml.Controls:Grid.Column)");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Left"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c311)
										{
											Storyboard.SetTargetName(c311, "TextLabel");
											Storyboard.SetTarget(c311, _TextLabelSubject);
											Storyboard.SetTargetProperty(c311, "TextAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c312)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c312, ObjectKeyFrame.ValueProperty, "AppBarButtonTextLabelOnRightMargin", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_7 = c312;
												NameScope.SetNameScope(_component_7, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c313)
										{
											Storyboard.SetTargetName(c313, "TextLabel");
											Storyboard.SetTarget(c313, _TextLabelSubject);
											Storyboard.SetTargetProperty(c313, "Margin");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "LabelCollapsed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c314)
						{
							nameScope.RegisterName("LabelCollapsed", c314);
							LabelCollapsed = c314;
							MarkupHelper.SetVisualStateLazy(c314, delegate
							{
								c314.Name = "LabelCollapsed";
								c314.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c315)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c315, ObjectKeyFrame.ValueProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_8 = c315;
												NameScope.SetNameScope(_component_8, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c316)
										{
											Storyboard.SetTargetName(c316, "ContentRoot");
											Storyboard.SetTarget(c316, _ContentRootSubject);
											Storyboard.SetTargetProperty(c316, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Collapsed"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c318)
										{
											Storyboard.SetTargetName(c318, "TextLabel");
											Storyboard.SetTarget(c318, _TextLabelSubject);
											Storyboard.SetTargetProperty(c318, "Visibility");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Overflow"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c319)
						{
							nameScope.RegisterName("Overflow", c319);
							Overflow = c319;
							MarkupHelper.SetVisualStateLazy(c319, delegate
							{
								c319.Name = "Overflow";
								c319.Setters.Add(new Setter(new TargetPropertyPath(_ContentRootSubject, (PropertyPath)"MinHeight"), "0"));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c319.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						}),
						new VisualState
						{
							Name = "OverflowWithToggleButtons"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c320)
						{
							nameScope.RegisterName("OverflowWithToggleButtons", c320);
							OverflowWithToggleButtons = c320;
							MarkupHelper.SetVisualStateLazy(c320, delegate
							{
								c320.Name = "OverflowWithToggleButtons";
								c320.Setters.Add(new Setter(new TargetPropertyPath(_ContentRootSubject, (PropertyPath)"MinHeight"), "0"));
								c320.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c320.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c320.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
								c320.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Margin"), "38,0,12,0"));
							});
						}),
						new VisualState
						{
							Name = "OverflowWithMenuIcons"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c321)
						{
							nameScope.RegisterName("OverflowWithMenuIcons", c321);
							OverflowWithMenuIcons = c321;
							MarkupHelper.SetVisualStateLazy(c321, delegate
							{
								c321.Name = "OverflowWithMenuIcons";
								c321.Setters.Add(new Setter(new TargetPropertyPath(_ContentRootSubject, (PropertyPath)"MinHeight"), "0"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"VerticalAlignment"), "Center"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Width"), "16"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Height"), "16"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Margin"), "12,0,12,0"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
								c321.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Margin"), "38,0,12,0"));
							});
						}),
						new VisualState
						{
							Name = "OverflowWithToggleButtonsAndMenuIcons"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c322)
						{
							nameScope.RegisterName("OverflowWithToggleButtonsAndMenuIcons", c322);
							OverflowWithToggleButtonsAndMenuIcons = c322;
							MarkupHelper.SetVisualStateLazy(c322, delegate
							{
								c322.Name = "OverflowWithToggleButtonsAndMenuIcons";
								c322.Setters.Add(new Setter(new TargetPropertyPath(_ContentRootSubject, (PropertyPath)"MinHeight"), "0"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"VerticalAlignment"), "Center"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Width"), "16"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Height"), "16"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Margin"), "38,0,12,0"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
								c322.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Margin"), "76,0,12,0"));
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c323)
				{
					nameScope.RegisterName("ApplicationViewStates", c323);
					ApplicationViewStates = c323;
				}),
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c324)
						{
							nameScope.RegisterName("Normal", c324);
							Normal = c324;
							MarkupHelper.SetVisualStateLazy(c324, delegate
							{
								c324.Name = "Normal";
								c324.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c325)
									{
										Storyboard.SetTargetName(c325, "OverflowTextLabel");
										Storyboard.SetTarget(c325, _OverflowTextLabelSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c326)
						{
							nameScope.RegisterName("PointerOver", c326);
							PointerOver = c326;
							MarkupHelper.SetVisualStateLazy(c326, delegate
							{
								c326.Name = "PointerOver";
								c326.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c326.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c326.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c326.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c326.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c326.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonKeyboardAcceleratorTextForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonKeyboardAcceleratorTextForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c326.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c327)
									{
										Storyboard.SetTargetName(c327, "OverflowTextLabel");
										Storyboard.SetTarget(c327, _OverflowTextLabelSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c328)
						{
							nameScope.RegisterName("Pressed", c328);
							Pressed = c328;
							MarkupHelper.SetVisualStateLazy(c328, delegate
							{
								c328.Name = "Pressed";
								c328.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonKeyboardAcceleratorTextForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonKeyboardAcceleratorTextForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c328.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerDownThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerDownThemeAnimation c329)
									{
										Storyboard.SetTargetName(c329, "OverflowTextLabel");
										Storyboard.SetTarget(c329, _OverflowTextLabelSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "Disabled"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c330)
						{
							nameScope.RegisterName("Disabled", c330);
							Disabled = c330;
							MarkupHelper.SetVisualStateLazy(c330, delegate
							{
								c330.Name = "Disabled";
								c330.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c330.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c330.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c330.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c330.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c330.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonKeyboardAcceleratorTextForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonKeyboardAcceleratorTextForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "OverflowNormal"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c331)
						{
							nameScope.RegisterName("OverflowNormal", c331);
							OverflowNormal = c331;
							MarkupHelper.SetVisualStateLazy(c331, delegate
							{
								c331.Name = "OverflowNormal";
								c331.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c332)
									{
										Storyboard.SetTargetName(c332, "ContentRoot");
										Storyboard.SetTarget(c332, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowPointerOver"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c333)
						{
							nameScope.RegisterName("OverflowPointerOver", c333);
							OverflowPointerOver = c333;
							MarkupHelper.SetVisualStateLazy(c333, delegate
							{
								c333.Name = "OverflowPointerOver";
								c333.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBackgroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBackgroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c333.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c333.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c333.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c333.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c333.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonKeyboardAcceleratorTextForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonKeyboardAcceleratorTextForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c333.Setters.Add(new Setter(new TargetPropertyPath(_SubItemChevronSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonSubItemChevronForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonSubItemChevronForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c333.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c334)
									{
										Storyboard.SetTargetName(c334, "ContentRoot");
										Storyboard.SetTarget(c334, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowPressed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c335)
						{
							nameScope.RegisterName("OverflowPressed", c335);
							OverflowPressed = c335;
							MarkupHelper.SetVisualStateLazy(c335, delegate
							{
								c335.Name = "OverflowPressed";
								c335.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBackgroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBackgroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonKeyboardAcceleratorTextForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonKeyboardAcceleratorTextForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Setters.Add(new Setter(new TargetPropertyPath(_SubItemChevronSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonSubItemChevronForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonSubItemChevronForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c335.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerDownThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerDownThemeAnimation c336)
									{
										Storyboard.SetTargetName(c336, "ContentRoot");
										Storyboard.SetTarget(c336, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowSubMenuOpened"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c337)
						{
							nameScope.RegisterName("OverflowSubMenuOpened", c337);
							OverflowSubMenuOpened = c337;
							MarkupHelper.SetVisualStateLazy(c337, delegate
							{
								c337.Name = "OverflowSubMenuOpened";
								c337.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBackgroundSubMenuOpened", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBackgroundSubMenuOpened", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonBorderBrushSubMenuOpened", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonBorderBrushSubMenuOpened", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundSubMenuOpened", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundSubMenuOpened", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundSubMenuOpened", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundSubMenuOpened", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonForegroundSubMenuOpened", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonForegroundSubMenuOpened", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonKeyboardAcceleratorTextForegroundSubMenuOpened", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonKeyboardAcceleratorTextForegroundSubMenuOpened", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Setters.Add(new Setter(new TargetPropertyPath(_SubItemChevronSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonSubItemChevronForegroundSubMenuOpened", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarButtonSubItemChevronForegroundSubMenuOpened", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c337.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c338)
									{
										Storyboard.SetTargetName(c338, "ContentRoot");
										Storyboard.SetTarget(c338, _ContentRootSubject);
									}) }
								};
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c339)
				{
					nameScope.RegisterName("CommonStates", c339);
					CommonStates = c339;
				}),
				new VisualStateGroup
				{
					Name = "InputModeStates",
					States = 
					{
						new VisualState
						{
							Name = "InputModeDefault"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c340)
						{
							nameScope.RegisterName("InputModeDefault", c340);
							InputModeDefault = c340;
						}),
						new VisualState
						{
							Name = "TouchInputMode"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c341)
						{
							nameScope.RegisterName("TouchInputMode", c341);
							TouchInputMode = c341;
							MarkupHelper.SetVisualStateLazy(c341, delegate
							{
								c341.Name = "TouchInputMode";
								c341.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Padding"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonOverflowTextTouchMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)));
							});
						}),
						new VisualState
						{
							Name = "GameControllerInputMode"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c342)
						{
							nameScope.RegisterName("GameControllerInputMode", c342);
							GameControllerInputMode = c342;
							MarkupHelper.SetVisualStateLazy(c342, delegate
							{
								c342.Name = "GameControllerInputMode";
								c342.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Padding"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarButtonOverflowTextTouchMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)));
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c343)
				{
					nameScope.RegisterName("InputModeStates", c343);
					InputModeStates = c343;
				}),
				new VisualStateGroup
				{
					Name = "KeyboardAcceleratorTextVisibility",
					States = 
					{
						new VisualState
						{
							Name = "KeyboardAcceleratorTextCollapsed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c344)
						{
							nameScope.RegisterName("KeyboardAcceleratorTextCollapsed", c344);
							KeyboardAcceleratorTextCollapsed = c344;
						}),
						new VisualState
						{
							Name = "KeyboardAcceleratorTextVisible"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c345)
						{
							nameScope.RegisterName("KeyboardAcceleratorTextVisible", c345);
							KeyboardAcceleratorTextVisible = c345;
							MarkupHelper.SetVisualStateLazy(c345, delegate
							{
								c345.Name = "KeyboardAcceleratorTextVisible";
								c345.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c346)
				{
					nameScope.RegisterName("KeyboardAcceleratorTextVisibility", c346);
					KeyboardAcceleratorTextVisibility = c346;
				}),
				new VisualStateGroup
				{
					Name = "FlyoutStates",
					States = 
					{
						new VisualState
						{
							Name = "NoFlyout"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c347)
						{
							nameScope.RegisterName("NoFlyout", c347);
							NoFlyout = c347;
						}),
						new VisualState
						{
							Name = "HasFlyout"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c348)
						{
							nameScope.RegisterName("HasFlyout", c348);
							HasFlyout = c348;
							MarkupHelper.SetVisualStateLazy(c348, delegate
							{
								c348.Name = "HasFlyout";
								c348.Setters.Add(new Setter(new TargetPropertyPath(_SubItemChevronSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c349)
				{
					nameScope.RegisterName("FlyoutStates", c349);
					FlyoutStates = c349;
				})
			});
			c296.CreationComplete();
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
internal class _AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_AppBarRDSC2
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

	private ElementNameSubject _CheckedHighlightBackgroundSubject = new ElementNameSubject();

	private ElementNameSubject _AccentOverlayBackgroundSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowCheckGlyphSubject = new ElementNameSubject();

	private ElementNameSubject _ContentSubject = new ElementNameSubject();

	private ElementNameSubject _ContentViewboxSubject = new ElementNameSubject();

	private ElementNameSubject _TextLabelSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowTextLabelSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextLabelSubject = new ElementNameSubject();

	private ElementNameSubject _ContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _FullSizeSubject = new ElementNameSubject();

	private ElementNameSubject _CompactSubject = new ElementNameSubject();

	private ElementNameSubject _LabelOnRightSubject = new ElementNameSubject();

	private ElementNameSubject _LabelCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowWithMenuIconsSubject = new ElementNameSubject();

	private ElementNameSubject _ApplicationViewStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _PointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _PressedSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CheckedDisabledSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowNormalSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowPressedSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowCheckedSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowCheckedPointerOverSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowCheckedPressedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _InputModeDefaultSubject = new ElementNameSubject();

	private ElementNameSubject _TouchInputModeSubject = new ElementNameSubject();

	private ElementNameSubject _GameControllerInputModeSubject = new ElementNameSubject();

	private ElementNameSubject _InputModeStatesSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _KeyboardAcceleratorTextVisibilitySubject = new ElementNameSubject();

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

	private Rectangle _component_1
	{
		get
		{
			return (Rectangle)_component_1_Holder.Instance;
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

	private Viewbox _component_3
	{
		get
		{
			return (Viewbox)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private TextBlock _component_4
	{
		get
		{
			return (TextBlock)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private TextBlock _component_5
	{
		get
		{
			return (TextBlock)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private Grid _component_6
	{
		get
		{
			return (Grid)_component_6_Holder.Instance;
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

	private Rectangle CheckedHighlightBackground
	{
		get
		{
			return (Rectangle)_CheckedHighlightBackgroundSubject.ElementInstance;
		}
		set
		{
			_CheckedHighlightBackgroundSubject.ElementInstance = value;
		}
	}

	private Rectangle AccentOverlayBackground
	{
		get
		{
			return (Rectangle)_AccentOverlayBackgroundSubject.ElementInstance;
		}
		set
		{
			_AccentOverlayBackgroundSubject.ElementInstance = value;
		}
	}

	private TextBlock OverflowCheckGlyph
	{
		get
		{
			return (TextBlock)_OverflowCheckGlyphSubject.ElementInstance;
		}
		set
		{
			_OverflowCheckGlyphSubject.ElementInstance = value;
		}
	}

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

	private Viewbox ContentViewbox
	{
		get
		{
			return (Viewbox)_ContentViewboxSubject.ElementInstance;
		}
		set
		{
			_ContentViewboxSubject.ElementInstance = value;
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

	private TextBlock OverflowTextLabel
	{
		get
		{
			return (TextBlock)_OverflowTextLabelSubject.ElementInstance;
		}
		set
		{
			_OverflowTextLabelSubject.ElementInstance = value;
		}
	}

	private TextBlock KeyboardAcceleratorTextLabel
	{
		get
		{
			return (TextBlock)_KeyboardAcceleratorTextLabelSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextLabelSubject.ElementInstance = value;
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

	private VisualState FullSize
	{
		get
		{
			return (VisualState)_FullSizeSubject.ElementInstance;
		}
		set
		{
			_FullSizeSubject.ElementInstance = value;
		}
	}

	private VisualState Compact
	{
		get
		{
			return (VisualState)_CompactSubject.ElementInstance;
		}
		set
		{
			_CompactSubject.ElementInstance = value;
		}
	}

	private VisualState LabelOnRight
	{
		get
		{
			return (VisualState)_LabelOnRightSubject.ElementInstance;
		}
		set
		{
			_LabelOnRightSubject.ElementInstance = value;
		}
	}

	private VisualState LabelCollapsed
	{
		get
		{
			return (VisualState)_LabelCollapsedSubject.ElementInstance;
		}
		set
		{
			_LabelCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState Overflow
	{
		get
		{
			return (VisualState)_OverflowSubject.ElementInstance;
		}
		set
		{
			_OverflowSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowWithMenuIcons
	{
		get
		{
			return (VisualState)_OverflowWithMenuIconsSubject.ElementInstance;
		}
		set
		{
			_OverflowWithMenuIconsSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ApplicationViewStates
	{
		get
		{
			return (VisualStateGroup)_ApplicationViewStatesSubject.ElementInstance;
		}
		set
		{
			_ApplicationViewStatesSubject.ElementInstance = value;
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

	private VisualState Checked
	{
		get
		{
			return (VisualState)_CheckedSubject.ElementInstance;
		}
		set
		{
			_CheckedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPointerOver
	{
		get
		{
			return (VisualState)_CheckedPointerOverSubject.ElementInstance;
		}
		set
		{
			_CheckedPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedPressed
	{
		get
		{
			return (VisualState)_CheckedPressedSubject.ElementInstance;
		}
		set
		{
			_CheckedPressedSubject.ElementInstance = value;
		}
	}

	private VisualState CheckedDisabled
	{
		get
		{
			return (VisualState)_CheckedDisabledSubject.ElementInstance;
		}
		set
		{
			_CheckedDisabledSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowNormal
	{
		get
		{
			return (VisualState)_OverflowNormalSubject.ElementInstance;
		}
		set
		{
			_OverflowNormalSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowPointerOver
	{
		get
		{
			return (VisualState)_OverflowPointerOverSubject.ElementInstance;
		}
		set
		{
			_OverflowPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowPressed
	{
		get
		{
			return (VisualState)_OverflowPressedSubject.ElementInstance;
		}
		set
		{
			_OverflowPressedSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowChecked
	{
		get
		{
			return (VisualState)_OverflowCheckedSubject.ElementInstance;
		}
		set
		{
			_OverflowCheckedSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowCheckedPointerOver
	{
		get
		{
			return (VisualState)_OverflowCheckedPointerOverSubject.ElementInstance;
		}
		set
		{
			_OverflowCheckedPointerOverSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowCheckedPressed
	{
		get
		{
			return (VisualState)_OverflowCheckedPressedSubject.ElementInstance;
		}
		set
		{
			_OverflowCheckedPressedSubject.ElementInstance = value;
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

	private VisualState InputModeDefault
	{
		get
		{
			return (VisualState)_InputModeDefaultSubject.ElementInstance;
		}
		set
		{
			_InputModeDefaultSubject.ElementInstance = value;
		}
	}

	private VisualState TouchInputMode
	{
		get
		{
			return (VisualState)_TouchInputModeSubject.ElementInstance;
		}
		set
		{
			_TouchInputModeSubject.ElementInstance = value;
		}
	}

	private VisualState GameControllerInputMode
	{
		get
		{
			return (VisualState)_GameControllerInputModeSubject.ElementInstance;
		}
		set
		{
			_GameControllerInputModeSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup InputModeStates
	{
		get
		{
			return (VisualStateGroup)_InputModeStatesSubject.ElementInstance;
		}
		set
		{
			_InputModeStatesSubject.ElementInstance = value;
		}
	}

	private VisualState KeyboardAcceleratorTextCollapsed
	{
		get
		{
			return (VisualState)_KeyboardAcceleratorTextCollapsedSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState KeyboardAcceleratorTextVisible
	{
		get
		{
			return (VisualState)_KeyboardAcceleratorTextVisibleSubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextVisibleSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup KeyboardAcceleratorTextVisibility
	{
		get
		{
			return (VisualStateGroup)_KeyboardAcceleratorTextVisibilitySubject.ElementInstance;
		}
		set
		{
			_KeyboardAcceleratorTextVisibilitySubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_177)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "Root",
			Children = 
			{
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "CheckedHighlightBackground",
					Opacity = 0.0
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Rectangle c350)
				{
					nameScope.RegisterName("CheckedHighlightBackground", c350);
					CheckedHighlightBackground = c350;
					ResourceResolverSingleton.Instance.ApplyResource(c350, Shape.FillProperty, "AppBarToggleButtonBackgroundChecked", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
					_component_0 = c350;
					c350.CreationComplete();
				}),
				(UIElement)new Rectangle
				{
					IsParsing = true,
					Name = "AccentOverlayBackground"
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Rectangle c351)
				{
					nameScope.RegisterName("AccentOverlayBackground", c351);
					AccentOverlayBackground = c351;
					ResourceResolverSingleton.Instance.ApplyResource(c351, Shape.FillProperty, "AppBarToggleButtonBackgroundHighLightOverlay", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
					_component_1 = c351;
					c351.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentRoot",
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
					RowDefinitions = 
					{
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						},
						new RowDefinition
						{
							Height = new GridLength(1.0, GridUnitType.Auto)
						}
					},
					Children = 
					{
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Name = "OverflowCheckGlyph",
							Text = "\ue73e",
							FontSize = 16.0,
							HorizontalAlignment = HorizontalAlignment.Left,
							VerticalAlignment = VerticalAlignment.Center,
							Height = 14.0,
							Width = 14.0,
							Opacity = 0.0,
							Visibility = Visibility.Collapsed
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TextBlock c356)
						{
							nameScope.RegisterName("OverflowCheckGlyph", c356);
							OverflowCheckGlyph = c356;
							ResourceResolverSingleton.Instance.ApplyResource(c356, TextBlock.ForegroundProperty, "AppBarToggleButtonCheckGlyphForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c356, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							ResourceResolverSingleton.Instance.ApplyResource(c356, FrameworkElement.MarginProperty, "AppBarToggleButtonOverflowCheckMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c356, AccessibilityView.Raw);
							_component_2 = c356;
							c356.CreationComplete();
						}),
						(UIElement)new Viewbox
						{
							IsParsing = true,
							Name = "ContentViewbox",
							Height = 20.0,
							HorizontalAlignment = HorizontalAlignment.Center,
							Child = new ContentPresenter
							{
								IsParsing = true,
								Name = "Content"
							}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ContentPresenter c357)
							{
								nameScope.RegisterName("Content", c357);
								Content = c357;
								c357.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Icon",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c357.SetBinding(ContentPresenter.ForegroundProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c357.CreationComplete();
							})
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Viewbox c358)
						{
							nameScope.RegisterName("ContentViewbox", c358);
							ContentViewbox = c358;
							ResourceResolverSingleton.Instance.ApplyResource(c358, FrameworkElement.MarginProperty, "AppBarButtonContentViewboxCollapsedMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c358, AccessibilityView.Raw);
							_component_3 = c358;
							c358.CreationComplete();
						}),
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Name = "TextLabel",
							FontSize = 11.0,
							TextAlignment = TextAlignment.Center,
							TextWrapping = TextWrapping.Wrap,
							Margin = new Thickness(2.0, 0.0, 2.0, 6.0)
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TextBlock c359)
						{
							nameScope.RegisterName("TextLabel", c359);
							TextLabel = c359;
							Grid.SetRow(c359, 1);
							c359.SetBinding(TextBlock.TextProperty, new Binding
							{
								Path = "Label",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c359.SetBinding(TextBlock.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c359.SetBinding(TextBlock.FontFamilyProperty, new Binding
							{
								Path = "FontFamily",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c359, AccessibilityView.Raw);
							c359.CreationComplete();
						}),
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Name = "OverflowTextLabel",
							TextAlignment = TextAlignment.Left,
							TextTrimming = TextTrimming.Clip,
							TextWrapping = TextWrapping.NoWrap,
							HorizontalAlignment = HorizontalAlignment.Stretch,
							VerticalAlignment = VerticalAlignment.Center,
							Margin = new Thickness(38.0, 0.0, 12.0, 0.0),
							Visibility = Visibility.Collapsed
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TextBlock c360)
						{
							nameScope.RegisterName("OverflowTextLabel", c360);
							OverflowTextLabel = c360;
							c360.SetBinding(TextBlock.TextProperty, new Binding
							{
								Path = "Label",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c360.SetBinding(TextBlock.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c360.SetBinding(TextBlock.FontFamilyProperty, new Binding
							{
								Path = "FontFamily",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							ResourceResolverSingleton.Instance.ApplyResource(c360, TextBlock.PaddingProperty, "AppBarToggleButtonOverflowTextLabelPadding", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c360, AccessibilityView.Raw);
							_component_4 = c360;
							c360.CreationComplete();
						}),
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Name = "KeyboardAcceleratorTextLabel",
							Margin = new Thickness(24.0, 0.0, 12.0, 0.0),
							HorizontalAlignment = HorizontalAlignment.Right,
							VerticalAlignment = VerticalAlignment.Center,
							Visibility = Visibility.Collapsed
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(TextBlock c361)
						{
							nameScope.RegisterName("KeyboardAcceleratorTextLabel", c361);
							KeyboardAcceleratorTextLabel = c361;
							Grid.SetColumn(c361, 1);
							ResourceResolverSingleton.Instance.ApplyResource(c361, FrameworkElement.StyleProperty, "CaptionTextBlockStyle", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							c361.SetBinding(TextBlock.TextProperty, new Binding
							{
								Path = "KeyboardAcceleratorTextOverride",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c361.SetBinding(FrameworkElement.MinWidthProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.KeyboardAcceleratorTextMinWidth"
							});
							ResourceResolverSingleton.Instance.ApplyResource(c361, TextBlock.ForegroundProperty, "AppBarToggleButtonKeyboardAcceleratorTextForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
							AutomationProperties.SetAccessibilityView(c361, AccessibilityView.Raw);
							_component_5 = c361;
							c361.CreationComplete();
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Grid c362)
				{
					nameScope.RegisterName("ContentRoot", c362);
					ContentRoot = c362;
					ResourceResolverSingleton.Instance.ApplyResource(c362, FrameworkElement.MinHeightProperty, "AppBarThemeMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
					_component_6 = c362;
					c362.CreationComplete();
				})
			}
		}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Grid c363)
		{
			nameScope.RegisterName("Root", c363);
			Root = c363;
			c363.SetBinding(FrameworkElement.MinWidthProperty, new Binding
			{
				Path = "MinWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c363.SetBinding(FrameworkElement.MaxWidthProperty, new Binding
			{
				Path = "MaxWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c363.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c363.SetBinding(Grid.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c363.SetBinding(Grid.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c363.SetBinding(Grid.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c363, new VisualStateGroup[4]
			{
				new VisualStateGroup
				{
					Name = "ApplicationViewStates",
					States = 
					{
						new VisualState
						{
							Name = "FullSize"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c364)
						{
							nameScope.RegisterName("FullSize", c364);
							FullSize = c364;
						}),
						new VisualState
						{
							Name = "Compact"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c365)
						{
							nameScope.RegisterName("Compact", c365);
							Compact = c365;
							MarkupHelper.SetVisualStateLazy(c365, delegate
							{
								c365.Name = "Compact";
								c365.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Collapsed"
										} }
									}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c367)
									{
										Storyboard.SetTargetName(c367, "TextLabel");
										Storyboard.SetTarget(c367, _TextLabelSubject);
										Storyboard.SetTargetProperty(c367, "Visibility");
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "LabelOnRight"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c368)
						{
							nameScope.RegisterName("LabelOnRight", c368);
							LabelOnRight = c368;
							MarkupHelper.SetVisualStateLazy(c368, delegate
							{
								c368.Name = "LabelOnRight";
								c368.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c369)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c369, ObjectKeyFrame.ValueProperty, "AppBarButtonContentViewboxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_7 = c369;
												NameScope.SetNameScope(_component_7, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c370)
										{
											Storyboard.SetTargetName(c370, "ContentViewbox");
											Storyboard.SetTarget(c370, _ContentViewboxSubject);
											Storyboard.SetTargetProperty(c370, "Margin");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c371)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c371, ObjectKeyFrame.ValueProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_8 = c371;
												NameScope.SetNameScope(_component_8, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c372)
										{
											Storyboard.SetTargetName(c372, "ContentRoot");
											Storyboard.SetTarget(c372, _ContentRootSubject);
											Storyboard.SetTargetProperty(c372, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "0"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c374)
										{
											Storyboard.SetTargetName(c374, "TextLabel");
											Storyboard.SetTarget(c374, _TextLabelSubject);
											Storyboard.SetTargetProperty(c374, "(Windows.UI.Xaml.Controls:Grid.Row)");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c376)
										{
											Storyboard.SetTargetName(c376, "TextLabel");
											Storyboard.SetTarget(c376, _TextLabelSubject);
											Storyboard.SetTargetProperty(c376, "(Windows.UI.Xaml.Controls:Grid.Column)");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Left"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c378)
										{
											Storyboard.SetTargetName(c378, "TextLabel");
											Storyboard.SetTarget(c378, _TextLabelSubject);
											Storyboard.SetTargetProperty(c378, "TextAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c379)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c379, ObjectKeyFrame.ValueProperty, "AppBarToggleButtonTextLabelOnRightMargin", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_9 = c379;
												NameScope.SetNameScope(_component_9, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c380)
										{
											Storyboard.SetTargetName(c380, "TextLabel");
											Storyboard.SetTarget(c380, _TextLabelSubject);
											Storyboard.SetTargetProperty(c380, "Margin");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "LabelCollapsed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c381)
						{
							nameScope.RegisterName("LabelCollapsed", c381);
							LabelCollapsed = c381;
							MarkupHelper.SetVisualStateLazy(c381, delegate
							{
								c381.Name = "LabelCollapsed";
								c381.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(DiscreteObjectKeyFrame c382)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c382, ObjectKeyFrame.ValueProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_);
												_component_10 = c382;
												NameScope.SetNameScope(_component_10, nameScope);
											}) }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c383)
										{
											Storyboard.SetTargetName(c383, "ContentRoot");
											Storyboard.SetTarget(c383, _ContentRootSubject);
											Storyboard.SetTargetProperty(c383, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Collapsed"
											} }
										}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c385)
										{
											Storyboard.SetTargetName(c385, "TextLabel");
											Storyboard.SetTarget(c385, _TextLabelSubject);
											Storyboard.SetTargetProperty(c385, "Visibility");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "Overflow"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c386)
						{
							nameScope.RegisterName("Overflow", c386);
							Overflow = c386;
							MarkupHelper.SetVisualStateLazy(c386, delegate
							{
								c386.Name = "Overflow";
								c386.Setters.Add(new Setter(new TargetPropertyPath(_ContentRootSubject, (PropertyPath)"MinHeight"), "0"));
								c386.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c386.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c386.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c386.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Visibility"), "Visible"));
								c386.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						}),
						new VisualState
						{
							Name = "OverflowWithMenuIcons"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c387)
						{
							nameScope.RegisterName("OverflowWithMenuIcons", c387);
							OverflowWithMenuIcons = c387;
							MarkupHelper.SetVisualStateLazy(c387, delegate
							{
								c387.Name = "OverflowWithMenuIcons";
								c387.Setters.Add(new Setter(new TargetPropertyPath(_ContentRootSubject, (PropertyPath)"MinHeight"), "0"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Visibility"), "Visible"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"VerticalAlignment"), "Center"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"MaxWidth"), "16"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"MaxHeight"), "16"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_ContentViewboxSubject, (PropertyPath)"Margin"), "38,0,12,0"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Visibility"), "Visible"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
								c387.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Margin"), "76,0,12,0"));
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c388)
				{
					nameScope.RegisterName("ApplicationViewStates", c388);
					ApplicationViewStates = c388;
				}),
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c389)
						{
							nameScope.RegisterName("Normal", c389);
							Normal = c389;
						}),
						new VisualState
						{
							Name = "PointerOver"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c390)
						{
							nameScope.RegisterName("PointerOver", c390);
							PointerOver = c390;
							MarkupHelper.SetVisualStateLazy(c390, delegate
							{
								c390.Name = "PointerOver";
								c390.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c390.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c390.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c390.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c390.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c390.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c390.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Pressed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c391)
						{
							nameScope.RegisterName("Pressed", c391);
							Pressed = c391;
							MarkupHelper.SetVisualStateLazy(c391, delegate
							{
								c391.Name = "Pressed";
								c391.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c391.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c391.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c391.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c391.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c391.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c391.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Disabled"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c392)
						{
							nameScope.RegisterName("Disabled", c392);
							Disabled = c392;
							MarkupHelper.SetVisualStateLazy(c392, delegate
							{
								c392.Name = "Disabled";
								c392.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"Background"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c392.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c392.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c392.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c392.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c392.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c392.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Checked"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c393)
						{
							nameScope.RegisterName("Checked", c393);
							Checked = c393;
							MarkupHelper.SetVisualStateLazy(c393, delegate
							{
								c393.Name = "Checked";
								c393.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c393.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c393.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c393.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c393.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c393.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Opacity"), "1"));
								c393.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "CheckedPointerOver"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c394)
						{
							nameScope.RegisterName("CheckedPointerOver", c394);
							CheckedPointerOver = c394;
							MarkupHelper.SetVisualStateLazy(c394, delegate
							{
								c394.Name = "CheckedPointerOver";
								c394.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Opacity"), "1"));
								c394.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "CheckedPressed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c395)
						{
							nameScope.RegisterName("CheckedPressed", c395);
							CheckedPressed = c395;
							MarkupHelper.SetVisualStateLazy(c395, delegate
							{
								c395.Name = "CheckedPressed";
								c395.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Opacity"), "1"));
								c395.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "CheckedDisabled"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c396)
						{
							nameScope.RegisterName("CheckedDisabled", c396);
							CheckedDisabled = c396;
							MarkupHelper.SetVisualStateLazy(c396, delegate
							{
								c396.Name = "CheckedDisabled";
								c396.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundCheckedDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundCheckedDisabled", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Opacity"), "1"));
								c396.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Opacity"), "1"));
							});
						}),
						new VisualState
						{
							Name = "OverflowNormal"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c397)
						{
							nameScope.RegisterName("OverflowNormal", c397);
							OverflowNormal = c397;
							MarkupHelper.SetVisualStateLazy(c397, delegate
							{
								c397.Name = "OverflowNormal";
								c397.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c398)
									{
										Storyboard.SetTargetName(c398, "ContentRoot");
										Storyboard.SetTarget(c398, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowPointerOver"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c399)
						{
							nameScope.RegisterName("OverflowPointerOver", c399);
							OverflowPointerOver = c399;
							MarkupHelper.SetVisualStateLazy(c399, delegate
							{
								c399.Name = "OverflowPointerOver";
								c399.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c399.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c399.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c399.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c399.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c399.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c399.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c399.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c400)
									{
										Storyboard.SetTargetName(c400, "ContentRoot");
										Storyboard.SetTarget(c400, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowPressed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c401)
						{
							nameScope.RegisterName("OverflowPressed", c401);
							OverflowPressed = c401;
							MarkupHelper.SetVisualStateLazy(c401, delegate
							{
								c401.Name = "OverflowPressed";
								c401.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c401.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c401.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c401.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c401.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c401.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c401.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c401.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerDownThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerDownThemeAnimation c402)
									{
										Storyboard.SetTargetName(c402, "ContentRoot");
										Storyboard.SetTarget(c402, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowChecked"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c403)
						{
							nameScope.RegisterName("OverflowChecked", c403);
							OverflowChecked = c403;
							MarkupHelper.SetVisualStateLazy(c403, delegate
							{
								c403.Name = "OverflowChecked";
								c403.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c403.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c403.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c403.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundChecked", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundChecked", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c403.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Opacity"), "1"));
								c403.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Opacity"), "1"));
								c403.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c404)
									{
										Storyboard.SetTargetName(c404, "ContentRoot");
										Storyboard.SetTarget(c404, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowCheckedPointerOver"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c405)
						{
							nameScope.RegisterName("OverflowCheckedPointerOver", c405);
							OverflowCheckedPointerOver = c405;
							MarkupHelper.SetVisualStateLazy(c405, delegate
							{
								c405.Name = "OverflowCheckedPointerOver";
								c405.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundCheckedPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundCheckedPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundPointerOver", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundPointerOver", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Opacity"), "1"));
								c405.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Opacity"), "1"));
								c405.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerUpThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerUpThemeAnimation c406)
									{
										Storyboard.SetTargetName(c406, "ContentRoot");
										Storyboard.SetTarget(c406, _ContentRootSubject);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "OverflowCheckedPressed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c407)
						{
							nameScope.RegisterName("OverflowCheckedPressed", c407);
							OverflowCheckedPressed = c407;
							MarkupHelper.SetVisualStateLazy(c407, delegate
							{
								c407.Name = "OverflowCheckedPressed";
								c407.Setters.Add(new Setter(new TargetPropertyPath(_RootSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBorderBrushCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBorderBrushCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_ContentSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_TextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonCheckGlyphForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonCheckGlyphForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_AccentOverlayBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundHighLightOverlayCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundHighLightOverlayCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Fill"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonBackgroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonBackgroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowLabelForegroundCheckedPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonOverflowLabelForegroundCheckedPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonKeyboardAcceleratorTextForegroundPressed", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("AppBarToggleButtonKeyboardAcceleratorTextForegroundPressed", GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_, isTheme: true, isHotReload: false));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_CheckedHighlightBackgroundSubject, (PropertyPath)"Opacity"), "1"));
								c407.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Opacity"), "1"));
								c407.Storyboard = new Storyboard
								{
									Children = { (Timeline)new PointerDownThemeAnimation().AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(PointerDownThemeAnimation c408)
									{
										Storyboard.SetTargetName(c408, "ContentRoot");
										Storyboard.SetTarget(c408, _ContentRootSubject);
									}) }
								};
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c409)
				{
					nameScope.RegisterName("CommonStates", c409);
					CommonStates = c409;
				}),
				new VisualStateGroup
				{
					Name = "InputModeStates",
					States = 
					{
						new VisualState
						{
							Name = "InputModeDefault"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c410)
						{
							nameScope.RegisterName("InputModeDefault", c410);
							InputModeDefault = c410;
						}),
						new VisualState
						{
							Name = "TouchInputMode"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c411)
						{
							nameScope.RegisterName("TouchInputMode", c411);
							TouchInputMode = c411;
							MarkupHelper.SetVisualStateLazy(c411, delegate
							{
								c411.Name = "TouchInputMode";
								c411.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Padding"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowTextTouchMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)));
								c411.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowCheckTouchMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)));
							});
						}),
						new VisualState
						{
							Name = "GameControllerInputMode"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c412)
						{
							nameScope.RegisterName("GameControllerInputMode", c412);
							GameControllerInputMode = c412;
							MarkupHelper.SetVisualStateLazy(c412, delegate
							{
								c412.Name = "GameControllerInputMode";
								c412.Setters.Add(new Setter(new TargetPropertyPath(_OverflowTextLabelSubject, (PropertyPath)"Padding"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowTextTouchMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)));
								c412.Setters.Add(new Setter(new TargetPropertyPath(_OverflowCheckGlyphSubject, (PropertyPath)"Margin"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AppBarToggleButtonOverflowCheckTouchMargin", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__0.Instance.__ParseContext_)));
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c413)
				{
					nameScope.RegisterName("InputModeStates", c413);
					InputModeStates = c413;
				}),
				new VisualStateGroup
				{
					Name = "KeyboardAcceleratorTextVisibility",
					States = 
					{
						new VisualState
						{
							Name = "KeyboardAcceleratorTextCollapsed"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c414)
						{
							nameScope.RegisterName("KeyboardAcceleratorTextCollapsed", c414);
							KeyboardAcceleratorTextCollapsed = c414;
						}),
						new VisualState
						{
							Name = "KeyboardAcceleratorTextVisible"
						}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c415)
						{
							nameScope.RegisterName("KeyboardAcceleratorTextVisible", c415);
							KeyboardAcceleratorTextVisible = c415;
							MarkupHelper.SetVisualStateLazy(c415, delegate
							{
								c415.Name = "KeyboardAcceleratorTextVisible";
								c415.Setters.Add(new Setter(new TargetPropertyPath(_KeyboardAcceleratorTextLabelSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c416)
				{
					nameScope.RegisterName("KeyboardAcceleratorTextVisibility", c416);
					KeyboardAcceleratorTextVisibility = c416;
				})
			});
			c363.CreationComplete();
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
internal class _AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_AppBarRDSC3
{
	private ElementNameSubject _SeparatorRectangleSubject = new ElementNameSubject();

	private ElementNameSubject _FullSizeSubject = new ElementNameSubject();

	private ElementNameSubject _CompactSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowSubject = new ElementNameSubject();

	private ElementNameSubject _ApplicationViewStatesSubject = new ElementNameSubject();

	private Rectangle SeparatorRectangle
	{
		get
		{
			return (Rectangle)_SeparatorRectangleSubject.ElementInstance;
		}
		set
		{
			_SeparatorRectangleSubject.ElementInstance = value;
		}
	}

	private VisualState FullSize
	{
		get
		{
			return (VisualState)_FullSizeSubject.ElementInstance;
		}
		set
		{
			_FullSizeSubject.ElementInstance = value;
		}
	}

	private VisualState Compact
	{
		get
		{
			return (VisualState)_CompactSubject.ElementInstance;
		}
		set
		{
			_CompactSubject.ElementInstance = value;
		}
	}

	private VisualState Overflow
	{
		get
		{
			return (VisualState)_OverflowSubject.ElementInstance;
		}
		set
		{
			_OverflowSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ApplicationViewStates
	{
		get
		{
			return (VisualStateGroup)_ApplicationViewStatesSubject.ElementInstance;
		}
		set
		{
			_ApplicationViewStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_224)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Rectangle
		{
			IsParsing = true,
			Name = "SeparatorRectangle",
			Width = 1.0,
			Height = 20.0,
			Margin = new Thickness(16.0, 12.0, 15.0, 12.0),
			VerticalAlignment = VerticalAlignment.Top
		}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(Rectangle c417)
		{
			nameScope.RegisterName("SeparatorRectangle", c417);
			SeparatorRectangle = c417;
			c417.SetBinding(Shape.FillProperty, new Binding
			{
				Path = "Foreground",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c417, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "ApplicationViewStates",
				States = 
				{
					new VisualState
					{
						Name = "FullSize"
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c418)
					{
						nameScope.RegisterName("FullSize", c418);
						FullSize = c418;
					}),
					new VisualState
					{
						Name = "Compact"
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c419)
					{
						nameScope.RegisterName("Compact", c419);
						Compact = c419;
					}),
					new VisualState
					{
						Name = "Overflow"
					}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualState c420)
					{
						nameScope.RegisterName("Overflow", c420);
						Overflow = c420;
						MarkupHelper.SetVisualStateLazy(c420, delegate
						{
							c420.Name = "Overflow";
							c420.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "NaN"
										} }
									}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c422)
									{
										Storyboard.SetTargetName(c422, "SeparatorRectangle");
										Storyboard.SetTarget(c422, _SeparatorRectangleSubject);
										Storyboard.SetTargetProperty(c422, "Width");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Stretch"
										} }
									}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c424)
									{
										Storyboard.SetTargetName(c424, "SeparatorRectangle");
										Storyboard.SetTarget(c424, _SeparatorRectangleSubject);
										Storyboard.SetTargetProperty(c424, "HorizontalAlignment");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "1"
										} }
									}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c426)
									{
										Storyboard.SetTargetName(c426, "SeparatorRectangle");
										Storyboard.SetTarget(c426, _SeparatorRectangleSubject);
										Storyboard.SetTargetProperty(c426, "Height");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "12,4,12,4"
										} }
									}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ObjectAnimationUsingKeyFrames c428)
									{
										Storyboard.SetTargetName(c428, "SeparatorRectangle");
										Storyboard.SetTarget(c428, _SeparatorRectangleSubject);
										Storyboard.SetTargetProperty(c428, "Margin");
									})
								}
							};
						});
					})
				}
			}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(VisualStateGroup c429)
			{
				nameScope.RegisterName("ApplicationViewStates", c429);
				ApplicationViewStates = c429;
			}) });
			c417.CreationComplete();
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
internal class _AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_AppBarRDSC4
{
	public UIElement Build(object __ResourceOwner_228)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new ContentPresenter
		{
			IsParsing = true
		}.AppBar_7546a2e65cd5cf5cb1a37a5d961c82db_XamlApply(delegate(ContentPresenter c430)
		{
			c430.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Content",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c430.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
			{
				Path = "ContentTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c430.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c430.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
			{
				Path = "ContentTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c430.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
			{
				Path = "HorizontalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c430.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
			{
				Path = "VerticalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c430.CreationComplete();
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

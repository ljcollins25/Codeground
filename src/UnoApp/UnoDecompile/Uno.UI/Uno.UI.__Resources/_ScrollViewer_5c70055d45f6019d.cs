using System;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_ScrollViewerRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ScrollContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalScrollBarSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalScrollBarSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollBarSeparatorSubject = new ElementNameSubject();

	private ElementNameSubject _RootSubject = new ElementNameSubject();

	private ElementNameSubject _NoIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _TouchIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _MouseIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollingIndicatorStatesSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollBarSeparatorCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollBarSeparatorExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollBarSeparatorExpandedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollBarSeparatorCollapsedWithoutAnimationSubject = new ElementNameSubject();

	private ElementNameSubject _ScrollBarSeparatorStatesSubject = new ElementNameSubject();

	private Border _component_0
	{
		get
		{
			return (Border)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_1
	{
		get
		{
			return (DoubleAnimation)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_2
	{
		get
		{
			return (DoubleAnimation)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_3
	{
		get
		{
			return (DoubleAnimation)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private DoubleAnimation _component_4
	{
		get
		{
			return (DoubleAnimation)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private ScrollContentPresenter ScrollContentPresenter
	{
		get
		{
			return (ScrollContentPresenter)_ScrollContentPresenterSubject.ElementInstance;
		}
		set
		{
			_ScrollContentPresenterSubject.ElementInstance = value;
		}
	}

	private ScrollBar VerticalScrollBar
	{
		get
		{
			return (ScrollBar)_VerticalScrollBarSubject.ElementInstance;
		}
		set
		{
			_VerticalScrollBarSubject.ElementInstance = value;
		}
	}

	private ScrollBar HorizontalScrollBar
	{
		get
		{
			return (ScrollBar)_HorizontalScrollBarSubject.ElementInstance;
		}
		set
		{
			_HorizontalScrollBarSubject.ElementInstance = value;
		}
	}

	private Border ScrollBarSeparator
	{
		get
		{
			return (Border)_ScrollBarSeparatorSubject.ElementInstance;
		}
		set
		{
			_ScrollBarSeparatorSubject.ElementInstance = value;
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

	private VisualState ScrollBarSeparatorCollapsed
	{
		get
		{
			return (VisualState)_ScrollBarSeparatorCollapsedSubject.ElementInstance;
		}
		set
		{
			_ScrollBarSeparatorCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualState ScrollBarSeparatorExpanded
	{
		get
		{
			return (VisualState)_ScrollBarSeparatorExpandedSubject.ElementInstance;
		}
		set
		{
			_ScrollBarSeparatorExpandedSubject.ElementInstance = value;
		}
	}

	private VisualState ScrollBarSeparatorExpandedWithoutAnimation
	{
		get
		{
			return (VisualState)_ScrollBarSeparatorExpandedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_ScrollBarSeparatorExpandedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualState ScrollBarSeparatorCollapsedWithoutAnimation
	{
		get
		{
			return (VisualState)_ScrollBarSeparatorCollapsedWithoutAnimationSubject.ElementInstance;
		}
		set
		{
			_ScrollBarSeparatorCollapsedWithoutAnimationSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ScrollBarSeparatorStates
	{
		get
		{
			return (VisualStateGroup)_ScrollBarSeparatorStatesSubject.ElementInstance;
		}
		set
		{
			_ScrollBarSeparatorStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_260)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Child = new Grid
			{
				IsParsing = true,
				Name = "Root",
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
						Height = new GridLength(1.0, GridUnitType.Star)
					},
					new RowDefinition
					{
						Height = new GridLength(1.0, GridUnitType.Auto)
					}
				},
				Children = 
				{
					(UIElement)new ScrollContentPresenter
					{
						IsParsing = true,
						Name = "ScrollContentPresenter"
					}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ScrollContentPresenter c4)
					{
						nameScope.RegisterName("ScrollContentPresenter", c4);
						ScrollContentPresenter = c4;
						Grid.SetRowSpan(c4, 2);
						Grid.SetColumnSpan(c4, 2);
						c4.SetBinding(FrameworkElement.MarginProperty, new Binding
						{
							Path = "Padding",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c4.CreationComplete();
					}),
					(UIElement)new ElementStub(() => new ScrollBar
					{
						IsParsing = true,
						Name = "VerticalScrollBar",
						IsTabStop = false,
						Orientation = Orientation.Vertical,
						HorizontalAlignment = HorizontalAlignment.Right
					}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ScrollBar c5)
					{
						nameScope.RegisterName("VerticalScrollBar", c5);
						VerticalScrollBar = c5;
						Grid.SetColumn(c5, 1);
						c5.SetBinding(RangeBase.MaximumProperty, new Binding
						{
							Path = "ScrollableHeight",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c5.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							Path = "ComputedVerticalScrollBarVisibility",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c5.SetBinding(RangeBase.ValueProperty, new Binding
						{
							Path = "VerticalOffset",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c5.SetBinding(ScrollBar.ViewportSizeProperty, new Binding
						{
							Path = "ViewportHeight",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c5.CreationComplete();
					})).ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ElementStub c6)
					{
						c6.Name = "VerticalScrollBar";
						_VerticalScrollBarSubject.ElementInstance = c6;
						c6.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							Path = "ComputedVerticalScrollBarVisibility",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
					}),
					(UIElement)new ElementStub(() => new ScrollBar
					{
						IsParsing = true,
						Name = "HorizontalScrollBar",
						IsTabStop = false,
						Orientation = Orientation.Horizontal
					}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ScrollBar c7)
					{
						nameScope.RegisterName("HorizontalScrollBar", c7);
						HorizontalScrollBar = c7;
						c7.SetBinding(RangeBase.MaximumProperty, new Binding
						{
							Path = "ScrollableWidth",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						Grid.SetRow(c7, 1);
						c7.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							Path = "ComputedHorizontalScrollBarVisibility",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c7.SetBinding(RangeBase.ValueProperty, new Binding
						{
							Path = "HorizontalOffset",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c7.SetBinding(ScrollBar.ViewportSizeProperty, new Binding
						{
							Path = "ViewportWidth",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c7.CreationComplete();
					})).ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ElementStub c8)
					{
						c8.Name = "HorizontalScrollBar";
						_HorizontalScrollBarSubject.ElementInstance = c8;
						c8.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							Path = "ComputedHorizontalScrollBarVisibility",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
					}),
					(UIElement)new Border
					{
						IsParsing = true,
						Name = "ScrollBarSeparator",
						Opacity = 0.0
					}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(Border c9)
					{
						nameScope.RegisterName("ScrollBarSeparator", c9);
						ScrollBarSeparator = c9;
						Grid.SetRow(c9, 1);
						Grid.SetColumn(c9, 1);
						ResourceResolverSingleton.Instance.ApplyResource(c9, FrameworkElement.BackgroundProperty, "SystemControlPageBackgroundChromeLowBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__65.Instance.__ParseContext_);
						_component_0 = c9;
						c9.CreationComplete();
					})
				}
			}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(Grid c10)
			{
				nameScope.RegisterName("Root", c10);
				Root = c10;
				c10.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c10.CreationComplete();
			})
		}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(Border c11)
		{
			c11.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c11.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c11.SetBinding(Border.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c11, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "ScrollingIndicatorStates",
					Transitions = 
					{
						new VisualTransition
						{
							From = "MouseIndicator",
							To = "NoIndicator"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualTransition c12)
						{
							MarkupHelper.SetVisualTransitionLazy(c12, delegate
							{
								c12.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(30000000L),
												Value = ScrollingIndicatorMode.None
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c14)
										{
											Storyboard.SetTargetName(c14, "VerticalScrollBar");
											Storyboard.SetTarget(c14, _VerticalScrollBarSubject);
											Storyboard.SetTargetProperty(c14, "IndicatorMode");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(30000000L),
												Value = ScrollingIndicatorMode.None
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c16)
										{
											Storyboard.SetTargetName(c16, "HorizontalScrollBar");
											Storyboard.SetTarget(c16, _HorizontalScrollBarSubject);
											Storyboard.SetTargetProperty(c16, "IndicatorMode");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							From = "TouchIndicator",
							To = "NoIndicator"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualTransition c17)
						{
							MarkupHelper.SetVisualTransitionLazy(c17, delegate
							{
								c17.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(5000000L),
												Value = ScrollingIndicatorMode.None
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c19)
										{
											Storyboard.SetTargetName(c19, "VerticalScrollBar");
											Storyboard.SetTarget(c19, _VerticalScrollBarSubject);
											Storyboard.SetTargetProperty(c19, "IndicatorMode");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(5000000L),
												Value = ScrollingIndicatorMode.None
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c21)
										{
											Storyboard.SetTargetName(c21, "HorizontalScrollBar");
											Storyboard.SetTarget(c21, _HorizontalScrollBarSubject);
											Storyboard.SetTargetProperty(c21, "IndicatorMode");
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
							Name = "NoIndicator"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualState c22)
						{
							nameScope.RegisterName("NoIndicator", c22);
							NoIndicator = c22;
						}),
						new VisualState
						{
							Name = "TouchIndicator"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualState c23)
						{
							nameScope.RegisterName("TouchIndicator", c23);
							TouchIndicator = c23;
							MarkupHelper.SetVisualStateLazy(c23, delegate
							{
								c23.Name = "TouchIndicator";
								c23.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = ScrollingIndicatorMode.TouchIndicator
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c25)
										{
											Storyboard.SetTargetName(c25, "VerticalScrollBar");
											Storyboard.SetTarget(c25, _VerticalScrollBarSubject);
											Storyboard.SetTargetProperty(c25, "IndicatorMode");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = ScrollingIndicatorMode.TouchIndicator
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c27)
										{
											Storyboard.SetTargetName(c27, "HorizontalScrollBar");
											Storyboard.SetTarget(c27, _HorizontalScrollBarSubject);
											Storyboard.SetTargetProperty(c27, "IndicatorMode");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MouseIndicator"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualState c28)
						{
							nameScope.RegisterName("MouseIndicator", c28);
							MouseIndicator = c28;
							MarkupHelper.SetVisualStateLazy(c28, delegate
							{
								c28.Name = "MouseIndicator";
								c28.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = ScrollingIndicatorMode.MouseIndicator
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c30)
										{
											Storyboard.SetTargetName(c30, "VerticalScrollBar");
											Storyboard.SetTarget(c30, _VerticalScrollBarSubject);
											Storyboard.SetTargetProperty(c30, "IndicatorMode");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											Duration = new Duration(TimeSpan.FromTicks(0L)),
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = ScrollingIndicatorMode.MouseIndicator
											} }
										}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ObjectAnimationUsingKeyFrames c32)
										{
											Storyboard.SetTargetName(c32, "HorizontalScrollBar");
											Storyboard.SetTarget(c32, _HorizontalScrollBarSubject);
											Storyboard.SetTargetProperty(c32, "IndicatorMode");
										})
									}
								};
							});
						})
					}
				}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualStateGroup c33)
				{
					nameScope.RegisterName("ScrollingIndicatorStates", c33);
					ScrollingIndicatorStates = c33;
				}),
				new VisualStateGroup
				{
					Name = "ScrollBarSeparatorStates",
					Transitions = { new VisualTransition
					{
						From = "ScrollBarSeparatorExpanded",
						To = "ScrollBarSeparatorCollapsed"
					}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualTransition c34)
					{
						MarkupHelper.SetVisualTransitionLazy(c34, delegate
						{
							c34.Storyboard = new Storyboard
							{
								Children = { (Timeline)new DoubleAnimation
								{
									To = 0.0
								}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(DoubleAnimation c35)
								{
									ResourceResolverSingleton.Instance.ApplyResource(c35, Timeline.DurationProperty, "ScrollViewerSeparatorContractDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__65.Instance.__ParseContext_);
									ResourceResolverSingleton.Instance.ApplyResource(c35, Timeline.BeginTimeProperty, "ScrollViewerSeparatorContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__65.Instance.__ParseContext_);
									Storyboard.SetTargetName(c35, "ScrollBarSeparator");
									Storyboard.SetTarget(c35, _ScrollBarSeparatorSubject);
									Storyboard.SetTargetProperty(c35, "Opacity");
									_component_1 = c35;
									NameScope.SetNameScope(_component_1, nameScope);
								}) }
							};
						});
					}) },
					States = 
					{
						new VisualState
						{
							Name = "ScrollBarSeparatorCollapsed"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualState c36)
						{
							nameScope.RegisterName("ScrollBarSeparatorCollapsed", c36);
							ScrollBarSeparatorCollapsed = c36;
						}),
						new VisualState
						{
							Name = "ScrollBarSeparatorExpanded"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualState c37)
						{
							nameScope.RegisterName("ScrollBarSeparatorExpanded", c37);
							ScrollBarSeparatorExpanded = c37;
							MarkupHelper.SetVisualStateLazy(c37, delegate
							{
								c37.Name = "ScrollBarSeparatorExpanded";
								c37.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DoubleAnimation
									{
										To = 1.0
									}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(DoubleAnimation c38)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c38, Timeline.DurationProperty, "ScrollViewerSeparatorExpandDuration", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__65.Instance.__ParseContext_);
										ResourceResolverSingleton.Instance.ApplyResource(c38, Timeline.BeginTimeProperty, "ScrollViewerSeparatorExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__65.Instance.__ParseContext_);
										Storyboard.SetTargetName(c38, "ScrollBarSeparator");
										Storyboard.SetTarget(c38, _ScrollBarSeparatorSubject);
										Storyboard.SetTargetProperty(c38, "Opacity");
										_component_2 = c38;
										NameScope.SetNameScope(_component_2, nameScope);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "ScrollBarSeparatorExpandedWithoutAnimation"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualState c39)
						{
							nameScope.RegisterName("ScrollBarSeparatorExpandedWithoutAnimation", c39);
							ScrollBarSeparatorExpandedWithoutAnimation = c39;
							MarkupHelper.SetVisualStateLazy(c39, delegate
							{
								c39.Name = "ScrollBarSeparatorExpandedWithoutAnimation";
								c39.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DoubleAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(0L)),
										To = 1.0
									}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(DoubleAnimation c40)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c40, Timeline.BeginTimeProperty, "ScrollViewerSeparatorExpandBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__65.Instance.__ParseContext_);
										Storyboard.SetTargetName(c40, "ScrollBarSeparator");
										Storyboard.SetTarget(c40, _ScrollBarSeparatorSubject);
										Storyboard.SetTargetProperty(c40, "Opacity");
										_component_3 = c40;
										NameScope.SetNameScope(_component_3, nameScope);
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "ScrollBarSeparatorCollapsedWithoutAnimation"
						}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualState c41)
						{
							nameScope.RegisterName("ScrollBarSeparatorCollapsedWithoutAnimation", c41);
							ScrollBarSeparatorCollapsedWithoutAnimation = c41;
							MarkupHelper.SetVisualStateLazy(c41, delegate
							{
								c41.Name = "ScrollBarSeparatorCollapsedWithoutAnimation";
								c41.Storyboard = new Storyboard
								{
									Children = { (Timeline)new DoubleAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(0L)),
										To = 0.0
									}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(DoubleAnimation c42)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c42, Timeline.BeginTimeProperty, "ScrollViewerSeparatorContractBeginTime", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__65.Instance.__ParseContext_);
										Storyboard.SetTargetName(c42, "ScrollBarSeparator");
										Storyboard.SetTarget(c42, _ScrollBarSeparatorSubject);
										Storyboard.SetTargetProperty(c42, "Opacity");
										_component_4 = c42;
										NameScope.SetNameScope(_component_4, nameScope);
									}) }
								};
							});
						})
					}
				}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(VisualStateGroup c43)
				{
					nameScope.RegisterName("ScrollBarSeparatorStates", c43);
					ScrollBarSeparatorStates = c43;
				})
			});
			c11.CreationComplete();
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
internal class _ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_ScrollViewerRDSC1
{
	private ElementNameSubject _ScrollContentPresenterSubject = new ElementNameSubject();

	private ScrollContentPresenter ScrollContentPresenter
	{
		get
		{
			return (ScrollContentPresenter)_ScrollContentPresenterSubject.ElementInstance;
		}
		set
		{
			_ScrollContentPresenterSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_291)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Child = new ScrollContentPresenter
			{
				IsParsing = true,
				Name = "ScrollContentPresenter"
			}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(ScrollContentPresenter c44)
			{
				nameScope.RegisterName("ScrollContentPresenter", c44);
				ScrollContentPresenter = c44;
				c44.SetBinding(FrameworkElement.MarginProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c44.CreationComplete();
			})
		}.ScrollViewer_5c70055d45f6019da4ee2981e86ea7f3_XamlApply(delegate(Border c45)
		{
			c45.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c45.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c45.SetBinding(Border.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c45.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c45.CreationComplete();
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

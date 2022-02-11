using System;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _ProgressBar_bab2e69de3222dc04321c485df7cbeee_ProgressBarRDSC0
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

	private ElementNameSubject _DeterminateProgressBarIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _IndeterminateProgressBarIndicatorSubject = new ElementNameSubject();

	private ElementNameSubject _IndeterminateProgressBarIndicator2Subject = new ElementNameSubject();

	private ElementNameSubject _ProgressBarRootSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DeterminateSubject = new ElementNameSubject();

	private ElementNameSubject _UpdatingSubject = new ElementNameSubject();

	private ElementNameSubject _IndeterminateSubject = new ElementNameSubject();

	private ElementNameSubject _IndeterminateErrorSubject = new ElementNameSubject();

	private ElementNameSubject _ErrorSubject = new ElementNameSubject();

	private ElementNameSubject _IndeterminatePausedSubject = new ElementNameSubject();

	private ElementNameSubject _PausedSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private LinearColorKeyFrame _component_0
	{
		get
		{
			return (LinearColorKeyFrame)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private LinearColorKeyFrame _component_1
	{
		get
		{
			return (LinearColorKeyFrame)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private LinearColorKeyFrame _component_2
	{
		get
		{
			return (LinearColorKeyFrame)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private LinearColorKeyFrame _component_3
	{
		get
		{
			return (LinearColorKeyFrame)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_4
	{
		get
		{
			return (ColorAnimation)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private ColorAnimation _component_5
	{
		get
		{
			return (ColorAnimation)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private DiscreteDoubleKeyFrame _component_6
	{
		get
		{
			return (DiscreteDoubleKeyFrame)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private LinearColorKeyFrame _component_7
	{
		get
		{
			return (LinearColorKeyFrame)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private LinearColorKeyFrame _component_8
	{
		get
		{
			return (LinearColorKeyFrame)_component_8_Holder.Instance;
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

	private DoubleAnimation _component_10
	{
		get
		{
			return (DoubleAnimation)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private Rectangle DeterminateProgressBarIndicator
	{
		get
		{
			return (Rectangle)_DeterminateProgressBarIndicatorSubject.ElementInstance;
		}
		set
		{
			_DeterminateProgressBarIndicatorSubject.ElementInstance = value;
		}
	}

	private Rectangle IndeterminateProgressBarIndicator
	{
		get
		{
			return (Rectangle)_IndeterminateProgressBarIndicatorSubject.ElementInstance;
		}
		set
		{
			_IndeterminateProgressBarIndicatorSubject.ElementInstance = value;
		}
	}

	private Rectangle IndeterminateProgressBarIndicator2
	{
		get
		{
			return (Rectangle)_IndeterminateProgressBarIndicator2Subject.ElementInstance;
		}
		set
		{
			_IndeterminateProgressBarIndicator2Subject.ElementInstance = value;
		}
	}

	private Border ProgressBarRoot
	{
		get
		{
			return (Border)_ProgressBarRootSubject.ElementInstance;
		}
		set
		{
			_ProgressBarRootSubject.ElementInstance = value;
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

	private VisualState Determinate
	{
		get
		{
			return (VisualState)_DeterminateSubject.ElementInstance;
		}
		set
		{
			_DeterminateSubject.ElementInstance = value;
		}
	}

	private VisualState Updating
	{
		get
		{
			return (VisualState)_UpdatingSubject.ElementInstance;
		}
		set
		{
			_UpdatingSubject.ElementInstance = value;
		}
	}

	private VisualState Indeterminate
	{
		get
		{
			return (VisualState)_IndeterminateSubject.ElementInstance;
		}
		set
		{
			_IndeterminateSubject.ElementInstance = value;
		}
	}

	private VisualState IndeterminateError
	{
		get
		{
			return (VisualState)_IndeterminateErrorSubject.ElementInstance;
		}
		set
		{
			_IndeterminateErrorSubject.ElementInstance = value;
		}
	}

	private VisualState Error
	{
		get
		{
			return (VisualState)_ErrorSubject.ElementInstance;
		}
		set
		{
			_ErrorSubject.ElementInstance = value;
		}
	}

	private VisualState IndeterminatePaused
	{
		get
		{
			return (VisualState)_IndeterminatePausedSubject.ElementInstance;
		}
		set
		{
			_IndeterminatePausedSubject.ElementInstance = value;
		}
	}

	private VisualState Paused
	{
		get
		{
			return (VisualState)_PausedSubject.ElementInstance;
		}
		set
		{
			_PausedSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_355)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Children = { (UIElement)new Border
			{
				IsParsing = true,
				Name = "ProgressBarRoot",
				Child = new Border
				{
					IsParsing = true,
					Child = new Grid
					{
						IsParsing = true,
						Children = 
						{
							(UIElement)new Rectangle
							{
								IsParsing = true,
								Name = "DeterminateProgressBarIndicator",
								HorizontalAlignment = HorizontalAlignment.Left
							}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(Rectangle c0)
							{
								nameScope.RegisterName("DeterminateProgressBarIndicator", c0);
								DeterminateProgressBarIndicator = c0;
								c0.SetBinding(FrameworkElement.MarginProperty, new Binding
								{
									Path = "Padding",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c0.SetBinding(Shape.FillProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c0.SetBinding(Rectangle.RadiusXProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_)
								});
								c0.SetBinding(Rectangle.RadiusYProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_)
								});
								c0.CreationComplete();
							}),
							(UIElement)new Rectangle
							{
								IsParsing = true,
								Name = "IndeterminateProgressBarIndicator",
								HorizontalAlignment = HorizontalAlignment.Left,
								Opacity = 0.0,
								RenderTransform = new CompositeTransform()
							}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(Rectangle c1)
							{
								nameScope.RegisterName("IndeterminateProgressBarIndicator", c1);
								IndeterminateProgressBarIndicator = c1;
								c1.SetBinding(FrameworkElement.MarginProperty, new Binding
								{
									Path = "Padding",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c1.SetBinding(Shape.FillProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c1.SetBinding(Rectangle.RadiusXProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_)
								});
								c1.SetBinding(Rectangle.RadiusYProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_)
								});
								c1.CreationComplete();
							}),
							(UIElement)new Rectangle
							{
								IsParsing = true,
								Name = "IndeterminateProgressBarIndicator2",
								HorizontalAlignment = HorizontalAlignment.Left,
								Opacity = 0.0,
								RenderTransform = new CompositeTransform()
							}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(Rectangle c2)
							{
								nameScope.RegisterName("IndeterminateProgressBarIndicator2", c2);
								IndeterminateProgressBarIndicator2 = c2;
								c2.SetBinding(FrameworkElement.MarginProperty, new Binding
								{
									Path = "Padding",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c2.SetBinding(Shape.FillProperty, new Binding
								{
									Path = "Foreground",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c2.SetBinding(Rectangle.RadiusXProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopLeftCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_)
								});
								c2.SetBinding(Rectangle.RadiusYProperty, new Binding
								{
									Path = "CornerRadius",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomRightCornerRadiusDoubleValueConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_)
								});
								c2.CreationComplete();
							})
						}
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(Grid c3)
					{
						c3.CreationComplete();
					})
				}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(Border c4)
				{
					c4.SetBinding(UIElement.ClipProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "TemplateSettings.ClipRect"
					});
					c4.CreationComplete();
				})
			}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(Border c5)
			{
				nameScope.RegisterName("ProgressBarRoot", c5);
				ProgressBarRoot = c5;
				c5.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c5.SetBinding(Border.BorderBrushProperty, new Binding
				{
					Path = "BorderBrush",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c5.SetBinding(Border.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c5.SetBinding(Border.CornerRadiusProperty, new Binding
				{
					Path = "CornerRadius",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c5.CreationComplete();
			}) }
		}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(Grid c6)
		{
			nameScope.RegisterName("LayoutRoot", c6);
			LayoutRoot = c6;
			VisualStateManager.SetVisualStateGroups(c6, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				Transitions = 
				{
					new VisualTransition
					{
						From = "Updating",
						To = "Determinate"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualTransition c7)
					{
						MarkupHelper.SetVisualTransitionLazy(c7, delegate
						{
							c7.Storyboard = new Storyboard();
						});
					}),
					new VisualTransition
					{
						From = "Paused",
						To = "Determinate"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualTransition c8)
					{
						MarkupHelper.SetVisualTransitionLazy(c8, delegate
						{
							c8.Storyboard = new Storyboard
							{
								Children = { (Timeline)new DoubleAnimation
								{
									To = 1.0,
									Duration = new Duration(TimeSpan.FromTicks(2500000L))
								}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimation c9)
								{
									Storyboard.SetTargetName(c9, "DeterminateProgressBarIndicator");
									Storyboard.SetTarget(c9, _DeterminateProgressBarIndicatorSubject);
									Storyboard.SetTargetProperty(c9, "Opacity");
								}) }
							};
						});
					}),
					new VisualTransition
					{
						From = "Error",
						To = "Determinate"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualTransition c10)
					{
						MarkupHelper.SetVisualTransitionLazy(c10, delegate
						{
							c10.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ColorAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(2500000L))
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ColorAnimation c11)
									{
										Storyboard.SetTargetName(c11, "DeterminateProgressBarIndicator");
										Storyboard.SetTarget(c11, _DeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c11, "(Windows.UI.Xaml.Shapes:Shape.Fill).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
										c11.SetBinding(ColorAnimation.ToProperty, new Binding
										{
											Path = "Foreground",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
									}),
									(Timeline)new ColorAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(2500000L))
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ColorAnimation c12)
									{
										Storyboard.SetTargetName(c12, "ProgressBarRoot");
										Storyboard.SetTarget(c12, _ProgressBarRootSubject);
										Storyboard.SetTargetProperty(c12, "(Windows.UI.Xaml.Controls:Border.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
										c12.SetBinding(ColorAnimation.ToProperty, new Binding
										{
											Path = "Background",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
									})
								}
							};
						});
					}),
					new VisualTransition
					{
						From = "Indeterminate",
						To = "Determinate"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualTransition c13)
					{
						MarkupHelper.SetVisualTransitionLazy(c13, delegate
						{
							c13.Storyboard = new Storyboard
							{
								Children = { (Timeline)new Storyboard
								{
									Children = 
									{
										(Timeline)new FadeInThemeAnimation
										{
											TargetName = "IndeterminateProgressBarIndicator"
										}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(FadeInThemeAnimation c14)
										{
											NameScope.SetNameScope(c14, nameScope);
										}),
										(Timeline)new FadeInThemeAnimation
										{
											TargetName = "IndeterminateProgressBarIndicator2"
										}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(FadeInThemeAnimation c15)
										{
											NameScope.SetNameScope(c15, nameScope);
										})
									}
								} }
							};
						});
					})
				},
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c16)
					{
						nameScope.RegisterName("Normal", c16);
						Normal = c16;
					}),
					new VisualState
					{
						Name = "Determinate"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c17)
					{
						nameScope.RegisterName("Determinate", c17);
						Determinate = c17;
					}),
					new VisualState
					{
						Name = "Updating"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c18)
					{
						nameScope.RegisterName("Updating", c18);
						Updating = c18;
					}),
					new VisualState
					{
						Name = "Indeterminate"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c19)
					{
						nameScope.RegisterName("Indeterminate", c19);
						Indeterminate = c19;
						MarkupHelper.SetVisualStateLazy(c19, delegate
						{
							c19.Name = "Indeterminate";
							c19.Storyboard = new Storyboard
							{
								RepeatBehavior = "Forever",
								Children = 
								{
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c20)
											{
												c20.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationStartPosition"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(15000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c21)
											{
												c21.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationEndPosition"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(20000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c22)
											{
												c22.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationEndPosition"
												});
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c23)
									{
										Storyboard.SetTargetName(c23, "IndeterminateProgressBarIndicator");
										Storyboard.SetTarget(c23, _IndeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c23, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateX)");
									}),
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c24)
											{
												c24.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationStartPosition2"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(7500000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c25)
											{
												c25.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationStartPosition2"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(20000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c26)
											{
												c26.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationEndPosition2"
												});
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c27)
									{
										Storyboard.SetTargetName(c27, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c27, _IndeterminateProgressBarIndicator2Subject);
										Storyboard.SetTargetProperty(c27, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateX)");
									}),
									(Timeline)new DoubleAnimation
									{
										To = 1.0,
										Duration = new Duration(TimeSpan.FromTicks(0L))
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimation c28)
									{
										Storyboard.SetTargetName(c28, "IndeterminateProgressBarIndicator");
										Storyboard.SetTarget(c28, _IndeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c28, "Opacity");
									}),
									(Timeline)new DoubleAnimation
									{
										To = 1.0,
										Duration = new Duration(TimeSpan.FromTicks(0L))
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimation c29)
									{
										Storyboard.SetTargetName(c29, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c29, _IndeterminateProgressBarIndicator2Subject);
										Storyboard.SetTargetProperty(c29, "Opacity");
									}),
									(Timeline)new FadeOutThemeAnimation
									{
										TargetName = "DeterminateProgressBarIndicator"
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(FadeOutThemeAnimation c30)
									{
										NameScope.SetNameScope(c30, nameScope);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "IndeterminateError"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c32)
					{
						nameScope.RegisterName("IndeterminateError", c32);
						IndeterminateError = c32;
						MarkupHelper.SetVisualStateLazy(c32, delegate
						{
							c32.Name = "IndeterminateError";
							c32.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(10000000L),
											KeySpline = "0.4, 0.0, 0.6, 1.0"
										}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c33)
										{
											c33.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
											{
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
												Path = "TemplateSettings.ContainerAnimationEndPosition"
											});
										}) }
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c34)
									{
										Storyboard.SetTargetName(c34, "IndeterminateProgressBarIndicator");
										Storyboard.SetTarget(c34, _IndeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c34, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateX)");
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
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(10000000L),
												Value = 0.0
											}
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c37)
									{
										Storyboard.SetTargetProperty(c37, "Opacity");
										Storyboard.SetTargetName(c37, "IndeterminateProgressBarIndicator");
										Storyboard.SetTarget(c37, _IndeterminateProgressBarIndicatorSubject);
									}),
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(10000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c38)
											{
												c38.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationEndPosition2"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(15000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c39)
											{
												c39.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationStartPosition2"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(25000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c40)
											{
												c40.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationMidPosition"
												});
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c41)
									{
										Storyboard.SetTargetName(c41, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c41, _IndeterminateProgressBarIndicator2Subject);
										Storyboard.SetTargetProperty(c41, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateX)");
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
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(10000000L),
												Value = 0.0
											},
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(15100000L),
												Value = 1.0
											},
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(25000000L),
												Value = 1.0
											},
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(30000000L),
												Value = 1.0
											}
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c47)
									{
										Storyboard.SetTargetProperty(c47, "Opacity");
										Storyboard.SetTargetName(c47, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c47, _IndeterminateProgressBarIndicator2Subject);
									}),
									(Timeline)new ColorAnimationUsingKeyFrames
									{
										KeyFrames = new ColorKeyFrameCollection
										{
											new LinearColorKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(27500000L)
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(LinearColorKeyFrame c48)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c48, ColorKeyFrame.ValueProperty, "SystemAccentColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
												_component_0 = c48;
												NameScope.SetNameScope(_component_0, nameScope);
											}),
											new LinearColorKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(30000000L)
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(LinearColorKeyFrame c49)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c49, ColorKeyFrame.ValueProperty, "SystemErrorTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
												_component_1 = c49;
												NameScope.SetNameScope(_component_1, nameScope);
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ColorAnimationUsingKeyFrames c50)
									{
										Storyboard.SetTargetName(c50, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c50, _IndeterminateProgressBarIndicator2Subject);
										Storyboard.SetTargetProperty(c50, "(Windows.UI.Xaml.Shapes:Shape.Fill).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
									}),
									(Timeline)new ColorAnimationUsingKeyFrames
									{
										KeyFrames = new ColorKeyFrameCollection
										{
											new LinearColorKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(27500000L)
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(LinearColorKeyFrame c51)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c51, ColorKeyFrame.ValueProperty, "SystemBaseLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
												_component_2 = c51;
												NameScope.SetNameScope(_component_2, nameScope);
											}),
											new LinearColorKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(30000000L)
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(LinearColorKeyFrame c52)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c52, ColorKeyFrame.ValueProperty, "SystemControlErrorBackgroundColor", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
												_component_3 = c52;
												NameScope.SetNameScope(_component_3, nameScope);
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ColorAnimationUsingKeyFrames c53)
									{
										Storyboard.SetTargetName(c53, "ProgressBarRoot");
										Storyboard.SetTarget(c53, _ProgressBarRootSubject);
										Storyboard.SetTargetProperty(c53, "(Windows.UI.Xaml.Controls:Border.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
									}),
									(Timeline)new FadeOutThemeAnimation
									{
										TargetName = "DeterminateProgressBarIndicator"
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(FadeOutThemeAnimation c54)
									{
										NameScope.SetNameScope(c54, nameScope);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Error"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c55)
					{
						nameScope.RegisterName("Error", c55);
						Error = c55;
						MarkupHelper.SetVisualStateLazy(c55, delegate
						{
							c55.Name = "Error";
							c55.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ColorAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(2500000L))
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ColorAnimation c56)
									{
										Storyboard.SetTargetName(c56, "DeterminateProgressBarIndicator");
										Storyboard.SetTarget(c56, _DeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c56, "(Windows.UI.Xaml.Shapes:Shape.Fill).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
										ResourceResolverSingleton.Instance.ApplyResource(c56, ColorAnimation.ToProperty, "SystemErrorTextColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
										_component_4 = c56;
										NameScope.SetNameScope(_component_4, nameScope);
									}),
									(Timeline)new ColorAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(2500000L))
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ColorAnimation c57)
									{
										Storyboard.SetTargetName(c57, "ProgressBarRoot");
										Storyboard.SetTarget(c57, _ProgressBarRootSubject);
										Storyboard.SetTargetProperty(c57, "(Windows.UI.Xaml.Controls:Border.Background).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
										ResourceResolverSingleton.Instance.ApplyResource(c57, ColorAnimation.ToProperty, "SystemControlErrorBackgroundColor", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
										_component_5 = c57;
										NameScope.SetNameScope(_component_5, nameScope);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "IndeterminatePaused"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c58)
					{
						nameScope.RegisterName("IndeterminatePaused", c58);
						IndeterminatePaused = c58;
						MarkupHelper.SetVisualStateLazy(c58, delegate
						{
							c58.Name = "IndeterminatePaused";
							c58.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = { (DoubleKeyFrame)new SplineDoubleKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(10000000L),
											KeySpline = "0.4, 0.0, 0.6, 1.0"
										}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c59)
										{
											c59.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
											{
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
												Path = "TemplateSettings.ContainerAnimationEndPosition"
											});
										}) }
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c60)
									{
										Storyboard.SetTargetName(c60, "IndeterminateProgressBarIndicator");
										Storyboard.SetTarget(c60, _IndeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c60, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateX)");
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
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(10000000L),
												Value = 0.0
											}
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c63)
									{
										Storyboard.SetTargetProperty(c63, "Opacity");
										Storyboard.SetTargetName(c63, "IndeterminateProgressBarIndicator");
										Storyboard.SetTarget(c63, _IndeterminateProgressBarIndicatorSubject);
									}),
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(10000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c64)
											{
												c64.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationEndPosition2"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(15000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c65)
											{
												c65.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationStartPosition2"
												});
											}),
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(25000000L),
												KeySpline = "0.4, 0.0, 0.6, 1.0"
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(SplineDoubleKeyFrame c66)
											{
												c66.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.ContainerAnimationMidPosition"
												});
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c67)
									{
										Storyboard.SetTargetName(c67, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c67, _IndeterminateProgressBarIndicator2Subject);
										Storyboard.SetTargetProperty(c67, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateX)");
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
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(10000000L),
												Value = 0.0
											},
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(15100000L),
												Value = 1.0
											},
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(25000000L),
												Value = 1.0
											},
											(DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(25100000L)
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DiscreteDoubleKeyFrame c72)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c72, DoubleKeyFrame.ValueProperty, "ProgressBarIndicatorPauseOpacity", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
												_component_6 = c72;
												NameScope.SetNameScope(_component_6, nameScope);
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimationUsingKeyFrames c73)
									{
										Storyboard.SetTargetProperty(c73, "Opacity");
										Storyboard.SetTargetName(c73, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c73, _IndeterminateProgressBarIndicator2Subject);
									}),
									(Timeline)new ColorAnimationUsingKeyFrames
									{
										KeyFrames = new ColorKeyFrameCollection
										{
											new LinearColorKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(25000000L)
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(LinearColorKeyFrame c74)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c74, ColorKeyFrame.ValueProperty, "SystemAccentColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
												_component_7 = c74;
												NameScope.SetNameScope(_component_7, nameScope);
											}),
											new LinearColorKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(27500000L)
											}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(LinearColorKeyFrame c75)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c75, ColorKeyFrame.ValueProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
												_component_8 = c75;
												NameScope.SetNameScope(_component_8, nameScope);
											})
										}
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ColorAnimationUsingKeyFrames c76)
									{
										Storyboard.SetTargetName(c76, "IndeterminateProgressBarIndicator2");
										Storyboard.SetTarget(c76, _IndeterminateProgressBarIndicator2Subject);
										Storyboard.SetTargetProperty(c76, "(Windows.UI.Xaml.Shapes:Shape.Fill).(Windows.UI.Xaml.Media:SolidColorBrush.Color)");
									}),
									(Timeline)new FadeOutThemeAnimation
									{
										TargetName = "DeterminateProgressBarIndicator"
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(FadeOutThemeAnimation c77)
									{
										NameScope.SetNameScope(c77, nameScope);
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Paused"
					}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualState c78)
					{
						nameScope.RegisterName("Paused", c78);
						Paused = c78;
						MarkupHelper.SetVisualStateLazy(c78, delegate
						{
							c78.Name = "Paused";
							c78.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DiscreteObjectKeyFrame c79)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c79, ObjectKeyFrame.ValueProperty, "SystemBaseMediumLowColor", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
											_component_9 = c79;
											NameScope.SetNameScope(_component_9, nameScope);
										}) }
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(ObjectAnimationUsingKeyFrames c80)
									{
										Storyboard.SetTargetName(c80, "DeterminateProgressBarIndicator");
										Storyboard.SetTarget(c80, _DeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c80, "Fill");
									}),
									(Timeline)new DoubleAnimation
									{
										Duration = new Duration(TimeSpan.FromTicks(2500000L))
									}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(DoubleAnimation c81)
									{
										Storyboard.SetTargetName(c81, "DeterminateProgressBarIndicator");
										Storyboard.SetTarget(c81, _DeterminateProgressBarIndicatorSubject);
										Storyboard.SetTargetProperty(c81, "Opacity");
										ResourceResolverSingleton.Instance.ApplyResource(c81, DoubleAnimation.ToProperty, "ProgressBarIndicatorPauseOpacity", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__51.Instance.__ParseContext_);
										_component_10 = c81;
										NameScope.SetNameScope(_component_10, nameScope);
									})
								}
							};
						});
					})
				}
			}.ProgressBar_bab2e69de3222dc04321c485df7cbeee_XamlApply(delegate(VisualStateGroup c82)
			{
				nameScope.RegisterName("CommonStates", c82);
				CommonStates = c82;
			}) });
			c6.CreationComplete();
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

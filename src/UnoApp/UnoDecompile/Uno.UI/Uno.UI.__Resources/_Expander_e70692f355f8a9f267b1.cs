using System;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _Expander_e70692f355f8a9f267b13d41b7df58de_ExpanderRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _Row0Subject = new ElementNameSubject();

	private ElementNameSubject _Row1Subject = new ElementNameSubject();

	private ElementNameSubject _ExpanderHeaderSubject = new ElementNameSubject();

	private ElementNameSubject _ExpanderContentSubject = new ElementNameSubject();

	private ElementNameSubject _ExpanderContentClipSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandUpSubject = new ElementNameSubject();

	private ElementNameSubject _CollapseDownSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandDownSubject = new ElementNameSubject();

	private ElementNameSubject _CollapseUpSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandStatesSubject = new ElementNameSubject();

	private ElementNameSubject _DownSubject = new ElementNameSubject();

	private ElementNameSubject _UpSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandDirectionStatesSubject = new ElementNameSubject();

	private ToggleButton _component_0
	{
		get
		{
			return (ToggleButton)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Border _component_1
	{
		get
		{
			return (Border)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private RowDefinition Row0
	{
		get
		{
			return (RowDefinition)_Row0Subject.ElementInstance;
		}
		set
		{
			_Row0Subject.ElementInstance = value;
		}
	}

	private RowDefinition Row1
	{
		get
		{
			return (RowDefinition)_Row1Subject.ElementInstance;
		}
		set
		{
			_Row1Subject.ElementInstance = value;
		}
	}

	private ToggleButton ExpanderHeader
	{
		get
		{
			return (ToggleButton)_ExpanderHeaderSubject.ElementInstance;
		}
		set
		{
			_ExpanderHeaderSubject.ElementInstance = value;
		}
	}

	private Border ExpanderContent
	{
		get
		{
			return (Border)_ExpanderContentSubject.ElementInstance;
		}
		set
		{
			_ExpanderContentSubject.ElementInstance = value;
		}
	}

	private Border ExpanderContentClip
	{
		get
		{
			return (Border)_ExpanderContentClipSubject.ElementInstance;
		}
		set
		{
			_ExpanderContentClipSubject.ElementInstance = value;
		}
	}

	private VisualState ExpandUp
	{
		get
		{
			return (VisualState)_ExpandUpSubject.ElementInstance;
		}
		set
		{
			_ExpandUpSubject.ElementInstance = value;
		}
	}

	private VisualState CollapseDown
	{
		get
		{
			return (VisualState)_CollapseDownSubject.ElementInstance;
		}
		set
		{
			_CollapseDownSubject.ElementInstance = value;
		}
	}

	private VisualState ExpandDown
	{
		get
		{
			return (VisualState)_ExpandDownSubject.ElementInstance;
		}
		set
		{
			_ExpandDownSubject.ElementInstance = value;
		}
	}

	private VisualState CollapseUp
	{
		get
		{
			return (VisualState)_CollapseUpSubject.ElementInstance;
		}
		set
		{
			_CollapseUpSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ExpandStates
	{
		get
		{
			return (VisualStateGroup)_ExpandStatesSubject.ElementInstance;
		}
		set
		{
			_ExpandStatesSubject.ElementInstance = value;
		}
	}

	private VisualState Down
	{
		get
		{
			return (VisualState)_DownSubject.ElementInstance;
		}
		set
		{
			_DownSubject.ElementInstance = value;
		}
	}

	private VisualState Up
	{
		get
		{
			return (VisualState)_UpSubject.ElementInstance;
		}
		set
		{
			_UpSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ExpandDirectionStates
	{
		get
		{
			return (VisualStateGroup)_ExpandDirectionStatesSubject.ElementInstance;
		}
		set
		{
			_ExpandDirectionStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2563)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(RowDefinition c0)
				{
					nameScope.RegisterName("Row0", c0);
					Row0 = c0;
				}),
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Star)
				}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(RowDefinition c1)
				{
					nameScope.RegisterName("Row1", c1);
					Row1 = c1;
				})
			},
			Children = 
			{
				(UIElement)new ToggleButton
				{
					IsParsing = true,
					Name = "ExpanderHeader",
					HorizontalAlignment = HorizontalAlignment.Stretch
				}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(ToggleButton c2)
				{
					nameScope.RegisterName("ExpanderHeader", c2);
					ExpanderHeader = c2;
					AutomationProperties.SetAutomationId(c2, "ExpanderToggleButton");
					ResourceResolverSingleton.Instance.ApplyResource(c2, FrameworkElement.BackgroundProperty, "ExpanderHeaderBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c2, Control.BorderBrushProperty, "ExpanderHeaderBorderBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c2, Control.BorderThicknessProperty, "ExpanderHeaderBorderThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
					c2.SetBinding(FrameworkElement.MinHeightProperty, new Binding
					{
						Path = "MinHeight",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.SetBinding(Control.IsEnabledProperty, new Binding
					{
						Path = "IsEnabled",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c2, Control.PaddingProperty, "ExpanderHeaderPadding", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c2, FrameworkElement.StyleProperty, "ExpanderHeaderDownStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c2, Control.HorizontalContentAlignmentProperty, "ExpanderHeaderHorizontalContentAlignment", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c2, Control.VerticalContentAlignmentProperty, "ExpanderHeaderVerticalContentAlignment", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
					c2.SetBinding(ContentControl.ContentProperty, new Binding
					{
						Path = "Header",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.SetBinding(ContentControl.ContentTemplateProperty, new Binding
					{
						Path = "HeaderTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.SetBinding(ContentControl.ContentTemplateSelectorProperty, new Binding
					{
						Path = "HeaderTemplateSelector",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c2.SetBinding(ToggleButton.IsCheckedProperty, new Binding
					{
						Path = "IsExpanded",
						Mode = BindingMode.TwoWay,
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c2;
					c2.CreationComplete();
				}),
				(UIElement)new Border
				{
					IsParsing = true,
					Name = "ExpanderContentClip",
					Child = new Border
					{
						IsParsing = true,
						Name = "ExpanderContent",
						Visibility = Visibility.Collapsed,
						HorizontalAlignment = HorizontalAlignment.Stretch,
						VerticalAlignment = VerticalAlignment.Stretch,
						RenderTransform = new CompositeTransform(),
						Child = new ContentPresenter
						{
							IsParsing = true
						}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(ContentPresenter c3)
						{
							c3.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c3.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c3.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
							{
								Path = "ContentTemplateSelector",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c3.SetBinding(ContentPresenter.HorizontalContentAlignmentProperty, new Binding
							{
								Path = "HorizontalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c3.SetBinding(ContentPresenter.VerticalContentAlignmentProperty, new Binding
							{
								Path = "VerticalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c3.CreationComplete();
						})
					}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(Border c4)
					{
						nameScope.RegisterName("ExpanderContent", c4);
						ExpanderContent = c4;
						c4.SetBinding(FrameworkElement.BackgroundProperty, new Binding
						{
							Path = "Background",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c4.SetBinding(Border.BorderBrushProperty, new Binding
						{
							Path = "BorderBrush",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						ResourceResolverSingleton.Instance.ApplyResource(c4, Border.BorderThicknessProperty, "ExpanderContentDownBorderThickness", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_);
						c4.SetBinding(FrameworkElement.MinHeightProperty, new Binding
						{
							Path = "MinHeight",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c4.SetBinding(Border.PaddingProperty, new Binding
						{
							Path = "Padding",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						_component_1 = c4;
						c4.CreationComplete();
					})
				}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(Border c5)
				{
					nameScope.RegisterName("ExpanderContentClip", c5);
					ExpanderContentClip = c5;
					Grid.SetRow(c5, 1);
					c5.CreationComplete();
				})
			}
		}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(Grid c6)
		{
			c6.SetBinding(FrameworkElement.MinWidthProperty, new Binding
			{
				Path = "MinWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c6.SetBinding(FrameworkElement.MaxWidthProperty, new Binding
			{
				Path = "MaxWidth",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c6, new VisualStateGroup[2]
			{
				new VisualStateGroup
				{
					Name = "ExpandStates",
					States = 
					{
						new VisualState
						{
							Name = "ExpandUp"
						}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualState c7)
						{
							nameScope.RegisterName("ExpandUp", c7);
							ExpandUp = c7;
							MarkupHelper.SetVisualStateLazy(c7, delegate
							{
								c7.Name = "ExpandUp";
								c7.Setters.Add(new Setter(new TargetPropertyPath(_ExpanderHeaderSubject, (PropertyPath)"CornerRadius"), null).Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(Setter c8)
								{
									c8.SetBinding("Value", new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("BottomCornerRadiusFilterConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_)
									});
								}));
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
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(ObjectAnimationUsingKeyFrames c10)
										{
											Storyboard.SetTargetName(c10, "ExpanderContent");
											Storyboard.SetTarget(c10, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c10, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(DiscreteDoubleKeyFrame c11)
												{
													c11.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.ContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(3330000L),
													Value = 0.0,
													KeySpline = "0.0, 0.0, 0.0, 1.0"
												}
											}
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(DoubleAnimationUsingKeyFrames c13)
										{
											Storyboard.SetTargetName(c13, "ExpanderContent");
											Storyboard.SetTarget(c13, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c13, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateY)");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "CollapseDown"
						}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualState c14)
						{
							nameScope.RegisterName("CollapseDown", c14);
							CollapseDown = c14;
							MarkupHelper.SetVisualStateLazy(c14, delegate
							{
								c14.Name = "CollapseDown";
								c14.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2000000L),
												Value = "Collapsed"
											} }
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(ObjectAnimationUsingKeyFrames c16)
										{
											Storyboard.SetTargetName(c16, "ExpanderContent");
											Storyboard.SetTarget(c16, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c16, "Visibility");
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
													KeySpline = "1.0, 1.0, 0.0, 1.0"
												}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(SplineDoubleKeyFrame c18)
												{
													c18.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.ContentHeight"
													});
												})
											}
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(DoubleAnimationUsingKeyFrames c19)
										{
											Storyboard.SetTargetName(c19, "ExpanderContent");
											Storyboard.SetTarget(c19, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c19, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateY)");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "ExpandDown"
						}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualState c20)
						{
							nameScope.RegisterName("ExpandDown", c20);
							ExpandDown = c20;
							MarkupHelper.SetVisualStateLazy(c20, delegate
							{
								c20.Name = "ExpandDown";
								c20.Setters.Add(new Setter(new TargetPropertyPath(_ExpanderHeaderSubject, (PropertyPath)"CornerRadius"), null).Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(Setter c21)
								{
									c21.SetBinding("Value", new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopCornerRadiusFilterConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_)
									});
								}));
								c20.Storyboard = new Storyboard
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
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(ObjectAnimationUsingKeyFrames c23)
										{
											Storyboard.SetTargetName(c23, "ExpanderContent");
											Storyboard.SetTarget(c23, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c23, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(DiscreteDoubleKeyFrame c24)
												{
													c24.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.NegativeContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(3330000L),
													Value = 0.0,
													KeySpline = "0.0, 0.0, 0.0, 1.0"
												}
											}
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(DoubleAnimationUsingKeyFrames c26)
										{
											Storyboard.SetTargetName(c26, "ExpanderContent");
											Storyboard.SetTarget(c26, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c26, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateY)");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "CollapseUp"
						}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualState c27)
						{
							nameScope.RegisterName("CollapseUp", c27);
							CollapseUp = c27;
							MarkupHelper.SetVisualStateLazy(c27, delegate
							{
								c27.Name = "CollapseUp";
								c27.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(1670000L),
												Value = "Collapsed"
											} }
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(ObjectAnimationUsingKeyFrames c29)
										{
											Storyboard.SetTargetName(c29, "ExpanderContent");
											Storyboard.SetTarget(c29, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c29, "Visibility");
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
													KeySpline = "1.0, 1.0, 0.0, 1.0"
												}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(SplineDoubleKeyFrame c31)
												{
													c31.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.NegativeContentHeight"
													});
												})
											}
										}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(DoubleAnimationUsingKeyFrames c32)
										{
											Storyboard.SetTargetName(c32, "ExpanderContent");
											Storyboard.SetTarget(c32, _ExpanderContentSubject);
											Storyboard.SetTargetProperty(c32, "(Windows.UI.Xaml:UIElement.RenderTransform).(Windows.UI.Xaml.Media:CompositeTransform.TranslateY)");
										})
									}
								};
							});
						})
					}
				}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualStateGroup c33)
				{
					nameScope.RegisterName("ExpandStates", c33);
					ExpandStates = c33;
				}),
				new VisualStateGroup
				{
					Name = "ExpandDirectionStates",
					States = 
					{
						new VisualState
						{
							Name = "Down"
						}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualState c34)
						{
							nameScope.RegisterName("Down", c34);
							Down = c34;
						}),
						new VisualState
						{
							Name = "Up"
						}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualState c35)
						{
							nameScope.RegisterName("Up", c35);
							Up = c35;
							MarkupHelper.SetVisualStateLazy(c35, delegate
							{
								c35.Name = "Up";
								c35.Setters.Add(new Setter(new TargetPropertyPath(_ExpanderHeaderSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ExpanderHeaderUpStyle", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_)));
								c35.Setters.Add(new Setter(new TargetPropertyPath(_ExpanderContentSubject, (PropertyPath)"BorderThickness"), ResourceResolverSingleton.Instance.ResolveResourceStatic("ExpanderContentUpBorderThickness", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_)));
								c35.Setters.Add(new Setter(new TargetPropertyPath(_ExpanderContentSubject, (PropertyPath)"CornerRadius"), null).Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(Setter c36)
								{
									c36.SetBinding("Value", new Binding
									{
										Path = "CornerRadius",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Converter = (IValueConverter)ResourceResolverSingleton.Instance.ResolveResourceStatic("TopCornerRadiusFilterConverter", typeof(IValueConverter), GlobalStaticResources.ResourceDictionarySingleton__14.Instance.__ParseContext_)
									});
								}));
								c35.Setters.Add(new Setter(new TargetPropertyPath(_ExpanderHeaderSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "1"));
								c35.Setters.Add(new Setter(new TargetPropertyPath(_ExpanderContentClipSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "0"));
								c35.Setters.Add(new Setter(new TargetPropertyPath(_Row0Subject, (PropertyPath)"Height"), "*"));
								c35.Setters.Add(new Setter(new TargetPropertyPath(_Row1Subject, (PropertyPath)"Height"), "Auto"));
							});
						})
					}
				}.Expander_e70692f355f8a9f267b13d41b7df58de_XamlApply(delegate(VisualStateGroup c37)
				{
					nameScope.RegisterName("ExpandDirectionStates", c37);
					ExpandDirectionStates = c37;
				})
			});
			c6.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
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

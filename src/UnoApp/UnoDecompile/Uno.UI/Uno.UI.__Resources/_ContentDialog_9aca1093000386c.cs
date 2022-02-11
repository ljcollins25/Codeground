using System;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _ContentDialog_9aca1093000386c42a23e87b2cc94d76_ContentDialogRDSC0
{
	private class _ContentDialog_9aca1093000386c42a23e87b2cc94d76_UnoUI__Resources_ContentDialog_9aca1093000386c42a23e87b2cc94d76_ContentDialogRDSC0ContentDialogRDSC1
	{
		public UIElement Build(object __ResourceOwner_2505)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new ContentPresenter
			{
				IsParsing = true,
				MaxLines = 2,
				TextWrapping = TextWrapping.Wrap
			}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ContentPresenter c69)
			{
				c69.SetBinding(ContentPresenter.ContentProperty, new Binding
				{
					Path = "Content",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c69.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
				{
					Path = "ContentTemplate",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c69.SetBinding(FrameworkElement.MarginProperty, new Binding
				{
					Path = "Padding",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c69.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
				{
					Path = "ContentTransitions",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c69.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
				{
					Path = "HorizontalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c69.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
				{
					Path = "VerticalContentAlignment",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c69.CreationComplete();
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

	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ScaleTransformSubject = new ElementNameSubject();

	private ElementNameSubject _TitleSubject = new ElementNameSubject();

	private ElementNameSubject _ContentSubject = new ElementNameSubject();

	private ElementNameSubject _ContentScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryButtonSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryButtonSubject = new ElementNameSubject();

	private ElementNameSubject _CloseButtonSubject = new ElementNameSubject();

	private ElementNameSubject _CommandSpaceSubject = new ElementNameSubject();

	private ElementNameSubject _DialogSpaceSubject = new ElementNameSubject();

	private ElementNameSubject _BackgroundElementSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _ContainerSubject = new ElementNameSubject();

	private ElementNameSubject _DialogHiddenSubject = new ElementNameSubject();

	private ElementNameSubject _DialogShowingSubject = new ElementNameSubject();

	private ElementNameSubject _DialogShowingWithoutSmokeLayerSubject = new ElementNameSubject();

	private ElementNameSubject _DialogShowingStatesSubject = new ElementNameSubject();

	private ElementNameSubject _DefaultDialogSizingSubject = new ElementNameSubject();

	private ElementNameSubject _FullDialogSizingSubject = new ElementNameSubject();

	private ElementNameSubject _DialogSizingStatesSubject = new ElementNameSubject();

	private ElementNameSubject _AllVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _NoneVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _CloseVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryAndSecondaryVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryAndCloseVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryAndCloseVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _ButtonsVisibilityStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NoDefaultButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryAsDefaultButtonSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryAsDefaultButtonSubject = new ElementNameSubject();

	private ElementNameSubject _CloseAsDefaultButtonSubject = new ElementNameSubject();

	private ElementNameSubject _DefaultButtonStatesSubject = new ElementNameSubject();

	private ElementNameSubject _NoBorderSubject = new ElementNameSubject();

	private ElementNameSubject _AccentColorBorderSubject = new ElementNameSubject();

	private ElementNameSubject _DialogBorderStatesSubject = new ElementNameSubject();

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

	private ContentPresenter _component_1
	{
		get
		{
			return (ContentPresenter)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private ScrollViewer _component_2
	{
		get
		{
			return (ScrollViewer)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private Grid _component_3
	{
		get
		{
			return (Grid)_component_3_Holder.Instance;
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

	private Border _component_5
	{
		get
		{
			return (Border)_component_5_Holder.Instance;
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

	private ScaleTransform ScaleTransform
	{
		get
		{
			return (ScaleTransform)_ScaleTransformSubject.ElementInstance;
		}
		set
		{
			_ScaleTransformSubject.ElementInstance = value;
		}
	}

	private ContentControl Title
	{
		get
		{
			return (ContentControl)_TitleSubject.ElementInstance;
		}
		set
		{
			_TitleSubject.ElementInstance = value;
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

	private ScrollViewer ContentScrollViewer
	{
		get
		{
			return (ScrollViewer)_ContentScrollViewerSubject.ElementInstance;
		}
		set
		{
			_ContentScrollViewerSubject.ElementInstance = value;
		}
	}

	private Button PrimaryButton
	{
		get
		{
			return (Button)_PrimaryButtonSubject.ElementInstance;
		}
		set
		{
			_PrimaryButtonSubject.ElementInstance = value;
		}
	}

	private Button SecondaryButton
	{
		get
		{
			return (Button)_SecondaryButtonSubject.ElementInstance;
		}
		set
		{
			_SecondaryButtonSubject.ElementInstance = value;
		}
	}

	private Button CloseButton
	{
		get
		{
			return (Button)_CloseButtonSubject.ElementInstance;
		}
		set
		{
			_CloseButtonSubject.ElementInstance = value;
		}
	}

	private Grid CommandSpace
	{
		get
		{
			return (Grid)_CommandSpaceSubject.ElementInstance;
		}
		set
		{
			_CommandSpaceSubject.ElementInstance = value;
		}
	}

	private Grid DialogSpace
	{
		get
		{
			return (Grid)_DialogSpaceSubject.ElementInstance;
		}
		set
		{
			_DialogSpaceSubject.ElementInstance = value;
		}
	}

	private Border BackgroundElement
	{
		get
		{
			return (Border)_BackgroundElementSubject.ElementInstance;
		}
		set
		{
			_BackgroundElementSubject.ElementInstance = value;
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

	private Border Container
	{
		get
		{
			return (Border)_ContainerSubject.ElementInstance;
		}
		set
		{
			_ContainerSubject.ElementInstance = value;
		}
	}

	private VisualState DialogHidden
	{
		get
		{
			return (VisualState)_DialogHiddenSubject.ElementInstance;
		}
		set
		{
			_DialogHiddenSubject.ElementInstance = value;
		}
	}

	private VisualState DialogShowing
	{
		get
		{
			return (VisualState)_DialogShowingSubject.ElementInstance;
		}
		set
		{
			_DialogShowingSubject.ElementInstance = value;
		}
	}

	private VisualState DialogShowingWithoutSmokeLayer
	{
		get
		{
			return (VisualState)_DialogShowingWithoutSmokeLayerSubject.ElementInstance;
		}
		set
		{
			_DialogShowingWithoutSmokeLayerSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DialogShowingStates
	{
		get
		{
			return (VisualStateGroup)_DialogShowingStatesSubject.ElementInstance;
		}
		set
		{
			_DialogShowingStatesSubject.ElementInstance = value;
		}
	}

	private VisualState DefaultDialogSizing
	{
		get
		{
			return (VisualState)_DefaultDialogSizingSubject.ElementInstance;
		}
		set
		{
			_DefaultDialogSizingSubject.ElementInstance = value;
		}
	}

	private VisualState FullDialogSizing
	{
		get
		{
			return (VisualState)_FullDialogSizingSubject.ElementInstance;
		}
		set
		{
			_FullDialogSizingSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DialogSizingStates
	{
		get
		{
			return (VisualStateGroup)_DialogSizingStatesSubject.ElementInstance;
		}
		set
		{
			_DialogSizingStatesSubject.ElementInstance = value;
		}
	}

	private VisualState AllVisible
	{
		get
		{
			return (VisualState)_AllVisibleSubject.ElementInstance;
		}
		set
		{
			_AllVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState NoneVisible
	{
		get
		{
			return (VisualState)_NoneVisibleSubject.ElementInstance;
		}
		set
		{
			_NoneVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState PrimaryVisible
	{
		get
		{
			return (VisualState)_PrimaryVisibleSubject.ElementInstance;
		}
		set
		{
			_PrimaryVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState SecondaryVisible
	{
		get
		{
			return (VisualState)_SecondaryVisibleSubject.ElementInstance;
		}
		set
		{
			_SecondaryVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState CloseVisible
	{
		get
		{
			return (VisualState)_CloseVisibleSubject.ElementInstance;
		}
		set
		{
			_CloseVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState PrimaryAndSecondaryVisible
	{
		get
		{
			return (VisualState)_PrimaryAndSecondaryVisibleSubject.ElementInstance;
		}
		set
		{
			_PrimaryAndSecondaryVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState PrimaryAndCloseVisible
	{
		get
		{
			return (VisualState)_PrimaryAndCloseVisibleSubject.ElementInstance;
		}
		set
		{
			_PrimaryAndCloseVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState SecondaryAndCloseVisible
	{
		get
		{
			return (VisualState)_SecondaryAndCloseVisibleSubject.ElementInstance;
		}
		set
		{
			_SecondaryAndCloseVisibleSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ButtonsVisibilityStates
	{
		get
		{
			return (VisualStateGroup)_ButtonsVisibilityStatesSubject.ElementInstance;
		}
		set
		{
			_ButtonsVisibilityStatesSubject.ElementInstance = value;
		}
	}

	private VisualState NoDefaultButton
	{
		get
		{
			return (VisualState)_NoDefaultButtonSubject.ElementInstance;
		}
		set
		{
			_NoDefaultButtonSubject.ElementInstance = value;
		}
	}

	private VisualState PrimaryAsDefaultButton
	{
		get
		{
			return (VisualState)_PrimaryAsDefaultButtonSubject.ElementInstance;
		}
		set
		{
			_PrimaryAsDefaultButtonSubject.ElementInstance = value;
		}
	}

	private VisualState SecondaryAsDefaultButton
	{
		get
		{
			return (VisualState)_SecondaryAsDefaultButtonSubject.ElementInstance;
		}
		set
		{
			_SecondaryAsDefaultButtonSubject.ElementInstance = value;
		}
	}

	private VisualState CloseAsDefaultButton
	{
		get
		{
			return (VisualState)_CloseAsDefaultButtonSubject.ElementInstance;
		}
		set
		{
			_CloseAsDefaultButtonSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DefaultButtonStates
	{
		get
		{
			return (VisualStateGroup)_DefaultButtonStatesSubject.ElementInstance;
		}
		set
		{
			_DefaultButtonStatesSubject.ElementInstance = value;
		}
	}

	private VisualState NoBorder
	{
		get
		{
			return (VisualState)_NoBorderSubject.ElementInstance;
		}
		set
		{
			_NoBorderSubject.ElementInstance = value;
		}
	}

	private VisualState AccentColorBorder
	{
		get
		{
			return (VisualState)_AccentColorBorderSubject.ElementInstance;
		}
		set
		{
			_AccentColorBorderSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DialogBorderStates
	{
		get
		{
			return (VisualStateGroup)_DialogBorderStatesSubject.ElementInstance;
		}
		set
		{
			_DialogBorderStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2497)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Name = "Container",
			Child = new Grid
			{
				IsParsing = true,
				Name = "LayoutRoot",
				Visibility = Visibility.Collapsed,
				Children = { (UIElement)new Border
				{
					IsParsing = true,
					Name = "BackgroundElement",
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center,
					RenderTransformOrigin = new Point(0.5, 0.5),
					RenderTransform = new ScaleTransform().ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ScaleTransform c0)
					{
						nameScope.RegisterName("ScaleTransform", c0);
						ScaleTransform = c0;
					}),
					Child = new Grid
					{
						IsParsing = true,
						Name = "DialogSpace",
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
							(UIElement)new ScrollViewer
							{
								IsParsing = true,
								Name = "ContentScrollViewer",
								IsTabStop = false,
								Content = new Grid
								{
									IsParsing = true,
									RowDefinitions = 
									{
										new RowDefinition
										{
											Height = new GridLength(1.0, GridUnitType.Auto)
										},
										new RowDefinition
										{
											Height = new GridLength(1.0, GridUnitType.Star)
										}
									},
									Children = 
									{
										(UIElement)new ContentControl
										{
											IsParsing = true,
											Name = "Title",
											FontSize = 20.0,
											FontFamily = new FontFamily("XamlAutoFontFamily"),
											FontWeight = FontWeights.Normal,
											HorizontalAlignment = HorizontalAlignment.Left,
											VerticalAlignment = VerticalAlignment.Top,
											IsTabStop = false,
											Template = new ControlTemplate(__ResourceOwner_2497, (object? __owner) => new _ContentDialog_9aca1093000386c42a23e87b2cc94d76_UnoUI__Resources_ContentDialog_9aca1093000386c42a23e87b2cc94d76_ContentDialogRDSC0ContentDialogRDSC1().Build(__owner))
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ContentControl c5)
										{
											nameScope.RegisterName("Title", c5);
											Title = c5;
											ResourceResolverSingleton.Instance.ApplyResource(c5, FrameworkElement.MarginProperty, "ContentDialogTitleMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
											c5.SetBinding(ContentControl.ContentProperty, new Binding
											{
												Path = "Title",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c5.SetBinding(ContentControl.ContentTemplateProperty, new Binding
											{
												Path = "TitleTemplate",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c5.SetBinding(Control.ForegroundProperty, new Binding
											{
												Path = "Foreground",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											_component_0 = c5;
											c5.CreationComplete();
										}),
										(UIElement)new ContentPresenter
										{
											IsParsing = true,
											Name = "Content",
											TextWrapping = TextWrapping.Wrap
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ContentPresenter c6)
										{
											nameScope.RegisterName("Content", c6);
											Content = c6;
											c6.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
											{
												Path = "ContentTemplate",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c6.SetBinding(ContentPresenter.ContentProperty, new Binding
											{
												Path = "Content",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											ResourceResolverSingleton.Instance.ApplyResource(c6, ContentPresenter.FontSizeProperty, "ControlContentThemeFontSize", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c6, ContentPresenter.FontFamilyProperty, "ContentControlThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
											ResourceResolverSingleton.Instance.ApplyResource(c6, FrameworkElement.MarginProperty, "ContentDialogContentMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
											c6.SetBinding(ContentPresenter.ForegroundProperty, new Binding
											{
												Path = "Foreground",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											Grid.SetRow(c6, 1);
											_component_1 = c6;
											c6.CreationComplete();
										})
									}
								}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Grid c7)
								{
									c7.CreationComplete();
								})
							}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ScrollViewer c8)
							{
								nameScope.RegisterName("ContentScrollViewer", c8);
								ContentScrollViewer = c8;
								ScrollViewer.SetHorizontalScrollBarVisibility(c8, ScrollBarVisibility.Disabled);
								ScrollViewer.SetVerticalScrollBarVisibility(c8, ScrollBarVisibility.Disabled);
								ScrollViewer.SetZoomMode(c8, ZoomMode.Disabled);
								ResourceResolverSingleton.Instance.ApplyResource(c8, FrameworkElement.MarginProperty, "ContentDialogContentScrollViewerMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
								_component_2 = c8;
								c8.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "CommandSpace",
								HorizontalAlignment = HorizontalAlignment.Stretch,
								VerticalAlignment = VerticalAlignment.Bottom,
								XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled,
								ColumnDefinitions = 
								{
									new ColumnDefinition(),
									new ColumnDefinition
									{
										Width = new GridLength(0.5, GridUnitType.Star)
									},
									new ColumnDefinition
									{
										Width = new GridLength(0.5, GridUnitType.Star)
									},
									new ColumnDefinition()
								},
								Children = 
								{
									(UIElement)new Button
									{
										IsParsing = true,
										Name = "PrimaryButton",
										ElementSoundMode = ElementSoundMode.FocusOnly,
										HorizontalAlignment = HorizontalAlignment.Stretch,
										VerticalAlignment = VerticalAlignment.Stretch,
										Margin = new Thickness(0.0, 0.0, 2.0, 0.0)
									}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Button c11)
									{
										nameScope.RegisterName("PrimaryButton", c11);
										PrimaryButton = c11;
										c11.SetBinding(ContentControl.ContentProperty, new Binding
										{
											Path = "PrimaryButtonText",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c11.SetBinding(Control.IsEnabledProperty, new Binding
										{
											Path = "IsPrimaryButtonEnabled",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c11.SetBinding(FrameworkElement.StyleProperty, new Binding
										{
											Path = "PrimaryButtonStyle",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										Grid.SetColumn(c11, 0);
										c11.CreationComplete();
									}),
									(UIElement)new Button
									{
										IsParsing = true,
										Name = "SecondaryButton",
										ElementSoundMode = ElementSoundMode.FocusOnly,
										HorizontalAlignment = HorizontalAlignment.Stretch,
										VerticalAlignment = VerticalAlignment.Stretch,
										Margin = new Thickness(2.0, 0.0, 2.0, 0.0)
									}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Button c12)
									{
										nameScope.RegisterName("SecondaryButton", c12);
										SecondaryButton = c12;
										c12.SetBinding(ContentControl.ContentProperty, new Binding
										{
											Path = "SecondaryButtonText",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c12.SetBinding(Control.IsEnabledProperty, new Binding
										{
											Path = "IsSecondaryButtonEnabled",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c12.SetBinding(FrameworkElement.StyleProperty, new Binding
										{
											Path = "SecondaryButtonStyle",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										Grid.SetColumn(c12, 1);
										Grid.SetColumnSpan(c12, 2);
										c12.CreationComplete();
									}),
									(UIElement)new Button
									{
										IsParsing = true,
										Name = "CloseButton",
										ElementSoundMode = ElementSoundMode.FocusOnly,
										HorizontalAlignment = HorizontalAlignment.Stretch,
										VerticalAlignment = VerticalAlignment.Stretch,
										Margin = new Thickness(2.0, 0.0, 0.0, 0.0)
									}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Button c13)
									{
										nameScope.RegisterName("CloseButton", c13);
										CloseButton = c13;
										c13.SetBinding(ContentControl.ContentProperty, new Binding
										{
											Path = "CloseButtonText",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										c13.SetBinding(FrameworkElement.StyleProperty, new Binding
										{
											Path = "CloseButtonStyle",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										Grid.SetColumn(c13, 3);
										c13.CreationComplete();
									})
								}
							}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Grid c14)
							{
								nameScope.RegisterName("CommandSpace", c14);
								CommandSpace = c14;
								Grid.SetRow(c14, 1);
								ResourceResolverSingleton.Instance.ApplyResource(c14, FrameworkElement.MarginProperty, "ContentDialogCommandSpaceMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
								_component_3 = c14;
								c14.CreationComplete();
							})
						}
					}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Grid c15)
					{
						nameScope.RegisterName("DialogSpace", c15);
						DialogSpace = c15;
						ResourceResolverSingleton.Instance.ApplyResource(c15, Grid.PaddingProperty, "ContentDialogPadding", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
						_component_4 = c15;
						c15.CreationComplete();
					})
				}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Border c16)
				{
					nameScope.RegisterName("BackgroundElement", c16);
					BackgroundElement = c16;
					c16.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c16.SetBinding(FrameworkElement.FlowDirectionProperty, new Binding
					{
						Path = "FlowDirection",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c16, Border.BorderThicknessProperty, "ContentDialogBorderWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
					c16.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "BorderBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c16.SetBinding(Border.CornerRadiusProperty, new Binding
					{
						Path = "CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c16, FrameworkElement.MinWidthProperty, "ContentDialogMinWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c16, FrameworkElement.MaxWidthProperty, "ContentDialogMaxWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c16, FrameworkElement.MinHeightProperty, "ContentDialogMinHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c16, FrameworkElement.MaxHeightProperty, "ContentDialogMaxHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
					_component_5 = c16;
					c16.CreationComplete();
				}) }
			}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Grid c17)
			{
				nameScope.RegisterName("LayoutRoot", c17);
				LayoutRoot = c17;
				ResourceResolverSingleton.Instance.ApplyResource(c17, FrameworkElement.BackgroundProperty, "SystemControlPageBackgroundMediumAltMediumBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_);
				_component_6 = c17;
				c17.CreationComplete();
			})
		}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(Border c18)
		{
			nameScope.RegisterName("Container", c18);
			Container = c18;
			VisualStateManager.SetVisualStateGroups(c18, new VisualStateGroup[5]
			{
				new VisualStateGroup
				{
					Name = "DialogShowingStates",
					Transitions = 
					{
						new VisualTransition
						{
							To = "DialogHidden"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualTransition c19)
						{
							MarkupHelper.SetVisualTransitionLazy(c19, delegate
							{
								c19.Storyboard = new Storyboard
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
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ObjectAnimationUsingKeyFrames c21)
										{
											Storyboard.SetTargetName(c21, "LayoutRoot");
											Storyboard.SetTarget(c21, _LayoutRootSubject);
											Storyboard.SetTargetProperty(c21, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ObjectAnimationUsingKeyFrames c23)
										{
											Storyboard.SetTargetName(c23, "LayoutRoot");
											Storyboard.SetTarget(c23, _LayoutRootSubject);
											Storyboard.SetTargetProperty(c23, "IsHitTestVisible");
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
													KeyTime = TimeSpan.FromTicks(5000000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 1.05
												}
											}
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(DoubleAnimationUsingKeyFrames c26)
										{
											Storyboard.SetTargetName(c26, "ScaleTransform");
											Storyboard.SetTarget(c26, _ScaleTransformSubject);
											Storyboard.SetTargetProperty(c26, "ScaleX");
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
													KeyTime = TimeSpan.FromTicks(5000000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 1.05
												}
											}
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(DoubleAnimationUsingKeyFrames c29)
										{
											Storyboard.SetTargetName(c29, "ScaleTransform");
											Storyboard.SetTarget(c29, _ScaleTransformSubject);
											Storyboard.SetTargetProperty(c29, "ScaleY");
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
												(DoubleKeyFrame)new LinearDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(830000L),
													Value = 0.0
												}
											}
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(DoubleAnimationUsingKeyFrames c32)
										{
											Storyboard.SetTargetName(c32, "LayoutRoot");
											Storyboard.SetTarget(c32, _LayoutRootSubject);
											Storyboard.SetTargetProperty(c32, "Opacity");
										})
									}
								};
							});
						}),
						new VisualTransition
						{
							To = "DialogShowing"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualTransition c33)
						{
							MarkupHelper.SetVisualTransitionLazy(c33, delegate
							{
								c33.Storyboard = new Storyboard
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
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(ObjectAnimationUsingKeyFrames c35)
										{
											Storyboard.SetTargetName(c35, "LayoutRoot");
											Storyboard.SetTarget(c35, _LayoutRootSubject);
											Storyboard.SetTargetProperty(c35, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 1.05
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(5000000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 1.0
												}
											}
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(DoubleAnimationUsingKeyFrames c38)
										{
											Storyboard.SetTargetName(c38, "ScaleTransform");
											Storyboard.SetTarget(c38, _ScaleTransformSubject);
											Storyboard.SetTargetProperty(c38, "ScaleX");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L),
													Value = 1.05
												},
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(5000000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 1.0
												}
											}
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(DoubleAnimationUsingKeyFrames c41)
										{
											Storyboard.SetTargetName(c41, "ScaleTransform");
											Storyboard.SetTarget(c41, _ScaleTransformSubject);
											Storyboard.SetTargetProperty(c41, "ScaleY");
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
												(DoubleKeyFrame)new LinearDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													Value = 1.0
												}
											}
										}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(DoubleAnimationUsingKeyFrames c44)
										{
											Storyboard.SetTargetName(c44, "LayoutRoot");
											Storyboard.SetTarget(c44, _LayoutRootSubject);
											Storyboard.SetTargetProperty(c44, "Opacity");
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
							Name = "DialogHidden"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c45)
						{
							nameScope.RegisterName("DialogHidden", c45);
							DialogHidden = c45;
						}),
						new VisualState
						{
							Name = "DialogShowing"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c46)
						{
							nameScope.RegisterName("DialogShowing", c46);
							DialogShowing = c46;
							MarkupHelper.SetVisualStateLazy(c46, delegate
							{
								c46.Name = "DialogShowing";
								c46.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Visibility"), "Visible"));
								c46.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundElementSubject, (PropertyPath)"TabFocusNavigation"), "Cycle"));
							});
						}),
						new VisualState
						{
							Name = "DialogShowingWithoutSmokeLayer"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c47)
						{
							nameScope.RegisterName("DialogShowingWithoutSmokeLayer", c47);
							DialogShowingWithoutSmokeLayer = c47;
							MarkupHelper.SetVisualStateLazy(c47, delegate
							{
								c47.Name = "DialogShowingWithoutSmokeLayer";
								c47.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Visibility"), "Visible"));
								c47.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Background"), null));
							});
						})
					}
				}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualStateGroup c48)
				{
					nameScope.RegisterName("DialogShowingStates", c48);
					DialogShowingStates = c48;
				}),
				new VisualStateGroup
				{
					Name = "DialogSizingStates",
					States = 
					{
						new VisualState
						{
							Name = "DefaultDialogSizing"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c49)
						{
							nameScope.RegisterName("DefaultDialogSizing", c49);
							DefaultDialogSizing = c49;
						}),
						new VisualState
						{
							Name = "FullDialogSizing"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c50)
						{
							nameScope.RegisterName("FullDialogSizing", c50);
							FullDialogSizing = c50;
							MarkupHelper.SetVisualStateLazy(c50, delegate
							{
								c50.Name = "FullDialogSizing";
								c50.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundElementSubject, (PropertyPath)"VerticalAlignment"), "Stretch"));
							});
						})
					}
				}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualStateGroup c51)
				{
					nameScope.RegisterName("DialogSizingStates", c51);
					DialogSizingStates = c51;
				}),
				new VisualStateGroup
				{
					Name = "ButtonsVisibilityStates",
					States = 
					{
						new VisualState
						{
							Name = "AllVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c52)
						{
							nameScope.RegisterName("AllVisible", c52);
							AllVisible = c52;
						}),
						new VisualState
						{
							Name = "NoneVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c53)
						{
							nameScope.RegisterName("NoneVisible", c53);
							NoneVisible = c53;
							MarkupHelper.SetVisualStateLazy(c53, delegate
							{
								c53.Name = "NoneVisible";
								c53.Setters.Add(new Setter(new TargetPropertyPath(_CommandSpaceSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "PrimaryVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c54)
						{
							nameScope.RegisterName("PrimaryVisible", c54);
							PrimaryVisible = c54;
							MarkupHelper.SetVisualStateLazy(c54, delegate
							{
								c54.Name = "PrimaryVisible";
								c54.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "2"));
								c54.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c54.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Margin"), "2,0,0,0"));
								c54.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c54.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "SecondaryVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c55)
						{
							nameScope.RegisterName("SecondaryVisible", c55);
							SecondaryVisible = c55;
							MarkupHelper.SetVisualStateLazy(c55, delegate
							{
								c55.Name = "SecondaryVisible";
								c55.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "2"));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Margin"), "2,0,0,0"));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c55.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "CloseVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c56)
						{
							nameScope.RegisterName("CloseVisible", c56);
							CloseVisible = c56;
							MarkupHelper.SetVisualStateLazy(c56, delegate
							{
								c56.Name = "CloseVisible";
								c56.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "2"));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Margin"), "2,0,0,0"));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c56.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "PrimaryAndSecondaryVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c57)
						{
							nameScope.RegisterName("PrimaryAndSecondaryVisible", c57);
							PrimaryAndSecondaryVisible = c57;
							MarkupHelper.SetVisualStateLazy(c57, delegate
							{
								c57.Name = "PrimaryAndSecondaryVisible";
								c57.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "2"));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Margin"), "2,0,0,0"));
								c57.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "PrimaryAndCloseVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c58)
						{
							nameScope.RegisterName("PrimaryAndCloseVisible", c58);
							PrimaryAndCloseVisible = c58;
							MarkupHelper.SetVisualStateLazy(c58, delegate
							{
								c58.Name = "PrimaryAndCloseVisible";
								c58.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "2"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Margin"), "2,0,0,0"));
								c58.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						}),
						new VisualState
						{
							Name = "SecondaryAndCloseVisible"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c59)
						{
							nameScope.RegisterName("SecondaryAndCloseVisible", c59);
							SecondaryAndCloseVisible = c59;
							MarkupHelper.SetVisualStateLazy(c59, delegate
							{
								c59.Name = "SecondaryAndCloseVisible";
								c59.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Margin"), "0,0,2,0"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "2"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.ColumnSpan)"), "2"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Margin"), "2,0,0,0"));
								c59.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualStateGroup c60)
				{
					nameScope.RegisterName("ButtonsVisibilityStates", c60);
					ButtonsVisibilityStates = c60;
				}),
				new VisualStateGroup
				{
					Name = "DefaultButtonStates",
					States = 
					{
						new VisualState
						{
							Name = "NoDefaultButton"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c61)
						{
							nameScope.RegisterName("NoDefaultButton", c61);
							NoDefaultButton = c61;
						}),
						new VisualState
						{
							Name = "PrimaryAsDefaultButton"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c62)
						{
							nameScope.RegisterName("PrimaryAsDefaultButton", c62);
							PrimaryAsDefaultButton = c62;
							MarkupHelper.SetVisualStateLazy(c62, delegate
							{
								c62.Name = "PrimaryAsDefaultButton";
								c62.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryButtonSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AccentButtonStyle", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_)));
							});
						}),
						new VisualState
						{
							Name = "SecondaryAsDefaultButton"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c63)
						{
							nameScope.RegisterName("SecondaryAsDefaultButton", c63);
							SecondaryAsDefaultButton = c63;
							MarkupHelper.SetVisualStateLazy(c63, delegate
							{
								c63.Name = "SecondaryAsDefaultButton";
								c63.Setters.Add(new Setter(new TargetPropertyPath(_SecondaryButtonSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AccentButtonStyle", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_)));
							});
						}),
						new VisualState
						{
							Name = "CloseAsDefaultButton"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c64)
						{
							nameScope.RegisterName("CloseAsDefaultButton", c64);
							CloseAsDefaultButton = c64;
							MarkupHelper.SetVisualStateLazy(c64, delegate
							{
								c64.Name = "CloseAsDefaultButton";
								c64.Setters.Add(new Setter(new TargetPropertyPath(_CloseButtonSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("AccentButtonStyle", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_)));
							});
						})
					}
				}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualStateGroup c65)
				{
					nameScope.RegisterName("DefaultButtonStates", c65);
					DefaultButtonStates = c65;
				}),
				new VisualStateGroup
				{
					Name = "DialogBorderStates",
					States = 
					{
						new VisualState
						{
							Name = "NoBorder"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c66)
						{
							nameScope.RegisterName("NoBorder", c66);
							NoBorder = c66;
						}),
						new VisualState
						{
							Name = "AccentColorBorder"
						}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualState c67)
						{
							nameScope.RegisterName("AccentColorBorder", c67);
							AccentColorBorder = c67;
							MarkupHelper.SetVisualStateLazy(c67, delegate
							{
								c67.Name = "AccentColorBorder";
								c67.Setters.Add(new Setter(new TargetPropertyPath(_BackgroundElementSubject, (PropertyPath)"BorderBrush"), ResourceResolverSingleton.Instance.ResolveResourceStatic("SystemControlForegroundAccentBrush", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("SystemControlForegroundAccentBrush", GlobalStaticResources.ResourceDictionarySingleton__8.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.ContentDialog_9aca1093000386c42a23e87b2cc94d76_XamlApply(delegate(VisualStateGroup c68)
				{
					nameScope.RegisterName("DialogBorderStates", c68);
					DialogBorderStates = c68;
				})
			});
			c18.CreationComplete();
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

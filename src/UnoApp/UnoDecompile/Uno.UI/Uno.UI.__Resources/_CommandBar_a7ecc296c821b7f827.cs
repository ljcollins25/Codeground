using System;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _CommandBar_a7ecc296c821b7f827e9c7e18c482393_CommandBarRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

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

	public UIElement Build(object __ResourceOwner_1565)
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
			}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ContentPresenter c0)
			{
				nameScope.RegisterName("ContentPresenter", c0);
				ContentPresenter = c0;
				c0.SetBinding(FrameworkElement.BackgroundProperty, new Binding
				{
					Path = "Background",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
				{
					Path = "BorderBrush",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
				{
					Path = "BorderThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c0.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
				{
					Path = "ContentTransitions",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
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
				c0.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding
				{
					Path = "ContentTemplateSelector",
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
				c0.CreationComplete();
			}) }
		}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Grid c1)
		{
			VisualStateManager.SetVisualStateGroups(c1, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c2)
					{
						nameScope.RegisterName("Normal", c2);
						Normal = c2;
					}),
					new VisualState
					{
						Name = "PointerOver"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c3)
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c4)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c4, ObjectKeyFrame.ValueProperty, "SystemControlHighlightListLowBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
											_component_0 = c4;
											NameScope.SetNameScope(_component_0, nameScope);
										}) }
									}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c5)
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c6)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c6, ObjectKeyFrame.ValueProperty, "SystemControlHighlightAltBaseHighBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
											_component_1 = c6;
											NameScope.SetNameScope(_component_1, nameScope);
										}) }
									}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c7)
									{
										Storyboard.SetTargetName(c7, "ContentPresenter");
										Storyboard.SetTarget(c7, _ContentPresenterSubject);
										Storyboard.SetTargetProperty(c7, "Foreground");
									})
								}
							};
						});
					}),
					new VisualState
					{
						Name = "Pressed"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c8)
					{
						nameScope.RegisterName("Pressed", c8);
						Pressed = c8;
						MarkupHelper.SetVisualStateLazy(c8, delegate
						{
							c8.Name = "Pressed";
							c8.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c9)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c9, ObjectKeyFrame.ValueProperty, "SystemControlHighlightListMediumBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
										_component_2 = c9;
										NameScope.SetNameScope(_component_2, nameScope);
									}) }
								}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c10)
								{
									Storyboard.SetTargetName(c10, "ContentPresenter");
									Storyboard.SetTarget(c10, _ContentPresenterSubject);
									Storyboard.SetTargetProperty(c10, "Background");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "Disabled"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c11)
					{
						nameScope.RegisterName("Disabled", c11);
						Disabled = c11;
						MarkupHelper.SetVisualStateLazy(c11, delegate
						{
							c11.Name = "Disabled";
							c11.Storyboard = new Storyboard
							{
								Children = { (Timeline)new ObjectAnimationUsingKeyFrames
								{
									KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
									{
										KeyTime = TimeSpan.FromTicks(0L)
									}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c12)
									{
										ResourceResolverSingleton.Instance.ApplyResource(c12, ObjectKeyFrame.ValueProperty, "SystemControlDisabledBaseMediumLowBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
										_component_3 = c12;
										NameScope.SetNameScope(_component_3, nameScope);
									}) }
								}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c13)
								{
									Storyboard.SetTargetName(c13, "ContentPresenter");
									Storyboard.SetTarget(c13, _ContentPresenterSubject);
									Storyboard.SetTargetProperty(c13, "Foreground");
								}) }
							};
						});
					})
				}
			}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualStateGroup c14)
			{
				nameScope.RegisterName("CommonStates", c14);
				CommonStates = c14;
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
internal class _CommandBar_a7ecc296c821b7f827e9c7e18c482393_CommandBarRDSC1
{
	private class _CommandBar_a7ecc296c821b7f827e9c7e18c482393_UnoUI__Resources_CommandBar_a7ecc296c821b7f827e9c7e18c482393_CommandBarRDSC1CommandBarRDSC3
	{
		public UIElement Build(object __ResourceOwner_2198)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new StackPanel
			{
				IsParsing = true,
				Orientation = Orientation.Horizontal
			}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(StackPanel c426)
			{
				c426.CreationComplete();
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

	private ComponentHolder _component_7_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_8_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_9_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_10_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_11_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_12_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_13_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_14_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_15_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ClipGeometryTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ContentTransformSubject = new ElementNameSubject();

	private ElementNameSubject _ContentControlColumnDefinitionSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryItemsControlColumnDefinitionSubject = new ElementNameSubject();

	private ElementNameSubject _ContentControlSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryItemsControlSubject = new ElementNameSubject();

	private ElementNameSubject _EllipsisIconSubject = new ElementNameSubject();

	private ElementNameSubject _MoreButtonSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowPopupOffsetTransformSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowContentRootClipSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowContentRootTransformSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowContentTransformSubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryItemsControlSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowPopupSubject = new ElementNameSubject();

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

	private ElementNameSubject _BothCommandsSubject = new ElementNameSubject();

	private ElementNameSubject _PrimaryCommandsOnlySubject = new ElementNameSubject();

	private ElementNameSubject _SecondaryCommandsOnlySubject = new ElementNameSubject();

	private ElementNameSubject _AvailableCommandsStatesSubject = new ElementNameSubject();

	private ElementNameSubject _DynamicOverflowDisabledSubject = new ElementNameSubject();

	private ElementNameSubject _DynamicOverflowEnabledSubject = new ElementNameSubject();

	private ElementNameSubject _DynamicOverflowStatesSubject = new ElementNameSubject();

	private ItemsControl _component_0
	{
		get
		{
			return (ItemsControl)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Button _component_1
	{
		get
		{
			return (Button)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Rectangle _component_2
	{
		get
		{
			return (Rectangle)_component_2_Holder.Instance;
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

	private DiscreteDoubleKeyFrame _component_5
	{
		get
		{
			return (DiscreteDoubleKeyFrame)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private SplineDoubleKeyFrame _component_6
	{
		get
		{
			return (SplineDoubleKeyFrame)_component_6_Holder.Instance;
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

	private DiscreteDoubleKeyFrame _component_10
	{
		get
		{
			return (DiscreteDoubleKeyFrame)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_11
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private SplineDoubleKeyFrame _component_12
	{
		get
		{
			return (SplineDoubleKeyFrame)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_13
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_14
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_14_Holder.Instance;
		}
		set
		{
			_component_14_Holder.Instance = value;
		}
	}

	private DiscreteObjectKeyFrame _component_15
	{
		get
		{
			return (DiscreteObjectKeyFrame)_component_15_Holder.Instance;
		}
		set
		{
			_component_15_Holder.Instance = value;
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

	private ColumnDefinition ContentControlColumnDefinition
	{
		get
		{
			return (ColumnDefinition)_ContentControlColumnDefinitionSubject.ElementInstance;
		}
		set
		{
			_ContentControlColumnDefinitionSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition PrimaryItemsControlColumnDefinition
	{
		get
		{
			return (ColumnDefinition)_PrimaryItemsControlColumnDefinitionSubject.ElementInstance;
		}
		set
		{
			_PrimaryItemsControlColumnDefinitionSubject.ElementInstance = value;
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

	private ItemsControl PrimaryItemsControl
	{
		get
		{
			return (ItemsControl)_PrimaryItemsControlSubject.ElementInstance;
		}
		set
		{
			_PrimaryItemsControlSubject.ElementInstance = value;
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

	private Button MoreButton
	{
		get
		{
			return (Button)_MoreButtonSubject.ElementInstance;
		}
		set
		{
			_MoreButtonSubject.ElementInstance = value;
		}
	}

	private TranslateTransform OverflowPopupOffsetTransform
	{
		get
		{
			return (TranslateTransform)_OverflowPopupOffsetTransformSubject.ElementInstance;
		}
		set
		{
			_OverflowPopupOffsetTransformSubject.ElementInstance = value;
		}
	}

	private RectangleGeometry OverflowContentRootClip
	{
		get
		{
			return (RectangleGeometry)_OverflowContentRootClipSubject.ElementInstance;
		}
		set
		{
			_OverflowContentRootClipSubject.ElementInstance = value;
		}
	}

	private TranslateTransform OverflowContentRootTransform
	{
		get
		{
			return (TranslateTransform)_OverflowContentRootTransformSubject.ElementInstance;
		}
		set
		{
			_OverflowContentRootTransformSubject.ElementInstance = value;
		}
	}

	private TranslateTransform OverflowContentTransform
	{
		get
		{
			return (TranslateTransform)_OverflowContentTransformSubject.ElementInstance;
		}
		set
		{
			_OverflowContentTransformSubject.ElementInstance = value;
		}
	}

	private CommandBarOverflowPresenter SecondaryItemsControl
	{
		get
		{
			return (CommandBarOverflowPresenter)_SecondaryItemsControlSubject.ElementInstance;
		}
		set
		{
			_SecondaryItemsControlSubject.ElementInstance = value;
		}
	}

	private Grid OverflowContentRoot
	{
		get
		{
			return (Grid)_OverflowContentRootSubject.ElementInstance;
		}
		set
		{
			_OverflowContentRootSubject.ElementInstance = value;
		}
	}

	private Popup OverflowPopup
	{
		get
		{
			return (Popup)_OverflowPopupSubject.ElementInstance;
		}
		set
		{
			_OverflowPopupSubject.ElementInstance = value;
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

	private VisualState BothCommands
	{
		get
		{
			return (VisualState)_BothCommandsSubject.ElementInstance;
		}
		set
		{
			_BothCommandsSubject.ElementInstance = value;
		}
	}

	private VisualState PrimaryCommandsOnly
	{
		get
		{
			return (VisualState)_PrimaryCommandsOnlySubject.ElementInstance;
		}
		set
		{
			_PrimaryCommandsOnlySubject.ElementInstance = value;
		}
	}

	private VisualState SecondaryCommandsOnly
	{
		get
		{
			return (VisualState)_SecondaryCommandsOnlySubject.ElementInstance;
		}
		set
		{
			_SecondaryCommandsOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup AvailableCommandsStates
	{
		get
		{
			return (VisualStateGroup)_AvailableCommandsStatesSubject.ElementInstance;
		}
		set
		{
			_AvailableCommandsStatesSubject.ElementInstance = value;
		}
	}

	private VisualState DynamicOverflowDisabled
	{
		get
		{
			return (VisualState)_DynamicOverflowDisabledSubject.ElementInstance;
		}
		set
		{
			_DynamicOverflowDisabledSubject.ElementInstance = value;
		}
	}

	private VisualState DynamicOverflowEnabled
	{
		get
		{
			return (VisualState)_DynamicOverflowEnabledSubject.ElementInstance;
		}
		set
		{
			_DynamicOverflowEnabledSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DynamicOverflowStates
	{
		get
		{
			return (VisualStateGroup)_DynamicOverflowStatesSubject.ElementInstance;
		}
		set
		{
			_DynamicOverflowStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1626)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		Grid grid = new Grid();
		grid.IsParsing = true;
		object key = "OverlayOpeningAnimation";
		grid.Resources[key] = new Storyboard
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
			}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c17)
			{
				Storyboard.SetTargetProperty(c17, "Opacity");
			}) }
		};
		object key2 = "OverlayClosingAnimation";
		grid.Resources[key2] = new Storyboard
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
			}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c20)
			{
				Storyboard.SetTargetProperty(c20, "Opacity");
			}) }
		};
		grid.Name = "LayoutRoot";
		grid.Clip = new RectangleGeometry
		{
			Transform = new TranslateTransform().CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(TranslateTransform c21)
			{
				nameScope.RegisterName("ClipGeometryTransform", c21);
				ClipGeometryTransform = c21;
				c21.SetBinding(TranslateTransform.YProperty, new Binding
				{
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
					Path = "TemplateSettings.CompactVerticalDelta"
				});
			})
		}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(RectangleGeometry c22)
		{
			c22.SetBinding(RectangleGeometry.RectProperty, new Binding
			{
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
				Path = "TemplateSettings.ClipRect"
			});
		});
		grid.Children.Add(new Grid
		{
			IsParsing = true,
			Name = "ContentRoot",
			VerticalAlignment = VerticalAlignment.Top,
			XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled,
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
			RenderTransform = new TranslateTransform().CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(TranslateTransform c25)
			{
				nameScope.RegisterName("ContentTransform", c25);
				ContentTransform = c25;
			}),
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					ColumnDefinitions = 
					{
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Star)
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ColumnDefinition c26)
						{
							nameScope.RegisterName("ContentControlColumnDefinition", c26);
							ContentControlColumnDefinition = c26;
						}),
						new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Auto)
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ColumnDefinition c27)
						{
							nameScope.RegisterName("PrimaryItemsControlColumnDefinition", c27);
							PrimaryItemsControlColumnDefinition = c27;
						})
					},
					Children = 
					{
						(UIElement)new ContentControl
						{
							IsParsing = true,
							Name = "ContentControl",
							IsTabStop = false
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ContentControl c28)
						{
							nameScope.RegisterName("ContentControl", c28);
							ContentControl = c28;
							c28.SetBinding(ContentControl.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.SetBinding(ContentControl.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.SetBinding(ContentControl.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.SetBinding(Control.ForegroundProperty, new Binding
							{
								Path = "Foreground",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
							{
								Path = "HorizontalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
							{
								Path = "VerticalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.SetBinding(Control.HorizontalContentAlignmentProperty, new Binding
							{
								Path = "HorizontalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.SetBinding(Control.VerticalContentAlignmentProperty, new Binding
							{
								Path = "VerticalContentAlignment",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c28.CreationComplete();
						}),
						(UIElement)new ItemsControl
						{
							IsParsing = true,
							Name = "PrimaryItemsControl",
							HorizontalAlignment = HorizontalAlignment.Right,
							IsTabStop = false,
							ItemsPanel = new ItemsPanelTemplate(__ResourceOwner_1626, (object? __owner) => new _CommandBar_a7ecc296c821b7f827e9c7e18c482393_UnoUI__Resources_CommandBar_a7ecc296c821b7f827e9c7e18c482393_CommandBarRDSC1CommandBarRDSC3().Build(__owner))
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ItemsControl c29)
						{
							nameScope.RegisterName("PrimaryItemsControl", c29);
							PrimaryItemsControl = c29;
							ResourceResolverSingleton.Instance.ApplyResource(c29, FrameworkElement.MinHeightProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
							Grid.SetColumn(c29, 1);
							_component_0 = c29;
							c29.CreationComplete();
						})
					}
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Grid c30)
				{
					c30.CreationComplete();
				}),
				(UIElement)new Button
				{
					IsParsing = true,
					Name = "MoreButton",
					VerticalAlignment = VerticalAlignment.Top,
					IsAccessKeyScope = true,
					Content = new FontIcon
					{
						IsParsing = true,
						Name = "EllipsisIcon",
						VerticalAlignment = VerticalAlignment.Center,
						FontSize = 16.0,
						Glyph = "\ue10c"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(FontIcon c31)
					{
						nameScope.RegisterName("EllipsisIcon", c31);
						EllipsisIcon = c31;
						c31.CreationComplete();
					})
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Button c32)
				{
					nameScope.RegisterName("MoreButton", c32);
					MoreButton = c32;
					c32.SetBinding(Control.ForegroundProperty, new Binding
					{
						Path = "Foreground",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c32, FrameworkElement.StyleProperty, "XamlDefaultCommandBar_EllipsisButton", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c32, Control.PaddingProperty, "CommandBarMoreButtonMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c32, FrameworkElement.MinHeightProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
					Grid.SetColumn(c32, 1);
					Control.SetIsTemplateKeyTipTarget(c32, value: true);
					c32.SetBinding(UIElement.VisibilityProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "CommandBarTemplateSettings.EffectiveOverflowButtonVisibility"
					});
					_component_1 = c32;
					c32.CreationComplete();
				}),
				(UIElement)new Popup
				{
					IsParsing = true,
					Name = "OverflowPopup",
					IsTabStop = false,
					RenderTransform = new TranslateTransform().CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(TranslateTransform c33)
					{
						nameScope.RegisterName("OverflowPopupOffsetTransform", c33);
						OverflowPopupOffsetTransform = c33;
					}),
					Child = new Grid
					{
						IsParsing = true,
						Name = "OverflowContentRoot",
						Clip = new RectangleGeometry().CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(RectangleGeometry c34)
						{
							nameScope.RegisterName("OverflowContentRootClip", c34);
							OverflowContentRootClip = c34;
						}),
						RenderTransform = new TranslateTransform().CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(TranslateTransform c35)
						{
							nameScope.RegisterName("OverflowContentRootTransform", c35);
							OverflowContentRootTransform = c35;
							c35.SetBinding(TranslateTransform.XProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "CommandBarTemplateSettings.OverflowContentHorizontalOffset"
							});
						}),
						Children = { (UIElement)new CommandBarOverflowPresenter
						{
							IsParsing = true,
							Name = "SecondaryItemsControl",
							IsTabStop = false,
							RenderTransform = new TranslateTransform().CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(TranslateTransform c36)
							{
								nameScope.RegisterName("OverflowContentTransform", c36);
								OverflowContentTransform = c36;
							}),
							ItemContainerStyle = new Style(typeof(FrameworkElement))
							{
								Setters = 
								{
									(SetterBase)new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch),
									(SetterBase)new Setter(FrameworkElement.WidthProperty, double.NaN)
								}
							}
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(CommandBarOverflowPresenter c37)
						{
							nameScope.RegisterName("SecondaryItemsControl", c37);
							SecondaryItemsControl = c37;
							c37.SetBinding(FrameworkElement.StyleProperty, new Binding
							{
								Path = "CommandBarOverflowPresenterStyle",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c37.CreationComplete();
						}) }
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Grid c38)
					{
						nameScope.RegisterName("OverflowContentRoot", c38);
						OverflowContentRoot = c38;
						c38.SetBinding(FrameworkElement.MinWidthProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "CommandBarTemplateSettings.OverflowContentMinWidth"
						});
						c38.SetBinding(FrameworkElement.MaxWidthProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "CommandBarTemplateSettings.OverflowContentMaxWidth"
						});
						c38.SetBinding(FrameworkElement.MaxHeightProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "CommandBarTemplateSettings.OverflowContentMaxHeight"
						});
						c38.CreationComplete();
					})
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Popup c39)
				{
					nameScope.RegisterName("OverflowPopup", c39);
					OverflowPopup = c39;
					c39.CreationComplete();
				}),
				(UIElement)new ElementStub(() => new Rectangle
				{
					IsParsing = true,
					Name = "HighContrastBorder",
					IsHitTestVisible = false,
					Visibility = Visibility.Collapsed,
					VerticalAlignment = VerticalAlignment.Stretch,
					StrokeThickness = 1.0
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Rectangle c40)
				{
					nameScope.RegisterName("HighContrastBorder", c40);
					HighContrastBorder = c40;
					Grid.SetColumnSpan(c40, 2);
					ResourceResolverSingleton.Instance.ApplyResource(c40, Shape.StrokeProperty, "CommandBarHighContrastBorder", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
					_component_2 = c40;
					c40.CreationComplete();
				})).CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ElementStub c41)
				{
					c41.Name = "HighContrastBorder";
					_HighContrastBorderSubject.ElementInstance = c41;
					c41.Visibility = Visibility.Collapsed;
				})
			}
		}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Grid c42)
		{
			nameScope.RegisterName("ContentRoot", c42);
			ContentRoot = c42;
			c42.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c42.SetBinding(FrameworkElement.HeightProperty, new Binding
			{
				Path = "Height",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c42, FrameworkElement.MinHeightProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
			c42.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			_component_3 = c42;
			c42.CreationComplete();
		}));
		uIElement = grid.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Grid c43)
		{
			nameScope.RegisterName("LayoutRoot", c43);
			LayoutRoot = c43;
			VisualStateManager.SetVisualStateGroups(c43, new VisualStateGroup[4]
			{
				new VisualStateGroup
				{
					Name = "CommonStates",
					States = 
					{
						new VisualState
						{
							Name = "Normal"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c44)
						{
							nameScope.RegisterName("Normal", c44);
							Normal = c44;
						}),
						new VisualState
						{
							Name = "Disabled"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c45)
						{
							nameScope.RegisterName("Disabled", c45);
							Disabled = c45;
							MarkupHelper.SetVisualStateLazy(c45, delegate
							{
								c45.Name = "Disabled";
								c45.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L)
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c46)
										{
											ResourceResolverSingleton.Instance.ApplyResource(c46, ObjectKeyFrame.ValueProperty, "CommandBarEllipsisIconForegroundDisabled", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
											_component_4 = c46;
											NameScope.SetNameScope(_component_4, nameScope);
										}) }
									}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c47)
									{
										Storyboard.SetTargetName(c47, "EllipsisIcon");
										Storyboard.SetTarget(c47, _EllipsisIconSubject);
										Storyboard.SetTargetProperty(c47, "Foreground");
									}) }
								};
							});
						})
					}
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualStateGroup c48)
				{
					nameScope.RegisterName("CommonStates", c48);
					CommonStates = c48;
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c49)
						{
							MarkupHelper.SetVisualTransitionLazy(c49, delegate
							{
								c49.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c51)
										{
											Storyboard.SetTargetName(c51, "MoreButton");
											Storyboard.SetTarget(c51, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c51, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c53)
										{
											Storyboard.SetTargetName(c53, "HighContrastBorder");
											Storyboard.SetTarget(c53, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c53, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c54)
											{
												c54.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c55)
										{
											Storyboard.SetTargetName(c55, "OverflowContentRootClip");
											Storyboard.SetTarget(c55, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c55, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c56)
											{
												c56.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c57)
										{
											Storyboard.SetTargetName(c57, "OverflowContentRootTransform");
											Storyboard.SetTarget(c57, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c57, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c59)
										{
											Storyboard.SetTargetName(c59, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c59, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c59, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c61)
												{
													c61.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.CompactVerticalDelta"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c62)
										{
											Storyboard.SetTargetName(c62, "ContentTransform");
											Storyboard.SetTarget(c62, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c62, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c63)
												{
													c63.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.OverflowContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c65)
										{
											Storyboard.SetTargetName(c65, "OverflowContentTransform");
											Storyboard.SetTarget(c65, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c65, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c66)
						{
							MarkupHelper.SetVisualTransitionLazy(c66, delegate
							{
								c66.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c68)
										{
											Storyboard.SetTargetName(c68, "MoreButton");
											Storyboard.SetTarget(c68, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c68, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c70)
										{
											Storyboard.SetTargetName(c70, "HighContrastBorder");
											Storyboard.SetTarget(c70, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c70, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c71)
											{
												c71.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c72)
										{
											Storyboard.SetTargetName(c72, "OverflowContentRootClip");
											Storyboard.SetTarget(c72, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c72, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c73)
											{
												c73.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c74)
										{
											Storyboard.SetTargetName(c74, "OverflowContentRootTransform");
											Storyboard.SetTarget(c74, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c74, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c76)
										{
											Storyboard.SetTargetName(c76, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c76, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c76, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c77)
												{
													c77.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c79)
										{
											Storyboard.SetTargetName(c79, "ContentTransform");
											Storyboard.SetTarget(c79, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c79, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c81)
												{
													c81.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.OverflowContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c82)
										{
											Storyboard.SetTargetName(c82, "OverflowContentTransform");
											Storyboard.SetTarget(c82, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c82, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c83)
						{
							MarkupHelper.SetVisualTransitionLazy(c83, delegate
							{
								c83.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c85)
										{
											Storyboard.SetTargetName(c85, "MoreButton");
											Storyboard.SetTarget(c85, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c85, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c87)
										{
											Storyboard.SetTargetName(c87, "HighContrastBorder");
											Storyboard.SetTarget(c87, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c87, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c88)
											{
												c88.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c89)
										{
											Storyboard.SetTargetName(c89, "OverflowContentRootClip");
											Storyboard.SetTarget(c89, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c89, "Rect");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "-1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c91)
										{
											Storyboard.SetTargetName(c91, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c91, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c91, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c92)
												{
													c92.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c94)
										{
											Storyboard.SetTargetName(c94, "ClipGeometryTransform");
											Storyboard.SetTarget(c94, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c94, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c95)
												{
													ResourceResolverSingleton.Instance.ApplyResource(c95, DoubleKeyFrame.ValueProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
													_component_5 = c95;
													NameScope.SetNameScope(_component_5, nameScope);
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0"
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c96)
												{
													c96.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.ContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c97)
										{
											Storyboard.SetTargetName(c97, "OverflowContentRootTransform");
											Storyboard.SetTarget(c97, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c97, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c98)
												{
													c98.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c100)
										{
											Storyboard.SetTargetName(c100, "OverflowContentTransform");
											Storyboard.SetTarget(c100, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c100, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c101)
						{
							MarkupHelper.SetVisualTransitionLazy(c101, delegate
							{
								c101.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c103)
										{
											Storyboard.SetTargetName(c103, "MoreButton");
											Storyboard.SetTarget(c103, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c103, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c105)
										{
											Storyboard.SetTargetName(c105, "HighContrastBorder");
											Storyboard.SetTarget(c105, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c105, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c106)
											{
												c106.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c107)
										{
											Storyboard.SetTargetName(c107, "OverflowContentRootClip");
											Storyboard.SetTarget(c107, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c107, "Rect");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "-1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c109)
										{
											Storyboard.SetTargetName(c109, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c109, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c109, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c111)
												{
													c111.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.CompactVerticalDelta"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c112)
										{
											Storyboard.SetTargetName(c112, "ClipGeometryTransform");
											Storyboard.SetTarget(c112, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c112, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c113)
												{
													c113.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.ContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1"
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c114)
												{
													ResourceResolverSingleton.Instance.ApplyResource(c114, DoubleKeyFrame.ValueProperty, "AppBarThemeCompactHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
													_component_6 = c114;
													NameScope.SetNameScope(_component_6, nameScope);
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c115)
										{
											Storyboard.SetTargetName(c115, "OverflowContentRootTransform");
											Storyboard.SetTarget(c115, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c115, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c117)
												{
													c117.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c118)
										{
											Storyboard.SetTargetName(c118, "OverflowContentTransform");
											Storyboard.SetTarget(c118, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c118, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c119)
						{
							MarkupHelper.SetVisualTransitionLazy(c119, delegate
							{
								c119.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c121)
										{
											Storyboard.SetTargetName(c121, "MoreButton");
											Storyboard.SetTarget(c121, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c121, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c122)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c122, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
												_component_7 = c122;
												NameScope.SetNameScope(_component_7, nameScope);
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c123)
										{
											Storyboard.SetTargetName(c123, "MoreButton");
											Storyboard.SetTarget(c123, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c123, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c125)
										{
											Storyboard.SetTargetName(c125, "MoreButton");
											Storyboard.SetTarget(c125, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c125, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c127)
										{
											Storyboard.SetTargetName(c127, "HighContrastBorder");
											Storyboard.SetTarget(c127, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c127, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c128)
											{
												c128.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c129)
										{
											Storyboard.SetTargetName(c129, "ClipGeometryTransform");
											Storyboard.SetTarget(c129, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c129, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c130)
											{
												c130.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c131)
										{
											Storyboard.SetTargetName(c131, "OverflowContentRootClip");
											Storyboard.SetTarget(c131, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c131, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c132)
											{
												c132.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c133)
										{
											Storyboard.SetTargetName(c133, "OverflowContentRootTransform");
											Storyboard.SetTarget(c133, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c133, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c135)
										{
											Storyboard.SetTargetName(c135, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c135, _OverflowPopupOffsetTransformSubject);
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
													KeySpline = "0.1,0.9 0.2,1.0"
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c137)
												{
													c137.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.MinimalVerticalDelta"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c138)
										{
											Storyboard.SetTargetName(c138, "ContentTransform");
											Storyboard.SetTarget(c138, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c138, "Y");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c141)
										{
											Storyboard.SetTargetName(c141, "ContentControl");
											Storyboard.SetTarget(c141, _ContentControlSubject);
											Storyboard.SetTargetProperty(c141, "Opacity");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c144)
										{
											Storyboard.SetTargetName(c144, "PrimaryItemsControl");
											Storyboard.SetTarget(c144, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c144, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c145)
												{
													c145.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.OverflowContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c147)
										{
											Storyboard.SetTargetName(c147, "OverflowContentTransform");
											Storyboard.SetTarget(c147, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c147, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c148)
						{
							MarkupHelper.SetVisualTransitionLazy(c148, delegate
							{
								c148.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c150)
										{
											Storyboard.SetTargetName(c150, "MoreButton");
											Storyboard.SetTarget(c150, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c150, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c151)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c151, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
												_component_8 = c151;
												NameScope.SetNameScope(_component_8, nameScope);
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c152)
										{
											Storyboard.SetTargetName(c152, "MoreButton");
											Storyboard.SetTarget(c152, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c152, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c154)
										{
											Storyboard.SetTargetName(c154, "MoreButton");
											Storyboard.SetTarget(c154, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c154, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c156)
										{
											Storyboard.SetTargetName(c156, "HighContrastBorder");
											Storyboard.SetTarget(c156, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c156, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c157)
											{
												c157.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c158)
										{
											Storyboard.SetTargetName(c158, "ClipGeometryTransform");
											Storyboard.SetTarget(c158, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c158, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c159)
											{
												c159.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c160)
										{
											Storyboard.SetTargetName(c160, "OverflowContentRootClip");
											Storyboard.SetTarget(c160, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c160, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c161)
											{
												c161.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c162)
										{
											Storyboard.SetTargetName(c162, "OverflowContentRootTransform");
											Storyboard.SetTarget(c162, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c162, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c164)
										{
											Storyboard.SetTargetName(c164, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c164, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c164, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c165)
												{
													c165.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c167)
										{
											Storyboard.SetTargetName(c167, "ContentTransform");
											Storyboard.SetTarget(c167, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c167, "Y");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c170)
										{
											Storyboard.SetTargetName(c170, "ContentControl");
											Storyboard.SetTarget(c170, _ContentControlSubject);
											Storyboard.SetTargetProperty(c170, "Opacity");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c173)
										{
											Storyboard.SetTargetName(c173, "PrimaryItemsControl");
											Storyboard.SetTarget(c173, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c173, "Opacity");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c175)
												{
													c175.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.OverflowContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c176)
										{
											Storyboard.SetTargetName(c176, "OverflowContentTransform");
											Storyboard.SetTarget(c176, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c176, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c177)
						{
							MarkupHelper.SetVisualTransitionLazy(c177, delegate
							{
								c177.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c179)
										{
											Storyboard.SetTargetName(c179, "MoreButton");
											Storyboard.SetTarget(c179, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c179, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c180)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c180, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
												_component_9 = c180;
												NameScope.SetNameScope(_component_9, nameScope);
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c181)
										{
											Storyboard.SetTargetName(c181, "MoreButton");
											Storyboard.SetTarget(c181, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c181, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c183)
										{
											Storyboard.SetTargetName(c183, "MoreButton");
											Storyboard.SetTarget(c183, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c183, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c185)
										{
											Storyboard.SetTargetName(c185, "HighContrastBorder");
											Storyboard.SetTarget(c185, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c185, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c186)
											{
												c186.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c187)
										{
											Storyboard.SetTargetName(c187, "OverflowContentRootClip");
											Storyboard.SetTarget(c187, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c187, "Rect");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "-1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c189)
										{
											Storyboard.SetTargetName(c189, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c189, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c189, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c190)
												{
													c190.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c192)
										{
											Storyboard.SetTargetName(c192, "ClipGeometryTransform");
											Storyboard.SetTarget(c192, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c192, "Y");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c195)
										{
											Storyboard.SetTargetName(c195, "ContentControl");
											Storyboard.SetTarget(c195, _ContentControlSubject);
											Storyboard.SetTargetProperty(c195, "Opacity");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c198)
										{
											Storyboard.SetTargetName(c198, "PrimaryItemsControl");
											Storyboard.SetTarget(c198, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c198, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c199)
												{
													ResourceResolverSingleton.Instance.ApplyResource(c199, DoubleKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
													_component_10 = c199;
													NameScope.SetNameScope(_component_10, nameScope);
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0"
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c200)
												{
													c200.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.ContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c201)
										{
											Storyboard.SetTargetName(c201, "OverflowContentRootTransform");
											Storyboard.SetTarget(c201, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c201, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c202)
												{
													c202.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c204)
										{
											Storyboard.SetTargetName(c204, "OverflowContentTransform");
											Storyboard.SetTarget(c204, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c204, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c205)
						{
							MarkupHelper.SetVisualTransitionLazy(c205, delegate
							{
								c205.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c207)
										{
											Storyboard.SetTargetName(c207, "MoreButton");
											Storyboard.SetTarget(c207, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c207, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c208)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c208, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
												_component_11 = c208;
												NameScope.SetNameScope(_component_11, nameScope);
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c209)
										{
											Storyboard.SetTargetName(c209, "MoreButton");
											Storyboard.SetTarget(c209, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c209, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c211)
										{
											Storyboard.SetTargetName(c211, "MoreButton");
											Storyboard.SetTarget(c211, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c211, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c213)
										{
											Storyboard.SetTargetName(c213, "HighContrastBorder");
											Storyboard.SetTarget(c213, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c213, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c214)
											{
												c214.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c215)
										{
											Storyboard.SetTargetName(c215, "OverflowContentRootClip");
											Storyboard.SetTarget(c215, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c215, "Rect");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "-1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c217)
										{
											Storyboard.SetTargetName(c217, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c217, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c217, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c219)
												{
													c219.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.MinimalVerticalDelta"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c220)
										{
											Storyboard.SetTargetName(c220, "ClipGeometryTransform");
											Storyboard.SetTarget(c220, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c220, "Y");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c223)
										{
											Storyboard.SetTargetName(c223, "ContentControl");
											Storyboard.SetTarget(c223, _ContentControlSubject);
											Storyboard.SetTargetProperty(c223, "Opacity");
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c226)
										{
											Storyboard.SetTargetName(c226, "PrimaryItemsControl");
											Storyboard.SetTarget(c226, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c226, "Opacity");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c227)
												{
													c227.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.ContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1"
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c228)
												{
													ResourceResolverSingleton.Instance.ApplyResource(c228, DoubleKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
													_component_12 = c228;
													NameScope.SetNameScope(_component_12, nameScope);
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c229)
										{
											Storyboard.SetTargetName(c229, "OverflowContentRootTransform");
											Storyboard.SetTarget(c229, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c229, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c231)
												{
													c231.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c232)
										{
											Storyboard.SetTargetName(c232, "OverflowContentTransform");
											Storyboard.SetTarget(c232, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c232, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c233)
						{
							MarkupHelper.SetVisualTransitionLazy(c233, delegate
							{
								c233.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c235)
										{
											Storyboard.SetTargetName(c235, "MoreButton");
											Storyboard.SetTarget(c235, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c235, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c237)
										{
											Storyboard.SetTargetName(c237, "HighContrastBorder");
											Storyboard.SetTarget(c237, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c237, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c238)
											{
												c238.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c239)
										{
											Storyboard.SetTargetName(c239, "ClipGeometryTransform");
											Storyboard.SetTarget(c239, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c239, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c240)
											{
												c240.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c241)
										{
											Storyboard.SetTargetName(c241, "OverflowContentRootClip");
											Storyboard.SetTarget(c241, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c241, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c242)
											{
												c242.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c243)
										{
											Storyboard.SetTargetName(c243, "OverflowContentRootTransform");
											Storyboard.SetTarget(c243, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c243, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c245)
										{
											Storyboard.SetTargetName(c245, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c245, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c245, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c247)
												{
													c247.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.HiddenVerticalDelta"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c248)
										{
											Storyboard.SetTargetName(c248, "ContentTransform");
											Storyboard.SetTarget(c248, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c248, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c249)
												{
													c249.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.OverflowContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c251)
										{
											Storyboard.SetTargetName(c251, "OverflowContentTransform");
											Storyboard.SetTarget(c251, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c251, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c252)
						{
							MarkupHelper.SetVisualTransitionLazy(c252, delegate
							{
								c252.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c254)
										{
											Storyboard.SetTargetName(c254, "MoreButton");
											Storyboard.SetTarget(c254, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c254, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c256)
										{
											Storyboard.SetTargetName(c256, "HighContrastBorder");
											Storyboard.SetTarget(c256, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c256, "Visibility");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c257)
											{
												c257.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c258)
										{
											Storyboard.SetTargetName(c258, "ClipGeometryTransform");
											Storyboard.SetTarget(c258, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c258, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c259)
											{
												c259.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c260)
										{
											Storyboard.SetTargetName(c260, "OverflowContentRootClip");
											Storyboard.SetTarget(c260, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c260, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c261)
											{
												c261.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c262)
										{
											Storyboard.SetTargetName(c262, "OverflowContentRootTransform");
											Storyboard.SetTarget(c262, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c262, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c264)
										{
											Storyboard.SetTargetName(c264, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c264, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c264, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c265)
												{
													c265.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.HiddenVerticalDelta"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c267)
										{
											Storyboard.SetTargetName(c267, "ContentTransform");
											Storyboard.SetTarget(c267, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c267, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c269)
												{
													c269.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.OverflowContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c270)
										{
											Storyboard.SetTargetName(c270, "OverflowContentTransform");
											Storyboard.SetTarget(c270, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c270, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c271)
						{
							MarkupHelper.SetVisualTransitionLazy(c271, delegate
							{
								c271.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c273)
										{
											Storyboard.SetTargetName(c273, "MoreButton");
											Storyboard.SetTarget(c273, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c273, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c275)
										{
											Storyboard.SetTargetName(c275, "HighContrastBorder");
											Storyboard.SetTarget(c275, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c275, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c276)
											{
												c276.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c277)
										{
											Storyboard.SetTargetName(c277, "OverflowContentRootClip");
											Storyboard.SetTarget(c277, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c277, "Rect");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "-1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c279)
										{
											Storyboard.SetTargetName(c279, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c279, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c279, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c280)
												{
													c280.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c282)
										{
											Storyboard.SetTargetName(c282, "ClipGeometryTransform");
											Storyboard.SetTarget(c282, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c282, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c284)
												{
													c284.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.ContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c285)
										{
											Storyboard.SetTargetName(c285, "OverflowContentRootTransform");
											Storyboard.SetTarget(c285, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c285, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c286)
												{
													c286.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(4670000L),
													KeySpline = "0.1,0.9 0.2,1.0",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c288)
										{
											Storyboard.SetTargetName(c288, "OverflowContentTransform");
											Storyboard.SetTarget(c288, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c288, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualTransition c289)
						{
							MarkupHelper.SetVisualTransitionLazy(c289, delegate
							{
								c289.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c291)
										{
											Storyboard.SetTargetName(c291, "MoreButton");
											Storyboard.SetTarget(c291, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c291, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c293)
										{
											Storyboard.SetTargetName(c293, "HighContrastBorder");
											Storyboard.SetTarget(c293, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c293, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c294)
											{
												c294.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c295)
										{
											Storyboard.SetTargetName(c295, "OverflowContentRootClip");
											Storyboard.SetTarget(c295, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c295, "Rect");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "-1"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c297)
										{
											Storyboard.SetTargetName(c297, "OverflowPopupOffsetTransform");
											Storyboard.SetTarget(c297, _OverflowPopupOffsetTransformSubject);
											Storyboard.SetTargetProperty(c297, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c299)
												{
													c299.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "TemplateSettings.HiddenVerticalDelta"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c300)
										{
											Storyboard.SetTargetName(c300, "ClipGeometryTransform");
											Storyboard.SetTarget(c300, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c300, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = 
											{
												(DoubleKeyFrame)new DiscreteDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(0L)
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c301)
												{
													c301.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.ContentHeight"
													});
												}),
												(DoubleKeyFrame)new SplineDoubleKeyFrame
												{
													KeyTime = TimeSpan.FromTicks(1670000L),
													KeySpline = "0.2,0 0,1",
													Value = 0.0
												}
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c303)
										{
											Storyboard.SetTargetName(c303, "OverflowContentRootTransform");
											Storyboard.SetTarget(c303, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c303, "Y");
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
												}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(SplineDoubleKeyFrame c305)
												{
													c305.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
													{
														RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
														Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
													});
												})
											}
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c306)
										{
											Storyboard.SetTargetName(c306, "OverflowContentTransform");
											Storyboard.SetTarget(c306, _OverflowContentTransformSubject);
											Storyboard.SetTargetProperty(c306, "Y");
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
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c307)
						{
							nameScope.RegisterName("CompactClosed", c307);
							CompactClosed = c307;
						}),
						new VisualState
						{
							Name = "CompactOpenUp"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c308)
						{
							nameScope.RegisterName("CompactOpenUp", c308);
							CompactOpenUp = c308;
							MarkupHelper.SetVisualStateLazy(c308, delegate
							{
								c308.Name = "CompactOpenUp";
								c308.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c309)
											{
												c309.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.CompactVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c310)
										{
											Storyboard.SetTargetName(c310, "ContentTransform");
											Storyboard.SetTarget(c310, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c310, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c312)
										{
											Storyboard.SetTargetName(c312, "MoreButton");
											Storyboard.SetTarget(c312, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c312, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c314)
										{
											Storyboard.SetTargetName(c314, "HighContrastBorder");
											Storyboard.SetTarget(c314, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c314, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c315)
											{
												c315.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c316)
										{
											Storyboard.SetTargetName(c316, "OverflowContentRootClip");
											Storyboard.SetTarget(c316, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c316, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c317)
											{
												c317.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c318)
										{
											Storyboard.SetTargetName(c318, "OverflowContentRootTransform");
											Storyboard.SetTarget(c318, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c318, "Y");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "CompactOpenDown"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c319)
						{
							nameScope.RegisterName("CompactOpenDown", c319);
							CompactOpenDown = c319;
							MarkupHelper.SetVisualStateLazy(c319, delegate
							{
								c319.Name = "CompactOpenDown";
								c319.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c321)
										{
											Storyboard.SetTargetName(c321, "ClipGeometryTransform");
											Storyboard.SetTarget(c321, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c321, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c323)
										{
											Storyboard.SetTargetName(c323, "MoreButton");
											Storyboard.SetTarget(c323, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c323, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c325)
										{
											Storyboard.SetTargetName(c325, "HighContrastBorder");
											Storyboard.SetTarget(c325, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c325, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c326)
											{
												c326.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c327)
										{
											Storyboard.SetTargetName(c327, "OverflowContentRootClip");
											Storyboard.SetTarget(c327, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c327, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c328)
											{
												c328.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.ContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c329)
										{
											Storyboard.SetTargetName(c329, "OverflowContentRootTransform");
											Storyboard.SetTarget(c329, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c329, "Y");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MinimalClosed"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c330)
						{
							nameScope.RegisterName("MinimalClosed", c330);
							MinimalClosed = c330;
							MarkupHelper.SetVisualStateLazy(c330, delegate
							{
								c330.Name = "MinimalClosed";
								c330.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c331)
											{
												c331.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c332)
										{
											Storyboard.SetTargetName(c332, "ClipGeometryTransform");
											Storyboard.SetTarget(c332, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c332, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c334)
										{
											Storyboard.SetTargetName(c334, "ContentControl");
											Storyboard.SetTarget(c334, _ContentControlSubject);
											Storyboard.SetTargetProperty(c334, "IsHitTestVisible");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c336)
										{
											Storyboard.SetTargetName(c336, "ContentControl");
											Storyboard.SetTarget(c336, _ContentControlSubject);
											Storyboard.SetTargetProperty(c336, "IsEnabled");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c338)
										{
											Storyboard.SetTargetName(c338, "ContentControl");
											Storyboard.SetTarget(c338, _ContentControlSubject);
											Storyboard.SetTargetProperty(c338, "Opacity");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c340)
										{
											Storyboard.SetTargetName(c340, "MoreButton");
											Storyboard.SetTarget(c340, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c340, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c341)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c341, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
												_component_13 = c341;
												NameScope.SetNameScope(_component_13, nameScope);
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c342)
										{
											Storyboard.SetTargetName(c342, "MoreButton");
											Storyboard.SetTarget(c342, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c342, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c344)
										{
											Storyboard.SetTargetName(c344, "PrimaryItemsControl");
											Storyboard.SetTarget(c344, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c344, "IsHitTestVisible");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c346)
										{
											Storyboard.SetTargetName(c346, "PrimaryItemsControl");
											Storyboard.SetTarget(c346, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c346, "IsEnabled");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c348)
										{
											Storyboard.SetTargetName(c348, "PrimaryItemsControl");
											Storyboard.SetTarget(c348, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c348, "Opacity");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MinimalOpenUp"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c349)
						{
							nameScope.RegisterName("MinimalOpenUp", c349);
							MinimalOpenUp = c349;
							MarkupHelper.SetVisualStateLazy(c349, delegate
							{
								c349.Name = "MinimalOpenUp";
								c349.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c350)
											{
												c350.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c351)
										{
											Storyboard.SetTargetName(c351, "ClipGeometryTransform");
											Storyboard.SetTarget(c351, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c351, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c352)
											{
												c352.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.MinimalVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c353)
										{
											Storyboard.SetTargetName(c353, "ContentTransform");
											Storyboard.SetTarget(c353, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c353, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c355)
										{
											Storyboard.SetTargetName(c355, "MoreButton");
											Storyboard.SetTarget(c355, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c355, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c356)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c356, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
												_component_14 = c356;
												NameScope.SetNameScope(_component_14, nameScope);
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c357)
										{
											Storyboard.SetTargetName(c357, "MoreButton");
											Storyboard.SetTarget(c357, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c357, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c359)
										{
											Storyboard.SetTargetName(c359, "MoreButton");
											Storyboard.SetTarget(c359, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c359, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c361)
										{
											Storyboard.SetTargetName(c361, "HighContrastBorder");
											Storyboard.SetTarget(c361, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c361, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c362)
											{
												c362.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c363)
										{
											Storyboard.SetTargetName(c363, "OverflowContentRootClip");
											Storyboard.SetTarget(c363, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c363, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c364)
											{
												c364.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c365)
										{
											Storyboard.SetTargetName(c365, "OverflowContentRootTransform");
											Storyboard.SetTarget(c365, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c365, "Y");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "MinimalOpenDown"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c366)
						{
							nameScope.RegisterName("MinimalOpenDown", c366);
							MinimalOpenDown = c366;
							MarkupHelper.SetVisualStateLazy(c366, delegate
							{
								c366.Name = "MinimalOpenDown";
								c366.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c368)
										{
											Storyboard.SetTargetName(c368, "ClipGeometryTransform");
											Storyboard.SetTarget(c368, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c368, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "14,11,14,0"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c370)
										{
											Storyboard.SetTargetName(c370, "MoreButton");
											Storyboard.SetTarget(c370, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c370, "Padding");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c371)
											{
												ResourceResolverSingleton.Instance.ApplyResource(c371, ObjectKeyFrame.ValueProperty, "AppBarThemeMinimalHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
												_component_15 = c371;
												NameScope.SetNameScope(_component_15, nameScope);
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c372)
										{
											Storyboard.SetTargetName(c372, "MoreButton");
											Storyboard.SetTarget(c372, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c372, "MinHeight");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c374)
										{
											Storyboard.SetTargetName(c374, "MoreButton");
											Storyboard.SetTarget(c374, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c374, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c376)
										{
											Storyboard.SetTargetName(c376, "HighContrastBorder");
											Storyboard.SetTarget(c376, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c376, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c377)
											{
												c377.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c378)
										{
											Storyboard.SetTargetName(c378, "OverflowContentRootClip");
											Storyboard.SetTarget(c378, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c378, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c379)
											{
												c379.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.ContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c380)
										{
											Storyboard.SetTargetName(c380, "OverflowContentRootTransform");
											Storyboard.SetTarget(c380, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c380, "Y");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "HiddenClosed"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c381)
						{
							nameScope.RegisterName("HiddenClosed", c381);
							HiddenClosed = c381;
							MarkupHelper.SetVisualStateLazy(c381, delegate
							{
								c381.Name = "HiddenClosed";
								c381.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c382)
											{
												c382.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c383)
										{
											Storyboard.SetTargetName(c383, "ClipGeometryTransform");
											Storyboard.SetTarget(c383, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c383, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c385)
										{
											Storyboard.SetTargetName(c385, "MoreButton");
											Storyboard.SetTarget(c385, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c385, "IsTabStop");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c387)
										{
											Storyboard.SetTargetName(c387, "ContentControl");
											Storyboard.SetTarget(c387, _ContentControlSubject);
											Storyboard.SetTargetProperty(c387, "IsEnabled");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "False"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c389)
										{
											Storyboard.SetTargetName(c389, "PrimaryItemsControl");
											Storyboard.SetTarget(c389, _PrimaryItemsControlSubject);
											Storyboard.SetTargetProperty(c389, "IsEnabled");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "HiddenOpenUp"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c390)
						{
							nameScope.RegisterName("HiddenOpenUp", c390);
							HiddenOpenUp = c390;
							MarkupHelper.SetVisualStateLazy(c390, delegate
							{
								c390.Name = "HiddenOpenUp";
								c390.Storyboard = new Storyboard
								{
									Children = 
									{
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c391)
											{
												c391.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c392)
										{
											Storyboard.SetTargetName(c392, "ClipGeometryTransform");
											Storyboard.SetTarget(c392, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c392, "Y");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c393)
											{
												c393.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "TemplateSettings.HiddenVerticalDelta"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c394)
										{
											Storyboard.SetTargetName(c394, "ContentTransform");
											Storyboard.SetTarget(c394, _ContentTransformSubject);
											Storyboard.SetTargetProperty(c394, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c396)
										{
											Storyboard.SetTargetName(c396, "MoreButton");
											Storyboard.SetTarget(c396, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c396, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c398)
										{
											Storyboard.SetTargetName(c398, "HighContrastBorder");
											Storyboard.SetTarget(c398, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c398, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c399)
											{
												c399.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c400)
										{
											Storyboard.SetTargetName(c400, "OverflowContentRootClip");
											Storyboard.SetTarget(c400, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c400, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c401)
											{
												c401.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.NegativeOverflowContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c402)
										{
											Storyboard.SetTargetName(c402, "OverflowContentRootTransform");
											Storyboard.SetTarget(c402, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c402, "Y");
										})
									}
								};
							});
						}),
						new VisualState
						{
							Name = "HiddenOpenDown"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c403)
						{
							nameScope.RegisterName("HiddenOpenDown", c403);
							HiddenOpenDown = c403;
							MarkupHelper.SetVisualStateLazy(c403, delegate
							{
								c403.Name = "HiddenOpenDown";
								c403.Storyboard = new Storyboard
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
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c405)
										{
											Storyboard.SetTargetName(c405, "ClipGeometryTransform");
											Storyboard.SetTarget(c405, _ClipGeometryTransformSubject);
											Storyboard.SetTargetProperty(c405, "Y");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Stretch"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c407)
										{
											Storyboard.SetTargetName(c407, "MoreButton");
											Storyboard.SetTarget(c407, _MoreButtonSubject);
											Storyboard.SetTargetProperty(c407, "VerticalAlignment");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = "Visible"
											} }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c409)
										{
											Storyboard.SetTargetName(c409, "HighContrastBorder");
											Storyboard.SetTarget(c409, _HighContrastBorderSubject);
											Storyboard.SetTargetProperty(c409, "Visibility");
										}),
										(Timeline)new ObjectAnimationUsingKeyFrames
										{
											KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteObjectKeyFrame c410)
											{
												c410.SetBinding(ObjectKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.OverflowContentClipRect"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c411)
										{
											Storyboard.SetTargetName(c411, "OverflowContentRootClip");
											Storyboard.SetTarget(c411, _OverflowContentRootClipSubject);
											Storyboard.SetTargetProperty(c411, "Rect");
										}),
										(Timeline)new DoubleAnimationUsingKeyFrames
										{
											KeyFrames = { (DoubleKeyFrame)new DiscreteDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L)
											}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DiscreteDoubleKeyFrame c412)
											{
												c412.SetBinding(DoubleKeyFrame.ValueProperty, new Binding
												{
													RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
													Path = "CommandBarTemplateSettings.ContentHeight"
												});
											}) }
										}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(DoubleAnimationUsingKeyFrames c413)
										{
											Storyboard.SetTargetName(c413, "OverflowContentRootTransform");
											Storyboard.SetTarget(c413, _OverflowContentRootTransformSubject);
											Storyboard.SetTargetProperty(c413, "Y");
										})
									}
								};
							});
						})
					}
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualStateGroup c414)
				{
					nameScope.RegisterName("DisplayModeStates", c414);
					DisplayModeStates = c414;
				}),
				new VisualStateGroup
				{
					Name = "AvailableCommandsStates",
					States = 
					{
						new VisualState
						{
							Name = "BothCommands"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c415)
						{
							nameScope.RegisterName("BothCommands", c415);
							BothCommands = c415;
						}),
						new VisualState
						{
							Name = "PrimaryCommandsOnly"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c416)
						{
							nameScope.RegisterName("PrimaryCommandsOnly", c416);
							PrimaryCommandsOnly = c416;
							MarkupHelper.SetVisualStateLazy(c416, delegate
							{
								c416.Name = "PrimaryCommandsOnly";
								c416.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Collapsed"
										} }
									}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c418)
									{
										Storyboard.SetTargetName(c418, "OverflowContentRoot");
										Storyboard.SetTarget(c418, _OverflowContentRootSubject);
										Storyboard.SetTargetProperty(c418, "Visibility");
									}) }
								};
							});
						}),
						new VisualState
						{
							Name = "SecondaryCommandsOnly"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c419)
						{
							nameScope.RegisterName("SecondaryCommandsOnly", c419);
							SecondaryCommandsOnly = c419;
							MarkupHelper.SetVisualStateLazy(c419, delegate
							{
								c419.Name = "SecondaryCommandsOnly";
								c419.Storyboard = new Storyboard
								{
									Children = { (Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Collapsed"
										} }
									}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ObjectAnimationUsingKeyFrames c421)
									{
										Storyboard.SetTargetName(c421, "PrimaryItemsControl");
										Storyboard.SetTarget(c421, _PrimaryItemsControlSubject);
										Storyboard.SetTargetProperty(c421, "Visibility");
									}) }
								};
							});
						})
					}
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualStateGroup c422)
				{
					nameScope.RegisterName("AvailableCommandsStates", c422);
					AvailableCommandsStates = c422;
				}),
				new VisualStateGroup
				{
					Name = "DynamicOverflowStates",
					States = 
					{
						new VisualState
						{
							Name = "DynamicOverflowDisabled"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c423)
						{
							nameScope.RegisterName("DynamicOverflowDisabled", c423);
							DynamicOverflowDisabled = c423;
						}),
						new VisualState
						{
							Name = "DynamicOverflowEnabled"
						}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c424)
						{
							nameScope.RegisterName("DynamicOverflowEnabled", c424);
							DynamicOverflowEnabled = c424;
							MarkupHelper.SetVisualStateLazy(c424, delegate
							{
								c424.Name = "DynamicOverflowEnabled";
								c424.Setters.Add(new Setter(new TargetPropertyPath(_ContentControlColumnDefinitionSubject, (PropertyPath)"Width"), "Auto"));
								c424.Setters.Add(new Setter(new TargetPropertyPath(_PrimaryItemsControlColumnDefinitionSubject, (PropertyPath)"Width"), "*"));
							});
						})
					}
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualStateGroup c425)
				{
					nameScope.RegisterName("DynamicOverflowStates", c425);
					DynamicOverflowStates = c425;
				})
			});
			c43.CreationComplete();
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
internal class _CommandBar_a7ecc296c821b7f827e9c7e18c482393_CommandBarRDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ItemsPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayModeDefaultSubject = new ElementNameSubject();

	private ElementNameSubject _FullWidthOpenDownSubject = new ElementNameSubject();

	private ElementNameSubject _FullWidthOpenUpSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayModeStatesSubject = new ElementNameSubject();

	private ItemsPresenter _component_0
	{
		get
		{
			return (ItemsPresenter)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Grid _component_1
	{
		get
		{
			return (Grid)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private ItemsPresenter ItemsPresenter
	{
		get
		{
			return (ItemsPresenter)_ItemsPresenterSubject.ElementInstance;
		}
		set
		{
			_ItemsPresenterSubject.ElementInstance = value;
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

	private VisualState DisplayModeDefault
	{
		get
		{
			return (VisualState)_DisplayModeDefaultSubject.ElementInstance;
		}
		set
		{
			_DisplayModeDefaultSubject.ElementInstance = value;
		}
	}

	private VisualState FullWidthOpenDown
	{
		get
		{
			return (VisualState)_FullWidthOpenDownSubject.ElementInstance;
		}
		set
		{
			_FullWidthOpenDownSubject.ElementInstance = value;
		}
	}

	private VisualState FullWidthOpenUp
	{
		get
		{
			return (VisualState)_FullWidthOpenUpSubject.ElementInstance;
		}
		set
		{
			_FullWidthOpenUpSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_2199)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			BackgroundSizing = BackgroundSizing.OuterBorderEdge,
			Children = { (UIElement)new ScrollViewer
			{
				IsParsing = true,
				Content = new ItemsPresenter
				{
					IsParsing = true,
					Name = "ItemsPresenter"
				}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ItemsPresenter c427)
				{
					nameScope.RegisterName("ItemsPresenter", c427);
					ItemsPresenter = c427;
					ResourceResolverSingleton.Instance.ApplyResource(c427, FrameworkElement.MarginProperty, "CommandBarOverflowPresenterMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
					_component_0 = c427;
					c427.CreationComplete();
				})
			}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(ScrollViewer c428)
			{
				c428.SetBinding(ScrollViewer.HorizontalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c428.SetBinding(ScrollViewer.HorizontalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c428.SetBinding(ScrollViewer.VerticalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c428.SetBinding(ScrollViewer.VerticalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c428.SetBinding(ScrollViewer.ZoomModeProperty, new Binding
				{
					Path = "ScrollViewer.ZoomMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c428, AccessibilityView.Raw);
				c428.CreationComplete();
			}) }
		}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(Grid c429)
		{
			nameScope.RegisterName("LayoutRoot", c429);
			LayoutRoot = c429;
			c429.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c429.SetBinding(Grid.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c429.SetBinding(Grid.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c429, Grid.BorderThicknessProperty, "CommandBarOverflowPresenterBorderThickness", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_);
			VisualStateManager.SetVisualStateGroups(c429, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "DisplayModeStates",
				States = 
				{
					new VisualState
					{
						Name = "DisplayModeDefault"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c430)
					{
						nameScope.RegisterName("DisplayModeDefault", c430);
						DisplayModeDefault = c430;
					}),
					new VisualState
					{
						Name = "FullWidthOpenDown"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c431)
					{
						nameScope.RegisterName("FullWidthOpenDown", c431);
						FullWidthOpenDown = c431;
						MarkupHelper.SetVisualStateLazy(c431, delegate
						{
							c431.Name = "FullWidthOpenDown";
							c431.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Padding"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CommandBarOverflowPresenterBorderDownPadding", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CommandBarOverflowPresenterBorderDownPadding", GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c431.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"BorderThickness"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CommandBarOverflowPresenterBorderDownThickness", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CommandBarOverflowPresenterBorderDownThickness", GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					}),
					new VisualState
					{
						Name = "FullWidthOpenUp"
					}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualState c432)
					{
						nameScope.RegisterName("FullWidthOpenUp", c432);
						FullWidthOpenUp = c432;
						MarkupHelper.SetVisualStateLazy(c432, delegate
						{
							c432.Name = "FullWidthOpenUp";
							c432.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"Padding"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CommandBarOverflowPresenterBorderUpPadding", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CommandBarOverflowPresenterBorderUpPadding", GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							c432.Setters.Add(new Setter(new TargetPropertyPath(_LayoutRootSubject, (PropertyPath)"BorderThickness"), ResourceResolverSingleton.Instance.ResolveResourceStatic("CommandBarOverflowPresenterBorderUpThickness", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("CommandBarOverflowPresenterBorderUpThickness", GlobalStaticResources.ResourceDictionarySingleton__6.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.CommandBar_a7ecc296c821b7f827e9c7e18c482393_XamlApply(delegate(VisualStateGroup c433)
			{
				nameScope.RegisterName("DisplayModeStates", c433);
				DisplayModeStates = c433;
			}) });
			_component_1 = c429;
			c429.CreationComplete();
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

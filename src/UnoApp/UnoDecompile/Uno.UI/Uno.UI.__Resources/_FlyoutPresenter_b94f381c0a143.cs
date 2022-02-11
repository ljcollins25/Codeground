using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddc_FlyoutPresenterRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _ScrollViewerSubject = new ElementNameSubject();

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

	public UIElement Build(object __ResourceOwner_2598)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			BackgroundSizing = BackgroundSizing.OuterBorderEdge,
			Child = new ScrollViewer
			{
				IsParsing = true,
				Name = "ScrollViewer",
				Content = new ContentPresenter
				{
					IsParsing = true
				}.FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddc_XamlApply(delegate(ContentPresenter c0)
				{
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
					c0.SetBinding(FrameworkElement.MarginProperty, new Binding
					{
						Path = "Padding",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
					{
						Path = "HorizontalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
					{
						Path = "VerticalContentAlignment",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.CreationComplete();
				})
			}.FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddc_XamlApply(delegate(ScrollViewer c1)
			{
				nameScope.RegisterName("ScrollViewer", c1);
				ScrollViewer = c1;
				ScrollViewer.SetZoomMode(c1, ZoomMode.Disabled);
				c1.SetBinding(ScrollViewer.HorizontalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.SetBinding(ScrollViewer.HorizontalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.HorizontalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.SetBinding(ScrollViewer.VerticalScrollModeProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollMode",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.SetBinding(ScrollViewer.VerticalScrollBarVisibilityProperty, new Binding
				{
					Path = "ScrollViewer.VerticalScrollBarVisibility",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				AutomationProperties.SetAccessibilityView(c1, AccessibilityView.Raw);
				c1.CreationComplete();
			})
		}.FlyoutPresenter_b94f381c0a143960c8ee6c41c6341ddc_XamlApply(delegate(Border c2)
		{
			c2.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c2.SetBinding(Border.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c2.SetBinding(Border.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c2.SetBinding(Border.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c2, Border.PaddingProperty, "FlyoutBorderThemePadding", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__17.Instance.__ParseContext_);
			_component_0 = c2;
			c2.CreationComplete();
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

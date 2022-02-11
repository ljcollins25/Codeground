using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uno.UI.__Resources;

internal class _SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_SwipeControlRDSC0
{
	private ElementNameSubject _SwipeContentStackPanelSubject = new ElementNameSubject();

	private ElementNameSubject _SwipeContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _InputEaterSubject = new ElementNameSubject();

	private ElementNameSubject _ContentRootSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private StackPanel SwipeContentStackPanel
	{
		get
		{
			return (StackPanel)_SwipeContentStackPanelSubject.ElementInstance;
		}
		set
		{
			_SwipeContentStackPanelSubject.ElementInstance = value;
		}
	}

	private Grid SwipeContentRoot
	{
		get
		{
			return (Grid)_SwipeContentRootSubject.ElementInstance;
		}
		set
		{
			_SwipeContentRootSubject.ElementInstance = value;
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

	private Grid InputEater
	{
		get
		{
			return (Grid)_InputEaterSubject.ElementInstance;
		}
		set
		{
			_InputEaterSubject.ElementInstance = value;
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

	private Grid RootGrid
	{
		get
		{
			return (Grid)_RootGridSubject.ElementInstance;
		}
		set
		{
			_RootGridSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_374)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "SwipeContentRoot",
					Children = { (UIElement)new StackPanel
					{
						IsParsing = true,
						Name = "SwipeContentStackPanel"
					}.SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(delegate(StackPanel c0)
					{
						nameScope.RegisterName("SwipeContentStackPanel", c0);
						SwipeContentStackPanel = c0;
						c0.CreationComplete();
					}) }
				}.SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(delegate(Grid c1)
				{
					nameScope.RegisterName("SwipeContentRoot", c1);
					SwipeContentRoot = c1;
					c1.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ContentRoot",
					Children = 
					{
						(UIElement)new ContentPresenter
						{
							IsParsing = true,
							Name = "ContentPresenter",
							HorizontalContentAlignment = HorizontalAlignment.Stretch,
							VerticalContentAlignment = VerticalAlignment.Stretch
						}.SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(delegate(ContentPresenter c2)
						{
							nameScope.RegisterName("ContentPresenter", c2);
							ContentPresenter = c2;
							c2.SetBinding(FrameworkElement.BackgroundProperty, new Binding
							{
								Path = "Background",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
							{
								Path = "BorderBrush",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
							{
								Path = "BorderThickness",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(ContentPresenter.PaddingProperty, new Binding
							{
								Path = "Padding",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(ContentPresenter.ContentProperty, new Binding
							{
								Path = "Content",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
							{
								Path = "ContentTransitions",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c2.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
							{
								Path = "ContentTemplate",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetAccessibilityView(c2, AccessibilityView.Raw);
							c2.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "InputEater"
						}.SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(delegate(Grid c3)
						{
							nameScope.RegisterName("InputEater", c3);
							InputEater = c3;
							c3.CreationComplete();
						})
					}
				}.SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(delegate(Grid c4)
				{
					nameScope.RegisterName("ContentRoot", c4);
					ContentRoot = c4;
					c4.CreationComplete();
				})
			}
		}.SwipeControl_b3f79e76564a93f1ea73b5e10af23ed1_XamlApply(delegate(Grid c5)
		{
			nameScope.RegisterName("RootGrid", c5);
			RootGrid = c5;
			c5.CreationComplete();
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

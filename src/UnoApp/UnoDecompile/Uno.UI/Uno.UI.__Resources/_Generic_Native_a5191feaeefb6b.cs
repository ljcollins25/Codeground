using Uno.UI.Xaml;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_Generic_NativeRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _HeaderContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _ContentElementSubject = new ElementNameSubject();

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

	private ContentPresenter HeaderContentPresenter
	{
		get
		{
			return (ContentPresenter)_HeaderContentPresenterSubject.ElementInstance;
		}
		set
		{
			_HeaderContentPresenterSubject.ElementInstance = value;
		}
	}

	private ContentControl ContentElement
	{
		get
		{
			return (ContentControl)_ContentElementSubject.ElementInstance;
		}
		set
		{
			_ContentElementSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2827)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
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
					Height = new GridLength(1.0, GridUnitType.Star)
				}
			},
			Children = 
			{
				(UIElement)new ElementStub(() => new ContentPresenter
				{
					IsParsing = true,
					Name = "HeaderContentPresenter",
					Visibility = Visibility.Collapsed,
					Margin = new Thickness(0.0, 0.0, 0.0, 8.0),
					FontWeight = FontWeights.Normal
				}.Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(delegate(ContentPresenter c4)
				{
					nameScope.RegisterName("HeaderContentPresenter", c4);
					HeaderContentPresenter = c4;
					Grid.SetRow(c4, 0);
					ResourceResolverSingleton.Instance.ApplyResource(c4, ContentPresenter.ForegroundProperty, "SystemControlForegroundBaseHighBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__19.Instance.__ParseContext_);
					Grid.SetColumnSpan(c4, 2);
					c4.SetBinding(ContentPresenter.ContentProperty, new Binding
					{
						Path = "Header",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c4.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
					{
						Path = "HeaderTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c4;
					c4.CreationComplete();
				})).Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(delegate(ElementStub c5)
				{
					c5.Name = "HeaderContentPresenter";
					_HeaderContentPresenterSubject.ElementInstance = c5;
					c5.Visibility = Visibility.Collapsed;
				}),
				(UIElement)new ContentControl
				{
					IsParsing = true,
					Name = "ContentElement"
				}.Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(delegate(ContentControl c6)
				{
					nameScope.RegisterName("ContentElement", c6);
					ContentElement = c6;
					Grid.SetRow(c6, 1);
					c6.CreationComplete();
				})
			}
		}.Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(delegate(Grid c7)
		{
			c7.CreationComplete();
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
internal class _Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_Generic_NativeRDSC1
{
	private ElementNameSubject _NativePresenterSubject = new ElementNameSubject();

	private NativePivotPresenter NativePresenter
	{
		get
		{
			return (NativePivotPresenter)_NativePresenterSubject.ElementInstance;
		}
		set
		{
			_NativePresenterSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2828)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new NativePivotPresenter
		{
			IsParsing = true,
			Name = "NativePresenter"
		}.Generic_Native_a5191feaeefb6b47b6ffc2cc3daca9d2_XamlApply(delegate(NativePivotPresenter c8)
		{
			nameScope.RegisterName("NativePresenter", c8);
			NativePresenter = c8;
			c8.CreationComplete();
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

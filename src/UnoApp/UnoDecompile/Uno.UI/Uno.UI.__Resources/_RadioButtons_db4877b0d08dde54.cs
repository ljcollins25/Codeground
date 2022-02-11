using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _RadioButtons_db4877b0d08dde542df2a4d175559c71_RadioButtonsRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _HeaderContentPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _InnerRepeaterSubject = new ElementNameSubject();

	private ElementNameSubject _NormalSubject = new ElementNameSubject();

	private ElementNameSubject _DisabledSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

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

	private ColumnMajorUniformToLargestGridLayout _component_1
	{
		get
		{
			return (ColumnMajorUniformToLargestGridLayout)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
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

	private ItemsRepeater InnerRepeater
	{
		get
		{
			return (ItemsRepeater)_InnerRepeaterSubject.ElementInstance;
		}
		set
		{
			_InnerRepeaterSubject.ElementInstance = value;
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

	public UIElement Build(object __ResourceOwner_600)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new StackPanel
		{
			IsParsing = true,
			Children = 
			{
				(UIElement)new ContentPresenter
				{
					IsParsing = true,
					Name = "HeaderContentPresenter"
				}.RadioButtons_db4877b0d08dde542df2a4d175559c71_XamlApply(delegate(ContentPresenter c0)
				{
					nameScope.RegisterName("HeaderContentPresenter", c0);
					HeaderContentPresenter = c0;
					c0.SetBinding(ContentPresenter.ContentProperty, new Binding
					{
						Path = "Header",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
					{
						Path = "HeaderTemplate",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c0, ContentPresenter.ForegroundProperty, "RadioButtonsHeaderForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__55.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c0, FrameworkElement.MarginProperty, "RadioButtonsTopHeaderMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__55.Instance.__ParseContext_);
					_component_0 = c0;
					c0.CreationComplete();
				}),
				(UIElement)new ItemsRepeater
				{
					IsParsing = true,
					Name = "InnerRepeater",
					Layout = new ColumnMajorUniformToLargestGridLayout().RadioButtons_db4877b0d08dde542df2a4d175559c71_XamlApply(delegate(ColumnMajorUniformToLargestGridLayout c1)
					{
						c1.SetBinding(ColumnMajorUniformToLargestGridLayout.MaxColumnsProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "MaxColumns"
						});
						ResourceResolverSingleton.Instance.ApplyResource(c1, ColumnMajorUniformToLargestGridLayout.ColumnSpacingProperty, "RadioButtonsColumnSpacing", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__55.Instance.__ParseContext_);
						ResourceResolverSingleton.Instance.ApplyResource(c1, ColumnMajorUniformToLargestGridLayout.RowSpacingProperty, "RadioButtonsRowSpacing", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__55.Instance.__ParseContext_);
						_component_1 = c1;
						NameScope.SetNameScope(_component_1, nameScope);
					})
				}.RadioButtons_db4877b0d08dde542df2a4d175559c71_XamlApply(delegate(ItemsRepeater c2)
				{
					nameScope.RegisterName("InnerRepeater", c2);
					InnerRepeater = c2;
					c2.CreationComplete();
				})
			}
		}.RadioButtons_db4877b0d08dde542df2a4d175559c71_XamlApply(delegate(StackPanel c3)
		{
			VisualStateManager.SetVisualStateGroups(c3, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Normal"
					}.RadioButtons_db4877b0d08dde542df2a4d175559c71_XamlApply(delegate(VisualState c4)
					{
						nameScope.RegisterName("Normal", c4);
						Normal = c4;
					}),
					new VisualState
					{
						Name = "Disabled"
					}.RadioButtons_db4877b0d08dde542df2a4d175559c71_XamlApply(delegate(VisualState c5)
					{
						nameScope.RegisterName("Disabled", c5);
						Disabled = c5;
						MarkupHelper.SetVisualStateLazy(c5, delegate
						{
							c5.Name = "Disabled";
							c5.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentPresenterSubject, (PropertyPath)"Foreground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("RadioButtonsHeaderForegroundDisabled", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__55.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("RadioButtonsHeaderForegroundDisabled", GlobalStaticResources.ResourceDictionarySingleton__55.Instance.__ParseContext_, isTheme: true, isHotReload: false));
						});
					})
				}
			}.RadioButtons_db4877b0d08dde542df2a4d175559c71_XamlApply(delegate(VisualStateGroup c6)
			{
				nameScope.RegisterName("CommonStates", c6);
				CommonStates = c6;
			}) });
			c3.CreationComplete();
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

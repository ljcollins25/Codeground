using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _MenuFlyout_rs1_themeresources_b9295cf4ea21acf9b089f6786df37972_MenuFlyout_rs1_themeresourcesRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

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

	public UIElement Build(object __ResourceOwner_213)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Rectangle
		{
			IsParsing = true
		}.MenuFlyout_rs1_themeresources_b9295cf4ea21acf9b089f6786df37972_XamlApply(delegate(Rectangle c0)
		{
			c0.SetBinding(Shape.FillProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c0.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			ResourceResolverSingleton.Instance.ApplyResource(c0, FrameworkElement.HeightProperty, "MenuFlyoutSeparatorThemeHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__29.Instance.__ParseContext_);
			_component_0 = c0;
			c0.CreationComplete();
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

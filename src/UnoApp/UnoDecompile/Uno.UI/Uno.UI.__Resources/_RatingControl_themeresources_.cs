using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Uno.UI.__Resources;

internal class _RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_RatingControl_themeresources_v1RDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private TextBlock _component_0
	{
		get
		{
			return (TextBlock)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1643)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new TextBlock
		{
			IsParsing = true,
			Margin = new Thickness(-8.0, -8.0, 0.0, 0.0),
			FontSize = 32.0,
			Text = "\ue734"
		}.RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_XamlApply(delegate(TextBlock c3)
		{
			ResourceResolverSingleton.Instance.ApplyResource(c3, TextBlock.ForegroundProperty, "RatingControlUnselectedForeground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__62.Instance.__ParseContext_);
			AutomationProperties.SetAccessibilityView(c3, AccessibilityView.Raw);
			ResourceResolverSingleton.Instance.ApplyResource(c3, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__62.Instance.__ParseContext_);
			_component_0 = c3;
			c3.CreationComplete();
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
internal class _RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_RatingControl_themeresources_v1RDSC1
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private TextBlock _component_0
	{
		get
		{
			return (TextBlock)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_1655)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new TextBlock
		{
			IsParsing = true,
			Margin = new Thickness(-8.0, -8.0, 0.0, 0.0),
			FontSize = 32.0,
			Text = "\ue735"
		}.RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_XamlApply(delegate(TextBlock c4)
		{
			AutomationProperties.SetAccessibilityView(c4, AccessibilityView.Raw);
			ResourceResolverSingleton.Instance.ApplyResource(c4, TextBlock.FontFamilyProperty, "SymbolThemeFontFamily", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__62.Instance.__ParseContext_);
			_component_0 = c4;
			c4.CreationComplete();
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
internal class _RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_RatingControl_themeresources_v1RDSC2
{
	public UIElement Build(object __ResourceOwner_1659)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Image
		{
			IsParsing = true,
			Margin = new Thickness(-8.0, -8.0, 0.0, 0.0)
		}.RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_XamlApply(delegate(Image c5)
		{
			AutomationProperties.SetAccessibilityView(c5, AccessibilityView.Raw);
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
internal class _RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_RatingControl_themeresources_v1RDSC3
{
	public UIElement Build(object __ResourceOwner_1660)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Image
		{
			IsParsing = true,
			Margin = new Thickness(-8.0, -8.0, 0.0, 0.0)
		}.RatingControl_themeresources_v1_b152074db65a450791fdd3dc62b6e4e8_XamlApply(delegate(Image c6)
		{
			AutomationProperties.SetAccessibilityView(c6, AccessibilityView.Raw);
			c6.CreationComplete();
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

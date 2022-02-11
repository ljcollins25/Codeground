using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uno.UI.__Resources;

internal class _ToolTip_ac7e2519a681bcd14512ef3662650954_ToolTipRDSC0
{
	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ContentPresenter LayoutRoot
	{
		get
		{
			return (ContentPresenter)_LayoutRootSubject.ElementInstance;
		}
		set
		{
			_LayoutRootSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2553)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new ContentPresenter
		{
			IsParsing = true,
			Name = "LayoutRoot",
			BackgroundSizing = BackgroundSizing.OuterBorderEdge,
			MaxWidth = 320.0,
			TextWrapping = TextWrapping.Wrap
		}.ToolTip_ac7e2519a681bcd14512ef3662650954_XamlApply(delegate(ContentPresenter c3)
		{
			nameScope.RegisterName("LayoutRoot", c3);
			LayoutRoot = c3;
			c3.SetBinding(ContentPresenter.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ContentPresenter.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Content",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
			{
				Path = "ContentTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
			{
				Path = "ContentTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ContentPresenter.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c3.CreationComplete();
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

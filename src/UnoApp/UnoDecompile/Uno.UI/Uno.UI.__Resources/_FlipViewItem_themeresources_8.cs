using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uno.UI.__Resources;

internal class _FlipViewItem_themeresources_832b35b6b63b5f6f2ee6baf336e30c3c_FlipViewItem_themeresourcesRDSC0
{
	public UIElement Build(object __ResourceOwner_2594)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new ContentPresenter
		{
			IsParsing = true
		}.FlipViewItem_themeresources_832b35b6b63b5f6f2ee6baf336e30c3c_XamlApply(delegate(ContentPresenter c0)
		{
			c0.SetBinding(ContentPresenter.ContentProperty, new Binding
			{
				Path = "Content",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
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
			c0.SetBinding(ContentPresenter.CornerRadiusProperty, new Binding
			{
				Path = "CornerRadius",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c0.SetBinding(ContentPresenter.ContentTransitionsProperty, new Binding
			{
				Path = "ContentTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c0.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding
			{
				Path = "ContentTemplate",
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
			c0.CreationComplete();
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

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uno.UI.__Resources;

internal class _SystemFocusVisual_d2e089aae2316d880324f851cc56641f_SystemFocusVisualRDSC0
{
	public UIElement Build(object __ResourceOwner_403)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Border
		{
			IsParsing = true,
			Child = new Border
			{
				IsParsing = true,
				Background = null,
				Child = new Border
				{
					IsParsing = true
				}.SystemFocusVisual_d2e089aae2316d880324f851cc56641f_XamlApply(delegate(Border c0)
				{
					c0.SetBinding(Border.BorderBrushProperty, new Binding
					{
						Path = "FocusedElement.FocusVisualSecondaryBrush",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.SetBinding(Border.BorderThicknessProperty, new Binding
					{
						Path = "FocusedElement.FocusVisualSecondaryThickness",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.SetBinding(Border.CornerRadiusProperty, new Binding
					{
						Path = "FocusedElement.CornerRadius",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c0.CreationComplete();
				})
			}.SystemFocusVisual_d2e089aae2316d880324f851cc56641f_XamlApply(delegate(Border c1)
			{
				c1.SetBinding(Border.BorderBrushProperty, new Binding
				{
					Path = "FocusedElement.FocusVisualPrimaryBrush",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.SetBinding(Border.BorderThicknessProperty, new Binding
				{
					Path = "FocusedElement.FocusVisualPrimaryThickness",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.SetBinding(Border.CornerRadiusProperty, new Binding
				{
					Path = "FocusedElement.CornerRadius",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.SetBinding(FrameworkElement.MarginProperty, new Binding
				{
					Path = "FocusedElement.FocusVisualMargin",
					RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
				});
				c1.CreationComplete();
			})
		}.SystemFocusVisual_d2e089aae2316d880324f851cc56641f_XamlApply(delegate(Border c2)
		{
			c2.SetBinding(UIElement.RenderTransformProperty, new Binding
			{
				Path = "FocusedElement.RenderTransform",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c2.SetBinding(UIElement.RenderTransformOriginProperty, new Binding
			{
				Path = "FocusedElement.RenderTransformOrigin",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c2.CreationComplete();
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

using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Uno.UI.__Resources;

internal class _DragView_1768c0992ed91fdec9b729bca455303a_DragViewRDSC0
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private StackPanel _component_0
	{
		get
		{
			return (StackPanel)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2541)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			HorizontalAlignment = HorizontalAlignment.Left,
			VerticalAlignment = VerticalAlignment.Top,
			Children = 
			{
				(UIElement)new Image
				{
					IsParsing = true,
					Opacity = 0.8,
					RenderTransform = new TranslateTransform().DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(delegate(TranslateTransform c0)
					{
						c0.SetBinding(TranslateTransform.XProperty, new Binding
						{
							Path = "ContentAnchor.X",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c0.SetBinding(TranslateTransform.YProperty, new Binding
						{
							Path = "ContentAnchor.Y",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
					})
				}.DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(delegate(Image c1)
				{
					c1.SetBinding(UIElement.VisibilityProperty, new Binding
					{
						Path = "ContentVisibility",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.SetBinding(Image.SourceProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c1.CreationComplete();
				}),
				(UIElement)new StackPanel
				{
					IsParsing = true,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Top,
					Orientation = Orientation.Horizontal,
					BorderThickness = new Thickness(1.0),
					Padding = new Thickness(2.0, 5.0),
					RenderTransform = new TranslateTransform
					{
						Y = -40.0
					},
					Children = 
					{
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Margin = new Thickness(3.0, 0.0)
						}.DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(delegate(TextBlock c3)
						{
							c3.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								Path = "GlyphVisiblity",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c3.SetBinding(TextBlock.TextProperty, new Binding
							{
								Path = "Glyph",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c3.CreationComplete();
						}),
						(UIElement)new TextBlock
						{
							IsParsing = true,
							Margin = new Thickness(3.0, 0.0)
						}.DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(delegate(TextBlock c4)
						{
							c4.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								Path = "CaptionVisiblity",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c4.SetBinding(TextBlock.TextProperty, new Binding
							{
								Path = "Caption",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c4.CreationComplete();
						})
					}
				}.DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(delegate(StackPanel c5)
				{
					ResourceResolverSingleton.Instance.ApplyResource(c5, StackPanel.BorderBrushProperty, "SystemControlForegroundChromeHighBrush", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__12.Instance.__ParseContext_);
					ResourceResolverSingleton.Instance.ApplyResource(c5, FrameworkElement.BackgroundProperty, "SystemControlBackgroundChromeMediumLowBrush", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__12.Instance.__ParseContext_);
					c5.SetBinding(UIElement.VisibilityProperty, new Binding
					{
						Path = "TooltipVisibility",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c5;
					c5.CreationComplete();
				})
			}
		}.DragView_1768c0992ed91fdec9b729bca455303a_XamlApply(delegate(Grid c6)
		{
			c6.CreationComplete();
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

using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Content")]
public class Flyout : FlyoutBase
{
	private FlyoutPresenter _presenter;

	public Style FlyoutPresenterStyle
	{
		get
		{
			return (Style)GetValue(FlyoutPresenterStyleProperty);
		}
		set
		{
			SetValue(FlyoutPresenterStyleProperty, value);
		}
	}

	public static DependencyProperty FlyoutPresenterStyleProperty { get; } = DependencyProperty.Register("FlyoutPresenterStyle", typeof(Style), typeof(Flyout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.AffectsMeasure, OnFlyoutPresenterStyleChanged));


	public UIElement Content
	{
		get
		{
			return (UIElement)GetValue(ContentProperty);
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(UIElement), typeof(Flyout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnContentChanged));


	private static void OnFlyoutPresenterStyleChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		Flyout flyout = dependencyObject as Flyout;
		if (flyout._presenter != null)
		{
			flyout.SetPresenterStyle();
		}
	}

	private void SetPresenterStyle()
	{
		if (FlyoutPresenterStyle != null)
		{
			_presenter.Style = FlyoutPresenterStyle;
		}
		else
		{
			_presenter.ClearValue(FrameworkElement.StyleProperty);
		}
	}

	private static void OnContentChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		Flyout flyout = dependencyObject as Flyout;
		if (flyout._presenter != null)
		{
			if (args.NewValue is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
			{
				dependencyObjectStoreProvider.Store.SetValue(dependencyObjectStoreProvider.Store.TemplatedParentProperty, flyout.TemplatedParent, DependencyPropertyValuePrecedences.Local);
			}
			flyout._presenter.Content = args.NewValue;
		}
		flyout.SynchronizeNamescope();
		if (args.OldValue is DependencyObject dependencyObject2)
		{
			dependencyObject2.ClearValue(NameScope.NameScopeProperty);
		}
	}

	private void SynchronizeNamescope()
	{
		INameScope nameScope = NameScope.GetNameScope(this);
		if (nameScope != null)
		{
			DependencyObject content = Content;
			if (content != null)
			{
				NameScope.SetNameScope(content, nameScope);
			}
		}
	}

	protected internal override void Close()
	{
		base.Close();
	}

	protected internal override void Open()
	{
		base.Open();
	}

	protected internal override void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnTemplatedParentChanged(e);
		IDependencyObjectStoreProvider content = Content;
		content?.Store.SetValue(content.Store.TemplatedParentProperty, base.TemplatedParent, DependencyPropertyValuePrecedences.Local);
	}

	protected override Control CreatePresenter()
	{
		_presenter = new FlyoutPresenter();
		SetPresenterStyle();
		_presenter.Content = Content;
		SynchronizeNamescope();
		return _presenter;
	}
}

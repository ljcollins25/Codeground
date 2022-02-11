using System;
using System.Collections;
using System.Linq;
using Uno;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Content")]
public class ContentControl : Control, IEnumerable, ICustomClippingElement
{
	private UIElement? _contentTemplateRoot;

	private DataTemplate? _dataTemplateUsedLastUpdate;

	private bool _canCreateTemplateWithoutParent;

	private bool _localContentDataContextOverride;

	private static Func<Type, bool> HasDefaultTemplate = Funcs.CreateMemoized((Type type) => Style.GetDefaultStyleForType(type)?.Flatten((Style s) => s.BasedOn).SelectMany((Style s) => s.Setters).OfType<Setter>()
		.Any((Setter s) => s.Property == Control.TemplateProperty && s.Value != null) ?? false);

	protected override bool CanCreateTemplateWithoutParent => _canCreateTemplateWithoutParent;

	public virtual object Content
	{
		get
		{
			if (this.IsDependencyPropertySet(ContentProperty))
			{
				return GetValue(ContentProperty);
			}
			if (ContentTemplate != null)
			{
				return base.DataContext;
			}
			return null;
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(object), typeof(ContentControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentControl)s)?.OnContentChanged(e.OldValue, e.NewValue);
	}));


	public DataTemplate ContentTemplate
	{
		get
		{
			return (DataTemplate)GetValue(ContentTemplateProperty);
		}
		set
		{
			SetValue(ContentTemplateProperty, value);
		}
	}

	public static DependencyProperty ContentTemplateProperty { get; } = DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(ContentControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentControl)s)?.OnContentTemplateChanged(e.OldValue as DataTemplate, e.NewValue as DataTemplate);
	}));


	public DataTemplateSelector ContentTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty);
		}
		set
		{
			SetValue(ContentTemplateSelectorProperty, value);
		}
	}

	public static DependencyProperty ContentTemplateSelectorProperty { get; } = DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(ContentControl), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentControl)s)?.OnContentTemplateSelectorChanged(e.OldValue as DataTemplateSelector, e.NewValue as DataTemplateSelector);
	}));


	public virtual UIElement ContentTemplateRoot
	{
		get
		{
			return _contentTemplateRoot;
		}
		protected set
		{
			UIElement contentTemplateRoot = _contentTemplateRoot;
			if (contentTemplateRoot != null)
			{
				ResetContentDataContextOverride();
				UnregisterContentTemplateRoot();
				UpdateContentTransitions(ContentTransitions, null);
			}
			_contentTemplateRoot = value;
			if (_contentTemplateRoot != null)
			{
				RegisterContentTemplateRoot();
				UpdateContentTransitions(null, ContentTransitions);
			}
		}
	}

	public TransitionCollection ContentTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(ContentTransitionsProperty);
		}
		set
		{
			SetValue(ContentTransitionsProperty, value);
		}
	}

	public static DependencyProperty ContentTransitionsProperty { get; } = DependencyProperty.Register("ContentTransitions", typeof(TransitionCollection), typeof(ContentControl), new FrameworkPropertyMetadata(null, OnContentTransitionsChanged));


	internal bool IsContentPresenterBypassEnabled
	{
		get
		{
			if (base.Template == null)
			{
				return !HasDefaultTemplate(GetDefaultStyleKey());
			}
			return false;
		}
	}

	bool ICustomClippingElement.AllowClippingToLayoutSlot
	{
		get
		{
			if (Content is UIElement uIElement && uIElement.RenderTransform != null)
			{
				return false;
			}
			UIElement templatedRoot = base.TemplatedRoot;
			if (templatedRoot != null && templatedRoot.RenderTransform != null)
			{
				return false;
			}
			return true;
		}
	}

	bool ICustomClippingElement.ForceClippingToLayoutSlot => false;

	public ContentControl()
	{
		base.DefaultStyleKey = typeof(ContentControl);
		InitializePartial();
	}

	private void InitializePartial()
	{
		IFrameworkElementHelper.Initialize(this);
	}

	protected virtual void OnContentChanged(object oldValue, object newValue)
	{
		if (IsContentPresenterBypassEnabled)
		{
			if (newValue is UIElement && base.Template == null)
			{
				ContentTemplateRoot = newValue as UIElement;
			}
			else if (oldValue != null && newValue == null)
			{
				ContentTemplateRoot = null;
			}
			if (newValue != null)
			{
				SetUpdateTemplate();
			}
		}
	}

	protected virtual void OnContentTemplateChanged(DataTemplate oldTemplate, DataTemplate newTemplate)
	{
		if (IsContentPresenterBypassEnabled)
		{
			if (ContentTemplateRoot != null)
			{
				ContentTemplateRoot = null;
			}
			SetUpdateTemplate();
		}
		else if (CanCreateTemplateWithoutParent)
		{
			SetUpdateControlTemplate();
		}
	}

	protected virtual void OnContentTemplateSelectorChanged(DataTemplateSelector dataTemplateSelector1, DataTemplateSelector dataTemplateSelector2)
	{
		_ = IsContentPresenterBypassEnabled;
	}

	private void SetUpdateTemplate()
	{
		if (HasParent() || CanCreateTemplateWithoutParent)
		{
			UpdateContentTemplateRoot();
			SyncDataContext();
			InvalidateMeasure();
		}
	}

	private void UnregisterContentTemplateRoot()
	{
		RemoveChild(ContentTemplateRoot);
	}

	private static void OnContentTransitionsChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is ContentControl contentControl)
		{
			TransitionCollection oldValue = (TransitionCollection)args.OldValue;
			TransitionCollection newValue = (TransitionCollection)args.NewValue;
			contentControl.UpdateContentTransitions(oldValue, newValue);
		}
	}

	private void UpdateContentTransitions(TransitionCollection? oldValue, TransitionCollection? newValue)
	{
		if (!(ContentTemplateRoot is IFrameworkElement element))
		{
			return;
		}
		if (oldValue != null)
		{
			foreach (Transition item in oldValue!)
			{
				item.DetachFromElement(element);
			}
		}
		if (newValue == null)
		{
			return;
		}
		foreach (Transition item2 in newValue!)
		{
			item2.AttachToElement(element);
		}
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (IsContentPresenterBypassEnabled)
		{
			SetUpdateTemplate();
		}
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		base.OnVisibilityChanged(oldValue, newValue);
		if (oldValue == Visibility.Collapsed && newValue == Visibility.Visible)
		{
			SetUpdateTemplate();
		}
	}

	public void UpdateContentTemplateRoot()
	{
		if (base.Visibility == Visibility.Collapsed)
		{
			return;
		}
		if (ContentTemplateRoot == null)
		{
			_dataTemplateUsedLastUpdate = null;
		}
		if (IsContentPresenterBypassEnabled)
		{
			DataTemplate dataTemplate = this.ResolveContentTemplate();
			if (!object.Equals(dataTemplate, _dataTemplateUsedLastUpdate))
			{
				_dataTemplateUsedLastUpdate = dataTemplate;
				ContentTemplateRoot = dataTemplate?.LoadContentCached() ?? (Content as UIElement);
			}
			if (Content != null && !(Content is UIElement) && ContentTemplateRoot == null && dataTemplate == null && ContentTemplate == null)
			{
				SetContentTemplateRootToPlaceholder();
			}
			if (ContentTemplateRoot == null && Content is UIElement contentTemplateRoot && dataTemplate == null)
			{
				ContentTemplateRoot = contentTemplateRoot;
			}
		}
		if (ContentTemplateRoot != null)
		{
			OnApplyTemplate();
		}
		SyncDataContext();
	}

	private void SetContentTemplateRootToPlaceholder()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("No ContentTemplate was specified for {0} and content is not a UIView, defaulting to TextBlock.", GetType().Name);
		}
		ContentTemplateRoot = new ImplicitTextBlock(this).Binding("Text", "").Binding("HorizontalAlignment", new Binding
		{
			Path = "HorizontalContentAlignment",
			Source = this,
			Mode = BindingMode.OneWay
		}).Binding("VerticalAlignment", new Binding
		{
			Path = "VerticalContentAlignment",
			Source = this,
			Mode = BindingMode.OneWay
		});
	}

	private void RegisterContentTemplateRoot()
	{
		AddChild(ContentTemplateRoot);
	}

	protected internal override void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnDataContextChanged(e);
		if (IsContentPresenterBypassEnabled)
		{
			SyncDataContext();
		}
	}

	protected virtual void SyncDataContext()
	{
		if (IsContentPresenterBypassEnabled)
		{
			if (Content is UIElement)
			{
				ResetContentDataContextOverride();
				return;
			}
			IDependencyObjectStoreProvider contentTemplateRoot = ContentTemplateRoot;
			if (contentTemplateRoot != null && (_localContentDataContextOverride || !(contentTemplateRoot as DependencyObject).IsDependencyPropertyLocallySet(contentTemplateRoot.Store.DataContextProperty)))
			{
				_localContentDataContextOverride = true;
				contentTemplateRoot.Store.SetValue(contentTemplateRoot.Store.DataContextProperty, Content, DependencyPropertyValuePrecedences.Local);
			}
		}
		else
		{
			ResetContentDataContextOverride();
		}
	}

	private void ResetContentDataContextOverride()
	{
		if (_localContentDataContextOverride)
		{
			IDependencyObjectStoreProvider contentTemplateRoot = ContentTemplateRoot;
			if (contentTemplateRoot != null)
			{
				_localContentDataContextOverride = false;
				contentTemplateRoot.Store.ClearValue(contentTemplateRoot.Store.DataContextProperty, DependencyPropertyValuePrecedences.Local);
			}
		}
	}

	internal static ContentControl CreateItemContainer()
	{
		return new ContentControl
		{
			_canCreateTemplateWithoutParent = true,
			IsGeneratedContainer = true
		};
	}

	public override string GetAccessibilityInnerText()
	{
		object content = Content;
		if (!(content is string result))
		{
			if (!(content is IFrameworkElement frameworkElement))
			{
				return content?.ToString();
			}
			return frameworkElement.GetAccessibilityInnerText();
		}
		return result;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (!base.IsDefaultStyleApplied && object.Equals(base.DefaultStyleKey, typeof(ContentControl)))
		{
			ApplyDefaultStyle();
		}
		return base.MeasureOverride(availableSize);
	}
}

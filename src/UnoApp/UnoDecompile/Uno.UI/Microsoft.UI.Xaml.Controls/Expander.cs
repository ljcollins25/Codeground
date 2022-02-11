using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;

namespace Microsoft.UI.Xaml.Controls;

public class Expander : ContentControl
{
	private readonly string c_expanderHeader = "ExpanderHeader";

	private readonly string c_expanderContent = "ExpanderContent";

	private readonly string c_expanderContentClip = "ExpanderContentClip";

	private SerialDisposable _eventSubscriptions = new SerialDisposable();

	public ExpandDirection ExpandDirection
	{
		get
		{
			return (ExpandDirection)GetValue(ExpandDirectionProperty);
		}
		set
		{
			SetValue(ExpandDirectionProperty, value);
		}
	}

	public static DependencyProperty ExpandDirectionProperty { get; } = DependencyProperty.Register("ExpandDirection", typeof(ExpandDirection), typeof(Expander), new FrameworkPropertyMetadata(ExpandDirection.Down, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as Expander)?.OnExpandDirectionPropertyChanged(e);
	}));


	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(Expander), new FrameworkPropertyMetadata(null));


	public DataTemplate HeaderTemplate
	{
		get
		{
			return GetValue(HeaderTemplateProperty) as DataTemplate;
		}
		set
		{
			SetValue(HeaderTemplateProperty, value);
		}
	}

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(Expander), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public DataTemplateSelector HeaderTemplateSelector
	{
		get
		{
			return GetValue(HeaderTemplateSelectorProperty) as DataTemplateSelector;
		}
		set
		{
			SetValue(HeaderTemplateSelectorProperty, value);
		}
	}

	public static DependencyProperty HeaderTemplateSelectorProperty { get; } = DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(Expander), new FrameworkPropertyMetadata(null));


	public bool IsExpanded
	{
		get
		{
			return (bool)GetValue(IsExpandedProperty);
		}
		set
		{
			SetValue(IsExpandedProperty, value);
		}
	}

	public static DependencyProperty IsExpandedProperty { get; } = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(Expander), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as Expander)?.OnIsExpandedPropertyChanged(e);
	}));


	public ExpanderTemplateSettings TemplateSettings
	{
		get
		{
			return (ExpanderTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(ExpanderTemplateSettings), typeof(Expander), new FrameworkPropertyMetadata(null));


	public event TypedEventHandler<Expander, ExpanderExpandingEventArgs> Expanding;

	public event TypedEventHandler<Expander, ExpanderCollapsedEventArgs> Collapsed;

	public Expander()
	{
		SetDefaultStyleKey(this);
		SetValue(TemplateSettingsProperty, new ExpanderTemplateSettings());
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ExpanderAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		_eventSubscriptions.Disposable = null;
		CompositeDisposable disposable = new CompositeDisposable();
		if (GetTemplateChild<Control>(c_expanderHeader) is ToggleButton element)
		{
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(element);
			if (automationPeer != null)
			{
				AutomationPeer automationPeer2 = FrameworkElementAutomationPeer.FromElement(this);
				if (string.IsNullOrEmpty(AutomationProperties.GetName(this)) && !string.IsNullOrEmpty(automationPeer.GetName()))
				{
					AutomationProperties.SetName(this, automationPeer.GetName());
				}
			}
		}
		Border templateChild = GetTemplateChild<Border>(c_expanderContentClip);
		if (templateChild != null)
		{
			Visual elementVisual = ElementCompositionPreview.GetElementVisual(templateChild);
			elementVisual.Clip = elementVisual.Compositor.CreateInsetClip();
		}
		Border expanderContent = GetTemplateChild<Border>(c_expanderContent);
		if (expanderContent != null)
		{
			expanderContent.SizeChanged += OnContentSizeChanged;
			disposable.Add(delegate
			{
				expanderContent.SizeChanged -= OnContentSizeChanged;
			});
		}
		UpdateExpandState(useTransitions: false);
		UpdateExpandDirection(useTransitions: false);
		_eventSubscriptions.Disposable = disposable;
	}

	protected void OnContentSizeChanged(object sender, SizeChangedEventArgs args)
	{
		ExpanderTemplateSettings templateSettings = TemplateSettings;
		double num = (templateSettings.ContentHeight = args.NewSize.Height);
		templateSettings.NegativeContentHeight = -1.0 * num;
	}

	protected void RaiseExpandingEvent(Expander container)
	{
		this.Expanding?.Invoke(this, new ExpanderExpandingEventArgs());
	}

	protected void RaiseCollapsedEvent(Expander container)
	{
		this.Collapsed?.Invoke(this, new ExpanderCollapsedEventArgs());
	}

	protected void OnIsExpandedPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		bool isExpanded = IsExpanded;
		if (isExpanded)
		{
			RaiseExpandingEvent(this);
		}
		UpdateExpandState(useTransitions: true);
		if (!isExpanded)
		{
			RaiseCollapsedEvent(this);
		}
	}

	protected void OnExpandDirectionPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateExpandDirection(useTransitions: true);
	}

	private void UpdateExpandDirection(bool useTransitions)
	{
		switch (ExpandDirection)
		{
		case ExpandDirection.Down:
			VisualStateManager.GoToState(this, "Down", useTransitions);
			break;
		case ExpandDirection.Up:
			VisualStateManager.GoToState(this, "Up", useTransitions);
			break;
		}
	}

	private void UpdateExpandState(bool useTransitions)
	{
		bool isExpanded = IsExpanded;
		ExpandDirection expandDirection = ExpandDirection;
		if (isExpanded)
		{
			if (expandDirection == ExpandDirection.Down)
			{
				VisualStateManager.GoToState(this, "ExpandDown", useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, "ExpandUp", useTransitions);
			}
		}
		else if (expandDirection == ExpandDirection.Down)
		{
			VisualStateManager.GoToState(this, "CollapseUp", useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "CollapseDown", useTransitions);
		}
		AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
		if (automationPeer != null && automationPeer is ExpanderAutomationPeer expanderAutomationPeer)
		{
			expanderAutomationPeer.RaiseExpandCollapseAutomationEvent(isExpanded ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
		}
	}
}

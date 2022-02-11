using System;
using System.Collections;
using System.Collections.Specialized;
using Microsoft.UI.Xaml.Controls;
using Uno;
using Uno.Disposables;
using Uno.UI.DataBinding;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Children")]
public class Panel : FrameworkElement, ICustomClippingElement, IPanel, IEnumerable
{
	private new UIElementCollection _children;

	private PanelTransitionHelper _transitionHelper;

	private ManagedWeakReference _itemsOwnerRef;

	private readonly SerialDisposable _borderBrushChanged = new SerialDisposable();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public BrushTransition BackgroundTransition
	{
		get
		{
			throw new NotImplementedException("The member BrushTransition Panel.BackgroundTransition is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Panel", "BrushTransition Panel.BackgroundTransition");
		}
	}

	public UIElementCollection Children => _children;

	public TransitionCollection ChildrenTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(ChildrenTransitionsProperty);
		}
		set
		{
			SetValue(ChildrenTransitionsProperty, value);
		}
	}

	public static DependencyProperty ChildrenTransitionsProperty { get; } = DependencyProperty.Register("ChildrenTransitions", typeof(TransitionCollection), typeof(Panel), new FrameworkPropertyMetadata(null, OnChildrenTransitionsChanged));


	internal Thickness PaddingInternal { get; set; }

	internal Thickness BorderThicknessInternal { get; set; }

	internal Brush BorderBrushInternal { get; set; }

	internal CornerRadius CornerRadiusInternal { get; set; }

	public static DependencyProperty IsItemsHostProperty { get; } = DependencyProperty.Register("IsItemsHost", typeof(bool), typeof(Panel), new FrameworkPropertyMetadata(false));


	public bool IsItemsHost
	{
		get
		{
			return (bool)GetValue(IsItemsHostProperty);
		}
		private set
		{
			SetValue(IsItemsHostProperty, value);
		}
	}

	internal ItemsControl ItemsOwner
	{
		get
		{
			return _itemsOwnerRef.Target as ItemsControl;
		}
		set
		{
			WeakReferencePool.ReturnWeakReference(this, _itemsOwnerRef);
			_itemsOwnerRef = WeakReferencePool.RentWeakReference(this, value);
		}
	}

	bool ICustomClippingElement.AllowClippingToLayoutSlot => true;

	bool ICustomClippingElement.ForceClippingToLayoutSlot => CornerRadiusInternal != CornerRadius.None;

	private void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		OnChildrenChanged();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		_children.CollectionChanged += OnChildrenCollectionChanged;
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		_children.CollectionChanged -= OnChildrenCollectionChanged;
	}

	private protected virtual void OnChildAdded(IFrameworkElement element)
	{
		UpdateTransitions(element);
	}

	private void UpdateTransitions(IFrameworkElement element)
	{
		if (_transitionHelper != null)
		{
			_transitionHelper.AddElement(element);
		}
	}

	private static void OnChildrenTransitionsChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is Panel panel && panel._transitionHelper == null)
		{
			panel._transitionHelper = new PanelTransitionHelper(panel);
		}
	}

	internal void SetItemsOwner(ItemsControl itemsOwner)
	{
		ItemsOwner = itemsOwner;
		IsItemsHost = itemsOwner != null;
	}

	protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		OnCornerRadiusChangedPartial(oldValue, newValue);
	}

	private void OnCornerRadiusChangedPartial(CornerRadius oldValue, CornerRadius newValue)
	{
		SetCornerRadius(newValue);
	}

	protected virtual void OnPaddingChanged(Thickness oldValue, Thickness newValue)
	{
		OnPaddingChangedPartial(oldValue, newValue);
	}

	private void OnPaddingChangedPartial(Thickness oldValue, Thickness newValue)
	{
		UpdateBorder();
	}

	protected virtual void OnBorderThicknessChanged(Thickness oldValue, Thickness newValue)
	{
		OnBorderThicknessChangedPartial(oldValue, newValue);
	}

	private void OnBorderThicknessChangedPartial(Thickness oldValue, Thickness newValue)
	{
		UpdateBorder();
	}

	protected virtual void OnBorderBrushChanged(Brush oldValue, Brush newValue)
	{
		OnBorderBrushChangedPartial(oldValue, newValue);
	}

	private void OnBorderBrushChangedPartial(Brush oldValue, Brush newValue)
	{
		_borderBrushChanged.Disposable = null;
		if (newValue != null && newValue.SupportsAssignAndObserveBrush)
		{
			_borderBrushChanged.Disposable = Brush.AssignAndObserveBrush(newValue, delegate
			{
				UpdateBorder();
			});
		}
		UpdateBorder();
	}

	private protected override Thickness GetBorderThickness()
	{
		return BorderThicknessInternal;
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}

	private protected void OnBackgroundSizingChangedInnerPanel(DependencyPropertyChangedEventArgs e)
	{
		base.OnBackgroundSizingChangedInner(e);
		UpdateBorder();
	}

	private void UpdateBorder()
	{
		SetBorder(BorderThicknessInternal, BorderBrushInternal);
	}

	public Panel()
	{
		Initialize();
	}

	private void Initialize()
	{
		_children = new UIElementCollection(this);
	}

	protected virtual void OnChildrenChanged()
	{
		UpdateBorder();
	}

	public void Add(UIElement view)
	{
		Children.Add(view);
	}

	public new IEnumerator GetEnumerator()
	{
		return GetChildren().GetEnumerator();
	}

	protected override void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnBackgroundChanged(e);
		UpdateHitTest();
	}
}

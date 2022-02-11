using System;
using System.Collections.Generic;
using Uno.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class NativePopupBase : Popup
{
	private Dictionary<DependencyProperty, DependencyProperty> _forwardedProperties = new Dictionary<DependencyProperty, DependencyProperty>();

	public new bool IsOpen
	{
		get
		{
			return GetIsOpenValue();
		}
		set
		{
			SetIsOpenValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = false, LocalCache = false, ChangedCallback = true)]
	public new static DependencyProperty IsOpenProperty { get; } = CreateIsOpenProperty();


	public new UIElement Child
	{
		get
		{
			return GetChildValue();
		}
		set
		{
			SetChildValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null, LocalCache = false, ChangedCallback = true)]
	public new static DependencyProperty ChildProperty { get; } = CreateChildProperty();


	public new bool IsLightDismissEnabled
	{
		get
		{
			return GetIsLightDismissEnabledValue();
		}
		set
		{
			SetIsLightDismissEnabledValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = false, LocalCache = false, ChangedCallback = true)]
	public new static DependencyProperty IsLightDismissEnabledProperty { get; } = CreateIsLightDismissEnabledProperty();


	public new double HorizontalOffset
	{
		get
		{
			return GetHorizontalOffsetValue();
		}
		set
		{
			SetHorizontalOffsetValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 0.0, LocalCache = false, ChangedCallback = true)]
	public new static DependencyProperty HorizontalOffsetProperty { get; } = CreateHorizontalOffsetProperty();


	public new double VerticalOffset
	{
		get
		{
			return GetVerticalOffsetValue();
		}
		set
		{
			SetVerticalOffsetValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 0.0, LocalCache = false, ChangedCallback = true)]
	public new static DependencyProperty VerticalOffsetProperty { get; } = CreateVerticalOffsetProperty();


	public new event EventHandler<object> Closed
	{
		add
		{
			base.Closed += value;
		}
		remove
		{
			base.Closed -= value;
		}
	}

	public new event EventHandler<object> Opened
	{
		add
		{
			base.Opened += value;
		}
		remove
		{
			base.Opened -= value;
		}
	}

	public NativePopupBase()
	{
		RegisterDependencyPropertyForward(IsOpenProperty, Popup.IsOpenProperty);
		RegisterDependencyPropertyForward(ChildProperty, Popup.ChildProperty);
		RegisterDependencyPropertyForward(IsLightDismissEnabledProperty, Popup.IsLightDismissEnabledProperty);
		RegisterDependencyPropertyForward(HorizontalOffsetProperty, Popup.HorizontalOffsetProperty);
		RegisterDependencyPropertyForward(VerticalOffsetProperty, Popup.VerticalOffsetProperty);
	}

	private protected void RegisterDependencyPropertyForward(DependencyProperty property, DependencyProperty baseProperty)
	{
		this.SetValue(property, GetValue(baseProperty), DependencyPropertyValuePrecedences.Local);
		RegisterPropertyChangedCallback(baseProperty, OnBasePropertyChanged);
		_forwardedProperties[baseProperty] = property;
	}

	private void OnBasePropertyChanged(DependencyObject sender, DependencyProperty dp)
	{
		if (_forwardedProperties.TryGetValue(dp, out var value))
		{
			SetValue(value, GetValue(dp));
		}
	}

	private new void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		base.IsOpen = newValue;
	}

	private new void OnChildChanged(UIElement oldValue, UIElement newValue)
	{
		base.Child = newValue;
	}

	private new void OnIsLightDismissEnabledChanged(bool oldValue, bool newValue)
	{
		base.IsLightDismissEnabled = newValue;
	}

	private new void OnHorizontalOffsetChanged(double oldValue, double newValue)
	{
		base.HorizontalOffset = newValue;
	}

	private new void OnVerticalOffsetChanged(double oldValue, double newValue)
	{
		base.VerticalOffset = newValue;
	}

	private bool GetIsOpenValue()
	{
		return (bool)GetValue(IsOpenProperty);
	}

	private void SetIsOpenValue(bool value)
	{
		SetValue(IsOpenProperty, value);
	}

	private static DependencyProperty CreateIsOpenProperty()
	{
		return DependencyProperty.Register("IsOpen", typeof(bool), typeof(NativePopupBase), new FrameworkPropertyMetadata(false, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((NativePopupBase)instance).OnIsOpenChanged((bool)args.OldValue, (bool)args.NewValue);
		}));
	}

	private UIElement GetChildValue()
	{
		return (UIElement)GetValue(ChildProperty);
	}

	private void SetChildValue(UIElement value)
	{
		SetValue(ChildProperty, value);
	}

	private static DependencyProperty CreateChildProperty()
	{
		return DependencyProperty.Register("Child", typeof(UIElement), typeof(NativePopupBase), new FrameworkPropertyMetadata(null, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((NativePopupBase)instance).OnChildChanged((UIElement)args.OldValue, (UIElement)args.NewValue);
		}));
	}

	private bool GetIsLightDismissEnabledValue()
	{
		return (bool)GetValue(IsLightDismissEnabledProperty);
	}

	private void SetIsLightDismissEnabledValue(bool value)
	{
		SetValue(IsLightDismissEnabledProperty, value);
	}

	private static DependencyProperty CreateIsLightDismissEnabledProperty()
	{
		return DependencyProperty.Register("IsLightDismissEnabled", typeof(bool), typeof(NativePopupBase), new FrameworkPropertyMetadata(false, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((NativePopupBase)instance).OnIsLightDismissEnabledChanged((bool)args.OldValue, (bool)args.NewValue);
		}));
	}

	private double GetHorizontalOffsetValue()
	{
		return (double)GetValue(HorizontalOffsetProperty);
	}

	private void SetHorizontalOffsetValue(double value)
	{
		SetValue(HorizontalOffsetProperty, value);
	}

	private static DependencyProperty CreateHorizontalOffsetProperty()
	{
		return DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(NativePopupBase), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((NativePopupBase)instance).OnHorizontalOffsetChanged((double)args.OldValue, (double)args.NewValue);
		}));
	}

	private double GetVerticalOffsetValue()
	{
		return (double)GetValue(VerticalOffsetProperty);
	}

	private void SetVerticalOffsetValue(double value)
	{
		SetValue(VerticalOffsetProperty, value);
	}

	private static DependencyProperty CreateVerticalOffsetProperty()
	{
		return DependencyProperty.Register("VerticalOffset", typeof(double), typeof(NativePopupBase), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((NativePopupBase)instance).OnVerticalOffsetChanged((double)args.OldValue, (double)args.NewValue);
		}));
	}
}

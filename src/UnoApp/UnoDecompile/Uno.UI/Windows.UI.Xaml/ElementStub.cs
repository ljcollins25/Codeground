using System;
using Uno.Extensions;
using Uno.Foundation.Logging;

namespace Windows.UI.Xaml;

public class ElementStub : FrameworkElement
{
	public delegate void MaterializationChangedHandler(ElementStub sender);

	public delegate void MaterializingChangedHandler(ElementStub sender);

	private object _content;

	private bool _isMaterializing;

	public static readonly DependencyProperty LoadProperty = DependencyProperty.Register("Load", typeof(bool), typeof(ElementStub), new FrameworkPropertyMetadata(false, OnLoadChanged));

	public bool Load
	{
		get
		{
			return (bool)GetValue(LoadProperty);
		}
		set
		{
			SetValue(LoadProperty, value);
		}
	}

	public bool IsMaterialized => _content != null;

	public Func<object> ContentBuilder { get; set; }

	public event MaterializationChangedHandler MaterializationChanged;

	public event MaterializationChangedHandler Materializing;

	public ElementStub(Func<object> contentBuilder)
		: this()
	{
		ContentBuilder = contentBuilder;
	}

	public ElementStub()
	{
		base.Visibility = Visibility.Collapsed;
	}

	private static void OnLoadChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if ((bool)args.NewValue)
		{
			((ElementStub)dependencyObject).Materialize();
		}
		else
		{
			((ElementStub)dependencyObject).Dematerialize();
		}
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		base.OnVisibilityChanged(oldValue, newValue);
		if (ContentBuilder != null && oldValue == Visibility.Collapsed && newValue == Visibility.Visible && base.Parent != null)
		{
			Materialize(isVisibilityChanged: true);
		}
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (ContentBuilder != null && base.Visibility == Visibility.Visible)
		{
			Materialize();
		}
	}

	public void Materialize()
	{
		Materialize(isVisibilityChanged: false);
	}

	private void RaiseMaterializing()
	{
		if (_isMaterializing)
		{
			this.Materializing?.Invoke(this);
		}
	}

	private void Materialize(bool isVisibilityChanged)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"ElementStub.Materialize(isVibilityChanged: {isVisibilityChanged})");
		}
		if (_content == null && !_isMaterializing)
		{
			_isMaterializing = true;
			_content = SwapViews(this, ContentBuilder);
			DependencyObject dependencyObject = _content as DependencyObject;
			if (isVisibilityChanged && dependencyObject != null)
			{
				DependencyProperty visibilityProperty = GetVisibilityProperty(_content);
				DependencyPropertyValuePrecedences currentHighestValuePrecedence = this.GetCurrentHighestValuePrecedence(visibilityProperty);
				dependencyObject.SetValue(visibilityProperty, Visibility.Visible, currentHighestValuePrecedence);
			}
			this.MaterializationChanged?.Invoke(this);
			_isMaterializing = false;
		}
	}

	private void Dematerialize()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug("ElementStub.Dematerialize()");
		}
		if (_content != null)
		{
			FrameworkElement frameworkElement = SwapViews((FrameworkElement)_content, () => this);
			if (frameworkElement != null)
			{
				_content = null;
			}
			this.MaterializationChanged?.Invoke(this);
		}
	}

	private static DependencyProperty GetVisibilityProperty(object view)
	{
		if (view is FrameworkElement)
		{
			return UIElement.VisibilityProperty;
		}
		return DependencyProperty.GetProperty(view.GetType(), "Visibility");
	}

	private FrameworkElement SwapViews(FrameworkElement oldView, Func<object> newViewProvider)
	{
		if (oldView?.Parent is FrameworkElement frameworkElement)
		{
			int num = frameworkElement.GetChildren().IndexOf(oldView);
			if (num != -1)
			{
				FrameworkElement frameworkElement2 = (FrameworkElement)newViewProvider();
				frameworkElement.RemoveChild(oldView);
				RaiseMaterializing();
				frameworkElement.AddChild(frameworkElement2, num);
				return frameworkElement2;
			}
		}
		return null;
	}
}

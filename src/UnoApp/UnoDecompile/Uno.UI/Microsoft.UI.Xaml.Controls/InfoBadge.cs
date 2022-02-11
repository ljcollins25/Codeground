using System;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class InfoBadge : Control
{
	private const string IconPresenterName = "IconPresenter";

	public int Value
	{
		get
		{
			return (int)GetValue(ValueProperty);
		}
		set
		{
			SetValue(ValueProperty, value);
		}
	}

	public static DependencyProperty ValueProperty { get; } = DependencyProperty.Register("Value", typeof(int), typeof(InfoBadge), new FrameworkPropertyMetadata(-1, OnPropertyChanged));


	public InfoBadgeTemplateSettings TemplateSettings
	{
		get
		{
			return (InfoBadgeTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(InfoBadgeTemplateSettings), typeof(InfoBadge), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public IconSource IconSource
	{
		get
		{
			return (IconSource)GetValue(IconSourceProperty);
		}
		set
		{
			SetValue(IconSourceProperty, value);
		}
	}

	public static DependencyProperty IconSourceProperty { get; } = DependencyProperty.Register("IconSource", typeof(IconSource), typeof(InfoBadge), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public InfoBadge()
	{
		base.DefaultStyleKey = typeof(InfoBadge);
		SetValue(TemplateSettingsProperty, new InfoBadgeTemplateSettings());
		base.SizeChanged += OnSizeChanged;
	}

	protected override void OnApplyTemplate()
	{
		OnDisplayKindPropertiesChanged();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size result = base.MeasureOverride(availableSize);
		if (result.Width < result.Height)
		{
			return new Size(result.Height, result.Height);
		}
		return result;
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == ValueProperty && Value < -1)
		{
			throw new ArgumentOutOfRangeException("Value must be equal to or greater than -1");
		}
		if (property == ValueProperty || property == IconSourceProperty)
		{
			OnDisplayKindPropertiesChanged();
		}
	}

	private void OnDisplayKindPropertiesChanged()
	{
		if (Value >= 0)
		{
			VisualStateManager.GoToState(this, "Value", useTransitions: true);
			return;
		}
		IconSource iconSource = IconSource;
		if (iconSource != null)
		{
			TemplateSettings.IconElement = iconSource.CreateIconElement();
			if (iconSource is FontIconSource)
			{
				VisualStateManager.GoToState(this, "FontIcon", useTransitions: true);
			}
			else
			{
				VisualStateManager.GoToState(this, "Icon", useTransitions: true);
			}
		}
		else
		{
			VisualStateManager.GoToState(this, "Dot", useTransitions: true);
		}
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		CornerRadius infoBadgeCornerRadius = GetCornerRadius();
		TemplateSettings.InfoBadgeCornerRadius = infoBadgeCornerRadius;
		CornerRadius GetCornerRadius()
		{
			double num = base.ActualHeight / 2.0;
			if (SharedHelpers.IsRS5OrHigher())
			{
				if (ReadLocalValue(Control.CornerRadiusProperty) == DependencyProperty.UnsetValue)
				{
					return new CornerRadius(num, num, num, num);
				}
				return default(CornerRadius);
			}
			return new CornerRadius(num, num, num, num);
		}
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		InfoBadge infoBadge = (InfoBadge)sender;
		infoBadge.OnPropertyChanged(args);
	}
}

using System;

namespace Windows.UI.Xaml.Controls.Primitives;

public class PickerFlyoutBase : FlyoutBase
{
	public static DependencyProperty TitleProperty { get; } = DependencyProperty.RegisterAttached("Title", typeof(string), typeof(PickerFlyoutBase), new FrameworkPropertyMetadata((object)null));


	public static string GetTitle(DependencyObject element)
	{
		return (string)element.GetValue(TitleProperty);
	}

	public static void SetTitle(DependencyObject element, string value)
	{
		element.SetValue(TitleProperty, value);
	}

	protected virtual void OnConfirmed()
	{
		throw new InvalidOperationException();
	}

	protected virtual bool ShouldShowConfirmationButtons()
	{
		throw new InvalidOperationException();
	}

	protected override void InitializePopupPanel()
	{
	}
}

using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class CommandingHelpers
{
	private class IconSourceToIconSourceElementConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null)
			{
				IconSourceElement iconSourceElement = new IconSourceElement();
				IconSource iconSource2 = (iconSourceElement.IconSource = value as IconSource);
				return iconSourceElement;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	private class KeyboardAcceleratorCopyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null)
			{
				DependencyObjectCollection<KeyboardAccelerator> result = new DependencyObjectCollection<KeyboardAccelerator>();
				IList<KeyboardAccelerator> list = value as IList<KeyboardAccelerator>;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					KeyboardAccelerator source = list[i];
					KeyboardAccelerator keyboardAccelerator = new KeyboardAccelerator();
					keyboardAccelerator.SetBinding(KeyboardAccelerator.IsEnabledProperty, new Binding
					{
						Path = "IsEnabled",
						Source = source
					});
					keyboardAccelerator.SetBinding(KeyboardAccelerator.KeyProperty, new Binding
					{
						Path = "Key",
						Source = source
					});
					keyboardAccelerator.SetBinding(KeyboardAccelerator.ModifiersProperty, new Binding
					{
						Path = "Modifiers",
						Source = source
					});
					keyboardAccelerator.SetBinding(KeyboardAccelerator.ScopeOwnerProperty, new Binding
					{
						Path = "ScopeOwner",
						Source = source
					});
				}
				return result;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	internal static void BindToLabelPropertyIfUnset(ICommand uiCommand, DependencyObject target, DependencyProperty labelProperty)
	{
		string value = null;
		object obj = target.ReadLocalValue(labelProperty);
		if (obj != null)
		{
			value = obj.ToString();
		}
		if ((obj == DependencyProperty.UnsetValue || string.IsNullOrEmpty(value)) && target is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			dependencyObjectStoreProvider.Store.SetBinding(labelProperty, new Binding
			{
				Path = "Label",
				Source = uiCommand
			});
		}
	}

	internal static void BindToIconPropertyIfUnset(XamlUICommand uiCommand, DependencyObject target, DependencyProperty iconProperty)
	{
		object obj = target.ReadLocalValue(iconProperty);
		IconElement iconElement = obj as IconElement;
		if ((obj == DependencyProperty.UnsetValue || iconElement == null) && target is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			IconSourceToIconSourceElementConverter converter = new IconSourceToIconSourceElementConverter();
			dependencyObjectStoreProvider.Store.SetBinding(iconProperty, new Binding
			{
				Path = "IconSource",
				Source = uiCommand,
				Converter = converter
			});
		}
	}

	internal static void BindToIconSourcePropertyIfUnset(XamlUICommand uiCommand, DependencyObject target, DependencyProperty iconSourceProperty)
	{
		object obj = target.ReadLocalValue(iconSourceProperty);
		IconSource iconSource = obj as IconSource;
		if ((obj == DependencyProperty.UnsetValue || iconSource == null) && target is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			dependencyObjectStoreProvider.Store.SetBinding(iconSourceProperty, new Binding
			{
				Path = "IconSource",
				Source = uiCommand
			});
		}
	}

	internal static void BindToKeyboardAcceleratorsIfUnset(XamlUICommand uiCommand, UIElement target)
	{
		IList<KeyboardAccelerator> keyboardAccelerators = target.KeyboardAccelerators;
		if (keyboardAccelerators.Count == 0)
		{
			KeyboardAcceleratorCopyConverter converter = new KeyboardAcceleratorCopyConverter();
			target.SetBinding(UIElement.KeyboardAcceleratorsProperty, new Binding
			{
				Path = "KeyboardAccelerators",
				Source = uiCommand,
				Converter = converter
			});
		}
	}

	internal static void BindToAccessKeyIfUnset(XamlUICommand uiCommand, UIElement target)
	{
		string accessKey = target.AccessKey;
		if (accessKey == null || string.IsNullOrEmpty(accessKey))
		{
			target.SetBinding(UIElement.AccessKeyProperty, new Binding
			{
				Path = "AccessKey",
				Source = uiCommand
			});
		}
	}

	internal static void BindToDescriptionPropertiesIfUnset(XamlUICommand uiCommand, FrameworkElement target)
	{
		string helpText = AutomationProperties.GetHelpText(target);
		if (helpText == null || string.IsNullOrEmpty(helpText))
		{
			target.SetBinding(AutomationProperties.HelpTextProperty, new Binding
			{
				Path = "Description",
				Source = uiCommand
			});
		}
		object toolTip = ToolTipService.GetToolTip(target);
		string text = null;
		ToolTip toolTip2 = null;
		if (toolTip != null)
		{
			text = toolTip.ToString();
			toolTip2 = toolTip as ToolTip;
		}
		if ((text == null || string.IsNullOrEmpty(text)) && toolTip2 == null)
		{
			target.SetBinding(ToolTipService.ToolTipProperty, new Binding
			{
				Path = "Description",
				Source = uiCommand
			});
		}
	}

	internal static void ClearBindingIfSet(ICommand uiCommand, FrameworkElement target, DependencyProperty targetProperty)
	{
		BindingExpression bindingExpression = target.GetBindingExpression(targetProperty);
		if (bindingExpression != null)
		{
			object source = bindingExpression.ParentBinding.Source;
			if (source != null && source == uiCommand)
			{
				target.ClearValue(targetProperty);
			}
		}
	}
}

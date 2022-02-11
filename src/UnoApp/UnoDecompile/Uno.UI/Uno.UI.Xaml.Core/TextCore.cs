using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Xaml.Core;

internal class TextCore
{
	private static readonly Lazy<TextCore> _instance = new Lazy<TextCore>(() => new TextCore());

	internal static TextCore Instance => _instance.Value;

	private TextCore()
	{
	}

	internal static bool IsTextControl(DependencyObject? dependencyObject)
	{
		if (!(dependencyObject is TextBlock) && !(dependencyObject is RichTextBlock) && !(dependencyObject is RichTextBlockOverflow) && !(dependencyObject is RichEditBox) && !(dependencyObject is TextBox))
		{
			return dependencyObject is PasswordBox;
		}
		return true;
	}

	internal void ClearLastSelectedTextElement()
	{
	}
}

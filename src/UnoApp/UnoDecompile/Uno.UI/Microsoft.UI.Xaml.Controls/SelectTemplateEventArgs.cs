using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public sealed class SelectTemplateEventArgs
{
	public string TemplateKey { get; set; }

	public object DataContext { get; internal set; }

	public UIElement Owner { get; internal set; }

	internal SelectTemplateEventArgs()
	{
	}
}

using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Documents;

public abstract class Inline : TextElement
{
	internal void InvalidateInlines()
	{
		object parent = this.GetParent();
		if (!(parent is Span span))
		{
			if (parent is TextBlock textBlock)
			{
				textBlock.InvalidateInlines();
			}
		}
		else
		{
			span.InvalidateInlines();
		}
	}

	protected Inline(string htmlTag = "span")
		: base(htmlTag)
	{
	}
}

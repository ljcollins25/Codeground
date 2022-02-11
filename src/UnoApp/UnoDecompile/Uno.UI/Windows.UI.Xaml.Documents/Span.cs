using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Documents;

[ContentProperty(Name = "Inlines")]
public class Span : Inline
{
	public InlineCollection Inlines { get; set; }

	public Span()
		: this("span")
	{
	}

	public Span(string htmlTag)
		: base(htmlTag)
	{
		Inlines = new InlineCollection(this);
	}
}

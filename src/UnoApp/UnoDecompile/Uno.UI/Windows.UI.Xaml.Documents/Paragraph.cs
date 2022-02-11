using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Documents;

[ContentProperty(Name = "Inlines")]
public class Paragraph : Block
{
	public double TextIndent
	{
		get
		{
			return (double)GetValue(TextIndentProperty);
		}
		set
		{
			SetValue(TextIndentProperty, value);
		}
	}

	public InlineCollection Inlines { get; }

	public static DependencyProperty TextIndentProperty { get; } = DependencyProperty.Register("TextIndent", typeof(double), typeof(Paragraph), new FrameworkPropertyMetadata(0.0));


	public Paragraph()
	{
		Inlines = new InlineCollection(this);
	}
}

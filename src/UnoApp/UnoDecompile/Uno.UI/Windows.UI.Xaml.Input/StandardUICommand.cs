namespace Windows.UI.Xaml.Input;

public class StandardUICommand : XamlUICommand
{
	public StandardUICommandKind Kind { get; set; }

	public static DependencyProperty KindProperty { get; } = DependencyProperty.Register("Kind", typeof(StandardUICommandKind), typeof(StandardUICommand), new FrameworkPropertyMetadata(StandardUICommandKind.None));


	public StandardUICommand()
	{
	}

	public StandardUICommand(StandardUICommandKind kind)
	{
		Kind = kind;
	}
}

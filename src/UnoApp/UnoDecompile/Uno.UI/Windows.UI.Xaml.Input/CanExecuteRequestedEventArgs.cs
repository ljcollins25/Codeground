namespace Windows.UI.Xaml.Input;

public class CanExecuteRequestedEventArgs
{
	public bool CanExecute { get; set; }

	public object Parameter { get; internal set; }
}

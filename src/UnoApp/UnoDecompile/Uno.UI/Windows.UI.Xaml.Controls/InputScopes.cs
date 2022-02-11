using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class InputScopes
{
	public static InputScope Default => Convert(InputScopeNameValue.Default);

	public static InputScope Number => Convert(InputScopeNameValue.Number);

	public static InputScope NumericPin => Convert(InputScopeNameValue.NumericPin);

	public static InputScope NumberFullWidth => Convert(InputScopeNameValue.NumberFullWidth);

	public static InputScope Url => Convert(InputScopeNameValue.Url);

	public static InputScope TelephoneNumber => Convert(InputScopeNameValue.TelephoneNumber);

	public static InputScope Search => Convert(InputScopeNameValue.Search);

	public static InputScope EmailSmtpAddress => Convert(InputScopeNameValue.EmailSmtpAddress);

	private static InputScope Convert(InputScopeNameValue inputScopeNameValue)
	{
		InputScope inputScope = new InputScope();
		inputScope.Names.Add(new InputScopeName(inputScopeNameValue));
		return inputScope;
	}
}

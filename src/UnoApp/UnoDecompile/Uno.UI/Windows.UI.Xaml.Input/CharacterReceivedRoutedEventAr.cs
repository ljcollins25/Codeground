using Uno.UI.Xaml.Input;
using Windows.UI.Core;

namespace Windows.UI.Xaml.Input;

public class CharacterReceivedRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	public bool Handled { get; set; }

	bool IHandleableRoutedEventArgs.Handled
	{
		get
		{
			return Handled;
		}
		set
		{
			Handled = value;
		}
	}

	public char Character { get; }

	public CorePhysicalKeyStatus KeyStatus { get; }

	internal CharacterReceivedRoutedEventArgs(char character, CorePhysicalKeyStatus keyStatus)
	{
		Character = character;
		KeyStatus = keyStatus;
	}
}

using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class InertiaExpansionBehavior
{
	private readonly GestureRecognizer.Manipulation.InertiaProcessor _processor;

	public double DesiredExpansion
	{
		get
		{
			return _processor.DesiredExpansion;
		}
		set
		{
			_processor.DesiredExpansion = value;
		}
	}

	public double DesiredDeceleration
	{
		get
		{
			return _processor.DesiredExpansionDeceleration;
		}
		set
		{
			_processor.DesiredExpansionDeceleration = value;
		}
	}

	internal InertiaExpansionBehavior(GestureRecognizer.Manipulation.InertiaProcessor processor)
	{
		_processor = processor;
	}
}

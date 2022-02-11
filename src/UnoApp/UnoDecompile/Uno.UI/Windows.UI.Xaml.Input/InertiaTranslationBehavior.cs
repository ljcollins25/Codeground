using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class InertiaTranslationBehavior
{
	private readonly GestureRecognizer.Manipulation.InertiaProcessor _processor;

	public double DesiredDisplacement
	{
		get
		{
			return _processor.DesiredDisplacement;
		}
		set
		{
			_processor.DesiredDisplacement = value;
		}
	}

	public double DesiredDeceleration
	{
		get
		{
			return _processor.DesiredDisplacementDeceleration;
		}
		set
		{
			_processor.DesiredDisplacementDeceleration = value;
		}
	}

	internal InertiaTranslationBehavior(GestureRecognizer.Manipulation.InertiaProcessor processor)
	{
		_processor = processor;
	}
}

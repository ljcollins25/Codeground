using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class InertiaRotationBehavior
{
	private readonly GestureRecognizer.Manipulation.InertiaProcessor _processor;

	public double DesiredRotation
	{
		get
		{
			return _processor.DesiredRotation;
		}
		set
		{
			_processor.DesiredRotation = value;
		}
	}

	public double DesiredDeceleration
	{
		get
		{
			return _processor.DesiredRotationDeceleration;
		}
		set
		{
			_processor.DesiredRotationDeceleration = value;
		}
	}

	internal InertiaRotationBehavior(GestureRecognizer.Manipulation.InertiaProcessor processor)
	{
		_processor = processor;
	}
}

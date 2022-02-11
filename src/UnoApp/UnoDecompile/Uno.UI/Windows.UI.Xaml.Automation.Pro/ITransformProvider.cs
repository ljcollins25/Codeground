using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITransformProvider
{
	bool CanMove { get; }

	bool CanResize { get; }

	bool CanRotate { get; }

	void Move(double x, double y);

	void Resize(double width, double height);

	void Rotate(double degrees);
}

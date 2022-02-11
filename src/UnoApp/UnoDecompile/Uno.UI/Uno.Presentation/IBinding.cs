namespace Uno.Presentation;

public interface IBinding
{
	object Converter { get; set; }

	object DataContext { get; set; }

	string Path { get; }

	string TargetName { get; }

	void SetSourceValue(object value);
}

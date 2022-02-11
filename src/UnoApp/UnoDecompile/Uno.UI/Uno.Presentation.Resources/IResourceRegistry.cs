namespace Uno.Presentation.Resources;

public interface IResourceRegistry
{
	object FindResource(string name);

	object GetResource(string name);
}

using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IStylesProvider
{
	string ExtendedProperties { get; }

	Color FillColor { get; }

	Color FillPatternColor { get; }

	string FillPatternStyle { get; }

	string Shape { get; }

	int StyleId { get; }

	string StyleName { get; }
}

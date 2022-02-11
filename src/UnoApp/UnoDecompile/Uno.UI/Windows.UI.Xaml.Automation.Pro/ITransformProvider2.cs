using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITransformProvider2 : ITransformProvider
{
	bool CanZoom { get; }

	double MaxZoom { get; }

	double MinZoom { get; }

	double ZoomLevel { get; }

	void Zoom(double zoom);

	void ZoomByUnit(ZoomUnit zoomUnit);
}

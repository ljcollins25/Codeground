using System;
using Windows.Foundation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml;

internal interface IFrameworkElement : IDataContextProvider, DependencyObject, IDependencyObjectParse
{
	DependencyObject Parent { get; }

	string Name { get; set; }

	bool IsEnabled { get; set; }

	Visibility Visibility { get; set; }

	Thickness Margin { get; set; }

	double Width { get; set; }

	double Height { get; set; }

	double MinWidth { get; set; }

	double MinHeight { get; set; }

	double MaxWidth { get; set; }

	double MaxHeight { get; set; }

	double ActualWidth { get; }

	double ActualHeight { get; }

	double Opacity { get; set; }

	Style Style { get; set; }

	Brush Background { get; set; }

	Transform RenderTransform { get; set; }

	Point RenderTransformOrigin { get; set; }

	TransitionCollection Transitions { get; set; }

	HorizontalAlignment HorizontalAlignment { get; set; }

	VerticalAlignment VerticalAlignment { get; set; }

	Uri BaseUri { get; }

	int? RenderPhase { get; set; }

	DependencyObject TemplatedParent { get; set; }

	event RoutedEventHandler Loaded;

	event RoutedEventHandler Unloaded;

	event EventHandler<object> LayoutUpdated;

	event SizeChangedEventHandler SizeChanged;

	object FindName(string name);

	Size AdjustArrange(Size finalSize);

	void ApplyBindingPhase(int phase);

	AutomationPeer GetAutomationPeer();

	string GetAccessibilityInnerText();
}

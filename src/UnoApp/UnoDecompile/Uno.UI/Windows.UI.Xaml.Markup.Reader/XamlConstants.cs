namespace Windows.UI.Xaml.Markup.Reader;

internal static class XamlConstants
{
	public static class Namespaces
	{
		public const string Controls = "Windows.UI.Xaml.Controls";

		public const string Primitives = "Windows.UI.Xaml.Controls.Primitives";

		public const string Text = "Windows.UI.Text";

		public const string Data = "Windows.UI.Xaml.Data";

		public const string XamlText = "Windows.UI.Xaml.Text";

		public const string Documents = "Windows.UI.Xaml.Documents";

		public const string Media = "Windows.UI.Xaml.Media";

		public const string MediaAnimation = "Windows.UI.Xaml.Media.Animation";

		public const string MediaImaging = "Windows.UI.Xaml.Media.Imaging";

		public const string Shapes = "Windows.UI.Xaml.Shapes";

		public static readonly string[] PresentationNamespaces = new string[16]
		{
			"Windows.UI", "Windows.UI.Xaml", "Windows.UI.Xaml.Controls", "Windows.UI.Xaml.Controls.Primitives", "Windows.UI.Xaml.Data", "Windows.UI.Xaml.Documents", "Windows.UI.Xaml.Shapes", "Windows.UI.Xaml.Media", "Windows.UI.Xaml.Media.Imaging", "Windows.UI.Xaml.Media.Animation",
			"Windows.UI", "Windows.UI.Xaml", "Windows.UI.Text", "Windows.UI.Xaml.Documents", "Windows.UI.Xaml.Text", "System"
		};

		public static readonly string[] All = new string[11]
		{
			"Windows.UI.Xaml", "Windows.UI.Xaml.Controls", "Windows.UI.Xaml.Controls.Primitives", "Windows.UI.Xaml.Data", "Windows.UI.Xaml.Documents", "Windows.UI.Xaml.Media", "Windows.UI.Xaml.Media.Imaging", "Windows.UI.Xaml.Media.Animation", "Windows.UI.Xaml.Shapes", "Windows.UI.Text",
			"Windows.UI.Xaml.Text"
		};
	}

	public static class Types
	{
		public const string Binding = "Windows.UI.Xaml.Data.Binding";

		public const string DependencyObject = "Windows.UI.Xaml.DependencyObject";

		public const string DependencyObjectExtensions = "Windows.UI.Xaml.DependencyObjectExtensions";

		public const string DependencyProperty = "Windows.UI.Xaml.DependencyProperty";

		public const string IFrameworkElement = "Windows.UI.Xaml.IFrameworkElement";

		public const string Style = "Windows.UI.Xaml.Style";

		public const string ElementStub = "Windows.UI.Xaml.ElementStub";

		public const string ContentPropertyAttribute = "Windows.UI.Xaml.Markup.ContentPropertyAttribute";

		public const string FontWeight = "Windows.UI.Text.FontWeight";

		public const string FontWeights = "Windows.UI.Text.FontWeights";

		public const string Setter = "Windows.UI.Xaml.Setter";

		public const string CornerRadius = "Windows.UI.Xaml.CornerRadius";

		public const string SolidColorBrushHelper = "Windows.UI.Xaml.SolidColorBrushHelper";

		public const string GridLength = "Windows.UI.Xaml.GridLength";

		public const string GridUnitType = "Windows.UI.Xaml.GridUnitType";

		public const string Colors = "Windows.UI.Colors";

		public const string Thickness = "Windows.UI.Xaml.Thickness";

		public const string Application = "Windows.UI.Xaml.Application";

		public const string LinearGradientBrush = "Windows.UI.Xaml.Media.LinearGradientBrush";

		public const string Brush = "Windows.UI.Xaml.Media.Brush";

		public const string SolidColorBrush = "Windows.UI.Xaml.Media.SolidColorBrush";

		public const string Geometry = "Windows.UI.Xaml.Media.Geometry";

		public const string Transform = "Windows.UI.Xaml.Media.Transform";

		public const string KeyTime = "Windows.UI.Xaml.Media.Animation.KeyTime";

		public const string Duration = "Windows.UI.Xaml.Duration";

		public const string FontFamily = "Windows.UI.Xaml.Media.FontFamily";

		public const string NativePage = "Windows.UI.Xaml.Controls.NativePage";

		public const string Border = "Windows.UI.Xaml.Controls.Border";

		public const string TextBlock = "Windows.UI.Xaml.Controls.TextBlock";

		public const string UserControl = "Windows.UI.Xaml.Controls.UserControl";

		public const string ContentControl = "Windows.UI.Xaml.Controls.ContentControl";

		public const string Control = "Windows.UI.Xaml.Controls.Control";

		public const string Panel = "Windows.UI.Xaml.Controls.Panel";

		public const string Button = "Windows.UI.Xaml.Controls.Button";

		public const string TextBox = "Windows.UI.Xaml.Controls.TextBox";

		public const string Run = "Windows.UI.Xaml.Documents.Run";

		public const string Span = "Windows.UI.Xaml.Documents.Span";
	}

	public const string XamlXmlNamespace = "http://schemas.microsoft.com/winfx/2006/xaml";

	public const string PresentationXamlXmlNamespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";

	public const string XmlXmlNamespace = "http://www.w3.org/XML/1998/namespace";

	public const string BundleResourcePrefix = "ms-appx:///";

	public const string RootFoundationNamespace = "Windows.Foundation";

	public const string RootWUINamespace = "Windows.UI";

	public const string RootMUINamespace = "Windows.UI";

	public const string BaseXamlNamespace = "Windows.UI.Xaml";

	public const string UnoXamlNamespace = "Windows.UI.Xaml";
}

using System;

namespace Windows.UI.Xaml.Media;

internal struct ImageData
{
	public ImageDataKind Kind { get; set; }

	public Exception Error { get; set; }

	internal ImageSource Source { get; set; }

	public string Value { get; set; }

	public override string ToString()
	{
		return Kind switch
		{
			ImageDataKind.Empty => "Empty", 
			ImageDataKind.Error => $"Error[{Error}]", 
			_ => $"{Kind}: {Value}", 
		};
	}
}

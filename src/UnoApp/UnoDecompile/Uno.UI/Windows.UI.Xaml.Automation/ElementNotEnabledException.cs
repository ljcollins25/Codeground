using System;

namespace Windows.UI.Xaml.Automation;

public class ElementNotEnabledException : Exception
{
	public ElementNotEnabledException()
	{
	}

	public ElementNotEnabledException(string message)
		: base(message)
	{
	}

	public ElementNotEnabledException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}

using System;

namespace Windows.UI.Xaml;

public class UnhandledExceptionEventArgs
{
	public bool Handled { get; set; }

	public Exception Exception { get; }

	public string Message { get; }

	internal bool Fatal { get; }

	public UnhandledExceptionEventArgs(Exception e, bool fatal)
	{
		Exception = e;
		Fatal = fatal;
		Message = e.Message;
	}
}

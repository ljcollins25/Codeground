using System;

namespace Uno.UI.DataBinding;

internal interface INativeObject
{
	IntPtr Handle { get; }
}

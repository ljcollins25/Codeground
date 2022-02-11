using System;

namespace Microsoft.UI.Xaml.Controls;

public class LayoutContext
{
	public object LayoutState
	{
		get
		{
			return LayoutStateCore;
		}
		set
		{
			LayoutStateCore = value;
		}
	}

	protected internal virtual object LayoutStateCore
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public int Indent => 0;
}

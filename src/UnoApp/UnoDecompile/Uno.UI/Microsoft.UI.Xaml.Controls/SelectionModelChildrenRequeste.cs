using System;

namespace Microsoft.UI.Xaml.Controls;

public class SelectionModelChildrenRequestedEventArgs
{
	private object m_source;

	private IndexPath m_sourceIndexPath;

	private bool m_throwOnAccess = true;

	public object Source
	{
		get
		{
			if (m_throwOnAccess)
			{
				throw new InvalidOperationException("Source can only be accesed in the ChildrenRequested event handler.");
			}
			return m_source;
		}
	}

	public IndexPath SourceIndex
	{
		get
		{
			if (m_throwOnAccess)
			{
				throw new InvalidOperationException("SourceIndex can only be accesed in the ChildrenRequested event handler.");
			}
			return m_sourceIndexPath;
		}
	}

	public object Children { get; set; }

	internal SelectionModelChildrenRequestedEventArgs(object source, IndexPath sourceIndexPath, bool throwOnAccess)
	{
		Initialize(source, sourceIndexPath, throwOnAccess);
	}

	internal void Initialize(object source, IndexPath sourceIndexPath, bool throwOnAccess)
	{
		m_source = source;
		m_sourceIndexPath = sourceIndexPath;
		m_throwOnAccess = throwOnAccess;
		Children = null;
	}
}

using System;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal class LayoutStrategyBase
{
	protected static int c_specialGroupIndex;

	protected static int c_specialItemIndex;

	private Orientation m_virtualizationDirection;

	private Thickness m_groupPadding;

	private GroupHeaderStrategy m_groupHeaderStrategy;

	private bool m_isWrapping;

	private bool m_useFullWidthHeaders;

	private ILayoutDataInfoProvider m_pDataInfoProviderNoRef;

	public bool IsGrouping => m_groupHeaderStrategy != GroupHeaderStrategy.None;

	public bool IsWrappingStrategy => m_isWrapping;

	public Thickness GroupPadding
	{
		get
		{
			return m_groupPadding;
		}
		set
		{
			m_groupPadding = value;
		}
	}

	public GroupHeaderStrategy GroupHeaderStrategy
	{
		get
		{
			return m_groupHeaderStrategy;
		}
		set
		{
			m_groupHeaderStrategy = value;
		}
	}

	public Orientation VirtualizationDirection
	{
		get
		{
			return m_virtualizationDirection;
		}
		set
		{
			m_virtualizationDirection = value;
		}
	}

	public bool UseFullWidthHeaders => m_useFullWidthHeaders;

	public virtual ILayoutDataInfoProvider GetLayoutDataInfoProviderNoRef
	{
		get
		{
			return m_pDataInfoProviderNoRef;
		}
		set
		{
			m_pDataInfoProviderNoRef = value;
		}
	}

	protected float PointInNonVirtualizingDirection(Point point)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)point.Y, 
			Orientation.Vertical => (float)point.X, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected float PointInVirtualizingDirection(Point point)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)point.X, 
			Orientation.Vertical => (float)point.Y, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected float SizeInNonVirtualizingDirection(Size size)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)size.Height, 
			Orientation.Vertical => (float)size.Width, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected float SizeInVirtualizingDirection(Size size)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)size.Width, 
			Orientation.Vertical => (float)size.Height, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected float PointFromRectInNonVirtualizingDirection(Rect rect)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)rect.Y, 
			Orientation.Vertical => (float)rect.X, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected float PointFromRectInVirtualizingDirection(Rect rect)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)rect.X, 
			Orientation.Vertical => (float)rect.Y, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected float SizeFromRectInNonVirtualizingDirection(Rect rect)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)rect.Height, 
			Orientation.Vertical => (float)rect.Width, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected float SizeFromRectInVirtualizingDirection(Rect rect)
	{
		return m_virtualizationDirection switch
		{
			Orientation.Horizontal => (float)rect.Width, 
			Orientation.Vertical => (float)rect.Height, 
			_ => throw new InvalidOperationException("XAML_FAIL_FAST"), 
		};
	}

	protected void SetPointInNonVirtualizingDirection(ref Point point, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			point.Y = value;
			break;
		case Orientation.Vertical:
			point.X = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected void SetPointInVirtualizingDirection(ref Point point, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			point.X = value;
			break;
		case Orientation.Vertical:
			point.Y = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected void SetSizeInNonVirtualizingDirection(ref Size size, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			size.Height = value;
			break;
		case Orientation.Vertical:
			size.Width = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected void SetSizeInVirtualizingDirection(ref Size size, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			size.Width = value;
			break;
		case Orientation.Vertical:
			size.Height = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected void SetPointFromRectInNonVirtualizingDirection(ref Rect rect, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			rect.Y = value;
			break;
		case Orientation.Vertical:
			rect.X = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected void SetPointFromRectInVirtualizingDirection(ref Rect rect, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			rect.X = value;
			break;
		case Orientation.Vertical:
			rect.Y = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected void SetSizeFromRectInNonVirtualizingDirection(ref Rect rect, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			rect.Height = value;
			break;
		case Orientation.Vertical:
			rect.Width = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected void SetSizeFromRectInVirtualizingDirection(ref Rect rect, float value)
	{
		switch (m_virtualizationDirection)
		{
		case Orientation.Horizontal:
			rect.Width = value;
			break;
		case Orientation.Vertical:
			rect.Height = value;
			break;
		default:
			throw new InvalidOperationException("XAML_FAIL_FAST");
		}
	}

	protected Size GetGroupPaddingAtStart()
	{
		return new Size((float)m_groupPadding.Left, (float)m_groupPadding.Top);
	}

	protected Size GetGroupPaddingAtEnd()
	{
		return new Size((float)m_groupPadding.Right, (float)m_groupPadding.Bottom);
	}

	protected static int GetRemainingGroups(int referenceGroupIndex, int totalGroups, RelativePosition positionOfReference)
	{
		return positionOfReference switch
		{
			RelativePosition.Before => totalGroups - referenceGroupIndex, 
			RelativePosition.After => referenceGroupIndex, 
			_ => 0, 
		};
	}

	protected static int GetRemainingItems(int referenceItemIndex, int totalItems, RelativePosition positionOfReference)
	{
		return positionOfReference switch
		{
			RelativePosition.Before => totalItems - referenceItemIndex, 
			RelativePosition.After => referenceItemIndex, 
			_ => 0, 
		};
	}

	protected RelativePosition GetReferenceDirectionFromWindow(Rect referenceRect, Rect window)
	{
		float num = PointFromRectInVirtualizingDirection(referenceRect);
		float num2 = num + SizeFromRectInVirtualizingDirection(referenceRect);
		float num3 = PointFromRectInVirtualizingDirection(window);
		float num4 = num3 + SizeFromRectInVirtualizingDirection(window);
		if (num2 < num3)
		{
			return RelativePosition.Before;
		}
		if (num4 < num)
		{
			return RelativePosition.After;
		}
		return RelativePosition.Inside;
	}

	public LayoutStrategyBase(bool useFullWidthHeaders, bool isWrapping)
	{
		m_useFullWidthHeaders = useFullWidthHeaders;
		m_isWrapping = isWrapping;
		m_pDataInfoProviderNoRef = null;
		m_virtualizationDirection = Orientation.Horizontal;
		m_groupHeaderStrategy = GroupHeaderStrategy.None;
		m_groupPadding = default(Thickness);
	}

	public void SetUseFullWidthHeaders(bool useFullWidthHeaders)
	{
		m_useFullWidthHeaders = useFullWidthHeaders;
	}
}

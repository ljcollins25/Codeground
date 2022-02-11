using System;
using Windows.Foundation;

namespace Windows.UI.Xaml.Hosting;

public class XamlSourceFocusNavigationRequest
{
	public XamlSourceFocusNavigationReason Reason { get; }

	public Rect HintRect { get; }

	public Guid CorrelationId { get; }

	public XamlSourceFocusNavigationRequest(XamlSourceFocusNavigationReason reason)
	{
		Reason = reason;
	}

	public XamlSourceFocusNavigationRequest(XamlSourceFocusNavigationReason reason, Rect hintRect)
	{
		Reason = reason;
		HintRect = hintRect;
	}

	public XamlSourceFocusNavigationRequest(XamlSourceFocusNavigationReason reason, Rect hintRect, Guid correlationId)
	{
		Reason = reason;
		HintRect = hintRect;
		CorrelationId = correlationId;
	}
}

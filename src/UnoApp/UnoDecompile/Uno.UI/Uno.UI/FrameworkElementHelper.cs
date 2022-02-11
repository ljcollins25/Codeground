using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace Uno.UI;

public static class FrameworkElementHelper
{
	private static ConditionalWeakTable<DependencyObject, object> _contextAssociation = new ConditionalWeakTable<DependencyObject, object>();

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool IsUiAutomationMappingEnabled { get; set; } = false;


	public static void SetRenderPhase(FrameworkElement target, int phase)
	{
		target.RenderPhase = phase;
	}

	public static void SetDataTemplateRenderPhases(FrameworkElement target, int[] declaredPhases)
	{
		target.DataTemplateRenderPhases = declaredPhases;
	}

	public static void SetBaseUri(FrameworkElement target, string uri)
	{
		if (target != null)
		{
			target.BaseUri = new Uri(uri);
		}
	}

	public static void AddObjectReference(DependencyObject target, object context)
	{
		_contextAssociation.Add(target, context);
	}
}

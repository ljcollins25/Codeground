using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Uno.Diagnostics.Eventing;
using Uno.Foundation.Logging;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml;

public class FrameworkTemplatePool
{
	public static class TraceProvider
	{
		public static readonly Guid Id = Guid.Parse("{266B850B-674C-4D3E-9B58-F680BE653E18}");

		public const int CreateTemplate = 1;

		public const int RecycleTemplate = 2;

		public const int ReuseTemplate = 3;

		public const int ReleaseTemplate = 4;
	}

	private class TemplateEntry
	{
		public TimeSpan CreationTime { get; private set; }

		public UIElement Control { get; private set; }

		public TemplateEntry(TimeSpan creationTime, UIElement dependencyObject)
		{
			CreationTime = creationTime;
			Control = dependencyObject;
		}
	}

	private static readonly IEventProvider _trace = Tracing.Get(TraceProvider.Id);

	private readonly Stopwatch _watch = new Stopwatch();

	private readonly Dictionary<FrameworkTemplate, List<TemplateEntry>> _pooledInstances = new Dictionary<FrameworkTemplate, List<TemplateEntry>>(FrameworkTemplate.FrameworkTemplateEqualityComparer.Default);

	private readonly HashSet<UIElement> _activeInstances = new HashSet<UIElement>();

	internal static FrameworkTemplatePool Instance { get; } = new FrameworkTemplatePool();


	public static TimeSpan TimeToLive { get; set; } = TimeSpan.FromMinutes(1.0);


	public static bool IsPoolingEnabled { get; set; } = true;


	private FrameworkTemplatePool()
	{
		_watch.Start();
		CoreDispatcher.Main.RunIdleAsync(new IdleDispatchedHandler(Scavenger));
	}

	private async void Scavenger(IdleDispatchedHandlerArgs e)
	{
		Scavenge(isManual: false);
		await Task.Delay(TimeSpan.FromSeconds(30.0));
		CoreDispatcher.Main.RunIdleAsync(new IdleDispatchedHandler(Scavenger));
	}

	private void Scavenge(bool isManual)
	{
		TimeSpan now = _watch.Elapsed;
		int num = 0;
		foreach (List<TemplateEntry> value in _pooledInstances.Values)
		{
			num += value.RemoveAll((TemplateEntry t) => isManual || now - t.CreationTime > TimeToLive);
		}
		if (num <= 0)
		{
			return;
		}
		if (_trace.IsEnabled)
		{
			for (int i = 0; i < num; i++)
			{
				_trace.WriteEvent(4);
			}
		}
		GC.Collect();
	}

	public static void Scavenge()
	{
		Instance.Scavenge(isManual: true);
	}

	internal UIElement? DequeueTemplate(FrameworkTemplate template)
	{
		List<TemplateEntry> templatePool = GetTemplatePool(template);
		UIElement uIElement;
		if (templatePool.Count == 0)
		{
			if (_trace.IsEnabled)
			{
				IEventProvider trace = _trace;
				object[] payload = new string[1] { ((Func<UIElement?>)template).Method.DeclaringType?.ToString() };
				trace.WriteEventActivity(1, EventOpcode.Send, payload);
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Creating new template, id={GetTemplateDebugId(template)} IsPoolingEnabled:{IsPoolingEnabled}");
			}
			uIElement = template.LoadContent();
			if (IsPoolingEnabled && uIElement is IFrameworkElement)
			{
				uIElement.RegisterParentChangedCallback(template, OnParentChanged);
			}
		}
		else
		{
			int index = templatePool.Count - 1;
			uIElement = templatePool[index].Control;
			templatePool.RemoveAt(index);
			if (_trace.IsEnabled)
			{
				IEventProvider trace2 = _trace;
				object[] payload = new string[1] { uIElement.GetType().ToString() };
				trace2.WriteEventActivity(3, EventOpcode.Send, payload);
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Recycling template,    id={GetTemplateDebugId(template)}, {templatePool.Count} items remaining in cache");
			}
		}
		if (IsPoolingEnabled && uIElement != null)
		{
			_activeInstances.Add(uIElement);
		}
		return uIElement;
	}

	private List<TemplateEntry> GetTemplatePool(FrameworkTemplate template)
	{
		if (!_pooledInstances.TryGetValue(template, out var value))
		{
			value = (_pooledInstances[template] = new List<TemplateEntry>());
		}
		return value;
	}

	internal void ReleaseTemplateRoot(UIElement root, FrameworkTemplate template)
	{
		OnParentChanged(root, template, null);
	}

	private void OnParentChanged(object instance, object? key, DependencyObjectParentChangedEventArgs? args)
	{
		object instance2 = instance;
		if (!IsPoolingEnabled)
		{
			return;
		}
		List<TemplateEntry> templatePool = GetTemplatePool((key as FrameworkTemplate) ?? throw new InvalidOperationException($"Received {key} but expecting {typeof(FrameworkElement)}"));
		if (args == null || args!.NewParent == null)
		{
			if (_trace.IsEnabled)
			{
				IEventProvider trace = _trace;
				object[] payload = new string[1] { instance2.GetType().ToString() };
				trace.WriteEventActivity(2, EventOpcode.Send, payload);
			}
			PropagateOnTemplateReused(instance2);
			if (instance2 is UIElement uIElement)
			{
				templatePool.Add(new TemplateEntry(_watch.Elapsed, uIElement));
				_activeInstances.Remove(uIElement);
			}
			else if (this.Log().IsEnabled(LogLevel.Warning))
			{
				this.Log().Warn("Enqueued template root was not a view");
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Caching template,      id={GetTemplateDebugId(key as FrameworkTemplate)}, {templatePool.Count} items now in cache");
			}
		}
		else
		{
			int num = templatePool.FindIndex((TemplateEntry e) => e.Control == instance2);
			if (num != -1)
			{
				templatePool.RemoveAt(num);
			}
		}
	}

	internal static void PropagateOnTemplateReused(object instance)
	{
		if (instance is IFrameworkTemplatePoolAware frameworkTemplatePoolAware && (instance as IFrameworkElement).DataContext == null)
		{
			frameworkTemplatePoolAware.OnTemplateRecycled();
		}
		if (instance is Panel panel)
		{
			for (int i = 0; i < panel.Children.Count; i++)
			{
				object instance2 = panel.Children[i];
				PropagateOnTemplateReused(instance2);
			}
		}
		else if (instance is UIElement uIElement)
		{
			IEnumerator<UIElement> enumerator = uIElement.GetChildren().GetEnumerator();
			while (enumerator.MoveNext())
			{
				PropagateOnTemplateReused(enumerator.Current);
			}
		}
	}

	private string GetTemplateDebugId(FrameworkTemplate? template)
	{
		int num = -1;
		foreach (KeyValuePair<FrameworkTemplate, List<TemplateEntry>> pooledInstance in _pooledInstances)
		{
			num++;
			FrameworkTemplate key = pooledInstance.Key;
			if (template != null && template!.Equals(key))
			{
				Func<UIElement> func = (Func<UIElement?>)template;
				return $"{num}({func.Method.DeclaringType}.{func.Method.Name})";
			}
		}
		return "Unknown";
	}
}

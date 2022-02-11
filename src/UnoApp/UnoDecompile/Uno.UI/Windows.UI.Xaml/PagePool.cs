using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Uno.Extensions;
using Uno.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml;

public class PagePool
{
	private class PagePoolEntry
	{
		public TimeSpan CreationTime { get; private set; }

		public Page PageInstance { get; private set; }

		public PagePoolEntry(TimeSpan creationTime, Page pageInstance)
		{
			CreationTime = creationTime;
			PageInstance = pageInstance;
		}
	}

	private readonly Stopwatch _watch = new Stopwatch();

	private readonly Dictionary<Type, List<PagePoolEntry>> _pooledInstances = new Dictionary<Type, List<PagePoolEntry>>();

	public static TimeSpan TimeToLive { get; set; } = TimeSpan.FromMinutes(1.0);


	public static bool IsPoolingEnabled { get; set; } = true;


	internal PagePool()
	{
		_watch.Start();
		CoreDispatcher.Main.RunIdleAsync(new IdleDispatchedHandler(Scavenger));
	}

	private async void Scavenger(IdleDispatchedHandlerArgs e)
	{
		TimeSpan now = _watch.Elapsed;
		int num = 0;
		foreach (List<PagePoolEntry> value in _pooledInstances.Values)
		{
			num += value.RemoveAll((PagePoolEntry t) => now - t.CreationTime > TimeToLive);
		}
		if (num > 0)
		{
			GC.Collect();
		}
		await Task.Delay(TimeSpan.FromSeconds(30.0));
		CoreDispatcher.Main.RunIdleAsync(new IdleDispatchedHandler(Scavenger));
	}

	internal Page DequeuePage(Type pageType)
	{
		if (!FeatureConfiguration.Page.IsPoolingEnabled)
		{
			return Frame.CreatePageInstance(pageType);
		}
		List<PagePoolEntry> list = _pooledInstances.UnoGetValueOrDefault(pageType);
		if (list == null || list.Count == 0)
		{
			return Frame.CreatePageInstance(pageType);
		}
		int index = list.Count - 1;
		Page pageInstance = list[index].PageInstance;
		list.RemoveAt(index);
		return pageInstance;
	}

	internal void EnqueuePage(Type pageType, Page pageInstance)
	{
		List<PagePoolEntry> list = _pooledInstances.FindOrCreate(pageType, () => new List<PagePoolEntry>());
		FrameworkTemplatePool.PropagateOnTemplateReused(pageInstance);
		list.Add(new PagePoolEntry(_watch.Elapsed, pageInstance));
	}
}

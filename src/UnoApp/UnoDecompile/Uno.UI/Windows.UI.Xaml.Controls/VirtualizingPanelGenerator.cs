using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno.Extensions;
using Uno.Foundation.Logging;

namespace Windows.UI.Xaml.Controls;

internal class VirtualizingPanelGenerator
{
	private const int CacheLimit = 10;

	private const int NoTemplateItemId = -1;

	private const int IsOwnContainerItemId = -2;

	private readonly VirtualizingPanelLayout _owner;

	private readonly Dictionary<int, Stack<FrameworkElement>> _itemContainerCache = new Dictionary<int, Stack<FrameworkElement>>();

	private readonly Dictionary<int, int> _idCache = new Dictionary<int, int>();

	private readonly Dictionary<int, FrameworkElement> _scrapCache = new Dictionary<int, FrameworkElement>();

	private ItemsControl ItemsControl => _owner.ItemsControl;

	public VirtualizingPanelGenerator(VirtualizingPanelLayout owner)
	{
		_owner = owner;
	}

	public FrameworkElement DequeueViewForItem(int index)
	{
		FrameworkElement frameworkElement = TryGetScrappedContainer(index);
		if (frameworkElement != null)
		{
			return frameworkElement;
		}
		int itemId = GetItemId(index);
		FrameworkElement frameworkElement2 = TryDequeueCachedContainer(itemId);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("{0} item={1} container={2} PreviousDC={3}", GetMethodTag("DequeueViewForItem"), index, frameworkElement2, frameworkElement2?.DataContext));
		}
		if (frameworkElement2 == null)
		{
			frameworkElement2 = ItemsControl.GetContainerForIndex(index) as FrameworkElement;
		}
		ItemsControl.PrepareContainerForIndex(frameworkElement2, index);
		return frameworkElement2;
	}

	private FrameworkElement TryDequeueCachedContainer(int id)
	{
		if (id == -2)
		{
			return null;
		}
		if (_itemContainerCache.TryGetValue(id, out var value) && value.Count > 0)
		{
			FrameworkElement frameworkElement = value.Pop();
			frameworkElement.Visibility = Visibility.Visible;
			return frameworkElement;
		}
		return null;
	}

	private FrameworkElement TryGetScrappedContainer(int index)
	{
		if (_scrapCache.TryGetValue(index, out var value))
		{
			_scrapCache.Remove(index);
			return value;
		}
		return null;
	}

	public void RecycleViewForItem(FrameworkElement container, int index)
	{
		int itemId = GetItemId(index);
		if (itemId != -2)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug(string.Format("{0} container={1} index={2}", GetMethodTag("RecycleViewForItem"), container, index));
			}
			Stack<FrameworkElement> stack = _itemContainerCache.FindOrCreate(itemId, () => new Stack<FrameworkElement>());
			if (stack.Count < 10)
			{
				stack.Push(container);
			}
			else
			{
				DiscardContainer(container);
			}
		}
		else
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug(string.Format("{0} itemIsItsOwnContainer container={1} index={2}", GetMethodTag("RecycleViewForItem"), container, index));
			}
			DiscardContainer(container);
		}
	}

	private static void DiscardContainer(FrameworkElement container)
	{
		if (container.Parent is Panel panel)
		{
			panel.Children.Remove(container);
		}
	}

	public void ScrapViewForItem(FrameworkElement container, int index)
	{
		_scrapCache[index] = container;
	}

	public void ClearScrappedViews()
	{
		foreach (KeyValuePair<int, FrameworkElement> item in _scrapCache)
		{
			RecycleViewForItem(item.Value, item.Key);
		}
		_scrapCache.Clear();
	}

	public void UpdateVisibilities()
	{
		foreach (KeyValuePair<int, Stack<FrameworkElement>> item in _itemContainerCache)
		{
			foreach (FrameworkElement item2 in item.Value)
			{
				item2.Visibility = Visibility.Collapsed;
			}
		}
	}

	public void UpdateForCollectionChanges(Queue<CollectionChangedOperation> collectionChanges)
	{
		List<KeyValuePair<int, FrameworkElement>> list = _scrapCache.ToList();
		_scrapCache.Clear();
		foreach (KeyValuePair<int, FrameworkElement> item in list)
		{
			int? num = CollectionChangedOperation.Offset(item.Key, collectionChanges);
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				_scrapCache[valueOrDefault] = item.Value;
			}
			else
			{
				RecycleViewForItem(item.Value, item.Key);
			}
		}
		List<KeyValuePair<int, int>> list2 = _idCache.ToList();
		_idCache.Clear();
		foreach (KeyValuePair<int, int> item2 in list2)
		{
			int? num = CollectionChangedOperation.Offset(item2.Key, collectionChanges);
			if (num.HasValue)
			{
				int valueOrDefault2 = num.GetValueOrDefault();
				_idCache[valueOrDefault2] = item2.Value;
			}
		}
	}

	private int GetItemId(int index)
	{
		if (_idCache.TryGetValue(index, out var value))
		{
			return value;
		}
		object item = ItemsControl?.GetItemFromIndex(index);
		DataTemplate dataTemplate = ItemsControl?.ResolveItemTemplate(item);
		ItemsControl itemsControl = ItemsControl;
		int num = ((itemsControl != null && itemsControl.IsItemItsOwnContainer(item)) ? (-2) : (dataTemplate?.GetHashCode() ?? (-1)));
		_idCache.Add(index, num);
		return num;
	}

	private string GetMethodTag([CallerMemberName] string caller = null)
	{
		return "VirtualizingPanelGenerator." + caller + "()";
	}

	internal void ClearIdCache()
	{
		_idCache.Clear();
	}
}

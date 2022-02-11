using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Windows.UI.Xaml.Controls;

public class UIElementCollection : ICollection<UIElement>, IEnumerable<UIElement>, IEnumerable, IList<UIElement>, INotifyCollectionChanged
{
	private readonly UIElement _owner;

	internal DependencyObject Owner => _owner;

	public UIElement this[int index]
	{
		get
		{
			return GetAtIndexCore(index);
		}
		set
		{
			value.SetParent(_owner);
			UIElement uIElement = SetAtIndexCore(index, value);
			uIElement.SetParent(null);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, uIElement, index));
		}
	}

	public int Count => CountCore();

	public bool IsReadOnly => false;

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	public int IndexOf(UIElement item)
	{
		return IndexOfCore(item);
	}

	public void Insert(int index, UIElement item)
	{
		item.SetParent(_owner);
		InsertCore(index, item);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
	}

	public void RemoveAt(int index)
	{
		UIElement uIElement = RemoveAtCore(index);
		uIElement.SetParent(null);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, uIElement, index));
	}

	public void Add(UIElement item)
	{
		if (item != null)
		{
			item.SetParent(_owner);
		}
		AddCore(item);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
	}

	public void Clear()
	{
		IEnumerable<UIElement> enumerable = ClearCore();
		IEnumerator<UIElement> enumerator = enumerable.GetEnumerator();
		while (enumerator.MoveNext())
		{
			UIElement current = enumerator.Current;
			IDependencyObjectStoreProvider dependencyObjectStoreProvider = current;
			if (dependencyObjectStoreProvider != null)
			{
				current.SetParent(null);
			}
		}
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, enumerable.ToList()));
	}

	public bool Contains(UIElement item)
	{
		return ContainsCore(item);
	}

	public void CopyTo(UIElement[] array, int arrayIndex)
	{
		CopyToCore(array, arrayIndex);
	}

	public bool Remove(UIElement item)
	{
		if (item != null)
		{
			item.SetParent(null);
			bool result = RemoveCore(item);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
			return result;
		}
		return false;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Move(uint oldIndex, uint newIndex)
	{
		if (oldIndex != newIndex)
		{
			MoveCore(oldIndex, newIndex);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, this[(int)newIndex], (int)newIndex, (int)oldIndex));
		}
	}

	private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		this.CollectionChanged?.Invoke(this, e);
	}

	internal UIElementCollection(UIElement view)
	{
		_owner = view;
	}

	private void AddCore(UIElement item)
	{
		_owner.AddChild(item);
	}

	private IEnumerable<UIElement> ClearCore()
	{
		UIElement[] result = _owner._children.ToArray();
		_owner.ClearChildren();
		return result;
	}

	private bool ContainsCore(UIElement item)
	{
		return _owner._children.Contains(item);
	}

	private void CopyToCore(UIElement[] array, int arrayIndex)
	{
		_owner._children.ToArray().CopyTo(array, arrayIndex);
	}

	private int CountCore()
	{
		return _owner._children.Count;
	}

	private UIElement GetAtIndexCore(int index)
	{
		return _owner._children[index];
	}

	public List<UIElement>.Enumerator GetEnumerator()
	{
		return (List<UIElement>.Enumerator)(object)_owner._children.GetEnumerator();
	}

	IEnumerator<UIElement> IEnumerable<UIElement>.GetEnumerator()
	{
		return GetEnumerator();
	}

	private int IndexOfCore(UIElement item)
	{
		return _owner._children.IndexOf(item);
	}

	private void InsertCore(int index, UIElement item)
	{
		_owner.AddChild(item, index);
	}

	private void MoveCore(uint oldIndex, uint newIndex)
	{
		_owner.MoveChildTo((int)oldIndex, (int)newIndex);
	}

	private UIElement RemoveAtCore(int index)
	{
		UIElement uIElement = _owner._children.ElementAtOrDefault(index);
		_owner.RemoveChild(uIElement);
		return uIElement;
	}

	private bool RemoveCore(UIElement item)
	{
		return _owner.RemoveChild(item);
	}

	private UIElement SetAtIndexCore(int index, UIElement value)
	{
		throw new NotImplementedException();
	}
}

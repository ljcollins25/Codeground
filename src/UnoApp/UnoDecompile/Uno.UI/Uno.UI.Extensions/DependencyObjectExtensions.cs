using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Uno.UI.Xaml.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Extensions;

internal static class DependencyObjectExtensions
{
	private class VisualTreeEnumerable : IEnumerable<DependencyObject>, IEnumerable
	{
		private readonly DependencyObject _obj;

		private readonly int? _childLevelLimit;

		private readonly bool _includeCurrent;

		private readonly TreeEnumerationMode _mode;

		public VisualTreeEnumerable(DependencyObject obj, int? childLevelLimit, bool includeCurrent, TreeEnumerationMode mode)
		{
			_obj = obj;
			_childLevelLimit = childLevelLimit;
			_includeCurrent = includeCurrent;
			_mode = mode;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<DependencyObject> GetEnumerator()
		{
			TreeEnumerationMode mode = _mode;
			if (mode != 0 && mode == TreeEnumerationMode.Layer)
			{
				return new LayerEnumerator(_obj, _childLevelLimit ?? int.MaxValue, _includeCurrent);
			}
			return new BranchEnumerator(_obj, _childLevelLimit ?? int.MaxValue, _includeCurrent);
		}
	}

	private class BranchEnumerator : IEnumerator<DependencyObject>, IEnumerator, IDisposable
	{
		private readonly DependencyObject _obj;

		private readonly int _childLevelLimit;

		private readonly int _count;

		private int _index;

		private BranchEnumerator _children;

		object IEnumerator.Current => Current;

		public DependencyObject Current { get; private set; }

		public BranchEnumerator(DependencyObject obj, int childLevelLimit, bool includeCurrent)
		{
			_obj = obj;
			_childLevelLimit = childLevelLimit;
			_index = (includeCurrent ? (-2) : (-1));
			_count = VisualTreeHelper.GetChildrenCount(obj);
		}

		public bool MoveNext()
		{
			BranchEnumerator children = _children;
			if (children != null && children.MoveNext())
			{
				Current = _children.Current;
				return true;
			}
			if (++_index == -1)
			{
				Current = _obj;
				return true;
			}
			if (_index < _count && _childLevelLimit > 0)
			{
				DependencyObject child = VisualTreeHelper.GetChild(_obj, _index);
				_children = new BranchEnumerator(child, _childLevelLimit - 1, includeCurrent: true);
				return MoveNext();
			}
			Current = null;
			return false;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void Dispose()
		{
		}
	}

	private class LayerEnumerator : IEnumerator<DependencyObject>, IEnumerator, IDisposable
	{
		private class Child
		{
			public DependencyObject Value { get; }

			public int Level { get; }

			public Child Next { get; set; }

			public Child(DependencyObject value, int level)
			{
				Value = value;
				Level = level;
			}
		}

		private readonly int _childLevelLimit;

		private Child _head;

		private Child _tail;

		private int _index;

		private int _count;

		object IEnumerator.Current => Current;

		public DependencyObject Current { get; private set; }

		public LayerEnumerator(DependencyObject obj, int childLevelLimit, bool includeCurrent)
		{
			_childLevelLimit = childLevelLimit;
			_head = (_tail = new Child(obj, 0));
			_index = (includeCurrent ? (-2) : (-1));
			_count = ((childLevelLimit > 0) ? VisualTreeHelper.GetChildrenCount(_head.Value) : 0);
		}

		public bool MoveNext()
		{
			if (_tail == null)
			{
				throw new ObjectDisposedException("LayerEnumerator");
			}
			if (++_index == -1)
			{
				Current = _head.Value;
				return true;
			}
			while (_head != null && _index >= _count)
			{
				_head = _head.Next;
				if (_head != null)
				{
					_index = 0;
					_count = VisualTreeHelper.GetChildrenCount(_head.Value);
				}
			}
			if (_head == null)
			{
				Current = null;
				return false;
			}
			DependencyObject child = VisualTreeHelper.GetChild(_head.Value, _index);
			int num = _head.Level + 1;
			if (child != null && num < _childLevelLimit)
			{
				Child child3 = (_tail = (_tail.Next = new Child(child, num)));
			}
			Current = child;
			return true;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void Dispose()
		{
			_head = (_tail = null);
		}
	}

	public static IEnumerable<DependencyObject> GetAllParents(this DependencyObject element, bool includeCurrent = true)
	{
		if (includeCurrent)
		{
			yield return element;
		}
		for (DependencyObject parent = (element as FrameworkElement)?.Parent ?? VisualTreeHelper.GetParent(element); parent != null; parent = VisualTreeHelper.GetParent(parent))
		{
			yield return parent;
		}
	}

	public static T FindFirstParent<T>(this DependencyObject element, bool includeCurrent = true) where T : DependencyObject
	{
		return element.GetAllParents(includeCurrent).OfType<T>().FirstOrDefault();
	}

	public static T FindFirstParent<T>(this DependencyObject element, Func<T, bool> predicate, bool includeCurrent = true) where T : DependencyObject
	{
		return element.GetAllParents(includeCurrent).OfType<T>().FirstOrDefault(predicate);
	}

	public static IEnumerable<DependencyObject> GetChildren(this DependencyObject obj, bool includeCurrent = false)
	{
		if (includeCurrent)
		{
			yield return obj;
		}
		int count = VisualTreeHelper.GetChildrenCount(obj);
		for (int i = 0; i < count; i++)
		{
			yield return VisualTreeHelper.GetChild(obj, i);
		}
	}

	public static IEnumerable<DependencyObject> GetAllChildren(this DependencyObject obj, int? childLevelLimit = null, bool includeCurrent = false, TreeEnumerationMode mode = TreeEnumerationMode.Branch)
	{
		return new VisualTreeEnumerable(obj, childLevelLimit, includeCurrent, mode);
	}

	public static T FindFirstChild<T>(this DependencyObject element, int? childLevelLimit = null, bool includeCurrent = true) where T : DependencyObject
	{
		return element.GetAllChildren(childLevelLimit, includeCurrent).OfType<T>().FirstOrDefault();
	}

	public static T FindFirstChild<T>(this DependencyObject element, Func<T, bool> predicate, int? childLevelLimit = null, bool includeCurrent = true) where T : DependencyObject
	{
		return element.GetAllChildren(childLevelLimit, includeCurrent).OfType<T>().FirstOrDefault(predicate);
	}

	internal static CoreServices GetContext(this DependencyObject dependencyObject)
	{
		return CoreServices.Instance;
	}

	internal static DependencyObject? GetParentInternal(this DependencyObject dependencyObject, bool publicParentOnly = true)
	{
		return dependencyObject.GetParent() as DependencyObject;
	}

	internal static bool SetFocusedElement(this DependencyObject sourceElement, DependencyObject? pElementToFocus, FocusState focusState, bool animateIfBringIntoView, bool isProcessingTab = false, bool isShiftPressed = false, bool forceBringIntoView = false)
	{
		FocusNavigationDirection focusNavigationDirection = FocusNavigationDirection.None;
		if (isProcessingTab)
		{
			focusNavigationDirection = (isShiftPressed ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);
		}
		return sourceElement.SetFocusedElementWithDirection(pElementToFocus, focusState, animateIfBringIntoView, focusNavigationDirection, forceBringIntoView);
	}

	internal static bool SetFocusedElementWithDirection(this DependencyObject sourceElement, DependencyObject? pFocusedElement, FocusState focusState, bool animateIfBringIntoView, FocusNavigationDirection focusNavigationDirection, bool forceBringIntoView)
	{
		return FocusManager.SetFocusedElementWithDirection(pFocusedElement, focusState, animateIfBringIntoView, forceBringIntoView, focusNavigationDirection);
	}

	internal static DependencyObject? GetFocusedElement(this DependencyObject referenceElement)
	{
		return VisualTree.GetFocusManagerForElement(referenceElement)?.FocusedElement;
	}

	internal static VisualTree? GetVisualTree(this DependencyObject dependencyObject)
	{
		return CoreServices.Instance.MainRootVisual?.AssociatedVisualTree;
	}

	internal static void SetVisualTree(this DependencyObject dependencyObject, VisualTree visualTree)
	{
	}
}

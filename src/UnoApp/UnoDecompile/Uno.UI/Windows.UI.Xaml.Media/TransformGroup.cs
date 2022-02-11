using System;
using System.Collections.Specialized;
using System.Numerics;
using Windows.Foundation;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Media;

[ContentProperty(Name = "Children")]
public class TransformGroup : Transform
{
	public static DependencyProperty ChildrenProperty { get; } = DependencyProperty.Register("Children", typeof(TransformCollection), typeof(TransformGroup), new FrameworkPropertyMetadata(OnChildrenChanged));


	public TransformCollection Children
	{
		get
		{
			return (TransformCollection)GetValue(ChildrenProperty);
		}
		set
		{
			SetValue(ChildrenProperty, value);
		}
	}

	public Matrix Value => new Matrix(base.MatrixCore);

	internal override UIElement View
	{
		get
		{
			return base.View;
		}
		set
		{
			base.View = value;
			foreach (Transform child in Children)
			{
				child.View = value;
			}
		}
	}

	public TransformGroup()
	{
		Children = new TransformCollection();
	}

	private static void OnChildrenChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		((TransformGroup)dependencyobject).OnChildrenChanged(args);
	}

	private void OnChildrenChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.OldValue is TransformCollection transformCollection)
		{
			transformCollection.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnChildrenItemsChanged);
			foreach (Transform item in transformCollection)
			{
				OnChildRemoved(item);
			}
		}
		if (args.NewValue is TransformCollection transformCollection2)
		{
			transformCollection2.CollectionChanged += new NotifyCollectionChangedEventHandler(OnChildrenItemsChanged);
			foreach (Transform item2 in transformCollection2)
			{
				OnChildAdded(item2);
			}
		}
		NotifyChanged();
	}

	private void OnChildrenItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		NotifyCollectionChangedAction action = e.Action;
		if ((uint)action <= 2u)
		{
			if (e.NewItems != null)
			{
				foreach (object item in e.NewItems!)
				{
					if (item is Transform transform)
					{
						OnChildAdded(transform);
					}
				}
			}
			if (e.OldItems != null)
			{
				foreach (object item2 in e.OldItems!)
				{
					if (item2 is Transform transform2)
					{
						OnChildRemoved(transform2);
					}
				}
			}
		}
		NotifyChanged();
	}

	private void OnChildAdded(Transform transform)
	{
		transform.View = View;
		transform.Changed += OnChildTransformChanged;
	}

	private void OnChildRemoved(Transform transform)
	{
		transform.View = null;
		transform.Changed -= OnChildTransformChanged;
	}

	private void OnChildTransformChanged(object sender, EventArgs e)
	{
		NotifyChanged();
	}

	internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
	{
		Matrix3x2 identity = Matrix3x2.Identity;
		if (Children != null)
		{
			foreach (Transform child in Children)
			{
				identity *= child.ToMatrix(absoluteOrigin);
			}
			return identity;
		}
		return identity;
	}
}

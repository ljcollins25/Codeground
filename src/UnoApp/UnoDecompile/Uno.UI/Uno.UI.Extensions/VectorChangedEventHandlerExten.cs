using System;
using Windows.Foundation.Collections;

namespace Uno.UI.Extensions;

internal static class VectorChangedEventHandlerExtensions
{
	public static void TryRaise(this (VectorChangedEventHandler<object> generic, VectorChangedEventHandler untyped) handlers, IObservableVector<object> owner, IVectorChangedEventArgs args)
	{
		(VectorChangedEventHandler<object>, VectorChangedEventHandler) tuple = handlers;
		if (!((Delegate?)tuple.Item1 == (Delegate?)null) || !((Delegate?)tuple.Item2 == (Delegate?)null))
		{
			handlers.generic?.Invoke(owner, args);
			handlers.untyped?.Invoke(owner, args);
		}
	}

	public static void TryRaiseInserted(this VectorChangedEventHandler<object> handler, IObservableVector<object> owner, uint index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemInserted, index));
	}

	public static void TryRaiseInserted(this VectorChangedEventHandler<object> handler, IObservableVector<object> owner, int index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemInserted, (uint)index));
	}

	public static void TryRaiseInserted(this (VectorChangedEventHandler<object> generic, VectorChangedEventHandler untyped) handlers, IObservableVector<object> owner, int index)
	{
		(VectorChangedEventHandler<object>, VectorChangedEventHandler) tuple = handlers;
		if (!((Delegate?)tuple.Item1 == (Delegate?)null) || !((Delegate?)tuple.Item2 == (Delegate?)null))
		{
			VectorChangedEventArgs @event = new VectorChangedEventArgs(CollectionChange.ItemInserted, (uint)index);
			handlers.generic?.Invoke(owner, @event);
			handlers.untyped?.Invoke(owner, @event);
		}
	}

	public static void TryRaiseChanged(this VectorChangedEventHandler<object> handler, IObservableVector<object> owner, uint index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemChanged, index));
	}

	public static void TryRaiseChanged(this VectorChangedEventHandler<object> handler, IObservableVector<object> owner, int index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemChanged, (uint)index));
	}

	public static void TryRaiseChanged(this (VectorChangedEventHandler<object> generic, VectorChangedEventHandler untyped) handlers, IObservableVector<object> owner, int index)
	{
		(VectorChangedEventHandler<object>, VectorChangedEventHandler) tuple = handlers;
		if (!((Delegate?)tuple.Item1 == (Delegate?)null) || !((Delegate?)tuple.Item2 == (Delegate?)null))
		{
			VectorChangedEventArgs @event = new VectorChangedEventArgs(CollectionChange.ItemChanged, (uint)index);
			handlers.generic?.Invoke(owner, @event);
			handlers.untyped?.Invoke(owner, @event);
		}
	}

	public static void TryRaiseRemoved(this VectorChangedEventHandler<object> handler, IObservableVector<object> owner, uint index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemRemoved, index));
	}

	public static void TryRaiseRemoved(this VectorChangedEventHandler<object> handler, IObservableVector<object> owner, int index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemRemoved, (uint)index));
	}

	public static void TryRaiseRemoved(this (VectorChangedEventHandler<object> generic, VectorChangedEventHandler untyped) handlers, IObservableVector<object> owner, int index)
	{
		(VectorChangedEventHandler<object>, VectorChangedEventHandler) tuple = handlers;
		if (!((Delegate?)tuple.Item1 == (Delegate?)null) || !((Delegate?)tuple.Item2 == (Delegate?)null))
		{
			VectorChangedEventArgs @event = new VectorChangedEventArgs(CollectionChange.ItemRemoved, (uint)index);
			handlers.generic?.Invoke(owner, @event);
			handlers.untyped?.Invoke(owner, @event);
		}
	}

	public static void TryRaiseReseted(this VectorChangedEventHandler<object> handler, IObservableVector<object> owner)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.Reset, 0u));
	}

	public static void TryRaiseReseted(this (VectorChangedEventHandler<object> generic, VectorChangedEventHandler untyped) handlers, IObservableVector<object> owner)
	{
		(VectorChangedEventHandler<object>, VectorChangedEventHandler) tuple = handlers;
		if (!((Delegate?)tuple.Item1 == (Delegate?)null) || !((Delegate?)tuple.Item2 == (Delegate?)null))
		{
			VectorChangedEventArgs @event = new VectorChangedEventArgs(CollectionChange.Reset, 0u);
			handlers.generic?.Invoke(owner, @event);
			handlers.untyped?.Invoke(owner, @event);
		}
	}

	public static void TryRaiseInserted<T>(this VectorChangedEventHandler<T> handler, IObservableVector<T> owner, uint index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemInserted, index));
	}

	public static void TryRaiseChanged<T>(this VectorChangedEventHandler<T> handler, IObservableVector<T> owner, uint index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemChanged, index));
	}

	public static void TryRaiseRemoved<T>(this VectorChangedEventHandler<T> handler, IObservableVector<T> owner, uint index)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.ItemRemoved, index));
	}

	public static void TryRaiseReseted<T>(this VectorChangedEventHandler<T> handler, IObservableVector<T> owner)
	{
		handler?.Invoke(owner, new VectorChangedEventArgs(CollectionChange.Reset, 0u));
	}
}

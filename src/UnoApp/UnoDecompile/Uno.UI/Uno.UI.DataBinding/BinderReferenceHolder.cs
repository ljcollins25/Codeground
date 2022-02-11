using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.DataBinding;

[DebuggerDisplay("{_handle}", Name = "{_type.ToString(),nq}")]
[DebuggerTypeProxy(typeof(BinderReferenceHolderDebuggerProxy))]
public class BinderReferenceHolder
{
	private class BinderReferenceHolderDebuggerProxy
	{
		public bool IsAlive { get; }

		public BinderReference[] References { get; }

		public object Target { get; }

		public GlobalStats GlobalStats => GlobalStats.Default;

		public BinderReferenceHolderDebuggerProxy(BinderReferenceHolder holder)
		{
			IsAlive = holder._target.IsAlive;
			Target = holder._target;
			References = holder._newReferences.Select((KeyValuePair<IntPtr, Tuple<Type, WeakReference>> p) => new BinderReference(p.Value.Item1, p.Value.Item2.Target)).ToArray();
		}
	}

	private class BinderReference
	{
		public object Target { get; }

		public Type Type { get; }

		public BinderReference(Type type, object target)
		{
			Type = type;
			Target = target;
		}
	}

	[DebuggerDisplay("BinderDetails global stats (may be slow)")]
	private class GlobalStats
	{
		public static readonly GlobalStats Default = new GlobalStats();

		public object[] InactiveViewBinders => GetInactiveViewReferencesStats();
	}

	public const string BinderActiveReferencesCounter = "Performance.ActiveBinders";

	public const string BinderCollectedReferencesCounter = "Performance.CollectedBinders";

	private static Dictionary<IntPtr, WeakReference> _nativeHolders = new Dictionary<IntPtr, WeakReference>();

	private static List<WeakReference> _holders = new List<WeakReference>();

	private readonly WeakReference _ref;

	private readonly Type _type;

	private readonly WeakReference _target;

	private readonly Dictionary<IntPtr, Tuple<Type, WeakReference>> _newReferences = new Dictionary<IntPtr, Tuple<Type, WeakReference>>();

	private readonly IntPtr _handle;

	public static bool IsEnabled { get; set; } = false;


	public BinderReferenceHolder(Type type, object target)
	{
		_type = type;
		_target = new WeakReference(target);
		lock (_holders)
		{
			_ref = new WeakReference(this);
			_handle = IntPtr.Zero;
			if (target is UIElement uIElement)
			{
				_handle = uIElement.Handle;
				_nativeHolders[_handle] = _ref;
			}
			else
			{
				_holders.Add(_ref);
			}
		}
	}

	public static void AddNativeReference(UIElement instance, UIElement parent)
	{
		if (_nativeHolders.TryGetValue(instance.Handle, out var value) && value.Target is BinderReferenceHolder binderReferenceHolder)
		{
			binderReferenceHolder._newReferences[parent.Handle] = Tuple.Create(parent.GetType(), new WeakReference(parent));
		}
	}

	public static void RemoveNativeReference(UIElement instance, UIElement parent)
	{
		if (_nativeHolders.TryGetValue(instance.Handle, out var value) && value.Target is BinderReferenceHolder binderReferenceHolder && parent != null)
		{
			binderReferenceHolder._newReferences.Remove(parent.Handle);
		}
	}

	public static BinderReferenceHolder[] GetInactiveViewBinders()
	{
		IEnumerable<BinderReferenceHolder> source = from r in _holders.Concat(_nativeHolders.Values)
			let holder = r.Target as BinderReferenceHolder
			where holder != null && holder.IsInactiveView()
			select holder;
		return source.ToArray();
	}

	public static BinderReferenceHolder[] GetInactiveChildViewBinders()
	{
		IEnumerable<BinderReferenceHolder> source = from r in _holders.Concat(_nativeHolders.Values)
			let holder = r.Target as BinderReferenceHolder
			let view = holder?._target.Target as UIElement
			where view != null && !IsInactiveView(view) && IsInactiveView(view.GetTopLevelParent())
			select holder;
		return source.ToArray();
	}

	public static T[] GetInactiveInstancesOfType<T>()
	{
		return (from h in GetInactiveViewBinders()
			select h._target.Target).OfType<T>().ToArray();
	}

	public static T[] GetInactiveChildInstancesOfType<T>()
	{
		return (from h in GetInactiveChildViewBinders()
			select h._target.Target).OfType<T>().ToArray();
	}

	public static Tuple<Type, int>[] GetReferenceStats()
	{
		lock (_holders)
		{
			IEnumerable<Tuple<Type, int>> source = from r in _holders.Concat(_nativeHolders.Values)
				let holder = r.Target as BinderReferenceHolder
				where holder != null
				group holder by holder._type into types
				let count = types.Count()
				orderby count descending
				select Tuple.Create(types.Key, count);
			return source.ToArray();
		}
	}

	public static void LogReferenceStatsWithDetails()
	{
		lock (_holders)
		{
			IEnumerable<Tuple<Type, int, IEnumerable<Type>>> enumerable = from r in _holders.Concat(_nativeHolders.Values)
				let holder = r.Target as BinderReferenceHolder
				where holder != null
				where holder._type == typeof(Grid)
				group holder by holder._type into types
				let count = types.Count()
				let parents = (from type in types
					let parentType = (type._target?.Target as DependencyObject).GetParent()?.GetType()
					where parentType != null
					select parentType).Distinct()
				orderby count descending
				select Tuple.Create(types.Key, count, parents);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Detailed DependencyObject references: \r\n");
			foreach (Tuple<Type, int, IEnumerable<Type>> item in enumerable)
			{
				stringBuilder.AppendFormatInvariant("\t{0}: {1}, [{2}]\r\n", item.Item1, item.Item2, string.Join(", ", item.Item3));
			}
			if (IsEnabled && typeof(BinderReferenceHolder).Log().IsEnabled(LogLevel.Information))
			{
				typeof(BinderReferenceHolder).Log().Info(stringBuilder.ToString());
			}
		}
	}

	public static void LogActiveViewReferencesStatsDiff(Tuple<Type, int>[] activeStats)
	{
		Tuple<Type, int>[] referenceStats = GetReferenceStats();
		LogDiff(activeStats, referenceStats, "Active");
	}

	public static void LogInactiveViewReferencesStatsDiff(Tuple<Type, int>[] inactiveStats)
	{
		Tuple<Type, int>[] inactiveViewReferencesStats = GetInactiveViewReferencesStats();
		LogDiff(inactiveStats, inactiveViewReferencesStats, "Inactive");
	}

	private static void LogDiff(Tuple<Type, int>[] oldInactiveStats, Tuple<Type, int>[] newInactiveStats, string referenceType)
	{
		var enumerable = from oldInactiveStat in oldInactiveStats
			from newInactiveStat in newInactiveStats
			where oldInactiveStat.Item1 == newInactiveStat.Item1
			let diff = newInactiveStat.Item2 - oldInactiveStat.Item2
			where diff != 0
			select new
			{
				Type = oldInactiveStat.Item1,
				Diff = diff
			};
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Detailed " + referenceType + " DependencyObject references delta: \r\n");
		foreach (var item in enumerable)
		{
			stringBuilder.AppendFormatInvariant("\t{0}: {1}\r\n", item.Type, item.Diff);
		}
		if (IsEnabled && typeof(BinderReferenceHolder).Log().IsEnabled(LogLevel.Information))
		{
			typeof(BinderReferenceHolder).Log().Info(stringBuilder.ToString());
		}
	}

	public static Tuple<Type, int>[] GetInactiveViewReferencesStats()
	{
		lock (_holders)
		{
			IEnumerable<Tuple<Type, int>> source = from r in _holders.Concat(_nativeHolders.Values)
				let holder = r.Target as BinderReferenceHolder
				where holder != null && holder.IsInactiveView()
				group holder by holder._type into types
				let count = types.Count()
				orderby count descending
				select Tuple.Create(types.Key, count);
			return source.ToArray();
		}
	}

	public static void LogReport()
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Inactive DependencyObject references: \r\n");
			Tuple<Type, int>[] inactiveViewReferencesStats = GetInactiveViewReferencesStats();
			foreach (Tuple<Type, int> tuple in inactiveViewReferencesStats)
			{
				stringBuilder.AppendFormatInvariant("\t{0}: {1}\r\n", tuple.Item1, tuple.Item2);
			}
			stringBuilder.Append("Active DependencyObject references: \r\n");
			Tuple<Type, int>[] referenceStats = GetReferenceStats();
			foreach (Tuple<Type, int> tuple2 in referenceStats)
			{
				stringBuilder.AppendFormatInvariant("\t{0}: {1}\r\n", tuple2.Item1, tuple2.Item2);
			}
			if (IsEnabled && typeof(BinderReferenceHolder).Log().IsEnabled(LogLevel.Information))
			{
				typeof(BinderReferenceHolder).Log().Info(stringBuilder.ToString());
			}
		}
		catch (Exception ex)
		{
			if (typeof(BinderReferenceHolder).Log().IsEnabled(LogLevel.Error))
			{
				typeof(BinderReferenceHolder).Log().Error("Failed to generate binders report", ex);
			}
		}
	}

	private bool IsInactiveView()
	{
		return IsInactiveView(_target.Target);
	}

	private static bool IsInactiveView(object target)
	{
		return false;
	}

	~BinderReferenceHolder()
	{
		if (IsEnabled && this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Collecting [{_type}]");
		}
		lock (_holders)
		{
			if (_handle != IntPtr.Zero)
			{
				_nativeHolders.Remove(_handle);
			}
			else
			{
				_holders.Remove(_ref);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object GetDebuggerProxy()
	{
		return new BinderReferenceHolderDebuggerProxy(this);
	}
}

using System;
using Uno.Disposables;
using Windows.UI.Core;

namespace Windows.UI.Xaml;

internal class DispatcherConditionalDisposable : ConditionalDisposable
{
	private readonly WeakReference _conditionSource;

	public DispatcherConditionalDisposable(object target, WeakReference conditionSource, Action action)
		: base(target, Wrap(action), conditionSource)
	{
		_conditionSource = conditionSource;
	}

	private static Action Wrap(Action action)
	{
		return delegate
		{
			if (CoreDispatcher.Main.HasThreadAccess)
			{
				action();
			}
			else
			{
				CoreDispatcher.Main.RunIdleAsync(delegate
				{
					action();
				});
			}
		};
	}
}

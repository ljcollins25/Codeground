using Windows.UI.Core;

namespace DirectUI;

internal class BuildTreeService
{
	public void RegisterWork(ITreeBuilder treeBuilder)
	{
		treeBuilder.IsRegisteredForCallbacks = true;
		CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.High, delegate
		{
			if (treeBuilder.IsBuildTreeSuspended)
			{
				RegisterWork(treeBuilder);
			}
			else
			{
				treeBuilder.IsRegisteredForCallbacks = false;
				if (treeBuilder.BuildTree() && !treeBuilder.IsRegisteredForCallbacks)
				{
					RegisterWork(treeBuilder);
				}
			}
		});
	}
}

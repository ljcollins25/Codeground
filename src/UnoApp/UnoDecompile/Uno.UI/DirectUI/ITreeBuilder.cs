namespace DirectUI;

internal interface ITreeBuilder
{
	bool IsBuildTreeSuspended { get; }

	bool IsRegisteredForCallbacks { get; set; }

	bool BuildTree();
}

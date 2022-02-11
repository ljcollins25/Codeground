namespace Microsoft.UI.Xaml.Controls;

public struct FlowLayoutAnchorInfo
{
	public int Index;

	public double Offset;

	internal FlowLayoutAnchorInfo(in int index, in double offset)
	{
		Index = index;
		Offset = offset;
	}
}

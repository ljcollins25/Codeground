namespace Microsoft.UI.Private.Controls;

internal class SplitButtonTestHelper
{
	private bool m_simulateTouch;

	public static SplitButtonTestHelper Instance { get; } = new SplitButtonTestHelper();


	public static bool SimulateTouch
	{
		get
		{
			return Instance.m_simulateTouch;
		}
		set
		{
			Instance.m_simulateTouch = value;
		}
	}
}

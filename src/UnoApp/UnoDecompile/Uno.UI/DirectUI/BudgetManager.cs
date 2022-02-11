namespace DirectUI;

internal class BudgetManager
{
	private const int BUDGET_MANAGER_DEFAULT_LIMIT = 40;

	private void Initialize()
	{
	}

	private void StoreFrameTime(bool isBeginOfTick)
	{
	}

	private void GetElapsedMilliSecondsSinceLastUITickImpl(out int returnValue)
	{
		returnValue = 0;
	}

	public int GetElapsedMilliSecondsSinceLastUITick()
	{
		return 1;
	}
}

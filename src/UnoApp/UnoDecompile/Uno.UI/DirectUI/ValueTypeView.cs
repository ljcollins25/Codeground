namespace DirectUI;

internal class ValueTypeView<T> : ValueTypeViewBase<T>
{
	protected ValueTypeView()
	{
	}

	public void IndexOf(T value, out uint index, out bool found)
	{
		index = 0u;
		found = false;
		CheckThread();
		found = IndexOf(value, out index);
	}
}

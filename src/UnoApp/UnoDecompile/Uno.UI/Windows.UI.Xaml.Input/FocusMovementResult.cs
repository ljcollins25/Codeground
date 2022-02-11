namespace Windows.UI.Xaml.Input;

public class FocusMovementResult
{
	public bool Succeeded { get; internal set; }

	internal bool WasMoved { get; }

	internal bool WasCanceled { get; }

	internal FocusMovementResult()
	{
	}

	internal FocusMovementResult(bool wasMoved, bool wasCanceled)
	{
		WasMoved = wasMoved;
		WasCanceled = wasCanceled;
	}
}

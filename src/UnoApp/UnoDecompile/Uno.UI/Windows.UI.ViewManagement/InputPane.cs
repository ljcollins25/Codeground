using Windows.Foundation;
using Windows.UI.Core;

namespace Windows.UI.ViewManagement;

public class InputPane
{
	private static InputPane _instance = new InputPane();

	private Rect _occludedRect = new Rect(0.0, 0.0, 0.0, 0.0);

	public Rect OccludedRect
	{
		get
		{
			return _occludedRect;
		}
		internal set
		{
			if (_occludedRect != value)
			{
				_occludedRect = value;
				OnOccludedRectChanged();
			}
		}
	}

	public bool Visible
	{
		get
		{
			return OccludedRect.Height > 0.0;
		}
		set
		{
			if (value)
			{
				TryShow();
			}
			else
			{
				TryHide();
			}
		}
	}

	public event TypedEventHandler<InputPane, InputPaneVisibilityEventArgs> Hiding;

	public event TypedEventHandler<InputPane, InputPaneVisibilityEventArgs> Showing;

	public static InputPane GetForCurrentView()
	{
		return _instance;
	}

	public bool TryShow()
	{
		if (Visible)
		{
			return false;
		}
		return true;
	}

	public bool TryHide()
	{
		if (!Visible)
		{
			return false;
		}
		return true;
	}

	internal void OnOccludedRectChanged()
	{
		InputPaneVisibilityEventArgs inputPaneVisibilityEventArgs = new InputPaneVisibilityEventArgs(OccludedRect);
		if (Visible)
		{
			this.Showing?.Invoke(this, inputPaneVisibilityEventArgs);
		}
		else
		{
			this.Hiding?.Invoke(this, inputPaneVisibilityEventArgs);
		}
		if (!inputPaneVisibilityEventArgs.EnsuredFocusedElementInView)
		{
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
			});
		}
	}
}

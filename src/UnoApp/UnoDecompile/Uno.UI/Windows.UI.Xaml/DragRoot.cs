using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml;

internal class DragRoot : Canvas
{
	public int PendingDragCount => base.Children.Count;

	public DragRoot()
	{
		base.VerticalAlignment = VerticalAlignment.Stretch;
		base.HorizontalAlignment = HorizontalAlignment.Stretch;
		base.Background = new SolidColorBrush(Colors.Transparent);
		base.IsHitTestVisible = false;
	}

	public void Show(DragView view)
	{
		view.IsHitTestVisible = false;
		base.Children.Add(view);
	}

	public void Hide(DragView view)
	{
		base.Children.Remove(view);
	}
}
